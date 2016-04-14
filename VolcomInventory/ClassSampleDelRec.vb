Public Class ClassSampleDelRec
    Public Function queryMain(ByVal condition As String, ByVal order_type As String) As String
        Dim query As String = "CALL view_sample_del_rec_main('" + condition + "', '" + order_type + "') "
        Return query
    End Function

    Public Function queryDetail(ByVal id_sample_del_rec_param As String) As String
        Dim query As String = "CALL view_sample_del_rec('" + id_sample_del_rec_param + "')"
        Return query
    End Function

    Public Function queryDetailCost(ByVal condition As String, ByVal order_type As String) As String
        Dim query As String = "CALL view_sample_del_rec_drw('" + condition + "', '" + order_type + "') "
        Return query
    End Function
End Class
