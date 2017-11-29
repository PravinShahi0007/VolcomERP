<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAccountingDraftJournalSingle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAccountingDraftJournalSingle))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtRef = New DevExpress.XtraEditors.TextEdit()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.TxtDebit = New DevExpress.XtraEditors.TextEdit()
        Me.TxtCredit = New DevExpress.XtraEditors.TextEdit()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnSaveExit = New DevExpress.XtraEditors.SimpleButton()
        Me.TxtAccountAcc = New DevExpress.XtraEditors.TextEdit()
        Me.TxtAccountAccDesc = New DevExpress.XtraEditors.TextEdit()
        Me.TxtCompNumber = New DevExpress.XtraEditors.TextEdit()
        Me.TxtCompName = New DevExpress.XtraEditors.TextEdit()
        CType(Me.TxtRef.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDebit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCredit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TxtAccountAcc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtAccountAccDesc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCompNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCompName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Account"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Reference"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Note"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 157)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Supplier / Customer"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 196)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Debit"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(164, 196)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Credit"
        '
        'TxtRef
        '
        Me.TxtRef.Enabled = False
        Me.TxtRef.Location = New System.Drawing.Point(21, 72)
        Me.TxtRef.Name = "TxtRef"
        Me.TxtRef.Size = New System.Drawing.Size(301, 20)
        Me.TxtRef.TabIndex = 1
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(21, 111)
        Me.MENote.Name = "MENote"
        Me.MENote.Size = New System.Drawing.Size(301, 43)
        Me.MENote.TabIndex = 1
        '
        'TxtDebit
        '
        Me.TxtDebit.Location = New System.Drawing.Point(21, 212)
        Me.TxtDebit.Name = "TxtDebit"
        Me.TxtDebit.Properties.DisplayFormat.FormatString = "{0:n2}"
        Me.TxtDebit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtDebit.Properties.Mask.EditMask = "n2"
        Me.TxtDebit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtDebit.Size = New System.Drawing.Size(145, 20)
        Me.TxtDebit.TabIndex = 3
        '
        'TxtCredit
        '
        Me.TxtCredit.Location = New System.Drawing.Point(167, 212)
        Me.TxtCredit.Name = "TxtCredit"
        Me.TxtCredit.Properties.DisplayFormat.FormatString = "{0:n2}"
        Me.TxtCredit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtCredit.Properties.Mask.EditMask = "n2"
        Me.TxtCredit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtCredit.Size = New System.Drawing.Size(155, 20)
        Me.TxtCredit.TabIndex = 4
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnSaveExit)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 249)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(344, 40)
        Me.PanelControl1.TabIndex = 100
        '
        'BtnSaveExit
        '
        Me.BtnSaveExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSaveExit.Image = CType(resources.GetObject("BtnSaveExit.Image"), System.Drawing.Image)
        Me.BtnSaveExit.Location = New System.Drawing.Point(258, 2)
        Me.BtnSaveExit.Name = "BtnSaveExit"
        Me.BtnSaveExit.Size = New System.Drawing.Size(84, 36)
        Me.BtnSaveExit.TabIndex = 5
        Me.BtnSaveExit.Text = "Save"
        '
        'TxtAccountAcc
        '
        Me.TxtAccountAcc.EditValue = ""
        Me.TxtAccountAcc.Location = New System.Drawing.Point(21, 29)
        Me.TxtAccountAcc.Name = "TxtAccountAcc"
        Me.TxtAccountAcc.Size = New System.Drawing.Size(74, 20)
        Me.TxtAccountAcc.TabIndex = 101
        '
        'TxtAccountAccDesc
        '
        Me.TxtAccountAccDesc.Enabled = False
        Me.TxtAccountAccDesc.Location = New System.Drawing.Point(98, 29)
        Me.TxtAccountAccDesc.Name = "TxtAccountAccDesc"
        Me.TxtAccountAccDesc.Size = New System.Drawing.Size(224, 20)
        Me.TxtAccountAccDesc.TabIndex = 102
        '
        'TxtCompNumber
        '
        Me.TxtCompNumber.EditValue = ""
        Me.TxtCompNumber.Location = New System.Drawing.Point(21, 173)
        Me.TxtCompNumber.Name = "TxtCompNumber"
        Me.TxtCompNumber.Size = New System.Drawing.Size(74, 20)
        Me.TxtCompNumber.TabIndex = 2
        '
        'TxtCompName
        '
        Me.TxtCompName.Enabled = False
        Me.TxtCompName.Location = New System.Drawing.Point(98, 173)
        Me.TxtCompName.Name = "TxtCompName"
        Me.TxtCompName.Size = New System.Drawing.Size(224, 20)
        Me.TxtCompName.TabIndex = 104
        '
        'FormAccountingDraftJournalSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(344, 289)
        Me.Controls.Add(Me.TxtCompName)
        Me.Controls.Add(Me.TxtCompNumber)
        Me.Controls.Add(Me.TxtAccountAccDesc)
        Me.Controls.Add(Me.TxtAccountAcc)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.TxtCredit)
        Me.Controls.Add(Me.TxtDebit)
        Me.Controls.Add(Me.MENote)
        Me.Controls.Add(Me.TxtRef)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAccountingDraftJournalSingle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Journal"
        CType(Me.TxtRef.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDebit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCredit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.TxtAccountAcc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtAccountAccDesc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCompNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCompName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtRef As DevExpress.XtraEditors.TextEdit
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents TxtDebit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtCredit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnSaveExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtAccountAcc As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtAccountAccDesc As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtCompNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtCompName As DevExpress.XtraEditors.TextEdit
End Class
