<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormViewMatMRS
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
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl
        Me.BAttach = New DevExpress.XtraEditors.SimpleButton
        Me.BMark = New DevExpress.XtraEditors.SimpleButton
        Me.GroupGeneralFooter = New DevExpress.XtraEditors.GroupControl
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl
        Me.MENote = New DevExpress.XtraEditors.MemoEdit
        Me.GConListPurchase = New DevExpress.XtraEditors.GroupControl
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.GCMat = New DevExpress.XtraGrid.GridControl
        Me.GVMat = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdPurcDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdMat = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdMatDetPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.SEQty = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
        Me.ColNote = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQtyOnHand = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColUOM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GroupGeneralHeader = New DevExpress.XtraEditors.GroupControl
        Me.TEWONumber = New DevExpress.XtraEditors.TextEdit
        Me.LMatWo = New DevExpress.XtraEditors.LabelControl
        Me.TECompToName = New DevExpress.XtraEditors.TextEdit
        Me.TECompToCode = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.TEDate = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl
        Me.TECompName = New DevExpress.XtraEditors.TextEdit
        Me.TECompCode = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl
        Me.TEMRSNumber = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.GroupGeneralFooter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneralFooter.SuspendLayout()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GConListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GConListPurchase.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCMat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SEQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupGeneralHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneralHeader.SuspendLayout()
        CType(Me.TEWONumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECompToName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECompToCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECompName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECompCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEMRSNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl3
        '
        Me.GroupControl3.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl3.Controls.Add(Me.BAttach)
        Me.GroupControl3.Controls.Add(Me.BMark)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl3.Location = New System.Drawing.Point(0, 418)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(909, 65)
        Me.GroupControl3.TabIndex = 68
        '
        'BAttach
        '
        Me.BAttach.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BAttach.Location = New System.Drawing.Point(22, 2)
        Me.BAttach.Name = "BAttach"
        Me.BAttach.Size = New System.Drawing.Size(885, 31)
        Me.BAttach.TabIndex = 7
        Me.BAttach.Text = "Attachment"
        '
        'BMark
        '
        Me.BMark.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BMark.Location = New System.Drawing.Point(22, 33)
        Me.BMark.Name = "BMark"
        Me.BMark.Size = New System.Drawing.Size(885, 30)
        Me.BMark.TabIndex = 4
        Me.BMark.Text = "Mark"
        '
        'GroupGeneralFooter
        '
        Me.GroupGeneralFooter.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupGeneralFooter.Controls.Add(Me.LabelControl18)
        Me.GroupGeneralFooter.Controls.Add(Me.MENote)
        Me.GroupGeneralFooter.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupGeneralFooter.Location = New System.Drawing.Point(0, 349)
        Me.GroupGeneralFooter.Name = "GroupGeneralFooter"
        Me.GroupGeneralFooter.Size = New System.Drawing.Size(909, 69)
        Me.GroupGeneralFooter.TabIndex = 67
        '
        'LabelControl18
        '
        Me.LabelControl18.Location = New System.Drawing.Point(27, 11)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl18.TabIndex = 138
        Me.LabelControl18.Text = "Note"
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(77, 8)
        Me.MENote.Name = "MENote"
        Me.MENote.Properties.MaxLength = 100
        Me.MENote.Size = New System.Drawing.Size(316, 41)
        Me.MENote.TabIndex = 137
        '
        'GConListPurchase
        '
        Me.GConListPurchase.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GConListPurchase.Controls.Add(Me.PanelControl1)
        Me.GConListPurchase.Dock = System.Windows.Forms.DockStyle.Top
        Me.GConListPurchase.Location = New System.Drawing.Point(0, 93)
        Me.GConListPurchase.Name = "GConListPurchase"
        Me.GConListPurchase.Size = New System.Drawing.Size(909, 256)
        Me.GConListPurchase.TabIndex = 66
        Me.GConListPurchase.Text = "List Purchase"
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.GCMat)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(22, 2)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(885, 252)
        Me.PanelControl1.TabIndex = 19
        '
        'GCMat
        '
        Me.GCMat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMat.Location = New System.Drawing.Point(0, 0)
        Me.GCMat.MainView = Me.GVMat
        Me.GCMat.Margin = New System.Windows.Forms.Padding(0)
        Me.GCMat.Name = "GCMat"
        Me.GCMat.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.SEQty})
        Me.GCMat.Size = New System.Drawing.Size(885, 252)
        Me.GCMat.TabIndex = 2
        Me.GCMat.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMat})
        '
        'GVMat
        '
        Me.GVMat.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdPurcDet, Me.ColIdMat, Me.ColIdMatDetPrice, Me.ColNo, Me.ColCode, Me.ColName, Me.ColQty, Me.ColNote, Me.GridColumn1, Me.ColSize, Me.GridColumnQtyOnHand, Me.ColUOM, Me.GridColumn2, Me.GridColumn3})
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
        'ColIdMatDetPrice
        '
        Me.ColIdMatDetPrice.Caption = "ID Mat Det Price"
        Me.ColIdMatDetPrice.FieldName = "id_mat_det_price"
        Me.ColIdMatDetPrice.Name = "ColIdMatDetPrice"
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
        Me.ColQty.OptionsColumn.AllowEdit = False
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
        '
        'ColUOM
        '
        Me.ColUOM.AppearanceCell.Options.UseTextOptions = True
        Me.ColUOM.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColUOM.AppearanceHeader.Options.UseTextOptions = True
        Me.ColUOM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColUOM.Caption = "UOM"
        Me.ColUOM.FieldName = "uom"
        Me.ColUOM.Name = "ColUOM"
        Me.ColUOM.Visible = True
        Me.ColUOM.VisibleIndex = 6
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn2.Caption = "Qty Reserved For MRS"
        Me.GridColumn2.DisplayFormat.FormatString = "N2"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn2.FieldName = "qty_mrs"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn3.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn3.Caption = "Qty Free"
        Me.GridColumn3.DisplayFormat.FormatString = "N2"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn3.FieldName = "qty_left"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GroupGeneralHeader
        '
        Me.GroupGeneralHeader.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupGeneralHeader.Controls.Add(Me.TEWONumber)
        Me.GroupGeneralHeader.Controls.Add(Me.LMatWo)
        Me.GroupGeneralHeader.Controls.Add(Me.TECompToName)
        Me.GroupGeneralHeader.Controls.Add(Me.TECompToCode)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl2)
        Me.GroupGeneralHeader.Controls.Add(Me.TEDate)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl6)
        Me.GroupGeneralHeader.Controls.Add(Me.TECompName)
        Me.GroupGeneralHeader.Controls.Add(Me.TECompCode)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl4)
        Me.GroupGeneralHeader.Controls.Add(Me.TEMRSNumber)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl3)
        Me.GroupGeneralHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupGeneralHeader.Location = New System.Drawing.Point(0, 0)
        Me.GroupGeneralHeader.Name = "GroupGeneralHeader"
        Me.GroupGeneralHeader.Size = New System.Drawing.Size(909, 93)
        Me.GroupGeneralHeader.TabIndex = 65
        '
        'TEWONumber
        '
        Me.TEWONumber.EditValue = ""
        Me.TEWONumber.Location = New System.Drawing.Point(142, 9)
        Me.TEWONumber.Name = "TEWONumber"
        Me.TEWONumber.Properties.EditValueChangedDelay = 1
        Me.TEWONumber.Properties.ReadOnly = True
        Me.TEWONumber.Size = New System.Drawing.Size(248, 20)
        Me.TEWONumber.TabIndex = 178
        Me.TEWONumber.TabStop = False
        '
        'LMatWo
        '
        Me.LMatWo.Location = New System.Drawing.Point(33, 12)
        Me.LMatWo.Name = "LMatWo"
        Me.LMatWo.Size = New System.Drawing.Size(97, 13)
        Me.LMatWo.TabIndex = 179
        Me.LMatWo.Text = "Material Work Order"
        '
        'TECompToName
        '
        Me.TECompToName.EditValue = ""
        Me.TECompToName.Location = New System.Drawing.Point(213, 61)
        Me.TECompToName.Name = "TECompToName"
        Me.TECompToName.Properties.EditValueChangedDelay = 1
        Me.TECompToName.Properties.ReadOnly = True
        Me.TECompToName.Size = New System.Drawing.Size(177, 20)
        Me.TECompToName.TabIndex = 172
        '
        'TECompToCode
        '
        Me.TECompToCode.EditValue = ""
        Me.TECompToCode.Location = New System.Drawing.Point(142, 61)
        Me.TECompToCode.Name = "TECompToCode"
        Me.TECompToCode.Properties.EditValueChangedDelay = 1
        Me.TECompToCode.Properties.ReadOnly = True
        Me.TECompToCode.Size = New System.Drawing.Size(65, 20)
        Me.TECompToCode.TabIndex = 171
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(33, 64)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(55, 13)
        Me.LabelControl2.TabIndex = 170
        Me.LabelControl2.Text = "Request To"
        '
        'TEDate
        '
        Me.TEDate.EditValue = ""
        Me.TEDate.Location = New System.Drawing.Point(682, 35)
        Me.TEDate.Name = "TEDate"
        Me.TEDate.Properties.EditValueChangedDelay = 1
        Me.TEDate.Properties.ReadOnly = True
        Me.TEDate.Size = New System.Drawing.Size(215, 20)
        Me.TEDate.TabIndex = 0
        Me.TEDate.TabStop = False
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(615, 38)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl6.TabIndex = 124
        Me.LabelControl6.Text = "Date"
        '
        'TECompName
        '
        Me.TECompName.EditValue = ""
        Me.TECompName.Location = New System.Drawing.Point(213, 35)
        Me.TECompName.Name = "TECompName"
        Me.TECompName.Properties.EditValueChangedDelay = 1
        Me.TECompName.Properties.ReadOnly = True
        Me.TECompName.Size = New System.Drawing.Size(177, 20)
        Me.TECompName.TabIndex = 0
        Me.TECompName.TabStop = False
        '
        'TECompCode
        '
        Me.TECompCode.EditValue = ""
        Me.TECompCode.Location = New System.Drawing.Point(142, 35)
        Me.TECompCode.Name = "TECompCode"
        Me.TECompCode.Properties.EditValueChangedDelay = 1
        Me.TECompCode.Properties.ReadOnly = True
        Me.TECompCode.Size = New System.Drawing.Size(65, 20)
        Me.TECompCode.TabIndex = 0
        Me.TECompCode.TabStop = False
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(33, 38)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(67, 13)
        Me.LabelControl4.TabIndex = 88
        Me.LabelControl4.Text = "Request From"
        '
        'TEMRSNumber
        '
        Me.TEMRSNumber.EditValue = ""
        Me.TEMRSNumber.Location = New System.Drawing.Point(682, 9)
        Me.TEMRSNumber.Name = "TEMRSNumber"
        Me.TEMRSNumber.Properties.EditValueChangedDelay = 1
        Me.TEMRSNumber.Size = New System.Drawing.Size(215, 20)
        Me.TEMRSNumber.TabIndex = 3
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(615, 12)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl3.TabIndex = 86
        Me.LabelControl3.Text = "MRS Number"
        '
        'FormViewMatMRS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(909, 483)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.GroupGeneralFooter)
        Me.Controls.Add(Me.GConListPurchase)
        Me.Controls.Add(Me.GroupGeneralHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormViewMatMRS"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Material Requisition Slip"
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.GroupGeneralFooter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneralFooter.ResumeLayout(False)
        Me.GroupGeneralFooter.PerformLayout()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GConListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GConListPurchase.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCMat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SEQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupGeneralHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneralHeader.ResumeLayout(False)
        Me.GroupGeneralHeader.PerformLayout()
        CType(Me.TEWONumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECompToName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECompToCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECompName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECompCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEMRSNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupGeneralFooter As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents GConListPurchase As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCMat As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMat As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdPurcDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdMat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdMatDetPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SEQty As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents ColNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyOnHand As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupGeneralHeader As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TEWONumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LMatWo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TECompToName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TECompToCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEDate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TECompName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TECompCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEMRSNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BAttach As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
End Class
