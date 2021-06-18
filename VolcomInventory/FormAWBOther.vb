Public Class FormAWBOther
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormAWBOther_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormAWBOther_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If GVAWB.RowCount < 1 Then
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Else
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_form()
    End Sub

    Sub load_form()
        Dim qw As String = ""

        If Not SLECargo.EditValue.ToString = "ALL" Then
            qw = " AND awb.id_comp='" & SLECargo.EditValue.ToString & "'"
        End If

        Dim qv As String = "SELECT IF(awb.is_void=1,'Void','-') AS status,awb.id_awb_office,CONCAT('AWBOFC',LPAD(awb.id_awb_office,5,'0')) AS number,awb.id_comp,awb.pickup_date,awb.created_date,emp.employee_name,awb.pickup_date
FROM `tb_awb_office` awb
INNER JOIN tb_m_comp c ON c.id_comp=awb.id_comp
INNER JOIN tb_m_user usr ON usr.id_user=awb.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
WHERE DATE(awb.pickup_date)>='" & Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND DATE(awb.pickup_date)<='" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "' " & qw
        Dim dt As DataTable = execute_query(qv, -1, True, "", "", "", "")
        GCAWB.DataSource = dt
        GVAWB.BestFitColumns()
        check_menu()
    End Sub

    Private Sub FormAWBOther_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_vendor()
        '
        DEStart.EditValue = Now
        DEUntil.EditValue = Now
    End Sub

    Sub load_vendor()
        Dim q As String = "SELECT 'ALL' AS id_comp,'ALL' comp_name
UNION ALL
SELECT id_comp,comp_name FROM tb_m_comp WHERE id_comp_cat='7' AND is_active='1'"
        viewSearchLookupQuery(SLECargo, q, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub DEStart_EditValueChanged(sender As Object, e As EventArgs) Handles DEStart.EditValueChanged
        DEUntil.Properties.MinValue = DEStart.EditValue
    End Sub

    Private Sub DEUntil_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntil.EditValueChanged
        DEStart.Properties.MaxValue = DEUntil.EditValue
    End Sub
End Class