Public Class FormMasterRawMatSupplierSingle
    Public id_raw_mat_supplier As String
    Public action As String
    Public id_raw_mat_detail As String

    'Validate
    Private Sub TxtUnitPrice_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtUnitPrice.Validating
        EP_TE_cant_blank(ErrorProviderSupplier, TxtUnitPrice)
    End Sub
    'Form Close
    Private Sub FormMasterRawMatSupplierSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'Cancel
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    'Form Load
    Private Sub FormMasterRawMatSupplierSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewDefault()
        viewSupplier()
        actionLoad()
        fillLabel()
    End Sub
    'View Default
    Private Sub viewDefault()
        Try
            Dim query As String = "SELECT * FROM tb_lookup_default a ORDER BY a.id_default ASC"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            LEDefault.Properties.DataSource = Nothing
            LEDefault.Properties.DataSource = data
            LEDefault.Properties.DisplayMember = "default_name"
            LEDefault.Properties.ValueMember = "id_default"
            LEDefault.ItemIndex = 1
        Catch ex As Exception
            errorConnection()
            Close()
        End Try
    End Sub
    'View Supplier
    Private Sub viewSupplier()
        Try
            Dim query As String = "SELECT * FROM tb_m_company a WHERE a.is_active='1' ORDER BY a.company_printed_name ASC"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            LESupplier.Properties.DataSource = Nothing
            LESupplier.Properties.DataSource = data
            LESupplier.Properties.DisplayMember = "company_name"
            LESupplier.Properties.ValueMember = "id_company"
            LESupplier.ItemIndex = 0
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    'Action Load
    Private Sub actionLoad()
        If action = "upd" Then
            Dim query As String = "SELECT * FROM tb_m_raw_mat_supplier a INNER JOIN tb_m_company b ON a.id_company=b.id_company WHERE a.id_raw_mat_supplier='" + id_raw_mat_supplier + "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtUnitPrice.Text = data.Rows(0)("unit_price").ToString
            LESupplier.ItemIndex = LESupplier.Properties.GetDataSourceRowIndex("id_company", data.Rows(0)("id_company").ToString)
            LEDefault.ItemIndex = LEDefault.Properties.GetDataSourceRowIndex("id_default", data.Rows(0)("is_default").ToString)
        End If
    End Sub
    'Fill Label Information
    Private Sub fillLabel()
        Dim query As String = "SELECT *, CONCAT_WS(' ',DATE(a.rec_created),TIME(a.rec_created)) as time_created, CONCAT_WS(' ',DATE(a.rec_modified),TIME(a.rec_modified)) as time_modified "
        query += "FROM tb_m_raw_mat_detail a "
        query += "INNER JOIN tb_m_raw_mat b ON b.id_raw_mat = a.id_raw_mat "
        query += "INNER JOIN tb_m_raw_mat_category_sub c ON b.id_item_category_sub = c.id_item_category_sub "
        query += "INNER JOIN tb_m_raw_mat_category d ON c.id_item_category = d.id_item_category "
        query += "INNER JOIN tb_season e ON a.id_season = e.id_season "
        query += "INNER JOIN tb_m_item_color f ON a.id_item_color = f.id_item_color "
        query += "INNER JOIN tb_m_item_size g ON a.id_item_size = g.id_item_size "
        query += "INNER JOIN tb_m_item_lot h ON a.id_item_lot = h.id_item_lot "
        query += "INNER JOIN tb_m_uom i ON b.id_uom = i.id_uom "
        query += "WHERE a.id_raw_mat_detail = '" + id_raw_mat_detail + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'setTimeFormat(data, "time_created")
        'setTimeFormat(data, "time_modified")
        LabelCode.Text = data.Rows(0)("raw_mat_code").ToString
        LabelCategory.Text = data.Rows(0)("item_category").ToString
        LabelSubCategory.Text = data.Rows(0)("item_category_sub").ToString
        LabelUOM.Text = data.Rows(0)("uom").ToString
        LabelColor.Text = data.Rows(0)("item_color").ToString
        LabelSize.Text = data.Rows(0)("item_size").ToString
        LabelLot.Text = data.Rows(0)("lot").ToString
        LabelSeason.Text = data.Rows(0)("season").ToString
        LabelCreated.Text = data.Rows(0)("rec_created")
        LabelModified.Text = data.Rows(0)("rec_modified")
        LabelTitle.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(data.Rows(0)("raw_mat_detail").ToString)
    End Sub
    'Save
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        If Not formIsValidInGroup(ErrorProviderSupplier, GCtrlSupplier) Or Not isDecimal(TxtUnitPrice.Text) Then
            errorInput()
        Else
            'Declare Var
            Dim id_company As String = LESupplier.EditValue.ToString
            Dim unit_price As String = TxtUnitPrice.Text.ToString
            Dim is_default As String = LEDefault.EditValue.ToString
            Dim id_raw_mat_detail As String = FormMasterRawMat.GVLot.GetFocusedRowCellDisplayText("id_raw_mat_detail").ToString
            Dim query As String

            'Set no default to others
            If is_default = "1" Then
                query = "UPDATE tb_m_raw_mat_supplier SET is_default='2' WHERE id_raw_mat_detail='" + id_raw_mat_detail + "'"
                execute_non_query(query, True, "", "", "", "")
            End If

            'Action 
            If action = "ins" Then
                Try
                    query = String.Format("INSERT INTO tb_m_raw_mat_supplier(id_raw_mat_detail, id_company, unit_price, is_default) VALUES('{0}', '{1}', '{2}', '{3}')", id_raw_mat_detail, id_company, unit_price, is_default)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterRawMat.viewRawMatSupplier()
                    Dispose()
                Catch ex As Exception
                    errorConnection()
                    Close()
                End Try
            ElseIf action = "upd" Then
                Try
                    query = String.Format("UPDATE tb_m_raw_mat_supplier SET id_company='{0}', unit_price='{1}', is_default='{2}', rec_modified=NOW() WHERE id_raw_mat_supplier='{3}'", id_company, unit_price, is_default, id_raw_mat_supplier)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterRawMat.viewRawMatSupplier()
                    Dispose()
                Catch ex As Exception
                    errorConnection()
                    Close()
                End Try
            End If
        End If
        Cursor = Cursors.Default
    End Sub
End Class