Public Class FormBatchUploadOnlineStore
    Private loaded As Boolean = False

    Private Sub FormBatchUploadOnlineStore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_online_store()
        view_season()
        view_division()
        view_product()

        loaded = True
    End Sub

    Private Sub FormBatchUploadOnlineStore_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormBatchUploadOnlineStore_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormBatchUploadOnlineStore_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub view_online_store()
        viewSearchLookupQuery(SLUEOnlineStore, "SELECT * FROM tb_design_column_type", "id_design_column_type", "column_type", "id_design_column_type")
    End Sub

    Sub view_season()
        Dim query As String = "
            (SELECT 0 AS id_season, 'ALL' AS season, 0 AS id_range, 'ALL' AS `range`)
            UNION ALL
            (SELECT a.id_season, a.season, b.id_range, b.range
            FROM tb_season a 
            INNER JOIN tb_range b ON a.id_range = b.id_range 
            ORDER BY b.range DESC)
        "

        viewSearchLookupQuery(SLUESeason, query, "id_season", "season", "id_season")
    End Sub

    Sub view_division()
        Dim query As String = "
            (SELECT 0 AS id_code_detail, 'ALL' AS code)
            UNION ALL
            (SELECT id_code_detail, `code`
            FROM tb_m_code_detail
            WHERE id_code = 32
            ORDER BY id_code_detail ASC)
        "

        viewSearchLookupQuery(SLUEDivision, query, "id_code_detail", "code", "id_code_detail")
    End Sub

    Sub view_product()
        CCBEProduct.Properties.Items.Clear()

        Dim where_season As String = ""

        Try
            where_season = If(SLUESeason.EditValue.ToString = "0", "", " AND d.id_season = " + SLUESeason.EditValue.ToString)
        Catch ex As Exception
        End Try

        Dim where_division As String = ""

        Try
            where_division = If(SLUEDivision.EditValue.ToString = "0", "", " AND c.id_code_detail = " + SLUEDivision.EditValue.ToString)
        Catch ex As Exception
        End Try

        Dim data As DataTable = execute_query("
            SELECT p.id_product, p.product_full_code, p.product_display_name, s.display_name AS size
            FROM tb_m_product AS p
            LEFT JOIN tb_m_design AS d ON p.id_design = d.id_design
            LEFT JOIN (
	            SELECT c.id_design, c.id_code_detail
	            FROM tb_m_design_code AS c
	            LEFT JOIN tb_m_code_detail AS d ON c.id_code_detail = d.id_code_detail
	            WHERE d.id_code = 32
            ) AS c ON c.id_design = p.id_design
            LEFT JOIN (
			    SELECT c.id_product, d.display_name
			    FROM tb_m_product_code AS c
			    LEFT JOIN tb_m_code_detail AS d ON c.id_code_detail = d.id_code_detail
            ) AS s ON p.id_product = s.id_product
            WHERE 1 " + where_season + " " + where_division + "
        ", -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            Dim item As DevExpress.XtraEditors.Controls.CheckedListBoxItem = New DevExpress.XtraEditors.Controls.CheckedListBoxItem

            item.Value = data.Rows(i)("id_product").ToString
            item.Description = data.Rows(i)("product_full_code").ToString + " (" + data.Rows(i)("product_display_name").ToString + ")" + " (" + data.Rows(i)("size").ToString + ")"

            CCBEProduct.Properties.Items.Add(item)
        Next

        CCBEProduct.Properties.DropDownRows = data.Rows.Count + 1
    End Sub

    Sub view_column()
        If SLUEOnlineStore.EditValue.ToString = "3" Then
            column_vios()
        ElseIf SLUEOnlineStore.EditValue.ToString = "4" Then
            column_zalora()
        ElseIf SLUEOnlineStore.EditValue.ToString = "5" Then
            column_blibli()
        ElseIf SLUEOnlineStore.EditValue.ToString = "8" Then
            column_shopee()
        End If
    End Sub

    Sub column_vios()
        Dim data As DataTable = New DataTable

        data.Columns.Add("Data", GetType(String))

        data.Rows.Add(SLUEOnlineStore.Text)

        GCBatchUpload.DataSource = data
    End Sub

    Sub column_zalora()
        Dim data As DataTable = New DataTable

        data.Columns.Add("Data", GetType(String))

        data.Rows.Add(SLUEOnlineStore.Text)

        GCBatchUpload.DataSource = data
    End Sub

    Sub column_blibli()
        Dim data As DataTable = New DataTable

        data.Columns.Add("Data", GetType(String))

        data.Rows.Add(SLUEOnlineStore.Text)

        GCBatchUpload.DataSource = data
    End Sub

    Sub column_shopee()
        Dim data As DataTable = New DataTable

        data.Columns.Add("Data", GetType(String))

        data.Rows.Add(SLUEOnlineStore.Text)

        GCBatchUpload.DataSource = data
    End Sub

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        clear_data()

        view_column()
    End Sub

    Private Sub SBExportExcel_Click(sender As Object, e As EventArgs) Handles SBExportExcel.Click
        Dim save As SaveFileDialog = New SaveFileDialog

        save.Filter = "Excel File | *.xlsx"

        save.ShowDialog()

        If Not save.FileName = "" Then
            GVBatchUpload.ExportToXlsx(save.FileName)

            infoCustom("File saved.")
        End If
    End Sub

    Private Sub SLUEOnlineStore_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEOnlineStore.EditValueChanged
        clear_data()
    End Sub

    Sub clear_data()
        GCBatchUpload.DataSource = Nothing

        GVBatchUpload.Columns.Clear()
    End Sub

    Private Sub SLUESeason_EditValueChanged(sender As Object, e As EventArgs) Handles SLUESeason.EditValueChanged
        If loaded Then
            view_product()
        End If
    End Sub

    Private Sub SLUEDivision_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEDivision.EditValueChanged
        If loaded Then
            view_product()
        End If
    End Sub
End Class