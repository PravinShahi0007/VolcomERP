Public Class FormSalesPOSDiscount
    Public id_comp As String = "-1"

    Private Sub FormSalesPOSDiscount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewOtherDiscount()
    End Sub

    Private Sub FormSalesPOSDiscount_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Sub choose()
        FormSalesPOSDet.SPDiscount.EditValue = GVOtherDiscount.GetFocusedRowCellValue("comp_commission")
        FormSalesPOSDet.id_acc_ar = GVOtherDiscount.GetFocusedRowCellValue("id_acc_ar").ToString
        FormSalesPOSDet.id_acc_sales = GVOtherDiscount.GetFocusedRowCellValue("id_acc_sales").ToString
        FormSalesPOSDet.id_acc_sales_return = GVOtherDiscount.GetFocusedRowCellValue("id_acc_sales_return").ToString
        Close()
    End Sub

    Private Sub BtnChoose_Click(sender As Object, e As EventArgs) Handles BtnChoose.Click
        choose()
    End Sub

    Sub viewOtherDiscount()
        Cursor = Cursors.WaitCursor
        Dim query As String = "
        SELECT d.id_comp, d.comp_commission, 
        d.id_acc_sales, sal.acc_name AS `acc_name_sales`, sal.acc_description AS `acc_description_sales`, 
        d.id_acc_sales_return, sal_ret.acc_name AS `acc_name_sales_ret`, sal_ret.acc_description AS `acc_description_sales_ret`,
        d.id_acc_ar, ar.acc_name AS `acc_name_ar`, ar.acc_description AS `acc_description_ar`, 1 AS `is_default`
        FROM tb_m_comp d
        INNER JOIN tb_a_acc ar ON ar.id_acc = d.id_acc_ar
        INNER JOIN tb_a_acc sal ON sal.id_acc = d.id_acc_sales
        INNER JOIN tb_a_acc sal_ret ON sal_ret.id_acc = d.id_acc_sales_return
        WHERE d.id_comp=" + id_comp + " 
        UNION ALL
        SELECT d.id_comp, d.comp_commission, 
        d.id_acc_sales, sal.acc_name AS `acc_name_sales`, sal.acc_description AS `acc_description_sales`, 
        d.id_acc_sales_return, sal_ret.acc_name AS `acc_name_sales_ret`, sal_ret.acc_description AS `acc_description_sales_ret`,
        d.id_acc_ar, ar.acc_name AS `acc_name_ar`, ar.acc_description AS `acc_description_ar`, 2 AS `is_default`
        FROM tb_m_comp_comm_extra d
        INNER JOIN tb_a_acc ar ON ar.id_acc = d.id_acc_ar
        INNER JOIN tb_a_acc sal ON sal.id_acc = d.id_acc_sales
        INNER JOIN tb_a_acc sal_ret ON sal_ret.id_acc = d.id_acc_sales_return
        WHERE d.id_comp=" + id_comp + " 
        ORDER BY is_default ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCOtherDiscount.DataSource = data
        GVOtherDiscount.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVOtherDiscount_DoubleClick(sender As Object, e As EventArgs) Handles GVOtherDiscount.DoubleClick
        If GVOtherDiscount.RowCount > 0 And GVOtherDiscount.FocusedRowHandle >= 0 Then
            choose()
        End If
    End Sub
End Class