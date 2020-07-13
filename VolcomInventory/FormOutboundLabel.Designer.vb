<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOutboundLabel
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BView = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.GCDOERP = New DevExpress.XtraGrid.GridControl()
        Me.GVDOERP = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn32 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn33 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn34 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn35 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn36 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn37 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnIdDel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncombine_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnreport_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SLEComp = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GCDOERP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDOERP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEComp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SLEComp)
        Me.PanelControl1.Controls.Add(Me.BView)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(789, 48)
        Me.PanelControl1.TabIndex = 1
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.SimpleButton1)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 397)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(789, 48)
        Me.PanelControl2.TabIndex = 2
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(13, 17)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Store"
        '
        'BView
        '
        Me.BView.Location = New System.Drawing.Point(333, 12)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(53, 23)
        Me.BView.TabIndex = 2
        Me.BView.Text = "view"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SimpleButton1.Location = New System.Drawing.Point(2, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(785, 44)
        Me.SimpleButton1.TabIndex = 3
        Me.SimpleButton1.Text = "Create Outbound Label"
        '
        'GCDOERP
        '
        Me.GCDOERP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDOERP.Location = New System.Drawing.Point(0, 48)
        Me.GCDOERP.MainView = Me.GVDOERP
        Me.GCDOERP.Name = "GCDOERP"
        Me.GCDOERP.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCDOERP.Size = New System.Drawing.Size(789, 349)
        Me.GCDOERP.TabIndex = 5
        Me.GCDOERP.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDOERP})
        '
        'GVDOERP
        '
        Me.GVDOERP.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn32, Me.GridColumn33, Me.GridColumn34, Me.GridColumn35, Me.GridColumn36, Me.GridColumn37, Me.GridColumnIdDel, Me.GridColumncombine_number, Me.GridColumnreport_status})
        Me.GVDOERP.GridControl = Me.GCDOERP
        Me.GVDOERP.Name = "GVDOERP"
        Me.GVDOERP.OptionsCustomization.AllowColumnMoving = False
        Me.GVDOERP.OptionsCustomization.AllowColumnResizing = False
        Me.GVDOERP.OptionsCustomization.AllowGroup = False
        Me.GVDOERP.OptionsCustomization.AllowQuickHideColumns = False
        Me.GVDOERP.OptionsCustomization.AllowRowSizing = True
        Me.GVDOERP.OptionsCustomization.CustomizationFormSearchBoxVisible = True
        Me.GVDOERP.OptionsView.ShowGroupPanel = False
        '
        'GridColumn32
        '
        Me.GridColumn32.Caption = "Delivery Order Number"
        Me.GridColumn32.FieldName = "do_no"
        Me.GridColumn32.Name = "GridColumn32"
        Me.GridColumn32.OptionsColumn.AllowEdit = False
        Me.GridColumn32.OptionsColumn.AllowFocus = False
        Me.GridColumn32.Visible = True
        Me.GridColumn32.VisibleIndex = 1
        Me.GridColumn32.Width = 142
        '
        'GridColumn33
        '
        Me.GridColumn33.Caption = "Scan Date"
        Me.GridColumn33.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn33.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn33.FieldName = "scan_date"
        Me.GridColumn33.Name = "GridColumn33"
        Me.GridColumn33.OptionsColumn.AllowEdit = False
        Me.GridColumn33.OptionsColumn.AllowFocus = False
        Me.GridColumn33.Visible = True
        Me.GridColumn33.VisibleIndex = 3
        Me.GridColumn33.Width = 119
        '
        'GridColumn34
        '
        Me.GridColumn34.Caption = "Code"
        Me.GridColumn34.FieldName = "store_number"
        Me.GridColumn34.Name = "GridColumn34"
        Me.GridColumn34.OptionsColumn.AllowEdit = False
        Me.GridColumn34.OptionsColumn.AllowFocus = False
        Me.GridColumn34.Visible = True
        Me.GridColumn34.VisibleIndex = 4
        Me.GridColumn34.Width = 83
        '
        'GridColumn35
        '
        Me.GridColumn35.Caption = "Store Name"
        Me.GridColumn35.FieldName = "store_name"
        Me.GridColumn35.Name = "GridColumn35"
        Me.GridColumn35.OptionsColumn.AllowEdit = False
        Me.GridColumn35.OptionsColumn.AllowFocus = False
        Me.GridColumn35.Visible = True
        Me.GridColumn35.VisibleIndex = 5
        Me.GridColumn35.Width = 201
        '
        'GridColumn36
        '
        Me.GridColumn36.Caption = "Qty"
        Me.GridColumn36.FieldName = "qty"
        Me.GridColumn36.Name = "GridColumn36"
        Me.GridColumn36.OptionsColumn.AllowEdit = False
        Me.GridColumn36.OptionsColumn.AllowFocus = False
        Me.GridColumn36.Visible = True
        Me.GridColumn36.VisibleIndex = 6
        Me.GridColumn36.Width = 86
        '
        'GridColumn37
        '
        Me.GridColumn37.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn37.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn37.Caption = "*"
        Me.GridColumn37.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumn37.FieldName = "is_check"
        Me.GridColumn37.Name = "GridColumn37"
        Me.GridColumn37.Visible = True
        Me.GridColumn37.VisibleIndex = 0
        Me.GridColumn37.Width = 61
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "no"
        '
        'GridColumnIdDel
        '
        Me.GridColumnIdDel.Caption = "ID Del"
        Me.GridColumnIdDel.FieldName = "id_pl_sales_order_del"
        Me.GridColumnIdDel.Name = "GridColumnIdDel"
        '
        'GridColumncombine_number
        '
        Me.GridColumncombine_number.Caption = "Combine No"
        Me.GridColumncombine_number.FieldName = "combine_number"
        Me.GridColumncombine_number.Name = "GridColumncombine_number"
        Me.GridColumncombine_number.OptionsColumn.AllowEdit = False
        Me.GridColumncombine_number.Visible = True
        Me.GridColumncombine_number.VisibleIndex = 2
        '
        'GridColumnreport_status
        '
        Me.GridColumnreport_status.Caption = "Status"
        Me.GridColumnreport_status.FieldName = "report_status"
        Me.GridColumnreport_status.Name = "GridColumnreport_status"
        Me.GridColumnreport_status.Visible = True
        Me.GridColumnreport_status.VisibleIndex = 7
        '
        'SLEComp
        '
        Me.SLEComp.Location = New System.Drawing.Point(45, 14)
        Me.SLEComp.Name = "SLEComp"
        Me.SLEComp.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEComp.Properties.View = Me.GridView3
        Me.SLEComp.Size = New System.Drawing.Size(282, 20)
        Me.SLEComp.TabIndex = 13
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn24, Me.GridColumn29, Me.GridColumn25})
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'GridColumn24
        '
        Me.GridColumn24.Caption = "ID Comp"
        Me.GridColumn24.FieldName = "id_comp"
        Me.GridColumn24.Name = "GridColumn24"
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "Number"
        Me.GridColumn29.FieldName = "comp_number"
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.Visible = True
        Me.GridColumn29.VisibleIndex = 0
        Me.GridColumn29.Width = 269
        '
        'GridColumn25
        '
        Me.GridColumn25.Caption = "Store"
        Me.GridColumn25.FieldName = "comp_name"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.Visible = True
        Me.GridColumn25.VisibleIndex = 1
        Me.GridColumn25.Width = 1363
        '
        'FormOutboundLabel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 445)
        Me.Controls.Add(Me.GCDOERP)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormOutboundLabel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Outbound Label"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GCDOERP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDOERP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEComp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCDOERP As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDOERP As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn32 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn33 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn34 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn35 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn36 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn37 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnIdDel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncombine_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnreport_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLEComp As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
End Class
