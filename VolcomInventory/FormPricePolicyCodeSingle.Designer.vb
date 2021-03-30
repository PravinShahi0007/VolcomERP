<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPricePolicyCodeSingle
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
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LEType = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtAgeMin = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtAgeMax = New DevExpress.XtraEditors.TextEdit()
        CType(Me.LEType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtAgeMin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtAgeMax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnAdd
        '
        Me.BtnAdd.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnAdd.Location = New System.Drawing.Point(0, 164)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(284, 23)
        Me.BtnAdd.TabIndex = 0
        Me.BtnAdd.Text = "Add"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(16, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Type"
        '
        'LEType
        '
        Me.LEType.Location = New System.Drawing.Point(16, 34)
        Me.LEType.Name = "LEType"
        Me.LEType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEType.Size = New System.Drawing.Size(245, 20)
        Me.LEType.TabIndex = 2
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(16, 60)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(38, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Age Min"
        '
        'TxtAgeMin
        '
        Me.TxtAgeMin.Location = New System.Drawing.Point(16, 79)
        Me.TxtAgeMin.Name = "TxtAgeMin"
        Me.TxtAgeMin.Properties.DisplayFormat.FormatString = "N0"
        Me.TxtAgeMin.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtAgeMin.Properties.Mask.EditMask = "N0"
        Me.TxtAgeMin.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtAgeMin.Size = New System.Drawing.Size(245, 20)
        Me.TxtAgeMin.TabIndex = 4
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(16, 105)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(42, 13)
        Me.LabelControl3.TabIndex = 5
        Me.LabelControl3.Text = "Age Max"
        '
        'TxtAgeMax
        '
        Me.TxtAgeMax.Location = New System.Drawing.Point(16, 124)
        Me.TxtAgeMax.Name = "TxtAgeMax"
        Me.TxtAgeMax.Properties.DisplayFormat.FormatString = "N0"
        Me.TxtAgeMax.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtAgeMax.Properties.Mask.EditMask = "N0"
        Me.TxtAgeMax.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtAgeMax.Size = New System.Drawing.Size(245, 20)
        Me.TxtAgeMax.TabIndex = 6
        '
        'FormPricePolicyCodeSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 187)
        Me.Controls.Add(Me.TxtAgeMax)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.TxtAgeMin)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LEType)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.BtnAdd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPricePolicyCodeSingle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Disc. Type"
        CType(Me.LEType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtAgeMin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtAgeMax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtAgeMin As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtAgeMax As DevExpress.XtraEditors.TextEdit
End Class
