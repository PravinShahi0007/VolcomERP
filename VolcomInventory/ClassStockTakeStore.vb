Public Class ClassStockTakeStore
    Sub checkClosedStockTake(ByVal id_bap As String)
        Dim qp As String = "SELECT b.id_st_store_period FROM tb_st_store_bap b WHERE b.id_st_store_bap=" + id_bap + ""
        Dim id_st_store_period As String = execute_query(qp, 0, True, "", "", "", "")

        Dim qc As String = "SELECT c.id_comp, b.id_st_store_bap
        FROM tb_st_store_period p
        INNER JOIN tb_m_comp c ON c.id_store = p.id_store
        LEFT JOIN tb_st_store_bap b ON b.id_comp = c.id_comp AND b.id_st_store_period=" + id_st_store_period + " AND b.id_report_status NOT IN (5)
        WHERE p.id_st_store_period=" + id_st_store_period + " AND ISNULL(b.id_st_store_bap) "
        Dim dc As DataTable = execute_query(qc, -1, True, "", "", "", "")
        If dc.Rows.Count = 0 Then
            execute_non_query_long("CALL ins_st_store_unique_not_found(" + id_st_store_period + ")", True, "", "", "", "")
        End If
    End Sub

    Sub cancelClosedStockTake(ByVal id_bap As String)
        Dim qp As String = "SELECT b.id_st_store_period FROM tb_st_store_bap b WHERE b.id_st_store_bap=" + id_bap + ""
        Dim id_st_store_period As String = execute_query(qp, 0, True, "", "", "", "")
        execute_non_query_long("CALL del_st_store_unique_not_found(" + id_st_store_period + ")", True, "", "", "", "")
    End Sub
End Class
