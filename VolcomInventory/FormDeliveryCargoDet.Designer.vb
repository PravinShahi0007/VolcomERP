<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDeliveryCargoDet
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDeliveryCargoDet))
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.XTCDetail = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPDetail = New DevExpress.XtraTab.XtraTabPage()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.TEBeratTerpakai = New DevExpress.XtraEditors.TextEdit()
        Me.TEWeight = New DevExpress.XtraEditors.TextEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TEVolume = New DevExpress.XtraEditors.TextEdit()
        Me.TELength = New DevExpress.XtraEditors.TextEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TEHeight = New DevExpress.XtraEditors.TextEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TEWidth = New DevExpress.XtraEditors.TextEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.XTPInvoice = New DevExpress.XtraTab.XtraTabPage()
        Me.BRecStoreNothing = New DevExpress.XtraEditors.SimpleButton()
        Me.BPickupNothing = New DevExpress.XtraEditors.SimpleButton()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.DEStore = New DevExpress.XtraEditors.DateEdit()
        Me.DEPickUp = New DevExpress.XtraEditors.DateEdit()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TEInvNo = New DevExpress.XtraEditors.TextEdit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.XTCDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCDetail.SuspendLayout()
        Me.XTPDetail.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.TEBeratTerpakai.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEWeight.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEVolume.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TELength.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEHeight.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEWidth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStore.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEPickUp.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEPickUp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEInvNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.LargeImageCollection.Images.SetKeyName(15, "1417618546_Blue tag.png")
        Me.LargeImageCollection.Images.SetKeyName(16, "attachment-icon.png")
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.XTCDetail)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(803, 264)
        Me.GroupControl2.TabIndex = 3
        Me.GroupControl2.Text = "Detail"
        '
        'XTCDetail
        '
        Me.XTCDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCDetail.Location = New System.Drawing.Point(2, 20)
        Me.XTCDetail.Name = "XTCDetail"
        Me.XTCDetail.SelectedTabPage = Me.XTPDetail
        Me.XTCDetail.Size = New System.Drawing.Size(799, 242)
        Me.XTCDetail.TabIndex = 104
        Me.XTCDetail.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPDetail, Me.XTPInvoice})
        '
        'XTPDetail
        '
        Me.XTPDetail.Controls.Add(Me.BRecStoreNothing)
        Me.XTPDetail.Controls.Add(Me.BPickupNothing)
        Me.XTPDetail.Controls.Add(Me.Label18)
        Me.XTPDetail.Controls.Add(Me.MENote)
        Me.XTPDetail.Controls.Add(Me.DEStore)
        Me.XTPDetail.Controls.Add(Me.DEPickUp)
        Me.XTPDetail.Controls.Add(Me.Label17)
        Me.XTPDetail.Controls.Add(Me.Label16)
        Me.XTPDetail.Controls.Add(Me.Label15)
        Me.XTPDetail.Controls.Add(Me.TEInvNo)
        Me.XTPDetail.Controls.Add(Me.PanelControl3)
        Me.XTPDetail.Name = "XTPDetail"
        Me.XTPDetail.Size = New System.Drawing.Size(793, 214)
        Me.XTPDetail.Text = "Calculation"
        '
        'PanelControl3
        '
        Me.PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl3.Controls.Add(Me.TEBeratTerpakai)
        Me.PanelControl3.Controls.Add(Me.TEWeight)
        Me.PanelControl3.Controls.Add(Me.Label5)
        Me.PanelControl3.Controls.Add(Me.Label4)
        Me.PanelControl3.Controls.Add(Me.Label11)
        Me.PanelControl3.Controls.Add(Me.TEVolume)
        Me.PanelControl3.Controls.Add(Me.TELength)
        Me.PanelControl3.Controls.Add(Me.Label1)
        Me.PanelControl3.Controls.Add(Me.TEHeight)
        Me.PanelControl3.Controls.Add(Me.Label2)
        Me.PanelControl3.Controls.Add(Me.TEWidth)
        Me.PanelControl3.Controls.Add(Me.Label3)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(793, 62)
        Me.PanelControl3.TabIndex = 102
        '
        'TEBeratTerpakai
        '
        Me.TEBeratTerpakai.Location = New System.Drawing.Point(636, 31)
        Me.TEBeratTerpakai.Name = "TEBeratTerpakai"
        Me.TEBeratTerpakai.Properties.Appearance.Options.UseTextOptions = True
        Me.TEBeratTerpakai.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEBeratTerpakai.Properties.Mask.EditMask = "N2"
        Me.TEBeratTerpakai.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEBeratTerpakai.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEBeratTerpakai.Properties.ReadOnly = True
        Me.TEBeratTerpakai.Size = New System.Drawing.Size(145, 20)
        Me.TEBeratTerpakai.TabIndex = 93
        Me.TEBeratTerpakai.TabStop = False
        '
        'TEWeight
        '
        Me.TEWeight.Location = New System.Drawing.Point(13, 31)
        Me.TEWeight.Name = "TEWeight"
        Me.TEWeight.Properties.Appearance.Options.UseTextOptions = True
        Me.TEWeight.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEWeight.Properties.Mask.EditMask = "N2"
        Me.TEWeight.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEWeight.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEWeight.Size = New System.Drawing.Size(116, 20)
        Me.TEWeight.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Berat (Kg)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(462, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Dimensional Weight"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(633, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(89, 13)
        Me.Label11.TabIndex = 92
        Me.Label11.Text = "Final Weight (Kg)"
        '
        'TEVolume
        '
        Me.TEVolume.Location = New System.Drawing.Point(465, 31)
        Me.TEVolume.Name = "TEVolume"
        Me.TEVolume.Properties.Appearance.Options.UseTextOptions = True
        Me.TEVolume.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEVolume.Properties.Mask.EditMask = "N2"
        Me.TEVolume.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEVolume.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEVolume.Properties.ReadOnly = True
        Me.TEVolume.Size = New System.Drawing.Size(165, 20)
        Me.TEVolume.TabIndex = 9
        Me.TEVolume.TabStop = False
        '
        'TELength
        '
        Me.TELength.Location = New System.Drawing.Point(143, 31)
        Me.TELength.Name = "TELength"
        Me.TELength.Properties.Appearance.Options.UseTextOptions = True
        Me.TELength.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TELength.Properties.Mask.EditMask = "N2"
        Me.TELength.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TELength.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TELength.Size = New System.Drawing.Size(100, 20)
        Me.TELength.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(140, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Panjang (cm)"
        '
        'TEHeight
        '
        Me.TEHeight.Location = New System.Drawing.Point(355, 31)
        Me.TEHeight.Name = "TEHeight"
        Me.TEHeight.Properties.Appearance.Options.UseTextOptions = True
        Me.TEHeight.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEHeight.Properties.Mask.EditMask = "N2"
        Me.TEHeight.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEHeight.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEHeight.Size = New System.Drawing.Size(100, 20)
        Me.TEHeight.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(246, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Lebar (cm)"
        '
        'TEWidth
        '
        Me.TEWidth.Location = New System.Drawing.Point(249, 31)
        Me.TEWidth.Name = "TEWidth"
        Me.TEWidth.Properties.Appearance.Options.UseTextOptions = True
        Me.TEWidth.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEWidth.Properties.Mask.EditMask = "N2"
        Me.TEWidth.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEWidth.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEWidth.Size = New System.Drawing.Size(100, 20)
        Me.TEWidth.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(354, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Tinggi (cm)"
        '
        'XTPInvoice
        '
        Me.XTPInvoice.Name = "XTPInvoice"
        Me.XTPInvoice.Size = New System.Drawing.Size(793, 214)
        Me.XTPInvoice.Text = "AWB"
        '
        'BRecStoreNothing
        '
        Me.BRecStoreNothing.Location = New System.Drawing.Point(276, 96)
        Me.BRecStoreNothing.Name = "BRecStoreNothing"
        Me.BRecStoreNothing.Size = New System.Drawing.Size(80, 23)
        Me.BRecStoreNothing.TabIndex = 114
        Me.BRecStoreNothing.Text = "Set Nothing"
        '
        'BPickupNothing
        '
        Me.BPickupNothing.Location = New System.Drawing.Point(636, 96)
        Me.BPickupNothing.Name = "BPickupNothing"
        Me.BPickupNothing.Size = New System.Drawing.Size(80, 23)
        Me.BPickupNothing.TabIndex = 113
        Me.BPickupNothing.Text = "Set Nothing"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(10, 126)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(30, 13)
        Me.Label18.TabIndex = 111
        Me.Label18.Text = "Note"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(83, 125)
        Me.MENote.Name = "MENote"
        Me.MENote.Size = New System.Drawing.Size(633, 70)
        Me.MENote.TabIndex = 112
        '
        'DEStore
        '
        Me.DEStore.EditValue = Nothing
        Me.DEStore.Location = New System.Drawing.Point(439, 98)
        Me.DEStore.Name = "DEStore"
        Me.DEStore.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStore.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStore.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEStore.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStore.Size = New System.Drawing.Size(191, 20)
        Me.DEStore.TabIndex = 110
        '
        'DEPickUp
        '
        Me.DEPickUp.EditValue = Nothing
        Me.DEPickUp.Location = New System.Drawing.Point(83, 98)
        Me.DEPickUp.Name = "DEPickUp"
        Me.DEPickUp.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEPickUp.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEPickUp.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEPickUp.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEPickUp.Size = New System.Drawing.Size(187, 20)
        Me.DEPickUp.TabIndex = 109
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(362, 101)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(71, 13)
        Me.Label17.TabIndex = 107
        Me.Label17.Text = "Receive Date"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(10, 101)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(67, 13)
        Me.Label16.TabIndex = 106
        Me.Label16.Text = "Pick Up Date"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(9, 75)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(46, 13)
        Me.Label15.TabIndex = 105
        Me.Label15.Text = "AWB No"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TEInvNo
        '
        Me.TEInvNo.Location = New System.Drawing.Point(83, 72)
        Me.TEInvNo.Name = "TEInvNo"
        Me.TEInvNo.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEInvNo.Size = New System.Drawing.Size(187, 20)
        Me.TEInvNo.TabIndex = 108
        '
        'FormDeliveryCargoDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(803, 387)
        Me.Controls.Add(Me.GroupControl2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormDeliveryCargoDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Air Waybill Detail"
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.XTCDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCDetail.ResumeLayout(False)
        Me.XTPDetail.ResumeLayout(False)
        Me.XTPDetail.PerformLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.TEBeratTerpakai.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEWeight.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEVolume.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TELength.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEHeight.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEWidth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStore.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEPickUp.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEPickUp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEInvNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents XTCDetail As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPDetail As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents BRecStoreNothing As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BPickupNothing As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label18 As Label
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents DEStore As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEPickUp As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents TEInvNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TEBeratTerpakai As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEWeight As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents TEVolume As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TELength As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents TEHeight As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents TEWidth As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents XTPInvoice As DevExpress.XtraTab.XtraTabPage
End Class
