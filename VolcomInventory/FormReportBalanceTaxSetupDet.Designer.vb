<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReportBalanceTaxSetupDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormReportBalanceTaxSetupDet))
        Me.SBMark = New DevExpress.XtraEditors.SimpleButton()
        Me.SBSubmit = New DevExpress.XtraEditors.SimpleButton()
        Me.TENumber = New DevExpress.XtraEditors.TextEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DEDateTo = New DevExpress.XtraEditors.DateEdit()
        Me.DEDateFrom = New DevExpress.XtraEditors.DateEdit()
        Me.SBGenerateSetupTax = New DevExpress.XtraEditors.SimpleButton()
        Me.TECreatedAt = New DevExpress.XtraEditors.TextEdit()
        Me.TECreatedBy = New DevExpress.XtraEditors.TextEdit()
        Me.SLUEReportStatus = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.SBAttachment = New DevExpress.XtraEditors.SimpleButton()
        Me.SBPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GVSetupTax = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCSetupTax = New DevExpress.XtraGrid.GridControl()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SLUETax = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TETotal = New DevExpress.XtraEditors.TextEdit()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SLUETag = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDateTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDateTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDateFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDateFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECreatedAt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECreatedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLUEReportStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GVSetupTax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCSetupTax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLUETax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TETotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLUETag.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SBMark
        '
        Me.SBMark.Dock = System.Windows.Forms.DockStyle.Left
        Me.SBMark.Image = CType(resources.GetObject("SBMark.Image"), System.Drawing.Image)
        Me.SBMark.Location = New System.Drawing.Point(2, 2)
        Me.SBMark.Name = "SBMark"
        Me.SBMark.Size = New System.Drawing.Size(90, 45)
        Me.SBMark.TabIndex = 2
        Me.SBMark.Text = "Mark"
        '
        'SBSubmit
        '
        Me.SBSubmit.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBSubmit.Image = CType(resources.GetObject("SBSubmit.Image"), System.Drawing.Image)
        Me.SBSubmit.Location = New System.Drawing.Point(692, 2)
        Me.SBSubmit.Name = "SBSubmit"
        Me.SBSubmit.Size = New System.Drawing.Size(90, 45)
        Me.SBSubmit.TabIndex = 0
        Me.SBSubmit.Text = "Submit"
        '
        'TENumber
        '
        Me.TENumber.Location = New System.Drawing.Point(103, 14)
        Me.TENumber.Name = "TENumber"
        Me.TENumber.Properties.ReadOnly = True
        Me.TENumber.Size = New System.Drawing.Size(246, 20)
        Me.TENumber.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Number"
        '
        'DEDateTo
        '
        Me.DEDateTo.EditValue = Nothing
        Me.DEDateTo.Location = New System.Drawing.Point(229, 40)
        Me.DEDateTo.Name = "DEDateTo"
        Me.DEDateTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDateTo.Properties.Mask.EditMask = "MMMM yyyy"
        Me.DEDateTo.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DEDateTo.Size = New System.Drawing.Size(120, 20)
        Me.DEDateTo.TabIndex = 10
        '
        'DEDateFrom
        '
        Me.DEDateFrom.EditValue = Nothing
        Me.DEDateFrom.Location = New System.Drawing.Point(103, 40)
        Me.DEDateFrom.Name = "DEDateFrom"
        Me.DEDateFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDateFrom.Properties.Mask.EditMask = "MMMM yyyy"
        Me.DEDateFrom.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DEDateFrom.Size = New System.Drawing.Size(120, 20)
        Me.DEDateFrom.TabIndex = 9
        '
        'SBGenerateSetupTax
        '
        Me.SBGenerateSetupTax.Location = New System.Drawing.Point(355, 116)
        Me.SBGenerateSetupTax.Name = "SBGenerateSetupTax"
        Me.SBGenerateSetupTax.Size = New System.Drawing.Size(114, 23)
        Me.SBGenerateSetupTax.TabIndex = 8
        Me.SBGenerateSetupTax.Text = "Generate Setup Tax"
        '
        'TECreatedAt
        '
        Me.TECreatedAt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TECreatedAt.Location = New System.Drawing.Point(617, 40)
        Me.TECreatedAt.Name = "TECreatedAt"
        Me.TECreatedAt.Properties.ReadOnly = True
        Me.TECreatedAt.Size = New System.Drawing.Size(150, 20)
        Me.TECreatedAt.TabIndex = 7
        '
        'TECreatedBy
        '
        Me.TECreatedBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TECreatedBy.Location = New System.Drawing.Point(617, 14)
        Me.TECreatedBy.Name = "TECreatedBy"
        Me.TECreatedBy.Properties.ReadOnly = True
        Me.TECreatedBy.Size = New System.Drawing.Size(150, 20)
        Me.TECreatedBy.TabIndex = 6
        '
        'SLUEReportStatus
        '
        Me.SLUEReportStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SLUEReportStatus.Location = New System.Drawing.Point(617, 66)
        Me.SLUEReportStatus.Name = "SLUEReportStatus"
        Me.SLUEReportStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUEReportStatus.Properties.ReadOnly = True
        Me.SLUEReportStatus.Properties.View = Me.GridView1
        Me.SLUEReportStatus.Size = New System.Drawing.Size(150, 20)
        Me.SLUEReportStatus.TabIndex = 5
        '
        'GridView1
        '
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.SBAttachment)
        Me.PanelControl2.Controls.Add(Me.SBMark)
        Me.PanelControl2.Controls.Add(Me.SBPrint)
        Me.PanelControl2.Controls.Add(Me.SBSubmit)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 512)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(784, 49)
        Me.PanelControl2.TabIndex = 5
        '
        'SBAttachment
        '
        Me.SBAttachment.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBAttachment.Image = CType(resources.GetObject("SBAttachment.Image"), System.Drawing.Image)
        Me.SBAttachment.Location = New System.Drawing.Point(483, 2)
        Me.SBAttachment.Name = "SBAttachment"
        Me.SBAttachment.Size = New System.Drawing.Size(119, 45)
        Me.SBAttachment.TabIndex = 3
        Me.SBAttachment.Text = "Attachment"
        '
        'SBPrint
        '
        Me.SBPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBPrint.Image = CType(resources.GetObject("SBPrint.Image"), System.Drawing.Image)
        Me.SBPrint.Location = New System.Drawing.Point(602, 2)
        Me.SBPrint.Name = "SBPrint"
        Me.SBPrint.Size = New System.Drawing.Size(90, 45)
        Me.SBPrint.TabIndex = 1
        Me.SBPrint.Text = "Print"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(537, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Report Status"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Total"
        Me.GridColumn4.DisplayFormat.FormatString = "N2"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn4.FieldName = "total"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:N2}")})
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Bulan"
        Me.GridColumn3.DisplayFormat.FormatString = "MMMM yyyy"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn3.FieldName = "bulan"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(537, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Created At"
        '
        'GVSetupTax
        '
        Me.GVSetupTax.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVSetupTax.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black
        Me.GVSetupTax.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVSetupTax.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVSetupTax.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVSetupTax.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black
        Me.GVSetupTax.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVSetupTax.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVSetupTax.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVSetupTax.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black
        Me.GVSetupTax.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GVSetupTax.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVSetupTax.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVSetupTax.AppearancePrint.GroupRow.Options.UseFont = True
        Me.GVSetupTax.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVSetupTax.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black
        Me.GVSetupTax.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GVSetupTax.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVSetupTax.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.GVSetupTax.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVSetupTax.AppearancePrint.Lines.BackColor = System.Drawing.Color.Black
        Me.GVSetupTax.AppearancePrint.Lines.Options.UseBackColor = True
        Me.GVSetupTax.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.GVSetupTax.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black
        Me.GVSetupTax.AppearancePrint.Row.Options.UseBackColor = True
        Me.GVSetupTax.AppearancePrint.Row.Options.UseBorderColor = True
        Me.GVSetupTax.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn3, Me.GridColumn4})
        Me.GVSetupTax.GridControl = Me.GCSetupTax
        Me.GVSetupTax.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "balance", Me.GridColumn4, "{0:N2}")})
        Me.GVSetupTax.Name = "GVSetupTax"
        Me.GVSetupTax.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVSetupTax.OptionsBehavior.ReadOnly = True
        Me.GVSetupTax.OptionsView.ShowFooter = True
        Me.GVSetupTax.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "No"
        Me.GridColumn1.FieldName = "no"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GCSetupTax
        '
        Me.GCSetupTax.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSetupTax.Location = New System.Drawing.Point(0, 154)
        Me.GCSetupTax.MainView = Me.GVSetupTax
        Me.GCSetupTax.Name = "GCSetupTax"
        Me.GCSetupTax.Size = New System.Drawing.Size(784, 358)
        Me.GCSetupTax.TabIndex = 4
        Me.GCSetupTax.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSetupTax})
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(537, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Created By"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Period"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SLUETag)
        Me.PanelControl1.Controls.Add(Me.Label8)
        Me.PanelControl1.Controls.Add(Me.SLUETax)
        Me.PanelControl1.Controls.Add(Me.Label7)
        Me.PanelControl1.Controls.Add(Me.Label6)
        Me.PanelControl1.Controls.Add(Me.TETotal)
        Me.PanelControl1.Controls.Add(Me.TENumber)
        Me.PanelControl1.Controls.Add(Me.Label5)
        Me.PanelControl1.Controls.Add(Me.DEDateTo)
        Me.PanelControl1.Controls.Add(Me.DEDateFrom)
        Me.PanelControl1.Controls.Add(Me.SBGenerateSetupTax)
        Me.PanelControl1.Controls.Add(Me.TECreatedAt)
        Me.PanelControl1.Controls.Add(Me.TECreatedBy)
        Me.PanelControl1.Controls.Add(Me.SLUEReportStatus)
        Me.PanelControl1.Controls.Add(Me.Label4)
        Me.PanelControl1.Controls.Add(Me.Label3)
        Me.PanelControl1.Controls.Add(Me.Label2)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 154)
        Me.PanelControl1.TabIndex = 3
        '
        'SLUETax
        '
        Me.SLUETax.Location = New System.Drawing.Point(103, 92)
        Me.SLUETax.Name = "SLUETax"
        Me.SLUETax.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUETax.Properties.View = Me.GridView2
        Me.SLUETax.Size = New System.Drawing.Size(246, 20)
        Me.SLUETax.TabIndex = 17
        '
        'GridView2
        '
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 121)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Total"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(25, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Tax"
        '
        'TETotal
        '
        Me.TETotal.Location = New System.Drawing.Point(103, 118)
        Me.TETotal.Name = "TETotal"
        Me.TETotal.Properties.DisplayFormat.FormatString = "N2"
        Me.TETotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TETotal.Properties.EditFormat.FormatString = "N2"
        Me.TETotal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TETotal.Properties.Mask.EditMask = "N2"
        Me.TETotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TETotal.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TETotal.Size = New System.Drawing.Size(246, 20)
        Me.TETotal.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 69)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(25, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Tag"
        '
        'SLUETag
        '
        Me.SLUETag.Location = New System.Drawing.Point(103, 66)
        Me.SLUETag.Name = "SLUETag"
        Me.SLUETag.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUETag.Properties.View = Me.GridView3
        Me.SLUETag.Size = New System.Drawing.Size(246, 20)
        Me.SLUETag.TabIndex = 19
        '
        'GridView3
        '
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'FormReportBalanceTaxSetupDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GCSetupTax)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormReportBalanceTaxSetupDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Setup Tax Detail"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDateTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDateTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDateFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDateFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECreatedAt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECreatedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLUEReportStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GVSetupTax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCSetupTax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLUETax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TETotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLUETag.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SBMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBSubmit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TENumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label5 As Label
    Friend WithEvents DEDateTo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEDateFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents SBGenerateSetupTax As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TECreatedAt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TECreatedBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SLUEReportStatus As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label4 As Label
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label3 As Label
    Friend WithEvents GVSetupTax As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCSetupTax As DevExpress.XtraGrid.GridControl
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLUETax As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TETotal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SBAttachment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLUETag As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label8 As Label
End Class
