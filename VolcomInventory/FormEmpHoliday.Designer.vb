<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpHoliday
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BImport = New DevExpress.XtraEditors.SimpleButton()
        Me.BSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEReligion = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdReligionSLE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReligionSLE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEYear = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GVSLEDesgSearch = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnYear = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.GCHoliday = New DevExpress.XtraGrid.GridControl()
        Me.GVHoliday = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdHoliday = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdReligion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReligion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RIPictureEdit = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.XTCHoliday = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPList = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPView = New DevExpress.XtraTab.XtraTabPage()
        Me.GCSum = New DevExpress.XtraGrid.GridControl()
        Me.GVSum = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemPictureEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BSearchSum = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEYearSum = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEReligion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSLEDesgSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCHoliday, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVHoliday, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RIPictureEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCHoliday, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCHoliday.SuspendLayout()
        Me.XTPList.SuspendLayout()
        Me.XTPView.SuspendLayout()
        CType(Me.GCSum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemPictureEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.SLEYearSum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BImport)
        Me.PanelControl1.Controls.Add(Me.BSearch)
        Me.PanelControl1.Controls.Add(Me.SLEReligion)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.SLEYear)
        Me.PanelControl1.Controls.Add(Me.LabelControl9)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(722, 47)
        Me.PanelControl1.TabIndex = 0
        '
        'BImport
        '
        Me.BImport.Dock = System.Windows.Forms.DockStyle.Right
        Me.BImport.Location = New System.Drawing.Point(626, 2)
        Me.BImport.Name = "BImport"
        Me.BImport.Size = New System.Drawing.Size(94, 43)
        Me.BImport.TabIndex = 8906
        Me.BImport.Text = "Import Excel"
        '
        'BSearch
        '
        Me.BSearch.Location = New System.Drawing.Point(444, 10)
        Me.BSearch.Name = "BSearch"
        Me.BSearch.Size = New System.Drawing.Size(59, 23)
        Me.BSearch.TabIndex = 8904
        Me.BSearch.Text = "View"
        '
        'SLEReligion
        '
        Me.SLEReligion.Location = New System.Drawing.Point(272, 12)
        Me.SLEReligion.Name = "SLEReligion"
        Me.SLEReligion.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEReligion.Properties.View = Me.GridView1
        Me.SLEReligion.Size = New System.Drawing.Size(166, 20)
        Me.SLEReligion.TabIndex = 8900
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdReligionSLE, Me.GridColumnReligionSLE})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdReligionSLE
        '
        Me.GridColumnIdReligionSLE.Caption = "Id Religion"
        Me.GridColumnIdReligionSLE.FieldName = "id_religion"
        Me.GridColumnIdReligionSLE.Name = "GridColumnIdReligionSLE"
        '
        'GridColumnReligionSLE
        '
        Me.GridColumnReligionSLE.Caption = "Religion"
        Me.GridColumnReligionSLE.FieldName = "religion"
        Me.GridColumnReligionSLE.Name = "GridColumnReligionSLE"
        Me.GridColumnReligionSLE.Visible = True
        Me.GridColumnReligionSLE.VisibleIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(229, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl1.TabIndex = 8899
        Me.LabelControl1.Text = "Religion"
        '
        'SLEYear
        '
        Me.SLEYear.Location = New System.Drawing.Point(52, 12)
        Me.SLEYear.Name = "SLEYear"
        Me.SLEYear.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEYear.Properties.View = Me.GVSLEDesgSearch
        Me.SLEYear.Size = New System.Drawing.Size(166, 20)
        Me.SLEYear.TabIndex = 8898
        '
        'GVSLEDesgSearch
        '
        Me.GVSLEDesgSearch.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnYear})
        Me.GVSLEDesgSearch.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GVSLEDesgSearch.Name = "GVSLEDesgSearch"
        Me.GVSLEDesgSearch.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GVSLEDesgSearch.OptionsView.ShowGroupPanel = False
        '
        'GridColumnYear
        '
        Me.GridColumnYear.Caption = "Year"
        Me.GridColumnYear.FieldName = "year"
        Me.GridColumnYear.Name = "GridColumnYear"
        Me.GridColumnYear.Visible = True
        Me.GridColumnYear.VisibleIndex = 0
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Location = New System.Drawing.Point(15, 15)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl9.TabIndex = 8897
        Me.LabelControl9.Text = "Year"
        '
        'GCHoliday
        '
        Me.GCHoliday.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCHoliday.Location = New System.Drawing.Point(0, 47)
        Me.GCHoliday.MainView = Me.GVHoliday
        Me.GCHoliday.Name = "GCHoliday"
        Me.GCHoliday.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RIPictureEdit})
        Me.GCHoliday.Size = New System.Drawing.Size(722, 251)
        Me.GCHoliday.TabIndex = 3
        Me.GCHoliday.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVHoliday})
        '
        'GVHoliday
        '
        Me.GVHoliday.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdHoliday, Me.GridColumnIdReligion, Me.GridColumnReligion, Me.GridColumnDate, Me.GridColumnDesc})
        Me.GVHoliday.GridControl = Me.GCHoliday
        Me.GVHoliday.Name = "GVHoliday"
        Me.GVHoliday.OptionsBehavior.Editable = False
        Me.GVHoliday.OptionsFind.AlwaysVisible = True
        Me.GVHoliday.OptionsView.ShowGroupPanel = False
        Me.GVHoliday.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnDate, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnIdHoliday
        '
        Me.GridColumnIdHoliday.Caption = "Id Holiday"
        Me.GridColumnIdHoliday.FieldName = "id_emp_holiday"
        Me.GridColumnIdHoliday.Name = "GridColumnIdHoliday"
        '
        'GridColumnIdReligion
        '
        Me.GridColumnIdReligion.Caption = "Id Religion"
        Me.GridColumnIdReligion.Name = "GridColumnIdReligion"
        '
        'GridColumnReligion
        '
        Me.GridColumnReligion.Caption = "Religion"
        Me.GridColumnReligion.FieldName = "religion"
        Me.GridColumnReligion.Name = "GridColumnReligion"
        Me.GridColumnReligion.Visible = True
        Me.GridColumnReligion.VisibleIndex = 1
        '
        'GridColumnDate
        '
        Me.GridColumnDate.Caption = "Holiday Date"
        Me.GridColumnDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumnDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnDate.FieldName = "emp_holiday_date"
        Me.GridColumnDate.Name = "GridColumnDate"
        Me.GridColumnDate.Visible = True
        Me.GridColumnDate.VisibleIndex = 0
        '
        'GridColumnDesc
        '
        Me.GridColumnDesc.Caption = "Holiday"
        Me.GridColumnDesc.FieldName = "emp_holiday_desc"
        Me.GridColumnDesc.Name = "GridColumnDesc"
        Me.GridColumnDesc.Visible = True
        Me.GridColumnDesc.VisibleIndex = 2
        '
        'RIPictureEdit
        '
        Me.RIPictureEdit.Name = "RIPictureEdit"
        Me.RIPictureEdit.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        '
        'XTCHoliday
        '
        Me.XTCHoliday.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCHoliday.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCHoliday.Location = New System.Drawing.Point(0, 0)
        Me.XTCHoliday.Name = "XTCHoliday"
        Me.XTCHoliday.SelectedTabPage = Me.XTPList
        Me.XTCHoliday.Size = New System.Drawing.Size(728, 326)
        Me.XTCHoliday.TabIndex = 4
        Me.XTCHoliday.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPList, Me.XTPView})
        '
        'XTPList
        '
        Me.XTPList.Controls.Add(Me.GCHoliday)
        Me.XTPList.Controls.Add(Me.PanelControl1)
        Me.XTPList.Name = "XTPList"
        Me.XTPList.Size = New System.Drawing.Size(722, 298)
        Me.XTPList.Text = "List"
        '
        'XTPView
        '
        Me.XTPView.Controls.Add(Me.GCSum)
        Me.XTPView.Controls.Add(Me.PanelControl2)
        Me.XTPView.Name = "XTPView"
        Me.XTPView.Size = New System.Drawing.Size(722, 298)
        Me.XTPView.Text = "View"
        '
        'GCSum
        '
        Me.GCSum.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSum.Location = New System.Drawing.Point(0, 47)
        Me.GCSum.MainView = Me.GVSum
        Me.GCSum.Name = "GCSum"
        Me.GCSum.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemPictureEdit1})
        Me.GCSum.Size = New System.Drawing.Size(722, 251)
        Me.GCSum.TabIndex = 4
        Me.GCSum.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSum})
        '
        'GVSum
        '
        Me.GVSum.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn9, Me.GridColumn8, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7})
        Me.GVSum.GridControl = Me.GCSum
        Me.GVSum.Name = "GVSum"
        Me.GVSum.OptionsBehavior.Editable = False
        Me.GVSum.OptionsView.AllowCellMerge = True
        Me.GVSum.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.Caption = "Month"
        Me.GridColumn1.FieldName = "hol_month"
        Me.GridColumn1.FieldNameSortGroup = "id_month"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 82
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "IDMonth"
        Me.GridColumn9.FieldName = "id_month"
        Me.GridColumn9.Name = "GridColumn9"
        '
        'GridColumn8
        '
        Me.GridColumn8.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn8.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn8.Caption = "*"
        Me.GridColumn8.DisplayFormat.FormatString = "dddd"
        Me.GridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn8.FieldName = "dow"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 5
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Date"
        Me.GridColumn2.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn2.FieldName = "hol_date"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn2.Width = 102
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn3.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn3.Caption = "Hindu"
        Me.GridColumn3.FieldName = "hindu"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 105
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn4.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn4.Caption = "Islam"
        Me.GridColumn4.FieldName = "islam"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn4.OptionsFilter.AllowFilter = False
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        Me.GridColumn4.Width = 105
        '
        'GridColumn5
        '
        Me.GridColumn5.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn5.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn5.Caption = "Kristen"
        Me.GridColumn5.FieldName = "kristen"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        Me.GridColumn5.Width = 105
        '
        'GridColumn6
        '
        Me.GridColumn6.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn6.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn6.Caption = "Budha"
        Me.GridColumn6.FieldName = "budha"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        Me.GridColumn6.Width = 112
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Holiday"
        Me.GridColumn7.FieldName = "emp_holiday_desc"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn7.Width = 93
        '
        'RepositoryItemPictureEdit1
        '
        Me.RepositoryItemPictureEdit1.Name = "RepositoryItemPictureEdit1"
        Me.RepositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BSearchSum)
        Me.PanelControl2.Controls.Add(Me.SLEYearSum)
        Me.PanelControl2.Controls.Add(Me.LabelControl3)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(722, 47)
        Me.PanelControl2.TabIndex = 5
        '
        'BSearchSum
        '
        Me.BSearchSum.Location = New System.Drawing.Point(233, 10)
        Me.BSearchSum.Name = "BSearchSum"
        Me.BSearchSum.Size = New System.Drawing.Size(59, 23)
        Me.BSearchSum.TabIndex = 8904
        Me.BSearchSum.Text = "View"
        '
        'SLEYearSum
        '
        Me.SLEYearSum.Location = New System.Drawing.Point(52, 12)
        Me.SLEYearSum.Name = "SLEYearSum"
        Me.SLEYearSum.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEYearSum.Properties.View = Me.GridView4
        Me.SLEYearSum.Size = New System.Drawing.Size(166, 20)
        Me.SLEYearSum.TabIndex = 8898
        '
        'GridView4
        '
        Me.GridView4.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn10})
        Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView4.OptionsView.ShowGroupPanel = False
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Year"
        Me.GridColumn10.FieldName = "year"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 0
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(15, 15)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl3.TabIndex = 8897
        Me.LabelControl3.Text = "Year"
        '
        'FormEmpHoliday
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(728, 326)
        Me.Controls.Add(Me.XTCHoliday)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpHoliday"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Holiday List"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLEReligion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSLEDesgSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCHoliday, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVHoliday, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RIPictureEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCHoliday, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCHoliday.ResumeLayout(False)
        Me.XTPList.ResumeLayout(False)
        Me.XTPView.ResumeLayout(False)
        CType(Me.GCSum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemPictureEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.SLEYearSum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLEYear As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GVSLEDesgSearch As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEReligion As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCHoliday As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVHoliday As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RIPictureEdit As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents GridColumnIdHoliday As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdReligion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReligion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnYear As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdReligionSLE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReligionSLE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BImport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XTCHoliday As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPView As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCSum As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSum As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemPictureEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BSearchSum As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLEYearSum As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
End Class
