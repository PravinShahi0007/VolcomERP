Public Class FormPurcItemDet
    Public id_item As String = "-1"

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub FormPurcItemDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_uom()
        load_cat()
        '
        If Not id_item = "-1" Then 'edit
            Dim query As String = "SELECT * FROM tb_item WHERE id_item='" & id_item & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TECode.Text = data.Rows(0)("id_item").ToString
            TEDesc.Text = data.Rows(0)("item_desc").ToString
            SLECat.EditValue = data.Rows(0)("id_item_cat").ToString
            SLEUOM.EditValue = data.Rows(0)("id_uom").ToString
            '
            If data.Rows(0)("is_stock").ToString = "1" Then
                CETrackStock.Checked = True
            Else
                CETrackStock.Checked = False
            End If
        Else
            TECode.Text = "[Auto Generate]"
        End If
    End Sub

    Sub load_uom()
        Dim query As String = "SELECT id_uom,uom FROM tb_m_uom WHERE is_active='1'"
        viewSearchLookupQuery(SLEUOM, query, "id_uom", "uom", "id_uom")
    End Sub

    Sub load_cat()
        Dim query As String = "SELECT id_item_cat,item_cat FROM tb_item_cat WHERE is_active='1'"
        viewSearchLookupQuery(SLECat, query, "id_item_cat", "item_cat", "id_item_cat")
    End Sub

    Private Sub FormPurcItemDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        Dim is_check As String = ""
        '
        If CETrackStock.Checked = True Then
            is_check = "1"
        Else
            is_check = "2"
        End If
        '
        If id_item = "-1" Then 'new
            Dim query As String = "INSERT INTO tb_item(item_desc,id_item_cat,id_uom,is_stock,date_created,id_user_created,is_active) VALUES('" & TEDesc.Text & "','" & SLECat.EditValue.ToString & "','" & SLEUOM.EditValue.ToString & "','" & is_check & "',NOW(),'" & id_user & "','1'); SELECT LAST_INSERT_ID();"
            id_item = execute_query(query, 0, True, "", "", "", "")
            FormPurcItem.load_item()
            FormPurcItem.GVItem.FocusedRowHandle = find_row(FormPurcItem.GVItem, "id_item", id_item)
            Close()
        Else 'edit
            Dim query As String = "UPDATE tb_item SET item_desc='" & TEDesc.Text & "',id_item_cat='" & SLECat.EditValue.ToString & "',id_uom='" & SLEUOM.EditValue.ToString & "',is_stock='" & is_check & "',is_active='',date_updated=NOW(),id_user_updated='" & id_user & "' WHERE id_item='" & id_item & "'"
            id_item = execute_query(query, 0, True, "", "", "", "")
            FormPurcItem.load_item()
            FormPurcItem.GVItem.FocusedRowHandle = find_row(FormPurcItem.GVItem, "id_item", id_item)
            Close()
        End If
    End Sub
End Class