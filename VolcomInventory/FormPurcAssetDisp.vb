Public Class FormPurcAssetDisp
    Public id_trans As String = "-1"
    Private Sub FormPurcAssetDisp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_pil()
        load_det()
    End Sub

    Sub load_pil()
        Dim q As String = "SELECT ass.id_purc_rec_asset
,ass.id_acc_fa,ass.id_acc_dep_accum
,accacum.acc_name AS acc_dep_accum_name,accacum.acc_description AS acc_dep_accum
,accfa.acc_name AS acc_fa_name,accfa.acc_description AS acc_fa
,ass.asset_number,ass.asset_name,ass.asset_note,(ass.acq_cost+ass.value_added) AS total_value, IFNULL(SUM(amount),0.00) AS dep_value,(ass.acq_cost+ass.value_added) - IFNULL(SUM(amount),0.00) AS rem_value
FROM `tb_purc_rec_asset` ass 
LEFT JOIN `tb_purc_rec_asset_dep` dep ON dep.id_purc_rec_asset=ass.id_purc_rec_asset
INNER JOIN tb_a_acc accfa ON accfa.id_acc=ass.id_acc_fa
INNER JOIN tb_a_acc accacum ON accacum.id_acc=ass.id_acc_dep_accum
WHERE ass.is_active=1
GROUP BY ass.id_purc_rec_asset"
        viewSearchLookupRepositoryQuery(RISLEAsset, q, 0, "asset_number", "id_purc_rec_asset")
    End Sub

    Sub load_det()
        Dim q As String = "SELECT dd.`id_purc_rec_asset_disp_det`,dd.`id_purc_rec_asset`,dd.`id_acc_fa`,dd.`id_acc_dep_accum`,dd.`rem_value`,dd.`harga_jual`
,accacum.acc_name AS acc_dep_accum_name,accacum.acc_description AS acc_dep_accum
,accfa.acc_name AS acc_fa_name,accfa.acc_description AS acc_fa
FROM tb_purc_rec_asset_disp_det dd
INNER JOIN tb_a_acc accfa ON accfa.id_acc=dd.id_acc_fa
INNER JOIN tb_a_acc accacum ON accacum.id_acc=dd.id_acc_dep_accum
WHERE dd.id_purc_rec_asset_disp='" & id_trans & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCItem.DataSource = dt
        GVItem.BestFitColumns()
        check_but()
    End Sub

    Private Sub RISLEAsset_EditValueChanged(sender As Object, e As EventArgs) Handles RISLEAsset.EditValueChanged
        Try
            Dim sle As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
            'budget
            GVItem.SetFocusedRowCellValue("acc_dep_accum_name", sle.Properties.View.GetFocusedRowCellValue("acc_dep_accum_name").ToString())
            GVItem.SetFocusedRowCellValue("acc_dep_accum", sle.Properties.View.GetFocusedRowCellValue("acc_dep_accum").ToString())
            GVItem.SetFocusedRowCellValue("acc_fa_name", sle.Properties.View.GetFocusedRowCellValue("acc_fa_name").ToString())
            GVItem.SetFocusedRowCellValue("acc_fa", sle.Properties.View.GetFocusedRowCellValue("acc_fa").ToString())
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BDelete_Click(sender As Object, e As EventArgs) Handles BDelete.Click
        If GVItem.RowCount > 0 Then
            GVItem.DeleteSelectedRows()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Sub check_but()
        If GVItem.RowCount > 0 Then
            BDelete.Visible = True
        Else
            BDelete.Visible = False
        End If
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        Dim newRow As DataRow = (TryCast(GCItem.DataSource, DataTable)).NewRow()

        TryCast(GCItem.DataSource, DataTable).Rows.Add(newRow)
        GCItem.RefreshDataSource()
        GVItem.RefreshData()

        check_but()
    End Sub
End Class