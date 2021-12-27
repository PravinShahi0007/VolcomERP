Public Class FormDisplayCapacityMaster
    Public id_comp As String = "-1"
    Public id_class_group As String = "-1"

    Sub viewClassGroup()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT cg.id_class_group, cg.class_group FROM tb_class_group cg"
        viewSearchLookupQuery(SLEClassGroup, query, "id_class_group", "class_group", "id_class_group")
        Cursor = Cursors.Default
    End Sub

    Sub viewDisplayType()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT dt.id_display_type, dt.display_type FROM tb_display_type dt WHERE dt.is_display_alloc=1 "
        viewSearchLookupQuery(SLEDisplayType, query, "id_display_type", "display_type", "id_display_type")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub FormDisplayCapacityMaster_FormClosed(sender As Object, e As FormClosedEventArgs)
        Dispose()
    End Sub

    Private Sub FormDisplayCapacityMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewClassGroup()
        viewDisplayType()
        resetView()

        If id_class_group <> "-1" Then
            SLEClassGroup.EditValue = id_class_group
            SLEClassGroup.Enabled = False
        End If
    End Sub

    Sub resetView()
        SLEDisplayType.EditValue = Nothing
        TxtQty.EditValue = 0.00
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If SLEClassGroup.EditValue = Nothing Or SLEDisplayType.EditValue = Nothing Or TxtQty.EditValue <= 0 Then
            warningCustom("Please input all data")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to update qty for this class?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim id_display_type As String = SLEDisplayType.EditValue.ToString
                Dim qty As String = decimalSQL(TxtQty.EditValue.ToString)
                Dim query As String = "UPDATE tb_display_master SET is_active=2 WHERE id_comp='" + id_comp + "' AND id_class_group='" + id_class_group + "' AND id_display_type='" + id_display_type + "'; 
                INSERT INTO tb_display_master(id_comp, id_display_type, id_class_group, qty, is_active, input_date, input_by)
                VALUES('" + id_comp + "', '" + id_display_type + "', '" + id_class_group + "', '" + qty + "', 1, NOW(), '" + id_user + "'); "
                execute_non_query(query, True, "", "", "", "")

                'FormMasterCompanySingle.viewDisplayCapacity()
                'FormMasterCompanySingle.viewDCHist()
                'FormMasterCompanySingle.viewBookedDisplay()
                resetView()
                SLEDisplayType.Focus()
            End If
        End If
    End Sub

    Private Sub SLEDisplayType_EditValueChanged(sender As Object, e As EventArgs) Handles SLEDisplayType.EditValueChanged
        Dim id_display_type As String = "-1"
        Try
            id_display_type = SLEDisplayType.EditValue.ToString
        Catch ex As Exception
        End Try
        If id_display_type <> "-1" Then
            Dim query As String = "SELECT * FROM tb_display_master dm 
            WHERE dm.id_comp='" + id_comp + "' AND dm.id_class_group='" + id_class_group + "' AND dm.id_display_type='" + id_display_type + "' AND dm.is_active=1
            ORDER BY dm.id_display_master DESC LIMIT 1 "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                TxtQty.EditValue = data.Rows(0)("qty")
            Else
                TxtQty.EditValue = 0.00
            End If
        End If
    End Sub
End Class