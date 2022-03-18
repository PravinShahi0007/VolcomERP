<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProposePriceMKDFixedPrie
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProposePriceMKDFixedPrie))
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtProposeFinal = New DevExpress.XtraEditors.TextEdit()
        Me.CENoPropose = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnDiscard = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnConfirm = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.TxtProposeFinal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CENoPropose.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(20, 39)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(52, 13)
        Me.LabelControl5.TabIndex = 44
        Me.LabelControl5.Text = "Fixed Price"
        '
        'TxtProposeFinal
        '
        Me.TxtProposeFinal.Location = New System.Drawing.Point(78, 36)
        Me.TxtProposeFinal.Name = "TxtProposeFinal"
        Me.TxtProposeFinal.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProposeFinal.Properties.Appearance.Options.UseFont = True
        Me.TxtProposeFinal.Properties.DisplayFormat.FormatString = "N0"
        Me.TxtProposeFinal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtProposeFinal.Size = New System.Drawing.Size(287, 20)
        Me.TxtProposeFinal.TabIndex = 43
        '
        'CENoPropose
        '
        Me.CENoPropose.Location = New System.Drawing.Point(290, 11)
        Me.CENoPropose.Name = "CENoPropose"
        Me.CENoPropose.Properties.Caption = "No Propose"
        Me.CENoPropose.Size = New System.Drawing.Size(75, 19)
        Me.CENoPropose.TabIndex = 42
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(21, 64)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl6.TabIndex = 41
        Me.LabelControl6.Text = "Note"
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(78, 62)
        Me.MENote.Name = "MENote"
        Me.MENote.Properties.MaxLength = 100
        Me.MENote.Size = New System.Drawing.Size(287, 43)
        Me.MENote.TabIndex = 40
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnDiscard)
        Me.PanelControl1.Controls.Add(Me.BtnConfirm)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 128)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(385, 43)
        Me.PanelControl1.TabIndex = 45
        '
        'BtnDiscard
        '
        Me.BtnDiscard.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDiscard.Image = CType(resources.GetObject("BtnDiscard.Image"), System.Drawing.Image)
        Me.BtnDiscard.Location = New System.Drawing.Point(201, 2)
        Me.BtnDiscard.LookAndFeel.SkinMaskColor = System.Drawing.Color.Red
        Me.BtnDiscard.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnDiscard.Name = "BtnDiscard"
        Me.BtnDiscard.Size = New System.Drawing.Size(91, 39)
        Me.BtnDiscard.TabIndex = 1
        Me.BtnDiscard.Text = "Discard"
        '
        'BtnConfirm
        '
        Me.BtnConfirm.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnConfirm.Image = CType(resources.GetObject("BtnConfirm.Image"), System.Drawing.Image)
        Me.BtnConfirm.Location = New System.Drawing.Point(292, 2)
        Me.BtnConfirm.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnConfirm.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnConfirm.Name = "BtnConfirm"
        Me.BtnConfirm.Size = New System.Drawing.Size(91, 39)
        Me.BtnConfirm.TabIndex = 0
        Me.BtnConfirm.Text = "Confirm"
        '
        'FormProposePriceMKDFixedPrie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(385, 171)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.TxtProposeFinal)
        Me.Controls.Add(Me.CENoPropose)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.MENote)
        Me.MinimizeBox = False
        Me.Name = "FormProposePriceMKDFixedPrie"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fixed Price"
        CType(Me.TxtProposeFinal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CENoPropose.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtProposeFinal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents CENoPropose As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnDiscard As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnConfirm As DevExpress.XtraEditors.SimpleButton
End Class
