<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSNIRealisasiPop
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
        Me.BApprove = New DevExpress.XtraEditors.SimpleButton()
        Me.GCDetail = New DevExpress.XtraGrid.GridControl()
        Me.GVDetail = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnItem = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQtyDetail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BApprove
        '
        Me.BApprove.Appearance.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BApprove.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BApprove.Appearance.ForeColor = System.Drawing.Color.White
        Me.BApprove.Appearance.Options.UseBackColor = True
        Me.BApprove.Appearance.Options.UseFont = True
        Me.BApprove.Appearance.Options.UseForeColor = True
        Me.BApprove.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BApprove.Location = New System.Drawing.Point(0, 433)
        Me.BApprove.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BApprove.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BApprove.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BApprove.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BApprove.Name = "BApprove"
        Me.BApprove.Size = New System.Drawing.Size(639, 32)
        Me.BApprove.TabIndex = 13
        Me.BApprove.Text = "Pick"
        '
        'GCDetail
        '
        Me.GCDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDetail.Location = New System.Drawing.Point(0, 0)
        Me.GCDetail.MainView = Me.GVDetail
        Me.GCDetail.Name = "GCDetail"
        Me.GCDetail.Size = New System.Drawing.Size(639, 433)
        Me.GCDetail.TabIndex = 18
        Me.GCDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDetail})
        '
        'GVDetail
        '
        Me.GVDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.GridColumn1, Me.GridColumnItem, Me.GridColumnQtyDetail, Me.GridColumn3, Me.GridColumn6, Me.GridColumn8})
        Me.GVDetail.GridControl = Me.GCDetail
        Me.GVDetail.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", Me.GridColumnQtyDetail, "{0:N2}")})
        Me.GVDetail.Name = "GVDetail"
        Me.GVDetail.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVDetail.OptionsView.ShowFooter = True
        Me.GVDetail.OptionsView.ShowGroupPanel = False
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Item Request Number"
        Me.GridColumn2.FieldName = "item_req_number"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 152
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Item Delivery Number"
        Me.GridColumn1.FieldName = "item_del_number"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 1
        Me.GridColumn1.Width = 146
        '
        'GridColumnItem
        '
        Me.GridColumnItem.Caption = "Item"
        Me.GridColumnItem.FieldName = "item_desc"
        Me.GridColumnItem.Name = "GridColumnItem"
        Me.GridColumnItem.OptionsColumn.AllowEdit = False
        Me.GridColumnItem.Visible = True
        Me.GridColumnItem.VisibleIndex = 2
        Me.GridColumnItem.Width = 104
        '
        'GridColumnQtyDetail
        '
        Me.GridColumnQtyDetail.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQtyDetail.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyDetail.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQtyDetail.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyDetail.Caption = "Qty"
        Me.GridColumnQtyDetail.DisplayFormat.FormatString = "N2"
        Me.GridColumnQtyDetail.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyDetail.FieldName = "qty"
        Me.GridColumnQtyDetail.Name = "GridColumnQtyDetail"
        Me.GridColumnQtyDetail.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N2}")})
        Me.GridColumnQtyDetail.Visible = True
        Me.GridColumnQtyDetail.VisibleIndex = 3
        Me.GridColumnQtyDetail.Width = 115
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn3.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn3.Caption = "Biaya per pcs"
        Me.GridColumn3.DisplayFormat.FormatString = "N2"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn3.FieldName = "value"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 4
        Me.GridColumn3.Width = 104
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Remark"
        Me.GridColumn6.FieldName = "remark"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Width = 213
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "UOM"
        Me.GridColumn8.FieldName = "uom"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Width = 39
        '
        'FormSNIRealisasiPop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 465)
        Me.Controls.Add(Me.GCDetail)
        Me.Controls.Add(Me.BApprove)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSNIRealisasiPop"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Reference"
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BApprove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnItem As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyDetail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
End Class
