<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpReceiveWOMat
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
        Me.GCMatReceive = New DevExpress.XtraGrid.GridControl
        Me.GVMatReceive = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdSampleReceive = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdComp = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColPONumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPoNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDONumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColTo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSamplePurcRecDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColRecDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDel = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDelx = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSeasonx = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCListPurchase = New DevExpress.XtraGrid.GridControl
        Me.GVListPurchase = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdMatPurcRecDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnUOM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColQtyReceived = New DevExpress.XtraGrid.Columns.GridColumn
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneral.SuspendLayout()
        CType(Me.GCMatReceive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMatReceive, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainerControl1.SplitterPosition = 216
        Me.SplitContainerControl1.TabIndex = 33
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'GroupGeneral
        '
        Me.GroupGeneral.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupGeneral.Controls.Add(Me.GCMatReceive)
        Me.GroupGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupGeneral.Location = New System.Drawing.Point(0, 0)
        Me.GroupGeneral.Name = "GroupGeneral"
        Me.GroupGeneral.Size = New System.Drawing.Size(814, 216)
        Me.GroupGeneral.TabIndex = 16
        Me.GroupGeneral.Text = "Receive"
        '
        'GCMatReceive
        '
        Me.GCMatReceive.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMatReceive.Location = New System.Drawing.Point(2, 22)
        Me.GCMatReceive.MainView = Me.GVMatReceive
        Me.GCMatReceive.Name = "GCMatReceive"
        Me.GCMatReceive.Size = New System.Drawing.Size(810, 192)
        Me.GCMatReceive.TabIndex = 1
        Me.GCMatReceive.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMatReceive})
        '
        'GVMatReceive
        '
        Me.GVMatReceive.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdSampleReceive, Me.GridColumnIdComp, Me.ColPONumber, Me.GridColumnPoNumber, Me.GridColumnDONumber, Me.ColTo, Me.ColSamplePurcRecDate, Me.ColRecDate, Me.ColSeason, Me.GridColumnDel, Me.GridColumnDelx, Me.GridColumnSeasonx})
        Me.GVMatReceive.GridControl = Me.GCMatReceive
        Me.GVMatReceive.GroupCount = 2
        Me.GVMatReceive.Name = "GVMatReceive"
        Me.GVMatReceive.OptionsBehavior.Editable = False
        Me.GVMatReceive.OptionsFind.AlwaysVisible = True
        Me.GVMatReceive.OptionsView.ShowGroupPanel = False
        Me.GVMatReceive.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnSeasonx, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnDelx, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'ColIdSampleReceive
        '
        Me.ColIdSampleReceive.Caption = "ID Mat Received"
        Me.ColIdSampleReceive.FieldName = "id_mat_wo_rec"
        Me.ColIdSampleReceive.Name = "ColIdSampleReceive"
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
        Me.ColPONumber.FieldName = "mat_wo_rec_number"
        Me.ColPONumber.Name = "ColPONumber"
        Me.ColPONumber.Visible = True
        Me.ColPONumber.VisibleIndex = 0
        Me.ColPONumber.Width = 100
        '
        'GridColumnPoNumber
        '
        Me.GridColumnPoNumber.Caption = "Order Number"
        Me.GridColumnPoNumber.FieldName = "mat_wo_number"
        Me.GridColumnPoNumber.Name = "GridColumnPoNumber"
        Me.GridColumnPoNumber.Visible = True
        Me.GridColumnPoNumber.VisibleIndex = 1
        '
        'GridColumnDONumber
        '
        Me.GridColumnDONumber.Caption = "Del. Order Number"
        Me.GridColumnDONumber.FieldName = "delivery_order_number"
        Me.GridColumnDONumber.Name = "GridColumnDONumber"
        Me.GridColumnDONumber.Visible = True
        Me.GridColumnDONumber.VisibleIndex = 2
        '
        'ColTo
        '
        Me.ColTo.Caption = "To"
        Me.ColTo.FieldName = "comp_name"
        Me.ColTo.Name = "ColTo"
        Me.ColTo.Visible = True
        Me.ColTo.VisibleIndex = 3
        Me.ColTo.Width = 124
        '
        'ColSamplePurcRecDate
        '
        Me.ColSamplePurcRecDate.Caption = "Create Date"
        Me.ColSamplePurcRecDate.FieldName = "mat_wo_rec_date"
        Me.ColSamplePurcRecDate.Name = "ColSamplePurcRecDate"
        Me.ColSamplePurcRecDate.Visible = True
        Me.ColSamplePurcRecDate.VisibleIndex = 4
        Me.ColSamplePurcRecDate.Width = 114
        '
        'ColRecDate
        '
        Me.ColRecDate.Caption = "Del. Order Date"
        Me.ColRecDate.FieldName = "delivery_order_date"
        Me.ColRecDate.Name = "ColRecDate"
        Me.ColRecDate.Visible = True
        Me.ColRecDate.VisibleIndex = 5
        Me.ColRecDate.Width = 114
        '
        'ColSeason
        '
        Me.ColSeason.Caption = "Season"
        Me.ColSeason.FieldName = "season"
        Me.ColSeason.Name = "ColSeason"
        '
        'GridColumnDel
        '
        Me.GridColumnDel.Caption = "Delivery"
        Me.GridColumnDel.FieldName = "delivery"
        Me.GridColumnDel.Name = "GridColumnDel"
        '
        'GridColumnDelx
        '
        Me.GridColumnDelx.Caption = "Delivery"
        Me.GridColumnDelx.FieldName = "id_delivery"
        Me.GridColumnDelx.Name = "GridColumnDelx"
        '
        'GridColumnSeasonx
        '
        Me.GridColumnSeasonx.Caption = "Season"
        Me.GridColumnSeasonx.FieldName = "id_season"
        Me.GridColumnSeasonx.Name = "GridColumnSeasonx"
        '
        'GCListPurchase
        '
        Me.GCListPurchase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListPurchase.Location = New System.Drawing.Point(0, 0)
        Me.GCListPurchase.MainView = Me.GVListPurchase
        Me.GCListPurchase.Name = "GCListPurchase"
        Me.GCListPurchase.Size = New System.Drawing.Size(814, 194)
        Me.GCListPurchase.TabIndex = 3
        Me.GCListPurchase.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListPurchase})
        '
        'GVListPurchase
        '
        Me.GVListPurchase.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdMatPurcRecDet, Me.ColNo, Me.ColCode, Me.ColName, Me.ColSize, Me.GridColumnUOM, Me.ColQtyReceived})
        Me.GVListPurchase.GridControl = Me.GCListPurchase
        Me.GVListPurchase.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.GVListPurchase.Name = "GVListPurchase"
        Me.GVListPurchase.OptionsBehavior.Editable = False
        Me.GVListPurchase.OptionsView.ShowGroupPanel = False
        '
        'ColIdMatPurcRecDet
        '
        Me.ColIdMatPurcRecDet.Caption = "ID Receive Mat Detail"
        Me.ColIdMatPurcRecDet.FieldName = "id_mat_wo_rec_det"
        Me.ColIdMatPurcRecDet.Name = "ColIdMatPurcRecDet"
        '
        'ColNo
        '
        Me.ColNo.AppearanceCell.Options.UseTextOptions = True
        Me.ColNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColNo.Caption = "NO."
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
        Me.ColSize.VisibleIndex = 3
        Me.ColSize.Width = 140
        '
        'GridColumnUOM
        '
        Me.GridColumnUOM.Caption = "UOM"
        Me.GridColumnUOM.FieldName = "uom"
        Me.GridColumnUOM.Name = "GridColumnUOM"
        Me.GridColumnUOM.Visible = True
        Me.GridColumnUOM.VisibleIndex = 4
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
        Me.ColQtyReceived.FieldName = "mat_wo_rec_det_qty"
        Me.ColQtyReceived.Name = "ColQtyReceived"
        Me.ColQtyReceived.Visible = True
        Me.ColQtyReceived.VisibleIndex = 5
        Me.ColQtyReceived.Width = 68
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.BtnCancel)
        Me.PanelControl2.Controls.Add(Me.BtnSave)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 411)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(814, 46)
        Me.PanelControl2.TabIndex = 34
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(656, 12)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(70, 23)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(732, 12)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(70, 23)
        Me.BtnSave.TabIndex = 3
        Me.BtnSave.Text = "Choose"
        '
        'FormPopUpReceiveWOMat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 457)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPopUpReceiveWOMat"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Receive WO Material"
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneral.ResumeLayout(False)
        CType(Me.GCMatReceive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMatReceive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupGeneral As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCMatReceive As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMatReceive As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdSampleReceive As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdComp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPONumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPoNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDONumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSamplePurcRecDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRecDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDelx As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeasonx As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCListPurchase As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListPurchase As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdMatPurcRecDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColQtyReceived As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
End Class
