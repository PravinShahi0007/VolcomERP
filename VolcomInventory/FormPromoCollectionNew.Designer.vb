<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPromoCollectionNew
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPromoCollectionNew))
        Me.TxtTag = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.DEEnd = New DevExpress.XtraEditors.DateEdit()
        Me.DEStart = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEPromoType = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnDiscard = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCreateNew = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtPromoName = New DevExpress.XtraEditors.TextEdit()
        Me.CheckEdit1 = New DevExpress.XtraEditors.CheckEdit()
        Me.SLEPromo = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.TxtTag.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEPromoType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TxtPromoName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEPromo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtTag
        '
        Me.TxtTag.Location = New System.Drawing.Point(104, 93)
        Me.TxtTag.Name = "TxtTag"
        Me.TxtTag.Size = New System.Drawing.Size(301, 20)
        Me.TxtTag.TabIndex = 169
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Location = New System.Drawing.Point(19, 96)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(18, 13)
        Me.LabelControl8.TabIndex = 168
        Me.LabelControl8.Text = "Tag"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(19, 148)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl6.TabIndex = 167
        Me.LabelControl6.Text = "End Period"
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(19, 173)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl7.TabIndex = 160
        Me.LabelControl7.Text = "Note"
        '
        'DEEnd
        '
        Me.DEEnd.EditValue = Nothing
        Me.DEEnd.Location = New System.Drawing.Point(104, 145)
        Me.DEEnd.Name = "DEEnd"
        Me.DEEnd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEnd.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.[True]
        Me.DEEnd.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEnd.Properties.CalendarTimeProperties.Mask.EditMask = "HH:mm"
        Me.DEEnd.Properties.DisplayFormat.FormatString = "dd MMM yyyy HH:mm"
        Me.DEEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEEnd.Properties.Mask.EditMask = "dd-MM-yyyy/HH:mm"
        Me.DEEnd.Size = New System.Drawing.Size(301, 20)
        Me.DEEnd.TabIndex = 166
        '
        'DEStart
        '
        Me.DEStart.EditValue = Nothing
        Me.DEStart.Location = New System.Drawing.Point(104, 119)
        Me.DEStart.Name = "DEStart"
        Me.DEStart.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.[True]
        Me.DEStart.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.CalendarTimeProperties.Mask.EditMask = "HH:mm"
        Me.DEStart.Properties.DisplayFormat.FormatString = "dd MMM yyyy HH:mm"
        Me.DEStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStart.Properties.Mask.EditMask = "dd-MM-yyyy/HH:mm"
        Me.DEStart.Size = New System.Drawing.Size(301, 20)
        Me.DEStart.TabIndex = 165
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(19, 122)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(57, 13)
        Me.LabelControl5.TabIndex = 164
        Me.LabelControl5.Text = "Start Period"
        '
        'SLEPromoType
        '
        Me.SLEPromoType.Enabled = False
        Me.SLEPromoType.Location = New System.Drawing.Point(19, 437)
        Me.SLEPromoType.Name = "SLEPromoType"
        Me.SLEPromoType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEPromoType.Properties.ShowClearButton = False
        Me.SLEPromoType.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEPromoType.Size = New System.Drawing.Size(301, 20)
        Me.SLEPromoType.TabIndex = 162
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(104, 171)
        Me.MENote.Name = "MENote"
        Me.MENote.Size = New System.Drawing.Size(301, 41)
        Me.MENote.TabIndex = 161
        Me.MENote.TabStop = False
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnDiscard)
        Me.PanelControl1.Controls.Add(Me.BtnCreateNew)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 235)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(428, 48)
        Me.PanelControl1.TabIndex = 170
        '
        'BtnDiscard
        '
        Me.BtnDiscard.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDiscard.Image = CType(resources.GetObject("BtnDiscard.Image"), System.Drawing.Image)
        Me.BtnDiscard.Location = New System.Drawing.Point(221, 2)
        Me.BtnDiscard.Name = "BtnDiscard"
        Me.BtnDiscard.Size = New System.Drawing.Size(95, 44)
        Me.BtnDiscard.TabIndex = 1
        Me.BtnDiscard.Text = "Discard"
        '
        'BtnCreateNew
        '
        Me.BtnCreateNew.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCreateNew.Image = CType(resources.GetObject("BtnCreateNew.Image"), System.Drawing.Image)
        Me.BtnCreateNew.Location = New System.Drawing.Point(316, 2)
        Me.BtnCreateNew.Name = "BtnCreateNew"
        Me.BtnCreateNew.Size = New System.Drawing.Size(110, 44)
        Me.BtnCreateNew.TabIndex = 0
        Me.BtnCreateNew.Text = "Create New"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(19, 70)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(60, 13)
        Me.LabelControl1.TabIndex = 171
        Me.LabelControl1.Text = "Promo Name"
        '
        'TxtPromoName
        '
        Me.TxtPromoName.Location = New System.Drawing.Point(104, 67)
        Me.TxtPromoName.Name = "TxtPromoName"
        Me.TxtPromoName.Size = New System.Drawing.Size(301, 20)
        Me.TxtPromoName.TabIndex = 172
        '
        'CheckEdit1
        '
        Me.CheckEdit1.Location = New System.Drawing.Point(260, 15)
        Me.CheckEdit1.Name = "CheckEdit1"
        Me.CheckEdit1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckEdit1.Properties.Appearance.Options.UseFont = True
        Me.CheckEdit1.Properties.Caption = "Use Discount Codes"
        Me.CheckEdit1.Size = New System.Drawing.Size(155, 20)
        Me.CheckEdit1.TabIndex = 173
        '
        'SLEPromo
        '
        Me.SLEPromo.Location = New System.Drawing.Point(104, 41)
        Me.SLEPromo.Name = "SLEPromo"
        Me.SLEPromo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEPromo.Properties.View = Me.GridView1
        Me.SLEPromo.Size = New System.Drawing.Size(301, 20)
        Me.SLEPromo.TabIndex = 174
        '
        'GridView1
        '
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(19, 44)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(73, 13)
        Me.LabelControl2.TabIndex = 175
        Me.LabelControl2.Text = "Group Discount"
        '
        'FormPromoCollectionNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(428, 283)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.SLEPromo)
        Me.Controls.Add(Me.CheckEdit1)
        Me.Controls.Add(Me.TxtPromoName)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.TxtTag)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.DEEnd)
        Me.Controls.Add(Me.DEStart)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.SLEPromoType)
        Me.Controls.Add(Me.MENote)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPromoCollectionNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create New - Promo Collection"
        CType(Me.TxtTag.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEPromoType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.TxtPromoName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEPromo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtTag As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEEnd As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEPromoType As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnDiscard As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCreateNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtPromoName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents CheckEdit1 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents SLEPromo As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
End Class
