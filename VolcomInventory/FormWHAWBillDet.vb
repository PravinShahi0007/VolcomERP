Public Class FormWHAWBillDet
    Public id_awb As String = "-1"
    Public id_comp As String = ""

    Public id_awb_type As String = "-1"
    Public opt As String = ""
    Public is_view As String = "-1"

    Private Sub FormWHAWBillDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_sub_dsitrict()
        load_awb()
    End Sub

    Sub load_sub_dsitrict()
        Dim q As String = "SELECT dis.id_sub_district,dis.`sub_district`,ct.city,ct.`island`,reg.`region`,st.`state`,c.`country`
FROM tb_m_sub_district dis
INNER JOIN tb_m_city ct ON dis.id_city=ct.id_city
INNER JOIN tb_m_state st ON st.`id_state`=ct.`id_state`
INNER JOIN tb_m_region reg ON reg.`id_region`=st.`id_region`
INNER JOIN tb_m_country c ON c.`id_country`=reg.`id_country`"
        viewSearchLookupQuery(SLESubDistrict, q, "id_sub_district", "sub_district", "id_sub_district")
    End Sub

    Sub load_sub_dsitrict_filter(ByVal filter As String)
        Dim q As String = "SELECT dis.id_sub_district,dis.`sub_district`,ct.city,ct.`island`,reg.`region`,st.`state`,c.`country`
FROM tb_m_sub_district dis
INNER JOIN tb_m_city ct ON dis.id_city=ct.id_city
INNER JOIN tb_m_state st ON st.`id_state`=ct.`id_state`
INNER JOIN tb_m_region reg ON reg.`id_region`=st.`id_region`
INNER JOIN tb_m_country c ON c.`id_country`=reg.`id_country` " & filter
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then
            viewSearchLookupQuery(SLESubDistrict, q, "id_sub_district", "sub_district", "id_sub_district")
        Else
            warningCustom("Shipping district not found, please choose shipping district correctly !")
            load_sub_dsitrict()
        End If
    End Sub

    Sub load_awb()
        TELength.EditValue = 0.00
        TEWidth.EditValue = 0.00
        TEHeight.EditValue = 0.00
        TEVolume.EditValue = 0.00
        TEWeight.EditValue = 0.00

        TEBeratTerpakai.EditValue = 0
        TEVolumeVolc.EditValue = 0

        'TEVolumeAirport.EditValue = 0
        TEVolumeDiff.EditValue = 0

        TEPriceAirport.EditValue = 0
        TEPriceDiff.EditValue = 0

        DECreated.EditValue = Now
        DEPickUp.EditValue = Now

        If Not id_awb = "-1" Then 'edit
            Dim query As String = "SELECT awb.*,IF(awb.awbill_type=1,'Outbound','Inbound') AS oi,comp_s.comp_name,comp_s.comp_number FROM tb_wh_awbill awb"
            query += " INNER JOIN tb_m_comp comp_s ON comp_s.id_comp=awb.id_store WHERE awb.id_awbill='" + id_awb + "'"

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            id_awb_type = data.Rows(0)("awbill_type").ToString
            TEAwbType.Text = data.Rows(0)("oi").ToString
            TENo.Text = data.Rows(0)("id_awbill").ToString

            DECreated.EditValue = data.Rows(0)("awbill_date")

            id_comp = data.Rows(0)("id_store").ToString
            TECompCode.Text = data.Rows(0)("comp_number").ToString
            TECompName.Text = data.Rows(0)("comp_name").ToString

            TELength.EditValue = data.Rows(0)("length")
            TEWidth.EditValue = data.Rows(0)("width")
            TEHeight.EditValue = data.Rows(0)("height")

            TEWeight.EditValue = data.Rows(0)("weight")

            TEBeratTerpakai.EditValue = data.Rows(0)("weight_calc").ToString

            TEMarkDifferent.Text = data.Rows(0)("mark_different").ToString

            rate_table()

            'If data.Rows(0)("id_track_no").ToString = "0" Then
            '    TEAwbNo.Enabled = True
            'Else
            '    TEAwbNo.Enabled = False
            'End If

            TEAwbNo.Enabled = False

            SLESubDistrict.EditValue = data.Rows(0)("id_sub_district").ToString
            SLECargo.EditValue = data.Rows(0)("id_cargo").ToString
            TEChargeRate.EditValue = data.Rows(0)("cargo_rate")
            TECargoLeadTime.EditValue = data.Rows(0)("cargo_lead_time")
            TECargoMinWeight.EditValue = data.Rows(0)("cargo_min_weight")
            TEVolumeVolc.EditValue = data.Rows(0)("c_weight")
            If data.Rows(0)("a_weight") = 0 Then
                TEVolumeAirport.EditValue = Nothing
            Else
                TEVolumeAirport.EditValue = data.Rows(0)("a_weight")
            End If

            '
            TEAwbNo.Text = data.Rows(0)("awbill_no").ToString
            TEInvNo.Text = data.Rows(0)("awbill_inv_no").ToString
            TERecByPerson.Text = data.Rows(0)("rec_by_store_person")

            If data.Rows(0)("pick_up_date").ToString = "" Then
                DEPickUp.EditValue = Nothing
            Else
                DEPickUp.EditValue = data.Rows(0)("pick_up_date")
            End If

            If data.Rows(0)("rec_by_store_date").ToString = "" Then
                DEStore.EditValue = Nothing
            Else
                DEStore.EditValue = data.Rows(0)("rec_by_store_date")
            End If

            If data.Rows(0)("is_paid_by_store").ToString = "1" Then
                CEPaid.Checked = True
            Else
                CEPaid.Checked = False
            End If

            MENote.Text = data.Rows(0)("awbill_note").ToString

            BMark.Visible = True

            If data.Rows(0)("is_lock").ToString = "1" Then
                BSave.Visible = False
            End If

            If isCreatedManifest() Then
                TECompCode.Properties.ReadOnly = True
                BBrowse.Enabled = False
                BRemoveDO.Enabled = False
            End If
        Else
            TEAwbNo.Enabled = False
        End If

        If id_awb_type = "1" Then
            TEAwbType.Text = "Outbound"
            CEPaid.Visible = True
            SLECargo.Width = 100
        ElseIf id_awb_type = "2" Then
            TEAwbType.Text = "Inbound"
            CEPaid.Visible = False
            SLECargo.Width = 200
        End If

        calculate_amount()
        view_do()
        If Not id_awb = "-1" Then
            XTCDetail.SelectedTabPageIndex = 1
            TEAwbNo.Focus()
        Else
            TECompCode.Focus()
        End If
        '
        If is_view = "1" Then
            BSave.Visible = False
        End If
        '
        If id_awb = "-1" Then
            If opt = "From DO" Then
                id_comp = FormWHAWBill.GVDOERP.GetRowCellValue(0, "id_comp").ToString
                SLESubDistrict.EditValue = FormWHAWBill.GVDOERP.GetRowCellValue(0, "id_sub_district").ToString
                TECompName.Text = FormWHAWBill.GVDOERP.GetRowCellValue(0, "store_name").ToString
                TECompCode.Text = FormWHAWBill.GVDOERP.GetRowCellValue(0, "store_number").ToString
                '
                If FormWHAWBill.GVDOERP.GetRowCellValue(0, "id_commerce_type").ToString = "2" Then
                    SLESubDistrict.Enabled = True
                Else
                    SLESubDistrict.Enabled = False
                End If
                '
                clear_do()
                rate_table()

                'masukkan DO
                For i As Integer = 0 To FormWHAWBill.GVDOERP.RowCount - 1
                    Dim newRow As DataRow = (TryCast(GCDO.DataSource, DataTable)).NewRow()
                    newRow("id_pl_sales_order_del") = FormWHAWBill.GVDOERP.GetRowCellValue(i, "id_pl_sales_order_del").ToString
                    newRow("do_no") = FormWHAWBill.GVDOERP.GetRowCellValue(i, "do_no").ToString
                    newRow("qty") = FormWHAWBill.GVDOERP.GetRowCellValue(i, "qty")

                    TryCast(GCDO.DataSource, DataTable).Rows.Add(newRow)
                    GCDO.RefreshDataSource()
                Next
                '
            ElseIf opt = "From DO AWB" Then
                id_comp = FormWHAWBillReff.GVDOERP.GetRowCellValue(0, "id_comp").ToString
                TECompName.Text = FormWHAWBillReff.GVDOERP.GetRowCellValue(0, "store_name").ToString
                TECompCode.Text = FormWHAWBillReff.GVDOERP.GetRowCellValue(0, "store_number").ToString
                '
                load_sub_dsitrict_filter(" WHERE ct.city='" & FormWHAWBillReff.GVDOERP.GetRowCellValue(0, "shipping_city").ToString & "' ")
                '
                If FormWHAWBillReff.GVDOERP.GetRowCellValue(0, "id_commerce_type").ToString = "2" Then
                    SLESubDistrict.Enabled = True
                Else
                    SLESubDistrict.Enabled = False
                End If
                '
                clear_do()
                rate_table()

                'masukkan DO
                For i As Integer = 0 To FormWHAWBillReff.GVDOERP.RowCount - 1
                    Dim newRow As DataRow = (TryCast(GCDO.DataSource, DataTable)).NewRow()
                    newRow("id_pl_sales_order_del") = FormWHAWBillReff.GVDOERP.GetRowCellValue(i, "id_pl_sales_order_del").ToString
                    newRow("do_no") = FormWHAWBillReff.GVDOERP.GetRowCellValue(i, "do_no").ToString
                    newRow("qty") = FormWHAWBillReff.GVDOERP.GetRowCellValue(i, "qty")

                    TryCast(GCDO.DataSource, DataTable).Rows.Add(newRow)
                    GCDO.RefreshDataSource()
                Next
                '
            ElseIf opt = "From Return Customer" Then
                id_comp = FormWHAWBill.GVRet.GetRowCellValue(0, "id_comp").ToString
                TECompName.Text = FormWHAWBill.GVRet.GetRowCellValue(0, "comp_name").ToString
                TECompCode.Text = FormWHAWBill.GVRet.GetRowCellValue(0, "comp_number").ToString
                '
                load_sub_dsitrict_filter(" WHERE ct.city='" & FormWHAWBill.GVRet.GetRowCellValue(0, "shipping_city").ToString & "' ")
                '
                If FormWHAWBill.GVRet.GetRowCellValue(0, "id_commerce_type").ToString = "2" Then
                    SLESubDistrict.Enabled = True
                Else
                    SLESubDistrict.Enabled = False
                End If
                '
                clear_do()
                rate_table()

                'masukkan DO
                Dim q As String = "SELECT r.id_ol_store_cust_ret,r.number,SUM(sod.sales_order_det_qty) AS qty
FROM tb_ol_store_cust_ret_det rd
INNER JOIN tb_ol_store_cust_ret r ON r.id_ol_store_cust_ret=rd.id_ol_store_cust_ret
INNER JOIN tb_ol_store_ret_list rl ON rl.`id_ol_store_ret_list`=rd.`id_ol_store_ret_list`
INNER JOIN tb_ol_store_ret_det retd ON retd.`id_ol_store_ret_det`=rl.`id_ol_store_ret_det`
INNER JOIN tb_sales_order_det sod ON sod.`id_sales_order_det`=retd.`id_sales_order_det`
INNER JOIN tb_sales_order so ON so.`id_sales_order`=sod.`id_sales_order`
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=so.`id_store_contact_to`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp` 
INNER JOIN tb_m_comp_group cg ON cg.`id_comp_group`=c.`id_comp_group` 
WHERE CONCAT('RET-',cg.`comp_group`,'-',so.`sales_order_ol_shop_number`)='" & FormWHAWBill.GVRet.GetRowCellValue(0, "stru").ToString & "'
GROUP BY r.id_ol_store_cust_ret"
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")

                For i As Integer = 0 To FormWHAWBill.GVRet.RowCount - 1
                    Dim newRow As DataRow = (TryCast(GCDO.DataSource, DataTable)).NewRow()
                    newRow("id_ol_store_cust_ret") = FormWHAWBill.GVRet.GetRowCellValue(i, "id_ol_store_cust_ret").ToString
                    newRow("do_no") = FormWHAWBill.GVRet.GetRowCellValue(i, "number").ToString
                    newRow("qty") = FormWHAWBill.GVRet.GetRowCellValue(i, "qty")

                    TryCast(GCDO.DataSource, DataTable).Rows.Add(newRow)
                    GCDO.RefreshDataSource()
                Next
                '
            ElseIf opt = "From AWB Reff" Then

            End If
        End If
    End Sub
    Sub view_do()
        Dim query As String = "SELECT * FROM tb_wh_awbill_det WHERE id_awbill='" + id_awb + "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCDO.DataSource = data
    End Sub
    Private Sub BBrowse_Click(sender As Object, e As EventArgs) Handles BBrowse.Click
        'FormPopUpContact.id_pop_up = "awb"
        'FormPopUpContact.id_cat = "6"
        'FormPopUpContact.ShowDialog()
        If id_comp = "-1" Then
            stopCustom("Choose Store first.")
            TECompCode.Focus()
        Else
            FormWHAWBillDetDO.store_number = TECompCode.Text
            FormWHAWBillDetDO.ShowDialog()
        End If
        TEWeight.Focus()
    End Sub
    Sub calculate_vol_volcom(ByVal is_vol As Boolean)
        If is_vol = True Then
            Try
                TEVolume.EditValue = (TELength.EditValue * TEWidth.EditValue * TEHeight.EditValue) / 6000
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If

        If Math.Ceiling(TEVolume.EditValue) > Math.Ceiling(TEWeight.EditValue) Then
            TEBeratTerpakai.EditValue = Math.Ceiling(TEVolume.EditValue)
        Else
            TEBeratTerpakai.EditValue = Math.Ceiling(TEWeight.EditValue)
        End If
    End Sub

    Private Sub TELength_EditValueChanged(sender As Object, e As EventArgs) Handles TELength.EditValueChanged
        calculate_vol_volcom(True)
    End Sub

    Private Sub TEWidth_EditValueChanged(sender As Object, e As EventArgs) Handles TEWidth.EditValueChanged
        calculate_vol_volcom(True)
    End Sub

    Private Sub TEHeight_EditValueChanged(sender As Object, e As EventArgs) Handles TEHeight.EditValueChanged
        calculate_vol_volcom(True)
    End Sub

    Private Sub TEWeight_EditValueChanged(sender As Object, e As EventArgs) Handles TEWeight.EditValueChanged
        calculate_vol_volcom(False)
    End Sub

    Private Sub FormWHAWBillDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            FormWHAWBillReff.Close()
            FormWHAWBill.XTCOutbound.SelectedTabPageIndex = 3
        Catch ex As Exception

        End Try
        Dispose()
    End Sub

    Sub rate_table()
        Dim berat_terpakai As Integer = TEBeratTerpakai.EditValue

        If id_awb = "-1" Then 'new
            'Dim query As String = "SELECT rate.id_cargo,rate.id_store,comp.comp_name AS cargo,rate.cargo_min_weight,rate.cargo_rate"
            'query += ", IF(" + berat_terpakai.ToString + " < Rate.cargo_min_weight, Rate.cargo_min_weight, " + berat_terpakai.ToString + ") As weight"
            'query += " ,(If(" + berat_terpakai.ToString + "<rate.cargo_min_weight,rate.cargo_min_weight," + berat_terpakai.ToString + ") * cargo_rate) As amount"
            'query += " ,rate.cargo_lead_time"
            'query += " ,comp.awb_rank"
            'query += " FROM tb_wh_cargo_rate As rate"
            'query += " INNER JOIN tb_m_comp comp ON comp.id_comp=rate.id_cargo"
            'query += " WHERE rate.id_store='" + id_comp + "' AND rate.id_rate_type='" + id_awb_type + "'"
            'query += " ORDER BY amount ASC,awb_rank ASC"

            Dim query As String = "SELECT rate.id_comp AS id_cargo,comp.comp_name AS cargo,rate.cargo_min_weight,rate.cargo_rate
, IF(" + berat_terpakai.ToString + " < Rate.cargo_min_weight, Rate.cargo_min_weight, " + berat_terpakai.ToString + ") AS weight
,(IF(" + berat_terpakai.ToString + "<rate.cargo_min_weight,rate.cargo_min_weight," + berat_terpakai.ToString + ") * cargo_rate) AS amount
,rate.cargo_lead_time
,comp.awb_rank
FROM `tb_3pl_rate` AS rate
INNER JOIN tb_m_comp comp ON comp.id_comp=rate.id_comp
WHERE rate.id_sub_district='" + SLESubDistrict.EditValue.ToString + "' AND rate.is_active=1 AND rate.id_type='" + id_awb_type + "'
ORDER BY amount ASC,comp.awb_rank ASC"

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCCargoRate.DataSource = data
            GVCargoRate.BestFitColumns()

            SLECargo.EditValue = Nothing
            viewSearchLookupQuery(SLECargo, query, "id_cargo", "cargo", "id_cargo")

            auto_cargo()
        Else 'edit
            'no edit
            Dim query As String = ""

            If FormWHAWBill.is_lock = "1" Then
                query = "SELECT rate.id_comp AS id_cargo,comp.comp_name AS cargo,rate.cargo_min_weight,rate.cargo_rate
, IF(" + berat_terpakai.ToString + " < Rate.cargo_min_weight, Rate.cargo_min_weight, " + berat_terpakai.ToString + ") AS weight
,(IF(" + berat_terpakai.ToString + "<rate.cargo_min_weight,rate.cargo_min_weight," + berat_terpakai.ToString + ") * cargo_rate) AS amount
,rate.cargo_lead_time
,comp.awb_rank
FROM `tb_3pl_rate` AS rate
INNER JOIN tb_m_comp comp ON comp.id_comp=rate.id_comp
WHERE rate.id_sub_district='" + SLESubDistrict.EditValue.ToString + "' AND rate.is_active=1 AND rate.id_type='" + id_awb_type + "'"
                query += " ORDER BY amount ASC,awb_rank ASC"
            Else
                query = "SELECT awb.id_cargo,awb.id_store,comp_c.comp_name AS cargo,awb.cargo_min_weight,awb.cargo_rate
                        ,awb.c_weight AS weight
                        ,awb.`c_tot_price` AS amount
                        ,awb.cargo_lead_time
                        ,comp_c.awb_rank
                        FROM tb_wh_awbill awb
                        INNER JOIN tb_m_comp comp_c ON comp_c.id_comp=awb.id_cargo 
                        WHERE awb.id_awbill='" & id_awb & "'"
            End If

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCCargoRate.DataSource = data
            GVCargoRate.BestFitColumns()

            SLECargo.EditValue = Nothing
            viewSearchLookupQuery(SLECargo, query, "id_cargo", "cargo", "id_cargo")

            auto_cargo()
        End If

        calculate_amount()
    End Sub

    Private Sub BRefresh_Click(sender As Object, e As EventArgs) Handles BRefresh.Click
        Cursor = Cursors.WaitCursor
        rate_table()
        SLECargo.Focus()
        Cursor = Cursors.Default
    End Sub

    Private Sub BAuto_Click(sender As Object, e As EventArgs) Handles BAuto.Click
        auto_cargo()
        calculate_amount()
    End Sub

    Sub auto_cargo()
        If GVCargoRate.RowCount > 0 Then
            SLECargo.EditValue = Nothing
            SLECargo.EditValue = GVCargoRate.GetRowCellValue(0, "id_cargo").ToString

            SLVCargo.FocusedRowHandle = find_row(SLVCargo, "id_cargo", GVCargoRate.GetRowCellValue(0, "id_cargo").ToString)
        End If
    End Sub

    Sub calculate_amount()
        If SLECargo.EditValue = Nothing Then
            TEChargeRate.EditValue = 0
            TEVolumeVolc.EditValue = 0
            TEPriceVolcom.EditValue = 0
            TECargoLeadTime.EditValue = 0
            TECargoMinWeight.EditValue = 0
        Else
            If CEPaid.Checked = True Then
                TEChargeRate.EditValue = 0
                TEPriceVolcom.EditValue = 0
            Else
                TEChargeRate.EditValue = SLECargo.Properties.View.GetFocusedRowCellValue("cargo_rate")
                TEPriceVolcom.EditValue = SLECargo.Properties.View.GetFocusedRowCellValue("amount")
            End If

            TEVolumeVolc.EditValue = SLECargo.Properties.View.GetFocusedRowCellValue("weight")
            TECargoLeadTime.EditValue = SLECargo.Properties.View.GetFocusedRowCellValue("cargo_lead_time")
            TECargoMinWeight.EditValue = SLECargo.Properties.View.GetFocusedRowCellValue("cargo_min_weight")

            If SLECargo.Properties.View.GetFocusedRowCellValue("cargo_rate") = Nothing Then
                If CEPaid.Checked = True Then
                    TEChargeRate.EditValue = 0
                    TEPriceVolcom.EditValue = 0
                Else
                    TEChargeRate.EditValue = GVCargoRate.GetRowCellValue(find_row(GVCargoRate, "id_cargo", SLECargo.EditValue), "cargo_rate").ToString
                    TEPriceVolcom.EditValue = GVCargoRate.GetRowCellValue(find_row(GVCargoRate, "id_cargo", SLECargo.EditValue), "amount").ToString
                End If

                TEVolumeVolc.EditValue = GVCargoRate.GetRowCellValue(find_row(GVCargoRate, "id_cargo", SLECargo.EditValue), "weight").ToString
                TECargoLeadTime.EditValue = GVCargoRate.GetRowCellValue(find_row(GVCargoRate, "id_cargo", SLECargo.EditValue), "cargo_lead_time").ToString
                TECargoMinWeight.EditValue = GVCargoRate.GetRowCellValue(find_row(GVCargoRate, "id_cargo", SLECargo.EditValue), "cargo_min_weight").ToString
            End If
        End If

        TEPriceAirport.EditValue = TEVolumeAirport.EditValue * TEChargeRate.EditValue
        TEVolumeDiff.EditValue = TEVolumeVolc.EditValue - TEVolumeAirport.EditValue
        TEPriceDiff.EditValue = TEChargeRate.EditValue * TEVolumeDiff.EditValue
        '
        Try
            If GVCargoRate.RowCount > 0 And Not SLECargo.EditValue.ToString = "" Then
                If Not GVCargoRate.GetRowCellValue(0, "id_cargo").ToString = SLECargo.EditValue.ToString Then
                    LMarkDifferent.Visible = True
                    TEMarkDifferent.Visible = True
                Else
                    LMarkDifferent.Visible = False
                    TEMarkDifferent.Visible = False
                End If
            End If
        Catch ex As Exception
            LMarkDifferent.Visible = False
            TEMarkDifferent.Visible = False
        End Try
    End Sub
    Private Sub SLECargo_EditValueChanged(sender As Object, e As EventArgs) Handles SLECargo.EditValueChanged
        calculate_amount()
    End Sub

    Private Sub TEVolumeAirport_EditValueChanged(sender As Object, e As EventArgs) Handles TEVolumeAirport.EditValueChanged
        calculate_amount()
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Function isCreatedManifest() As Boolean
        Dim query As String = "SELECT ad.id_awbill FROM tb_del_manifest_det od
        INNER JOIN tb_del_manifest o ON o.id_del_manifest = od.id_del_manifest
        INNER JOIN tb_wh_awbill_det ad ON ad.id_wh_awb_det = od.id_wh_awb_det
        WHERE IFNULL(o.id_report_status,0)!=5 AND ad.id_awbill=" + id_awb + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        Dim query As String = ""

        If id_comp = "-1" Or SLECargo.EditValue = Nothing Then
            stopCustom("Please select your destination and cargo first")
        Else
            Dim date_pickup As String = ""
            Dim date_store As String = ""
            Dim rec_store_by As String = ""
            Dim is_paid_by_store As String = "2"
            Dim vol_airport As String = "0"
            Dim mark_diff As String = ""
            Dim id_sub_district As String = "0"

            Try
                If GVCargoRate.RowCount > 0 And Not SLECargo.EditValue.ToString = "" Then
                    If Not GVCargoRate.GetRowCellValue(0, "id_cargo").ToString = SLECargo.EditValue.ToString Then
                        mark_diff = TEMarkDifferent.Text
                    Else
                        mark_diff = ""
                    End If
                End If
            Catch ex As Exception

            End Try


            If CEPaid.Checked = True Then
                is_paid_by_store = "1"
            Else
                is_paid_by_store = "2"
            End If

            If DEPickUp.Text = "" Then
                date_pickup = "NULL"
            Else
                Dim date_temp As Date = DEPickUp.EditValue
                date_pickup = "'" + date_temp.ToString("yyyy-MM-dd") + "'"
            End If

            If DEStore.Text = "" Then
                date_store = "NULL"
            Else
                Dim date_temp As Date = DEStore.EditValue
                date_store = "'" + date_temp.ToString("yyyy-MM-dd") + "'"
            End If

            If TEVolumeAirport.Text = "" Then
                vol_airport = "0"
            Else
                vol_airport = TEVolumeAirport.EditValue
            End If

            id_sub_district = SLESubDistrict.EditValue.ToString
            rec_store_by = TERecByPerson.Text

            If id_awb = "-1" Then 'new
                'query = "INSERT INTO tb_wh_awbill(is_paid_by_store,id_sub_district,id_track_no,awbill_type,awbill_date,id_store,id_cargo,cargo_rate,cargo_lead_time,cargo_min_weight,weight,`length`,width,height,weight_calc,c_weight,c_tot_price,a_weight,a_tot_price,awbill_no,awbill_inv_no,pick_up_date,rec_by_store_date,rec_by_store_person,awbill_note,id_cargo_best,cargo_rate_best,cargo_lead_time_best,cargo_min_weight_best,mark_different)"
                'query += " VALUES('" + is_paid_by_store + "','" + id_sub_district + "',(SELECT get_track_no('" & SLECargo.EditValue.ToString & "')),'" + id_awb_type + "',NOW(),'" + id_comp + "','" + SLECargo.EditValue.ToString + "','" + decimalSQL(TEChargeRate.EditValue.ToString) + "','" + decimalSQL(TECargoLeadTime.EditValue.ToString) + "','" + decimalSQL(TECargoMinWeight.EditValue.ToString) + "','" + decimalSQL(TEWeight.EditValue.ToString) + "','" + decimalSQL(TELength.EditValue.ToString) + "','" + decimalSQL(TEWidth.EditValue.ToString) + "','" + decimalSQL(TEHeight.EditValue.ToString) + "','" + decimalSQL(TEBeratTerpakai.EditValue.ToString) + "','" + decimalSQL(TEVolumeVolc.EditValue.ToString) + "','" + decimalSQL(TEPriceVolcom.EditValue.ToString) + "','" + decimalSQL(vol_airport.ToString) + "','" + decimalSQL(TEPriceAirport.EditValue.ToString) + "','" + addSlashes(TEAwbNo.Text.ToString) + "','" + addSlashes(TEInvNo.Text.ToString) + "'," + date_pickup + "," + date_store + ",'" + rec_store_by + "','" + addSlashes(MENote.Text) + "','" + GVCargoRate.GetRowCellValue(0, "id_cargo").ToString + "','" + decimalSQL(GVCargoRate.GetRowCellValue(0, "cargo_rate").ToString) + "','" + decimalSQL(GVCargoRate.GetRowCellValue(0, "cargo_lead_time").ToString) + "','" + decimalSQL(GVCargoRate.GetRowCellValue(0, "cargo_min_weight").ToString) + "','" & mark_diff & "'); SELECT LAST_INSERT_ID(); "
                query = "INSERT INTO tb_wh_awbill(is_paid_by_store,id_sub_district,awbill_type,awbill_date,id_store,id_cargo,cargo_rate,cargo_lead_time,cargo_min_weight,weight,`length`,width,height,weight_calc,c_weight,c_tot_price,a_weight,a_tot_price,awbill_no,awbill_inv_no,pick_up_date,rec_by_store_date,rec_by_store_person,awbill_note,id_cargo_best,cargo_rate_best,cargo_lead_time_best,cargo_min_weight_best,mark_different)"
                query += " VALUES('" + is_paid_by_store + "','" + id_sub_district + "','" + id_awb_type + "',NOW(),'" + id_comp + "','" + SLECargo.EditValue.ToString + "','" + decimalSQL(TEChargeRate.EditValue.ToString) + "','" + decimalSQL(TECargoLeadTime.EditValue.ToString) + "','" + decimalSQL(TECargoMinWeight.EditValue.ToString) + "','" + decimalSQL(TEWeight.EditValue.ToString) + "','" + decimalSQL(TELength.EditValue.ToString) + "','" + decimalSQL(TEWidth.EditValue.ToString) + "','" + decimalSQL(TEHeight.EditValue.ToString) + "','" + decimalSQL(TEBeratTerpakai.EditValue.ToString) + "','" + decimalSQL(TEVolumeVolc.EditValue.ToString) + "','" + decimalSQL(TEPriceVolcom.EditValue.ToString) + "','" + decimalSQL(vol_airport.ToString) + "','" + decimalSQL(TEPriceAirport.EditValue.ToString) + "','" + addSlashes(TEAwbNo.Text.ToString) + "','" + addSlashes(TEInvNo.Text.ToString) + "'," + date_pickup + "," + date_store + ",'" + rec_store_by + "','" + addSlashes(MENote.Text) + "','" + GVCargoRate.GetRowCellValue(0, "id_cargo").ToString + "','" + decimalSQL(GVCargoRate.GetRowCellValue(0, "cargo_rate").ToString) + "','" + decimalSQL(GVCargoRate.GetRowCellValue(0, "cargo_lead_time").ToString) + "','" + decimalSQL(GVCargoRate.GetRowCellValue(0, "cargo_min_weight").ToString) + "','" & mark_diff & "'); SELECT LAST_INSERT_ID(); "

                id_awb = execute_query(query, 0, True, "", "", "", "")

                query = "CALL awbill_log('" & id_awb & "','" & id_user & "')"
                execute_non_query(query, True, "", "", "", "")

                execute_non_query("CALL upd_track_no('" & id_awb & "')", True, "", "", "", "")

                GVDO.ApplyFindFilter("")
                GVDO.ActiveFilterString = ""

                'detail do
                If GVDO.RowCount > 0 Then
                    query = "INSERT INTO tb_wh_awbill_det(id_awbill,id_pl_sales_order_del,id_ol_store_cust_ret,do_no,qty) VALUES"
                    For i As Integer = 0 To GVDO.RowCount - 1
                        Dim id_pl_sales_order_del As String = "NULL"
                        Dim id_ol_store_cust_ret As String = "NULL"

                        Try
                            id_pl_sales_order_del = GVDO.GetRowCellValue(i, "id_pl_sales_order_del").ToString
                        Catch ex As Exception
                        End Try

                        Try
                            id_ol_store_cust_ret = GVDO.GetRowCellValue(i, "id_ol_store_cust_ret").ToString
                        Catch ex As Exception
                        End Try

                        If id_pl_sales_order_del = "" Then
                            id_pl_sales_order_del = "NULL"
                        End If
                        If id_ol_store_cust_ret = "" Then
                            id_ol_store_cust_ret = "NULL"
                        End If

                        If Not i = 0 Then
                            query += ","
                        End If
                        query += "('" + id_awb + "'," + id_pl_sales_order_del + "," + id_ol_store_cust_ret + ",'" + GVDO.GetRowCellValue(i, "do_no").ToString + "','" + GVDO.GetRowCellValue(i, "qty").ToString + "')"
                    Next
                    execute_non_query(query, True, "", "", "", "")
                End If

                'infoCustom("AWB calculation saved.")

                If id_awb_type = "1" Then
                    FormWHAWBill.DEStart.EditValue = Now
                    FormWHAWBill.DEEnd.EditValue = Now
                    FormWHAWBill.load_outbound()
                    FormWHAWBill.GVAWBill.FocusedRowHandle = find_row(FormWHAWBill.GVAWBill, "id_awbill", id_awb)
                Else
                    FormWHAWBill.DEStart.EditValue = Now
                    FormWHAWBill.DEEnd.EditValue = Now
                    FormWHAWBill.load_inbound()
                    FormWHAWBill.GVAwbillIn.FocusedRowHandle = find_row(FormWHAWBill.GVAwbillIn, "id_awbill", id_awb)
                End If

                load_awb()
                'Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Calculation saved. Do you want to create again ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                'If confirm = Windows.Forms.DialogResult.Yes Then
                '    again_awb = "1"
                'End If
                If opt = "From DO AWB" Then
                    FormWHAWBill.load_from_do()
                End If
                Close()
            Else 'edit
                query = "UPDATE tb_wh_awbill SET is_paid_by_store='" + is_paid_by_store + "',id_sub_district='" + id_sub_district + "',id_store='" + id_comp + "',id_cargo='" + SLECargo.EditValue.ToString + "',cargo_rate='" + decimalSQL(TEChargeRate.EditValue.ToString) + "',cargo_lead_time='" + decimalSQL(TECargoLeadTime.EditValue.ToString) + "',cargo_min_weight='" + decimalSQL(TECargoMinWeight.EditValue.ToString) + "',weight='" + decimalSQL(TEWeight.EditValue.ToString) + "',`length`='" + decimalSQL(TELength.EditValue.ToString) + "',width='" + decimalSQL(TEWidth.EditValue.ToString) + "',height='" + decimalSQL(TEHeight.EditValue.ToString) + "',weight_calc='" + decimalSQL(TEBeratTerpakai.EditValue.ToString) + "',c_weight='" + decimalSQL(TEVolumeVolc.EditValue.ToString) + "',c_tot_price='" + decimalSQL(TEPriceVolcom.EditValue.ToString) + "',a_weight='" + decimalSQL(vol_airport.ToString) + "',a_tot_price='" + decimalSQL(TEPriceAirport.EditValue.ToString) + "',awbill_no='" + addSlashes(TEAwbNo.Text.ToString) + "',awbill_inv_no='" + addSlashes(TEInvNo.Text.ToString) + "',pick_up_date=" + date_pickup + ",rec_by_store_date=" + date_store + ",rec_by_store_person='" + rec_store_by + "',awbill_note='" + addSlashes(MENote.Text) + "',id_cargo_best='" + decimalSQL(GVCargoRate.GetRowCellValue(0, "id_cargo").ToString) + "',cargo_rate_best='" + decimalSQL(GVCargoRate.GetRowCellValue(0, "cargo_rate").ToString) + "',cargo_lead_time_best='" + decimalSQL(GVCargoRate.GetRowCellValue(0, "cargo_lead_time").ToString) + "',cargo_min_weight_best='" + decimalSQL(GVCargoRate.GetRowCellValue(0, "cargo_min_weight").ToString) + "',mark_different='" & mark_diff & "' WHERE id_awbill='" + id_awb + "'"
                execute_non_query(query, True, "", "", "", "")

                query = "CALL awbill_log('" & id_awb & "','" & id_user & "')"
                execute_non_query(query, True, "", "", "", "")

                'detail
                'If Not isCreatedManifest()Then
                '    '
                '    query = "DELETE FROM tb_wh_awbill_det WHERE id_awbill='" + id_awb + "'"
                '    execute_non_query(query, True, "", "", "", "")
                '    '
                '    If GVDO.RowCount > 0 Then
                '        query = "INSERT INTO tb_wh_awbill_det(id_awbill,id_pl_sales_order_del,do_no,qty) VALUES"
                '        For i As Integer = 0 To GVDO.RowCount - 1
                '            Dim id_pl_sales_order_del As String = "NULL"
                '            Try
                '                id_pl_sales_order_del = GVDO.GetRowCellValue(i, "id_pl_sales_order_del").ToString
                '            Catch ex As Exception
                '            End Try
                '            If id_pl_sales_order_del = "" Then
                '                id_pl_sales_order_del = "NULL"
                '            End If

                '            If Not i = 0 Then
                '                query += ","
                '            End If
                '            query += "('" + id_awb + "'," + id_pl_sales_order_del + ",'" + GVDO.GetRowCellValue(i, "do_no").ToString + "','" + GVDO.GetRowCellValue(i, "qty").ToString + "')"
                '        Next
                '        execute_non_query(query, True, "", "", "", "")
                '    End If
                'End If


                'infoCustom("AWB calculation updated.")
                Dim find_string As String = ""
                Dim filter_string As String = ""
                Dim sort(FormWHCargoRate.GVCompany.Columns.Count, 2) As String
                '
                If id_awb_type = "1" Then
                    filter_string = FormWHAWBill.GVAWBill.ActiveFilterString
                    find_string = FormWHAWBill.GVAWBill.FindFilterText.ToString
                    'sorting
                    For i As Integer = 0 To FormWHCargoRate.GVCompany.SortedColumns.Count - 1
                        sort(i, 1) = FormWHCargoRate.GVCompany.SortedColumns.Item(i).FieldName
                        If FormWHCargoRate.GVCompany.SortedColumns.Item(i).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending Then
                            sort(i, 2) = "1"
                        Else
                            sort(i, 2) = "2"
                        End If
                    Next
                    '
                    FormWHAWBill.load_outbound()

                    FormWHAWBill.GVAWBill.ActiveFilterString = filter_string
                    FormWHAWBill.GVAWBill.ApplyFindFilter(find_string)
                    FormWHAWBill.GVAWBill.FocusedRowHandle = find_row(FormWHAWBill.GVAWBill, "id_awbill", id_awb)
                Else
                    filter_string = FormWHAWBill.GVAwbillIn.ActiveFilterString
                    find_string = FormWHAWBill.GVAwbillIn.FindFilterText.ToString
                    FormWHAWBill.load_inbound()
                    FormWHAWBill.GVAwbillIn.ActiveFilterString = filter_string
                    FormWHAWBill.GVAwbillIn.ApplyFindFilter(find_string)
                    FormWHAWBill.GVAwbillIn.FocusedRowHandle = find_row(FormWHAWBill.GVAwbillIn, "id_awbill", id_awb)
                End If
            End If
        End If
    End Sub

    Private Sub BPickupNothing_Click(sender As Object, e As EventArgs) Handles BPickupNothing.Click
        DEPickUp.EditValue = Nothing
    End Sub

    Private Sub BRecStoreNothing_Click(sender As Object, e As EventArgs) Handles BRecStoreNothing.Click
        DEStore.EditValue = Nothing
    End Sub

    Private Sub TELength_KeyDown(sender As Object, e As KeyEventArgs) Handles TELength.KeyDown
        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            SelectNextControl(ActiveControl, True, True, True, True)
        End If
    End Sub

    Private Sub TEWidth_KeyDown(sender As Object, e As KeyEventArgs) Handles TEWidth.KeyDown
        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            SelectNextControl(ActiveControl, True, True, True, True)
        End If
    End Sub

    Private Sub TEHeight_KeyDown(sender As Object, e As KeyEventArgs) Handles TEHeight.KeyDown
        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            SelectNextControl(ActiveControl, True, True, True, True)
        End If
    End Sub

    Private Sub TEWeight_KeyDown(sender As Object, e As KeyEventArgs) Handles TEWeight.KeyDown
        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            SelectNextControl(ActiveControl, True, True, True, True)
        End If
    End Sub

    Private Sub TECompCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TECompCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim query As String = "select cc.id_comp_contact,cc.id_comp,c.npwp,c.comp_number,c.comp_name,c.comp_commission,c.address_primary,c.id_city,c.id_sub_district,c.id_commerce_type "
            query += " From tb_m_comp_contact cc "
            query += " inner join tb_m_comp c On c.id_comp=cc.id_comp"
            query += " where cc.is_default=1 and c.id_comp_cat='6' AND c.comp_number='" + TECompCode.Text + "'"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

            If data.Rows.Count <= 0 Then
                stopCustom("Store not found.")
                TECompCode.Focus()
            ElseIf data.Rows.Count > 1 Then
                FormPopUpContact.id_pop_up = "awb"
                FormPopUpContact.id_cat = "6"
                FormPopUpContact.GVCompany.ActiveFilterString = "[comp_number]='" + TECompCode.Text + "'"
                FormPopUpContact.ShowDialog()
                If Not id_comp = "-1" Then
                    rate_table()
                    e.SuppressKeyPress = True
                    SelectNextControl(ActiveControl, True, True, True, True)
                End If
            Else
                id_comp = data.Rows(0)("id_comp").ToString
                SLESubDistrict.EditValue = data.Rows(0)("id_sub_district").ToString
                TECompName.Text = data.Rows(0)("comp_name").ToString
                TECompCode.Text = data.Rows(0)("comp_number").ToString
                '
                If data.Rows(0)("id_commerce_type").ToString = "2" Then
                    SLESubDistrict.Enabled = True
                Else
                    SLESubDistrict.Enabled = False
                End If
                '
                clear_do()
                '
                'TEWeight.Focus() ---三
                rate_table()
                e.SuppressKeyPress = True
                SelectNextControl(ActiveControl, True, True, True, True)
            End If
        End If
    End Sub
    Sub clear_do()
        For i As Integer = GVDO.RowCount To 0 Step -1
            GVDO.DeleteRow(i)
        Next
    End Sub
    Private Sub BRemoveDO_Click(sender As Object, e As EventArgs) Handles BRemoveDO.Click
        If GVDO.RowCount > 0 Then
            GVDO.DeleteRow(GVDO.FocusedRowHandle)
        End If
    End Sub

    Private Sub SLECargo_KeyDown(sender As Object, e As KeyEventArgs) Handles SLECargo.KeyDown
        If id_awb_type = "1" Then 'outbound
            If (e.KeyData = Keys.Enter) Then
                e.SuppressKeyPress = True
                If TEMarkDifferent.Visible = True Then
                    TEMarkDifferent.Focus()
                Else
                    CEPaid.Focus()
                End If
            End If
        Else
            If (e.KeyData = Keys.Enter) Then
                e.SuppressKeyPress = True
                XTCDetail.SelectedTabPageIndex = 1
                TEAwbNo.Focus()
            End If
        End If
    End Sub

    Private Sub TEInvNo_KeyDown(sender As Object, e As KeyEventArgs) Handles TEAwbNo.KeyDown
        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            TEInvNo.Focus()
        End If
    End Sub

    Private Sub DEPickUp_KeyDown(sender As Object, e As KeyEventArgs) Handles DEPickUp.KeyDown
        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            DEStore.Focus()
        End If
    End Sub

    Private Sub DEStore_KeyDown(sender As Object, e As KeyEventArgs) Handles DEStore.KeyDown
        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            TERecByPerson.Focus()
        End If
    End Sub

    Private Sub MENote_KeyDown(sender As Object, e As KeyEventArgs) Handles MENote.KeyDown
        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            BSave.Focus()
        End If
    End Sub

    Private Sub CEPaid_KeyDown(sender As Object, e As KeyEventArgs) Handles CEPaid.KeyDown
        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            XTCDetail.SelectedTabPageIndex = 1
            TEAwbNo.Focus()
        End If
    End Sub

    Private Sub CEPaid_CheckedChanged(sender As Object, e As EventArgs) Handles CEPaid.CheckedChanged
        calculate_amount()
    End Sub

    Private Sub TERecByPerson_KeyDown(sender As Object, e As KeyEventArgs) Handles TERecByPerson.KeyDown
        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            MENote.Focus()
        End If
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_awb
        FormReportMark.report_mark_type = "101"
        FormReportMark.is_view = is_view
        FormReportMark.ShowDialog()
    End Sub

    Private Sub TEMarkDifferent_KeyDown(sender As Object, e As KeyEventArgs) Handles TEMarkDifferent.KeyDown
        If id_awb_type = "1" Then 'outbound
            If (e.KeyData = Keys.Enter) Then
                e.SuppressKeyPress = True
                CEPaid.Focus()
            End If
        Else
            If (e.KeyData = Keys.Enter) Then
                e.SuppressKeyPress = True
                XTCDetail.SelectedTabPageIndex = 1
                TEAwbNo.Focus()
            End If
        End If
    End Sub

    Private Sub TEAwbInvoice_KeyDown(sender As Object, e As KeyEventArgs) Handles TEInvNo.KeyDown
        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            DEPickUp.Focus()
        End If
    End Sub

    Private Sub TEBeratTerpakai_EditValueChanged(sender As Object, e As EventArgs) Handles TEBeratTerpakai.EditValueChanged
        Try
            If TEBeratTerpakai.EditValue > 0 Then
                rate_table()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SLECity_EditValueChanged(sender As Object, e As EventArgs) Handles SLESubDistrict.EditValueChanged
        'clear_do()
        '
        'TEWeight.Focus() ---三
        rate_table()
        SelectNextControl(ActiveControl, True, True, True, True)
    End Sub
End Class