Public Class FormMailManage
    Public id_menu As String = "1"
    '1=for accounting

    Private Sub FormMailManage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt_now As DataTable = execute_query("SELECT DATE(NOW()) as tgl", -1, True, "", "", "", "")
        DEFromList.EditValue = dt_now.Rows(0)("tgl")
        DEUntilList.EditValue = dt_now.Rows(0)("tgl")

        'invoice list
        load_group_store()
    End Sub

    Sub load_group_store()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS id_comp_group, 'Select Group' AS comp_group, 'Select Group' AS description 
        UNION
        SELECT cg.id_comp_group, cg.comp_group, cg.description 
        FROM tb_m_comp_group cg "
        viewSearchLookupQuery(SLEStoreGroup, query, "id_comp_group", "comp_group", "id_comp_group")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPending_Click(sender As Object, e As EventArgs) Handles BtnPending.Click
        loadInvoice("AND sp.is_pending_mail=1 ")
    End Sub

    Sub loadInvoice(ByVal cond As String)
        Cursor = Cursors.WaitCursor
        Dim id_comp_group As String = SLEStoreGroup.EditValue.ToString

        If id_comp_group = "0" Then
            stopCustom("Please select store group first")
        Else
            Dim query As String = "SELECT 'no' AS is_check,sp.is_close_rec_payment,sp.`id_sales_pos`,sp.sales_pos_note,sp.`sales_pos_number`,sp.`id_memo_type`,typ.`memo_type`,typ.`is_receive_payment`,sp.`sales_pos_date`,sp.`id_store_contact_from`, c.id_comp,c.comp_number,c.`comp_name`, cg.comp_group,sp.`sales_pos_due_date`, sp.`sales_pos_start_period`, sp.`sales_pos_end_period`
            ,sp.`sales_pos_total`,sp.`sales_pos_discount`,sp.`sales_pos_vat`,sp.`sales_pos_potongan`, sp.sales_pos_total_qty,
            CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2)) AS amount
            ,sp.report_mark_type,rmt.report_mark_type_name
            ,DATEDIFF(sp.`sales_pos_due_date`,NOW()) AS due_days
            FROM tb_sales_pos sp 
            INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
            INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
            INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
            INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
            INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
            WHERE sp.`id_report_status`='6' AND c.id_comp_group='" + id_comp_group + "' 
            " + cond + "
            GROUP BY sp.`id_sales_pos` 
            ORDER BY id_sales_pos ASC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCInvoiceList.DataSource = data
            GVInvoiceList.BestFitColumns()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAlreadyProcessed_Click(sender As Object, e As EventArgs) Handles BtnAlreadyProcessed.Click
        loadInvoice("AND sp.is_pending_mail=2 ")
    End Sub

    Private Sub CESelectAllInvoice_CheckedChanged(sender As Object, e As EventArgs) Handles CESelectAllInvoice.CheckedChanged
        Dim val As String = ""
        If CESelectAllInvoice.EditValue = True Then
            val = "yes"
        Else
            val = "no"
        End If

        For i As Integer = 0 To GVInvoiceList.RowCount - 1
            GVInvoiceList.SetRowCellValue(i, "is_check", val)
        Next
    End Sub

    Private Sub BCreatePO_Click(sender As Object, e As EventArgs) Handles BCreatePO.Click
        makeSafeGV(GVInvoiceList)
        GVInvoiceList.ActiveFilterString = "[is_check]='yes'"

        'load detil form


        GVInvoiceList.ActiveFilterString = ""
    End Sub
End Class