Public Class FormMailManageDet
    Public rmt As String = "-1"
    Public action As String = "-1"
    Public id As String = "-1"
    Dim id_mail_status As String = "-1"
    Dim mail_head As String = ""
    Dim mail_subject As String = ""
    Dim mail_title As String = ""
    Dim mail_content_head As String = ""
    Dim mail_content As String = ""
    Dim mail_content_end As String = ""
    Dim mail_content_to As String = ""
    Dim super_user As String = get_setup_field("id_role_super_admin")

    Private Sub FormMailManageDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Private Sub FormMailManageDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Function dtLoadDetail(ByVal id_sales_pos_par As String)
        Dim dt As New DataTable
        If rmt = "225" Then
            Dim qdet As String = "SELECT '' AS `no`, sp.id_sales_pos AS `id_report`, sp.sales_pos_number AS `report_number`,
            CONCAT(c.comp_number, ' - ', c.comp_name) AS `store`, g.description AS `group_store`,
            cg.comp_name AS `group_company`, 
            CONCAT(DATE_FORMAT(sp.sales_pos_start_period,'%d-%m-%y'),' s/d ', DATE_FORMAT(sp.sales_pos_end_period,'%d-%m-%y')) AS `period`,
            DATE_FORMAT(sp.sales_pos_due_date,'%d-%m-%y') AS `sales_pos_due_date`,
            sp.sales_pos_total_qty AS `qty_invoice`, 
            CAST(IF(typ.`is_receive_payment`=2,-1,1) * sp.netto AS DECIMAL(15,2)) AS `amount`,
            prd.period AS `period_header`,
            prd.amount AS `total_amount`,
            prd.total_qty AS `total_qty`,
            sp.report_mark_type
            FROM tb_sales_pos sp 
            INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
            INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
            INNER JOIN tb_m_comp_group g ON g.id_comp_group = c.id_comp_group
            INNER JOIN tb_m_comp cg ON cg.id_comp = c.id_store_company
            INNER JOIN (
	            SELECT c.id_comp_group,
	            GROUP_CONCAT(DISTINCT CONCAT(DATE_FORMAT(sp.sales_pos_start_period,'%d-%m-%y'),' s/d ', DATE_FORMAT(sp.sales_pos_end_period,'%d-%m-%y')) ORDER BY sp.id_sales_pos ASC SEPARATOR ', ') AS `period`,
	            SUM(CAST(IF(typ.`is_receive_payment`=2,-1,1) * sp.netto AS DECIMAL(15,2))) AS `amount`,
                SUM(sp.sales_pos_total_qty) AS `total_qty`
	            FROM tb_sales_pos sp
	            INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
	            INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
	            INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
	            WHERE sp.id_sales_pos IN (" + id_sales_pos_par + ")
	            GROUP BY c.id_comp_group
            ) prd ON prd.id_comp_group = c.id_comp_group
            INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
            WHERE sp.id_sales_pos IN (" + id_sales_pos_par + ") "
            dt = execute_query(qdet, -1, True, "", "", "", "")
        ElseIf rmt = "226" Then
            Dim qdet As String = "SELECT '' AS `no`, sp.id_sales_pos AS `id_report`, sp.sales_pos_number AS `report_number`,
            CONCAT(c.comp_number, ' - ', c.comp_name) AS `store`, g.description AS `group_store`,
            cg.comp_name AS `group_company`, 
            CONCAT(DATE_FORMAT(sp.sales_pos_start_period,'%d-%m-%y'),' s/d ', DATE_FORMAT(sp.sales_pos_end_period,'%d-%m-%y')) AS `period`,
            DATE_FORMAT(sp.sales_pos_due_date,'%d-%m-%y') AS `sales_pos_due_date`,
            CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2))-IFNULL(pyd.`value`,0.00) AS `amount`,
            sp.report_mark_type
            FROM tb_sales_pos sp 
            INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
            INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
            INNER JOIN tb_m_comp_group g ON g.id_comp_group = c.id_comp_group
            INNER JOIN tb_m_comp cg ON cg.id_comp = g.id_comp
            INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
            LEFT JOIN (
                SELECT pyd.id_report, pyd.report_mark_type, 
                COUNT(IF(py.id_report_status!=5 AND py.id_report_status!=6,py.id_rec_payment,NULL)) AS `total_pending`,
                SUM(pyd.value) AS  `value`
                FROM tb_rec_payment_det pyd
                INNER JOIN tb_rec_payment py ON py.`id_rec_payment`=pyd.`id_rec_payment`
                WHERE py.`id_report_status`=6
                GROUP BY pyd.id_report, pyd.report_mark_type
            ) pyd ON pyd.id_report = sp.id_sales_pos AND pyd.report_mark_type = sp.report_mark_type
            WHERE sp.id_sales_pos IN (" + id_sales_pos_par + ") "
            dt = execute_query(qdet, -1, True, "", "", "", "")
        ElseIf rmt = "227" Then
            Dim id_comp_group As String = execute_query("SELECT mail_parameter FROM tb_mail_manage WHERE id_mail_manage='" + id + "' ", 0, True, "", "", "", "")
            Dim qdet As String = "SELECT '' AS `no`, sp.id_sales_pos AS `id_report`, sp.sales_pos_number AS `report_number`,
            CONCAT(c.comp_number, ' - ', c.comp_name) AS `store`, g.description AS `group_store`,
            cg.comp_name AS `group_company`, 
            CONCAT(DATE_FORMAT(sp.sales_pos_start_period,'%d-%m-%y'),' s/d ', DATE_FORMAT(sp.sales_pos_end_period,'%d-%m-%y')) AS `period`,
            DATE_FORMAT(sp.sales_pos_due_date,'%d-%m-%y') AS `sales_pos_due_date`,
            CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2))-IFNULL(pyd.`value`,0.00) AS `amount`,
            sp.report_mark_type
            FROM tb_sales_pos sp 
            INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
            INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
            INNER JOIN tb_m_comp_group g ON g.id_comp_group = c.id_comp_group
            INNER JOIN tb_m_comp cg ON cg.id_comp = g.id_comp
            INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
            LEFT JOIN (
                SELECT pyd.id_report, pyd.report_mark_type, 
                COUNT(IF(py.id_report_status!=5 AND py.id_report_status!=6,py.id_rec_payment,NULL)) AS `total_pending`,
                SUM(pyd.value) AS  `value`
                FROM tb_rec_payment_det pyd
                INNER JOIN tb_rec_payment py ON py.`id_rec_payment`=pyd.`id_rec_payment`
                WHERE py.`id_report_status`=6
                GROUP BY pyd.id_report, pyd.report_mark_type
            ) pyd ON pyd.id_report = sp.id_sales_pos AND pyd.report_mark_type = sp.report_mark_type
            WHERE sp.id_sales_pos IN (" + id_sales_pos_par + ") AND c.id_comp_group='" + id_comp_group + "' "
            dt = execute_query(qdet, -1, True, "", "", "", "")
        End If
        Return dt
    End Function

    Sub columnDetail()
        If rmt = "225" Then
            'hide column
            GVDetail.Columns("id_report").Visible = False
            GVDetail.Columns("period").Visible = False
            GVDetail.Columns("total_amount").Visible = False
            GVDetail.Columns("total_qty").Visible = False
            GVDetail.Columns("report_mark_type").Visible = False
            'caption
            GVDetail.Columns("no").Caption = "No"
            GVDetail.Columns("report_number").Caption = "Invoice Number"
            GVDetail.Columns("store").Caption = "Store"
            GVDetail.Columns("group_store").Caption = "Store Group"
            GVDetail.Columns("group_company").Caption = "Company"
            GVDetail.Columns("qty_invoice").Caption = "Qty"
            GVDetail.Columns("amount").Caption = "Amount"
            'display format
            GVDetail.Columns("qty_invoice").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVDetail.Columns("qty_invoice").DisplayFormat.FormatString = "{0:N0}"
            GVDetail.Columns("amount").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVDetail.Columns("amount").DisplayFormat.FormatString = "{0:N2}"
            'summary
            GVDetail.Columns("qty_invoice").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVDetail.Columns("qty_invoice").SummaryItem.DisplayFormat = "{0:n0}"
            GVDetail.Columns("amount").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVDetail.Columns("amount").SummaryItem.DisplayFormat = "{0:n2}"
            'bestfit
            GVDetail.BestFitColumns()
        ElseIf rmt = "226" Or rmt = "227" Then
            'hide column
            GVDetail.Columns("id_report").Visible = False
            GVDetail.Columns("report_mark_type").Visible = False
            'caption
            GVDetail.Columns("no").Caption = "No"
            GVDetail.Columns("report_number").Caption = "Invoice Number"
            GVDetail.Columns("store").Caption = "Store"
            GVDetail.Columns("group_store").Caption = "Store Group"
            GVDetail.Columns("group_company").Caption = "Company"
            GVDetail.Columns("period").Caption = "Period"
            GVDetail.Columns("sales_pos_due_date").Caption = "Due Date"
            GVDetail.Columns("amount").Caption = "Amount"
            'display format
            GVDetail.Columns("amount").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVDetail.Columns("amount").DisplayFormat.FormatString = "{0:N2}"
            'summary
            GVDetail.Columns("amount").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVDetail.Columns("amount").SummaryItem.DisplayFormat = "{0:n2}"
            'bestfit
            GVDetail.BestFitColumns()
        End If
    End Sub

    Function getSavedInvoice() As String
        Dim qinv As String = "SELECT d.id_report FROM tb_mail_manage_det d WHERE d.id_mail_manage=" + id + " "
        Dim dinv As DataTable = execute_query(qinv, -1, True, "", "", "", "")
        Dim id_sales_pos As String = ""
        For i As Integer = 0 To dinv.Rows.Count - 1
            If i > 0 Then
                id_sales_pos += ","
            End If
            id_sales_pos += dinv.Rows(i)("id_report").ToString
        Next
        Return id_sales_pos
    End Function

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        If action = "ins" Then
            TxtEmailNumber.Text = "[auto_generated]"
            TxtMailStatus.Text = "Pending"

            If rmt = "225" Then 'INVOICE PWNJUALAN
                '-- mail type
                TxtMailType.Text = execute_query("SELECT report_mark_type_name FROM tb_lookup_report_mark_type WHERE report_mark_type='225'", 0, True, "", "", "", "")

                '--- load member
                Dim qf As String = "SELECT m.id_mail_manage_mapping_intern AS `index`,0 AS `id_mail_manage_member`,0 AS `id_mail_manage`,m.id_mail_member_type, mmt.mail_member_type,m.id_user,0 AS `id_comp_contact`, 
                e.employee_name AS `description`,e.email_external AS `mail_address` 
                FROM tb_mail_manage_mapping_intern m
                INNER JOIN tb_lookup_mail_member_type mmt ON mmt.id_mail_member_type = m.id_mail_member_type
                INNER JOIN tb_m_user u ON u.id_user = m.id_user
                INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
                WHERE e.email_external!='' AND m.report_mark_type='" + rmt + "' AND (ISNULL(m.id_comp_group) OR m.id_comp_group='" + FormMailManage.SLEStoreGroup.EditValue.ToString + "')
                UNION
                SELECT m.id_mail_manage_mapping AS `index`,0 AS `id_mail_manage_member`,0 AS `id_mail_manage`,m.id_mail_member_type, mmt.mail_member_type, 0 AS `id_user`, m.id_comp_contact,
                cc.contact_person AS `description`, cc.email AS `mail_address`
                FROM tb_mail_manage_mapping m
                INNER JOIN tb_lookup_mail_member_type mmt ON mmt.id_mail_member_type = m.id_mail_member_type
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = m.id_comp_contact
                WHERE m.id_comp_group='" + FormMailManage.SLEStoreGroup.EditValue.ToString + "' AND cc.id_comp='" + FormMailManage.SLEStoreCompany.EditValue.ToString + "' AND cc.email!='' AND m.report_mark_type='" + rmt + "'
                ORDER BY id_mail_member_type ASC, `index` ASC "
                Dim df As DataTable = execute_query(qf, -1, True, "", "", "", "")
                GCMember.DataSource = df
                GVMember.BestFitColumns()

                '--- load data
                Dim id_sales_pos As String = ""
                For i As Integer = 0 To (FormMailManage.GVInvoiceList.RowCount - 1)
                    If i > 0 Then
                        id_sales_pos += ","
                    End If
                    id_sales_pos += FormMailManage.GVInvoiceList.GetRowCellValue(i, "id_sales_pos").ToString
                Next
                Dim ddet As DataTable = dtLoadDetail(id_sales_pos)
                GCDetail.DataSource = ddet
                columnDetail()


                '-- load 'from/to/cc & html preview
                GVMember.ActiveFilterString = ""
                For j As Integer = 0 To ((GVMember.RowCount - 1) - GetGroupRowCount(GVMember))
                    Dim id_mail_member_type As String = GVMember.GetRowCellValue(j, "id_mail_member_type").ToString
                    Dim mail_address As String = GVMember.GetRowCellValue(j, "mail_address").ToString

                    If id_mail_member_type = "1" Then
                        MEFrom.Text += mail_address + "; "
                    ElseIf id_mail_member_type = "2" Then
                        METo.Text += mail_address + "; "
                    Else
                        MECC.Text += mail_address + "; "
                    End If
                Next

                'load var
                Dim qopt As String = "SELECT mail_head_invoice,mail_subject_invoice, mail_title_invoice , mail_content_head_invoice, mail_content_invoice ,mail_content_end_invoice
                FROM tb_opt "
                Dim dopt As DataTable = execute_query(qopt, -1, True, "", "", "", "")
                mail_head = dopt.Rows(0)("mail_head_invoice").ToString
                mail_subject = dopt.Rows(0)("mail_subject_invoice").ToString + ddet.Rows(0)("period_header").ToString + " - " + ddet.Rows(0)("group_store").ToString
                mail_title = dopt.Rows(0)("mail_title_invoice").ToString
                mail_content_head = dopt.Rows(0)("mail_content_head_invoice").ToString
                mail_content = dopt.Rows(0)("mail_content_invoice").ToString
                mail_content_end = dopt.Rows(0)("mail_content_end_invoice").ToString
                MESubject.Text = addSlashes(mail_subject)

                'mail template
                Dim m As New ClassSendEmail()
                Dim html As String = m.email_body_invoice_penjualan(ddet, mail_title, mail_content_head + ddet.Rows(0)("group_company").ToString, mail_content, mail_content_end, Double.Parse(getTotalAmo(ddet).ToString).ToString("N2"))
                WebBrowser1.DocumentText = html
            ElseIf rmt = "226" Or rmt = "227" Then
                '-- mail type
                TxtMailType.Text = execute_query("SELECT report_mark_type_name FROM tb_lookup_report_mark_type WHERE report_mark_type='" + rmt + "'", 0, True, "", "", "", "")

                '--- load member
                Dim qf As String = "SELECT m.id_mail_manage_mapping_intern AS `index`,0 AS `id_mail_manage_member`,0 AS `id_mail_manage`,m.id_mail_member_type, mmt.mail_member_type,m.id_user,0 AS `id_comp_contact`, 
                e.employee_name AS `description`,e.email_external AS `mail_address` 
                FROM tb_mail_manage_mapping_intern m
                INNER JOIN tb_lookup_mail_member_type mmt ON mmt.id_mail_member_type = m.id_mail_member_type
                INNER JOIN tb_m_user u ON u.id_user = m.id_user
                INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
                WHERE e.email_external!='' AND m.report_mark_type='" + rmt + "'
                UNION
                SELECT m.id_mail_manage_mapping AS `index`,0 AS `id_mail_manage_member`,0 AS `id_mail_manage`,m.id_mail_member_type, mmt.mail_member_type, 0 AS `id_user`, m.id_comp_contact,
                cc.contact_person AS `description`, cc.email AS `mail_address`
                FROM tb_mail_manage_mapping m
                INNER JOIN tb_lookup_mail_member_type mmt ON mmt.id_mail_member_type = m.id_mail_member_type
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = m.id_comp_contact
                WHERE m.id_comp_group='" + FormMailManage.SLEStoreGroupUnpaid.EditValue.ToString + "' AND cc.email!='' AND m.report_mark_type='" + rmt + "'
                ORDER BY id_mail_member_type ASC, `index` ASC "
                Dim df As DataTable = execute_query(qf, -1, True, "", "", "", "")
                GCMember.DataSource = df
                GVMember.BestFitColumns()

                '--- load data
                Dim id_sales_pos As String = ""
                For i As Integer = 0 To (FormMailManage.GVUnpaid.RowCount - 1)
                    If i > 0 Then
                        id_sales_pos += ","
                    End If
                    id_sales_pos += FormMailManage.GVUnpaid.GetRowCellValue(i, "id_sales_pos").ToString
                Next
                Console.WriteLine(id_sales_pos)
                Dim ddet As DataTable = dtLoadDetail(id_sales_pos)
                GCDetail.DataSource = ddet
                columnDetail()


                '-- load 'from/to/cc & html preview
                GVMember.ActiveFilterString = ""
                For j As Integer = 0 To ((GVMember.RowCount - 1) - GetGroupRowCount(GVMember))
                    Dim id_mail_member_type As String = GVMember.GetRowCellValue(j, "id_mail_member_type").ToString
                    Dim mail_address As String = GVMember.GetRowCellValue(j, "mail_address").ToString

                    If id_mail_member_type = "1" Then
                        MEFrom.Text += mail_address + "; "
                    ElseIf id_mail_member_type = "2" Then
                        METo.Text += mail_address + "; "
                    Else
                        MECC.Text += mail_address + "; "
                    End If
                Next
                Dim qopt As String = "SELECT 
                mail_head_pemberitahuan,mail_subject_pemberitahuan, mail_title_pemberitahuan , mail_content_head_pemberitahuan, mail_content_pemberitahuan, mail_content_end_pemberitahuan,
                mail_head_peringatan,mail_subject_peringatan, mail_title_peringatan , mail_content_head_peringatan, mail_content_peringatan ,mail_content_end_peringatan
                FROM tb_opt "
                Dim dopt As DataTable = execute_query(qopt, -1, True, "", "", "", "")
                If rmt = "226" Then
                    mail_head = dopt.Rows(0)("mail_head_pemberitahuan").ToString
                    mail_subject = dopt.Rows(0)("mail_subject_pemberitahuan").ToString
                    mail_title = dopt.Rows(0)("mail_title_pemberitahuan").ToString
                    mail_content_head = dopt.Rows(0)("mail_content_head_pemberitahuan").ToString
                    mail_content = dopt.Rows(0)("mail_content_pemberitahuan").ToString
                    mail_content_end = dopt.Rows(0)("mail_content_end_pemberitahuan").ToString
                ElseIf rmt = "227" Then
                    mail_head = dopt.Rows(0)("mail_head_peringatan").ToString
                    mail_subject = dopt.Rows(0)("mail_subject_peringatan").ToString
                    mail_title = dopt.Rows(0)("mail_title_peringatan").ToString
                    mail_content_head = dopt.Rows(0)("mail_content_head_peringatan").ToString
                    mail_content = dopt.Rows(0)("mail_content_peringatan").ToString
                    mail_content_end = dopt.Rows(0)("mail_content_end_peringatan").ToString
                End If


                MESubject.Text = addSlashes(mail_subject)
                Dim m As New ClassSendEmail()
                Dim html As String = m.email_body_invoice_jatuh_tempo(ddet, mail_title, mail_content_head + ddet.Rows(0)("group_company").ToString, mail_content, mail_content_end, Double.Parse(getTotalAmo(ddet).ToString).ToString("N2"))
                WebBrowser1.DocumentText = html
            End If
        ElseIf action = "upd" Then
            '-- main view
            Dim mm As New ClassMailManage()
            mm.id_mail_manage = id
            mm.rmt = rmt
            Dim query As String = mm.queryMain("AND m.id_mail_manage='" + id + "' ", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtEmailNumber.Text = data.Rows(0)("number").ToString
            TxtMailType.Text = data.Rows(0)("report_mark_type_name").ToString
            id_mail_status = data.Rows(0)("id_mail_status").ToString
            TxtMailStatus.Text = data.Rows(0)("mail_status").ToString
            MENote.Text = data.Rows(0)("mail_status_note").ToString
            DECreatedDate.EditValue = data.Rows(0)("created_date")
            TxtCreatedBy.Text = data.Rows(0)("created_by_name").ToString
            DEUpdatedDate.EditValue = data.Rows(0)("updated_date")
            TxtUpdatedBy.Text = data.Rows(0)("updated_by_name").ToString
            MESubject.Text = data.Rows(0)("mail_subject").ToString

            If rmt = "225" Then 'INVOICE PWNJUALAN
                '-- load member
                Dim qf As String = "SELECT m.id_mail_manage_member AS `index`,m.`id_mail_manage_member`,m.`id_mail_manage`,m.id_mail_member_type, mmt.mail_member_type,m.id_user, 0 AS `id_comp_contact`, 
                e.employee_name AS `description`, m.mail_address AS `mail_address` 
                FROM tb_mail_manage_member m
                INNER JOIN tb_lookup_mail_member_type mmt ON mmt.id_mail_member_type = m.id_mail_member_type
                INNER JOIN tb_m_user u ON u.id_user = m.id_user
                INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
                WHERE m.id_mail_manage=" + id + " AND ISNULL(m.id_comp_contact)
                UNION
                SELECT m.id_mail_manage_member AS `index`,m.`id_mail_manage_member`,m.`id_mail_manage`,m.id_mail_member_type, mmt.mail_member_type, 0 AS `id_user`, m.id_comp_contact,
                cc.contact_person AS `description`, cc.email AS `mail_address`
                FROM tb_mail_manage_member m
                INNER JOIN tb_lookup_mail_member_type mmt ON mmt.id_mail_member_type = m.id_mail_member_type
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = m.id_comp_contact
                WHERE m.id_mail_manage=" + id + " AND ISNULL(m.id_user)
                ORDER BY id_mail_member_type ASC, `index` ASC "
                Dim df As DataTable = execute_query(qf, -1, True, "", "", "", "")
                GCMember.DataSource = df
                GVMember.BestFitColumns()

                '--- load data
                Dim id_sales_pos As String = getSavedInvoice()
                Dim ddet As DataTable = dtLoadDetail(id_sales_pos)
                GCDetail.DataSource = ddet
                columnDetail()

                '-- load 'from/to/cc & html preview
                GVMember.ActiveFilterString = ""
                MEFrom.Text = ""
                METo.Text = ""
                MECC.Text = ""
                For j As Integer = 0 To ((GVMember.RowCount - 1) - GetGroupRowCount(GVMember))
                    Dim id_mail_member_type As String = GVMember.GetRowCellValue(j, "id_mail_member_type").ToString
                    Dim mail_address As String = GVMember.GetRowCellValue(j, "mail_address").ToString

                    If id_mail_member_type = "1" Then
                        MEFrom.Text += mail_address + "; "
                    ElseIf id_mail_member_type = "2" Then
                        METo.Text += mail_address + "; "
                    Else
                        MECC.Text += mail_address + "; "
                    End If
                Next

                'load var
                Dim qopt As String = "SELECT mail_head_invoice,mail_subject_invoice, mail_title_invoice , mail_content_head_invoice, mail_content_invoice ,mail_content_end_invoice
                FROM tb_opt "
                Dim dopt As DataTable = execute_query(qopt, -1, True, "", "", "", "")
                mail_head = dopt.Rows(0)("mail_head_invoice").ToString
                mail_subject = dopt.Rows(0)("mail_subject_invoice").ToString + ddet.Rows(0)("period_header").ToString + " - " + ddet.Rows(0)("group_store").ToString
                mail_title = dopt.Rows(0)("mail_title_invoice").ToString
                mail_content_head = dopt.Rows(0)("mail_content_head_invoice").ToString
                mail_content = dopt.Rows(0)("mail_content_invoice").ToString
                mail_content_end = dopt.Rows(0)("mail_content_end_invoice").ToString
                MESubject.Text = addSlashes(mail_subject)

                'mail template
                Dim m As New ClassSendEmail()
                Dim html As String = m.email_body_invoice_penjualan(ddet, mail_title, mail_content_head + ddet.Rows(0)("group_company").ToString, mail_content, mail_content_end, Double.Parse(getTotalAmo(ddet).ToString).ToString("N2"))
                WebBrowser1.DocumentText = html
            ElseIf rmt = "226" Or rmt = "227" Then
                '-- load member
                Dim qf As String = "SELECT m.id_mail_manage_member AS `index`,m.`id_mail_manage_member`,m.`id_mail_manage`,m.id_mail_member_type, mmt.mail_member_type,m.id_user, 0 AS `id_comp_contact`, 
                e.employee_name AS `description`, m.mail_address AS `mail_address` 
                FROM tb_mail_manage_member m
                INNER JOIN tb_lookup_mail_member_type mmt ON mmt.id_mail_member_type = m.id_mail_member_type
                INNER JOIN tb_m_user u ON u.id_user = m.id_user
                INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
                WHERE m.id_mail_manage=" + id + " AND ISNULL(m.id_comp_contact)
                UNION
                SELECT m.id_mail_manage_member AS `index`,m.`id_mail_manage_member`,m.`id_mail_manage`,m.id_mail_member_type, mmt.mail_member_type, 0 AS `id_user`, m.id_comp_contact,
                cc.contact_person AS `description`, cc.email AS `mail_address`
                FROM tb_mail_manage_member m
                INNER JOIN tb_lookup_mail_member_type mmt ON mmt.id_mail_member_type = m.id_mail_member_type
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = m.id_comp_contact
                WHERE m.id_mail_manage=" + id + " AND ISNULL(m.id_user)
                ORDER BY id_mail_member_type ASC, `index` ASC "
                Dim df As DataTable = execute_query(qf, -1, True, "", "", "", "")
                GCMember.DataSource = df
                GVMember.BestFitColumns()

                '--- load data
                Dim id_sales_pos As String = getSavedInvoice()
                Dim ddet As DataTable = dtLoadDetail(id_sales_pos)
                GCDetail.DataSource = ddet
                columnDetail()

                '-- load 'from/to/cc & html preview
                GVMember.ActiveFilterString = ""
                For j As Integer = 0 To ((GVMember.RowCount - 1) - GetGroupRowCount(GVMember))
                    Dim id_mail_member_type As String = GVMember.GetRowCellValue(j, "id_mail_member_type").ToString
                    Dim mail_address As String = GVMember.GetRowCellValue(j, "mail_address").ToString

                    If id_mail_member_type = "1" Then
                        MEFrom.Text += mail_address + "; "
                    ElseIf id_mail_member_type = "2" Then
                        METo.Text += mail_address + "; "
                    Else
                        MECC.Text += mail_address + "; "
                    End If
                Next
                Dim qopt As String = "SELECT 
                mail_head_pemberitahuan,mail_subject_pemberitahuan, mail_title_pemberitahuan , mail_content_head_pemberitahuan, mail_content_pemberitahuan, mail_content_end_pemberitahuan,
                mail_head_peringatan,mail_subject_peringatan, mail_title_peringatan , mail_content_head_peringatan, mail_content_peringatan ,mail_content_end_peringatan
                FROM tb_opt "
                Dim dopt As DataTable = execute_query(qopt, -1, True, "", "", "", "")
                If rmt = "226" Then
                    mail_head = dopt.Rows(0)("mail_head_pemberitahuan").ToString
                    mail_subject = dopt.Rows(0)("mail_subject_pemberitahuan").ToString
                    mail_title = dopt.Rows(0)("mail_title_pemberitahuan").ToString
                    mail_content_head = dopt.Rows(0)("mail_content_head_pemberitahuan").ToString
                    mail_content = dopt.Rows(0)("mail_content_pemberitahuan").ToString
                    mail_content_end = dopt.Rows(0)("mail_content_end_pemberitahuan").ToString
                ElseIf rmt = "227" Then
                    mail_head = dopt.Rows(0)("mail_head_peringatan").ToString
                    mail_subject = dopt.Rows(0)("mail_subject_peringatan").ToString
                    mail_title = dopt.Rows(0)("mail_title_peringatan").ToString
                    mail_content_head = dopt.Rows(0)("mail_content_head_peringatan").ToString
                    mail_content = dopt.Rows(0)("mail_content_peringatan").ToString
                    mail_content_end = dopt.Rows(0)("mail_content_end_peringatan").ToString
                    'MESubject.Text = addSlashes(mail_subject)
                End If
                Dim m As New ClassSendEmail()
                Dim html As String = m.email_body_invoice_jatuh_tempo(ddet, mail_title, mail_content_head + ddet.Rows(0)("group_company").ToString, mail_content, mail_content_end, Double.Parse(getTotalAmo(ddet).ToString).ToString("N2"))
                WebBrowser1.DocumentText = html
            ElseIf rmt = "228" Or rmt = "230" Then
                '-- load member
                Dim qf As String = "SELECT m.id_mail_manage_member AS `index`,m.`id_mail_manage_member`,m.`id_mail_manage`,m.id_mail_member_type, mmt.mail_member_type,m.id_user, 0 AS `id_comp_contact`, 
                e.employee_name AS `description`, m.mail_address AS `mail_address` 
                FROM tb_mail_manage_member m
                INNER JOIN tb_lookup_mail_member_type mmt ON mmt.id_mail_member_type = m.id_mail_member_type
                INNER JOIN tb_m_user u ON u.id_user = m.id_user
                INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
                WHERE m.id_mail_manage=" + id + " AND ISNULL(m.id_comp_contact)
                UNION
                SELECT m.id_mail_manage_member AS `index`,m.`id_mail_manage_member`,m.`id_mail_manage`,m.id_mail_member_type, mmt.mail_member_type, 0 AS `id_user`, m.id_comp_contact,
                cc.contact_person AS `description`, cc.email AS `mail_address`
                FROM tb_mail_manage_member m
                INNER JOIN tb_lookup_mail_member_type mmt ON mmt.id_mail_member_type = m.id_mail_member_type
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = m.id_comp_contact
                WHERE m.id_mail_manage=" + id + " AND ISNULL(m.id_user)
                ORDER BY id_mail_member_type ASC, `index` ASC "
                Dim df As DataTable = execute_query(qf, -1, True, "", "", "", "")
                GCMember.DataSource = df
                GVMember.BestFitColumns()

                '--- load data
                Dim ddet As DataTable = mm.getDetailData()
                GCDetail.DataSource = ddet
                columnDetail()

                '-- load 'from/to/cc & html preview
                GVMember.ActiveFilterString = ""
                For j As Integer = 0 To ((GVMember.RowCount - 1) - GetGroupRowCount(GVMember))
                    Dim id_mail_member_type As String = GVMember.GetRowCellValue(j, "id_mail_member_type").ToString
                    Dim mail_address As String = GVMember.GetRowCellValue(j, "mail_address").ToString

                    If id_mail_member_type = "1" Then
                        MEFrom.Text += mail_address + "; "
                    ElseIf id_mail_member_type = "2" Then
                        METo.Text += mail_address + "; "
                    Else
                        MECC.Text += mail_address + "; "
                    End If
                Next

                Dim query_opt_det As String = "SELECT 
                CONCAT(e.employee_name, ' (',e.employee_position,')') AS `to_content_mail`,
                o.mail_subject_release_del, o.mail_title_release_del, o.mail_content_release_del,
                o.mail_subject_on_hold, o.mail_title_on_hold, o.mail_content_on_hold
                FROM tb_opt o
                INNER JOIN tb_m_employee e ON e.id_employee = o.id_emp_wh_manager "
                Dim data_opt_det As DataTable = execute_query(query_opt_det, -1, True, "", "", "", "")
                mail_content_to = data_opt_det.Rows(0)("to_content_mail").ToString
                If rmt = "228" Then
                    mail_subject = data_opt_det.Rows(0)("mail_subject_on_hold").ToString
                    mail_title = data_opt_det.Rows(0)("mail_title_on_hold").ToString
                    mail_content = data_opt_det.Rows(0)("mail_content_on_hold").ToString
                    Dim m As New ClassSendEmail()
                    Dim html As String = m.emailOnHold(mail_content_to, mail_content, ddet)
                    WebBrowser1.DocumentText = html
                ElseIf rmt = "230" Then
                    mail_subject = data_opt_det.Rows(0)("mail_subject_release_del").ToString
                    mail_title = data_opt_det.Rows(0)("mail_title_release_del").ToString
                    mail_content = data_opt_det.Rows(0)("mail_content_release_del").ToString
                    Dim m As New ClassSendEmail()
                    Dim html As String = m.emailReleaseDel(mail_content_to, mail_content, ddet)
                    WebBrowser1.DocumentText = html
                End If
            End If

            '-- muncul dialog jika eror send
            If id_mail_status = "3" And Not checkAlreadySent() Then
                stopCustom("Last log show this email is 'FAILED' to send. Click 'RESEND' to try again.")
            End If

            '-- permision
            'general btn
            BtnLog.Visible = True

            'jika draft dan fail
            If id_mail_status = "1" Or id_mail_status = "3" Then
                BtnDraft.Visible = True
                BtnCancel.Visible = True
            Else
                BtnDraft.Visible = False
                BtnCancel.Visible = False
            End If

            'jika cancel
            If id_mail_status = "4" Then
                BtnSend.Visible = False
            End If

            'cek di log jika sudah pernah sent
            If checkAlreadySent() Then
                BtnDraft.Visible = False
                BtnCancel.Visible = False
                BtnSend.Text = "Resend"
            End If

            'jika sent tapi bukan super user
            If id_mail_status = "2" And id_role_login <> super_user Then
                BtnSend.Visible = False
            End If
        End If

        'include mail management
        Dim management_mail As String = getMailManagement(rmt)
        If management_mail <> "" Then
            MECC.Text += management_mail + ";"
        End If
        Cursor = Cursors.Default
    End Sub

    Function checkAlreadySent() As Boolean
        Dim qsl As String = "SELECT * FROM tb_mail_manage_log l WHERE l.id_mail_manage=" + id + " AND l.id_mail_status=2 "
        Dim dsl As DataTable = execute_query(qsl, -1, True, "", "", "", "")
        If dsl.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub GVDetail_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnSend_Click(sender As Object, e As EventArgs) Handles BtnSend.Click
        Cursor = Cursors.WaitCursor
        'ada konfirmasi
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to send this email ? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            save("2", "")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDraft_Click(sender As Object, e As EventArgs) Handles BtnDraft.Click
        Cursor = Cursors.WaitCursor
        save("1", "")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        If checkAlreadySent() Then
            stopCustom("Can't cancel this transaction because email already sent")
        Else
            FormMailManageCancel.rmt = rmt
            FormMailManageCancel.id_mail_manage = id
            FormMailManageCancel.ShowDialog()
            actionLoad()
            refreshMainView()
            If id_mail_status = "4" Then
                Close()
            End If
        End If
    End Sub

    Sub refreshMainView()
        FormMailManage.XTCMailManage.SelectedTabPageIndex = 0
        FormMailManage.viewMailManage()
        makeSafeGV(FormMailManage.GVData)
        FormMailManage.GVData.FocusedRowHandle = find_row(FormMailManage.GVData, "id_mail_manage", id)
        If rmt = "225" Then
            FormMailManage.SLEStoreGroup.EditValue = "0"
        ElseIf rmt = "226" Or rmt = "227" Then
            FormMailManage.SLEStoreGroupUnpaid.EditValue = "0"
        End If
    End Sub

    Sub save(ByVal id_status_par As String, ByVal note_par As String)
        Cursor = Cursors.WaitCursor
        GVMember.ActiveFilterString = ""
        GVDetail.ActiveFilterString = ""
        Dim mail_subject As String = addSlashes(MESubject.Text)
        If action = "ins" Then
            'insert head
            Dim query As String = "INSERT INTO tb_mail_manage(number, created_date, created_by, updated_date, updated_by, report_mark_type, id_mail_status, mail_status_note, mail_subject) VALUES
            ('', NOW(), '" + id_user + "', NOW(), '" + id_user + "', '" + rmt + "', '1', '" + note_par + "', '" + mail_subject + "'); SELECT LAST_INSERT_ID(); "
            id = execute_query(query, 0, True, "", "", "", "")
            execute_non_query("CALL gen_number(" + id + ", " + rmt + ")", True, "", "", "", "")

            'insert member
            If GVMember.RowCount > 0 Then
                Dim query_member As String = "INSERT INTO tb_mail_manage_member(id_mail_manage, id_mail_member_type, id_user, id_comp_contact, mail_address) VALUES "
                For i As Integer = 0 To ((GVMember.RowCount - 1) - (GetGroupRowCount(GVMember)))
                    Dim id_mail_member_type As String = GVMember.GetRowCellValue(i, "id_mail_member_type").ToString
                    Dim id_userx As String = GVMember.GetRowCellValue(i, "id_user").ToString
                    If id_userx = "0" Then
                        id_userx = "NULL"
                    End If
                    Dim id_comp_contact As String = GVMember.GetRowCellValue(i, "id_comp_contact").ToString
                    If id_comp_contact = "0" Then
                        id_comp_contact = "NULL"
                    End If
                    Dim mail_address As String = addSlashes(GVMember.GetRowCellValue(i, "mail_address").ToString)

                    If i > 0 Then
                        query_member += ", "
                    End If
                    query_member += "('" + id + "', '" + id_mail_member_type + "', " + id_userx + ", " + id_comp_contact + ", '" + mail_address + "') "
                Next
                execute_non_query(query_member, True, "", "", "", "")
            End If

            'insert detil
            If GVDetail.RowCount > 0 Then
                Dim query_detail As String = "INSERT INTO tb_mail_manage_det(id_mail_manage, report_mark_type, id_report, report_number) VALUES "
                For j As Integer = 0 To ((GVDetail.RowCount - 1) - (GetGroupRowCount(GVDetail)))
                    Dim report_mark_type As String = GVDetail.GetRowCellValue(j, "report_mark_type").ToString
                    Dim id_report As String = GVDetail.GetRowCellValue(j, "id_report").ToString
                    Dim report_number As String = GVDetail.GetRowCellValue(j, "report_number").ToString

                    If j > 0 Then
                        query_detail += ","
                    End If
                    query_detail += "('" + id + "', '" + report_mark_type + "', '" + id_report + "', '" + report_number + "') "
                Next
                execute_non_query(query_detail, True, "", "", "", "")
            End If

            'other action
            If rmt = "225" Then
                updateSttInvoice("2")
            End If

            'send email
            If id_status_par = "2" Then 'send
                sendEmail()
            ElseIf id_status_par = "1" Then 'draft
                Dim querylog As String = "UPDATE tb_mail_manage SET updated_date=NOW(), updated_by='" + id_user + "', 
                id_mail_status=1, mail_status_note='Draft Email' WHERE id_mail_manage='" + id + "'; " + queryInsertLog("1", "Draft Email") + "; "
                execute_non_query(querylog, True, "", "", "", "")
            End If

            'actionLoad & refresh
            action = "upd"
            actionLoad()
            refreshMainView()

            'jika tidak gagal langsung close
            If id_mail_status <> "3" Then
                Close()
            End If
        Else
            'send email
            If id_status_par = "2" Then 'send
                sendEmail()
            ElseIf id_status_par = "1" Then 'draft
                Dim querylog As String = "UPDATE tb_mail_manage SET updated_date=NOW(), updated_by='" + id_user + "', 
                id_mail_status=1, mail_status_note='Draft Email' WHERE id_mail_manage='" + id + "'; " + queryInsertLog("1", "Draft Email") + "; "
                execute_non_query(querylog, True, "", "", "", "")
            End If

            'actionLoad & refresh
            action = "upd"
            actionLoad()
            refreshMainView()

            'jika tidak gagal langsung close
            If id_mail_status <> "3" Then
                Close()
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Function getTotalAmo(ByVal dtx As DataTable) As Double
        Dim tot_amo As Double = 0
        If rmt = "225" Or rmt = "226" Or rmt = "227" Then
            For i As Integer = 0 To dtx.Rows.Count - 1
                tot_amo += dtx.Rows(i)("amount")
            Next
        End If
        Return tot_amo
    End Function

    Sub sendEmail()
        'send mail
        Dim sm As New ClassSendEmail()
        sm.id_report = id
        sm.report_mark_type = rmt


        'jika ada parameter lain
        If rmt = "225" Then
            Dim id_sales_pos As String = getSavedInvoice()
            Dim dtx As DataTable = dtLoadDetail(id_sales_pos)
            sm.dt = dtx
            sm.head = mail_head
            sm.subj = addSlashes(MESubject.Text)
            sm.titl = mail_title
            sm.par1 = mail_content_head + " " + dtx.Rows(0)("group_company").ToString
            sm.par2 = mail_content
            sm.comment = mail_content_end
            sm.design_code = Double.Parse(getTotalAmo(dtx).ToString).ToString("N2")
        ElseIf rmt = "226" Or rmt = "227" Then
            Dim id_sales_pos As String = getSavedInvoice()
            Dim dtx As DataTable = dtLoadDetail(id_sales_pos)
            sm.dt = dtx
            sm.head = mail_head
            sm.subj = addSlashes(MESubject.Text)
            sm.titl = mail_title
            sm.par1 = mail_content_head + " " + dtx.Rows(0)("group_company").ToString
            sm.par2 = mail_content
            sm.comment = mail_content_end
            sm.design_code = Double.Parse(getTotalAmo(dtx).ToString).ToString("N2")
        ElseIf rmt = "228" Or rmt = "230" Then
            Dim mm As New ClassMailManage
            mm.id_mail_manage = id
            mm.rmt = rmt
            sm.design_code = mail_title
            sm.design = mail_subject
            sm.comment_by = mail_content_to
            sm.comment = mail_content
            sm.dt = mm.getDetailData
        End If

        Try
            sm.send_email()
            Dim querylog As String = "UPDATE tb_mail_manage SET updated_date=NOW(), updated_by='" + id_user + "', 
            id_mail_status=2, mail_status_note='Sent successfully' WHERE id_mail_manage='" + id + "'; " + queryInsertLog("2", "Sent successfully") + "; "
            execute_non_query(querylog, True, "", "", "", "")

            'insert log
            Dim cml As New ClassMailManage()
            cml.id_mail_manage = id
            cml.rmt = rmt
            cml.insertLogFollowUp("")
        Catch ex As Exception
            Dim query As String = "UPDATE tb_mail_manage SET updated_date=NOW(), updated_by='" + id_user + "', 
            id_mail_status=3, mail_status_note='" + addSlashes(ex.ToString) + "' WHERE id_mail_manage='" + id + "';" + queryInsertLog("3", ex.ToString) + "; "
            execute_non_query(query, True, "", "", "", "")
        End Try
    End Sub

    Function queryInsertLog(ByVal id_status_par As String, ByVal note_par As String) As String
        Dim query As String = "INSERT INTO tb_mail_manage_log(id_mail_manage, log_date, id_user, id_mail_status, note) VALUES 
        ('" + id + "', NOW(),'" + id_user + "', '" + id_status_par + "', '" + addSlashes(note_par) + "') "
        Return query
    End Function

    Sub updateSttInvoice(ByVal is_pending_mail_par As String)
        'update detil invoice
        Dim query As String = "UPDATE tb_sales_pos main 
        INNER JOIN (
	        SELECT md.report_mark_type,md.id_report 
	        FROM tb_mail_manage_det md
	        WHERE md.id_mail_manage=" + id + "
        ) src ON src.report_mark_type = main.report_mark_type AND src.id_report = main.id_sales_pos
        SET main.is_pending_mail=" + is_pending_mail_par + " "
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnAttach.Click
        Cursor = Cursors.WaitCursor
        If rmt = "225" Then
            Dim list As List(Of DevExpress.XtraPrinting.Page) = New List(Of DevExpress.XtraPrinting.Page)
            Dim rpt As New ReportSalesInvoiceNew()
            GVDetail.ActiveFilterString = ""
            For i As Integer = 0 To GVDetail.RowCount - 1
                ReportSalesInvoiceNew.id_sales_pos = GVDetail.GetRowCellValue(i, "id_report").ToString
                ReportSalesInvoiceNew.id_report_status = "6"
                ReportSalesInvoiceNew.rmt = GVDetail.GetRowCellValue(i, "report_mark_type").ToString
                Dim Report As New ReportSalesInvoiceNew()
                Report.LabelTitle.Text = "INVOICE SLIP"
                Report.PrintingSystem.ContinuousPageNumbering = False
                Report.CreateDocument()

                For j = 0 To Report.Pages.Count - 1
                    list.Add(Report.Pages(j))
                Next
            Next
            rpt.Pages.AddRange(list)
            Dim tool_detail As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(rpt)
            tool_detail.ShowPreview()
        ElseIf rmt = "226" Or rmt = "227" Then
            Dim id_sales_pos As String = ""
            For i As Integer = 0 To (GVDetail.RowCount - 1)
                If i > 0 Then
                    id_sales_pos += ","
                End If
                id_sales_pos += GVDetail.GetRowCellValue(i, "id_report").ToString
            Next
            ReportSummaryInvoice.id = id_sales_pos
            Dim rpt As New ReportSummaryInvoice()
            Dim tool_detail As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(rpt)
            tool_detail.ShowPreview()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Cursor = Cursors.WaitCursor
        FormMailManageLog.id = id
        FormMailManageLog.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class