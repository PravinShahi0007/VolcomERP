<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterSampleDetNote
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
        Me.PicSample = New DevExpress.XtraEditors.PictureEdit
        Me.TEName = New DevExpress.XtraEditors.TextEdit
        Me.TESampleCode = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControlUpdateName = New DevExpress.XtraEditors.LabelControl
        Me.BViewImage = New DevExpress.XtraEditors.SimpleButton
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.MENote = New DevExpress.XtraEditors.MemoEdit
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BAccept = New DevExpress.XtraEditors.SimpleButton
        CType(Me.PicSample.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TESampleCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PicSample
        '
        Me.PicSample.Location = New System.Drawing.Point(12, 12)
        Me.PicSample.Name = "PicSample"
        Me.PicSample.Properties.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.Image
        Me.PicSample.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PicSample.Size = New System.Drawing.Size(187, 220)
        Me.PicSample.TabIndex = 95
        '
        'TEName
        '
        Me.TEName.Location = New System.Drawing.Point(217, 31)
        Me.TEName.Name = "TEName"
        Me.TEName.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TEName.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TEName.Properties.ReadOnly = True
        Me.TEName.Size = New System.Drawing.Size(189, 20)
        Me.TEName.TabIndex = 96
        '
        'TESampleCode
        '
        Me.TESampleCode.Location = New System.Drawing.Point(218, 76)
        Me.TESampleCode.Name = "TESampleCode"
        Me.TESampleCode.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TESampleCode.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TESampleCode.Properties.ReadOnly = True
        Me.TESampleCode.Size = New System.Drawing.Size(188, 20)
        Me.TESampleCode.TabIndex = 99
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(218, 57)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(62, 13)
        Me.LabelControl6.TabIndex = 98
        Me.LabelControl6.Text = "Sample Code"
        '
        'LabelControlUpdateName
        '
        Me.LabelControlUpdateName.Location = New System.Drawing.Point(218, 12)
        Me.LabelControlUpdateName.Name = "LabelControlUpdateName"
        Me.LabelControlUpdateName.Size = New System.Drawing.Size(34, 13)
        Me.LabelControlUpdateName.TabIndex = 97
        Me.LabelControlUpdateName.Text = "Sample"
        '
        'BViewImage
        '
        Me.BViewImage.Location = New System.Drawing.Point(12, 238)
        Me.BViewImage.Name = "BViewImage"
        Me.BViewImage.Size = New System.Drawing.Size(187, 23)
        Me.BViewImage.TabIndex = 100
        Me.BViewImage.Text = "View Image"
        Me.BViewImage.Visible = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl1.Location = New System.Drawing.Point(218, 102)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(25, 15)
        Me.LabelControl1.TabIndex = 137
        Me.LabelControl1.Text = "Note"
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(218, 123)
        Me.MENote.Name = "MENote"
        Me.MENote.Size = New System.Drawing.Size(326, 109)
        Me.MENote.TabIndex = 136
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Location = New System.Drawing.Point(396, 238)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(71, 23)
        Me.BCancel.TabIndex = 139
        Me.BCancel.Text = "Cancel"
        '
        'BAccept
        '
        Me.BAccept.Location = New System.Drawing.Point(473, 238)
        Me.BAccept.Name = "BAccept"
        Me.BAccept.Size = New System.Drawing.Size(71, 23)
        Me.BAccept.TabIndex = 138
        Me.BAccept.Text = "Save"
        '
        'FormMasterSampleDetNote
        '
        Me.AcceptButton = Me.BAccept
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BCancel
        Me.ClientSize = New System.Drawing.Size(556, 273)
        Me.Controls.Add(Me.BCancel)
        Me.Controls.Add(Me.BAccept)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.MENote)
        Me.Controls.Add(Me.BViewImage)
        Me.Controls.Add(Me.TEName)
        Me.Controls.Add(Me.TESampleCode)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.LabelControlUpdateName)
        Me.Controls.Add(Me.PicSample)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterSampleDetNote"
        Me.ShowInTaskbar = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sample Note"
        CType(Me.PicSample.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TESampleCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PicSample As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents TEName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TESampleCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControlUpdateName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BViewImage As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BAccept As DevExpress.XtraEditors.SimpleButton
End Class
