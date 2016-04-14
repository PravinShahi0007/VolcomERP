Public Class ClassFGSalesOrderReff
    Public Function queryMain(ByVal condition As String, ByVal order_type As String) As String
        Dim query As String = "CALL view_fg_so_reff_main('" + condition + "', '" + order_type + "') "
        Return query
    End Function

    Public Function queryDetail(ByVal id_report_param As String, ByVal id_season_param As String) As String
        Dim query As String = "CALL view_fg_so_reff('" + id_report_param + "', '" + id_season_param + "')"
        Return query
    End Function
End Class
