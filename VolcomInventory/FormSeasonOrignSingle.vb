Public Class FormSeasonorignSingle
    Public id_season_orign As String
    Public id_country As String
    Public season_orign_year As String
    Public action As String

    'Validating Season
    Private Sub TxtSeason_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtSeason.Validating
        EP_TE_cant_blank(EPSeason, TxtSeason)
    End Sub
    'Validating Display name
    Private Sub TxtSeasonPrintedName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtSeasonPrintedName.Validating
        EP_TE_cant_blank(EPSeason, TxtSeasonPrintedName)
    End Sub
    'Form Load
    Private Sub FormSeasonorignSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewCountry()
        getYear(ComboBoxEditYear)
        If action = "upd" Then
            LECountry.ItemIndex = LECountry.Properties.GetDataSourceRowIndex("id_country", id_country)
            ComboBoxEditYear.Text = season_orign_year
        End If
    End Sub
    'View Lookup
    Sub viewCountry()
        Dim query As String = "SELECT * FROM tb_m_country ORDER BY country ASC"
        viewLookupQuery(LECountry, query, 0, "country", "id_country")
    End Sub
    'Form Close
    Private Sub FormSeasonorignSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'Close
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    'Save
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ValidateChildren()
        If Not formIsValid(EPSeason) Then
            errorInput()
        Else
            Dim query As String
            Dim season_orign As String = addSlashes(TxtSeason.Text)
            Dim season_orign_display As String = addSlashes(TxtSeasonPrintedName.Text)
            season_orign_year = ComboBoxEditYear.Text
            Dim id_country As String = LECountry.EditValue

            'Cek udah ada ato belum di row
            Dim query_cek As String = "SELECT * FROM tb_season_orign a WHERE a.id_country = '" + id_country + "' AND a.season_orign = '" + season_orign + "' AND a.season_orign_display = '" + season_orign_display + "' AND a.season_orign_year = '" + season_orign_year + "' "
            If action = "upd" Then
                query_cek += "AND a.id_season_orign != '" + id_season_orign + "' "
            End If
            Dim data_cek As DataTable = execute_query(query_cek, -1, True, "", "", "", "")
            If data_cek.Rows.Count > 0 Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Season Origin already exist, please check your input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If action = "ins" Then
                    Try
                        query = String.Format("INSERT INTO tb_season_orign(season_orign, season_orign_display, id_country, season_orign_year) VALUES ('{0}', '{1}', '{2}', '{3}')", season_orign, season_orign_display, id_country, season_orign_year)
                        execute_non_query(query, True, "", "", "", "")
                        logData("tb_season_orign", 1)
                        FormSeason.viewSeasonOrign()
                        Close()
                    Catch ex As Exception
                        errorConnection()
                        Close()
                    End Try
                ElseIf action = "upd" Then
                    Try
                        query = String.Format("UPDATE tb_season_orign SET season_orign = '{0}', season_orign_display='{1}', id_country = '{2}', season_orign_year = '{3}' WHERE id_season_orign = '{4}'", season_orign, season_orign_display, id_country, season_orign_year, id_season_orign)
                        execute_non_query(query, True, "", "", "", "")
                        logData("tb_season_orign", 2)
                        FormSeason.viewSeasonOrign()
                        Close()
                    Catch ex As Exception
                        errorConnection()
                        Close()
                    End Try
                End If
            End If
        End If
    End Sub
End Class