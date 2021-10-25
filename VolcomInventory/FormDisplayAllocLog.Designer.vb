<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDisplayAllocLog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDisplayAllocLog))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEClass = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEDisplay = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnclass_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndisplay_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnemployee_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnlog_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnlog = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEClass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEDisplay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnPrint)
        Me.PanelControl1.Controls.Add(Me.BtnView)
        Me.PanelControl1.Controls.Add(Me.SLEDisplay)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.SLEClass)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 66)
        Me.PanelControl1.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(16, 11)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(25, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Class"
        '
        'SLEClass
        '
        Me.SLEClass.Location = New System.Drawing.Point(16, 30)
        Me.SLEClass.Name = "SLEClass"
        Me.SLEClass.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEClass.Properties.ShowClearButton = False
        Me.SLEClass.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEClass.Size = New System.Drawing.Size(195, 20)
        Me.SLEClass.TabIndex = 1
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(217, 11)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Display Type"
        '
        'SLEDisplay
        '
        Me.SLEDisplay.Location = New System.Drawing.Point(217, 30)
        Me.SLEDisplay.Name = "SLEDisplay"
        Me.SLEDisplay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEDisplay.Properties.ShowClearButton = False
        Me.SLEDisplay.Properties.View = Me.GridView1
        Me.SLEDisplay.Size = New System.Drawing.Size(195, 20)
        Me.SLEDisplay.TabIndex = 3
        '
        'GridView1
        '
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'BtnView
        '
        Me.BtnView.Image = CType(resources.GetObject("BtnView.Image"), System.Drawing.Image)
        Me.BtnView.Location = New System.Drawing.Point(418, 27)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(62, 23)
        Me.BtnView.TabIndex = 1
        Me.BtnView.Text = "View"
        '
        'BtnPrint
        '
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(486, 27)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(64, 23)
        Me.BtnPrint.TabIndex = 4
        Me.BtnPrint.Text = "Print"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 66)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(784, 295)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnclass_group, Me.GridColumndisplay_type, Me.GridColumnemployee_name, Me.GridColumnlog_date, Me.GridColumnlog})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnclass_group
        '
        Me.GridColumnclass_group.Caption = "Class"
        Me.GridColumnclass_group.FieldName = "class_group"
        Me.GridColumnclass_group.Name = "GridColumnclass_group"
        Me.GridColumnclass_group.Visible = True
        Me.GridColumnclass_group.VisibleIndex = 0
        '
        'GridColumndisplay_type
        '
        Me.GridColumndisplay_type.Caption = "Type"
        Me.GridColumndisplay_type.FieldName = "display_type"
        Me.GridColumndisplay_type.Name = "GridColumndisplay_type"
        Me.GridColumndisplay_type.Visible = True
        Me.GridColumndisplay_type.VisibleIndex = 1
        '
        'GridColumnemployee_name
        '
        Me.GridColumnemployee_name.Caption = "Updated By"
        Me.GridColumnemployee_name.FieldName = "employee_name"
        Me.GridColumnemployee_name.Name = "GridColumnemployee_name"
        Me.GridColumnemployee_name.Visible = True
        Me.GridColumnemployee_name.VisibleIndex = 4
        '
        'GridColumnlog_date
        '
        Me.GridColumnlog_date.Caption = "Updated at"
        Me.GridColumnlog_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GridColumnlog_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnlog_date.FieldName = "log_date"
        Me.GridColumnlog_date.Name = "GridColumnlog_date"
        Me.GridColumnlog_date.Visible = True
        Me.GridColumnlog_date.VisibleIndex = 3
        '
        'GridColumnlog
        '
        Me.GridColumnlog.Caption = "Log"
        Me.GridColumnlog.FieldName = "log"
        Me.GridColumnlog.Name = "GridColumnlog"
        Me.GridColumnlog.Visible = True
        Me.GridColumnlog.VisibleIndex = 2
        '
        'FormDisplayAllocLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 361)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormDisplayAllocLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Display Capacity - Log Update"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLEClass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEDisplay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLEDisplay As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEClass As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnclass_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndisplay_type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnemployee_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnlog_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnlog As DevExpress.XtraGrid.Columns.GridColumn
End Class
