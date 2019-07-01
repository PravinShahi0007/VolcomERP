<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGDesignListChangesNew
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFGDesignListChangesNew))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnCreateNew = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnDiscard = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(18, 14)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Note"
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(18, 33)
        Me.MENote.Name = "MENote"
        Me.MENote.Size = New System.Drawing.Size(340, 64)
        Me.MENote.TabIndex = 1
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnDiscard)
        Me.PanelControl1.Controls.Add(Me.BtnCreateNew)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 132)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(377, 42)
        Me.PanelControl1.TabIndex = 2
        '
        'BtnCreateNew
        '
        Me.BtnCreateNew.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCreateNew.Image = CType(resources.GetObject("BtnCreateNew.Image"), System.Drawing.Image)
        Me.BtnCreateNew.Location = New System.Drawing.Point(269, 2)
        Me.BtnCreateNew.Name = "BtnCreateNew"
        Me.BtnCreateNew.Size = New System.Drawing.Size(106, 38)
        Me.BtnCreateNew.TabIndex = 0
        Me.BtnCreateNew.Text = "Create New"
        '
        'BtnDiscard
        '
        Me.BtnDiscard.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDiscard.Image = CType(resources.GetObject("BtnDiscard.Image"), System.Drawing.Image)
        Me.BtnDiscard.Location = New System.Drawing.Point(170, 2)
        Me.BtnDiscard.Name = "BtnDiscard"
        Me.BtnDiscard.Size = New System.Drawing.Size(99, 38)
        Me.BtnDiscard.TabIndex = 1
        Me.BtnDiscard.Text = "Discard"
        '
        'FormFGDesignListChangesNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 174)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.MENote)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormFGDesignListChangesNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create New - Propose Design Changes"
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnDiscard As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCreateNew As DevExpress.XtraEditors.SimpleButton
End Class
