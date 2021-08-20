Public Class FormPreCalFGPODet
    Public id As String = "-1"
    Public is_view As String = "-1"
    Private Sub FormPreCalFGPODet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_type()
        load_vendor()

        If id = "-1" Then
            'new
        Else
            'edit
        End If

        load_list_fgpo()
    End Sub

    Sub load_list_fgpo()
        Dim q As String = "SELECT d.`design_display_name`,d.`design_code`,pcl.id_prod_order,a.prod_order_number,pcl.qty,pcl.id_currency,pcl.price
FROM `tb_pre_cal_fgpo_list` pcl
INNER JOIN tb_prod_order a ON a.id_prod_order=pcl.id_prod_order 
INNER JOIN tb_prod_demand_design b ON a.id_prod_demand_design = b.id_prod_demand_design 
INNER JOIN tb_m_design d ON b.id_design = d.id_design
WHERE pcl.id_pre_cal_fgpo='" & id & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCListFGPO.DataSource = dt
    End Sub

    Sub load_vendor()
        Dim query As String = "(SELECT id_comp, comp_name AS comp_name FROM tb_m_comp WHERE id_comp_cat = 1)"
        viewSearchLookupQuery(SLE3PLImport, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub load_type()
        Dim q As String = "SELECT 1 AS id_type,'LCL' AS type
UNION ALL
SELECT 2 AS id_type,'FCL' AS type"
        viewSearchLookupQuery(SLETypeImport, q, "id_type", "type", "id_type")
    End Sub

    Private Sub BDel_Click(sender As Object, e As EventArgs) Handles BDel.Click
        If Not GVListFGPO.RowCount = 0 Then
            delete_row(GVListFGPO.FocusedRowHandle)
        End If
    End Sub

    Sub delete_row(ByVal i As Integer)
        GVListFGPO.DeleteRow(i)
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        FormPopUpProd.id_pop_up = "12"
        FormPopUpProd.id_comp = SLE3PLImport.EditValue.ToString
        FormPopUpProd.ShowDialog()
    End Sub

    Private Sub SLE3PLImport_EditValueChanged(sender As Object, e As EventArgs) Handles SLE3PLImport.EditValueChanged
        If Not GVListFGPO.RowCount = 0 Then
            For i = GVListFGPO.RowCount - 1 To 0 Step -1
                delete_row(i)
            Next
        End If
    End Sub

    Private Sub BPropose_Click(sender As Object, e As EventArgs) Handles BPropose.Click
        Dim q As String = "INSERT INTO `tb_pre_cal_fgpo`(created_date,created_by,id_report_status) VALUES(NOW(),'" & id_user & "','1');SELECT LAST_INSERT_ID();"
        id = execute_query(q, 0, True, "", "", "", "")
        'detail
        q = "INSERT INTO `tb_pre_cal_fgpo_list`(`id_pre_cal_fgpo`,`id_prod_order`,`id_currency`,`price`,`qty`) VALUES"
        For i As Integer = 0 To GVListFGPO.RowCount - 1
            If Not i = 0 Then
                q += ","
            End If
            q += "('" & id & "','" & GVListFGPO.GetRowCellValue(i, "id_prod_order").ToString & "','" & GVListFGPO.GetRowCellValue(i, "id_currency").ToString & "','" & decimalSQL(Decimal.Parse(GVListFGPO.GetRowCellValue(i, "id_prod_order").ToString).ToString) & "','" & GVListFGPO.GetRowCellValue(i, "id_prod_order").ToString & "')"

        Next

        execute_non_query(q, True, "", "", "", "")
    End Sub
End Class