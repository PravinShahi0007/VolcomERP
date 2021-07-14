Public Class FormStockTakePeriodEOS
    Private Sub FormStockTakePeriodEOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "
            SELECT s.id_st_store_partial, s.number, s.note, r.report_status, e.employee_name AS created_by, DATE_FORMAT(created_at, '%d %M %Y %H:%i:%s') AS created_at
            FROM tb_st_store_partial AS s
            LEFT JOIN tb_lookup_report_status AS r ON r.id_report_status = s.id_report_status
            LEFT JOIN tb_m_user AS u ON s.created_by = u.id_user
            LEFT JOIN tb_m_employee AS e ON u.id_employee = e.id_employee
            WHERE s.id_report_status = 6
            ORDER BY s.id_st_store_partial DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCData.DataSource = data

        GVData.BestFitColumns()
    End Sub

    Private Sub FormStockTakePeriodEOS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        Cursor = Cursors.WaitCursor

        Dim dataSource As DataTable = FormStockTakePeriodSOH.GCSOH.DataSource

        Dim query As String = "
            SELECT id_design FROM tb_st_store_partial_det WHERE id_st_store_partial = " + GVData.GetFocusedRowCellValue("id_st_store_partial").ToString + "
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To dataSource.Rows.Count - 1
            dataSource.Rows(i)("is_select") = "no"

            For j = 0 To data.Rows.Count - 1
                If dataSource.Rows(i)("id_design").ToString = data.Rows(j)("id_design").ToString Then
                    dataSource.Rows(i)("is_select") = "yes"

                    Exit For
                End If
            Next
        Next

        FormStockTakePeriodSOH.GCSOH.DataSource = dataSource

        Cursor = Cursors.Default

        Close()
    End Sub
End Class