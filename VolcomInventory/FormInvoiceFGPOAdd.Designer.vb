<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormInvoiceFGPOAdd
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormInvoiceFGPOAdd))
        Me.PanelControl7 = New DevExpress.XtraEditors.PanelControl()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BPick = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEFGPO = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TEInfoDesign = New DevExpress.XtraEditors.TextEdit()
        Me.TEReportNumber = New DevExpress.XtraEditors.TextEdit()
        Me.XTCAdd = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPFGPO = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPOther = New DevExpress.XtraTab.XtraTabPage()
        Me.TEVat = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TextEdit2 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.TextEdit3 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.TextEdit4 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl()
        Me.TEKurs = New DevExpress.XtraEditors.TextEdit()
        Me.LECurrency = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.TextEdit5 = New DevExpress.XtraEditors.TextEdit()
        CType(Me.PanelControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl7.SuspendLayout()
        CType(Me.SLEFGPO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEInfoDesign.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEReportNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCAdd.SuspendLayout()
        Me.XTPFGPO.SuspendLayout()
        CType(Me.TEVat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEKurs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LECurrency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit5.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl7
        '
        Me.PanelControl7.Controls.Add(Me.BCancel)
        Me.PanelControl7.Controls.Add(Me.BPick)
        Me.PanelControl7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl7.Location = New System.Drawing.Point(0, 273)
        Me.PanelControl7.Name = "PanelControl7"
        Me.PanelControl7.Size = New System.Drawing.Size(451, 40)
        Me.PanelControl7.TabIndex = 4
        '
        'BCancel
        '
        Me.BCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCancel.Image = CType(resources.GetObject("BCancel.Image"), System.Drawing.Image)
        Me.BCancel.ImageIndex = 5
        Me.BCancel.Location = New System.Drawing.Point(277, 2)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(87, 36)
        Me.BCancel.TabIndex = 18
        Me.BCancel.TabStop = False
        Me.BCancel.Text = "Close"
        '
        'BPick
        '
        Me.BPick.Dock = System.Windows.Forms.DockStyle.Right
        Me.BPick.Image = CType(resources.GetObject("BPick.Image"), System.Drawing.Image)
        Me.BPick.ImageIndex = 7
        Me.BPick.Location = New System.Drawing.Point(364, 2)
        Me.BPick.Name = "BPick"
        Me.BPick.Size = New System.Drawing.Size(85, 36)
        Me.BPick.TabIndex = 16
        Me.BPick.TabStop = False
        Me.BPick.Text = "Add"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(16, 21)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(27, 13)
        Me.LabelControl1.TabIndex = 5
        Me.LabelControl1.Text = "FGPO"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(16, 52)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(32, 13)
        Me.LabelControl2.TabIndex = 6
        Me.LabelControl2.Text = "Design"
        '
        'SLEFGPO
        '
        Me.SLEFGPO.Location = New System.Drawing.Point(195, 18)
        Me.SLEFGPO.Name = "SLEFGPO"
        Me.SLEFGPO.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEFGPO.Properties.View = Me.GridView1
        Me.SLEFGPO.Size = New System.Drawing.Size(226, 20)
        Me.SLEFGPO.TabIndex = 7
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "id_prod_order"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "F.G. PO Number"
        Me.GridColumn2.FieldName = "prod_order_number"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 290
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Design Code"
        Me.GridColumn3.FieldName = "design_code"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 307
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Design"
        Me.GridColumn4.FieldName = "design_display_name"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        Me.GridColumn4.Width = 1035
        '
        'TEInfoDesign
        '
        Me.TEInfoDesign.Location = New System.Drawing.Point(108, 49)
        Me.TEInfoDesign.Name = "TEInfoDesign"
        Me.TEInfoDesign.Size = New System.Drawing.Size(211, 20)
        Me.TEInfoDesign.TabIndex = 8
        '
        'TEReportNumber
        '
        Me.TEReportNumber.Location = New System.Drawing.Point(108, 18)
        Me.TEReportNumber.Name = "TEReportNumber"
        Me.TEReportNumber.Size = New System.Drawing.Size(81, 20)
        Me.TEReportNumber.TabIndex = 9
        '
        'XTCAdd
        '
        Me.XTCAdd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCAdd.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCAdd.Location = New System.Drawing.Point(0, 0)
        Me.XTCAdd.Name = "XTCAdd"
        Me.XTCAdd.SelectedTabPage = Me.XTPFGPO
        Me.XTCAdd.Size = New System.Drawing.Size(451, 273)
        Me.XTCAdd.TabIndex = 10
        Me.XTCAdd.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPFGPO, Me.XTPOther})
        '
        'XTPFGPO
        '
        Me.XTPFGPO.Controls.Add(Me.TextEdit5)
        Me.XTPFGPO.Controls.Add(Me.LabelControl8)
        Me.XTPFGPO.Controls.Add(Me.LabelControl21)
        Me.XTPFGPO.Controls.Add(Me.TEKurs)
        Me.XTPFGPO.Controls.Add(Me.LECurrency)
        Me.XTPFGPO.Controls.Add(Me.TextEdit4)
        Me.XTPFGPO.Controls.Add(Me.LabelControl7)
        Me.XTPFGPO.Controls.Add(Me.LabelControl6)
        Me.XTPFGPO.Controls.Add(Me.TextEdit3)
        Me.XTPFGPO.Controls.Add(Me.TextEdit2)
        Me.XTPFGPO.Controls.Add(Me.LabelControl5)
        Me.XTPFGPO.Controls.Add(Me.TextEdit1)
        Me.XTPFGPO.Controls.Add(Me.LabelControl3)
        Me.XTPFGPO.Controls.Add(Me.TEVat)
        Me.XTPFGPO.Controls.Add(Me.LabelControl4)
        Me.XTPFGPO.Controls.Add(Me.LabelControl1)
        Me.XTPFGPO.Controls.Add(Me.TEReportNumber)
        Me.XTPFGPO.Controls.Add(Me.LabelControl2)
        Me.XTPFGPO.Controls.Add(Me.TEInfoDesign)
        Me.XTPFGPO.Controls.Add(Me.SLEFGPO)
        Me.XTPFGPO.Name = "XTPFGPO"
        Me.XTPFGPO.Size = New System.Drawing.Size(445, 245)
        Me.XTPFGPO.Text = "FGPO"
        '
        'XTPOther
        '
        Me.XTPOther.Name = "XTPOther"
        Me.XTPOther.Size = New System.Drawing.Size(445, 95)
        Me.XTPOther.Text = "Other"
        '
        'TEVat
        '
        Me.TEVat.EditValue = ""
        Me.TEVat.Location = New System.Drawing.Point(349, 49)
        Me.TEVat.Name = "TEVat"
        Me.TEVat.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.TEVat.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEVat.Properties.DisplayFormat.FormatString = "N2"
        Me.TEVat.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TEVat.Properties.EditValueChangedDelay = 1
        Me.TEVat.Properties.Mask.EditMask = "N2"
        Me.TEVat.Size = New System.Drawing.Size(72, 20)
        Me.TEVat.TabIndex = 8910
        Me.TEVat.TabStop = False
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(325, 52)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(18, 13)
        Me.LabelControl4.TabIndex = 8909
        Me.LabelControl4.Text = "Qty"
        '
        'TextEdit1
        '
        Me.TextEdit1.EditValue = ""
        Me.TextEdit1.Location = New System.Drawing.Point(108, 141)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.TextEdit1.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TextEdit1.Properties.DisplayFormat.FormatString = "N2"
        Me.TextEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TextEdit1.Properties.EditValueChangedDelay = 1
        Me.TextEdit1.Properties.Mask.EditMask = "N2"
        Me.TextEdit1.Size = New System.Drawing.Size(313, 20)
        Me.TextEdit1.TabIndex = 8912
        Me.TextEdit1.TabStop = False
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(16, 144)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(49, 13)
        Me.LabelControl3.TabIndex = 8911
        Me.LabelControl3.Text = "After Kurs"
        '
        'TextEdit2
        '
        Me.TextEdit2.EditValue = ""
        Me.TextEdit2.Location = New System.Drawing.Point(195, 171)
        Me.TextEdit2.Name = "TextEdit2"
        Me.TextEdit2.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.TextEdit2.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TextEdit2.Properties.DisplayFormat.FormatString = "N2"
        Me.TextEdit2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TextEdit2.Properties.EditValueChangedDelay = 1
        Me.TextEdit2.Properties.Mask.EditMask = "N2"
        Me.TextEdit2.Size = New System.Drawing.Size(226, 20)
        Me.TextEdit2.TabIndex = 8914
        Me.TextEdit2.TabStop = False
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(16, 174)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(16, 13)
        Me.LabelControl5.TabIndex = 8913
        Me.LabelControl5.Text = "Vat"
        '
        'TextEdit3
        '
        Me.TextEdit3.EditValue = ""
        Me.TextEdit3.Location = New System.Drawing.Point(108, 171)
        Me.TextEdit3.Name = "TextEdit3"
        Me.TextEdit3.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.TextEdit3.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TextEdit3.Properties.DisplayFormat.FormatString = "N2"
        Me.TextEdit3.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TextEdit3.Properties.EditValueChangedDelay = 1
        Me.TextEdit3.Properties.Mask.EditMask = "N2"
        Me.TextEdit3.Size = New System.Drawing.Size(64, 20)
        Me.TextEdit3.TabIndex = 8915
        Me.TextEdit3.TabStop = False
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(178, 174)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(11, 13)
        Me.LabelControl6.TabIndex = 8916
        Me.LabelControl6.Text = "%"
        '
        'TextEdit4
        '
        Me.TextEdit4.EditValue = ""
        Me.TextEdit4.Location = New System.Drawing.Point(108, 200)
        Me.TextEdit4.Name = "TextEdit4"
        Me.TextEdit4.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.TextEdit4.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TextEdit4.Properties.DisplayFormat.FormatString = "N2"
        Me.TextEdit4.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TextEdit4.Properties.EditValueChangedDelay = 1
        Me.TextEdit4.Properties.Mask.EditMask = "N2"
        Me.TextEdit4.Size = New System.Drawing.Size(313, 20)
        Me.TextEdit4.TabIndex = 8918
        Me.TextEdit4.TabStop = False
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(16, 203)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(86, 13)
        Me.LabelControl7.TabIndex = 8917
        Me.LabelControl7.Text = "Amount after VAT"
        '
        'LabelControl21
        '
        Me.LabelControl21.Location = New System.Drawing.Point(16, 116)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl21.TabIndex = 8922
        Me.LabelControl21.Text = "Kurs"
        '
        'TEKurs
        '
        Me.TEKurs.Location = New System.Drawing.Point(108, 113)
        Me.TEKurs.Name = "TEKurs"
        Me.TEKurs.Properties.Appearance.Options.UseTextOptions = True
        Me.TEKurs.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEKurs.Properties.EditValueChangedDelay = 1
        Me.TEKurs.Properties.Mask.EditMask = "N2"
        Me.TEKurs.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEKurs.Properties.Mask.SaveLiteral = False
        Me.TEKurs.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEKurs.Properties.ReadOnly = True
        Me.TEKurs.Size = New System.Drawing.Size(313, 20)
        Me.TEKurs.TabIndex = 8921
        '
        'LECurrency
        '
        Me.LECurrency.Location = New System.Drawing.Point(108, 84)
        Me.LECurrency.Name = "LECurrency"
        Me.LECurrency.Properties.Appearance.Options.UseTextOptions = True
        Me.LECurrency.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LECurrency.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LECurrency.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.LECurrency.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.LECurrency.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.LECurrency.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LECurrency.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_currency", "Id Currency", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("currency", "Currency")})
        Me.LECurrency.Properties.NullText = ""
        Me.LECurrency.Properties.ShowFooter = False
        Me.LECurrency.Size = New System.Drawing.Size(64, 20)
        Me.LECurrency.TabIndex = 8920
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(16, 87)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl8.TabIndex = 8923
        Me.LabelControl8.Text = "Before Kurs"
        '
        'TextEdit5
        '
        Me.TextEdit5.EditValue = ""
        Me.TextEdit5.Location = New System.Drawing.Point(178, 84)
        Me.TextEdit5.Name = "TextEdit5"
        Me.TextEdit5.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.TextEdit5.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TextEdit5.Properties.DisplayFormat.FormatString = "N2"
        Me.TextEdit5.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TextEdit5.Properties.EditValueChangedDelay = 1
        Me.TextEdit5.Properties.Mask.EditMask = "N2"
        Me.TextEdit5.Size = New System.Drawing.Size(243, 20)
        Me.TextEdit5.TabIndex = 8924
        Me.TextEdit5.TabStop = False
        '
        'FormInvoiceFGPOAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(451, 313)
        Me.Controls.Add(Me.XTCAdd)
        Me.Controls.Add(Me.PanelControl7)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormInvoiceFGPOAdd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Item"
        CType(Me.PanelControl7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl7.ResumeLayout(False)
        CType(Me.SLEFGPO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEInfoDesign.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEReportNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCAdd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCAdd.ResumeLayout(False)
        Me.XTPFGPO.ResumeLayout(False)
        Me.XTPFGPO.PerformLayout()
        CType(Me.TEVat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEKurs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LECurrency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit5.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl7 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BPick As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEFGPO As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TEInfoDesign As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEReportNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents XTCAdd As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPFGPO As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPOther As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEdit3 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEVat As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEdit4 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEKurs As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LECurrency As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents TextEdit5 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
End Class
