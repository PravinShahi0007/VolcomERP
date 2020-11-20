<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormScanReturnBAP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormScanReturnBAP))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.DEStartBAP = New DevExpress.XtraEditors.DateEdit()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.CheckEdit1 = New DevExpress.XtraEditors.CheckEdit()
        Me.CheckEdit2 = New DevExpress.XtraEditors.CheckEdit()
        Me.CheckEdit3 = New DevExpress.XtraEditors.CheckEdit()
        Me.CheckEdit4 = New DevExpress.XtraEditors.CheckEdit()
        Me.TextEdit2 = New DevExpress.XtraEditors.TextEdit()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.BDeleteScan = New DevExpress.XtraEditors.SimpleButton()
        Me.BInputManual = New DevExpress.XtraEditors.SimpleButton()
        Me.GCListProduct = New DevExpress.XtraGrid.GridControl()
        Me.GVListProduct = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStartBAP.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStartBAP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.GCListProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.DEStartBAP)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.TextEdit1)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(932, 48)
        Me.PanelControl1.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 16)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "BAP Number"
        '
        'TextEdit1
        '
        Me.TextEdit1.EditValue = "[Atuo Generate]"
        Me.TextEdit1.Location = New System.Drawing.Point(97, 13)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Size = New System.Drawing.Size(462, 20)
        Me.TextEdit1.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(565, 16)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "BAP Date"
        '
        'DEStartBAP
        '
        Me.DEStartBAP.EditValue = Nothing
        Me.DEStartBAP.Location = New System.Drawing.Point(616, 13)
        Me.DEStartBAP.Name = "DEStartBAP"
        Me.DEStartBAP.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStartBAP.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStartBAP.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEStartBAP.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStartBAP.Properties.EditFormat.FormatString = "dd MMMM yyyy"
        Me.DEStartBAP.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStartBAP.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DEStartBAP.Size = New System.Drawing.Size(291, 20)
        Me.DEStartBAP.TabIndex = 8921
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BPrint)
        Me.PanelControl2.Controls.Add(Me.BClose)
        Me.PanelControl2.Controls.Add(Me.BSave)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 542)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(932, 45)
        Me.PanelControl2.TabIndex = 2
        '
        'BClose
        '
        Me.BClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BClose.Image = CType(resources.GetObject("BClose.Image"), System.Drawing.Image)
        Me.BClose.Location = New System.Drawing.Point(712, 2)
        Me.BClose.Name = "BClose"
        Me.BClose.Size = New System.Drawing.Size(109, 41)
        Me.BClose.TabIndex = 5
        Me.BClose.Text = "Close"
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.Image = CType(resources.GetObject("BSave.Image"), System.Drawing.Image)
        Me.BSave.Location = New System.Drawing.Point(821, 2)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(109, 41)
        Me.BSave.TabIndex = 3
        Me.BSave.Text = "Save"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.TextEdit2)
        Me.PanelControl3.Controls.Add(Me.CheckEdit4)
        Me.PanelControl3.Controls.Add(Me.CheckEdit3)
        Me.PanelControl3.Controls.Add(Me.CheckEdit2)
        Me.PanelControl3.Controls.Add(Me.CheckEdit1)
        Me.PanelControl3.Controls.Add(Me.LabelControl3)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(0, 48)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(932, 50)
        Me.PanelControl3.TabIndex = 3
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 17)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(68, 13)
        Me.LabelControl3.TabIndex = 1
        Me.LabelControl3.Text = "BOX Condition"
        '
        'CheckEdit1
        '
        Me.CheckEdit1.Location = New System.Drawing.Point(97, 14)
        Me.CheckEdit1.Name = "CheckEdit1"
        Me.CheckEdit1.Properties.Caption = "Berlubang / robek"
        Me.CheckEdit1.Size = New System.Drawing.Size(120, 19)
        Me.CheckEdit1.TabIndex = 2
        '
        'CheckEdit2
        '
        Me.CheckEdit2.Location = New System.Drawing.Point(223, 14)
        Me.CheckEdit2.Name = "CheckEdit2"
        Me.CheckEdit2.Properties.Caption = "Seal / Lakban rusak"
        Me.CheckEdit2.Size = New System.Drawing.Size(120, 19)
        Me.CheckEdit2.TabIndex = 3
        '
        'CheckEdit3
        '
        Me.CheckEdit3.Location = New System.Drawing.Point(349, 14)
        Me.CheckEdit3.Name = "CheckEdit3"
        Me.CheckEdit3.Properties.Caption = "Basah / Kotor"
        Me.CheckEdit3.Size = New System.Drawing.Size(120, 19)
        Me.CheckEdit3.TabIndex = 4
        '
        'CheckEdit4
        '
        Me.CheckEdit4.Location = New System.Drawing.Point(453, 14)
        Me.CheckEdit4.Name = "CheckEdit4"
        Me.CheckEdit4.Properties.Caption = "Alasan lainnya"
        Me.CheckEdit4.Size = New System.Drawing.Size(92, 19)
        Me.CheckEdit4.TabIndex = 5
        '
        'TextEdit2
        '
        Me.TextEdit2.Location = New System.Drawing.Point(551, 14)
        Me.TextEdit2.Name = "TextEdit2"
        Me.TextEdit2.Size = New System.Drawing.Size(356, 20)
        Me.TextEdit2.TabIndex = 6
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.BDeleteScan)
        Me.PanelControl4.Controls.Add(Me.BInputManual)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl4.Location = New System.Drawing.Point(0, 98)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(932, 44)
        Me.PanelControl4.TabIndex = 4
        '
        'BDeleteScan
        '
        Me.BDeleteScan.Dock = System.Windows.Forms.DockStyle.Right
        Me.BDeleteScan.Image = CType(resources.GetObject("BDeleteScan.Image"), System.Drawing.Image)
        Me.BDeleteScan.Location = New System.Drawing.Point(728, 2)
        Me.BDeleteScan.Name = "BDeleteScan"
        Me.BDeleteScan.Size = New System.Drawing.Size(93, 40)
        Me.BDeleteScan.TabIndex = 7
        Me.BDeleteScan.Text = "Delete"
        '
        'BInputManual
        '
        Me.BInputManual.Dock = System.Windows.Forms.DockStyle.Right
        Me.BInputManual.Image = CType(resources.GetObject("BInputManual.Image"), System.Drawing.Image)
        Me.BInputManual.Location = New System.Drawing.Point(821, 2)
        Me.BInputManual.Name = "BInputManual"
        Me.BInputManual.Size = New System.Drawing.Size(109, 40)
        Me.BInputManual.TabIndex = 6
        Me.BInputManual.Text = "Add"
        '
        'GCListProduct
        '
        Me.GCListProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListProduct.Location = New System.Drawing.Point(0, 142)
        Me.GCListProduct.MainView = Me.GVListProduct
        Me.GCListProduct.Name = "GCListProduct"
        Me.GCListProduct.Size = New System.Drawing.Size(932, 400)
        Me.GCListProduct.TabIndex = 5
        Me.GCListProduct.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListProduct})
        '
        'GVListProduct
        '
        Me.GVListProduct.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn8, Me.GridColumn9, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn7, Me.GridColumn6})
        Me.GVListProduct.GridControl = Me.GCListProduct
        Me.GVListProduct.Name = "GVListProduct"
        Me.GVListProduct.OptionsBehavior.Editable = False
        Me.GVListProduct.OptionsBehavior.ReadOnly = True
        Me.GVListProduct.OptionsView.ShowFooter = True
        Me.GVListProduct.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "id_det"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "ID Return Note"
        Me.GridColumn2.FieldName = "id_return_note"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Code"
        Me.GridColumn3.FieldName = "product_full_code"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        Me.GridColumn3.Width = 200
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Product"
        Me.GridColumn4.FieldName = "product_display_name"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "product_display_name", "Total Qty Scan")})
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        Me.GridColumn4.Width = 278
        '
        'GridColumn5
        '
        Me.GridColumn5.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn5.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn5.Caption = "Size"
        Me.GridColumn5.FieldName = "size"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "size", "{0}")})
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 4
        Me.GridColumn5.Width = 69
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Note"
        Me.GridColumn6.FieldName = "notes"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 6
        Me.GridColumn6.Width = 256
        '
        'BPrint
        '
        Me.BPrint.Dock = System.Windows.Forms.DockStyle.Left
        Me.BPrint.Image = CType(resources.GetObject("BPrint.Image"), System.Drawing.Image)
        Me.BPrint.Location = New System.Drawing.Point(2, 2)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(109, 41)
        Me.BPrint.TabIndex = 6
        Me.BPrint.Text = "Print"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Qty"
        Me.GridColumn7.FieldName = "qty"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 5
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Surat jalan"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 0
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "List Toko"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 1
        '
        'FormScanReturnBAP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(932, 587)
        Me.Controls.Add(Me.GCListProduct)
        Me.Controls.Add(Me.PanelControl4)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormScanReturnBAP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Scan Return BAP"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStartBAP.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStartBAP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        CType(Me.GCListProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListProduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEStartBAP As DevExpress.XtraEditors.DateEdit
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TextEdit2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents CheckEdit4 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CheckEdit3 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CheckEdit2 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CheckEdit1 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BDeleteScan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BInputManual As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCListProduct As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListProduct As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
End Class
