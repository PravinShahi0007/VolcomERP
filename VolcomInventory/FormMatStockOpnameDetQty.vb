Public Class FormMatStockOpnameDetQty
    Public id_mat_det As String = "-1"
    Public id_mat_so As String = "-1"
    Public id_mat_so_det As String = "-1"
    Dim material_image_path As String = get_setup_field("pic_path_mat") & "\"
    Sub view_image()
        If System.IO.File.Exists(material_image_path & id_mat_det & ".jpg") Then
            PictureEdit1.LoadAsync(material_image_path & id_mat_det & ".jpg")
        Else
            PictureEdit1.LoadAsync(material_image_path & "default" & ".jpg")
        End If
    End Sub

    Private Sub FormMatStockOpnameDetQty_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub Bcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bcancel.Click
        Close()
    End Sub

    Private Sub FormMatStockOpnameDetQty_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewPLCat()
        view_image()
        If Not id_mat_so_det = "-1" Then
            Try
                SPQtyPL.EditValue = FormMatStockOpnameDet.GVMatSO.GetFocusedRowCellValue("mat_so_det_qty")
                TENote.Text = FormMatStockOpnameDet.GVMatSO.GetFocusedRowCellValue("mat_so_det_note").ToString
                LEPLCategory.ItemIndex = LEPLCategory.Properties.GetDataSourceRowIndex("id_pl_category", FormMatStockOpnameDet.GVMatSO.GetFocusedRowCellValue("id_pl_category").ToString)
            Catch ex As Exception
            End Try
        End If
    End Sub
    'View PL Category
    Sub viewPLCat()
        Dim query As String = "SELECT * FROM tb_lookup_pl_category a ORDER BY a.id_pl_category  "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEPLCategory, query, 0, "pl_category", "id_pl_category")
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        If id_mat_so_det = "-1" Then 'new
            Dim query As String = "INSERT INTO tb_mat_so_det(id_mat_so,id_mat_det,mat_so_det_qty,mat_so_det_note,mat_so_det_date,id_pl_category) VALUES('" & id_mat_so & "','" & id_mat_det & "','" & decimalSQL(SPQtyPL.EditValue.ToString) & "','" & addSlashes(TENote.Text) & "',NOW(),'" & LEPLCategory.EditValue.ToString & "')"
            execute_non_query(query, True, "", "", "", "")

            query = "SELECT LAST_INSERT_ID() "
            id_mat_so_det = execute_query(query, 0, True, "", "", "", "")

            query = "UPDATE tb_mat_so SET mat_so_last_update=NOW() WHERE id_mat_so='" & id_mat_so & "'"
            execute_non_query(query, True, "", "", "", "")

            FormMatStockOpnameDet.actionLoad()
            FormMatStockOpnameDet.GVMatList.FocusedRowHandle = find_row(FormMatStockOpnameDet.GVMatList, "id_mat_det", id_mat_det)
            Close()
        Else 'edit
            Dim query As String = "UPDATE tb_mat_so_det SET mat_so_det_qty='" & decimalSQL(SPQtyPL.EditValue.ToString) & "',mat_so_det_note='" & addSlashes(TENote.Text) & "',mat_so_det_date=NOW(),id_pl_category='" & LEPLCategory.EditValue.ToString & "' WHERE id_mat_so_det='" & id_mat_so_det & "'"
            execute_non_query(query, True, "", "", "", "")

            query = "UPDATE tb_mat_so SET mat_so_last_update=NOW() WHERE id_mat_so='" & id_mat_so & "'"
            execute_non_query(query, True, "", "", "", "")

            FormMatStockOpnameDet.actionLoad()
            FormMatStockOpnameDet.GVMatList.FocusedRowHandle = find_row(FormMatStockOpnameDet.GVMatList, "id_mat_det", id_mat_det)
            Close()
        End If
    End Sub
End Class