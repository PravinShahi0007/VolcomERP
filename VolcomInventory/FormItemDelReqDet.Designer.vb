<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormItemDelReqDet
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
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnITemName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdItemn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRemark = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFinalReason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSattus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQtyDel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnUom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDelStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(784, 411)
        Me.GCData.TabIndex = 16
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNo, Me.GridColumnITemName, Me.GridColumnIdItemn, Me.GridColumnQty, Me.GridColumnRemark, Me.GridColumnStt, Me.GridColumnFinalReason, Me.GridColumnSattus, Me.GridColumnQtyDel, Me.GridColumnUom, Me.GridColumnDelStatus})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.OptionsColumn.AllowEdit = False
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 66
        '
        'GridColumnITemName
        '
        Me.GridColumnITemName.Caption = "Description"
        Me.GridColumnITemName.FieldName = "item_desc"
        Me.GridColumnITemName.Name = "GridColumnITemName"
        Me.GridColumnITemName.OptionsColumn.AllowEdit = False
        Me.GridColumnITemName.Visible = True
        Me.GridColumnITemName.VisibleIndex = 1
        Me.GridColumnITemName.Width = 412
        '
        'GridColumnIdItemn
        '
        Me.GridColumnIdItemn.Caption = "Id Item"
        Me.GridColumnIdItemn.FieldName = "id_item"
        Me.GridColumnIdItemn.Name = "GridColumnIdItemn"
        Me.GridColumnIdItemn.OptionsColumn.AllowEdit = False
        '
        'GridColumnQty
        '
        Me.GridColumnQty.Caption = "Requested Qty"
        Me.GridColumnQty.DisplayFormat.FormatString = "N2"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.OptionsColumn.AllowEdit = False
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N2}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 3
        Me.GridColumnQty.Width = 100
        '
        'GridColumnRemark
        '
        Me.GridColumnRemark.Caption = "Request Note"
        Me.GridColumnRemark.FieldName = "remark"
        Me.GridColumnRemark.Name = "GridColumnRemark"
        Me.GridColumnRemark.Visible = True
        Me.GridColumnRemark.VisibleIndex = 6
        Me.GridColumnRemark.Width = 302
        '
        'GridColumnStt
        '
        Me.GridColumnStt.Caption = "Status"
        Me.GridColumnStt.FieldName = "stt"
        Me.GridColumnStt.Name = "GridColumnStt"
        '
        'GridColumnFinalReason
        '
        Me.GridColumnFinalReason.Caption = "Note"
        Me.GridColumnFinalReason.FieldName = "final_reason"
        Me.GridColumnFinalReason.Name = "GridColumnFinalReason"
        Me.GridColumnFinalReason.Visible = True
        Me.GridColumnFinalReason.VisibleIndex = 8
        Me.GridColumnFinalReason.Width = 242
        '
        'GridColumnSattus
        '
        Me.GridColumnSattus.Caption = "Request Status"
        Me.GridColumnSattus.FieldName = "prepare_status"
        Me.GridColumnSattus.Name = "GridColumnSattus"
        Me.GridColumnSattus.Visible = True
        Me.GridColumnSattus.VisibleIndex = 7
        Me.GridColumnSattus.Width = 249
        '
        'GridColumnQtyDel
        '
        Me.GridColumnQtyDel.Caption = "Delivered Qty"
        Me.GridColumnQtyDel.DisplayFormat.FormatString = "N2"
        Me.GridColumnQtyDel.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyDel.FieldName = "qty_del"
        Me.GridColumnQtyDel.Name = "GridColumnQtyDel"
        Me.GridColumnQtyDel.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_del", "{0:N2}")})
        Me.GridColumnQtyDel.Visible = True
        Me.GridColumnQtyDel.VisibleIndex = 4
        Me.GridColumnQtyDel.Width = 90
        '
        'GridColumnUom
        '
        Me.GridColumnUom.Caption = "UOM"
        Me.GridColumnUom.FieldName = "uom"
        Me.GridColumnUom.Name = "GridColumnUom"
        Me.GridColumnUom.Visible = True
        Me.GridColumnUom.VisibleIndex = 2
        Me.GridColumnUom.Width = 68
        '
        'GridColumnDelStatus
        '
        Me.GridColumnDelStatus.Caption = "Delivery Status"
        Me.GridColumnDelStatus.FieldName = "del_status"
        Me.GridColumnDelStatus.Name = "GridColumnDelStatus"
        Me.GridColumnDelStatus.Visible = True
        Me.GridColumnDelStatus.VisibleIndex = 5
        Me.GridColumnDelStatus.Width = 103
        '
        'FormItemDelReqDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 411)
        Me.Controls.Add(Me.GCData)
        Me.MinimizeBox = False
        Me.Name = "FormItemDelReqDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detail Request"
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnITemName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdItemn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRemark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFinalReason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSattus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyDel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDelStatus As DevExpress.XtraGrid.Columns.GridColumn
End Class
