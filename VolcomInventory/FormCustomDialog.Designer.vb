<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCustomDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCustomDialog))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnAction = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.PictureEditIcon = New DevExpress.XtraEditors.PictureEdit()
        Me.LabelContent = New DevExpress.XtraEditors.LabelControl()
        Me.BtnDiscard = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PictureEditIcon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnAction)
        Me.PanelControl1.Controls.Add(Me.BtnDiscard)
        Me.PanelControl1.Controls.Add(Me.BtnOK)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 171)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(462, 40)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnAction
        '
        Me.BtnAction.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAction.Location = New System.Drawing.Point(176, 2)
        Me.BtnAction.Name = "BtnAction"
        Me.BtnAction.Size = New System.Drawing.Size(134, 36)
        Me.BtnAction.TabIndex = 1
        Me.BtnAction.Text = "Action Button"
        '
        'BtnOK
        '
        Me.BtnOK.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnOK.Location = New System.Drawing.Point(385, 2)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(75, 36)
        Me.BtnOK.TabIndex = 0
        Me.BtnOK.Text = "OK"
        '
        'PictureEditIcon
        '
        Me.PictureEditIcon.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureEditIcon.EditValue = CType(resources.GetObject("PictureEditIcon.EditValue"), Object)
        Me.PictureEditIcon.Location = New System.Drawing.Point(0, 0)
        Me.PictureEditIcon.Name = "PictureEditIcon"
        Me.PictureEditIcon.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureEditIcon.Properties.Appearance.Options.UseBackColor = True
        Me.PictureEditIcon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEditIcon.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PictureEditIcon.Size = New System.Drawing.Size(124, 171)
        Me.PictureEditIcon.TabIndex = 19
        '
        'LabelContent
        '
        Me.LabelContent.Appearance.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelContent.Appearance.ForeColor = System.Drawing.Color.Maroon
        Me.LabelContent.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LabelContent.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LabelContent.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelContent.Location = New System.Drawing.Point(124, 0)
        Me.LabelContent.Name = "LabelContent"
        Me.LabelContent.Padding = New System.Windows.Forms.Padding(15, 0, 15, 0)
        Me.LabelContent.Size = New System.Drawing.Size(338, 171)
        Me.LabelContent.TabIndex = 20
        Me.LabelContent.Text = "ERROR STRING"
        '
        'BtnDiscard
        '
        Me.BtnDiscard.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDiscard.Location = New System.Drawing.Point(310, 2)
        Me.BtnDiscard.Name = "BtnDiscard"
        Me.BtnDiscard.Size = New System.Drawing.Size(75, 36)
        Me.BtnDiscard.TabIndex = 2
        Me.BtnDiscard.Text = "Discard"
        '
        'FormCustomDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(462, 211)
        Me.Controls.Add(Me.LabelContent)
        Me.Controls.Add(Me.PictureEditIcon)
        Me.Controls.Add(Me.PanelControl1)
        Me.LookAndFeel.SkinName = "Office 2007 Pink"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCustomDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Warning"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PictureEditIcon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnAction As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PictureEditIcon As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents LabelContent As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnDiscard As DevExpress.XtraEditors.SimpleButton
End Class
