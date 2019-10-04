Public Class FormPromoRulesDet
    Public id As String = "-1"
    Public action As String = "-1"
    Dim id_product As String = "-1"

    Sub viewDesignCat()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT * FROM tb_lookup_design_cat c"
        viewLookupQuery(LEProductStatus, query, 0, "design_cat", "id_design_cat")
        Cursor = Cursors.Default
    End Sub

    Private Sub FormPromoRulesDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDesignCat()
        actionLoad
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        If action = "ins" Then
            'dteail
            Dim qd As String = "SELECT o.*, 'no' AS `is_select` FROM tb_store_conn o "
            Dim dd As DataTable = execute_query(qd, -1, True, "", "", "", "")
            GCStore.DataSource = dd
            GVStore.BestFitColumns()

            TxtLimitValue.EditValue = 0
            LEProductStatus.Focus()
            ActiveControl = LEProductStatus
        ElseIf action = "upd" Then
            Dim query As String = "SELECT r.id_rules, r.id_design_cat, dc.design_cat, r.limit_value, r.id_product, p.product_full_code AS `code`, p.product_display_name AS `name`, cd.code_detail_name AS `size`
            FROM tb_promo_rules r 
            INNER JOIN tb_lookup_design_cat dc ON dc.id_design_cat = r.id_design_cat
            INNER JOIN tb_m_product p ON p.id_product = r.id_product 
            INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
            WHERE r.id_rules='" + id + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            LEProductStatus.ItemIndex = LEProductStatus.Properties.GetDataSourceRowIndex("id_design_cat", data.Rows(0)("id_design_cat").ToString)
            TxtLimitValue.EditValue = data.Rows(0)("limit_value")
            id_product = data.Rows(0)("id_product").ToString
            TxtCode.Text = data.Rows(0)("code").ToString
            TxtName.Text = data.Rows(0)("name").ToString
            TxtSize.Text = data.Rows(0)("size").ToString

            'detail
            Dim qd As String = "SELECT c.id_outlet, c.outlet_name, IF(!ISNULL(rd.id_outlet), 'yes', 'no') AS `is_select`,
            c.id_store_conn, c.outlet_name, c.host, c.username, c.pass, c.db
            FROM tb_store_conn c
            LEFT JOIN tb_promo_rules_det rd ON rd.id_outlet = c.id_outlet AND rd.id_rules=" + id + " "
            Dim dd As DataTable = execute_query(qd, -1, True, "", "", "", "")
            GCStore.DataSource = dd
            GVStore.BestFitColumns()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FormPromoRulesDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub TxtCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            Dim code As String = addSlashes(TxtCode.Text)
            Dim query As String = "SELECT p.id_product, p.product_full_code AS `code`, p.product_display_name AS `name`, cd.code_detail_name AS `size` 
            FROM tb_m_product p
            INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
            INNER JOIN tb_m_design d ON d.id_design = p.id_design
            WHERE d.id_lookup_status_order!=2 AND d.id_active=1 AND p.product_full_code='" + code + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                id_product = data.Rows(0)("id_product").ToString
                TxtCode.Text = data.Rows(0)("code").ToString
                TxtName.Text = data.Rows(0)("name").ToString
                TxtSize.Text = data.Rows(0)("size").ToString
            Else
                stopCustom("Code not found")
                TxtCode.Text = ""
                resetProduct()
            End If
            Cursor = Cursors.Default
        Else
            resetProduct()
        End If
    End Sub

    Sub resetProduct()
        id_product = "-1"
        TxtName.Text = ""
    End Sub

    Sub insertDetail()
        'detail
        makeSafeGV(GVStore)
        GVStore.ActiveFilterString = "[is_select]='yes'"
        Dim query_det As String = "INSERT INTO tb_promo_rules_det(id_rules, id_outlet) VALUES "
        For i As Integer = 0 To GVStore.RowCount - 1
            If i > 0 Then
                query_det += ", "
            End If
            query_det += "(" + id + ", " + GVStore.GetRowCellValue(i, "id_outlet").ToString + ") "
        Next
        If GVStore.RowCount > 0 Then
            execute_non_query(query_det, True, "", "", "", "")
        End If
        GVStore.ActiveFilterString = ""
    End Sub

    Sub syncStore()
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVStore)
        GVStore.ActiveFilterString = "[is_select]='yes'"
        For i As Integer = 0 To GVStore.RowCount - 1
            Dim id_outlet As String = GVStore.GetRowCellValue(i, "id_outlet").ToString
            Dim host As String = GVStore.GetRowCellValue(i, "host").ToString
            Dim username As String = GVStore.GetRowCellValue(i, "username").ToString
            Dim pass As String = GVStore.GetRowCellValue(i, "pass").ToString
            Dim db As String = GVStore.GetRowCellValue(i, "db").ToString

            Dim query As String = "INSERT INTO tb_promo_rules(id_rules, id_design_cat, limit_value, id_product) VALUES
            ('" + id + "', '" + LEProductStatus.EditValue.ToString + "', '" + decimalSQL(TxtLimitValue.EditValue.ToString) + "', '" + id_product + "'); "
            execute_non_query_long(query, False, host, username, pass, db)
        Next
        GVStore.ActiveFilterString = ""
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If id_product = "-1" Then
            stopCustom("Product not found")
        Else
            Dim id_design_cat As String = LEProductStatus.EditValue.ToString
            Dim limit_value As String = decimalSQL(TxtLimitValue.EditValue.ToString)

            If action = "ins" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save this rule ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    'main
                    Dim query As String = "INSERT INTO tb_promo_rules(id_design_cat, limit_value, id_product) VALUES (" + id_design_cat + ", " + limit_value + ", " + id_product + "); SELECT LAST_INSERT_ID(); "
                    id = execute_query(query, 0, True, "", "", "", "")

                    'detail
                    insertDetail()

                    'sync to store
                    syncStore()

                    'refresh
                    FormPromoRules.viewRules()
                    FormPromoRules.viewStore()
                    FormPromoRules.GVRules.FocusedRowHandle = find_row(FormPromoRules.GVRules, "id_rules", id)
                    Close()
                    Cursor = Cursors.Default
                End If
            ElseIf action = "upd" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save changes this rule ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor

                    'hapus di toko
                    Dim qold As String = "SELECT * 
                    FROM tb_promo_rules_det rd
                    INNER JOIN tb_store_conn c ON c.id_outlet = rd.id_outlet
                    WHERE rd.id_rules=" + id + " "
                    Dim dold As DataTable = execute_query(qold, -1, True, "", "", "", "")
                    For i As Integer = 0 To dold.Rows.Count - 1
                        Dim id_outlet As String = GVStore.GetRowCellValue(i, "id_outlet").ToString
                        Dim host As String = GVStore.GetRowCellValue(i, "host").ToString
                        Dim username As String = GVStore.GetRowCellValue(i, "username").ToString
                        Dim pass As String = GVStore.GetRowCellValue(i, "pass").ToString
                        Dim db As String = GVStore.GetRowCellValue(i, "db").ToString

                        Dim qds As String = "DELETE FROM tb_promo_rules WHERE id_rules='" + id + "' "
                        execute_non_query_long(qds, False, host, username, pass, db)
                    Next

                    'main 
                    Dim query As String = "UPDATE tb_promo_rules Set id_design_cat='" + id_design_cat + "', limit_value='" + limit_value + "', id_product='" + id_product + "' WHERE id_rules='" + id + "' "
                    execute_non_query(query, True, "", "", "", "")

                    'detail
                    Dim query_det As String = "DELETE FROM tb_promo_rules_det WHERE id_rules='" + id + "' "
                    execute_non_query(query_det, True, "", "", "", "")
                    insertDetail()

                    'synv
                    syncStore()

                    'refresh
                    FormPromoRules.viewRules()
                    FormPromoRules.viewStore()
                    FormPromoRules.GVRules.FocusedRowHandle = find_row(FormPromoRules.GVRules, "id_rules", id)
                    Close()

                    Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub
End Class