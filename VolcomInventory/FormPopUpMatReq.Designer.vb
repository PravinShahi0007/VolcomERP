<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpMatReq
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
        Me.GroupControlSampleReq = New DevExpress.XtraEditors.GroupControl
        Me.GCReq = New DevExpress.XtraGrid.GridControl
        Me.GVReq = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdSampleReq = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColRetOutNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColShipFrom = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColShipTo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColRecDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnNotes = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GroupControlDetail = New DevExpress.XtraEditors.GroupControl
        Me.GCMat = New DevExpress.XtraGrid.GridControl
        Me.GVMat = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdPurcDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdMat = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.SEQty = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
        Me.ColNote = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQtyOnHand = New DevExpress.XtraGrid.Columns.GridColumn
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BtnChoose = New DevExpress.XtraEditors.SimpleButton
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GroupControlSampleReq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlSampleReq.SuspendLayout()
        CType(Me.GCReq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVReq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlDetail.SuspendLayout()
        CType(Me.GCMat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SEQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GroupControlSampleReq)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GroupControlDetail)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(864, 446)
        Me.SplitContainerControl1.SplitterPosition = 190
        Me.SplitContainerControl1.TabIndex = 5
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'GroupControlSampleReq
        '
        Me.GroupControlSampleReq.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlSampleReq.Controls.Add(Me.GCReq)
        Me.GroupControlSampleReq.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlSampleReq.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlSampleReq.Name = "GroupControlSampleReq"
        Me.GroupControlSampleReq.Size = New System.Drawing.Size(864, 190)
        Me.GroupControlSampleReq.TabIndex = 0
        Me.GroupControlSampleReq.Text = "Material Requisition "
        '
        'GCReq
        '
        Me.GCReq.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCReq.Location = New System.Drawing.Point(22, 2)
        Me.GCReq.MainView = Me.GVReq
        Me.GCReq.Name = "GCReq"
        Me.GCReq.Size = New System.Drawing.Size(840, 186)
        Me.GCReq.TabIndex = 5
        Me.GCReq.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVReq})
        '
        'GVReq
        '
        Me.GVReq.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdSampleReq, Me.ColRetOutNumber, Me.ColShipFrom, Me.ColShipTo, Me.ColRecDate, Me.GridColumnNotes, Me.GridColumnStatus, Me.GridColumn2})
        Me.GVReq.GridControl = Me.GCReq
        Me.GVReq.Name = "GVReq"
        Me.GVReq.OptionsBehavior.Editable = False
        Me.GVReq.OptionsView.ShowGroupPanel = False
        '
        'ColIdSampleReq
        '
        Me.ColIdSampleReq.Caption = "ID MRS"
        Me.ColIdSampleReq.FieldName = "id_prod_order_mrs"
        Me.ColIdSampleReq.Name = "ColIdSampleReq"
        '
        'ColRetOutNumber
        '
        Me.ColRetOutNumber.Caption = "Number"
        Me.ColRetOutNumber.FieldName = "prod_order_mrs_number"
        Me.ColRetOutNumber.Name = "ColRetOutNumber"
        Me.ColRetOutNumber.Visible = True
        Me.ColRetOutNumber.VisibleIndex = 0
        Me.ColRetOutNumber.Width = 168
        '
        'ColShipFrom
        '
        Me.ColShipFrom.Caption = "Ship To"
        Me.ColShipFrom.FieldName = "comp_from"
        Me.ColShipFrom.Name = "ColShipFrom"
        Me.ColShipFrom.Visible = True
        Me.ColShipFrom.VisibleIndex = 2
        Me.ColShipFrom.Width = 303
        '
        'ColShipTo
        '
        Me.ColShipTo.Caption = "To"
        Me.ColShipTo.FieldName = "comp_to"
        Me.ColShipTo.Name = "ColShipTo"
        Me.ColShipTo.Width = 142
        '
        'ColRecDate
        '
        Me.ColRecDate.Caption = "Created Date"
        Me.ColRecDate.FieldName = "prod_order_mrs_date"
        Me.ColRecDate.Name = "ColRecDate"
        Me.ColRecDate.Visible = True
        Me.ColRecDate.VisibleIndex = 3
        Me.ColRecDate.Width = 262
        '
        'GridColumnNotes
        '
        Me.GridColumnNotes.Caption = "Notes"
        Me.GridColumnNotes.FieldName = "prod_order_mrs_note"
        Me.GridColumnNotes.Name = "GridColumnNotes"
        Me.GridColumnNotes.Visible = True
        Me.GridColumnNotes.VisibleIndex = 4
        Me.GridColumnNotes.Width = 258
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Width = 101
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "PO Number"
        Me.GridColumn2.FieldName = "prod_order_number"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 189
        '
        'GroupControlDetail
        '
        Me.GroupControlDetail.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlDetail.Controls.Add(Me.GCMat)
        Me.GroupControlDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlDetail.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlDetail.Name = "GroupControlDetail"
        Me.GroupControlDetail.Size = New System.Drawing.Size(864, 251)
        Me.GroupControlDetail.TabIndex = 1
        Me.GroupControlDetail.Text = "Detail"
        '
        'GCMat
        '
        Me.GCMat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMat.Location = New System.Drawing.Point(22, 2)
        Me.GCMat.MainView = Me.GVMat
        Me.GCMat.Margin = New System.Windows.Forms.Padding(0)
        Me.GCMat.Name = "GCMat"
        Me.GCMat.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.SEQty})
        Me.GCMat.Size = New System.Drawing.Size(840, 247)
        Me.GCMat.TabIndex = 3
        Me.GCMat.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMat})
        '
        'GVMat
        '
        Me.GVMat.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdPurcDet, Me.ColIdMat, Me.ColNo, Me.ColCode, Me.ColName, Me.ColQty, Me.ColNote, Me.GridColumn1, Me.ColSize, Me.GridColumnQtyOnHand})
        Me.GVMat.GridControl = Me.GCMat
        Me.GVMat.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        Me.GVMat.Name = "GVMat"
        Me.GVMat.OptionsView.ShowFooter = True
        Me.GVMat.OptionsView.ShowGroupPanel = False
        '
        'ColIdPurcDet
        '
        Me.ColIdPurcDet.Caption = "ID Purc Det"
        Me.ColIdPurcDet.FieldName = "id_prod_order_mrs_det"
        Me.ColIdPurcDet.Name = "ColIdPurcDet"
        '
        'ColIdMat
        '
        Me.ColIdMat.Caption = "Id Mat"
        Me.ColIdMat.FieldName = "id_mat_det"
        Me.ColIdMat.Name = "ColIdMat"
        '
        'ColNo
        '
        Me.ColNo.AppearanceCell.Options.UseTextOptions = True
        Me.ColNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColNo.AppearanceHeader.Options.UseTextOptions = True
        Me.ColNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColNo.Caption = "No."
        Me.ColNo.FieldName = "no"
        Me.ColNo.Name = "ColNo"
        Me.ColNo.OptionsColumn.AllowEdit = False
        Me.ColNo.Visible = True
        Me.ColNo.VisibleIndex = 0
        Me.ColNo.Width = 30
        '
        'ColCode
        '
        Me.ColCode.Caption = "Code"
        Me.ColCode.FieldName = "code"
        Me.ColCode.Name = "ColCode"
        Me.ColCode.OptionsColumn.AllowEdit = False
        Me.ColCode.Visible = True
        Me.ColCode.VisibleIndex = 1
        Me.ColCode.Width = 140
        '
        'ColName
        '
        Me.ColName.Caption = "Name"
        Me.ColName.FieldName = "name"
        Me.ColName.Name = "ColName"
        Me.ColName.OptionsColumn.AllowEdit = False
        Me.ColName.Visible = True
        Me.ColName.VisibleIndex = 2
        Me.ColName.Width = 235
        '
        'ColQty
        '
        Me.ColQty.AppearanceCell.Options.UseTextOptions = True
        Me.ColQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.AppearanceHeader.Options.UseTextOptions = True
        Me.ColQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.Caption = "Qty"
        Me.ColQty.ColumnEdit = Me.SEQty
        Me.ColQty.DisplayFormat.FormatString = "{0:N2}"
        Me.ColQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColQty.FieldName = "qty"
        Me.ColQty.Name = "ColQty"
        Me.ColQty.Visible = True
        Me.ColQty.VisibleIndex = 5
        Me.ColQty.Width = 68
        '
        'SEQty
        '
        Me.SEQty.AutoHeight = False
        Me.SEQty.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.SEQty.DisplayFormat.FormatString = "N2"
        Me.SEQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.SEQty.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.SEQty.Mask.EditMask = "N2"
        Me.SEQty.MaxValue = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.SEQty.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.SEQty.Name = "SEQty"
        '
        'ColNote
        '
        Me.ColNote.Caption = "Note"
        Me.ColNote.FieldName = "note"
        Me.ColNote.Name = "ColNote"
        Me.ColNote.Visible = True
        Me.ColNote.VisibleIndex = 7
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.Caption = "Color"
        Me.GridColumn1.FieldName = "color"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 3
        '
        'ColSize
        '
        Me.ColSize.AppearanceCell.Options.UseTextOptions = True
        Me.ColSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColSize.AppearanceHeader.Options.UseTextOptions = True
        Me.ColSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColSize.Caption = "Size"
        Me.ColSize.FieldName = "size"
        Me.ColSize.Name = "ColSize"
        Me.ColSize.OptionsColumn.AllowEdit = False
        Me.ColSize.Visible = True
        Me.ColSize.VisibleIndex = 4
        '
        'GridColumnQtyOnHand
        '
        Me.GridColumnQtyOnHand.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQtyOnHand.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyOnHand.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQtyOnHand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyOnHand.Caption = "On Hand Qty"
        Me.GridColumnQtyOnHand.DisplayFormat.FormatString = "N2"
        Me.GridColumnQtyOnHand.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyOnHand.FieldName = "qty_all_mat"
        Me.GridColumnQtyOnHand.Name = "GridColumnQtyOnHand"
        Me.GridColumnQtyOnHand.OptionsColumn.AllowEdit = False
        Me.GridColumnQtyOnHand.Visible = True
        Me.GridColumnQtyOnHand.VisibleIndex = 6
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Controls.Add(Me.BtnChoose)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 446)
        Me.PanelControl1.LookAndFeel.SkinName = "Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(864, 36)
        Me.PanelControl1.TabIndex = 4
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.Location = New System.Drawing.Point(712, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 32)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnChoose
        '
        Me.BtnChoose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnChoose.Location = New System.Drawing.Point(787, 2)
        Me.BtnChoose.Name = "BtnChoose"
        Me.BtnChoose.Size = New System.Drawing.Size(75, 32)
        Me.BtnChoose.TabIndex = 0
        Me.BtnChoose.Text = "Choose"
        '
        'FormPopUpMatReq
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(864, 482)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPopUpMatReq"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Material Requisition"
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GroupControlSampleReq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlSampleReq.ResumeLayout(False)
        CType(Me.GCReq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVReq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlDetail.ResumeLayout(False)
        CType(Me.GCMat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SEQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControlSampleReq As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCReq As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVReq As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdSampleReq As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRetOutNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColShipFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColShipTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRecDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNotes As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupControlDetail As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCMat As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMat As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdPurcDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdMat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SEQty As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents ColNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyOnHand As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnChoose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
End Class
