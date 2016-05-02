<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormViewMatRetOut
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
        Me.GroupControlRet = New DevExpress.XtraEditors.GroupControl
        Me.GCRetDetail = New DevExpress.XtraGrid.GridControl
        Me.GVRetDetail = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnIdRet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdSamplePurcDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnUOM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
        Me.GridColumnRemark = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColTotalPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GroupGeneralHeader = New DevExpress.XtraEditors.GroupControl
        Me.DERetDueDate = New DevExpress.XtraEditors.TextEdit
        Me.DERet = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl
        Me.TxtOrderNumber = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl
        Me.TxtRetOutNumber = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl
        Me.MEAdrressCompTo = New DevExpress.XtraEditors.MemoEdit
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.TxtNameCompTo = New DevExpress.XtraEditors.TextEdit
        Me.TxtCodeCompTo = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.TxtNameCompFrom = New DevExpress.XtraEditors.TextEdit
        Me.TxtCodeCompFrom = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl
        Me.LEReportStatus = New DevExpress.XtraEditors.LookUpEdit
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl
        Me.MENote = New DevExpress.XtraEditors.MemoEdit
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl
        Me.BMark = New DevExpress.XtraEditors.SimpleButton
        Me.BAttach = New DevExpress.XtraEditors.SimpleButton
        CType(Me.GroupControlRet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlRet.SuspendLayout()
        CType(Me.GCRetDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRetDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupGeneralHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneralHeader.SuspendLayout()
        CType(Me.DERetDueDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DERet.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtOrderNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtRetOutNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEAdrressCompTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNameCompTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodeCompTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNameCompFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodeCompFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupControlRet
        '
        Me.GroupControlRet.AppearanceCaption.Options.UseTextOptions = True
        Me.GroupControlRet.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GroupControlRet.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlRet.Controls.Add(Me.GCRetDetail)
        Me.GroupControlRet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlRet.Location = New System.Drawing.Point(0, 154)
        Me.GroupControlRet.Name = "GroupControlRet"
        Me.GroupControlRet.Size = New System.Drawing.Size(736, 201)
        Me.GroupControlRet.TabIndex = 180
        Me.GroupControlRet.Text = "Return List"
        '
        'GCRetDetail
        '
        Me.GCRetDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRetDetail.Location = New System.Drawing.Point(22, 2)
        Me.GCRetDetail.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCRetDetail.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GCRetDetail.MainView = Me.GVRetDetail
        Me.GCRetDetail.Name = "GCRetDetail"
        Me.GCRetDetail.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1})
        Me.GCRetDetail.Size = New System.Drawing.Size(712, 197)
        Me.GCRetDetail.TabIndex = 1
        Me.GCRetDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRetDetail})
        '
        'GVRetDetail
        '
        Me.GVRetDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdRet, Me.GridColumnIdSamplePurcDet, Me.GridColumnNo, Me.GridColumnName, Me.GridColumnSize, Me.GridColumnUOM, Me.GridColumnQty, Me.GridColumnRemark, Me.ColTotalPrice, Me.GridColumn1, Me.GridColumn2})
        Me.GVRetDetail.GridControl = Me.GCRetDetail
        Me.GVRetDetail.Name = "GVRetDetail"
        Me.GVRetDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVRetDetail.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVRetDetail.OptionsBehavior.Editable = False
        Me.GVRetDetail.OptionsView.ShowFooter = True
        Me.GVRetDetail.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdRet
        '
        Me.GridColumnIdRet.Caption = "ID Ret"
        Me.GridColumnIdRet.FieldName = "id_mat_purc_ret_out_det"
        Me.GridColumnIdRet.Name = "GridColumnIdRet"
        Me.GridColumnIdRet.OptionsColumn.AllowEdit = False
        '
        'GridColumnIdSamplePurcDet
        '
        Me.GridColumnIdSamplePurcDet.Caption = "Id Sample Purc Det"
        Me.GridColumnIdSamplePurcDet.FieldName = "id_mat_purc_det"
        Me.GridColumnIdSamplePurcDet.Name = "GridColumnIdSamplePurcDet"
        Me.GridColumnIdSamplePurcDet.OptionsColumn.AllowEdit = False
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.OptionsColumn.AllowEdit = False
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Description"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.OptionsColumn.AllowEdit = False
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 1
        '
        'GridColumnSize
        '
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.OptionsColumn.AllowEdit = False
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 2
        '
        'GridColumnUOM
        '
        Me.GridColumnUOM.Caption = "UOM"
        Me.GridColumnUOM.FieldName = "uom"
        Me.GridColumnUOM.Name = "GridColumnUOM"
        Me.GridColumnUOM.OptionsColumn.AllowEdit = False
        Me.GridColumnUOM.Visible = True
        Me.GridColumnUOM.VisibleIndex = 3
        '
        'GridColumnQty
        '
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.GridColumnQty.FieldName = "mat_purc_ret_out_det_qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 4
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "f0"
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'GridColumnRemark
        '
        Me.GridColumnRemark.Caption = "Remark"
        Me.GridColumnRemark.FieldName = "mat_purc_ret_out_det_note"
        Me.GridColumnRemark.Name = "GridColumnRemark"
        Me.GridColumnRemark.Visible = True
        Me.GridColumnRemark.VisibleIndex = 5
        '
        'ColTotalPrice
        '
        Me.ColTotalPrice.AppearanceCell.Options.UseTextOptions = True
        Me.ColTotalPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColTotalPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.ColTotalPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColTotalPrice.Caption = "Total Cost"
        Me.ColTotalPrice.DisplayFormat.FormatString = "N2"
        Me.ColTotalPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColTotalPrice.FieldName = "tot_price"
        Me.ColTotalPrice.Name = "ColTotalPrice"
        Me.ColTotalPrice.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tot_cost", "{0:N2}")})
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn1.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn1.Caption = "Cost"
        Me.GridColumn1.DisplayFormat.FormatString = "N4"
        Me.GridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn1.FieldName = "price"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Code"
        Me.GridColumn2.FieldName = "code"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GroupGeneralHeader
        '
        Me.GroupGeneralHeader.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupGeneralHeader.Controls.Add(Me.DERetDueDate)
        Me.GroupGeneralHeader.Controls.Add(Me.DERet)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl6)
        Me.GroupGeneralHeader.Controls.Add(Me.TxtOrderNumber)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl4)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl7)
        Me.GroupGeneralHeader.Controls.Add(Me.TxtRetOutNumber)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl5)
        Me.GroupGeneralHeader.Controls.Add(Me.MEAdrressCompTo)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl3)
        Me.GroupGeneralHeader.Controls.Add(Me.TxtNameCompTo)
        Me.GroupGeneralHeader.Controls.Add(Me.TxtCodeCompTo)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl2)
        Me.GroupGeneralHeader.Controls.Add(Me.TxtNameCompFrom)
        Me.GroupGeneralHeader.Controls.Add(Me.TxtCodeCompFrom)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl1)
        Me.GroupGeneralHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupGeneralHeader.Location = New System.Drawing.Point(0, 0)
        Me.GroupGeneralHeader.Name = "GroupGeneralHeader"
        Me.GroupGeneralHeader.Size = New System.Drawing.Size(736, 154)
        Me.GroupGeneralHeader.TabIndex = 179
        '
        'DERetDueDate
        '
        Me.DERetDueDate.EditValue = ""
        Me.DERetDueDate.Location = New System.Drawing.Point(551, 35)
        Me.DERetDueDate.Name = "DERetDueDate"
        Me.DERetDueDate.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.DERetDueDate.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black
        Me.DERetDueDate.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.DERetDueDate.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.DERetDueDate.Properties.EditValueChangedDelay = 1
        Me.DERetDueDate.Properties.ReadOnly = True
        Me.DERetDueDate.Size = New System.Drawing.Size(160, 20)
        Me.DERetDueDate.TabIndex = 163
        '
        'DERet
        '
        Me.DERet.EditValue = ""
        Me.DERet.Location = New System.Drawing.Point(551, 9)
        Me.DERet.Name = "DERet"
        Me.DERet.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.DERet.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black
        Me.DERet.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.DERet.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.DERet.Properties.EditValueChangedDelay = 1
        Me.DERet.Properties.ReadOnly = True
        Me.DERet.Size = New System.Drawing.Size(160, 20)
        Me.DERet.TabIndex = 162
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(443, 42)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(90, 13)
        Me.LabelControl6.TabIndex = 161
        Me.LabelControl6.Text = "Estimate Return In"
        '
        'TxtOrderNumber
        '
        Me.TxtOrderNumber.EditValue = ""
        Me.TxtOrderNumber.Location = New System.Drawing.Point(108, 9)
        Me.TxtOrderNumber.Name = "TxtOrderNumber"
        Me.TxtOrderNumber.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtOrderNumber.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black
        Me.TxtOrderNumber.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TxtOrderNumber.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.TxtOrderNumber.Properties.EditValueChangedDelay = 1
        Me.TxtOrderNumber.Properties.ReadOnly = True
        Me.TxtOrderNumber.Size = New System.Drawing.Size(286, 20)
        Me.TxtOrderNumber.TabIndex = 0
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(27, 16)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl4.TabIndex = 88
        Me.LabelControl4.Text = "PO Number"
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(443, 16)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl7.TabIndex = 159
        Me.LabelControl7.Text = "Date"
        '
        'TxtRetOutNumber
        '
        Me.TxtRetOutNumber.EditValue = ""
        Me.TxtRetOutNumber.Location = New System.Drawing.Point(551, 61)
        Me.TxtRetOutNumber.Name = "TxtRetOutNumber"
        Me.TxtRetOutNumber.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtRetOutNumber.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black
        Me.TxtRetOutNumber.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TxtRetOutNumber.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.TxtRetOutNumber.Properties.EditValueChangedDelay = 1
        Me.TxtRetOutNumber.Properties.ReadOnly = True
        Me.TxtRetOutNumber.Size = New System.Drawing.Size(160, 20)
        Me.TxtRetOutNumber.TabIndex = 8
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(443, 68)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(82, 13)
        Me.LabelControl5.TabIndex = 155
        Me.LabelControl5.Text = "Ret. Out Number"
        '
        'MEAdrressCompTo
        '
        Me.MEAdrressCompTo.Location = New System.Drawing.Point(108, 91)
        Me.MEAdrressCompTo.Name = "MEAdrressCompTo"
        Me.MEAdrressCompTo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MEAdrressCompTo.Properties.Appearance.Options.UseFont = True
        Me.MEAdrressCompTo.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.MEAdrressCompTo.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black
        Me.MEAdrressCompTo.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.MEAdrressCompTo.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.MEAdrressCompTo.Properties.ReadOnly = True
        Me.MEAdrressCompTo.Size = New System.Drawing.Size(286, 46)
        Me.MEAdrressCompTo.TabIndex = 7
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(27, 93)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl3.TabIndex = 153
        Me.LabelControl3.Text = "Address"
        '
        'TxtNameCompTo
        '
        Me.TxtNameCompTo.EditValue = ""
        Me.TxtNameCompTo.Location = New System.Drawing.Point(214, 63)
        Me.TxtNameCompTo.Name = "TxtNameCompTo"
        Me.TxtNameCompTo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNameCompTo.Properties.Appearance.Options.UseFont = True
        Me.TxtNameCompTo.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtNameCompTo.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black
        Me.TxtNameCompTo.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TxtNameCompTo.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.TxtNameCompTo.Properties.EditValueChangedDelay = 1
        Me.TxtNameCompTo.Properties.ReadOnly = True
        Me.TxtNameCompTo.Size = New System.Drawing.Size(180, 20)
        Me.TxtNameCompTo.TabIndex = 5
        Me.TxtNameCompTo.TabStop = False
        '
        'TxtCodeCompTo
        '
        Me.TxtCodeCompTo.EditValue = ""
        Me.TxtCodeCompTo.Location = New System.Drawing.Point(108, 63)
        Me.TxtCodeCompTo.Name = "TxtCodeCompTo"
        Me.TxtCodeCompTo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodeCompTo.Properties.Appearance.Options.UseFont = True
        Me.TxtCodeCompTo.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtCodeCompTo.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black
        Me.TxtCodeCompTo.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TxtCodeCompTo.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.TxtCodeCompTo.Properties.EditValueChangedDelay = 1
        Me.TxtCodeCompTo.Properties.ReadOnly = True
        Me.TxtCodeCompTo.Size = New System.Drawing.Size(102, 20)
        Me.TxtCodeCompTo.TabIndex = 4
        Me.TxtCodeCompTo.TabStop = False
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(27, 70)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(12, 13)
        Me.LabelControl2.TabIndex = 149
        Me.LabelControl2.Text = "To"
        '
        'TxtNameCompFrom
        '
        Me.TxtNameCompFrom.EditValue = ""
        Me.TxtNameCompFrom.Location = New System.Drawing.Point(216, 35)
        Me.TxtNameCompFrom.Name = "TxtNameCompFrom"
        Me.TxtNameCompFrom.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNameCompFrom.Properties.Appearance.Options.UseFont = True
        Me.TxtNameCompFrom.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtNameCompFrom.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black
        Me.TxtNameCompFrom.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TxtNameCompFrom.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.TxtNameCompFrom.Properties.EditValueChangedDelay = 1
        Me.TxtNameCompFrom.Properties.ReadOnly = True
        Me.TxtNameCompFrom.Size = New System.Drawing.Size(178, 20)
        Me.TxtNameCompFrom.TabIndex = 3
        Me.TxtNameCompFrom.TabStop = False
        '
        'TxtCodeCompFrom
        '
        Me.TxtCodeCompFrom.EditValue = ""
        Me.TxtCodeCompFrom.Location = New System.Drawing.Point(108, 35)
        Me.TxtCodeCompFrom.Name = "TxtCodeCompFrom"
        Me.TxtCodeCompFrom.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodeCompFrom.Properties.Appearance.Options.UseFont = True
        Me.TxtCodeCompFrom.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtCodeCompFrom.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black
        Me.TxtCodeCompFrom.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TxtCodeCompFrom.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.TxtCodeCompFrom.Properties.EditValueChangedDelay = 1
        Me.TxtCodeCompFrom.Properties.ReadOnly = True
        Me.TxtCodeCompFrom.Size = New System.Drawing.Size(102, 20)
        Me.TxtCodeCompFrom.TabIndex = 2
        Me.TxtCodeCompFrom.TabStop = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(27, 42)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl1.TabIndex = 145
        Me.LabelControl1.Text = "From"
        '
        'GroupControl3
        '
        Me.GroupControl3.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl3.Controls.Add(Me.LEReportStatus)
        Me.GroupControl3.Controls.Add(Me.LabelControl21)
        Me.GroupControl3.Controls.Add(Me.MENote)
        Me.GroupControl3.Controls.Add(Me.LabelControl18)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl3.Location = New System.Drawing.Point(0, 355)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(736, 93)
        Me.GroupControl3.TabIndex = 178
        '
        'LEReportStatus
        '
        Me.LEReportStatus.Enabled = False
        Me.LEReportStatus.Location = New System.Drawing.Point(495, 10)
        Me.LEReportStatus.Name = "LEReportStatus"
        Me.LEReportStatus.Properties.Appearance.Options.UseTextOptions = True
        Me.LEReportStatus.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEReportStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEReportStatus.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_report_status", "ID Report Status", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("report_status", "Report Status")})
        Me.LEReportStatus.Properties.NullText = ""
        Me.LEReportStatus.Properties.ShowFooter = False
        Me.LEReportStatus.Size = New System.Drawing.Size(216, 20)
        Me.LEReportStatus.TabIndex = 12
        '
        'LabelControl21
        '
        Me.LabelControl21.Location = New System.Drawing.Point(443, 13)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl21.TabIndex = 144
        Me.LabelControl21.Text = "Status"
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(108, 11)
        Me.MENote.Name = "MENote"
        Me.MENote.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.MENote.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black
        Me.MENote.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.MENote.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.MENote.Properties.MaxLength = 100
        Me.MENote.Properties.ReadOnly = True
        Me.MENote.Size = New System.Drawing.Size(286, 61)
        Me.MENote.TabIndex = 11
        '
        'LabelControl18
        '
        Me.LabelControl18.Location = New System.Drawing.Point(27, 17)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl18.TabIndex = 138
        Me.LabelControl18.Text = "Note"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.BAttach)
        Me.PanelControl3.Controls.Add(Me.BMark)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 448)
        Me.PanelControl3.LookAndFeel.SkinName = "Blue"
        Me.PanelControl3.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(736, 58)
        Me.PanelControl3.TabIndex = 177
        '
        'BMark
        '
        Me.BMark.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BMark.Location = New System.Drawing.Point(2, 28)
        Me.BMark.Name = "BMark"
        Me.BMark.Size = New System.Drawing.Size(732, 28)
        Me.BMark.TabIndex = 16
        Me.BMark.Text = "Mark"
        '
        'BAttach
        '
        Me.BAttach.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BAttach.Location = New System.Drawing.Point(2, 2)
        Me.BAttach.Name = "BAttach"
        Me.BAttach.Size = New System.Drawing.Size(732, 26)
        Me.BAttach.TabIndex = 17
        Me.BAttach.Text = "Attachment"
        '
        'FormViewMatRetOut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 506)
        Me.Controls.Add(Me.GroupControlRet)
        Me.Controls.Add(Me.GroupGeneralHeader)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.PanelControl3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormViewMatRetOut"
        Me.ShowInTaskbar = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Raw Material Return Out"
        CType(Me.GroupControlRet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlRet.ResumeLayout(False)
        CType(Me.GCRetDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRetDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupGeneralHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneralHeader.ResumeLayout(False)
        Me.GroupGeneralHeader.PerformLayout()
        CType(Me.DERetDueDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DERet.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtOrderNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtRetOutNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEAdrressCompTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNameCompTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodeCompTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNameCompFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodeCompFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControlRet As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCRetDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRetDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdRet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSamplePurcDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumnRemark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColTotalPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupGeneralHeader As DevExpress.XtraEditors.GroupControl
    Friend WithEvents DERetDueDate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DERet As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtOrderNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtRetOutNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MEAdrressCompTo As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtNameCompTo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtCodeCompTo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtNameCompFrom As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtCodeCompFrom As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LEReportStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BAttach As DevExpress.XtraEditors.SimpleButton
End Class
