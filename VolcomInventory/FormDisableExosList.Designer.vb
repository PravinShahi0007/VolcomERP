<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDisableExosList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDisableExosList))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.CESelectAll = New DevExpress.XtraEditors.CheckEdit()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_design = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnclass = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsht = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncolor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnis_select = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.CESelectAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.CESelectAll)
        Me.PanelControl1.Controls.Add(Me.BtnClose)
        Me.PanelControl1.Controls.Add(Me.BtnAdd)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 308)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(541, 46)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnAdd
        '
        Me.BtnAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"), System.Drawing.Image)
        Me.BtnAdd.Location = New System.Drawing.Point(464, 2)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(75, 42)
        Me.BtnAdd.TabIndex = 1
        Me.BtnAdd.Text = "Add"
        '
        'BtnClose
        '
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(376, 2)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(88, 42)
        Me.BtnClose.TabIndex = 2
        Me.BtnClose.Text = "Discard"
        '
        'CESelectAll
        '
        Me.CESelectAll.Location = New System.Drawing.Point(12, 13)
        Me.CESelectAll.Name = "CESelectAll"
        Me.CESelectAll.Properties.Caption = "Select All"
        Me.CESelectAll.Size = New System.Drawing.Size(75, 19)
        Me.CESelectAll.TabIndex = 1
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCData.Size = New System.Drawing.Size(541, 308)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_design, Me.GridColumncode, Me.GridColumnclass, Me.GridColumnname, Me.GridColumnsht, Me.GridColumncolor, Me.GridColumnis_select})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_design
        '
        Me.GridColumnid_design.Caption = "id_design"
        Me.GridColumnid_design.FieldName = "id_design"
        Me.GridColumnid_design.Name = "GridColumnid_design"
        Me.GridColumnid_design.OptionsColumn.AllowEdit = False
        '
        'GridColumncode
        '
        Me.GridColumncode.Caption = "Code"
        Me.GridColumncode.FieldName = "code"
        Me.GridColumncode.Name = "GridColumncode"
        Me.GridColumncode.OptionsColumn.AllowEdit = False
        Me.GridColumncode.Visible = True
        Me.GridColumncode.VisibleIndex = 0
        '
        'GridColumnclass
        '
        Me.GridColumnclass.Caption = "Class"
        Me.GridColumnclass.FieldName = "class"
        Me.GridColumnclass.Name = "GridColumnclass"
        Me.GridColumnclass.OptionsColumn.AllowEdit = False
        Me.GridColumnclass.Visible = True
        Me.GridColumnclass.VisibleIndex = 1
        '
        'GridColumnname
        '
        Me.GridColumnname.Caption = "Description"
        Me.GridColumnname.FieldName = "name"
        Me.GridColumnname.Name = "GridColumnname"
        Me.GridColumnname.OptionsColumn.AllowEdit = False
        Me.GridColumnname.Visible = True
        Me.GridColumnname.VisibleIndex = 2
        '
        'GridColumnsht
        '
        Me.GridColumnsht.Caption = "Silhouette"
        Me.GridColumnsht.FieldName = "sht"
        Me.GridColumnsht.Name = "GridColumnsht"
        Me.GridColumnsht.OptionsColumn.AllowEdit = False
        Me.GridColumnsht.Visible = True
        Me.GridColumnsht.VisibleIndex = 3
        '
        'GridColumncolor
        '
        Me.GridColumncolor.Caption = "Color"
        Me.GridColumncolor.FieldName = "color"
        Me.GridColumncolor.Name = "GridColumncolor"
        Me.GridColumncolor.OptionsColumn.AllowEdit = False
        Me.GridColumncolor.Visible = True
        Me.GridColumncolor.VisibleIndex = 4
        '
        'GridColumnis_select
        '
        Me.GridColumnis_select.Caption = "Select"
        Me.GridColumnis_select.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnis_select.FieldName = "is_select"
        Me.GridColumnis_select.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right
        Me.GridColumnis_select.Name = "GridColumnis_select"
        Me.GridColumnis_select.Visible = True
        Me.GridColumnis_select.VisibleIndex = 5
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'FormDisableExosList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(541, 354)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormDisableExosList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Extended EOS Product List"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.CESelectAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CESelectAll As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_design As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnclass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsht As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncolor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnis_select As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
End Class
