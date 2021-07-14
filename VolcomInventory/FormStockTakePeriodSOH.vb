Public Class FormStockTakePeriodSOH
    Private Sub FormStockTakePeriodSOH_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "
            SELECT 'no' AS is_select, d.id_design, d.design_code, d.design_display_name, c.code AS class
            FROM tb_m_design AS d
            INNER JOIN (
	            SELECT c.id_design, d.code, d.code_detail_name
	            FROM tb_m_design_code AS c
	            INNER JOIN tb_m_code_detail AS d ON d.id_code_detail = c.id_code_detail
	            WHERE d.id_code = 30
            ) AS c ON d.id_design = c.id_design
            WHERE d.id_lookup_status_order <> 2
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            For j = 0 To FormStockTakeStorePeriodDet.id_design.Count - 1
                If data.Rows(i)("id_design").ToString = FormStockTakeStorePeriodDet.id_design(j).ToString Then
                    data.Rows(i)("is_select") = "yes"
                End If
            Next
        Next

        GCSOH.DataSource = data

        GVSOH.BestFitColumns()
    End Sub

    Private Sub FormStockTakePeriodSOH_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        Dim data As DataTable = GCSOH.DataSource

        If CheckEdit1.EditValue Then
            For i = 0 To data.Rows.Count - 1
                data.Rows(i)("is_select") = "yes"
            Next
        Else
            For i = 0 To data.Rows.Count - 1
                data.Rows(i)("is_select") = "no"
            Next
        End If

        GCSOH.DataSource = data
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        GVSOH.FindFilterText = ""
        GVSOH.ClearColumnsFilter()
        GVSOH.ActiveFilterString = "[is_select] = 'yes'"

        FormStockTakeStorePeriodDet.id_design.Clear()

        For i = 0 To GVSOH.RowCount - 1
            If GVSOH.IsValidRowHandle(i) Then
                FormStockTakeStorePeriodDet.id_design.Add(GVSOH.GetRowCellValue(i, "id_design").ToString)
            End If
        Next

        FormStockTakeStorePeriodDet.CEAll.EditValue = False

        Close()
    End Sub

    Private Sub SBEOS_Click(sender As Object, e As EventArgs) Handles SBEOS.Click
        FormStockTakePeriodEOS.ShowDialog()
    End Sub
End Class