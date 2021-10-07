Public Class FormPolisRegPop
    Private Sub FormPolisRegPop_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormPolisRegPop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEStore.Text = FormPolisReg.BGVSummary.GetFocusedRowCellValue("comp_name").ToString

        If FormPolisReg.SLEPPSType.EditValue.ToString = "1" Then
            'kolektif
            load_kolektif()
            SLEPenawaran.Properties.ReadOnly = True
            TEPremi.Properties.ReadOnly = False
        Else
            'mandiri
            load_mandiri()
            SLEPenawaran.Properties.ReadOnly = False
            TEPremi.Properties.ReadOnly = True
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
        SLEPenawaran.EditValue = FormPolisReg.BGVSummary.GetFocusedRowCellValue("vendor_dipilih").ToString
    End Sub

    Sub load_mandiri()
        Dim q As String = ""
        q = "SELECT c.id_comp,c.comp_number,c.comp_name 
FROM tb_polis_pps_vendor ppsv
INNER JOIN tb_m_comp c ON c.id_comp=ppsv.id_vendor
WHERE ppsv.id_polis_pps='" & FormPolisReg.id_polis_pps & "'
GROUP BY ppsv.id_vendor"
        viewSearchLookupQuery(SLEPenawaran, q, "id_comp", "comp_name", "id_comp")
        If Not FormPolisReg.BGVSummary.GetFocusedRowCellValue("vendor_dipilih").ToString = "" Then
            SLEPenawaran.EditValue = FormPolisReg.BGVSummary.GetFocusedRowCellValue("vendor_dipilih").ToString
        Else
            SLEPenawaran.EditValue = FormPolisReg.BGVSummary.GetFocusedRowCellValue("vendor_rekomendasi").ToString
        End If
    End Sub

    Private Sub BSubmit_Click(sender As Object, e As EventArgs) Handles BSubmit.Click
        If TEPremi.EditValue <= 0 Or TEPremi.Text = "" Then
            warningCustom("Please put premi")
        Else
            Dim q As String = "UPDATE tb_polis_reg_det SET vendor_dipilih='" & SLEPenawaran.EditValue.ToString & "',premi='" & decimalSQL(Decimal.Parse(TEPremi.EditValue.ToString).ToString) & "' WHERE id_polis_reg_det='" & FormPolisReg.BGVSummary.GetFocusedRowCellValue("id_polis_reg_det").ToString & "'"
            execute_non_query(q, True, "", "", "", "")
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
End Class