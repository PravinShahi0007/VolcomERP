<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRangeSingle
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
        Me.LabelRange = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.EPRange = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TxtRange = New DevExpress.XtraEditors.SpinEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.MEDescription = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtSeason = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtSeasonPrintedName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtYear = New DevExpress.XtraEditors.TextEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.EPRange, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtRange.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSeasonPrintedName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelRange
        '
        Me.LabelRange.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelRange.Location = New System.Drawing.Point(12, 15)
        Me.LabelRange.Name = "LabelRange"
        Me.LabelRange.Size = New System.Drawing.Size(33, 15)
        Me.LabelRange.TabIndex = 0
        Me.LabelRange.Text = "Range"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Controls.Add(Me.BtnSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 203)
        Me.PanelControl1.LookAndFeel.SkinName = "Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(441, 36)
        Me.PanelControl1.TabIndex = 3
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.Location = New System.Drawing.Point(289, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 32)
        Me.BtnCancel.TabIndex = 6
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.Location = New System.Drawing.Point(364, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 32)
        Me.BtnSave.TabIndex = 5
        Me.BtnSave.Text = "Save"
        '
        'EPRange
        '
        Me.EPRange.ContainerControl = Me
        '
        'TxtRange
        '
        Me.TxtRange.EditValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TxtRange.Location = New System.Drawing.Point(140, 12)
        Me.TxtRange.Name = "TxtRange"
        Me.TxtRange.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRange.Properties.Appearance.Options.UseFont = True
        Me.TxtRange.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtRange.Properties.IsFloatValue = False
        Me.TxtRange.Properties.Mask.EditMask = "F00"
        Me.TxtRange.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.TxtRange.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TxtRange.Size = New System.Drawing.Size(274, 22)
        Me.TxtRange.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(12, 120)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(64, 15)
        Me.LabelControl1.TabIndex = 4
        Me.LabelControl1.Text = "Description"
        '
        'MEDescription
        '
        Me.MEDescription.Location = New System.Drawing.Point(140, 118)
        Me.MEDescription.Name = "MEDescription"
        Me.MEDescription.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MEDescription.Properties.Appearance.Options.UseFont = True
        Me.MEDescription.Properties.MaxLength = 100
        Me.MEDescription.Size = New System.Drawing.Size(274, 63)
        Me.MEDescription.TabIndex = 4
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(12, 68)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(39, 15)
        Me.LabelControl2.TabIndex = 5
        Me.LabelControl2.Text = "Season"
        '
        'TxtSeason
        '
        Me.TxtSeason.Location = New System.Drawing.Point(140, 66)
        Me.TxtSeason.Name = "TxtSeason"
        Me.TxtSeason.Size = New System.Drawing.Size(274, 20)
        Me.TxtSeason.TabIndex = 2
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(12, 95)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(105, 15)
        Me.LabelControl3.TabIndex = 7
        Me.LabelControl3.Text = "Season Short Name"
        '
        'TxtSeasonPrintedName
        '
        Me.TxtSeasonPrintedName.Location = New System.Drawing.Point(140, 92)
        Me.TxtSeasonPrintedName.Name = "TxtSeasonPrintedName"
        Me.TxtSeasonPrintedName.Size = New System.Drawing.Size(274, 20)
        Me.TxtSeasonPrintedName.TabIndex = 3
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(12, 42)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(24, 15)
        Me.LabelControl4.TabIndex = 9
        Me.LabelControl4.Text = "Year"
        '
        'TxtYear
        '
        Me.TxtYear.Location = New System.Drawing.Point(140, 40)
        Me.TxtYear.Name = "TxtYear"
        Me.TxtYear.Size = New System.Drawing.Size(274, 20)
        Me.TxtYear.TabIndex = 1
        '
        'FormRangeSingle
        '
        Me.AcceptButton = Me.BtnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(441, 239)
        Me.Controls.Add(Me.TxtYear)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.TxtSeasonPrintedName)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.TxtSeason)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.MEDescription)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.TxtRange)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.LabelRange)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormRangeSingle"
        Me.ShowInTaskbar = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Range"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.EPRange, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtRange.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSeasonPrintedName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelRange As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents EPRange As System.Windows.Forms.ErrorProvider
    Friend WithEvents TxtRange As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MEDescription As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents TxtSeasonPrintedName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtSeason As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtYear As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
End Class
