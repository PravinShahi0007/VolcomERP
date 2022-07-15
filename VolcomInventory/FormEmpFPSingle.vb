Public Class FormEmpFPSingle


    Private Sub FormEmpFPSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormEmpFPSingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to upload finger template from database?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim fp As New ClassFingerPrint()
            fp.ip = FormEmpFP.GVFP.GetFocusedRowCellValue("ip").ToString
            fp.port = FormEmpFP.GVFP.GetFocusedRowCellValue("port").ToString
            fp.upload_fp_temp_single(addSlashes(TextEdit1.Text))
            fp.upload_face_temp_single(addSlashes(TextEdit1.Text))
            infoCustom("Process completed")
            Close()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim f As New ClassFingerPrint
        f.ip = FormEmpFP.GVFP.GetFocusedRowCellValue("ip").ToString
        f.port = FormEmpFP.GVFP.GetFocusedRowCellValue("port").ToString
        f.connect()
        f.deleteUserInfo(addSlashes(TextEdit1.Text))
        f.disconnect()
        infoCustom("Process completed")
        Close()
    End Sub

    Private Sub BLoad_Click(sender As Object, e As EventArgs) Handles BLoad.Click
        Dim q As String = "SELECT fp.nip,emp.employee_name,a.employee_active FROM tb_fp_bulk fp
INNER JOIN tb_m_employee emp ON emp.employee_code=fp.nip
INNER JOIN tb_lookup_employee_active a ON a.id_employee_active=emp.id_employee_active"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCClaim.DataSource = dt
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles BDelBulk.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete finger template from machine?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            For i = 0 To GVClaim.RowCount - 1
                Dim f As New ClassFingerPrint
                f.ip = FormEmpFP.GVFP.GetFocusedRowCellValue("ip").ToString
                f.port = FormEmpFP.GVFP.GetFocusedRowCellValue("port").ToString
                f.connect()
                f.deleteUserInfo(addSlashes(GVClaim.GetRowCellValue(i, "nip").ToString))
                f.disconnect()
            Next
            infoCustom("Process completed")
            Close()
        End If
    End Sub

    Private Sub BAddBulk_Click(sender As Object, e As EventArgs) Handles BAddBulk.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to upload finger template from database?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            For i = 0 To GVClaim.RowCount - 1
                Dim fp As New ClassFingerPrint()
                fp.ip = FormEmpFP.GVFP.GetFocusedRowCellValue("ip").ToString
                fp.port = FormEmpFP.GVFP.GetFocusedRowCellValue("port").ToString
                fp.upload_fp_temp_single(addSlashes(TextEdit1.Text))
                fp.upload_face_temp_single(addSlashes(TextEdit1.Text))
            Next
            infoCustom("Process completed")
            Close()
            Cursor = Cursors.Default
        End If
    End Sub
End Class