Public Class ClassFGWoff
    Public Function queryMain(ByVal condition As String, ByVal order_type As String) As String
        Dim query As String = "CALL view_fg_woff_main('" + condition + "', '" + order_type + "') "
        Return query
    End Function

    Public Function queryDetail(ByVal id_report_param As String) As String
        Dim query As String = "CALL view_fg_woff('" + id_report_param + "')"
        Return query
    End Function

    Public Function queryDetailDrw(ByVal id_report_param As String) As String
        Dim query As String = "CALL view_fg_woff_drw('" + id_report_param + "')"
        Return query
    End Function

    Public Function queryRollbackStock(ByVal id_report_param As String) As String
        Dim query As String = "CALL view_fg_woff_rollback('" + id_report_param + "')"
        Return query
    End Function

    Public Function queryCompletedStock(ByVal id_report_param As String) As String
        Dim query As String = "CALL view_fg_woff_moved('" + id_report_param + "')"
        Return query
    End Function

End Class
