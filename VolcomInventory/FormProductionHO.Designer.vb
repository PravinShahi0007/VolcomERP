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
        Me.GCDetail = New DevExpress.XtraGrid.GridControl()
        Me.GVDetail = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnDetCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDetDEFromDetail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDetName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetdesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDetsize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetqty_po = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetqty_rec = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDetqty_pl = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetqty_pl_total = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetbalance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetremark = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetpl_prod_order_rec_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetreport_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetprod_order_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetpl_prod_order_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetvendor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetpl_category = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetseason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetdelivery = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetstep = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndetpl_prod_order_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.DEUntilDetail = New DevExpress.XtraEditors.DateEdit()
        Me.DEFromDetail = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnViewDetail = New DevExpress.XtraEditors.SimpleButton()
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
        Me.XTPDetail.SuspendLayout()
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.DEUntilDetail.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilDetail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromDetail.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromDetail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.XTPDetail.Controls.Add(Me.GCDetail)
        Me.XTPDetail.Controls.Add(Me.PanelControl2)
        Me.XTPDetail.Name = "XTPDetail"
        Me.XTPDetail.Size = New System.Drawing.Size(804, 472)
        Me.XTPDetail.Text = "Detail"
        '
        'GCDetail
        '
        Me.GCDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDetail.Location = New System.Drawing.Point(0, 43)
        Me.GCDetail.MainView = Me.GVDetail
        Me.GCDetail.Name = "GCDetail"
        Me.GCDetail.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit2})
        Me.GCDetail.Size = New System.Drawing.Size(804, 429)
        Me.GCDetail.TabIndex = 2
        Me.GCDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDetail})
        '
        'GVDetail
        '
        Me.GVDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnDetCode, Me.GridColumnDetDEFromDetail, Me.GridColumnDetName, Me.GridColumndetdesign, Me.GridColumnDetsize, Me.GridColumndetqty_po, Me.GridColumndetqty_rec, Me.GridColumnDetqty_pl, Me.GridColumndetqty_pl_total, Me.GridColumndetbalance, Me.GridColumndetremark, Me.GridColumndetpl_prod_order_rec_number, Me.GridColumndetreport_status, Me.GridColumndetprod_order_number, Me.GridColumndetpl_prod_order_number, Me.GridColumndetvendor, Me.GridColumndetpl_category, Me.GridColumndetseason, Me.GridColumndetdelivery, Me.GridColumndetstep, Me.GridColumndetpl_prod_order_date})
        Me.GVDetail.GridControl = Me.GCDetail
        Me.GVDetail.GroupCount = 1
        Me.GVDetail.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_po", Me.GridColumndetqty_po, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rec", Me.GridColumndetqty_rec, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_pl", Me.GridColumnDetqty_pl, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_pl_total", Me.GridColumndetqty_pl_total, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "balance", Me.GridColumndetbalance, "{0:N0}")})
        Me.GVDetail.Name = "GVDetail"
        Me.GVDetail.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVDetail.OptionsBehavior.Editable = False
        Me.GVDetail.OptionsFind.AlwaysVisible = True
        Me.GVDetail.OptionsView.ColumnAutoWidth = False
        Me.GVDetail.OptionsView.ShowFooter = True
        Me.GVDetail.OptionsView.ShowGroupedColumns = True
        Me.GVDetail.OptionsView.ShowGroupPanel = False
        Me.GVDetail.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumndetpl_prod_order_number, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnDetCode
        '
        Me.GridColumnDetCode.Caption = "Code"
        Me.GridColumnDetCode.FieldName = "code"
        Me.GridColumnDetCode.Name = "GridColumnDetCode"
        Me.GridColumnDetCode.Visible = True
        Me.GridColumnDetCode.VisibleIndex = 1
        '
        'GridColumnDetDEFromDetail
        '
        Me.GridColumnDetDEFromDetail.Caption = "Barcode"
        Me.GridColumnDetDEFromDetail.FieldName = "barcode"
        Me.GridColumnDetDEFromDetail.Name = "GridColumnDetDEFromDetail"
        Me.GridColumnDetDEFromDetail.Visible = True
        Me.GridColumnDetDEFromDetail.VisibleIndex = 0
        '
        'GridColumnDetName
        '
        Me.GridColumnDetName.Caption = "Design"
        Me.GridColumnDetName.FieldName = "name"
        Me.GridColumnDetName.Name = "GridColumnDetName"
        Me.GridColumnDetName.Visible = True
        Me.GridColumnDetName.VisibleIndex = 2
        '
        'GridColumndetdesign
        '
        Me.GridColumndetdesign.Caption = "Design"
        Me.GridColumndetdesign.FieldName = "design"
        Me.GridColumndetdesign.Name = "GridColumndetdesign"
        Me.GridColumndetdesign.UnboundExpression = "Concat([code], ' - ', [name])"
        Me.GridColumndetdesign.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        '
        'GridColumnDetsize
        '
        Me.GridColumnDetsize.Caption = "Size"
        Me.GridColumnDetsize.FieldName = "size"
        Me.GridColumnDetsize.Name = "GridColumnDetsize"
        Me.GridColumnDetsize.Visible = True
        Me.GridColumnDetsize.VisibleIndex = 3
        '
        'GridColumndetqty_po
        '
        Me.GridColumndetqty_po.Caption = "Order Total"
        Me.GridColumndetqty_po.DisplayFormat.FormatString = "N0"
        Me.GridColumndetqty_po.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumndetqty_po.FieldName = "qty_po"
        Me.GridColumndetqty_po.Name = "GridColumndetqty_po"
        Me.GridColumndetqty_po.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_po", "{0:N0}")})
        Me.GridColumndetqty_po.Visible = True
        Me.GridColumndetqty_po.VisibleIndex = 12
        '
        'GridColumndetqty_rec
        '
        Me.GridColumndetqty_rec.Caption = "Received Total"
        Me.GridColumndetqty_rec.DisplayFormat.FormatString = "N0"
        Me.GridColumndetqty_rec.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumndetqty_rec.FieldName = "qty_rec"
        Me.GridColumndetqty_rec.Name = "GridColumndetqty_rec"
        Me.GridColumndetqty_rec.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rec", "{0:N0}")})
        Me.GridColumndetqty_rec.Visible = True
        Me.GridColumndetqty_rec.VisibleIndex = 13
        Me.GridColumndetqty_rec.Width = 105
        '
        'GridColumnDetqty_pl
        '
        Me.GridColumnDetqty_pl.Caption = "Handover"
        Me.GridColumnDetqty_pl.DisplayFormat.FormatString = "N0"
        Me.GridColumnDetqty_pl.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnDetqty_pl.FieldName = "qty_pl"
        Me.GridColumnDetqty_pl.Name = "GridColumnDetqty_pl"
        Me.GridColumnDetqty_pl.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_pl", "{0:N0}")})
        Me.GridColumnDetqty_pl.Visible = True
        Me.GridColumnDetqty_pl.VisibleIndex = 14
        Me.GridColumnDetqty_pl.Width = 115
        '
        'GridColumndetqty_pl_total
        '
        Me.GridColumndetqty_pl_total.Caption = "Handover Total"
        Me.GridColumndetqty_pl_total.DisplayFormat.FormatString = "N0"
        Me.GridColumndetqty_pl_total.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumndetqty_pl_total.FieldName = "qty_pl_total"
        Me.GridColumndetqty_pl_total.Name = "GridColumndetqty_pl_total"
        Me.GridColumndetqty_pl_total.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_pl_total", "{0:N0}")})
        Me.GridColumndetqty_pl_total.Visible = True
        Me.GridColumndetqty_pl_total.VisibleIndex = 15
        Me.GridColumndetqty_pl_total.Width = 109
        '
        'GridColumndetbalance
        '
        Me.GridColumndetbalance.Caption = "Balance"
        Me.GridColumndetbalance.DisplayFormat.FormatString = "N0"
        Me.GridColumndetbalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumndetbalance.FieldName = "balance"
        Me.GridColumndetbalance.Name = "GridColumndetbalance"
        Me.GridColumndetbalance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "balance", "{0:N0}")})
        Me.GridColumndetbalance.Visible = True
        Me.GridColumndetbalance.VisibleIndex = 16
        Me.GridColumndetbalance.Width = 103
        '
        'GridColumndetremark
        '
        Me.GridColumndetremark.Caption = "Remark"
        Me.GridColumndetremark.FieldName = "remark"
        Me.GridColumndetremark.Name = "GridColumndetremark"
        Me.GridColumndetremark.Visible = True
        Me.GridColumndetremark.VisibleIndex = 17
        '
        'GridColumndetpl_prod_order_rec_number
        '
        Me.GridColumndetpl_prod_order_rec_number.Caption = "Received WH#"
        Me.GridColumndetpl_prod_order_rec_number.FieldName = "pl_prod_order_rec_number"
        Me.GridColumndetpl_prod_order_rec_number.Name = "GridColumndetpl_prod_order_rec_number"
        Me.GridColumndetpl_prod_order_rec_number.Visible = True
        Me.GridColumndetpl_prod_order_rec_number.VisibleIndex = 18
        Me.GridColumndetpl_prod_order_rec_number.Width = 106
        '
        'GridColumndetreport_status
        '
        Me.GridColumndetreport_status.Caption = "Received WH Status"
        Me.GridColumndetreport_status.FieldName = "report_status"
        Me.GridColumndetreport_status.Name = "GridColumndetreport_status"
        Me.GridColumndetreport_status.Visible = True
        Me.GridColumndetreport_status.VisibleIndex = 19
        Me.GridColumndetreport_status.Width = 125
        '
        'GridColumndetprod_order_number
        '
        Me.GridColumndetprod_order_number.Caption = "FG. PO #"
        Me.GridColumndetprod_order_number.FieldName = "prod_order_number"
        Me.GridColumndetprod_order_number.Name = "GridColumndetprod_order_number"
        Me.GridColumndetprod_order_number.Visible = True
        Me.GridColumndetprod_order_number.VisibleIndex = 7
        '
        'GridColumndetpl_prod_order_number
        '
        Me.GridColumndetpl_prod_order_number.Caption = "PL#"
        Me.GridColumndetpl_prod_order_number.FieldName = "pl_prod_order_number"
        Me.GridColumndetpl_prod_order_number.Name = "GridColumndetpl_prod_order_number"
        Me.GridColumndetpl_prod_order_number.Visible = True
        Me.GridColumndetpl_prod_order_number.VisibleIndex = 8
        '
        'GridColumndetvendor
        '
        Me.GridColumndetvendor.Caption = "Vendor"
        Me.GridColumndetvendor.FieldName = "vendor"
        Me.GridColumndetvendor.Name = "GridColumndetvendor"
        Me.GridColumndetvendor.Visible = True
        Me.GridColumndetvendor.VisibleIndex = 6
        '
        'GridColumndetpl_category
        '
        Me.GridColumndetpl_category.Caption = "Handover Category"
        Me.GridColumndetpl_category.FieldName = "pl_category"
        Me.GridColumndetpl_category.Name = "GridColumndetpl_category"
        Me.GridColumndetpl_category.Visible = True
        Me.GridColumndetpl_category.VisibleIndex = 11
        Me.GridColumndetpl_category.Width = 127
        '
        'GridColumndetseason
        '
        Me.GridColumndetseason.Caption = "Season"
        Me.GridColumndetseason.FieldName = "season"
        Me.GridColumndetseason.Name = "GridColumndetseason"
        Me.GridColumndetseason.Visible = True
        Me.GridColumndetseason.VisibleIndex = 4
        '
        'GridColumndetdelivery
        '
        Me.GridColumndetdelivery.Caption = "Del"
        Me.GridColumndetdelivery.FieldName = "delivery"
        Me.GridColumndetdelivery.Name = "GridColumndetdelivery"
        Me.GridColumndetdelivery.Visible = True
        Me.GridColumndetdelivery.VisibleIndex = 5
        '
        'GridColumndetstep
        '
        Me.GridColumndetstep.Caption = "Handover Step"
        Me.GridColumndetstep.FieldName = "step"
        Me.GridColumndetstep.Name = "GridColumndetstep"
        Me.GridColumndetstep.Visible = True
        Me.GridColumndetstep.VisibleIndex = 10
        Me.GridColumndetstep.Width = 111
        '
        'GridColumndetpl_prod_order_date
        '
        Me.GridColumndetpl_prod_order_date.Caption = "Created PL Date"
        Me.GridColumndetpl_prod_order_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumndetpl_prod_order_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumndetpl_prod_order_date.FieldName = "pl_prod_order_date"
        Me.GridColumndetpl_prod_order_date.Name = "GridColumndetpl_prod_order_date"
        Me.GridColumndetpl_prod_order_date.Visible = True
        Me.GridColumndetpl_prod_order_date.VisibleIndex = 9
        Me.GridColumndetpl_prod_order_date.Width = 112
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        Me.RepositoryItemCheckEdit2.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit2.ValueUnchecked = "No"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.PanelControl3)
        Me.PanelControl2.Controls.Add(Me.BtnViewDetail)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(804, 43)
        Me.PanelControl2.TabIndex = 1
        '
        'PanelControl3
        '
        Me.PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl3.Controls.Add(Me.DEUntilDetail)
        Me.PanelControl3.Controls.Add(Me.DEFromDetail)
        Me.PanelControl3.Controls.Add(Me.LabelControl1)
        Me.PanelControl3.Controls.Add(Me.LabelControl4)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl3.Location = New System.Drawing.Point(419, 2)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(299, 39)
        Me.PanelControl3.TabIndex = 2
        '
        'DEUntilDetail
        '
        Me.DEUntilDetail.EditValue = Nothing
        Me.DEUntilDetail.Location = New System.Drawing.Point(181, 9)
        Me.DEUntilDetail.Name = "DEUntilDetail"
        Me.DEUntilDetail.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntilDetail.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntilDetail.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntilDetail.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntilDetail.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntilDetail.Size = New System.Drawing.Size(111, 20)
        Me.DEUntilDetail.TabIndex = 8899
        '
        'DEFromDetail
        '
        Me.DEFromDetail.EditValue = Nothing
        Me.DEFromDetail.Location = New System.Drawing.Point(37, 9)
        Me.DEFromDetail.Name = "DEFromDetail"
        Me.DEFromDetail.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFromDetail.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFromDetail.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFromDetail.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFromDetail.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFromDetail.Size = New System.Drawing.Size(111, 20)
        Me.DEFromDetail.TabIndex = 8898
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(154, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl1.TabIndex = 8897
        Me.LabelControl1.Text = "Until"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(7, 12)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl4.TabIndex = 8896
        Me.LabelControl4.Text = "From"
        '
        'BtnViewDetail
        '
        Me.BtnViewDetail.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnViewDetail.Image = CType(resources.GetObject("BtnViewDetail.Image"), System.Drawing.Image)
        Me.BtnViewDetail.Location = New System.Drawing.Point(718, 2)
        Me.BtnViewDetail.Name = "BtnViewDetail"
        Me.BtnViewDetail.Size = New System.Drawing.Size(84, 39)
        Me.BtnViewDetail.TabIndex = 0
        Me.BtnViewDetail.Text = "View"
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
        Me.XTPDetail.ResumeLayout(False)
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.DEUntilDetail.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilDetail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromDetail.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromDetail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents GCDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DEUntilDetail As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFromDetail As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnViewDetail As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnDetCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDetDEFromDetail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDetName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetdesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDetsize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetqty_po As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetqty_rec As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDetqty_pl As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetqty_pl_total As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetbalance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetremark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetpl_prod_order_rec_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetreport_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetprod_order_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetpl_prod_order_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetvendor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetpl_category As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetseason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetdelivery As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetstep As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndetpl_prod_order_date As DevExpress.XtraGrid.Columns.GridColumn
End Class
