Public Class ClassFGMissingInv
    Public Function queryMain(ByVal condition_param As String, ByVal order_type_param As String) As String
        Dim query As String = "CALL view_fg_missing_inv_main('" + condition_param + "', '" + order_type_param + "') "
        Return query
    End Function

    Public Function queryMainReport(ByVal condition_param As String, ByVal order_type_param As String) As String
        Dim query As String = "CALL view_fg_missing_inv_report('" + condition_param + "', '" + order_type_param + "') "
        Return query
    End Function

    Public Function queryDetail(ByVal id_report_param As String) As String
        Dim query As String = "CALL view_fg_missing('" + id_report_param + "')"
        Return query
    End Function

    Public Function queryDetailReport(ByVal id_report_param As String) As String
        Dim query As String = "CALL view_fg_missing_report('" + id_report_param + "')"
        Return query
    End Function
End Class
