Public Class FormVMMove
    Public id As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"

    Private Sub FormVMMove_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDelDetail_Click(sender As Object, e As EventArgs) Handles BtnDelDetail.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this item ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                GVData.DeleteRow(GVData.FocusedRowHandle)
                CType(GCData.DataSource, DataTable).AcceptChanges()
                GCData.RefreshDataSource()
                GVData.RefreshData()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub FormVMMove_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_head()
    End Sub

    Sub load_head()
        load_store()
        load_type()
        '
        If id = "-1" Then
            'new
        Else
            Dim q As String = "SELECT h.number,h.note,h.created_date,emp.employee_name,h.id_report_status,h.id_comp_from,h.id_comp_to,h.id_type FROM tb_vm_item_move h
INNER JOIN tb_m_user usr ON usr.id_user=h.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
WHERE h.id_vm.item_move='" & id & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                DECreated.EditValue = dt.Rows(0)("created_date")
                TENumber.Text = dt.Rows(0)("number").ToString
                TECreated_by.Text = dt.Rows(0)("employee_name").ToString
                MENote.Text = dt.Rows(0)("note").ToString
                '
                SLEType.EditValue = dt.Rows(0)("id_type").ToString
                If SLEType.EditValue.ToString = "1" Then
                    SLETo.EditValue = dt.Rows(0)("id_comp_to").ToString
                    SLEFrom.EditValue = dt.Rows(0)("id_comp_from").ToString
                Else
                    SLEFrom.EditValue = dt.Rows(0)("id_comp_from").ToString
                End If
                id_report_status = dt.Rows(0)("id_report_status").ToString
            End If
        End If

        load_det()
    End Sub

    Sub load_type()
        Dim q As String = "SELECT '1' AS id_type,'Transfer' AS type
UNION ALL
SELECT '2' AS id_type,'Add' AS type
UNION ALL
SELECT '3' AS id_type,'Remove' AS type"
        viewSearchLookupQuery(SLEType, q, "id_type", "type", "id_type")
    End Sub

    Sub load_store()
        Dim q As String = "SELECT 0 AS id_comp,'-' AS comp_number,'Office' AS comp_name
UNION ALL
SELECT id_comp,comp_number,comp_name
FROM tb_m_comp
WHERE id_comp_cat='6'"
        viewSearchLookupQuery(SLEFrom, q, "id_comp", "comp_name", "id_comp")
        viewSearchLookupQuery(SLETo, q, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub clear_row()
        For i = GVData.RowCount - 1 To 0 Step -1
            GVData.DeleteRow(i)
        Next
    End Sub

    Sub load_item()
        Dim q As String = "SELECT s.`id_item`,i.`item_desc` ,SUM(s.`qty`) AS qty
FROM tb_stock_vm s
INNER JOIN tb_item i ON i.`id_item`=s.`id_item`
WHERE s.`id_comp`='" & SLEFrom.EditValue.ToString & "'
GROUP BY s.`id_item`"
        viewSearchLookupQuery(SLEItem, q, "id_item", "item_desc", "id_item")
        SLEItem.EditValue = Nothing
    End Sub

    Sub load_item_add()
        Dim q As String = "SELECT i.`id_item`,i.`item_desc`,0 AS qty
FROM tb_item i 
WHERE i.is_active=1"
        viewSearchLookupQuery(SLEItem, q, "id_item", "item_desc", "id_item")
        SLEItem.EditValue = Nothing
    End Sub

    Private Sub SLEToko_EditValueChanged(sender As Object, e As EventArgs) Handles SLEFrom.EditValueChanged
        clear_row()
        load_item()
    End Sub

    Sub load_det()
        Dim q As String = "SELECT d.`id_item`,i.`item_desc`,d.`qty`,uom.`uom`,d.`remark`
FROM tb_vm_item_move_det d
INNER JOIN tb_item i ON i.`id_item`=d.`id_item`
INNER JOIN tb_m_uom uom ON uom.`id_uom`=i.`id_uom`
WHERE d.`id_vm_item_move`='" & id & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCData.DataSource = dt
        GVData.BestFitColumns()
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        If Not SLEItem.EditValue = Nothing Then
            'check
            Dim is_already As Boolean = False
            For i = 0 To GVData.RowCount - 1
                If GVData.GetRowCellValue(i, "id_item").ToString = SLEItem.EditValue.ToString Then
                    is_already = True
                    Exit For
                End If
            Next
            '
            If is_already Then
                warningCustom("Item already on list")
            Else
                Dim newRow As DataRow = (TryCast(GCData.DataSource, DataTable)).NewRow()
                newRow("id_item") = SLEItem.EditValue.ToString
                newRow("item_desc") = SLEItem.Text.ToString
                newRow("uom") = SLEItem.Properties.View.GetFocusedRowCellValue("uom").ToString
                newRow("qty") = 1
                newRow("remark") = ""
                TryCast(FormItemReqDet.GCDetail.DataSource, DataTable).Rows.Add(newRow)
                GCData.RefreshDataSource()
                GVData.RefreshData()
            End If
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If GVData.RowCount = 0 Then
            warningCustom("Please add item")
        ElseIf SLEFrom.EditValue.ToString = SLETo.EditValue.ToString Then
            warningCustom("Please pick location to move properly")
        Else
            Dim is_ok_limit As Boolean = True

            Dim from_c As String = "NULL"
            Dim to_c As String = "NULL"

            If SLEType.EditValue.ToString = "1" Then
                from_c = "'" & SLEFrom.EditValue.ToString & "'"
                to_c = "'" & SLETo.EditValue.ToString & "'"
            Else
                from_c = "'" & SLEFrom.EditValue.ToString & "'"
            End If

            If id = "-1" Then
                'new
                Dim q As String = "INSERT INTO tb_vm_item_move(id_type,id_comp_from,id_comp_to,created_date,created_by,note) VALUES('" & SLEType.EditValue.ToString & "'," & from_c & "," & to_c & ",NOW(),'" & id_user & "','" & addSlashes(MENote.Text) & "'); SELECT LAST_INSERT_ID();"
                id = execute_query(q, 0, True, "", "", "", "")
                '
                execute_non_query("CALL gen_number('" & id & "','389')", True, "", "", "", "")
                'detail
                q = "DELETE FROM tb_vm_item_move_det WHERE id_vm_item_move='" & id & "'"
                execute_non_query(q, True, "", "", "", "")
                '
                q = "INSERT INTO tb_vm_item_move(id_item_vm_move,id_item,qty,remark) VALUES"
                For i = 0 To GVData.RowCount - 1
                    If Not i = 0 Then
                        q += ","
                    End If
                    q += "('" & id & "','" & GVData.GetRowCellValue(i, "id_item").ToString & "','" & decimalSQL(Decimal.Parse(GVData.GetRowCellValue(i, "qty").ToString).ToString) & "','" & addSlashes(GVData.GetRowCellValue(i, "remark").ToString) & "')"
                Next
                execute_non_query(q, True, "", "", "", "")
                '
                submit_who_prepared("389", id, id_user)

                load_head()
            Else
                'edit
            End If
        End If
    End Sub

    Private Sub SLEType_EditValueChanged(sender As Object, e As EventArgs) Handles SLEType.EditValueChanged
        clear_row()

        If SLEType.EditValue.ToString = "1" Then
            'pindah asset
            SLEFrom.Visible = True
            LFrom.Visible = True
            SLETo.Visible = True
            LTo.Visible = True
            load_item()
        ElseIf SLEType.EditValue.ToString = "2" Then
            'add asset
            SLEFrom.Visible = True
            LFrom.Visible = True
            SLETo.Visible = False
            LTo.Visible = False
            load_item_add()
        ElseIf SLEType.EditValue.ToString = "3" Then
            'remove asset
            SLEFrom.Visible = True
            LFrom.Visible = True
            SLETo.Visible = False
            LTo.Visible = False
            load_item()
        End If
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "389"
        FormReportMark.id_report = id
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class