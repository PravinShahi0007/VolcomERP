Public Class FormSOPIndexPPS
    Public id As String = "-1"
    Public is_view As String = "-1"

    Private Sub FormSOPIndexPPS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormSOPIndexPPS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_departement()
        If id = "-1" Then
            'new
            SLEDepartement.Properties.ReadOnly = False
            BtnMark.Visible = False
        Else
            'edit
            SLEDepartement.Properties.ReadOnly = True
            BtnMark.Visible = True

            Dim q As String = "SELECT pps.*,sts.report_status,dep.departement,emp.employee_name FROM `tb_sop_pps` pps
INNER JOIN tb_m_departement dep ON dep.id_departement=pps.id_departement
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pps.id_report_status
INNER JOIN tb_m_user usr ON usr.id_user=pps.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
WHERE pps.id_sop_pps='" & id & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                TxtNumber.Text = dt.Rows(0)("number").ToString
                TECreatedBy.Text = dt.Rows(0)("employee_name").ToString
                DECreated.EditValue = dt.Rows(0)("created_date")
                SLEDepartement.EditValue = dt.Rows(0)("id_departement").ToString
            End If
        End If
        load_det()
    End Sub

    Sub load_det()
        Dim q As String = "SELECT ppsd.id_sop_pps_det,ps.id_sop_prosedur_sub,ps.sop_prosedur_sub,ps.sop_prosedur_sub_code,p.sop_prosedur,p.sop_prosedur_code,ppsd.sop_name,ppsd.sop_number
FROM tb_sop_pps_det ppsd
INNER JOIN `tb_sop_prosedur_sub` ps ON ps.id_sop_prosedur_sub=ppsd.id_sop_prosedur_sub
INNER JOIN tb_sop_prosedur p ON p.id_sop_prosedur=ps.id_sop_prosedur 
WHERE ppsd.id_sop_pps='" & id & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCList.DataSource = dt
        GVList.BestFitColumns()
    End Sub

    Sub load_departement()
        Dim q As String = "SELECT id_departement,departement FROM tb_m_departement"
        viewSearchLookupQuery(SLEDepartement, q, "id_departement", "departement", "id_departement")
    End Sub

    Private Sub SLEDepartement_EditValueChanged(sender As Object, e As EventArgs) Handles SLEDepartement.EditValueChanged
        clear_grid()
        load_sub_prosedur()
    End Sub

    Sub load_sub_prosedur()
        Dim q As String = "SELECT ps.id_sop_prosedur_sub,ps.sop_prosedur_sub,ps.sop_prosedur_sub_code,p.sop_prosedur,p.sop_prosedur_code
FROM `tb_sop_prosedur_sub` ps 
INNER JOIN tb_sop_prosedur p ON p.id_sop_prosedur=ps.id_sop_prosedur AND p.is_active=1 AND ps.is_active=1
WHERE p.id_departement='" & SLEDepartement.EditValue.ToString & "'"
        viewSearchLookupQuery(SLESubProsedur, q, "id_sop_prosedur_sub", "sop_prosedur_sub", "id_sop_prosedur_sub")
        SLESubProsedur.EditValue = Nothing
    End Sub

    Sub clear_grid()
        For i As Integer = GVList.RowCount - 1 To 0 Step -1
            GVList.DeleteRow(i)
        Next
    End Sub

    Private Sub BRefreshCat_Click(sender As Object, e As EventArgs) Handles BRefreshCat.Click
        load_sub_prosedur()
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        If Not SLESubProsedur.EditValue = Nothing And Not SLEDepartement.EditValue = Nothing Then
            Cursor = Cursors.WaitCursor
            'check first
            Dim qc As String = "SELECT * FROM tb_sop_pps_det ppsd
INNER JOIN tb_sop_pps pps ON pps.id_sop_pps=ppsd.id_sop_pps
WHERE pps.id_report_status!=5 AND ppsd.id_sop_prosedur_sub='" & SLESubProsedur.EditValue.ToString & "' AND ppsd.sop_name='" & addSlashes(TESOPName.Text) & "'"
            GVList.AddNewRow()
            GVList.FocusedRowHandle = GVList.RowCount - 1
            '
            GVList.SetRowCellValue(GVList.RowCount - 1, "id_sop_prosedur_sub", SLESubProsedur.EditValue.ToString)
            GVList.SetRowCellValue(GVList.RowCount - 1, "sop_prosedur_sub", SLESubProsedur.Properties.View.GetFocusedRowCellValue("sop_prosedur_sub").ToString)
            GVList.SetRowCellValue(GVList.RowCount - 1, "sop_prosedur_sub_code", SLESubProsedur.Properties.View.GetFocusedRowCellValue("sop_prosedur_sub_code").ToString)
            GVList.SetRowCellValue(GVList.RowCount - 1, "sop_prosedur", SLESubProsedur.Properties.View.GetFocusedRowCellValue("sop_prosedur").ToString)
            GVList.SetRowCellValue(GVList.RowCount - 1, "sop_prosedur_code", SLESubProsedur.Properties.View.GetFocusedRowCellValue("sop_prosedur_code").ToString)
            GVList.SetRowCellValue(GVList.RowCount - 1, "sop_name", TESOPName.Text)
            '
            GVList.BestFitColumns()
            Cursor = Cursors.Default
        Else
            warningCustom("Pastikan anda memilih departement dan sub prosedur")
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BCat.Click
        FormSOPCat.ShowDialog()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor

        If GVList.RowCount > 0 Then
            If id = "-1" Then
                'new
                Dim q As String = "INSERT INTO `tb_sop_pps`(id_departement,created_by,created_date,id_report_status) VALUES('" & SLEDepartement.EditValue.ToString & "','" & id_user & "',NOW(),'1');SELECT LAST_INSERT_ID(); "
                id = execute_query(q, 0, True, "", "", "", "")

                execute_non_query("CALL gen_number('" & id & "','375')", True, "", "", "", "")

                q = "INSERT INTO tb_sop_pps_det(`id_sop_pps`,`id_sop_prosedur_sub`,`sop_name`) VALUES"
                For i = 0 To GVList.RowCount - 1
                    If Not i = 0 Then
                        q += ","
                    End If
                    q += "('" & id & "','" & GVList.GetRowCellValue(i, "id_sop_prosedur_sub").ToString & "','" & addSlashes(GVList.GetRowCellValue(i, "sop_name").ToString) & "')"
                Next
                execute_non_query(q, True, "", "", "", "")

                'submit
                submit_who_prepared("375", id, id_user)

                infoCustom("SOP index diajukan, menunggu persetujuan.")
            Else
                'edit.

                Dim q As String = "UPDATE `tb_sop_pps` SET id_departement='" & SLEDepartement.EditValue.ToString & "',created_by='" & id_user & "',created_date=NOW() WHERE id_sop_pps='" & id & "' "
                execute_non_query(q, True, "", "", "", "")

                'delete first
                execute_non_query("DELETE FROM tb_sop_pps_det WHERE id_sop_pps='" & id & "'", True, "", "", "", "")

                'loops
                q = "INSERT INTO tb_sop_pps_det(`id_sop_pps`,`id_sop_prosedur_sub`,`sop_name`) VALUES"
                For i = 0 To GVList.RowCount - 1
                    If Not i = 0 Then
                        q += ","
                    End If
                    q += "('" & id & "','" & GVList.GetRowCellValue(i, "id_sop_prosedur_sub").ToString & "','" & addSlashes(GVList.GetRowCellValue(i, "sop_name").ToString) & "')"
                Next
                execute_non_query(q, True, "", "", "", "")

                infoCustom("SOP index diperbaharui, menunggu persetujuan.")
            End If
        Else
            warningCustom("Pastikan anda memasukkan SOP yang akan didaftarkan")
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "375"
        FormReportMark.id_report = id
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class