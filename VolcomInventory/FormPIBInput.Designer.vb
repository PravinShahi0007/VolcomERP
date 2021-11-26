<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPIBInput
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPIBInput))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TEPIBTaxAmount = New DevExpress.XtraEditors.TextEdit()
        Me.TEPIBNumber = New DevExpress.XtraEditors.TextEdit()
        Me.TEBudgetNumber = New DevExpress.XtraEditors.TextEdit()
        Me.DEPIB = New DevExpress.XtraEditors.DateEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TEPIBTaxAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPIBNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEBudgetNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEPIB.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEPIB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BClose)
        Me.PanelControl1.Controls.Add(Me.BSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 152)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(494, 47)
        Me.PanelControl1.TabIndex = 0
        '
        'BClose
        '
        Me.BClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BClose.Image = CType(resources.GetObject("BClose.Image"), System.Drawing.Image)
        Me.BClose.Location = New System.Drawing.Point(272, 2)
        Me.BClose.Name = "BClose"
        Me.BClose.Size = New System.Drawing.Size(110, 43)
        Me.BClose.TabIndex = 1
        Me.BClose.Text = "Close"
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.Image = CType(resources.GetObject("BSave.Image"), System.Drawing.Image)
        Me.BSave.Location = New System.Drawing.Point(382, 2)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(110, 43)
        Me.BSave.TabIndex = 0
        Me.BSave.Text = "Save"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(19, 21)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(74, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Budget Number"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(19, 54)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "PIB Number"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(19, 86)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(42, 13)
        Me.LabelControl3.TabIndex = 3
        Me.LabelControl3.Text = "PIB Date"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(19, 119)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(77, 13)
        Me.LabelControl4.TabIndex = 4
        Me.LabelControl4.Text = "PIB Tax Amount"
        '
        'TEPIBTaxAmount
        '
        Me.TEPIBTaxAmount.Location = New System.Drawing.Point(119, 116)
        Me.TEPIBTaxAmount.Name = "TEPIBTaxAmount"
        Me.TEPIBTaxAmount.Size = New System.Drawing.Size(213, 20)
        Me.TEPIBTaxAmount.TabIndex = 5
        '
        'TEPIBNumber
        '
        Me.TEPIBNumber.Location = New System.Drawing.Point(119, 51)
        Me.TEPIBNumber.Name = "TEPIBNumber"
        Me.TEPIBNumber.Size = New System.Drawing.Size(353, 20)
        Me.TEPIBNumber.TabIndex = 6
        '
        'TEBudgetNumber
        '
        Me.TEBudgetNumber.Location = New System.Drawing.Point(119, 18)
        Me.TEBudgetNumber.Name = "TEBudgetNumber"
        Me.TEBudgetNumber.Properties.ReadOnly = True
        Me.TEBudgetNumber.Size = New System.Drawing.Size(272, 20)
        Me.TEBudgetNumber.TabIndex = 7
        '
        'DEPIB
        '
        Me.DEPIB.EditValue = Nothing
        Me.DEPIB.Location = New System.Drawing.Point(119, 83)
        Me.DEPIB.Name = "DEPIB"
        Me.DEPIB.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEPIB.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEPIB.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEPIB.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEPIB.Size = New System.Drawing.Size(242, 20)
        Me.DEPIB.TabIndex = 181
        '
        'FormPIBInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 199)
        Me.Controls.Add(Me.DEPIB)
        Me.Controls.Add(Me.TEBudgetNumber)
        Me.Controls.Add(Me.TEPIBNumber)
        Me.Controls.Add(Me.TEPIBTaxAmount)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPIBInput"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Input Detail PIB"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.TEPIBTaxAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPIBNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEBudgetNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEPIB.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEPIB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEPIBTaxAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEPIBNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEBudgetNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEPIB As DevExpress.XtraEditors.DateEdit
End Class
