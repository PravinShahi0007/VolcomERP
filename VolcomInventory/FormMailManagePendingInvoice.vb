Public Class FormMailManagePendingInvoice
    Public show_direct As Boolean = False

    Private Sub FormMailManagePendingInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()

        If show_direct Then
            FormMailManage.already_open_invoice = True
            If GVData.RowCount <= 0 Then
                Close()
            End If
        End If
    End Sub

    Private Sub FormMailManagePendingInvoice_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT cg.id_comp_group,cg.comp_group AS `group`, cg.description AS `group_description`, hc.comp_name AS `comp_group_office`,
        SUM(sp.sales_pos_total_qty) AS `total_qty`, SUM(sp.`sales_pos_total`) AS sales_pos_total,
        SUM(CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2))) AS amount
        FROM tb_sales_pos sp 
        INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
        INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
        INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        LEFT JOIN tb_m_comp hc ON hc.id_comp = cg.id_comp
        INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
        WHERE sp.`id_report_status`='6' AND sp.is_pending_mail=1
        GROUP BY cg.id_comp_group 
        ORDER BY id_sales_pos ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail()
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormMailManage.SLEStoreGroup.EditValue = GVData.GetFocusedRowCellValue("id_comp_group").ToString
            FormMailManage.loadInvoice("AND sp.is_pending_mail=1 ")
            Close()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnViewDetail_Click(sender As Object, e As EventArgs) Handles BtnViewDetail.Click
        viewDetail()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        viewDetail()
    End Sub
End Class