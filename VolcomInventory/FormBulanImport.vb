Public Class FormBulanImport
    Private Sub FormBulanImport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEYearStart.EditValue = Now()
        DEYearUntil.EditValue = Now()
        DEYearInput.EditValue = Now()
        '
    End Sub

    Private Sub BViewInput_Click(sender As Object, e As EventArgs) Handles BViewInput.Click
        view_input()
    End Sub

    Sub view_input()
        Dim q As String = "SELECT id_month,month_ind,bi.`bulan`,IF(ISNULL(bi.`bulan`),'no','yes') AS rencana_import
FROM `tb_lookup_month` lm
LEFT JOIN tb_bulan_import bi ON bi.`bulan`=lm.`id_month` AND bi.`year`='" & Date.Parse(DEYearInput.EditValue.ToString).ToString("yyyy") & "'
ORDER BY lm.`id_month` ASC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCPlan.DataSource = dt
    End Sub

    Private Sub BUpdateDuty_Click(sender As Object, e As EventArgs) Handles BUpdateDuty.Click
        If GVPlan.RowCount > 0 Then
            Dim q As String = "DELETE FROM tb_bulan_import WHERE `year`='" & Date.Parse(DEYearInput.EditValue.ToString).ToString("yyyy") & "'"
            execute_non_query(q, True, "", "", "", "")
            '
            GVPlan.ActiveFilterString = "[rencana_import]='yes'"
            If GVPlan.RowCount > 0 Then
                q = "INSERT INTO tb_bulan_import(year,bulan) VALUES"
                For i = 0 To GVPlan.RowCount - 1
                    If Not i = 0 Then
                        q += ","
                    End If
                    q += "('" & Date.Parse(DEYearInput.EditValue.ToString).ToString("yyyy") & "','" & GVPlan.GetRowCellValue(i, "id_month").ToString & "')"
                Next
                execute_non_query(q, True, "", "", "", "")
            End If
            GVPlan.ActiveFilterString = ""
        End If
    End Sub

    Sub del_all()
        For i = GVPlan.RowCount - 1 To 0 Step -1
            GVPlan.DeleteRow(i)
        Next
    End Sub

    Private Sub DEYearInput_EditValueChanged(sender As Object, e As EventArgs) Handles DEYearInput.EditValueChanged
        del_all()
    End Sub
End Class