<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormWHCargoRate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormWHCargoRate))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BAddComp = New DevExpress.XtraEditors.SimpleButton()
        Me.GCCompany = New DevExpress.XtraGrid.GridControl()
        Me.GVCompany = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.XTCRate = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPOutbound = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPInbound = New DevExpress.XtraTab.XtraTabPage()
        Me.GCCompanyIn = New DevExpress.XtraGrid.GridControl()
        Me.GVCompanyIn = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BEditIn = New DevExpress.XtraEditors.SimpleButton()
        Me.BCompanyIn = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCRate.SuspendLayout()
        Me.XTPOutbound.SuspendLayout()
        Me.XTPInbound.SuspendLayout()
        CType(Me.GCCompanyIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVCompanyIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnEdit)
        Me.PanelControl1.Controls.Add(Me.BAddComp)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(849, 41)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnEdit
        '
        Me.BtnEdit.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnEdit.ImageIndex = 20
        Me.BtnEdit.ImageList = Me.LargeImageCollection
        Me.BtnEdit.Location = New System.Drawing.Point(617, 2)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(81, 37)
        Me.BtnEdit.TabIndex = 110
        Me.BtnEdit.Text = "Edit"
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
        Me.LargeImageCollection.Images.SetKeyName(20, "pencil.png")
        Me.LargeImageCollection.Images.SetKeyName(21, "edit-validated-icon.png")
        Me.LargeImageCollection.Images.SetKeyName(22, "Delete.png")
        Me.LargeImageCollection.Images.SetKeyName(23, "browse_3.png")
        Me.LargeImageCollection.Images.SetKeyName(24, "Full_Screen.png")
        Me.LargeImageCollection.Images.SetKeyName(25, "Exit_Full_Screen.png")
        '
        'BAddComp
        '
        Me.BAddComp.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAddComp.ImageIndex = 17
        Me.BAddComp.ImageList = Me.LargeImageCollection
        Me.BAddComp.Location = New System.Drawing.Point(698, 2)
        Me.BAddComp.Name = "BAddComp"
        Me.BAddComp.Size = New System.Drawing.Size(149, 37)
        Me.BAddComp.TabIndex = 3
        Me.BAddComp.Text = "Master Store / Cargo"
        Me.BAddComp.Visible = False
        '
        'GCCompany
        '
        Me.GCCompany.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCCompany.Location = New System.Drawing.Point(0, 41)
        Me.GCCompany.MainView = Me.GVCompany
        Me.GCCompany.Name = "GCCompany"
        Me.GCCompany.Size = New System.Drawing.Size(849, 393)
        Me.GCCompany.TabIndex = 5
        Me.GCCompany.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVCompany})
        '
        'GVCompany
        '
        Me.GVCompany.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.GVCompany.GridControl = Me.GCCompany
        Me.GVCompany.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.GVCompany.Name = "GVCompany"
        Me.GVCompany.OptionsBehavior.Editable = False
        Me.GVCompany.OptionsFind.AlwaysVisible = True
        Me.GVCompany.OptionsView.ColumnAutoWidth = False
        Me.GVCompany.OptionsView.ShowGroupPanel = False
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "GridBand1"
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        '
        'XTCRate
        '
        Me.XTCRate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCRate.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCRate.Location = New System.Drawing.Point(0, 0)
        Me.XTCRate.Name = "XTCRate"
        Me.XTCRate.SelectedTabPage = Me.XTPOutbound
        Me.XTCRate.Size = New System.Drawing.Size(855, 462)
        Me.XTCRate.TabIndex = 6
        Me.XTCRate.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPOutbound, Me.XTPInbound})
        '
        'XTPOutbound
        '
        Me.XTPOutbound.Controls.Add(Me.GCCompany)
        Me.XTPOutbound.Controls.Add(Me.PanelControl1)
        Me.XTPOutbound.Name = "XTPOutbound"
        Me.XTPOutbound.Size = New System.Drawing.Size(849, 434)
        Me.XTPOutbound.Text = "Outbound"
        '
        'XTPInbound
        '
        Me.XTPInbound.Controls.Add(Me.GCCompanyIn)
        Me.XTPInbound.Controls.Add(Me.PanelControl2)
        Me.XTPInbound.Name = "XTPInbound"
        Me.XTPInbound.Size = New System.Drawing.Size(849, 434)
        Me.XTPInbound.Text = "Inbound"
        '
        'GCCompanyIn
        '
        Me.GCCompanyIn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCCompanyIn.Location = New System.Drawing.Point(0, 41)
        Me.GCCompanyIn.MainView = Me.GVCompanyIn
        Me.GCCompanyIn.Name = "GCCompanyIn"
        Me.GCCompanyIn.Size = New System.Drawing.Size(849, 393)
        Me.GCCompanyIn.TabIndex = 7
        Me.GCCompanyIn.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVCompanyIn})
        '
        'GVCompanyIn
        '
        Me.GVCompanyIn.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand2})
        Me.GVCompanyIn.GridControl = Me.GCCompanyIn
        Me.GVCompanyIn.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.GVCompanyIn.Name = "GVCompanyIn"
        Me.GVCompanyIn.OptionsBehavior.Editable = False
        Me.GVCompanyIn.OptionsFind.AlwaysVisible = True
        Me.GVCompanyIn.OptionsView.ColumnAutoWidth = False
        Me.GVCompanyIn.OptionsView.ShowGroupPanel = False
        '
        'GridBand2
        '
        Me.GridBand2.Caption = "GridBand1"
        Me.GridBand2.Name = "GridBand2"
        Me.GridBand2.VisibleIndex = 0
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BEditIn)
        Me.PanelControl2.Controls.Add(Me.BCompanyIn)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(849, 41)
        Me.PanelControl2.TabIndex = 6
        '
        'BEditIn
        '
        Me.BEditIn.Dock = System.Windows.Forms.DockStyle.Right
        Me.BEditIn.ImageIndex = 20
        Me.BEditIn.ImageList = Me.LargeImageCollection
        Me.BEditIn.Location = New System.Drawing.Point(617, 2)
        Me.BEditIn.Name = "BEditIn"
        Me.BEditIn.Size = New System.Drawing.Size(81, 37)
        Me.BEditIn.TabIndex = 110
        Me.BEditIn.Text = "Edit"
        '
        'BCompanyIn
        '
        Me.BCompanyIn.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCompanyIn.ImageIndex = 17
        Me.BCompanyIn.ImageList = Me.LargeImageCollection
        Me.BCompanyIn.Location = New System.Drawing.Point(698, 2)
        Me.BCompanyIn.Name = "BCompanyIn"
        Me.BCompanyIn.Size = New System.Drawing.Size(149, 37)
        Me.BCompanyIn.TabIndex = 3
        Me.BCompanyIn.Text = "Master Store / Cargo"
        '
        'FormWHCargoRate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(855, 462)
        Me.Controls.Add(Me.XTCRate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormWHCargoRate"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cargo Rate"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCCompany, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVCompany, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCRate.ResumeLayout(False)
        Me.XTPOutbound.ResumeLayout(False)
        Me.XTPInbound.ResumeLayout(False)
        CType(Me.GCCompanyIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVCompanyIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCCompany As DevExpress.XtraGrid.GridControl
    Friend WithEvents BAddComp As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnEdit As DevExpress.XtraEditors.SimpleButton
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents GVCompany As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents XTCRate As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPOutbound As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPInbound As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCCompanyIn As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVCompanyIn As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BEditIn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BCompanyIn As DevExpress.XtraEditors.SimpleButton
End Class
