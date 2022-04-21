Public Class FormProductionManualETA
    Public id_prod_order As String = "-1"
    Private Sub FormProductionManualETA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEArrive.Properties.MinValue = Now
        DEArrive.EditValue = Now

        view_eta_log()
    End Sub

    Sub view_eta_log()
        Dim q As String = "SELECT lo.*,emp.employee_name 
FROM `tb_prod_order_eta_qc_log` lo
INNER JOIN tb_m_user usr ON usr.id_user=lo.id_user
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
WHERE lo.id_prod_order='" & id_prod_order & "'
ORDER BY lo.id_prod_order_eta_qc_log DESC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCLog.DataSource = dt
        GVLog.BestFitColumns()
        If GVLog.RowCount > 0 Then
            DECurrentETA.EditValue = GVLog.GetRowCellValue(0, "eta_date").ToString
        Else
            'search
            Dim qs As String = "
SELECT DATE_ADD(wo.prod_order_wo_del_date, INTERVAL IFNULL(kod.lead_time_prod,wo.prod_order_wo_lead_time) DAY) AS dte FROM
tb_prod_order_wo wo
LEFT JOIN tb_prod_order_ko_det kod ON wo.id_prod_order=kod.id_prod_order AND wo.is_main_vendor=1 
LEFT JOIN (
	SELECT MAX(kod.id_prod_order_ko_det) AS id_prod_order_ko_det
	FROM tb_prod_order_ko_det kod
	INNER JOIN tb_prod_order_ko ko ON ko.id_prod_order_ko=kod.id_prod_order_ko AND kod.id_prod_order='" & id_prod_order & "' AND ko.is_locked=1 AND ko.is_void=2 AND NOT ISNULL(kod.id_prod_order)
	GROUP BY kod.id_prod_order 
)ko ON kod.`id_prod_order_ko_det`=ko.id_prod_order_ko_det
WHERE wo.id_prod_order='" & id_prod_order & "'"
            Dim dts As DataTable = execute_query(qs, -1, True, "", "", "", "")
            If dts.Rows.Count > 0 Then
                'local lihat ke KO, import lihat langsung
                DECurrentETA.EditValue = dts.Rows(0)("dte")
            End If
        End If
    End Sub

    Private Sub BRefresh_Click(sender As Object, e As EventArgs) Handles BRefresh.Click
        view_eta_log()
    End Sub

    Private Sub Binput_Click(sender As Object, e As EventArgs) Handles Binput.Click
        Dim qu As String = ""
        'update
        qu = "UPDATE tb_prod_order SET manual_eta_date='" & Date.Parse(DEArrive.EditValue.ToString).ToString("yyyy-MM-dd") & "' WHERE id_prod_order='" & id_prod_order & "'"
        execute_non_query(qu, True, "", "", "", "")
        'insert log
        qu = "INSERT INTO tb_prod_order_eta_qc_log(id_user,datetime,before_eta_date,eta_date,id_prod_order) VALUES('" & id_user & "',NOW(),'" & Date.Parse(DECurrentETA.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & Date.Parse(DEArrive.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & id_prod_order & "'); SELECT LAST_INSERT_ID(); "
        Dim new_id As String = execute_query(qu, 0, True, "", "", "", "")

        view_eta_log()

        Dim qid_design As String = "SELECT pdd.id_design
FROM tb_prod_order po
INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design
WHERE po.id_prod_order='" & id_prod_order & "'"
        Dim dt As DataTable = execute_query(qid_design, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then
            Dim now_date As String = DateTime.Parse(getTimeDB.ToString).ToString("yyyy-MM-dd")

            Dim s As New ClassDesign
            s.insertLogLineList("400", new_id, False, id_user, id_user, "-", now_date, dt.Rows(0)("id_design").ToString, "Update Manual Estimate Receiving QC")
        End If
    End Sub
End Class