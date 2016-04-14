Public Class ClassFGBorrowQCReq
    Public Function queryMainReq(ByVal condition As String, ByVal order_type As String) As String
        Dim query As String = "CALL view_fg_borrow_qc_req_main('" + condition + "', '" + order_type + "') "
        Return query
    End Function

    Public Function queryDetailReq(ByVal id_report_param As String) As String
        Dim query As String = "CALL view_fg_borrow_qc_req('" + id_report_param + "')"
        Return query
    End Function
End Class
