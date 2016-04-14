Public Class FormInfoDrawer 
    Public id_sample As String = ""
    Public id_mat_det As String = ""
    Private Sub FormInfoDrawer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewDrawer()
    End Sub

    Sub viewDrawer()
        Dim query As String = ""
        If id_sample <> "" Then
            query = "SELECT j.id_wh_drawer, f.sample_code, f.sample_name, g.uom, n.comp_name, n.id_comp, m.wh_locator, m.id_wh_locator, l.wh_rack, l.id_wh_rack, k.wh_drawer , "
            query += "CAST(SUM(IF(j.id_storage_category='2', CONCAT('-', j.qty_sample), j.qty_sample)) AS DECIMAL(13,2)) AS qty_all_sample "
            query += "FROM tb_m_sample f "
            query += "INNER JOIN tb_m_uom g ON g.id_uom = f.id_uom "
            query += "INNER JOIN tb_storage_sample j ON j.id_sample = f.id_sample "
            query += "INNER JOIN tb_m_wh_drawer k ON j.id_wh_drawer = k.id_wh_drawer "
            query += "INNER JOIN tb_m_wh_rack l ON l.id_wh_rack = k.id_wh_rack "
            query += "INNER JOIN tb_m_wh_locator m ON m.id_wh_locator =  l.id_wh_locator "
            query += "INNER JOIN tb_m_comp n ON n.id_comp = m.id_comp "
            query += "WHERE j.id_wh_drawer  LIKE '%%' "
            query += "AND l.id_wh_rack  LIKE '%%' "
            query += "AND m.id_wh_locator  LIKE '%%' "
            query += "AND n.id_comp  LIKE '%%' "
            query += "AND j.id_sample = '" + id_sample + "' "
            query += "GROUP BY j.id_sample, j.id_wh_drawer "
            query += "ORDER BY j.id_wh_drawer ASC "
        ElseIf id_mat_det <> "" Then
            query = "SELECT j.id_wh_drawer, f.mat_det_code, f.mat_det_name, g.uom, n.comp_name, n.id_comp, m.wh_locator, m.id_wh_locator, l.wh_rack, l.id_wh_rack, k.wh_drawer ,j.id_mat_det_price, j.price, "
            query += "CAST(SUM(IF(j.id_storage_category='2', CONCAT('-', j.storage_mat_qty), j.storage_mat_qty)) AS DECIMAL(13,2)) AS qty_all_sample "
            query += "FROM tb_m_mat_det f "
            query += "INNER JOIN tb_m_mat f0 ON f.id_mat = f0.id_mat "
            query += "INNER JOIN tb_m_uom g ON g.id_uom = f0.id_uom "
            query += "INNER JOIN tb_storage_mat j ON j.id_mat_det = f.id_mat_det "
            query += "INNER JOIN tb_m_wh_drawer k ON j.id_wh_drawer = k.id_wh_drawer "
            query += "INNER JOIN tb_m_wh_rack l ON l.id_wh_rack = k.id_wh_rack "
            query += "INNER JOIN tb_m_wh_locator m ON m.id_wh_locator =  l.id_wh_locator "
            query += "INNER JOIN tb_m_comp n ON n.id_comp = m.id_comp "
            query += "WHERE j.id_wh_drawer  LIKE '%%' "
            query += "AND l.id_wh_rack  LIKE '%%' "
            query += "AND m.id_wh_locator  LIKE '%%' "
            query += "AND n.id_comp  LIKE '%%' "
            query += "AND j.id_mat_det = '" + id_mat_det + "' "
            query += "GROUP BY j.id_mat_det, j.id_wh_drawer, j.id_mat_det_price, j.price "
            query += "ORDER BY j.id_wh_drawer ASC "
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSampleDrawer.DataSource = data
        'viewPLDel()
        viewImg()
    End Sub

    Sub viewImg()
        Try
            If id_sample <> "" Then
                pre_viewImages("1", PictureEdit1, id_sample, False)
            ElseIf id_mat_det <> "" Then
                pre_viewImages("3", PictureEdit1, id_mat_det, False)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub BtnViewImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewImg.Click
        'Try
        If id_sample <> "" Then
            pre_viewImages("1", PictureEdit1, id_sample, True)
        ElseIf id_mat_det <> "" Then
            pre_viewImages("3", PictureEdit1, id_mat_det, True)
        End If
        'Catch ex As Exception
        'End Try
    End Sub
End Class