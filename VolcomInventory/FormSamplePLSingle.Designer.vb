<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSamplePLSingle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSamplePLSingle))
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl
        Me.GConListPL = New DevExpress.XtraEditors.GroupControl
        Me.GCListPurchase = New DevExpress.XtraGrid.GridControl
        Me.GVListPurchase = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnUOM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQtyIssue = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQtyNote = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdSamplePurcRecDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColQtyReceived = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdPLDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdSampleRec = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdPLRec = New DevExpress.XtraGrid.Columns.GridColumn
        Me.PanelControl8 = New DevExpress.XtraEditors.PanelControl
        Me.BtnEditPL = New DevExpress.XtraEditors.SimpleButton
        Me.PanelControl11 = New DevExpress.XtraEditors.PanelControl
        Me.BtnAddPL = New DevExpress.XtraEditors.SimpleButton
        Me.BtnDelPL = New DevExpress.XtraEditors.SimpleButton
        Me.GroupControlDetailSingle = New DevExpress.XtraEditors.GroupControl
        Me.GCDetail = New DevExpress.XtraGrid.GridControl
        Me.GVDetail = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnSampleCodeUnique = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnNoDetail = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnNoteReceiptSampleDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdSampleUnique = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDetailIdRecDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdPLDetDetail = New DevExpress.XtraGrid.Columns.GridColumn
        Me.PanelControl9 = New DevExpress.XtraEditors.PanelControl
        Me.PanelControl10 = New DevExpress.XtraEditors.PanelControl
        Me.BAdd = New DevExpress.XtraEditors.SimpleButton
        Me.Bdel = New DevExpress.XtraEditors.SimpleButton
        Me.GroupGeneralHeader = New DevExpress.XtraEditors.GroupControl
        Me.GCReceiving = New DevExpress.XtraGrid.GridControl
        Me.GVReceiving = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl
        Me.TxtOrderNumber = New DevExpress.XtraEditors.TextEdit
        Me.LEPLCategory = New DevExpress.XtraEditors.LookUpEdit
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.DEPL = New DevExpress.XtraEditors.DateEdit
        Me.TxtNameCompFrom = New DevExpress.XtraEditors.TextEdit
        Me.TxtPLNumber = New DevExpress.XtraEditors.TextEdit
        Me.MEAdrressCompTo = New DevExpress.XtraEditors.MemoEdit
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl
        Me.TxtCodeCompFrom = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton
        Me.BtnPopTo = New DevExpress.XtraEditors.SimpleButton
        Me.TxtCodeCompTo = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.TxtNameCompTo = New DevExpress.XtraEditors.TextEdit
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl
        Me.MENote = New DevExpress.XtraEditors.MemoEdit
        Me.LEReportStatus = New DevExpress.XtraEditors.LookUpEdit
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl
        Me.PanelControl5 = New DevExpress.XtraEditors.PanelControl
        Me.BMark = New DevExpress.XtraEditors.SimpleButton
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.ErrorProviderPL = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GConListPL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GConListPL.SuspendLayout()
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl8.SuspendLayout()
        CType(Me.PanelControl11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl11.SuspendLayout()
        CType(Me.GroupControlDetailSingle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlDetailSingle.SuspendLayout()
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl9.SuspendLayout()
        CType(Me.PanelControl10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl10.SuspendLayout()
        CType(Me.GroupGeneralHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneralHeader.SuspendLayout()
        CType(Me.GCReceiving, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVReceiving, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtOrderNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEPLCategory.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEPL.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEPL.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNameCompFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPLNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEAdrressCompTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodeCompFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodeCompTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNameCompTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl5.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.ErrorProviderPL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 177)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GConListPL)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GroupControlDetailSingle)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(892, 349)
        Me.SplitContainerControl1.SplitterPosition = 162
        Me.SplitContainerControl1.TabIndex = 31
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'GConListPL
        '
        Me.GConListPL.AppearanceCaption.Options.UseTextOptions = True
        Me.GConListPL.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GConListPL.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GConListPL.Controls.Add(Me.GCListPurchase)
        Me.GConListPL.Controls.Add(Me.PanelControl8)
        Me.GConListPL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GConListPL.Enabled = False
        Me.GConListPL.Location = New System.Drawing.Point(0, 0)
        Me.GConListPL.Name = "GConListPL"
        Me.GConListPL.Size = New System.Drawing.Size(892, 162)
        Me.GConListPL.TabIndex = 23
        Me.GConListPL.Text = "Packing List Data"
        '
        'GCListPurchase
        '
        Me.GCListPurchase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListPurchase.Location = New System.Drawing.Point(22, 2)
        Me.GCListPurchase.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCListPurchase.MainView = Me.GVListPurchase
        Me.GCListPurchase.Name = "GCListPurchase"
        Me.GCListPurchase.Size = New System.Drawing.Size(868, 121)
        Me.GCListPurchase.TabIndex = 24
        Me.GCListPurchase.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListPurchase})
        '
        'GVListPurchase
        '
        Me.GVListPurchase.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColNo, Me.ColCode, Me.ColName, Me.ColSize, Me.GridColumnUOM, Me.GridColumnQtyIssue, Me.GridColumnQtyNote, Me.ColIdSamplePurcRecDet, Me.ColQtyReceived, Me.GridColumnIdPLDet, Me.GridColumnIdSampleRec, Me.GridColumnIdPLRec})
        Me.GVListPurchase.GridControl = Me.GCListPurchase
        Me.GVListPurchase.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.GVListPurchase.Name = "GVListPurchase"
        Me.GVListPurchase.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVListPurchase.OptionsFind.AlwaysVisible = True
        Me.GVListPurchase.OptionsView.ShowGroupPanel = False
        '
        'ColNo
        '
        Me.ColNo.AppearanceCell.Options.UseTextOptions = True
        Me.ColNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColNo.AppearanceHeader.Options.UseTextOptions = True
        Me.ColNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColNo.Caption = "No"
        Me.ColNo.FieldName = "no"
        Me.ColNo.Name = "ColNo"
        Me.ColNo.OptionsColumn.AllowEdit = False
        Me.ColNo.Width = 30
        '
        'ColCode
        '
        Me.ColCode.Caption = "Code"
        Me.ColCode.FieldName = "code"
        Me.ColCode.Name = "ColCode"
        Me.ColCode.OptionsColumn.AllowEdit = False
        Me.ColCode.Visible = True
        Me.ColCode.VisibleIndex = 0
        Me.ColCode.Width = 140
        '
        'ColName
        '
        Me.ColName.Caption = "Name"
        Me.ColName.FieldName = "name"
        Me.ColName.Name = "ColName"
        Me.ColName.OptionsColumn.AllowEdit = False
        Me.ColName.Visible = True
        Me.ColName.VisibleIndex = 1
        Me.ColName.Width = 235
        '
        'ColSize
        '
        Me.ColSize.AppearanceCell.Options.UseTextOptions = True
        Me.ColSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ColSize.AppearanceHeader.Options.UseTextOptions = True
        Me.ColSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ColSize.Caption = "Size"
        Me.ColSize.FieldName = "size"
        Me.ColSize.Name = "ColSize"
        Me.ColSize.OptionsColumn.AllowEdit = False
        Me.ColSize.Visible = True
        Me.ColSize.VisibleIndex = 2
        Me.ColSize.Width = 140
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
        'GridColumnQtyIssue
        '
        Me.GridColumnQtyIssue.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQtyIssue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyIssue.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQtyIssue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyIssue.Caption = "Qty "
        Me.GridColumnQtyIssue.FieldName = "qty_issue"
        Me.GridColumnQtyIssue.Name = "GridColumnQtyIssue"
        Me.GridColumnQtyIssue.OptionsColumn.AllowEdit = False
        Me.GridColumnQtyIssue.Visible = True
        Me.GridColumnQtyIssue.VisibleIndex = 4
        '
        'GridColumnQtyNote
        '
        Me.GridColumnQtyNote.Caption = "Note"
        Me.GridColumnQtyNote.FieldName = "pl_sample_purc_det_note"
        Me.GridColumnQtyNote.Name = "GridColumnQtyNote"
        Me.GridColumnQtyNote.Visible = True
        Me.GridColumnQtyNote.VisibleIndex = 5
        '
        'ColIdSamplePurcRecDet
        '
        Me.ColIdSamplePurcRecDet.Caption = "ID Sample Detail"
        Me.ColIdSamplePurcRecDet.FieldName = "id_sample_purc_det"
        Me.ColIdSamplePurcRecDet.Name = "ColIdSamplePurcRecDet"
        Me.ColIdSamplePurcRecDet.OptionsColumn.AllowEdit = False
        Me.ColIdSamplePurcRecDet.OptionsColumn.ShowInCustomizationForm = False
        '
        'ColQtyReceived
        '
        Me.ColQtyReceived.AppearanceCell.Options.UseTextOptions = True
        Me.ColQtyReceived.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQtyReceived.AppearanceHeader.Options.UseTextOptions = True
        Me.ColQtyReceived.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQtyReceived.Caption = "Qty Received"
        Me.ColQtyReceived.FieldName = "sample_purc_rec_det_qty"
        Me.ColQtyReceived.Name = "ColQtyReceived"
        Me.ColQtyReceived.OptionsColumn.AllowEdit = False
        Me.ColQtyReceived.OptionsColumn.ShowInCustomizationForm = False
        Me.ColQtyReceived.Width = 68
        '
        'GridColumnIdPLDet
        '
        Me.GridColumnIdPLDet.Caption = "Id PL Detail"
        Me.GridColumnIdPLDet.FieldName = "id_pl_sample_purc_det"
        Me.GridColumnIdPLDet.Name = "GridColumnIdPLDet"
        Me.GridColumnIdPLDet.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdSampleRec
        '
        Me.GridColumnIdSampleRec.Caption = "Id Sample Rec"
        Me.GridColumnIdSampleRec.FieldName = "id_sample_purc_rec"
        Me.GridColumnIdSampleRec.Name = "GridColumnIdSampleRec"
        Me.GridColumnIdSampleRec.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdPLRec
        '
        Me.GridColumnIdPLRec.Caption = "Id PL Rec"
        Me.GridColumnIdPLRec.FieldName = "id_pl_sample_purc_rec"
        Me.GridColumnIdPLRec.Name = "GridColumnIdPLRec"
        Me.GridColumnIdPLRec.OptionsColumn.ShowInCustomizationForm = False
        '
        'PanelControl8
        '
        Me.PanelControl8.Controls.Add(Me.BtnEditPL)
        Me.PanelControl8.Controls.Add(Me.PanelControl11)
        Me.PanelControl8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl8.Location = New System.Drawing.Point(22, 123)
        Me.PanelControl8.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.PanelControl8.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl8.Name = "PanelControl8"
        Me.PanelControl8.Size = New System.Drawing.Size(868, 37)
        Me.PanelControl8.TabIndex = 23
        Me.PanelControl8.Visible = False
        '
        'BtnEditPL
        '
        Me.BtnEditPL.Location = New System.Drawing.Point(8, 6)
        Me.BtnEditPL.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.BtnEditPL.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnEditPL.Name = "BtnEditPL"
        Me.BtnEditPL.Size = New System.Drawing.Size(90, 24)
        Me.BtnEditPL.TabIndex = 24
        Me.BtnEditPL.Text = "Edit"
        Me.BtnEditPL.Visible = False
        '
        'PanelControl11
        '
        Me.PanelControl11.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl11.Controls.Add(Me.BtnAddPL)
        Me.PanelControl11.Controls.Add(Me.BtnDelPL)
        Me.PanelControl11.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl11.Location = New System.Drawing.Point(560, 2)
        Me.PanelControl11.Name = "PanelControl11"
        Me.PanelControl11.Size = New System.Drawing.Size(306, 33)
        Me.PanelControl11.TabIndex = 24
        '
        'BtnAddPL
        '
        Me.BtnAddPL.Location = New System.Drawing.Point(211, 4)
        Me.BtnAddPL.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.BtnAddPL.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnAddPL.Name = "BtnAddPL"
        Me.BtnAddPL.Size = New System.Drawing.Size(90, 24)
        Me.BtnAddPL.TabIndex = 23
        Me.BtnAddPL.Text = "Add"
        '
        'BtnDelPL
        '
        Me.BtnDelPL.Location = New System.Drawing.Point(115, 4)
        Me.BtnDelPL.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.BtnDelPL.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnDelPL.Name = "BtnDelPL"
        Me.BtnDelPL.Size = New System.Drawing.Size(90, 24)
        Me.BtnDelPL.TabIndex = 22
        Me.BtnDelPL.Text = "Delete"
        '
        'GroupControlDetailSingle
        '
        Me.GroupControlDetailSingle.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlDetailSingle.Controls.Add(Me.GCDetail)
        Me.GroupControlDetailSingle.Controls.Add(Me.PanelControl9)
        Me.GroupControlDetailSingle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlDetailSingle.Enabled = False
        Me.GroupControlDetailSingle.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlDetailSingle.Name = "GroupControlDetailSingle"
        Me.GroupControlDetailSingle.Size = New System.Drawing.Size(892, 181)
        Me.GroupControlDetailSingle.TabIndex = 2
        Me.GroupControlDetailSingle.Text = "Detail Data"
        '
        'GCDetail
        '
        Me.GCDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDetail.Location = New System.Drawing.Point(22, 2)
        Me.GCDetail.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCDetail.MainView = Me.GVDetail
        Me.GCDetail.Name = "GCDetail"
        Me.GCDetail.Size = New System.Drawing.Size(868, 139)
        Me.GCDetail.TabIndex = 23
        Me.GCDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDetail})
        '
        'GVDetail
        '
        Me.GVDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnSampleCodeUnique, Me.GridColumnNoDetail, Me.GridColumnNoteReceiptSampleDet, Me.GridColumnIdSampleUnique, Me.GridColumnDetailIdRecDet, Me.GridColumnIdPLDetDetail})
        Me.GVDetail.GridControl = Me.GCDetail
        Me.GVDetail.Name = "GVDetail"
        Me.GVDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVDetail.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVDetail.OptionsFind.AlwaysVisible = True
        Me.GVDetail.OptionsNavigation.AutoFocusNewRow = True
        Me.GVDetail.OptionsView.ShowGroupPanel = False
        '
        'GridColumnSampleCodeUnique
        '
        Me.GridColumnSampleCodeUnique.Caption = "Code "
        Me.GridColumnSampleCodeUnique.FieldName = "sample_unique_code"
        Me.GridColumnSampleCodeUnique.Name = "GridColumnSampleCodeUnique"
        Me.GridColumnSampleCodeUnique.OptionsColumn.AllowEdit = False
        Me.GridColumnSampleCodeUnique.Visible = True
        Me.GridColumnSampleCodeUnique.VisibleIndex = 0
        '
        'GridColumnNoDetail
        '
        Me.GridColumnNoDetail.Caption = "No"
        Me.GridColumnNoDetail.FieldName = "no_row"
        Me.GridColumnNoDetail.Name = "GridColumnNoDetail"
        Me.GridColumnNoDetail.OptionsColumn.AllowEdit = False
        Me.GridColumnNoDetail.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnNoteReceiptSampleDet
        '
        Me.GridColumnNoteReceiptSampleDet.Caption = "Note"
        Me.GridColumnNoteReceiptSampleDet.FieldName = "note_receipt_sample_det"
        Me.GridColumnNoteReceiptSampleDet.Name = "GridColumnNoteReceiptSampleDet"
        Me.GridColumnNoteReceiptSampleDet.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdSampleUnique
        '
        Me.GridColumnIdSampleUnique.Caption = "Id Sample Unique"
        Me.GridColumnIdSampleUnique.FieldName = "id_sample_unique"
        Me.GridColumnIdSampleUnique.Name = "GridColumnIdSampleUnique"
        Me.GridColumnIdSampleUnique.OptionsColumn.AllowEdit = False
        Me.GridColumnIdSampleUnique.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnDetailIdRecDet
        '
        Me.GridColumnDetailIdRecDet.Caption = "Id Rec Det"
        Me.GridColumnDetailIdRecDet.FieldName = "id_sample_purc_det"
        Me.GridColumnDetailIdRecDet.Name = "GridColumnDetailIdRecDet"
        Me.GridColumnDetailIdRecDet.OptionsColumn.AllowEdit = False
        Me.GridColumnDetailIdRecDet.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdPLDetDetail
        '
        Me.GridColumnIdPLDetDetail.Caption = "id pl sample purc det unique"
        Me.GridColumnIdPLDetDetail.FieldName = "id_pl_sample_purc_det_unique"
        Me.GridColumnIdPLDetDetail.Name = "GridColumnIdPLDetDetail"
        Me.GridColumnIdPLDetDetail.OptionsColumn.ShowInCustomizationForm = False
        '
        'PanelControl9
        '
        Me.PanelControl9.Controls.Add(Me.PanelControl10)
        Me.PanelControl9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl9.Location = New System.Drawing.Point(22, 141)
        Me.PanelControl9.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.PanelControl9.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl9.Name = "PanelControl9"
        Me.PanelControl9.Size = New System.Drawing.Size(868, 38)
        Me.PanelControl9.TabIndex = 22
        '
        'PanelControl10
        '
        Me.PanelControl10.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl10.Controls.Add(Me.BAdd)
        Me.PanelControl10.Controls.Add(Me.Bdel)
        Me.PanelControl10.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl10.Location = New System.Drawing.Point(560, 2)
        Me.PanelControl10.Name = "PanelControl10"
        Me.PanelControl10.Size = New System.Drawing.Size(306, 34)
        Me.PanelControl10.TabIndex = 22
        '
        'BAdd
        '
        Me.BAdd.Location = New System.Drawing.Point(200, 3)
        Me.BAdd.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.BAdd.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BAdd.Name = "BAdd"
        Me.BAdd.Size = New System.Drawing.Size(101, 24)
        Me.BAdd.TabIndex = 21
        Me.BAdd.Text = "Add (Press F5)"
        '
        'Bdel
        '
        Me.Bdel.Location = New System.Drawing.Point(84, 3)
        Me.Bdel.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.Bdel.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Bdel.Name = "Bdel"
        Me.Bdel.Size = New System.Drawing.Size(110, 24)
        Me.Bdel.TabIndex = 20
        Me.Bdel.Text = "Del (Press F6)"
        '
        'GroupGeneralHeader
        '
        Me.GroupGeneralHeader.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupGeneralHeader.Controls.Add(Me.GCReceiving)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl8)
        Me.GroupGeneralHeader.Controls.Add(Me.TxtOrderNumber)
        Me.GroupGeneralHeader.Controls.Add(Me.LEPLCategory)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl5)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl2)
        Me.GroupGeneralHeader.Controls.Add(Me.DEPL)
        Me.GroupGeneralHeader.Controls.Add(Me.TxtNameCompFrom)
        Me.GroupGeneralHeader.Controls.Add(Me.TxtPLNumber)
        Me.GroupGeneralHeader.Controls.Add(Me.MEAdrressCompTo)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl7)
        Me.GroupGeneralHeader.Controls.Add(Me.TxtCodeCompFrom)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl6)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl3)
        Me.GroupGeneralHeader.Controls.Add(Me.SimpleButton1)
        Me.GroupGeneralHeader.Controls.Add(Me.BtnPopTo)
        Me.GroupGeneralHeader.Controls.Add(Me.TxtCodeCompTo)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl4)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl1)
        Me.GroupGeneralHeader.Controls.Add(Me.TxtNameCompTo)
        Me.GroupGeneralHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupGeneralHeader.Location = New System.Drawing.Point(0, 0)
        Me.GroupGeneralHeader.Name = "GroupGeneralHeader"
        Me.GroupGeneralHeader.Size = New System.Drawing.Size(892, 177)
        Me.GroupGeneralHeader.TabIndex = 28
        '
        'GCReceiving
        '
        Me.GCReceiving.Enabled = False
        Me.GCReceiving.Location = New System.Drawing.Point(567, 71)
        Me.GCReceiving.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCReceiving.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GCReceiving.MainView = Me.GVReceiving
        Me.GCReceiving.Name = "GCReceiving"
        Me.GCReceiving.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCReceiving.Size = New System.Drawing.Size(301, 85)
        Me.GCReceiving.TabIndex = 161
        Me.GCReceiving.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVReceiving})
        '
        'GVReceiving
        '
        Me.GVReceiving.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3})
        Me.GVReceiving.GridControl = Me.GCReceiving
        Me.GVReceiving.Name = "GVReceiving"
        Me.GVReceiving.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id Receiving"
        Me.GridColumn1.FieldName = "id_sample_purc_rec"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Receiving"
        Me.GridColumn2.FieldName = "sample_purc_rec_number"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Choose Receiving"
        Me.GridColumn3.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumn3.FieldName = "choose_receiving"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Location = New System.Drawing.Point(485, 71)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl8.TabIndex = 160
        Me.LabelControl8.Text = "Receiving"
        '
        'TxtOrderNumber
        '
        Me.TxtOrderNumber.EditValue = ""
        Me.TxtOrderNumber.Location = New System.Drawing.Point(108, 12)
        Me.TxtOrderNumber.Name = "TxtOrderNumber"
        Me.TxtOrderNumber.Properties.EditValueChangedDelay = 1
        Me.TxtOrderNumber.Properties.ReadOnly = True
        Me.TxtOrderNumber.Size = New System.Drawing.Size(286, 20)
        Me.TxtOrderNumber.TabIndex = 0
        '
        'LEPLCategory
        '
        Me.LEPLCategory.Location = New System.Drawing.Point(568, 41)
        Me.LEPLCategory.Name = "LEPLCategory"
        Me.LEPLCategory.Properties.Appearance.Options.UseTextOptions = True
        Me.LEPLCategory.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEPLCategory.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEPLCategory.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_pl_category", "Id  PL Category", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("pl_category", "PL Category")})
        Me.LEPLCategory.Properties.NullText = ""
        Me.LEPLCategory.Properties.ShowFooter = False
        Me.LEPLCategory.Size = New System.Drawing.Size(301, 20)
        Me.LEPLCategory.TabIndex = 10
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(485, 18)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl5.TabIndex = 155
        Me.LabelControl5.Text = "PL Number"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(27, 71)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(12, 13)
        Me.LabelControl2.TabIndex = 149
        Me.LabelControl2.Text = "To"
        '
        'DEPL
        '
        Me.DEPL.EditValue = Nothing
        Me.DEPL.Location = New System.Drawing.Point(724, 15)
        Me.DEPL.Name = "DEPL"
        Me.DEPL.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEPL.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.DEPL.Size = New System.Drawing.Size(144, 20)
        Me.DEPL.TabIndex = 9
        '
        'TxtNameCompFrom
        '
        Me.TxtNameCompFrom.EditValue = ""
        Me.TxtNameCompFrom.Location = New System.Drawing.Point(216, 41)
        Me.TxtNameCompFrom.Name = "TxtNameCompFrom"
        Me.TxtNameCompFrom.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNameCompFrom.Properties.Appearance.Options.UseFont = True
        Me.TxtNameCompFrom.Properties.EditValueChangedDelay = 1
        Me.TxtNameCompFrom.Properties.ReadOnly = True
        Me.TxtNameCompFrom.Size = New System.Drawing.Size(207, 20)
        Me.TxtNameCompFrom.TabIndex = 3
        Me.TxtNameCompFrom.TabStop = False
        '
        'TxtPLNumber
        '
        Me.TxtPLNumber.EditValue = ""
        Me.TxtPLNumber.Location = New System.Drawing.Point(567, 15)
        Me.TxtPLNumber.Name = "TxtPLNumber"
        Me.TxtPLNumber.Properties.EditValueChangedDelay = 1
        Me.TxtPLNumber.Size = New System.Drawing.Size(112, 20)
        Me.TxtPLNumber.TabIndex = 8
        '
        'MEAdrressCompTo
        '
        Me.MEAdrressCompTo.Location = New System.Drawing.Point(108, 96)
        Me.MEAdrressCompTo.Name = "MEAdrressCompTo"
        Me.MEAdrressCompTo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MEAdrressCompTo.Properties.Appearance.Options.UseFont = True
        Me.MEAdrressCompTo.Properties.ReadOnly = True
        Me.MEAdrressCompTo.Size = New System.Drawing.Size(315, 60)
        Me.MEAdrressCompTo.TabIndex = 7
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(695, 19)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl7.TabIndex = 159
        Me.LabelControl7.Text = "Date"
        '
        'TxtCodeCompFrom
        '
        Me.TxtCodeCompFrom.EditValue = ""
        Me.TxtCodeCompFrom.Location = New System.Drawing.Point(108, 41)
        Me.TxtCodeCompFrom.Name = "TxtCodeCompFrom"
        Me.TxtCodeCompFrom.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodeCompFrom.Properties.Appearance.Options.UseFont = True
        Me.TxtCodeCompFrom.Properties.EditValueChangedDelay = 1
        Me.TxtCodeCompFrom.Properties.ReadOnly = True
        Me.TxtCodeCompFrom.Size = New System.Drawing.Size(102, 20)
        Me.TxtCodeCompFrom.TabIndex = 2
        Me.TxtCodeCompFrom.TabStop = False
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(485, 44)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl6.TabIndex = 158
        Me.LabelControl6.Text = "PL Category"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(27, 98)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl3.TabIndex = 153
        Me.LabelControl3.Text = "Address"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.Location = New System.Drawing.Point(400, 12)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(23, 20)
        Me.SimpleButton1.TabIndex = 1
        Me.SimpleButton1.Text = "..."
        '
        'BtnPopTo
        '
        Me.BtnPopTo.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPopTo.Appearance.Options.UseFont = True
        Me.BtnPopTo.Location = New System.Drawing.Point(400, 68)
        Me.BtnPopTo.Name = "BtnPopTo"
        Me.BtnPopTo.Size = New System.Drawing.Size(23, 20)
        Me.BtnPopTo.TabIndex = 6
        Me.BtnPopTo.Text = "..."
        '
        'TxtCodeCompTo
        '
        Me.TxtCodeCompTo.EditValue = ""
        Me.TxtCodeCompTo.Location = New System.Drawing.Point(108, 68)
        Me.TxtCodeCompTo.Name = "TxtCodeCompTo"
        Me.TxtCodeCompTo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodeCompTo.Properties.Appearance.Options.UseFont = True
        Me.TxtCodeCompTo.Properties.EditValueChangedDelay = 1
        Me.TxtCodeCompTo.Properties.ReadOnly = True
        Me.TxtCodeCompTo.Size = New System.Drawing.Size(102, 20)
        Me.TxtCodeCompTo.TabIndex = 4
        Me.TxtCodeCompTo.TabStop = False
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(27, 19)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl4.TabIndex = 88
        Me.LabelControl4.Text = "PO Number"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(27, 44)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl1.TabIndex = 145
        Me.LabelControl1.Text = "From"
        '
        'TxtNameCompTo
        '
        Me.TxtNameCompTo.EditValue = ""
        Me.TxtNameCompTo.Location = New System.Drawing.Point(214, 68)
        Me.TxtNameCompTo.Name = "TxtNameCompTo"
        Me.TxtNameCompTo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNameCompTo.Properties.Appearance.Options.UseFont = True
        Me.TxtNameCompTo.Properties.EditValueChangedDelay = 1
        Me.TxtNameCompTo.Properties.ReadOnly = True
        Me.TxtNameCompTo.Size = New System.Drawing.Size(180, 20)
        Me.TxtNameCompTo.TabIndex = 5
        Me.TxtNameCompTo.TabStop = False
        '
        'GroupControl3
        '
        Me.GroupControl3.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl3.Controls.Add(Me.LabelControl21)
        Me.GroupControl3.Controls.Add(Me.MENote)
        Me.GroupControl3.Controls.Add(Me.LEReportStatus)
        Me.GroupControl3.Controls.Add(Me.LabelControl18)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl3.Location = New System.Drawing.Point(0, 526)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(892, 97)
        Me.GroupControl3.TabIndex = 32
        '
        'LabelControl21
        '
        Me.LabelControl21.Location = New System.Drawing.Point(505, 17)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl21.TabIndex = 144
        Me.LabelControl21.Text = "Status"
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(121, 15)
        Me.MENote.Name = "MENote"
        Me.MENote.Properties.MaxLength = 100
        Me.MENote.Size = New System.Drawing.Size(302, 62)
        Me.MENote.TabIndex = 11
        '
        'LEReportStatus
        '
        Me.LEReportStatus.Enabled = False
        Me.LEReportStatus.Location = New System.Drawing.Point(582, 14)
        Me.LEReportStatus.Name = "LEReportStatus"
        Me.LEReportStatus.Properties.Appearance.Options.UseTextOptions = True
        Me.LEReportStatus.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEReportStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEReportStatus.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_report_status", "ID Report Status", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("report_status", "Report Status")})
        Me.LEReportStatus.Properties.NullText = ""
        Me.LEReportStatus.Properties.ShowFooter = False
        Me.LEReportStatus.Size = New System.Drawing.Size(287, 20)
        Me.LEReportStatus.TabIndex = 12
        '
        'LabelControl18
        '
        Me.LabelControl18.Location = New System.Drawing.Point(43, 17)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl18.TabIndex = 138
        Me.LabelControl18.Text = "Note"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.PanelControl5)
        Me.PanelControl3.Controls.Add(Me.PanelControl1)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 620)
        Me.PanelControl3.LookAndFeel.SkinName = "Blue"
        Me.PanelControl3.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(892, 58)
        Me.PanelControl3.TabIndex = 33
        '
        'PanelControl5
        '
        Me.PanelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl5.Controls.Add(Me.BMark)
        Me.PanelControl5.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl5.Location = New System.Drawing.Point(2, 2)
        Me.PanelControl5.Name = "PanelControl5"
        Me.PanelControl5.Size = New System.Drawing.Size(443, 54)
        Me.PanelControl5.TabIndex = 18
        '
        'BMark
        '
        Me.BMark.Location = New System.Drawing.Point(20, 14)
        Me.BMark.Name = "BMark"
        Me.BMark.Size = New System.Drawing.Size(75, 23)
        Me.BMark.TabIndex = 16
        Me.BMark.Text = "Mark"
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.BtnSave)
        Me.PanelControl1.Controls.Add(Me.BtnPrint)
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl1.Location = New System.Drawing.Point(582, 2)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(308, 54)
        Me.PanelControl1.TabIndex = 17
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(211, 15)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 13
        Me.BtnSave.Text = "Save"
        '
        'BtnPrint
        '
        Me.BtnPrint.Location = New System.Drawing.Point(49, 15)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrint.TabIndex = 14
        Me.BtnPrint.Text = "Print"
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(130, 15)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 15
        Me.BtnCancel.Text = "Cancel"
        '
        'ErrorProviderPL
        '
        Me.ErrorProviderPL.ContainerControl = Me
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "20_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "8_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "23_24x24.png")
        '
        'FormSamplePLSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 678)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Controls.Add(Me.GroupGeneralHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSamplePLSingle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Packing List Sample"
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GConListPL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GConListPL.ResumeLayout(False)
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl8.ResumeLayout(False)
        CType(Me.PanelControl11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl11.ResumeLayout(False)
        CType(Me.GroupControlDetailSingle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlDetailSingle.ResumeLayout(False)
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl9.ResumeLayout(False)
        CType(Me.PanelControl10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl10.ResumeLayout(False)
        CType(Me.GroupGeneralHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneralHeader.ResumeLayout(False)
        Me.GroupGeneralHeader.PerformLayout()
        CType(Me.GCReceiving, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVReceiving, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtOrderNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEPLCategory.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEPL.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEPL.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNameCompFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPLNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEAdrressCompTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodeCompFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodeCompTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNameCompTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl5.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.ErrorProviderPL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GConListPL As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCListPurchase As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListPurchase As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyIssue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdSamplePurcRecDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColQtyReceived As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdPLDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSampleRec As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdPLRec As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl8 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnEditPL As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl11 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnAddPL As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnDelPL As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControlDetailSingle As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnSampleCodeUnique As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNoDetail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNoteReceiptSampleDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSampleUnique As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDetailIdRecDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdPLDetDetail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl9 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl10 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Bdel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupGeneralHeader As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCReceiving As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVReceiving As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtOrderNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LEPLCategory As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEPL As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TxtNameCompFrom As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtPLNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents MEAdrressCompTo As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtCodeCompFrom As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPopTo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtCodeCompTo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtNameCompTo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LEReportStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl5 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ErrorProviderPL As System.Windows.Forms.ErrorProvider
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
End Class
