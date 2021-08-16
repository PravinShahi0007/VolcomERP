Public Class FormSNIIn
    Public id As String = "-1"
    Public id_out As String = "-1"

    Private Sub FormSNIIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_head
    End Sub

    Sub load_head()
        view_vendor()
        view_barcode_list()
        viewReportStatus()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub view_vendor()
        Dim query As String = "SELECT comp.id_comp,comp.comp_number, comp.comp_name FROM tb_m_comp comp WHERE comp.id_comp_cat='1' OR comp.id_comp_cat='2'"
        viewSearchLookupQuery(SLEVendor, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub view_barcode_list()
        Dim query As String = "SELECT ('0') AS no, ('') AS product_full_code, ('0') AS id_prod_order_det, ('1') AS is_fix "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBarcode.DataSource = data
        deleteRowsBc()
        allowDelete()
    End Sub

    'DeleteRows
    Sub deleteRowsBc()
        GVBarcode.DeleteRow(GVBarcode.FocusedRowHandle)
    End Sub

    'Focus Column Code
    Sub focusColumnCodeBc()
        GVBarcode.FocusedColumn = GVBarcode.VisibleColumns(0)
        GVBarcode.ShowEditor()
    End Sub
    'New Row
    Sub newRowsBc()
        GVBarcode.AddNewRow()
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
    End Sub

    Sub allowDelete()
        If GVBarcode.RowCount <= 0 Then
            BDelete.Enabled = False

        Else
            BDelete.Enabled = True

        End If
    End Sub

    Private Sub TESNIOutNo_KeyDown(sender As Object, e As KeyEventArgs) Handles TESNIOutNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TESNIOutNo.Text = "" Then
                warningCustom("Please scan SNI Out form")
            Else
                Dim qc As String = "SELECT id_qc_sni_out,id_comp_to FROM tb_qc_sni_out WHERE number='" & addSlashes(TESNIOutNo.Text) & "' AND id_report_status=6"
                Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
                If dtc.Rows.Count = 0 Then
                    warningCustom("SNI Out number not found")
                    TESNIOutNo.Text = ""
                    TESNIOutNo.Focus()
                Else
                    TESNIOutNo.Properties.ReadOnly = True
                    SLEVendor.EditValue = dtc.Rows(0)("id_comp_to").ToString
                    id_out = dtc.Rows(0)("id_qc_sni_out").ToString
                    '
                    load_det()
                    PanelNavBarcode.Visible = True
                End If
            End If
        End If
    End Sub

    Sub load_det()
        Dim q As String = "SELECT '' AS `no`,qco.`id_qc_sni_out_det`,pdp.`id_product`,po.`id_prod_order`,pod.id_prod_order_det,recd.id_prod_order_rec_det,recd.`id_prod_order_rec`,po.`prod_order_number`,rec.`prod_order_rec_number`,p.`product_full_code`,dsg.`design_display_name` AS name,cd.`display_name` AS size,qco.qty,'' AS qty_in
FROM `tb_qc_sni_out_det` qco
INNER JOIN tb_prod_order_rec_det recd ON recd.`id_prod_order_rec_det`=qco.`id_prod_order_rec_det`
INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec`
INNER JOIN tb_prod_order_det pod ON pod.`id_prod_order_det`=recd.`id_prod_order_det`
INNER JOIN tb_prod_order po ON po.`id_prod_order`=pod.`id_prod_order`
INNER JOIN tb_prod_demand_product pdp ON pdp.`id_prod_demand_product`=pod.`id_prod_demand_product`
INNER JOIN tb_m_product p ON p.`id_product`=pdp.`id_product`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=p.`id_design`
INNER JOIN tb_m_code_detail cd ON cd.code=p.`product_code` AND cd.`id_code`=33
WHERE qco.id_qc_sni_out='" & id_out & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCDetail.DataSource = dt
        GVDetail.BestFitColumns()
    End Sub
End Class