<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSamplePriceSingle
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSamplePriceSingle))
        Me.EPSamplePrice = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl
        Me.PictureSeason = New DevExpress.XtraEditors.PictureEdit
        Me.BSave = New DevExpress.XtraEditors.SimpleButton
        Me.TEPrice = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.LEVendor = New DevExpress.XtraEditors.SearchLookUpEdit
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdComp = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColCompNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColCompName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColCompAddress = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColCompCat = New DevExpress.XtraGrid.Columns.GridColumn
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.LEVendorContact = New DevExpress.XtraEditors.SearchLookUpEdit
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdCompContact = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColCompContact = New DevExpress.XtraGrid.Columns.GridColumn
        Me.TEPriceName = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.LECurrency = New DevExpress.XtraEditors.LookUpEdit
        CType(Me.EPSamplePrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PictureSeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEVendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEVendorContact.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPriceName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LECurrency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EPSamplePrice
        '
        Me.EPSamplePrice.ContainerControl = Me
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl5.Location = New System.Drawing.Point(159, 152)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(49, 15)
        Me.LabelControl5.TabIndex = 122
        Me.LabelControl5.Text = "Currency"
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Location = New System.Drawing.Point(365, 262)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(86, 20)
        Me.BCancel.TabIndex = 114
        Me.BCancel.Text = "Cancel"
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.PictureSeason)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(153, 296)
        Me.PanelControl2.TabIndex = 121
        '
        'PictureSeason
        '
        Me.PictureSeason.EditValue = CType(resources.GetObject("PictureSeason.EditValue"), Object)
        Me.PictureSeason.Location = New System.Drawing.Point(12, 167)
        Me.PictureSeason.Name = "PictureSeason"
        Me.PictureSeason.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureSeason.Properties.Appearance.Options.UseBackColor = True
        Me.PictureSeason.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureSeason.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PictureSeason.Size = New System.Drawing.Size(124, 113)
        Me.PictureSeason.TabIndex = 19
        '
        'BSave
        '
        Me.BSave.Location = New System.Drawing.Point(457, 262)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(86, 20)
        Me.BSave.TabIndex = 113
        Me.BSave.Text = "Save"
        '
        'TEPrice
        '
        Me.TEPrice.Location = New System.Drawing.Point(159, 220)
        Me.TEPrice.Name = "TEPrice"
        Me.TEPrice.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TEPrice.Properties.Appearance.Options.UseFont = True
        Me.TEPrice.Properties.Mask.EditMask = "N2"
        Me.TEPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEPrice.Properties.Mask.SaveLiteral = False
        Me.TEPrice.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEPrice.Size = New System.Drawing.Size(197, 23)
        Me.TEPrice.TabIndex = 120
        Me.TEPrice.ToolTip = "Example : 65000"
        Me.TEPrice.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl4.Location = New System.Drawing.Point(159, 199)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(28, 15)
        Me.LabelControl4.TabIndex = 119
        Me.LabelControl4.Text = "Price"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl3.Location = New System.Drawing.Point(159, 57)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(42, 15)
        Me.LabelControl3.TabIndex = 118
        Me.LabelControl3.Text = "Contact"
        '
        'LEVendor
        '
        Me.LEVendor.Location = New System.Drawing.Point(159, 31)
        Me.LEVendor.Name = "LEVendor"
        Me.LEVendor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEVendor.Properties.NullText = ""
        Me.LEVendor.Properties.ShowFooter = False
        Me.LEVendor.Properties.View = Me.GridView1
        Me.LEVendor.Size = New System.Drawing.Size(384, 20)
        Me.LEVendor.TabIndex = 117
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdComp, Me.ColCompNumber, Me.ColCompName, Me.ColCompAddress, Me.ColCompCat})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'ColIdComp
        '
        Me.ColIdComp.Caption = "Id Company"
        Me.ColIdComp.FieldName = "id_comp"
        Me.ColIdComp.Name = "ColIdComp"
        '
        'ColCompNumber
        '
        Me.ColCompNumber.Caption = "Code"
        Me.ColCompNumber.FieldName = "comp_number"
        Me.ColCompNumber.Name = "ColCompNumber"
        Me.ColCompNumber.Visible = True
        Me.ColCompNumber.VisibleIndex = 0
        '
        'ColCompName
        '
        Me.ColCompName.Caption = "Company"
        Me.ColCompName.FieldName = "comp_name"
        Me.ColCompName.Name = "ColCompName"
        Me.ColCompName.Visible = True
        Me.ColCompName.VisibleIndex = 1
        '
        'ColCompAddress
        '
        Me.ColCompAddress.Caption = "Address"
        Me.ColCompAddress.FieldName = "address_primary"
        Me.ColCompAddress.Name = "ColCompAddress"
        Me.ColCompAddress.Visible = True
        Me.ColCompAddress.VisibleIndex = 2
        '
        'ColCompCat
        '
        Me.ColCompCat.Caption = "Category"
        Me.ColCompCat.FieldName = "comp_cat_name"
        Me.ColCompCat.Name = "ColCompCat"
        Me.ColCompCat.Visible = True
        Me.ColCompCat.VisibleIndex = 3
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl2.Location = New System.Drawing.Point(159, 10)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(39, 15)
        Me.LabelControl2.TabIndex = 116
        Me.LabelControl2.Text = "Vendor"
        '
        'LEVendorContact
        '
        Me.LEVendorContact.Location = New System.Drawing.Point(159, 78)
        Me.LEVendorContact.Name = "LEVendorContact"
        Me.LEVendorContact.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEVendorContact.Properties.NullText = ""
        Me.LEVendorContact.Properties.ShowFooter = False
        Me.LEVendorContact.Properties.View = Me.GridView2
        Me.LEVendorContact.Size = New System.Drawing.Size(384, 20)
        Me.LEVendorContact.TabIndex = 115
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdCompContact, Me.ColCompContact})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'ColIdCompContact
        '
        Me.ColIdCompContact.Caption = "Id Contact"
        Me.ColIdCompContact.FieldName = "id_comp_contact"
        Me.ColIdCompContact.Name = "ColIdCompContact"
        '
        'ColCompContact
        '
        Me.ColCompContact.Caption = "Cotact Person"
        Me.ColCompContact.FieldName = "contact_person"
        Me.ColCompContact.Name = "ColCompContact"
        Me.ColCompContact.Visible = True
        Me.ColCompContact.VisibleIndex = 0
        '
        'TEPriceName
        '
        Me.TEPriceName.Location = New System.Drawing.Point(159, 123)
        Me.TEPriceName.Name = "TEPriceName"
        Me.TEPriceName.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TEPriceName.Properties.Appearance.Options.UseFont = True
        Me.TEPriceName.Size = New System.Drawing.Size(324, 23)
        Me.TEPriceName.TabIndex = 112
        Me.TEPriceName.ToolTip = "Example : Price Estimation"
        Me.TEPriceName.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl1.Location = New System.Drawing.Point(159, 102)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(62, 15)
        Me.LabelControl1.TabIndex = 111
        Me.LabelControl1.Text = "Price Name"
        '
        'LECurrency
        '
        Me.LECurrency.Location = New System.Drawing.Point(159, 173)
        Me.LECurrency.Name = "LECurrency"
        Me.LECurrency.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LECurrency.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_currency", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("currency", "Currency")})
        Me.LECurrency.Properties.NullText = ""
        Me.LECurrency.Properties.ShowFooter = False
        Me.LECurrency.Size = New System.Drawing.Size(141, 20)
        Me.LECurrency.TabIndex = 123
        '
        'FormSamplePriceSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(575, 296)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.BCancel)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.BSave)
        Me.Controls.Add(Me.TEPrice)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LEVendor)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LEVendorContact)
        Me.Controls.Add(Me.TEPriceName)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LECurrency)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSamplePriceSingle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sample Price"
        CType(Me.EPSamplePrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PictureSeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEVendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEVendorContact.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPriceName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LECurrency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EPSamplePrice As System.Windows.Forms.ErrorProvider
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PictureSeason As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEPrice As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEVendor As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdComp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCompNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCompName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCompAddress As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCompCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEVendorContact As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdCompContact As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCompContact As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TEPriceName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LECurrency As DevExpress.XtraEditors.LookUpEdit
End Class
