Public Class ReportEmpPayrollReportAllDepartement
    Public type As String = ""
    Public id_payroll As String = ""
    Public id_pre As String
    Public data As DataTable
    Public data_office As DataTable
    Public data_store As DataTable

    Private Sub ReportEmpPayrollReportAllDepartement_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'office
        GVSummaryOffice.Columns("event_overtime").Caption = "Overtime" + Environment.NewLine + "Event"
        GVSummaryOffice.Columns("d_cooperative_loan").Caption = "Cooperative" + Environment.NewLine + "Loan"
        GVSummaryOffice.Columns("d_bpjskes").Caption = "BPJS" + Environment.NewLine + "Kesehatan"
        GVSummaryOffice.Columns("d_jaminan_pensiun").Caption = "JP" + Environment.NewLine + "Contribution"
        GVSummaryOffice.Columns("d_cooperative_contribution").Caption = "Cooperative" + Environment.NewLine + "Contribution"
        GVSummaryOffice.Columns("d_missing").Caption = "Saving" + Environment.NewLine + "Missing"
        GVSummaryOffice.Columns("d_meditation_cash").Caption = "Meditation" + Environment.NewLine + "/ Cash Receipt"

        GCSummaryOffice.DataSource = data_office

        'store
        GVSummaryStore.Columns("event_overtime").Caption = "Overtime" + Environment.NewLine + "Event"
        GVSummaryStore.Columns("d_cooperative_loan").Caption = "Cooperative" + Environment.NewLine + "Loan"
        GVSummaryStore.Columns("d_bpjskes").Caption = "BPJS" + Environment.NewLine + "Kesehatan"
        GVSummaryStore.Columns("d_jaminan_pensiun").Caption = "JP" + Environment.NewLine + "Contribution"
        GVSummaryStore.Columns("d_cooperative_contribution").Caption = "Cooperative" + Environment.NewLine + "Contribution"
        GVSummaryStore.Columns("d_missing").Caption = "Saving" + Environment.NewLine + "Missing"
        GVSummaryStore.Columns("d_meditation_cash").Caption = "Meditation" + Environment.NewLine + "/ Cash Receipt"

        GCSummaryStore.DataSource = data_store

        'all
        GCSummaryAll.DataSource = data

        GVSummaryAll.Columns("volcom_indonesia").Caption = "VOLCOM INDONESIA" + Environment.NewLine + "(VCIN)"
        GVSummaryAll.Columns("bemo_corner").Caption = "BEMO CORNER" + Environment.NewLine + "(VCOM)"
        GVSummaryAll.Columns("kuta_square").Caption = "KUTA SQUARE" + Environment.NewLine + "(VOCM)"
        GVSummaryAll.Columns("seminyak").Caption = "SEMINYAK" + Environment.NewLine + "(PTVI)"

        'mark
        If id_pre = "-1" Then
            load_mark_horz("192", id_payroll, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("192", id_payroll, "2", "2", XrTable1)
        End If
    End Sub
End Class