Public Class ClassSampleDelOrder
    Public Function queryMain(ByVal condition As String, ByVal order_type As String) As String
        Dim query As String = "CALL view_sample_del_order_main('" + condition + "', '" + order_type + "') "
        Return query
    End Function

    Public Function queryDetail(ByVal id_report_param As String) As String
        Dim query As String = "CALL view_sample_del_order('" + id_report_param + "')"
        Return query
    End Function

    Public Function queryDetailDrawer(ByVal condition As String, ByVal order_type As String) As String
        Dim query As String = "CALL view_sample_del_order_drw('" + condition + "', '" + order_type + "') "
        Return query
    End Function
End Class
