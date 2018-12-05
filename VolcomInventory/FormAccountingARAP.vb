Public Class FormAccountingARAP
    Public id_comp As String = "-1"

    Private Sub FormAccountingARAP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCOA()

        id_comp = FormAccounting.GVCompany.GetFocusedRowCellValue("id_comp").ToString
        TxtCompNumber.Text = FormAccounting.GVCompany.GetFocusedRowCellValue("comp_number").ToString
        TxtCompName.Text = FormAccounting.GVCompany.GetFocusedRowCellValue("comp_name").ToString
        Dim id_ap As String = FormAccounting.GVCompany.GetFocusedRowCellValue("id_acc_ap").ToString
        If id_ap = "0" Then
            SLEAP.EditValue = Nothing
        Else
            SLEAP.EditValue = id_ap
        End If

        Dim id_ar As String = FormAccounting.GVCompany.GetFocusedRowCellValue("id_acc_ar").ToString
        If id_ar = "0" Then
            SLEAR.EditValue = Nothing
        Else
            SLEAR.EditValue = id_ar
        End If
    End Sub

    Sub viewCOA()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 "
        viewSearchLookupQuery(SLEAR, query, "id_acc", "acc_description", "id_acc")
        viewSearchLookupQuery(SLEAP, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormAccountingARAP_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        SLEAP.EditValue = Nothing
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        SLEAR.EditValue = Nothing
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        Dim id_acc_ap As String = ""
        If SLEAP.EditValue = Nothing Then
            id_acc_ap = "NULL"
        Else
            id_acc_ap = SLEAP.EditValue.ToString
        End If
        Dim id_acc_ar As String = ""
        If SLEAR.EditValue = Nothing Then
            id_acc_ar = "NULL"
        Else
            id_acc_ar = SLEAR.EditValue.ToString
        End If

        If id_comp = "-1" Then
            warningCustom("Store not found")
        Else
            Dim query As String = "UPDATE tb_m_comp SET id_acc_ar='" + id_acc_ar + "', id_acc_ap='" + id_acc_ap + "' WHERE id_comp='" + id_comp + "' "
            execute_non_query(query, True, "", "", "", "")
            FormAccounting.viewCompany()
            FormAccounting.GVCompany.FocusedRowHandle = find_row(FormAccounting.GVCompany, "id_comp", id_comp)
            Close()
        End If
    End Sub
End Class