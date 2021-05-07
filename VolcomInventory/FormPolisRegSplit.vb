Public Class FormPolisRegSplit
    Dim id_polis_reg As String = ""
    Dim id_polis_pps_det As String = ""

    Private Sub FormPolisRegSplit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEPremi.EditValue = 0.00

        id_polis_pps_det = FormPolisReg.BGVSummary.GetFocusedRowCellValue("id_polis_pps_det").ToString
        id_polis_reg = FormPolisReg.id_reg

        TEStore.Text = FormPolisReg.BGVSummary.GetFocusedRowCellValue("comp_name").ToString
        TEVendor.Text = FormPolisReg.BGVSummary.GetFocusedRowCellValue("vendor").ToString
        TEPremi.EditValue = FormPolisReg.BGVSummary.GetFocusedRowCellValue("premi")
        '
        view_desc()
        load_det()
        '
    End Sub

    Sub load_det()
        Dim q As String = "SELECT * FROM `tb_polis_reg_det`
WHERE id_polis_pps_det='" & id_polis_pps_det & "' AND id_polis_reg='" & id_polis_reg & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCDetail.DataSource = dt
        GVDetail.BestFitColumns()
    End Sub

    Sub view_desc()
        Dim q As String = "SELECT description FROM tb_lookup_desc_premi WHERE is_active=1"
        viewSearchLookupRepositoryQuery(RISLEDesc, q, 0, "description", "description")
    End Sub

    Private Sub FormPolisRegSplit_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BDel_Click(sender As Object, e As EventArgs) Handles BDel.Click
        If GVDetail.RowCount > 0 Then
            GVDetail.DeleteSelectedRows()
        End If
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        GVDetail.AddNewRow()
    End Sub

    Private Sub BSubmit_Click(sender As Object, e As EventArgs) Handles BSubmit.Click
        'check
        GVDetail.RefreshData()

        If GVDetail.RowCount <= 0 Then
            warningCustom("Please put detail")
        ElseIf Not Decimal.Parse(GVDetail.Columns("premi").SummaryItem.SummaryValue) = Decimal.Parse(TEPremi.EditValue) Then
            warningCustom("Please make sure total premi same as proposed")
        Else
            'check loop
            Dim is_ok As Boolean = True
            For i = 0 To GVDetail.RowCount - 1
                If GVDetail.GetRowCellValue(i, "description").ToString = "" Or GVDetail.GetRowCellValue(i, "polis_number").ToString = "" Or Decimal.Parse(GVDetail.GetRowCellValue(i, "premi").ToString) <= 0 Then
                    is_ok = False
                End If
            Next

            If Not is_ok Then
                warningCustom("Please check your input again")
            Else
                Dim q As String = "DELETE FROM tb_polis_reg_det WHERE id_polis_reg='" & id_polis_reg & "'"
                execute_non_query(q, True, "", "", "", "")
                '
                q = "INSERT INTO tb_polis_reg_det(`id_polis_reg`,`id_polis_pps_det`,`premi`,`polis_number`,`description`) VALUES"
                For i = 0 To GVDetail.RowCount - 1
                    If Not i = 0 Then
                        q += ","
                    End If

                    q = "('" & id_polis_reg & "','" & id_polis_pps_det & "','" & decimalSQL(Decimal.Parse(GVDetail.GetRowCellValue(i, "premi").ToString)) & "','" & addSlashes(GVDetail.GetRowCellValue(i, "polis_number").ToString) & "','" & addSlashes(GVDetail.GetRowCellValue(i, "description").ToString) & "')"
                Next
                execute_non_query(q, True, "", "", "", "")
                FormPolisReg.load_pps_view()
                Close()
            End If
        End If
    End Sub
End Class