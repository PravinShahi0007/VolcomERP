Public Class FormDisplayCapacityMaster
    Public id_comp As String = "-1"
    Public id_class_group As String = "-1"

    Sub viewClassGroup()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT cg.id_class_group, cg.class_group FROM tb_class_group cg WHERE cg.is_active=1 "
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
        'cek capacity
        Dim qtc As String = "SELECT IFNULL(SUM(da.capacity * dm.qty),0.00) AS `total_cap`
        FROM tb_display_master dm 
        INNER JOIN tb_display_alloc da ON da.id_display_type= dm.id_display_type AND da.id_class_group = dm.id_class_group
        WHERE dm.id_comp=" + id_comp + " AND dm.is_active=1 AND dm.id_class_group='" + SLEClassGroup.EditValue.ToString + "' 
        AND dm.id_display_type!=" + SLEDisplayType.EditValue.ToString + " "
        Dim dtc As DataTable = execute_query(qtc, -1, True, "", "", "", "")
        Dim total_cap As Decimal = TxtTotalCapacity.EditValue + dtc.Rows(0)("total_cap")
        'cek ocuupied
        Dim qmd As String = "SELECT DATE_SUB(MAX(ds.return_date),INTERVAL 1 DAY) AS `max_date` FROM tb_display_stock ds 
        WHERE ds.is_active=1 AND ds.id_comp=" + id_comp + " AND ds.id_class_group='" + SLEClassGroup.EditValue.ToString + "'  
        HAVING !ISNULL(max_date) "
        Dim dmd As DataTable = execute_query(qmd, -1, True, "", "", "", "")
        Dim err_stock As String = ""
        If dmd.Rows.Count > 0 Then
            Dim max_date As String = DateTime.Parse(dmd.Rows(0)("max_date").ToString).ToString("yyyy-MM-dd")
            Dim max_date_display As String = DateTime.Parse(dmd.Rows(0)("max_date").ToString).ToString("dd MMMM yyyy")
            Dim csd As New ClassStoreDisplay()
            'cek ocuppiced
            Dim cond_par As String = "AND ds.id_comp=" + id_comp + " AND ds.id_class_group='" + SLEClassGroup.EditValue.ToString + "' "
            Dim qstock As String = csd.queryStockByClassGroup(max_date, cond_par)
            Dim dstock As DataTable = execute_query(qstock, -1, True, "", "", "", "")
            If dstock.Rows(0)("qty") > total_cap Then
                err_stock = "Qty tidak dapat diubah karena kapasitas tidak mencukupi " + System.Environment.NewLine + "(occupied until " + max_date_display + " : " + dstock.Rows(0)("qty").ToString + " pcs) "
            End If
        End If

        If SLEClassGroup.EditValue = Nothing Or SLEDisplayType.EditValue = Nothing Or TxtQty.EditValue < 0 Then
            warningCustom("Please input all data")
        ElseIf err_stock <> "" Then
            warningCustom(err_stock)
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to update qty for this class?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim id_display_type As String = SLEDisplayType.EditValue.ToString
                Dim qty As String = decimalSQL(TxtQty.EditValue.ToString)
                Dim query As String = "UPDATE tb_display_master SET is_active=2 WHERE id_comp='" + id_comp + "' AND id_class_group='" + id_class_group + "' AND id_display_type='" + id_display_type + "'; 
                INSERT INTO tb_display_master(id_comp, id_display_type, id_class_group, qty, is_active, input_date, input_by)
                VALUES('" + id_comp + "', '" + id_display_type + "', '" + id_class_group + "', '" + qty + "', 1, NOW(), '" + id_user + "'); "
                execute_non_query(query, True, "", "", "", "")

                FormMasterCompanySingle.viewDisplayCapacity()
                FormMasterCompanySingle.viewDCHist()
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
            getCapacity
        End If
    End Sub

    Private Sub SLEClassGroup_EditValueChanged(sender As Object, e As EventArgs) Handles SLEClassGroup.EditValueChanged
        getCapacity
    End Sub

    Sub getCapacity()
        Dim id_class_group As String = "-1"
        Try
            id_class_group = SLEClassGroup.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim id_display_type As String = "-1"
        Try
            id_display_type = SLEDisplayType.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim capacity As Decimal = 0.00
        Dim query As String = "SELECT da.capacity FROM tb_display_alloc da WHERE da.id_display_type=" + id_display_type + " AND da.id_class_group=" + id_class_group + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count <= 0 Then
            capacity = 0.00
        Else
            capacity = data.Rows(0)("capacity").ToString
        End If
        TxtCapacity.EditValue = capacity
        Dim qty As Decimal = 0.0
        Try
            qty = TxtQty.EditValue
        Catch ex As Exception
        End Try
        TxtTotalCapacity.EditValue = capacity * qty
    End Sub

    Private Sub TxtQty_EditValueChanged(sender As Object, e As EventArgs) Handles TxtQty.EditValueChanged
        getCapacity()
    End Sub
End Class