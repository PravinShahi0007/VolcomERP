<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGPOPaymentTracking
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
        Me.PCSummary = New DevExpress.XtraEditors.PanelControl()
        Me.SLEFGPO = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BLoad = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.GCRec = New DevExpress.XtraGrid.GridControl()
        Me.BGVRec = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn13 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn12 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQtyRecGrade = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn10 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn14 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn11 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn15 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn16 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        CType(Me.PCSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCSummary.SuspendLayout()
        CType(Me.SLEFGPO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GCRec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BGVRec, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PCSummary
        '
        Me.PCSummary.Controls.Add(Me.BLoad)
        Me.PCSummary.Controls.Add(Me.SLEFGPO)
        Me.PCSummary.Controls.Add(Me.LabelControl2)
        Me.PCSummary.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCSummary.Location = New System.Drawing.Point(0, 0)
        Me.PCSummary.Name = "PCSummary"
        Me.PCSummary.Size = New System.Drawing.Size(859, 46)
        Me.PCSummary.TabIndex = 6
        '
        'SLEFGPO
        '
        Me.SLEFGPO.Location = New System.Drawing.Point(63, 12)
        Me.SLEFGPO.Name = "SLEFGPO"
        Me.SLEFGPO.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEFGPO.Properties.View = Me.GridView1
        Me.SLEFGPO.Size = New System.Drawing.Size(373, 20)
        Me.SLEFGPO.TabIndex = 3
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn26})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(16, 15)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "F. G. PO"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "id_prod_order"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "F.G. PO Number"
        Me.GridColumn2.FieldName = "prod_order_number"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 290
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Design Code"
        Me.GridColumn3.FieldName = "design_code"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 307
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Design"
        Me.GridColumn4.FieldName = "design_display_name"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        Me.GridColumn4.Width = 1035
        '
        'GridColumn26
        '
        Me.GridColumn26.Caption = "View"
        Me.GridColumn26.FieldName = "view_po"
        Me.GridColumn26.Name = "GridColumn26"
        '
        'BLoad
        '
        Me.BLoad.Appearance.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BLoad.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BLoad.Appearance.ForeColor = System.Drawing.Color.White
        Me.BLoad.Appearance.Options.UseBackColor = True
        Me.BLoad.Appearance.Options.UseFont = True
        Me.BLoad.Appearance.Options.UseForeColor = True
        Me.BLoad.Location = New System.Drawing.Point(442, 11)
        Me.BLoad.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BLoad.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BLoad.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BLoad.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BLoad.Name = "BLoad"
        Me.BLoad.Size = New System.Drawing.Size(93, 22)
        Me.BLoad.TabIndex = 22
        Me.BLoad.Text = "Load"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.GCRec)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 46)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(859, 488)
        Me.GroupControl2.TabIndex = 7
        Me.GroupControl2.Text = "Information"
        '
        'GCRec
        '
        Me.GCRec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRec.Location = New System.Drawing.Point(2, 20)
        Me.GCRec.MainView = Me.BGVRec
        Me.GCRec.Name = "GCRec"
        Me.GCRec.Size = New System.Drawing.Size(855, 466)
        Me.GCRec.TabIndex = 0
        Me.GCRec.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BGVRec})
        '
        'BGVRec
        '
        Me.BGVRec.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1, Me.gridBand2, Me.gridBand3})
        Me.BGVRec.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn1, Me.BandedGridColumn2, Me.BandedGridColumn13, Me.BandedGridColumn12, Me.BandedGridColumn3, Me.BandedGridColumn4, Me.BandedGridColumn16, Me.BandedGridColumn15, Me.BandedGridColumn5, Me.BandedGridColumn6, Me.BandedGridColumn7, Me.BandedGridColumnQtyRecGrade, Me.BandedGridColumn8, Me.BandedGridColumn9, Me.BandedGridColumn10, Me.BandedGridColumn14, Me.BandedGridColumn11})
        Me.BGVRec.GridControl = Me.GCRec
        Me.BGVRec.Name = "BGVRec"
        Me.BGVRec.OptionsView.ShowFooter = True
        Me.BGVRec.OptionsView.ShowGroupPanel = False
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.Caption = "ID"
        Me.BandedGridColumn1.FieldName = "id_prod_order"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        '
        'BandedGridColumn13
        '
        Me.BandedGridColumn13.Caption = "Type"
        Me.BandedGridColumn13.FieldName = "type"
        Me.BandedGridColumn13.Name = "BandedGridColumn13"
        Me.BandedGridColumn13.Visible = True
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.Caption = "Number"
        Me.BandedGridColumn2.FieldName = "number"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.Visible = True
        '
        'BandedGridColumn12
        '
        Me.BandedGridColumn12.Caption = "Date"
        Me.BandedGridColumn12.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.BandedGridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumn12.FieldName = "created_date"
        Me.BandedGridColumn12.Name = "BandedGridColumn12"
        Me.BandedGridColumn12.Visible = True
        Me.BandedGridColumn12.Width = 87
        '
        'BandedGridColumn3
        '
        Me.BandedGridColumn3.Caption = "Design Code"
        Me.BandedGridColumn3.FieldName = "design_code"
        Me.BandedGridColumn3.Name = "BandedGridColumn3"
        Me.BandedGridColumn3.Visible = True
        '
        'BandedGridColumn4
        '
        Me.BandedGridColumn4.Caption = "Design"
        Me.BandedGridColumn4.FieldName = "design_display_name"
        Me.BandedGridColumn4.Name = "BandedGridColumn4"
        Me.BandedGridColumn4.Visible = True
        '
        'BandedGridColumn5
        '
        Me.BandedGridColumn5.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn5.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn5.Caption = "Qty PO"
        Me.BandedGridColumn5.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn5.FieldName = "qty_po"
        Me.BandedGridColumn5.Name = "BandedGridColumn5"
        Me.BandedGridColumn5.Visible = True
        '
        'BandedGridColumn6
        '
        Me.BandedGridColumn6.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn6.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn6.Caption = "Qty (Normal)"
        Me.BandedGridColumn6.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn6.FieldName = "qty_rec"
        Me.BandedGridColumn6.Name = "BandedGridColumn6"
        Me.BandedGridColumn6.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rec", "{0:N0}")})
        Me.BandedGridColumn6.Visible = True
        '
        'BandedGridColumn7
        '
        Me.BandedGridColumn7.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn7.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn7.Caption = "Qty (Extra)"
        Me.BandedGridColumn7.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn7.FieldName = "qty_rec_extra"
        Me.BandedGridColumn7.Name = "BandedGridColumn7"
        Me.BandedGridColumn7.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rec_extra", "{0:N0}")})
        Me.BandedGridColumn7.Visible = True
        '
        'BandedGridColumnQtyRecGrade
        '
        Me.BandedGridColumnQtyRecGrade.Caption = "Qty Grade"
        Me.BandedGridColumnQtyRecGrade.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnQtyRecGrade.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnQtyRecGrade.FieldName = "qty_rec_grade"
        Me.BandedGridColumnQtyRecGrade.Name = "BandedGridColumnQtyRecGrade"
        Me.BandedGridColumnQtyRecGrade.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rec_grade", "{0:N0}")})
        Me.BandedGridColumnQtyRecGrade.Visible = True
        '
        'BandedGridColumn8
        '
        Me.BandedGridColumn8.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn8.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn8.Caption = "Qty (Over Memo)"
        Me.BandedGridColumn8.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn8.FieldName = "qty_rec_over"
        Me.BandedGridColumn8.Name = "BandedGridColumn8"
        Me.BandedGridColumn8.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rec_over", "{0:N0}")})
        Me.BandedGridColumn8.Visible = True
        '
        'BandedGridColumn9
        '
        Me.BandedGridColumn9.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn9.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn9.Caption = "Amount Normal"
        Me.BandedGridColumn9.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn9.FieldName = "amount_rec"
        Me.BandedGridColumn9.Name = "BandedGridColumn9"
        Me.BandedGridColumn9.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_rec", "{0:N2}")})
        Me.BandedGridColumn9.Visible = True
        '
        'BandedGridColumn10
        '
        Me.BandedGridColumn10.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn10.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn10.Caption = "Amount Extra"
        Me.BandedGridColumn10.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn10.FieldName = "amount_rec_extra"
        Me.BandedGridColumn10.Name = "BandedGridColumn10"
        Me.BandedGridColumn10.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_rec_extra", "{0:N2}")})
        Me.BandedGridColumn10.Visible = True
        '
        'BandedGridColumn14
        '
        Me.BandedGridColumn14.Caption = "Amount Grade"
        Me.BandedGridColumn14.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn14.FieldName = "amount_rec_grade"
        Me.BandedGridColumn14.Name = "BandedGridColumn14"
        Me.BandedGridColumn14.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_rec_grade", "{0:N2}")})
        Me.BandedGridColumn14.Visible = True
        '
        'BandedGridColumn11
        '
        Me.BandedGridColumn11.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn11.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn11.Caption = "Amount Over Memo"
        Me.BandedGridColumn11.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn11.FieldName = "amount_rec_over"
        Me.BandedGridColumn11.Name = "BandedGridColumn11"
        Me.BandedGridColumn11.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_rec_over", "{0:N2}")})
        Me.BandedGridColumn11.Visible = True
        '
        'BandedGridColumn15
        '
        Me.BandedGridColumn15.Caption = "BBK Payment Date"
        Me.BandedGridColumn15.FieldName = "date_payment"
        Me.BandedGridColumn15.Name = "BandedGridColumn15"
        Me.BandedGridColumn15.Visible = True
        '
        'BandedGridColumn16
        '
        Me.BandedGridColumn16.Caption = "BBK Number"
        Me.BandedGridColumn16.FieldName = "number"
        Me.BandedGridColumn16.Name = "BandedGridColumn16"
        Me.BandedGridColumn16.Visible = True
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "Detail FGPO"
        Me.GridBand1.Columns.Add(Me.BandedGridColumn1)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn13)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn2)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn12)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn3)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn4)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn5)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn16)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn15)
        Me.GridBand1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 612
        '
        'gridBand2
        '
        Me.gridBand2.Caption = "Qty"
        Me.gridBand2.Columns.Add(Me.BandedGridColumn6)
        Me.gridBand2.Columns.Add(Me.BandedGridColumn7)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnQtyRecGrade)
        Me.gridBand2.Columns.Add(Me.BandedGridColumn8)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 1
        Me.gridBand2.Width = 300
        '
        'gridBand3
        '
        Me.gridBand3.Caption = "Amount"
        Me.gridBand3.Columns.Add(Me.BandedGridColumn9)
        Me.gridBand3.Columns.Add(Me.BandedGridColumn10)
        Me.gridBand3.Columns.Add(Me.BandedGridColumn14)
        Me.gridBand3.Columns.Add(Me.BandedGridColumn11)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 2
        Me.gridBand3.Width = 300
        '
        'FormFGPOPaymentTracking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(859, 534)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.PCSummary)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormFGPOPaymentTracking"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Payment Tracking"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PCSummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCSummary.ResumeLayout(False)
        Me.PCSummary.PerformLayout()
        CType(Me.SLEFGPO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GCRec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BGVRec, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PCSummary As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLEFGPO As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BLoad As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCRec As DevExpress.XtraGrid.GridControl
    Friend WithEvents BGVRec As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn13 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn12 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQtyRecGrade As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn10 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn14 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn11 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn16 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn15 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
End Class
