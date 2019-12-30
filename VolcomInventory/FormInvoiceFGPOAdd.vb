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
            If XTCAdd.SelectedTabPageIndex = 0 Then 'fgpo
                newRow("id_prod_order") = SLEFGPO.EditValue.ToString
                newRow("id_report") = SLEFGPO.EditValue.ToString
                newRow("report_mark_type") = "22"
                newRow("report_number") = SLEFGPO.Text
                newRow("info_design") = TEInfoDesign.Text
                '
                newRow("qty") = TEQty.EditValue
                newRow("id_currency") = LECurrency.EditValue.ToString
                newRow("currency") = LECurrency.Text
                newRow("kurs") = TEKurs.EditValue
                newRow("value_bef_kurs") = TEBeforeKurs.EditValue
                '
                newRow("value") = TEAfterKurs.EditValue
                newRow("vat") = TEVat.EditValue
                newRow("inv_number") = ""
                newRow("note") = ""
            Else
                newRow("id_prod_order") = SLEFGPO.EditValue.ToString
                newRow("id_report") = SLEFGPO.EditValue.ToString
                newRow("report_mark_type") = "22"
                newRow("report_number") = SLEFGPO.Text
                newRow("info_design") = TEInfoDesign.Text
                '
                newRow("qty") = TEQty.EditValue
                newRow("id_currency") = LECurrency.EditValue.ToString
                newRow("currency") = LECurrency.Text
                newRow("kurs") = TEKurs.EditValue
                newRow("value_bef_kurs") = TEBeforeKurs.EditValue
                '
                newRow("value") = TEAfterKurs.EditValue
                newRow("vat") = TEVat.EditValue
                newRow("inv_number") = ""
                newRow("note") = ""
            End If

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

    Private Sub FormInvoiceFGPOAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEVATPercent.EditValue = 0.00
        TEVat.EditValue = 0.00
        TEQty.EditValue = 1
        '
        TEKurs.EditValue = 0.00
        TEBeforeKurs.EditValue = 0.00
        TEAfterKurs.EditValue = 0.00
        '
        view_currency()
        view_fgpo()
    End Sub

    Private Sub view_currency()
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        viewLookupQuery(LECurrency, query, 0, "currency", "id_currency")
    End Sub

    Sub view_fgpo()
        Dim query As String = "SELECT po.`id_prod_order`,po.`prod_order_number`,dsg.`design_display_name`,dsg.`design_code`
FROM tb_prod_order po 
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
WHERE po.`id_report_status`='6'
GROUP BY po.`id_prod_order`"
        viewSearchLookupQuery(SLEFGPO, query, "id_prod_order", "prod_order_number", "id_prod_order")
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
            TEInfoDesign.Text = SLEFGPO.Properties.View.GetFocusedRowCellValue("design_display_name").ToString

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

    Private Sub LECurrency_EditValueChanged(sender As Object, e As EventArgs) Handles LECurrency.EditValueChanged
        load_kurs()
    End Sub

    Private Sub TEKurs_EditValueChanged(sender As Object, e As EventArgs) Handles TEKurs.EditValueChanged
        If Not TEVATPercent.EditValue = 0 Then
            calculate_fgpo(True)
        Else
            calculate_fgpo(False)
        End If
    End Sub
End Class