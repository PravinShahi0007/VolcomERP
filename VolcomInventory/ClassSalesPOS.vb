Imports MySql.Data.MySqlClient

Public Class ClassSalesPOS
    Public splash As DevExpress.XtraSplashScreen.SplashScreenManager

    Public Function queryMainNoStock(ByVal condition As String, ByVal order_type As String) As String
        If order_type = "1" Then
            order_type = "ASC "
        ElseIf order_type = "2" Then
            order_type = "DESC "
        End If

        If condition <> "-1" Then
            condition = condition
        Else
            condition = ""
        End If

        Dim query As String = "SELECT ns.id_sales_pos_no_stock, ns.id_comp, c.comp_number, c.comp_name, CONCAT(c.comp_number, ' - ', c.comp_name) AS `comp`, 
        ns.`number`, ns.created_date, 
        ns.period_from, ns.period_until, ns.created_by, emp.employee_name AS `created_by_name`, ns.note, ns.id_report_status, stt.report_status
        FROM tb_sales_pos_no_stock ns
        INNER JOIN tb_m_comp c ON c.id_comp = ns.id_comp
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = ns.id_report_status
        INNER JOIN tb_m_user u ON u.id_user = ns.created_by
        INNER JOIN tb_m_employee emp ON emp.id_employee = u.id_employee
        WHERE ns.id_sales_pos_no_stock>0 "
        query += condition + " "
        query += "ORDER BY ns.id_sales_pos_no_stock " + order_type
        Return query
    End Function

    Public Sub syncOutlet(ByVal id_outlet_par As String, ByVal outlet_par As String, ByVal host_par As String, ByVal username_par As String, ByVal pass_par As String, ByVal db_par As String)
        Dim curr_time As String = DateTime.Parse(getTimeDB.ToString).ToString("yyyy-MM-dd HH:mm:ss")
        Dim id_pos_last As String = ""
        Dim constring As String = "server=" + host_par + ";user=" + username_par + ";pwd=" + pass_par + ";database=" + db_par + ";"
        Dim path_root As String = Application.StartupPath
        Dim fileName As String = "bup" + ".sql"
        Dim file As String = IO.Path.Combine(path_root, fileName)
        Dim dic As New Dictionary(Of String, String)()

        splash.SetWaitFormCaption(outlet_par)
        splash.SetWaitFormDescription("Prepare data")
        Dim ql As String = "SELECT a.id_pos FROM tb_pos_sync_log a WHERE a.id_outlet='" + id_outlet_par + "' AND a.is_success=1 ORDER BY a.sync_time DESC LIMIT 1"
        Dim dql As DataTable = execute_query(ql, -1, True, "", "", "", "")
        If dql.Rows.Count > 0 Then
            id_pos_last = dql.Rows(0)("id_pos").ToString
        Else
            id_pos_last = "0"
        End If
        dic.Add("tb_pos", "SELECT * FROM tb_pos p WHERE p.is_closed=1 AND p.id_pos>'" + id_pos_last + "';")
        dic.Add("tb_pos_det", "SELECT pd.* FROM tb_pos p INNER JOIN tb_pos_det pd ON pd.id_pos = p.id_pos WHERE p.is_closed=1 AND p.id_pos>'" + id_pos_last + "';")
        dic.Add("tb_pos_summary", "SELECT pd.* FROM tb_pos p INNER JOIN tb_pos_summary pd ON pd.id_pos = p.id_pos WHERE p.is_closed=1 AND p.id_pos>'" + id_pos_last + "';")

        'backup
        splash.SetWaitFormDescription("Backup data")
        Using conn As New MySqlConnection(constring)
            Using cmd As New MySqlCommand()
                Using mb As New MySqlBackup(cmd)
                    cmd.Connection = conn
                    conn.Open()
                    mb.ExportInfo.AddCreateDatabase = False
                    mb.ExportInfo.ExportTableStructure = True
                    mb.ExportInfo.ExportRows = True
                    mb.ExportInfo.TablesToBeExportedDic = dic
                    mb.ExportInfo.ExportProcedures = False
                    mb.ExportInfo.ExportFunctions = False
                    mb.ExportInfo.ExportTriggers = False
                    mb.ExportInfo.ExportEvents = False
                    mb.ExportInfo.ExportViews = False
                    mb.ExportInfo.EnableEncryption = True
                    mb.ExportInfo.EncryptionPassword = "csmtafc"
                    mb.ExportToFile(file)
                End Using
            End Using
        End Using

        'restore
        splash.SetWaitFormDescription("Restoring data")
        Dim constring_erp As String = "server=" + app_host + ";user=" + app_username + ";pwd=" + app_password + ";database=db_sync;"
        Dim path_root_erp As String = Application.StartupPath
        Dim fileName_erp As String = "bup" + ".sql"
        Dim file_erp As String = IO.Path.Combine(path_root_erp, fileName_erp)
        Using conn As New MySqlConnection(constring_erp)
            Using cmd As New MySqlCommand()
                Using mb As New MySqlBackup(cmd)
                    cmd.Connection = conn
                    conn.Open()
                    mb.ImportInfo.TargetDatabase = "db_sync"
                    mb.ImportInfo.EnableEncryption = True
                    mb.ImportInfo.EncryptionPassword = "csmtafc"
                    mb.ImportFromFile(file)
                    conn.Close()
                End Using
            End Using
        End Using

        'sync
        splash.SetWaitFormDescription("Synchronize data")
        Dim err As String = ""
        Try
            Dim qry As String = "
            /*main*/ 
            INSERT INTO tb_pos_combine(
                `id_pos`, `id_outlet`, `id_pos_ref` , `pos_number` , `pos_date`,`pos_closed_date`,
                `id_shift` , `shift_type`, `id_user_employee`, `id_pos_status` , `id_pos_cat`, `subtotal`,
                `discount`, `tax` , `total`, `id_voucher`, `voucher_number`, `voucher` , `point`,
                `cash`, `card`, `id_card_type`, `card_number`, `card_name`,
                `change`, `total_qty`, `id_sales`, `id_country`, `is_payment_ok`,
                `is_closed` , `closed_date`,`closed_by`, `is_get_promo`
            )
            SELECT 
            p.`id_pos`, p.`id_outlet`, p.`id_pos_ref` , p.`pos_number` , p.`pos_date`,p.`pos_closed_date`,
            p.`id_shift` , p.`shift_type`, p.`id_user_employee`, p.`id_pos_status` , p.`id_pos_cat`, p.`subtotal`,
            p.`discount`, p.`tax` , p.`total`, p.`id_voucher`, p.`voucher_number`, p.`voucher` , p.`point`,
            p.`cash`, p.`card`, p.`id_card_type`, p.`card_number`, p.`card_name`,
            p.`change`, p.`total_qty`, p.`id_sales`, p.`id_country`, p.`is_payment_ok`,
            p.`is_closed` , p.`closed_date`,p.`closed_by`, p.`is_get_promo`
            FROM db_sync.tb_pos p
            LEFT JOIN tb_pos_combine pc ON pc.id_pos = p.id_pos AND pc.id_outlet = p.id_outlet
            WHERE ISNULL(pc.id_pos_combine); 
            /*detail*/
            INSERT INTO tb_pos_combine_det(id_pos_combine,`id_pos_det`, `id_pos`, `id_item`, `item_code`, `id_product`, `id_comp_sup`, `comm`, `qty`, `price`, `id_design_cat`, `is_free_promo`)
            SELECT pc.id_pos_combine,pd.`id_pos_det`, pd.`id_pos`, pd.`id_item`, pd.`item_code`, pd.`id_product`, pd.`id_comp_sup`, pd.`comm`, pd.`qty`, pd.`price`, pd.`id_design_cat`, pd.`is_free_promo`
            FROM db_sync.tb_pos_det pd
            INNER JOIN tb_pos_combine pc ON pc.id_pos = pd.id_pos AND pc.id_outlet=" + id_outlet_par + "
            LEFT JOIN (
                SELECT pcd.id_pos_combine_det AS `id_detail`,pcd.id_pos_det 
                FROM tb_pos_combine_det pcd
                INNER JOIN tb_pos_combine pc ON pc.id_pos_combine = pcd.id_pos_combine
                WHERE pc.id_outlet=" + id_outlet_par + "
            ) e ON e.id_pos_det = pd.id_pos_det
            WHERE ISNULL(e.id_detail); 
            /*summary*/
            INSERT INTO tb_pos_combine_summary(id_pos_combine, `id_pos`, `id_item`, `item_code`, `id_product`, `id_comp_sup`, `comm`, `qty`, `price`, `id_design_cat`, `is_free_promo`)
            SELECT pc.id_pos_combine,ps.`id_pos`, ps.`id_item`, ps.`item_code`, ps.`id_product`, ps.`id_comp_sup`, ps.`comm`, ps.`qty`, ps.`price`, ps.`id_design_cat`, ps.`is_free_promo`
            FROM db_sync.tb_pos_summary ps
            INNER JOIN tb_pos_combine pc ON pc.id_pos = ps.id_pos AND pc.id_outlet=" + id_outlet_par + "
            LEFT JOIN (
                SELECT pcs.id_pos_combine_summary AS `id_summary`, pcs.id_pos 
                FROM tb_pos_combine_summary pcs
                INNER JOIN tb_pos_combine pc ON pc.id_pos_combine = pcs.id_pos_combine
                WHERE pc.id_outlet=" + id_outlet_par + "
            ) e ON e.id_pos = ps.id_pos    
            WHERE ISNULL(e.id_summary); "
            execute_non_query(qry, True, "", "", "", "")
        Catch ex As Exception
            err += ex.ToString + "; "
        End Try

        Dim is_success = ""
        If err = "" Then
            is_success = "1"
        Else
            is_success = "2"
        End If
        Dim qlast As String = "INSERT INTO tb_pos_sync_log(sync_time,id_outlet, id_pos, is_success, remark)
        SELECT '" + curr_time + "', '" + id_outlet_par + "',IFNULL(MAX(pc.id_pos),0), '" + is_success + "',  '" + addSlashes(err) + "'
        FROM tb_pos_combine pc WHERE pc.id_outlet='" + id_outlet_par + "' "
        execute_non_query(qlast, True, "", "", "", "")
    End Sub

    Public Sub syncAllOutlet()
        Dim query As String = "SELECT sc.`id_outlet`, sc.outlet_name AS `outlet`,
        sc.host, sc.username, sc.pass, sc.db
        FROM tb_store_conn "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To data.Rows.Count - 1
            syncOutlet(data.Rows(i)("id_outlet").ToString, data.Rows(i)("outlet").ToString, data.Rows(i)("host").ToString, data.Rows(i)("username").ToString, data.Rows(i)("pass").ToString, data.Rows(i)("db").ToString)
        Next
    End Sub

    Public Function querySalesRecord(ByVal condition As String, ByVal order_type As String) As String
        If order_type = "1" Then
            order_type = "ASC "
        ElseIf order_type = "2" Then
            order_type = "DESC "
        End If

        If condition <> "-1" Then
            condition = condition
        Else
            condition = ""
        End If

        Dim query As String = "SELECT pc.id_pos_combine, pc.id_pos, pc.id_outlet, d.departement AS `outlet`, pc.id_pos_ref, pc.pos_number,
        pc.pos_date, pc.pos_closed_date, pc.id_shift, pc.shift_type, pc.id_user_employee, e.employee_name AS `user_employee`, pc.id_pos_status,
        pc.id_pos_cat, pc.subtotal, pc.discount, pc.tax, pc.total, pc.id_voucher, pc.voucher_number, pc.voucher,
        pc.point, pc.cash, pc.card, pc.id_card_type, ct.card_type, pc.card_number, pc.card_name, pc.`change`, pc.total_qty, pc.id_sales, es.employee_name AS `sales_name`,
        pc.id_country, cty.country, pc.closed_date, pc.closed_by, pc.sync_time 
        FROM tb_pos_combine pc 
        INNER JOIN tb_m_employee e ON e.id_employee = pc.id_user_employee
        INNER JOIN tb_m_employee es ON es.id_employee = pc.id_sales
        INNER JOIN tb_m_departement d ON d.id_departement = pc.id_outlet
        LEFT JOIN tb_lookup_card_type ct ON ct.id_card_type = pc.id_card_type
        LEFT JOIN tb_m_country cty ON cty.id_country = pc.id_country
        WHERE pc.id_pos_combine>0 "
        query += condition + " "
        query += "ORDER BY pc.id_outlet ASC, pc.id_pos " + order_type
        Return query
    End Function

    Sub detailReport(ByVal id_sales_pos As String, ByVal XTable As DevExpress.XtraReports.UI.XRTable, ByVal XTRow As DevExpress.XtraReports.UI.XRTableRow)
        Dim row As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow
        Dim query As String = "CALL view_sales_pos_less('" + id_sales_pos + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

        Dim font_row_style As New Font("Segoe UI", 8, FontStyle.Regular)
        For i = 0 To data.Rows.Count - 1
            'row
            If i = 0 Then
                row = XTable.InsertRowBelow(XTRow)
                row.HeightF = 15
            Else
                row = XTable.InsertRowBelow(row)
            End If

            'no
            Dim no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
            no.Text = (i + 1).ToString + "."
            no.Borders = DevExpress.XtraPrinting.BorderSide.None
            no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            no.BackColor = Color.Transparent
            no.Font = font_row_style

            'barcode
            Dim code As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
            code.Text = data.Rows(i)("code").ToString
            code.Borders = DevExpress.XtraPrinting.BorderSide.None
            code.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            code.BackColor = Color.Transparent
            code.Font = font_row_style

            'descrition
            Dim descrip As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
            descrip.Text = data.Rows(i)("name").ToString
            descrip.Borders = DevExpress.XtraPrinting.BorderSide.None
            descrip.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            descrip.BackColor = Color.Transparent
            descrip.Font = font_row_style

            'size
            Dim size As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
            size.Text = data.Rows(i)("size").ToString
            size.Borders = DevExpress.XtraPrinting.BorderSide.None
            size.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            size.BackColor = Color.Transparent
            size.Font = font_row_style

            'qty
            Dim qty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
            qty.Text = Decimal.Parse(data.Rows(i)("sales_pos_det_qty").ToString).ToString("N0")
            qty.Borders = DevExpress.XtraPrinting.BorderSide.None
            qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            qty.BackColor = Color.Transparent
            qty.Font = font_row_style

            'price
            Dim price As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
            price.Text = Decimal.Parse(data.Rows(i)("design_price_retail").ToString).ToString("N0")
            price.Borders = DevExpress.XtraPrinting.BorderSide.None
            price.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            price.BackColor = Color.Transparent
            price.Font = font_row_style

            'amount
            Dim amo As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)
            amo.Text = Decimal.Parse(data.Rows(i)("sales_pos_det_amount").ToString).ToString("N0")
            amo.Borders = DevExpress.XtraPrinting.BorderSide.None
            amo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            amo.BackColor = Color.Transparent
            amo.Font = font_row_style
        Next
    End Sub

    Sub detailReportDelSlip(ByVal id_sales_pos As String, ByVal XTable As DevExpress.XtraReports.UI.XRTable, ByVal XTRow As DevExpress.XtraReports.UI.XRTableRow)
        Dim row As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow
        Dim query As String = "CALL view_sales_pos_less('" + id_sales_pos + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

        Dim font_row_style As New Font("Segoe UI", 8, FontStyle.Regular)
        For i = 0 To data.Rows.Count - 1
            'row
            If i = 0 Then
                row = XTable.InsertRowBelow(XTRow)
                row.HeightF = 15
            Else
                row = XTable.InsertRowBelow(row)
            End If

            'no
            Dim no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
            no.Text = (i + 1).ToString + "."
            no.Borders = DevExpress.XtraPrinting.BorderSide.None
            no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            no.BackColor = Color.Transparent
            no.Font = font_row_style

            'barcode
            Dim code As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
            code.Text = data.Rows(i)("code").ToString
            code.Borders = DevExpress.XtraPrinting.BorderSide.None
            code.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            code.BackColor = Color.Transparent
            code.Font = font_row_style

            'descrition
            Dim descrip As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
            descrip.Text = data.Rows(i)("name").ToString
            descrip.Borders = DevExpress.XtraPrinting.BorderSide.None
            descrip.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            descrip.BackColor = Color.Transparent
            descrip.Font = font_row_style

            'size
            Dim size As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
            size.Text = data.Rows(i)("size").ToString
            size.Borders = DevExpress.XtraPrinting.BorderSide.None
            size.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            size.BackColor = Color.Transparent
            size.Font = font_row_style

            'qty
            Dim qty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
            qty.Text = Decimal.Parse(data.Rows(i)("sales_pos_det_qty").ToString).ToString("N0")
            qty.Borders = DevExpress.XtraPrinting.BorderSide.None
            qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            qty.BackColor = Color.Transparent
            qty.Font = font_row_style
        Next
    End Sub
End Class
