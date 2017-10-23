<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOLStoreSummary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormOLStoreSummary))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.SLEComp = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdComp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdCompContact = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnOLStoreOrder = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumnSONumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDelNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReturnOrder = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReturnNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIsPaid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnInvNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCNNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSalesOrder = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAttach = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoAttach = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.RepositoryItemImageEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageEdit()
        Me.RepositoryItemHyperLinkEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepoSLEAttach = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.RepositoryItemSearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEComp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoAttach, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoSLEAttach, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnView)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.DEUntil)
        Me.PanelControl1.Controls.Add(Me.SLEComp)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.DEFrom)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(886, 48)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(579, 14)
        Me.BtnView.LookAndFeel.SkinName = "Blue"
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(75, 20)
        Me.BtnView.TabIndex = 3
        Me.BtnView.Text = "View"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(288, 17)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "From"
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(462, 14)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntil.Size = New System.Drawing.Size(111, 20)
        Me.DEUntil.TabIndex = 2
        '
        'SLEComp
        '
        Me.SLEComp.Location = New System.Drawing.Point(61, 14)
        Me.SLEComp.Name = "SLEComp"
        Me.SLEComp.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEComp.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEComp.Size = New System.Drawing.Size(220, 20)
        Me.SLEComp.TabIndex = 0
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdComp, Me.GridColumnIdCompContact, Me.GridColumnCompCode, Me.GridColumnCompName})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdComp
        '
        Me.GridColumnIdComp.Caption = "Id Comp"
        Me.GridColumnIdComp.FieldName = "id_comp"
        Me.GridColumnIdComp.Name = "GridColumnIdComp"
        '
        'GridColumnIdCompContact
        '
        Me.GridColumnIdCompContact.Caption = "Id Contact"
        Me.GridColumnIdCompContact.FieldName = "id_comp_contact"
        Me.GridColumnIdCompContact.Name = "GridColumnIdCompContact"
        '
        'GridColumnCompCode
        '
        Me.GridColumnCompCode.Caption = "Account"
        Me.GridColumnCompCode.FieldName = "comp_number"
        Me.GridColumnCompCode.Name = "GridColumnCompCode"
        Me.GridColumnCompCode.Visible = True
        Me.GridColumnCompCode.VisibleIndex = 0
        '
        'GridColumnCompName
        '
        Me.GridColumnCompName.Caption = "Account Name"
        Me.GridColumnCompName.FieldName = "comp_name"
        Me.GridColumnCompName.Name = "GridColumnCompName"
        Me.GridColumnCompName.Visible = True
        Me.GridColumnCompName.VisibleIndex = 1
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(435, 17)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl3.TabIndex = 2
        Me.LabelControl3.Text = "Until"
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(318, 14)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFrom.Size = New System.Drawing.Size(111, 20)
        Me.DEFrom.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(20, 17)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Store"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 48)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1, Me.RepositoryItemImageEdit1, Me.RepositoryItemHyperLinkEdit1, Me.RepositoryItemCheckEdit1, Me.RepoSLEAttach, Me.RepoAttach})
        Me.GCData.Size = New System.Drawing.Size(886, 447)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnOLStoreOrder, Me.GridColumnSONumber, Me.GridColumnDelNumber, Me.GridColumnReturnOrder, Me.GridColumnReturnNumber, Me.GridColumnIsPaid, Me.GridColumnInvNumber, Me.GridColumnCNNumber, Me.GridColumnIdSalesOrder, Me.GridColumnAttach})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupedColumns = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnOLStoreOrder
        '
        Me.GridColumnOLStoreOrder.Caption = "OL Store Order#"
        Me.GridColumnOLStoreOrder.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnOLStoreOrder.FieldName = "sales_order_ol_shop_number"
        Me.GridColumnOLStoreOrder.Name = "GridColumnOLStoreOrder"
        Me.GridColumnOLStoreOrder.Visible = True
        Me.GridColumnOLStoreOrder.VisibleIndex = 0
        Me.GridColumnOLStoreOrder.Width = 181
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        Me.RepositoryItemTextEdit1.NullText = "-"
        '
        'GridColumnSONumber
        '
        Me.GridColumnSONumber.Caption = "Sales Order#"
        Me.GridColumnSONumber.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnSONumber.FieldName = "sales_order_number"
        Me.GridColumnSONumber.Name = "GridColumnSONumber"
        Me.GridColumnSONumber.Visible = True
        Me.GridColumnSONumber.VisibleIndex = 1
        Me.GridColumnSONumber.Width = 181
        '
        'GridColumnDelNumber
        '
        Me.GridColumnDelNumber.Caption = "Delivery#"
        Me.GridColumnDelNumber.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnDelNumber.FieldName = "pl_sales_order_del_number"
        Me.GridColumnDelNumber.Name = "GridColumnDelNumber"
        Me.GridColumnDelNumber.Visible = True
        Me.GridColumnDelNumber.VisibleIndex = 2
        Me.GridColumnDelNumber.Width = 181
        '
        'GridColumnReturnOrder
        '
        Me.GridColumnReturnOrder.Caption = "Return Order#"
        Me.GridColumnReturnOrder.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnReturnOrder.FieldName = "sales_return_order_number"
        Me.GridColumnReturnOrder.Name = "GridColumnReturnOrder"
        Me.GridColumnReturnOrder.Visible = True
        Me.GridColumnReturnOrder.VisibleIndex = 3
        Me.GridColumnReturnOrder.Width = 181
        '
        'GridColumnReturnNumber
        '
        Me.GridColumnReturnNumber.Caption = "Return"
        Me.GridColumnReturnNumber.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnReturnNumber.FieldName = "sales_return_number"
        Me.GridColumnReturnNumber.Name = "GridColumnReturnNumber"
        Me.GridColumnReturnNumber.Visible = True
        Me.GridColumnReturnNumber.VisibleIndex = 4
        Me.GridColumnReturnNumber.Width = 181
        '
        'GridColumnIsPaid
        '
        Me.GridColumnIsPaid.Caption = "Is Paid"
        Me.GridColumnIsPaid.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnIsPaid.FieldName = "paid_status"
        Me.GridColumnIsPaid.Name = "GridColumnIsPaid"
        Me.GridColumnIsPaid.Visible = True
        Me.GridColumnIsPaid.VisibleIndex = 5
        Me.GridColumnIsPaid.Width = 114
        '
        'GridColumnInvNumber
        '
        Me.GridColumnInvNumber.Caption = "Invoice#"
        Me.GridColumnInvNumber.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnInvNumber.FieldName = "sales_pos_number"
        Me.GridColumnInvNumber.Name = "GridColumnInvNumber"
        Me.GridColumnInvNumber.Visible = True
        Me.GridColumnInvNumber.VisibleIndex = 6
        Me.GridColumnInvNumber.Width = 201
        '
        'GridColumnCNNumber
        '
        Me.GridColumnCNNumber.Caption = "Credit Note#"
        Me.GridColumnCNNumber.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnCNNumber.FieldName = "sales_pos_cn_number"
        Me.GridColumnCNNumber.Name = "GridColumnCNNumber"
        Me.GridColumnCNNumber.Visible = True
        Me.GridColumnCNNumber.VisibleIndex = 7
        Me.GridColumnCNNumber.Width = 201
        '
        'GridColumnIdSalesOrder
        '
        Me.GridColumnIdSalesOrder.Caption = "id_sales_order"
        Me.GridColumnIdSalesOrder.FieldName = "id_sales_order"
        Me.GridColumnIdSalesOrder.Name = "GridColumnIdSalesOrder"
        '
        'GridColumnAttach
        '
        Me.GridColumnAttach.Caption = "Attachment"
        Me.GridColumnAttach.ColumnEdit = Me.RepoAttach
        Me.GridColumnAttach.FieldName = "report_mark_type"
        Me.GridColumnAttach.Name = "GridColumnAttach"
        Me.GridColumnAttach.Visible = True
        Me.GridColumnAttach.VisibleIndex = 8
        '
        'RepoAttach
        '
        Me.RepoAttach.AutoHeight = False
        Me.RepoAttach.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoAttach.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("report_mark_type", "Id", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("report_mark_type_name", "Transaction")})
        Me.RepoAttach.Name = "RepoAttach"
        '
        'RepositoryItemImageEdit1
        '
        Me.RepositoryItemImageEdit1.AutoHeight = False
        Me.RepositoryItemImageEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageEdit1.Name = "RepositoryItemImageEdit1"
        '
        'RepositoryItemHyperLinkEdit1
        '
        Me.RepositoryItemHyperLinkEdit1.AutoHeight = False
        Me.RepositoryItemHyperLinkEdit1.Name = "RepositoryItemHyperLinkEdit1"
        Me.RepositoryItemHyperLinkEdit1.SingleClick = True
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.PictureChecked = CType(resources.GetObject("RepositoryItemCheckEdit1.PictureChecked"), System.Drawing.Image)
        Me.RepositoryItemCheckEdit1.ReadOnly = True
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'RepoSLEAttach
        '
        Me.RepoSLEAttach.AutoHeight = False
        Me.RepoSLEAttach.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoSLEAttach.Name = "RepoSLEAttach"
        Me.RepoSLEAttach.View = Me.RepositoryItemSearchLookUpEdit1View
        '
        'RepositoryItemSearchLookUpEdit1View
        '
        Me.RepositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.RepositoryItemSearchLookUpEdit1View.Name = "RepositoryItemSearchLookUpEdit1View"
        Me.RepositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RepositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'FormOLStoreSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(886, 495)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormOLStoreSummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Online Store Report"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEComp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoAttach, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoSLEAttach, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEComp As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdComp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdCompContact As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOLStoreOrder As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSONumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDelNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReturnOrder As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReturnNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIsPaid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnInvNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCNNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumnIdSalesOrder As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemHyperLinkEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents RepositoryItemImageEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemImageEdit
    Friend WithEvents GridColumnAttach As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepoAttach As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepoSLEAttach As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
End Class
