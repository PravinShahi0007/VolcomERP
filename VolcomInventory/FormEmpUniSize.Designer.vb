<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpUniSize
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpUniSize))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnChoose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelEmpName = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelGroupName = New DevExpress.XtraEditors.LabelControl()
        Me.LabelClass = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LabelClass)
        Me.PanelControl1.Controls.Add(Me.LabelGroupName)
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.LabelEmpName)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(619, 85)
        Me.PanelControl1.TabIndex = 0
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BtnCancel)
        Me.PanelControl2.Controls.Add(Me.BtnChoose)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 365)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(619, 42)
        Me.PanelControl2.TabIndex = 1
        '
        'BtnChoose
        '
        Me.BtnChoose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnChoose.Image = CType(resources.GetObject("BtnChoose.Image"), System.Drawing.Image)
        Me.BtnChoose.Location = New System.Drawing.Point(527, 2)
        Me.BtnChoose.Name = "BtnChoose"
        Me.BtnChoose.Size = New System.Drawing.Size(90, 38)
        Me.BtnChoose.TabIndex = 0
        Me.BtnChoose.Text = "Choose"
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(437, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(90, 38)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "Cancel"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 85)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(619, 280)
        Me.GCData.TabIndex = 2
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'LabelEmpName
        '
        Me.LabelEmpName.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelEmpName.Location = New System.Drawing.Point(12, 12)
        Me.LabelEmpName.Name = "LabelEmpName"
        Me.LabelEmpName.Size = New System.Drawing.Size(119, 18)
        Me.LabelEmpName.TabIndex = 0
        Me.LabelEmpName.Text = "Employee Name"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 37)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "Group Name"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 56)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(25, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Class"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(77, 37)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(4, 13)
        Me.LabelControl3.TabIndex = 3
        Me.LabelControl3.Text = ":"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(77, 56)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(4, 13)
        Me.LabelControl4.TabIndex = 4
        Me.LabelControl4.Text = ":"
        '
        'LabelGroupName
        '
        Me.LabelGroupName.Location = New System.Drawing.Point(87, 37)
        Me.LabelGroupName.Name = "LabelGroupName"
        Me.LabelGroupName.Size = New System.Drawing.Size(47, 13)
        Me.LabelGroupName.TabIndex = 5
        Me.LabelGroupName.Text = "[Content]"
        '
        'LabelClass
        '
        Me.LabelClass.Location = New System.Drawing.Point(87, 56)
        Me.LabelClass.Name = "LabelClass"
        Me.LabelClass.Size = New System.Drawing.Size(47, 13)
        Me.LabelClass.TabIndex = 6
        Me.LabelClass.Text = "[Content]"
        '
        'FormEmpUniSize
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 407)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormEmpUniSize"
        Me.Text = "Select Size"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnChoose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelClass As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelGroupName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelEmpName As DevExpress.XtraEditors.LabelControl
End Class
