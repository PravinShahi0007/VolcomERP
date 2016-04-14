<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpFGSalesOrderReff
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SCCSOA = New DevExpress.XtraEditors.SplitContainerControl
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        Me.GCSOReff = New DevExpress.XtraGrid.GridControl
        Me.GVSOReff = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnIdFgSOReff = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDelivery = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCreatedDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDivision = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCategory = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl
        Me.GCDesign = New DevExpress.XtraGrid.GridControl
        Me.GVDesign = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.BtnViewDet = New DevExpress.XtraEditors.SimpleButton
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.BtnChoose = New DevExpress.XtraEditors.SimpleButton
        CType(Me.SCCSOA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SCCSOA.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GCSOReff, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSOReff, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GCDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SCCSOA
        '
        Me.SCCSOA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SCCSOA.Horizontal = False
        Me.SCCSOA.Location = New System.Drawing.Point(0, 0)
        Me.SCCSOA.Name = "SCCSOA"
        Me.SCCSOA.Panel1.Controls.Add(Me.GroupControl1)
        Me.SCCSOA.Panel1.Text = "Panel1"
        Me.SCCSOA.Panel2.Controls.Add(Me.GroupControl2)
        Me.SCCSOA.Panel2.Text = "Panel2"
        Me.SCCSOA.Size = New System.Drawing.Size(882, 466)
        Me.SCCSOA.SplitterPosition = 208
        Me.SCCSOA.TabIndex = 0
        Me.SCCSOA.Text = "SplitContainerControl1"
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.GCSOReff)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(882, 208)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Transaction Number"
        '
        'GCSOReff
        '
        Me.GCSOReff.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSOReff.Location = New System.Drawing.Point(22, 2)
        Me.GCSOReff.MainView = Me.GVSOReff
        Me.GCSOReff.Name = "GCSOReff"
        Me.GCSOReff.Size = New System.Drawing.Size(858, 204)
        Me.GCSOReff.TabIndex = 1
        Me.GCSOReff.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSOReff})
        '
        'GVSOReff
        '
        Me.GVSOReff.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdFgSOReff, Me.GridColumnNumber, Me.GridColumnDelivery, Me.GridColumnSeason, Me.GridColumnCreatedDate, Me.GridColumnDivision, Me.GridColumnCategory, Me.GridColumnStatus})
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
        Me.GridColumnCreatedDate.VisibleIndex = 3
        '
        'GridColumnDivision
        '
        Me.GridColumnDivision.Caption = "Division"
        Me.GridColumnDivision.FieldName = "division"
        Me.GridColumnDivision.FieldNameSortGroup = "id_division"
        Me.GridColumnDivision.Name = "GridColumnDivision"
        Me.GridColumnDivision.Visible = True
        Me.GridColumnDivision.VisibleIndex = 1
        '
        'GridColumnCategory
        '
        Me.GridColumnCategory.Caption = "Category"
        Me.GridColumnCategory.FieldName = "rec_note"
        Me.GridColumnCategory.FieldNameSortGroup = "id_rec_note"
        Me.GridColumnCategory.Name = "GridColumnCategory"
        Me.GridColumnCategory.Visible = True
        Me.GridColumnCategory.VisibleIndex = 2
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 4
        '
        'GroupControl2
        '
        Me.GroupControl2.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl2.Controls.Add(Me.GCDesign)
        Me.GroupControl2.Controls.Add(Me.BtnViewDet)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(882, 253)
        Me.GroupControl2.TabIndex = 1
        Me.GroupControl2.Text = "Detail"
        '
        'GCDesign
        '
        Me.GCDesign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDesign.Location = New System.Drawing.Point(22, 30)
        Me.GCDesign.MainView = Me.GVDesign
        Me.GCDesign.Name = "GCDesign"
        Me.GCDesign.Size = New System.Drawing.Size(858, 221)
        Me.GCDesign.TabIndex = 3
        Me.GCDesign.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDesign})
        '
        'GVDesign
        '
        Me.GVDesign.GridControl = Me.GCDesign
        Me.GVDesign.Name = "GVDesign"
        Me.GVDesign.OptionsView.ColumnAutoWidth = False
        Me.GVDesign.OptionsView.ShowFooter = True
        Me.GVDesign.OptionsView.ShowGroupPanel = False
        '
        'BtnViewDet
        '
        Me.BtnViewDet.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnViewDet.Location = New System.Drawing.Point(22, 2)
        Me.BtnViewDet.Name = "BtnViewDet"
        Me.BtnViewDet.Size = New System.Drawing.Size(858, 28)
        Me.BtnViewDet.TabIndex = 0
        Me.BtnViewDet.Text = "View Detail"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnChoose)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 466)
        Me.PanelControl1.LookAndFeel.SkinName = "Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(882, 37)
        Me.PanelControl1.TabIndex = 1
        '
        'BtnChoose
        '
        Me.BtnChoose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnChoose.Location = New System.Drawing.Point(792, 2)
        Me.BtnChoose.Name = "BtnChoose"
        Me.BtnChoose.Size = New System.Drawing.Size(88, 33)
        Me.BtnChoose.TabIndex = 1
        Me.BtnChoose.Text = "Choose"
        '
        'FormPopUpFGSalesOrderReff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(882, 503)
        Me.Controls.Add(Me.SCCSOA)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormPopUpFGSalesOrderReff"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pop Up Analysis of New Product"
        CType(Me.SCCSOA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SCCSOA.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GCSOReff, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSOReff, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GCDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SCCSOA As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnViewDet As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCDesign As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDesign As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCSOReff As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSOReff As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdFgSOReff As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDelivery As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDivision As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnChoose As DevExpress.XtraEditors.SimpleButton
End Class
