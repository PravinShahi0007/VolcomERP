<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProductionCOPDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProductionCOPDet))
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TEEcop = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TEKurs = New DevExpress.XtraEditors.TextEdit()
        Me.LECurrency = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TECode = New DevExpress.XtraEditors.TextEdit()
        Me.TEDesc = New DevExpress.XtraEditors.TextEdit()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TEVendor = New DevExpress.XtraEditors.TextEdit()
        Me.TEVendorName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.BPickOVH = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.BUploadFile = New DevExpress.XtraEditors.ButtonEdit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEEcop.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEKurs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LECurrency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDesc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.TEVendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEVendorName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BUploadFile.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(12, 118)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl4.TabIndex = 8918
        Me.LabelControl4.Text = "Price"
        '
        'TEEcop
        '
        Me.TEEcop.EditValue = ""
        Me.TEEcop.Location = New System.Drawing.Point(85, 115)
        Me.TEEcop.Name = "TEEcop"
        Me.TEEcop.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEEcop.Properties.Appearance.Options.UseFont = True
        Me.TEEcop.Properties.Appearance.Options.UseTextOptions = True
        Me.TEEcop.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEEcop.Properties.DisplayFormat.FormatString = "N2"
        Me.TEEcop.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TEEcop.Properties.EditFormat.FormatString = "N2"
        Me.TEEcop.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TEEcop.Properties.EditValueChangedDelay = 1
        Me.TEEcop.Properties.Mask.EditMask = "N2"
        Me.TEEcop.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEEcop.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEEcop.Size = New System.Drawing.Size(231, 20)
        Me.TEEcop.TabIndex = 8908
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(12, 92)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl3.TabIndex = 8917
        Me.LabelControl3.Text = "Kurs"
        '
        'TEKurs
        '
        Me.TEKurs.EditValue = ""
        Me.TEKurs.Location = New System.Drawing.Point(85, 89)
        Me.TEKurs.Name = "TEKurs"
        Me.TEKurs.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEKurs.Properties.Appearance.Options.UseFont = True
        Me.TEKurs.Properties.Appearance.Options.UseTextOptions = True
        Me.TEKurs.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEKurs.Properties.EditValueChangedDelay = 1
        Me.TEKurs.Properties.Mask.EditMask = "N2"
        Me.TEKurs.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEKurs.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEKurs.Size = New System.Drawing.Size(231, 20)
        Me.TEKurs.TabIndex = 8907
        '
        'LECurrency
        '
        Me.LECurrency.Location = New System.Drawing.Point(85, 63)
        Me.LECurrency.Name = "LECurrency"
        Me.LECurrency.Properties.Appearance.Options.UseTextOptions = True
        Me.LECurrency.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LECurrency.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LECurrency.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_currency", "Id Currency", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("currency", "Currency")})
        Me.LECurrency.Properties.NullText = ""
        Me.LECurrency.Properties.ShowFooter = False
        Me.LECurrency.Size = New System.Drawing.Size(173, 20)
        Me.LECurrency.TabIndex = 8906
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(12, 67)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(44, 13)
        Me.LabelControl7.TabIndex = 8916
        Me.LabelControl7.Text = "Currency"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(12, 14)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl2.TabIndex = 8914
        Me.LabelControl2.Text = "Work Order"
        '
        'TECode
        '
        Me.TECode.EditValue = ""
        Me.TECode.Location = New System.Drawing.Point(85, 11)
        Me.TECode.Name = "TECode"
        Me.TECode.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TECode.Properties.Appearance.Options.UseFont = True
        Me.TECode.Properties.EditValueChangedDelay = 1
        Me.TECode.Properties.ReadOnly = True
        Me.TECode.Size = New System.Drawing.Size(130, 20)
        Me.TECode.TabIndex = 8913
        Me.TECode.TabStop = False
        '
        'TEDesc
        '
        Me.TEDesc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TEDesc.EditValue = ""
        Me.TEDesc.Location = New System.Drawing.Point(251, 11)
        Me.TEDesc.Name = "TEDesc"
        Me.TEDesc.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEDesc.Properties.Appearance.Options.UseFont = True
        Me.TEDesc.Properties.EditValueChangedDelay = 1
        Me.TEDesc.Properties.ReadOnly = True
        Me.TEDesc.Size = New System.Drawing.Size(266, 20)
        Me.TEDesc.TabIndex = 8915
        Me.TEDesc.TabStop = False
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.BtnCancel)
        Me.PanelControl3.Controls.Add(Me.BtnSave)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 172)
        Me.PanelControl3.LookAndFeel.SkinName = "Blue"
        Me.PanelControl3.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(529, 38)
        Me.PanelControl3.TabIndex = 8909
        Me.PanelControl3.TabStop = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.ImageIndex = 5
        Me.BtnCancel.ImageList = Me.LargeImageCollection
        Me.BtnCancel.Location = New System.Drawing.Point(377, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 34)
        Me.BtnCancel.TabIndex = 7
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.ImageIndex = 7
        Me.BtnSave.ImageList = Me.LargeImageCollection
        Me.BtnSave.Location = New System.Drawing.Point(452, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 34)
        Me.BtnSave.TabIndex = 6
        Me.BtnSave.Text = "Save"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(12, 40)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl1.TabIndex = 8911
        Me.LabelControl1.Text = "Vendor"
        '
        'TEVendor
        '
        Me.TEVendor.EditValue = ""
        Me.TEVendor.Location = New System.Drawing.Point(85, 37)
        Me.TEVendor.Name = "TEVendor"
        Me.TEVendor.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEVendor.Properties.Appearance.Options.UseFont = True
        Me.TEVendor.Properties.EditValueChangedDelay = 1
        Me.TEVendor.Properties.ReadOnly = True
        Me.TEVendor.Size = New System.Drawing.Size(130, 20)
        Me.TEVendor.TabIndex = 8905
        '
        'TEVendorName
        '
        Me.TEVendorName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TEVendorName.EditValue = ""
        Me.TEVendorName.Location = New System.Drawing.Point(221, 37)
        Me.TEVendorName.Name = "TEVendorName"
        Me.TEVendorName.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEVendorName.Properties.Appearance.Options.UseFont = True
        Me.TEVendorName.Properties.EditValueChangedDelay = 1
        Me.TEVendorName.Properties.ReadOnly = True
        Me.TEVendorName.Size = New System.Drawing.Size(262, 20)
        Me.TEVendorName.TabIndex = 8912
        Me.TEVendorName.TabStop = False
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(221, 14)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl5.TabIndex = 8919
        Me.LabelControl5.Text = "Type"
        '
        'BPickOVH
        '
        Me.BPickOVH.Location = New System.Drawing.Point(489, 35)
        Me.BPickOVH.Name = "BPickOVH"
        Me.BPickOVH.Size = New System.Drawing.Size(28, 23)
        Me.BPickOVH.TabIndex = 8920
        Me.BPickOVH.Text = "..."
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(12, 144)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl6.TabIndex = 8921
        Me.LabelControl6.Text = "Attachment"
        '
        'BUploadFile
        '
        Me.BUploadFile.Location = New System.Drawing.Point(85, 141)
        Me.BUploadFile.Name = "BUploadFile"
        Me.BUploadFile.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.BUploadFile.Properties.ReadOnly = True
        Me.BUploadFile.Size = New System.Drawing.Size(432, 20)
        Me.BUploadFile.TabIndex = 8922
        '
        'FormProductionCOPDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(529, 210)
        Me.Controls.Add(Me.BUploadFile)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.BPickOVH)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.TEEcop)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.TEKurs)
        Me.Controls.Add(Me.LECurrency)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.TECode)
        Me.Controls.Add(Me.TEDesc)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.TEVendor)
        Me.Controls.Add(Me.TEVendorName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProductionCOPDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Price"
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEEcop.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEKurs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LECurrency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDesc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.TEVendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEVendorName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BUploadFile.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEEcop As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEKurs As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LECurrency As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TECode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEDesc As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEVendor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEVendorName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BPickOVH As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BUploadFile As DevExpress.XtraEditors.ButtonEdit
End Class
