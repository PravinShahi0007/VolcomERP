Public Class FormAWBOtherDet
    Public id As String = "-1"

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub FormAWBOtherDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormAWBOtherDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_head()
    End Sub

    Sub load_head()
        view_3pl()

        If id = "-1" Then
            'new
            Dim q As String = "SELECT awb.id_comp,awb.pickup_date,awb.created_date,emp.employee_name
FROM `tb_awb_office` awb
INNER JOIN tb_m_comp c ON c.id_comp=awb.id_comp
INNER JOIN tb_m_user usr ON usr.id_user=awb.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
WHERE awb.id_awb_office='" & id & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then

            End If

            load_det()
        Else
            'edit
            load_det()
        End If
    End Sub

    Sub load_det()
        Dim q As String = "SELECT awbo.`awbill_no`,dep.departement,awbo.`jml_koli`,c.comp_name,dis.sub_district,awbo.`client_note`
FROM `tb_awb_office_det` awbo 
INNER JOIN tb_m_departement dep ON dep.id_departement=awbo.id_departement
LEFT JOIN tb_m_comp c ON c.id_comp=awbo.id_client
INNER JOIN tb_m_sub_district dis ON dis.id_sub_district=awbo.id_sub_district
WHERE awbo.id_awb_office='" & id & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCList.DataSource = dt
        GVList.BestFitColumns()
    End Sub

    Sub view_3pl()
        Dim query As String = "SELECT id_comp, comp_name AS comp_name FROM tb_m_comp WHERE id_comp_cat = 7"
        viewSearchLookupQuery(SLUE3PL, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub BDel_Click(sender As Object, e As EventArgs) Handles BDel.Click
        If GVList.RowCount > 0 Then
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = DialogResult.Yes Then
                GVList.DeleteSelectedRows()
            End If
        End If
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click

    End Sub
End Class