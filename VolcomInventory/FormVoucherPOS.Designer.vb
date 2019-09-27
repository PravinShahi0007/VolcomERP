<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormVoucherPOS
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
        Me.GridColumnid_pos_voucher = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnvoucher_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnvoucher_value = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnvoucher_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnvoucher_address = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnperiod_start = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnperiod_end = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_outlet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnoutlet_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTransNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnstatus = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.GCData.Size = New System.Drawing.Size(677, 395)
        Me.GCData.TabIndex = 0
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_pos_voucher, Me.GridColumnvoucher_number, Me.GridColumnvoucher_value, Me.GridColumnvoucher_name, Me.GridColumnvoucher_address, Me.GridColumnperiod_start, Me.GridColumnperiod_end, Me.GridColumnid_outlet, Me.GridColumnoutlet_name, Me.GridColumnTransNumber, Me.GridColumnstatus})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_pos_voucher
        '
        Me.GridColumnid_pos_voucher.Caption = "id_pos_voucher"
        Me.GridColumnid_pos_voucher.FieldName = "id_pos_voucher"
        Me.GridColumnid_pos_voucher.Name = "GridColumnid_pos_voucher"
        '
        'GridColumnvoucher_number
        '
        Me.GridColumnvoucher_number.Caption = "Voucher No."
        Me.GridColumnvoucher_number.FieldName = "voucher_number"
        Me.GridColumnvoucher_number.Name = "GridColumnvoucher_number"
        Me.GridColumnvoucher_number.Visible = True
        Me.GridColumnvoucher_number.VisibleIndex = 0
        '
        'GridColumnvoucher_value
        '
        Me.GridColumnvoucher_value.Caption = "Nominal"
        Me.GridColumnvoucher_value.DisplayFormat.FormatString = "N0"
        Me.GridColumnvoucher_value.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnvoucher_value.FieldName = "voucher_value"
        Me.GridColumnvoucher_value.Name = "GridColumnvoucher_value"
        Me.GridColumnvoucher_value.Visible = True
        Me.GridColumnvoucher_value.VisibleIndex = 1
        '
        'GridColumnvoucher_name
        '
        Me.GridColumnvoucher_name.Caption = "On behalf"
        Me.GridColumnvoucher_name.FieldName = "voucher_name"
        Me.GridColumnvoucher_name.Name = "GridColumnvoucher_name"
        Me.GridColumnvoucher_name.Visible = True
        Me.GridColumnvoucher_name.VisibleIndex = 2
        '
        'GridColumnvoucher_address
        '
        Me.GridColumnvoucher_address.Caption = "Address"
        Me.GridColumnvoucher_address.FieldName = "voucher_address"
        Me.GridColumnvoucher_address.Name = "GridColumnvoucher_address"
        Me.GridColumnvoucher_address.Visible = True
        Me.GridColumnvoucher_address.VisibleIndex = 3
        '
        'GridColumnperiod_start
        '
        Me.GridColumnperiod_start.Caption = "Start"
        Me.GridColumnperiod_start.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnperiod_start.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnperiod_start.FieldName = "period_start"
        Me.GridColumnperiod_start.Name = "GridColumnperiod_start"
        Me.GridColumnperiod_start.Visible = True
        Me.GridColumnperiod_start.VisibleIndex = 4
        '
        'GridColumnperiod_end
        '
        Me.GridColumnperiod_end.Caption = "End"
        Me.GridColumnperiod_end.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnperiod_end.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnperiod_end.FieldName = "period_end"
        Me.GridColumnperiod_end.Name = "GridColumnperiod_end"
        Me.GridColumnperiod_end.Visible = True
        Me.GridColumnperiod_end.VisibleIndex = 5
        '
        'GridColumnid_outlet
        '
        Me.GridColumnid_outlet.Caption = "id_outlet"
        Me.GridColumnid_outlet.FieldName = "id_outlet"
        Me.GridColumnid_outlet.Name = "GridColumnid_outlet"
        '
        'GridColumnoutlet_name
        '
        Me.GridColumnoutlet_name.Caption = "Already used at"
        Me.GridColumnoutlet_name.FieldName = "outlet_name"
        Me.GridColumnoutlet_name.Name = "GridColumnoutlet_name"
        Me.GridColumnoutlet_name.Visible = True
        Me.GridColumnoutlet_name.VisibleIndex = 6
        '
        'GridColumnTransNumber
        '
        Me.GridColumnTransNumber.Caption = "Transaction No."
        Me.GridColumnTransNumber.FieldName = "trans_number"
        Me.GridColumnTransNumber.Name = "GridColumnTransNumber"
        Me.GridColumnTransNumber.Visible = True
        Me.GridColumnTransNumber.VisibleIndex = 7
        Me.GridColumnTransNumber.Width = 146
        '
        'GridColumnstatus
        '
        Me.GridColumnstatus.Caption = "Status"
        Me.GridColumnstatus.FieldName = "status"
        Me.GridColumnstatus.Name = "GridColumnstatus"
        Me.GridColumnstatus.Visible = True
        Me.GridColumnstatus.VisibleIndex = 8
        '
        'FormVoucherPOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(677, 395)
        Me.Controls.Add(Me.GCData)
        Me.Name = "FormVoucherPOS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Voucher POS"
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_pos_voucher As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnvoucher_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnvoucher_value As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnvoucher_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnvoucher_address As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnperiod_start As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnperiod_end As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_outlet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnoutlet_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnstatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTransNumber As DevExpress.XtraGrid.Columns.GridColumn
End Class
