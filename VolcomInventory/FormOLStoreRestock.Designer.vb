<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOLStoreRestock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormOLStoreRestock))
        Me.XTCData = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPOnlineWH = New DevExpress.XtraTab.XtraTabPage()
        Me.GCOnlineWH = New DevExpress.XtraGrid.GridControl()
        Me.GVOnlineWH = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_wh_drawer = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_comp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal_stock = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoSP = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.BCreatePO = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPOtherWH = New DevExpress.XtraTab.XtraTabPage()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtSize = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtDescription = New DevExpress.XtraEditors.TextEdit()
        Me.TxtCode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.GridColumnnote = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCData.SuspendLayout()
        Me.XTPOnlineWH.SuspendLayout()
        CType(Me.GCOnlineWH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVOnlineWH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoSP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TxtSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCData
        '
        Me.XTCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCData.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCData.Location = New System.Drawing.Point(0, 72)
        Me.XTCData.Name = "XTCData"
        Me.XTCData.SelectedTabPage = Me.XTPOnlineWH
        Me.XTCData.Size = New System.Drawing.Size(734, 389)
        Me.XTCData.TabIndex = 0
        Me.XTCData.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPOnlineWH, Me.XTPOtherWH})
        '
        'XTPOnlineWH
        '
        Me.XTPOnlineWH.Controls.Add(Me.GCOnlineWH)
        Me.XTPOnlineWH.Controls.Add(Me.PanelControl2)
        Me.XTPOnlineWH.Controls.Add(Me.BCreatePO)
        Me.XTPOnlineWH.Name = "XTPOnlineWH"
        Me.XTPOnlineWH.Size = New System.Drawing.Size(728, 361)
        Me.XTPOnlineWH.Text = "Online WH"
        '
        'GCOnlineWH
        '
        Me.GCOnlineWH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCOnlineWH.Location = New System.Drawing.Point(0, 44)
        Me.GCOnlineWH.MainView = Me.GVOnlineWH
        Me.GCOnlineWH.Name = "GCOnlineWH"
        Me.GCOnlineWH.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepoSP})
        Me.GCOnlineWH.Size = New System.Drawing.Size(728, 285)
        Me.GCOnlineWH.TabIndex = 0
        Me.GCOnlineWH.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVOnlineWH})
        '
        'GVOnlineWH
        '
        Me.GVOnlineWH.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_wh_drawer, Me.GridColumnid_comp, Me.GridColumncomp_number, Me.GridColumncomp_name, Me.GridColumntotal_stock, Me.GridColumntotal_order, Me.GridColumnnote})
        Me.GVOnlineWH.GridControl = Me.GCOnlineWH
        Me.GVOnlineWH.Name = "GVOnlineWH"
        Me.GVOnlineWH.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVOnlineWH.OptionsFind.AlwaysVisible = True
        Me.GVOnlineWH.OptionsView.ColumnAutoWidth = False
        Me.GVOnlineWH.OptionsView.ShowFooter = True
        Me.GVOnlineWH.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_wh_drawer
        '
        Me.GridColumnid_wh_drawer.Caption = "id_wh_drawer"
        Me.GridColumnid_wh_drawer.FieldName = "id_wh_drawer"
        Me.GridColumnid_wh_drawer.Name = "GridColumnid_wh_drawer"
        Me.GridColumnid_wh_drawer.OptionsColumn.ReadOnly = True
        '
        'GridColumnid_comp
        '
        Me.GridColumnid_comp.Caption = "id_comp"
        Me.GridColumnid_comp.FieldName = "id_comp"
        Me.GridColumnid_comp.Name = "GridColumnid_comp"
        Me.GridColumnid_comp.OptionsColumn.ReadOnly = True
        '
        'GridColumncomp_number
        '
        Me.GridColumncomp_number.Caption = "Account"
        Me.GridColumncomp_number.FieldName = "comp_number"
        Me.GridColumncomp_number.Name = "GridColumncomp_number"
        Me.GridColumncomp_number.OptionsColumn.ReadOnly = True
        Me.GridColumncomp_number.Visible = True
        Me.GridColumncomp_number.VisibleIndex = 0
        '
        'GridColumncomp_name
        '
        Me.GridColumncomp_name.Caption = "Acc. Description"
        Me.GridColumncomp_name.FieldName = "comp_name"
        Me.GridColumncomp_name.Name = "GridColumncomp_name"
        Me.GridColumncomp_name.OptionsColumn.ReadOnly = True
        Me.GridColumncomp_name.Visible = True
        Me.GridColumncomp_name.VisibleIndex = 1
        Me.GridColumncomp_name.Width = 95
        '
        'GridColumntotal_stock
        '
        Me.GridColumntotal_stock.Caption = "Available Qty"
        Me.GridColumntotal_stock.DisplayFormat.FormatString = "N0"
        Me.GridColumntotal_stock.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal_stock.FieldName = "total_stock"
        Me.GridColumntotal_stock.Name = "GridColumntotal_stock"
        Me.GridColumntotal_stock.OptionsColumn.ReadOnly = True
        Me.GridColumntotal_stock.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_stock", "{0:N0}")})
        Me.GridColumntotal_stock.Visible = True
        Me.GridColumntotal_stock.VisibleIndex = 2
        '
        'GridColumntotal_order
        '
        Me.GridColumntotal_order.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumntotal_order.AppearanceCell.Options.UseFont = True
        Me.GridColumntotal_order.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumntotal_order.AppearanceHeader.Options.UseFont = True
        Me.GridColumntotal_order.Caption = "Restock Qty"
        Me.GridColumntotal_order.ColumnEdit = Me.RepoSP
        Me.GridColumntotal_order.DisplayFormat.FormatString = "N0"
        Me.GridColumntotal_order.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal_order.FieldName = "total_order"
        Me.GridColumntotal_order.Name = "GridColumntotal_order"
        Me.GridColumntotal_order.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_order", "{0:N0}")})
        Me.GridColumntotal_order.Visible = True
        Me.GridColumntotal_order.VisibleIndex = 4
        Me.GridColumntotal_order.Width = 106
        '
        'RepoSP
        '
        Me.RepoSP.AutoHeight = False
        Me.RepoSP.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoSP.DisplayFormat.FormatString = "N0"
        Me.RepoSP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepoSP.Mask.EditMask = "N0"
        Me.RepoSP.MaxValue = New Decimal(New Integer() {-1486618625, 232830643, 0, 0})
        Me.RepoSP.Name = "RepoSP"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BtnPrint)
        Me.PanelControl2.Controls.Add(Me.BtnRefresh)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(728, 44)
        Me.PanelControl2.TabIndex = 20
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(543, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(83, 40)
        Me.BtnPrint.TabIndex = 1
        Me.BtnPrint.Text = "Print"
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnRefresh.Image = CType(resources.GetObject("BtnRefresh.Image"), System.Drawing.Image)
        Me.BtnRefresh.Location = New System.Drawing.Point(626, 2)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(100, 40)
        Me.BtnRefresh.TabIndex = 0
        Me.BtnRefresh.Text = "Refresh"
        '
        'BCreatePO
        '
        Me.BCreatePO.Appearance.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BCreatePO.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BCreatePO.Appearance.ForeColor = System.Drawing.Color.White
        Me.BCreatePO.Appearance.Options.UseBackColor = True
        Me.BCreatePO.Appearance.Options.UseFont = True
        Me.BCreatePO.Appearance.Options.UseForeColor = True
        Me.BCreatePO.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BCreatePO.Location = New System.Drawing.Point(0, 329)
        Me.BCreatePO.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BCreatePO.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BCreatePO.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BCreatePO.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BCreatePO.Name = "BCreatePO"
        Me.BCreatePO.Size = New System.Drawing.Size(728, 32)
        Me.BCreatePO.TabIndex = 19
        Me.BCreatePO.Text = "Restock"
        '
        'XTPOtherWH
        '
        Me.XTPOtherWH.Name = "XTPOtherWH"
        Me.XTPOtherWH.Size = New System.Drawing.Size(728, 361)
        Me.XTPOtherWH.Text = "Other WH"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.TxtSize)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.TxtDescription)
        Me.PanelControl1.Controls.Add(Me.TxtCode)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(734, 72)
        Me.PanelControl1.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(446, 12)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(24, 16)
        Me.LabelControl2.TabIndex = 11
        Me.LabelControl2.Text = "Size"
        '
        'TxtSize
        '
        Me.TxtSize.EditValue = ""
        Me.TxtSize.Location = New System.Drawing.Point(446, 34)
        Me.TxtSize.Name = "TxtSize"
        Me.TxtSize.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSize.Properties.Appearance.Options.UseFont = True
        Me.TxtSize.Properties.ReadOnly = True
        Me.TxtSize.Size = New System.Drawing.Size(52, 22)
        Me.TxtSize.TabIndex = 10
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(144, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(63, 16)
        Me.LabelControl1.TabIndex = 9
        Me.LabelControl1.Text = "Description"
        '
        'TxtDescription
        '
        Me.TxtDescription.EditValue = ""
        Me.TxtDescription.Location = New System.Drawing.Point(144, 34)
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescription.Properties.Appearance.Options.UseFont = True
        Me.TxtDescription.Properties.ReadOnly = True
        Me.TxtDescription.Size = New System.Drawing.Size(296, 22)
        Me.TxtDescription.TabIndex = 8
        '
        'TxtCode
        '
        Me.TxtCode.EditValue = ""
        Me.TxtCode.Location = New System.Drawing.Point(12, 34)
        Me.TxtCode.Name = "TxtCode"
        Me.TxtCode.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCode.Properties.Appearance.Options.UseFont = True
        Me.TxtCode.Properties.ReadOnly = True
        Me.TxtCode.Size = New System.Drawing.Size(126, 22)
        Me.TxtCode.TabIndex = 7
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(29, 16)
        Me.LabelControl3.TabIndex = 6
        Me.LabelControl3.Text = "Code"
        '
        'GridColumnnote
        '
        Me.GridColumnnote.Caption = "Note"
        Me.GridColumnnote.FieldName = "note"
        Me.GridColumnnote.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumnnote.Name = "GridColumnnote"
        Me.GridColumnnote.OptionsColumn.ReadOnly = True
        Me.GridColumnnote.Visible = True
        Me.GridColumnnote.VisibleIndex = 0
        '
        'FormOLStoreRestock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 461)
        Me.Controls.Add(Me.XTCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormOLStoreRestock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Restock List"
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCData.ResumeLayout(False)
        Me.XTPOnlineWH.ResumeLayout(False)
        CType(Me.GCOnlineWH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVOnlineWH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoSP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.TxtSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCData As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPOnlineWH As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCOnlineWH As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVOnlineWH As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents XTPOtherWH As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtSize As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtDescription As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BCreatePO As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnid_wh_drawer As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_comp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal_stock As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal_order As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoSP As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnnote As DevExpress.XtraGrid.Columns.GridColumn
End Class
