<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterEmployeeCustom
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
        Me.XTCCustomView = New DevExpress.XtraTab.XtraTabControl()
        Me.XtpContract = New DevExpress.XtraTab.XtraTabPage()
        Me.DEStart = New DevExpress.XtraEditors.DateEdit()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPAge = New DevExpress.XtraTab.XtraTabPage()
        Me.BtnViewAge = New DevExpress.XtraEditors.SimpleButton()
        Me.DEAge = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.XTCCustomView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCCustomView.SuspendLayout()
        Me.XtpContract.SuspendLayout()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPAge.SuspendLayout()
        CType(Me.DEAge.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEAge.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCCustomView
        '
        Me.XTCCustomView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCCustomView.Location = New System.Drawing.Point(0, 0)
        Me.XTCCustomView.Name = "XTCCustomView"
        Me.XTCCustomView.SelectedTabPage = Me.XtpContract
        Me.XTCCustomView.Size = New System.Drawing.Size(408, 106)
        Me.XTCCustomView.TabIndex = 0
        Me.XTCCustomView.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtpContract, Me.XTPAge})
        '
        'XtpContract
        '
        Me.XtpContract.Controls.Add(Me.DEStart)
        Me.XtpContract.Controls.Add(Me.BtnView)
        Me.XtpContract.Controls.Add(Me.LabelControl3)
        Me.XtpContract.Name = "XtpContract"
        Me.XtpContract.Size = New System.Drawing.Size(402, 78)
        Me.XtpContract.Text = "Contract Review"
        '
        'DEStart
        '
        Me.DEStart.EditValue = Nothing
        Me.DEStart.Location = New System.Drawing.Point(11, 28)
        Me.DEStart.Name = "DEStart"
        Me.DEStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEStart.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStart.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEStart.Size = New System.Drawing.Size(303, 20)
        Me.DEStart.TabIndex = 8900
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(320, 28)
        Me.BtnView.LookAndFeel.SkinName = "Blue"
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(75, 20)
        Me.BtnView.TabIndex = 8899
        Me.BtnView.Text = "View"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(11, 9)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl3.TabIndex = 8897
        Me.LabelControl3.Text = "Date"
        '
        'XTPAge
        '
        Me.XTPAge.Controls.Add(Me.BtnViewAge)
        Me.XTPAge.Controls.Add(Me.DEAge)
        Me.XTPAge.Controls.Add(Me.LabelControl1)
        Me.XTPAge.Name = "XTPAge"
        Me.XTPAge.Size = New System.Drawing.Size(402, 78)
        Me.XTPAge.Text = "Age Review"
        '
        'BtnViewAge
        '
        Me.BtnViewAge.Location = New System.Drawing.Point(320, 28)
        Me.BtnViewAge.LookAndFeel.SkinName = "Blue"
        Me.BtnViewAge.Name = "BtnViewAge"
        Me.BtnViewAge.Size = New System.Drawing.Size(75, 20)
        Me.BtnViewAge.TabIndex = 8903
        Me.BtnViewAge.Text = "View"
        '
        'DEAge
        '
        Me.DEAge.EditValue = Nothing
        Me.DEAge.Location = New System.Drawing.Point(11, 28)
        Me.DEAge.Name = "DEAge"
        Me.DEAge.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEAge.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEAge.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEAge.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEAge.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEAge.Size = New System.Drawing.Size(303, 20)
        Me.DEAge.TabIndex = 8902
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(11, 9)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl1.TabIndex = 8901
        Me.LabelControl1.Text = "Date"
        '
        'FormMasterEmployeeCustom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 106)
        Me.Controls.Add(Me.XTCCustomView)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterEmployeeCustom"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Custom View"
        CType(Me.XTCCustomView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCCustomView.ResumeLayout(False)
        Me.XtpContract.ResumeLayout(False)
        Me.XtpContract.PerformLayout()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPAge.ResumeLayout(False)
        Me.XTPAge.PerformLayout()
        CType(Me.DEAge.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEAge.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCCustomView As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtpContract As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents XTPAge As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents BtnViewAge As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEAge As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
End Class
