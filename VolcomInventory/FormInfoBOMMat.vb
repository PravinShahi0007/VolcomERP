Public Class FormInfoBOMMat 
    Public id_pd_design As String = "-1"

    Private Sub FormInfoBOMMat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RCIsCOP.ValueChecked = Convert.ToSByte(1)
        RCIsCOP.ValueUnchecked = Convert.ToSByte(2)

        view_bom_mat()
    End Sub
    Sub view_bom_mat()
        Try
            Dim query As String
            query = "CALL view_mat_design(" & id_pd_design & ")"

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBomDetMat.DataSource = data
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub FormInfoBOMMat_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class