Public Class FormTargetSalesDet
    Public id As String = "-1"
    Public action As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim rmt As String = "414"
    Dim dt_json As New Newtonsoft.Json.Linq.JObject()

    Private Sub FormTargetSalesDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dt_json = volcomErpApiGetJson(volcom_erp_api_host & "api/target-sales-det-controller/" + id + "")
        viewReportStatus()
    End Sub

    Private Sub FormTargetSalesDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
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
            TxtNumber.Text = "[auto generated]"
        ElseIf action = "upd" Then
            Dim data As DataTable = volcomErpApiGetDT(dt_json, 2)
            TxtNumber.Text = data.Rows(0)("number").ToString
            DECreated.EditValue = data.Rows(0)("created_date")
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            TxtYear.EditValue = data.Rows(0)("year").ToString
            MENote.Text = data.Rows(0)("note").ToString
            is_confirm = data.Rows(0)("is_confirm").ToString

            'detail
            viewDetail()
            allowStatus()
        End If
    End Sub

    Sub viewDetail()

    End Sub

    Sub allowStatus()
        BtnCreateNew.Visible = False
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        TxtYear.Enabled = False
        If is_confirm = "2" And is_view = "-1" Then
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            MENote.Enabled = False
            BtnPrint.Visible = False
            BtnSaveChanges.Visible = True
            MENote.Enabled = True
            GVData.OptionsBehavior.ReadOnly = False
            PanelControlNav.Visible = True
        Else
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            MENote.Enabled = False
            BtnPrint.Visible = True
            BtnSaveChanges.Visible = False
            MENote.Enabled = False
            GVData.OptionsBehavior.ReadOnly = True
            PanelControlNav.Visible = False
        End If

        'reset propose
        If is_view = "-1" And is_confirm = "1" Then
            BtnResetPropose.Visible = True
        Else
            BtnResetPropose.Visible = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
            BtnResetPropose.Visible = False
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
            BtnResetPropose.Visible = False
            BtnConfirm.Visible = False
            MENote.Enabled = False
            BtnPrint.Visible = False
            BtnSaveChanges.Visible = False
            MENote.Enabled = False
            GVData.OptionsBehavior.ReadOnly = True
            PanelControlNav.Visible = False
        End If
    End Sub
End Class