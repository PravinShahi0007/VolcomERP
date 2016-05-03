<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormViewSampleOrder
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
        Me.GroupGeneralHeader = New DevExpress.XtraEditors.GroupControl
        Me.PanelControlTopLeft = New DevExpress.XtraEditors.PanelControl
        Me.TxtNameCompTo = New DevExpress.XtraEditors.ButtonEdit
        Me.MEAdrressCompTo = New DevExpress.XtraEditors.MemoEdit
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.TxtCodeCompTo = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.PanelControlTopMiddle = New DevExpress.XtraEditors.PanelControl
        Me.LETypeSO = New DevExpress.XtraEditors.LookUpEdit
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl
        Me.LEStatusSO = New DevExpress.XtraEditors.LookUpEdit
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl
        Me.PanelControlTopRight = New DevExpress.XtraEditors.PanelControl
        Me.TxtNumber = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl
        Me.DEForm = New DevExpress.XtraEditors.TextEdit
        Me.BMark = New DevExpress.XtraEditors.SimpleButton
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl
        Me.PanelControlBottomRight = New DevExpress.XtraEditors.PanelControl
        Me.LEReportStatus = New DevExpress.XtraEditors.LookUpEdit
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl
        Me.MENote = New DevExpress.XtraEditors.MemoEdit
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl
        Me.GroupControlList = New DevExpress.XtraEditors.GroupControl
        Me.GCItemList = New DevExpress.XtraGrid.GridControl
        Me.GVItemList = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnUOM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPriceType = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnAmount = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnRemark = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdSample = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdSalesOrderDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdSampleRetPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
        CType(Me.GroupGeneralHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneralHeader.SuspendLayout()
        CType(Me.PanelControlTopLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlTopLeft.SuspendLayout()
        CType(Me.TxtNameCompTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEAdrressCompTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodeCompTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlTopMiddle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlTopMiddle.SuspendLayout()
        CType(Me.LETypeSO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEStatusSO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlTopRight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlTopRight.SuspendLayout()
        CType(Me.TxtNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEForm.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.PanelControlBottomRight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlBottomRight.SuspendLayout()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlList.SuspendLayout()
        CType(Me.GCItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupGeneralHeader
        '
        Me.GroupGeneralHeader.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupGeneralHeader.Controls.Add(Me.PanelControlTopLeft)
        Me.GroupGeneralHeader.Controls.Add(Me.PanelControlTopMiddle)
        Me.GroupGeneralHeader.Controls.Add(Me.PanelControlTopRight)
        Me.GroupGeneralHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupGeneralHeader.Location = New System.Drawing.Point(0, 0)
        Me.GroupGeneralHeader.Name = "GroupGeneralHeader"
        Me.GroupGeneralHeader.Size = New System.Drawing.Size(832, 92)
        Me.GroupGeneralHeader.TabIndex = 185
        '
        'PanelControlTopLeft
        '
        Me.PanelControlTopLeft.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlTopLeft.Controls.Add(Me.TxtNameCompTo)
        Me.PanelControlTopLeft.Controls.Add(Me.MEAdrressCompTo)
        Me.PanelControlTopLeft.Controls.Add(Me.LabelControl1)
        Me.PanelControlTopLeft.Controls.Add(Me.TxtCodeCompTo)
        Me.PanelControlTopLeft.Controls.Add(Me.LabelControl3)
        Me.PanelControlTopLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControlTopLeft.Location = New System.Drawing.Point(22, 2)
        Me.PanelControlTopLeft.Name = "PanelControlTopLeft"
        Me.PanelControlTopLeft.Size = New System.Drawing.Size(412, 88)
        Me.PanelControlTopLeft.TabIndex = 8896
        '
        'TxtNameCompTo
        '
        Me.TxtNameCompTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNameCompTo.Location = New System.Drawing.Point(140, 4)
        Me.TxtNameCompTo.Name = "TxtNameCompTo"
        Me.TxtNameCompTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.TxtNameCompTo.Properties.ReadOnly = True
        Me.TxtNameCompTo.Size = New System.Drawing.Size(237, 20)
        Me.TxtNameCompTo.TabIndex = 0
        '
        'MEAdrressCompTo
        '
        Me.MEAdrressCompTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MEAdrressCompTo.Location = New System.Drawing.Point(52, 30)
        Me.MEAdrressCompTo.Name = "MEAdrressCompTo"
        Me.MEAdrressCompTo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MEAdrressCompTo.Properties.Appearance.Options.UseFont = True
        Me.MEAdrressCompTo.Properties.ReadOnly = True
        Me.MEAdrressCompTo.Size = New System.Drawing.Size(325, 46)
        Me.MEAdrressCompTo.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(7, 7)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl1.TabIndex = 145
        Me.LabelControl1.Text = "Store"
        '
        'TxtCodeCompTo
        '
        Me.TxtCodeCompTo.EditValue = ""
        Me.TxtCodeCompTo.Location = New System.Drawing.Point(52, 4)
        Me.TxtCodeCompTo.Name = "TxtCodeCompTo"
        Me.TxtCodeCompTo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodeCompTo.Properties.Appearance.Options.UseFont = True
        Me.TxtCodeCompTo.Properties.EditValueChangedDelay = 1
        Me.TxtCodeCompTo.Properties.ReadOnly = True
        Me.TxtCodeCompTo.Size = New System.Drawing.Size(82, 20)
        Me.TxtCodeCompTo.TabIndex = 7777
        Me.TxtCodeCompTo.TabStop = False
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(7, 32)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl3.TabIndex = 153
        Me.LabelControl3.Text = "Address"
        '
        'PanelControlTopMiddle
        '
        Me.PanelControlTopMiddle.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlTopMiddle.Controls.Add(Me.LETypeSO)
        Me.PanelControlTopMiddle.Controls.Add(Me.LabelControl6)
        Me.PanelControlTopMiddle.Controls.Add(Me.LEStatusSO)
        Me.PanelControlTopMiddle.Controls.Add(Me.LabelControl8)
        Me.PanelControlTopMiddle.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControlTopMiddle.Location = New System.Drawing.Point(434, 2)
        Me.PanelControlTopMiddle.Name = "PanelControlTopMiddle"
        Me.PanelControlTopMiddle.Size = New System.Drawing.Size(224, 88)
        Me.PanelControlTopMiddle.TabIndex = 8897
        '
        'LETypeSO
        '
        Me.LETypeSO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LETypeSO.Location = New System.Drawing.Point(88, 5)
        Me.LETypeSO.Name = "LETypeSO"
        Me.LETypeSO.Properties.Appearance.Options.UseTextOptions = True
        Me.LETypeSO.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LETypeSO.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LETypeSO.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_so_type", "ID SO Type", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("so_type", "Type")})
        Me.LETypeSO.Properties.NullText = ""
        Me.LETypeSO.Properties.ShowFooter = False
        Me.LETypeSO.Size = New System.Drawing.Size(127, 20)
        Me.LETypeSO.TabIndex = 2
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(22, 8)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl6.TabIndex = 8893
        Me.LabelControl6.Text = "SO. Type"
        '
        'LEStatusSO
        '
        Me.LEStatusSO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LEStatusSO.Location = New System.Drawing.Point(88, 31)
        Me.LEStatusSO.Name = "LEStatusSO"
        Me.LEStatusSO.Properties.Appearance.Options.UseTextOptions = True
        Me.LEStatusSO.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEStatusSO.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEStatusSO.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_so_status", "ID SO Staus", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("so_status", "Status")})
        Me.LEStatusSO.Properties.NullText = ""
        Me.LEStatusSO.Properties.ShowFooter = False
        Me.LEStatusSO.Size = New System.Drawing.Size(127, 20)
        Me.LEStatusSO.TabIndex = 3
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Location = New System.Drawing.Point(22, 33)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(52, 13)
        Me.LabelControl8.TabIndex = 8894
        Me.LabelControl8.Text = "SO. Status"
        '
        'PanelControlTopRight
        '
        Me.PanelControlTopRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlTopRight.Controls.Add(Me.TxtNumber)
        Me.PanelControlTopRight.Controls.Add(Me.LabelControl5)
        Me.PanelControlTopRight.Controls.Add(Me.LabelControl7)
        Me.PanelControlTopRight.Controls.Add(Me.DEForm)
        Me.PanelControlTopRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControlTopRight.Location = New System.Drawing.Point(658, 2)
        Me.PanelControlTopRight.Name = "PanelControlTopRight"
        Me.PanelControlTopRight.Size = New System.Drawing.Size(172, 88)
        Me.PanelControlTopRight.TabIndex = 8898
        '
        'TxtNumber
        '
        Me.TxtNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNumber.EditValue = ""
        Me.TxtNumber.Location = New System.Drawing.Point(59, 30)
        Me.TxtNumber.Name = "TxtNumber"
        Me.TxtNumber.Properties.EditValueChangedDelay = 1
        Me.TxtNumber.Properties.ReadOnly = True
        Me.TxtNumber.Size = New System.Drawing.Size(103, 20)
        Me.TxtNumber.TabIndex = 5
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(11, 33)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl5.TabIndex = 155
        Me.LabelControl5.Text = "Number"
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(11, 8)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl7.TabIndex = 159
        Me.LabelControl7.Text = "Date"
        '
        'DEForm
        '
        Me.DEForm.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DEForm.EditValue = ""
        Me.DEForm.Location = New System.Drawing.Point(59, 6)
        Me.DEForm.Name = "DEForm"
        Me.DEForm.Properties.EditValueChangedDelay = 1
        Me.DEForm.Properties.ReadOnly = True
        Me.DEForm.Size = New System.Drawing.Size(103, 20)
        Me.DEForm.TabIndex = 4
        '
        'BMark
        '
        Me.BMark.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BMark.Location = New System.Drawing.Point(0, 499)
        Me.BMark.Name = "BMark"
        Me.BMark.Size = New System.Drawing.Size(832, 32)
        Me.BMark.TabIndex = 186
        Me.BMark.Text = "Mark"
        '
        'GroupControl3
        '
        Me.GroupControl3.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl3.Controls.Add(Me.PanelControlBottomRight)
        Me.GroupControl3.Controls.Add(Me.MENote)
        Me.GroupControl3.Controls.Add(Me.LabelControl18)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl3.Location = New System.Drawing.Point(0, 430)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(832, 69)
        Me.GroupControl3.TabIndex = 187
        '
        'PanelControlBottomRight
        '
        Me.PanelControlBottomRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlBottomRight.Controls.Add(Me.LEReportStatus)
        Me.PanelControlBottomRight.Controls.Add(Me.LabelControl21)
        Me.PanelControlBottomRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControlBottomRight.Location = New System.Drawing.Point(434, 2)
        Me.PanelControlBottomRight.Name = "PanelControlBottomRight"
        Me.PanelControlBottomRight.Size = New System.Drawing.Size(396, 65)
        Me.PanelControlBottomRight.TabIndex = 139
        '
        'LEReportStatus
        '
        Me.LEReportStatus.Enabled = False
        Me.LEReportStatus.Location = New System.Drawing.Point(130, 9)
        Me.LEReportStatus.Name = "LEReportStatus"
        Me.LEReportStatus.Properties.Appearance.Options.UseTextOptions = True
        Me.LEReportStatus.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEReportStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEReportStatus.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_report_status", "ID Report Status", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("report_status", "Report Status")})
        Me.LEReportStatus.Properties.NullText = ""
        Me.LEReportStatus.Properties.ShowFooter = False
        Me.LEReportStatus.Size = New System.Drawing.Size(256, 20)
        Me.LEReportStatus.TabIndex = 10
        '
        'LabelControl21
        '
        Me.LabelControl21.Location = New System.Drawing.Point(88, 11)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl21.TabIndex = 144
        Me.LabelControl21.Text = "Status"
        '
        'MENote
        '
        Me.MENote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MENote.Location = New System.Drawing.Point(79, 11)
        Me.MENote.Name = "MENote"
        Me.MENote.Properties.MaxLength = 100
        Me.MENote.Size = New System.Drawing.Size(334, 43)
        Me.MENote.TabIndex = 9
        '
        'LabelControl18
        '
        Me.LabelControl18.Location = New System.Drawing.Point(27, 14)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl18.TabIndex = 138
        Me.LabelControl18.Text = "Note"
        '
        'GroupControlList
        '
        Me.GroupControlList.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlList.Controls.Add(Me.GCItemList)
        Me.GroupControlList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlList.Enabled = False
        Me.GroupControlList.Location = New System.Drawing.Point(0, 92)
        Me.GroupControlList.Name = "GroupControlList"
        Me.GroupControlList.Size = New System.Drawing.Size(832, 338)
        Me.GroupControlList.TabIndex = 188
        Me.GroupControlList.Text = "Item List"
        '
        'GCItemList
        '
        Me.GCItemList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCItemList.Location = New System.Drawing.Point(22, 2)
        Me.GCItemList.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCItemList.MainView = Me.GVItemList
        Me.GCItemList.Name = "GCItemList"
        Me.GCItemList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1})
        Me.GCItemList.Size = New System.Drawing.Size(808, 334)
        Me.GCItemList.TabIndex = 2
        Me.GCItemList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVItemList})
        '
        'GVItemList
        '
        Me.GVItemList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNo, Me.GridColumnCode, Me.GridColumnName, Me.GridColumnSize, Me.GridColumnUOM, Me.GridColumnPriceType, Me.GridColumnQty, Me.GridColumnPrice, Me.GridColumnAmount, Me.GridColumnRemark, Me.GridColumnIdSample, Me.GridColumnIdSalesOrderDet, Me.GridColumnIdSampleRetPrice})
        Me.GVItemList.GridControl = Me.GCItemList
        Me.GVItemList.Name = "GVItemList"
        Me.GVItemList.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVItemList.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVItemList.OptionsBehavior.ReadOnly = True
        Me.GVItemList.OptionsCustomization.AllowGroup = False
        Me.GVItemList.OptionsCustomization.AllowQuickHideColumns = False
        Me.GVItemList.OptionsView.ShowFooter = True
        Me.GVItemList.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.OptionsColumn.AllowEdit = False
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 42
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.OptionsColumn.AllowEdit = False
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 1
        Me.GridColumnCode.Width = 69
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Description"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.FieldNameSortGroup = "id_sample"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.OptionsColumn.AllowEdit = False
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 2
        Me.GridColumnName.Width = 142
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
        Me.GridColumnSize.OptionsColumn.AllowEdit = False
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 3
        Me.GridColumnSize.Width = 53
        '
        'GridColumnUOM
        '
        Me.GridColumnUOM.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnUOM.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnUOM.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnUOM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnUOM.Caption = "UOM"
        Me.GridColumnUOM.FieldName = "uom"
        Me.GridColumnUOM.Name = "GridColumnUOM"
        Me.GridColumnUOM.OptionsColumn.AllowEdit = False
        Me.GridColumnUOM.Width = 71
        '
        'GridColumnPriceType
        '
        Me.GridColumnPriceType.Caption = "Price Type"
        Me.GridColumnPriceType.FieldName = "design_price_type"
        Me.GridColumnPriceType.Name = "GridColumnPriceType"
        Me.GridColumnPriceType.OptionsColumn.AllowEdit = False
        Me.GridColumnPriceType.Width = 98
        '
        'GridColumnQty
        '
        Me.GridColumnQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.DisplayFormat.FormatString = "F2"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "sample_order_det_qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.OptionsColumn.AllowEdit = False
        Me.GridColumnQty.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sample_order_det_qty", "{0:f2}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 5
        Me.GridColumnQty.Width = 88
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPrice.Caption = "Price"
        Me.GridColumnPrice.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "sample_ret_price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.OptionsColumn.AllowEdit = False
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 4
        Me.GridColumnPrice.Width = 106
        '
        'GridColumnAmount
        '
        Me.GridColumnAmount.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnAmount.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnAmount.Caption = "Amount"
        Me.GridColumnAmount.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAmount.FieldName = "sample_order_det_amount"
        Me.GridColumnAmount.Name = "GridColumnAmount"
        Me.GridColumnAmount.OptionsColumn.AllowEdit = False
        Me.GridColumnAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sample_order_det_amount", "{0:n2}")})
        Me.GridColumnAmount.Visible = True
        Me.GridColumnAmount.VisibleIndex = 6
        Me.GridColumnAmount.Width = 121
        '
        'GridColumnRemark
        '
        Me.GridColumnRemark.Caption = "Remark"
        Me.GridColumnRemark.FieldName = "sample_order_det_note"
        Me.GridColumnRemark.Name = "GridColumnRemark"
        Me.GridColumnRemark.Visible = True
        Me.GridColumnRemark.VisibleIndex = 7
        Me.GridColumnRemark.Width = 225
        '
        'GridColumnIdSample
        '
        Me.GridColumnIdSample.Caption = "Id Sample"
        Me.GridColumnIdSample.FieldName = "id_sample"
        Me.GridColumnIdSample.Name = "GridColumnIdSample"
        Me.GridColumnIdSample.OptionsColumn.AllowEdit = False
        Me.GridColumnIdSample.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnIdSample.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdSalesOrderDet
        '
        Me.GridColumnIdSalesOrderDet.Caption = "Id Sample Order Det"
        Me.GridColumnIdSalesOrderDet.FieldName = "id_sample_order_det"
        Me.GridColumnIdSalesOrderDet.Name = "GridColumnIdSalesOrderDet"
        Me.GridColumnIdSalesOrderDet.OptionsColumn.AllowEdit = False
        Me.GridColumnIdSalesOrderDet.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnIdSalesOrderDet.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdSampleRetPrice
        '
        Me.GridColumnIdSampleRetPrice.Caption = "Id Sample Ret Price"
        Me.GridColumnIdSampleRetPrice.FieldName = "id_sample_ret_price"
        Me.GridColumnIdSampleRetPrice.Name = "GridColumnIdSampleRetPrice"
        Me.GridColumnIdSampleRetPrice.OptionsColumn.AllowEdit = False
        Me.GridColumnIdSampleRetPrice.OptionsColumn.ShowInCustomizationForm = False
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "f0"
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'FormViewSampleOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(832, 531)
        Me.Controls.Add(Me.GroupControlList)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.BMark)
        Me.Controls.Add(Me.GroupGeneralHeader)
        Me.MinimizeBox = False
        Me.Name = "FormViewSampleOrder"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales Order Sample"
        CType(Me.GroupGeneralHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneralHeader.ResumeLayout(False)
        CType(Me.PanelControlTopLeft, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlTopLeft.ResumeLayout(False)
        Me.PanelControlTopLeft.PerformLayout()
        CType(Me.TxtNameCompTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEAdrressCompTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodeCompTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlTopMiddle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlTopMiddle.ResumeLayout(False)
        Me.PanelControlTopMiddle.PerformLayout()
        CType(Me.LETypeSO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEStatusSO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlTopRight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlTopRight.ResumeLayout(False)
        Me.PanelControlTopRight.PerformLayout()
        CType(Me.TxtNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEForm.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        CType(Me.PanelControlBottomRight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlBottomRight.ResumeLayout(False)
        Me.PanelControlBottomRight.PerformLayout()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlList.ResumeLayout(False)
        CType(Me.GCItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupGeneralHeader As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PanelControlTopLeft As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TxtNameCompTo As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents MEAdrressCompTo As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtCodeCompTo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControlTopMiddle As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LETypeSO As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEStatusSO As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControlTopRight As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TxtNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEForm As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PanelControlBottomRight As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LEReportStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControlList As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCItemList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVItemList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPriceType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRemark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSalesOrderDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSampleRetPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
End Class
