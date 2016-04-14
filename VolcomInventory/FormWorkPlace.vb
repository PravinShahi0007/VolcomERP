Imports DevExpress.XtraGrid.Views.Grid

Public Class FormWorkPlace

    Private Sub FormWorkplace_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_work_place()
    End Sub
    Sub view_work_place()
        Dim query As String = "SELECT *,DATE(rec_time_create) as time, CONCAT_WS(' ',DATE(rec_time_modify),TIME(rec_time_modify)) as time_modify  FROM tb_season ORDER BY id_season ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To (data.Rows.Count - 1)
            data.Rows(i)("time") = FormatDateTime(data.Rows(i)("time").ToString, DateFormat.GeneralDate).ToString
            If data.Rows(i)("time_modify") = "" Or data.Rows(i)("time_modify") = "0000-00-00 00:00:00" Then
                data.Rows(i)("time_modify") = "-"
            Else
                data.Rows(i)("time_modify") = FormatDateTime(data.Rows(i)("time_modify").ToString, DateFormat.GeneralDate).ToString
            End If
        Next
        GCWorkplace.DataSource = data
    End Sub

    Private Sub GVWorkplace_RowStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GVWorkplace.RowStyle
        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            'pick field
            Dim time As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("time"))
            'condition
            If time = Now.Date.AddDays(-5) Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.Salmon
            End If
        End If
    End Sub
End Class