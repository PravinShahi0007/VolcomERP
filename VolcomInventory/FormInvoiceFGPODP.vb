﻿Public Class FormInvoiceFGPODP
    Public id_invoice As String = "-1"
    Public is_view As String = "-1"
    Public type As String = "1"

    Public id_po As String = "-1"

    Public doc_type As String = "2"

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Sub load_trans_type()
        Dim query As String = "SELECT id_type,pn_type FROM tb_pn_type"
        If doc_type = "1" Or doc_type = "3" Then
            query += " WHERE id_type='1' OR id_type='2'"
        End If
        viewSearchLookupQuery(SLEPayType, query, "id_type", "pn_type", "id_type")
    End Sub

    Private Sub view_currency()
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        viewSearchLookupRepositoryQuery(RISLECurrency, query, 0, "currency", "id_currency")
    End Sub

    Private Sub view_coa()
        Dim query As String = "SELECT id_acc,acc_name,acc_description FROM tb_a_acc WHERE id_is_det='2'"
        viewSearchLookupRepositoryQuery(RISLECOA, query, 0, "acc_description", "id_acc")
    End Sub

    Private Sub FormInvoiceFGPODP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_currency()
        view_coa()
        'check 
        DEDateCreated.EditValue = Now
        DERefDate.EditValue = Now
        DEDueDate.EditValue = Now
        DEDueDateInv.EditValue = Now
        '
        TETotal.EditValue = 0.00
        TEVat.EditValue = 0.00
        TEGrandTotal.EditValue = 0.00
        '
        TENumber.Text = "[auto generate]"
        load_vendor()
        load_trans_type()
        load_det()
        '
        If id_invoice = "-1" Then 'new
            BtnPrint.Visible = False
            BtnViewJournal.Visible = False
            BMark.Visible = False
            DEDueDate.Properties.ReadOnly = False
            DEDueDateInv.Properties.ReadOnly = False
            DERefDate.Properties.ReadOnly = False
            '
            If doc_type = "1" Or doc_type = "3" Then
                SLEPayType.Properties.ReadOnly = False
                SLEVendor.Properties.ReadOnly = False
            Else
                GCReff.OptionsColumn.AllowFocus = False
                GCDescription.OptionsColumn.AllowFocus = False
                GCQty.OptionsColumn.AllowFocus = False
                GCCur.OptionsColumn.AllowFocus = False
                GCBeforeKurs.OptionsColumn.AllowFocus = False
                GCKurs.OptionsColumn.AllowFocus = False
                GCVat.OptionsColumn.AllowFocus = False

                If type = "1" Then 'DP
                    BtnPrint.Visible = False
                    BtnViewJournal.Visible = False
                    BMark.Visible = False
                    DEDueDate.Properties.ReadOnly = False
                    DERefDate.Properties.ReadOnly = False
                    'new
                    'vendor 
                    SLEVendor.EditValue = FormInvoiceFGPO.SLEVendorPayment.EditValue
                    'detail
                    Try
                        For i = 0 To FormInvoiceFGPO.GVDPFGPO.RowCount - 1
                            Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                            newRow("id_prod_order") = FormInvoiceFGPO.GVDPFGPO.GetRowCellValue(i, "id_prod_order").ToString
                            newRow("id_acc") = FormInvoiceFGPO.GVDPFGPO.GetRowCellValue(i, "id_acc").ToString
                            newRow("id_report") = FormInvoiceFGPO.GVDPFGPO.GetRowCellValue(i, "id_prod_order").ToString
                            newRow("report_mark_type") = "22"
                            newRow("report_number") = FormInvoiceFGPO.GVDPFGPO.GetRowCellValue(i, "prod_order_number").ToString
                            newRow("info_design") = FormInvoiceFGPO.GVDPFGPO.GetRowCellValue(i, "design_display_name").ToString
                            newRow("qty") = FormInvoiceFGPO.GVDPFGPO.GetRowCellValue(i, "qty")
                            '
                            newRow("id_currency") = FormInvoiceFGPO.GVDPFGPO.GetRowCellValue(i, "id_currency")
                            newRow("kurs") = FormInvoiceFGPO.GVDPFGPO.GetRowCellValue(i, "prod_order_wo_kurs")
                            newRow("value_bef_kurs") = FormInvoiceFGPO.GVDPFGPO.GetRowCellValue(i, "dp_amount_bef_kurs")
                            '
                            newRow("vat") = FormInvoiceFGPO.GVDPFGPO.GetRowCellValue(i, "dp_amount_vat")
                            newRow("inv_number") = ""
                            newRow("note") = ""
                            TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                        Next
                        calculate()
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                ElseIf type = "2" Then 'payment
                    BtnPrint.Visible = False
                    BtnViewJournal.Visible = False
                    BMark.Visible = False
                    DEDueDate.Properties.ReadOnly = False
                    DERefDate.Properties.ReadOnly = False

                    'add detail vendor, PO, receiving
                    FormInvoiceFGPONew.ShowDialog()

                    'pop up DP
                    Dim query_pop As String = "SELECT 'no' AS is_check, pnd.id_pn_fgpo_det, pn.`id_pn_fgpo`,pn.`number`,pnd.`value`,pnd.`vat`,pnd.`inv_number`,pnd.`note` 
                ,dsg.`design_code`,dsg.`design_display_name`
                FROM `tb_pn_fgpo_det` pnd
                INNER JOIN tb_pn_fgpo pn ON pn.`id_pn_fgpo`=pnd.`id_pn_fgpo`
                INNER JOIN tb_prod_order po ON po.`id_prod_order`=pnd.`id_report` AND pnd.`report_mark_type`='22'
                INNER JOIN `tb_prod_demand_design` pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
                INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
                WHERE pn.`id_report_status`= '6' AND pnd.`id_report`='" & id_po & "' AND pnd.report_mark_type='22' AND pn.`type`='1'"
                    Dim data_pop As DataTable = execute_query(query_pop, -1, True, "", "", "", "")
                    If data_pop.Rows.Count > 0 Then
                        FormInvoiceFGPODPPop.id_po = id_po
                        FormInvoiceFGPODPPop.ShowDialog()
                    End If

                    '
                    calculate()

                    If GVList.RowCount <= 0 Then
                        Close()
                    End If

                    calculate()
                End If
            End If
        Else
            BtnPrint.Visible = True
            BtnViewJournal.Visible = True
            BMark.Visible = True
            BtnSave.Visible = False
            PCAddDel.Visible = False
            DEDueDate.Properties.ReadOnly = True
            DERefDate.Properties.ReadOnly = True
            DEDueDateInv.Properties.ReadOnly = True
            '
            SLEPayType.Properties.ReadOnly = True
            SLEVendor.Properties.ReadOnly = True
            '

            Dim query As String = "SELECT pn.*,emp.`employee_name` FROM tb_pn_fgpo pn
INNER JOIN tb_m_user usr ON usr.`id_user`=pn.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
WHERE pn.`id_pn_fgpo`='" & id_invoice & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                TENumber.Text = data.Rows(0)("number").ToString
                DEDateCreated.EditValue = data.Rows(0)("created_date")
                DEDueDate.EditValue = data.Rows(0)("due_date")
                DEDueDateInv.EditValue = data.Rows(0)("due_date_inv")
                DERefDate.EditValue = data.Rows(0)("ref_date")

                SLEVendor.EditValue = data.Rows(0)("id_comp").ToString
                SLEPayType.EditValue = data.Rows(0)("type").ToString
                '
                MENote.Text = data.Rows(0)("note").ToString
            End If
        End If
    End Sub

    Sub load_det()
        Dim query As String = "
Select pnd.`id_prod_order`,pnd.id_acc,pnd.`id_report` As id_report,pnd.report_mark_type, pnd.`report_number`, pnd.`info_design`, pnd.`id_pn_fgpo_det`, pnd.`qty`,pnd.`vat`, pnd.`inv_number`,pnd.value_bef_kurs,pnd.kurs,pnd.id_currency,cur.currency, pnd.`note` 
FROM tb_pn_fgpo_det pnd
INNER JOIN tb_lookup_currency cur ON cur.id_currency=pnd.id_currency
WHERE pnd.`id_pn_fgpo`='" & id_invoice & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCList.DataSource = data
        GVList.BestFitColumns()
        calculate()
    End Sub

    Sub calculate()
        GVList.RefreshData()
        Dim tot As Decimal = 0.0
        Dim tot_vat As Decimal = 0.0
        Dim grand_tot As Decimal = 0.0

        Try
            tot = Decimal.Parse(GVList.Columns("valuex").SummaryItem.SummaryValue.ToString)

            TETotal.EditValue = tot
            tot_vat = Decimal.Parse(GVList.Columns("vat").SummaryItem.SummaryValue.ToString)
            TEVat.EditValue = tot_vat
            grand_tot = tot + tot_vat
            TEGrandTotal.EditValue = grand_tot

            GVList.BestFitColumns()
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    Sub load_vendor()
        Dim query As String = "SELECT c.id_comp,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name  
                                FROM tb_m_comp c
                                WHERE c.id_comp_cat='1' "
        viewSearchLookupQuery(SLEVendor, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        'check
        Dim is_ok As Boolean = True
        For i = 0 To GVList.RowCount - 1
            If GVList.GetRowCellValue(i, "inv_number").ToString = "" Or GVList.GetRowCellValue(i, "id_currency").ToString = "" Or GVList.GetRowCellValue(i, "id_acc").ToString = "" Then
                is_ok = False
            End If
        Next

        Dim is_not_mapping As Boolean = False

        Dim q_pay As String = "SELECT id_acc_dp,id_acc_ap FROM tb_m_comp WHERE id_comp='" & SLEVendor.EditValue.ToString & "'"
        Dim dt_pay As DataTable = execute_query(q_pay, -1, True, "", "", "", "")

        If SLEPayType.EditValue.ToString = "1" Then 'DP
            If dt_pay.Rows(0)("id_acc_dp").ToString = "" Then
                is_not_mapping = True
            End If
        Else 'Payment
            If dt_pay.Rows(0)("id_acc_ap").ToString = "" Then
                is_not_mapping = True
            End If
        End If

        Dim is_dup As Boolean = False
        If is_ok Then
            'check on grid
            Dim inv_number As String = ""
            For i = 0 To GVList.RowCount - 1
                'can duplicate
                If Not GVList.GetRowCellValue(i, "report_mark_type").ToString = "199" Then
                    If Not inv_number = "" Then
                        inv_number += ","
                    End If
                    inv_number += "'" & GVList.GetRowCellValue(i, "inv_number").ToString & "'"
                End If
            Next

            'check on db
            Dim check_q As String = "SELECT * FROM tb_pn_fgpo_det pnd
INNER JOIN tb_pn_fgpo pn ON pn.`id_pn_fgpo`=pnd.`id_pn_fgpo`
WHERE pn.`id_report_status`!=5 AND inv_number IN (" & inv_number & ") AND pn.id_pn_fgpo!='" & id_invoice & "'"
            Dim dt_q As DataTable = execute_query(check_q, -1, True, "", "", "", "")
            If dt_q.Rows.Count > 0 Then
                is_dup = True
            End If
            'end of check duplicate
        End If

        If Not is_ok Then
            warningCustom("Please fill all value")
        ElseIf is_dup Then
            warningCustom("Invoice number duplicate")
        ElseIf is_not_mapping Then
            warningCustom("This vendor AP account is not set.")
        Else
            If id_invoice = "-1" Then
                'new
                'header
                Dim query As String = "INSERT INTO `tb_pn_fgpo`(`type`,`doc_type`,`created_by`,`created_date`,`note`,`id_report_status`,`id_comp`,`due_date`,`due_date_inv`,`ref_date`)
VALUES ('" & SLEPayType.EditValue.ToString & "','" & doc_type & "','" & id_user & "',NOW(),'" & addSlashes(MENote.Text) & "','1','" & SLEVendor.EditValue.ToString & "','" & Date.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & Date.Parse(DEDueDateInv.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & Date.Parse(DERefDate.EditValue.ToString).ToString("yyyy-MM-dd") & "'); SELECT LAST_INSERT_ID(); "
                id_invoice = execute_query(query, 0, True, "", "", "", "")
                'detail
                query = ""
                For i = 0 To GVList.RowCount - 1 '
                    query += "INSERT INTO `tb_pn_fgpo_det`(`id_pn_fgpo`,id_prod_order,`id_acc`,`id_report`,`report_mark_type`,report_number,info_design,qty,id_currency,value_bef_kurs,kurs,`value`,`vat`,`inv_number`,`note`)
VALUES('" & id_invoice & "','" & GVList.GetRowCellValue(i, "id_acc").ToString & "','" & GVList.GetRowCellValue(i, "id_prod_order").ToString & "','" & GVList.GetRowCellValue(i, "id_report").ToString & "','" & GVList.GetRowCellValue(i, "report_mark_type").ToString & "','" & GVList.GetRowCellValue(i, "report_number").ToString & "','" & GVList.GetRowCellValue(i, "info_design").ToString & "','" & decimalSQL(GVList.GetRowCellValue(i, "qty").ToString) & "','" & GVList.GetRowCellValue(i, "id_currency").ToString & "','" & decimalSQL(GVList.GetRowCellValue(i, "value_bef_kurs").ToString) & "','" & decimalSQL(GVList.GetRowCellValue(i, "kurs").ToString) & "','" & decimalSQL(GVList.GetRowCellValue(i, "valuex").ToString) & "','" & decimalSQL(GVList.GetRowCellValue(i, "vat").ToString) & "','" & addSlashes(GVList.GetRowCellValue(i, "inv_number").ToString) & "','" & addSlashes(GVList.GetRowCellValue(i, "note").ToString) & "');"
                Next
                execute_non_query(query, True, "", "", "", "")
                '
                query = "CALL gen_number('" & id_invoice & "','189')"
                execute_non_query(query, True, "", "", "", "")
                submit_who_prepared("189", id_invoice, id_user)
                '
                infoCustom("BPL Created")
                Close()
            Else
                'edit
                Dim query As String = ""
            End If
        End If
    End Sub

    Private Sub BtnViewJournal_Click(sender As Object, e As EventArgs) Handles BtnViewJournal.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            WHERE ad.report_mark_type=189 AND ad.id_report=" + id_invoice + "
            GROUP BY ad.id_acc_trans ", 0, True, "", "", "", "")
        Catch ex As Exception
            id_acc_trans = ""
        End Try

        If id_acc_trans <> "" Then
            Dim s As New ClassShowPopUp()
            FormViewJournal.is_enable_view_doc = False
            FormViewJournal.BMark.Visible = False
            s.id_report = id_acc_trans
            s.report_mark_type = "36"
            s.show()
        Else
            warningCustom("Auto journal not found.")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormInvoiceFGPODP_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.report_mark_type = "189"
        FormReportMark.is_view = is_view
        FormReportMark.id_report = id_invoice
        FormReportMark.ShowDialog()
    End Sub

    Private Sub SMEditCost_Click(sender As Object, e As EventArgs) Handles SMEditCost.Click
        If GVList.RowCount > 0 Then
            FormInvoiceFGPODPSplit.ShowDialog()
        End If
    End Sub

    Private Sub BDP_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub BDelete_Click(sender As Object, e As EventArgs) 
        If GVList.RowCount > 0 Then
            GVList.DeleteSelectedRows()
            calculate()
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click

    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        FormInvoiceFGPOAdd.ShowDialog()
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If GVList.RowCount > 0 Then
            GVList.DeleteSelectedRows()
            calculate()
        End If
    End Sub

    Private Sub BAddNewRow_Click(sender As Object, e As EventArgs) Handles BAddNewRow.Click
        Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
        '
        newRow("qty") = 1
        newRow("id_currency") = 1
        newRow("kurs") = 1
        newRow("value_bef_kurs") = 0
        '
        newRow("vat") = 0
        newRow("inv_number") = ""
        newRow("note") = ""

        TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
    End Sub

    Private Sub GVList_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVList.CellValueChanged
        If e.Column.FieldName = "value_bef_kurs" Or e.Column.FieldName = "kurs" Or e.Column.FieldName = "vat" Then
            calculate()
        End If
    End Sub
End Class