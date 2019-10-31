<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDebitNoteDet
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
        Me.GroupGeneralHeader = New DevExpress.XtraEditors.GroupControl()
        Me.TEMemoType = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl16 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControlTopLeft = New DevExpress.XtraEditors.PanelControl()
        Me.MEAdrressCompFrom = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtNameCompFrom = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControlTopRight = New DevExpress.XtraEditors.PanelControl()
        Me.DEForm = New DevExpress.XtraEditors.TextEdit()
        Me.DEDueDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtVirtualPosNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.GroupGeneralHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneralHeader.SuspendLayout()
        CType(Me.TEMemoType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlTopLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlTopLeft.SuspendLayout()
        CType(Me.MEAdrressCompFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNameCompFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlTopRight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlTopRight.SuspendLayout()
        CType(Me.DEForm.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDueDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDueDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtVirtualPosNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupGeneralHeader
        '
        Me.GroupGeneralHeader.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupGeneralHeader.Controls.Add(Me.PanelControlTopLeft)
        Me.GroupGeneralHeader.Controls.Add(Me.PanelControlTopRight)
        Me.GroupGeneralHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupGeneralHeader.Location = New System.Drawing.Point(0, 0)
        Me.GroupGeneralHeader.Name = "GroupGeneralHeader"
        Me.GroupGeneralHeader.Size = New System.Drawing.Size(1044, 118)
        Me.GroupGeneralHeader.TabIndex = 186
        '
        'TEMemoType
        '
        Me.TEMemoType.EditValue = ""
        Me.TEMemoType.Location = New System.Drawing.Point(65, 7)
        Me.TEMemoType.Name = "TEMemoType"
        Me.TEMemoType.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEMemoType.Properties.Appearance.Options.UseFont = True
        Me.TEMemoType.Properties.EditValueChangedDelay = 1
        Me.TEMemoType.Properties.ReadOnly = True
        Me.TEMemoType.Size = New System.Drawing.Size(217, 20)
        Me.TEMemoType.TabIndex = 8941
        Me.TEMemoType.TabStop = False
        '
        'LabelControl16
        '
        Me.LabelControl16.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl16.Location = New System.Drawing.Point(7, 10)
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl16.TabIndex = 8940
        Me.LabelControl16.Text = "Type"
        '
        'PanelControlTopLeft
        '
        Me.PanelControlTopLeft.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlTopLeft.Controls.Add(Me.TEMemoType)
        Me.PanelControlTopLeft.Controls.Add(Me.LabelControl16)
        Me.PanelControlTopLeft.Controls.Add(Me.MEAdrressCompFrom)
        Me.PanelControlTopLeft.Controls.Add(Me.LabelControl1)
        Me.PanelControlTopLeft.Controls.Add(Me.TxtNameCompFrom)
        Me.PanelControlTopLeft.Controls.Add(Me.LabelControl3)
        Me.PanelControlTopLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControlTopLeft.Location = New System.Drawing.Point(20, 2)
        Me.PanelControlTopLeft.Name = "PanelControlTopLeft"
        Me.PanelControlTopLeft.Size = New System.Drawing.Size(797, 114)
        Me.PanelControlTopLeft.TabIndex = 8939
        '
        'MEAdrressCompFrom
        '
        Me.MEAdrressCompFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MEAdrressCompFrom.Location = New System.Drawing.Point(65, 59)
        Me.MEAdrressCompFrom.Name = "MEAdrressCompFrom"
        Me.MEAdrressCompFrom.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MEAdrressCompFrom.Properties.Appearance.Options.UseFont = True
        Me.MEAdrressCompFrom.Properties.ReadOnly = True
        Me.MEAdrressCompFrom.Size = New System.Drawing.Size(347, 43)
        Me.MEAdrressCompFrom.TabIndex = 4444
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(7, 35)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl1.TabIndex = 145
        Me.LabelControl1.Text = "Vendor"
        '
        'TxtNameCompFrom
        '
        Me.TxtNameCompFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNameCompFrom.EditValue = ""
        Me.TxtNameCompFrom.Location = New System.Drawing.Point(65, 33)
        Me.TxtNameCompFrom.Name = "TxtNameCompFrom"
        Me.TxtNameCompFrom.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNameCompFrom.Properties.Appearance.Options.UseFont = True
        Me.TxtNameCompFrom.Properties.EditValueChangedDelay = 1
        Me.TxtNameCompFrom.Properties.ReadOnly = True
        Me.TxtNameCompFrom.Size = New System.Drawing.Size(347, 20)
        Me.TxtNameCompFrom.TabIndex = 8888
        Me.TxtNameCompFrom.TabStop = False
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(7, 62)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl3.TabIndex = 153
        Me.LabelControl3.Text = "Address"
        '
        'PanelControlTopRight
        '
        Me.PanelControlTopRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlTopRight.Controls.Add(Me.DEForm)
        Me.PanelControlTopRight.Controls.Add(Me.DEDueDate)
        Me.PanelControlTopRight.Controls.Add(Me.LabelControl5)
        Me.PanelControlTopRight.Controls.Add(Me.TxtVirtualPosNumber)
        Me.PanelControlTopRight.Controls.Add(Me.LabelControl7)
        Me.PanelControlTopRight.Controls.Add(Me.LabelControl8)
        Me.PanelControlTopRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControlTopRight.Location = New System.Drawing.Point(817, 2)
        Me.PanelControlTopRight.Name = "PanelControlTopRight"
        Me.PanelControlTopRight.Size = New System.Drawing.Size(225, 114)
        Me.PanelControlTopRight.TabIndex = 8941
        '
        'DEForm
        '
        Me.DEForm.EditValue = ""
        Me.DEForm.Location = New System.Drawing.Point(57, 3)
        Me.DEForm.Name = "DEForm"
        Me.DEForm.Properties.EditValueChangedDelay = 1
        Me.DEForm.Properties.ReadOnly = True
        Me.DEForm.Size = New System.Drawing.Size(158, 20)
        Me.DEForm.TabIndex = 162
        '
        'DEDueDate
        '
        Me.DEDueDate.EditValue = Nothing
        Me.DEDueDate.Location = New System.Drawing.Point(57, 81)
        Me.DEDueDate.Name = "DEDueDate"
        Me.DEDueDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDueDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEDueDate.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEDueDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEDueDate.Size = New System.Drawing.Size(158, 20)
        Me.DEDueDate.TabIndex = 4
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(7, 32)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl5.TabIndex = 155
        Me.LabelControl5.Text = "Number"
        '
        'TxtVirtualPosNumber
        '
        Me.TxtVirtualPosNumber.EditValue = ""
        Me.TxtVirtualPosNumber.Location = New System.Drawing.Point(57, 29)
        Me.TxtVirtualPosNumber.Name = "TxtVirtualPosNumber"
        Me.TxtVirtualPosNumber.Properties.EditValueChangedDelay = 1
        Me.TxtVirtualPosNumber.Properties.ReadOnly = True
        Me.TxtVirtualPosNumber.Size = New System.Drawing.Size(158, 20)
        Me.TxtVirtualPosNumber.TabIndex = 8
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(7, 6)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl7.TabIndex = 159
        Me.LabelControl7.Text = "Date"
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Location = New System.Drawing.Point(7, 84)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl8.TabIndex = 8930
        Me.LabelControl8.Text = "Due Date"
        '
        'FormDebitNoteDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1044, 573)
        Me.Controls.Add(Me.GroupGeneralHeader)
        Me.Name = "FormDebitNoteDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Debit Note"
        CType(Me.GroupGeneralHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneralHeader.ResumeLayout(False)
        CType(Me.TEMemoType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlTopLeft, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlTopLeft.ResumeLayout(False)
        Me.PanelControlTopLeft.PerformLayout()
        CType(Me.MEAdrressCompFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNameCompFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlTopRight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlTopRight.ResumeLayout(False)
        Me.PanelControlTopRight.PerformLayout()
        CType(Me.DEForm.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDueDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDueDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtVirtualPosNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupGeneralHeader As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PanelControlTopLeft As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TEMemoType As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl16 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MEAdrressCompFrom As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtNameCompFrom As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControlTopRight As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DEForm As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DEDueDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtVirtualPosNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
End Class
