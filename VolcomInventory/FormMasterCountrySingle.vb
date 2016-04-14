Public Class FormMasterCountrySingle
    Public id_country As String = "-1"
    Private Sub FormMasterCountrySingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    Private Sub FormMasterCountrySingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If id_country <> "-1" Then
                'edit
                Dim query As String = String.Format("SELECT * FROM tb_m_country WHERE id_country = '{0}'", id_country)
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

                Dim country As String = data.Rows(0)("country").ToString
                Dim country_display_name As String = data.Rows(0)("country_display_name").ToString
                data.Dispose()

                TECountry.Text = country
                TECountryDisplay.Text = country_display_name
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Cursor = Cursors.WaitCursor

        Dim query As String
        Dim country As String = addSlashes(TECountry.Text)
        Dim country_display_name As String = addSlashes(TECountryDisplay.Text)

        Try
            If id_country <> "-1" Then
                'update
                If Not formIsValid(EPCountry) Then
                    errorInput()
                Else
                    query = String.Format("UPDATE tb_m_country SET country='{0}', country_display_name = '{1}' WHERE id_country='{2}'", country, country_display_name, id_country)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterArea.view_country()
                    Close()
                End If
            Else
                'insert
                If Not formIsValid(EPCountry) Then
                    errorInput()
                Else
                    query = String.Format("INSERT INTO tb_m_country(country, country_display_name) VALUES('{0}', '{1}')", country, country_display_name)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterArea.view_country()
                    Close()
                End If
            End If
        Catch ex As Exception
            errorConnection()
        End Try

        Cursor = Cursors.Default
    End Sub

    Private Sub TECountry_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TECountry.Validating
        EP_TE_cant_blank(EPCountry, TECountry)
        '
        Dim query_real As String = "SELECT COUNT(id_country) FROM tb_m_country WHERE country='{0}' "
        If id_country <> "-1" Then
            query_real += "AND id_country!='" + id_country + "' "
        End If
        Dim query_jml As String = String.Format(query_real, TECountry.Text)
        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(EPCountry, TECountry, "1")
        End If
    End Sub

    Private Sub TECountryDisplay_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TECountryDisplay.Validating
        EP_TE_cant_blank(EPCountry, TECountryDisplay)
    End Sub
End Class