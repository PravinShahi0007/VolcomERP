<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpScheduleBulkSet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpScheduleBulkSet))
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BTempSchedule = New DevExpress.XtraEditors.SimpleButton()
        Me.PGBBulk = New DevExpress.XtraEditors.ProgressBarControl()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DEStart = New DevExpress.XtraEditors.DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GCShift = New DevExpress.XtraGrid.GridControl()
        Me.GVShift = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployee = New DevExpress.XtraGrid.GridControl()
        Me.GVEmployee = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICEEmp = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.CESelectAll = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PGBBulk.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GCShift, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVShift, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICEEmp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.CESelectAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "20_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "8_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "23_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(3, "arrow_refresh.png")
        Me.LargeImageCollection.Images.SetKeyName(4, "check_mark.png")
        Me.LargeImageCollection.Images.SetKeyName(5, "gnome_application_exit (1).png")
        Me.LargeImageCollection.Images.SetKeyName(6, "printer_3.png")
        Me.LargeImageCollection.Images.SetKeyName(7, "save.png")
        Me.LargeImageCollection.Images.SetKeyName(8, "31_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(9, "18_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(10, "1415351112474759854-32.png")
        Me.LargeImageCollection.Images.SetKeyName(11, "icon_merchandise_clothes32.png")
        Me.LargeImageCollection.Images.SetKeyName(12, "t_shirtgreen.png")
        Me.LargeImageCollection.Images.SetKeyName(13, "lock red.png")
        Me.LargeImageCollection.Images.SetKeyName(14, "ordering32.png")
        Me.LargeImageCollection.Images.SetKeyName(15, "kghostview.png")
        Me.LargeImageCollection.Images.SetKeyName(16, "MetroUI-Folder-OS-Configure-icon.png")
        Me.LargeImageCollection.Images.SetKeyName(17, "Setting(32).png")
        Me.LargeImageCollection.Images.SetKeyName(18, "estimate_icon32.png")
        Me.LargeImageCollection.Images.SetKeyName(19, "copy_icon.png")
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BTempSchedule)
        Me.PanelControl2.Controls.Add(Me.PGBBulk)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 476)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(787, 37)
        Me.PanelControl2.TabIndex = 3
        '
        'BTempSchedule
        '
        Me.BTempSchedule.Dock = System.Windows.Forms.DockStyle.Right
        Me.BTempSchedule.ImageIndex = 14
        Me.BTempSchedule.ImageList = Me.LargeImageCollection
        Me.BTempSchedule.Location = New System.Drawing.Point(673, 2)
        Me.BTempSchedule.Name = "BTempSchedule"
        Me.BTempSchedule.Size = New System.Drawing.Size(112, 33)
        Me.BTempSchedule.TabIndex = 3
        Me.BTempSchedule.Text = "Use Template"
        '
        'PGBBulk
        '
        Me.PGBBulk.Dock = System.Windows.Forms.DockStyle.Left
        Me.PGBBulk.Location = New System.Drawing.Point(2, 2)
        Me.PGBBulk.Name = "PGBBulk"
        Me.PGBBulk.Properties.FlowAnimationEnabled = True
        Me.PGBBulk.Properties.ShowTitle = True
        Me.PGBBulk.Size = New System.Drawing.Size(176, 33)
        Me.PGBBulk.TabIndex = 1
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(361, 6)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Size = New System.Drawing.Size(127, 20)
        Me.DEUntil.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(317, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Until : "
        '
        'DEStart
        '
        Me.DEStart.EditValue = Nothing
        Me.DEStart.Location = New System.Drawing.Point(184, 6)
        Me.DEStart.Name = "DEStart"
        Me.DEStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStart.Size = New System.Drawing.Size(127, 20)
        Me.DEStart.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(93, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Schedule from : "
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GCShift)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GCEmployee)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.PanelControl1)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(787, 476)
        Me.SplitContainerControl1.SplitterPosition = 125
        Me.SplitContainerControl1.TabIndex = 4
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'GCShift
        '
        Me.GCShift.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCShift.Location = New System.Drawing.Point(0, 0)
        Me.GCShift.MainView = Me.GVShift
        Me.GCShift.Name = "GCShift"
        Me.GCShift.Size = New System.Drawing.Size(787, 125)
        Me.GCShift.TabIndex = 4
        Me.GCShift.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVShift})
        '
        'GVShift
        '
        Me.GVShift.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnId, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn1, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7})
        Me.GVShift.GridControl = Me.GCShift
        Me.GVShift.Name = "GVShift"
        Me.GVShift.OptionsBehavior.ReadOnly = True
        Me.GVShift.OptionsView.ShowGroupPanel = False
        '
        'GridColumnId
        '
        Me.GridColumnId.Caption = "ID Shift"
        Me.GridColumnId.FieldName = "id_schedule"
        Me.GridColumnId.Name = "GridColumnId"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Shift Name"
        Me.GridColumn2.FieldName = "shift_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Start Working"
        Me.GridColumn3.FieldName = "start_work"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "End Working"
        Me.GridColumn4.FieldName = "end_work"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Start Break Time"
        Me.GridColumn1.FieldName = "start_break"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 3
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "End Break Time"
        Me.GridColumn5.FieldName = "end_break"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 4
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Work Minute(s)"
        Me.GridColumn6.FieldName = "minutes_work"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 5
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Workday"
        Me.GridColumn7.FieldName = "workday"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 6
        '
        'GCEmployee
        '
        Me.GCEmployee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCEmployee.Location = New System.Drawing.Point(0, 0)
        Me.GCEmployee.MainView = Me.GVEmployee
        Me.GCEmployee.Name = "GCEmployee"
        Me.GCEmployee.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICEEmp})
        Me.GCEmployee.Size = New System.Drawing.Size(787, 314)
        Me.GCEmployee.TabIndex = 1
        Me.GCEmployee.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVEmployee})
        '
        'GVEmployee
        '
        Me.GVEmployee.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn14, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13})
        Me.GVEmployee.GridControl = Me.GCEmployee
        Me.GVEmployee.Name = "GVEmployee"
        Me.GVEmployee.OptionsFind.AlwaysVisible = True
        Me.GVEmployee.OptionsView.ShowGroupPanel = False
        '
        'GridColumn14
        '
        Me.GridColumn14.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn14.Caption = "*"
        Me.GridColumn14.ColumnEdit = Me.RICEEmp
        Me.GridColumn14.FieldName = "is_select"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 0
        Me.GridColumn14.Width = 64
        '
        'RICEEmp
        '
        Me.RICEEmp.AutoHeight = False
        Me.RICEEmp.Name = "RICEEmp"
        Me.RICEEmp.ValueChecked = "yes"
        Me.RICEEmp.ValueUnchecked = "no"
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Id Employee"
        Me.GridColumn8.FieldName = "id_employee"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Employee Code (NIP)"
        Me.GridColumn9.FieldName = "employee_code"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 1
        Me.GridColumn9.Width = 139
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Employee Name"
        Me.GridColumn10.FieldName = "employee_name"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = False
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 2
        Me.GridColumn10.Width = 139
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Departement"
        Me.GridColumn11.FieldName = "departement"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 3
        Me.GridColumn11.Width = 139
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Position"
        Me.GridColumn12.FieldName = "employee_position"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.AllowEdit = False
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 4
        Me.GridColumn12.Width = 139
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Status"
        Me.GridColumn13.FieldName = "employee_active"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.AllowEdit = False
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 5
        Me.GridColumn13.Width = 149
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.DEUntil)
        Me.PanelControl1.Controls.Add(Me.Label2)
        Me.PanelControl1.Controls.Add(Me.CESelectAll)
        Me.PanelControl1.Controls.Add(Me.DEStart)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 314)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(787, 32)
        Me.PanelControl1.TabIndex = 0
        '
        'CESelectAll
        '
        Me.CESelectAll.Location = New System.Drawing.Point(12, 6)
        Me.CESelectAll.Name = "CESelectAll"
        Me.CESelectAll.Properties.Caption = "Select All"
        Me.CESelectAll.Size = New System.Drawing.Size(75, 19)
        Me.CESelectAll.TabIndex = 0
        '
        'FormEmpScheduleBulkSet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(787, 513)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Controls.Add(Me.PanelControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "FormEmpScheduleBulkSet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Set Schedule"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PGBBulk.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GCShift, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVShift, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICEEmp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.CESelectAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents DEStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents BTempSchedule As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GCShift As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVShift As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CESelectAll As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GCEmployee As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVEmployee As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICEEmp As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents PGBBulk As DevExpress.XtraEditors.ProgressBarControl
End Class
