Public Class FormOpt
    Private y As Integer = 10
    Private xLabel As Integer = 10
    Private xInput As Integer = 210

    Private data As New DataTable
    Private dataColumn As New DataTable

    Private column As New DataTable

    Private dataStore As New DataTable

    Private Sub FormOpt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim queryData As String = "SELECT * FROM tb_opt"
        data = execute_query(queryData, -1, True, "", "", "", "")

        Dim queryDataColumn As String = "SHOW COLUMNS FROM tb_opt"
        dataColumn = execute_query(queryDataColumn, -1, True, "", "", "", "")

        Dim queryColumn As String = "
            SELECT 'app_name' `name`, 'Application Name' `text`, 'text' `type`, '' `query`
            UNION SELECT 'system_email' `name`, 'System Email' `text`, 'text' `type`, '' `query`
            UNION SELECT 'system_email_pass' `name`, 'System Email Password' `text`, 'text' `type`, '' `query`
            UNION SELECT 'system_email_server' `name`, 'System Email Server' `text`, 'text' `type`, '' `query`
        "
        column = execute_query(queryColumn, -1, True, "", "", "", "")

        dataStore.Columns.Add("field", GetType(String))
        dataStore.Columns.Add("value", GetType(String))

        For i = 0 To dataColumn.Rows.Count - 1
            'control
            addControl(dataColumn.Rows(i)("Field"))

            If (i + 1) Mod 25 = 0 Then
                y = 10
                xLabel = xInput + 200 + 20
                xInput = xLabel + 210
            End If
        Next
    End Sub

    Private Sub FormOpt_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("0", "0", "0")
    End Sub

    Private Sub FormOpt_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub addControl(ByRef name As String)
        Dim text As String = name
        Dim type As String = "text"
        Dim query As String = ""

        For i = 0 To column.Rows.Count - 1
            If name = column.Rows(i)("name") Then
                text = column.Rows(i)("text")
                type = column.Rows(i)("type")
                query = column.Rows(i)("query")

                Exit For
            End If
        Next

        'label
        Dim cLabel As New DevExpress.XtraEditors.LabelControl

        cLabel.Location = New Point(xLabel, y)
        cLabel.Name = "LC_" + name
        cLabel.Text = text

        XSCGen.Controls.Add(cLabel)

        'input
        If type = "text" Then
            Dim cText As New DevExpress.XtraEditors.TextEdit

            cText.EditValue = data.Rows(0)(name)
            cText.Location = New Point(xInput, y)
            cText.Name = "TE_" + name
            cText.Size = New Size(200, 20)

            AddHandler cText.EditValueChanged, AddressOf Me.texteditChanged

            XSCGen.Controls.Add(cText)
        End If

        If type = "lookup" Then
            Dim cText As New DevExpress.XtraEditors.SearchLookUpEdit

            cText.EditValue = data.Rows(0)(name)
            cText.Location = New Point(xInput, y)
            cText.Name = "TE_" + name
            cText.Size = New Size(200, 20)

            AddHandler cText.EditValueChanged, AddressOf Me.lookupeditChanged

            XSCGen.Controls.Add(cText)

            viewSearchLookupQuery(cText, query, "value", "display", "value")
        End If

        y += 20 + 10
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        Dim query As String = "UPDATE tb_opt SET "

        For i = 0 To dataStore.Rows.Count - 1
            query += dataStore.Rows(i)("field") + " = '" + addSlashes(dataStore.Rows(i)("value")) + "'"

            If Not i = dataStore.Rows.Count - 1 Then
                query += ", "
            End If
        Next

        If dataStore.Rows.Count < 1 Then
            errorCustom("Nothing has changed")
        Else
            Dim confirm As DialogResult
            confirm = DevExpress.XtraEditors.XtraMessageBox.Show(query, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                execute_non_query(query, True, "", "", "", "")

                Close()
            End If
        End If
    End Sub

    Private Sub texteditChanged(sender As Object, e As EventArgs)
        Dim control As DevExpress.XtraEditors.TextEdit = sender

        addDataStore(control.Name.Replace("TE_", ""), control.EditValue.ToString)
    End Sub

    Private Sub lookupeditChanged(sender As Object, e As EventArgs)
        Dim control As DevExpress.XtraEditors.SearchLookUpEdit = sender

        addDataStore(control.Name.Replace("TE_", ""), control.EditValue.ToString)
    End Sub

    Sub addDataStore(ByRef field As String, ByRef value As String)
        Dim already As Boolean = False

        For i = 0 To dataStore.Rows.Count - 1
            If dataStore.Rows(i)("field") = field Then
                dataStore.Rows(i)("value") = value

                already = True

                Exit For
            End If
        Next

        If Not already Then
            dataStore.Rows.Add(field, value)
        End If
    End Sub
End Class