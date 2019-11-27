<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMailManagePendingInvoice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMailManagePendingInvoice))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnViewDetail = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumnid_comp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumngroup = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumngroup_description = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group_office = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal_qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnamount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_total = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnClose)
        Me.PanelControl1.Controls.Add(Me.BtnViewDetail)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 404)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(687, 44)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnViewDetail
        '
        Me.BtnViewDetail.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnViewDetail.Image = CType(resources.GetObject("BtnViewDetail.Image"), System.Drawing.Image)
        Me.BtnViewDetail.Location = New System.Drawing.Point(578, 2)
        Me.BtnViewDetail.Name = "BtnViewDetail"
        Me.BtnViewDetail.Size = New System.Drawing.Size(107, 40)
        Me.BtnViewDetail.TabIndex = 0
        Me.BtnViewDetail.Text = "View Detail"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(687, 404)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_comp_group, Me.GridColumngroup, Me.GridColumngroup_description, Me.GridColumncomp_group_office, Me.GridColumntotal_qty, Me.GridColumnamount, Me.GridColumnsales_pos_total})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'BtnClose
        '
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(488, 2)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(90, 40)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        '
        'GridColumnid_comp_group
        '
        Me.GridColumnid_comp_group.Caption = "id_comp_group"
        Me.GridColumnid_comp_group.FieldName = "id_comp_group"
        Me.GridColumnid_comp_group.Name = "GridColumnid_comp_group"
        '
        'GridColumngroup
        '
        Me.GridColumngroup.Caption = "Group"
        Me.GridColumngroup.FieldName = "group"
        Me.GridColumngroup.Name = "GridColumngroup"
        Me.GridColumngroup.Visible = True
        Me.GridColumngroup.VisibleIndex = 0
        '
        'GridColumngroup_description
        '
        Me.GridColumngroup_description.Caption = "Group Description"
        Me.GridColumngroup_description.FieldName = "group_description"
        Me.GridColumngroup_description.Name = "GridColumngroup_description"
        Me.GridColumngroup_description.Visible = True
        Me.GridColumngroup_description.VisibleIndex = 1
        '
        'GridColumncomp_group_office
        '
        Me.GridColumncomp_group_office.Caption = "Store HO"
        Me.GridColumncomp_group_office.FieldName = "comp_group_office"
        Me.GridColumncomp_group_office.Name = "GridColumncomp_group_office"
        Me.GridColumncomp_group_office.Visible = True
        Me.GridColumncomp_group_office.VisibleIndex = 2
        '
        'GridColumntotal_qty
        '
        Me.GridColumntotal_qty.Caption = "Total Qty"
        Me.GridColumntotal_qty.DisplayFormat.FormatString = "N0"
        Me.GridColumntotal_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal_qty.FieldName = "total_qty"
        Me.GridColumntotal_qty.Name = "GridColumntotal_qty"
        Me.GridColumntotal_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_qty", "{0:N0}")})
        Me.GridColumntotal_qty.Visible = True
        Me.GridColumntotal_qty.VisibleIndex = 3
        '
        'GridColumnamount
        '
        Me.GridColumnamount.Caption = "Amount Invoice"
        Me.GridColumnamount.DisplayFormat.FormatString = "N2"
        Me.GridColumnamount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnamount.FieldName = "amount"
        Me.GridColumnamount.Name = "GridColumnamount"
        Me.GridColumnamount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N2}")})
        Me.GridColumnamount.Visible = True
        Me.GridColumnamount.VisibleIndex = 5
        '
        'GridColumnsales_pos_total
        '
        Me.GridColumnsales_pos_total.Caption = "Total Sales"
        Me.GridColumnsales_pos_total.DisplayFormat.FormatString = "N2"
        Me.GridColumnsales_pos_total.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnsales_pos_total.FieldName = "sales_pos_total"
        Me.GridColumnsales_pos_total.Name = "GridColumnsales_pos_total"
        Me.GridColumnsales_pos_total.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_total", "{0:N2}")})
        Me.GridColumnsales_pos_total.Visible = True
        Me.GridColumnsales_pos_total.VisibleIndex = 4
        '
        'FormMailManagePendingInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 448)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.LookAndFeel.SkinName = "Office 2007 Pink"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MinimizeBox = False
        Me.Name = "FormMailManagePendingInvoice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pending Invoice (Store Group)"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnViewDetail As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnid_comp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumngroup As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumngroup_description As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_group_office As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal_qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnamount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_pos_total As DevExpress.XtraGrid.Columns.GridColumn
End Class
