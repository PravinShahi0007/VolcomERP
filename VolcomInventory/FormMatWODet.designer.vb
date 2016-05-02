<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMatWODet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMatWODet))
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.EPMatWO = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl
        Me.BAttach = New DevExpress.XtraEditors.SimpleButton
        Me.BMark = New DevExpress.XtraEditors.SimpleButton
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BSave = New DevExpress.XtraEditors.SimpleButton
        Me.GroupGeneralFooter = New DevExpress.XtraEditors.GroupControl
        Me.PanelControl7 = New DevExpress.XtraEditors.PanelControl
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl22 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl
        Me.TEDiscount = New DevExpress.XtraEditors.TextEdit
        Me.TEKurs = New DevExpress.XtraEditors.TextEdit
        Me.TEVatTot = New DevExpress.XtraEditors.TextEdit
        Me.TETot = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl
        Me.LECurrency = New DevExpress.XtraEditors.LookUpEdit
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl19 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl16 = New DevExpress.XtraEditors.LabelControl
        Me.METotSay = New DevExpress.XtraEditors.MemoEdit
        Me.TEGrossTot = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl17 = New DevExpress.XtraEditors.LabelControl
        Me.TEVat = New DevExpress.XtraEditors.SpinEdit
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl
        Me.MENote = New DevExpress.XtraEditors.MemoEdit
        Me.LabelControl20 = New DevExpress.XtraEditors.LabelControl
        Me.BSearchCompShipTo = New DevExpress.XtraEditors.SimpleButton
        Me.MECompShipToAddress = New DevExpress.XtraEditors.MemoEdit
        Me.TECompShipToName = New DevExpress.XtraEditors.TextEdit
        Me.TECompShipTo = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl23 = New DevExpress.XtraEditors.LabelControl
        Me.GConListPurchase = New DevExpress.XtraEditors.GroupControl
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl
        Me.XTPWorkOrder = New DevExpress.XtraTab.XtraTabPage
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.GCListPurchase = New DevExpress.XtraGrid.GridControl
        Me.GVListPurchase = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdPurcDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdOvhPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdMatDetPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdMat = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColDiscount = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSubtotal = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColNote = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnUOM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl
        Me.Bdel = New DevExpress.XtraEditors.SimpleButton
        Me.BEdit = New DevExpress.XtraEditors.SimpleButton
        Me.BAdd = New DevExpress.XtraEditors.SimpleButton
        Me.XTPMaterial = New DevExpress.XtraTab.XtraTabPage
        Me.GCMaterial = New DevExpress.XtraGrid.GridControl
        Me.GVMaterial = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnUOMMat = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnNote = New DevExpress.XtraGrid.Columns.GridColumn
        Me.PanelControl6 = New DevExpress.XtraEditors.PanelControl
        Me.BDelMaterial = New DevExpress.XtraEditors.SimpleButton
        Me.BEditMaterial = New DevExpress.XtraEditors.SimpleButton
        Me.BAddMaterial = New DevExpress.XtraEditors.SimpleButton
        Me.GroupGeneralHeader = New DevExpress.XtraEditors.GroupControl
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.TEPONumber = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl
        Me.LEpayment = New DevExpress.XtraEditors.LookUpEdit
        Me.TELeadTime = New DevExpress.XtraEditors.SpinEdit
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl
        Me.TETOP = New DevExpress.XtraEditors.SpinEdit
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl
        Me.PanelControl5 = New DevExpress.XtraEditors.PanelControl
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl
        Me.LEDelivery = New DevExpress.XtraEditors.SearchLookUpEdit
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.TEDate = New DevExpress.XtraEditors.TextEdit
        Me.TERecDate = New DevExpress.XtraEditors.TextEdit
        Me.LESeason = New DevExpress.XtraEditors.SearchLookUpEdit
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl
        Me.TEDueDate = New DevExpress.XtraEditors.TextEdit
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl
        Me.BPickPORev = New DevExpress.XtraEditors.SimpleButton
        Me.TEWORevNumber = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl24 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl
        Me.TECompCode = New DevExpress.XtraEditors.TextEdit
        Me.TECompName = New DevExpress.XtraEditors.TextEdit
        Me.MECompAddress = New DevExpress.XtraEditors.MemoEdit
        Me.TECompAttn = New DevExpress.XtraEditors.TextEdit
        Me.BSearchCompTo = New DevExpress.XtraEditors.SimpleButton
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl
        Me.LEWOType = New DevExpress.XtraEditors.SearchLookUpEdit
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdPOType = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColPOType = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EPMatWO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.GroupGeneralFooter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneralFooter.SuspendLayout()
        CType(Me.PanelControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl7.SuspendLayout()
        CType(Me.TEDiscount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEKurs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEVatTot.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TETot.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LECurrency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.METotSay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEGrossTot.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEVat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MECompShipToAddress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECompShipToName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECompShipTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GConListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GConListPurchase.SuspendLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XTPWorkOrder.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        Me.XTPMaterial.SuspendLayout()
        CType(Me.GCMaterial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMaterial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl6.SuspendLayout()
        CType(Me.GroupGeneralHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneralHeader.SuspendLayout()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.TEPONumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEpayment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TELeadTime.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TETOP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl5.SuspendLayout()
        CType(Me.LEDelivery.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TERecDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDueDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.TEWORevNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECompCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECompName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MECompAddress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECompAttn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEWOType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "20_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "8_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "23_24x24.png")
        '
        'EPMatWO
        '
        Me.EPMatWO.ContainerControl = Me
        '
        'GroupControl3
        '
        Me.GroupControl3.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl3.Controls.Add(Me.BAttach)
        Me.GroupControl3.Controls.Add(Me.BMark)
        Me.GroupControl3.Controls.Add(Me.BPrint)
        Me.GroupControl3.Controls.Add(Me.BCancel)
        Me.GroupControl3.Controls.Add(Me.BSave)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl3.Location = New System.Drawing.Point(0, 548)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(909, 38)
        Me.GroupControl3.TabIndex = 44
        '
        'BAttach
        '
        Me.BAttach.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAttach.Location = New System.Drawing.Point(588, 2)
        Me.BAttach.Name = "BAttach"
        Me.BAttach.Size = New System.Drawing.Size(94, 34)
        Me.BAttach.TabIndex = 5
        Me.BAttach.Text = "Attachment"
        '
        'BMark
        '
        Me.BMark.Dock = System.Windows.Forms.DockStyle.Left
        Me.BMark.Location = New System.Drawing.Point(22, 2)
        Me.BMark.Name = "BMark"
        Me.BMark.Size = New System.Drawing.Size(75, 34)
        Me.BMark.TabIndex = 4
        Me.BMark.Text = "Mark"
        '
        'BPrint
        '
        Me.BPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BPrint.Enabled = False
        Me.BPrint.Location = New System.Drawing.Point(682, 2)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(75, 34)
        Me.BPrint.TabIndex = 3
        Me.BPrint.Text = "Print"
        '
        'BCancel
        '
        Me.BCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCancel.Location = New System.Drawing.Point(757, 2)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(75, 34)
        Me.BCancel.TabIndex = 2
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.Enabled = False
        Me.BSave.Location = New System.Drawing.Point(832, 2)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(75, 34)
        Me.BSave.TabIndex = 1
        Me.BSave.Text = "Save"
        '
        'GroupGeneralFooter
        '
        Me.GroupGeneralFooter.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupGeneralFooter.Controls.Add(Me.PanelControl7)
        Me.GroupGeneralFooter.Controls.Add(Me.LabelControl18)
        Me.GroupGeneralFooter.Controls.Add(Me.MENote)
        Me.GroupGeneralFooter.Controls.Add(Me.LabelControl20)
        Me.GroupGeneralFooter.Controls.Add(Me.BSearchCompShipTo)
        Me.GroupGeneralFooter.Controls.Add(Me.MECompShipToAddress)
        Me.GroupGeneralFooter.Controls.Add(Me.TECompShipToName)
        Me.GroupGeneralFooter.Controls.Add(Me.TECompShipTo)
        Me.GroupGeneralFooter.Controls.Add(Me.LabelControl23)
        Me.GroupGeneralFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupGeneralFooter.Location = New System.Drawing.Point(0, 393)
        Me.GroupGeneralFooter.Name = "GroupGeneralFooter"
        Me.GroupGeneralFooter.Size = New System.Drawing.Size(909, 155)
        Me.GroupGeneralFooter.TabIndex = 43
        '
        'PanelControl7
        '
        Me.PanelControl7.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl7.Controls.Add(Me.LabelControl13)
        Me.PanelControl7.Controls.Add(Me.LabelControl22)
        Me.PanelControl7.Controls.Add(Me.LabelControl21)
        Me.PanelControl7.Controls.Add(Me.TEDiscount)
        Me.PanelControl7.Controls.Add(Me.TEKurs)
        Me.PanelControl7.Controls.Add(Me.TEVatTot)
        Me.PanelControl7.Controls.Add(Me.TETot)
        Me.PanelControl7.Controls.Add(Me.LabelControl14)
        Me.PanelControl7.Controls.Add(Me.LECurrency)
        Me.PanelControl7.Controls.Add(Me.LabelControl15)
        Me.PanelControl7.Controls.Add(Me.LabelControl19)
        Me.PanelControl7.Controls.Add(Me.LabelControl16)
        Me.PanelControl7.Controls.Add(Me.METotSay)
        Me.PanelControl7.Controls.Add(Me.TEGrossTot)
        Me.PanelControl7.Controls.Add(Me.LabelControl17)
        Me.PanelControl7.Controls.Add(Me.TEVat)
        Me.PanelControl7.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl7.Location = New System.Drawing.Point(421, 2)
        Me.PanelControl7.Name = "PanelControl7"
        Me.PanelControl7.Size = New System.Drawing.Size(486, 151)
        Me.PanelControl7.TabIndex = 147
        '
        'LabelControl13
        '
        Me.LabelControl13.Location = New System.Drawing.Point(11, 8)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(44, 13)
        Me.LabelControl13.TabIndex = 129
        Me.LabelControl13.Text = "Currency"
        '
        'LabelControl22
        '
        Me.LabelControl22.Location = New System.Drawing.Point(354, 33)
        Me.LabelControl22.Name = "LabelControl22"
        Me.LabelControl22.Size = New System.Drawing.Size(11, 13)
        Me.LabelControl22.TabIndex = 144
        Me.LabelControl22.Text = "%"
        '
        'LabelControl21
        '
        Me.LabelControl21.Location = New System.Drawing.Point(11, 34)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl21.TabIndex = 146
        Me.LabelControl21.Text = "Kurs"
        '
        'TEDiscount
        '
        Me.TEDiscount.EditValue = ""
        Me.TEDiscount.Location = New System.Drawing.Point(71, 57)
        Me.TEDiscount.Name = "TEDiscount"
        Me.TEDiscount.Properties.Appearance.Options.UseTextOptions = True
        Me.TEDiscount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEDiscount.Properties.EditValueChangedDelay = 1
        Me.TEDiscount.Properties.Mask.EditMask = "N2"
        Me.TEDiscount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEDiscount.Properties.Mask.SaveLiteral = False
        Me.TEDiscount.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEDiscount.Properties.ReadOnly = True
        Me.TEDiscount.Size = New System.Drawing.Size(155, 20)
        Me.TEDiscount.TabIndex = 125
        '
        'TEKurs
        '
        Me.TEKurs.EditValue = "1.00"
        Me.TEKurs.Location = New System.Drawing.Point(71, 31)
        Me.TEKurs.Name = "TEKurs"
        Me.TEKurs.Properties.Appearance.Options.UseTextOptions = True
        Me.TEKurs.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEKurs.Properties.EditValueChangedDelay = 1
        Me.TEKurs.Properties.Mask.EditMask = "N2"
        Me.TEKurs.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEKurs.Properties.Mask.SaveLiteral = False
        Me.TEKurs.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEKurs.Size = New System.Drawing.Size(155, 20)
        Me.TEKurs.TabIndex = 145
        '
        'TEVatTot
        '
        Me.TEVatTot.EditValue = ""
        Me.TEVatTot.Location = New System.Drawing.Point(371, 30)
        Me.TEVatTot.Name = "TEVatTot"
        Me.TEVatTot.Properties.Appearance.Options.UseTextOptions = True
        Me.TEVatTot.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEVatTot.Properties.EditValueChangedDelay = 1
        Me.TEVatTot.Properties.Mask.EditMask = "N2"
        Me.TEVatTot.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEVatTot.Properties.Mask.SaveLiteral = False
        Me.TEVatTot.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEVatTot.Properties.ReadOnly = True
        Me.TEVatTot.Size = New System.Drawing.Size(102, 20)
        Me.TEVatTot.TabIndex = 126
        '
        'TETot
        '
        Me.TETot.EditValue = ""
        Me.TETot.Location = New System.Drawing.Point(313, 58)
        Me.TETot.Name = "TETot"
        Me.TETot.Properties.Appearance.Options.UseTextOptions = True
        Me.TETot.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TETot.Properties.EditValueChangedDelay = 1
        Me.TETot.Properties.Mask.EditMask = "N2"
        Me.TETot.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TETot.Properties.Mask.SaveLiteral = False
        Me.TETot.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TETot.Properties.ReadOnly = True
        Me.TETot.Size = New System.Drawing.Size(160, 20)
        Me.TETot.TabIndex = 127
        '
        'LabelControl14
        '
        Me.LabelControl14.Location = New System.Drawing.Point(253, 34)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(16, 13)
        Me.LabelControl14.TabIndex = 131
        Me.LabelControl14.Text = "Vat"
        '
        'LECurrency
        '
        Me.LECurrency.Location = New System.Drawing.Point(71, 5)
        Me.LECurrency.Name = "LECurrency"
        Me.LECurrency.Properties.Appearance.Options.UseTextOptions = True
        Me.LECurrency.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LECurrency.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LECurrency.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.LECurrency.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.LECurrency.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.LECurrency.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LECurrency.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_currency", "Id Currency", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("currency", "Currency")})
        Me.LECurrency.Properties.NullText = ""
        Me.LECurrency.Properties.ShowFooter = False
        Me.LECurrency.Size = New System.Drawing.Size(155, 20)
        Me.LECurrency.TabIndex = 141
        '
        'LabelControl15
        '
        Me.LabelControl15.Location = New System.Drawing.Point(253, 61)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl15.TabIndex = 132
        Me.LabelControl15.Text = "Total"
        '
        'LabelControl19
        '
        Me.LabelControl19.Location = New System.Drawing.Point(11, 87)
        Me.LabelControl19.Name = "LabelControl19"
        Me.LabelControl19.Size = New System.Drawing.Size(18, 13)
        Me.LabelControl19.TabIndex = 140
        Me.LabelControl19.Text = "Say"
        '
        'LabelControl16
        '
        Me.LabelControl16.Location = New System.Drawing.Point(11, 61)
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl16.TabIndex = 133
        Me.LabelControl16.Text = "Discount"
        '
        'METotSay
        '
        Me.METotSay.Location = New System.Drawing.Point(71, 84)
        Me.METotSay.Name = "METotSay"
        Me.METotSay.Properties.MaxLength = 100
        Me.METotSay.Properties.ReadOnly = True
        Me.METotSay.Size = New System.Drawing.Size(402, 51)
        Me.METotSay.TabIndex = 139
        '
        'TEGrossTot
        '
        Me.TEGrossTot.EditValue = ""
        Me.TEGrossTot.Location = New System.Drawing.Point(313, 5)
        Me.TEGrossTot.Name = "TEGrossTot"
        Me.TEGrossTot.Properties.Appearance.Options.UseTextOptions = True
        Me.TEGrossTot.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEGrossTot.Properties.EditValueChangedDelay = 1
        Me.TEGrossTot.Properties.Mask.EditMask = "N2"
        Me.TEGrossTot.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEGrossTot.Properties.Mask.SaveLiteral = False
        Me.TEGrossTot.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEGrossTot.Properties.ReadOnly = True
        Me.TEGrossTot.Size = New System.Drawing.Size(160, 20)
        Me.TEGrossTot.TabIndex = 134
        '
        'LabelControl17
        '
        Me.LabelControl17.Location = New System.Drawing.Point(253, 8)
        Me.LabelControl17.Name = "LabelControl17"
        Me.LabelControl17.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl17.TabIndex = 135
        Me.LabelControl17.Text = "Gross Total"
        '
        'TEVat
        '
        Me.TEVat.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TEVat.Location = New System.Drawing.Point(313, 29)
        Me.TEVat.Name = "TEVat"
        Me.TEVat.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEVat.Properties.Appearance.Options.UseFont = True
        Me.TEVat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.TEVat.Properties.IsFloatValue = False
        Me.TEVat.Properties.Mask.EditMask = "N00"
        Me.TEVat.Properties.MaxValue = New Decimal(New Integer() {100, 0, 0, 0})
        Me.TEVat.Size = New System.Drawing.Size(35, 22)
        Me.TEVat.TabIndex = 136
        '
        'LabelControl18
        '
        Me.LabelControl18.Location = New System.Drawing.Point(27, 11)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl18.TabIndex = 138
        Me.LabelControl18.Text = "Note"
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(77, 8)
        Me.MENote.Name = "MENote"
        Me.MENote.Properties.MaxLength = 100
        Me.MENote.Size = New System.Drawing.Size(316, 41)
        Me.MENote.TabIndex = 137
        '
        'LabelControl20
        '
        Me.LabelControl20.Location = New System.Drawing.Point(27, 90)
        Me.LabelControl20.Name = "LabelControl20"
        Me.LabelControl20.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl20.TabIndex = 123
        Me.LabelControl20.Text = "Address"
        '
        'BSearchCompShipTo
        '
        Me.BSearchCompShipTo.Location = New System.Drawing.Point(370, 61)
        Me.BSearchCompShipTo.Name = "BSearchCompShipTo"
        Me.BSearchCompShipTo.Size = New System.Drawing.Size(23, 20)
        Me.BSearchCompShipTo.TabIndex = 119
        Me.BSearchCompShipTo.Text = "..."
        '
        'MECompShipToAddress
        '
        Me.MECompShipToAddress.Location = New System.Drawing.Point(77, 87)
        Me.MECompShipToAddress.Name = "MECompShipToAddress"
        Me.MECompShipToAddress.Properties.MaxLength = 100
        Me.MECompShipToAddress.Properties.ReadOnly = True
        Me.MECompShipToAddress.Size = New System.Drawing.Size(316, 51)
        Me.MECompShipToAddress.TabIndex = 117
        '
        'TECompShipToName
        '
        Me.TECompShipToName.EditValue = ""
        Me.TECompShipToName.Location = New System.Drawing.Point(156, 61)
        Me.TECompShipToName.Name = "TECompShipToName"
        Me.TECompShipToName.Properties.EditValueChangedDelay = 1
        Me.TECompShipToName.Properties.ReadOnly = True
        Me.TECompShipToName.Size = New System.Drawing.Size(208, 20)
        Me.TECompShipToName.TabIndex = 116
        '
        'TECompShipTo
        '
        Me.TECompShipTo.EditValue = ""
        Me.TECompShipTo.Location = New System.Drawing.Point(77, 61)
        Me.TECompShipTo.Name = "TECompShipTo"
        Me.TECompShipTo.Properties.EditValueChangedDelay = 1
        Me.TECompShipTo.Properties.ReadOnly = True
        Me.TECompShipTo.Size = New System.Drawing.Size(73, 20)
        Me.TECompShipTo.TabIndex = 115
        '
        'LabelControl23
        '
        Me.LabelControl23.Location = New System.Drawing.Point(25, 64)
        Me.LabelControl23.Name = "LabelControl23"
        Me.LabelControl23.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl23.TabIndex = 88
        Me.LabelControl23.Text = "Ship To"
        '
        'GConListPurchase
        '
        Me.GConListPurchase.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GConListPurchase.Controls.Add(Me.XtraTabControl1)
        Me.GConListPurchase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GConListPurchase.Location = New System.Drawing.Point(0, 179)
        Me.GConListPurchase.Name = "GConListPurchase"
        Me.GConListPurchase.Size = New System.Drawing.Size(909, 214)
        Me.GConListPurchase.TabIndex = 42
        Me.GConListPurchase.Text = "List Purchase"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(22, 2)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XTPWorkOrder
        Me.XtraTabControl1.Size = New System.Drawing.Size(885, 210)
        Me.XtraTabControl1.TabIndex = 20
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPWorkOrder, Me.XTPMaterial})
        '
        'XTPWorkOrder
        '
        Me.XTPWorkOrder.Controls.Add(Me.PanelControl1)
        Me.XTPWorkOrder.Controls.Add(Me.PanelControl2)
        Me.XTPWorkOrder.Name = "XTPWorkOrder"
        Me.XTPWorkOrder.Size = New System.Drawing.Size(879, 184)
        Me.XTPWorkOrder.Text = "Work Order Result"
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.GCListPurchase)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(0, 38)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(879, 146)
        Me.PanelControl1.TabIndex = 19
        '
        'GCListPurchase
        '
        Me.GCListPurchase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListPurchase.Location = New System.Drawing.Point(0, 0)
        Me.GCListPurchase.MainView = Me.GVListPurchase
        Me.GCListPurchase.Margin = New System.Windows.Forms.Padding(0)
        Me.GCListPurchase.Name = "GCListPurchase"
        Me.GCListPurchase.Size = New System.Drawing.Size(879, 146)
        Me.GCListPurchase.TabIndex = 0
        Me.GCListPurchase.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListPurchase})
        '
        'GVListPurchase
        '
        Me.GVListPurchase.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdPurcDet, Me.ColIdOvhPrice, Me.GridColumnIdMatDetPrice, Me.ColIdMat, Me.ColNo, Me.ColCode, Me.ColName, Me.ColPrice, Me.ColQty, Me.ColDiscount, Me.ColSubtotal, Me.ColNote, Me.GridColumnUOM})
        Me.GVListPurchase.GridControl = Me.GCListPurchase
        Me.GVListPurchase.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.GVListPurchase.Name = "GVListPurchase"
        Me.GVListPurchase.OptionsBehavior.Editable = False
        Me.GVListPurchase.OptionsView.ColumnAutoWidth = False
        Me.GVListPurchase.OptionsView.ShowFooter = True
        Me.GVListPurchase.OptionsView.ShowGroupPanel = False
        '
        'ColIdPurcDet
        '
        Me.ColIdPurcDet.Caption = "ID Purc Det"
        Me.ColIdPurcDet.FieldName = "id_mat_wo_det"
        Me.ColIdPurcDet.Name = "ColIdPurcDet"
        '
        'ColIdOvhPrice
        '
        Me.ColIdOvhPrice.Caption = "Id Ovh Price"
        Me.ColIdOvhPrice.FieldName = "id_ovh_price"
        Me.ColIdOvhPrice.Name = "ColIdOvhPrice"
        '
        'GridColumnIdMatDetPrice
        '
        Me.GridColumnIdMatDetPrice.Caption = "ID Mat Det Price"
        Me.GridColumnIdMatDetPrice.FieldName = "id_mat_det_price"
        Me.GridColumnIdMatDetPrice.Name = "GridColumnIdMatDetPrice"
        '
        'ColIdMat
        '
        Me.ColIdMat.Caption = "Id Mat"
        Me.ColIdMat.FieldName = "id_mat_det"
        Me.ColIdMat.Name = "ColIdMat"
        '
        'ColNo
        '
        Me.ColNo.AppearanceCell.Options.UseTextOptions = True
        Me.ColNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColNo.Caption = "No."
        Me.ColNo.FieldName = "no"
        Me.ColNo.Name = "ColNo"
        Me.ColNo.Visible = True
        Me.ColNo.VisibleIndex = 0
        Me.ColNo.Width = 30
        '
        'ColCode
        '
        Me.ColCode.Caption = "Code"
        Me.ColCode.FieldName = "code"
        Me.ColCode.Name = "ColCode"
        Me.ColCode.Visible = True
        Me.ColCode.VisibleIndex = 1
        Me.ColCode.Width = 140
        '
        'ColName
        '
        Me.ColName.Caption = "Name"
        Me.ColName.FieldName = "name"
        Me.ColName.Name = "ColName"
        Me.ColName.Visible = True
        Me.ColName.VisibleIndex = 2
        Me.ColName.Width = 235
        '
        'ColPrice
        '
        Me.ColPrice.AppearanceCell.Options.UseTextOptions = True
        Me.ColPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.ColPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.Caption = "Price"
        Me.ColPrice.DisplayFormat.FormatString = "N2"
        Me.ColPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColPrice.FieldName = "price"
        Me.ColPrice.Name = "ColPrice"
        Me.ColPrice.Visible = True
        Me.ColPrice.VisibleIndex = 3
        Me.ColPrice.Width = 140
        '
        'ColQty
        '
        Me.ColQty.AppearanceCell.Options.UseTextOptions = True
        Me.ColQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.AppearanceHeader.Options.UseTextOptions = True
        Me.ColQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.Caption = "Qty"
        Me.ColQty.DisplayFormat.FormatString = "N2"
        Me.ColQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColQty.FieldName = "qty"
        Me.ColQty.Name = "ColQty"
        Me.ColQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N2}")})
        Me.ColQty.Visible = True
        Me.ColQty.VisibleIndex = 5
        Me.ColQty.Width = 68
        '
        'ColDiscount
        '
        Me.ColDiscount.AppearanceCell.Options.UseTextOptions = True
        Me.ColDiscount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColDiscount.AppearanceHeader.Options.UseTextOptions = True
        Me.ColDiscount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColDiscount.Caption = "Discount"
        Me.ColDiscount.DisplayFormat.FormatString = "N2"
        Me.ColDiscount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColDiscount.FieldName = "discount"
        Me.ColDiscount.Name = "ColDiscount"
        Me.ColDiscount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "discount", "{0:N2}")})
        Me.ColDiscount.Visible = True
        Me.ColDiscount.VisibleIndex = 4
        Me.ColDiscount.Width = 96
        '
        'ColSubtotal
        '
        Me.ColSubtotal.AppearanceCell.Options.UseTextOptions = True
        Me.ColSubtotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColSubtotal.AppearanceHeader.Options.UseTextOptions = True
        Me.ColSubtotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColSubtotal.Caption = "Sub Total"
        Me.ColSubtotal.DisplayFormat.FormatString = "N2"
        Me.ColSubtotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColSubtotal.FieldName = "total"
        Me.ColSubtotal.Name = "ColSubtotal"
        Me.ColSubtotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:N2}")})
        Me.ColSubtotal.Visible = True
        Me.ColSubtotal.VisibleIndex = 7
        Me.ColSubtotal.Width = 165
        '
        'ColNote
        '
        Me.ColNote.Caption = "Note"
        Me.ColNote.FieldName = "note"
        Me.ColNote.Name = "ColNote"
        Me.ColNote.Visible = True
        Me.ColNote.VisibleIndex = 8
        Me.ColNote.Width = 200
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
        Me.GridColumnUOM.Visible = True
        Me.GridColumnUOM.VisibleIndex = 6
        '
        'PanelControl2
        '
        Me.PanelControl2.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PanelControl2.Appearance.Options.UseBackColor = True
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.Bdel)
        Me.PanelControl2.Controls.Add(Me.BEdit)
        Me.PanelControl2.Controls.Add(Me.BAdd)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(879, 38)
        Me.PanelControl2.TabIndex = 18
        '
        'Bdel
        '
        Me.Bdel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Bdel.Enabled = False
        Me.Bdel.ImageIndex = 1
        Me.Bdel.ImageList = Me.LargeImageCollection
        Me.Bdel.Location = New System.Drawing.Point(606, 0)
        Me.Bdel.Name = "Bdel"
        Me.Bdel.Size = New System.Drawing.Size(91, 38)
        Me.Bdel.TabIndex = 20
        Me.Bdel.Text = "Delete"
        '
        'BEdit
        '
        Me.BEdit.Dock = System.Windows.Forms.DockStyle.Right
        Me.BEdit.Enabled = False
        Me.BEdit.ImageIndex = 2
        Me.BEdit.ImageList = Me.LargeImageCollection
        Me.BEdit.Location = New System.Drawing.Point(697, 0)
        Me.BEdit.Name = "BEdit"
        Me.BEdit.Size = New System.Drawing.Size(91, 38)
        Me.BEdit.TabIndex = 22
        Me.BEdit.Text = "Edit"
        '
        'BAdd
        '
        Me.BAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAdd.Enabled = False
        Me.BAdd.ImageIndex = 0
        Me.BAdd.ImageList = Me.LargeImageCollection
        Me.BAdd.Location = New System.Drawing.Point(788, 0)
        Me.BAdd.Name = "BAdd"
        Me.BAdd.Size = New System.Drawing.Size(91, 38)
        Me.BAdd.TabIndex = 21
        Me.BAdd.Text = "Add"
        '
        'XTPMaterial
        '
        Me.XTPMaterial.Controls.Add(Me.GCMaterial)
        Me.XTPMaterial.Controls.Add(Me.PanelControl6)
        Me.XTPMaterial.Name = "XTPMaterial"
        Me.XTPMaterial.Size = New System.Drawing.Size(879, 184)
        Me.XTPMaterial.Text = "Material"
        '
        'GCMaterial
        '
        Me.GCMaterial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMaterial.Location = New System.Drawing.Point(0, 38)
        Me.GCMaterial.MainView = Me.GVMaterial
        Me.GCMaterial.Margin = New System.Windows.Forms.Padding(0)
        Me.GCMaterial.Name = "GCMaterial"
        Me.GCMaterial.Size = New System.Drawing.Size(879, 146)
        Me.GCMaterial.TabIndex = 19
        Me.GCMaterial.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMaterial})
        '
        'GVMaterial
        '
        Me.GVMaterial.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumnUOMMat, Me.GridColumn17, Me.GridColumnNote})
        Me.GVMaterial.GridControl = Me.GCMaterial
        Me.GVMaterial.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.GVMaterial.Name = "GVMaterial"
        Me.GVMaterial.OptionsBehavior.Editable = False
        Me.GVMaterial.OptionsView.ColumnAutoWidth = False
        Me.GVMaterial.OptionsView.ShowFooter = True
        Me.GVMaterial.OptionsView.ShowGroupPanel = False
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "ID Purc Det"
        Me.GridColumn8.FieldName = "id_mat_wo_mat"
        Me.GridColumn8.Name = "GridColumn8"
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Id Ovh Price"
        Me.GridColumn9.FieldName = "id_mat_det_price"
        Me.GridColumn9.Name = "GridColumn9"
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Id Mat"
        Me.GridColumn10.FieldName = "id_mat_det"
        Me.GridColumn10.Name = "GridColumn10"
        '
        'GridColumn11
        '
        Me.GridColumn11.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn11.Caption = "No."
        Me.GridColumn11.FieldName = "no"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 0
        Me.GridColumn11.Width = 30
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Code"
        Me.GridColumn12.FieldName = "code"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 1
        Me.GridColumn12.Width = 140
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Name"
        Me.GridColumn13.FieldName = "name"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 2
        Me.GridColumn13.Width = 235
        '
        'GridColumn14
        '
        Me.GridColumn14.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn14.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn14.Caption = "Cost"
        Me.GridColumn14.DisplayFormat.FormatString = "N4"
        Me.GridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn14.FieldName = "price"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 3
        Me.GridColumn14.Width = 140
        '
        'GridColumn15
        '
        Me.GridColumn15.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn15.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn15.Caption = "Qty"
        Me.GridColumn15.DisplayFormat.FormatString = "N2"
        Me.GridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn15.FieldName = "qty"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N2}")})
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 4
        Me.GridColumn15.Width = 68
        '
        'GridColumnUOMMat
        '
        Me.GridColumnUOMMat.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnUOMMat.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnUOMMat.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnUOMMat.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnUOMMat.Caption = "UOM"
        Me.GridColumnUOMMat.FieldName = "uom"
        Me.GridColumnUOMMat.Name = "GridColumnUOMMat"
        Me.GridColumnUOMMat.Visible = True
        Me.GridColumnUOMMat.VisibleIndex = 5
        '
        'GridColumn17
        '
        Me.GridColumn17.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn17.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn17.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn17.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn17.Caption = "Amount"
        Me.GridColumn17.DisplayFormat.FormatString = "N2"
        Me.GridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn17.FieldName = "total"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:N2}")})
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 6
        Me.GridColumn17.Width = 165
        '
        'GridColumnNote
        '
        Me.GridColumnNote.Caption = "Note"
        Me.GridColumnNote.FieldName = "note"
        Me.GridColumnNote.Name = "GridColumnNote"
        Me.GridColumnNote.Visible = True
        Me.GridColumnNote.VisibleIndex = 7
        Me.GridColumnNote.Width = 200
        '
        'PanelControl6
        '
        Me.PanelControl6.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PanelControl6.Appearance.Options.UseBackColor = True
        Me.PanelControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl6.Controls.Add(Me.BDelMaterial)
        Me.PanelControl6.Controls.Add(Me.BEditMaterial)
        Me.PanelControl6.Controls.Add(Me.BAddMaterial)
        Me.PanelControl6.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl6.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl6.Name = "PanelControl6"
        Me.PanelControl6.Size = New System.Drawing.Size(879, 38)
        Me.PanelControl6.TabIndex = 20
        '
        'BDelMaterial
        '
        Me.BDelMaterial.Dock = System.Windows.Forms.DockStyle.Right
        Me.BDelMaterial.Enabled = False
        Me.BDelMaterial.ImageIndex = 1
        Me.BDelMaterial.ImageList = Me.LargeImageCollection
        Me.BDelMaterial.Location = New System.Drawing.Point(606, 0)
        Me.BDelMaterial.Name = "BDelMaterial"
        Me.BDelMaterial.Size = New System.Drawing.Size(91, 38)
        Me.BDelMaterial.TabIndex = 20
        Me.BDelMaterial.Text = "Delete"
        '
        'BEditMaterial
        '
        Me.BEditMaterial.Dock = System.Windows.Forms.DockStyle.Right
        Me.BEditMaterial.Enabled = False
        Me.BEditMaterial.ImageIndex = 2
        Me.BEditMaterial.ImageList = Me.LargeImageCollection
        Me.BEditMaterial.Location = New System.Drawing.Point(697, 0)
        Me.BEditMaterial.Name = "BEditMaterial"
        Me.BEditMaterial.Size = New System.Drawing.Size(91, 38)
        Me.BEditMaterial.TabIndex = 22
        Me.BEditMaterial.Text = "Edit"
        '
        'BAddMaterial
        '
        Me.BAddMaterial.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAddMaterial.ImageIndex = 0
        Me.BAddMaterial.ImageList = Me.LargeImageCollection
        Me.BAddMaterial.Location = New System.Drawing.Point(788, 0)
        Me.BAddMaterial.Name = "BAddMaterial"
        Me.BAddMaterial.Size = New System.Drawing.Size(91, 38)
        Me.BAddMaterial.TabIndex = 21
        Me.BAddMaterial.Text = "Add"
        '
        'GroupGeneralHeader
        '
        Me.GroupGeneralHeader.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupGeneralHeader.Controls.Add(Me.PanelControl4)
        Me.GroupGeneralHeader.Controls.Add(Me.PanelControl5)
        Me.GroupGeneralHeader.Controls.Add(Me.PanelControl3)
        Me.GroupGeneralHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupGeneralHeader.Location = New System.Drawing.Point(0, 0)
        Me.GroupGeneralHeader.Name = "GroupGeneralHeader"
        Me.GroupGeneralHeader.Size = New System.Drawing.Size(909, 179)
        Me.GroupGeneralHeader.TabIndex = 41
        '
        'PanelControl4
        '
        Me.PanelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl4.Controls.Add(Me.LabelControl3)
        Me.PanelControl4.Controls.Add(Me.TEPONumber)
        Me.PanelControl4.Controls.Add(Me.LabelControl7)
        Me.PanelControl4.Controls.Add(Me.LEpayment)
        Me.PanelControl4.Controls.Add(Me.TELeadTime)
        Me.PanelControl4.Controls.Add(Me.LabelControl8)
        Me.PanelControl4.Controls.Add(Me.TETOP)
        Me.PanelControl4.Controls.Add(Me.LabelControl9)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl4.Location = New System.Drawing.Point(367, 2)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(245, 175)
        Me.PanelControl4.TabIndex = 145
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(11, 12)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl3.TabIndex = 86
        Me.LabelControl3.Text = "WO Number"
        '
        'TEPONumber
        '
        Me.TEPONumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TEPONumber.EditValue = ""
        Me.TEPONumber.Location = New System.Drawing.Point(86, 9)
        Me.TEPONumber.Name = "TEPONumber"
        Me.TEPONumber.Properties.EditValueChangedDelay = 1
        Me.TEPONumber.Size = New System.Drawing.Size(148, 20)
        Me.TEPONumber.TabIndex = 3
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(11, 75)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl7.TabIndex = 126
        Me.LabelControl7.Text = "Lead Time"
        '
        'LEpayment
        '
        Me.LEpayment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LEpayment.Location = New System.Drawing.Point(86, 40)
        Me.LEpayment.Name = "LEpayment"
        Me.LEpayment.Properties.Appearance.Options.UseTextOptions = True
        Me.LEpayment.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEpayment.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LEpayment.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.LEpayment.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.LEpayment.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.LEpayment.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEpayment.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_payment", "Id payment", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("payment", "Payment")})
        Me.LEpayment.Properties.NullText = ""
        Me.LEpayment.Properties.ShowFooter = False
        Me.LEpayment.Size = New System.Drawing.Size(148, 20)
        Me.LEpayment.TabIndex = 142
        '
        'TELeadTime
        '
        Me.TELeadTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TELeadTime.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TELeadTime.Location = New System.Drawing.Point(86, 71)
        Me.TELeadTime.Name = "TELeadTime"
        Me.TELeadTime.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TELeadTime.Properties.Appearance.Options.UseFont = True
        Me.TELeadTime.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.TELeadTime.Properties.IsFloatValue = False
        Me.TELeadTime.Properties.Mask.EditMask = "N00"
        Me.TELeadTime.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.TELeadTime.Size = New System.Drawing.Size(148, 22)
        Me.TELeadTime.TabIndex = 4
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(11, 108)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(20, 13)
        Me.LabelControl8.TabIndex = 129
        Me.LabelControl8.Text = "TOP"
        '
        'TETOP
        '
        Me.TETOP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TETOP.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TETOP.Location = New System.Drawing.Point(86, 104)
        Me.TETOP.Name = "TETOP"
        Me.TETOP.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TETOP.Properties.Appearance.Options.UseFont = True
        Me.TETOP.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.TETOP.Properties.IsFloatValue = False
        Me.TETOP.Properties.Mask.EditMask = "N00"
        Me.TETOP.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.TETOP.Size = New System.Drawing.Size(148, 22)
        Me.TETOP.TabIndex = 5
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(11, 43)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl9.TabIndex = 133
        Me.LabelControl9.Text = "Payment Type"
        '
        'PanelControl5
        '
        Me.PanelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl5.Controls.Add(Me.LabelControl12)
        Me.PanelControl5.Controls.Add(Me.LabelControl6)
        Me.PanelControl5.Controls.Add(Me.LEDelivery)
        Me.PanelControl5.Controls.Add(Me.TEDate)
        Me.PanelControl5.Controls.Add(Me.TERecDate)
        Me.PanelControl5.Controls.Add(Me.LESeason)
        Me.PanelControl5.Controls.Add(Me.LabelControl10)
        Me.PanelControl5.Controls.Add(Me.LabelControl11)
        Me.PanelControl5.Controls.Add(Me.TEDueDate)
        Me.PanelControl5.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl5.Location = New System.Drawing.Point(612, 2)
        Me.PanelControl5.Name = "PanelControl5"
        Me.PanelControl5.Size = New System.Drawing.Size(295, 175)
        Me.PanelControl5.TabIndex = 146
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(11, 8)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl12.TabIndex = 139
        Me.LabelControl12.Text = "Season"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(11, 39)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl6.TabIndex = 124
        Me.LabelControl6.Text = "Date"
        '
        'LEDelivery
        '
        Me.LEDelivery.Location = New System.Drawing.Point(222, 5)
        Me.LEDelivery.Name = "LEDelivery"
        Me.LEDelivery.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LEDelivery.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black
        Me.LEDelivery.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.LEDelivery.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.LEDelivery.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEDelivery.Properties.NullText = ""
        Me.LEDelivery.Properties.ShowFooter = False
        Me.LEDelivery.Properties.View = Me.GridView1
        Me.LEDelivery.Size = New System.Drawing.Size(65, 20)
        Me.LEDelivery.TabIndex = 143
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id Season"
        Me.GridColumn1.FieldName = "id_delivery"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Delivery"
        Me.GridColumn2.FieldName = "delivery"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'TEDate
        '
        Me.TEDate.EditValue = ""
        Me.TEDate.Location = New System.Drawing.Point(83, 36)
        Me.TEDate.Name = "TEDate"
        Me.TEDate.Properties.EditValueChangedDelay = 1
        Me.TEDate.Properties.ReadOnly = True
        Me.TEDate.Size = New System.Drawing.Size(204, 20)
        Me.TEDate.TabIndex = 0
        Me.TEDate.TabStop = False
        '
        'TERecDate
        '
        Me.TERecDate.EditValue = ""
        Me.TERecDate.Location = New System.Drawing.Point(83, 68)
        Me.TERecDate.Name = "TERecDate"
        Me.TERecDate.Properties.EditValueChangedDelay = 1
        Me.TERecDate.Properties.ReadOnly = True
        Me.TERecDate.Size = New System.Drawing.Size(204, 20)
        Me.TERecDate.TabIndex = 0
        Me.TERecDate.TabStop = False
        '
        'LESeason
        '
        Me.LESeason.Location = New System.Drawing.Point(83, 5)
        Me.LESeason.Name = "LESeason"
        Me.LESeason.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LESeason.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black
        Me.LESeason.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.LESeason.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.LESeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LESeason.Properties.NullText = ""
        Me.LESeason.Properties.ShowFooter = False
        Me.LESeason.Properties.View = Me.GridView2
        Me.LESeason.Size = New System.Drawing.Size(133, 20)
        Me.LESeason.TabIndex = 7
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn4})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Id Season"
        Me.GridColumn3.FieldName = "id_season"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Season"
        Me.GridColumn4.FieldName = "season"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 0
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(11, 71)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(66, 13)
        Me.LabelControl10.TabIndex = 135
        Me.LabelControl10.Text = "Est. Rec Date"
        '
        'LabelControl11
        '
        Me.LabelControl11.Location = New System.Drawing.Point(11, 104)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl11.TabIndex = 137
        Me.LabelControl11.Text = "Due Date"
        '
        'TEDueDate
        '
        Me.TEDueDate.EditValue = ""
        Me.TEDueDate.Location = New System.Drawing.Point(83, 101)
        Me.TEDueDate.Name = "TEDueDate"
        Me.TEDueDate.Properties.EditValueChangedDelay = 1
        Me.TEDueDate.Properties.ReadOnly = True
        Me.TEDueDate.Size = New System.Drawing.Size(204, 20)
        Me.TEDueDate.TabIndex = 0
        Me.TEDueDate.TabStop = False
        '
        'PanelControl3
        '
        Me.PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl3.Controls.Add(Me.BPickPORev)
        Me.PanelControl3.Controls.Add(Me.TEWORevNumber)
        Me.PanelControl3.Controls.Add(Me.LabelControl24)
        Me.PanelControl3.Controls.Add(Me.LabelControl4)
        Me.PanelControl3.Controls.Add(Me.TECompCode)
        Me.PanelControl3.Controls.Add(Me.TECompName)
        Me.PanelControl3.Controls.Add(Me.MECompAddress)
        Me.PanelControl3.Controls.Add(Me.TECompAttn)
        Me.PanelControl3.Controls.Add(Me.BSearchCompTo)
        Me.PanelControl3.Controls.Add(Me.LabelControl1)
        Me.PanelControl3.Controls.Add(Me.LabelControl2)
        Me.PanelControl3.Controls.Add(Me.LabelControl5)
        Me.PanelControl3.Controls.Add(Me.LEWOType)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl3.Location = New System.Drawing.Point(22, 2)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(345, 175)
        Me.PanelControl3.TabIndex = 144
        '
        'BPickPORev
        '
        Me.BPickPORev.Location = New System.Drawing.Point(312, 9)
        Me.BPickPORev.Name = "BPickPORev"
        Me.BPickPORev.Size = New System.Drawing.Size(23, 20)
        Me.BPickPORev.TabIndex = 153
        Me.BPickPORev.Text = "..."
        '
        'TEWORevNumber
        '
        Me.TEWORevNumber.EditValue = "-"
        Me.TEWORevNumber.Location = New System.Drawing.Point(83, 9)
        Me.TEWORevNumber.Name = "TEWORevNumber"
        Me.TEWORevNumber.Properties.EditValueChangedDelay = 1
        Me.TEWORevNumber.Properties.ReadOnly = True
        Me.TEWORevNumber.Size = New System.Drawing.Size(223, 20)
        Me.TEWORevNumber.TabIndex = 152
        '
        'LabelControl24
        '
        Me.LabelControl24.Location = New System.Drawing.Point(8, 15)
        Me.LabelControl24.Name = "LabelControl24"
        Me.LabelControl24.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl24.TabIndex = 151
        Me.LabelControl24.Text = "Revised From"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(8, 43)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(12, 13)
        Me.LabelControl4.TabIndex = 88
        Me.LabelControl4.Text = "To"
        '
        'TECompCode
        '
        Me.TECompCode.EditValue = ""
        Me.TECompCode.Location = New System.Drawing.Point(83, 40)
        Me.TECompCode.Name = "TECompCode"
        Me.TECompCode.Properties.EditValueChangedDelay = 1
        Me.TECompCode.Properties.ReadOnly = True
        Me.TECompCode.Size = New System.Drawing.Size(73, 20)
        Me.TECompCode.TabIndex = 0
        Me.TECompCode.TabStop = False
        '
        'TECompName
        '
        Me.TECompName.EditValue = ""
        Me.TECompName.Location = New System.Drawing.Point(162, 40)
        Me.TECompName.Name = "TECompName"
        Me.TECompName.Properties.EditValueChangedDelay = 1
        Me.TECompName.Properties.ReadOnly = True
        Me.TECompName.Size = New System.Drawing.Size(144, 20)
        Me.TECompName.TabIndex = 0
        Me.TECompName.TabStop = False
        '
        'MECompAddress
        '
        Me.MECompAddress.Location = New System.Drawing.Point(83, 92)
        Me.MECompAddress.Name = "MECompAddress"
        Me.MECompAddress.Properties.MaxLength = 100
        Me.MECompAddress.Properties.ReadOnly = True
        Me.MECompAddress.Size = New System.Drawing.Size(252, 41)
        Me.MECompAddress.TabIndex = 0
        Me.MECompAddress.TabStop = False
        '
        'TECompAttn
        '
        Me.TECompAttn.EditValue = ""
        Me.TECompAttn.Location = New System.Drawing.Point(83, 66)
        Me.TECompAttn.Name = "TECompAttn"
        Me.TECompAttn.Properties.EditValueChangedDelay = 1
        Me.TECompAttn.Properties.ReadOnly = True
        Me.TECompAttn.Size = New System.Drawing.Size(252, 20)
        Me.TECompAttn.TabIndex = 0
        Me.TECompAttn.TabStop = False
        '
        'BSearchCompTo
        '
        Me.BSearchCompTo.Location = New System.Drawing.Point(312, 40)
        Me.BSearchCompTo.Name = "BSearchCompTo"
        Me.BSearchCompTo.Size = New System.Drawing.Size(23, 20)
        Me.BSearchCompTo.TabIndex = 1
        Me.BSearchCompTo.Text = "..."
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(8, 143)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl1.TabIndex = 121
        Me.LabelControl1.Text = "WO Type"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(8, 69)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(25, 13)
        Me.LabelControl2.TabIndex = 122
        Me.LabelControl2.Text = "Attn."
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(8, 94)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl5.TabIndex = 123
        Me.LabelControl5.Text = "Address"
        '
        'LEWOType
        '
        Me.LEWOType.Location = New System.Drawing.Point(83, 140)
        Me.LEWOType.Name = "LEWOType"
        Me.LEWOType.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LEWOType.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black
        Me.LEWOType.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.LEWOType.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.LEWOType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEWOType.Properties.NullText = ""
        Me.LEWOType.Properties.ShowFooter = False
        Me.LEWOType.Properties.View = Me.GridView3
        Me.LEWOType.Size = New System.Drawing.Size(252, 20)
        Me.LEWOType.TabIndex = 2
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdPOType, Me.ColPOType})
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'ColIdPOType
        '
        Me.ColIdPOType.Caption = "Id PO Type"
        Me.ColIdPOType.FieldName = "id_ovh"
        Me.ColIdPOType.Name = "ColIdPOType"
        '
        'ColPOType
        '
        Me.ColPOType.Caption = "PO Type"
        Me.ColPOType.FieldName = "overhead"
        Me.ColPOType.Name = "ColPOType"
        Me.ColPOType.Visible = True
        Me.ColPOType.VisibleIndex = 0
        '
        'FormMatWODet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(909, 586)
        Me.Controls.Add(Me.GConListPurchase)
        Me.Controls.Add(Me.GroupGeneralFooter)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.GroupGeneralHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "FormMatWODet"
        Me.ShowInTaskbar = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Raw Material Work Order Detail"
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EPMatWO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.GroupGeneralFooter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneralFooter.ResumeLayout(False)
        Me.GroupGeneralFooter.PerformLayout()
        CType(Me.PanelControl7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl7.ResumeLayout(False)
        Me.PanelControl7.PerformLayout()
        CType(Me.TEDiscount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEKurs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEVatTot.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TETot.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LECurrency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.METotSay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEGrossTot.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEVat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MECompShipToAddress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECompShipToName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECompShipTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GConListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GConListPurchase.ResumeLayout(False)
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XTPWorkOrder.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.XTPMaterial.ResumeLayout(False)
        CType(Me.GCMaterial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMaterial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl6.ResumeLayout(False)
        CType(Me.GroupGeneralHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneralHeader.ResumeLayout(False)
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        Me.PanelControl4.PerformLayout()
        CType(Me.TEPONumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEpayment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TELeadTime.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TETOP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl5.ResumeLayout(False)
        Me.PanelControl5.PerformLayout()
        CType(Me.LEDelivery.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TERecDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDueDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.TEWORevNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECompCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECompName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MECompAddress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECompAttn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEWOType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents EPMatWO As System.Windows.Forms.ErrorProvider
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupGeneralFooter As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEKurs As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl22 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LECurrency As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl19 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents METotSay As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents TEVat As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelControl17 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEGrossTot As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl16 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TETot As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEVatTot As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEDiscount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl20 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BSearchCompShipTo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents MECompShipToAddress As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents TECompShipToName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TECompShipTo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl23 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GConListPurchase As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCListPurchase As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListPurchase As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdPurcDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdOvhPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdMat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDiscount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSubtotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Bdel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupGeneralHeader As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LEDelivery As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LEpayment As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LESeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEDueDate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TERecDate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEWOType As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdPOType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPOType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TETOP As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TELeadTime As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEDate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BSearchCompTo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TECompAttn As DevExpress.XtraEditors.TextEdit
    Friend WithEvents MECompAddress As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents TECompName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TECompCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEPONumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl5 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPWorkOrder As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPMaterial As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCMaterial As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMaterial As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl6 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BDelMaterial As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BEditMaterial As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BAddMaterial As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdMatDetPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUOMMat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl7 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BPickPORev As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEWORevNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl24 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BAttach As DevExpress.XtraEditors.SimpleButton
End Class
