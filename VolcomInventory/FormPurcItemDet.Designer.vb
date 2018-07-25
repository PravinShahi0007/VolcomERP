<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPurcItemDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPurcItemDet))
        Me.XTCDetail = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.CETrackStock = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEUOM = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SLECat = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TEDesc = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.TECode = New DevExpress.XtraEditors.TextEdit()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCDetail.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.CETrackStock.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEUOM.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLECat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDesc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCDetail
        '
        Me.XTCDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCDetail.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCDetail.Location = New System.Drawing.Point(0, 0)
        Me.XTCDetail.Name = "XTCDetail"
        Me.XTCDetail.SelectedTabPage = Me.XtraTabPage1
        Me.XTCDetail.Size = New System.Drawing.Size(400, 212)
        Me.XTCDetail.TabIndex = 0
        Me.XTCDetail.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.PanelControl1)
        Me.XtraTabPage1.Controls.Add(Me.CETrackStock)
        Me.XtraTabPage1.Controls.Add(Me.LabelControl4)
        Me.XtraTabPage1.Controls.Add(Me.SLEUOM)
        Me.XtraTabPage1.Controls.Add(Me.SLECat)
        Me.XtraTabPage1.Controls.Add(Me.LabelControl2)
        Me.XtraTabPage1.Controls.Add(Me.TEDesc)
        Me.XtraTabPage1.Controls.Add(Me.LabelControl1)
        Me.XtraTabPage1.Controls.Add(Me.LabelControl11)
        Me.XtraTabPage1.Controls.Add(Me.TECode)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(394, 184)
        Me.XtraTabPage1.Text = "Detail"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BClose)
        Me.PanelControl1.Controls.Add(Me.BSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 144)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(394, 40)
        Me.PanelControl1.TabIndex = 8902
        '
        'BClose
        '
        Me.BClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BClose.Image = CType(resources.GetObject("BClose.Image"), System.Drawing.Image)
        Me.BClose.Location = New System.Drawing.Point(207, 2)
        Me.BClose.Name = "BClose"
        Me.BClose.Size = New System.Drawing.Size(96, 36)
        Me.BClose.TabIndex = 1
        Me.BClose.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.Image = CType(resources.GetObject("BSave.Image"), System.Drawing.Image)
        Me.BSave.Location = New System.Drawing.Point(303, 2)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(89, 36)
        Me.BSave.TabIndex = 0
        Me.BSave.Text = "Save"
        '
        'CETrackStock
        '
        Me.CETrackStock.Location = New System.Drawing.Point(70, 101)
        Me.CETrackStock.Name = "CETrackStock"
        Me.CETrackStock.Properties.Caption = "Track Stok"
        Me.CETrackStock.Size = New System.Drawing.Size(78, 19)
        Me.CETrackStock.TabIndex = 8901
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(174, 103)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl4.TabIndex = 8900
        Me.LabelControl4.Text = "UOM"
        '
        'SLEUOM
        '
        Me.SLEUOM.Location = New System.Drawing.Point(203, 100)
        Me.SLEUOM.Name = "SLEUOM"
        Me.SLEUOM.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEUOM.Properties.View = Me.GridView1
        Me.SLEUOM.Size = New System.Drawing.Size(156, 20)
        Me.SLEUOM.TabIndex = 8899
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn3})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID UOM"
        Me.GridColumn1.FieldName = "id_uom"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "UOM"
        Me.GridColumn3.FieldName = "uom"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        '
        'SLECat
        '
        Me.SLECat.Location = New System.Drawing.Point(70, 72)
        Me.SLECat.Name = "SLECat"
        Me.SLECat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLECat.Properties.View = Me.SearchLookUpEdit1View
        Me.SLECat.Size = New System.Drawing.Size(289, 20)
        Me.SLECat.TabIndex = 8897
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.GridColumn4})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(11, 75)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl2.TabIndex = 8896
        Me.LabelControl2.Text = "Category"
        '
        'TEDesc
        '
        Me.TEDesc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TEDesc.EditValue = ""
        Me.TEDesc.Location = New System.Drawing.Point(70, 44)
        Me.TEDesc.Name = "TEDesc"
        Me.TEDesc.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEDesc.Properties.Appearance.Options.UseFont = True
        Me.TEDesc.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.TEDesc.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TEDesc.Properties.EditValueChangedDelay = 1
        Me.TEDesc.Size = New System.Drawing.Size(289, 20)
        Me.TEDesc.TabIndex = 8895
        Me.TEDesc.TabStop = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(11, 46)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl1.TabIndex = 8894
        Me.LabelControl1.Text = "Description"
        '
        'LabelControl11
        '
        Me.LabelControl11.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl11.Location = New System.Drawing.Point(11, 18)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl11.TabIndex = 8891
        Me.LabelControl11.Text = "Item Code"
        '
        'TECode
        '
        Me.TECode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TECode.EditValue = ""
        Me.TECode.Enabled = False
        Me.TECode.Location = New System.Drawing.Point(70, 15)
        Me.TECode.Name = "TECode"
        Me.TECode.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TECode.Properties.Appearance.Options.UseFont = True
        Me.TECode.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.TECode.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TECode.Properties.EditValueChangedDelay = 1
        Me.TECode.Properties.ReadOnly = True
        Me.TECode.Size = New System.Drawing.Size(289, 20)
        Me.TECode.TabIndex = 8892
        Me.TECode.TabStop = False
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "ID Cat"
        Me.GridColumn2.FieldName = "id_item_cat"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Item Category"
        Me.GridColumn4.FieldName = "item_cat"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 0
        '
        'FormPurcItemDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 212)
        Me.Controls.Add(Me.XTCDetail)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPurcItemDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Item Detail"
        CType(Me.XTCDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCDetail.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        Me.XtraTabPage1.PerformLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.CETrackStock.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEUOM.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLECat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDesc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCDetail As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TECode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEDesc As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CETrackStock As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEUOM As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SLECat As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
End Class
