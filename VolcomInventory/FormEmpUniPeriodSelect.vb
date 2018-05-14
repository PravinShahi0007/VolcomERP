Public Class FormEmpUniPeriodSelect
    Public data As DataTable

    Private Sub FormEmpUniPeriodSelect_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormEmpUniPeriodSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GCUni.DataSource = data
    End Sub

    Sub choose()
        Cursor = Cursors.WaitCursor
        If GVUni.RowCount > 0 And GVUni.FocusedRowHandle >= 0 Then
            Dim id_periode As String = GVUni.GetFocusedRowCellValue("id_emp_uni_period").ToString
            FormEmpUniPeriodDet.MdiParent = FormMain
            FormEmpUniPeriodDet.action = "upd"
            FormEmpUniPeriodDet.id_emp_uni_period = id_periode
            Close()
            FormEmpUniPeriodDet.is_public_form = True
            FormEmpUniPeriodDet.Show()
            FormEmpUniPeriodDet.WindowState = FormWindowState.Maximized
            FormEmpUniPeriodDet.Focus()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnChoose_Click(sender As Object, e As EventArgs) Handles BtnChoose.Click
        choose()
    End Sub

    Private Sub GVUni_DoubleClick(sender As Object, e As EventArgs) Handles GVUni.DoubleClick
        choose()
    End Sub
End Class