Public Class FormScanReturnSummary
    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_view_wh()
    End Sub

    Sub load_3pl()
        Dim q As String = "SELECT c.id_comp,c.comp_number,c.comp_name
FROM tb_3pl_rate rate
INNER JOIN tb_lookup_del_type del ON del.id_del_type=rate.id_del_type AND del.is_able_inbound=1
INNER JOIN tb_m_comp c ON c.id_comp=rate.id_comp
WHERE rate.id_type='2' AND rate.is_active='1'
GROUP BY rate.id_comp"
        viewSearchLookupQuery(SLEVendor, q, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub load_emp()
        Dim q As String = "SELECT id_employee,employee_code,employee_name FROM tb_m_employee WHERE id_employee_status='1' AND id_departement='6'"
        viewSearchLookupQuery(SLEEmp, q, "id_employee", "employee_name", "id_employee")
    End Sub

    Sub load_view_wh()
        Dim date_start As String = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")

        Dim q As String = "SELECT rn.id_return_note,emp.employee_name,IF(rn.id_type=1,'WH Inbound','3PL') AS `type`,st_list.store AS store_list,rn.id_inbound_awb,rn.label_number,rn.date_created,rn.number_return_note,rn.qty AS qty_return_note,rn.date_return_note
,IFNULL(bap.qty_bap,0) AS qty_bap, bap.bap_number
,IFNULL(sc.qty_scan,0) AS qty_scan
,IF(rn.qty - IFNULL(sc.qty_scan,0)-IFNULL(bap.qty_bap,0)=0,'Ok','Not Balance') as status
FROM `tb_return_note` rn
LEFT JOIN
(
    SELECT st.`id_return_note`,GROUP_CONCAT(DISTINCT CONCAT(c.comp_number,' - ',c.comp_name) ORDER BY c.`comp_number` ASC SEPARATOR '\n') AS store
    FROM `tb_return_note_store` st
    INNER JOIN tb_m_comp c ON c.id_comp=st.id_comp
    GROUP BY st.`id_return_note`
)st_list ON st_list.id_return_note=rn.id_return_note
LEFT JOIN 
(
	SELECT bapd.`id_return_note`,SUM(bapd.`qty`*IF(bapd.`id_type`=1,1,-1)) AS qty_bap ,GROUP_CONCAT(DISTINCT(bap.`bap_number`) ORDER BY bap.`bap_number` SEPARATOR '\n') AS bap_number
	FROM tb_scan_return_bap_det bapd 
	INNER JOIN tb_scan_return_bap bap ON bap.`id_scan_return_bap`=bapd.`id_scan_return_bap`
	GROUP BY bapd.`id_return_note`
)bap ON bap.id_return_note=rn.`id_return_note`
LEFT JOIN 
(
    SELECT sc.`id_return_note`,COUNT(scd.`id_scan_return_det`) AS qty_scan
    FROM tb_scan_return_det scd
    INNER JOIN tb_scan_return sc ON sc.`id_scan_return`=scd.`id_scan_return`
    WHERE sc.is_void!=1
    GROUP BY sc.`id_return_note`
)sc ON sc.id_return_note=rn.id_return_note
INNER JOIN tb_m_employee emp ON emp.id_employee=rn.id_emp_driver
WHERE rn.id_type=1 AND rn.id_emp_driver='" & SLEEmp.EditValue.ToString & "' AND DATE(rn.`date_created`)>='" & date_start & "' AND DATE(rn.`date_created`)<='" & date_start & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCAwb.DataSource = dt
        GVAwb.BestFitColumns()
    End Sub

    Private Sub FormScanReturnSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_emp()
        load_3pl()
        DEStart.EditValue = Now
        DEStart3pl.EditValue = Now
    End Sub

End Class