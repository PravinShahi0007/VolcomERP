<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReportBudget
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
        Me.GCItemCat = New DevExpress.XtraGrid.GridControl()
        Me.GVItemCat = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCItemCat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVItemCat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCItemCat
        '
        Me.GCItemCat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCItemCat.Location = New System.Drawing.Point(0, 45)
        Me.GCItemCat.MainView = Me.GVItemCat
        Me.GCItemCat.Name = "GCItemCat"
        Me.GCItemCat.Size = New System.Drawing.Size(1017, 497)
        Me.GCItemCat.TabIndex = 2
        Me.GCItemCat.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVItemCat})
        '
        'GVItemCat
        '
        Me.GVItemCat.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn6, Me.GridColumn7, Me.GridColumn10, Me.GridColumn1, Me.GridColumn2, Me.GridColumn3})
        Me.GVItemCat.GridControl = Me.GCItemCat
        Me.GVItemCat.Name = "GVItemCat"
        Me.GVItemCat.OptionsBehavior.Editable = False
        Me.GVItemCat.OptionsFind.AlwaysVisible = True
        Me.GVItemCat.OptionsView.ShowGroupPanel = False
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Id"
        Me.GridColumn6.FieldName = "id_item_cat_main"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Expense Type"
        Me.GridColumn7.FieldName = "expense_type"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 1
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Main Category"
        Me.GridColumn10.FieldName = "item_cat_main"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 0
        '
        'PanelControl1
        '
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1017, 45)
        Me.PanelControl1.TabIndex = 3
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Budget Value"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 2
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Booked Budget (PO)"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 3
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Used Budget (Receiving)"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 4
        '
        'FormReportBudget
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1017, 542)
        Me.Controls.Add(Me.GCItemCat)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormReportBudget"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Report Budget"
        CType(Me.GCItemCat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVItemCat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCItemCat As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVItemCat As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
End Class
