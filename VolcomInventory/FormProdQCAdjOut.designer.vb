<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProdQCAdjOut
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProdQCAdjOut))
        Me.EPAdj = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ImgBut = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl
        Me.BtnAttachment = New DevExpress.XtraEditors.SimpleButton
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton
        Me.BMark = New DevExpress.XtraEditors.SimpleButton
        Me.GroupGeneralFooter = New DevExpress.XtraEditors.GroupControl
        Me.LabelControl19 = New DevExpress.XtraEditors.LabelControl
        Me.METotSay = New DevExpress.XtraEditors.MemoEdit
        Me.LEReportStatus = New DevExpress.XtraEditors.LookUpEdit
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl
        Me.MENote = New DevExpress.XtraEditors.MemoEdit
        Me.GConListPurchase = New DevExpress.XtraEditors.GroupControl
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.GCDetail = New DevExpress.XtraGrid.GridControl
        Me.GVDetail = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIDProdDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RSPQty = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
        Me.GridColumnNote = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDescription = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCost = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnAmount = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQtyInQC = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupGeneralHeader = New DevExpress.XtraEditors.GroupControl
        Me.BPickPO = New DevExpress.XtraEditors.SimpleButton
        Me.TEProdOrderNumber = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl
        Me.TxtAdjDate = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl
        Me.TxtAdjNumber = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        CType(Me.EPAdj, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImgBut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.GroupGeneralFooter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneralFooter.SuspendLayout()
        CType(Me.METotSay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GConListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GConListPurchase.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RSPQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupGeneralHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneralHeader.SuspendLayout()
        CType(Me.TEProdOrderNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtAdjDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtAdjNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EPAdj
        '
        Me.EPAdj.ContainerControl = Me
        '
        'ImgBut
        '
        Me.ImgBut.ImageSize = New System.Drawing.Size(24, 24)
        Me.ImgBut.ImageStream = CType(resources.GetObject("ImgBut.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImgBut.Images.SetKeyName(0, "20_24x24.png")
        Me.ImgBut.Images.SetKeyName(1, "8_24x24.png")
        Me.ImgBut.Images.SetKeyName(2, "23_24x24.png")
        Me.ImgBut.Images.SetKeyName(3, "arrow_refresh.png")
        Me.ImgBut.Images.SetKeyName(4, "check_mark.png")
        Me.ImgBut.Images.SetKeyName(5, "gnome_application_exit (1).png")
        Me.ImgBut.Images.SetKeyName(6, "printer_3.png")
        Me.ImgBut.Images.SetKeyName(7, "save.png")
        Me.ImgBut.Images.SetKeyName(8, "31_24x24.png")
        Me.ImgBut.Images.SetKeyName(9, "18_24x24.png")
        Me.ImgBut.Images.SetKeyName(10, "attachment-icon.png")
        Me.ImgBut.Images.SetKeyName(11, "document_32.png")
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.BtnAttachment)
        Me.PanelControl3.Controls.Add(Me.BtnPrint)
        Me.PanelControl3.Controls.Add(Me.BtnCancel)
        Me.PanelControl3.Controls.Add(Me.BtnSave)
        Me.PanelControl3.Controls.Add(Me.BMark)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl3.Location = New System.Drawing.Point(0, 444)
        Me.PanelControl3.LookAndFeel.SkinName = "Blue"
        Me.PanelControl3.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(829, 33)
        Me.PanelControl3.TabIndex = 177
        '
        'BtnAttachment
        '
        Me.BtnAttachment.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAttachment.ImageIndex = 10
        Me.BtnAttachment.ImageList = Me.ImgBut
        Me.BtnAttachment.Location = New System.Drawing.Point(505, 2)
        Me.BtnAttachment.Name = "BtnAttachment"
        Me.BtnAttachment.Size = New System.Drawing.Size(97, 29)
        Me.BtnAttachment.TabIndex = 18
        Me.BtnAttachment.Text = "Attachment"
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.ImageIndex = 6
        Me.BtnPrint.ImageList = Me.ImgBut
        Me.BtnPrint.Location = New System.Drawing.Point(602, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(75, 29)
        Me.BtnPrint.TabIndex = 14
        Me.BtnPrint.Text = "Print"
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.ImageIndex = 5
        Me.BtnCancel.ImageList = Me.ImgBut
        Me.BtnCancel.Location = New System.Drawing.Point(677, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 29)
        Me.BtnCancel.TabIndex = 15
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.ImageIndex = 7
        Me.BtnSave.ImageList = Me.ImgBut
        Me.BtnSave.Location = New System.Drawing.Point(752, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 29)
        Me.BtnSave.TabIndex = 13
        Me.BtnSave.Text = "Save"
        '
        'BMark
        '
        Me.BMark.Dock = System.Windows.Forms.DockStyle.Left
        Me.BMark.ImageIndex = 4
        Me.BMark.ImageList = Me.ImgBut
        Me.BMark.Location = New System.Drawing.Point(2, 2)
        Me.BMark.Name = "BMark"
        Me.BMark.Size = New System.Drawing.Size(75, 29)
        Me.BMark.TabIndex = 16
        Me.BMark.Text = "Mark"
        '
        'GroupGeneralFooter
        '
        Me.GroupGeneralFooter.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupGeneralFooter.Controls.Add(Me.LabelControl19)
        Me.GroupGeneralFooter.Controls.Add(Me.METotSay)
        Me.GroupGeneralFooter.Controls.Add(Me.LEReportStatus)
        Me.GroupGeneralFooter.Controls.Add(Me.LabelControl21)
        Me.GroupGeneralFooter.Controls.Add(Me.LabelControl18)
        Me.GroupGeneralFooter.Controls.Add(Me.MENote)
        Me.GroupGeneralFooter.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupGeneralFooter.Location = New System.Drawing.Point(0, 334)
        Me.GroupGeneralFooter.Name = "GroupGeneralFooter"
        Me.GroupGeneralFooter.Size = New System.Drawing.Size(829, 110)
        Me.GroupGeneralFooter.TabIndex = 176
        '
        'LabelControl19
        '
        Me.LabelControl19.Location = New System.Drawing.Point(460, 16)
        Me.LabelControl19.Name = "LabelControl19"
        Me.LabelControl19.Size = New System.Drawing.Size(18, 13)
        Me.LabelControl19.TabIndex = 148
        Me.LabelControl19.Text = "Say"
        '
        'METotSay
        '
        Me.METotSay.Location = New System.Drawing.Point(500, 12)
        Me.METotSay.Name = "METotSay"
        Me.METotSay.Properties.MaxLength = 100
        Me.METotSay.Properties.ReadOnly = True
        Me.METotSay.Size = New System.Drawing.Size(317, 83)
        Me.METotSay.TabIndex = 147
        '
        'LEReportStatus
        '
        Me.LEReportStatus.Enabled = False
        Me.LEReportStatus.Location = New System.Drawing.Point(77, 75)
        Me.LEReportStatus.Name = "LEReportStatus"
        Me.LEReportStatus.Properties.Appearance.Options.UseTextOptions = True
        Me.LEReportStatus.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEReportStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEReportStatus.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_report_status", "ID Report Status", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("report_status", "Report Status")})
        Me.LEReportStatus.Properties.NullText = ""
        Me.LEReportStatus.Properties.ShowFooter = False
        Me.LEReportStatus.Size = New System.Drawing.Size(336, 20)
        Me.LEReportStatus.TabIndex = 145
        '
        'LabelControl21
        '
        Me.LabelControl21.Location = New System.Drawing.Point(27, 78)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl21.TabIndex = 146
        Me.LabelControl21.Text = "Status"
        '
        'LabelControl18
        '
        Me.LabelControl18.Location = New System.Drawing.Point(27, 15)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl18.TabIndex = 138
        Me.LabelControl18.Text = "Note"
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(77, 11)
        Me.MENote.Name = "MENote"
        Me.MENote.Properties.MaxLength = 100
        Me.MENote.Size = New System.Drawing.Size(336, 58)
        Me.MENote.TabIndex = 137
        '
        'GConListPurchase
        '
        Me.GConListPurchase.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GConListPurchase.Controls.Add(Me.PanelControl1)
        Me.GConListPurchase.Dock = System.Windows.Forms.DockStyle.Top
        Me.GConListPurchase.Location = New System.Drawing.Point(0, 75)
        Me.GConListPurchase.Name = "GConListPurchase"
        Me.GConListPurchase.Size = New System.Drawing.Size(829, 259)
        Me.GConListPurchase.TabIndex = 175
        Me.GConListPurchase.Text = "Adjustment List"
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.GCDetail)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(22, 2)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(805, 255)
        Me.PanelControl1.TabIndex = 19
        '
        'GCDetail
        '
        Me.GCDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDetail.Location = New System.Drawing.Point(0, 0)
        Me.GCDetail.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.GCDetail.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GCDetail.MainView = Me.GVDetail
        Me.GCDetail.Name = "GCDetail"
        Me.GCDetail.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1, Me.RSPQty})
        Me.GCDetail.Size = New System.Drawing.Size(805, 255)
        Me.GCDetail.TabIndex = 2
        Me.GCDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDetail, Me.GridView1})
        '
        'GVDetail
        '
        Me.GVDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNo, Me.GridColumnIdDet, Me.GridColumnIDProdDet, Me.GridColumnQty, Me.GridColumnNote, Me.GridColumnCode, Me.GridColumnDescription, Me.GridColumnColor, Me.GridColumnSize, Me.GridColumnCost, Me.GridColumnAmount, Me.GridColumnQtyInQC})
        Me.GVDetail.GridControl = Me.GCDetail
        Me.GVDetail.Name = "GVDetail"
        Me.GVDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVDetail.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVDetail.OptionsView.ShowFooter = True
        Me.GVDetail.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNo
        '
        Me.GridColumnNo.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnNo.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.OptionsColumn.ReadOnly = True
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 47
        '
        'GridColumnIdDet
        '
        Me.GridColumnIdDet.Caption = "ID Det"
        Me.GridColumnIdDet.FieldName = "id_prod_order_qc_adj_out_det"
        Me.GridColumnIdDet.Name = "GridColumnIdDet"
        Me.GridColumnIdDet.OptionsColumn.ReadOnly = True
        '
        'GridColumnIDProdDet
        '
        Me.GridColumnIDProdDet.Caption = "ID Prod Order Det"
        Me.GridColumnIDProdDet.FieldName = "id_prod_order_det"
        Me.GridColumnIDProdDet.Name = "GridColumnIDProdDet"
        Me.GridColumnIDProdDet.OptionsColumn.ReadOnly = True
        '
        'GridColumnQty
        '
        Me.GridColumnQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.ColumnEdit = Me.RSPQty
        Me.GridColumnQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N2}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 6
        Me.GridColumnQty.Width = 91
        '
        'RSPQty
        '
        Me.RSPQty.AutoHeight = False
        Me.RSPQty.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.RSPQty.IsFloatValue = False
        Me.RSPQty.Mask.EditMask = "N00"
        Me.RSPQty.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.RSPQty.Name = "RSPQty"
        '
        'GridColumnNote
        '
        Me.GridColumnNote.Caption = "Note"
        Me.GridColumnNote.FieldName = "note"
        Me.GridColumnNote.Name = "GridColumnNote"
        Me.GridColumnNote.Visible = True
        Me.GridColumnNote.VisibleIndex = 9
        Me.GridColumnNote.Width = 139
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.OptionsColumn.ReadOnly = True
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 1
        Me.GridColumnCode.Width = 130
        '
        'GridColumnDescription
        '
        Me.GridColumnDescription.Caption = "Description"
        Me.GridColumnDescription.FieldName = "description"
        Me.GridColumnDescription.Name = "GridColumnDescription"
        Me.GridColumnDescription.OptionsColumn.ReadOnly = True
        Me.GridColumnDescription.Visible = True
        Me.GridColumnDescription.VisibleIndex = 2
        Me.GridColumnDescription.Width = 227
        '
        'GridColumnColor
        '
        Me.GridColumnColor.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnColor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnColor.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnColor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnColor.Caption = "Color"
        Me.GridColumnColor.FieldName = "color"
        Me.GridColumnColor.Name = "GridColumnColor"
        Me.GridColumnColor.OptionsColumn.ReadOnly = True
        Me.GridColumnColor.Visible = True
        Me.GridColumnColor.VisibleIndex = 3
        Me.GridColumnColor.Width = 81
        '
        'GridColumnSize
        '
        Me.GridColumnSize.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSize.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.OptionsColumn.ReadOnly = True
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 4
        Me.GridColumnSize.Width = 94
        '
        'GridColumnCost
        '
        Me.GridColumnCost.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnCost.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnCost.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnCost.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnCost.Caption = "Cost"
        Me.GridColumnCost.DisplayFormat.FormatString = "N2"
        Me.GridColumnCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCost.FieldName = "cost"
        Me.GridColumnCost.Name = "GridColumnCost"
        Me.GridColumnCost.OptionsColumn.ReadOnly = True
        Me.GridColumnCost.Visible = True
        Me.GridColumnCost.VisibleIndex = 7
        Me.GridColumnCost.Width = 138
        '
        'GridColumnAmount
        '
        Me.GridColumnAmount.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnAmount.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnAmount.Caption = "Amount"
        Me.GridColumnAmount.DisplayFormat.FormatString = "N2"
        Me.GridColumnAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAmount.FieldName = "amount"
        Me.GridColumnAmount.Name = "GridColumnAmount"
        Me.GridColumnAmount.OptionsColumn.ReadOnly = True
        Me.GridColumnAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N2}")})
        Me.GridColumnAmount.Visible = True
        Me.GridColumnAmount.VisibleIndex = 8
        Me.GridColumnAmount.Width = 145
        '
        'GridColumnQtyInQC
        '
        Me.GridColumnQtyInQC.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQtyInQC.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyInQC.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQtyInQC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyInQC.Caption = "Qty in QC"
        Me.GridColumnQtyInQC.DisplayFormat.FormatString = "N0"
        Me.GridColumnQtyInQC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyInQC.FieldName = "qty_left"
        Me.GridColumnQtyInQC.Name = "GridColumnQtyInQC"
        Me.GridColumnQtyInQC.Visible = True
        Me.GridColumnQtyInQC.VisibleIndex = 5
        Me.GridColumnQtyInQC.Width = 88
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "f0"
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GCDetail
        Me.GridView1.Name = "GridView1"
        '
        'GroupGeneralHeader
        '
        Me.GroupGeneralHeader.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupGeneralHeader.Controls.Add(Me.BPickPO)
        Me.GroupGeneralHeader.Controls.Add(Me.TEProdOrderNumber)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl13)
        Me.GroupGeneralHeader.Controls.Add(Me.TxtAdjDate)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl6)
        Me.GroupGeneralHeader.Controls.Add(Me.TxtAdjNumber)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl3)
        Me.GroupGeneralHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupGeneralHeader.Location = New System.Drawing.Point(0, 0)
        Me.GroupGeneralHeader.Name = "GroupGeneralHeader"
        Me.GroupGeneralHeader.Size = New System.Drawing.Size(829, 75)
        Me.GroupGeneralHeader.TabIndex = 174
        '
        'BPickPO
        '
        Me.BPickPO.Location = New System.Drawing.Point(384, 37)
        Me.BPickPO.Name = "BPickPO"
        Me.BPickPO.Size = New System.Drawing.Size(29, 20)
        Me.BPickPO.TabIndex = 148
        Me.BPickPO.Text = "..."
        '
        'TEProdOrderNumber
        '
        Me.TEProdOrderNumber.EditValue = ""
        Me.TEProdOrderNumber.Location = New System.Drawing.Point(150, 38)
        Me.TEProdOrderNumber.Name = "TEProdOrderNumber"
        Me.TEProdOrderNumber.Properties.EditValueChangedDelay = 1
        Me.TEProdOrderNumber.Properties.ReadOnly = True
        Me.TEProdOrderNumber.Size = New System.Drawing.Size(228, 20)
        Me.TEProdOrderNumber.TabIndex = 147
        '
        'LabelControl13
        '
        Me.LabelControl13.Location = New System.Drawing.Point(32, 41)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(82, 13)
        Me.LabelControl13.TabIndex = 146
        Me.LabelControl13.Text = "Production Order"
        '
        'TxtAdjDate
        '
        Me.TxtAdjDate.EditValue = ""
        Me.TxtAdjDate.Location = New System.Drawing.Point(540, 12)
        Me.TxtAdjDate.Name = "TxtAdjDate"
        Me.TxtAdjDate.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.TxtAdjDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TxtAdjDate.Properties.EditValueChangedDelay = 1
        Me.TxtAdjDate.Properties.ReadOnly = True
        Me.TxtAdjDate.Size = New System.Drawing.Size(277, 20)
        Me.TxtAdjDate.TabIndex = 0
        Me.TxtAdjDate.TabStop = False
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(489, 15)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl6.TabIndex = 124
        Me.LabelControl6.Text = "Date"
        '
        'TxtAdjNumber
        '
        Me.TxtAdjNumber.EditValue = ""
        Me.TxtAdjNumber.Location = New System.Drawing.Point(150, 12)
        Me.TxtAdjNumber.Name = "TxtAdjNumber"
        Me.TxtAdjNumber.Properties.EditValueChangedDelay = 1
        Me.TxtAdjNumber.Properties.ReadOnly = True
        Me.TxtAdjNumber.Size = New System.Drawing.Size(263, 20)
        Me.TxtAdjNumber.TabIndex = 3
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(32, 15)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(112, 13)
        Me.LabelControl3.TabIndex = 86
        Me.LabelControl3.Text = "Adjusment Out Number"
        '
        'FormProdQCAdjOut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(829, 477)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.GroupGeneralFooter)
        Me.Controls.Add(Me.GConListPurchase)
        Me.Controls.Add(Me.GroupGeneralHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProdQCAdjOut"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "QC Adjustment Out"
        CType(Me.EPAdj, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImgBut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.GroupGeneralFooter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneralFooter.ResumeLayout(False)
        Me.GroupGeneralFooter.PerformLayout()
        CType(Me.METotSay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GConListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GConListPurchase.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RSPQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupGeneralHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneralHeader.ResumeLayout(False)
        Me.GroupGeneralHeader.PerformLayout()
        CType(Me.TEProdOrderNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtAdjDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtAdjNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EPAdj As System.Windows.Forms.ErrorProvider
    Public WithEvents ImgBut As DevExpress.Utils.ImageCollection
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnAttachment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupGeneralFooter As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl19 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents METotSay As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LEReportStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents GConListPurchase As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIDProdDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RSPQty As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumnNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCost As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupGeneralHeader As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BPickPO As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEProdOrderNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtAdjDate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtAdjNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumnQtyInQC As DevExpress.XtraGrid.Columns.GridColumn
End Class
