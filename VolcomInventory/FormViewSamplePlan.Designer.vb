<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormViewSamplePlan
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
        Me.BMark = New DevExpress.XtraEditors.SimpleButton
        Me.GroupGeneralFooter = New DevExpress.XtraEditors.GroupControl
        Me.LEReportStatus = New DevExpress.XtraEditors.LookUpEdit
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl
        Me.MENote = New DevExpress.XtraEditors.MemoEdit
        Me.GConListPurchase = New DevExpress.XtraEditors.GroupControl
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.GCListPurchase = New DevExpress.XtraGrid.GridControl
        Me.GVListPurchase = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdSamplePlanDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdSample = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSampleCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSampleName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSampleSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSamplePlanQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.SEQty = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
        Me.ColSamplePlanDetNote = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GroupGeneralHeader = New DevExpress.XtraEditors.GroupControl
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl
        Me.LESeason = New DevExpress.XtraEditors.SearchLookUpEdit
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.TEDate = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.TECompAttn = New DevExpress.XtraEditors.TextEdit
        Me.MECompAddress = New DevExpress.XtraEditors.MemoEdit
        Me.TECompName = New DevExpress.XtraEditors.TextEdit
        Me.TECompCode = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl
        Me.TEPONumber = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.GroupGeneralFooter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneralFooter.SuspendLayout()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GConListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GConListPurchase.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SEQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupGeneralHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneralHeader.SuspendLayout()
        CType(Me.LESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECompAttn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MECompAddress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECompName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECompCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPONumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl3
        '
        Me.GroupControl3.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl3.Controls.Add(Me.BMark)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl3.Location = New System.Drawing.Point(0, 417)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(882, 30)
        Me.GroupControl3.TabIndex = 40
        '
        'BMark
        '
        Me.BMark.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BMark.Location = New System.Drawing.Point(22, 2)
        Me.BMark.Name = "BMark"
        Me.BMark.Size = New System.Drawing.Size(858, 26)
        Me.BMark.TabIndex = 4
        Me.BMark.Text = "Mark"
        '
        'GroupGeneralFooter
        '
        Me.GroupGeneralFooter.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupGeneralFooter.Controls.Add(Me.LEReportStatus)
        Me.GroupGeneralFooter.Controls.Add(Me.LabelControl21)
        Me.GroupGeneralFooter.Controls.Add(Me.LabelControl18)
        Me.GroupGeneralFooter.Controls.Add(Me.MENote)
        Me.GroupGeneralFooter.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupGeneralFooter.Location = New System.Drawing.Point(0, 346)
        Me.GroupGeneralFooter.Name = "GroupGeneralFooter"
        Me.GroupGeneralFooter.Size = New System.Drawing.Size(882, 71)
        Me.GroupGeneralFooter.TabIndex = 39
        '
        'LEReportStatus
        '
        Me.LEReportStatus.Enabled = False
        Me.LEReportStatus.Location = New System.Drawing.Point(570, 9)
        Me.LEReportStatus.Name = "LEReportStatus"
        Me.LEReportStatus.Properties.Appearance.Options.UseTextOptions = True
        Me.LEReportStatus.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEReportStatus.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LEReportStatus.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.LEReportStatus.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.LEReportStatus.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.LEReportStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEReportStatus.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_report_status", "ID Report Status", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("report_status", "Report Status")})
        Me.LEReportStatus.Properties.NullText = ""
        Me.LEReportStatus.Properties.ShowFooter = False
        Me.LEReportStatus.Size = New System.Drawing.Size(299, 20)
        Me.LEReportStatus.TabIndex = 145
        '
        'LabelControl21
        '
        Me.LabelControl21.Location = New System.Drawing.Point(511, 13)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl21.TabIndex = 144
        Me.LabelControl21.Text = "Status"
        '
        'LabelControl18
        '
        Me.LabelControl18.Location = New System.Drawing.Point(27, 13)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl18.TabIndex = 138
        Me.LabelControl18.Text = "Note"
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(56, 10)
        Me.MENote.Name = "MENote"
        Me.MENote.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.MENote.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.MENote.Properties.MaxLength = 100
        Me.MENote.Properties.ReadOnly = True
        Me.MENote.Size = New System.Drawing.Size(384, 46)
        Me.MENote.TabIndex = 137
        '
        'GConListPurchase
        '
        Me.GConListPurchase.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GConListPurchase.Controls.Add(Me.PanelControl1)
        Me.GConListPurchase.Dock = System.Windows.Forms.DockStyle.Top
        Me.GConListPurchase.Location = New System.Drawing.Point(0, 122)
        Me.GConListPurchase.Name = "GConListPurchase"
        Me.GConListPurchase.Size = New System.Drawing.Size(882, 224)
        Me.GConListPurchase.TabIndex = 38
        Me.GConListPurchase.Text = "List Sample"
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.GCListPurchase)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(22, 2)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(858, 220)
        Me.PanelControl1.TabIndex = 19
        '
        'GCListPurchase
        '
        Me.GCListPurchase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListPurchase.Location = New System.Drawing.Point(0, 0)
        Me.GCListPurchase.MainView = Me.GVListPurchase
        Me.GCListPurchase.Name = "GCListPurchase"
        Me.GCListPurchase.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.SEQty})
        Me.GCListPurchase.Size = New System.Drawing.Size(858, 220)
        Me.GCListPurchase.TabIndex = 0
        Me.GCListPurchase.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListPurchase})
        '
        'GVListPurchase
        '
        Me.GVListPurchase.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColNo, Me.ColIdSamplePlanDet, Me.ColIdSample, Me.ColSampleCode, Me.ColSampleName, Me.ColSampleSize, Me.ColSamplePlanQty, Me.ColSamplePlanDetNote})
        Me.GVListPurchase.GridControl = Me.GCListPurchase
        Me.GVListPurchase.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.GVListPurchase.Name = "GVListPurchase"
        Me.GVListPurchase.OptionsView.ShowGroupPanel = False
        '
        'ColNo
        '
        Me.ColNo.Caption = "No."
        Me.ColNo.FieldName = "no"
        Me.ColNo.Name = "ColNo"
        Me.ColNo.OptionsColumn.AllowEdit = False
        Me.ColNo.Visible = True
        Me.ColNo.VisibleIndex = 0
        Me.ColNo.Width = 50
        '
        'ColIdSamplePlanDet
        '
        Me.ColIdSamplePlanDet.Caption = "Id Sample Plan Det"
        Me.ColIdSamplePlanDet.FieldName = "id_sample_plan_det"
        Me.ColIdSamplePlanDet.Name = "ColIdSamplePlanDet"
        Me.ColIdSamplePlanDet.OptionsColumn.AllowEdit = False
        '
        'ColIdSample
        '
        Me.ColIdSample.Caption = "Id Sample"
        Me.ColIdSample.FieldName = "id_sample"
        Me.ColIdSample.Name = "ColIdSample"
        Me.ColIdSample.OptionsColumn.AllowEdit = False
        '
        'ColSampleCode
        '
        Me.ColSampleCode.Caption = "Code"
        Me.ColSampleCode.FieldName = "code"
        Me.ColSampleCode.Name = "ColSampleCode"
        Me.ColSampleCode.OptionsColumn.AllowEdit = False
        Me.ColSampleCode.Visible = True
        Me.ColSampleCode.VisibleIndex = 1
        Me.ColSampleCode.Width = 150
        '
        'ColSampleName
        '
        Me.ColSampleName.Caption = "Name"
        Me.ColSampleName.FieldName = "name"
        Me.ColSampleName.Name = "ColSampleName"
        Me.ColSampleName.OptionsColumn.AllowEdit = False
        Me.ColSampleName.Visible = True
        Me.ColSampleName.VisibleIndex = 2
        Me.ColSampleName.Width = 192
        '
        'ColSampleSize
        '
        Me.ColSampleSize.AppearanceCell.Options.UseTextOptions = True
        Me.ColSampleSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColSampleSize.AppearanceHeader.Options.UseTextOptions = True
        Me.ColSampleSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColSampleSize.Caption = "Size"
        Me.ColSampleSize.FieldName = "size"
        Me.ColSampleSize.Name = "ColSampleSize"
        Me.ColSampleSize.OptionsColumn.AllowEdit = False
        Me.ColSampleSize.Visible = True
        Me.ColSampleSize.VisibleIndex = 3
        Me.ColSampleSize.Width = 100
        '
        'ColSamplePlanQty
        '
        Me.ColSamplePlanQty.AppearanceCell.Options.UseTextOptions = True
        Me.ColSamplePlanQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColSamplePlanQty.AppearanceHeader.Options.UseTextOptions = True
        Me.ColSamplePlanQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColSamplePlanQty.Caption = "Qty"
        Me.ColSamplePlanQty.ColumnEdit = Me.SEQty
        Me.ColSamplePlanQty.FieldName = "qty"
        Me.ColSamplePlanQty.Name = "ColSamplePlanQty"
        Me.ColSamplePlanQty.Visible = True
        Me.ColSamplePlanQty.VisibleIndex = 4
        Me.ColSamplePlanQty.Width = 100
        '
        'SEQty
        '
        Me.SEQty.AutoHeight = False
        Me.SEQty.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.SEQty.Mask.EditMask = "f0"
        Me.SEQty.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.SEQty.Name = "SEQty"
        '
        'ColSamplePlanDetNote
        '
        Me.ColSamplePlanDetNote.Caption = "Note"
        Me.ColSamplePlanDetNote.FieldName = "sample_plan_det_note"
        Me.ColSamplePlanDetNote.Name = "ColSamplePlanDetNote"
        Me.ColSamplePlanDetNote.Visible = True
        Me.ColSamplePlanDetNote.VisibleIndex = 5
        Me.ColSamplePlanDetNote.Width = 202
        '
        'GroupGeneralHeader
        '
        Me.GroupGeneralHeader.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl12)
        Me.GroupGeneralHeader.Controls.Add(Me.LESeason)
        Me.GroupGeneralHeader.Controls.Add(Me.TEDate)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl6)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl5)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl2)
        Me.GroupGeneralHeader.Controls.Add(Me.TECompAttn)
        Me.GroupGeneralHeader.Controls.Add(Me.MECompAddress)
        Me.GroupGeneralHeader.Controls.Add(Me.TECompName)
        Me.GroupGeneralHeader.Controls.Add(Me.TECompCode)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl4)
        Me.GroupGeneralHeader.Controls.Add(Me.TEPONumber)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl3)
        Me.GroupGeneralHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupGeneralHeader.Location = New System.Drawing.Point(0, 0)
        Me.GroupGeneralHeader.Name = "GroupGeneralHeader"
        Me.GroupGeneralHeader.Size = New System.Drawing.Size(882, 122)
        Me.GroupGeneralHeader.TabIndex = 37
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(467, 42)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl12.TabIndex = 139
        Me.LabelControl12.Text = "Season"
        '
        'LESeason
        '
        Me.LESeason.Location = New System.Drawing.Point(570, 39)
        Me.LESeason.Name = "LESeason"
        Me.LESeason.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LESeason.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.LESeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LESeason.Properties.NullText = ""
        Me.LESeason.Properties.ReadOnly = True
        Me.LESeason.Properties.ShowFooter = False
        Me.LESeason.Properties.View = Me.GridView2
        Me.LESeason.Size = New System.Drawing.Size(299, 20)
        Me.LESeason.TabIndex = 7
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn4})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Id Season"
        Me.GridColumn3.FieldName = "id_season_orign"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Season"
        Me.GridColumn4.FieldName = "season_orign"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 0
        '
        'TEDate
        '
        Me.TEDate.EditValue = ""
        Me.TEDate.Location = New System.Drawing.Point(570, 70)
        Me.TEDate.Name = "TEDate"
        Me.TEDate.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TEDate.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TEDate.Properties.EditValueChangedDelay = 1
        Me.TEDate.Properties.ReadOnly = True
        Me.TEDate.Size = New System.Drawing.Size(299, 20)
        Me.TEDate.TabIndex = 0
        Me.TEDate.TabStop = False
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(467, 73)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl6.TabIndex = 124
        Me.LabelControl6.Text = "Date"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(25, 63)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl5.TabIndex = 123
        Me.LabelControl5.Text = "Address"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(25, 38)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(25, 13)
        Me.LabelControl2.TabIndex = 122
        Me.LabelControl2.Text = "Attn."
        '
        'TECompAttn
        '
        Me.TECompAttn.EditValue = ""
        Me.TECompAttn.Location = New System.Drawing.Point(72, 35)
        Me.TECompAttn.Name = "TECompAttn"
        Me.TECompAttn.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TECompAttn.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TECompAttn.Properties.EditValueChangedDelay = 1
        Me.TECompAttn.Properties.ReadOnly = True
        Me.TECompAttn.Size = New System.Drawing.Size(368, 20)
        Me.TECompAttn.TabIndex = 0
        Me.TECompAttn.TabStop = False
        '
        'MECompAddress
        '
        Me.MECompAddress.Location = New System.Drawing.Point(72, 61)
        Me.MECompAddress.Name = "MECompAddress"
        Me.MECompAddress.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.MECompAddress.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.MECompAddress.Properties.MaxLength = 100
        Me.MECompAddress.Properties.ReadOnly = True
        Me.MECompAddress.Size = New System.Drawing.Size(368, 41)
        Me.MECompAddress.TabIndex = 0
        Me.MECompAddress.TabStop = False
        '
        'TECompName
        '
        Me.TECompName.EditValue = ""
        Me.TECompName.Location = New System.Drawing.Point(151, 9)
        Me.TECompName.Name = "TECompName"
        Me.TECompName.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TECompName.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TECompName.Properties.EditValueChangedDelay = 1
        Me.TECompName.Properties.ReadOnly = True
        Me.TECompName.Size = New System.Drawing.Size(289, 20)
        Me.TECompName.TabIndex = 0
        Me.TECompName.TabStop = False
        '
        'TECompCode
        '
        Me.TECompCode.EditValue = ""
        Me.TECompCode.Location = New System.Drawing.Point(72, 9)
        Me.TECompCode.Name = "TECompCode"
        Me.TECompCode.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TECompCode.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TECompCode.Properties.EditValueChangedDelay = 1
        Me.TECompCode.Properties.ReadOnly = True
        Me.TECompCode.Size = New System.Drawing.Size(73, 20)
        Me.TECompCode.TabIndex = 0
        Me.TECompCode.TabStop = False
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(25, 12)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(12, 13)
        Me.LabelControl4.TabIndex = 88
        Me.LabelControl4.Text = "To"
        '
        'TEPONumber
        '
        Me.TEPONumber.EditValue = ""
        Me.TEPONumber.Location = New System.Drawing.Point(570, 9)
        Me.TEPONumber.Name = "TEPONumber"
        Me.TEPONumber.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TEPONumber.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TEPONumber.Properties.EditValueChangedDelay = 1
        Me.TEPONumber.Properties.ReadOnly = True
        Me.TEPONumber.Size = New System.Drawing.Size(299, 20)
        Me.TEPONumber.TabIndex = 3
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(467, 12)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(97, 13)
        Me.LabelControl3.TabIndex = 86
        Me.LabelControl3.Text = "Sample Plan Number"
        '
        'FormViewSamplePlan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(882, 447)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.GroupGeneralFooter)
        Me.Controls.Add(Me.GConListPurchase)
        Me.Controls.Add(Me.GroupGeneralHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormViewSamplePlan"
        Me.ShowInTaskbar = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Sample Planning"
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.GroupGeneralFooter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneralFooter.ResumeLayout(False)
        Me.GroupGeneralFooter.PerformLayout()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GConListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GConListPurchase.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SEQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupGeneralHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneralHeader.ResumeLayout(False)
        Me.GroupGeneralHeader.PerformLayout()
        CType(Me.LESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECompAttn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MECompAddress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECompName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECompCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPONumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupGeneralFooter As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LEReportStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents GConListPurchase As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCListPurchase As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListPurchase As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdSamplePlanDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSampleCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSampleName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSampleSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSamplePlanQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SEQty As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents ColSamplePlanDetNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupGeneralHeader As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LESeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TEDate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TECompAttn As DevExpress.XtraEditors.TextEdit
    Friend WithEvents MECompAddress As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents TECompName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TECompCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEPONumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
End Class
