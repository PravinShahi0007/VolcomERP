Public Class FormEmpUniCreditNoteAdd
    Public id_emp_uni_ex_ref As String = "0"

    Private Sub FormEmpUniCreditNoteAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim data_tmp As DataTable = execute_query("CALL view_emp_uni_ex(" + id_emp_uni_ex_ref + ")", -1, True, "", "", "", "")

        Dim data As DataTable = data_tmp.Clone

        For i = 0 To data_tmp.Rows.Count - 1
            Dim already_in As Boolean = False

            For j = 0 To FormEmpUniCreditNoteDet.GVData.RowCount - 1
                If data_tmp.Rows(i)("id_emp_uni_ex_det").ToString = FormEmpUniCreditNoteDet.GVData.GetRowCellValue(j, "id_emp_uni_ex_det").ToString Then
                    already_in = True
                End If
            Next

            If Not already_in Then
                data.ImportRow(data_tmp.Rows(i))
            End If
        Next

        GCData.DataSource = data
    End Sub

    Private Sub FormEmpUniCreditNoteAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        makeSafeGV(GVData)

        GVData.ActiveFilterString = "[is_checked] = 'yes'"

        If GVData.RowCount > 0 Then
            Dim data As DataTable = FormEmpUniCreditNoteDet.GCData.DataSource

            For i = 0 To GVData.RowCount - 1
                Dim row As DataRow = data.NewRow

                For c = 0 To data.Columns.Count - 1
                    row(data.Columns(c).ColumnName) = GVData.GetRowCellValue(i, data.Columns(c).ColumnName)
                Next

                data.Rows.Add(row)
            Next

            FormEmpUniCreditNoteDet.GCData.DataSource = data

            Close()
        Else
            stopCustom("No item selected.")
        End If

        GVData.ActiveFilterString = ""
    End Sub
End Class