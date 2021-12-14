﻿Public Class FormItemReq
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Public is_for_store As String = "2"
    Public is_for_purchasing As String = "2"

    Private Sub FormItemReq_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_dep()
        viewData()
    End Sub

    Sub load_dep()
        Dim query As String = ""
        Dim can_all_dep As String = get_opt_purchasing_field("is_can_all_dep")

        If can_all_dep = "1" Or is_for_purchasing = "1" Then
            query = "SELECT '0' AS id_departement,'ALL' AS departement 
                    UNION
                    SELECT dep.id_departement,dep.departement FROM tb_m_departement dep"

            If is_for_store = "1" Then
                query += " WHERE dep.id_coa_tag=1 "
            End If
        Else
            query = "SELECT dep.id_departement,dep.departement FROM tb_m_departement dep WHERE dep.id_departement='" & id_departement_user & "'"
            query += " UNION ALL "
            query += " SELECT dep.`id_departement`,dep.`departement`
FROM `tb_purc_req_extra_dep` ext 
INNER JOIN tb_m_departement dep ON dep.`id_departement`=ext.`id_departement`
WHERE ext.id_user='" & id_user & "' "
            If is_for_store = "1" Then
                query += " AND dep.id_coa_tag=1 "
            End If
        End If

        viewSearchLookupQuery(SLEDepartement, query, "id_departement", "departement", "id_departement")
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim ir As New ClassItemRequest()
        Dim cond As String = ""
        If SLEDepartement.EditValue.ToString = "0" Then
            cond = " AND r.is_for_store='" + is_for_store + "' "
        Else
            cond = "AND r.id_departement=" + SLEDepartement.EditValue.ToString + " AND r.is_for_store='" + is_for_store + "' "
        End If
        Dim query As String = ir.queryMain(cond, "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        check_menu()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormItemReq_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormItemReq_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormItemReq_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If GVData.RowCount < 1 Then
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Else
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "0"
            noManipulating()
        End If
    End Sub

    Sub noManipulating()
        Try
            Dim indeks As Integer = 0
            indeks = GVData.FocusedRowHandle
            If indeks < 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "0"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GVData_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVData.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        openDetail()
    End Sub

    Sub openDetail()
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormMain.but_edit()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ViewDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailToolStripMenuItem.Click
        openDetail()
    End Sub

    Private Sub ViewProgressToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewProgressToolStripMenuItem.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormItemDelReqDet.is_view = "1"
            FormItemDelReqDet.is_for_store = is_for_store
            FormItemDelReqDet.id = GVData.GetFocusedRowCellValue("id_item_req").ToString
            FormItemDelReqDet.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        viewData()
    End Sub
End Class