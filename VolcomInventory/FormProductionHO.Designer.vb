<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProductionHO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProductionHO))
        Me.XTCHO = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPRegisterList = New DevExpress.XtraTab.XtraTabPage()
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.GVList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_pl_prod_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpl_prod_order_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnstep = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpl_category = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal_qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnprod_order_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnvendor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnho_notif_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnho_notif_by_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnis_select = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpl_prod_order_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControlSendEmail = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.CESelAll = New DevExpress.XtraEditors.CheckEdit()
        Me.BtnSendEmail = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControlNav = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControlDate = New DevExpress.XtraEditors.PanelControl()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnViewPending = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPDetail = New DevExpress.XtraTab.XtraTabPage()
        CType(Me.XTCHO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCHO.SuspendLayout()
        Me.XTPRegisterList.SuspendLayout()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlSendEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlSendEmail.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.CESelAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNav.SuspendLayout()
        CType(Me.PanelControlDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlDate.SuspendLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCHO
        '
        Me.XTCHO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCHO.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCHO.Location = New System.Drawing.Point(0, 0)
        Me.XTCHO.Name = "XTCHO"
        Me.XTCHO.SelectedTabPage = Me.XTPRegisterList
        Me.XTCHO.Size = New System.Drawing.Size(810, 500)
        Me.XTCHO.TabIndex = 0
        Me.XTCHO.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPRegisterList, Me.XTPDetail})
        '
        'XTPRegisterList
        '
        Me.XTPRegisterList.Controls.Add(Me.GCList)
        Me.XTPRegisterList.Controls.Add(Me.PanelControlSendEmail)
        Me.XTPRegisterList.Controls.Add(Me.PanelControlNav)
        Me.XTPRegisterList.Name = "XTPRegisterList"
        Me.XTPRegisterList.Size = New System.Drawing.Size(804, 472)
        Me.XTPRegisterList.Text = "Register List"
        '
        'GCList
        '
        Me.GCList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCList.Location = New System.Drawing.Point(0, 43)
        Me.GCList.MainView = Me.GVList
        Me.GCList.Name = "GCList"
        Me.GCList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCList.Size = New System.Drawing.Size(804, 397)
        Me.GCList.TabIndex = 1
        Me.GCList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVList})
        '
        'GVList
        '
        Me.GVList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_pl_prod_order, Me.GridColumncode, Me.GridColumnName, Me.GridColumnpl_prod_order_number, Me.GridColumnstep, Me.GridColumnpl_category, Me.GridColumntotal_qty, Me.GridColumnprod_order_number, Me.GridColumnvendor, Me.GridColumnho_notif_date, Me.GridColumnho_notif_by_name, Me.GridColumnis_select, Me.GridColumnNo, Me.GridColumnpl_prod_order_date})
        Me.GVList.GridControl = Me.GCList
        Me.GVList.Name = "GVList"
        Me.GVList.OptionsFind.AlwaysVisible = True
        Me.GVList.OptionsView.ColumnAutoWidth = False
        Me.GVList.OptionsView.ShowFooter = True
        Me.GVList.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_pl_prod_order
        '
        Me.GridColumnid_pl_prod_order.Caption = "ID PL"
        Me.GridColumnid_pl_prod_order.FieldName = "id_pl_prod_order"
        Me.GridColumnid_pl_prod_order.Name = "GridColumnid_pl_prod_order"
        Me.GridColumnid_pl_prod_order.OptionsColumn.AllowEdit = False
        '
        'GridColumncode
        '
        Me.GridColumncode.Caption = "Design Code"
        Me.GridColumncode.FieldName = "code"
        Me.GridColumncode.Name = "GridColumncode"
        Me.GridColumncode.OptionsColumn.AllowEdit = False
        Me.GridColumncode.Visible = True
        Me.GridColumncode.VisibleIndex = 2
        Me.GridColumncode.Width = 150
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Design"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.OptionsColumn.AllowEdit = False
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 3
        Me.GridColumnName.Width = 150
        '
        'GridColumnpl_prod_order_number
        '
        Me.GridColumnpl_prod_order_number.Caption = "PL Number"
        Me.GridColumnpl_prod_order_number.FieldName = "pl_prod_order_number"
        Me.GridColumnpl_prod_order_number.Name = "GridColumnpl_prod_order_number"
        Me.GridColumnpl_prod_order_number.OptionsColumn.AllowEdit = False
        Me.GridColumnpl_prod_order_number.Visible = True
        Me.GridColumnpl_prod_order_number.VisibleIndex = 4
        Me.GridColumnpl_prod_order_number.Width = 150
        '
        'GridColumnstep
        '
        Me.GridColumnstep.Caption = "Step Handover"
        Me.GridColumnstep.FieldName = "step"
        Me.GridColumnstep.Name = "GridColumnstep"
        Me.GridColumnstep.OptionsColumn.AllowEdit = False
        Me.GridColumnstep.Visible = True
        Me.GridColumnstep.VisibleIndex = 6
        Me.GridColumnstep.Width = 150
        '
        'GridColumnpl_category
        '
        Me.GridColumnpl_category.Caption = "PL Category"
        Me.GridColumnpl_category.FieldName = "pl_category"
        Me.GridColumnpl_category.Name = "GridColumnpl_category"
        Me.GridColumnpl_category.OptionsColumn.AllowEdit = False
        Me.GridColumnpl_category.Visible = True
        Me.GridColumnpl_category.VisibleIndex = 7
        Me.GridColumnpl_category.Width = 150
        '
        'GridColumntotal_qty
        '
        Me.GridColumntotal_qty.Caption = "Total Qty"
        Me.GridColumntotal_qty.DisplayFormat.FormatString = "N0"
        Me.GridColumntotal_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal_qty.FieldName = "total_qty"
        Me.GridColumntotal_qty.Name = "GridColumntotal_qty"
        Me.GridColumntotal_qty.OptionsColumn.AllowEdit = False
        Me.GridColumntotal_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_qty", "{0:N0}")})
        Me.GridColumntotal_qty.Visible = True
        Me.GridColumntotal_qty.VisibleIndex = 8
        Me.GridColumntotal_qty.Width = 150
        '
        'GridColumnprod_order_number
        '
        Me.GridColumnprod_order_number.Caption = "FGPO Number"
        Me.GridColumnprod_order_number.FieldName = "prod_order_number"
        Me.GridColumnprod_order_number.Name = "GridColumnprod_order_number"
        Me.GridColumnprod_order_number.OptionsColumn.AllowEdit = False
        Me.GridColumnprod_order_number.Visible = True
        Me.GridColumnprod_order_number.VisibleIndex = 9
        Me.GridColumnprod_order_number.Width = 150
        '
        'GridColumnvendor
        '
        Me.GridColumnvendor.Caption = "Vendor"
        Me.GridColumnvendor.FieldName = "vendor"
        Me.GridColumnvendor.Name = "GridColumnvendor"
        Me.GridColumnvendor.OptionsColumn.AllowEdit = False
        Me.GridColumnvendor.Visible = True
        Me.GridColumnvendor.VisibleIndex = 10
        Me.GridColumnvendor.Width = 150
        '
        'GridColumnho_notif_date
        '
        Me.GridColumnho_notif_date.Caption = "Notification Sent"
        Me.GridColumnho_notif_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumnho_notif_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnho_notif_date.FieldName = "ho_notif_date"
        Me.GridColumnho_notif_date.Name = "GridColumnho_notif_date"
        Me.GridColumnho_notif_date.OptionsColumn.AllowEdit = False
        Me.GridColumnho_notif_date.Visible = True
        Me.GridColumnho_notif_date.VisibleIndex = 11
        Me.GridColumnho_notif_date.Width = 150
        '
        'GridColumnho_notif_by_name
        '
        Me.GridColumnho_notif_by_name.Caption = "Sent by"
        Me.GridColumnho_notif_by_name.FieldName = "ho_notif_by_name"
        Me.GridColumnho_notif_by_name.Name = "GridColumnho_notif_by_name"
        Me.GridColumnho_notif_by_name.OptionsColumn.AllowEdit = False
        Me.GridColumnho_notif_by_name.Visible = True
        Me.GridColumnho_notif_by_name.VisibleIndex = 12
        Me.GridColumnho_notif_by_name.Width = 158
        '
        'GridColumnis_select
        '
        Me.GridColumnis_select.Caption = "Select"
        Me.GridColumnis_select.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnis_select.FieldName = "is_select"
        Me.GridColumnis_select.Name = "GridColumnis_select"
        Me.GridColumnis_select.Visible = True
        Me.GridColumnis_select.VisibleIndex = 0
        Me.GridColumnis_select.Width = 63
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.OptionsColumn.AllowEdit = False
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 1
        Me.GridColumnNo.Width = 61
        '
        'GridColumnpl_prod_order_date
        '
        Me.GridColumnpl_prod_order_date.Caption = "PL Date"
        Me.GridColumnpl_prod_order_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnpl_prod_order_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnpl_prod_order_date.FieldName = "pl_prod_order_date"
        Me.GridColumnpl_prod_order_date.Name = "GridColumnpl_prod_order_date"
        Me.GridColumnpl_prod_order_date.Visible = True
        Me.GridColumnpl_prod_order_date.VisibleIndex = 5
        '
        'PanelControlSendEmail
        '
        Me.PanelControlSendEmail.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlSendEmail.Controls.Add(Me.PanelControl1)
        Me.PanelControlSendEmail.Controls.Add(Me.BtnSendEmail)
        Me.PanelControlSendEmail.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControlSendEmail.Location = New System.Drawing.Point(0, 440)
        Me.PanelControlSendEmail.Name = "PanelControlSendEmail"
        Me.PanelControlSendEmail.Size = New System.Drawing.Size(804, 32)
        Me.PanelControlSendEmail.TabIndex = 140
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.CESelAll)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(99, 32)
        Me.PanelControl1.TabIndex = 141
        '
        'CESelAll
        '
        Me.CESelAll.Location = New System.Drawing.Point(4, 6)
        Me.CESelAll.Name = "CESelAll"
        Me.CESelAll.Properties.Caption = "Select All"
        Me.CESelAll.Size = New System.Drawing.Size(75, 19)
        Me.CESelAll.TabIndex = 140
        '
        'BtnSendEmail
        '
        Me.BtnSendEmail.Appearance.BackColor = System.Drawing.SystemColors.Highlight
        Me.BtnSendEmail.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSendEmail.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnSendEmail.Appearance.Options.UseBackColor = True
        Me.BtnSendEmail.Appearance.Options.UseFont = True
        Me.BtnSendEmail.Appearance.Options.UseForeColor = True
        Me.BtnSendEmail.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSendEmail.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.BtnSendEmail.Location = New System.Drawing.Point(643, 0)
        Me.BtnSendEmail.LookAndFeel.SkinName = "Metropolis"
        Me.BtnSendEmail.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnSendEmail.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnSendEmail.Name = "BtnSendEmail"
        Me.BtnSendEmail.Size = New System.Drawing.Size(161, 32)
        Me.BtnSendEmail.TabIndex = 139
        Me.BtnSendEmail.Text = "Send Notification Email"
        '
        'PanelControlNav
        '
        Me.PanelControlNav.Controls.Add(Me.PanelControlDate)
        Me.PanelControlNav.Controls.Add(Me.BtnView)
        Me.PanelControlNav.Controls.Add(Me.BtnViewPending)
        Me.PanelControlNav.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlNav.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlNav.Name = "PanelControlNav"
        Me.PanelControlNav.Size = New System.Drawing.Size(804, 43)
        Me.PanelControlNav.TabIndex = 0
        '
        'PanelControlDate
        '
        Me.PanelControlDate.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlDate.Controls.Add(Me.DEUntil)
        Me.PanelControlDate.Controls.Add(Me.DEFrom)
        Me.PanelControlDate.Controls.Add(Me.LabelControl2)
        Me.PanelControlDate.Controls.Add(Me.LabelControl3)
        Me.PanelControlDate.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControlDate.Location = New System.Drawing.Point(245, 2)
        Me.PanelControlDate.Name = "PanelControlDate"
        Me.PanelControlDate.Size = New System.Drawing.Size(299, 39)
        Me.PanelControlDate.TabIndex = 2
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(181, 9)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntil.Size = New System.Drawing.Size(111, 20)
        Me.DEUntil.TabIndex = 8899
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(37, 9)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFrom.Size = New System.Drawing.Size(111, 20)
        Me.DEFrom.TabIndex = 8898
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(154, 12)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl2.TabIndex = 8897
        Me.LabelControl2.Text = "Until"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(7, 12)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl3.TabIndex = 8896
        Me.LabelControl3.Text = "From"
        '
        'BtnView
        '
        Me.BtnView.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnView.Image = CType(resources.GetObject("BtnView.Image"), System.Drawing.Image)
        Me.BtnView.Location = New System.Drawing.Point(544, 2)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(84, 39)
        Me.BtnView.TabIndex = 0
        Me.BtnView.Text = "View"
        '
        'BtnViewPending
        '
        Me.BtnViewPending.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnViewPending.Image = CType(resources.GetObject("BtnViewPending.Image"), System.Drawing.Image)
        Me.BtnViewPending.Location = New System.Drawing.Point(628, 2)
        Me.BtnViewPending.Name = "BtnViewPending"
        Me.BtnViewPending.Size = New System.Drawing.Size(174, 39)
        Me.BtnViewPending.TabIndex = 1
        Me.BtnViewPending.Text = "View Pending Notification"
        '
        'XTPDetail
        '
        Me.XTPDetail.Name = "XTPDetail"
        Me.XTPDetail.Size = New System.Drawing.Size(804, 472)
        Me.XTPDetail.Text = "Detail"
        '
        'FormProductionHO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(810, 500)
        Me.Controls.Add(Me.XTCHO)
        Me.MinimizeBox = False
        Me.Name = "FormProductionHO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Handover Report"
        CType(Me.XTCHO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCHO.ResumeLayout(False)
        Me.XTPRegisterList.ResumeLayout(False)
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlSendEmail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlSendEmail.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.CESelAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNav.ResumeLayout(False)
        CType(Me.PanelControlDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlDate.ResumeLayout(False)
        Me.PanelControlDate.PerformLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCHO As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPRegisterList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPDetail As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControlNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControlDate As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnViewPending As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumnid_pl_prod_order As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpl_prod_order_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnstep As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpl_category As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal_qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnprod_order_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnvendor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnho_notif_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnho_notif_by_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnis_select As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpl_prod_order_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnSendEmail As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControlSendEmail As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CESelAll As DevExpress.XtraEditors.CheckEdit
End Class
