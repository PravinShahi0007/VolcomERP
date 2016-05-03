<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpReceive
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
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BSave = New DevExpress.XtraEditors.SimpleButton
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl
        Me.GroupGeneral = New DevExpress.XtraEditors.GroupControl
        Me.GCSampleReceive = New DevExpress.XtraGrid.GridControl
        Me.GVSampleReceive = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdSampleReceive = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdComp = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColPONumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDONumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColTo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSamplePurcRecDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColRecDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCListPurchase = New DevExpress.XtraGrid.GridControl
        Me.GVListPurchase = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdSamplePurcRecDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnUOM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColQtyReceived = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnUSCode = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneral.SuspendLayout()
        CType(Me.GCSampleReceive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSampleReceive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.BtnCancel)
        Me.PanelControl2.Controls.Add(Me.BtnSave)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl2.Location = New System.Drawing.Point(0, 416)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(814, 41)
        Me.PanelControl2.TabIndex = 29
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(663, 10)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(70, 23)
        Me.BtnCancel.TabIndex = 2
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(739, 10)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(70, 23)
        Me.BtnSave.TabIndex = 1
        Me.BtnSave.Text = "Choose"
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
        Me.SplitContainerControl1.Size = New System.Drawing.Size(814, 416)
        Me.SplitContainerControl1.SplitterPosition = 216
        Me.SplitContainerControl1.TabIndex = 28
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'GroupGeneral
        '
        Me.GroupGeneral.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupGeneral.Controls.Add(Me.GCSampleReceive)
        Me.GroupGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupGeneral.Location = New System.Drawing.Point(0, 0)
        Me.GroupGeneral.Name = "GroupGeneral"
        Me.GroupGeneral.Size = New System.Drawing.Size(814, 216)
        Me.GroupGeneral.TabIndex = 16
        Me.GroupGeneral.Text = "Receive"
        '
        'GCSampleReceive
        '
        Me.GCSampleReceive.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSampleReceive.Location = New System.Drawing.Point(2, 22)
        Me.GCSampleReceive.MainView = Me.GVSampleReceive
        Me.GCSampleReceive.Name = "GCSampleReceive"
        Me.GCSampleReceive.Size = New System.Drawing.Size(810, 192)
        Me.GCSampleReceive.TabIndex = 1
        Me.GCSampleReceive.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSampleReceive})
        '
        'GVSampleReceive
        '
        Me.GVSampleReceive.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdSampleReceive, Me.ColSeason, Me.GridColumnIdComp, Me.ColPONumber, Me.GridColumnDONumber, Me.ColTo, Me.ColSamplePurcRecDate, Me.ColRecDate})
        Me.GVSampleReceive.GridControl = Me.GCSampleReceive
        Me.GVSampleReceive.GroupCount = 1
        Me.GVSampleReceive.Name = "GVSampleReceive"
        Me.GVSampleReceive.OptionsBehavior.Editable = False
        Me.GVSampleReceive.OptionsFind.AlwaysVisible = True
        Me.GVSampleReceive.OptionsView.ShowGroupPanel = False
        Me.GVSampleReceive.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColSeason, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'ColIdSampleReceive
        '
        Me.ColIdSampleReceive.Caption = "ID Sample Received"
        Me.ColIdSampleReceive.FieldName = "id_sample_purc_rec"
        Me.ColIdSampleReceive.Name = "ColIdSampleReceive"
        '
        'ColSeason
        '
        Me.ColSeason.Caption = "Season Orign"
        Me.ColSeason.FieldName = "season_orign"
        Me.ColSeason.Name = "ColSeason"
        '
        'GridColumnIdComp
        '
        Me.GridColumnIdComp.Caption = "IdCompContactTo"
        Me.GridColumnIdComp.FieldName = "id_comp_contact_to"
        Me.GridColumnIdComp.Name = "GridColumnIdComp"
        '
        'ColPONumber
        '
        Me.ColPONumber.Caption = "Receiving Number"
        Me.ColPONumber.FieldName = "sample_purc_rec_number"
        Me.ColPONumber.Name = "ColPONumber"
        Me.ColPONumber.Visible = True
        Me.ColPONumber.VisibleIndex = 0
        Me.ColPONumber.Width = 100
        '
        'GridColumnDONumber
        '
        Me.GridColumnDONumber.Caption = "Del. Order Number"
        Me.GridColumnDONumber.FieldName = "delivery_order_number"
        Me.GridColumnDONumber.Name = "GridColumnDONumber"
        Me.GridColumnDONumber.Visible = True
        Me.GridColumnDONumber.VisibleIndex = 1
        '
        'ColTo
        '
        Me.ColTo.Caption = "To"
        Me.ColTo.FieldName = "comp_name"
        Me.ColTo.Name = "ColTo"
        Me.ColTo.Visible = True
        Me.ColTo.VisibleIndex = 2
        Me.ColTo.Width = 124
        '
        'ColSamplePurcRecDate
        '
        Me.ColSamplePurcRecDate.Caption = "Create Date"
        Me.ColSamplePurcRecDate.FieldName = "sample_purc_rec_date"
        Me.ColSamplePurcRecDate.Name = "ColSamplePurcRecDate"
        Me.ColSamplePurcRecDate.Visible = True
        Me.ColSamplePurcRecDate.VisibleIndex = 3
        Me.ColSamplePurcRecDate.Width = 114
        '
        'ColRecDate
        '
        Me.ColRecDate.Caption = "Del. Order Date"
        Me.ColRecDate.FieldName = "delivery_order_date"
        Me.ColRecDate.Name = "ColRecDate"
        Me.ColRecDate.Visible = True
        Me.ColRecDate.VisibleIndex = 4
        Me.ColRecDate.Width = 114
        '
        'GCListPurchase
        '
        Me.GCListPurchase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListPurchase.Location = New System.Drawing.Point(0, 0)
        Me.GCListPurchase.MainView = Me.GVListPurchase
        Me.GCListPurchase.Name = "GCListPurchase"
        Me.GCListPurchase.Size = New System.Drawing.Size(814, 195)
        Me.GCListPurchase.TabIndex = 3
        Me.GCListPurchase.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListPurchase})
        '
        'GVListPurchase
        '
        Me.GVListPurchase.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdSamplePurcRecDet, Me.ColNo, Me.ColCode, Me.ColName, Me.ColSize, Me.GridColumnUOM, Me.ColQtyReceived, Me.GridColumnUSCode})
        Me.GVListPurchase.GridControl = Me.GCListPurchase
        Me.GVListPurchase.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.GVListPurchase.Name = "GVListPurchase"
        Me.GVListPurchase.OptionsBehavior.Editable = False
        Me.GVListPurchase.OptionsView.ShowGroupPanel = False
        '
        'ColIdSamplePurcRecDet
        '
        Me.ColIdSamplePurcRecDet.Caption = "ID Receive Sample Detail"
        Me.ColIdSamplePurcRecDet.FieldName = "id_sample_purc_rec_det"
        Me.ColIdSamplePurcRecDet.Name = "ColIdSamplePurcRecDet"
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
        Me.ColNo.Width = 33
        '
        'ColCode
        '
        Me.ColCode.Caption = "Code"
        Me.ColCode.FieldName = "code"
        Me.ColCode.Name = "ColCode"
        Me.ColCode.Visible = True
        Me.ColCode.VisibleIndex = 2
        Me.ColCode.Width = 151
        '
        'ColName
        '
        Me.ColName.Caption = "Name"
        Me.ColName.FieldName = "name"
        Me.ColName.Name = "ColName"
        Me.ColName.Visible = True
        Me.ColName.VisibleIndex = 3
        Me.ColName.Width = 254
        '
        'ColSize
        '
        Me.ColSize.AppearanceCell.Options.UseTextOptions = True
        Me.ColSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColSize.AppearanceHeader.Options.UseTextOptions = True
        Me.ColSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColSize.Caption = "Size"
        Me.ColSize.FieldName = "size"
        Me.ColSize.Name = "ColSize"
        Me.ColSize.Visible = True
        Me.ColSize.VisibleIndex = 4
        Me.ColSize.Width = 151
        '
        'GridColumnUOM
        '
        Me.GridColumnUOM.Caption = "UOM"
        Me.GridColumnUOM.FieldName = "uom"
        Me.GridColumnUOM.Name = "GridColumnUOM"
        Me.GridColumnUOM.Visible = True
        Me.GridColumnUOM.VisibleIndex = 5
        Me.GridColumnUOM.Width = 80
        '
        'ColQtyReceived
        '
        Me.ColQtyReceived.AppearanceCell.Options.UseTextOptions = True
        Me.ColQtyReceived.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQtyReceived.AppearanceHeader.Options.UseTextOptions = True
        Me.ColQtyReceived.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQtyReceived.Caption = "Qty Received"
        Me.ColQtyReceived.DisplayFormat.FormatString = "N2"
        Me.ColQtyReceived.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColQtyReceived.FieldName = "sample_purc_rec_det_qty"
        Me.ColQtyReceived.Name = "ColQtyReceived"
        Me.ColQtyReceived.Visible = True
        Me.ColQtyReceived.VisibleIndex = 6
        Me.ColQtyReceived.Width = 80
        '
        'GridColumnUSCode
        '
        Me.GridColumnUSCode.Caption = "US Code"
        Me.GridColumnUSCode.FieldName = "sample_us_code"
        Me.GridColumnUSCode.Name = "GridColumnUSCode"
        Me.GridColumnUSCode.Visible = True
        Me.GridColumnUSCode.VisibleIndex = 1
        Me.GridColumnUSCode.Width = 113
        '
        'FormPopUpReceive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 457)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPopUpReceive"
        Me.ShowInTaskbar = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Receive"
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneral.ResumeLayout(False)
        CType(Me.GCSampleReceive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSampleReceive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupGeneral As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCSampleReceive As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSampleReceive As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdSampleReceive As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdComp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPONumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDONumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSamplePurcRecDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRecDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCListPurchase As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListPurchase As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdSamplePurcRecDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColQtyReceived As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUSCode As DevExpress.XtraGrid.Columns.GridColumn
End Class
