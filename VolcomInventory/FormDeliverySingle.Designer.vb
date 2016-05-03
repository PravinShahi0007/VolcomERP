<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDeliverySingle
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
        Me.components = New System.ComponentModel.Container()
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.GCtrlDelivery = New DevExpress.XtraEditors.GroupControl()
        Me.DEWHDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.DEDelDate = New DevExpress.XtraEditors.DateEdit()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.SpDelivery = New DevExpress.XtraEditors.SpinEdit()
        Me.LabelDelivery = New DevExpress.XtraEditors.LabelControl()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.GCtrlDelivery, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCtrlDelivery.SuspendLayout()
        CType(Me.DEWHDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEWHDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDelDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDelDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SpDelivery.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar3
        '
        Me.Bar3.BarName = "Status bar"
        Me.Bar3.DockCol = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar3.Text = "Status bar"
        '
        'Bar2
        '
        Me.Bar2.BarName = "Main menu"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.Text = "Main menu"
        '
        'Bar1
        '
        Me.Bar1.BarName = "Tools"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.Text = "Tools"
        '
        'GCtrlDelivery
        '
        Me.GCtrlDelivery.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GCtrlDelivery.Appearance.Options.UseFont = True
        Me.GCtrlDelivery.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GCtrlDelivery.AppearanceCaption.ForeColor = System.Drawing.Color.DimGray
        Me.GCtrlDelivery.AppearanceCaption.Options.UseFont = True
        Me.GCtrlDelivery.AppearanceCaption.Options.UseForeColor = True
        Me.GCtrlDelivery.Controls.Add(Me.DEWHDate)
        Me.GCtrlDelivery.Controls.Add(Me.LabelControl2)
        Me.GCtrlDelivery.Controls.Add(Me.LabelControl1)
        Me.GCtrlDelivery.Controls.Add(Me.DEDelDate)
        Me.GCtrlDelivery.Controls.Add(Me.PanelControl1)
        Me.GCtrlDelivery.Controls.Add(Me.SpDelivery)
        Me.GCtrlDelivery.Controls.Add(Me.LabelDelivery)
        Me.GCtrlDelivery.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCtrlDelivery.Location = New System.Drawing.Point(0, 0)
        Me.GCtrlDelivery.Name = "GCtrlDelivery"
        Me.GCtrlDelivery.Size = New System.Drawing.Size(362, 159)
        Me.GCtrlDelivery.TabIndex = 40
        Me.GCtrlDelivery.Text = "Range 1 - Season Holiday"
        '
        'DEWHDate
        '
        Me.DEWHDate.EditValue = Nothing
        Me.DEWHDate.Location = New System.Drawing.Point(107, 86)
        Me.DEWHDate.Name = "DEWHDate"
        Me.DEWHDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEWHDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEWHDate.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEWHDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEWHDate.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEWHDate.Size = New System.Drawing.Size(234, 20)
        Me.DEWHDate.TabIndex = 2
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(12, 88)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(67, 15)
        Me.LabelControl2.TabIndex = 52
        Me.LabelControl2.Text = "Est WH Date"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(12, 62)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(70, 15)
        Me.LabelControl1.TabIndex = 51
        Me.LabelControl1.Text = "In Store Date"
        '
        'DEDelDate
        '
        Me.DEDelDate.EditValue = Nothing
        Me.DEDelDate.Location = New System.Drawing.Point(107, 60)
        Me.DEDelDate.Name = "DEDelDate"
        Me.DEDelDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDelDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEDelDate.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEDelDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEDelDate.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEDelDate.Size = New System.Drawing.Size(234, 20)
        Me.DEDelDate.TabIndex = 1
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Controls.Add(Me.BtnSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(2, 126)
        Me.PanelControl1.LookAndFeel.SkinName = "Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(358, 31)
        Me.PanelControl1.TabIndex = 49
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.Location = New System.Drawing.Point(206, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 27)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.Location = New System.Drawing.Point(281, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 27)
        Me.BtnSave.TabIndex = 3
        Me.BtnSave.Text = "Save"
        '
        'SpDelivery
        '
        Me.SpDelivery.EditValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.SpDelivery.Location = New System.Drawing.Point(107, 32)
        Me.SpDelivery.Name = "SpDelivery"
        Me.SpDelivery.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpDelivery.Properties.Appearance.Options.UseFont = True
        Me.SpDelivery.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.SpDelivery.Properties.IsFloatValue = False
        Me.SpDelivery.Properties.Mask.EditMask = "N00"
        Me.SpDelivery.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.SpDelivery.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.SpDelivery.Size = New System.Drawing.Size(234, 22)
        Me.SpDelivery.TabIndex = 0
        '
        'LabelDelivery
        '
        Me.LabelDelivery.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDelivery.Location = New System.Drawing.Point(12, 35)
        Me.LabelDelivery.Name = "LabelDelivery"
        Me.LabelDelivery.Size = New System.Drawing.Size(45, 15)
        Me.LabelDelivery.TabIndex = 44
        Me.LabelDelivery.Text = "Delivery"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'FormDeliverySingle
        '
        Me.AcceptButton = Me.BtnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(362, 159)
        Me.Controls.Add(Me.GCtrlDelivery)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormDeliverySingle"
        Me.ShowInTaskbar = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delivery"
        CType(Me.GCtrlDelivery, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GCtrlDelivery.ResumeLayout(False)
        Me.GCtrlDelivery.PerformLayout()
        CType(Me.DEWHDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEWHDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDelDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDelDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.SpDelivery.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents GCtrlDelivery As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SpDelivery As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelDelivery As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEDelDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents DEWHDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
End Class
