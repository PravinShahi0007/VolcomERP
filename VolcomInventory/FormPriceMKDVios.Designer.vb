<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPriceMKDVios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPriceMKDVios))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnImportToXLS = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnHistory = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.DEEffDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtProposeNo = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnLastPropose = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_report = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnrmt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_product = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnproduct_full_code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnclass = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnproduct_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsht_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnormal_price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpropose_price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnshopify_price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsync_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsync_note = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsync_stt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnvariant_id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BtnUpdatePrice = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumncheck = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.DEEffDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEffDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtProposeNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnImportToXLS)
        Me.PanelControl1.Controls.Add(Me.BtnHistory)
        Me.PanelControl1.Controls.Add(Me.PanelControl2)
        Me.PanelControl1.Controls.Add(Me.BtnLastPropose)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(860, 42)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnImportToXLS
        '
        Me.BtnImportToXLS.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnImportToXLS.Image = CType(resources.GetObject("BtnImportToXLS.Image"), System.Drawing.Image)
        Me.BtnImportToXLS.Location = New System.Drawing.Point(211, 2)
        Me.BtnImportToXLS.Name = "BtnImportToXLS"
        Me.BtnImportToXLS.Size = New System.Drawing.Size(116, 38)
        Me.BtnImportToXLS.TabIndex = 3
        Me.BtnImportToXLS.Text = "Export as XLS"
        '
        'BtnHistory
        '
        Me.BtnHistory.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnHistory.Image = CType(resources.GetObject("BtnHistory.Image"), System.Drawing.Image)
        Me.BtnHistory.Location = New System.Drawing.Point(127, 2)
        Me.BtnHistory.Name = "BtnHistory"
        Me.BtnHistory.Size = New System.Drawing.Size(84, 38)
        Me.BtnHistory.TabIndex = 5
        Me.BtnHistory.Text = "History"
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.DEEffDate)
        Me.PanelControl2.Controls.Add(Me.LabelControl2)
        Me.PanelControl2.Controls.Add(Me.TxtProposeNo)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl2.Location = New System.Drawing.Point(422, 2)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(436, 38)
        Me.PanelControl2.TabIndex = 2
        '
        'DEEffDate
        '
        Me.DEEffDate.EditValue = Nothing
        Me.DEEffDate.Enabled = False
        Me.DEEffDate.Location = New System.Drawing.Point(255, 9)
        Me.DEEffDate.Name = "DEEffDate"
        Me.DEEffDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEffDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEffDate.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEEffDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEEffDate.Size = New System.Drawing.Size(173, 20)
        Me.DEEffDate.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(180, 12)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Effective Date"
        '
        'TxtProposeNo
        '
        Me.TxtProposeNo.Enabled = False
        Me.TxtProposeNo.Location = New System.Drawing.Point(31, 9)
        Me.TxtProposeNo.Name = "TxtProposeNo"
        Me.TxtProposeNo.Size = New System.Drawing.Size(143, 20)
        Me.TxtProposeNo.TabIndex = 2
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(8, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(17, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "No."
        '
        'BtnLastPropose
        '
        Me.BtnLastPropose.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnLastPropose.Image = CType(resources.GetObject("BtnLastPropose.Image"), System.Drawing.Image)
        Me.BtnLastPropose.Location = New System.Drawing.Point(2, 2)
        Me.BtnLastPropose.Name = "BtnLastPropose"
        Me.BtnLastPropose.Size = New System.Drawing.Size(125, 38)
        Me.BtnLastPropose.TabIndex = 4
        Me.BtnLastPropose.Text = "Latest Proposal"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 42)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(860, 379)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_report, Me.GridColumnrmt, Me.GridColumnid_product, Me.GridColumnproduct_full_code, Me.GridColumnclass, Me.GridColumnproduct_name, Me.GridColumnsht_name, Me.GridColumnsize, Me.GridColumnnormal_price, Me.GridColumnpropose_price, Me.GridColumnshopify_price, Me.GridColumnsync_date, Me.GridColumnsync_note, Me.GridColumnsync_stt, Me.GridColumnvariant_id, Me.GridColumncheck})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_report
        '
        Me.GridColumnid_report.Caption = "id_report"
        Me.GridColumnid_report.FieldName = "id_report"
        Me.GridColumnid_report.Name = "GridColumnid_report"
        '
        'GridColumnrmt
        '
        Me.GridColumnrmt.Caption = "rmt"
        Me.GridColumnrmt.FieldName = "rmt"
        Me.GridColumnrmt.Name = "GridColumnrmt"
        '
        'GridColumnid_product
        '
        Me.GridColumnid_product.Caption = "id_product"
        Me.GridColumnid_product.FieldName = "id_product"
        Me.GridColumnid_product.Name = "GridColumnid_product"
        '
        'GridColumnproduct_full_code
        '
        Me.GridColumnproduct_full_code.Caption = "SKU"
        Me.GridColumnproduct_full_code.FieldName = "product_full_code"
        Me.GridColumnproduct_full_code.Name = "GridColumnproduct_full_code"
        Me.GridColumnproduct_full_code.Visible = True
        Me.GridColumnproduct_full_code.VisibleIndex = 0
        '
        'GridColumnclass
        '
        Me.GridColumnclass.Caption = "Class"
        Me.GridColumnclass.FieldName = "class"
        Me.GridColumnclass.Name = "GridColumnclass"
        Me.GridColumnclass.Visible = True
        Me.GridColumnclass.VisibleIndex = 1
        '
        'GridColumnproduct_name
        '
        Me.GridColumnproduct_name.Caption = "Description"
        Me.GridColumnproduct_name.FieldName = "product_name"
        Me.GridColumnproduct_name.Name = "GridColumnproduct_name"
        Me.GridColumnproduct_name.Visible = True
        Me.GridColumnproduct_name.VisibleIndex = 2
        '
        'GridColumnsht_name
        '
        Me.GridColumnsht_name.Caption = "Silhouette"
        Me.GridColumnsht_name.FieldName = "sht_name"
        Me.GridColumnsht_name.Name = "GridColumnsht_name"
        Me.GridColumnsht_name.Visible = True
        Me.GridColumnsht_name.VisibleIndex = 3
        '
        'GridColumnsize
        '
        Me.GridColumnsize.Caption = "Size"
        Me.GridColumnsize.FieldName = "size"
        Me.GridColumnsize.Name = "GridColumnsize"
        Me.GridColumnsize.Visible = True
        Me.GridColumnsize.VisibleIndex = 4
        '
        'GridColumnnormal_price
        '
        Me.GridColumnnormal_price.Caption = "Normal Price"
        Me.GridColumnnormal_price.DisplayFormat.FormatString = "N0"
        Me.GridColumnnormal_price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnnormal_price.FieldName = "normal_price"
        Me.GridColumnnormal_price.Name = "GridColumnnormal_price"
        Me.GridColumnnormal_price.Visible = True
        Me.GridColumnnormal_price.VisibleIndex = 5
        '
        'GridColumnpropose_price
        '
        Me.GridColumnpropose_price.Caption = "Propose Price"
        Me.GridColumnpropose_price.DisplayFormat.FormatString = "N0"
        Me.GridColumnpropose_price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnpropose_price.FieldName = "propose_price"
        Me.GridColumnpropose_price.Name = "GridColumnpropose_price"
        Me.GridColumnpropose_price.Visible = True
        Me.GridColumnpropose_price.VisibleIndex = 6
        Me.GridColumnpropose_price.Width = 96
        '
        'GridColumnshopify_price
        '
        Me.GridColumnshopify_price.Caption = "Current VIOS Price"
        Me.GridColumnshopify_price.DisplayFormat.FormatString = "N0"
        Me.GridColumnshopify_price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnshopify_price.FieldName = "shopify_price"
        Me.GridColumnshopify_price.Name = "GridColumnshopify_price"
        Me.GridColumnshopify_price.Visible = True
        Me.GridColumnshopify_price.VisibleIndex = 7
        Me.GridColumnshopify_price.Width = 123
        '
        'GridColumnsync_date
        '
        Me.GridColumnsync_date.Caption = "Sync Date"
        Me.GridColumnsync_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumnsync_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsync_date.FieldName = "sync_date"
        Me.GridColumnsync_date.Name = "GridColumnsync_date"
        Me.GridColumnsync_date.Visible = True
        Me.GridColumnsync_date.VisibleIndex = 9
        '
        'GridColumnsync_note
        '
        Me.GridColumnsync_note.Caption = "Sync Note"
        Me.GridColumnsync_note.FieldName = "sync_note"
        Me.GridColumnsync_note.Name = "GridColumnsync_note"
        Me.GridColumnsync_note.Visible = True
        Me.GridColumnsync_note.VisibleIndex = 10
        '
        'GridColumnsync_stt
        '
        Me.GridColumnsync_stt.Caption = "Sync Status"
        Me.GridColumnsync_stt.FieldName = "sync_stt"
        Me.GridColumnsync_stt.Name = "GridColumnsync_stt"
        Me.GridColumnsync_stt.UnboundExpression = "Iif([sync_note] = '', '', 'Done')"
        Me.GridColumnsync_stt.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        '
        'GridColumnvariant_id
        '
        Me.GridColumnvariant_id.Caption = "variant_id"
        Me.GridColumnvariant_id.FieldName = "variant_id"
        Me.GridColumnvariant_id.Name = "GridColumnvariant_id"
        '
        'BtnUpdatePrice
        '
        Me.BtnUpdatePrice.Appearance.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BtnUpdatePrice.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnUpdatePrice.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnUpdatePrice.Appearance.Options.UseBackColor = True
        Me.BtnUpdatePrice.Appearance.Options.UseFont = True
        Me.BtnUpdatePrice.Appearance.Options.UseForeColor = True
        Me.BtnUpdatePrice.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnUpdatePrice.Location = New System.Drawing.Point(0, 421)
        Me.BtnUpdatePrice.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnUpdatePrice.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BtnUpdatePrice.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnUpdatePrice.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnUpdatePrice.Name = "BtnUpdatePrice"
        Me.BtnUpdatePrice.Size = New System.Drawing.Size(860, 32)
        Me.BtnUpdatePrice.TabIndex = 19
        Me.BtnUpdatePrice.Text = "Update Price"
        Me.BtnUpdatePrice.Visible = False
        '
        'GridColumncheck
        '
        Me.GridColumncheck.Caption = "Check Status"
        Me.GridColumncheck.FieldName = "check"
        Me.GridColumncheck.Name = "GridColumncheck"
        Me.GridColumncheck.UnboundExpression = "Iif([propose_price] = [shopify_price], 'Match', 'Not Match')"
        Me.GridColumncheck.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.GridColumncheck.Visible = True
        Me.GridColumncheck.VisibleIndex = 8
        '
        'FormPriceMKDVios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(860, 453)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.BtnUpdatePrice)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormPriceMKDVios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VIOS - Sync Price"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.DEEffDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEffDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtProposeNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DEEffDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtProposeNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnUpdatePrice As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnImportToXLS As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnHistory As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnLastPropose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnid_report As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnrmt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_product As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnproduct_full_code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnclass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnproduct_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsht_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnormal_price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpropose_price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnshopify_price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsync_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsync_note As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsync_stt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnvariant_id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncheck As DevExpress.XtraGrid.Columns.GridColumn
End Class
