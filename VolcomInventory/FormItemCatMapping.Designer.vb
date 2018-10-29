<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormItemCatMapping
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormItemCatMapping))
        Me.XTCMapping = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPMapping = New DevExpress.XtraTab.XtraTabPage()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.LECat = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LEDeptSum = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.GCMapping = New DevExpress.XtraGrid.GridControl()
        Me.GVMapping = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.BandedGridColumnItemCat = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnDept = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnId = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnExp = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnExpDesc = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnInvAcc = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnInvDesc = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.XTPPropose = New DevExpress.XtraTab.XtraTabPage()
        Me.GCPropose = New DevExpress.XtraGrid.GridControl()
        Me.GVPropose = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        CType(Me.XTCMapping, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCMapping.SuspendLayout()
        Me.XTPMapping.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LECat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEDeptSum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCMapping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMapping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPPropose.SuspendLayout()
        CType(Me.GCPropose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPropose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCMapping
        '
        Me.XTCMapping.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCMapping.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCMapping.Location = New System.Drawing.Point(0, 0)
        Me.XTCMapping.Name = "XTCMapping"
        Me.XTCMapping.SelectedTabPage = Me.XTPMapping
        Me.XTCMapping.Size = New System.Drawing.Size(946, 602)
        Me.XTCMapping.TabIndex = 0
        Me.XTCMapping.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPMapping, Me.XTPPropose})
        '
        'XTPMapping
        '
        Me.XTPMapping.Controls.Add(Me.PanelControl1)
        Me.XTPMapping.Controls.Add(Me.GCMapping)
        Me.XTPMapping.Name = "XTPMapping"
        Me.XTPMapping.Size = New System.Drawing.Size(940, 574)
        Me.XTPMapping.Text = "Mapping"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnView)
        Me.PanelControl1.Controls.Add(Me.LECat)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.LEDeptSum)
        Me.PanelControl1.Controls.Add(Me.LabelControl6)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(940, 48)
        Me.PanelControl1.TabIndex = 3
        '
        'BtnView
        '
        Me.BtnView.Image = CType(resources.GetObject("BtnView.Image"), System.Drawing.Image)
        Me.BtnView.Location = New System.Drawing.Point(496, 12)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(75, 23)
        Me.BtnView.TabIndex = 20
        Me.BtnView.Text = "View"
        '
        'LECat
        '
        Me.LECat.Location = New System.Drawing.Point(315, 14)
        Me.LECat.Name = "LECat"
        Me.LECat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LECat.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_item_cat", "Id", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("item_cat", "Category")})
        Me.LECat.Size = New System.Drawing.Size(175, 20)
        Me.LECat.TabIndex = 19
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(264, 17)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl1.TabIndex = 18
        Me.LabelControl1.Text = "Category"
        '
        'LEDeptSum
        '
        Me.LEDeptSum.Location = New System.Drawing.Point(83, 14)
        Me.LEDeptSum.Name = "LEDeptSum"
        Me.LEDeptSum.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEDeptSum.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_departement", "Id Departement", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("departement", "Departemen")})
        Me.LEDeptSum.Size = New System.Drawing.Size(175, 20)
        Me.LEDeptSum.TabIndex = 17
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(14, 17)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl6.TabIndex = 16
        Me.LabelControl6.Text = "Departement"
        '
        'GCMapping
        '
        Me.GCMapping.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMapping.Location = New System.Drawing.Point(0, 0)
        Me.GCMapping.MainView = Me.GVMapping
        Me.GCMapping.Name = "GCMapping"
        Me.GCMapping.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCMapping.Size = New System.Drawing.Size(940, 574)
        Me.GCMapping.TabIndex = 2
        Me.GCMapping.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMapping})
        '
        'GVMapping
        '
        Me.GVMapping.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand2, Me.GridBand1, Me.gridBand3, Me.gridBand4})
        Me.GVMapping.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GridColumnId, Me.GridColumnExp, Me.BandedGridColumnExpDesc, Me.BandedGridColumnInvAcc, Me.BandedGridColumnInvDesc, Me.BandedGridColumnDept, Me.BandedGridColumnItemCat, Me.BandedGridColumn1, Me.BandedGridColumn2})
        Me.GVMapping.GridControl = Me.GCMapping
        Me.GVMapping.GroupCount = 1
        Me.GVMapping.Name = "GVMapping"
        Me.GVMapping.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVMapping.OptionsBehavior.Editable = False
        Me.GVMapping.OptionsFind.AlwaysVisible = True
        Me.GVMapping.OptionsView.ShowGroupPanel = False
        Me.GVMapping.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumnDept, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'BandedGridColumnItemCat
        '
        Me.BandedGridColumnItemCat.Caption = "Category"
        Me.BandedGridColumnItemCat.FieldName = "item_cat"
        Me.BandedGridColumnItemCat.Name = "BandedGridColumnItemCat"
        Me.BandedGridColumnItemCat.Visible = True
        '
        'BandedGridColumnDept
        '
        Me.BandedGridColumnDept.Caption = "Departement"
        Me.BandedGridColumnDept.FieldName = "departement"
        Me.BandedGridColumnDept.Name = "BandedGridColumnDept"
        Me.BandedGridColumnDept.Visible = True
        '
        'GridColumnId
        '
        Me.GridColumnId.Caption = "Id"
        Me.GridColumnId.FieldName = "id_item_coa"
        Me.GridColumnId.Name = "GridColumnId"
        '
        'GridColumnExp
        '
        Me.GridColumnExp.Caption = "Account"
        Me.GridColumnExp.FieldName = "exp_acc"
        Me.GridColumnExp.Name = "GridColumnExp"
        Me.GridColumnExp.Visible = True
        '
        'BandedGridColumnExpDesc
        '
        Me.BandedGridColumnExpDesc.Caption = "Description"
        Me.BandedGridColumnExpDesc.FieldName = "exp_desc"
        Me.BandedGridColumnExpDesc.Name = "BandedGridColumnExpDesc"
        Me.BandedGridColumnExpDesc.Visible = True
        '
        'BandedGridColumnInvAcc
        '
        Me.BandedGridColumnInvAcc.Caption = "Account"
        Me.BandedGridColumnInvAcc.FieldName = "inv_acc"
        Me.BandedGridColumnInvAcc.Name = "BandedGridColumnInvAcc"
        Me.BandedGridColumnInvAcc.Visible = True
        '
        'BandedGridColumnInvDesc
        '
        Me.BandedGridColumnInvDesc.Caption = "Description"
        Me.BandedGridColumnInvDesc.FieldName = "inv_desc"
        Me.BandedGridColumnInvDesc.Name = "BandedGridColumnInvDesc"
        Me.BandedGridColumnInvDesc.Visible = True
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.Caption = "Request"
        Me.BandedGridColumn1.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.BandedGridColumn1.FieldName = "is_request_v"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.Visible = True
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.Caption = "Expense"
        Me.BandedGridColumn2.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.BandedGridColumn2.FieldName = "is_expense_v"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.Visible = True
        '
        'XTPPropose
        '
        Me.XTPPropose.Controls.Add(Me.GCPropose)
        Me.XTPPropose.Name = "XTPPropose"
        Me.XTPPropose.Size = New System.Drawing.Size(940, 574)
        Me.XTPPropose.Text = "Propose New Mapping"
        '
        'GCPropose
        '
        Me.GCPropose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPropose.Location = New System.Drawing.Point(0, 0)
        Me.GCPropose.MainView = Me.GVPropose
        Me.GCPropose.Name = "GCPropose"
        Me.GCPropose.Size = New System.Drawing.Size(940, 574)
        Me.GCPropose.TabIndex = 1
        Me.GCPropose.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPropose})
        '
        'GVPropose
        '
        Me.GVPropose.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5})
        Me.GVPropose.GridControl = Me.GCPropose
        Me.GVPropose.Name = "GVPropose"
        Me.GVPropose.OptionsBehavior.Editable = False
        Me.GVPropose.OptionsFind.AlwaysVisible = True
        Me.GVPropose.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id"
        Me.GridColumn1.FieldName = "id_item_cat_propose"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Number"
        Me.GridColumn2.FieldName = "number"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Created Date"
        Me.GridColumn3.DisplayFormat.FormatString = "dd MMMM yyyy \/ HH:mm"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn3.FieldName = "created_date"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Note"
        Me.GridColumn4.FieldName = "note"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Status"
        Me.GridColumn5.FieldName = "report_status"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        '
        'gridBand2
        '
        Me.gridBand2.Columns.Add(Me.BandedGridColumnItemCat)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnDept)
        Me.gridBand2.Columns.Add(Me.GridColumnId)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 0
        Me.gridBand2.Width = 150
        '
        'GridBand1
        '
        Me.GridBand1.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridBand1.AppearanceHeader.Options.UseFont = True
        Me.GridBand1.Caption = "Expense Account"
        Me.GridBand1.Columns.Add(Me.GridColumnExp)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnExpDesc)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 1
        Me.GridBand1.Width = 150
        '
        'gridBand3
        '
        Me.gridBand3.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridBand3.AppearanceHeader.Options.UseFont = True
        Me.gridBand3.Caption = "Inventory Account"
        Me.gridBand3.Columns.Add(Me.BandedGridColumnInvAcc)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnInvDesc)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.Visible = False
        Me.gridBand3.VisibleIndex = -1
        Me.gridBand3.Width = 150
        '
        'gridBand4
        '
        Me.gridBand4.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridBand4.AppearanceHeader.Options.UseFont = True
        Me.gridBand4.Caption = "Access Menu"
        Me.gridBand4.Columns.Add(Me.BandedGridColumn1)
        Me.gridBand4.Columns.Add(Me.BandedGridColumn2)
        Me.gridBand4.Name = "gridBand4"
        Me.gridBand4.VisibleIndex = 2
        Me.gridBand4.Width = 150
        '
        'FormItemCatMapping
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(946, 602)
        Me.Controls.Add(Me.XTCMapping)
        Me.MinimizeBox = False
        Me.Name = "FormItemCatMapping"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mapping Category"
        CType(Me.XTCMapping, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCMapping.ResumeLayout(False)
        Me.XTPMapping.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.LECat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEDeptSum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCMapping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMapping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPPropose.ResumeLayout(False)
        CType(Me.GCPropose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPropose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCMapping As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPMapping As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPPropose As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCMapping As DevExpress.XtraGrid.GridControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LEDeptSum As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LECat As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCPropose As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPropose As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GVMapping As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents BandedGridColumnDept As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnId As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnExp As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnExpDesc As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnInvAcc As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnInvDesc As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnItemCat As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
End Class
