<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSamplePLExport
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
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TEPLEnd = New DevExpress.XtraEditors.TextEdit()
        Me.TEPLStart = New DevExpress.XtraEditors.TextEdit()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.GCSample = New DevExpress.XtraGrid.GridControl()
        Me.GVSample = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColSampleID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSamplePL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSampleCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSampleDisplayName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCost = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TEPLEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPLStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCSample, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSample, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.TEPLEnd)
        Me.PanelControl1.Controls.Add(Me.TEPLStart)
        Me.PanelControl1.Controls.Add(Me.BPrint)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(813, 54)
        Me.PanelControl1.TabIndex = 2
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(229, 20)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(4, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "-"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 20)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(66, 13)
        Me.LabelControl1.TabIndex = 3
        Me.LabelControl1.Text = "Packing List #"
        '
        'TEPLEnd
        '
        Me.TEPLEnd.Location = New System.Drawing.Point(239, 17)
        Me.TEPLEnd.Name = "TEPLEnd"
        Me.TEPLEnd.Size = New System.Drawing.Size(144, 20)
        Me.TEPLEnd.TabIndex = 2
        '
        'TEPLStart
        '
        Me.TEPLStart.Location = New System.Drawing.Point(84, 17)
        Me.TEPLStart.Name = "TEPLStart"
        Me.TEPLStart.Size = New System.Drawing.Size(139, 20)
        Me.TEPLStart.TabIndex = 1
        '
        'BPrint
        '
        Me.BPrint.Location = New System.Drawing.Point(389, 14)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(87, 26)
        Me.BPrint.TabIndex = 2
        Me.BPrint.Text = "View"
        '
        'GCSample
        '
        Me.GCSample.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSample.Location = New System.Drawing.Point(0, 54)
        Me.GCSample.MainView = Me.GVSample
        Me.GCSample.Name = "GCSample"
        Me.GCSample.Size = New System.Drawing.Size(813, 272)
        Me.GCSample.TabIndex = 4
        Me.GCSample.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSample, Me.GridView2})
        '
        'GVSample
        '
        Me.GVSample.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColSampleID, Me.GridColumn1, Me.GridColumnSamplePL, Me.ColSampleCode, Me.ColSampleDisplayName, Me.GridColumnCost, Me.GridColumnAmount, Me.GridColumnPrice, Me.GridColumnQty})
        Me.GVSample.GridControl = Me.GCSample
        Me.GVSample.GroupCount = 1
        Me.GVSample.Name = "GVSample"
        Me.GVSample.OptionsBehavior.Editable = False
        Me.GVSample.OptionsView.ShowFooter = True
        Me.GVSample.OptionsView.ShowGroupPanel = False
        Me.GVSample.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnSamplePL, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'ColSampleID
        '
        Me.ColSampleID.Caption = "Id Sample"
        Me.ColSampleID.FieldName = "id_sample"
        Me.ColSampleID.Name = "ColSampleID"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID Sample PL"
        Me.GridColumn1.FieldName = "id_sample_pl"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumnSamplePL
        '
        Me.GridColumnSamplePL.Caption = "PL Number"
        Me.GridColumnSamplePL.FieldName = "sample_pl_number"
        Me.GridColumnSamplePL.FieldNameSortGroup = "id_sample_pl"
        Me.GridColumnSamplePL.Name = "GridColumnSamplePL"
        Me.GridColumnSamplePL.Visible = True
        Me.GridColumnSamplePL.VisibleIndex = 0
        '
        'ColSampleCode
        '
        Me.ColSampleCode.Caption = "Code"
        Me.ColSampleCode.FieldName = "code"
        Me.ColSampleCode.Name = "ColSampleCode"
        Me.ColSampleCode.Visible = True
        Me.ColSampleCode.VisibleIndex = 0
        Me.ColSampleCode.Width = 69
        '
        'ColSampleDisplayName
        '
        Me.ColSampleDisplayName.Caption = "Description"
        Me.ColSampleDisplayName.FieldName = "description"
        Me.ColSampleDisplayName.Name = "ColSampleDisplayName"
        Me.ColSampleDisplayName.Visible = True
        Me.ColSampleDisplayName.VisibleIndex = 1
        Me.ColSampleDisplayName.Width = 69
        '
        'GridColumnCost
        '
        Me.GridColumnCost.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnCost.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnCost.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnCost.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnCost.Caption = "Total Cost"
        Me.GridColumnCost.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCost.FieldName = "total_cost"
        Me.GridColumnCost.Name = "GridColumnCost"
        Me.GridColumnCost.Width = 65
        '
        'GridColumnAmount
        '
        Me.GridColumnAmount.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnAmount.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnAmount.Caption = "Total Amount"
        Me.GridColumnAmount.DisplayFormat.FormatString = "N2"
        Me.GridColumnAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAmount.FieldName = "total_amount"
        Me.GridColumnAmount.Name = "GridColumnAmount"
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPrice.Caption = "Price"
        Me.GridColumnPrice.DisplayFormat.FormatString = "N2"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 2
        '
        'GridColumnQty
        '
        Me.GridColumnQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.DisplayFormat.FormatString = "{0:n0}"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:n0}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 3
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GCSample
        Me.GridView2.Name = "GridView2"
        '
        'FormSamplePLExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(813, 326)
        Me.Controls.Add(Me.GCSample)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSamplePLExport"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Sample PL Detail List"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.TEPLEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPLStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCSample, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSample, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEPLEnd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEPLStart As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCSample As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSample As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColSampleID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSampleCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSampleDisplayName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCost As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSamplePL As DevExpress.XtraGrid.Columns.GridColumn
End Class
