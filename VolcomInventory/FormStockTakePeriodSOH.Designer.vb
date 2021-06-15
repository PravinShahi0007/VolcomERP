<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormStockTakePeriodSOH
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormStockTakePeriodSOH))
        Me.CheckEdit1 = New DevExpress.XtraEditors.CheckEdit()
        Me.GCSOH = New DevExpress.XtraGrid.GridControl()
        Me.GVSOH = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICESelect = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.SBSave = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCSOH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSOH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICESelect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'CheckEdit1
        '
        Me.CheckEdit1.Location = New System.Drawing.Point(12, 12)
        Me.CheckEdit1.Name = "CheckEdit1"
        Me.CheckEdit1.Properties.Caption = "Select All"
        Me.CheckEdit1.Size = New System.Drawing.Size(75, 19)
        Me.CheckEdit1.TabIndex = 0
        '
        'GCSOH
        '
        Me.GCSOH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSOH.Location = New System.Drawing.Point(0, 45)
        Me.GCSOH.MainView = Me.GVSOH
        Me.GCSOH.Name = "GCSOH"
        Me.GCSOH.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICESelect})
        Me.GCSOH.Size = New System.Drawing.Size(784, 371)
        Me.GCSOH.TabIndex = 1
        Me.GCSOH.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSOH})
        '
        'GVSOH
        '
        Me.GVSOH.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn6, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn7})
        Me.GVSOH.GridControl = Me.GCSOH
        Me.GVSOH.Name = "GVSOH"
        Me.GVSOH.OptionsView.ShowFooter = True
        Me.GVSOH.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "*"
        Me.GridColumn1.ColumnEdit = Me.RICESelect
        Me.GridColumn1.FieldName = "is_select"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'RICESelect
        '
        Me.RICESelect.AutoHeight = False
        Me.RICESelect.Name = "RICESelect"
        Me.RICESelect.ValueChecked = "yes"
        Me.RICESelect.ValueUnchecked = "no"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "No"
        Me.GridColumn6.FieldName = "no"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.ReadOnly = True
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 1
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Code"
        Me.GridColumn2.FieldName = "product_full_code"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.ReadOnly = True
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 2
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Name"
        Me.GridColumn3.FieldName = "product_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.ReadOnly = True
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 3
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Size"
        Me.GridColumn4.FieldName = "size"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.ReadOnly = True
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 4
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Qty"
        Me.GridColumn5.DisplayFormat.FormatString = "N0"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn5.FieldName = "qty"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.ReadOnly = True
        Me.GridColumn5.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N0}")})
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 5
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "GridColumn7"
        Me.GridColumn7.FieldName = "id_product"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.ReadOnly = True
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.CheckEdit1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 45)
        Me.PanelControl1.TabIndex = 2
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.SBSave)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 416)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(784, 45)
        Me.PanelControl2.TabIndex = 3
        '
        'SBSave
        '
        Me.SBSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBSave.Image = CType(resources.GetObject("SBSave.Image"), System.Drawing.Image)
        Me.SBSave.Location = New System.Drawing.Point(693, 2)
        Me.SBSave.Name = "SBSave"
        Me.SBSave.Size = New System.Drawing.Size(89, 41)
        Me.SBSave.TabIndex = 10
        Me.SBSave.Text = "Select"
        '
        'FormStockTakePeriodSOH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 461)
        Me.Controls.Add(Me.GCSOH)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormStockTakePeriodSOH"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Take Store Period SOH"
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCSOH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSOH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICESelect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CheckEdit1 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GCSOH As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSOH As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICESelect As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
End Class
