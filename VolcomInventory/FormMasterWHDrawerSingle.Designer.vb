<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterWHDrawerSingle
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
        Me.LabelSubTitle = New DevExpress.XtraEditors.LabelControl
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.LabelTitle = New DevExpress.XtraEditors.LabelControl
        Me.MEDesription = New DevExpress.XtraEditors.MemoEdit
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.EPWH = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl
        Me.TxtRackName = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.TxtRackCode = New DevExpress.XtraEditors.TextEdit
        Me.LabelSeason = New DevExpress.XtraEditors.LabelControl
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        CType(Me.MEDesription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EPWH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.TxtRackName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtRackCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelSubTitle
        '
        Me.LabelSubTitle.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSubTitle.Location = New System.Drawing.Point(12, 32)
        Me.LabelSubTitle.Name = "LabelSubTitle"
        Me.LabelSubTitle.Size = New System.Drawing.Size(184, 15)
        Me.LabelSubTitle.TabIndex = 30
        Me.LabelSubTitle.Text = "Warehouse/Locator/Drawer : xxx "
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.Location = New System.Drawing.Point(537, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 37)
        Me.BtnCancel.TabIndex = 5
        Me.BtnCancel.Text = "Cancel"
        '
        'LabelTitle
        '
        Me.LabelTitle.Appearance.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitle.Location = New System.Drawing.Point(11, 10)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(155, 23)
        Me.LabelTitle.TabIndex = 29
        Me.LabelTitle.Text = "Drawer Description"
        '
        'MEDesription
        '
        Me.MEDesription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MEDesription.Location = New System.Drawing.Point(103, 135)
        Me.MEDesription.Name = "MEDesription"
        Me.MEDesription.Size = New System.Drawing.Size(566, 120)
        Me.MEDesription.TabIndex = 49
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.Location = New System.Drawing.Point(612, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 37)
        Me.BtnSave.TabIndex = 4
        Me.BtnSave.Text = "Save"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(12, 137)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(64, 15)
        Me.LabelControl2.TabIndex = 48
        Me.LabelControl2.Text = "Description"
        '
        'EPWH
        '
        Me.EPWH.ContainerControl = Me
        '
        'PanelControl2
        '
        Me.PanelControl2.Appearance.BackColor = System.Drawing.Color.Blue
        Me.PanelControl2.Appearance.Options.UseBackColor = True
        Me.PanelControl2.Controls.Add(Me.LabelSubTitle)
        Me.PanelControl2.Controls.Add(Me.LabelTitle)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.LookAndFeel.SkinName = "Office 2007 Blue"
        Me.PanelControl2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(689, 59)
        Me.PanelControl2.TabIndex = 47
        '
        'TxtRackName
        '
        Me.TxtRackName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtRackName.Location = New System.Drawing.Point(103, 103)
        Me.TxtRackName.Name = "TxtRackName"
        Me.TxtRackName.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRackName.Properties.Appearance.Options.UseFont = True
        Me.TxtRackName.Properties.MaxLength = 50
        Me.TxtRackName.Size = New System.Drawing.Size(566, 22)
        Me.TxtRackName.TabIndex = 46
        Me.TxtRackName.ToolTip = "Max :  50 character."
        Me.TxtRackName.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.TxtRackName.ToolTipTitle = "Information"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(12, 110)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(74, 15)
        Me.LabelControl1.TabIndex = 45
        Me.LabelControl1.Text = "Drawer Name"
        '
        'TxtRackCode
        '
        Me.TxtRackCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtRackCode.Location = New System.Drawing.Point(103, 75)
        Me.TxtRackCode.Name = "TxtRackCode"
        Me.TxtRackCode.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRackCode.Properties.Appearance.Options.UseFont = True
        Me.TxtRackCode.Properties.MaxLength = 20
        Me.TxtRackCode.Size = New System.Drawing.Size(566, 22)
        Me.TxtRackCode.TabIndex = 43
        Me.TxtRackCode.ToolTip = "Max :  20 character."
        Me.TxtRackCode.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.TxtRackCode.ToolTipTitle = "Information"
        '
        'LabelSeason
        '
        Me.LabelSeason.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSeason.Location = New System.Drawing.Point(12, 82)
        Me.LabelSeason.Name = "LabelSeason"
        Me.LabelSeason.Size = New System.Drawing.Size(70, 15)
        Me.LabelSeason.TabIndex = 44
        Me.LabelSeason.Text = "Drawer Code"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Controls.Add(Me.BtnSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 266)
        Me.PanelControl1.LookAndFeel.SkinName = "Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(689, 41)
        Me.PanelControl1.TabIndex = 42
        '
        'FormMasterWHDrawerSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(689, 307)
        Me.Controls.Add(Me.MEDesription)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.TxtRackName)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.TxtRackCode)
        Me.Controls.Add(Me.LabelSeason)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormMasterWHDrawerSingle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Drawer WH"
        CType(Me.MEDesription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EPWH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.TxtRackName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtRackCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelSubTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MEDesription As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents EPWH As System.Windows.Forms.ErrorProvider
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TxtRackName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtRackCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelSeason As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
End Class
