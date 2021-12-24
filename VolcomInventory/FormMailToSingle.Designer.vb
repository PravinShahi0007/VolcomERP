<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMailToSingle
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
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.CEExternal = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEEmployee = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TxtRecipient = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtEmail = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.SLERMT = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEType = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.CEExternal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEEmployee.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtRecipient.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtEmail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLERMT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnAdd
        '
        Me.BtnAdd.Appearance.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BtnAdd.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnAdd.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnAdd.Appearance.Options.UseBackColor = True
        Me.BtnAdd.Appearance.Options.UseFont = True
        Me.BtnAdd.Appearance.Options.UseForeColor = True
        Me.BtnAdd.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnAdd.Location = New System.Drawing.Point(0, 194)
        Me.BtnAdd.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnAdd.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BtnAdd.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnAdd.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(358, 32)
        Me.BtnAdd.TabIndex = 19
        Me.BtnAdd.Text = "Add"
        '
        'BtnDelete
        '
        Me.BtnDelete.Appearance.BackColor = System.Drawing.Color.Crimson
        Me.BtnDelete.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnDelete.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnDelete.Appearance.Options.UseBackColor = True
        Me.BtnDelete.Appearance.Options.UseFont = True
        Me.BtnDelete.Appearance.Options.UseForeColor = True
        Me.BtnDelete.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnDelete.Location = New System.Drawing.Point(0, 226)
        Me.BtnDelete.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnDelete.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BtnDelete.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnDelete.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(358, 32)
        Me.BtnDelete.TabIndex = 20
        Me.BtnDelete.Text = "Discard"
        '
        'CEExternal
        '
        Me.CEExternal.Location = New System.Drawing.Point(257, 12)
        Me.CEExternal.Name = "CEExternal"
        Me.CEExternal.Properties.Caption = "External User"
        Me.CEExternal.Size = New System.Drawing.Size(87, 19)
        Me.CEExternal.TabIndex = 21
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 45)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl1.TabIndex = 22
        Me.LabelControl1.Text = "Employee"
        '
        'SLEEmployee
        '
        Me.SLEEmployee.Location = New System.Drawing.Point(75, 42)
        Me.SLEEmployee.Name = "SLEEmployee"
        Me.SLEEmployee.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEEmployee.Properties.NullText = "- Pilih Karyawan -"
        Me.SLEEmployee.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEEmployee.Size = New System.Drawing.Size(269, 20)
        Me.SLEEmployee.TabIndex = 23
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'TxtRecipient
        '
        Me.TxtRecipient.Location = New System.Drawing.Point(75, 68)
        Me.TxtRecipient.Name = "TxtRecipient"
        Me.TxtRecipient.Size = New System.Drawing.Size(269, 20)
        Me.TxtRecipient.TabIndex = 24
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 71)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(44, 13)
        Me.LabelControl2.TabIndex = 25
        Me.LabelControl2.Text = "Recipient"
        '
        'TxtEmail
        '
        Me.TxtEmail.Location = New System.Drawing.Point(75, 94)
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(269, 20)
        Me.TxtEmail.TabIndex = 26
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 97)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl3.TabIndex = 27
        Me.LabelControl3.Text = "Email"
        '
        'SLERMT
        '
        Me.SLERMT.Location = New System.Drawing.Point(75, 146)
        Me.SLERMT.Name = "SLERMT"
        Me.SLERMT.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLERMT.Properties.View = Me.GridView1
        Me.SLERMT.Size = New System.Drawing.Size(269, 20)
        Me.SLERMT.TabIndex = 28
        '
        'GridView1
        '
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(12, 123)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl4.TabIndex = 29
        Me.LabelControl4.Text = "Type"
        '
        'SLEType
        '
        Me.SLEType.Location = New System.Drawing.Point(75, 120)
        Me.SLEType.Name = "SLEType"
        Me.SLEType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEType.Properties.View = Me.GridView2
        Me.SLEType.Size = New System.Drawing.Size(269, 20)
        Me.SLEType.TabIndex = 30
        '
        'GridView2
        '
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(12, 149)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl5.TabIndex = 31
        Me.LabelControl5.Text = "Report"
        '
        'FormMailToSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(358, 258)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.SLEType)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.SLERMT)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.TxtEmail)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.TxtRecipient)
        Me.Controls.Add(Me.SLEEmployee)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.CEExternal)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.BtnDelete)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMailToSingle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Mail"
        CType(Me.CEExternal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEEmployee.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtRecipient.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtEmail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLERMT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CEExternal As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEEmployee As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TxtRecipient As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtEmail As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLERMT As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEType As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
End Class
