<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCompanyEmailMappingDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCompanyEmailMappingDet))
        Me.SLUEName = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnVName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnVDetail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SLUEContact = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit2View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SLUEType = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LCName = New DevExpress.XtraEditors.LabelControl()
        Me.LCContact = New DevExpress.XtraEditors.LabelControl()
        Me.LCType = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SBClose = New DevExpress.XtraEditors.SimpleButton()
        Me.SBSave = New DevExpress.XtraEditors.SimpleButton()
        Me.PCCheck = New DevExpress.XtraEditors.PanelControl()
        Me.PCDetail = New DevExpress.XtraEditors.PanelControl()
        Me.LCGroup = New DevExpress.XtraEditors.LabelControl()
        Me.SLUEGroup = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.SLUEName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLUEContact.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit2View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLUEType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PCCheck, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCDetail.SuspendLayout()
        CType(Me.SLUEGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SLUEName
        '
        Me.SLUEName.Location = New System.Drawing.Point(106, 23)
        Me.SLUEName.Name = "SLUEName"
        Me.SLUEName.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUEName.Properties.View = Me.SearchLookUpEdit1View
        Me.SLUEName.Size = New System.Drawing.Size(400, 20)
        Me.SLUEName.TabIndex = 0
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumnVName, Me.GridColumnVDetail, Me.GridColumn4})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "id"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumnVName
        '
        Me.GridColumnVName.FieldName = "name"
        Me.GridColumnVName.Name = "GridColumnVName"
        Me.GridColumnVName.Visible = True
        Me.GridColumnVName.VisibleIndex = 0
        '
        'GridColumnVDetail
        '
        Me.GridColumnVDetail.FieldName = "detail"
        Me.GridColumnVDetail.Name = "GridColumnVDetail"
        Me.GridColumnVDetail.Visible = True
        Me.GridColumnVDetail.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.FieldName = "description"
        Me.GridColumn4.Name = "GridColumn4"
        '
        'SLUEContact
        '
        Me.SLUEContact.Location = New System.Drawing.Point(106, 75)
        Me.SLUEContact.Name = "SLUEContact"
        Me.SLUEContact.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUEContact.Properties.View = Me.SearchLookUpEdit2View
        Me.SLUEContact.Size = New System.Drawing.Size(400, 20)
        Me.SLUEContact.TabIndex = 1
        '
        'SearchLookUpEdit2View
        '
        Me.SearchLookUpEdit2View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn5, Me.GridColumn14, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9})
        Me.SearchLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit2View.Name = "SearchLookUpEdit2View"
        Me.SearchLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit2View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn5
        '
        Me.GridColumn5.FieldName = "id_comp_contact"
        Me.GridColumn5.Name = "GridColumn5"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Contact Name"
        Me.GridColumn6.FieldName = "contact_person"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 1
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Position"
        Me.GridColumn7.FieldName = "position"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 2
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Email"
        Me.GridColumn8.FieldName = "email"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 3
        '
        'GridColumn9
        '
        Me.GridColumn9.FieldName = "description"
        Me.GridColumn9.Name = "GridColumn9"
        '
        'SLUEType
        '
        Me.SLUEType.Location = New System.Drawing.Point(106, 101)
        Me.SLUEType.Name = "SLUEType"
        Me.SLUEType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUEType.Properties.View = Me.GridView1
        Me.SLUEType.Size = New System.Drawing.Size(400, 20)
        Me.SLUEType.TabIndex = 2
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn2})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn3
        '
        Me.GridColumn3.FieldName = "id_mail_member_type"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Type"
        Me.GridColumn2.FieldName = "mail_member_type"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'LCName
        '
        Me.LCName.Location = New System.Drawing.Point(21, 24)
        Me.LCName.Name = "LCName"
        Me.LCName.Size = New System.Drawing.Size(58, 13)
        Me.LCName.TabIndex = 5
        Me.LCName.Text = "Store Group"
        '
        'LCContact
        '
        Me.LCContact.Location = New System.Drawing.Point(21, 76)
        Me.LCContact.Name = "LCContact"
        Me.LCContact.Size = New System.Drawing.Size(38, 13)
        Me.LCContact.TabIndex = 6
        Me.LCContact.Text = "Contact"
        '
        'LCType
        '
        Me.LCType.Location = New System.Drawing.Point(21, 102)
        Me.LCType.Name = "LCType"
        Me.LCType.Size = New System.Drawing.Size(24, 13)
        Me.LCType.TabIndex = 7
        Me.LCType.Text = "Type"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SBClose)
        Me.PanelControl1.Controls.Add(Me.SBSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 156)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(534, 49)
        Me.PanelControl1.TabIndex = 8
        '
        'SBClose
        '
        Me.SBClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBClose.Image = CType(resources.GetObject("SBClose.Image"), System.Drawing.Image)
        Me.SBClose.Location = New System.Drawing.Point(359, 2)
        Me.SBClose.Name = "SBClose"
        Me.SBClose.Size = New System.Drawing.Size(83, 45)
        Me.SBClose.TabIndex = 1
        Me.SBClose.Text = "Close"
        '
        'SBSave
        '
        Me.SBSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBSave.Image = CType(resources.GetObject("SBSave.Image"), System.Drawing.Image)
        Me.SBSave.Location = New System.Drawing.Point(442, 2)
        Me.SBSave.Name = "SBSave"
        Me.SBSave.Size = New System.Drawing.Size(90, 45)
        Me.SBSave.TabIndex = 0
        Me.SBSave.Text = "Save"
        '
        'PCCheck
        '
        Me.PCCheck.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCCheck.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PCCheck.Location = New System.Drawing.Point(0, 131)
        Me.PCCheck.Name = "PCCheck"
        Me.PCCheck.Size = New System.Drawing.Size(534, 25)
        Me.PCCheck.TabIndex = 9
        '
        'PCDetail
        '
        Me.PCDetail.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCDetail.Controls.Add(Me.LCGroup)
        Me.PCDetail.Controls.Add(Me.SLUEGroup)
        Me.PCDetail.Controls.Add(Me.LCName)
        Me.PCDetail.Controls.Add(Me.SLUEName)
        Me.PCDetail.Controls.Add(Me.SLUEContact)
        Me.PCDetail.Controls.Add(Me.LCType)
        Me.PCDetail.Controls.Add(Me.SLUEType)
        Me.PCDetail.Controls.Add(Me.LCContact)
        Me.PCDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCDetail.Location = New System.Drawing.Point(0, 0)
        Me.PCDetail.Name = "PCDetail"
        Me.PCDetail.Size = New System.Drawing.Size(534, 131)
        Me.PCDetail.TabIndex = 10
        '
        'LCGroup
        '
        Me.LCGroup.Location = New System.Drawing.Point(21, 50)
        Me.LCGroup.Name = "LCGroup"
        Me.LCGroup.Size = New System.Drawing.Size(58, 13)
        Me.LCGroup.TabIndex = 9
        Me.LCGroup.Text = "Store Group"
        '
        'SLUEGroup
        '
        Me.SLUEGroup.Location = New System.Drawing.Point(106, 49)
        Me.SLUEGroup.Name = "SLUEGroup"
        Me.SLUEGroup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUEGroup.Properties.View = Me.GridView2
        Me.SLUEGroup.Size = New System.Drawing.Size(400, 20)
        Me.SLUEGroup.TabIndex = 8
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn10
        '
        Me.GridColumn10.FieldName = "id"
        Me.GridColumn10.Name = "GridColumn10"
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Store Group"
        Me.GridColumn11.FieldName = "name"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 0
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Description"
        Me.GridColumn12.FieldName = "detail"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 1
        '
        'GridColumn13
        '
        Me.GridColumn13.FieldName = "description"
        Me.GridColumn13.Name = "GridColumn13"
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Company Name"
        Me.GridColumn14.FieldName = "comp_name"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 0
        '
        'FormCompanyEmailMappingDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 205)
        Me.Controls.Add(Me.PCCheck)
        Me.Controls.Add(Me.PCDetail)
        Me.Controls.Add(Me.PanelControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCompanyEmailMappingDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Email Mapping Detail"
        CType(Me.SLUEName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLUEContact.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit2View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLUEType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PCCheck, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCDetail.ResumeLayout(False)
        Me.PCDetail.PerformLayout()
        CType(Me.SLUEGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SLUEName As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SLUEContact As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit2View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SLUEType As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LCName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LCContact As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LCType As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PCCheck As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PCDetail As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnVName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnVDetail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LCGroup As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLUEGroup As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
End Class
