Imports DevExpress.XtraEditors

Public Class FormRangeSingle
    Public action As String
    Public Shared id_range As String = "-1"
    Public id_season_par As String = "-1"

    'Form Closed
    Private Sub FormRangeSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'Cancel
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    'Validating
    Private Sub TxtRange_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        EP_TE_cant_blank(EPRange, TxtRange)
    End Sub
    'Form Load
    Private Sub FormRangeSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If action = "upd" Then
            Dim query As String = ""
            query += "SELECT rg.id_range, ss.id_season, rg.range, rg.description_range, rg.year_range, ss.season, ss.season_printed_name FROM tb_range rg "
            query += "INNER JOIN tb_season ss On rg.id_range = ss.id_range "
            query += "WHERE rg.id_range='" + id_range + "' "
            query += "ORDER BY rg.id_range DESC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtRange.Text = data.Rows(0)("range").ToString
            MEDescription.Text = data.Rows(0)("description_range").ToString
            TxtSeason.Text = data.Rows(0)("season").ToString
            TxtSeasonPrintedName.Text = data.Rows(0)("season_printed_name").ToString
            TxtYear.Text = data.Rows(0)("year_range").ToString
        ElseIf action = "ins" Then
            If FormSeason.is_md = "1" Then
                Dim query As String = "SELECT IF(ISNULL(MAX(tb_range.range)), 1, MAX(tb_range.range)+1) AS current_range FROM tb_range WHERE is_md='1' "
                Dim current_range As String = execute_query(query, 0, True, "", "", "", "")
                TxtRange.Text = current_range.ToString
            Else
                TxtRange.Text = "0"
            End If


        End If
    End Sub
    'Save
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ValidateChildren()
        If Not formIsValid(EPRange) Then
            errorInput()
        Else
            'cek sudah adakah delivery untuk season tsb
            Dim range As String = addSlashes(TxtRange.Text)
            Dim year_range As String = addSlashes(TxtYear.Text)
            Dim description_range As String = addSlashes(MEDescription.Text)
            Dim season As String = TxtSeason.Text
            Dim season_printed_name As String = TxtSeasonPrintedName.Text
            Dim query_count = String.Format("SELECT * FROM tb_range WHERE tb_range.range='{0}'", range)
            Dim id_dept As String = "-1"
            If FormSeason.is_md = "1" Then
                id_dept = get_setup_field("ss_default_dept").ToString
            Else
                id_dept = id_departement_user
            End If

            If action = "upd" Then
                query_count = query_count + String.Format(" AND id_range!='{0}'", id_range)
            End If
            Dim data_count As DataTable = execute_query(query_count, -1, True, "", "", "", "")
            Dim row_count As Integer = data_count.Rows.Count
            If row_count > 0 And FormSeason.is_md = "1" Then
                XtraMessageBox.Show("Range season already exist, please check your input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Try
                    Dim query As String
                    If action = "ins" Then
                        query = String.Format("INSERT INTO tb_range(tb_range.range, tb_range.description_range, year_range, is_md, id_departement) VALUES('{0}', '{1}', '{2}', '{3}', '{4}'); SELECT LAST_INSERT_ID(); ", range, description_range, year_range, FormSeason.is_md, id_dept)
                        id_range = execute_query(query, 0, True, "", "", "", "")

                        'u/ season
                        Dim query_season As String = "INSERT INTO tb_season(id_range, season, season_printed_name) VALUES "
                        query_season += "('" + id_range + "', '" + season + "', '" + season_printed_name + "'); SELECT LAST_INSERT_ID(); "
                        Dim id_season As String = execute_query(query_season, 0, True, "", "", "", "")

                        'del
                        Dim query_del = String.Format("INSERT INTO tb_season_delivery(delivery, id_season, delivery_date, est_wh_date) VALUES('1', '{0}','2050-01-01','2050-01-01'); ", id_season)
                        execute_non_query(query_del, True, "", "", "", "")

                        logData("tb_range", 1)
                        FormSeason.viewRange()
                        FormSeason.GVRange.FocusedRowHandle = find_row(FormSeason.GVRange, "id_range", id_range)
                        FormSeason.viewDelivery(id_season)
                        Close()
                    ElseIf action = "upd" Then
                        query = ""
                        query += "UPDATE tb_range rg INNER JOIN tb_season ss On rg.id_range = ss.id_range "
                        query += "SET ss.season='" + season + "', ss.season_printed_name='" + season_printed_name + "',rg.description_range='" + description_range + "', rg.range='" + range + "', rg.year_range='" + year_range + "' "
                        query += "WHERE rg.id_range ='" + id_range + "' "
                        execute_non_query(query, True, "", "", "", "")
                        logData("tb_range", 2)
                        FormSeason.viewRange()
                        FormSeason.GVRange.FocusedRowHandle = find_row(FormSeason.GVRange, "id_range", id_range)
                        FormSeason.viewDelivery(id_season_par)
                        Close()
                    End If
                Catch ex As Exception
                    errorConnection()
                    Close()
                End Try
            End If
        End If
    End Sub
    'Validating Description
    Private Sub MEDescription_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MEDescription.Validating
        EP_ME_cant_blank(EPRange, MEDescription)
    End Sub

    Private Sub TxtSeason_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtSeason.Validating
        EP_TE_cant_blank(EPRange, TxtSeason)
    End Sub

    Private Sub TxtSeasonPrintedName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtSeasonPrintedName.Validating
        EP_TE_cant_blank(EPRange, TxtSeasonPrintedName)
    End Sub
End Class