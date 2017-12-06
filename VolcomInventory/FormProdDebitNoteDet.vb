Public Class FormProdDebitNoteDet
    Public id_dn As String = "-1"
    Public id_comp_contact_debit_to As String = "-1"

    Private Sub FormProdDebitNoteDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        action_load()
    End Sub
    Sub action_load()
        If id_dn = "-1" Then 'new
            TxtVirtualPosNumber.Text = header_number_prod("14")
            Dim date_dn As Date = Now()
            DEForm.Text = date_dn.ToString("dd MMM yyyy")
        Else

        End If
        load_gv()
    End Sub

    Sub load_gv()
        Dim query As String = "SELECT * FROM tb_prod_debit_note_det WHERE id_prod_debit_note='" & id_dn & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProdRec.DataSource = data
        GVProdRec.BestFitColumns()

        button_check()
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormProdDebitNoteDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnBrowseContactFrom_Click(sender As Object, e As EventArgs) Handles BtnBrowseContactFrom.Click
        FormPopUpContact.id_cat = "1"
        FormPopUpContact.id_pop_up = "84"
        FormPopUpContact.ShowDialog()
    End Sub

    Sub button_check()
        If GVProdRec.RowCount > 0 Then
            BEdit.Visible = True
            BDelete.Visible = True
        Else
            BEdit.Visible = False
            BDelete.Visible = False
        End If
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click

    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        FormPopUpRecQC.id_pop_up = "2"
        FormPopUpRecQC.ShowDialog()
    End Sub
End Class