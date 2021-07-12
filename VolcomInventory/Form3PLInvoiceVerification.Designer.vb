<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3PLInvoiceVerification
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3PLInvoiceVerification))
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.BAdd = New DevExpress.XtraEditors.SimpleButton()
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
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.BRefreshOffice = New DevExpress.XtraEditors.SimpleButton()
        Me.BCreateOffice = New DevExpress.XtraEditors.SimpleButton()
        Me.GCInvoiceOffice = New DevExpress.XtraGrid.GridControl()
        Me.GVInvoiceOffice = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GCInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.GCInvoiceOffice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVInvoiceOffice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BRefresh)
        Me.PanelControl2.Controls.Add(Me.BAdd)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1072, 54)
        Me.PanelControl2.TabIndex = 2
        '
        'BRefresh
        '
        Me.BRefresh.Dock = System.Windows.Forms.DockStyle.Left
        Me.BRefresh.Image = CType(resources.GetObject("BRefresh.Image"), System.Drawing.Image)
        Me.BRefresh.Location = New System.Drawing.Point(2, 2)
        Me.BRefresh.Name = "BRefresh"
        Me.BRefresh.Size = New System.Drawing.Size(114, 50)
        Me.BRefresh.TabIndex = 1
        Me.BRefresh.Text = "Refresh"
        '
        'BAdd
        '
        Me.BAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAdd.Image = CType(resources.GetObject("BAdd.Image"), System.Drawing.Image)
        Me.BAdd.Location = New System.Drawing.Point(895, 2)
        Me.BAdd.Name = "BAdd"
        Me.BAdd.Size = New System.Drawing.Size(175, 50)
        Me.BAdd.TabIndex = 0
        Me.BAdd.Text = "Create Verification Report"
        '
        'GCInvoice
        '
        Me.GCInvoice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCInvoice.Location = New System.Drawing.Point(0, 54)
        Me.GCInvoice.MainView = Me.GVInvoice
        Me.GCInvoice.Name = "GCInvoice"
        Me.GCInvoice.Size = New System.Drawing.Size(1072, 448)
        Me.GCInvoice.TabIndex = 3
        Me.GCInvoice.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVInvoice})
        '
        'GVInvoice
        '
        Me.GVInvoice.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn39, Me.GridColumn47, Me.GridColumn40, Me.GridColumn41, Me.GridColumn42, Me.GridColumn43, Me.GridColumn44, Me.GridColumn45, Me.GridColumn1})
        Me.GVInvoice.GridControl = Me.GCInvoice
        Me.GVInvoice.Name = "GVInvoice"
        Me.GVInvoice.OptionsBehavior.Editable = False
        Me.GVInvoice.OptionsBehavior.ReadOnly = True
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
        Me.GridColumn44.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn44.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
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
        Me.GridColumn45.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn45.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn45.Caption = "(Cargo) Total Invoice"
        Me.GridColumn45.DisplayFormat.FormatString = "N2"
        Me.GridColumn45.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn45.FieldName = "a_tot"
        Me.GridColumn45.Name = "GridColumn45"
        Me.GridColumn45.Visible = True
        Me.GridColumn45.VisibleIndex = 6
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn1.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn1.Caption = "(Final) Total Invoice"
        Me.GridColumn1.DisplayFormat.FormatString = "N2"
        Me.GridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn1.FieldName = "final_tot"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 7
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(1078, 530)
        Me.XtraTabControl1.TabIndex = 4
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.GCInvoice)
        Me.XtraTabPage1.Controls.Add(Me.PanelControl2)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(1072, 502)
        Me.XtraTabPage1.Text = "Warehouse"
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.GCInvoiceOffice)
        Me.XtraTabPage2.Controls.Add(Me.PanelControl3)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(1072, 502)
        Me.XtraTabPage2.Text = "Office"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.BRefreshOffice)
        Me.PanelControl3.Controls.Add(Me.BCreateOffice)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(1072, 46)
        Me.PanelControl3.TabIndex = 6
        '
        'BRefreshOffice
        '
        Me.BRefreshOffice.Dock = System.Windows.Forms.DockStyle.Left
        Me.BRefreshOffice.Image = CType(resources.GetObject("BRefreshOffice.Image"), System.Drawing.Image)
        Me.BRefreshOffice.Location = New System.Drawing.Point(2, 2)
        Me.BRefreshOffice.Name = "BRefreshOffice"
        Me.BRefreshOffice.Size = New System.Drawing.Size(114, 42)
        Me.BRefreshOffice.TabIndex = 2
        Me.BRefreshOffice.Text = "Refresh"
        '
        'BCreateOffice
        '
        Me.BCreateOffice.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCreateOffice.Image = CType(resources.GetObject("BCreateOffice.Image"), System.Drawing.Image)
        Me.BCreateOffice.Location = New System.Drawing.Point(895, 2)
        Me.BCreateOffice.Name = "BCreateOffice"
        Me.BCreateOffice.Size = New System.Drawing.Size(175, 42)
        Me.BCreateOffice.TabIndex = 1
        Me.BCreateOffice.Text = "Create Verification Report"
        '
        'GCInvoiceOffice
        '
        Me.GCInvoiceOffice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCInvoiceOffice.Location = New System.Drawing.Point(0, 46)
        Me.GCInvoiceOffice.MainView = Me.GVInvoiceOffice
        Me.GCInvoiceOffice.Name = "GCInvoiceOffice"
        Me.GCInvoiceOffice.Size = New System.Drawing.Size(1072, 456)
        Me.GCInvoiceOffice.TabIndex = 7
        Me.GCInvoiceOffice.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVInvoiceOffice})
        '
        'GVInvoiceOffice
        '
        Me.GVInvoiceOffice.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn23})
        Me.GVInvoiceOffice.GridControl = Me.GCInvoiceOffice
        Me.GVInvoiceOffice.Name = "GVInvoiceOffice"
        Me.GVInvoiceOffice.OptionsBehavior.Editable = False
        Me.GVInvoiceOffice.OptionsBehavior.ReadOnly = True
        Me.GVInvoiceOffice.OptionsView.ShowGroupPanel = False
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "ID Ivn AWB"
        Me.GridColumn2.FieldName = "id_awb_inv_sum"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "3PL"
        Me.GridColumn3.FieldName = "comp_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Invoice Number"
        Me.GridColumn4.FieldName = "inv_number"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 1
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Created By"
        Me.GridColumn5.FieldName = "employee_name"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 2
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Created Date"
        Me.GridColumn6.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn6.FieldName = "created_date"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 3
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Report Status"
        Me.GridColumn7.FieldName = "report_status"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 4
        '
        'GridColumn23
        '
        Me.GridColumn23.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn23.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn23.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn23.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn23.Caption = "Total Invoice"
        Me.GridColumn23.DisplayFormat.FormatString = "N2"
        Me.GridColumn23.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn23.FieldName = "final_tot"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 5
        '
        'Form3PLInvoiceVerification
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1078, 530)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form3PLInvoiceVerification"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Invoice Verification"
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GCInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.GCInvoiceOffice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVInvoiceOffice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BAdd As DevExpress.XtraEditors.SimpleButton
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
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BRefreshOffice As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BCreateOffice As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCInvoiceOffice As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVInvoiceOffice As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
End Class
