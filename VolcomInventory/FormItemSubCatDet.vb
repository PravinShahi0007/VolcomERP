﻿Public Class FormItemSubCatDet
    Public id_sub_cat As String = "-1"

    Private Sub FormItemSubCatDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_cat()
        load_vendor_type()

        If Not id_sub_cat = "-1" Then
            Dim query As String = "SELECT * FROM tb_item_cat_detail WHERE id_item_cat_detail='" & id_sub_cat & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                SLEBudgetCat.EditValue = data.Rows(0)("id_item_cat").ToString
                SLEVendorType.EditValue = data.Rows(0)("id_vendor_type").ToString
            End If
            '
            BSave.Visible = False
        End If
    End Sub

    Sub load_cat()
        Dim query As String = "SELECT cat.id_item_cat,cat.item_cat FROM `tb_item_cat` cat
INNER JOIN `tb_item_coa` coa ON cat.`id_item_cat`=coa.`id_item_cat`
WHERE coa.`is_request`='1' AND cat.is_active='1'
GROUP BY cat.`id_item_cat`"
        viewSearchLookupQuery(SLEBudgetCat, query, "id_item_cat", "item_cat", "id_item_cat")
    End Sub

    Sub load_vendor_type()
        Dim query As String = "SELECT id_vendor_type,vendor_type FROM tb_vendor_type"
        viewSearchLookupQuery(SLEVendorType, query, "id_vendor_type", "vendor_type", "id_vendor_type")
    End Sub

    Private Sub FormItemSubCatDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        If id_sub_cat = "-1" Then
            If TEPurchaseCategory.Text = "" Then
                warningCustom("Please input purchase category")
            Else
                Dim query As String = "INSERT INTO tb_item_cat_detail(id_item_cat,id_vendor_type,item_cat_detail,created_by,created_date) VALUES('" & SLEBudgetCat.EditValue.ToString & "','" & SLEVendorType.EditValue.ToString & "','" & addSlashes(TEPurchaseCategory.Text) & "','" & id_user & "',NOW())"
                execute_non_query(query, True, "", "", "", "")
                infoCustom("Purchase category added")
                FormItemSubCat.load_cat()
                Close()
            End If
        End If
    End Sub
End Class