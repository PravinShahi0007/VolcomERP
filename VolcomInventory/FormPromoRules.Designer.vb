<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPromoRules
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
        Me.GCRules = New DevExpress.XtraGrid.GridControl()
        Me.GVRules = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_rules = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_design_cat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndesign_cat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnlimit_value = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_product = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPropose = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPClosed = New DevExpress.XtraTab.XtraTabPage()
        Me.GCClosed = New DevExpress.XtraGrid.GridControl()
        Me.GVClosed = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCRules, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRules, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XTPPropose.SuspendLayout()
        Me.XTPClosed.SuspendLayout()
        CType(Me.GCClosed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVClosed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCRules
        '
        Me.GCRules.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRules.Location = New System.Drawing.Point(0, 0)
        Me.GCRules.MainView = Me.GVRules
        Me.GCRules.Name = "GCRules"
        Me.GCRules.Size = New System.Drawing.Size(778, 533)
        Me.GCRules.TabIndex = 0
        Me.GCRules.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRules})
        '
        'GVRules
        '
        Me.GVRules.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_rules, Me.GridColumnid_design_cat, Me.GridColumndesign_cat, Me.GridColumnlimit_value, Me.GridColumnid_product, Me.GridColumncode, Me.GridColumnname, Me.GridColumnSize, Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4})
        Me.GVRules.GridControl = Me.GCRules
        Me.GVRules.Name = "GVRules"
        Me.GVRules.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVRules.OptionsBehavior.Editable = False
        Me.GVRules.OptionsFind.AlwaysVisible = True
        Me.GVRules.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_rules
        '
        Me.GridColumnid_rules.Caption = "id_rules"
        Me.GridColumnid_rules.FieldName = "id_rules"
        Me.GridColumnid_rules.Name = "GridColumnid_rules"
        '
        'GridColumnid_design_cat
        '
        Me.GridColumnid_design_cat.Caption = "id_design_cat"
        Me.GridColumnid_design_cat.FieldName = "id_design_cat"
        Me.GridColumnid_design_cat.Name = "GridColumnid_design_cat"
        '
        'GridColumndesign_cat
        '
        Me.GridColumndesign_cat.Caption = "Product Status"
        Me.GridColumndesign_cat.FieldName = "design_cat"
        Me.GridColumndesign_cat.Name = "GridColumndesign_cat"
        Me.GridColumndesign_cat.Visible = True
        Me.GridColumndesign_cat.VisibleIndex = 3
        '
        'GridColumnlimit_value
        '
        Me.GridColumnlimit_value.Caption = "Limit Value"
        Me.GridColumnlimit_value.DisplayFormat.FormatString = "N0"
        Me.GridColumnlimit_value.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnlimit_value.FieldName = "limit_value"
        Me.GridColumnlimit_value.Name = "GridColumnlimit_value"
        Me.GridColumnlimit_value.Visible = True
        Me.GridColumnlimit_value.VisibleIndex = 5
        '
        'GridColumnid_product
        '
        Me.GridColumnid_product.Caption = "id_product"
        Me.GridColumnid_product.FieldName = "id_product"
        Me.GridColumnid_product.Name = "GridColumnid_product"
        '
        'GridColumncode
        '
        Me.GridColumncode.Caption = "Code"
        Me.GridColumncode.FieldName = "code"
        Me.GridColumncode.Name = "GridColumncode"
        Me.GridColumncode.Visible = True
        Me.GridColumncode.VisibleIndex = 1
        '
        'GridColumnname
        '
        Me.GridColumnname.Caption = "Style"
        Me.GridColumnname.FieldName = "name"
        Me.GridColumnname.Name = "GridColumnname"
        Me.GridColumnname.Visible = True
        Me.GridColumnname.VisibleIndex = 2
        '
        'GridColumnSize
        '
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 4
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Number"
        Me.GridColumn1.FieldName = "report_number"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Created Date"
        Me.GridColumn2.FieldName = "created_date"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 7
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Created By"
        Me.GridColumn3.FieldName = "created_by"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 8
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Report Status"
        Me.GridColumn4.FieldName = "report_status"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 6
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XTPPropose
        Me.XtraTabControl1.Size = New System.Drawing.Size(784, 561)
        Me.XtraTabControl1.TabIndex = 1
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPropose, Me.XTPClosed})
        '
        'XTPPropose
        '
        Me.XTPPropose.Controls.Add(Me.GCRules)
        Me.XTPPropose.Name = "XTPPropose"
        Me.XTPPropose.Size = New System.Drawing.Size(778, 533)
        Me.XTPPropose.Text = "Propose"
        '
        'XTPClosed
        '
        Me.XTPClosed.Controls.Add(Me.GCClosed)
        Me.XTPClosed.Name = "XTPClosed"
        Me.XTPClosed.Size = New System.Drawing.Size(778, 533)
        Me.XTPClosed.Text = "Closed"
        '
        'GCClosed
        '
        Me.GCClosed.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCClosed.Location = New System.Drawing.Point(0, 0)
        Me.GCClosed.MainView = Me.GVClosed
        Me.GCClosed.Name = "GCClosed"
        Me.GCClosed.Size = New System.Drawing.Size(778, 533)
        Me.GCClosed.TabIndex = 1
        Me.GCClosed.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVClosed})
        '
        'GVClosed
        '
        Me.GVClosed.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn5, Me.GridColumn13, Me.GridColumn8, Me.GridColumn6, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16})
        Me.GVClosed.GridControl = Me.GCClosed
        Me.GVClosed.Name = "GVClosed"
        Me.GVClosed.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVClosed.OptionsBehavior.Editable = False
        Me.GVClosed.OptionsFind.AlwaysVisible = True
        Me.GVClosed.OptionsView.ShowGroupPanel = False
        '
        'GridColumn5
        '
        Me.GridColumn5.FieldName = "id_close_promo_rules"
        Me.GridColumn5.Name = "GridColumn5"
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Number"
        Me.GridColumn13.FieldName = "report_number"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 0
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Proposed Number"
        Me.GridColumn8.FieldName = "proposed_number"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 1
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Store"
        Me.GridColumn6.FieldName = "store"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 2
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Created Date"
        Me.GridColumn14.FieldName = "created_date"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 4
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Created By"
        Me.GridColumn15.FieldName = "created_by"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 5
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Report Status"
        Me.GridColumn16.FieldName = "report_status"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 3
        '
        'FormPromoRules
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Name = "FormPromoRules"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Promo Product Rules"
        CType(Me.GCRules, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRules, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XTPPropose.ResumeLayout(False)
        Me.XTPClosed.ResumeLayout(False)
        CType(Me.GCClosed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVClosed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCRules As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRules As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_rules As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_design_cat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndesign_cat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnlimit_value As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_product As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPropose As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPClosed As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCClosed As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVClosed As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
End Class
