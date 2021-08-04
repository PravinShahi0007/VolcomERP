<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormStockTakeStorePeriodDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormStockTakeStorePeriodDet))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DESOHDate = New DevExpress.XtraEditors.DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SBAddUser = New DevExpress.XtraEditors.SimpleButton()
        Me.GCExternalUser = New DevExpress.XtraGrid.GridControl()
        Me.GVExternalUser = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SBSave = New DevExpress.XtraEditors.SimpleButton()
        Me.SBEditUser = New DevExpress.XtraEditors.SimpleButton()
        Me.DEStart = New DevExpress.XtraEditors.DateEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DEEnd = New DevExpress.XtraEditors.DateEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SBSOH = New DevExpress.XtraEditors.SimpleButton()
        Me.CEAll = New DevExpress.XtraEditors.CheckEdit()
        Me.SBSelectStore = New DevExpress.XtraEditors.SimpleButton()
        Me.SBGenerateUser = New DevExpress.XtraEditors.SimpleButton()
        Me.SEGenerateUser = New DevExpress.XtraEditors.SpinEdit()
        CType(Me.DESOHDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DESOHDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCExternalUser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVExternalUser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CEAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SEGenerateUser.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SOH Date"
        '
        'DESOHDate
        '
        Me.DESOHDate.EditValue = Nothing
        Me.DESOHDate.Location = New System.Drawing.Point(15, 35)
        Me.DESOHDate.Name = "DESOHDate"
        Me.DESOHDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DESOHDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DESOHDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DESOHDate.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DESOHDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DESOHDate.Properties.EditFormat.FormatString = "dd MMMM yyyy"
        Me.DESOHDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DESOHDate.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DESOHDate.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DESOHDate.Size = New System.Drawing.Size(357, 20)
        Me.DESOHDate.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Store"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 236)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "User"
        '
        'SBAddUser
        '
        Me.SBAddUser.Location = New System.Drawing.Point(297, 266)
        Me.SBAddUser.Name = "SBAddUser"
        Me.SBAddUser.Size = New System.Drawing.Size(75, 23)
        Me.SBAddUser.TabIndex = 6
        Me.SBAddUser.Text = "Add User"
        Me.SBAddUser.Visible = False
        '
        'GCExternalUser
        '
        Me.GCExternalUser.Location = New System.Drawing.Point(15, 295)
        Me.GCExternalUser.MainView = Me.GVExternalUser
        Me.GCExternalUser.Name = "GCExternalUser"
        Me.GCExternalUser.Size = New System.Drawing.Size(357, 225)
        Me.GCExternalUser.TabIndex = 7
        Me.GCExternalUser.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVExternalUser})
        '
        'GVExternalUser
        '
        Me.GVExternalUser.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7})
        Me.GVExternalUser.GridControl = Me.GCExternalUser
        Me.GVExternalUser.GroupCount = 1
        Me.GVExternalUser.Name = "GVExternalUser"
        Me.GVExternalUser.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVExternalUser.OptionsBehavior.Editable = False
        Me.GVExternalUser.OptionsView.ColumnAutoWidth = False
        Me.GVExternalUser.OptionsView.ShowGroupPanel = False
        Me.GVExternalUser.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn7, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "GridColumn1"
        Me.GridColumn3.FieldName = "id_user"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Name"
        Me.GridColumn4.FieldName = "name_external"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 0
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Position"
        Me.GridColumn5.FieldName = "position_external"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 1
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Username"
        Me.GridColumn6.FieldName = "username"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 2
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Store"
        Me.GridColumn7.FieldName = "store_name"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 3
        '
        'SBSave
        '
        Me.SBSave.Image = CType(resources.GetObject("SBSave.Image"), System.Drawing.Image)
        Me.SBSave.Location = New System.Drawing.Point(283, 526)
        Me.SBSave.Name = "SBSave"
        Me.SBSave.Size = New System.Drawing.Size(89, 40)
        Me.SBSave.TabIndex = 9
        Me.SBSave.Text = "Save"
        '
        'SBEditUser
        '
        Me.SBEditUser.Location = New System.Drawing.Point(216, 266)
        Me.SBEditUser.Name = "SBEditUser"
        Me.SBEditUser.Size = New System.Drawing.Size(75, 23)
        Me.SBEditUser.TabIndex = 10
        Me.SBEditUser.Text = "Edit User"
        Me.SBEditUser.Visible = False
        '
        'DEStart
        '
        Me.DEStart.EditValue = Nothing
        Me.DEStart.Location = New System.Drawing.Point(15, 143)
        Me.DEStart.Name = "DEStart"
        Me.DEStart.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.DisplayFormat.FormatString = "dd MMMM yyyy / HH:mm"
        Me.DEStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStart.Properties.EditFormat.FormatString = "dd MMMM yyyy / HH:mm"
        Me.DEStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStart.Properties.Mask.EditMask = "dd MMMM yyyy / HH:mm"
        Me.DEStart.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DEStart.Size = New System.Drawing.Size(175, 20)
        Me.DEStart.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Schedule"
        '
        'DEEnd
        '
        Me.DEEnd.EditValue = Nothing
        Me.DEEnd.Location = New System.Drawing.Point(197, 143)
        Me.DEEnd.Name = "DEEnd"
        Me.DEEnd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEnd.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEnd.Properties.DisplayFormat.FormatString = "dd MMMM yyyy / HH:mm"
        Me.DEEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEEnd.Properties.EditFormat.FormatString = "dd MMMM yyyy / HH:mm"
        Me.DEEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEEnd.Properties.Mask.EditMask = "dd MMMM yyyy / HH:mm"
        Me.DEEnd.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DEEnd.Size = New System.Drawing.Size(175, 20)
        Me.DEEnd.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 176)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Product"
        '
        'SBSOH
        '
        Me.SBSOH.Location = New System.Drawing.Point(15, 197)
        Me.SBSOH.Name = "SBSOH"
        Me.SBSOH.Size = New System.Drawing.Size(264, 23)
        Me.SBSOH.TabIndex = 15
        Me.SBSOH.Text = "Select Product"
        '
        'CEAll
        '
        Me.CEAll.Location = New System.Drawing.Point(295, 199)
        Me.CEAll.Name = "CEAll"
        Me.CEAll.Properties.Caption = "All Product"
        Me.CEAll.Size = New System.Drawing.Size(77, 19)
        Me.CEAll.TabIndex = 16
        '
        'SBSelectStore
        '
        Me.SBSelectStore.Location = New System.Drawing.Point(15, 84)
        Me.SBSelectStore.Name = "SBSelectStore"
        Me.SBSelectStore.Size = New System.Drawing.Size(357, 23)
        Me.SBSelectStore.TabIndex = 17
        Me.SBSelectStore.Text = "Select Store"
        '
        'SBGenerateUser
        '
        Me.SBGenerateUser.Location = New System.Drawing.Point(63, 266)
        Me.SBGenerateUser.Name = "SBGenerateUser"
        Me.SBGenerateUser.Size = New System.Drawing.Size(95, 23)
        Me.SBGenerateUser.TabIndex = 18
        Me.SBGenerateUser.Text = "Generate User"
        '
        'SEGenerateUser
        '
        Me.SEGenerateUser.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.SEGenerateUser.Location = New System.Drawing.Point(15, 268)
        Me.SEGenerateUser.Name = "SEGenerateUser"
        Me.SEGenerateUser.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SEGenerateUser.Size = New System.Drawing.Size(42, 20)
        Me.SEGenerateUser.TabIndex = 19
        '
        'FormStockTakeStorePeriodDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 593)
        Me.Controls.Add(Me.SEGenerateUser)
        Me.Controls.Add(Me.SBGenerateUser)
        Me.Controls.Add(Me.SBSelectStore)
        Me.Controls.Add(Me.CEAll)
        Me.Controls.Add(Me.SBSOH)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DEEnd)
        Me.Controls.Add(Me.DEStart)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.SBEditUser)
        Me.Controls.Add(Me.SBSave)
        Me.Controls.Add(Me.GCExternalUser)
        Me.Controls.Add(Me.SBAddUser)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DESOHDate)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormStockTakeStorePeriodDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Take Store Period Detail"
        CType(Me.DESOHDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DESOHDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCExternalUser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVExternalUser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CEAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SEGenerateUser.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents DESOHDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents SBAddUser As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCExternalUser As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVExternalUser As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SBSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBEditUser As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents DEEnd As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label5 As Label
    Friend WithEvents SBSOH As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CEAll As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents SBSelectStore As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBGenerateUser As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SEGenerateUser As DevExpress.XtraEditors.SpinEdit
End Class
