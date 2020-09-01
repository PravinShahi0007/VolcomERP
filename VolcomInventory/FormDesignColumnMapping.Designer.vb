<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDesignColumnMapping
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDesignColumnMapping))
        Me.GCColumn = New DevExpress.XtraGrid.GridControl()
        Me.GVColumn = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemMemoEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.GCCol = New DevExpress.XtraGrid.GridControl()
        Me.GVCol = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLUEStore = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TEType = New DevExpress.XtraEditors.TextEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.SBClose = New DevExpress.XtraEditors.SimpleButton()
        Me.SBSave = New DevExpress.XtraEditors.SimpleButton()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.SBDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.SBAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.TEAdd = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.GCColumn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVColumn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCCol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVCol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLUEStore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.TEAdd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCColumn
        '
        Me.GCColumn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCColumn.Location = New System.Drawing.Point(0, 42)
        Me.GCColumn.MainView = Me.GVColumn
        Me.GCColumn.Name = "GCColumn"
        Me.GCColumn.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit})
        Me.GCColumn.Size = New System.Drawing.Size(759, 430)
        Me.GCColumn.TabIndex = 3
        Me.GCColumn.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVColumn})
        '
        'GVColumn
        '
        Me.GVColumn.GridControl = Me.GCColumn
        Me.GVColumn.Name = "GVColumn"
        Me.GVColumn.OptionsView.ColumnAutoWidth = False
        Me.GVColumn.OptionsView.RowAutoHeight = True
        Me.GVColumn.OptionsView.ShowGroupPanel = False
        Me.GVColumn.RowHeight = 64
        '
        'RepositoryItemMemoEdit
        '
        Me.RepositoryItemMemoEdit.Name = "RepositoryItemMemoEdit"
        '
        'GCCol
        '
        Me.GCCol.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCCol.Location = New System.Drawing.Point(0, 0)
        Me.GCCol.MainView = Me.GVCol
        Me.GCCol.Name = "GCCol"
        Me.GCCol.Size = New System.Drawing.Size(244, 472)
        Me.GCCol.TabIndex = 4
        Me.GCCol.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVCol})
        '
        'GVCol
        '
        Me.GVCol.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn29})
        Me.GVCol.GridControl = Me.GCCol
        Me.GVCol.Name = "GVCol"
        Me.GVCol.OptionsBehavior.Editable = False
        Me.GVCol.OptionsView.ColumnAutoWidth = False
        Me.GVCol.OptionsView.ShowGroupPanel = False
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "Column Name"
        Me.GridColumn29.FieldName = "column_name"
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.Visible = True
        Me.GridColumn29.VisibleIndex = 0
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.SLUEStore)
        Me.PanelControl1.Controls.Add(Me.TEType)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1008, 52)
        Me.PanelControl1.TabIndex = 5
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(275, 20)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(44, 13)
        Me.LabelControl1.TabIndex = 3
        Me.LabelControl1.Text = "Template"
        '
        'SLUEStore
        '
        Me.SLUEStore.Location = New System.Drawing.Point(330, 17)
        Me.SLUEStore.Name = "SLUEStore"
        Me.SLUEStore.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUEStore.Properties.View = Me.SearchLookUpEdit1View
        Me.SLUEStore.Size = New System.Drawing.Size(198, 20)
        Me.SLUEStore.TabIndex = 2
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "GridColumn1"
        Me.GridColumn1.FieldName = "id_design_column_type"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Template"
        Me.GridColumn2.FieldName = "column_type"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'TEType
        '
        Me.TEType.Location = New System.Drawing.Point(61, 17)
        Me.TEType.Name = "TEType"
        Me.TEType.Properties.ReadOnly = True
        Me.TEType.Size = New System.Drawing.Size(188, 20)
        Me.TEType.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Type"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.SBClose)
        Me.PanelControl2.Controls.Add(Me.SBSave)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 524)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1008, 51)
        Me.PanelControl2.TabIndex = 6
        '
        'SBClose
        '
        Me.SBClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SBClose.Image = CType(resources.GetObject("SBClose.Image"), System.Drawing.Image)
        Me.SBClose.Location = New System.Drawing.Point(840, 16)
        Me.SBClose.Name = "SBClose"
        Me.SBClose.Size = New System.Drawing.Size(75, 23)
        Me.SBClose.TabIndex = 8
        Me.SBClose.Text = "Close"
        '
        'SBSave
        '
        Me.SBSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SBSave.Image = CType(resources.GetObject("SBSave.Image"), System.Drawing.Image)
        Me.SBSave.Location = New System.Drawing.Point(921, 16)
        Me.SBSave.Name = "SBSave"
        Me.SBSave.Size = New System.Drawing.Size(75, 23)
        Me.SBSave.TabIndex = 7
        Me.SBSave.Text = "Save"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 52)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GCCol)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GCColumn)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.PanelControl3)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1008, 472)
        Me.SplitContainerControl1.SplitterPosition = 244
        Me.SplitContainerControl1.TabIndex = 7
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.SBDelete)
        Me.PanelControl3.Controls.Add(Me.SBAdd)
        Me.PanelControl3.Controls.Add(Me.TEAdd)
        Me.PanelControl3.Controls.Add(Me.LabelControl2)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(759, 42)
        Me.PanelControl3.TabIndex = 4
        '
        'SBDelete
        '
        Me.SBDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SBDelete.Image = CType(resources.GetObject("SBDelete.Image"), System.Drawing.Image)
        Me.SBDelete.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.SBDelete.Location = New System.Drawing.Point(710, 8)
        Me.SBDelete.Name = "SBDelete"
        Me.SBDelete.Size = New System.Drawing.Size(37, 23)
        Me.SBDelete.TabIndex = 3
        Me.SBDelete.Text = "Add"
        '
        'SBAdd
        '
        Me.SBAdd.Image = CType(resources.GetObject("SBAdd.Image"), System.Drawing.Image)
        Me.SBAdd.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.SBAdd.Location = New System.Drawing.Point(272, 8)
        Me.SBAdd.Name = "SBAdd"
        Me.SBAdd.Size = New System.Drawing.Size(37, 23)
        Me.SBAdd.TabIndex = 2
        Me.SBAdd.Text = "Add"
        '
        'TEAdd
        '
        Me.TEAdd.Location = New System.Drawing.Point(83, 10)
        Me.TEAdd.Name = "TEAdd"
        Me.TEAdd.Size = New System.Drawing.Size(183, 20)
        Me.TEAdd.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(15, 13)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(57, 13)
        Me.LabelControl2.TabIndex = 0
        Me.LabelControl2.Text = "Add Column"
        '
        'FormDesignColumnMapping
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 575)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormDesignColumnMapping"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Design Column Mapping"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GCColumn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVColumn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCCol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVCol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLUEStore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.TEAdd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCColumn As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVColumn As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemMemoEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents GCCol As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVCol As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Label1 As Label
    Friend WithEvents TEType As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SLUEStore As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SBAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEAdd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SBDelete As DevExpress.XtraEditors.SimpleButton
End Class
