﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDesignColumnValue
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDesignColumnValue))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TEColumnName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.SBClose = New DevExpress.XtraEditors.SimpleButton()
        Me.SBSave = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TEType = New DevExpress.XtraEditors.TextEdit()
        Me.TEValue = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TEColumnGroup = New DevExpress.XtraEditors.TextEdit()
        CType(Me.TEColumnName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEValue.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEColumnGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 61)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl1.TabIndex = 4
        Me.LabelControl1.Text = "Column Name"
        '
        'TEColumnName
        '
        Me.TEColumnName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TEColumnName.Location = New System.Drawing.Point(12, 80)
        Me.TEColumnName.Name = "TEColumnName"
        Me.TEColumnName.Properties.ReadOnly = True
        Me.TEColumnName.Size = New System.Drawing.Size(460, 20)
        Me.TEColumnName.TabIndex = 2
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 161)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl2.TabIndex = 6
        Me.LabelControl2.Text = "Value"
        '
        'SBClose
        '
        Me.SBClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SBClose.Image = CType(resources.GetObject("SBClose.Image"), System.Drawing.Image)
        Me.SBClose.Location = New System.Drawing.Point(316, 427)
        Me.SBClose.Name = "SBClose"
        Me.SBClose.Size = New System.Drawing.Size(75, 23)
        Me.SBClose.TabIndex = 6
        Me.SBClose.Text = "Close"
        '
        'SBSave
        '
        Me.SBSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SBSave.Image = CType(resources.GetObject("SBSave.Image"), System.Drawing.Image)
        Me.SBSave.Location = New System.Drawing.Point(397, 427)
        Me.SBSave.Name = "SBSave"
        Me.SBSave.Size = New System.Drawing.Size(75, 23)
        Me.SBSave.TabIndex = 5
        Me.SBSave.Text = "Save"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl3.TabIndex = 10
        Me.LabelControl3.Text = "Type"
        '
        'TEType
        '
        Me.TEType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TEType.Location = New System.Drawing.Point(12, 31)
        Me.TEType.Name = "TEType"
        Me.TEType.Properties.ReadOnly = True
        Me.TEType.Size = New System.Drawing.Size(460, 20)
        Me.TEType.TabIndex = 1
        '
        'TEValue
        '
        Me.TEValue.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TEValue.Location = New System.Drawing.Point(12, 180)
        Me.TEValue.Name = "TEValue"
        Me.TEValue.Size = New System.Drawing.Size(460, 241)
        Me.TEValue.TabIndex = 4
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(12, 111)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(67, 13)
        Me.LabelControl4.TabIndex = 13
        Me.LabelControl4.Text = "Column Group"
        '
        'TEColumnGroup
        '
        Me.TEColumnGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TEColumnGroup.Location = New System.Drawing.Point(12, 130)
        Me.TEColumnGroup.Name = "TEColumnGroup"
        Me.TEColumnGroup.Size = New System.Drawing.Size(460, 20)
        Me.TEColumnGroup.TabIndex = 3
        '
        'FormDesignColumnValue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 461)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.TEColumnGroup)
        Me.Controls.Add(Me.TEValue)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.TEType)
        Me.Controls.Add(Me.SBClose)
        Me.Controls.Add(Me.SBSave)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.TEColumnName)
        Me.Name = "FormDesignColumnValue"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Design Column Value"
        CType(Me.TEColumnName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEValue.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEColumnGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEColumnName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SBClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEType As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEValue As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEColumnGroup As DevExpress.XtraEditors.TextEdit
End Class
