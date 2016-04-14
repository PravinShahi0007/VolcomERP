<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAccountingFYear
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
        Me.GCAcc = New DevExpress.XtraGrid.GridControl
        Me.GVAcc = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.id_acc_fy = New DevExpress.XtraGrid.Columns.GridColumn
        Me.company = New DevExpress.XtraGrid.Columns.GridColumn
        Me.address_primary = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.is_active_company = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        CType(Me.GCAcc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAcc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.is_active_company, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCAcc
        '
        Me.GCAcc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAcc.Location = New System.Drawing.Point(0, 0)
        Me.GCAcc.MainView = Me.GVAcc
        Me.GCAcc.Name = "GCAcc"
        Me.GCAcc.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.is_active_company, Me.RepositoryItemCheckEdit1})
        Me.GCAcc.Size = New System.Drawing.Size(809, 323)
        Me.GCAcc.TabIndex = 5
        Me.GCAcc.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAcc})
        '
        'GVAcc
        '
        Me.GVAcc.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.id_acc_fy, Me.company, Me.address_primary, Me.GridColumn1})
        Me.GVAcc.GridControl = Me.GCAcc
        Me.GVAcc.Name = "GVAcc"
        Me.GVAcc.OptionsBehavior.Editable = False
        Me.GVAcc.OptionsFind.AlwaysVisible = True
        Me.GVAcc.OptionsView.ShowGroupPanel = False
        '
        'id_acc_fy
        '
        Me.id_acc_fy.Caption = "ID"
        Me.id_acc_fy.FieldName = "id_acc"
        Me.id_acc_fy.Name = "id_acc_fy"
        '
        'company
        '
        Me.company.Caption = "Fiscal Year"
        Me.company.FieldName = "acc_fy_name"
        Me.company.Name = "company"
        Me.company.Visible = True
        Me.company.VisibleIndex = 0
        Me.company.Width = 264
        '
        'address_primary
        '
        Me.address_primary.Caption = "Start Date"
        Me.address_primary.FieldName = "acc_fy_start_date"
        Me.address_primary.Name = "address_primary"
        Me.address_primary.Visible = True
        Me.address_primary.VisibleIndex = 1
        Me.address_primary.Width = 174
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "End Date"
        Me.GridColumn1.FieldName = "acc_fy_end_date"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 2
        Me.GridColumn1.Width = 165
        '
        'is_active_company
        '
        Me.is_active_company.AutoHeight = False
        Me.is_active_company.DisplayValueChecked = "1"
        Me.is_active_company.DisplayValueUnchecked = "0"
        Me.is_active_company.Name = "is_active_company"
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RepositoryItemCheckEdit1.ValueGrayed = "0"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'FormAccountingFYear
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 323)
        Me.Controls.Add(Me.GCAcc)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAccountingFYear"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fiscal Year"
        CType(Me.GCAcc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAcc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.is_active_company, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCAcc As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAcc As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents id_acc_fy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents company As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents address_primary As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents is_active_company As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
End Class
