<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormVoucherPOSDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormVoucherPOSDet))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtVoucherNumber = New DevExpress.XtraEditors.TextEdit()
        Me.TxtValue = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtOnBehalf = New DevExpress.XtraEditors.TextEdit()
        Me.MEAddress = New DevExpress.XtraEditors.LabelControl()
        Me.MEAddressVoucher = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.DEStart = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.DEEnd = New DevExpress.XtraEditors.DateEdit()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.CEActive = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.TxtVoucherNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtValue.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtOnBehalf.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEAddressVoucher.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.CEActive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(15, 23)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(79, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Voucher Number"
        '
        'TxtVoucherNumber
        '
        Me.TxtVoucherNumber.Location = New System.Drawing.Point(109, 20)
        Me.TxtVoucherNumber.Name = "TxtVoucherNumber"
        Me.TxtVoucherNumber.Size = New System.Drawing.Size(316, 20)
        Me.TxtVoucherNumber.TabIndex = 0
        '
        'TxtValue
        '
        Me.TxtValue.Location = New System.Drawing.Point(109, 46)
        Me.TxtValue.Name = "TxtValue"
        Me.TxtValue.Properties.DisplayFormat.FormatString = "N0"
        Me.TxtValue.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtValue.Properties.Mask.EditMask = "N0"
        Me.TxtValue.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtValue.Size = New System.Drawing.Size(316, 20)
        Me.TxtValue.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(15, 49)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Nominal"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(15, 101)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl3.TabIndex = 4
        Me.LabelControl3.Text = "On Behalf"
        '
        'TxtOnBehalf
        '
        Me.TxtOnBehalf.Location = New System.Drawing.Point(109, 98)
        Me.TxtOnBehalf.Name = "TxtOnBehalf"
        Me.TxtOnBehalf.Size = New System.Drawing.Size(316, 20)
        Me.TxtOnBehalf.TabIndex = 4
        '
        'MEAddress
        '
        Me.MEAddress.Location = New System.Drawing.Point(15, 128)
        Me.MEAddress.Name = "MEAddress"
        Me.MEAddress.Size = New System.Drawing.Size(39, 13)
        Me.MEAddress.TabIndex = 6
        Me.MEAddress.Text = "Address"
        '
        'MEAddressVoucher
        '
        Me.MEAddressVoucher.Location = New System.Drawing.Point(109, 126)
        Me.MEAddressVoucher.Name = "MEAddressVoucher"
        Me.MEAddressVoucher.Size = New System.Drawing.Size(316, 44)
        Me.MEAddressVoucher.TabIndex = 5
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(15, 75)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(30, 13)
        Me.LabelControl4.TabIndex = 8
        Me.LabelControl4.Text = "Period"
        '
        'DEStart
        '
        Me.DEStart.EditValue = Nothing
        Me.DEStart.Location = New System.Drawing.Point(109, 72)
        Me.DEStart.Name = "DEStart"
        Me.DEStart.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStart.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEStart.Size = New System.Drawing.Size(150, 20)
        Me.DEStart.TabIndex = 2
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(265, 75)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(4, 13)
        Me.LabelControl5.TabIndex = 10
        Me.LabelControl5.Text = "-"
        '
        'DEEnd
        '
        Me.DEEnd.EditValue = Nothing
        Me.DEEnd.Location = New System.Drawing.Point(275, 72)
        Me.DEEnd.Name = "DEEnd"
        Me.DEEnd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEnd.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEnd.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEEnd.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEEnd.Size = New System.Drawing.Size(150, 20)
        Me.DEEnd.TabIndex = 3
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Controls.Add(Me.BtnSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 210)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(449, 41)
        Me.PanelControl1.TabIndex = 12
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(277, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(86, 37)
        Me.BtnCancel.TabIndex = 7
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), System.Drawing.Image)
        Me.BtnSave.Location = New System.Drawing.Point(363, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(84, 37)
        Me.BtnSave.TabIndex = 6
        Me.BtnSave.Text = "Save"
        '
        'CEActive
        '
        Me.CEActive.EditValue = True
        Me.CEActive.Location = New System.Drawing.Point(109, 176)
        Me.CEActive.Name = "CEActive"
        Me.CEActive.Properties.Caption = "Active"
        Me.CEActive.Size = New System.Drawing.Size(75, 19)
        Me.CEActive.TabIndex = 13
        '
        'FormVoucherPOSDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(449, 251)
        Me.Controls.Add(Me.CEActive)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.DEEnd)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.DEStart)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.MEAddressVoucher)
        Me.Controls.Add(Me.MEAddress)
        Me.Controls.Add(Me.TxtOnBehalf)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.TxtValue)
        Me.Controls.Add(Me.TxtVoucherNumber)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormVoucherPOSDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Voucher"
        CType(Me.TxtVoucherNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtValue.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtOnBehalf.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEAddressVoucher.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.CEActive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtVoucherNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtValue As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtOnBehalf As DevExpress.XtraEditors.TextEdit
    Friend WithEvents MEAddress As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MEAddressVoucher As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEEnd As DevExpress.XtraEditors.DateEdit
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CEActive As DevExpress.XtraEditors.CheckEdit
End Class
