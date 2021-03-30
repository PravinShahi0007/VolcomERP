<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPricePolicyCode
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
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_code_detail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnormal_view = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnmkd_30_view = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnmkd_50_view = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnmkd_70_view = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnmkd_fix_view = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(695, 449)
        Me.GCData.TabIndex = 0
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_code_detail, Me.GridColumncode, Me.GridColumndescription, Me.GridColumnnormal_view, Me.GridColumnmkd_30_view, Me.GridColumnmkd_50_view, Me.GridColumnmkd_70_view, Me.GridColumnmkd_fix_view})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_code_detail
        '
        Me.GridColumnid_code_detail.Caption = "id_code_detail"
        Me.GridColumnid_code_detail.FieldName = "id_code_detail"
        Me.GridColumnid_code_detail.Name = "GridColumnid_code_detail"
        '
        'GridColumncode
        '
        Me.GridColumncode.Caption = "Code"
        Me.GridColumncode.FieldName = "code"
        Me.GridColumncode.Name = "GridColumncode"
        Me.GridColumncode.Visible = True
        Me.GridColumncode.VisibleIndex = 0
        '
        'GridColumndescription
        '
        Me.GridColumndescription.Caption = "Description"
        Me.GridColumndescription.FieldName = "description"
        Me.GridColumndescription.Name = "GridColumndescription"
        Me.GridColumndescription.Visible = True
        Me.GridColumndescription.VisibleIndex = 1
        '
        'GridColumnnormal_view
        '
        Me.GridColumnnormal_view.Caption = "Normal"
        Me.GridColumnnormal_view.FieldName = "normal_view"
        Me.GridColumnnormal_view.Name = "GridColumnnormal_view"
        Me.GridColumnnormal_view.Visible = True
        Me.GridColumnnormal_view.VisibleIndex = 2
        '
        'GridColumnmkd_30_view
        '
        Me.GridColumnmkd_30_view.Caption = "Disc. 30%"
        Me.GridColumnmkd_30_view.FieldName = "mkd_30_view"
        Me.GridColumnmkd_30_view.Name = "GridColumnmkd_30_view"
        Me.GridColumnmkd_30_view.Visible = True
        Me.GridColumnmkd_30_view.VisibleIndex = 3
        '
        'GridColumnmkd_50_view
        '
        Me.GridColumnmkd_50_view.Caption = "Disc. 50%"
        Me.GridColumnmkd_50_view.FieldName = "mkd_50_view"
        Me.GridColumnmkd_50_view.Name = "GridColumnmkd_50_view"
        Me.GridColumnmkd_50_view.Visible = True
        Me.GridColumnmkd_50_view.VisibleIndex = 4
        '
        'GridColumnmkd_70_view
        '
        Me.GridColumnmkd_70_view.Caption = "Disc. 70%"
        Me.GridColumnmkd_70_view.FieldName = "mkd_70_view"
        Me.GridColumnmkd_70_view.Name = "GridColumnmkd_70_view"
        Me.GridColumnmkd_70_view.Visible = True
        Me.GridColumnmkd_70_view.VisibleIndex = 5
        '
        'GridColumnmkd_fix_view
        '
        Me.GridColumnmkd_fix_view.Caption = "Disc. Fixed Price"
        Me.GridColumnmkd_fix_view.FieldName = "mkd_fix_view"
        Me.GridColumnmkd_fix_view.Name = "GridColumnmkd_fix_view"
        Me.GridColumnmkd_fix_view.Visible = True
        Me.GridColumnmkd_fix_view.VisibleIndex = 6
        '
        'FormPricePolicyCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(695, 449)
        Me.Controls.Add(Me.GCData)
        Me.Name = "FormPricePolicyCode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Price Policy Code"
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_code_detail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnormal_view As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnmkd_30_view As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnmkd_50_view As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnmkd_70_view As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnmkd_fix_view As DevExpress.XtraGrid.Columns.GridColumn
End Class
