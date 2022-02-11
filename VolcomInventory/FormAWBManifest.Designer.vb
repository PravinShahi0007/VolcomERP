<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAWBManifest
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
        Me.BCompleteWholesale = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TEDraftNo = New DevExpress.XtraEditors.TextEdit()
        Me.TE3PLNo = New DevExpress.XtraEditors.TextEdit()
        Me.TEStore = New DevExpress.XtraEditors.TextEdit()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.TEAwb = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.GCInputAWBManifest = New DevExpress.XtraGrid.GridControl()
        Me.GVInputAWBManifest = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn89 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.GridColumn91 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.GridColumn92 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TEDraftNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TE3PLNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEStore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.TEAwb.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCInputAWBManifest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVInputAWBManifest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BCompleteWholesale
        '
        Me.BCompleteWholesale.Appearance.BackColor = System.Drawing.Color.Blue
        Me.BCompleteWholesale.Appearance.ForeColor = System.Drawing.Color.White
        Me.BCompleteWholesale.Appearance.Options.UseBackColor = True
        Me.BCompleteWholesale.Appearance.Options.UseForeColor = True
        Me.BCompleteWholesale.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.BCompleteWholesale.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BCompleteWholesale.Location = New System.Drawing.Point(0, 532)
        Me.BCompleteWholesale.Name = "BCompleteWholesale"
        Me.BCompleteWholesale.Size = New System.Drawing.Size(967, 32)
        Me.BCompleteWholesale.TabIndex = 15
        Me.BCompleteWholesale.Text = "Update AWB"
        Me.BCompleteWholesale.Visible = False
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.TEStore)
        Me.PanelControl1.Controls.Add(Me.TE3PLNo)
        Me.PanelControl1.Controls.Add(Me.TEDraftNo)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(967, 100)
        Me.PanelControl1.TabIndex = 16
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 16)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Draft Manifest"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 42)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(17, 13)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "3PL"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 68)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl3.TabIndex = 2
        Me.LabelControl3.Text = "Store"
        '
        'TEDraftNo
        '
        Me.TEDraftNo.Location = New System.Drawing.Point(104, 13)
        Me.TEDraftNo.Name = "TEDraftNo"
        Me.TEDraftNo.Properties.ReadOnly = True
        Me.TEDraftNo.Size = New System.Drawing.Size(355, 20)
        Me.TEDraftNo.TabIndex = 3
        '
        'TE3PLNo
        '
        Me.TE3PLNo.Location = New System.Drawing.Point(104, 39)
        Me.TE3PLNo.Name = "TE3PLNo"
        Me.TE3PLNo.Properties.ReadOnly = True
        Me.TE3PLNo.Size = New System.Drawing.Size(296, 20)
        Me.TE3PLNo.TabIndex = 4
        '
        'TEStore
        '
        Me.TEStore.Location = New System.Drawing.Point(104, 65)
        Me.TEStore.Name = "TEStore"
        Me.TEStore.Properties.ReadOnly = True
        Me.TEStore.Size = New System.Drawing.Size(339, 20)
        Me.TEStore.TabIndex = 5
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.TEAwb)
        Me.PanelControl2.Controls.Add(Me.LabelControl6)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 486)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(967, 46)
        Me.PanelControl2.TabIndex = 17
        '
        'TEAwb
        '
        Me.TEAwb.Location = New System.Drawing.Point(71, 13)
        Me.TEAwb.Name = "TEAwb"
        Me.TEAwb.Size = New System.Drawing.Size(355, 20)
        Me.TEAwb.TabIndex = 3
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(12, 16)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl6.TabIndex = 0
        Me.LabelControl6.Text = "AWB / Resi"
        '
        'GCInputAWBManifest
        '
        Me.GCInputAWBManifest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCInputAWBManifest.Location = New System.Drawing.Point(0, 100)
        Me.GCInputAWBManifest.MainView = Me.GVInputAWBManifest
        Me.GCInputAWBManifest.Name = "GCInputAWBManifest"
        Me.GCInputAWBManifest.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit1, Me.RepositoryItemMemoEdit2, Me.RepositoryItemMemoEdit3})
        Me.GCInputAWBManifest.Size = New System.Drawing.Size(967, 386)
        Me.GCInputAWBManifest.TabIndex = 18
        Me.GCInputAWBManifest.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVInputAWBManifest})
        '
        'GVInputAWBManifest
        '
        Me.GVInputAWBManifest.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn89, Me.GridColumn91, Me.GridColumn92})
        Me.GVInputAWBManifest.GridControl = Me.GCInputAWBManifest
        Me.GVInputAWBManifest.Name = "GVInputAWBManifest"
        Me.GVInputAWBManifest.OptionsBehavior.Editable = False
        Me.GVInputAWBManifest.OptionsView.RowAutoHeight = True
        Me.GVInputAWBManifest.OptionsView.ShowGroupPanel = False
        '
        'GridColumn89
        '
        Me.GridColumn89.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn89.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn89.Caption = "Invoice Number"
        Me.GridColumn89.ColumnEdit = Me.RepositoryItemMemoEdit3
        Me.GridColumn89.FieldName = "inv_number"
        Me.GridColumn89.MinWidth = 10
        Me.GridColumn89.Name = "GridColumn89"
        Me.GridColumn89.Visible = True
        Me.GridColumn89.VisibleIndex = 1
        Me.GridColumn89.Width = 200
        '
        'RepositoryItemMemoEdit3
        '
        Me.RepositoryItemMemoEdit3.Name = "RepositoryItemMemoEdit3"
        '
        'GridColumn91
        '
        Me.GridColumn91.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn91.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn91.Caption = "Delivery Order Number"
        Me.GridColumn91.ColumnEdit = Me.RepositoryItemMemoEdit2
        Me.GridColumn91.FieldName = "do_number"
        Me.GridColumn91.MinWidth = 10
        Me.GridColumn91.Name = "GridColumn91"
        Me.GridColumn91.Visible = True
        Me.GridColumn91.VisibleIndex = 0
        Me.GridColumn91.Width = 200
        '
        'RepositoryItemMemoEdit2
        '
        Me.RepositoryItemMemoEdit2.Name = "RepositoryItemMemoEdit2"
        '
        'GridColumn92
        '
        Me.GridColumn92.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn92.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn92.Caption = "Rec Payment Number"
        Me.GridColumn92.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.GridColumn92.FieldName = "bbm_number"
        Me.GridColumn92.MinWidth = 10
        Me.GridColumn92.Name = "GridColumn92"
        Me.GridColumn92.Visible = True
        Me.GridColumn92.VisibleIndex = 2
        Me.GridColumn92.Width = 200
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'FormAWBManifest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(967, 564)
        Me.Controls.Add(Me.GCInputAWBManifest)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.BCompleteWholesale)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAWBManifest"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Input AWB"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.TEDraftNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TE3PLNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEStore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.TEAwb.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCInputAWBManifest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVInputAWBManifest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BCompleteWholesale As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEStore As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TE3PLNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEDraftNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TEAwb As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCInputAWBManifest As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVInputAWBManifest As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn89 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents GridColumn91 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents GridColumn92 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
End Class
