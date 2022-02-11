Public Class FormODMPrintPick
    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_awb()
    End Sub

    Sub load_awb()
        Dim q As String = "SELECT 'yes' AS is_check,d.`awbill_no`,emp.`employee_name`,od.`id_odm_sc`,od.`created_date`,d.id_comp
FROM tb_odm_sc_det odd
INNER JOIN tb_odm_sc od ON odd.`id_odm_sc`=od.`id_odm_sc` AND od.id_report_status!=5
INNER JOIN tb_m_user usr ON usr.`id_user`=od.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_del_manifest d ON d.`id_del_manifest`=odd.`id_del_manifest` AND d.id_report_status=6
LEFT JOIN 
(
    SELECT id_odm_sc ,pd.id_odm_print
    FROM tb_odm_print_det pd
    INNER JOIN tb_odm_print p ON p.id_odm_print=pd.id_odm_print AND p.is_cancel=2
)used ON used.id_odm_sc = odd.id_odm_sc
WHERE ISNULL(used.id_odm_print) AND d.id_comp='" & SLUE3PL.EditValue.ToString & "'
AND DATE(od.created_date)=DATE('" & Date.Parse(DETo.EditValue.ToString).ToString("yyyy-MM-dd") & "') "
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCDOERP.DataSource = dt
        GVDOERP.BestFitColumns()
    End Sub

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub FormODMPrintPick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub view_3pl()
        Dim query As String = "(SELECT id_comp, comp_name AS comp_name FROM tb_m_comp WHERE id_comp_cat = 7)"

        viewSearchLookupQuery(SLUE3PL, query, "id_comp", "comp_name", "id_comp")
    End Sub


    Private Sub FormODMPrintPick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DETo.EditValue = Now
        view_3pl()
    End Sub

    Private Sub BCreateManifest_Click(sender As Object, e As EventArgs) Handles BCreateManifest.Click
        GVDOERP.ActiveFilterString = "[is_check]='yes'"

        If GVDOERP.RowCount > 0 Then
            'head
            Dim q As String = "INSERT INTO `tb_odm_print`(created_date,created_by,id_3pl)
VALUES(NOW(),'" & id_user & "','" & GVDOERP.GetRowCellValue(0, "id_comp").ToString & "'); SELECT LAST_INSERT_ID();"
            Dim id As String = execute_query(q, 0, True, "", "", "", "")

            execute_non_query("CALL gen_number('" & id & "',301)", True, "", "", "", "")
            'detail
            For i = 0 To GVDOERP.RowCount - 1
                q = "INSERT INTO tb_odm_print_det(`id_odm_print`,`id_odm_sc`) VALUES('" & id & "','" & GVDOERP.GetRowCellValue(i, "id_odm_sc").ToString & "')"
                execute_non_query(q, True, "", "", "", "")
            Next

            FormODM.SLE3PLPrint.EditValue = SLUE3PL.EditValue.ToString
            FormODM.load_print_list()

            Close()
        Else
            warningCustom("No AWB selected")
        End If

        GVDOERP.ActiveFilterString = ""
    End Sub
End Class