Public Class FormSampleOrderedDet 
    Public id_sample_ordered As String = "-1"
    Public action As String = "-1"
    Public id_report_status As String = "-1"
    Public id_sample_ordered_det_list As New List(Of String)

    Private Sub FormSampleOrderedDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus()
    End Sub

    'report status
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    'VIEW DETAIL
    Sub viewDetail()
        Dim query_c As ClassSampleOrdered = New ClassSampleOrdered()
        Dim query As String = query_c.queryDetail(id_sample_ordered)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'action upd
        If action = "upd" Then
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_sample_ordered_det_list.Add(data.Rows(i)("id_sample_ordered_det").ToString)
            Next
        End If
        GCDetail.DataSource = data
    End Sub

    'enable/disable Edit/Delete Detail
    Sub check_but()
        Dim id_cek As String = "-1"
        Try
            id_cek = GVDetail.GetFocusedRowCellValue("id_sample_ordered_det").ToString
        Catch ex As Exception
        End Try

        If GVDetail.RowCount > 0 And id_cek <> "-1" Then
            BtnEdit.Enabled = True
            BtnDelete.Enabled = True
        Else
            BtnEdit.Enabled = False
            BtnDelete.Enabled = False
        End If
    End Sub

    'load 
    Sub actionLoad()
        If action = "ins" Then
            BMark.Enabled = False
            BtnAttachment.Enabled = False
            BtnPrint.Enabled = False
            DEForm.Text = view_date(0)
            viewDetail()
            check_but()
        ElseIf action = "upd" Then
            BtnSave.Text = "Save Changes"
            BMark.Enabled = True
            Dim query_c As ClassSampleOrdered = New ClassSampleOrdered()
            Dim query As String = query_c.queryMain("AND tb_sample_ordered.id_sample_ordered = ''" + id_sample_ordered + "'' ", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            TxtNumber.Text = data.Rows(0)("sample_ordered_number").ToString
            DEForm.Text = view_date_from(data.Rows(0)("sample_ordered_datex").ToString, 0)
            MENote.Text = data.Rows(0)("sample_ordered_note").ToString

            viewDetail()
            check_but()
        End If
    End Sub

    Sub allow_status()
        'Based on report status
        If check_edit_report_status(id_report_status, "71", id_sample_ordered) Then
            'MsgBox("Masih Boleh")
            PanelControlNav.Enabled = True
            BtnSave.Enabled = True
            MENote.Enabled = True
            GVDetail.OptionsBehavior.ReadOnly = False
        Else
            'MsgBox("Nggak Boleh")
            PanelControlNav.Enabled = False
            BtnSave.Enabled = False
            MENote.Enabled = False
            GVDetail.OptionsBehavior.ReadOnly = True
        End If

        If check_attach_report_status(id_report_status, "71", id_sample_ordered) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub


    Private Sub FormSampleOrderedDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub


    Private Sub GVDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class