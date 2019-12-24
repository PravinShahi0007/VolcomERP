<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDelayPaymentPick
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDelayPaymentPick))
        Me.PanelControlNav = New DevExpress.XtraEditors.PanelControl()
        Me.BtnDiscard = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_sales_pos = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnstore = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_due_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnaging = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnaging_view = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnperiod = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnamount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnremark = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnis_select = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNav.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControlNav
        '
        Me.PanelControlNav.Controls.Add(Me.BtnDiscard)
        Me.PanelControlNav.Controls.Add(Me.BtnAdd)
        Me.PanelControlNav.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControlNav.Location = New System.Drawing.Point(0, 363)
        Me.PanelControlNav.Name = "PanelControlNav"
        Me.PanelControlNav.Size = New System.Drawing.Size(734, 48)
        Me.PanelControlNav.TabIndex = 0
        '
        'BtnDiscard
        '
        Me.BtnDiscard.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDiscard.Image = CType(resources.GetObject("BtnDiscard.Image"), System.Drawing.Image)
        Me.BtnDiscard.Location = New System.Drawing.Point(558, 2)
        Me.BtnDiscard.Name = "BtnDiscard"
        Me.BtnDiscard.Size = New System.Drawing.Size(90, 44)
        Me.BtnDiscard.TabIndex = 1
        Me.BtnDiscard.Text = "Discard"
        '
        'BtnAdd
        '
        Me.BtnAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"), System.Drawing.Image)
        Me.BtnAdd.Location = New System.Drawing.Point(648, 2)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(84, 44)
        Me.BtnAdd.TabIndex = 0
        Me.BtnAdd.Text = "Add"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCData.Size = New System.Drawing.Size(734, 363)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_sales_pos, Me.GridColumnsales_pos_number, Me.GridColumnstore, Me.GridColumnsales_pos_date, Me.GridColumnsales_pos_due_date, Me.GridColumnaging, Me.GridColumnaging_view, Me.GridColumnperiod, Me.GridColumnamount, Me.GridColumnremark, Me.GridColumnis_select})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_sales_pos
        '
        Me.GridColumnid_sales_pos.Caption = "id_sales_pos"
        Me.GridColumnid_sales_pos.FieldName = "id_sales_pos"
        Me.GridColumnid_sales_pos.Name = "GridColumnid_sales_pos"
        Me.GridColumnid_sales_pos.OptionsColumn.AllowEdit = False
        '
        'GridColumnsales_pos_number
        '
        Me.GridColumnsales_pos_number.Caption = "Invoice No"
        Me.GridColumnsales_pos_number.FieldName = "sales_pos_number"
        Me.GridColumnsales_pos_number.Name = "GridColumnsales_pos_number"
        Me.GridColumnsales_pos_number.OptionsColumn.AllowEdit = False
        Me.GridColumnsales_pos_number.Visible = True
        Me.GridColumnsales_pos_number.VisibleIndex = 0
        '
        'GridColumnstore
        '
        Me.GridColumnstore.Caption = "Store"
        Me.GridColumnstore.FieldName = "store"
        Me.GridColumnstore.Name = "GridColumnstore"
        Me.GridColumnstore.OptionsColumn.AllowEdit = False
        Me.GridColumnstore.Visible = True
        Me.GridColumnstore.VisibleIndex = 1
        '
        'GridColumnsales_pos_date
        '
        Me.GridColumnsales_pos_date.Caption = "Created Date"
        Me.GridColumnsales_pos_date.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.GridColumnsales_pos_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsales_pos_date.FieldName = "sales_pos_date"
        Me.GridColumnsales_pos_date.Name = "GridColumnsales_pos_date"
        Me.GridColumnsales_pos_date.OptionsColumn.AllowEdit = False
        Me.GridColumnsales_pos_date.Visible = True
        Me.GridColumnsales_pos_date.VisibleIndex = 2
        '
        'GridColumnsales_pos_due_date
        '
        Me.GridColumnsales_pos_due_date.Caption = "Due Date"
        Me.GridColumnsales_pos_due_date.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.GridColumnsales_pos_due_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsales_pos_due_date.FieldName = "sales_pos_due_date"
        Me.GridColumnsales_pos_due_date.Name = "GridColumnsales_pos_due_date"
        Me.GridColumnsales_pos_due_date.Visible = True
        Me.GridColumnsales_pos_due_date.VisibleIndex = 4
        '
        'GridColumnaging
        '
        Me.GridColumnaging.Caption = "Aging Data"
        Me.GridColumnaging.FieldName = "aging"
        Me.GridColumnaging.Name = "GridColumnaging"
        Me.GridColumnaging.OptionsColumn.AllowEdit = False
        '
        'GridColumnaging_view
        '
        Me.GridColumnaging_view.Caption = "Aging"
        Me.GridColumnaging_view.FieldName = "aging_view"
        Me.GridColumnaging_view.Name = "GridColumnaging_view"
        Me.GridColumnaging_view.OptionsColumn.AllowEdit = False
        Me.GridColumnaging_view.UnboundExpression = "Iif([aging] > 0, Concat('+', [aging]), Iif([aging] < 0, [aging], 0))"
        Me.GridColumnaging_view.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.GridColumnaging_view.Visible = True
        Me.GridColumnaging_view.VisibleIndex = 5
        '
        'GridColumnperiod
        '
        Me.GridColumnperiod.Caption = "Period"
        Me.GridColumnperiod.FieldName = "period"
        Me.GridColumnperiod.Name = "GridColumnperiod"
        Me.GridColumnperiod.OptionsColumn.AllowEdit = False
        Me.GridColumnperiod.Visible = True
        Me.GridColumnperiod.VisibleIndex = 3
        '
        'GridColumnamount
        '
        Me.GridColumnamount.Caption = "Amount"
        Me.GridColumnamount.DisplayFormat.FormatString = "N2"
        Me.GridColumnamount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnamount.FieldName = "amount"
        Me.GridColumnamount.Name = "GridColumnamount"
        Me.GridColumnamount.OptionsColumn.AllowEdit = False
        Me.GridColumnamount.Visible = True
        Me.GridColumnamount.VisibleIndex = 6
        '
        'GridColumnremark
        '
        Me.GridColumnremark.Caption = "Remark"
        Me.GridColumnremark.FieldName = "remark"
        Me.GridColumnremark.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right
        Me.GridColumnremark.Name = "GridColumnremark"
        Me.GridColumnremark.Visible = True
        Me.GridColumnremark.VisibleIndex = 7
        '
        'GridColumnis_select
        '
        Me.GridColumnis_select.Caption = "Select"
        Me.GridColumnis_select.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnis_select.FieldName = "is_select"
        Me.GridColumnis_select.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right
        Me.GridColumnis_select.Name = "GridColumnis_select"
        Me.GridColumnis_select.Visible = True
        Me.GridColumnis_select.VisibleIndex = 8
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "no"
        '
        'FormDelayPaymentPick
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 411)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControlNav)
        Me.Name = "FormDelayPaymentPick"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Invoice"
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNav.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControlNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnDiscard As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_sales_pos As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_pos_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnstore As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_pos_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_pos_due_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnaging As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnaging_view As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnperiod As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnamount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnremark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnis_select As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
End Class
