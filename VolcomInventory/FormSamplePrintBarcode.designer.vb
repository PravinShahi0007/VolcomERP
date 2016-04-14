<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSamplePrintBarcode
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.CheckEditSelAll = New DevExpress.XtraEditors.CheckEdit()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.GCSample = New DevExpress.XtraGrid.GridControl()
        Me.GVSample = New DevExpress.XtraGrid.Views.Grid.GridView()
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
        Me.GridColumnClass = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCEPrint = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RCEPrint = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RSLEPrice = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.RepositoryItemSearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RPEQty = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.GridColumnIdSeasonOrign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSeasonOrignDisplay = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BPrintZebra = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.CheckEditSelAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCSample, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSample, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RCEPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RSLEPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RPEQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BPrintZebra)
        Me.PanelControl1.Controls.Add(Me.CheckEditSelAll)
        Me.PanelControl1.Controls.Add(Me.BPrint)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(743, 44)
        Me.PanelControl1.TabIndex = 1
        '
        'CheckEditSelAll
        '
        Me.CheckEditSelAll.Location = New System.Drawing.Point(12, 12)
        Me.CheckEditSelAll.Name = "CheckEditSelAll"
        Me.CheckEditSelAll.Properties.Caption = "Select All"
        Me.CheckEditSelAll.Size = New System.Drawing.Size(75, 19)
        Me.CheckEditSelAll.TabIndex = 1
        '
        'BPrint
        '
        Me.BPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BPrint.Location = New System.Drawing.Point(619, 2)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(122, 40)
        Me.BPrint.TabIndex = 0
        Me.BPrint.Text = "Print Code Sato"
        '
        'GCSample
        '
        Me.GCSample.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSample.Location = New System.Drawing.Point(0, 44)
        Me.GCSample.MainView = Me.GVSample
        Me.GCSample.Name = "GCSample"
        Me.GCSample.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RCEPrint, Me.RSLEPrice, Me.RPEQty})
        Me.GCSample.Size = New System.Drawing.Size(743, 318)
        Me.GCSample.TabIndex = 4
        Me.GCSample.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSample, Me.GridView2})
        '
        'GVSample
        '
        Me.GVSample.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColSampleID, Me.ColSampleDisplayName, Me.ColSampleName, Me.ColSampleUSCode, Me.ColSampleUOM, Me.ColSampleSeason, Me.ColSeasonOrigin, Me.ColSampleCode, Me.GridColumnIdSeason, Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumnClass, Me.GridColumnCEPrint, Me.GridColumn7, Me.GridColumnQty, Me.GridColumnIdSeasonOrign, Me.GridColumnSeasonOrignDisplay})
        Me.GVSample.GridControl = Me.GCSample
        Me.GVSample.GroupCount = 1
        Me.GVSample.Name = "GVSample"
        Me.GVSample.OptionsView.ShowGroupPanel = False
        Me.GVSample.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColSeasonOrigin, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'ColSampleID
        '
        Me.ColSampleID.Caption = "Id Sample"
        Me.ColSampleID.FieldName = "id_sample"
        Me.ColSampleID.Name = "ColSampleID"
        '
        'ColSampleDisplayName
        '
        Me.ColSampleDisplayName.Caption = "Display Description"
        Me.ColSampleDisplayName.FieldName = "sample_display_name"
        Me.ColSampleDisplayName.Name = "ColSampleDisplayName"
        Me.ColSampleDisplayName.Visible = True
        Me.ColSampleDisplayName.VisibleIndex = 3
        '
        'ColSampleName
        '
        Me.ColSampleName.Caption = "Description"
        Me.ColSampleName.FieldName = "sample_name"
        Me.ColSampleName.Name = "ColSampleName"
        Me.ColSampleName.Visible = True
        Me.ColSampleName.VisibleIndex = 4
        '
        'ColSampleUSCode
        '
        Me.ColSampleUSCode.Caption = "US Code"
        Me.ColSampleUSCode.FieldName = "sample_us_code"
        Me.ColSampleUSCode.Name = "ColSampleUSCode"
        Me.ColSampleUSCode.Visible = True
        Me.ColSampleUSCode.VisibleIndex = 1
        '
        'ColSampleUOM
        '
        Me.ColSampleUOM.Caption = "UOM"
        Me.ColSampleUOM.FieldName = "id_uom"
        Me.ColSampleUOM.Name = "ColSampleUOM"
        '
        'ColSampleSeason
        '
        Me.ColSampleSeason.Caption = "Season"
        Me.ColSampleSeason.FieldName = "season"
        Me.ColSampleSeason.FieldNameSortGroup = "id_season"
        Me.ColSampleSeason.Name = "ColSampleSeason"
        Me.ColSampleSeason.Visible = True
        Me.ColSampleSeason.VisibleIndex = 0
        '
        'ColSeasonOrigin
        '
        Me.ColSeasonOrigin.Caption = "Season Orign"
        Me.ColSeasonOrigin.FieldName = "season_orign"
        Me.ColSeasonOrigin.FieldNameSortGroup = "id_season_orign"
        Me.ColSeasonOrigin.Name = "ColSeasonOrigin"
        '
        'ColSampleCode
        '
        Me.ColSampleCode.Caption = "Code"
        Me.ColSampleCode.FieldName = "sample_code"
        Me.ColSampleCode.Name = "ColSampleCode"
        Me.ColSampleCode.Visible = True
        Me.ColSampleCode.VisibleIndex = 2
        '
        'GridColumnIdSeason
        '
        Me.GridColumnIdSeason.Caption = "Id Season"
        Me.GridColumnIdSeason.FieldName = "id_season"
        Me.GridColumnIdSeason.Name = "GridColumnIdSeason"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Source"
        Me.GridColumn1.FieldName = "Sample Source"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 5
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Category"
        Me.GridColumn2.FieldName = "Sample Category"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 6
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Color"
        Me.GridColumn3.FieldName = "display_Color"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 7
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Size"
        Me.GridColumn4.FieldName = "size"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 8
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Division"
        Me.GridColumn5.FieldName = "Sample Division"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 9
        '
        'GridColumnClass
        '
        Me.GridColumnClass.Caption = "Class"
        Me.GridColumnClass.FieldName = "Sample Counting Class"
        Me.GridColumnClass.Name = "GridColumnClass"
        Me.GridColumnClass.Visible = True
        Me.GridColumnClass.VisibleIndex = 10
        '
        'GridColumnCEPrint
        '
        Me.GridColumnCEPrint.Caption = "Print"
        Me.GridColumnCEPrint.ColumnEdit = Me.RCEPrint
        Me.GridColumnCEPrint.FieldName = "is_print"
        Me.GridColumnCEPrint.Name = "GridColumnCEPrint"
        Me.GridColumnCEPrint.Visible = True
        Me.GridColumnCEPrint.VisibleIndex = 11
        '
        'RCEPrint
        '
        Me.RCEPrint.AutoHeight = False
        Me.RCEPrint.Name = "RCEPrint"
        Me.RCEPrint.ValueChecked = "yes"
        Me.RCEPrint.ValueUnchecked = "no"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Price"
        Me.GridColumn7.ColumnEdit = Me.RSLEPrice
        Me.GridColumn7.DisplayFormat.FormatString = "N2"
        Me.GridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn7.FieldName = "id_sample_ret_price"
        Me.GridColumn7.Name = "GridColumn7"
        '
        'RSLEPrice
        '
        Me.RSLEPrice.AutoHeight = False
        Me.RSLEPrice.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RSLEPrice.Name = "RSLEPrice"
        Me.RSLEPrice.View = Me.RepositoryItemSearchLookUpEdit1View
        '
        'RepositoryItemSearchLookUpEdit1View
        '
        Me.RepositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.RepositoryItemSearchLookUpEdit1View.Name = "RepositoryItemSearchLookUpEdit1View"
        Me.RepositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RepositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnQty
        '
        Me.GridColumnQty.Caption = "Qty Print"
        Me.GridColumnQty.ColumnEdit = Me.RPEQty
        Me.GridColumnQty.FieldName = "qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 12
        '
        'RPEQty
        '
        Me.RPEQty.AutoHeight = False
        Me.RPEQty.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RPEQty.IsFloatValue = False
        Me.RPEQty.Mask.EditMask = "N00"
        Me.RPEQty.MaxValue = New Decimal(New Integer() {99, 0, 0, 0})
        Me.RPEQty.Name = "RPEQty"
        '
        'GridColumnIdSeasonOrign
        '
        Me.GridColumnIdSeasonOrign.Caption = "Id Season Orign"
        Me.GridColumnIdSeasonOrign.FieldName = "id_season_orign"
        Me.GridColumnIdSeasonOrign.Name = "GridColumnIdSeasonOrign"
        '
        'GridColumnSeasonOrignDisplay
        '
        Me.GridColumnSeasonOrignDisplay.Caption = "Display Orign"
        Me.GridColumnSeasonOrignDisplay.FieldName = "season_orign_display"
        Me.GridColumnSeasonOrignDisplay.Name = "GridColumnSeasonOrignDisplay"
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GCSample
        Me.GridView2.Name = "GridView2"
        '
        'BPrintZebra
        '
        Me.BPrintZebra.Dock = System.Windows.Forms.DockStyle.Right
        Me.BPrintZebra.Location = New System.Drawing.Point(497, 2)
        Me.BPrintZebra.Name = "BPrintZebra"
        Me.BPrintZebra.Size = New System.Drawing.Size(122, 40)
        Me.BPrintZebra.TabIndex = 2
        Me.BPrintZebra.Text = "Print Code Zebra"
        '
        'FormSamplePrintBarcode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(743, 362)
        Me.Controls.Add(Me.GCSample)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSamplePrintBarcode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Print Barcode"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.CheckEditSelAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCSample, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSample, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RCEPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RSLEPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RPEQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
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
    Friend WithEvents GridColumnIdSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnCEPrint As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RCEPrint As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RSLEPrice As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RPEQty As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumnIdSeasonOrign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeasonOrignDisplay As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CheckEditSelAll As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GridColumnClass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BPrintZebra As DevExpress.XtraEditors.SimpleButton
End Class
