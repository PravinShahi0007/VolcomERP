Public Class FormMasterRawMat
    Public id_raw_mat As String
    Public raw_mat As String

    'Load
    Private Sub FormMasterRawMat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewRawMat()
        viewRawMatDetail()
        viewRawMatSupplier()
    End Sub
    'view raw mat
    Sub viewRawMat()
        Try
            Dim query As String = "SELECT a.id_raw_mat, a.raw_mat, b.uom, c.item_category_sub, d.item_category, "
            query += "CONCAT_WS(' ',DATE(a.rec_created),TIME(a.rec_created)) as time_created, " ' time created
            query += "CONCAT_WS(' ',DATE(a.rec_modified),TIME(a.rec_modified)) as time_modified, " ' time modified
            query += "c.id_item_category, a.id_item_category_sub  FROM tb_m_raw_mat a  "
            query += "INNER JOIN tb_m_uom b ON a.id_uom = b.id_uom "
            query += "INNER JOIN tb_m_raw_mat_category_sub c ON c.id_item_category_sub = a.id_item_category_sub "
            query += "INNER JOIN tb_m_raw_mat_category d ON c.id_item_category = d.id_item_category ORDER BY a.raw_mat ASC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            'setTimeFormat(data, "time_created")
            'setTimeFormat(data, "time_modified")
            GCRawMat.DataSource = data
            labelLot()
            If data.Rows.Count <= 0 Then
                XTPDetailLot.PageEnabled = False
            Else
                XTPDetailLot.PageEnabled = True
            End If
        Catch ex As Exception
            errorConnection()
            Close()
        End Try
    End Sub
    'View raw mat detail
    Sub viewRawMatDetail()
        Try
            Dim query As String = "SELECT a.id_raw_mat_detail, a.raw_mat_detail, c.raw_mat_code_name, a.raw_mat_code, "
            query += "d.item_color, e.lot, f.item_size, "
            query += "g.method, a.rec_created, a.rec_modified, a.is_active,  "
            query += "CONCAT_WS(' ',DATE(a.rec_created),TIME(a.rec_created)) as time_created, " ' time created
            query += "CONCAT_WS(' ',DATE(a.rec_modified),TIME(a.rec_modified)) as time_modified " ' time modified
            query += "FROM tb_m_raw_mat_detail a "
            query += "INNER JOIN tb_m_raw_mat b ON a.id_raw_mat = b.id_raw_mat "
            query += "INNER JOIN tb_m_raw_mat_code c ON a.id_raw_mat_code = c.id_raw_mat_code "
            query += "INNER JOIN tb_m_item_color d ON a.id_item_color = d.id_item_color "
            query += "INNER JOIN tb_m_item_lot e ON a.id_item_lot = e.id_item_lot "
            query += "INNER JOIN tb_m_item_size f ON a.id_item_size = f.id_item_size "
            query += "INNER JOIN tb_lookup_inventory_method g ON a.id_method = g.id_method  "
            query += "WHERE a.id_raw_mat = '" + id_raw_mat + "' ORDER BY rec_created ASC"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            'setTimeFormat(data, "time_created")
            'setTimeFormat(data, "time_modified")
            GCLot.DataSource = data
            If data.Rows.Count <= 0 Then
                XTPDetailSupplier.PageEnabled = False
            Else
                XTPDetailSupplier.PageEnabled = True
            End If
        Catch ex As Exception
            errorConnection()
            Close()
        End Try
    End Sub
    'View raw mat supplier
    Sub viewRawMatSupplier()
        Try
            Dim query As String = "SELECT *, CONCAT_WS(' ',DATE(a.rec_created),TIME(a.rec_created)) as time_created, CONCAT_WS(' ',DATE(a.rec_modified),TIME(a.rec_modified)) as time_modified  FROM tb_m_raw_mat_supplier a "
            query += "INNER JOIN tb_m_company b ON a.id_company = b.id_company WHERE a.id_raw_mat_detail='" + GVLot.GetFocusedRowCellDisplayText("id_raw_mat_detail").ToString + "' "
            query += "ORDER BY a.is_default ASC, b.company_name ASC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            'setTimeFormat(data, "time_created")
            'setTimeFormat(data, "time_modified")
            GCSupplier.DataSource = data
            labelSupplierInfo()
        Catch ex As Exception
            errorConnection()
            Close()
        End Try
    End Sub
    'Click Row Raw Mat
    Private Sub GCRawMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GCRawMat.Click
        labelLot()
        viewRawMatDetail()
        viewRawMatSupplier()
    End Sub
    'Set & Get Label Information Raw Mat
    Private Sub labelLot()
        LabelRawMatContent.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(GVRawMat.GetFocusedRowCellDisplayText("raw_mat").ToString)
        raw_mat = GVRawMat.GetFocusedRowCellDisplayText("raw_mat").ToString
        id_raw_mat = GVRawMat.GetFocusedRowCellDisplayText("id_raw_mat").ToString
    End Sub
    'Set & Get Label Information Raw Mat Detail
    Private Sub labelSupplierInfo()
        LabelSupplier.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(GVLot.GetFocusedRowCellDisplayText("raw_mat_detail").ToString)
    End Sub
    'Click GC Raw Mat Detail
    Private Sub GCLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GCLot.Click

        viewRawMatSupplier()
    End Sub
    'Activated
    Private Sub FormMasterRawMat_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
    End Sub
    'Deactivate
    Private Sub FormMasterRawMat_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
    'Detail Lot Click
    Private Sub XTCRawMat_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCRawMat.SelectedPageChanged
        If XTCRawMat.SelectedTabPageIndex.ToString = "1" Then
            FormMain.BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Else
            FormMain.BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If
    End Sub
End Class