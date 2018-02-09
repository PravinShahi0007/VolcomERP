<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpPayrollAdjustmentDet
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpPayrollAdjustmentDet))
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.TEDeduction = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LEDeductionType = New DevExpress.XtraEditors.LookUpEdit()
        Me.BPickEmployee = New DevExpress.XtraEditors.SimpleButton()
        Me.TEEmployeeCode = New DevExpress.XtraEditors.TextEdit()
        Me.TEEmployeeName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl16 = New DevExpress.XtraEditors.LabelControl()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.TextEdit2 = New DevExpress.XtraEditors.TextEdit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDeduction.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEDeductionType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEEmployeeCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEEmployeeName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "20_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "8_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "23_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(3, "arrow_refresh.png")
        Me.LargeImageCollection.Images.SetKeyName(4, "check_mark.png")
        Me.LargeImageCollection.Images.SetKeyName(5, "gnome_application_exit (1).png")
        Me.LargeImageCollection.Images.SetKeyName(6, "printer_3.png")
        Me.LargeImageCollection.Images.SetKeyName(7, "save.png")
        Me.LargeImageCollection.Images.SetKeyName(8, "31_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(9, "18_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(10, "1415351112474759854-32.png")
        Me.LargeImageCollection.Images.SetKeyName(11, "icon_merchandise_clothes32.png")
        Me.LargeImageCollection.Images.SetKeyName(12, "t_shirtgreen.png")
        Me.LargeImageCollection.Images.SetKeyName(13, "lock red.png")
        Me.LargeImageCollection.Images.SetKeyName(14, "ordering32.png")
        Me.LargeImageCollection.Images.SetKeyName(15, "kghostview.png")
        Me.LargeImageCollection.Images.SetKeyName(16, "MetroUI-Folder-OS-Configure-icon.png")
        Me.LargeImageCollection.Images.SetKeyName(17, "Setting(32).png")
        Me.LargeImageCollection.Images.SetKeyName(18, "estimate_icon32.png")
        Me.LargeImageCollection.Images.SetKeyName(19, "copy_icon.png")
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.BCancel)
        Me.PanelControl3.Controls.Add(Me.BSave)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 202)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(543, 37)
        Me.PanelControl3.TabIndex = 149
        '
        'BCancel
        '
        Me.BCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCancel.ImageIndex = 5
        Me.BCancel.ImageList = Me.LargeImageCollection
        Me.BCancel.Location = New System.Drawing.Point(393, 2)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(73, 33)
        Me.BCancel.TabIndex = 6
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.ImageIndex = 7
        Me.BSave.ImageList = Me.LargeImageCollection
        Me.BSave.Location = New System.Drawing.Point(466, 2)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(75, 33)
        Me.BSave.TabIndex = 5
        Me.BSave.Text = "Save"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 141)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl3.TabIndex = 160
        Me.LabelControl3.Text = "Note"
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(113, 139)
        Me.MENote.Name = "MENote"
        Me.MENote.Properties.MaxLength = 200
        Me.MENote.Size = New System.Drawing.Size(418, 46)
        Me.MENote.TabIndex = 154
        '
        'TEDeduction
        '
        Me.TEDeduction.EditValue = "1.00"
        Me.TEDeduction.Location = New System.Drawing.Point(112, 113)
        Me.TEDeduction.Name = "TEDeduction"
        Me.TEDeduction.Properties.Appearance.Options.UseTextOptions = True
        Me.TEDeduction.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEDeduction.Properties.EditValueChangedDelay = 1
        Me.TEDeduction.Properties.Mask.EditMask = "N0"
        Me.TEDeduction.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEDeduction.Properties.Mask.SaveLiteral = False
        Me.TEDeduction.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEDeduction.Size = New System.Drawing.Size(207, 20)
        Me.TEDeduction.TabIndex = 153
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 116)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl2.TabIndex = 159
        Me.LabelControl2.Text = "Value"
        '
        'LEDeductionType
        '
        Me.LEDeductionType.Location = New System.Drawing.Point(112, 87)
        Me.LEDeductionType.Name = "LEDeductionType"
        Me.LEDeductionType.Properties.Appearance.Options.UseTextOptions = True
        Me.LEDeductionType.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEDeductionType.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LEDeductionType.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.LEDeductionType.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.LEDeductionType.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.LEDeductionType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEDeductionType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_salary_deduction", "ID Deduction", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("description", "Deduction")})
        Me.LEDeductionType.Properties.NullText = ""
        Me.LEDeductionType.Properties.ShowFooter = False
        Me.LEDeductionType.Size = New System.Drawing.Size(245, 20)
        Me.LEDeductionType.TabIndex = 152
        '
        'BPickEmployee
        '
        Me.BPickEmployee.Location = New System.Drawing.Point(505, 7)
        Me.BPickEmployee.Name = "BPickEmployee"
        Me.BPickEmployee.Size = New System.Drawing.Size(29, 23)
        Me.BPickEmployee.TabIndex = 158
        Me.BPickEmployee.TabStop = False
        Me.BPickEmployee.Text = "..."
        '
        'TEEmployeeCode
        '
        Me.TEEmployeeCode.EditValue = ""
        Me.TEEmployeeCode.Location = New System.Drawing.Point(112, 9)
        Me.TEEmployeeCode.Name = "TEEmployeeCode"
        Me.TEEmployeeCode.Properties.EditValueChangedDelay = 1
        Me.TEEmployeeCode.Size = New System.Drawing.Size(119, 20)
        Me.TEEmployeeCode.TabIndex = 151
        '
        'TEEmployeeName
        '
        Me.TEEmployeeName.EditValue = ""
        Me.TEEmployeeName.Location = New System.Drawing.Point(237, 9)
        Me.TEEmployeeName.Name = "TEEmployeeName"
        Me.TEEmployeeName.Properties.EditValueChangedDelay = 1
        Me.TEEmployeeName.Properties.ReadOnly = True
        Me.TEEmployeeName.Size = New System.Drawing.Size(262, 20)
        Me.TEEmployeeName.TabIndex = 157
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 90)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(75, 13)
        Me.LabelControl1.TabIndex = 156
        Me.LabelControl1.Text = "Deduction Type"
        '
        'LabelControl16
        '
        Me.LabelControl16.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl16.TabIndex = 155
        Me.LabelControl16.Text = "Employee"
        '
        'TextEdit1
        '
        Me.TextEdit1.EditValue = "1.00"
        Me.TextEdit1.Location = New System.Drawing.Point(112, 35)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Properties.Appearance.Options.UseTextOptions = True
        Me.TextEdit1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TextEdit1.Properties.EditValueChangedDelay = 1
        Me.TextEdit1.Properties.Mask.EditMask = "N0"
        Me.TextEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TextEdit1.Properties.Mask.SaveLiteral = False
        Me.TextEdit1.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TextEdit1.Size = New System.Drawing.Size(207, 20)
        Me.TextEdit1.TabIndex = 161
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(12, 38)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl4.TabIndex = 162
        Me.LabelControl4.Text = "Total THP"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(12, 64)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl5.TabIndex = 163
        Me.LabelControl5.Text = "Total days"
        '
        'TextEdit2
        '
        Me.TextEdit2.EditValue = "1.00"
        Me.TextEdit2.Location = New System.Drawing.Point(112, 61)
        Me.TextEdit2.Name = "TextEdit2"
        Me.TextEdit2.Properties.Appearance.Options.UseTextOptions = True
        Me.TextEdit2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TextEdit2.Properties.EditValueChangedDelay = 1
        Me.TextEdit2.Properties.Mask.EditMask = "N0"
        Me.TextEdit2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TextEdit2.Properties.Mask.SaveLiteral = False
        Me.TextEdit2.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TextEdit2.Size = New System.Drawing.Size(207, 20)
        Me.TextEdit2.TabIndex = 164
        '
        'FormEmpPayrollAdjustmentDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(543, 239)
        Me.Controls.Add(Me.TextEdit2)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.TextEdit1)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.MENote)
        Me.Controls.Add(Me.TEDeduction)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LEDeductionType)
        Me.Controls.Add(Me.BPickEmployee)
        Me.Controls.Add(Me.TEEmployeeCode)
        Me.Controls.Add(Me.TEEmployeeName)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LabelControl16)
        Me.Controls.Add(Me.PanelControl3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpPayrollAdjustmentDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detail Bonus / Adjustment"
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDeduction.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEDeductionType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEEmployeeCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEEmployeeName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents TEDeduction As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEDeductionType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents BPickEmployee As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEEmployeeCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEEmployeeName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl16 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEdit2 As DevExpress.XtraEditors.TextEdit
End Class
