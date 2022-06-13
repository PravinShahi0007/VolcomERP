<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTargetSalesDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormTargetSalesDet))
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.GroupControlHead = New DevExpress.XtraEditors.GroupControl()
        Me.TxtYear = New DevExpress.XtraEditors.TextEdit()
        Me.BtnChangeEffectiveDate = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCreateNew = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelEffectiveDate = New DevExpress.XtraEditors.LabelControl()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtType = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LEReportStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.DECreated = New DevExpress.XtraEditors.DateEdit()
        Me.TxtNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControlNav = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControlOptionView = New DevExpress.XtraEditors.PanelControl()
        Me.SLEOptionView = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnDeletePTH = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAddPTH = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControlBottom = New DevExpress.XtraEditors.PanelControl()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAttachment = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnMark = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCancell = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnResetPropose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSaveChanges = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnConfirm = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        CType(Me.GroupControlHead, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlHead.SuspendLayout()
        CType(Me.TxtYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TxtType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DECreated.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DECreated.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNav.SuspendLayout()
        CType(Me.PanelControlOptionView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlOptionView.SuspendLayout()
        CType(Me.SLEOptionView.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlBottom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlBottom.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControlHead
        '
        Me.GroupControlHead.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlHead.Controls.Add(Me.TxtYear)
        Me.GroupControlHead.Controls.Add(Me.BtnChangeEffectiveDate)
        Me.GroupControlHead.Controls.Add(Me.BtnCreateNew)
        Me.GroupControlHead.Controls.Add(Me.LabelEffectiveDate)
        Me.GroupControlHead.Controls.Add(Me.MENote)
        Me.GroupControlHead.Controls.Add(Me.LabelControl7)
        Me.GroupControlHead.Controls.Add(Me.PanelControl1)
        Me.GroupControlHead.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControlHead.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlHead.Name = "GroupControlHead"
        Me.GroupControlHead.Size = New System.Drawing.Size(798, 130)
        Me.GroupControlHead.TabIndex = 13
        '
        'TxtYear
        '
        Me.TxtYear.Location = New System.Drawing.Point(94, 14)
        Me.TxtYear.Name = "TxtYear"
        Me.TxtYear.Properties.DisplayFormat.FormatString = "F0"
        Me.TxtYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtYear.Properties.Mask.EditMask = "f0"
        Me.TxtYear.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtYear.Properties.MaxLength = 4
        Me.TxtYear.Size = New System.Drawing.Size(323, 20)
        Me.TxtYear.TabIndex = 23
        '
        'BtnChangeEffectiveDate
        '
        Me.BtnChangeEffectiveDate.Enabled = False
        Me.BtnChangeEffectiveDate.Location = New System.Drawing.Point(262, 252)
        Me.BtnChangeEffectiveDate.Name = "BtnChangeEffectiveDate"
        Me.BtnChangeEffectiveDate.Size = New System.Drawing.Size(75, 23)
        Me.BtnChangeEffectiveDate.TabIndex = 8926
        Me.BtnChangeEffectiveDate.Text = "change"
        '
        'BtnCreateNew
        '
        Me.BtnCreateNew.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnCreateNew.Image = CType(resources.GetObject("BtnCreateNew.Image"), System.Drawing.Image)
        Me.BtnCreateNew.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.BtnCreateNew.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        Me.BtnCreateNew.Location = New System.Drawing.Point(20, 99)
        Me.BtnCreateNew.Name = "BtnCreateNew"
        Me.BtnCreateNew.Size = New System.Drawing.Size(525, 29)
        Me.BtnCreateNew.TabIndex = 8925
        Me.BtnCreateNew.Text = "Create New"
        Me.BtnCreateNew.Visible = False
        '
        'LabelEffectiveDate
        '
        Me.LabelEffectiveDate.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelEffectiveDate.Location = New System.Drawing.Point(36, 17)
        Me.LabelEffectiveDate.Name = "LabelEffectiveDate"
        Me.LabelEffectiveDate.Size = New System.Drawing.Size(22, 13)
        Me.LabelEffectiveDate.TabIndex = 8922
        Me.LabelEffectiveDate.Text = "Year"
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(94, 40)
        Me.MENote.Name = "MENote"
        Me.MENote.Size = New System.Drawing.Size(323, 41)
        Me.MENote.TabIndex = 151
        Me.MENote.TabStop = False
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(36, 42)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl7.TabIndex = 150
        Me.LabelControl7.Text = "Note"
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.TxtType)
        Me.PanelControl1.Controls.Add(Me.LabelControl21)
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Controls.Add(Me.LEReportStatus)
        Me.PanelControl1.Controls.Add(Me.DECreated)
        Me.PanelControl1.Controls.Add(Me.TxtNumber)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl1.Location = New System.Drawing.Point(545, 2)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(251, 126)
        Me.PanelControl1.TabIndex = 4
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(10, 41)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl3.TabIndex = 8927
        Me.LabelControl3.Text = "Type"
        '
        'TxtType
        '
        Me.TxtType.Enabled = False
        Me.TxtType.Location = New System.Drawing.Point(64, 38)
        Me.TxtType.Name = "TxtType"
        Me.TxtType.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtType.Properties.Appearance.Options.UseFont = True
        Me.TxtType.Size = New System.Drawing.Size(172, 20)
        Me.TxtType.TabIndex = 148
        '
        'LabelControl21
        '
        Me.LabelControl21.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl21.Location = New System.Drawing.Point(10, 92)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl21.TabIndex = 144
        Me.LabelControl21.Text = "Status"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(10, 67)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl4.TabIndex = 7
        Me.LabelControl4.Text = "Date"
        '
        'LEReportStatus
        '
        Me.LEReportStatus.Enabled = False
        Me.LEReportStatus.Location = New System.Drawing.Point(64, 89)
        Me.LEReportStatus.Name = "LEReportStatus"
        Me.LEReportStatus.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LEReportStatus.Properties.Appearance.Options.UseFont = True
        Me.LEReportStatus.Properties.Appearance.Options.UseTextOptions = True
        Me.LEReportStatus.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEReportStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEReportStatus.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_report_status", "ID Report Status", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("report_status", "Report Status")})
        Me.LEReportStatus.Properties.NullText = ""
        Me.LEReportStatus.Properties.ShowFooter = False
        Me.LEReportStatus.Size = New System.Drawing.Size(172, 20)
        Me.LEReportStatus.TabIndex = 7
        '
        'DECreated
        '
        Me.DECreated.EditValue = Nothing
        Me.DECreated.Enabled = False
        Me.DECreated.Location = New System.Drawing.Point(64, 64)
        Me.DECreated.Name = "DECreated"
        Me.DECreated.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DECreated.Properties.Appearance.Options.UseFont = True
        Me.DECreated.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DECreated.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DECreated.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DECreated.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DECreated.Size = New System.Drawing.Size(172, 20)
        Me.DECreated.TabIndex = 6
        '
        'TxtNumber
        '
        Me.TxtNumber.Enabled = False
        Me.TxtNumber.Location = New System.Drawing.Point(64, 12)
        Me.TxtNumber.Name = "TxtNumber"
        Me.TxtNumber.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumber.Properties.Appearance.Options.UseFont = True
        Me.TxtNumber.Size = New System.Drawing.Size(172, 20)
        Me.TxtNumber.TabIndex = 147
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(10, 15)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl2.TabIndex = 147
        Me.LabelControl2.Text = "Number"
        '
        'PanelControlNav
        '
        Me.PanelControlNav.Controls.Add(Me.PanelControlOptionView)
        Me.PanelControlNav.Controls.Add(Me.BtnDeletePTH)
        Me.PanelControlNav.Controls.Add(Me.BtnAddPTH)
        Me.PanelControlNav.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlNav.Location = New System.Drawing.Point(0, 130)
        Me.PanelControlNav.Name = "PanelControlNav"
        Me.PanelControlNav.Size = New System.Drawing.Size(798, 42)
        Me.PanelControlNav.TabIndex = 21
        '
        'PanelControlOptionView
        '
        Me.PanelControlOptionView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlOptionView.Controls.Add(Me.SLEOptionView)
        Me.PanelControlOptionView.Controls.Add(Me.LabelControl1)
        Me.PanelControlOptionView.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControlOptionView.Location = New System.Drawing.Point(401, 2)
        Me.PanelControlOptionView.Name = "PanelControlOptionView"
        Me.PanelControlOptionView.Size = New System.Drawing.Size(238, 38)
        Me.PanelControlOptionView.TabIndex = 8937
        '
        'SLEOptionView
        '
        Me.SLEOptionView.Location = New System.Drawing.Point(72, 9)
        Me.SLEOptionView.Name = "SLEOptionView"
        Me.SLEOptionView.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEOptionView.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEOptionView.Size = New System.Drawing.Size(160, 20)
        Me.SLEOptionView.TabIndex = 8936
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(9, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(57, 13)
        Me.LabelControl1.TabIndex = 8935
        Me.LabelControl1.Text = "Option View"
        '
        'BtnDeletePTH
        '
        Me.BtnDeletePTH.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDeletePTH.Image = CType(resources.GetObject("BtnDeletePTH.Image"), System.Drawing.Image)
        Me.BtnDeletePTH.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.BtnDeletePTH.Location = New System.Drawing.Point(639, 2)
        Me.BtnDeletePTH.Name = "BtnDeletePTH"
        Me.BtnDeletePTH.Size = New System.Drawing.Size(82, 38)
        Me.BtnDeletePTH.TabIndex = 8934
        Me.BtnDeletePTH.Text = "Delete"
        '
        'BtnAddPTH
        '
        Me.BtnAddPTH.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAddPTH.Image = CType(resources.GetObject("BtnAddPTH.Image"), System.Drawing.Image)
        Me.BtnAddPTH.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.BtnAddPTH.Location = New System.Drawing.Point(721, 2)
        Me.BtnAddPTH.Name = "BtnAddPTH"
        Me.BtnAddPTH.Size = New System.Drawing.Size(75, 38)
        Me.BtnAddPTH.TabIndex = 8933
        Me.BtnAddPTH.Text = "Add"
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
        Me.PanelControlBottom.Location = New System.Drawing.Point(0, 502)
        Me.PanelControlBottom.Name = "PanelControlBottom"
        Me.PanelControlBottom.Size = New System.Drawing.Size(798, 44)
        Me.PanelControlBottom.TabIndex = 22
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(115, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(110, 40)
        Me.BtnPrint.TabIndex = 3
        Me.BtnPrint.Text = "Print (Letter)"
        '
        'BtnAttachment
        '
        Me.BtnAttachment.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAttachment.Image = CType(resources.GetObject("BtnAttachment.Image"), System.Drawing.Image)
        Me.BtnAttachment.Location = New System.Drawing.Point(225, 2)
        Me.BtnAttachment.Name = "BtnAttachment"
        Me.BtnAttachment.Size = New System.Drawing.Size(106, 40)
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
        Me.BtnCancell.Location = New System.Drawing.Point(331, 2)
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
        Me.BtnResetPropose.Location = New System.Drawing.Point(457, 2)
        Me.BtnResetPropose.Name = "BtnResetPropose"
        Me.BtnResetPropose.Size = New System.Drawing.Size(123, 40)
        Me.BtnResetPropose.TabIndex = 9
        Me.BtnResetPropose.Text = "Reset Propose"
        '
        'BtnSaveChanges
        '
        Me.BtnSaveChanges.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSaveChanges.Image = CType(resources.GetObject("BtnSaveChanges.Image"), System.Drawing.Image)
        Me.BtnSaveChanges.Location = New System.Drawing.Point(580, 2)
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
        Me.BtnConfirm.Location = New System.Drawing.Point(700, 2)
        Me.BtnConfirm.Name = "BtnConfirm"
        Me.BtnConfirm.Size = New System.Drawing.Size(96, 40)
        Me.BtnConfirm.TabIndex = 6
        Me.BtnConfirm.Text = "Confirm"
        Me.BtnConfirm.Visible = False
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 172)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(798, 330)
        Me.GCData.TabIndex = 23
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        FormatConditionRuleValue1.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Expression
        FormatConditionRuleValue1.Expression = "Iif([INFO|type_view]=1 And [INFO|id_proposal_type] = 2, True, False)"
        GridFormatRule1.Rule = FormatConditionRuleValue1
        Me.GVData.FormatRules.Add(GridFormatRule1)
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'FormTargetSalesDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 546)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControlBottom)
        Me.Controls.Add(Me.PanelControlNav)
        Me.Controls.Add(Me.GroupControlHead)
        Me.Name = "FormTargetSalesDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Propose Sales Target"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GroupControlHead, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlHead.ResumeLayout(False)
        Me.GroupControlHead.PerformLayout()
        CType(Me.TxtYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.TxtType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DECreated.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DECreated.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNav.ResumeLayout(False)
        CType(Me.PanelControlOptionView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlOptionView.ResumeLayout(False)
        Me.PanelControlOptionView.PerformLayout()
        CType(Me.SLEOptionView.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlBottom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlBottom.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupControlHead As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnChangeEffectiveDate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCreateNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelEffectiveDate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEReportStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents DECreated As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TxtNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControlNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnDeletePTH As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAddPTH As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControlBottom As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAttachment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCancell As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnResetPropose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSaveChanges As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnConfirm As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtYear As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtType As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SLEOptionView As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents PanelControlOptionView As DevExpress.XtraEditors.PanelControl
End Class
