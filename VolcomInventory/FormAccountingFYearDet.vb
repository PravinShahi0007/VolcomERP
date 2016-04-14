Public Class FormAccountingFYearDet 
    Public id_acc_fy As String = "-1"

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormAccountingFYearDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_awal()
    End Sub

    Sub load_awal()
        Dim query As String = "SELECT a.id_acc_fy,a.acc_fy_name,DATE_FORMAT(a.acc_fy_start_date, '%d %M %Y') as acc_fy_start_date,IFNULL(DATE_FORMAT(a.acc_fy_end_date, '%d %M %Y'),'') as acc_fy_end_date FROM tb_a_acc_fy a WHERE a.id_acc_fy='" & id_acc_fy & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        MEAccDesc.Text = data.Rows(0)("acc_fy_name").ToString
        TEStart.Text = data.Rows(0)("acc_fy_start_date").ToString
        TEEnd.Text = data.Rows(0)("acc_fy_end_date").ToString
        If data.Rows(0)("acc_fy_end_date").ToString = "" Then
            BSave.Enabled = True
            BCloseYear.Enabled = True
        Else
            BSave.Enabled = False
            BCloseYear.Enabled = False
        End If
    End Sub

    Private Sub FormAccountingFYearDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim query As String = String.Format("UPDATE tb_a_acc_fy SET acc_fy_name='{0}' WHERE id_acc_fy='{1}'", MEAccDesc.Text, id_acc_fy)
        execute_non_query(query, True, "", "", "", "")

        infoCustom("Description Updated.")
        load_awal()
    End Sub

    Private Sub BCloseYear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCloseYear.Click
        FormAccountingFYearOpen.id_acc_fy = id_acc_fy
        FormAccountingFYearOpen.ShowDialog()
    End Sub
End Class