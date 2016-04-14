Public Class FormDataReff 
    Public report_mark_type As String = "-1"
    Public id_pop_up As String = "-1"

    Private Sub FormDataReff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query As String = ""
        query += "select dt.id_data_reff, typ.report_mark_type, typ.report_mark_type_name, dt.remark_data_reff from tb_data_reff dt "
        query += "inner join tb_lookup_report_mark_type typ ON dt.report_mark_type = typ.report_mark_type "
        query += "order by typ.report_mark_type_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDataReff.DataSource = data
    End Sub

    Sub chooseReff()
        Dim id_data_reff As String = "-1"
        Try
            id_data_reff = GVDataReff.GetFocusedRowCellValue("id_data_reff").ToString
        Catch ex As Exception
        End Try

        If id_pop_up = "1" Then ' DISTRIBUTION SCHEME FORM
            FormFGDistSchemeType.id_data_reff = id_data_reff
            FormFGDistSchemeType.id_pop_up = "1"
            FormFGDistSchemeType.ShowDialog()
        ElseIf id_pop_up = "2" Then ' Analisis New Product
            FormFGDistSchemeType.id_data_reff = id_data_reff
            FormFGDistSchemeType.id_pop_up = "3"
            FormFGDistSchemeType.ShowDialog()
        Else
            stopCustom("Sorry, data reference is not available for this time. ")
        End If
        Close()
    End Sub

    Private Sub FormDataReff_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        Cursor = Cursors.WaitCursor
        chooseReff()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDataReff_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVDataReff.DoubleClick
        If GVDataReff.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            chooseReff()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub GVDataReff_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDataReff.FocusedRowChanged
        If GVDataReff.FocusedRowHandle >= 0 Then
            BtnChoose.Enabled = True
        Else
            BtnChoose.Enabled = False
        End If
    End Sub
End Class