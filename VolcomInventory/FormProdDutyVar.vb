Public Class FormProdDutyVar
    Public id_prod_order As String = "-1"
    Private Sub FormProdDutyVar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEDuty.EditValue = 0
        TERoyalty.EditValue = 0
        TESalesVAT.EditValue = 0
        TESalesThrough.EditValue = 0
        TEStoreDisc.EditValue = 0
        '
        Dim query As String = "SELECT * FROM tb_prod_order WHERE id_prod_order='" & id_prod_order & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '
        If data.Rows.Count > 0 Then
            TEPO.Text = FormProdDuty.GVProd.GetFocusedRowCellValue("prod_order_number").ToString
            TEStyle.Text = FormProdDuty.GVProd.GetFocusedRowCellValue("design_display_name").ToString & " " & FormProdDuty.GVProd.GetFocusedRowCellValue("color").ToString
            '
            TEPIBNo.Text = data.Rows(0)("pib_no").ToString
            DEDate.EditValue = data.Rows(0)("pib_date")
            '
            TEDuty.EditValue = data.Rows(0)("duty_percent")
            TERoyalty.EditValue = data.Rows(0)("duty_royalty")
            TESalesVAT.EditValue = data.Rows(0)("duty_sales_vat")
            TESalesThrough.EditValue = data.Rows(0)("duty_sales_thru")
            TEStoreDisc.EditValue = data.Rows(0)("duty_store_disc")
            '
            If data.Rows(0)("duty_is_pr_proposed").ToString = "1" Then
                CEPayCreated.Checked = True
            Else
                CEPayCreated.Checked = False
            End If
            '
            If data.Rows(0)("duty_is_pay").ToString = "1" Then
                CEPaid.Checked = True
            Else
                CEPaid.Checked = False
            End If
        End If
    End Sub

    Private Sub FormProdDutyVar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        Dim pib_date As String = ""

        Dim is_pr As String = ""
        Dim is_paid As String = ""

        If DEDate.Text = "" Then
            pib_date = ",pib_date=NULL"
        Else
            pib_date = ",pib_date='" & Date.Parse(DEDate.EditValue.ToString).ToString("yyyy-MM-dd") & "'"
        End If

        If CEPaid.Checked = True Then
            is_paid = "1"
        Else
            is_paid = "2"
        End If

        If CEPayCreated.Checked = True Then
            is_pr = "1"
        Else
            is_pr = "2"
        End If

        Dim query_upd As String = "UPDATE tb_prod_order SET pib_no='" & TEPIBNo.Text & "'" & pib_date & ",duty_percent='" & TEDuty.EditValue.ToString & "',duty_royalty='" & TERoyalty.EditValue.ToString & "',duty_sales_vat='" & TESalesVAT.EditValue.ToString & "',duty_sales_thru='" & TESalesThrough.EditValue.ToString & "',duty_store_disc='" & TEStoreDisc.EditValue.ToString & "',duty_is_pr_proposed='" & is_pr & "',duty_is_pay='" & is_paid & "' WHERE id_prod_order='" & id_prod_order & "'"
        execute_non_query(query_upd, True, "", "", "", "")
        '
        infoCustom("Variable set !")
        FormProdDuty.view_production_order()
        FormProdDuty.GVProd.FocusedRowHandle = find_row(FormProdDuty.GVProd, "id_prod_order", id_prod_order)
        Close()
    End Sub
End Class