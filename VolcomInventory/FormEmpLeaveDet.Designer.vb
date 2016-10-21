<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormEmpLeaveDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpLeaveDet))
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.TEEmployeeCode = New DevExpress.XtraEditors.TextEdit()
        Me.BPickEmployee = New DevExpress.XtraEditors.SimpleButton()
        Me.DEJoinDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TEDept = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TEPosition = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TEEmployeeName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.XTCDet = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPDetLeave = New DevExpress.XtraTab.XtraTabPage()
        Me.GCLeaveDet = New DevExpress.XtraGrid.GridControl()
        Me.GVLeaveDet = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BDelLeave = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BEditLeave = New DevExpress.XtraEditors.SimpleButton()
        Me.BAddLeave = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPLeaveRemaining = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.TextEdit6 = New DevExpress.XtraEditors.TextEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextEdit4 = New DevExpress.XtraEditors.TextEdit()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.SimpleButton6 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton7 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.TEEmployeeCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEJoinDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEJoinDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDept.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEEmployeeName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.XTCDet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCDet.SuspendLayout()
        Me.XTPDetLeave.SuspendLayout()
        CType(Me.GCLeaveDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVLeaveDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPLeaveRemaining.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TextEdit6.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.TEEmployeeCode)
        Me.GroupControl1.Controls.Add(Me.BPickEmployee)
        Me.GroupControl1.Controls.Add(Me.DEJoinDate)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Controls.Add(Me.TEDept)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.TEPosition)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.TEEmployeeName)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(703, 100)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Employee"
        '
        'TEEmployeeCode
        '
        Me.TEEmployeeCode.EditValue = ""
        Me.TEEmployeeCode.Location = New System.Drawing.Point(128, 14)
        Me.TEEmployeeCode.Name = "TEEmployeeCode"
        Me.TEEmployeeCode.Properties.EditValueChangedDelay = 1
        Me.TEEmployeeCode.Size = New System.Drawing.Size(150, 20)
        Me.TEEmployeeCode.TabIndex = 1
        '
        'BPickEmployee
        '
        Me.BPickEmployee.Location = New System.Drawing.Point(649, 12)
        Me.BPickEmployee.Name = "BPickEmployee"
        Me.BPickEmployee.Size = New System.Drawing.Size(29, 23)
        Me.BPickEmployee.TabIndex = 0
        Me.BPickEmployee.Text = "..."
        '
        'DEJoinDate
        '
        Me.DEJoinDate.EditValue = Nothing
        Me.DEJoinDate.Location = New System.Drawing.Point(128, 66)
        Me.DEJoinDate.Name = "DEJoinDate"
        Me.DEJoinDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEJoinDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEJoinDate.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEJoinDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEJoinDate.Properties.ReadOnly = True
        Me.DEJoinDate.Size = New System.Drawing.Size(205, 20)
        Me.DEJoinDate.TabIndex = 5
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(35, 69)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(44, 13)
        Me.LabelControl4.TabIndex = 94
        Me.LabelControl4.Text = "Join date"
        '
        'TEDept
        '
        Me.TEDept.EditValue = ""
        Me.TEDept.Location = New System.Drawing.Point(128, 40)
        Me.TEDept.Name = "TEDept"
        Me.TEDept.Properties.EditValueChangedDelay = 1
        Me.TEDept.Properties.ReadOnly = True
        Me.TEDept.Size = New System.Drawing.Size(283, 20)
        Me.TEDept.TabIndex = 3
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(34, 43)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl2.TabIndex = 92
        Me.LabelControl2.Text = "Departement"
        '
        'TEPosition
        '
        Me.TEPosition.EditValue = ""
        Me.TEPosition.Location = New System.Drawing.Point(460, 40)
        Me.TEPosition.Name = "TEPosition"
        Me.TEPosition.Properties.EditValueChangedDelay = 1
        Me.TEPosition.Properties.ReadOnly = True
        Me.TEPosition.Size = New System.Drawing.Size(218, 20)
        Me.TEPosition.TabIndex = 4
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(417, 43)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl1.TabIndex = 90
        Me.LabelControl1.Text = "Position"
        '
        'TEEmployeeName
        '
        Me.TEEmployeeName.EditValue = ""
        Me.TEEmployeeName.Location = New System.Drawing.Point(284, 14)
        Me.TEEmployeeName.Name = "TEEmployeeName"
        Me.TEEmployeeName.Properties.EditValueChangedDelay = 1
        Me.TEEmployeeName.Properties.ReadOnly = True
        Me.TEEmployeeName.Size = New System.Drawing.Size(359, 20)
        Me.TEEmployeeName.TabIndex = 2
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(35, 17)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl3.TabIndex = 88
        Me.LabelControl3.Text = "Employee"
        '
        'GroupControl2
        '
        Me.GroupControl2.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl2.Controls.Add(Me.XTCDet)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 100)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(703, 249)
        Me.GroupControl2.TabIndex = 1
        Me.GroupControl2.Text = "Leave"
        '
        'XTCDet
        '
        Me.XTCDet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCDet.Location = New System.Drawing.Point(20, 2)
        Me.XTCDet.Name = "XTCDet"
        Me.XTCDet.SelectedTabPage = Me.XTPDetLeave
        Me.XTCDet.Size = New System.Drawing.Size(681, 245)
        Me.XTCDet.TabIndex = 2
        Me.XTCDet.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPDetLeave, Me.XTPLeaveRemaining})
        '
        'XTPDetLeave
        '
        Me.XTPDetLeave.Controls.Add(Me.GCLeaveDet)
        Me.XTPDetLeave.Controls.Add(Me.PanelControl2)
        Me.XTPDetLeave.Name = "XTPDetLeave"
        Me.XTPDetLeave.Size = New System.Drawing.Size(675, 217)
        Me.XTPDetLeave.Text = "Leave propose"
        '
        'GCLeaveDet
        '
        Me.GCLeaveDet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCLeaveDet.Location = New System.Drawing.Point(0, 37)
        Me.GCLeaveDet.MainView = Me.GVLeaveDet
        Me.GCLeaveDet.Name = "GCLeaveDet"
        Me.GCLeaveDet.Size = New System.Drawing.Size(675, 180)
        Me.GCLeaveDet.TabIndex = 2
        Me.GCLeaveDet.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVLeaveDet})
        '
        'GVLeaveDet
        '
        Me.GVLeaveDet.GridControl = Me.GCLeaveDet
        Me.GVLeaveDet.Name = "GVLeaveDet"
        Me.GVLeaveDet.OptionsView.ShowGroupPanel = False
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BDelLeave)
        Me.PanelControl2.Controls.Add(Me.BEditLeave)
        Me.PanelControl2.Controls.Add(Me.BAddLeave)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(675, 37)
        Me.PanelControl2.TabIndex = 1
        '
        'BDelLeave
        '
        Me.BDelLeave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BDelLeave.ImageIndex = 1
        Me.BDelLeave.ImageList = Me.LargeImageCollection
        Me.BDelLeave.Location = New System.Drawing.Point(447, 2)
        Me.BDelLeave.Name = "BDelLeave"
        Me.BDelLeave.Size = New System.Drawing.Size(78, 33)
        Me.BDelLeave.TabIndex = 2
        Me.BDelLeave.Text = "Delete"
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "20_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "8_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "23_24x24.png")
        '
        'BEditLeave
        '
        Me.BEditLeave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BEditLeave.ImageIndex = 2
        Me.BEditLeave.ImageList = Me.LargeImageCollection
        Me.BEditLeave.Location = New System.Drawing.Point(525, 2)
        Me.BEditLeave.Name = "BEditLeave"
        Me.BEditLeave.Size = New System.Drawing.Size(73, 33)
        Me.BEditLeave.TabIndex = 1
        Me.BEditLeave.Text = "Edit"
        '
        'BAddLeave
        '
        Me.BAddLeave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAddLeave.ImageIndex = 0
        Me.BAddLeave.ImageList = Me.LargeImageCollection
        Me.BAddLeave.Location = New System.Drawing.Point(598, 2)
        Me.BAddLeave.Name = "BAddLeave"
        Me.BAddLeave.Size = New System.Drawing.Size(75, 33)
        Me.BAddLeave.TabIndex = 0
        Me.BAddLeave.Text = "Add"
        '
        'XTPLeaveRemaining
        '
        Me.XTPLeaveRemaining.Controls.Add(Me.GridControl1)
        Me.XTPLeaveRemaining.Name = "XTPLeaveRemaining"
        Me.XTPLeaveRemaining.Size = New System.Drawing.Size(675, 217)
        Me.XTPLeaveRemaining.Text = "Leave Remaining"
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(675, 217)
        Me.GridControl1.TabIndex = 3
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(174, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "hour(s) "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Total Leave : "
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.TextEdit6)
        Me.PanelControl1.Controls.Add(Me.Label5)
        Me.PanelControl1.Controls.Add(Me.Label6)
        Me.PanelControl1.Controls.Add(Me.TextEdit4)
        Me.PanelControl1.Controls.Add(Me.Label3)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 349)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(703, 51)
        Me.PanelControl1.TabIndex = 2
        '
        'TextEdit6
        '
        Me.TextEdit6.EditValue = ""
        Me.TextEdit6.Location = New System.Drawing.Point(571, 18)
        Me.TextEdit6.Name = "TextEdit6"
        Me.TextEdit6.Properties.EditValueChangedDelay = 1
        Me.TextEdit6.Size = New System.Drawing.Size(72, 20)
        Me.TextEdit6.TabIndex = 96
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(649, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 95
        Me.Label5.Text = "hour(s) "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(492, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 94
        Me.Label6.Text = "Remaining : "
        '
        'TextEdit4
        '
        Me.TextEdit4.EditValue = ""
        Me.TextEdit4.Location = New System.Drawing.Point(96, 18)
        Me.TextEdit4.Name = "TextEdit4"
        Me.TextEdit4.Properties.EditValueChangedDelay = 1
        Me.TextEdit4.Size = New System.Drawing.Size(72, 20)
        Me.TextEdit4.TabIndex = 90
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.SimpleButton6)
        Me.PanelControl3.Controls.Add(Me.SimpleButton7)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 400)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(703, 37)
        Me.PanelControl3.TabIndex = 3
        '
        'SimpleButton6
        '
        Me.SimpleButton6.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton6.Location = New System.Drawing.Point(553, 2)
        Me.SimpleButton6.Name = "SimpleButton6"
        Me.SimpleButton6.Size = New System.Drawing.Size(73, 33)
        Me.SimpleButton6.TabIndex = 1
        Me.SimpleButton6.Text = "Cancel"
        '
        'SimpleButton7
        '
        Me.SimpleButton7.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton7.Location = New System.Drawing.Point(626, 2)
        Me.SimpleButton7.Name = "SimpleButton7"
        Me.SimpleButton7.Size = New System.Drawing.Size(75, 33)
        Me.SimpleButton7.TabIndex = 0
        Me.SimpleButton7.Text = "Save"
        '
        'FormEmpLeaveDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 437)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.GroupControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "FormEmpLeaveDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Request to leave"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.TEEmployeeCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEJoinDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEJoinDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDept.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEEmployeeName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.XTCDet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCDet.ResumeLayout(False)
        Me.XTPDetLeave.ResumeLayout(False)
        CType(Me.GCLeaveDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVLeaveDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPLeaveRemaining.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.TextEdit6.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEDept As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEPosition As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEEmployeeName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEJoinDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TEEmployeeCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BPickEmployee As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XTCDet As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPDetLeave As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCLeaveDet As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVLeaveDet As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents BDelLeave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BEditLeave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BAddLeave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XTPLeaveRemaining As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SimpleButton6 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton7 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextEdit6 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TextEdit4 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
