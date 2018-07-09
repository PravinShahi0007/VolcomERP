Public Class FormEmpUniExpenseDet
    Public id_emp_uni_ex As String = "-1"
    Public action As String = ""
    Dim id_pl_sales_order_del As String = "-1"
    Dim id_comp_contact As String = "-1"
    Dim id_report_status As String = "-1"
    Public is_view As String = "-1"

    Private Sub FormEmpUniExpenseDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Private Sub FormEmpUniExpenseDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub


    'View Data
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            BtnPrint.Visible = False
            BtnAttachment.Visible = False
            BtnMark.Visible = False
            viewDetail()
        ElseIf action = "upd" Then
            BtnPrint.Visible = True
            BtnAttachment.Visible = True
            BtnMark.Visible = True
            Dim query_c As New ClassEmpUniExpense()
            Dim query As String = query_c.queryMain("AND e.id_emp_uni_ex=" + id_emp_uni_ex + "", "2")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TxtNumber.Text = data.Rows(0)("emp_uni_ex_number").ToString
            DECreated.EditValue = data.Rows(0)("created_date")
            MENote.Text = data.Rows(0)("memo_note").ToString
            id_pl_sales_order_del = data.Rows(0)("id_pl_sales_order_del").ToString
            TxtDel.Text = data.Rows(0)("pl_sales_order_del_number").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            viewDetail()
            allow_status()
        End If
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL view_emp_uni_ex(" + id_emp_uni_ex + ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
    End Sub

    Sub allow_status()
        TxtNumber.Enabled = False
        MENote.Enabled = False
        BtnSave.Enabled = False
        TxtDel.Enabled = False

        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If

        If is_view = "1" Then
            BtnSave.Visible = False
        End If
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "132"
        FormReportMark.id_report = id_emp_uni_ex
        If is_view = "1" Then
            FormReportMark.is_view = "1"
        End If
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "132"
        FormDocumentUpload.id_report = id_emp_uni_ex
        If is_view = "1" Or id_report_status = "6" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If id_pl_sales_order_del = "-1" Then
            stopCustom("Delivery can't blank")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to continue this process? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim emp_uni_ex_note As String = addSlashes(MENote.Text)

                'main
                Dim qi As String = "INSERT INTO tb_emp_uni_ex(id_comp_contact, id_pl_sales_order_del, emp_uni_ex_number, emp_uni_ex_date, emp_uni_ex_note, id_report_status) 
                VALUES('" + id_comp_contact + "','" + id_pl_sales_order_del + "', '" + header_number("35") + "', NOW(), '" + emp_uni_ex_note + "', 1); SELECT LAST_INSERT_ID(); "
                id_emp_uni_ex = execute_query(qi, 0, True, "", "", "", "")

                'detail
                Dim qd As String = "INSERT INTO tb_emp_uni_ex_det(id_emp_uni_ex, id_product, qty, design_cop, remark) VALUES "
                For i As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                    If i > 0 Then
                        qd += ", "
                    End If
                    qd += "('" + id_emp_uni_ex + "', '" + GVData.GetRowCellValue(i, "id_product").ToString + "', '" + decimalSQL(GVData.GetRowCellValue(i, "qty").ToString) + "', '" + decimalSQL(GVData.GetRowCellValue(i, "design_cop").ToString) + "', '" + GVData.GetRowCellValue(i, "remark").ToString + "') "
                Next
                execute_non_query(qd, True, "", "", "", "")

                'reserved stock
                Dim rsv_stock As ClassEmpUniExpense = New ClassEmpUniExpense()
                rsv_stock.reservedStock(id_emp_uni_ex, 132)

                'refresh
                action = "upd"
                actionLoad()
                FormEmpUniExpense.viewData()
                FormEmpUniExpense.GVData.FocusedRowHandle = find_row(FormEmpUniExpense.GVData, "id_emp_uni_ex", id_emp_uni_ex)
                infoCustom("Transaction : " + TxtNumber.Text + " created successfully")
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub TxtDel_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtDel.KeyDown
        If e.KeyCode = Keys.Enter Then
            'hanya bisa do single karena liat di categori SO : uniform
            Dim so_cat As String = ""
            so_cat = "AND (so.id_so_status=7 OR so.id_so_status=9) "

            Dim query As String = "SELECT pldel.id_pl_sales_order_del, so.sales_order_ol_shop_number, pldel.id_store_contact_to, comp.id_comp, comp.comp_name, comp.comp_number, comp.address_primary, comp.npwp, comp.id_drawer_def, comp.comp_commission, rck.id_wh_rack, loc.id_wh_locator, sp.id_emp_uni_ex
            FROM tb_pl_sales_order_del pldel 
            INNER JOIN tb_sales_order so ON so.id_sales_order = pldel.id_sales_order "
            query += " INNER JOIN tb_m_comp_contact cc On cc.id_comp_contact=pldel.id_store_contact_to"
            query += " INNER JOIN tb_m_comp comp ON comp.id_comp=cc.id_comp 
            INNER JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = comp.id_drawer_def 
            INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack 
            INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator "
            query += " LEFT JOIN tb_emp_uni_ex sp ON sp.id_pl_sales_order_del=pldel.id_pl_sales_order_del AND sp.id_report_status !=5 "
            query += " WHERE pldel.id_report_status='6' AND pldel.is_combine=2 AND pldel.pl_sales_order_del_number='" + addSlashes(TxtDel.Text) + "' " + so_cat + " "
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

            If data.Rows.Count <= 0 Then
                stopCustom("Delivery is not found for this store.")
                defaultReset()
                TxtDel.Focus()
            ElseIf Not data.Rows(0)("id_emp_uni_ex").ToString = "" Then
                stopCustom("Invoice is already created.")
                defaultReset()
                TxtDel.Focus()
            Else
                'id DO
                id_pl_sales_order_del = data.Rows(0)("id_pl_sales_order_del").ToString
                id_comp_contact = data.Rows(0)("id_store_contact_to").ToString
                TxtAccNo.Text = data.Rows(0)("comp_number").ToString
                TxtAcc.Text = data.Rows(0)("comp_name").ToString
                ' fill GV
                view_do()
                MENote.Focus()
            End If
        Else
            defaultReset()
        End If
    End Sub

    Sub defaultReset()
        id_comp_contact = "-1"
        id_pl_sales_order_del = "-1"
        TxtAcc.Text = ""
        TxtAccNo.Text = ""
        GCData.DataSource = Nothing
    End Sub

    Sub view_do()
        Dim query As String = "CALL view_pl_sales_order_del(" + id_pl_sales_order_del + ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
    End Sub
End Class