Public Class FormFGCodeReplaceStoreAdd
    Dim id_comp As String = "-1"
    Dim id_design As String = "-1"
    Private Sub FormFGCodeReplaceStoreAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActiveControl = TxtStoreCode
        TxtQty.EditValue = 0
        TxtAvailable.EditValue = 0
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FormFGCodeReplaceStoreAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub resetInput()
        id_comp = "-1"
        id_design = "-1"
        TxtStoreCode.Text = ""
        TxtStoreName.Text = ""
        TxtDesignCode.Text = ""
        TxtDesignName.Text = ""
        TxtQty.EditValue = 0
        TxtAvailable.EditValue = 0
    End Sub

End Class