<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGDistSchemaSetup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFGDistSchemaSetup))
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl
        Me.GroupControlAlloc = New DevExpress.XtraEditors.GroupControl
        Me.GCAlloc = New DevExpress.XtraGrid.GridControl
        Me.GVAlloc = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnAlloc = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIncludeSO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.PanelControlNavAlloc = New DevExpress.XtraEditors.PanelControl
        Me.BtnDel = New DevExpress.XtraEditors.SimpleButton
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BtnEdit = New DevExpress.XtraEditors.SimpleButton
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton
        Me.GroupControlComp = New DevExpress.XtraEditors.GroupControl
        Me.GCCompList = New DevExpress.XtraGrid.GridControl
        Me.GVCompList = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnCompName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.BtnDeleteComp = New DevExpress.XtraEditors.SimpleButton
        Me.BtnAddComp = New DevExpress.XtraEditors.SimpleButton
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GroupControlAlloc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlAlloc.SuspendLayout()
        CType(Me.GCAlloc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAlloc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlNavAlloc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNavAlloc.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlComp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlComp.SuspendLayout()
        CType(Me.GCCompList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVCompList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GroupControlAlloc)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GroupControlComp)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(790, 435)
        Me.SplitContainerControl1.SplitterPosition = 442
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'GroupControlAlloc
        '
        Me.GroupControlAlloc.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlAlloc.Controls.Add(Me.GCAlloc)
        Me.GroupControlAlloc.Controls.Add(Me.PanelControlNavAlloc)
        Me.GroupControlAlloc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlAlloc.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlAlloc.Name = "GroupControlAlloc"
        Me.GroupControlAlloc.Size = New System.Drawing.Size(442, 435)
        Me.GroupControlAlloc.TabIndex = 0
        Me.GroupControlAlloc.Text = "Allocation Group"
        '
        'GCAlloc
        '
        Me.GCAlloc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAlloc.Location = New System.Drawing.Point(22, 38)
        Me.GCAlloc.MainView = Me.GVAlloc
        Me.GCAlloc.Name = "GCAlloc"
        Me.GCAlloc.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCAlloc.Size = New System.Drawing.Size(418, 395)
        Me.GCAlloc.TabIndex = 1
        Me.GCAlloc.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAlloc})
        '
        'GVAlloc
        '
        Me.GVAlloc.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnAlloc, Me.GridColumnIncludeSO})
        Me.GVAlloc.GridControl = Me.GCAlloc
        Me.GVAlloc.Name = "GVAlloc"
        Me.GVAlloc.OptionsView.ShowGroupPanel = False
        '
        'GridColumnAlloc
        '
        Me.GridColumnAlloc.Caption = "Allocation"
        Me.GridColumnAlloc.FieldName = "pd_alloc"
        Me.GridColumnAlloc.Name = "GridColumnAlloc"
        Me.GridColumnAlloc.OptionsColumn.ReadOnly = True
        Me.GridColumnAlloc.Visible = True
        Me.GridColumnAlloc.VisibleIndex = 0
        '
        'GridColumnIncludeSO
        '
        Me.GridColumnIncludeSO.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnIncludeSO.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnIncludeSO.Caption = "Include Sales Order"
        Me.GridColumnIncludeSO.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnIncludeSO.FieldName = "answer"
        Me.GridColumnIncludeSO.Name = "GridColumnIncludeSO"
        Me.GridColumnIncludeSO.OptionsColumn.ReadOnly = True
        Me.GridColumnIncludeSO.Visible = True
        Me.GridColumnIncludeSO.VisibleIndex = 1
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'PanelControlNavAlloc
        '
        Me.PanelControlNavAlloc.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlNavAlloc.Controls.Add(Me.BtnDel)
        Me.PanelControlNavAlloc.Controls.Add(Me.BtnEdit)
        Me.PanelControlNavAlloc.Controls.Add(Me.BtnAdd)
        Me.PanelControlNavAlloc.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlNavAlloc.Location = New System.Drawing.Point(22, 2)
        Me.PanelControlNavAlloc.Name = "PanelControlNavAlloc"
        Me.PanelControlNavAlloc.Size = New System.Drawing.Size(418, 36)
        Me.PanelControlNavAlloc.TabIndex = 0
        '
        'BtnDel
        '
        Me.BtnDel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDel.ImageIndex = 1
        Me.BtnDel.ImageList = Me.LargeImageCollection
        Me.BtnDel.Location = New System.Drawing.Point(145, 0)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(91, 36)
        Me.BtnDel.TabIndex = 10
        Me.BtnDel.Text = "Delete"
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
        Me.LargeImageCollection.Images.SetKeyName(10, "10_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(11, "18_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(12, "31_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(13, "folder-documents-icon.png")
        Me.LargeImageCollection.Images.SetKeyName(14, "mail_attachment.png")
        Me.LargeImageCollection.Images.SetKeyName(15, "1417618546_Blue tag.png")
        Me.LargeImageCollection.Images.SetKeyName(16, "attachment-icon.png")
        '
        'BtnEdit
        '
        Me.BtnEdit.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnEdit.ImageIndex = 2
        Me.BtnEdit.ImageList = Me.LargeImageCollection
        Me.BtnEdit.Location = New System.Drawing.Point(236, 0)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(91, 36)
        Me.BtnEdit.TabIndex = 9
        Me.BtnEdit.Text = "Edit"
        '
        'BtnAdd
        '
        Me.BtnAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAdd.ImageIndex = 0
        Me.BtnAdd.ImageList = Me.LargeImageCollection
        Me.BtnAdd.Location = New System.Drawing.Point(327, 0)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(91, 36)
        Me.BtnAdd.TabIndex = 8
        Me.BtnAdd.Text = "Add"
        '
        'GroupControlComp
        '
        Me.GroupControlComp.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlComp.Controls.Add(Me.GCCompList)
        Me.GroupControlComp.Controls.Add(Me.PanelControl1)
        Me.GroupControlComp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlComp.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlComp.Name = "GroupControlComp"
        Me.GroupControlComp.Size = New System.Drawing.Size(343, 435)
        Me.GroupControlComp.TabIndex = 1
        Me.GroupControlComp.Text = "Company List"
        '
        'GCCompList
        '
        Me.GCCompList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCCompList.Location = New System.Drawing.Point(22, 38)
        Me.GCCompList.MainView = Me.GVCompList
        Me.GCCompList.Name = "GCCompList"
        Me.GCCompList.Size = New System.Drawing.Size(319, 395)
        Me.GCCompList.TabIndex = 1
        Me.GCCompList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVCompList})
        '
        'GVCompList
        '
        Me.GVCompList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnCompName})
        Me.GVCompList.GridControl = Me.GCCompList
        Me.GVCompList.Name = "GVCompList"
        Me.GVCompList.OptionsBehavior.ReadOnly = True
        Me.GVCompList.OptionsView.ShowGroupPanel = False
        '
        'GridColumnCompName
        '
        Me.GridColumnCompName.Caption = "Company/Dept"
        Me.GridColumnCompName.FieldName = "comp_name"
        Me.GridColumnCompName.Name = "GridColumnCompName"
        Me.GridColumnCompName.Visible = True
        Me.GridColumnCompName.VisibleIndex = 0
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.BtnDeleteComp)
        Me.PanelControl1.Controls.Add(Me.BtnAddComp)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(22, 2)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(319, 36)
        Me.PanelControl1.TabIndex = 2
        '
        'BtnDeleteComp
        '
        Me.BtnDeleteComp.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDeleteComp.ImageIndex = 1
        Me.BtnDeleteComp.ImageList = Me.LargeImageCollection
        Me.BtnDeleteComp.Location = New System.Drawing.Point(137, 0)
        Me.BtnDeleteComp.Name = "BtnDeleteComp"
        Me.BtnDeleteComp.Size = New System.Drawing.Size(91, 36)
        Me.BtnDeleteComp.TabIndex = 10
        Me.BtnDeleteComp.Text = "Delete"
        '
        'BtnAddComp
        '
        Me.BtnAddComp.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAddComp.ImageIndex = 0
        Me.BtnAddComp.ImageList = Me.LargeImageCollection
        Me.BtnAddComp.Location = New System.Drawing.Point(228, 0)
        Me.BtnAddComp.Name = "BtnAddComp"
        Me.BtnAddComp.Size = New System.Drawing.Size(91, 36)
        Me.BtnAddComp.TabIndex = 8
        Me.BtnAddComp.Text = "Add"
        '
        'FormFGDistSchemaSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 435)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Name = "FormFGDistSchemaSetup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Distribution Schema Setup"
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GroupControlAlloc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlAlloc.ResumeLayout(False)
        CType(Me.GCAlloc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAlloc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlNavAlloc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNavAlloc.ResumeLayout(False)
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlComp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlComp.ResumeLayout(False)
        CType(Me.GCCompList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVCompList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControlAlloc As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCAlloc As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAlloc As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControlNavAlloc As DevExpress.XtraEditors.PanelControl
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents BtnDel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControlComp As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCCompList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVCompList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnAlloc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIncludeSO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnCompName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnDeleteComp As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAddComp As DevExpress.XtraEditors.SimpleButton
End Class
