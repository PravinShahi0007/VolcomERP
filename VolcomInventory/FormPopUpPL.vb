Public Class FormPopUpPL 
    Public id_pop_up As String = "-1"
    Public id_pl As String = "-1"
    '1 : Receipt Slip Warehouse

    'Form Load
    Private Sub FormPopUpPL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If id_pop_up = "1" Then
            viewMain()
            If id_pl <> "-1" Then
                GVPL.FocusedRowHandle = find_row(GVPL, "id_pl_sample_purc", id_pl)
            End If
        End If
    End Sub
    'List PL
    Sub viewMain()
        Try
            Dim query As String = "SELECT a.id_pl_sample_purc, a.id_comp_contact_from , a.id_comp_contact_to,a.pl_sample_purc_date, a.pl_sample_purc_note, a.pl_sample_purc_number, b.pl_category, "
            query += "(d.comp_number) AS code_comp_from, (d.comp_name) AS comp_name_from, (f.comp_number) AS code_comp_to,(f.comp_name) AS comp_name, g.report_status "
            query += "FROM tb_pl_sample_purc a "
            ' query += "INNER JOIN tb_pl_sample_purc_rec a2 ON a.id_pl_sample_purc = a2.id_pl_sample_purc "
            query += "INNER JOIN tb_lookup_pl_category b ON a.id_pl_category = b.id_pl_category "
            query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
            query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
            query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
            query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
            query += "INNER JOIN tb_lookup_report_status g ON a.id_report_status = g.id_report_status "
            query += "WHERE a.receipt_sample_number = '-' AND (a.id_report_status = '3' OR a.id_report_status = '4' OR a.id_report_status = '6' OR a.id_report_status = '7') "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCPL.DataSource = data
            If data.Rows.Count > 0 Then 'ada data
                BtnSave.Enabled = True
                viewDetail()
            Else
                BtnSave.Enabled = False
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    'Row Click
    Private Sub GVPL_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVPL.RowClick
        viewDetail()
    End Sub
    'List Detail
    Sub viewDetail()
        If id_pop_up = "1" Then
            Try
                Dim id_pl_sample_purc As String = GVPL.GetFocusedRowCellDisplayText("id_pl_sample_purc").ToString
                Dim query As String = "CALL view_pl_sample('" + id_pl_sample_purc + "')"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                GCDetailPL.DataSource = data
            Catch ex As Exception
                'no action 
            End Try
        End If
    End Sub
    'Btn Cancel
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    'Form Closed
    Private Sub FormPopUpPL_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'Btn Choose
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If id_pop_up = "1" Then
            FormSampleReceiptSingle.id_comp_contact_from = GVPL.GetFocusedRowCellDisplayText("id_comp_contact_from").ToString
            FormSampleReceiptSingle.TxtCodeCompFrom.Text = GVPL.GetFocusedRowCellDisplayText("code_comp_from").ToString
            FormSampleReceiptSingle.TxtNameCompFrom.Text = GVPL.GetFocusedRowCellDisplayText("comp_name_from").ToString
            FormSampleReceiptSingle.id_comp_contact_to = GVPL.GetFocusedRowCellDisplayText("id_comp_contact_to").ToString
            FormSampleReceiptSingle.TxtCodeCompTo.Text = GVPL.GetFocusedRowCellDisplayText("code_comp_to").ToString
            FormSampleReceiptSingle.TxtNameCompTo.Text = GVPL.GetFocusedRowCellDisplayText("comp_name").ToString
            FormSampleReceiptSingle.id_pl_sample_purc = GVPL.GetFocusedRowCellDisplayText("id_pl_sample_purc").ToString
            FormSampleReceiptSingle.TxtPLNumber.Text = GVPL.GetFocusedRowCellDisplayText("pl_sample_purc_number").ToString
            FormSampleReceiptSingle.TxtPLCategory.Text = GVPL.GetFocusedRowCellDisplayText("pl_category").ToString
            FormSampleReceiptSingle.viewDetailPL()
            Close()
        End If
    End Sub
    'Number Table
    Private Sub GVDetailPL_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetailPL.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class