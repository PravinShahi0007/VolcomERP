<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormEmpOvertimePick
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpOvertimePick))
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.GVList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICEPick = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SBClose = New DevExpress.XtraEditors.SimpleButton()
        Me.SBAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.TEOvertimeEnd = New DevExpress.XtraEditors.TimeEdit()
        Me.TEOvertimeStart = New DevExpress.XtraEditors.TimeEdit()
        Me.DEOvertimeDateTo = New DevExpress.XtraEditors.DateEdit()
        Me.TEOvertimeBreak = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.TETotalHours = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.DEOvertimeDateFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.MEOvertimeNote = New DevExpress.XtraEditors.MemoEdit()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.CESelectAll = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICEPick, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.TEOvertimeEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEOvertimeStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEOvertimeDateTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEOvertimeDateTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEOvertimeBreak.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TETotalHours.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEOvertimeDateFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEOvertimeDateFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.MEOvertimeNote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.CESelectAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCList
        '
        Me.GCList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCList.Location = New System.Drawing.Point(20, 2)
        Me.GCList.MainView = Me.GVList
        Me.GCList.Name = "GCList"
        Me.GCList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICEPick})
        Me.GCList.Size = New System.Drawing.Size(762, 333)
        Me.GCList.TabIndex = 2
        Me.GCList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVList})
        '
        'GVList
        '
        Me.GVList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn7, Me.GridColumn1, Me.GridColumn9, Me.GridColumn17, Me.GridColumn4, Me.GridColumn2, Me.GridColumn3, Me.GridColumn5, Me.GridColumn10, Me.GridColumn6, Me.GridColumn12, Me.GridColumn11, Me.GridColumn8, Me.GridColumn13})
        Me.GVList.GridControl = Me.GCList
        Me.GVList.GroupCount = 1
        Me.GVList.Name = "GVList"
        Me.GVList.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVList.OptionsFind.AlwaysVisible = True
        Me.GVList.OptionsView.ColumnAutoWidth = False
        Me.GVList.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.GVList.OptionsView.ShowGroupPanel = False
        Me.GVList.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn4, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "*"
        Me.GridColumn7.ColumnEdit = Me.RICEPick
        Me.GridColumn7.FieldName = "is_checked"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 0
        Me.GridColumn7.Width = 41
        '
        'RICEPick
        '
        Me.RICEPick.AutoHeight = False
        Me.RICEPick.Name = "RICEPick"
        Me.RICEPick.ValueChecked = "yes"
        Me.RICEPick.ValueUnchecked = "no"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "GridColumn1"
        Me.GridColumn1.FieldName = "id_employee"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "GridColumn9"
        Me.GridColumn9.FieldName = "id_departement"
        Me.GridColumn9.Name = "GridColumn9"
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "GridColumn17"
        Me.GridColumn17.FieldName = "id_departement_sub"
        Me.GridColumn17.Name = "GridColumn17"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Departement"
        Me.GridColumn4.FieldName = "departement"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 0
        Me.GridColumn4.Width = 86
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "NIP"
        Me.GridColumn2.FieldName = "employee_code"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 27
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Employee"
        Me.GridColumn3.FieldName = "employee_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        Me.GridColumn3.Width = 56
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Employee Position"
        Me.GridColumn5.FieldName = "employee_position"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        Me.GridColumn5.Width = 96
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "GridColumn10"
        Me.GridColumn10.FieldName = "id_employee_status"
        Me.GridColumn10.Name = "GridColumn10"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Employee Status"
        Me.GridColumn6.FieldName = "employee_status"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        Me.GridColumn6.Width = 90
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "GridColumn12"
        Me.GridColumn12.FieldName = "id_employee_active"
        Me.GridColumn12.Name = "GridColumn12"
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Active Status"
        Me.GridColumn11.FieldName = "employee_active"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 5
        Me.GridColumn11.Width = 74
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "GridColumn8"
        Me.GridColumn8.FieldName = "to_salary"
        Me.GridColumn8.Name = "GridColumn8"
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "GridColumn13"
        Me.GridColumn13.FieldName = "is_day_off"
        Me.GridColumn13.Name = "GridColumn13"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SBClose)
        Me.PanelControl1.Controls.Add(Me.SBAdd)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 519)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 42)
        Me.PanelControl1.TabIndex = 3
        '
        'SBClose
        '
        Me.SBClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SBClose.Image = CType(resources.GetObject("SBClose.Image"), System.Drawing.Image)
        Me.SBClose.Location = New System.Drawing.Point(612, 6)
        Me.SBClose.Name = "SBClose"
        Me.SBClose.Size = New System.Drawing.Size(78, 29)
        Me.SBClose.TabIndex = 1
        Me.SBClose.Text = "Close"
        '
        'SBAdd
        '
        Me.SBAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SBAdd.Image = CType(resources.GetObject("SBAdd.Image"), System.Drawing.Image)
        Me.SBAdd.Location = New System.Drawing.Point(694, 6)
        Me.SBAdd.Name = "SBAdd"
        Me.SBAdd.Size = New System.Drawing.Size(78, 29)
        Me.SBAdd.TabIndex = 0
        Me.SBAdd.Text = "Add"
        '
        'GroupControl2
        '
        Me.GroupControl2.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl2.Controls.Add(Me.TEOvertimeEnd)
        Me.GroupControl2.Controls.Add(Me.TEOvertimeStart)
        Me.GroupControl2.Controls.Add(Me.DEOvertimeDateTo)
        Me.GroupControl2.Controls.Add(Me.TEOvertimeBreak)
        Me.GroupControl2.Controls.Add(Me.LabelControl12)
        Me.GroupControl2.Controls.Add(Me.LabelControl11)
        Me.GroupControl2.Controls.Add(Me.TETotalHours)
        Me.GroupControl2.Controls.Add(Me.LabelControl9)
        Me.GroupControl2.Controls.Add(Me.LabelControl8)
        Me.GroupControl2.Controls.Add(Me.DEOvertimeDateFrom)
        Me.GroupControl2.Controls.Add(Me.LabelControl2)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(784, 69)
        Me.GroupControl2.TabIndex = 4
        Me.GroupControl2.Text = "Date"
        '
        'TEOvertimeEnd
        '
        Me.TEOvertimeEnd.EditValue = New Date(2019, 10, 17, 0, 0, 0, 0)
        Me.TEOvertimeEnd.Location = New System.Drawing.Point(612, 12)
        Me.TEOvertimeEnd.Name = "TEOvertimeEnd"
        Me.TEOvertimeEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TEOvertimeEnd.Properties.DisplayFormat.FormatString = "HH:mm:ss"
        Me.TEOvertimeEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TEOvertimeEnd.Properties.EditFormat.FormatString = "HH:mm:ss"
        Me.TEOvertimeEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TEOvertimeEnd.Properties.Mask.EditMask = "HH:mm:ss"
        Me.TEOvertimeEnd.Properties.ReadOnly = True
        Me.TEOvertimeEnd.Size = New System.Drawing.Size(160, 20)
        Me.TEOvertimeEnd.TabIndex = 28
        '
        'TEOvertimeStart
        '
        Me.TEOvertimeStart.EditValue = New Date(2019, 10, 17, 0, 0, 0, 0)
        Me.TEOvertimeStart.Location = New System.Drawing.Point(436, 12)
        Me.TEOvertimeStart.Name = "TEOvertimeStart"
        Me.TEOvertimeStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TEOvertimeStart.Properties.DisplayFormat.FormatString = "HH:mm:ss"
        Me.TEOvertimeStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TEOvertimeStart.Properties.EditFormat.FormatString = "HH:mm:ss"
        Me.TEOvertimeStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TEOvertimeStart.Properties.Mask.EditMask = "HH:mm:ss"
        Me.TEOvertimeStart.Properties.ReadOnly = True
        Me.TEOvertimeStart.Size = New System.Drawing.Size(160, 20)
        Me.TEOvertimeStart.TabIndex = 27
        '
        'DEOvertimeDateTo
        '
        Me.DEOvertimeDateTo.EditValue = Nothing
        Me.DEOvertimeDateTo.Location = New System.Drawing.Point(126, 38)
        Me.DEOvertimeDateTo.Name = "DEOvertimeDateTo"
        Me.DEOvertimeDateTo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEOvertimeDateTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEOvertimeDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEOvertimeDateTo.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEOvertimeDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEOvertimeDateTo.Properties.EditFormat.FormatString = "dd MMMM yyyy"
        Me.DEOvertimeDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEOvertimeDateTo.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DEOvertimeDateTo.Properties.ReadOnly = True
        Me.DEOvertimeDateTo.Size = New System.Drawing.Size(215, 20)
        Me.DEOvertimeDateTo.TabIndex = 26
        '
        'TEOvertimeBreak
        '
        Me.TEOvertimeBreak.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TEOvertimeBreak.EditValue = New Decimal(New Integer() {0, 0, 0, 65536})
        Me.TEOvertimeBreak.Location = New System.Drawing.Point(436, 38)
        Me.TEOvertimeBreak.Name = "TEOvertimeBreak"
        Me.TEOvertimeBreak.Properties.DisplayFormat.FormatString = "N1"
        Me.TEOvertimeBreak.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TEOvertimeBreak.Properties.EditFormat.FormatString = "N1"
        Me.TEOvertimeBreak.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TEOvertimeBreak.Properties.Mask.EditMask = "N1"
        Me.TEOvertimeBreak.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEOvertimeBreak.Properties.ReadOnly = True
        Me.TEOvertimeBreak.Size = New System.Drawing.Size(100, 20)
        Me.TEOvertimeBreak.TabIndex = 23
        '
        'LabelControl12
        '
        Me.LabelControl12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl12.Location = New System.Drawing.Point(557, 41)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(109, 13)
        Me.LabelControl12.TabIndex = 22
        Me.LabelControl12.Text = "Total Overtime (hours)"
        '
        'LabelControl11
        '
        Me.LabelControl11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl11.Location = New System.Drawing.Point(365, 41)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl11.TabIndex = 21
        Me.LabelControl11.Text = "Break (hours)"
        '
        'TETotalHours
        '
        Me.TETotalHours.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TETotalHours.EditValue = ""
        Me.TETotalHours.Location = New System.Drawing.Point(672, 38)
        Me.TETotalHours.Name = "TETotalHours"
        Me.TETotalHours.Properties.DisplayFormat.FormatString = "N1"
        Me.TETotalHours.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TETotalHours.Properties.EditFormat.FormatString = "N1"
        Me.TETotalHours.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TETotalHours.Properties.ReadOnly = True
        Me.TETotalHours.Size = New System.Drawing.Size(100, 20)
        Me.TETotalHours.TabIndex = 18
        '
        'LabelControl9
        '
        Me.LabelControl9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl9.Location = New System.Drawing.Point(602, 15)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(4, 13)
        Me.LabelControl9.TabIndex = 14
        Me.LabelControl9.Text = "-"
        '
        'LabelControl8
        '
        Me.LabelControl8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl8.Location = New System.Drawing.Point(365, 15)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl8.TabIndex = 13
        Me.LabelControl8.Text = "Time"
        '
        'DEOvertimeDateFrom
        '
        Me.DEOvertimeDateFrom.EditValue = Nothing
        Me.DEOvertimeDateFrom.Location = New System.Drawing.Point(126, 12)
        Me.DEOvertimeDateFrom.Name = "DEOvertimeDateFrom"
        Me.DEOvertimeDateFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEOvertimeDateFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEOvertimeDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEOvertimeDateFrom.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEOvertimeDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEOvertimeDateFrom.Properties.EditFormat.FormatString = "dd MMMM yyyy"
        Me.DEOvertimeDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEOvertimeDateFrom.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DEOvertimeDateFrom.Properties.ReadOnly = True
        Me.DEOvertimeDateFrom.Size = New System.Drawing.Size(215, 20)
        Me.DEOvertimeDateFrom.TabIndex = 7
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(35, 15)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(70, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Overtime Date"
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.GCList)
        Me.GroupControl1.Controls.Add(Me.PanelControl2)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 69)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(784, 375)
        Me.GroupControl1.TabIndex = 5
        Me.GroupControl1.Text = "Employee"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(35, 14)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(86, 13)
        Me.LabelControl6.TabIndex = 39
        Me.LabelControl6.Text = "Overtime Purpose"
        '
        'MEOvertimeNote
        '
        Me.MEOvertimeNote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MEOvertimeNote.Location = New System.Drawing.Point(127, 12)
        Me.MEOvertimeNote.Name = "MEOvertimeNote"
        Me.MEOvertimeNote.Properties.ReadOnly = True
        Me.MEOvertimeNote.Size = New System.Drawing.Size(645, 50)
        Me.MEOvertimeNote.TabIndex = 40
        '
        'GroupControl3
        '
        Me.GroupControl3.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl3.Controls.Add(Me.LabelControl6)
        Me.GroupControl3.Controls.Add(Me.MEOvertimeNote)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl3.Location = New System.Drawing.Point(0, 444)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(784, 75)
        Me.GroupControl3.TabIndex = 41
        Me.GroupControl3.Text = "Detail"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.CESelectAll)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(20, 335)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(762, 38)
        Me.PanelControl2.TabIndex = 3
        '
        'CESelectAll
        '
        Me.CESelectAll.Location = New System.Drawing.Point(15, 10)
        Me.CESelectAll.Name = "CESelectAll"
        Me.CESelectAll.Properties.Caption = "Select All"
        Me.CESelectAll.Size = New System.Drawing.Size(75, 19)
        Me.CESelectAll.TabIndex = 0
        '
        'FormEmpOvertimePick
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormEmpOvertimePick"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Overtime Pick"
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICEPick, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.TEOvertimeEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEOvertimeStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEOvertimeDateTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEOvertimeDateTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEOvertimeBreak.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TETotalHours.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEOvertimeDateFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEOvertimeDateFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.MEOvertimeNote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.CESelectAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICEPick As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents SBClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TEOvertimeBreak As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TETotalHours As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEOvertimeDateFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MEOvertimeNote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents DEOvertimeDateTo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TEOvertimeStart As DevExpress.XtraEditors.TimeEdit
    Friend WithEvents TEOvertimeEnd As DevExpress.XtraEditors.TimeEdit
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CESelectAll As DevExpress.XtraEditors.CheckEdit
End Class
