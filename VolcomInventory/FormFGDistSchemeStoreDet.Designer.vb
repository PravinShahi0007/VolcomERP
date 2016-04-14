<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGDistSchemeStoreDet
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFGDistSchemeStoreDet))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.CheckEdit1 = New DevExpress.XtraEditors.CheckEdit
        Me.BtnChoose = New DevExpress.XtraEditors.SimpleButton
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.GCCodeDetail = New DevExpress.XtraGrid.GridControl
        Me.GVCodeDetail = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnSelect = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCompArea = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCompName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCategory = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnRate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemSearchLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
        Me.RepositoryItemSearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnIdComp = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnAllocation = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl
        Me.BDelComp = New DevExpress.XtraEditors.SimpleButton
        Me.BEditComp = New DevExpress.XtraEditors.SimpleButton
        Me.BAddComp = New DevExpress.XtraEditors.SimpleButton
        Me.BtnRateStore = New DevExpress.XtraEditors.SimpleButton
        Me.GridColumnIdPDAlloc = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCCodeDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVCodeDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.CheckEdit1)
        Me.PanelControl1.Controls.Add(Me.BtnChoose)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 422)
        Me.PanelControl1.LookAndFeel.SkinName = "Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(766, 37)
        Me.PanelControl1.TabIndex = 1
        '
        'CheckEdit1
        '
        Me.CheckEdit1.Location = New System.Drawing.Point(7, 9)
        Me.CheckEdit1.Name = "CheckEdit1"
        Me.CheckEdit1.Properties.Caption = "Select All"
        Me.CheckEdit1.Size = New System.Drawing.Size(102, 19)
        Me.CheckEdit1.TabIndex = 1
        '
        'BtnChoose
        '
        Me.BtnChoose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnChoose.ImageIndex = 4
        Me.BtnChoose.ImageList = Me.LargeImageCollection
        Me.BtnChoose.Location = New System.Drawing.Point(691, 0)
        Me.BtnChoose.Name = "BtnChoose"
        Me.BtnChoose.Size = New System.Drawing.Size(75, 37)
        Me.BtnChoose.TabIndex = 1
        Me.BtnChoose.Text = "Choose"
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
        Me.LargeImageCollection.Images.SetKeyName(10, "Actions-rating-icon.png")
        Me.LargeImageCollection.Images.SetKeyName(11, "list-add.png")
        '
        'GCCodeDetail
        '
        Me.GCCodeDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCCodeDetail.Location = New System.Drawing.Point(0, 37)
        Me.GCCodeDetail.MainView = Me.GVCodeDetail
        Me.GCCodeDetail.Name = "GCCodeDetail"
        Me.GCCodeDetail.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit2, Me.RepositoryItemLookUpEdit1, Me.RepositoryItemCheckEdit1, Me.RepositoryItemSearchLookUpEdit1})
        Me.GCCodeDetail.Size = New System.Drawing.Size(766, 385)
        Me.GCCodeDetail.TabIndex = 8
        Me.GCCodeDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVCodeDetail})
        '
        'GVCodeDetail
        '
        Me.GVCodeDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnSelect, Me.GridColumnCode, Me.GridColumnCompArea, Me.GridColumnCompName, Me.GridColumnCategory, Me.GridColumnRate, Me.GridColumnAllocation, Me.GridColumnIdComp, Me.GridColumnIdPDAlloc})
        Me.GVCodeDetail.GridControl = Me.GCCodeDetail
        Me.GVCodeDetail.GroupCount = 1
        Me.GVCodeDetail.Name = "GVCodeDetail"
        Me.GVCodeDetail.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVCodeDetail.OptionsView.ShowGroupPanel = False
        Me.GVCodeDetail.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnCategory, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnCode, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnSelect
        '
        Me.GridColumnSelect.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnSelect.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSelect.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSelect.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSelect.Caption = "Select"
        Me.GridColumnSelect.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnSelect.FieldName = "is_select"
        Me.GridColumnSelect.Name = "GridColumnSelect"
        Me.GridColumnSelect.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnSelect.Visible = True
        Me.GridColumnSelect.VisibleIndex = 5
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "comp_number"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.OptionsColumn.ReadOnly = True
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 0
        '
        'GridColumnCompArea
        '
        Me.GridColumnCompArea.Caption = "Area"
        Me.GridColumnCompArea.FieldName = "area"
        Me.GridColumnCompArea.FieldNameSortGroup = "id_area"
        Me.GridColumnCompArea.Name = "GridColumnCompArea"
        Me.GridColumnCompArea.OptionsColumn.ReadOnly = True
        Me.GridColumnCompArea.Visible = True
        Me.GridColumnCompArea.VisibleIndex = 1
        '
        'GridColumnCompName
        '
        Me.GridColumnCompName.Caption = "Name"
        Me.GridColumnCompName.FieldName = "comp_name"
        Me.GridColumnCompName.Name = "GridColumnCompName"
        Me.GridColumnCompName.OptionsColumn.ReadOnly = True
        Me.GridColumnCompName.Visible = True
        Me.GridColumnCompName.VisibleIndex = 2
        '
        'GridColumnCategory
        '
        Me.GridColumnCategory.Caption = "Category"
        Me.GridColumnCategory.FieldName = "comp_cat_name"
        Me.GridColumnCategory.FieldNameSortGroup = "id_comp_cat"
        Me.GridColumnCategory.Name = "GridColumnCategory"
        Me.GridColumnCategory.OptionsColumn.ReadOnly = True
        '
        'GridColumnRate
        '
        Me.GridColumnRate.Caption = "Rate Store"
        Me.GridColumnRate.ColumnEdit = Me.RepositoryItemSearchLookUpEdit1
        Me.GridColumnRate.FieldName = "id_store_rate"
        Me.GridColumnRate.Name = "GridColumnRate"
        Me.GridColumnRate.Visible = True
        Me.GridColumnRate.VisibleIndex = 3
        '
        'RepositoryItemSearchLookUpEdit1
        '
        Me.RepositoryItemSearchLookUpEdit1.AutoHeight = False
        Me.RepositoryItemSearchLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSearchLookUpEdit1.Name = "RepositoryItemSearchLookUpEdit1"
        Me.RepositoryItemSearchLookUpEdit1.View = Me.RepositoryItemSearchLookUpEdit1View
        '
        'RepositoryItemSearchLookUpEdit1View
        '
        Me.RepositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.RepositoryItemSearchLookUpEdit1View.Name = "RepositoryItemSearchLookUpEdit1View"
        Me.RepositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RepositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdComp
        '
        Me.GridColumnIdComp.Caption = "Id Comp"
        Me.GridColumnIdComp.FieldName = "id_comp"
        Me.GridColumnIdComp.Name = "GridColumnIdComp"
        Me.GridColumnIdComp.OptionsColumn.ReadOnly = True
        Me.GridColumnIdComp.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnAllocation
        '
        Me.GridColumnAllocation.Caption = "Allocation"
        Me.GridColumnAllocation.FieldName = "pd_alloc"
        Me.GridColumnAllocation.FieldNameSortGroup = "id_pd_alloc"
        Me.GridColumnAllocation.Name = "GridColumnAllocation"
        Me.GridColumnAllocation.Visible = True
        Me.GridColumnAllocation.VisibleIndex = 4
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        Me.RepositoryItemCheckEdit2.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RepositoryItemCheckEdit2.ValueUnchecked = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'RepositoryItemLookUpEdit1
        '
        Me.RepositoryItemLookUpEdit1.AutoHeight = False
        Me.RepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BDelComp)
        Me.PanelControl2.Controls.Add(Me.BEditComp)
        Me.PanelControl2.Controls.Add(Me.BAddComp)
        Me.PanelControl2.Controls.Add(Me.BtnRateStore)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.LookAndFeel.SkinName = "Blue"
        Me.PanelControl2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(766, 37)
        Me.PanelControl2.TabIndex = 9
        '
        'BDelComp
        '
        Me.BDelComp.Dock = System.Windows.Forms.DockStyle.Right
        Me.BDelComp.ImageIndex = 1
        Me.BDelComp.ImageList = Me.LargeImageCollection
        Me.BDelComp.Location = New System.Drawing.Point(517, 2)
        Me.BDelComp.Name = "BDelComp"
        Me.BDelComp.Size = New System.Drawing.Size(85, 33)
        Me.BDelComp.TabIndex = 7
        Me.BDelComp.Text = "Delete"
        '
        'BEditComp
        '
        Me.BEditComp.Dock = System.Windows.Forms.DockStyle.Right
        Me.BEditComp.ImageIndex = 2
        Me.BEditComp.ImageList = Me.LargeImageCollection
        Me.BEditComp.Location = New System.Drawing.Point(602, 2)
        Me.BEditComp.Name = "BEditComp"
        Me.BEditComp.Size = New System.Drawing.Size(82, 33)
        Me.BEditComp.TabIndex = 6
        Me.BEditComp.Text = "Edit"
        '
        'BAddComp
        '
        Me.BAddComp.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAddComp.ImageIndex = 0
        Me.BAddComp.ImageList = Me.LargeImageCollection
        Me.BAddComp.Location = New System.Drawing.Point(684, 2)
        Me.BAddComp.Name = "BAddComp"
        Me.BAddComp.Size = New System.Drawing.Size(80, 33)
        Me.BAddComp.TabIndex = 5
        Me.BAddComp.Text = "Add"
        '
        'BtnRateStore
        '
        Me.BtnRateStore.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnRateStore.ImageIndex = 10
        Me.BtnRateStore.ImageList = Me.LargeImageCollection
        Me.BtnRateStore.Location = New System.Drawing.Point(2, 2)
        Me.BtnRateStore.Name = "BtnRateStore"
        Me.BtnRateStore.Size = New System.Drawing.Size(107, 33)
        Me.BtnRateStore.TabIndex = 2
        Me.BtnRateStore.Text = "Master Rate"
        '
        'GridColumnIdPDAlloc
        '
        Me.GridColumnIdPDAlloc.Caption = "Id Pd Alloc"
        Me.GridColumnIdPDAlloc.FieldName = "id_pd_alloc"
        Me.GridColumnIdPDAlloc.Name = "GridColumnIdPDAlloc"
        Me.GridColumnIdPDAlloc.OptionsColumn.ShowInCustomizationForm = False
        '
        'FormFGDistSchemeStoreDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(766, 459)
        Me.Controls.Add(Me.GCCodeDetail)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormFGDistSchemeStoreDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Distribution Scheme - Select Account"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCCodeDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVCodeDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CheckEdit1 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents BtnChoose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCCodeDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVCodeDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnSelect As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompArea As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSearchLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnRateStore As DevExpress.XtraEditors.SimpleButton
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents BDelComp As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BEditComp As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BAddComp As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnIdComp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAllocation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdPDAlloc As DevExpress.XtraGrid.Columns.GridColumn
End Class
