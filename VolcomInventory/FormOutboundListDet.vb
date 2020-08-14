Public Class FormOutboundListDet
    Public id_awb As String = ""
    Public is_cancel As Boolean = False
    Private Sub FormOutboundListDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub view_del_type()
        Dim q As String = "SELECT id_del_type, del_type, is_no_weight,volume_divide_by FROM tb_lookup_del_type"
        viewSearchLookupQuery(SLEDelType, q, "id_del_type", "del_type", "id_del_type")
        SLEDelType.EditValue = Nothing
    End Sub

    Private Sub FormOutboundListDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEPanjang.EditValue = 0
        TELebar.EditValue = 0
        TETinggi.EditValue = 0
        TEDimWeight.EditValue = 0
        TEActWeight.EditValue = 0
        '
        view_del_type()
        '
        Dim q As String = "SELECT awb.id_awbill,dis.sub_district,c.comp_name
FROM tb_wh_awbill awb 
INNER JOIN tb_m_sub_district dis ON dis.id_sub_district=awb.id_sub_district
INNER JOIN tb_m_comp c ON c.id_comp=awb.id_store
WHERE awb.id_awbill='" & id_awb & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then
            TEOutboundNumber.Text = dt.Rows(0)("id_awbill").ToString
            TESubDistrict.Text = dt.Rows(0)("sub_district").ToString
            TEStore.Text = dt.Rows(0)("comp_name").ToString
            '
            view_do()
        End If
    End Sub

    Sub view_do()
        Dim query As String = "SELECT * FROM tb_wh_awbill_det WHERE id_awbill='" + id_awb + "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCDO.DataSource = data
        GVDO.BestFitColumns()
    End Sub

    Sub calculate()
        Dim dim_weight As Decimal = 0.0
        Dim divide_by As Decimal = 1
        '
        Dim panjang As Decimal = 0.0
        Dim lebar As Decimal = 0.0
        Dim tinggi As Decimal = 0.0
        '
        Try
            divide_by = SearchLookUpEdit1View.GetFocusedRowCellValue("volume_divide_by")
        Catch ex As Exception

        End Try

        Try
            panjang = TEPanjang.EditValue
            lebar = TELebar.EditValue
            tinggi = TETinggi.EditValue
        Catch ex As Exception

        End Try

        Try
            dim_weight = (panjang * lebar * tinggi) / divide_by
            TEDimWeight.EditValue = dim_weight
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TEPanjang_EditValueChanged(sender As Object, e As EventArgs) Handles TEPanjang.EditValueChanged
        calculate()
    End Sub

    Private Sub TELebar_EditValueChanged(sender As Object, e As EventArgs) Handles TELebar.EditValueChanged
        calculate()
    End Sub

    Private Sub TETinggi_EditValueChanged(sender As Object, e As EventArgs) Handles TETinggi.EditValueChanged
        calculate()
    End Sub

    Private Sub SLEDelType_EditValueChanged(sender As Object, e As EventArgs) Handles SLEDelType.EditValueChanged
        Try
            If SearchLookUpEdit1View.GetFocusedRowCellValue("is_no_weight").ToString = "1" Then
                PCWeight.Visible = False
            Else
                PCWeight.Visible = True
            End If
            calculate()
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    Private Sub BApprove_Click(sender As Object, e As EventArgs) Handles BApprove.Click
        'Approve DO
        If SLEDelType.EditValue = Nothing Then
            warningCustom("Please select delivery type !")
        Else
            If SearchLookUpEdit1View.GetFocusedRowCellValue("is_no_weight").ToString = "2" And (TEActWeight.EditValue + TEDimWeight.EditValue <= 0) Then
                warningCustom("Please put some weight")
            Else
                Dim q As String = "UPDATE tb_wh_awbill SET weight='" & decimalSQL(TEActWeight.EditValue.ToString) & "',`length`='" & decimalSQL(TEPanjang.EditValue.ToString) & "',width='" & decimalSQL(TELebar.EditValue.ToString) & "',height='" & decimalSQL(TETinggi.EditValue.ToString) & "',weight_calc='" & decimalSQL(TEDimWeight.EditValue.ToString) & "',id_del_type='" & SLEDelType.EditValue.ToString & "',id_report_status=3,step=2,approve_outbound_by='" & id_user & "',approve_outbound_date=NOW()  WHERE id_awbill='" & id_awb & "'"
                execute_non_query(q, True, "", "", "", "")

                For i = 0 To GVDO.RowCount - 1
                    If Not GVDO.GetRowCellValue(i, "id_pl_sales_order_del").ToString = "" And Not GVDO.GetRowCellValue(i, "id_pl_sales_order_del").ToString = "NULL" Then
                        Dim stt As ClassSalesDelOrder = New ClassSalesDelOrder()
                        stt.changeStatus(GVDO.GetRowCellValue(i, "id_pl_sales_order_del").ToString, "3")

                        If FormViewSalesDelOrder.id_commerce_type = "2" Then
                            stt.sendEmailConfirmation(GVDO.GetRowCellValue(i, "id_pl_sales_order_del").ToString)
                        End If
                    ElseIf Not GVDO.GetRowCellValue(i, "id_ol_store_cust_ret").ToString = "" And Not GVDO.GetRowCellValue(i, "id_ol_store_cust_ret").ToString = "NULL" Then
                        Dim query As String = String.Format("UPDATE tb_ol_store_cust_ret SET id_report_status='{0}' WHERE id_ol_store_cust_ret ='{1}'", "3", GVDO.GetRowCellValue(i, "id_ol_store_cust_ret").ToString)
                        execute_non_query(query, True, "", "", "", "")
                    End If
                Next

                FormOutboundList.load_list("")
                Close()
            End If
        End If
    End Sub

    Private Sub BNotApprove_Click(sender As Object, e As EventArgs) Handles BNotApprove.Click
        'pakai login dept head + cancel semua DO
        FormMenuAuth.type = "7"
        FormMenuAuth.ShowDialog()

        If is_cancel Then
            'cancel
            For i = 0 To GVDO.RowCount - 1
                If Not GVDO.GetRowCellValue(i, "id_pl_sales_order_del").ToString = "" And Not GVDO.GetRowCellValue(i, "id_pl_sales_order_del").ToString = "NULL" Then
                    Dim stt As ClassSalesDelOrder = New ClassSalesDelOrder()
                    stt.changeStatus(GVDO.GetRowCellValue(i, "id_pl_sales_order_del").ToString, "5")

                    If FormViewSalesDelOrder.id_commerce_type = "2" Then
                        stt.sendEmailConfirmation(GVDO.GetRowCellValue(i, "id_pl_sales_order_del").ToString)
                    End If
                ElseIf Not GVDO.GetRowCellValue(i, "id_ol_store_cust_ret").ToString = "" And Not GVDO.GetRowCellValue(i, "id_ol_store_cust_ret").ToString = "NULL" Then
                    Dim query As String = String.Format("UPDATE tb_ol_store_cust_ret SET id_report_status='{0}' WHERE id_ol_store_cust_ret ='{1}'", "5", GVDO.GetRowCellValue(i, "id_ol_store_cust_ret").ToString)
                    execute_non_query(query, True, "", "", "", "")
                End If
            Next
            Dim q As String = "UPDATE tb_wh_awbill SET id_report_status=5  WHERE id_awbill='" & id_awb & "'"
            execute_non_query(q, True, "", "", "", "")
            FormOutboundList.load_list("")
            Close()
        End If
    End Sub
End Class