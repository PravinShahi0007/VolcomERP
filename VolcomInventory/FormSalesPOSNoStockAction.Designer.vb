<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesPOSNoStockAction
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSalesPOSNoStockAction))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnVerify = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.TEQty = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TEQty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 62)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Remark"
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(12, 81)
        Me.MENote.Name = "MENote"
        Me.MENote.Size = New System.Drawing.Size(290, 48)
        Me.MENote.TabIndex = 5
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(136, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(86, 38)
        Me.BtnCancel.TabIndex = 2
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnVerify
        '
        Me.BtnVerify.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnVerify.Image = CType(resources.GetObject("BtnVerify.Image"), System.Drawing.Image)
        Me.BtnVerify.Location = New System.Drawing.Point(222, 2)
        Me.BtnVerify.Name = "BtnVerify"
        Me.BtnVerify.Size = New System.Drawing.Size(90, 38)
        Me.BtnVerify.TabIndex = 3
        Me.BtnVerify.Text = "Verify"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Controls.Add(Me.BtnVerify)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 141)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(314, 42)
        Me.PanelControl1.TabIndex = 4
        '
        'TEQty
        '
        Me.TEQty.EditValue = ""
        Me.TEQty.Location = New System.Drawing.Point(12, 31)
        Me.TEQty.Name = "TEQty"
        Me.TEQty.Properties.DisplayFormat.FormatString = "N0"
        Me.TEQty.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TEQty.Properties.EditFormat.FormatString = "N0"
        Me.TEQty.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TEQty.Properties.Mask.EditMask = "N0"
        Me.TEQty.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEQty.Size = New System.Drawing.Size(290, 20)
        Me.TEQty.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(18, 13)
        Me.LabelControl2.TabIndex = 6
        Me.LabelControl2.Text = "Qty"
        '
        'FormSalesPOSNoStockAction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(314, 183)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.TEQty)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.MENote)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSalesPOSNoStockAction"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "No Stock - Action"
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.TEQty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnVerify As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TEQty As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
End Class
