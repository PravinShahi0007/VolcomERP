Public Class FormAccountingARAPOtherDiscount
    Public id_comp As String = "-1"
    Public id_comp_comm_extra As String = "-1"
    Public is_for_gwp As String = "2"
    Public id_coa_type As String = "1"

    Private Sub FormAccountingARAPOtherDiscount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCOA()
        If id_comp_comm_extra = "-1" Then
            TxtStoreDiscount.EditValue = 0.00
        Else
            TxtStoreDiscount.EditValue = FormAccountingARAP.GVOtherDiscount.GetFocusedRowCellValue("comp_commission")
            SLEAR.EditValue = FormAccountingARAP.GVOtherDiscount.GetFocusedRowCellValue("id_acc_ar").ToString
            SLESales.EditValue = FormAccountingARAP.GVOtherDiscount.GetFocusedRowCellValue("id_acc_sales").ToString
            SLESalesReturn.EditValue = FormAccountingARAP.GVOtherDiscount.GetFocusedRowCellValue("id_acc_sales_return").ToString
        End If

        If is_for_gwp = "1" Then
            SLESales.Enabled = False
            SLESalesReturn.Enabled = False
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormAccountingARAPOtherDiscount_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewCOA()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 AND a.id_coa_type='" + id_coa_type + "' "
        viewSearchLookupQuery(SLESales, query, "id_acc", "acc_description", "id_acc")
        viewSearchLookupQuery(SLESalesReturn, query, "id_acc", "acc_description", "id_acc")
        viewSearchLookupQuery(SLEAR, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_sales As String = SLESales.EditValue.ToString
        Dim id_acc_sales_return = SLESalesReturn.EditValue.ToString
        Dim id_acc_ar = SLEAR.EditValue.ToString
        Dim comp_commission As String = decimalSQL(TxtStoreDiscount.EditValue.ToString)

        If id_comp_comm_extra = "-1" Then
            'new
            If is_for_gwp = "2" Then
                Dim query As String = "INSERT INTO tb_m_comp_comm_extra(id_comp, comp_commission, id_acc_sales, id_acc_sales_return, id_acc_ar) VALUES 
                ('" + id_comp + "', '" + comp_commission + "', '" + id_acc_sales + "', '" + id_acc_sales_return + "', '" + id_acc_ar + "'); "
                execute_non_query(query, True, "", "", "", "")
            Else
                Dim query As String = "INSERT INTO tb_m_comp_comm_extra(id_comp, comp_commission,id_acc_ar, is_for_gwp) VALUES 
                ('" + id_comp + "', '" + comp_commission + "', '" + id_acc_ar + "',1); "
                execute_non_query(query, True, "", "", "", "")
            End If
        Else
            'update
            If is_for_gwp = "2" Then
                Dim query As String = "UPDATE tb_m_comp_comm_extra SET comp_commission='" + comp_commission + "', id_acc_sales='" + id_acc_sales + "', 
                id_acc_sales_return='" + id_acc_sales_return + "', id_acc_ar='" + id_acc_ar + "' WHERE id_comp_comm_extra='" + id_comp_comm_extra + "' "
                execute_non_query(query, True, "", "", "", "")
            Else
                Dim query As String = "UPDATE tb_m_comp_comm_extra SET comp_commission='" + comp_commission + "',id_acc_ar='" + id_acc_ar + "' 
                WHERE id_comp_comm_extra='" + id_comp_comm_extra + "' "
                execute_non_query(query, True, "", "", "", "")
            End If
        End If
        FormAccountingARAP.viewOtherDiscount()
        Close()
        Cursor = Cursors.Default
    End Sub
End Class