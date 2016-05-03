<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProdDemandCostHist
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
        Me.GCLogCost = New DevExpress.XtraGrid.GridControl
        Me.GVLogCost = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnCost = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnEmpName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnTime = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnRate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.GCLogCost, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVLogCost, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCLogCost
        '
        Me.GCLogCost.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCLogCost.Location = New System.Drawing.Point(0, 0)
        Me.GCLogCost.MainView = Me.GVLogCost
        Me.GCLogCost.Name = "GCLogCost"
        Me.GCLogCost.Size = New System.Drawing.Size(619, 401)
        Me.GCLogCost.TabIndex = 1
        Me.GCLogCost.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVLogCost})
        '
        'GVLogCost
        '
        Me.GVLogCost.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnCost, Me.GridColumnEmpName, Me.GridColumnTime, Me.GridColumnRate, Me.GridColumn3})
        Me.GVLogCost.GridControl = Me.GCLogCost
        Me.GVLogCost.Name = "GVLogCost"
        Me.GVLogCost.OptionsBehavior.ReadOnly = True
        Me.GVLogCost.OptionsView.ShowGroupPanel = False
        '
        'GridColumnCost
        '
        Me.GridColumnCost.Caption = "Cost"
        Me.GridColumnCost.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCost.FieldName = "prod_demand_log_cost"
        Me.GridColumnCost.Name = "GridColumnCost"
        Me.GridColumnCost.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnCost.Visible = True
        Me.GridColumnCost.VisibleIndex = 0
        Me.GridColumnCost.Width = 172
        '
        'GridColumnEmpName
        '
        Me.GridColumnEmpName.Caption = "Updated by"
        Me.GridColumnEmpName.FieldName = "employee_name"
        Me.GridColumnEmpName.Name = "GridColumnEmpName"
        Me.GridColumnEmpName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnEmpName.Visible = True
        Me.GridColumnEmpName.VisibleIndex = 3
        Me.GridColumnEmpName.Width = 302
        '
        'GridColumnTime
        '
        Me.GridColumnTime.Caption = "Time"
        Me.GridColumnTime.DisplayFormat.FormatString = "dd MMM yyyy hh:mm tt"
        Me.GridColumnTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnTime.FieldName = "prod_demand_log_cost_time"
        Me.GridColumnTime.Name = "GridColumnTime"
        Me.GridColumnTime.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnTime.Visible = True
        Me.GridColumnTime.VisibleIndex = 4
        Me.GridColumnTime.Width = 414
        '
        'GridColumnRate
        '
        Me.GridColumnRate.Caption = "Rate"
        Me.GridColumnRate.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnRate.FieldName = "prod_demand_log_cost_rate"
        Me.GridColumnRate.Name = "GridColumnRate"
        Me.GridColumnRate.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnRate.Visible = True
        Me.GridColumnRate.VisibleIndex = 2
        Me.GridColumnRate.Width = 162
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Currency Origin"
        Me.GridColumn3.FieldName = "currency"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 90
        '
        'FormProdDemandCostHist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 401)
        Me.Controls.Add(Me.GCLogCost)
        Me.Name = "FormProdDemandCostHist"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estimate Cost History"
        CType(Me.GCLogCost, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVLogCost, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCLogCost As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVLogCost As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnCost As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEmpName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
End Class
