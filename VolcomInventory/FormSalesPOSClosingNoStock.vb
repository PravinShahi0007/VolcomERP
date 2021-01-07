Public Class FormSalesPOSClosingNoStock
    Public id As String = "-1"
    Dim rmt As String = "283"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "2"
    Public is_view As String = "-1"

    Private Sub FormSalesPOSClosingNoStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Private Sub FormSalesPOSClosingNoStock_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub actionLoad()
        Dim query As String = "SELECT r.id_sales_pos_oos_recon, r.number, r.created_date, r.note, r.id_report_status, rs.report_status, r.is_confirm 
        FROM tb_sales_pos_oos_recon r
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = r.id_report_status
        WHERE r.id_sales_pos_oos_recon='" + id + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtNumber.Text = data.Rows(0)("number").ToString
        DECreated.EditValue = data.Rows(0)("created_date")
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        id_report_status = data.Rows(0)("id_report_status").ToString
        is_confirm = data.Rows(0)("is_confirm").ToString
        MENote.Text = data.Rows(0)("note").ToString
        viewDetail()
        allowStatus()
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        XTCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub allowStatus()
        If is_confirm = "2" And is_view = "-1" Then
            MENote.Properties.ReadOnly = False
            BtnCreate.Visible = True
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            BtnCancell.Visible = False
        Else
            MENote.Properties.ReadOnly = True
            BtnCreate.Visible = False
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            BtnCancell.Visible = True
        End If
        BtnAttachment.Visible = True

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
        End If

        If id_report_status = "-1" Then
            SBPrint.Visible = False
        Else
            SBPrint.Visible = True
        End If
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class