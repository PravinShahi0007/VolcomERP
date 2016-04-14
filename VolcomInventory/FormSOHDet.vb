Public Class FormSOHDet 
    Public id_soh As String = "-1"
    Public id_comp_contact As String = "-1"

    Private Sub FormSOHDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus()
        action_load()
    End Sub
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_status_soh a ORDER BY a.id_status_soh "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEStatus, query, 0, "status_soh", "id_status_soh")
    End Sub
    Sub action_load()
        view_periode()
        '
        If Not id_soh = "-1" Then 'edit
            Dim query As String = ""
            query = "SELECT a.id_soh_periode,a.id_comp_contact,d.comp_name,d.comp_number,c.comp_group,a.date_created,a.date_updated,a.id_status_soh FROM tb_soh a "
            query += " INNER JOIN tb_m_comp_contact b ON a.id_comp_contact=b.id_comp_contact"
            query += " INNER JOIN tb_m_comp d ON d.id_comp=b.id_comp "
            query += " INNER JOIN tb_m_comp_group c ON c.id_comp_group=d.id_comp_group"
            query += " WHERE id_soh='" + id_soh + "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TECompCode.Text = data.Rows(0)("comp_number").ToString
            TECompName.Text = data.Rows(0)("comp_name").ToString
            TECompGroup.Text = data.Rows(0)("comp_group").ToString
            id_comp_contact = data.Rows(0)("id_comp_contact").ToString

            LEStatus.ItemIndex = LEStatus.Properties.GetDataSourceRowIndex("id_status_soh", data.Rows(0)("id_status_soh").ToString)

            TECreated.EditValue = data.Rows(0)("date_created")
            TELastUpdate.EditValue = data.Rows(0)("date_updated")

            SLEPeriode.EditValue = data.Rows(0)("id_soh_periode").ToString

            SLEPeriode.Enabled = False
            GroupControlReq.Enabled = True
            load_self()
            load_store()
            load_sum()
        Else
            GroupControlReq.Enabled = False
        End If
    End Sub
    Private Sub BImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BImport.Click
        FormImportExcel.id_pop_up = "3"
        FormImportExcel.ShowDialog()
    End Sub
    Sub load_sum()
        Dim query As String = "CALL view_soh_load_sum('" + id_soh + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSummary.DataSource = data
        If data.Rows.Count > 0 Then
            GVSummary.BestFitColumns()
        End If
    End Sub
    Sub load_self()
        Dim query As String = "CALL view_soh_load_self('" + id_soh + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSelf.DataSource = data
        If data.Rows.Count > 0 Then
            BEmpty.Visible = True
        Else
            BEmpty.Visible = False
        End If
    End Sub

    Sub load_store()
        Dim query As String = "CALL view_soh_load_store('" + id_soh + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCStore.DataSource = data
        If data.Rows.Count > 0 Then
            BEmptyStore.Visible = True
        Else
            BEmptyStore.Visible = False
        End If
    End Sub

    Sub load_diff()
        Dim query As String = "SELECT * FROM tb_soh_periode"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSummary.DataSource = data
    End Sub

    Private Sub GVSelf_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSelf.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BPickContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickContact.Click
        FormPopUpContact.id_pop_up = "56"
        FormPopUpContact.ShowDialog()
    End Sub

    Sub view_periode()
        Dim query As String = "SELECT id_soh_periode,soh_periode,date_start,date_end FROM tb_soh_periode ORDER BY id_soh_periode DESC "
        viewSearchLookupQuery(SLEPeriode, query, "id_soh_periode", "soh_periode", "id_soh_periode")
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim query As String = ""

        If id_soh = "-1" Then 'new
            query = "INSERT INTO tb_soh(id_soh_periode,id_comp_contact,id_status_soh,date_created,date_updated) "
            query += "VALUES('" + SLEPeriode.EditValue.ToString + "','" + id_comp_contact + "','1',NOW(),NOW());SELECT LAST_INSERT_ID() "
            id_soh = execute_query(query, 0, True, "", "", "", "")
            infoCustom("SOH created.")
            FormSOH.view_soh_periode(SLEPeriode.EditValue)
            FormSOH.BGVSOH.FocusedRowHandle = find_row(FormSOH.BGVSOH, "id_soh", id_soh)
            action_load()
        Else 'edit
            query = "UPDATE tb_soh SET id_soh_periode='" + SLEPeriode.EditValue.ToString + "',id_comp_contact='" + id_comp_contact + "',date_updated=NOW(),id_status_soh='" + LEStatus.EditValue.ToString + "'  WHERE id_soh='" + id_soh + "'"
            execute_non_query(query, True, "", "", "", "")
            infoCustom("SOH updated.")
            FormSOH.view_soh_periode(SLEPeriode.EditValue)
            FormSOH.BGVSOH.FocusedRowHandle = find_row(FormSOH.BGVSOH, "id_soh", id_soh)
            action_load()
        End If
    End Sub

    Private Sub BImportStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BImportStore.Click
        FormImportExcel.id_pop_up = "4"
        FormImportExcel.ShowDialog()
    End Sub

    Private Sub GVStore_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVStore.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVSummary_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSummary.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefresh.Click
        load_sum()
    End Sub

    Private Sub BEmpty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEmpty.Click
        Dim confirm As DialogResult
        Dim query As String

        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to empty the list ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                query = String.Format("DELETE FROM tb_soh_on_hand WHERE id_soh = '{0}'", id_soh)
                execute_non_query(query, True, "", "", "", "")
                load_self()
            Catch ex As Exception
                errorDelete()
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BEmptyStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEmptyStore.Click
        Dim confirm As DialogResult
        Dim query As String

        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to empty the list ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                query = String.Format("DELETE FROM tb_soh_store WHERE id_soh = '{0}'", id_soh)
                execute_non_query(query, True, "", "", "", "")
                load_store()
            Catch ex As Exception
                errorDelete()
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        print(GCSummary, TECompCode.Text + "-" + TECompName.Text + "-" + SLEPeriode.Text + "-" + "Summary")
    End Sub

    Private Sub FormSOHDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub BOHPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOHPrint.Click
        print(GCSelf, TECompCode.Text + "-" + TECompName.Text + "-" + SLEPeriode.Text + "-" + "SOH Volcom")
    End Sub

    Private Sub BStPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BStPrint.Click
        print(GCStore, TECompCode.Text + "-" + TECompName.Text + "-" + SLEPeriode.Text + "-" + "SOH Store")
    End Sub
End Class