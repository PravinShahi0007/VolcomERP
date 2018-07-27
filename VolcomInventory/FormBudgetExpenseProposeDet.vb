Public Class FormBudgetExpenseProposeDet
    Public id As String = "-1"
    Public action As String = ""
    Dim id_report_status As String = "-1"
    Public is_view As String = "-1"
    Dim is_confirm As String = "-1"

    Private Sub FormBudgetExpenseProposeDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtTotalInput.EditValue = 0.00
        viewReportStatus()
        viewDept()
        actionLoad()
    End Sub

    'View Data
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewDept()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT id_departement,departement FROM tb_m_departement a ORDER BY a.departement ASC "
        viewLookupQuery(LEDeptSum, query, 0, "departement", "id_departement")
        Cursor = Cursors.Default
    End Sub

    Sub actionLoad()
        If action = "upd" Then
            Dim query_c As New ClassBudgetExpensePropose()
            Dim query As String = query_c.queryMain("AND p.id_b_expense_propose=" + id + "", "2")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TxtYear.Text = data.Rows(0)("year").ToString
            TxtTotal.EditValue = data.Rows(0)("value_expense_total")
            TxtNumber.Text = data.Rows(0)("number").ToString
            DECreated.EditValue = data.Rows(0)("created_date")
            MENote.Text = data.Rows(0)("note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            is_confirm = data.Rows(0)("is_confirm").ToString
            allow_status()
        Else
            LEDeptSum.ItemIndex = LEDeptSum.Properties.GetDataSourceRowIndex("id_departement", id_departement_user)
            XTCBudget.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False
            ActiveControl = TxtYear
        End If
    End Sub

    Sub viewDetailYearly()
        'Dim query As String = ""
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'GCData.DataSource = data
        'GVData.BestFitColumns()
    End Sub

    Sub viewDetailMonthly()
        'Dim query As String = ""
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'GCData.DataSource = data
        'GVData.BestFitColumns()
    End Sub


    Sub allow_status()
        XTCBudget.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        If is_confirm = "2" Then
            BtnImportXLSYearly.Visible = True
            BtnImportXLSMonthly.Visible = True
            BtnMark.Visible = False
            GVData.OptionsBehavior.Editable = True
        Else
            BtnImportXLSYearly.Visible = False
            BtnImportXLSMonthly.Visible = False
            BtnMark.Visible = True
            GVData.OptionsBehavior.Editable = False
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Visible = True
        Else
            BtnPrint.Visible = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
            GVData.OptionsBehavior.Editable = False
        ElseIf id_report_status = "5" Then
            BtnImportXLSYearly.Visible = False
            BtnImportXLSMonthly.Visible = False
            BtnCancell.Visible = False
            BtnConfirm.Visible = False
            GVData.OptionsBehavior.Editable = False
        End If

        If is_view = "1" Then
            XTCBudget.ShowTabHeader = DevExpress.Utils.DefaultBoolean.True
        End If
    End Sub

    Private Sub FormBudgetExpenseProposeDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles BtnNext.Click
        If XTCBudget.SelectedTabPageIndex = 0 Then
            'cek budget
            Dim cond As Boolean = True
            Dim query_c As New ClassBudgetExpensePropose()
            Dim check_upd As String = ""
            If action = "upd" Then
                check_upd = "AND p.id_b_expense_propose!=" + id + " "
            End If
            Dim queryc As String = query_c.queryMain("AND p.year='" + TxtYear.Text + "' AND p.id_report_status!=5 " + check_upd, "2")
            Dim data As DataTable = execute_query(queryc, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                cond = False
            End If

            If Not cond Then
                stopCustom("Revenue budget : " + TxtYear.Text + " already created")
            Else
                Cursor = Cursors.WaitCursor
                Dim id_departement As String = LEDeptSum.EditValue.ToString
                Dim number As String = ""
                Dim year As String = TxtYear.Text
                Dim value_expense_total As String = decimalSQL(TxtTotal.EditValue.ToString)
                Dim note As String = addSlashes(MENote.Text)

                If action = "ins" Then
                    Dim query As String = "INSERT INTO tb_b_expense_propose(id_departement, number, created_date, id_created_user, year, value_expense_total, note, id_report_status) 
                    VALUES('" + id_departement + "', '',NOW(),'" + id_user + "', '" + year + "', '" + value_expense_total + "', '" + note + "',1); SELECT LAST_INSERT_ID(); "
                    id = execute_query(query, 0, True, "", "", "", "")

                    'update number
                    Dim qn As String = "CALL gen_number(" + id + ",136)"
                    execute_non_query(qn, True, "", "", "", "")

                    FormBudgetExpensePropose.viewData()
                    FormBudgetExpensePropose.GVData.FocusedRowHandle = find_row(FormBudgetExpensePropose.GVData, "id_b_expense_propose", id)
                    action = "upd"
                    actionLoad()
                ElseIf action = "upd" Then
                    Dim query As String = "UPDATE tb_b_expense_propose SET year='" + year + "', value_expense_total='" + value_expense_total + "', note='" + note + "'
                    WHERE id_b_expense_propose='" + id + "' "
                    execute_non_query(query, True, "", "", "", "")
                    FormBudgetExpensePropose.viewData()
                    FormBudgetExpensePropose.GVData.FocusedRowHandle = find_row(FormBudgetExpensePropose.GVData, "id_b_expense_propose", id)
                    action = "upd"
                    actionLoad()
                End If
                Cursor = Cursors.Default
            End If
        End If
        XTCBudget.SelectedTabPageIndex = XTCBudget.SelectedTabPageIndex + 1
    End Sub

    Private Sub BtnPrev_Click(sender As Object, e As EventArgs) Handles BtnPrev.Click
        XTCBudget.SelectedTabPageIndex = XTCBudget.SelectedTabPageIndex - 1
    End Sub

    Private Sub XTCBudget_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCBudget.SelectedPageChanged
        If XTCBudget.SelectedTabPageIndex = 0 Then 'total budget
            BtnPrev.Visible = False
            BtnNext.Visible = True
            BtnConfirm.Visible = False
            TxtYear.Focus()
        ElseIf XTCBudget.SelectedTabPageIndex = 1 Then 'yearly budget
            BtnPrev.Visible = True
            BtnNext.Visible = True
            BtnConfirm.Visible = False
        ElseIf XTCBudget.SelectedTabPageIndex = 2 Then 'monthly budget
            BtnPrev.Visible = True
            BtnNext.Visible = False
            If is_confirm = "2" Then
                BtnConfirm.Visible = True
            Else
                BtnConfirm.Visible = False
            End If
        End If
    End Sub

    Private Sub TxtYear_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtYear.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtTotal.Focus()
        End If
    End Sub

    Private Sub TxtTotal_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtTotal.KeyDown
        If e.KeyCode = Keys.Enter Then
            MENote.Focus()
        End If
    End Sub

    Private Sub MENote_KeyDown(sender As Object, e As KeyEventArgs) Handles MENote.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnNext.Focus()
        End If
    End Sub
End Class