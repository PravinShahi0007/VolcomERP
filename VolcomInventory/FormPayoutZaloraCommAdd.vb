Public Class FormPayoutZaloraCommAdd
    Public id_payout As String = "-1"
    Private Sub FormPayoutZaloraCommAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCOA()
        actionLoad()
    End Sub

    Private Sub FormPayoutZaloraCommAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        Dim id_payout_zalora As String = id_payout
        Dim id_acc As String = SLECOA.EditValue.ToString
        Dim adj_value As String = decimalSQL(TxtAmount.EditValue.ToString)
        Dim note As String = addSlashes(MENote.Text)

        'insert
        Dim query As String = "INSERT INTO tb_payout_zalora_comm_addition(id_payout_zalora, id_zalora_comm_type, id_acc, value, note) 
        VALUES('" + id_payout_zalora + "','" + +"'); "
        execute_non_query(query, True, "", "", "", "")
        FormPayoutZaloraComm.viewAddition()
        actionLoad()
    End Sub

    Sub viewCOA()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description,CONCAT(a.acc_name,' - ', a.acc_description) AS `acc`, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 AND a.id_coa_type='1' "
        viewSearchLookupQuery(SLECOA, query, "id_acc", "acc", "id_acc")
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        MENote.Text = ""
        TxtAmount.EditValue = 0.00
        MENote.Focus()
        Cursor = Cursors.Default
    End Sub
End Class