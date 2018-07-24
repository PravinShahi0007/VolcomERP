Public Class FormItemCoaProposeAdd
    Private Sub FormItemCoaProposeAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCat()
        viewCOA()
        viewData()
    End Sub

    Sub viewData()
        Dim query As String = "SELECT d.id_departement, d.departement, NULL AS `exp_acc`, NULL AS `inv_acc`,
        '1' AS `is_request`, '2' AS `is_expense`
        FROM tb_m_departement d WHERE d.is_office_dept=1"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
    End Sub


    Sub viewCat()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT c.id_item_cat, c.item_cat FROM tb_item_cat c ORDER BY id_item_cat ASC"
        viewLookupQuery(LECat, query, 0, "item_cat", "id_item_cat")
        Cursor = Cursors.Default
    End Sub

    Sub viewCOA()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        RepositoryItemSearchLookUpEdit1.DataSource = Nothing
        RepositoryItemSearchLookUpEdit1.DataSource = data
        RepositoryItemSearchLookUpEdit1.DisplayMember = "acc_description"
        RepositoryItemSearchLookUpEdit1.ValueMember = "id_acc"
        'If CheckEdit1.EditValue = True Then
        '    RepositoryItemSearchLookUpEdit1View.ActiveFilterString = "[acc_description] like '%" + LECat.Text.ToString + "%'"
        '    RepositoryItemSearchLookUpEdit1View.ApplyColumnsFilter()
        '    RepositoryItemSearchLookUpEdit1View.RefreshData()
        'End If
    End Sub


    Private Sub FormItemCoaProposeAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub LECat_EditValueChanged(sender As Object, e As EventArgs) Handles LECat.EditValueChanged
        viewData()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        add()
    End Sub

    Sub add()
        Cursor = Cursors.WaitCursor
        GVData.ActiveFilterString = "Not IsNullOrEmpty([exp_acc])"
        If GVData.RowCount > 0 Then
            Dim err As String = ""
            For i As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                'If i > 0 And err <> "" Then
                '    'err += System.Environment.NewLine
                'End If

                'check exist
                'cek kondisi master
                Dim id_cat As String = LECat.EditValue.ToString
                Dim id_dept As String = GVData.GetRowCellValue(i, "id_departement").ToString
                Dim dept As String = GVData.GetRowCellValue(i, "departement").ToString
                Dim cm As Boolean = False
                Dim qm As String = "SELECT * FROM tb_item_coa WHERE id_item_cat='" + id_cat + "' AND id_departement='" + id_dept + "' "
                Dim dm As DataTable = execute_query(qm, -1, True, "", "", "", "")
                If dm.Rows.Count > 0 Then
                    cm = True
                End If
                'cel kondisi propose
                Dim cp As Boolean = False
                Dim qp As String = "SELECT * FROM tb_item_coa_propose_det d 
                INNER JOIN tb_item_coa_propose m ON m.id_item_coa_propose = d.id_item_coa_propose
                WHERE d.id_item_cat='" + id_cat + "' AND d.id_departement='" + id_dept + "' AND m.id_report_status!=5 "
                Dim dp As DataTable = execute_query(qp, -1, True, "", "", "", "")
                If dp.Rows.Count > 0 Then
                    cp = True
                End If
                If cm Or cp Then
                    err += dept + " : Mapping already exist" + System.Environment.NewLine
                End If


                'check access menu
                Dim is_req As String = GVData.GetRowCellValue(i, "is_request").ToString
                Dim is_exp As String = GVData.GetRowCellValue(i, "is_expense").ToString
                If is_req = "2" And is_exp = "2" Then

                    err += dept + " : Please select access menu one or both" + System.Environment.NewLine
                End If
            Next

            If err <> "" Then
                stopCustom("ERROR" + System.Environment.NewLine + err)
                GVData.ActiveFilterString = ""
            Else

                infoCustom("Oke sip")

            End If
        Else
            stopCustom("Data can't blank")
            GVData.ActiveFilterString = ""
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged

    End Sub

    Private Sub RepositoryItemSearchLookUpEdit1_Popup(sender As Object, e As EventArgs) Handles RepositoryItemSearchLookUpEdit1.Popup
        Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = TryCast(GVData.ActiveEditor, DevExpress.XtraEditors.SearchLookUpEdit)
        If CheckEdit1.EditValue = True Then
            editor.Properties.View.ActiveFilterString = "[acc_description] like '%" + LECat.Text.ToString + "%'"
        End If
    End Sub
End Class