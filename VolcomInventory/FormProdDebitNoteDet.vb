Public Class FormProdDebitNoteDet
    Public id_dn As String = "-1"
    Public id_comp_contact_debit_to As String = "-1"

    Private Sub FormProdDebitNoteDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        action_load()
    End Sub
    Sub action_load()
        view_claim_type(RIClaimType)

        view_report_status(LEReportStatus)

        If id_dn = "-1" Then 'new
            TxtVirtualPosNumber.Text = header_number_prod("14")
            Dim date_dn As Date = Now()
            DEForm.Text = date_dn.ToString("dd MMM yyyy")
        Else

        End If
        load_gv()
    End Sub

    Private Sub view_report_status(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_report_status,report_status FROM tb_lookup_report_status"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "report_status"
        lookup.Properties.ValueMember = "id_report_status"
        lookup.ItemIndex = 0
    End Sub

    Sub load_gv()
        Dim query As String = "SELECT dn.*,rec.`delivery_order_number`,rec.`delivery_order_date`,rec.`prod_order_rec_number`,rec.`arrive_date`,po.`prod_order_number`
                                ,dsg.`design_name` as name,dsg.`design_code`,RIGHT(dsg.`design_display_name`,3) AS color,DATE_ADD(wo.prod_order_wo_date, INTERVAL wo.`prod_order_wo_lead_time` DAY) AS est_rec_date
                                FROM tb_prod_debit_note_det dn
                                INNER JOIN 
                                (		
	                                SELECT rec.*,SUM(recd.prod_order_rec_det_qty) AS prod_order_rec_qty 
	                                FROM 
	                                tb_prod_order_rec rec 
	                                LEFT JOIN tb_prod_order_rec_det recd ON recd.id_prod_order_rec=rec.id_prod_order_rec
	                                GROUP BY rec.id_prod_order_rec 
                                ) rec ON rec.`id_prod_order_rec`=dn.`id_prod_order_rec` AND rec.id_report_status != 5
                                INNER JOIN tb_prod_order po ON po.`id_prod_order`=rec.`id_prod_order`
                                LEFT JOIN 
                                (SELECT * FROM tb_prod_order_wo wo WHERE wo.`is_main_vendor`=1 GROUP BY wo.`id_prod_order`) wo ON wo.`id_prod_order`=po.`id_prod_order`
                                INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
                                INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
                                WHERE dn.id_prod_debit_note='" & id_dn & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProdRec.DataSource = data
        GVProdRec.BestFitColumns()

        button_check()
    End Sub
    Private Sub view_claim_type(ByVal lookup As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)
        Dim query As String = "SELECT id_claim_type,claim_type,description FROM tb_lookup_claim_type ORDER BY id_claim_type ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.DataSource = data

        lookup.DisplayMember = "description"
        lookup.ValueMember = "id_claim_type"
    End Sub
    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormProdDebitNoteDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnBrowseContactFrom_Click(sender As Object, e As EventArgs) Handles BtnBrowseContactFrom.Click
        FormPopUpContact.id_cat = "1"
        FormPopUpContact.id_pop_up = "84"
        FormPopUpContact.ShowDialog()
    End Sub

    Sub button_check()
        If GVProdRec.RowCount > 0 Then
            BEdit.Visible = True
            BDelete.Visible = True
        Else
            BEdit.Visible = False
            BDelete.Visible = False
        End If
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click

    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        If id_comp_contact_debit_to = "-1" Then
            stopCustom("Please choose the vendor first")
        Else
            FormPopUpRecQC.id_contact_vendor = id_comp_contact_debit_to
            FormPopUpRecQC.id_pop_up = "2"
            FormPopUpRecQC.ShowDialog()
        End If
    End Sub
End Class