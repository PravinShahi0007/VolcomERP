<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterAssetLog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterAssetLog))
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LECurDep = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LECurUser = New DevExpress.XtraEditors.LookUpEdit()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.DEMovingDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LENewDep = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LENewUser = New DevExpress.XtraEditors.LookUpEdit()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.TEDesc = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LEAssetCat = New DevExpress.XtraEditors.LookUpEdit()
        Me.TEOldCode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.TECode = New DevExpress.XtraEditors.TextEdit()
        Me.BNothingUser = New DevExpress.XtraEditors.SimpleButton()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.LECurDep.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LECurUser.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.DEMovingDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEMovingDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LENewDep.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LENewUser.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.TEDesc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEAssetCat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEOldCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.LargeImageCollection.Images.SetKeyName(10, "1415351112474759854-32.png")
        Me.LargeImageCollection.Images.SetKeyName(11, "icon_merchandise_clothes32.png")
        Me.LargeImageCollection.Images.SetKeyName(12, "t_shirtgreen.png")
        Me.LargeImageCollection.Images.SetKeyName(13, "lock red.png")
        Me.LargeImageCollection.Images.SetKeyName(14, "ordering32.png")
        Me.LargeImageCollection.Images.SetKeyName(15, "kghostview.png")
        Me.LargeImageCollection.Images.SetKeyName(16, "MetroUI-Folder-OS-Configure-icon.png")
        Me.LargeImageCollection.Images.SetKeyName(17, "Setting(32).png")
        Me.LargeImageCollection.Images.SetKeyName(18, "estimate_icon32.png")
        Me.LargeImageCollection.Images.SetKeyName(19, "copy_icon.png")
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.BPrint)
        Me.PanelControl3.Controls.Add(Me.BCancel)
        Me.PanelControl3.Controls.Add(Me.BSave)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 350)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(496, 37)
        Me.PanelControl3.TabIndex = 153
        '
        'BCancel
        '
        Me.BCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCancel.ImageIndex = 5
        Me.BCancel.ImageList = Me.LargeImageCollection
        Me.BCancel.Location = New System.Drawing.Point(346, 2)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(73, 33)
        Me.BCancel.TabIndex = 21
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.ImageIndex = 7
        Me.BSave.ImageList = Me.LargeImageCollection
        Me.BSave.Location = New System.Drawing.Point(419, 2)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(75, 33)
        Me.BSave.TabIndex = 20
        Me.BSave.Text = "Save"
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.LECurDep)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.LECurUser)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 120)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(496, 67)
        Me.GroupControl1.TabIndex = 155
        Me.GroupControl1.Text = "Current"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(34, 14)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl1.TabIndex = 13
        Me.LabelControl1.Text = "Departement"
        '
        'LECurDep
        '
        Me.LECurDep.Enabled = False
        Me.LECurDep.Location = New System.Drawing.Point(103, 11)
        Me.LECurDep.Name = "LECurDep"
        Me.LECurDep.Properties.Appearance.Options.UseTextOptions = True
        Me.LECurDep.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LECurDep.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LECurDep.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.LECurDep.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.LECurDep.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.LECurDep.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LECurDep.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_departement", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("departement_code", "Code"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("departement", "Departement")})
        Me.LECurDep.Properties.NullText = ""
        Me.LECurDep.Properties.ShowFooter = False
        Me.LECurDep.Size = New System.Drawing.Size(279, 20)
        Me.LECurDep.TabIndex = 4
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(34, 40)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl2.TabIndex = 14
        Me.LabelControl2.Text = "User"
        '
        'LECurUser
        '
        Me.LECurUser.Enabled = False
        Me.LECurUser.Location = New System.Drawing.Point(103, 37)
        Me.LECurUser.Name = "LECurUser"
        Me.LECurUser.Properties.Appearance.Options.UseTextOptions = True
        Me.LECurUser.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LECurUser.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LECurUser.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.LECurUser.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.LECurUser.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.LECurUser.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LECurUser.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_employee", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("employee_code", "NIK"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("employee_name", "Employee")})
        Me.LECurUser.Properties.NullText = ""
        Me.LECurUser.Properties.ShowFooter = False
        Me.LECurUser.Size = New System.Drawing.Size(279, 20)
        Me.LECurUser.TabIndex = 5
        '
        'GroupControl3
        '
        Me.GroupControl3.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl3.Controls.Add(Me.BNothingUser)
        Me.GroupControl3.Controls.Add(Me.DEMovingDate)
        Me.GroupControl3.Controls.Add(Me.LabelControl10)
        Me.GroupControl3.Controls.Add(Me.MENote)
        Me.GroupControl3.Controls.Add(Me.LabelControl9)
        Me.GroupControl3.Controls.Add(Me.LabelControl3)
        Me.GroupControl3.Controls.Add(Me.LENewDep)
        Me.GroupControl3.Controls.Add(Me.LabelControl4)
        Me.GroupControl3.Controls.Add(Me.LENewUser)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl3.Location = New System.Drawing.Point(0, 187)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(496, 163)
        Me.GroupControl3.TabIndex = 156
        Me.GroupControl3.Text = "New Location"
        '
        'DEMovingDate
        '
        Me.DEMovingDate.EditValue = Nothing
        Me.DEMovingDate.Location = New System.Drawing.Point(103, 131)
        Me.DEMovingDate.Name = "DEMovingDate"
        Me.DEMovingDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEMovingDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEMovingDate.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEMovingDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEMovingDate.Size = New System.Drawing.Size(213, 20)
        Me.DEMovingDate.TabIndex = 18
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(33, 134)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(60, 13)
        Me.LabelControl10.TabIndex = 17
        Me.LabelControl10.Text = "Date Moving"
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(103, 63)
        Me.MENote.Name = "MENote"
        Me.MENote.Size = New System.Drawing.Size(354, 62)
        Me.MENote.TabIndex = 16
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(33, 70)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl9.TabIndex = 15
        Me.LabelControl9.Text = "Note"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(34, 14)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl3.TabIndex = 13
        Me.LabelControl3.Text = "Departement"
        '
        'LENewDep
        '
        Me.LENewDep.Location = New System.Drawing.Point(103, 11)
        Me.LENewDep.Name = "LENewDep"
        Me.LENewDep.Properties.Appearance.Options.UseTextOptions = True
        Me.LENewDep.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LENewDep.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LENewDep.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.LENewDep.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.LENewDep.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.LENewDep.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LENewDep.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_departement", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("departement_code", "Code"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("departement", "Departement")})
        Me.LENewDep.Properties.NullText = ""
        Me.LENewDep.Properties.ShowFooter = False
        Me.LENewDep.Size = New System.Drawing.Size(279, 20)
        Me.LENewDep.TabIndex = 4
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(34, 40)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl4.TabIndex = 14
        Me.LabelControl4.Text = "User"
        '
        'LENewUser
        '
        Me.LENewUser.Location = New System.Drawing.Point(103, 37)
        Me.LENewUser.Name = "LENewUser"
        Me.LENewUser.Properties.Appearance.Options.UseTextOptions = True
        Me.LENewUser.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LENewUser.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LENewUser.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.LENewUser.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.LENewUser.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.LENewUser.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LENewUser.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_employee", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("employee_code", "NIK"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("employee_name", "Employee")})
        Me.LENewUser.Properties.NullText = ""
        Me.LENewUser.Properties.ShowFooter = False
        Me.LENewUser.Size = New System.Drawing.Size(279, 20)
        Me.LENewUser.TabIndex = 5
        '
        'GroupControl2
        '
        Me.GroupControl2.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl2.Controls.Add(Me.LabelControl5)
        Me.GroupControl2.Controls.Add(Me.TEDesc)
        Me.GroupControl2.Controls.Add(Me.LabelControl6)
        Me.GroupControl2.Controls.Add(Me.LEAssetCat)
        Me.GroupControl2.Controls.Add(Me.TEOldCode)
        Me.GroupControl2.Controls.Add(Me.LabelControl7)
        Me.GroupControl2.Controls.Add(Me.LabelControl8)
        Me.GroupControl2.Controls.Add(Me.TECode)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(496, 120)
        Me.GroupControl2.TabIndex = 157
        Me.GroupControl2.Text = "Asset"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(34, 16)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(25, 13)
        Me.LabelControl5.TabIndex = 7
        Me.LabelControl5.Text = "Code"
        '
        'TEDesc
        '
        Me.TEDesc.Location = New System.Drawing.Point(103, 65)
        Me.TEDesc.Name = "TEDesc"
        Me.TEDesc.Properties.ReadOnly = True
        Me.TEDesc.Size = New System.Drawing.Size(354, 20)
        Me.TEDesc.TabIndex = 2
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(34, 68)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl6.TabIndex = 8
        Me.LabelControl6.Text = "Description"
        '
        'LEAssetCat
        '
        Me.LEAssetCat.Enabled = False
        Me.LEAssetCat.Location = New System.Drawing.Point(103, 91)
        Me.LEAssetCat.Name = "LEAssetCat"
        Me.LEAssetCat.Properties.Appearance.Options.UseTextOptions = True
        Me.LEAssetCat.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEAssetCat.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LEAssetCat.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.LEAssetCat.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.LEAssetCat.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.LEAssetCat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEAssetCat.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_asset_cat", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("asset_cat_code", "Code"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("asset_cat", "Category")})
        Me.LEAssetCat.Properties.NullText = ""
        Me.LEAssetCat.Properties.ShowFooter = False
        Me.LEAssetCat.Size = New System.Drawing.Size(242, 20)
        Me.LEAssetCat.TabIndex = 3
        '
        'TEOldCode
        '
        Me.TEOldCode.Location = New System.Drawing.Point(103, 39)
        Me.TEOldCode.Name = "TEOldCode"
        Me.TEOldCode.Properties.ReadOnly = True
        Me.TEOldCode.Size = New System.Drawing.Size(242, 20)
        Me.TEOldCode.TabIndex = 1
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(34, 42)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(44, 13)
        Me.LabelControl7.TabIndex = 9
        Me.LabelControl7.Text = "Old Code"
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(34, 94)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl8.TabIndex = 6
        Me.LabelControl8.Text = "Category "
        '
        'TECode
        '
        Me.TECode.Location = New System.Drawing.Point(103, 13)
        Me.TECode.Name = "TECode"
        Me.TECode.Properties.ReadOnly = True
        Me.TECode.Size = New System.Drawing.Size(213, 20)
        Me.TECode.TabIndex = 1
        Me.TECode.TabStop = False
        '
        'BNothingUser
        '
        Me.BNothingUser.Location = New System.Drawing.Point(388, 35)
        Me.BNothingUser.Name = "BNothingUser"
        Me.BNothingUser.Size = New System.Drawing.Size(75, 23)
        Me.BNothingUser.TabIndex = 19
        Me.BNothingUser.Text = "set nothing"
        '
        'BPrint
        '
        Me.BPrint.Dock = System.Windows.Forms.DockStyle.Left
        Me.BPrint.ImageIndex = 6
        Me.BPrint.ImageList = Me.LargeImageCollection
        Me.BPrint.Location = New System.Drawing.Point(2, 2)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(73, 33)
        Me.BPrint.TabIndex = 22
        Me.BPrint.Text = "Print"
        '
        'FormMasterAssetLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(496, 387)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.GroupControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterAssetLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Log Moving Detail"
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.LECurDep.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LECurUser.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        CType(Me.DEMovingDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEMovingDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LENewDep.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LENewUser.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.TEDesc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEAssetCat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEOldCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LECurDep As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LECurUser As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LENewDep As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LENewUser As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEDesc As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEAssetCat As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents TEOldCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TECode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEMovingDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents BNothingUser As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
End Class
