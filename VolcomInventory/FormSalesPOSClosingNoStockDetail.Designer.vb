<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesPOSClosingNoStockDetail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSalesPOSClosingNoStockDetail))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LinkInvoice = New DevExpress.XtraEditors.HyperLinkEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtStore = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtSKU = New DevExpress.XtraEditors.TextEdit()
        Me.TxtName = New DevExpress.XtraEditors.TextEdit()
        Me.TxtSize = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtPrice = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtSizeValid = New DevExpress.XtraEditors.TextEdit()
        Me.TxtNameValid = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.TXTSKUValid = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.MeNote = New DevExpress.XtraEditors.MemoEdit()
        Me.BtnConfirm = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnDiscard = New DevExpress.XtraEditors.SimpleButton()
        Me.TxtPriceValid = New DevExpress.XtraEditors.TextEdit()
        Me.SLEType = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtQty = New DevExpress.XtraEditors.TextEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.LinkInvoice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtStore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSKU.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSizeValid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNameValid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXTSKUValid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MeNote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPriceValid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtQty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnDiscard)
        Me.PanelControl1.Controls.Add(Me.BtnConfirm)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 304)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(551, 49)
        Me.PanelControl1.TabIndex = 0
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.TxtPrice)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Controls.Add(Me.TxtSize)
        Me.GroupControl1.Controls.Add(Me.TxtName)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Controls.Add(Me.TxtSKU)
        Me.GroupControl1.Controls.Add(Me.TextEdit1)
        Me.GroupControl1.Controls.Add(Me.TxtStore)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.LinkInvoice)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(551, 121)
        Me.GroupControl1.TabIndex = 1
        Me.GroupControl1.Text = "Invoice Reference"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.TxtQty)
        Me.GroupControl2.Controls.Add(Me.LabelControl9)
        Me.GroupControl2.Controls.Add(Me.SLEType)
        Me.GroupControl2.Controls.Add(Me.TxtPriceValid)
        Me.GroupControl2.Controls.Add(Me.MeNote)
        Me.GroupControl2.Controls.Add(Me.LabelControl8)
        Me.GroupControl2.Controls.Add(Me.LabelControl6)
        Me.GroupControl2.Controls.Add(Me.TxtSizeValid)
        Me.GroupControl2.Controls.Add(Me.TxtNameValid)
        Me.GroupControl2.Controls.Add(Me.LabelControl7)
        Me.GroupControl2.Controls.Add(Me.TXTSKUValid)
        Me.GroupControl2.Controls.Add(Me.LabelControl5)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 121)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(551, 183)
        Me.GroupControl2.TabIndex = 2
        Me.GroupControl2.Text = "Action"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(13, 32)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Invoice"
        '
        'LinkInvoice
        '
        Me.LinkInvoice.Location = New System.Drawing.Point(74, 29)
        Me.LinkInvoice.Name = "LinkInvoice"
        Me.LinkInvoice.Properties.ReadOnly = True
        Me.LinkInvoice.Size = New System.Drawing.Size(117, 20)
        Me.LinkInvoice.TabIndex = 0
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(197, 32)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "Store"
        '
        'TxtStore
        '
        Me.TxtStore.Location = New System.Drawing.Point(229, 29)
        Me.TxtStore.Name = "TxtStore"
        Me.TxtStore.Properties.ReadOnly = True
        Me.TxtStore.Size = New System.Drawing.Size(61, 20)
        Me.TxtStore.TabIndex = 0
        '
        'TextEdit1
        '
        Me.TextEdit1.Location = New System.Drawing.Point(293, 29)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Properties.ReadOnly = True
        Me.TextEdit1.Size = New System.Drawing.Size(240, 20)
        Me.TextEdit1.TabIndex = 2
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(13, 58)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl3.TabIndex = 3
        Me.LabelControl3.Text = "Product"
        '
        'TxtSKU
        '
        Me.TxtSKU.EditValue = ""
        Me.TxtSKU.Location = New System.Drawing.Point(74, 55)
        Me.TxtSKU.Name = "TxtSKU"
        Me.TxtSKU.Properties.ReadOnly = True
        Me.TxtSKU.Size = New System.Drawing.Size(89, 20)
        Me.TxtSKU.TabIndex = 4
        '
        'TxtName
        '
        Me.TxtName.EditValue = ""
        Me.TxtName.Location = New System.Drawing.Point(165, 55)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Properties.ReadOnly = True
        Me.TxtName.Size = New System.Drawing.Size(277, 20)
        Me.TxtName.TabIndex = 5
        '
        'TxtSize
        '
        Me.TxtSize.EditValue = ""
        Me.TxtSize.Location = New System.Drawing.Point(444, 55)
        Me.TxtSize.Name = "TxtSize"
        Me.TxtSize.Properties.ReadOnly = True
        Me.TxtSize.Size = New System.Drawing.Size(89, 20)
        Me.TxtSize.TabIndex = 6
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(13, 84)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl4.TabIndex = 7
        Me.LabelControl4.Text = "Price"
        '
        'TxtPrice
        '
        Me.TxtPrice.EditValue = ""
        Me.TxtPrice.Location = New System.Drawing.Point(74, 81)
        Me.TxtPrice.Name = "TxtPrice"
        Me.TxtPrice.Properties.DisplayFormat.FormatString = "N2"
        Me.TxtPrice.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtPrice.Properties.ReadOnly = True
        Me.TxtPrice.Size = New System.Drawing.Size(459, 20)
        Me.TxtPrice.TabIndex = 8
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(169, 31)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl5.TabIndex = 9
        Me.LabelControl5.Text = "Type"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(13, 83)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl6.TabIndex = 15
        Me.LabelControl6.Text = "Price"
        '
        'TxtSizeValid
        '
        Me.TxtSizeValid.EditValue = ""
        Me.TxtSizeValid.Location = New System.Drawing.Point(444, 54)
        Me.TxtSizeValid.Name = "TxtSizeValid"
        Me.TxtSizeValid.Properties.ReadOnly = True
        Me.TxtSizeValid.Size = New System.Drawing.Size(89, 20)
        Me.TxtSizeValid.TabIndex = 14
        '
        'TxtNameValid
        '
        Me.TxtNameValid.EditValue = ""
        Me.TxtNameValid.Location = New System.Drawing.Point(165, 54)
        Me.TxtNameValid.Name = "TxtNameValid"
        Me.TxtNameValid.Properties.ReadOnly = True
        Me.TxtNameValid.Size = New System.Drawing.Size(277, 20)
        Me.TxtNameValid.TabIndex = 13
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(13, 57)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl7.TabIndex = 11
        Me.LabelControl7.Text = "Product"
        '
        'TXTSKUValid
        '
        Me.TXTSKUValid.EditValue = ""
        Me.TXTSKUValid.Location = New System.Drawing.Point(74, 54)
        Me.TXTSKUValid.Name = "TXTSKUValid"
        Me.TXTSKUValid.Properties.ReadOnly = True
        Me.TXTSKUValid.Size = New System.Drawing.Size(89, 20)
        Me.TXTSKUValid.TabIndex = 12
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(13, 108)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl8.TabIndex = 17
        Me.LabelControl8.Text = "Note"
        '
        'MeNote
        '
        Me.MeNote.Location = New System.Drawing.Point(74, 106)
        Me.MeNote.Name = "MeNote"
        Me.MeNote.Size = New System.Drawing.Size(459, 54)
        Me.MeNote.TabIndex = 18
        '
        'BtnConfirm
        '
        Me.BtnConfirm.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConfirm.Appearance.Options.UseFont = True
        Me.BtnConfirm.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnConfirm.Image = CType(resources.GetObject("BtnConfirm.Image"), System.Drawing.Image)
        Me.BtnConfirm.Location = New System.Drawing.Point(453, 2)
        Me.BtnConfirm.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnConfirm.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnConfirm.Name = "BtnConfirm"
        Me.BtnConfirm.Size = New System.Drawing.Size(96, 45)
        Me.BtnConfirm.TabIndex = 0
        Me.BtnConfirm.Text = "Confirm"
        '
        'BtnDiscard
        '
        Me.BtnDiscard.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDiscard.Appearance.Options.UseFont = True
        Me.BtnDiscard.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDiscard.Image = CType(resources.GetObject("BtnDiscard.Image"), System.Drawing.Image)
        Me.BtnDiscard.Location = New System.Drawing.Point(357, 2)
        Me.BtnDiscard.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnDiscard.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnDiscard.Name = "BtnDiscard"
        Me.BtnDiscard.Size = New System.Drawing.Size(96, 45)
        Me.BtnDiscard.TabIndex = 1
        Me.BtnDiscard.Text = "Discard"
        '
        'TxtPriceValid
        '
        Me.TxtPriceValid.EditValue = ""
        Me.TxtPriceValid.Location = New System.Drawing.Point(74, 80)
        Me.TxtPriceValid.Name = "TxtPriceValid"
        Me.TxtPriceValid.Properties.DisplayFormat.FormatString = "N2"
        Me.TxtPriceValid.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtPriceValid.Properties.ReadOnly = True
        Me.TxtPriceValid.Size = New System.Drawing.Size(459, 20)
        Me.TxtPriceValid.TabIndex = 9
        '
        'SLEType
        '
        Me.SLEType.Location = New System.Drawing.Point(197, 28)
        Me.SLEType.Name = "SLEType"
        Me.SLEType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEType.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEType.Size = New System.Drawing.Size(336, 20)
        Me.SLEType.TabIndex = 19
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(13, 31)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(18, 13)
        Me.LabelControl9.TabIndex = 20
        Me.LabelControl9.Text = "Qty"
        '
        'TxtQty
        '
        Me.TxtQty.Location = New System.Drawing.Point(74, 28)
        Me.TxtQty.Name = "TxtQty"
        Me.TxtQty.Properties.Mask.EditMask = "N0"
        Me.TxtQty.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtQty.Size = New System.Drawing.Size(89, 20)
        Me.TxtQty.TabIndex = 21
        '
        'FormSalesPOSClosingNoStockDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(551, 353)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSalesPOSClosingNoStockDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detail Closing"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.LinkInvoice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtStore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSKU.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSizeValid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNameValid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXTSKUValid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MeNote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPriceValid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtQty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TxtPrice As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtSize As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtSKU As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtStore As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LinkInvoice As DevExpress.XtraEditors.HyperLinkEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MeNote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtSizeValid As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtNameValid As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TXTSKUValid As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnDiscard As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnConfirm As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtPriceValid As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SLEType As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TxtQty As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
End Class
