Public Class FormSetupRawMatCode 
    'Activated
    Private Sub FormSetupRawMatCode_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
    End Sub
    'Deadctivated
    Private Sub FormSetupRawMatCode_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
    'Load Form
    Private Sub FormSetupRawMatCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewCodeType(1, GCCodeType) 'Code Type
    End Sub
    ' View Data
    Sub viewCodeType(ByVal value As Integer, ByVal GC As DevExpress.XtraGrid.GridControl)
        Dim query As String
        Dim data As DataTable
        If value = 1 Then
            query = "SELECT *, CONCAT_WS(' ',DATE(a.rec_created),TIME(a.rec_created)) as time_created, "
            query += "CONCAT_WS(' ',DATE(a.rec_modified),TIME(a.rec_modified)) as time_modified "
            query += "FROM tb_m_raw_mat_code a ORDER BY a.rec_created ASC "
            data = execute_query(query, -1, True, "", "", "", "")
            'setTimeFormat(data, "time_created")
            'setTimeFormat(data, "time_modified")
            GC.DataSource = data
            If data.Rows.Count <= 0 Then
                GCCodeTypeDetail.Enabled = False
            Else
                GCCodeTypeDetail.Enabled = True
            End If
            viewCodeType(2, GCCodeTypeDetail) 'Code Type Detail
        Else
            query = "SELECT * FROM tb_m_raw_mat_code_detail a INNER JOIN tb_m_raw_mat_code_lookup b ON a.id_code_lookup = b.id_code_lookup WHERE a.id_raw_mat_code = '" + GVCodeType.GetFocusedRowCellDisplayText("id_raw_mat_code").ToString + "' ORDER BY index_code ASC"
            data = execute_query(query, -1, True, "", "", "", "")
            GC.DataSource = data
        End If
    End Sub
    'Click & Refresh Detail
    Private Sub GCCodeType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GCCodeType.Click
        viewCodeType(2, GCCodeTypeDetail) 'Code Type Detail
    End Sub
    'Double click to edit description
    Private Sub GCCodeTypeDetail_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GCCodeTypeDetail.DoubleClick
        FormSetupRawMatCodeDesc.ShowDialog()
    End Sub
End Class