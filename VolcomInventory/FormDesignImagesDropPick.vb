Public Class FormDesignImagesDropPick
    Private Sub FormDesignImagesDropPick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim in_design As String = ""

        For i = 0 To FormDesignImagesDrop.GVDesignList.RowCount - 1
            in_design += FormDesignImagesDrop.GVDesignList.GetRowCellValue(i, "id_design").ToString + ", "
        Next

        If Not in_design = "" Then
            in_design = in_design.Substring(0, in_design.Length - 2)
        Else
            in_design = "0"
        End If

        Dim query As String = "
            SELECT i.id_design, d.design_code, d.design_display_name
            FROM tb_design_images AS i
            LEFT JOIN tb_m_design AS d ON i.id_design = d.id_design
            WHERE i.id_design NOT IN (" + in_design + ")
            GROUP BY i.id_design
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCDesign.DataSource = data

        GVDesign.BestFitColumns()
    End Sub

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        Dim data As DataTable = FormDesignImagesDrop.GCDesignList.DataSource

        data.Rows.Add(GVDesign.GetFocusedRowCellValue("id_design"), GVDesign.GetFocusedRowCellValue("design_code"), GVDesign.GetFocusedRowCellValue("design_display_name"))

        FormDesignImagesDrop.GCDesignList.DataSource = data

        Close()
    End Sub

    Private Sub FormDesignImagesDropPick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class