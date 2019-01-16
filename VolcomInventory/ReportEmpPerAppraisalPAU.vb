Public Class ReportEmpPerAppraisalPAU
    Public Shared dt_question As DataTable
    Public Shared dt_group_question As DataTable
    Public Shared dt_result As DataTable
    Public Shared dt_conclusion As DataTable

    Private Sub ReportEmpPerAppraisalDet_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim y As Integer = 0
        Dim last_group As Integer = 0

        Dim result_x() As Integer = {220, 290, 360, 430, 500}

        For i = 0 To dt_question.Rows.Count - 1
            'Group
            If last_group <> dt_question.Rows(i)("id_question_gen_app_group") Then
                Dim tb_g As New DevExpress.XtraReports.UI.XRLabel

                tb_g.Text = dt_question.Rows(i)("group_name")
                tb_g.SizeF = New Size(200, 20)
                tb_g.LocationF = New Point(0, y)
                tb_g.Font = New Font("Arial", 10, FontStyle.Bold)

                Me.XPAspek.Controls.Add(tb_g)

                y = y + 20 + 15
            End If

            last_group = dt_question.Rows(i)("id_question_gen_app_group")

            'Number
            Dim tb_n As New DevExpress.XtraReports.UI.XRLabel

            tb_n.Text = (i + 1).ToString + "."
            tb_n.SizeF = New Size(20, 20)
            tb_n.LocationF = New Point(20, y)
            tb_n.Font = New Font("Arial", 10)

            Me.XPAspek.Controls.Add(tb_n)

            'Question
            Dim tb_q As New DevExpress.XtraReports.UI.XRLabel

            tb_q.Text = dt_question.Rows(i)("question")
            tb_q.SizeF = New Size(200, 20)
            tb_q.LocationF = New Point(40, y)
            tb_q.Font = New Font("Arial", 10, FontStyle.Bold)

            Me.XPAspek.Controls.Add(tb_q)

            'Result Value
            For j = 0 To result_x.Length() - 1
                Dim tb_v As New DevExpress.XtraReports.UI.XRLabel

                tb_v.Text = ""

                If j = 0 And dt_question.Rows(i)("value") <= 1 Then
                    tb_v.Text = dt_question.Rows(i)("value")
                End If

                If j = 1 And dt_question.Rows(i)("value") >= 2 And dt_question.Rows(i)("value") <= 4 Then
                    tb_v.Text = dt_question.Rows(i)("value")
                End If

                If j = 2 And dt_question.Rows(i)("value") >= 5 And dt_question.Rows(i)("value") <= 6 Then
                    tb_v.Text = dt_question.Rows(i)("value")
                End If

                If j = 3 And dt_question.Rows(i)("value") >= 7 And dt_question.Rows(i)("value") <= 8 Then
                    tb_v.Text = dt_question.Rows(i)("value")
                End If

                If j = 4 And dt_question.Rows(i)("value") >= 9 And dt_question.Rows(i)("value") <= 10 Then
                    tb_v.Text = dt_question.Rows(i)("value")
                End If

                tb_v.SizeF = New Size(70, 20)
                tb_v.LocationF = New Point(result_x(j), y)
                tb_v.Font = New Font("Arial", 10)
                tb_v.Borders = DevExpress.XtraPrinting.BorderSide.All
                tb_v.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter

                Me.XPAspek.Controls.Add(tb_v)
            Next

            'Result Information
            Dim tb_i As New DevExpress.XtraReports.UI.XRLabel

            tb_i.Text = dt_question.Rows(i)("information")
            tb_i.SizeF = New Size(180, 20)
            tb_i.LocationF = New Point(570, y)
            tb_i.Font = New Font("Arial", 10)
            tb_i.Borders = DevExpress.XtraPrinting.BorderSide.All
            tb_i.Padding = New DevExpress.XtraPrinting.PaddingInfo(7, 2, 0, 0)

            Me.XPAspek.Controls.Add(tb_i)

            y = y + 20

            'Detail
            Dim tb_qd As New DevExpress.XtraReports.UI.XRLabel

            tb_qd.Text = dt_question.Rows(i)("question_detail")
            tb_qd.SizeF = New Size(750, 20)
            tb_qd.LocationF = New Point(40, y)
            tb_qd.Font = New Font("Arial", 10, FontStyle.Italic)

            Me.XPAspek.Controls.Add(tb_qd)

            y = y + 20 + 15
        Next

        'Total Nilai & Bobot
        y = 0

        For i = 0 To dt_group_question.Rows.Count - 1
            'Group Name
            Dim tb_g As New DevExpress.XtraReports.UI.XRLabel

            tb_g.Text = dt_group_question.Rows(i)("group_name")
            tb_g.SizeF = New Size(150, 20)
            tb_g.LocationF = New Point(0, y)
            If i = dt_group_question.Rows.Count - 1 Then
                tb_g.Font = New Font("Arial", 10, FontStyle.Bold)
            Else
                tb_g.Font = New Font("Arial", 10)
            End If

            Me.XPGroupQuestion.Controls.Add(tb_g)

            'Equal
            Dim tb_e As New DevExpress.XtraReports.UI.XRLabel

            If i = dt_group_question.Rows.Count - 1 Then
                tb_e.Text = ""
            Else
                tb_e.Text = "="
            End If
            tb_e.SizeF = New Size(20, 20)
            tb_e.LocationF = New Point(150, y)
            If i = dt_group_question.Rows.Count - 1 Then
                tb_e.Font = New Font("Arial", 10, FontStyle.Bold)
            Else
                tb_e.Font = New Font("Arial", 10)
            End If

            Me.XPGroupQuestion.Controls.Add(tb_e)

            'Formula
            Dim tb_f As New DevExpress.XtraReports.UI.XRLabel

            tb_f.Text = dt_group_question.Rows(i)("formula")
            tb_f.SizeF = New Size(100, 20)
            tb_f.LocationF = New Point(170, y)
            If i = dt_group_question.Rows.Count - 1 Then
                tb_f.Font = New Font("Arial", 10, FontStyle.Bold)
            Else
                tb_f.Font = New Font("Arial", 10)
            End If

            Me.XPGroupQuestion.Controls.Add(tb_f)

            'Total
            Dim tb_t As New DevExpress.XtraReports.UI.XRLabel

            tb_t.Text = dt_group_question.Rows(i)("total")
            tb_t.SizeF = New Size(50, 20)
            tb_t.LocationF = New Point(270, y)
            If i = dt_group_question.Rows.Count - 1 Then
                tb_t.Font = New Font("Arial", 10, FontStyle.Bold)
            Else
                tb_t.Font = New Font("Arial", 10)
            End If

            Me.XPGroupQuestion.Controls.Add(tb_t)

            y = y + 20
        Next

        'Penilaian Umum
        y = 0

        For i = 0 To dt_result.Rows.Count - 1
            'Result
            Dim tb_r As New DevExpress.XtraReports.UI.XRLabel

            tb_r.Text = dt_result.Rows(i)("result")
            tb_r.SizeF = New Size(50, 20)
            tb_r.LocationF = New Point(0, y)
            tb_r.Font = New Font("Arial", 10)

            Me.XPResult.Controls.Add(tb_r)

            'Name
            Dim tb_n As New DevExpress.XtraReports.UI.XRLabel

            tb_n.Text = dt_result.Rows(i)("name")
            tb_n.SizeF = New Size(150, 20)
            tb_n.LocationF = New Point(50, y)
            tb_n.Font = New Font("Arial", 10)

            Me.XPResult.Controls.Add(tb_n)

            'Range
            Dim tb_f As New DevExpress.XtraReports.UI.XRLabel

            tb_r.Text = dt_result.Rows(i)("range")
            tb_r.SizeF = New Size(130, 20)
            tb_r.LocationF = New Point(620, y)
            tb_r.Font = New Font("Arial", 10)

            Me.XPResult.Controls.Add(tb_r)

            y = y + 20
        Next

        'Kesimpulan
        y = 0

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