<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpMatPrice
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
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.TEPriceTot = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl
        Me.LECurrency = New DevExpress.XtraEditors.LookUpEdit
        Me.TEVendCur = New DevExpress.XtraEditors.TextEdit
        Me.TEVendPrice = New DevExpress.XtraEditors.TextEdit
        Me.LabelControlUpdateName = New DevExpress.XtraEditors.LabelControl
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BSave = New DevExpress.XtraEditors.SimpleButton
        Me.GroupGeneral = New DevExpress.XtraEditors.GroupControl
        Me.GCMatPrice = New DevExpress.XtraGrid.GridControl
        Me.GVMatPrice = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColMatPirce = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColPriceName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColCompany = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColCurrenct = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.TEPriceTot.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LECurrency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEVendCur.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEVendPrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneral.SuspendLayout()
        CType(Me.GCMatPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMatPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl2
        '
        Me.GroupControl2.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl2.Controls.Add(Me.LabelControl1)
        Me.GroupControl2.Controls.Add(Me.TEPriceTot)
        Me.GroupControl2.Controls.Add(Me.LabelControl7)
        Me.GroupControl2.Controls.Add(Me.LECurrency)
        Me.GroupControl2.Controls.Add(Me.TEVendCur)
        Me.GroupControl2.Controls.Add(Me.TEVendPrice)
        Me.GroupControl2.Controls.Add(Me.LabelControlUpdateName)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 290)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(704, 62)
        Me.GroupControl2.TabIndex = 46
        Me.GroupControl2.Text = "Detail"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl1.Location = New System.Drawing.Point(35, 8)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(77, 15)
        Me.LabelControl1.TabIndex = 117
        Me.LabelControl1.Text = "Original Price"
        '
        'TEPriceTot
        '
        Me.TEPriceTot.Location = New System.Drawing.Point(478, 25)
        Me.TEPriceTot.Name = "TEPriceTot"
        Me.TEPriceTot.Properties.Appearance.Options.UseTextOptions = True
        Me.TEPriceTot.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEPriceTot.Properties.Mask.EditMask = "N2"
        Me.TEPriceTot.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEPriceTot.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEPriceTot.Size = New System.Drawing.Size(210, 20)
        Me.TEPriceTot.TabIndex = 6
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(388, 10)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl7.TabIndex = 116
        Me.LabelControl7.Text = "Price"
        '
        'LECurrency
        '
        Me.LECurrency.Enabled = False
        Me.LECurrency.Location = New System.Drawing.Point(388, 25)
        Me.LECurrency.Name = "LECurrency"
        Me.LECurrency.Properties.Appearance.Options.UseTextOptions = True
        Me.LECurrency.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LECurrency.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LECurrency.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_currency", "Id Currency", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("currency", "Currency")})
        Me.LECurrency.Properties.NullText = ""
        Me.LECurrency.Properties.ShowFooter = False
        Me.LECurrency.Size = New System.Drawing.Size(84, 20)
        Me.LECurrency.TabIndex = 1
        '
        'TEVendCur
        '
        Me.TEVendCur.Enabled = False
        Me.TEVendCur.Location = New System.Drawing.Point(35, 25)
        Me.TEVendCur.Name = "TEVendCur"
        Me.TEVendCur.Properties.Appearance.Options.UseTextOptions = True
        Me.TEVendCur.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.TEVendCur.Size = New System.Drawing.Size(84, 20)
        Me.TEVendCur.TabIndex = 89
        '
        'TEVendPrice
        '
        Me.TEVendPrice.EditValue = ""
        Me.TEVendPrice.Enabled = False
        Me.TEVendPrice.Location = New System.Drawing.Point(125, 25)
        Me.TEVendPrice.Name = "TEVendPrice"
        Me.TEVendPrice.Properties.Appearance.Options.UseTextOptions = True
        Me.TEVendPrice.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEVendPrice.Properties.Mask.EditMask = "N2"
        Me.TEVendPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEVendPrice.Properties.Mask.SaveLiteral = False
        Me.TEVendPrice.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEVendPrice.Size = New System.Drawing.Size(214, 20)
        Me.TEVendPrice.TabIndex = 81
        '
        'LabelControlUpdateName
        '
        Me.LabelControlUpdateName.Location = New System.Drawing.Point(35, 9)
        Me.LabelControlUpdateName.Name = "LabelControlUpdateName"
        Me.LabelControlUpdateName.Size = New System.Drawing.Size(0, 13)
        Me.LabelControlUpdateName.TabIndex = 82
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.BCancel)
        Me.PanelControl2.Controls.Add(Me.BSave)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 352)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(704, 38)
        Me.PanelControl2.TabIndex = 45
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Location = New System.Drawing.Point(542, 8)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(70, 23)
        Me.BCancel.TabIndex = 2
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Location = New System.Drawing.Point(618, 8)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(70, 23)
        Me.BSave.TabIndex = 1
        Me.BSave.Text = "Save"
        '
        'GroupGeneral
        '
        Me.GroupGeneral.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupGeneral.Controls.Add(Me.GCMatPrice)
        Me.GroupGeneral.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupGeneral.Location = New System.Drawing.Point(0, 0)
        Me.GroupGeneral.Name = "GroupGeneral"
        Me.GroupGeneral.Size = New System.Drawing.Size(704, 290)
        Me.GroupGeneral.TabIndex = 44
        Me.GroupGeneral.Text = "Price"
        '
        'GCMatPrice
        '
        Me.GCMatPrice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMatPrice.Location = New System.Drawing.Point(2, 22)
        Me.GCMatPrice.MainView = Me.GVMatPrice
        Me.GCMatPrice.Name = "GCMatPrice"
        Me.GCMatPrice.Size = New System.Drawing.Size(700, 266)
        Me.GCMatPrice.TabIndex = 4
        Me.GCMatPrice.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMatPrice, Me.GridView1})
        '
        'GVMatPrice
        '
        Me.GVMatPrice.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColMatPirce, Me.ColPriceName, Me.ColCompany, Me.ColPrice, Me.ColDate, Me.ColCurrenct})
        Me.GVMatPrice.GridControl = Me.GCMatPrice
        Me.GVMatPrice.Name = "GVMatPrice"
        Me.GVMatPrice.OptionsBehavior.Editable = False
        Me.GVMatPrice.OptionsView.ShowGroupPanel = False
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GCMatPrice
        Me.GridView1.Name = "GridView1"
        '
        'ColMatPirce
        '
        Me.ColMatPirce.Caption = "Id Price"
        Me.ColMatPirce.FieldName = "id_mat_det_price"
        Me.ColMatPirce.Name = "ColMatPirce"
        '
        'ColPriceName
        '
        Me.ColPriceName.Caption = "Name"
        Me.ColPriceName.FieldName = "mat_det_price_name"
        Me.ColPriceName.Name = "ColPriceName"
        Me.ColPriceName.Visible = True
        Me.ColPriceName.VisibleIndex = 0
        Me.ColPriceName.Width = 174
        '
        'ColCompany
        '
        Me.ColCompany.Caption = "Source"
        Me.ColCompany.FieldName = "comp_name"
        Me.ColCompany.Name = "ColCompany"
        Me.ColCompany.Visible = True
        Me.ColCompany.VisibleIndex = 1
        Me.ColCompany.Width = 174
        '
        'ColPrice
        '
        Me.ColPrice.AppearanceCell.Options.UseTextOptions = True
        Me.ColPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.ColPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.Caption = "Price"
        Me.ColPrice.DisplayFormat.FormatString = "N2"
        Me.ColPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColPrice.FieldName = "mat_det_price"
        Me.ColPrice.Name = "ColPrice"
        Me.ColPrice.Visible = True
        Me.ColPrice.VisibleIndex = 3
        Me.ColPrice.Width = 174
        '
        'ColDate
        '
        Me.ColDate.Caption = "Date"
        Me.ColDate.FieldName = "mat_det_price_date"
        Me.ColDate.Name = "ColDate"
        Me.ColDate.Visible = True
        Me.ColDate.VisibleIndex = 4
        Me.ColDate.Width = 174
        '
        'ColCurrenct
        '
        Me.ColCurrenct.AppearanceCell.Options.UseTextOptions = True
        Me.ColCurrenct.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColCurrenct.AppearanceHeader.Options.UseTextOptions = True
        Me.ColCurrenct.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColCurrenct.Caption = "Currency"
        Me.ColCurrenct.FieldName = "currency"
        Me.ColCurrenct.Name = "ColCurrenct"
        Me.ColCurrenct.Visible = True
        Me.ColCurrenct.VisibleIndex = 2
        Me.ColCurrenct.Width = 60
        '
        'FormPopUpMatPrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 390)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.GroupGeneral)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPopUpMatPrice"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Material Price"
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.TEPriceTot.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LECurrency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEVendCur.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEVendPrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneral.ResumeLayout(False)
        CType(Me.GCMatPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMatPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEPriceTot As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LECurrency As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents TEVendCur As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEVendPrice As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControlUpdateName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupGeneral As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCMatPrice As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMatPrice As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColMatPirce As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPriceName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCompany As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCurrenct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
