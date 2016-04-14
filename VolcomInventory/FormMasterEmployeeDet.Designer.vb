<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterEmployeeDet
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
        Me.components = New System.ComponentModel.Container
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.TxtCode = New DevExpress.XtraEditors.TextEdit
        Me.TxtName = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.LEDept = New DevExpress.XtraEditors.LookUpEdit
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl
        Me.LESex = New DevExpress.XtraEditors.LookUpEdit
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TxtCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEDept.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LESex.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Controls.Add(Me.BtnSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 139)
        Me.PanelControl1.LookAndFeel.SkinName = "Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(368, 35)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.Location = New System.Drawing.Point(216, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 31)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.Location = New System.Drawing.Point(291, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 31)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "Save"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(25, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Code"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 38)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(27, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Name"
        '
        'TxtCode
        '
        Me.TxtCode.Location = New System.Drawing.Point(96, 9)
        Me.TxtCode.Name = "TxtCode"
        Me.TxtCode.Size = New System.Drawing.Size(251, 20)
        Me.TxtCode.TabIndex = 3
        '
        'TxtName
        '
        Me.TxtName.Location = New System.Drawing.Point(96, 35)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(251, 20)
        Me.TxtName.TabIndex = 4
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 64)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl3.TabIndex = 5
        Me.LabelControl3.Text = "Departement"
        '
        'LEDept
        '
        Me.LEDept.Location = New System.Drawing.Point(96, 61)
        Me.LEDept.Name = "LEDept"
        Me.LEDept.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEDept.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_departement", "Id Departement", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("departement", "Departemen")})
        Me.LEDept.Size = New System.Drawing.Size(251, 20)
        Me.LEDept.TabIndex = 6
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(12, 90)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(18, 13)
        Me.LabelControl4.TabIndex = 7
        Me.LabelControl4.Text = "Sex"
        '
        'LESex
        '
        Me.LESex.Location = New System.Drawing.Point(96, 87)
        Me.LESex.Name = "LESex"
        Me.LESex.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LESex.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_sex", "Id Sex", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("sex", "Sex")})
        Me.LESex.Size = New System.Drawing.Size(251, 20)
        Me.LESex.TabIndex = 8
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'FormMasterEmployeeDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(368, 174)
        Me.Controls.Add(Me.LESex)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LEDept)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.TxtCode)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterEmployeeDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Employee"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.TxtCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEDept.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LESex.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEDept As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LESex As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
End Class
