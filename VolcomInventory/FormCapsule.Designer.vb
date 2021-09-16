<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCapsule
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCapsule))
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumncode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnclass = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncolor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncolor_desc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnparent_color = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnseason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnstt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndivision = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsht = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndesign_first_rec_wh = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnttl_qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnprice_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnunit_price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumngroup_store = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnstate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnarea = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnstore_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraScrollableControl1 = New DevExpress.XtraEditors.XtraScrollableControl()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.DEUntilAcc = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl29 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnExportXLS = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        Me.XtraScrollableControl1.SuspendLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.DEUntilAcc.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilAcc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(272, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(452, 438)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GVData.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GVData.Appearance.Row.Options.UseTextOptions = True
        Me.GVData.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GVData.ColumnPanelRowHeight = 50
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumncode, Me.GridColumnname, Me.GridColumnclass, Me.GridColumncolor, Me.GridColumncolor_desc, Me.GridColumnparent_color, Me.GridColumnseason, Me.GridColumnstt, Me.GridColumndivision, Me.GridColumnsht, Me.GridColumndesign_first_rec_wh, Me.GridColumnttl_qty, Me.GridColumnprice_type, Me.GridColumnunit_price, Me.GridColumncomp_number, Me.GridColumncomp_name, Me.GridColumngroup_store, Me.GridColumnstate, Me.GridColumnarea, Me.GridColumnstore_type, Me.GridColumncomp_status})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ttl_qty", Me.GridColumnttl_qty, "{0:N0}")})
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        Me.GVData.RowHeight = 30
        '
        'GridColumncode
        '
        Me.GridColumncode.Caption = "Code"
        Me.GridColumncode.FieldName = "code"
        Me.GridColumncode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumncode.Name = "GridColumncode"
        Me.GridColumncode.Visible = True
        Me.GridColumncode.VisibleIndex = 0
        '
        'GridColumnname
        '
        Me.GridColumnname.Caption = "Description"
        Me.GridColumnname.FieldName = "name"
        Me.GridColumnname.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumnname.Name = "GridColumnname"
        Me.GridColumnname.Visible = True
        Me.GridColumnname.VisibleIndex = 1
        '
        'GridColumnclass
        '
        Me.GridColumnclass.Caption = "Class"
        Me.GridColumnclass.FieldName = "class"
        Me.GridColumnclass.Name = "GridColumnclass"
        Me.GridColumnclass.Visible = True
        Me.GridColumnclass.VisibleIndex = 2
        '
        'GridColumncolor
        '
        Me.GridColumncolor.Caption = "Color"
        Me.GridColumncolor.FieldName = "color"
        Me.GridColumncolor.Name = "GridColumncolor"
        Me.GridColumncolor.Visible = True
        Me.GridColumncolor.VisibleIndex = 3
        '
        'GridColumncolor_desc
        '
        Me.GridColumncolor_desc.Caption = "Color Description"
        Me.GridColumncolor_desc.FieldName = "color_desc"
        Me.GridColumncolor_desc.Name = "GridColumncolor_desc"
        Me.GridColumncolor_desc.Visible = True
        Me.GridColumncolor_desc.VisibleIndex = 4
        Me.GridColumncolor_desc.Width = 77
        '
        'GridColumnparent_color
        '
        Me.GridColumnparent_color.Caption = "Color Base"
        Me.GridColumnparent_color.FieldName = "parent_color"
        Me.GridColumnparent_color.Name = "GridColumnparent_color"
        Me.GridColumnparent_color.Visible = True
        Me.GridColumnparent_color.VisibleIndex = 5
        '
        'GridColumnseason
        '
        Me.GridColumnseason.Caption = "Season"
        Me.GridColumnseason.FieldName = "season"
        Me.GridColumnseason.Name = "GridColumnseason"
        Me.GridColumnseason.Visible = True
        Me.GridColumnseason.VisibleIndex = 6
        '
        'GridColumnstt
        '
        Me.GridColumnstt.Caption = "Status"
        Me.GridColumnstt.FieldName = "stt"
        Me.GridColumnstt.Name = "GridColumnstt"
        Me.GridColumnstt.Visible = True
        Me.GridColumnstt.VisibleIndex = 7
        '
        'GridColumndivision
        '
        Me.GridColumndivision.Caption = "Section"
        Me.GridColumndivision.FieldName = "division"
        Me.GridColumndivision.Name = "GridColumndivision"
        Me.GridColumndivision.Visible = True
        Me.GridColumndivision.VisibleIndex = 8
        '
        'GridColumnsht
        '
        Me.GridColumnsht.Caption = "Silhouette"
        Me.GridColumnsht.FieldName = "sht"
        Me.GridColumnsht.Name = "GridColumnsht"
        Me.GridColumnsht.Visible = True
        Me.GridColumnsht.VisibleIndex = 9
        '
        'GridColumndesign_first_rec_wh
        '
        Me.GridColumndesign_first_rec_wh.Caption = "Rec. in WH"
        Me.GridColumndesign_first_rec_wh.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumndesign_first_rec_wh.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumndesign_first_rec_wh.FieldName = "design_first_rec_wh"
        Me.GridColumndesign_first_rec_wh.Name = "GridColumndesign_first_rec_wh"
        Me.GridColumndesign_first_rec_wh.Visible = True
        Me.GridColumndesign_first_rec_wh.VisibleIndex = 10
        '
        'GridColumnttl_qty
        '
        Me.GridColumnttl_qty.Caption = "Total Qty"
        Me.GridColumnttl_qty.DisplayFormat.FormatString = "N0"
        Me.GridColumnttl_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnttl_qty.FieldName = "ttl_qty"
        Me.GridColumnttl_qty.Name = "GridColumnttl_qty"
        Me.GridColumnttl_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ttl_qty", "{0:N0}")})
        Me.GridColumnttl_qty.Visible = True
        Me.GridColumnttl_qty.VisibleIndex = 11
        '
        'GridColumnprice_type
        '
        Me.GridColumnprice_type.Caption = "Price Type"
        Me.GridColumnprice_type.FieldName = "price_type"
        Me.GridColumnprice_type.Name = "GridColumnprice_type"
        Me.GridColumnprice_type.Visible = True
        Me.GridColumnprice_type.VisibleIndex = 12
        '
        'GridColumnunit_price
        '
        Me.GridColumnunit_price.Caption = "Unit Price"
        Me.GridColumnunit_price.DisplayFormat.FormatString = "N0"
        Me.GridColumnunit_price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnunit_price.FieldName = "unit_price"
        Me.GridColumnunit_price.Name = "GridColumnunit_price"
        Me.GridColumnunit_price.Visible = True
        Me.GridColumnunit_price.VisibleIndex = 13
        '
        'GridColumncomp_number
        '
        Me.GridColumncomp_number.Caption = "Store Code"
        Me.GridColumncomp_number.FieldName = "comp_number"
        Me.GridColumncomp_number.Name = "GridColumncomp_number"
        Me.GridColumncomp_number.Visible = True
        Me.GridColumncomp_number.VisibleIndex = 14
        '
        'GridColumncomp_name
        '
        Me.GridColumncomp_name.Caption = "Store Description"
        Me.GridColumncomp_name.FieldName = "comp_name"
        Me.GridColumncomp_name.Name = "GridColumncomp_name"
        Me.GridColumncomp_name.Visible = True
        Me.GridColumncomp_name.VisibleIndex = 15
        '
        'GridColumngroup_store
        '
        Me.GridColumngroup_store.Caption = "Store Group"
        Me.GridColumngroup_store.FieldName = "group_store"
        Me.GridColumngroup_store.Name = "GridColumngroup_store"
        Me.GridColumngroup_store.Visible = True
        Me.GridColumngroup_store.VisibleIndex = 16
        '
        'GridColumnstate
        '
        Me.GridColumnstate.Caption = "Province"
        Me.GridColumnstate.FieldName = "state"
        Me.GridColumnstate.Name = "GridColumnstate"
        Me.GridColumnstate.Visible = True
        Me.GridColumnstate.VisibleIndex = 17
        '
        'GridColumnarea
        '
        Me.GridColumnarea.Caption = "Area"
        Me.GridColumnarea.FieldName = "area"
        Me.GridColumnarea.Name = "GridColumnarea"
        Me.GridColumnarea.Visible = True
        Me.GridColumnarea.VisibleIndex = 18
        '
        'GridColumnstore_type
        '
        Me.GridColumnstore_type.Caption = "Store Type"
        Me.GridColumnstore_type.FieldName = "store_type"
        Me.GridColumnstore_type.Name = "GridColumnstore_type"
        Me.GridColumnstore_type.Visible = True
        Me.GridColumnstore_type.VisibleIndex = 19
        '
        'GridColumncomp_status
        '
        Me.GridColumncomp_status.Caption = "Store Status"
        Me.GridColumncomp_status.FieldName = "comp_status"
        Me.GridColumncomp_status.Name = "GridColumncomp_status"
        Me.GridColumncomp_status.Visible = True
        Me.GridColumncomp_status.VisibleIndex = 20
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.XtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left
        Me.XtraTabControl1.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(272, 438)
        Me.XtraTabControl1.TabIndex = 2
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XtraTabPage1.Appearance.Header.Options.UseFont = True
        Me.XtraTabPage1.Controls.Add(Me.XtraScrollableControl1)
        Me.XtraTabPage1.Controls.Add(Me.PanelControl1)
        Me.XtraTabPage1.Image = CType(resources.GetObject("XtraTabPage1.Image"), System.Drawing.Image)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(236, 432)
        '
        'XtraScrollableControl1
        '
        Me.XtraScrollableControl1.Controls.Add(Me.GroupControl3)
        Me.XtraScrollableControl1.Controls.Add(Me.GroupControl2)
        Me.XtraScrollableControl1.Controls.Add(Me.GroupControl1)
        Me.XtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraScrollableControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraScrollableControl1.Name = "XtraScrollableControl1"
        Me.XtraScrollableControl1.Size = New System.Drawing.Size(236, 397)
        Me.XtraScrollableControl1.TabIndex = 0
        '
        'GroupControl3
        '
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl3.Location = New System.Drawing.Point(0, 185)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(219, 9999)
        Me.GroupControl3.TabIndex = 8910
        Me.GroupControl3.Text = "Filter by Store"
        '
        'GroupControl2
        '
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl2.Location = New System.Drawing.Point(0, 89)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(219, 96)
        Me.GroupControl2.TabIndex = 8909
        Me.GroupControl2.Text = "Filter by Product"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.DEUntilAcc)
        Me.GroupControl1.Controls.Add(Me.LabelControl29)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(219, 89)
        Me.GroupControl1.TabIndex = 8908
        Me.GroupControl1.Text = "Filter by Period"
        '
        'DEUntilAcc
        '
        Me.DEUntilAcc.EditValue = Nothing
        Me.DEUntilAcc.Location = New System.Drawing.Point(14, 46)
        Me.DEUntilAcc.Name = "DEUntilAcc"
        Me.DEUntilAcc.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEUntilAcc.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntilAcc.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntilAcc.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntilAcc.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntilAcc.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntilAcc.Size = New System.Drawing.Size(190, 20)
        Me.DEUntilAcc.TabIndex = 8907
        '
        'LabelControl29
        '
        Me.LabelControl29.Location = New System.Drawing.Point(14, 27)
        Me.LabelControl29.Name = "LabelControl29"
        Me.LabelControl29.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl29.TabIndex = 8906
        Me.LabelControl29.Text = "Date"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnExportXLS)
        Me.PanelControl1.Controls.Add(Me.BtnView)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 397)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(236, 35)
        Me.PanelControl1.TabIndex = 1
        '
        'BtnExportXLS
        '
        Me.BtnExportXLS.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnExportXLS.Image = CType(resources.GetObject("BtnExportXLS.Image"), System.Drawing.Image)
        Me.BtnExportXLS.Location = New System.Drawing.Point(86, 2)
        Me.BtnExportXLS.Name = "BtnExportXLS"
        Me.BtnExportXLS.Size = New System.Drawing.Size(84, 31)
        Me.BtnExportXLS.TabIndex = 1
        Me.BtnExportXLS.Text = "Export XLS"
        '
        'BtnView
        '
        Me.BtnView.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnView.Image = CType(resources.GetObject("BtnView.Image"), System.Drawing.Image)
        Me.BtnView.Location = New System.Drawing.Point(170, 2)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(64, 31)
        Me.BtnView.TabIndex = 0
        Me.BtnView.Text = "View"
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Image = CType(resources.GetObject("XtraTabPage2.Image"), System.Drawing.Image)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(236, 432)
        '
        'FormCapsule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 438)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Name = "FormCapsule"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Capsule Data"
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        Me.XtraScrollableControl1.ResumeLayout(False)
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.DEUntilAcc.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilAcc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumncode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnclass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncolor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncolor_desc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnparent_color As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnseason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnstt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndivision As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsht As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndesign_first_rec_wh As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnttl_qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnprice_type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnunit_price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumngroup_store As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnstate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnarea As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnstore_type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraScrollableControl1 As DevExpress.XtraEditors.XtraScrollableControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnExportXLS As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents DEUntilAcc As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl29 As DevExpress.XtraEditors.LabelControl
End Class
