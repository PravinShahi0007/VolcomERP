Public Class ReportEmpOvertime
    Public id As String = "0"
    Public data As DataTable = New DataTable
    Public is_check As String = "-1"
    Public id_pre As String = "-1"

    Private Sub ReportEmpOvertime_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        viewSearchLookupRepositoryQuery(RISLUEType, "SELECT id_ot_conversion AS id_type, conversion_type AS type, to_salary FROM tb_lookup_ot_conversion", 0, "type", "id_type")

        GCEmployee.DataSource = data

        GCConversionType.Caption = GCConversionType.Caption.Replace(" ", Environment.NewLine)

        GVEmployee.BestFitColumns()

        If id_pre = "-1" Then
            load_mark_horz("184", id, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("184", id, "2", "2", XrTable1)
        End If
    End Sub
End Class