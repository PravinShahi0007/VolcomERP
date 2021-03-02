<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPayoutZaloraManualReconRef
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPayoutZaloraManualReconRef))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtOrderNo = New DevExpress.XtraEditors.TextEdit()
        Me.BtnSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.GridColumnis_select = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnitem_id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnproduct_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_ref = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1id_ref_det = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnrmt_ref = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnreport_mark_type_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnref = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnamo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_acc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_comp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_number = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtOrderNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.PanelControl2)
        Me.PanelControl1.Controls.Add(Me.BtnSearch)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 48)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnAdd
        '
        Me.BtnAdd.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"), System.Drawing.Image)
        Me.BtnAdd.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        Me.BtnAdd.Location = New System.Drawing.Point(0, 287)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(784, 44)
        Me.BtnAdd.TabIndex = 0
        Me.BtnAdd.Text = "Add Reference"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 48)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCData.Size = New System.Drawing.Size(784, 239)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnis_select, Me.GridColumnitem_id, Me.GridColumncode, Me.GridColumnproduct_name, Me.GridColumnsize, Me.GridColumnname, Me.GridColumnid_ref, Me.GridColumn1id_ref_det, Me.GridColumnrmt_ref, Me.GridColumnreport_mark_type_name, Me.GridColumnref, Me.GridColumnamo, Me.GridColumnid_acc, Me.GridColumnid_comp, Me.GridColumncomp_number})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(9, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(68, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Order Number"
        '
        'TxtOrderNo
        '
        Me.TxtOrderNo.Location = New System.Drawing.Point(83, 12)
        Me.TxtOrderNo.Name = "TxtOrderNo"
        Me.TxtOrderNo.Size = New System.Drawing.Size(158, 20)
        Me.TxtOrderNo.TabIndex = 1
        '
        'BtnSearch
        '
        Me.BtnSearch.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSearch.Image = CType(resources.GetObject("BtnSearch.Image"), System.Drawing.Image)
        Me.BtnSearch.Location = New System.Drawing.Point(694, 2)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(88, 44)
        Me.BtnSearch.TabIndex = 2
        Me.BtnSearch.Text = "Search"
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.TxtOrderNo)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl2.Location = New System.Drawing.Point(445, 2)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(249, 44)
        Me.PanelControl2.TabIndex = 3
        '
        'GridColumnis_select
        '
        Me.GridColumnis_select.Caption = "Select"
        Me.GridColumnis_select.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnis_select.FieldName = "is_select"
        Me.GridColumnis_select.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumnis_select.Name = "GridColumnis_select"
        Me.GridColumnis_select.Visible = True
        Me.GridColumnis_select.VisibleIndex = 0
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'GridColumnitem_id
        '
        Me.GridColumnitem_id.Caption = "Item Id"
        Me.GridColumnitem_id.FieldName = "item_id"
        Me.GridColumnitem_id.Name = "GridColumnitem_id"
        Me.GridColumnitem_id.OptionsColumn.ReadOnly = True
        Me.GridColumnitem_id.Visible = True
        Me.GridColumnitem_id.VisibleIndex = 1
        '
        'GridColumncode
        '
        Me.GridColumncode.Caption = "Code"
        Me.GridColumncode.FieldName = "code"
        Me.GridColumncode.Name = "GridColumncode"
        Me.GridColumncode.OptionsColumn.ReadOnly = True
        Me.GridColumncode.Visible = True
        Me.GridColumncode.VisibleIndex = 2
        '
        'GridColumnproduct_name
        '
        Me.GridColumnproduct_name.Caption = "Description"
        Me.GridColumnproduct_name.FieldName = "product_name"
        Me.GridColumnproduct_name.Name = "GridColumnproduct_name"
        Me.GridColumnproduct_name.OptionsColumn.ReadOnly = True
        Me.GridColumnproduct_name.Visible = True
        Me.GridColumnproduct_name.VisibleIndex = 3
        '
        'GridColumnsize
        '
        Me.GridColumnsize.Caption = "Size"
        Me.GridColumnsize.FieldName = "size"
        Me.GridColumnsize.Name = "GridColumnsize"
        Me.GridColumnsize.OptionsColumn.ReadOnly = True
        Me.GridColumnsize.Visible = True
        Me.GridColumnsize.VisibleIndex = 4
        '
        'GridColumnname
        '
        Me.GridColumnname.Caption = "Account Description"
        Me.GridColumnname.FieldName = "name"
        Me.GridColumnname.Name = "GridColumnname"
        Me.GridColumnname.OptionsColumn.ReadOnly = True
        '
        'GridColumnid_ref
        '
        Me.GridColumnid_ref.Caption = "id_ref"
        Me.GridColumnid_ref.FieldName = "id_ref"
        Me.GridColumnid_ref.Name = "GridColumnid_ref"
        Me.GridColumnid_ref.OptionsColumn.ReadOnly = True
        '
        'GridColumn1id_ref_det
        '
        Me.GridColumn1id_ref_det.Caption = "id_ref_det"
        Me.GridColumn1id_ref_det.FieldName = "id_ref_det"
        Me.GridColumn1id_ref_det.Name = "GridColumn1id_ref_det"
        Me.GridColumn1id_ref_det.OptionsColumn.ReadOnly = True
        '
        'GridColumnrmt_ref
        '
        Me.GridColumnrmt_ref.Caption = "rmt_ref"
        Me.GridColumnrmt_ref.FieldName = "rmt_ref"
        Me.GridColumnrmt_ref.Name = "GridColumnrmt_ref"
        Me.GridColumnrmt_ref.OptionsColumn.ReadOnly = True
        '
        'GridColumnreport_mark_type_name
        '
        Me.GridColumnreport_mark_type_name.Caption = "Trans. Type"
        Me.GridColumnreport_mark_type_name.FieldName = "report_mark_type_name"
        Me.GridColumnreport_mark_type_name.Name = "GridColumnreport_mark_type_name"
        Me.GridColumnreport_mark_type_name.OptionsColumn.ReadOnly = True
        Me.GridColumnreport_mark_type_name.Visible = True
        Me.GridColumnreport_mark_type_name.VisibleIndex = 5
        '
        'GridColumnref
        '
        Me.GridColumnref.Caption = "Ref. No."
        Me.GridColumnref.FieldName = "ref"
        Me.GridColumnref.Name = "GridColumnref"
        Me.GridColumnref.OptionsColumn.ReadOnly = True
        Me.GridColumnref.Visible = True
        Me.GridColumnref.VisibleIndex = 6
        '
        'GridColumnamo
        '
        Me.GridColumnamo.Caption = "Amount"
        Me.GridColumnamo.DisplayFormat.FormatString = "N2"
        Me.GridColumnamo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnamo.FieldName = "amo"
        Me.GridColumnamo.Name = "GridColumnamo"
        Me.GridColumnamo.OptionsColumn.ReadOnly = True
        Me.GridColumnamo.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amo", "{0:N2}")})
        Me.GridColumnamo.Visible = True
        Me.GridColumnamo.VisibleIndex = 7
        '
        'GridColumnid_acc
        '
        Me.GridColumnid_acc.Caption = "id_acc"
        Me.GridColumnid_acc.FieldName = "id_acc"
        Me.GridColumnid_acc.Name = "GridColumnid_acc"
        Me.GridColumnid_acc.OptionsColumn.ReadOnly = True
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
        Me.GridColumncomp_number.Caption = "Store Acc."
        Me.GridColumncomp_number.FieldName = "comp_number"
        Me.GridColumncomp_number.Name = "GridColumncomp_number"
        Me.GridColumncomp_number.OptionsColumn.ReadOnly = True
        '
        'FormPayoutZaloraManualReconRef
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 331)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormPayoutZaloraManualReconRef"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Reference"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtOrderNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TxtOrderNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnis_select As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnitem_id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnproduct_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_ref As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1id_ref_det As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnrmt_ref As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnreport_mark_type_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnref As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnamo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_acc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_comp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_number As DevExpress.XtraGrid.Columns.GridColumn
End Class
