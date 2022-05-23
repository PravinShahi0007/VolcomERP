Public Class FormFGLineListMoveSeason
    Public id_pop_up As String = "-1"

    Private Sub FormFGLineListMoveSeason_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSeason()
        viewPlanOrder()
        SLESeasonFrom.EditValue = FormFGLineList.SLESeason.EditValue.ToString
        SLESeason.EditValue = FormFGLineList.SLESeason.EditValue.ToString
    End Sub

    Sub viewPlanOrder()
        Dim query As String = "SELECT * FROM tb_lookup_status_order WHERE id_lookup_status_order=2 ORDER BY id_lookup_status_order ASC"
        viewLookupQuery(LEPlanStatus, query, 0, "lookup_status_order", "id_lookup_status_order")
    End Sub

    Sub viewSeason()
        Dim query As String = "SELECT * FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        query += "WHERE b.id_range >0 "
        If id_pop_up = "3" Then 'non merch
            query += "AND b.is_md='2' AND b.id_departement='" + id_departement_user + "' "
        Else
            query += "AND b.is_md='1' "
        End If
        query += "ORDER BY b.range DESC"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
        viewSearchLookupQuery(SLESeasonFrom, query, "id_season", "season", "id_season")
    End Sub

    Private Sub LEPlanStatus_EditValueChanged(sender As Object, e As EventArgs) Handles LEPlanStatus.EditValueChanged
        Dim stt As String = "-1"
        Try
            stt = LEPlanStatus.EditValue.ToString
        Catch ex As Exception
        End Try
        If stt = "1" Then
            LabelSeason.Enabled = False
            SLESeason.Enabled = False
            LabelSeasonFrom.Enabled = False
            SLESeasonFrom.Enabled = False
            SLESeason.EditValue = FormFGLineList.SLESeason.EditValue.ToString
        ElseIf stt = "2" Then
            LabelSeason.Enabled = False
            SLESeason.Enabled = False
            LabelSeasonFrom.Enabled = False
            SLESeasonFrom.Enabled = False
        Else
            LabelSeason.Enabled = True
            SLESeason.Enabled = True
            LabelSeasonFrom.Enabled = False
            SLESeasonFrom.Enabled = False
        End If
    End Sub

    Private Sub BtnUpdateRec_Click(sender As Object, e As EventArgs) Handles BtnUpdateRec.Click
        If MEReason.Text = "" Then
            warningCustom("Please input reason")
            Exit Sub
        End If

        'cek jika drop
        If LEPlanStatus.EditValue.ToString = "2" Then
            Dim dsg_cek As String = ""
            Dim dsg_in As String = ""

            For l As Integer = 0 To ((FormFGLineList.BGVLineList.RowCount - 1) - GetGroupRowCount(FormFGLineList.BGVLineList))
                If l > 0 Then
                    dsg_cek += "OR "
                    dsg_in += ","
                End If
                dsg_cek += "pdd.id_design = '" + FormFGLineList.BGVLineList.GetRowCellValue(l, "id_design").ToString + "' "
                dsg_in += FormFGLineList.BGVLineList.GetRowCellValue(l, "id_design").ToString
            Next


            'cek design yg ada di PD
            Dim qd As String = "SELECT pd.prod_demand_number, d.design_code AS `code`, d.design_display_name AS `name` 
            FROM tb_prod_demand_design pdd
            INNER JOIN tb_m_design d ON d.id_design = pdd.id_design
            INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pdd.id_prod_demand
            WHERE pd.is_pd=1 AND pd.id_report_status!=5 AND pdd.is_void=2
            AND (" + dsg_cek + ")
            ORDER BY pd.id_prod_demand ASC "
            Dim dd As DataTable = execute_query(qd, -1, True, "", "", "", "")
            If dd.Rows.Count > 0 Then
                warningCustom("Some designs already have PD, please 'drop' via PD 'Revision'. Click OK to see design detail.")
                FormFGLineListPDExist.dt = dd
                FormFGLineListPDExist.PanelControl1.Visible = False
                FormFGLineListPDExist.ShowDialog()
                Cursor = Cursors.Default
                Exit Sub
            End If

            'cek design yg ud propose sni
            Dim qcek As String = "SELECT  d.design_code AS `code`, d.design_display_name AS `name` 
            FROM tb_sni_pps_list sl
            INNER JOIN tb_sni_pps s ON s.id_sni_pps = sl.id_sni_pps
            INNER JOIN tb_m_design d ON d.id_design = sl.id_design
            WHERE s.id_report_status!=5 AND sl.id_design IN (" + dsg_in + ") "
            Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
            If dcek.Rows.Count > 0 Then
                warningCustom("Some designs already propose for SNI. Click OK to see design detail.")
                FormFGLineListPDExist.GVData.Columns("prod_demand_number").Visible = False
                FormFGLineListPDExist.LabelControl1.Text = "Already propose for SNI"
                FormFGLineListPDExist.dt = dcek
                FormFGLineListPDExist.PanelControl1.Visible = False
                FormFGLineListPDExist.ShowDialog()
                Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        If LEPlanStatus.EditValue.ToString = "3" And (SLESeason.EditValue.ToString = SLESeasonFrom.EditValue.ToString) Then
            errorCustom("Season must different")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to change line list status for these data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim id_lookup_status_order As String = LEPlanStatus.EditValue.ToString
                Dim id_season_to As String = SLESeason.EditValue.ToString
                Dim reason As String = addSlashes(MEReason.Text)
                For i As Integer = 0 To ((FormFGLineList.BGVLineList.RowCount - 1) - GetGroupRowCount(FormFGLineList.BGVLineList))
                    Dim id_design As String = FormFGLineList.BGVLineList.GetRowCellValue(i, "id_design").ToString
                    Dim in_store_date_old As String = DateTime.Parse(FormFGLineList.BGVLineList.GetRowCellValue(i, "IN STORE DATE").ToString).ToString("dd MMMM yyyy")
                    Dim id_season_from As String = SLESeasonFrom.EditValue.ToString

                    'update line list status
                    Dim id_delivery As String = ""
                    Dim query_upd As String = "UPDATE tb_m_design SET id_lookup_status_order='" + id_lookup_status_order + "' "
                    If id_lookup_status_order = "2" Then 'drop
                        query_upd += ", id_active=2 "
                    ElseIf id_lookup_status_order = "3" Then 'move
                        Dim query_get_del As String = "SELECT id_delivery FROM tb_season_delivery WHERE id_season='" + id_season_to + "' LIMIT 1 "
                        id_delivery = execute_query(query_get_del, 0, True, "", "", "", "")
                        query_upd += ",id_season='" + id_season_to + "', id_delivery='" + id_delivery + "', id_delivery_act='" + id_delivery + "', id_season_move=IF(ISNULL(id_season_move),'" + id_season_from + "',id_season_move) "
                    Else
                        query_upd += ", id_season='" + id_season_to + "', id_season_move=NULL "
                    End If
                    query_upd += "WHERE id_design='" + id_design + "' "
                    execute_non_query(query_upd, True, "", "", "", "")


                    'update time
                    Dim upd As New ClassDesign
                    upd.updatedTime(id_design)

                    'log line list
                    Dim now_date As String = DateTime.Parse(getTimeDB.ToString).ToString("yyyy-MM-dd")
                    upd.insertLogLineList("394", id_design, False, id_user, id_user, "-", now_date, id_design, reason)

                    'store display
                    Try
                        If id_lookup_status_order = "2" Then 'drop
                            Dim qsd As String = "-- update non active
                            UPDATE tb_display_stock SET is_active=2 WHERE id_design='" + id_design + "'; 
                            -- ins changes log
                            INSERT INTO tb_display_stock_changes_log(id_design, id_report, report_mark_type, report_number, report_date, log_date, log_note, id_user)
                            SELECT ds.id_design, 0, 394, '-', DATE(NOW()), NOW(), 'Drop article : set display as non active','" + id_user + "' 
                            FROM tb_display_stock ds 
                            WHERE ds.id_design=" + id_design + "
                            GROUP BY ds.id_design; "
                            execute_non_query_long(qsd, True, "", "", "", "")
                        ElseIf id_lookup_status_order = "3" Then 'move
                            Dim ddel As DataTable = execute_query("SELECT sd.delivery_date FROM tb_season_delivery sd WHERE sd.id_delivery="+id_delivery+" ",-1, True,"", "", "", "")
                            Dim in_store_date As String = DateTime.Parse(ddel.Rows(0)("delivery_date").ToString).ToString("yyyy-MM-dd")
                            Dim in_store_date_view As String = DateTime.Parse(ddel.Rows(0)("delivery_date").ToString).ToString("dd MMMM yyyy")
                            Dim qsd As String = "-- update display stock
                            UPDATE tb_display_stock SET id_season='" + id_season_to + "', id_delivery='" + id_delivery + "',in_store_date='" + in_store_date + "' WHERE id_design='" + id_design + "'; 
                            -- ins change log
                            INSERT INTO tb_display_stock_changes_log(id_design, id_report, report_mark_type, report_number, report_date, log_date, log_note, id_user)
                            SELECT ds.id_design, 0, 394, '-', DATE(NOW()), NOW(), 'Move season :" + SLESeasonFrom.Text + " -> " + SLESeason.Text + "; change in store date : " + in_store_date_old + "->" + in_store_date_view + ";','" + id_user + "' 
                            FROM tb_display_stock ds 
                            WHERE ds.id_design=" + id_design + "
                            GROUP BY ds.id_design; "
                            execute_non_query_long(qsd, True, "", "", "", "")
                        End If
                    Catch ex As Exception
                        'jika gagal
                        stopCustom("Failed update status store display : " + ex.ToString)
                    End Try


                    PBC.PerformStep()
                    PBC.Update()
                Next
                FormFGLineList.viewLineList()
                Close()
                Cursor = Cursors.Default
            End If
        End If

    End Sub

    Private Sub FormFGLineListMoveSeason_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class