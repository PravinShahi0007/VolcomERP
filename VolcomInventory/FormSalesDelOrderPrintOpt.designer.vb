<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesDelOrderPrintOpt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSalesDelOrderPrintOpt))
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.SLESalesOrder = New DevExpress.XtraEditors.SearchLookUpEdit
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnSONumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnStoreNameTo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSOStatus = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSOType = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSODate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.LEStatusSO = New DevExpress.XtraEditors.LookUpEdit
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.SLESeason = New DevExpress.XtraEditors.SearchLookUpEdit
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl
        Me.SLEDelivery = New DevExpress.XtraEditors.SearchLookUpEdit
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.PictureSeason = New DevExpress.XtraEditors.PictureEdit
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.SLESalesOrder.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEStatusSO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEDelivery.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureSeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.BtnCancel)
        Me.PanelControl3.Controls.Add(Me.BtnPrint)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 193)
        Me.PanelControl3.LookAndFeel.SkinName = "Blue"
        Me.PanelControl3.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(468, 44)
        Me.PanelControl3.TabIndex = 186
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(290, 9)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnPrint
        '
        Me.BtnPrint.Location = New System.Drawing.Point(371, 9)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrint.TabIndex = 0
        Me.BtnPrint.Text = "Print"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(185, 125)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(90, 13)
        Me.LabelControl1.TabIndex = 187
        Me.LabelControl1.Text = "Sales Order Status"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(185, 71)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(96, 13)
        Me.LabelControl2.TabIndex = 189
        Me.LabelControl2.Text = "Sales Order Number"
        '
        'SLESalesOrder
        '
        Me.SLESalesOrder.Location = New System.Drawing.Point(185, 90)
        Me.SLESalesOrder.Name = "SLESalesOrder"
        Me.SLESalesOrder.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESalesOrder.Properties.View = Me.SearchLookUpEdit1View
        Me.SLESalesOrder.Size = New System.Drawing.Size(261, 20)
        Me.SLESalesOrder.TabIndex = 190
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnSONumber, Me.GridColumnStoreNameTo, Me.GridColumnSOStatus, Me.GridColumnSOType, Me.GridColumnSODate})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnSONumber
        '
        Me.GridColumnSONumber.Caption = "Number"
        Me.GridColumnSONumber.FieldName = "sales_order_number"
        Me.GridColumnSONumber.Name = "GridColumnSONumber"
        Me.GridColumnSONumber.Visible = True
        Me.GridColumnSONumber.VisibleIndex = 0
        '
        'GridColumnStoreNameTo
        '
        Me.GridColumnStoreNameTo.Caption = "Store"
        Me.GridColumnStoreNameTo.FieldName = "store_name_to"
        Me.GridColumnStoreNameTo.Name = "GridColumnStoreNameTo"
        Me.GridColumnStoreNameTo.Visible = True
        Me.GridColumnStoreNameTo.VisibleIndex = 1
        '
        'GridColumnSOStatus
        '
        Me.GridColumnSOStatus.Caption = "SO Status"
        Me.GridColumnSOStatus.FieldName = "so_status"
        Me.GridColumnSOStatus.Name = "GridColumnSOStatus"
        Me.GridColumnSOStatus.Visible = True
        Me.GridColumnSOStatus.VisibleIndex = 2
        '
        'GridColumnSOType
        '
        Me.GridColumnSOType.Caption = "SO Type"
        Me.GridColumnSOType.FieldName = "so_type"
        Me.GridColumnSOType.Name = "GridColumnSOType"
        Me.GridColumnSOType.Visible = True
        Me.GridColumnSOType.VisibleIndex = 3
        '
        'GridColumnSODate
        '
        Me.GridColumnSODate.Caption = "Created Date"
        Me.GridColumnSODate.FieldName = "sales_order_date"
        Me.GridColumnSODate.Name = "GridColumnSODate"
        Me.GridColumnSODate.Visible = True
        Me.GridColumnSODate.VisibleIndex = 4
        '
        'LEStatusSO
        '
        Me.LEStatusSO.Location = New System.Drawing.Point(185, 144)
        Me.LEStatusSO.Name = "LEStatusSO"
        Me.LEStatusSO.Properties.Appearance.Options.UseTextOptions = True
        Me.LEStatusSO.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEStatusSO.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEStatusSO.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_so_status", "ID SO Staus", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("so_status", "Status")})
        Me.LEStatusSO.Properties.NullText = ""
        Me.LEStatusSO.Properties.ShowFooter = False
        Me.LEStatusSO.Size = New System.Drawing.Size(261, 20)
        Me.LEStatusSO.TabIndex = 8903
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(185, 20)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl3.TabIndex = 8905
        Me.LabelControl3.Text = "Season"
        '
        'SLESeason
        '
        Me.SLESeason.Location = New System.Drawing.Point(185, 39)
        Me.SLESeason.Name = "SLESeason"
        Me.SLESeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESeason.Properties.View = Me.GridView1
        Me.SLESeason.Size = New System.Drawing.Size(145, 20)
        Me.SLESeason.TabIndex = 8904
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Season"
        Me.GridColumn1.FieldName = "season"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Range"
        Me.GridColumn2.FieldName = "range"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Season Start"
        Me.GridColumn3.FieldName = "date_season_start"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Season End"
        Me.GridColumn4.FieldName = "date_season_end"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(336, 20)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl4.TabIndex = 8906
        Me.LabelControl4.Text = "Delivery"
        '
        'SLEDelivery
        '
        Me.SLEDelivery.Location = New System.Drawing.Point(336, 39)
        Me.SLEDelivery.Name = "SLEDelivery"
        Me.SLEDelivery.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEDelivery.Properties.View = Me.GridView2
        Me.SLEDelivery.Size = New System.Drawing.Size(110, 20)
        Me.SLEDelivery.TabIndex = 8907
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn6})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Delivery"
        Me.GridColumn6.FieldName = "delivery"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 0
        '
        'PictureSeason
        '
        Me.PictureSeason.EditValue = CType(resources.GetObject("PictureSeason.EditValue"), Object)
        Me.PictureSeason.Location = New System.Drawing.Point(20, 25)
        Me.PictureSeason.Name = "PictureSeason"
        Me.PictureSeason.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureSeason.Properties.Appearance.Options.UseBackColor = True
        Me.PictureSeason.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureSeason.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PictureSeason.Size = New System.Drawing.Size(141, 144)
        Me.PictureSeason.TabIndex = 8908
        '
        'FormSalesDelOrderPrintOpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(468, 237)
        Me.Controls.Add(Me.PictureSeason)
        Me.Controls.Add(Me.SLEDelivery)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LEStatusSO)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.SLESeason)
        Me.Controls.Add(Me.SLESalesOrder)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.PanelControl3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSalesDelOrderPrintOpt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Print Options"
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.SLESalesOrder.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEStatusSO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEDelivery.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureSeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLESalesOrder As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LEStatusSO As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents GridColumnSONumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStoreNameTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSOStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSOType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSODate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLESeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEDelivery As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PictureSeason As DevExpress.XtraEditors.PictureEdit
End Class
