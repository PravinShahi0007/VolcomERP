<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPIBPPSDet
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
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GCSummary = New DevExpress.XtraGrid.GridControl()
        Me.GVSummary = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.BCreatePPS = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.DEPIBOld = New DevExpress.XtraEditors.DateEdit()
        Me.TEPIBNumberOld = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.DEPIB = New DevExpress.XtraEditors.DateEdit()
        Me.TEPIBNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.DEVp = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.DEOldVp = New DevExpress.XtraEditors.DateEdit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GCSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DEPIBOld.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEPIBOld.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPIBNumberOld.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEPIB.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEPIB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPIBNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEVp.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEVp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEOldVp.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEOldVp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.GCSummary)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(623, 436)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Pick ISB"
        '
        'GCSummary
        '
        Me.GCSummary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSummary.Location = New System.Drawing.Point(2, 20)
        Me.GCSummary.MainView = Me.GVSummary
        Me.GCSummary.Name = "GCSummary"
        Me.GCSummary.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit1})
        Me.GCSummary.Size = New System.Drawing.Size(619, 414)
        Me.GCSummary.TabIndex = 2
        Me.GCSummary.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSummary})
        '
        'GVSummary
        '
        Me.GVSummary.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn16})
        Me.GVSummary.GridControl = Me.GCSummary
        Me.GVSummary.Name = "GVSummary"
        Me.GVSummary.OptionsBehavior.Editable = False
        Me.GVSummary.OptionsBehavior.ReadOnly = True
        Me.GVSummary.OptionsFind.AlwaysVisible = True
        Me.GVSummary.OptionsView.RowAutoHeight = True
        Me.GVSummary.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "id"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "ISB Number"
        Me.GridColumn2.FieldName = "pre_cal_fgpo_number"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 157
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "FGPO List"
        Me.GridColumn16.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.GridColumn16.FieldName = "list_fgpo"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 1
        Me.GridColumn16.Width = 446
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'BCreatePPS
        '
        Me.BCreatePPS.Appearance.BackColor = System.Drawing.Color.DarkBlue
        Me.BCreatePPS.Appearance.ForeColor = System.Drawing.Color.White
        Me.BCreatePPS.Appearance.Options.UseBackColor = True
        Me.BCreatePPS.Appearance.Options.UseForeColor = True
        Me.BCreatePPS.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.BCreatePPS.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BCreatePPS.Location = New System.Drawing.Point(0, 550)
        Me.BCreatePPS.Name = "BCreatePPS"
        Me.BCreatePPS.Size = New System.Drawing.Size(623, 40)
        Me.BCreatePPS.TabIndex = 7
        Me.BCreatePPS.Text = "Pick"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.DEOldVp)
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Controls.Add(Me.DEVp)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.DEPIBOld)
        Me.PanelControl1.Controls.Add(Me.TEPIBNumberOld)
        Me.PanelControl1.Controls.Add(Me.LabelControl5)
        Me.PanelControl1.Controls.Add(Me.LabelControl6)
        Me.PanelControl1.Controls.Add(Me.DEPIB)
        Me.PanelControl1.Controls.Add(Me.TEPIBNumber)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 436)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(623, 114)
        Me.PanelControl1.TabIndex = 8
        '
        'DEPIBOld
        '
        Me.DEPIBOld.EditValue = Nothing
        Me.DEPIBOld.Location = New System.Drawing.Point(118, 50)
        Me.DEPIBOld.Name = "DEPIBOld"
        Me.DEPIBOld.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEPIBOld.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEPIBOld.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEPIBOld.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEPIBOld.Properties.ReadOnly = True
        Me.DEPIBOld.Size = New System.Drawing.Size(183, 20)
        Me.DEPIBOld.TabIndex = 193
        '
        'TEPIBNumberOld
        '
        Me.TEPIBNumberOld.Location = New System.Drawing.Point(118, 18)
        Me.TEPIBNumberOld.Name = "TEPIBNumberOld"
        Me.TEPIBNumberOld.Properties.ReadOnly = True
        Me.TEPIBNumberOld.Size = New System.Drawing.Size(183, 20)
        Me.TEPIBNumberOld.TabIndex = 192
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(17, 53)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl5.TabIndex = 189
        Me.LabelControl5.Text = "Old PIB Date"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(17, 21)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(75, 13)
        Me.LabelControl6.TabIndex = 188
        Me.LabelControl6.Text = "Old PIB Number"
        '
        'DEPIB
        '
        Me.DEPIB.EditValue = Nothing
        Me.DEPIB.Location = New System.Drawing.Point(419, 50)
        Me.DEPIB.Name = "DEPIB"
        Me.DEPIB.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEPIB.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEPIB.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEPIB.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEPIB.Size = New System.Drawing.Size(183, 20)
        Me.DEPIB.TabIndex = 187
        '
        'TEPIBNumber
        '
        Me.TEPIBNumber.Location = New System.Drawing.Point(419, 18)
        Me.TEPIBNumber.Name = "TEPIBNumber"
        Me.TEPIBNumber.Size = New System.Drawing.Size(183, 20)
        Me.TEPIBNumber.TabIndex = 186
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(336, 53)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(42, 13)
        Me.LabelControl3.TabIndex = 183
        Me.LabelControl3.Text = "PIB Date"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(336, 21)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl2.TabIndex = 182
        Me.LabelControl2.Text = "PIB Number"
        '
        'DEVp
        '
        Me.DEVp.EditValue = Nothing
        Me.DEVp.Location = New System.Drawing.Point(419, 82)
        Me.DEVp.Name = "DEVp"
        Me.DEVp.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEVp.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEVp.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEVp.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEVp.Size = New System.Drawing.Size(183, 20)
        Me.DEVp.TabIndex = 195
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(336, 85)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(60, 13)
        Me.LabelControl1.TabIndex = 194
        Me.LabelControl1.Text = "VP Due Date"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(17, 85)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(79, 13)
        Me.LabelControl4.TabIndex = 196
        Me.LabelControl4.Text = "Old VP Due Date"
        '
        'DEOldVp
        '
        Me.DEOldVp.EditValue = Nothing
        Me.DEOldVp.Location = New System.Drawing.Point(118, 82)
        Me.DEOldVp.Name = "DEOldVp"
        Me.DEOldVp.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEOldVp.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEOldVp.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEOldVp.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEOldVp.Properties.ReadOnly = True
        Me.DEOldVp.Size = New System.Drawing.Size(183, 20)
        Me.DEOldVp.TabIndex = 197
        '
        'FormPIBPPSDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(623, 590)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.BCreatePPS)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPIBPPSDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PIB Detail"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GCSummary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSummary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.DEPIBOld.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEPIBOld.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPIBNumberOld.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEPIB.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEPIB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPIBNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEVp.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEVp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEOldVp.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEOldVp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BCreatePPS As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCSummary As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSummary As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DEPIBOld As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TEPIBNumberOld As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEPIB As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TEPIBNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents DEOldVp As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEVp As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
End Class
