<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProposePriceMKD
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
        Me.components = New System.ComponentModel.Container()
        Me.XTCData = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPSummary = New DevExpress.XtraTab.XtraTabPage()
        Me.GCSummary = New DevExpress.XtraGrid.GridControl()
        Me.GVSummary = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_pp_change = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumneffective_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsoh_sal_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_report_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnreport_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndesign_price_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnemployee_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PriceListForStoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCData.SuspendLayout()
        Me.XTPSummary.SuspendLayout()
        CType(Me.GCSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'XTCData
        '
        Me.XTCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCData.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCData.Location = New System.Drawing.Point(0, 0)
        Me.XTCData.Name = "XTCData"
        Me.XTCData.SelectedTabPage = Me.XTPSummary
        Me.XTCData.Size = New System.Drawing.Size(884, 567)
        Me.XTCData.TabIndex = 0
        Me.XTCData.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPSummary})
        '
        'XTPSummary
        '
        Me.XTPSummary.Controls.Add(Me.GCSummary)
        Me.XTPSummary.Name = "XTPSummary"
        Me.XTPSummary.Size = New System.Drawing.Size(878, 539)
        Me.XTPSummary.Text = "Summary"
        '
        'GCSummary
        '
        Me.GCSummary.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GCSummary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSummary.Location = New System.Drawing.Point(0, 0)
        Me.GCSummary.MainView = Me.GVSummary
        Me.GCSummary.Name = "GCSummary"
        Me.GCSummary.Size = New System.Drawing.Size(878, 539)
        Me.GCSummary.TabIndex = 0
        Me.GCSummary.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSummary})
        '
        'GVSummary
        '
        Me.GVSummary.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_pp_change, Me.GridColumnnumber, Me.GridColumncreated_date, Me.GridColumneffective_date, Me.GridColumnsoh_sal_date, Me.GridColumnnote, Me.GridColumnid_report_status, Me.GridColumnreport_status, Me.GridColumndesign_price_type, Me.GridColumnemployee_name})
        Me.GVSummary.GridControl = Me.GCSummary
        Me.GVSummary.Name = "GVSummary"
        Me.GVSummary.OptionsBehavior.ReadOnly = True
        Me.GVSummary.OptionsFind.AlwaysVisible = True
        Me.GVSummary.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_pp_change
        '
        Me.GridColumnid_pp_change.Caption = "id_pp_change"
        Me.GridColumnid_pp_change.FieldName = "id_pp_change"
        Me.GridColumnid_pp_change.Name = "GridColumnid_pp_change"
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
        'GridColumneffective_date
        '
        Me.GridColumneffective_date.Caption = "Effective Date"
        Me.GridColumneffective_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumneffective_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumneffective_date.FieldName = "effective_date"
        Me.GridColumneffective_date.Name = "GridColumneffective_date"
        Me.GridColumneffective_date.Visible = True
        Me.GridColumneffective_date.VisibleIndex = 3
        '
        'GridColumnsoh_sal_date
        '
        Me.GridColumnsoh_sal_date.Caption = "SOH/SAL Date"
        Me.GridColumnsoh_sal_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnsoh_sal_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsoh_sal_date.FieldName = "soh_sal_date"
        Me.GridColumnsoh_sal_date.Name = "GridColumnsoh_sal_date"
        Me.GridColumnsoh_sal_date.Visible = True
        Me.GridColumnsoh_sal_date.VisibleIndex = 4
        '
        'GridColumnnote
        '
        Me.GridColumnnote.Caption = "Note"
        Me.GridColumnnote.FieldName = "note"
        Me.GridColumnnote.Name = "GridColumnnote"
        Me.GridColumnnote.Visible = True
        Me.GridColumnnote.VisibleIndex = 5
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
        Me.GridColumnreport_status.VisibleIndex = 6
        '
        'GridColumndesign_price_type
        '
        Me.GridColumndesign_price_type.Caption = "Price Type"
        Me.GridColumndesign_price_type.FieldName = "design_price_type"
        Me.GridColumndesign_price_type.Name = "GridColumndesign_price_type"
        Me.GridColumndesign_price_type.Visible = True
        Me.GridColumndesign_price_type.VisibleIndex = 2
        '
        'GridColumnemployee_name
        '
        Me.GridColumnemployee_name.Caption = "Last Approved By"
        Me.GridColumnemployee_name.FieldName = "employee_name"
        Me.GridColumnemployee_name.Name = "GridColumnemployee_name"
        Me.GridColumnemployee_name.Visible = True
        Me.GridColumnemployee_name.VisibleIndex = 7
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PriceListForStoreToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(170, 48)
        '
        'PriceListForStoreToolStripMenuItem
        '
        Me.PriceListForStoreToolStripMenuItem.Name = "PriceListForStoreToolStripMenuItem"
        Me.PriceListForStoreToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.PriceListForStoreToolStripMenuItem.Text = "Price List for Store"
        '
        'FormProposePriceMKD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 567)
        Me.Controls.Add(Me.XTCData)
        Me.MinimizeBox = False
        Me.Name = "FormProposePriceMKD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Proposal Turun Harga"
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCData.ResumeLayout(False)
        Me.XTPSummary.ResumeLayout(False)
        CType(Me.GCSummary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCData As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPSummary As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCSummary As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSummary As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_pp_change As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumneffective_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsoh_sal_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_report_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnreport_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndesign_price_type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnemployee_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents PriceListForStoreToolStripMenuItem As ToolStripMenuItem
End Class
