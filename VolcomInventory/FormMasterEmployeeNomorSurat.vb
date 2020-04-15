Public Class FormMasterEmployeeNomorSurat
    Private Sub FormMasterEmployeeNomorSurat_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        Dim month As String = execute_query("SELECT `code` FROM `tb_ot_memo_number_mon` WHERE `month` = MONTH(NOW())", 0, True, "", "", "", "")

        Dim Report As New ReportMasterEmployeeSuratKeteranganPenangguhanBank()

        Report.XLNumber.Text = Report.XLNumber.Text.Replace("[number]", TENumber.Text + "/EXT/HRD-SK/" + month + "/" + Date.Now.ToString("yy"))

        If FormMasterEmployee.GVEmployee.GetFocusedRowCellValue("id_employee").ToString = "132" Then
            Report.L_hrd_employee_name1.Text = "Marissa Bridgitt Kasih"
            Report.L_hrd_employee_position1.Text = "Director"

            Report.L_hrd_employee_name2.Text = "Marissa Bridgitt Kasih"
            Report.L_hrd_employee_position2.Text = "Director"
        Else
            Report.L_hrd_employee_name1.Text = "Johannes Paulus Lazarus Handoko"
            Report.L_hrd_employee_position1.Text = "HR & Compliance Manager"

            Report.L_hrd_employee_name2.Text = "Johannes Paulus Lazarus Handoko"
            Report.L_hrd_employee_position2.Text = "HR & Compliance Manager"
        End If
        Report.L_employee_name.Text = FormMasterEmployee.GVEmployee.GetFocusedRowCellDisplayText("employee_name")
        Report.L_employee_code.Text = FormMasterEmployee.GVEmployee.GetFocusedRowCellDisplayText("employee_code")
        Report.L_address_primary.Text = FormMasterEmployee.GVEmployee.GetFocusedRowCellDisplayText("address_primary")
        Report.L_date.Text = "Kuta, " + Date.Now.ToString("dd MMMM yyyy")

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
    End Sub

    Private Sub FormMasterEmployeeNomorSurat_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class