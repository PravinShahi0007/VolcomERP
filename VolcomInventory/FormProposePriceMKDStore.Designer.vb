<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProposePriceMKDStore
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
        Me.BCreatePO = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtType = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEStore = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.TxtNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEStore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BCreatePO
        '
        Me.BCreatePO.Appearance.BackColor = System.Drawing.Color.Teal
        Me.BCreatePO.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BCreatePO.Appearance.ForeColor = System.Drawing.Color.White
        Me.BCreatePO.Appearance.Options.UseBackColor = True
        Me.BCreatePO.Appearance.Options.UseFont = True
        Me.BCreatePO.Appearance.Options.UseForeColor = True
        Me.BCreatePO.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BCreatePO.Location = New System.Drawing.Point(0, 173)
        Me.BCreatePO.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BCreatePO.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BCreatePO.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BCreatePO.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BCreatePO.Name = "BCreatePO"
        Me.BCreatePO.Size = New System.Drawing.Size(291, 32)
        Me.BCreatePO.TabIndex = 19
        Me.BCreatePO.Text = "Print"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(18, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl1.TabIndex = 20
        Me.LabelControl1.Text = "Proposal No."
        '
        'TxtNumber
        '
        Me.TxtNumber.Enabled = False
        Me.TxtNumber.Location = New System.Drawing.Point(18, 34)
        Me.TxtNumber.Name = "TxtNumber"
        Me.TxtNumber.Size = New System.Drawing.Size(252, 20)
        Me.TxtNumber.TabIndex = 21
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(18, 60)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl2.TabIndex = 22
        Me.LabelControl2.Text = "Type"
        '
        'TxtType
        '
        Me.TxtType.Enabled = False
        Me.TxtType.Location = New System.Drawing.Point(18, 79)
        Me.TxtType.Name = "TxtType"
        Me.TxtType.Size = New System.Drawing.Size(252, 20)
        Me.TxtType.TabIndex = 23
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(18, 105)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl3.TabIndex = 24
        Me.LabelControl3.Text = "Store"
        '
        'SLEStore
        '
        Me.SLEStore.Location = New System.Drawing.Point(18, 124)
        Me.SLEStore.Name = "SLEStore"
        Me.SLEStore.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEStore.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEStore.Size = New System.Drawing.Size(252, 20)
        Me.SLEStore.TabIndex = 25
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'FormProposePriceMKDStore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(291, 205)
        Me.Controls.Add(Me.SLEStore)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.TxtType)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.TxtNumber)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.BCreatePO)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProposePriceMKDStore"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Store"
        CType(Me.TxtNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEStore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BCreatePO As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtType As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEStore As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
End Class
