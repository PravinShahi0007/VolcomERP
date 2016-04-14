Public Class FormMappingCOA 
    Public report_mark_type As String = "-1"

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormMappingCOA_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormMappingCOA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not report_mark_type = "-1" Then
            Dim query As String = "SELECT report_mark_type_name,is_auto_posting_coa FROM tb_lookup_report_mark_type WHERE report_mark_type='" & report_mark_type & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            LReportMarkType.Text = data.Rows(0)("report_mark_type_name").ToString

            If data.Rows(0)("is_auto_posting_coa").ToString = "1" Then
                CEAutoPosting.Checked = True
            Else
                CEAutoPosting.Checked = False
            End If

            viewLE()
            load_mapping_coa()
        End If
    End Sub
    Sub viewLE()
        Dim id_comp As String = "0"

        Dim query As String = ""
        query = "SELECT id_dc,dc FROM tb_lookup_dc WHERE id_dc='1' or id_dc='2'"
        Try
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            RILUDebitCredit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("dc", 50, "Debit/Credit"))
            RILUDebitCredit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_dc", 50, "ID Dc"))

            RILUDebitCredit.DataSource = Nothing
            RILUDebitCredit.DataSource = data
            RILUDebitCredit.DisplayMember = "dc"
            RILUDebitCredit.ValueMember = "id_dc"
            RILUDebitCredit.Columns("id_dc").Visible = False

        Catch ex As Exception
            errorCustom(ex.ToString)
        End Try
    End Sub

    Sub load_mapping_coa()
        Dim query As String = "SELECT map.id_coa_mapping,map.id_acc,a.acc_name,map.description,map.is_acc_sup,a.acc_description,map.is_strict,map.id_dc FROM tb_opt_coa_mapping map LEFT JOIN tb_a_acc a ON map.id_acc=a.id_acc WHERE map.report_mark_type='" & report_mark_type & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAcc.DataSource = data
    End Sub

    Private Sub RIColAcc_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RIColAcc.ButtonClick
        FormPopUpCOA.id_pop_up = "2"
        If Not GVAcc.GetFocusedRowCellValue("id_acc").ToString = "" Then
            FormPopUpCOA.id_coa = GVAcc.GetFocusedRowCellValue("id_acc").ToString
        Else
            FormPopUpCOA.id_coa = "-1"
        End If
        FormPopUpCOA.ShowDialog()
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim query As String = ""
        If CEAutoPosting.Checked = True Then 'auto posting
            query = String.Format("UPDATE tb_lookup_report_mark_type SET is_auto_posting_coa='{0}' WHERE report_mark_type='{1}'", "1", report_mark_type)
        Else 'not auto posting
            query = String.Format("UPDATE tb_lookup_report_mark_type SET is_auto_posting_coa='{0}' WHERE report_mark_type='{1}'", "2", report_mark_type)
        End If
        execute_non_query(query, True, "", "", "", "")
        If GVAcc.RowCount > 0 Then
            For i As Integer = 0 To GVAcc.RowCount - 1
                If Not GVAcc.GetRowCellValue(i, "id_acc").ToString = "" Then
                    query = String.Format("UPDATE tb_opt_coa_mapping SET id_acc='{0}',is_acc_sup='{1}',id_dc='{3}',description='{4}' WHERE id_coa_mapping='{2}'", GVAcc.GetRowCellValue(i, "id_acc").ToString, GVAcc.GetRowCellValue(i, "is_acc_sup").ToString, GVAcc.GetRowCellValue(i, "id_coa_mapping").ToString, GVAcc.GetRowCellValue(i, "id_dc").ToString, GVAcc.GetRowCellValue(i, "description").ToString)
                    execute_non_query(query, True, "", "", "", "")
                End If
            Next
            infoCustom("Mapping COA updated.")
            load_mapping_coa()
        End If
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox(GVAcc.GetFocusedRowCellValue("id_dc").ToString)
    End Sub

    Private Sub GVAcc_CustomRowCellEdit(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles GVAcc.CustomRowCellEdit
      
    End Sub

    Private Sub GVAcc_ShowingEditor(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GVAcc.ShowingEditor
        If GVAcc.FocusedColumn.FieldName.ToString = "id_dc" And GVAcc.GetFocusedRowCellValue("is_strict") = "1" Then
            e.Cancel = True
        End If
    End Sub
End Class