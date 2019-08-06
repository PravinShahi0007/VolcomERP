Public Class FormItemCatProposeAdd
    Private Sub FormItemCatProposeAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub actionLoad()
        viewType()
        viewMainCategory()
        TxtCat.Text = ""
        TxtCatEn.Text = ""
    End Sub

    Sub viewType()
        Dim query As String = "SELECT * FROM tb_lookup_expense_type t "
        viewLookupQuery(LEExpenseType, query, 0, "expense_type", "id_expense_type")
    End Sub

    Sub viewMainCategory()
        Dim query As String = "SELECT * FROM tb_item_cat_main t
INNER JOIN tb_lookup_expense_type tt ON tt.`id_expense_type`=t.`id_expense_type` "
        viewSearchLookupQuery(SLEMainCategory, query, "id_item_cat_main", "item_cat_main", "id_item_cat_main")
        SLEMainCategory.EditValue = Nothing
    End Sub

    Private Sub FormItemCatProposeAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
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
        ElseIf SLEMainCategory.EditValue = Nothing Then
            stopCustom("Please choose main category")
        Else
            Dim item_cat As String = addSlashes(TxtCat.Text).Trim()
            Dim item_cat_en As String = addSlashes(TxtCatEn.Text).Trim()
            Dim id_expense_type As String = LEExpenseType.EditValue.ToString

            'cek kondisi master
            Dim cm As Boolean = False
            Dim qm As String = "SELECT * FROM tb_item_cat WHERE item_cat='" + item_cat + "' "
            Dim dm As DataTable = execute_query(qm, -1, True, "", "", "", "")
            If dm.Rows.Count > 0 Then
                cm = True
            End If

            'cel kondisi propose
            Dim cp As Boolean = False
            Dim qp As String = "SELECT * FROM tb_item_cat_propose_det d 
            INNER JOIN tb_item_cat_propose m ON m.id_item_cat_propose = d.id_item_cat_propose
            WHERE d.item_cat='" + item_cat + "' AND m.id_report_status!=5 "
            Dim dp As DataTable = execute_query(qp, -1, True, "", "", "", "")
            If dp.Rows.Count > 0 Then
                cp = True
            End If

            If cm Or cp Then
                stopCustom("Category already exist")
                TxtCat.Focus()
            Else
                Dim query As String = "INSERT INTO tb_item_cat_propose_det(id_item_cat_propose, id_item_cat_main, id_expense_type, item_cat, item_cat_en)
            VALUES('" + FormItemCatProposeDet.id + "','" & SLEMainCategory.EditValue.ToString & "', " + id_expense_type + ", '" + item_cat + "', '" + item_cat_en + "'); "
                execute_non_query(query, True, "", "", "", "")
                FormItemCatProposeDet.viewDetail()
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

    Private Sub TxtCatEn_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCatEn.KeyDown
        If e.KeyCode = Keys.Enter Then
            save()
        End If
    End Sub

    Private Sub SLEMainCategory_EditValueChanged(sender As Object, e As EventArgs) Handles SLEMainCategory.EditValueChanged
        If Not SLEMainCategory.EditValue = Nothing Then
            Try
                Dim id_expense_type As String = SLEMainCategory.Properties.View.GetFocusedRowCellValue("id_expense_type").ToString
                LEExpenseType.EditValue = Nothing
                LEExpenseType.ItemIndex = LEExpenseType.Properties.GetDataSourceRowIndex("id_expense_type", id_expense_type)
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class