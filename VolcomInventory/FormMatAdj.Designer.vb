<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMatAdj
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
        Me.XTCAdj = New DevExpress.XtraTab.XtraTabControl
        Me.XTPAdjIn = New DevExpress.XtraTab.XtraTabPage
        Me.GCAdjIn = New DevExpress.XtraGrid.GridControl
        Me.GVAdjIn = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnIdAdjInSample = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnNumberAdjInSampleNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnAdjInSampleDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCurrencyAdjInSample = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnAmount = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnReportStatus = New DevExpress.XtraGrid.Columns.GridColumn
        Me.XTPAdjOut = New DevExpress.XtraTab.XtraTabPage
        Me.GCAdjOut = New DevExpress.XtraGrid.GridControl
        Me.GVAdjOut = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCAdjSampleOut = New DevExpress.XtraGrid.GridControl
        Me.GVAdjSampleOut = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.XTCAdj, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCAdj.SuspendLayout()
        Me.XTPAdjIn.SuspendLayout()
        CType(Me.GCAdjIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAdjIn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPAdjOut.SuspendLayout()
        CType(Me.GCAdjOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAdjOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCAdjSampleOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAdjSampleOut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCAdj
        '
        Me.XTCAdj.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCAdj.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Right
        Me.XTCAdj.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal
        Me.XTCAdj.Location = New System.Drawing.Point(0, 0)
        Me.XTCAdj.Name = "XTCAdj"
        Me.XTCAdj.SelectedTabPage = Me.XTPAdjIn
        Me.XTCAdj.Size = New System.Drawing.Size(754, 451)
        Me.XTCAdj.TabIndex = 5
        Me.XTCAdj.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPAdjIn, Me.XTPAdjOut})
        '
        'XTPAdjIn
        '
        Me.XTPAdjIn.Controls.Add(Me.GCAdjIn)
        Me.XTPAdjIn.Name = "XTPAdjIn"
        Me.XTPAdjIn.Size = New System.Drawing.Size(660, 445)
        Me.XTPAdjIn.Text = "Adjustment In"
        '
        'GCAdjIn
        '
        Me.GCAdjIn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAdjIn.Location = New System.Drawing.Point(0, 0)
        Me.GCAdjIn.MainView = Me.GVAdjIn
        Me.GCAdjIn.Name = "GCAdjIn"
        Me.GCAdjIn.Size = New System.Drawing.Size(660, 445)
        Me.GCAdjIn.TabIndex = 0
        Me.GCAdjIn.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAdjIn})
        '
        'GVAdjIn
        '
        Me.GVAdjIn.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdAdjInSample, Me.GridColumnNumberAdjInSampleNumber, Me.GridColumnAdjInSampleDate, Me.GridColumnCurrencyAdjInSample, Me.GridColumnAmount, Me.GridColumnReportStatus})
        Me.GVAdjIn.GridControl = Me.GCAdjIn
        Me.GVAdjIn.Name = "GVAdjIn"
        Me.GVAdjIn.OptionsBehavior.Editable = False
        Me.GVAdjIn.OptionsFind.AlwaysVisible = True
        Me.GVAdjIn.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdAdjInSample
        '
        Me.GridColumnIdAdjInSample.Caption = "Id Adj In Sample"
        Me.GridColumnIdAdjInSample.FieldName = "id_adj_in_mat"
        Me.GridColumnIdAdjInSample.Name = "GridColumnIdAdjInSample"
        '
        'GridColumnNumberAdjInSampleNumber
        '
        Me.GridColumnNumberAdjInSampleNumber.Caption = "Number"
        Me.GridColumnNumberAdjInSampleNumber.FieldName = "adj_in_mat_number"
        Me.GridColumnNumberAdjInSampleNumber.Name = "GridColumnNumberAdjInSampleNumber"
        Me.GridColumnNumberAdjInSampleNumber.Visible = True
        Me.GridColumnNumberAdjInSampleNumber.VisibleIndex = 0
        '
        'GridColumnAdjInSampleDate
        '
        Me.GridColumnAdjInSampleDate.Caption = "Created Date"
        Me.GridColumnAdjInSampleDate.FieldName = "adj_in_mat_datex"
        Me.GridColumnAdjInSampleDate.Name = "GridColumnAdjInSampleDate"
        Me.GridColumnAdjInSampleDate.Visible = True
        Me.GridColumnAdjInSampleDate.VisibleIndex = 1
        '
        'GridColumnCurrencyAdjInSample
        '
        Me.GridColumnCurrencyAdjInSample.Caption = "Currency"
        Me.GridColumnCurrencyAdjInSample.FieldName = "currency"
        Me.GridColumnCurrencyAdjInSample.Name = "GridColumnCurrencyAdjInSample"
        Me.GridColumnCurrencyAdjInSample.Visible = True
        Me.GridColumnCurrencyAdjInSample.VisibleIndex = 2
        '
        'GridColumnAmount
        '
        Me.GridColumnAmount.Caption = "Amount"
        Me.GridColumnAmount.DisplayFormat.FormatString = "n2"
        Me.GridColumnAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAmount.FieldName = "adj_in_mat_total"
        Me.GridColumnAmount.Name = "GridColumnAmount"
        Me.GridColumnAmount.Visible = True
        Me.GridColumnAmount.VisibleIndex = 3
        '
        'GridColumnReportStatus
        '
        Me.GridColumnReportStatus.Caption = "Status"
        Me.GridColumnReportStatus.FieldName = "report_status"
        Me.GridColumnReportStatus.Name = "GridColumnReportStatus"
        Me.GridColumnReportStatus.Visible = True
        Me.GridColumnReportStatus.VisibleIndex = 4
        '
        'XTPAdjOut
        '
        Me.XTPAdjOut.Controls.Add(Me.GCAdjOut)
        Me.XTPAdjOut.Controls.Add(Me.GCAdjSampleOut)
        Me.XTPAdjOut.Name = "XTPAdjOut"
        Me.XTPAdjOut.Size = New System.Drawing.Size(660, 445)
        Me.XTPAdjOut.Text = "Adjustment Out"
        '
        'GCAdjOut
        '
        Me.GCAdjOut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAdjOut.Location = New System.Drawing.Point(0, 0)
        Me.GCAdjOut.MainView = Me.GVAdjOut
        Me.GCAdjOut.Name = "GCAdjOut"
        Me.GCAdjOut.Size = New System.Drawing.Size(660, 445)
        Me.GCAdjOut.TabIndex = 2
        Me.GCAdjOut.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAdjOut})
        '
        'GVAdjOut
        '
        Me.GVAdjOut.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12})
        Me.GVAdjOut.GridControl = Me.GCAdjOut
        Me.GVAdjOut.Name = "GVAdjOut"
        Me.GVAdjOut.OptionsBehavior.Editable = False
        Me.GVAdjOut.OptionsFind.AlwaysVisible = True
        Me.GVAdjOut.OptionsView.ShowGroupPanel = False
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Id Adj Out Sample"
        Me.GridColumn7.FieldName = "id_adj_out_mat"
        Me.GridColumn7.Name = "GridColumn7"
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Number"
        Me.GridColumn8.FieldName = "adj_out_mat_number"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 0
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Created Date"
        Me.GridColumn9.FieldName = "adj_out_mat_datex"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 1
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Currency"
        Me.GridColumn10.FieldName = "currency"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 2
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Amount"
        Me.GridColumn11.DisplayFormat.FormatString = "n2"
        Me.GridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn11.FieldName = "adj_out_mat_total"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 3
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Status"
        Me.GridColumn12.FieldName = "report_status"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 4
        '
        'GCAdjSampleOut
        '
        Me.GCAdjSampleOut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAdjSampleOut.Location = New System.Drawing.Point(0, 0)
        Me.GCAdjSampleOut.MainView = Me.GVAdjSampleOut
        Me.GCAdjSampleOut.Name = "GCAdjSampleOut"
        Me.GCAdjSampleOut.Size = New System.Drawing.Size(660, 445)
        Me.GCAdjSampleOut.TabIndex = 1
        Me.GCAdjSampleOut.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAdjSampleOut})
        '
        'GVAdjSampleOut
        '
        Me.GVAdjSampleOut.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6})
        Me.GVAdjSampleOut.GridControl = Me.GCAdjSampleOut
        Me.GVAdjSampleOut.Name = "GVAdjSampleOut"
        Me.GVAdjSampleOut.OptionsBehavior.Editable = False
        Me.GVAdjSampleOut.OptionsFind.AlwaysVisible = True
        Me.GVAdjSampleOut.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id Sample Return"
        Me.GridColumn1.FieldName = "id_sample_return"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Number"
        Me.GridColumn2.FieldName = "sample_return_number"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "From"
        Me.GridColumn3.FieldName = "comp_from"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "To"
        Me.GridColumn4.FieldName = "comp_to"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Created Date"
        Me.GridColumn5.FieldName = "sample_return_date"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Status"
        Me.GridColumn6.FieldName = "report_status"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        '
        'FormMatAdj
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 451)
        Me.Controls.Add(Me.XTCAdj)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMatAdj"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Adjustment Material"
        CType(Me.XTCAdj, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCAdj.ResumeLayout(False)
        Me.XTPAdjIn.ResumeLayout(False)
        CType(Me.GCAdjIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAdjIn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPAdjOut.ResumeLayout(False)
        CType(Me.GCAdjOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAdjOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCAdjSampleOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAdjSampleOut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XTCAdj As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPAdjIn As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCAdjIn As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAdjIn As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdAdjInSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNumberAdjInSampleNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAdjInSampleDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCurrencyAdjInSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPAdjOut As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCAdjOut As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAdjOut As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCAdjSampleOut As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAdjSampleOut As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
End Class
