<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMatWO
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
        Me.GCMatWO = New DevExpress.XtraGrid.GridControl
        Me.GVMatWO = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdMatPurchase = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColDelivery = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColPONumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColShipFrom = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColShipTo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSamplePurcDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColRecDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColDueDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColPayment = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColStatus = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIDStatus = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdDelivery = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdWoType = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColWoType = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.GCMatWO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMatWO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCMatWO
        '
        Me.GCMatWO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMatWO.Location = New System.Drawing.Point(0, 0)
        Me.GCMatWO.MainView = Me.GVMatWO
        Me.GCMatWO.Name = "GCMatWO"
        Me.GCMatWO.Size = New System.Drawing.Size(852, 344)
        Me.GCMatWO.TabIndex = 6
        Me.GCMatWO.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMatWO})
        '
        'GVMatWO
        '
        Me.GVMatWO.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdMatPurchase, Me.ColSeason, Me.ColDelivery, Me.ColPONumber, Me.ColShipFrom, Me.ColShipTo, Me.ColSamplePurcDate, Me.ColRecDate, Me.ColDueDate, Me.ColPayment, Me.ColStatus, Me.ColIDStatus, Me.ColIdDelivery, Me.ColIdSeason, Me.ColIdWoType, Me.ColWoType})
        Me.GVMatWO.GridControl = Me.GCMatWO
        Me.GVMatWO.GroupCount = 2
        Me.GVMatWO.Name = "GVMatWO"
        Me.GVMatWO.OptionsBehavior.Editable = False
        Me.GVMatWO.OptionsFind.AlwaysVisible = True
        Me.GVMatWO.OptionsView.ShowGroupPanel = False
        Me.GVMatWO.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColSeason, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColDelivery, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColIdWoType, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'ColIdMatPurchase
        '
        Me.ColIdMatPurchase.Caption = "ID Sample Purchase"
        Me.ColIdMatPurchase.FieldName = "id_mat_wo"
        Me.ColIdMatPurchase.Name = "ColIdMatPurchase"
        '
        'ColSeason
        '
        Me.ColSeason.Caption = "Season"
        Me.ColSeason.FieldName = "season"
        Me.ColSeason.FieldNameSortGroup = "id_season"
        Me.ColSeason.Name = "ColSeason"
        Me.ColSeason.Visible = True
        Me.ColSeason.VisibleIndex = 9
        '
        'ColDelivery
        '
        Me.ColDelivery.Caption = "Del"
        Me.ColDelivery.FieldName = "delivery"
        Me.ColDelivery.FieldNameSortGroup = "id_delivery"
        Me.ColDelivery.Name = "ColDelivery"
        Me.ColDelivery.Visible = True
        Me.ColDelivery.VisibleIndex = 9
        '
        'ColPONumber
        '
        Me.ColPONumber.Caption = "Number"
        Me.ColPONumber.FieldName = "mat_wo_number"
        Me.ColPONumber.Name = "ColPONumber"
        Me.ColPONumber.Visible = True
        Me.ColPONumber.VisibleIndex = 0
        Me.ColPONumber.Width = 120
        '
        'ColShipFrom
        '
        Me.ColShipFrom.Caption = "To"
        Me.ColShipFrom.FieldName = "comp_name_to"
        Me.ColShipFrom.Name = "ColShipFrom"
        Me.ColShipFrom.Visible = True
        Me.ColShipFrom.VisibleIndex = 2
        Me.ColShipFrom.Width = 107
        '
        'ColShipTo
        '
        Me.ColShipTo.Caption = "Ship To"
        Me.ColShipTo.FieldName = "comp_name_ship_to"
        Me.ColShipTo.Name = "ColShipTo"
        Me.ColShipTo.Visible = True
        Me.ColShipTo.VisibleIndex = 3
        Me.ColShipTo.Width = 107
        '
        'ColSamplePurcDate
        '
        Me.ColSamplePurcDate.Caption = "Create Date"
        Me.ColSamplePurcDate.FieldName = "mat_wo_date"
        Me.ColSamplePurcDate.Name = "ColSamplePurcDate"
        Me.ColSamplePurcDate.Visible = True
        Me.ColSamplePurcDate.VisibleIndex = 5
        Me.ColSamplePurcDate.Width = 99
        '
        'ColRecDate
        '
        Me.ColRecDate.Caption = "Est. Receive Date"
        Me.ColRecDate.FieldName = "mat_wo_lead_time"
        Me.ColRecDate.Name = "ColRecDate"
        Me.ColRecDate.Visible = True
        Me.ColRecDate.VisibleIndex = 6
        Me.ColRecDate.Width = 99
        '
        'ColDueDate
        '
        Me.ColDueDate.Caption = "Due Date"
        Me.ColDueDate.FieldName = "mat_wo_top"
        Me.ColDueDate.Name = "ColDueDate"
        Me.ColDueDate.Visible = True
        Me.ColDueDate.VisibleIndex = 7
        Me.ColDueDate.Width = 109
        '
        'ColPayment
        '
        Me.ColPayment.Caption = "Payment"
        Me.ColPayment.FieldName = "payment"
        Me.ColPayment.Name = "ColPayment"
        Me.ColPayment.Visible = True
        Me.ColPayment.VisibleIndex = 4
        Me.ColPayment.Width = 80
        '
        'ColStatus
        '
        Me.ColStatus.Caption = "Status"
        Me.ColStatus.FieldName = "report_status"
        Me.ColStatus.Name = "ColStatus"
        Me.ColStatus.Visible = True
        Me.ColStatus.VisibleIndex = 8
        Me.ColStatus.Width = 62
        '
        'ColIDStatus
        '
        Me.ColIDStatus.Caption = "ID Status"
        Me.ColIDStatus.FieldName = "id_report_status"
        Me.ColIDStatus.Name = "ColIDStatus"
        '
        'ColIdDelivery
        '
        Me.ColIdDelivery.Caption = "Delivery"
        Me.ColIdDelivery.FieldName = "id_delivery"
        Me.ColIdDelivery.Name = "ColIdDelivery"
        '
        'ColIdSeason
        '
        Me.ColIdSeason.Caption = "Season"
        Me.ColIdSeason.FieldName = "id_season"
        Me.ColIdSeason.Name = "ColIdSeason"
        '
        'ColIdWoType
        '
        Me.ColIdWoType.Caption = "WO Type"
        Me.ColIdWoType.FieldName = "id_overhead"
        Me.ColIdWoType.Name = "ColIdWoType"
        Me.ColIdWoType.Width = 80
        '
        'ColWoType
        '
        Me.ColWoType.Caption = "WO Type"
        Me.ColWoType.FieldName = "overhead"
        Me.ColWoType.Name = "ColWoType"
        Me.ColWoType.Visible = True
        Me.ColWoType.VisibleIndex = 1
        '
        'FormMatWO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(852, 344)
        Me.Controls.Add(Me.GCMatWO)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMatWO"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Raw Material Work Order"
        CType(Me.GCMatWO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMatWO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCMatWO As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMatWO As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdMatPurchase As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDelivery As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPONumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColShipFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColShipTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSamplePurcDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRecDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPayment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIDStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdDelivery As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdWoType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColWoType As DevExpress.XtraGrid.Columns.GridColumn
End Class
