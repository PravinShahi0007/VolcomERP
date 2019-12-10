<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormItemReq
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
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewDetailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewProgressToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDept = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedByName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PCDepartement = New DevExpress.XtraEditors.PanelControl()
        Me.BView = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEDepartement = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCDepartement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCDepartement.SuspendLayout()
        CType(Me.SLEDepartement.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCData
        '
        Me.GCData.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 48)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(759, 480)
        Me.GCData.TabIndex = 0
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewDetailToolStripMenuItem, Me.ViewProgressToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(147, 48)
        '
        'ViewDetailToolStripMenuItem
        '
        Me.ViewDetailToolStripMenuItem.Name = "ViewDetailToolStripMenuItem"
        Me.ViewDetailToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.ViewDetailToolStripMenuItem.Text = "view detail"
        '
        'ViewProgressToolStripMenuItem
        '
        Me.ViewProgressToolStripMenuItem.Name = "ViewProgressToolStripMenuItem"
        Me.ViewProgressToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.ViewProgressToolStripMenuItem.Text = "view progress"
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNumber, Me.GridColumnDept, Me.GridColumnCreatedDate, Me.GridColumnCreatedByName, Me.GridColumnStt})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNumber
        '
        Me.GridColumnNumber.Caption = "Number"
        Me.GridColumnNumber.FieldName = "number"
        Me.GridColumnNumber.Name = "GridColumnNumber"
        Me.GridColumnNumber.Visible = True
        Me.GridColumnNumber.VisibleIndex = 0
        '
        'GridColumnDept
        '
        Me.GridColumnDept.Caption = "Department"
        Me.GridColumnDept.FieldName = "departement"
        Me.GridColumnDept.Name = "GridColumnDept"
        Me.GridColumnDept.Visible = True
        Me.GridColumnDept.VisibleIndex = 1
        '
        'GridColumnCreatedDate
        '
        Me.GridColumnCreatedDate.Caption = "Created Date"
        Me.GridColumnCreatedDate.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumnCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnCreatedDate.FieldName = "created_date"
        Me.GridColumnCreatedDate.Name = "GridColumnCreatedDate"
        Me.GridColumnCreatedDate.Visible = True
        Me.GridColumnCreatedDate.VisibleIndex = 2
        '
        'GridColumnCreatedByName
        '
        Me.GridColumnCreatedByName.Caption = "Created By"
        Me.GridColumnCreatedByName.FieldName = "created_by_name"
        Me.GridColumnCreatedByName.Name = "GridColumnCreatedByName"
        Me.GridColumnCreatedByName.Visible = True
        Me.GridColumnCreatedByName.VisibleIndex = 3
        '
        'GridColumnStt
        '
        Me.GridColumnStt.Caption = "Status"
        Me.GridColumnStt.FieldName = "report_status"
        Me.GridColumnStt.Name = "GridColumnStt"
        Me.GridColumnStt.Visible = True
        Me.GridColumnStt.VisibleIndex = 4
        '
        'PCDepartement
        '
        Me.PCDepartement.Controls.Add(Me.BView)
        Me.PCDepartement.Controls.Add(Me.SLEDepartement)
        Me.PCDepartement.Controls.Add(Me.LabelControl2)
        Me.PCDepartement.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCDepartement.Location = New System.Drawing.Point(0, 0)
        Me.PCDepartement.Name = "PCDepartement"
        Me.PCDepartement.Size = New System.Drawing.Size(759, 48)
        Me.PCDepartement.TabIndex = 1
        '
        'BView
        '
        Me.BView.Location = New System.Drawing.Point(264, 12)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(96, 23)
        Me.BView.TabIndex = 8913
        Me.BView.Text = "view request"
        '
        'SLEDepartement
        '
        Me.SLEDepartement.Location = New System.Drawing.Point(81, 14)
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
        Me.LabelControl2.Location = New System.Drawing.Point(12, 17)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl2.TabIndex = 8911
        Me.LabelControl2.Text = "Departement"
        '
        'FormItemReq
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 528)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PCDepartement)
        Me.Name = "FormItemReq"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Item Request"
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCDepartement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCDepartement.ResumeLayout(False)
        Me.PCDepartement.PerformLayout()
        CType(Me.SLEDepartement.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDept As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedByName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ViewDetailToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewProgressToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PCDepartement As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLEDepartement As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
End Class
