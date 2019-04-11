Public Class FormInvoiceFGPODP
    Public id_dp As String = "-1"

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Sub load_trans_type()
        Dim query As String = "SELECT id_pay_type,pay_type FROM tb_lookup_pay_type"
        viewSearchLookupQuery(SLEPayType, query, "id_pay_type", "pay_type", "id_pay_type")
    End Sub

    Sub load_report_type()
        Dim query As String = "SELECT report_mark_type,report_mark_type_name FROM `tb_lookup_report_mark_type` WHERE is_payable='1'"
        viewSearchLookupQuery(SLEReportType, query, "report_mark_type", "report_mark_type_name", "report_mark_type")
    End Sub

    Private Sub FormInvoiceFGPODP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEDateCreated.EditValue = Now
        TEPayNumber.Text = "[auto generate]"
        load_pay_from()
        load_vendor()
        load_trans_type()
        load_report_type()
        load_det()
        '
        If id_dp = "-1" Then
            'new
            For i = 0 To FormInvoiceFGPO.GVDPFGPO.RowCount - 1
                Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                newRow("id_report") = FormInvoiceFGPO.GVDPFGPO.GetRowCellValue(i, "id_prod_order").ToString
                newRow("type") = "1"
                newRow("number") = FormInvoiceFGPO.GVDPFGPO.GetRowCellValue(i, "prod_order_number").ToString
                newRow("description") = FormInvoiceFGPO.GVDPFGPO.GetRowCellValue(i, "design_display_name").ToString
                newRow("code") = FormInvoiceFGPO.GVDPFGPO.GetRowCellValue(i, "design_code").ToString
                newRow("value") = FormInvoiceFGPO.GVDPFGPO.GetRowCellValue(i, "dp_amount").ToString
                newRow("inv_number") = ""
                newRow("note") = ""
                TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
            Next
            calculate()
        Else
            'edit
        End If
    End Sub

    Sub load_det()
        Dim query As String = "SELECT pnd.`id_prod_order` AS id_report,pnd.`type`,po.`prod_order_number` AS number,dsg.`design_code` AS `code`,dsg.`design_display_name` AS description,pnd.`id_pn_fgpo_det`,pnd.`value`,pnd.`inv_number`,pnd.`note` FROM tb_pn_fgpo_det pnd
INNER JOIN tb_prod_order po ON po.`id_prod_order`=pnd.`id_prod_order` 
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
WHERE pnd.`id_pn_fgpo`=" & id_dp
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCList.DataSource = data
        GVList.BestFitColumns()
    End Sub

    Sub calculate()
        Dim tot As Decimal = 0.0

        Try
            tot = GVList.Columns("value").SummaryItem.SummaryValue
            TETotal.EditValue = tot
        Catch ex As Exception

        End Try
    End Sub

    Sub load_pay_from()
        Dim query As String = "SELECT id_acc,acc_name,acc_description FROM `tb_a_acc` WHERE id_status='1' AND id_is_det='2'"
        viewSearchLookupQuery(SLEPayFrom, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Sub load_vendor()
        Dim query As String = "SELECT cc.id_comp_contact,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name  
                                FROM tb_m_comp c
                                INNER JOIN tb_m_comp_contact cc ON cc.`id_comp`=c.`id_comp` AND cc.`is_default`='1'
                                WHERE c.id_comp_cat='1' "
        viewSearchLookupQuery(SLEVendor, query, "id_comp_contact", "comp_name", "id_comp_contact")
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        'check
        Dim is_ok As Boolean = True
        For i = 0 To GVList.RowCount - 1
            If GVList.GetRowCellValue(i, "inv_number").ToString = "" Then
                is_ok = False
            End If
        Next
        'check if duplicate
        For i = 0 To GVList.RowCount - 1
            For j = 0 To GVList.RowCount - 1
                If Not i = j Then
                    If GVList.GetRowCellValue(i, "inv_number").ToString = GVList.GetRowCellValue(j, "inv_number").ToString Then

                    End If
                End If
            Next
        Next

        If is_ok Then

        Else
            warningCustom("Please fill invoice number")
        End If
    End Sub
End Class