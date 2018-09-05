<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReportMarkCancel
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
        Me.DEDateProposed = New DevExpress.XtraEditors.DateEdit()
        Me.MEReason = New DevExpress.XtraEditors.MemoEdit()
        Me.TECancelBy = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TENumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.BDetail = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BApprove = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BAttachment = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.DEDateProposed.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDateProposed.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEReason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECancelBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DEDateProposed
        '
        Me.DEDateProposed.EditValue = Nothing
        Me.DEDateProposed.Enabled = False
        Me.DEDateProposed.Location = New System.Drawing.Point(103, 64)
        Me.DEDateProposed.Name = "DEDateProposed"
        Me.DEDateProposed.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDateProposed.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDateProposed.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEDateProposed.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEDateProposed.Size = New System.Drawing.Size(312, 20)
        Me.DEDateProposed.TabIndex = 154
        '
        'MEReason
        '
        Me.MEReason.Location = New System.Drawing.Point(103, 90)
        Me.MEReason.Name = "MEReason"
        Me.MEReason.Properties.ReadOnly = True
        Me.MEReason.Size = New System.Drawing.Size(590, 308)
        Me.MEReason.TabIndex = 153
        '
        'TECancelBy
        '
        Me.TECancelBy.EditValue = "[Auto Generate]"
        Me.TECancelBy.Location = New System.Drawing.Point(103, 12)
        Me.TECancelBy.Name = "TECancelBy"
        Me.TECancelBy.Properties.ReadOnly = True
        Me.TECancelBy.Size = New System.Drawing.Size(312, 20)
        Me.TECancelBy.TabIndex = 152
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(9, 90)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(71, 13)
        Me.LabelControl2.TabIndex = 151
        Me.LabelControl2.Text = "Cancel Reason"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(9, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(47, 13)
        Me.LabelControl1.TabIndex = 150
        Me.LabelControl1.Text = "Cancel By"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(9, 67)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(71, 13)
        Me.LabelControl3.TabIndex = 155
        Me.LabelControl3.Text = "Date Proposed"
        '
        'TENumber
        '
        Me.TENumber.EditValue = "[Auto Generate]"
        Me.TENumber.Location = New System.Drawing.Point(103, 38)
        Me.TENumber.Name = "TENumber"
        Me.TENumber.Properties.ReadOnly = True
        Me.TENumber.Size = New System.Drawing.Size(238, 20)
        Me.TENumber.TabIndex = 158
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(9, 41)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl4.TabIndex = 157
        Me.LabelControl4.Text = "Number"
        '
        'BDetail
        '
        Me.BDetail.ImageIndex = 4
        Me.BDetail.Location = New System.Drawing.Point(347, 38)
        Me.BDetail.Name = "BDetail"
        Me.BDetail.Size = New System.Drawing.Size(68, 19)
        Me.BDetail.TabIndex = 16
        Me.BDetail.TabStop = False
        Me.BDetail.Text = "See Detail"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BApprove)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 443)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(717, 29)
        Me.PanelControl2.TabIndex = 161
        '
        'BApprove
        '
        Me.BApprove.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BApprove.ImageIndex = 4
        Me.BApprove.Location = New System.Drawing.Point(2, 2)
        Me.BApprove.Name = "BApprove"
        Me.BApprove.Size = New System.Drawing.Size(713, 25)
        Me.BApprove.TabIndex = 15
        Me.BApprove.TabStop = False
        Me.BApprove.Text = "Approve"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BAttachment)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 414)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(717, 29)
        Me.PanelControl1.TabIndex = 162
        '
        'BAttachment
        '
        Me.BAttachment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BAttachment.ImageIndex = 4
        Me.BAttachment.Location = New System.Drawing.Point(2, 2)
        Me.BAttachment.Name = "BAttachment"
        Me.BAttachment.Size = New System.Drawing.Size(713, 25)
        Me.BAttachment.TabIndex = 15
        Me.BAttachment.TabStop = False
        Me.BAttachment.Text = "See Attachment"
        '
        'FormReportMarkCancel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(717, 472)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.BDetail)
        Me.Controls.Add(Me.TENumber)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.DEDateProposed)
        Me.Controls.Add(Me.MEReason)
        Me.Controls.Add(Me.TECancelBy)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormReportMarkCancel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancel Form"
        CType(Me.DEDateProposed.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDateProposed.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEReason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECancelBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DEDateProposed As DevExpress.XtraEditors.DateEdit
    Friend WithEvents MEReason As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents TECancelBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TENumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BDetail As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BApprove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BAttachment As DevExpress.XtraEditors.SimpleButton
End Class
