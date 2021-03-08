<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormODMPrintPick
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormODMPrintPick))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BCreateManifest = New DevExpress.XtraEditors.SimpleButton()
        Me.BClose = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.GCDOERP = New DevExpress.XtraGrid.GridControl()
        Me.GVDOERP = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn32 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn33 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumncombine_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SLUE3PL = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BView = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GCDOERP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDOERP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLUE3PL.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BClose)
        Me.PanelControl1.Controls.Add(Me.BCreateManifest)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 456)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(895, 49)
        Me.PanelControl1.TabIndex = 0
        '
        'BCreateManifest
        '
        Me.BCreateManifest.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCreateManifest.Image = CType(resources.GetObject("BCreateManifest.Image"), System.Drawing.Image)
        Me.BCreateManifest.Location = New System.Drawing.Point(741, 2)
        Me.BCreateManifest.Name = "BCreateManifest"
        Me.BCreateManifest.Size = New System.Drawing.Size(152, 45)
        Me.BCreateManifest.TabIndex = 0
        Me.BCreateManifest.Text = "Create Manifest"
        '
        'BClose
        '
        Me.BClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BClose.Image = CType(resources.GetObject("BClose.Image"), System.Drawing.Image)
        Me.BClose.Location = New System.Drawing.Point(644, 2)
        Me.BClose.Name = "BClose"
        Me.BClose.Size = New System.Drawing.Size(97, 45)
        Me.BClose.TabIndex = 1
        Me.BClose.Text = "Close"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BView)
        Me.PanelControl2.Controls.Add(Me.SLUE3PL)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(895, 46)
        Me.PanelControl2.TabIndex = 2
        '
        'GCDOERP
        '
        Me.GCDOERP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDOERP.Location = New System.Drawing.Point(0, 46)
        Me.GCDOERP.MainView = Me.GVDOERP
        Me.GCDOERP.Name = "GCDOERP"
        Me.GCDOERP.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCDOERP.Size = New System.Drawing.Size(895, 410)
        Me.GCDOERP.TabIndex = 6
        Me.GCDOERP.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDOERP})
        '
        'GVDOERP
        '
        Me.GVDOERP.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.GridColumn1, Me.GridColumn32, Me.GridColumn33, Me.GridColumncombine_number})
        Me.GVDOERP.GridControl = Me.GCDOERP
        Me.GVDOERP.Name = "GVDOERP"
        Me.GVDOERP.OptionsCustomization.AllowColumnMoving = False
        Me.GVDOERP.OptionsCustomization.AllowColumnResizing = False
        Me.GVDOERP.OptionsCustomization.AllowGroup = False
        Me.GVDOERP.OptionsCustomization.AllowQuickHideColumns = False
        Me.GVDOERP.OptionsCustomization.AllowRowSizing = True
        Me.GVDOERP.OptionsCustomization.CustomizationFormSearchBoxVisible = True
        Me.GVDOERP.OptionsView.ShowGroupPanel = False
        '
        'GridColumn32
        '
        Me.GridColumn32.Caption = "AWB Number"
        Me.GridColumn32.FieldName = "awbill_no"
        Me.GridColumn32.Name = "GridColumn32"
        Me.GridColumn32.OptionsColumn.AllowEdit = False
        Me.GridColumn32.OptionsColumn.AllowFocus = False
        Me.GridColumn32.Visible = True
        Me.GridColumn32.VisibleIndex = 1
        Me.GridColumn32.Width = 620
        '
        'GridColumn33
        '
        Me.GridColumn33.Caption = "Scan Date"
        Me.GridColumn33.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn33.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn33.FieldName = "created_date"
        Me.GridColumn33.Name = "GridColumn33"
        Me.GridColumn33.OptionsColumn.AllowEdit = False
        Me.GridColumn33.OptionsColumn.AllowFocus = False
        Me.GridColumn33.Visible = True
        Me.GridColumn33.VisibleIndex = 3
        Me.GridColumn33.Width = 523
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "no"
        '
        'GridColumncombine_number
        '
        Me.GridColumncombine_number.Caption = "Scan By"
        Me.GridColumncombine_number.FieldName = "employee_name"
        Me.GridColumncombine_number.Name = "GridColumncombine_number"
        Me.GridColumncombine_number.OptionsColumn.AllowEdit = False
        Me.GridColumncombine_number.Visible = True
        Me.GridColumncombine_number.VisibleIndex = 2
        Me.GridColumncombine_number.Width = 326
        '
        'SLUE3PL
        '
        Me.SLUE3PL.Location = New System.Drawing.Point(35, 12)
        Me.SLUE3PL.Name = "SLUE3PL"
        Me.SLUE3PL.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUE3PL.Properties.View = Me.SearchLookUpEdit1View
        Me.SLUE3PL.Size = New System.Drawing.Size(211, 20)
        Me.SLUE3PL.TabIndex = 12
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn9, Me.GridColumn10})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn9
        '
        Me.GridColumn9.FieldName = "id_comp"
        Me.GridColumn9.Name = "GridColumn9"
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "3PL"
        Me.GridColumn10.FieldName = "comp_name"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(17, 13)
        Me.LabelControl1.TabIndex = 11
        Me.LabelControl1.Text = "3PL"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "id_odm_sc"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'BView
        '
        Me.BView.Location = New System.Drawing.Point(252, 10)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(54, 23)
        Me.BView.TabIndex = 13
        Me.BView.Text = "view"
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.Caption = "*"
        Me.GridColumn2.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumn2.FieldName = "is_check"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 147
        '
        'FormODMPrintPick
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(895, 505)
        Me.Controls.Add(Me.GCDOERP)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormODMPrintPick"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick AWB"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.GCDOERP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDOERP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLUE3PL.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BCreateManifest As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCDOERP As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDOERP As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn32 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn33 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumncombine_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLUE3PL As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
End Class
