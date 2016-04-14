<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGSalesOrderReff
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
        Me.GCSOReff = New DevExpress.XtraGrid.GridControl()
        Me.GVSOReff = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdFgSOReff = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDelivery = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDivision = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCategory = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReff = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnComp = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCSOReff, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSOReff, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCSOReff
        '
        Me.GCSOReff.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSOReff.Location = New System.Drawing.Point(0, 0)
        Me.GCSOReff.MainView = Me.GVSOReff
        Me.GCSOReff.Name = "GCSOReff"
        Me.GCSOReff.Size = New System.Drawing.Size(711, 415)
        Me.GCSOReff.TabIndex = 0
        Me.GCSOReff.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSOReff})
        '
        'GVSOReff
        '
        Me.GVSOReff.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdFgSOReff, Me.GridColumnNumber, Me.GridColumnDelivery, Me.GridColumnSeason, Me.GridColumnCreatedDate, Me.GridColumnDivision, Me.GridColumnCategory, Me.GridColumnStatus, Me.GridColumnReff, Me.GridColumnComp})
        Me.GVSOReff.GridControl = Me.GCSOReff
        Me.GVSOReff.GroupCount = 2
        Me.GVSOReff.Name = "GVSOReff"
        Me.GVSOReff.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVSOReff.OptionsView.ShowGroupPanel = False
        Me.GVSOReff.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnSeason, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnDelivery, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnIdFgSOReff, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'GridColumnIdFgSOReff
        '
        Me.GridColumnIdFgSOReff.Caption = "Id Sales Order Reff"
        Me.GridColumnIdFgSOReff.FieldName = "id_fg_so_reff"
        Me.GridColumnIdFgSOReff.Name = "GridColumnIdFgSOReff"
        Me.GridColumnIdFgSOReff.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnNumber
        '
        Me.GridColumnNumber.Caption = "Number"
        Me.GridColumnNumber.FieldName = "fg_so_reff_number"
        Me.GridColumnNumber.Name = "GridColumnNumber"
        Me.GridColumnNumber.Visible = True
        Me.GridColumnNumber.VisibleIndex = 0
        '
        'GridColumnDelivery
        '
        Me.GridColumnDelivery.Caption = "Delivery"
        Me.GridColumnDelivery.FieldName = "delivery"
        Me.GridColumnDelivery.FieldNameSortGroup = "id_delivery"
        Me.GridColumnDelivery.Name = "GridColumnDelivery"
        '
        'GridColumnSeason
        '
        Me.GridColumnSeason.Caption = "Season"
        Me.GridColumnSeason.FieldName = "season"
        Me.GridColumnSeason.FieldNameSortGroup = "id_season"
        Me.GridColumnSeason.Name = "GridColumnSeason"
        '
        'GridColumnCreatedDate
        '
        Me.GridColumnCreatedDate.Caption = "Created Date"
        Me.GridColumnCreatedDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnCreatedDate.FieldName = "fg_so_reff_date"
        Me.GridColumnCreatedDate.Name = "GridColumnCreatedDate"
        Me.GridColumnCreatedDate.Visible = True
        Me.GridColumnCreatedDate.VisibleIndex = 5
        '
        'GridColumnDivision
        '
        Me.GridColumnDivision.Caption = "Division"
        Me.GridColumnDivision.FieldName = "division"
        Me.GridColumnDivision.FieldNameSortGroup = "id_division"
        Me.GridColumnDivision.Name = "GridColumnDivision"
        Me.GridColumnDivision.Visible = True
        Me.GridColumnDivision.VisibleIndex = 3
        '
        'GridColumnCategory
        '
        Me.GridColumnCategory.Caption = "Category"
        Me.GridColumnCategory.FieldName = "rec_note"
        Me.GridColumnCategory.FieldNameSortGroup = "id_rec_note"
        Me.GridColumnCategory.Name = "GridColumnCategory"
        Me.GridColumnCategory.Visible = True
        Me.GridColumnCategory.VisibleIndex = 4
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 6
        '
        'GridColumnReff
        '
        Me.GridColumnReff.Caption = "Reff."
        Me.GridColumnReff.FieldName = "fg_so_reff_fk_number"
        Me.GridColumnReff.Name = "GridColumnReff"
        Me.GridColumnReff.Visible = True
        Me.GridColumnReff.VisibleIndex = 1
        '
        'GridColumnComp
        '
        Me.GridColumnComp.Caption = "Warehouse"
        Me.GridColumnComp.FieldName = "comp_name"
        Me.GridColumnComp.Name = "GridColumnComp"
        Me.GridColumnComp.Visible = True
        Me.GridColumnComp.VisibleIndex = 2
        '
        'FormFGSalesOrderReff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(711, 415)
        Me.Controls.Add(Me.GCSOReff)
        Me.Name = "FormFGSalesOrderReff"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Prepare Order New Product Order"
        CType(Me.GCSOReff, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSOReff, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCSOReff As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSOReff As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdFgSOReff As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDelivery As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDivision As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReff As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnComp As DevExpress.XtraGrid.Columns.GridColumn
End Class
