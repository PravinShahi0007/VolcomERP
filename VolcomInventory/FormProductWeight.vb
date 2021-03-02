Public Class FormProductWeight
    Public id_trans As String = "-1"
    Public is_view As String = "-1"

    Private Sub FormProductWeight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If id_trans = "-1" Then
            'new
            BMark.Visible = False
            BtnPrint.Visible = False

            TENumber.Text = "[auto_generate]"
            DECreatedDate.EditValue = Now
        Else
            'edit
            BMark.Visible = True
            BtnPrint.Visible = True
            PCAddDel.Visible = False
            '
            Dim q As String = "SELECT pps.`created_date`,pps.`id_product_weight_pps`,pps.`number`,pps.`note`,emp.`employee_name`,pps.id_report_status
FROM `tb_product_weight_pps` pps
INNER JOIN tb_m_user usr ON usr.`id_user`=pps.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
WHERE pps.id_product_weight_pps='" & id_trans & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                TENumber.Text = dt.Rows(0)("number").ToString
                DECreatedDate.EditValue = dt.Rows(0)("created_date")
                TECreatedBy.Text = dt.Rows(0)("employee_name").ToString
                MENote.Text = dt.Rows(0)("note").ToString

                If dt.Rows(0)("id_report_status").ToString = "6" Or dt.Rows(0)("id_report_status").ToString = "5" Then
                    BtnSave.Visible = False
                Else
                    BtnSave.Visible = True
                End If
            End If

            load_det()
        End If
    End Sub

    Sub load_det()
        Dim q As String = "SELECT p.`id_product`,p.`product_full_code`,p.`product_display_name`,cd.`code_detail_name` AS size, ppsd.weight,ppsd.id_product_weight_pps_det,ppsd.note
FROM `tb_product_weight_pps_det` ppsd
INNER JOIN tb_m_product p ON ppsd.`id_product`=p.`id_product`
INNER JOIN `tb_m_product_code` pc ON p.id_product=pc.`id_product`
INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=pc.`id_code_detail`
WHERE ppsd.id_product_weight_pps='" & id_trans & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCItem.DataSource = dt
        GVItem.BestFitColumns()
    End Sub

    Private Sub FormProductWeight_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub TEFGPONumbers_KeyDown(sender As Object, e As KeyEventArgs) Handles TEFGPONumbers.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not TEFGPONumbers.Text = "" Then
                Dim q As String = "SELECT p.`id_product`,p.`product_full_code`,p.`product_display_name`,cd.`code_detail_name` AS size, 0.00 AS weight,0 AS id_product_weight_pps_det,'' AS note
FROM tb_prod_order_det pod
INNER JOIN tb_prod_order po ON po.`id_prod_order`=pod.`id_prod_order` AND po.prod_order_number='" & TEFGPONumber.Text & TEFGPONumbers.Text & "'
INNER JOIN tb_prod_demand_product pdp ON pdp.`id_prod_demand_product`=pod.`id_prod_demand_product`
INNER JOIN tb_m_product p ON p.`id_product`=pdp.`id_product`
INNER JOIN `tb_m_product_code` pc ON p.id_product=pc.`id_product`
INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=pc.`id_code_detail`"
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                If dt.Rows.Count > 0 Then
                    GCItem.DataSource = dt
                    GVItem.BestFitColumns()
                Else
                    warningCustom("FGPO Not Found")
                End If
            End If
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim is_ok_weight As Boolean = True

        For i = 0 To GVItem.RowCount - 1
            If GVItem.GetRowCellValue(i, "weight") <= 0 Then
                is_ok_weight = False
                Exit For
            End If
        Next

        If GVItem.RowCount = 0 Then
            warningCustom("Please input item")
        ElseIf Not is_ok_weight Then
            warningCustom("Please input weight correctly")
        Else
            If id_trans = "-1" Then
                Dim q As String = "INSERT INTO tb_product_weight_pps(`created_by`,`created_date`,`id_report_status`,`note`)
VALUES('" & id_user & "',NOW(),1,'" & addSlashes(MENote.Text) & "'); SELECT LAST_INSERT_ID()"
                id_trans = execute_query(q, 0, True, "", "", "", "")
                q = "INSERT INTO tb_product_weight_pps_det(`id_product_weight_pps`,`id_product`,`weight`)
VALUES"
                For i = 0 To GVItem.RowCount - 1
                    If Not i = 0 Then
                        q += ","
                    End If
                    q += "('" & id_trans & "','" & GVItem.GetRowCellValue(i, "id_product").ToString & "','" & decimalSQL(Decimal.Parse(GVItem.GetRowCellValue(i, "weight").ToString).ToString) & "')"
                Next
                execute_non_query(q, True, "", "", "", "")
                '
                q = "CALL gen_number('" & id_trans & "','299')"
                execute_non_query(q, True, "", "", "", "")
                '
                submit_who_prepared("299", id_trans, id_user)
                '
                warningCustom("Dokumen diajukan, menunggu persetujuan")
                FormProductionRec.load_weight_pps()
                Close()
                '
            Else
                'edit
                Dim q As String = "UPDATE tb_product_weight_pps SET `created_by`='" & id_user & "',`created_date`=NOW(),`note`)='" & addSlashes(MENote.Text) & "' WHERE id_product_weight_pps='" & id_trans & "'"
                execute_non_query(q, True, "", "", "", "")

                For i = 0 To GVItem.RowCount - 1
                    q += "UPDATE tb_product_weight_pps_det SET weight='" & decimalSQL(Decimal.Parse(GVItem.GetRowCellValue(i, "weight").ToString).ToString) & "' WHERE id_product_weight_pps_det='" & GVItem.GetRowCellValue(i, "id_product_weight_pps_det").ToString & "';"
                Next
                execute_non_query(q, True, "", "", "", "")

                warningCustom("Dokumen diperbaharui, menunggu persetujuan")
                FormProductionRec.load_weight_pps()
                Close()
            End If
        End If
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.report_mark_type = "299"
        FormReportMark.is_view = is_view
        FormReportMark.id_report = id_trans
        FormReportMark.ShowDialog()
    End Sub
End Class