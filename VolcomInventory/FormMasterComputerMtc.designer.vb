<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterComputerMtc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterComputerMtc))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TEasset = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.DEtglmtc = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TEproblem = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.MEdtlmtc = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LEstatus = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LEusernow = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LEpic = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BTcancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BTsave = New DevExpress.XtraEditors.SimpleButton()
        Me.TEhwname = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.TEasset.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEtglmtc.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEtglmtc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEproblem.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEdtlmtc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEstatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEusernow.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEpic.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TEhwname.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(8, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(40, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Id Asset"
        '
        'TEasset
        '
        Me.TEasset.Enabled = False
        Me.TEasset.Location = New System.Drawing.Point(108, 9)
        Me.TEasset.Name = "TEasset"
        Me.TEasset.Size = New System.Drawing.Size(96, 20)
        Me.TEasset.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(283, 12)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(102, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Tanggal Maintenance"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(7, 83)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(70, 13)
        Me.LabelControl3.TabIndex = 4
        Me.LabelControl3.Text = "User Sekarang"
        '
        'DEtglmtc
        '
        Me.DEtglmtc.EditValue = Nothing
        Me.DEtglmtc.Location = New System.Drawing.Point(391, 9)
        Me.DEtglmtc.Name = "DEtglmtc"
        Me.DEtglmtc.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEtglmtc.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEtglmtc.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEtglmtc.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEtglmtc.Properties.EditFormat.FormatString = "dd MMMM yyyy"
        Me.DEtglmtc.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEtglmtc.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DEtglmtc.Size = New System.Drawing.Size(120, 20)
        Me.DEtglmtc.TabIndex = 5
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(7, 119)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(38, 13)
        Me.LabelControl4.TabIndex = 7
        Me.LabelControl4.Text = "Problem"
        '
        'TEproblem
        '
        Me.TEproblem.Location = New System.Drawing.Point(108, 116)
        Me.TEproblem.Name = "TEproblem"
        Me.TEproblem.Size = New System.Drawing.Size(403, 20)
        Me.TEproblem.TabIndex = 6
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(7, 149)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(91, 13)
        Me.LabelControl5.TabIndex = 9
        Me.LabelControl5.Text = "Detail Maintenance"
        '
        'MEdtlmtc
        '
        Me.MEdtlmtc.Location = New System.Drawing.Point(108, 148)
        Me.MEdtlmtc.Name = "MEdtlmtc"
        Me.MEdtlmtc.Size = New System.Drawing.Size(403, 85)
        Me.MEdtlmtc.TabIndex = 10
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(7, 248)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(95, 13)
        Me.LabelControl6.TabIndex = 11
        Me.LabelControl6.Text = "Status Maintenance"
        '
        'LEstatus
        '
        Me.LEstatus.Location = New System.Drawing.Point(109, 245)
        Me.LEstatus.Name = "LEstatus"
        Me.LEstatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEstatus.Properties.View = Me.SearchLookUpEdit1View
        Me.LEstatus.Size = New System.Drawing.Size(240, 20)
        Me.LEstatus.TabIndex = 12
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(7, 278)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(17, 13)
        Me.LabelControl7.TabIndex = 13
        Me.LabelControl7.Text = "PIC"
        '
        'LEusernow
        '
        Me.LEusernow.Location = New System.Drawing.Point(109, 83)
        Me.LEusernow.Name = "LEusernow"
        Me.LEusernow.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEusernow.Properties.View = Me.GridView1
        Me.LEusernow.Size = New System.Drawing.Size(240, 20)
        Me.LEusernow.TabIndex = 14
        '
        'GridView1
        '
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'LEpic
        '
        Me.LEpic.Location = New System.Drawing.Point(109, 275)
        Me.LEpic.Name = "LEpic"
        Me.LEpic.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEpic.Properties.View = Me.GridView2
        Me.LEpic.Size = New System.Drawing.Size(240, 20)
        Me.LEpic.TabIndex = 15
        '
        'GridView2
        '
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BTcancel)
        Me.PanelControl1.Controls.Add(Me.BTsave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 318)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(523, 43)
        Me.PanelControl1.TabIndex = 16
        '
        'BTcancel
        '
        Me.BTcancel.Image = CType(resources.GetObject("BTcancel.Image"), System.Drawing.Image)
        Me.BTcancel.Location = New System.Drawing.Point(323, 3)
        Me.BTcancel.Name = "BTcancel"
        Me.BTcancel.Size = New System.Drawing.Size(91, 35)
        Me.BTcancel.TabIndex = 1
        Me.BTcancel.Text = "Cancel"
        '
        'BTsave
        '
        Me.BTsave.Image = CType(resources.GetObject("BTsave.Image"), System.Drawing.Image)
        Me.BTsave.Location = New System.Drawing.Point(420, 3)
        Me.BTsave.Name = "BTsave"
        Me.BTsave.Size = New System.Drawing.Size(91, 35)
        Me.BTsave.TabIndex = 0
        Me.BTsave.Text = "Save"
        '
        'TEhwname
        '
        Me.TEhwname.EditValue = ""
        Me.TEhwname.Location = New System.Drawing.Point(109, 46)
        Me.TEhwname.Name = "TEhwname"
        Me.TEhwname.Size = New System.Drawing.Size(240, 20)
        Me.TEhwname.TabIndex = 18
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(8, 49)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(77, 13)
        Me.LabelControl8.TabIndex = 17
        Me.LabelControl8.Text = "Nama Hardware"
        '
        'FormMasterComputerMtc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(523, 361)
        Me.Controls.Add(Me.TEhwname)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.LEpic)
        Me.Controls.Add(Me.LEusernow)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.LEstatus)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.MEdtlmtc)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.TEproblem)
        Me.Controls.Add(Me.DEtglmtc)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.TEasset)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterComputerMtc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Input Detail Maintenance"
        CType(Me.TEasset.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEtglmtc.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEtglmtc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEproblem.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEdtlmtc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEstatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEusernow.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEpic.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.TEhwname.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEasset As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEtglmtc As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEproblem As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MEdtlmtc As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEstatus As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEusernow As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LEpic As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BTcancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BTsave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEhwname As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
End Class
