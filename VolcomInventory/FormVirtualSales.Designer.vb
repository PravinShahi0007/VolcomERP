<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormVirtualSales
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormVirtualSales))
        Me.XTCData = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPSalesReport = New DevExpress.XtraTab.XtraTabPage()
        Me.GCSales = New DevExpress.XtraGrid.GridControl()
        Me.GVSales = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_virtual_sales = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_by = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_by_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_comp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group_desc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnstart_period = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnend_period = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_report_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnreport_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal_qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnCreateNew = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPVirtualStock = New DevExpress.XtraTab.XtraTabPage()
        Me.XTCVirtualStock = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPVSBarcode = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPVSMainCode = New DevExpress.XtraTab.XtraTabPage()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.LEPriceType = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEAccount = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn31 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn32 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn33 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnViewAcc = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnExportToXLSAcc = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnBrowseProduct = New DevExpress.XtraEditors.SimpleButton()
        Me.CEFindAllProduct = New DevExpress.XtraEditors.CheckEdit()
        Me.TxtProduct = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl29 = New DevExpress.XtraEditors.LabelControl()
        Me.DEUntilAcc = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl35 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCData.SuspendLayout()
        Me.XTPSalesReport.SuspendLayout()
        CType(Me.GCSales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.XTPVirtualStock.SuspendLayout()
        CType(Me.XTCVirtualStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCVirtualStock.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.LEPriceType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.CEFindAllProduct.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtProduct.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilAcc.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilAcc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCData
        '
        Me.XTCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCData.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCData.Location = New System.Drawing.Point(0, 0)
        Me.XTCData.Name = "XTCData"
        Me.XTCData.SelectedTabPage = Me.XTPSalesReport
        Me.XTCData.Size = New System.Drawing.Size(718, 453)
        Me.XTCData.TabIndex = 0
        Me.XTCData.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPSalesReport, Me.XTPVirtualStock})
        '
        'XTPSalesReport
        '
        Me.XTPSalesReport.Controls.Add(Me.GCSales)
        Me.XTPSalesReport.Controls.Add(Me.PanelControl1)
        Me.XTPSalesReport.Name = "XTPSalesReport"
        Me.XTPSalesReport.Size = New System.Drawing.Size(712, 425)
        Me.XTPSalesReport.Text = "Sales Report List"
        '
        'GCSales
        '
        Me.GCSales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSales.Location = New System.Drawing.Point(0, 51)
        Me.GCSales.MainView = Me.GVSales
        Me.GCSales.Name = "GCSales"
        Me.GCSales.Size = New System.Drawing.Size(712, 374)
        Me.GCSales.TabIndex = 1
        Me.GCSales.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSales})
        '
        'GVSales
        '
        Me.GVSales.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_virtual_sales, Me.GridColumnnumber, Me.GridColumncreated_date, Me.GridColumncreated_by, Me.GridColumncreated_by_name, Me.GridColumnid_comp, Me.GridColumncomp_number, Me.GridColumncomp_name, Me.GridColumncomp_group, Me.GridColumncomp_group_desc, Me.GridColumnstart_period, Me.GridColumnend_period, Me.GridColumnid_report_status, Me.GridColumnreport_status, Me.GridColumnnote, Me.GridColumntotal_qty})
        Me.GVSales.GridControl = Me.GCSales
        Me.GVSales.Name = "GVSales"
        Me.GVSales.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVSales.OptionsBehavior.Editable = False
        Me.GVSales.OptionsFind.AlwaysVisible = True
        Me.GVSales.OptionsView.ColumnAutoWidth = False
        Me.GVSales.OptionsView.ShowFooter = True
        Me.GVSales.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_virtual_sales
        '
        Me.GridColumnid_virtual_sales.Caption = "id_virtual_sales"
        Me.GridColumnid_virtual_sales.FieldName = "id_virtual_sales"
        Me.GridColumnid_virtual_sales.Name = "GridColumnid_virtual_sales"
        '
        'GridColumnnumber
        '
        Me.GridColumnnumber.Caption = "Number"
        Me.GridColumnnumber.FieldName = "number"
        Me.GridColumnnumber.Name = "GridColumnnumber"
        Me.GridColumnnumber.Visible = True
        Me.GridColumnnumber.VisibleIndex = 0
        '
        'GridColumncreated_date
        '
        Me.GridColumncreated_date.Caption = "Created Date"
        Me.GridColumncreated_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumncreated_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumncreated_date.FieldName = "created_date"
        Me.GridColumncreated_date.Name = "GridColumncreated_date"
        Me.GridColumncreated_date.Visible = True
        Me.GridColumncreated_date.VisibleIndex = 8
        '
        'GridColumncreated_by
        '
        Me.GridColumncreated_by.Caption = "created_by"
        Me.GridColumncreated_by.FieldName = "created_by"
        Me.GridColumncreated_by.Name = "GridColumncreated_by"
        '
        'GridColumncreated_by_name
        '
        Me.GridColumncreated_by_name.Caption = "Created By"
        Me.GridColumncreated_by_name.FieldName = "created_by_name"
        Me.GridColumncreated_by_name.Name = "GridColumncreated_by_name"
        Me.GridColumncreated_by_name.Visible = True
        Me.GridColumncreated_by_name.VisibleIndex = 9
        '
        'GridColumnid_comp
        '
        Me.GridColumnid_comp.Caption = "id_comp"
        Me.GridColumnid_comp.FieldName = "id_comp"
        Me.GridColumnid_comp.Name = "GridColumnid_comp"
        '
        'GridColumncomp_number
        '
        Me.GridColumncomp_number.Caption = "Account"
        Me.GridColumncomp_number.FieldName = "comp_number"
        Me.GridColumncomp_number.Name = "GridColumncomp_number"
        Me.GridColumncomp_number.Visible = True
        Me.GridColumncomp_number.VisibleIndex = 3
        '
        'GridColumncomp_name
        '
        Me.GridColumncomp_name.Caption = "Account Description"
        Me.GridColumncomp_name.FieldName = "comp_name"
        Me.GridColumncomp_name.Name = "GridColumncomp_name"
        Me.GridColumncomp_name.Visible = True
        Me.GridColumncomp_name.VisibleIndex = 4
        '
        'GridColumncomp_group
        '
        Me.GridColumncomp_group.Caption = "Store Group"
        Me.GridColumncomp_group.FieldName = "comp_group"
        Me.GridColumncomp_group.Name = "GridColumncomp_group"
        Me.GridColumncomp_group.Visible = True
        Me.GridColumncomp_group.VisibleIndex = 5
        '
        'GridColumncomp_group_desc
        '
        Me.GridColumncomp_group_desc.Caption = "Store Group Desc."
        Me.GridColumncomp_group_desc.FieldName = "comp_group_desc"
        Me.GridColumncomp_group_desc.Name = "GridColumncomp_group_desc"
        Me.GridColumncomp_group_desc.Visible = True
        Me.GridColumncomp_group_desc.VisibleIndex = 6
        Me.GridColumncomp_group_desc.Width = 109
        '
        'GridColumnstart_period
        '
        Me.GridColumnstart_period.Caption = "Start Period"
        Me.GridColumnstart_period.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnstart_period.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnstart_period.FieldName = "start_period"
        Me.GridColumnstart_period.Name = "GridColumnstart_period"
        Me.GridColumnstart_period.Visible = True
        Me.GridColumnstart_period.VisibleIndex = 1
        '
        'GridColumnend_period
        '
        Me.GridColumnend_period.Caption = "End Period"
        Me.GridColumnend_period.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnend_period.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnend_period.FieldName = "end_period"
        Me.GridColumnend_period.Name = "GridColumnend_period"
        Me.GridColumnend_period.Visible = True
        Me.GridColumnend_period.VisibleIndex = 2
        '
        'GridColumnid_report_status
        '
        Me.GridColumnid_report_status.Caption = "id_report_status"
        Me.GridColumnid_report_status.FieldName = "id_report_status"
        Me.GridColumnid_report_status.Name = "GridColumnid_report_status"
        '
        'GridColumnreport_status
        '
        Me.GridColumnreport_status.Caption = "Status"
        Me.GridColumnreport_status.FieldName = "report_status"
        Me.GridColumnreport_status.Name = "GridColumnreport_status"
        Me.GridColumnreport_status.Visible = True
        Me.GridColumnreport_status.VisibleIndex = 10
        '
        'GridColumnnote
        '
        Me.GridColumnnote.Caption = "Note"
        Me.GridColumnnote.FieldName = "note"
        Me.GridColumnnote.Name = "GridColumnnote"
        '
        'GridColumntotal_qty
        '
        Me.GridColumntotal_qty.Caption = "Total Qty"
        Me.GridColumntotal_qty.DisplayFormat.FormatString = "N0"
        Me.GridColumntotal_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal_qty.FieldName = "total_qty"
        Me.GridColumntotal_qty.Name = "GridColumntotal_qty"
        Me.GridColumntotal_qty.Visible = True
        Me.GridColumntotal_qty.VisibleIndex = 7
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnCreateNew)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(712, 51)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnCreateNew
        '
        Me.BtnCreateNew.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnCreateNew.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCreateNew.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnCreateNew.Appearance.Image = CType(resources.GetObject("BtnCreateNew.Appearance.Image"), System.Drawing.Image)
        Me.BtnCreateNew.Appearance.Options.UseBackColor = True
        Me.BtnCreateNew.Appearance.Options.UseFont = True
        Me.BtnCreateNew.Appearance.Options.UseForeColor = True
        Me.BtnCreateNew.Appearance.Options.UseImage = True
        Me.BtnCreateNew.Location = New System.Drawing.Point(11, 11)
        Me.BtnCreateNew.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnCreateNew.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BtnCreateNew.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnCreateNew.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnCreateNew.Name = "BtnCreateNew"
        Me.BtnCreateNew.Size = New System.Drawing.Size(117, 29)
        Me.BtnCreateNew.TabIndex = 23
        Me.BtnCreateNew.Text = "+ Create New"
        '
        'XTPVirtualStock
        '
        Me.XTPVirtualStock.Controls.Add(Me.XTCVirtualStock)
        Me.XTPVirtualStock.Controls.Add(Me.PanelControl2)
        Me.XTPVirtualStock.Name = "XTPVirtualStock"
        Me.XTPVirtualStock.Size = New System.Drawing.Size(712, 425)
        Me.XTPVirtualStock.Text = "Virtual Stock"
        '
        'XTCVirtualStock
        '
        Me.XTCVirtualStock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCVirtualStock.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Right
        Me.XTCVirtualStock.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal
        Me.XTCVirtualStock.Location = New System.Drawing.Point(0, 139)
        Me.XTCVirtualStock.Name = "XTCVirtualStock"
        Me.XTCVirtualStock.SelectedTabPage = Me.XTPVSBarcode
        Me.XTCVirtualStock.Size = New System.Drawing.Size(712, 286)
        Me.XTCVirtualStock.TabIndex = 0
        Me.XTCVirtualStock.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPVSBarcode, Me.XTPVSMainCode})
        '
        'XTPVSBarcode
        '
        Me.XTPVSBarcode.Name = "XTPVSBarcode"
        Me.XTPVSBarcode.Size = New System.Drawing.Size(627, 280)
        Me.XTPVSBarcode.Text = "By Barcode"
        '
        'XTPVSMainCode
        '
        Me.XTPVSMainCode.Name = "XTPVSMainCode"
        Me.XTPVSMainCode.Size = New System.Drawing.Size(627, 331)
        Me.XTPVSMainCode.Text = "By Main Code"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.PanelControl3)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(712, 139)
        Me.PanelControl2.TabIndex = 1
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.LEPriceType)
        Me.PanelControl3.Controls.Add(Me.LabelControl10)
        Me.PanelControl3.Controls.Add(Me.SLEAccount)
        Me.PanelControl3.Controls.Add(Me.PanelControl4)
        Me.PanelControl3.Controls.Add(Me.BtnBrowseProduct)
        Me.PanelControl3.Controls.Add(Me.CEFindAllProduct)
        Me.PanelControl3.Controls.Add(Me.TxtProduct)
        Me.PanelControl3.Controls.Add(Me.LabelControl29)
        Me.PanelControl3.Controls.Add(Me.DEUntilAcc)
        Me.PanelControl3.Controls.Add(Me.LabelControl35)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl3.Location = New System.Drawing.Point(2, 2)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(444, 135)
        Me.PanelControl3.TabIndex = 8928
        '
        'LEPriceType
        '
        Me.LEPriceType.Location = New System.Drawing.Point(183, 172)
        Me.LEPriceType.Name = "LEPriceType"
        Me.LEPriceType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEPriceType.Size = New System.Drawing.Size(185, 20)
        Me.LEPriceType.TabIndex = 8930
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(96, 175)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl10.TabIndex = 8929
        Me.LabelControl10.Text = "Price Type"
        '
        'SLEAccount
        '
        Me.SLEAccount.Location = New System.Drawing.Point(96, 12)
        Me.SLEAccount.Name = "SLEAccount"
        Me.SLEAccount.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLEAccount.Properties.Appearance.Options.UseFont = True
        Me.SLEAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEAccount.Properties.ShowClearButton = False
        Me.SLEAccount.Properties.View = Me.GridView2
        Me.SLEAccount.Size = New System.Drawing.Size(329, 20)
        Me.SLEAccount.TabIndex = 8928
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn31, Me.GridColumn32, Me.GridColumn33})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn31
        '
        Me.GridColumn31.Caption = "Id Comp"
        Me.GridColumn31.FieldName = "id_comp"
        Me.GridColumn31.Name = "GridColumn31"
        '
        'GridColumn32
        '
        Me.GridColumn32.Caption = "Account"
        Me.GridColumn32.FieldName = "comp_number"
        Me.GridColumn32.Name = "GridColumn32"
        Me.GridColumn32.Visible = True
        Me.GridColumn32.VisibleIndex = 0
        '
        'GridColumn33
        '
        Me.GridColumn33.Caption = "Description"
        Me.GridColumn33.FieldName = "comp_name_label"
        Me.GridColumn33.Name = "GridColumn33"
        Me.GridColumn33.Visible = True
        Me.GridColumn33.VisibleIndex = 1
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.BtnViewAcc)
        Me.PanelControl4.Controls.Add(Me.BtnExportToXLSAcc)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl4.Location = New System.Drawing.Point(2, 96)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(440, 37)
        Me.PanelControl4.TabIndex = 8925
        '
        'BtnViewAcc
        '
        Me.BtnViewAcc.Image = CType(resources.GetObject("BtnViewAcc.Image"), System.Drawing.Image)
        Me.BtnViewAcc.Location = New System.Drawing.Point(354, 9)
        Me.BtnViewAcc.LookAndFeel.SkinName = "Blue"
        Me.BtnViewAcc.Name = "BtnViewAcc"
        Me.BtnViewAcc.Size = New System.Drawing.Size(69, 20)
        Me.BtnViewAcc.TabIndex = 8906
        Me.BtnViewAcc.Text = "View"
        '
        'BtnExportToXLSAcc
        '
        Me.BtnExportToXLSAcc.Image = CType(resources.GetObject("BtnExportToXLSAcc.Image"), System.Drawing.Image)
        Me.BtnExportToXLSAcc.Location = New System.Drawing.Point(257, 9)
        Me.BtnExportToXLSAcc.LookAndFeel.SkinName = "Blue"
        Me.BtnExportToXLSAcc.Name = "BtnExportToXLSAcc"
        Me.BtnExportToXLSAcc.Size = New System.Drawing.Size(94, 20)
        Me.BtnExportToXLSAcc.TabIndex = 8907
        Me.BtnExportToXLSAcc.Text = "Export to XLS"
        '
        'BtnBrowseProduct
        '
        Me.BtnBrowseProduct.Enabled = False
        Me.BtnBrowseProduct.Image = CType(resources.GetObject("BtnBrowseProduct.Image"), System.Drawing.Image)
        Me.BtnBrowseProduct.Location = New System.Drawing.Point(399, 38)
        Me.BtnBrowseProduct.LookAndFeel.SkinName = "Blue"
        Me.BtnBrowseProduct.Name = "BtnBrowseProduct"
        Me.BtnBrowseProduct.Size = New System.Drawing.Size(26, 20)
        Me.BtnBrowseProduct.TabIndex = 8904
        Me.BtnBrowseProduct.Text = "..."
        '
        'CEFindAllProduct
        '
        Me.CEFindAllProduct.EditValue = True
        Me.CEFindAllProduct.Location = New System.Drawing.Point(8, 38)
        Me.CEFindAllProduct.Name = "CEFindAllProduct"
        Me.CEFindAllProduct.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CEFindAllProduct.Properties.Appearance.Options.UseFont = True
        Me.CEFindAllProduct.Properties.Caption = "All Product "
        Me.CEFindAllProduct.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CEFindAllProduct.Size = New System.Drawing.Size(72, 19)
        Me.CEFindAllProduct.TabIndex = 8907
        '
        'TxtProduct
        '
        Me.TxtProduct.EditValue = ""
        Me.TxtProduct.Enabled = False
        Me.TxtProduct.Location = New System.Drawing.Point(96, 38)
        Me.TxtProduct.Name = "TxtProduct"
        Me.TxtProduct.Size = New System.Drawing.Size(297, 20)
        Me.TxtProduct.TabIndex = 8906
        '
        'LabelControl29
        '
        Me.LabelControl29.Location = New System.Drawing.Point(9, 67)
        Me.LabelControl29.Name = "LabelControl29"
        Me.LabelControl29.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl29.TabIndex = 8903
        Me.LabelControl29.Text = "Until"
        '
        'DEUntilAcc
        '
        Me.DEUntilAcc.EditValue = Nothing
        Me.DEUntilAcc.Location = New System.Drawing.Point(96, 64)
        Me.DEUntilAcc.Name = "DEUntilAcc"
        Me.DEUntilAcc.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEUntilAcc.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntilAcc.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntilAcc.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntilAcc.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntilAcc.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntilAcc.Size = New System.Drawing.Size(329, 20)
        Me.DEUntilAcc.TabIndex = 8905
        '
        'LabelControl35
        '
        Me.LabelControl35.Location = New System.Drawing.Point(9, 15)
        Me.LabelControl35.Name = "LabelControl35"
        Me.LabelControl35.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl35.TabIndex = 8915
        Me.LabelControl35.Text = "Account"
        '
        'FormVirtualSales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(718, 453)
        Me.Controls.Add(Me.XTCData)
        Me.Name = "FormVirtualSales"
        Me.Text = "Virtual Stock"
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCData.ResumeLayout(False)
        Me.XTPSalesReport.ResumeLayout(False)
        CType(Me.GCSales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.XTPVirtualStock.ResumeLayout(False)
        CType(Me.XTCVirtualStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCVirtualStock.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.LEPriceType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        CType(Me.CEFindAllProduct.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtProduct.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilAcc.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilAcc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCData As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPSalesReport As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCSales As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSales As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnCreateNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnid_virtual_sales As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_by As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_by_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_comp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_group_desc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnstart_period As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnend_period As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_report_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnreport_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal_qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPVirtualStock As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTCVirtualStock As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPVSBarcode As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPVSMainCode As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LEPriceType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEAccount As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn31 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn32 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn33 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnViewAcc As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnExportToXLSAcc As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnBrowseProduct As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CEFindAllProduct As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents TxtProduct As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl29 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEUntilAcc As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl35 As DevExpress.XtraEditors.LabelControl
End Class
