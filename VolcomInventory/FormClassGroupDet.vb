Public Class FormClassGroupDet
    Public id_class_group As String = "-1"

    Private Sub FormClassGroupDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDivision()
        viewType()
        viewCat()
        viewClass()
        TxtEstimasiSKU.EditValue = 2
        If id_class_group <> "-1" Then
            Dim query As String = "SELECT class_group, id_division, id_class_type, id_class_cat, estimasi_sku FROM tb_class_group cg WHERE cg.id_class_group=" + id_class_group + ""
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtGroupName.Text = data.Rows(0)("class_group").ToString
            SLEDivision.EditValue = data.Rows(0)("id_division").ToString
            SLEType.EditValue = data.Rows(0)("id_class_type").ToString
            SLECat.EditValue = data.Rows(0)("id_class_cat").ToString
            TxtEstimasiSKU.EditValue = data.Rows(0)("estimasi_sku")
            GVData.ActiveFilterString = "[is_select]='Yes'"
            For i As Integer = 0 To GVData.RowCount - 1
                Dim is_select As String = GVData.GetRowCellValue(i, "is_select").ToString
                Dim pclass As String = GVData.GetRowCellValue(i, "class").ToString
                If is_select = "Yes" Then
                    acc.Add(pclass)
                Else
                    acc.Remove(pclass)
                End If
            Next
            GVData.ActiveFilterString = ""
        End If
    End Sub

    Private Sub FormClassGroupDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewType()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT * FROM tb_class_type ct"
        viewSearchLookupQuery(SLEType, query, "id_class_type", "class_type", "id_class_type")
        Cursor = Cursors.Default
    End Sub

    Sub viewClass()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT IF(!ISNULL(cgd.id_class_group_det),'Yes','No') AS `is_select`,cd.id_code_detail AS `id_class`, cd.display_name AS `class`, cd.code_detail_name AS `class_desc` 
        FROM tb_m_code_detail cd
        LEFT JOIN tb_class_group_det cgd ON cgd.id_class = cd.id_code_detail AND cgd.id_class_group=" + id_class_group + "
        WHERE cd.id_code IN (SELECT o.id_code_fg_class FROM tb_opt o)
        ORDER BY class ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewDivision()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT cd.id_code_detail AS `id_division`, cd.code_detail_name AS `division` 
FROM tb_m_code_detail cd WHERE cd.id_code IN (SELECT o.id_code_fg_division FROM tb_opt o) "
        viewSearchLookupQuery(SLEDivision, query, "id_division", "division", "id_division")
        Cursor = Cursors.Default
    End Sub

    Sub viewCat()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT c.id_class_cat, c.class_cat FROM tb_class_cat c ORDER BY c.class_cat ASC "
        viewSearchLookupQuery(SLECat, query, "id_class_cat", "class_cat", "id_class_cat")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        makeSafeGV(GVData)
        GVData.ActiveFilterString = ""
        GVData.ActiveFilterString = "[is_select]='Yes'"

        'pengecekan bole update ato tidak
        Dim cond_exist As Boolean = False
        Dim qcek As String = "SELECT * FROM tb_display_stock dst WHERE dst.id_class_group=" + id_class_group + " "
        Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
        If dcek.Rows.Count > 0 Then
            cond_exist = True
        End If

        If GVData.RowCount <= 0 Then
            warningCustom("No item selected")
        ElseIf TxtGroupName.Text = "" Then
            warningCustom("Group name can't blank")
        ElseIf TxtEstimasiSKU.EditValue <= 0 Then
            warningCustom("Silahkan isi estimasi SKU")
        ElseIf cond_exist Then
            warningCustom("Can't update, because already used")
        Else
            Cursor = Cursors.WaitCursor
            Dim id_division As String = SLEDivision.EditValue.ToString
            Dim id_class_type As String = SLEType.EditValue.ToString
            Dim id_class_cat As String = SLECat.EditValue.ToString
            Dim estimasi_sku As String = decimalSQL(TxtEstimasiSKU.EditValue.ToString)

            If id_class_group = "-1" Then 'new
                'head
                Dim query As String = "INSERT INTO tb_class_group(class_group, id_division, id_class_type, id_class_cat, estimasi_sku) VALUES('" + addSlashes(TxtGroupName.Text) + "', '" + id_division + "', '" + id_class_type + "', '" + id_class_cat + "', '" + estimasi_sku + "'); SELECT LAST_INSERT_ID(); "
                Dim id_new As String = execute_query(query, 0, True, "", "", "", "")

                'det
                Dim query_det As String = "DELETE FROM tb_class_group_det WHERE id_class_group='" + id_class_group + "' ; INSERT INTO tb_class_group_det(id_class_group, id_class) VALUES "
                For i As Integer = 0 To (GVData.RowCount - 1)
                    Dim id_class As String = GVData.GetRowCellValue(i, "id_class").ToString
                    If i > 0 Then
                        query_det += ","
                    End If
                    query_det += "('" + id_new + "', '" + id_class + "') "
                Next
                If GVData.RowCount > 0 Then
                    execute_non_query(query_det, True, "", "", "", "")
                End If
            Else 'update
                'head 
                Dim query As String = "UPDATE tb_class_group SET class_group='" + addSlashes(TxtGroupName.Text) + "',id_division='" + id_division + "', id_class_type='" + id_class_type + "', id_class_cat='" + id_class_cat + "', estimasi_sku='" + estimasi_sku + "' WHERE id_class_group='" + id_class_group + "' "
                execute_non_query(query, True, "", "", "", "")

                'detail
                Dim query_det As String = "DELETE FROM tb_class_group_det WHERE id_class_group='" + id_class_group + "' ; INSERT INTO tb_class_group_det(id_class_group, id_class) VALUES "
                For i As Integer = 0 To (GVData.RowCount - 1)
                    Dim id_class As String = GVData.GetRowCellValue(i, "id_class").ToString
                    If i > 0 Then
                        query_det += ","
                    End If
                    query_det += "('" + id_class_group + "', '" + id_class + "') "
                Next
                If GVData.RowCount > 0 Then
                    execute_non_query(query_det, True, "", "", "", "")
                End If
            End If
            FormClassGroup.viewData()
            FormClassGroup.GVData.FocusedRowHandle = find_row(FormClassGroup.GVData, "id_class_group", id_class_group)
            Close()
            Cursor = Cursors.Default
        End If
    End Sub

    Dim acc As New List(Of String)

    Private Sub GVData_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVData.CellValueChanged

    End Sub

    Private Sub RepositoryItemCheckEdit1_EditValueChanged_1(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.EditValueChanged
        Dim SpSelect As DevExpress.XtraEditors.CheckEdit = CType(sender, DevExpress.XtraEditors.CheckEdit)
        Dim is_select As String = SpSelect.EditValue.ToString
        Dim pclass As String = GVData.GetFocusedRowCellValue("class").ToString
        If is_select = "Yes" Then
            'MsgBox("Checked : " + comp_number)
            acc.Add(pclass)
        Else
            'MsgBox("Unchecked : " + comp_number)
            acc.Remove(pclass)
        End If
        showSelectedStore()
    End Sub

    Sub showSelectedStore()
        Dim i As Integer = 0
        Dim acc_col As String = ""
        For Each res As String In acc
            If i > 0 Then
                acc_col += ","
            End If
            acc_col += res
            i += 1
        Next
        TxtGroupName.Text = acc_col
    End Sub

End Class