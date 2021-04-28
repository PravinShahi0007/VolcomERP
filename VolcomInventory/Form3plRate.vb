﻿Public Class Form3plRate
    Dim bnew_active As String = "0"
    Dim bedit_active As String = "0"
    Dim bdel_active As String = "0"

    Private Sub FormPurcReceive_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormPurcReceive_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub Form3plRate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_vendor()
        load_type()
        view_del_type()
    End Sub

    Sub load_vendor()
        Dim q As String = "SELECT 'ALL' AS id_comp,'ALL' comp_name
UNION ALL
SELECT id_comp,comp_name FROM tb_m_comp WHERE id_comp_cat='7' AND is_active='1'"
        viewSearchLookupQuery(SLECargo, q, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub load_type()
        Dim q As String = "SELECT 1 AS id_type,'Outbound' AS type
UNION
SELECT 2 AS id_type,'Inbound' AS type"
        viewSearchLookupQuery(SLEInboundOutbound, q, "id_type", "type", "id_type")
    End Sub

    Sub view_del_type()
        Dim q As String = "SELECT id_del_type, del_type FROM tb_lookup_del_type"
        viewSearchLookupQuery(SLEDelType, q, "id_del_type", "del_type", "id_del_type")
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_list()
    End Sub

    Sub load_list()
        Dim q As String = ""
        Dim qw As String = ""

        If SLECargo.EditValue.ToString = "ALL" Then
            qw = ""
        Else
            qw = "AND 3pl.id_comp='" & SLECargo.EditValue.ToString & "'"
        End If

        q = "SELECT 3pl.`id_3pl_rate`,IF(3pl.id_type=1,'Outbound','Inbound') AS `type`,sub.sub_district,ct.`city`,c.`comp_name`,emp.`employee_name`
,3pl.`cargo_code`,3pl.`cargo_lead_time`,3pl.`cargo_min_weight`,3pl.`cargo_rate`,3pl.`input_datetime`,state.state
FROM tb_3pl_rate 3pl
INNER JOIN tb_m_sub_district sub ON sub.id_sub_district=3pl.id_sub_district
INNER JOIN tb_m_city ct ON ct.`id_city`=sub.`id_city`
INNER JOIN tb_m_state state ON state.`id_state`=ct.`id_state`
INNER JOIN tb_m_comp c ON c.`id_comp`=3pl.`id_comp`
INNER JOIN tb_m_user usr ON usr.`id_user`=3pl.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
WHERE 3pl.id_del_type = '" + SLEDelType.EditValue.ToString + "' AND 3pl.is_active=1 " & qw & " AND 3pl.id_type='" & SLEInboundOutbound.EditValue.ToString & "'"

        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCListRate.DataSource = dt
        GVListRate.BestFitColumns()
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        Form3plRateDet.ShowDialog()
    End Sub

    Private Sub BEdit_Click(sender As Object, e As EventArgs) Handles BEdit.Click
        If GVListRate.RowCount > 0 Then
            Form3plRateDet.id_rate = GVListRate.GetFocusedRowCellValue("id_3pl_rate").ToString
            Form3plRateDet.ShowDialog()
        End If
    End Sub

    Private Sub BImport_Click(sender As Object, e As EventArgs) Handles BImport.Click
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "52"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        print(GCListRate, "3PL Rate " & SLECargo.Text & " - " & SLEDelType.Text & " - " & SLEInboundOutbound.Text)
    End Sub
End Class