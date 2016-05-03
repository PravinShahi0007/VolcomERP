<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGCodeReplace
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
        Me.XTCFGCodeReplace = New DevExpress.XtraTab.XtraTabControl
        Me.XTPFGCodeReplaceStore = New DevExpress.XtraTab.XtraTabPage
        Me.GCFGCodeReplaceStore = New DevExpress.XtraGrid.GridControl
        Me.GVFGCodeReplaceStore = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn
        Me.XTPFGCodeReplaceWH = New DevExpress.XtraTab.XtraTabPage
        Me.GCFGCodeReplaceWH = New DevExpress.XtraGrid.GridControl
        Me.GVFGCodeReplaceWH = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.XTCFGCodeReplace, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCFGCodeReplace.SuspendLayout()
        Me.XTPFGCodeReplaceStore.SuspendLayout()
        CType(Me.GCFGCodeReplaceStore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVFGCodeReplaceStore, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPFGCodeReplaceWH.SuspendLayout()
        CType(Me.GCFGCodeReplaceWH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVFGCodeReplaceWH, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCFGCodeReplace
        '
        Me.XTCFGCodeReplace.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCFGCodeReplace.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Right
        Me.XTCFGCodeReplace.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal
        Me.XTCFGCodeReplace.Location = New System.Drawing.Point(0, 0)
        Me.XTCFGCodeReplace.Name = "XTCFGCodeReplace"
        Me.XTCFGCodeReplace.SelectedTabPage = Me.XTPFGCodeReplaceStore
        Me.XTCFGCodeReplace.Size = New System.Drawing.Size(707, 453)
        Me.XTCFGCodeReplace.TabIndex = 0
        Me.XTCFGCodeReplace.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPFGCodeReplaceStore, Me.XTPFGCodeReplaceWH})
        '
        'XTPFGCodeReplaceStore
        '
        Me.XTPFGCodeReplaceStore.Controls.Add(Me.GCFGCodeReplaceStore)
        Me.XTPFGCodeReplaceStore.Name = "XTPFGCodeReplaceStore"
        Me.XTPFGCodeReplaceStore.Size = New System.Drawing.Size(650, 447)
        Me.XTPFGCodeReplaceStore.Text = "In Store"
        '
        'GCFGCodeReplaceStore
        '
        Me.GCFGCodeReplaceStore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCFGCodeReplaceStore.Location = New System.Drawing.Point(0, 0)
        Me.GCFGCodeReplaceStore.MainView = Me.GVFGCodeReplaceStore
        Me.GCFGCodeReplaceStore.Name = "GCFGCodeReplaceStore"
        Me.GCFGCodeReplaceStore.Size = New System.Drawing.Size(650, 447)
        Me.GCFGCodeReplaceStore.TabIndex = 0
        Me.GCFGCodeReplaceStore.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVFGCodeReplaceStore})
        '
        'GVFGCodeReplaceStore
        '
        Me.GVFGCodeReplaceStore.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNumber, Me.GridColumnDate, Me.GridColumnStatus})
        Me.GVFGCodeReplaceStore.GridControl = Me.GCFGCodeReplaceStore
        Me.GVFGCodeReplaceStore.Name = "GVFGCodeReplaceStore"
        Me.GVFGCodeReplaceStore.OptionsBehavior.ReadOnly = True
        Me.GVFGCodeReplaceStore.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNumber
        '
        Me.GridColumnNumber.Caption = "Number"
        Me.GridColumnNumber.FieldName = "fg_code_replace_store_number"
        Me.GridColumnNumber.Name = "GridColumnNumber"
        Me.GridColumnNumber.Visible = True
        Me.GridColumnNumber.VisibleIndex = 0
        '
        'GridColumnDate
        '
        Me.GridColumnDate.Caption = "Date"
        Me.GridColumnDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnDate.FieldName = "fg_code_replace_store_date"
        Me.GridColumnDate.Name = "GridColumnDate"
        Me.GridColumnDate.Visible = True
        Me.GridColumnDate.VisibleIndex = 1
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 2
        '
        'XTPFGCodeReplaceWH
        '
        Me.XTPFGCodeReplaceWH.Controls.Add(Me.GCFGCodeReplaceWH)
        Me.XTPFGCodeReplaceWH.Name = "XTPFGCodeReplaceWH"
        Me.XTPFGCodeReplaceWH.Size = New System.Drawing.Size(650, 447)
        Me.XTPFGCodeReplaceWH.Text = "In WH"
        '
        'GCFGCodeReplaceWH
        '
        Me.GCFGCodeReplaceWH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCFGCodeReplaceWH.Location = New System.Drawing.Point(0, 0)
        Me.GCFGCodeReplaceWH.MainView = Me.GVFGCodeReplaceWH
        Me.GCFGCodeReplaceWH.Name = "GCFGCodeReplaceWH"
        Me.GCFGCodeReplaceWH.Size = New System.Drawing.Size(650, 447)
        Me.GCFGCodeReplaceWH.TabIndex = 1
        Me.GCFGCodeReplaceWH.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVFGCodeReplaceWH})
        '
        'GVFGCodeReplaceWH
        '
        Me.GVFGCodeReplaceWH.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3})
        Me.GVFGCodeReplaceWH.GridControl = Me.GCFGCodeReplaceWH
        Me.GVFGCodeReplaceWH.Name = "GVFGCodeReplaceWH"
        Me.GVFGCodeReplaceWH.OptionsBehavior.ReadOnly = True
        Me.GVFGCodeReplaceWH.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Number"
        Me.GridColumn1.FieldName = "fg_code_replace_wh_number"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Date"
        Me.GridColumn2.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn2.FieldName = "fg_code_replace_wh_date"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Status"
        Me.GridColumn3.FieldName = "report_status"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'FormFGCodeReplace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(707, 453)
        Me.Controls.Add(Me.XTCFGCodeReplace)
        Me.Name = "FormFGCodeReplace"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Finished Goods Code Replacement"
        CType(Me.XTCFGCodeReplace, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCFGCodeReplace.ResumeLayout(False)
        Me.XTPFGCodeReplaceStore.ResumeLayout(False)
        CType(Me.GCFGCodeReplaceStore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVFGCodeReplaceStore, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPFGCodeReplaceWH.ResumeLayout(False)
        CType(Me.GCFGCodeReplaceWH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVFGCodeReplaceWH, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XTCFGCodeReplace As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPFGCodeReplaceStore As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPFGCodeReplaceWH As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCFGCodeReplaceStore As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVFGCodeReplaceStore As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCFGCodeReplaceWH As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVFGCodeReplaceWH As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
End Class
