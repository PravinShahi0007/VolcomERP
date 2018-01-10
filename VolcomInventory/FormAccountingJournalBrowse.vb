Public Class FormAccountingJournalBrowse
    Public data_par As DataTable

    Private Sub FormAccountingJournalBrowse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_billing_type(LEBilling)
        viewWHStockSum()
        ActiveControl = LEBilling
    End Sub

    Sub viewJournal()
        Dim id_bill_type As String = "-1"
        Try
            id_bill_type = LEBilling.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim id_comp As String = "-1"
        Try
            id_comp = SLEWHStockSum.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim query As String = "SELECT c.id_acc_trans,c.acc_trans_number,c.date_created,a.id_acc_trans_det,a.id_acc, a.id_comp,b.acc_name,b.acc_description,
        CAST(a.debit AS DECIMAL(13,2)) as debit,CAST(a.credit AS DECIMAL(13,2)) as credit,a.acc_trans_det_note as note,  a.report_mark_type, a.id_report, a.report_number,'36' AS `report_mark_type_current`,
        'No' AS `is_select`
        FROM tb_a_acc_trans_det a 
        INNER JOIN tb_a_acc b ON a.id_acc=b.id_acc 
        INNER JOIN tb_a_acc_trans c ON c.id_acc_trans=a.id_acc_trans
        LEFT JOIN tb_a_acc_trans_det ar ON ar.id_acc_src = a.id_acc_trans
        WHERE c.id_bill_type=" + id_bill_type + " AND a.id_comp=" + id_comp + " AND ISNULL(ar.id_acc_src) "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")


        If data_par.Rows.Count = 0 Then
            GCJournalDet.DataSource = data
        Else
            If data.Rows.Count > 0 Then
                Dim t1 = data.AsEnumerable()
                Dim t2 = data_par.AsEnumerable()
                Dim except As DataTable = (From _t1 In t1
                                           Group Join _t2 In t2
                                           On _t1("id_acc") Equals _t2("id_acc") And _t1("id_acc_trans") Equals _t2("id_report") Into Group
                                           From _t3 In Group.DefaultIfEmpty()
                                           Where _t3 Is Nothing
                                           Select _t1).CopyToDataTable
                GCJournalDet.DataSource = except
            End If
        End If
    End Sub

    Sub load_billing_type(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_bill_type,bill_type FROM tb_lookup_bill_type WHERE is_active='1'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "bill_type"
        lookup.Properties.ValueMember = "id_bill_type"
        lookup.ItemIndex = 0
    End Sub

    Sub viewWHStockSum()
        Dim query As String = ""
        query += "SELECT ('0') AS id_comp, ('-') AS comp_number, ('- Select Account -') AS comp_name, ('- Select Account -') AS comp_name_label UNION ALL "
        query += "SELECT e.id_comp, e.comp_number, e.comp_name, CONCAT_WS(' - ', e.comp_number, e.comp_name) AS comp_name_label FROM tb_storage_fg a "
        query += "INNER JOIN tb_m_wh_drawer b ON a.id_wh_drawer = b.id_wh_drawer "
        query += "INNER JOIN tb_m_wh_rack c ON b.id_wh_rack = c.id_wh_rack "
        query += "INNER JOIN tb_m_wh_locator d ON c.id_wh_locator = d.id_wh_locator "
        query += "INNER JOIN tb_m_comp e ON e.id_comp = d.id_comp "
        query += "GROUP BY e.id_comp "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        SLEWHStockSum.Properties.DataSource = Nothing
        SLEWHStockSum.Properties.DataSource = data
        SLEWHStockSum.Properties.DisplayMember = "comp_name_label"
        SLEWHStockSum.Properties.ValueMember = "id_comp"
        If data.Rows.Count.ToString >= 1 Then
            SLEWHStockSum.EditValue = data.Rows(0)("id_comp").ToString
        Else
            SLEWHStockSum.EditValue = Nothing
        End If
    End Sub

    Private Sub LEBilling_EditValueChanged(sender As Object, e As EventArgs) Handles LEBilling.EditValueChanged
        viewJournal()
    End Sub

    Private Sub SLEWHStockSum_EditValueChanged(sender As Object, e As EventArgs) Handles SLEWHStockSum.EditValueChanged
        viewJournal()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnDebit.Click
        setVal(True)
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles BtnCredit.Click
        setVal(False)
    End Sub

    Sub setVal(ByVal is_debit As Boolean)
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVJournalDet)
        GVJournalDet.ActiveFilterString = "[is_select]='Yes'"
        If GVJournalDet.RowCount > 0 Then

            For i As Integer = 0 To ((GVJournalDet.RowCount - 1) - GetGroupRowCount(GVJournalDet))
                Dim newRow As DataRow = (TryCast(FormAccountingJournalBill.GCJournalDet.DataSource, DataTable)).NewRow()
                newRow("id_acc") = GVJournalDet.GetRowCellValue(i, "id_acc").ToString()
                newRow("acc_name") = GVJournalDet.GetRowCellValue(i, "acc_name").ToString()
                newRow("note") = GVJournalDet.GetRowCellValue(i, "note").ToString()


                Dim vald As Decimal = GVJournalDet.GetRowCellValue(i, "debit")
                Dim valc As Decimal = GVJournalDet.GetRowCellValue(i, "credit")
                Dim val As Decimal = 0
                If vald = 0 Then
                    val = valc
                Else
                    val = vald
                End If
                If is_debit Then
                    newRow("debit") = val
                    newRow("credit") = 0
                Else
                    newRow("debit") = 0
                    newRow("credit") = val

                End If
                newRow("id_comp") = SLEWHStockSum.EditValue.ToString
                newRow("report_mark_type") = "36"
                newRow("id_report") = GVJournalDet.GetRowCellValue(i, "id_acc_trans").ToString()
                newRow("report_number") = GVJournalDet.GetRowCellValue(i, "acc_trans_number").ToString()
                newRow("id_status_open") = 1

                TryCast(FormAccountingJournalBill.GCJournalDet.DataSource, DataTable).Rows.Add(newRow)
                FormAccountingJournalBill.GCJournalDet.RefreshDataSource()
                FormAccountingJournalBill.but_check()
                FormAccountingJournalBill.GVJournalDet.FocusedRowHandle = 0
                Close()
            Next
        Else
            stopCustom("No item selected")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormAccountingJournalBrowse_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub LEBilling_KeyDown(sender As Object, e As KeyEventArgs) Handles LEBilling.KeyDown
        If e.KeyCode = Keys.Enter Then
            'SLEWHStockSum.ShowPopup()
            SLEWHStockSum.Focus()
        End If
    End Sub
End Class