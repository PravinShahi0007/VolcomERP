Public Class FormDropChangesDet
    Public id As String = "-1"
    Public action As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim rmt As String = "410"
    Dim dt_json As New Newtonsoft.Json.Linq.JObject()

    Private Sub FormDropChangesDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dt_json = volcomErpApiGetJson(volcom_erp_api_host & "api/dropchanges-det/" + id + "")

        viewSeason()
        viewReportStatus()
        actionLoad()
    End Sub

    Private Sub FormDropChangesDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewSeason()
        viewSearchLookupQueryO(SLESeason, volcomErpApiGetDT(dt_json, 1), "id_season", "season", "id_season")
    End Sub

    Sub viewReportStatus()
        viewLookupQueryO(LEReportStatus, volcomErpApiGetDT(dt_json, 0), 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            BtnCreateNew.Visible = True
            Width = 459
            Height = 155
            WindowState = FormWindowState.Normal
            MaximizeBox = False
            'FormBorderStyle = FormBorderStyle.FixedDialog
            StartPosition = FormStartPosition.CenterScreen
            PanelControlBottom.Visible = False
            PanelControl1.Visible = False
            PanelControlNav.Visible = False

            'location form
            Dim r As Rectangle
            If Parent IsNot Nothing Then
                r = Parent.RectangleToScreen(Parent.ClientRectangle)
            Else
                r = Screen.FromPoint(Location).WorkingArea
            End If
            Dim x = r.Left + (r.Width - Width) \ 2
            Dim y = r.Top + (r.Height - Height) \ 2
            Location = New Point(x, y)
        End If
    End Sub

    Private Sub BtnCreateNew_Click(sender As Object, e As EventArgs) Handles BtnCreateNew.Click
        If SLESeason.EditValue = Nothing Then
            warningCustom("Please input all data")
            Exit Sub
        End If

        Dim qcek As String = "SELECT * FROM tb_drop_changes p WHERE p.id_season='" + SLESeason.EditValue.ToString + "' AND p.id_report_status!=5 "
        Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")

        If dcek.Rows.Count > 0 Then
            warningCustom("Please complete all pending propose first")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to create New propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                saveHead()
            End If
        End If
    End Sub

    Sub saveHead()

    End Sub
End Class