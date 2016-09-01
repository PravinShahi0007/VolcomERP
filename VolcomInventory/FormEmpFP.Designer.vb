<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpFP
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
        Me.GCFP = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddMachineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditMachineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteMachineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVFP = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPort = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFPRegister = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.DownloadTemplateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.GCFP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GVFP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCFP
        '
        Me.GCFP.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GCFP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCFP.Location = New System.Drawing.Point(0, 0)
        Me.GCFP.MainView = Me.GVFP
        Me.GCFP.Name = "GCFP"
        Me.GCFP.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCFP.Size = New System.Drawing.Size(519, 262)
        Me.GCFP.TabIndex = 1
        Me.GCFP.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVFP})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddMachineToolStripMenuItem, Me.EditMachineToolStripMenuItem, Me.DeleteMachineToolStripMenuItem, Me.ToolStripMenuItem1, Me.DownloadTemplateToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(199, 136)
        '
        'AddMachineToolStripMenuItem
        '
        Me.AddMachineToolStripMenuItem.Name = "AddMachineToolStripMenuItem"
        Me.AddMachineToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.AddMachineToolStripMenuItem.Text = "Add Machine"
        '
        'EditMachineToolStripMenuItem
        '
        Me.EditMachineToolStripMenuItem.Name = "EditMachineToolStripMenuItem"
        Me.EditMachineToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.EditMachineToolStripMenuItem.Text = "Edit Machine"
        '
        'DeleteMachineToolStripMenuItem
        '
        Me.DeleteMachineToolStripMenuItem.Name = "DeleteMachineToolStripMenuItem"
        Me.DeleteMachineToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.DeleteMachineToolStripMenuItem.Text = "Delete Machine"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(198, 22)
        Me.ToolStripMenuItem1.Text = "Set as Register Machine"
        '
        'GVFP
        '
        Me.GVFP.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnId, Me.GridColumnName, Me.GridColumnSN, Me.GridColumnIP, Me.GridColumnPort, Me.GridColumnFPRegister})
        Me.GVFP.GridControl = Me.GCFP
        Me.GVFP.Name = "GVFP"
        Me.GVFP.OptionsBehavior.Editable = False
        Me.GVFP.OptionsView.ShowGroupPanel = False
        '
        'GridColumnId
        '
        Me.GridColumnId.Caption = "Id"
        Me.GridColumnId.FieldName = "id_fingerprint"
        Me.GridColumnId.Name = "GridColumnId"
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Name"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 0
        '
        'GridColumnSN
        '
        Me.GridColumnSN.Caption = "Serial Number"
        Me.GridColumnSN.FieldName = "sn"
        Me.GridColumnSN.Name = "GridColumnSN"
        Me.GridColumnSN.Visible = True
        Me.GridColumnSN.VisibleIndex = 1
        '
        'GridColumnIP
        '
        Me.GridColumnIP.Caption = "IP"
        Me.GridColumnIP.FieldName = "ip"
        Me.GridColumnIP.Name = "GridColumnIP"
        Me.GridColumnIP.Visible = True
        Me.GridColumnIP.VisibleIndex = 2
        '
        'GridColumnPort
        '
        Me.GridColumnPort.Caption = "Port"
        Me.GridColumnPort.FieldName = "port"
        Me.GridColumnPort.Name = "GridColumnPort"
        Me.GridColumnPort.Visible = True
        Me.GridColumnPort.VisibleIndex = 3
        '
        'GridColumnFPRegister
        '
        Me.GridColumnFPRegister.Caption = "Register Machine"
        Me.GridColumnFPRegister.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnFPRegister.FieldName = "register"
        Me.GridColumnFPRegister.Name = "GridColumnFPRegister"
        Me.GridColumnFPRegister.Visible = True
        Me.GridColumnFPRegister.VisibleIndex = 4
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'DownloadTemplateToolStripMenuItem
        '
        Me.DownloadTemplateToolStripMenuItem.Name = "DownloadTemplateToolStripMenuItem"
        Me.DownloadTemplateToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.DownloadTemplateToolStripMenuItem.Text = "Download Template"
        '
        'FormEmpFP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(519, 262)
        Me.Controls.Add(Me.GCFP)
        Me.Name = "FormEmpFP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fingerprint Setup"
        CType(Me.GCFP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GVFP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCFP As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVFP As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPort As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFPRegister As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents AddMachineToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditMachineToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteMachineToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DownloadTemplateToolStripMenuItem As ToolStripMenuItem
End Class
