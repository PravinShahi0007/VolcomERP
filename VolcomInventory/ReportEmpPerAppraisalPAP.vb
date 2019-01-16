Public Class ReportEmpPerAppraisalPAP
    Public Shared dt_conclusion As DataTable

    Private Sub ReportEmpPerAppraisalPAP_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim y As Integer = 0

        'Komentar
        For i = 0 To dt_conclusion.Rows.Count - 1
            'Number
            Dim tb_n As New DevExpress.XtraReports.UI.XRLabel

            tb_n.Text = (i + 1).ToString + "."
            tb_n.SizeF = New Size(20, 20)
            tb_n.LocationF = New Point(0, y)
            tb_n.Font = New Font("Arial", 10)

            Me.XPConclusion.Controls.Add(tb_n)

            'Question
            Dim tb_q As New DevExpress.XtraReports.UI.XRLabel

            tb_q.Text = dt_conclusion.Rows(i)("question")
            tb_q.SizeF = New Size(730, 20)
            tb_q.LocationF = New Point(20, y)
            tb_q.Font = New Font("Arial", 10)

            Me.XPConclusion.Controls.Add(tb_q)

            y = y + 20

            'Conclusion
            Dim tb_c As New DevExpress.XtraReports.UI.XRLabel

            tb_c.Text = dt_conclusion.Rows(i)("conclusion")
            tb_c.SizeF = New Size(730, 20)
            tb_c.LocationF = New Point(20, y)
            tb_c.Font = New Font("Arial", 10)

            Me.XPConclusion.Controls.Add(tb_c)

            y = y + 35
        Next
    End Sub
End Class