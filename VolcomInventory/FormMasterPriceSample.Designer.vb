<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterPriceSample
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
        Me.XTCPrice = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPBrowse = New DevExpress.XtraTab.XtraTabPage()
        Me.GCBrowsePrice = New DevExpress.XtraGrid.GridControl()
        Me.GVBrowsePrice = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnClass = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSeasonx = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPriceType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControlNav = New DevExpress.XtraEditors.PanelControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLESeason = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPImport = New DevExpress.XtraTab.XtraTabPage()
        Me.GCPrice = New DevExpress.XtraGrid.GridControl()
        Me.GVPrice = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPriceNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPriceCreated = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPriceNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCPrice.SuspendLayout()
        Me.XTPBrowse.SuspendLayout()
        CType(Me.GCBrowsePrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBrowsePrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNav.SuspendLayout()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPImport.SuspendLayout()
        CType(Me.GCPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCPrice
        '
        Me.XTCPrice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCPrice.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCPrice.Location = New System.Drawing.Point(0, 0)
        Me.XTCPrice.Name = "XTCPrice"
        Me.XTCPrice.SelectedTabPage = Me.XTPBrowse
        Me.XTCPrice.Size = New System.Drawing.Size(697, 408)
        Me.XTCPrice.TabIndex = 2
        Me.XTCPrice.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPBrowse, Me.XTPImport})
        '
        'XTPBrowse
        '
        Me.XTPBrowse.Controls.Add(Me.GCBrowsePrice)
        Me.XTPBrowse.Controls.Add(Me.PanelControlNav)
        Me.XTPBrowse.Name = "XTPBrowse"
        Me.XTPBrowse.Size = New System.Drawing.Size(691, 380)
        Me.XTPBrowse.Text = "Browse"
        '
        'GCBrowsePrice
        '
        Me.GCBrowsePrice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCBrowsePrice.Location = New System.Drawing.Point(0, 37)
        Me.GCBrowsePrice.MainView = Me.GVBrowsePrice
        Me.GCBrowsePrice.Name = "GCBrowsePrice"
        Me.GCBrowsePrice.Size = New System.Drawing.Size(691, 343)
        Me.GCBrowsePrice.TabIndex = 90
        Me.GCBrowsePrice.TabStop = False
        Me.GCBrowsePrice.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBrowsePrice})
        '
        'GVBrowsePrice
        '
        Me.GVBrowsePrice.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnCode, Me.GridColumnSize, Me.GridColumnClass, Me.GridColumnDesc, Me.GridColumnColor, Me.GridColumnPrice, Me.GridColumnSeasonx, Me.GridColumnNo, Me.GridColumnPriceType})
        Me.GVBrowsePrice.GridControl = Me.GCBrowsePrice
        Me.GVBrowsePrice.Name = "GVBrowsePrice"
        Me.GVBrowsePrice.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVBrowsePrice.OptionsBehavior.Editable = False
        Me.GVBrowsePrice.OptionsView.ShowGroupPanel = False
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "sample_code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 1
        '
        'GridColumnSize
        '
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 3
        '
        'GridColumnClass
        '
        Me.GridColumnClass.Caption = "Class"
        Me.GridColumnClass.FieldName = "class"
        Me.GridColumnClass.Name = "GridColumnClass"
        Me.GridColumnClass.Visible = True
        Me.GridColumnClass.VisibleIndex = 4
        '
        'GridColumnDesc
        '
        Me.GridColumnDesc.Caption = "Description"
        Me.GridColumnDesc.FieldName = "sample_name"
        Me.GridColumnDesc.Name = "GridColumnDesc"
        Me.GridColumnDesc.Visible = True
        Me.GridColumnDesc.VisibleIndex = 4
        '
        'GridColumnColor
        '
        Me.GridColumnColor.Caption = "Color"
        Me.GridColumnColor.FieldName = "color"
        Me.GridColumnColor.Name = "GridColumnColor"
        Me.GridColumnColor.Visible = True
        Me.GridColumnColor.VisibleIndex = 6
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.Caption = "Price"
        Me.GridColumnPrice.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "sample_price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 6
        '
        'GridColumnSeasonx
        '
        Me.GridColumnSeasonx.Caption = "Season"
        Me.GridColumnSeasonx.FieldName = "season_orign"
        Me.GridColumnSeasonx.FieldNameSortGroup = "id_season_orign"
        Me.GridColumnSeasonx.Name = "GridColumnSeasonx"
        Me.GridColumnSeasonx.Visible = True
        Me.GridColumnSeasonx.VisibleIndex = 8
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        '
        'GridColumnPriceType
        '
        Me.GridColumnPriceType.Caption = "Price Type"
        Me.GridColumnPriceType.FieldName = "design_price_type"
        Me.GridColumnPriceType.Name = "GridColumnPriceType"
        Me.GridColumnPriceType.Visible = True
        Me.GridColumnPriceType.VisibleIndex = 8
        '
        'PanelControlNav
        '
        Me.PanelControlNav.Controls.Add(Me.BtnView)
        Me.PanelControlNav.Controls.Add(Me.DEFrom)
        Me.PanelControlNav.Controls.Add(Me.LabelControl1)
        Me.PanelControlNav.Controls.Add(Me.SLESeason)
        Me.PanelControlNav.Controls.Add(Me.LabelControl4)
        Me.PanelControlNav.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlNav.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlNav.Name = "PanelControlNav"
        Me.PanelControlNav.Size = New System.Drawing.Size(691, 37)
        Me.PanelControlNav.TabIndex = 100
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(437, 8)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(70, 20)
        Me.BtnView.TabIndex = 3
        Me.BtnView.Text = "View"
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(311, 8)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFrom.Size = New System.Drawing.Size(120, 20)
        Me.DEFrom.TabIndex = 2
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(282, 11)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl1.TabIndex = 99
        Me.LabelControl1.Text = "Date"
        '
        'SLESeason
        '
        Me.SLESeason.Location = New System.Drawing.Point(84, 8)
        Me.SLESeason.Name = "SLESeason"
        Me.SLESeason.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLESeason.Properties.Appearance.Options.UseFont = True
        Me.SLESeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESeason.Properties.View = Me.SearchLookUpEdit1View
        Me.SLESeason.Size = New System.Drawing.Size(191, 20)
        Me.SLESeason.TabIndex = 0
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdSeason, Me.GridColumnSeason})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdSeason
        '
        Me.GridColumnIdSeason.Caption = "Id Season"
        Me.GridColumnIdSeason.FieldName = "id_season_orign"
        Me.GridColumnIdSeason.Name = "GridColumnIdSeason"
        '
        'GridColumnSeason
        '
        Me.GridColumnSeason.Caption = "Season"
        Me.GridColumnSeason.FieldName = "season_orign"
        Me.GridColumnSeason.Name = "GridColumnSeason"
        Me.GridColumnSeason.Visible = True
        Me.GridColumnSeason.VisibleIndex = 0
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(13, 11)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(64, 13)
        Me.LabelControl4.TabIndex = 98
        Me.LabelControl4.Text = "Season Orign"
        '
        'XTPImport
        '
        Me.XTPImport.Controls.Add(Me.GCPrice)
        Me.XTPImport.Name = "XTPImport"
        Me.XTPImport.Size = New System.Drawing.Size(691, 380)
        Me.XTPImport.Text = "Import from Excel"
        '
        'GCPrice
        '
        Me.GCPrice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPrice.Location = New System.Drawing.Point(0, 0)
        Me.GCPrice.MainView = Me.GVPrice
        Me.GCPrice.Name = "GCPrice"
        Me.GCPrice.Size = New System.Drawing.Size(691, 380)
        Me.GCPrice.TabIndex = 0
        Me.GCPrice.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPrice})
        '
        'GVPrice
        '
        Me.GVPrice.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnId, Me.GridColumnPriceNumber, Me.GridColumnPriceCreated, Me.GridColumnPriceNote, Me.GridColumnStatus})
        Me.GVPrice.GridControl = Me.GCPrice
        Me.GVPrice.Name = "GVPrice"
        Me.GVPrice.OptionsView.ShowGroupPanel = False
        '
        'GridColumnId
        '
        Me.GridColumnId.Caption = "Id"
        Me.GridColumnId.FieldName = "id_sample_price"
        Me.GridColumnId.Name = "GridColumnId"
        Me.GridColumnId.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnPriceNumber
        '
        Me.GridColumnPriceNumber.Caption = "Number"
        Me.GridColumnPriceNumber.FieldName = "sample_price_number"
        Me.GridColumnPriceNumber.Name = "GridColumnPriceNumber"
        Me.GridColumnPriceNumber.Visible = True
        Me.GridColumnPriceNumber.VisibleIndex = 0
        '
        'GridColumnPriceCreated
        '
        Me.GridColumnPriceCreated.Caption = "Created Date"
        Me.GridColumnPriceCreated.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnPriceCreated.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnPriceCreated.FieldName = "sample_price_date"
        Me.GridColumnPriceCreated.Name = "GridColumnPriceCreated"
        Me.GridColumnPriceCreated.Visible = True
        Me.GridColumnPriceCreated.VisibleIndex = 1
        '
        'GridColumnPriceNote
        '
        Me.GridColumnPriceNote.Caption = "Note"
        Me.GridColumnPriceNote.FieldName = "sample_price_note"
        Me.GridColumnPriceNote.Name = "GridColumnPriceNote"
        Me.GridColumnPriceNote.Visible = True
        Me.GridColumnPriceNote.VisibleIndex = 2
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.FieldNameSortGroup = "id_report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 3
        '
        'FormMasterPriceSample
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(697, 408)
        Me.Controls.Add(Me.XTCPrice)
        Me.MinimizeBox = False
        Me.Name = "FormMasterPriceSample"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sample Price"
        CType(Me.XTCPrice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCPrice.ResumeLayout(False)
        Me.XTPBrowse.ResumeLayout(False)
        CType(Me.GCBrowsePrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBrowsePrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNav.ResumeLayout(False)
        Me.PanelControlNav.PerformLayout()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPImport.ResumeLayout(False)
        CType(Me.GCPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPrice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCPrice As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPBrowse As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCBrowsePrice As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVBrowsePrice As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnClass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeasonx As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPriceType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControlNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLESeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents XTPImport As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCPrice As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPrice As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPriceNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPriceCreated As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPriceNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
End Class
