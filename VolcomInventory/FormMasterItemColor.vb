Public Class FormMasterItemColor
    'Form Close
    Private Sub FormMasterItemColor_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'Form Load
    Private Sub FormMasterItemColor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewMasterItemColor()
    End Sub
    'View 
    Public Sub viewMasterItemColor()
        Dim query As String = "SELECT a.`id_item_color`, a.`id_item_color` AS 'no',a.`code_item_color`, a.`item_color`, "
        query += "IF(a.`description_item_color`='','-', a.`description_item_color`) AS 'description_item_color'"
        query += "FROM `tb_m_item_color` a ORDER BY a.`item_color` ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemColor.DataSource = data
    End Sub

    Private Sub FormMasterItemColor_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
    End Sub

    Private Sub FormMasterItemColor_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class