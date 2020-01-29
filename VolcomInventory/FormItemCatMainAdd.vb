Public Class FormItemCatMainAdd
    Private Sub FormItemCatMainAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormItemCatMainAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub actionLoad()
        viewType()
        view_fixed_asset()
        TxtCat.Text = ""
    End Sub

    Sub view_fixed_asset()
        Dim query As String = "SELECT '2' AS is_fixed_asset,'Non Fixed Asset' AS description
UNION ALL
SELECT '1' AS is_fixed_asset,'Fixed Asset' AS description "
        viewSearchLookupQuery(SLEFixedAsset, query, "is_fixed_asset", "description", "is_fixed_asset")
    End Sub

    Sub viewType()
        Dim query As String = "SELECT * FROM tb_lookup_expense_type t "
        viewLookupQuery(LEExpenseType, query, 0, "expense_type", "id_expense_type")
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BTnOK.Click
        save()
    End Sub

    Sub save()
        If TxtCat.Text = "" Then
            stopCustom("Category can't blank")
        Else
            Dim item_cat_main As String = addSlashes(TxtCat.Text).Trim()
            Dim id_expense_type As String = LEExpenseType.EditValue.ToString
            Dim is_fixed_asset As String = SLEFixedAsset.EditValue.ToString

            'cek kondisi master
            Dim cm As Boolean = False
            Dim qm As String = "SELECT * FROM tb_item_cat_main WHERE item_cat_main='" + item_cat_main + "' "
            Dim dm As DataTable = execute_query(qm, -1, True, "", "", "", "")
            If dm.Rows.Count > 0 Then
                cm = True
            End If

            'cel kondisi propose
            Dim cp As Boolean = False
            Dim qp As String = "SELECT * FROM tb_item_cat_main_pps_det d 
            INNER JOIN tb_item_cat_main_pps m ON m.id_item_cat_main_pps = d.id_item_cat_main_pps
            WHERE d.item_cat_main='" + item_cat_main + "' AND m.id_report_status!=5 "
            Dim dp As DataTable = execute_query(qp, -1, True, "", "", "", "")
            If dp.Rows.Count > 0 Then
                cp = True
            End If

            If cm Or cp Then
                stopCustom("Category already exist")
                TxtCat.Focus()
            Else
                Dim query As String = "INSERT INTO tb_item_cat_main_pps_det(id_item_cat_main_pps,  id_expense_type, item_cat_main, is_fixed_asset)
            VALUES('" + FormItemCatMainDet.id_propose + "', " + id_expense_type + ", '" + item_cat_main + "','" + is_fixed_asset + "'); "
                execute_non_query(query, True, "", "", "", "")
                FormItemCatMainDet.viewDetail()
                actionLoad()
            End If
        End If

    End Sub

    Private Sub LookUpEdit1_KeyDown(sender As Object, e As KeyEventArgs) Handles LEExpenseType.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtCat.Focus()
        End If
    End Sub

    Private Sub TxtCat_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCat.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtCat.Text <> "" Then
                save()
            Else
                stopCustom("Can't blank.")
                TxtCat.Focus()
            End If
        End If
    End Sub
End Class