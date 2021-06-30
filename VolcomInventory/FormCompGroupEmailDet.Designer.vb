<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCompGroupEmailDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCompGroupEmailDet))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TECompGroup = New DevExpress.XtraEditors.TextEdit()
        Me.TEName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TEEmail = New DevExpress.XtraEditors.TextEdit()
        Me.SLEToCC = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.PCEmployee = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEEmp = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.PCComp = New DevExpress.XtraEditors.PanelControl()
        Me.TEStore = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.TECompGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEEmail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEToCC.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PCEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCEmployee.SuspendLayout()
        CType(Me.SLEEmp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.PCComp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCComp.SuspendLayout()
        CType(Me.TEStore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(20, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Group Store"
        '
        'TECompGroup
        '
        Me.TECompGroup.Location = New System.Drawing.Point(119, 12)
        Me.TECompGroup.Name = "TECompGroup"
        Me.TECompGroup.Properties.ReadOnly = True
        Me.TECompGroup.Size = New System.Drawing.Size(292, 20)
        Me.TECompGroup.TabIndex = 1
        '
        'TEName
        '
        Me.TEName.Location = New System.Drawing.Point(119, 10)
        Me.TEName.Name = "TEName"
        Me.TEName.Size = New System.Drawing.Size(292, 20)
        Me.TEName.TabIndex = 2
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(20, 13)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(74, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Recipient Name"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(20, 39)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(71, 13)
        Me.LabelControl3.TabIndex = 4
        Me.LabelControl3.Text = "Recipient Email"
        '
        'TEEmail
        '
        Me.TEEmail.Location = New System.Drawing.Point(119, 36)
        Me.TEEmail.Name = "TEEmail"
        Me.TEEmail.Size = New System.Drawing.Size(292, 20)
        Me.TEEmail.TabIndex = 5
        '
        'SLEToCC
        '
        Me.SLEToCC.Location = New System.Drawing.Point(119, 62)
        Me.SLEToCC.Name = "SLEToCC"
        Me.SLEToCC.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEToCC.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEToCC.Size = New System.Drawing.Size(229, 20)
        Me.SLEToCC.TabIndex = 6
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "is_to"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Description"
        Me.GridColumn2.FieldName = "desc"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(20, 65)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl4.TabIndex = 7
        Me.LabelControl4.Text = "To / CC"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BCancel)
        Me.PanelControl1.Controls.Add(Me.BSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 230)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(430, 44)
        Me.PanelControl1.TabIndex = 8
        '
        'BCancel
        '
        Me.BCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCancel.Image = CType(resources.GetObject("BCancel.Image"), System.Drawing.Image)
        Me.BCancel.Location = New System.Drawing.Point(236, 2)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(93, 40)
        Me.BCancel.TabIndex = 3
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.Image = CType(resources.GetObject("BSave.Image"), System.Drawing.Image)
        Me.BSave.Location = New System.Drawing.Point(329, 2)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(99, 40)
        Me.BSave.TabIndex = 2
        Me.BSave.Text = "Save"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.TECompGroup)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(430, 44)
        Me.PanelControl2.TabIndex = 9
        '
        'PCEmployee
        '
        Me.PCEmployee.Controls.Add(Me.LabelControl5)
        Me.PCEmployee.Controls.Add(Me.SLEEmp)
        Me.PCEmployee.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCEmployee.Location = New System.Drawing.Point(0, 88)
        Me.PCEmployee.Name = "PCEmployee"
        Me.PCEmployee.Size = New System.Drawing.Size(430, 44)
        Me.PCEmployee.TabIndex = 10
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(20, 15)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl5.TabIndex = 4
        Me.LabelControl5.Text = "Employee"
        '
        'SLEEmp
        '
        Me.SLEEmp.Location = New System.Drawing.Point(119, 12)
        Me.SLEEmp.Name = "SLEEmp"
        Me.SLEEmp.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEEmp.Properties.View = Me.GridView1
        Me.SLEEmp.Size = New System.Drawing.Size(292, 20)
        Me.SLEEmp.TabIndex = 0
        '
        'GridView1
        '
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.TEName)
        Me.PanelControl4.Controls.Add(Me.LabelControl2)
        Me.PanelControl4.Controls.Add(Me.LabelControl3)
        Me.PanelControl4.Controls.Add(Me.TEEmail)
        Me.PanelControl4.Controls.Add(Me.LabelControl4)
        Me.PanelControl4.Controls.Add(Me.SLEToCC)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl4.Location = New System.Drawing.Point(0, 132)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(430, 98)
        Me.PanelControl4.TabIndex = 11
        '
        'PCComp
        '
        Me.PCComp.Controls.Add(Me.TEStore)
        Me.PCComp.Controls.Add(Me.LabelControl6)
        Me.PCComp.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCComp.Location = New System.Drawing.Point(0, 44)
        Me.PCComp.Name = "PCComp"
        Me.PCComp.Size = New System.Drawing.Size(430, 44)
        Me.PCComp.TabIndex = 12
        Me.PCComp.Visible = False
        '
        'TEStore
        '
        Me.TEStore.Location = New System.Drawing.Point(119, 12)
        Me.TEStore.Name = "TEStore"
        Me.TEStore.Properties.ReadOnly = True
        Me.TEStore.Size = New System.Drawing.Size(292, 20)
        Me.TEStore.TabIndex = 1
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(20, 15)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl6.TabIndex = 0
        Me.LabelControl6.Text = "Store"
        '
        'FormCompGroupEmailDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 274)
        Me.Controls.Add(Me.PanelControl4)
        Me.Controls.Add(Me.PCEmployee)
        Me.Controls.Add(Me.PCComp)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCompGroupEmailDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Email setup"
        CType(Me.TECompGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEEmail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEToCC.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.PCEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCEmployee.ResumeLayout(False)
        Me.PCEmployee.PerformLayout()
        CType(Me.SLEEmp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        Me.PanelControl4.PerformLayout()
        CType(Me.PCComp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCComp.ResumeLayout(False)
        Me.PCComp.PerformLayout()
        CType(Me.TEStore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TECompGroup As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEEmail As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SLEToCC As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PCEmployee As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEEmp As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PCComp As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TEStore As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
End Class
