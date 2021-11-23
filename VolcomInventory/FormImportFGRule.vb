Public Class FormImportFGRule

    Private Sub FormImportFGRule_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SetNonActiveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetNonActiveToolStripMenuItem.Click
        If GVRule.RowCount > 0 Then
            Dim q As String = "UPDATE tb_import_rule SET is_active=2 WHERE id_import_rule='" & GVRule.GetFocusedRowCellValue("id_import_rule").ToString & "'"
            execute_non_query(q, True, "", "", "", "")
            refresh_rule()
        End If
    End Sub

    Private Sub BAddRule_Click(sender As Object, e As EventArgs) Handles BAddRule.Click
        If Not TERuleName.Text = "" Then
            Dim q As String = "INSERT INTO tb_import_rule(import_rule,is_active) VALUES('" & addSlashes(TERuleName.Text) & "','1')"
            execute_non_query(q, True, "", "", "", "")
            '
            refresh_rule()
        End If
    End Sub

    Sub refresh_rule()
        Dim q As String = "SELECT id_import_rule,import_rule,IF(is_active=1,'Active','Not Active') AS active_sts FROM tb_import_rule ORDER BY id_import_rule DESC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        '
        GCRule.DataSource = dt
        If GVRule.RowCount > 0 Then
            refresh_vendor()
            refresh_det()
        End If
    End Sub

    Sub refresh_vendor()
        If GVRule.RowCount > 0 Then
            Dim q As String = "SELECT v.id_import_rule_vendor,v.id_comp,c.comp_number,c.comp_name FROM tb_import_rule_vendor v
INNER JOIN tb_m_comp c ON c.id_comp=v.id_comp
WHERE v.id_import_rule='" & GVRule.GetFocusedRowCellValue("id_import_rule").ToString & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            '
            GCVendor.DataSource = dt
        End If
    End Sub

    Sub refresh_det()
        If GVRule.RowCount > 0 Then
            Dim q As String = "SELECT `id_import_rule_det`,`min_qty_order`,`max_qty_order`,`max_minor`,`max_major` FROM tb_import_rule_det d
WHERE d.id_import_rule='" & GVRule.GetFocusedRowCellValue("id_import_rule").ToString & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            '
            GCDetailRule.DataSource = dt
        End If
    End Sub

    Private Sub GVRule_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRule.FocusedRowChanged
        If GVRule.RowCount > 0 Then
            refresh_vendor()
            refresh_det()
        End If
    End Sub

    Private Sub BRefreshRule_Click(sender As Object, e As EventArgs) Handles BRefreshRule.Click
        refresh_rule()
    End Sub

    Private Sub BRefreshVendor_Click(sender As Object, e As EventArgs) Handles BRefreshVendor.Click
        refresh_vendor()
    End Sub

    Private Sub BRefreshDetailRule_Click(sender As Object, e As EventArgs) Handles BRefreshDetailRule.Click
        refresh_det()
    End Sub

    Private Sub FormImportFGRule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_vendor()
    End Sub

    Sub view_vendor()
        Dim q As String = ""
        q = "SELECT comp.id_comp,comp.comp_number, comp.comp_name, CONCAT_WS(' - ', comp.comp_number,comp.comp_name) AS comp_name_label FROM tb_m_comp comp
INNER JOIN tb_m_city ct ON ct.`id_city`=comp.`id_city` AND comp.is_active=1
INNER JOIN tb_m_state st ON st.`id_state`=ct.`id_state`
INNER JOIN tb_m_region reg ON reg.`id_region`=st.`id_region`
INNER JOIN tb_m_country co ON co.`id_country`=reg.`id_country` AND co.id_country!=5 "
        Dim data As DataTable = execute_query(q, -1, True, "", "", "", "")
        viewSearchLookupQuery(SLEVendor, q, "id_comp", "comp_name_label", "id_comp")
    End Sub

    Private Sub BAddVendor_Click(sender As Object, e As EventArgs) Handles BAddVendor.Click
        If GVRule.RowCount > 0 Then
            'check sudah insert apa blm
            Dim qc As String = "SELECT * FROM tb_import_rule_vendor WHERE id_comp='" & SLEVendor.EditValue.ToString & "' AND id_import_rule='" & GVRule.GetFocusedRowCellValue("id_import_rule").ToString & "'"
            Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
            If dtc.Rows.Count = 0 Then
                Dim q As String = "INSERT INTO tb_import_rule_vendor(id_import_rule,id_comp) VALUES('" & GVRule.GetFocusedRowCellValue("id_import_rule").ToString & "','" & SLEVendor.EditValue.ToString & "')"
                execute_non_query(q, True, "", "", "", "")
                refresh_vendor()
            Else
                warningCustom("Vendor ini sudah terdaftar pada rule bersangkutan")
            End If
        Else
            warningCustom("Pilih rule terlebih dahulu")
        End If
    End Sub

    Private Sub SMDropVendor_Click(sender As Object, e As EventArgs) Handles SMDropVendor.Click
        If GVRule.RowCount > 0 Then
            If GVVendor.RowCount > 0 Then
                Dim q As String = "DELETE FROM tb_import_rule_vendor WHERE id_import_rule_vendor='" & GVVendor.GetFocusedRowCellValue("id_import_rule_vendor").ToString & "'"
                execute_non_query(q, True, "", "", "", "")
                refresh_vendor()
            End If
        End If
    End Sub
End Class