Public Class FormInfoPLSample 
    Public id_receiving As String
    Public id_info As String
    Public number_receiving As String
    '1 : PL Sample Receiving

    'Form Load
    Private Sub FormInfoPLSample_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If id_info = "1" Then
            viewPLSampleRec()
            LabelSubTitle.Text = "Receiving Number : " + number_receiving.ToString
        End If
    End Sub
    'view Data
    Sub viewPLSampleRec()
        Try
            Dim query As String = "SELECT a.id_pl_sample_purc, a2.id_sample_purc_rec, a.id_comp_contact_from , a.id_comp_contact_to,a.pl_sample_purc_date, a.pl_sample_purc_note, a.pl_sample_purc_number, b.pl_category, "
            query += "(d.comp_name) AS comp_name_from, (f.comp_name) AS comp_name_to "
            query += "FROM tb_pl_sample_purc a "
            query += "INNER JOIN tb_pl_sample_purc_rec a2 ON a.id_pl_sample_purc = a2.id_pl_sample_purc "
            query += "INNER JOIN tb_lookup_pl_category b ON a.id_pl_category = b.id_pl_category "
            query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
            query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
            query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
            query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp WHERE a2.id_sample_purc_rec = '" + id_receiving + "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCPL.DataSource = data
            If data.Rows.Count > 0 Then
                viewPLSampleRecDet()
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Sub viewPLSampleRecDet()
        Try
            Dim id_pl_sample_purc As String = GVPL.GetFocusedRowCellDisplayText("id_pl_sample_purc").ToString
            Dim query As String = "CALL view_pl_sample('" + id_pl_sample_purc + "') "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCListPurchase.DataSource = data
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    'Close
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Dispose()
    End Sub
    Private Sub FormInfoPLSample_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'Row Click Main To Detail
    Private Sub GVPL_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVPL.RowClick
        viewPLSampleRecDet()
    End Sub
End Class