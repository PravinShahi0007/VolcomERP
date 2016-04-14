Public Class FormMatWODet
    Public id_purc As String = "-1" 'id_wo
    Public id_comp_to As String = "-1"
    Public id_comp_ship_to As String = "-1"
    Public date_created As String = ""
    Public id_report_status_g As String = "1"
    Public id_wo_type As String = "-1"
    Public id_rev As String = "-1"

    Private Sub FormMatWODet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        action_load()
    End Sub

    Sub action_load()
        view_currency(LECurrency)
        view_wo_type(LEWOType)
        viewSeason(LESeason)
        view_payment_type(LEpayment)

        Dim default_kurs As Decimal
        default_kurs = 1.0
        TEKurs.EditValue = default_kurs

        If id_purc = "-1" Then
            'new
            TEDate.Text = view_date(0)
            TERecDate.Text = view_date(0)
            TEDueDate.Text = view_date(0)
            TEPONumber.Text = header_number_mat("2")
            view_list_purchase(id_purc)
            view_list_mat_ext("-1")
            BPrint.Visible = False
            BMark.Visible = False
            BAttach.Visible = False
            '
        Else
            Dim query As String = String.Format("SELECT IFNULL(a.id_mat_wo_rev,'-1') as id_mat_wo_rev,IFNULL(b.mat_wo_number,'-') as mat_wo_number_rev,a.id_ovh,a.mat_wo_kurs,a.id_report_status,a.mat_wo_vat,a.id_delivery,a.mat_wo_number,a.id_comp_contact_to,a.id_comp_contact_ship_to,a.id_payment,DATE_FORMAT(a.mat_wo_date,'%Y-%m-%d') as mat_wo_datex,a.mat_wo_lead_time,a.mat_wo_top,a.id_currency,a.mat_wo_note" _
                                                & " FROM tb_mat_wo a " _
                                                & " LEFT JOIN tb_mat_wo b ON a.id_mat_wo_rev=b.id_mat_wo " _
                                                & " WHERE a.id_mat_wo = '{0}'", id_purc)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TEPONumber.Text = data.Rows(0)("mat_wo_number").ToString
            TEKurs.Text = data.Rows(0)("mat_wo_kurs").ToString

            id_rev = data.Rows(0)("id_mat_wo_rev").ToString
            TEWORevNumber.Text = data.Rows(0)("mat_wo_number_rev").ToString

            LECurrency.EditValue = Nothing
            LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)

            LEpayment.EditValue = Nothing
            LEpayment.ItemIndex = LEpayment.Properties.GetDataSourceRowIndex("id_payment", data.Rows(0)("id_payment").ToString)

            id_report_status_g = data.Rows(0)("id_report_status").ToString

            LESeason.EditValue = get_id_season(data.Rows(0)("id_delivery").ToString)
            LEDelivery.EditValue = data.Rows(0)("id_delivery").ToString

            LEWOType.EditValue = data.Rows(0)("id_ovh").ToString()
            id_wo_type = LEWOType.EditValue.ToString

            id_comp_to = data.Rows(0)("id_comp_contact_to").ToString
            TECompName.Text = get_company_x(get_id_company(id_comp_to), "1")
            TECompCode.Text = get_company_x(get_id_company(id_comp_to), "2")
            MECompAddress.Text = get_company_x(get_id_company(id_comp_to), "3")
            TECompAttn.Text = get_company_contact_x(id_comp_to, "1")

            id_comp_ship_to = data.Rows(0)("id_comp_contact_ship_to").ToString
            TECompShipToName.Text = get_company_x(get_id_company(id_comp_ship_to), "1")
            TECompShipTo.Text = get_company_x(get_id_company(id_comp_ship_to), "2")
            MECompShipToAddress.Text = get_company_x(get_id_company(id_comp_ship_to), "3")

            MENote.Text = data.Rows(0)("mat_wo_note").ToString

            date_created = data.Rows(0)("mat_wo_datex").ToString
            TEDate.Text = view_date_from(date_created, 0)
            TELeadTime.Text = data.Rows(0)("mat_wo_lead_time").ToString
            TERecDate.Text = view_date_from(date_created, Integer.Parse(data.Rows(0)("mat_wo_lead_time").ToString))
            TETOP.Text = data.Rows(0)("mat_wo_top").ToString
            TEDueDate.Text = view_date_from(date_created, (Integer.Parse(data.Rows(0)("mat_wo_lead_time").ToString) + Integer.Parse(data.Rows(0)("mat_wo_top").ToString)))
            '
            GConListPurchase.Enabled = True
            TEVat.Properties.ReadOnly = False
            view_list_purchase(id_purc)
            view_list_mat_ext(id_purc)
            TEVat.Text = data.Rows(0)("mat_wo_vat").ToString
            calculate()
        End If
        allow_status()
    End Sub

    Sub action_load_rev()
        view_currency(LECurrency)
        view_wo_type(LEWOType)
        viewSeason(LESeason)
        view_payment_type(LEpayment)

        Dim default_kurs As Decimal
        default_kurs = 1.0
        TEKurs.EditValue = default_kurs

        Dim query As String = String.Format("SELECT id_ovh,mat_wo_kurs,id_report_status,mat_wo_vat,id_delivery,mat_wo_number,id_comp_contact_to,id_comp_contact_ship_to,id_payment,DATE_FORMAT(mat_wo_date,'%Y-%m-%d') as mat_wo_datex,mat_wo_lead_time,mat_wo_top,id_currency,mat_wo_note FROM tb_mat_wo WHERE id_mat_wo = '{0}'", id_rev)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TEPONumber.Text = data.Rows(0)("mat_wo_number").ToString
        TEKurs.Text = data.Rows(0)("mat_wo_kurs").ToString

        LECurrency.EditValue = Nothing
        LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)

        LEpayment.EditValue = Nothing
        LEpayment.ItemIndex = LEpayment.Properties.GetDataSourceRowIndex("id_payment", data.Rows(0)("id_payment").ToString)

        LESeason.EditValue = get_id_season(data.Rows(0)("id_delivery").ToString)
        LEDelivery.EditValue = data.Rows(0)("id_delivery").ToString

        LEWOType.EditValue = data.Rows(0)("id_ovh").ToString()
        id_wo_type = LEWOType.EditValue.ToString

        id_comp_to = data.Rows(0)("id_comp_contact_to").ToString
        TECompName.Text = get_company_x(get_id_company(id_comp_to), "1")
        TECompCode.Text = get_company_x(get_id_company(id_comp_to), "2")
        MECompAddress.Text = get_company_x(get_id_company(id_comp_to), "3")
        TECompAttn.Text = get_company_contact_x(id_comp_to, "1")

        id_comp_ship_to = data.Rows(0)("id_comp_contact_ship_to").ToString
        TECompShipToName.Text = get_company_x(get_id_company(id_comp_ship_to), "1")
        TECompShipTo.Text = get_company_x(get_id_company(id_comp_ship_to), "2")
        MECompShipToAddress.Text = get_company_x(get_id_company(id_comp_ship_to), "3")

        MENote.Text = data.Rows(0)("mat_wo_note").ToString

        date_created = data.Rows(0)("mat_wo_datex").ToString
        TEDate.Text = view_date_from(date_created, 0)
        TELeadTime.Text = data.Rows(0)("mat_wo_lead_time").ToString
        TERecDate.Text = view_date_from(date_created, Integer.Parse(data.Rows(0)("mat_wo_lead_time").ToString))
        TETOP.Text = data.Rows(0)("mat_wo_top").ToString
        TEDueDate.Text = view_date_from(date_created, (Integer.Parse(data.Rows(0)("mat_wo_lead_time").ToString) + Integer.Parse(data.Rows(0)("mat_wo_top").ToString)))
        '
        GConListPurchase.Enabled = True
        TEVat.Properties.ReadOnly = False
        view_list_purchase(id_rev)
        view_list_mat_ext(id_rev)
        TEVat.Text = data.Rows(0)("mat_wo_vat").ToString
        calculate()

        allow_status()
    End Sub

    Sub view_delivery(ByVal id_season As String, ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT id_delivery,delivery FROM tb_season_delivery WHERE id_season='" & id_season & "' ORDER BY id_delivery DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "delivery"
        lookup.Properties.ValueMember = "id_delivery"
        If data.Rows.Count > 0 Then
            lookup.EditValue = data.Rows(0)("id_delivery").ToString
        End If
    End Sub

    Sub view_list_purchase(ByVal id_purcx As String)
        Dim query = "CALL view_mat_wo_det('" & id_purcx & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
        show_but()
        calculate()
    End Sub
    Sub view_list_purchase_ext(ByVal ext As String)
        Dim query = "CALL view_mat_wo_det('" & ext & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
        show_but()
        calculate()
    End Sub
    Sub view_list_mat_ext(ByVal ext As String)
        Dim query = "CALL view_mat_wo_mat('" & ext & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMaterial.DataSource = data
        show_but_mat()
    End Sub
    Private Sub view_currency(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "currency"
        lookup.Properties.ValueMember = "id_currency"
        lookup.ItemIndex = 0
    End Sub
    Private Sub view_report_status(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_report_status,report_status FROM tb_lookup_report_status"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "report_status"
        lookup.Properties.ValueMember = "id_report_status"
        lookup.ItemIndex = 0
    End Sub
    Private Sub view_payment_type(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_payment,payment FROM tb_lookup_payment"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "payment"
        lookup.Properties.ValueMember = "id_payment"
        lookup.ItemIndex = 0
    End Sub
    Private Sub view_wo_type(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT id_ovh,overhead FROM tb_m_ovh ORDER BY id_ovh ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "overhead"
        lookup.Properties.ValueMember = "id_ovh"
        lookup.EditValue = data.Rows(0)("id_ovh").ToString
        id_wo_type = lookup.EditValue.ToString
    End Sub
    'View Season
    Private Sub viewSeason(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT id_season,season FROM tb_season ORDER BY id_season DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "season"
        lookup.Properties.ValueMember = "id_season"

        If data.Rows.Count > 0 Then
            lookup.EditValue = data.Rows(0)("id_season").ToString
            view_delivery(data.Rows(0)("id_season").ToString, LEDelivery)
        End If
    End Sub

    Private Sub BSearchCompTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSearchCompTo.Click
        FormPopUpContact.id_pop_up = "19"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BSearchCompShipTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSearchCompShipTo.Click
        FormPopUpContact.id_pop_up = "20"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim kurs, err_txt, query, ovh_type, po_number, lead_time, top, payment_type, id_delivery, id_currency, notex, vat, id_purc_new As String
        err_txt = "-1"

        ovh_type = LEWOType.EditValue
        payment_type = LEpayment.EditValue
        id_delivery = LEDelivery.EditValue
        id_currency = LECurrency.EditValue
        po_number = TEPONumber.Text
        lead_time = TELeadTime.Text
        top = TETOP.Text
        notex = MENote.Text
        kurs = TEKurs.EditValue
        vat = TEVat.EditValue

        ValidateChildren()

        If id_delivery = "" Or Not formIsValidInGroup(EPMatWO, GroupGeneralHeader) Or id_comp_ship_to = "-1" Or id_comp_to = "-1" Then
            'error input
            stopCustom("Please make sure :" & vbNewLine & "- Delivery is not blank" & vbNewLine & "- To and Ship To is not blank" & vbNewLine & "- Order number is correct")
        Else
            If id_purc <> "-1" Then
                'edit
                Try
                    If id_rev = "-1" Then 'no rev
                        query = String.Format("UPDATE tb_mat_wo SET id_delivery='{0}',mat_wo_number='{1}',id_comp_contact_to='{2}',id_comp_contact_ship_to='{3}',id_ovh='{4}',id_payment='{5}',mat_wo_lead_time='{6}',mat_wo_top='{7}',id_currency='{8}',mat_wo_note='{9}',mat_wo_vat='{10}',mat_wo_kurs='{12}',id_mat_wo_rev=NULL WHERE id_mat_wo='{11}'", id_delivery, po_number, id_comp_to, id_comp_ship_to, ovh_type, payment_type, lead_time, top, id_currency, notex, vat, id_purc, kurs)
                    Else 'rev
                        query = String.Format("UPDATE tb_mat_wo SET id_delivery='{0}',mat_wo_number='{1}',id_comp_contact_to='{2}',id_comp_contact_ship_to='{3}',id_ovh='{4}',id_payment='{5}',mat_wo_lead_time='{6}',mat_wo_top='{7}',id_currency='{8}',mat_wo_note='{9}',mat_wo_vat='{10}',mat_wo_kurs='{12}',id_mat_wo_rev='{13}' WHERE id_mat_wo='{11}'", id_delivery, po_number, id_comp_to, id_comp_ship_to, ovh_type, payment_type, lead_time, top, id_currency, notex, vat, id_purc, kurs, id_rev)
                    End If
                    execute_non_query(query, True, "", "", "", "")
                    'delete first
                    Dim sp_check As Boolean = False
                    Dim query_del As String = "SELECT id_mat_wo_det FROM tb_mat_wo_det WHERE id_mat_wo='" & id_purc & "'"
                    Dim data_del As DataTable = execute_query(query_del, -1, True, "", "", "", "")
                    If data_del.Rows.Count > 0 Then
                        For i As Integer = 0 To data_del.Rows.Count - 1
                            sp_check = False
                            ' false mean not found, believe me
                            For j As Integer = 0 To GVListPurchase.RowCount - 1
                                If Not GVListPurchase.GetRowCellValue(j, "id_mat_wo_det").ToString = "" Then
                                    '
                                    If GVListPurchase.GetRowCellValue(j, "id_mat_wo_det").ToString = data_del.Rows(i)("id_mat_wo_det").ToString() Then
                                        sp_check = True
                                    End If
                                End If
                            Next
                            'end loop check on gv
                            If sp_check = False Then
                                'Because not found, it's only mean already deleted
                                query = String.Format("DELETE FROM tb_mat_wo_det WHERE id_mat_wo_det='{0}'", data_del.Rows(i)("id_mat_wo_det").ToString())
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        Next
                    End If

                    For i As Integer = 0 To GVListPurchase.RowCount - 1
                        If Not GVListPurchase.GetRowCellValue(i, "id_ovh_price").ToString = "" And Not GVListPurchase.GetRowCellValue(i, "id_mat_det").ToString = "" Then
                            If GVListPurchase.GetRowCellValue(i, "id_mat_wo_det").ToString = "" Then
                                'insert new
                                query = String.Format("INSERT INTO tb_mat_wo_det(id_mat_wo,id_ovh_price,mat_wo_det_price,mat_wo_det_discount,mat_wo_det_qty,mat_wo_det_note,id_mat_det,id_mat_det_result,id_mat_det_price,id_mat_det_price_result) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", id_purc, GVListPurchase.GetRowCellValue(i, "id_ovh_price").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "discount").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "qty").ToString), GVListPurchase.GetRowCellValue(i, "note").ToString, GVListPurchase.GetRowCellValue(i, "id_mat_det").ToString, GVListPurchase.GetRowCellValue(i, "id_mat_det_result").ToString, GVListPurchase.GetRowCellValue(i, "id_mat_det_price").ToString, GVListPurchase.GetRowCellValue(i, "id_mat_det_price_result").ToString)
                                execute_non_query(query, True, "", "", "", "")
                            Else
                                'update
                                query = String.Format("UPDATE tb_mat_wo_det SET id_ovh_price='{0}',mat_wo_det_price='{1}',mat_wo_det_discount='{2}',mat_wo_det_qty='{3}',mat_wo_det_note='{4}',id_mat_det='{6}',id_mat_det_result='{7}',id_mat_det_price='{8}',id_mat_det_price_result='{9}' WHERE id_mat_wo_det='{5}'", GVListPurchase.GetRowCellValue(i, "id_ovh_price").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "discount").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "qty").ToString), GVListPurchase.GetRowCellValue(i, "note").ToString, GVListPurchase.GetRowCellValue(i, "id_mat_wo_det").ToString, GVListPurchase.GetRowCellValue(i, "id_mat_det").ToString, GVListPurchase.GetRowCellValue(i, "id_mat_det_result").ToString, GVListPurchase.GetRowCellValue(i, "id_mat_det_price").ToString, GVListPurchase.GetRowCellValue(i, "id_mat_det_price_result").ToString)
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        End If
                    Next
                    'next table
                    'delete first
                    sp_check = False
                    query_del = "SELECT id_mat_wo_mat FROM tb_mat_wo_mat WHERE id_mat_wo='" & id_purc & "'"
                    data_del = execute_query(query_del, -1, True, "", "", "", "")
                    If data_del.Rows.Count > 0 Then
                        For i As Integer = 0 To data_del.Rows.Count - 1
                            sp_check = False
                            ' false mean not found, believe me
                            For j As Integer = 0 To GVMaterial.RowCount - 1
                                If Not GVMaterial.GetRowCellValue(j, "id_mat_wo_mat").ToString = "" Then
                                    '
                                    If GVMaterial.GetRowCellValue(j, "id_mat_wo_mat").ToString = data_del.Rows(i)("id_mat_wo_mat").ToString() Then
                                        sp_check = True
                                    End If
                                End If
                            Next
                            'end loop check on gv
                            If sp_check = False Then
                                'Because not found, it's only mean already deleted
                                query = String.Format("DELETE FROM tb_mat_wo_mat WHERE id_mat_wo_mat='{0}'", data_del.Rows(i)("id_mat_wo_mat").ToString())
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        Next
                    End If

                    For i As Integer = 0 To GVMaterial.RowCount - 1
                        If Not GVMaterial.GetRowCellValue(i, "id_mat_det").ToString = "" Then
                            If GVMaterial.GetRowCellValue(i, "id_mat_wo_mat").ToString = "" Then
                                'insert new
                                query = String.Format("INSERT INTO tb_mat_wo_mat(id_mat_wo,id_mat_det,id_mat_det_price,mat_wo_mat_price,mat_wo_mat_qty,mat_wo_mat_note) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", id_purc, GVMaterial.GetRowCellValue(i, "id_mat_det").ToString, GVMaterial.GetRowCellValue(i, "id_mat_det_price").ToString, decimalSQL(GVMaterial.GetRowCellValue(i, "price").ToString), decimalSQL(GVMaterial.GetRowCellValue(i, "qty").ToString), GVMaterial.GetRowCellValue(i, "note").ToString)
                                execute_non_query(query, True, "", "", "", "")
                            Else
                                'update
                                query = String.Format("UPDATE tb_mat_wo_mat SET id_mat_det='{1}',id_mat_det_price='{2}',mat_wo_mat_price='{3}',mat_wo_mat_qty='{4}',mat_wo_mat_note='{5}' WHERE id_mat_wo_mat='{0}'", GVMaterial.GetRowCellValue(i, "id_mat_wo_mat").ToString, GVMaterial.GetRowCellValue(i, "id_mat_det").ToString, GVMaterial.GetRowCellValue(i, "id_mat_det_price").ToString, decimalSQL(GVMaterial.GetRowCellValue(i, "price").ToString), decimalSQL(GVMaterial.GetRowCellValue(i, "qty").ToString), GVMaterial.GetRowCellValue(i, "note").ToString)
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        End If
                    Next
                    FormMatWO.view_mat_purc()
                    FormMatWO.GVMatWO.FocusedRowHandle = find_row(FormMatWO.GVMatWO, "id_mat_wo", id_purc)
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            Else
                'new
                Try
                    'insert 
                    If id_rev = "-1" Then
                        query = String.Format("INSERT INTO tb_mat_wo(id_delivery,mat_wo_number,id_comp_contact_to,id_comp_contact_ship_to,id_ovh,id_payment,mat_wo_date,mat_wo_lead_time,mat_wo_top,id_currency,mat_wo_note,mat_wo_vat,mat_wo_kurs) VALUES('{0}','{1}','{2}','{3}','{4}','{5}',DATE(NOW()),'{6}','{7}','{8}','{9}','{10}','{11}');SELECT LAST_INSERT_ID() ", id_delivery, po_number, id_comp_to, id_comp_ship_to, ovh_type, payment_type, lead_time, top, id_currency, notex, vat, kurs)
                    Else
                        query = String.Format("INSERT INTO tb_mat_wo(id_delivery,mat_wo_number,id_comp_contact_to,id_comp_contact_ship_to,id_ovh,id_payment,mat_wo_date,mat_wo_lead_time,mat_wo_top,id_currency,mat_wo_note,mat_wo_vat,mat_wo_kurs,id_mat_wo_rev) VALUES('{0}','{1}','{2}','{3}','{4}','{5}',DATE(NOW()),'{6}','{7}','{8}','{9}','{10}','{11}','{12}');SELECT LAST_INSERT_ID() ", id_delivery, po_number, id_comp_to, id_comp_ship_to, ovh_type, payment_type, lead_time, top, id_currency, notex, vat, kurs, id_rev)
                    End If
                    id_purc_new = execute_query(query, 0, True, "", "", "", "")
                    '
                    insert_who_prepared("15", id_purc_new, id_user)

                    increase_inc_mat("2")
                    For i As Integer = 0 To GVListPurchase.RowCount - 1
                        If Not GVListPurchase.GetRowCellValue(i, "id_ovh_price").ToString = "" And Not GVListPurchase.GetRowCellValue(i, "id_mat_det").ToString = "" Then
                            'dp
                            query = String.Format("INSERT INTO tb_mat_wo_det(id_mat_wo,id_ovh_price,mat_wo_det_price,mat_wo_det_discount,mat_wo_det_qty,mat_wo_det_note,id_mat_det,id_mat_det_price) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", id_purc_new, GVListPurchase.GetRowCellValue(i, "id_ovh_price").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "discount").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "qty").ToString), GVListPurchase.GetRowCellValue(i, "note").ToString, GVListPurchase.GetRowCellValue(i, "id_mat_det").ToString, GVListPurchase.GetRowCellValue(i, "id_mat_det_price").ToString)
                            execute_non_query(query, True, "", "", "", "")
                        End If
                    Next

                    For i As Integer = 0 To GVMaterial.RowCount - 1
                        If Not GVMaterial.GetRowCellValue(i, "id_mat_det").ToString = "" Then
                            query = String.Format("INSERT INTO tb_mat_wo_mat(id_mat_wo,id_mat_det,id_mat_det_price,mat_wo_mat_price,mat_wo_mat_qty,mat_wo_mat_note) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", id_purc_new, GVMaterial.GetRowCellValue(i, "id_mat_det").ToString, GVMaterial.GetRowCellValue(i, "id_mat_det_price").ToString, decimalSQL(GVMaterial.GetRowCellValue(i, "price").ToString), decimalSQL(GVMaterial.GetRowCellValue(i, "qty").ToString), GVMaterial.GetRowCellValue(i, "note").ToString)
                            execute_non_query(query, True, "", "", "", "")
                        End If
                    Next
                    FormMatWO.view_mat_purc()
                    FormMatWO.GVMatWO.FocusedRowHandle = find_row(FormMatWO.GVMatWO, "id_mat_wo", id_purc_new)
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
        End If
    End Sub

    Private Sub TEPONumber_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEPONumber.Validating
        Dim query_jml As String
        query_jml = String.Format("SELECT COUNT(id_mat_wo) FROM tb_mat_wo WHERE mat_wo_number='{0}' AND id_mat_wo!='{1}'", TEPONumber.Text, id_purc)
        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(EPMatWO, TEPONumber, "1")
        Else
            EP_TE_cant_blank(EPMatWO, TEPONumber)
        End If
    End Sub

    Private Sub TELeadTime_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TELeadTime.EditValueChanged
        If id_purc <> "-1" Then
            Try
                TERecDate.Text = view_date_from(date_created, Integer.Parse(TELeadTime.Text))
            Catch ex As Exception
                TERecDate.Text = view_date_from(date_created, 0)
            End Try
        Else
            Try
                TERecDate.Text = view_date(Integer.Parse(TELeadTime.Text))
            Catch ex As Exception
                TERecDate.Text = view_date(0)
            End Try
        End If
    End Sub

    Private Sub TETOP_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TETOP.EditValueChanged
        If id_purc <> "-1" Then
            Try
                TEDueDate.Text = view_date_from(date_created, (Integer.Parse(TELeadTime.Text) + Integer.Parse(TETOP.Text)))
            Catch ex As Exception
                TEDueDate.Text = view_date_from(date_created, 0)
            End Try
        Else
            Try
                TEDueDate.Text = view_date(Integer.Parse(TELeadTime.Text) + Integer.Parse(TETOP.Text))
            Catch ex As Exception
                TEDueDate.Text = view_date(0)
            End Try
        End If
    End Sub

    Private Sub LEpayment_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LEpayment.EditValueChanged
        If LEpayment.EditValue = 1 Then
            TETOP.Enabled = True
        Else
            TETOP.Text = 0
            If id_purc <> "-1" Then
                TEDueDate.Text = view_date_from(date_created, (Integer.Parse(TELeadTime.Text) + Integer.Parse(TETOP.Text)))
            Else
                TEDueDate.Text = view_date(Integer.Parse(TELeadTime.Text) + Integer.Parse(TETOP.Text))
            End If
            TETOP.Enabled = False
        End If
    End Sub

    Private Sub FormSamplePurchaseDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAdd.Click
        If id_comp_to <> "-1" Then
            FormMatWOSingle.id_comp = get_id_company(id_comp_to)
        End If
        FormMatWOSingle.id_pop_up = "1"
        FormMatWOSingle.id_ovh = LEWOType.EditValue
        FormMatWOSingle.ShowDialog()
    End Sub

    Sub calculate()
        Dim total, sub_tot, gross_tot, vat, discount As Decimal

        'Try
        sub_tot = GVListPurchase.Columns("total").SummaryItem.SummaryValue
        vat = (TEVat.EditValue / 100) * GVListPurchase.Columns("total").SummaryItem.SummaryValue
        discount = GVListPurchase.Columns("discount").SummaryItem.SummaryValue
        'Catch ex As Exception
        'End Try

        TEDiscount.EditValue = discount
        TEVatTot.EditValue = vat

        gross_tot = sub_tot + discount
        TEGrossTot.EditValue = gross_tot

        total = sub_tot + vat
        TETot.EditValue = total
        METotSay.Text = ConvertCurrencyToEnglish(Double.Parse(total.ToString), LECurrency.EditValue.ToString)
    End Sub

    Private Sub TEVat_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEVat.EditValueChanged
        calculate()
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEdit.Click
        If id_comp_to <> "-1" Then
            FormMatWOSingle.id_comp = get_id_company(id_comp_to)
        End If
        FormMatWOSingle.id_pop_up = "1"
        FormMatWOSingle.id_ovh = LEWOType.EditValue
        FormMatWOSingle.id_ovh_price = GVListPurchase.GetFocusedRowCellValue("id_ovh_price").ToString
        FormMatWOSingle.id_mat_det_result = GVListPurchase.GetFocusedRowCellValue("id_mat_det").ToString
        FormMatWOSingle.id_mat_det_price_result = GVListPurchase.GetFocusedRowCellValue("id_mat_det_price").ToString
        FormMatWOSingle.ShowDialog()
    End Sub

    Private Sub BPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        ReportMatWO.id_mat_purc = id_purc

        Dim Report As New ReportMatWO()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub Bdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bdel.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this material on list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                GVListPurchase.DeleteSelectedRows()
                show_but()
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show("This material on list already used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_purc
        FormReportMark.report_mark_type = "15"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub
    Sub allow_status()
        If check_edit_report_status(id_report_status_g, "15", id_purc) Then
            BAdd.Enabled = True
            BEdit.Enabled = True
            Bdel.Enabled = True
            BSave.Enabled = True
            '
            BAddMaterial.Enabled = True
            BEditMaterial.Enabled = True
            BDelMaterial.Enabled = True
            '
            BSearchCompTo.Enabled = True
            BSearchCompShipTo.Enabled = True
            BPickPORev.Enabled = True
        Else
            BAdd.Enabled = False
            BEdit.Enabled = False
            Bdel.Enabled = False
            BSave.Enabled = False
            '
            BAddMaterial.Enabled = False
            BEditMaterial.Enabled = False
            BDelMaterial.Enabled = False
            '
            BSearchCompTo.Enabled = False
            BSearchCompShipTo.Enabled = False
            BPickPORev.Enabled = False
        End If

        If check_print_report_status(id_report_status_g) Then
            BPrint.Enabled = True
        Else
            BPrint.Enabled = False
        End If
    End Sub
    Sub show_but()
        If GVListPurchase.RowCount > 0 Then
            BEdit.Visible = True
            Bdel.Visible = True
        Else
            BEdit.Visible = False
            Bdel.Visible = False
        End If
    End Sub
    Sub show_but_mat()
        If GVMaterial.RowCount > 0 Then
            BEditMaterial.Visible = True
            BDelMaterial.Visible = True
        Else
            BEditMaterial.Visible = False
            BDelMaterial.Visible = False
        End If
    End Sub

    Private Sub LESeason_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LESeason.EditValueChanged
        view_delivery(LESeason.EditValue, LEDelivery)
    End Sub

    Private Sub LEWOType_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LEWOType.EditValueChanged
        If GVListPurchase.RowCount > 0 Then
            If Not LEWOType.EditValue.ToString = "" Then
                If Not id_wo_type = LEWOType.EditValue.ToString Then
                    'make sure first, resetting all detail
                    Dim confirm As DialogResult
                    confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Changing type will delete all detail entry, Are you sure ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        Try
                            GCListPurchase.DataSource = Nothing
                            view_list_purchase_ext("-1")
                            show_but()
                            id_wo_type = LEWOType.EditValue.ToString
                        Catch ex As Exception
                            DevExpress.XtraEditors.XtraMessageBox.Show("This material on list already used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            LEWOType.EditValue = id_wo_type
                        End Try
                        Cursor = Cursors.Default
                    Else
                        LEWOType.EditValue = id_wo_type
                    End If
                End If
            End If
        End If
    End Sub

    'Private Sub CEShowResultField_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CEShowResultField.CheckedChanged
    '    If CEShowResultField.Checked = True Then
    '        Colresult_code.Visible = True
    '        Colresult_code.VisibleIndex = 3
    '        Colresult_name.Visible = True
    '        Colresult_name.VisibleIndex = 4
    '    Else
    '        Colresult_code.Visible = False
    '        Colresult_name.Visible = False
    '    End If
    'End Sub

    Private Sub BAddMaterial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAddMaterial.Click
        FormMatWOSingle.id_pop_up = "2"
        FormMatWOSingle.ShowDialog()
    End Sub

    Private Sub BDelMaterial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelMaterial.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this material on list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                GVMaterial.DeleteSelectedRows()
                show_but_mat()
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show("This material on list already used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BEditMaterial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditMaterial.Click
        FormMatWOSingle.id_pop_up = "2"
        FormMatWOSingle.id_mat_det = GVMaterial.GetFocusedRowCellValue("id_mat_det").ToString
        FormMatWOSingle.id_mat_det_price = GVMaterial.GetFocusedRowCellValue("id_mat_det_price").ToString
        FormMatWOSingle.ShowDialog()
    End Sub

    Private Sub GVMaterial_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMaterial.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BPickPORev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickPORev.Click
        FormPopUpWOMat.id_pop_up = "4"
        FormPopUpWOMat.id_wo = id_rev
        FormPopUpWOMat.ShowDialog()
    End Sub

    Private Sub BAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAttach.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_purc
        FormDocumentUpload.report_mark_type = "15"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class