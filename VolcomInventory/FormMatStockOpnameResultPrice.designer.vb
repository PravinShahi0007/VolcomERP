<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMatStockOpnameResultPrice
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
        Me.components = New System.ComponentModel.Container
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMatStockOpnameResultPrice))
        Me.GVMatListPrice = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnIdMatPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdCur = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnMPName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCur = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnMPP = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnMPD = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdMatDetDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCMatList = New DevExpress.XtraGrid.GridControl
        Me.GVMatList = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdMatDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCategory = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnUOM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnLot = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSOSumQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnMatQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnMatDiff = New DevExpress.XtraGrid.Columns.GridColumn
        Me.BandedGridView1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl
        Me.BHide = New DevExpress.XtraEditors.SimpleButton
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BExpand = New DevExpress.XtraEditors.SimpleButton
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl
        Me.XTCListPrice = New DevExpress.XtraTab.XtraTabControl
        Me.XTPListSO = New DevExpress.XtraTab.XtraTabPage
        Me.GridColumnNox = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.GVMatListPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCMatList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMatList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BandedGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.XTCListPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCListPrice.SuspendLayout()
        Me.XTPListSO.SuspendLayout()
        Me.SuspendLayout()
        '
        'GVMatListPrice
        '
        Me.GVMatListPrice.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdMatPrice, Me.GridColumnIdCur, Me.GridColumnMPName, Me.GridColumnCur, Me.GridColumnMPP, Me.GridColumnMPD, Me.GridColumnIdMatDetDet})
        Me.GVMatListPrice.GridControl = Me.GCMatList
        Me.GVMatListPrice.Name = "GVMatListPrice"
        Me.GVMatListPrice.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdMatPrice
        '
        Me.GridColumnIdMatPrice.Caption = "Id Price"
        Me.GridColumnIdMatPrice.FieldName = "id_mat_det_price"
        Me.GridColumnIdMatPrice.Name = "GridColumnIdMatPrice"
        '
        'GridColumnIdCur
        '
        Me.GridColumnIdCur.Caption = "Id Curr"
        Me.GridColumnIdCur.FieldName = "id_currency"
        Me.GridColumnIdCur.Name = "GridColumnIdCur"
        '
        'GridColumnMPName
        '
        Me.GridColumnMPName.Caption = "Price Description"
        Me.GridColumnMPName.FieldName = "mat_det_price_name"
        Me.GridColumnMPName.Name = "GridColumnMPName"
        Me.GridColumnMPName.Visible = True
        Me.GridColumnMPName.VisibleIndex = 0
        '
        'GridColumnCur
        '
        Me.GridColumnCur.Caption = "Currency"
        Me.GridColumnCur.FieldName = "currency"
        Me.GridColumnCur.Name = "GridColumnCur"
        Me.GridColumnCur.Visible = True
        Me.GridColumnCur.VisibleIndex = 2
        '
        'GridColumnMPP
        '
        Me.GridColumnMPP.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnMPP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnMPP.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnMPP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnMPP.Caption = "Price"
        Me.GridColumnMPP.DisplayFormat.FormatString = "N2"
        Me.GridColumnMPP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnMPP.FieldName = "mat_det_price"
        Me.GridColumnMPP.Name = "GridColumnMPP"
        Me.GridColumnMPP.Visible = True
        Me.GridColumnMPP.VisibleIndex = 3
        '
        'GridColumnMPD
        '
        Me.GridColumnMPD.Caption = "Date"
        Me.GridColumnMPD.FieldName = "mat_det_price_date"
        Me.GridColumnMPD.Name = "GridColumnMPD"
        Me.GridColumnMPD.Visible = True
        Me.GridColumnMPD.VisibleIndex = 1
        '
        'GridColumnIdMatDetDet
        '
        Me.GridColumnIdMatDetDet.Caption = "Id mat Det"
        Me.GridColumnIdMatDetDet.FieldName = "id_mat_det"
        Me.GridColumnIdMatDetDet.Name = "GridColumnIdMatDetDet"
        '
        'GCMatList
        '
        Me.GCMatList.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.LevelTemplate = Me.GVMatListPrice
        GridLevelNode1.RelationName = "Price List"
        Me.GCMatList.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GCMatList.Location = New System.Drawing.Point(0, 0)
        Me.GCMatList.MainView = Me.GVMatList
        Me.GCMatList.Name = "GCMatList"
        Me.GCMatList.Size = New System.Drawing.Size(750, 288)
        Me.GCMatList.TabIndex = 6
        Me.GCMatList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMatList, Me.BandedGridView1, Me.GVMatListPrice})
        '
        'GVMatList
        '
        Me.GVMatList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNo, Me.GridColumnIdMatDet, Me.GridColumnCategory, Me.GridColumnName, Me.GridColumnCode, Me.GridColumnColor, Me.GridColumnSize, Me.GridColumnUOM, Me.GridColumnLot, Me.GridColumnSOSumQty, Me.GridColumnMatQty, Me.GridColumnMatDiff})
        Me.GVMatList.GridControl = Me.GCMatList
        Me.GVMatList.Name = "GVMatList"
        Me.GVMatList.OptionsBehavior.Editable = False
        Me.GVMatList.OptionsFind.AlwaysVisible = True
        Me.GVMatList.OptionsPrint.PrintDetails = True
        Me.GVMatList.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNo
        '
        Me.GridColumnNo.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnNo.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 40
        '
        'GridColumnIdMatDet
        '
        Me.GridColumnIdMatDet.Caption = "IdMatDet"
        Me.GridColumnIdMatDet.FieldName = "id_mat_det"
        Me.GridColumnIdMatDet.Name = "GridColumnIdMatDet"
        '
        'GridColumnCategory
        '
        Me.GridColumnCategory.Caption = "Category"
        Me.GridColumnCategory.FieldName = "mat_cat"
        Me.GridColumnCategory.Name = "GridColumnCategory"
        Me.GridColumnCategory.Visible = True
        Me.GridColumnCategory.VisibleIndex = 1
        Me.GridColumnCategory.Width = 79
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Description"
        Me.GridColumnName.FieldName = "mat_det_name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 2
        Me.GridColumnName.Width = 134
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "mat_det_code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 3
        Me.GridColumnCode.Width = 79
        '
        'GridColumnColor
        '
        Me.GridColumnColor.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnColor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnColor.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnColor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnColor.Caption = "Color"
        Me.GridColumnColor.FieldName = "color"
        Me.GridColumnColor.Name = "GridColumnColor"
        Me.GridColumnColor.Visible = True
        Me.GridColumnColor.VisibleIndex = 4
        Me.GridColumnColor.Width = 66
        '
        'GridColumnSize
        '
        Me.GridColumnSize.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSize.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 5
        Me.GridColumnSize.Width = 66
        '
        'GridColumnUOM
        '
        Me.GridColumnUOM.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnUOM.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnUOM.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnUOM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnUOM.Caption = "UOM"
        Me.GridColumnUOM.FieldName = "uom"
        Me.GridColumnUOM.Name = "GridColumnUOM"
        Me.GridColumnUOM.Visible = True
        Me.GridColumnUOM.VisibleIndex = 6
        Me.GridColumnUOM.Width = 66
        '
        'GridColumnLot
        '
        Me.GridColumnLot.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnLot.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnLot.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnLot.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnLot.Caption = "Lot"
        Me.GridColumnLot.FieldName = "lot"
        Me.GridColumnLot.Name = "GridColumnLot"
        Me.GridColumnLot.Visible = True
        Me.GridColumnLot.VisibleIndex = 7
        Me.GridColumnLot.Width = 73
        '
        'GridColumnSOSumQty
        '
        Me.GridColumnSOSumQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnSOSumQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnSOSumQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSOSumQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnSOSumQty.Caption = "SO Qty"
        Me.GridColumnSOSumQty.DisplayFormat.FormatString = "N2"
        Me.GridColumnSOSumQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnSOSumQty.FieldName = "mat_so_sum_qty"
        Me.GridColumnSOSumQty.Name = "GridColumnSOSumQty"
        Me.GridColumnSOSumQty.Visible = True
        Me.GridColumnSOSumQty.VisibleIndex = 9
        '
        'GridColumnMatQty
        '
        Me.GridColumnMatQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnMatQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnMatQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnMatQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnMatQty.Caption = "Qty"
        Me.GridColumnMatQty.DisplayFormat.FormatString = "N2"
        Me.GridColumnMatQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnMatQty.FieldName = "mat_qty"
        Me.GridColumnMatQty.Name = "GridColumnMatQty"
        Me.GridColumnMatQty.Visible = True
        Me.GridColumnMatQty.VisibleIndex = 8
        '
        'GridColumnMatDiff
        '
        Me.GridColumnMatDiff.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnMatDiff.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnMatDiff.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnMatDiff.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnMatDiff.Caption = "Difference"
        Me.GridColumnMatDiff.DisplayFormat.FormatString = "N2"
        Me.GridColumnMatDiff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnMatDiff.FieldName = "mat_so_sum_dif"
        Me.GridColumnMatDiff.Name = "GridColumnMatDiff"
        Me.GridColumnMatDiff.Visible = True
        Me.GridColumnMatDiff.VisibleIndex = 10
        '
        'BandedGridView1
        '
        Me.BandedGridView1.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.BandedGridView1.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn1, Me.BandedGridColumn2})
        Me.BandedGridView1.GridControl = Me.GCMatList
        Me.BandedGridView1.Name = "BandedGridView1"
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "GridBand1"
        Me.GridBand1.Name = "GridBand1"
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.Caption = "BandedGridColumn1"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.Visible = True
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.Caption = "BandedGridColumn2"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.Visible = True
        '
        'GroupControl3
        '
        Me.GroupControl3.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl3.Controls.Add(Me.BHide)
        Me.GroupControl3.Controls.Add(Me.BExpand)
        Me.GroupControl3.Controls.Add(Me.BPrint)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl3.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(780, 34)
        Me.GroupControl3.TabIndex = 6
        '
        'BHide
        '
        Me.BHide.Dock = System.Windows.Forms.DockStyle.Left
        Me.BHide.ImageIndex = 9
        Me.BHide.ImageList = Me.LargeImageCollection
        Me.BHide.Location = New System.Drawing.Point(144, 2)
        Me.BHide.Name = "BHide"
        Me.BHide.Size = New System.Drawing.Size(113, 30)
        Me.BHide.TabIndex = 6
        Me.BHide.Text = "Hide All Detail"
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
        Me.LargeImageCollection.Images.SetKeyName(8, "zoom-in32.png")
        Me.LargeImageCollection.Images.SetKeyName(9, "zoom-out32.png")
        '
        'BExpand
        '
        Me.BExpand.Dock = System.Windows.Forms.DockStyle.Left
        Me.BExpand.ImageIndex = 8
        Me.BExpand.ImageList = Me.LargeImageCollection
        Me.BExpand.Location = New System.Drawing.Point(22, 2)
        Me.BExpand.Name = "BExpand"
        Me.BExpand.Size = New System.Drawing.Size(122, 30)
        Me.BExpand.TabIndex = 5
        Me.BExpand.Text = "Expand All Detail"
        '
        'BPrint
        '
        Me.BPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BPrint.ImageIndex = 6
        Me.BPrint.ImageList = Me.LargeImageCollection
        Me.BPrint.Location = New System.Drawing.Point(691, 2)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(87, 30)
        Me.BPrint.TabIndex = 4
        Me.BPrint.Text = "Print"
        '
        'GroupControl2
        '
        Me.GroupControl2.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl2.Controls.Add(Me.XTCListPrice)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 34)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(780, 318)
        Me.GroupControl2.TabIndex = 7
        Me.GroupControl2.Text = "Material List"
        '
        'XTCListPrice
        '
        Me.XTCListPrice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCListPrice.Location = New System.Drawing.Point(22, 2)
        Me.XTCListPrice.Name = "XTCListPrice"
        Me.XTCListPrice.SelectedTabPage = Me.XTPListSO
        Me.XTCListPrice.Size = New System.Drawing.Size(756, 314)
        Me.XTCListPrice.TabIndex = 0
        Me.XTCListPrice.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPListSO})
        '
        'XTPListSO
        '
        Me.XTPListSO.Controls.Add(Me.GCMatList)
        Me.XTPListSO.Name = "XTPListSO"
        Me.XTPListSO.Size = New System.Drawing.Size(750, 288)
        Me.XTPListSO.Text = "Summary"
        '
        'GridColumnNox
        '
        Me.GridColumnNox.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnNox.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnNox.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnNox.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnNox.Caption = "No"
        Me.GridColumnNox.FieldName = "no"
        Me.GridColumnNox.Name = "GridColumnNox"
        Me.GridColumnNox.Visible = True
        Me.GridColumnNox.VisibleIndex = 0
        Me.GridColumnNox.Width = 42
        '
        'FormMatStockOpnameResultPrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(780, 352)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMatStockOpnameResultPrice"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Opname Price Detail"
        CType(Me.GVMatListPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCMatList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMatList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BandedGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.XTCListPrice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCListPrice.ResumeLayout(False)
        Me.XTPListSO.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XTCListPrice As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPListSO As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCMatList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMatList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLot As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GVMatListPrice As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdMatPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdMatDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BandedGridView1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnIdCur As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMPName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCur As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMPP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMPD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdMatDetDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNox As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BExpand As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BHide As DevExpress.XtraEditors.SimpleButton
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSOSumQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMatQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMatDiff As DevExpress.XtraGrid.Columns.GridColumn
End Class
