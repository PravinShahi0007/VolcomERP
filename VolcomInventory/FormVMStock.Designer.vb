<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormVMStock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormVMStock))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.DESOHUntil = New DevExpress.XtraEditors.DateEdit()
        Me.BSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEToko = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCStock = New DevExpress.XtraGrid.GridControl()
        Me.GVStock = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPMove = New DevExpress.XtraTab.XtraTabPage()
        Me.GCMoveList = New DevExpress.XtraGrid.GridControl()
        Me.GVMoveList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BMoveAsset = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BRefreshMove = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DESOHUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DESOHUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEToko.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        Me.XTPMove.SuspendLayout()
        CType(Me.GCMoveList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMoveList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LabelControl12)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.DESOHUntil)
        Me.PanelControl1.Controls.Add(Me.BSearch)
        Me.PanelControl1.Controls.Add(Me.SLEToko)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(907, 41)
        Me.PanelControl1.TabIndex = 0
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(11, 14)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(40, 13)
        Me.LabelControl12.TabIndex = 28
        Me.LabelControl12.Text = "Location"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(190, 13)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl2.TabIndex = 26
        Me.LabelControl2.Text = "Until"
        '
        'DESOHUntil
        '
        Me.DESOHUntil.EditValue = Nothing
        Me.DESOHUntil.Location = New System.Drawing.Point(217, 10)
        Me.DESOHUntil.Name = "DESOHUntil"
        Me.DESOHUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DESOHUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DESOHUntil.Properties.DisplayFormat.FormatString = "dd\/MM\/yyyy"
        Me.DESOHUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DESOHUntil.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DESOHUntil.Size = New System.Drawing.Size(172, 20)
        Me.DESOHUntil.TabIndex = 25
        '
        'BSearch
        '
        Me.BSearch.Location = New System.Drawing.Point(395, 9)
        Me.BSearch.Name = "BSearch"
        Me.BSearch.Size = New System.Drawing.Size(75, 23)
        Me.BSearch.TabIndex = 1
        Me.BSearch.Text = "search"
        '
        'SLEToko
        '
        Me.SLEToko.Location = New System.Drawing.Point(57, 10)
        Me.SLEToko.Name = "SLEToko"
        Me.SLEToko.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEToko.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEToko.Size = New System.Drawing.Size(127, 20)
        Me.SLEToko.TabIndex = 0
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.GridColumn5, Me.GridColumn6})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "ID"
        Me.GridColumn2.FieldName = "id_comp"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Kode"
        Me.GridColumn5.FieldName = "comp_number"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 0
        Me.GridColumn5.Width = 318
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Lokasi"
        Me.GridColumn6.FieldName = "comp_name"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 1
        Me.GridColumn6.Width = 1020
        '
        'GCStock
        '
        Me.GCStock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCStock.Location = New System.Drawing.Point(0, 41)
        Me.GCStock.MainView = Me.GVStock
        Me.GCStock.Name = "GCStock"
        Me.GCStock.Size = New System.Drawing.Size(907, 492)
        Me.GCStock.TabIndex = 1
        Me.GCStock.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVStock})
        '
        'GVStock
        '
        Me.GVStock.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn8, Me.GridColumn1, Me.GridColumn3, Me.GridColumn4, Me.GridColumn7})
        Me.GVStock.GridControl = Me.GCStock
        Me.GVStock.Name = "GVStock"
        Me.GVStock.OptionsView.ShowFooter = True
        Me.GVStock.OptionsView.ShowGroupPanel = False
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Location"
        Me.GridColumn8.FieldName = "location"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 0
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Kode Item"
        Me.GridColumn1.FieldName = "id_item"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 1
        Me.GridColumn1.Width = 166
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Item Description"
        Me.GridColumn3.FieldName = "item_desc"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        Me.GridColumn3.Width = 542
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn4.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn4.Caption = "Qty"
        Me.GridColumn4.DisplayFormat.FormatString = "N2"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn4.FieldName = "qty"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N2}")})
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        Me.GridColumn4.Width = 181
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "UOM"
        Me.GridColumn7.FieldName = "uom"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 4
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(913, 561)
        Me.XtraTabControl1.TabIndex = 2
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2, Me.XTPMove})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.GCStock)
        Me.XtraTabPage1.Controls.Add(Me.PanelControl1)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(907, 533)
        Me.XtraTabPage1.Text = "Stock VM"
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(907, 533)
        Me.XtraTabPage2.Text = "Stock Card"
        '
        'XTPMove
        '
        Me.XTPMove.Controls.Add(Me.GCMoveList)
        Me.XTPMove.Controls.Add(Me.BMoveAsset)
        Me.XTPMove.Controls.Add(Me.PanelControl2)
        Me.XTPMove.Name = "XTPMove"
        Me.XTPMove.Size = New System.Drawing.Size(907, 533)
        Me.XTPMove.Text = "Move Asset"
        '
        'GCMoveList
        '
        Me.GCMoveList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMoveList.Location = New System.Drawing.Point(0, 41)
        Me.GCMoveList.MainView = Me.GVMoveList
        Me.GCMoveList.Name = "GCMoveList"
        Me.GCMoveList.Size = New System.Drawing.Size(907, 454)
        Me.GCMoveList.TabIndex = 2
        Me.GCMoveList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMoveList})
        '
        'GVMoveList
        '
        Me.GVMoveList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14})
        Me.GVMoveList.GridControl = Me.GCMoveList
        Me.GVMoveList.Name = "GVMoveList"
        Me.GVMoveList.OptionsView.ShowGroupPanel = False
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "ID"
        Me.GridColumn9.FieldName = "id_vm_item_move"
        Me.GridColumn9.Name = "GridColumn9"
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Number"
        Me.GridColumn10.FieldName = "number"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 0
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Type"
        Me.GridColumn11.FieldName = "type"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 1
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "From"
        Me.GridColumn12.FieldName = "comp_from"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 2
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Status"
        Me.GridColumn13.FieldName = "report_status"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 4
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "To"
        Me.GridColumn14.FieldName = "comp_to"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 3
        '
        'BMoveAsset
        '
        Me.BMoveAsset.Appearance.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BMoveAsset.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BMoveAsset.Appearance.ForeColor = System.Drawing.Color.White
        Me.BMoveAsset.Appearance.Options.UseBackColor = True
        Me.BMoveAsset.Appearance.Options.UseFont = True
        Me.BMoveAsset.Appearance.Options.UseForeColor = True
        Me.BMoveAsset.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BMoveAsset.Location = New System.Drawing.Point(0, 495)
        Me.BMoveAsset.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BMoveAsset.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BMoveAsset.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BMoveAsset.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BMoveAsset.Name = "BMoveAsset"
        Me.BMoveAsset.Size = New System.Drawing.Size(907, 38)
        Me.BMoveAsset.TabIndex = 21
        Me.BMoveAsset.Text = "Asset Manage"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BRefreshMove)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(907, 41)
        Me.PanelControl2.TabIndex = 1
        '
        'BRefreshMove
        '
        Me.BRefreshMove.Dock = System.Windows.Forms.DockStyle.Right
        Me.BRefreshMove.Image = CType(resources.GetObject("BRefreshMove.Image"), System.Drawing.Image)
        Me.BRefreshMove.Location = New System.Drawing.Point(801, 2)
        Me.BRefreshMove.Name = "BRefreshMove"
        Me.BRefreshMove.Size = New System.Drawing.Size(104, 37)
        Me.BRefreshMove.TabIndex = 0
        Me.BRefreshMove.Text = "Refresh"
        '
        'FormVMStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(913, 561)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormVMStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Stock VM"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.DESOHUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DESOHUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEToko.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        Me.XTPMove.ResumeLayout(False)
        CType(Me.GCMoveList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMoveList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCStock As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVStock As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLEToko As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DESOHUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPMove As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCMoveList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMoveList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BMoveAsset As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BRefreshMove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
End Class
