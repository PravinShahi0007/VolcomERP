<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMasterSample
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterSample))
        Me.GCSample = New DevExpress.XtraGrid.GridControl()
        Me.GVSample = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnNormalReject = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RCISample = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.ColSampleID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSampleDisplayName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSampleName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSampleUSCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSampleUOM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSampleSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSeasonOrigin = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSampleCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSamplePriceName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCurr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLastPriceName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLastPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCurrLast = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFOBPriceName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCurrFOBPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFOBPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLastVendorCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnVendor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PBCLineList = New DevExpress.XtraEditors.ProgressBarControl()
        Me.BStatusNR = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PanelControlNavLineListBottom = New DevExpress.XtraEditors.PanelControl()
        Me.PCSelAll = New DevExpress.XtraEditors.PanelControl()
        Me.CheckEditSelAll = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.GCSample, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSample, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RCISample, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBCLineList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlNavLineListBottom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNavLineListBottom.SuspendLayout()
        CType(Me.PCSelAll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCSelAll.SuspendLayout()
        CType(Me.CheckEditSelAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCSample
        '
        Me.GCSample.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSample.Location = New System.Drawing.Point(0, 0)
        Me.GCSample.MainView = Me.GVSample
        Me.GCSample.Name = "GCSample"
        Me.GCSample.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RCISample})
        Me.GCSample.Size = New System.Drawing.Size(940, 373)
        Me.GCSample.TabIndex = 3
        Me.GCSample.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSample, Me.GridView2})
        '
        'GVSample
        '
        Me.GVSample.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNormalReject, Me.GridColumn6, Me.ColSampleID, Me.ColSampleDisplayName, Me.ColSampleName, Me.ColSampleUSCode, Me.ColSampleUOM, Me.ColSampleSeason, Me.ColSeasonOrigin, Me.ColSampleCode, Me.GridColumnIdSeason, Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumnNo, Me.GridColumnSamplePriceName, Me.GridColumnCurr, Me.GridColumnPrice, Me.GridColumnLastPriceName, Me.GridColumnLastPrice, Me.GridColumnCurrLast, Me.GridColumnFOBPriceName, Me.GridColumnCurrFOBPrice, Me.GridColumnFOBPrice, Me.GridColumnLastVendorCode, Me.GridColumnVendor})
        Me.GVSample.GridControl = Me.GCSample
        Me.GVSample.GroupCount = 1
        Me.GVSample.Name = "GVSample"
        Me.GVSample.OptionsView.ColumnAutoWidth = False
        Me.GVSample.OptionsView.ShowGroupPanel = False
        Me.GVSample.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColSampleSeason, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'GridColumnNormalReject
        '
        Me.GridColumnNormalReject.Caption = "Normal/Reject"
        Me.GridColumnNormalReject.FieldName = "status_nr"
        Me.GridColumnNormalReject.Name = "GridColumnNormalReject"
        Me.GridColumnNormalReject.Visible = True
        Me.GridColumnNormalReject.VisibleIndex = 23
        '
        'GridColumn6
        '
        Me.GridColumn6.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn6.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn6.Caption = "*"
        Me.GridColumn6.ColumnEdit = Me.RCISample
        Me.GridColumn6.FieldName = "checkbox"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 0
        Me.GridColumn6.Width = 52
        '
        'RCISample
        '
        Me.RCISample.AutoHeight = False
        Me.RCISample.Name = "RCISample"
        Me.RCISample.ValueChecked = "yes"
        Me.RCISample.ValueUnchecked = "no"
        '
        'ColSampleID
        '
        Me.ColSampleID.Caption = "Id Sample"
        Me.ColSampleID.FieldName = "id_sample"
        Me.ColSampleID.Name = "ColSampleID"
        Me.ColSampleID.OptionsColumn.AllowEdit = False
        '
        'ColSampleDisplayName
        '
        Me.ColSampleDisplayName.Caption = "Display Description"
        Me.ColSampleDisplayName.FieldName = "sample_display_name"
        Me.ColSampleDisplayName.Name = "ColSampleDisplayName"
        Me.ColSampleDisplayName.OptionsColumn.AllowEdit = False
        Me.ColSampleDisplayName.Visible = True
        Me.ColSampleDisplayName.VisibleIndex = 5
        Me.ColSampleDisplayName.Width = 69
        '
        'ColSampleName
        '
        Me.ColSampleName.Caption = "Description"
        Me.ColSampleName.FieldName = "sample_name"
        Me.ColSampleName.Name = "ColSampleName"
        Me.ColSampleName.OptionsColumn.AllowEdit = False
        Me.ColSampleName.Visible = True
        Me.ColSampleName.VisibleIndex = 6
        Me.ColSampleName.Width = 69
        '
        'ColSampleUSCode
        '
        Me.ColSampleUSCode.Caption = "US Code"
        Me.ColSampleUSCode.FieldName = "sample_us_code"
        Me.ColSampleUSCode.Name = "ColSampleUSCode"
        Me.ColSampleUSCode.OptionsColumn.AllowEdit = False
        Me.ColSampleUSCode.Visible = True
        Me.ColSampleUSCode.VisibleIndex = 3
        Me.ColSampleUSCode.Width = 69
        '
        'ColSampleUOM
        '
        Me.ColSampleUOM.Caption = "UOM"
        Me.ColSampleUOM.FieldName = "id_uom"
        Me.ColSampleUOM.Name = "ColSampleUOM"
        Me.ColSampleUOM.OptionsColumn.AllowEdit = False
        '
        'ColSampleSeason
        '
        Me.ColSampleSeason.Caption = "Season"
        Me.ColSampleSeason.FieldName = "season"
        Me.ColSampleSeason.FieldNameSortGroup = "id_season"
        Me.ColSampleSeason.Name = "ColSampleSeason"
        Me.ColSampleSeason.OptionsColumn.AllowEdit = False
        '
        'ColSeasonOrigin
        '
        Me.ColSeasonOrigin.Caption = "Season Orign"
        Me.ColSeasonOrigin.FieldName = "season_orign"
        Me.ColSeasonOrigin.Name = "ColSeasonOrigin"
        Me.ColSeasonOrigin.OptionsColumn.AllowEdit = False
        Me.ColSeasonOrigin.Visible = True
        Me.ColSeasonOrigin.VisibleIndex = 2
        Me.ColSeasonOrigin.Width = 69
        '
        'ColSampleCode
        '
        Me.ColSampleCode.Caption = "Code"
        Me.ColSampleCode.FieldName = "sample_code"
        Me.ColSampleCode.Name = "ColSampleCode"
        Me.ColSampleCode.OptionsColumn.AllowEdit = False
        Me.ColSampleCode.Visible = True
        Me.ColSampleCode.VisibleIndex = 4
        Me.ColSampleCode.Width = 69
        '
        'GridColumnIdSeason
        '
        Me.GridColumnIdSeason.Caption = "Id Season"
        Me.GridColumnIdSeason.FieldName = "id_season"
        Me.GridColumnIdSeason.Name = "GridColumnIdSeason"
        Me.GridColumnIdSeason.OptionsColumn.AllowEdit = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Source"
        Me.GridColumn1.FieldName = "Sample Source"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 7
        Me.GridColumn1.Width = 69
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Category"
        Me.GridColumn2.FieldName = "Sample Category"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 8
        Me.GridColumn2.Width = 69
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Color"
        Me.GridColumn3.FieldName = "Color"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 9
        Me.GridColumn3.Width = 69
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Size"
        Me.GridColumn4.FieldName = "size"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 10
        Me.GridColumn4.Width = 69
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Division"
        Me.GridColumn5.FieldName = "Sample Division"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 11
        Me.GridColumn5.Width = 69
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.OptionsColumn.AllowEdit = False
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 1
        Me.GridColumnNo.Width = 69
        '
        'GridColumnSamplePriceName
        '
        Me.GridColumnSamplePriceName.Caption = "Default Cost Name"
        Me.GridColumnSamplePriceName.FieldName = "sample_price_name"
        Me.GridColumnSamplePriceName.Name = "GridColumnSamplePriceName"
        Me.GridColumnSamplePriceName.OptionsColumn.AllowEdit = False
        Me.GridColumnSamplePriceName.Visible = True
        Me.GridColumnSamplePriceName.VisibleIndex = 14
        Me.GridColumnSamplePriceName.Width = 82
        '
        'GridColumnCurr
        '
        Me.GridColumnCurr.Caption = "Default Cost Currency"
        Me.GridColumnCurr.FieldName = "currency"
        Me.GridColumnCurr.Name = "GridColumnCurr"
        Me.GridColumnCurr.OptionsColumn.AllowEdit = False
        Me.GridColumnCurr.Visible = True
        Me.GridColumnCurr.VisibleIndex = 15
        Me.GridColumnCurr.Width = 65
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.Caption = "Default Cost"
        Me.GridColumnPrice.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "sample_price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.OptionsColumn.AllowEdit = False
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 16
        Me.GridColumnPrice.Width = 65
        '
        'GridColumnLastPriceName
        '
        Me.GridColumnLastPriceName.Caption = "Last Price Name"
        Me.GridColumnLastPriceName.FieldName = "sample_price_name_last"
        Me.GridColumnLastPriceName.Name = "GridColumnLastPriceName"
        Me.GridColumnLastPriceName.OptionsColumn.AllowEdit = False
        Me.GridColumnLastPriceName.Visible = True
        Me.GridColumnLastPriceName.VisibleIndex = 20
        '
        'GridColumnLastPrice
        '
        Me.GridColumnLastPrice.Caption = "Last Price"
        Me.GridColumnLastPrice.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnLastPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnLastPrice.FieldName = "sample_price_last"
        Me.GridColumnLastPrice.Name = "GridColumnLastPrice"
        Me.GridColumnLastPrice.OptionsColumn.AllowEdit = False
        Me.GridColumnLastPrice.Visible = True
        Me.GridColumnLastPrice.VisibleIndex = 22
        Me.GridColumnLastPrice.Width = 65
        '
        'GridColumnCurrLast
        '
        Me.GridColumnCurrLast.Caption = "Last Price Currency"
        Me.GridColumnCurrLast.FieldName = "currency_last"
        Me.GridColumnCurrLast.Name = "GridColumnCurrLast"
        Me.GridColumnCurrLast.OptionsColumn.AllowEdit = False
        Me.GridColumnCurrLast.Visible = True
        Me.GridColumnCurrLast.VisibleIndex = 21
        Me.GridColumnCurrLast.Width = 69
        '
        'GridColumnFOBPriceName
        '
        Me.GridColumnFOBPriceName.Caption = "FOB Price Name"
        Me.GridColumnFOBPriceName.FieldName = "sample_price_name_fob"
        Me.GridColumnFOBPriceName.Name = "GridColumnFOBPriceName"
        Me.GridColumnFOBPriceName.Visible = True
        Me.GridColumnFOBPriceName.VisibleIndex = 17
        '
        'GridColumnCurrFOBPrice
        '
        Me.GridColumnCurrFOBPrice.Caption = "FOB Price Currency"
        Me.GridColumnCurrFOBPrice.FieldName = "currency_fob"
        Me.GridColumnCurrFOBPrice.Name = "GridColumnCurrFOBPrice"
        Me.GridColumnCurrFOBPrice.Visible = True
        Me.GridColumnCurrFOBPrice.VisibleIndex = 18
        '
        'GridColumnFOBPrice
        '
        Me.GridColumnFOBPrice.Caption = "FOB Price"
        Me.GridColumnFOBPrice.DisplayFormat.FormatString = "N2"
        Me.GridColumnFOBPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnFOBPrice.FieldName = "sample_price_fob"
        Me.GridColumnFOBPrice.Name = "GridColumnFOBPrice"
        Me.GridColumnFOBPrice.Visible = True
        Me.GridColumnFOBPrice.VisibleIndex = 19
        '
        'GridColumnLastVendorCode
        '
        Me.GridColumnLastVendorCode.Caption = "Vendor Code"
        Me.GridColumnLastVendorCode.FieldName = "last_vendor_code"
        Me.GridColumnLastVendorCode.Name = "GridColumnLastVendorCode"
        Me.GridColumnLastVendorCode.OptionsColumn.AllowEdit = False
        Me.GridColumnLastVendorCode.Visible = True
        Me.GridColumnLastVendorCode.VisibleIndex = 12
        '
        'GridColumnVendor
        '
        Me.GridColumnVendor.Caption = "Vendor"
        Me.GridColumnVendor.FieldName = "last_vendor"
        Me.GridColumnVendor.Name = "GridColumnVendor"
        Me.GridColumnVendor.OptionsColumn.AllowEdit = False
        Me.GridColumnVendor.Visible = True
        Me.GridColumnVendor.VisibleIndex = 13
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GCSample
        Me.GridView2.Name = "GridView2"
        '
        'PBCLineList
        '
        Me.PBCLineList.Dock = System.Windows.Forms.DockStyle.Left
        Me.PBCLineList.Location = New System.Drawing.Point(2, 2)
        Me.PBCLineList.Name = "PBCLineList"
        Me.PBCLineList.Properties.ShowTitle = True
        Me.PBCLineList.Size = New System.Drawing.Size(148, 33)
        Me.PBCLineList.TabIndex = 96
        Me.PBCLineList.Visible = False
        '
        'BStatusNR
        '
        Me.BStatusNR.Dock = System.Windows.Forms.DockStyle.Right
        Me.BStatusNR.ImageIndex = 14
        Me.BStatusNR.ImageList = Me.LargeImageCollection
        Me.BStatusNR.Location = New System.Drawing.Point(805, 2)
        Me.BStatusNR.Name = "BStatusNR"
        Me.BStatusNR.Size = New System.Drawing.Size(133, 33)
        Me.BStatusNR.TabIndex = 109
        Me.BStatusNR.Text = "Set Normal/Reject"
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "20_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "8_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "23_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(3, "arrow_refresh.png")
        Me.LargeImageCollection.Images.SetKeyName(4, "check_mark.png")
        Me.LargeImageCollection.Images.SetKeyName(5, "gnome_application_exit (1).png")
        Me.LargeImageCollection.Images.SetKeyName(6, "printer_3.png")
        Me.LargeImageCollection.Images.SetKeyName(7, "save.png")
        Me.LargeImageCollection.Images.SetKeyName(8, "31_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(9, "18_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(10, "1415351112474759854-32.png")
        Me.LargeImageCollection.Images.SetKeyName(11, "icon_merchandise_clothes32.png")
        Me.LargeImageCollection.Images.SetKeyName(12, "t_shirtgreen.png")
        Me.LargeImageCollection.Images.SetKeyName(13, "lock red.png")
        Me.LargeImageCollection.Images.SetKeyName(14, "ordering32.png")
        Me.LargeImageCollection.Images.SetKeyName(15, "kghostview.png")
        Me.LargeImageCollection.Images.SetKeyName(16, "MetroUI-Folder-OS-Configure-icon.png")
        Me.LargeImageCollection.Images.SetKeyName(17, "Setting(32).png")
        Me.LargeImageCollection.Images.SetKeyName(18, "estimate_icon32.png")
        Me.LargeImageCollection.Images.SetKeyName(19, "copy_icon.png")
        '
        'PanelControlNavLineListBottom
        '
        Me.PanelControlNavLineListBottom.Controls.Add(Me.PCSelAll)
        Me.PanelControlNavLineListBottom.Controls.Add(Me.BStatusNR)
        Me.PanelControlNavLineListBottom.Controls.Add(Me.PBCLineList)
        Me.PanelControlNavLineListBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControlNavLineListBottom.Location = New System.Drawing.Point(0, 373)
        Me.PanelControlNavLineListBottom.Name = "PanelControlNavLineListBottom"
        Me.PanelControlNavLineListBottom.Size = New System.Drawing.Size(940, 37)
        Me.PanelControlNavLineListBottom.TabIndex = 4
        '
        'PCSelAll
        '
        Me.PCSelAll.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCSelAll.Controls.Add(Me.CheckEditSelAll)
        Me.PCSelAll.Dock = System.Windows.Forms.DockStyle.Left
        Me.PCSelAll.Location = New System.Drawing.Point(150, 2)
        Me.PCSelAll.Name = "PCSelAll"
        Me.PCSelAll.Size = New System.Drawing.Size(109, 33)
        Me.PCSelAll.TabIndex = 110
        '
        'CheckEditSelAll
        '
        Me.CheckEditSelAll.Location = New System.Drawing.Point(5, 7)
        Me.CheckEditSelAll.Name = "CheckEditSelAll"
        Me.CheckEditSelAll.Properties.Caption = "Select All Item"
        Me.CheckEditSelAll.Size = New System.Drawing.Size(92, 19)
        Me.CheckEditSelAll.TabIndex = 102
        '
        'FormMasterSample
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(940, 410)
        Me.Controls.Add(Me.GCSample)
        Me.Controls.Add(Me.PanelControlNavLineListBottom)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterSample"
        Me.ShowInTaskbar = False
        Me.Text = "Sample"
        CType(Me.GCSample, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSample, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RCISample, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBCLineList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlNavLineListBottom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNavLineListBottom.ResumeLayout(False)
        CType(Me.PCSelAll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCSelAll.ResumeLayout(False)
        CType(Me.CheckEditSelAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCSample As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSample As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColSampleID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSampleDisplayName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSampleName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSampleUSCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSampleUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSampleSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSeasonOrigin As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSampleCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSamplePriceName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCurr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLastPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLastPriceName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCurrLast As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLastVendorCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnVendor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RCISample As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents PBCLineList As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents BStatusNR As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControlNavLineListBottom As DevExpress.XtraEditors.PanelControl
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents GridColumnNormalReject As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PCSelAll As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CheckEditSelAll As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GridColumnFOBPriceName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCurrFOBPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFOBPrice As DevExpress.XtraGrid.Columns.GridColumn
End Class
