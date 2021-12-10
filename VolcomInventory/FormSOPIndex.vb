Public Class FormSOPIndex
    Public is_super_admin As String = "2"

    Private Sub FormSOPIndex_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not is_super_admin = "1" Then
            BNewSOP.Visible = False
        Else
            BNewSOP.Visible = True
        End If
    End Sub

    Private Sub FormSOPIndex_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BNewSOP_Click(sender As Object, e As EventArgs) Handles BNewSOP.Click
        FormSOPNew.ShowDialog()
    End Sub

    Private Sub BRefresh_Click(sender As Object, e As EventArgs) Handles BRefresh.Click
        Dim q As String = "SELECT s.*,d.departement,m.`menu_caption`
FROM `tb_sop` s
INNER JOIN tb_m_departement d ON d.id_departement=s.id_departement
LEFT JOIN tb_sop_menu_erp er ON er.id_sop=s.id_sop
LEFT JOIN tb_menu m ON m.`id_menu`=er.`id_menu`"
        If Not is_super_admin = "1" Then
            q += " WHERE s.id_departement='" & id_departement_user & "' "
        End If

        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCBySOP.DataSource = dt
        GVBySOP.BestFitColumns()
    End Sub

    Private Sub GVBySOP_DoubleClick(sender As Object, e As EventArgs) Handles GVBySOP.DoubleClick
        If GVBySOP.RowCount > 0 Then
            FormSOPNew.id = GVBySOP.GetFocusedRowCellValue("id_sop").ToString
            FormSOPNew.ShowDialog()
        End If
    End Sub
End Class