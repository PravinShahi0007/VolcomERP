Public Class FormAREvalScheduleDet
    Public action As String = "-1"
    Public id As String = "-1"
    Dim input_again As Boolean = False

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FormAREvalScheduleDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormAREvalScheduleDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        If action = "ins" Then
            If Not input_again Then
                DESchedule.EditValue = getTimeDB()
            End If
        Else
            Dim query As String = "SELECT * FROM tb_ar_eval_setup_date WHERE id_ar_eval_setup_date='" + id + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            DESchedule.EditValue = data.Rows(0)("ar_eval_setup_date")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        Dim tgl As String = DateTime.Parse(DESchedule.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim year As String = DateTime.Parse(DESchedule.EditValue.ToString).Year()

        'cek
        Dim qcek As String = "SELECT * FROM tb_ar_eval_setup_date WHERE ar_eval_setup_date='" + tgl + "' AND id_ar_eval_setup_date!='" + id + "' "
        Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
        If dcek.Rows.Count > 0 Then
            stopCustom("This date already input")
            Cursor = Cursors.Default
            Exit Sub
        End If

        If action = "ins" Then
            Dim query As String = "INSERT INTO tb_ar_eval_setup_date(ar_eval_setup_date) VALUES('" + tgl + "'); SELECT LAST_INSERT_ID(); "
            id = execute_query(query, 0, True, "", "", "", "")
            refreshData(year)
            action = "ins"
            id = "-1"
            input_again = True
            DESchedule.ShowPopup()
            actionLoad()
        Else
            Dim query As String = "UPDATE tb_ar_eval_setup_date SET ar_eval_setup_date='" + tgl + "' WHERE id_ar_eval_setup_date='" + id + "' "
            execute_non_query(query, True, "", "", "", "")
            refreshData(year)
            Close()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub refreshData(ByVal last_year_input As String)
        FormAREvalScheduke.viewYear()
        FormAREvalScheduke.LEYear.ItemIndex = FormAREvalScheduke.LEYear.Properties.GetDataSourceRowIndex("year", last_year_input)
        FormAREvalScheduke.viewData()
        FormAREvalScheduke.GVData.FocusedRowHandle = find_row(FormAREvalScheduke.GVData, "id_ar_eval_setup_date", id)
    End Sub
End Class