Public Class FormPurcReqDet
    Public id_req As String = "-1"
    Public id_user_created As String = "-1"
    Public is_draft As String = "1"

    Private Sub FormPurcReqDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If id_req = "-1" Then 'new
            load_item_pil()
            load_det()

            '
            TEReqBy.Text = name_user
            id_user_created = id_user
            DEDateCreated.EditValue = Now
            TEReqNUmber.Text = "[auto generate]"
            TEDep.Text = get_departement_x(id_departement_user, "1")
        Else 'edit
            load_item_pil_edit()
        End If
        load_but()
    End Sub

    Sub load_but()
        If id_req = "-1" Then 'new
            PanelControl3.Visible = True
            BtnAdd.Visible = True
            If GVItemList.RowCount > 0 Then
                BtnDel.Visible = True
            Else
                BtnDel.Visible = False
            End If
        Else
            PanelControl3.Visible = False
            BtnDel.Visible = False
            BtnAdd.Visible = False
        End If
    End Sub

    Sub load_det()
        Dim query As String = "SELECT * FROM tb_purc_req_det WHERE id_purc_req='" & id_req & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub

    Sub load_item_pil()
        Dim query As String = "SELECT it.id_item,it.item_desc,cat.item_cat FROM tb_item it
                                INNER JOIN tb_item_cat cat ON cat.id_item_cat=it.id_item_cat
                                INNER JOIN tb_item_coa itc ON itc.id_item_cat=cat.id_item_cat AND itc.id_departement='" & id_departement_user & "'
                                WHERE it.is_active='1'"
        viewSearchLookupRepositoryQuery(RISLEItem, query, 0, "item_desc", "id_item")
    End Sub

    Sub load_item_pil_edit()
        Dim query As String = "SELECT it.id_item,it.item_desc,cat.item_cat FROM tb_item it
                                INNER JOIN tb_item_cat cat ON cat.id_item_cat=it.id_item_cat
                                INNER JOIN tb_item_coa itc ON itc.id_item_cat=cat.id_item_cat AND itc.id_departement='" & id_departement_user & "'"
        viewSearchLookupRepositoryQuery(RISLEItem, query, "id_item", "item_desc", "id_item")
    End Sub

    Private Sub FormPurcReqDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        GVItemList.AddNewRow()
    End Sub

    Private Sub GVItemList_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVItemList.CellValueChanged
        If e.Column.FieldName = "id_item" Then
            If Not e.Value = "" Then

            End If
        End If
    End Sub
End Class