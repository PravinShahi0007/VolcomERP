Public Class FormDeptHeadSurvey
    Public is_hrd As String = "-1"

    Sub load_employee()

    End Sub

    Private Sub FormDeptHeadSurvey_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("0", "0", "0")
    End Sub

    Private Sub FormDeptHeadSurvey_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormDeptHeadSurvey_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query_depthead As String = "SELECT id_user_head FROM tb_m_departement WHERE id_departement = '" + id_departement_user + "'"

        Dim id_user_depthead As String = execute_query(query_depthead, 0, True, "", "", "", "")

        TEDeptHead.EditValue = get_emp(id_user_depthead, "3")
        TEDept.EditValue = get_departement_x(id_departement_user, "1")

        Dim query As String = "
            SELECT 0 no, id_question_depthead, question, 1 value, '' information FROM tb_question_depthead
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCList.DataSource = data
        GVList.BestFitColumns()

        query = "SELECT id_question_depthead_value, value FROM tb_lookup_question_depthead_value"

        viewLookupRepositoryQuery(RIUEValue, query, 0, "value", "value")

        generate_number(GVList, "no")
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        GVList.ExpandAllGroups()

        Dim query As String = ""

        For i As Integer = 0 To GVList.RowCount - 1
            query = "INSERT INTO tb_question_depthead_res (id_question_depthead, id_employee, value, information) VALUES ('" + GVList.GetRowCellValue(i, "id_question_depthead").ToString + "', '" + id_employee_user + "', '" + GVList.GetRowCellValue(i, "value").ToString + "', '" + addSlashes(GVList.GetRowCellValue(i, "information").ToString) + "')"

            execute_non_query(query, True, "", "", "", "")
        Next
    End Sub

    Sub generate_number(ByVal GridView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal fieldName As String)
        For i = 0 To GridView.RowCount - 1
            GridView.SetRowCellValue(i, fieldName, i + 1)
        Next
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor

        ReportDeptHeadSurvey.dt = GCList.DataSource

        Dim Report As New ReportDeptHeadSurvey()

        Report.XLDeptHead.Text = TEDeptHead.EditValue.ToString
        Report.XLDept.Text = TEDept.EditValue.ToString

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()

        Cursor = Cursors.Default
    End Sub

    Private Sub RIMEInformation_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles RIMEInformation.Validating

    End Sub
End Class