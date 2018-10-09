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
        Me.GVSOH = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.PCNav = New DevExpress.XtraEditors.PanelControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.DateEdit1 = New DevExpress.XtraEditors.DateEdit()
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
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GVSOH.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.GVSOH.GridControl = Me.GCSOH
        Me.GVSOH.Name = "GVSOH"
        Me.GVSOH.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVSOH.OptionsBehavior.Editable = False
        Me.GVSOH.OptionsView.ShowGroupPanel = False
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "GridBand1"
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        '
        'PCNav
        '
        Me.PCNav.Controls.Add(Me.BtnView)
        Me.PCNav.Controls.Add(Me.LabelControl2)
        Me.PCNav.Controls.Add(Me.DateEdit1)
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
        'DateEdit1
        '
        Me.DateEdit1.EditValue = Nothing
        Me.DateEdit1.Location = New System.Drawing.Point(527, 14)
        Me.DateEdit1.Name = "DateEdit1"
        Me.DateEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Size = New System.Drawing.Size(172, 20)
        Me.DateEdit1.TabIndex = 23
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
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents DateEdit1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LECat As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCSOH As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSOH As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
End Class
