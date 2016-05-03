<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGDistSchemeStore
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFGDistSchemeStore))
        Me.PanelControlTop = New DevExpress.XtraEditors.PanelControl()
        Me.BtnCopy = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BtnDel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControlBottom = New DevExpress.XtraEditors.PanelControl()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GCAccount = New DevExpress.XtraGrid.GridControl()
        Me.GVAccount = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdDsStore = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCOmp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStoreRate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnArea = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAllocation = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSOCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControlTop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlTop.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlBottom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlBottom.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GCAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControlTop
        '
        Me.PanelControlTop.Controls.Add(Me.BtnPrint)
        Me.PanelControlTop.Controls.Add(Me.BtnCopy)
        Me.PanelControlTop.Controls.Add(Me.BtnDel)
        Me.PanelControlTop.Controls.Add(Me.BtnAdd)
        Me.PanelControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlTop.LookAndFeel.SkinName = "Blue"
        Me.PanelControlTop.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControlTop.Name = "PanelControlTop"
        Me.PanelControlTop.Size = New System.Drawing.Size(743, 41)
        Me.PanelControlTop.TabIndex = 0
        '
        'BtnCopy
        '
        Me.BtnCopy.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnCopy.ImageIndex = 10
        Me.BtnCopy.ImageList = Me.LargeImageCollection
        Me.BtnCopy.Location = New System.Drawing.Point(2, 2)
        Me.BtnCopy.Name = "BtnCopy"
        Me.BtnCopy.Size = New System.Drawing.Size(97, 37)
        Me.BtnCopy.TabIndex = 3
        Me.BtnCopy.Text = "Copy from"
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
        Me.LargeImageCollection.Images.SetKeyName(10, "copy_icon.png")
        '
        'BtnDel
        '
        Me.BtnDel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDel.ImageIndex = 1
        Me.BtnDel.ImageList = Me.LargeImageCollection
        Me.BtnDel.Location = New System.Drawing.Point(559, 2)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(91, 37)
        Me.BtnDel.TabIndex = 1
        Me.BtnDel.Text = "Delete"
        '
        'BtnAdd
        '
        Me.BtnAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAdd.ImageIndex = 0
        Me.BtnAdd.ImageList = Me.LargeImageCollection
        Me.BtnAdd.Location = New System.Drawing.Point(650, 2)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(91, 37)
        Me.BtnAdd.TabIndex = 0
        Me.BtnAdd.Text = "Add"
        '
        'PanelControlBottom
        '
        Me.PanelControlBottom.Controls.Add(Me.BtnSave)
        Me.PanelControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControlBottom.Location = New System.Drawing.Point(0, 437)
        Me.PanelControlBottom.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.PanelControlBottom.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControlBottom.Name = "PanelControlBottom"
        Me.PanelControlBottom.Size = New System.Drawing.Size(743, 38)
        Me.PanelControlBottom.TabIndex = 33
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.ImageIndex = 5
        Me.BtnSave.ImageList = Me.LargeImageCollection
        Me.BtnSave.Location = New System.Drawing.Point(666, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 34)
        Me.BtnSave.TabIndex = 9
        Me.BtnSave.Text = "Close"
        '
        'GroupControl1
        '
        Me.GroupControl1.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl1.AppearanceCaption.Options.UseFont = True
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.GCAccount)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 41)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(743, 396)
        Me.GroupControl1.TabIndex = 34
        Me.GroupControl1.Text = "Account List - Season"
        '
        'GCAccount
        '
        Me.GCAccount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAccount.Location = New System.Drawing.Point(21, 2)
        Me.GCAccount.MainView = Me.GVAccount
        Me.GCAccount.Name = "GCAccount"
        Me.GCAccount.Size = New System.Drawing.Size(720, 392)
        Me.GCAccount.TabIndex = 4
        Me.GCAccount.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAccount})
        '
        'GVAccount
        '
        Me.GVAccount.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdDsStore, Me.GridColumnIdSeason, Me.GridColumnCode, Me.GridColumnCOmp, Me.GridColumnStoreRate, Me.GridColumnArea, Me.GridColumnAllocation, Me.GridColumnIdSOCat})
        Me.GVAccount.GridControl = Me.GCAccount
        Me.GVAccount.Name = "GVAccount"
        Me.GVAccount.OptionsBehavior.ReadOnly = True
        Me.GVAccount.OptionsView.ShowGroupPanel = False
        Me.GVAccount.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnIdSOCat, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnIdDsStore
        '
        Me.GridColumnIdDsStore.Caption = "Id Ds Store"
        Me.GridColumnIdDsStore.FieldName = "id_fg_ds_store"
        Me.GridColumnIdDsStore.Name = "GridColumnIdDsStore"
        Me.GridColumnIdDsStore.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdSeason
        '
        Me.GridColumnIdSeason.Caption = "Id Season"
        Me.GridColumnIdSeason.FieldName = "id_season"
        Me.GridColumnIdSeason.Name = "GridColumnIdSeason"
        Me.GridColumnIdSeason.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "comp_number"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 0
        '
        'GridColumnCOmp
        '
        Me.GridColumnCOmp.Caption = "Store"
        Me.GridColumnCOmp.FieldName = "comp_name"
        Me.GridColumnCOmp.Name = "GridColumnCOmp"
        Me.GridColumnCOmp.Visible = True
        Me.GridColumnCOmp.VisibleIndex = 1
        '
        'GridColumnStoreRate
        '
        Me.GridColumnStoreRate.Caption = "Rate"
        Me.GridColumnStoreRate.FieldName = "store_rate"
        Me.GridColumnStoreRate.Name = "GridColumnStoreRate"
        Me.GridColumnStoreRate.Visible = True
        Me.GridColumnStoreRate.VisibleIndex = 3
        '
        'GridColumnArea
        '
        Me.GridColumnArea.Caption = "Area"
        Me.GridColumnArea.FieldName = "area"
        Me.GridColumnArea.FieldNameSortGroup = "id_area"
        Me.GridColumnArea.Name = "GridColumnArea"
        Me.GridColumnArea.Visible = True
        Me.GridColumnArea.VisibleIndex = 2
        '
        'GridColumnAllocation
        '
        Me.GridColumnAllocation.Caption = "Allocation"
        Me.GridColumnAllocation.FieldName = "pd_alloc"
        Me.GridColumnAllocation.FieldNameSortGroup = "id_pd_alloc"
        Me.GridColumnAllocation.Name = "GridColumnAllocation"
        Me.GridColumnAllocation.Visible = True
        Me.GridColumnAllocation.VisibleIndex = 4
        '
        'GridColumnIdSOCat
        '
        Me.GridColumnIdSOCat.Caption = "id so cat"
        Me.GridColumnIdSOCat.FieldName = "id_so_cat"
        Me.GridColumnIdSOCat.Name = "GridColumnIdSOCat"
        Me.GridColumnIdSOCat.OptionsColumn.ShowInCustomizationForm = False
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.ImageIndex = 6
        Me.BtnPrint.ImageList = Me.LargeImageCollection
        Me.BtnPrint.Location = New System.Drawing.Point(477, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(82, 37)
        Me.BtnPrint.TabIndex = 2
        Me.BtnPrint.Text = "Print"
        '
        'FormFGDistSchemeStore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(743, 475)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.PanelControlBottom)
        Me.Controls.Add(Me.PanelControlTop)
        Me.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MinimizeBox = False
        Me.Name = "FormFGDistSchemeStore"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Distribution Scheme - Account List"
        CType(Me.PanelControlTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlTop.ResumeLayout(False)
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlBottom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlBottom.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GCAccount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAccount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControlTop As DevExpress.XtraEditors.PanelControl
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents PanelControlBottom As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnDel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCAccount As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAccount As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdDsStore As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCOmp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStoreRate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnCopy As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnArea As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAllocation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSOCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
End Class
