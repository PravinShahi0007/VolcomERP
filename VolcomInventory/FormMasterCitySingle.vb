Imports DevExpress.XtraEditors

Public Class FormMasterCitySingle
    Public id_city As String = "-1"
    Public id_state As String = "-1"
    Private Sub FormMasterCitySingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If id_city <> "-1" Then
                'edit
                Dim query As String = String.Format("SELECT * FROM tb_m_city WHERE id_city = '{0}'", id_city)
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

                Dim city As String = data.Rows(0)("city").ToString

                data.Dispose()

                TECity.Text = city
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Server Disconnected on viewing city. Please wait a moment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Cursor = Cursors.WaitCursor

        Dim query As String
        Dim city As String = TECity.Text

        Try
            If id_city <> "-1" Then
                'update
                If Not formIsValid(EPCity) Then
                    XtraMessageBox.Show("Please check your input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    query = String.Format("UPDATE tb_m_city SET city='{0}' WHERE id_city='{1}'", city, id_city)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterArea.view_city(id_state)
                    Close()
                End If
            Else
                'insert
                If Not formIsValid(EPCity) Then
                    XtraMessageBox.Show("Please check your input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    query = String.Format("INSERT INTO tb_m_city(city,id_state) VALUES('{0}','{1}')", city, id_state)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterArea.view_city(id_state)
                    Close()
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Server Disconnected on saving city. Please wait a moment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Cursor = Cursors.Default
    End Sub

    Private Sub TECity_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TECity.Validating
        EP_TE_cant_blank(EPCity, TECity)
        '
        Dim query_jml As String = String.Format("SELECT COUNT(id_city) FROM tb_m_city WHERE city='{0}' AND id_city!='{1}'", TECity.Text, id_city)
        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(EPCity, TECity, "1")
        End If
    End Sub

    Private Sub FormMasterCitySingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class