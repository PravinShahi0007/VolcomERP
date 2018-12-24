<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormItemExpense
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
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedByName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReortStt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPaidStt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdComp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBeneficiary = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1})
        Me.GCData.Size = New System.Drawing.Size(783, 553)
        Me.GCData.TabIndex = 0
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnId, Me.GridColumnNumber, Me.GridColumnCreatedDate, Me.GridColumnCreatedByName, Me.GridColumnReortStt, Me.GridColumnPaidStt, Me.GridColumnBal, Me.GridColumntotal, Me.GridColumnIdComp, Me.GridColumnBeneficiary})
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
        Me.GridColumnId.FieldName = "id_item_expense"
        Me.GridColumnId.Name = "GridColumnId"
        '
        'GridColumnNumber
        '
        Me.GridColumnNumber.Caption = "Number"
        Me.GridColumnNumber.FieldName = "number"
        Me.GridColumnNumber.Name = "GridColumnNumber"
        Me.GridColumnNumber.Visible = True
        Me.GridColumnNumber.VisibleIndex = 0
        '
        'GridColumnCreatedDate
        '
        Me.GridColumnCreatedDate.Caption = "Created Date"
        Me.GridColumnCreatedDate.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumnCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnCreatedDate.FieldName = "created_date"
        Me.GridColumnCreatedDate.Name = "GridColumnCreatedDate"
        Me.GridColumnCreatedDate.Visible = True
        Me.GridColumnCreatedDate.VisibleIndex = 2
        '
        'GridColumnCreatedByName
        '
        Me.GridColumnCreatedByName.Caption = "Created by"
        Me.GridColumnCreatedByName.FieldName = "created_by_name"
        Me.GridColumnCreatedByName.Name = "GridColumnCreatedByName"
        Me.GridColumnCreatedByName.Visible = True
        Me.GridColumnCreatedByName.VisibleIndex = 3
        '
        'GridColumnReortStt
        '
        Me.GridColumnReortStt.Caption = "Transaction Status"
        Me.GridColumnReortStt.FieldName = "report_status"
        Me.GridColumnReortStt.Name = "GridColumnReortStt"
        Me.GridColumnReortStt.Visible = True
        Me.GridColumnReortStt.VisibleIndex = 4
        '
        'GridColumnPaidStt
        '
        Me.GridColumnPaidStt.Caption = "Payment Status"
        Me.GridColumnPaidStt.FieldName = "paid_status"
        Me.GridColumnPaidStt.Name = "GridColumnPaidStt"
        Me.GridColumnPaidStt.Visible = True
        Me.GridColumnPaidStt.VisibleIndex = 5
        '
        'GridColumnBal
        '
        Me.GridColumnBal.Caption = "Balance Due"
        Me.GridColumnBal.DisplayFormat.FormatString = "N2"
        Me.GridColumnBal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnBal.FieldName = "balance"
        Me.GridColumnBal.Name = "GridColumnBal"
        Me.GridColumnBal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "balance", "{0:N2}")})
        Me.GridColumnBal.Visible = True
        Me.GridColumnBal.VisibleIndex = 6
        '
        'GridColumntotal
        '
        Me.GridColumntotal.Caption = "Total"
        Me.GridColumntotal.DisplayFormat.FormatString = "N2"
        Me.GridColumntotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal.FieldName = "total"
        Me.GridColumntotal.Name = "GridColumntotal"
        Me.GridColumntotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:N2}")})
        Me.GridColumntotal.Visible = True
        Me.GridColumntotal.VisibleIndex = 7
        '
        'GridColumnIdComp
        '
        Me.GridColumnIdComp.Caption = "Id Comp"
        Me.GridColumnIdComp.FieldName = "id_comp"
        Me.GridColumnIdComp.Name = "GridColumnIdComp"
        '
        'GridColumnBeneficiary
        '
        Me.GridColumnBeneficiary.Caption = "Beneficiary"
        Me.GridColumnBeneficiary.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnBeneficiary.FieldName = "comp"
        Me.GridColumnBeneficiary.Name = "GridColumnBeneficiary"
        Me.GridColumnBeneficiary.Visible = True
        Me.GridColumnBeneficiary.VisibleIndex = 1
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        Me.RepositoryItemTextEdit1.NullText = "-"
        '
        'FormItemExpense
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(783, 553)
        Me.Controls.Add(Me.GCData)
        Me.Name = "FormItemExpense"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Expense"
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedByName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReortStt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPaidStt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdComp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBeneficiary As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
End Class
