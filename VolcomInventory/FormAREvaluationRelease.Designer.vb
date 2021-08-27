<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAREvaluationRelease
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
        Me.SLECompGroup = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.BtnRelease = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAttach = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.TxtMemoNo = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtAREvalNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtAREvalDate = New DevExpress.XtraEditors.TextEdit()
        CType(Me.SLECompGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMemoNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtAREvalNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtAREvalDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SLECompGroup
        '
        Me.SLECompGroup.Location = New System.Drawing.Point(98, 70)
        Me.SLECompGroup.Name = "SLECompGroup"
        Me.SLECompGroup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLECompGroup.Properties.View = Me.SearchLookUpEdit1View
        Me.SLECompGroup.Size = New System.Drawing.Size(364, 20)
        Me.SLECompGroup.TabIndex = 0
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(15, 73)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Group Store"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(15, 98)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Note"
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(98, 96)
        Me.MENote.Name = "MENote"
        Me.MENote.Size = New System.Drawing.Size(364, 65)
        Me.MENote.TabIndex = 3
        '
        'BtnRelease
        '
        Me.BtnRelease.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRelease.Enabled = False
        Me.BtnRelease.Location = New System.Drawing.Point(236, 170)
        Me.BtnRelease.Name = "BtnRelease"
        Me.BtnRelease.Size = New System.Drawing.Size(71, 23)
        Me.BtnRelease.TabIndex = 4
        Me.BtnRelease.Text = "Release"
        '
        'BtnAttach
        '
        Me.BtnAttach.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAttach.Enabled = False
        Me.BtnAttach.Location = New System.Drawing.Point(313, 170)
        Me.BtnAttach.Name = "BtnAttach"
        Me.BtnAttach.Size = New System.Drawing.Size(79, 23)
        Me.BtnAttach.TabIndex = 5
        Me.BtnAttach.Text = "Attachment"
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Location = New System.Drawing.Point(398, 170)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(64, 23)
        Me.BtnSave.TabIndex = 6
        Me.BtnSave.Text = "Save"
        '
        'TxtMemoNo
        '
        Me.TxtMemoNo.Location = New System.Drawing.Point(98, 44)
        Me.TxtMemoNo.Name = "TxtMemoNo"
        Me.TxtMemoNo.Size = New System.Drawing.Size(364, 20)
        Me.TxtMemoNo.TabIndex = 7
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(15, 47)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl3.TabIndex = 8
        Me.LabelControl3.Text = "Memo No."
        '
        'TxtAREvalNumber
        '
        Me.TxtAREvalNumber.Enabled = False
        Me.TxtAREvalNumber.Location = New System.Drawing.Point(98, 18)
        Me.TxtAREvalNumber.Name = "TxtAREvalNumber"
        Me.TxtAREvalNumber.Size = New System.Drawing.Size(180, 20)
        Me.TxtAREvalNumber.TabIndex = 9
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(15, 21)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl4.TabIndex = 11
        Me.LabelControl4.Text = "Evaluation"
        '
        'TxtAREvalDate
        '
        Me.TxtAREvalDate.Enabled = False
        Me.TxtAREvalDate.Location = New System.Drawing.Point(282, 18)
        Me.TxtAREvalDate.Name = "TxtAREvalDate"
        Me.TxtAREvalDate.Size = New System.Drawing.Size(180, 20)
        Me.TxtAREvalDate.TabIndex = 10
        '
        'FormAREvaluationRelease
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(480, 218)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.TxtAREvalDate)
        Me.Controls.Add(Me.TxtAREvalNumber)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.TxtMemoNo)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnAttach)
        Me.Controls.Add(Me.BtnRelease)
        Me.Controls.Add(Me.MENote)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.SLECompGroup)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAREvaluationRelease"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Release"
        CType(Me.SLECompGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMemoNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtAREvalNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtAREvalDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SLECompGroup As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents BtnRelease As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAttach As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtMemoNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtAREvalNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtAREvalDate As DevExpress.XtraEditors.TextEdit
End Class
