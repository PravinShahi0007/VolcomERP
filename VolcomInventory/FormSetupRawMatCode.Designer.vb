<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSetupRawMatCode
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
        Me.GCtrlCodeType = New DevExpress.XtraEditors.GroupControl
        Me.GCCodeType = New DevExpress.XtraGrid.GridControl
        Me.GVCodeType = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColumnIdRawMatCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnRawMatCodeName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnRecCreated = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnRecordModified = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnIsDefault = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.GCtrlDetailCodeType = New DevExpress.XtraEditors.GroupControl
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl
        Me.GCCodeTypeDetail = New DevExpress.XtraGrid.GridControl
        Me.GVCodeTypeDetail = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColumnIdCodeDetail = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnCodeLookup = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnDescriptionCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        CType(Me.GCtrlCodeType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCtrlCodeType.SuspendLayout()
        CType(Me.GCCodeType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVCodeType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCtrlDetailCodeType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCtrlDetailCodeType.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GCCodeTypeDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVCodeTypeDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GCtrlCodeType
        '
        Me.GCtrlCodeType.Controls.Add(Me.GCCodeType)
        Me.GCtrlCodeType.Dock = System.Windows.Forms.DockStyle.Top
        Me.GCtrlCodeType.Location = New System.Drawing.Point(0, 0)
        Me.GCtrlCodeType.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.GCtrlCodeType.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GCtrlCodeType.Name = "GCtrlCodeType"
        Me.GCtrlCodeType.Size = New System.Drawing.Size(576, 235)
        Me.GCtrlCodeType.TabIndex = 0
        Me.GCtrlCodeType.Text = "Code Type"
        '
        'GCCodeType
        '
        Me.GCCodeType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCCodeType.Location = New System.Drawing.Point(2, 22)
        Me.GCCodeType.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GCCodeType.MainView = Me.GVCodeType
        Me.GCCodeType.Name = "GCCodeType"
        Me.GCCodeType.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1, Me.RepositoryItemCheckEdit2})
        Me.GCCodeType.Size = New System.Drawing.Size(572, 211)
        Me.GCCodeType.TabIndex = 0
        Me.GCCodeType.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVCodeType})
        '
        'GVCodeType
        '
        Me.GVCodeType.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColumnIdRawMatCode, Me.ColumnRawMatCodeName, Me.ColumnRecCreated, Me.ColumnRecordModified, Me.ColumnIsDefault, Me.GridColumn1})
        Me.GVCodeType.GridControl = Me.GCCodeType
        Me.GVCodeType.Name = "GVCodeType"
        Me.GVCodeType.OptionsBehavior.Editable = False
        Me.GVCodeType.OptionsView.ShowGroupPanel = False
        '
        'ColumnIdRawMatCode
        '
        Me.ColumnIdRawMatCode.Caption = "Id Raw Mat Code "
        Me.ColumnIdRawMatCode.FieldName = "id_raw_mat_code"
        Me.ColumnIdRawMatCode.Name = "ColumnIdRawMatCode"
        '
        'ColumnRawMatCodeName
        '
        Me.ColumnRawMatCodeName.Caption = "Code Type"
        Me.ColumnRawMatCodeName.FieldName = "raw_mat_code_name"
        Me.ColumnRawMatCodeName.Name = "ColumnRawMatCodeName"
        Me.ColumnRawMatCodeName.Visible = True
        Me.ColumnRawMatCodeName.VisibleIndex = 0
        '
        'ColumnRecCreated
        '
        Me.ColumnRecCreated.Caption = "Record Created"
        Me.ColumnRecCreated.FieldName = "time_created"
        Me.ColumnRecCreated.Name = "ColumnRecCreated"
        Me.ColumnRecCreated.Visible = True
        Me.ColumnRecCreated.VisibleIndex = 1
        '
        'ColumnRecordModified
        '
        Me.ColumnRecordModified.Caption = "Record Modified"
        Me.ColumnRecordModified.FieldName = "time_modified"
        Me.ColumnRecordModified.Name = "ColumnRecordModified"
        Me.ColumnRecordModified.Visible = True
        Me.ColumnRecordModified.VisibleIndex = 2
        '
        'ColumnIsDefault
        '
        Me.ColumnIsDefault.Caption = "Default"
        Me.ColumnIsDefault.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.ColumnIsDefault.FieldName = "is_default"
        Me.ColumnIsDefault.Name = "ColumnIsDefault"
        Me.ColumnIsDefault.Visible = True
        Me.ColumnIsDefault.VisibleIndex = 3
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RepositoryItemCheckEdit1.ValueUnchecked = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Active"
        Me.GridColumn1.ColumnEdit = Me.RepositoryItemCheckEdit2
        Me.GridColumn1.FieldName = "is_active"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 4
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        Me.RepositoryItemCheckEdit2.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RepositoryItemCheckEdit2.ValueUnchecked = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'GCtrlDetailCodeType
        '
        Me.GCtrlDetailCodeType.Controls.Add(Me.PanelControl2)
        Me.GCtrlDetailCodeType.Controls.Add(Me.PanelControl1)
        Me.GCtrlDetailCodeType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCtrlDetailCodeType.Location = New System.Drawing.Point(0, 235)
        Me.GCtrlDetailCodeType.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.GCtrlDetailCodeType.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GCtrlDetailCodeType.Name = "GCtrlDetailCodeType"
        Me.GCtrlDetailCodeType.Size = New System.Drawing.Size(576, 213)
        Me.GCtrlDetailCodeType.TabIndex = 1
        Me.GCtrlDetailCodeType.Text = "Detail Code Type"
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.GCCodeTypeDetail)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl2.Location = New System.Drawing.Point(2, 22)
        Me.PanelControl2.LookAndFeel.SkinName = "Office 2007 Blue"
        Me.PanelControl2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(572, 170)
        Me.PanelControl2.TabIndex = 1
        '
        'GCCodeTypeDetail
        '
        Me.GCCodeTypeDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCCodeTypeDetail.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.GCCodeTypeDetail.Location = New System.Drawing.Point(0, 0)
        Me.GCCodeTypeDetail.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GCCodeTypeDetail.MainView = Me.GVCodeTypeDetail
        Me.GCCodeTypeDetail.Name = "GCCodeTypeDetail"
        Me.GCCodeTypeDetail.Size = New System.Drawing.Size(572, 170)
        Me.GCCodeTypeDetail.TabIndex = 0
        Me.GCCodeTypeDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVCodeTypeDetail})
        '
        'GVCodeTypeDetail
        '
        Me.GVCodeTypeDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColumnIdCodeDetail, Me.ColumnCodeLookup, Me.ColumnDescriptionCode})
        Me.GVCodeTypeDetail.GridControl = Me.GCCodeTypeDetail
        Me.GVCodeTypeDetail.Name = "GVCodeTypeDetail"
        Me.GVCodeTypeDetail.OptionsBehavior.Editable = False
        Me.GVCodeTypeDetail.OptionsView.ShowGroupPanel = False
        '
        'ColumnIdCodeDetail
        '
        Me.ColumnIdCodeDetail.Caption = "Id Code Detail"
        Me.ColumnIdCodeDetail.FieldName = "id_code_detail"
        Me.ColumnIdCodeDetail.Name = "ColumnIdCodeDetail"
        '
        'ColumnCodeLookup
        '
        Me.ColumnCodeLookup.Caption = "Parameter"
        Me.ColumnCodeLookup.FieldName = "code_lookup"
        Me.ColumnCodeLookup.Name = "ColumnCodeLookup"
        Me.ColumnCodeLookup.Visible = True
        Me.ColumnCodeLookup.VisibleIndex = 0
        '
        'ColumnDescriptionCode
        '
        Me.ColumnDescriptionCode.Caption = "Description"
        Me.ColumnDescriptionCode.FieldName = "description_code"
        Me.ColumnDescriptionCode.Name = "ColumnDescriptionCode"
        Me.ColumnDescriptionCode.Visible = True
        Me.ColumnDescriptionCode.VisibleIndex = 1
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(2, 192)
        Me.PanelControl1.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(572, 19)
        Me.PanelControl1.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Dock = System.Windows.Forms.DockStyle.Right
        Me.LabelControl1.Location = New System.Drawing.Point(404, 0)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(168, 14)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Double Click to Set Description"
        '
        'FormSetupRawMatCode
        '
        Me.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(576, 448)
        Me.Controls.Add(Me.GCtrlDetailCodeType)
        Me.Controls.Add(Me.GCtrlCodeType)
        Me.Name = "FormSetupRawMatCode"
        Me.ShowInTaskbar = False
        Me.Text = "Setup Raw Material Code"
        CType(Me.GCtrlCodeType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GCtrlCodeType.ResumeLayout(False)
        CType(Me.GCCodeType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVCodeType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCtrlDetailCodeType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GCtrlDetailCodeType.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GCCodeTypeDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVCodeTypeDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCtrlCodeType As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCtrlDetailCodeType As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCCodeType As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVCodeType As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCCodeTypeDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVCodeTypeDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ColumnIdRawMatCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnRawMatCodeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnRecCreated As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnRecordModified As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnIsDefault As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents ColumnIdCodeDetail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnCodeLookup As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnDescriptionCode As DevExpress.XtraGrid.Columns.GridColumn
End Class
