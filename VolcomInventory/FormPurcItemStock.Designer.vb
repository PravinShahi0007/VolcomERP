<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPurcItemStock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPurcItemStock))
        Me.XTCStock = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPSOH = New DevExpress.XtraTab.XtraTabPage()
        Me.GCSOH = New DevExpress.XtraGrid.GridControl()
        Me.GVSOH = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdItem = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnItemDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdItemCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnItemCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdDept = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDept = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PCNav = New DevExpress.XtraEditors.PanelControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.DESOHUntil = New DevExpress.XtraEditors.DateEdit()
        Me.LECat = New DevExpress.XtraEditors.LookUpEdit()
        Me.LEDeptSum = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPStockCard = New DevExpress.XtraTab.XtraTabPage()
        CType(Me.XTCStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCStock.SuspendLayout()
        Me.XTPSOH.SuspendLayout()
        CType(Me.GCSOH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSOH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCNav.SuspendLayout()
        CType(Me.DESOHUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DESOHUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LECat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEDeptSum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCStock
        '
        Me.XTCStock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCStock.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCStock.Location = New System.Drawing.Point(0, 0)
        Me.XTCStock.Name = "XTCStock"
        Me.XTCStock.SelectedTabPage = Me.XTPSOH
        Me.XTCStock.Size = New System.Drawing.Size(890, 592)
        Me.XTCStock.TabIndex = 0
        Me.XTCStock.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPSOH, Me.XTPStockCard})
        '
        'XTPSOH
        '
        Me.XTPSOH.Controls.Add(Me.GCSOH)
        Me.XTPSOH.Controls.Add(Me.PCNav)
        Me.XTPSOH.Name = "XTPSOH"
        Me.XTPSOH.Size = New System.Drawing.Size(884, 564)
        Me.XTPSOH.Text = "Stock On Hand"
        '
        'GCSOH
        '
        Me.GCSOH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSOH.Location = New System.Drawing.Point(0, 48)
        Me.GCSOH.MainView = Me.GVSOH
        Me.GCSOH.Name = "GCSOH"
        Me.GCSOH.Size = New System.Drawing.Size(884, 516)
        Me.GCSOH.TabIndex = 1
        Me.GCSOH.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSOH})
        '
        'GVSOH
        '
        Me.GVSOH.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdItem, Me.GridColumnItemDesc, Me.GridColumnIdItemCat, Me.GridColumnItemCat, Me.GridColumnQty, Me.GridColumnAmount, Me.GridColumnIdDept, Me.GridColumnDept})
        Me.GVSOH.GridControl = Me.GCSOH
        Me.GVSOH.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", Me.GridColumnQty, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", Me.GridColumnAmount, "{0:N2}")})
        Me.GVSOH.Name = "GVSOH"
        Me.GVSOH.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVSOH.OptionsBehavior.Editable = False
        Me.GVSOH.OptionsView.ShowFooter = True
        Me.GVSOH.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdItem
        '
        Me.GridColumnIdItem.Caption = "Id Item"
        Me.GridColumnIdItem.FieldName = "id_item"
        Me.GridColumnIdItem.Name = "GridColumnIdItem"
        '
        'GridColumnItemDesc
        '
        Me.GridColumnItemDesc.Caption = "Description"
        Me.GridColumnItemDesc.FieldName = "item_desc"
        Me.GridColumnItemDesc.Name = "GridColumnItemDesc"
        Me.GridColumnItemDesc.Visible = True
        Me.GridColumnItemDesc.VisibleIndex = 1
        '
        'GridColumnIdItemCat
        '
        Me.GridColumnIdItemCat.Caption = "Id Cat"
        Me.GridColumnIdItemCat.FieldName = "id_item_cat"
        Me.GridColumnIdItemCat.Name = "GridColumnIdItemCat"
        '
        'GridColumnItemCat
        '
        Me.GridColumnItemCat.Caption = "Category"
        Me.GridColumnItemCat.FieldName = "item_cat"
        Me.GridColumnItemCat.Name = "GridColumnItemCat"
        Me.GridColumnItemCat.Visible = True
        Me.GridColumnItemCat.VisibleIndex = 2
        '
        'GridColumnQty
        '
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.DisplayFormat.FormatString = "N2"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N2}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 3
        '
        'GridColumnAmount
        '
        Me.GridColumnAmount.Caption = "Amount"
        Me.GridColumnAmount.DisplayFormat.FormatString = "N2"
        Me.GridColumnAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAmount.FieldName = "amount"
        Me.GridColumnAmount.Name = "GridColumnAmount"
        Me.GridColumnAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N2}")})
        Me.GridColumnAmount.Visible = True
        Me.GridColumnAmount.VisibleIndex = 4
        '
        'GridColumnIdDept
        '
        Me.GridColumnIdDept.Caption = "Id Departement"
        Me.GridColumnIdDept.FieldName = "id_departement"
        Me.GridColumnIdDept.Name = "GridColumnIdDept"
        '
        'GridColumnDept
        '
        Me.GridColumnDept.Caption = "Departement"
        Me.GridColumnDept.FieldName = "departement"
        Me.GridColumnDept.Name = "GridColumnDept"
        Me.GridColumnDept.Visible = True
        Me.GridColumnDept.VisibleIndex = 0
        '
        'PCNav
        '
        Me.PCNav.Controls.Add(Me.BtnView)
        Me.PCNav.Controls.Add(Me.LabelControl2)
        Me.PCNav.Controls.Add(Me.DESOHUntil)
        Me.PCNav.Controls.Add(Me.LECat)
        Me.PCNav.Controls.Add(Me.LEDeptSum)
        Me.PCNav.Controls.Add(Me.LabelControl1)
        Me.PCNav.Controls.Add(Me.LabelControl6)
        Me.PCNav.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCNav.Location = New System.Drawing.Point(0, 0)
        Me.PCNav.Name = "PCNav"
        Me.PCNav.Size = New System.Drawing.Size(884, 48)
        Me.PCNav.TabIndex = 0
        '
        'BtnView
        '
        Me.BtnView.Image = CType(resources.GetObject("BtnView.Image"), System.Drawing.Image)
        Me.BtnView.Location = New System.Drawing.Point(705, 12)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(75, 23)
        Me.BtnView.TabIndex = 23
        Me.BtnView.Text = "View"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(500, 17)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl2.TabIndex = 24
        Me.LabelControl2.Text = "Until"
        '
        'DESOHUntil
        '
        Me.DESOHUntil.EditValue = Nothing
        Me.DESOHUntil.Location = New System.Drawing.Point(527, 14)
        Me.DESOHUntil.Name = "DESOHUntil"
        Me.DESOHUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DESOHUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DESOHUntil.Properties.DisplayFormat.FormatString = "dd\/MM\/yyyy"
        Me.DESOHUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DESOHUntil.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DESOHUntil.Size = New System.Drawing.Size(172, 20)
        Me.DESOHUntil.TabIndex = 23
        '
        'LECat
        '
        Me.LECat.Location = New System.Drawing.Point(319, 14)
        Me.LECat.Name = "LECat"
        Me.LECat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LECat.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_item_cat", "Id", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("item_cat", "Category")})
        Me.LECat.Size = New System.Drawing.Size(175, 20)
        Me.LECat.TabIndex = 22
        '
        'LEDeptSum
        '
        Me.LEDeptSum.Location = New System.Drawing.Point(85, 14)
        Me.LEDeptSum.Name = "LEDeptSum"
        Me.LEDeptSum.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEDeptSum.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_departement", "Id Departement", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("departement", "Departemen")})
        Me.LEDeptSum.Size = New System.Drawing.Size(175, 20)
        Me.LEDeptSum.TabIndex = 19
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(268, 17)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl1.TabIndex = 21
        Me.LabelControl1.Text = "Category"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(16, 17)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl6.TabIndex = 18
        Me.LabelControl6.Text = "Departement"
        '
        'XTPStockCard
        '
        Me.XTPStockCard.Name = "XTPStockCard"
        Me.XTPStockCard.Size = New System.Drawing.Size(884, 564)
        Me.XTPStockCard.Text = "Stock Card"
        '
        'FormPurcItemStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(890, 592)
        Me.Controls.Add(Me.XTCStock)
        Me.MinimizeBox = False
        Me.Name = "FormPurcItemStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Items Stock"
        CType(Me.XTCStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCStock.ResumeLayout(False)
        Me.XTPSOH.ResumeLayout(False)
        CType(Me.GCSOH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSOH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCNav.ResumeLayout(False)
        Me.PCNav.PerformLayout()
        CType(Me.DESOHUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DESOHUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LECat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEDeptSum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCStock As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPSOH As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPStockCard As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PCNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LEDeptSum As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DESOHUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LECat As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCSOH As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSOH As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdItem As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnItemDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdItemCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnItemCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdDept As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDept As DevExpress.XtraGrid.Columns.GridColumn
End Class
