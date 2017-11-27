Public Class FormAccountingDraftJournal
    Public id_report As String = "-1"
    Public report_number As String = ""
    Public report_mark_type As String = "-1"
    Public is_view As String = "-1"
    Public id_pop_up As String = "-1"
    Public data_delete As New DataTable
    Dim acc_desc_initial As String = ""
    Dim acc_id_initial As String = ""


    Private Sub FormAccountingDraftJournal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub FormAccountingDraftJournal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_bill_type()
        viewDraft()
        viewAcc()
        viewComp()



        'only view draft
        If is_view = "1" Then
            BtnAdd.Visible = False
            BtnDelete.Visible = False
            LEJournalType.Enabled = False
            SimpleButton1.Visible = False
            GVData.OptionsBehavior.ReadOnly = True
        End If

        'initialisation datatable edit
        Try
            data_delete.Columns.Add("id_acc_trans_draft")
        Catch ex As Exception
        End Try
    End Sub

    Sub view_bill_type()
        Dim query As String = "SELECT * FROM tb_lookup_bill_type b ORDER BY b.id_bill_type ASC "
        viewLookupQuery(LEJournalType, query, 0, "bill_desc", "id_bill_type")
    End Sub

    Sub viewAcc()
        Dim acc As New ClassAccounting()
        Dim query As String = acc.queryViewAcc("-1", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        acc_desc_initial = data.Rows(0)("acc_description").ToString
        acc_id_initial = data.Rows(0)("id_acc").ToString
        RSLEAcc.DataSource = Nothing
        RSLEAcc.DataSource = data
        RSLEAcc.DisplayMember = "acc_name"
        RSLEAcc.ValueMember = "id_acc"
    End Sub

    Sub viewComp()
        Dim query As String = "SELECT c.id_comp, CONCAT(c.comp_number, ' - ', c.comp_name) AS `comp` FROM tb_m_comp c ORDER BY c.comp_number ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        RSLEComp.DataSource = Nothing
        RSLEComp.DataSource = data
        RSLEComp.DisplayMember = "comp"
        RSLEComp.ValueMember = "id_comp"
    End Sub

    Sub viewDraft()
        Dim acc As New ClassAccounting()
        Dim query As String = acc.viewJournalSalesDraft("AND d.id_report=" + id_report + " AND d.report_mark_type =" + report_mark_type + " ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data

        'initial biill type
        If GVData.RowCount > 0 Then
            LEJournalType.ItemIndex = LEJournalType.Properties.GetDataSourceRowIndex("id_bill_type", data.Rows(0)("id_bill_type").ToString)
        End If
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        addRow()
        GCData.Focus()
        GVData.FocusedRowHandle = GVData.RowCount - 1
        GVData.FocusedColumn = GridColumnAcc
        Cursor = Cursors.Default
    End Sub

    Sub addRow()
        Cursor = Cursors.WaitCursor
        Dim newRow As DataRow = (TryCast(GCData.DataSource, DataTable)).NewRow()
        newRow("id_acc_trans_draft") = "0"
        newRow("id_acc") = acc_id_initial
        newRow("acc_description") = acc_desc_initial
        newRow("report_number") = report_number
        newRow("acc_trans_det_note") = ""
        newRow("id_comp") = 0
        newRow("debit") = 0
        newRow("credit") = 0
        TryCast(GCData.DataSource, DataTable).Rows.Add(newRow)
        GCData.RefreshDataSource()
        GVData.RefreshData()
        Cursor = Cursors.Default
    End Sub

    Private Sub RSLEAcc_EditValueChanged(sender As Object, e As EventArgs) Handles RSLEAcc.EditValueChanged
        Dim SLE As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = SLE.Properties.View
        Dim desc As String = view.GetRowCellValue(view.FocusedRowHandle, "acc_description").ToString
        GVData.SetRowCellValue(GVData.FocusedRowHandle, "acc_description", desc)
        GVData.SetRowCellValue(GVData.FocusedRowHandle, "acc_trans_det_note", "")
    End Sub

    Private Sub RSLEAcc_Popup(sender As Object, e As EventArgs) Handles RSLEAcc.Popup

    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GVData.CloseEditor()
        makeSafeGV(GVData)

        If GVData.Columns("debit").SummaryItem.SummaryValue <> GVData.Columns("credit").SummaryItem.SummaryValue Then
            stopCustom("The totals of the debits and credits must equal ")
        Else
            Cursor = Cursors.WaitCursor
            makeSafeGV(GVData)

            PBC.Properties.Minimum = 0
            PBC.Properties.Maximum = GVData.RowCount - 1
            PBC.Properties.Step = 1
            For i As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                Dim id_acc_trans_draft As String = GVData.GetRowCellValue(i, "id_acc_trans_draft").ToString
                Dim id_acc As String = GVData.GetRowCellValue(i, "id_acc").ToString
                Dim id_comp As String = "NULL "
                Try
                    id_comp = GVData.GetRowCellValue(i, "id_comp").ToString
                Catch ex As Exception
                End Try
                If id_comp = "0" Then
                    id_comp = "NULL "
                End If
                Dim debit As String = decimalSQL(GVData.GetRowCellValue(i, "debit").ToString)
                Dim credit As String = decimalSQL(GVData.GetRowCellValue(i, "credit").ToString)
                Dim acc_trans_det_note As String = addSlashes(GVData.GetRowCellValue(i, "acc_trans_det_note").ToString)
                Dim id_bill_type As String = LEJournalType.EditValue.ToString
                report_number = addSlashes(report_number)

                If id_acc_trans_draft = "0" Then 'insert
                    Dim query As String = "INSERT INTO tb_a_acc_trans_draft(id_acc, id_comp, id_bill_type, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number) 
                    VALUES (" + id_acc + ", " + id_comp + ", '" + id_bill_type + "', " + debit + ", " + credit + ", '" + acc_trans_det_note + "', " + report_mark_type + ", " + id_report + ", '" + report_number + "') "
                    execute_non_query(query, True, "", "", "", "")
                Else 'edit
                    Dim query As String = "UPDATE tb_a_acc_trans_draft SET id_acc=" + id_acc + ", 
                    id_comp = " + id_comp + ", 
                    id_bill_type ='" + id_bill_type + "',
                    debit = " + debit + ", 
                    credit = " + credit + ", 
                    acc_trans_det_note = '" + acc_trans_det_note + "', 
                    report_mark_type = " + report_mark_type + ", 
                    id_report = " + id_report + ",  
                    report_number ='" + report_number + "'
                    WHERE id_acc_trans_draft =" + id_acc_trans_draft + " "
                    execute_non_query(query, True, "", "", "", "")
                End If

                PBC.PerformStep()
                PBC.Update()
            Next

            'delete
            If data_delete.Rows.Count > 0 Then
                Dim qd As String = "DELETE FROM tb_a_acc_trans_draft WHERE id_acc_trans_draft>0 AND ("
                For j As Integer = 0 To data_delete.Rows.Count - 1
                    If j > 0 Then
                        qd += "OR "
                    End If
                    qd += "id_acc_trans_draft='" + data_delete.Rows(j)("id_acc_trans_draft").ToString + "' "
                Next
                qd += ") "
                execute_non_query(qd, True, "", "", "", "")
            End If
            data_delete.Clear()
            viewDraft()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim id As String = GVData.GetFocusedRowCellValue("id_acc_trans_draft").ToString
            If id <> "0" Then
                Dim R As DataRow = data_delete.NewRow
                R("id_acc_trans_draft") = id
                data_delete.Rows.Add(R)
            End If
            GVData.DeleteSelectedRows()
        End If
    End Sub
End Class