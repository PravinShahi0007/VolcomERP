Public Class FormAccountingMappingList
    Public report_mark_type As String = "-1"

    Private Sub FormAccoutningMappingList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LReportMarkType.Text = FormAccountingMapping.GVMarkAssign.GetFocusedRowCellValue("report_mark_type_name").ToString()
        'WindowState = FormWindowState.Maximized

        load_mapping()
    End Sub

    Sub load_mapping()
        If Not report_mark_type = "-1" Then
            Dim query As String = "SELECT is_auto_posting_coa FROM tb_lookup_report_mark_type WHERE report_mark_type='" & report_mark_type & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows(0)("is_auto_posting_coa").ToString = "1" Then
                CEAutoPosting.Checked = True
            Else
                CEAutoPosting.Checked = False
            End If
            load_mapping_coa()
        End If
    End Sub

    Sub load_mapping_coa()
        Dim query As String = "SELECT map.id_coa_mapping,map.id_acc,a.acc_name,map.description,map.is_acc_sup,a.acc_description,map.is_strict,map.id_dc,l_dc.dc FROM tb_opt_coa_mapping map LEFT JOIN tb_a_acc a ON map.id_acc=a.id_acc LEFT JOIN tb_lookup_dc l_dc ON map.id_dc=l_dc.id_dc WHERE map.report_mark_type='" & report_mark_type & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAcc.DataSource = data
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAdd.Click
        FormAccountingMappingListDet.ShowDialog()
    End Sub

    Private Sub FormAccountingMappingList_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        FormAccountingMappingListDet.id_coa_mapping = GVAcc.GetFocusedRowCellValue("id_coa_mapping").ToString
        FormAccountingMappingListDet.id_acc = GVAcc.GetFocusedRowCellValue("id_acc").ToString
        FormAccountingMappingListDet.is_search_cc = GVAcc.GetFocusedRowCellValue("is_acc_sup").ToString
        FormAccountingMappingListDet.LEpayment.EditValue = GVAcc.GetFocusedRowCellValue("id_dc").ToString
        FormAccountingMappingListDet.MEDesc.Text = GVAcc.GetFocusedRowCellValue("description").ToString
        FormAccountingMappingListDet.TECoaNumber.Text = GVAcc.GetFocusedRowCellValue("acc_name").ToString
        FormAccountingMappingListDet.ShowDialog()
    End Sub
End Class