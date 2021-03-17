<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAccountingAcc
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAccountingAcc))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LECOAType = New DevExpress.XtraEditors.LookUpEdit()
        Me.LEType = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.MEAccDesc = New DevExpress.XtraEditors.MemoEdit()
        Me.TEAccount = New DevExpress.XtraEditors.TextEdit()
        Me.SLEParentAccount = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdAcc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnACc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LEActive = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LEAccCat = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LEDetail = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TEAccountDetail = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.EPACC = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.SLEConsolidationCat = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LConsCat = New DevExpress.XtraEditors.LabelControl()
        Me.LtaxReport = New DevExpress.XtraEditors.LabelControl()
        Me.SLETaxReport = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.LECOAType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEAccDesc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEParentAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEActive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEAccCat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEDetail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEAccountDetail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EPACC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEConsolidationCat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLETaxReport.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BCancel)
        Me.PanelControl1.Controls.Add(Me.BSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 296)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(639, 39)
        Me.PanelControl1.TabIndex = 0
        '
        'BCancel
        '
        Me.BCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCancel.Image = CType(resources.GetObject("BCancel.Image"), System.Drawing.Image)
        Me.BCancel.Location = New System.Drawing.Point(457, 2)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(94, 35)
        Me.BCancel.TabIndex = 1
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.Image = CType(resources.GetObject("BSave.Image"), System.Drawing.Image)
        Me.BSave.Location = New System.Drawing.Point(551, 2)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(86, 35)
        Me.BSave.TabIndex = 0
        Me.BSave.Text = "Save"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.SLETaxReport)
        Me.PanelControl3.Controls.Add(Me.LtaxReport)
        Me.PanelControl3.Controls.Add(Me.LConsCat)
        Me.PanelControl3.Controls.Add(Me.SLEConsolidationCat)
        Me.PanelControl3.Controls.Add(Me.LabelControl4)
        Me.PanelControl3.Controls.Add(Me.LECOAType)
        Me.PanelControl3.Controls.Add(Me.LEType)
        Me.PanelControl3.Controls.Add(Me.LabelControl2)
        Me.PanelControl3.Controls.Add(Me.MEAccDesc)
        Me.PanelControl3.Controls.Add(Me.TEAccount)
        Me.PanelControl3.Controls.Add(Me.SLEParentAccount)
        Me.PanelControl3.Controls.Add(Me.LEActive)
        Me.PanelControl3.Controls.Add(Me.LabelControl8)
        Me.PanelControl3.Controls.Add(Me.LEAccCat)
        Me.PanelControl3.Controls.Add(Me.LabelControl6)
        Me.PanelControl3.Controls.Add(Me.LEDetail)
        Me.PanelControl3.Controls.Add(Me.LabelControl5)
        Me.PanelControl3.Controls.Add(Me.LabelControl1)
        Me.PanelControl3.Controls.Add(Me.TEAccountDetail)
        Me.PanelControl3.Controls.Add(Me.LabelControl3)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl3.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(639, 296)
        Me.PanelControl3.TabIndex = 54
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(18, 14)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(51, 15)
        Me.LabelControl4.TabIndex = 124
        Me.LabelControl4.Text = "COA Type"
        '
        'LECOAType
        '
        Me.LECOAType.Location = New System.Drawing.Point(130, 12)
        Me.LECOAType.Name = "LECOAType"
        Me.LECOAType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LECOAType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_coa_type", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("coa_type", "Type")})
        Me.LECOAType.Size = New System.Drawing.Size(188, 20)
        Me.LECOAType.TabIndex = 123
        '
        'LEType
        '
        Me.LEType.Location = New System.Drawing.Point(130, 206)
        Me.LEType.Name = "LEType"
        Me.LEType.Properties.Appearance.Options.UseTextOptions = True
        Me.LEType.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_dc", "id_dc", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("dc", "Debit / Credit")})
        Me.LEType.Properties.NullText = ""
        Me.LEType.Properties.ShowFooter = False
        Me.LEType.Size = New System.Drawing.Size(236, 20)
        Me.LEType.TabIndex = 122
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(18, 208)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(73, 15)
        Me.LabelControl2.TabIndex = 121
        Me.LabelControl2.Text = "Debit / Credit"
        '
        'MEAccDesc
        '
        Me.MEAccDesc.Location = New System.Drawing.Point(130, 115)
        Me.MEAccDesc.Name = "MEAccDesc"
        Me.MEAccDesc.Size = New System.Drawing.Size(493, 45)
        Me.MEAccDesc.TabIndex = 120
        '
        'TEAccount
        '
        Me.TEAccount.Location = New System.Drawing.Point(130, 81)
        Me.TEAccount.Name = "TEAccount"
        Me.TEAccount.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEAccount.Properties.Appearance.Options.UseFont = True
        Me.TEAccount.Properties.ReadOnly = True
        Me.TEAccount.Size = New System.Drawing.Size(134, 22)
        Me.TEAccount.TabIndex = 119
        '
        'SLEParentAccount
        '
        Me.SLEParentAccount.EditValue = "No Parent Account"
        Me.SLEParentAccount.Location = New System.Drawing.Point(270, 82)
        Me.SLEParentAccount.Name = "SLEParentAccount"
        Me.SLEParentAccount.Properties.Appearance.Options.UseTextOptions = True
        Me.SLEParentAccount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.SLEParentAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEParentAccount.Properties.NullText = "No Parent Account"
        Me.SLEParentAccount.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEParentAccount.Size = New System.Drawing.Size(168, 20)
        Me.SLEParentAccount.TabIndex = 118
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdAcc, Me.GridColumnACc, Me.GridColumnDesc, Me.GridColumnIdCat, Me.GridColumnCat})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdAcc
        '
        Me.GridColumnIdAcc.Caption = "Id Acc"
        Me.GridColumnIdAcc.FieldName = "id_acc"
        Me.GridColumnIdAcc.Name = "GridColumnIdAcc"
        '
        'GridColumnACc
        '
        Me.GridColumnACc.Caption = "Account"
        Me.GridColumnACc.FieldName = "acc_name"
        Me.GridColumnACc.Name = "GridColumnACc"
        Me.GridColumnACc.Visible = True
        Me.GridColumnACc.VisibleIndex = 0
        Me.GridColumnACc.Width = 100
        '
        'GridColumnDesc
        '
        Me.GridColumnDesc.Caption = "Description"
        Me.GridColumnDesc.FieldName = "acc_description"
        Me.GridColumnDesc.Name = "GridColumnDesc"
        Me.GridColumnDesc.Visible = True
        Me.GridColumnDesc.VisibleIndex = 1
        Me.GridColumnDesc.Width = 190
        '
        'GridColumnIdCat
        '
        Me.GridColumnIdCat.Caption = "Id Cat"
        Me.GridColumnIdCat.FieldName = "id_acc_cat"
        Me.GridColumnIdCat.Name = "GridColumnIdCat"
        '
        'GridColumnCat
        '
        Me.GridColumnCat.Caption = "Category"
        Me.GridColumnCat.FieldName = "acc_cat"
        Me.GridColumnCat.Name = "GridColumnCat"
        Me.GridColumnCat.Visible = True
        Me.GridColumnCat.VisibleIndex = 2
        Me.GridColumnCat.Width = 94
        '
        'LEActive
        '
        Me.LEActive.Location = New System.Drawing.Point(130, 236)
        Me.LEActive.Name = "LEActive"
        Me.LEActive.Properties.Appearance.Options.UseTextOptions = True
        Me.LEActive.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEActive.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEActive.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_status", "id_status", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("status", "Status")})
        Me.LEActive.Properties.NullText = ""
        Me.LEActive.Properties.ShowFooter = False
        Me.LEActive.Size = New System.Drawing.Size(236, 20)
        Me.LEActive.TabIndex = 117
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Location = New System.Drawing.Point(18, 238)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(33, 15)
        Me.LabelControl8.TabIndex = 116
        Me.LabelControl8.Text = "Active"
        '
        'LEAccCat
        '
        Me.LEAccCat.Location = New System.Drawing.Point(130, 46)
        Me.LEAccCat.Name = "LEAccCat"
        Me.LEAccCat.Properties.Appearance.Options.UseTextOptions = True
        Me.LEAccCat.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEAccCat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEAccCat.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_acc_cat", "id_acc_cat", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("acc_cat", "Account Categori")})
        Me.LEAccCat.Properties.NullText = ""
        Me.LEAccCat.Properties.ShowFooter = False
        Me.LEAccCat.Size = New System.Drawing.Size(134, 20)
        Me.LEAccCat.TabIndex = 115
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(18, 48)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(48, 15)
        Me.LabelControl6.TabIndex = 114
        Me.LabelControl6.Text = "Category"
        '
        'LEDetail
        '
        Me.LEDetail.Location = New System.Drawing.Point(130, 175)
        Me.LEDetail.Name = "LEDetail"
        Me.LEDetail.Properties.Appearance.Options.UseTextOptions = True
        Me.LEDetail.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEDetail.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEDetail.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_is_det", "id_is_det", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("is_det", "Type Account")})
        Me.LEDetail.Properties.NullText = ""
        Me.LEDetail.Properties.ShowFooter = False
        Me.LEDetail.Size = New System.Drawing.Size(236, 20)
        Me.LEDetail.TabIndex = 113
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(18, 117)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(64, 15)
        Me.LabelControl5.TabIndex = 53
        Me.LabelControl5.Text = "Description"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(18, 84)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(44, 15)
        Me.LabelControl1.TabIndex = 46
        Me.LabelControl1.Text = "Account"
        '
        'TEAccountDetail
        '
        Me.TEAccountDetail.Location = New System.Drawing.Point(444, 81)
        Me.TEAccountDetail.Name = "TEAccountDetail"
        Me.TEAccountDetail.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEAccountDetail.Properties.Appearance.Options.UseFont = True
        Me.TEAccountDetail.Size = New System.Drawing.Size(179, 22)
        Me.TEAccountDetail.TabIndex = 52
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(18, 177)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(33, 15)
        Me.LabelControl3.TabIndex = 48
        Me.LabelControl3.Text = "Detail"
        '
        'EPACC
        '
        Me.EPACC.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EPACC.ContainerControl = Me
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "20_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "8_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "23_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(3, "arrow_refresh.png")
        Me.LargeImageCollection.Images.SetKeyName(4, "check_mark.png")
        Me.LargeImageCollection.Images.SetKeyName(5, "gnome_application_exit (1).png")
        Me.LargeImageCollection.Images.SetKeyName(6, "printer_3.png")
        Me.LargeImageCollection.Images.SetKeyName(7, "save.png")
        Me.LargeImageCollection.Images.SetKeyName(8, "31_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(9, "18_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(10, "10_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(11, "18_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(12, "31_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(13, "folder-documents-icon.png")
        Me.LargeImageCollection.Images.SetKeyName(14, "mail_attachment.png")
        Me.LargeImageCollection.Images.SetKeyName(15, "attachment-icon.png")
        '
        'SLEConsolidationCat
        '
        Me.SLEConsolidationCat.Location = New System.Drawing.Point(192, 265)
        Me.SLEConsolidationCat.Name = "SLEConsolidationCat"
        Me.SLEConsolidationCat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEConsolidationCat.Properties.View = Me.GridView1
        Me.SLEConsolidationCat.Size = New System.Drawing.Size(431, 20)
        Me.SLEConsolidationCat.TabIndex = 125
        Me.SLEConsolidationCat.Visible = False
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn7, Me.GridColumn6, Me.GridColumn4, Me.GridColumn5})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'LConsCat
        '
        Me.LConsCat.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LConsCat.Location = New System.Drawing.Point(18, 267)
        Me.LConsCat.Name = "LConsCat"
        Me.LConsCat.Size = New System.Drawing.Size(168, 15)
        Me.LConsCat.TabIndex = 126
        Me.LConsCat.Text = "Consolidation Report Category"
        Me.LConsCat.Visible = False
        '
        'LtaxReport
        '
        Me.LtaxReport.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtaxReport.Location = New System.Drawing.Point(372, 177)
        Me.LtaxReport.Name = "LtaxReport"
        Me.LtaxReport.Size = New System.Drawing.Size(58, 15)
        Me.LtaxReport.TabIndex = 127
        Me.LtaxReport.Text = "Tax Report"
        Me.LtaxReport.Visible = False
        '
        'SLETaxReport
        '
        Me.SLETaxReport.Location = New System.Drawing.Point(444, 175)
        Me.SLETaxReport.Name = "SLETaxReport"
        Me.SLETaxReport.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLETaxReport.Properties.View = Me.GridView2
        Me.SLETaxReport.Size = New System.Drawing.Size(179, 20)
        Me.SLETaxReport.TabIndex = 128
        Me.SLETaxReport.Visible = False
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID "
        Me.GridColumn1.FieldName = "id_tax_report"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Type"
        Me.GridColumn2.FieldName = "tax_report"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "No"
        Me.GridColumn3.FieldName = "id_consolidation"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        Me.GridColumn3.Width = 112
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Type (Indonesia)"
        Me.GridColumn4.FieldName = "description_ind"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        Me.GridColumn4.Width = 375
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Type (English)"
        Me.GridColumn5.FieldName = "description_eng"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 4
        Me.GridColumn5.Width = 379
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Sub Header"
        Me.GridColumn6.FieldName = "sub_header"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 2
        Me.GridColumn6.Width = 375
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Header"
        Me.GridColumn7.FieldName = "header"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 1
        Me.GridColumn7.Width = 375
        '
        'FormAccountingAcc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 335)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAccountingAcc"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Accounting Account"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.LECOAType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEAccDesc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEParentAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEActive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEAccCat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEDetail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEAccountDetail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EPACC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEConsolidationCat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLETaxReport.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents MEAccDesc As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents TEAccount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SLEParentAccount As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LEActive As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEAccCat As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEDetail As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEAccountDetail As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnIdAcc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnACc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents EPACC As System.Windows.Forms.ErrorProvider
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents LEType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LECOAType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LConsCat As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEConsolidationCat As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SLETaxReport As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LtaxReport As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
End Class
