<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOutboundCheckFisik
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.TEOutboundNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.XTCScan = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPList = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPScanList = New DevExpress.XtraTab.XtraTabPage()
        Me.GCItemList = New DevExpress.XtraGrid.GridControl()
        Me.GVItemList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCScanList = New DevExpress.XtraGrid.GridControl()
        Me.GVScanList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TETotScan = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TETotQty = New DevExpress.XtraEditors.TextEdit()
        Me.BCheckFisik = New DevExpress.XtraEditors.SimpleButton()
        Me.BReset = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl5 = New DevExpress.XtraEditors.PanelControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.TEOutboundNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.XTCScan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCScan.SuspendLayout()
        Me.XTPList.SuspendLayout()
        Me.XTPScanList.SuspendLayout()
        CType(Me.GCItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCScanList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVScanList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TETotScan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TETotQty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl5.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BCheckFisik)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 556)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(935, 45)
        Me.PanelControl1.TabIndex = 0
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.BReset)
        Me.PanelControl3.Controls.Add(Me.TEOutboundNumber)
        Me.PanelControl3.Controls.Add(Me.LabelControl1)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(935, 46)
        Me.PanelControl3.TabIndex = 2
        '
        'TEOutboundNumber
        '
        Me.TEOutboundNumber.Location = New System.Drawing.Point(150, 9)
        Me.TEOutboundNumber.Name = "TEOutboundNumber"
        Me.TEOutboundNumber.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.TEOutboundNumber.Properties.Appearance.Options.UseFont = True
        Me.TEOutboundNumber.Size = New System.Drawing.Size(334, 28)
        Me.TEOutboundNumber.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.LabelControl1.Location = New System.Drawing.Point(11, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(133, 21)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Outbound Number"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.PanelControl5)
        Me.PanelControl2.Controls.Add(Me.LabelControl2)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 510)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(935, 46)
        Me.PanelControl2.TabIndex = 3
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.LabelControl2.Location = New System.Drawing.Point(11, 11)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(100, 21)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "Qty Total Scan"
        '
        'XTCScan
        '
        Me.XTCScan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCScan.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCScan.Location = New System.Drawing.Point(0, 46)
        Me.XTCScan.Name = "XTCScan"
        Me.XTCScan.SelectedTabPage = Me.XTPList
        Me.XTCScan.Size = New System.Drawing.Size(935, 464)
        Me.XTCScan.TabIndex = 4
        Me.XTCScan.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPList, Me.XTPScanList})
        '
        'XTPList
        '
        Me.XTPList.Controls.Add(Me.GCItemList)
        Me.XTPList.Name = "XTPList"
        Me.XTPList.Size = New System.Drawing.Size(929, 436)
        Me.XTPList.Text = "List All"
        '
        'XTPScanList
        '
        Me.XTPScanList.Controls.Add(Me.GCScanList)
        Me.XTPScanList.Controls.Add(Me.PanelControl4)
        Me.XTPScanList.Name = "XTPScanList"
        Me.XTPScanList.Size = New System.Drawing.Size(929, 436)
        Me.XTPScanList.Text = "Scan List"
        '
        'GCItemList
        '
        Me.GCItemList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCItemList.Location = New System.Drawing.Point(0, 0)
        Me.GCItemList.MainView = Me.GVItemList
        Me.GCItemList.Name = "GCItemList"
        Me.GCItemList.Size = New System.Drawing.Size(929, 436)
        Me.GCItemList.TabIndex = 0
        Me.GCItemList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVItemList})
        '
        'GVItemList
        '
        Me.GVItemList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn1, Me.GridColumn2, Me.GridColumn7, Me.GridColumn4})
        Me.GVItemList.GridControl = Me.GCItemList
        Me.GVItemList.Name = "GVItemList"
        Me.GVItemList.OptionsView.ShowFooter = True
        Me.GVItemList.OptionsView.ShowGroupPanel = False
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.TextEdit1)
        Me.PanelControl4.Controls.Add(Me.LabelControl3)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl4.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(929, 46)
        Me.PanelControl4.TabIndex = 3
        '
        'TextEdit1
        '
        Me.TextEdit1.Location = New System.Drawing.Point(50, 9)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.TextEdit1.Properties.Appearance.Options.UseFont = True
        Me.TextEdit1.Size = New System.Drawing.Size(433, 28)
        Me.TextEdit1.TabIndex = 1
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.LabelControl3.Location = New System.Drawing.Point(11, 12)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(33, 21)
        Me.LabelControl3.TabIndex = 0
        Me.LabelControl3.Text = "Scan"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Code"
        Me.GridColumn1.FieldName = "full_code"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 1114
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn2.Caption = "Qty"
        Me.GridColumn2.DisplayFormat.FormatString = "N0"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn2.FieldName = "qty"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N0}")})
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 182
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "ID"
        Me.GridColumn3.FieldName = "id_product"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn4.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn4.Caption = "Status"
        Me.GridColumn4.FieldName = "status"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.UnboundExpression = "Iif([qty] - [qty_scan] > 0, 'Missing', Iif([qty] - [qty_scan] < 0, 'Over', 'Balan" &
    "ce'))"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        Me.GridColumn4.Width = 189
        '
        'GCScanList
        '
        Me.GCScanList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCScanList.Location = New System.Drawing.Point(0, 46)
        Me.GCScanList.MainView = Me.GVScanList
        Me.GCScanList.Name = "GCScanList"
        Me.GCScanList.Size = New System.Drawing.Size(929, 390)
        Me.GCScanList.TabIndex = 4
        Me.GCScanList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVScanList})
        '
        'GVScanList
        '
        Me.GVScanList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn5, Me.GridColumn6})
        Me.GVScanList.GridControl = Me.GCScanList
        Me.GVScanList.Name = "GVScanList"
        Me.GVScanList.OptionsView.ShowGroupPanel = False
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "ID"
        Me.GridColumn5.Name = "GridColumn5"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Code"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 0
        Me.GridColumn6.Width = 1092
        '
        'TETotScan
        '
        Me.TETotScan.Location = New System.Drawing.Point(12, 6)
        Me.TETotScan.Name = "TETotScan"
        Me.TETotScan.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.TETotScan.Properties.Appearance.Options.UseFont = True
        Me.TETotScan.Size = New System.Drawing.Size(124, 28)
        Me.TETotScan.TabIndex = 2
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.LabelControl4.Location = New System.Drawing.Point(142, 9)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(7, 21)
        Me.LabelControl4.TabIndex = 3
        Me.LabelControl4.Text = "/"
        '
        'TETotQty
        '
        Me.TETotQty.Location = New System.Drawing.Point(155, 6)
        Me.TETotQty.Name = "TETotQty"
        Me.TETotQty.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.TETotQty.Properties.Appearance.Options.UseFont = True
        Me.TETotQty.Size = New System.Drawing.Size(124, 28)
        Me.TETotQty.TabIndex = 4
        '
        'BCheckFisik
        '
        Me.BCheckFisik.Appearance.BackColor = System.Drawing.Color.Blue
        Me.BCheckFisik.Appearance.BackColor2 = System.Drawing.Color.Blue
        Me.BCheckFisik.Appearance.ForeColor = System.Drawing.Color.White
        Me.BCheckFisik.Appearance.Options.UseBackColor = True
        Me.BCheckFisik.Appearance.Options.UseForeColor = True
        Me.BCheckFisik.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.BCheckFisik.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BCheckFisik.Location = New System.Drawing.Point(2, 2)
        Me.BCheckFisik.Name = "BCheckFisik"
        Me.BCheckFisik.Size = New System.Drawing.Size(931, 41)
        Me.BCheckFisik.TabIndex = 4
        Me.BCheckFisik.Text = "Complete"
        '
        'BReset
        '
        Me.BReset.Location = New System.Drawing.Point(490, 11)
        Me.BReset.Name = "BReset"
        Me.BReset.Size = New System.Drawing.Size(75, 23)
        Me.BReset.TabIndex = 2
        Me.BReset.Text = "Reset"
        Me.BReset.Visible = False
        '
        'GridColumn7
        '
        Me.GridColumn7.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn7.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn7.Caption = "Qty Scan"
        Me.GridColumn7.DisplayFormat.FormatString = "N0"
        Me.GridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn7.FieldName = "qty_scan"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_scan", "{0:N0}")})
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 2
        Me.GridColumn7.Width = 131
        '
        'PanelControl5
        '
        Me.PanelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl5.Controls.Add(Me.TETotScan)
        Me.PanelControl5.Controls.Add(Me.TETotQty)
        Me.PanelControl5.Controls.Add(Me.LabelControl4)
        Me.PanelControl5.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl5.Location = New System.Drawing.Point(646, 2)
        Me.PanelControl5.Name = "PanelControl5"
        Me.PanelControl5.Size = New System.Drawing.Size(287, 42)
        Me.PanelControl5.TabIndex = 5
        '
        'FormOutboundCheckFisik
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(935, 601)
        Me.Controls.Add(Me.XTCScan)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormOutboundCheckFisik"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Check Fisik"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.TEOutboundNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.XTCScan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCScan.ResumeLayout(False)
        Me.XTPList.ResumeLayout(False)
        Me.XTPScanList.ResumeLayout(False)
        CType(Me.GCItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        Me.PanelControl4.PerformLayout()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCScanList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVScanList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TETotScan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TETotQty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl5.ResumeLayout(False)
        Me.PanelControl5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TEOutboundNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents XTCScan As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPScanList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCItemList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVItemList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCScanList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVScanList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TETotQty As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TETotScan As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BCheckFisik As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BReset As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl5 As DevExpress.XtraEditors.PanelControl
End Class
