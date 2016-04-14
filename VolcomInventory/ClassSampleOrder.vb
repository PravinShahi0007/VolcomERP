Public Class ClassSampleOrder
    Public Function queryMain(ByVal condition As String, ByVal order_type As String) As String
        Dim query As String = "CALL view_sample_order_main('" + condition + "', '" + order_type + "') "
        Return query
    End Function

    Public Function queryDetail(ByVal id_report_param As String) As String
        Dim query As String = "CALL view_sample_order('" + id_report_param + "')"
        Return query
    End Function

    Public Function queryDetailLimit(ByVal id_report_param As String, ByVal id_report_pl_param As String) As String
        Dim query As String = "CALL view_sample_order_limit('" + id_report_param + "', '" + id_report_pl_param + "') "
        Return query
    End Function
End Class
