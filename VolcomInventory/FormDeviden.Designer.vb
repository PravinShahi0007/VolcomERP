<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDeviden
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDeviden))
        Me.XTCExpense = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPDeviden = New DevExpress.XtraTab.XtraTabPage()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedByName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReortStt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.XTP3PLInv = New DevExpress.XtraTab.XtraTabPage()
        Me.GCInvoice = New DevExpress.XtraGrid.GridControl()
        Me.GVInvoice = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn39 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn47 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn40 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn41 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn42 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn43 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn44 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn45 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.TEDesc3PLInv = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TEPPH3PLInv = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.TEPPN3PLInv = New DevExpress.XtraEditors.TextEdit()
        Me.SLEPPH3PLInv = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BImport = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.BRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPReport = New DevExpress.XtraTab.XtraTabPage()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.BrefreshSNI = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCExpense, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCExpense.SuspendLayout()
        Me.XTPDeviden.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTP3PLInv.SuspendLayout()
        CType(Me.GCInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.TEDesc3PLInv.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPPH3PLInv.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPPN3PLInv.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEPPH3PLInv.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        Me.XTPReport.SuspendLayout()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        Me.SuspendLayout()
        '
        'XTCExpense
        '
        Me.XTCExpense.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCExpense.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCExpense.Location = New System.Drawing.Point(0, 0)
        Me.XTCExpense.Name = "XTCExpense"
        Me.XTCExpense.SelectedTabPage = Me.XTPDeviden
        Me.XTCExpense.Size = New System.Drawing.Size(947, 495)
        Me.XTCExpense.TabIndex = 3
        Me.XTCExpense.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPDeviden, Me.XTP3PLInv, Me.XTPReport})
        '
        'XTPDeviden
        '
        Me.XTPDeviden.Controls.Add(Me.GCData)
        Me.XTPDeviden.Name = "XTPDeviden"
        Me.XTPDeviden.Size = New System.Drawing.Size(941, 467)
        Me.XTPDeviden.Text = "Deviden List"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1})
        Me.GCData.Size = New System.Drawing.Size(941, 467)
        Me.GCData.TabIndex = 0
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnId, Me.GridColumnNumber, Me.GridColumnCreatedDate, Me.GridColumnCreatedByName, Me.GridColumnReortStt, Me.GridColumn2, Me.GridColumn3, Me.GridColumntotal})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnId
        '
        Me.GridColumnId.Caption = "Id"
        Me.GridColumnId.FieldName = "id_deviden"
        Me.GridColumnId.Name = "GridColumnId"
        '
        'GridColumnNumber
        '
        Me.GridColumnNumber.Caption = "Profit Year"
        Me.GridColumnNumber.FieldName = "profit_year"
        Me.GridColumnNumber.Name = "GridColumnNumber"
        Me.GridColumnNumber.Visible = True
        Me.GridColumnNumber.VisibleIndex = 0
        Me.GridColumnNumber.Width = 83
        '
        'GridColumnCreatedDate
        '
        Me.GridColumnCreatedDate.Caption = "Created Date"
        Me.GridColumnCreatedDate.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumnCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnCreatedDate.FieldName = "created_date"
        Me.GridColumnCreatedDate.Name = "GridColumnCreatedDate"
        Me.GridColumnCreatedDate.Visible = True
        Me.GridColumnCreatedDate.VisibleIndex = 4
        Me.GridColumnCreatedDate.Width = 83
        '
        'GridColumnCreatedByName
        '
        Me.GridColumnCreatedByName.Caption = "Created by"
        Me.GridColumnCreatedByName.FieldName = "employee_name"
        Me.GridColumnCreatedByName.Name = "GridColumnCreatedByName"
        Me.GridColumnCreatedByName.Visible = True
        Me.GridColumnCreatedByName.VisibleIndex = 5
        Me.GridColumnCreatedByName.Width = 83
        '
        'GridColumnReortStt
        '
        Me.GridColumnReortStt.Caption = "Approval Status"
        Me.GridColumnReortStt.FieldName = "report_status"
        Me.GridColumnReortStt.Name = "GridColumnReortStt"
        Me.GridColumnReortStt.Visible = True
        Me.GridColumnReortStt.VisibleIndex = 6
        Me.GridColumnReortStt.Width = 83
        '
        'GridColumntotal
        '
        Me.GridColumntotal.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumntotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumntotal.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumntotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumntotal.Caption = "Deviden Amount"
        Me.GridColumntotal.DisplayFormat.FormatString = "N2"
        Me.GridColumntotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal.FieldName = "deviden_value"
        Me.GridColumntotal.Name = "GridColumntotal"
        Me.GridColumntotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:N2}")})
        Me.GridColumntotal.Visible = True
        Me.GridColumntotal.VisibleIndex = 3
        Me.GridColumntotal.Width = 88
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        Me.RepositoryItemTextEdit1.NullText = "-"
        '
        'XTP3PLInv
        '
        Me.XTP3PLInv.Controls.Add(Me.GCInvoice)
        Me.XTP3PLInv.Controls.Add(Me.PanelControl2)
        Me.XTP3PLInv.Controls.Add(Me.BImport)
        Me.XTP3PLInv.Controls.Add(Me.PanelControl3)
        Me.XTP3PLInv.Name = "XTP3PLInv"
        Me.XTP3PLInv.Size = New System.Drawing.Size(941, 467)
        Me.XTP3PLInv.Text = "-"
        '
        'GCInvoice
        '
        Me.GCInvoice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCInvoice.Location = New System.Drawing.Point(0, 48)
        Me.GCInvoice.MainView = Me.GVInvoice
        Me.GCInvoice.Name = "GCInvoice"
        Me.GCInvoice.Size = New System.Drawing.Size(941, 342)
        Me.GCInvoice.TabIndex = 4
        Me.GCInvoice.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVInvoice})
        '
        'GVInvoice
        '
        Me.GVInvoice.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn39, Me.GridColumn47, Me.GridColumn40, Me.GridColumn41, Me.GridColumn42, Me.GridColumn43, Me.GridColumn44, Me.GridColumn45, Me.GridColumn5})
        Me.GVInvoice.GridControl = Me.GCInvoice
        Me.GVInvoice.Name = "GVInvoice"
        Me.GVInvoice.OptionsBehavior.Editable = False
        Me.GVInvoice.OptionsBehavior.ReadOnly = True
        Me.GVInvoice.OptionsFind.AlwaysVisible = True
        Me.GVInvoice.OptionsView.ShowGroupPanel = False
        '
        'GridColumn39
        '
        Me.GridColumn39.Caption = "ID Ivn AWB"
        Me.GridColumn39.FieldName = "id_awb_inv_sum"
        Me.GridColumn39.Name = "GridColumn39"
        '
        'GridColumn47
        '
        Me.GridColumn47.Caption = "3PL"
        Me.GridColumn47.FieldName = "comp_name"
        Me.GridColumn47.Name = "GridColumn47"
        Me.GridColumn47.Visible = True
        Me.GridColumn47.VisibleIndex = 0
        '
        'GridColumn40
        '
        Me.GridColumn40.Caption = "Invoice Number"
        Me.GridColumn40.FieldName = "inv_number"
        Me.GridColumn40.Name = "GridColumn40"
        Me.GridColumn40.Visible = True
        Me.GridColumn40.VisibleIndex = 1
        '
        'GridColumn41
        '
        Me.GridColumn41.Caption = "Created By"
        Me.GridColumn41.FieldName = "employee_name"
        Me.GridColumn41.Name = "GridColumn41"
        Me.GridColumn41.Visible = True
        Me.GridColumn41.VisibleIndex = 2
        '
        'GridColumn42
        '
        Me.GridColumn42.Caption = "Created Date"
        Me.GridColumn42.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn42.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn42.FieldName = "created_date"
        Me.GridColumn42.Name = "GridColumn42"
        Me.GridColumn42.Visible = True
        Me.GridColumn42.VisibleIndex = 3
        '
        'GridColumn43
        '
        Me.GridColumn43.Caption = "Report Status"
        Me.GridColumn43.FieldName = "report_status"
        Me.GridColumn43.Name = "GridColumn43"
        Me.GridColumn43.Visible = True
        Me.GridColumn43.VisibleIndex = 4
        '
        'GridColumn44
        '
        Me.GridColumn44.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn44.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn44.Caption = "(Volcom) Total Invoice"
        Me.GridColumn44.DisplayFormat.FormatString = "N2"
        Me.GridColumn44.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn44.FieldName = "c_tot"
        Me.GridColumn44.Name = "GridColumn44"
        Me.GridColumn44.Visible = True
        Me.GridColumn44.VisibleIndex = 5
        '
        'GridColumn45
        '
        Me.GridColumn45.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn45.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn45.Caption = "(Cargo) Total Invoice"
        Me.GridColumn45.DisplayFormat.FormatString = "N2"
        Me.GridColumn45.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn45.FieldName = "a_tot"
        Me.GridColumn45.Name = "GridColumn45"
        Me.GridColumn45.Visible = True
        Me.GridColumn45.VisibleIndex = 6
        '
        'GridColumn5
        '
        Me.GridColumn5.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn5.Caption = "(Final) Total Invoice"
        Me.GridColumn5.DisplayFormat.FormatString = "N2"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn5.FieldName = "final_tot"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 7
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.TEDesc3PLInv)
        Me.PanelControl2.Controls.Add(Me.LabelControl4)
        Me.PanelControl2.Controls.Add(Me.LabelControl3)
        Me.PanelControl2.Controls.Add(Me.TEPPH3PLInv)
        Me.PanelControl2.Controls.Add(Me.LabelControl5)
        Me.PanelControl2.Controls.Add(Me.LabelControl6)
        Me.PanelControl2.Controls.Add(Me.TEPPN3PLInv)
        Me.PanelControl2.Controls.Add(Me.SLEPPH3PLInv)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 390)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(941, 43)
        Me.PanelControl2.TabIndex = 92
        Me.PanelControl2.Visible = False
        '
        'TEDesc3PLInv
        '
        Me.TEDesc3PLInv.Location = New System.Drawing.Point(740, 14)
        Me.TEDesc3PLInv.Name = "TEDesc3PLInv"
        Me.TEDesc3PLInv.Size = New System.Drawing.Size(259, 20)
        Me.TEDesc3PLInv.TabIndex = 7
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(681, 17)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl4.TabIndex = 6
        Me.LabelControl4.Text = "Description"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(397, 17)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl3.TabIndex = 5
        Me.LabelControl3.Text = "PPH Account"
        '
        'TEPPH3PLInv
        '
        Me.TEPPH3PLInv.Location = New System.Drawing.Point(248, 14)
        Me.TEPPH3PLInv.Name = "TEPPH3PLInv"
        Me.TEPPH3PLInv.Properties.Mask.EditMask = "N2"
        Me.TEPPH3PLInv.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEPPH3PLInv.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEPPH3PLInv.Size = New System.Drawing.Size(143, 20)
        Me.TEPPH3PLInv.TabIndex = 4
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(201, 17)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl5.TabIndex = 3
        Me.LabelControl5.Text = "PPH (%)"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(11, 17)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl6.TabIndex = 2
        Me.LabelControl6.Text = "PPN (%)"
        '
        'TEPPN3PLInv
        '
        Me.TEPPN3PLInv.Location = New System.Drawing.Point(58, 14)
        Me.TEPPN3PLInv.Name = "TEPPN3PLInv"
        Me.TEPPN3PLInv.Properties.Mask.EditMask = "N2"
        Me.TEPPN3PLInv.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEPPN3PLInv.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEPPN3PLInv.Size = New System.Drawing.Size(137, 20)
        Me.TEPPN3PLInv.TabIndex = 1
        '
        'SLEPPH3PLInv
        '
        Me.SLEPPH3PLInv.Location = New System.Drawing.Point(464, 14)
        Me.SLEPPH3PLInv.Name = "SLEPPH3PLInv"
        Me.SLEPPH3PLInv.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEPPH3PLInv.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEPPH3PLInv.Size = New System.Drawing.Size(211, 20)
        Me.SLEPPH3PLInv.TabIndex = 0
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn6, Me.GridColumn7, Me.GridColumn8})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "id"
        Me.GridColumn6.FieldName = "id_acc"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "ACC"
        Me.GridColumn7.FieldName = "acc_name"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 0
        Me.GridColumn7.Width = 400
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Description"
        Me.GridColumn8.FieldName = "acc_description"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 1
        Me.GridColumn8.Width = 1216
        '
        'BImport
        '
        Me.BImport.Appearance.BackColor = System.Drawing.Color.Blue
        Me.BImport.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BImport.Appearance.ForeColor = System.Drawing.Color.White
        Me.BImport.Appearance.Options.UseBackColor = True
        Me.BImport.Appearance.Options.UseFont = True
        Me.BImport.Appearance.Options.UseForeColor = True
        Me.BImport.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BImport.Location = New System.Drawing.Point(0, 433)
        Me.BImport.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.BImport.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BImport.Name = "BImport"
        Me.BImport.Size = New System.Drawing.Size(941, 34)
        Me.BImport.TabIndex = 91
        Me.BImport.Text = "Generate Expense"
        Me.BImport.Visible = False
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.BRefresh)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(941, 48)
        Me.PanelControl3.TabIndex = 0
        '
        'BRefresh
        '
        Me.BRefresh.Dock = System.Windows.Forms.DockStyle.Right
        Me.BRefresh.Image = CType(resources.GetObject("BRefresh.Image"), System.Drawing.Image)
        Me.BRefresh.Location = New System.Drawing.Point(825, 2)
        Me.BRefresh.Name = "BRefresh"
        Me.BRefresh.Size = New System.Drawing.Size(114, 44)
        Me.BRefresh.TabIndex = 2
        Me.BRefresh.Text = "Refresh"
        '
        'XTPReport
        '
        Me.XTPReport.Controls.Add(Me.PanelControl4)
        Me.XTPReport.Name = "XTPReport"
        Me.XTPReport.Size = New System.Drawing.Size(941, 467)
        Me.XTPReport.Text = "Report"
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.BrefreshSNI)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl4.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(941, 48)
        Me.PanelControl4.TabIndex = 1
        '
        'BrefreshSNI
        '
        Me.BrefreshSNI.Dock = System.Windows.Forms.DockStyle.Right
        Me.BrefreshSNI.Image = CType(resources.GetObject("BrefreshSNI.Image"), System.Drawing.Image)
        Me.BrefreshSNI.Location = New System.Drawing.Point(825, 2)
        Me.BrefreshSNI.Name = "BrefreshSNI"
        Me.BrefreshSNI.Size = New System.Drawing.Size(114, 44)
        Me.BrefreshSNI.TabIndex = 2
        Me.BrefreshSNI.Text = "Refresh"
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn2.Caption = "Total Profit"
        Me.GridColumn2.DisplayFormat.FormatString = "N2"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn2.FieldName = "profit_value"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn3.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn3.Caption = "Deviden (%)"
        Me.GridColumn3.DisplayFormat.FormatString = "{0:N0} %"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn3.FieldName = "profit_percent"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'FormDeviden
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(947, 495)
        Me.Controls.Add(Me.XTCExpense)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormDeviden"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Deviden"
        CType(Me.XTCExpense, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCExpense.ResumeLayout(False)
        Me.XTPDeviden.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTP3PLInv.ResumeLayout(False)
        CType(Me.GCInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.TEDesc3PLInv.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPPH3PLInv.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPPN3PLInv.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEPPH3PLInv.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.XTPReport.ResumeLayout(False)
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XTCExpense As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPDeviden As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedByName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReortStt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents XTP3PLInv As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCInvoice As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVInvoice As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn39 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn47 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn40 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn41 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn42 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn43 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn44 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn45 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TEDesc3PLInv As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEPPH3PLInv As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEPPN3PLInv As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SLEPPH3PLInv As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BImport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XTPReport As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BrefreshSNI As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
End Class
