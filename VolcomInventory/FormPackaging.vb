Public Class FormPackaging
    Dim active_id_olshop As String = "-1"
    Dim d_json As New Newtonsoft.Json.Linq.JObject()

    Sub load_json()
        d_json = volcomErpApiGetJson(volcom_erp_api_host & "api/packaging")
    End Sub

    Private Sub FormPackaging_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_json()
        load_online_shop()
    End Sub

    Sub load_online_shop()
        viewSearchLookupQueryO(SLEOnlineShop, volcomErpApiGetDT(d_json, 0), "id_comp_group", "description", "id_comp_group")
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        active_id_olshop = SLEOnlineShop.EditValue.ToString
        LOlShop.Text = SLEOnlineShop.Text
        load_weight()
    End Sub

    Sub load_weight()
        Dim q As String = "SELECT 2 AS is_change,cd.id_code_detail,cd.code,cd.code_detail_name,IFNULL(pw.berat,0.00) AS berat,IFNULL(pw.panjang,0.00) AS panjang,IFNULL(pw.lebar,0.00) AS lebar,IFNULL(pw.tinggi,0.00) AS tinggi
FROM tb_m_code_detail cd
LEFT JOIN tb_packaging_w pw ON pw.id_code_detail=cd.id_code_detail AND pw.id_comp_group='" & SLEOnlineShop.EditValue.ToString & "' AND pw.is_active=1 
WHERE cd.id_code='30'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCClass.DataSource = dt
        'GCClass.DataSource = volcomErpApiGetDT(d_json, 1).Select("[id_comp_group]='" & SLEOnlineShop.EditValue.ToString & "'").CopyToDataTable

    End Sub

    Private Sub BCreatePenawaran_Click(sender As Object, e As EventArgs) Handles BUpdateData.Click
        If GVClass.RowCount > 0 Then
            makeSafeGV(GVClass)
            GVClass.ActiveFilterString = "[is_change]=1"
            If GVClass.RowCount > 0 Then
                Dim qi As String = "INSERT INTO tb_packaging_w(`id_comp_group`,`id_code_detail`,`berat`,`panjang`,`lebar`,`tinggi`,`update_by`,`update_date`) VALUES"
                Dim qu As String = ""
                For i = 0 To GVClass.RowCount - 1
                    If Not i = 0 Then
                        qu += ","
                        qi += ","
                    End If

                    qu += "'" & GVClass.GetRowCellValue(i, "id_code_detail").ToString & "'"
                    qi += "('" & SLEOnlineShop.EditValue.ToString & "','" & GVClass.GetRowCellValue(i, "id_code_detail").ToString & "','" & decimalSQL(Decimal.Parse(GVClass.GetRowCellValue(i, "berat").ToString)) & "','" & decimalSQL(Decimal.Parse(GVClass.GetRowCellValue(i, "panjang").ToString)) & "','" & decimalSQL(Decimal.Parse(GVClass.GetRowCellValue(i, "lebar").ToString)) & "','" & decimalSQL(Decimal.Parse(GVClass.GetRowCellValue(i, "tinggi").ToString)) & "','" & id_user & "',NOW())"
                Next
                'update non active
                execute_non_query("UPDATE `tb_packaging_w` SET is_active=2 WHERE id_code_detail IN (" & qu & ") AND id_comp_group='" & SLEOnlineShop.EditValue.ToString & "'", True, "", "", "", "")
                'insert
                execute_non_query(qi, True, "", "", "", "")
                infoCustom("Data disimpan.")
                '
                load_weight()
            Else
                warningCustom("Tidak ada data yang berubah")
            End If
            GVClass.ActiveFilterString = ""
        End If
    End Sub

    Private Sub GVClass_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVClass.CellValueChanged
        If Not e.Column.FieldName = "is_change" Then
            GVClass.SetFocusedRowCellValue("is_change", "1")
        End If
    End Sub
End Class