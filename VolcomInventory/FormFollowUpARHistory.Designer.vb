<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFollowUpARHistory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFollowUpARHistory))
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.SimpleButtonClose = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButtonMark = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButtonPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.GCActive = New DevExpress.XtraGrid.GridControl()
        Me.GVActive = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumn5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.TextEditCreatedDate = New DevExpress.XtraEditors.TextEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextEditFollowUpDate = New DevExpress.XtraEditors.TextEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextEditCreatedBy = New DevExpress.XtraEditors.TextEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextEditReportStatus = New DevExpress.XtraEditors.TextEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GCActive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVActive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TextEditCreatedDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEditFollowUpDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEditCreatedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEditReportStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.SimpleButtonClose)
        Me.PanelControl2.Controls.Add(Me.SimpleButtonMark)
        Me.PanelControl2.Controls.Add(Me.SimpleButtonPrint)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 511)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(784, 50)
        Me.PanelControl2.TabIndex = 2
        '
        'SimpleButtonClose
        '
        Me.SimpleButtonClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButtonClose.Image = CType(resources.GetObject("SimpleButtonClose.Image"), System.Drawing.Image)
        Me.SimpleButtonClose.Location = New System.Drawing.Point(622, 2)
        Me.SimpleButtonClose.Name = "SimpleButtonClose"
        Me.SimpleButtonClose.Size = New System.Drawing.Size(80, 46)
        Me.SimpleButtonClose.TabIndex = 8931
        Me.SimpleButtonClose.Text = "Close"
        '
        'SimpleButtonMark
        '
        Me.SimpleButtonMark.Dock = System.Windows.Forms.DockStyle.Left
        Me.SimpleButtonMark.Image = CType(resources.GetObject("SimpleButtonMark.Image"), System.Drawing.Image)
        Me.SimpleButtonMark.Location = New System.Drawing.Point(2, 2)
        Me.SimpleButtonMark.Name = "SimpleButtonMark"
        Me.SimpleButtonMark.Size = New System.Drawing.Size(80, 46)
        Me.SimpleButtonMark.TabIndex = 8930
        Me.SimpleButtonMark.Text = "Mark"
        '
        'SimpleButtonPrint
        '
        Me.SimpleButtonPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButtonPrint.Image = CType(resources.GetObject("SimpleButtonPrint.Image"), System.Drawing.Image)
        Me.SimpleButtonPrint.Location = New System.Drawing.Point(702, 2)
        Me.SimpleButtonPrint.Name = "SimpleButtonPrint"
        Me.SimpleButtonPrint.Size = New System.Drawing.Size(80, 46)
        Me.SimpleButtonPrint.TabIndex = 8929
        Me.SimpleButtonPrint.Text = "Print"
        '
        'GCActive
        '
        Me.GCActive.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCActive.Location = New System.Drawing.Point(0, 69)
        Me.GCActive.MainView = Me.GVActive
        Me.GCActive.Name = "GCActive"
        Me.GCActive.Size = New System.Drawing.Size(784, 442)
        Me.GCActive.TabIndex = 3
        Me.GCActive.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVActive})
        '
        'GVActive
        '
        Me.GVActive.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1, Me.gridBand2, Me.gridBand3})
        Me.GVActive.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8})
        Me.GVActive.GridControl = Me.GCActive
        Me.GVActive.GroupCount = 1
        Me.GVActive.GroupFormat = ""
        Me.GVActive.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "group", Me.GridColumn2, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "amount", Me.GridColumn3, "", "1")})
        Me.GVActive.Name = "GVActive"
        Me.GVActive.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVActive.OptionsBehavior.ReadOnly = True
        Me.GVActive.OptionsView.AllowCellMerge = True
        Me.GVActive.OptionsView.ColumnAutoWidth = False
        Me.GVActive.OptionsView.ShowGroupPanel = False
        Me.GVActive.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridBand1
        '
        Me.GridBand1.Columns.Add(Me.GridColumn1)
        Me.GridBand1.Columns.Add(Me.GridColumn2)
        Me.GridBand1.Columns.Add(Me.GridColumn3)
        Me.GridBand1.Columns.Add(Me.GridColumn4)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 365
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.Caption = "NO"
        Me.GridColumn1.FieldName = "no"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.Caption = "NAMA TOKO"
        Me.GridColumn2.FieldName = "group"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "TOTAL INVOICE"
        Me.GridColumn3.DisplayFormat.FormatString = "N0"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn3.FieldName = "amount"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.Width = 87
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "TANGGAL JATUH TEMPO"
        Me.GridColumn4.FieldName = "due_date"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.Width = 128
        '
        'gridBand2
        '
        Me.gridBand2.Caption = "FOLLOW UP BY FINANCE"
        Me.gridBand2.Columns.Add(Me.GridColumn5)
        Me.gridBand2.Columns.Add(Me.GridColumn6)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 1
        Me.gridBand2.Width = 151
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "TANGGAL"
        Me.GridColumn5.FieldName = "follow_up_date"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "KETERANGAN"
        Me.GridColumn6.FieldName = "follow_up"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn6.Visible = True
        Me.GridColumn6.Width = 76
        '
        'gridBand3
        '
        Me.gridBand3.Columns.Add(Me.GridColumn7)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 2
        Me.gridBand3.Width = 100
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "HASIL FOLLOW UP"
        Me.GridColumn7.FieldName = "follow_up_result"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn7.Visible = True
        Me.GridColumn7.Width = 100
        '
        'GridColumn8
        '
        Me.GridColumn8.FieldName = "id_comp_group"
        Me.GridColumn8.Name = "GridColumn8"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.TextEditCreatedDate)
        Me.PanelControl1.Controls.Add(Me.Label4)
        Me.PanelControl1.Controls.Add(Me.TextEditFollowUpDate)
        Me.PanelControl1.Controls.Add(Me.Label3)
        Me.PanelControl1.Controls.Add(Me.TextEditCreatedBy)
        Me.PanelControl1.Controls.Add(Me.Label2)
        Me.PanelControl1.Controls.Add(Me.TextEditReportStatus)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 69)
        Me.PanelControl1.TabIndex = 4
        '
        'TextEditCreatedDate
        '
        Me.TextEditCreatedDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextEditCreatedDate.Location = New System.Drawing.Point(622, 38)
        Me.TextEditCreatedDate.Name = "TextEditCreatedDate"
        Me.TextEditCreatedDate.Properties.ReadOnly = True
        Me.TextEditCreatedDate.Size = New System.Drawing.Size(150, 20)
        Me.TextEditCreatedDate.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(537, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Created Date"
        '
        'TextEditFollowUpDate
        '
        Me.TextEditFollowUpDate.Location = New System.Drawing.Point(97, 38)
        Me.TextEditFollowUpDate.Name = "TextEditFollowUpDate"
        Me.TextEditFollowUpDate.Properties.ReadOnly = True
        Me.TextEditFollowUpDate.Size = New System.Drawing.Size(150, 20)
        Me.TextEditFollowUpDate.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Follow Up Date"
        '
        'TextEditCreatedBy
        '
        Me.TextEditCreatedBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextEditCreatedBy.Location = New System.Drawing.Point(622, 12)
        Me.TextEditCreatedBy.Name = "TextEditCreatedBy"
        Me.TextEditCreatedBy.Properties.ReadOnly = True
        Me.TextEditCreatedBy.Size = New System.Drawing.Size(150, 20)
        Me.TextEditCreatedBy.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(537, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Created By"
        '
        'TextEditReportStatus
        '
        Me.TextEditReportStatus.Location = New System.Drawing.Point(97, 12)
        Me.TextEditReportStatus.Name = "TextEditReportStatus"
        Me.TextEditReportStatus.Properties.ReadOnly = True
        Me.TextEditReportStatus.Size = New System.Drawing.Size(150, 20)
        Me.TextEditReportStatus.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Report Status"
        '
        'FormFollowUpARHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GCActive)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PanelControl2)
        Me.MinimizeBox = False
        Me.Name = "FormFollowUpARHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "History Follow Up"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GCActive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVActive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.TextEditCreatedDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEditFollowUpDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEditCreatedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEditReportStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SimpleButtonPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButtonClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButtonMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCActive As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVActive As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TextEditReportStatus As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents TextEditFollowUpDate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents TextEditCreatedBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents TextEditCreatedDate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label4 As Label
End Class
