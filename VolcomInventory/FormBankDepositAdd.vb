Public Class FormBankDepositAdd
    Public action As String = "-1"
    Public id_pop_up As String = "-1"
    Public id_coa_type As String = "1"
    Public is_valas As Boolean = False
    Public kurs As Decimal = 1.0

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FormBankDepositAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormBankDepositAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCOA()
        viewComp()
        viewDK()
        actionLoad()
    End Sub

    Sub actionLoad()
        'focus
        ActiveControl = SLECOA

        'option
        If id_pop_up = "1" Then
            'bpj toko cabang
            SLEComp.Enabled = False
        End If
        TxtBefKurs.EditValue = 0.00
        If Not is_valas Then
            TxtBefKurs.Enabled = False
        Else
            TxtAmount.Enabled = False
        End If


        If action = "ins" Then
            'coa
            Dim id_acc As String = SLECOA.EditValue.ToString
            TxtCOA.Text = execute_query("SELECT acc_name FROM tb_a_acc WHERE id_acc='" + id_acc + "' ", 0, True, "", "", "", "")

            'comp
            If id_pop_up = "-1" Then 'BBM
                SLEComp.EditValue = "-1"
                TxtComp.Text = ""
                If FormBankDepositDet.SLEUnit.EditValue.ToString = "1" Then
                    SLEComp.EditValue = "1"
                Else
                    Dim id_comp_tag_selected As String = execute_query("SELECT id_comp FROM tb_coa_tag WHERE id_coa_tag='" + FormBankDepositDet.SLEUnit.EditValue.ToString + "' ", 0, True, "", "", "", "")
                    SLEComp.EditValue = id_comp_tag_selected
                End If
            End If
            TxtComp.Text = execute_query("SELECT comp_number FROM tb_m_comp WHERE id_comp='" + SLEComp.EditValue.ToString + "' ", 0, True, "", "", "", "")

            TxtReff.Text = ""
            TxtDescription.Text = ""
            TxtSupplier.Text = ""

            'd/k
            LEDK.ItemIndex = LEDK.Properties.GetDataSourceRowIndex("id_dc", "1")
            TxtAmount.EditValue = 0.00
        Else
            If id_pop_up = "-1" Then
                'BBM
                SLECOA.EditValue = FormBankDepositDet.GVList.GetFocusedRowCellValue("id_acc").ToString
                TxtCOA.Text = FormBankDepositDet.GVList.GetFocusedRowCellValue("acc_name").ToString
                TxtReff.Text = FormBankDepositDet.GVList.GetFocusedRowCellValue("number").ToString
                TxtDescription.Text = FormBankDepositDet.GVList.GetFocusedRowCellValue("note").ToString
                TxtSupplier.Text = FormBankDepositDet.GVList.GetFocusedRowCellValue("vendor").ToString
                TxtComp.Text = FormBankDepositDet.GVList.GetFocusedRowCellValue("comp_number").ToString
                SLEComp.EditValue = FormBankDepositDet.GVList.GetFocusedRowCellValue("id_comp").ToString
                LEDK.ItemIndex = LEDK.Properties.GetDataSourceRowIndex("id_dc", FormBankDepositDet.GVList.GetFocusedRowCellValue("id_dc").ToString)
                TxtBefKurs.EditValue = FormBankDepositDet.GVList.GetFocusedRowCellValue("value_bef_kurs")
                TxtAmount.EditValue = FormBankDepositDet.GVList.GetFocusedRowCellValue("value_view")
            ElseIf id_pop_up = "1" Then
                'BPJ Toko
                SLECOA.EditValue = FormSalesBranchDet.GVData.GetFocusedRowCellValue("id_acc").ToString
                TxtCOA.Text = FormSalesBranchDet.GVData.GetFocusedRowCellValue("coa_account").ToString
                TxtReff.Text = FormSalesBranchDet.GVData.GetFocusedRowCellValue("number").ToString
                TxtDescription.Text = FormSalesBranchDet.GVData.GetFocusedRowCellValue("note").ToString
                TxtSupplier.Text = FormSalesBranchDet.GVData.GetFocusedRowCellValue("vendor").ToString
                TxtComp.Text = FormSalesBranchDet.GVData.GetFocusedRowCellValue("comp_number").ToString
                SLEComp.EditValue = FormSalesBranchDet.GVData.GetFocusedRowCellValue("id_comp").ToString
                LEDK.ItemIndex = LEDK.Properties.GetDataSourceRowIndex("id_dc", FormSalesBranchDet.GVData.GetFocusedRowCellValue("id_dc").ToString)
                TxtAmount.EditValue = FormSalesBranchDet.GVData.GetFocusedRowCellValue("value")
            End If
        End If
    End Sub

    Sub viewCOA()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 AND a.id_coa_type='" + id_coa_type + "' "
        viewSearchLookupQuery(SLECOA, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Sub viewComp()
        Dim query As String = "SELECT c.id_comp, c.comp_number,c.comp_name FROM tb_m_comp c WHERE 1=1 "
        If id_pop_up = "1" Then
            Dim id_comp_tag As String = execute_query("SELECT id_comp FROM tb_coa_tag WHERE id_coa_tag='" + FormSalesBranchDet.SLEUnit.EditValue.ToString + "' ", 0, True, "", "", "", "")
            query += "AND c.id_comp='" + id_comp_tag + "' "
        End If
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
        'cek value pph
        Dim qph As String = "SELECT * 
        FROM tb_a_acc a
        INNER JOIN tb_lookup_tax_report tr ON tr.id_tax_report = a.id_tax_report
        WHERE tr.id_type=1 AND a.id_acc='" + SLECOA.EditValue.ToString + "' "
        Dim dph As DataTable = execute_query(qph, -1, True, "", "", "", "")
        Dim amo As Decimal = 0.00
        If dph.Rows.Count > 0 Then
            amo = Math.Floor(TxtAmount.EditValue)
        Else
            amo = TxtAmount.EditValue
        End If

        If id_pop_up = "-1" Then
            'BBM
            If action = "ins" Then
                Dim newRow As DataRow = (TryCast(FormBankDepositDet.GCList.DataSource, DataTable)).NewRow()
                newRow("id_report") = "0"
                newRow("id_report_det") = "0"
                newRow("report_mark_type") = "0"
                newRow("report_mark_type_name") = "-"
                newRow("number") = addSlashes(TxtReff.Text)
                If TxtComp.Text = "" Then
                    newRow("id_comp") = "0"
                Else
                    newRow("id_comp") = SLEComp.EditValue.ToString
                End If
                newRow("vendor") = TxtSupplier.Text
                newRow("id_acc") = SLECOA.EditValue.ToString
                newRow("acc_name") = TxtCOA.Text
                newRow("acc_description") = SLECOA.Text
                newRow("comp_number") = TxtComp.Text
                newRow("total_rec") = 0
                If LEDK.EditValue.ToString = "1" Then
                    newRow("value") = amo * -1
                    newRow("balance_due") = amo * -1
                Else
                    newRow("value") = amo
                    newRow("balance_due") = amo
                End If
                newRow("note") = addSlashes(TxtDescription.Text)
                newRow("id_dc") = LEDK.EditValue.ToString
                newRow("dc_code") = LEDK.Text
                newRow("value_view") = amo
                newRow("value_bef_kurs") = TxtBefKurs.EditValue
                TryCast(FormBankDepositDet.GCList.DataSource, DataTable).Rows.Add(newRow)
                FormBankDepositDet.GCList.RefreshDataSource()
                FormBankDepositDet.GVList.RefreshData()
                FormBankDepositDet.calculate_amount()
                actionLoad()
            Else
                'update
                FormBankDepositDet.GVList.SetFocusedRowCellValue("number", addSlashes(TxtReff.Text))
                If TxtComp.Text = "" Then
                    FormBankDepositDet.GVList.SetFocusedRowCellValue("id_comp", "0")
                Else
                    FormBankDepositDet.GVList.SetFocusedRowCellValue("id_comp", SLEComp.EditValue.ToString)
                End If
                FormBankDepositDet.GVList.SetFocusedRowCellValue("vendor", TxtSupplier.Text)
                FormBankDepositDet.GVList.SetFocusedRowCellValue("id_acc", SLECOA.EditValue.ToString)
                FormBankDepositDet.GVList.SetFocusedRowCellValue("acc_name", TxtCOA.Text)
                FormBankDepositDet.GVList.SetFocusedRowCellValue("acc_description", SLECOA.Text)
                FormBankDepositDet.GVList.SetFocusedRowCellValue("comp_number", TxtComp.Text)
                FormBankDepositDet.GVList.SetFocusedRowCellValue("total_rec", 0)
                If LEDK.EditValue.ToString = "1" Then
                    FormBankDepositDet.GVList.SetFocusedRowCellValue("value", amo * -1)
                    FormBankDepositDet.GVList.SetFocusedRowCellValue("balance_due", amo * -1)
                Else
                    FormBankDepositDet.GVList.SetFocusedRowCellValue("value", amo)
                    FormBankDepositDet.GVList.SetFocusedRowCellValue("balance_due", amo)
                End If
                FormBankDepositDet.GVList.SetFocusedRowCellValue("note", addSlashes(TxtDescription.Text))
                FormBankDepositDet.GVList.SetFocusedRowCellValue("id_dc", LEDK.EditValue.ToString)
                FormBankDepositDet.GVList.SetFocusedRowCellValue("dc_code", LEDK.Text)
                FormBankDepositDet.GVList.SetFocusedRowCellValue("value_view", amo)
                FormBankDepositDet.GVList.SetFocusedRowCellValue("value_bef_kurs", TxtBefKurs.EditValue)
                FormBankDepositDet.GCList.RefreshDataSource()
                FormBankDepositDet.GVList.RefreshData()
                FormBankDepositDet.calculate_amount()
                Close()
            End If
        ElseIf id_pop_up = "1" Then
            'Sales Volcom Store
            If action = "ins" Then
                Dim newRow As DataRow = (TryCast(FormSalesBranchDet.GCData.DataSource, DataTable)).NewRow()
                newRow("id_sales_branch_det") = "0"
                newRow("id_sales_branch_ref_det") = "0"
                newRow("id_sales_branch") = "0"
                newRow("id_acc") = SLECOA.EditValue.ToString
                newRow("coa_account") = TxtCOA.Text
                newRow("coa_description") = SLECOA.Text
                newRow("id_dc") = LEDK.EditValue.ToString
                newRow("dc_code") = LEDK.Text.ToString
                If TxtComp.Text = "" Then
                    newRow("id_comp") = "0"
                Else
                    newRow("id_comp") = SLEComp.EditValue.ToString
                End If
                newRow("comp_number") = TxtComp.Text
                newRow("note") = TxtDescription.Text
                newRow("value") = amo
                newRow("id_report") = "0"
                newRow("number") = TxtReff.Text
                newRow("report_mark_type") = "0"
                newRow("vendor") = TxtSupplier.Text
                TryCast(FormSalesBranchDet.GCData.DataSource, DataTable).Rows.Add(newRow)
                FormSalesBranchDet.GCData.RefreshDataSource()
                FormSalesBranchDet.GVData.RefreshData()
                FormSalesBranchDet.calculate()
                actionLoad()
            Else
                FormSalesBranchDet.GVData.SetFocusedRowCellValue("id_acc", SLECOA.EditValue.ToString)
                FormSalesBranchDet.GVData.SetFocusedRowCellValue("coa_account", TxtCOA.Text)
                FormSalesBranchDet.GVData.SetFocusedRowCellValue("coa_description", SLECOA.Text)
                FormSalesBranchDet.GVData.SetFocusedRowCellValue("id_dc", LEDK.EditValue.ToString)
                FormSalesBranchDet.GVData.SetFocusedRowCellValue("dc_code", LEDK.Text.ToString)
                If TxtComp.Text = "" Then
                    FormSalesBranchDet.GVData.SetFocusedRowCellValue("id_comp", "0")
                Else
                    FormSalesBranchDet.GVData.SetFocusedRowCellValue("id_comp", SLEComp.EditValue.ToString)
                End If
                FormSalesBranchDet.GVData.SetFocusedRowCellValue("comp_number", TxtComp.Text)
                FormSalesBranchDet.GVData.SetFocusedRowCellValue("note", TxtDescription.Text)
                FormSalesBranchDet.GVData.SetFocusedRowCellValue("value", amo)
                FormSalesBranchDet.GVData.SetFocusedRowCellValue("id_report", "0")
                FormSalesBranchDet.GVData.SetFocusedRowCellValue("number", TxtReff.Text)
                FormSalesBranchDet.GVData.SetFocusedRowCellValue("report_mark_type", "0")
                FormSalesBranchDet.GVData.SetFocusedRowCellValue("vendor", TxtSupplier.Text)
                FormSalesBranchDet.GCData.RefreshDataSource()
                FormSalesBranchDet.GVData.RefreshData()
                FormSalesBranchDet.calculate()
                Close()
            End If
        End If
    End Sub

    Private Sub BtnClearComp_Click(sender As Object, e As EventArgs) Handles BtnClearComp.Click
        TxtComp.Text = ""
        SLEComp.EditValue = Nothing
    End Sub

    Private Sub TxtAutoFill_Click(sender As Object, e As EventArgs) Handles TxtAutoFill.Click
        TxtDescription.Text = SLECOA.Text
    End Sub

    Private Sub TxtBefKurs_EditValueChanged(sender As Object, e As EventArgs) Handles TxtBefKurs.EditValueChanged
        If is_valas Then
            TxtAmount.EditValue = TxtBefKurs.EditValue * kurs
        End If
    End Sub
End Class