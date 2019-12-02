<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormItemSubCatDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormItemSubCatDet))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.LBudgetCat = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TEPurchaseCategory = New DevExpress.XtraEditors.TextEdit()
        Me.SLEBudgetCat = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SLEVendorType = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TEPurchaseCategory.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEBudgetCat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEVendorType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BClose)
        Me.PanelControl1.Controls.Add(Me.BSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 127)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(413, 40)
        Me.PanelControl1.TabIndex = 0
        '
        'BClose
        '
        Me.BClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BClose.Image = CType(resources.GetObject("BClose.Image"), System.Drawing.Image)
        Me.BClose.Location = New System.Drawing.Point(209, 2)
        Me.BClose.Name = "BClose"
        Me.BClose.Size = New System.Drawing.Size(101, 36)
        Me.BClose.TabIndex = 1
        Me.BClose.Text = "Close"
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.Image = CType(resources.GetObject("BSave.Image"), System.Drawing.Image)
        Me.BSave.Location = New System.Drawing.Point(310, 2)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(101, 36)
        Me.BSave.TabIndex = 0
        Me.BSave.Text = "Save"
        '
        'LBudgetCat
        '
        Me.LBudgetCat.Location = New System.Drawing.Point(20, 90)
        Me.LBudgetCat.Name = "LBudgetCat"
        Me.LBudgetCat.Size = New System.Drawing.Size(82, 13)
        Me.LBudgetCat.TabIndex = 1
        Me.LBudgetCat.Text = "Budget Category"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(20, 51)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Vendor Type"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(20, 15)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(92, 13)
        Me.LabelControl3.TabIndex = 3
        Me.LabelControl3.Text = "Purchase Category"
        '
        'TEPurchaseCategory
        '
        Me.TEPurchaseCategory.Location = New System.Drawing.Point(131, 12)
        Me.TEPurchaseCategory.Name = "TEPurchaseCategory"
        Me.TEPurchaseCategory.Size = New System.Drawing.Size(257, 20)
        Me.TEPurchaseCategory.TabIndex = 4
        '
        'SLEBudgetCat
        '
        Me.SLEBudgetCat.Location = New System.Drawing.Point(131, 87)
        Me.SLEBudgetCat.Name = "SLEBudgetCat"
        Me.SLEBudgetCat.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLEBudgetCat.Properties.Appearance.Options.UseFont = True
        Me.SLEBudgetCat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEBudgetCat.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEBudgetCat.Size = New System.Drawing.Size(257, 20)
        Me.SLEBudgetCat.TabIndex = 8906
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn4, Me.GridColumn5})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'SLEVendorType
        '
        Me.SLEVendorType.Location = New System.Drawing.Point(131, 48)
        Me.SLEVendorType.Name = "SLEVendorType"
        Me.SLEVendorType.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLEVendorType.Properties.Appearance.Options.UseFont = True
        Me.SLEVendorType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEVendorType.Properties.View = Me.GridView1
        Me.SLEVendorType.Size = New System.Drawing.Size(257, 20)
        Me.SLEVendorType.TabIndex = 8907
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
        Me.GridColumn1.Caption = "Id Vendor Type"
        Me.GridColumn1.FieldName = "id_vendor_type"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Vendor Type"
        Me.GridColumn3.FieldName = "vendor_type"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "ID Item Cat"
        Me.GridColumn4.FieldName = "id_item_cat"
        Me.GridColumn4.Name = "GridColumn4"
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Budget Category"
        Me.GridColumn5.FieldName = "item_cat"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 0
        '
        'FormItemSubCatDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 167)
        Me.Controls.Add(Me.SLEVendorType)
        Me.Controls.Add(Me.SLEBudgetCat)
        Me.Controls.Add(Me.TEPurchaseCategory)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LBudgetCat)
        Me.Controls.Add(Me.PanelControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormItemSubCatDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Category"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.TEPurchaseCategory.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEBudgetCat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEVendorType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LBudgetCat As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEPurchaseCategory As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SLEBudgetCat As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SLEVendorType As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
End Class
