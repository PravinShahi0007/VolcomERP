Public Class FormAccountingFYear 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormAccountingFYear_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormAccountingFYear_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormAccountingFYear_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub view_acc()
        Dim query As String = ""
        query += "SELECT a.id_acc_fy,a.acc_fy_name,DATE_FORMAT(a.acc_fy_start_date, '%d %M %Y') as acc_fy_start_date,IFNULL(DATE_FORMAT(a.acc_fy_end_date, '%d %M %Y'),'') as acc_fy_end_date FROM tb_a_acc_fy a ORDER BY a.id_acc_fy DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAcc.DataSource = data
    End Sub

    Private Sub FormAccountingFYear_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_acc()
    End Sub
End Class