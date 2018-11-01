Public Class FormPurchaseReturnDet
    Public id As String = "-1"
    Public action As String = ""
    Public id_purc_order As String = "-1"
    Dim id_report_status As String = "-1"
    Public is_view As String = "-1"
    Dim created_date As String = ""

    Private Sub FormPurchaseReturnDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            'cek coa
            Dim qcoa As String = "SELECT * 
            FROM tb_opt_purchasing o
            INNER JOIN tb_a_acc d ON d.id_acc = o.acc_coa_receive 
            INNER JOIN tb_a_acc k ON k.id_acc = o.acc_coa_hutang 
            WHERE !ISNULL(d.id_acc) AND !ISNULL(k.id_acc) "
            Dim dcoa As DataTable = execute_query(qcoa, -1, True, "", "", "", "")
            If dcoa.Rows.Count <= 0 Then
                warningCustom("The account hasn't been mapped yet. Please contact accounting department.")
                Close()
            End If

            'purc order detail
            TxtNumber.Text = "[auto generate]"
            DECreated.EditValue = getTimeDB()
            viewDetail
        Else
            XTCReceive.SelectedTabPageIndex = 0

            Dim r As New ClassPurcReturn()
            Dim query As String = r.queryMain("AND ret.id_purc_return='" + id + "' ", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            id_report_status = data.Rows(0)("id_report_status").ToString
            TxtNumber.Text = data.Rows(0)("number").ToString
            created_date = DateTime.Parse(data.Rows(0)("created_date")).ToString("yyyy-MM-dd HH:mm:ss")
            DECreated.EditValue = data.Rows(0)("created_date")
            MENote.Text = data.Rows(0)("note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_purc_order = data.Rows(0)("id_purc_order").ToString
            TxtOrderNumber.Text = data.Rows(0)("purc_order_number").ToString
            TxtVendor.Text = data.Rows(0)("vendor").ToString

            viewDetail()
            allow_status()
        End If
    End Sub

    Sub viewDetail()

    End Sub

    Sub viewSummary()

    End Sub

    Sub viewOrderDetails()
        Cursor = Cursors.WaitCursor
        Dim po As New ClassPurcOrder()
        Dim query As String = po.queryOrderDetails(id_purc_order)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCOrderDetail.DataSource = data
        GVOrderDetail.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub allow_status()
        BtnCancell.Visible = True
        BtnMark.Visible = True
        BtnAttachment.Visible = True
        BtnPrint.Visible = True
        GVSummary.OptionsBehavior.Editable = False
        GVDetail.OptionsBehavior.Editable = False

        If check_edit_report_status(id_report_status, "148", id) Then
            BtnSave.Visible = False
            MENote.Enabled = True
        Else
            BtnSave.Visible = False
            MENote.Enabled = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
            BtnViewJournal.Visible = True
            BtnViewJournal.BringToFront()
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
        End If
    End Sub
End Class