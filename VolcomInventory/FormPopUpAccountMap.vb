Public Class FormPopUpAccountMap 
    Public id_coa As String = "-1"
    Public id_source As String = "-1"
    Public report_mark_type As String = "-1"
    Public id_report As String = "-1"
    Public id_comp As String = "-1"

    Private Sub BSearchCompTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSearchCompTo.Click
        FormPopUpCOA.id_pop_up = "4"
        FormPopUpCOA.ShowDialog()
    End Sub

    Private Sub FormPopUpAccountMap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_dc(LEpayment)
        load_pr()
        GVListTransaction.BestFitColumns()
    End Sub

    Private Sub view_dc(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_dc,dc FROM tb_lookup_dc WHERE id_dc='1' or id_dc='2'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "dc"
        lookup.Properties.ValueMember = "id_dc"
        lookup.ItemIndex = 0
    End Sub

    Sub load_pr()
        Dim dt As DataTable = FormAccountingListPR.GCPaymentList.DataSource

        Dim dr As DataRow() = dt.Select("[is_check]= 'yes'")
        If (dr.Length > 0) Then
            Dim dtb_n As DataTable = dr.CopyToDataTable
            'Dim dtb_fix As DataTable = dtb_n.Clone

            'For i As Integer = 0 To dtb_n.Rows.Count - 1
            '    If dtb_n.Rows(i)("vat") > 0 Then
            '        dtb_fix.ImportRow(dtb_n.Rows(i))
            '    End If
            'Next

            GCListTransaction.DataSource = dtb_n
        Else
            BSelect.Visible = False
        End If
        
        ' '... 
        'creating and saving the view's layout to a new memory stream
        'Dim str As System.IO.Stream
        'str = New System.IO.MemoryStream()
        'FormAccountingListPR.GVPaymentList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str.Seek(0, System.IO.SeekOrigin.Begin)
        'GVListTransaction.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str.Seek(0, System.IO.SeekOrigin.Begin)
        'GVListTransaction.Columns("is_check").Visible = False
        'GVListTransaction.Columns("report_mark_type_name").GroupIndex = -1
        'GVListTransaction.ActiveFilterString = String.Empty
    End Sub

    Private Sub BSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSelect.Click
        GVListTransaction.ActiveFilterString = "is_check='yes'"
        TEAmount.EditValue = GVListTransaction.Columns("total").SummaryItem.SummaryValue
        TEPayment.EditValue = GVListTransaction.GetFocusedRowCellValue("report_number").ToString
        id_comp = GVListTransaction.GetFocusedRowCellValue("id_comp").ToString
        TESource.EditValue = GVListTransaction.GetFocusedRowCellValue("comp_name").ToString
        id_report = GVListTransaction.GetFocusedRowCellValue("id_report").ToString
        report_mark_type = GVListTransaction.GetFocusedRowCellValue("report_mark_type").ToString
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        If id_coa = "-1" Then
            stopCustom("Please choose COA first.")
        Else
            'insert
            Dim newRow As DataRow = (TryCast(FormAccountingListPRPay.GCJournalDet.DataSource, DataTable)).NewRow()
            newRow("id_acc") = id_coa
            newRow("acc_name") = TECoaNumber.Text
            newRow("note") = METransDet.Text
            If LEpayment.EditValue.ToString = "1" Then
                newRow("debit") = TEAfterKurs.EditValue
                newRow("credit") = 0
            ElseIf LEpayment.EditValue.ToString = "2" Then
                newRow("debit") = 0
                newRow("credit") = TEAfterKurs.EditValue
            End If
            newRow("id_report") = id_report

            newRow("id_report") = id_report
            newRow("report_mark_type") = report_mark_type
            newRow("report_number") = TEPayment.Text

            newRow("id_comp") = id_comp
            newRow("comp_name") = TESource.Text

            TryCast(FormAccountingListPRPay.GCJournalDet.DataSource, DataTable).Rows.Add(newRow)
            FormAccountingListPRPay.GCJournalDet.RefreshDataSource()
            FormAccountingListPRPay.GVJournalDet.BestFitColumns()
            FormAccountingListPRPay.show_but()
            Close()
        End If
    End Sub

    Private Sub TEKurs_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEKurs.EditValueChanged
        load_price()
    End Sub

    Sub load_price()
        Dim kurs As Decimal = TEKurs.EditValue
        Dim amount As Decimal = TEAmount.EditValue
        Dim after_kurs As Decimal

        after_kurs = amount * kurs
        TEAfterKurs.EditValue = after_kurs
    End Sub

    Private Sub TEAmount_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEAmount.EditValueChanged
        load_price()
    End Sub

    Private Sub FormPopUpAccountMap_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class