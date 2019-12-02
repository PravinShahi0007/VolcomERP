<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMatPurchasePDDup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMatPurchasePDDup))
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.TEUOM = New DevExpress.XtraEditors.TextEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TEConsumption = New DevExpress.XtraEditors.TextEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SLEMaterial = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.TEUOM.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEConsumption.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEMaterial.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BClose)
        Me.PanelControl2.Controls.Add(Me.BSave)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 72)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(311, 44)
        Me.PanelControl2.TabIndex = 2
        '
        'BClose
        '
        Me.BClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BClose.Image = CType(resources.GetObject("BClose.Image"), System.Drawing.Image)
        Me.BClose.Location = New System.Drawing.Point(111, 2)
        Me.BClose.Name = "BClose"
        Me.BClose.Size = New System.Drawing.Size(94, 40)
        Me.BClose.TabIndex = 1
        Me.BClose.Text = "Back"
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.Image = CType(resources.GetObject("BSave.Image"), System.Drawing.Image)
        Me.BSave.Location = New System.Drawing.Point(205, 2)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(104, 40)
        Me.BSave.TabIndex = 0
        Me.BSave.Text = "Duplicate"
        '
        'TEUOM
        '
        Me.TEUOM.Enabled = False
        Me.TEUOM.Location = New System.Drawing.Point(239, 38)
        Me.TEUOM.Name = "TEUOM"
        Me.TEUOM.Size = New System.Drawing.Size(60, 20)
        Me.TEUOM.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Consumption"
        '
        'TEConsumption
        '
        Me.TEConsumption.Location = New System.Drawing.Point(91, 38)
        Me.TEConsumption.Name = "TEConsumption"
        Me.TEConsumption.Size = New System.Drawing.Size(142, 20)
        Me.TEConsumption.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Select Material"
        '
        'SLEMaterial
        '
        Me.SLEMaterial.Location = New System.Drawing.Point(91, 12)
        Me.SLEMaterial.Name = "SLEMaterial"
        Me.SLEMaterial.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEMaterial.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEMaterial.Size = New System.Drawing.Size(208, 20)
        Me.SLEMaterial.TabIndex = 5
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn12})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "ID Det"
        Me.GridColumn7.FieldName = "id_mat_det"
        Me.GridColumn7.Name = "GridColumn7"
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "ID mat"
        Me.GridColumn8.FieldName = "id_mat"
        Me.GridColumn8.Name = "GridColumn8"
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Material Code"
        Me.GridColumn9.FieldName = "mat_det_code"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 0
        Me.GridColumn9.Width = 331
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Material"
        Me.GridColumn10.FieldName = "mat_det_display_name"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 1
        Me.GridColumn10.Width = 1109
        '
        'GridColumn12
        '
        Me.GridColumn12.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn12.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn12.Caption = "UOM"
        Me.GridColumn12.FieldName = "uom"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 2
        Me.GridColumn12.Width = 192
        '
        'FormMatPurchasePDDup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(311, 116)
        Me.Controls.Add(Me.TEUOM)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TEConsumption)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SLEMaterial)
        Me.Controls.Add(Me.PanelControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMatPurchasePDDup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Duplicate List"
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.TEUOM.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEConsumption.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEMaterial.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEUOM As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents TEConsumption As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents SLEMaterial As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
End Class
