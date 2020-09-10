Public Class FormProductionMRSPickPO
    Private Sub FormProductionMRSPickPO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewVendor()
    End Sub

    Private Sub FormProductionMRSPickPO_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        Dim query_where As String = ""

        If Not SLEVendor.EditValue.ToString = "0" Then
            query_where += " AND cc.id_comp='" & SLEVendor.EditValue.ToString & "'"
        End If

        Dim query As String = "
            SELECT a.id_prod_order, CONCAT(comp.comp_number, '-', comp.comp_name) AS vendor, a.prod_order_number, d.design_code, d.design_display_name, a.prod_order_date
            FROM tb_prod_order AS a
            INNER JOIN tb_prod_order_det AS pod ON pod.id_prod_order = a.id_prod_order
            INNER JOIN tb_prod_demand_design AS b ON a.id_prod_demand_design = b.id_prod_demand_design
            INNER JOIN tb_m_design AS d ON b.id_design = d.id_design
            LEFT JOIN tb_prod_order_wo AS wo ON wo.id_prod_order = a.id_prod_order AND wo.is_main_vendor = '1'
            LEFT JOIN tb_m_ovh_price AS ovh_p ON ovh_p.id_ovh_price = wo.id_ovh_price 
            LEFT JOIN tb_m_comp_contact AS cc ON cc.id_comp_contact = ovh_p.id_comp_contact
            LEFT JOIN tb_m_comp AS comp ON comp.id_comp = cc.id_comp
            WHERE a.id_report_status = 6 " + query_where + "
            GROUP BY a.id_prod_order
            ORDER BY a.id_prod_order DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCProd.DataSource = data

        GVProd.BestFitColumns()
    End Sub

    Sub viewVendor()
        Dim query As String = ""
        query += "SELECT ('0') AS id_comp, ('-') AS comp_number, ('All Vendor') AS comp_name, ('ALL Vendor') AS comp_name_label 
        UNION "
        query += "SELECT comp.id_comp,comp.comp_number, comp.comp_name, CONCAT_WS(' - ', comp.comp_number,comp.comp_name) AS comp_name_label FROM tb_m_comp comp "
        query += "WHERE comp.id_comp_cat='1'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        SLEVendor.Properties.DataSource = Nothing
        SLEVendor.Properties.DataSource = data
        SLEVendor.Properties.DisplayMember = "comp_name_label"
        SLEVendor.Properties.ValueMember = "id_comp"
        If data.Rows.Count.ToString >= 1 Then
            SLEVendor.EditValue = data.Rows(0)("id_comp").ToString
        Else
            SLEVendor.EditValue = Nothing
        End If
    End Sub

    Private Sub GVProd_DoubleClick(sender As Object, e As EventArgs) Handles GVProd.DoubleClick
        FormProductionMRS.id_prod_order = GVProd.GetFocusedRowCellValue("id_prod_order").ToString

        FormProductionMRS.TEDesign.EditValue = GVProd.GetFocusedRowCellValue("design_display_name").ToString
        FormProductionMRS.TEDesignCode.EditValue = GVProd.GetFocusedRowCellValue("design_code").ToString
        FormProductionMRS.TEPONumber.EditValue = GVProd.GetFocusedRowCellValue("prod_order_number").ToString

        Close()
    End Sub
End Class