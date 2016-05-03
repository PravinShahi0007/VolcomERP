<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesTarget
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
        Me.XTCSalesTarget = New DevExpress.XtraTab.XtraTabControl
        Me.XTPSalesTargetList = New DevExpress.XtraTab.XtraTabPage
        Me.GCSalesTarget = New DevExpress.XtraGrid.GridControl
        Me.GVSalesTarget = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnSalesTargetNumb = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnTo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSalesTargetDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDSalesTargetNote = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnReportStatus = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage
        CType(Me.XTCSalesTarget, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCSalesTarget.SuspendLayout()
        Me.XTPSalesTargetList.SuspendLayout()
        CType(Me.GCSalesTarget, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSalesTarget, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCSalesTarget
        '
        Me.XTCSalesTarget.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.XTCSalesTarget.BorderStylePage = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.XTCSalesTarget.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCSalesTarget.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCSalesTarget.Location = New System.Drawing.Point(0, 0)
        Me.XTCSalesTarget.Name = "XTCSalesTarget"
        Me.XTCSalesTarget.SelectedTabPage = Me.XTPSalesTargetList
        Me.XTCSalesTarget.ShowTabHeader = DevExpress.Utils.DefaultBoolean.[False]
        Me.XTCSalesTarget.Size = New System.Drawing.Size(731, 467)
        Me.XTCSalesTarget.TabIndex = 0
        Me.XTCSalesTarget.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPSalesTargetList, Me.XtraTabPage2})
        '
        'XTPSalesTargetList
        '
        Me.XTPSalesTargetList.Controls.Add(Me.GCSalesTarget)
        Me.XTPSalesTargetList.Name = "XTPSalesTargetList"
        Me.XTPSalesTargetList.Size = New System.Drawing.Size(725, 461)
        Me.XTPSalesTargetList.Text = "Sales Target"
        '
        'GCSalesTarget
        '
        Me.GCSalesTarget.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSalesTarget.Location = New System.Drawing.Point(0, 0)
        Me.GCSalesTarget.MainView = Me.GVSalesTarget
        Me.GCSalesTarget.Name = "GCSalesTarget"
        Me.GCSalesTarget.Size = New System.Drawing.Size(725, 461)
        Me.GCSalesTarget.TabIndex = 0
        Me.GCSalesTarget.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSalesTarget, Me.GridView2})
        '
        'GVSalesTarget
        '
        Me.GVSalesTarget.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnSalesTargetNumb, Me.GridColumnTo, Me.GridColumnSalesTargetDate, Me.GridColumnDSalesTargetNote, Me.GridColumnReportStatus, Me.GridColumnSeason})
        Me.GVSalesTarget.GridControl = Me.GCSalesTarget
        Me.GVSalesTarget.GroupCount = 1
        Me.GVSalesTarget.Name = "GVSalesTarget"
        Me.GVSalesTarget.OptionsView.ShowGroupPanel = False
        Me.GVSalesTarget.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnSeason, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnSalesTargetNumb
        '
        Me.GridColumnSalesTargetNumb.Caption = "Number"
        Me.GridColumnSalesTargetNumb.FieldName = "sales_target_number"
        Me.GridColumnSalesTargetNumb.Name = "GridColumnSalesTargetNumb"
        Me.GridColumnSalesTargetNumb.Visible = True
        Me.GridColumnSalesTargetNumb.VisibleIndex = 0
        '
        'GridColumnTo
        '
        Me.GridColumnTo.Caption = "To"
        Me.GridColumnTo.FieldName = "comp_name_to"
        Me.GridColumnTo.Name = "GridColumnTo"
        Me.GridColumnTo.Visible = True
        Me.GridColumnTo.VisibleIndex = 1
        '
        'GridColumnSalesTargetDate
        '
        Me.GridColumnSalesTargetDate.Caption = "Created Date"
        Me.GridColumnSalesTargetDate.FieldName = "sales_target_date"
        Me.GridColumnSalesTargetDate.Name = "GridColumnSalesTargetDate"
        Me.GridColumnSalesTargetDate.Visible = True
        Me.GridColumnSalesTargetDate.VisibleIndex = 2
        '
        'GridColumnDSalesTargetNote
        '
        Me.GridColumnDSalesTargetNote.Caption = "Note"
        Me.GridColumnDSalesTargetNote.FieldName = "sales_target_note"
        Me.GridColumnDSalesTargetNote.Name = "GridColumnDSalesTargetNote"
        Me.GridColumnDSalesTargetNote.Visible = True
        Me.GridColumnDSalesTargetNote.VisibleIndex = 3
        '
        'GridColumnReportStatus
        '
        Me.GridColumnReportStatus.Caption = "Status"
        Me.GridColumnReportStatus.FieldName = "report_status"
        Me.GridColumnReportStatus.Name = "GridColumnReportStatus"
        Me.GridColumnReportStatus.Visible = True
        Me.GridColumnReportStatus.VisibleIndex = 4
        '
        'GridColumnSeason
        '
        Me.GridColumnSeason.Caption = "Season"
        Me.GridColumnSeason.FieldName = "season"
        Me.GridColumnSeason.FieldNameSortGroup = "id_season"
        Me.GridColumnSeason.Name = "GridColumnSeason"
        Me.GridColumnSeason.Visible = True
        Me.GridColumnSeason.VisibleIndex = 5
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GCSalesTarget
        Me.GridView2.Name = "GridView2"
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.PageVisible = False
        Me.XtraTabPage2.Size = New System.Drawing.Size(725, 441)
        Me.XtraTabPage2.Text = "XtraTabPage2"
        '
        'FormSalesTarget
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(731, 467)
        Me.Controls.Add(Me.XTCSalesTarget)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSalesTarget"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales Target"
        CType(Me.XTCSalesTarget, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCSalesTarget.ResumeLayout(False)
        Me.XTPSalesTargetList.ResumeLayout(False)
        CType(Me.GCSalesTarget, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSalesTarget, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XTCSalesTarget As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPSalesTargetList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCSalesTarget As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSalesTarget As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnSalesTargetNumb As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSalesTargetDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDSalesTargetNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Columns.GridColumn
End Class
