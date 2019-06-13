Public Class ReportEmpOvertime
    Public id As String = "0"
    Public data As DataTable = New DataTable
    Public is_check As String = "-1"
    Public id_pre As String = "-1"

    Private Sub ReportEmpOvertime_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        viewSearchLookupRepositoryQuery(RISLUEType, "SELECT 1 AS id_type, 'Salary' AS type UNION SELECT 2 AS id_type, 'DP' AS type", 0, "type", "id_type")

        GCEmployee.DataSource = data

        GCConversionType.Caption = GCConversionType.Caption.Replace(" ", Environment.NewLine)
        GCStartWork.Caption = GCStartWork.Caption.Replace(" ", Environment.NewLine)
        GCEndWork.Caption = GCEndWork.Caption.Replace(" ", Environment.NewLine)
        GCBreakHours.Caption = GCBreakHours.Caption.Replace(" ", Environment.NewLine)
        GCTotalHours.Caption = GCTotalHours.Caption.Replace(" ", Environment.NewLine)

        GVEmployee.BestFitColumns()

        If is_check = "-1" Then
            GCStartWork.Visible = False
            GCEndWork.Visible = False
            GCBreakHours.Visible = False
            GCTotalHours.Visible = False
            GCPoint.Visible = False
            GCValid.Visible = False
        End If

        If id_pre = "-1" Then
            load_mark_horz("184", id, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("184", id, "2", "2", XrTable1)
        End If
    End Sub
End Class