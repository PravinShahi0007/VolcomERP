<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOptView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormOptView))
        Me.SCCOpt = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GroupControlTemplate = New DevExpress.XtraEditors.GroupControl()
        Me.GCTemplate = New DevExpress.XtraGrid.GridControl()
        Me.GVTemplate = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdTemp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PCNav = New DevExpress.XtraEditors.PanelControl()
        Me.BtnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.SCCTemplate2 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GroupControlColumn = New DevExpress.XtraEditors.GroupControl()
        Me.GCSetup = New DevExpress.XtraGrid.GridControl()
        Me.GVSetup = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdParent = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBand = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnVisible = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnCaption = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupControlRole = New DevExpress.XtraEditors.GroupControl()
        Me.GCRole = New DevExpress.XtraGrid.GridControl()
        Me.GVRole = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdRole = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRole = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.PCBottom = New DevExpress.XtraEditors.PanelControl()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.SCCOpt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SCCOpt.SuspendLayout()
        CType(Me.GroupControlTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlTemplate.SuspendLayout()
        CType(Me.GCTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCNav.SuspendLayout()
        CType(Me.SCCTemplate2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SCCTemplate2.SuspendLayout()
        CType(Me.GroupControlColumn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlColumn.SuspendLayout()
        CType(Me.GCSetup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSetup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlRole, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlRole.SuspendLayout()
        CType(Me.GCRole, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRole, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCBottom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'SCCOpt
        '
        Me.SCCOpt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SCCOpt.Location = New System.Drawing.Point(0, 0)
        Me.SCCOpt.Name = "SCCOpt"
        Me.SCCOpt.Panel1.Controls.Add(Me.GroupControlTemplate)
        Me.SCCOpt.Panel1.Text = "Panel1"
        Me.SCCOpt.Panel2.Controls.Add(Me.SCCTemplate2)
        Me.SCCOpt.Panel2.Text = "Panel2"
        Me.SCCOpt.Size = New System.Drawing.Size(949, 384)
        Me.SCCOpt.SplitterPosition = 360
        Me.SCCOpt.TabIndex = 0
        Me.SCCOpt.Text = "SplitContainerControl1"
        '
        'GroupControlTemplate
        '
        Me.GroupControlTemplate.CaptionLocation = DevExpress.Utils.Locations.Bottom
        Me.GroupControlTemplate.Controls.Add(Me.GCTemplate)
        Me.GroupControlTemplate.Controls.Add(Me.PCNav)
        Me.GroupControlTemplate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlTemplate.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlTemplate.Name = "GroupControlTemplate"
        Me.GroupControlTemplate.Size = New System.Drawing.Size(360, 384)
        Me.GroupControlTemplate.TabIndex = 0
        Me.GroupControlTemplate.Text = "Template"
        '
        'GCTemplate
        '
        Me.GCTemplate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCTemplate.Location = New System.Drawing.Point(2, 39)
        Me.GCTemplate.MainView = Me.GVTemplate
        Me.GCTemplate.Name = "GCTemplate"
        Me.GCTemplate.Size = New System.Drawing.Size(356, 325)
        Me.GCTemplate.TabIndex = 1
        Me.GCTemplate.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVTemplate})
        '
        'GVTemplate
        '
        Me.GVTemplate.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdTemp, Me.GridColumnName})
        Me.GVTemplate.GridControl = Me.GCTemplate
        Me.GVTemplate.Name = "GVTemplate"
        Me.GVTemplate.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdTemp
        '
        Me.GridColumnIdTemp.Caption = "Id"
        Me.GridColumnIdTemp.FieldName = "id_options_view"
        Me.GridColumnIdTemp.Name = "GridColumnIdTemp"
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Name"
        Me.GridColumnName.FieldName = "options_view_name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 0
        '
        'PCNav
        '
        Me.PCNav.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCNav.Controls.Add(Me.BtnDelete)
        Me.PCNav.Controls.Add(Me.BtnAdd)
        Me.PCNav.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCNav.Location = New System.Drawing.Point(2, 2)
        Me.PCNav.Name = "PCNav"
        Me.PCNav.Size = New System.Drawing.Size(356, 37)
        Me.PCNav.TabIndex = 0
        '
        'BtnDelete
        '
        Me.BtnDelete.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDelete.Image = CType(resources.GetObject("BtnDelete.Image"), System.Drawing.Image)
        Me.BtnDelete.Location = New System.Drawing.Point(187, 0)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(88, 37)
        Me.BtnDelete.TabIndex = 2
        Me.BtnDelete.Text = "Delete"
        '
        'BtnAdd
        '
        Me.BtnAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"), System.Drawing.Image)
        Me.BtnAdd.Location = New System.Drawing.Point(275, 0)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(81, 37)
        Me.BtnAdd.TabIndex = 1
        Me.BtnAdd.Text = "Add"
        '
        'SCCTemplate2
        '
        Me.SCCTemplate2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SCCTemplate2.Horizontal = False
        Me.SCCTemplate2.Location = New System.Drawing.Point(0, 0)
        Me.SCCTemplate2.Name = "SCCTemplate2"
        Me.SCCTemplate2.Panel1.Controls.Add(Me.GroupControlColumn)
        Me.SCCTemplate2.Panel1.Text = "Panel1"
        Me.SCCTemplate2.Panel2.Controls.Add(Me.GroupControlRole)
        Me.SCCTemplate2.Panel2.Text = "Panel2"
        Me.SCCTemplate2.Size = New System.Drawing.Size(584, 384)
        Me.SCCTemplate2.SplitterPosition = 267
        Me.SCCTemplate2.TabIndex = 1
        Me.SCCTemplate2.Text = "SplitContainerControl1"
        '
        'GroupControlColumn
        '
        Me.GroupControlColumn.CaptionLocation = DevExpress.Utils.Locations.Bottom
        Me.GroupControlColumn.Controls.Add(Me.GCSetup)
        Me.GroupControlColumn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlColumn.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlColumn.Name = "GroupControlColumn"
        Me.GroupControlColumn.Size = New System.Drawing.Size(584, 267)
        Me.GroupControlColumn.TabIndex = 0
        Me.GroupControlColumn.Text = "Setup Columns"
        '
        'GCSetup
        '
        Me.GCSetup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSetup.Location = New System.Drawing.Point(2, 2)
        Me.GCSetup.MainView = Me.GVSetup
        Me.GCSetup.Name = "GCSetup"
        Me.GCSetup.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCSetup.Size = New System.Drawing.Size(580, 245)
        Me.GCSetup.TabIndex = 0
        Me.GCSetup.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSetup})
        '
        'GVSetup
        '
        Me.GVSetup.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdDet, Me.GridColumnIdParent, Me.GridColumnBand, Me.GridColumnColumn, Me.GridColumnVisible, Me.GridColumnCaption})
        Me.GVSetup.GridControl = Me.GCSetup
        Me.GVSetup.GroupCount = 1
        Me.GVSetup.Name = "GVSetup"
        Me.GVSetup.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVSetup.OptionsView.ShowGroupPanel = False
        Me.GVSetup.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnBand, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnIdDet
        '
        Me.GridColumnIdDet.Caption = "Id Det"
        Me.GridColumnIdDet.Name = "GridColumnIdDet"
        Me.GridColumnIdDet.OptionsColumn.ReadOnly = True
        '
        'GridColumnIdParent
        '
        Me.GridColumnIdParent.Caption = "Id"
        Me.GridColumnIdParent.FieldName = "id_options_view"
        Me.GridColumnIdParent.Name = "GridColumnIdParent"
        Me.GridColumnIdParent.OptionsColumn.ReadOnly = True
        '
        'GridColumnBand
        '
        Me.GridColumnBand.Caption = "Band"
        Me.GridColumnBand.FieldName = "options_view_det_band"
        Me.GridColumnBand.Name = "GridColumnBand"
        Me.GridColumnBand.OptionsColumn.ReadOnly = True
        Me.GridColumnBand.Visible = True
        Me.GridColumnBand.VisibleIndex = 0
        '
        'GridColumnColumn
        '
        Me.GridColumnColumn.Caption = "Column Hide"
        Me.GridColumnColumn.FieldName = "options_view_det_column"
        Me.GridColumnColumn.Name = "GridColumnColumn"
        Me.GridColumnColumn.OptionsColumn.ReadOnly = True
        '
        'GridColumnVisible
        '
        Me.GridColumnVisible.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnVisible.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnVisible.Caption = "Visible"
        Me.GridColumnVisible.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnVisible.FieldName = "options_view_det_visible"
        Me.GridColumnVisible.Name = "GridColumnVisible"
        Me.GridColumnVisible.Visible = True
        Me.GridColumnVisible.VisibleIndex = 1
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "True"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "False"
        '
        'GridColumnCaption
        '
        Me.GridColumnCaption.Caption = "Column"
        Me.GridColumnCaption.FieldName = "options_view_det_caption"
        Me.GridColumnCaption.Name = "GridColumnCaption"
        Me.GridColumnCaption.Visible = True
        Me.GridColumnCaption.VisibleIndex = 0
        '
        'GroupControlRole
        '
        Me.GroupControlRole.CaptionLocation = DevExpress.Utils.Locations.Bottom
        Me.GroupControlRole.Controls.Add(Me.GCRole)
        Me.GroupControlRole.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlRole.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlRole.Name = "GroupControlRole"
        Me.GroupControlRole.Size = New System.Drawing.Size(584, 112)
        Me.GroupControlRole.TabIndex = 0
        Me.GroupControlRole.Text = "Setup Role"
        '
        'GCRole
        '
        Me.GCRole.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRole.Location = New System.Drawing.Point(2, 2)
        Me.GCRole.MainView = Me.GVRole
        Me.GCRole.Name = "GCRole"
        Me.GCRole.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit2})
        Me.GCRole.Size = New System.Drawing.Size(580, 90)
        Me.GCRole.TabIndex = 1
        Me.GCRole.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRole})
        '
        'GVRole
        '
        Me.GVRole.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdRole, Me.GridColumnRole, Me.GridColumnSel})
        Me.GVRole.GridControl = Me.GCRole
        Me.GVRole.Name = "GVRole"
        Me.GVRole.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdRole
        '
        Me.GridColumnIdRole.Caption = "Id Role"
        Me.GridColumnIdRole.FieldName = "id_role"
        Me.GridColumnIdRole.Name = "GridColumnIdRole"
        Me.GridColumnIdRole.OptionsColumn.ReadOnly = True
        '
        'GridColumnRole
        '
        Me.GridColumnRole.Caption = "Role"
        Me.GridColumnRole.FieldName = "role"
        Me.GridColumnRole.Name = "GridColumnRole"
        Me.GridColumnRole.OptionsColumn.ReadOnly = True
        Me.GridColumnRole.Visible = True
        Me.GridColumnRole.VisibleIndex = 0
        '
        'GridColumnSel
        '
        Me.GridColumnSel.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSel.Caption = "Select"
        Me.GridColumnSel.ColumnEdit = Me.RepositoryItemCheckEdit2
        Me.GridColumnSel.FieldName = "is_select"
        Me.GridColumnSel.Name = "GridColumnSel"
        Me.GridColumnSel.Visible = True
        Me.GridColumnSel.VisibleIndex = 1
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        Me.RepositoryItemCheckEdit2.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit2.ValueUnchecked = "No"
        '
        'PCBottom
        '
        Me.PCBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCBottom.Controls.Add(Me.BtnClose)
        Me.PCBottom.Controls.Add(Me.BtnSave)
        Me.PCBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PCBottom.Location = New System.Drawing.Point(0, 384)
        Me.PCBottom.Name = "PCBottom"
        Me.PCBottom.Size = New System.Drawing.Size(949, 35)
        Me.PCBottom.TabIndex = 1
        '
        'BtnClose
        '
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnClose.Location = New System.Drawing.Point(797, 0)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(72, 35)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.Location = New System.Drawing.Point(869, 0)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(80, 35)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "Save"
        '
        'FormOptView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(949, 419)
        Me.Controls.Add(Me.SCCOpt)
        Me.Controls.Add(Me.PCBottom)
        Me.MinimizeBox = False
        Me.Name = "FormOptView"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Options View"
        CType(Me.SCCOpt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SCCOpt.ResumeLayout(False)
        CType(Me.GroupControlTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlTemplate.ResumeLayout(False)
        CType(Me.GCTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCNav.ResumeLayout(False)
        CType(Me.SCCTemplate2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SCCTemplate2.ResumeLayout(False)
        CType(Me.GroupControlColumn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlColumn.ResumeLayout(False)
        CType(Me.GCSetup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSetup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlRole, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlRole.ResumeLayout(False)
        CType(Me.GCRole, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRole, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCBottom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCBottom.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SCCOpt As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControlTemplate As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControlColumn As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCSetup As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSetup As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PCNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCTemplate As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVTemplate As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdTemp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SCCTemplate2 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControlRole As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCRole As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRole As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PCBottom As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnIdDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdParent As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBand As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnVisible As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnIdRole As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRole As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnCaption As DevExpress.XtraGrid.Columns.GridColumn
End Class
