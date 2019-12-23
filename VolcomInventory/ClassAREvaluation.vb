Public Class ClassAREvaluation
    Function dtCekEmailRelease(ByVal id_group As String) As DataTable
        Dim query_cek_email_release As String = "SELECT e.id_comp_group, IFNULL(ep.jum_not_active,0) AS `jum_not_active`
        FROM tb_ar_eval e
        LEFT JOIN (
          SELECT e.id_comp_group,
          COUNT(e.id_sales_pos) AS `jum_not_active`
          FROM tb_ar_eval e
          WHERE e.eval_date IN (SELECT MAX(e.eval_date)  FROM tb_ar_eval e)
          AND e.id_comp_group IN (" + id_group + ") AND e.is_active=1
          GROUP BY e.id_comp_group
        ) ep ON ep.id_comp_group = e.id_comp_group
        WHERE e.eval_date IN (SELECT MAX(e.eval_date)  FROM tb_ar_eval e)
        AND e.id_comp_group IN (" + id_group + ")
        GROUP BY e.id_comp_group
        HAVING jum_not_active=0 "
        Dim data_cek_email_release As DataTable = execute_query(query_cek_email_release, -1, True, "", "", "", "")
        Return data_cek_email_release
    End Function
End Class