<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSampleSummary
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
        Me.XTCSamnple = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPO = New DevExpress.XtraTab.XtraTabPage()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.BtnViewMat = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton5 = New DevExpress.XtraEditors.SimpleButton()
        Me.DEUntilMat = New DevExpress.XtraEditors.DateEdit()
        Me.DEFromMat = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.XTCSamnple, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCSamnple.SuspendLayout()
        Me.XTPPO.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.DEUntilMat.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilMat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromMat.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromMat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCSamnple
        '
        Me.XTCSamnple.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCSamnple.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCSamnple.Location = New System.Drawing.Point(0, 0)
        Me.XTCSamnple.Name = "XTCSamnple"
        Me.XTCSamnple.SelectedTabPage = Me.XTPPO
        Me.XTCSamnple.Size = New System.Drawing.Size(722, 262)
        Me.XTCSamnple.TabIndex = 0
        Me.XTCSamnple.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPO})
        '
        'XTPPO
        '
        Me.XTPPO.Controls.Add(Me.GroupControl2)
        Me.XTPPO.Name = "XTPPO"
        Me.XTPPO.Size = New System.Drawing.Size(716, 234)
        Me.XTPPO.Text = "Purchase"
        '
        'GroupControl2
        '
        Me.GroupControl2.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl2.Controls.Add(Me.BtnViewMat)
        Me.GroupControl2.Controls.Add(Me.SimpleButton4)
        Me.GroupControl2.Controls.Add(Me.SimpleButton5)
        Me.GroupControl2.Controls.Add(Me.DEUntilMat)
        Me.GroupControl2.Controls.Add(Me.DEFromMat)
        Me.GroupControl2.Controls.Add(Me.LabelControl5)
        Me.GroupControl2.Controls.Add(Me.LabelControl6)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(716, 39)
        Me.GroupControl2.TabIndex = 6
        '
        'BtnViewMat
        '
        Me.BtnViewMat.Location = New System.Drawing.Point(317, 9)
        Me.BtnViewMat.LookAndFeel.SkinName = "Blue"
        Me.BtnViewMat.Name = "BtnViewMat"
        Me.BtnViewMat.Size = New System.Drawing.Size(75, 20)
        Me.BtnViewMat.TabIndex = 8896
        Me.BtnViewMat.Text = "View"
        '
        'SimpleButton4
        '
        Me.SimpleButton4.ImageIndex = 9
        Me.SimpleButton4.Location = New System.Drawing.Point(938, 14)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(104, 20)
        Me.SimpleButton4.TabIndex = 8898
        Me.SimpleButton4.Text = "Hide All Detail"
        Me.SimpleButton4.Visible = False
        '
        'SimpleButton5
        '
        Me.SimpleButton5.ImageIndex = 8
        Me.SimpleButton5.Location = New System.Drawing.Point(835, 14)
        Me.SimpleButton5.Name = "SimpleButton5"
        Me.SimpleButton5.Size = New System.Drawing.Size(99, 20)
        Me.SimpleButton5.TabIndex = 8897
        Me.SimpleButton5.Text = "Expand All Detail"
        Me.SimpleButton5.Visible = False
        '
        'DEUntilMat
        '
        Me.DEUntilMat.EditValue = Nothing
        Me.DEUntilMat.Location = New System.Drawing.Point(202, 9)
        Me.DEUntilMat.Name = "DEUntilMat"
        Me.DEUntilMat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntilMat.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntilMat.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntilMat.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntilMat.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntilMat.Size = New System.Drawing.Size(111, 20)
        Me.DEUntilMat.TabIndex = 8895
        '
        'DEFromMat
        '
        Me.DEFromMat.EditValue = Nothing
        Me.DEFromMat.Location = New System.Drawing.Point(58, 9)
        Me.DEFromMat.Name = "DEFromMat"
        Me.DEFromMat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFromMat.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFromMat.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFromMat.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFromMat.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFromMat.Size = New System.Drawing.Size(111, 20)
        Me.DEFromMat.TabIndex = 8894
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(175, 12)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl5.TabIndex = 8893
        Me.LabelControl5.Text = "Until"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(28, 12)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl6.TabIndex = 8892
        Me.LabelControl6.Text = "From"
        '
        'FormSampleSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(722, 262)
        Me.Controls.Add(Me.XTCSamnple)
        Me.Name = "FormSampleSummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sample"
        CType(Me.XTCSamnple, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCSamnple.ResumeLayout(False)
        Me.XTPPO.ResumeLayout(False)
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.DEUntilMat.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilMat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromMat.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromMat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCSamnple As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPO As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnViewMat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton5 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntilMat As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFromMat As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
End Class
