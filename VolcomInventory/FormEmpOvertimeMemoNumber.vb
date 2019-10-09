Public Class FormEmpOvertimeMemoNumber
    Public id_ot As String = ""

    Private Sub FormEmpOvertimeMemoNumber_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TENumber.EditValue = ""

        Dim format As String = execute_query("
            SELECT CONCAT('/INT/', (SELECT `code` FROM tb_ot_memo_number_dep WHERE id_departement = ot.id_departement), '/MM/', (SELECT `code` FROM tb_ot_memo_number_mon WHERE `month` = DATE_FORMAT(ot.created_at, '%c')), '/', DATE_FORMAT(ot.created_at, '%y')) AS `format`
            FROM tb_ot AS ot
            WHERE ot.id_ot = " + id_ot + "
        ", 0, True, "", "", "", "")

        TEFormat.EditValue = format
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        TENumber_Validating(TENumber, New System.ComponentModel.CancelEventArgs)

        If formIsValidInPanel(ErrorProvider, PanelControl2) Then
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Memo Consumption Number will be saved and cannot be changed, are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query As String = "INSERT INTO tb_ot_memo_number (id_ot, number) VALUES (" + id_ot + ", '" + addSlashes(TENumber.EditValue.ToString) + addSlashes(TEFormat.EditValue.ToString) + "')"

                execute_non_query(query, True, "", "", "", "")

                Close()
            End If
        Else
            errorCustom("Please check your input.")
        End If
    End Sub

    Private Sub FormEmpOvertimeMemoNumber_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub TENumber_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TENumber.Validating
        If TENumber.EditValue.ToString = "" Then
            ErrorProvider.SetError(TENumber, "Please fill out this field.")
        Else
            ErrorProvider.SetError(TENumber, "")
        End If
    End Sub
End Class