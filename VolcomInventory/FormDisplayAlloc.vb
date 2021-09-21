Public Class FormDisplayAlloc
    Private Sub FormDisplayAlloc_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormDisplayAlloc_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor

        'build kolom
        Dim qt As String = "SELECT dt.id_display_type, UPPER(dt.display_type) AS `display_type` FROM tb_display_type dt "
        Dim dt As DataTable = execute_query(qt, -1, True, "", "", "", "")
        Dim col_type1 As String = ""
        Dim col_type2 As String = ""
        For i As Integer = 0 To dt.Rows.Count - 1
            If i > 0 Then
                col_type1 += ","
                col_type2 += ","
            End If
            col_type1 += "SUM(CASE WHEN a.id_display_type=" + dt.Rows(i)("id_display_type").ToString + " THEN a.capacity END) AS `" + dt.Rows(i)("display_type").ToString + "` "
            col_type2 += "IFNULL(a.`" + dt.Rows(i)("display_type").ToString + "`,0) AS `" + dt.Rows(i)("display_type").ToString + "` "
        Next

        Dim query As String = "SELECT cg.id_class_group, cg.id_division, dv.display_name AS `division`, 
        cg.id_class_type, ct.class_type, cg.id_class_cat, UPPER(cat.class_cat) AS `class_cat`, cg.class_group,
        " + col_type2 + ",
        IFNULL(a.`TOTAL DISPLAY`,0) AS `TOTAL DISPLAY`, 
        IFNULL(a.`ESTIMASI SKU`,0) AS `ESTIMASI SKU`
        FROM tb_class_group cg
        INNER JOIN tb_m_code_detail dv ON dv.id_code_detail = cg.id_division
        INNER JOIN tb_class_type ct ON ct.id_class_type = cg.id_class_type
        INNER JOIN tb_class_cat cat ON cat.id_class_cat = cg.id_class_cat
        LEFT JOIN (
	        SELECT a.id_class_group, 
	        " + col_type1 + ",
	        SUM(a.capacity) AS `TOTAL DISPLAY`, 
	        SUM(a.capacity / a.qty_size) AS `ESTIMASI SKU`
	        FROM tb_display_alloc a
	        GROUP BY a.id_class_group
        ) a ON a.id_class_group = cg.id_class_group "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnClassGroup_Click(sender As Object, e As EventArgs) Handles BtnClassGroup.Click
        Cursor = Cursors.WaitCursor
        FormClassGroup.ShowDialog()
        viewData()
        Cursor = Cursors.Default
    End Sub
End Class