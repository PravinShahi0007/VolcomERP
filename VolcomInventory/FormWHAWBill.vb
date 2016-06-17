Public Class FormWHAWBill
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormWHAWBill_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_but()
    End Sub

    Private Sub FormWHAWBill_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
    Sub check_but()
        If XTCAwb.SelectedTabPageIndex = 0 Then
            If GVAWBill.RowCount > 0 Then
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
            Else
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            End If
        ElseIf XTCAwb.SelectedTabPageIndex = 1 Then
            If GVAwbillIn.RowCount > 0 Then
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
            Else
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            End If
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Sub load_outbound()
        Dim number_start, number_end, date_start, date_end As String

        If TENoStart.EditValue = 0 Or TENoStart.EditValue = Nothing Then
            number_start = ""
        Else
            number_start = " AND awb.id_awbill>='" + TENoStart.EditValue.ToString + "'"
        End If

        If TENoEnd.EditValue = 0 Or TENoEnd.EditValue = Nothing Then
            number_end = ""
        Else
            number_end = " AND awb.id_awbill<='" + TENoEnd.EditValue.ToString + "'"
        End If

        If DEStart.EditValue = Nothing Then
            date_start = ""
        Else
            Dim date_temp As Date = DEStart.EditValue
            date_start = " AND DATE(awb.awbill_date)>='" & date_temp.ToString("yyyy-MM-dd") & "'"
        End If

        If DEEnd.EditValue = Nothing Then
            date_end = ""
        Else
            Dim date_temp As Date = DEEnd.EditValue
            date_end = " AND DATE(awb.awbill_date)<='" & date_temp.ToString("yyyy-MM-dd") & "'"
        End If

        Dim query As String = ""

        If CECompare.Checked = True Then
            Cursor = Cursors.WaitCursor

            gridBandCalcDetail.Visible = True

            If CEDO.Checked = True Then
                query = "CALL view_wh_awbill_do(1,""" + number_start + " " + number_end + " " + date_start + " " + date_end + """)"
                gridBandDO.Visible = True
            Else
                query = "CALL view_wh_awbill(1,""" + number_start + " " + number_end + " " + date_start + " " + date_end + """)"
                gridBandDO.Visible = False
            End If
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

            For i As Integer = GVAWBill.Columns.Count - 1 To 0 Step -1
                If GVAWBill.Columns(i).FieldName.ToString.Contains("#") Then
                    GVAWBill.Columns.RemoveAt(i)
                End If
            Next

            GVAWBill.BeginUpdate()

            For i As Integer = 0 To data.Columns.Count - 1
                If data.Columns(i).ColumnName.ToString.Contains("cargo_rate#") Then
                    Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("#"c)
                    GBCalcRate.Columns.Add(GVAWBill.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(2).ToString))

                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"
                ElseIf data.Columns(i).ColumnName.ToString.Contains("cargo_lead_time#") Then
                    Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("#"c)
                    GBCalcLeadTime.Columns.Add(GVAWBill.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(2).ToString))

                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"
                ElseIf data.Columns(i).ColumnName.ToString.Contains("cargo_min_weight#") Then
                    Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("#"c)
                    GBCalcMinWeight.Columns.Add(GVAWBill.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(2).ToString))

                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"
                ElseIf data.Columns(i).ColumnName.ToString.Contains("cargo_charge_weight#") Then
                    Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("#"c)
                    GBCalcCWeight.Columns.Add(GVAWBill.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(2).ToString))

                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"
                ElseIf data.Columns(i).ColumnName.ToString.Contains("cargo_amount#") Then
                    Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("#"c)
                    GBCalcAmount.Columns.Add(GVAWBill.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(2).ToString))

                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GVAWBill.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"
                End If
            Next

            GVAWBill.EndUpdate()

            GCAWBill.DataSource = data
            GVAWBill.BestFitColumns()

            Cursor = Cursors.Default
        Else
            If CEDO.Checked = True Then 'view do
                gridBandDO.Visible = True
                query = "SELECT IF(is_paid_by_store='2','no','yes') as is_cod,do.do_no,do.qty,do.reff, do.scan_date, grp.comp_group,comp_store.comp_number as account,comp_store.comp_name as account_name,comp_cargo.comp_name as cargo,comp_store.awb_cargo_code AS awb_cargo_code,comp_store.awb_zone AS awb_zone,comp_store.awb_destination AS awb_destination,awb.*, ((awb.height*awb.length*awb.width)/6000) as volume,"
                query += " DATE_ADD(awb.pick_up_date, INTERVAL awb.cargo_lead_time DAY) AS eta_date,"
                query += " DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) AS del_time,"
                query += " (DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time) AS lead_time_diff,"
                query += " (IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time=0, 'ON TIME', IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time>0, 'LATE', IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time<0, 'EARLY', 'ON DELIVERY')))) AS time_remark,"
                query += " (awb.c_weight-awb.a_weight) as weight_diff,(awb.c_tot_price-awb.a_tot_price) as amount_diff"
                query += " FROM tb_wh_awbill awb"
                query += " inner join tb_m_comp comp_store On comp_store.id_comp=awb.id_store"
                query += " inner join tb_m_comp comp_cargo On comp_cargo.id_comp=awb.id_cargo"
                query += " left join tb_m_comp_group grp ON grp.id_comp_group = comp_store.id_comp_group"
                query += " inner join tb_wh_awbill_det awbd ON awbd.id_awbill=awb.id_awbill"
                query += " inner join tb_wh_awb_do do ON do.do_no=awbd.do_no"
                query += " WHERE awb.awbill_type='1' " + number_start + " " + number_end + " " + date_start + " " + date_end + ""
                query += " ORDER BY awb.id_awbill,do.do_no ASC"
            Else
                gridBandDO.Visible = False
                query = "SELECT IF(is_paid_by_store='2','no','yes') as is_cod,grp.comp_group, comp_store.comp_number as account,comp_store.comp_name as account_name,comp_cargo.comp_name as cargo,comp_store.awb_cargo_code AS awb_cargo_code,comp_store.awb_zone AS awb_zone,comp_store.awb_destination AS awb_destination,awb.*, ((awb.height*awb.length*awb.width)/6000) as volume,"
                query += " DATE_ADD(awb.pick_up_date, INTERVAL awb.cargo_lead_time DAY) AS eta_date,"
                query += " DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) AS del_time,"
                query += " (DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time) AS lead_time_diff,"
                query += " (IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time=0, 'ON TIME', IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time>0, 'LATE', IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time<0, 'EARLY', 'ON DELIVERY')))) AS time_remark,"
                query += " (awb.c_weight-awb.a_weight) as weight_diff,(awb.c_tot_price-awb.a_tot_price) as amount_diff"
                query += " FROM tb_wh_awbill awb"
                query += " inner join tb_m_comp comp_store On comp_store.id_comp=awb.id_store"
                query += " inner join tb_m_comp comp_cargo On comp_cargo.id_comp=awb.id_cargo"
                query += " left join tb_m_comp_group grp ON grp.id_comp_group = comp_store.id_comp_group"
                query += " WHERE awb.awbill_type='1' " + number_start + " " + number_end + " " + date_start + " " + date_end + ""
            End If

            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            GCAWBill.DataSource = data

            gridBandCalcDetail.Visible = False

            GVAWBill.BestFitColumns()
        End If
        check_but()
    End Sub
    Sub load_inbound()
        Dim number_start, number_end, date_start, date_end As String

        If TEInNoStart.EditValue = 0 Or TEInNoStart.EditValue = Nothing Then
            number_start = ""
        Else
            number_start = " AND awb.id_awbill>='" + TEInNoStart.EditValue.ToString + "'"
        End If

        If TEInNoEnd.EditValue = 0 Or TEInNoEnd.EditValue = Nothing Then
            number_end = ""
        Else
            number_end = " AND awb.id_awbill<='" + TEInNoEnd.EditValue.ToString + "'"
        End If

        If DEInStart.EditValue = Nothing Then
            date_start = ""
        Else
            Dim date_temp As Date = DEInStart.EditValue
            date_start = " AND DATE(awb.awbill_date)>='" & date_temp.ToString("yyyy-MM-dd") & "'"
        End If

        If DEInEnd.EditValue = Nothing Then
            date_end = ""
        Else
            Dim date_temp As Date = DEInEnd.EditValue
            date_end = " AND DATE(awb.awbill_date)<='" & date_temp.ToString("yyyy-MM-dd") & "'"
        End If

        Dim query As String = ""

        If CEInCompare.Checked = True Then
            Cursor = Cursors.WaitCursor

            GBInCalcDet.Visible = True

            If CERO.Checked = True Then
                query = "CALL view_wh_awbill_do(2,""" + number_start + " " + number_end + " " + date_start + " " + date_end + """)"
                gridBandDO.Visible = True
            Else
                query = "CALL view_wh_awbill(2,""" + number_start + " " + number_end + " " + date_start + " " + date_end + """)"
                gridBandDO.Visible = False
            End If

            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

            For i As Integer = GVAwbillIn.Columns.Count - 1 To 0 Step -1
                If GVAwbillIn.Columns(i).FieldName.ToString.Contains("#") Then
                    GVAwbillIn.Columns.RemoveAt(i)
                End If
            Next

            GVAwbillIn.BeginUpdate()

            For i As Integer = 0 To data.Columns.Count - 1
                If data.Columns(i).ColumnName.ToString.Contains("cargo_rate#") Then
                    Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("#"c)
                    GCInCalcRate.Columns.Add(GVAwbillIn.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(2).ToString))

                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"
                ElseIf data.Columns(i).ColumnName.ToString.Contains("cargo_lead_time#") Then
                    Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("#"c)
                    GBInCalcLeadTime.Columns.Add(GVAwbillIn.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(2).ToString))

                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"
                ElseIf data.Columns(i).ColumnName.ToString.Contains("cargo_min_weight#") Then
                    Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("#"c)
                    GCInCalcMinWeight.Columns.Add(GVAwbillIn.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(2).ToString))

                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"
                ElseIf data.Columns(i).ColumnName.ToString.Contains("cargo_charge_weight#") Then
                    Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("#"c)
                    GCInCalcCWeight.Columns.Add(GVAwbillIn.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(2).ToString))

                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"
                ElseIf data.Columns(i).ColumnName.ToString.Contains("cargo_amount#") Then
                    Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("#"c)
                    GBInCalcAmount.Columns.Add(GVAwbillIn.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(2).ToString))

                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GVAwbillIn.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"
                End If
            Next

            GVAwbillIn.EndUpdate()

            GCAwbillIn.DataSource = data
            GVAwbillIn.BestFitColumns()

            Cursor = Cursors.Default
        Else
            If CERO.Checked = True Then 'view do
                gridBandRO.Visible = True
                query = "SELECT IF(is_paid_by_store='2','no','yes') as is_cod,awbd.do_no,awbd.qty, grp.comp_group,comp_store.comp_number as account,comp_store.comp_name as account_name,comp_cargo.comp_name as cargo,comp_store.awb_cargo_code AS awb_cargo_code,comp_store.awb_zone AS awb_zone,comp_store.awb_destination AS awb_destination,awb.*, ((awb.height*awb.length*awb.width)/6000) as volume,"
                query += " DATE_ADD(awb.pick_up_date, INTERVAL awb.cargo_lead_time DAY) AS eta_date,"
                query += " DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) AS del_time,"
                query += " (DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time) AS lead_time_diff,"
                query += " (IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time=0, 'ON TIME', IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time>0, 'LATE', IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time<0, 'EARLY', 'ON DELIVERY')))) AS time_remark,"
                query += " (awb.c_weight-awb.a_weight) as weight_diff,(awb.c_tot_price-awb.a_tot_price) as amount_diff"
                query += " FROM tb_wh_awbill awb"
                query += " inner join tb_m_comp comp_store On comp_store.id_comp=awb.id_store"
                query += " inner join tb_m_comp comp_cargo On comp_cargo.id_comp=awb.id_cargo"
                query += " left join tb_m_comp_group grp ON grp.id_comp_group = comp_store.id_comp_group"
                query += " inner join tb_wh_awbill_det_in awbd ON awbd.id_awbill=awb.id_awbill"
                query += " WHERE awb.awbill_type='2' " + number_start + " " + number_end + " " + date_start + " " + date_end + ""
                query += " ORDER BY awb.id_awbill,awbd.do_no ASC"
            Else
                gridBandRO.Visible = False
                query = "SELECT grp.comp_group, comp_store.comp_number as account,comp_store.comp_name as account_name,comp_cargo.comp_name as cargo,comp_store.awb_cargo_code AS awb_cargo_code,comp_store.awb_zone AS awb_zone,comp_store.awb_destination AS awb_destination,awb.*, ((awb.height*awb.length*awb.width)/6000) as volume,"
                query += " DATE_ADD(awb.pick_up_date, INTERVAL awb.cargo_lead_time DAY) AS eta_date,"
                query += " DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) AS del_time,"
                query += " (DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time) AS lead_time_diff,"
                query += " (IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time=0, 'ON TIME', IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time>0, 'LATE', IF(DATEDIFF(awb.rec_by_store_date, awb.pick_up_date) - awb.cargo_lead_time<0, 'EARLY', 'ON DELIVERY')))) AS time_remark,"
                query += " (awb.c_weight-awb.a_weight) as weight_diff,(awb.c_tot_price-awb.a_tot_price) as amount_diff FROM tb_wh_awbill awb"
                query += " inner join tb_m_comp comp_store On comp_store.id_comp=awb.id_store"
                query += " inner join tb_m_comp comp_cargo On comp_cargo.id_comp=awb.id_cargo"
                query += " left join tb_m_comp_group grp ON grp.id_comp_group = comp_store.id_comp_group"
                query += " WHERE awb.awbill_type='2' " + number_start + " " + number_end + " " + date_start + " " + date_end + ""
            End If

            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            GCAwbillIn.DataSource = data

            GBInCalcDet.Visible = False

            GVAwbillIn.BestFitColumns()
        End If
        check_but()
    End Sub
    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_outbound()
    End Sub

    Private Sub BInView_Click(sender As Object, e As EventArgs) Handles BInView.Click
        load_inbound()
    End Sub

    Private Sub XTCAwb_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCAwb.SelectedPageChanged
        check_but()
    End Sub

    Private Sub GVAWBill_CellMerge(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs) Handles GVAWBill.CellMerge
        If (e.Column.FieldName = "id_awbill" Or e.Column.FieldName = "weight" Or e.Column.FieldName = "length" Or e.Column.FieldName = "width" Or e.Column.FieldName = "height" Or e.Column.FieldName = "volume" Or e.Column.FieldName = "c_weight" Or e.Column.FieldName = "c_tot_price" Or e.Column.FieldName = "a_weight" Or e.Column.FieldName = "a_tot_price" Or e.Column.FieldName = "weight_diff" Or e.Column.FieldName = "amount_diff") Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim val1 As String = view.GetRowCellValue(e.RowHandle1, "id_awbill")
            Dim val2 As String = view.GetRowCellValue(e.RowHandle2, "id_awbill")
            e.Merge = (val1.ToString = val2.ToString)
            e.Handled = True
        Else
            e.Merge = False
            e.Handled = True
        End If
    End Sub
End Class