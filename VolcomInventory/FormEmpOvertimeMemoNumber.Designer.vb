<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpOvertimeMemoNumber
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpOvertimeMemoNumber))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TENumber = New DevExpress.XtraEditors.TextEdit()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SBClose = New DevExpress.XtraEditors.SimpleButton()
        Me.SBSave = New DevExpress.XtraEditors.SimpleButton()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.TEFormat = New DevExpress.XtraEditors.TextEdit()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.TEFormat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 14)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(133, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Memo Consumption Number"
        '
        'TENumber
        '
        Me.TENumber.Location = New System.Drawing.Point(156, 11)
        Me.TENumber.Name = "TENumber"
        Me.TENumber.Properties.Mask.EditMask = "000"
        Me.TENumber.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple
        Me.TENumber.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TENumber.Size = New System.Drawing.Size(100, 20)
        Me.TENumber.TabIndex = 1
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SBClose)
        Me.PanelControl1.Controls.Add(Me.SBSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 43)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(484, 42)
        Me.PanelControl1.TabIndex = 4
        '
        'SBClose
        '
        Me.SBClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SBClose.Image = CType(resources.GetObject("SBClose.Image"), System.Drawing.Image)
        Me.SBClose.Location = New System.Drawing.Point(299, 5)
        Me.SBClose.Name = "SBClose"
        Me.SBClose.Size = New System.Drawing.Size(78, 29)
        Me.SBClose.TabIndex = 2
        Me.SBClose.Text = "Close"
        '
        'SBSave
        '
        Me.SBSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SBSave.Image = CType(resources.GetObject("SBSave.Image"), System.Drawing.Image)
        Me.SBSave.Location = New System.Drawing.Point(383, 5)
        Me.SBSave.Name = "SBSave"
        Me.SBSave.Size = New System.Drawing.Size(78, 29)
        Me.SBSave.TabIndex = 0
        Me.SBSave.Text = "Save"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.TEFormat)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Controls.Add(Me.TENumber)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(484, 43)
        Me.PanelControl2.TabIndex = 5
        '
        'TEFormat
        '
        Me.TEFormat.Location = New System.Drawing.Point(279, 11)
        Me.TEFormat.Name = "TEFormat"
        Me.TEFormat.Properties.ReadOnly = True
        Me.TEFormat.Size = New System.Drawing.Size(182, 20)
        Me.TEFormat.TabIndex = 2
        '
        'FormEmpOvertimeMemoNumber
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 85)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpOvertimeMemoNumber"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Overtime Memo Consuption Number"
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.TEFormat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TENumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TEFormat As DevExpress.XtraEditors.TextEdit
End Class
