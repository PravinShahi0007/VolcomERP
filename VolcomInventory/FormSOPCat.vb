Public Class FormSOPCat
    Dim id_departement As String = "-1"
    Public id_dep_view As String = "-1"

    Private Sub FormSOPCat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_departement()
        If Not id_dep_view = "-1" Then
            SLEDepartement.EditValue = id_dep_view
            view()
        End If
    End Sub

    Sub load_departement()
        Dim q As String = "SELECT id_departement,departement FROM tb_m_departement"
        viewSearchLookupQuery(SLEDepartement, q, "id_departement", "departement", "id_departement")
    End Sub

    Private Sub Bview_Click(sender As Object, e As EventArgs) Handles Bview.Click
        view()
    End Sub

    Sub view()
        load_prosedur()

        PCAddMasterProsedur.Visible = True
        load_second_page()

        id_departement = SLEDepartement.EditValue.ToString
    End Sub

    Sub load_second_page()
        If GVProsedur.RowCount > 0 Then
            XTPSubProsedur.PageVisible = True
            TESKodeProsedur.Text = GVProsedur.GetFocusedRowCellValue("sop_prosedur_code").ToString
            TESProsedur.Text = GVProsedur.GetFocusedRowCellValue("sop_prosedur").ToString
        Else
            XTPSubProsedur.PageVisible = False
            TESKodeProsedur.Text = ""
            TESProsedur.Text = ""
        End If
    End Sub

    Sub load_prosedur()
        Dim q As String = "SELECT id_sop_prosedur,sop_prosedur,sop_prosedur_code,IF(is_active=1,'Active','Not Active') AS sts
FROM `tb_sop_prosedur`
WHERE id_departement='" & SLEDepartement.EditValue.ToString & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCProsedur.DataSource = dt
        GVProsedur.BestFitColumns()
    End Sub

    Private Sub BAddProsedur_Click(sender As Object, e As EventArgs) Handles BAddProsedur.Click
        If Not TEKodeProsedur.Text = "" And Not TEProsedur.Text = "" And Not id_departement = "-1" Then
            'check first
            Dim q As String = "SELECT * FROM tb_sop_prosedur WHERE (sop_prosedur_code='" & addSlashes(TEKodeProsedur.Text) & "' OR sop_prosedur='" & addSlashes(TEProsedur.Text) & "') AND id_departement='" & id_departement & "' "
            Dim dtc As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dtc.Rows.Count > 0 Then
                warningCustom("Kode/ nama SOP prosedur sudah pernah digunakan.")
            Else
                q = "INSERT INTO tb_sop_prosedur(sop_prosedur_code,sop_prosedur,id_departement) VALUES('" & addSlashes(TEKodeProsedur.Text) & "','" & addSlashes(TEProsedur.Text) & "','" & id_departement & "')"
                execute_non_query(q, True, "", "", "", "")
                '
                TEKodeProsedur.Text = ""
                TEProsedur.Text = ""

                load_prosedur()
            End If
        Else
            warningCustom("Tolong lengkapi isian dengan benar.")
        End If
    End Sub

    Sub load_prosedur_sub()
        Dim q As String = "SELECT id_sop_prosedur_sub,sop_prosedur_sub,sop_prosedur_sub_code,IF(is_active=1,'Active','Not Active') AS sts
FROM `tb_sop_prosedur_sub`
WHERE id_sop_prosedur='" & GVProsedur.GetFocusedRowCellValue("id_sop_prosedur").ToString & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCSubProsedur.DataSource = dt
        GVSubProsedur.BestFitColumns()
    End Sub

    Private Sub BAddSubProsedur_Click(sender As Object, e As EventArgs) Handles BAddSubProsedur.Click
        If Not TEKodeSub.Text = "" And Not TESub.Text = "" And Not GVProsedur.RowCount = 0 Then
            'check first
            Dim q As String = "SELECT * FROM tb_sop_prosedur_sub WHERE (sop_prosedur_sub_code='" & addSlashes(TEKodeSub.Text) & "' OR sop_prosedur_sub='" & addSlashes(TESub.Text) & "') AND id_sop_prosedur='" & GVProsedur.GetFocusedRowCellValue("id_sop_prosedur").ToString & "' "
            Dim dtc As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dtc.Rows.Count > 0 Then
                warningCustom("Kode/ nama SOP sub prosedur sudah pernah digunakan.")
            Else
                q = "INSERT INTO tb_sop_prosedur_sub(sop_prosedur_sub_code,sop_prosedur_sub,id_sop_prosedur) VALUES('" & addSlashes(TEKodeSub.Text) & "','" & addSlashes(TESub.Text) & "','" & GVProsedur.GetFocusedRowCellValue("id_sop_prosedur").ToString & "')"
                execute_non_query(q, True, "", "", "", "")
                '
                TEKodeSub.Text = ""
                TESub.Text = ""

                load_prosedur_sub()
            End If
        Else
            warningCustom("Tolong lengkapi isian dengan benar.")
        End If
    End Sub

    Private Sub BRefresSubSOP_Click(sender As Object, e As EventArgs) Handles BRefresSubSOP.Click
        load_prosedur_sub()
    End Sub

    Private Sub GVProsedur_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProsedur.FocusedRowChanged
        load_second_page()
    End Sub

    Private Sub FormSOPCat_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        If GVSubProsedur.RowCount > 0 Then
            'check
            Dim q As String = "(SELECT id_sop_prosedur_sub FROM tb_sop_pps_det WHERE id_sop_prosedur_sub='" & GVSubProsedur.GetFocusedRowCellValue("id_sop_prosedur_sub").ToString & "')
UNION ALL
(SELECT id_sop_prosedur_sub FROM tb_sop WHERE id_sop_prosedur_sub='" & GVSubProsedur.GetFocusedRowCellValue("id_sop_prosedur_sub").ToString & "')"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                warningCustom("This sub prosedur / subject already used")
            Else
                execute_non_query("DELETE FROM tb_sop_prosedur_sub WHERE id_sop_prosedur_sub='" & GVSubProsedur.GetFocusedRowCellValue("id_sop_prosedur_sub").ToString & "'", True, "", "", "", "")
                load_prosedur_sub()
            End If
        Else
            warningCustom("No data found")
        End If
    End Sub

    Private Sub DeleteModulToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteModulToolStripMenuItem.Click
        If GVProsedur.RowCount > 0 Then
            'check
            Dim q As String = "SELECT id_sop_prosedur FROM tb_sop_prosedur_sub WHERE id_sop_prosedur='" & GVProsedur.GetFocusedRowCellValue("id_sop_prosedur").ToString & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                warningCustom("This prosedur already used, please delete all sub prosedur / subject.")
            Else
                execute_non_query("DELETE FROM tb_sop_prosedur WHERE id_sop_prosedur='" & GVProsedur.GetFocusedRowCellValue("id_sop_prosedur").ToString & "'", True, "", "", "", "")
                view()
            End If
        Else
            warningCustom("No data found")
        End If
    End Sub

    Private Sub XTCCat_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCCat.SelectedPageChanged
        If XTCCat.SelectedTabPageIndex = 1 Then
            load_prosedur_sub()
        End If
    End Sub
End Class