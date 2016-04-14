Public Class FormAccountingFYearOpen 
    Public id_acc_fy As String = "-1"

    Private Sub FormAccountingFYearOpen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_awal()
    End Sub

    Sub load_awal()
        Dim query As String = "SELECT a.id_acc_fy,a.acc_fy_name,DATE_FORMAT(a.acc_fy_start_date, '%d %M %Y') as acc_fy_start_date,DATE_FORMAT(NOW(), '%d %M %Y') as acc_fy_end_date, DATE_FORMAT(DATE_ADD(NOW(),INTERVAL 1 DAY), '%d %M %Y') as date_besok FROM tb_a_acc_fy a WHERE a.id_acc_fy='" & id_acc_fy & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        MEAccDesc.Text = data.Rows(0)("acc_fy_name").ToString
        TEStart.Text = data.Rows(0)("acc_fy_start_date").ToString
        TEEnd.Text = data.Rows(0)("acc_fy_end_date").ToString

        MENext.Text = ""
        TEStartNext.Text = data.Rows(0)("date_besok").ToString
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormAccountingFYearOpen_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim confirm As DialogResult
        Dim query As String

        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to close this period?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            query = String.Format("UPDATE tb_a_acc_fy SET acc_fy_end_date=NOW() WHERE id_acc_fy='{0}'", id_acc_fy)
            execute_non_query(query, True, "", "", "", "")

            query = String.Format("INSERT INTO tb_a_acc_fy(acc_fy_name,acc_fy_start_date) VALUES('{0}',DATE_ADD(NOW(),INTERVAL 1 DAY))", MENext.Text)
            execute_non_query(query, True, "", "", "", "")

            infoCustom("Periode has been closed.")
            FormAccountingFYearDet.load_awal()
            FormAccountingFYear.view_acc()
            'insert new period
            Close()
        End If
    End Sub
End Class