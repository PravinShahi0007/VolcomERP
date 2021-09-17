Public Class FormCapsule
    Sub view_season()
        Dim query As String = "
            SELECT a.id_season, a.season
            FROM tb_season a 
            INNER JOIN tb_range b ON a.id_range = b.id_range 
            ORDER BY b.range DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            Dim c As DevExpress.XtraEditors.Controls.CheckedListBoxItem = New DevExpress.XtraEditors.Controls.CheckedListBoxItem

            c.Description = data.Rows(i)("season").ToString
            c.Value = data.Rows(i)("id_season").ToString

            CCBESeason.Properties.Items.Add(c)
        Next
    End Sub

    Sub view_division()
        Dim query As String = "
            SELECT id_code_detail, `code`
            FROM tb_m_code_detail
            WHERE id_code = 32
            ORDER BY id_code_detail ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            Dim c As DevExpress.XtraEditors.Controls.CheckedListBoxItem = New DevExpress.XtraEditors.Controls.CheckedListBoxItem

            c.Description = data.Rows(i)("code").ToString
            c.Value = data.Rows(i)("id_code_detail").ToString

            CCBEDivision.Properties.Items.Add(c)
        Next
    End Sub

    Sub view_class()
        Dim query As String = "
            SELECT id_code_detail, `code`
            FROM tb_m_code_detail
            WHERE id_code = 30
            ORDER BY `code` ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            Dim c As DevExpress.XtraEditors.Controls.CheckedListBoxItem = New DevExpress.XtraEditors.Controls.CheckedListBoxItem

            c.Description = data.Rows(i)("code").ToString
            c.Value = data.Rows(i)("id_code_detail").ToString

            CCBEClass.Properties.Items.Add(c)
        Next
    End Sub
    Private Sub FormCapsule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_season()
        view_division()
        view_class()
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEUntilAcc.EditValue = data_dt.Rows(0)("dt")
    End Sub

    Private Sub FormCapsule_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnExportXLS_Click(sender As Object, e As EventArgs) Handles BtnExportXLS.Click
        Cursor = Cursors.WaitCursor
        Dim save As SaveFileDialog = New SaveFileDialog

        save.Filter = "Excel File | *.xlsx"
        save.ShowDialog()

        If Not save.FileName = "" Then
            Dim op As DevExpress.XtraPrinting.XlsxExportOptionsEx = New DevExpress.XtraPrinting.XlsxExportOptionsEx

            op.ExportType = DevExpress.Export.ExportType.WYSIWYG

            GVData.ExportToXlsx(save.FileName, op)

            infoCustom("File saved.")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        FormMain.SplashScreenManager1.SetWaitFormDescription("Loading data")
        Dim soh_date As String = DateTime.Parse(DEUntilAcc.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim query As String = "CALL view_capsule('" + soh_date + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        'FormMain.SplashScreenManager1.SetWaitFormDescription("Best fit columns")
        'GVData.BestFitColumns()
        FormMain.SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub DEUntilAcc_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntilAcc.EditValueChanged
        resetView()
    End Sub

    Sub resetView()
        GCData.DataSource = Nothing
    End Sub

    Private Sub CESelectedProduct_EditValueChanged(sender As Object, e As EventArgs) Handles CESelectedProduct.EditValueChanged
        If CESelectedProduct.EditValue = True Then
            GCProd.Visible = True
        Else
            GCProd.Visible = False
        End If

    End Sub

    Sub viewProduct()
        Cursor = Cursors.WaitCursor

        'filter product
        Dim where_prod As String = ""
        If Not CCBESeason.EditValue.ToString = "" Then
            where_prod += " AND d.id_season IN (" + CCBESeason.EditValue.ToString + ")"
        End If
        If Not CCBEDivision.EditValue.ToString = "" Then
            where_prod += " AND i.id_division IN (" + CCBEDivision.EditValue.ToString + ")"
        End If
        If Not CCBEClass.EditValue.ToString = "" Then
            where_prod += " AND i.id_class IN (" + CCBEClass.EditValue.ToString + ")"
        End If

        Dim query As String = "SELECT 'No' AS `is_select`, d.id_design,d.design_code AS `code`, d.design_display_name AS `name` 
        FROM tb_m_design d
        LEFT JOIN (
	        SELECT dc.id_design, 
	        MAX(CASE WHEN cd.id_code=32 THEN cd.id_code_detail END) AS `id_division`,
	        MAX(CASE WHEN cd.id_code=32 THEN cd.code_detail_name END) AS `division`,
	        MAX(CASE WHEN cd.id_code=30 THEN cd.id_code_detail END) AS `id_class`,
	        MAX(CASE WHEN cd.id_code=30 THEN cd.display_name END) AS `class`,
	        MAX(CASE WHEN cd.id_code=14 THEN cd.id_code_detail END) AS `id_color`,
	        MAX(CASE WHEN cd.id_code=14 THEN cd.display_name END) AS `color`,
	        MAX(CASE WHEN cd.id_code=14 THEN cd.code_detail_name END) AS `color_desc`,
	        MAX(CASE WHEN cd.id_code=43 THEN cd.id_code_detail END) AS `id_sht`,
	        MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`
	        FROM tb_m_design_code dc
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	        AND cd.id_code IN (32,30,14, 43)
	        GROUP BY dc.id_design
        ) i ON i.id_design = d.id_design
        WHERE d.id_lookup_status_order!=2 "
        query += where_prod
        query += "ORDER BY name ASC, code ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub productList()
        If CESelectedProduct.EditValue = True Then
            viewProduct()
        End If
    End Sub

    Private Sub CCBESeason_EditValueChanged(sender As Object, e As EventArgs) Handles CCBESeason.EditValueChanged
        resetView()
        productList()
    End Sub

    Private Sub CCBEDivision_EditValueChanged(sender As Object, e As EventArgs) Handles CCBEDivision.EditValueChanged
        resetView()
        productList()
    End Sub

    Private Sub CCBEClass_EditValueChanged(sender As Object, e As EventArgs) Handles CCBEClass.EditValueChanged
        resetView()
        productList()
    End Sub
End Class