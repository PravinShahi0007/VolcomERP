Public Class FormMasterRegionSingle 
    Public id_country As String = "-1"
    Public id_region As String = "-1"
    Private Sub FormMasterRegionSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If id_region <> "-1" Then
                'edit
                Dim query As String = String.Format("SELECT * FROM tb_m_region WHERE id_region = '{0}'", id_region)
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

                Dim city As String = data.Rows(0)("region").ToString

                data.Dispose()

                TERegion.Text = city
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Cursor = Cursors.WaitCursor

        Dim query As String
        Dim region As String = TERegion.Text

        Try
            If id_region <> "-1" Then
                'update
                If Not formIsValid(EPRegion) Then
                    errorInput()
                Else
                    query = String.Format("UPDATE tb_m_region SET region='{0}' WHERE id_region='{1}'", region, id_region)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterArea.view_region(id_country)
                    Close()
                End If
            Else
                'insert
                If Not formIsValid(EPRegion) Then
                    errorInput()
                Else
                    query = String.Format("INSERT INTO tb_m_region(region,id_country) VALUES('{0}','{1}')", region, id_country)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterArea.view_region(id_country)
                    Close()
                End If
            End If
        Catch ex As Exception
            errorConnection()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub TERegion_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TERegion.Validating
        EP_TE_cant_blank(EPRegion, TERegion)
        '
        Dim query_jml As String = String.Format("SELECT COUNT(id_region) FROM tb_m_region WHERE region='{0}' AND id_region!='{1}'", TERegion.Text, id_region)
        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(EPRegion, TERegion, "1")
        End If
    End Sub

    Private Sub FormMasterRegionSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class