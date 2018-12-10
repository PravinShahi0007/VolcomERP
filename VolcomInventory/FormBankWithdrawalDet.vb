Public Class FormBankWithdrawalDet
    Public report_mark_type As String = "-1"
    Public id_pay_type As String = "-1"
    Public id_payment As String = "-1"

    Private Sub FormBankWithdrawalDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormBankWithdrawalDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TETotal.EditValue = 0.00
        DEDateCreated.EditValue = Now
        TEPayNumber.Text = "[Auto generate]"

        load_pay_from()
        load_vendor()
        load_trans_type()
        load_report_type()
        '
        If id_payment = "-1" Then
            load_det()
            BtnPrint.Visible = False
            BMark.Visible = False
            BtnSave.Visible = True
            '
            If report_mark_type = "139" Then 'purchasing
                'load header
                SLEVendor.EditValue = FormBankWithdrawal.SLEVendor.EditValue
                SLEPayType.EditValue = id_pay_type
                SLEReportType.EditValue = report_mark_type
                'load detail
                For i As Integer = 0 To FormBankWithdrawal.GVPOList.RowCount - 1
                    'id_report,number,total,balance due
                    Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                    newRow("id_report") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "id_purc_order").ToString
                    newRow("number") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "purc_order_number").ToString
                    newRow("value") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "total_due").ToString
                    newRow("balance_due") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "total_due").ToString
                    newRow("note") = ""
                    TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                Next
            End If
        Else
            BtnPrint.Visible = True
            BMark.Visible = True
            BtnSave.Visible = False
            SLEPayFrom.Enabled = False
            MENote.Enabled = False
            '
            Dim query As String = "SELECT * FROM tb_payment WHERE id_payment='" & id_payment & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                TEPayNumber.Text = data.Rows(0)("number").ToString
                report_mark_type = data.Rows(0)("report_mark_type").ToString
                SLEVendor.EditValue = data.Rows(0)("id_comp_contact").ToString
                SLEPayType.EditValue = data.Rows(0)("id_pay_type").ToString
                SLEReportType.EditValue = data.Rows(0)("report_mark_type").ToString
                '
                DEDateCreated.EditValue = data.Rows(0)("date_created")
                SLEPayFrom.EditValue = data.Rows(0)("id_acc_payfrom").ToString
                MENote.EditValue = data.Rows(0)("note").ToString
            End If
            '
            load_det()
            GridColumnPayment.OptionsColumn.AllowEdit = False
            GridColumnNote.OptionsColumn.AllowEdit = False
        End If
    End Sub

    Sub load_det()
        Dim query As String = ""
        If report_mark_type = "139" Then
            query = "SELECT pyd.*,po.purc_order_number as number FROM tb_payment_det pyd INNER JOIN tb_purc_order po ON po.id_purc_order=pyd.id_report WHERE pyd.id_payment='" & id_payment & "'"
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCList.DataSource = data
        calculate_amount()
    End Sub

    Sub load_vendor()
        Dim query As String = "SELECT cc.id_comp_contact,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name 
                                FROM tb_m_comp c
                                INNER JOIN tb_m_comp_contact cc ON cc.`id_comp`=c.`id_comp` AND cc.`is_default`='1'"
        viewSearchLookupQuery(SLEVendor, query, "id_comp_contact", "comp_name", "id_comp_contact")
    End Sub

    Sub load_pay_from()
        Dim query As String = "SELECT id_acc,acc_name,acc_description FROM `tb_a_acc` WHERE id_status='1' AND id_is_det='2'"
        viewSearchLookupQuery(SLEPayFrom, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Sub load_trans_type()
        Dim query As String = "SELECT id_pay_type,pay_type FROM tb_lookup_pay_type"
        viewSearchLookupQuery(SLEPayType, query, "id_pay_type", "pay_type", "id_pay_type")
    End Sub

    Sub load_report_type()
        Dim query As String = "SELECT report_mark_type,report_mark_type_name FROM `tb_lookup_report_mark_type` WHERE is_payable='1'"
        viewSearchLookupQuery(SLEReportType, query, "report_mark_type", "report_mark_type_name", "report_mark_type")
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click

    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Sub calculate_amount()
        GVList.RefreshData()
        Dim gross_total As Double = 0.0
        Try
            gross_total = Double.Parse(GVList.Columns("value").SummaryItem.SummaryValue.ToString)
        Catch ex As Exception
        End Try

        TETotal.EditValue = gross_total
        GVList.BestFitColumns()
    End Sub

    Private Sub GVList_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVList.CellValueChanged
        If e.Column.FieldName.ToString = "value" Then
            'set value
            calculate_amount()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If id_payment = "-1" Then
            If report_mark_type = "139" Then 'purchasing
                If TETotal.EditValue = 0.00 Then
                    warningCustom("Please fill paid value.")
                ElseIf GVList.RowCount = 0 Then
                    warningCustom("No item listed.")
                Else
                    'header
                    Dim query As String = "INSERT INTO tb_payment(report_mark_type,id_acc_payfrom,id_comp_contact,id_pay_type,id_user_created,date_created,value,note,id_report_status) 
VALUES('139','" & SLEPayFrom.EditValue.ToString & "','" & SLEVendor.EditValue.ToString & "','" & SLEPayType.EditValue.ToString & "','" & id_user & "',NOW(),'" & decimalSQL(TETotal.EditValue.ToString) & "','" & addSlashes(MENote.Text) & "','1'); SELECT LAST_INSERT_ID(); "
                    id_payment = execute_query(query, 0, True, "", "", "", "")
                    'detail
                    query = "INSERT INTO tb_payment_det(id_payment,id_report,number,value,balance_due,note) VALUES"
                    For i As Integer = 0 To GVList.RowCount - 1
                        If Not i = 0 Then
                            query += ","
                        End If
                        query += "('" & id_payment & "','" & GVList.GetRowCellValue(i, "id_report").ToString & "','" & GVList.GetRowCellValue(i, "number").ToString & "','" & decimalSQL(GVList.GetRowCellValue(i, "value").ToString) & "','" & decimalSQL(GVList.GetRowCellValue(i, "balance_due").ToString) & "','" & addSlashes(GVList.GetRowCellValue(i, "note").ToString) & "')"
                    Next
                    execute_non_query(query, True, "", "", "", "")
                    'generate number
                    query = "CALL gen_number('" & id_payment & "','159')"
                    execute_non_query(query, True, "", "", "", "")
                    'add journal + mark
                    submit_who_prepared("159", id_payment, id_user)

                    'done
                    infoCustom("Payment created")
                    FormBankWithdrawal.load_po()
                    FormBankWithdrawal.load_payment()
                    FormBankWithdrawal.GVList.FocusedRowHandle = find_row(FormBankWithdrawal.GVList, "id_payment", id_payment)
                    Close()
                End If
            End If
        End If
    End Sub
End Class