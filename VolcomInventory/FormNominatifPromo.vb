Public Class FormNominatifPromo
    Private Sub FormNominatifPromo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim year_from As Integer = 2019
        Dim year_to As Integer = Integer.Parse(execute_query("SELECT YEAR(NOW())", 0, True, "", "", "", ""))

        Dim query As String = ""

        For i = year_from To year_to
            query += "SELECT " + i.ToString + " AS `year` UNION ALL "
        Next

        query = query.Substring(0, query.Length - 11)

        viewSearchLookupQuery(SLUEYear, query, "year", "year", "year")
    End Sub

    Private Sub FormNominatifPromo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormNominatifPromo_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormNominatifPromo_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        form_load()
    End Sub

    Sub form_load()
        Dim query As String = "CALL view_daftar_nominatif(" + SLUEYear.EditValue.ToString + ")"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            data.Rows(i)("no") = i + 1
        Next

        GCDaftar.DataSource = data

        BGVDaftar.BestFitColumns()
    End Sub

    Sub form_print()
        Dim report As New ReportNominatifPromo()

        report.XLYear.Text = SLUEYear.EditValue.ToString

        report.GCDaftar.DataSource = GCDaftar.DataSource

        report.BGVDaftar.BestFitColumns()

        Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        tool.ShowPreviewDialog()
    End Sub
End Class