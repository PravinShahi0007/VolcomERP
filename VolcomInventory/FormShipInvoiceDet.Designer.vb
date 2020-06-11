<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormShipInvoiceDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormShipInvoiceDet))
        Me.GroupGeneralHeader = New DevExpress.XtraEditors.GroupControl()
        Me.PanelControlTopLeft = New DevExpress.XtraEditors.PanelControl()
        Me.DEDueDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.DEEnd = New DevExpress.XtraEditors.DateEdit()
        Me.TXTName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelName = New System.Windows.Forms.Label()
        Me.DEStart = New DevExpress.XtraEditors.DateEdit()
        Me.LabelStore = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelOLStoreNumber = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtCodeCompFrom = New DevExpress.XtraEditors.TextEdit()
        Me.TxtNameCompFrom = New DevExpress.XtraEditors.TextEdit()
        Me.TxtOLStoreNumber = New DevExpress.XtraEditors.TextEdit()
        Me.PanelControlTopMiddle = New DevExpress.XtraEditors.PanelControl()
        Me.LETypeSO = New DevExpress.XtraEditors.LookUpEdit()
        Me.PanelControlTopRight = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtVirtualPosNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LEReportStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.DEForm = New DevExpress.XtraEditors.TextEdit()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.CEPrintPreview = New DevExpress.XtraEditors.CheckEdit()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BMark = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl()
        Me.XTCData = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPDetail = New DevExpress.XtraTab.XtraTabPage()
        Me.BtnViewJournal = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GroupGeneralHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneralHeader.SuspendLayout()
        CType(Me.PanelControlTopLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlTopLeft.SuspendLayout()
        CType(Me.DEDueDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDueDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXTName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodeCompFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNameCompFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtOLStoreNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlTopMiddle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlTopMiddle.SuspendLayout()
        CType(Me.LETypeSO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlTopRight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlTopRight.SuspendLayout()
        CType(Me.TxtVirtualPosNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEForm.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.CEPrintPreview.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCData.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupGeneralHeader
        '
        Me.GroupGeneralHeader.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupGeneralHeader.Controls.Add(Me.PanelControlTopLeft)
        Me.GroupGeneralHeader.Controls.Add(Me.PanelControlTopMiddle)
        Me.GroupGeneralHeader.Controls.Add(Me.PanelControlTopRight)
        Me.GroupGeneralHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupGeneralHeader.Location = New System.Drawing.Point(0, 0)
        Me.GroupGeneralHeader.Name = "GroupGeneralHeader"
        Me.GroupGeneralHeader.Size = New System.Drawing.Size(935, 160)
        Me.GroupGeneralHeader.TabIndex = 185
        '
        'PanelControlTopLeft
        '
        Me.PanelControlTopLeft.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlTopLeft.Controls.Add(Me.DEDueDate)
        Me.PanelControlTopLeft.Controls.Add(Me.LabelControl4)
        Me.PanelControlTopLeft.Controls.Add(Me.DEEnd)
        Me.PanelControlTopLeft.Controls.Add(Me.TXTName)
        Me.PanelControlTopLeft.Controls.Add(Me.LabelName)
        Me.PanelControlTopLeft.Controls.Add(Me.DEStart)
        Me.PanelControlTopLeft.Controls.Add(Me.LabelStore)
        Me.PanelControlTopLeft.Controls.Add(Me.LabelControl2)
        Me.PanelControlTopLeft.Controls.Add(Me.LabelOLStoreNumber)
        Me.PanelControlTopLeft.Controls.Add(Me.LabelControl8)
        Me.PanelControlTopLeft.Controls.Add(Me.TxtCodeCompFrom)
        Me.PanelControlTopLeft.Controls.Add(Me.TxtNameCompFrom)
        Me.PanelControlTopLeft.Controls.Add(Me.TxtOLStoreNumber)
        Me.PanelControlTopLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControlTopLeft.Location = New System.Drawing.Point(20, 2)
        Me.PanelControlTopLeft.Name = "PanelControlTopLeft"
        Me.PanelControlTopLeft.Size = New System.Drawing.Size(371, 156)
        Me.PanelControlTopLeft.TabIndex = 8933
        '
        'DEDueDate
        '
        Me.DEDueDate.EditValue = Nothing
        Me.DEDueDate.Location = New System.Drawing.Point(78, 88)
        Me.DEDueDate.Name = "DEDueDate"
        Me.DEDueDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDueDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEDueDate.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEDueDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEDueDate.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEDueDate.Size = New System.Drawing.Size(274, 20)
        Me.DEDueDate.TabIndex = 3
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(214, 117)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(4, 13)
        Me.LabelControl4.TabIndex = 8926
        Me.LabelControl4.Text = "-"
        '
        'DEEnd
        '
        Me.DEEnd.EditValue = Nothing
        Me.DEEnd.Location = New System.Drawing.Point(225, 114)
        Me.DEEnd.Name = "DEEnd"
        Me.DEEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEnd.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEEnd.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEEnd.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEEnd.Size = New System.Drawing.Size(127, 20)
        Me.DEEnd.TabIndex = 5
        '
        'TXTName
        '
        Me.TXTName.EditValue = ""
        Me.TXTName.Location = New System.Drawing.Point(78, 62)
        Me.TXTName.Name = "TXTName"
        Me.TXTName.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTName.Properties.Appearance.Options.UseFont = True
        Me.TXTName.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.TXTName.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TXTName.Properties.EditValueChangedDelay = 1
        Me.TXTName.Properties.ReadOnly = True
        Me.TXTName.Size = New System.Drawing.Size(274, 20)
        Me.TXTName.TabIndex = 8960
        Me.TXTName.TabStop = False
        '
        'LabelName
        '
        Me.LabelName.AutoSize = True
        Me.LabelName.Location = New System.Drawing.Point(6, 65)
        Me.LabelName.Name = "LabelName"
        Me.LabelName.Size = New System.Drawing.Size(63, 13)
        Me.LabelName.TabIndex = 8959
        Me.LabelName.Text = "Cust. Name"
        '
        'DEStart
        '
        Me.DEStart.EditValue = Nothing
        Me.DEStart.Location = New System.Drawing.Point(78, 114)
        Me.DEStart.Name = "DEStart"
        Me.DEStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEStart.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStart.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEStart.Size = New System.Drawing.Size(130, 20)
        Me.DEStart.TabIndex = 4
        '
        'LabelStore
        '
        Me.LabelStore.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelStore.Location = New System.Drawing.Point(9, 13)
        Me.LabelStore.Name = "LabelStore"
        Me.LabelStore.Size = New System.Drawing.Size(26, 13)
        Me.LabelStore.TabIndex = 145
        Me.LabelStore.Text = "Store"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(9, 117)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(30, 13)
        Me.LabelControl2.TabIndex = 8925
        Me.LabelControl2.Text = "Period"
        '
        'LabelOLStoreNumber
        '
        Me.LabelOLStoreNumber.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelOLStoreNumber.Location = New System.Drawing.Point(9, 39)
        Me.LabelOLStoreNumber.Name = "LabelOLStoreNumber"
        Me.LabelOLStoreNumber.Size = New System.Drawing.Size(56, 13)
        Me.LabelOLStoreNumber.TabIndex = 163
        Me.LabelOLStoreNumber.Text = "Order Ref#"
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Location = New System.Drawing.Point(9, 91)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl8.TabIndex = 8930
        Me.LabelControl8.Text = "Due Date"
        '
        'TxtCodeCompFrom
        '
        Me.TxtCodeCompFrom.EditValue = ""
        Me.TxtCodeCompFrom.Location = New System.Drawing.Point(78, 10)
        Me.TxtCodeCompFrom.Name = "TxtCodeCompFrom"
        Me.TxtCodeCompFrom.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodeCompFrom.Properties.Appearance.Options.UseFont = True
        Me.TxtCodeCompFrom.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White
        Me.TxtCodeCompFrom.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.TxtCodeCompFrom.Properties.EditValueChangedDelay = 1
        Me.TxtCodeCompFrom.Size = New System.Drawing.Size(82, 20)
        Me.TxtCodeCompFrom.TabIndex = 2
        '
        'TxtNameCompFrom
        '
        Me.TxtNameCompFrom.EditValue = ""
        Me.TxtNameCompFrom.Location = New System.Drawing.Point(164, 10)
        Me.TxtNameCompFrom.Name = "TxtNameCompFrom"
        Me.TxtNameCompFrom.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNameCompFrom.Properties.Appearance.Options.UseFont = True
        Me.TxtNameCompFrom.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White
        Me.TxtNameCompFrom.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.TxtNameCompFrom.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.TxtNameCompFrom.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TxtNameCompFrom.Properties.EditValueChangedDelay = 1
        Me.TxtNameCompFrom.Properties.ReadOnly = True
        Me.TxtNameCompFrom.Size = New System.Drawing.Size(188, 20)
        Me.TxtNameCompFrom.TabIndex = 8888
        Me.TxtNameCompFrom.TabStop = False
        '
        'TxtOLStoreNumber
        '
        Me.TxtOLStoreNumber.EditValue = ""
        Me.TxtOLStoreNumber.Location = New System.Drawing.Point(78, 36)
        Me.TxtOLStoreNumber.Name = "TxtOLStoreNumber"
        Me.TxtOLStoreNumber.Properties.EditValueChangedDelay = 1
        Me.TxtOLStoreNumber.Properties.ReadOnly = True
        Me.TxtOLStoreNumber.Size = New System.Drawing.Size(274, 20)
        Me.TxtOLStoreNumber.TabIndex = 164
        Me.TxtOLStoreNumber.TabStop = False
        '
        'PanelControlTopMiddle
        '
        Me.PanelControlTopMiddle.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlTopMiddle.Controls.Add(Me.LETypeSO)
        Me.PanelControlTopMiddle.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControlTopMiddle.Location = New System.Drawing.Point(391, 2)
        Me.PanelControlTopMiddle.Name = "PanelControlTopMiddle"
        Me.PanelControlTopMiddle.Size = New System.Drawing.Size(330, 156)
        Me.PanelControlTopMiddle.TabIndex = 8934
        '
        'LETypeSO
        '
        Me.LETypeSO.Location = New System.Drawing.Point(83, 214)
        Me.LETypeSO.Name = "LETypeSO"
        Me.LETypeSO.Properties.Appearance.Options.UseTextOptions = True
        Me.LETypeSO.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LETypeSO.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LETypeSO.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_so_type", "ID SO Type", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("so_type", "Type")})
        Me.LETypeSO.Properties.NullText = ""
        Me.LETypeSO.Properties.ShowFooter = False
        Me.LETypeSO.Size = New System.Drawing.Size(234, 20)
        Me.LETypeSO.TabIndex = 2
        '
        'PanelControlTopRight
        '
        Me.PanelControlTopRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlTopRight.Controls.Add(Me.LabelControl21)
        Me.PanelControlTopRight.Controls.Add(Me.TxtVirtualPosNumber)
        Me.PanelControlTopRight.Controls.Add(Me.LEReportStatus)
        Me.PanelControlTopRight.Controls.Add(Me.LabelControl5)
        Me.PanelControlTopRight.Controls.Add(Me.LabelControl7)
        Me.PanelControlTopRight.Controls.Add(Me.DEForm)
        Me.PanelControlTopRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControlTopRight.Location = New System.Drawing.Point(721, 2)
        Me.PanelControlTopRight.Name = "PanelControlTopRight"
        Me.PanelControlTopRight.Size = New System.Drawing.Size(212, 156)
        Me.PanelControlTopRight.TabIndex = 8935
        '
        'LabelControl21
        '
        Me.LabelControl21.Location = New System.Drawing.Point(14, 65)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl21.TabIndex = 189
        Me.LabelControl21.Text = "Status"
        '
        'TxtVirtualPosNumber
        '
        Me.TxtVirtualPosNumber.EditValue = ""
        Me.TxtVirtualPosNumber.Location = New System.Drawing.Point(80, 36)
        Me.TxtVirtualPosNumber.Name = "TxtVirtualPosNumber"
        Me.TxtVirtualPosNumber.Properties.EditValueChangedDelay = 1
        Me.TxtVirtualPosNumber.Properties.ReadOnly = True
        Me.TxtVirtualPosNumber.Size = New System.Drawing.Size(117, 20)
        Me.TxtVirtualPosNumber.TabIndex = 8
        Me.TxtVirtualPosNumber.TabStop = False
        '
        'LEReportStatus
        '
        Me.LEReportStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LEReportStatus.Enabled = False
        Me.LEReportStatus.Location = New System.Drawing.Point(80, 62)
        Me.LEReportStatus.Name = "LEReportStatus"
        Me.LEReportStatus.Properties.Appearance.Options.UseTextOptions = True
        Me.LEReportStatus.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEReportStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEReportStatus.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_report_status", "ID Report Status", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("report_status", "Report Status")})
        Me.LEReportStatus.Properties.NullText = ""
        Me.LEReportStatus.Properties.ShowFooter = False
        Me.LEReportStatus.Size = New System.Drawing.Size(117, 20)
        Me.LEReportStatus.TabIndex = 188
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(14, 39)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl5.TabIndex = 155
        Me.LabelControl5.Text = "Number"
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(14, 13)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl7.TabIndex = 159
        Me.LabelControl7.Text = "Date"
        '
        'DEForm
        '
        Me.DEForm.EditValue = ""
        Me.DEForm.Location = New System.Drawing.Point(80, 10)
        Me.DEForm.Name = "DEForm"
        Me.DEForm.Properties.EditValueChangedDelay = 1
        Me.DEForm.Properties.ReadOnly = True
        Me.DEForm.Size = New System.Drawing.Size(117, 20)
        Me.DEForm.TabIndex = 162
        Me.DEForm.TabStop = False
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.PanelControl1)
        Me.PanelControl3.Controls.Add(Me.BtnPrint)
        Me.PanelControl3.Controls.Add(Me.BMark)
        Me.PanelControl3.Controls.Add(Me.BtnViewJournal)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 514)
        Me.PanelControl3.LookAndFeel.SkinName = "Blue"
        Me.PanelControl3.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(935, 43)
        Me.PanelControl3.TabIndex = 186
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.CEPrintPreview)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl1.Location = New System.Drawing.Point(666, 2)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(71, 39)
        Me.PanelControl1.TabIndex = 25
        '
        'CEPrintPreview
        '
        Me.CEPrintPreview.Location = New System.Drawing.Point(5, 10)
        Me.CEPrintPreview.Name = "CEPrintPreview"
        Me.CEPrintPreview.Properties.Caption = "Preview"
        Me.CEPrintPreview.Size = New System.Drawing.Size(60, 19)
        Me.CEPrintPreview.TabIndex = 145
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.ImageIndex = 6
        Me.BtnPrint.Location = New System.Drawing.Point(737, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(87, 39)
        Me.BtnPrint.TabIndex = 9
        Me.BtnPrint.TabStop = False
        Me.BtnPrint.Text = "Print"
        '
        'BMark
        '
        Me.BMark.Dock = System.Windows.Forms.DockStyle.Left
        Me.BMark.Image = CType(resources.GetObject("BMark.Image"), System.Drawing.Image)
        Me.BMark.ImageIndex = 4
        Me.BMark.Location = New System.Drawing.Point(2, 2)
        Me.BMark.Name = "BMark"
        Me.BMark.Size = New System.Drawing.Size(87, 39)
        Me.BMark.TabIndex = 11
        Me.BMark.TabStop = False
        Me.BMark.Text = "Mark"
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.MENote)
        Me.GroupControl1.Controls.Add(Me.LabelControl18)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl1.Location = New System.Drawing.Point(0, 447)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(935, 67)
        Me.GroupControl1.TabIndex = 187
        '
        'MENote
        '
        Me.MENote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MENote.Location = New System.Drawing.Point(76, 10)
        Me.MENote.Name = "MENote"
        Me.MENote.Properties.MaxLength = 100
        Me.MENote.Size = New System.Drawing.Size(842, 42)
        Me.MENote.TabIndex = 139
        '
        'LabelControl18
        '
        Me.LabelControl18.Location = New System.Drawing.Point(29, 12)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl18.TabIndex = 140
        Me.LabelControl18.Text = "Note"
        '
        'XTCData
        '
        Me.XTCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCData.Location = New System.Drawing.Point(0, 160)
        Me.XTCData.Name = "XTCData"
        Me.XTCData.SelectedTabPage = Me.XTPDetail
        Me.XTCData.Size = New System.Drawing.Size(935, 287)
        Me.XTCData.TabIndex = 188
        Me.XTCData.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPDetail})
        '
        'XTPDetail
        '
        Me.XTPDetail.Name = "XTPDetail"
        Me.XTPDetail.Size = New System.Drawing.Size(929, 259)
        Me.XTPDetail.Text = "Detail"
        '
        'BtnViewJournal
        '
        Me.BtnViewJournal.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnViewJournal.Image = CType(resources.GetObject("BtnViewJournal.Image"), System.Drawing.Image)
        Me.BtnViewJournal.ImageIndex = 6
        Me.BtnViewJournal.Location = New System.Drawing.Point(824, 2)
        Me.BtnViewJournal.Name = "BtnViewJournal"
        Me.BtnViewJournal.Size = New System.Drawing.Size(109, 39)
        Me.BtnViewJournal.TabIndex = 26
        Me.BtnViewJournal.TabStop = False
        Me.BtnViewJournal.Text = "View Journal"
        '
        'FormShipInvoiceDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(935, 557)
        Me.Controls.Add(Me.XTCData)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.GroupGeneralHeader)
        Me.MinimizeBox = False
        Me.Name = "FormShipInvoiceDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Shipping Invoice"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GroupGeneralHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneralHeader.ResumeLayout(False)
        CType(Me.PanelControlTopLeft, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlTopLeft.ResumeLayout(False)
        Me.PanelControlTopLeft.PerformLayout()
        CType(Me.DEDueDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDueDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXTName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodeCompFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNameCompFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtOLStoreNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlTopMiddle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlTopMiddle.ResumeLayout(False)
        CType(Me.LETypeSO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlTopRight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlTopRight.ResumeLayout(False)
        Me.PanelControlTopRight.PerformLayout()
        CType(Me.TxtVirtualPosNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEForm.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.CEPrintPreview.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCData.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupGeneralHeader As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PanelControlTopLeft As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DEDueDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TXTName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DEEnd As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelName As Label
    Friend WithEvents DEStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelStore As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelOLStoreNumber As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtCodeCompFrom As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtNameCompFrom As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtOLStoreNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PanelControlTopMiddle As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LETypeSO As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents PanelControlTopRight As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TxtVirtualPosNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEForm As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CEPrintPreview As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEReportStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents XTCData As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPDetail As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents BtnViewJournal As DevExpress.XtraEditors.SimpleButton
End Class
