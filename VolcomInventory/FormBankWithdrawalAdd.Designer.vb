<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBankWithdrawalAdd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBankWithdrawalAdd))
        Me.TxtSupplier = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtAmount = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtComp = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LEDK = New DevExpress.XtraEditors.LookUpEdit()
        Me.SLEComp = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtDescription = New DevExpress.XtraEditors.TextEdit()
        Me.TxtReff = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.SLECOA = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TxtCOA = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TEBeforeKurs = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl()
        Me.TEKurs = New DevExpress.XtraEditors.TextEdit()
        Me.LECurrency = New DevExpress.XtraEditors.LookUpEdit()
        Me.BCalculateKurs = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.TxtSupplier.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtComp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEDK.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEComp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtReff.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLECOA.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCOA.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEBeforeKurs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEKurs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LECurrency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtSupplier
        '
        Me.TxtSupplier.Location = New System.Drawing.Point(19, 256)
        Me.TxtSupplier.Name = "TxtSupplier"
        Me.TxtSupplier.Size = New System.Drawing.Size(360, 20)
        Me.TxtSupplier.TabIndex = 8925
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(19, 98)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(14, 13)
        Me.LabelControl7.TabIndex = 8935
        Me.LabelControl7.Text = "CC"
        '
        'TxtAmount
        '
        Me.TxtAmount.Enabled = False
        Me.TxtAmount.Location = New System.Drawing.Point(122, 394)
        Me.TxtAmount.Name = "TxtAmount"
        Me.TxtAmount.Properties.DisplayFormat.FormatString = "N2"
        Me.TxtAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtAmount.Properties.Mask.EditMask = "N2"
        Me.TxtAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtAmount.Size = New System.Drawing.Size(257, 20)
        Me.TxtAmount.TabIndex = 8927
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(122, 375)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(64, 13)
        Me.LabelControl6.TabIndex = 8934
        Me.LabelControl6.Text = "Amount in Rp"
        '
        'TxtComp
        '
        Me.TxtComp.Enabled = False
        Me.TxtComp.Location = New System.Drawing.Point(19, 117)
        Me.TxtComp.Name = "TxtComp"
        Me.TxtComp.Size = New System.Drawing.Size(100, 20)
        Me.TxtComp.TabIndex = 8924
        Me.TxtComp.TabStop = False
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(19, 375)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(17, 13)
        Me.LabelControl5.TabIndex = 8933
        Me.LabelControl5.Text = "D/K"
        '
        'LEDK
        '
        Me.LEDK.Location = New System.Drawing.Point(19, 394)
        Me.LEDK.Name = "LEDK"
        Me.LEDK.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEDK.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_dc", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("dc_code", "D/K"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("dc", "Description")})
        Me.LEDK.Size = New System.Drawing.Size(100, 20)
        Me.LEDK.TabIndex = 8926
        '
        'SLEComp
        '
        Me.SLEComp.Location = New System.Drawing.Point(122, 117)
        Me.SLEComp.Name = "SLEComp"
        Me.SLEComp.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEComp.Properties.NullText = ""
        Me.SLEComp.Properties.View = Me.GridView2
        Me.SLEComp.Size = New System.Drawing.Size(257, 20)
        Me.SLEComp.TabIndex = 8921
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn13, Me.GridColumn14, Me.GridColumncomp_number})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "ID Comp Contact"
        Me.GridColumn13.FieldName = "id_comp_contact"
        Me.GridColumn13.Name = "GridColumn13"
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Name"
        Me.GridColumn14.FieldName = "comp_name"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 1
        '
        'GridColumncomp_number
        '
        Me.GridColumncomp_number.Caption = "Code"
        Me.GridColumncomp_number.FieldName = "comp_number"
        Me.GridColumncomp_number.Name = "GridColumncomp_number"
        Me.GridColumncomp_number.Visible = True
        Me.GridColumncomp_number.VisibleIndex = 0
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(19, 237)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl4.TabIndex = 8931
        Me.LabelControl4.Text = "Vendor"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(19, 192)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl3.TabIndex = 8930
        Me.LabelControl3.Text = "Description"
        '
        'TxtDescription
        '
        Me.TxtDescription.Location = New System.Drawing.Point(19, 211)
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(360, 20)
        Me.TxtDescription.TabIndex = 8923
        '
        'TxtReff
        '
        Me.TxtReff.Location = New System.Drawing.Point(19, 166)
        Me.TxtReff.Name = "TxtReff"
        Me.TxtReff.Size = New System.Drawing.Size(360, 20)
        Me.TxtReff.TabIndex = 8922
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(19, 147)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl2.TabIndex = 8929
        Me.LabelControl2.Text = "Reff"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnClose)
        Me.PanelControl1.Controls.Add(Me.BtnAdd)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 429)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(399, 45)
        Me.PanelControl1.TabIndex = 8932
        '
        'BtnClose
        '
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(218, 2)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(91, 41)
        Me.BtnClose.TabIndex = 8
        Me.BtnClose.Text = "Close"
        '
        'BtnAdd
        '
        Me.BtnAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"), System.Drawing.Image)
        Me.BtnAdd.Location = New System.Drawing.Point(309, 2)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(88, 41)
        Me.BtnAdd.TabIndex = 7
        Me.BtnAdd.Text = "OK"
        '
        'SLECOA
        '
        Me.SLECOA.Location = New System.Drawing.Point(122, 72)
        Me.SLECOA.Name = "SLECOA"
        Me.SLECOA.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLECOA.Properties.NullText = ""
        Me.SLECOA.Properties.ShowClearButton = False
        Me.SLECOA.Properties.View = Me.GridView1
        Me.SLECOA.Size = New System.Drawing.Size(257, 20)
        Me.SLECOA.TabIndex = 8920
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn5, Me.GridColumn6})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id"
        Me.GridColumn1.FieldName = "id_acc"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Account"
        Me.GridColumn5.FieldName = "acc_name"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 0
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Description"
        Me.GridColumn6.FieldName = "acc_description"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 1
        '
        'TxtCOA
        '
        Me.TxtCOA.Enabled = False
        Me.TxtCOA.Location = New System.Drawing.Point(19, 72)
        Me.TxtCOA.Name = "TxtCOA"
        Me.TxtCOA.Size = New System.Drawing.Size(100, 20)
        Me.TxtCOA.TabIndex = 8928
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(19, 53)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl1.TabIndex = 8919
        Me.LabelControl1.Text = "COA"
        '
        'TEBeforeKurs
        '
        Me.TEBeforeKurs.EditValue = ""
        Me.TEBeforeKurs.Location = New System.Drawing.Point(90, 301)
        Me.TEBeforeKurs.Name = "TEBeforeKurs"
        Me.TEBeforeKurs.Properties.Appearance.Options.UseTextOptions = True
        Me.TEBeforeKurs.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEBeforeKurs.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.TEBeforeKurs.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEBeforeKurs.Properties.DisplayFormat.FormatString = "N2"
        Me.TEBeforeKurs.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TEBeforeKurs.Properties.EditValueChangedDelay = 1
        Me.TEBeforeKurs.Properties.Mask.EditMask = "N2"
        Me.TEBeforeKurs.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEBeforeKurs.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEBeforeKurs.Size = New System.Drawing.Size(289, 20)
        Me.TEBeforeKurs.TabIndex = 8937
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(19, 282)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl8.TabIndex = 8940
        Me.LabelControl8.Text = "Before Kurs"
        '
        'LabelControl21
        '
        Me.LabelControl21.Location = New System.Drawing.Point(19, 327)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl21.TabIndex = 8939
        Me.LabelControl21.Text = "Kurs"
        '
        'TEKurs
        '
        Me.TEKurs.Location = New System.Drawing.Point(18, 346)
        Me.TEKurs.Name = "TEKurs"
        Me.TEKurs.Properties.Appearance.Options.UseTextOptions = True
        Me.TEKurs.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEKurs.Properties.EditValueChangedDelay = 1
        Me.TEKurs.Properties.Mask.EditMask = "N2"
        Me.TEKurs.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEKurs.Properties.Mask.SaveLiteral = False
        Me.TEKurs.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEKurs.Size = New System.Drawing.Size(361, 20)
        Me.TEKurs.TabIndex = 8938
        '
        'LECurrency
        '
        Me.LECurrency.Location = New System.Drawing.Point(19, 301)
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
        Me.LECurrency.TabIndex = 8936
        '
        'BCalculateKurs
        '
        Me.BCalculateKurs.Dock = System.Windows.Forms.DockStyle.Top
        Me.BCalculateKurs.Image = CType(resources.GetObject("BCalculateKurs.Image"), System.Drawing.Image)
        Me.BCalculateKurs.Location = New System.Drawing.Point(0, 0)
        Me.BCalculateKurs.Name = "BCalculateKurs"
        Me.BCalculateKurs.Size = New System.Drawing.Size(399, 41)
        Me.BCalculateKurs.TabIndex = 8941
        Me.BCalculateKurs.Text = "Auto (Selisih Kurs)"
        '
        'FormBankWithdrawalAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(399, 474)
        Me.Controls.Add(Me.BCalculateKurs)
        Me.Controls.Add(Me.TEBeforeKurs)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.LabelControl21)
        Me.Controls.Add(Me.TEKurs)
        Me.Controls.Add(Me.LECurrency)
        Me.Controls.Add(Me.TxtSupplier)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.TxtAmount)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.TxtComp)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LEDK)
        Me.Controls.Add(Me.SLEComp)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.TxtDescription)
        Me.Controls.Add(Me.TxtReff)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.SLECOA)
        Me.Controls.Add(Me.TxtCOA)
        Me.Controls.Add(Me.LabelControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormBankWithdrawalAdd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Detail"
        CType(Me.TxtSupplier.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtComp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEDK.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEComp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtReff.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.SLECOA.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCOA.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEBeforeKurs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEKurs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LECurrency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtSupplier As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtComp As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEDK As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents SLEComp As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtDescription As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtReff As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLECOA As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TxtCOA As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEBeforeKurs As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEKurs As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LECurrency As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents BCalculateKurs As DevExpress.XtraEditors.SimpleButton
End Class
