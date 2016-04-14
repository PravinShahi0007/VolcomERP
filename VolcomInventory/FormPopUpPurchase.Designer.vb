<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpPurchase
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
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl
        Me.GroupGeneral = New DevExpress.XtraEditors.GroupControl
        Me.GCSamplePurchase = New DevExpress.XtraGrid.GridControl
        Me.GVSamplePurchase = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdSamplePurchase = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColPONumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColShipFrom = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColShipTo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSamplePurcDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColRecDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColDueDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColPayment = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdCompContactTo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCListPurchase = New DevExpress.XtraGrid.GridControl
        Me.GVListPurchase = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColDiscount = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSubtotal = New DevExpress.XtraGrid.Columns.GridColumn
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BSave = New DevExpress.XtraEditors.SimpleButton
        Me.GridColumnIdSeasonOrign = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneral.SuspendLayout()
        CType(Me.GCSamplePurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSamplePurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GroupGeneral)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GCListPurchase)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(814, 415)
        Me.SplitContainerControl1.SplitterPosition = 212
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'GroupGeneral
        '
        Me.GroupGeneral.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupGeneral.Controls.Add(Me.GCSamplePurchase)
        Me.GroupGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupGeneral.Location = New System.Drawing.Point(0, 0)
        Me.GroupGeneral.Name = "GroupGeneral"
        Me.GroupGeneral.Size = New System.Drawing.Size(814, 212)
        Me.GroupGeneral.TabIndex = 15
        Me.GroupGeneral.Text = "Purchase"
        '
        'GCSamplePurchase
        '
        Me.GCSamplePurchase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSamplePurchase.Location = New System.Drawing.Point(2, 22)
        Me.GCSamplePurchase.MainView = Me.GVSamplePurchase
        Me.GCSamplePurchase.Name = "GCSamplePurchase"
        Me.GCSamplePurchase.Size = New System.Drawing.Size(810, 188)
        Me.GCSamplePurchase.TabIndex = 1
        Me.GCSamplePurchase.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSamplePurchase})
        '
        'GVSamplePurchase
        '
        Me.GVSamplePurchase.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdSamplePurchase, Me.ColSeason, Me.ColPONumber, Me.ColShipFrom, Me.ColShipTo, Me.ColSamplePurcDate, Me.ColRecDate, Me.ColDueDate, Me.ColPayment, Me.GridColumnIdCompContactTo, Me.GridColumnIdSeasonOrign})
        Me.GVSamplePurchase.GridControl = Me.GCSamplePurchase
        Me.GVSamplePurchase.GroupCount = 1
        Me.GVSamplePurchase.Name = "GVSamplePurchase"
        Me.GVSamplePurchase.OptionsBehavior.Editable = False
        Me.GVSamplePurchase.OptionsView.ShowGroupPanel = False
        Me.GVSamplePurchase.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColSeason, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'ColIdSamplePurchase
        '
        Me.ColIdSamplePurchase.Caption = "ID Sample Purchase"
        Me.ColIdSamplePurchase.FieldName = "id_sample_purc"
        Me.ColIdSamplePurchase.Name = "ColIdSamplePurchase"
        '
        'ColSeason
        '
        Me.ColSeason.Caption = "Season Orign"
        Me.ColSeason.FieldName = "season_orign"
        Me.ColSeason.FieldNameSortGroup = "id_season_orign"
        Me.ColSeason.Name = "ColSeason"
        '
        'ColPONumber
        '
        Me.ColPONumber.Caption = "Number"
        Me.ColPONumber.FieldName = "sample_purc_number"
        Me.ColPONumber.Name = "ColPONumber"
        Me.ColPONumber.Visible = True
        Me.ColPONumber.VisibleIndex = 0
        Me.ColPONumber.Width = 100
        '
        'ColShipFrom
        '
        Me.ColShipFrom.Caption = "To"
        Me.ColShipFrom.FieldName = "comp_name_to"
        Me.ColShipFrom.Name = "ColShipFrom"
        Me.ColShipFrom.Visible = True
        Me.ColShipFrom.VisibleIndex = 1
        Me.ColShipFrom.Width = 124
        '
        'ColShipTo
        '
        Me.ColShipTo.Caption = "Ship To"
        Me.ColShipTo.FieldName = "comp_name_ship_to"
        Me.ColShipTo.Name = "ColShipTo"
        Me.ColShipTo.Visible = True
        Me.ColShipTo.VisibleIndex = 2
        Me.ColShipTo.Width = 124
        '
        'ColSamplePurcDate
        '
        Me.ColSamplePurcDate.Caption = "Create Date"
        Me.ColSamplePurcDate.FieldName = "sample_purc_date"
        Me.ColSamplePurcDate.Name = "ColSamplePurcDate"
        Me.ColSamplePurcDate.Visible = True
        Me.ColSamplePurcDate.VisibleIndex = 4
        Me.ColSamplePurcDate.Width = 114
        '
        'ColRecDate
        '
        Me.ColRecDate.Caption = "Est. Receive Date"
        Me.ColRecDate.FieldName = "sample_purc_lead_time"
        Me.ColRecDate.Name = "ColRecDate"
        Me.ColRecDate.Visible = True
        Me.ColRecDate.VisibleIndex = 5
        Me.ColRecDate.Width = 114
        '
        'ColDueDate
        '
        Me.ColDueDate.Caption = "Due Date"
        Me.ColDueDate.FieldName = "sample_purc_top"
        Me.ColDueDate.Name = "ColDueDate"
        Me.ColDueDate.Visible = True
        Me.ColDueDate.VisibleIndex = 6
        Me.ColDueDate.Width = 131
        '
        'ColPayment
        '
        Me.ColPayment.Caption = "Payment"
        Me.ColPayment.FieldName = "payment"
        Me.ColPayment.Name = "ColPayment"
        Me.ColPayment.Visible = True
        Me.ColPayment.VisibleIndex = 3
        Me.ColPayment.Width = 87
        '
        'GridColumnIdCompContactTo
        '
        Me.GridColumnIdCompContactTo.Caption = "GridColumn1"
        Me.GridColumnIdCompContactTo.FieldName = "id_comp_contact_to"
        Me.GridColumnIdCompContactTo.Name = "GridColumnIdCompContactTo"
        '
        'GCListPurchase
        '
        Me.GCListPurchase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListPurchase.Location = New System.Drawing.Point(0, 0)
        Me.GCListPurchase.MainView = Me.GVListPurchase
        Me.GCListPurchase.Name = "GCListPurchase"
        Me.GCListPurchase.Size = New System.Drawing.Size(814, 198)
        Me.GCListPurchase.TabIndex = 2
        Me.GCListPurchase.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListPurchase})
        '
        'GVListPurchase
        '
        Me.GVListPurchase.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdPrice, Me.ColNo, Me.ColCode, Me.ColName, Me.ColPrice, Me.ColQty, Me.ColDiscount, Me.ColSubtotal})
        Me.GVListPurchase.GridControl = Me.GCListPurchase
        Me.GVListPurchase.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.GVListPurchase.Name = "GVListPurchase"
        Me.GVListPurchase.OptionsBehavior.Editable = False
        Me.GVListPurchase.OptionsView.ShowGroupPanel = False
        '
        'ColIdPrice
        '
        Me.ColIdPrice.Caption = "ID Price"
        Me.ColIdPrice.FieldName = "id_sample_purc_det"
        Me.ColIdPrice.Name = "ColIdPrice"
        '
        'ColNo
        '
        Me.ColNo.AppearanceCell.Options.UseTextOptions = True
        Me.ColNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColNo.Caption = "No."
        Me.ColNo.FieldName = "no"
        Me.ColNo.Name = "ColNo"
        Me.ColNo.Visible = True
        Me.ColNo.VisibleIndex = 0
        Me.ColNo.Width = 30
        '
        'ColCode
        '
        Me.ColCode.Caption = "Code"
        Me.ColCode.FieldName = "code"
        Me.ColCode.Name = "ColCode"
        Me.ColCode.Visible = True
        Me.ColCode.VisibleIndex = 1
        Me.ColCode.Width = 140
        '
        'ColName
        '
        Me.ColName.Caption = "Name"
        Me.ColName.FieldName = "name"
        Me.ColName.Name = "ColName"
        Me.ColName.Visible = True
        Me.ColName.VisibleIndex = 2
        Me.ColName.Width = 235
        '
        'ColPrice
        '
        Me.ColPrice.AppearanceCell.Options.UseTextOptions = True
        Me.ColPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.ColPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.Caption = "Price"
        Me.ColPrice.DisplayFormat.FormatString = "N2"
        Me.ColPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColPrice.FieldName = "price"
        Me.ColPrice.Name = "ColPrice"
        Me.ColPrice.Visible = True
        Me.ColPrice.VisibleIndex = 3
        Me.ColPrice.Width = 140
        '
        'ColQty
        '
        Me.ColQty.AppearanceCell.Options.UseTextOptions = True
        Me.ColQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.AppearanceHeader.Options.UseTextOptions = True
        Me.ColQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.Caption = "Qty"
        Me.ColQty.DisplayFormat.FormatString = "N2"
        Me.ColQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColQty.FieldName = "qty"
        Me.ColQty.Name = "ColQty"
        Me.ColQty.Visible = True
        Me.ColQty.VisibleIndex = 5
        Me.ColQty.Width = 68
        '
        'ColDiscount
        '
        Me.ColDiscount.AppearanceCell.Options.UseTextOptions = True
        Me.ColDiscount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColDiscount.AppearanceHeader.Options.UseTextOptions = True
        Me.ColDiscount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColDiscount.Caption = "Discount"
        Me.ColDiscount.DisplayFormat.FormatString = "N2"
        Me.ColDiscount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColDiscount.FieldName = "discount"
        Me.ColDiscount.Name = "ColDiscount"
        Me.ColDiscount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.ColDiscount.Visible = True
        Me.ColDiscount.VisibleIndex = 4
        Me.ColDiscount.Width = 96
        '
        'ColSubtotal
        '
        Me.ColSubtotal.AppearanceCell.Options.UseTextOptions = True
        Me.ColSubtotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColSubtotal.AppearanceHeader.Options.UseTextOptions = True
        Me.ColSubtotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColSubtotal.Caption = "Sub Total"
        Me.ColSubtotal.DisplayFormat.FormatString = "N2"
        Me.ColSubtotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColSubtotal.FieldName = "total"
        Me.ColSubtotal.Name = "ColSubtotal"
        Me.ColSubtotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:N2}")})
        Me.ColSubtotal.Visible = True
        Me.ColSubtotal.VisibleIndex = 6
        Me.ColSubtotal.Width = 165
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.BCancel)
        Me.PanelControl2.Controls.Add(Me.BSave)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl2.Location = New System.Drawing.Point(0, 415)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(814, 42)
        Me.PanelControl2.TabIndex = 26
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Location = New System.Drawing.Point(663, 10)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(70, 23)
        Me.BCancel.TabIndex = 2
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Location = New System.Drawing.Point(739, 10)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(70, 23)
        Me.BSave.TabIndex = 1
        Me.BSave.Text = "Choose"
        '
        'GridColumnIdSeasonOrign
        '
        Me.GridColumnIdSeasonOrign.Caption = "Id Season Orign"
        Me.GridColumnIdSeasonOrign.FieldName = "id_season_orign"
        Me.GridColumnIdSeasonOrign.Name = "GridColumnIdSeasonOrign"
        '
        'FormPopUpPurchase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 457)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPopUpPurchase"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Purchase"
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneral.ResumeLayout(False)
        CType(Me.GCSamplePurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSamplePurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupGeneral As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCSamplePurchase As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSamplePurchase As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdSamplePurchase As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPONumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColShipFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColShipTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSamplePurcDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRecDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPayment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCListPurchase As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListPurchase As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDiscount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSubtotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdCompContactTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSeasonOrign As DevExpress.XtraGrid.Columns.GridColumn
End Class
