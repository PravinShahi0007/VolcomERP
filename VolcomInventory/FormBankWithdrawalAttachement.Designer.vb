<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBankWithdrawalAttachement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBankWithdrawalAttachement))
        Me.SimpleButtonAttachment = New DevExpress.XtraEditors.SimpleButton()
        Me.DateEditDueDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButtonSet = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TextEditVendor = New DevExpress.XtraEditors.TextEdit()
        Me.TextEditPONumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        CType(Me.DateEditDueDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditDueDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEditVendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEditPONumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SimpleButtonAttachment
        '
        Me.SimpleButtonAttachment.Location = New System.Drawing.Point(89, 85)
        Me.SimpleButtonAttachment.Name = "SimpleButtonAttachment"
        Me.SimpleButtonAttachment.Size = New System.Drawing.Size(183, 20)
        Me.SimpleButtonAttachment.TabIndex = 0
        Me.SimpleButtonAttachment.Text = "View"
        '
        'DateEditDueDate
        '
        Me.DateEditDueDate.EditValue = Nothing
        Me.DateEditDueDate.Location = New System.Drawing.Point(89, 111)
        Me.DateEditDueDate.Name = "DateEditDueDate"
        Me.DateEditDueDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DateEditDueDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditDueDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditDueDate.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DateEditDueDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEditDueDate.Properties.EditFormat.FormatString = "dd MMMM yyyy"
        Me.DateEditDueDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEditDueDate.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DateEditDueDate.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DateEditDueDate.Size = New System.Drawing.Size(183, 20)
        Me.DateEditDueDate.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(17, 114)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Due Date"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(17, 88)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Attachment"
        '
        'SimpleButtonSet
        '
        Me.SimpleButtonSet.Image = CType(resources.GetObject("SimpleButtonSet.Image"), System.Drawing.Image)
        Me.SimpleButtonSet.Location = New System.Drawing.Point(204, 142)
        Me.SimpleButtonSet.Name = "SimpleButtonSet"
        Me.SimpleButtonSet.Size = New System.Drawing.Size(68, 38)
        Me.SimpleButtonSet.TabIndex = 4
        Me.SimpleButtonSet.Text = "Set"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(17, 18)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl3.TabIndex = 6
        Me.LabelControl3.Text = "Vendor"
        '
        'TextEditVendor
        '
        Me.TextEditVendor.Location = New System.Drawing.Point(89, 15)
        Me.TextEditVendor.Name = "TextEditVendor"
        Me.TextEditVendor.Properties.ReadOnly = True
        Me.TextEditVendor.Size = New System.Drawing.Size(183, 20)
        Me.TextEditVendor.TabIndex = 7
        '
        'TextEditPONumber
        '
        Me.TextEditPONumber.Location = New System.Drawing.Point(89, 41)
        Me.TextEditPONumber.Name = "TextEditPONumber"
        Me.TextEditPONumber.Properties.ReadOnly = True
        Me.TextEditPONumber.Size = New System.Drawing.Size(183, 20)
        Me.TextEditPONumber.TabIndex = 9
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(17, 44)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl4.TabIndex = 8
        Me.LabelControl4.Text = "PO Number"
        '
        'PanelControl1
        '
        Me.PanelControl1.Location = New System.Drawing.Point(17, 72)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(255, 2)
        Me.PanelControl1.TabIndex = 10
        '
        'FormBankWithdrawalAttachement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 192)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.TextEditPONumber)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.TextEditVendor)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.SimpleButtonSet)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.DateEditDueDate)
        Me.Controls.Add(Me.SimpleButtonAttachment)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormBankWithdrawalAttachement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Attachment & Due Date"
        CType(Me.DateEditDueDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditDueDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEditVendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEditPONumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SimpleButtonAttachment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DateEditDueDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButtonSet As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEditVendor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEditPONumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
End Class
