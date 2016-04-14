<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAccountingFYearOpen
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BSave = New DevExpress.XtraEditors.SimpleButton
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.TEEnd = New DevExpress.XtraEditors.TextEdit
        Me.TEStart = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.MEAccDesc = New DevExpress.XtraEditors.MemoEdit
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl
        Me.TEStartNext = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.MENext = New DevExpress.XtraEditors.MemoEdit
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.TEEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEAccDesc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.TEStartNext.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENext.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BCancel)
        Me.PanelControl1.Controls.Add(Me.BSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 242)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(626, 36)
        Me.PanelControl1.TabIndex = 128
        '
        'BCancel
        '
        Me.BCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCancel.Location = New System.Drawing.Point(431, 2)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(75, 32)
        Me.BCancel.TabIndex = 3
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.Location = New System.Drawing.Point(506, 2)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(118, 32)
        Me.BSave.TabIndex = 2
        Me.BSave.Text = "Close Fiscal Year"
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.TEEnd)
        Me.GroupControl1.Controls.Add(Me.TEStart)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.MEAccDesc)
        Me.GroupControl1.Controls.Add(Me.LabelControl5)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(626, 142)
        Me.GroupControl1.TabIndex = 129
        Me.GroupControl1.Text = "Current"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(34, 110)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(48, 15)
        Me.LabelControl2.TabIndex = 132
        Me.LabelControl2.Text = "End Date"
        '
        'TEEnd
        '
        Me.TEEnd.Location = New System.Drawing.Point(122, 107)
        Me.TEEnd.Name = "TEEnd"
        Me.TEEnd.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEEnd.Properties.Appearance.Options.UseFont = True
        Me.TEEnd.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.TEEnd.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black
        Me.TEEnd.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TEEnd.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.TEEnd.Properties.ReadOnly = True
        Me.TEEnd.Size = New System.Drawing.Size(261, 22)
        Me.TEEnd.TabIndex = 131
        '
        'TEStart
        '
        Me.TEStart.Location = New System.Drawing.Point(122, 71)
        Me.TEStart.Name = "TEStart"
        Me.TEStart.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEStart.Properties.Appearance.Options.UseFont = True
        Me.TEStart.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.TEStart.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black
        Me.TEStart.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TEStart.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.TEStart.Properties.ReadOnly = True
        Me.TEStart.Size = New System.Drawing.Size(261, 22)
        Me.TEStart.TabIndex = 130
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(34, 74)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(54, 15)
        Me.LabelControl1.TabIndex = 129
        Me.LabelControl1.Text = "Start Date"
        '
        'MEAccDesc
        '
        Me.MEAccDesc.Location = New System.Drawing.Point(122, 10)
        Me.MEAccDesc.Name = "MEAccDesc"
        Me.MEAccDesc.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.MEAccDesc.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black
        Me.MEAccDesc.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.MEAccDesc.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.MEAccDesc.Properties.ReadOnly = True
        Me.MEAccDesc.Size = New System.Drawing.Size(453, 45)
        Me.MEAccDesc.TabIndex = 128
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(34, 12)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(64, 15)
        Me.LabelControl5.TabIndex = 127
        Me.LabelControl5.Text = "Description"
        '
        'GroupControl2
        '
        Me.GroupControl2.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl2.Controls.Add(Me.TEStartNext)
        Me.GroupControl2.Controls.Add(Me.LabelControl3)
        Me.GroupControl2.Controls.Add(Me.MENext)
        Me.GroupControl2.Controls.Add(Me.LabelControl4)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 142)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(626, 100)
        Me.GroupControl2.TabIndex = 130
        Me.GroupControl2.Text = "New"
        '
        'TEStartNext
        '
        Me.TEStartNext.Location = New System.Drawing.Point(122, 68)
        Me.TEStartNext.Name = "TEStartNext"
        Me.TEStartNext.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEStartNext.Properties.Appearance.Options.UseFont = True
        Me.TEStartNext.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.TEStartNext.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black
        Me.TEStartNext.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TEStartNext.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.TEStartNext.Properties.ReadOnly = True
        Me.TEStartNext.Size = New System.Drawing.Size(261, 22)
        Me.TEStartNext.TabIndex = 134
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(34, 71)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(54, 15)
        Me.LabelControl3.TabIndex = 133
        Me.LabelControl3.Text = "Start Date"
        '
        'MENext
        '
        Me.MENext.Location = New System.Drawing.Point(122, 9)
        Me.MENext.Name = "MENext"
        Me.MENext.Size = New System.Drawing.Size(453, 45)
        Me.MENext.TabIndex = 132
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(34, 11)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(64, 15)
        Me.LabelControl4.TabIndex = 131
        Me.LabelControl4.Text = "Description"
        '
        'FormAccountingFYearOpen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(626, 278)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAccountingFYearOpen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Closing"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.TEEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEAccDesc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.TEStartNext.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENext.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEEnd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEStart As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MEAccDesc As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEStartNext As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MENext As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
End Class
