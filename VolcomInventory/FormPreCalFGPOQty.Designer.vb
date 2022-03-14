<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPreCalFGPOQty
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
        Me.BPropose = New DevExpress.XtraEditors.SimpleButton()
        Me.TEQtyShipment = New DevExpress.XtraEditors.SpinEdit()
        Me.LShipment = New DevExpress.XtraEditors.LabelControl()
        CType(Me.TEQtyShipment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BPropose
        '
        Me.BPropose.Appearance.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BPropose.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BPropose.Appearance.ForeColor = System.Drawing.Color.White
        Me.BPropose.Appearance.Options.UseBackColor = True
        Me.BPropose.Appearance.Options.UseFont = True
        Me.BPropose.Appearance.Options.UseForeColor = True
        Me.BPropose.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BPropose.Location = New System.Drawing.Point(0, 67)
        Me.BPropose.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BPropose.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BPropose.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BPropose.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BPropose.Name = "BPropose"
        Me.BPropose.Size = New System.Drawing.Size(400, 38)
        Me.BPropose.TabIndex = 22
        Me.BPropose.Text = "save"
        '
        'TEQtyShipment
        '
        Me.TEQtyShipment.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TEQtyShipment.Location = New System.Drawing.Point(94, 24)
        Me.TEQtyShipment.Name = "TEQtyShipment"
        Me.TEQtyShipment.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TEQtyShipment.Size = New System.Drawing.Size(294, 20)
        Me.TEQtyShipment.TabIndex = 23
        '
        'LShipment
        '
        Me.LShipment.Location = New System.Drawing.Point(12, 27)
        Me.LShipment.Name = "LShipment"
        Me.LShipment.Size = New System.Drawing.Size(65, 13)
        Me.LShipment.TabIndex = 24
        Me.LShipment.Text = "Shipment Qty"
        '
        'FormPreCalFGPOQty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 105)
        Me.Controls.Add(Me.LShipment)
        Me.Controls.Add(Me.TEQtyShipment)
        Me.Controls.Add(Me.BPropose)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPreCalFGPOQty"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Qty Shipment"
        CType(Me.TEQtyShipment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BPropose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEQtyShipment As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LShipment As DevExpress.XtraEditors.LabelControl
End Class
