<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSOPIndexScheduleEdit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSOPIndexScheduleEdit))
        Me.DETimeEnd = New DevExpress.XtraEditors.TimeEdit()
        Me.DETimeStart = New DevExpress.XtraEditors.TimeEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLUEDepartment = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DEDate = New DevExpress.XtraEditors.DateEdit()
        Me.SBSave = New DevExpress.XtraEditors.SimpleButton()
        Me.SBClose = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.DETimeEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DETimeStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLUEDepartment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DETimeEnd
        '
        Me.DETimeEnd.EditValue = New Date(2021, 12, 17, 0, 0, 0, 0)
        Me.DETimeEnd.Location = New System.Drawing.Point(225, 71)
        Me.DETimeEnd.Name = "DETimeEnd"
        Me.DETimeEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DETimeEnd.Properties.DisplayFormat.FormatString = "HH:mm"
        Me.DETimeEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DETimeEnd.Properties.EditFormat.FormatString = "HH:mm"
        Me.DETimeEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DETimeEnd.Properties.Mask.EditMask = "HH:mm"
        Me.DETimeEnd.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DETimeEnd.Size = New System.Drawing.Size(100, 20)
        Me.DETimeEnd.TabIndex = 19
        '
        'DETimeStart
        '
        Me.DETimeStart.EditValue = New Date(2021, 12, 17, 0, 0, 0, 0)
        Me.DETimeStart.Location = New System.Drawing.Point(100, 71)
        Me.DETimeStart.Name = "DETimeStart"
        Me.DETimeStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DETimeStart.Properties.DisplayFormat.FormatString = "HH:mm"
        Me.DETimeStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DETimeStart.Properties.EditFormat.FormatString = "HH:mm"
        Me.DETimeStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DETimeStart.Properties.Mask.EditMask = "HH:mm"
        Me.DETimeStart.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DETimeStart.Size = New System.Drawing.Size(100, 20)
        Me.DETimeStart.TabIndex = 18
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(210, 74)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(4, 13)
        Me.LabelControl4.TabIndex = 17
        Me.LabelControl4.Text = "-"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(22, 74)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl3.TabIndex = 16
        Me.LabelControl3.Text = "Time"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(22, 48)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl2.TabIndex = 15
        Me.LabelControl2.Text = "Date"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(22, 22)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(57, 13)
        Me.LabelControl1.TabIndex = 14
        Me.LabelControl1.Text = "Department"
        '
        'SLUEDepartment
        '
        Me.SLUEDepartment.Location = New System.Drawing.Point(100, 19)
        Me.SLUEDepartment.Name = "SLUEDepartment"
        Me.SLUEDepartment.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUEDepartment.Properties.View = Me.SearchLookUpEdit1View
        Me.SLUEDepartment.Size = New System.Drawing.Size(225, 20)
        Me.SLUEDepartment.TabIndex = 13
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn4, Me.GridColumn5})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn4
        '
        Me.GridColumn4.FieldName = "id_departement"
        Me.GridColumn4.Name = "GridColumn4"
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Department"
        Me.GridColumn5.FieldName = "departement"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 0
        '
        'DEDate
        '
        Me.DEDate.EditValue = Nothing
        Me.DEDate.Location = New System.Drawing.Point(100, 45)
        Me.DEDate.Name = "DEDate"
        Me.DEDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDate.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEDate.Properties.EditFormat.FormatString = "dd MMMM yyyy"
        Me.DEDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEDate.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DEDate.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DEDate.Size = New System.Drawing.Size(225, 20)
        Me.DEDate.TabIndex = 12
        '
        'SBSave
        '
        Me.SBSave.Image = CType(resources.GetObject("SBSave.Image"), System.Drawing.Image)
        Me.SBSave.Location = New System.Drawing.Point(250, 107)
        Me.SBSave.Name = "SBSave"
        Me.SBSave.Size = New System.Drawing.Size(75, 23)
        Me.SBSave.TabIndex = 20
        Me.SBSave.Text = "Save"
        '
        'SBClose
        '
        Me.SBClose.Image = CType(resources.GetObject("SBClose.Image"), System.Drawing.Image)
        Me.SBClose.Location = New System.Drawing.Point(169, 107)
        Me.SBClose.Name = "SBClose"
        Me.SBClose.Size = New System.Drawing.Size(75, 23)
        Me.SBClose.TabIndex = 21
        Me.SBClose.Text = "Close"
        '
        'FormSOPIndexScheduleEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(345, 147)
        Me.Controls.Add(Me.SBClose)
        Me.Controls.Add(Me.SBSave)
        Me.Controls.Add(Me.DETimeEnd)
        Me.Controls.Add(Me.DETimeStart)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.SLUEDepartment)
        Me.Controls.Add(Me.DEDate)
        Me.Name = "FormSOPIndexScheduleEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Schedule Edit"
        CType(Me.DETimeEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DETimeStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLUEDepartment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DETimeEnd As DevExpress.XtraEditors.TimeEdit
    Friend WithEvents DETimeStart As DevExpress.XtraEditors.TimeEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLUEDepartment As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DEDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents SBSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBClose As DevExpress.XtraEditors.SimpleButton
End Class
