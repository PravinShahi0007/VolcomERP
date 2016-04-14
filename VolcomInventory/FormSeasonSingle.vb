Imports DevExpress.XtraEditors
Public Class FormSeasonSingle
    Public action As String
    Public id_season As String
    Dim id_range As String
    Dim date_start As Date

    'Load
    Private Sub FormSeasonSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If action = "ins" Then
            id_range = FormSeason.GVRange.GetFocusedRowCellDisplayText("id_range").ToString
        ElseIf action = "upd" Then
            Dim query As String = String.Format("SELECT * FROM tb_season WHERE id_season = '{0}'", id_season)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            id_range = data.Rows(0)("id_range").ToString
            TxtSeason.Text = data.Rows(0)("season").ToString
            Dim start_date_arr() As String = data.Rows(0)("date_season_start").ToString.Split(" ")
            DEStart.Text = start_date_arr(0)
            Dim start_end_arr() As String = data.Rows(0)("date_season_end").ToString.Split(" ")
            DEEnd.Text = start_end_arr(0)
            TxtSeasonPrintedName.Text = data.Rows(0)("season_printed_name").ToString
        End If
    End Sub
    'Close
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Dispose()
    End Sub
    'Validate
    Private Sub TxtSeason_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtSeason.Validating
        EP_TE_cant_blank(ErrorProviderSeason, TxtSeason)
    End Sub
    'Save
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Me.ValidateChildren()
        Dim query As String
        Dim found_season As Boolean = False
        Dim found_season_printed_name As Boolean = False
        Dim jum As Integer

        'cek row db
        query = "SELECT COUNT(*) FROM tb_season WHERE season = '" + addSlashes(TxtSeason.Text) + "' "
        If action = "upd" Then
            query += "AND id_season != '" + id_season + "'"
        End If
        jum = execute_query(query, 0, True, "", "", "", "")
        If jum >= 1 Then
            found_season = True
        End If
        query = "SELECT COUNT(*) FROM tb_season WHERE season_printed_name = '" + addSlashes(TxtSeasonPrintedName.Text) + "' "
        If action = "upd" Then
            query += "AND id_season != '" + id_season + "'"
        End If
        jum = execute_query(query, 0, True, "", "", "", "")
        If jum >= 1 Then
            found_season_printed_name = True
        End If

        If Not formIsValid(ErrorProviderSeason) Then
            errorInput()
        Else
            If found_season Or found_season_printed_name Then
                XtraMessageBox.Show("Season already exist, please check your input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Dim season As String = TxtSeason.Text.ToString
                Dim season_printed_name As String = TxtSeasonPrintedName.Text.ToString
                Dim date_season_start As String = DEStart.Text
                Dim date_season_start_format As Date = CType(date_season_start, Date)
                date_season_start = date_season_start_format.ToString("yyyy-MM-dd")
                Dim date_season_end As String = DEEnd.Text
                Dim date_season_end_format As Date = CType(date_season_end, Date)
                date_season_end = date_season_end_format.ToString("yyyy-MM-dd")

                If action = "ins" Then
                    Try
                        query = String.Format("INSERT tb_season(id_range, season, season_printed_name, date_season_start, date_season_end) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}'); SELECT LAST_INSERT_ID(); ", id_range, season, season_printed_name, date_season_start, date_season_end)
                        id_season = execute_query(query, 0, True, "", "", "", "")
                        ' < septian 28 May 14
                        '   - add default delivery 1


                        query = String.Format("INSERT INTO tb_season_delivery(delivery, id_season) VALUES('1', '{0}'); ", id_season)
                        execute_non_query(query, True, "", "", "", "")
                        ' >
                        logData("tb_season", 1)
                        FormSeason.viewSeason()
                        FormSeason.GVSeason.FocusedRowHandle = find_row(FormSeason.GVSeason, "id_season", id_season)
                        FormSeason.viewDelivery(id_season)
                        Dispose()
                    Catch ex As Exception
                        errorConnection()
                    End Try
                ElseIf action = "upd" Then
                    Try
                        query = String.Format("UPDATE tb_season SET id_range='{0}', season='{1}', season_printed_name='{2}', date_season_start='{3}', date_season_end='{4}' WHERE id_season='{5}'", id_range, season, season_printed_name, date_season_start, date_season_end, id_season)
                        execute_non_query(query, True, "", "", "", "")
                        logData("tb_season", 2)
                        FormSeason.viewSeason()
                        FormSeason.GVSeason.FocusedRowHandle = find_row(FormSeason.GVSeason, "id_season", id_season)
                        FormSeason.viewDelivery(id_season)
                        Dispose()
                    Catch ex As Exception
                        errorConnection()
                    End Try
                End If
            End If
        End If
    End Sub
    'Validate Season Printed Name 
    Private Sub TxtSeasonPrintedName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtSeasonPrintedName.Validating
        EP_TE_cant_blank(ErrorProviderSeason, TxtSeasonPrintedName)
    End Sub
    'Validating Start Date
    Private Sub DEStart_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DEStart.Validating
        EP_DE_cant_blank(ErrorProviderSeason, DEStart)
    End Sub
    'Validating End Date
    Private Sub DEEnd_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DEEnd.Validating
        EP_DE_cant_blank(ErrorProviderSeason, DEEnd)
    End Sub
    'Start Date
    Private Sub DEStart_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEStart.EditValueChanged
        Try
            Dim dt_str As String = DEStart.Text
            date_start = Date.Parse(DEStart.Text)
            DEEnd.Properties.MinValue = date_start
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FormSeasonSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class