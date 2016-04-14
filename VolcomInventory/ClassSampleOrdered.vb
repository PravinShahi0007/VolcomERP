Public Class ClassSampleOrdered
    Public Function queryMain(ByVal condition As String, ByVal order_type As String) As String
        Dim query As String = "CALL view_sample_ordered_main('" + condition + "', '" + order_type + "') "
        Return query
    End Function

    Public Function queryDetail(ByVal id_report_param As String) As String
        Dim query As String = "CALL view_sample_ordered('" + id_report_param + "')"
        Return query
    End Function
End Class
