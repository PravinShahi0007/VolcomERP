<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesProbTransHistory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSalesProbTransHistory))
        Me.XTCData = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPriceRecon = New DevExpress.XtraTab.XtraTabPage()
        Me.GCPriceRecon = New DevExpress.XtraGrid.GridControl()
        Me.GVPriceRecon = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.XTPInvoice = New DevExpress.XtraTab.XtraTabPage()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.GridColumnid_sales_pos_recon = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_report_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnreport_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnis_confirm = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BtnViewPriceRecon = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCData.SuspendLayout()
        Me.XTPPriceRecon.SuspendLayout()
        CType(Me.GCPriceRecon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPriceRecon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.XTPInvoice.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCData
        '
        Me.XTCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCData.Location = New System.Drawing.Point(0, 0)
        Me.XTCData.Name = "XTCData"
        Me.XTCData.SelectedTabPage = Me.XTPPriceRecon
        Me.XTCData.Size = New System.Drawing.Size(657, 348)
        Me.XTCData.TabIndex = 0
        Me.XTCData.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPriceRecon, Me.XTPInvoice})
        '
        'XTPPriceRecon
        '
        Me.XTPPriceRecon.Controls.Add(Me.GCPriceRecon)
        Me.XTPPriceRecon.Controls.Add(Me.PanelControl1)
        Me.XTPPriceRecon.Name = "XTPPriceRecon"
        Me.XTPPriceRecon.Size = New System.Drawing.Size(651, 320)
        Me.XTPPriceRecon.Text = "Price Reconcile"
        '
        'GCPriceRecon
        '
        Me.GCPriceRecon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPriceRecon.Location = New System.Drawing.Point(0, 43)
        Me.GCPriceRecon.MainView = Me.GVPriceRecon
        Me.GCPriceRecon.Name = "GCPriceRecon"
        Me.GCPriceRecon.Size = New System.Drawing.Size(651, 277)
        Me.GCPriceRecon.TabIndex = 1
        Me.GCPriceRecon.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPriceRecon})
        '
        'GVPriceRecon
        '
        Me.GVPriceRecon.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_sales_pos_recon, Me.GridColumnnumber, Me.GridColumncreated_date, Me.GridColumnnote, Me.GridColumnid_report_status, Me.GridColumnreport_status, Me.GridColumnis_confirm})
        Me.GVPriceRecon.GridControl = Me.GCPriceRecon
        Me.GVPriceRecon.Name = "GVPriceRecon"
        Me.GVPriceRecon.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVPriceRecon.OptionsBehavior.ReadOnly = True
        Me.GVPriceRecon.OptionsFind.AlwaysVisible = True
        Me.GVPriceRecon.OptionsView.ColumnAutoWidth = False
        Me.GVPriceRecon.OptionsView.ShowFooter = True
        Me.GVPriceRecon.OptionsView.ShowGroupPanel = False
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnViewPriceRecon)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(651, 43)
        Me.PanelControl1.TabIndex = 0
        '
        'XTPInvoice
        '
        Me.XTPInvoice.Controls.Add(Me.PanelControl2)
        Me.XTPInvoice.Name = "XTPInvoice"
        Me.XTPInvoice.Size = New System.Drawing.Size(651, 320)
        Me.XTPInvoice.Text = "Sales Invoice"
        '
        'PanelControl2
        '
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(651, 43)
        Me.PanelControl2.TabIndex = 1
        '
        'GridColumnid_sales_pos_recon
        '
        Me.GridColumnid_sales_pos_recon.Caption = "id_sales_pos_recon"
        Me.GridColumnid_sales_pos_recon.FieldName = "id_sales_pos_recon"
        Me.GridColumnid_sales_pos_recon.Name = "GridColumnid_sales_pos_recon"
        '
        'GridColumnnumber
        '
        Me.GridColumnnumber.Caption = "Number"
        Me.GridColumnnumber.FieldName = "number"
        Me.GridColumnnumber.Name = "GridColumnnumber"
        Me.GridColumnnumber.Visible = True
        Me.GridColumnnumber.VisibleIndex = 0
        '
        'GridColumncreated_date
        '
        Me.GridColumncreated_date.Caption = "Created Date"
        Me.GridColumncreated_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GridColumncreated_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumncreated_date.FieldName = "created_date"
        Me.GridColumncreated_date.Name = "GridColumncreated_date"
        Me.GridColumncreated_date.Visible = True
        Me.GridColumncreated_date.VisibleIndex = 1
        '
        'GridColumnnote
        '
        Me.GridColumnnote.Caption = "Note"
        Me.GridColumnnote.FieldName = "note"
        Me.GridColumnnote.Name = "GridColumnnote"
        '
        'GridColumnid_report_status
        '
        Me.GridColumnid_report_status.Caption = "id_report_status"
        Me.GridColumnid_report_status.FieldName = "id_report_status"
        Me.GridColumnid_report_status.Name = "GridColumnid_report_status"
        '
        'GridColumnreport_status
        '
        Me.GridColumnreport_status.Caption = "Status"
        Me.GridColumnreport_status.FieldName = "report_status"
        Me.GridColumnreport_status.Name = "GridColumnreport_status"
        Me.GridColumnreport_status.Visible = True
        Me.GridColumnreport_status.VisibleIndex = 2
        '
        'GridColumnis_confirm
        '
        Me.GridColumnis_confirm.Caption = "is_confirm"
        Me.GridColumnis_confirm.FieldName = "is_confirm"
        Me.GridColumnis_confirm.Name = "GridColumnis_confirm"
        '
        'BtnViewPriceRecon
        '
        Me.BtnViewPriceRecon.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnViewPriceRecon.Image = CType(resources.GetObject("BtnViewPriceRecon.Image"), System.Drawing.Image)
        Me.BtnViewPriceRecon.Location = New System.Drawing.Point(567, 2)
        Me.BtnViewPriceRecon.Name = "BtnViewPriceRecon"
        Me.BtnViewPriceRecon.Size = New System.Drawing.Size(82, 39)
        Me.BtnViewPriceRecon.TabIndex = 0
        Me.BtnViewPriceRecon.Text = "View"
        '
        'FormSalesProbTransHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 348)
        Me.Controls.Add(Me.XTCData)
        Me.MinimizeBox = False
        Me.Name = "FormSalesProbTransHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transaction History"
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCData.ResumeLayout(False)
        Me.XTPPriceRecon.ResumeLayout(False)
        CType(Me.GCPriceRecon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPriceRecon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.XTPInvoice.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCData As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPriceRecon As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCPriceRecon As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPriceRecon As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents XTPInvoice As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GridColumnid_sales_pos_recon As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_report_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnreport_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnis_confirm As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnViewPriceRecon As DevExpress.XtraEditors.SimpleButton
End Class
