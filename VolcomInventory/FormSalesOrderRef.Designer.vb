<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesOrderRef
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
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.GVList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRef = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndate = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GCList
        '
        Me.GCList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCList.Location = New System.Drawing.Point(0, 0)
        Me.GCList.MainView = Me.GVList
        Me.GCList.Name = "GCList"
        Me.GCList.Size = New System.Drawing.Size(630, 236)
        Me.GCList.TabIndex = 0
        Me.GCList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVList})
        '
        'GVList
        '
        Me.GVList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumnStt, Me.GridColumnRef, Me.GridColumndate})
        Me.GVList.GridControl = Me.GCList
        Me.GVList.Name = "GVList"
        Me.GVList.OptionsBehavior.Editable = False
        Me.GVList.OptionsFind.AlwaysVisible = True
        Me.GVList.OptionsView.ShowGroupPanel = False
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SimpleButton1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 236)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(630, 33)
        Me.PanelControl1.TabIndex = 1
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton1.Location = New System.Drawing.Point(553, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(75, 29)
        Me.SimpleButton1.TabIndex = 0
        Me.SimpleButton1.Text = "Choose"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id Sales Order Gen"
        Me.GridColumn1.FieldName = "id_sales_order_gen"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumnStt
        '
        Me.GridColumnStt.Caption = "Category"
        Me.GridColumnStt.FieldName = "so_status"
        Me.GridColumnStt.Name = "GridColumnStt"
        Me.GridColumnStt.Visible = True
        Me.GridColumnStt.VisibleIndex = 0
        '
        'GridColumnRef
        '
        Me.GridColumnRef.Caption = "Reference"
        Me.GridColumnRef.FieldName = "sales_order_gen_reff"
        Me.GridColumnRef.Name = "GridColumnRef"
        Me.GridColumnRef.Visible = True
        Me.GridColumnRef.VisibleIndex = 1
        '
        'GridColumndate
        '
        Me.GridColumndate.Caption = "Created Date"
        Me.GridColumndate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumndate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumndate.FieldName = "sales_order_gen_date"
        Me.GridColumndate.Name = "GridColumndate"
        Me.GridColumndate.Visible = True
        Me.GridColumndate.VisibleIndex = 2
        '
        'FormSalesOrderRef
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(630, 269)
        Me.Controls.Add(Me.GCList)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormSalesOrderRef"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Prepare Order Reference"
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRef As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndate As DevExpress.XtraGrid.Columns.GridColumn
End Class
