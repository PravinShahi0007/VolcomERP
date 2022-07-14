Public Class FormMasterComputer
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormMasterComputer_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormMasterComputer_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If GVComputer.RowCount < 1 Then
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
            bdel_active = "1"
            noManipulating()
        End If
    End Sub

    Sub noManipulating()
        Try
            Dim indeks As Integer = GVComputer.FocusedRowHandle
            If indeks < 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FormMasterComputer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewComputer()
        dtassetcomp()

    End Sub

    Sub viewComputer()
        Dim query As String = "SELECT * FROM tb_m_computer ORDER BY id_computer ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCComputer.DataSource = data
        check_menu()
    End Sub

    Private Sub GVComputer_DoubleClick(sender As Object, e As EventArgs)
        If GVComputer.RowCount > 0 And GVComputer.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub
    Sub dtassetcomp()
        Dim query As String = "SELECT pra.id_purc_rec_asset,pra.asset_number,pra.asset_name,pra.acq_date,pra.location_current,me.employee_name
FROM tb_purc_rec_asset pra
LEFT JOIN tb_m_employee me ON pra.id_employee_current=me.id_employee
WHERE pra.id_acc_fa='799'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCdakomp.DataSource = data

    End Sub

    Private Sub BTrefresh_Click(sender As Object, e As EventArgs) Handles BTrefresh.Click
        dtassetcomp()
    End Sub

    Private Sub GCdtlkomp_Click(sender As Object, e As EventArgs) Handles GCdtlkomp.Click

    End Sub
    Sub loadmtc()
        Dim id_purc_rec_asset As String = GVdakomp.GetFocusedRowCellValue("id_purc_rec_asset").ToString

        Dim query As String = "SELECT dmi.id_det_mtc,dmi.id_purc_rec_asset,dmi.date_mtc,me.employee_name,dmi.problem,dmi.dtl_problem,smi.status_mtc,me2.employee_name as `pic_name`,dmi.status_delete
FROM tb_det_mtc_it dmi
LEFT JOIN tb_m_employee me ON dmi.now_user = me.id_employee
LEFT JOIN tb_m_employee me2 ON dmi.pic = me2.id_employee
LEFT JOIN tb_status_mtc_it smi ON dmi.id_status_mtc = smi.id_status_mtc
WHERE dmi.id_purc_rec_asset = '" & id_purc_rec_asset & "' AND dmi.status_delete IS NULL ORDER BY dmi.date_mtc DESC "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCdtlkomp.DataSource = data

    End Sub
    Private Sub BTadd_Click(sender As Object, e As EventArgs) Handles BTadd.Click

        FormMasterComputerMtc.id_purc_rec_asset = GVdakomp.GetFocusedRowCellValue("id_purc_rec_asset").ToString
        FormMasterComputerMtc.hw_name = GVdakomp.GetFocusedRowCellValue("asset_name").ToString
        FormMasterComputerMtc.Action = "ins"
        FormMasterComputerMtc.ShowDialog()

    End Sub

    Private Sub BTedit_Click(sender As Object, e As EventArgs) Handles BTedit.Click
        If GVdtlkomp.RowCount = 0 Then
            stopCustom("Tidak ada data perbaikan!")
        Else
            FormMasterComputerMtc.id_det_mtc = GVdtlkomp.GetFocusedRowCellValue("id_det_mtc").ToString
            FormMasterComputerMtc.Action = "edit"
            FormMasterComputerMtc.ShowDialog()
        End If
    End Sub

    Private Sub BTdelete_Click(sender As Object, e As EventArgs) Handles BTdelete.Click
        If GVdtlkomp.RowCount = 0 Then
            stopCustom("Tidak ada data perbaikan!")
        Else
            Dim confirm As DialogResult
            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim id_det_mtc As String = GVdtlkomp.GetFocusedRowCellValue("id_det_mtc").ToString
                Dim query As String = "UPDATE tb_det_mtc_it SET status_delete = 'delete' WHERE id_det_mtc = '" & id_det_mtc & "'"
                execute_non_query(query, True, "", "", "", "")
                MessageBox.Show("Data telah dihapus!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                loadmtc()
            End If
        End If
    End Sub
    Sub loadlist()
        Dim query As String = "SELECT dmi.id_det_mtc,dmi.hw_name,pra.asset_number,dmi.date_mtc,me.employee_name as `user_now`,dmi.problem,dmi.dtl_problem,smi.status_mtc,me2.employee_name as `pic_name`,dmi.status_delete
FROM tb_det_mtc_it dmi
LEFT JOIN tb_purc_rec_asset pra ON dmi.id_purc_rec_asset = pra.id_purc_rec_asset
LEFT JOIN tb_m_employee me ON dmi.now_user = me.id_employee
LEFT JOIN tb_m_employee me2 ON dmi.pic = me2.id_employee
LEFT JOIN tb_status_mtc_it smi ON dmi.id_status_mtc = smi.id_status_mtc
WHERE dmi.status_delete IS NULL ORDER BY dmi.date_mtc DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GClistmtc.DataSource = data
    End Sub

    Private Sub BTrefreshlist_Click(sender As Object, e As EventArgs) Handles BTrefreshlist.Click
        loadlist()

    End Sub

    Private Sub BTeditlist_Click(sender As Object, e As EventArgs) Handles BTeditlist.Click
        If GVlistmtc.RowCount = 0 Then
            stopCustom("Tidak ada data perbaikan!")
        Else
            FormMasterComputerMtc.id_det_mtc = GVlistmtc.GetFocusedRowCellValue("id_det_mtc").ToString
            FormMasterComputerMtc.Action = "edit"
            FormMasterComputerMtc.ShowDialog()
        End If
    End Sub

    Private Sub BTdeletelist_Click(sender As Object, e As EventArgs) Handles BTdeletelist.Click
        If GVlistmtc.RowCount = 0 Then
            stopCustom("Tidak ada data perbaikan!")
        Else
            Dim confirm As DialogResult
            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim id_det_mtc As String = GVlistmtc.GetFocusedRowCellValue("id_det_mtc").ToString
                Dim query As String = "UPDATE tb_det_mtc_it SET status_delete = 'delete' WHERE id_det_mtc = '" & id_det_mtc & "'"
                execute_non_query(query, True, "", "", "", "")
                MessageBox.Show("Data telah dihapus!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                loadmtc()
                loadlist()

            End If
        End If
    End Sub

    Private Sub BTaddnonaset_Click(sender As Object, e As EventArgs) Handles BTaddnonaset.Click
        FormMasterComputerMtc.Action = "ins"
        FormMasterComputerMtc.ShowDialog()
    End Sub

    Private Sub BTprintmtc_Click(sender As Object, e As EventArgs) Handles BTprintmtc.Click
        print(Me.GClistmtc, "List Maintenance Hardware IT")
    End Sub

    Private Sub GClistmtc_DoubleClick(sender As Object, e As EventArgs) Handles GClistmtc.DoubleClick

        Dim asset_number As String = GVlistmtc.GetFocusedRowCellValue("asset_number").ToString

        Dim query As String = "SELECT pra.id_purc_rec_asset,pra.asset_number,pra.asset_name,pra.acq_date,pra.location_current,me.employee_name
FROM tb_purc_rec_asset pra
LEFT JOIN tb_m_employee me ON pra.id_employee_current=me.id_employee
WHERE pra.id_acc_fa='799' AND pra.asset_number = '" & asset_number & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCdakomp.DataSource = data
        loadmtc()
        XtraTabControl1.SelectedTabPage = XtraTabPage2
    End Sub

    Private Sub GCdakomp_Click(sender As Object, e As EventArgs) Handles GCdakomp.Click
        loadmtc()
    End Sub
End Class