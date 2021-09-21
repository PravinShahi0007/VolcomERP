Public Class FormDisplayAllocDet
    Public id_class_group As String = "-1"
    Public foc As String = ""

    Sub viewDisplayType()
        Dim query As String = "SELECT dt.id_display_type, dt.display_type FROM tb_display_type dt"
        viewSearchLookupQuery(SLEDisplayType, query, "id_display_type", "display_type", "id_display_type")
    End Sub

    Private Sub FormDisplayAllocDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDisplayType()
        resetView()

        'cek
        Dim qt As String = "SELECT dt.id_display_type, dt.display_type FROM tb_display_type dt WHERE dt.display_type='" + foc + "' "
        Dim dt As DataTable = execute_query(qt, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then
            SLEDisplayType.EditValue = dt.Rows(0)("id_display_type").ToString
        End If
    End Sub

    Private Sub FormDisplayAllocDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        If SLEDisplayType.EditValue = Nothing Or TxtQty.EditValue = 0 Or TxtCapacity.EditValue = 0 Then
            warningCustom("Please input all data")
        Else
            'save
            Dim id_display_type As String = SLEDisplayType.EditValue.ToString
            Dim qty_size As String = decimalSQL(TxtQty.EditValue.ToString)
            Dim capacity As String = decimalSQL(TxtCapacity.EditValue.ToString)
            Dim query As String = "DELETE FROM tb_display_alloc WHERE id_class_group='" + id_class_group + "' AND id_display_type='" + id_display_type + "';
            INSERT INTO tb_display_alloc(id_display_type, id_class_group, qty_size, capacity) 
            VALUES(" + id_display_type + ", " + id_class_group + ", " + qty_size + ", " + capacity + "); "
            execute_non_query(query, True, "", "", "", "")
            FormDisplayAlloc.viewData()
            FormDisplayAlloc.GVData.FocusedRowHandle = find_row(FormDisplayAlloc.GVData, "id_class_group", id_class_group)
            resetView()
        End If
    End Sub

    Sub resetView()
        SLEDisplayType.EditValue = Nothing
        TxtCapacity.EditValue = 0.00
        TxtQty.EditValue = 0
    End Sub

    Private Sub SLEDisplayType_EditValueChanged(sender As Object, e As EventArgs) Handles SLEDisplayType.EditValueChanged
        Dim id_display_alloc As String = "-1"
        Dim id_sel As String = "-1"
        Try
            id_sel = SLEDisplayType.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim qry As String = "SELECT a.id_display_alloc, a.id_display_type, a.id_class_group, a.qty_size, a.capacity 
        FROM tb_display_alloc a
        WHERE a.id_class_group='" + id_class_group + "' AND  a.id_display_type='" + id_sel + "' "
        Dim dt As DataTable = execute_query(qry, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then
            id_display_alloc = dt.Rows(0)("id_display_alloc").ToString
            TxtQty.EditValue = dt.Rows(0)("qty_size")
            TxtCapacity.EditValue = dt.Rows(0)("capacity")
        Else
            id_display_alloc = "-1"
            TxtQty.EditValue = 0
            TxtCapacity.EditValue = 0.00
        End If
    End Sub
End Class