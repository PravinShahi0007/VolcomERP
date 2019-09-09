Public Class ReportEmpAttnInd
    Public Shared dt As DataTable
    Public Shared id_pre As String = "-1"

    Private Sub ReportEmpAttnInd_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCEmployee.DataSource = dt
    End Sub

    Private Sub GVEmployee_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVEmployee.RowCellStyle
        Try
            If GVEmployee.GetRowCellValue(e.RowHandle, "id_schedule_type").ToString = "1" And Date.Parse(GVEmployee.GetRowCellValue(e.RowHandle, "date").ToString).Date < Now.Date And GVEmployee.GetRowCellValue(e.RowHandle, "present").ToString = "0" And GVEmployee.GetRowCellValue(e.RowHandle, "id_leave_type").ToString = "" Then
                e.Appearance.BackColor = Color.Yellow
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class