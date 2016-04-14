Public Class FormMasterItemSize
    'VIEW DATA
    Public Sub viewMasterItemSize()
        Dim query As String = "SELECT a.`id_item_size`, a.`id_item_size` AS 'no',a.`code_item_size`, a.`item_size`, "
        query += "IF(a.`description_item_size`='','-', a.`description_item_size`) AS 'description_item_size'"
        query += "FROM `tb_m_item_size` a ORDER BY a.`item_size` ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemSize.DataSource = data
    End Sub
    'FORM LOAD
    Private Sub FormMasterItemSize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewMasterItemSize()
    End Sub
    'FORM CLOSE
    Private Sub FormMasterItemSize_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormMasterItemSize_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
    End Sub

    Private Sub FormMasterItemSize_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class