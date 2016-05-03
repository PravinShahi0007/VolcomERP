<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProductionWOProgress
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
        Me.GCNote = New DevExpress.XtraGrid.GridControl
        Me.GVNote = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl
        Me.BDelete = New DevExpress.XtraEditors.SimpleButton
        Me.BEdit = New DevExpress.XtraEditors.SimpleButton
        Me.BAdd = New DevExpress.XtraEditors.SimpleButton
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl
        Me.BViewImage = New DevExpress.XtraEditors.SimpleButton
        Me.PEPic = New DevExpress.XtraEditors.PictureEdit
        Me.GCSizeQty = New DevExpress.XtraGrid.GridControl
        Me.GVSizeQty = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnIdWoDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.LDateDel = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl22 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl23 = New DevExpress.XtraEditors.LabelControl
        Me.LPONumber = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl19 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl20 = New DevExpress.XtraEditors.LabelControl
        Me.LVendor = New DevExpress.XtraEditors.LabelControl
        Me.LestDateRec = New DevExpress.XtraEditors.LabelControl
        Me.LLeadTime = New DevExpress.XtraEditors.LabelControl
        Me.LDesign = New DevExpress.XtraEditors.LabelControl
        Me.LWONumber = New DevExpress.XtraEditors.LabelControl
        Me.LWOType = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl24 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl
        Me.PBCWO = New DevExpress.XtraEditors.ProgressBarControl
        Me.BProgress = New DevExpress.XtraEditors.SimpleButton
        CType(Me.GCNote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVNote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.PEPic.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCSizeQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSizeQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PBCWO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCNote
        '
        Me.GCNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCNote.Location = New System.Drawing.Point(189, 134)
        Me.GCNote.MainView = Me.GVNote
        Me.GCNote.Name = "GCNote"
        Me.GCNote.Size = New System.Drawing.Size(560, 319)
        Me.GCNote.TabIndex = 11
        Me.GCNote.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVNote})
        '
        'GVNote
        '
        Me.GVNote.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumnNo, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4})
        Me.GVNote.GridControl = Me.GCNote
        Me.GVNote.Name = "GVNote"
        Me.GVNote.OptionsBehavior.Editable = False
        Me.GVNote.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID WO Det"
        Me.GridColumn1.FieldName = "id_prod_order_wo_prog"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumnNo
        '
        Me.GridColumnNo.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnNo.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnNo.Caption = "No."
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 50
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Note"
        Me.GridColumn2.FieldName = "prod_order_wo_prog_note"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 250
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Date"
        Me.GridColumn3.FieldName = "prod_order_wo_prog_date"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 3
        Me.GridColumn3.Width = 162
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn4.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn4.Caption = "Progress"
        Me.GridColumn4.FieldName = "prod_order_wo_prog_percent"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        Me.GridColumn4.Width = 80
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.BDelete)
        Me.PanelControl4.Controls.Add(Me.BEdit)
        Me.PanelControl4.Controls.Add(Me.BAdd)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl4.Location = New System.Drawing.Point(189, 99)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(560, 35)
        Me.PanelControl4.TabIndex = 10
        '
        'BDelete
        '
        Me.BDelete.Dock = System.Windows.Forms.DockStyle.Right
        Me.BDelete.ImageIndex = 3
        Me.BDelete.Location = New System.Drawing.Point(318, 2)
        Me.BDelete.Name = "BDelete"
        Me.BDelete.Size = New System.Drawing.Size(80, 31)
        Me.BDelete.TabIndex = 25
        Me.BDelete.Text = "Delete"
        '
        'BEdit
        '
        Me.BEdit.Dock = System.Windows.Forms.DockStyle.Right
        Me.BEdit.ImageIndex = 3
        Me.BEdit.Location = New System.Drawing.Point(398, 2)
        Me.BEdit.Name = "BEdit"
        Me.BEdit.Size = New System.Drawing.Size(80, 31)
        Me.BEdit.TabIndex = 24
        Me.BEdit.Text = "Edit"
        '
        'BAdd
        '
        Me.BAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAdd.ImageIndex = 3
        Me.BAdd.Location = New System.Drawing.Point(478, 2)
        Me.BAdd.Name = "BAdd"
        Me.BAdd.Size = New System.Drawing.Size(80, 31)
        Me.BAdd.TabIndex = 23
        Me.BAdd.Text = "Add"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.BViewImage)
        Me.PanelControl3.Controls.Add(Me.PEPic)
        Me.PanelControl3.Controls.Add(Me.GCSizeQty)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl3.Location = New System.Drawing.Point(0, 99)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(189, 354)
        Me.PanelControl3.TabIndex = 9
        '
        'BViewImage
        '
        Me.BViewImage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BViewImage.Location = New System.Drawing.Point(2, 187)
        Me.BViewImage.Name = "BViewImage"
        Me.BViewImage.Size = New System.Drawing.Size(185, 27)
        Me.BViewImage.TabIndex = 97
        Me.BViewImage.Text = "View Image"
        '
        'PEPic
        '
        Me.PEPic.Dock = System.Windows.Forms.DockStyle.Top
        Me.PEPic.Location = New System.Drawing.Point(2, 2)
        Me.PEPic.Name = "PEPic"
        Me.PEPic.Properties.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.Image
        Me.PEPic.Properties.ReadOnly = True
        Me.PEPic.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PEPic.Size = New System.Drawing.Size(185, 185)
        Me.PEPic.TabIndex = 8
        '
        'GCSizeQty
        '
        Me.GCSizeQty.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GCSizeQty.Location = New System.Drawing.Point(2, 214)
        Me.GCSizeQty.MainView = Me.GVSizeQty
        Me.GCSizeQty.Name = "GCSizeQty"
        Me.GCSizeQty.Size = New System.Drawing.Size(185, 138)
        Me.GCSizeQty.TabIndex = 5
        Me.GCSizeQty.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSizeQty})
        '
        'GVSizeQty
        '
        Me.GVSizeQty.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdWoDet, Me.GridColumnSize, Me.GridColumnQty})
        Me.GVSizeQty.GridControl = Me.GCSizeQty
        Me.GVSizeQty.Name = "GVSizeQty"
        Me.GVSizeQty.OptionsBehavior.Editable = False
        Me.GVSizeQty.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdWoDet
        '
        Me.GridColumnIdWoDet.Caption = "ID WO Det"
        Me.GridColumnIdWoDet.FieldName = "id_prod_order_wo_det"
        Me.GridColumnIdWoDet.Name = "GridColumnIdWoDet"
        '
        'GridColumnSize
        '
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 0
        '
        'GridColumnQty
        '
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.FieldName = "qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 1
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LDateDel)
        Me.PanelControl1.Controls.Add(Me.LabelControl22)
        Me.PanelControl1.Controls.Add(Me.LabelControl23)
        Me.PanelControl1.Controls.Add(Me.LPONumber)
        Me.PanelControl1.Controls.Add(Me.LabelControl19)
        Me.PanelControl1.Controls.Add(Me.LabelControl20)
        Me.PanelControl1.Controls.Add(Me.LVendor)
        Me.PanelControl1.Controls.Add(Me.LestDateRec)
        Me.PanelControl1.Controls.Add(Me.LLeadTime)
        Me.PanelControl1.Controls.Add(Me.LDesign)
        Me.PanelControl1.Controls.Add(Me.LWONumber)
        Me.PanelControl1.Controls.Add(Me.LWOType)
        Me.PanelControl1.Controls.Add(Me.LabelControl8)
        Me.PanelControl1.Controls.Add(Me.LabelControl9)
        Me.PanelControl1.Controls.Add(Me.LabelControl11)
        Me.PanelControl1.Controls.Add(Me.LabelControl6)
        Me.PanelControl1.Controls.Add(Me.LabelControl5)
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.LabelControl10)
        Me.PanelControl1.Controls.Add(Me.LabelControl7)
        Me.PanelControl1.Controls.Add(Me.LabelControl24)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(749, 99)
        Me.PanelControl1.TabIndex = 8
        '
        'LDateDel
        '
        Me.LDateDel.Appearance.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.LDateDel.Location = New System.Drawing.Point(544, 12)
        Me.LDateDel.Name = "LDateDel"
        Me.LDateDel.Size = New System.Drawing.Size(4, 14)
        Me.LDateDel.TabIndex = 167
        Me.LDateDel.Text = "-"
        '
        'LabelControl22
        '
        Me.LabelControl22.Appearance.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.LabelControl22.Location = New System.Drawing.Point(534, 12)
        Me.LabelControl22.Name = "LabelControl22"
        Me.LabelControl22.Size = New System.Drawing.Size(4, 14)
        Me.LabelControl22.TabIndex = 166
        Me.LabelControl22.Text = ":"
        '
        'LabelControl23
        '
        Me.LabelControl23.Appearance.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.LabelControl23.Location = New System.Drawing.Point(380, 12)
        Me.LabelControl23.Name = "LabelControl23"
        Me.LabelControl23.Size = New System.Drawing.Size(130, 14)
        Me.LabelControl23.TabIndex = 165
        Me.LabelControl23.Text = "Est. Delivery To Vendor"
        '
        'LPONumber
        '
        Me.LPONumber.Appearance.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.LPONumber.Location = New System.Drawing.Point(139, 31)
        Me.LPONumber.Name = "LPONumber"
        Me.LPONumber.Size = New System.Drawing.Size(4, 14)
        Me.LPONumber.TabIndex = 164
        Me.LPONumber.Text = "-"
        '
        'LabelControl19
        '
        Me.LabelControl19.Appearance.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.LabelControl19.Location = New System.Drawing.Point(129, 31)
        Me.LabelControl19.Name = "LabelControl19"
        Me.LabelControl19.Size = New System.Drawing.Size(4, 14)
        Me.LabelControl19.TabIndex = 163
        Me.LabelControl19.Text = ":"
        '
        'LabelControl20
        '
        Me.LabelControl20.Appearance.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.LabelControl20.Location = New System.Drawing.Point(12, 31)
        Me.LabelControl20.Name = "LabelControl20"
        Me.LabelControl20.Size = New System.Drawing.Size(106, 14)
        Me.LabelControl20.TabIndex = 162
        Me.LabelControl20.Text = "Production Number"
        '
        'LVendor
        '
        Me.LVendor.Appearance.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.LVendor.Location = New System.Drawing.Point(544, 71)
        Me.LVendor.Name = "LVendor"
        Me.LVendor.Size = New System.Drawing.Size(4, 14)
        Me.LVendor.TabIndex = 161
        Me.LVendor.Text = "-"
        '
        'LestDateRec
        '
        Me.LestDateRec.Appearance.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.LestDateRec.Location = New System.Drawing.Point(544, 51)
        Me.LestDateRec.Name = "LestDateRec"
        Me.LestDateRec.Size = New System.Drawing.Size(4, 14)
        Me.LestDateRec.TabIndex = 160
        Me.LestDateRec.Text = "-"
        '
        'LLeadTime
        '
        Me.LLeadTime.Appearance.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.LLeadTime.Location = New System.Drawing.Point(544, 32)
        Me.LLeadTime.Name = "LLeadTime"
        Me.LLeadTime.Size = New System.Drawing.Size(4, 14)
        Me.LLeadTime.TabIndex = 159
        Me.LLeadTime.Text = "-"
        '
        'LDesign
        '
        Me.LDesign.Appearance.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.LDesign.Location = New System.Drawing.Point(139, 71)
        Me.LDesign.Name = "LDesign"
        Me.LDesign.Size = New System.Drawing.Size(4, 14)
        Me.LDesign.TabIndex = 158
        Me.LDesign.Text = "-"
        '
        'LWONumber
        '
        Me.LWONumber.Appearance.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.LWONumber.Location = New System.Drawing.Point(139, 51)
        Me.LWONumber.Name = "LWONumber"
        Me.LWONumber.Size = New System.Drawing.Size(4, 14)
        Me.LWONumber.TabIndex = 157
        Me.LWONumber.Text = "-"
        '
        'LWOType
        '
        Me.LWOType.Appearance.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.LWOType.Location = New System.Drawing.Point(139, 12)
        Me.LWOType.Name = "LWOType"
        Me.LWOType.Size = New System.Drawing.Size(4, 14)
        Me.LWOType.TabIndex = 156
        Me.LWOType.Text = "-"
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.LabelControl8.Location = New System.Drawing.Point(534, 71)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(4, 14)
        Me.LabelControl8.TabIndex = 155
        Me.LabelControl8.Text = ":"
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.LabelControl9.Location = New System.Drawing.Point(534, 32)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(4, 14)
        Me.LabelControl9.TabIndex = 154
        Me.LabelControl9.Text = ":"
        '
        'LabelControl11
        '
        Me.LabelControl11.Appearance.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.LabelControl11.Location = New System.Drawing.Point(534, 51)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(4, 14)
        Me.LabelControl11.TabIndex = 153
        Me.LabelControl11.Text = ":"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.LabelControl6.Location = New System.Drawing.Point(129, 71)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(4, 14)
        Me.LabelControl6.TabIndex = 152
        Me.LabelControl6.Text = ":"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.LabelControl5.Location = New System.Drawing.Point(129, 12)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(4, 14)
        Me.LabelControl5.TabIndex = 151
        Me.LabelControl5.Text = ":"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.LabelControl4.Location = New System.Drawing.Point(129, 51)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(4, 14)
        Me.LabelControl4.TabIndex = 150
        Me.LabelControl4.Text = ":"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.LabelControl2.Location = New System.Drawing.Point(380, 71)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(46, 14)
        Me.LabelControl2.TabIndex = 149
        Me.LabelControl2.Text = "Location"
        '
        'LabelControl10
        '
        Me.LabelControl10.Appearance.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.LabelControl10.Location = New System.Drawing.Point(380, 52)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(148, 14)
        Me.LabelControl10.TabIndex = 148
        Me.LabelControl10.Text = "Est. Receive In Warehouse"
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.LabelControl7.Location = New System.Drawing.Point(380, 32)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(57, 14)
        Me.LabelControl7.TabIndex = 147
        Me.LabelControl7.Text = "Lead Time"
        '
        'LabelControl24
        '
        Me.LabelControl24.Appearance.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.LabelControl24.Location = New System.Drawing.Point(12, 71)
        Me.LabelControl24.Name = "LabelControl24"
        Me.LabelControl24.Size = New System.Drawing.Size(36, 14)
        Me.LabelControl24.TabIndex = 146
        Me.LabelControl24.Text = "Design"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.LabelControl3.Location = New System.Drawing.Point(12, 51)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(111, 14)
        Me.LabelControl3.TabIndex = 123
        Me.LabelControl3.Text = "Work Order Number"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(64, 14)
        Me.LabelControl1.TabIndex = 122
        Me.LabelControl1.Text = "Work Order"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.PBCWO)
        Me.PanelControl2.Controls.Add(Me.BProgress)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 453)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(749, 35)
        Me.PanelControl2.TabIndex = 7
        '
        'PBCWO
        '
        Me.PBCWO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PBCWO.Location = New System.Drawing.Point(2, 2)
        Me.PBCWO.Name = "PBCWO"
        Me.PBCWO.Size = New System.Drawing.Size(665, 31)
        Me.PBCWO.TabIndex = 151
        '
        'BProgress
        '
        Me.BProgress.Dock = System.Windows.Forms.DockStyle.Right
        Me.BProgress.ImageIndex = 3
        Me.BProgress.Location = New System.Drawing.Point(667, 2)
        Me.BProgress.Name = "BProgress"
        Me.BProgress.Size = New System.Drawing.Size(80, 31)
        Me.BProgress.TabIndex = 23
        Me.BProgress.Text = "Close"
        '
        'FormProductionWOProgress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 488)
        Me.Controls.Add(Me.GCNote)
        Me.Controls.Add(Me.PanelControl4)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PanelControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProductionWOProgress"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Work Order Progress"
        CType(Me.GCNote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVNote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.PEPic.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCSizeQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSizeQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PBCWO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCNote As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVNote As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BViewImage As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PEPic As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents GCSizeQty As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSizeQty As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdWoDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LDateDel As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl22 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl23 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LPONumber As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl19 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl20 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LVendor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LestDateRec As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LLeadTime As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LDesign As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LWONumber As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LWOType As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl24 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PBCWO As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents BProgress As DevExpress.XtraEditors.SimpleButton
End Class
