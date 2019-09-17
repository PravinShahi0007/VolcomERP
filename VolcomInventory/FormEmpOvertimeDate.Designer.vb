<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormEmpOvertimeDate
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpOvertimeDate))
        Me.TEOvertimeEnd = New DevExpress.XtraEditors.DateEdit()
        Me.TEOvertimeStart = New DevExpress.XtraEditors.DateEdit()
        Me.TEOvertimeBreak = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.TETotalHours = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.DEOvertimeDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SBClose = New DevExpress.XtraEditors.SimpleButton()
        Me.SBAdd = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.TEOvertimeEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEOvertimeEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEOvertimeStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEOvertimeStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEOvertimeBreak.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TETotalHours.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEOvertimeDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEOvertimeDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TEOvertimeEnd
        '
        Me.TEOvertimeEnd.EditValue = Nothing
        Me.TEOvertimeEnd.Location = New System.Drawing.Point(272, 38)
        Me.TEOvertimeEnd.Name = "TEOvertimeEnd"
        Me.TEOvertimeEnd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.TEOvertimeEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TEOvertimeEnd.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TEOvertimeEnd.Properties.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.TEOvertimeEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TEOvertimeEnd.Properties.EditFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.TEOvertimeEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TEOvertimeEnd.Properties.Mask.EditMask = "dd MMMM yyyy HH:mm:ss"
        Me.TEOvertimeEnd.Size = New System.Drawing.Size(150, 20)
        Me.TEOvertimeEnd.TabIndex = 35
        '
        'TEOvertimeStart
        '
        Me.TEOvertimeStart.EditValue = Nothing
        Me.TEOvertimeStart.Location = New System.Drawing.Point(97, 38)
        Me.TEOvertimeStart.Name = "TEOvertimeStart"
        Me.TEOvertimeStart.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.TEOvertimeStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TEOvertimeStart.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TEOvertimeStart.Properties.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.TEOvertimeStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TEOvertimeStart.Properties.EditFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.TEOvertimeStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TEOvertimeStart.Properties.Mask.EditMask = "dd MMMM yyyy HH:mm:ss"
        Me.TEOvertimeStart.Size = New System.Drawing.Size(150, 20)
        Me.TEOvertimeStart.TabIndex = 34
        '
        'TEOvertimeBreak
        '
        Me.TEOvertimeBreak.EditValue = New Decimal(New Integer() {0, 0, 0, 65536})
        Me.TEOvertimeBreak.Location = New System.Drawing.Point(97, 64)
        Me.TEOvertimeBreak.Name = "TEOvertimeBreak"
        Me.TEOvertimeBreak.Properties.DisplayFormat.FormatString = "N1"
        Me.TEOvertimeBreak.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TEOvertimeBreak.Properties.EditFormat.FormatString = "N1"
        Me.TEOvertimeBreak.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TEOvertimeBreak.Properties.Mask.EditMask = "N1"
        Me.TEOvertimeBreak.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEOvertimeBreak.Size = New System.Drawing.Size(100, 20)
        Me.TEOvertimeBreak.TabIndex = 33
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(207, 67)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(109, 13)
        Me.LabelControl12.TabIndex = 32
        Me.LabelControl12.Text = "Total Overtime (hours)"
        '
        'LabelControl11
        '
        Me.LabelControl11.Location = New System.Drawing.Point(11, 67)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl11.TabIndex = 31
        Me.LabelControl11.Text = "Break (hours)"
        '
        'TETotalHours
        '
        Me.TETotalHours.EditValue = ""
        Me.TETotalHours.Location = New System.Drawing.Point(322, 64)
        Me.TETotalHours.Name = "TETotalHours"
        Me.TETotalHours.Properties.DisplayFormat.FormatString = "N1"
        Me.TETotalHours.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TETotalHours.Properties.EditFormat.FormatString = "N1"
        Me.TETotalHours.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TETotalHours.Properties.ReadOnly = True
        Me.TETotalHours.Size = New System.Drawing.Size(100, 20)
        Me.TETotalHours.TabIndex = 30
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(257, 40)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(4, 13)
        Me.LabelControl9.TabIndex = 29
        Me.LabelControl9.Text = "-"
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(11, 41)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl8.TabIndex = 28
        Me.LabelControl8.Text = "Time"
        '
        'DEOvertimeDate
        '
        Me.DEOvertimeDate.EditValue = Nothing
        Me.DEOvertimeDate.Location = New System.Drawing.Point(97, 12)
        Me.DEOvertimeDate.Name = "DEOvertimeDate"
        Me.DEOvertimeDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEOvertimeDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEOvertimeDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEOvertimeDate.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEOvertimeDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEOvertimeDate.Properties.EditFormat.FormatString = "dd MMMM yyyy"
        Me.DEOvertimeDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEOvertimeDate.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DEOvertimeDate.Size = New System.Drawing.Size(325, 20)
        Me.DEOvertimeDate.TabIndex = 27
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(11, 15)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(70, 13)
        Me.LabelControl2.TabIndex = 26
        Me.LabelControl2.Text = "Overtime Date"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SBClose)
        Me.PanelControl1.Controls.Add(Me.SBAdd)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 95)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(434, 42)
        Me.PanelControl1.TabIndex = 36
        '
        'SBClose
        '
        Me.SBClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SBClose.Image = CType(resources.GetObject("SBClose.Image"), System.Drawing.Image)
        Me.SBClose.Location = New System.Drawing.Point(262, 6)
        Me.SBClose.Name = "SBClose"
        Me.SBClose.Size = New System.Drawing.Size(78, 29)
        Me.SBClose.TabIndex = 1
        Me.SBClose.Text = "Close"
        '
        'SBAdd
        '
        Me.SBAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SBAdd.Image = CType(resources.GetObject("SBAdd.Image"), System.Drawing.Image)
        Me.SBAdd.Location = New System.Drawing.Point(344, 6)
        Me.SBAdd.Name = "SBAdd"
        Me.SBAdd.Size = New System.Drawing.Size(78, 29)
        Me.SBAdd.TabIndex = 0
        Me.SBAdd.Text = "Add"
        '
        'FormEmpOvertimeDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 137)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.TEOvertimeEnd)
        Me.Controls.Add(Me.TEOvertimeStart)
        Me.Controls.Add(Me.TEOvertimeBreak)
        Me.Controls.Add(Me.LabelControl12)
        Me.Controls.Add(Me.LabelControl11)
        Me.Controls.Add(Me.TETotalHours)
        Me.Controls.Add(Me.LabelControl9)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.DEOvertimeDate)
        Me.Controls.Add(Me.LabelControl2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpOvertimeDate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Overtime Pick"
        CType(Me.TEOvertimeEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEOvertimeEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEOvertimeStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEOvertimeStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEOvertimeBreak.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TETotalHours.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEOvertimeDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEOvertimeDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TEOvertimeEnd As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TEOvertimeStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TEOvertimeBreak As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TETotalHours As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEOvertimeDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBAdd As DevExpress.XtraEditors.SimpleButton
End Class
