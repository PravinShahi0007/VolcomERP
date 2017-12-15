Public Class FormFGCodeReplaceStoreAdd
    Dim id_drawer_def As String = "-1"
    Dim id_product As String = "-1"
    Private Sub FormFGCodeReplaceStoreAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActiveControl = TxtStoreCode
        TxtQty.EditValue = 0
        TxtAvailable.EditValue = 0
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FormFGCodeReplaceStoreAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub resetInput(ByVal include_comp As Boolean, ByVal include_design As Boolean)
        id_drawer_def = "-1"
        id_product = "-1"
        If include_comp Then
            TxtStoreCode.Text = ""
        End If
        TxtStoreName.Text = ""
        If include_design Then
            TxtDesignCode.Text = ""
        End If
        TxtDesignName.Text = ""
        TxtQty.EditValue = 0
        TxtAvailable.EditValue = 0
    End Sub

    Private Sub TxtStoreCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtStoreCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim code As String = addSlashes(TxtStoreCode.Text)
            Dim data As DataTable = get_company_by_code(code, "AND comp.id_comp_cat = 6 ")
            If data.Rows.Count > 0 Then
                TxtStoreCode.Text = data.Rows(0)("comp_number").ToString
                TxtStoreName.Text = data.Rows(0)("comp_name").ToString
                id_drawer_def = data.Rows(0)("id_drawer_def").ToString
                TxtDesignCode.Focus()
            Else
                stopCustom("Store not found")
                TxtStoreCode.Text = ""
                TxtStoreCode.Focus()
            End If
        Else
            resetInput(False, True)
        End If
    End Sub

    Private Sub TxtDesignCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtDesignCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim code As String = addSlashes(TxtDesignCode.Text)
            Dim data As DataTable = execute_query("SELECT * FROM tb_m_product p WHERE p.product_full_code='" + code + "' ", -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                TxtDesignCode.Text = data.Rows(0)("product_full_code").ToString
                TxtDesignName.Text = data.Rows(0)("product_name").ToString
                id_product = data.Rows(0)("id_product").ToString
                getStock()
                TxtQty.Focus()
            Else
                stopCustom("Store not found")
                TxtDesignCode.Text = ""
                TxtDesignCode.Focus()
            End If
        Else
            resetInput(True, False)
        End If
    End Sub

    Sub getStock()
        Dim query As String = "SELECT SUM(IF(f.id_storage_category=2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)) AS qty
        FROM tb_storage_fg f
        WHERE f.id_wh_drawer='" + id_drawer_def + "' AND f.id_product='" + id_product + "'
        GROUP BY f.id_product "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            TxtAvailable.EditValue = data.Rows(0)("qty")
        Else
            TxtAvailable.EditValue = 0
        End If
    End Sub

    Private Sub TxtQty_EditValueChanged(sender As Object, e As EventArgs) Handles TxtQty.EditValueChanged
        If TxtQty.EditValue > TxtAvailable.EditValue Then
            stopCustom("Can't exceed " + TxtAvailable.EditValue.ToString)
            TxtQty.EditValue = 0
        End If
    End Sub


    Private Sub TxtQty_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtQty.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnAdd.Focus()
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        If id_drawer_def = "-1" Or id_product = "-1" Or TxtQty.EditValue = 0 Then
            stopCustom("Input can't blank. ")
        Else

        End If
    End Sub
End Class