<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProdDemandLineList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProdDemandLineList))
        Me.PanelControlNavLineList = New DevExpress.XtraEditors.PanelControl
        Me.PCNavLineList = New DevExpress.XtraEditors.PanelControl
        Me.SLESeason = New DevExpress.XtraEditors.SearchLookUpEdit
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnIdSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnRange = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl
        Me.PCType = New DevExpress.XtraEditors.PanelControl
        Me.SLETypeLineList = New DevExpress.XtraEditors.SearchLookUpEdit
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PanelControlNavLineListBottom = New DevExpress.XtraEditors.PanelControl
        Me.BtnChoose = New DevExpress.XtraEditors.SimpleButton
        Me.PCSelAll = New DevExpress.XtraEditors.PanelControl
        Me.CheckEditSelAll = New DevExpress.XtraEditors.CheckEdit
        Me.PBCLineList = New DevExpress.XtraEditors.ProgressBarControl
        Me.GCLineList = New DevExpress.XtraGrid.GridControl
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.BGVLineList = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        CType(Me.PanelControlNavLineList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNavLineList.SuspendLayout()
        CType(Me.PCNavLineList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCNavLineList.SuspendLayout()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCType.SuspendLayout()
        CType(Me.SLETypeLineList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlNavLineListBottom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNavLineListBottom.SuspendLayout()
        CType(Me.PCSelAll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCSelAll.SuspendLayout()
        CType(Me.CheckEditSelAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBCLineList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCLineList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BGVLineList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControlNavLineList
        '
        Me.PanelControlNavLineList.Controls.Add(Me.PCNavLineList)
        Me.PanelControlNavLineList.Controls.Add(Me.PCType)
        Me.PanelControlNavLineList.Controls.Add(Me.BtnView)
        Me.PanelControlNavLineList.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlNavLineList.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlNavLineList.Name = "PanelControlNavLineList"
        Me.PanelControlNavLineList.Size = New System.Drawing.Size(800, 39)
        Me.PanelControlNavLineList.TabIndex = 1
        '
        'PCNavLineList
        '
        Me.PCNavLineList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCNavLineList.Controls.Add(Me.SLESeason)
        Me.PCNavLineList.Controls.Add(Me.LabelControl4)
        Me.PCNavLineList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PCNavLineList.Location = New System.Drawing.Point(2, 2)
        Me.PCNavLineList.Name = "PCNavLineList"
        Me.PCNavLineList.Size = New System.Drawing.Size(235, 35)
        Me.PCNavLineList.TabIndex = 105
        '
        'SLESeason
        '
        Me.SLESeason.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SLESeason.Location = New System.Drawing.Point(55, 7)
        Me.SLESeason.Name = "SLESeason"
        Me.SLESeason.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLESeason.Properties.Appearance.Options.UseFont = True
        Me.SLESeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESeason.Properties.View = Me.SearchLookUpEdit1View
        Me.SLESeason.Size = New System.Drawing.Size(168, 20)
        Me.SLESeason.TabIndex = 95
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdSeason, Me.GridColumnRange, Me.GridColumnSeason})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdSeason
        '
        Me.GridColumnIdSeason.Caption = "Id Season"
        Me.GridColumnIdSeason.FieldName = "id_season"
        Me.GridColumnIdSeason.Name = "GridColumnIdSeason"
        '
        'GridColumnRange
        '
        Me.GridColumnRange.Caption = "Range"
        Me.GridColumnRange.FieldName = "range"
        Me.GridColumnRange.Name = "GridColumnRange"
        Me.GridColumnRange.Visible = True
        Me.GridColumnRange.VisibleIndex = 0
        '
        'GridColumnSeason
        '
        Me.GridColumnSeason.Caption = "Season"
        Me.GridColumnSeason.FieldName = "season"
        Me.GridColumnSeason.Name = "GridColumnSeason"
        Me.GridColumnSeason.Visible = True
        Me.GridColumnSeason.VisibleIndex = 1
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(14, 10)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl4.TabIndex = 90
        Me.LabelControl4.Text = "Season"
        '
        'PCType
        '
        Me.PCType.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCType.Controls.Add(Me.SLETypeLineList)
        Me.PCType.Controls.Add(Me.LabelControl1)
        Me.PCType.Dock = System.Windows.Forms.DockStyle.Right
        Me.PCType.Location = New System.Drawing.Point(237, 2)
        Me.PCType.Name = "PCType"
        Me.PCType.Size = New System.Drawing.Size(457, 35)
        Me.PCType.TabIndex = 106
        '
        'SLETypeLineList
        '
        Me.SLETypeLineList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SLETypeLineList.Location = New System.Drawing.Point(35, 7)
        Me.SLETypeLineList.Name = "SLETypeLineList"
        Me.SLETypeLineList.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLETypeLineList.Properties.NullText = ""
        Me.SLETypeLineList.Properties.ShowFooter = False
        Me.SLETypeLineList.Properties.View = Me.GridView4
        Me.SLETypeLineList.Size = New System.Drawing.Size(414, 20)
        Me.SLETypeLineList.TabIndex = 93
        '
        'GridView4
        '
        Me.GridView4.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView4.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id PD TYPE"
        Me.GridColumn1.FieldName = "id_pd_type"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Type"
        Me.GridColumn2.FieldName = "pd_type"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(5, 10)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl1.TabIndex = 92
        Me.LabelControl1.Text = "Type"
        '
        'BtnView
        '
        Me.BtnView.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnView.ImageIndex = 15
        Me.BtnView.ImageList = Me.LargeImageCollection
        Me.BtnView.Location = New System.Drawing.Point(694, 2)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(104, 35)
        Me.BtnView.TabIndex = 94
        Me.BtnView.Text = "View Line List"
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
        '
        'PanelControlNavLineListBottom
        '
        Me.PanelControlNavLineListBottom.Controls.Add(Me.BtnChoose)
        Me.PanelControlNavLineListBottom.Controls.Add(Me.PCSelAll)
        Me.PanelControlNavLineListBottom.Controls.Add(Me.PBCLineList)
        Me.PanelControlNavLineListBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControlNavLineListBottom.Location = New System.Drawing.Point(0, 481)
        Me.PanelControlNavLineListBottom.Name = "PanelControlNavLineListBottom"
        Me.PanelControlNavLineListBottom.Size = New System.Drawing.Size(800, 37)
        Me.PanelControlNavLineListBottom.TabIndex = 3
        '
        'BtnChoose
        '
        Me.BtnChoose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnChoose.Enabled = False
        Me.BtnChoose.ImageIndex = 2
        Me.BtnChoose.ImageList = Me.LargeImageCollection
        Me.BtnChoose.Location = New System.Drawing.Point(704, 2)
        Me.BtnChoose.Name = "BtnChoose"
        Me.BtnChoose.Size = New System.Drawing.Size(94, 33)
        Me.BtnChoose.TabIndex = 106
        Me.BtnChoose.Text = "Choose"
        '
        'PCSelAll
        '
        Me.PCSelAll.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCSelAll.Controls.Add(Me.CheckEditSelAll)
        Me.PCSelAll.Dock = System.Windows.Forms.DockStyle.Left
        Me.PCSelAll.Location = New System.Drawing.Point(321, 2)
        Me.PCSelAll.Name = "PCSelAll"
        Me.PCSelAll.Size = New System.Drawing.Size(99, 33)
        Me.PCSelAll.TabIndex = 103
        '
        'CheckEditSelAll
        '
        Me.CheckEditSelAll.Location = New System.Drawing.Point(5, 7)
        Me.CheckEditSelAll.Name = "CheckEditSelAll"
        Me.CheckEditSelAll.Properties.Caption = "Select All Item"
        Me.CheckEditSelAll.Size = New System.Drawing.Size(92, 19)
        Me.CheckEditSelAll.TabIndex = 102
        '
        'PBCLineList
        '
        Me.PBCLineList.Dock = System.Windows.Forms.DockStyle.Left
        Me.PBCLineList.Location = New System.Drawing.Point(2, 2)
        Me.PBCLineList.Name = "PBCLineList"
        Me.PBCLineList.Properties.ShowTitle = True
        Me.PBCLineList.Size = New System.Drawing.Size(319, 33)
        Me.PBCLineList.TabIndex = 96
        Me.PBCLineList.Visible = False
        '
        'GCLineList
        '
        Me.GCLineList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCLineList.Location = New System.Drawing.Point(0, 39)
        Me.GCLineList.MainView = Me.BGVLineList
        Me.GCLineList.Name = "GCLineList"
        Me.GCLineList.Size = New System.Drawing.Size(800, 442)
        Me.GCLineList.TabIndex = 4
        Me.GCLineList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2, Me.BGVLineList})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GCLineList
        Me.GridView2.Name = "GridView2"
        '
        'BGVLineList
        '
        Me.BGVLineList.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.BGVLineList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.BGVLineList.GridControl = Me.GCLineList
        Me.BGVLineList.Name = "BGVLineList"
        Me.BGVLineList.OptionsPrint.AutoWidth = False
        Me.BGVLineList.OptionsView.ShowFooter = True
        Me.BGVLineList.OptionsView.ShowGroupPanel = False
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "GridBand1"
        Me.GridBand1.MinWidth = 20
        Me.GridBand1.Name = "GridBand1"
        '
        'FormProdDemandLineList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 518)
        Me.Controls.Add(Me.GCLineList)
        Me.Controls.Add(Me.PanelControlNavLineListBottom)
        Me.Controls.Add(Me.PanelControlNavLineList)
        Me.Name = "FormProdDemandLineList"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Line List"
        CType(Me.PanelControlNavLineList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNavLineList.ResumeLayout(False)
        CType(Me.PCNavLineList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCNavLineList.ResumeLayout(False)
        Me.PCNavLineList.PerformLayout()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCType.ResumeLayout(False)
        Me.PCType.PerformLayout()
        CType(Me.SLETypeLineList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlNavLineListBottom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNavLineListBottom.ResumeLayout(False)
        CType(Me.PCSelAll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCSelAll.ResumeLayout(False)
        CType(Me.CheckEditSelAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBCLineList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCLineList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BGVLineList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControlNavLineList As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PCNavLineList As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLESeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRange As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PCType As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLETypeLineList As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents PanelControlNavLineListBottom As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnChoose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PCSelAll As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CheckEditSelAll As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents PBCLineList As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents GCLineList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BGVLineList As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
End Class
