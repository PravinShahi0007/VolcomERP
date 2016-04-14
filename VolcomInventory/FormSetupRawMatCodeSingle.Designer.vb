<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSetupRawMatCodeSingle
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
        Me.GCtrlCodeTypeDetail = New DevExpress.XtraEditors.GroupControl
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BtnUnselectedAll = New DevExpress.XtraEditors.SimpleButton
        Me.BtnMoveDown = New DevExpress.XtraEditors.SimpleButton
        Me.BtnMoveUp = New DevExpress.XtraEditors.SimpleButton
        Me.BtnSelected = New DevExpress.XtraEditors.SimpleButton
        Me.BtnUnselected = New DevExpress.XtraEditors.SimpleButton
        Me.BtnSelectedAll = New DevExpress.XtraEditors.SimpleButton
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl
        Me.LBCCriteriaSelected = New DevExpress.XtraEditors.ListBoxControl
        Me.LBCCriteria = New DevExpress.XtraEditors.ListBoxControl
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl
        Me.GCtrlCodeType = New DevExpress.XtraEditors.GroupControl
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.LEActive = New DevExpress.XtraEditors.LookUpEdit
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.LeDefault = New DevExpress.XtraEditors.LookUpEdit
        Me.TxtRawMatCodeName = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.ErrorProviderSetup = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.GCtrlCodeTypeDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCtrlCodeTypeDetail.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LBCCriteriaSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LBCCriteria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCtrlCodeType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCtrlCodeType.SuspendLayout()
        CType(Me.LEActive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeDefault.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtRawMatCodeName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProviderSetup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCtrlCodeTypeDetail
        '
        Me.GCtrlCodeTypeDetail.Controls.Add(Me.PanelControl1)
        Me.GCtrlCodeTypeDetail.Controls.Add(Me.BtnUnselectedAll)
        Me.GCtrlCodeTypeDetail.Controls.Add(Me.BtnMoveDown)
        Me.GCtrlCodeTypeDetail.Controls.Add(Me.BtnMoveUp)
        Me.GCtrlCodeTypeDetail.Controls.Add(Me.BtnSelected)
        Me.GCtrlCodeTypeDetail.Controls.Add(Me.BtnUnselected)
        Me.GCtrlCodeTypeDetail.Controls.Add(Me.BtnSelectedAll)
        Me.GCtrlCodeTypeDetail.Controls.Add(Me.LabelControl5)
        Me.GCtrlCodeTypeDetail.Controls.Add(Me.LBCCriteriaSelected)
        Me.GCtrlCodeTypeDetail.Controls.Add(Me.LBCCriteria)
        Me.GCtrlCodeTypeDetail.Controls.Add(Me.LabelControl4)
        Me.GCtrlCodeTypeDetail.Location = New System.Drawing.Point(0, 135)
        Me.GCtrlCodeTypeDetail.Name = "GCtrlCodeTypeDetail"
        Me.GCtrlCodeTypeDetail.Size = New System.Drawing.Size(582, 428)
        Me.GCtrlCodeTypeDetail.TabIndex = 6
        Me.GCtrlCodeTypeDetail.Text = "Parameter"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnSave)
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(2, 353)
        Me.PanelControl1.LookAndFeel.SkinName = "Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(578, 73)
        Me.PanelControl1.TabIndex = 37
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(481, 22)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 38
        Me.BtnSave.Text = "Save"
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(400, 22)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 39
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnUnselectedAll
        '
        Me.BtnUnselectedAll.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.BtnUnselectedAll.Location = New System.Drawing.Point(247, 206)
        Me.BtnUnselectedAll.Name = "BtnUnselectedAll"
        Me.BtnUnselectedAll.Size = New System.Drawing.Size(75, 33)
        Me.BtnUnselectedAll.TabIndex = 36
        Me.BtnUnselectedAll.Text = "<<"
        Me.BtnUnselectedAll.ToolTip = "Unselect All"
        Me.BtnUnselectedAll.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.BtnUnselectedAll.ToolTipTitle = "Information"
        '
        'BtnMoveDown
        '
        Me.BtnMoveDown.Location = New System.Drawing.Point(455, 308)
        Me.BtnMoveDown.Name = "BtnMoveDown"
        Me.BtnMoveDown.Size = New System.Drawing.Size(94, 23)
        Me.BtnMoveDown.TabIndex = 35
        Me.BtnMoveDown.Text = "Move Down"
        '
        'BtnMoveUp
        '
        Me.BtnMoveUp.Location = New System.Drawing.Point(365, 308)
        Me.BtnMoveUp.Name = "BtnMoveUp"
        Me.BtnMoveUp.Size = New System.Drawing.Size(84, 23)
        Me.BtnMoveUp.TabIndex = 34
        Me.BtnMoveUp.Text = "Move Up"
        '
        'BtnSelected
        '
        Me.BtnSelected.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.BtnSelected.Location = New System.Drawing.Point(247, 131)
        Me.BtnSelected.Name = "BtnSelected"
        Me.BtnSelected.Size = New System.Drawing.Size(75, 30)
        Me.BtnSelected.TabIndex = 32
        Me.BtnSelected.Text = ">"
        Me.BtnSelected.ToolTip = "Select"
        Me.BtnSelected.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.BtnSelected.ToolTipTitle = "Information"
        '
        'BtnUnselected
        '
        Me.BtnUnselected.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.BtnUnselected.Location = New System.Drawing.Point(247, 167)
        Me.BtnUnselected.Name = "BtnUnselected"
        Me.BtnUnselected.Size = New System.Drawing.Size(75, 33)
        Me.BtnUnselected.TabIndex = 31
        Me.BtnUnselected.Text = "<"
        Me.BtnUnselected.ToolTip = "Unselect"
        Me.BtnUnselected.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.BtnUnselected.ToolTipTitle = "Information"
        '
        'BtnSelectedAll
        '
        Me.BtnSelectedAll.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.BtnSelectedAll.Location = New System.Drawing.Point(247, 92)
        Me.BtnSelectedAll.Name = "BtnSelectedAll"
        Me.BtnSelectedAll.Size = New System.Drawing.Size(75, 33)
        Me.BtnSelectedAll.TabIndex = 30
        Me.BtnSelectedAll.Text = ">>"
        Me.BtnSelectedAll.ToolTip = "Select All"
        Me.BtnSelectedAll.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.BtnSelectedAll.ToolTipTitle = "Information"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(355, 32)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(105, 15)
        Me.LabelControl5.TabIndex = 29
        Me.LabelControl5.Text = "Parameter Selected"
        '
        'LBCCriteriaSelected
        '
        Me.LBCCriteriaSelected.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBCCriteriaSelected.Appearance.Options.UseFont = True
        Me.LBCCriteriaSelected.Location = New System.Drawing.Point(355, 53)
        Me.LBCCriteriaSelected.Name = "LBCCriteriaSelected"
        Me.LBCCriteriaSelected.Size = New System.Drawing.Size(203, 249)
        Me.LBCCriteriaSelected.TabIndex = 28
        '
        'LBCCriteria
        '
        Me.LBCCriteria.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBCCriteria.Appearance.Options.UseFont = True
        Me.LBCCriteria.IncrementalSearch = True
        Me.LBCCriteria.Location = New System.Drawing.Point(12, 53)
        Me.LBCCriteria.Name = "LBCCriteria"
        Me.LBCCriteria.Size = New System.Drawing.Size(201, 249)
        Me.LBCCriteria.TabIndex = 27
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(12, 32)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(79, 15)
        Me.LabelControl4.TabIndex = 26
        Me.LabelControl4.Text = "Parameter List"
        '
        'GCtrlCodeType
        '
        Me.GCtrlCodeType.Controls.Add(Me.LabelControl3)
        Me.GCtrlCodeType.Controls.Add(Me.LEActive)
        Me.GCtrlCodeType.Controls.Add(Me.LabelControl2)
        Me.GCtrlCodeType.Controls.Add(Me.LeDefault)
        Me.GCtrlCodeType.Controls.Add(Me.TxtRawMatCodeName)
        Me.GCtrlCodeType.Controls.Add(Me.LabelControl1)
        Me.GCtrlCodeType.Dock = System.Windows.Forms.DockStyle.Top
        Me.GCtrlCodeType.Location = New System.Drawing.Point(0, 0)
        Me.GCtrlCodeType.Name = "GCtrlCodeType"
        Me.GCtrlCodeType.Size = New System.Drawing.Size(582, 135)
        Me.GCtrlCodeType.TabIndex = 7
        Me.GCtrlCodeType.Text = "Code Type"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(12, 91)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(52, 15)
        Me.LabelControl3.TabIndex = 11
        Me.LabelControl3.Text = "Set Active"
        '
        'LEActive
        '
        Me.LEActive.Location = New System.Drawing.Point(111, 88)
        Me.LEActive.Name = "LEActive"
        Me.LEActive.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LEActive.Properties.Appearance.Options.UseFont = True
        Me.LEActive.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEActive.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_status", "Id Active", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("status", "Status")})
        Me.LEActive.Properties.NullText = ""
        Me.LEActive.Size = New System.Drawing.Size(447, 22)
        Me.LEActive.TabIndex = 10
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(12, 64)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(59, 15)
        Me.LabelControl2.TabIndex = 9
        Me.LabelControl2.Text = "Set Default"
        '
        'LeDefault
        '
        Me.LeDefault.Location = New System.Drawing.Point(111, 61)
        Me.LeDefault.Name = "LeDefault"
        Me.LeDefault.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LeDefault.Properties.Appearance.Options.UseFont = True
        Me.LeDefault.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LeDefault.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_default", "Id  Default", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("default_name", "Default")})
        Me.LeDefault.Properties.NullText = ""
        Me.LeDefault.Size = New System.Drawing.Size(447, 22)
        Me.LeDefault.TabIndex = 8
        '
        'TxtRawMatCodeName
        '
        Me.TxtRawMatCodeName.Location = New System.Drawing.Point(111, 31)
        Me.TxtRawMatCodeName.Name = "TxtRawMatCodeName"
        Me.TxtRawMatCodeName.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRawMatCodeName.Properties.Appearance.Options.UseFont = True
        Me.TxtRawMatCodeName.Properties.MaxLength = 30
        Me.TxtRawMatCodeName.Size = New System.Drawing.Size(447, 22)
        Me.TxtRawMatCodeName.TabIndex = 7
        Me.TxtRawMatCodeName.ToolTip = "Max : 30 characters "
        Me.TxtRawMatCodeName.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.TxtRawMatCodeName.ToolTipTitle = "Information"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(12, 38)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(55, 15)
        Me.LabelControl1.TabIndex = 6
        Me.LabelControl1.Text = "Code Type"
        '
        'ErrorProviderSetup
        '
        Me.ErrorProviderSetup.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProviderSetup.ContainerControl = Me
        '
        'FormSetupRawMatCodeSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(582, 555)
        Me.Controls.Add(Me.GCtrlCodeType)
        Me.Controls.Add(Me.GCtrlCodeTypeDetail)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSetupRawMatCodeSingle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Setup Code Raw Material"
        CType(Me.GCtrlCodeTypeDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GCtrlCodeTypeDetail.ResumeLayout(False)
        Me.GCtrlCodeTypeDetail.PerformLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.LBCCriteriaSelected, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LBCCriteria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCtrlCodeType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GCtrlCodeType.ResumeLayout(False)
        Me.GCtrlCodeType.PerformLayout()
        CType(Me.LEActive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeDefault.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtRawMatCodeName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProviderSetup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCtrlCodeTypeDetail As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCtrlCodeType As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEActive As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LeDefault As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents TxtRawMatCodeName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnMoveDown As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnMoveUp As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSelected As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnUnselected As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSelectedAll As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LBCCriteriaSelected As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents LBCCriteria As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnUnselectedAll As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ErrorProviderSetup As System.Windows.Forms.ErrorProvider
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
End Class
