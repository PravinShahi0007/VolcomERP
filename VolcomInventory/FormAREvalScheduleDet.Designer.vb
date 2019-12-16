<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAREvalScheduleDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAREvalScheduleDet))
        Me.DESchedule = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.DESchedule.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DESchedule.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DESchedule
        '
        Me.DESchedule.EditValue = Nothing
        Me.DESchedule.Location = New System.Drawing.Point(78, 25)
        Me.DESchedule.Name = "DESchedule"
        Me.DESchedule.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DESchedule.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DESchedule.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DESchedule.Properties.DisplayFormat.FormatString = "dddd ,dd MMMM yyyy"
        Me.DESchedule.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DESchedule.Properties.Mask.EditMask = "dddd,dd MMMM yyyy"
        Me.DESchedule.Size = New System.Drawing.Size(254, 20)
        Me.DESchedule.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(17, 28)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(55, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Select Date"
        '
        'BtnAdd
        '
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"), System.Drawing.Image)
        Me.BtnAdd.Location = New System.Drawing.Point(338, 23)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(60, 23)
        Me.BtnAdd.TabIndex = 2
        Me.BtnAdd.Text = "Add"
        '
        'BtnClose
        '
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(404, 23)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(57, 23)
        Me.BtnClose.TabIndex = 3
        Me.BtnClose.Text = "Close"
        '
        'FormAREvalScheduleDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(478, 78)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.DESchedule)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAREvalScheduleDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Set Schedule"
        CType(Me.DESchedule.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DESchedule.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DESchedule As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
End Class
