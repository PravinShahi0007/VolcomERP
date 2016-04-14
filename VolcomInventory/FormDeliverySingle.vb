Imports DevExpress.XtraEditors
Public Class FormDeliverySingle
    Public action As String
    Public id_delivery As String
    'Load
    Private Sub FormDeliverySingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If action = "upd" Then
            Dim query As String = String.Format("SELECT * FROM tb_season_delivery WHERE id_delivery = '{0}'", id_delivery)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            SpDelivery.Text = data.Rows(0)("delivery").ToString
            DEDelDate.EditValue = data.Rows(0)("delivery_date")
            Try
                DEWHDate.EditValue = data.Rows(0)("est_wh_date")
            Catch ex As Exception
            End Try
        ElseIf action = "ins" Then
            Dim query As String = "SELECT IF(ISNULL(MAX(delivery)), 1, MAX(delivery)+1) AS current_delivery FROM tb_season_delivery WHERE id_season='" + FormSeason.GVSeason.GetFocusedRowCellDisplayText("id_season").ToString + "'"
            Dim current_delivery As String = execute_query(query, 0, True, "", "", "", "")
            SpDelivery.Text = current_delivery.ToString
        End If
    End Sub
    'Cancel
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Close()
    End Sub
    'Save
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim delivery As String = SpDelivery.Text
        Dim id_season As String = FormSeason.id_season
        Dim delivery_date As String = "0000-00-00"
        Try
            delivery_date = Date.Parse(DEDelDate.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim est_wh_date As String = "0000-00-00"
        Try
            est_wh_date = Date.Parse(DEWHDate.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query As String
        Dim query_count As String
        ValidateChildren()
        'EP_DE_cant_blank(ErrorProvider1, DEDelDate)

        If Not formIsValidInGroup(ErrorProvider1, GCtrlDelivery) Then
            errorInput()
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to save changes this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                'cek sudah adakah delivery untuk season tsb
                query_count = String.Format("SELECT * FROM tb_season_delivery WHERE id_season='{0}' AND delivery='{1}'", id_season, delivery)
                If action = "upd" Then
                    query_count = query_count + String.Format(" AND id_delivery!='{0}'", id_delivery)
                End If
                Dim data_count As DataTable = execute_query(query_count, -1, True, "", "", "", "")
                Dim row_count As Integer = data_count.Rows.Count
                If row_count > 0 Then
                    XtraMessageBox.Show("Delivery season already exist, please check your input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    'manipulasi db
                    If action = "ins" Then
                        'insert process
                        Try
                            If est_wh_date <> "0000-00-00" Then
                                query = String.Format("INSERT INTO tb_season_delivery(delivery, id_season, delivery_date,est_wh_date) VALUES('{0}', '{1}', '{2}','{3}')", delivery, id_season, delivery_date, est_wh_date)
                            Else
                                query = String.Format("INSERT INTO tb_season_delivery(delivery, id_season, delivery_date,est_wh_date) VALUES('{0}', '{1}', '{2}',NULL)", delivery, id_season, delivery_date)
                            End If

                            execute_non_query(query, True, "", "", "", "")
                            logData("tb_season_delivery", 1)
                            FormSeason.viewDelivery(id_season)
                            Dispose()
                        Catch ex As Exception
                            errorConnection()
                        End Try
                    ElseIf action = "upd" Then
                        'update process
                        Try
                            If est_wh_date <> "0000-00-00" Then
                                query = String.Format("UPDATE tb_season_delivery SET delivery='{0}', delivery_date='{2}', est_wh_date='" + est_wh_date + "' WHERE id_delivery='{1}'", delivery, id_delivery, delivery_date)
                            Else
                                query = String.Format("UPDATE tb_season_delivery SET delivery='{0}', delivery_date='{2}', est_wh_date=NULL WHERE id_delivery='{1}'", delivery, id_delivery, delivery_date)
                            End If
                            execute_non_query(query, True, "", "", "", "")
                            logData("tb_season_delivery", 2)
                            FormSeason.viewDelivery(id_season)
                            Dispose()
                        Catch ex As Exception
                            errorConnection()
                        End Try
                    End If
                End If
            End If
        End If
    End Sub
    'Form Closed
    Private Sub FormDeliverySingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub DateEdit1_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DEDelDate.Validating
        EP_DE_cant_blank(ErrorProvider1, DEDelDate)
    End Sub

End Class