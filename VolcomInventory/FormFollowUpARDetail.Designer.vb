<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFollowUpARDetail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFollowUpARDetail))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnDiscard = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEStoreGroup = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEDue = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SLEDueDate = New DevExpress.XtraEditors.LabelControl()
        Me.MEFollowUp = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.MEResult = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.DEFollowUpDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_due_date_sle = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEStoreGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEDue.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEFollowUp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEResult.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFollowUpDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFollowUpDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnDiscard)
        Me.PanelControl1.Controls.Add(Me.BtnSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 225)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(396, 43)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), System.Drawing.Image)
        Me.BtnSave.Location = New System.Drawing.Point(310, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(84, 39)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "Save"
        '
        'BtnDiscard
        '
        Me.BtnDiscard.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDiscard.Image = CType(resources.GetObject("BtnDiscard.Image"), System.Drawing.Image)
        Me.BtnDiscard.Location = New System.Drawing.Point(226, 2)
        Me.BtnDiscard.Name = "BtnDiscard"
        Me.BtnDiscard.Size = New System.Drawing.Size(84, 39)
        Me.BtnDiscard.TabIndex = 1
        Me.BtnDiscard.Text = "Discard"
        '
        'SLEStoreGroup
        '
        Me.SLEStoreGroup.Location = New System.Drawing.Point(118, 15)
        Me.SLEStoreGroup.Name = "SLEStoreGroup"
        Me.SLEStoreGroup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEStoreGroup.Properties.NullText = "- Select Group Store -"
        Me.SLEStoreGroup.Properties.View = Me.GridView3
        Me.SLEStoreGroup.Size = New System.Drawing.Size(247, 20)
        Me.SLEStoreGroup.TabIndex = 8929
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumncomp_group, Me.GridColumndescription})
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(19, 18)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl1.TabIndex = 8928
        Me.LabelControl1.Text = "Store Group"
        '
        'SLEDue
        '
        Me.SLEDue.Location = New System.Drawing.Point(118, 41)
        Me.SLEDue.Name = "SLEDue"
        Me.SLEDue.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEDue.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.SLEDue.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.SLEDue.Properties.EditFormat.FormatString = "dd MMMM yyyy"
        Me.SLEDue.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.SLEDue.Properties.ShowClearButton = False
        Me.SLEDue.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEDue.Size = New System.Drawing.Size(247, 20)
        Me.SLEDue.TabIndex = 8930
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnsales_pos_due_date_sle})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'SLEDueDate
        '
        Me.SLEDueDate.Location = New System.Drawing.Point(19, 44)
        Me.SLEDueDate.Name = "SLEDueDate"
        Me.SLEDueDate.Size = New System.Drawing.Size(45, 13)
        Me.SLEDueDate.TabIndex = 8931
        Me.SLEDueDate.Text = "Due Date"
        '
        'MEFollowUp
        '
        Me.MEFollowUp.Location = New System.Drawing.Point(118, 93)
        Me.MEFollowUp.Name = "MEFollowUp"
        Me.MEFollowUp.Size = New System.Drawing.Size(247, 54)
        Me.MEFollowUp.TabIndex = 8932
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(19, 95)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl2.TabIndex = 8933
        Me.LabelControl2.Text = "Follow Up"
        '
        'MEResult
        '
        Me.MEResult.Location = New System.Drawing.Point(118, 153)
        Me.MEResult.Name = "MEResult"
        Me.MEResult.Size = New System.Drawing.Size(247, 54)
        Me.MEResult.TabIndex = 8934
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(19, 155)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(79, 13)
        Me.LabelControl3.TabIndex = 8935
        Me.LabelControl3.Text = "Follow Up Result"
        '
        'DEFollowUpDate
        '
        Me.DEFollowUpDate.EditValue = Nothing
        Me.DEFollowUpDate.Location = New System.Drawing.Point(118, 67)
        Me.DEFollowUpDate.Name = "DEFollowUpDate"
        Me.DEFollowUpDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFollowUpDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFollowUpDate.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEFollowUpDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFollowUpDate.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DEFollowUpDate.Size = New System.Drawing.Size(247, 20)
        Me.DEFollowUpDate.TabIndex = 8936
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(19, 70)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(72, 13)
        Me.LabelControl4.TabIndex = 8937
        Me.LabelControl4.Text = "Follow Up Date"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "id_comp_group"
        Me.GridColumn1.FieldName = "id_comp_group"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumncomp_group
        '
        Me.GridColumncomp_group.Caption = "Group"
        Me.GridColumncomp_group.FieldName = "comp_group"
        Me.GridColumncomp_group.Name = "GridColumncomp_group"
        Me.GridColumncomp_group.Visible = True
        Me.GridColumncomp_group.VisibleIndex = 0
        '
        'GridColumndescription
        '
        Me.GridColumndescription.Caption = "Description"
        Me.GridColumndescription.FieldName = "description"
        Me.GridColumndescription.Name = "GridColumndescription"
        Me.GridColumndescription.Visible = True
        Me.GridColumndescription.VisibleIndex = 1
        '
        'GridColumnsales_pos_due_date_sle
        '
        Me.GridColumnsales_pos_due_date_sle.Caption = "Due Date"
        Me.GridColumnsales_pos_due_date_sle.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnsales_pos_due_date_sle.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsales_pos_due_date_sle.FieldName = "sales_pos_due_date"
        Me.GridColumnsales_pos_due_date_sle.Name = "GridColumnsales_pos_due_date_sle"
        Me.GridColumnsales_pos_due_date_sle.Visible = True
        Me.GridColumnsales_pos_due_date_sle.VisibleIndex = 0
        '
        'FormFollowUpARDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 268)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.DEFollowUpDate)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.MEResult)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.MEFollowUp)
        Me.Controls.Add(Me.SLEDueDate)
        Me.Controls.Add(Me.SLEDue)
        Me.Controls.Add(Me.SLEStoreGroup)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormFollowUpARDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Follow Up"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.SLEStoreGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEDue.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEFollowUp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEResult.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFollowUpDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFollowUpDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnDiscard As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLEStoreGroup As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEDue As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SLEDueDate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MEFollowUp As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MEResult As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEFollowUpDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumnsales_pos_due_date_sle As DevExpress.XtraGrid.Columns.GridColumn
End Class
