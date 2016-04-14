<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGProdList
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
        Me.PanelControlNavLineList = New DevExpress.XtraEditors.PanelControl()
        Me.PCNavLineList = New DevExpress.XtraEditors.PanelControl()
        Me.SLESeason = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRange = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.GVProdList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnDesignCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesignDisplayName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProductCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnVendorCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProductOrigin = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDivision = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProdSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEstDelDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEstWHDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnColod = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCProdList = New DevExpress.XtraGrid.GridControl()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        CType(Me.PanelControlNavLineList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNavLineList.SuspendLayout()
        CType(Me.PCNavLineList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCNavLineList.SuspendLayout()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProdList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCProdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControlNavLineList
        '
        Me.PanelControlNavLineList.Controls.Add(Me.PCNavLineList)
        Me.PanelControlNavLineList.Controls.Add(Me.BtnView)
        Me.PanelControlNavLineList.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlNavLineList.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlNavLineList.Name = "PanelControlNavLineList"
        Me.PanelControlNavLineList.Size = New System.Drawing.Size(733, 39)
        Me.PanelControlNavLineList.TabIndex = 1
        '
        'PCNavLineList
        '
        Me.PCNavLineList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCNavLineList.Controls.Add(Me.SLESeason)
        Me.PCNavLineList.Controls.Add(Me.LabelControl4)
        Me.PCNavLineList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PCNavLineList.Location = New System.Drawing.Point(2, 2)
        Me.PCNavLineList.Name = "PCNavLineList"
        Me.PCNavLineList.Size = New System.Drawing.Size(625, 35)
        Me.PCNavLineList.TabIndex = 105
        '
        'SLESeason
        '
        Me.SLESeason.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SLESeason.Location = New System.Drawing.Point(55, 7)
        Me.SLESeason.Name = "SLESeason"
        Me.SLESeason.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLESeason.Properties.Appearance.Options.UseFont = True
        Me.SLESeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESeason.Properties.View = Me.SearchLookUpEdit1View
        Me.SLESeason.Size = New System.Drawing.Size(558, 20)
        Me.SLESeason.TabIndex = 95
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdSeason, Me.GridColumnRange, Me.GridColumnSeason})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdSeason
        '
        Me.GridColumnIdSeason.Caption = "Id Season"
        Me.GridColumnIdSeason.FieldName = "id_season"
        Me.GridColumnIdSeason.Name = "GridColumnIdSeason"
        '
        'GridColumnRange
        '
        Me.GridColumnRange.Caption = "Range"
        Me.GridColumnRange.FieldName = "range"
        Me.GridColumnRange.Name = "GridColumnRange"
        Me.GridColumnRange.Visible = True
        Me.GridColumnRange.VisibleIndex = 0
        '
        'GridColumnSeason
        '
        Me.GridColumnSeason.Caption = "Season"
        Me.GridColumnSeason.FieldName = "season"
        Me.GridColumnSeason.Name = "GridColumnSeason"
        Me.GridColumnSeason.Visible = True
        Me.GridColumnSeason.VisibleIndex = 1
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(14, 10)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl4.TabIndex = 90
        Me.LabelControl4.Text = "Season"
        '
        'BtnView
        '
        Me.BtnView.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnView.ImageIndex = 15
        Me.BtnView.Location = New System.Drawing.Point(627, 2)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(104, 35)
        Me.BtnView.TabIndex = 94
        Me.BtnView.Text = "View List"
        '
        'GVProdList
        '
        Me.GVProdList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnDesignCode, Me.GridColumnDesignDisplayName, Me.GridColumnProductCode, Me.GridColumnVendorCode, Me.GridColumnProductOrigin, Me.GridColumnDivision, Me.GridColumnProdSize, Me.GridColumnEstDelDate, Me.GridColumnEstWHDate, Me.GridColumnColod})
        Me.GVProdList.GridControl = Me.GCProdList
        Me.GVProdList.GroupCount = 1
        Me.GVProdList.Name = "GVProdList"
        Me.GVProdList.OptionsBehavior.Editable = False
        Me.GVProdList.OptionsBehavior.ReadOnly = True
        Me.GVProdList.OptionsView.ShowGroupPanel = False
        Me.GVProdList.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnDesignDisplayName, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnDesignCode
        '
        Me.GridColumnDesignCode.Caption = "Design Code"
        Me.GridColumnDesignCode.FieldName = "design_code"
        Me.GridColumnDesignCode.Name = "GridColumnDesignCode"
        Me.GridColumnDesignCode.Visible = True
        Me.GridColumnDesignCode.VisibleIndex = 0
        '
        'GridColumnDesignDisplayName
        '
        Me.GridColumnDesignDisplayName.Caption = "Design"
        Me.GridColumnDesignDisplayName.FieldName = "design_display_name"
        Me.GridColumnDesignDisplayName.FieldNameSortGroup = "id_design"
        Me.GridColumnDesignDisplayName.Name = "GridColumnDesignDisplayName"
        '
        'GridColumnProductCode
        '
        Me.GridColumnProductCode.Caption = "Product Code"
        Me.GridColumnProductCode.FieldName = "product_full_code"
        Me.GridColumnProductCode.Name = "GridColumnProductCode"
        Me.GridColumnProductCode.Visible = True
        Me.GridColumnProductCode.VisibleIndex = 1
        '
        'GridColumnVendorCode
        '
        Me.GridColumnVendorCode.Caption = "Vendor/UPC Code"
        Me.GridColumnVendorCode.FieldName = "product_ean_code"
        Me.GridColumnVendorCode.Name = "GridColumnVendorCode"
        Me.GridColumnVendorCode.Visible = True
        Me.GridColumnVendorCode.VisibleIndex = 2
        '
        'GridColumnProductOrigin
        '
        Me.GridColumnProductOrigin.Caption = "Product Origin"
        Me.GridColumnProductOrigin.FieldName = "Product Source_display"
        Me.GridColumnProductOrigin.Name = "GridColumnProductOrigin"
        Me.GridColumnProductOrigin.Visible = True
        Me.GridColumnProductOrigin.VisibleIndex = 3
        '
        'GridColumnDivision
        '
        Me.GridColumnDivision.Caption = "Division"
        Me.GridColumnDivision.FieldName = "Product Division_display"
        Me.GridColumnDivision.Name = "GridColumnDivision"
        Me.GridColumnDivision.Visible = True
        Me.GridColumnDivision.VisibleIndex = 4
        '
        'GridColumnProdSize
        '
        Me.GridColumnProdSize.Caption = "Size"
        Me.GridColumnProdSize.FieldName = "Size"
        Me.GridColumnProdSize.Name = "GridColumnProdSize"
        Me.GridColumnProdSize.Visible = True
        Me.GridColumnProdSize.VisibleIndex = 6
        '
        'GridColumnEstDelDate
        '
        Me.GridColumnEstDelDate.Caption = "Est. In Store Date"
        Me.GridColumnEstDelDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnEstDelDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnEstDelDate.FieldName = "delivery_date"
        Me.GridColumnEstDelDate.Name = "GridColumnEstDelDate"
        Me.GridColumnEstDelDate.Visible = True
        Me.GridColumnEstDelDate.VisibleIndex = 7
        '
        'GridColumnEstWHDate
        '
        Me.GridColumnEstWHDate.Caption = "Est. WH. Date"
        Me.GridColumnEstWHDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnEstWHDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnEstWHDate.FieldName = "est_wh_date"
        Me.GridColumnEstWHDate.Name = "GridColumnEstWHDate"
        Me.GridColumnEstWHDate.Visible = True
        Me.GridColumnEstWHDate.VisibleIndex = 8
        '
        'GridColumnColod
        '
        Me.GridColumnColod.Caption = "Color"
        Me.GridColumnColod.FieldName = "Color_display"
        Me.GridColumnColod.Name = "GridColumnColod"
        Me.GridColumnColod.Visible = True
        Me.GridColumnColod.VisibleIndex = 5
        '
        'GCProdList
        '
        Me.GCProdList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProdList.Location = New System.Drawing.Point(0, 39)
        Me.GCProdList.MainView = Me.GVProdList
        Me.GCProdList.Name = "GCProdList"
        Me.GCProdList.Size = New System.Drawing.Size(733, 336)
        Me.GCProdList.TabIndex = 2
        Me.GCProdList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProdList})
        '
        'FormFGProdList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 375)
        Me.Controls.Add(Me.GCProdList)
        Me.Controls.Add(Me.PanelControlNavLineList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormFGProdList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Product List"
        CType(Me.PanelControlNavLineList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNavLineList.ResumeLayout(False)
        CType(Me.PCNavLineList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCNavLineList.ResumeLayout(False)
        Me.PCNavLineList.PerformLayout()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProdList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCProdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControlNavLineList As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PCNavLineList As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLESeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRange As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GVProdList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnDesignCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCProdList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridColumnDesignDisplayName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProductCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnVendorCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProductOrigin As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProdSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEstDelDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEstWHDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDivision As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColod As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
