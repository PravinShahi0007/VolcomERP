Public Class FormPolisRegPop
    Private Sub FormPolisRegPop_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormPolisRegPop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEStore.Text = FormPolisReg.BGVSummary.GetFocusedRowCellValue("comp_name").ToString
        TENomorPolis.Text = FormPolisReg.BGVSummary.GetFocusedRowCellValue("polis_number").ToString
        If FormPolisReg.SLEPPSType.EditValue.ToString = "1" Then
            'kolektif
            load_kolektif()
            TENomorPolis.Properties.ReadOnly = True
            SLEPenawaran.Properties.ReadOnly = True
            TEPremi.Properties.ReadOnly = False
            DEStart.Properties.ReadOnly = True
            DEUntil.Properties.ReadOnly = True
        Else
            'mandiri
            load_mandiri()
            TENomorPolis.Properties.ReadOnly = False
            SLEPenawaran.Properties.ReadOnly = False
            TEPremi.Properties.ReadOnly = False 'bisa verubah kata kezia
            DEStart.Properties.ReadOnly = False
            If FormPolisReg.is_annual = "1" Then
                DEUntil.Properties.ReadOnly = True
            Else
                DEUntil.Properties.ReadOnly = False
            End If
        End If

        'view date
        Dim q As String = "SELECT real_start_date,real_end_date FROM tb_polis_reg_det WHERE id_polis_reg_det='" & FormPolisReg.BGVSummary.GetFocusedRowCellValue("id_polis_reg_det").ToString & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then
            DEStart.EditValue = dt.Rows(0)("real_start_date")
            DEUntil.EditValue = dt.Rows(0)("real_end_date")
        End If
    End Sub

    Sub load_kolektif()
        Dim q As String = ""
        q = "SELECT c.id_comp,c.comp_number,c.comp_name 
FROM tb_polis_pps_kolektif ppsv
INNER JOIN tb_m_comp c ON c.id_comp=ppsv.id_vendor
WHERE ppsv.id_polis_pps='" & FormPolisReg.id_polis_pps & "'
GROUP BY ppsv.id_vendor"
        viewSearchLookupQuery(SLEPenawaran, q, "id_comp", "comp_name", "id_comp")

        If Not FormPolisReg.BGVSummary.GetFocusedRowCellValue("id_vendor_dipilih").ToString = "" Then
            SLEPenawaran.EditValue = FormPolisReg.BGVSummary.GetFocusedRowCellValue("id_vendor_dipilih").ToString
        End If
    End Sub

    Sub load_mandiri()
        Dim q As String = ""
        q = "SELECT c.id_comp,c.comp_number,c.comp_name 
FROM tb_polis_pps_vendor ppsv
INNER JOIN tb_m_comp c ON c.id_comp=ppsv.id_vendor
WHERE ppsv.id_polis_pps='" & FormPolisReg.id_polis_pps & "'
GROUP BY ppsv.id_vendor"
        viewSearchLookupQuery(SLEPenawaran, q, "id_comp", "comp_name", "id_comp")
        If Not FormPolisReg.BGVSummary.GetFocusedRowCellValue("id_vendor_dipilih").ToString = "" Then
            SLEPenawaran.EditValue = FormPolisReg.BGVSummary.GetFocusedRowCellValue("id_vendor_dipilih").ToString
        Else
            SLEPenawaran.EditValue = FormPolisReg.BGVSummary.GetFocusedRowCellValue("id_vendor_rekomendasi").ToString
        End If

        'load premi
        If Not FormPolisReg.BGVSummary.GetFocusedRowCellValue("premi") = 0 Then
            TEPremi.EditValue = FormPolisReg.BGVSummary.GetFocusedRowCellValue("premi")
        End If
    End Sub

    Private Sub BSubmit_Click(sender As Object, e As EventArgs) Handles BSubmit.Click
        If TEPremi.EditValue <= 0 Or TEPremi.Text = "" Then
            warningCustom("Please put premi")
        Else
            Dim q As String = "UPDATE tb_polis_reg_det SET vendor_dipilih='" & SLEPenawaran.EditValue.ToString & "',polis_number='" & addSlashes(TENomorPolis.Text) & "',premi='" & decimalSQL(Decimal.Parse(TEPremi.EditValue.ToString).ToString) & "',real_start_date='" & Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") & "',real_end_date='" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "' WHERE id_polis_reg_det='" & FormPolisReg.BGVSummary.GetFocusedRowCellValue("id_polis_reg_det").ToString & "'"
            execute_non_query(q, True, "", "", "", "")
            FormPolisReg.load_pps_view()
            Close()
        End If
    End Sub

    Private Sub SLEPenawaran_EditValueChanged(sender As Object, e As EventArgs) Handles SLEPenawaran.EditValueChanged
        If FormPolisReg.SLEPPSType.EditValue.ToString = "2" Then
            'mandiri
            Dim q As String = "SELECT * FROM `tb_polis_pps_vendor` WHERE id_polis_pps='" & FormPolisReg.id_polis_pps & "' AND id_comp='" & FormPolisReg.BGVSummary.GetFocusedRowCellValue("id_comp").ToString & "' AND id_vendor='" & SLEPenawaran.EditValue.ToString & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                TEPremi.EditValue = dt.Rows(0)("price")
            Else
                TEPremi.EditValue = 0
            End If
        End If
    End Sub

    Private Sub DEStart_EditValueChanged(sender As Object, e As EventArgs) Handles DEStart.EditValueChanged
        Try
            If FormPolisReg.is_annual = "1" Then
                DEUntil.EditValue = Date.Parse(DEStart.EditValue.ToString).AddYears(1)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class