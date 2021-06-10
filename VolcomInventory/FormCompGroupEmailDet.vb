Public Class FormCompGroupEmailDet
    Public id_comp_group As String = "-1"

    Private Sub FormCompGroupEmailDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_type()
        TECompGroup.Text = FormCompGroupEmail.GVGroupComp.GetFocusedRowCellValue("description").ToString
    End Sub

    Sub load_type()
        Dim q As String = "SELECT 1 AS is_to,'To' AS `desc`
UNION ALL
SELECT 2 AS is_to,'CC' AS `desc`"
        viewSearchLookupQuery(SLEToCC, q, "is_to", "desc", "is_to")
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormCompGroupEmailDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        If TEEmail.Text = "" Or TEName.Text = "" Then
            warningCustom("Please complete your input")
        Else
            Dim q As String = "INSERT INTO `tb_mail_to_group`(`report_mark_type`,`id_comp_group`,`is_to`,`email`,`name`) VALUES('" & FormCompGroupEmail.SLEReportMarkType.EditValue.ToString & "','" & id_comp_group & "','" & SLEToCC.EditValue.ToString & "','" & addSlashes(TEEmail.Text) & "','" & addSlashes(TEName.Text) & "')"
            execute_non_query(q, True, "", "", "", "")
            Close()
            FormCompGroupEmail.show_email()
        End If
    End Sub
End Class