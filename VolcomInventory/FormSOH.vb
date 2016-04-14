Public Class FormSOH 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Private Sub FormSOH_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'view_soh()
        view_soh_periode(LESOHPeriode)
    End Sub
    Sub view_soh_periode(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT id_soh_periode,soh_periode FROM tb_soh_periode ORDER BY id_soh_periode DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "soh_periode"
        lookup.Properties.ValueMember = "id_soh_periode"
        lookup.EditValue = data.Rows(0)("id_soh_periode").ToString
    End Sub
    Sub view_soh()
        Dim query As String = "CALL view_soh_all()"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSOH.DataSource = data
        If data.Rows.Count > 0 Then
            'show all
            BGVSOH.BestFitColumns()
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
        Else
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub
    Sub view_soh_periode(ByVal id_periode As String)
        Dim query As String = "CALL view_soh_all_periode(" & id_periode & ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSOH.DataSource = data
        If data.Rows.Count > 0 Then
            'show all
            BGVSOH.BestFitColumns()
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
        Else
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub
    Private Sub FormSOH_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormSOH_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub DDBPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DDBPrint.Click
        Cursor = Cursors.WaitCursor
        view_soh_periode(LESOHPeriode.EditValue)
        Cursor = Cursors.Default
    End Sub
End Class