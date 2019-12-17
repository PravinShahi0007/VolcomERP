Public Class FormInvMatDet
    Public id_inv As String = "-1"
    Public id_status As String = "1"
    '
    Private Sub FormInvMatDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_vendor()
        load_type()

        DEDueDate.EditValue = Now
        DERefDate.EditValue = Now
        DEDateCreated.EditValue = Now

        If id_inv = "-1" Then 'new
            BtnPrint.Visible = False
            BtnViewJournal.Visible = False
            BMark.Visible = False
            DEDueDate.Properties.ReadOnly = False
            DERefDate.Properties.ReadOnly = False
            '
            load_det()
            'vendor 
            SLEVendor.EditValue = FormInvMat.SLEVendorPayment.EditValue

            If FormInvMat.XTCMatInv.SelectedTabPageIndex = 1 Then
                'invoice pl
                SLEPayType.EditValue = "1"
                'detail
                Try
                    For i = 0 To FormInvMat.GVPL.RowCount - 1
                        Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                        newRow("id_prod_order") = FormInvMat.GVPL.GetRowCellValue(i, "id_prod_order").ToString
                        newRow("prod_order_number") = FormInvMat.GVPL.GetRowCellValue(i, "prod_order_number").ToString
                        newRow("id_report") = FormInvMat.GVPL.GetRowCellValue(i, "id_pl_mrs").ToString
                        newRow("report_mark_type") = "30"
                        newRow("report_number") = FormInvMat.GVPL.GetRowCellValue(i, "pl_mrs_number").ToString
                        newRow("info_design") = FormInvMat.GVPL.GetRowCellValue(i, "design_display_name").ToString
                        newRow("value") = FormInvMat.GVPL.GetRowCellValue(i, "amount")
                        newRow("note") = ""
                        TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                    Next
                    calculate()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            ElseIf FormInvMat.XTCMatInv.SelectedTabPageIndex = 2 Then
                'invoice retur
                SLEPayType.EditValue = "2"
                'detail
                Try
                    For i = 0 To FormInvMat.GVRetur.RowCount - 1
                        Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                        newRow("id_prod_order") = FormInvMat.GVRetur.GetRowCellValue(i, "id_prod_order").ToString
                        newRow("prod_order_number") = FormInvMat.GVRetur.GetRowCellValue(i, "prod_order_number").ToString
                        newRow("id_report") = FormInvMat.GVRetur.GetRowCellValue(i, "id_mat_prod_ret_in").ToString
                        newRow("report_mark_type") = "32"
                        newRow("report_number") = FormInvMat.GVRetur.GetRowCellValue(i, "mat_prod_ret_in_number").ToString
                        newRow("info_design") = FormInvMat.GVRetur.GetRowCellValue(i, "design_display_name").ToString
                        newRow("value") = FormInvMat.GVRetur.GetRowCellValue(i, "amount")
                        newRow("note") = ""
                        TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                    Next
                    calculate()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If
        Else 'edit
            BtnPrint.Visible = True
            BMark.Visible = True
            DEDueDate.Properties.ReadOnly = True
            DERefDate.Properties.ReadOnly = True
            TEVatPercent.Enabled = False
            'load header
            Dim q_head As String = "SELECT inv.`number`,inv.`id_comp`,c.`comp_name`,inv.`vat_percent`,inv.`id_inv_mat_type`,typ.`inv_mat_type`,inv.created_date,inv.ref_date,inv.due_date,inv.note,inv.id_report_status
FROM tb_inv_mat inv
INNER JOIN tb_m_comp c ON c.`id_comp`=inv.`id_comp`
INNER JOIN `tb_inv_mat_type` typ ON typ.`id_inv_mat_type`=inv.`id_inv_mat_type`
WHERE inv.id_inv_mat='" & id_inv & "'"
            Dim dt_head As DataTable = execute_query(q_head, -1, True, "", "", "", "")
            If dt_head.Rows.Count > 0 Then
                TENumber.Text = dt_head.Rows(0)("number").ToString
                SLEPayType.EditValue = dt_head.Rows(0)("id_inv_mat_type").ToString
                SLEVendor.EditValue = dt_head.Rows(0)("id_comp").ToString
                '
                DEDateCreated.EditValue = dt_head.Rows(0)("created_date")
                DEDueDate.EditValue = dt_head.Rows(0)("due_date")
                DERefDate.EditValue = dt_head.Rows(0)("ref_date")
                TEVatPercent.EditValue = dt_head.Rows(0)("vat_percent")
                MENote.Text = dt_head.Rows(0)("note").ToString
                '
                id_status = dt_head.Rows(0)("id_report_status").ToString
            End If
            '
            load_det()
            calculate()
            '
            If id_status = "6" Then
                BtnViewJournal.Visible = True
            Else
                BtnViewJournal.Visible = False
            End If
        End If
    End Sub

    Sub load_type()
        Dim query As String = "SELECT id_inv_mat_type,inv_mat_type FROM `tb_inv_mat_type`"
        viewSearchLookupQuery(SLEPayType, query, "id_inv_mat_type", "inv_mat_type", "id_inv_mat_type")
    End Sub

    Sub load_vendor()
        Dim query As String = "SELECT c.`id_comp`,c.`comp_number`,c.`comp_name`,c.`id_acc_ar` FROM tb_pl_mrs pl
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=pl.`id_comp_contact_to` AND pl.`id_pl_mat_type`='2'
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp` 
GROUP BY c.`id_comp`"
        viewSearchLookupQuery(SLEVendor, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub calculate()
        Dim tot As Decimal = 0.0
        Dim vat_p As Decimal = 0.0
        Dim tot_vat As Decimal = 0.0
        Dim grand_tot As Decimal = 0.0

        Try
            tot = GVList.Columns("value").SummaryItem.SummaryValue
            vat_p = TEVatPercent.EditValue
            tot_vat = tot * (vat_p / 100)
            '
            TETotal.EditValue = tot
            TEVat.EditValue = tot_vat
            grand_tot = tot + tot_vat
            TEGrandTotal.EditValue = grand_tot
        Catch ex As Exception

        End Try
    End Sub

    Sub load_det()
        Dim query As String = "SELECT po.`id_prod_order`,po.`prod_order_number`,invd.`info_design`,invd.`id_report`,invd.`report_mark_type`,invd.`report_number`,invd.`value`,invd.note
FROM `tb_inv_mat_det` invd
INNER JOIN tb_prod_order po ON po.`id_prod_order`=invd.`id_prod_order`
WHERE invd.`id_inv_mat`='" & id_inv & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '
        GCList.DataSource = data
    End Sub

    Private Sub FormInvMatDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub TEVatPercent_EditValueChanged(sender As Object, e As EventArgs) Handles TEVatPercent.EditValueChanged
        calculate()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If SLEPayType.EditValue.ToString = "1" Then 'PL
            If id_inv = "-1" Then
                'new
                'header
                Dim query As String = "INSERT INTO `tb_inv_mat`(`id_inv_mat_type`,`id_comp`,`created_by`,`created_date`,`note`,`id_report_status`,`due_date`,`ref_date`,`vat_percent`)
VALUES ('" & SLEPayType.EditValue.ToString & "','" & SLEVendor.EditValue.ToString & "','" & id_user & "',NOW(),'" & addSlashes(MENote.Text) & "','1','" & Date.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & Date.Parse(DERefDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & decimalSQL(TEVatPercent.EditValue.ToString) & "'); SELECT LAST_INSERT_ID(); "
                id_inv = execute_query(query, 0, True, "", "", "", "")
                'id_inv
                query = ""
                For i = 0 To GVList.RowCount - 1
                    query += "INSERT INTO `tb_inv_mat_det`(`id_inv_mat`,id_prod_order,`id_report`,`report_mark_type`,report_number,info_design,`value`,`note`)
VALUES('" & id_inv & "','" & GVList.GetRowCellValue(i, "id_prod_order").ToString & "','" & GVList.GetRowCellValue(i, "id_report").ToString & "','" & GVList.GetRowCellValue(i, "report_mark_type").ToString & "','" & GVList.GetRowCellValue(i, "report_number").ToString & "','" & GVList.GetRowCellValue(i, "info_design").ToString & "','" & decimalSQL(GVList.GetRowCellValue(i, "value").ToString) & "','" & addSlashes(GVList.GetRowCellValue(i, "note").ToString) & "');"
                Next
                execute_non_query(query, True, "", "", "", "")
                '
                query = "CALL gen_number('" & id_inv & "','231')"
                execute_non_query(query, True, "", "", "", "")
                submit_who_prepared("231", id_inv, id_user)
                '
                infoCustom("BPB Created")
                Close()
            Else
                'edit
                Dim query As String = ""
            End If
        ElseIf SLEPayType.EditValue.ToString = "2" Then 'retur
            If id_inv = "-1" Then
                'new
                'header
                Dim query As String = "INSERT INTO `tb_inv_mat`(`id_inv_mat_type`,`id_comp`,`created_by`,`created_date`,`note`,`id_report_status`,`due_date`,`ref_date`,`vat_percent`)
VALUES ('" & SLEPayType.EditValue.ToString & "','" & SLEVendor.EditValue.ToString & "','" & id_user & "',NOW(),'" & addSlashes(MENote.Text) & "','1','" & Date.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & Date.Parse(DERefDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & decimalSQL(TEVatPercent.EditValue.ToString) & "'); SELECT LAST_INSERT_ID(); "
                id_inv = execute_query(query, 0, True, "", "", "", "")
                'id_inv
                query = ""
                For i = 0 To GVList.RowCount - 1
                    query += "INSERT INTO `tb_inv_mat_det`(`id_inv_mat`,id_prod_order,`id_report`,`report_mark_type`,report_number,info_design,`value`,`note`)
VALUES('" & id_inv & "','" & GVList.GetRowCellValue(i, "id_prod_order").ToString & "','" & GVList.GetRowCellValue(i, "id_report").ToString & "','" & GVList.GetRowCellValue(i, "report_mark_type").ToString & "','" & GVList.GetRowCellValue(i, "report_number").ToString & "','" & GVList.GetRowCellValue(i, "info_design").ToString & "','" & decimalSQL(GVList.GetRowCellValue(i, "value").ToString) & "','" & addSlashes(GVList.GetRowCellValue(i, "note").ToString) & "');"
                Next
                execute_non_query(query, True, "", "", "", "")
                '
                query = "CALL gen_number('" & id_inv & "','231')"
                execute_non_query(query, True, "", "", "", "")
                submit_who_prepared("231", id_inv, id_user)
                '
                infoCustom("BRP Created")
                Close()
            Else
                'edit
                Dim query As String = ""
            End If
        End If
    End Sub
End Class