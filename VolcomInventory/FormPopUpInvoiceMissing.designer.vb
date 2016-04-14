<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpInvoiceMissing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPopUpInvoiceMissing))
        Me.PanelControlNav = New DevExpress.XtraEditors.PanelControl
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BtnChoose = New DevExpress.XtraEditors.SimpleButton
        Me.DEDueDate = New DevExpress.XtraEditors.DateEdit
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl
        Me.PictureMenuAccess = New DevExpress.XtraEditors.PictureEdit
        Me.MENote = New DevExpress.XtraEditors.MemoEdit
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl
        Me.MQPBMissing = New DevExpress.XtraEditors.MarqueeProgressBarControl
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNav.SuspendLayout()
        CType(Me.DEDueDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDueDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureMenuAccess.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MQPBMissing.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControlNav
        '
        Me.PanelControlNav.Controls.Add(Me.BtnCancel)
        Me.PanelControlNav.Controls.Add(Me.BtnChoose)
        Me.PanelControlNav.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControlNav.Location = New System.Drawing.Point(0, 129)
        Me.PanelControlNav.LookAndFeel.SkinName = "Blue"
        Me.PanelControlNav.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControlNav.Name = "PanelControlNav"
        Me.PanelControlNav.Size = New System.Drawing.Size(492, 36)
        Me.PanelControlNav.TabIndex = 8
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.Location = New System.Drawing.Point(340, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 32)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnChoose
        '
        Me.BtnChoose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnChoose.Location = New System.Drawing.Point(415, 2)
        Me.BtnChoose.Name = "BtnChoose"
        Me.BtnChoose.Size = New System.Drawing.Size(75, 32)
        Me.BtnChoose.TabIndex = 3
        Me.BtnChoose.Text = "Generate"
        '
        'DEDueDate
        '
        Me.DEDueDate.EditValue = Nothing
        Me.DEDueDate.Location = New System.Drawing.Point(192, 12)
        Me.DEDueDate.Name = "DEDueDate"
        Me.DEDueDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDueDate.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEDueDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEDueDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.DEDueDate.Size = New System.Drawing.Size(276, 20)
        Me.DEDueDate.TabIndex = 8931
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Location = New System.Drawing.Point(127, 15)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl8.TabIndex = 8932
        Me.LabelControl8.Text = "Due Date"
        '
        'PictureMenuAccess
        '
        Me.PictureMenuAccess.EditValue = CType(resources.GetObject("PictureMenuAccess.EditValue"), Object)
        Me.PictureMenuAccess.Location = New System.Drawing.Point(10, 12)
        Me.PictureMenuAccess.Name = "PictureMenuAccess"
        Me.PictureMenuAccess.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureMenuAccess.Properties.Appearance.Options.UseBackColor = True
        Me.PictureMenuAccess.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureMenuAccess.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PictureMenuAccess.Size = New System.Drawing.Size(111, 97)
        Me.PictureMenuAccess.TabIndex = 8933
        '
        'MENote
        '
        Me.MENote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MENote.Location = New System.Drawing.Point(192, 38)
        Me.MENote.Name = "MENote"
        Me.MENote.Properties.MaxLength = 100
        Me.MENote.Size = New System.Drawing.Size(276, 64)
        Me.MENote.TabIndex = 8934
        '
        'LabelControl18
        '
        Me.LabelControl18.Location = New System.Drawing.Point(127, 41)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl18.TabIndex = 8935
        Me.LabelControl18.Text = "Note"
        '
        'MQPBMissing
        '
        Me.MQPBMissing.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MQPBMissing.EditValue = 0
        Me.MQPBMissing.Location = New System.Drawing.Point(0, 119)
        Me.MQPBMissing.Name = "MQPBMissing"
        Me.MQPBMissing.Properties.MarqueeAnimationSpeed = 80
        Me.MQPBMissing.Properties.ProgressAnimationMode = DevExpress.Utils.Drawing.ProgressAnimationMode.PingPong
        Me.MQPBMissing.Size = New System.Drawing.Size(492, 10)
        Me.MQPBMissing.TabIndex = 8936
        '
        'FormPopUpInvoiceMissing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 165)
        Me.Controls.Add(Me.MQPBMissing)
        Me.Controls.Add(Me.MENote)
        Me.Controls.Add(Me.LabelControl18)
        Me.Controls.Add(Me.PictureMenuAccess)
        Me.Controls.Add(Me.DEDueDate)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.PanelControlNav)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPopUpInvoiceMissing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inovice Missing"
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNav.ResumeLayout(False)
        CType(Me.DEDueDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDueDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureMenuAccess.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MQPBMissing.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelControlNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnChoose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEDueDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PictureMenuAccess As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MQPBMissing As DevExpress.XtraEditors.MarqueeProgressBarControl
End Class
