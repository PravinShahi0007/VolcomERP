Public Class FormMasterRawMatLotSingle
    Public action As String
    Public id_raw_mat_detail As String
    Dim id_raw_mat_code As String
    Dim id_item_color As String
    Dim id_item_lot As String
    Dim id_item_size As String
    Dim id_item_category As String = FormMasterRawMat.GVRawMat.GetFocusedRowCellDisplayText("id_item_category").ToString
    Dim id_raw_mat As String = FormMasterRawMat.GVRawMat.GetFocusedRowCellDisplayText("id_raw_mat").ToString
    Dim id_item_category_sub As String = FormMasterRawMat.GVRawMat.GetFocusedRowCellDisplayText("id_item_category_sub").ToString
    Dim id_season As String
    Dim raw_mat_code As String
    Public loadku As Integer

    'Load
    Private Sub FormMasterRowMatLotSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewCodeType()
        viewColor()
        viewLot()
        viewSize()
        viewMethod()
        viewStatus()
        viewRange()
        viewSupplier()
        setDescription()
        actionLoad()
    End Sub
    'action load
    Private Sub actionLoad()
        'general load
        LabelTitle.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(FormMasterRawMat.GVRawMat.GetFocusedRowCellDisplayText("raw_mat").ToString) 'capitalize word
        LabelCategory.Text = FormMasterRawMat.GVRawMat.GetFocusedRowCellDisplayText("item_category").ToString
        LabelSubCategory.Text = FormMasterRawMat.GVRawMat.GetFocusedRowCellDisplayText("item_category_sub").ToString
        LabelUOM.Text = FormMasterRawMat.GVRawMat.GetFocusedRowCellDisplayText("uom").ToString

        'load action
        If action = "ins" Then
            Me.Text = "New Detail Raw Material"
            Try
                setRawMatCode()
                loadku = loadku + 1
            Catch ex As Exception
                errorProcess()
            End Try
        ElseIf action = "upd" Then
            Me.Text = "Edit Detail Raw Material"
            Try
                'Set var load
                loadku = loadku + 1

                'Pass data Edit
                Dim query As String = String.Format("SELECT *, CONCAT_WS(' ',DATE(a.rec_created),TIME(a.rec_created)) as time_created, CONCAT_WS(' ',DATE(a.rec_modified),TIME(a.rec_modified)) as time_modified FROM tb_m_raw_mat_detail a INNER JOIN tb_m_raw_mat_supplier b ON a.id_raw_mat_detail = b.id_raw_mat_detail WHERE a.id_raw_mat_detail='{0}' AND b.is_default='1'", id_raw_mat_detail)
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                'setTimeFormat(data, "time_created")
                'setTimeFormat(data, "time_modified")
                TxtCodeRawMat.Text = data.Rows(0)("raw_mat_code").ToString
                TxtUnitPrice.Text = data.Rows(0)("unit_price").ToString
                LEStatus.ItemIndex = LEStatus.Properties.GetDataSourceRowIndex("id_status", data.Rows(0)("is_active").ToString)
                LECodeType.ItemIndex = LECodeType.Properties.GetDataSourceRowIndex("id_raw_mat_code", data.Rows(0)("id_raw_mat_code").ToString)
                LEColor.ItemIndex = LEColor.Properties.GetDataSourceRowIndex("id_item_color", data.Rows(0)("id_item_color").ToString)
                LELot.ItemIndex = LELot.Properties.GetDataSourceRowIndex("id_item_lot", data.Rows(0)("id_item_lot").ToString)
                LESize.ItemIndex = LESize.Properties.GetDataSourceRowIndex("id_item_size", data.Rows(0)("id_item_size").ToString)
                LERange.ItemIndex = LERange.Properties.GetDataSourceRowIndex("id_season", data.Rows(0)("id_season").ToString)
                LEInventoryMethod.ItemIndex = LEInventoryMethod.Properties.GetDataSourceRowIndex("id_method", data.Rows(0)("id_method").ToString)
                LESupplier.ItemIndex = LESupplier.Properties.GetDataSourceRowIndex("id_company", data.Rows(0)("id_company").ToString)
                LabelCreated.Text = data.Rows(0)("time_created").ToString
                LabelModified.Text = data.Rows(0)("time_modified").ToString

                'Readonly form
                LESupplier.Properties.ReadOnly = True
                TxtUnitPrice.Properties.ReadOnly = True
                LECodeType.Properties.ReadOnly = True
                LEColor.Properties.ReadOnly = True
                LELot.Properties.ReadOnly = True
                LESize.Properties.ReadOnly = True
                LERange.Properties.ReadOnly = True
                LEInventoryMethod.Properties.ReadOnly = True
                TxtDesc.Properties.ReadOnly = True
            Catch ex As Exception
                errorProcess()
                Close()
            End Try
        End If
    End Sub
    'view code type
    Private Sub viewCodeType()
        Try
            'cek opt
            Dim query As String = "SELECT only_default_code FROM tb_opt"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            'filter 
            query = "SELECT id_raw_mat_code, raw_mat_code_name FROM tb_m_raw_mat_code WHERE is_active='1' "
            If data.Rows(0)("only_default_code").ToString = "1" Then
                query += "AND is_default='1'"
            End If
            query += "ORDER BY is_default ASC, raw_mat_code_name ASC"

            'pass into LE
            data = execute_query(query, -1, True, "", "", "", "")
            LECodeType.Properties.DataSource = Nothing
            LECodeType.Properties.DataSource = data
            LECodeType.Properties.DisplayMember = "raw_mat_code_name"
            LECodeType.Properties.ValueMember = "id_raw_mat_code"
            LECodeType.ItemIndex = 0
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    'view color
    Private Sub viewColor()
        Try
            Dim query As String = "SELECT a.id_item_color, a.item_color, a.initial_item_color, a.code_item_color FROM tb_m_item_color a WHERE a.is_active='1' ORDER BY a.item_color ASC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            LEColor.Properties.DataSource = Nothing
            LEColor.Properties.DataSource = data
            LEColor.Properties.DisplayMember = "item_color"
            LEColor.Properties.ValueMember = "id_item_color"
            LEColor.ItemIndex = 0
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    'vieew lot 
    Private Sub viewLot()
        Try
            Dim query As String = "SELECT  a.id_item_lot, a.lot, a.lot_code FROM tb_m_item_lot a ORDER BY a.lot ASC"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            LELot.Properties.DataSource = Nothing
            LELot.Properties.DataSource = data
            LELot.Properties.DisplayMember = "lot"
            LELot.Properties.ValueMember = "id_item_lot"
            LELot.ItemIndex = 0
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    'view size
    Private Sub viewSize()
        Try
            Dim query As String = "SELECT a.id_item_size, a.item_size, a.code_item_size FROM tb_m_item_size a ORDER BY a.item_size ASC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            LESize.Properties.DataSource = Nothing
            LESize.Properties.DataSource = Data
            LESize.Properties.DisplayMember = "item_size"
            LESize.Properties.ValueMember = "id_item_size"
            LESize.ItemIndex = 0
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    'view inventory method
    Private Sub viewMethod()
        Try
            Dim query As String = "SELECT * FROM tb_lookup_inventory_method a ORDER BY a.method ASC"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            LEInventoryMethod.Properties.DataSource = Nothing
            LEInventoryMethod.Properties.DataSource = data
            LEInventoryMethod.Properties.DisplayMember = "method"
            LEInventoryMethod.Properties.ValueMember = "id_method"
            LEInventoryMethod.ItemIndex = 0
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    'view status
    Private Sub viewStatus()
        Try
            Dim query As String = "SELECT * FROM tb_lookup_status a ORDER BY a.id_status ASC"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            LEStatus.Properties.DataSource = Nothing
            LEStatus.Properties.DataSource = data
            LEStatus.Properties.DisplayMember = "status"
            LEStatus.Properties.ValueMember = "id_status"
            LEStatus.ItemIndex = 1
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    'view range
    Private Sub viewRange()
        Try
            Dim query As String = "SELECT * FROM tb_season a WHERE a.is_active='1' ORDER BY a.range_season ASC"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            LERange.Properties.DataSource = Nothing
            LERange.Properties.DataSource = data
            LERange.Properties.DisplayMember = "season"
            LERange.Properties.ValueMember = "id_season"
            LERange.ItemIndex = 0
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    'view Supplier
    Private Sub viewSupplier()
        Try
            Dim query As String = "SELECT * FROM tb_m_company a WHERE a.is_active='1' ORDER BY a.company_name ASC"
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
    'Set Id raw Mat code
    Private Sub LECodeType_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LECodeType.EditValueChanged
        id_raw_mat_code = LECodeType.EditValue.ToString
        If loadku > 0 Then
            setRawMatCode()
        End If
    End Sub
    ' Set code color
    Private Sub LEColor_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LEColor.EditValueChanged
        id_item_color = LEColor.EditValue.ToString
        If loadku > 0 Then
            setRawMatCode()
        End If
        setDescription()
    End Sub
    'Set Lot code
    Private Sub LELot_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LELot.EditValueChanged
        id_item_lot = LELot.EditValue.ToString
        If loadku > 0 Then
            setRawMatCode()
        End If
    End Sub
    'Set Code Size
    Private Sub LESize_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LESize.EditValueChanged
        'code_item_size = LESize.GetColumnValue("code_item_size").ToString
        id_item_size = LESize.EditValue.ToString
        If loadku > 0 Then
            setRawMatCode()
        End If
    End Sub
    'Set id_range
    Private Sub LERange_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LERange.EditValueChanged
        id_season = LERange.EditValue.ToString
        If loadku > 0 Then
            setRawMatCode()
        End If
    End Sub
    'Close
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    'Save
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        Me.ValidateChildren()
        If Not formIsValidInGroup(ErrorProviderRawMat, GCtrlDetail) Or Not isDecimal(TxtUnitPrice.Text.ToString) Or Not formIsValidInGroup(ErrorProviderRawMat, GCtrlSupplier) Then
            errorInput()
        Else
            Dim id_company As String = LESupplier.EditValue.ToString
            Dim unit_price As String = TxtUnitPrice.Text
            Dim id_raw_mat_code As String = LECodeType.EditValue.ToString
            Dim raw_mat_code As String = TxtCodeRawMat.Text
            Dim id_item_color As String = LEColor.EditValue.ToString
            Dim id_item_lot As String = LELot.EditValue.ToString
            Dim id_item_size As String = LELot.EditValue.ToString
            Dim id_season As String = LERange.EditValue.ToString
            Dim id_method As String = LEInventoryMethod.EditValue.ToString
            Dim is_active As String = LEStatus.EditValue.ToString
            Dim raw_mat_detail As String = TxtDesc.Text.ToString
            Dim query As String

            If action = "ins" Then
                Try
                    query = String.Format("INSERT INTO tb_m_raw_mat_detail(id_raw_mat, id_raw_mat_code, id_season, raw_mat_code, id_item_color, id_item_lot, id_item_size, id_method, is_active, raw_mat_detail) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');SELECT LAST_INSERT_ID(); ", id_raw_mat, id_raw_mat_code, id_season, raw_mat_code, id_item_color, id_item_lot, id_item_size, id_method, is_active, raw_mat_detail)

                    id_raw_mat_detail = execute_query(query, 0, True, "", "", "", "")
                    query = String.Format("INSERT INTO tb_m_raw_mat_supplier(id_raw_mat_detail, id_company, unit_price, is_default) VALUES ('{0}', '{1}', '{2}', '1')", id_raw_mat_detail, id_company, unit_price)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterRawMat.viewRawMatDetail()
                    Dispose()
                Catch ex As Exception
                    errorConnection()
                End Try
            ElseIf action = "upd" Then
                Try
                    query = String.Format("UPDATE tb_m_raw_mat_detail SET is_active='{0}', rec_modified=NOW() WHERE id_raw_mat_detail='{1}'", is_active, id_raw_mat_detail)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterRawMat.viewRawMatDetail()
                    Dispose()
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
        End If
        Cursor = Cursors.Default
    End Sub
    'Validate code raw mat
    Private Sub TxtCodeRawMat_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodeRawMat.Validating
        EP_TE_cant_blank(ErrorProviderRawMat, TxtCodeRawMat)
    End Sub
    'Set Raw Mat Code Into Textbox
    Private Sub setRawMatCode()
        raw_mat_code = generateCodeRaw(id_raw_mat, id_raw_mat_code, id_item_color, id_item_size, id_item_lot, id_item_category, id_item_category_sub, id_season)
        TxtCodeRawMat.Text = raw_mat_code
    End Sub
    'Close Form
    Private Sub FormMasterRawMatLotSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'Validate Unit Price
    Private Sub TxtUnitPrice_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtUnitPrice.Validating
        EP_TE_cant_blank(ErrorProviderRawMat, TxtUnitPrice)
    End Sub
    'validate desc detail
    Private Sub TxtDesc_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        EP_TE_cant_blank(ErrorProviderRawMat, TxtDesc)
    End Sub
    'Set Description
    Private Sub setDescription()
        Dim desc As String = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(FormMasterRawMat.GVRawMat.GetFocusedRowCellDisplayText("raw_mat").ToString).ToString + " " + LEColor.GetColumnValue("initial_item_color").ToString
        TxtDesc.Text = desc
    End Sub
End Class