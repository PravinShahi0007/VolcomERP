﻿Public Class FormReportMark
    Public not_allow_complete As String = "-1"
    Public not_allow_cancelled As String = "-1"
    Public report_mark_type As String = "-1"
    Public id_report As String = "-1"
    Public id_report_status_report As String = "-1"
    Public form_origin As String
    Public is_view As String = "-1"
    Public is_disabled_set_stt = "-1"

    Public report_number As String = ""
    Public is_view_finalize As String = "-1"
    Public id_report_mark_cancel As String = "-1"

    Public is_bbk_tolakan As Boolean = False
    '
    ' report_mark_type
    ' WARNING : if want to add new report type, also add on the tb_lookup_report_mark_type ^_-
    ' is_view = "1" only for workplace (FormView*)

    Private Sub FormReportMark_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'checkFormAccessSingle(Name)
        'block load 
        If report_mark_type = "22" Then
            'Prod order - cek jika ada yang sedang diproses di perubajan design
            Dim query_cek As String = "SELECT * 
            FROM tb_m_design_changes_det pcd
            INNER JOIN tb_m_design d ON d.id_design = pcd.id_design
            INNER JOIN tb_m_design_changes pc ON pc.id_changes = pcd.id_changes
            WHERE d.id_design_rev_from=" + FormViewProduction.id_design + " AND pc.id_report_status!=5 "
            Dim data_cek As DataTable = execute_query(query_cek, -1, True, "", "", "", "")
            If data_cek.Rows.Count > 0 Then
                stopCustom("Cannot approve this order, because it's being processed for design changes.")
                Close()
                Exit Sub
            End If
        End If

        act_load()
        '
        '
    End Sub
    Sub act_load()
        Dim query As String = ""
        query = "SELECT COUNT(id_report_mark) FROM tb_report_mark WHERE id_report='" + id_report + "' AND report_mark_type='" + report_mark_type + "'"
        Dim jml As Integer = execute_query(query, 0, True, "", "", "", "")
        If jml = 0 Then 'not submitted yet
            Dim confirm As DialogResult
            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Form is not submitted yet, do you want to submit this form ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                submit_who_prepared(report_mark_type, id_report, id_user)
                '
                If report_mark_type = "153" Then
                    FormMasterCompanySingle.update_status("4")
                    FormMasterCompanySingle.action_load()
                End If
                '
                infoCustom("Form submitted.")
                act_load()
            Else
                Opacity = 0
                Close()
            End If
        Else 'normal
            view_mark()
            view_report_status(LEReportStatus)
            If is_view = "1" Then
                GroupControl2.Visible = False
            Else
                GroupControl2.Visible = True
            End If
            If is_disabled_set_stt = "1" Then
                LEReportStatus.Enabled = False
                BSetStatus.Enabled = False
            End If

            'view finalize
            If is_view_finalize = "1" Then
                view_mark_final()
                If GVFinal.RowCount > 0 Then
                    GroupControl3.Visible = True
                End If
            End If
            '
        End If
    End Sub

    Private Sub view_report_status(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_report_status,report_status FROM tb_lookup_report_status WHERE id_report_status!='7' "
        If not_allow_complete = "1" Then
            query += "AND id_report_status!='6' "
        End If
        If not_allow_cancelled = "1" Then
            query += "AND id_report_status!='5' "
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "report_status"
        lookup.Properties.ValueMember = "id_report_status"

        If report_mark_type = "1" Then
            'sample purchase
            query = String.Format("SELECT id_report_status,sample_purc_number as report_number FROM tb_sample_purc WHERE id_sample_purc = '{0}'", id_report)
        ElseIf report_mark_type = "2" Then
            'sample receive
            query = String.Format("SELECT id_report_status,sample_purc_rec_number as report_number FROM tb_sample_purc_rec WHERE id_sample_purc_rec = '{0}'", id_report)
        ElseIf report_mark_type = "3" Then
            'sample PL
            query = String.Format("SELECT id_report_status,pl_sample_purc_number as report_number FROM tb_pl_sample_purc WHERE id_pl_sample_purc = '{0}'", id_report)
        ElseIf report_mark_type = "4" Then
            'sample PR
            query = String.Format("SELECT id_report_status,pr_sample_purc_number as report_number FROM tb_pr_sample_purc WHERE id_pr_sample_purc = '{0}'", id_report)
        ElseIf report_mark_type = "5" Then
            'sample ret out
            query = String.Format("SELECT id_report_status,sample_purc_ret_in_number as report_number FROM tb_sample_purc_ret_out WHERE id_sample_purc_ret_out = '{0}'", id_report)
        ElseIf report_mark_type = "6" Then
            'sample ret in
            query = String.Format("SELECT id_report_status,sample_purc_ret_out_number as report_number FROM tb_sample_purc_ret_in WHERE id_sample_purc_ret_in = '{0}'", id_report)
        ElseIf report_mark_type = "7" Then
            'sample receipt
            query = String.Format("SELECT (id_report_status_rec) AS id_report_status FROM tb_pl_sample_purc WHERE id_pl_sample_purc = '{0}'", id_report)
        ElseIf report_mark_type = "8" Then
            'bom
            query = String.Format("SELECT id_report_status FROM tb_bom WHERE id_bom = '{0}'", id_report)
        ElseIf report_mark_type = "9" Or report_mark_type = "80" Or report_mark_type = "81" Or report_mark_type = "206" Then
            'prod demand
            query = String.Format("SELECT id_report_status,(prod_demand_number) AS report_number FROM tb_prod_Demand WHERE id_prod_demand = '{0}'", id_report)
        ElseIf report_mark_type = "10" Then
            'sample PL
            query = String.Format("SELECT id_report_status,pl_sample_del_number as report_number FROM tb_pl_sample_del WHERE id_pl_sample_del = '{0}'", id_report)
        ElseIf report_mark_type = "11" Then
            'sample Requisition
            query = String.Format("SELECT id_report_status, sample_requisition_number as report_number FROM tb_sample_requisition WHERE id_sample_requisition = '{0}'", id_report)
        ElseIf report_mark_type = "12" Then
            'sample plan
            query = String.Format("SELECT id_report_status,sample_plan_number as report_number FROM tb_sample_plan WHERE id_sample_plan = '{0}'", id_report)
        ElseIf report_mark_type = "13" Then
            'material purchasing
            query = String.Format("SELECT id_report_status,mat_purc_number as report_number FROM tb_mat_purc WHERE id_mat_purc = '{0}'", id_report)
        ElseIf report_mark_type = "14" Then
            'sample Return
            query = String.Format("SELECT id_report_status,sample_return_number as report_number FROM tb_sample_return WHERE id_sample_return = '{0}'", id_report)
        ElseIf report_mark_type = "15" Then
            'material wo
            query = String.Format("SELECT id_report_status,mat_wo_number as report_number FROM tb_mat_wo WHERE id_mat_wo = '{0}'", id_report)
        ElseIf report_mark_type = "16" Then
            'receive material purchase
            query = String.Format("SELECT id_report_status,mat_purc_rec_number as report_number FROM tb_mat_purc_rec WHERE id_mat_purc_rec = '{0}'", id_report)
        ElseIf report_mark_type = "17" Then
            'receive material wo
            query = String.Format("SELECT id_report_status,mat_wo_rec_number as report_number FROM tb_mat_wo_rec WHERE id_mat_wo_rec = '{0}'", id_report)
        ElseIf report_mark_type = "18" Then
            'Return Material Out
            query = String.Format("SELECT id_report_status,mat_purc_ret_out_number as report_number FROM tb_mat_purc_ret_out WHERE id_mat_purc_ret_out = '{0}'", id_report)
        ElseIf report_mark_type = "19" Then
            'Return Material In
            query = String.Format("SELECT id_report_status,mat_purc_ret_in_number as report_number FROM tb_mat_purc_ret_in WHERE id_mat_purc_ret_in = '{0}'", id_report)
        ElseIf report_mark_type = "20" Then
            'SAMPle Adj In
            query = String.Format("SELECT id_report_status,adj_in_sample_number as report_number FROM tb_adj_in_sample WHERE id_adj_in_sample = '{0}'", id_report)
        ElseIf report_mark_type = "21" Then
            'SAMPle Adj Out
            query = String.Format("SELECT id_report_status,adj_out_sample_number as report_number FROM tb_adj_out_sample WHERE id_adj_out_sample = '{0}'", id_report)
        ElseIf report_mark_type = "22" Then
            'Production Order
            query = String.Format("SELECT id_report_status FROM tb_prod_order WHERE id_prod_order = '{0}'", id_report)
        ElseIf report_mark_type = "23" Then
            'Production Work Order
            query = String.Format("SELECT id_report_status,prod_order_wo_number as report_number FROM tb_prod_order_wo WHERE id_prod_order_wo = '{0}'", id_report)
        ElseIf report_mark_type = "24" Then
            'Material PO PR
            query = String.Format("SELECT id_report_status,pr_mat_purc_number as report_number FROM tb_pr_mat_purc WHERE id_pr_mat_purc = '{0}'", id_report)
        ElseIf report_mark_type = "25" Then
            'Material WO PR
            query = String.Format("SELECT id_report_status,pr_mat_wo_number as report_number FROM tb_pr_mat_wo WHERE id_pr_mat_wo = '{0}'", id_report)
        ElseIf report_mark_type = "26" Then
            'Mat Adj In
            query = String.Format("SELECT id_report_status,adj_in_mat_number as report_number FROM tb_adj_in_mat WHERE id_adj_in_mat = '{0}'", id_report)
        ElseIf report_mark_type = "27" Then
            'Mat Adj Out
            query = String.Format("SELECT id_report_status,adj_out_mat_number as report_number FROM tb_adj_out_mat WHERE id_adj_out_mat = '{0}'", id_report)
        ElseIf report_mark_type = "28" Or report_mark_type = "127" Then
            'Production rec
            query = String.Format("SELECT id_report_status,prod_order_rec_number as report_number FROM tb_prod_order_rec WHERE id_prod_order_rec = '{0}'", id_report)
        ElseIf report_mark_type = "29" Then
            'Production MRS
            query = String.Format("SELECT id_report_status FROM tb_prod_order_mrs WHERE id_prod_order_mrs = '{0}'", id_report)
        ElseIf report_mark_type = "30" Then
            'PL MRS Production
            query = String.Format("SELECT id_report_status,pl_mrs_number as report_number FROM tb_pl_mrs WHERE id_pl_mrs = '{0}'", id_report)
        ElseIf report_mark_type = "31" Then
            'Production ret out
            query = String.Format("SELECT id_report_status,prod_order_ret_out_number as report_number FROM tb_prod_order_ret_out WHERE id_prod_order_ret_out = '{0}'", id_report)
        ElseIf report_mark_type = "32" Then
            'Production ret in
            query = String.Format("SELECT id_report_status,prod_order_ret_in_number as report_number FROM tb_prod_order_ret_in WHERE id_prod_order_ret_in = '{0}'", id_report)
        ElseIf report_mark_type = "33" Then
            'PL FG To WH
            query = String.Format("SELECT id_report_status,pl_prod_order_number as report_number FROM tb_pl_prod_order WHERE id_pl_prod_order = '{0}'", id_report)
        ElseIf report_mark_type = "34" Then
            'Inv Mat PL MRS
            query = String.Format("SELECT id_report_status,inv_pl_mrs_number as report_number FROM tb_inv_pl_mrs WHERE id_inv_pl_mrs = '{0}'", id_report)
        ElseIf report_mark_type = "35" Then
            'Inv Mat PL MRS
            query = String.Format("SELECT id_report_status,inv_pl_mrs_ret_number as report_number FROM tb_inv_pl_mrs_ret WHERE id_inv_pl_mrs_ret = '{0}'", id_report)
        ElseIf report_mark_type = "36" Then
            'Entry Journal
            query = String.Format("SELECT id_report_status FROM tb_a_acc_trans WHERE id_acc_trans = '{0}'", id_report)
        ElseIf report_mark_type = "37" Then
            'REC PL FG To WH
            query = String.Format("SELECT id_report_status,pl_prod_order_rec_number as report_number FROM tb_pl_prod_order_rec WHERE id_pl_prod_order_rec = '{0}'", id_report)
        ElseIf report_mark_type = "39" Or report_mark_type = "130" Then
            'SALES ORDER
            query = String.Format("SELECT id_report_status FROM tb_sales_order WHERE id_sales_order = '{0}'", id_report)
        ElseIf report_mark_type = "40" Then
            'Entry Journal Adjustment
            query = String.Format("SELECT id_report_status FROM tb_a_acc_trans_adj WHERE id_acc_trans_adj = '{0}'", id_report)
        ElseIf report_mark_type = "41" Then
            'FG Adj In
            query = String.Format("SELECT id_report_status,adj_in_fg_number as report_number FROM tb_adj_in_fg WHERE id_adj_in_fg = '{0}'", id_report)
        ElseIf report_mark_type = "42" Then
            'FG Adj Out
            query = String.Format("SELECT id_report_status,adj_out_fg_number as report_number FROM tb_adj_out_fg WHERE id_adj_out_fg = '{0}'", id_report)
        ElseIf report_mark_type = "43" Then
            'SALES DELIVERY ORDER
            query = String.Format("SELECT id_report_status,pl_sales_order_del_number as report_number FROM tb_pl_sales_order_del WHERE id_pl_sales_order_del = '{0}'", id_report)
        ElseIf report_mark_type = "44" Then
            'Mat MRS
            query = String.Format("SELECT id_report_status FROM tb_prod_order_mrs WHERE id_prod_order_mrs = '{0}'", id_report)
        ElseIf report_mark_type = "45" Or report_mark_type = "119" Then
            'SALES RETURN ORDER
            query = String.Format("SELECT id_report_status, sales_return_order_number AS report_number FROM tb_sales_return_order WHERE id_sales_return_order = '{0}'", id_report)
        ElseIf report_mark_type = "46" Or report_mark_type = "111" Or report_mark_type = "113" Or report_mark_type = "120" Then
            'SALES RETURN
            query = String.Format("SELECT id_report_status,sales_return_number as report_number FROM tb_sales_return WHERE id_sales_return = '{0}'", id_report)
        ElseIf report_mark_type = "47" Then
            'Mat return Prod
            query = String.Format("SELECT id_report_status,mat_prod_ret_in_number as report_number FROM tb_mat_prod_ret_in WHERE id_mat_prod_ret_in = '{0}'", id_report)
        ElseIf report_mark_type = "48" Or report_mark_type = "183" Then
            'SALES VIRTUAL POS
            query = String.Format("SELECT id_report_status,sales_pos_number as report_number FROM tb_sales_pos WHERE id_sales_pos = '{0}'", id_report)
        ElseIf report_mark_type = "49" Or report_mark_type = "106" Then
            'SALES RETURN QC
            query = String.Format("SELECT id_report_status,sales_return_qc_number as report_number FROM tb_sales_return_qc WHERE id_sales_return_qc = '{0}'", id_report)
        ElseIf report_mark_type = "50" Then
            'PR Prod Order
            query = String.Format("SELECT id_report_status,pr_prod_order_number as report_number FROM tb_pr_prod_order WHERE id_pr_prod_order = '{0}'", id_report)
        ElseIf report_mark_type = "51" Then
            'SALES INVOICE
            query = String.Format("SELECT id_report_status,sales_invoice_number as report_number FROM tb_sales_invoice WHERE id_sales_invoice = '{0}'", id_report)
        ElseIf report_mark_type = "52" Then
            'Stok Opname mat
            query = String.Format("SELECT id_report_status,mat_so_number as report_number FROM tb_mat_so WHERE id_mat_so = '{0}'", id_report)
        ElseIf report_mark_type = "53" Then
            'FG SO STORE
            query = String.Format("SELECT id_report_status,fg_so_store_number as report_number FROM tb_fg_so_store WHERE id_fg_so_store = '{0}'", id_report)
        ElseIf report_mark_type = "54" Then
            'FG MISSING
            query = String.Format("SELECT id_report_status,sales_pos_number as report_number FROM tb_sales_pos WHERE id_sales_pos = '{0}'", id_report)
        ElseIf report_mark_type = "55" Then
            'FG MISSING INVOICE
            query = String.Format("SELECT id_report_status,fg_missing_invoice_number as report_number FROM tb_fg_missing_invoice WHERE id_fg_missing_invoice = '{0}'", id_report)
        ElseIf report_mark_type = "56" Then
            'FG SO WH
            query = String.Format("SELECT id_report_status,fg_so_wh_number as report_number FROM tb_fg_so_wh WHERE id_fg_so_wh = '{0}'", id_report)
        ElseIf report_mark_type = "57" Then
            'FG TRF
            query = String.Format("SELECT id_report_status,fg_trf_number as report_number FROM tb_fg_trf WHERE id_fg_trf = '{0}'", id_report)
        ElseIf report_mark_type = "58" Then
            'FG TRF REC
            query = String.Format("SELECT (id_report_status_rec) AS id_report_status,fg_trf_number as report_number FROM tb_fg_trf WHERE id_fg_trf = '{0}'", id_report)
        ElseIf report_mark_type = "60" Then
            'SAMPLE DEL
            query = String.Format("SELECT id_report_status, sample_del_number as report_number FROM tb_sample_del WHERE id_sample_del = '{0}'", id_report)
        ElseIf report_mark_type = "61" Then
            'SAMPLE DEL REC
            query = String.Format("SELECT id_report_status, sample_del_rec_number as report_number FROM tb_sample_del_rec WHERE id_sample_del_rec = '{0}'", id_report)
        ElseIf report_mark_type = "62" Then
            'SO SAMPLE
            query = String.Format("SELECT id_report_status, sample_order_number as report_number FROM tb_sample_order WHERE id_sample_order = '{0}'", id_report)
        ElseIf report_mark_type = "63" Then
            'DELIVERY ORDER SAMPLE FOR SALES
            query = String.Format("SELECT id_report_status, pl_sample_order_del_number as report_number FROM tb_pl_sample_order_del WHERE id_pl_sample_order_del = '{0}'", id_report)
        ElseIf report_mark_type = "64" Then
            'SAMPLE SO
            query = String.Format("SELECT id_report_status, sample_so_number as report_number FROM tb_sample_so WHERE id_sample_so = '{0}'", id_report)
        ElseIf report_mark_type = "65" Then
            'FG CODE REPLACEMENT STORE
            query = String.Format("SELECT id_report_status, fg_code_replace_store_number as report_number FROM tb_fg_code_replace_store WHERE id_fg_code_replace_store = '{0}'", id_report)
        ElseIf report_mark_type = "66" Or report_mark_type = "118" Then
            'SALES CREDIT NOTE
            query = String.Format("SELECT id_report_status,sales_pos_number as report_number FROM tb_sales_pos WHERE id_sales_pos = '{0}'", id_report)
        ElseIf report_mark_type = "67" Then
            'MISSING CREDIT NOTE STORE
            query = String.Format("SELECT id_report_status,sales_pos_number as report_number FROM tb_sales_pos WHERE id_sales_pos = '{0}'", id_report)
        ElseIf report_mark_type = "68" Then
            'FG CODE REPLACEMENT WH
            query = String.Format("SELECT id_report_status, fg_code_replace_wh_number as report_number FROM tb_fg_code_replace_wh WHERE id_fg_code_replace_wh = '{0}'", id_report)
        ElseIf report_mark_type = "69" Then
            'FG Write Off
            query = String.Format("SELECT id_report_status,fg_woff_number as report_number FROM tb_fg_woff WHERE id_fg_woff = '{0}'", id_report)
        ElseIf report_mark_type = "70" Then
            'FG PROPOSE PRICE
            query = String.Format("SELECT id_report_status,fg_propose_price_number as report_number FROM tb_fg_propose_price WHERE id_fg_propose_price = '{0}'", id_report)
        ElseIf report_mark_type = "72" Then
            'QC Adj In
            query = String.Format("SELECT id_report_status,prod_order_qc_adj_in_number as report_number FROM tb_prod_order_qc_adj_in WHERE id_prod_order_qc_adj_in = '{0}'", id_report)
        ElseIf report_mark_type = "73" Then
            'QC Adj Out
            query = String.Format("SELECT id_report_status,prod_order_qc_adj_out_number as report_number FROM tb_prod_order_qc_adj_out WHERE id_prod_order_qc_adj_out = '{0}'", id_report)
        ElseIf report_mark_type = "75" Then
            'ANALISIS NEW PRODUK
            query = String.Format("SELECT id_report_status,fg_so_reff_number as report_number FROM tb_fg_so_reff WHERE id_fg_so_reff = '{0}'", id_report)
        ElseIf report_mark_type = "76" Then
            'Promo
            query = String.Format("SELECT id_report_status,sales_pos_number as report_number FROM tb_sales_pos WHERE id_sales_pos = '{0}'", id_report)
        ElseIf report_mark_type = "79" Then
            'BOM Approve
            query = String.Format("SELECT id_report_status,'-' as report_number FROM tb_bom_approve WHERE id_bom_approve = '{0}'", id_report)
        ElseIf report_mark_type = "82" Then
            'PRICE EXCEL
            query = String.Format("SELECT id_report_status,fg_price_number as report_number FROM tb_fg_price WHERE id_fg_price = '{0}'", id_report)
        ElseIf report_mark_type = "85" Then
            'SAMPLE PL
            query = String.Format("SELECT id_report_status,sample_pl_number as report_number FROM tb_sample_pl WHERE id_sample_pl = '{0}'", id_report)
        ElseIf report_mark_type = "86" Then
            'PRICE SAMPLE EXCEL
            query = String.Format("SELECT id_report_status,sample_price_number as report_number FROM tb_sample_price WHERE id_sample_price = '{0}'", id_report)
        ElseIf report_mark_type = "87" Then
            'INVENTORY ALLOCATION
            query = String.Format("SELECT id_report_status, fg_wh_alloc_number as report_number FROM tb_fg_wh_alloc WHERE id_fg_wh_alloc = '{0}'", id_report)
        ElseIf report_mark_type = "88" Then
            'GENERATE SO
            query = String.Format("SELECT id_report_status, sales_order_gen_reff as report_number FROM tb_sales_order_gen WHERE id_sales_order_gen = '{0}'", id_report)
        ElseIf report_mark_type = "89" Then
            'Receive local sample
            query = String.Format("SELECT id_report_status, sample_pl_ret_number as report_number FROM tb_sample_pl_ret WHERE id_sample_pl_ret = '{0}'", id_report)
        ElseIf report_mark_type = "91" Or report_mark_type = "140" Then
            'REPAIR
            query = String.Format("SELECT id_report_status, fg_repair_number as report_number FROM tb_fg_repair WHERE id_fg_repair = '{0}'", id_report)
        ElseIf report_mark_type = "92" Then
            'REPAIR REC
            query = String.Format("SELECT id_report_status, fg_repair_rec_number as report_number FROM tb_fg_repair_rec WHERE id_fg_repair_rec = '{0}'", id_report)
        ElseIf report_mark_type = "93" Or report_mark_type = "141" Then
            'REPAIR RETURN
            query = String.Format("SELECT id_report_status, fg_repair_return_number as report_number FROM tb_fg_repair_return WHERE id_fg_repair_return = '{0}'", id_report)
        ElseIf report_mark_type = "94" Then
            'REPAIR RETURN REC
            query = String.Format("SELECT id_report_status, fg_repair_return_rec_number as report_number FROM tb_fg_repair_return_rec WHERE id_fg_repair_return_rec = '{0}'", id_report)
        ElseIf report_mark_type = "95" Or report_mark_type = "164" Or report_mark_type = "165" Then
            'Leave Propose
            query = String.Format("SELECT id_report_status, emp_leave_number as report_number FROM tb_emp_leave WHERE id_emp_leave = '{0}'", id_report)
        ElseIf report_mark_type = "96" Then
            'Leave Propose need management approval
            query = String.Format("SELECT id_report_status, emp_leave_number as report_number FROM tb_emp_leave WHERE id_emp_leave = '{0}'", id_report)
        ElseIf report_mark_type = "97" Then
            'DP propose
            query = String.Format("SELECT id_report_status, dp_number as report_number FROM tb_emp_dp WHERE id_dp = '{0}'", id_report)
        ElseIf report_mark_type = "98" Then
            'Employee Change Schedule
            query = String.Format("SELECT id_report_status, emp_ch_schedule_number as report_number FROM tb_emp_ch_schedule WHERE id_emp_ch_schedule = '{0}'", id_report)
        ElseIf report_mark_type = "99" Then
            'Leave Propose Admin Management
            query = String.Format("SELECT id_report_status, emp_leave_number as report_number FROM tb_emp_leave WHERE id_emp_leave = '{0}'", id_report)
        ElseIf report_mark_type = "100" Or report_mark_type = "240" Then
            'Schedule Propose With Approval
            query = String.Format("SELECT id_report_status, assign_sch_number as report_number FROM tb_emp_assign_sch WHERE id_assign_sch = '{0}'", id_report)
        ElseIf report_mark_type = "101" Then
            'Air Ways Bill
            query = String.Format("SELECT id_report_status, id_awbill as report_number FROM tb_wh_awbill WHERE id_awbill = '{0}'", id_report)
        ElseIf report_mark_type = "102" Then
            'Leave Propose HRD
            query = String.Format("SELECT id_report_status, emp_leave_number as report_number FROM tb_emp_leave WHERE id_emp_leave = '{0}'", id_report)
        ElseIf report_mark_type = "103" Then
            'combine ddel
            query = String.Format("SELECT id_report_status, combine_number as report_number FROM tb_pl_sales_order_del_combine WHERE id_combine = '{0}'", id_report)
        ElseIf report_mark_type = "104" Then
            'Leave Propose For Admin Manager
            query = String.Format("SELECT id_report_status, emp_leave_number as report_number FROM tb_emp_leave WHERE id_emp_leave = '{0}'", id_report)
        ElseIf report_mark_type = "105" Or report_mark_type = "224" Then
            'final clear
            query = String.Format("SELECT id_report_status, prod_fc_number as report_number FROM tb_prod_fc WHERE id_prod_fc = '{0}'", id_report)
        ElseIf report_mark_type = "107" Then
            'production assembly
            query = String.Format("SELECT id_report_status, prod_ass_number as report_number FROM tb_prod_ass WHERE id_prod_ass = '{0}'", id_report)
        ElseIf report_mark_type = "108" Then
            'Propose Leave (Staff-Supervisor KK Unit)
            query = String.Format("SELECT id_report_status, emp_leave_number as report_number FROM tb_emp_leave WHERE id_emp_leave = '{0}'", id_report)
        ElseIf report_mark_type = "109" Then
            'Propose Leave (Coord-Asst Mgr KK Unit)
            query = String.Format("SELECT id_report_status, emp_leave_number as report_number FROM tb_emp_leave WHERE id_emp_leave = '{0}'", id_report)
        ElseIf report_mark_type = "110" Then
            'Propose Leave (Manager KK Unit)
            query = String.Format("SELECT id_report_status, emp_leave_number as report_number FROM tb_emp_leave WHERE id_emp_leave = '{0}'", id_report)
        ElseIf report_mark_type = "111" Then
            'out non inventory
            query = String.Format("SELECT id_report_status, wh_del_empty_number as report_number FROM tb_wh_del_empty WHERE id_wh_del_empty = '{0}'", id_report)
        ElseIf report_mark_type = "116" Then
            'missing promo
            query = String.Format("SELECT id_report_status,sales_pos_number as report_number FROM tb_sales_pos WHERE id_sales_pos = '{0}'", id_report)
        ElseIf report_mark_type = "117" Then
            'missing staff
            query = String.Format("SELECT id_report_status,sales_pos_number as report_number FROM tb_sales_pos WHERE id_sales_pos = '{0}'", id_report)
        ElseIf report_mark_type = "123" Then
            'list uniform
            query = String.Format("SELECT ed.id_report_status,ep.period_name as report_number FROM tb_emp_uni_design ed INNER JOIN tb_emp_uni_period ep ON ep.id_emp_uni_period = ed.id_emp_uni_period WHERE ed.id_emp_uni_design = '{0}'", id_report)
        ElseIf report_mark_type = "124" Then
            'Propose Leave Admin Manager
            query = String.Format("SELECT id_report_status, emp_leave_number as report_number FROM tb_emp_leave WHERE id_emp_leave = '{0}'", id_report)
        ElseIf report_mark_type = "125" Then
            'Leave Cut
            query = String.Format("SELECT id_report_status, leave_cut_number as report_number FROM tb_emp_leave_cut WHERE id_leave_cut = '{0}'", id_report)
        ElseIf report_mark_type = "126" Then
            'over production memo
            query = String.Format("SELECT id_report_status, memo_number as report_number FROM tb_prod_over_memo WHERE id_prod_over_memo = '{0}'", id_report)
        ElseIf report_mark_type = "128" Then
            'Asset PO
            query = String.Format("SELECT id_report_status, asset_po_no as report_number FROM tb_a_asset_po WHERE id_asset_po = '{0}'", id_report)
        ElseIf report_mark_type = "129" Then
            'Asset Rec
            query = String.Format("SELECT id_report_status, asset_rec_no as report_number FROM tb_a_asset_rec WHERE id_asset_rec = '{0}'", id_report)
        ElseIf report_mark_type = "132" Or report_mark_type = "236" Then
            'UNIFORM EXPENS & CREDIT NOTE
            query = String.Format("SELECT id_report_status,emp_uni_ex_number as report_number FROM tb_emp_uni_ex WHERE id_emp_uni_ex = '{0}'", id_report)
        ElseIf report_mark_type = "133" Then
            'REVENUE BUDGET
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_b_revenue_propose WHERE id_b_revenue_propose = '{0}'", id_report)
        ElseIf report_mark_type = "134" Then
            'PROPOSE NEW ITEM CAT
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_item_cat_propose WHERE id_item_cat_propose = '{0}'", id_report)
        ElseIf report_mark_type = "135" Then
            'PROPOSE NEW COA
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_item_coa_propose WHERE id_item_coa_propose = '{0}'", id_report)
        ElseIf report_mark_type = "136" Then
            'EXPENSE BUDGET
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_b_expense_propose WHERE id_b_expense_propose = '{0}'", id_report)
        ElseIf report_mark_type = "137" Or report_mark_type = "201" Or report_mark_type = "218" Then
            'Purchase Request
            query = String.Format("SELECT id_report_status,purc_req_number as report_number FROM tb_purc_req WHERE id_purc_req = '{0}'", id_report)
        ElseIf report_mark_type = "138" Then
            'EXPENSE BUDGET
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_b_expense_revision WHERE id_b_expense_revision = '{0}'", id_report)
        ElseIf report_mark_type = "139" Or report_mark_type = "202" Then
            'Purchase Order
            query = String.Format("SELECT id_report_status,purc_order_number as report_number FROM tb_purc_order WHERE id_purc_order = '{0}'", id_report)
        ElseIf report_mark_type = "143" Or report_mark_type = "144" Or report_mark_type = "145" Or report_mark_type = "194" Or report_mark_type = "210" Then
            'PD REVISION
            query = String.Format("SELECT tb_prod_demand_rev.id_report_status,CONCAT(tb_prod_demand.prod_demand_number,'/REV ', tb_prod_demand_rev.rev_count) as report_number FROM tb_prod_demand_rev INNER JOIN tb_prod_demand ON tb_prod_demand.id_prod_demand = tb_prod_demand_rev.id_prod_demand WHERE id_prod_demand_rev = '{0}'", id_report)
        ElseIf report_mark_type = "142" Then
            'Cancel Report
            query = String.Format("SELECT id_report_status,id_report_mark_cancel as report_number FROM tb_report_mark_cancel WHERE id_report_mark_cancel = '{0}'", id_report)
        ElseIf report_mark_type = "147" Then
            ' REVENUE BUDGET REVISION
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_b_revenue_revision WHERE id_b_revenue_revision = '{0}'", id_report)
        ElseIf report_mark_type = "148" Then
            'Purchase receive non aseet
            query = String.Format("SELECT id_report_status,purc_rec_number as report_number FROM tb_purc_rec WHERE id_purc_rec = '{0}'", id_report)
        ElseIf report_mark_type = "150" Or report_mark_type = "155" Or report_mark_type = "172" Or report_mark_type = "173" Then
            ' Propose COP
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_design_cop_propose WHERE id_design_cop_propose = '{0}'", id_report)
        ElseIf report_mark_type = "151" Then
            'claim return
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_prod_claim_return WHERE id_prod_claim_return = '{0}'", id_report)
        ElseIf report_mark_type = "152" Then
            ''Purchase Return
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_purc_return WHERE id_purc_return = '{0}'", id_report)
        ElseIf report_mark_type = "153" Then
            'Propose company
            query = String.Format("SELECT id_report_status,comp_name as report_number FROM tb_m_comp WHERE id_comp = '{0}'", id_report)
        ElseIf report_mark_type = "154" Or report_mark_type = "163" Then
            'Item request
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_item_req WHERE id_item_req = '{0}'", id_report)
        ElseIf report_mark_type = "156" Or report_mark_type = "166" Then
            'Item del
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_item_del WHERE id_item_del = '{0}'", id_report)
        ElseIf report_mark_type = "157" Then
            'expense
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_item_expense WHERE id_item_expense = '{0}'", id_report)
        ElseIf report_mark_type = "158" Then
            'NO STOCJ
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_sales_pos_no_stock WHERE id_sales_pos_no_stock = '{0}'", id_report)
        ElseIf report_mark_type = "159" Then
            'Payment
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_pn WHERE id_pn = '{0}'", id_report)
        ElseIf report_mark_type = "160" Or report_mark_type = "169" Then
            'Aset Management
            query = String.Format("SELECT id_report_status,asset_number as report_number FROM tb_purc_rec_asset WHERE id_purc_rec_asset = '{0}'", id_report)
        ElseIf report_mark_type = "162" Then
            'Receive Payment (Bank Deposit/BBM)
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_rec_payment WHERE id_rec_payment = '{0}'", id_report)
        ElseIf report_mark_type = "237" Then
            'Tabungan Missing
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_missing_payment WHERE id_missing_payment = '{0}'", id_report)
        ElseIf report_mark_type = "167" Then
            'cash advance
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_cash_advance WHERE id_cash_advance = '{0}'", id_report)
        ElseIf report_mark_type = "168" Then
            'Receive Return
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_sales_return_rec WHERE id_sales_return_rec = '{0}'", id_report)
        ElseIf report_mark_type = "170" Then
            'approve us
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_m_design_approve_us WHERE id_design_approve_us = '{0}'", id_report)
        ElseIf report_mark_type = "174" Then
            'cash advance reconcile
            query = String.Format("SELECT rb_id_report_status as id_report_status,number as report_number FROM tb_cash_advance WHERE id_cash_advance = '{0}'", id_report)
        ElseIf report_mark_type = "175" Then
            'Sample Budget Propose
            query = String.Format("SELECT id_report_status as id_report_status,number as report_number FROM tb_sample_budget_pps WHERE id_sample_budget_pps = '{0}'", id_report)
        ElseIf report_mark_type = "176" Or report_mark_type = "177" Or report_mark_type = "178" Then
            'propose design changes
            query = String.Format("SELECT id_report_status, number as report_number FROM tb_m_design_rev WHERE id_design_rev = '{0}'", id_report)
        ElseIf report_mark_type = "180" Then
            'propose employee changes
            query = String.Format("SELECT id_report_status, number as report_number FROM tb_employee_pps WHERE id_employee_pps = '{0}'", id_report)
        ElseIf report_mark_type = "184" Or report_mark_type = "213" Or report_mark_type = "214" Or report_mark_type = "219" Or report_mark_type = "220" Then
            'overtime
            query = String.Format("SELECT id_report_status, number as report_number FROM tb_ot WHERE id_ot = '{0}'", id_report)
        ElseIf report_mark_type = "185" Then
            'sample purchase close
            query = String.Format("SELECT id_report_status, number as report_number FROM tb_sample_purc_close WHERE id_ot = '{0}'", id_report)
        ElseIf report_mark_type = "187" Or report_mark_type = "215" Or report_mark_type = "216" Then
            'overtime report
            query = String.Format("SELECT vr.id_report_status, ot.number FROM tb_ot_verification AS vr LEFT JOIN tb_ot AS ot ON vr.id_ot = ot.id_ot WHERE id_ot_verification = '{0}'", id_report)
        ElseIf report_mark_type = "188" Then
            'propose price new product-revision
            query = String.Format("SELECT tb_fg_propose_price_rev.id_report_status AS id_report_status, CONCAT(tb_fg_propose_price.fg_propose_price_number,'/REV ', tb_fg_propose_price_rev.rev_count) as report_number 
            FROM tb_fg_propose_price_rev 
            INNER JOIN tb_fg_propose_price ON tb_fg_propose_price.id_fg_propose_price = tb_fg_propose_price_rev.id_fg_propose_price
            WHERE id_fg_propose_price_rev = '{0}'", id_report)
        ElseIf report_mark_type = "189" Then
            'Invoice FGPO
            query = String.Format("SELECT id_report_status, number as report_number FROM tb_pn_fgpo WHERE id_pn_fgpo = '{0}'", id_report)
        ElseIf report_mark_type = "190" Or report_mark_type = "193" Then
            'work order MTC/IT
            query = String.Format("SELECT id_report_status, number as report_number FROM tb_work_order WHERE id_work_order = '{0}'", id_report)
        ElseIf report_mark_type = "192" Then
            'payroll
            query = String.Format("SELECT id_report_status, report_number FROM tb_emp_payroll WHERE id_payroll = '{0}'", id_report)
        ElseIf report_mark_type = "179" Then
            'sample material purchase
            query = String.Format("SELECT id_report_status, number AS report_number FROM tb_sample_po_mat WHERE id_sample_po_mat = '{0}'", id_report)
        ElseIf report_mark_type = "197" Or report_mark_type = "229" Then
            'propose employee salary
            query = String.Format("SELECT id_report_status, number as report_number FROM tb_employee_sal_pps WHERE id_employee_sal_pps = '{0}'", id_report)
        ElseIf report_mark_type = "200" Then
            'design changes
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_m_design_changes WHERE id_changes = '{0}'", id_report)
        ElseIf report_mark_type = "203" Or report_mark_type = "204" Then
            'OPEX Budget Propose
            query = String.Format("SELECT id_report_status as id_report_status,number as report_number FROM tb_b_opex_pps WHERE id_b_opex_pps = '{0}'", id_report)
        ElseIf report_mark_type = "207" Then
            'PROPOSE MAIN CATEGORY
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_item_cat_main_pps WHERE id_item_cat_main_pps = '{0}'", id_report)
        ElseIf report_mark_type = "208" Or report_mark_type = "209" Then
            'OPEX Budget Propose
            query = String.Format("SELECT id_report_status as id_report_status,number as report_number FROM tb_b_expense_propose WHERE id_b_expense_propose = '{0}'", id_report)
        ElseIf report_mark_type = "211" Then
            'input attendance
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_emp_attn_input WHERE id_emp_attn_input = '{0}'", id_report)
        ElseIf report_mark_type = "212" Then
            'fgpo closing
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_prod_order_close WHERE id_prod_order_close = '{0}'", id_report)
        ElseIf report_mark_type = "221" Then
            'Debit Note
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_debit_note WHERE id_debit_note = '{0}'", id_report)
        ElseIf report_mark_type = "223" Then
            'bpjs kesehatan
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_pay_bpjs_kesehatan WHERE id_pay_bpjs_kesehatan = '{0}'", id_report)
        ElseIf report_mark_type = "222" Then
            'summary qc report
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_prod_fc_sum WHERE id_prod_fc_sum = '{0}'", id_report)
        ElseIf report_mark_type = "231" Then
            'invoice mat
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_inv_mat WHERE id_inv_mat = '{0}'", id_report)
        ElseIf report_mark_type = "233" Then
            'delay payment
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_propose_delay_payment WHERE id_propose_delay_payment = '{0}'", id_report)
        ElseIf report_mark_type = "234" Then
            'follow up recap
            query = String.Format("SELECT id_report_status,'' as report_number FROM tb_follow_up_recap WHERE id_follow_up_recap = '{0}'", id_report)
        ElseIf report_mark_type = "242" Then
            'cash advance cancel
            query = String.Format("SELECT id_report_status,(SELECT number FROM tb_cash_advance WHERE id_cash_advance = {0}) as report_number FROM tb_cash_advance_cancel WHERE id_cash_advance = '{1}'", id_report, id_report)
        ElseIf report_mark_type = "243" Then
            'pre return
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_ol_store_ret WHERE id_ol_store_ret = '{0}'", id_report)
        ElseIf report_mark_type = "245" Then
            'return customer
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_ol_store_cust_ret WHERE id_ol_store_cust_ret = '{0}'", id_report)
        ElseIf report_mark_type = "246" Then
            'return request
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_ol_store_ret_req WHERE id_ol_store_ret_req = '{0}'", id_report)
        ElseIf report_mark_type = "250" Then
            'propose promo collection
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_ol_promo_collection WHERE id_ol_promo_collection = '{0}'", id_report)
        ElseIf report_mark_type = "251" Or report_mark_type = "285" Then
            'bbk summary
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_pn_summary WHERE id_pn_summary = '{0}'", id_report)
        ElseIf report_mark_type = "254" Or report_mark_type = "256" Then
            ' sales volcom store
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_sales_branch WHERE id_sales_branch = '{0}'", id_report)
        ElseIf report_mark_type = "259" Then
            'close receiving
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_purc_order_close WHERE id_close_receiving = '{0}'", id_report)
        ElseIf report_mark_type = "260" Then
            'move est. date receive
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_purc_order_move_date WHERE id_receive_date = '{0}'", id_report)
        ElseIf report_mark_type = "264" Then
            'rekonsil payout
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_list_payout_trans WHERE id_list_payout_trans = '{0}'", id_report)
        ElseIf report_mark_type = "265" Then
            'rekonsil payout VA
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_virtual_acc_trans WHERE id_virtual_acc_trans = '{0}'", id_report)
        ElseIf report_mark_type = "268" Then
            'WIP Stock Summary Report
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_wip_summary WHERE id_wip_summary = '{0}'", id_report)
        ElseIf report_mark_type = "269" Then
            'Material & Trims Stock Summary Report
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_mat_summary WHERE id_mat_summary = '{0}'", id_report)
        ElseIf report_mark_type = "270" Then
            'propose ECOP
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_design_ecop_pps WHERE id_design_ecop_pps = '{0}'", id_report)
        ElseIf report_mark_type = "273" Then
            'propose material
            query = String.Format("SELECT id_report_status,mat_det_code as report_number FROM tb_m_mat_det_pps WHERE id_mat_det_pps = '{0}'", id_report)
        ElseIf report_mark_type = "280" Then
            'Invoice claim lain-lain
            query = String.Format("SELECT id_report_status,number as report_number FROM tb_inv_claim_other WHERE id_inv_claim_other = '{0}'", id_report)
        ElseIf report_mark_type = "241" Then
            'adj og
            query = String.Format("SELECT id_report_status, number as report_number FROM tb_adjustment_og WHERE id_adjustment = '{0}'", id_report)
        ElseIf report_mark_type = "281" Then
            'price recon
            query = String.Format("SELECT id_report_status, number as report_number FROM tb_sales_pos_recon WHERE id_sales_pos_recon = '{0}'", id_report)
        ElseIf report_mark_type = "282" Then
            'payout zalora
            query = String.Format("SELECT id_report_status, statement_number as report_number FROM tb_payout_zalora WHERE id_payout_zalora = '{0}'", id_report)
        ElseIf report_mark_type = "283" Then
            'closing no stok
            query = String.Format("SELECT id_report_status, number as report_number FROM tb_sales_pos_oos_recon WHERE id_sales_pos_oos_recon = '{0}'", id_report)
        ElseIf report_mark_type = "287" Then
            'Depresiasi
            query = String.Format("SELECT id_report_status, number as report_number FROM tb_asset_dep_pps WHERE id_asset_dep_pps = '{0}'", id_report)
        ElseIf report_mark_type = "284" Then
            'Summary Tax Report
            query = String.Format("SELECT id_report_status, number as report_number FROM tb_tax_pph_summary WHERE id_summary = '{0}'", id_report)
        ElseIf report_mark_type = "288" Then
            'Setup Tax
            query = String.Format("SELECT id_report_status, number as report_number FROM tb_setup_tax_installment WHERE id_setup_tax = '{0}'", id_report)
        ElseIf report_mark_type = "289" Then
            'Asset In Out
            query = String.Format("SELECT id_report_status, number as report_number FROM tb_item_card_trs WHERE id_item_card_trs = '{0}'", id_report)
        ElseIf report_mark_type = "290" Then
            'REFUSE RETURB ONLINE
            query = String.Format("SELECT id_report_status, number as report_number FROM tb_ol_store_return_refuse WHERE id_return_refuse = '{0}'", id_report)
        ElseIf report_mark_type = "292" Then
            'CANCEL CN
            query = String.Format("SELECT id_report_status,sales_pos_number as report_number FROM tb_sales_pos WHERE id_sales_pos = '{0}'", id_report)
        ElseIf report_mark_type = "293" Then
            'Summary Tax Report
            query = String.Format("SELECT id_report_status, number as report_number FROM tb_tax_ppn_summary WHERE id_summary = '{0}'", id_report)
        ElseIf report_mark_type = "294" Then
            'Alokasi bulanan
            query = String.Format("SELECT id_report_status, number as report_number FROM tb_biaya_sewa_bulanan WHERE id_biaya_sewa_bulanan = '{0}'", id_report)
        ElseIf report_mark_type = "295" Then
            'Master Alokasi bulanan
            query = String.Format("SELECT id_report_status, number as report_number FROM tb_biaya_sewa_pps WHERE id_biaya_sewa_pps = '{0}'", id_report)
        ElseIf report_mark_type = "298" Then
            'Fixed Asset sell / drop
            query = String.Format("SELECT id_report_status, number as report_number FROM tb_purc_rec_asset_disp WHERE id_purc_rec_asset_disp = '{0}'", id_report)
        ElseIf report_mark_type = "299" Then
            'Weight PPS
            query = String.Format("SELECT id_report_status, number as report_number FROM tb_product_weight_pps WHERE id_product_weight_pps = '{0}'", id_report)
        ElseIf report_mark_type = "300" Then
            'foc og
            query = String.Format("SELECT id_report_status, purc_rec_foc_number as report_number FROM tb_purc_rec_foc WHERE id_purc_rec_foc = '{0}'", id_report)
        End If
        data = execute_query(query, -1, True, "", "", "", "")

        LEReportStatus.EditValue = Nothing
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        id_report_status_report = data.Rows(0)("id_report_status").ToString
        Try
            report_number = data.Rows(0)("report_number").ToString
        Catch ex As Exception
        End Try
        'if canceled
        If data.Rows(0)("id_report_status").ToString = "5" Or data.Rows(0)("id_report_status").ToString = "6" Then
            LEReportStatus.Enabled = False
            BSetStatus.Visible = False
            BLeadTime.Visible = False
            BClearLeadTime.Visible = False
            '
            BReset.Visible = False
        Else
            If is_disabled_set_stt = "-1" Then
                LEReportStatus.Enabled = True
            End If
            BSetStatus.Visible = True
            BLeadTime.Visible = True
            BClearLeadTime.Visible = True
            '
            BReset.Visible = True
        End If
        ''cancel approval
        ''Cancel button : if there is no mark, dont show it, if someone already mark, show it.
        'Dim query_check As String = "SELECT * FROM tb_report_mark WHERE id_report='" & id_report & "' AND report_mark_type='" & report_mark_type & "' AND id_mark=2"
        'Dim data_check As DataTable = execute_query(query_check, -1, True, "", "", "", "")
        'If data_check.Rows.Count > 0 Then
        '    'check if form cancel already created
        '    Dim query_cancel As String = "SELECT rmc.*,emp.employee_name FROM tb_report_mark_cancel rmc
        '                                    LEFT JOIN tb_m_user usr ON usr.id_user=rmc.created_by
        '                                    LEFT JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
        '                                    WHERE rmc.id_report='" & id_report & "' AND rmc.report_mark_type='" & report_mark_type & "'"
        '    Dim data_cancel As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
        '    If data_cancel.Rows.Count > 0 Then
        '        BCancel.Visible = False
        '        XTPCancel.PageVisible = True
        '        'fill it
        '        If data_cancel.Rows(0)("created_by").ToString = "" Then
        '            TECancelCreatedBy.Text = name_user
        '            DECancelCreated.EditValue = Now()
        '        Else
        '            TECancelCreatedBy.Text = data_cancel.Rows(0)("employee_name").ToString
        '            DECancelCreated.EditValue = data_cancel.Rows(0)("created_datetime")
        '            MEReason.Text = data_cancel.Rows(0)("reason").ToString
        '            id_report_mark_cancel = data_cancel.Rows(0)("id_report_mark_cancel").ToString
        '            If data_cancel.Rows(0)("is_submit").ToString = "1" Then
        '                BSubmit.Text = "Print"
        '            Else
        '                BSubmit.Text = "Submit"
        '            End If
        '            '
        '            Dim query_cancel_user As String = "SELECT emp.`employee_name`,rmc_usr.`approve_datetime`,IF(rmc_usr.is_approve='1','Approved','No Action') AS is_approve FROM `tb_report_mark_cancel_user` rmc_usr
        '                                                INNER JOIN tb_m_employee emp ON emp.`id_employee`=rmc_usr.`id_employee`
        '                                                WHERE rmc_usr.id_report_mark_cancel='" & id_report_mark_cancel & "'"
        '            Dim data_cancel_user As DataTable = execute_query(query_cancel_user, -1, True, "", "", "", "")
        '            GCCancel.DataSource = data_cancel_user
        '            '
        '            '
        '        End If
        '    Else
        '        BCancel.Visible = True
        '        XTPCancel.PageVisible = False
        '    End If
        'Else
        '    BCancel.Visible = False
        '    XTPCancel.PageVisible = False
        'End If
    End Sub
    Sub view_mark()
        Dim query As String = "SELECT IF(a.is_requisite='2','no','yes') AS is_requisite, a.is_need_print, a.is_need_upload,a.id_report,a.report_mark_type,emp.employee_name,a.id_mark,a.id_mark_asg,a.id_report_status,a.report_mark_note,a.id_report_mark,b.report_status,a.id_user,IF(a.id_report_status=1,'Submitted',IF(e.`id_mark`=2,b.report_status,e.`mark`)) AS mark,CONCAT_WS(' ',DATE_FORMAT(a.report_mark_datetime,'%d %M %Y'),TIME(a.report_mark_datetime)) AS date_time,a.report_mark_note,a.is_use
                            ,CONCAT_WS(' ',DATE_FORMAT(a.report_mark_start_datetime,'%d %M %Y'),TIME(a.report_mark_start_datetime)) AS date_time_start
                            ,CONCAT_WS(' ',DATE_FORMAT((ADDTIME(report_mark_start_datetime,report_mark_lead_time)),'%d %M %Y'),TIME((ADDTIME(report_mark_start_datetime,report_mark_lead_time)))) AS lead_time
                            ,CONCAT_WS(' ',DATE(ADDTIME(report_mark_start_datetime,report_mark_lead_time)),TIME((ADDTIME(report_mark_start_datetime,report_mark_lead_time)))) AS raw_lead_time
                            ,CONCAT(a.id_report_status,LPAD(a.id_mark_asg,6,0))  as id_sort
                            FROM tb_report_mark a
                            INNER JOIN tb_lookup_report_status b ON a.id_report_status=b.id_report_status
                            LEFT JOIN tb_m_user c ON a.id_user=c.id_user
                            LEFT JOIN tb_m_employee d ON d.id_employee=c.id_employee
                            LEFT JOIN tb_m_employee emp ON emp.id_employee=a.id_employee
                            INNER JOIN tb_lookup_mark e ON e.id_mark=a.id_mark
                            WHERE a.report_mark_type='" & report_mark_type & "' AND a.id_report='" & id_report & "'
                            ORDER BY a.id_report_status,a.level"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMark.DataSource = data
        GVMark.ExpandAllGroups()
        If data.Rows.Count < 1 Then
            BLeadTime.Visible = False
        Else
            BLeadTime.Visible = True
        End If

        'Check Edit
        Dim id_rep_status As String = GVMark.GetFocusedRowCellDisplayText("id_report_status").ToString
        If report_mark_type = "11" Then
            If form_origin = "FormSampleReqSingle" Then
                FormSampleReqSingle.action = "upd"
                FormSampleReqSingle.id_report_status = id_rep_status
                FormSampleReqSingle.actionLoad()
            Else

            End If
        End If
    End Sub

    Sub view_mark_final()
        Dim query As String = "SELECT fnl.id_final_comment, rs.id_report_status, fnl.report_mark_type, fnl.id_report, rs.report_status,  "
        query += "emp.employee_name, fnl.final_comment,  "
        query += "CONCAT_WS(' ',DATE_FORMAT(fnl.final_comment_date,'%d %M %Y'),TIME(fnl.final_comment_date)) AS `final_date`  "
        query += "FROM tb_report_mark_final_comment fnl  "
        query += "INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = fnl.id_report_status  "
        query += "INNER JOIN tb_m_user usr ON usr.id_user = fnl.id_user  "
        query += "INNER JOIN tb_m_employee emp ON emp.id_employee = usr.id_employee  "
        query += "WHERE fnl.id_report='" + id_report + "' AND fnl.report_mark_type='" + report_mark_type + "'  "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFinal.DataSource = data
        GVFinal.ExpandAllGroups()
    End Sub

    Function check_available(ByVal id_report_markx As String)
        Dim result As Boolean = False
        Dim id_report_statusx As String = "-1"
        Dim id_userx As String = "-1"

        Dim query As String = String.Format("SELECT id_user,id_report_status FROM tb_report_mark WHERE id_report_mark = '{0}'", id_report_markx)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        ' going to marked
        id_report_statusx = data.Rows(0)("id_report_status").ToString
        id_userx = data.Rows(0)("id_user").ToString
        '
        If id_userx = id_user And check_available_asg(id_report_markx) Then
            Dim query_jml As String = String.Format("SELECT count(id_report_mark) FROM tb_report_mark WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status < '{2}' AND id_mark != '2' AND is_use='1' AND id_report_mark!='{3}'", report_mark_type, id_report, id_report_statusx, id_report_markx)
            Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
            If jml < 1 Then
                result = True
            End If
        End If

        Return result
    End Function
    Function check_available_asg(ByVal id_report_markx As String)
        Dim result As Boolean = False
        Dim id_report_statusx As String = "-1"

        Dim query As String = "SELECT id_report,id_mark_asg,report_mark_type FROM tb_report_mark WHERE id_report_mark='" & id_report_markx & "' LIMIT 1"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        Dim id_mark_asg, id_report, report_mark_type As String

        id_mark_asg = data.Rows(0)("id_mark_asg").ToString()
        id_report = data.Rows(0)("id_report").ToString()
        report_mark_type = data.Rows(0)("report_mark_type").ToString()

        Dim query_jml As String = String.Format("SELECT count(id_report_mark) FROM tb_report_mark WHERE report_mark_type='{0}' AND id_report='{1}' AND id_mark_asg='{2}' AND id_mark != '1' AND is_use='1' AND id_report_mark!='{3}'", report_mark_type, id_report, id_mark_asg, id_report_markx)
        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If jml < 1 Then
            result = True
        End If

        Return result
    End Function
    Function check_available_asg_color(ByVal id_report_markx As String)
        Dim result As Boolean = False
        Dim id_report_statusx As String = "-1"

        Dim query As String = "SELECT id_report,id_mark_asg,report_mark_type FROM tb_report_mark WHERE id_report_mark='" & id_report_markx & "' LIMIT 1"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        Dim id_mark_asg, id_report, report_mark_type As String

        id_mark_asg = data.Rows(0)("id_mark_asg").ToString()
        id_report = data.Rows(0)("id_report").ToString()
        report_mark_type = data.Rows(0)("report_mark_type").ToString()

        Dim query_jml As String = String.Format("SELECT count(id_report_mark) FROM tb_report_mark WHERE report_mark_type='{0}' AND id_report='{1}' AND id_mark_asg='{2}' AND id_mark != '1' AND is_use='1' ", report_mark_type, id_report, id_mark_asg, id_report_markx)
        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If jml < 1 Then
            result = True
        End If

        Return result
    End Function
    Function check_available_lead_time(ByVal id_report_markx As String)
        Dim result As Boolean = False
        Dim id_report_statusx As String = "-1"
        Dim id_userx As String = "-1"

        Dim query As String = String.Format("SELECT id_user,id_report_status FROM tb_report_mark WHERE id_report_mark = '{0}'", id_report_markx)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        ' going to marked
        id_report_statusx = data.Rows(0)("id_report_status").ToString
        Dim query_jml As String = String.Format("SELECT count(id_report_mark) FROM tb_report_mark WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status < '{2}' AND id_mark != '2' AND is_use='1'", report_mark_type, id_report, id_report_statusx)
        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If jml < 1 Then
            result = True
        End If

        Return result
    End Function
    Private Sub GVMark_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVMark.DoubleClick
        'MsgBox(id_report_status_report)
        If id_report_status_report.ToString <> "5" And id_report_status_report.ToString <> "6" Then
            If id_report_status_report >= GVMark.GetFocusedRowCellDisplayText("id_report_status").ToString Then
                stopCustom("This mark already locked.")
            Else
                If check_available(GVMark.GetFocusedRowCellDisplayText("id_report_mark").ToString) Then
                    'the user
                    'check if prerequisite already checked
                    Dim pass As String = "no"
                    Dim pass_need As String = "no"
                    If GVMark.GetFocusedRowCellValue("is_requisite").ToString = "no" Then
                        For i As Integer = 0 To (GVMark.RowCount - 1 - GetGroupRowCount(GVMark))
                            If GVMark.GetRowCellValue(i, "is_requisite").ToString = "yes" And GVMark.GetRowCellValue(i, "id_report_status").ToString = GVMark.GetFocusedRowCellDisplayText("id_report_status").ToString Then
                                pass_need = "yes"
                                If GVMark.GetRowCellValue(i, "id_mark").ToString = "2" Then
                                    pass = "yes"
                                End If
                            End If
                        Next
                    Else
                        pass_need = "no"
                    End If

                    If pass_need = "yes" And pass = "no" Then
                        stopCustom("There is mark need to approve first, please check again.")
                    Else
                        FormReportMarkDet.id_report_mark = GVMark.GetFocusedRowCellDisplayText("id_report_mark").ToString
                        FormReportMarkDet.ShowDialog()
                    End If
                Else
                    stopCustom("This mark not available." & vbNewLine & "Make sure : " & vbNewLine & "- You're the correct user." & vbNewLine & "- This mark not marked yet.")
                End If
            End If
        End If
    End Sub

    Private Sub GVMark_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMark.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub FormReportMark_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Close()
    End Sub

    Private Sub BSetStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSetStatus.Click
        Cursor = Cursors.WaitCursor
        Dim id_status_reportx As String = LEReportStatus.EditValue
        Dim query As String = ""
        Dim assigned As Boolean = False
        'check
        Dim query_jml As String
        Dim jml As Integer
        If Not id_status_reportx = id_report_status_report Then
            If id_status_reportx = "6" Or id_status_reportx = "4" Then
                'completed or processed
                assigned = True
                query_jml = String.Format("SELECT count(id_report_mark) FROM tb_report_mark WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status <= '3' AND id_mark != '2' AND is_use='1'", report_mark_type, id_report)
                jml = execute_query(query_jml, 0, True, "", "", "", "")
            Else
                'check there are marking
                query_jml = String.Format("SELECT count(id_report_mark) FROM tb_report_mark WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status = '{2}' AND is_use='1'", report_mark_type, id_report, id_status_reportx)
                jml = execute_query(query_jml, 0, True, "", "", "", "")
                If jml < 1 Then
                    'no one assigned yet
                    assigned = False
                Else
                    assigned = True
                    query_jml = String.Format("SELECT count(id_report_mark) FROM tb_report_mark WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status <= '{2}' AND id_mark != '2' AND is_use='1'", report_mark_type, id_report, id_status_reportx)
                    jml = execute_query(query_jml, 0, True, "", "", "", "")
                End If
            End If

            If (jml < 1 And assigned = True) Or id_status_reportx = "5" Then
                If id_status_reportx < id_report_status_report Or id_status_reportx = "5" Then
                    '
                    If id_status_reportx = "5" Then
                        Dim confirm As DialogResult
                        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to cancel this document ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        If confirm = Windows.Forms.DialogResult.Yes Then
                            assigned = True
                            query = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", report_mark_type, id_report, id_status_reportx)
                            execute_non_query(query, True, "", "", "", "")
                            view_mark()
                        Else
                            assigned = False
                        End If
                    ElseIf id_status_reportx = "6" Or id_status_reportx = "4" Or id_status_reportx = "3" Then
                        'completed or processed
                        assigned = True
                    Else
                        Dim confirm As DialogResult
                        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Choosing this status will reset all mark above this status, continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        If confirm = Windows.Forms.DialogResult.Yes Then
                            assigned = True
                            query = String.Format("UPDATE tb_report_mark SET id_mark='1',report_mark_lead_time=NULL,report_mark_start_datetime=NULL,report_mark_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'{2}'", report_mark_type, id_report, id_status_reportx)
                            execute_non_query(query, True, "", "", "", "")
                            view_mark()
                        Else
                            assigned = False
                        End If
                    End If
                ElseIf id_status_reportx = "6" Then 'completed
                    'If is_coa_posting(report_mark_type) Then
                    '    Dim confirm As DialogResult
                    '    confirm = DevExpress.XtraEditors.XtraMessageBox.Show("By choosing this status, program will automatically create entry to journal, continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    '    If confirm = Windows.Forms.DialogResult.Yes Then
                    '        assigned = True
                    '        posting_journal()
                    '        view_mark()
                    '    Else
                    '        assigned = False
                    '    End If
                    'Else
                    '    assigned = True
                    'End If
                    assigned = True
                End If

                If assigned = True Then
                    change_status(id_status_reportx)
                End If
            Else
                stopCustom("Unable change to this status, report doesn't meet requirement to this status.")
            End If

            view_mark()
            view_report_status(LEReportStatus)
            'slow here
            'FormWork.view_mark_history()
            'FormWork.view_mark_need()
        Else
            infoCustom("Nothing changed.")
        End If
        Cursor = Cursors.Default
    End Sub

    'Sub auto_journal()
    '    Dim id_status_reportx As String = LEReportStatus.EditValue
    '    Dim acc_trans_number As String = ""
    '    Dim last_id As String = ""
    '    Dim id_cc As String = "-1"
    '    Dim query As String = ""
    '    Dim query_det As String = ""
    '    Dim id_ref As String = ""
    '    Dim id_acc As String = ""
    '    Dim acc_name As String = ""
    '    Dim acc_desc As String = ""
    '    Dim debit, credit As Decimal
    '    Dim comp_name As String = ""
    '    Dim id_trans As String = ""

    '    'q_posting = String.Format("INSERT INTO tb_a_acc_trans(acc_trans_number,id_user,date_created,acc_trans_note) VALUES('{0}','{1}',NOW(),'Auto posting {2}');SELECT LAST_INSERT_ID()", acc_trans_number, id_user, report_number)
    '    'last_id = execute_query(q_posting, 0, True, "", "", "", "")

    '    If report_mark_type = "48" And id_status_reportx = "6" Then ' sales FG; 1 = BPJ
    '        query = "SELECT s_p.id_sales_pos,comp_c.id_comp,comp.comp_name,s_p.sales_pos_number, s_p.sales_pos_total,s_p.sales_pos_discount,s_p.sales_pos_vat,(s_p.sales_pos_total*((100-s_p.sales_pos_discount)/100) ) AS netto, ((100/(100+s_p.sales_pos_vat))*(s_p.sales_pos_total*((100-s_p.sales_pos_discount)/100))) AS kena_ppn,((s_p.sales_pos_vat/(100+s_p.sales_pos_vat))*(s_p.sales_pos_total*((100-s_p.sales_pos_discount)/100))) AS ppn"
    '        query += " FROM tb_sales_pos s_p INNER JOIN tb_m_comp_contact comp_c ON comp_c.id_comp_contact=s_p.id_store_contact_from "
    '        query += " INNER JOIN tb_m_comp comp ON comp.id_comp=comp_c.id_comp "
    '        query += " WHERE sales_pos_number = '" + report_number + "' AND id_memo_type='1'"
    '        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

    '        'auto posting COA
    '        id_cc = data.Rows(0)("id_comp").ToString
    '        report_number = data.Rows(0)("sales_pos_number").ToString
    '        id_ref = data.Rows(0)("id_sales_pos").ToString
    '        comp_name = data.Rows(0)("comp_name").ToString

    '        query = "SELECT coa_map_d.id_coa_map_det,comp_coa.id_acc,acc.acc_name,acc.acc_description "
    '        query += " FROM tb_m_comp_coa comp_coa "
    '        query += " INNER JOIN tb_coa_map_det coa_map_d ON coa_map_d.id_coa_map_det=comp_coa.id_coa_map_det"
    '        query += " INNER JOIN tb_coa_map coa_map ON coa_map_d.id_coa_map=coa_map.id_coa_map"
    '        query += " INNER JOIN tb_a_acc acc ON acc.id_acc=comp_coa.id_acc"
    '        query += " WHERE comp_coa.id_comp='" + id_cc + "' AND coa_map.id_coa_map='1'"
    '        Dim data_acc As DataTable = execute_query(query, -1, True, "", "", "", "")

    '        If data_acc.Rows.Count > 0 Then 'id_coa_map = 1
    '            no_journal = header_number_acc("3") 'journal number
    '            'insert journal header
    '            query = String.Format("INSERT INTO tb_a_acc_trans(acc_trans_number,date_created,id_user,acc_trans_note,id_bill_type,report_mark_type,id_report,report_number,id_cc) VALUES('{0}',NOW(),'{1}','{2}','{3}','{4}','{5}','{6}','{7}'); SELECT LAST_INSERT_ID()", no_journal, id_user, "Auto posting sales finish goods.", 1, report_mark_type, id_ref, report_number, id_cc)
    '            id_trans = execute_query(query, 0, True, "", "", "", "")

    '            increase_inc_acc("3")

    '            'id_acc piutang dagang
    '            Dim data_filter As DataRow() = data_acc.Select("[id_coa_map_det]='1'")
    '            id_acc = data_filter(0)("id_acc").ToString
    '            acc_name = data_filter(0)("acc_name").ToString
    '            acc_desc = data_filter(0)("acc_description").ToString

    '            debit = 0
    '            credit = data.Rows(0)("netto")

    '            query_det = add_journal(id_trans, id_acc, acc_name, acc_desc, debit, credit, id_cc, report_mark_type, id_ref, report_number)
    '            'end id_acc piutang dagang

    '            'id_acc PPN
    '            data_filter = data_acc.Select("[id_coa_map_det]='2'")
    '            id_acc = data_filter(0)("id_acc").ToString
    '            acc_name = data_filter(0)("acc_name").ToString
    '            acc_desc = data_filter(0)("acc_description").ToString

    '            debit = data.Rows(0)("ppn")
    '            credit = 0
    '            query_det += "," + add_journal(id_trans, id_acc, acc_name, acc_desc, debit, credit, id_cc, report_mark_type, id_ref, report_number)
    '            'end id_acc PPN

    '            'id_acc penjualan
    '            data_filter = data_acc.Select("[id_coa_map_det]='3'")
    '            id_acc = data_filter(0)("id_acc").ToString
    '            acc_name = data_filter(0)("acc_name").ToString
    '            acc_desc = data_filter(0)("acc_description").ToString

    '            debit = data.Rows(0)("kena_ppn")
    '            credit = 0
    '            query_det += "," + add_journal(id_trans, id_acc, acc_name, acc_desc, debit, credit, id_cc, report_mark_type, id_ref, report_number)
    '            'end id_acc penjualan

    '            query = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,id_status_open,report_mark_type,id_report,report_number,id_comp) VALUES" + query_det
    '            execute_non_query(query, True, "", "", "", "")
    '        Else
    '            stopCustom("Store account not registered")
    '        End If
    '    End If
    'End Sub

    Function add_journal(ByVal id_acc_trans As String, ByVal id_acc As String, ByVal acc_name As String, ByVal note As String, ByVal debit As Decimal, ByVal credit As Decimal, ByVal id_comp As String, ByVal report_mark_type As String, ByVal id_report As String, ByVal report_numberx As String)
        Dim query As String = "('" + id_acc_trans + "','" + id_acc + "','" + decimalSQL(debit.ToString) + "','" + decimalSQL(credit.ToString) + "','" + note + "',1,'" + report_mark_type + "','" + id_report + "','" + report_numberx + "','" + id_comp + "')"
        Return query
    End Function

    Sub change_status(ByVal id_status_reportx As String)
        Dim query As String = ""
        If report_mark_type = "1" Then
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            'sample purchase
            query = String.Format("UPDATE tb_sample_purc SET id_report_status='{0}' WHERE id_sample_purc='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            Try
                FormSamplePurchaseDet.allow_status()
                FormSamplePurchase.view_sample_purc()
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "2" Then
            'sample receive
            'report status
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = 6 Then 'Completed
                Dim query_del As String = "DELETE FROM tb_sample_purc_rec_det WHERE id_sample_purc_rec='" + id_report + "' AND sample_purc_rec_det_qty <= 0"
                execute_non_query(query_del, True, "", "", "", "")
                '
                Dim query_completed As String = "SELECT * FROM tb_sample_purc_rec_det a "
                query_completed += "INNER JOIN tb_sample_purc_det b ON a.id_sample_purc_det = b.id_sample_purc_det "
                query_completed += "INNER JOIN tb_m_sample_price c ON c.id_sample_price = b.id_sample_price "
                query_completed += "INNER JOIN tb_sample_purc_rec d ON d.id_sample_purc_rec = a.id_sample_purc_rec "
                query_completed += "LEFT JOIN "
                query_completed += "( "
                query_completed += "SELECT id_sample_price as id_sample_price_cost,sample_price as sample_price_cost,id_sample FROM tb_m_sample_price WHERE is_default_cost=1 "
                query_completed += ") cost ON cost.id_sample=c.id_sample "
                query_completed += "WHERE a.id_sample_purc_rec = '" + id_report + "' "
                Dim data As DataTable = execute_query(query_completed, -1, True, "", "", "", "")
                For i As Integer = 0 To (data.Rows.Count - 1)
                    Dim id_sample_purc_rec_det As String = data.Rows(i)("id_sample_purc_rec_det").ToString
                    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                    Dim id_sample As String = data.Rows(i)("id_sample").ToString
                    Dim id_sample_price As String = data.Rows(i)("id_sample_price_cost").ToString
                    Dim sample_price As Decimal = data.Rows(i)("sample_price_cost")
                    Dim sample_return_det_qty As String = data.Rows(i)("sample_purc_rec_det_qty").ToString
                    Dim sample_return_number As String = data.Rows(i)("sample_purc_rec_number").ToString
                    Dim query_upd_storage As String = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes,id_report,report_mark_type,id_stock_status,id_sample_price,sample_price) "
                    'update storage
                    query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_sample + "', '" + sample_return_det_qty + "', NOW(), 'Completed, Sample Receive No. : " + sample_return_number + "','" + id_report + "','" + report_mark_type + "','1','" + id_sample_price + "','" + decimalSQL(sample_price.ToString) + "')"
                    execute_non_query(query_upd_storage, True, "", "", "", "")
                    'update stored
                    Dim query_upd_stored As String = "UPDATE tb_sample_purc_rec_det SET sample_purc_rec_det_qty_stored = sample_purc_rec_det_qty WHERE id_sample_purc_rec_det='" & id_sample_purc_rec_det & "' "
                    execute_non_query(query_upd_stored, True, "", "", "", "")
                Next

                'email notifikasi
                Dim mail As ClassSendEmail = New ClassSendEmail()
                mail.id_report = id_report
                mail.report_mark_type = report_mark_type
                mail.send_email()
            ElseIf id_status_reportx = "5" Then
                query = String.Format("SELECT id_report_status FROM tb_sample_purc_rec WHERE id_sample_purc_rec ='{0}' AND id_report_status='6'", id_report)
                Dim dt_c As DataTable = execute_query(query, -1, True, "", "", "", "")
                If dt_c.Rows.Count > 0 Then
                    'cancellation form
                    Dim q_cancel As String = "DELETE FROM tb_storage_sample WHERE id_report='" & id_report & "' AND report_mark_type='" & report_mark_type & "'"
                    execute_non_query(q_cancel, True, "", "", "", "")
                End If
            End If
            query = String.Format("UPDATE tb_sample_purc_rec SET id_report_status='{0}' WHERE id_sample_purc_rec='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'infoCustom("Status changed.")
            Try
                'FormSampleReceiveDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                'FormSampleReceiveDet.allow_status()
                'FormSampleReceiveDet.view_list_rec()
                'FormSampleReceive.view_sample_rec()
                'FormSampleReceive.GVSampleReceive.FocusedRowHandle = find_row(FormSampleReceive.GVSampleReceive, "id_sample_purc_rec", id_report)
                'FormViewSampleReceive.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                'FormWork.view_sample_rec()
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "3" Then
            'sample PL
            If id_status_reportx = 3 Then
                Dim query_del_zero As String = "DELETE FROM tb_pl_sample_purc_det WHERE id_pl_sample_purc = '" + id_report + "' AND pl_sample_purc_det_qty= '0.00'"
                execute_non_query(query_del_zero, True, "", "", "", "")
            End If

            query = String.Format("UPDATE tb_pl_sample_purc SET id_report_status='{0}' WHERE id_pl_sample_purc='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            Try
                FormSamplePLSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSamplePLSingle.action = "upd"
                FormSamplePLSingle.id_report_status = id_status_reportx
                FormSamplePLSingle.actionLoad()
                FormViewSamplePL.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "4" Then
            'sample PR
            query = String.Format("UPDATE tb_pr_sample_purc SET id_report_status='{0}' WHERE id_pr_sample_purc='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            Try
                FormSamplePRDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSamplePRDet.allow_status()
                FormViewSamplePR.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "5" Then
            'sample ret out
            query = String.Format("UPDATE tb_sample_purc_ret_out SET id_report_status='{0}' WHERE id_sample_purc_ret_out='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            Try
                FormSampleRetOutSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSampleRetOutSingle.action = "upd"
                FormSampleRetOutSingle.id_report_status = id_status_reportx
                FormSampleRetOutSingle.actionLoad()
                'FormViewSampleReceive.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                'FormWork.view_sample_rec()
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "6" Then
            'sample ret in
            query = String.Format("UPDATE tb_sample_purc_ret_in SET id_report_status='{0}' WHERE id_sample_purc_ret_in='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            Try
                FormSampleRetInSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSampleRetInSingle.action = "upd"
                FormSampleRetInSingle.id_report_status = id_status_reportx
                FormSampleRetInSingle.actionLoad()
                'FormViewSampleReceive.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                'FormWork.view_sample_rec()
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "7" Then
            'sample Receipt
            query = String.Format("UPDATE tb_pl_sample_purc SET id_report_status_rec='{0}' WHERE id_pl_sample_purc='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            Try
                FormSampleReceiptSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSampleReceiptSingle.action = "upd"
                FormSampleReceiptSingle.id_report_status_rec = id_status_reportx
                FormSampleReceiptSingle.actionLoad()
                'FormViewSampleReceive.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                'FormWork.view_sample_rec()
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "8" Then
            'bom
            query = String.Format("UPDATE tb_bom SET id_report_status='{0}' WHERE id_bom='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            Try
                FormBOMSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormBOMSingle.allow_status()
                'FormViewSamplePurchase.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                'FormWork.view_sample_purc()
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "9" Or report_mark_type = "80" Or report_mark_type = "81" Or report_mark_type = "206" Then
            'PROD DEMAND
            'auto completed
            If id_status_reportx = "2" Then
                id_status_reportx = "6"
            End If


            'posting ke master price disini
            '--------------------------
            If id_status_reportx = 6 Then ' COMPLETED
                'get default curr
                Dim auto_insert_price_from_pd As String = execute_query("SELECT auto_insert_price_from_pd FROM tb_opt", 0, True, "", "", "", "")
                Dim id_currency As String = execute_query("SELECT id_currency_default FROM tb_opt", 0, True, "", "", "", "")

                'insert price
                If auto_insert_price_from_pd = "1" Then
                    Dim query_post_price As String = ""
                    query_post_price += "INSERT INTO tb_m_design_price(id_design, id_design_price_type, design_price_name, id_currency, design_price, design_price_date, design_price_start_date, is_print, is_active_wh, id_user) "
                    query_post_price += "SELECT id_design, '1', 'Normal Price', '" + id_currency + "', prod_demand_design_propose_price, NOW(), date_available_start, '1', '1', '" + id_user + "' FROM tb_prod_demand_design WHERE id_prod_demand = '" + id_report + "' "
                    execute_non_query(query_post_price, True, "", "", "", "")
                End If

                'non md
                If FormViewProdDemand.id_pd_kind <> "1" Then
                    Dim query_post_price As String = ""
                    query_post_price += "INSERT INTO tb_m_design_price(id_design, id_design_price_type, design_price_name, id_currency, design_price, design_price_date, design_price_start_date, is_print, is_active_wh, id_user) "
                    query_post_price += "SELECT id_design, '1', 'Normal Price', '" + id_currency + "', 0, NOW(), NOW(), '1', '1', '" + id_user + "' FROM tb_prod_demand_design WHERE id_prod_demand = '" + id_report + "' "
                    execute_non_query(query_post_price, True, "", "", "", "")
                End If

                'notif email
                Try
                    Dim mail As ClassSendEmail = New ClassSendEmail()
                    mail.report_mark_type = report_mark_type
                    mail.send_email_notif(report_mark_type, id_report)
                Catch ex As Exception
                    execute_non_query("INSERT INTO tb_error_mail(date, description) VALUES(NOW(), 'PD;" + id_report + ";" + addSlashes(ex.ToString) + "'); ", True, "", "", "", "")
                End Try
            End If

            'update status
            query = String.Format("UPDATE tb_prod_demand SET id_report_status='{0}' WHERE id_prod_demand='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            If form_origin = "FormProdDemand" Then
                FormProdDemand.viewProdDemand()
                FormProdDemand.GVProdDemand.FocusedRowHandle = find_row(FormProdDemand.GVProdDemand, "id_prod_demand", id_report)
                FormProdDemand.view_product()
            End If
        ElseIf report_mark_type = "10" Then
            'sample PL Del
            If id_status_reportx = 5 Then 'Cancel
                Dim query_cancel As String = "SELECT * FROM tb_pl_sample_del a "
                query_cancel += "INNER JOIN tb_pl_sample_del_det b ON a.id_pl_sample_del = b.id_pl_sample_del "
                query_cancel += "INNER JOIN tb_sample_requisition_det c ON b.id_sample_requisition_det = c.id_sample_requisition_det "
                query_cancel += "WHERE a.id_pl_sample_del = '" + id_report + "' "
                Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                For i As Integer = 0 To (data.Rows.Count - 1)
                    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                    Dim id_sample As String = data.Rows(i)("id_sample").ToString
                    Dim pl_sample_del_det_qty As String = data.Rows(i)("pl_sample_del_det_qty").ToString
                    Dim pl_sample_del_number As String = data.Rows(i)("pl_sample_del_number").ToString
                    Dim id_sample_price As String = data.Rows(i)("id_sample_price").ToString
                    Dim sample_price As Decimal = data.Rows(i)("sample_price")

                    Dim query_upd_storage As String = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes,id_report,report_mark_type,id_stock_status,id_sample_price,sample_price) "
                    query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_sample + "', '" + pl_sample_del_det_qty + "', NOW(), 'Out sample was cancelled, PL : " + pl_sample_del_number + "','" + id_report + "','" + report_mark_type + "','2','" + id_sample_price + "','" + decimalSQL(sample_price.ToString) + "')"
                    execute_non_query(query_upd_storage, True, "", "", "", "")
                Next
            ElseIf id_status_reportx = 6 Then 'Completed
                Dim query_cancel As String = "SELECT * FROM tb_pl_sample_del a "
                query_cancel += "INNER JOIN tb_pl_sample_del_det b ON a.id_pl_sample_del = b.id_pl_sample_del "
                query_cancel += "INNER JOIN tb_sample_requisition_det c ON b.id_sample_requisition_det = c.id_sample_requisition_det "
                query_cancel += "WHERE a.id_pl_sample_del = '" + id_report + "' "
                Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                For i As Integer = 0 To (data.Rows.Count - 1)
                    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                    Dim id_sample As String = data.Rows(i)("id_sample").ToString
                    Dim pl_sample_del_det_qty As String = data.Rows(i)("pl_sample_del_det_qty").ToString
                    Dim pl_sample_del_number As String = data.Rows(i)("pl_sample_del_number").ToString
                    Dim id_sample_price As String = data.Rows(i)("id_sample_price").ToString
                    Dim sample_price As Decimal = data.Rows(i)("sample_price")
                    '
                    Dim query_upd_storage As String = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes,id_report,report_mark_type,id_stock_status,id_sample_price,sample_price) "
                    query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_sample + "', '" + pl_sample_del_det_qty + "', NOW(), 'Completed, Sample PL : " + pl_sample_del_number + "','" + id_report + "','" + report_mark_type + "','2','" + id_sample_price + "','" + decimalSQL(sample_price.ToString) + "')"
                    execute_non_query(query_upd_storage, True, "", "", "", "")
                    '
                    query_upd_storage = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes,id_report,report_mark_type,id_stock_status,id_sample_price,sample_price) "
                    query_upd_storage += "VALUES('" + id_wh_drawer + "', '2', '" + id_sample + "', '" + pl_sample_del_det_qty + "', NOW(), 'Completed, Sample PL : " + pl_sample_del_number + "','" + id_report + "','" + report_mark_type + "','1','" + id_sample_price + "','" + decimalSQL(sample_price.ToString) + "')"
                    execute_non_query(query_upd_storage, True, "", "", "", "")
                Next
            End If

            query = String.Format("UPDATE tb_pl_sample_del SET id_report_status='{0}' WHERE id_pl_sample_del='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            'Try
            If form_origin = "FormSamplePLDelSingle" Then
                FormSamplePLDelSingle.id_pl_sample_del = id_report
                FormSamplePLDelSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSamplePLDelSingle.action = "upd"
                FormSamplePLDelSingle.id_report_status = id_status_reportx
                FormSamplePLDelSingle.actionLoad()
                FormSamplePLDel.viewPL()
                FormSamplePLDel.viewSampleReq()
                FormSamplePLDel.GVPL.FocusedRowHandle = find_row(FormSamplePLDel.GVPL, "id_pl_sample_del", id_report)
            Else
                FormViewSamplePLDel.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
            End If
            'Catch ex As Exception
            'End Try
        ElseIf report_mark_type = "11" Then
            'sample requisition
            query = String.Format("UPDATE tb_sample_requisition SET id_report_status='{0}' WHERE id_sample_requisition='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            Try
                FormSampleReqSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSampleReqSingle.action = "upd"
                FormSampleReqSingle.id_report_status = id_status_reportx
                FormSampleReqSingle.actionLoad()
                FormSampleReq.viewSampleReq()
                'FormViewSampleReceive.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                'FormWork.view_sample_rec()
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "12" Then
            'sample planning
            query = String.Format("UPDATE tb_sample_plan SET id_report_status='{0}' WHERE id_sample_plan='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            Try
                FormSamplePlanDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSamplePlanDet.allow_status()
                FormSamplePlan.view_sample_plan()
                FormViewSamplePlan.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                'FormWork.view_sample_purc()
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "13" Then
            'material purchase
            If id_status_reportx = 3 Then 'Approved then completed
                id_status_reportx = 6
            ElseIf id_status_reportx = 5 Then 'cancel
                query = "UPDATE `tb_mat_purc_list` SET id_mat_purc=NULL,id_comp_contact=NULL,mat_det_price=NULL,id_mat_det_price=NULL WHERE id_mat_purc='" & id_report & "'"
                execute_non_query(query, True, "", "", "", "")
            End If
            query = String.Format("UPDATE tb_mat_purc SET id_report_status='{0}' WHERE id_mat_purc='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            Try
                FormMatPurchaseDet.id_report_status_g = id_status_reportx
                FormMatPurchaseDet.allow_status()
                FormMatPurchase.view_mat_purc()
                FormMatPurchase.GVMatPurchase.FocusedRowHandle = find_row(FormMatPurchase.GVMatPurchase, "id_mat_purc", id_report)
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "14" Then
            'sample Return

            If id_status_reportx = 6 Then 'Completed
                Dim query_cancel As String = "SELECT * FROM tb_sample_return a "
                query_cancel += "INNER JOIN tb_sample_return_det b ON a.id_sample_return = b.id_sample_return "
                query_cancel += "WHERE a.id_sample_return = '" + id_report + "' "
                Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")

                Dim jum_ins_i As Integer = 0
                Dim query_upd_storage As String = ""
                If data.Rows.Count > 0 Then
                    query_upd_storage = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes,id_report,report_mark_type,id_stock_status,id_sample_price,sample_price) VALUES "
                End If
                For i As Integer = 0 To (data.Rows.Count - 1)
                    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                    Dim id_sample As String = data.Rows(i)("id_sample").ToString
                    Dim id_sample_price As String = data.Rows(i)("id_sample_price").ToString
                    Dim sample_price As Decimal = data.Rows(i)("sample_price")
                    Dim sample_return_det_qty As String = data.Rows(i)("sample_return_det_qty").ToString
                    Dim sample_return_number As String = data.Rows(i)("sample_return_number").ToString

                    If jum_ins_i > 0 Then
                        query_upd_storage += ", "
                    End If
                    query_upd_storage += "('" + id_wh_drawer + "', '1', '" + id_sample + "', '" + decimalSQL(sample_return_det_qty) + "', NOW(), 'Completed,Sample Return No. : " + sample_return_number + "','" + id_report + "','" + report_mark_type + "','1','" + id_sample_price + "','" + decimalSQL(sample_price.ToString) + "') "
                    jum_ins_i = jum_ins_i + 1
                Next
                If data.Rows.Count > 0 Then
                    execute_non_query(query_upd_storage, True, "", "", "", "")
                End If
            End If

            query = String.Format("UPDATE tb_sample_return SET id_report_status='{0}' WHERE id_sample_return='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            'Try
            If form_origin = "FormSampleReturnSingle" Then
                FormSampleReturnSingle.id_sample_return = id_report
                FormSampleReturnSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSampleReturnSingle.action = "upd"
                FormSampleReturnSingle.id_report_status = id_status_reportx
                FormSampleReturnSingle.actionLoad()
                FormSampleReturn.viewSampleReturn()
                FormSampleReturn.GVRetSample.FocusedRowHandle = find_row(FormSampleReturn.GVRetSample, "id_sample_return", id_report)
                FormSampleReturn.viewPl()
            Else
                FormViewSampleReturn.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
            End If
            'Catch ex As Exception
            'End Try
        ElseIf report_mark_type = "15" Then
            'material wo
            If id_status_reportx = "6" Then 'completed
                query = String.Format("UPDATE tb_mat_wo SET id_report_status='{0}',mat_wo_complete_date=NOW() WHERE id_mat_wo='{1}'", id_status_reportx, id_report)
            Else
                query = String.Format("UPDATE tb_mat_wo SET id_report_status='{0}' WHERE id_mat_wo='{1}'", id_status_reportx, id_report)
            End If

            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            Try
                FormMatWODet.allow_status()
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "16" Then
            'Receive material purchase
            If id_status_reportx = 3 Then
                id_status_reportx = 6
            End If
            If id_status_reportx = 6 Then 'Completed
                Dim is_ok As String = "1"
                For i As Integer = 0 To FormMatRecPurcDet.GVListPurchase.RowCount - 1
                    If FormMatRecPurcDet.GVListPurchase.GetRowCellValue(i, "mat_purc_rec_det_qty") > 0 And FormMatRecPurcDet.GVListPurchase.GetRowCellValue(i, "cost") = 0 Then
                        is_ok = "2"
                        Exit For
                    End If
                Next
                If is_ok = "1" Then
                    query = String.Format("UPDATE tb_mat_purc_rec SET id_report_status='{0}' WHERE id_mat_purc_rec='{1}'", id_status_reportx, id_report)
                    execute_non_query(query, True, "", "", "", "")
                    '
                    Dim query_del As String = "DELETE FROM tb_mat_purc_rec_det WHERE id_mat_purc_rec='" + id_report + "' AND mat_purc_rec_det_qty <= 0"
                    execute_non_query(query_del, True, "", "", "", "")
                    '
                    Dim query_completed As String = "SELECT c.id_mat_det,b.id_mat_det_price,b.mat_purc_det_price,a.mat_purc_rec_det_qty,d.id_wh_drawer,d.mat_purc_rec_number,IFNULL(cost.id_mat_det_price_cost,0) as id_mat_det_price_cost,IFNULL(cost.mat_det_price_cost,0.0) as mat_det_price_cost FROM tb_mat_purc_rec_det a "
                    query_completed += "INNER JOIN tb_mat_purc_det b ON a.id_mat_purc_det = b.id_mat_purc_det "
                    query_completed += "INNER JOIN tb_m_mat_det_price c ON c.id_mat_det_price = b.id_mat_det_price "
                    query_completed += "INNER JOIN tb_mat_purc_rec d ON d.id_mat_purc_rec = a.id_mat_purc_rec "
                    query_completed += "LEFT JOIN ( "
                    query_completed += "SELECT id_mat_det_price as id_mat_det_price_cost,mat_det_price as mat_det_price_cost,id_mat_det FROM tb_m_mat_det_price WHERE is_default_cost=1 "
                    query_completed += ") cost ON cost.id_mat_det=c.id_mat_det "
                    query_completed += "WHERE a.id_mat_purc_rec = '" + id_report + "' AND a.mat_purc_rec_det_qty>0 "
                    Dim data As DataTable = execute_query(query_completed, -1, True, "", "", "", "")
                    Dim jum_ins_i As Integer = 0
                    Dim query_upd_storage As String = ""
                    If data.Rows.Count > 0 Then
                        query_upd_storage = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_report,report_mark_type,id_stock_status,id_mat_det_price,price) VALUES "
                    End If
                    For i As Integer = 0 To (data.Rows.Count - 1)
                        Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                        Dim id_mat_det As String = data.Rows(i)("id_mat_det").ToString
                        Dim id_mat_det_price As String = data.Rows(i)("id_mat_det_price_cost").ToString
                        Dim mat_det_price As Decimal = data.Rows(i)("mat_det_price_cost")
                        Dim mat_wo_rec_det_qty As String = data.Rows(i)("mat_purc_rec_det_qty").ToString
                        Dim mat_wo_rec_number As String = data.Rows(i)("mat_purc_rec_number").ToString
                        If i > 0 Then
                            query_upd_storage += ", "
                        End If
                        'update storage
                        query_upd_storage += "('" + id_wh_drawer + "', '1', '" + id_mat_det + "', '" + decimalSQL(mat_wo_rec_det_qty.ToString) + "', NOW(), 'Completed, Material PO Receive No. : " + mat_wo_rec_number + "','" + id_report + "','" + report_mark_type + "','1','" + id_mat_det_price + "','" + decimalSQL(mat_det_price.ToString) + "')"
                    Next
                    If data.Rows.Count > 0 Then
                        execute_non_query(query_upd_storage, True, "", "", "", "")
                    End If

                    'post journal
                    'Dim queryj As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, acc_trans_note, id_report_status)
                    'VALUES ('" + header_number_acc("1") + "','" + report_number + "','15','" + id_user + "', NOW(), 'Auto Posting', '6'); SELECT LAST_INSERT_ID(); "
                    'Dim idj As String = execute_query(queryj, 0, True, "", "", "", "")
                    'increase_inc_acc("1")

                    'Dim qdj As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number, id_status_open)
                    '(SELECT '" + idj + "',1132,(prc.mat_det_price * rd.mat_purc_rec_det_qty) AS `debit_val`, 0 AS `credit_val` , 'Auto Posting', '16', '" + id_report + "', r.mat_purc_rec_number, 2
                    'FROM tb_mat_purc_rec_det rd
                    'INNER JOIN tb_mat_purc_rec r ON r.id_mat_purc_rec = rd.id_mat_purc_rec
                    'INNER JOIN tb_mat_purc_det pod ON pod.id_mat_purc_det = rd.id_mat_purc_det
                    'INNER JOIN tb_m_mat_det_price prc ON prc.id_mat_det_price = pod.id_mat_det_price
                    'WHERE rd.id_mat_purc_rec=" + id_report + " AND rd.mat_purc_rec_det_qty>0)
                    'UNION ALL
                    '(SELECT '" + idj + "',191,SUM(prc.mat_det_price * rd.mat_purc_rec_det_qty)*(po.mat_purc_vat/100) AS `debit_val`, 0 AS `credit_val`, 'Auto Posting', '16', '" + id_report + "', r.mat_purc_rec_number, 2
                    'FROM tb_mat_purc_rec_det rd
                    'INNER JOIN tb_mat_purc_rec r ON r.id_mat_purc_rec = rd.id_mat_purc_rec
                    'INNER JOIN tb_mat_purc_det pod ON pod.id_mat_purc_det = rd.id_mat_purc_det
                    'INNER JOIN tb_m_mat_det_price prc ON prc.id_mat_det_price = pod.id_mat_det_price
                    'INNER JOIN tb_mat_purc po ON po.id_mat_purc = pod.id_mat_purc
                    'WHERE rd.id_mat_purc_rec=" + id_report + " AND rd.mat_purc_rec_det_qty>0)
                    'UNION ALL
                    '(SELECT '" + idj + "',a.id_acc,0 AS `debit_val`,SUM(prc.mat_det_price * rd.mat_purc_rec_det_qty)*((po.mat_purc_vat+100)/100) AS `credit_val`, 'Auto Posting', '16', '" + id_report + "', r.mat_purc_rec_number, 2
                    'FROM tb_mat_purc_rec_det rd
                    'INNER JOIN tb_mat_purc_rec r ON r.id_mat_purc_rec = rd.id_mat_purc_rec
                    'INNER JOIN tb_mat_purc_det pod ON pod.id_mat_purc_det = rd.id_mat_purc_det
                    'INNER JOIN tb_m_mat_det_price prc ON prc.id_mat_det_price = pod.id_mat_det_price
                    'INNER JOIN tb_mat_purc po ON po.id_mat_purc = pod.id_mat_purc
                    'INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = po.id_comp_contact_to
                    'INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
                    'JOIN tb_a_acc a ON a.acc_name LIKE CONCAT('2112','%',c.comp_number) AND a.id_is_det=2
                    'WHERE rd.id_mat_purc_rec=" + id_report + " AND rd.mat_purc_rec_det_qty>0) "
                    'execute_non_query(qdj, True, "", "", "", "")

                    'infoCustom("Status changed.")
                    Try
                        FormMatRecPurcDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                        FormMatRecPurcDet.allow_status()
                        FormViewMatRecPurc.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                        FormMatRecPurc.view_mat_rec_purc()
                        FormMatRecPurc.GVMatRecPurc.FocusedRowHandle = find_row(FormMatRecPurc.GVMatRecPurc, "id_mat_rec_purc", id_report)
                    Catch ex As Exception
                    End Try
                Else
                    stopCustom("Please make sure all material have cost.")
                End If
            Else
                query = String.Format("UPDATE tb_mat_purc_rec Set id_report_status='{0}' WHERE id_mat_purc_rec='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                'infoCustom("Status changed.")
                Try
                    FormMatRecPurcDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormMatRecPurcDet.allow_status()
                    FormViewMatRecPurc.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormMatRecPurc.view_mat_rec_purc()
                    FormMatRecPurc.GVMatRecPurc.FocusedRowHandle = find_row(FormMatRecPurc.GVMatRecPurc, "id_mat_rec_purc", id_report)
                Catch ex As Exception
                End Try
            End If
        ElseIf report_mark_type = "17" Then
            'Receive material wo
            If id_status_reportx = 6 Then 'Completed
                Dim is_ok As String = "1"
                For i As Integer = 0 To FormMatRecWODet.GVListPurchase.RowCount - 1
                    If FormMatRecWODet.GVListPurchase.GetRowCellValue(i, "cost") = 0 Then
                        is_ok = "2"
                        Exit For
                    End If
                Next
                If is_ok = "1" Then
                    Dim query_del As String = "DELETE FROM tb_mat_wo_rec_det WHERE id_mat_wo_rec='" + id_report + "' AND mat_wo_rec_det_qty <= 0"
                    execute_non_query(query_del, True, "", "", "", "")
                    '
                    Dim query_completed As String = "SELECT b.id_mat_det,b.id_mat_det_price,b.mat_wo_det_price,a.mat_wo_rec_det_qty,d.id_wh_drawer,d.mat_wo_rec_number,IFNULL(cost.id_mat_det_price_cost,0) as id_mat_det_price_cost,IFNULL(cost.mat_det_price_cost,0.0) as mat_det_price_cost FROM tb_mat_wo_rec_det a "
                    query_completed += "INNER JOIN tb_mat_wo_det b ON a.id_mat_wo_det = b.id_mat_wo_det "
                    query_completed += "INNER JOIN tb_mat_wo_rec d ON d.id_mat_wo_rec = a.id_mat_wo_rec "
                    query_completed += "LEFT JOIN ( "
                    query_completed += "SELECT id_mat_det_price as id_mat_det_price_cost,mat_det_price as mat_det_price_cost,id_mat_det FROM tb_m_mat_det_price WHERE is_default_cost=1 "
                    query_completed += ") cost ON cost.id_mat_det=b.id_mat_det "
                    query_completed += "WHERE a.id_mat_wo_rec = '" + id_report + "' "
                    Dim data As DataTable = execute_query(query_completed, -1, True, "", "", "", "")
                    For i As Integer = 0 To (data.Rows.Count - 1)
                        Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                        Dim id_mat_det As String = data.Rows(i)("id_mat_det").ToString
                        Dim id_mat_det_price As String = data.Rows(i)("id_mat_det_price_cost").ToString
                        Dim mat_det_price As Decimal = data.Rows(i)("mat_det_price_cost")
                        Dim mat_wo_rec_det_qty As String = data.Rows(i)("mat_wo_rec_det_qty").ToString
                        Dim mat_wo_rec_number As String = data.Rows(i)("mat_wo_rec_number").ToString
                        Dim query_upd_storage As String = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_report,report_mark_type,id_stock_status,id_mat_det_price,price) "
                        'update storage
                        query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_mat_det + "', '" + mat_wo_rec_det_qty + "', NOW(), 'Completed, Material WO Receive No. : " + mat_wo_rec_number + "','" + id_report + "','" + report_mark_type + "','1','" + id_mat_det_price + "','" + decimalSQL(mat_det_price.ToString) + "')"
                        execute_non_query(query_upd_storage, True, "", "", "", "")
                        'update stored
                    Next
                    query = String.Format("UPDATE tb_mat_wo_rec SET id_report_status='{0}' WHERE id_mat_wo_rec='{1}'", id_status_reportx, id_report)
                    execute_non_query(query, True, "", "", "", "")
                    'infoCustom("Status changed.")
                    Try
                        FormMatRecWODet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                        FormMatRecWODet.allow_status()
                        FormViewMatRecWO.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    Catch ex As Exception
                    End Try
                Else
                    stopCustom("Please make sure all material have cost.")
                End If

            Else
                query = String.Format("UPDATE tb_mat_wo_rec SET id_report_status='{0}' WHERE id_mat_wo_rec='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                'infoCustom("Status changed.")
                Try
                    FormMatRecWODet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormMatRecWODet.allow_status()
                    FormViewMatRecWO.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                Catch ex As Exception
                End Try
            End If
        ElseIf report_mark_type = "18" Then
            'Return Material Out
            If id_status_reportx = 6 Then 'complete
                Dim query_upd_storage As String = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det,id_mat_det_price,price, storage_mat_qty, storage_mat_datetime, storage_mat_notes,report_mark_type,id_report,id_stock_status) "
                query_upd_storage += " SELECT a.id_wh_drawer,'2',c.id_mat_det,b.id_mat_det_price,a.price,a.mat_purc_ret_out_det_qty,NOW(),'Completed, Material purchase return out : " & report_number & "','18','" & id_report & "','1' FROM tb_mat_purc_ret_out_det a INNER JOIN tb_mat_purc_det b ON b.id_mat_purc_det=a.id_mat_purc_det INNER JOIN tb_m_mat_det_price c ON c.id_mat_det_price=b.id_mat_det_price WHERE id_mat_purc_ret_out='" & id_report & "' AND NOT ISNULL(id_wh_drawer) AND NOT ISNULL(price)"
                execute_non_query(query_upd_storage, True, "", "", "", "")
            End If

            query = String.Format("UPDATE tb_mat_purc_ret_out SET id_report_status='{0}' WHERE id_mat_purc_ret_out='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            Try
                FormMatRetOutDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormMatRetOutDet.check_but()
                FormMatRetOutDet.allow_status()
                FormMatRet.viewRetOut()
                FormViewMatRetOut.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "19" Then
            'Return Material in
            query = String.Format("UPDATE tb_mat_purc_ret_in SET id_report_status='{0}' WHERE id_mat_purc_ret_in='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            If id_status_reportx = 6 Then 'Completed
                Dim query_cancel As String = "SELECT c.id_wh_drawer,d.id_mat_det,b.id_mat_det_price,b.mat_purc_det_price,a.mat_purc_ret_in_det_qty,c.mat_purc_ret_in_number,IFNULL(cost.id_mat_det_price_cost,0) as id_mat_det_price_cost,IFNULL(cost.mat_det_price_cost,0.0) as mat_det_price_cost FROM tb_mat_purc_ret_in_det a "
                query_cancel += "INNER JOIN tb_mat_purc_det b ON a.id_mat_purc_det = b.id_mat_purc_det "
                query_cancel += "INNER JOIN tb_m_mat_det_price d ON d.id_mat_det_price = b.id_mat_det_price "
                query_cancel += "INNER JOIN tb_mat_purc_ret_in c ON a.id_mat_purc_ret_in = c.id_mat_purc_ret_in "
                query_cancel += "LEFT JOIN( "
                query_cancel += "SELECT id_mat_det_price as id_mat_det_price_cost,mat_det_price as mat_det_price_cost,id_mat_det FROM tb_m_mat_det_price WHERE is_default_cost=1 "
                query_cancel += ") cost ON cost.id_mat_det=d.id_mat_det "
                query_cancel += "WHERE a.id_mat_purc_ret_in = '" + id_report + "' "
                Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")

                Dim jum_ins_i As Integer = 0
                Dim query_upd_storage As String = ""
                If data.Rows.Count > 0 Then
                    query_upd_storage = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_report,report_mark_type,id_stock_status,id_mat_det_price,price) VALUES "
                End If

                For i As Integer = 0 To (data.Rows.Count - 1)
                    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                    Dim id_mat_det As String = data.Rows(i)("id_mat_det").ToString
                    Dim id_mat_det_price As String = data.Rows(i)("id_mat_det_price_cost").ToString
                    Dim mat_det_price As Decimal = data.Rows(i)("mat_det_price_cost")
                    Dim mat_qty As String = data.Rows(i)("mat_purc_ret_in_det_qty").ToString
                    Dim mat_number As String = data.Rows(i)("mat_purc_ret_in_number").ToString

                    If jum_ins_i > 0 Then
                        query_upd_storage += ", "
                    End If

                    query_upd_storage += "('" + id_wh_drawer + "', '1', '" + id_mat_det + "', '" + decimalSQL(mat_qty.ToString) + "', NOW(), 'Completed, Material Return In No. : " + mat_number + "','" + id_report + "','" + report_mark_type + "','1','" + id_mat_det_price + "','" + decimalSQL(mat_det_price.ToString) + "') "

                    jum_ins_i = jum_ins_i + 1
                Next
                If data.Rows.Count > 0 Then
                    execute_non_query(query_upd_storage, True, "", "", "", "")
                End If
            End If
            'infoCustom("Status changed.")
            Try
                FormMatRetInDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormMatRetInDet.check_but()
                FormMatRetInDet.allow_status()
                FormMatRet.viewRetIn()
                FormViewMatRetIn.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "20" Then
            'Sample Adj In (UPDATED 17 October 2014)
            If id_status_reportx = "6" Then 'Cancel
                Dim query_cancel As String = "SELECT * FROM tb_adj_in_sample a "
                query_cancel += "INNER JOIN tb_adj_in_sample_det b ON a.id_adj_in_sample = b.id_adj_in_sample "
                query_cancel += "WHERE a.id_adj_in_sample = '" + id_report + "' "
                Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                For i As Integer = 0 To (data.Rows.Count - 1)
                    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                    Dim id_sample As String = data.Rows(i)("id_sample").ToString
                    Dim adj_in_sample_det_qty As String = data.Rows(i)("adj_in_sample_det_qty").ToString
                    Dim adj_in_sample_number As String = data.Rows(i)("adj_in_sample_number").ToString
                    Dim adj_in_sample_det_price As String = decimalSQL(data.Rows(i)("adj_in_sample_det_price").ToString)
                    Dim id_sample_price As String = data.Rows(i)("id_sample_price").ToString
                    Dim query_upd_storage As String = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes, id_sample_price, sample_price, report_mark_type, id_report, id_stock_status) "
                    query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_sample + "', '" + decimalSQL(adj_in_sample_det_qty) + "', NOW(), 'Sample IN completed, Adjustment In No. : " + adj_in_sample_number + "', '" + id_sample_price + "', '" + adj_in_sample_det_price + "', '20', '" + id_report + "', '1') "
                    execute_non_query(query_upd_storage, True, "", "", "", "")
                Next
            End If

            query = String.Format("UPDATE tb_adj_in_sample SET id_report_status='{0}' WHERE id_adj_in_sample='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            'Try
            If form_origin = "FormSampleAdjustmentInSingle" Then
                FormSampleAdjustmentInSingle.id_adj_in_sample = id_report
                FormSampleAdjustmentInSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSampleAdjustmentInSingle.action = "upd"
                FormSampleAdjustmentInSingle.id_report_status = id_status_reportx
                FormSampleAdjustmentInSingle.actionLoad()
                FormSampleAdjustment.viewAdjInSample()
                FormSampleAdjustment.GVAdjSampleIn.FocusedRowHandle = find_row(FormSampleAdjustment.GVAdjSampleIn, "id_adj_in_sample", id_report)
            ElseIf form_origin = "FormViewSampleAdjIn" Then
                FormViewSampleAdjIn.id_adj_in_sample = id_report
                FormViewSampleAdjIn.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormViewSampleAdjIn.action = "upd"
                FormViewSampleAdjIn.id_report_status = id_status_reportx
                FormViewSampleAdjIn.actionLoad()
            End If
            'Catch ex As Exception
            'End Try
        ElseIf report_mark_type = "21" Then
            'Sample Adj Out
            If id_status_reportx = 5 Then 'Cancel
                Dim query_cancel As String = "SELECT * FROM tb_adj_out_sample a "
                query_cancel += "INNER JOIN tb_adj_out_sample_det b ON a.id_adj_out_sample = b.id_adj_out_sample "
                query_cancel += "WHERE a.id_adj_out_sample = '" + id_report + "' "
                Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")

                Dim jum_ins_i As Integer = 0
                Dim query_drawer_stock As String = ""
                If data.Rows.Count > 0 Then
                    query_drawer_stock = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, id_sample_price, sample_price, qty_sample, datetime_storage_sample, storage_sample_notes, report_mark_type, id_report, id_stock_status) VALUES "
                End If
                For i As Integer = 0 To (data.Rows.Count - 1)
                    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                    Dim id_sample As String = data.Rows(i)("id_sample").ToString
                    Dim adj_out_sample_det_qty As String = decimalSQL(data.Rows(i)("adj_out_sample_det_qty").ToString)
                    Dim adj_out_sample_number As String = data.Rows(i)("adj_out_sample_number").ToString
                    Dim id_sample_price As String = data.Rows(i)("id_sample_price").ToString
                    Dim adj_out_sample_det_price As String = decimalSQL(data.Rows(i)("adj_out_sample_det_price").ToString)

                    'insert stock
                    If jum_ins_i > 0 Then
                        query_drawer_stock += ", "
                    End If
                    query_drawer_stock += "('" + id_wh_drawer + "', '1', '" + id_sample + "', '" + id_sample_price + "', '" + adj_out_sample_det_price + "','" + adj_out_sample_det_qty + "', NOW(), 'Adjusment Out Cancelled Order No: " + adj_out_sample_number + "', '21', '" + id_report + "', '2') "
                    jum_ins_i = jum_ins_i + 1
                Next
                If jum_ins_i > 0 Then
                    execute_non_query(query_drawer_stock, True, "", "", "", "")
                End If
            ElseIf id_status_reportx = 6 Then
                Dim query_cancel As String = "SELECT * FROM tb_adj_out_sample a "
                query_cancel += "INNER JOIN tb_adj_out_sample_det b ON a.id_adj_out_sample = b.id_adj_out_sample "
                query_cancel += "WHERE a.id_adj_out_sample = '" + id_report + "' "
                Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")

                Dim jum_ins_i As Integer = 0
                Dim query_drawer_stock As String = ""
                Dim query_drawer_stock2 As String = ""
                If data.Rows.Count > 0 Then
                    query_drawer_stock = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, id_sample_price, sample_price, qty_sample, datetime_storage_sample, storage_sample_notes, report_mark_type, id_report, id_stock_status) VALUES "
                    query_drawer_stock2 = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, id_sample_price, sample_price, qty_sample, datetime_storage_sample, storage_sample_notes, report_mark_type, id_report, id_stock_status) VALUES "
                End If
                For i As Integer = 0 To (data.Rows.Count - 1)
                    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                    Dim id_sample As String = data.Rows(i)("id_sample").ToString
                    Dim adj_out_sample_det_qty As String = decimalSQL(data.Rows(i)("adj_out_sample_det_qty").ToString)
                    Dim adj_out_sample_number As String = data.Rows(i)("adj_out_sample_number").ToString
                    Dim id_sample_price As String = data.Rows(i)("id_sample_price").ToString
                    Dim adj_out_sample_det_price As String = decimalSQL(data.Rows(i)("adj_out_sample_det_price").ToString)

                    'insert stock
                    If jum_ins_i > 0 Then
                        query_drawer_stock += ", "
                        query_drawer_stock2 += ", "
                    End If
                    query_drawer_stock += "('" + id_wh_drawer + "', '1', '" + id_sample + "', '" + id_sample_price + "', '" + adj_out_sample_det_price + "','" + adj_out_sample_det_qty + "', NOW(), 'Adjusment Out Completed Order No: " + adj_out_sample_number + "', '21', '" + id_report + "', '2') "
                    query_drawer_stock2 += "('" + id_wh_drawer + "', '2', '" + id_sample + "', '" + id_sample_price + "', '" + adj_out_sample_det_price + "','" + adj_out_sample_det_qty + "', NOW(), 'Adjusment Out Completed Order No: " + adj_out_sample_number + "', '21', '" + id_report + "', '1') "
                    jum_ins_i = jum_ins_i + 1
                Next
                If jum_ins_i > 0 Then
                    execute_non_query(query_drawer_stock, True, "", "", "", "")
                    execute_non_query(query_drawer_stock2, True, "", "", "", "")
                End If

            End If

            query = String.Format("UPDATE tb_adj_out_sample SET id_report_status='{0}' WHERE id_adj_out_sample='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            'Try
            If form_origin = "FormSampleAdjustmentOutSingle" Then
                FormSampleAdjustmentOutSingle.id_adj_out_sample = id_report
                FormSampleAdjustmentOutSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSampleAdjustmentOutSingle.action = "upd"
                FormSampleAdjustmentOutSingle.id_report_status = id_status_reportx
                FormSampleAdjustmentOutSingle.actionLoad()
                FormSampleAdjustment.viewAdjOutSample()
                FormSampleAdjustment.GVAdjOutSample.FocusedRowHandle = find_row(FormSampleAdjustment.GVAdjOutSample, "id_adj_out_sample", id_report)
            ElseIf form_origin = "FormViewSampleAdjOut" Then
                FormViewSampleAdjOut.id_adj_out_sample = id_report
                FormViewSampleAdjOut.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormViewSampleAdjOut.action = "upd"
                FormViewSampleAdjOut.id_report_status = id_status_reportx
                FormViewSampleAdjOut.actionLoad()
            End If
            'Catch ex As Exception
            'End Try
        ElseIf report_mark_type = "22" Then
            'Production Order
            '
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If
            '
            query = String.Format("UPDATE tb_prod_order SET id_report_status='{0}' WHERE id_prod_order='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            '
            query = String.Format("UPDATE tb_prod_order_wo SET id_report_status='{0}' WHERE id_prod_order='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            '
            If id_status_reportx = "5" Then
                query = String.Format("UPDATE tb_m_design SET pp_is_approve='2',final_is_approve='2' WHERE id_design=(SELECT pdd.id_design FROM tb_prod_order po INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design` WHERE po.`id_prod_order`='{0}' LIMIT 1)", id_report)
                execute_non_query(query, True, "", "", "", "")
            End If
            '
            'infoCustom("Status changed.")
            '
            If id_status_reportx = "6" Then
                Dim nm As New ClassSendEmail
                nm.id_report = id_report
                nm.report_mark_type = report_mark_type
                nm.send_email()
            End If

            Try
                FormProductionDet.id_report_status_g = id_status_reportx
                FormProductionDet.allow_status()
                FormProduction.view_production_order()
                FormProduction.GVProd.FocusedRowHandle = find_row(FormProduction.GVProd, "id_prod_order", id_report)
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "23" Then
            'Production Work Order
            Try
                If id_status_reportx = "6" Then
                    Dim query_upd_contact As String = ""
                    query_upd_contact += "Update tb_prod_order pdo INNER JOIN ( "
                    query_upd_contact += "Select If(wo.is_main_vendor ='1', ovh_prc.id_comp_contact,NULL) AS id_comp_contact, wo.id_prod_order "
                    query_upd_contact += "From tb_prod_order_wo wo "
                    query_upd_contact += "INNER Join tb_m_ovh_price ovh_prc On wo.id_ovh_price = ovh_prc.id_ovh_price "
                    query_upd_contact += "WHERE wo.id_prod_order_wo ='" + id_report + "' "
                    query_upd_contact += ") wo On pdo.id_prod_order = wo.id_prod_order "
                    query_upd_contact += "SET pdo.id_comp_contact_main=wo.id_comp_contact "
                    execute_non_query(query_upd_contact, True, "", "", "", "")
                End If

                query = String.Format("UPDATE tb_prod_order_wo Set id_report_status='{0}' WHERE id_prod_order_wo='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                ''infoCustom("Status changed.")

                FormProductionWO.id_report_status_g = id_status_reportx
                FormProductionWO.allow_status()
                FormProductionDet.view_wo()
                FormProductionDet.GVProdWO.FocusedRowHandle = find_row(FormProductionDet.GVProdWO, "id_prod_order_wo", id_report)
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "24" Then
            'Material PO PR
            query = String.Format("UPDATE tb_pr_mat_purc SET id_report_status='{0}' WHERE id_pr_mat_purc='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            Try
                If form_origin = "FormMatPRDet" Then
                    FormMatPRDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormMatPRDet.allow_status()
                    FormMatPR.view_mat_pr()
                    FormMatPR.view_mat_purc()
                    FormMatPR.view_mat_rec()
                Else
                    FormViewMatPR.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                End If
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "25" Then
            'Material WO PR
            query = String.Format("UPDATE tb_pr_mat_wo SET id_report_status='{0}' WHERE id_pr_mat_wo='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            Try
                If form_origin = "FormMatPRWODet" Then
                    FormMatPRWODet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormMatPRWODet.allow_status()
                    FormMatPRWO.view_mat_pr()
                    FormMatPRWO.view_mat_wo()
                    FormMatPRWO.view_mat_rec()
                Else
                    FormViewMatPRWO.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                End If
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "26" Then
            'Material Adj In

            query = String.Format("UPDATE tb_adj_in_mat SET id_report_status='{0}' WHERE id_adj_in_mat='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                Dim query_upd_storage As String = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_mat_det_price,price,id_stock_status,report_mark_type,id_report)
SELECT adjd.id_wh_drawer,1,adjd.id_mat_det,adjd.adj_in_mat_det_qty,NOW(),adj.adj_in_mat_note,adjd.id_mat_det_price,adjd.adj_in_mat_det_price,1,26,adjd.id_adj_in_mat
FROM
`tb_adj_in_mat_det` adjd
INNER JOIN tb_adj_in_mat adj ON adj.id_adj_in_mat=adjd.id_adj_in_mat
WHERE adjd.id_adj_in_mat='" & id_report & "'"
                execute_non_query(query_upd_storage, True, "", "", "", "")
            End If

            'infoCustom("Status changed.")
            Try
                If form_origin = "FormMatAdjInSingle" Then
                    FormMatAdjInSingle.id_adj_in_mat = id_report
                    FormMatAdjInSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormMatAdjInSingle.action = "upd"
                    FormMatAdjInSingle.id_report_status = id_status_reportx
                    FormMatAdjInSingle.actionLoad()
                    FormMatAdj.viewAdjIn()
                ElseIf form_origin = "FormViewMatAdjIn" Then
                    FormViewMatAdjIn.id_adj_in_mat = id_report
                    FormViewMatAdjIn.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormViewMatAdjIn.action = "upd"
                    FormViewMatAdjIn.id_report_status = id_status_reportx
                    FormViewMatAdjIn.actionLoad()
                End If
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "27" Then
            'Material Adj Out
            Cursor = Cursors.WaitCursor

            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = 5 Then 'Cancel
                Dim query_cancel As String = "SELECT * FROM tb_adj_out_mat a "
                query_cancel += "INNER JOIN tb_adj_out_mat_det b ON a.id_adj_out_mat = b.id_adj_out_mat "
                query_cancel += "WHERE a.id_adj_out_mat = '" + id_report + "' "
                Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                For i As Integer = 0 To (data.Rows.Count - 1)
                    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                    Dim id_mat_det As String = data.Rows(i)("id_mat_det").ToString
                    Dim adj_out_mat_det_qty As Decimal = data.Rows(i)("adj_out_mat_det_qty")
                    Dim id_mat_det_price As String = data.Rows(i)("id_mat_det_price").ToString
                    Dim adj_out_mat_det_price As Decimal = data.Rows(i)("adj_out_mat_det_price")
                    Dim adj_out_mat_number As String = data.Rows(i)("adj_out_mat_number").ToString
                    Dim query_upd_storage As String = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_mat_det_price,price,id_stock_status,report_mark_type,id_report) "
                    query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_mat_det + "', '" + decimalSQL(adj_out_mat_det_qty.ToString) + "', NOW(), 'Material Adjustment Out cancelled, Adjustment Out : " + adj_out_mat_number + "','" & id_mat_det_price & "','" & decimalSQL(adj_out_mat_det_price.ToString) & "','2','27','" & id_report & "')"
                    execute_non_query(query_upd_storage, True, "", "", "", "")
                Next
            ElseIf id_status_reportx = 6 Then 'completed
                ''stock
                'Dim query_cancel As String = "SELECT * FROM tb_adj_out_mat a "
                'query_cancel += "INNER JOIN tb_adj_out_mat_det b ON a.id_adj_out_mat = b.id_adj_out_mat "
                'query_cancel += "WHERE a.id_adj_out_mat = '" + id_report + "' "
                'Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                'For i As Integer = 0 To (data.Rows.Count - 1)
                '    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                '    Dim id_mat_det As String = data.Rows(i)("id_mat_det").ToString
                '    Dim adj_out_mat_det_qty As Decimal = data.Rows(i)("adj_out_mat_det_qty")
                '    Dim id_mat_det_price As String = data.Rows(i)("id_mat_det_price").ToString
                '    Dim adj_out_mat_det_price As Decimal = data.Rows(i)("adj_out_mat_det_price")
                '    Dim adj_out_mat_number As String = data.Rows(i)("adj_out_mat_number").ToString
                '    Dim query_upd_storage As String = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_mat_det_price,price,id_stock_status,report_mark_type,id_report) "
                '    query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_mat_det + "', '" + decimalSQL(adj_out_mat_det_qty.ToString) + "', NOW(), 'Completed, Adjustment Out : " + adj_out_mat_number + "','" & id_mat_det_price & "','" & decimalSQL(adj_out_mat_det_price.ToString) & "','2','27','" & id_report & "')"
                '    execute_non_query(query_upd_storage, True, "", "", "", "")

                '    query_upd_storage = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_mat_det_price,price,id_stock_status,report_mark_type,id_report) "
                '    query_upd_storage += "VALUES('" + id_wh_drawer + "', '2', '" + id_mat_det + "', '" + decimalSQL(adj_out_mat_det_qty.ToString) + "', NOW(), 'Completed, Adjustment Out : " + adj_out_mat_number + "','" & id_mat_det_price & "','" & decimalSQL(adj_out_mat_det_price.ToString) & "','1','27','" & id_report & "')"
                '    execute_non_query(query_upd_storage, True, "", "", "", "")
                'Next
                'batalkan reserved
                Dim query_upd_storage As String = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_mat_det_price,price,id_stock_status,report_mark_type,id_report)
SELECT adjd.id_wh_drawer,1,adjd.id_mat_det,adjd.adj_out_mat_det_qty,NOW(),adj.adj_out_mat_note,adjd.id_mat_det_price,adjd.adj_out_mat_det_price,2,27,adjd.id_adj_out_mat
FROM
`tb_adj_out_mat_det` adjd
INNER JOIN tb_adj_out_mat adj ON adj.id_adj_out_mat=adjd.id_adj_out_mat
WHERE adjd.id_adj_out_mat='" & id_report & "'"
                execute_non_query(query_upd_storage, True, "", "", "", "")
                'masukkan sebenarnya
                query_upd_storage = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_mat_det_price,price,id_stock_status,report_mark_type,id_report)
SELECT adjd.id_wh_drawer,2,adjd.id_mat_det,adjd.adj_out_mat_det_qty,NOW(),adj.adj_out_mat_note,adjd.id_mat_det_price,adjd.adj_out_mat_det_price,1,27,adjd.id_adj_out_mat
FROM
`tb_adj_out_mat_det` adjd
INNER JOIN tb_adj_out_mat adj ON adj.id_adj_out_mat=adjd.id_adj_out_mat
WHERE adjd.id_adj_out_mat='" & id_report & "'"
                execute_non_query(query_upd_storage, True, "", "", "", "")
            End If

            query = String.Format("UPDATE tb_adj_out_mat SET id_report_status='{0}' WHERE id_adj_out_mat='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            If form_origin = "FormMatAdjOutSingle" Then
                FormMatAdjOutSingle.id_adj_out_mat = id_report
                FormMatAdjOutSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormMatAdjOutSingle.action = "upd"
                FormMatAdjOutSingle.id_report_status = id_status_reportx
                FormMatAdjOutSingle.actionLoad()
                FormMatAdj.viewAdjOut()
            ElseIf form_origin = "FormViewMatAdjOut" Then
                FormViewMatAdjOut.id_adj_out_mat = id_report
                FormViewMatAdjOut.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormViewMatAdjOut.action = "upd"
                FormViewMatAdjOut.id_report_status = id_status_reportx
                FormViewMatAdjOut.actionLoad()
            End If
            Cursor = Cursors.Default
        ElseIf report_mark_type = "28" Or report_mark_type = "127" Then
            'prod receive qc
            'auto completed
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                'generate unique
                Dim query_gen As String = "CALL generate_prod_unique('" & id_report & "',1)"
                execute_non_query(query_gen, True, "", "", "", "")
                'delete empty data
                For i As Integer = 0 To (FormProductionRecDet.GVListPurchase.RowCount - 1)
                    Dim id_prod_order_rec_det As String = FormProductionRecDet.GVListPurchase.GetRowCellValue(i, "id_prod_order_rec_det").ToString
                    Dim qty As Decimal = FormProductionRecDet.GVListPurchase.GetRowCellValue(i, "prod_order_rec_det_qty")
                    If qty = 0.0 Then
                        Dim query_del As String = "DELETE FROM tb_prod_order_rec_det WHERE id_prod_order_rec_det = '" + id_prod_order_rec_det + "'"
                        execute_non_query(query_del, True, "", "", "", "")
                    End If
                Next
                '
                query = String.Format("UPDATE tb_prod_order_rec SET complete_date=NOW() WHERE id_prod_order_rec='{0}'", id_report)
                execute_non_query(query, True, "", "", "", "")
            End If

            query = String.Format("UPDATE tb_prod_order_rec SET id_report_status='{0}' WHERE id_prod_order_rec='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")

            If form_origin = "FormProductionRecDet" Then
                FormProductionRecDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormProductionRecDet.allow_status()
                FormProductionRecDet.view_list_rec()
                FormProductionRec.view_prod_order_rec()
                FormProductionRec.GVProdRec.FocusedRowHandle = find_row(FormProductionRec.GVProdRec, "id_prod_order_rec", id_report)
            Else
                FormViewProductionRec.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
            End If
        ElseIf report_mark_type = "29" Then
            'Production MRS
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            query = String.Format("UPDATE tb_prod_order_mrs SET id_report_status='{0}' WHERE id_prod_order_mrs='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            Try
                FormProductionMRS.id_report_status_g = id_status_reportx
                FormProductionMRS.allow_status()
                FormProductionDet.view_mrs()
                FormProductionDet.GVMRS.FocusedRowHandle = find_row(FormProductionDet.GVMRS, "id_prod_order_mrs", id_report)
                '
                FormMatMRSDet.id_report_status_g = id_status_reportx
                FormMatMRSDet.allow_status()
                FormMatMRSDet.view_mrs()
                FormMatMRS.GVMRS.FocusedRowHandle = find_row(FormMatMRS.GVMRS, "id_prod_order_mrs", id_report)
                '
                FormMaterialRequisition.view_mrs()
                FormMaterialRequisition.GVMRS.FocusedRowHandle = find_row(FormMaterialRequisition.GVMRS, "id_prod_order_mrs", id_report)
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "30" Then
            'PL MRS Production
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If
            '
            If id_status_reportx = 5 Then 'Cancel
                'cek jika batal dari completed
                Dim qc As String = "SELECT id_report_status FROM tb_pl_mrs WHERE id_pl_mrs='" & id_report & "'"
                Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
                If dtc.Rows(0)("id_report_status").ToString = "6" Then
                    'stock
                    Dim query_cancel As String = "SELECT b.*,p.`id_mat_det`,a.`pl_mrs_number` FROM tb_pl_mrs a
                                                INNER JOIN tb_pl_mrs_det b ON a.id_pl_mrs = b.id_pl_mrs
                                                INNER JOIN tb_m_mat_det_price p ON b.`id_mat_det_price`=p.`id_mat_det_price`
                                                INNER JOIN tb_prod_order_mrs_det c ON b.id_prod_order_mrs_det = c.id_prod_order_mrs_det
                                                WHERE a.id_pl_mrs ='" + id_report + "' "
                    Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                    For i As Integer = 0 To (data.Rows.Count - 1)
                        Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                        Dim id_mat_det As String = data.Rows(i)("id_mat_det").ToString
                        Dim pl_mrs_det_qty As String = decimalSQL(data.Rows(i)("pl_mrs_det_qty").ToString)
                        Dim pl_mrs_number As String = data.Rows(i)("pl_mrs_number").ToString
                        Dim pl_mrs_det_price As Decimal = data.Rows(i)("pl_mrs_det_price")
                        Dim id_mat_det_pricex As String = data.Rows(i)("id_mat_det_price").ToString
                        Dim query_upd_storage As String = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det,id_mat_det_price, price, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_stock_status,report_mark_type,id_report) "
                        query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_mat_det + "','" + id_mat_det_pricex + "','" + decimalSQL(pl_mrs_det_price.ToString) + "', '" + decimalSQL(pl_mrs_det_qty.ToString) + "', NOW(), 'Out material was cancelled, PL : " + pl_mrs_number + "','1','" + report_mark_type + "','" + id_report + "')"
                        execute_non_query(query_upd_storage, True, "", "", "", "")
                    Next
                Else
                    'stock
                    Dim query_cancel As String = "SELECT b.*,p.`id_mat_det`,a.`pl_mrs_number` FROM tb_pl_mrs a
                                                INNER JOIN tb_pl_mrs_det b ON a.id_pl_mrs = b.id_pl_mrs
                                                INNER JOIN tb_m_mat_det_price p ON b.`id_mat_det_price`=p.`id_mat_det_price`
                                                INNER JOIN tb_prod_order_mrs_det c ON b.id_prod_order_mrs_det = c.id_prod_order_mrs_det
                                                WHERE a.id_pl_mrs ='" + id_report + "' "
                    Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                    For i As Integer = 0 To (data.Rows.Count - 1)
                        Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                        Dim id_mat_det As String = data.Rows(i)("id_mat_det").ToString
                        Dim pl_mrs_det_qty As String = decimalSQL(data.Rows(i)("pl_mrs_det_qty").ToString)
                        Dim pl_mrs_number As String = data.Rows(i)("pl_mrs_number").ToString
                        Dim pl_mrs_det_price As Decimal = data.Rows(i)("pl_mrs_det_price")
                        Dim id_mat_det_pricex As String = data.Rows(i)("id_mat_det_price").ToString
                        Dim query_upd_storage As String = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det,id_mat_det_price, price, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_stock_status,report_mark_type,id_report) "
                        query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_mat_det + "','" + id_mat_det_pricex + "','" + decimalSQL(pl_mrs_det_price.ToString) + "', '" + decimalSQL(pl_mrs_det_qty) + "', NOW(), 'Out material was cancelled, PL : " + pl_mrs_number + "','2','" + report_mark_type + "','" + id_report + "')"
                        execute_non_query(query_upd_storage, True, "", "", "", "")
                    Next
                End If

            ElseIf id_status_reportx = 6 Then 'completed
                'stock
                Dim query_cancel As String = "SELECT b.*,p.`id_mat_det`,a.`pl_mrs_number` FROM tb_pl_mrs a
                                                INNER JOIN tb_pl_mrs_det b ON a.id_pl_mrs = b.id_pl_mrs
                                                INNER JOIN tb_m_mat_det_price p ON b.`id_mat_det_price`=p.`id_mat_det_price`
                                                INNER JOIN tb_prod_order_mrs_det c ON b.id_prod_order_mrs_det = c.id_prod_order_mrs_det
                                                WHERE a.id_pl_mrs = '" + id_report + "' "
                Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                For i As Integer = 0 To (data.Rows.Count - 1)
                    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                    Dim id_mat_det As String = data.Rows(i)("id_mat_det").ToString
                    Dim pl_mrs_det_qty As Decimal = data.Rows(i)("pl_mrs_det_qty")
                    Dim pl_mrs_number As String = data.Rows(i)("pl_mrs_number").ToString
                    Dim pl_mrs_det_price As Decimal = data.Rows(i)("pl_mrs_det_price")
                    Dim id_mat_det_pricex As String = data.Rows(i)("id_mat_det_price").ToString
                    Dim query_upd_storage As String = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det,id_mat_det_price, price, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_stock_status,report_mark_type,id_report) "
                    query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_mat_det + "','" + id_mat_det_pricex + "','" + decimalSQL(pl_mrs_det_price.ToString) + "', '" + decimalSQL(pl_mrs_det_qty.ToString) + "', NOW(), 'Completion of packing list, PL : " + pl_mrs_number + "','2','" + report_mark_type + "','" + id_report + "')"
                    execute_non_query(query_upd_storage, True, "", "", "", "")
                    query_upd_storage = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det,id_mat_det_price, price, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_stock_status,report_mark_type,id_report) "
                    query_upd_storage += "VALUES('" + id_wh_drawer + "', '2', '" + id_mat_det + "','" + id_mat_det_pricex + "','" + decimalSQL(pl_mrs_det_price.ToString) + "', '" + decimalSQL(pl_mrs_det_qty.ToString) + "', NOW(), 'Completion of packing list, PL : " + pl_mrs_number + "','1','" + report_mark_type + "','" + id_report + "')"
                    execute_non_query(query_upd_storage, True, "", "", "", "")
                Next
            End If

            query = String.Format("UPDATE tb_pl_mrs SET id_report_status='{0}' WHERE id_pl_mrs='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            Try
                FormMatPLSingle.id_report_status = id_status_reportx
                FormMatPLSingle.actionLoad()
                If FormMatPL.XTCPL.SelectedTabPageIndex = 0 Then 'production
                    FormMatPL.viewPL()
                    FormMatPL.GVProdPL.FocusedRowHandle = find_row(FormMatPL.GVProdPL, "id_pl_mrs", id_report)
                ElseIf FormMatPL.XTCPL.SelectedTabPageIndex = 1 Then 'wo
                    FormMatPL.viewPLWO()
                    FormMatPL.GVPLWO.FocusedRowHandle = find_row(FormMatPL.GVPLWO, "id_pl_mrs", id_report)
                Else 'other
                    FormMatPL.viewPLOther()
                    FormMatPL.GVPLOther.FocusedRowHandle = find_row(FormMatPL.GVPLOther, "id_pl_mrs", id_report)
                End If
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "31" Then
            'Return Out FG
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            'update status
            query = String.Format("UPDATE tb_prod_order_ret_out SET id_report_status='{0}' WHERE id_prod_order_ret_out ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")

            'delete qty =0
            If id_status_reportx > "2" Then
                Dim query_del As String = "DELETE FROM tb_prod_order_ret_out_det WHERE id_prod_order_ret_out='" + id_report + "' AND prod_order_ret_out_det_qty<='0.00' "
                execute_non_query(query_del, True, "", "", "", "")
            End If

            If id_status_reportx = "6" Then
                query = String.Format("UPDATE tb_prod_order_ret_out SET complete_date=NOW() WHERE id_prod_order_ret_out ='{0}'", id_report)
                execute_non_query(query, True, "", "", "", "")
            End If

            Try
                If form_origin = "FormProductionRetOutSingle" Then
                    FormProductionRetOutSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormProductionRetOutSingle.check_but()
                    FormProductionRetOutSingle.actionLoad()
                    FormProductionRet.viewRetOut()
                Else
                    FormViewProductionRetOut.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                End If
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "32" Then
            'Return IN FG
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            query = String.Format("UPDATE tb_prod_order_ret_in SET id_report_status='{0}' WHERE id_prod_order_ret_in ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            '
            If id_status_reportx = "6" Then
                query = String.Format("UPDATE tb_prod_order_ret_in SET complete_date=NOW() WHERE id_prod_order_ret_in ='{0}'", id_report)
                execute_non_query(query, True, "", "", "", "")
            End If
            '
            Try
                If form_origin = "FormProductionRetInSingle" Then
                    FormProductionRetInSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormProductionRetInSingle.check_but()
                    FormProductionRetInSingle.actionLoad()
                    FormProductionRet.viewRetIn()
                Else
                    'FormViewProductionRetIn.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    'FormWork.view_production_ret_in()
                End If
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "33" Then
            'PL FG TO WH
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            query = String.Format("UPDATE tb_pl_prod_order SET id_report_status='{0}' WHERE id_pl_prod_order ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            '
            If id_status_reportx = "6" Then
                query = String.Format("UPDATE tb_pl_prod_order SET complete_date=NOW() WHERE id_pl_prod_order ='{0}'", id_report)
                execute_non_query(query, True, "", "", "", "")
            End If

            Try
                If form_origin = "FormProductionPLToWHDet" Then
                    FormProductionPLToWHDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormProductionPLToWHDet.check_but()
                    FormProductionPLToWHDet.actionLoad()
                    FormProductionPLToWH.viewPL()
                Else

                End If
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "34" Then
            'Invoice Mat PL MRS
            query = String.Format("UPDATE tb_inv_pl_mrs SET id_report_status='{0}' WHERE id_inv_pl_mrs ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            Try
                FormMatInvoiceDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormMatInvoiceDet.id_report_status_g = id_status_reportx
                FormMatInvoiceDet.allow_status()
                FormMatInvoice.viewInv()
                FormMatInvoice.GVProdInvoice.FocusedRowHandle = find_row(FormMatInvoice.GVProdInvoice, "id_inv_pl_mrs", id_report)
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "35" Then
            'Retur invoice Mat PL MRS
            query = String.Format("UPDATE tb_inv_pl_mrs_ret SET id_report_status='{0}' WHERE id_inv_pl_mrs_ret ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            Try
                FormMatInvoiceReturDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormMatInvoiceReturDet.id_report_status_g = id_status_reportx
                FormMatInvoiceReturDet.allow_status()
                FormMatInvoice.view_retur()
                FormMatInvoice.GVProdInvoice.FocusedRowHandle = find_row(FormMatInvoice.GVProdInvoice, "id_inv_pl_mrs_ret", id_report)
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "36" Then
            'Journal Entry
            If id_status_reportx = 3 Then
                id_status_reportx = 6
            End If

            If id_status_reportx = "6" Then
                Dim qu As String = "CALL update_status_trans_journal(" + id_report + ")"
                execute_non_query(qu, True, "", "", "", "")
            End If

            query = String.Format("UPDATE tb_a_acc_trans SET id_report_status='{0}' WHERE id_acc_trans ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")

            If form_origin = "FormAccountingJournalBill" Then
                FormAccountingJournalBill.actionLoad()
                FormAccountingJournal.view_entry()
                FormAccountingJournal.GVAccTrans.FocusedRowHandle = find_row(FormAccountingJournal.GVAccTrans, "id_acc_trans", id_report)
            Else
                Try
                    FormAccountingJournalDet.id_report_status_g = id_status_reportx
                    FormAccountingJournalDet.allow_status()
                    FormAccountingJournal.view_entry()
                    FormAccountingJournal.GVAccTrans.FocusedRowHandle = find_row(FormAccountingJournal.GVAccTrans, "id_acc_trans", id_report)
                Catch ex As Exception
                End Try
            End If

        ElseIf report_mark_type = "37" Then
            'Rec PL FG TO WH
            Try
                Dim ch_stt As ClassProductionPLToWHRec = New ClassProductionPLToWHRec()
                ch_stt.changeStatus(id_report, id_status_reportx)

                'infoCustom("Status changed.")

                FormProductionPLToWHRecDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormProductionPLToWHRecDet.check_but()
                FormProductionPLToWHRecDet.actionLoad()
                FormProductionPLToWHRec.viewPL()
                FormProductionPLToWHRec.view_sample_purc()
            Catch ex As Exception
                errorProcess()
            End Try
        ElseIf report_mark_type = "39" Or report_mark_type = "130" Then
            'SALES Order
            If id_status_reportx = "3" Then 'kalo approved langsung completed
                id_status_reportx = "6"
            End If

            If id_status_reportx = "5" Then
                Dim cancel As New ClassSalesOrder()
                cancel.cancelReservedStock(id_report)
            ElseIf id_status_reportx = "6" Then
                'check stock
                Dim cond_invalid_stock As Boolean = False
                If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                    FormMain.SplashScreenManager1.ShowWaitForm()
                End If
                FormMain.SplashScreenManager1.SetWaitFormDescription("Checking stock")
                Dim id_wh_so As String = FormSalesOrderDet.id_comp_par
                Dim qcs As String = "SELECT p.product_full_code AS `code`, p.product_display_name AS `description`, cd.code_detail_name AS `size`, a.available_qty,
                IF(a.available_qty>=0,'OK', 'Not Valid') AS `status` 
                FROM (
	                SELECT f.id_product,
	                SUM(IF(f.id_storage_category=2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)) AS `available_qty`
	                FROM tb_storage_fg f
	                INNER JOIN tb_m_wh_drawer drw ON  drw.id_wh_drawer= f.id_wh_drawer
	                INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack
	                INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator
	                INNER JOIN tb_m_comp c ON c.id_comp = loc.id_comp AND c.id_comp=" + id_wh_so + "
	                WHERE f.id_product IN (
		                SELECT d.id_product
		                FROM tb_sales_order_det d
		                WHERE d.id_sales_order=" + id_report + "
		                GROUP BY d.id_product
	                )
	                GROUP BY f.id_product
                ) a
                INNER JOIN tb_m_product p ON p.id_product = a.id_product
                INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
                INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail "
                Dim dsc As DataTable = execute_query(qcs, -1, True, "", "", "", "")
                Dim dsc_filter As DataRow() = dsc.Select("[status]<>'OK' ")
                If dsc_filter.Length > 0 Then
                    cond_invalid_stock = True
                End If
                FormMain.SplashScreenManager1.CloseWaitForm()
                If cond_invalid_stock Then
                    stopCustom("There is invalid stock in this order, click OK to see details")
                    FormValidateStock.dt = dsc
                    FormValidateStock.ShowDialog()
                    Exit Sub
                End If

                'created transfer
                'AND c.id_comp IN (SELECT id_comp FROM tb_wh_auto_trf) AND cf.id_comp IN (SELECT id_comp FROM tb_wh_auto_trf)
                Dim qv As String = "SELECT so.id_warehouse_contact_to, so.id_store_contact_to, so.id_sales_order, c.id_drawer_def
                FROM tb_sales_order so
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = so.id_store_contact_to
                INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
                INNER JOIN tb_m_comp_contact ccf ON ccf.id_comp_contact = so.id_warehouse_contact_to
                INNER JOIN tb_m_comp cf ON cf.id_comp = ccf.id_comp
                WHERE so.id_sales_order=" + id_report + " AND so.id_so_status=5 AND so.is_transfer_data=1 "
                Dim dtv As DataTable = execute_query(qv, -1, True, "", "", "", "")
                If dtv.Rows.Count > 0 Then
                    For m As Integer = 0 To dtv.Rows.Count - 1
                        'main
                        Dim qm As String = "INSERT INTO tb_fg_trf(id_comp_contact_from, id_comp_contact_to, id_sales_order, fg_trf_number, fg_trf_date, fg_trf_date_rec, fg_trf_note, id_report_status, id_report_status_rec, id_wh_drawer, last_update, last_update_by)
                        VALUES('" + dtv.Rows(m)("id_warehouse_contact_to").ToString + "', '" + dtv.Rows(m)("id_store_contact_to").ToString + "', '" + dtv.Rows(m)("id_sales_order").ToString + "', '', NOW(), NOW(), '', '3', '3', '" + dtv.Rows(m)("id_drawer_def").ToString + "', NOW(), " + id_user + "); SELECT LAST_INSERT_ID(); "
                        Dim id_so As String = execute_query(qm, 0, True, "", "", "", "")
                        execute_non_query("CALL gen_number(" + id_so + ", 57)", True, "", "", "", "")
                        'increase_inc_sales("15")

                        'detail
                        Dim qd As String = "INSERT INTO tb_fg_trf_det(id_fg_trf, id_product, id_sales_order_det, fg_trf_det_qty, fg_trf_det_qty_rec, fg_trf_det_qty_stored, fg_trf_det_note)
                        SELECT '" + id_so + "', sd.id_product, sd.id_sales_order_det, sd.sales_order_det_qty, sd.sales_order_det_qty, sd.sales_order_det_qty,''
                        FROM tb_sales_order_det sd
                        WHERE sd.id_sales_order=" + dtv.Rows(m)("id_sales_order").ToString + " "
                        execute_non_query(qd, -1, True, "", "", "")

                        'completed
                        Dim stt As ClassFGTrf = New ClassFGTrf()
                        stt.changeStatus(id_so, "6")

                        'final comment
                        Dim query_comment As String = "INSERT INTO tb_report_mark_final_comment(report_mark_type, id_report, id_report_status, id_user, final_comment, final_comment_date, ip_user) VALUES "
                        query_comment += "('57', '" + id_so + "', '6', '" + id_user + "', '', NOW(), '" + GetIPv4AddressPublic() + "') "
                        execute_non_query(query_comment, True, "", "", "", "")
                    Next
                End If
            End If

            query = String.Format("UPDATE tb_sales_order SET id_report_status='{0}' WHERE id_sales_order ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'jika online store cek GWP
            If FormSalesOrderDet.id_commerce_type = "2" And id_status_reportx = "6" Then
                Dim id_store_group As String = execute_query("SELECT id_comp_group FROM tb_m_comp WHERE id_comp='" + FormSalesOrderDet.id_store + "'", 0, True, "", "", "", "")
                execute_non_query("CALL create_ol_gwp_order(" + id_store_group + ", '" + addSlashes(FormSalesOrderDet.TxtOLShopNumber.Text) + "')", True, "", "", "", "")
            End If

            'infoCustom("Status changed.")
            'Try
            If form_origin = "FormSalesOrderDet" Then
                FormSalesOrderDet.exportToBOF(False)
                FormSalesOrderDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSalesOrderDet.check_but()
                FormSalesOrderDet.actionLoad()
                FormSalesOrder.viewSalesOrder()
                FormSalesOrder.GVSalesOrder.FocusedRowHandle = find_row(FormSalesOrder.GVSalesOrder, "id_sales_order", id_report)
            Else

            End If
            'Catch ex As Exception
            'End Try
        ElseIf report_mark_type = "40" Then
            'Entry Journal
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                ' date
                Dim q_d As String = "SELECT id_report,report_mark_type,report_number,acc_trans_adj_number,date_created,date_reffrence,id_acc_trans FROM tb_a_acc_trans_adj WHERE id_acc_trans_adj='" & id_report & "'"
                Dim dt_d As DataTable = execute_query(q_d, -1, True, "", "", "", "")

                Dim date_created As String = Date.Parse(dt_d.Rows(0)("date_created").ToString).ToString("yyyy-MM-dd")
                Dim id_trans As String = dt_d.Rows(0)("id_acc_trans").ToString
                Dim t_number As String = dt_d.Rows(0)("acc_trans_adj_number").ToString
                '
                Dim trx_number As String = dt_d.Rows(0)("report_number").ToString
                Dim trx_id As String = dt_d.Rows(0)("id_report").ToString
                Dim trx_rmt As String = dt_d.Rows(0)("report_mark_type").ToString

                ' select user prepared
                Dim qu As String = "SELECT rm.id_user, rm.report_number FROM tb_report_mark rm WHERE rm.report_mark_type=" + report_mark_type + " AND rm.id_report='" + id_report + "' AND rm.id_report_status=1 "
                Dim du As DataTable = execute_query(qu, -1, True, "", "", "", "")
                Dim id_user_prepared As String = du.Rows(0)("id_user").ToString
                Dim report_number As String = du.Rows(0)("report_number").ToString

                'main journal
                Dim qjm As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, acc_trans_note, id_report_status)
                VALUES ('','" + report_number + "','25','" + id_user_prepared + "', '" & date_created & "', 'Auto Posting', '6'); SELECT LAST_INSERT_ID(); "
                Dim id_acc_trans As String = execute_query(qjm, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id_acc_trans + ",36)", True, "", "", "", "")

                'det journal
                Dim qjd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, qty, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number,report_mark_type_ref, id_report_ref, report_number_ref, id_comp)
                    SELECT '" + id_acc_trans + "', a.id_acc, 0, a.credit AS debit, a.debit AS credit, a.acc_trans_det_note, '" + report_mark_type + "', '" + id_report + "', '" + t_number + "', '" + trx_rmt + "','" + trx_id + "','" + trx_number + "', 0
                    FROM tb_a_acc_trans_det a 
                    INNER JOIN tb_a_acc b ON a.id_acc=b.id_acc 
                    WHERE a.id_acc_trans='" + id_trans + "'
                    UNION ALL
                    SELECT '" + id_acc_trans + "', ad.id_acc, 0, ad.debit, ad.credit, ad.acc_trans_adj_det_note, '" + report_mark_type + "', '" + id_report + "', a.acc_trans_adj_number, a.report_mark_type,a.id_report,a.report_number, 0
                    FROM `tb_a_acc_trans_adj_det` ad
                    INNER JOIN tb_a_acc_trans_adj a ON a.id_acc_trans_adj=ad.id_acc_trans_adj
                    WHERE ad.`id_acc_trans_adj`='" + id_report + "'"
                execute_non_query(qjd, True, "", "", "", "")
                'set adjusted status
                qjd = "UPDATE tb_a_acc_trans SET is_adjusted='1' WHERE id_acc_trans='" & id_trans & "'"
                execute_non_query(qjd, True, "", "", "", "")
            End If

            query = String.Format("UPDATE tb_a_acc_trans_adj SET id_report_status='{0}' WHERE id_acc_trans_adj ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            Try
                FormAccountingJournalAdjDet.id_report_status_g = id_status_reportx
                FormAccountingJournalAdjDet.allow_status()
                FormAccountingJournalAdj.view_jurnal()
                FormAccountingJournalAdj.GVAccTrans.FocusedRowHandle = find_row(FormAccountingJournalAdj.GVAccTrans, "id_trans_adj", id_report)
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "41" Then
            'FG Adj In
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = 6 Then 'completed
                'Dim query_cancel As String = "SELECT * FROM tb_adj_in_fg a "
                'query_cancel += "INNER JOIN tb_adj_in_fg_det b ON a.id_adj_in_fg = b.id_adj_in_fg "
                'query_cancel += "WHERE a.id_adj_in_fg = '" + id_report + "' "
                'Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                'For i As Integer = 0 To (data.Rows.Count - 1)
                '    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                '    Dim id_product As String = data.Rows(i)("id_product").ToString
                '    Dim adj_in_fg_det_qty As String = decimalSQL(data.Rows(i)("adj_in_fg_det_qty").ToString)
                '    Dim adj_in_fg_det_price As String = decimalSQL(data.Rows(i)("adj_in_fg_det_price").ToString)
                '    Dim adj_in_fg_number As String = data.Rows(i)("adj_in_fg_number").ToString

                '    Dim query_upd_storage As String = ""
                '    query_upd_storage = "INSERT tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, storage_product_qty, storage_product_datetime, storage_product_notes,report_mark_type,id_report,id_stock_status) "
                '    query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_product + "'," + adj_in_fg_det_price + ",'" + adj_in_fg_det_qty + "', NOW(), 'Completed, Adjustment In : " + adj_in_fg_number + "','41','" & id_report & "','1')"
                '    execute_non_query(query_upd_storage, True, "", "", "", "")
                'Next

                Dim q As String = "INSERT tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, storage_product_qty, storage_product_datetime, storage_product_notes,report_mark_type,id_report,id_stock_status)
SELECT b.`id_wh_drawer`,'1',b.`id_product`,b.`adj_in_fg_det_price`,b.`adj_in_fg_det_qty`,NOW(),CONCAT('Completed, Adjustment In : ',a.`adj_in_fg_number`) AS note,'41',a.`id_adj_in_fg`,'1'
FROM tb_adj_in_fg a 
INNER JOIN tb_adj_in_fg_det b ON a.id_adj_in_fg = b.id_adj_in_fg 
WHERE a.id_adj_in_fg = '" & id_report & "'"
                execute_non_query(q, True, "", "", "", "")
            End If

            query = String.Format("UPDATE tb_adj_in_fg SET id_report_status='{0}' WHERE id_adj_in_fg = '{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            Try
                If form_origin = "FormFGAdjInDet" Then
                    FormFGAdjInDet.id_adj_in_fg = id_report
                    FormFGAdjInDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormFGAdjInDet.action = "upd"
                    FormFGAdjInDet.id_report_status = id_status_reportx
                    FormFGAdjInDet.actionLoad()
                    FormFGAdj.viewAdjIn()
                ElseIf form_origin = "FormViewFGAdjIn" Then
                    'FormViewFGAdjIn.id_adj_in_fg = id_report
                    'FormViewFGAdjIn.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    'FormViewFGAdjIn.action = "upd"
                    'FormViewFGAdjIn.id_report_status = id_status_reportx
                    'FormViewFGAdjIn.actionLoad()
                    'FormWork.viewMatAdjIn()
                End If
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "42" Then
            'FG Adj Out
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            Cursor = Cursors.WaitCursor
            If id_status_reportx = 5 Then 'Cancel
                'Dim query_cancel As String = "SELECT * FROM tb_adj_out_fg a "
                'query_cancel += "INNER JOIN tb_adj_out_fg_det b ON a.id_adj_out_fg = b.id_adj_out_fg "
                'query_cancel += "WHERE a.id_adj_out_fg = '" + id_report + "' "
                'Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                'For i As Integer = 0 To (data.Rows.Count - 1)
                '    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                '    Dim id_product As String = data.Rows(i)("id_product").ToString
                '    Dim adj_out_fg_det_qty As Decimal = data.Rows(i)("adj_out_fg_det_qty")
                '    Dim adj_out_fg_det_price As Decimal = data.Rows(i)("adj_out_fg_det_price")
                '    Dim adj_out_fg_number As String = data.Rows(i)("adj_out_fg_number").ToString
                '    Dim query_upd_storage As String = "INSERT tb_storage_fg(id_wh_drawer, id_storage_category, id_product, storage_product_qty, storage_product_datetime, storage_product_notes, bom_unit_price,id_stock_status,report_mark_type,id_report) "
                '    query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_product + "', '" + decimalSQL(adj_out_fg_det_qty.ToString) + "', NOW(), 'Finished Goods Out cancelled, Adjustment Out : " + adj_out_fg_number + "','" & decimalSQL(adj_out_fg_det_price.ToString) & "','2','42','" & id_report & "')"
                '    execute_non_query(query_upd_storage, True, "", "", "", "")
                'Next
                Dim qry As String = "INSERT tb_storage_fg(id_wh_drawer, id_storage_category, id_product, storage_product_qty, storage_product_datetime, storage_product_notes, bom_unit_price,id_stock_status,report_mark_type,id_report) 
                SELECT d.id_wh_drawer, '1', d.id_product, d.adj_out_fg_det_qty, NOW(), '',d.adj_out_fg_det_price,'2','42', d.id_adj_out_fg 
                FROM tb_adj_out_fg_det d
                WHERE d.id_adj_out_fg=" + id_report + " "
                execute_non_query(qry, True, "", "", "", "")
            ElseIf id_status_reportx = 6 Then 'completed
                'stock
                'Dim query_cancel As String = "SELECT * FROM tb_adj_out_fg a "
                'query_cancel += "INNER JOIN tb_adj_out_fg_det b ON a.id_adj_out_fg = b.id_adj_out_fg "
                'query_cancel += "WHERE a.id_adj_out_fg = '" + id_report + "' "
                'Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                'For i As Integer = 0 To (data.Rows.Count - 1)
                '    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                '    Dim id_product As String = data.Rows(i)("id_product").ToString
                '    Dim adj_out_fg_det_qty As Decimal = data.Rows(i)("adj_out_fg_det_qty")
                '    Dim adj_out_fg_det_price As Decimal = data.Rows(i)("adj_out_fg_det_price")
                '    Dim adj_out_fg_number As String = data.Rows(i)("adj_out_fg_number").ToString
                '    Dim query_upd_storage As String = "INSERT tb_storage_fg(id_wh_drawer, id_storage_category, id_product, storage_product_qty, storage_product_datetime, storage_product_notes, bom_unit_price,id_stock_status,report_mark_type,id_report) "
                '    query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_product + "', '" + decimalSQL(adj_out_fg_det_qty.ToString) + "', NOW(), 'Completed, Adjustment Out : " + adj_out_fg_number + "','" & decimalSQL(adj_out_fg_det_price.ToString) & "','2','42','" & id_report & "')"
                '    execute_non_query(query_upd_storage, True, "", "", "", "")

                '    query_upd_storage = "INSERT tb_storage_fg(id_wh_drawer, id_storage_category, id_product, storage_product_qty, storage_product_datetime, storage_product_notes, bom_unit_price, id_stock_status, report_mark_type, id_report) "
                '    query_upd_storage += "VALUES('" + id_wh_drawer + "', '2', '" + id_product + "', '" + decimalSQL(adj_out_fg_det_qty.ToString) + "', NOW(), 'Completed, Adjustment Out : " + adj_out_fg_number + "','" & decimalSQL(adj_out_fg_det_price.ToString) & "','1','42','" & id_report & "')"
                '    execute_non_query(query_upd_storage, True, "", "", "", "")
                'Next
                Dim qry As String = "INSERT tb_storage_fg(id_wh_drawer, id_storage_category, id_product, storage_product_qty, storage_product_datetime, storage_product_notes, bom_unit_price,id_stock_status,report_mark_type,id_report) 
                SELECT d.id_wh_drawer, '1', d.id_product, d.adj_out_fg_det_qty, NOW(), '',d.adj_out_fg_det_price,'2','42', d.id_adj_out_fg 
                FROM tb_adj_out_fg_det d
                WHERE d.id_adj_out_fg=" + id_report + " 
                UNION ALL
                SELECT d.id_wh_drawer, '2', d.id_product, d.adj_out_fg_det_qty, NOW(), '',d.adj_out_fg_det_price,'1','42', d.id_adj_out_fg 
                FROM tb_adj_out_fg_det d
                WHERE d.id_adj_out_fg=" + id_report + " "
                execute_non_query(qry, True, "", "", "", "")
            End If

            query = String.Format("UPDATE tb_adj_out_fg SET id_report_status='{0}' WHERE id_adj_out_fg='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            If form_origin = "FormFGAdjOutDet" Then
                FormFGAdjOutDet.id_adj_out_fg = id_report
                FormFGAdjOutDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormFGAdjOutDet.action = "upd"
                FormFGAdjOutDet.id_report_status = id_status_reportx
                FormFGAdjOutDet.actionLoad()
                FormFGAdj.viewAdjOut()
            End If
            Cursor = Cursors.Default
        ElseIf report_mark_type = "43" Then
            'SALES Del Order
            Dim stt As ClassSalesDelOrder = New ClassSalesDelOrder()
            stt.changeStatus(id_report, id_status_reportx)

            If FormViewSalesDelOrder.id_commerce_type = "2" Then
                stt.sendEmailConfirmation(id_report)
            End If
            'infoCustom("Status changed.")

            If form_origin = "FormSalesDelOrderDet" Then
                FormSalesDelOrderDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSalesDelOrderDet.check_but()
                FormSalesDelOrderDet.actionLoad()
                FormSalesDelOrder.viewSalesDelOrder()
                FormSalesDelOrder.GVSalesDelOrder.FocusedRowHandle = find_row(FormSalesDelOrder.GVSalesDelOrder, "id_pl_sales_order_del", id_report)
            Else
                'no code
            End If
        ElseIf report_mark_type = "44" Then
            'MRS WO
            query = String.Format("UPDATE tb_prod_order_mrs SET id_report_status='{0}' WHERE id_prod_order_mrs ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            Try
                FormMatMRSDet.id_report_status_g = id_status_reportx
                FormMatMRSDet.allow_status()
                If FormMatMRS.XTCMRS.SelectedTabPageIndex = 0 Then 'wo mat
                    FormMatMRS.view_mrs_wo()
                    FormMatMRS.GVMRSWO.FocusedRowHandle = find_row(FormMatMRS.GVMRSWO, "id_prod_order_mrs", id_report)
                ElseIf FormMatMRS.XTCMRS.SelectedTabPageIndex = 1 Then 'other
                    FormMatMRS.view_mrs()
                    FormMatMRS.GVMRS.FocusedRowHandle = find_row(FormMatMRS.GVMRS, "id_prod_order_mrs", id_report)
                End If
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "45" Then
            'SALES Return Order
            Try
                query = String.Format("UPDATE tb_sales_return_order SET id_report_status='{0}' WHERE id_sales_return_order ='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                'infoCustom("Status changed.")
            Catch ex As Exception
                errorConnection()
                Close()
            End Try

            If form_origin = "FormSalesReturnOrderDet" Then
                FormSalesReturnOrderDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSalesReturnOrderDet.check_but()
                FormSalesReturnOrderDet.actionLoad()
                FormSalesReturnOrder.viewSalesReturnOrder()
                FormSalesReturnOrder.GVSalesReturnOrder.FocusedRowHandle = find_row(FormSalesReturnOrder.GVSalesReturnOrder, "id_sales_return_order", id_report)
            Else
                'code here
            End If
        ElseIf report_mark_type = "46" Or report_mark_type = "111" Or report_mark_type = "113" Or report_mark_type = "120" Then
            'SALES RETURN
            If id_status_reportx = "3" And report_mark_type = "111" Then
                id_status_reportx = "6"
            End If

            If report_mark_type = "120" Then
                Dim stt As ClassSalesReturn = New ClassSalesReturn()
                stt.changeStatusOLStore(id_report, id_status_reportx)

                If id_status_reportx = "6" Then

                End If
            Else
                Dim stt As ClassSalesReturn = New ClassSalesReturn()
                stt.changeStatus(id_report, id_status_reportx)
            End If

            'infoCustom("Status changed.")

            Dim combine_number As String = ""
            If form_origin = "FormSalesReturnDet" Then
                combine_number = FormSalesReturnDet.TxtCombineNumber.Text
                FormSalesReturnDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSalesReturnDet.check_but()
                FormSalesReturnDet.actionLoad()
                FormSalesReturn.viewSalesReturn()
                FormSalesReturn.viewSalesReturnOrder()
                FormSalesReturn.GVSalesReturn.FocusedRowHandle = find_row(FormSalesReturn.GVSalesReturn, "id_sales_return", id_report)
            Else
                'code here
                combine_number = FormViewSalesReturn.TxtCombineNumber.Text
            End If

            'update status for related combine number
            If combine_number <> "" And report_mark_type <> "111" Then
                Dim query_upd_single As String = "UPDATE tb_sales_return SET id_report_status=" + id_status_reportx + ", last_update=NOW(), last_update_by=" + id_user + " WHERE combine_number='" + combine_number + "' AND id_sales_return!=" + id_report + " "
                execute_non_query(query_upd_single, True, "", "", "", "")
            End If
        ElseIf report_mark_type = "47" Then
            'Return Production
            query = String.Format("UPDATE tb_mat_prod_ret_in SET id_report_status='{0}' WHERE id_mat_prod_ret_in ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            If id_status_reportx = 6 Then 'Completed
                Dim query_del As String = "DELETE FROM tb_mat_prod_ret_in_det WHERE id_mat_prod_ret_in_det='" + id_report + "' AND mat_prod_ret_in_det_qty <= 0"
                execute_non_query(query_del, True, "", "", "", "")
                '
                Dim query_completed As String = "SELECT c.id_mat_det,b.id_mat_det_price,a.mat_prod_ret_in_det_price,a.mat_prod_ret_in_det_qty,d.id_wh_drawer,d.mat_prod_ret_in_number,IFNULL(cost.id_mat_det_price_cost,0) as id_mat_det_price_cost,IFNULL(cost.mat_det_price_cost,0.0) as mat_det_price_cost FROM tb_mat_prod_ret_in_det a "
                query_completed += "INNER JOIN tb_pl_mrs_det b ON a.id_pl_mrs_det = b.id_pl_mrs_det "
                query_completed += "INNER JOIN tb_m_mat_det_price c ON c.id_mat_det_price = b.id_mat_det_price "
                query_completed += "INNER JOIN tb_mat_prod_ret_in d ON d.id_mat_prod_ret_in = a.id_mat_prod_ret_in "
                query_completed += "LEFT JOIN( "
                query_completed += "SELECT id_mat_det_price as id_mat_det_price_cost,mat_det_price as mat_det_price_cost,id_mat_det FROM tb_m_mat_det_price WHERE is_default_cost=1 "
                query_completed += ") cost ON cost.id_mat_det=c.id_mat_det "
                query_completed += "WHERE a.id_mat_prod_ret_in = '" + id_report + "' "
                Dim data As DataTable = execute_query(query_completed, -1, True, "", "", "", "")
                For i As Integer = 0 To (data.Rows.Count - 1)
                    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                    Dim id_mat_det As String = data.Rows(i)("id_mat_det").ToString
                    Dim id_mat_det_price As String = data.Rows(i)("id_mat_det_price_cost").ToString
                    Dim mat_det_price As Decimal = data.Rows(i)("mat_det_price_cost")
                    Dim mat_wo_rec_det_qty As String = decimalSQL(Decimal.Parse(data.Rows(i)("mat_prod_ret_in_det_qty").ToString).ToString)
                    Dim mat_wo_rec_number As String = data.Rows(i)("mat_prod_ret_in_number").ToString
                    Dim query_upd_storage As String = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_report,report_mark_type,id_stock_status,id_mat_det_price,price) "
                    'update storage
                    query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_mat_det + "', '" + mat_wo_rec_det_qty + "', NOW(), 'Completed, Material Return In Production Receive No. : " + mat_wo_rec_number + "','" + id_report + "','" + report_mark_type + "','1','" + id_mat_det_price + "','" + decimalSQL(mat_det_price.ToString) + "')"
                    execute_non_query(query_upd_storage, True, "", "", "", "")
                    'update stored
                Next
            End If
            'infoCustom("Status changed.")
            Try
                FormMatRetInProd.id_report_status = id_status_reportx
                FormMatRetInProd.allow_status()
                FormMatRet.viewRetInProd()
                FormMatRet.GVRetInProd.FocusedRowHandle = find_row(FormMatRet.GVRetInProd, "id_mat_prod_ret_in", id_report)
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "48" Then
            'SALES POS
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "5" Then
                Dim cancel_rsv_stock As ClassSalesInv = New ClassSalesInv()

                If FormSalesPOSDet.is_use_unique_code = "1" Then
                    'cancelled unique
                    cancel_rsv_stock.cancellUnique(id_report, report_mark_type)
                End If


                'cancelled
                cancel_rsv_stock.cancelReservedStock(id_report, "48")
            ElseIf id_status_reportx = "6" Then
                'completed
                Dim complete_rsv_stock As ClassSalesInv = New ClassSalesInv()
                complete_rsv_stock.completedStock(id_report, "48")
            End If

            'update status
            query = String.Format("UPDATE tb_sales_pos SET id_report_status='{0}' WHERE id_sales_pos ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")

            If form_origin = "FormSalesPOSDet" Then
                FormSalesPOSDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSalesPOSDet.check_but()
                FormSalesPOSDet.actionLoad()
                FormSalesPOS.viewSalesPOS()
                FormSalesPOS.GVSalesPOS.FocusedRowHandle = find_row(FormSalesPOS.GVSalesPOS, "id_sales_pos", id_report)
            Else
                'code here
            End If
        ElseIf report_mark_type = "49" Or report_mark_type = "106" Then
            'SALES RETURN QC
            Dim st As ClassSalesReturnQC = New ClassSalesReturnQC()
            st.changeStatus(id_report, id_status_reportx)
            'infoCustom("Status changed.")

            If form_origin = "FormSalesReturnQCDet" Then
                FormSalesReturnQCDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSalesReturnQCDet.check_but()
                FormSalesReturnQCDet.actionLoad()
                FormSalesReturnQC.viewSalesReturnQC()
                FormSalesReturnQC.GVSalesReturnQC.FocusedRowHandle = find_row(FormSalesReturnQC.GVSalesReturnQC, "id_sales_return_qc", id_report)
            Else
                'code here
            End If
        ElseIf report_mark_type = "50" Then
            'PR Production
            query = String.Format("UPDATE tb_pr_prod_order SET id_report_status='{0}' WHERE id_pr_prod_order ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            Try
                FormProdPRWODet.id_report_status = id_status_reportx
                FormProdPRWODet.allow_status()
                FormProdPRWO.view_pr()
                FormProdPRWO.GVMatPR.FocusedRowHandle = find_row(FormProdPRWO.GVMatPR, "id_pr_prod_order", id_report)
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "51" Then
            'SALES INVOICE
            Try
                query = String.Format("UPDATE tb_sales_invoice SET id_report_status='{0}' WHERE id_sales_invoice ='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                'infoCustom("Status changed.")

                If form_origin = "FormSalesInvoiceDet" Then
                    FormSalesInvoiceDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormSalesInvoiceDet.check_but()
                    FormSalesInvoiceDet.actionLoad()
                    FormSalesInvoice.viewSalesInvoice()
                    FormSalesInvoice.GVSalesInvoice.FocusedRowHandle = find_row(FormSalesInvoice.GVSalesInvoice, "id_sales_invoice", id_report)
                Else
                    'code here
                End If
            Catch ex As Exception
                errorConnection()
                Close()
            End Try
        ElseIf report_mark_type = "52" Then
            'Mat Stock Opname
            query = String.Format("UPDATE tb_mat_so SET id_report_status='{0}' WHERE id_mat_so ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            Try
                FormMatStockOpnameDet.id_report_status = id_status_reportx
                FormMatStockOpnameDet.allow_status()
                FormMatStockOpnameResultDet.id_report_status = id_status_reportx
                FormMatStockOpnameResultDet.allow_status()
                FormMatStockOpname.view_so()
                FormMatStockOpname.GVMatPR.FocusedRowHandle = find_row(FormMatStockOpname.GVMatPR, "id_mat_so", id_report)
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "53" Then
            'FG SO STORE
            Try
                query = String.Format("UPDATE tb_fg_so_store SET id_report_status='{0}' WHERE id_fg_so_store ='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                'infoCustom("Status changed.")

                If form_origin = "FormFGStockOpnameStoreDet" Then
                    'FormSalesInvoiceDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    ' FormFGStockOpnameStoreDet.check_but()
                    FormFGStockOpnameStoreDet.actionLoad()
                    FormFGStockOpnameStore.viewSoStore()
                    FormFGStockOpnameStore.GVSOStore.FocusedRowHandle = find_row(FormFGStockOpnameStore.GVSOStore, "id_fg_so_store", id_report)
                Else
                    'code here
                End If
            Catch ex As Exception
                errorConnection()
                Close()
            End Try
        ElseIf report_mark_type = "54" Then
            'FG MISSING
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            Try
                If id_status_reportx = "5" Then
                    Dim cancel_rsv_stock As ClassSalesInv = New ClassSalesInv()

                    If FormSalesPOSDet.is_use_unique_code = "1" Then
                        'cancelled unique
                        cancel_rsv_stock.cancellUnique(id_report, report_mark_type)
                    End If


                    'cancelled stock
                    cancel_rsv_stock.cancelReservedStock(id_report, "54")
                ElseIf id_status_reportx = "6" Then
                    'completed
                    Dim complete_rsv_stock As ClassSalesInv = New ClassSalesInv()
                    complete_rsv_stock.completedStock(id_report, "54")
                End If

                query = String.Format("UPDATE tb_sales_pos SET id_report_status='{0}' WHERE id_sales_pos ='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                'infoCustom("Status changed.")

                If form_origin = "FormSalesPOSDet" Then
                    FormSalesPOSDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormSalesPOSDet.check_but()
                    FormSalesPOSDet.actionLoad()
                    FormSalesPOS.viewSalesPOS()
                    FormSalesPOS.GVSalesPOS.FocusedRowHandle = find_row(FormSalesPOS.GVSalesPOS, "id_sales_pos", id_report)
                Else
                    'code here
                End If
            Catch ex As Exception
                errorConnection()
                Close()
            End Try
        ElseIf report_mark_type = "55" Then
            'FG MISSING INVOICE
            Try
                query = String.Format("UPDATE tb_fg_missing_invoice SET id_report_status='{0}' WHERE id_fg_missing_invoice ='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                'infoCustom("Status changed.")

                If form_origin = "FormFGMissingInvoiceDet" Then
                    FormFGMissingInvoiceDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormFGMissingInvoiceDet.check_but()
                    FormFGMissingInvoiceDet.actionLoad()
                    FormFGMissingInvoice.viewFGMissingInvoice()
                    FormFGMissingInvoice.GVFGMissingInvoice.FocusedRowHandle = find_row(FormFGMissingInvoice.GVFGMissingInvoice, "id_fg_missing_invoice", id_report)
                Else
                    'code here
                End If
            Catch ex As Exception
                errorConnection()
                Close()
            End Try
        ElseIf report_mark_type = "56" Then
            'FG SO WH
            Try
                query = String.Format("UPDATE tb_fg_so_wh SET id_report_status='{0}' WHERE id_fg_so_wh ='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                'infoCustom("Status changed.")

                If form_origin = "FormFGStockOpnameWHDet" Then
                    'FormSalesInvoiceDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    ' FormFGStockOpnameStoreDet.check_but()
                    FormFGStockOpnameWHDet.actionLoad()
                    FormFGStockOpnameWH.viewSOWH()
                    FormFGStockOpnameWH.GVSOWH.FocusedRowHandle = find_row(FormFGStockOpnameWH.GVSOWH, "id_fg_so_wh", id_report)
                Else
                    'code here
                End If
            Catch ex As Exception
                errorConnection()
                Close()
            End Try
        ElseIf report_mark_type = "57" Then
            'TRANSFER
            Dim stt As ClassFGTrf = New ClassFGTrf()
            stt.changeStatus(id_report, id_status_reportx)
            'infoCustom("Status changed.")

            If form_origin = "FormFGTrfDet" Then
                FormFGTrfDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormFGTrfDet.check_but()
                FormFGTrfDet.actionLoad()
                FormFGTrf.viewFGTrf()
                FormFGTrf.GVFGTrf.FocusedRowHandle = find_row(FormFGTrf.GVFGTrf, "id_fg_trf", id_report)
            ElseIf form_origin = "FormFGTrfNewDet" Then
                FormFGTrfNewDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormFGTrfNewDet.check_but()
                FormFGTrfNewDet.actionLoad()
                FormFGTrfNew.viewFGTrf()
                FormFGTrfNew.GVFGTrf.FocusedRowHandle = find_row(FormFGTrfNew.GVFGTrf, "id_fg_trf", id_report)
            Else
                'no code
            End If
        ElseIf report_mark_type = "58" Then
            'REC TRF
            Try
                If id_status_reportx = "6" Then
                    ' jika complete
                    Dim query_save_st As String = ""
                    query_save_st += "INSERT INTO tb_storage_fg(id_wh_drawer,id_storage_category,id_product,bom_unit_price,report_mark_type,id_report,storage_product_qty,storage_product_datetime,storage_product_notes,id_stock_status) "
                    query_save_st += "SELECT trf.id_wh_drawer, '1', trf_det.id_product, dsg.design_cop, '58', '" + id_report + "', trf_det.fg_trf_det_qty_rec, "
                    query_save_st += "NOW(), CONCAT('Receive Transfer Completed, No : ', trf.fg_trf_number), '1' "
                    query_save_st += "FROM tb_fg_trf_det trf_det "
                    query_save_st += "INNER JOIN tb_fg_trf trf ON trf.id_fg_trf = trf_det.id_fg_trf "
                    query_save_st += "INNER JOIN tb_m_product prd ON prd.id_product = trf_det.id_product "
                    query_save_st += "INNER JOIN tb_m_design dsg ON dsg.id_design = prd.id_design "
                    query_save_st += "WHERE trf.id_fg_trf = '" + id_report + "' "
                    execute_non_query(query_save_st, True, "", "", "", "")
                End If

                query = String.Format("UPDATE tb_fg_trf SET id_report_status_rec='{0}' WHERE id_fg_trf ='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                'infoCustom("Status changed.")

                If form_origin = "FormFGTrfDet" Then
                    FormFGTrfDet.LEReportStatus2.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormFGTrfDet.check_but()
                    FormFGTrfDet.actionLoad()
                    FormFGTrfReceive.viewFGTrf()
                    FormFGTrfReceive.GVFGTrf.FocusedRowHandle = find_row(FormFGTrfReceive.GVFGTrf, "id_fg_trf", id_report)
                Else
                    'code here
                End If
            Catch ex As Exception
                errorConnection()
                Close()
            End Try
        ElseIf report_mark_type = "60" Then
            'PL SAMPLE DEL
            query = String.Format("UPDATE tb_sample_del SET id_report_status='{0}' WHERE id_sample_del ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'rollback stock if cancelled and complerted
            If id_status_reportx = "5" Then
                Dim query_drawer As String = "SELECT c.sample_del_number, b.id_sample, a.id_wh_drawer, a.sample_del_det_drawer_qty,a.id_sample_price, a.sample_price FROM tb_sample_del_det_drawer a "
                query_drawer += "INNER JOIN tb_sample_del_det b ON a.id_sample_del_det = b.id_sample_del_det "
                query_drawer += "INNER JOIN tb_sample_del c ON c.id_sample_del = b.id_sample_del "
                query_drawer += "WHERE b.id_sample_del = '" + id_report + "' "
                Dim data_drawer As DataTable = execute_query(query_drawer, -1, True, "", "", "", "")

                'prepare rollback stock
                Dim query_drawer_stock As String = ""
                Dim jum_ins_c As Integer = 0
                If data_drawer.Rows.Count > 0 Then
                    query_drawer_stock = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes, id_sample_price, sample_price, report_mark_type, id_report, id_stock_status) VALUES "
                End If
                For c As Integer = 0 To (data_drawer.Rows.Count - 1)
                    If c > 0 Then
                        query_drawer_stock += ", "
                    End If
                    query_drawer_stock += "('" + data_drawer(c)("id_wh_drawer").ToString + "', '1', '" + data_drawer(c)("id_sample").ToString + "', '" + decimalSQL(data_drawer(c)("sample_del_det_drawer_qty").ToString) + "', NOW(), 'PL sample Delivery No: " + data_drawer(c)("sample_del_number").ToString + ", has been canceled', '" + data_drawer(c)("id_sample_price").ToString + "','" + decimalSQL(data_drawer(c)("sample_price").ToString) + "', '60', '" + id_report + "', '2') "
                Next

                'excequte rollback
                If data_drawer.Rows.Count > 0 Then
                    execute_non_query(query_drawer_stock, True, "", "", "", "")
                End If
            ElseIf id_status_reportx = "6" Then
                Dim query_drawer As String = "SELECT c.sample_del_number, b.id_sample, a.id_wh_drawer, a.sample_del_det_drawer_qty, a.id_sample_price, a.sample_price FROM tb_sample_del_det_drawer a "
                query_drawer += "INNER JOIN tb_sample_del_det b ON a.id_sample_del_det = b.id_sample_del_det "
                query_drawer += "INNER JOIN tb_sample_del c ON c.id_sample_del = b.id_sample_del "
                query_drawer += "WHERE b.id_sample_del = '" + id_report + "' "
                Dim data_drawer As DataTable = execute_query(query_drawer, -1, True, "", "", "", "")

                'prepare rollback stock
                Dim query_drawer_stock_reserved As String = ""
                Dim query_drawer_stock_preparedx As String = ""
                Dim jum_ins_c As Integer = 0
                If data_drawer.Rows.Count > 0 Then
                    query_drawer_stock_reserved = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes, id_sample_price, sample_price, report_mark_type, id_report, id_stock_status) VALUES "
                    query_drawer_stock_preparedx = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes, id_sample_price, sample_price, report_mark_type, id_report, id_stock_status) VALUES "
                End If
                For c As Integer = 0 To (data_drawer.Rows.Count - 1)
                    If c > 0 Then
                        query_drawer_stock_reserved += ", "
                        query_drawer_stock_preparedx += ", "
                    End If
                    query_drawer_stock_reserved += "('" + data_drawer(c)("id_wh_drawer").ToString + "', '1', '" + data_drawer(c)("id_sample").ToString + "', '" + decimalSQL(data_drawer(c)("sample_del_det_drawer_qty").ToString) + "', NOW(), 'PL Sample Delivery Completed and delete reserved stock, no : " + data_drawer(c)("sample_del_number").ToString + "',  '" + data_drawer(c)("id_sample_price").ToString + "', '" + decimalSQL(data_drawer(c)("sample_price").ToString) + "', '60', '" + id_report + "', '2') "
                    query_drawer_stock_preparedx += "('" + data_drawer(c)("id_wh_drawer").ToString + "', '2', '" + data_drawer(c)("id_sample").ToString + "', '" + decimalSQL(data_drawer(c)("sample_del_det_drawer_qty").ToString) + "', NOW(), 'PL Sample Delivery, no : " + data_drawer(c)("sample_del_number").ToString + "', '" + data_drawer(c)("id_sample_price").ToString + "','" + decimalSQL(data_drawer(c)("sample_price").ToString) + "', '60', '" + id_report + "', '1') "
                Next

                'excequte
                If data_drawer.Rows.Count > 0 Then
                    execute_non_query(query_drawer_stock_reserved, True, "", "", "", "")
                    execute_non_query(query_drawer_stock_preparedx, True, "", "", "", "")
                End If
            End If

            'infoCustom("Status changed.")

            If form_origin = "FormSampleDelDet" Then
                FormSampleDelDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSampleDelDet.check_but()
                FormSampleDelDet.actionLoad()
                FormSampleDel.viewSampleDel()
                FormSampleDel.GVSampleDel.FocusedRowHandle = find_row(FormSampleDel.GVSampleDel, "id_sample_del", id_report)
            Else
                'no code
            End If
        ElseIf report_mark_type = "61" Then
            'RECEIVING SAMPLE DEL
            Try
                query = String.Format("UPDATE tb_sample_del_rec SET id_report_status='{0}' WHERE id_sample_del_rec ='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                'infoCustom("Status changed.")

                If form_origin = "FormSampleDelRecDet" Then
                    FormSampleDelRecDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormSampleDelRecDet.actionLoad()
                    FormSampleDelRec.viewSampleDel()
                    FormSampleDelRec.viewSampleDelRec()
                    FormSampleDelRec.GVSampleDelRec.FocusedRowHandle = find_row(FormSampleDelRec.GVSampleDelRec, "id_sample_del_rec", id_report)
                Else
                    'code here
                End If
            Catch ex As Exception
                errorConnection()
                Close()
            End Try
        ElseIf report_mark_type = "62" Then
            'SO SAMPLE ORDER
            Try
                query = String.Format("UPDATE tb_sample_order SET id_report_status='{0}' WHERE id_sample_order ='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                'infoCustom("Status changed.")

                If form_origin = "FormSampleOrderDet" Then
                    FormSampleOrderDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormSampleOrderDet.actionLoad()
                    FormSampleOrder.viewSampleOrder()
                    FormSampleOrder.GVSampleOrder.FocusedRowHandle = find_row(FormSampleOrder.GVSampleOrder, "id_sample_order", id_report)
                Else
                    'code here
                End If
            Catch ex As Exception
                errorConnection()
                Close()
            End Try
        ElseIf report_mark_type = "63" Then
            ' DELIVERY ORDER SAMPLE FOR SALES
            query = String.Format("UPDATE tb_pl_sample_order_del SET id_report_status='{0}' WHERE id_pl_sample_order_del ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'rollback stock if cancelled and complerted
            If id_status_reportx = "5" Then
                Dim query_c As ClassSampleDelOrder = New ClassSampleDelOrder
                Dim query_drawer As String = query_c.queryDetailDrawer("AND a1.id_pl_sample_order_del = ''" + id_report + "''", "1")
                Dim data_drawer As DataTable = execute_query(query_drawer, -1, True, "", "", "", "")

                'prepare rollback stock
                Dim query_drawer_stock As String = ""
                Dim jum_ins_c As Integer = 0
                If data_drawer.Rows.Count > 0 Then
                    query_drawer_stock = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes, id_sample_price, sample_price, report_mark_type, id_report, id_stock_status) VALUES "
                End If
                For c As Integer = 0 To (data_drawer.Rows.Count - 1)
                    If c > 0 Then
                        query_drawer_stock += ", "
                    End If
                    query_drawer_stock += "('" + data_drawer(c)("id_wh_drawer").ToString + "', '1', '" + data_drawer(c)("id_sample").ToString + "', '" + decimalSQL(data_drawer(c)("qty_all_sample").ToString) + "', NOW(), 'Delivery Order Sample No: " + data_drawer(c)("pl_sample_order_del_number").ToString + ", has been canceled', '" + data_drawer(c)("id_sample_price").ToString + "','" + decimalSQL(data_drawer(c)("sample_price").ToString) + "', '63', '" + id_report + "', '2') "
                Next

                'excequte rollback
                If data_drawer.Rows.Count > 0 Then
                    execute_non_query(query_drawer_stock, True, "", "", "", "")
                End If
            ElseIf id_status_reportx = "6" Then
                Dim query_c As ClassSampleDelOrder = New ClassSampleDelOrder
                Dim query_drawer As String = query_c.queryDetailDrawer("AND a1.id_pl_sample_order_del = ''" + id_report + "''", "1")
                Dim data_drawer As DataTable = execute_query(query_drawer, -1, True, "", "", "", "")

                'prepare rollback stock
                Dim query_drawer_stock_reserved As String = ""
                Dim query_drawer_stock_preparedx As String = ""
                Dim jum_ins_c As Integer = 0
                If data_drawer.Rows.Count > 0 Then
                    query_drawer_stock_reserved = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes, id_sample_price, sample_price, report_mark_type, id_report, id_stock_status) VALUES "
                    query_drawer_stock_preparedx = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes, id_sample_price, sample_price, report_mark_type, id_report, id_stock_status) VALUES "
                End If
                For c As Integer = 0 To (data_drawer.Rows.Count - 1)
                    If c > 0 Then
                        query_drawer_stock_reserved += ", "
                        query_drawer_stock_preparedx += ", "
                    End If
                    query_drawer_stock_reserved += "('" + data_drawer(c)("id_wh_drawer").ToString + "', '1', '" + data_drawer(c)("id_sample").ToString + "', '" + decimalSQL(data_drawer(c)("qty_all_sample").ToString) + "', NOW(), 'Delivery Order Sample Completed and delete reserved stock, no : " + data_drawer(c)("pl_sample_order_del_number").ToString + "',  '" + data_drawer(c)("id_sample_price").ToString + "', '" + decimalSQL(data_drawer(c)("sample_price").ToString) + "', '63', '" + id_report + "', '2') "
                    query_drawer_stock_preparedx += "('" + data_drawer(c)("id_wh_drawer").ToString + "', '2', '" + data_drawer(c)("id_sample").ToString + "', '" + decimalSQL(data_drawer(c)("qty_all_sample").ToString) + "', NOW(), 'Delivery Order Sample, no : " + data_drawer(c)("pl_sample_order_del_number").ToString + "', '" + data_drawer(c)("id_sample_price").ToString + "','" + decimalSQL(data_drawer(c)("sample_price").ToString) + "', '63', '" + id_report + "', '1') "
                Next

                'excequte
                If data_drawer.Rows.Count > 0 Then
                    execute_non_query(query_drawer_stock_reserved, True, "", "", "", "")
                    execute_non_query(query_drawer_stock_preparedx, True, "", "", "", "")
                End If
            End If

            'infoCustom("Status changed.")

            If form_origin = "FormSampleDelOrderDet" Then
                FormSampleDelOrderDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSampleDelOrderDet.check_but()
                FormSampleDelOrderDet.actionLoad()
                FormSampleDelOrder.viewSampleDelOrder()
                FormSampleDelOrder.viewSampleOrder()
                FormSampleDelOrder.GVSampleDelOrder.FocusedRowHandle = find_row(FormSampleDelOrder.GVSampleDelOrder, "id_pl_sample_order_del", id_report)
            Else
                'no code
            End If
        ElseIf report_mark_type = "64" Then
            'SAMPLE SO
            Try
                query = String.Format("UPDATE tb_sample_so SET id_report_status='{0}' WHERE id_sample_so ='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                'infoCustom("Status changed.")

                If form_origin = "FormSampleStockOpname" Then
                    FormSampleStockOpnameDet.actionLoad()
                    FormSampleStockOpname.viewSOWH()
                    FormSampleStockOpname.GVSOWH.FocusedRowHandle = find_row(FormSampleStockOpname.GVSOWH, "id_sample_so", id_report)
                Else
                    'code here
                End If
            Catch ex As Exception
                errorConnection()
                Close()
            End Try
        ElseIf report_mark_type = "65" Then
            'CODE REPLACEMENT
            If id_status_reportx = "3" Then
                id_status_reportx = 6
            End If
            'action complete
            'If id_status_reportx = "6" Then
            '    Dim query_replace As String = "CALL generate_replace_barcode('" + id_report + "')"
            '    execute_non_query(query_replace, True, "", "", "", "")
            'End If

            query = String.Format("UPDATE tb_fg_code_replace_store SET id_report_status='{0}' WHERE id_fg_code_replace_store ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")

            If form_origin = "FormFGCodeReplaceStoreDet" Then
                FormFGCodeReplaceStoreDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormFGCodeReplaceStoreDet.check_but()
                FormFGCodeReplaceStoreDet.actionLoad()
                FormFGCodeReplace.viewCodeReplaceStore()
                FormFGCodeReplace.GVFGCodeReplaceStore.FocusedRowHandle = find_row(FormFGCodeReplace.GVFGCodeReplaceStore, "id_fg_code_replace_store", id_report)
            Else
                'no code
            End If
        ElseIf report_mark_type = "66" Or report_mark_type = "118" Then
            'SALES CREDIT NOTE
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                'completed
                Dim stc_in As ClassSalesInv = New ClassSalesInv()
                stc_in.insertUnique(id_report, report_mark_type)
                stc_in.completeInStock(id_report, report_mark_type)

                'return centre online store
                If report_mark_type = "118" Then
                    'update stt in return centre & order status
                    Try
                        Dim qstt As String = "UPDATE tb_ol_store_ret_list main
                        INNER JOIN (
	                        SELECT d.id_ol_store_ret_list 
	                        FROM tb_sales_pos_det d
	                        WHERE d.id_sales_pos=" + id_report + "
	                        GROUP BY d.id_ol_store_ret_list
                        ) src ON src.id_ol_store_ret_list = main.id_ol_store_ret_list
                        SET main.id_ol_store_ret_stt=7;
                        INSERT IGNORE INTO tb_sales_order_det_status(id_sales_order_det, `status`, `status_date`, `input_status_date`, is_internal)
                        SELECT rd.id_sales_order_det, stt.ol_store_ret_stt, NOW(), NOW(),1
                        FROM tb_sales_pos_det d
                        INNER JOIN tb_ol_store_ret_list rl ON rl.id_ol_store_ret_list = d.id_ol_store_ret_list
                        INNER JOIN tb_ol_store_ret_det rd ON rd.id_ol_store_ret_det = rl.id_ol_store_ret_det
                        JOIN tb_lookup_ol_store_ret_stt stt ON stt.id_ol_store_ret_stt=7
                        WHERE d.id_sales_pos=" + id_report + "
                        GROUP BY rd.id_sales_order_det;"
                        execute_non_query(qstt, True, "", "", "", "")
                    Catch ex As Exception
                        stopCustom("Error updating status in return centre. " + ex.ToString)
                    End Try

                    'send mail for ROR
                    Try

                    Catch ex As Exception

                    End Try
                End If
            End If

            query = String.Format("UPDATE tb_sales_pos SET id_report_status='{0}' WHERE id_sales_pos ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")

            If form_origin = "FormSalesPOSDet" Then
                FormSalesPOSDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSalesPOSDet.check_but()
                FormSalesPOSDet.actionLoad()
                FormSalesPOS.viewSalesPOS()
                FormSalesPOS.GVSalesPOS.FocusedRowHandle = find_row(FormSalesPOS.GVSalesPOS, "id_sales_pos", id_report)
            Else
                'code here
            End If
        ElseIf report_mark_type = "67" Then
            'MISSING CREDIT NOTE
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                'completed
                Dim stc_in As ClassSalesInv = New ClassSalesInv()
                stc_in.completeInStock(id_report, "67")
            End If

            query = String.Format("UPDATE tb_sales_pos SET id_report_status='{0}' WHERE id_sales_pos ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")

            If form_origin = "FormSalesPOSDet" Then
                FormSalesPOSDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSalesPOSDet.check_but()
                FormSalesPOSDet.actionLoad()
                FormSalesPOS.viewSalesPOS()
                FormSalesPOS.GVSalesPOS.FocusedRowHandle = find_row(FormSalesPOS.GVSalesPOS, "id_sales_pos", id_report)
            Else
                'code here
            End If
        ElseIf report_mark_type = "68" Then
            'CODE REPLACEMENT WH
            'action complete
            If id_status_reportx = "6" Then
                Dim query_replace As String = "CALL generate_replace_barcode_wh('" + id_report + "')"
                execute_non_query(query_replace, True, "", "", "", "")
            End If

            query = String.Format("UPDATE tb_fg_code_replace_wh SET id_report_status='{0}' WHERE id_fg_code_replace_wh ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")

            If form_origin = "FormFGCodeReplaceWHDet" Then
                FormFGCodeReplaceWHDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormFGCodeReplaceWHDet.check_but()
                FormFGCodeReplaceWHDet.actionLoad()
                FormFGCodeReplace.viewCodeReplaceWH()
                FormFGCodeReplace.GVFGCodeReplaceWH.FocusedRowHandle = find_row(FormFGCodeReplace.GVFGCodeReplaceWH, "id_fg_code_replace_wh", id_report)
            Else
                'no code
            End If
        ElseIf report_mark_type = "69" Then
            'FG WRITE OFF
            If id_status_reportx = "5" Then
                Dim query_c As ClassFGWoff = New ClassFGWoff()
                Dim query_roll As String = query_c.queryRollbackStock(id_report)
                execute_non_query(query_roll, True, "", "", "", "")
            ElseIf id_status_reportx = "6" Then
                Dim query_c As ClassFGWoff = New ClassFGWoff()
                Dim query_out As String = query_c.queryCompletedStock(id_report)
                execute_non_query(query_out, True, "", "", "", "")
            End If

            'cheange status
            query = String.Format("UPDATE tb_fg_woff SET id_report_status='{0}' WHERE id_fg_woff ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")

            If form_origin = "FormFGWoffDet" Then
                FormFGWoffDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormFGWoffDet.check_but()
                FormFGWoffDet.actionLoad()
                FormFGWoff.viewFGWoff()
                FormFGWoff.GVFGWoff.FocusedRowHandle = find_row(FormFGWoff.GVFGWoff, "id_fg_woff", id_report)
            End If
        ElseIf report_mark_type = "70" Then
            'FG PROPOSE PRICE
            If id_status_reportx = "2" Then
                id_status_reportx = "6"
            End If

            'post ke master price if completed
            If id_status_reportx = "6" Then
                If FormFGProposePriceDetail.id_pp_type = "1" Then
                    'reguler normal master price
                    Dim query_ins As String = "INSERT INTO tb_m_design_price(id_design, id_design_price_type, design_price_name, id_currency, design_price, design_price_date, design_price_start_date, is_print, id_user) 
                    SELECT ppd.id_design, ppd.id_design_price_type_master, pt.design_price_type, 1, ppd.price, NOW(), NOW(), 1, " + id_user + "
                    FROM tb_fg_propose_price_detail ppd
                    INNER JOIN tb_fg_propose_price pp ON pp.id_fg_propose_price = ppd.id_fg_propose_price
                    INNER JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = ppd.id_design_price_type_master
                    WHERE ppd.id_fg_propose_price=" + id_report + " "
                    execute_non_query(query_ins, True, "", "", "", "")

                    'send email
                    Try
                        Dim qc As String = "SELECT * FROM tb_fg_propose_price_detail prcd 
                    WHERE prcd.id_fg_propose_price=" + id_report + " AND !ISNULL(id_design_price_type_print) AND  prcd.is_active=1 "
                        Dim dc As DataTable = execute_query(qc, -1, True, "", "", "", "")
                        If dc.Rows.Count > 0 Then
                            Dim mail As New ClassSendEmail()
                            mail.report_mark_type = "70"
                            mail.id_report = id_report
                            mail.date_string = FormFGProposePriceDetail.DECreated.Text
                            mail.comment = ""
                            mail.send_email()
                        End If
                    Catch ex As Exception
                        execute_non_query("INSERT INTO tb_error_mail(date, description) VALUES(NOW(), 'PP;" + addSlashes(ex.ToString) + "'); ", True, "", "", "", "")
                    End Try
                Else
                    'non reguler - ada normal & sale price
                    Dim qd As String = "SELECT * 
                    FROM tb_fg_propose_price_detail ppd
                    WHERE ppd.id_fg_propose_price=" + id_report + " "
                    Dim dd As DataTable = execute_query(qd, -1, True, "", "", "", "")
                    For i As Integer = 0 To dd.Rows.Count - 1
                        Dim is_print_normal = "0"
                        Dim is_print_sale = "0"
                        If dd.Rows(i)("id_design_price_type_print") = "1" Then
                            is_print_normal = "1"
                            is_print_sale = "0"
                        ElseIf dd.Rows(i)("id_design_price_type_print") = "4" Then
                            is_print_normal = "0"
                            is_print_sale = "1"
                        End If

                        If dd.Rows(i)("id_design_price_type_master") = "1" Then
                            'master akhir normal
                            Dim query_ins As String = "INSERT INTO tb_m_design_price(id_design, id_design_price_type, design_price_name, id_currency, design_price, design_price_date, design_price_start_date, is_print, id_user) 
                            SELECT '" + dd.Rows(i)("id_design").ToString + "','4', 'Sale','1', '" + decimalSQL(dd.Rows(i)("sale_price").ToString) + "', NOW(), NOW(), '" + is_print_sale + "', '" + id_user + "' 
                            UNION ALL
                            SELECT '" + dd.Rows(i)("id_design").ToString + "','1', 'Normal','1', '" + decimalSQL(dd.Rows(i)("price").ToString) + "', NOW(), NOW(), '" + is_print_normal + "', '" + id_user + "'  "
                            execute_non_query(query_ins, True, "", "", "", "")
                        ElseIf dd.Rows(i)("id_design_price_type_master") = "4" Then
                            'master akhir sale
                            Dim query_ins As String = "INSERT INTO tb_m_design_price(id_design, id_design_price_type, design_price_name, id_currency, design_price, design_price_date, design_price_start_date, is_print, id_user) 
                            SELECT '" + dd.Rows(i)("id_design").ToString + "','1', 'Normal','1', '" + decimalSQL(dd.Rows(i)("price").ToString) + "', NOW(), NOW(), '" + is_print_normal + "', '" + id_user + "'  
                            UNION ALL
                            SELECT '" + dd.Rows(i)("id_design").ToString + "','4', 'Sale','1', '" + decimalSQL(dd.Rows(i)("sale_price").ToString) + "', NOW(), NOW(), '" + is_print_sale + "', '" + id_user + "'  "
                            execute_non_query(query_ins, True, "", "", "", "")
                        End If
                    Next

                    'send email
                    Try
                        Dim qc As String = "SELECT * FROM tb_fg_propose_price_detail prcd 
                        WHERE prcd.id_fg_propose_price=" + id_report + " AND !ISNULL(id_design_price_type_print) AND  prcd.is_active=1 "
                        Dim dc As DataTable = execute_query(qc, -1, True, "", "", "", "")
                        If dc.Rows.Count > 0 Then
                            Dim mail As New ClassSendEmail()
                            mail.report_mark_type = "70_non_reg"
                            mail.id_report = id_report
                            mail.date_string = FormFGProposePriceDetail.DECreated.Text
                            mail.comment = ""
                            mail.send_email()
                        End If
                    Catch ex As Exception
                        execute_non_query("INSERT INTO tb_error_mail(date, description) VALUES(NOW(), 'PP;" + addSlashes(ex.ToString) + "'); ", True, "", "", "", "")
                    End Try
                End If
            End If

            query = String.Format("UPDATE tb_fg_propose_price SET id_report_status='{0}' WHERE id_fg_propose_price ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")

            If form_origin = "FormFGProposePriceDetail" Then
                FormFGProposePriceDetail.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormFGProposePriceDetail.actionLoad()
                FormFGProposePrice.viewPropose()
                FormFGProposePrice.GVFGPropose.FocusedRowHandle = find_row(FormFGProposePrice.GVFGPropose, "id_fg_propose_price", id_report)
            End If
        ElseIf report_mark_type = "72" Then
            'QC Adj In
            query = String.Format("UPDATE tb_prod_order_qc_adj_in SET id_report_status='{0}' WHERE id_prod_order_qc_adj_in ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")

            If id_status_reportx = "6" Then
                query = String.Format("UPDATE tb_prod_order_qc_adj_in SET complete_date=NOW() WHERE id_prod_order_qc_adj_in ='{0}'", id_report)
                execute_non_query(query, True, "", "", "", "")
            End If

            If form_origin = "FormProdQCAdjIn" Then
                FormProdQCAdjIn.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormProdQCAdjIn.actionLoad()
                FormProdQCAdj.viewAdjIn()
                FormProdQCAdj.GVAdjIn.FocusedRowHandle = find_row(FormProdQCAdj.GVAdjIn, "id_prod_order_qc_adj_in", id_report)
            Else
                FormViewProdQCAdjIn.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
            End If
        ElseIf report_mark_type = "73" Then
            'QC Adj Out
            query = String.Format("UPDATE tb_prod_order_qc_adj_out SET id_report_status='{0}' WHERE id_prod_order_qc_adj_out ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")

            If id_status_reportx = "6" Then
                query = String.Format("UPDATE tb_prod_order_qc_adj_out SET complete_date=NOW() WHERE id_prod_order_qc_adj_out ='{0}'", id_report)
                execute_non_query(query, True, "", "", "", "")
            End If

            If form_origin = "FormProdQCAdjOut" Then
                FormProdQCAdjOut.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormProdQCAdjOut.actionLoad()
                FormProdQCAdj.viewAdjOut()
                FormProdQCAdj.GVAdjOut.FocusedRowHandle = find_row(FormProdQCAdj.GVAdjOut, "id_prod_order_qc_adj_out", id_report)
            Else
                FormViewProdQcAdjOut.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
            End If
        ElseIf report_mark_type = "75" Then
            'ANALISIS SO
            If id_status_reportx = "6" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("This process will create prepare order new product documents automatically. Are you sure to continue this process ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    PBC.Visible = True

                    'delete mark
                    Dim query_del_mark As String = ""
                    query_del_mark += "DELETE "
                    query_del_mark += "FROM tb_report_mark "
                    query_del_mark += "WHERE id_report IN ( "
                    query_del_mark += "SELECT * FROM ( "
                    query_del_mark += "select id_sales_order from tb_sales_order a where a.id_fg_so_reff='" + id_report + "' "
                    query_del_mark += ") a "
                    query_del_mark += ") AND report_mark_type='39' "
                    execute_non_query(query_del_mark, True, "", "", "", "")

                    'delete prepare order terkait
                    Dim query_del As String = "DELETE FROM tb_sales_order WHERE id_fg_so_reff='" + id_report + "' "
                    execute_non_query(query_del, True, "", "", "", "")

                    'get product
                    Dim ix As Integer = 0
                    Dim id_product_sel As String = ""
                    For j As Integer = 0 To ((FormFGSalesOrderReffDet.GVDesign.RowCount - 1) - GetGroupRowCount(FormFGSalesOrderReffDet.GVDesign)) 'looping product
                        Dim id_product As String = FormFGSalesOrderReffDet.GVDesign.GetRowCellValue(j, "id_product").ToString
                        If ix > 0 Then
                            id_product_sel += "OR "
                        End If
                        id_product_sel += "ds.id_product = '" + id_product + "' "
                        ix += 1
                    Next

                    'looping based on store
                    Dim str_err As String = ""
                    Dim sales_order_reff As String = ""
                    Dim data_fg_store As DataTable = FormFGSalesOrderReffDet.GCDesign.DataSource

                    If data_fg_store.Rows.Count > 0 Then
                        PBC.Properties.Minimum = 0
                        PBC.Properties.Maximum = data_fg_store.Rows.Count - 1
                        PBC.Properties.Step = 1
                        PBC.Properties.PercentView = True
                    End If

                    Dim cond_success As Boolean = False
                    Dim nx As Integer = 0
                    Dim min_so As Integer = 0 'utk melihat minimal SO
                    For i As Integer = 0 To data_fg_store.Columns.Count - 1 'looping account
                        Dim col As String = data_fg_store.Columns(i).ToString
                        If col.Contains("#id#") Then
                            nx += 1
                            Dim col_foc_arr As String() = Split(col, "#id#")
                            Try
                                Dim id_sales_order As String = "0"
                                Dim id_delivery As String = FormFGSalesOrderReffDet.SLEDel.EditValue.ToString
                                Dim id_store_to As String = col_foc_arr(1)
                                Dim id_store_contact_to As String = get_company_x(id_store_to, "6")
                                Dim id_warehouse_contact_to As String = FormFGSalesOrderReffDet.id_comp_contact_par
                                Dim id_so_type As String = col_foc_arr(3)
                                Dim id_so_cat As String = col_foc_arr(4)
                                Dim id_so_status As String = "1"
                                If id_so_cat = "1" Then
                                    id_so_status = "1"
                                Else
                                    id_so_status = "5"
                                End If


                                'cek harus dibuat so atau tidak
                                Dim query_cek_so As String = ""
                                query_cek_so += "SELECT SUM(ds.fg_so_reff_det_qty) AS `tot_ds` FROM tb_fg_so_reff_det ds "
                                query_cek_so += "INNER JOIN tb_fg_ds_store ds_store ON ds.id_fg_ds_store = ds_store.id_fg_ds_store "
                                query_cek_so += "INNER JOIN tb_m_comp comp ON comp.id_comp = ds_store.id_comp "
                                query_cek_so += "WHERE ds.id_fg_so_reff='" + id_report + "' AND ds_store.id_season='" + FormFGSalesOrderReffDet.SLESeason.EditValue.ToString + "' "
                                query_cek_so += "AND ( "
                                query_cek_so += id_product_sel + " "
                                query_cek_so += ") "
                                query_cek_so += "AND comp.id_comp = '" + id_store_to + "' "
                                Dim tot_ds As String = execute_query(query_cek_so, 0, True, "", "", "", "")

                                'create so
                                If tot_ds > "0" Then
                                    'minimal SO
                                    min_so += 1
                                    If min_so = 1 Then
                                        sales_order_reff = header_number_sales("21")
                                        increase_inc_sales("21")
                                    End If

                                    'insert SO by store
                                    Dim sales_order_number As String = header_number_sales("2")
                                    Dim query_so As String = "INSERT INTO tb_sales_order(id_store_contact_to, id_warehouse_contact_to, sales_order_number, sales_order_date, sales_order_note, id_so_type, id_so_status, id_report_status, id_fg_so_reff, id_user_created) "
                                    query_so += "VALUES ('" + id_store_contact_to + "', '" + id_warehouse_contact_to + "', '" + sales_order_number + "', now(), '', '" + id_so_type + "', '" + id_so_status + "', '6', '" + id_report + "', '" + id_user + "'); SELECT LAST_INSERT_ID(); "
                                    Dim id_sales_order_new As String = execute_query(query_so, 0, True, "", "", "", "")

                                    'increment sales ord number
                                    increase_inc_sales("2")

                                    'insert who prepared
                                    insert_who_approved("39", id_sales_order_new, id_user)

                                    'insert detail
                                    Dim query_det As String = ""
                                    query_det += "INSERT INTO tb_sales_order_det(id_sales_order, id_product, id_design_price, design_price, sales_order_det_qty) "
                                    query_det += "SELECT ('" + id_sales_order_new + "'),ds.id_product, prc.id_design_price, prc.design_price, ds.fg_so_reff_det_qty "
                                    query_det += "FROM tb_fg_so_reff_det ds "
                                    query_det += "INNER JOIN tb_fg_ds_store ds_store ON ds.id_fg_ds_store = ds_store.id_fg_ds_store "
                                    query_det += "INNER JOIN tb_m_comp comp ON comp.id_comp = ds_store.id_comp "
                                    query_det += "INNER JOIN tb_lookup_pd_alloc pd_alloc ON pd_alloc.id_pd_alloc = comp.id_pd_alloc "
                                    query_det += "INNER JOIN tb_m_product prod ON prod.id_product = ds.id_product "
                                    query_det += "LEFT JOIN ( "
                                    query_det += "SELECT * FROM ( "
                                    query_det += "SELECT price.id_design, price.design_price, price.design_price_date, price.id_design_price "
                                    query_det += "FROM tb_m_design_price price "
                                    query_det += "INNER JOIN tb_lookup_design_price_type price_type "
                                    query_det += "ON price.id_design_price_type = price_type.id_design_price_type "
                                    query_det += "INNER JOIN tb_lookup_currency curr ON curr.id_currency = price.id_currency "
                                    query_det += "INNER JOIN tb_m_user `user` ON user.id_user = price.id_user "
                                    query_det += "INNER JOIN tb_m_employee emp ON emp.id_employee = user.id_employee "
                                    query_det += "WHERE price.is_active_wh='1' AND price.design_price_start_date <= NOW() "
                                    query_det += "ORDER BY price.design_price_start_date DESC ) a "
                                    query_det += "GROUP BY a.id_design "
                                    query_det += ") prc ON prc.id_design = prod.id_design "
                                    query_det += "WHERE ds.id_fg_so_reff = '" + id_report + "' AND ds_store.id_season = '" + FormFGSalesOrderReffDet.SLESeason.EditValue.ToString + "' "
                                    query_det += "AND ( "
                                    query_det += id_product_sel + " "
                                    query_det += ") "
                                    query_det += "AND ds.fg_so_reff_det_qty >0 "
                                    query_det += "AND comp.id_comp = '" + id_store_to + "' "
                                    query_det += "ORDER BY ds.id_product ASC "
                                    execute_non_query(query_det, True, "", "", "", "")
                                End If
                            Catch ex As Exception
                                str_err += "- " + col_foc_arr(0).ToString + System.Environment.NewLine
                            End Try

                            'colom statis = 15
                            PBC.PerformStep()
                            PBC.Update()
                        End If
                    Next

                    If str_err = "" Then
                        query = String.Format("UPDATE tb_fg_so_reff SET id_report_status='{0}' WHERE id_fg_so_reff ='{1}'", id_status_reportx, id_report)
                        execute_non_query(query, True, "", "", "", "")
                        infoCustom("Status changed and prepare order was created succesfully.")
                        If form_origin = "FormFGSalesOrderReffDet" Then
                            FormFGSalesOrderReffDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                            FormFGSalesOrderReffDet.actionLoad()
                            FormFGSalesOrderReff.viewSOReff()
                            FormFGSalesOrderReff.GVSOReff.FocusedRowHandle = find_row(FormFGSalesOrderReff.GVSOReff, "id_fg_so_reff", id_report)
                            PBC.Visible = False
                            PBC.EditValue = 0
                        Else
                            ' FormViewProdQCAdjIn.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                        End If
                    Else
                        stopCustom("There are some problem with this process. These account are not successfully to create prepare order : " + System.Environment.NewLine + str_err + System.Environment.NewLine + "Please try again later !")
                        PBC.Visible = False
                        PBC.EditValue = 0
                    End If
                End If
            Else
                query = String.Format("UPDATE tb_fg_so_reff SET id_report_status='{0}' WHERE id_fg_so_reff ='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                'infoCustom("Status changed.")

                If form_origin = "FormFGSalesOrderReffDet" Then
                    FormFGSalesOrderReffDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormFGSalesOrderReffDet.actionLoad()
                    FormFGSalesOrderReff.viewSOReff()
                    FormFGSalesOrderReff.GVSOReff.FocusedRowHandle = find_row(FormFGSalesOrderReff.GVSOReff, "id_fg_so_reff", id_report)
                Else
                    ' FormViewProdQCAdjIn.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                End If
            End If
        ElseIf report_mark_type = "76" Then
            'SALES INVOICE PROMO
            If id_status_reportx = "5" Then
                'cancelled
                Dim cancel_rsv_stock As ClassSalesInv = New ClassSalesInv()
                cancel_rsv_stock.cancelReservedStock(id_report, "76")
            ElseIf id_status_reportx = "6" Then
                'completed
                Dim complete_rsv_stock As ClassSalesInv = New ClassSalesInv()
                complete_rsv_stock.completedStock(id_report, "76")
            End If

            query = String.Format("UPDATE tb_sales_pos SET id_report_status='{0}' WHERE id_sales_pos ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")

            If form_origin = "FormSalesPromoDet" Then
                FormSalesPromoDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSalesPromoDet.check_but()
                FormSalesPromoDet.actionLoad()
                FormSalesPromo.viewSalesPOS()
                FormSalesPromo.GVSalesPOS.FocusedRowHandle = find_row(FormSalesPromo.GVSalesPOS, "id_sales_pos", id_report)
            Else
                'code here
            End If
        ElseIf report_mark_type = "79" Then
            'BOM Per Design
            Try
                Dim id_design As String = "-1"
                If form_origin = "FormBomSingle" Then
                    id_design = FormBOMSingle.id_design
                ElseIf form_origin = "FormBOMDesignSingle" Then
                    id_design = FormBOMDesignSingle.id_design
                End If
                query = String.Format("UPDATE tb_bom_approve SET id_report_status='{0}' WHERE id_bom_approve ='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                query = String.Format("UPDATE tb_bom bom INNER JOIN tb_m_product prod ON prod.id_product=bom.id_product SET bom.id_report_status='{0}' WHERE bom.id_bom_approve='{1}' AND prod.id_design='{2}'", id_status_reportx, id_report, FormBOMSingle.id_design)
                execute_non_query(query, True, "", "", "", "")
                'infoCustom("Status changed.")
                If form_origin = "FormBomSingle" Then
                    FormBOMSingle.act_load()
                ElseIf form_origin = "FormBOMDesignSingle" Then
                    FormBOMDesignSingle.act_load()
                End If
            Catch ex As Exception
                errorConnection()
                Close()
            End Try
        ElseIf report_mark_type = "82" Then
            'FG PRICE
            'post ke master price if completed
            If id_status_reportx = "6" Then
                'insert price
                Dim query_ins As String = "INSERT INTO tb_m_design_price(id_design, id_design_price_type, design_price_name, id_currency, design_price, design_price_date, design_price_start_date, is_print, id_user) "
                query_ins += "SELECT det.id_design, prc.id_design_price_type, det.design_price_name, det.id_currency, det.design_price, "
                query_ins += "NOW(), IF(prc.fg_effective_date = 0000-00-00, NOW(), prc.fg_effective_date) AS fg_effective_date, det.is_print, '" + id_user + "' "
                query_ins += "FROM tb_fg_price_det det "
                query_ins += "INNER JOIN tb_fg_price prc ON prc.id_fg_price = det.id_fg_price "
                query_ins += "WHERE det.id_fg_price='" + id_report + "' "
                execute_non_query(query_ins, True, "", "", "", "")

                'send email
                Try
                    Dim qc As String = "SELECT * FROM tb_fg_price_det prcd WHERE prcd.id_fg_price=" + id_report + " AND prcd.is_print=1 "
                    Dim dc As DataTable = execute_query(qc, -1, True, "", "", "", "")
                    If dc.Rows.Count > 0 Then
                        Dim mail As New ClassSendEmail()
                        mail.report_mark_type = "82"
                        mail.id_report = id_report
                        mail.date_string = FormMasterPriceSingle.DEForm.Text
                        mail.comment = FormMasterPriceSingle.MENote.Text.ToString
                        mail.send_email()
                    End If
                Catch ex As Exception
                    stopCustom(ex.ToString)
                End Try
            End If

            query = String.Format("UPDATE tb_fg_price SET id_report_status='{0}' WHERE id_fg_price ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")

            If form_origin = "FormMasterPriceSingle" Then
                FormMasterPriceSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormMasterPriceSingle.check_but()
                FormMasterPriceSingle.actionLoad()
                FormMasterPrice.viewPrice()
                FormMasterPrice.GVPrice.FocusedRowHandle = find_row(FormMasterPrice.GVPrice, "id_fg_price", id_report)
            End If
        ElseIf report_mark_type = "85" Then
            'SAMPLE PL
            If id_status_reportx = "5" Then
                'cancelled
                Dim cancel_rsv_stock As ClassSamplePLtoWH = New ClassSamplePLtoWH()
                cancel_rsv_stock.cancelReservedStock(id_report, report_mark_type)
            ElseIf id_status_reportx = "6" Then
                'completed
                Dim complete_rsv_stock As ClassSamplePLtoWH = New ClassSamplePLtoWH()
                complete_rsv_stock.completeReservedStock(id_report, report_mark_type)
            End If

            query = String.Format("UPDATE tb_sample_pl SET id_report_status='{0}' WHERE id_sample_pl ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")

            If form_origin = "FormSamplePLToWHDet" Then
                FormSamplePLToWHDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSamplePLToWHDet.check_but()
                FormSamplePLToWHDet.actionLoad()
                FormSamplePLToWH.viewSamplePL()
                FormSamplePLToWH.GVSamplePL.FocusedRowHandle = find_row(FormSamplePLToWH.GVSamplePL, "id_sample_pl", id_report)
            Else
                'code here
            End If
        ElseIf report_mark_type = "86" Then
            'SAMPLE PRICE
            'post ke master price if completed
            If id_status_reportx = "6" Then
                Dim query_ins As String = "INSERT INTO tb_m_sample_ret_price(id_sample, id_design_price_type, sample_ret_price_name, id_currency, sample_ret_price, sample_ret_price_date, sample_ret_price_start_date, is_print, id_user) "
                query_ins += "SELECT det.id_sample, prc.id_design_price_type, det.sample_price_name, det.id_currency, det.sample_price, "
                query_ins += "NOW(), NOW(), det.is_print, '" + id_user + "' "
                query_ins += "FROM tb_sample_price_det det "
                query_ins += "INNER JOIN tb_sample_price prc ON prc.id_sample_price = det.id_sample_price "
                query_ins += "WHERE det.id_sample_price='" + id_report + "' "
                execute_non_query(query_ins, True, "", "", "", "")
            End If

            query = String.Format("UPDATE tb_sample_price SET id_report_status='{0}' WHERE id_sample_price ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")

            If form_origin = "FormMasterPriceSampleSingle" Then
                FormMasterPriceSampleSingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormMasterPriceSampleSingle.check_but()
                FormMasterPriceSampleSingle.actionLoad()
                FormMasterPriceSample.viewPrice()
                FormMasterPriceSample.GVPrice.FocusedRowHandle = find_row(FormMasterPriceSample.GVPrice, "id_sample_price", id_report)
            End If
        ElseIf report_mark_type = "87" Then
            'inventory allocation
            If id_status_reportx = "5" Then
                'cancelled
                Dim cancel_rsv_stock As ClassFGWHAlloc = New ClassFGWHAlloc()
                cancel_rsv_stock.cancelReservedStock(id_report)
            ElseIf id_status_reportx = "6" Then
                'completed
                Dim cmpl_stock As ClassFGWHAlloc = New ClassFGWHAlloc()
                cmpl_stock.completeReservedStock(id_report)
            End If

            query = String.Format("UPDATE tb_fg_wh_alloc SET id_report_status='{0}' WHERE id_fg_wh_alloc ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")

            If form_origin = "FormFGWHAllocDet" Then
                FormFGWHAllocDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormFGWHAllocDet.check_but()
                FormFGWHAllocDet.actionLoad()
                FormFGWHAlloc.viewFGWHAlloc()
                FormFGWHAlloc.GVFGWHAlloc.FocusedRowHandle = find_row(FormFGWHAlloc.GVFGWHAlloc, "id_fg_wh_alloc", id_report)
            End If
        ElseIf report_mark_type = "88" Then
            'generate prepare order
            If id_status_reportx = "5" Then
                Dim cancel As New ClassSalesOrder()
                cancel.cancelReservedStockGen(id_report)
            ElseIf id_status_reportx = "6" Then
                'created transfer
                Dim qv As String = "SELECT so.id_warehouse_contact_to, so.id_store_contact_to, so.id_sales_order, c.id_drawer_def
                FROM tb_sales_order so
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = so.id_store_contact_to
                INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
                WHERE so.id_sales_order_gen=" + id_report + " AND so.id_so_status=5 AND so.is_transfer_data=1 "
                Dim dtv As DataTable = execute_query(qv, -1, True, "", "", "", "")
                If dtv.Rows.Count > 0 Then
                    For m As Integer = 0 To dtv.Rows.Count - 1
                        'main
                        Dim qm As String = "INSERT INTO tb_fg_trf(id_comp_contact_from, id_comp_contact_to, id_sales_order, fg_trf_number, fg_trf_date, fg_trf_date_rec, fg_trf_note, id_report_status, id_report_status_rec, id_wh_drawer, last_update, last_update_by)
                        VALUES('" + dtv.Rows(m)("id_warehouse_contact_to").ToString + "', '" + dtv.Rows(m)("id_store_contact_to").ToString + "', '" + dtv.Rows(m)("id_sales_order").ToString + "', '', NOW(), NOW(), '', '3', '3', '" + dtv.Rows(m)("id_drawer_def").ToString + "', NOW(), " + id_user + "); SELECT LAST_INSERT_ID(); "
                        Dim id_so As String = execute_query(qm, 0, True, "", "", "", "")
                        execute_non_query("CALL gen_number(" + id_so + ", 57)", True, "", "", "", "")
                        'increase_inc_sales("15")

                        'detail
                        Dim qd As String = "INSERT INTO tb_fg_trf_det(id_fg_trf, id_product, id_sales_order_det, fg_trf_det_qty, fg_trf_det_qty_rec, fg_trf_det_qty_stored, fg_trf_det_note)
                        SELECT '" + id_so + "', sd.id_product, sd.id_sales_order_det, sd.sales_order_det_qty, sd.sales_order_det_qty, sd.sales_order_det_qty,''
                        FROM tb_sales_order_det sd
                        WHERE sd.id_sales_order=" + dtv.Rows(m)("id_sales_order").ToString + " "
                        execute_non_query(qd, -1, True, "", "", "")

                        'completed
                        Dim stt As ClassFGTrf = New ClassFGTrf()
                        stt.changeStatus(id_so, "6")

                        'final comment
                        Dim query_comment As String = "INSERT INTO tb_report_mark_final_comment(report_mark_type, id_report, id_report_status, id_user, final_comment, final_comment_date, ip_user) VALUES "
                        query_comment += "('57', '" + id_so + "', '6', '" + id_user + "', '', NOW(), '" + GetIPv4AddressPublic() + "') "
                        execute_non_query(query_comment, True, "", "", "", "")
                    Next
                End If
            End If


            Dim query_update_so As String = "UPDATE tb_sales_order SET id_report_status='" + id_status_reportx + "' WHERE id_sales_order_gen='" + id_report + "' "
            execute_non_query(query_update_so, True, "", "", "", "")

            query = String.Format("UPDATE tb_sales_order_gen SET id_report_status='{0}' WHERE id_sales_order_gen ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")

            If form_origin = "FormSalesOrderGen" Then
                FormSalesOrderGen.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSalesOrderGen.check_but()
                FormSalesOrderGen.actionLoad()
                FormSalesOrder.viewSalesOrderGen()
                FormSalesOrder.GVGen.FocusedRowHandle = find_row(FormSalesOrder.GVGen, "id_sales_order_gen", id_report)
            End If
        ElseIf report_mark_type = "89" Then
            'SAMPLE Receive Local Sample
            If id_status_reportx = "6" Then
                'completed
                Dim complete_rsv_stock As ClassSampleReturnPL = New ClassSampleReturnPL()
                complete_rsv_stock.completeStock(id_report, report_mark_type)
            End If

            query = String.Format("UPDATE tb_sample_pl_ret SET id_report_status='{0}' WHERE id_sample_pl_ret ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            If id_status_reportx = "6" Then
                Dim mail As ClassSendEmail = New ClassSendEmail()
                mail.report_mark_type = report_mark_type
                mail.id_report = id_report
                mail.send_email()
            End If

            'infoCustom("Status changed.")

            If form_origin = "FormSampleReturnPLDet" Then
                FormSampleReturnPLDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSampleReturnPLDet.check_but()
                FormSampleReturnPLDet.actionLoad()
                'FormSampleReturnPL.viewSamplePL()
                'FormSampleReturnPL.GVSamplePL.FocusedRowHandle = find_row(FormSampleReturnPL.GVSamplePL, "id_sample_pl_ret", id_report)
            Else
                'code here
            End If
        ElseIf report_mark_type = "91" Or report_mark_type = "140" Then
            'FG REPAIR
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "5" Then
                Dim cancel As New ClassFGRepair()
                cancel.cancelReservedStock(id_report)
                '
                Dim quniq As String = "INSERT INTO tb_m_unique_code(`id_comp`,`id_wh_drawer`,`id_product`, `id_pl_prod_order_rec_det_unique` ,`id_fg_repair_det`,`id_type`,`unique_code`,
                        `id_design_price`,`design_price`,`qty`,`is_unique_report`,`input_date`) 
                        SELECT c.id_comp, t.`id_wh_drawer_from`, td.id_product, td.id_pl_prod_order_rec_det_unique,  td.id_fg_repair_det, '8', 
                        CONCAT(p.product_full_code,td.fg_repair_det_counting), sod.id_design_price, sod.design_price, 1, 1, NOW() 
                        FROM tb_fg_repair_det td
                        INNER JOIN tb_fg_repair t ON t.id_fg_repair = td.id_fg_repair
                        INNER JOIN tb_m_wh_drawer drw_frm ON drw_frm.id_wh_drawer = t.id_wh_drawer_from  
                        INNER JOIN tb_m_wh_rack rack_frm ON rack_frm.id_wh_rack = drw_frm.id_wh_rack  
                        INNER JOIN tb_m_wh_locator loc_frm ON loc_frm.id_wh_locator = rack_frm.id_wh_locator  
                        INNER JOIN tb_m_comp c ON c.id_comp = loc_frm.id_comp  
                        INNER JOIN tb_m_product p ON p.id_product = td.id_product
                        INNER JOIN tb_m_design d ON d.id_design = p.id_design
                        LEFT JOIN( 
                            SELECT * FROM ( 
	                        SELECT price.id_design, price.design_price, price.design_price_date, price.id_design_price, 
	                        price.id_design_price_type, price_type.design_price_type,
	                        cat.id_design_cat, cat.design_cat
	                        FROM tb_m_design_price price 
	                        INNER JOIN tb_lookup_design_price_type price_type ON price.id_design_price_type = price_type.id_design_price_type 
	                        INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = price_type.id_design_cat
	                        WHERE price.is_active_wh ='1' AND price.design_price_start_date <= NOW() 
	                        ORDER BY price.design_price_start_date DESC, price.id_design_price DESC 
                            ) a 
                            GROUP BY a.id_design 
                        ) sod ON sod.id_design = d.id_design 
                                                WHERE t.id_fg_repair=" & id_report & " AND d.is_old_design=2  AND t.is_use_unique_code=1 "
                execute_non_query(quniq, True, "", "", "", "")
            ElseIf id_status_reportx = "6" Then
                Dim compl As New ClassFGRepair()
                compl.completedStock(id_report)
                '
                'Dim quniq As String = "INSERT INTO tb_m_unique_code(`id_comp`,`id_wh_drawer`,`id_product`, `id_pl_prod_order_rec_det_unique`, `id_fg_repair_det`,`id_type`,`unique_code`,
                '        `id_design_price`,`design_price`,`qty`,`is_unique_report`,`input_date`) 
                '        SELECT c.id_comp, t.`id_wh_drawer_to`, td.id_product, td.id_pl_prod_order_rec_det_unique,  td.id_fg_repair_det, '8', 
                '        CONCAT(p.product_full_code,td.fg_repair_det_counting), sod.id_design_price, sod.design_price, 1, 1, NOW() 
                '        FROM tb_fg_repair_det td
                '        INNER JOIN tb_fg_repair t ON t.id_fg_repair = td.id_fg_repair
                '        INNER JOIN tb_m_wh_drawer drw_frm ON drw_frm.id_wh_drawer = t.id_wh_drawer_to  
                '        INNER JOIN tb_m_wh_rack rack_frm ON rack_frm.id_wh_rack = drw_frm.id_wh_rack  
                '        INNER JOIN tb_m_wh_locator loc_frm ON loc_frm.id_wh_locator = rack_frm.id_wh_locator  
                '        INNER JOIN tb_m_comp c ON c.id_comp = loc_frm.id_comp  
                '        INNER JOIN tb_m_product p ON p.id_product = td.id_product
                '        INNER JOIN tb_m_design d ON d.id_design = p.id_design
                '        LEFT JOIN( 
                '            SELECT * FROM ( 
                '         SELECT price.id_design, price.design_price, price.design_price_date, price.id_design_price, 
                '         price.id_design_price_type, price_type.design_price_type,
                '         cat.id_design_cat, cat.design_cat
                '         FROM tb_m_design_price price 
                '         INNER JOIN tb_lookup_design_price_type price_type ON price.id_design_price_type = price_type.id_design_price_type 
                '         INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = price_type.id_design_cat
                '         WHERE price.is_active_wh ='1' AND price.design_price_start_date <= NOW() 
                '         ORDER BY price.design_price_start_date DESC, price.id_design_price DESC 
                '            ) a 
                '            GROUP BY a.id_design 
                '        ) sod ON sod.id_design = d.id_design 
                '                                WHERE t.id_fg_repair=" & id_report & " AND d.is_old_design=2  AND t.is_use_unique_code=1 "
                'execute_non_query(quniq, True, "", "", "", "")
            End If

            query = String.Format("UPDATE tb_fg_repair SET id_report_status='{0}' WHERE id_fg_repair ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")

            If form_origin = "FormFGRepairDet" Then
                FormFGRepairDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormFGRepairDet.actionLoad()
                FormFGRepair.viewData()
                FormFGRepair.GVRepair.FocusedRowHandle = find_row(FormFGRepair.GVRepair, "id_fg_repair", id_report)
            End If
        ElseIf report_mark_type = "92" Then
            'FG REPAIR REC
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                Dim compl As New ClassFGRepairRec()
                compl.completedStock(id_report)
                'put unique code wh drawer to
                Dim quniq As String = "INSERT INTO tb_m_unique_code(`id_comp`,`id_wh_drawer`,`id_product`, `id_pl_prod_order_rec_det_unique`, `id_fg_repair_rec_det`,`id_type`,`unique_code`,
                        `id_design_price`,`design_price`,`qty`,`is_unique_report`,`input_date`, report_mark_type, id_report, id_report_status) 
                        SELECT c.id_comp, t.`id_wh_drawer_to`, td.id_product, td.id_pl_prod_order_rec_det_unique,  td.id_fg_repair_rec_det, '9', 
                        CONCAT(p.product_full_code,td.fg_repair_rec_det_counting), sod.id_design_price, sod.design_price, 1, 1, NOW(), 92,t.id_fg_repair_rec, '6' 
                        FROM tb_fg_repair_rec_det td
                        INNER JOIN tb_fg_repair_rec t ON t.id_fg_repair_rec = td.id_fg_repair_rec
                        INNER JOIN tb_m_wh_drawer drw_frm ON drw_frm.id_wh_drawer = t.id_wh_drawer_to  
                        INNER JOIN tb_m_wh_rack rack_frm ON rack_frm.id_wh_rack = drw_frm.id_wh_rack  
                        INNER JOIN tb_m_wh_locator loc_frm ON loc_frm.id_wh_locator = rack_frm.id_wh_locator  
                        INNER JOIN tb_m_comp c ON c.id_comp = loc_frm.id_comp  
                        INNER JOIN tb_m_product p ON p.id_product = td.id_product
                        INNER JOIN tb_m_design d ON d.id_design = p.id_design
                        LEFT JOIN( 
                            SELECT * FROM ( 
	                        SELECT price.id_design, price.design_price, price.design_price_date, price.id_design_price, 
	                        price.id_design_price_type, price_type.design_price_type,
	                        cat.id_design_cat, cat.design_cat
	                        FROM tb_m_design_price price 
	                        INNER JOIN tb_lookup_design_price_type price_type ON price.id_design_price_type = price_type.id_design_price_type 
	                        INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = price_type.id_design_cat
	                        WHERE price.is_active_wh ='1' AND price.design_price_start_date <= NOW() 
	                        ORDER BY price.design_price_start_date DESC, price.id_design_price DESC 
                            ) a 
                            GROUP BY a.id_design 
                        ) sod ON sod.id_design = d.id_design 
                        WHERE t.id_fg_repair_rec=" & id_report & " AND d.is_old_design=2 AND t.is_use_unique_code=1 "
                execute_non_query(quniq, True, "", "", "", "")
            ElseIf id_status_reportx = "5" Then
                'cancel reserved unique code
                'Dim quniq As String = "INSERT INTO tb_m_unique_code(`id_comp`,`id_wh_drawer`,`id_product`, `id_pl_prod_order_rec_det_unique`, `id_fg_repair_rec_det`,`id_type`,`unique_code`,
                '        `id_design_price`,`design_price`,`qty`,`is_unique_report`,`input_date`) 
                '        SELECT c.id_comp, t.`id_wh_drawer_from`, td.id_product, td.id_pl_prod_order_rec_det_unique,  td.id_fg_repair_rec_det, '9', 
                '        CONCAT(p.product_full_code,td.fg_repair_rec_det_counting), sod.id_design_price, sod.design_price, 1, 1, NOW() 
                '        FROM tb_fg_repair_rec_det td
                '        INNER JOIN tb_fg_repair_rec t ON t.id_fg_repair_rec = td.id_fg_repair_rec
                '        INNER JOIN tb_m_wh_drawer drw_frm ON drw_frm.id_wh_drawer = t.id_wh_drawer_from  
                '        INNER JOIN tb_m_wh_rack rack_frm ON rack_frm.id_wh_rack = drw_frm.id_wh_rack  
                '        INNER JOIN tb_m_wh_locator loc_frm ON loc_frm.id_wh_locator = rack_frm.id_wh_locator  
                '        INNER JOIN tb_m_comp c ON c.id_comp = loc_frm.id_comp  
                '        INNER JOIN tb_m_product p ON p.id_product = td.id_product
                '        INNER JOIN tb_m_design d ON d.id_design = p.id_design
                '        LEFT JOIN( 
                '            SELECT * FROM ( 
                '         SELECT price.id_design, price.design_price, price.design_price_date, price.id_design_price, 
                '         price.id_design_price_type, price_type.design_price_type,
                '         cat.id_design_cat, cat.design_cat
                '         FROM tb_m_design_price price 
                '         INNER JOIN tb_lookup_design_price_type price_type ON price.id_design_price_type = price_type.id_design_price_type 
                '         INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = price_type.id_design_cat
                '         WHERE price.is_active_wh ='1' AND price.design_price_start_date <= NOW() 
                '         ORDER BY price.design_price_start_date DESC, price.id_design_price DESC 
                '            ) a 
                '            GROUP BY a.id_design 
                '        ) sod ON sod.id_design = d.id_design 
                '        WHERE t.id_fg_repair_rec=" & id_report & " AND d.is_old_design=2 AND t.is_use_unique_code=1 "
                'execute_non_query(quniq, True, "", "", "", "")
            End If

            query = String.Format("UPDATE tb_fg_repair_rec SET id_report_status='{0}' WHERE id_fg_repair_rec ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")

            If form_origin = "FormFGRepairRecDet" Then
                FormFGRepairRecDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormFGRepairRecDet.actionLoad()
                FormFGRepairRec.viewData()
                FormFGRepairRec.viewRepairList()
                FormFGRepairRec.GVRepairRec.FocusedRowHandle = find_row(FormFGRepairRec.GVRepairRec, "id_fg_repair_rec", id_report)
            End If
        ElseIf report_mark_type = "93" Or report_mark_type = "141" Then
            'FG REPAIR RETURN
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "5" Then
                If report_mark_type = "93" Then
                    Dim cancel As New ClassFGRepairReturn()
                    cancel.cancelReservedStock(id_report)
                End If
                'cancel reserved unique
                Dim quniq As String = "INSERT INTO tb_m_unique_code(`id_comp`,`id_wh_drawer`,`id_product`, `id_pl_prod_order_rec_det_unique`, `id_fg_repair_return_det`,`id_type`,`unique_code`,
                        `id_design_price`,`design_price`,`qty`,`is_unique_report`,`input_date`, report_mark_type, id_report, id_report_status) 
                        SELECT c.id_comp, t.`id_wh_drawer_from`, td.id_product, td.id_pl_prod_order_rec_det_unique, td.id_fg_repair_return_det, '10', 
                        CONCAT(p.product_full_code,td.fg_repair_return_det_counting), sod.id_design_price, sod.design_price, 1, 1, NOW(), '" + report_mark_type + "', td.id_fg_repair_return, 5
                        FROM tb_fg_repair_return_det td
                        INNER JOIN tb_fg_repair_return t ON t.id_fg_repair_return = td.id_fg_repair_return
                        INNER JOIN tb_m_wh_drawer drw_frm ON drw_frm.id_wh_drawer = t.id_wh_drawer_from  
                        INNER JOIN tb_m_wh_rack rack_frm ON rack_frm.id_wh_rack = drw_frm.id_wh_rack  
                        INNER JOIN tb_m_wh_locator loc_frm ON loc_frm.id_wh_locator = rack_frm.id_wh_locator  
                        INNER JOIN tb_m_comp c ON c.id_comp = loc_frm.id_comp  
                        INNER JOIN tb_m_product p ON p.id_product = td.id_product
                        INNER JOIN tb_m_design d ON d.id_design = p.id_design
                        LEFT JOIN( 
                            SELECT * FROM ( 
	                        SELECT price.id_design, price.design_price, price.design_price_date, price.id_design_price, 
	                        price.id_design_price_type, price_type.design_price_type,
	                        cat.id_design_cat, cat.design_cat
	                        FROM tb_m_design_price price 
	                        INNER JOIN tb_lookup_design_price_type price_type ON price.id_design_price_type = price_type.id_design_price_type 
	                        INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = price_type.id_design_cat
	                        WHERE price.is_active_wh ='1' AND price.design_price_start_date <= NOW() 
	                        ORDER BY price.design_price_start_date DESC, price.id_design_price DESC 
                            ) a 
                            GROUP BY a.id_design 
                        ) sod ON sod.id_design = d.id_design 
                        WHERE t.id_fg_repair_return=" & id_report & " AND d.is_old_design=2 AND t.is_use_unique_code=1 "
                execute_non_query(quniq, True, "", "", "", "")
                '
                query = String.Format("UPDATE tb_fg_repair_return SET complete_date=NOW() WHERE id_fg_repair_return ='{0}'", id_report)
                execute_non_query(query, True, "", "", "", "")
                '
            ElseIf id_status_reportx = "6" Then
                Dim compl As New ClassFGRepairReturn()
                compl.completedStock(id_report, report_mark_type)

                'insert unique drawer to
                'Dim quniq As String = "INSERT INTO tb_m_unique_code(`id_comp`,`id_wh_drawer`,`id_product`, `id_pl_prod_order_rec_det_unique`, `id_fg_repair_return_det`,`id_type`,`unique_code`,
                '        `id_design_price`,`design_price`,`qty`,`is_unique_report`,`input_date`) 
                '        SELECT c.id_comp, t.`id_wh_drawer_to`, td.id_product, td.id_pl_prod_order_rec_det_unique, td.id_fg_repair_return_det, '10', 
                '        CONCAT(p.product_full_code,td.fg_repair_return_det_counting), sod.id_design_price, sod.design_price, 1, 1, NOW() 
                '        FROM tb_fg_repair_return_det td
                '        INNER JOIN tb_fg_repair_return t ON t.id_fg_repair_return = td.id_fg_repair_return
                '        INNER JOIN tb_m_wh_drawer drw_frm ON drw_frm.id_wh_drawer = t.id_wh_drawer_to  
                '        INNER JOIN tb_m_wh_rack rack_frm ON rack_frm.id_wh_rack = drw_frm.id_wh_rack  
                '        INNER JOIN tb_m_wh_locator loc_frm ON loc_frm.id_wh_locator = rack_frm.id_wh_locator  
                '        INNER JOIN tb_m_comp c ON c.id_comp = loc_frm.id_comp  
                '        INNER JOIN tb_m_product p ON p.id_product = td.id_product
                '        INNER JOIN tb_m_design d ON d.id_design = p.id_design
                '        LEFT JOIN( 
                '            SELECT * FROM ( 
                '         SELECT price.id_design, price.design_price, price.design_price_date, price.id_design_price, 
                '         price.id_design_price_type, price_type.design_price_type,
                '         cat.id_design_cat, cat.design_cat
                '         FROM tb_m_design_price price 
                '         INNER JOIN tb_lookup_design_price_type price_type ON price.id_design_price_type = price_type.id_design_price_type 
                '         INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = price_type.id_design_cat
                '         WHERE price.is_active_wh ='1' AND price.design_price_start_date <= NOW() 
                '         ORDER BY price.design_price_start_date DESC, price.id_design_price DESC 
                '            ) a 
                '            GROUP BY a.id_design 
                '        ) sod ON sod.id_design = d.id_design 
                '        WHERE t.id_fg_repair_return=" & id_report & " AND d.is_old_design=2 AND t.is_use_unique_code=1 "
                'execute_non_query(quniq, True, "", "", "", "")
            End If

            query = String.Format("UPDATE tb_fg_repair_return SET id_report_status='{0}' WHERE id_fg_repair_return ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")

            If form_origin = "FormFGRepairReturnDet" Then
                FormFGRepairReturnDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormFGRepairReturnDet.actionLoad()
                FormFGRepairReturn.viewData()
                FormFGRepairReturn.GVRepairReturn.FocusedRowHandle = find_row(FormFGRepairReturn.GVRepairReturn, "id_fg_repair_return", id_report)
            End If
        ElseIf report_mark_type = "94" Then
            'FG REPAIR RETURN REC
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                Dim compl As New ClassFGRepairReturnRec()
                compl.completedStock(id_report)
                'insert unique drawer to
                Dim quniq As String = "INSERT INTO tb_m_unique_code(`id_comp`,`id_wh_drawer`,`id_product`, `id_pl_prod_order_rec_det_unique`, `id_fg_repair_return_rec_det`,`id_type`,`unique_code`,
                        `id_design_price`,`design_price`,`qty`,`is_unique_report`,`input_date`, report_mark_type, id_report, id_report_status) 
                        SELECT c.id_comp, t.`id_wh_drawer_dest`, td.id_product, td.id_pl_prod_order_rec_det_unique, td.id_fg_repair_return_rec_det, '11', 
                        CONCAT(p.product_full_code,td.fg_repair_return_rec_det_counting), sod.id_design_price, sod.design_price, 1, 1, NOW() ,'" + report_mark_type + "', td.id_fg_repair_return_rec,6
                        FROM tb_fg_repair_return_rec_det td
                        INNER JOIN tb_fg_repair_return_rec t ON t.id_fg_repair_return_rec = td.id_fg_repair_return_rec
                        INNER JOIN tb_m_wh_drawer drw_frm ON drw_frm.id_wh_drawer = t.id_wh_drawer_dest 
                        INNER JOIN tb_m_wh_rack rack_frm ON rack_frm.id_wh_rack = drw_frm.id_wh_rack  
                        INNER JOIN tb_m_wh_locator loc_frm ON loc_frm.id_wh_locator = rack_frm.id_wh_locator  
                        INNER JOIN tb_m_comp c ON c.id_comp = loc_frm.id_comp  
                        INNER JOIN tb_m_product p ON p.id_product = td.id_product
                        INNER JOIN tb_m_design d ON d.id_design = p.id_design
                        LEFT JOIN( 
                            SELECT * FROM ( 
	                        SELECT price.id_design, price.design_price, price.design_price_date, price.id_design_price, 
	                        price.id_design_price_type, price_type.design_price_type,
	                        cat.id_design_cat, cat.design_cat
	                        FROM tb_m_design_price price 
	                        INNER JOIN tb_lookup_design_price_type price_type ON price.id_design_price_type = price_type.id_design_price_type 
	                        INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = price_type.id_design_cat
	                        WHERE price.is_active_wh ='1' AND price.design_price_start_date <= NOW() 
	                        ORDER BY price.design_price_start_date DESC, price.id_design_price DESC 
                            ) a 
                            GROUP BY a.id_design 
                        ) sod ON sod.id_design = d.id_design 
                        WHERE t.id_fg_repair_return_rec=" & id_report & " AND d.is_old_design=2 AND t.is_use_unique_code=1 "
                execute_non_query(quniq, True, "", "", "", "")
                '
                query = String.Format("UPDATE tb_fg_repair_return_rec SET complete_date=NOW() WHERE id_fg_repair_return_rec ='{0}'", id_report)
                execute_non_query(query, True, "", "", "", "")
                '
            ElseIf id_status_reportx = "5" Then
                'cancel reserved unique
                'Dim quniq As String = "INSERT INTO tb_m_unique_code(`id_comp`,`id_wh_drawer`,`id_product`, `id_pl_prod_order_rec_det_unique` ,`id_fg_repair_return_rec_det`,`id_type`,`unique_code`,
                '        `id_design_price`,`design_price`,`qty`,`is_unique_report`,`input_date`) 
                '        SELECT c.id_comp, t.`id_wh_drawer_from`, td.id_product, td.id_pl_prod_order_rec_det_unique, td.id_fg_repair_return_rec_det, '11', 
                '        CONCAT(p.product_full_code,td.fg_repair_return_rec_det_counting), sod.id_design_price, sod.design_price, 1, 1, NOW() 
                '        FROM tb_fg_repair_return_rec_det td
                '        INNER JOIN tb_fg_repair_return_rec t ON t.id_fg_repair_return_rec = td.id_fg_repair_return_rec
                '        INNER JOIN tb_m_wh_drawer drw_frm ON drw_frm.id_wh_drawer = t.id_wh_drawer_from  
                '        INNER JOIN tb_m_wh_rack rack_frm ON rack_frm.id_wh_rack = drw_frm.id_wh_rack  
                '        INNER JOIN tb_m_wh_locator loc_frm ON loc_frm.id_wh_locator = rack_frm.id_wh_locator  
                '        INNER JOIN tb_m_comp c ON c.id_comp = loc_frm.id_comp  
                '        INNER JOIN tb_m_product p ON p.id_product = td.id_product
                '        INNER JOIN tb_m_design d ON d.id_design = p.id_design
                '        LEFT JOIN( 
                '            SELECT * FROM ( 
                '         SELECT price.id_design, price.design_price, price.design_price_date, price.id_design_price, 
                '         price.id_design_price_type, price_type.design_price_type,
                '         cat.id_design_cat, cat.design_cat
                '         FROM tb_m_design_price price 
                '         INNER JOIN tb_lookup_design_price_type price_type ON price.id_design_price_type = price_type.id_design_price_type 
                '         INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = price_type.id_design_cat
                '         WHERE price.is_active_wh ='1' AND price.design_price_start_date <= NOW() 
                '         ORDER BY price.design_price_start_date DESC, price.id_design_price DESC 
                '            ) a 
                '            GROUP BY a.id_design 
                '        ) sod ON sod.id_design = d.id_design 
                '        WHERE t.id_fg_repair_return_rec=" & id_report & " AND d.is_old_design=2 AND t.is_use_unique_code=1 "
                'execute_non_query(quniq, True, "", "", "", "")
            End If

            query = String.Format("UPDATE tb_fg_repair_return_rec SET id_report_status='{0}' WHERE id_fg_repair_return_rec ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")

            If form_origin = "FormFGRepairReturnRecDet" Then
                FormFGRepairReturnRecDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormFGRepairReturnRecDet.actionLoad()
                FormFGRepairReturnRec.viewData()
                FormFGRepairReturnRec.viewRepairList()
                FormFGRepairReturnRec.GVRepairRec.FocusedRowHandle = find_row(FormFGRepairReturnRec.GVRepairRec, "id_fg_repair_return_rec", id_report)
            End If
        ElseIf report_mark_type = "95" Or report_mark_type = "96" Or report_mark_type = "99" Or report_mark_type = "102" Or report_mark_type = "104" Or report_mark_type = "108" Or report_mark_type = "109" Or report_mark_type = "110" Or report_mark_type = "124" Or report_mark_type = "164" Or report_mark_type = "165" Then
            'LEAVE PROPOSE
            If id_status_reportx = "3" Or id_status_reportx = "6" Then
                'update schedule to cuti
                Dim query_upd As String = ""
                query_upd = "UPDATE tb_emp_schedule emps
                                INNER JOIN
                                (SELECT empld.id_schedule,empl.leave_purpose,empl.id_leave_type FROM tb_emp_leave_det empld
                                INNER JOIN tb_emp_leave empl ON empld.id_emp_leave=empl.id_emp_leave
                                WHERE empld.id_emp_leave='" & id_report & "')
                                a ON a.id_schedule=emps.id_schedule
                                SET emps.id_leave_type=a.id_leave_type,emps.info_leave=a.leave_purpose"
                execute_non_query(query_upd, True, "", "", "", "")
                'add if advance
                'select
                Dim query_det As String = "SELECT lve.id_emp,ld.id_emp_leave,SUM(ld.minutes_total) AS qty,NOW() as datex
                                FROM tb_emp_leave_det ld
                                INNER JOIN tb_emp_leave lve ON lve.id_emp_leave=ld.id_emp_leave
                                WHERE ld.id_emp_leave='" & id_report & "' AND lve.id_leave_type='4'
                                GROUP BY ld.id_emp_leave"
                Dim data_det As DataTable = execute_query(query_det, -1, True, "", "", "", "")
                If data_det.Rows.Count > 0 Then
                    Dim qty_adv As Integer = data_det.Rows(0)("qty")
                    '
                    Dim query_sisa As String = "SELECT id_emp,SUM(IF(plus_minus=1,qty,-qty)) AS qty_sisa,`type`,IF(`type`=1,'Leave','DP') as type_ket,date_expired FROM tb_emp_stock_leave
                                WHERE id_emp='" & data_det.Rows(0)("id_emp").ToString & "'
                                GROUP BY id_emp,date_expired,`type`
                                HAVING SUM(IF(plus_minus=1,qty,-qty)) > 0
                                ORDER BY date_expired ASC,`type` DESC"
                    Dim data_sisa As DataTable = execute_query(query_sisa, -1, True, "", "", "", "")
                    If data_sisa.Rows.Count > 0 Then
                        For i_sisa As Integer = 0 To data_sisa.Rows.Count - 1
                            If qty_adv = 0 Then
                                Exit For
                            End If
                            Dim qty_sisa As Integer = data_sisa.Rows(i_sisa)("qty_sisa")
                            If qty_adv >= qty_sisa Then
                                'adv kurangi, qty sisa lawankan dgn sisa
                                qty_adv = qty_adv - qty_sisa
                                Dim query_pot As String = "INSERT INTO tb_emp_stock_leave(id_emp_leave,id_emp,qty,plus_minus,date_leave,date_expired,is_process_exp,note,`type`) VALUES
                                                            ('" & id_report & "','" & data_det.Rows(0)("id_emp").ToString & "','" & qty_sisa.ToString & "','2',NOW(),'" & Date.Parse(data_sisa.Rows(i_sisa)("date_expired").ToString).ToString("yyyy-MM-dd") & "','2','Auto Paid Advance Leave(" & report_number & ")','" & data_sisa.Rows(i_sisa)("type").ToString & "')"
                                execute_non_query(query_pot, True, "", "", "", "")
                            Else
                                'qty sisa kurangi , lawankan dgn adv
                                Dim query_pot As String = "INSERT INTO tb_emp_stock_leave(id_emp_leave,id_emp,qty,plus_minus,date_leave,date_expired,is_process_exp,note,`type`) VALUES
                                                            ('" & id_report & "','" & data_det.Rows(0)("id_emp").ToString & "','" & qty_adv.ToString & "','2',NOW(),'" & Date.Parse(data_sisa.Rows(i_sisa)("date_expired").ToString).ToString("yyyy-MM-dd") & "','2','Auto Paid Advance Leave(" & report_number & ")','" & data_sisa.Rows(i_sisa)("type").ToString & "')"
                                execute_non_query(query_pot, True, "", "", "", "")
                                qty_adv = 0
                            End If
                        Next
                    End If
                    If qty_adv > 0 Then
                        Dim query_pot As String = "INSERT INTO tb_emp_stock_leave_adv(id_emp,id_emp_leave,qty,adv_datetime)
                                SELECT lve.id_emp,lve.id_emp_leave,'" & qty_adv.ToString & "' AS qty,NOW()
                                FROM tb_emp_leave lve WHERE lve.id_emp_leave='" & id_report & "' AND lve.id_leave_type='4'"
                        execute_non_query(query_pot, True, "", "", "", "")
                    End If
                End If

                'complete
                id_status_reportx = "6"
                'mail
                Dim mail As ClassSendEmail = New ClassSendEmail()
                mail.report_mark_type = report_mark_type
                mail.send_email_appr(report_mark_type, id_report, True)
            ElseIf id_status_reportx = "5" Then 'cancel
                Dim query_cancel As String = ""
                query_cancel = "DELETE FROM tb_emp_stock_leave_adv WHERE id_emp_leave='" & id_report & "'"
                execute_non_query(query_cancel, True, "", "", "", "")
                query_cancel = "DELETE FROM tb_emp_stock_leave WHERE id_emp_leave='" & id_report & "'"
                execute_non_query(query_cancel, True, "", "", "", "")
                query_cancel = "UPDATE tb_report_mark SET id_mark = '3' WHERE id_mark = '1' AND report_mark_type = '" + report_mark_type + "' AND id_report = '" & id_report & "'"
                execute_non_query(query_cancel, True, "", "", "", "")
            End If
            query = String.Format("UPDATE tb_emp_leave SET id_report_status='{0}' WHERE id_emp_leave ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'FormEmpLeave.load_sum()
        ElseIf report_mark_type = "97" Then
            'DP
            If id_status_reportx = "3" Then
                'complete
                Dim query_det As String = "SELECT det.id_dp,dp.id_employee,det.subtotal_hour,pr.periode_end,det.remark
                                            FROM tb_emp_dp_det det
                                            INNER JOIN tb_emp_dp dp ON dp.id_dp=det.id_dp
                                            INNER JOIN tb_emp_payroll pr ON pr.`id_payroll`=dp.id_payroll
                                            WHERE det.id_dp='" & id_report & "'"
                Dim data_det As DataTable = execute_query(query_det, -1, True, "", "", "", "")
                If data_det.Rows.Count > 0 Then
                    For i As Integer = 0 To data_det.Rows.Count - 1
                        query = "INSERT INTO tb_emp_stock_leave(id_emp_dp,id_emp,qty,plus_minus,date_leave,date_expired,is_process_exp,note,`type`) VALUES
                        ('" & id_report & "','" & data_det.Rows(i)("id_employee").ToString & "','" & (data_det.Rows(i)("subtotal_hour") * 60).ToString & "','1',NOW(),'" & Date.Parse(data_det.Rows(i)("periode_end").ToString).AddMonths(6).ToString("yyyy-MM-dd") & "','2','" & data_det.Rows(i)("remark").ToString & "','2')"
                        execute_non_query(query, True, "", "", "", "")
                    Next
                End If
                '
                id_status_reportx = "6"
            End If
            query = String.Format("UPDATE tb_emp_dp SET id_report_status='{0}' WHERE id_dp ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "98" Then
            'Employee change schedule
            If id_status_reportx = "6" Then
                'complete
                query = "UPDATE tb_emp_schedule sch
                            INNER JOIN(
                            SELECT schdf.id_schedule
                            ,IF(ISNULL(schdt.in),NULL,CONCAT(schdf.date,' ',TIME(schdt.in))) AS `in`
                            ,IF(ISNULL(schdt.in),NULL,CONCAT(schdf.date,' ',TIME(schdt.out))) AS `out`
                            ,IF(ISNULL(schdt.in),NULL,CONCAT(schdf.date,' ',TIME(schdt.in_tolerance))) AS `in_tolerance`
                            ,IF(ISNULL(schdt.in),NULL,CONCAT(schdf.date,' ',TIME(schdt.break_out))) AS `break_out`
                            ,IF(ISNULL(schdt.in),NULL,CONCAT(schdf.date,' ',TIME(schdt.break_in))) AS `break_in`
                            ,schdt.minutes_work AS `minutes_work`
                            ,schdt.id_schedule_type AS `id_schedule_type`
                            ,schdt.note AS `note`
                            ,schdt.shift_code AS `shift_code`
                            FROM tb_emp_ch_schedule_det schdf
                            INNER JOIN tb_emp_ch_schedule_det schdt ON schdt.id_emp_ch_schedule=schdf.id_emp_ch_schedule
                            AND schdt.from_to='2'
                            WHERE schdf.from_to = '1'
                            AND schdf.id_emp_ch_schedule='" & id_report & "'
                            ) switch ON switch.id_schedule=sch.id_schedule
                            SET sch.in=switch.in
                            ,sch.out=switch.out
                            ,sch.in_tolerance=switch.in_tolerance
                            ,sch.break_out=switch.break_out
                            ,sch.break_in=switch.break_in
                            ,sch.minutes_work=switch.minutes_work
                            ,sch.id_schedule_type=switch.id_schedule_type
                            ,sch.note=switch.note
                            ,sch.shift_code=switch.shift_code"
                execute_non_query(query, True, "", "", "", "")
                query = "UPDATE tb_emp_schedule sch
                            INNER JOIN(
                            SELECT schdf.id_schedule
                            ,IF(ISNULL(schdt.in),NULL,CONCAT(schdf.date,' ',TIME(schdt.in))) AS `in`
                            ,IF(ISNULL(schdt.in),NULL,CONCAT(schdf.date,' ',TIME(schdt.out))) AS `out`
                            ,IF(ISNULL(schdt.in),NULL,CONCAT(schdf.date,' ',TIME(schdt.in_tolerance))) AS `in_tolerance`
                            ,IF(ISNULL(schdt.in),NULL,CONCAT(schdf.date,' ',TIME(schdt.break_out))) AS `break_out`
                            ,IF(ISNULL(schdt.in),NULL,CONCAT(schdf.date,' ',TIME(schdt.break_in))) AS `break_in`
                            ,schdt.minutes_work AS `minutes_work`
                            ,schdt.id_schedule_type AS `id_schedule_type`
                            ,schdt.note AS `note`
                            ,schdt.shift_code AS `shift_code`
                            FROM tb_emp_ch_schedule_det schdf
                            INNER JOIN tb_emp_ch_schedule_det schdt ON schdt.id_emp_ch_schedule=schdf.id_emp_ch_schedule
                            AND schdt.from_to='1'
                            WHERE schdf.from_to ='2'
                            AND schdf.id_emp_ch_schedule='" & id_report & "'
                            ) switch ON switch.id_schedule=sch.id_schedule
                            SET sch.in=switch.in
                            ,sch.out=switch.out
                            ,sch.in_tolerance=switch.in_tolerance
                            ,sch.break_out=switch.break_out
                            ,sch.break_in=switch.break_in
                            ,sch.minutes_work=switch.minutes_work
                            ,sch.id_schedule_type=switch.id_schedule_type
                            ,sch.note=switch.note
                            ,sch.shift_code=switch.shift_code"
                execute_non_query(query, True, "", "", "", "")
                id_status_reportx = "6"
            End If
            query = String.Format("UPDATE tb_emp_ch_schedule SET id_report_status='{0}' WHERE id_emp_ch_schedule ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "100" Or report_mark_type = "240" Then
            'Schedule PROPOSE with approval
            If id_status_reportx = "3" Then
                'update schedule
                Dim query_after As String = "SELECT sch.id_employee,IFNULL(s.id_shift,0) as id_shift,sch.date FROM tb_emp_assign_sch_det sch
                                                LEFT JOIN tb_emp_shift s ON sch.shift_code=s.shift_code
                                                WHERE id_emp_assign_sch='" & id_report & "' AND `type`='2'"
                Dim data_after As DataTable = execute_query(query_after, -1, True, "", "", "", "")
                For j As Integer = 0 To data_after.Rows.Count - 1
                    Dim id_shift, id_empployee_varx, date_var As String
                    id_shift = data_after(j)("id_shift").ToString
                    id_empployee_varx = data_after(j)("id_employee").ToString
                    date_var = Date.Parse(data_after(j)("date").ToString).ToString("yyy-MM-dd")

                    If Not id_shift = "" Then
                        If id_shift = "0" Then
                            Dim query_shift As String = "CALL add_shift(" & id_empployee_varx & ",1,'" & date_var & "','" & date_var & "',2)"
                            execute_non_query(query_shift, True, "", "", "", "")
                        Else
                            Dim query_shift As String = "CALL add_shift(" & id_empployee_varx & "," & id_shift & ",'" & date_var & "','" & date_var & "',1)"
                            execute_non_query(query_shift, True, "", "", "", "")
                        End If
                    End If
                Next

                'complete
                id_status_reportx = "6"
            End If
            query = String.Format("UPDATE tb_emp_assign_sch SET id_report_status='{0}' WHERE id_assign_sch ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
        ElseIf report_mark_type = "101" Then
            'Air Ways Bill
            If id_status_reportx = "3" Then
                'complete
                id_status_reportx = "6"
            End If
            query = String.Format("UPDATE tb_wh_awbill SET id_report_status='{0}' WHERE id_awbill ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
        ElseIf report_mark_type = "103" Then
            'combine del
            Dim stt As ClassSalesDelOrder = New ClassSalesDelOrder()
            stt.changeStatusHead(id_report, id_status_reportx)
            'infoCustom("Status changed.")

            FormSalesDelOrderSlip.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
            FormSalesDelOrderSlip.actionLoad()
        ElseIf report_mark_type = "105" Or report_mark_type = "224" Then
            'Final Clear
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            query = String.Format("UPDATE tb_prod_fc SET id_report_status='{0}' WHERE id_prod_fc ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")

            If form_origin = "FormProductionFinalClearDet" Then
                FormProductionFinalClearDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormProductionFinalClearDet.actionLoad()
                FormProductionFinalClear.viewFinalClear()
                FormProductionFinalClear.GVFinalClear.FocusedRowHandle = find_row(FormProductionFinalClear.GVFinalClear, "id_prod_fc", id_report)
            End If
        ElseIf report_mark_type = "107" Then
            Cursor = Cursors.WaitCursor
            'production assem
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            Dim ch_stt As New ClassProductionAssembly()
            ch_stt.changeStatus(id_report, id_status_reportx)

            If form_origin = "FormProductionAssemblySingle" Then
                FormProductionAssemblySingle.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormProductionAssemblySingle.actionLoad()
                FormProductionAssembly.viewData()
                FormProductionAssembly.GVData.FocusedRowHandle = find_row(FormProductionAssembly.GVData, "id_prod_ass", id_report)
            End If
            Cursor = Cursors.Default
        ElseIf report_mark_type = "111" Then
            Cursor = Cursors.WaitCursor
            'out non stock

            Dim ch_stt As New ClassDelEmpty()
            ch_stt.changeStatus(id_report, id_status_reportx)

            If form_origin = "FormProductionAssemblySingle" Then
                FormWHDelEmptyDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormWHDelEmptyDet.actionLoad()
                FormWHDelEmpty.viewDel()
                FormWHDelEmpty.GVDel.FocusedRowHandle = find_row(FormWHDelEmpty.GVDel, "id_wh_del_empty", id_report)
            End If
            Cursor = Cursors.Default
        ElseIf report_mark_type = "116" Then
            'Invoice missing promo
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                'completed
                Dim inv As ClassSalesInv = New ClassSalesInv()
                inv.postingJournal(id_report, report_mark_type)
            End If

            query = String.Format("UPDATE tb_sales_pos SET id_report_status='{0}' WHERE id_sales_pos ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")

            If form_origin = "FormSalesPOSDet" Then
                FormSalesPOSDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSalesPOSDet.check_but()
                FormSalesPOSDet.actionLoad()
                FormSalesPOS.viewSalesPOS()
                FormSalesPOS.GVSalesPOS.FocusedRowHandle = find_row(FormSalesPOS.GVSalesPOS, "id_sales_pos", id_report)
            Else
                'code here
            End If
        ElseIf report_mark_type = "117" Then
            'imvoice missing staff
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "5" Then
                Dim cancel_rsv_stock As ClassSalesInv = New ClassSalesInv()

                If FormSalesPOSDet.is_use_unique_code = "1" Then
                    'cancelled unique
                    cancel_rsv_stock.cancellUnique(id_report, report_mark_type)
                End If

                'cancelled stock
                cancel_rsv_stock.cancelReservedStock(id_report, "117")
            ElseIf id_status_reportx = "6" Then
                'completed
                Dim complete_rsv_stock As ClassSalesInv = New ClassSalesInv()
                complete_rsv_stock.completedStockMissingStaff(id_report, "117")
            End If

            'update status
            query = String.Format("UPDATE tb_sales_pos SET id_report_status='{0}' WHERE id_sales_pos ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")

            If form_origin = "FormSalesPOSDet" Then
                FormSalesPOSDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSalesPOSDet.check_but()
                FormSalesPOSDet.actionLoad()
                FormSalesPOS.viewSalesPOS()
                FormSalesPOS.GVSalesPOS.FocusedRowHandle = find_row(FormSalesPOS.GVSalesPOS, "id_sales_pos", id_report)
            Else
                'code here
            End If
        ElseIf report_mark_type = "119" Then
            'return Order ol
            If id_status_reportx = "5" Then
                Dim ro As New ClassSalesReturnOrder()
                ro.cancelReservedStock(id_report)
            ElseIf id_status_reportx = "6" Then
                'update stt in return centre
                Try
                    Dim qstt As String = "UPDATE tb_ol_store_ret_list main
                    INNER JOIN (
                       SELECT d.id_ol_store_ret_list 
                       FROM tb_sales_return_order_det d
                       WHERE d.id_sales_return_order=" + id_report + "
                       GROUP BY d.id_ol_store_ret_list
                    ) src ON src.id_ol_store_ret_list = main.id_ol_store_ret_list
                    SET main.id_ol_store_ret_stt=8;
                    INSERT IGNORE INTO tb_sales_order_det_status(id_sales_order_det, `status`, `status_date`, `input_status_date`, is_internal)
                    SELECT rd.id_sales_order_det, stt.ol_store_ret_stt, NOW(), NOW(),1
                    FROM tb_sales_return_order_det d
                    INNER JOIN tb_ol_store_ret_list rl ON rl.id_ol_store_ret_list = d.id_ol_store_ret_list
                    INNER JOIN tb_ol_store_ret_det rd ON rd.id_ol_store_ret_det = rl.id_ol_store_ret_det
                    JOIN tb_lookup_ol_store_ret_stt stt ON stt.id_ol_store_ret_stt=8
                    WHERE d.id_sales_return_order=" + id_report + "
                    GROUP BY rd.id_sales_order_det; "
                    execute_non_query(qstt, True, "", "", "", "")
                Catch ex As Exception
                    stopCustom("Error updating status in return centre. " + ex.ToString)
                End Try

                'send mail for process return
                Try

                Catch ex As Exception

                End Try
            End If

            query = String.Format("UPDATE tb_sales_return_order SET id_report_status='{0}' WHERE id_sales_return_order ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")

            If form_origin = "FormSalesReturnOrderOLDet" Then
                FormSalesReturnOrderOLDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSalesReturnOrderOLDet.check_but()
                FormSalesReturnOrderOLDet.actionLoad()
                FormSalesReturnOrderOL.viewSalesReturnOrder()
                FormSalesReturnOrderOL.GVSalesReturnOrder.FocusedRowHandle = find_row(FormSalesReturnOrderOL.GVSalesReturnOrder, "id_sales_return_order", id_report)
            Else
                'code here
            End If
        ElseIf report_mark_type = "123" Then
            'list uniform
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            query = String.Format("UPDATE tb_emp_uni_design SET id_report_status='{0}' WHERE id_emp_uni_design ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'kalo completed generate nomer urut
            If id_status_reportx = "6" Then
                Dim qm As String = "SELECT IFNULL(MAX(dd.`no`),0) AS `maks` FROM tb_emp_uni_design_det dd
                INNER JOIN tb_emp_uni_design d ON d.id_emp_uni_design = dd.id_emp_uni_design
                WHERE d.id_emp_uni_period=" + FormEmpUniListDet.LEPeriodx.EditValue.ToString + " AND d.id_report_status=6 "
                Dim dm As DataTable = execute_query(qm, -1, True, "", "", "", "")
                Dim maks As Integer = dm.Rows(0)("maks")

                Dim qn As String = "UPDATE tb_emp_uni_design_det main
                INNER JOIN (
                    SELECT d.*,  @a:=@a+1 `counting`
                    FROM (
                        SELECT dd.id_emp_uni_design_det,dd.id_design, LEFT(cd.code_detail_name,1) AS `dv`
                        FROM tb_emp_uni_design_det dd
                        INNER JOIN tb_m_design d ON d.id_design = dd.id_design
                        INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
	                    INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail AND cd.id_code=32
                        INNER JOIN tb_m_design_code dc2 ON dc2.id_design = d.id_design
                        INNER JOIN tb_m_code_detail cd2 ON cd2.id_code_detail = dc2.id_code_detail AND cd2.id_code=30
                        WHERE dd.id_emp_uni_design =" + id_report + "
                        ORDER BY cd.id_code_detail ASC, cd2.display_name ASC, d.design_code ASC
                    ) d, (SELECT @a:= " + maks.ToString + ") AS a
                ) src ON src.id_emp_uni_design_det = main.id_emp_uni_design_det
                SET main.no = src.counting, main.division = src.dv "
                execute_non_query(qn, True, "", "", "", "")

                'update point
                execute_non_query("CALL set_emp_uni_point(" + FormEmpUniListDet.id_emp_uni_period + ")", True, "", "", "", "")
            End If


            'infoCustom("Status changed.")

            FormEmpUniListDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
            FormEmpUniListDet.actionLoad()
            FormEmpUniList.viewData()
            FormEmpUniList.GVData.FocusedRowHandle = find_row(FormEmpUniList.GVData, "id_emp_uni_design", id_report)
        ElseIf report_mark_type = "125" Then
            'leave cut
            If id_status_reportx = "5" Then
                '
            ElseIf id_status_reportx = "6" Then

            End If

            query = String.Format("UPDATE tb_emp_leave_cut SET id_report_status='{0}' WHERE id_leave_cut ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
        ElseIf report_mark_type = "126" Then
            'Production Over Memo

            If id_status_reportx = "6" Then
                Cursor = Cursors.WaitCursor

                'check upload file
                Dim query_file As String = "SELECT * FROM tb_doc d WHERE d.report_mark_type='" + report_mark_type + "' AND d.id_report='" + id_report + "' "
                Dim data_file As DataTable = execute_query(query_file, -1, True, "", "", "", "")
                If data_file.Rows.Count <= 0 Then
                    stopCustom("Document not found. Please attach document first")
                    Cursor = Cursors.Default
                    Exit Sub
                End If

                Dim query_upd_datetime As String = "UPDATE tb_prod_over_memo SET created_date=NOW() WHERE id_prod_over_memo='" + id_report + "' "
                execute_non_query(query_upd_datetime, True, "", "", "", "")
                Dim mail As New ClassSendEmail()
                mail.report_mark_type = "126"
                mail.id_report = id_report
                mail.send_email()
                Cursor = Cursors.Default
            ElseIf id_status_reportx = "5" Then
                Dim qu As String = "UPDATE tb_prod_order_rec SET id_report_status=5 WHERE id_prod_over_memo='" + id_report + "' "
                execute_non_query(qu, True, "", "", "", "")
            End If

            Dim query_upd As String = "UPDATE tb_prod_over_memo SET id_report_status='" + id_status_reportx + "' WHERE id_prod_over_memo='" + id_report + "' "
            execute_non_query(query_upd, True, "", "", "", "")
            FormProdOverMemoDet.actionLoad()
            FormProdOverMemo.viewData()
            FormProdOverMemo.GVMemo.FocusedRowHandle = find_row(FormProdOverMemo.GVMemo, "id_prod_over_memo", id_report)
        ElseIf report_mark_type = "128" Then
            'Asset PO
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            query = String.Format("UPDATE tb_a_asset_po SET id_report_status='{0}' WHERE id_asset_po ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")

            If form_origin = "FormAssetPODet" Then
                FormAssetPODet.load_det()
                FormAssetPO.load_po()
                FormAssetPO.GVPOList.FocusedRowHandle = find_row(FormAssetPO.GVPOList, "id_asset_po", id_report)
            Else
                'code here
            End If
        ElseIf report_mark_type = "129" Then
            'Asset PO
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            '
            query = String.Format("UPDATE tb_a_asset_rec SET id_report_status='{0}' WHERE id_asset_rec ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")
            '
            If id_status_reportx = "6" Then
                'insert to master asset
                query = String.Format("SELECT recd.qty_rec,pod.`id_asset_cat`,recd.`id_asset_rec_det`,pod.`desc`,pod.`id_departement`,0 AS id_employee,1 AS id_user_created,1 AS id_user_last_upd,DATE(NOW()) AS date_created,DATE(NOW()) AS date_last_upd FROM tb_a_asset_rec_det recd
                                        INNER JOIN tb_a_asset_po_det pod ON pod.`id_asset_po_det`=recd.`id_asset_po_det`
                                        WHERE id_asset_rec='{0}'", id_report)
                Dim data_sel As DataTable = execute_query(query, -1, True, "", "", "", "")
                For sel As Integer = 0 To data_sel.Rows.Count - 1
                    Dim qty_rec As Integer = data_sel.Rows(sel)("qty_rec")
                    For ins As Integer = 0 To qty_rec - 1
                        Dim query_ins As String = String.Format("INSERT INTO tb_a_asset(id_asset_cat,id_asset_rec_det,`asset_desc`,id_departement,id_employee,id_user_created,id_user_last_upd,date_created,date_last_upd)
                                        SELECT pod.`id_asset_cat`,recd.`id_asset_rec_det`,pod.`desc`,pod.`id_departement`,0 AS id_employee,'" & id_user & "' AS id_user_created,'" & id_user & "' AS id_user_last_upd,DATE(NOW()) AS date_created,DATE(NOW()) AS date_last_upd FROM tb_a_asset_rec_det recd
                                        INNER JOIN tb_a_asset_po_det pod ON pod.`id_asset_po_det`=recd.`id_asset_po_det`
                                        WHERE recd.id_asset_rec_det='{0}'", data_sel.Rows(sel)("id_asset_rec_det"))
                        execute_non_query(query_ins, True, "", "", "", "")
                    Next
                Next
            End If

            If form_origin = "FormAssetRecDet" Then
                FormAssetRecDet.load_det()
                FormAssetRec.load_rec()
                FormAssetRec.GVRecList.FocusedRowHandle = find_row(FormAssetRec.GVRecList, "id_asset_rec", id_report)
            Else
                'code here
            End If
        ElseIf report_mark_type = "132" Or report_mark_type = "236" Then
            'Uniform expense
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "5" Then
                'cancelled
                If report_mark_type = "132" Then
                    Dim cancel_rsv_stock As ClassEmpUniExpense = New ClassEmpUniExpense()
                    cancel_rsv_stock.cancelReservedStock(id_report, report_mark_type)
                End If
            ElseIf id_status_reportx = "6" Then
                'completed
                Dim complete_rsv_stock As ClassEmpUniExpense = New ClassEmpUniExpense()
                complete_rsv_stock.completedStock(id_report, report_mark_type)
            End If

            'update status
            query = String.Format("UPDATE tb_emp_uni_ex SET id_report_status='{0}' WHERE id_emp_uni_ex ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")

            If form_origin = "FormEmpUniExpenseDet" Then
                FormEmpUniExpenseDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormEmpUniExpenseDet.actionLoad()
                FormEmpUniExpense.viewData()
                FormEmpUniExpense.GVData.FocusedRowHandle = find_row(FormEmpUniExpense.GVData, "id_emp_uni_ex", id_report)
            ElseIf form_origin = "FormEmpUniCreditNoteDet" Then
                FormEmpUniCreditNoteDet.load_form()
                FormEmpUniCreditNote.view_form()
                FormEmpUniCreditNote.GVData.FocusedRowHandle = find_row(FormEmpUniCreditNote.GVData, "id_emp_uni_ex", id_report)
            Else
                'code here
            End If
        ElseIf report_mark_type = "133" Then
            'REVENUE BUDGET
            'auto completed
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                Dim qc As String = "SELECT r.`year`, rd.`month`, rd.id_store, rd.b_revenue_propose
                FROM tb_b_revenue_propose_det rd
                INNER JOIN tb_b_revenue_propose r ON r.id_b_revenue_propose = rd.id_b_revenue_propose
                WHERE r.id_b_revenue_propose=" + id_report + " "
                Dim dc As DataTable = execute_query(qc, -1, True, "", "", "", "")
                For i As Integer = 0 To dc.Rows.Count - 1
                    Dim year As String = dc.Rows(i)("year").ToString
                    Dim month As String = dc.Rows(i)("month").ToString
                    Dim id_store As String = dc.Rows(i)("id_store").ToString
                    Dim b_revenue_propose As String = decimalSQL(dc.Rows(i)("b_revenue_propose").ToString)

                    'insert tb revenue
                    Dim qi As String = "INSERT INTO tb_b_revenue (
	                    `year`,
	                    `month`,
	                    `id_store`,
	                    `b_revenue`
                    ) VALUES ('" + year + "', '" + month + "', '" + id_store + "', '" + b_revenue_propose + "'); SELECT LAST_INSERT_ID(); "
                    Dim id_b_revenue As String = execute_query(qi, 0, True, "", "", "", "")

                    'insert log
                    Dim ql As String = "INSERT INTO tb_b_revenue_log(
	                    `id_b_revenue`,
	                    `value_old`,
	                    `value_new`,
	                    `log_date`,
	                    `id_user`,
	                    `id_report`,
	                    `report_mark_type`
                    ) VALUES('" + id_b_revenue + "', 0, '" + b_revenue_propose + "', NOW(), '" + id_user + "', '" + id_report + "', '133'); "
                    execute_non_query(ql, True, "", "", "", "")
                Next
            End If

            'update status
            query = String.Format("UPDATE tb_b_revenue_propose SET id_report_status='{0}' WHERE id_b_revenue_propose ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            FormBudgetRevProposeDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
            FormBudgetRevProposeDet.actionLoad()
            FormBudgetRevPropose.viewData()
            FormBudgetRevPropose.GVRev.FocusedRowHandle = find_row(FormBudgetRevPropose.GVRev, "id_b_revenue_propose", id_report)
        ElseIf report_mark_type = "134" Then
            'POPOSE NEW ITEM CAT
            'auto completed
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
                query = "INSERT INTO tb_item_cat(`id_expense_type`,`id_item_cat_main` ,`item_cat`, `item_cat_en`)
		                SELECT d.id_expense_type,d.id_item_cat_main, d.item_cat, d.item_cat_en 
		                FROM tb_item_cat_propose_det d
		                WHERE d.id_item_cat_propose = '" & id_report & "'"
                execute_non_query(query, True, "", "", "", "")
            End If

            'jika cancel

            'update status
            query = String.Format("UPDATE tb_item_cat_propose SET id_report_status='{0}' WHERE id_item_cat_propose ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            FormItemCatProposeDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
            FormItemCatProposeDet.actionLoad()
            FormItemCatPropose.viewPropose()
            FormItemCatPropose.GVData.FocusedRowHandle = find_row(FormItemCatPropose.GVData, "id_item_cat_propose", id_report)
        ElseIf report_mark_type = "135" Then
            'POPOSE NEW ITEM COA
            'auto completed
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                'main inv store
                If FormItemCatMappingDet.TxtProposeCodeInvStore.Text <> "" Then
                    Dim qmr As String = "UPDATE tb_opt_purchasing main
                    JOIN tb_item_coa_propose src ON src.id_item_coa_propose=" + id_report + "
                    SET main.acc_coa_receive = src.acc_coa_receive "
                    execute_non_query(qmr, True, "", "", "", "")
                End If

                'main hutang
                If FormItemCatMappingDet.TxtProposeCodeHutang.Text <> "" Then
                    Dim qmh As String = "UPDATE tb_opt_purchasing main
                    JOIN tb_item_coa_propose src ON src.id_item_coa_propose=" + id_report + "
                    SET main.acc_coa_hutang = src.acc_coa_hutang "
                    execute_non_query(qmh, True, "", "", "", "")
                End If

                'main trf
                If FormItemCatMappingDet.TxtProposeCodeInvWH.Text <> "" Then
                    Dim qmt As String = "UPDATE tb_opt_purchasing main
                    JOIN tb_item_coa_propose src ON src.id_item_coa_propose=" + id_report + "
                    SET main.acc_coa_trf = src.acc_coa_trf "
                    execute_non_query(qmt, True, "", "", "", "")
                End If

                'detail
                Dim qd As String = "INSERT INTO tb_item_coa(id_item_coa_propose_det,id_item_cat, id_departement, id_coa_in, id_coa_out, is_request, is_expense)
		        SELECT d.id_item_coa_propose_det, d.id_item_cat, d.id_departement, d.id_coa_in, d.id_coa_out, d.is_request, d.is_expense
		        FROM tb_item_coa_propose_det d
		        WHERE d.id_item_coa_propose = " + id_report + "; "
                execute_non_query(qd, True, "", "", "", "")
            End If

            'update status
            query = String.Format("UPDATE tb_item_coa_propose SET id_report_status='{0}' WHERE id_item_coa_propose ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            FormItemCatMappingDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
            FormItemCatMappingDet.actionLoad()
            FormItemCatMapping.viewPropose()
            FormItemCatMapping.GVPropose.FocusedRowHandle = find_row(FormItemCatMapping.GVPropose, "id_item_coa_propose", id_report)
        ElseIf report_mark_type = "136" Then
            'Expense BUDGET
            'auto completed
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                'budget year & month
                Dim idb_new As String = "0"
                Dim idy As String = "0"
                Dim qall As String = "SELECT y.id_b_expense_propose_year, y.id_b_expense_propose, y.year, y.id_item_coa, y.value_expense AS `value_year`,
                m.id_b_expense_propose_month, m.month, m.value_expense
                FROM tb_b_expense_propose_year y
                INNER JOIN tb_b_expense_propose_month m ON m.id_b_expense_propose_year = y.id_b_expense_propose_year
                WHERE y.id_b_expense_propose=" + id_report + "
                ORDER BY y.id_b_expense_propose_year ASC "
                Dim dall As DataTable = execute_query(qall, -1, True, "", "", "", "")
                For i As Integer = 0 To dall.Rows.Count - 1
                    If idy <> dall.Rows(i)("id_b_expense_propose_year").ToString Then
                        'isi id year baru jika ud beda dengan row saat ini
                        idy = dall.Rows(i)("id_b_expense_propose_year").ToString

                        'insert budget tahunan
                        Dim qyi As String = "INSERT INTO tb_b_expense(year, id_item_coa, value_expense)
                        VALUES('" + dall.Rows(i)("year").ToString + "', '" + dall.Rows(i)("id_item_coa").ToString + "','" + decimalSQL(dall.Rows(i)("value_year").ToString) + "'); SELECT LAST_INSERT_ID(); "
                        idb_new = execute_query(qyi, 0, True, "", "", "", "")

                        'insert log budget tahunan
                        Dim qyl As String = "INSERT INTO tb_b_expense_log(id_b_expense, value_old, value_new, log_date, id_user, id_report, report_mark_type)
                        VALUES('" + idb_new + "', 0, '" + decimalSQL(dall.Rows(i)("value_year").ToString) + "', NOW(),'" + id_user + "', '" + id_report + "', 136); "
                        execute_non_query(qyl, True, "", "", "", "")
                    End If

                    'insert detil bulanan
                    Dim qm As String = "INSERT INTO tb_b_expense_month(id_b_expense, month, value_expense) VALUES
                    ('" + idb_new + "', '" + DateTime.Parse(dall.Rows(i)("month").ToString).ToString("yyyy-MM-dd") + "', '" + decimalSQL(dall.Rows(i)("value_expense").ToString) + "'); SELECT LAST_INSERT_ID(); "
                    Dim idb_month_new As String = execute_query(qm, 0, True, "", "", "", "")

                    'insert log detil bulanan
                    Dim qmlog As String = "INSERT INTO tb_b_expense_month_log(id_b_expense_month, value_old, value_new, log_date, id_user, id_report, report_mark_type)
                    VALUES('" + idb_month_new + "', 0 ,'" + decimalSQL(dall.Rows(i)("value_expense").ToString) + "', NOW(), '" + id_user + "', '" + id_report + "', 136); "
                    execute_non_query(qmlog, True, "", "", "", "")
                Next
            End If


            'update status
            query = String.Format("UPDATE tb_b_expense_propose SET id_report_status='{0}' WHERE id_b_expense_propose ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            FormBudgetExpenseProposeDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
            FormBudgetExpenseProposeDet.actionLoad()
            FormBudgetExpensePropose.viewData()
            FormBudgetExpensePropose.GVData.FocusedRowHandle = find_row(FormBudgetExpensePropose.GVData, "id_b_expense_propose", id_report)
        ElseIf report_mark_type = "137" Or report_mark_type = "201" Or report_mark_type = "218" Then
            'Purchase request
            'auto completed
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            ElseIf id_status_reportx = "5" Then
                'Cancel Storage
                'Dim query_trans As String = "INSERT INTO `tb_b_expense_trans`(id_b_expense,date_trans,-`value`,is_actual,id_report,report_mark_type)
                '                                 SELECT id_b_expense,NOW(),`value`,'2' AS is_actual,id_purc_req AS id_report,'137' AS report_mark_type
                '                                 FROM tb_purc_req_det prd
                '                                 WHERE prd.`id_purc_req`='" & id_report & "'"
                'execute_non_query(query_trans, True, "", "", "", "")
            End If

            'update status
            query = String.Format("UPDATE tb_purc_req SET id_report_status='{0}' WHERE id_purc_req ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "138" Then
            'Expense BUDGET revision
            'auto completed
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                'budget yearly & monthly yg sudqah ada
                Dim qupd_yearly As String = "UPDATE tb_b_expense main
                INNER JOIN (
	                SELECT ry.id_b_expense,ry.value_new
	                FROM tb_b_expense_revision_year ry
	                WHERE ry.id_b_expense_revision=" + id_report + " AND !ISNULL(ry.id_b_expense)
                ) src ON src.id_b_expense = main.id_b_expense
                SET main.value_expense = src.value_new;

                INSERT INTO tb_b_expense_log(id_b_expense, value_old, value_new, log_date, id_user, id_report, report_mark_type)
                SELECT ry.id_b_expense, ry.value_old,ry.value_new, NOW(),'" + id_user + "','" + id_report + "',138
                FROM tb_b_expense_revision_year ry
                WHERE ry.id_b_expense_revision=" + id_report + " AND !ISNULL(ry.id_b_expense);

                UPDATE tb_b_expense_month main
                INNER JOIN (
	                SELECT rd.id_b_expense_month, rd.value_expense_old, rd.value_expense_new
	                FROM tb_b_expense_revision_det rd
	                WHERE rd.id_b_expense_revision=" + id_report + " AND !ISNULL(rd.id_b_expense_month)
                ) src ON src.id_b_expense_month = main.id_b_expense_month
                SET main.value_expense = src.value_expense_new;

                INSERT INTO tb_b_expense_month_log(id_b_expense_month, value_old, value_new, log_date, id_user, id_report, report_mark_type)
                SELECT rd.id_b_expense_month, rd.value_expense_old, rd.value_expense_new, NOW(), '" + id_user + "', '" + id_report + "', 138
	            FROM tb_b_expense_revision_det rd
	            WHERE rd.id_b_expense_revision=" + id_report + " AND !ISNULL(rd.id_b_expense_month); "
                execute_non_query(qupd_yearly, True, "", "", "", "")

                'belum ada yearly
                Dim idb_new As String = "0"
                Dim idy As String = "0"
                Dim qall As String = "SELECT ry.id_b_expense_revision_year,r.year, ry.id_item_coa, ry.value_new, rd.month,rd.value_expense_old, rd.value_expense_new
                FROM tb_b_expense_revision_year ry
                INNER JOIN tb_b_expense_revision_det rd ON rd.id_item_coa = ry.id_item_coa AND rd.id_b_expense_revision=" + id_report + "
                INNER JOIN tb_b_expense_revision r ON r.id_b_expense_revision = ry.id_b_expense_revision
                WHERE ry.id_b_expense_revision=" + id_report + " AND ISNULL(ry.id_b_expense) "
                Dim dall As DataTable = execute_query(qall, -1, True, "", "", "", "")
                For i As Integer = 0 To dall.Rows.Count - 1
                    If idy <> dall.Rows(i)("id_b_expense_revision_year").ToString Then
                        'isi id year baru jika ud beda dengan row saat ini
                        idy = dall.Rows(i)("id_b_expense_revision_year").ToString

                        'insert budget tahunan
                        Dim qyi As String = "INSERT INTO tb_b_expense(year, id_item_coa, value_expense)
                        VALUES('" + dall.Rows(i)("year").ToString + "', '" + dall.Rows(i)("id_item_coa").ToString + "','" + decimalSQL(dall.Rows(i)("value_new").ToString) + "'); SELECT LAST_INSERT_ID(); "
                        idb_new = execute_query(qyi, 0, True, "", "", "", "")

                        'insert log budget tahunan
                        Dim qyl As String = "INSERT INTO tb_b_expense_log(id_b_expense, value_old, value_new, log_date, id_user, id_report, report_mark_type)
                        VALUES('" + idb_new + "', 0, '" + decimalSQL(dall.Rows(i)("value_new").ToString) + "', NOW(),'" + id_user + "', '" + id_report + "', 138); "
                        execute_non_query(qyl, True, "", "", "", "")
                    End If

                    'insert detil bulanan
                    Dim qm As String = "INSERT INTO tb_b_expense_month(id_b_expense, month, value_expense) VALUES
                    ('" + idb_new + "', '" + DateTime.Parse(dall.Rows(i)("month").ToString).ToString("yyyy-MM-dd") + "', '" + decimalSQL(dall.Rows(i)("value_expense_new").ToString) + "'); SELECT LAST_INSERT_ID(); "
                    Dim idb_month_new As String = execute_query(qm, 0, True, "", "", "", "")

                    'insert log detil bulanan
                    Dim qmlog As String = "INSERT INTO tb_b_expense_month_log(id_b_expense_month, value_old, value_new, log_date, id_user, id_report, report_mark_type)
                    VALUES('" + idb_month_new + "', 0 ,'" + decimalSQL(dall.Rows(i)("value_expense_new").ToString) + "', NOW(), '" + id_user + "', '" + id_report + "', 138); "
                    execute_non_query(qmlog, True, "", "", "", "")
                Next

                'belum ada monthly
                'insert detil bulanan
                Dim qm_new As String = "INSERT INTO tb_b_expense_month(id_b_expense, month, value_expense)
                SELECT rd.id_b_expense, rd.month, rd.value_expense_new
                FROM tb_b_expense_revision_det rd
                WHERE rd.id_b_expense_revision=" + id_report + " AND ISNULL(rd.id_b_expense_month) AND !ISNULL(rd.id_b_expense) "
                execute_non_query(qm_new, True, "", "", "", "")
                'insert del bulanan log
                Dim qm_new_log As String = "INSERT INTO tb_b_expense_month_log(id_b_expense_month, value_old, value_new, log_date, id_user, id_report, report_mark_type)
                SELECT em.id_b_expense_month, rd.value_expense_old, rd.value_expense_new, NOW(),'" + id_user + "','" + id_report + "',138
                FROM tb_b_expense_revision_det rd
                INNER JOIN tb_b_expense_month em ON em.month = rd.month AND rd.id_b_expense = em.id_b_expense
                INNER JOIN tb_b_expense e ON e.id_b_expense = em.id_b_expense AND e.id_item_coa = rd.id_item_coa
                WHERE rd.id_b_expense_revision='" + id_report + "'
                AND ISNULL(rd.id_b_expense_month)
                AND !ISNULL(rd.id_b_expense) "
                execute_non_query(qm_new_log, True, "", "", "", "")
            End If

            'update status
            query = String.Format("UPDATE tb_b_expense_revision SET id_report_status='{0}' WHERE id_b_expense_revision ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            FormBudgetExpenseRevisionDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
            FormBudgetExpenseRevisionDet.actionLoad()
            FormBudgetExpenseRevision.viewData()
            FormBudgetExpenseRevision.GVData.FocusedRowHandle = find_row(FormBudgetExpenseRevision.GVData, "id_b_expense_revision", id_report)
        ElseIf report_mark_type = "139" Or report_mark_type = "202" Then
            'Purchase Order
            'auto completed
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            ElseIf id_status_reportx = "5" Then
                'balik budget
                If report_mark_type = "139" Then 'opex
                    query = "INSERT INTO `tb_b_expense_opex_trans`(id_b_expense_opex,id_departement,date_trans,`value`,id_item,id_report,report_mark_type,note) 
                                SELECT prd.id_b_expense_opex,pr.id_departement,NOW(),-(pod.`value` * pod.qty),prd.id_item,pod.`id_purc_order` AS id_report,'202' AS report_mark_type,'Purchase Order'
                                FROM `tb_purc_order_det` pod
                                INNER JOIN `tb_purc_req_det` prd ON prd.`id_purc_req_det`=pod.`id_purc_req_det`
                                INNER JOIN tb_purc_req pr ON pr.id_purc_req=prd.id_purc_req
                                WHERE pod.`id_purc_order`='" & id_report & "'"
                Else 'capex
                    query = "INSERT INTO `tb_b_expense_trans`(id_b_expense,id_departement,date_trans,`value`,id_item,id_report,report_mark_type,note) 
                                SELECT prd.id_b_expense,pr.id_departement,NOW(),-(pod.`value` * pod.qty),prd.id_item,pod.`id_purc_order` AS id_report,'139' AS report_mark_type,'Purchase Order'
                                FROM `tb_purc_order_det` pod
                                INNER JOIN `tb_purc_req_det` prd ON prd.`id_purc_req_det`=pod.`id_purc_req_det`
                                INNER JOIN tb_purc_req pr ON pr.id_purc_req=prd.id_purc_req
                                WHERE pod.`id_purc_order`='" & id_report & "'"
                End If
                query = String.Format("INSERT tb_purc_order SET id_report_status='{0}' WHERE id_purc_order ='{1}'", id_status_reportx, id_report)
            End If

            'update status
            query = String.Format("UPDATE tb_purc_order SET id_report_status='{0}' WHERE id_purc_order ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "143" Or report_mark_type = "144" Or report_mark_type = "145" Or report_mark_type = "194" Or report_mark_type = "210" Then
            Cursor = Cursors.WaitCursor
            'pd revision
            'auto completed
            If id_status_reportx = "2" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                'non aktifkan pd dan po
                Dim query_void As String = "UPDATE tb_prod_demand_design main
                INNER JOIN (
	                SELECT rd.id_prod_demand_design, rd.id_prod_demand_design_rev
	                FROM tb_prod_demand_design_rev rd
	                WHERE rd.id_prod_demand_rev=" + id_report + "
                ) src ON src.id_prod_demand_design = main.id_prod_demand_design
                SET main.is_void=1, main.id_prod_demand_design_rev_void = src.id_prod_demand_design_rev;
                UPDATE tb_prod_order main
                INNER JOIN (
	                SELECT po.id_prod_order, r.note
	                FROM tb_prod_demand_design_rev rd
	                INNER JOIN tb_prod_demand_rev r ON r.id_prod_demand_rev = rd.id_prod_demand_rev
	                INNER JOIN tb_prod_order po ON po.id_prod_demand_design = rd.id_prod_demand_design AND po.id_report_status!=5
	                WHERE rd.id_prod_demand_rev=" + id_report + " AND rd.is_cancel_po=1
                ) src ON src.id_prod_order = main.id_prod_order
                SET main.id_report_status=5,main.is_void=1, main.void_reason = src.note;
                UPDATE tb_report_mark main
                INNER JOIN (
	                SELECT po.id_prod_order, po.prod_order_number, r.note
	                FROM tb_prod_demand_design_rev rd
	                INNER JOIN tb_prod_demand_rev r ON r.id_prod_demand_rev = rd.id_prod_demand_rev
	                INNER JOIN tb_prod_order po ON po.id_prod_demand_design = rd.id_prod_demand_design
	                WHERE rd.id_prod_demand_rev=" + id_report + " AND rd.is_cancel_po=1
                ) src ON src.id_prod_order = main.id_report AND main.report_mark_type=22
                SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL; 
                UPDATE tb_m_design main 
                INNER JOIN (
	                SELECT rd.id_design 
	                FROM tb_prod_demand_rev r
	                INNER JOIN tb_prod_demand_design_rev rd ON rd.id_prod_demand_rev = r.id_prod_demand_rev
	                WHERE r.id_prod_demand_rev=" + id_report + " AND rd.id_pd_status_rev=2
                ) src ON src.id_design = main.id_design
                SET main.id_lookup_status_order=2, main.id_active=2; "
                execute_non_query(query_void, True, "", "", "", "")


                Dim qpr As String = "SELECT pdd.`id_prod_demand_design_rev`,pdd.`id_prod_demand_rev`,pdd.`id_prod_demand_design`, pdd_org.`id_delivery`, pdd.`id_design`, pdd.`id_currency`, pdd.`prod_demand_design_propose_price`,
                pdd.`additional_price`, pdd.`prod_demand_design_estimate_price`, pdd.`prod_demand_design_total_cost`, pdd.`additional_cost`, pdd.`royalty_design`, pdd.`royalty_special`, pdd.`inflation`,
                pdd.`rate_current`, pdd.`rate_management`, pdd.`msrp`, pdd.`msrp_rp`, pdd.`date_available_start`, pdd.`id_pd_status_rev`, pdd.`is_cancel_po`, pdd.`cancel_po_note`,
                pd.`id_prod_demand_rev`, pd.`id_prod_demand`, pd.`rev_count`, pd.`id_report_status`,
                pd.`created_date`, pd.`note`, pd.`is_confirm`, pd.`report_mark_type`
                FROM tb_prod_demand_design_rev pdd
                INNER JOIN tb_prod_demand_design pdd_org ON pdd_org.id_prod_demand_design = pdd.id_prod_demand_design
                INNER JOIN tb_prod_demand_rev pd ON pd.id_prod_demand_rev = pdd.id_prod_demand_rev
                WHERE pdd.id_prod_demand_rev=" + id_report + " AND pdd.id_pd_status_rev=1 "
                Dim dpr As DataTable = execute_query(qpr, -1, True, "", "", "", "")
                For i As Integer = 0 To dpr.Rows.Count - 1
                    'insert new pdd
                    Dim qins As String = "INSERT INTO tb_prod_demand_design (
	                `id_prod_demand`,
	                `id_delivery` ,
	                `id_design` ,
	                `id_currency` ,
	                `prod_demand_design_propose_price` ,
	                `prod_demand_design_estimate_price` ,
	                `prod_demand_design_total_cost` ,
	                `royalty_design` ,
	                `royalty_special`,
	                `inflation` ,
	                `rate_current`,
                    `rate_management`,
	                `msrp` ,
	                `msrp_rp` ,
	                `date_available_start`,
	                `additional_price`,
	                `additional_cost` ,
	                `id_prod_demand_design_rev` ,
	                `id_prod_demand_design_old`
                    ) VALUES (
                    '" + dpr.Rows(i)("id_prod_demand").ToString + "',
                    '" + dpr.Rows(i)("id_delivery").ToString + "',
                    '" + dpr.Rows(i)("id_design").ToString + "',
                    '" + dpr.Rows(i)("id_currency").ToString + "',
                    '" + decimalSQL(dpr.Rows(i)("prod_demand_design_propose_price").ToString) + "',
                    '" + decimalSQL(dpr.Rows(i)("prod_demand_design_estimate_price").ToString) + "',
                    '" + decimalSQL(dpr.Rows(i)("prod_demand_design_total_cost").ToString) + "',
                    '" + decimalSQL(dpr.Rows(i)("royalty_design").ToString) + "',
                    '" + decimalSQL(dpr.Rows(i)("royalty_special").ToString) + "',
                    '" + decimalSQL(dpr.Rows(i)("inflation").ToString) + "',
                    '" + decimalSQL(dpr.Rows(i)("rate_current").ToString) + "',
                    '" + decimalSQL(dpr.Rows(i)("rate_management").ToString) + "',
                    '" + decimalSQL(dpr.Rows(i)("msrp").ToString) + "',
                    '" + decimalSQL(dpr.Rows(i)("msrp_rp").ToString) + "',
                    '" + DateTime.Parse(dpr.Rows(i)("date_available_start").ToString).ToString("yyyy-MM-dd") + "',
                    '" + decimalSQL(dpr.Rows(i)("additional_price").ToString) + "',
                    '" + decimalSQL(dpr.Rows(i)("additional_cost").ToString) + "',
                    '" + dpr.Rows(i)("id_prod_demand_design_rev").ToString + "',
                    '" + dpr.Rows(i)("id_prod_demand_design").ToString + "'
                    ); SELECT LAST_INSERT_ID();"
                    Dim id_prod_demand_design As String = execute_query(qins, 0, True, "", "", "", "")
                    If dpr.Rows(i)("is_cancel_po").ToString = "2" Then
                        'select PO
                        'Dim id_po As String = execute_query("SELECT id_prod_order FROM tb_prod_order WHERE id_report_status!=5 AND id_prod_demand_design=" + dpr.Rows(i)("id_prod_demand_design").ToString + "", 0, True, "", "", "", "")

                        'change reference pdd
                        Dim qpo As String = "UPDATE tb_prod_order SET id_prod_demand_design=" + id_prod_demand_design + " 
                        WHERE id_prod_demand_design=" + dpr.Rows(i)("id_prod_demand_design").ToString + " AND id_report_status!=5 "
                        execute_non_query(qpo, True, "", "", "", "")
                    End If

                    'insert new pdp
                    Dim qprev As String = "SELECT * FROM tb_prod_demand_product_rev pdp 
                    WHERE pdp.id_prod_demand_design_rev=" + dpr.Rows(i)("id_prod_demand_design_rev").ToString + "; "
                    Dim dprev As DataTable = execute_query(qprev, -1, True, "", "", "", "")
                    For p As Integer = 0 To dprev.Rows.Count - 1
                        Dim id_bom As String = dprev.Rows(p)("id_bom").ToString
                        If id_bom = "" Then
                            id_bom = "NULL "
                        End If
                        Dim qins_pdp As String = "INSERT INTO tb_prod_demand_product (
	                    `id_prod_demand_design`,
	                    `id_product`,
	                    `id_bom`,
	                    `prod_demand_product_qty`
                        ) VALUES(
                        " + id_prod_demand_design + " ,
                        " + dprev.Rows(p)("id_product").ToString + " ,
                        " + id_bom + " ,
                        " + decimalSQL(dprev.Rows(p)("prod_demand_product_qty").ToString) + " 
                        ); SELECT LAST_INSERT_ID(); "
                        Dim id_prod_demand_product As String = execute_query(qins_pdp, 0, True, "", "", "", "")
                        If dpr.Rows(i)("is_cancel_po").ToString = "2" Then
                            Dim qpdp_cr As String = "UPDATE tb_prod_order_det main 
                            INNER JOIN (
	                            SELECT pod.id_prod_order_det 
	                            FROM tb_prod_order_det pod
	                            INNER JOIN tb_prod_order po ON po.id_prod_order = pod.id_prod_order
	                            INNER JOIN tb_prod_demand_product pdp ON pdp.id_prod_demand_product = pod.id_prod_demand_product
	                            WHERE po.id_prod_demand_design=" + id_prod_demand_design + " AND po.id_report_status!=5 AND pdp.id_product=" + dprev.Rows(p)("id_product").ToString + "
                            ) src ON src.id_prod_order_det = main.id_prod_order_det
                            SET main.id_prod_demand_product=" + id_prod_demand_product + " "
                            execute_non_query(qpdp_cr, True, "", "", "", "")
                        End If

                        'insert new pdp alloc
                        Dim qins_alloc As String = "INSERT INTO tb_prod_demand_alloc (
                        `id_prod_demand_product`,
                        `id_pd_alloc`,
                        `prod_demand_alloc_qty`
                        )
                        SELECT '" + id_prod_demand_product + "', a.id_pd_alloc, a.prod_demand_alloc_qty
                        FROM tb_prod_demand_alloc_rev a
                        WHERE a.id_prod_demand_product_rev=" + dprev.Rows(p)("id_prod_demand_product_rev").ToString + "; "
                        execute_non_query(qins_alloc, True, "", "", "", "")
                    Next

                Next

                'notif email
                Try
                    Dim mail As ClassSendEmail = New ClassSendEmail()
                    mail.report_mark_type = report_mark_type
                    mail.send_email_notif(report_mark_type, id_report)
                Catch ex As Exception
                    execute_non_query("INSERT INTO tb_error_mail(date, description) VALUES(NOW(), 'PD REVISE;" + id_report + ";" + addSlashes(ex.ToString) + "'); ", True, "", "", "", "")
                End Try
            End If

            'update status
            query = String.Format("UPDATE tb_prod_demand_rev SET id_report_status='{0}' WHERE id_prod_demand_rev ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            FormProdDemandRevDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
            FormProdDemandRevDet.actionLoad()
            FormProdDemandRev.viewData()
            FormProdDemandRev.GVData.FocusedRowHandle = find_row(FormProdDemandRev.GVData, "id_prod_demand_rev", id_report)
            Cursor = Cursors.Default
        ElseIf report_mark_type = "142" Then
            'Cancel Report
            'auto on process
            If id_status_reportx = "6" Then
                'complete
                Dim query_cancel As String = "SELECT rmcr.id_report,rmc.report_mark_type
                                                FROM tb_report_mark_cancel_report rmcr
                                                INNER JOIN tb_report_mark_cancel rmc ON rmc.id_report_mark_cancel=rmcr.id_report_mark_cancel
                                                WHERE rmc.id_report_mark_cancel='" & id_report & "'"
                Dim data_cancel As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                For j As Integer = 0 To data_cancel.Rows.Count - 1
                    Dim xf As New FormReportMark
                    xf.id_report = data_cancel.Rows(j)("id_report").ToString
                    xf.report_mark_type = data_cancel.Rows(j)("report_mark_type").ToString
                    xf.change_status("5")
                Next
                query = String.Format("UPDATE tb_report_mark_cancel SET user_complete='{0}',complete_datetime=NOW() WHERE id_report_mark_cancel ='{1}'", id_user, id_report)
                execute_non_query(query, True, "", "", "", "")
            Else
                Dim query_check As String = "SELECT * FROM tb_report_mark WHERE report_mark_type='142' AND id_report='" & id_report & "' AND id_report_status>" & id_status_reportx
                Dim data_check As DataTable = execute_query(query_check, -1, True, "", "", "", "")
                If data_check.Rows.Count = 0 Then
                    'auto on process
                    id_status_reportx = 4
                End If
            End If
            'update status
            query = String.Format("UPDATE tb_report_mark_cancel SET id_report_status='{0}' WHERE id_report_mark_cancel ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "147" Then
            'auto completed
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            'completed
            If id_status_reportx = "6" Then
                Dim qr As String = "SELECT IFNULL(rv.id_b_revenue,0) AS  `id_b_revenue`,r.`year`,
                rd.id_b_revenue_revision_det, rd.id_b_revenue_revision, rd.id_store, rd.`month`, rd.value_expense_old, rd.value_expense_new
                FROM tb_b_revenue_revision_det rd
                INNER JOIN tb_b_revenue_revision r ON r.id_b_revenue_revision = rd.id_b_revenue_revision
                LEFT JOIN tb_b_revenue rv ON rv.`year`=r.`year` AND rv.`month` = rd.`month` AND rv.id_store = rd.id_store AND rv.is_active=1
                WHERE r.id_b_revenue_revision=" + id_report + " "
                Dim dr As DataTable = execute_query(qr, -1, True, "", "", "", "")
                For i As Integer = 0 To dr.Rows.Count - 1
                    Dim id_b_revenue As String = dr.Rows(i)("id_b_revenue").ToString
                    Dim year As String = dr.Rows(i)("year").ToString
                    Dim month As String = dr.Rows(i)("month").ToString
                    Dim id_store As String = dr.Rows(i)("id_store").ToString
                    Dim b_revenue As String = decimalSQL(dr.Rows(i)("value_expense_new").ToString)
                    Dim value_old As String = decimalSQL(dr.Rows(i)("value_expense_old").ToString)
                    Dim value_new As String = decimalSQL(dr.Rows(i)("value_expense_new").ToString)
                    If id_b_revenue = "0" Then
                        'insert budget
                        Dim qi As String = "INSERT INTO tb_b_revenue(year, month, id_store, b_revenue) VALUES
                       ('" + year + "', '" + month + "', '" + id_store + "', '" + b_revenue + "'); SELECT LAST_INSERT_ID(); "
                        id_b_revenue = execute_query(qi, 0, True, "", "", "", "")

                        'insert log
                        Dim ql As String = "INSERT INTO tb_b_revenue_log(id_b_revenue, value_old, value_new, log_date, id_user, id_report, report_mark_type) VALUES
                        ('" + id_b_revenue + "', '" + value_old + "', '" + value_new + "', NOW(), '" + id_user + "', '" + id_report + "', '147'); "
                        execute_non_query(ql, True, "", "", "", "")
                    Else
                        'edit budget
                        Dim qu As String = "UPDATE tb_b_revenue SET b_revenue='" + b_revenue + "' WHERE id_b_revenue='" + id_b_revenue + "' "
                        execute_non_query(qu, True, "", "", "", "")

                        'edit log budget
                        Dim ql As String = "INSERT INTO tb_b_revenue_log(id_b_revenue, value_old, value_new, log_date, id_user, id_report, report_mark_type) VALUES
                        ('" + id_b_revenue + "', '" + value_old + "', '" + value_new + "', NOW(), '" + id_user + "', '" + id_report + "', '147'); "
                        execute_non_query(ql, True, "", "", "", "")
                    End If
                Next
            End If

            'update status
            query = String.Format("UPDATE tb_b_revenue_revision SET id_report_status='{0}' WHERE id_b_revenue_revision ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            FormBudgetRevPropose.viewRevision()
            FormBudgetRevPropose.GVRevision.FocusedRowHandle = find_row(FormBudgetRevPropose.GVRevision, "id_b_revenue_revision", id_report)
        ElseIf report_mark_type = "148" Then
            'PURCHASE RECEIVE
            'auto completed
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            query = String.Format("UPDATE tb_purc_rec SET id_report_status='{0}' WHERE id_purc_rec ='{1}';", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'update
            Dim query_complete As String = ""
            query_complete = "CALL update_stt_purc_order(" + FormPurcReceiveDet.id_purc_order + ");" 'jika sudah klop
            execute_non_query(query_complete, True, "", "", "", "")

            'completed
            Dim qjd As String = ""
            Dim id_acc_trans As String = ""

            If id_status_reportx = "6" Then
                'stock only OPEX and Not delivered yet
                Dim id_purc_store As String = get_purc_setup_field("id_purc_store")

                Dim qs As String = "INSERT INTO tb_storage_item (
                    `id_departement`,
	                `id_storage_category`,
	                `id_item`,
	                `value`,
	                `report_mark_type`,
	                `id_report`,
	                `storage_item_qty`,
	                `storage_item_datetime`,
	                `storage_item_notes`,
	                `id_stock_status`
                )
                SELECT IF(rq.is_store_purchase=1,'" & id_purc_store & "',rq.id_departement) AS id_departement, 1, rd.id_item, (pod.`value`/i.stock_convertion) AS value, 148, " + id_report + ", rd.qty_stock, NOW(),'', 1
                FROM tb_purc_rec_det rd
                INNER JOIN tb_purc_rec r ON r.id_purc_rec=rd.id_purc_rec
                INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
                INNER JOIN tb_purc_req_det rqd ON rqd.id_purc_req_det = pod.id_purc_req_det
                INNER JOIN tb_purc_req rq ON rq.id_purc_req = rqd.id_purc_req
                INNER JOIN tb_item i ON i.id_item = rd.id_item
                INNER JOIN tb_item_cat cat ON cat.id_item_cat = i.id_item_cat
                WHERE rd.id_purc_rec=" + id_report + " AND cat.id_expense_type=1 AND i.id_item_type='1' AND r.is_delivered='2'; "
                execute_non_query(qs, True, "", "", "", "")

                'budget move to actual
                Dim qb As String = "-- opex
                INSERT INTO tb_b_expense_opex_trans(id_b_expense_opex,is_po,id_departement,date_trans,`value`,id_item,id_report,report_mark_type,note)
                SELECT rqd.id_b_expense_opex,1,rq.id_departement,NOW(),-(pod.`value` * rd.qty),rd.id_item, pod.id_purc_order, 139 AS rmt, 'Adj Budget Booking PO'
                FROM tb_purc_rec_det rd
                INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
                INNER JOIN tb_purc_req_det rqd ON rqd.id_purc_req_det = pod.id_purc_req_det
                INNER JOIN tb_purc_req rq ON rq.id_purc_req = rqd.id_purc_req
                INNER JOIN tb_item i ON i.id_item = rd.id_item
                INNER JOIN tb_item_cat cat ON cat.id_item_cat = i.id_item_cat
                WHERE rd.id_purc_rec=" + id_report + " AND cat.id_expense_type=1 AND i.id_item_type='1'
                UNION ALL
                SELECT rqd.id_b_expense_opex,2,rq.id_departement,NOW(),(pod.`value` * rd.qty),rd.id_item, " + id_report + ", 148 AS rmt, 'Receiving PO'
                FROM tb_purc_rec_det rd
                INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
                INNER JOIN tb_purc_req_det rqd ON rqd.id_purc_req_det = pod.id_purc_req_det
                INNER JOIN tb_purc_req rq ON rq.id_purc_req = rqd.id_purc_req
                INNER JOIN tb_item i ON i.id_item = rd.id_item
                INNER JOIN tb_item_cat cat ON cat.id_item_cat = i.id_item_cat
                WHERE rd.id_purc_rec=" + id_report + " AND cat.id_expense_type=1 AND i.id_item_type='1';
                -- capex
                INSERT INTO tb_b_expense_trans(id_b_expense,is_po,id_departement,date_trans,`value`,id_item,id_report,report_mark_type,note)
                SELECT rqd.id_b_expense,1,rq.id_departement,NOW(),-(pod.`value` * rd.qty),rd.id_item, pod.id_purc_order, 202, 'Adj Budget Booking PO'
                FROM tb_purc_rec_det rd
                INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
                INNER JOIN tb_purc_req_det rqd ON rqd.id_purc_req_det = pod.id_purc_req_det
                INNER JOIN tb_purc_req rq ON rq.id_purc_req = rqd.id_purc_req
                INNER JOIN tb_item i ON i.id_item = rd.id_item
                INNER JOIN tb_item_cat cat ON cat.id_item_cat = i.id_item_cat
                WHERE rd.id_purc_rec=" + id_report + " AND cat.id_expense_type=2 AND i.id_item_type='1'
                UNION ALL
                SELECT rqd.id_b_expense,2,rq.id_departement,NOW(),(pod.`value` * rd.qty),rd.id_item, " + id_report + ", 148, 'Receiving'
                FROM tb_purc_rec_det rd
                INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
                INNER JOIN tb_purc_req_det rqd ON rqd.id_purc_req_det = pod.id_purc_req_det
                INNER JOIN tb_purc_req rq ON rq.id_purc_req = rqd.id_purc_req
                INNER JOIN tb_item i ON i.id_item = rd.id_item
                INNER JOIN tb_item_cat cat ON cat.id_item_cat = i.id_item_cat
                WHERE rd.id_purc_rec=" + id_report + " AND cat.id_expense_type=2 AND i.id_item_type='1';"
                execute_non_query(qb, True, "", "", "", "")

                ' asset
                Dim qa As String = "SELECT rd.id_item, rd.id_purc_rec_det, rd.qty, coa.id_coa_out, rq.id_departement, i.item_desc, NOW(), (pod.`value` - pod.discount) AS `cost`, 2
                FROM tb_purc_rec_det rd
                INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
                INNER JOIN tb_purc_req_det rqd ON rqd.id_purc_req_det = pod.id_purc_req_det
                INNER JOIN tb_purc_req rq ON rq.id_purc_req = rqd.id_purc_req
                INNER JOIN tb_item i ON i.id_item = rd.id_item
                INNER JOIN tb_item_cat cat ON cat.id_item_cat = i.id_item_cat
                INNER JOIN tb_item_cat_main main ON main.id_item_cat_main = cat.id_item_cat_main
                INNER JOIN tb_lookup_expense_type et ON et.id_expense_type = cat.id_expense_type
                INNER JOIN tb_item_coa coa ON coa.id_item_cat = cat.id_item_cat AND coa.id_departement=rq.id_departement
                WHERE rd.id_purc_rec=" + id_report + " AND et.id_expense_type=2 AND main.is_fixed_asset='1' "
                Dim da As DataTable = execute_query(qa, -1, True, "", "", "", "")
                If da.Rows.Count > 0 Then
                    Dim ix As Integer = 0
                    Dim qa_ins As String = "INSERT INTO tb_purc_rec_asset (`id_item`,`id_purc_rec_det`,`id_departement`, `id_acc_fa`,`asset_name`,`acq_date`,`acq_cost`) VALUES "
                    For a As Integer = 0 To da.Rows.Count - 1
                        For j As Integer = 1 To da.Rows(a)("qty")
                            If ix > 0 Then
                                qa_ins += ", "
                            End If

                            qa_ins += "('" + da.Rows(a)("id_item").ToString + "', '" + da.Rows(a)("id_purc_rec_det").ToString + "', '" + da.Rows(a)("id_departement").ToString + "', '" + da.Rows(a)("id_coa_out").ToString + "', '" + da.Rows(a)("item_desc").ToString + "', NOW(), '" + decimalSQL(da.Rows(a)("cost").ToString) + "') "
                            ix += 1
                        Next
                    Next

                    'ins
                    If ix > 0 Then
                        execute_non_query(qa_ins, True, "", "", "", "")
                    End If
                End If


                ' select user prepared
                Dim qu As String = "SELECT rm.id_user, rm.report_number FROM tb_report_mark rm WHERE rm.report_mark_type=" + report_mark_type + " AND rm.id_report='" + id_report + "' AND rm.id_report_status=1 "
                Dim du As DataTable = execute_query(qu, -1, True, "", "", "", "")
                Dim id_user_prepared As String = du.Rows(0)("id_user").ToString
                Dim report_number As String = du.Rows(0)("report_number").ToString

                'main journal
                Dim qjm As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, acc_trans_note, id_report_status)
                VALUES ('','" + report_number + "','24','" + id_user_prepared + "', NOW(), 'Auto Posting', '6'); SELECT LAST_INSERT_ID(); "
                id_acc_trans = execute_query(qjm, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id_acc_trans + ",36)", True, "", "", "", "")

                'det journal
                qjd = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, id_vendor, id_comp, qty, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number, report_mark_type_ref, id_report_ref, report_number_ref, id_coa_tag)
SELECT id_acc_trans,id_acc,id_vendor,id_comp,qty,IF(SUM(debit)>SUM(credit),SUM(debit)-SUM(credit),0) AS debit,IF(SUM(credit)>SUM(debit),SUM(credit)-SUM(debit),0) AS credit,note,report_mark_type,id_report,report_number,rmt_reff,id_report_reff,report_number_reff,id_coa_tag
FROM
(
                /* total biaya jasa atau non inventory tanpa diskon */
                SELECT " + id_acc_trans + " AS id_acc_trans,o.id_coa_out AS `id_acc`,cont.id_comp AS id_vendor, IF(reqd.ship_to=0,1,reqd.ship_to) AS id_comp,  SUM(rd.qty) AS `qty`,
                SUM(rd.qty * pod.`value`) AS `debit`,
                0 AS `credit`,i.item_desc AS `note`,148 AS report_mark_type,rd.id_purc_rec AS id_report, r.purc_rec_number AS report_number, IF(po.id_expense_type=1,139,202) AS rmt_reff,  po.id_purc_order AS id_report_reff, po.purc_order_number AS report_number_reff,po.id_coa_tag
                FROM tb_purc_rec_det rd
                INNER JOIN tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
                INNER JOIN tb_purc_order po ON po.id_purc_order = r.id_purc_order
                INNER JOIN tb_m_comp_contact cont ON cont.id_comp_contact = po.id_comp_contact
                INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
                INNER JOIN (
	                SELECT pod.id_purc_order,SUM(pod.qty) AS `qty`, SUM(pod.qty*(pod.`value`-pod.discount)) AS `value`, po.disc_value, po.purc_order_number, po.id_expense_type
	                FROM tb_purc_order_det pod
	                INNER JOIN tb_purc_order po ON po.id_purc_order = pod.id_purc_order
	                WHERE pod.id_purc_order=" + FormPurcReceiveDet.id_purc_order + "
	                GROUP BY pod.id_purc_order
                 ) poall ON poall.id_purc_order = r.id_purc_order
                INNER JOIN tb_item i ON i.id_item = rd.id_item
                INNER JOIN tb_item_cat cat ON cat.id_item_cat = i.id_item_cat
                INNER JOIN tb_purc_req_det reqd ON pod.id_purc_req_det=reqd.id_purc_req_det
                INNER JOIN tb_purc_req req ON req.id_purc_req=reqd.id_purc_req
                INNER JOIN tb_m_departement dep ON dep.id_departement=req.id_departement
                INNER JOIN tb_item_coa o ON o.id_item_cat=i.id_item_cat AND o.id_departement=req.id_departement
                WHERE rd.id_purc_rec=" + id_report + " AND cat.id_expense_type=1 AND (i.id_item_type='2' OR r.is_delivered='1')
                GROUP BY rd.id_purc_rec_det,dep.id_main_comp,reqd.ship_to
                HAVING debit>0 OR credit>0
                UNION ALL
                /*total value item inventory tanpa diskon*/
                SELECT " + id_acc_trans + " AS id_acc_trans,IF(po.id_coa_tag=1,o.acc_coa_receive,o.acc_coa_receive_cabang) AS `id_acc`,cont.id_comp AS id_vendor, dep.id_main_comp,  SUM(rd.qty) AS `qty`,
                SUM(rd.qty * (pod.`value`)) AS `debit`,
                0 AS `credit`,i.item_desc AS `note`,148,rd.id_purc_rec, r.purc_rec_number, IF(po.id_expense_type=1,139,202) AS rmt_reff,  po.id_purc_order, po.purc_order_number,po.id_coa_tag
                FROM tb_purc_rec_det rd
                INNER JOIN tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
                INNER JOIN tb_purc_order po ON po.id_purc_order = r.id_purc_order
                INNER JOIN tb_m_comp_contact cont ON cont.id_comp_contact = po.id_comp_contact
                INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
                INNER JOIN tb_purc_req_det reqd ON pod.id_purc_req_det=reqd.id_purc_req_det
                INNER JOIN tb_purc_req req ON req.id_purc_req=reqd.id_purc_req
                INNER JOIN tb_m_departement dep ON dep.id_departement=req.id_departement
                INNER JOIN (
 	                SELECT pod.id_purc_order,SUM(pod.qty) AS `qty`, SUM(pod.qty*(pod.`value`-pod.discount)) AS `value`, po.disc_value, po.purc_order_number, po.id_expense_type
	                FROM tb_purc_order_det pod
	                INNER JOIN tb_purc_order po ON po.id_purc_order = pod.id_purc_order
	                WHERE pod.id_purc_order=" + FormPurcReceiveDet.id_purc_order + "
	                GROUP BY pod.id_purc_order
                 ) poall ON poall.id_purc_order = r.id_purc_order
                INNER JOIN tb_item i ON i.id_item = rd.id_item
                INNER JOIN tb_item_cat cat ON cat.id_item_cat = i.id_item_cat
                JOIN tb_opt_purchasing o
                WHERE rd.id_purc_rec=" + id_report + " AND cat.id_expense_type=1 AND i.id_item_type='1' AND r.is_delivered='2'
                GROUP BY rd.id_purc_rec_det,dep.id_main_comp
                HAVING debit>0 OR credit>0
                UNION ALL
                /*total value item asset tanpa diskon*/
                SELECT " + id_acc_trans + " AS id_acc_trans,coa.id_coa_out AS `id_acc`,cont.id_comp AS id_vendor, dep.id_main_comp,  
                SUM(rd.qty) AS `qty`, SUM(rd.qty * (pod.`value`)) AS `debit`,
                0 AS `credit`,i.item_desc AS `note`,148,rd.id_purc_rec, r.purc_rec_number, IF(po.id_expense_type=1,139,202) AS rmt_reff,  po.id_purc_order, po.purc_order_number,po.id_coa_tag
                FROM tb_purc_rec_det rd
                INNER JOIN tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
                INNER JOIN tb_purc_order po ON po.id_purc_order = r.id_purc_order
                INNER JOIN tb_m_comp_contact cont ON cont.id_comp_contact = po.id_comp_contact
                INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
                INNER JOIN (
	                SELECT pod.id_purc_order,SUM(pod.qty) AS `qty`, SUM(pod.qty*(pod.`value`-pod.discount)) AS `value`, po.disc_value, po.purc_order_number, po.id_expense_type
	                FROM tb_purc_order_det pod
	                INNER JOIN tb_purc_order po ON po.id_purc_order = pod.id_purc_order
	                WHERE pod.id_purc_order=" + FormPurcReceiveDet.id_purc_order + "
	                GROUP BY pod.id_purc_order
                ) poall ON poall.id_purc_order = r.id_purc_order
                INNER JOIN tb_purc_req_det rqd ON rqd.id_purc_req_det = pod.id_purc_req_det
                INNER JOIN tb_purc_req rq ON rq.id_purc_req  = rqd.id_purc_req
                INNER JOIN tb_m_departement dep ON dep.id_departement=rq.`id_departement`
                INNER JOIN tb_item i ON i.id_item = rd.id_item
                INNER JOIN tb_item_cat cat ON cat.id_item_cat = i.id_item_cat
                INNER JOIN tb_item_coa coa ON coa.id_item_cat = cat.id_item_cat AND coa.id_departement = rq.id_departement
                WHERE rd.id_purc_rec=" + id_report + " AND cat.id_expense_type=2
                GROUP BY rd.id_purc_rec_det, rq.id_departement,rd.id_item,rqd.item_detail
                UNION ALL
                /*Discount ke pendapatan lain-lain PPN digungung*/
                SELECT " + id_acc_trans + " AS id_acc_trans,IF(po.id_coa_tag=1,o.id_acc_pend_lain_ppn_gung,o.id_acc_pendapatan_lain_cabang) AS `id_acc`,cont.id_comp AS id_vendor, dep.id_main_comp,  
                SUM(rd.qty) AS `qty`,
                0 AS `debit`,
                ((100/110) * SUM(rd.qty * pod.discount)+((SUM(rd.qty * (pod.`value`-pod.discount))/(poall.`value`))*poall.disc_value)) AS `credit`,i.item_desc AS `note`,148,rd.id_purc_rec, r.purc_rec_number, IF(po.id_expense_type=1,139,202) AS rmt_reff,  po.id_purc_order, po.purc_order_number,po.id_coa_tag
                FROM tb_purc_rec_det rd
                INNER JOIN tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
                INNER JOIN tb_purc_order po ON po.id_purc_order = r.id_purc_order
                INNER JOIN tb_m_comp_contact cont ON cont.id_comp_contact = po.id_comp_contact
                INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
                INNER JOIN (
	                SELECT pod.id_purc_order,SUM(pod.qty) AS `qty`, SUM(pod.qty*(pod.`value`-pod.discount)) AS `value`, po.disc_value, po.purc_order_number, po.id_expense_type
	                FROM tb_purc_order_det pod
	                INNER JOIN tb_purc_order po ON po.id_purc_order = pod.id_purc_order
	                WHERE pod.id_purc_order=" + FormPurcReceiveDet.id_purc_order + "
	                GROUP BY pod.id_purc_order
                ) poall ON poall.id_purc_order = r.id_purc_order
                INNER JOIN tb_purc_req_det rqd ON rqd.id_purc_req_det = pod.id_purc_req_det
                INNER JOIN tb_purc_req rq ON rq.id_purc_req  = rqd.id_purc_req
                INNER JOIN tb_m_departement dep ON dep.id_departement=rq.`id_departement`
                INNER JOIN tb_item i ON i.id_item = rd.id_item
                INNER JOIN tb_item_cat cat ON cat.id_item_cat = i.id_item_cat
                INNER JOIN tb_item_coa coa ON coa.id_item_cat = cat.id_item_cat AND coa.id_departement = rq.id_departement
                JOIN tb_opt_accounting o
                WHERE rd.id_purc_rec=" + id_report + "
                GROUP BY rd.id_purc_rec_det, rq.id_departement
                HAVING debit!=0 OR credit!=0
                /*PPN Discount ke pendapatan lain-lain PPN digungung*/
                SELECT " + id_acc_trans + " AS id_acc_trans,IF(po.id_coa_tag=1,o.id_acc_ppn_lain,o.id_acc_ppn_lain) AS `id_acc`,cont.id_comp AS id_vendor, dep.id_main_comp,  
                SUM(rd.qty) AS `qty`,
                0 AS `debit`,
                SUM(rd.qty * pod.discount)+((SUM(rd.qty * (pod.`value`-pod.discount))/(poall.`value`))*poall.disc_value) - ((100/110) * SUM(rd.qty * pod.discount)+((SUM(rd.qty * (pod.`value`-pod.discount))/(poall.`value`))*poall.disc_value)) AS `credit`,i.item_desc AS `note`,148,rd.id_purc_rec, r.purc_rec_number, IF(po.id_expense_type=1,139,202) AS rmt_reff,  po.id_purc_order, po.purc_order_number,po.id_coa_tag
                FROM tb_purc_rec_det rd
                INNER JOIN tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
                INNER JOIN tb_purc_order po ON po.id_purc_order = r.id_purc_order
                INNER JOIN tb_m_comp_contact cont ON cont.id_comp_contact = po.id_comp_contact
                INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
                INNER JOIN (
	                SELECT pod.id_purc_order,SUM(pod.qty) AS `qty`, SUM(pod.qty*(pod.`value`-pod.discount)) AS `value`, po.disc_value, po.purc_order_number, po.id_expense_type
	                FROM tb_purc_order_det pod
	                INNER JOIN tb_purc_order po ON po.id_purc_order = pod.id_purc_order
	                WHERE pod.id_purc_order=" + FormPurcReceiveDet.id_purc_order + "
	                GROUP BY pod.id_purc_order
                ) poall ON poall.id_purc_order = r.id_purc_order
                INNER JOIN tb_purc_req_det rqd ON rqd.id_purc_req_det = pod.id_purc_req_det
                INNER JOIN tb_purc_req rq ON rq.id_purc_req  = rqd.id_purc_req
                INNER JOIN tb_m_departement dep ON dep.id_departement=rq.`id_departement`
                INNER JOIN tb_item i ON i.id_item = rd.id_item
                INNER JOIN tb_item_cat cat ON cat.id_item_cat = i.id_item_cat
                INNER JOIN tb_item_coa coa ON coa.id_item_cat = cat.id_item_cat AND coa.id_departement = rq.id_departement
                JOIN tb_opt_accounting o
                WHERE rd.id_purc_rec=" + id_report + "
                GROUP BY rd.id_purc_rec_det, rq.id_departement
                HAVING debit!=0 OR credit!=0
                UNION ALL
                /*total vat in*/
                SELECT " + id_acc_trans + " AS id_acc_trans,IF(po.id_coa_tag=1,o.acc_coa_vat_in,o.acc_coa_vat_in_cabang) AS `id_acc`,cont.id_comp AS id_vendor, dep.id_main_comp,  SUM(rd.qty) AS `qty`,
                (po.vat_percent/100)*(po.dpp_percent/100)*(SUM(rd.qty * (pod.`value`-pod.discount))-((SUM(rd.qty * (pod.`value`-pod.discount))/(poall.`value`))*poall.disc_value)) AS `debit`,
                0 AS `credit`,i.item_desc AS `note`,148,rd.id_purc_rec, r.purc_rec_number, IF(po.id_expense_type=1,139,202) AS rmt_reff,  po.id_purc_order, po.purc_order_number,po.id_coa_tag
                FROM tb_purc_rec_det rd
                INNER JOIN tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
                INNER JOIN tb_purc_order po ON po.id_purc_order = r.id_purc_order
                INNER JOIN tb_m_comp_contact cont ON cont.id_comp_contact = po.id_comp_contact
                INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
                INNER JOIN tb_purc_req_det reqd ON pod.id_purc_req_det=reqd.id_purc_req_det
                INNER JOIN tb_item i ON i.id_item = rd.id_item
                INNER JOIN tb_purc_req req ON req.id_purc_req=reqd.id_purc_req
                INNER JOIN tb_m_departement dep ON dep.id_departement=req.id_departement
                INNER JOIN (
 	                SELECT pod.id_purc_order,SUM(pod.qty) AS `qty`, SUM(pod.qty*(pod.`value`-pod.discount)) AS `value`, po.disc_value, po.purc_order_number, po.id_expense_type
	                FROM tb_purc_order_det pod
	                INNER JOIN tb_purc_order po ON po.id_purc_order = pod.id_purc_order
	                WHERE pod.id_purc_order=" + FormPurcReceiveDet.id_purc_order + "
	                GROUP BY pod.id_purc_order
                ) poall ON poall.id_purc_order = r.id_purc_order
                JOIN tb_opt_purchasing o
                WHERE rd.id_purc_rec=" + id_report + " AND po.vat_percent>0
                GROUP BY rd.id_purc_rec,dep.id_main_comp
                UNION ALL
                /* Total value item inventory + total value item asset + vat in ke AP */
                SELECT " + id_acc_trans + " AS id_acc_trans, IF(po.id_coa_tag=1,comp.id_acc_ap,comp.id_acc_cabang_ap) AS `id_acc`,cont.id_comp AS id_vendor, dep.id_main_comp, SUM(rd.qty) AS `qty`, 0 AS `debit`,
                SUM(rd.qty * (pod.`value`-pod.discount))-((SUM(rd.qty * (pod.`value`-pod.discount))/(poall.`value`))*poall.disc_value) + ((po.vat_percent/100)*(po.dpp_percent/100)*(SUM(rd.qty * (pod.`value`-pod.discount))-((SUM(rd.qty * (pod.`value`-pod.discount))/(poall.`value`))*poall.disc_value))) AS `credit`,
                i.item_desc AS `note`, 148, rd.id_purc_rec, r.purc_rec_number, IF(po.id_expense_type=1,139,202) AS rmt_reff,  po.id_purc_order, po.purc_order_number,po.id_coa_tag
                FROM tb_purc_rec_det rd
                INNER JOIN tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
                INNER JOIN tb_purc_order po ON po.id_purc_order = r.id_purc_order
                INNER JOIN tb_m_comp_contact cont ON cont.id_comp_contact = po.id_comp_contact
                INNER JOIN tb_m_comp comp ON comp.id_comp = cont.id_comp
                INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
                INNER JOIN tb_purc_req_det reqd ON pod.id_purc_req_det=reqd.id_purc_req_det
                INNER JOIN tb_item i ON i.id_item = rd.id_item
                INNER JOIN tb_purc_req req ON req.id_purc_req=reqd.id_purc_req
                INNER JOIN tb_m_departement dep ON dep.id_departement=req.id_departement
                INNER JOIN (
 	                SELECT pod.id_purc_order,SUM(pod.qty) AS `qty`, SUM(pod.qty*(pod.`value`-pod.discount)) AS `value`, po.disc_value, po.purc_order_number, po.id_expense_type
	                FROM tb_purc_order_det pod
	                INNER JOIN tb_purc_order po ON po.id_purc_order = pod.id_purc_order
	                WHERE pod.id_purc_order=" + FormPurcReceiveDet.id_purc_order + "
	                GROUP BY pod.id_purc_order
                ) poall ON poall.id_purc_order = r.id_purc_order
                WHERE rd.id_purc_rec=" + id_report + "
                GROUP BY rd.id_purc_rec,dep.id_main_comp
                UNION ALL
                /* Total DP balik */
                SELECT " + id_acc_trans + " AS id_acc_trans, IF(po.id_coa_tag=1,comp.id_acc_dp,comp.id_acc_cabang_dp) AS `id_acc`,cont.id_comp AS id_vendor, 1, 0 AS `qty`,0 AS `debit`
                ,IF(now_rec.rec_val<=IF((SUM(pnd.`value`)-IFNULL(already_rec.rec_val,0))<0,0,(SUM(pnd.`value`)-IFNULL(already_rec.rec_val,0))),now_rec.rec_val,IF((SUM(pnd.`value`)-IFNULL(already_rec.rec_val,0))<0,0,(SUM(pnd.`value`)-IFNULL(already_rec.rec_val,0)))) AS `credit`, 
                'Receiving with DP' AS note, '159', pn.id_pn, pn.number, po.report_mark_type, po.id_purc_order, po.purc_order_number,po.id_coa_tag
                FROM tb_pn_det pnd
                INNER JOIN tb_pn pn ON pn.id_pn=pnd.id_pn AND pn.id_report_status='6' AND pn.id_pay_type='1'
                INNER JOIN tb_purc_order po ON po.id_purc_order=pnd.id_report AND (pnd.report_mark_type='139' OR pnd.report_mark_type='202')
                INNER JOIN tb_m_comp_contact cont ON cont.id_comp_contact = po.id_comp_contact
                INNER JOIN tb_m_comp comp ON comp.id_comp = cont.id_comp
                LEFT JOIN 
                (
	                SELECT rec.id_purc_order ,SUM(recd.`qty`*pod.`value`*(po.dpp_percent/100)*((100+po.`vat_percent`)/100)) AS rec_val
	                FROM tb_purc_rec_det recd
	                INNER JOIN tb_purc_rec rec ON rec.`id_purc_rec`=recd.`id_purc_rec` AND rec.`id_report_status`=6  AND rec.`id_purc_rec`!='" + id_report + "' AND rec.`id_purc_order`='" + FormPurcReceiveDet.id_purc_order + "'
	                INNER JOIN tb_purc_order_det pod ON pod.`id_purc_order_det`=recd.`id_purc_order_det`
	                INNER JOIN tb_purc_order po ON po.`id_purc_order`=rec.`id_purc_order`
	                GROUP BY rec.`id_purc_order`
                )already_rec ON already_rec.id_purc_order=pnd.id_report
                LEFT JOIN 
                (
	                SELECT rec.id_purc_order ,SUM(recd.`qty`*pod.`value`*(po.dpp_percent/100)*((100+po.`vat_percent`)/100)) AS rec_val
	                FROM tb_purc_rec_det recd
	                INNER JOIN tb_purc_rec rec ON rec.`id_purc_rec`=recd.`id_purc_rec` AND rec.`id_purc_rec`='" + id_report + "'
	                INNER JOIN tb_purc_order_det pod ON pod.`id_purc_order_det`=recd.`id_purc_order_det`
	                INNER JOIN tb_purc_order po ON po.`id_purc_order`=rec.`id_purc_order`
	                GROUP BY rec.`id_purc_order`
                )now_rec ON now_rec.id_purc_order=pnd.id_report
                WHERE (pnd.report_mark_type='139' OR pnd.report_mark_type='202') AND pnd.id_report='" + FormPurcReceiveDet.id_purc_order + "' 
                GROUP BY pnd.id_report
                UNION ALL
                /* Hutang karena DP dibalik */
                SELECT " + id_acc_trans + " AS id_acc_trans, IF(po.id_coa_tag=1,comp.id_acc_ap,comp.id_acc_cabang_ap) AS `id_acc`,cont.id_comp AS id_vendor, 1, 0 AS `qty`
                ,IF(now_rec.rec_val<=IF((SUM(pnd.`value`)-IFNULL(already_rec.rec_val,0))<0,0,(SUM(pnd.`value`)-IFNULL(already_rec.rec_val,0))),now_rec.rec_val,IF((SUM(pnd.`value`)-IFNULL(already_rec.rec_val,0))<0,0,(SUM(pnd.`value`)-IFNULL(already_rec.rec_val,0)))) AS `debit`
                ,0 AS `credit`, 
                'Receiving with DP' AS note, '159', pn.id_pn, pn.number, po.report_mark_type, po.id_purc_order, po.purc_order_number,po.id_coa_tag
                FROM tb_pn_det pnd
                INNER JOIN tb_pn pn ON pn.id_pn=pnd.id_pn AND pn.id_report_status='6' AND pn.id_pay_type='1'
                INNER JOIN tb_purc_order po ON po.id_purc_order=pnd.id_report AND (pnd.report_mark_type='139' OR pnd.report_mark_type='202')
                INNER JOIN tb_m_comp_contact cont ON cont.id_comp_contact = po.id_comp_contact
                INNER JOIN tb_m_comp comp ON comp.id_comp = cont.id_comp
                LEFT JOIN 
                (
	                SELECT rec.id_purc_order ,SUM(recd.`qty`*pod.`value`*(po.dpp_percent/100)*((100+po.`vat_percent`)/100)) AS rec_val
	                FROM tb_purc_rec_det recd
	                INNER JOIN tb_purc_rec rec ON rec.`id_purc_rec`=recd.`id_purc_rec` AND rec.`id_report_status`=6  AND rec.`id_purc_rec`!='" + id_report + "' AND rec.`id_purc_order`='" + FormPurcReceiveDet.id_purc_order + "'
	                INNER JOIN tb_purc_order_det pod ON pod.`id_purc_order_det`=recd.`id_purc_order_det`
	                INNER JOIN tb_purc_order po ON po.`id_purc_order`=rec.`id_purc_order`
	                GROUP BY rec.`id_purc_order`
                )already_rec ON already_rec.id_purc_order=pnd.id_report
                LEFT JOIN 
                (
	                SELECT rec.id_purc_order ,SUM(recd.`qty`*pod.`value`*(po.dpp_percent/100)*((100+po.`vat_percent`)/100)) AS rec_val
	                FROM tb_purc_rec_det recd
	                INNER JOIN tb_purc_rec rec ON rec.`id_purc_rec`=recd.`id_purc_rec` AND rec.`id_purc_rec`='" + id_report + "'
	                INNER JOIN tb_purc_order_det pod ON pod.`id_purc_order_det`=recd.`id_purc_order_det`
	                INNER JOIN tb_purc_order po ON po.`id_purc_order`=rec.`id_purc_order`
	                GROUP BY rec.`id_purc_order`
                )now_rec ON now_rec.id_purc_order=pnd.id_report
                WHERE (pnd.report_mark_type='139' OR pnd.report_mark_type='202') AND pnd.id_report='" + FormPurcReceiveDet.id_purc_order + "' 
                GROUP BY pnd.id_report
) ttl
GROUP BY ttl.id_acc
HAVING debit!=credit"
                execute_non_query(qjd, True, "", "", "", "")

                'stock card for listed
                Dim qi As String = ""
                Dim qsi As String = ""

                'stock card
                qsi = "SELECT prd.id_purc_rec,prd.id_purc_rec_det,'148' AS report_mark_type,req.id_departement,reqd.id_item,reqd.item_detail,reqd.remark,SUM(prd.qty) AS qty,reqd.id_item
FROM tb_purc_rec_det prd
INNER JOIN tb_purc_order_det pod ON pod.`id_purc_order_det`=prd.`id_purc_order_det`
INNER JOIN tb_purc_req_det reqd ON reqd.`id_purc_req_det`=pod.`id_purc_req_det`
INNER JOIN tb_purc_req req ON req.`id_purc_req`=reqd.`id_purc_req`
INNER JOIN tb_item it ON it.id_item=reqd.id_item AND reqd.is_dep_stock_card=1
WHERE prd.`id_purc_rec`='" & id_report & "'
GROUP BY prd.id_purc_rec_det,reqd.`id_item`,reqd.item_detail,reqd.remark"
                Dim dtsi As DataTable = execute_query(qsi, -1, True, "", "", "", "")
                For i As Integer = 0 To dtsi.Rows.Count - 1
                    Dim id_item_detail As String = ""
                    'insert ignore
                    qi = "SELECT id_item_detail FROM tb_stock_card_dep_item WHERE `id_item`='" & dtsi.Rows(i)("id_item").ToString & "' AND `item_detail`='" & addSlashes(dtsi.Rows(i)("item_detail").ToString) & "' AND `remark`='" & addSlashes(dtsi.Rows(i)("remark").ToString) & "'"
                    Dim dti As DataTable = execute_query(qi, -1, True, "", "", "", "")

                    If dti.Rows.Count > 0 Then
                        id_item_detail = dti.Rows(0)("id_item_detail").ToString
                    Else
                        qi = "INSERT INTO tb_stock_card_dep_item(`id_item`,`item_detail`,`remark`)
VALUES('" & dtsi.Rows(i)("id_item").ToString & "','" & addSlashes(dtsi.Rows(i)("item_detail").ToString) & "','" & addSlashes(dtsi.Rows(i)("remark").ToString) & "'); SELECT LAST_INSERT_ID();"
                        id_item_detail = execute_query(qi, 0, True, "", "", "", "")
                    End If

                    'insert qty
                    qi = "INSERT INTO `tb_stock_card_dep`(`id_departement`,`id_item_detail`,`id_report`,`id_report_det`,`report_mark_type`,`qty`,storage_item_datetime)
VALUES('" & dtsi.Rows(i)("id_departement").ToString & "','" & id_item_detail & "','" & dtsi.Rows(i)("id_purc_rec").ToString & "','" & dtsi.Rows(i)("id_purc_rec_det").ToString & "','" & dtsi.Rows(i)("report_mark_type").ToString & "','" & decimalSQL(Decimal.Parse(dtsi.Rows(i)("qty").ToString)) & "',NOW())"
                    execute_non_query(qi, True, "", "", "", "")
                Next
            End If
            'jurnal PPH pindah
            'UNION ALL-PPH
            '    Select Case " + id_acc_trans + " As id_acc_trans, comp.id_acc_ap As `id_acc`, dep.id_main_comp, SUM(rd.qty) As `qty`,
            '    SUM(rd.`qty` * (pod.`value`-pod.`discount`) * (pod.`pph_percent`/100)) As `debit`,
            '    0 AS `credit`,
            '    i.item_desc AS `note`, 148, rd.id_purc_rec, r.purc_rec_number, If(po.id_expense_type = 1, 139, 202) As rmt_reff, po.id_purc_order, po.purc_order_number
            '    From tb_purc_rec_det rd
            '    INNER Join tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
            '    INNER Join tb_purc_order po ON po.id_purc_order = r.id_purc_order
            '    INNER Join tb_m_comp_contact cont ON cont.id_comp_contact = po.id_comp_contact
            '    INNER Join tb_m_comp comp ON comp.id_comp = cont.id_comp
            '    INNER Join tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
            '    INNER Join tb_purc_req_det reqd ON pod.id_purc_req_det=reqd.id_purc_req_det
            '    INNER Join tb_item i ON i.id_item = rd.id_item
            '    INNER Join tb_purc_req req ON req.id_purc_req=reqd.id_purc_req
            '    INNER Join tb_m_departement dep ON dep.id_departement=req.id_departement
            '    WHERE po.id_purc_order = " + FormPurcReceiveDet.id_purc_order + " And po.`is_close_rec`=1 
            '    GROUP BY po.id_purc_order, dep.id_main_comp
            '    UNION ALL - -PPH
            '    Select Case " + id_acc_trans + " As id_acc_trans, po.`pph_account` As `id_acc`, dep.id_main_comp, SUM(rd.qty) As `qty`,
            '    0 AS `debit`,
            '    SUM(rd.`qty` * (pod.`value`-pod.`discount`) * (pod.`pph_percent`/100)) As `credit`,
            '    i.item_desc AS `note`, 148, rd.id_purc_rec, r.purc_rec_number, If(po.id_expense_type = 1, 139, 202) As rmt_reff, po.id_purc_order, po.purc_order_number
            '    From tb_purc_rec_det rd
            '    INNER Join tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
            '    INNER Join tb_purc_order po ON po.id_purc_order = r.id_purc_order
            '    INNER Join tb_m_comp_contact cont ON cont.id_comp_contact = po.id_comp_contact
            '    INNER Join tb_m_comp comp ON comp.id_comp = cont.id_comp
            '    INNER Join tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
            '    INNER Join tb_purc_req_det reqd ON pod.id_purc_req_det=reqd.id_purc_req_det
            '    INNER Join tb_item i ON i.id_item = rd.id_item
            '    INNER Join tb_purc_req req ON req.id_purc_req=reqd.id_purc_req
            '    INNER Join tb_m_departement dep ON dep.id_departement=req.id_departement
            '    WHERE po.id_purc_order = " + FormPurcReceiveDet.id_purc_order + " And po.`is_close_rec`=1
            '    GROUP BY po.id_purc_order, dep.id_main_comp

            'refresh view
            FormPurcReceiveDet.actionLoad()
            FormPurcReceive.viewReceive()
            FormPurcReceive.GVReceive.FocusedRowHandle = find_row(FormPurcReceive.GVReceive, "id_purc_rec", id_report)

            'jika ada PPH dan receiving klop
            'DP pindah BBK
            '            If id_status_reportx = "6" Then
            '                'jika klop diinsert jurnal balik DP nya jika ada
            '                Dim q_dp As String = "SELECT pnd.id_report,SUM(pnd.`value`) AS `value`, po.is_close_rec FROM tb_pn_det pnd
            '                                        INNER JOIN tb_pn pn ON pn.id_pn=pnd.id_pn AND pn.id_report_status='6' AND pn.id_pay_type='1'
            '                                        INNER JOIN tb_purc_order po ON po.id_purc_order=pnd.id_report AND (pnd.report_mark_type='139' OR pnd.report_mark_type='202')
            '                                        WHERE (pnd.report_mark_type='139' OR pnd.report_mark_type='202') AND pnd.id_report='" + FormPurcReceiveDet.id_purc_order + "' 
            '                                        GROUP BY pnd.id_report"
            '                Dim dt_dp As DataTable = execute_query(q_dp, -1, True, "", "", "", "")
            '                If dt_dp.Rows.Count > 0 Then 'ada DP
            '                    If dt_dp.Rows(0)("is_close_rec").ToString = "1" Then
            '                        'sudah klop receiving
            '                        qjd += " UNION ALL
            '                                /* Total DP balik */
            '                                SELECT " + id_acc_trans + " AS id_acc_trans, comp.id_acc_dp AS `id_acc`, 1, 0 AS `qty`,0 AS `debit`,SUM(pnd.`value`) AS `credit`, 
            '                                'Receiving complete, inverting journal DP' AS note, '159', pn.id_pn, pn.number, po.report_mark_type, po.id_purc_order, po.purc_order_number
            '                                FROM tb_pn_det pnd
            '                                INNER JOIN tb_pn pn ON pn.id_pn=pnd.id_pn AND pn.id_report_status='6' AND pn.id_pay_type='1'
            '                                INNER JOIN tb_purc_order po ON po.id_purc_order=pnd.id_report AND (pnd.report_mark_type='139' OR pnd.report_mark_type='202')
            '                                INNER JOIN tb_m_comp_contact cont ON cont.id_comp_contact = po.id_comp_contact
            '                                INNER JOIN tb_m_comp comp ON comp.id_comp = cont.id_comp
            '                                WHERE (pnd.report_mark_type='139' OR pnd.report_mark_type='202') AND pnd.id_report='" + FormPurcReceiveDet.id_purc_order + "' 
            '                                GROUP BY pnd.id_report
            '                                UNION ALL
            '                                /* Hutang dagang balik */
            '                                SELECT " + id_acc_trans + " AS id_acc_trans, comp.id_acc_ap AS `id_acc`, 1, 0 AS `qty`,SUM(pnd.`value`) AS `debit`,0 AS `credit`, 
            '                                'Receiving complete, inverting journal DP' AS note, '159', pn.id_pn, pn.number, po.report_mark_type, po.id_purc_order, po.purc_order_number
            '                                FROM tb_pn_det pnd
            '                                INNER JOIN tb_pn pn ON pn.id_pn=pnd.id_pn AND pn.id_report_status='6' AND pn.id_pay_type='1'
            '                                INNER JOIN tb_purc_order po ON po.id_purc_order=pnd.id_report AND (pnd.report_mark_type='139' OR pnd.report_mark_type='202')
            '                                INNER JOIN tb_m_comp_contact cont ON cont.id_comp_contact = po.id_comp_contact
            '                                INNER JOIN tb_m_comp comp ON comp.id_comp = cont.id_comp
            '                                WHERE (pnd.report_mark_type='139' OR pnd.report_mark_type='202') AND pnd.id_report='" + FormPurcReceiveDet.id_purc_order + "' 
            '                                GROUP BY pnd.id_report"
            '                    End If
            '                End If

            '                qjd = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, id_comp, qty, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number, report_mark_type_ref, id_report_ref, report_number_ref)
            'SELECT id_acc_trans,id_acc,id_comp,qty,IF(SUM(debit)>SUM(credit),SUM(debit)-SUM(credit),0) AS debit,IF(SUM(credit)>SUM(debit),SUM(credit)-SUM(debit),0) AS credit,note,report_mark_type,id_report,report_number,rmt_reff,id_report_reff,report_number_reff
            'FROM 
            '(
            '" + qjd + "
            ') ttl
            'GROUP BY ttl.id_acc
            'HAVING debit!=credit"
            '            End If
        ElseIf report_mark_type = "150" Or report_mark_type = "155" Or report_mark_type = "172" Or report_mark_type = "173" Then
            'COP Propose
            'auto complete
            If id_status_reportx = "3" Or id_status_reportx = "6" Then
                id_status_reportx = "6"
                'complete
                query = "UPDATE tb_m_design dsg
INNER JOIN `tb_design_cop_propose_det` copd ON copd.id_design=dsg.id_design AND copd.`id_design_cop_propose`='" & id_report & "'
SET dsg.`prod_order_cop_pd_curr`=copd.`id_currency`,dsg.`prod_order_cop_kurs_pd`=copd.`kurs`,dsg.`prod_order_cop_pd`=copd.`design_cop`,dsg.`prod_order_cop_pd_vendor`=copd.`id_comp_contact`,dsg.`prod_order_cop_pd_addcost`=copd.`add_cost`,dsg.is_cold_storage=copd.is_cold_storage ;
UPDATE tb_m_design_cop SET is_active='2' WHERE id_design IN (SELECT id_design FROM tb_design_cop_propose_det WHERE id_design_cop_propose='" & id_report & "') AND is_production_dept=1;
INSERT INTO `tb_m_design_cop`(description,id_design,date_created,id_currency,kurs,before_kurs,additional,is_active,is_production_dept)
SELECT cmp.description,copd.id_design,NOW(),cmp.id_currency,cmp.kurs,cmp.before_kurs,cmp.additional,1,1 FROM tb_design_cop_propose_comp cmp
INNER JOIN `tb_design_cop_propose_det` copd ON copd.id_design_cop_propose_det=cmp.id_design_cop_propose_det
WHERE copd.id_design_cop_propose='" & id_report & "';"
                execute_non_query(query, True, "", "", "", "")
            End If
            'update status
            query = String.Format("UPDATE tb_design_cop_propose SET id_report_status='{0}' WHERE id_design_cop_propose ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "151" Then
            'claim return
            'auto completed
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            'update status
            query = String.Format("UPDATE tb_prod_claim_return SET id_report_status='{0}' WHERE id_prod_claim_return ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            Try
                FormProductionClaimReturn.viewData()
                FormProductionClaimReturn.GVData.FocusedRowHandle = find_row(FormProductionClaimReturn.GVData, "id_prod_claim_return", id_report)
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "152" Then
            'purchase return
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If
            If id_status_reportx = "5" Then
                'cancell out stock (in stock)
                Dim rs As New ClassPurcReturn()
                rs.updateStock(id_report, 1)
            ElseIf id_status_reportx = "6" Then
                'complit
                ' select user prepared
                Dim qu As String = "SELECT rm.id_user, rm.report_number FROM tb_report_mark rm WHERE rm.report_mark_type=" + report_mark_type + " AND rm.id_report='" + id_report + "' AND rm.id_report_status=1 "
                Dim du As DataTable = execute_query(qu, -1, True, "", "", "", "")
                Dim id_user_prepared As String = du.Rows(0)("id_user").ToString
                Dim report_number As String = du.Rows(0)("report_number").ToString

                'main journal
                Dim qjm As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, acc_trans_note, id_report_status)
                VALUES ('','" + report_number + "','0','" + id_user_prepared + "', NOW(), 'Auto Posting', '6'); SELECT LAST_INSERT_ID(); "
                Dim id_acc_trans As String = execute_query(qjm, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id_acc_trans + ",36)", True, "", "", "", "")

                'det journal
                Dim qjd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, id_comp, qty, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number)
                SELECT " + id_acc_trans + ",o.acc_coa_receive AS `id_acc`, cont.id_comp,  SUM(rd.qty) AS `qty`,0 AS `debit`, SUM(rd.qty * pod.`value`) AS `credit`,'' AS `note`,152,rd.id_purc_return, r.`number`
                FROM tb_purc_return_det rd
                INNER JOIN tb_purc_return r ON r.id_purc_return = rd.id_purc_return
                INNER JOIN tb_purc_order po ON po.id_purc_order = r.id_purc_order
                INNER JOIN tb_m_comp_contact cont ON cont.id_comp_contact = po.id_comp_contact
                INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
                INNER JOIN tb_item i ON i.id_item = rd.id_item
                JOIN tb_opt_purchasing o
                WHERE rd.id_purc_return=" + id_report + "
                GROUP BY rd.id_purc_return
                UNION ALL
                SELECT " + id_acc_trans + ", o.acc_coa_hutang AS `id_acc`, cont.id_comp, SUM(rd.qty) AS `qty`, SUM(rd.qty*pod.`value`) AS `debit`, 0 AS `credit`,'' AS `note`, 152, rd.id_purc_return, r.`number`
                FROM tb_purc_return_det rd
                INNER JOIN tb_purc_return r ON r.id_purc_return = rd.id_purc_return
                INNER JOIN tb_purc_order po ON po.id_purc_order = r.id_purc_order
                INNER JOIN tb_m_comp_contact cont ON cont.id_comp_contact = po.id_comp_contact
                INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
                JOIN tb_opt_purchasing o
                WHERE rd.id_purc_return=" + id_report + "
                GROUP BY rd.id_purc_return "
                execute_non_query(qjd, True, "", "", "", "")
            End If

            'update
            query = String.Format("UPDATE tb_purc_return SET id_report_status='{0}' WHERE id_purc_return ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            FormPurcReturn.viewReturn()
            FormPurcReturn.GVReturn.FocusedRowHandle = find_row(FormPurcReturn.GVReturn, "id_purc_return", id_report)
        ElseIf report_mark_type = "153" Then
            'claim return
            'auto completed
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If
            'update status
            query = String.Format("UPDATE tb_m_comp SET id_report_status='{0}' WHERE id_comp ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            '
            If id_status_reportx = "6" Then
                query = String.Format("UPDATE tb_m_comp SET is_active='1' WHERE id_comp ='{0}'", id_report)
                execute_non_query(query, True, "", "", "", "")
            End If
            'refresh view
            Try
                FormMasterCompanySingle.action_load()
                FormMasterCompany.view_company()
                FormMasterCompany.GVCompany.FocusedRowHandle = find_row(FormMasterCompany.GVCompany, "id_comp", id_report)
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "154" Or report_mark_type = "163" Then
            'item request
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "5" Then
                'cancell out stock (in stock)
                Dim rs As New ClassItemRequest()
                rs.updateStock(id_report, 1, report_mark_type)
            End If

            'update
            query = String.Format("UPDATE tb_item_req SET id_report_status='{0}' WHERE id_item_req ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            'FormItemReq.viewData()
            'FormItemReq.GVData.FocusedRowHandle = find_row(FormItemReq.GVData, "id_item_req", id_report)
        ElseIf report_mark_type = "156" Or report_mark_type = "166" Then
            'Item del
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            'update
            query = String.Format("UPDATE tb_item_del SET id_report_status='{0}' WHERE id_item_del ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            If id_status_reportx = "6" Then
                'completed storage
                Dim id_purc_store As String = get_purc_setup_field("id_purc_store")

                Dim query_completed_stock As String = "INSERT INTO tb_storage_item (id_departement, id_storage_category,id_item, `value`, report_mark_type, id_report, storage_item_qty, storage_item_datetime, id_stock_status)
                SELECT IF(rd.is_store_request=1,'" & id_purc_store & "',r.id_departement) AS id_departement, 1, dd.id_item, getAvgCost(dd.id_item), IF(r.is_for_store=1,163,154) AS rmt, r.id_item_req, dd.qty, NOW(), 1
                FROM tb_item_del d
                INNER JOIN tb_item_del_det dd ON dd.id_item_del = d.id_item_del
                INNER JOIN tb_item_req_det rd ON rd.id_item_req_det=dd.`id_item_req_det`
                INNER JOIN tb_item_req r ON r.id_item_req = d.id_item_req
                WHERE d.id_item_del=" + id_report + " 
                -- AND rd.is_store_request='2'
                UNION ALL
                SELECT IF(rd.is_store_request=1,'" & id_purc_store & "',r.id_departement) AS id_departement, 2, dd.id_item, getAvgCost(dd.id_item), " + report_mark_type + " AS rmt, d.id_item_del, dd.qty, NOW(), 1
                FROM tb_item_del d
                INNER JOIN tb_item_del_det dd ON dd.id_item_del = d.id_item_del
                INNER JOIN tb_item_req_det rd ON rd.id_item_req_det=dd.`id_item_req_det`
                INNER JOIN tb_item_req r ON r.id_item_req = d.id_item_req
                WHERE d.id_item_del=" + id_report + ";
                CALL update_item_reqdel_stt(" + id_report + "); "
                execute_non_query(query_completed_stock, True, "", "", "", "")

                ' select user prepared
                Dim qu As String = "SELECT rm.id_user, rm.report_number FROM tb_report_mark rm WHERE rm.report_mark_type=" + report_mark_type + " AND rm.id_report='" + id_report + "' AND rm.id_report_status=1 "
                Dim du As DataTable = execute_query(qu, -1, True, "", "", "", "")
                Dim id_user_prepared As String = du.Rows(0)("id_user").ToString
                Dim report_number As String = du.Rows(0)("report_number").ToString

                'main journal
                Dim qjm As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, acc_trans_note, id_report_status)
                VALUES ('','" + report_number + "','0','" + id_user_prepared + "', NOW(), 'Auto Posting', '6'); SELECT LAST_INSERT_ID(); "
                Dim id_acc_trans As String = execute_query(qjm, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id_acc_trans + ",36)", True, "", "", "", "")

                'det journal
                If FormItemDelDetail.is_for_store = "1" Then
                    Dim qjd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, qty, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number, id_comp)
                    SELECT " + id_acc_trans + " AS `id_trans`,m.id_coa_out AS `id_acc`, SUM(dd.qty) AS `qty`, SUM(dd.qty*getAvgCost(dd.id_item)) AS `debit`, 0 AS `credit`,
                    CONCAT('Expense : ',cat.item_cat,' (',c.comp_number,'), ',d.note) AS `note`, " + report_mark_type + " AS `rmt`, d.id_item_del, d.`number`, c.id_comp
                    FROM tb_item_del_det_alloc dd
                    INNER JOIN tb_item_del d ON d.id_item_del = dd.id_item_del
                    INNER JOIN tb_item_req r ON r.id_item_req = d.id_item_req
                    INNER JOIN tb_item i ON i.id_item = dd.id_item
                    INNER JOIN tb_item_cat cat ON cat.id_item_cat = i.id_item_cat
                    INNER JOIN tb_item_coa m ON m.id_item_cat = i.id_item_cat AND m.id_departement = r.id_departement
                    INNER JOIN tb_m_comp c ON c.id_comp = dd.id_comp
                    WHERE dd.id_item_del=" + id_report + "
                    GROUP BY i.id_item_cat, dd.id_comp
                    UNION ALL
                    -- afiliasi companynya
                    SELECT " + id_acc_trans + " AS `id_trans`,(SELECT id_acc_afiliasi FROM tb_opt_accounting LIMIT 1) AS `id_acc`, SUM(dd.qty) AS `qty`, 0 AS `debit`, SUM(dd.qty*getAvgCost(dd.id_item)) AS `credit`,
                    CONCAT('Expense : ',cat.item_cat,' (',c.comp_number,'), ',d.note) AS `note`, " + report_mark_type + " AS `rmt`, d.id_item_del, d.`number`, c.id_comp
                    FROM tb_item_del_det_alloc dd
                    INNER JOIN tb_item_del d ON d.id_item_del = dd.id_item_del
                    INNER JOIN tb_item_req r ON r.id_item_req = d.id_item_req
                    INNER JOIN tb_item i ON i.id_item = dd.id_item
                    INNER JOIN tb_item_cat cat ON cat.id_item_cat = i.id_item_cat
                    INNER JOIN tb_item_coa m ON m.id_item_cat = i.id_item_cat AND m.id_departement = r.id_departement
                    INNER JOIN tb_m_comp c ON c.id_comp = dd.id_comp
                    WHERE dd.id_item_del=" + id_report + "
                    GROUP BY i.id_item_cat, dd.id_comp
                    UNION ALL
                    -- balik afiliasi volcom
                    SELECT " + id_acc_trans + " AS `id_trans`,(SELECT id_acc_afiliasi FROM tb_opt_accounting LIMIT 1) AS `id_acc`, SUM(dd.qty) AS `qty`, SUM(dd.qty*getAvgCost(dd.id_item)) AS `debit`, 0 AS `credit`,
                    CONCAT('Expense : ',cat.item_cat,' (',c.comp_number,'), ',d.note) AS `note`, " + report_mark_type + " AS `rmt`, d.id_item_del, d.`number`, 1
                    FROM tb_item_del_det_alloc dd
                    INNER JOIN tb_item_del d ON d.id_item_del = dd.id_item_del
                    INNER JOIN tb_item_req r ON r.id_item_req = d.id_item_req
                    INNER JOIN tb_item i ON i.id_item = dd.id_item
                    INNER JOIN tb_item_cat cat ON cat.id_item_cat = i.id_item_cat
                    INNER JOIN tb_item_coa m ON m.id_item_cat = i.id_item_cat AND m.id_departement = r.id_departement
                    INNER JOIN tb_m_comp c ON c.id_comp = dd.id_comp
                    WHERE dd.id_item_del=" + id_report + "
                    GROUP BY i.id_item_cat, dd.id_comp
                    UNION ALL
                    SELECT " + id_acc_trans + " AS `id_trans`,o.acc_coa_receive AS `id_acc`, SUM(dd.qty) AS `qty`, 0 AS `debit`, SUM(dd.qty*getAvgCost(dd.id_item)) AS `credit`, '' AS `note`, " + report_mark_type + " AS `rmt`, d.id_item_del, d.`number`, 1 AS `id_comp`
                    FROM tb_item_del_det dd
                    INNER JOIN tb_item_del d ON d.id_item_del = dd.id_item_del
                    JOIN tb_opt_purchasing o
                    WHERE dd.id_item_del=" + id_report + "
                    GROUP BY dd.id_item_del "
                    execute_non_query(qjd, True, "", "", "", "")
                ElseIf FormItemDelDetail.is_for_store = "2" Then
                    Dim qjd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, qty, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number,id_comp,id_coa_tag)
                    SELECT " + id_acc_trans + " AS `id_trans`,m.id_coa_out AS `id_acc`, SUM(dd.qty) AS `qty`, SUM(dd.qty*getAvgCost(dd.id_item)) AS `debit`, 0 AS `credit`, i.`item_desc` AS `note`, " + report_mark_type + " AS `rmt`, d.id_item_del, d.number, 1 AS `id_comp`,dep.id_coa_tag
                    FROM tb_item_del_det dd
                    INNER JOIN tb_item_del d ON d.id_item_del = dd.id_item_del
                    INNER JOIN tb_item_req r ON r.id_item_req = d.id_item_req
                    INNER JOIN tb_m_departement dep ON r.id_departement = dep.id_departement
                    INNER JOIN tb_item i ON i.id_item = dd.id_item
                    INNER JOIN tb_item_cat cat ON cat.id_item_cat = i.id_item_cat
                    INNER JOIN tb_item_coa m ON m.id_item_cat = i.id_item_cat AND m.id_departement = r.id_departement
                    WHERE dd.id_item_del=" + id_report + "
                    GROUP BY dd.id_item_del_det
                    UNION ALL
                    SELECT " + id_acc_trans + " AS `id_trans`,IF(dep.id_coa_tag=1,o.acc_coa_receive,o.acc_coa_receive_cabang) AS `id_acc`, SUM(dd.qty) AS `qty`, 0 AS `debit`, SUM(dd.qty*getAvgCost(dd.id_item)) AS `credit`, i.`item_desc` AS `note`, " + report_mark_type + " AS `rmt`, d.id_item_del, d.number, 1 AS `id_comp`,dep.id_coa_tag
                    FROM tb_item_del_det dd
                    INNER JOIN tb_item i ON i.id_item = dd.id_item
                    INNER JOIN tb_item_cat cat ON cat.id_item_cat = i.id_item_cat
                    INNER JOIN tb_item_del d ON d.id_item_del = dd.id_item_del
                    INNER JOIN tb_item_req r ON r.id_item_req = d.id_item_req
                    INNER JOIN tb_m_departement dep ON r.id_departement = dep.id_departement
                    JOIN tb_opt_purchasing o
                    WHERE dd.id_item_del=" + id_report + "
                    GROUP BY dd.id_item_del_det "
                    execute_non_query(qjd, True, "", "", "", "")
                End If
            End If

            'refresh view
            FormItemDelDetail.actionLoad()
            FormItemDel.viewDelivery()
            FormItemDel.GVDelivery.FocusedRowHandle = find_row(FormItemDel.GVDelivery, "id_item_del", id_report)
        ElseIf report_mark_type = "157" Then
            'expense
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            Dim id_report_now As String = execute_query("SELECT id_report_status FROM tb_item_expense WHERE id_item_expense='" & id_report & "'", 0, True, "", "", "", "")

            'update
            query = String.Format("UPDATE tb_item_expense SET id_report_status='{0}' WHERE id_item_expense ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            If id_status_reportx = "5" And id_report_now = "6" Then 'cancel form
                Dim old_id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
                WHERE ad.report_mark_type=157 AND ad.id_report=" + id_report + "
                GROUP BY ad.id_acc_trans ", 0, True, "", "", "", "")
                '
                Dim qu As String = "SELECT rm.id_user, rm.report_number FROM tb_report_mark rm WHERE rm.report_mark_type=" + report_mark_type + " AND rm.id_report='" + id_report + "' AND rm.id_report_status=1 "
                Dim du As DataTable = execute_query(qu, -1, True, "", "", "", "")
                Dim id_user_prepared As String = du.Rows(0)("id_user").ToString
                Dim report_number As String = du.Rows(0)("report_number").ToString

                Dim qe As String = "SELECT created_date,date_reff FROM tb_item_expense WHERE id_item_expense='" & id_report & "'"
                Dim de As DataTable = execute_query(qe, -1, True, "", "", "", "")
                Dim date_reff As String = Date.Parse(de.Rows(0)("date_reff").ToString).ToString("yyyy-MM-dd")

                'main journal
                Dim qjm As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, date_reference, acc_trans_note, id_report_status)
                VALUES ('','" + report_number + "','0','" + id_user_prepared + "', NOW(), NOW(), 'Cancel Expense', '6'); SELECT LAST_INSERT_ID(); "
                Dim id_acc_trans As String = execute_query(qjm, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id_acc_trans + ",36)", True, "", "", "", "")
                '
                Dim q_balik = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number, id_comp, report_number_ref, id_vendor)
SELECT id_acc_trans, id_acc, credit, debit, CONCAT('Cancel Form - ',acc_trans_det_note) AS acc_trans_det_note, report_mark_type, id_report, report_number, id_comp, report_number_ref, id_vendor
FROM tb_a_acc_trans_det
WHERE id_acc_trans='" & old_id_acc_trans & "'"
                execute_non_query(q_balik, True, "", "", "", "")
            End If

            If id_status_reportx = "6" Then
                ' select user prepared
                Dim qu As String = "SELECT rm.id_user, rm.report_number FROM tb_report_mark rm WHERE rm.report_mark_type=" + report_mark_type + " AND rm.id_report='" + id_report + "' AND rm.id_report_status=1 "
                Dim du As DataTable = execute_query(qu, -1, True, "", "", "", "")
                Dim id_user_prepared As String = du.Rows(0)("id_user").ToString
                Dim report_number As String = du.Rows(0)("report_number").ToString

                Dim qe As String = "SELECT created_date,date_reff FROM tb_item_expense WHERE id_item_expense='" & id_report & "'"
                Dim de As DataTable = execute_query(qe, -1, True, "", "", "", "")
                Dim date_reff As String = Date.Parse(de.Rows(0)("date_reff").ToString).ToString("yyyy-MM-dd")

                'main journal
                Dim qjm As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, date_reference, acc_trans_note, id_report_status)
                VALUES ('','" + report_number + "','0','" + id_user_prepared + "', NOW(), '" & date_reff & "', 'Auto Posting', '6'); SELECT LAST_INSERT_ID(); "
                Dim id_acc_trans As String = execute_query(qjm, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id_acc_trans + ",36)", True, "", "", "", "")

                If FormItemExpenseDet.CEPayLater.EditValue = True Then
                    'utang
                    Dim qjd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, id_vendor, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number, id_comp, report_number_ref, id_coa_tag)
                    SELECT " + id_acc_trans + ", ed.id_acc_pph, e.id_comp  AS id_vendor,IF(ed.amount<0,-ed.pph,0) AS `debit`, IF(ed.amount<0,0,ed.pph) AS `credit`, ed.description, 157, e.id_item_expense, e.`number`,ed.cc
                    ,e.inv_number,e.id_coa_tag
                    FROM tb_item_expense e
                    INNER JOIN  tb_item_expense_det ed ON ed.id_item_expense = e.id_item_expense
                    WHERE e.id_item_expense=" + id_report + " AND pph_percent>0 AND ed.`id_acc_pph` != (SELECT id_acc_skbp FROM tb_opt_accounting)
                    UNION ALL
                    SELECT " + id_acc_trans + ", ed.id_acc_pph, e.id_comp  AS id_vendor,IF(ed.amount<0,-FLOOR(ed.amount*(ed.`pph_percent`/100)),0) AS `debit`, IF(ed.amount<0,0,FLOOR(ed.amount*(ed.`pph_percent`/100))) AS `credit`, ed.description, 157, e.id_item_expense, e.`number`,ed.cc
                    ,e.inv_number,e.id_coa_tag
                    FROM tb_item_expense e
                    INNER JOIN  tb_item_expense_det ed ON ed.id_item_expense = e.id_item_expense
                    WHERE e.id_item_expense=" + id_report + " AND pph_percent>0 AND ed.`id_acc_pph` = (SELECT id_acc_skbp FROM tb_opt_accounting)
                    UNION ALL
                    SELECT " + id_acc_trans + ", ed.id_acc_pph, e.id_comp  AS id_vendor,IF(ed.amount<0,0,FLOOR(ed.amount*(ed.`pph_percent`/100))) AS `debit`, IF(ed.amount<0,-FLOOR(ed.amount*(ed.`pph_percent`/100)),0) AS `credit`, ed.description, 157, e.id_item_expense, e.`number`,ed.cc
                    ,e.inv_number,e.id_coa_tag
                    FROM tb_item_expense e
                    INNER JOIN  tb_item_expense_det ed ON ed.id_item_expense = e.id_item_expense
                    WHERE e.id_item_expense=" + id_report + " AND pph_percent>0 AND ed.`id_acc_pph` = (SELECT id_acc_skbp FROM tb_opt_accounting)
                    UNION ALL
                    SELECT " + id_acc_trans + ", ed.id_acc, e.id_comp  AS id_vendor, IF(ed.amount<0,0,ed.amount) AS `debit`, IF(ed.amount<0,-ed.amount,0) AS `credit`, ed.description, 157, e.id_item_expense, e.`number`,ed.cc
                    ,e.inv_number,e.id_coa_tag
                    FROM tb_item_expense e
                    INNER JOIN  tb_item_expense_det ed ON ed.id_item_expense = e.id_item_expense
                    WHERE e.id_item_expense=" + id_report + "
                    UNION ALL
                    SELECT " + id_acc_trans + ", IF(e.id_coa_tag=1,o.acc_coa_vat_in,o.acc_coa_vat_in_cabang), e.id_comp  AS id_vendor, e.vat_total AS `debit`, 0 AS `credit`, e.note AS description, 157, e.id_item_expense, e.`number`,1
                    ,e.inv_number,e.id_coa_tag
                    FROM tb_item_expense e
                    JOIN tb_opt_purchasing o
                    WHERE e.id_item_expense=" + id_report + " AND e.vat_total>0
                    UNION ALL
                    SELECT " + id_acc_trans + ",  IF(e.id_coa_tag=1,c.id_acc_ap,c.id_acc_cabang_ap) AS `id_acc`, e.id_comp  AS id_vendor, 0 AS `debit`, e.`total` AS `credit`, e.note AS description, 157, e.id_item_expense, e.`number`,1
                    ,e.inv_number,e.id_coa_tag
                    FROM tb_item_expense e
                    INNER JOIN tb_m_comp c ON c.id_comp = e.id_comp
                    WHERE e.id_item_expense=" + id_report + " "
                    execute_non_query(qjd, True, "", "", "", "")
                Else
                    'lansung biaya
                    Dim qjd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number,id_comp,id_coa_tag)
                    SELECT " + id_acc_trans + ", ed.id_acc_pph,IF(ed.amount<0,(ed.pph_percent/100)*-ed.amount,0) AS `debit`, IF(ed.amount<0,0,(ed.pph_percent/100)*ed.amount) AS `credit`, ed.description, 157, e.id_item_expense, e.`number`,ed.cc,e.id_coa_tag
                    FROM tb_item_expense e
                    INNER JOIN  tb_item_expense_det ed ON ed.id_item_expense = e.id_item_expense
                    WHERE e.id_item_expense=" + id_report + " AND pph_percent>0
                    UNION ALL
                    SELECT " + id_acc_trans + ", ed.id_acc,  IF(ed.amount<0,0,ed.amount) AS `debit`, IF(ed.amount<0,-ed.amount,0) AS `credit`, ed.description, 157, e.id_item_expense, e.`number`,ed.cc,e.id_coa_tag
                    FROM tb_item_expense e
                    INNER JOIN  tb_item_expense_det ed ON ed.id_item_expense = e.id_item_expense
                    WHERE e.id_item_expense=" + id_report + "
                    UNION ALL
                    SELECT " + id_acc_trans + ", o.acc_coa_vat_in, e.vat_total AS `debit`, 0 AS `credit`, e.note AS description, 157, e.id_item_expense, e.`number`,1,e.id_coa_tag
                    FROM tb_item_expense e
                    JOIN tb_opt_purchasing o
                    WHERE e.id_item_expense=" + id_report + " AND e.vat_total>0
                    UNION ALL
                    SELECT " + id_acc_trans + ", e.id_acc_from, 0 AS `debit`, e.`total` AS `credit`, e.note AS description, 157, e.id_item_expense, e.`number`,1,e.id_coa_tag
                    FROM tb_item_expense e
                    WHERE e.id_item_expense=" + id_report + " "
                    execute_non_query(qjd, True, "", "", "", "")
                End If
                'budget
                Dim q_budget As String = "INSERT INTO tb_b_expense_opex_trans(id_b_expense_opex,is_po,id_departement,date_trans,`value`,id_item,id_report,report_mark_type,note)
                SELECT ied.id_b_expense,'2' AS is_po, '5' AS id_departement,NOW() AS date_trans,amount,NULL AS id_item,ie.id_item_expense,'157','Expense'
                FROM tb_item_expense_det ied 
                INNER JOIN tb_item_expense ie ON ie.id_item_expense=ied.id_item_expense
                WHERE ied.id_expense_type='1' AND ied.id_item_expense='" + id_report + "';
                INSERT INTO tb_b_expense_trans(id_b_expense,is_po,id_departement,date_trans,`value`,id_item,id_report,report_mark_type,note)
                SELECT ied.id_b_expense,'2' AS is_po, be.id_departement AS id_departement,NOW() AS date_trans,amount,NULL AS id_item,ie.id_item_expense,'157','Expense'
                FROM tb_item_expense_det ied 
                INNER JOIN tb_item_expense ie ON ie.id_item_expense=ied.id_item_expense
                INNER JOIN tb_b_expense be ON be.id_b_expense=ied.id_b_expense
                WHERE ied.id_expense_type='2' AND ied.id_item_expense='" + id_report + "';"
                execute_non_query(q_budget, True, "", "", "", "")
            End If

            'refresh view
            'Try
            'FormItemExpenseDet.actionLoad()
            'FormItemExpense.viewData()
            'FormItemExpense.GVData.FocusedRowHandle = find_row(FormItemExpense.GVData, "id_item_expense", id_report)
            'Catch ex As Exception
            'End Try
        ElseIf report_mark_type = "159" Then
            'Payment
            'auto completed on summary
            'If id_status_reportx = "3" Then
            'id_status_reportx = "6"
            'End If
            'select header
            Dim qu_payment As String = "SELECT id_pay_type,report_mark_type,date_created,date_payment,is_auto_debet,is_buy_valas,kurs FROM tb_pn py WHERE py.id_pn='" & id_report & "'"
            Dim data_payment As DataTable = execute_query(qu_payment, -1, True, "", "", "", "")

            If data_payment.Rows(0)("is_auto_debet").ToString = "1" Then
                If id_status_reportx = "3" Then
                    id_status_reportx = "6"
                End If
            End If

            'completed
            If id_status_reportx = "6" Then
                'auto journal
                Dim qu As String = "SELECT rm.id_user, rm.report_number FROM tb_report_mark rm WHERE rm.report_mark_type=" + report_mark_type + " AND rm.id_report='" + id_report + "' AND rm.id_report_status=1 "
                Dim du As DataTable = execute_query(qu, -1, True, "", "", "", "")
                Dim id_user_prepared As String = du.Rows(0)("id_user").ToString
                Dim report_number As String = du.Rows(0)("report_number").ToString

                Dim date_reff As String = Date.Parse(data_payment.Rows(0)("date_payment").ToString).ToString("yyyy-MM-dd")

                'main journal
                Dim qjm As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, date_reference, acc_trans_note, id_report_status)
                VALUES('','" + report_number + "','22','" + id_user_prepared + "', NOW(), '" & date_reff & "', 'Auto Posting', '6'); SELECT LAST_INSERT_ID(); "
                Dim id_acc_trans As String = execute_query(qjm, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id_acc_trans + ",36)", True, "", "", "", "")

                'det journal
                Dim qjd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, id_vendor, id_comp, qty, debit, credit, id_currency, kurs, debit_valas, credit_valas, acc_trans_det_note, report_mark_type, id_report, report_number,report_mark_type_ref, id_report_ref, report_number_ref, vendor, id_coa_tag)
                                    SELECT * FROM
                                    (
	                                    /* Pay from */
	                                    SELECT '" & id_acc_trans & "' AS id_acc_trans,py.id_acc_payfrom AS `id_acc`,ccvendor.id_comp  AS id_vendor,1 AS id_comp,  0 AS `qty`,0 AS `debit`, py.value+py.trf_fee AS `credit`, 1 AS id_currency, 0 AS kurs,0  AS debit_valas, 0 AS credit_valas,py.note AS `note`,159 AS report_mark_type,py.id_pn AS id_report, py.number AS report_number,NULL AS report_mark_type_ref,NULL AS id_report_ref,NULL AS report_number_ref,NULL AS vendor,py.id_coa_tag
	                                    FROM tb_pn py
                                        INNER JOIN tb_m_comp_contact ccvendor ON ccvendor.id_comp_contact=py.id_comp_contact
	                                    WHERE py.id_pn=" & id_report & "
	                                    UNION ALL
                                        /* Transfer Fee */
	                                    SELECT '" & id_acc_trans & "' AS id_acc_trans,py.id_acc_trf_fee AS `id_acc`,ccvendor.id_comp  AS id_vendor,1 AS id_comp,  0 AS `qty`,py.trf_fee AS `debit`, 0 AS `credit`, 1 AS id_currency, 0 AS kurs,0  AS debit_valas, 0 AS credit_valas,py.note AS `note`,159 AS report_mark_type,py.id_pn AS id_report, py.number AS report_number,NULL AS report_mark_type_ref,NULL AS id_report_ref,NULL AS report_number_ref,NULL AS vendor,py.id_coa_tag
	                                    FROM tb_pn py
                                        INNER JOIN tb_m_comp_contact ccvendor ON ccvendor.id_comp_contact=py.id_comp_contact
	                                    WHERE py.id_pn=" & id_report & "
                                        UNION ALL
	                                    /* Hutang dagang */
	                                    SELECT '" & id_acc_trans & "' AS id_acc_trans,pnd.id_acc AS `id_acc`,ccvendor.id_comp  AS id_vendor, pnd.id_comp,  0 AS `qty`,IF(pnd.id_dc=2,0,ABS(pnd.value)) AS `debit`, IF(pnd.id_dc=2,ABS(pnd.value),0) AS `credit`, pnd.id_currency, pnd.kurs, IF(pnd.id_dc=2,0,ABS(pnd.val_bef_kurs)) AS debit_valas, IF(pnd.id_dc=2,ABS(pnd.val_bef_kurs),0) AS credit_valas,pnd.note AS `note`,159 AS report_mark_type,pn.id_pn AS id_report, pn.number AS report_number,pnd.report_mark_type,pnd.id_report,pnd.number,pnd.vendor,pn.id_coa_tag
	                                    FROM tb_pn_det pnd
	                                    INNER JOIN tb_pn pn ON pnd.id_pn=pn.id_pn
                                        INNER JOIN tb_m_comp_contact ccvendor ON ccvendor.id_comp_contact=pn.id_comp_contact
	                                    WHERE pn.id_pn=" & id_report & "                 
                                    )trx WHERE trx.debit != 0 OR trx.credit != 0"
                execute_non_query(qjd, True, "", "", "", "")
                '
                If is_bbk_tolakan Then
                    'balik jurnal
                    Dim qjm_tolak As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, date_reference, acc_trans_note, id_report_status)
                VALUES('','" + report_number + "','25','" + id_user_prepared + "', NOW(), '" & date_reff & "', 'Auto Posting Tolakan', '6'); SELECT LAST_INSERT_ID(); "
                    Dim id_acc_trans_tolak As String = execute_query(qjm_tolak, 0, True, "", "", "", "")
                    execute_non_query("CALL gen_number(" + id_acc_trans_tolak + ",36)", True, "", "", "", "")

                    'det journal
                    Dim qjd_tolak As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, id_vendor, id_comp, qty, debit, credit, id_currency, kurs, debit_valas, credit_valas, acc_trans_det_note, report_mark_type, id_report, report_number,report_mark_type_ref, id_report_ref, report_number_ref, vendor, id_coa_tag)
                                    SELECT * FROM
                                    (
	                                    /* Pay from */
	                                    SELECT '" & id_acc_trans_tolak & "' AS id_acc_trans,py.id_acc_payfrom AS `id_acc`,ccvendor.id_comp  AS id_vendor,1 AS id_comp,  0 AS `qty`,py.value+py.trf_fee AS `debit`,0  AS `credit`, 1 AS id_currency, 0 AS kurs,0  AS debit_valas, 0 AS credit_valas,py.note AS `note`,159 AS report_mark_type,py.id_pn AS id_report, py.number AS report_number,NULL AS report_mark_type_ref,NULL AS id_report_ref,NULL AS report_number_ref,NULL AS vendor,py.id_coa_tag
	                                    FROM tb_pn py
                                        INNER JOIN tb_m_comp_contact ccvendor ON ccvendor.id_comp_contact=py.id_comp_contact
	                                    WHERE py.id_pn=" & id_report & "
	                                    UNION ALL
                                        /* Transfer Fee */
	                                    SELECT '" & id_acc_trans_tolak & "' AS id_acc_trans,py.id_acc_trf_fee AS `id_acc`,ccvendor.id_comp  AS id_vendor,1 AS id_comp,  0 AS `qty`,0 AS `debit`, py.trf_fee AS `credit`, 1 AS id_currency, 0 AS kurs,0  AS debit_valas, 0 AS credit_valas,py.note AS `note`,159 AS report_mark_type,py.id_pn AS id_report, py.number AS report_number,NULL AS report_mark_type_ref,NULL AS id_report_ref,NULL AS report_number_ref,NULL AS vendor,py.id_coa_tag
	                                    FROM tb_pn py
                                        INNER JOIN tb_m_comp_contact ccvendor ON ccvendor.id_comp_contact=py.id_comp_contact
	                                    WHERE py.id_pn=" & id_report & "
                                        UNION ALL
	                                    /* Hutang dagang */
	                                    SELECT '" & id_acc_trans_tolak & "' AS id_acc_trans,pnd.id_acc AS `id_acc`,ccvendor.id_comp  AS id_vendor, pnd.id_comp,  0 AS `qty`,IF(pnd.id_dc=2,ABS(pnd.value),0) AS `debit`, IF(pnd.id_dc=2,0,ABS(pnd.value)) AS `credit`, pnd.id_currency, pnd.kurs, IF(pnd.id_dc=2,0,ABS(pnd.val_bef_kurs)) AS debit_valas, IF(pnd.id_dc=2,ABS(pnd.val_bef_kurs),0) AS credit_valas,pnd.note AS `note`,159 AS report_mark_type,pn.id_pn AS id_report, pn.number AS report_number,pnd.report_mark_type,pnd.id_report,pnd.number,pnd.vendor,pn.id_coa_tag
	                                    FROM tb_pn_det pnd
	                                    INNER JOIN tb_pn pn ON pnd.id_pn=pn.id_pn
                                        INNER JOIN tb_m_comp_contact ccvendor ON ccvendor.id_comp_contact=pn.id_comp_contact
	                                    WHERE pn.id_pn=" & id_report & "                 
                                    )trx WHERE trx.debit != 0 OR trx.credit != 0"
                    execute_non_query(qjd_tolak, True, "", "", "", "")
                End If

                If Not is_bbk_tolakan Then
                    'PROSES CLOSING
                    If data_payment.Rows(0)("report_mark_type").ToString = "139" Or data_payment.Rows(0)("report_mark_type").ToString = "202" Then
                        'check total
                        query = String.Format("UPDATE tb_pn SET id_report_status='{0}' WHERE id_pn ='{1}'", id_status_reportx, id_report)
                        execute_non_query(query, True, "", "", "", "")

                        Dim id_po As String = execute_query("SELECT id_report FROM tb_pn_det WHERE id_pn = " + id_report + " LIMIT 1", 0, True, "", "", "", "")

                        Dim value_pn As String = execute_query("
                        SELECT ROUND(SUM(pn_det.value), 2) AS VALUE
                        FROM tb_pn_det AS pn_det
                        LEFT JOIN tb_pn AS pn ON pn_det.id_pn = pn.id_pn AND pn.is_tolakan=2
                        WHERE pn.report_mark_type = '" + data_payment.Rows(0)("report_mark_type").ToString + "' AND pn_det.id_report = '" + id_po + "' AND pn.id_report_status = 6
                    ", 0, True, "", "", "", "")


                        Dim value_po As String = execute_query("
                        SELECT ROUND((SUM(pod.qty * (pod.value - pod.discount)) - po.disc_value + po.vat_value - po.pph_total), 2) AS VALUE
                        FROM tb_purc_order po
                        INNER JOIN tb_purc_order_det pod ON pod.id_purc_order = po.id_purc_order
                        WHERE po.id_purc_order = '" + id_po + "'
                    ", 0, True, "", "", "", "")

                        If value_pn = value_po Then
                            'close pay in tb_purc_order
                            Dim qc As String = "UPDATE tb_purc_order po
                                                INNER JOIN tb_pn_det pyd ON pyd.`id_report`=po.`id_purc_order` AND pyd.balance_due=pyd.`value` AND pyd.`id_pn`=" & id_report & "
                                                SET po.is_close_pay='1'"
                            execute_non_query(qc, True, "", "", "", "")

                        End If

                        'FormBankWithdrawal.load_po()
                    ElseIf data_payment.Rows(0)("report_mark_type").ToString = "157" Then
                        'close expense
                        Dim qc As String = "UPDATE tb_item_expense e
                                                INNER JOIN tb_pn_det pyd ON pyd.`id_report`=e.`id_item_expense` AND pyd.balance_due=pyd.`value` AND pyd.`id_pn`=" & id_report & "
                                                SET e.is_open='2'"
                        execute_non_query(qc, True, "", "", "", "")
                        'FormBankWithdrawal.load_expense()
                    ElseIf data_payment.Rows(0)("report_mark_type").ToString = "189" Then
                        'Close FGPO
                        Dim qry As String = "SELECT pd.`id_report`,pd.`report_mark_type`
FROM tb_pn_det pd
WHERE pd.balance_due=pd.`value` AND pd.`id_pn`='" & id_report & "'"
                        Dim dt As DataTable = execute_query(qry, -1, True, "", "", "", "")
                        '
                        For i As Integer = 0 To dt.Rows.Count - 1
                            If dt.Rows(i)("report_mark_type").ToString = "189" Then 'payment
                                Dim qc As String = "UPDATE tb_pn_fgpo 
                                                SET is_open='2'
                                                WHERE id_pn_fgpo='" & dt.Rows(i)("id_report").ToString & "'"
                                execute_non_query(qc, True, "", "", "", "")
                            ElseIf dt.Rows(i)("report_mark_type").ToString = "221" Then 'debit note
                                Dim qc As String = "UPDATE tb_debit_note 
                                                SET is_open='2'
                                                WHERE id_debit_note='" & dt.Rows(i)("id_report").ToString & "'"
                                execute_non_query(qc, True, "", "", "", "")
                                'update claim reject / late
                                Dim quc As String = "SELECT id_dn_type FROM tb_debit_note WHERE id_debit_note='" & dt.Rows(i)("id_report").ToString & "'"
                                Dim dtc As DataTable = execute_query(quc, -1, True, "", "", "", "")
                                If dtc.Rows(0)("id_dn_type").ToString = "1" Then 'claim reject
                                    query = String.Format("UPDATE tb_debit_note_det dnd
                                                        INNER JOIN tb_prod_order po ON po.id_prod_order=dnd.id_report AND dnd.report_mark_type='22' 
                                                        SET po.is_claimed_reject='1'
                                                        WHERE dnd.id_debit_note='{0}'", dt.Rows(i)("id_report").ToString)
                                    execute_non_query(query, True, "", "", "", "")
                                ElseIf dtc.Rows(0)("id_dn_type").ToString = "2" Then 'claim terlambat
                                    query = String.Format("UPDATE tb_debit_note_det dnd
                                                        INNER JOIN tb_prod_order_rec rec ON rec.id_prod_order_rec=dnd.id_report AND dnd.report_mark_type='28' 
                                                        SET rec.is_claimed_late='1'
                                                        WHERE dnd.id_debit_note='{0}'", dt.Rows(i)("id_report").ToString)
                                    execute_non_query(query, True, "", "", "", "")
                                End If
                            ElseIf dt.Rows(i)("report_mark_type").ToString = "231" Then 'inv mat
                                Dim qc As String = "UPDATE tb_inv_mat 
                                                SET is_open='2'
                                                WHERE id_inv_mat='" & dt.Rows(i)("id_report").ToString & "'"
                                execute_non_query(qc, True, "", "", "", "")
                            ElseIf dt.Rows(i)("report_mark_type").ToString = "280" Then 'inv mat
                                Dim qc As String = "UPDATE tb_inv_claim_other 
                                                SET is_open='2'
                                                WHERE id_inv_claim_other='" & dt.Rows(i)("id_report").ToString & "'"
                                execute_non_query(qc, True, "", "", "", "")
                            End If
                        Next
                        'FormBankWithdrawal.load_fgpo()
                    ElseIf data_payment.Rows(0)("report_mark_type").ToString = "223" Then
                        'close bpjs
                        execute_non_query("UPDATE tb_pay_bpjs_kesehatan SET is_close_pay = 1 WHERE id_pay_bpjs_kesehatan IN (SELECT id_report FROM tb_pn_det WHERE id_pn = " + id_report + ")", True, "", "", "", "")
                        'FormBankWithdrawal.view_bpjskesehatan()
                    ElseIf data_payment.Rows(0)("report_mark_type").ToString = "192" Then
                        'close thr
                        execute_non_query("UPDATE tb_emp_payroll SET is_close_pay = 1 WHERE id_payroll IN (SELECT id_report FROM tb_pn_det WHERE id_pn = " + id_report + ")", True, "", "", "", "")
                        'FormBankWithdrawal.view_thr()
                    ElseIf data_payment.Rows(0)("report_mark_type").ToString = "118" Or data_payment.Rows(0)("report_mark_type").ToString = "66" Then
                        'close CN
                        Dim qry As String = "SELECT pd.`id_report`,pd.`report_mark_type` 
FROM tb_pn_det pd
WHERE pd.balance_due=pd.`value` AND pd.`id_pn`='" & id_report & "'"
                        Dim dt As DataTable = execute_query(qry, -1, True, "", "", "", "")
                        '
                        For i As Integer = 0 To dt.Rows.Count - 1
                            If dt.Rows(i)("report_mark_type").ToString = "118" Or dt.Rows(i)("report_mark_type").ToString = "66" Or dt.Rows(i)("report_mark_type").ToString = "67" Then 'payment
                                Dim qc As String = "UPDATE tb_sales_pos 
                                                SET is_close_rec_payment='1'
                                                WHERE id_sales_pos='" & dt.Rows(i)("id_report").ToString & "';
                            -- update stt
                            UPDATE tb_ol_store_ret_list main
                            INNER JOIN (
                                SELECT spd.id_ol_store_ret_list
                                FROM tb_sales_pos sp 
                                INNER JOIN tb_sales_pos_det spd ON spd.id_sales_pos = sp.id_sales_pos
                                WHERE sp.id_sales_pos='" & dt.Rows(i)("id_report").ToString & "'
                                GROUP BY spd.id_ol_store_ret_list
                            ) src ON src.id_ol_store_ret_list = main.id_ol_store_ret_list
                            SET main.id_ol_store_ret_stt=3; 
                            -- update stt order
                            INSERT IGNORE INTO tb_sales_order_det_status(id_sales_order_det, `status`, `status_date`, `input_status_date`, is_internal)
                            SELECT rd.id_sales_order_det, stt.ol_store_ret_stt, NOW(), NOW(),1
                            FROM tb_sales_pos_det d
                            INNER JOIN tb_ol_store_ret_list rl ON rl.id_ol_store_ret_list = d.id_ol_store_ret_list
                            INNER JOIN tb_ol_store_ret_det rd ON rd.id_ol_store_ret_det = rl.id_ol_store_ret_det
                            JOIN tb_lookup_ol_store_ret_stt stt ON stt.id_ol_store_ret_stt=3
                            WHERE d.id_sales_pos='" & dt.Rows(i)("id_report").ToString & "'; "
                                execute_non_query(qc, True, "", "", "", "")
                            End If
                        Next
                    ElseIf data_payment.Rows(0)("report_mark_type").ToString = "247" Then
                        'close jamsostek
                        execute_non_query("UPDATE tb_emp_payroll SET is_close_pay_jamsostek = 1 WHERE id_payroll IN (SELECT id_report FROM tb_pn_det WHERE id_pn = " + id_report + ")", True, "", "", "", "")
                    ElseIf data_payment.Rows(0)("report_mark_type").ToString = "254" Then
                        'close SVS & CVS
                        Dim qv As String = "SELECT sb.* ,paid.*,IF(ABS(sb.comp_rev_normal+sb.comp_rev_sale)=ABS(paid.`val`),1,2) AS is_ok
FROM tb_sales_branch sb
LEFT JOIN
(
	SELECT pnd.id_report,SUM(pnd.`value`) val 
	FROM tb_pn_det pnd 
	INNER JOIN tb_pn pn ON (pn.id_report_status=6 OR pn.id_pn='" & id_report & "') AND pnd.id_pn=pn.id_pn 
	WHERE pnd.report_mark_type='254'
	GROUP BY id_report
)paid ON paid.id_report=sb.id_sales_branch
WHERE id_sales_branch IN (SELECT id_report FROM tb_pn_det WHERE id_pn='" & id_report & "' AND report_mark_type='254')"
                        Dim dtv As DataTable = execute_query(qv, -1, True, "", "", "", "")
                        If dtv.Rows.Count > 0 Then
                            If dtv.Rows(0)("is_ok").ToString = "1" Then
                                Dim qc As String = "UPDATE tb_sales_branch e
                                                SET e.is_close_bbk='1'
WHERE id_sales_branch ='" & dtv.Rows(0)("id_sales_branch").ToString & "' "
                                execute_non_query(qc, True, "", "", "", "")
                            End If
                        End If
                    ElseIf data_payment.Rows(0)("report_mark_type").ToString = "167" Then
                        'close cash advance
                        execute_non_query("UPDATE tb_cash_advance SET is_bbk = 1 WHERE id_cash_advance IN (SELECT id_report FROM tb_pn_det WHERE id_pn = " + id_report + ")", True, "", "", "", "")
                    End If
                    'check compen rmt 117 183 then close
                    Dim qce As String = "SELECT id_report FROM tb_pn_det WHERE id_pn='" & id_report & "' AND (report_mark_type='117' OR  report_mark_type='183')"
                    Dim dtce As DataTable = execute_query(qce, -1, True, "", "", "", "")
                    For i As Integer = 0 To dtce.Rows.Count - 1
                        Dim qe As String = "UPDATE tb_sales_pos SET is_close_rec_payment='1' WHERE id_sales_pos='" & dtce.Rows(i)("id_report").ToString & "'"
                        execute_non_query(qe, True, "", "", "", "")
                    Next
                    '
                    If data_payment.Rows(0)("is_buy_valas").ToString = "1" Then
                        'insert to stok valas/beli valas
                        Dim qi As String = "INSERT INTO tb_stock_valas(`id_report`,`report_mark_type`,id_valas_bank,`id_currency`,`amount`,`trans_datetime`,`kurs_transaksi`,`insert_datetime`)
SELECT pnd.`id_pn`,'159',pn.id_valas_bank,pnd.id_currency,pnd.val_bef_kurs,pn.date_payment,pnd.kurs,NOW()
FROM tb_pn_det pnd
INNER JOIN tb_pn pn ON pn.id_pn=pnd.id_pn
WHERE pnd.id_currency!=1 AND pnd.`id_pn`='" & id_report & "'"
                        execute_non_query(qi, True, "", "", "", "")
                    Else
                        Dim qi As String = "INSERT INTO tb_stock_valas(`id_report`,`report_mark_type`,id_valas_bank,`id_currency`,`amount`,`trans_datetime`,`kurs_transaksi`,`insert_datetime`)
SELECT pnd.`id_pn`,'159',pn.id_valas_bank,pnd.id_currency,-pnd.val_bef_kurs,pn.date_payment,pn.kurs,NOW()
FROM tb_pn_det pnd
INNER JOIN tb_pn pn ON pn.id_pn=pnd.id_pn
WHERE pnd.id_currency!=1 AND pnd.`id_pn`='" & id_report & "'"
                        execute_non_query(qi, True, "", "", "", "")
                    End If
                Else
                    qu = "UPDATE tb_pn SET is_tolakan='1' WHERE id_pn='" & id_report & "'"
                    execute_non_query(qu, True, "", "", "", "")
                End If
            End If

            'update
            query = String.Format("UPDATE tb_pn SET id_report_status='{0}' WHERE id_pn ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view

            'FormBankWithdrawal.load_payment()
            FormBankWithdrawalDet.form_load()
            'FormBankWithdrawal.GVList.FocusedRowHandle = find_row(FormBankWithdrawal.GVList, "id_pn", id_report)
        ElseIf report_mark_type = "160" Then
            'Asset management
            'auto completed
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            'update
            query = String.Format("UPDATE tb_purc_rec_asset SET is_active=1,id_report_status='{0}' WHERE id_purc_rec_asset ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            FormPurcAsset.viewPending()
        ElseIf report_mark_type = "162" Then
            'Receive Payment
            'auto completed
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            'completed
            If id_status_reportx = "6" Then
                'auto jurnal
                'Select user prepared
                Dim qu As String = "SELECT rm.id_user, rm.report_number FROM tb_report_mark rm WHERE rm.report_mark_type=" + report_mark_type + " AND rm.id_report='" + id_report + "' AND rm.id_report_status=1 "
                Dim du As DataTable = execute_query(qu, -1, True, "", "", "", "")
                Dim id_user_prepared As String = du.Rows(0)("id_user").ToString
                Dim report_number As String = du.Rows(0)("report_number").ToString


                If FormBankDepositDet.TETotal.EditValue > 0 Then 'BBM
                    'main journal
                    Dim date_reference As String = DateTime.Parse(FormBankDepositDet.DERecDate.EditValue.ToString).ToString("yyyy-MM-dd")
                    Dim date_created As String = DateTime.Parse(FormBankDepositDet.DEDateCreated.EditValue.ToString).ToString("yyyy-MM-dd")
                    Dim qjm As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, date_reference, acc_trans_note, id_report_status)
                        VALUES ('','" + report_number + "','21','" + id_user_prepared + "', '" + date_created + "','" + date_reference + "',  'Auto Posting', '6'); SELECT LAST_INSERT_ID(); "
                    Dim id_acc_trans As String = execute_query(qjm, 0, True, "", "", "", "")
                    execute_non_query("CALL gen_number(" + id_acc_trans + ",36)", True, "", "", "", "")

                    'det journal
                    Dim qjd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, id_comp, qty, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number, report_mark_type_ref, id_report_ref, report_number_ref, vendor, id_coa_tag)
                    SELECT '" & id_acc_trans & "' AS id_acc_trans,py.id_acc_pay_rec AS `id_acc`, cc.id_comp,  0 AS `qty`,
                    py.value AS `debit`, 0 AS `credit`,
                    py.note AS `note`,162,py.id_rec_payment, py.number, NULL, NULL, NULL, '' AS `vendor`, py.id_coa_tag
                    FROM tb_rec_payment py
                    INNER JOIN tb_coa_tag ct ON ct.id_coa_tag = py.id_coa_tag
                    INNER JOIN tb_m_comp cc ON cc.id_comp = ct.id_comp
                    WHERE py.id_rec_payment=" + id_report + " AND py.`value` > 0
                    UNION ALL
                    SELECT '" & id_acc_trans & "' AS id_acc_trans,pyd.id_acc AS `id_acc`, pyd.id_comp,0 AS `qty`, 
                    IF(pyd.id_dc=1, ABS(pyd.value), 0) AS `debit`, IF(pyd.id_dc=2, pyd.value, 0) AS `credit`,
                    pyd.note AS `note`, 
                    162, py.id_rec_payment, py.number,
                    pyd.report_mark_type, pyd.id_report, pyd.number, pyd.vendor, py.id_coa_tag
                    FROM tb_rec_payment_det pyd
                    INNER JOIN tb_rec_payment py ON py.id_rec_payment = pyd.id_rec_payment
                    INNER JOIN tb_lookup_dc dc ON dc.id_dc = pyd.id_dc
                    INNER JOIN tb_a_acc a ON a.id_acc = pyd.id_acc
                    LEFT JOIN tb_m_comp comp ON comp.id_comp = pyd.id_comp
                    WHERE pyd.id_rec_payment=" + id_report + " "
                    execute_non_query(qjd, True, "", "", "", "")
                Else 'BBK
                    'UNION ALL
                    '-- lebih bayar keluar berapa dari mana credit
                    'Select '" & id_acc_trans & "' AS id_acc_trans,py.id_acc_pay_to AS `id_acc`, cc.id_comp,  0 AS `qty`,0 AS `debit`, py.`val_need_pay` AS `credit`,'' AS `note`,162,py.id_rec_payment, py.number
                    'From tb_rec_payment py
                    'INNER Join tb_m_comp_contact cc ON cc.id_comp_contact = py.id_comp_contact
                    'WHERE py.id_rec_payment = " & id_report & " And py.`val_need_pay` > 0
                    ' -- tambah piutang (AR) debit => credit note
                    'Select Case'" & id_acc_trans & "' AS id_acc_trans,comp.id_acc_ar AS `id_acc`, cc.id_comp,  0 AS `qty`,py.`val_need_pay` AS `debit`, 0 AS `credit`,'' AS `note`,162,py.id_rec_payment, py.number
                    'From tb_rec_payment py
                    'INNER Join tb_m_comp_contact cc ON cc.id_comp_contact = py.id_comp_contact
                    'INNER Join tb_m_comp comp ON comp.id_comp=cc.id_comp
                    'WHERE py.id_rec_payment = " & id_report & " And py.`val_need_pay` > 0
                End If

                'close if complete rec
                If FormBankDepositDet.type_rec = "1" Then
                    'INVOICE PENJUALAN
                    Dim qjd_upd = "/*closing invoice*/
                    UPDATE tb_sales_pos pos
                    INNER JOIN tb_rec_payment_det pyd ON pyd.`id_report`=pos.`id_sales_pos` AND pyd.`report_mark_type`=pos.`report_mark_type`
                    SET pos.`is_close_rec_payment`=1
                    WHERE pyd.`id_rec_payment`='" & id_report & "'
                    AND pyd.`value`=balance_due;
                    /*closing invoice ship*/
                    UPDATE tb_invoice_ship ps
                    INNER JOIN tb_rec_payment_det pyd ON pyd.`id_report`=ps.id_invoice_ship AND pyd.`report_mark_type`=ps.`report_mark_type`
                    SET ps.`is_close_rec`=1
                    WHERE pyd.`id_rec_payment`='" & id_report & "';
                    /*updayte eval AR*/
                    UPDATE tb_ar_eval main
                    INNER JOIN (
	                    SELECT sp.id_sales_pos, rd.id_rec_payment
	                    FROM tb_rec_payment_det rd
	                    INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = rd.id_report AND sp.is_close_rec_payment=1
	                    WHERE rd.id_rec_payment=" + id_report + "
                    ) src ON src.id_sales_pos = main.id_sales_pos
                    SET main.is_paid=1, main.release_date=NOW(), main.id_rec_payment = src.id_rec_payment, main.is_active=2
                    WHERE main.is_active=1; "
                    execute_non_query(qjd_upd, True, "", "", "", "")

                    '=== checking release hanya utk keperluan email
                    'check apakah invoice yang di BBM ada di evaluasi ato tidak
                    Dim query_in_evaluation As String = "SELECT rd.id_rec_payment_det, c.id_comp_group
                    FROM tb_rec_payment_det rd
                    INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = rd.id_report
                    INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
                    INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
                    LEFT JOIN (
	                    SELECT e.id_sales_pos, e.id_ar_eval
	                    FROM tb_ar_eval e 
	                    WHERE e.eval_date IN (SELECT MAX(e.eval_date)  FROM tb_ar_eval e) AND ISNULL(e.id_propose_delay_payment_det)
                    ) e ON e.id_sales_pos = rd.id_report
                    WHERE rd.id_rec_payment=" + id_report + " AND !ISNULL(e.id_ar_eval) "
                    Dim data_in_evaluation As DataTable = execute_query(query_in_evaluation, -1, True, "", "", "", "")
                    If data_in_evaluation.Rows.Count > 0 Then
                        'jika ada cek apakah  ada email release ato tidak
                        Dim dtg As DataTable = data_in_evaluation.DefaultView.ToTable(True, "id_comp_group")
                        Dim id_comp_group As String = ""
                        For i As Integer = 0 To dtg.Rows.Count - 1
                            If i > 0 Then
                                id_comp_group += ","
                            End If
                            id_comp_group += dtg.Rows(i)("id_comp_group").ToString
                        Next

                        Dim ev As New ClassAREvaluation()
                        Dim data_cek_email_release As DataTable = ev.dtCekEmailRelease(id_comp_group)
                        If data_cek_email_release.Rows.Count > 0 Then
                            'jika ada yg dibayar semua maka kirim email
                            Dim mm As New ClassMailManage()
                            Dim id_mail As String = "-1"
                            Dim mail_subject As String = get_setup_field("mail_subject_release_del")
                            Dim mail_title As String = get_setup_field("mail_title_release_del")
                            Dim mail_content As String = get_setup_field("mail_content_release_del")
                            Dim query_mail_content_to As String = "SELECT CONCAT(e.employee_name, ' (',e.employee_position,')') AS `to_content_mail`
                                FROM tb_opt o
                                INNER JOIN tb_m_employee e ON e.id_employee = o.id_emp_wh_manager "
                            Dim mail_content_to As String = execute_query(query_mail_content_to, 0, True, "", "", "", "")

                            'send paramenter class
                            mm.rmt = report_mark_type
                            mm.mail_subject = mail_subject
                            mm.mail_title = mail_title
                            mm.par1 = id_comp_group
                            mm.rmt = "230"
                            mm.createEmail("-1", id_user, id_report, report_mark_type, report_number)
                            id_mail = mm.id_mail_manage

                            'email rep address
                            Dim query_email_rep As String = "INSERT INTO tb_mail_manage_member(id_mail_manage, id_mail_member_type, id_user, id_comp_contact, mail_address)
                            SELECT " + id_mail + " AS `id_mail_manage`, m.id_mail_member_type, m.id_user, NULL AS `id_comp_contact`, e.email_external AS `mail_address`
                            FROM tb_mail_manage_mapping_intern m
                            INNER JOIN tb_m_user u ON u.id_user = m.id_user
                            INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
                            WHERE m.report_mark_type=228 AND 
                            m.id_comp_group IN (" + id_comp_group + ") "
                            execute_non_query(query_email_rep, True, "", "", "", "")

                            'email
                            Try
                                Dim em As New ClassSendEmail()
                                em.report_mark_type = "230"
                                em.id_report = id_mail
                                em.design_code = mail_title
                                em.design = mail_subject
                                em.comment_by = mail_content_to
                                em.comment = mail_content
                                em.dt = mm.getDetailData
                                em.send_email()

                                Dim query_log As String = mm.queryInsertLog(id_user, "2", "Sent Successfully")
                                execute_non_query(query_log, True, "", "", "", "")
                            Catch ex As Exception
                                Dim query_log As String = mm.queryInsertLog(id_user, "3", addSlashes(ex.ToString))
                                execute_non_query(query_log, True, "", "", "", "")
                            End Try
                        End If
                    End If
                ElseIf FormBankDepositDet.type_rec = "3" Then
                    'penjualan toko volcom
                    Dim qjd_upd = "/*closing invoice*/
                    UPDATE tb_sales_branch_det d
                    INNER JOIN tb_rec_payment_det pyd ON pyd.id_report_det = d.id_sales_branch_det AND pyd.report_mark_type=254
                    SET d.is_close=1
                    WHERE pyd.id_rec_payment = '" + id_report + "' AND pyd.`value`=balance_due AND pyd.`value`!= 0; "
                    execute_non_query(qjd_upd, True, "", "", "", "")
                ElseIf FormBankDepositDet.type_rec = "4" Then
                    'penjualan fixed asset
                    Dim qjd_upd = "UPDATE tb_purc_rec_asset_disp d
                    INNER JOIN tb_rec_payment_det pyd ON pyd.id_report = d.id_purc_rec_asset_disp AND pyd.report_mark_type=298
                    SET d.is_rec_payment=1
                    WHERE pyd.id_rec_payment = '" + id_report + "'; "
                    execute_non_query(qjd_upd, True, "", "", "", "")
                End If

                'insert valas
                Dim qiv As String = "INSERT INTO tb_stock_valas(`id_report`,`report_mark_type`,id_valas_bank,`id_currency`,`amount`,`trans_datetime`,`kurs_transaksi`,`insert_datetime`)
SELECT recd.id_rec_payment,'162',rec.id_valas_bank,2,recd.value_bef_kurs,rec.date_received,rec.kurs,NOW()
FROM tb_rec_payment_det recd
INNER JOIN tb_rec_payment rec ON rec.id_rec_payment=recd.id_rec_payment
WHERE kurs>1 AND recd.`id_rec_payment`='" & id_report & "'"
                execute_non_query(qiv, True, "", "", "", "")
            End If

            'update
            query = String.Format("UPDATE tb_rec_payment SET id_report_status='{0}' WHERE id_rec_payment ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            FormBankDepositDet.form_load()
            Try
                FormBankDeposit.load_deposit()
                FormBankDeposit.GVList.FocusedRowHandle = find_row(FormBankWithdrawal.GVList, "id_payment", id_report)
                FormBankDeposit.load_invoice()
            Catch ex As Exception

            End Try
        ElseIf report_mark_type = "237" Then
            'Tabungan Missing
            'auto completed
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            'completed
            If id_status_reportx = "6" Then
                'auto jurnal
                'Select user prepared
                Dim qu As String = "SELECT rm.id_user, rm.report_number FROM tb_report_mark rm WHERE rm.report_mark_type=" + report_mark_type + " AND rm.id_report='" + id_report + "' AND rm.id_report_status=1 "
                Dim du As DataTable = execute_query(qu, -1, True, "", "", "", "")
                Dim id_user_prepared As String = du.Rows(0)("id_user").ToString
                Dim report_number As String = du.Rows(0)("report_number").ToString


                If FormPaymentMissingDet.TETotal.EditValue > 0 Then 'BBM
                    'main journal
                    Dim date_reference As String = DateTime.Parse(FormPaymentMissingDet.DERecDate.EditValue.ToString).ToString("yyyy-MM-dd")
                    Dim date_created As String = DateTime.Parse(FormPaymentMissingDet.DEDateCreated.EditValue.ToString).ToString("yyyy-MM-dd")
                    Dim qjm As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, date_reference, acc_trans_note, id_report_status)
                        VALUES ('','" + report_number + "','25','" + id_user_prepared + "', '" + date_created + "','" + date_reference + "',  'Auto Posting', '6'); SELECT LAST_INSERT_ID(); "
                    Dim id_acc_trans As String = execute_query(qjm, 0, True, "", "", "", "")
                    execute_non_query("CALL gen_number(" + id_acc_trans + ",36)", True, "", "", "", "")

                    'det journal
                    Dim qjd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, id_comp, qty, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number, report_mark_type_ref, id_report_ref, report_number_ref, vendor)
                    SELECT '" & id_acc_trans & "' AS id_acc_trans,py.id_acc_pay_rec AS `id_acc`, 1,  0 AS `qty`,
                    py.value AS `debit`, 0 AS `credit`,
                    py.note AS `note`," + report_mark_type + ",py.id_missing_payment, py.number, NULL, NULL, NULL, '' AS `vendor`
                    FROM tb_missing_payment py
                    WHERE py.id_missing_payment=" + id_report + " AND py.`value` > 0
                    UNION ALL
                    SELECT '" & id_acc_trans & "' AS id_acc_trans,pyd.id_acc AS `id_acc`, pyd.id_comp,0 AS `qty`, 
                    IF(pyd.id_dc=1, ABS(pyd.value), 0) AS `debit`, IF(pyd.id_dc=2, pyd.value, 0) AS `credit`,
                    pyd.note AS `note`, 
                    " + report_mark_type + ", py.id_missing_payment, py.number,
                    pyd.report_mark_type, pyd.id_report, pyd.number, pyd.vendor
                    FROM tb_missing_payment_det pyd
                    INNER JOIN tb_missing_payment py ON py.id_missing_payment = pyd.id_missing_payment
                    INNER JOIN tb_lookup_dc dc ON dc.id_dc = pyd.id_dc
                    INNER JOIN tb_a_acc a ON a.id_acc = pyd.id_acc
                    LEFT JOIN tb_m_comp comp ON comp.id_comp = pyd.id_comp
                    WHERE pyd.id_missing_payment=" + id_report + " "
                    execute_non_query(qjd, True, "", "", "", "")
                Else 'BBK
                    'UNION ALL
                    '-- lebih bayar keluar berapa dari mana credit
                    'Select '" & id_acc_trans & "' AS id_acc_trans,py.id_acc_pay_to AS `id_acc`, cc.id_comp,  0 AS `qty`,0 AS `debit`, py.`val_need_pay` AS `credit`,'' AS `note`," + report_mark_type + ",py.id_rec_payment, py.number
                    'From tb_missing_payment py
                    'INNER Join tb_m_comp_contact cc ON cc.id_comp_contact = py.id_comp_contact
                    'WHERE py.id_rec_payment = " & id_report & " And py.`val_need_pay` > 0
                    ' -- tambah piutang (AR) debit => credit note
                    'Select Case'" & id_acc_trans & "' AS id_acc_trans,comp.id_acc_ar AS `id_acc`, cc.id_comp,  0 AS `qty`,py.`val_need_pay` AS `debit`, 0 AS `credit`,'' AS `note`," + report_mark_type + ",py.id_rec_payment, py.number
                    'From tb_missing_payment py
                    'INNER Join tb_m_comp_contact cc ON cc.id_comp_contact = py.id_comp_contact
                    'INNER Join tb_m_comp comp ON comp.id_comp=cc.id_comp
                    'WHERE py.id_rec_payment = " & id_report & " And py.`val_need_pay` > 0
                End If

                'close if complete rec
                If FormPaymentMissingDet.type_rec = "1" Then
                    'INVOICE PENJUALAN
                    Dim qjd_upd = "/*closing invoice*/
                    UPDATE tb_sales_pos pos
                    INNER JOIN tb_missing_payment_det pyd ON pyd.`id_report`=pos.`id_sales_pos` AND pyd.`report_mark_type`=pos.`report_mark_type`
                    SET pos.`is_close_rec_payment`=1
                    WHERE pyd.`id_missing_payment`='" & id_report & "'
                    AND pyd.`value`=balance_due AND pyd.`value` != 0;
                    /*updayte eval AR*/
                    UPDATE tb_ar_eval main
                    INNER JOIN (
                     SELECT sp.id_sales_pos, rd.id_missing_payment
                     FROM tb_missing_payment_det rd
                     INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = rd.id_report AND sp.is_close_rec_payment=1
                     WHERE rd.id_missing_payment=" + id_report + "
                    ) src ON src.id_sales_pos = main.id_sales_pos
                    SET main.is_paid=1, main.release_date=NOW(), main.id_rec_payment = src.id_missing_payment, main.is_active=2
                    WHERE main.is_active=1; "
                    execute_non_query(qjd_upd, True, "", "", "", "")

                    '=== checking release hanya utk keperluan email
                    'check apakah invoice yang di BBM ada di evaluasi ato tidak
                    Dim query_in_evaluation As String = "SELECT rd.id_missing_payment_det, c.id_comp_group
                    FROM tb_missing_payment_det rd
                    INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = rd.id_report
                    INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
                    INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
                    LEFT JOIN (
                     SELECT e.id_sales_pos, e.id_ar_eval
                     FROM tb_ar_eval e 
                     WHERE e.eval_date IN (SELECT MAX(e.eval_date)  FROM tb_ar_eval e)
                    ) e ON e.id_sales_pos = rd.id_report
                    WHERE rd.id_missing_payment=" + id_report + " AND !ISNULL(e.id_ar_eval) "
                    Dim data_in_evaluation As DataTable = execute_query(query_in_evaluation, -1, True, "", "", "", "")
                    If data_in_evaluation.Rows.Count > 0 Then
                        'jika ada cek apakah  ada email release ato tidak
                        Dim dtg As DataTable = data_in_evaluation.DefaultView.ToTable(True, "id_comp_group")
                        Dim id_comp_group As String = ""
                        For i As Integer = 0 To dtg.Rows.Count - 1
                            If i > 0 Then
                                id_comp_group += ","
                            End If
                            id_comp_group += dtg.Rows(i)("id_comp_group").ToString
                        Next

                        Dim ev As New ClassAREvaluation()
                        Dim data_cek_email_release As DataTable = ev.dtCekEmailRelease(id_comp_group)
                        If data_cek_email_release.Rows.Count > 0 Then
                            'jika ada yg dibayar semua maka kirim email
                            Dim mm As New ClassMailManage()
                            Dim id_mail As String = "-1"
                            Dim mail_subject As String = get_setup_field("mail_subject_release_del")
                            Dim mail_title As String = get_setup_field("mail_title_release_del")
                            Dim mail_content As String = get_setup_field("mail_content_release_del")
                            Dim query_mail_content_to As String = "SELECT CONCAT(e.employee_name, ' (',e.employee_position,')') AS `to_content_mail`
                                FROM tb_opt o
                                INNER JOIN tb_m_employee e ON e.id_employee = o.id_emp_wh_manager "
                            Dim mail_content_to As String = execute_query(query_mail_content_to, 0, True, "", "", "", "")

                            'send paramenter class
                            mm.rmt = report_mark_type
                            mm.mail_subject = mail_subject
                            mm.mail_title = mail_title
                            mm.par1 = id_comp_group
                            mm.rmt = "230"
                            mm.createEmail("-1", id_user, id_report, report_mark_type, report_number)
                            id_mail = mm.id_mail_manage

                            'email rep address
                            Dim query_email_rep As String = "INSERT INTO tb_mail_manage_member(id_mail_manage, id_mail_member_type, id_user, id_comp_contact, mail_address)
                            SELECT " + id_mail + " AS `id_mail_manage`, m.id_mail_member_type, m.id_user, NULL AS `id_comp_contact`, e.email_external AS `mail_address`
                            FROM tb_mail_manage_mapping_intern m
                            INNER JOIN tb_m_user u ON u.id_user = m.id_user
                            INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
                            WHERE m.report_mark_type=228 AND 
                            m.id_comp_group IN (" + id_comp_group + ") "
                            execute_non_query(query_email_rep, True, "", "", "", "")

                            'email
                            Try
                                Dim em As New ClassSendEmail()
                                em.report_mark_type = "230"
                                em.id_report = id_mail
                                em.design_code = mail_title
                                em.design = mail_subject
                                em.comment_by = mail_content_to
                                em.comment = mail_content
                                em.dt = mm.getDetailData
                                em.send_email()

                                Dim query_log As String = mm.queryInsertLog(id_user, "2", "Sent Successfully")
                                execute_non_query(query_log, True, "", "", "", "")
                            Catch ex As Exception
                                Dim query_log As String = mm.queryInsertLog(id_user, "3", addSlashes(ex.ToString))
                                execute_non_query(query_log, True, "", "", "", "")
                            End Try
                        End If
                    End If
                End If
            End If

            'update
            query = String.Format("UPDATE tb_missing_payment SET id_report_status='{0}' WHERE id_missing_payment ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            FormPaymentMissingDet.form_load()
        ElseIf report_mark_type = "167" Then
            'Cash Advance
            'auto completed
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                'Select user prepared
                Dim qu As String = "SELECT rm.id_user, rm.report_number FROM tb_report_mark rm WHERE rm.report_mark_type=" + report_mark_type + " AND rm.id_report='" + id_report + "' AND rm.id_report_status=1 "
                Dim du As DataTable = execute_query(qu, -1, True, "", "", "", "")
                Dim id_user_prepared As String = du.Rows(0)("id_user").ToString
                Dim report_number As String = du.Rows(0)("report_number").ToString

                'main journal
                Dim qjm As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, acc_trans_note, id_report_status)
                        VALUES ('','" + report_number + "','7','" + id_user_prepared + "', NOW(), 'Auto Posting', '6'); SELECT LAST_INSERT_ID(); "
                Dim id_acc_trans As String = execute_query(qjm, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id_acc_trans + ",36)", True, "", "", "", "")

                'det journal
                Dim qjd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, id_comp, qty, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number)
                                    -- kas keluar
                                    SELECT '" & id_acc_trans & "' AS id_acc_trans,ca.id_acc_from AS `id_acc`, 1,  0 AS `qty`,0 AS `debit`, ca.val_ca AS `credit`,ca.note,167,ca.id_cash_advance, ca.number
                                    FROM tb_cash_advance ca
                                    WHERE ca.id_cash_advance=" & id_report & " AND ca.`val_ca` <> 0
                                    UNION ALL
                                    -- cash advance
                                    SELECT '" & id_acc_trans & "' AS id_acc_trans,ca.id_acc_to AS `id_acc`, 1,  0 AS `qty`,ca.val_ca AS `debit`, 0 AS `credit`,ca.note,167,ca.id_cash_advance, ca.number
                                    FROM tb_cash_advance ca
                                    WHERE ca.id_cash_advance=" & id_report & " AND ca.`val_ca` <> 0"
                execute_non_query(qjd, True, "", "", "", "")
            End If

            'update
            query = String.Format("UPDATE tb_cash_advance SET id_report_status='{0}' WHERE id_cash_advance ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            FormCashAdvance.load_cash_advance()
        ElseIf report_mark_type = "168" Then
            'Receive Return
            'auto completed
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            'update
            query = String.Format("UPDATE tb_sales_return_rec SET id_report_status='{0}' WHERE id_sales_return_rec ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            FormSalesReturnRec.load_list()
        ElseIf report_mark_type = "169" Then
            'Asset value-added
            'auto completed
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            'value added
            If id_status_reportx = "6" Then
                Dim id_asset As String = ""
                Dim val_added As String = ""
                Dim val_added_month As String = ""

                Dim qs As String = "SELECT added_month,added_value,id_purc_rec_asset FROM id_purc_rec_asset_kap='" & id_report & "'"
                Dim dts As DataTable = execute_query(qs, -1, True, "", "", "", "")
                If dts.Rows.Count > 0 Then
                    id_asset = dts.Rows(0)("id_purc_rec_asset").ToString
                    val_added = decimalSQL(dts.Rows(0)("added_value").ToString)
                    val_added_month = decimalSQL(dts.Rows(0)("added_month").ToString)
                End If

                execute_non_query("UPDATE tb_purc_rec_asset SET value_added=(value_added+" & val_added & "),month_added=(month_added+" & val_added_month & ") WHERE id_purc_rec_asset='" & id_asset & "'", True, "", "", "", "")
            End If

            'update
            query = String.Format("UPDATE tb_purc_rec_asset_kap SET id_report_status='{0}' WHERE id_purc_rec_asset ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            FormPurcAsset.viewActive()
            FormPurcAssetValueAddedList.viewData()
        ElseIf report_mark_type = "174" Then
            'Cash Advance Reconcile
            'auto completed
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                'Select user prepared
                Dim qu As String = "SELECT rm.id_user, rm.report_number FROM tb_report_mark rm WHERE rm.report_mark_type=" + report_mark_type + " AND rm.id_report='" + id_report + "' AND rm.id_report_status=1 "
                Dim du As DataTable = execute_query(qu, -1, True, "", "", "", "")
                Dim id_user_prepared As String = du.Rows(0)("id_user").ToString
                Dim report_number As String = du.Rows(0)("report_number").ToString

                'main journal
                Dim id_bill_type As String = execute_query("SELECT IFNULL((SELECT id_bill_type FROM tb_cash_advance_report_det WHERE id_cash_advance = " + id_report + "), 7) AS id_bill_type", 0, True, "", "", "", "")

                If id_bill_type = "22" Then
                    id_bill_type = "7"
                End If

                If id_bill_type = "21" Then
                    id_bill_type = "8"
                End If

                Dim qjm As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, acc_trans_note, id_report_status)
                        VALUES ('','" + report_number + "','" + id_bill_type + "','" + id_user_prepared + "', NOW(), 'Auto Posting', '6'); SELECT LAST_INSERT_ID(); "
                Dim id_acc_trans As String = execute_query(qjm, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id_acc_trans + ",36)", True, "", "", "", "")

                'det journal
                Dim qjd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, id_comp, qty, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number)
                                    -- cash advance
                                    SELECT '" & id_acc_trans & "' AS id_acc_trans,ca.id_acc_to AS `id_acc`, 1,  0 AS `qty`,0 AS `debit`,ca.val_ca AS `credit`,ca.note AS `note`,174,ca.id_cash_advance,ca.number
                                    FROM tb_cash_advance ca
                                    WHERE ca.id_cash_advance=" & id_report & " AND ca.`val_ca` <> 0
                                    -- detail
                                    UNION ALL
                                    SELECT '" & id_acc_trans & "' AS id_acc_trans,car.id_acc AS `id_acc`, car.id_comp,  0 AS `qty`, car.value AS `debit`,0  AS `credit`,car.description AS `note`,174,ca.id_cash_advance,ca.number
                                    FROM tb_cash_advance ca
                                    INNER JOIN tb_cash_advance_report car ON ca.id_cash_advance = car.id_cash_advance
                                    WHERE ca.id_cash_advance=" & id_report & " AND car.`value` <> 0
                                    --
                                    UNION ALL
                                    SELECT '" & id_acc_trans & "' AS id_acc_trans,card.id_acc AS `id_acc`, 1,  0 AS `qty`, IF(card.id_bill_type = 21, card.value, 0) AS `debit`, IF(card.id_bill_type = 21, 0, card.value)  AS `credit`,card.description AS `note`,174,ca.id_cash_advance,ca.number
                                    FROM tb_cash_advance ca
                                    INNER JOIN tb_cash_advance_report_det card ON ca.id_cash_advance = card.id_cash_advance
                                    WHERE ca.id_cash_advance=" & id_report & " AND card.`value` <> 0
                                    -- pph
                                    UNION ALL
                                    SELECT '" & id_acc_trans & "' AS id_acc_trans,car.pph_coa AS `id_acc`, car.id_comp,  0 AS `qty`, 0 AS `debit`,car.pph_amount  AS `credit`,car.description AS `note`,174,ca.id_cash_advance,ca.number
                                    FROM tb_cash_advance ca
                                    INNER JOIN tb_cash_advance_report car ON ca.id_cash_advance = car.id_cash_advance
                                    WHERE ca.id_cash_advance=" & id_report & " AND car.`pph_amount` <> 0
                                    -- ppn
                                    UNION ALL
                                    (SELECT '" & id_acc_trans & "' AS id_acc_trans,car.ppn_coa AS `id_acc`, car.id_comp,  0 AS `qty`, SUM(car.ppn_amount) AS `debit`,0  AS `credit`,car.description AS `note`,174,ca.id_cash_advance,ca.number
                                    FROM tb_cash_advance ca
                                    INNER JOIN tb_cash_advance_report car ON ca.id_cash_advance = car.id_cash_advance
                                    WHERE ca.id_cash_advance=" & id_report & " AND car.`ppn_amount` <> 0 GROUP BY ppn_coa)"
                execute_non_query(qjd, True, "", "", "", "")
            End If

            'update
            query = String.Format("UPDATE tb_cash_advance SET rb_id_report_status='{0}' WHERE id_cash_advance ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            FormCashAdvanceReconcile.load_det()
        ElseIf report_mark_type = "175" Then
            'item request
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then 'complete update/insert budget
                'cek type first
                Dim query_pps As String = "SELECT id_type FROM tb_sample_budget_pps WHERE id_sample_budget_pps ='" & id_report & "'"
                Dim data_pps As DataTable = execute_query(query_pps, -1, True, "", "", "", "")
                If data_pps.Rows.Count > 0 Then
                    If data_pps.Rows(0)("id_type").ToString = "1" Then 'propose new
                        Dim query_det As String = "SELECT ppsd.`id_sample_budget_pps_det`,ppsd.`description_after`,ppsd.`year_after`,ppsd.`value_rp_after`,ppsd.`value_usd_after`,ppsd.`kurs_after`
FROM `tb_sample_budget_pps` pps
INNER JOIN tb_sample_budget_pps_det ppsd ON ppsd.id_sample_budget_pps=pps.id_sample_budget_pps
WHERE pps.id_sample_budget_pps='" & id_report & "'"
                        Dim data_det As DataTable = execute_query(query_det, -1, True, "", "", "", "")
                        For i As Integer = 0 To data_det.Rows.Count - 1
                            'insert budget
                            Dim ins_det As String = "INSERT INTO `tb_sample_purc_budget`(description,`year`,value_rp,value_usd,kurs)
VALUES('" & data_det.Rows(i)("description_after").ToString & "','" & data_det.Rows(i)("year_after").ToString & "','" & decimalSQL(data_det.Rows(i)("value_rp_after").ToString) & "','" & decimalSQL(data_det.Rows(i)("value_usd_after").ToString) & "','" & decimalSQL(data_det.Rows(i)("kurs_after").ToString) & "');
SELECT LAST_INSERT_ID(); "
                            Dim id_det As String = execute_query(ins_det, 0, True, "", "", "", "")
                            'insert division
                            Dim ins_div As String = "INSERT INTO `tb_sample_purc_budget_div`(id_sample_purc_budget,id_code_division)
SELECT '" & id_det & "' AS id_det,id_code_division FROM tb_sample_budget_pps_div WHERE id_sample_budget_pps_det='" & data_det.Rows(i)("id_sample_budget_pps_det").ToString & "' AND is_after='1'"
                            execute_non_query(ins_div, True, "", "", "", "")
                        Next
                    Else 'revision
                        Dim query_det As String = "SELECT ppsd.`id_sample_budget_pps_det`,ppsd.`id_sample_purc_budget`,ppsd.`description_after`,ppsd.`year_after`,ppsd.`value_rp_after`,ppsd.`value_usd_after`,ppsd.`kurs_after`
FROM `tb_sample_budget_pps` pps
INNER JOIN tb_sample_budget_pps_det ppsd ON ppsd.id_sample_budget_pps=pps.id_sample_budget_pps
WHERE pps.id_sample_budget_pps='" & id_report & "'"
                        Dim data_det As DataTable = execute_query(query_det, -1, True, "", "", "", "")
                        For i As Integer = 0 To data_det.Rows.Count - 1
                            'update budget
                            Dim upd_det As String = "UPDATE tb_sample_purc_budget SET description='" & data_det.Rows(i)("description_after").ToString & "',`year`='" & data_det.Rows(i)("year_after").ToString & "',value_rp='" & decimalSQL(data_det.Rows(i)("value_rp_after").ToString) & "',value_usd='" & decimalSQL(data_det.Rows(i)("value_usd_after").ToString) & "',kurs='" & decimalSQL(data_det.Rows(i)("kurs_after").ToString) & "' WHERE id_sample_purc_budget='" & data_det.Rows(i)("id_sample_purc_budget").ToString & "'"
                            execute_non_query(upd_det, True, "", "", "", "")
                            'delete + insert division
                            Dim upd_div As String = "DELETE FROM tb_sample_purc_budget_div WHERE id_sample_purc_budget='" & data_det.Rows(i)("id_sample_purc_budget").ToString & "';
INSERT INTO `tb_sample_purc_budget_div`(id_sample_purc_budget,id_code_division)
SELECT '" & data_det.Rows(i)("id_sample_purc_budget").ToString & "' AS id_det,id_code_division FROM tb_sample_budget_pps_div WHERE id_sample_budget_pps_det='" & data_det.Rows(i)("id_sample_budget_pps_det").ToString & "' AND is_after='1';"
                            execute_non_query(upd_div, True, "", "", "", "")
                        Next
                    End If
                End If
            End If

            'update
            query = String.Format("UPDATE tb_sample_budget_pps SET id_report_status='{0}' WHERE id_sample_budget_pps ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            'FormSampleBudget.load_propose()
            'FormSampleBudget.load_budget()
        ElseIf report_mark_type = "176" Or report_mark_type = "177" Or report_mark_type = "178" Then
            'Propose Design Changes
            'auto completed
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            'update tb_m_design & tb_m_design_code
            If id_status_reportx = "6" Then
                Dim query_changes As String = ""

                '--tb_m_design
                Dim data_dr As DataTable = execute_query("SELECT * FROM tb_m_design_rev WHERE id_design_rev = '" + id_report + "'", -1, True, "", "", "", "")
                Dim data_hs As DataTable = execute_query("SELECT * FROM tb_m_design_his WHERE id_design_rev = '" + id_report + "'", -1, True, "", "", "", "")

                'check changes
                If Not data_dr.Rows(0)("design_name").ToString = data_hs.Rows(0)("design_name").ToString Then
                    query_changes += "design_name = '" + data_dr.Rows(0)("design_name").ToString + "'"
                End If

                If Not data_dr.Rows(0)("design_code").ToString = data_hs.Rows(0)("design_code").ToString Then
                    If Not query_changes = "" Then
                        query_changes += ", "
                    End If

                    query_changes += "design_code = '" + data_dr.Rows(0)("design_code").ToString + "'"
                End If

                If Not data_dr.Rows(0)("design_code_import").ToString = data_hs.Rows(0)("design_code_import").ToString Then
                    If Not query_changes = "" Then
                        query_changes += ", "
                    End If

                    query_changes += "design_code_import = '" + data_dr.Rows(0)("design_code_import").ToString + "'"
                End If

                If Not data_dr.Rows(0)("id_delivery").ToString = data_hs.Rows(0)("id_delivery").ToString Then
                    If Not query_changes = "" Then
                        query_changes += ", "
                    End If

                    query_changes += "id_delivery = '" + data_dr.Rows(0)("id_delivery").ToString + "'"
                End If

                If Not data_dr.Rows(0)("id_delivery_act").ToString = data_hs.Rows(0)("id_delivery_act").ToString Then
                    If Not query_changes = "" Then
                        query_changes += ", "
                    End If

                    query_changes += "id_delivery_act = '" + data_dr.Rows(0)("id_delivery_act").ToString + "'"
                End If

                If Not data_dr.Rows(0)("design_display_name").ToString = data_hs.Rows(0)("design_display_name").ToString Then
                    If Not query_changes = "" Then
                        query_changes += ", "
                    End If

                    query_changes += "design_display_name = '" + addSlashes(data_dr.Rows(0)("design_display_name").ToString) + "'"
                End If

                If Not data_dr.Rows(0)("id_season").ToString = data_hs.Rows(0)("id_season").ToString Then
                    If Not query_changes = "" Then
                        query_changes += ", "
                    End If

                    query_changes += "id_season = '" + data_dr.Rows(0)("id_season").ToString + "'"
                End If

                If Not data_dr.Rows(0)("id_season_orign").ToString = data_hs.Rows(0)("id_season_orign").ToString Then
                    If Not query_changes = "" Then
                        query_changes += ", "
                    End If

                    query_changes += "id_season_orign = '" + data_dr.Rows(0)("id_season_orign").ToString + "'"
                End If

                If Not data_dr.Rows(0)("id_sample").ToString = data_hs.Rows(0)("id_sample").ToString Then
                    If Not query_changes = "" Then
                        query_changes += ", "
                    End If

                    Dim id_sample As String = If(data_dr.Rows(0)("id_sample").ToString = "", "NULL", data_dr.Rows(0)("id_sample").ToString)

                    query_changes += "id_sample = " + id_sample
                End If

                If Not data_dr.Rows(0)("design_eos").ToString = data_hs.Rows(0)("design_eos").ToString Then
                    If Not query_changes = "" Then
                        query_changes += ", "
                    End If

                    Dim design_eos As String = If(data_dr.Rows(0)("design_eos").ToString = "", "NULL", "'" + data_dr.Rows(0)("design_eos").ToString + "'")

                    query_changes += "design_eos = " + design_eos
                End If

                If Not data_dr.Rows(0)("id_ret_code").ToString = data_hs.Rows(0)("id_ret_code").ToString Then
                    If Not query_changes = "" Then
                        query_changes += ", "
                    End If

                    query_changes += "id_ret_code = '" + data_dr.Rows(0)("id_ret_code").ToString + "'"
                End If

                If Not data_dr.Rows(0)("design_fabrication").ToString = data_hs.Rows(0)("design_fabrication").ToString Then
                    If Not query_changes = "" Then
                        query_changes += ", "
                    End If

                    query_changes += "design_fabrication = '" + addSlashes(data_dr.Rows(0)("design_fabrication").ToString) + "'"
                End If

                If Not data_dr.Rows(0)("id_design_ref").ToString = data_hs.Rows(0)("id_design_ref").ToString Then
                    If Not query_changes = "" Then
                        query_changes += ", "
                    End If

                    Dim id_design_ref As String = If(data_dr.Rows(0)("id_design_ref").ToString = "", "NULL", data_dr.Rows(0)("id_design_ref").ToString)

                    query_changes += "id_design_ref = " + id_design_ref
                End If

                If Not data_dr.Rows(0)("design_detail").ToString = data_hs.Rows(0)("design_detail").ToString Then
                    If Not query_changes = "" Then
                        query_changes += ", "
                    End If

                    query_changes += "design_detail = '" + addSlashes(data_dr.Rows(0)("design_detail").ToString) + "'"
                End If

                If Not query_changes = "" Then
                    query = "UPDATE tb_m_design SET " + query_changes + " WHERE id_design = '" + data_dr.Rows(0)("id_design").ToString + "'"
                    execute_non_query(query, True, "", "", "", "")
                End If

                '--tb_m_design_code
                Dim data_cr As DataTable = execute_query("SELECT cd.id_code, dc.id_code_detail FROM tb_m_design_code_rev AS dc, tb_m_code_detail AS cd, tb_template_code_det AS tcd WHERE dc.id_code_detail = cd.id_code_detail AND cd.id_code = tcd.id_code AND dc.id_design_rev = '" + id_report + "' ORDER BY cd.id_code ASC", -1, True, "", "", "", "")
                Dim data_ch As DataTable = execute_query("SELECT cd.id_code, dc.id_code_detail FROM tb_m_design_code_his AS dc, tb_m_code_detail AS cd, tb_template_code_det AS tcd WHERE dc.id_code_detail = cd.id_code_detail AND cd.id_code = tcd.id_code AND dc.id_design_rev = '" + id_report + "' ORDER BY cd.id_code ASC", -1, True, "", "", "", "")

                Dim new_code As String = ""

                For i = 0 To data_cr.Rows.Count - 1
                    new_code = data_cr.Rows(i)("id_code").ToString

                    For j = 0 To data_ch.Rows.Count - 1
                        'update
                        If data_cr.Rows(i)("id_code").ToString = data_ch.Rows(j)("id_code").ToString Then
                            If Not data_cr.Rows(i)("id_code_detail").ToString = data_ch.Rows(j)("id_code_detail").ToString Then
                                query = "UPDATE tb_m_design_code SET id_code_detail = '" + data_cr.Rows(i)("id_code_detail").ToString + "' WHERE id_design = '" + data_dr.Rows(0)("id_design").ToString + "' AND id_code_detail = '" + data_ch.Rows(i)("id_code_detail").ToString + "'"

                                execute_non_query(query, True, "", "", "", "")
                            End If

                            new_code = ""
                        End If
                    Next

                    'if new code
                    If Not new_code = "" Then
                        query = "INSERT INTO tb_m_design_code (id_design, id_code_detail) VALUES ('" + data_dr.Rows(0)("id_design").ToString + "', '" + data_cr.Rows(i)("id_code_detail").ToString + "')"

                        execute_non_query(query, True, "", "", "", "")
                    End If
                Next

                'delete code
                Dim old_code As String = ""

                For j = 0 To data_ch.Rows.Count - 1
                    old_code = data_ch.Rows(j)("id_code").ToString

                    For i = 0 To data_cr.Rows.Count - 1
                        If data_ch.Rows(j)("id_code").ToString = data_cr.Rows(i)("id_code").ToString Then
                            old_code = ""
                        End If
                    Next

                    'if old code
                    If Not old_code = "" Then
                        query = "DELETE FROM tb_m_design_code WHERE id_design = '" + data_dr.Rows(0)("id_design").ToString + "' AND id_code_detail = '" + data_ch.Rows(j)("id_code_detail").ToString + "'"

                        execute_non_query(query, True, "", "", "", "")
                    End If
                Next

                'update tb_m_product
                execute_non_query("
                    UPDATE tb_m_product AS p SET p.product_display_name = (SELECT d.design_display_name FROM tb_m_design AS d WHERE d.id_design = '" + data_dr.Rows(0)("id_design").ToString + "'), p.product_name = (SELECT d.design_display_name FROM tb_m_design AS d WHERE d.id_design = '" + data_dr.Rows(0)("id_design").ToString + "'), p.product_full_code = (SELECT CONCAT((SELECT d.design_code FROM tb_m_design AS d WHERE d.id_design = '" + data_dr.Rows(0)("id_design").ToString + "'), p.product_code)) WHERE p.id_design = '" + data_dr.Rows(0)("id_design").ToString + "'
                ", True, "", "", "", "")
            End If

            'update
            query = String.Format("UPDATE tb_m_design_rev SET id_report_status='{0}' WHERE id_design_rev ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            FormMasterDesignSingle.actionLoad()
        ElseIf report_mark_type = "180" Then
            'auto completed
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            ' update tb_m_employee
            If id_status_reportx = "6" Then
                Dim progress As FormEmployeePpsProgress = New FormEmployeePpsProgress()

                progress.Show()

                Dim query_pps As String = "SELECT id_type, id_employee FROM tb_employee_pps WHERE id_employee_pps = '" + id_report + "'"
                Dim data_pps As DataTable = execute_query(query_pps, -1, True, "", "", "", "")

                FormEmployeePpsDet.id_pps = id_report
                FormEmployeePpsDet.is_new = If(data_pps.Rows(0)("id_type").ToString = "1", "-1", "1")
                FormEmployeePpsDet.id_employee = If(data_pps.Rows(0)("id_employee").ToString = "", "-1", data_pps.Rows(0)("id_employee").ToString)

                progress.ProgressBarControl.EditValue = 10

                FormEmployeePpsDet.updateChanges(progress)

                progress.ProgressBarControl.EditValue = 100

                progress.Close()
            End If

            'update
            query = String.Format("UPDATE tb_employee_pps SET id_report_status='{0}' WHERE id_employee_pps ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "183" Then
            'invoice different margin
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "5" Then
                Dim cancel_rsv_stock As ClassSalesInv = New ClassSalesInv()

                If FormSalesPOSDet.is_use_unique_code = "1" Then
                    'cancelled unique
                    cancel_rsv_stock.cancellUnique(id_report, report_mark_type)
                End If

                'cancelled stock
                cancel_rsv_stock.cancelReservedStock(id_report, "183")
            ElseIf id_status_reportx = "6" Then
                'completed
                Dim complete_rsv_stock As ClassSalesInv = New ClassSalesInv()
                complete_rsv_stock.completedStockMissingStaff(id_report, "183")
            End If

            'update status
            query = String.Format("UPDATE tb_sales_pos SET id_report_status='{0}' WHERE id_sales_pos ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            'infoCustom("Status changed.")

            If form_origin = "FormSalesPOSDet" Then
                FormSalesPOSDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSalesPOSDet.check_but()
                FormSalesPOSDet.actionLoad()
                FormSalesPOS.viewSalesPOS()
                FormSalesPOS.GVSalesPOS.FocusedRowHandle = find_row(FormSalesPOS.GVSalesPOS, "id_sales_pos", id_report)
            Else
                'code here
            End If
        ElseIf report_mark_type = "184" Or report_mark_type = "213" Or report_mark_type = "214" Or report_mark_type = "219" Or report_mark_type = "220" Then
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            'sendmail
            If report_mark_type = "184" Or report_mark_type = "213" Then
                If id_status_reportx = "2" Then
                    'FormEmpOvertimeDet.send_mail()
                End If
            End If

            If report_mark_type = "219" Or report_mark_type = "220" Then
                If id_status_reportx = "6" Then
                    'FormEmpOvertimeDet.send_mail()
                End If
            End If

            'update
            query = String.Format("UPDATE tb_ot SET id_report_status='{0}' WHERE id_ot ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "185" Then
            'sample purchase close
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            'update
            query = String.Format("UPDATE tb_sample_purc_close SET id_report_status='{0}' WHERE id_sample_purc_close ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            FormSamplePurcCloseDet.load_form()
        ElseIf report_mark_type = "187" Or report_mark_type = "215" Or report_mark_type = "216" Then
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                Dim data_ver As DataTable = execute_query("SELECT id_ot, ot_date FROM tb_ot_verification WHERE id_ot_verification = " + id_report + " LIMIT 1", -1, True, "", "", "", "")

                FormEmpOvertimeVerification.id = id_report
                FormEmpOvertimeVerification.id_ot = data_ver.Rows(0)("id_ot").ToString
                FormEmpOvertimeVerification.is_view = "0"
                FormEmpOvertimeVerification.ot_date = Date.Parse(data_ver.Rows(0)("ot_date").ToString)

                FormEmpOvertimeVerification.update_changes()
            End If

            'update
            query = String.Format("UPDATE tb_ot_verification SET id_report_status='{0}' WHERE id_ot_verification ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "188" Then
            'FG PROPOSE PRICE
            If id_status_reportx = "2" Then
                id_status_reportx = "6"
            End If

            'post ke master price if completed
            If id_status_reportx = "6" Then
                'update
                Dim query_ins As String = "
                -- nonaktif pp detail
                UPDATE tb_fg_propose_price_detail ppd
                INNER JOIN tb_fg_propose_price_rev_det rd ON rd.id_fg_propose_price_detail = ppd.id_fg_propose_price_detail
                SET ppd.is_active=2
                WHERE rd.id_fg_propose_price_rev=" + id_report + ";
                -- insert active detail
                INSERT INTO tb_fg_propose_price_detail (
	                `id_fg_propose_price`,
	                `id_design`,
	                `id_prod_demand_design`,
	                `id_cop_status`,
	                `qty`,
	                `msrp`,
	                `additional_cost`,
	                `cop_date`,
	                `cop_rate_cat`,
	                `cop_kurs`,
	                `cop_value`,
	                `cop_mng_kurs` ,
	                `cop_mng_value`,
	                `price`,
                    `sale_price`,
	                `additional_price`,
	                `remark`,
                    `id_design_price_type_master`,
                    `id_design_price_type_print`,
	                `id_fg_propose_price_rev_det`
                 )
                SELECT 
                r.`id_fg_propose_price`,
                rd.`id_design`,
                rd.`id_prod_demand_design`,
                rd.`id_cop_status`,
                rd.`qty`,
                rd.`msrp`,
                rd.`additional_cost`,
                rd.`cop_date`,
                rd.`cop_rate_cat`,
                rd.`cop_kurs`,
                rd.`cop_value`,
                rd.`cop_mng_kurs` ,
                rd.`cop_mng_value`,
                rd.`price`,
                rd.`sale_price`,
                rd.`additional_price`,
                rd.`remark`,
                rd.`id_design_price_type_master`,
                rd.`id_design_price_type_print`,
                rd.`id_fg_propose_price_rev_det`
                FROM tb_fg_propose_price_rev_det rd
                INNER JOIN tb_fg_propose_price_rev r ON r.id_fg_propose_price_rev = rd.id_fg_propose_price_rev
                WHERE r.id_fg_propose_price_rev=" + id_report + ";
                -- nonaktif is_print
                UPDATE tb_m_design_price main 
                INNER JOIN ( 
	                SELECT rd.id_design, ppd.price
	                FROM tb_fg_propose_price_rev_det rd
	                INNER JOIN tb_fg_propose_price_detail ppd ON ppd.id_fg_propose_price_detail = rd.id_fg_propose_price_detail
	                INNER JOIN tb_fg_propose_price pp ON pp.id_fg_propose_price = ppd.id_fg_propose_price
	                WHERE rd.id_fg_propose_price_rev=" + id_report + " AND !ISNULL(ppd.id_design_price_type_print)
                ) src ON src.id_design = main.id_design 
                SET main.is_print=0; "
                If FormFGProposePriceRev.id_pp_type = "1" Then 'reguler
                    query_ins += "-- update price
                    INSERT INTO tb_m_design_price(id_design, id_design_price_type, design_price_name, id_currency, design_price, design_price_date, design_price_start_date, is_print, id_user) 
                    SELECT rd.id_design, 1, 'Normal', 1, rd.price, NOW(), NOW(), 1, " + id_user + "
                    FROM tb_fg_propose_price_rev_det rd
                    INNER JOIN tb_fg_propose_price_detail ppd ON ppd.id_fg_propose_price_detail = rd.id_fg_propose_price_detail
                    INNER JOIN tb_fg_propose_price pp ON pp.id_fg_propose_price = ppd.id_fg_propose_price
                    WHERE rd.id_fg_propose_price_rev=" + id_report + " ; "
                    execute_non_query(query_ins, True, "", "", "", "")
                ElseIf FormFGProposePriceRev.id_pp_type = "2" Then 'nonreguler
                    'execute detail revision
                    execute_non_query(query_ins, True, "", "", "", "")

                    Dim qd As String = "SELECT * 
                    FROM tb_fg_propose_price_rev_det ppd
                    WHERE ppd.id_fg_propose_price_rev=" + id_report + " "
                    Dim dd As DataTable = execute_query(qd, -1, True, "", "", "", "")
                    For i As Integer = 0 To dd.Rows.Count - 1
                        Dim is_print_normal = "0"
                        Dim is_print_sale = "0"
                        If dd.Rows(i)("id_design_price_type_print") = "1" Then
                            is_print_normal = "1"
                            is_print_sale = "0"
                        ElseIf dd.Rows(i)("id_design_price_type_print") = "4" Then
                            is_print_normal = "0"
                            is_print_sale = "1"
                        End If

                        If dd.Rows(i)("id_design_price_type_master") = "1" Then
                            'master akhir normal
                            Dim qry As String = "INSERT INTO tb_m_design_price(id_design, id_design_price_type, design_price_name, id_currency, design_price, design_price_date, design_price_start_date, is_print, id_user) 
                            SELECT '" + dd.Rows(i)("id_design").ToString + "','4', 'Sale','1', '" + decimalSQL(dd.Rows(i)("sale_price").ToString) + "', NOW(), NOW(), '" + is_print_sale + "', '" + id_user + "' 
                            UNION ALL
                            SELECT '" + dd.Rows(i)("id_design").ToString + "','1', 'Normal','1', '" + decimalSQL(dd.Rows(i)("price").ToString) + "', NOW(), NOW(), '" + is_print_normal + "', '" + id_user + "';  "
                            execute_non_query(qry, True, "", "", "", "")
                        ElseIf dd.Rows(i)("id_design_price_type_master") = "4" Then
                            'master akhir sale
                            Dim qry As String = "INSERT INTO tb_m_design_price(id_design, id_design_price_type, design_price_name, id_currency, design_price, design_price_date, design_price_start_date, is_print, id_user) 
                            SELECT '" + dd.Rows(i)("id_design").ToString + "','1', 'Normal','1', '" + decimalSQL(dd.Rows(i)("price").ToString) + "', NOW(), NOW(), '" + is_print_normal + "', '" + id_user + "'  
                            UNION ALL
                            SELECT '" + dd.Rows(i)("id_design").ToString + "','4', 'Sale','1', '" + decimalSQL(dd.Rows(i)("sale_price").ToString) + "', NOW(), NOW(), '" + is_print_sale + "', '" + id_user + "';  "
                            execute_non_query(qry, True, "", "", "", "")
                        End If
                    Next
                End If

                query = String.Format("UPDATE tb_fg_propose_price_rev SET id_report_status='{0}' WHERE id_fg_propose_price_rev ='{1}'", id_status_reportx, id_report)
                execute_non_query(query, True, "", "", "", "")
                'infoCustom("Status changed.")

                If form_origin = "FormFGProposePriceRev" Then
                    FormFGProposePriceRev.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                    FormFGProposePriceRev.actionLoad()
                    FormFGProposePrice.viewRevision()
                    FormFGProposePrice.GVRev.FocusedRowHandle = find_row(FormFGProposePrice.GVRev, "id_fg_propose_price_rev", id_report)
                End If
            End If
        ElseIf report_mark_type = "189" Then
            'Invoice FGPO
            'auto completed
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                'select detail
                Dim pn_type As String = ""
                Dim pn_date As String = ""
                Dim ref_date As String = ""

                Dim q_head As String = "SELECT id_pn_fgpo,`type`,created_date,ref_date FROM tb_pn_fgpo WHERE id_pn_fgpo='" & id_report & "'"
                Dim dt_head As DataTable = execute_query(q_head, -1, True, "", "", "", "")
                If dt_head.Rows.Count > 0 Then
                    pn_type = dt_head.Rows(0)("type").ToString
                    pn_date = Date.Parse(dt_head.Rows(0)("created_date").ToString).ToString("yyyy-MM-dd")
                    ref_date = Date.Parse(dt_head.Rows(0)("ref_date").ToString).ToString("yyyy-MM-dd")
                End If

                'Select user prepared
                Dim qu As String = "SELECT rm.id_user, rm.report_number FROM tb_report_mark rm WHERE rm.report_mark_type=" + report_mark_type + " AND rm.id_report='" + id_report + "' AND rm.id_report_status=1 "
                Dim du As DataTable = execute_query(qu, -1, True, "", "", "", "")
                Dim id_user_prepared As String = du.Rows(0)("id_user").ToString
                Dim report_number As String = du.Rows(0)("report_number").ToString

                'main journal
                Dim qjm As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, date_reference, acc_trans_note, id_report_status)
                        VALUES ('','" + report_number + "','24','" + id_user_prepared + "', NOW(), '" & ref_date & "', 'Auto Posting', '6'); SELECT LAST_INSERT_ID(); "
                Dim id_acc_trans As String = execute_query(qjm, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id_acc_trans + ",36)", True, "", "", "", "")

                'det journal
                Dim qjd As String = ""
                qjd = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, id_vendor, id_comp, qty, debit, credit, id_currency,kurs,debit_valas,credit_valas, acc_trans_det_note, report_mark_type, id_report, report_number, report_mark_type_ref, id_report_ref, report_number_ref, vendor)
                SELECT * FROM
                (
	                /* Per row */
	                SELECT '" & id_acc_trans & "' AS id_acc_trans,pnd.id_acc AS `id_acc`,pn.id_comp AS id_vendor, cf.id_comp,SUM(pnd.`qty`) AS `qty`,IF(SUM(pnd.value)<0,0,SUM(pnd.value)) AS `debit`,IF(SUM(pnd.value)>0,0,-SUM(pnd.value)) AS `credit`,pnd.id_currency,pnd.kurs,IF(pnd.id_currency=1,0,IF(SUM(pnd.value_bef_kurs)<0,0,SUM(pnd.value_bef_kurs))) AS `debit_valas`,IF(pnd.id_currency=1,0,IF(SUM(pnd.value_bef_kurs)>0,0,-SUM(pnd.value_bef_kurs))) AS `credit_valas`,CONCAT(pnd.`info_design`,' (Invoice no : ',pnd.inv_number,')') AS `note`,189,pn.id_pn_fgpo, pn.number, pnd.report_mark_type, pnd.id_report, pnd.report_number, comp.comp_number
	                FROM tb_pn_fgpo_det pnd
                    INNER JOIN tb_m_comp cf ON cf.id_comp=1
	                INNER JOIN tb_pn_fgpo pn ON pnd.id_pn_fgpo=pn.id_pn_fgpo
	                INNER JOIN tb_m_comp comp ON comp.id_comp=pn.id_comp
	                WHERE pn.id_pn_fgpo=" & id_report & "
	                GROUP BY pnd.id_pn_fgpo_det
	                UNION ALL
                    /* Per row PPH */
	                SELECT '" & id_acc_trans & "' AS id_acc_trans,pnd.id_acc_pph AS `id_acc`,pn.id_comp AS id_vendor, cf.id_comp,SUM(pnd.`qty`) AS `qty`,IF(SUM(pnd.pph)>0,0,-SUM(pnd.pph)) AS `debit`,IF(SUM(pnd.pph)<0,0,SUM(pnd.pph)) AS `credit`,pnd.id_currency,pnd.kurs,IF(pnd.id_currency=1,0,IF(SUM(pnd.value_bef_kurs)<0,0,SUM(pnd.value_bef_kurs))) AS `debit_valas`,IF(pnd.id_currency=1,0,IF(SUM(pnd.value_bef_kurs)>0,0,-SUM(pnd.value_bef_kurs))) AS `credit_valas`,CONCAT(pnd.`info_design`,' (Invoice no : ',pnd.inv_number,')') AS `note`,189,pn.id_pn_fgpo, pn.number, pnd.report_mark_type, pnd.id_report, pnd.report_number, comp.comp_number
	                FROM tb_pn_fgpo_det pnd
                    INNER JOIN tb_m_comp cf ON cf.id_comp=1
	                INNER JOIN tb_pn_fgpo pn ON pnd.id_pn_fgpo=pn.id_pn_fgpo
	                INNER JOIN tb_m_comp comp ON comp.id_comp=pn.id_comp
	                WHERE pn.id_pn_fgpo=" & id_report & "
	                GROUP BY pnd.id_pn_fgpo_det
	                UNION ALL
	                /* PPN */
	                SELECT '" & id_acc_trans & "' AS id_acc_trans,pn.id_acc_vat AS `id_acc`,pn.id_comp AS id_vendor, cf.id_comp,0 AS `qty`,IF(SUM(pnd.vat)<0,0,SUM(pnd.vat)) AS `debit`,IF(SUM(pnd.vat)>0,0,-SUM(pnd.vat)) AS `credit`,1 AS id_currency,1 as kurs,0 as debit_valas,0 as credit_valas,CONCAT(pnd.`info_design`,' (Invoice no : ',pnd.inv_number,')') AS `note`,189,pn.id_pn_fgpo, pn.number, pnd.report_mark_type, pnd.id_report, pnd.report_number, comp.comp_number
	                FROM tb_pn_fgpo_det pnd
                    INNER JOIN tb_m_comp cf ON cf.id_comp=1
	                INNER JOIN tb_pn_fgpo pn ON pnd.id_pn_fgpo=pn.id_pn_fgpo
	                INNER JOIN tb_m_comp comp ON comp.id_comp=pn.id_comp
	                WHERE pn.id_pn_fgpo=" & id_report & "
	                GROUP BY pn.id_pn_fgpo
	                UNION ALL
	                /* hutang dagang total */
	                SELECT '" & id_acc_trans & "' AS id_acc_trans,comp.id_acc_ap AS `id_acc`,pn.id_comp AS id_vendor, cf.id_comp,0 AS `qty`,IF(SUM(pnd.value + pnd.vat - pnd.pph)>0,0,-SUM(pnd.value + pnd.vat - pnd.pph)) AS `debit`,IF(SUM(pnd.value + pnd.vat)<0,0,SUM(pnd.value + pnd.vat - pnd.pph)) AS `credit`,pnd.id_currency,pnd.kurs,IF(pnd.id_currency=1,0,IF(SUM(pnd.value_bef_kurs + pnd.vat)>0,0,-SUM(pnd.value_bef_kurs + pnd.vat - pnd.pph))) AS `debit_valas`,IF(pnd.id_currency=1,0,IF(SUM(pnd.value_bef_kurs + pnd.vat - pnd.pph)<0,0,SUM(pnd.value_bef_kurs + pnd.vat - pnd.pph))) AS `credit_valas`,CONCAT(pnd.`info_design`,' (Invoice no : ',pnd.inv_number,')') AS `note`,189,pn.id_pn_fgpo, pn.number, pnd.report_mark_type, pnd.id_report, pnd.report_number, comp.comp_number
	                FROM tb_pn_fgpo_det pnd
                    INNER JOIN tb_m_comp cf ON cf.id_comp=1
	                INNER JOIN tb_pn_fgpo pn ON pnd.id_pn_fgpo=pn.id_pn_fgpo
	                INNER JOIN tb_m_comp comp ON comp.id_comp=pn.id_comp
	                WHERE pn.id_pn_fgpo=" & id_report & "
	                GROUP BY pn.id_pn_fgpo
                )trx WHERE trx.debit != 0 OR trx.credit != 0"
                'If pn_type = "1" Then 'dp
                '    qjd = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, id_comp, qty, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number, report_mark_type_ref, id_report_ref, report_number_ref, vendor)
                '            SELECT * FROM
                '            (
                '             /* DP vendor */
                '             SELECT '" & id_acc_trans & "' AS id_acc_trans,pnd.id_acc AS `id_acc`, pn.id_comp,0 AS `qty`,IF(SUM(pnd.value)<0,0,SUM(pnd.value)) AS `debit`,IF(SUM(pnd.value)>0,0,-SUM(pnd.value)) AS `credit`,'' AS `note`,189,pn.id_pn_fgpo, pn.number, pnd.report_mark_type, pnd.id_report, pnd.report_number, comp.comp_number
                '             FROM tb_pn_fgpo_det pnd
                '             INNER JOIN tb_pn_fgpo pn ON pnd.id_pn_fgpo=pn.id_pn_fgpo
                '             INNER JOIN tb_m_comp comp ON comp.id_comp=pn.id_comp
                '             WHERE pn.id_pn_fgpo=" & id_report & "
                '             GROUP BY pnd.id_pn_fgpo_det
                '             UNION ALL
                '             /* uang muka PPN WIP */
                '             SELECT '" & id_acc_trans & "' AS id_acc_trans,pn.id_acc_vat AS `id_acc`, pn.id_comp,  0 AS `qty`,IF(SUM(pnd.vat)<0,0,SUM(pnd.vat)) AS `debit`,IF(SUM(pnd.vat)>0,0,-SUM(pnd.vat)) AS `credit`,'' AS `note`,189,pn.id_pn_fgpo, pn.number, pnd.report_mark_type, pnd.id_report, pnd.report_number, comp.comp_number
                '             FROM tb_pn_fgpo_det pnd
                '             INNER JOIN tb_pn_fgpo pn ON pnd.id_pn_fgpo=pn.id_pn_fgpo
                '             INNER JOIN tb_m_comp comp ON comp.id_comp=pn.id_comp
                '             WHERE pn.id_pn_fgpo=" & id_report & "
                '             GROUP BY pn.id_pn_fgpo
                '             UNION ALL
                '             /* hutang dagang total */
                '             SELECT '" & id_acc_trans & "' AS id_acc_trans,comp.id_acc_ap AS `id_acc`, pn.id_comp,  0 AS `qty`,IF(SUM(pnd.value + pnd.vat)>0,0,-SUM(pnd.value + pnd.vat)) AS `debit`,IF(SUM(pnd.value + pnd.vat)<0,0,SUM(pnd.value + pnd.vat)) AS `credit`,'' AS `note`,189,pn.id_pn_fgpo, pn.number, pnd.report_mark_type, pnd.id_report, pnd.report_number, comp.comp_number
                '             FROM tb_pn_fgpo_det pnd
                '             INNER JOIN tb_pn_fgpo pn ON pnd.id_pn_fgpo=pn.id_pn_fgpo
                '             INNER JOIN tb_m_comp comp ON comp.id_comp=pn.id_comp
                '             WHERE pn.id_pn_fgpo=" & id_report & "
                '             GROUP BY pn.id_pn_fgpo
                '            )trx WHERE trx.debit != 0 OR trx.credit != 0"
                'ElseIf pn_type = "2" Or pn_type = "3" Or pn_type = "4" Then 'payment / extra / over memo
                '    qjd = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, id_comp, qty, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number, report_mark_type_ref, id_report_ref, report_number_ref, vendor)
                '                    SELECT * FROM
                '                    (
                '                        /* HPP jika domestik or international */
                '                        SELECT '" & id_acc_trans & "' AS id_acc_trans,IF(cou.is_domestic=1,(SELECT id_acc_hpp_dom FROM tb_opt_accounting),(SELECT id_acc_hpp_int FROM tb_opt_accounting)) AS `id_acc`, 1 AS id_comp, pnd.`qty` AS `qty`,(pnd.value) AS `debit`,0 AS `credit`,pnd.`info_design` AS `note`,189,pn.id_pn_fgpo, pn.number, pnd.report_mark_type, pnd.id_report, pnd.report_number, comp.comp_number
                '                        FROM `tb_pn_fgpo_det` pnd
                '                        INNER JOIN tb_pn_fgpo pn ON pn.`id_pn_fgpo`=pnd.`id_pn_fgpo`
                '                        INNER JOIN tb_m_comp comp ON comp.id_comp=pn.id_comp
                '                        INNER JOIN tb_m_city city ON city.id_city=comp.id_city
                '                        INNER JOIN tb_m_state stte ON stte.id_state=city.id_state
                '                        INNER JOIN tb_m_region reg ON reg.id_region=stte.id_region
                '                        INNER JOIN tb_m_country cou ON cou.id_country=reg.id_country
                '                        WHERE pnd.`id_pn_fgpo`='" & id_report & "' AND pnd.report_mark_type='28'
                '                        UNION ALL
                '                        /* Balik DP */
                '                        SELECT '" & id_acc_trans & "' AS id_acc_trans,comp.id_acc_dp AS `id_acc`, 1 AS id_comp, pnd.`qty` AS `qty`,0 AS `debit`,(-pnd.value) AS `credit`,pnd.`info_design` AS `note`,199,pn.id_pn_fgpo, pn.number, pnd.report_mark_type, pnd.id_report, pnd.report_number, comp.comp_number
                '                        FROM `tb_pn_fgpo_det` pnd
                '                        INNER JOIN tb_pn_fgpo pn ON pn.`id_pn_fgpo`=pnd.`id_pn_fgpo`
                '                        INNER JOIN tb_m_comp comp ON comp.id_comp=pn.id_comp
                '                        INNER JOIN tb_m_city city ON city.id_city=comp.id_city
                '                        INNER JOIN tb_m_state stte ON stte.id_state=city.id_state
                '                        INNER JOIN tb_m_region reg ON reg.id_region=stte.id_region
                '                        INNER JOIN tb_m_country cou ON cou.id_country=reg.id_country
                '                        WHERE pnd.`id_pn_fgpo`='" & id_report & "' AND pnd.report_mark_type='199'
                '                        UNION ALL
                '                        /* VAT */
                '                        SELECT '" & id_acc_trans & "' AS id_acc_trans,(SELECT id_acc_vat_fg FROM tb_opt_accounting) AS `id_acc`, 1 AS id_comp, pnd.`qty` AS `qty`,IF(SUM(pnd.vat)<0,0,SUM(pnd.vat)) AS `debit`,IF(SUM(pnd.vat)<0,-SUM(pnd.vat),0) AS `credit`,pnd.`info_design` AS `note`,199,pn.id_pn_fgpo, pn.number, pnd.report_mark_type, pnd.id_report, pnd.report_number, comp.comp_number
                '                        FROM `tb_pn_fgpo_det` pnd
                '                        INNER JOIN tb_pn_fgpo pn ON pn.`id_pn_fgpo`=pnd.`id_pn_fgpo`
                '                        INNER JOIN tb_m_comp comp ON comp.id_comp=pn.id_comp
                '                        INNER JOIN tb_m_city city ON city.id_city=comp.id_city
                '                        INNER JOIN tb_m_state stte ON stte.id_state=city.id_state
                '                        INNER JOIN tb_m_region reg ON reg.id_region=stte.id_region
                '                        INNER JOIN tb_m_country cou ON cou.id_country=reg.id_country
                '                        WHERE pnd.`id_pn_fgpo`='" & id_report & "' 
                '                        UNION ALL
                '                        /* Hutang Dagang */
                '                        SELECT '" & id_acc_trans & "' AS id_acc_trans,comp.id_acc_ap AS `id_acc`, 1 AS id_comp, pnd.`qty` AS `qty`,IF(SUM(pnd.vat+pnd.value)<0,SUM(-(pnd.vat+pnd.value)),0) AS `debit`,IF(SUM(pnd.vat+pnd.value)<0,0,SUM(pnd.vat+pnd.value)) AS `credit`,pnd.`info_design` AS `note`,199,pn.id_pn_fgpo, pn.number, pnd.report_mark_type, pnd.id_report, pnd.report_number, comp.comp_number
                '                        FROM `tb_pn_fgpo_det` pnd
                '                        INNER JOIN tb_pn_fgpo pn ON pn.`id_pn_fgpo`=pnd.`id_pn_fgpo`
                '                        INNER JOIN tb_m_comp comp ON comp.id_comp=pn.id_comp
                '                        INNER JOIN tb_m_city city ON city.id_city=comp.id_city
                '                        INNER JOIN tb_m_state stte ON stte.id_state=city.id_state
                '                        INNER JOIN tb_m_region reg ON reg.id_region=stte.id_region
                '                        INNER JOIN tb_m_country cou ON cou.id_country=reg.id_country
                '                        WHERE pnd.`id_pn_fgpo`='" & id_report & "' 
                '                    )trx WHERE trx.debit != 0 OR trx.credit != 0"
                'End If
                execute_non_query(qjd, True, "", "", "", "")
                'check if hutang dagang 0
                Dim qc As String = "SELECT comp.id_acc_ap AS `id_acc`, cf.id_comp,0 AS `qty`,IF(SUM(pnd.value + pnd.vat - pnd.pph)>0,0,-SUM(pnd.value + pnd.vat - pnd.pph)) AS `debit`,IF(SUM(pnd.value + pnd.vat)<0,0,SUM(pnd.value + pnd.vat - pnd.pph)) AS `credit`,pnd.id_currency,pnd.kurs,IF(pnd.id_currency=1,0,IF(SUM(pnd.value_bef_kurs + pnd.vat)>0,0,-SUM(pnd.value_bef_kurs + pnd.vat - pnd.pph))) AS `debit_valas`,IF(pnd.id_currency=1,0,IF(SUM(pnd.value_bef_kurs + pnd.vat - pnd.pph)<0,0,SUM(pnd.value_bef_kurs + pnd.vat - pnd.pph))) AS `credit_valas`,CONCAT(pnd.`info_design`,' (Invoice no : ',pnd.inv_number,')') AS `note`,189,pn.id_pn_fgpo, pn.number, pnd.report_mark_type, pnd.id_report, pnd.report_number, comp.comp_number
FROM tb_pn_fgpo_det pnd
INNER JOIN tb_m_comp cf ON cf.id_comp=1
INNER JOIN tb_pn_fgpo pn ON pnd.id_pn_fgpo=pn.id_pn_fgpo
INNER JOIN tb_m_comp comp ON comp.id_comp=pn.id_comp
WHERE pn.id_pn_fgpo=" & id_report & "
GROUP BY pn.id_pn_fgpo"
                Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
                If dtc.Rows.Count > 0 Then
                    If dtc.Rows(0)("debit") = 0 And dtc.Rows(0)("credit") = 0 Then
                        query = String.Format("UPDATE tb_pn_fgpo SET is_open='2' WHERE id_pn_fgpo ='{0}'", id_report)
                        execute_non_query(query, True, "", "", "", "")
                    End If
                End If
            End If

            'update
            query = String.Format("UPDATE tb_pn_fgpo SET id_report_status='{0}' WHERE id_pn_fgpo ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            'FormInvoiceFGPO.load_list("0")
        ElseIf report_mark_type = "190" Or report_mark_type = "193" Then
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            'update
            query = String.Format("UPDATE tb_work_order SET id_report_status='{0}' WHERE id_work_order ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            FormWorkOrderDet.load_form()
        ElseIf report_mark_type = "192" Then
            'payroll
            If id_status_reportx = "2" Then
                id_status_reportx = "6"
            End If

            'update
            query = String.Format("UPDATE tb_emp_payroll SET id_report_status='{0}' WHERE id_payroll ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            If id_status_reportx = "6" Then
                FormEmpPayroll.insert_expense(id_report)
                FormEmpPayroll.insert_jurnal(id_report)
                FormEmpPayroll.insert_jurnal_toko(id_report)
                FormEmpPayroll.remaining_leave(id_report)
            End If

            FormEmpPayroll.load_payroll()

            FormEmpPayroll.GVPayrollPeriode.FocusedRowHandle = find_row(FormEmpPayroll.GVPayrollPeriode, "id_payroll", id_report)

            FormEmpPayroll.load_payroll_detail()
        ElseIf report_mark_type = "179" Then
            'sample material purchase
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            'update
            query = String.Format("UPDATE tb_sample_po_mat SET id_report_status='{0}' WHERE id_sample_po_mat ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            FormSampleExpenseDet.load_head()
        ElseIf report_mark_type = "197" Or report_mark_type = "229" Then
            'auto completed
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            ' update to tb_m_employee and tb_m_employee_salary
            If id_status_reportx = "6" Then
                FormProposeEmpSalaryDet.id_employee_sal_pps = id_report
                FormProposeEmpSalaryDet.is_duplicate = "-1"

                FormProposeEmpSalaryDet.update_changes()
            End If

            'update
            query = String.Format("UPDATE tb_employee_sal_pps SET id_report_status='{0}' WHERE id_employee_sal_pps ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "200" Then
            Cursor = Cursors.WaitCursor
            'propose design changes
            'auto completed
            If id_status_reportx = "2" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                Dim query_comp As String = "
                /*update design new*/
                UPDATE tb_m_design main
                INNER JOIN (
	                SELECT det.id_design
	                FROM tb_m_design_changes_det det
	                INNER JOIN tb_m_design_changes c ON c.id_changes = det.id_changes
	                WHERE det.id_changes=" + id_report + "
                ) src ON src.id_design = main.id_design 
                SET main.is_process=2, main.last_updated=NOW(), main.updated_by=" + id_user + ", main.is_approved=1,
                main.approved_by=" + id_user + ", main.approved_time=NOW(); "
                execute_non_query(query_comp, True, "", "", "", "")
            End If

            'update status
            query = String.Format("UPDATE tb_m_design_changes SET id_report_status='{0}' WHERE id_changes ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")


            'refresh view
            FormFGDesignListChanges.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
            FormFGDesignListChanges.actionLoad()
            FormFGDesignList.viewPropose()
            FormFGDesignList.GVPropose.FocusedRowHandle = find_row(FormFGDesignList.GVPropose, "id_changes", id_report)
            Cursor = Cursors.Default
        ElseIf report_mark_type = "203" Or report_mark_type = "204" Then
            'budget OPEX propose
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then 'complete update/insert budget
                'cek type first
                Dim query_pps As String = "SELECT id_type FROM tb_b_opex_pps WHERE id_b_opex_pps ='" & id_report & "'"
                Dim data_pps As DataTable = execute_query(query_pps, -1, True, "", "", "", "")
                If data_pps.Rows.Count > 0 Then
                    If data_pps.Rows(0)("id_type").ToString = "1" Then 'propose new
                        Dim query_det As String = "SELECT ppsd.`id_item_cat_main`,ppsd.`year`,ppsd.`value_after`
FROM `tb_b_opex_pps` pps
INNER JOIN tb_b_opex_pps_det ppsd ON ppsd.id_b_opex_pps=pps.id_b_opex_pps
WHERE pps.id_b_opex_pps='" & id_report & "' AND value_after!=0"
                        Dim data_det As DataTable = execute_query(query_det, -1, True, "", "", "", "")
                        For i As Integer = 0 To data_det.Rows.Count - 1
                            'insert budget
                            Dim ins_det As String = "INSERT INTO `tb_b_expense_opex`(id_item_cat_main,`year`,value_expense)
VALUES('" & data_det.Rows(i)("id_item_cat_main").ToString & "','" & data_det.Rows(i)("year").ToString & "','" & decimalSQL(data_det.Rows(i)("value_after").ToString) & "');"
                            execute_non_query(ins_det, True, "", "", "", "")
                        Next
                    Else 'revision
                        Dim query_det As String = "SELECT ppsd.`id_item_cat_main`,ppsd.`year`,ppsd.`value_before`,ppsd.`value_after`,IFNULL(bo.`id_b_expense_opex`,'') AS id_b_expense_opex
FROM `tb_b_opex_pps` pps
INNER JOIN tb_b_opex_pps_det ppsd ON ppsd.id_b_opex_pps=pps.id_b_opex_pps
LEFT JOIN tb_b_expense_opex bo ON bo.`id_item_cat_main`=ppsd.id_item_cat_main AND ppsd.year=bo.`year` AND bo.`is_active`='1'
WHERE pps.id_b_opex_pps='" & id_report & "' AND (value_after!=0 OR value_before!=0)"
                        Dim data_det As DataTable = execute_query(query_det, -1, True, "", "", "", "")
                        For i As Integer = 0 To data_det.Rows.Count - 1

                            If Not data_det.Rows(i)("id_b_expense_opex").ToString = "" Then
                                'update budget
                                Dim upd_det As String = "UPDATE tb_b_expense_opex SET value_expense='" & decimalSQL(data_det.Rows(i)("value_after").ToString) & "' WHERE id_b_expense_opex='" & data_det.Rows(i)("id_b_expense_opex").ToString & "'"
                                execute_non_query(upd_det, True, "", "", "", "")
                            Else
                                'insert budget
                                Dim ins_det As String = "INSERT INTO `tb_b_expense_opex`(id_item_cat_main,`year`,value_expense)
VALUES('" & data_det.Rows(i)("id_item_cat_main").ToString & "','" & data_det.Rows(i)("year").ToString & "','" & decimalSQL(data_det.Rows(i)("value_after").ToString) & "');"
                                execute_non_query(ins_det, True, "", "", "", "")
                            End If
                        Next
                    End If
                End If
            End If

            'update
            query = String.Format("UPDATE tb_b_opex_pps SET id_report_status='{0}' WHERE id_b_opex_pps ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            'FormSampleBudget.load_propose()
            'FormSampleBudget.load_budget()
        ElseIf report_mark_type = "207" Then
            'POPOSE MAIN CATEGORY
            'auto completed
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                query = "INSERT INTO tb_item_cat_main(`id_expense_type`,`is_fixed_asset`,`item_cat_main`)
		                SELECT d.id_expense_type, d.is_fixed_asset, d.item_cat_main 
		                FROM tb_item_cat_main_pps_det d
		                WHERE d.id_item_cat_main_pps = '" & id_report & "'"
                execute_non_query(query, True, "", "", "", "")
            End If

            'jika cancel


            'update status
            query = String.Format("UPDATE tb_item_cat_main_pps SET id_report_status='{0}' WHERE id_item_cat_main_pps ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            FormItemCatMainDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
            FormItemCatMainDet.actionLoad()
            FormItemCatMain.view_propose()
            FormItemCatMain.GVData.FocusedRowHandle = find_row(FormItemCatMain.GVData, "id_item_cat_main_pps", id_report)
        ElseIf report_mark_type = "208" Or report_mark_type = "209" Then
            'budget OPEX propose
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then 'complete update/insert budget
                'cek type first
                Dim query_pps As String = "SELECT id_type FROM tb_b_expense_propose WHERE id_b_expense_propose ='" & id_report & "'"
                Dim data_pps As DataTable = execute_query(query_pps, -1, True, "", "", "", "")
                If data_pps.Rows.Count > 0 Then
                    If data_pps.Rows(0)("id_type").ToString = "1" Then 'propose new
                        Dim query_det As String = "SELECT ppsd.`id_item_cat_main`,pps.id_departement,ppsd.`year`,ppsd.`value_after`
FROM `tb_b_expense_propose` pps
INNER JOIN tb_b_expense_propose_year ppsd ON ppsd.id_b_expense_propose=pps.id_b_expense_propose
WHERE pps.id_b_expense_propose='" & id_report & "' AND value_after!=0"
                        Dim data_det As DataTable = execute_query(query_det, -1, True, "", "", "", "")
                        For i As Integer = 0 To data_det.Rows.Count - 1
                            'insert budget
                            Dim ins_det As String = "INSERT INTO `tb_b_expense`(id_item_cat_main,id_departement,`year`,value_expense)
VALUES('" & data_det.Rows(i)("id_item_cat_main").ToString & "','" & data_det.Rows(i)("id_departement").ToString & "','" & data_det.Rows(i)("year").ToString & "','" & decimalSQL(data_det.Rows(i)("value_after").ToString) & "');"
                            execute_non_query(ins_det, True, "", "", "", "")
                        Next
                    Else 'revision
                        Dim query_det As String = "SELECT ppsd.`id_item_cat_main`,pps.id_departement,ppsd.`year`,ppsd.`value_before`,ppsd.`value_after`,IFNULL(bo.`id_b_expense`,'') AS id_b_expense
FROM `tb_b_expense_propose` pps
INNER JOIN tb_b_expense_propose_year ppsd ON ppsd.id_b_expense_propose=pps.id_b_expense_propose
LEFT JOIN tb_b_expense bo ON bo.`id_item_cat_main`=ppsd.id_item_cat_main AND ppsd.year=bo.`year` AND bo.`is_active`='1' AND pps.id_departement=bo.id_departement
WHERE pps.id_b_expense_propose='" & id_report & "' AND (value_after!=0 OR value_before!=0)"
                        Dim data_det As DataTable = execute_query(query_det, -1, True, "", "", "", "")
                        For i As Integer = 0 To data_det.Rows.Count - 1

                            If Not data_det.Rows(i)("id_b_expense").ToString = "" Then
                                'update budget
                                Dim upd_det As String = "UPDATE tb_b_expense SET value_expense='" & decimalSQL(data_det.Rows(i)("value_after").ToString) & "' WHERE id_b_expense='" & data_det.Rows(i)("id_b_expense").ToString & "'"
                                execute_non_query(upd_det, True, "", "", "", "")
                            Else
                                'insert budget
                                Dim ins_det As String = "INSERT INTO `tb_b_expense`(id_item_cat_main,id_departement,`year`,value_expense)
VALUES('" & data_det.Rows(i)("id_item_cat_main").ToString & "','" & data_det.Rows(i)("id_departement").ToString & "','" & data_det.Rows(i)("year").ToString & "','" & decimalSQL(data_det.Rows(i)("value_after").ToString) & "');"
                                execute_non_query(ins_det, True, "", "", "", "")
                            End If
                        Next
                    End If
                End If
            End If

            'update
            query = String.Format("UPDATE tb_b_expense_propose SET id_report_status='{0}' WHERE id_b_expense_propose ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            'FormSampleBudget.load_propose()
            'FormSampleBudget.load_budget()
        ElseIf report_mark_type = "211" Then
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            'update
            query = String.Format("UPDATE tb_emp_attn_input SET id_report_status='{0}' WHERE id_emp_attn_input ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "212" Then
            'prod order closing
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            'update
            query = String.Format("UPDATE tb_prod_order_close SET id_report_status='{0}' WHERE id_prod_order_close ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            If id_status_reportx = "6" Then
                'update is close
                Dim query_closing As String = "UPDATE tb_prod_order po 
INNER JOIN `tb_prod_order_close_det` pocd ON pocd.id_prod_order=po.id_prod_order
SET po.is_closing_rec='1'
WHERE pocd.id_prod_order_close = '" & id_report & "'"
                execute_non_query(query_closing, True, "", "", "", "")
            End If
        ElseIf report_mark_type = "221" Then
            'Debit Note
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                Dim dn_date As String = ""
                Dim ref_date As String = ""

                Dim q_head As String = "SELECT created_date,ref_date FROM tb_debit_note WHERE id_debit_note='" & id_report & "'"
                Dim dt_head As DataTable = execute_query(q_head, -1, True, "", "", "", "")
                If dt_head.Rows.Count > 0 Then
                    dn_date = Date.Parse(dt_head.Rows(0)("created_date").ToString).ToString("yyyy-MM-dd")
                    ref_date = Date.Parse(dt_head.Rows(0)("ref_date").ToString).ToString("yyyy-MM-dd")
                End If

                ' select user prepared
                Dim qu As String = "SELECT rm.id_user, rm.report_number ,rm.report_mark_datetime FROM tb_report_mark rm WHERE rm.report_mark_type=" + report_mark_type + " AND rm.id_report='" + id_report + "' AND rm.id_report_status=1 "
                Dim du As DataTable = execute_query(qu, -1, True, "", "", "", "")
                Dim id_user_prepared As String = du.Rows(0)("id_user").ToString
                Dim report_number As String = du.Rows(0)("report_number").ToString

                'main journal
                Dim qjm As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, date_reference, acc_trans_note, id_report_status)
                VALUES ('','" + report_number + "','24','" + id_user_prepared + "','" & dn_date & "','" & ref_date & "', 'Auto Posting', '6'); SELECT LAST_INSERT_ID(); "
                Dim id_acc_trans As String = execute_query(qjm, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id_acc_trans + ",36)", True, "", "", "", "")

                'det journal
                If FormDebitNoteDet.id_dn_type = "1" Or FormDebitNoteDet.id_dn_type = "4" Then 'claim reject
                    Dim qjd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, id_vendor, qty, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number, id_comp, report_mark_type_ref,id_report_ref,report_number_ref)
                    -- klaim reject nya dulu
                    SELECT " + id_acc_trans + " AS `id_trans`, IF(dn.id_dn_type=1,(SELECT acc_coa_claim FROM tb_opt_purchasing),(SELECT acc_coa_claim_int FROM tb_opt_purchasing)) AS `id_acc`, dn.id_comp  AS id_vendor, dnd.qty, 0 AS `debit`, CAST(((dnd.claim_percent/100)*dnd.unit_price)*dnd.qty AS DECIMAL(13,2)) AS `credit`
                    ,CONCAT('KLAIM ',dnd.description,' - ',dnd.info_design) AS `note`, " + report_mark_type + " AS `rmt`, dnd.id_debit_note, dn.`number`, 1 AS id_comp, dnd.report_mark_type AS rmt_ref, dnd.id_report AS id_ref, dnd.report_number AS number_ref
                    FROM tb_debit_note_det dnd
                    INNER JOIN tb_debit_note dn ON dn.id_debit_note=dnd.id_debit_note
                    WHERE dnd.id_debit_note='" & id_report & "' AND dnd.unit_price>0 AND dnd.claim_percent>0
                    UNION ALL
                    -- lawannya DP
                    SELECT " + id_acc_trans + " AS `id_trans`, c.id_acc_dp AS `id_acc`, dn.id_comp  AS id_vendor, dnd.qty, SUM(CAST((dnd.claim_percent/100)*dnd.unit_price*dnd.qty AS DECIMAL(13,2))) AS `debit`, 0 AS `credit`
                    ,CONCAT('KLAIM REJECT') AS `note`, " + report_mark_type + " AS `rmt`, dnd.id_debit_note, dn.`number`, 1 AS id_comp, dnd.report_mark_type AS rmt_ref, dnd.id_report AS id_ref, dnd.report_number AS number_ref
                    FROM tb_debit_note_det dnd
                    INNER JOIN tb_debit_note dn ON dn.id_debit_note=dnd.id_debit_note
                    INNER JOIN tb_m_comp c ON c.id_comp=dn.id_comp
                    WHERE dnd.id_debit_note='" & id_report & "'
                    GROUP BY dnd.id_debit_note "
                    execute_non_query(qjd, True, "", "", "", "")
                ElseIf FormDebitNoteDet.id_dn_type = "2" Then 'claim terlambat
                    Dim qjd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, id_vendor, qty, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number, id_comp, report_mark_type_ref,id_report_ref,report_number_ref)
                    -- klaim late nya dulu
                    SELECT " + id_acc_trans + " AS `id_trans`, (SELECT acc_coa_claim FROM tb_opt_purchasing) AS `id_acc`, dn.id_comp  AS id_vendor, dnd.qty, 0 AS `debit`, CAST(((dnd.claim_percent/100)*dnd.unit_price)*dnd.qty AS DECIMAL(13,2)) AS `credit`
                    ,CONCAT('KLAIM TERLAMBAT - ',dnd.info_design) AS `note`, " + report_mark_type + " AS `rmt`, dnd.id_debit_note, dn.`number`, 1 AS id_comp, dnd.report_mark_type AS rmt_ref, dnd.id_report AS id_ref, dnd.report_number AS number_ref
                    FROM tb_debit_note_det dnd
                    INNER JOIN tb_debit_note dn ON dn.id_debit_note=dnd.id_debit_note
                    WHERE dnd.id_debit_note='" & id_report & "' AND dnd.unit_price>0 AND dnd.claim_percent>0
                    UNION ALL
                    -- lawannya DP
                    SELECT " + id_acc_trans + " AS `id_trans`, c.id_acc_dp AS `id_acc`, dn.id_comp  AS id_vendor, dnd.qty, SUM(CAST((dnd.claim_percent/100)*dnd.unit_price*dnd.qty AS DECIMAL(13,2))) AS `debit`, 0 AS `credit`
                    ,CONCAT('KLAIM TERLAMBAT') AS `note`, " + report_mark_type + " AS `rmt`, dnd.id_debit_note, dn.`number`, 1 AS id_comp, dnd.report_mark_type AS rmt_ref, dnd.id_report AS id_ref, dnd.report_number AS number_ref
                    FROM tb_debit_note_det dnd
                    INNER JOIN tb_debit_note dn ON dn.id_debit_note=dnd.id_debit_note
                    INNER JOIN tb_m_comp c ON c.id_comp=dn.id_comp
                    WHERE dnd.id_debit_note='" & id_report & "'
                    GROUP BY dnd.id_debit_note "
                    execute_non_query(qjd, True, "", "", "", "")
                End If
                ' update status 
                'If FormDebitNoteDet.id_dn_type = "1" Then 'claim reject
                '    query = String.Format("UPDATE tb_debit_note_det dnd
                '                            INNER JOIN tb_prod_order po ON po.id_prod_order=dnd.id_report AND dnd.report_mark_type='22' 
                '                            SET is_claimed_reject='1'
                '                            WHERE dnd.id_debit_note='{0}'", id_report)
                '    execute_non_query(query, True, "", "", "", "")
                'ElseIf FormDebitNoteDet.id_dn_type = "2" Then 'claim terlambat
                '    query = String.Format("UPDATE tb_debit_note_det dnd
                '                            INNER JOIN tb_prod_order_rec rec ON rec.id_prod_order_rec=dnd.id_report AND dnd.report_mark_type='28' 
                '                            SET is_claimed_late='1'
                '                            WHERE dnd.id_debit_note='{0}'", id_report)
                '    execute_non_query(query, True, "", "", "", "")
                'End If
            End If

            'update
            query = String.Format("UPDATE tb_debit_note SET id_report_status='{0}' WHERE id_debit_note ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            FormDebitNoteDet.load_form()
        ElseIf report_mark_type = "223" Then
            'bpjs kesehatan
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                FormEmpBPJSKesehatanDet.update_changes()
            End If

            'update
            query = String.Format("UPDATE tb_pay_bpjs_kesehatan SET id_report_status='{0}' WHERE id_pay_bpjs_kesehatan ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "222" Then
            'summary qc report
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
                pushNotifFromDb(id_report, report_mark_type)
            End If

            'update
            query = String.Format("UPDATE tb_prod_fc_sum SET id_report_status='{0}' WHERE id_prod_fc_sum ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "231" Then
            'inv mat
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                Dim dn_date As String = ""
                Dim ref_date As String = ""
                Dim bill_type As String = ""
                Dim id_type As String = ""
                Dim is_deposit As String = ""

                Dim q_head As String = "SELECT created_date,ref_date,id_inv_mat_type,is_deposit FROM tb_inv_mat WHERE id_inv_mat='" & id_report & "'"
                Dim dt_head As DataTable = execute_query(q_head, -1, True, "", "", "", "")
                If dt_head.Rows.Count > 0 Then
                    dn_date = Date.Parse(dt_head.Rows(0)("created_date").ToString).ToString("yyyy-MM-dd")
                    ref_date = Date.Parse(dt_head.Rows(0)("ref_date").ToString).ToString("yyyy-MM-dd")
                    id_type = dt_head.Rows(0)("id_inv_mat_type").ToString
                    is_deposit = dt_head.Rows(0)("is_deposit").ToString

                    If dt_head.Rows(0)("id_inv_mat_type").ToString = "1" Then
                        bill_type = "23"
                    ElseIf dt_head.Rows(0)("id_inv_mat_type").ToString = "2" Then
                        bill_type = "20"
                    End If
                End If

                ' select user prepared
                Dim qu As String = "SELECT rm.id_user, rm.report_number ,rm.report_mark_datetime FROM tb_report_mark rm WHERE rm.report_mark_type=" + report_mark_type + " AND rm.id_report='" + id_report + "' AND rm.id_report_status=1 "
                Dim du As DataTable = execute_query(qu, -1, True, "", "", "", "")
                Dim id_user_prepared As String = du.Rows(0)("id_user").ToString
                Dim report_number As String = du.Rows(0)("report_number").ToString


                'main journal
                Dim qjm As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, date_reference, acc_trans_note, id_report_status)
                VALUES ('','" + report_number + "','" & bill_type & "','" + id_user_prepared + "','" & dn_date & "','" & ref_date & "', 'Auto Posting', '6'); SELECT LAST_INSERT_ID(); "
                Dim id_acc_trans As String = execute_query(qjm, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id_acc_trans + ",36)", True, "", "", "", "")

                'det journal
                If is_deposit = "1" Then
                    Dim qjd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, id_vendor, qty, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number, id_comp, report_mark_type_ref,id_report_ref,report_number_ref)
SELECT * FROM (
-- pend lain tanpa ppn
SELECT " + id_acc_trans + " AS `id_trans`, (SELECT id_acc_pend_lain FROM tb_opt_accounting) AS `id_acc`, inv.id_comp AS id_vendor, 0 AS qty, 0 AS `debit`, CAST(SUM(invd.`value`) AS DECIMAL(13,2)) AS `credit`
,CONCAT('PENJUALAN MATERIAL') AS `note`, " + report_mark_type + " AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
FROM `tb_inv_mat_det` invd
INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
WHERE invd.`id_inv_mat`='" & id_report & "' AND inv.vat_percent = 0   
UNION ALL                 
-- pend lain dengan ppn
SELECT " + id_acc_trans + " AS `id_trans`, (SELECT id_acc_pend_lain_dgn_ppn FROM tb_opt_accounting) AS `id_acc`,inv.id_comp AS id_vendor, 0 AS qty, 0 AS `debit`, CAST(SUM(invd.`value`) AS DECIMAL(13,2)) AS `credit`
,CONCAT('PENJUALAN MATERIAL') AS `note`, " + report_mark_type + " AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
FROM `tb_inv_mat_det` invd
INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
WHERE invd.`id_inv_mat`='" & id_report & "' AND inv.vat_percent > 0
UNION ALL
-- hutang PPN
SELECT " + id_acc_trans + " AS `id_trans`, (SELECT id_acc_ppn_lain FROM tb_opt_accounting) AS `id_acc`,inv.id_comp AS id_vendor, 0 AS qty, 0 AS `debit`, CAST(SUM(invd.`value`)*((inv.`vat_percent`)/(100)) AS DECIMAL(13,2)) AS `credit`
,CONCAT('PENJUALAN MATERIAL') AS `note`, " + report_mark_type + " AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
FROM `tb_inv_mat_det` invd
INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
WHERE invd.`id_inv_mat`='" & id_report & "' AND inv.vat_percent > 0
UNION ALL
-- KAS
SELECT " + id_acc_trans + " AS `id_trans`, (SELECT id_acc_kas FROM tb_opt_accounting) AS `id_acc`,inv.id_comp AS id_vendor, 0 AS qty, CAST(SUM(invd.`value`)*((100+inv.`vat_percent`)/(100)) AS DECIMAL(13,2)) AS `debit`, 0 AS `credit`
,CONCAT('PENJUALAN MATERIAL') AS `note`, " + report_mark_type + " AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
FROM `tb_inv_mat_det` invd
INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
WHERE invd.`id_inv_mat`='" & id_report & "' 
) a WHERE credit>0 OR debit>0"
                    execute_non_query(qjd, True, "", "", "", "")
                Else
                    If id_type = "1" Then 'pl
                        Dim qjd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc,id_vendor, qty, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number, id_comp, report_mark_type_ref,id_report_ref,report_number_ref)
                    -- penjualan
SELECT " + id_acc_trans + " AS `id_trans`, (SELECT id_acc_jual_mat FROM tb_opt_accounting) AS `id_acc`,inv.id_comp AS id_vendor, 0 AS qty, 0 AS `debit`, CAST(SUM(invd.`value`) AS DECIMAL(13,2)) AS `credit`
,CONCAT('PENJUALAN MATERIAL') AS `note`, " + report_mark_type + " AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
FROM `tb_inv_mat_det` invd
INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
WHERE invd.`id_inv_mat`='" & id_report & "'
UNION ALL
-- hutang PPN
SELECT " + id_acc_trans + " AS `id_trans`, (SELECT id_acc_hutang_ppn_bahan FROM tb_opt_accounting) AS `id_acc`,inv.id_comp AS id_vendor, 0 AS qty, 0 AS `debit`, CAST(SUM(invd.`value`)*((inv.`vat_percent`)/(100)) AS DECIMAL(13,2)) AS `credit`
,CONCAT('PENJUALAN MATERIAL') AS `note`, " + report_mark_type + " AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
FROM `tb_inv_mat_det` invd
INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
WHERE invd.`id_inv_mat`='" & id_report & "'
UNION ALL
-- AR
SELECT " + id_acc_trans + " AS `id_trans`, c.id_acc_ar AS `id_acc`,inv.id_comp AS id_vendor, 0 AS qty, CAST(SUM(invd.`value`)*((100+inv.`vat_percent`)/(100)) AS DECIMAL(13,2)) AS `debit`, 0 AS `credit`
,CONCAT('PENJUALAN MATERIAL') AS `note`, " + report_mark_type + " AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
FROM `tb_inv_mat_det` invd
INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
INNER JOIN tb_m_comp c ON c.id_comp=inv.`id_comp`
WHERE invd.`id_inv_mat`='" & id_report & "' "
                        execute_non_query(qjd, True, "", "", "", "")
                    ElseIf id_type = "2" Then 'ret
                        Dim qjd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc,id_vendor, qty, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number, id_comp, report_mark_type_ref,id_report_ref,report_number_ref)
                    -- retur
SELECT " + id_acc_trans + " AS `id_trans`, (SELECT id_acc_retur_jual_mat FROM tb_opt_accounting) AS `id_acc`,inv.id_comp  AS id_vendor, 0 AS qty,  CAST(SUM(invd.`value`) AS DECIMAL(13,2)) AS `debit`,0 AS `credit`
,CONCAT('RETUR PENJUALAN MATERIAL') AS `note`, " + report_mark_type + " AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
FROM `tb_inv_mat_det` invd
INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
WHERE invd.`id_inv_mat`='" & id_report & "'
UNION ALL
-- hutang PPN
SELECT " + id_acc_trans + " AS `id_trans`, (SELECT id_acc_hutang_ppn_bahan FROM tb_opt_accounting) AS `id_acc`,inv.id_comp  AS id_vendor, 0 AS qty, CAST(SUM(invd.`value`)*((inv.`vat_percent`)/(100)) AS DECIMAL(13,2)) AS `debit`,0 AS `credit`
,CONCAT('RETUR PENJUALAN MATERIAL') AS `note`, " + report_mark_type + " AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
FROM `tb_inv_mat_det` invd
INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
WHERE invd.`id_inv_mat`='" & id_report & "'
UNION ALL
-- AR
SELECT " + id_acc_trans + " AS `id_trans`, c.id_acc_ar AS `id_acc`,inv.id_comp  AS id_vendor, 0 AS qty,0 AS `debit`, CAST(SUM(invd.`value`)*((100+inv.`vat_percent`)/(100)) AS DECIMAL(13,2)) AS `credit`
,CONCAT('RETUR PENJUALAN MATERIAL') AS `note`, " + report_mark_type + " AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
FROM `tb_inv_mat_det` invd
INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
INNER JOIN tb_m_comp c ON c.id_comp=inv.`id_comp`
WHERE invd.`id_inv_mat`='" & id_report & "'"
                        execute_non_query(qjd, True, "", "", "", "")
                    End If
                End If

                ' update status 
                If id_type = "1" Then 'pl
                    query = String.Format("UPDATE tb_pl_mrs pl 
                                            SET is_invoice='1'
                                            WHERE pl.id_pl_mrs='{0}'", id_report)
                    execute_non_query(query, True, "", "", "", "")
                ElseIf id_type = "2" Then 'ret
                    query = String.Format("UPDATE tb_mat_prod_ret_in ret
                                            SET is_invoice='1'
                                            WHERE ret.id_mat_prod_ret_in='{0}'", id_report)
                    execute_non_query(query, True, "", "", "", "")
                End If
            ElseIf id_status_reportx = "5" Then
                query = String.Format("SELECT id_report_status,id_inv_mat_type FROM tb_inv_mat WHERE id_inv_mat ='{0}' AND id_report_status='6'", id_report)
                Dim dt_c As DataTable = execute_query(query, -1, True, "", "", "", "")
                If dt_c.Rows.Count > 0 Then
                    'cancellation form
                    'jurnal balik
                    Dim dn_date As String = ""
                    Dim ref_date As String = ""
                    Dim bill_type As String = ""
                    Dim id_type As String = ""
                    Dim is_deposit As String = ""

                    Dim q_head As String = "SELECT created_date,ref_date,id_inv_mat_type,is_deposit FROM tb_inv_mat WHERE id_inv_mat='" & id_report & "'"
                    Dim dt_head As DataTable = execute_query(q_head, -1, True, "", "", "", "")
                    If dt_head.Rows.Count > 0 Then
                        dn_date = Date.Parse(dt_head.Rows(0)("created_date").ToString).ToString("yyyy-MM-dd")
                        ref_date = Date.Parse(dt_head.Rows(0)("ref_date").ToString).ToString("yyyy-MM-dd")
                        id_type = dt_head.Rows(0)("id_inv_mat_type").ToString
                        is_deposit = dt_head.Rows(0)("is_deposit").ToString

                        If dt_head.Rows(0)("id_inv_mat_type").ToString = "1" Then
                            bill_type = "23"
                        ElseIf dt_head.Rows(0)("id_inv_mat_type").ToString = "2" Then
                            bill_type = "20"
                        End If
                    End If

                    ' select user prepared
                    Dim qu As String = "SELECT rm.id_user, rm.report_number ,rm.report_mark_datetime FROM tb_report_mark rm WHERE rm.report_mark_type=" + report_mark_type + " AND rm.id_report='" + id_report + "' AND rm.id_report_status=1 "
                    Dim du As DataTable = execute_query(qu, -1, True, "", "", "", "")
                    Dim id_user_prepared As String = du.Rows(0)("id_user").ToString
                    Dim report_number As String = du.Rows(0)("report_number").ToString


                    'main journal
                    Dim qjm As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, date_reference, acc_trans_note, id_report_status)
                VALUES ('','" + report_number + "','" & bill_type & "','" + id_user_prepared + "','" & dn_date & "','" & ref_date & "', 'Auto Posting', '6'); SELECT LAST_INSERT_ID(); "
                    Dim id_acc_trans As String = execute_query(qjm, 0, True, "", "", "", "")
                    execute_non_query("CALL gen_number(" + id_acc_trans + ",36)", True, "", "", "", "")

                    'det journal
                    If is_deposit = "1" Then
                        Dim qjd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, qty, debit, credit,  acc_trans_det_note, report_mark_type, id_report, report_number, id_comp, report_mark_type_ref,id_report_ref,report_number_ref)
SELECT * FROM (
-- pend lain tanpa ppn
SELECT " + id_acc_trans + " AS `id_trans`, (SELECT id_acc_pend_lain FROM tb_opt_accounting) AS `id_acc`, 0 AS qty, CAST(SUM(invd.`value`) AS DECIMAL(13,2)) AS `debit`, 0 AS `credit`
,CONCAT('CANCEL PENJUALAN MATERIAL') AS `note`, " + report_mark_type + " AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
FROM `tb_inv_mat_det` invd
INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
WHERE invd.`id_inv_mat`='" & id_report & "' AND inv.vat_percent = 0
UNION ALL                 
-- pend lain dengan ppn
SELECT " + id_acc_trans + " AS `id_trans`, (SELECT id_acc_pend_lain_dgn_ppn FROM tb_opt_accounting) AS `id_acc`, 0 AS qty, CAST(SUM(invd.`value`) AS DECIMAL(13,2)) AS `debit`,0  AS `credit`
,CONCAT('CANCEL PENJUALAN MATERIAL') AS `note`, " + report_mark_type + " AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
FROM `tb_inv_mat_det` invd
INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
WHERE invd.`id_inv_mat`='" & id_report & "' AND inv.vat_percent > 0
UNION ALL
-- hutang PPN
SELECT " + id_acc_trans + " AS `id_trans`, (SELECT id_acc_ppn_lain FROM tb_opt_accounting) AS `id_acc`, 0 AS qty, CAST(SUM(invd.`value`)*((inv.`vat_percent`)/(100)) AS DECIMAL(13,2)) AS `debit`,0  AS `credit`
,CONCAT('CANCEL PENJUALAN MATERIAL') AS `note`, " + report_mark_type + " AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
FROM `tb_inv_mat_det` invd
INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
WHERE invd.`id_inv_mat`='" & id_report & "' AND inv.vat_percent > 0
UNION ALL
-- KAS
SELECT " + id_acc_trans + " AS `id_trans`, (SELECT id_acc_kas FROM tb_opt_accounting) AS `id_acc`, 0 AS qty, 0 AS `debit`,CAST(SUM(invd.`value`)*((100+inv.`vat_percent`)/(100)) AS DECIMAL(13,2))  AS `credit`
,CONCAT('CANCEL PENJUALAN MATERIAL') AS `note`, " + report_mark_type + " AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
FROM `tb_inv_mat_det` invd
INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
WHERE invd.`id_inv_mat`='" & id_report & "' 
) a WHERE credit>0 OR debit>0"
                        execute_non_query(qjd, True, "", "", "", "")
                    Else
                        If id_type = "1" Then 'pl
                            Dim qjd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, qty, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number, id_comp, report_mark_type_ref,id_report_ref,report_number_ref)
                    -- penjualan
SELECT " + id_acc_trans + " AS `id_trans`, (SELECT id_acc_jual_mat FROM tb_opt_accounting) AS `id_acc`, 0 AS qty,  CAST(SUM(invd.`value`) AS DECIMAL(13,2)) AS `debit`, 0 AS `credit`
,CONCAT('CANCEL PENJUALAN MATERIAL') AS `note`, " + report_mark_type + " AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
FROM `tb_inv_mat_det` invd
INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
WHERE invd.`id_inv_mat`='" & id_report & "'
UNION ALL
-- hutang PPN
SELECT " + id_acc_trans + " AS `id_trans`, (SELECT id_acc_hutang_ppn_bahan FROM tb_opt_accounting) AS `id_acc`, 0 AS qty, CAST(SUM(invd.`value`)*((inv.`vat_percent`)/(100)) AS DECIMAL(13,2)) AS `debit`,0  AS `credit`
,CONCAT('CANCEL PENJUALAN MATERIAL') AS `note`, " + report_mark_type + " AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
FROM `tb_inv_mat_det` invd
INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
WHERE invd.`id_inv_mat`='" & id_report & "'
UNION ALL
-- AR
SELECT " + id_acc_trans + " AS `id_trans`, c.id_acc_ar AS `id_acc`, 0 AS qty, 0 AS `debit`,CAST(SUM(invd.`value`)*((100+inv.`vat_percent`)/(100)) AS DECIMAL(13,2))  AS `credit`
,CONCAT('CANCEL PENJUALAN MATERIAL') AS `note`, " + report_mark_type + " AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
FROM `tb_inv_mat_det` invd
INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
INNER JOIN tb_m_comp c ON c.id_comp=inv.`id_comp`
WHERE invd.`id_inv_mat`='" & id_report & "' "
                            execute_non_query(qjd, True, "", "", "", "")
                        ElseIf id_type = "2" Then 'ret
                            Dim qjd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, qty, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number, id_comp, report_mark_type_ref,id_report_ref,report_number_ref)
                    -- retur
SELECT " + id_acc_trans + " AS `id_trans`, (SELECT id_acc_retur_jual_mat FROM tb_opt_accounting) AS `id_acc`, 0 AS qty, 0  AS `debit`,CAST(SUM(invd.`value`) AS DECIMAL(13,2)) AS `credit`
,CONCAT('CANCEL RETUR PENJUALAN MATERIAL') AS `note`, " + report_mark_type + " AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
FROM `tb_inv_mat_det` invd
INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
WHERE invd.`id_inv_mat`='" & id_report & "'
UNION ALL
-- hutang PPN
SELECT " + id_acc_trans + " AS `id_trans`, (SELECT id_acc_hutang_ppn_bahan FROM tb_opt_accounting) AS `id_acc`, 0 AS qty, 0 AS `debit`,CAST(SUM(invd.`value`)*((inv.`vat_percent`)/(100)) AS DECIMAL(13,2)) AS `credit`
,CONCAT('CANCEL RETUR PENJUALAN MATERIAL') AS `note`, " + report_mark_type + " AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
FROM `tb_inv_mat_det` invd
INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
WHERE invd.`id_inv_mat`='" & id_report & "'
UNION ALL
-- AR
SELECT " + id_acc_trans + " AS `id_trans`, c.id_acc_ar AS `id_acc`, 0 AS qty,CAST(SUM(invd.`value`)*((100+inv.`vat_percent`)/(100)) AS DECIMAL(13,2)) AS `debit`, 0 AS `credit`
,CONCAT('CANCEL RETUR PENJUALAN MATERIAL') AS `note`, " + report_mark_type + " AS `rmt`, inv.id_inv_mat, inv.`number`, 1 AS id_comp, invd.report_mark_type AS rmt_ref, invd.id_report AS id_ref, invd.report_number AS number_ref
FROM `tb_inv_mat_det` invd
INNER JOIN `tb_inv_mat` inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
INNER JOIN tb_m_comp c ON c.id_comp=inv.`id_comp`
WHERE invd.`id_inv_mat`='" & id_report & "'"
                            execute_non_query(qjd, True, "", "", "", "")
                        End If
                    End If

                    'balik pl yang diupdate
                    If dt_c.Rows(0)("id_inv_mat_type").ToString = "1" Then 'pl
                        query = String.Format("UPDATE tb_pl_mrs pl 
                                            SET is_invoice='2'
                                            WHERE pl.id_pl_mrs='{0}'", id_report)
                        execute_non_query(query, True, "", "", "", "")
                    ElseIf dt_c.Rows(0)("id_inv_mat_type").ToString = "2" Then 'ret
                        query = String.Format("UPDATE tb_mat_prod_ret_in ret
                                            SET is_invoice='2'
                                            WHERE ret.id_mat_prod_ret_in='{0}'", id_report)
                        execute_non_query(query, True, "", "", "", "")
                    End If
                End If
            End If

            'update
            query = String.Format("UPDATE tb_inv_mat SET id_report_status='{0}' WHERE id_inv_mat ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            FormInvMatDet.load_form()
        ElseIf report_mark_type = "233" Then
            'delay payment
            If id_status_reportx = "2" Then
                id_status_reportx = "6"
            End If

            'if completed
            If id_status_reportx = "6" Then
                Dim query_upd_inv As String = "/* update tabel invoice */
                UPDATE tb_sales_pos main
                INNER JOIN (
	                SELECT dd.id_propose_delay_payment, d.due_date, dd.id_sales_pos 
	                FROM tb_propose_delay_payment_det dd
	                INNER JOIN tb_propose_delay_payment d ON d.id_propose_delay_payment = dd.id_propose_delay_payment
	                WHERE d.id_propose_delay_payment=" + id_report + "
                ) src ON src.id_sales_pos = main.id_sales_pos
                SET main.id_propose_delay_payment = src.id_propose_delay_payment,
                main.propose_delay_payment_due_date = src.due_date; 
                /* update ar eval jika ada */
                UPDATE tb_ar_eval main
                INNER JOIN (
	                SELECT d.id_sales_pos , d.id_propose_delay_payment_det
	                FROM tb_propose_delay_payment_det d
	                WHERE d.id_propose_delay_payment=" + id_report + "
                ) src ON src.id_sales_pos = main.id_sales_pos
                SET main.is_active=2, main.id_propose_delay_payment_det = src.id_propose_delay_payment_det, main.release_date=NOW()
                WHERE main.is_active=1; "
                execute_non_query(query_upd_inv, True, "", "", "", "")

                '=== checking release hanya utk keperluan email
                'check apakah invoice yang di memo ada di evaluasi ato tidak
                Dim query_in_evaluation As String = "SELECT md.id_propose_delay_payment_det,m.id_comp_group  
                FROM tb_propose_delay_payment_det md
                INNER JOIN tb_propose_delay_payment m ON m.id_propose_delay_payment = md.id_propose_delay_payment
                LEFT JOIN (
	                SELECT e.id_ar_eval, e.id_sales_pos 
	                FROM tb_ar_eval e
	                INNER JOIN tb_propose_delay_payment_det md ON md.id_propose_delay_payment_det = e.id_propose_delay_payment_det
	                WHERE e.eval_date IN (SELECT MAX(e.eval_date)  FROM tb_ar_eval e)
                )  e ON e.id_sales_pos = md.id_sales_pos
                WHERE md.id_propose_delay_payment=" + id_report + " AND !ISNULL(e.id_ar_eval) "
                Dim data_in_evaluation As DataTable = execute_query(query_in_evaluation, -1, True, "", "", "", "")
                If data_in_evaluation.Rows.Count > 0 Then
                    Dim id_comp_group As String = data_in_evaluation.Rows(0)("id_comp_group").ToString
                    Dim ev As New ClassAREvaluation()
                    Dim data_cek_email_release As DataTable = ev.dtCekEmailRelease(id_comp_group)
                    If data_cek_email_release.Rows.Count > 0 Then
                        'jika ada yg dibayar semua maka kirim email
                        Dim mm As New ClassMailManage()
                        Dim id_mail As String = "-1"
                        Dim mail_subject As String = get_setup_field("mail_subject_release_del")
                        Dim mail_title As String = get_setup_field("mail_title_release_del")
                        Dim mail_content As String = get_setup_field("mail_content_release_del")
                        Dim query_mail_content_to As String = "SELECT CONCAT(e.employee_name, ' (',e.employee_position,')') AS `to_content_mail`
                                FROM tb_opt o
                                INNER JOIN tb_m_employee e ON e.id_employee = o.id_emp_wh_manager "
                        Dim mail_content_to As String = execute_query(query_mail_content_to, 0, True, "", "", "", "")

                        'send paramenter class
                        mm.rmt = report_mark_type
                        mm.mail_subject = mail_subject
                        mm.mail_title = mail_title
                        mm.par1 = id_comp_group
                        mm.rmt = "230"
                        mm.createEmail(id_comp_group, id_user, id_report, report_mark_type, report_number)
                        id_mail = mm.id_mail_manage

                        'email
                        Try
                            Dim em As New ClassSendEmail()
                            em.report_mark_type = "230"
                            em.id_report = id_mail
                            em.design_code = mail_title
                            em.design = mail_subject
                            em.comment_by = mail_content_to
                            em.comment = mail_content
                            em.dt = mm.getDetailData
                            em.send_email()

                            Dim query_log As String = mm.queryInsertLog(id_user, "2", "Sent Successfully")
                            execute_non_query(query_log, True, "", "", "", "")
                        Catch ex As Exception
                            Dim query_log As String = mm.queryInsertLog(id_user, "3", addSlashes(ex.ToString))
                            execute_non_query(query_log, True, "", "", "", "")
                        End Try
                    End If
                End If
            End If

            'update
            query = String.Format("UPDATE tb_propose_delay_payment SET id_report_status='{0}' WHERE id_propose_delay_payment ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            Try
                FormDelayPayment.SLEStoreGroup.EditValue = FormDelayPaymentDet.id_comp_group
                FormDelayPayment.viewData()
                FormDelayPayment.GVData.FocusedRowHandle = find_row(FormDelayPayment.GVData, "id_propose_delay_payment", id_report)
                FormDelayPaymentDet.actionLoad()
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "234" Then
            'follow up ar
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            'update
            query = String.Format("UPDATE tb_follow_up_recap SET id_report_status='{0}' WHERE id_follow_up_recap ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "242" Then
            'cash advance cancel
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                'Select user prepared
                Dim qu As String = "SELECT rm.id_user, rm.report_number FROM tb_report_mark rm WHERE rm.report_mark_type=" + report_mark_type + " AND rm.id_report='" + id_report + "' AND rm.id_report_status=1 "
                Dim du As DataTable = execute_query(qu, -1, True, "", "", "", "")
                Dim id_user_prepared As String = du.Rows(0)("id_user").ToString
                Dim report_number As String = du.Rows(0)("report_number").ToString

                'main journal
                Dim id_bill_type As String = "8"

                Dim qjm As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, acc_trans_note, id_report_status)
                        VALUES ('','" + report_number + "','" + id_bill_type + "','" + id_user_prepared + "', NOW(), 'Auto Posting', '6'); SELECT LAST_INSERT_ID(); "
                Dim id_acc_trans As String = execute_query(qjm, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id_acc_trans + ",36)", True, "", "", "", "")

                'det journal
                Dim qjd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, id_comp, qty, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number)
                    SELECT " + id_acc_trans + ", cr.id_acc, 1 AS id_comp, 0 AS qty, 0 AS debit, cr.`value` AS credit, cr.`description` AS acc_trans_det_note, " + report_mark_type + " AS report_mark_type, cr.`id_cash_advance` AS id_report, c.`number` AS report_number
                    FROM tb_cash_advance_cancel_det AS cl_det
                    LEFT JOIN tb_cash_advance_cancel AS cl ON cl_det.id_cash_advance_cancel = cl.id_cash_advance_cancel
                    LEFT JOIN tb_cash_advance_report AS cr ON cl_det.id_cash_advance_report = cr.id_cash_advance_report
                    LEFT JOIN tb_cash_advance AS c ON cl.`id_cash_advance` = c.`id_cash_advance`
                    WHERE cl.id_cash_advance = '" + id_report + "'

                    UNION ALL

                    SELECT " + id_acc_trans + ", cl_det.id_acc_to, 1 AS id_comp, 0 AS qty, cl_det.value AS debit, 0 AS credit, cl_det.`description_to` AS acc_trans_det_note, " + report_mark_type + " AS report_mark_type, cr.`id_cash_advance` AS id_report, c.`number` AS report_number
                    FROM tb_cash_advance_cancel_det AS cl_det
                    LEFT JOIN tb_cash_advance_cancel AS cl ON cl_det.id_cash_advance_cancel = cl.id_cash_advance_cancel
                    LEFT JOIN tb_cash_advance_report AS cr ON cl_det.id_cash_advance_report = cr.id_cash_advance_report
                    LEFT JOIN tb_cash_advance AS c ON cl.`id_cash_advance` = c.`id_cash_advance`
                    WHERE cl.id_cash_advance = '" + id_report + "'"
                execute_non_query(qjd, True, "", "", "", "")
            End If

            'update
            query = String.Format("UPDATE tb_cash_advance_cancel SET id_report_status='{0}' WHERE id_cash_advance ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "243" Then
            'pre return
            'auto completed
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                'action completed
                Dim query_ins As String = "INSERT INTO tb_ol_store_ret_list(id_ol_store_ret_det, id_ol_store_ret_stt) 
                SELECT d.id_ol_store_ret_det, 1 
                FROM tb_ol_store_ret_det d
                WHERE d.id_ol_store_ret=" + id_report + " "
                execute_non_query(query_ins, True, "", "", "", "")

                'update status order
                Try
                    Dim query_upd_stt_order As String = "INSERT IGNORE INTO tb_sales_order_det_status(id_sales_order_det, `status`, `status_date`, `input_status_date`)
                    SELECT d.id_sales_order_det, 'pre return', NOW(), NOW()
                    FROM tb_ol_store_ret_det d
                    WHERE d.id_ol_store_ret=" + id_report + "
                    GROUP BY d.id_sales_order_det "
                    execute_non_query(query_upd_stt_order, True, "", "", "", "")
                Catch ex As Exception
                    warningCustom("Error updating status order. " + ex.ToString)
                End Try
            End If

            'update status
            query = String.Format("UPDATE tb_ol_store_ret SET id_report_status='{0}' WHERE id_ol_store_ret ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "245" Then
            'return cust
            'auto completed changed because complete di manifest
            'If id_status_reportx = "3" Then
            'id_status_reportx = "6"
            'End If

            If id_status_reportx = "6" Then
                'action completed
                Dim query_ins As String = "UPDATE `tb_ol_store_ret_list` rl
                INNER JOIN tb_ol_store_cust_ret_det rd ON rd.`id_ol_store_ret_list`=rl.`id_ol_store_ret_list`
                SET rl.`id_ol_store_ret_stt`='5'
                WHERE rd.`id_ol_store_cust_ret`='" & id_report & "'; 
                -- update status internal order
                INSERT IGNORE INTO tb_sales_order_det_status(id_sales_order_det, `status`, `status_date`, `input_status_date`, is_internal)
                SELECT rd.id_sales_order_det, stt.ol_store_ret_stt, NOW(), NOW(),1
                FROM tb_ol_store_cust_ret_det d
                INNER JOIN tb_ol_store_ret_list rl ON rl.id_ol_store_ret_list = d.id_ol_store_ret_list
                INNER JOIN tb_ol_store_ret_det rd ON rd.id_ol_store_ret_det = rl.id_ol_store_ret_det
                JOIN tb_lookup_ol_store_ret_stt stt ON stt.id_ol_store_ret_stt=5
                WHERE d.id_ol_store_cust_ret='" & id_report & "'; "
                execute_non_query(query_ins, True, "", "", "", "")
            End If

            'update status
            query = String.Format("UPDATE tb_ol_store_cust_ret SET id_report_status='{0}' WHERE id_ol_store_cust_ret ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "246" Then
            'request return
            'auto completed
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                'action completed
                'send mail
                Try
                Catch ex As Exception

                End Try
            End If

            'update status
            query = String.Format("UPDATE tb_ol_store_ret_req SET id_report_status='{0}' WHERE id_ol_store_ret_req ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            Try
                FormOlStoreReturnList.viewRequest()
                FormOlStoreReturnList.GVRequest.FocusedRowHandle = find_row(FormOlStoreReturnList.GVRequest, "id_ol_store_ret_req", id_report)
                FormRequestRetOLStore.actionLoad()
            Catch ex As Exception

            End Try
        ElseIf report_mark_type = "250" Then
            'request return
            'auto completed
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                'delete log

                'set tag
                Dim ql As String = "DELETE FROM tb_ol_promo_collection_log WHERE id_ol_promo_collection='" + id_report + "';
                SELECT s.id_prod_shopify, p.id_design , m.tag
                FROM tb_ol_promo_collection_sku s
                INNER JOIN tb_ol_promo_collection m ON m.id_ol_promo_collection = s.id_ol_promo_collection
                INNER JOIN tb_m_product p ON p.id_product = s.id_product
                WHERE s.id_ol_promo_collection=" + id_report + "
                GROUP BY s.id_prod_shopify "
                Dim dl As DataTable = execute_query(ql, -1, True, "", "", "", "")
                If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                    FormMain.SplashScreenManager1.ShowWaitForm()
                End If
                For l As Integer = 0 To dl.Rows.Count - 1
                    FormMain.SplashScreenManager1.SetWaitFormDescription((l + 1).ToString + " of " + dl.Rows.Count.ToString)
                    Dim prod_id As String = dl.Rows(l)("id_prod_shopify").ToString
                    Dim id_design_curr As String = dl.Rows(l)("id_design").ToString
                    Try
                        Dim s As New ClassShopifyApi()
                        Dim tag As String = s.get_tag(prod_id)
                        Dim tag_save As String = ""
                        If tag <> "" Then
                            tag_save = tag + "," + dl.Rows(l)("tag").ToString
                        Else
                            tag_save = dl.Rows(l)("tag").ToString
                        End If
                        s.set_tag(prod_id, tag_save)
                        execute_non_query("INSERT tb_ol_promo_collection_log(id_ol_promo_collection, type, id_design, log, log_date)
                        VALUES('" + id_report + "', 1, '" + id_design_curr + "', 'OK', NOW()); ", True, "", "", "", "")
                    Catch ex As Exception
                        execute_non_query("INSERT tb_ol_promo_collection_log(id_ol_promo_collection, type, id_design, log, log_date)
                        VALUES('" + id_report + "', 1, '" + id_design_curr + "', '" + addSlashes(ex.ToString) + "', NOW()); ", True, "", "", "", "")
                    End Try
                Next
                FormMain.SplashScreenManager1.CloseWaitForm()

                'cek log
                Dim qlog As String = "SELECT * FROM tb_ol_promo_collection_log l WHERE l.id_ol_promo_collection=" + id_report + " AND l.log<>'OK'"
                Dim dlog As DataTable = execute_query(qlog, -1, True, "", "", "", "")
                If dlog.Rows.Count > 0 Then
                    stopCustom("Some product failed to sync. Please contact administrator")
                End If
            End If

            'update status
            query = String.Format("UPDATE tb_ol_promo_collection SET id_report_status='{0}' WHERE id_ol_promo_collection ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
            Try
                FormPromoCollectionDet.refreshData()
            Catch ex As Exception

            End Try
        ElseIf report_mark_type = "251" Or report_mark_type = "285" Then
            'bbk summary
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                'complete all BBK
                'yang bukan beli dolar dulu
                Dim q As String = "SELECT pnsd.id_pn,pnsd.id_pn_summary_type FROM tb_pn_summary_det pnsd 
INNER JOIN tb_pn pn ON pn.id_pn=pnsd.id_pn
WHERE (pnsd.id_pn_summary_type=1 OR pnsd.id_pn_summary_type=3) AND pnsd.id_pn_summary='" & id_report & "' AND pn.is_buy_valas='2'"
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                For i = 0 To dt.Rows.Count - 1
                    Dim rm As FormReportMark = New FormReportMark
                    rm.is_bbk_tolakan = If(dt.Rows(i)("id_pn_summary_type").ToString = "3", True, False)
                    rm.id_report = dt.Rows(i)("id_pn").ToString
                    rm.report_mark_type = "159"
                    rm.change_status("6")
                Next
                'beli dolar terakhir
                q = "SELECT pnsd.id_pn,pnsd.id_pn_summary_type FROM tb_pn_summary_det pnsd 
INNER JOIN tb_pn pn ON pn.id_pn=pnsd.id_pn
WHERE (pnsd.id_pn_summary_type=1 OR pnsd.id_pn_summary_type=3) AND pnsd.id_pn_summary='" & id_report & "' AND pn.is_buy_valas='1'"
                dt = execute_query(q, -1, True, "", "", "", "")
                For i = 0 To dt.Rows.Count - 1
                    Dim rm As FormReportMark = New FormReportMark
                    rm.is_bbk_tolakan = If(dt.Rows(i)("id_pn_summary_type").ToString = "3", True, False)
                    rm.id_report = dt.Rows(i)("id_pn").ToString
                    rm.report_mark_type = "159"
                    rm.change_status("6")
                Next
                'balik tolakan

            End If

            'update status
            query = String.Format("UPDATE tb_pn_summary SET id_report_status='{0}' WHERE id_pn_summary ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "254" Then
            'volcom store sales
            'auto completed
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            'completed
            If id_status_reportx = "6" Then
                'auto jurnal
                'Select user prepared
                Dim qu As String = "SELECT rm.id_user, rm.report_number FROM tb_report_mark rm WHERE rm.report_mark_type=" + report_mark_type + " AND rm.id_report='" + id_report + "' AND rm.id_report_status=1 "
                Dim du As DataTable = execute_query(qu, -1, True, "", "", "", "")
                Dim id_user_prepared As String = du.Rows(0)("id_user").ToString
                Dim report_number As String = du.Rows(0)("report_number").ToString

                'main journal
                Dim date_reference As String = DateTime.Parse(FormSalesBranchDet.DESalesDate.EditValue.ToString).ToString("yyyy-MM-dd")
                Dim date_created As String = DateTime.Parse(FormSalesBranchDet.DECreatedDate.EditValue.ToString).ToString("yyyy-MM-dd")
                Dim qjm As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, date_reference, acc_trans_note, id_report_status)
                VALUES ('','" + report_number + "','19','" + id_user_prepared + "', '" + date_created + "','" + date_reference + "',  'Auto Posting', '6'); SELECT LAST_INSERT_ID(); "
                Dim id_acc_trans As String = execute_query(qjm, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id_acc_trans + ",36)", True, "", "", "", "")

                'det journal
                Dim qjd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, id_comp, qty, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number, vendor, id_coa_tag) 
                SELECT '" + id_acc_trans + "', d.id_acc, d.id_comp, 0, IF(d.id_dc=1, ABS(d.value), 0) AS `debit`, IF(d.id_dc=2, d.value, 0) AS `credit`, d.note, '254', '" + id_report + "', 
                '" + report_number + "', d.vendor, m.id_coa_tag
                FROM tb_sales_branch_det d
                INNER JOIN tb_sales_branch m ON m.id_sales_branch = d.id_sales_branch
                WHERE d.id_sales_branch='" + id_report + "'
                UNION ALL 
                SELECT '" + id_acc_trans + "', m.rev_normal_net_acc, m.id_comp_normal, 0, 0.00 AS `debit`, m.rev_normal_net AS `credit`, m.rev_normal_net_note, '254', '" + id_report + "',
                '" + report_number + "', '', m.id_coa_tag
                FROM tb_sales_branch m
                WHERE m.id_sales_branch='" + id_report + "'
                UNION ALL
                SELECT '" + id_acc_trans + "', m.rev_normal_ppn_acc, m.id_comp_normal, 0, 0.00 AS `debit`, m.rev_normal_ppn AS `credit`, m.rev_normal_ppn_note, '254', '" + id_report + "',
                '" + report_number + "', '', m.id_coa_tag
                FROM tb_sales_branch m
                WHERE m.id_sales_branch='" + id_report + "'
                UNION ALL
                SELECT '" + id_acc_trans + "', m.comp_rev_normal_acc, m.id_comp_normal, 0, 0.00 AS `debit`, m.comp_rev_normal AS `credit`, m.comp_rev_normal_note, '254', '" + id_report + "',
                '" + report_number + "', '', m.id_coa_tag
                FROM tb_sales_branch m
                WHERE m.id_sales_branch='" + id_report + "'
                UNION ALL
                SELECT '" + id_acc_trans + "', m.rev_sale_net_acc, m.id_comp_sale, 0, 0.00 AS `debit`, m.rev_sale_net AS `credit`, m.rev_sale_net_note, '254', '" + id_report + "',
                '" + report_number + "', '', m.id_coa_tag
                FROM tb_sales_branch m
                WHERE m.id_sales_branch='" + id_report + "'
                UNION ALL
                SELECT '" + id_acc_trans + "', m.rev_sale_ppn_acc, m.id_comp_sale, 0, 0.00 AS `debit`, m.rev_sale_ppn AS `credit`, m.rev_sale_ppn_note, '254', '" + id_report + "',
                '" + report_number + "', '', m.id_coa_tag
                FROM tb_sales_branch m
                WHERE m.id_sales_branch='" + id_report + "'
                UNION ALL
                SELECT '" + id_acc_trans + "', m.comp_rev_sale_acc, m.id_comp_sale, 0, 0.00 AS `debit`, m.comp_rev_sale AS `credit`, m.comp_rev_sale_note, '254', '" + id_report + "',
                '" + report_number + "', '', m.id_coa_tag
                FROM tb_sales_branch m
                WHERE m.id_sales_branch='" + id_report + "'; "
                execute_non_query(qjd, True, "", "", "", "")
            End If

            'update
            query = String.Format("UPDATE tb_sales_branch Set id_report_status='{0}' WHERE id_sales_branch ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            Try
                FormSalesBranchDet.actionLoad()
                FormSalesBranch.viewData()
                FormSalesBranch.GVData.FocusedRowHandle = find_row(FormSalesBranch.GVData, "id_sales_branch", id_report)
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "256" Then
            'volcom store CN
            'auto completed
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            'completed
            If id_status_reportx = "6" Then
                'auto jurnal
                'Select user prepared
                Dim qu As String = "SELECT rm.id_user, rm.report_number FROM tb_report_mark rm WHERE rm.report_mark_type=" + report_mark_type + " AND rm.id_report='" + id_report + "' AND rm.id_report_status=1 "
                Dim du As DataTable = execute_query(qu, -1, True, "", "", "", "")
                Dim id_user_prepared As String = du.Rows(0)("id_user").ToString
                Dim report_number As String = du.Rows(0)("report_number").ToString

                'main journal
                Dim date_reference As String = DateTime.Parse(FormSalesBranchDet.DESalesDate.EditValue.ToString).ToString("yyyy-MM-dd")
                Dim date_created As String = DateTime.Parse(FormSalesBranchDet.DECreatedDate.EditValue.ToString).ToString("yyyy-MM-dd")
                Dim qjm As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, date_reference, acc_trans_note, id_report_status)
                VALUES ('','" + report_number + "','25','" + id_user_prepared + "', '" + date_created + "','" + date_reference + "',  'Auto Posting', '6'); SELECT LAST_INSERT_ID(); "
                Dim id_acc_trans As String = execute_query(qjm, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id_acc_trans + ",36)", True, "", "", "", "")

                'det journal
                Dim qjd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, id_comp, qty, credit,debit, acc_trans_det_note, report_mark_type, id_report, report_number, vendor, id_coa_tag) 
                SELECT '" + id_acc_trans + "', d.id_acc, d.id_comp, 0, IF(d.id_dc=2, ABS(d.value), 0) AS `credit`, IF(d.id_dc=1, ABS(d.value), 0) AS `debit`, d.note, '256', '" + id_report + "', 
                '" + report_number + "', d.vendor, m.id_coa_tag
                FROM tb_sales_branch_det d
                INNER JOIN tb_sales_branch m ON m.id_sales_branch = d.id_sales_branch
                WHERE d.id_sales_branch='" + id_report + "'
                UNION ALL 
                SELECT '" + id_acc_trans + "', m.rev_normal_net_acc, m.id_comp_normal, 0, 0.00 AS `credit`, m.rev_normal_net AS `debit`, m.rev_normal_net_note, '256', '" + id_report + "',
                '" + report_number + "', '', m.id_coa_tag
                FROM tb_sales_branch m
                WHERE m.id_sales_branch='" + id_report + "'
                UNION ALL
                SELECT '" + id_acc_trans + "', m.rev_normal_ppn_acc, m.id_comp_normal, 0, 0.00 AS `credit`, m.rev_normal_ppn AS `debit`, m.rev_normal_ppn_note, '256', '" + id_report + "',
                '" + report_number + "', '', m.id_coa_tag
                FROM tb_sales_branch m
                WHERE m.id_sales_branch='" + id_report + "'
                UNION ALL
                SELECT '" + id_acc_trans + "', m.comp_rev_normal_acc, m.id_comp_normal, 0, 0.00 AS `credit`, m.comp_rev_normal AS `debit`, m.comp_rev_normal_note, '256', '" + id_report + "',
                '" + report_number + "', '', m.id_coa_tag
                FROM tb_sales_branch m
                WHERE m.id_sales_branch='" + id_report + "'
                UNION ALL
                SELECT '" + id_acc_trans + "', m.rev_sale_net_acc, m.id_comp_sale, 0, 0.00 AS `credit`, m.rev_sale_net AS `debit`, m.rev_sale_net_note, '256', '" + id_report + "',
                '" + report_number + "', '', m.id_coa_tag
                FROM tb_sales_branch m
                WHERE m.id_sales_branch='" + id_report + "'
                UNION ALL
                SELECT '" + id_acc_trans + "', m.rev_sale_ppn_acc, m.id_comp_sale, 0, 0.00 AS `credit`, m.rev_sale_ppn AS `debit`, m.rev_sale_ppn_note, '256', '" + id_report + "',
                '" + report_number + "', '', m.id_coa_tag
                FROM tb_sales_branch m
                WHERE m.id_sales_branch='" + id_report + "'
                UNION ALL
                SELECT '" + id_acc_trans + "', m.comp_rev_sale_acc, m.id_comp_sale, 0, 0.00 AS `credit`, m.comp_rev_sale AS `debit`, m.comp_rev_sale_note, '256', '" + id_report + "',
                '" + report_number + "', '', m.id_coa_tag
                FROM tb_sales_branch m
                WHERE m.id_sales_branch='" + id_report + "'; "
                execute_non_query(qjd, True, "", "", "", "")

                'get id ref
                Dim id_ref As String = execute_query("SELECT b.id_sales_branch_ref FROM tb_sales_branch b WHERE b.id_sales_branch=" + id_report + "", 0, True, "", "", "", "")
                Dim qcl As String = "UPDATE tb_sales_branch_det main
                INNER JOIN (
	                SELECT d.id_sales_branch_det, d.value-IFNULL(cn.amount_cn,0.00)-IFNULL(rec.value,0.00) AS `bal`
	                FROM tb_sales_branch_det d
	                LEFT JOIN (
	                  SELECT d.id_sales_branch_ref_det, SUM(d.value) AS `amount_cn`
	                  FROM tb_sales_branch_det d
	                  INNER JOIN tb_sales_branch m ON m.id_sales_branch = d.id_sales_branch
	                  WHERE m.id_report_status!=5 AND m.id_sales_branch_ref=" + id_ref + "
	                  GROUP BY d.id_sales_branch_ref_det
	                ) cn ON cn.id_sales_branch_ref_det = d.id_sales_branch_det
	                LEFT JOIN (
	                  SELECT d.id_report_det, SUM(d.value) AS `value`
	                  FROM tb_rec_payment_det d
	                  INNER JOIN tb_rec_payment h ON h.id_rec_payment = d.id_rec_payment
	                  WHERE h.id_report_status!=5 AND d.report_mark_type=254 AND d.id_report=" + id_ref + "
	                  GROUP BY d.id_report_det
	                ) rec ON rec.id_report_det = d.id_sales_branch_det
	                INNER JOIN tb_a_acc coa ON coa.id_acc = d.id_acc
	                INNER JOIN tb_m_comp c ON c.id_comp = d.id_comp
	                WHERE d.id_sales_branch=" + id_ref + " AND d.is_close=2
	                HAVING bal=0
                ) src ON src.id_sales_branch_det = main.id_sales_branch_det
                SET main.is_close=1; "
                execute_non_query(qcl, True, "", "", "", "")
            End If

            'update
            query = String.Format("UPDATE tb_sales_branch Set id_report_status='{0}' WHERE id_sales_branch ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            'refresh view
            Try
                FormSalesBranchDet.actionLoad()
                FormSalesBranch.viewData()
                FormSalesBranch.GVData.FocusedRowHandle = find_row(FormSalesBranch.GVData, "id_sales_branch", id_report)
            Catch ex As Exception
            End Try
        ElseIf report_mark_type = "259" Then
            'close receiving
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                Dim data_odr As DataTable = execute_query("SELECT id_purc_order, close_rec_reason FROM tb_purc_order_close_det WHERE id_close_receiving = " + id_report, -1, True, "", "", "", "")

                For i = 0 To data_odr.Rows.Count - 1
                    Dim query_ss As String = "SELECT IFNULL(SUM(IF(id_report_status = 6, 1, 0)), 0) AS report_6 FROM tb_purc_rec WHERE id_purc_order = " + data_odr.Rows(i)("id_purc_order").ToString

                    Dim data_ss As DataTable = execute_query(query_ss, -1, True, "", "", "", "")

                    Dim query_pay As String = If(data_ss.Rows(0)("report_6").ToString = "0", ", is_close_pay = 1", "")

                    Dim query_update As String = "UPDATE tb_purc_order SET is_close_rec = 1, close_rec_reason = '" + addSlashes(data_odr.Rows(i)("close_rec_reason").ToString) + "'" + query_pay + " WHERE id_purc_order = " + data_odr.Rows(i)("id_purc_order").ToString

                    execute_non_query(query_update, True, "", "", "", "")

                    'reverse budget
                    Dim id_expense_type As String = execute_query("SELECT id_expense_type FROM tb_purc_order WHERE id_purc_order = " + data_odr.Rows(i)("id_purc_order").ToString, 0, True, "", "", "", "")

                    Dim query_budget As String = ""

                    If id_expense_type = "1" Then
                        'opex
                        query_budget = "
                        INSERT INTO tb_b_expense_opex_trans (id_b_expense_opex, id_departement, date_trans, `value`, id_item, id_report, report_mark_type, note)
                        SELECT *
                        FROM (
	                        SELECT p_det.id_b_expense_opex, p.id_departement, NOW() AS date_trans, (IFNULL(r.qty, 0) * o_det.value) - (o_det.qty * o_det.value) AS `value`, p_det.id_item, o_det.id_purc_order AS id_report, 202 AS report_mark_type, 'Close Receiving Reverse' AS note
	                        FROM tb_purc_order_det AS o_det
	                        LEFT JOIN tb_purc_req_det AS p_det ON o_det.id_purc_req_det = p_det.id_purc_req_det
	                        LEFT JOIN tb_purc_req AS p ON p_det.id_purc_req = p.id_purc_req
	                        LEFT JOIN (
		                        SELECT r_det.id_purc_order_det, r_det.qty
		                        FROM tb_purc_rec_det AS r_det
		                        LEFT JOIN tb_purc_rec AS r ON r_det.id_purc_rec = r.id_purc_rec
		                        WHERE r.id_report_status = 6
	                        ) AS r ON o_det.id_purc_order_det = r.id_purc_order_det
	                        WHERE o_det.id_purc_order = " + data_odr.Rows(i)("id_purc_order").ToString + "
                        ) AS tb
                        WHERE `value` < 0
                    "
                    Else
                        'capex
                        query_budget = "
                        INSERT INTO tb_b_expense_trans (id_b_expense, id_departement, date_trans, `value`, id_item, id_report, report_mark_type, note)
                        SELECT *
                        FROM (
	                        SELECT p_det.id_b_expense, p.id_departement, NOW() AS date_trans, (IFNULL(r.qty, 0) * o_det.value) - (o_det.qty * o_det.value) AS `value`, p_det.id_item, o_det.id_purc_order AS id_report, 139 AS report_mark_type, 'Close Receiving Reverse' AS note
	                        FROM tb_purc_order_det AS o_det
	                        LEFT JOIN tb_purc_req_det AS p_det ON o_det.id_purc_req_det = p_det.id_purc_req_det
	                        LEFT JOIN tb_purc_req AS p ON p_det.id_purc_req = p.id_purc_req
	                        LEFT JOIN (
		                        SELECT r_det.id_purc_order_det, r_det.qty
		                        FROM tb_purc_rec_det AS r_det
		                        LEFT JOIN tb_purc_rec AS r ON r_det.id_purc_rec = r.id_purc_rec
		                        WHERE r.id_report_status = 6
	                        ) AS r ON o_det.id_purc_order_det = r.id_purc_order_det
	                        WHERE o_det.id_purc_order = " + data_odr.Rows(i)("id_purc_order").ToString + "
                        ) AS tb
                        WHERE `value` < 0
                    "
                    End If

                    execute_non_query(query_budget, True, "", "", "", "")
                Next
            End If

            'update status
            query = String.Format("UPDATE tb_purc_order_close SET id_report_status='{0}' WHERE id_close_receiving ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "260" Then
            'move est. receive date
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                Dim data_odr As DataTable = execute_query("SELECT id_purc_order, est_date_receive, to_est_date_receive FROM tb_purc_order_move_date_det WHERE id_receive_date = " + id_report, -1, True, "", "", "", "")

                For i = 0 To data_odr.Rows.Count - 1
                    Dim query_update As String = "UPDATE tb_purc_order SET est_date_receive = '" + Date.Parse(data_odr.Rows(i)("to_est_date_receive").ToString).ToString("yyyy-MM-dd") + "' WHERE id_purc_order = " + data_odr.Rows(i)("id_purc_order").ToString

                    execute_non_query(query_update, True, "", "", "", "")
                Next
            End If

            'update status
            query = String.Format("UPDATE tb_purc_order_move_date SET id_report_status='{0}' WHERE id_receive_date ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "264" Then
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If
            'update status
            query = String.Format("UPDATE tb_list_payout_trans SET id_report_status='{0}' WHERE id_list_payout_trans ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "265" Then
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If
            'update status
            query = String.Format("UPDATE tb_virtual_acc_trans SET id_report_status='{0}' WHERE id_virtual_acc_trans ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "268" Then
            'WIP Stock Summary Report
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            'update status
            query = String.Format("UPDATE tb_wip_summary SET id_report_status='{0}' WHERE id_wip_summary ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "269" Then
            'Material & Trims Stock Summary Report
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            'update status
            query = String.Format("UPDATE tb_mat_summary SET id_report_status='{0}' WHERE id_mat_summary ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "270" Then
            'move est. receive date
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                Dim data_odr As DataTable = execute_query("SELECT id_purc_order, est_date_receive, to_est_date_receive FROM tb_purc_order_move_date_det WHERE id_receive_date = " + id_report, -1, True, "", "", "", "")

                For i = 0 To data_odr.Rows.Count - 1
                    Dim query_update As String = "UPDATE tb_purc_order SET est_date_receive = '" + Date.Parse(data_odr.Rows(i)("to_est_date_receive").ToString).ToString("yyyy-MM-dd") + "' WHERE id_purc_order = " + data_odr.Rows(i)("id_purc_order").ToString

                    execute_non_query(query_update, True, "", "", "", "")
                Next
            End If

            'update status
            query = String.Format("UPDATE tb_purc_order_move_date SET id_report_status='{0}' WHERE id_receive_date ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "273" Then
            '
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                Dim material_image_path As String = get_setup_field("pic_path_mat") & "\"
                Dim id_mat_det As String = ""
                Dim qi As String = ""

                Dim qc As String = "SELECT pps.is_active ,pps.id_mat, pps.mat_det_display_name, pps.mat_det_name, pps.mat_det_code, pps.id_method, pps.lifetime, NOW() AS mat_det_date, 2 AS allow_design, NULL AS id_fab_type, 0 AS gramasi,pps.id_range,is_revise,id_mat_det_revise,id_comp_contact,id_currency,fob_price FROM tb_m_mat_det_pps pps WHERE pps.`id_mat_det_pps`='" & id_report & "'"
                Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")

                If dtc.Rows.Count > 0 Then
                    If dtc.Rows(0)("is_revise").ToString = "1" Then 'revisi
                        id_mat_det = dtc.Rows(0)("id_mat_det_revise").ToString
                        '
                        qi = String.Format("UPDATE tb_m_mat_det SET id_mat='{1}', mat_det_display_name='{2}', mat_det_name='{3}', mat_det_code='{4}', id_method='{5}', lifetime='{6}', mat_det_date=NOW(), allow_design=2, id_fab_type=NULL, gramasi=0,id_range='{7}',is_active='{8}' WHERE id_mat_det='{0}'", id_mat_det, dtc.Rows(0)("id_mat").ToString, dtc.Rows(0)("mat_det_display_name").ToString, dtc.Rows(0)("mat_det_name").ToString, dtc.Rows(0)("mat_det_code").ToString, dtc.Rows(0)("id_method").ToString, dtc.Rows(0)("lifetime").ToString, dtc.Rows(0)("id_range").ToString, dtc.Rows(0)("is_active").ToString)
                        execute_non_query(qi, True, "", "", "", "")
                        'fob price
                        qi = String.Format("UPDATE tb_m_mat_det_price SET is_default_po='2' WHERE id_mat_det='{0}'", id_mat_det)
                        execute_non_query(qi, True, "", "", "", "")
                        qi = String.Format("INSERT INTO tb_m_mat_det_price(id_mat_det,mat_det_price_name,id_currency,id_comp_contact,mat_det_price,mat_det_price_date,is_default_cost,is_default_po) VALUES('{0}','FOB Price','{1}','{2}','{3}',DATE(NOW()),'2','1')", id_mat_det, dtc.Rows(0)("id_currency").ToString, dtc.Rows(0)("id_comp_contact").ToString, decimalSQL(Decimal.Parse(dtc.Rows(0)("fob_price").ToString).ToString))
                        execute_non_query(qi, True, "", "", "", "")

                        'image
                        If Not FormMasterRawMatPps.PictureEdit1.EditValue Is Nothing Then
                            save_image_ori(FormMasterRawMatPps.PictureEdit1, material_image_path, id_mat_det & ".jpg")
                        End If

                        'detail code
                        qi = String.Format("DELETE FROM tb_m_mat_det_code WHERE id_mat_det='{0}'", id_mat_det)
                        execute_non_query(qi, True, "", "", "", "")
                        qi = String.Format("INSERT INTO tb_m_mat_det_code(id_mat_det, id_code_detail) SELECT '{0}' AS id_mat_det,id_code_detail FROM tb_m_mat_det_pps_code WHERE id_mat_det_pps='{1}'", id_mat_det, id_report)
                        execute_non_query(qi, True, "", "", "", "")
                    Else
                        qi = "INSERT INTO tb_m_mat_det(id_mat, mat_det_display_name, mat_det_name, mat_det_code, id_method, lifetime, mat_det_date, allow_design, id_fab_type, gramasi,id_range, is_active) "
                        qi += "SELECT pps.id_mat, pps.mat_det_display_name, pps.mat_det_name, pps.mat_det_code, pps.id_method, pps.lifetime, NOW() AS mat_det_date, 2 AS allow_design, NULL AS id_fab_type, 0 AS gramasi,pps.id_range,pps.is_active
FROM tb_m_mat_det_pps pps
WHERE pps.`id_mat_det_pps`='" & id_report & "';SELECT LAST_INSERT_ID() "

                        id_mat_det = execute_query(qi, 0, True, "", "", "", "")

                        'fob price
                        qi = String.Format("INSERT INTO tb_m_mat_det_price(id_mat_det,mat_det_price_name,id_currency,id_comp_contact,mat_det_price,mat_det_price_date,is_default_cost,is_default_po) VALUES('{0}','FOB Price','{1}','{2}','{3}',DATE(NOW()),'2','1')", id_mat_det, dtc.Rows(0)("id_currency").ToString, dtc.Rows(0)("id_comp_contact").ToString, decimalSQL(Decimal.Parse(dtc.Rows(0)("fob_price").ToString).ToString))
                        execute_non_query(qi, True, "", "", "", "")

                        'image
                        If Not FormMasterRawMatPps.PictureEdit1.EditValue Is Nothing Then
                            save_image_ori(FormMasterRawMatPps.PictureEdit1, material_image_path, id_mat_det & ".jpg")
                        End If

                        qi = String.Format("DELETE FROM tb_m_mat_det_code WHERE id_mat_det='{0}'", id_mat_det)
                        execute_non_query(qi, True, "", "", "", "")
                        qi = String.Format("INSERT INTO tb_m_mat_det_code(id_mat_det, id_code_detail) SELECT '{0}' AS id_mat_det,id_code_detail FROM tb_m_mat_det_pps_code WHERE id_mat_det_pps='{1}'", id_mat_det, id_report)
                        execute_non_query(qi, True, "", "", "", "")
                    End If
                End If
            End If

            'update status
            query = String.Format("UPDATE tb_m_mat_det_pps SET id_report_status='{0}' WHERE id_mat_det_pps ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "274" Then
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                Dim q As String = "SELECT pps.`id_type`,SUM(ppsd.`qty`*ppsd.`value`) AS amount,SUM(ppsd.`qty_est`*ppsd.`value_est`) AS amount_est,ppsdsg.qty_order,SUM(ppsd.`qty`*ppsd.`value`)/ppsdsg.qty_order AS cost,SUM(ppsd.`qty_est`*ppsd.`value_est`)/ppsdsg.qty_order AS cost_est
FROM `tb_additional_cost_pps_det` ppsd
INNER JOIN `tb_additional_cost_pps` pps ON pps.`id_additional_cost_pps`=ppsd.`id_additional_cost_pps`
LEFT JOIN 
(
	SELECT SUM(qty_order) AS qty_order ,id_additional_cost_pps
	FROM `tb_additional_cost_pps_design`
	GROUP BY id_additional_cost_pps
)ppsdsg ON ppsdsg.id_additional_cost_pps=pps.id_additional_cost_pps
WHERE pps.id_additional_cost_pps='" & id_report & "'"
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                If dt.Rows.Count > 0 Then
                    If dt.Rows(0)("id_type").ToString = "1" Then
                        'ecop

                    ElseIf dt.Rows(0)("id_type").ToString = "2" Then
                        'realization

                    End If
                End If
            End If
        ElseIf report_mark_type = "280" Then
            'Invoice FGPO
            'auto completed
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                'select detail
                Dim pn_date As String = ""
                Dim ref_date As String = ""

                Dim q_head As String = "SELECT id_inv_claim_other,created_date,ref_date FROM tb_inv_claim_other WHERE id_inv_claim_other='" & id_report & "'"
                Dim dt_head As DataTable = execute_query(q_head, -1, True, "", "", "", "")
                If dt_head.Rows.Count > 0 Then
                    pn_date = Date.Parse(dt_head.Rows(0)("created_date").ToString).ToString("yyyy-MM-dd")
                    ref_date = Date.Parse(dt_head.Rows(0)("ref_date").ToString).ToString("yyyy-MM-dd")
                End If

                'Select user prepared
                Dim qu As String = "SELECT rm.id_user, rm.report_number FROM tb_report_mark rm WHERE rm.report_mark_type=" + report_mark_type + " AND rm.id_report='" + id_report + "' AND rm.id_report_status=1 "
                Dim du As DataTable = execute_query(qu, -1, True, "", "", "", "")
                Dim id_user_prepared As String = du.Rows(0)("id_user").ToString
                Dim report_number As String = du.Rows(0)("report_number").ToString

                'main journal
                Dim qjm As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, date_reference, acc_trans_note, id_report_status)
                        VALUES ('','" + report_number + "','24','" + id_user_prepared + "', NOW(), '" & ref_date & "', 'Auto Posting', '6'); SELECT LAST_INSERT_ID(); "
                Dim id_acc_trans As String = execute_query(qjm, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id_acc_trans + ",36)", True, "", "", "", "")

                'det journal
                Dim qjd As String = ""
                qjd = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, id_vendor, id_comp, qty, debit, credit, id_currency,kurs,debit_valas,credit_valas, acc_trans_det_note, report_mark_type, id_report, report_number, report_mark_type_ref, id_report_ref, report_number_ref, vendor)
                SELECT * FROM
                (
	               /* Per row */
                    SELECT '" & id_acc_trans & "' AS id_acc_trans,pnd.id_acc AS `id_acc`,pn.id_comp AS id_vendor, cf.id_comp,SUM(pnd.`qty`) AS `qty`,IF(SUM(pnd.value)>0,0,-SUM(pnd.value)) AS `debit`,IF(SUM(pnd.value)<0,0,SUM(pnd.value)) AS `credit`,pnd.id_currency,pnd.kurs,IF(pnd.id_currency=1,0,IF(SUM(pnd.value_bef_kurs)<0,0,SUM(pnd.value_bef_kurs))) AS `debit_valas`,IF(pnd.id_currency=1,0,IF(SUM(pnd.value_bef_kurs)>0,0,-SUM(pnd.value_bef_kurs))) AS `credit_valas`,pnd.`note` AS `note`,280,pn.id_inv_claim_other, pn.number, pnd.report_mark_type, pnd.id_report, pnd.report_number, comp.comp_number
                    FROM tb_inv_claim_other_det pnd
                    INNER JOIN tb_m_comp cf ON cf.id_comp=1
                    INNER JOIN tb_inv_claim_other pn ON pnd.id_inv_claim_other=pn.id_inv_claim_other
                    INNER JOIN tb_m_comp comp ON comp.id_comp=pn.id_comp
                    WHERE pn.id_inv_claim_other=" & id_report & "
                    GROUP BY pnd.id_inv_claim_other_det
                    UNION ALL
                    /* PPN */
                    SELECT '" & id_acc_trans & "' AS id_acc_trans,pn.id_acc_vat AS `id_acc`,pn.id_comp AS id_vendor, cf.id_comp,0 AS `qty`,IF(SUM(pnd.vat)>0,0,-SUM(pnd.vat)) AS `debit`,IF(SUM(pnd.vat)<0,0,SUM(pnd.vat)) AS `credit`,1 AS id_currency,1 AS kurs,0 AS debit_valas,0 AS credit_valas,pnd.`note` AS `note`,280,pn.id_inv_claim_other, pn.number, pnd.report_mark_type, pnd.id_report, pnd.report_number, comp.comp_number
                    FROM tb_inv_claim_other_det pnd
                    INNER JOIN tb_m_comp cf ON cf.id_comp=1
                    INNER JOIN tb_inv_claim_other pn ON pnd.id_inv_claim_other=pn.id_inv_claim_other
                    INNER JOIN tb_m_comp comp ON comp.id_comp=pn.id_comp
                    WHERE pn.id_inv_claim_other=" & id_report & "
                    GROUP BY pn.id_inv_claim_other
                    UNION ALL
                    /* AR */
                    SELECT '" & id_acc_trans & "' AS id_acc_trans,comp.id_acc_ar AS `id_acc`,pn.id_comp AS id_vendor, cf.id_comp,0 AS `qty`,IF(SUM(pnd.value + pnd.vat)<0,0,SUM(pnd.value + pnd.vat)) AS `debit`,IF(SUM(pnd.value + pnd.vat)>0,0,-SUM(pnd.value + pnd.vat)) AS `credit`,pnd.id_currency,pnd.kurs,IF(pnd.id_currency=1,0,IF(SUM(pnd.value_bef_kurs + pnd.vat)>0,0,-SUM(pnd.value_bef_kurs + pnd.vat))) AS `debit_valas`,IF(pnd.id_currency=1,0,IF(SUM(pnd.value_bef_kurs + pnd.vat)<0,0,SUM(pnd.value_bef_kurs + pnd.vat))) AS `credit_valas`,pnd.note AS `note`,280,pn.id_inv_claim_other, pn.number, pnd.report_mark_type, pnd.id_report, pnd.report_number, comp.comp_number
                    FROM tb_inv_claim_other_det pnd
                    INNER JOIN tb_m_comp cf ON cf.id_comp=1
                    INNER JOIN tb_inv_claim_other pn ON pnd.id_inv_claim_other=pn.id_inv_claim_other
                    INNER JOIN tb_m_comp comp ON comp.id_comp=pn.id_comp
                    WHERE pn.id_inv_claim_other=" & id_report & "
                    GROUP BY pn.id_inv_claim_other
                )trx WHERE trx.debit != 0 OR trx.credit != 0"
                execute_non_query(qjd, True, "", "", "", "")
            End If

            'update
            query = String.Format("UPDATE tb_inv_claim_other SET id_report_status='{0}' WHERE id_inv_claim_other ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "241" Then
            'adj og
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                FormAdjustmentOGDet.update_changes()
            End If

            'update status
            query = String.Format("UPDATE tb_adjustment_og SET id_report_status='{0}' WHERE id_adjustment ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "281" Then
            'price recon
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                Dim query_prc_valid As String = "UPDATE tb_sales_pos_prob main
                INNER JOIN tb_sales_pos_recon_det rd ON rd.id_sales_pos_prob = main.id_sales_pos_prob AND rd.id_sales_pos_recon=" + id_report + "
                SET main.id_design_price_valid = rd.id_design_price_valid, main.design_price_valid = rd.design_price_valid
                WHERE main.is_invalid_price=1 "
                execute_non_query(query_prc_valid, True, "", "", "", "")
            End If

            'update status
            query = String.Format("UPDATE tb_sales_pos_recon SET id_report_status='{0}' WHERE id_sales_pos_recon ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "282" Then
            'payout zalora
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            'update status
            query = String.Format("UPDATE tb_payout_zalora SET id_report_status='{0}' WHERE id_payout_zalora ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "283" Then
            'closing no stok
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            'update status
            query = String.Format("UPDATE tb_sales_pos_oos_recon SET id_report_status='{0}' WHERE id_sales_pos_oos_recon ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "287" Then
            'depresiasi
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                'masukkan ke tabel depresiasi
                Dim qi As String = "INSERT INTO `tb_purc_rec_asset_dep`(`id_purc_rec_asset`,`id_asset_dep_pps`,`period`,`amount`)
SELECT psd.id_purc_rec_asset,psd.id_asset_dep_pps,ps.`reff_date`,psd.dep_value
FROM `tb_asset_dep_pps_det` psd
INNER JOIN tb_asset_dep_pps ps ON ps.`id_asset_dep_pps`=psd.`id_asset_dep_pps`
WHERE psd.id_asset_dep_pps='" & id_report & "'"
                execute_non_query(qi, True, "", "", "", "")

                'main journal
                Dim qjm As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, acc_trans_note, id_report_status,date_reference) 
                VALUES ('','" + report_number + "','0','" + id_user + "', NOW(), 'Auto Posting', '6', (SELECT reff_date FROM tb_asset_dep_pps WHERE id_asset_dep_pps='" & id_report & "')); SELECT LAST_INSERT_ID(); "
                Dim id_acc_trans As String = execute_query(qjm, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id_acc_trans + ",36)", True, "", "", "", "")

                'det journal
                Dim qjd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_comp, id_acc, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number,id_coa_tag)
            SELECT '" + id_acc_trans + "',1, dep.id_acc_dep, dep.dep_value, 0, CONCAT('DEPRECIATION - ',a.asset_name,'(',DATE_FORMAT(dep_head.reff_date,'%M %Y'),')'), 287, dep_head.id_asset_dep_pps, dep_head.number,dep_head.id_coa_tag
FROM tb_asset_dep_pps_det dep
INNER JOIN tb_asset_dep_pps dep_head ON dep_head.id_asset_dep_pps=dep.id_asset_dep_pps
INNER JOIN tb_purc_rec_asset a ON a.id_purc_rec_asset = dep.id_purc_rec_asset
WHERE dep.id_asset_dep_pps='" + id_report + "'
UNION ALL
SELECT '" + id_acc_trans + "',1, dep.id_acc_dep_accum, 0, dep.dep_value,  CONCAT('ACCUM. DEPRECIATION - ',a.asset_name,'(',DATE_FORMAT(dep_head.reff_date,'%M %Y'),')'), 287, dep_head.id_asset_dep_pps, dep_head.number,dep_head.id_coa_tag
FROM tb_asset_dep_pps_det dep
INNER JOIN tb_asset_dep_pps dep_head ON dep_head.id_asset_dep_pps=dep.id_asset_dep_pps
INNER JOIN tb_purc_rec_asset a ON a.id_purc_rec_asset = dep.id_purc_rec_asset
WHERE dep.id_asset_dep_pps='" + id_report + "'"
                'Console.WriteLine("Insert jurnal")
                execute_non_query(qjd, True, "", "", "", "")
            End If

            'update status
            query = String.Format("UPDATE tb_asset_dep_pps SET id_report_status='{0}' WHERE id_asset_dep_pps ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "284" Then
            'summary tax
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            'update status
            query = String.Format("UPDATE tb_tax_pph_summary SET id_report_status='{0}' WHERE id_summary ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "288" Then
            'setup tax
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                execute_non_query("UPDATE tb_tax_report_monthly SET is_active = 2 WHERE date_start IN (SELECT month_year FROM tb_setup_tax_installment_det WHERE id_setup_tax = " + id_report + ")", True, "", "", "", "")

                execute_non_query("
                    INSERT INTO tb_tax_report_monthly (id_coa_tag, id_tax_report, tax_value, date_start, date_end, is_active)
                    SELECT s.id_coa_tag, s.id_tax_report, t.balance AS tax_value, t.month_year AS date_start, LAST_DAY(t.month_year) AS date_end, 1 AS is_active
                    FROM tb_setup_tax_installment_det AS t
                    LEFT JOIN tb_setup_tax_installment AS s ON t.id_setup_tax = s.id_setup_tax
                    WHERE t.id_setup_tax = " + id_report + "
                ", True, "", "", "", "")
            End If

            'update status
            query = String.Format("UPDATE tb_setup_tax_installment SET id_report_status='{0}' WHERE id_setup_tax ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "290" Then
            'refuse return online
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If


            'if completed
            If id_status_reportx = "6" Then
                Dim qry As String = "-- kembalikan book stock
                DELETE FROM tb_storage_fg WHERE report_mark_type_ref=" + report_mark_type + " AND id_report_ref =" + id_report + ";
                INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status, report_mark_type_ref, id_report_ref)
                SELECT getCompByContact(ro.id_store_contact, 4),1, p.id_product, d.design_cop, 119, ror_det.id_sales_return_order, rod.qty,NOW(), 'Auto',2, " + report_mark_type + ", " + id_report + "
                FROM tb_ol_store_return_refuse ro
                INNER JOIN tb_ol_store_return_refuse_det rod ON rod.id_return_refuse = ro.id_return_refuse
                INNER JOIN tb_m_product p ON p.id_product = rod.id_product
                INNER JOIN tb_m_design d ON d.id_design = p.id_design
                INNER JOIN tb_sales_return_order_det ror_det ON ror_det.id_sales_return_order_det = rod.id_sales_return_order_det
                WHERE ro.id_return_refuse=" + id_report + " AND rod.qty>0; 
                -- update void ror
                UPDATE tb_sales_return_order_det main 
                INNER JOIN (
                    SELECT d.id_sales_return_order_det 
                    FROM tb_ol_store_return_refuse_det d
                    WHERE d.id_return_refuse=" + id_report + " AND !ISNULL(d.id_sales_return_order_det)
                ) src ON main.id_sales_return_order_det = src.id_sales_return_order_det
                SET main.is_void=1; "
                execute_non_query(qry, True, "", "", "", "")
            End If

            'update status
            query = String.Format("UPDATE tb_ol_store_return_refuse SET id_report_status='{0}' WHERE id_return_refuse ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "289" Then
            'Asset In Out
            If id_status_reportx = "5" Then
                'revert
                Dim q As String = "INSERT INTO `tb_stock_card_dep`(id_departement,id_item_detail,id_report,id_report_det,report_mark_type,qty,storage_item_datetime)
SELECT it.id_departement,itd.id_item_detail,it.id_item_card_trs,itd.id_item_card_trs_det,'289' AS rmt,IF(it.id_type=1,1,-1)*SUM(qty) AS qty,NOW()
FROM tb_item_card_trs_det itd
INNER JOIN tb_item_card_trs it ON it.id_item_card_trs=itd.id_item_card_trs
WHERE it.id_item_card_trs='" & id_report & "' AND it.id_type=1 GROUP BY itd.id_item_detail"
                execute_query(q, -1, True, "", "", "", "")
            ElseIf id_status_reportx = "6" Then
                'complete in
                Dim q As String = "INSERT INTO `tb_stock_card_dep`(id_departement,id_item_detail,id_report,id_report_det,report_mark_type,qty,storage_item_datetime)
SELECT it.id_departement,itd.id_item_detail,it.id_item_card_trs,itd.id_item_card_trs_det,'289' AS rmt,IF(it.id_type=1,-1,1)*SUM(qty) AS qty,NOW()
FROM tb_item_card_trs_det itd
INNER JOIN tb_item_card_trs it ON it.id_item_card_trs=itd.id_item_card_trs
WHERE it.id_item_card_trs='" & id_report & "' AND it.id_type=2 GROUP BY itd.id_item_detail"
                execute_query(q, -1, True, "", "", "", "")

                'auto item request
                Dim qir As String = "INSERT INTO `tb_item_req`(`id_departement`,`created_date`,`created_by`,`note`,`id_report_status`,`is_for_store`)
SELECT it.id_departement,NOW(),'" & id_user & "' AS id_user,'','6','1'
FROM tb_item_card_trs it 
WHERE it.id_item_card_trs='" & id_report & "' AND it.id_purc_rec != "" AND NOT ISNULL(it.id_purc_rec) AND it.id_purc_rec !='0'"
                Dim id_ir As String = execute_query(qir, 0, True, "", "", "", "")

                execute_non_query("CALL gen_number(" + id_ir + ",163)", True, "", "", "", "")

                qir = "INSERT INTO `tb_item_req_det`(id_item_req, id_item, qty, is_store_request, remark)
SELECT '" & id_ir & "' AS id_item_req,itsd.id_item,IF(it.id_type=1,1,0)*SUM(qty) AS qty,1 AS is_store_request,'' AS remark
FROM tb_item_card_trs_det itd
INNER JOIN tb_item_card_trs it ON it.id_item_card_trs=itd.id_item_card_trs
INNER JOIN `tb_stock_card_dep_item` itsd ON itsd.id_item_detail=itd.id_item_detail
WHERE 
it.id_item_card_trs='" & id_report & "' AND 
it.id_type=1
GROUP BY itsd.id_item
HAVING qty>0"
                execute_non_query(qir, True, "", "", "", "")

                'allocation
                qir = "INSERT `tb_item_req_det_alloc`(`id_item_req`,`is_store_request`,`id_item`,`id_comp`,`qty`)
SELECT '" & id_ir & "' AS id_item_req,'1' AS is_store_request,itsd.id_item,it.id_store,IF(it.id_type=1,1,0)*SUM(qty) AS qty
FROM tb_item_card_trs_det itd
INNER JOIN tb_item_card_trs it ON it.id_item_card_trs=itd.id_item_card_trs
INNER JOIN `tb_stock_card_dep_item` itsd ON itsd.id_item_detail=itd.id_item_detail
WHERE 
it.id_item_card_trs='" & id_report & "' AND 
it.id_type=1
GROUP BY itsd.id_item
HAVING qty>0"
                execute_non_query(qir, True, "", "", "", "")
            End If

            'update status
            query = String.Format("UPDATE tb_item_card_trs SET id_report_status='{0}' WHERE id_item_card_trs ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "292" Then
            ' CANCEL CN
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "5" Then
                Dim cancel_rsv_stock As ClassSalesInv = New ClassSalesInv()

                If FormSalesPOSDet.is_use_unique_code = "1" Then
                    'cancelled unique
                    cancel_rsv_stock.cancellUnique(id_report, report_mark_type)
                End If

                'cancelled
                cancel_rsv_stock.cancelReservedStock(id_report, report_mark_type)
            ElseIf id_status_reportx = "6" Then
                'completed
                Dim complete_rsv_stock As ClassSalesInv = New ClassSalesInv()
                complete_rsv_stock.completedStock(id_report, report_mark_type)

                'set is_cancel_trans
                Dim qct As String = "UPDATE tb_sales_pos_det main 
                INNER JOIN (
	                SELECT spd.id_cn_det 
	                FROM tb_sales_pos_det spd
	                WHERE spd.id_sales_pos=" + id_report + "
                ) src ON src.id_cn_det = main.id_sales_pos_det
                SET main.is_cancel_trans=1 "
                execute_non_query(qct, True, "", "", "", "")
            End If

            'update status
            query = String.Format("UPDATE tb_sales_pos SET id_report_status='{0}' WHERE id_sales_pos ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")

            If form_origin = "FormSalesPOSDet" Then
                FormSalesPOSDet.LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_status_reportx)
                FormSalesPOSDet.check_but()
                FormSalesPOSDet.actionLoad()
                FormSalesPOS.viewSalesPOS()
                FormSalesPOS.GVSalesPOS.FocusedRowHandle = find_row(FormSalesPOS.GVSalesPOS, "id_sales_pos", id_report)
            End If
        ElseIf report_mark_type = "293" Then
            'summary tax
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            'update status
            query = String.Format("UPDATE tb_tax_ppn_summary SET id_report_status='{0}' WHERE id_summary ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "294" Then
            'alokasi biaya bulanan
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                'masukkan ke tabel alokasi bulanan
                Dim qi As String = "INSERT INTO `tb_biaya_sewa_teralokasi`(`id_biaya_sewa`,`id_biaya_sewa_bulanan`,`reff_date`,`amount`)
SELECT psd.id_biaya_sewa,psd.id_biaya_sewa_bulanan,ps.`reff_date`,psd.alokasi_biaya_per_bulan
FROM `tb_biaya_sewa_bulanan_det` psd
INNER JOIN tb_biaya_sewa_bulanan ps ON ps.`id_asset_dep_pps`=psd.`id_asset_dep_pps`
WHERE psd.id_biaya_sewa_bulanan='" & id_report & "'"
                execute_non_query(qi, True, "", "", "", "")

                'main journal
                Dim qjm As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, acc_trans_note, id_report_status,date_reference) 
                VALUES ('','" + report_number + "','0','" + id_user + "', NOW(), 'Auto Posting', '6', (SELECT reff_date FROM tb_biaya_sewa_bulanan WHERE id_biaya_sewa_bulanan='" & id_report & "')); SELECT LAST_INSERT_ID(); "
                Dim id_acc_trans As String = execute_query(qjm, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id_acc_trans + ",36)", True, "", "", "", "")

                'det journal
                Dim qjd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_comp, id_acc, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number,id_coa_tag)
            SELECT '" + id_acc_trans + "',1, dep.coa_uang_muka, 0, dep.alokasi_biaya_per_bulan,  CONCAT('Alokasi Biaya - ',a.description,'(',DATE_FORMAT(dep_head.reff_date,'%M %Y'),')'), 294, dep_head.id_biaya_sewa_bulanan, dep_head.number,dep_head.id_coa_tag
FROM `tb_biaya_sewa_bulanan_det` dep
INNER JOIN tb_biaya_sewa_bulanan dep_head ON dep_head.id_biaya_sewa_bulanan=dep.id_biaya_sewa_bulanan
INNER JOIN tb_biaya_sewa a ON a.id_biaya_sewa = dep.id_biaya_sewa
WHERE dep.id_biaya_sewa_bulanan='" + id_report + "'
UNION ALL
SELECT '" + id_acc_trans + "',1, dep.coa_biaya, dep.alokasi_biaya_per_bulan, 0,   CONCAT('Alokasi Biaya - ',a.description,'(',DATE_FORMAT(dep_head.reff_date,'%M %Y'),')'), 294, dep_head.id_biaya_sewa_bulanan, dep_head.number,dep_head.id_coa_tag
FROM `tb_biaya_sewa_bulanan_det` dep
INNER JOIN tb_biaya_sewa_bulanan dep_head ON dep_head.id_biaya_sewa_bulanan=dep.id_biaya_sewa_bulanan
INNER JOIN tb_biaya_sewa a ON a.id_biaya_sewa = dep.id_biaya_sewa
WHERE dep.id_biaya_sewa_bulanan='" + id_report + "'"
                'Console.WriteLine("Insert jurnal")
                execute_non_query(qjd, True, "", "", "", "")
            End If

            'update status
            query = String.Format("UPDATE tb_biaya_sewa_bulanan SET id_report_status='{0}' WHERE id_biaya_sewa_bulanan ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "295" Then
            'master alokasi biaya bulanan
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                'masukkan ke master alokasi bulanan
                Dim qi As String = "INSERT INTO `tb_biaya_sewa`(`description`,`date_reff`,`total_uang_muka`,`total_bulan`,`coa_prepaid_non_current`,`coa_uang_muka`,`coa_biaya`,`is_active`,`insert_date`,`insert_by`,`id_coa_tag`)
SELECT ppsd.`description`,ppsd.`date_reff`,ppsd.`total_uang_muka`,ppsd.`total_bulan`,ppsd.`coa_prepaid_non_current`,ppsd.`coa_uang_muka`,ppsd.`coa_biaya`,1,NOW(),pps.created_by,pps.id_coa_tag
FROM `tb_biaya_sewa_pps_det` ppsd
INNER JOIN tb_biaya_sewa_pps pps ON pps.id_biaya_sewa_pps=ppsd.id_biaya_sewa_pps AND pps.id_biaya_sewa_pps='" & id_report & "'"
                execute_non_query(qi, True, "", "", "", "")

                'main journal
                Dim qjm As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, acc_trans_note, id_report_status,date_reference) 
            VALUES ('','" + report_number + "','0','" + id_user + "', NOW(), 'Auto Posting', '6', NOW()); SELECT LAST_INSERT_ID(); "
                Dim id_acc_trans As String = execute_query(qjm, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id_acc_trans + ",36)", True, "", "", "", "")

                'det journal
                Dim qjd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_comp, id_acc, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number,id_coa_tag)
SELECT '" + id_acc_trans + "',1, dep.coa_prepaid_non_current, 0, dep.total_uang_muka,  CONCAT('Alokasi Biaya - ',dep.description,' untuk ',dep.`total_bulan`,' bulan') AS note, 295, dep_head.id_biaya_sewa_pps, dep_head.number,dep_head.id_coa_tag
FROM `tb_biaya_sewa_pps_det` dep
INNER JOIN tb_biaya_sewa_pps dep_head ON dep_head.id_biaya_sewa_pps=dep.id_biaya_sewa_pps
WHERE dep.id_biaya_sewa_pps='" + id_report + "'
UNION ALL
SELECT '" + id_acc_trans + "',1, dep.coa_prepaid_non_current, dep.total_uang_muka, 0,  CONCAT('Alokasi Biaya - ',dep.description,' untuk ',dep.`total_bulan`,' bulan') AS note, 295, dep_head.id_biaya_sewa_pps, dep_head.number,dep_head.id_coa_tag
FROM `tb_biaya_sewa_pps_det` dep
INNER JOIN tb_biaya_sewa_pps dep_head ON dep_head.id_biaya_sewa_pps=dep.id_biaya_sewa_pps
WHERE dep.id_biaya_sewa_pps='" + id_report + "'"
                'Console.WriteLine("Insert jurnal")
                execute_non_query(qjd, True, "", "", "", "")
            End If

            'update status
            query = String.Format("UPDATE tb_biaya_sewa_pps SET id_report_status='{0}' WHERE id_biaya_sewa_pps ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "298" Then
            'Fixed Asset Sell or Drop
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                'update not active
                Dim qi As String = "UPDATE tb_purc_rec_asset ass
INNER JOIN tb_purc_rec_asset_disp_det dd ON dd.id_purc_rec_asset=ass.id_purc_rec_asset
SET ass.is_active='2',ass.active_reff=dd.id_purc_rec_asset_disp
WHERE dd.id_purc_rec_asset_disp='" & id_report & "'"
                execute_non_query(qi, True, "", "", "", "")

                'main journal
                Dim qjm As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, acc_trans_note, id_report_status,date_reference) 
            VALUES ('','" + report_number + "','0','" + id_user + "', NOW(), 'Auto Posting', '6', (SELECT date_reff FROM tb_purc_rec_asset_disp WHERE id_purc_rec_asset_disp='" & id_report & "')); SELECT LAST_INSERT_ID(); "
                Dim id_acc_trans As String = execute_query(qjm, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id_acc_trans + ",36)", True, "", "", "", "")

                'det journal belum kelar
                Dim qjd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_comp, id_acc, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number,id_coa_tag)
-- perolehan
SELECT '" + id_acc_trans + "',1, dep.id_acc_fa, 0, dep.total_value,  CONCAT(IF(dep_head.is_sell=1,'Penjualan Fixed Asset ','Penghapysan Fixed Asset '),'(',ass.asset_note,')') AS note, 298, dep_head.id_purc_rec_asset_disp, dep_head.number,dep_head.id_coa_tag
FROM `tb_purc_rec_asset_disp_det` dep
INNER JOIN tb_purc_rec_asset_disp dep_head ON dep_head.id_purc_rec_asset_disp=dep.id_purc_rec_asset_disp
INNER JOIN tb_purc_rec_asset ass ON dep.id_purc_rec_asset=ass.id_purc_rec_asset
WHERE dep.id_purc_rec_asset_disp='" + id_report + "'
UNION ALL
-- kerugian
SELECT '" + id_acc_trans + "',1, dep_head.coa_kerugian, dep.rem_value, 0, CONCAT(IF(dep_head.is_sell=1,'Penjualan Fixed Asset ','Penghapysan Fixed Asset '),'(',ass.asset_note,')') AS note, 298, dep_head.id_purc_rec_asset_disp, dep_head.number,dep_head.id_coa_tag
FROM `tb_purc_rec_asset_disp_det` dep
INNER JOIN tb_purc_rec_asset_disp dep_head ON dep_head.id_purc_rec_asset_disp=dep.id_purc_rec_asset_disp
INNER JOIN tb_purc_rec_asset ass ON dep.id_purc_rec_asset=ass.id_purc_rec_asset
WHERE dep.id_purc_rec_asset_disp='" + id_report + "' AND dep.rem_value>0
UNION ALL
-- akumulasi
SELECT '" + id_acc_trans + "',1, dep.id_acc_dep_accum, (dep.total_value-dep.rem_value), 0, CONCAT(IF(dep_head.is_sell=1,'Penjualan Fixed Asset ','Penghapysan Fixed Asset '),'(',ass.asset_note,')') AS note, 298, dep_head.id_purc_rec_asset_disp, dep_head.number,dep_head.id_coa_tag
FROM `tb_purc_rec_asset_disp_det` dep
INNER JOIN tb_purc_rec_asset_disp dep_head ON dep_head.id_purc_rec_asset_disp=dep.id_purc_rec_asset_disp
INNER JOIN tb_purc_rec_asset ass ON dep.id_purc_rec_asset=ass.id_purc_rec_asset
WHERE dep.id_purc_rec_asset_disp='" + id_report + "' AND (dep.total_value-dep.rem_value)>0
"
                'Console.WriteLine("Insert jurnal")
                execute_non_query(qjd, True, "", "", "", "")
            End If

            'update status
            query = String.Format("UPDATE tb_purc_rec_asset_disp SET id_report_status='{0}' WHERE id_purc_rec_asset_disp ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "299" Then
            'Product Weight
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                'update tb_m_product
                Dim qi As String = "UPDATE tb_m_product p
INNER JOIN tb_product_weight_pps_det pps ON pps.id_product=p.id_product
SET p.qc_weight=pps.weight
WHERE pps.id_product_weight_pps='" & id_report & "'"
                execute_non_query(qi, True, "", "", "", "")
            End If

            'update status
            query = String.Format("UPDATE tb_product_weight_pps SET id_report_status='{0}' WHERE id_product_weight_pps ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        ElseIf report_mark_type = "300" Then
            'foc og
            If id_status_reportx = "3" Then
                id_status_reportx = "6"
            End If

            If id_status_reportx = "6" Then
                FormPurcReceiveFOCDet.update_changes()
            End If

            'update status
            query = String.Format("UPDATE tb_purc_rec_foc SET id_report_status='{0}' WHERE id_purc_rec_foc ='{1}'", id_status_reportx, id_report)
            execute_non_query(query, True, "", "", "", "")
        End If

        'adding lead time
        Dim query_auto As String = "SELECT DISTINCT(id_report_status) as id_report_status FROM tb_report_mark  WHERE id_report='" & id_report & "' AND report_mark_type='" & report_mark_type & "' AND id_report_status>'" & id_status_reportx & "' ORDER BY id_report_status LIMIT 1"
        Dim data_auto As DataTable = execute_query(query_auto, -1, True, "", "", "", "")
        If data_auto.Rows.Count > 0 Then
            Dim query_set As String = "SELECT * FROM tb_report_mark WHERE id_report='" & id_report & "' AND report_mark_type='" & report_mark_type & "' AND id_report_status>'" & id_status_reportx & "' AND id_report_status='" & data_auto.Rows(0)("id_report_status").ToString & "' ORDER BY level"
            Dim data_set As DataTable = execute_query(query_set, -1, True, "", "", "", "")
            For i As Integer = 0 To data_set.Rows.Count - 1
                query = "UPDATE tb_report_mark b SET b.report_mark_start_datetime=NOW(),b.report_mark_lead_time=(SELECT IFNULL(z.lead_time,'00-00-00') FROM tb_mark_asg_user z WHERE z.id_mark_asg=b.id_mark_asg AND z.id_user=b.id_user LIMIT 1) WHERE b.id_report_mark='" & data_set.Rows(i)("id_report_mark").ToString & "'"
                'If data_set.Rows(i)("level").ToString() = "1" Then
                '    query = "UPDATE tb_report_mark b SET b.report_mark_start_datetime=NOW(),b.report_mark_lead_time=(SELECT IFNULL(z.lead_time,'00-00-00') FROM tb_mark_asg_user z WHERE z.id_mark_asg=b.id_mark_asg AND z.id_user=b.id_user LIMIT 1) WHERE b.id_report_mark='" & data_set.Rows(i)("id_report_mark").ToString & "'"
                'Else
                '    query = "UPDATE tb_report_mark b SET b.report_mark_start_datetime=(SELECT a.report_mark_start_datetime_end FROM (SELECT ADDTIME(z.report_mark_start_datetime,z.report_mark_lead_time) AS report_mark_start_datetime_end FROM tb_report_mark z WHERE z.id_mark_asg=" & data_set.Rows(i)("id_mark_asg").ToString() & " AND z.id_report=" & data_set.Rows(i)("id_report").ToString() & " AND z.level=" & data_set.Rows(i)("level").ToString() & "-1 LIMIT 1) a),b.report_mark_lead_time=(SELECT IFNULL(z.lead_time,'00-00-00') FROM tb_mark_asg_user z WHERE z.id_mark_asg=b.id_mark_asg AND z.id_user=b.id_user LIMIT 1) WHERE b.id_report_mark='" & data_set.Rows(i)("id_report_mark").ToString & "'"
                'End If
                execute_non_query(query, True, "", "", "", "")
            Next
        End If
        'auto_journal()
        'auto email
        If id_status_reportx = "6" Then
            Dim qc As String = "SELECT report_mark_type_name FROM tb_lookup_report_mark_type WHERE report_mark_type='" & report_mark_type & "' AND is_complete_send_mail='1'"
            Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
            If dtc.Rows.Count > 0 Then
                'send mail
                Dim mail As ClassSendEmail = New ClassSendEmail()
                mail.report_mark_type = report_mark_type
                mail.send_mail_complete(report_mark_type, id_report, report_number)
            End If
        End If
        view_report_status(LEReportStatus)
    End Sub

    Sub posting_journal()
        'Dim q_posting As String = ""
        'Dim acc_trans_number As String = ""
        'acc_trans_number = header_number_acc("1")

        'q_posting = String.Format("INSERT INTO tb_a_acc_trans(acc_trans_number,id_user,date_created,acc_trans_note) VALUES('{0}','{1}',NOW(),'Auto posting {2}');SELECT LAST_INSERT_ID()", acc_trans_number, id_user, report_number)
        ''execute_non_query(q_posting, True, "", "", "", "")

        ''q_posting = "SELECT LAST_INSERT_ID()"
        'Dim last_id As String = execute_query(q_posting, 0, True, "", "", "", "")

        'If report_mark_type = "1" Then ' sample purchase det
        '    Dim id_acc_x As String = ""
        '    q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
        '    '-debit
        '    '-- item
        '    If get_coa_mapping("1", "4").ToString = "1" Then
        '        id_acc_x = make_sure_acc(get_coa_mapping("1", "1"), get_coa_mapping("1", "2") & "" & FormSamplePurchaseDet.TECompCode.Text, FormSamplePurchaseDet.TECompName.Text)
        '    Else
        '        id_acc_x = get_coa_mapping("1", "1")
        '    End If

        '    q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, decimalSQL(FormSamplePurchaseDet.TEGrossTot.EditValue.ToString), 0, "Sample - " & FormSamplePurchaseDet.TECompName.Text, report_mark_type, id_report)
        '    'credit
        '    If get_coa_mapping("2", "4").ToString = "1" Then
        '        id_acc_x = make_sure_acc(get_coa_mapping("2", "1"), get_coa_mapping("2", "2") & "" & FormSamplePurchaseDet.TECompCode.Text, FormSamplePurchaseDet.TECompName.Text)
        '    Else
        '        id_acc_x = get_coa_mapping("2", "1")
        '    End If

        '    q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, decimalSQL(FormSamplePurchaseDet.TEGrossTot.EditValue.ToString), "PO Sample - " & FormSamplePurchaseDet.TECompName.Text, report_mark_type, id_report)
        '    execute_non_query(q_posting, True, "", "", "", "")
        'ElseIf report_mark_type = "2" Then 'receive sample purc
        '    'MsgBox(FormSampleReceiveDet.GVListPurchase.Columns("sample_purc_rec_det_price").SummaryItem.SummaryValue.ToString)
        '    'declare account
        '    'Dim id_coa_m_d As String = "3"
        '    'Dim id_coa_m_k As String = "4"
        '    ''vendor name and code
        '    'Dim _comp_code As String = get_company_x(FormSampleReceiveDet.id_comp_from, "2")
        '    'Dim _comp_name As String = FormSampleReceiveDet.TECompName.Text
        '    'Dim _value_str As String = decimalSQL(FormSampleReceiveDet.GVListPurchase.Columns("sample_purc_rec_det_price").SummaryItem.SummaryValue.ToString)
        '    ''
        '    'Dim id_acc_x As String = ""
        '    'q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
        '    ''-debit
        '    ''-- item
        '    'If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
        '    '    id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
        '    'Else
        '    '    id_acc_x = get_coa_mapping(id_coa_m_d, "1")
        '    'End If

        '    'q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Sample Receive - " & _comp_name, report_mark_type, id_report)
        '    ''credit
        '    'If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
        '    '    id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
        '    'Else
        '    '    id_acc_x = get_coa_mapping(id_coa_m_k, "1")
        '    'End If

        '    'q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Sample Receive - " & _comp_name, report_mark_type, id_report)
        '    'execute_non_query(q_posting, True, "", "", "", "")
        'ElseIf report_mark_type = "13" Then 'mat purc
        '    If FormMatPurchaseDet.LEPOType.EditValue.ToString = "1" Then 'domestic
        '        'declare account
        '        Dim id_coa_m_d As String = "13"
        '        Dim id_coa_m_k As String = "14"
        '        'vendor name and code
        '        Dim _comp_code As String = FormMatPurchaseDet.TECompCode.Text
        '        Dim _comp_name As String = FormMatPurchaseDet.TECompName.Text
        '        Dim _value_str As String = decimalSQL(FormMatPurchaseDet.TEGrossTot.EditValue.ToString)
        '        '
        '        Dim id_acc_x As String = ""
        '        q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
        '        '-debit
        '        '-- item
        '        If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
        '            id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
        '        Else
        '            id_acc_x = get_coa_mapping(id_coa_m_d, "1")
        '        End If

        '        q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Purchase Domestic - " & _comp_name, report_mark_type, id_report)
        '        'credit
        '        If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
        '            id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
        '        Else
        '            id_acc_x = get_coa_mapping(id_coa_m_k, "1")
        '        End If

        '        q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Purchase Domestic - " & _comp_name, report_mark_type, id_report)
        '        execute_non_query(q_posting, True, "", "", "", "")
        '    ElseIf FormMatPurchaseDet.LEPOType.EditValue.ToString = "2" Then 'international
        '        'declare account
        '        Dim id_coa_m_d As String = "5"
        '        Dim id_coa_m_k As String = "6"
        '        'vendor name and code
        '        Dim _comp_code As String = FormMatPurchaseDet.TECompCode.Text
        '        Dim _comp_name As String = FormMatPurchaseDet.TECompName.Text
        '        Dim _value_str As String = decimalSQL(FormMatPurchaseDet.TEGrossTot.EditValue.ToString)
        '        '
        '        Dim id_acc_x As String = ""
        '        q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
        '        '-debit
        '        '-- item
        '        If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
        '            id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
        '        Else
        '            id_acc_x = get_coa_mapping(id_coa_m_d, "1")
        '        End If

        '        q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Purchase Import - " & _comp_name, report_mark_type, id_report)
        '        'credit
        '        If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
        '            id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
        '        Else
        '            id_acc_x = get_coa_mapping(id_coa_m_k, "1")
        '        End If

        '        q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Purchase Import - " & _comp_name, report_mark_type, id_report)
        '        execute_non_query(q_posting, True, "", "", "", "")
        '    ElseIf FormMatPurchaseDet.LEPOType.EditValue.ToString = "3" Then 'merchandise
        '        'declare account
        '        Dim id_coa_m_d As String = "15"
        '        Dim id_coa_m_k As String = "16"
        '        'vendor name and code
        '        Dim _comp_code As String = FormMatPurchaseDet.TECompCode.Text
        '        Dim _comp_name As String = FormMatPurchaseDet.TECompName.Text
        '        Dim _value_str As String = decimalSQL(FormMatPurchaseDet.TEGrossTot.EditValue.ToString)
        '        '
        '        Dim id_acc_x As String = ""
        '        q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
        '        '-debit
        '        '-- item
        '        If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
        '            id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
        '        Else
        '            id_acc_x = get_coa_mapping(id_coa_m_d, "1")
        '        End If

        '        q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Purchase Non Merchandise - " & _comp_name, report_mark_type, id_report)
        '        'credit
        '        If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
        '            id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
        '        Else
        '            id_acc_x = get_coa_mapping(id_coa_m_k, "1")
        '        End If

        '        q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Purchase Non Merchandise - " & _comp_name, report_mark_type, id_report)
        '        execute_non_query(q_posting, True, "", "", "", "")
        '    End If
        'ElseIf report_mark_type = "16" Then 'mat purc receive
        '    Dim query_det As String = "SELECT b.id_po_type FROM tb_mat_purc_rec a INNER JOIN tb_mat_purc b ON a.id_mat_purc=b.id_mat_purc WHERE a.id_mat_purc_rec='" & id_report & "'"
        '    Dim id_po_type As String = execute_query(query_det, 0, True, "", "", "", "")

        '    If id_po_type = "1" Then 'domestic
        '        'declare account
        '        Dim id_coa_m_d As String = "17"
        '        Dim id_coa_m_k As String = "18"
        '        'vendor name and code
        '        Dim _comp_code As String = get_company_x(get_company_contact_x(FormMatRecPurcDet.id_comp_from, "3"), "2")
        '        Dim _comp_name As String = FormMatRecPurcDet.TECompName.Text
        '        Dim _value_str As String = decimalSQL(FormMatRecPurcDet.GVListPurchase.Columns("mat_purc_rec_det_price").SummaryItem.SummaryValue.ToString)
        '        '
        '        Dim id_acc_x As String = ""
        '        q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
        '        '-debit
        '        '-- item
        '        If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
        '            id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
        '        Else
        '            id_acc_x = get_coa_mapping(id_coa_m_d, "1")
        '        End If

        '        q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Receive Purchasing Domestic - " & _comp_name, report_mark_type, id_report)
        '        'credit
        '        If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
        '            id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
        '        Else
        '            id_acc_x = get_coa_mapping(id_coa_m_k, "1")
        '        End If

        '        q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Receive Purchasing Domestic - " & _comp_name, report_mark_type, id_report)
        '        execute_non_query(q_posting, True, "", "", "", "")
        '    ElseIf id_po_type = "2" Then 'import
        '        'declare account
        '        Dim id_coa_m_d As String = "7"
        '        Dim id_coa_m_k As String = "8"
        '        'vendor name and code
        '        Dim _comp_code As String = get_company_x(FormMatRecPurcDet.id_comp_from, "2")
        '        Dim _comp_name As String = FormMatRecPurcDet.TECompName.Text
        '        Dim _value_str As String = decimalSQL(FormMatRecPurcDet.GVListPurchase.Columns("mat_purc_rec_det_price").SummaryItem.SummaryValue.ToString)
        '        '
        '        Dim id_acc_x As String = ""
        '        q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
        '        '-debit
        '        '-- item
        '        If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
        '            id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
        '        Else
        '            id_acc_x = get_coa_mapping(id_coa_m_d, "1")
        '        End If

        '        q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Receive Purchasing Import - " & _comp_name, report_mark_type, id_report)
        '        'credit
        '        If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
        '            id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
        '        Else
        '            id_acc_x = get_coa_mapping(id_coa_m_k, "1")
        '        End If

        '        q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Receive Purchasing Import  - " & _comp_name, report_mark_type, id_report)
        '        execute_non_query(q_posting, True, "", "", "", "")
        '    ElseIf id_po_type = "3" Then 'non merchandise
        '        'declare account
        '        Dim id_coa_m_d As String = "19"
        '        Dim id_coa_m_k As String = "20"
        '        'vendor name and code
        '        Dim _comp_code As String = get_company_x(FormMatRecPurcDet.id_comp_from, "2")
        '        Dim _comp_name As String = FormMatRecPurcDet.TECompName.Text
        '        Dim _value_str As String = decimalSQL(FormMatRecPurcDet.GVListPurchase.Columns("mat_purc_rec_det_price").SummaryItem.SummaryValue.ToString)
        '        '
        '        Dim id_acc_x As String = ""
        '        q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
        '        '-debit
        '        '-- item
        '        If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
        '            id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
        '        Else
        '            id_acc_x = get_coa_mapping(id_coa_m_d, "1")
        '        End If

        '        q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Receive Purchasing Non Merchandise - " & _comp_name, report_mark_type, id_report)
        '        'credit
        '        If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
        '            id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
        '        Else
        '            id_acc_x = get_coa_mapping(id_coa_m_k, "1")
        '        End If

        '        q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Receive Purchasing Non Merchandise - " & _comp_name, report_mark_type, id_report)
        '        execute_non_query(q_posting, True, "", "", "", "")
        '    End If
        'ElseIf report_mark_type = "15" Then 'mat wo
        '    'declare account
        '    Dim id_coa_m_d As String = "33"
        '    Dim id_coa_m_k As String = "34"
        '    'vendor name and code
        '    Dim _comp_code As String = FormMatWODet.TECompCode.Text
        '    Dim _comp_name As String = FormMatWODet.TECompName.Text
        '    Dim _value_str As String = decimalSQL(FormMatWODet.GVListPurchase.Columns("total").SummaryItem.SummaryValue.ToString)
        '    '
        '    Dim id_acc_x As String = ""
        '    q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
        '    '-debit
        '    '-- item
        '    If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
        '        id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
        '    Else
        '        id_acc_x = get_coa_mapping(id_coa_m_d, "1")
        '    End If

        '    q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Work Order - " & _comp_name, report_mark_type, id_report)
        '    'credit
        '    If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
        '        id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
        '    Else
        '        id_acc_x = get_coa_mapping(id_coa_m_k, "1")
        '    End If

        '    q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Work Order - " & _comp_name, report_mark_type, id_report)
        '    execute_non_query(q_posting, True, "", "", "", "")
        'ElseIf report_mark_type = "17" Then 'mat rec wo
        '    'declare account
        '    Dim id_coa_m_d As String = "35"
        '    Dim id_coa_m_k As String = "36"
        '    'vendor name and code
        '    Dim _comp_code As String = get_company_x(FormMatRecWODet.id_comp_from, "2")
        '    Dim _comp_name As String = FormMatRecWODet.TECompName.Text
        '    Dim _value_str As String = decimalSQL(FormMatRecWODet.GVListPurchase.Columns("total_price").SummaryItem.SummaryValue.ToString)
        '    '
        '    Dim id_acc_x As String = ""
        '    q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
        '    '-debit
        '    '-- item
        '    If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
        '        id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
        '    Else
        '        id_acc_x = get_coa_mapping(id_coa_m_d, "1")
        '    End If

        '    q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material WO Receiving - " & _comp_name, report_mark_type, id_report)
        '    'credit
        '    If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
        '        id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
        '    Else
        '        id_acc_x = get_coa_mapping(id_coa_m_k, "1")
        '    End If

        '    q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material WO Receiving - " & _comp_name, report_mark_type, id_report)
        '    execute_non_query(q_posting, True, "", "", "", "")
        'ElseIf report_mark_type = "18" Then 'mat ret out
        '    Dim query_det As String = "SELECT b.id_po_type FROM tb_mat_purc_ret_out a INNER JOIN tb_mat_purc b ON a.id_mat_purc=b.id_mat_purc WHERE a.id_mat_purc_ret_out='" & id_report & "'"
        '    Dim id_po_type As String = execute_query(query_det, 0, True, "", "", "", "")

        '    If id_po_type = "1" Then 'domestic
        '        'declare account
        '        Dim id_coa_m_d As String = "21"
        '        Dim id_coa_m_k As String = "22"
        '        'vendor name and code
        '        Dim _comp_code As String = FormMatRetOutDet.TxtCodeCompTo.Text
        '        Dim _comp_name As String = FormMatRetOutDet.TxtNameCompTo.Text
        '        Dim _value_str As String = decimalSQL(FormMatRetOutDet.GVRetDetail.Columns("mat_purc_ret_out_det_price").SummaryItem.SummaryValue.ToString)
        '        '
        '        Dim id_acc_x As String = ""
        '        q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
        '        '-debit
        '        '-- item
        '        If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
        '            id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
        '        Else
        '            id_acc_x = get_coa_mapping(id_coa_m_d, "1")
        '        End If

        '        q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Return Out - " & _comp_name, report_mark_type, id_report)
        '        'credit
        '        If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
        '            id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
        '        Else
        '            id_acc_x = get_coa_mapping(id_coa_m_k, "1")
        '        End If

        '        q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Return Out - " & _comp_name, report_mark_type, id_report)
        '        execute_non_query(q_posting, True, "", "", "", "")
        '    ElseIf id_po_type = "2" Then 'import
        '        'declare account
        '        Dim id_coa_m_d As String = "9"
        '        Dim id_coa_m_k As String = "10"
        '        'vendor name and code
        '        Dim _comp_code As String = FormMatRetOutDet.TxtCodeCompTo.Text
        '        Dim _comp_name As String = FormMatRetOutDet.TxtNameCompTo.Text
        '        Dim _value_str As String = decimalSQL(FormMatRetOutDet.GVRetDetail.Columns("mat_purc_ret_out_det_price").SummaryItem.SummaryValue.ToString)
        '        '
        '        Dim id_acc_x As String = ""
        '        q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
        '        '-debit
        '        '-- item
        '        If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
        '            id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
        '        Else
        '            id_acc_x = get_coa_mapping(id_coa_m_d, "1")
        '        End If

        '        q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Return Out - " & _comp_name, report_mark_type, id_report)
        '        'credit
        '        If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
        '            id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
        '        Else
        '            id_acc_x = get_coa_mapping(id_coa_m_k, "1")
        '        End If

        '        q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Return Out - " & _comp_name, report_mark_type, id_report)
        '        execute_non_query(q_posting, True, "", "", "", "")
        '    ElseIf id_po_type = "3" Then 'non merchandise
        '        'declare account
        '        Dim id_coa_m_d As String = "23"
        '        Dim id_coa_m_k As String = "24"
        '        'vendor name and code
        '        Dim _comp_code As String = FormMatRetOutDet.TxtCodeCompTo.Text
        '        Dim _comp_name As String = FormMatRetOutDet.TxtNameCompTo.Text
        '        Dim _value_str As String = decimalSQL(FormMatRetOutDet.GVRetDetail.Columns("mat_purc_ret_out_det_price").SummaryItem.SummaryValue.ToString)
        '        '
        '        Dim id_acc_x As String = ""
        '        q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
        '        '-debit
        '        '-- item
        '        If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
        '            id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
        '        Else
        '            id_acc_x = get_coa_mapping(id_coa_m_d, "1")
        '        End If

        '        q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Return Out - " & _comp_name, report_mark_type, id_report)
        '        'credit
        '        If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
        '            id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
        '        Else
        '            id_acc_x = get_coa_mapping(id_coa_m_k, "1")
        '        End If

        '        q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Return Out - " & _comp_name, report_mark_type, id_report)
        '        execute_non_query(q_posting, True, "", "", "", "")
        '    End If
        'ElseIf report_mark_type = "26" Then 'mat adj in
        '    'declare account
        '    Dim id_coa_m_d As String = "25"
        '    Dim id_coa_m_k As String = "26"
        '    'vendor name and code
        '    Dim _comp_code As String = ""
        '    Dim _comp_name As String = ""
        '    Dim _value_str As String = decimalSQL(FormMatAdjInSingle.GVDetail.Columns("adj_in_mat_det_amount").SummaryItem.SummaryValue.ToString)
        '    '
        '    Dim id_acc_x As String = ""
        '    q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
        '    '-debit
        '    '-- item
        '    If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
        '        id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
        '    Else
        '        id_acc_x = get_coa_mapping(id_coa_m_d, "1")
        '    End If

        '    q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Adjustment In " & _comp_name, report_mark_type, id_report)
        '    'credit
        '    If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
        '        id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
        '    Else
        '        id_acc_x = get_coa_mapping(id_coa_m_k, "1")
        '    End If

        '    q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Adjustment In " & _comp_name, report_mark_type, id_report)
        '    execute_non_query(q_posting, True, "", "", "", "")
        'ElseIf report_mark_type = "30" Then 'mat PL
        '    'declare account
        '    Dim id_coa_m_d As String = "37"
        '    Dim id_coa_m_k As String = "38"
        '    'vendor name and code
        '    Dim _comp_code As String = FormMatPLSingle.TxtCodeCompTo.Text
        '    Dim _comp_name As String = FormMatPLSingle.TxtNameCompTo.Text
        '    Dim _value_str As String = decimalSQL(FormMatPLSingle.GVDrawer.Columns("total_price").SummaryItem.SummaryValue.ToString)
        '    '
        '    Dim id_acc_x As String = ""
        '    q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
        '    '-debit
        '    '-- item
        '    If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
        '        id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
        '    Else
        '        id_acc_x = get_coa_mapping(id_coa_m_d, "1")
        '    End If

        '    q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Packing List " & _comp_name, report_mark_type, id_report)
        '    'credit
        '    If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
        '        id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
        '    Else
        '        id_acc_x = get_coa_mapping(id_coa_m_k, "1")
        '    End If

        '    q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Packing List " & _comp_name, report_mark_type, id_report)
        '    execute_non_query(q_posting, True, "", "", "", "")
        'ElseIf report_mark_type = "27" Then 'mat adj out
        '    'declare account
        '    Dim id_coa_m_d As String = "27"
        '    Dim id_coa_m_k As String = "28"
        '    'vendor name and code
        '    Dim _comp_code As String = ""
        '    Dim _comp_name As String = ""
        '    Dim _value_str As String = decimalSQL(FormMatAdjOutSingle.GVDetail.Columns("adj_out_mat_det_amount").SummaryItem.SummaryValue.ToString)
        '    '
        '    Dim id_acc_x As String = ""
        '    q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
        '    '-debit
        '    '-- item
        '    If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
        '        id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
        '    Else
        '        id_acc_x = get_coa_mapping(id_coa_m_d, "1")
        '    End If

        '    q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Adjustment Out " & _comp_name, report_mark_type, id_report)
        '    'credit
        '    If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
        '        id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
        '    Else
        '        id_acc_x = get_coa_mapping(id_coa_m_k, "1")
        '    End If

        '    q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Adjustment Out " & _comp_name, report_mark_type, id_report)
        '    execute_non_query(q_posting, True, "", "", "", "")
        'ElseIf report_mark_type = "20" Then 'sample adjustment in
        '    'declare account
        '    Dim id_coa_m_d As String = "29"
        '    Dim id_coa_m_k As String = "30"
        '    'vendor name and code
        '    Dim _comp_code As String = ""
        '    Dim _comp_name As String = ""
        '    Dim _value_str As String = decimalSQL(FormSampleAdjustmentInSingle.GVDetail.Columns("adj_in_sample_det_amount").SummaryItem.SummaryValue.ToString)
        '    '
        '    Dim id_acc_x As String = ""
        '    q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
        '    '-debit
        '    '-- item
        '    If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
        '        id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
        '    Else
        '        id_acc_x = get_coa_mapping(id_coa_m_d, "1")
        '    End If

        '    q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Sample Adjustment In " & _comp_name, report_mark_type, id_report)
        '    'credit
        '    If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
        '        id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
        '    Else
        '        id_acc_x = get_coa_mapping(id_coa_m_k, "1")
        '    End If

        '    q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Sample Adjustment In " & _comp_name, report_mark_type, id_report)
        '    execute_non_query(q_posting, True, "", "", "", "")
        'ElseIf report_mark_type = "21" Then 'sample adjustment out
        '    'declare account
        '    Dim id_coa_m_d As String = "31"
        '    Dim id_coa_m_k As String = "32"
        '    'vendor name and code
        '    Dim _comp_code As String = ""
        '    Dim _comp_name As String = ""
        '    Dim _value_str As String = decimalSQL(FormSampleAdjustmentOutSingle.GVDetail.Columns("adj_out_sample_det_amount").SummaryItem.SummaryValue.ToString)
        '    '
        '    Dim id_acc_x As String = ""
        '    q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
        '    '-debit
        '    '-- item
        '    If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
        '        id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
        '    Else
        '        id_acc_x = get_coa_mapping(id_coa_m_d, "1")
        '    End If

        '    q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Sample Adjustment Out " & _comp_name, report_mark_type, id_report)
        '    'credit
        '    If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
        '        id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
        '    Else
        '        id_acc_x = get_coa_mapping(id_coa_m_k, "1")
        '    End If

        '    q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Sample Adjustment Out " & _comp_name, report_mark_type, id_report)
        '    execute_non_query(q_posting, True, "", "", "", "")
        'ElseIf report_mark_type = "23" Then 'Production Work Order
        '    'declare account
        '    Dim id_coa_m_d As String = "45"
        '    Dim id_coa_m_k As String = "46"
        '    Dim id_coa_m_v As String = "47" 'vat
        '    Dim id_v_dc As String = get_coa_mapping(id_coa_m_v, "5")
        '    'vendor name and code
        '    Dim _comp_code As String = FormMatInvoiceReturDet.TECompCode.Text
        '    Dim _comp_name As String = FormMatInvoiceReturDet.TECompName.Text
        '    Dim _value_str As String = decimalSQL(FormMatInvoiceReturDet.TETot.EditValue.ToString)
        '    Dim _value_gross_str As String = decimalSQL(FormMatInvoiceReturDet.TEGrossTot.EditValue.ToString)
        '    Dim _value_vat_str As String = decimalSQL(FormMatInvoiceReturDet.TEVatTot.EditValue.ToString)
        '    '
        '    Dim id_acc_x As String = ""
        '    q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
        '    '-debit
        '    '-- item
        '    If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
        '        id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
        '    Else
        '        id_acc_x = get_coa_mapping(id_coa_m_d, "1")
        '    End If

        '    If id_v_dc = "1" Then 'debit
        '        q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_gross_str, 0, "Material Invoice Retur " & _comp_name, report_mark_type, id_report)
        '    Else
        '        q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Invoice Retur " & _comp_name, report_mark_type, id_report)
        '    End If

        '    'credit
        '    If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
        '        id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
        '    Else
        '        id_acc_x = get_coa_mapping(id_coa_m_k, "1")
        '    End If
        '    '
        '    If id_v_dc = "1" Then 'debit
        '        q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Invoice Retur " & _comp_name, report_mark_type, id_report)
        '    Else
        '        q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_gross_str, "Material Invoice Retur " & _comp_name, report_mark_type, id_report)
        '    End If

        '    'vat
        '    If get_coa_mapping(id_coa_m_v, "4").ToString = "1" Then
        '        id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_v, "1"), get_coa_mapping(id_coa_m_v, "2") & _comp_code, _comp_name)
        '    Else
        '        id_acc_x = get_coa_mapping(id_coa_m_v, "1")
        '    End If
        '    '
        '    If id_v_dc = "1" Then 'debit
        '        q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_vat_str, 0, "Material Invoice Retur Vat " & _comp_name, report_mark_type, id_report)
        '    Else
        '        q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_vat_str, "Material Invoice Retur Vat " & _comp_name, report_mark_type, id_report)
        '    End If

        '    execute_non_query(q_posting, True, "", "", "", "")
        'ElseIf report_mark_type = "34" Then 'Mat Invoice
        '    'declare account
        '    Dim id_coa_m_d As String = "39"
        '    Dim id_coa_m_k As String = "40"
        '    Dim id_coa_m_v As String = "41" 'vat
        '    Dim id_v_dc As String = get_coa_mapping(id_coa_m_v, "5")
        '    'vendor name and code
        '    Dim _comp_code As String = FormMatInvoiceDet.TECompCode.Text
        '    Dim _comp_name As String = FormMatInvoiceDet.TECompName.Text
        '    Dim _value_str As String = decimalSQL(FormMatInvoiceDet.TETot.EditValue.ToString)
        '    Dim _value_gross_str As String = decimalSQL(FormMatInvoiceDet.TEGrossTot.EditValue.ToString)
        '    Dim _value_vat_str As String = decimalSQL(FormMatInvoiceDet.TEVatTot.EditValue.ToString)
        '    '
        '    Dim id_acc_x As String = ""
        '    q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
        '    '-debit
        '    '-- item
        '    If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
        '        id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
        '    Else
        '        id_acc_x = get_coa_mapping(id_coa_m_d, "1")
        '    End If

        '    If id_v_dc = "1" Then 'debit
        '        q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_gross_str, 0, "Material Invoice " & _comp_name, report_mark_type, id_report)
        '    Else
        '        q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Invoice " & _comp_name, report_mark_type, id_report)
        '    End If

        '    'credit
        '    If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
        '        id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
        '    Else
        '        id_acc_x = get_coa_mapping(id_coa_m_k, "1")
        '    End If
        '    '
        '    If id_v_dc = "1" Then 'debit
        '        q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Invoice " & _comp_name, report_mark_type, id_report)
        '    Else
        '        q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_gross_str, "Material Invoice " & _comp_name, report_mark_type, id_report)
        '    End If

        '    'vat
        '    If get_coa_mapping(id_coa_m_v, "4").ToString = "1" Then
        '        id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_v, "1"), get_coa_mapping(id_coa_m_v, "2") & _comp_code, _comp_name)
        '    Else
        '        id_acc_x = get_coa_mapping(id_coa_m_v, "1")
        '    End If
        '    '
        '    If id_v_dc = "1" Then 'debit
        '        q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_vat_str, 0, "Material Invoice Vat " & _comp_name, report_mark_type, id_report)
        '    Else
        '        q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_vat_str, "Material Invoice Vat " & _comp_name, report_mark_type, id_report)
        '    End If

        '    execute_non_query(q_posting, True, "", "", "", "")
        'ElseIf report_mark_type = "35" Then 'Mat Invoice Retur
        '    'declare account
        '    Dim id_coa_m_d As String = "42"
        '    Dim id_coa_m_k As String = "43"
        '    Dim id_coa_m_v As String = "44" 'vat
        '    Dim id_v_dc As String = get_coa_mapping(id_coa_m_v, "5")
        '    'vendor name and code
        '    Dim _comp_code As String = FormMatInvoiceReturDet.TECompCode.Text
        '    Dim _comp_name As String = FormMatInvoiceReturDet.TECompName.Text
        '    Dim _value_str As String = decimalSQL(FormMatInvoiceReturDet.TETot.EditValue.ToString)
        '    Dim _value_gross_str As String = decimalSQL(FormMatInvoiceReturDet.TEGrossTot.EditValue.ToString)
        '    Dim _value_vat_str As String = decimalSQL(FormMatInvoiceReturDet.TEVatTot.EditValue.ToString)
        '    '
        '    Dim id_acc_x As String = ""
        '    q_posting = "INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,report_mark_type,id_report) VALUES"
        '    '-debit
        '    '-- item
        '    If get_coa_mapping(id_coa_m_d, "4").ToString = "1" Then
        '        id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_d, "1"), get_coa_mapping(id_coa_m_d, "2") & _comp_code, _comp_name)
        '    Else
        '        id_acc_x = get_coa_mapping(id_coa_m_d, "1")
        '    End If

        '    If id_v_dc = "1" Then 'debit
        '        q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_gross_str, 0, "Material Invoice Retur " & _comp_name, report_mark_type, id_report)
        '    Else
        '        q_posting += String.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_str, 0, "Material Invoice Retur " & _comp_name, report_mark_type, id_report)
        '    End If

        '    'credit
        '    If get_coa_mapping(id_coa_m_k, "4").ToString = "1" Then
        '        id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_k, "1"), get_coa_mapping(id_coa_m_k, "2") & _comp_code, _comp_name)
        '    Else
        '        id_acc_x = get_coa_mapping(id_coa_m_k, "1")
        '    End If
        '    '
        '    If id_v_dc = "1" Then 'debit
        '        q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_str, "Material Invoice Retur " & _comp_name, report_mark_type, id_report)
        '    Else
        '        q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_gross_str, "Material Invoice Retur " & _comp_name, report_mark_type, id_report)
        '    End If

        '    'vat
        '    If get_coa_mapping(id_coa_m_v, "4").ToString = "1" Then
        '        id_acc_x = make_sure_acc(get_coa_mapping(id_coa_m_v, "1"), get_coa_mapping(id_coa_m_v, "2") & _comp_code, _comp_name)
        '    Else
        '        id_acc_x = get_coa_mapping(id_coa_m_v, "1")
        '    End If
        '    '
        '    If id_v_dc = "1" Then 'debit
        '        q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, _value_vat_str, 0, "Material Invoice Retur Vat " & _comp_name, report_mark_type, id_report)
        '    Else
        '        q_posting += String.Format(",('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, id_acc_x, 0, _value_vat_str, "Material Invoice Retur Vat " & _comp_name, report_mark_type, id_report)
        '    End If

        '    execute_non_query(q_posting, True, "", "", "", "")
        'End If
        'insert_who_prepared("36", last_id, id_user)
        'increase_inc_acc("1")
        '
    End Sub
    Private Sub BLeadTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BLeadTime.Click
        If check_available_lead_time(GVMark.GetFocusedRowCellDisplayText("id_report_mark").ToString) Then
            FormReportMarkTime.id_report_mark = GVMark.GetFocusedRowCellDisplayText("id_report_mark").ToString
            FormReportMarkTime.ShowDialog()
        Else
            stopCustom("Previous mark must be completed.")
        End If
    End Sub

    Private Sub GVMark_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMark.FocusedRowChanged
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If
    End Sub

    'Private Sub GVMark_RowStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GVMark.RowStyle
    'If (e.RowHandle >= 0) Then
    '    'pick field
    '    'see if already marked
    '    If check_available_asg_color(sender.GetRowCellDisplayText(e.RowHandle, sender.Columns("id_report_mark"))) Then
    '        'already marked
    '        Dim lead_time As String = sender.GetRowCellDisplayText(e.RowHandle, sender.Columns("raw_lead_time"))
    '        'condition
    '        If Not lead_time = "" Then
    '            If Integer.Parse(check_date_passed_now(lead_time)) > 0 Then
    '                e.Appearance.BackColor = Color.Salmon
    '                e.Appearance.BackColor2 = Color.Salmon
    '            End If
    '        End If
    '    End If
    '    '
    '    If sender.GetRowCellDisplayText(e.RowHandle, sender.Columns("id_user")).ToString = id_user Then
    '        e.Appearance.Font = New Font(GVMark.Appearance.Row.Font, FontStyle.Bold)
    '    End If
    'End If
    'End Sub

    Private Sub BClearLeadTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BClearLeadTime.Click
        'MsgBox(id_report_status_report)
        If id_report_status_report.ToString = "1" And check_edit_report_status(id_report_status_report, report_mark_type, id_report) Then
            'clear lead time
            Dim query As String = ""
            query = String.Format("UPDATE tb_report_mark SET report_mark_start_datetime=NULL,report_mark_lead_time=NULL,report_mark_datetime=NULL WHERE id_report_mark='{0}'", GVMark.GetFocusedRowCellDisplayText("id_report_mark").ToString)
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Lead time cleared.")
            view_mark()
        Else
            stopCustom("This report already approved.")
        End If
    End Sub

    Public Sub sendNotif(ByVal type_par As String)
        Dim type As String = ""
        If type_par = "1" Then
            type = "approved"
        Else
            type = "not approved"
        End If

        Dim dt As DataTable = get_who_prepared(report_mark_type, id_report)
        If report_mark_type = "9" Or report_mark_type = "80" Or report_mark_type = "81" Or report_mark_type = "206" Then
            pushNotif("Production Demand", "Document #" + report_number + " is " + type, "FormProdDemand", dt.Rows(0)("id_user"), id_user, id_report, report_number, "1", report_mark_type)
            'ElseIf report_mark_type = "11" Then
            '    pushNotif("Sample Requisition", "Document #" + report_number + " is " + type + " by " + get_user_identify(dt.Rows(0)("id_user"), "1") + ".", "FormSampleReq", dt.Rows(0)("id_user"), id_user, id_report, report_number, "1", report_mark_type)
            'ElseIf report_mark_type = "28" Or report_mark_type = "127" Then
            '    pushNotif("Receiving QC", "Document #" + report_number + " is " + type + " by " + get_user_identify(id_user, "1") + ".", "FormProductionRec", dt.Rows(0)("id_user"), id_user, id_report, report_number, "1", report_mark_type)
            'ElseIf report_mark_type = "31" Then
            '    pushNotif("Return Out", "Document #" + report_number + " is " + type, "FormProductionRet", dt.Rows(0)("id_user"), id_user, id_report, report_number, "1", report_mark_type)
            'ElseIf report_mark_type = "32" Then
            '    pushNotif("Return In", "Document #" + report_number + " is " + type, "FormProductionRet", dt.Rows(0)("id_user"), id_user, id_report, report_number, "2", report_mark_type)
            'ElseIf report_mark_type = "33" Then
            '    pushNotif("Packing List", "Document #" + report_number + " is " + type, "FormProductionPLToWH", dt.Rows(0)("id_user"), id_user, id_report, report_number, "1", report_mark_type)
            'ElseIf report_mark_type = "37" Then
            '    pushNotif("Received FG in Warehouse", "Document #" + report_number + " is " + type, "FormProductionPLToWHRec", dt.Rows(0)("id_user"), id_user, id_report, report_number, "1", report_mark_type)
            'ElseIf report_mark_type = "45" Then
            '    pushNotif("Return Order", "Document #" + report_number + " is " + type, "FormSalesReturnOrder", dt.Rows(0)("id_user"), id_user, id_report, report_number, "1", report_mark_type)
            'ElseIf report_mark_type = "46" Then
            '    pushNotif("Return", "Document #" + report_number + " is " + type, "FormSalesReturn", dt.Rows(0)("id_user"), id_user, id_report, report_number, "1", report_mark_type)
            'ElseIf report_mark_type = "49" Or report_mark_type = "106" Then
            '    pushNotif("Return QC", "Document #" + report_number + " is " + type, "FormSalesReturnQC", dt.Rows(0)("id_user"), id_user, id_report, report_number, "1", report_mark_type)
        ElseIf report_mark_type = "82" Then
            pushNotif("Product Price From Excel", "Document #" + report_number + " is " + type, "FormMasterPrice", dt.Rows(0)("id_user"), id_user, id_report, report_number, "1", report_mark_type)
            'ElseIf report_mark_type = "85" Then
            '    pushNotif("Packing List Sampple", "Document #" + report_number + " " + type, "FormSamplePLToWH", dt.Rows(0)("id_user"), id_user, id_report, report_number, "1", report_mark_type)
        ElseIf report_mark_type = "86" Then
            pushNotif("Sample Price From Excel", "Document #" + report_number + " is " + type, "FormMasterPriceSample", dt.Rows(0)("id_user"), id_user, id_report, report_number, "1", report_mark_type)
        ElseIf report_mark_type = "87" Then
            pushNotif("Inventory Allocation", "Document #" + report_number + " " + type, "FormFGWHAlloc", dt.Rows(0)("id_user"), id_user, id_report, report_number, "1", report_mark_type)
        ElseIf report_mark_type = "88" Then
            pushNotif("Generate Prepare Order", "Document #" + report_number + " " + type + " by " + get_user_identify(id_user, "1") + ".", "FormSalesOrder", dt.Rows(0)("id_user"), id_user, id_report, report_number, "2", report_mark_type)
        ElseIf report_mark_type = "134" Then
            Dim note As String = ""
            If type_par = "2" Then
                note = "Document #" + report_number + " is not approved and canceled, please submit a new one according to the note"
            Else
                note = "Document #" + report_number + " is approved."
            End If
            pushNotif("Setup Budget Category", note, "FormItemCatPropose", dt.Rows(0)("id_user"), id_user, id_report, report_number, "1", report_mark_type)
        ElseIf report_mark_type = "135" Then
            Dim note As String = ""
            If type_par = "2" Then
                note = "Document #" + report_number + " is not approved and canceled, please submit a new one according to the note"
            Else
                note = "Document #" + report_number + " is approved."
            End If
            pushNotif("Mapping Budget Category", note, "FormItemCatMapping", dt.Rows(0)("id_user"), id_user, id_report, report_number, "1", report_mark_type)
        End If
    End Sub

    Private Sub BReset_Click(sender As Object, e As EventArgs) Handles BReset.Click
        Dim query As String

        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Reset all mark on this document, continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            query = String.Format("UPDATE tb_report_mark SET id_mark='1',is_use=IF(ISNULL(`level`) OR `level`=1,1,2),report_mark_lead_time=NULL,report_mark_start_datetime=NULL,report_mark_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'{2}'", report_mark_type, id_report, 1)
            execute_non_query(query, True, "", "", "", "")

            view_mark()
        End If
    End Sub

    Private Sub BCancel_Click_1(sender As Object, e As EventArgs)
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Cancel this document ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim query_cancel As String = "UPDATE tb_report_mark SET report_mark_start_datetime=NULL,report_mark_lead_time=NULL WHERE id_report='" & id_report & "' AND report_mark_type='" & report_mark_type & "' AND id_mark='1';
                                          DELETE FROM tb_report_mark_cancel WHERE id_report='" & id_report & "' AND report_mark_type='" & report_mark_type & "';
                                          INSERT INTO tb_report_mark_cancel(created_by,created_datetime,id_report,report_mark_type,report_number,is_submit)
                                          VALUES('" & id_user & "',NOW(),'" & id_report & "','" & report_mark_type & "','" & report_number & "','2')"
            execute_non_query(query_cancel, True, "", "", "", "")
            view_report_status(LEReportStatus)
            XTCMark.SelectedTabPageIndex = 1
        End If
    End Sub

    'Private Sub BSubmit_Click(sender As Object, e As EventArgs)
    '    If BSubmit.Text = "Print" Then
    '        'print

    '    Else
    '        'check attachment
    '        'rmt = 142
    '        Dim query_attchment As String = "SELECT * FROM tb_doc WHERE report_mark_type='142' AND id_report='" & id_report_mark_cancel & "'"
    '        Dim data_attachemnt As DataTable = execute_query(query_attchment, -1, True, "", "", "", "")
    '        '
    '        If MEReason.Text = "" Then
    '            stopCustom("Please input the reason")
    '        ElseIf data_attachemnt.Rows.Count = 0 Then
    '            stopCustom("Please attach supporting document")
    '        Else
    '            'submit
    '            Dim query_upd As String = "SET @id_rmc=0;
    '                                    Select id_report_mark_cancel INTO @id_rmc FROM tb_report_mark_cancel WHERE id_report='" & id_report & "' AND report_mark_type='" & report_mark_type & "';
    '                                    UPDATE tb_report_mark_cancel SET is_submit=1,reason='" & addSlashes(MEReason.Text) & "' WHERE id_report_mark_cancel=@id_rmc;
    '                                    INSERT INTO tb_report_mark_cancel_user(id_report_mark_cancel,id_user,id_employee)
    '                                    SELECT @id_rmc,id_user,id_employee FROM tb_report_mark WHERE id_report='" & id_report & "' AND report_mark_type='" & report_mark_type & "' AND id_mark=2 AND id_report_status>1
    '                                    ORDER BY report_mark_datetime ASC;"
    '            execute_non_query(query_upd, True, "", "", "", "")
    '            cancel_if_suffice()
    '            infoCustom("Cancel Form submitted")
    '            view_report_status(LEReportStatus)
    '        End If
    '    End If
    'End Sub

    Public Sub cancel_if_suffice()
        Dim query As String = "SELECT * FROM tb_report_mark_cancel_user usr
                                INNER JOIN tb_report_mark_cancel rmc ON rmc.id_report_mark_cancel=usr.id_report_mark_cancel
                                WHERE rmc.id_report='" & id_report & "' AND rmc.report_mark_type='" & report_mark_type & "' AND usr.is_approve=2"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count = 0 Then 'tidak ada yg blm setuju
            'set cancel
            change_status("5")
        End If
    End Sub
End Class