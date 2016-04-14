<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAccess
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAccess))
        Me.PCBack = New DevExpress.XtraEditors.PanelControl()
        Me.XTCMenuManage = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPForm = New DevExpress.XtraTab.XtraTabPage()
        Me.XTCForm = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPFormMain = New DevExpress.XtraTab.XtraTabPage()
        Me.GCForm = New DevExpress.XtraGrid.GridControl()
        Me.GVForm = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPFormControl = New DevExpress.XtraTab.XtraTabPage()
        Me.GCProcess = New DevExpress.XtraGrid.GridControl()
        Me.GVProcess = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdFormControl = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDescriptionFormControl = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFormControlType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdFormControlType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIsView = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnIsViewDB = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPMenu = New DevExpress.XtraTab.XtraTabPage()
        Me.GCMenu = New DevExpress.XtraGrid.GridControl()
        Me.GVMenu = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnDescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnMenu = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdMenu = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnGroup = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPRole = New DevExpress.XtraTab.XtraTabPage()
        Me.GCRole = New DevExpress.XtraGrid.GridControl()
        Me.GVRole = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColumnIdRole = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GolumnRoleMaster = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PCBack, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCBack.SuspendLayout()
        CType(Me.XTCMenuManage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCMenuManage.SuspendLayout()
        Me.XTPForm.SuspendLayout()
        CType(Me.XTCForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCForm.SuspendLayout()
        Me.XTPFormMain.SuspendLayout()
        CType(Me.GCForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPFormControl.SuspendLayout()
        CType(Me.GCProcess, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProcess, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPMenu.SuspendLayout()
        CType(Me.GCMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPRole.SuspendLayout()
        CType(Me.GCRole, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRole, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PCBack
        '
        Me.PCBack.Controls.Add(Me.XTCMenuManage)
        Me.PCBack.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PCBack.Location = New System.Drawing.Point(0, 0)
        Me.PCBack.Name = "PCBack"
        Me.PCBack.Size = New System.Drawing.Size(783, 392)
        Me.PCBack.TabIndex = 1
        '
        'XTCMenuManage
        '
        Me.XTCMenuManage.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.XTCMenuManage.Appearance.Options.UseBackColor = True
        Me.XTCMenuManage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCMenuManage.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Right
        Me.XTCMenuManage.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal
        Me.XTCMenuManage.Location = New System.Drawing.Point(2, 2)
        Me.XTCMenuManage.LookAndFeel.SkinName = "Xmas 2008 Blue"
        Me.XTCMenuManage.LookAndFeel.UseDefaultLookAndFeel = False
        Me.XTCMenuManage.Name = "XTCMenuManage"
        Me.XTCMenuManage.SelectedTabPage = Me.XTPForm
        Me.XTCMenuManage.Size = New System.Drawing.Size(779, 388)
        Me.XTCMenuManage.TabIndex = 2
        Me.XTCMenuManage.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPForm, Me.XTPMenu, Me.XTPRole})
        '
        'XTPForm
        '
        Me.XTPForm.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XTPForm.Appearance.Header.Options.UseFont = True
        Me.XTPForm.Controls.Add(Me.XTCForm)
        Me.XTPForm.Image = CType(resources.GetObject("XTPForm.Image"), System.Drawing.Image)
        Me.XTPForm.Name = "XTPForm"
        Me.XTPForm.Size = New System.Drawing.Size(656, 383)
        Me.XTPForm.Text = "Form"
        '
        'XTCForm
        '
        Me.XTCForm.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.XTCForm.Appearance.Options.UseBackColor = True
        Me.XTCForm.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.XTCForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCForm.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left
        Me.XTCForm.Location = New System.Drawing.Point(0, 0)
        Me.XTCForm.LookAndFeel.SkinName = "Seven Classic"
        Me.XTCForm.LookAndFeel.UseDefaultLookAndFeel = False
        Me.XTCForm.Name = "XTCForm"
        Me.XTCForm.SelectedTabPage = Me.XTPFormMain
        Me.XTCForm.Size = New System.Drawing.Size(656, 383)
        Me.XTCForm.TabIndex = 0
        Me.XTCForm.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPFormMain, Me.XTPFormControl})
        '
        'XTPFormMain
        '
        Me.XTPFormMain.Controls.Add(Me.GCForm)
        Me.XTPFormMain.Name = "XTPFormMain"
        Me.XTPFormMain.Size = New System.Drawing.Size(630, 380)
        Me.XTPFormMain.Text = "Form"
        '
        'GCForm
        '
        Me.GCForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCForm.Location = New System.Drawing.Point(0, 0)
        Me.GCForm.MainView = Me.GVForm
        Me.GCForm.Name = "GCForm"
        Me.GCForm.Size = New System.Drawing.Size(630, 380)
        Me.GCForm.TabIndex = 0
        Me.GCForm.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVForm})
        '
        'GVForm
        '
        Me.GVForm.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3})
        Me.GVForm.GridControl = Me.GCForm
        Me.GVForm.Name = "GVForm"
        Me.GVForm.OptionsBehavior.Editable = False
        Me.GVForm.OptionsFind.AlwaysVisible = True
        Me.GVForm.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id Form"
        Me.GridColumn1.FieldName = "id_form"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Form Name"
        Me.GridColumn2.FieldName = "form_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'XTPFormControl
        '
        Me.XTPFormControl.Controls.Add(Me.GCProcess)
        Me.XTPFormControl.Name = "XTPFormControl"
        Me.XTPFormControl.PageEnabled = False
        Me.XTPFormControl.Size = New System.Drawing.Size(630, 380)
        Me.XTPFormControl.Text = "Process"
        '
        'GCProcess
        '
        Me.GCProcess.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProcess.Location = New System.Drawing.Point(0, 0)
        Me.GCProcess.MainView = Me.GVProcess
        Me.GCProcess.Name = "GCProcess"
        Me.GCProcess.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCProcess.Size = New System.Drawing.Size(630, 380)
        Me.GCProcess.TabIndex = 0
        Me.GCProcess.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProcess})
        '
        'GVProcess
        '
        Me.GVProcess.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdFormControl, Me.GridColumnDescriptionFormControl, Me.GridColumnFormControlType, Me.GridColumnIdFormControlType, Me.GridColumnIsView, Me.GridColumnIsViewDB})
        Me.GVProcess.GridControl = Me.GCProcess
        Me.GVProcess.Name = "GVProcess"
        Me.GVProcess.OptionsBehavior.Editable = False
        Me.GVProcess.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdFormControl
        '
        Me.GridColumnIdFormControl.Caption = "Id"
        Me.GridColumnIdFormControl.FieldName = "id_form_control"
        Me.GridColumnIdFormControl.Name = "GridColumnIdFormControl"
        '
        'GridColumnDescriptionFormControl
        '
        Me.GridColumnDescriptionFormControl.Caption = "Function Description"
        Me.GridColumnDescriptionFormControl.FieldName = "description_form_control"
        Me.GridColumnDescriptionFormControl.Name = "GridColumnDescriptionFormControl"
        Me.GridColumnDescriptionFormControl.Visible = True
        Me.GridColumnDescriptionFormControl.VisibleIndex = 0
        '
        'GridColumnFormControlType
        '
        Me.GridColumnFormControlType.Caption = "Type Control"
        Me.GridColumnFormControlType.FieldName = "form_control_type"
        Me.GridColumnFormControlType.Name = "GridColumnFormControlType"
        Me.GridColumnFormControlType.Visible = True
        Me.GridColumnFormControlType.VisibleIndex = 1
        '
        'GridColumnIdFormControlType
        '
        Me.GridColumnIdFormControlType.Caption = "Id Form Control Type"
        Me.GridColumnIdFormControlType.FieldName = "id_form_control_type"
        Me.GridColumnIdFormControlType.Name = "GridColumnIdFormControlType"
        '
        'GridColumnIsView
        '
        Me.GridColumnIsView.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnIsView.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnIsView.Caption = "Required Process"
        Me.GridColumnIsView.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnIsView.FieldName = "is_viewx"
        Me.GridColumnIsView.Name = "GridColumnIsView"
        Me.GridColumnIsView.Visible = True
        Me.GridColumnIsView.VisibleIndex = 2
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'GridColumnIsViewDB
        '
        Me.GridColumnIsViewDB.Caption = "IsView"
        Me.GridColumnIsViewDB.FieldName = "is_view"
        Me.GridColumnIsViewDB.Name = "GridColumnIsViewDB"
        '
        'XTPMenu
        '
        Me.XTPMenu.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XTPMenu.Appearance.Header.Options.UseFont = True
        Me.XTPMenu.Controls.Add(Me.GCMenu)
        Me.XTPMenu.Image = CType(resources.GetObject("XTPMenu.Image"), System.Drawing.Image)
        Me.XTPMenu.Name = "XTPMenu"
        Me.XTPMenu.Size = New System.Drawing.Size(656, 383)
        Me.XTPMenu.Text = "Menu Access"
        '
        'GCMenu
        '
        Me.GCMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMenu.Location = New System.Drawing.Point(0, 0)
        Me.GCMenu.MainView = Me.GVMenu
        Me.GCMenu.Name = "GCMenu"
        Me.GCMenu.Size = New System.Drawing.Size(656, 383)
        Me.GCMenu.TabIndex = 1
        Me.GCMenu.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMenu})
        '
        'GVMenu
        '
        Me.GVMenu.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnDescription, Me.GridColumnMenu, Me.GridColumnIdMenu, Me.GridColumnGroup})
        Me.GVMenu.GridControl = Me.GCMenu
        Me.GVMenu.Name = "GVMenu"
        Me.GVMenu.OptionsBehavior.Editable = False
        Me.GVMenu.OptionsFind.AlwaysVisible = True
        Me.GVMenu.OptionsView.ShowGroupPanel = False
        '
        'GridColumnDescription
        '
        Me.GridColumnDescription.Caption = "Description"
        Me.GridColumnDescription.FieldName = "description_menu_name"
        Me.GridColumnDescription.Name = "GridColumnDescription"
        Me.GridColumnDescription.Visible = True
        Me.GridColumnDescription.VisibleIndex = 0
        '
        'GridColumnMenu
        '
        Me.GridColumnMenu.Caption = "Menu Item Name"
        Me.GridColumnMenu.FieldName = "menu_name"
        Me.GridColumnMenu.Name = "GridColumnMenu"
        Me.GridColumnMenu.Visible = True
        Me.GridColumnMenu.VisibleIndex = 1
        '
        'GridColumnIdMenu
        '
        Me.GridColumnIdMenu.Caption = "Id"
        Me.GridColumnIdMenu.FieldName = "id_menu"
        Me.GridColumnIdMenu.Name = "GridColumnIdMenu"
        '
        'GridColumnGroup
        '
        Me.GridColumnGroup.Caption = "Group"
        Me.GridColumnGroup.FieldName = "group_menu"
        Me.GridColumnGroup.Name = "GridColumnGroup"
        Me.GridColumnGroup.Visible = True
        Me.GridColumnGroup.VisibleIndex = 2
        '
        'XTPRole
        '
        Me.XTPRole.Appearance.Header.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XTPRole.Appearance.Header.Options.UseFont = True
        Me.XTPRole.Controls.Add(Me.GCRole)
        Me.XTPRole.Image = CType(resources.GetObject("XTPRole.Image"), System.Drawing.Image)
        Me.XTPRole.Name = "XTPRole"
        Me.XTPRole.Size = New System.Drawing.Size(656, 383)
        Me.XTPRole.Text = "Role"
        '
        'GCRole
        '
        Me.GCRole.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRole.Location = New System.Drawing.Point(0, 0)
        Me.GCRole.MainView = Me.GVRole
        Me.GCRole.Name = "GCRole"
        Me.GCRole.Size = New System.Drawing.Size(656, 383)
        Me.GCRole.TabIndex = 0
        Me.GCRole.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRole})
        '
        'GVRole
        '
        Me.GVRole.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColumnIdRole, Me.GolumnRoleMaster})
        Me.GVRole.GridControl = Me.GCRole
        Me.GVRole.Name = "GVRole"
        Me.GVRole.OptionsBehavior.Editable = False
        Me.GVRole.OptionsView.ShowGroupPanel = False
        '
        'ColumnIdRole
        '
        Me.ColumnIdRole.Caption = "Id Role"
        Me.ColumnIdRole.FieldName = "id_role"
        Me.ColumnIdRole.Name = "ColumnIdRole"
        '
        'GolumnRoleMaster
        '
        Me.GolumnRoleMaster.Caption = "Role"
        Me.GolumnRoleMaster.FieldName = "role"
        Me.GolumnRoleMaster.Name = "GolumnRoleMaster"
        Me.GolumnRoleMaster.Visible = True
        Me.GolumnRoleMaster.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Note"
        Me.GridColumn3.FieldName = "form_note"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'FormAccess
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(783, 392)
        Me.Controls.Add(Me.PCBack)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAccess"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Access"
        CType(Me.PCBack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCBack.ResumeLayout(False)
        CType(Me.XTCMenuManage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCMenuManage.ResumeLayout(False)
        Me.XTPForm.ResumeLayout(False)
        CType(Me.XTCForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCForm.ResumeLayout(False)
        Me.XTPFormMain.ResumeLayout(False)
        CType(Me.GCForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPFormControl.ResumeLayout(False)
        CType(Me.GCProcess, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProcess, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPMenu.ResumeLayout(False)
        CType(Me.GCMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPRole.ResumeLayout(False)
        CType(Me.GCRole, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRole, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PCBack As DevExpress.XtraEditors.PanelControl
    Friend WithEvents XTCMenuManage As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPRole As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCRole As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRole As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColumnIdRole As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GolumnRoleMaster As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPMenu As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCMenu As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMenu As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMenu As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdMenu As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnGroup As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPForm As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTCForm As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPFormMain As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPFormControl As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCForm As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVForm As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCProcess As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProcess As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdFormControl As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDescriptionFormControl As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFormControlType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdFormControlType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIsView As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnIsViewDB As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
End Class
