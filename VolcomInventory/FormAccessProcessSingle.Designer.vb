<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAccessProcessSingle
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAccessProcessSingle))
        Me.PictureEditIcon = New DevExpress.XtraEditors.PictureEdit
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton
        Me.LabelTitle = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.LEType = New DevExpress.XtraEditors.LookUpEdit
        Me.TxtDescription = New DevExpress.XtraEditors.TextEdit
        Me.EPProcess = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TxtFormControlName = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl
        Me.LabelRequired = New DevExpress.XtraEditors.LabelControl
        CType(Me.PictureEditIcon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LEType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EPProcess, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFormControlName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureEditIcon
        '
        Me.PictureEditIcon.EditValue = CType(resources.GetObject("PictureEditIcon.EditValue"), Object)
        Me.PictureEditIcon.Location = New System.Drawing.Point(12, 5)
        Me.PictureEditIcon.Name = "PictureEditIcon"
        Me.PictureEditIcon.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureEditIcon.Properties.Appearance.Options.UseBackColor = True
        Me.PictureEditIcon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEditIcon.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PictureEditIcon.Size = New System.Drawing.Size(84, 73)
        Me.PictureEditIcon.TabIndex = 46
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Controls.Add(Me.BtnSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 200)
        Me.PanelControl1.LookAndFeel.SkinName = "Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(631, 43)
        Me.PanelControl1.TabIndex = 47
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.Location = New System.Drawing.Point(479, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 39)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.Location = New System.Drawing.Point(554, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 39)
        Me.BtnSave.TabIndex = 3
        Me.BtnSave.Text = "Save"
        '
        'LabelTitle
        '
        Me.LabelTitle.Appearance.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitle.Location = New System.Drawing.Point(167, 25)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(87, 26)
        Me.LabelTitle.TabIndex = 48
        Me.LabelTitle.Text = "Form Title"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(98, 25)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(64, 26)
        Me.LabelControl1.TabIndex = 49
        Me.LabelControl1.Text = "Process"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(19, 152)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(64, 15)
        Me.LabelControl2.TabIndex = 50
        Me.LabelControl2.Text = "Description"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(19, 96)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(25, 15)
        Me.LabelControl3.TabIndex = 52
        Me.LabelControl3.Text = "Type"
        '
        'LEType
        '
        Me.LEType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LEType.Location = New System.Drawing.Point(111, 89)
        Me.LEType.Name = "LEType"
        Me.LEType.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LEType.Properties.Appearance.Options.UseFont = True
        Me.LEType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_form_control", "Id Form Control", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("form_control_type", "Type Control", 20, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.[Default], DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[True])})
        Me.LEType.Size = New System.Drawing.Size(494, 22)
        Me.LEType.TabIndex = 0
        '
        'TxtDescription
        '
        Me.TxtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDescription.Location = New System.Drawing.Point(111, 145)
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescription.Properties.Appearance.Options.UseFont = True
        Me.TxtDescription.Properties.MaxLength = 100
        Me.TxtDescription.Size = New System.Drawing.Size(494, 22)
        Me.TxtDescription.TabIndex = 2
        Me.TxtDescription.ToolTip = "Function description of process. Max : 100 character."
        Me.TxtDescription.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        '
        'EPProcess
        '
        Me.EPProcess.ContainerControl = Me
        '
        'TxtFormControlName
        '
        Me.TxtFormControlName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtFormControlName.Location = New System.Drawing.Point(111, 117)
        Me.TxtFormControlName.Name = "TxtFormControlName"
        Me.TxtFormControlName.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFormControlName.Properties.Appearance.Options.UseFont = True
        Me.TxtFormControlName.Properties.MaxLength = 100
        Me.TxtFormControlName.Size = New System.Drawing.Size(494, 22)
        Me.TxtFormControlName.TabIndex = 1
        Me.TxtFormControlName.ToolTip = "Function description of process. Max : 100 character."
        Me.TxtFormControlName.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(19, 124)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(75, 15)
        Me.LabelControl4.TabIndex = 54
        Me.LabelControl4.Text = "Control Name"
        '
        'LabelRequired
        '
        Me.LabelRequired.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelRequired.Appearance.ForeColor = System.Drawing.Color.Red
        Me.LabelRequired.Location = New System.Drawing.Point(98, 49)
        Me.LabelRequired.Name = "LabelRequired"
        Me.LabelRequired.Size = New System.Drawing.Size(0, 15)
        Me.LabelRequired.TabIndex = 5
        '
        'FormAccessProcessSingle
        '
        Me.AcceptButton = Me.BtnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(631, 243)
        Me.Controls.Add(Me.LabelRequired)
        Me.Controls.Add(Me.TxtFormControlName)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.TxtDescription)
        Me.Controls.Add(Me.LEType)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LabelTitle)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PictureEditIcon)
        Me.MinimizeBox = False
        Me.Name = "FormAccessProcessSingle"
        Me.ShowInTaskbar = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Process Form"
        CType(Me.PictureEditIcon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.LEType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EPProcess, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFormControlName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureEditIcon As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents TxtDescription As DevExpress.XtraEditors.TextEdit
    Friend WithEvents EPProcess As System.Windows.Forms.ErrorProvider
    Friend WithEvents TxtFormControlName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelRequired As DevExpress.XtraEditors.LabelControl
End Class
