<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDelayPaymentInvDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDelayPaymentInvDet))
        Me.GroupControlHead = New DevExpress.XtraEditors.GroupControl()
        Me.BtnCreateNew = New DevExpress.XtraEditors.SimpleButton()
        Me.DEDueDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LEReportStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.DECreated = New DevExpress.XtraEditors.DateEdit()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControlNav = New DevExpress.XtraEditors.PanelControl()
        Me.BtnDel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControlBottom = New DevExpress.XtraEditors.PanelControl()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAttachment = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnMark = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCancell = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnResetPropose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSaveChanges = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnConfirm = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_propose_delay_payment_det = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_propose_delay_payment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_sales_pos = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnstore = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_due_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnperiod = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnamount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnremark = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SLEStoreGroup = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_comp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.GroupControlHead, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlHead.SuspendLayout()
        CType(Me.DEDueDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDueDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DECreated.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DECreated.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNav.SuspendLayout()
        CType(Me.PanelControlBottom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlBottom.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEStoreGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControlHead
        '
        Me.GroupControlHead.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlHead.Controls.Add(Me.SLEStoreGroup)
        Me.GroupControlHead.Controls.Add(Me.LabelControl3)
        Me.GroupControlHead.Controls.Add(Me.BtnCreateNew)
        Me.GroupControlHead.Controls.Add(Me.DEDueDate)
        Me.GroupControlHead.Controls.Add(Me.LabelControl1)
        Me.GroupControlHead.Controls.Add(Me.MENote)
        Me.GroupControlHead.Controls.Add(Me.LabelControl7)
        Me.GroupControlHead.Controls.Add(Me.TxtNumber)
        Me.GroupControlHead.Controls.Add(Me.LabelControl2)
        Me.GroupControlHead.Controls.Add(Me.PanelControl1)
        Me.GroupControlHead.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControlHead.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlHead.Name = "GroupControlHead"
        Me.GroupControlHead.Size = New System.Drawing.Size(785, 158)
        Me.GroupControlHead.TabIndex = 18
        '
        'BtnCreateNew
        '
        Me.BtnCreateNew.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnCreateNew.Image = CType(resources.GetObject("BtnCreateNew.Image"), System.Drawing.Image)
        Me.BtnCreateNew.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.BtnCreateNew.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        Me.BtnCreateNew.Location = New System.Drawing.Point(20, 127)
        Me.BtnCreateNew.LookAndFeel.SkinMaskColor = System.Drawing.Color.DarkSeaGreen
        Me.BtnCreateNew.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnCreateNew.Name = "BtnCreateNew"
        Me.BtnCreateNew.Size = New System.Drawing.Size(538, 29)
        Me.BtnCreateNew.TabIndex = 8926
        Me.BtnCreateNew.Text = "Create New"
        Me.BtnCreateNew.Visible = False
        '
        'DEDueDate
        '
        Me.DEDueDate.EditValue = Nothing
        Me.DEDueDate.Location = New System.Drawing.Point(344, 14)
        Me.DEDueDate.Name = "DEDueDate"
        Me.DEDueDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEDueDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDueDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDueDate.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEDueDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEDueDate.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DEDueDate.Size = New System.Drawing.Size(132, 20)
        Me.DEDueDate.TabIndex = 18
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(248, 17)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(90, 13)
        Me.LabelControl1.TabIndex = 152
        Me.LabelControl1.Text = "Est. Payment Date"
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(109, 66)
        Me.MENote.Name = "MENote"
        Me.MENote.Properties.MaxLength = 255
        Me.MENote.Size = New System.Drawing.Size(367, 52)
        Me.MENote.TabIndex = 151
        Me.MENote.TabStop = False
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(31, 68)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl7.TabIndex = 150
        Me.LabelControl7.Text = "Note"
        '
        'TxtNumber
        '
        Me.TxtNumber.EditValue = ""
        Me.TxtNumber.Enabled = False
        Me.TxtNumber.Location = New System.Drawing.Point(109, 14)
        Me.TxtNumber.Name = "TxtNumber"
        Me.TxtNumber.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumber.Properties.Appearance.Options.UseFont = True
        Me.TxtNumber.Size = New System.Drawing.Size(132, 20)
        Me.TxtNumber.TabIndex = 147
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(31, 17)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(44, 13)
        Me.LabelControl2.TabIndex = 147
        Me.LabelControl2.Text = "Number"
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.LabelControl21)
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Controls.Add(Me.LEReportStatus)
        Me.PanelControl1.Controls.Add(Me.DECreated)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl1.Location = New System.Drawing.Point(558, 2)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(225, 154)
        Me.PanelControl1.TabIndex = 4
        '
        'LabelControl21
        '
        Me.LabelControl21.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl21.Location = New System.Drawing.Point(10, 41)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl21.TabIndex = 144
        Me.LabelControl21.Text = "Status"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(10, 15)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl4.TabIndex = 7
        Me.LabelControl4.Text = "Created Date"
        '
        'LEReportStatus
        '
        Me.LEReportStatus.Enabled = False
        Me.LEReportStatus.Location = New System.Drawing.Point(81, 38)
        Me.LEReportStatus.Name = "LEReportStatus"
        Me.LEReportStatus.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LEReportStatus.Properties.Appearance.Options.UseFont = True
        Me.LEReportStatus.Properties.Appearance.Options.UseTextOptions = True
        Me.LEReportStatus.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEReportStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEReportStatus.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_report_status", "ID Report Status", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("report_status", "Report Status")})
        Me.LEReportStatus.Properties.NullText = ""
        Me.LEReportStatus.Properties.ShowFooter = False
        Me.LEReportStatus.Size = New System.Drawing.Size(136, 20)
        Me.LEReportStatus.TabIndex = 7
        '
        'DECreated
        '
        Me.DECreated.EditValue = Nothing
        Me.DECreated.Enabled = False
        Me.DECreated.Location = New System.Drawing.Point(81, 12)
        Me.DECreated.Name = "DECreated"
        Me.DECreated.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DECreated.Properties.Appearance.Options.UseFont = True
        Me.DECreated.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DECreated.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DECreated.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DECreated.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DECreated.Size = New System.Drawing.Size(136, 20)
        Me.DECreated.TabIndex = 6
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.PanelControlNav)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(0, 158)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(785, 40)
        Me.PanelControl3.TabIndex = 19
        '
        'PanelControlNav
        '
        Me.PanelControlNav.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlNav.Controls.Add(Me.BtnDel)
        Me.PanelControlNav.Controls.Add(Me.BtnAdd)
        Me.PanelControlNav.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControlNav.Location = New System.Drawing.Point(426, 2)
        Me.PanelControlNav.Name = "PanelControlNav"
        Me.PanelControlNav.Size = New System.Drawing.Size(357, 36)
        Me.PanelControlNav.TabIndex = 6
        '
        'BtnDel
        '
        Me.BtnDel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDel.Image = CType(resources.GetObject("BtnDel.Image"), System.Drawing.Image)
        Me.BtnDel.Location = New System.Drawing.Point(194, 0)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(86, 36)
        Me.BtnDel.TabIndex = 7
        Me.BtnDel.Text = "Delete"
        '
        'BtnAdd
        '
        Me.BtnAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"), System.Drawing.Image)
        Me.BtnAdd.Location = New System.Drawing.Point(280, 0)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(77, 36)
        Me.BtnAdd.TabIndex = 6
        Me.BtnAdd.Text = "Add"
        '
        'PanelControlBottom
        '
        Me.PanelControlBottom.Controls.Add(Me.BtnPrint)
        Me.PanelControlBottom.Controls.Add(Me.BtnAttachment)
        Me.PanelControlBottom.Controls.Add(Me.BtnMark)
        Me.PanelControlBottom.Controls.Add(Me.BtnCancell)
        Me.PanelControlBottom.Controls.Add(Me.BtnResetPropose)
        Me.PanelControlBottom.Controls.Add(Me.BtnSaveChanges)
        Me.PanelControlBottom.Controls.Add(Me.BtnConfirm)
        Me.PanelControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControlBottom.Location = New System.Drawing.Point(0, 404)
        Me.PanelControlBottom.Name = "PanelControlBottom"
        Me.PanelControlBottom.Size = New System.Drawing.Size(785, 44)
        Me.PanelControlBottom.TabIndex = 20
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(122, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(87, 40)
        Me.BtnPrint.TabIndex = 3
        Me.BtnPrint.Text = "Print"
        '
        'BtnAttachment
        '
        Me.BtnAttachment.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAttachment.Image = CType(resources.GetObject("BtnAttachment.Image"), System.Drawing.Image)
        Me.BtnAttachment.Location = New System.Drawing.Point(209, 2)
        Me.BtnAttachment.Name = "BtnAttachment"
        Me.BtnAttachment.Size = New System.Drawing.Size(109, 40)
        Me.BtnAttachment.TabIndex = 4
        Me.BtnAttachment.Text = "Attachment"
        Me.BtnAttachment.Visible = False
        '
        'BtnMark
        '
        Me.BtnMark.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnMark.Image = CType(resources.GetObject("BtnMark.Image"), System.Drawing.Image)
        Me.BtnMark.Location = New System.Drawing.Point(2, 2)
        Me.BtnMark.Name = "BtnMark"
        Me.BtnMark.Size = New System.Drawing.Size(89, 40)
        Me.BtnMark.TabIndex = 5
        Me.BtnMark.Text = "Mark"
        Me.BtnMark.Visible = False
        '
        'BtnCancell
        '
        Me.BtnCancell.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancell.Image = CType(resources.GetObject("BtnCancell.Image"), System.Drawing.Image)
        Me.BtnCancell.Location = New System.Drawing.Point(318, 2)
        Me.BtnCancell.Name = "BtnCancell"
        Me.BtnCancell.Size = New System.Drawing.Size(126, 40)
        Me.BtnCancell.TabIndex = 7
        Me.BtnCancell.Text = "Cancell Propose"
        Me.BtnCancell.Visible = False
        '
        'BtnResetPropose
        '
        Me.BtnResetPropose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnResetPropose.Image = CType(resources.GetObject("BtnResetPropose.Image"), System.Drawing.Image)
        Me.BtnResetPropose.Location = New System.Drawing.Point(444, 2)
        Me.BtnResetPropose.Name = "BtnResetPropose"
        Me.BtnResetPropose.Size = New System.Drawing.Size(123, 40)
        Me.BtnResetPropose.TabIndex = 9
        Me.BtnResetPropose.Text = "Reset Propose"
        '
        'BtnSaveChanges
        '
        Me.BtnSaveChanges.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSaveChanges.Image = CType(resources.GetObject("BtnSaveChanges.Image"), System.Drawing.Image)
        Me.BtnSaveChanges.Location = New System.Drawing.Point(567, 2)
        Me.BtnSaveChanges.Name = "BtnSaveChanges"
        Me.BtnSaveChanges.Size = New System.Drawing.Size(120, 40)
        Me.BtnSaveChanges.TabIndex = 8
        Me.BtnSaveChanges.Text = "Save Changes"
        Me.BtnSaveChanges.Visible = False
        '
        'BtnConfirm
        '
        Me.BtnConfirm.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnConfirm.Image = CType(resources.GetObject("BtnConfirm.Image"), System.Drawing.Image)
        Me.BtnConfirm.Location = New System.Drawing.Point(687, 2)
        Me.BtnConfirm.Name = "BtnConfirm"
        Me.BtnConfirm.Size = New System.Drawing.Size(96, 40)
        Me.BtnConfirm.TabIndex = 6
        Me.BtnConfirm.Text = "Confirm"
        Me.BtnConfirm.Visible = False
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 198)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(785, 206)
        Me.GCData.TabIndex = 21
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_propose_delay_payment_det, Me.GridColumnid_propose_delay_payment, Me.GridColumnid_sales_pos, Me.GridColumnsales_pos_number, Me.GridColumnstore, Me.GridColumnsales_pos_date, Me.GridColumnsales_pos_due_date, Me.GridColumnperiod, Me.GridColumnamount, Me.GridColumnremark, Me.GridColumnno})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", Me.GridColumnamount, "{0:N2}")})
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_propose_delay_payment_det
        '
        Me.GridColumnid_propose_delay_payment_det.Caption = "id_propose_delay_payment_det"
        Me.GridColumnid_propose_delay_payment_det.FieldName = "id_propose_delay_payment_det"
        Me.GridColumnid_propose_delay_payment_det.Name = "GridColumnid_propose_delay_payment_det"
        Me.GridColumnid_propose_delay_payment_det.OptionsColumn.AllowEdit = False
        '
        'GridColumnid_propose_delay_payment
        '
        Me.GridColumnid_propose_delay_payment.Caption = "id_propose_delay_payment"
        Me.GridColumnid_propose_delay_payment.FieldName = "id_propose_delay_payment"
        Me.GridColumnid_propose_delay_payment.Name = "GridColumnid_propose_delay_payment"
        Me.GridColumnid_propose_delay_payment.OptionsColumn.AllowEdit = False
        '
        'GridColumnid_sales_pos
        '
        Me.GridColumnid_sales_pos.Caption = "id_sales_pos"
        Me.GridColumnid_sales_pos.FieldName = "id_sales_pos"
        Me.GridColumnid_sales_pos.Name = "GridColumnid_sales_pos"
        Me.GridColumnid_sales_pos.OptionsColumn.AllowEdit = False
        '
        'GridColumnsales_pos_number
        '
        Me.GridColumnsales_pos_number.Caption = "Invoice No"
        Me.GridColumnsales_pos_number.FieldName = "sales_pos_number"
        Me.GridColumnsales_pos_number.Name = "GridColumnsales_pos_number"
        Me.GridColumnsales_pos_number.OptionsColumn.AllowEdit = False
        Me.GridColumnsales_pos_number.Visible = True
        Me.GridColumnsales_pos_number.VisibleIndex = 1
        '
        'GridColumnstore
        '
        Me.GridColumnstore.Caption = "Store"
        Me.GridColumnstore.FieldName = "store"
        Me.GridColumnstore.Name = "GridColumnstore"
        Me.GridColumnstore.OptionsColumn.AllowEdit = False
        Me.GridColumnstore.Visible = True
        Me.GridColumnstore.VisibleIndex = 2
        '
        'GridColumnsales_pos_date
        '
        Me.GridColumnsales_pos_date.Caption = "Created Date"
        Me.GridColumnsales_pos_date.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.GridColumnsales_pos_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsales_pos_date.FieldName = "sales_pos_date"
        Me.GridColumnsales_pos_date.Name = "GridColumnsales_pos_date"
        Me.GridColumnsales_pos_date.OptionsColumn.AllowEdit = False
        Me.GridColumnsales_pos_date.Visible = True
        Me.GridColumnsales_pos_date.VisibleIndex = 3
        '
        'GridColumnsales_pos_due_date
        '
        Me.GridColumnsales_pos_due_date.Caption = "Due Date"
        Me.GridColumnsales_pos_due_date.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.GridColumnsales_pos_due_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsales_pos_due_date.FieldName = "sales_pos_due_date"
        Me.GridColumnsales_pos_due_date.Name = "GridColumnsales_pos_due_date"
        Me.GridColumnsales_pos_due_date.OptionsColumn.AllowEdit = False
        Me.GridColumnsales_pos_due_date.Visible = True
        Me.GridColumnsales_pos_due_date.VisibleIndex = 5
        '
        'GridColumnperiod
        '
        Me.GridColumnperiod.Caption = "Period"
        Me.GridColumnperiod.FieldName = "period"
        Me.GridColumnperiod.Name = "GridColumnperiod"
        Me.GridColumnperiod.OptionsColumn.AllowEdit = False
        Me.GridColumnperiod.Visible = True
        Me.GridColumnperiod.VisibleIndex = 4
        '
        'GridColumnamount
        '
        Me.GridColumnamount.Caption = "Amount"
        Me.GridColumnamount.DisplayFormat.FormatString = "N2"
        Me.GridColumnamount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnamount.FieldName = "amount"
        Me.GridColumnamount.Name = "GridColumnamount"
        Me.GridColumnamount.OptionsColumn.AllowEdit = False
        Me.GridColumnamount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N2}")})
        Me.GridColumnamount.Visible = True
        Me.GridColumnamount.VisibleIndex = 6
        '
        'GridColumnremark
        '
        Me.GridColumnremark.Caption = "Remark"
        Me.GridColumnremark.FieldName = "remark"
        Me.GridColumnremark.Name = "GridColumnremark"
        Me.GridColumnremark.Visible = True
        Me.GridColumnremark.VisibleIndex = 7
        '
        'GridColumnno
        '
        Me.GridColumnno.Caption = "No"
        Me.GridColumnno.FieldName = "no"
        Me.GridColumnno.Name = "GridColumnno"
        Me.GridColumnno.OptionsColumn.AllowEdit = False
        Me.GridColumnno.Visible = True
        Me.GridColumnno.VisibleIndex = 0
        '
        'SLEStoreGroup
        '
        Me.SLEStoreGroup.Location = New System.Drawing.Point(109, 40)
        Me.SLEStoreGroup.Name = "SLEStoreGroup"
        Me.SLEStoreGroup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEStoreGroup.Properties.View = Me.GridView3
        Me.SLEStoreGroup.Size = New System.Drawing.Size(367, 20)
        Me.SLEStoreGroup.TabIndex = 8928
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_comp_group, Me.GridColumncomp_group, Me.GridColumndescription})
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_comp_group
        '
        Me.GridColumnid_comp_group.Caption = "id_comp_group"
        Me.GridColumnid_comp_group.FieldName = "id_comp_group"
        Me.GridColumnid_comp_group.Name = "GridColumnid_comp_group"
        '
        'GridColumncomp_group
        '
        Me.GridColumncomp_group.Caption = "Group"
        Me.GridColumncomp_group.FieldName = "comp_group"
        Me.GridColumncomp_group.Name = "GridColumncomp_group"
        Me.GridColumncomp_group.Visible = True
        Me.GridColumncomp_group.VisibleIndex = 0
        '
        'GridColumndescription
        '
        Me.GridColumndescription.Caption = "Description"
        Me.GridColumndescription.FieldName = "description"
        Me.GridColumndescription.Name = "GridColumndescription"
        Me.GridColumndescription.Visible = True
        Me.GridColumndescription.VisibleIndex = 1
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(31, 43)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl3.TabIndex = 8927
        Me.LabelControl3.Text = "Store Group"
        '
        'FormDelayPaymentInvDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(785, 448)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControlBottom)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.GroupControlHead)
        Me.MinimizeBox = False
        Me.Name = "FormDelayPaymentInvDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Penundaan Pembayaran"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GroupControlHead, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlHead.ResumeLayout(False)
        Me.GroupControlHead.PerformLayout()
        CType(Me.DEDueDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDueDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DECreated.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DECreated.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNav.ResumeLayout(False)
        CType(Me.PanelControlBottom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlBottom.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEStoreGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupControlHead As DevExpress.XtraEditors.GroupControl
    Friend WithEvents DEDueDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEReportStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents DECreated As DevExpress.XtraEditors.DateEdit
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControlNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnDel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControlBottom As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAttachment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCancell As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnResetPropose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSaveChanges As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnConfirm As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCreateNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_propose_delay_payment_det As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_propose_delay_payment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_sales_pos As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_pos_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnstore As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_pos_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_pos_due_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnperiod As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnamount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnremark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnno As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLEStoreGroup As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_comp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
End Class
