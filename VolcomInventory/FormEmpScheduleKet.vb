Public Class FormEmpScheduleKet
    Public id_schedule As String = ""
    Public id_emp_schedule_ket As String = "1"

    Private Sub FormEmpScheduleKet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_ket()
        LETypeKet.ItemIndex = LETypeKet.Properties.GetDataSourceRowIndex("id_emp_schedule_ket", id_emp_schedule_ket)
    End Sub

    Sub load_ket()
        Dim query As String = "SELECT id_emp_schedule_ket,ket FROM tb_emp_schedule_ket"
        viewLookupQuery(LETypeKet, query, 0, "ket", "id_emp_schedule_ket")
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormEmpScheduleKet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        Dim query As String = ""
        If LETypeKet.Text = "" Then
            query = "UPDATE tb_emp_schedule SET id_emp_schedule_ket=NULL,info_ket='" & MEInfo.Text & "' WHERE id_schedule='" & id_schedule & "'"
            execute_non_query(query, True, "", "", "", "")
        Else
            query = "UPDATE tb_emp_schedule SET id_emp_schedule_ket='" & LETypeKet.EditValue.ToString & "',info_ket='" & MEInfo.Text & "' WHERE id_schedule='" & id_schedule & "'"
            execute_non_query(query, True, "", "", "", "")
        End If

        FormEmpAttnSum.load_report()
        FormEmpAttnSum.GVSum.FocusedRowHandle = find_row(FormEmpAttnSum.GVSum, "id_schedule", id_schedule)
        Close()
    End Sub

    Private Sub BReset_Click(sender As Object, e As EventArgs) Handles BReset.Click
        Dim query As String = ""
        query = "UPDATE tb_emp_schedule SET id_emp_schedule_ket=NULL,info_ket='' WHERE id_schedule='" & id_schedule & "'"
        execute_non_query(query, True, "", "", "", "")
        FormEmpAttnSum.load_report()
        FormEmpAttnSum.GVSum.FocusedRowHandle = find_row(FormEmpAttnSum.GVSum, "id_schedule", id_schedule)
        Close()
    End Sub
End Class