Public Class FormMasterEmployeeNomorSurat
    Private Sub FormMasterEmployeeNomorSurat_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        Dim month As String = execute_query("SELECT `code` FROM `tb_ot_memo_number_mon` WHERE `month` = MONTH(NOW())", 0, True, "", "", "", "")

        Dim Report As New ReportMasterEmployeeSuratKeteranganPenangguhanBank()

        Report.XLNumber.Text = Report.XLNumber.Text.Replace("[number]", TENumber.Text + "/EXT/HRD-SK/" + month + "/" + Date.Now.ToString("yy"))

        Report.XLText.Text = Report.XLText.Text.Replace("[employee_name]", FormMasterEmployee.GVEmployee.GetFocusedRowCellDisplayText("employee_name"))
        Report.XLText.Text = Report.XLText.Text.Replace("[employee_code]", FormMasterEmployee.GVEmployee.GetFocusedRowCellDisplayText("employee_code"))
        Report.XLText.Text = Report.XLText.Text.Replace("[employee_pob_dob]", FormMasterEmployee.GVEmployee.GetFocusedRowCellDisplayText("employee_pob") + " " + FormMasterEmployee.GVEmployee.GetFocusedRowCellDisplayText("employee_dob"))
        Report.XLText.Text = Report.XLText.Text.Replace("[address_primary]", FormMasterEmployee.GVEmployee.GetFocusedRowCellDisplayText("address_primary"))
        Report.XLText.Text = Report.XLText.Text.Replace("[date]", Date.Now.ToString("dd MMMM yyyy"))

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
    End Sub

    Private Sub FormMasterEmployeeNomorSurat_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class