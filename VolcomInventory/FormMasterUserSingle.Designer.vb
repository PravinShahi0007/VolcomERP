<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMasterUserSingle
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterUserSingle))
        Me.EPUser = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TERepeatPassword = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.TEPassword = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TEUsername = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LERole = New DevExpress.XtraEditors.LookUpEdit()
        Me.SLEEmployee = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SLEEmployeeView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdEmployee = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEmployeeCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEmployeeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDepartement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSex = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PictureEditIcon = New DevExpress.XtraEditors.PictureEdit()
        Me.BtnReset = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.EPUser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TERepeatPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEUsername.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LERole.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEEmployee.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEEmployeeView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureEditIcon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EPUser
        '
        Me.EPUser.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EPUser.ContainerControl = Me
        '
        'TERepeatPassword
        '
        Me.TERepeatPassword.Location = New System.Drawing.Point(144, 165)
        Me.TERepeatPassword.Name = "TERepeatPassword"
        Me.TERepeatPassword.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TERepeatPassword.Properties.Appearance.Options.UseFont = True
        Me.TERepeatPassword.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TERepeatPassword.Size = New System.Drawing.Size(273, 22)
        Me.TERepeatPassword.TabIndex = 3
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(147, 148)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(94, 15)
        Me.LabelControl4.TabIndex = 38
        Me.LabelControl4.Text = "Repeat Password"
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Location = New System.Drawing.Point(187, 249)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(72, 23)
        Me.BCancel.TabIndex = 7
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Location = New System.Drawing.Point(347, 249)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(70, 23)
        Me.BSave.TabIndex = 5
        Me.BSave.Text = "Save"
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Location = New System.Drawing.Point(148, 192)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(24, 15)
        Me.LabelControl8.TabIndex = 37
        Me.LabelControl8.Text = "Role"
        '
        'TEPassword
        '
        Me.TEPassword.Location = New System.Drawing.Point(144, 120)
        Me.TEPassword.Name = "TEPassword"
        Me.TEPassword.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEPassword.Properties.Appearance.Options.UseFont = True
        Me.TEPassword.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TEPassword.Size = New System.Drawing.Size(273, 22)
        Me.TEPassword.TabIndex = 2
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(147, 103)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(54, 15)
        Me.LabelControl3.TabIndex = 35
        Me.LabelControl3.Text = "Password"
        '
        'TEUsername
        '
        Me.TEUsername.Location = New System.Drawing.Point(144, 74)
        Me.TEUsername.Name = "TEUsername"
        Me.TEUsername.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEUsername.Properties.Appearance.Options.UseFont = True
        Me.TEUsername.Size = New System.Drawing.Size(273, 22)
        Me.TEUsername.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(147, 56)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(55, 15)
        Me.LabelControl2.TabIndex = 33
        Me.LabelControl2.Text = "Username"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(144, 11)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(52, 15)
        Me.LabelControl1.TabIndex = 29
        Me.LabelControl1.Text = "Employee"
        '
        'LERole
        '
        Me.LERole.Location = New System.Drawing.Point(145, 210)
        Me.LERole.Name = "LERole"
        Me.LERole.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LERole.Properties.Appearance.Options.UseFont = True
        Me.LERole.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LERole.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("role", "Role"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_role", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.LERole.Properties.NullText = ""
        Me.LERole.Size = New System.Drawing.Size(272, 22)
        Me.LERole.TabIndex = 4
        '
        'SLEEmployee
        '
        Me.SLEEmployee.EditValue = "a"
        Me.SLEEmployee.Location = New System.Drawing.Point(144, 32)
        Me.SLEEmployee.Name = "SLEEmployee"
        Me.SLEEmployee.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLEEmployee.Properties.Appearance.Options.UseFont = True
        Me.SLEEmployee.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEEmployee.Properties.NullText = ""
        Me.SLEEmployee.Properties.View = Me.SLEEmployeeView
        Me.SLEEmployee.Size = New System.Drawing.Size(273, 22)
        Me.SLEEmployee.TabIndex = 0
        '
        'SLEEmployeeView
        '
        Me.SLEEmployeeView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdEmployee, Me.GridColumnEmployeeCode, Me.GridColumnEmployeeName, Me.GridColumnDepartement, Me.GridColumnSex})
        Me.SLEEmployeeView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SLEEmployeeView.Name = "SLEEmployeeView"
        Me.SLEEmployeeView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SLEEmployeeView.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdEmployee
        '
        Me.GridColumnIdEmployee.Caption = "Id Employee"
        Me.GridColumnIdEmployee.FieldName = "id_employee"
        Me.GridColumnIdEmployee.Name = "GridColumnIdEmployee"
        '
        'GridColumnEmployeeCode
        '
        Me.GridColumnEmployeeCode.Caption = "Employee Code"
        Me.GridColumnEmployeeCode.FieldName = "employee_code"
        Me.GridColumnEmployeeCode.Name = "GridColumnEmployeeCode"
        Me.GridColumnEmployeeCode.Visible = True
        Me.GridColumnEmployeeCode.VisibleIndex = 0
        '
        'GridColumnEmployeeName
        '
        Me.GridColumnEmployeeName.Caption = "Name"
        Me.GridColumnEmployeeName.FieldName = "employee_name"
        Me.GridColumnEmployeeName.Name = "GridColumnEmployeeName"
        Me.GridColumnEmployeeName.Visible = True
        Me.GridColumnEmployeeName.VisibleIndex = 1
        '
        'GridColumnDepartement
        '
        Me.GridColumnDepartement.Caption = "Departement"
        Me.GridColumnDepartement.FieldName = "departement"
        Me.GridColumnDepartement.Name = "GridColumnDepartement"
        Me.GridColumnDepartement.Visible = True
        Me.GridColumnDepartement.VisibleIndex = 2
        '
        'GridColumnSex
        '
        Me.GridColumnSex.Caption = "Sex"
        Me.GridColumnSex.FieldName = "sex"
        Me.GridColumnSex.Name = "GridColumnSex"
        Me.GridColumnSex.Visible = True
        Me.GridColumnSex.VisibleIndex = 3
        '
        'PictureEditIcon
        '
        Me.PictureEditIcon.EditValue = CType(resources.GetObject("PictureEditIcon.EditValue"), Object)
        Me.PictureEditIcon.Location = New System.Drawing.Point(12, 120)
        Me.PictureEditIcon.Name = "PictureEditIcon"
        Me.PictureEditIcon.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureEditIcon.Properties.Appearance.Options.UseBackColor = True
        Me.PictureEditIcon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEditIcon.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PictureEditIcon.Size = New System.Drawing.Size(122, 113)
        Me.PictureEditIcon.TabIndex = 36
        '
        'BtnReset
        '
        Me.BtnReset.Location = New System.Drawing.Point(265, 249)
        Me.BtnReset.Name = "BtnReset"
        Me.BtnReset.Size = New System.Drawing.Size(76, 23)
        Me.BtnReset.TabIndex = 6
        Me.BtnReset.Text = "Reset"
        '
        'FormMasterUserSingle
        '
        Me.AcceptButton = Me.BSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BCancel
        Me.ClientSize = New System.Drawing.Size(449, 291)
        Me.Controls.Add(Me.BtnReset)
        Me.Controls.Add(Me.SLEEmployee)
        Me.Controls.Add(Me.TERepeatPassword)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.BCancel)
        Me.Controls.Add(Me.BSave)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.PictureEditIcon)
        Me.Controls.Add(Me.TEPassword)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.TEUsername)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LERole)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterUserSingle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User"
        CType(Me.EPUser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TERepeatPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEUsername.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LERole.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEEmployee.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEEmployeeView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureEditIcon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EPUser As System.Windows.Forms.ErrorProvider
    Friend WithEvents TERepeatPassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEPassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEUsername As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LERole As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents SLEEmployee As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents PictureEditIcon As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents SLEEmployeeView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdEmployee As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEmployeeCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEmployeeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSex As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnReset As DevExpress.XtraEditors.SimpleButton
End Class
