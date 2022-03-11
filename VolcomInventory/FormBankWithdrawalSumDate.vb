Public Class FormBankWithdrawalSumDate
    Private Sub FormBankWithdrawalSumDate_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub BPick_Click(sender As Object, e As EventArgs) Handles BPick.Click
        If Date.Parse(FormBankWithdrawalSum.DEPayment.EditValue.ToString) = Date.Parse(DEReleaseDate.EditValue.ToString) Then
            warningCustom("Same date selected")
        Else
            'update
            For i = 0 To FormBankWithdrawalSum.GVList.RowCount - 1
                Dim q As String = ""
                Try
                    q = "UPDATE tb_pn_summary_det SET id_pn_summary_type='2',change_date_to='" & Date.Parse(DEReleaseDate.EditValue.ToString).ToString("yyyy-MM-dd") & "' WHERE id_pn_summary_det='" & FormBankWithdrawalSum.GVList.GetRowCellValue(i, "id_pn_summary_det").ToString & "'"
                    execute_non_query(q, True, "", "", "", "")
                Catch ex As Exception
                End Try

                q = "UPDATE tb_pn SET date_payment='" & Date.Parse(DEReleaseDate.EditValue.ToString).ToString("yyyy-MM-dd") & "' WHERE id_pn='" & FormBankWithdrawalSum.GVList.GetRowCellValue(i, "id_pn").ToString & "'"
                execute_non_query(q, True, "", "", "", "")

                'reset mark
                q = String.Format("UPDATE tb_report_mark SET id_mark='1',report_mark_lead_time=NULL,report_mark_start_datetime=NULL,report_mark_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'{2}'", "159", FormBankWithdrawalSum.GVList.GetRowCellValue(i, "id_pn").ToString, "1")
                execute_non_query(q, True, "", "", "", "")
                '
                FormReportMark.id_report = FormBankWithdrawalSum.GVList.GetRowCellValue(i, "id_pn").ToString
                FormReportMark.report_mark_type = "159"
                FormReportMark.change_status("1")
                'end reset mark

                'FormBankWithdrawalSum.load_det()
                '
                FormBankWithdrawalDet.Opacity = 0
                FormBankWithdrawalDet.is_print = "1"
                If CEPrintPreview.Checked = True Then
                    FormBankWithdrawalDet.is_print_preview = True
                Else
                    FormBankWithdrawalDet.is_print_preview = False
                End If
                FormBankWithdrawalDet.id_payment = FormBankWithdrawalSum.GVList.GetRowCellValue(i, "id_pn").ToString
                FormBankWithdrawalDet.ShowDialog()
            Next
            '
            Close()
        End If
    End Sub

    Private Sub FormBankWithdrawalSumDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEReleaseDate.EditValue = getTimeDB()
    End Sub
End Class