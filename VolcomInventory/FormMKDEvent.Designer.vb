<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMKDEvent
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
        Me.XTCEvent = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPList = New DevExpress.XtraTab.XtraTabPage()
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.GVList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_pp_change = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoLinkNo = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.GridColumnstart_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnend_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncount_day = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControlList = New DevExpress.XtraEditors.PanelControl()
        Me.BtnPrintList = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnViewList = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEOption = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPDetail = New DevExpress.XtraTab.XtraTabPage()
        Me.GCDetail = New DevExpress.XtraGrid.GridControl()
        Me.GVDetail = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemHyperLinkEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.PanelControlDetail = New DevExpress.XtraEditors.PanelControl()
        Me.BtnPrintMKD = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnViewMKD = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEMKD = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.GridColumnkode_lengkap = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnkode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnclass = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndeskripsi = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnwarna = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndeskripsi_warna = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnharga_normal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndisc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnharga_update = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnket = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCEvent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCEvent.SuspendLayout()
        Me.XTPList.SuspendLayout()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoLinkNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlList.SuspendLayout()
        CType(Me.SLEOption.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPDetail.SuspendLayout()
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlDetail.SuspendLayout()
        CType(Me.SLEMKD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCEvent
        '
        Me.XTCEvent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCEvent.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCEvent.Location = New System.Drawing.Point(0, 0)
        Me.XTCEvent.Name = "XTCEvent"
        Me.XTCEvent.SelectedTabPage = Me.XTPList
        Me.XTCEvent.Size = New System.Drawing.Size(651, 419)
        Me.XTCEvent.TabIndex = 0
        Me.XTCEvent.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPList, Me.XTPDetail})
        '
        'XTPList
        '
        Me.XTPList.Controls.Add(Me.GCList)
        Me.XTPList.Controls.Add(Me.PanelControlList)
        Me.XTPList.Name = "XTPList"
        Me.XTPList.Size = New System.Drawing.Size(645, 391)
        Me.XTPList.Text = "EOS List"
        '
        'GCList
        '
        Me.GCList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCList.Location = New System.Drawing.Point(0, 54)
        Me.GCList.MainView = Me.GVList
        Me.GCList.Name = "GCList"
        Me.GCList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepoLinkNo})
        Me.GCList.Size = New System.Drawing.Size(645, 337)
        Me.GCList.TabIndex = 1
        Me.GCList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVList})
        '
        'GVList
        '
        Me.GVList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_pp_change, Me.GridColumnnumber, Me.GridColumnstart_date, Me.GridColumnend_date, Me.GridColumnnote, Me.GridColumncount_day})
        Me.GVList.GridControl = Me.GCList
        Me.GVList.Name = "GVList"
        Me.GVList.OptionsBehavior.ReadOnly = True
        Me.GVList.OptionsFind.AlwaysVisible = True
        Me.GVList.OptionsView.ColumnAutoWidth = False
        Me.GVList.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_pp_change
        '
        Me.GridColumnid_pp_change.Caption = "id_pp_change"
        Me.GridColumnid_pp_change.FieldName = "id_pp_change"
        Me.GridColumnid_pp_change.Name = "GridColumnid_pp_change"
        '
        'GridColumnnumber
        '
        Me.GridColumnnumber.Caption = "Number"
        Me.GridColumnnumber.ColumnEdit = Me.RepoLinkNo
        Me.GridColumnnumber.FieldName = "number"
        Me.GridColumnnumber.Name = "GridColumnnumber"
        Me.GridColumnnumber.Visible = True
        Me.GridColumnnumber.VisibleIndex = 0
        '
        'RepoLinkNo
        '
        Me.RepoLinkNo.AutoHeight = False
        Me.RepoLinkNo.Name = "RepoLinkNo"
        '
        'GridColumnstart_date
        '
        Me.GridColumnstart_date.Caption = "Start Date"
        Me.GridColumnstart_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnstart_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnstart_date.FieldName = "start_date"
        Me.GridColumnstart_date.Name = "GridColumnstart_date"
        Me.GridColumnstart_date.Visible = True
        Me.GridColumnstart_date.VisibleIndex = 1
        '
        'GridColumnend_date
        '
        Me.GridColumnend_date.Caption = "End Date"
        Me.GridColumnend_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnend_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnend_date.FieldName = "end_date"
        Me.GridColumnend_date.Name = "GridColumnend_date"
        Me.GridColumnend_date.Visible = True
        Me.GridColumnend_date.VisibleIndex = 2
        '
        'GridColumnnote
        '
        Me.GridColumnnote.Caption = "Note"
        Me.GridColumnnote.FieldName = "note"
        Me.GridColumnnote.Name = "GridColumnnote"
        Me.GridColumnnote.Visible = True
        Me.GridColumnnote.VisibleIndex = 3
        '
        'GridColumncount_day
        '
        Me.GridColumncount_day.Caption = "count_day"
        Me.GridColumncount_day.FieldName = "count_day"
        Me.GridColumncount_day.Name = "GridColumncount_day"
        '
        'PanelControlList
        '
        Me.PanelControlList.Controls.Add(Me.BtnPrintList)
        Me.PanelControlList.Controls.Add(Me.BtnViewList)
        Me.PanelControlList.Controls.Add(Me.LabelControl2)
        Me.PanelControlList.Controls.Add(Me.SLEOption)
        Me.PanelControlList.Controls.Add(Me.LabelControl1)
        Me.PanelControlList.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlList.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlList.Name = "PanelControlList"
        Me.PanelControlList.Size = New System.Drawing.Size(645, 54)
        Me.PanelControlList.TabIndex = 0
        '
        'BtnPrintList
        '
        Me.BtnPrintList.Location = New System.Drawing.Point(304, 16)
        Me.BtnPrintList.Name = "BtnPrintList"
        Me.BtnPrintList.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrintList.TabIndex = 3
        Me.BtnPrintList.Text = "Print List"
        '
        'BtnViewList
        '
        Me.BtnViewList.Location = New System.Drawing.Point(223, 16)
        Me.BtnViewList.Name = "BtnViewList"
        Me.BtnViewList.Size = New System.Drawing.Size(75, 23)
        Me.BtnViewList.TabIndex = 1
        Me.BtnViewList.Text = "View Data"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(306, 21)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(0, 13)
        Me.LabelControl2.TabIndex = 2
        '
        'SLEOption
        '
        Me.SLEOption.Location = New System.Drawing.Point(54, 18)
        Me.SLEOption.Name = "SLEOption"
        Me.SLEOption.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEOption.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEOption.Size = New System.Drawing.Size(164, 20)
        Me.SLEOption.TabIndex = 1
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(16, 21)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(32, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Option"
        '
        'XTPDetail
        '
        Me.XTPDetail.Controls.Add(Me.GCDetail)
        Me.XTPDetail.Controls.Add(Me.PanelControlDetail)
        Me.XTPDetail.Name = "XTPDetail"
        Me.XTPDetail.Size = New System.Drawing.Size(645, 391)
        Me.XTPDetail.Text = "EOS Detail"
        '
        'GCDetail
        '
        Me.GCDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDetail.Location = New System.Drawing.Point(0, 54)
        Me.GCDetail.MainView = Me.GVDetail
        Me.GCDetail.Name = "GCDetail"
        Me.GCDetail.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemHyperLinkEdit1})
        Me.GCDetail.Size = New System.Drawing.Size(645, 337)
        Me.GCDetail.TabIndex = 2
        Me.GCDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDetail})
        '
        'GVDetail
        '
        Me.GVDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnkode_lengkap, Me.GridColumnkode, Me.GridColumnsize, Me.GridColumnclass, Me.GridColumndeskripsi, Me.GridColumnwarna, Me.GridColumndeskripsi_warna, Me.GridColumnharga_normal, Me.GridColumndisc, Me.GridColumnharga_update, Me.GridColumnket})
        Me.GVDetail.GridControl = Me.GCDetail
        Me.GVDetail.Name = "GVDetail"
        Me.GVDetail.OptionsBehavior.ReadOnly = True
        Me.GVDetail.OptionsFind.AlwaysVisible = True
        Me.GVDetail.OptionsView.ColumnAutoWidth = False
        Me.GVDetail.OptionsView.ShowGroupPanel = False
        '
        'RepositoryItemHyperLinkEdit1
        '
        Me.RepositoryItemHyperLinkEdit1.AutoHeight = False
        Me.RepositoryItemHyperLinkEdit1.Name = "RepositoryItemHyperLinkEdit1"
        '
        'PanelControlDetail
        '
        Me.PanelControlDetail.Controls.Add(Me.BtnPrintMKD)
        Me.PanelControlDetail.Controls.Add(Me.BtnViewMKD)
        Me.PanelControlDetail.Controls.Add(Me.SLEMKD)
        Me.PanelControlDetail.Controls.Add(Me.LabelControl3)
        Me.PanelControlDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlDetail.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlDetail.Name = "PanelControlDetail"
        Me.PanelControlDetail.Size = New System.Drawing.Size(645, 54)
        Me.PanelControlDetail.TabIndex = 0
        '
        'BtnPrintMKD
        '
        Me.BtnPrintMKD.Location = New System.Drawing.Point(331, 15)
        Me.BtnPrintMKD.Name = "BtnPrintMKD"
        Me.BtnPrintMKD.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrintMKD.TabIndex = 5
        Me.BtnPrintMKD.Text = "Print List"
        '
        'BtnViewMKD
        '
        Me.BtnViewMKD.Location = New System.Drawing.Point(250, 15)
        Me.BtnViewMKD.Name = "BtnViewMKD"
        Me.BtnViewMKD.Size = New System.Drawing.Size(75, 23)
        Me.BtnViewMKD.TabIndex = 4
        Me.BtnViewMKD.Text = "View Data"
        '
        'SLEMKD
        '
        Me.SLEMKD.Location = New System.Drawing.Point(81, 17)
        Me.SLEMKD.Name = "SLEMKD"
        Me.SLEMKD.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEMKD.Properties.View = Me.GridView1
        Me.SLEMKD.Size = New System.Drawing.Size(164, 20)
        Me.SLEMKD.TabIndex = 2
        '
        'GridView1
        '
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(14, 20)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl3.TabIndex = 0
        Me.LabelControl3.Text = "Proposal No."
        '
        'GridColumnkode_lengkap
        '
        Me.GridColumnkode_lengkap.Caption = "Kode Lengkap"
        Me.GridColumnkode_lengkap.FieldName = "kode_lengkap"
        Me.GridColumnkode_lengkap.Name = "GridColumnkode_lengkap"
        Me.GridColumnkode_lengkap.Visible = True
        Me.GridColumnkode_lengkap.VisibleIndex = 0
        '
        'GridColumnkode
        '
        Me.GridColumnkode.Caption = "Kode"
        Me.GridColumnkode.FieldName = "kode"
        Me.GridColumnkode.Name = "GridColumnkode"
        Me.GridColumnkode.Visible = True
        Me.GridColumnkode.VisibleIndex = 1
        '
        'GridColumnsize
        '
        Me.GridColumnsize.Caption = "Size"
        Me.GridColumnsize.FieldName = "size"
        Me.GridColumnsize.Name = "GridColumnsize"
        Me.GridColumnsize.Visible = True
        Me.GridColumnsize.VisibleIndex = 2
        '
        'GridColumnclass
        '
        Me.GridColumnclass.Caption = "Class"
        Me.GridColumnclass.FieldName = "class"
        Me.GridColumnclass.Name = "GridColumnclass"
        Me.GridColumnclass.Visible = True
        Me.GridColumnclass.VisibleIndex = 3
        '
        'GridColumndeskripsi
        '
        Me.GridColumndeskripsi.Caption = "Deskripsi"
        Me.GridColumndeskripsi.FieldName = "deskripsi"
        Me.GridColumndeskripsi.Name = "GridColumndeskripsi"
        Me.GridColumndeskripsi.Visible = True
        Me.GridColumndeskripsi.VisibleIndex = 4
        '
        'GridColumnwarna
        '
        Me.GridColumnwarna.Caption = "Warna"
        Me.GridColumnwarna.FieldName = "warna"
        Me.GridColumnwarna.Name = "GridColumnwarna"
        Me.GridColumnwarna.Visible = True
        Me.GridColumnwarna.VisibleIndex = 5
        '
        'GridColumndeskripsi_warna
        '
        Me.GridColumndeskripsi_warna.Caption = "Deskripsi Warna"
        Me.GridColumndeskripsi_warna.FieldName = "deskripsi_warna"
        Me.GridColumndeskripsi_warna.Name = "GridColumndeskripsi_warna"
        Me.GridColumndeskripsi_warna.Visible = True
        Me.GridColumndeskripsi_warna.VisibleIndex = 6
        '
        'GridColumnharga_normal
        '
        Me.GridColumnharga_normal.Caption = "Harga Normal"
        Me.GridColumnharga_normal.DisplayFormat.FormatString = "N0"
        Me.GridColumnharga_normal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnharga_normal.FieldName = "harga_normal"
        Me.GridColumnharga_normal.Name = "GridColumnharga_normal"
        Me.GridColumnharga_normal.Visible = True
        Me.GridColumnharga_normal.VisibleIndex = 7
        '
        'GridColumndisc
        '
        Me.GridColumndisc.Caption = "Disc"
        Me.GridColumndisc.FieldName = "disc"
        Me.GridColumndisc.Name = "GridColumndisc"
        Me.GridColumndisc.Visible = True
        Me.GridColumndisc.VisibleIndex = 8
        '
        'GridColumnharga_update
        '
        Me.GridColumnharga_update.Caption = "Harga Update"
        Me.GridColumnharga_update.DisplayFormat.FormatString = "N0"
        Me.GridColumnharga_update.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnharga_update.FieldName = "harga_update"
        Me.GridColumnharga_update.Name = "GridColumnharga_update"
        Me.GridColumnharga_update.Visible = True
        Me.GridColumnharga_update.VisibleIndex = 9
        '
        'GridColumnket
        '
        Me.GridColumnket.Caption = "Ket"
        Me.GridColumnket.FieldName = "ket"
        Me.GridColumnket.Name = "GridColumnket"
        Me.GridColumnket.Visible = True
        Me.GridColumnket.VisibleIndex = 10
        '
        'FormMKDEvent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(651, 419)
        Me.Controls.Add(Me.XTCEvent)
        Me.Name = "FormMKDEvent"
        Me.Text = "End Of Season Sale"
        CType(Me.XTCEvent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCEvent.ResumeLayout(False)
        Me.XTPList.ResumeLayout(False)
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoLinkNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlList.ResumeLayout(False)
        Me.PanelControlList.PerformLayout()
        CType(Me.SLEOption.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPDetail.ResumeLayout(False)
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlDetail.ResumeLayout(False)
        Me.PanelControlDetail.PerformLayout()
        CType(Me.SLEMKD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCEvent As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPDetail As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControlList As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnViewList As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEOption As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_pp_change As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoLinkNo As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents GridColumnstart_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnend_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncount_day As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnPrintList As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemHyperLinkEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents PanelControlDetail As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLEMKD As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnPrintMKD As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnViewMKD As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnkode_lengkap As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnkode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnclass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndeskripsi As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnwarna As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndeskripsi_warna As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnharga_normal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndisc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnharga_update As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnket As DevExpress.XtraGrid.Columns.GridColumn
End Class
