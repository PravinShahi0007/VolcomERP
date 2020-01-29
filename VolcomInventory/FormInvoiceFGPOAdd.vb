Public Class FormInvoiceFGPOAdd
    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormInvoiceFGPOAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BPick_Click(sender As Object, e As EventArgs) Handles BPick.Click
        Try
            Dim newRow As DataRow = (TryCast(FormInvoiceFGPODP.GCList.DataSource, DataTable)).NewRow()
            '
            newRow("id_prod_order") = SLEFGPO.EditValue.ToString
            newRow("id_report") = SLEFGPO.EditValue.ToString

            newRow("report_mark_type") = SLEReportType.EditValue.ToString
            newRow("report_number") = SLEFGPO.Text
            newRow("info_design") = TEInfoDesign.Text
            '
            newRow("qty") = TEQty.EditValue
            newRow("id_currency") = LECurrency.EditValue.ToString
            newRow("kurs") = TEKurs.EditValue
            newRow("value_bef_kurs") = TEBeforeKurs.EditValue
            '
            newRow("vat") = TEVat.EditValue
            newRow("inv_number") = ""
            newRow("note") = ""

            TryCast(FormInvoiceFGPODP.GCList.DataSource, DataTable).Rows.Add(newRow)
            FormInvoiceFGPODP.calculate()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Close()
    End Sub

    Sub load_kurs()
        'check kurs first
        Dim query_kurs As String = "SELECT * FROM tb_kurs_trans WHERE DATE(created_date) = DATE(NOW()) ORDER BY id_kurs_trans DESC"
        Dim data_kurs As DataTable = execute_query(query_kurs, -1, True, "", "", "", "")

        If Not data_kurs.Rows.Count > 0 Then
            warningCustom("Today transaction kurs still not submitted.")
            TEKurs.EditValue = 0.00
        Else
            If LECurrency.EditValue.ToString = "2" Then
                TEKurs.EditValue = data_kurs.Rows(0)("kurs_trans")
            Else
                TEKurs.EditValue = 1
            End If
        End If
    End Sub

    Sub load_report_type()
        Dim query As String = "SELECT report_mark_type,report_mark_type_name FROM `tb_lookup_report_mark_type` WHERE is_payable_bpl='1'"
        viewSearchLookupQuery(SLEReportType, query, "report_mark_type", "report_mark_type_name", "report_mark_type")
    End Sub

    Private Sub FormInvoiceFGPOAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEVATPercent.EditValue = 0.00
        TEVat.EditValue = 0.00
        TEQty.EditValue = 1
        '
        If FormInvoiceFGPODP.GVList.RowCount >= 1 Then
            TEKurs.EditValue = FormInvoiceFGPODP.GVList.GetRowCellValue(0, "kurs")
        Else
            TEKurs.EditValue = 0.00
        End If

        TEBeforeKurs.EditValue = 0.00
        TEAfterKurs.EditValue = 0.00

        load_report_type()

        view_currency()
        view_po()

        If FormInvoiceFGPODP.GVList.RowCount >= 1 Then
            LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", FormInvoiceFGPODP.GVList.GetRowCellValue(0, "id_currency").ToString)
        End If
    End Sub

    Private Sub view_currency()
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        viewLookupQuery(LECurrency, query, 0, "currency", "id_currency")
    End Sub

    Sub view_po()
        Dim query As String = ""

        If SLEReportType.EditValue.ToString = "22" Then 'fgpo
            query = "SELECT po.`id_prod_order` AS id_report,po.`prod_order_number` AS report_number,dsg.`design_display_name` AS description,dsg.`design_code` AS info
FROM tb_prod_order po 
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
WHERE po.`id_report_status`='6'
GROUP BY po.`id_prod_order`"
        ElseIf SLEReportType.EditValue.ToString = "13" Then 'material
            query = "SELECT po.`id_mat_purc` AS id_report,po.`mat_purc_number` AS report_number,GROUP_CONCAT(TRIM(md.mat_det_name) SEPARATOR '\n') AS description,c.comp_name AS info
FROM tb_mat_purc_det pod 
INNER JOIN tb_m_mat_det_price mdp ON mdp.id_mat_det_price=pod.id_mat_det_price
INNER JOIN tb_m_mat_det md ON md.id_mat_det=mdp.id_mat_det
INNER JOIN tb_mat_purc po ON pod.id_mat_purc=po.id_mat_purc 
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=po.id_comp_contact_to
INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp
WHERE po.`id_report_status`='6'
GROUP BY pod.id_mat_purc"
        End If

        viewSearchLookupQuery(SLEFGPO, query, "id_report", "report_number", "id_report")
        Try
            SLEFGPO.EditValue = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub SLEFGPO_EditValueChanged(sender As Object, e As EventArgs) Handles SLEFGPO.EditValueChanged
        If Not TEVATPercent.EditValue = 0 Then
            calculate_fgpo(True)
        Else
            calculate_fgpo(False)
        End If
    End Sub

    Sub calculate_fgpo(ByVal is_vatp As Boolean)
        Dim bef_kurs As Decimal = 0.00
        Dim aft_kurs As Decimal = 0.00
        Dim kurs As Decimal = 0.00
        '
        Dim vat_perc As Decimal = 0.00
        Dim vat As Decimal = 0.00
        '
        Try
            TEInfoDesign.Text = SLEFGPO.Properties.View.GetFocusedRowCellValue("description").ToString

            bef_kurs = TEBeforeKurs.EditValue
            kurs = TEKurs.EditValue
            aft_kurs = bef_kurs * kurs
            TEAfterKurs.EditValue = aft_kurs
            '
            If is_vatp Then
                vat_perc = TEVATPercent.EditValue
                vat = aft_kurs * (vat_perc / 100)
                TEVat.EditValue = vat
                TEAfterVAT.EditValue = aft_kurs + vat
            Else
                vat = TEVat.EditValue
                TEAfterVAT.EditValue = aft_kurs + vat
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    Private Sub TEVATPercent_EditValueChanged(sender As Object, e As EventArgs) Handles TEVATPercent.EditValueChanged
        calculate_fgpo(True)
    End Sub

    Private Sub TEVat_EditValueChanged(sender As Object, e As EventArgs) Handles TEVat.EditValueChanged
        calculate_fgpo(False)
    End Sub

    Private Sub TEBeforeKurs_EditValueChanged(sender As Object, e As EventArgs) Handles TEBeforeKurs.EditValueChanged
        If Not TEVATPercent.EditValue = 0 Then
            calculate_fgpo(True)
        Else
            calculate_fgpo(False)
        End If
    End Sub

    'Private Sub LECurrency_EditValueChanged(sender As Object, e As EventArgs) Handles LECurrency.EditValueChanged
    '    load_kurs()
    'End Sub

    Private Sub TEKurs_EditValueChanged(sender As Object, e As EventArgs) Handles TEKurs.EditValueChanged
        If Not TEVATPercent.EditValue = 0 Then
            calculate_fgpo(True)
        Else
            calculate_fgpo(False)
        End If
    End Sub

    Private Sub SLEReportType_EditValueChanged(sender As Object, e As EventArgs) Handles SLEReportType.EditValueChanged
        view_po()
    End Sub
End Class