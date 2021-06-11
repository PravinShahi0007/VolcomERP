﻿Public Class FormBankWithdrawalAdd
    Public action As String = "-1"
    Dim id_coa_tag As String = FormBankWithdrawalDet.id_coa_tag

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FormBankWithdrawalAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormBankWithdrawalAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCOA()
        viewComp()
        viewDK()
        actionLoad()
    End Sub

    Sub actionLoad()
        view_currency()
        TEBeforeKurs.EditValue = 0.00
        TEKurs.EditValue = 1.0

        'focus
        ActiveControl = SLECOA

        If action = "ins" Then
            'coa
            Dim id_acc As String = SLECOA.EditValue.ToString
            TxtCOA.Text = execute_query("SELECT acc_name FROM tb_a_acc WHERE id_acc='" + id_acc + "' ", 0, True, "", "", "", "")

            'comp
            SLEComp.EditValue = "-1"
            TxtComp.Text = ""
            SLEComp.EditValue = "1"
            TxtComp.Text = execute_query("SELECT comp_number FROM tb_m_comp WHERE id_comp='" + SLEComp.EditValue.ToString + "' ", 0, True, "", "", "", "")

            TxtReff.Text = ""
            TxtDescription.Text = ""
            TxtSupplier.Text = ""

            'd/k
            LEDK.ItemIndex = LEDK.Properties.GetDataSourceRowIndex("id_dc", "1")
            TxtAmount.EditValue = 0.00
        Else
            SLECOA.EditValue = FormBankWithdrawalDet.GVList.GetFocusedRowCellValue("id_acc").ToString
            TxtCOA.Text = FormBankWithdrawalDet.GVList.GetFocusedRowCellValue("acc_name").ToString
            TxtReff.Text = FormBankWithdrawalDet.GVList.GetFocusedRowCellValue("number").ToString
            TxtDescription.Text = FormBankWithdrawalDet.GVList.GetFocusedRowCellValue("note").ToString
            TxtSupplier.Text = FormBankWithdrawalDet.GVList.GetFocusedRowCellValue("vendor").ToString
            TxtComp.Text = FormBankWithdrawalDet.GVList.GetFocusedRowCellValue("comp_number").ToString
            SLEComp.EditValue = FormBankWithdrawalDet.GVList.GetFocusedRowCellValue("id_comp").ToString
            LEDK.ItemIndex = LEDK.Properties.GetDataSourceRowIndex("id_dc", FormBankWithdrawalDet.GVList.GetFocusedRowCellValue("id_dc").ToString)
            TxtAmount.EditValue = FormBankWithdrawalDet.GVList.GetFocusedRowCellValue("value_view")
            '
            LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", FormBankWithdrawalDet.GVList.GetFocusedRowCellValue("id_currency").ToString)
            TEKurs.EditValue = FormBankWithdrawalDet.GVList.GetFocusedRowCellValue("kurs")
            TEBeforeKurs.EditValue = FormBankWithdrawalDet.GVList.GetFocusedRowCellValue("val_bef_kurs")
        End If
    End Sub

    Sub viewCOA()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 "
        If id_coa_tag = "1" Then
            query += " AND a.id_coa_type='1' "
        Else
            query += " AND a.id_coa_type='2' "
        End If
        viewSearchLookupQuery(SLECOA, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Sub viewComp()
        Dim query As String = "SELECT c.id_comp, c.comp_number,c.comp_name FROM tb_m_comp c"
        viewSearchLookupQuery(SLEComp, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub viewDK()
        Dim query As String = "SELECT * FROM tb_lookup_dc d WHERE d.id_dc=1 OR d.id_dc=2 "
        viewLookupQuery(LEDK, query, 0, "dc_code", "id_dc")
    End Sub

    Private Sub SLECOA_EditValueChanged(sender As Object, e As EventArgs) Handles SLECOA.EditValueChanged
        Try
            TxtCOA.Text = SLECOA.Properties.View.GetFocusedRowCellValue("acc_name").ToString
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SLEComp_EditValueChanged(sender As Object, e As EventArgs) Handles SLEComp.EditValueChanged
        Try
            TxtComp.Text = SLEComp.Properties.View.GetFocusedRowCellValue("comp_number").ToString
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        If TxtAmount.EditValue < 0 Then
            stopCustom("Value must be positive value")
        Else
            If action = "ins" Then
                Dim newRow As DataRow = (TryCast(FormBankWithdrawalDet.GCList.DataSource, DataTable)).NewRow()
                newRow("id_report") = "0"
                newRow("report_mark_type") = "0"
                newRow("id_acc") = SLECOA.EditValue.ToString
                newRow("vendor") = TxtSupplier.Text
                If TxtComp.Text = "" Then
                    newRow("id_comp") = "1"
                    newRow("comp_number") = "000"
                Else
                    newRow("id_comp") = SLEComp.EditValue.ToString
                    newRow("comp_number") = TxtComp.Text
                End If

                newRow("acc_name") = TxtCOA.Text
                newRow("acc_description") = SLECOA.Text
                newRow("number") = addSlashes(TxtReff.Text)
                newRow("total_pay") = 0

                If LEDK.EditValue.ToString = "2" Then
                    newRow("value") = TxtAmount.EditValue * -1
                    newRow("balance_due") = TxtAmount.EditValue * -1
                    newRow("val_bef_kurs") = TEBeforeKurs.EditValue * -1
                    newRow("value_view") = TxtAmount.EditValue * -1
                Else
                    newRow("value") = TxtAmount.EditValue
                    newRow("balance_due") = TxtAmount.EditValue
                    newRow("val_bef_kurs") = TEBeforeKurs.EditValue
                    newRow("value_view") = TxtAmount.EditValue
                End If
                newRow("kurs") = TEKurs.EditValue
                newRow("id_currency") = LECurrency.EditValue
                newRow("currency") = LECurrency.Text

                newRow("note") = addSlashes(TxtDescription.Text)
                newRow("id_dc") = LEDK.EditValue.ToString
                newRow("dc_code") = LEDK.Text
                TryCast(FormBankWithdrawalDet.GCList.DataSource, DataTable).Rows.Add(newRow)
                FormBankWithdrawalDet.GCList.RefreshDataSource()
                FormBankWithdrawalDet.GVList.RefreshData()
                FormBankWithdrawalDet.calculate_amount()
                actionLoad()
            Else
                'update
                FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("number", addSlashes(TxtReff.Text))
                If TxtComp.Text = "" Then
                    FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("id_comp", "0")
                Else
                    FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("id_comp", SLEComp.EditValue.ToString)
                End If
                FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("vendor", TxtSupplier.Text)
                FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("id_acc", SLECOA.EditValue.ToString)
                FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("acc_name", TxtCOA.Text)
                FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("acc_description", SLECOA.Text)
                FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("comp_number", TxtComp.Text)
                FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("total_rec", 0)
                If LEDK.EditValue.ToString = "2" Then
                    FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("value", TxtAmount.EditValue * -1)
                    FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("balance_due", TxtAmount.EditValue * -1)
                    FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("val_bef_kurs", TEBeforeKurs.EditValue * -1)
                    FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("value_view", TxtAmount.EditValue * -1)
                Else
                    FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("value", TxtAmount.EditValue)
                    FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("balance_due", TxtAmount.EditValue)
                    FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("val_bef_kurs", TEBeforeKurs.EditValue)
                    FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("value_view", TxtAmount.EditValue)
                End If
                FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("note", addSlashes(TxtDescription.Text))
                FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("id_dc", LEDK.EditValue.ToString)
                FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("dc_code", LEDK.Text)

                FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("id_currency", LECurrency.EditValue)
                FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("currency", LECurrency.Text)

                FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("kurs", TEKurs.EditValue)

                FormBankWithdrawalDet.GCList.RefreshDataSource()
                FormBankWithdrawalDet.GVList.RefreshData()
                FormBankWithdrawalDet.calculate_amount()
                Close()
            End If
        End If
    End Sub

    Private Sub TEKurs_EditValueChanged(sender As Object, e As EventArgs) Handles TEKurs.EditValueChanged
        calculate()
    End Sub

    Sub calculate()
        Try
            TxtAmount.EditValue = Math.Round(TEBeforeKurs.EditValue * TEKurs.EditValue, 2)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub view_currency()
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        viewLookupQuery(LECurrency, query, 0, "currency", "id_currency")
    End Sub

    Private Sub TEBeforeKurs_EditValueChanged(sender As Object, e As EventArgs) Handles TEBeforeKurs.EditValueChanged
        calculate()
    End Sub

    Private Sub BCalculateKurs_Click(sender As Object, e As EventArgs) Handles BCalculateKurs.Click
        If FormBankWithdrawalDet.GVList.RowCount > 0 Then
            Dim selisih As Decimal = 0.00
            For i = 0 To FormBankWithdrawalDet.GVList.RowCount - 1
                If Not FormBankWithdrawalDet.GVList.GetRowCellValue(i, "id_currency").ToString = "1" Then
                    selisih += Math.Round((FormBankWithdrawalDet.TEKurs.EditValue * FormBankWithdrawalDet.GVList.GetRowCellValue(i, "val_bef_kurs")), 2) - Math.Round((FormBankWithdrawalDet.GVList.GetRowCellValue(i, "kurs") * FormBankWithdrawalDet.GVList.GetRowCellValue(i, "val_bef_kurs")), 2)
                End If
            Next

            If Not selisih = 0 Then
                Dim newRow As DataRow = (TryCast(FormBankWithdrawalDet.GCList.DataSource, DataTable)).NewRow()
                newRow("id_report") = 0
                newRow("report_mark_type") = 0
                Dim q_acc As String = ""
                If selisih > 0 Then
                    'kerugian kurs
                    q_acc = "SELECT id_acc,acc_name,acc_description FROM tb_a_acc WHERE id_acc=(SELECT id_acc_rugi_kurs FROM tb_opt_accounting LIMIT 1)"
                Else
                    'keuntungan kurs
                    q_acc = "SELECT id_acc,acc_name,acc_description FROM tb_a_acc WHERE id_acc=(SELECT id_acc_untung_kurs FROM tb_opt_accounting LIMIT 1)"
                End If
                Dim dt_acc As DataTable = execute_query(q_acc, -1, True, "", "", "", "")

                newRow("id_acc") = dt_acc.Rows(0)("id_acc").ToString
                newRow("acc_name") = dt_acc.Rows(0)("acc_name").ToString
                newRow("acc_description") = dt_acc.Rows(0)("acc_description").ToString
                newRow("note") = dt_acc.Rows(0)("acc_description").ToString

                newRow("vendor") = get_company_x(get_company_contact_x(FormBankWithdrawalDet.SLEVendor.EditValue.ToString, "3"), "2")

                newRow("id_comp") = "1"
                newRow("comp_number") = "000"
                newRow("total_pay") = 0
                newRow("kurs") = 1
                newRow("id_currency") = "1"
                newRow("currency") = "Rp"
                newRow("val_bef_kurs") = selisih
                newRow("value") = selisih
                newRow("value_view") = selisih
                If selisih > 0 Then 'kerugian kurs
                    newRow("id_dc") = 1
                    newRow("dc_code") = "D"
                    newRow("balance_due") = selisih
                Else 'keuntungan kurs
                    newRow("id_dc") = 2
                    newRow("dc_code") = "K"
                    newRow("balance_due") = -selisih
                End If

                TryCast(FormBankWithdrawalDet.GCList.DataSource, DataTable).Rows.Add(newRow)

                FormBankWithdrawalDet.GCList.RefreshDataSource()
                FormBankWithdrawalDet.GVList.RefreshData()
                FormBankWithdrawalDet.calculate_amount()
                Close()
            End If
        End If
    End Sub

    Private Sub LECurrency_EditValueChanged(sender As Object, e As EventArgs) Handles LECurrency.EditValueChanged
        Try
            If Not LECurrency.EditValue.ToString = "1" Then
                TEKurs.EditValue = FormBankWithdrawalDet.TEKurs.EditValue
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class