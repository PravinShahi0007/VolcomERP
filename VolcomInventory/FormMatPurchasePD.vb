﻿Public Class FormMatPurchasePD
    Public id_list As String = "-1"

    Private Sub FormMatPurchasePD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_head()
        load_mat()
        '
        If Not id_list = "-1" Then 'view
            Dim query As String = "SELECT id_mat_det,qty_consumption,tolerance FROM tb_mat_purc_list WHERE id_mat_purc_list='" & id_list & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                SLEMaterial.EditValue = data.Rows(0)("id_mat_det").ToString
                TEConsumption.EditValue = data.Rows(0)("qty_consumption")
                TEToleransi.EditValue = data.Rows(0)("tolerance")
                'view pd
                load_pd_view()
                set_calculate()
                '
                BSetConsumption.Enabled = False
                BCalculate.Enabled = False
                TEToleransi.Enabled = False
                '
                BSave.Visible = False
            End If
        End If
    End Sub

    Sub load_head()
        TEConsumption.EditValue = 0.00
        TEToleransi.EditValue = 0.00
        TEToleransiAmount.EditValue = 0.00
        TETotal.EditValue = 0.00
        TETotalAmount.EditValue = 0.00
    End Sub

    Sub load_mat()
        Dim query As String = "SELECT md.`id_mat_det`,md.`id_mat`,md.`mat_det_code`,md.`mat_det_display_name` ,uom.`uom`
FROM tb_m_mat_det md
INNER JOIN tb_m_mat mat ON mat.`id_mat`=md.`id_mat`
INNER JOIN tb_m_uom uom ON uom.`id_uom`=mat.`id_uom`"
        viewSearchLookupQuery(SLEMaterial, query, "id_mat_det", "mat_det_display_name", "id_mat_det")
        SLEMaterial.EditValue = Nothing
    End Sub

    Sub load_pd()
        Dim query As String = "SELECT '' AS note,'no' AS is_check,pdd.id_prod_demand_design,pdd.id_design,pdd.qty,dsg.design_display_name,dsg.design_code,pdd.prod_demand_number,pdd.qty,(" & decimalSQL(TEConsumption.EditValue.ToString) & "*pdd.qty) AS qty_order FROM (
	SELECT pd_dsg.id_prod_demand_design, pd_dsg.id_prod_demand, pd.prod_demand_number, pd_dsg.id_design, 
	pd_dsg.prod_demand_design_propose_price, pd_dsg.prod_demand_design_total_cost, pd_dsg.msrp,
	(SUM(pd_prd.prod_demand_product_qty)) AS qty
	FROM  tb_prod_demand_design pd_dsg
	INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pd_dsg.id_prod_demand
	LEFT JOIN tb_prod_demand_product pd_prd ON pd_prd.id_prod_demand_design = pd_dsg.id_prod_demand_design 
	WHERE pd.id_report_status = '6' AND pd_dsg.is_void=2
	GROUP BY pd_dsg.id_prod_demand_design
	ORDER BY pd_dsg.id_prod_demand_design DESC
) pdd
INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design
GROUP BY pdd.id_design
ORDER BY pdd.id_prod_demand_design DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPD.DataSource = data
    End Sub

    Sub load_pd_view()
        Dim query As String = "SELECT 'yes' AS is_check,lp.id_prod_demand_design,pdd.id_design,lp.total_qty_pd AS qty,dsg.design_display_name,dsg.design_code,pd.prod_demand_number,(" & decimalSQL(TEConsumption.EditValue.ToString) & "*lp.total_qty_pd) AS qty_order 
FROM tb_mat_purc_list_pd lp
INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=lp.id_prod_demand_design
INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pdd.id_prod_demand
INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design
WHERE lp.id_mat_purc_list='" & id_list & "'
ORDER BY pdd.id_prod_demand_design DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPD.DataSource = data
    End Sub

    Private Sub FormMatPurchasePD_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BSetConsumption_Click(sender As Object, e As EventArgs) Handles BSetConsumption.Click
        If TEConsumption.EditValue <= 0 Then
            warningCustom("Please input consumption quantity.")
        Else
            load_pd()
        End If
    End Sub

    Sub calculate()
        Dim total_qty As Decimal = 0.00
        Dim toleransi As Decimal = 0.00

        For i As Integer = 0 To GVPD.RowCount - 1
            total_qty += GVPD.GetRowCellValue(i, "qty_order")
        Next
        'calculate
        toleransi = TEToleransi.EditValue
        TETotal.EditValue = total_qty
        '
        TEToleransiAmount.EditValue = (toleransi / 100) * total_qty
        TETotalAmount.EditValue = TETotal.EditValue + TEToleransiAmount.EditValue
    End Sub

    Private Sub BCalculate_Click(sender As Object, e As EventArgs) Handles BCalculate.Click
        set_calculate()
    End Sub

    Sub set_calculate()
        If BCalculate.Text = "Calculate" Then
            GVPD.ActiveFilterString = "[is_check] = 'yes'"
            calculate()
            '
            GridColumnCheck.Visible = False
            SLEMaterial.Enabled = False
            TEConsumption.Enabled = False
            BSetConsumption.Enabled = False
            TEToleransi.Enabled = False
            GVPD.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
            '
            BCalculate.Text = "Unlock"
        ElseIf BCalculate.Text = "Unlock" Then
            GridColumnCheck.Visible = True
            SLEMaterial.Enabled = True
            TEConsumption.Enabled = True
            BSetConsumption.Enabled = True
            TEToleransi.Enabled = True
            GVPD.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Default
            '
            BCalculate.Text = "Calculate"
        End If
    End Sub

    Private Sub SLEMaterial_EditValueChanged(sender As Object, e As EventArgs) Handles SLEMaterial.EditValueChanged
        Try
            If Not SLEMaterial.EditValue = Nothing Then
                TEUOM.Text = SLEMaterial.Properties.View.GetFocusedRowCellValue("uom").ToString
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        Dim query As String = ""
        'cek first
        Dim already As Boolean = False
        Dim pd_note As String = ""

        For i As Integer = 0 To GVPD.RowCount - 1
            Dim query_cek As String = "SELECT dsg.`design_code`,dsg.`design_display_name`,LPAD(l.`id_mat_purc`,6,'0') AS number FROM `tb_mat_purc_list_pd` lp
INNER JOIN `tb_mat_purc_list` l ON l.`id_mat_purc_list`=lp.`id_mat_purc_list`
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=lp.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
WHERE l.`is_cancel`=2 AND lp.`id_prod_demand_design`='" & GVPD.GetRowCellValue(i, "id_prod_demand_design").ToString & "'"
            Dim data_cek As DataTable = execute_query(query_cek, -1, True, "", "", "", "")
            If data_cek.Rows.Count > 0 Then
                pd_note = data_cek.Rows(0)("design_code").ToString & " - " & data_cek.Rows(0)("design_display_name").ToString & " already listed on list no : " & data_cek.Rows(0)("number").ToString
                already = False
                Exit For
            End If
        Next

        If already = True Then
            warningCustom(pd_note)
        ElseIf GVPD.RowCount <= 0 Then
            warningCustom("Please select at least 1 PD Design")
        ElseIf Not BCalculate.Text = "Unlock" Then
            warningCustom("Please press calculate")
        Else
            'header
            query = "INSERT INTO tb_mat_purc_list(id_mat_det,created_by,created_date,qty_consumption,tolerance,note) VALUES
('" & SLEMaterial.EditValue.ToString & "','" & id_user & "',NOW(),'" & decimalSQL(TEConsumption.EditValue.ToString) & "','" & decimalSQL(TEToleransi.EditValue.ToString) & "','" & addSlashes(MENote.Text) & "'); SELECT LAST_INSERT_ID()"
            id_list = execute_query(query, 0, True, "", "", "", "")

            'pd list
            query = ""
            For i As Integer = 0 To GVPD.RowCount - 1
                If Not i = 0 Then
                    query += ","
                End If

                query += "('" & id_list & "','" & GVPD.GetRowCellValue(i, "id_prod_demand_design").ToString & "','" & decimalSQL(GVPD.GetRowCellValue(i, "qty").ToString) & "','" & GVPD.GetRowCellValue(i, "note").ToString & "')"
            Next

            query = "INSERT INTO tb_mat_purc_list_pd(id_mat_purc_list,id_prod_demand_design,total_qty_pd,note) VALUES " & query
            execute_non_query(query, True, "", "", "", "")

            Close()
        End If
    End Sub
End Class