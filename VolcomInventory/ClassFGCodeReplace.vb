Public Class ClassFGCodeReplace
    Public Function queryMainStore(ByVal condition As String, ByVal order_type As String) As String
        Dim query As String = "CALL view_fg_code_replace_store_main('" + condition + "', '" + order_type + "') "
        Return query
    End Function

    Public Function queryDetailStore(ByVal id_report_param As String) As String
        Dim query As String = "CALL view_fg_code_replace_store('" + id_report_param + "')"
        Return query
    End Function

    Public Function queryMainWH(ByVal condition As String, ByVal order_type As String) As String
        Dim query As String = "CALL view_fg_code_replace_wh_main('" + condition + "', '" + order_type + "') "
        Return query
    End Function

    Public Function queryDetailWH(ByVal id_report_param As String) As String
        Dim query As String = "CALL view_fg_code_replace_wh('" + id_report_param + "')"
        Return query
    End Function
End Class
