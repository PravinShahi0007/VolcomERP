Public Class FormPopUpBOM 
    Public id_product As String = "-1"
    Private Sub FormPopUpBOM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_bom(id_product)
    End Sub
    Sub view_bom(ByVal id_product As String)
        Try
            Dim query As String
            query = "SELECT tb_lookup_report_status.id_report_status,tb_lookup_report_status.report_status,tb_bom.id_bom,tb_bom.bom_name,tb_bom.bom_unit_price,DATE_FORMAT(tb_bom.bom_date_created,'%d %M %Y') as bom_date_created,tb_lookup_term_production.term_production,IF(tb_bom.is_default='1','yes','no') as is_default,tb_lookup_currency.currency,tb_lookup_currency.id_currency FROM tb_bom,tb_lookup_report_status,tb_lookup_term_production,tb_lookup_currency WHERE tb_lookup_report_status.id_report_status=tb_bom.id_report_status AND tb_bom.id_term_production=tb_lookup_term_production.id_term_production AND tb_lookup_currency.id_currency=tb_bom.id_currency AND tb_bom.id_product = '" & id_product & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            GCBOM.DataSource = data
            If Not data.Rows.Count < 1 Then
                'show all
                BEditMat.Visible = True
                BDelMat.Visible = True
                BDefault.Visible = True

                view_bom_det(GVBOM.GetFocusedRowCellDisplayText("id_bom").ToString)
                view_bom_ovh(GVBOM.GetFocusedRowCellDisplayText("id_bom").ToString)
                view_bom_wip(GVBOM.GetFocusedRowCellDisplayText("id_bom").ToString)
            Else
                'hide all except add
                BEditMat.Visible = False
                BDelMat.Visible = False
                BDefault.Visible = False

                GCBomDetMat.DataSource = Nothing
                GCBomDetOvh.DataSource = Nothing
                GCBomDetWip.DataSource = Nothing
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Sub view_bom_det(ByVal id_bom As String)
        Try
            Dim query As String
            query = "CALL view_bom_mat(" & id_bom & ")"

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBomDetMat.DataSource = data
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Sub view_bom_ovh(ByVal id_bomx As String)
        Try
            Dim query As String
            query = "CALL view_bom_ovh(" & id_bomx & ")"

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBomDetOvh.DataSource = data
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Sub view_bom_wip(ByVal id_bomx As String)
        Try
            Dim query As String
            query = "CALL view_bom_product(" & id_bomx & ")"

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBomDetWip.DataSource = data
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    
    Private Sub GVBOM_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVBOM.RowClick
        view_bom_det(GVBOM.GetFocusedRowCellDisplayText("id_bom").ToString)
        view_bom_ovh(GVBOM.GetFocusedRowCellDisplayText("id_bom").ToString)
        view_bom_wip(GVBOM.GetFocusedRowCellDisplayText("id_bom").ToString)
    End Sub

    Private Sub BAddWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        If GVBOM.RowCount > 0 Then
            FormProductionDet.GVListProduct.SetFocusedRowCellValue("id_bom", GVBOM.GetFocusedRowCellValue("id_bom").ToString)
            FormProductionDet.GVListProduct.SetFocusedRowCellValue("bom_name", GVBOM.GetFocusedRowCellValue("bom_name").ToString)
            Close()
        End If
    End Sub

    Private Sub BEditWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormPopUpBOM_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BEditMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditMat.Click
        FormBOMSingle.id_bom = GVBOM.GetFocusedRowCellDisplayText("id_bom").ToString
        FormBOMSingle.id_product = id_product
        FormBOMSingle.ShowDialog()
    End Sub

    Private Sub BAddMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAddMat.Click
        FormBOMSingle.id_bom = "-1"
        FormBOMSingle.id_product = id_product
    End Sub

    Private Sub BDelMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelMat.Click
        Dim confirm As DialogResult
        Dim query As String

        If check_edit_report_status(GVBOM.GetFocusedRowCellDisplayText("id_report_status"), "8", GVBOM.GetFocusedRowCellDisplayText("id_bom")) Then
            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this BOM ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            Dim id_bom As String = GVBOM.GetFocusedRowCellDisplayText("id_bom").ToString

            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    query = String.Format("DELETE FROM tb_bom WHERE id_bom = '{0}'", id_bom)
                    execute_non_query(query, True, "", "", "", "")

                    'del mark
                    delete_all_mark_related("8", id_bom)

                    view_bom(id_product)
                Catch ex As Exception
                    errorDelete()
                End Try
                Cursor = Cursors.Default
            End If
        Else
            stopCustom("BOM already processed.")
        End If
    End Sub

    Private Sub BRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefresh.Click
        view_bom(id_product)
    End Sub

    Private Sub BDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDefault.Click
        Dim confirm As DialogResult
        Dim query As String

        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to make this BOM as default for this porduct ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                Dim id_bom As String = GVBOM.GetFocusedRowCellValue("id_bom").ToString
                query = String.Format("UPDATE tb_bom SET is_default='2' WHERE id_product = '{0}';UPDATE tb_bom SET is_default='1' WHERE id_bom = '{1}'", id_product, id_bom)
                execute_non_query(query, True, "", "", "", "")
                view_bom(id_product)
                GVBOM.FocusedRowHandle = find_row(GVBOM, "id_bom", id_bom)
                infoCustom("BOM updated.")
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show("Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub
End Class