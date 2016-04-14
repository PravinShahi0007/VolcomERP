Public Class ClassOwnMenu
    Public gv_main As New DevExpress.XtraGrid.Views.Grid.GridView
    Public Sub createDesignInfoForPD(ByVal menu_par As System.Windows.Forms.ContextMenuStrip, ByVal gv As DevExpress.XtraGrid.Views.Grid.GridView)
        gv_main = gv
        menu_par.Items.Add("Design Info", Nothing, New EventHandler(AddressOf OnDesignInfoClickForPD))
    End Sub

    Private Sub OnDesignInfoClickForPD(ByVal sender As Object, ByVal e As EventArgs)
        Dim id_dsg As String = "-1"
        Try
            id_dsg = gv_main.GetFocusedRowCellValue("id_design_desc_report_column").ToString
        Catch ex As Exception
            stopCustom("Design not found.")
        End Try
        FormMasterDesignSingle.id_design = id_dsg
        FormMasterDesignSingle.id_pop_up = "4"
        FormMasterDesignSingle.ShowDialog()
    End Sub

    Public Sub createDesignInfo(ByVal menu_par As System.Windows.Forms.ContextMenuStrip, ByVal gv As DevExpress.XtraGrid.Views.Grid.GridView)
        gv_main = gv
        menu_par.Items.Add("Design Info", Nothing, New EventHandler(AddressOf OnDesignInfoClick))
    End Sub

    Private Sub OnDesignInfoClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim id_dsg As String = "-1"
        Try
            id_dsg = gv_main.GetFocusedRowCellValue("id_design").ToString
        Catch ex As Exception
            stopCustom("Design not found.")
        End Try
        FormMasterDesignSingle.id_design = id_dsg
        FormMasterDesignSingle.id_pop_up = "4"
        FormMasterDesignSingle.ShowDialog()
    End Sub

    Public Sub removeAllMenu(ByVal menu_par As System.Windows.Forms.ContextMenuStrip)
        For i As Integer = 0 To menu_par.Items.Count - 1
            menu_par.Items.RemoveAt(i)
        Next
    End Sub
End Class
