Public Class FormAssetRecDet
    Public id_rec As String = "-1"
    Public is_view As String = "-1"
    Public id_po As String = "-1"
    Private Sub FormAssetRecDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_top()
        load_cat()
        load_dept()
        '
        DERecDate.EditValue = Now()
        '
        If Not id_rec = "-1" Then  'edit
            load_det()
        End If
        load_list()
    End Sub
    Sub load_list()
        Dim query As String = "SELECT recd.*,pod.* FROM tb_a_asset_rec_det recd
                                INNER JOIN tb_a_asset_po_det pod ON pod.`id_asset_po_det`=recd.`id_asset_po_det` WHERE recd.id_asset_rec='" & id_rec & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
        GVItemList.BestFitColumns()
    End Sub
    Sub load_det()
        Dim query As String = "SELECT * FROM tb_a_asset_rec rec 
                            INNER JOIN tb_a_asset_po po ON po.id_asset_po=rec.id_asset_rec
                            WHERE rec.id_asset_rec='" & id_rec & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            TEVendor.Text = data.Rows(0)("comp_name").ToString
            TEAttn.Text = data.Rows(0)("comp_attn").ToString
            MEAddress.Text = data.Rows(0)("comp_address").ToString
            TEPhone.Text = data.Rows(0)("comp_phone").ToString
            TEFax.Text = data.Rows(0)("comp_fax").ToString
            DEPODate.EditValue = data.Rows(0)("asset_po_date")
            DEEstRecDate.EditValue = data.Rows(0)("est_rec_date")
            TEPONumber.Text = data.Rows(0)("asset_po_no").ToString
            LEPil.ItemIndex = LEPil.Properties.GetDataSourceRowIndex("id_term_payment", data.Rows(0)("id_term_payment").ToString)
            '
            DERecDate.EditValue = data.Rows(0)("asset_rec_date")
            TERecNumber.Text = data.Rows(0)("asset_rec_no").ToString
            '
            id_po = data.Rows(0)("id_asset_po")
            If data.Rows(0)("id_report_status").ToString = "6" Then
                BPickPONumber.Enabled = False
                BtnSave.Visible = False
            End If
            '
            BMark.Visible = True
            BtnPrint.Visible = True
        End If
    End Sub
    Sub load_cat()
        Dim query As String = "SELECT id_asset_cat,asset_cat FROM tb_a_asset_cat"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupRepositoryQuery(RILEAssetCat, query, 0, "asset_cat", "id_asset_cat")
    End Sub
    Sub load_dept()
        Dim query As String = "SELECT id_departement,departement FROM tb_m_departement"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupRepositoryQuery(RILEDepartement, query, 0, "departement", "id_departement")
    End Sub
    Sub load_list_po_det()
        Dim query As String = "SELECT pod.*,'' AS id_asset_rec_det,pod.`qty` AS qty_rec,(pod.`value`-pod.`disc`) AS value_rec,'' AS note_rec
                                FROM tb_a_asset_po_det pod
                                WHERE pod.`id_asset_po`='" & id_po & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
        GVItemList.BestFitColumns()
    End Sub
    Sub load_po_det()
        Dim query As String = "SELECT * FROM tb_a_asset_po WHERE id_asset_po='" & id_po & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            TEVendor.Text = data.Rows(0)("comp_name").ToString
            TEAttn.Text = data.Rows(0)("comp_attn").ToString
            MEAddress.Text = data.Rows(0)("comp_address").ToString
            TEPhone.Text = data.Rows(0)("comp_phone").ToString
            TEFax.Text = data.Rows(0)("comp_fax").ToString
            DEPODate.EditValue = data.Rows(0)("asset_po_date")
            DEEstRecDate.EditValue = data.Rows(0)("est_rec_date")
            TEPONumber.Text = data.Rows(0)("asset_po_no").ToString
            LEPil.ItemIndex = LEPil.Properties.GetDataSourceRowIndex("id_term_payment", data.Rows(0)("id_term_payment").ToString)
            '
            load_list_po_det()
            '
        End If
    End Sub
    Sub load_top()
        Dim query As String = "SELECT id_term_payment,term_payment FROM tb_lookup_term_payment"
        viewLookupQuery(LEPil, query, 0, "term_payment", "id_term_payment")
    End Sub

    Private Sub BPickPONumber_Click(sender As Object, e As EventArgs) Handles BPickPONumber.Click
        FormAssetPickPO.ShowDialog()
    End Sub

    Private Sub FormAssetRecDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If id_rec = "-1" Then 'new
            Dim query As String = "INSERT INTO tb_a_asset_rec(id_asset_po,asset_rec_date,note,created_date,id_user_created,last_upd_date,id_user_last_upd) 
                                    VALUES('" & id_po & "','" & Date.Parse(DERecDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & addSlashes(MENote.Text) & "',NOW(),'" & id_user & "',NOW(),'" & id_user & "'); SELECT LAST_INSERT_ID(); "
            id_rec = execute_query(query, 0, True, "", "", "", "")
            'insert detail
            For i As Integer = 0 To GVItemList.RowCount - 1
                query = "INSERT INTO tb_a_asset_rec_det(id_asset_po_det,id_asset_rec,qty_rec,value_rec,note_rec) VALUES('" & GVItemList.GetRowCellValue(i, "id_asset_po_det").ToString & "','" & id_rec & "','" & GVItemList.GetRowCellValue(i, "qty_rec").ToString & "','" & GVItemList.GetRowCellValue(i, "value_rec").ToString & "','" & GVItemList.GetRowCellValue(i, "note_rec").ToString & "')"
                execute_non_query(query, True, "", "", "", "")
            Next
            infoCustom("Asset receive saved")
            load_det()
            FormAssetRec.load_rec()
            FormAssetRec.GVRecList.FocusedRowHandle = find_row(FormAssetRec.GVRecList, "id_asset_rec", id_rec)
        Else
            Dim query As String = "UPDATE tb_a_asset_rec SET id_asset_po='" & id_po & "',asset_rec_date='" & Date.Parse(DERecDate.EditValue.ToString).ToString("yyyy-MM-dd") & "',note='" & addSlashes(MENote.Text) & "',last_upd_date=NOW(),id_user_last_upd='" & id_user & "' WHERE id_asset_rec='" & id_rec & "'"
            execute_non_query(query, True, "", "", "", "")
            'insert detail
            query = "DELETE FROM tb_a_asset_rec_det WHERE id_asset_rec='" & id_rec & "'"
            execute_non_query(query, True, "", "", "", "")
            For i As Integer = 0 To GVItemList.RowCount - 1
                query = "INSERT INTO tb_a_asset_rec_det(id_asset_po_det,id_asset_rec,qty_rec,value_rec,note_rec) VALUES('" & GVItemList.GetRowCellValue(i, "id_asset_po_det").ToString & "','" & id_rec & "','" & GVItemList.GetRowCellValue(i, "qty_rec").ToString & "','" & GVItemList.GetRowCellValue(i, "value_rec").ToString & "','" & GVItemList.GetRowCellValue(i, "note_rec").ToString & "')"
                execute_non_query(query, True, "", "", "", "")
            Next
            infoCustom("Asset updated")
            load_det()
            FormAssetRec.load_rec()
            FormAssetRec.GVRecList.FocusedRowHandle = find_row(FormAssetRec.GVRecList, "id_asset_rec", id_rec)
        End If
    End Sub
End Class