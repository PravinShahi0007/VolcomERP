Public Class FormFGFirstDel
    Private Sub FormFGFirstDel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim cond As String = ""
        If TxtDesignCode.Text <> "" Then
            cond = "AND dsg.design_code='" + addSlashes(TxtDesignCode.Text) + "' "
        End If
        Dim query As String = "SELECT d.id_design, dsg.design_code AS `code`, dsg.design_display_name AS `name`, d.id_comp, c.comp_number, c.comp_name, d.id_pl_sales_order_del, del.pl_sales_order_del_number, 
        d.id_design_price, d.design_price, d.input_date, d.first_del, d.note
        FROM tb_m_design_first_del d
        INNER JOIN tb_m_design dsg ON dsg.id_design = d.id_design
        INNER JOIN tb_m_comp c ON c.id_comp = d.id_comp
        LEFT JOIN tb_pl_sales_order_del del ON del.id_pl_sales_order_del = d.id_pl_sales_order_del 
        WHERE 1=1 " + cond + "
        ORDER BY d.id_pl_sales_order_del ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub FormFGFirstDel_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
    End Sub

    Private Sub FormFGFirstDel_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewData()
    End Sub
End Class