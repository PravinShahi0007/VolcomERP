Public Class FormPromoRulesDet
    Public id As String = "-1"
    Public action As String = "-1"

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
            TxtLimitValue.EditValue = 0
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
        If e.KeyCode = Keys.Add Then
            Cursor = Cursors.WaitCursor
            Dim code As String = addSlashes(TxtCode.Text)
            Dim query As String = "SELECT p.id_product, p.product_full_code AS `code`, p.product_display_name AS `name` 
            FROM tb_m_product p
            INNER JOIN tb_m_design d ON d.id_design = p.id_design
            WHERE d.id_lookup_status_order!=2 AND d.id_active=1 AND p.product_full_code='" + code + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then

            End If
            Cursor = Cursors.Default
        End If
    End Sub
End Class