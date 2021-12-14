<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProposePriceMKDMail
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
        Me.XTCData = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPCheck = New DevExpress.XtraTab.XtraTabPage()
        Me.GCCheck = New DevExpress.XtraGrid.GridControl()
        Me.GVCheck = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.XTPStore = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPInternal = New DevExpress.XtraTab.XtraTabPage()
        Me.GridColumnid_comp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnjum = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnstt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BtnSetupMailStore = New DevExpress.XtraEditors.SimpleButton()
        Me.GCStoreEmail = New DevExpress.XtraGrid.GridControl()
        Me.GVStoreEmail = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnemail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BtnSetupMailInternal = New DevExpress.XtraEditors.SimpleButton()
        Me.GCInternalEmail = New DevExpress.XtraGrid.GridControl()
        Me.GVInternalEmail = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCData.SuspendLayout()
        Me.XTPCheck.SuspendLayout()
        CType(Me.GCCheck, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVCheck, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPStore.SuspendLayout()
        Me.XTPInternal.SuspendLayout()
        CType(Me.GCStoreEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVStoreEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCInternalEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVInternalEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCData
        '
        Me.XTCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCData.Location = New System.Drawing.Point(0, 0)
        Me.XTCData.Name = "XTCData"
        Me.XTCData.SelectedTabPage = Me.XTPCheck
        Me.XTCData.Size = New System.Drawing.Size(584, 350)
        Me.XTCData.TabIndex = 0
        Me.XTCData.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPCheck, Me.XTPStore, Me.XTPInternal})
        '
        'XTPCheck
        '
        Me.XTPCheck.Controls.Add(Me.GCCheck)
        Me.XTPCheck.Name = "XTPCheck"
        Me.XTPCheck.Size = New System.Drawing.Size(578, 322)
        Me.XTPCheck.Text = "Checking Mail Store"
        '
        'GCCheck
        '
        Me.GCCheck.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCCheck.Location = New System.Drawing.Point(0, 0)
        Me.GCCheck.MainView = Me.GVCheck
        Me.GCCheck.Name = "GCCheck"
        Me.GCCheck.Size = New System.Drawing.Size(578, 322)
        Me.GCCheck.TabIndex = 0
        Me.GCCheck.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVCheck})
        '
        'GVCheck
        '
        Me.GVCheck.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_comp_group, Me.GridColumncomp_group, Me.GridColumndescription, Me.GridColumnjum, Me.GridColumnstt})
        Me.GVCheck.GridControl = Me.GCCheck
        Me.GVCheck.Name = "GVCheck"
        Me.GVCheck.OptionsBehavior.Editable = False
        Me.GVCheck.OptionsFind.AlwaysVisible = True
        Me.GVCheck.OptionsView.ColumnAutoWidth = False
        Me.GVCheck.OptionsView.ShowGroupPanel = False
        '
        'XTPStore
        '
        Me.XTPStore.Controls.Add(Me.GCStoreEmail)
        Me.XTPStore.Controls.Add(Me.BtnSetupMailStore)
        Me.XTPStore.Name = "XTPStore"
        Me.XTPStore.Size = New System.Drawing.Size(578, 322)
        Me.XTPStore.Text = "Store Email List"
        '
        'XTPInternal
        '
        Me.XTPInternal.Controls.Add(Me.GCInternalEmail)
        Me.XTPInternal.Controls.Add(Me.BtnSetupMailInternal)
        Me.XTPInternal.Name = "XTPInternal"
        Me.XTPInternal.Size = New System.Drawing.Size(578, 322)
        Me.XTPInternal.Text = "Internal Email List"
        '
        'GridColumnid_comp_group
        '
        Me.GridColumnid_comp_group.Caption = "id_comp_group"
        Me.GridColumnid_comp_group.FieldName = "id_comp_group"
        Me.GridColumnid_comp_group.Name = "GridColumnid_comp_group"
        '
        'GridColumncomp_group
        '
        Me.GridColumncomp_group.Caption = "Store Group"
        Me.GridColumncomp_group.FieldName = "comp_group"
        Me.GridColumncomp_group.Name = "GridColumncomp_group"
        Me.GridColumncomp_group.Visible = True
        Me.GridColumncomp_group.VisibleIndex = 0
        '
        'GridColumndescription
        '
        Me.GridColumndescription.Caption = "Store"
        Me.GridColumndescription.FieldName = "description"
        Me.GridColumndescription.Name = "GridColumndescription"
        Me.GridColumndescription.Visible = True
        Me.GridColumndescription.VisibleIndex = 1
        '
        'GridColumnjum
        '
        Me.GridColumnjum.Caption = "jum"
        Me.GridColumnjum.FieldName = "jum"
        Me.GridColumnjum.Name = "GridColumnjum"
        '
        'GridColumnstt
        '
        Me.GridColumnstt.Caption = "Status"
        Me.GridColumnstt.FieldName = "stt"
        Me.GridColumnstt.Name = "GridColumnstt"
        Me.GridColumnstt.UnboundExpression = "Iif([jum] <= 0, 'Email not found', 'OK')"
        Me.GridColumnstt.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.GridColumnstt.Visible = True
        Me.GridColumnstt.VisibleIndex = 2
        '
        'BtnSetupMailStore
        '
        Me.BtnSetupMailStore.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnSetupMailStore.Location = New System.Drawing.Point(0, 0)
        Me.BtnSetupMailStore.Name = "BtnSetupMailStore"
        Me.BtnSetupMailStore.Size = New System.Drawing.Size(578, 29)
        Me.BtnSetupMailStore.TabIndex = 0
        Me.BtnSetupMailStore.Text = "Setup Mail"
        '
        'GCStoreEmail
        '
        Me.GCStoreEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCStoreEmail.Location = New System.Drawing.Point(0, 29)
        Me.GCStoreEmail.MainView = Me.GVStoreEmail
        Me.GCStoreEmail.Name = "GCStoreEmail"
        Me.GCStoreEmail.Size = New System.Drawing.Size(578, 293)
        Me.GCStoreEmail.TabIndex = 1
        Me.GCStoreEmail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVStoreEmail})
        '
        'GVStoreEmail
        '
        Me.GVStoreEmail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumnemail})
        Me.GVStoreEmail.GridControl = Me.GCStoreEmail
        Me.GVStoreEmail.GroupCount = 1
        Me.GVStoreEmail.Name = "GVStoreEmail"
        Me.GVStoreEmail.OptionsBehavior.Editable = False
        Me.GVStoreEmail.OptionsFind.AlwaysVisible = True
        Me.GVStoreEmail.OptionsView.ColumnAutoWidth = False
        Me.GVStoreEmail.OptionsView.ShowGroupedColumns = True
        Me.GVStoreEmail.OptionsView.ShowGroupPanel = False
        Me.GVStoreEmail.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn3, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "id_comp_group"
        Me.GridColumn1.FieldName = "id_comp_group"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Store Group"
        Me.GridColumn2.FieldName = "comp_group"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Store"
        Me.GridColumn3.FieldName = "comp_group_desc"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Type"
        Me.GridColumn4.FieldName = "type"
        Me.GridColumn4.Name = "GridColumn4"
        '
        'GridColumnemail
        '
        Me.GridColumnemail.Caption = "Email"
        Me.GridColumnemail.FieldName = "email"
        Me.GridColumnemail.Name = "GridColumnemail"
        Me.GridColumnemail.UnboundExpression = "Iif([jum] <= 0, 'Email not found', 'OK')"
        Me.GridColumnemail.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.GridColumnemail.Visible = True
        Me.GridColumnemail.VisibleIndex = 2
        '
        'BtnSetupMailInternal
        '
        Me.BtnSetupMailInternal.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnSetupMailInternal.Location = New System.Drawing.Point(0, 0)
        Me.BtnSetupMailInternal.Name = "BtnSetupMailInternal"
        Me.BtnSetupMailInternal.Size = New System.Drawing.Size(578, 29)
        Me.BtnSetupMailInternal.TabIndex = 1
        Me.BtnSetupMailInternal.Text = "Setup Mail"
        '
        'GCInternalEmail
        '
        Me.GCInternalEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCInternalEmail.Location = New System.Drawing.Point(0, 29)
        Me.GCInternalEmail.MainView = Me.GVInternalEmail
        Me.GCInternalEmail.Name = "GCInternalEmail"
        Me.GCInternalEmail.Size = New System.Drawing.Size(578, 293)
        Me.GCInternalEmail.TabIndex = 2
        Me.GCInternalEmail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVInternalEmail})
        '
        'GVInternalEmail
        '
        Me.GVInternalEmail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn5, Me.GridColumn6, Me.GridColumn7})
        Me.GVInternalEmail.GridControl = Me.GCInternalEmail
        Me.GVInternalEmail.Name = "GVInternalEmail"
        Me.GVInternalEmail.OptionsBehavior.Editable = False
        Me.GVInternalEmail.OptionsFind.AlwaysVisible = True
        Me.GVInternalEmail.OptionsView.ColumnAutoWidth = False
        Me.GVInternalEmail.OptionsView.ShowGroupedColumns = True
        Me.GVInternalEmail.OptionsView.ShowGroupPanel = False
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Type"
        Me.GridColumn5.FieldName = "type"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 0
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Email"
        Me.GridColumn6.FieldName = "email"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 1
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Name"
        Me.GridColumn7.FieldName = "name"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 2
        '
        'FormProposePriceMKDMail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 350)
        Me.Controls.Add(Me.XTCData)
        Me.MinimizeBox = False
        Me.Name = "FormProposePriceMKDMail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mail Setup"
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCData.ResumeLayout(False)
        Me.XTPCheck.ResumeLayout(False)
        CType(Me.GCCheck, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVCheck, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPStore.ResumeLayout(False)
        Me.XTPInternal.ResumeLayout(False)
        CType(Me.GCStoreEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVStoreEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCInternalEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVInternalEmail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCData As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPCheck As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCCheck As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVCheck As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents XTPStore As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPInternal As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridColumnid_comp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnjum As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnstt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnSetupMailStore As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCStoreEmail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVStoreEmail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnemail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnSetupMailInternal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCInternalEmail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVInternalEmail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
End Class
