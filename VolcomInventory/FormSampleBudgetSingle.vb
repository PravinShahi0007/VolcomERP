Public Class FormSampleBudgetSingle
    Public is_edit As String = "2"
    Private Sub FormSampleBudgetSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEYearBudget.EditValue = Now
        TEBudgetRp.EditValue = 0.00
        TEBudgetUSD.EditValue = 0.00
        '
        load_division()
        '
        If is_edit = "1" Then
            TEDescription.Text = FormSampleBudgetDet.GVAfter.GetFocusedRowCellValue("description_after").ToString
            DEYearBudget.EditValue = Date.Parse("1-1-" & FormSampleBudgetDet.GVAfter.GetFocusedRowCellValue("year_after").ToString)
            TEBudgetRp.EditValue = FormSampleBudgetDet.GVAfter.GetFocusedRowCellValue("value_rp_after")
            TEBudgetUSD.EditValue = FormSampleBudgetDet.GVAfter.GetFocusedRowCellValue("value_usd_after")
            '
            Dim divs() As String = FormSampleBudgetDet.GVAfter.GetFocusedRowCellValue("id_division_after").ToString.Split(",")
            For Each div As String In divs
                GVDivision.ActiveFilterString = "[id_code_detail] = '" & div.ToString & "'"
                If GVDivision.RowCount > 0 Then
                    GVDivision.SetRowCellValue(0, "is_check", "yes")
                End If
                GVDivision.ActiveFilterString = ""
            Next div
            BtnSave.Text = "Update"
        Else
            BtnSave.Text = "Insert"
        End If
    End Sub

    Sub load_division()
        Dim query As String = "SELECT 'no' AS is_check,cd.* FROM tb_m_code_detail cd
WHERE cd.`id_code`='16'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDivision.DataSource = data
        GVDivision.BestFitColumns()
    End Sub

    Private Sub FormSampleBudgetSingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        GVDivision.ActiveFilterString = "[is_check] = 'yes'"
        If GVDivision.RowCount <= 0 Then
            warningCustom("Please select division to budget")
        Else
            Dim id_code_detail As String = ""
            Dim code_detail As String = ""
            For i As Integer = 0 To GVDivision.RowCount - 1
                If Not i = 0 Then
                    id_code_detail += ","
                    code_detail += ","
                End If
                id_code_detail += GVDivision.GetRowCellValue(i, "id_code_detail").ToString
                code_detail += GVDivision.GetRowCellValue(i, "code_detail_name").ToString
            Next

            If is_edit = "1" Then
                FormSampleBudgetDet.GVAfter.SetFocusedRowCellValue("description_after", TEDescription.Text)
                FormSampleBudgetDet.GVAfter.SetFocusedRowCellValue("year_after", Date.Parse(DEYearBudget.EditValue).ToString("yyyy"))
                FormSampleBudgetDet.GVAfter.SetFocusedRowCellValue("value_usd_after", TEBudgetUSD.EditValue)
                FormSampleBudgetDet.GVAfter.SetFocusedRowCellValue("value_rp_after", TEBudgetRp.EditValue)
                FormSampleBudgetDet.GVAfter.SetFocusedRowCellValue("id_division_after", id_code_detail)
                FormSampleBudgetDet.GVAfter.SetFocusedRowCellValue("division_after", code_detail)
                FormSampleBudgetDet.GCAfter.RefreshDataSource()
                FormSampleBudgetDet.GVAfter.RefreshData()
                Close()
            Else
                Dim newRow As DataRow = (TryCast(FormSampleBudgetDet.GCAfter.DataSource, DataTable)).NewRow()
                newRow("description_after") = TEDescription.Text
                newRow("year_after") = Date.Parse(DEYearBudget.EditValue.ToString).ToString("yyyy")
                newRow("value_usd_after") = TEBudgetUSD.EditValue
                newRow("value_rp_after") = TEBudgetRp.EditValue
                newRow("id_division_after") = id_code_detail
                newRow("division_after") = code_detail
                TryCast(FormSampleBudgetDet.GCAfter.DataSource, DataTable).Rows.Add(newRow)
                FormSampleBudgetDet.GCAfter.RefreshDataSource()
                FormSampleBudgetDet.GVAfter.RefreshData()
                FormSampleBudgetDet.GVAfter.FocusedRowHandle = FormSampleBudgetDet.GVAfter.RowCount - 1
                FormSampleBudgetDet.check_but()
            End If
        End If
        GVDivision.ActiveFilterString = ""
    End Sub
End Class