<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormWorkOrder
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BView = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEDepartement = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.GCWorkOrder = New DevExpress.XtraGrid.GridControl()
        Me.GVWorkOrder = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SLEWorkType = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEDepartement.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCWorkOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVWorkOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEWorkType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SLEWorkType)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.BView)
        Me.PanelControl1.Controls.Add(Me.SLEDepartement)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1080, 44)
        Me.PanelControl1.TabIndex = 0
        '
        'BView
        '
        Me.BView.Location = New System.Drawing.Point(505, 11)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(115, 23)
        Me.BView.TabIndex = 8913
        Me.BView.Text = "view work order"
        '
        'SLEDepartement
        '
        Me.SLEDepartement.Location = New System.Drawing.Point(322, 13)
        Me.SLEDepartement.Name = "SLEDepartement"
        Me.SLEDepartement.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEDepartement.Properties.View = Me.GridView2
        Me.SLEDepartement.Size = New System.Drawing.Size(177, 20)
        Me.SLEDepartement.TabIndex = 8912
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn13, Me.GridColumn14})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "ID Departement"
        Me.GridColumn13.FieldName = "id_departement"
        Me.GridColumn13.Name = "GridColumn13"
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Departement"
        Me.GridColumn14.FieldName = "departement"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 0
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(253, 16)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl2.TabIndex = 8911
        Me.LabelControl2.Text = "Departement"
        '
        'GCWorkOrder
        '
        Me.GCWorkOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCWorkOrder.Location = New System.Drawing.Point(0, 44)
        Me.GCWorkOrder.MainView = Me.GVWorkOrder
        Me.GCWorkOrder.Name = "GCWorkOrder"
        Me.GCWorkOrder.Size = New System.Drawing.Size(1080, 531)
        Me.GCWorkOrder.TabIndex = 1
        Me.GCWorkOrder.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVWorkOrder})
        '
        'GVWorkOrder
        '
        Me.GVWorkOrder.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn5, Me.GridColumn2, Me.GridColumn4, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8})
        Me.GVWorkOrder.CustomizationFormBounds = New System.Drawing.Rectangle(1102, 554, 210, 172)
        Me.GVWorkOrder.GridControl = Me.GCWorkOrder
        Me.GVWorkOrder.Name = "GVWorkOrder"
        Me.GVWorkOrder.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Work Type"
        Me.GridColumn5.FieldName = "work_order_type"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "From Departement"
        Me.GridColumn2.FieldName = "departement"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 3
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Note"
        Me.GridColumn4.FieldName = "note"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 4
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Requested By"
        Me.GridColumn6.FieldName = "employee_name"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 2
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Created Date"
        Me.GridColumn7.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn7.FieldName = "created_date"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 1
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Status"
        Me.GridColumn8.FieldName = "report_status"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 5
        '
        'SLEWorkType
        '
        Me.SLEWorkType.Location = New System.Drawing.Point(70, 13)
        Me.SLEWorkType.Name = "SLEWorkType"
        Me.SLEWorkType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEWorkType.Properties.View = Me.GridView1
        Me.SLEWorkType.Size = New System.Drawing.Size(177, 20)
        Me.SLEWorkType.TabIndex = 8915
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn9})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "ID"
        Me.GridColumn3.FieldName = "id_work_order_type"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Work Type"
        Me.GridColumn9.FieldName = "work_order_type"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 16)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(52, 13)
        Me.LabelControl1.TabIndex = 8914
        Me.LabelControl1.Text = "Work Type"
        '
        'FormWorkOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1080, 575)
        Me.Controls.Add(Me.GCWorkOrder)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormWorkOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Work Order"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLEDepartement.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCWorkOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVWorkOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEWorkType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCWorkOrder As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVWorkOrder As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLEDepartement As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEWorkType As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
End Class
