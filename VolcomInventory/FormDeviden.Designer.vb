<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDeviden
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDeviden))
        Me.XTCExpense = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPDeviden = New DevExpress.XtraTab.XtraTabPage()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedByName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReortStt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.XTPReport = New DevExpress.XtraTab.XtraTabPage()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.BrefreshSNI = New DevExpress.XtraEditors.SimpleButton()
        Me.XTCDevidenReport = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPComparation = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPBBKHistory = New DevExpress.XtraTab.XtraTabPage()
        CType(Me.XTCExpense, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCExpense.SuspendLayout()
        Me.XTPDeviden.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPReport.SuspendLayout()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.XTCDevidenReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCDevidenReport.SuspendLayout()
        Me.SuspendLayout()
        '
        'XTCExpense
        '
        Me.XTCExpense.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCExpense.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCExpense.Location = New System.Drawing.Point(0, 0)
        Me.XTCExpense.Name = "XTCExpense"
        Me.XTCExpense.SelectedTabPage = Me.XTPDeviden
        Me.XTCExpense.Size = New System.Drawing.Size(947, 495)
        Me.XTCExpense.TabIndex = 3
        Me.XTCExpense.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPDeviden, Me.XTPReport})
        '
        'XTPDeviden
        '
        Me.XTPDeviden.Controls.Add(Me.GCData)
        Me.XTPDeviden.Name = "XTPDeviden"
        Me.XTPDeviden.Size = New System.Drawing.Size(941, 467)
        Me.XTPDeviden.Text = "Deviden List"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1})
        Me.GCData.Size = New System.Drawing.Size(941, 467)
        Me.GCData.TabIndex = 0
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnId, Me.GridColumnNumber, Me.GridColumnCreatedDate, Me.GridColumnCreatedByName, Me.GridColumnReortStt, Me.GridColumn2, Me.GridColumn3, Me.GridColumntotal})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnId
        '
        Me.GridColumnId.Caption = "Id"
        Me.GridColumnId.FieldName = "id_deviden"
        Me.GridColumnId.Name = "GridColumnId"
        '
        'GridColumnNumber
        '
        Me.GridColumnNumber.Caption = "Profit Year"
        Me.GridColumnNumber.FieldName = "profit_year"
        Me.GridColumnNumber.Name = "GridColumnNumber"
        Me.GridColumnNumber.Visible = True
        Me.GridColumnNumber.VisibleIndex = 0
        Me.GridColumnNumber.Width = 83
        '
        'GridColumnCreatedDate
        '
        Me.GridColumnCreatedDate.Caption = "Created Date"
        Me.GridColumnCreatedDate.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumnCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnCreatedDate.FieldName = "created_date"
        Me.GridColumnCreatedDate.Name = "GridColumnCreatedDate"
        Me.GridColumnCreatedDate.Visible = True
        Me.GridColumnCreatedDate.VisibleIndex = 4
        Me.GridColumnCreatedDate.Width = 83
        '
        'GridColumnCreatedByName
        '
        Me.GridColumnCreatedByName.Caption = "Created by"
        Me.GridColumnCreatedByName.FieldName = "employee_name"
        Me.GridColumnCreatedByName.Name = "GridColumnCreatedByName"
        Me.GridColumnCreatedByName.Visible = True
        Me.GridColumnCreatedByName.VisibleIndex = 5
        Me.GridColumnCreatedByName.Width = 83
        '
        'GridColumnReortStt
        '
        Me.GridColumnReortStt.Caption = "Approval Status"
        Me.GridColumnReortStt.FieldName = "report_status"
        Me.GridColumnReortStt.Name = "GridColumnReortStt"
        Me.GridColumnReortStt.Visible = True
        Me.GridColumnReortStt.VisibleIndex = 6
        Me.GridColumnReortStt.Width = 83
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn2.Caption = "Total Profit"
        Me.GridColumn2.DisplayFormat.FormatString = "N2"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn2.FieldName = "profit_value"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn3.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn3.Caption = "Deviden (%)"
        Me.GridColumn3.DisplayFormat.FormatString = "{0:N0} %"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn3.FieldName = "profit_percent"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'GridColumntotal
        '
        Me.GridColumntotal.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumntotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumntotal.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumntotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumntotal.Caption = "Deviden Amount"
        Me.GridColumntotal.DisplayFormat.FormatString = "N2"
        Me.GridColumntotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal.FieldName = "deviden_value"
        Me.GridColumntotal.Name = "GridColumntotal"
        Me.GridColumntotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:N2}")})
        Me.GridColumntotal.Visible = True
        Me.GridColumntotal.VisibleIndex = 3
        Me.GridColumntotal.Width = 88
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        Me.RepositoryItemTextEdit1.NullText = "-"
        '
        'XTPReport
        '
        Me.XTPReport.Controls.Add(Me.XTCDevidenReport)
        Me.XTPReport.Controls.Add(Me.PanelControl4)
        Me.XTPReport.Name = "XTPReport"
        Me.XTPReport.Size = New System.Drawing.Size(941, 467)
        Me.XTPReport.Text = "Report"
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.BrefreshSNI)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl4.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(941, 48)
        Me.PanelControl4.TabIndex = 1
        '
        'BrefreshSNI
        '
        Me.BrefreshSNI.Dock = System.Windows.Forms.DockStyle.Right
        Me.BrefreshSNI.Image = CType(resources.GetObject("BrefreshSNI.Image"), System.Drawing.Image)
        Me.BrefreshSNI.Location = New System.Drawing.Point(825, 2)
        Me.BrefreshSNI.Name = "BrefreshSNI"
        Me.BrefreshSNI.Size = New System.Drawing.Size(114, 44)
        Me.BrefreshSNI.TabIndex = 2
        Me.BrefreshSNI.Text = "Refresh"
        '
        'XTCDevidenReport
        '
        Me.XTCDevidenReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCDevidenReport.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCDevidenReport.Location = New System.Drawing.Point(0, 48)
        Me.XTCDevidenReport.Name = "XTCDevidenReport"
        Me.XTCDevidenReport.SelectedTabPage = Me.XTPComparation
        Me.XTCDevidenReport.Size = New System.Drawing.Size(941, 419)
        Me.XTCDevidenReport.TabIndex = 2
        Me.XTCDevidenReport.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPComparation, Me.XTPBBKHistory})
        '
        'XTPComparation
        '
        Me.XTPComparation.Name = "XTPComparation"
        Me.XTPComparation.Size = New System.Drawing.Size(935, 391)
        Me.XTPComparation.Text = "Comparation"
        '
        'XTPBBKHistory
        '
        Me.XTPBBKHistory.Name = "XTPBBKHistory"
        Me.XTPBBKHistory.Size = New System.Drawing.Size(294, 272)
        Me.XTPBBKHistory.Text = "BBK History"
        '
        'FormDeviden
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(947, 495)
        Me.Controls.Add(Me.XTCExpense)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormDeviden"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Deviden"
        CType(Me.XTCExpense, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCExpense.ResumeLayout(False)
        Me.XTPDeviden.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPReport.ResumeLayout(False)
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        CType(Me.XTCDevidenReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCDevidenReport.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XTCExpense As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPDeviden As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedByName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReortStt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents XTPReport As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BrefreshSNI As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTCDevidenReport As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPComparation As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPBBKHistory As DevExpress.XtraTab.XtraTabPage
End Class
