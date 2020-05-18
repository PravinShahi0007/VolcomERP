<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOlStoreReturnInputAWB
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
        Me.GCRequest = New DevExpress.XtraGrid.GridControl()
        Me.GVRequest = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_ol_store_ret_req = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_comp_group_req = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_order_ol_shop_number_req = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnret_req_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnret_req_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_by_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnupdated_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnupdated_by_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnawb_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnreport_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SBInputAWB = New DevExpress.XtraEditors.SimpleButton()
        Me.TEInputAWB = New DevExpress.XtraEditors.TextEdit()
        CType(Me.GCRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.TEInputAWB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCRequest
        '
        Me.GCRequest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRequest.Location = New System.Drawing.Point(0, 49)
        Me.GCRequest.MainView = Me.GVRequest
        Me.GCRequest.Name = "GCRequest"
        Me.GCRequest.Size = New System.Drawing.Size(1008, 512)
        Me.GCRequest.TabIndex = 3
        Me.GCRequest.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRequest})
        '
        'GVRequest
        '
        Me.GVRequest.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_ol_store_ret_req, Me.GridColumnid_comp_group_req, Me.GridColumncomp_group_name, Me.GridColumnsales_order_ol_shop_number_req, Me.GridColumnnumber, Me.GridColumnret_req_number, Me.GridColumnret_req_date, Me.GridColumncreated_date, Me.GridColumncreated_by_name, Me.GridColumnupdated_date, Me.GridColumnupdated_by_name, Me.GridColumnawb_number, Me.GridColumnnote, Me.GridColumnreport_status})
        Me.GVRequest.GridControl = Me.GCRequest
        Me.GVRequest.Name = "GVRequest"
        Me.GVRequest.OptionsBehavior.ReadOnly = True
        Me.GVRequest.OptionsFind.AlwaysVisible = True
        Me.GVRequest.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_ol_store_ret_req
        '
        Me.GridColumnid_ol_store_ret_req.Caption = "id_ol_store_ret_req"
        Me.GridColumnid_ol_store_ret_req.FieldName = "id_ol_store_ret_req"
        Me.GridColumnid_ol_store_ret_req.Name = "GridColumnid_ol_store_ret_req"
        '
        'GridColumnid_comp_group_req
        '
        Me.GridColumnid_comp_group_req.Caption = "id_comp_group"
        Me.GridColumnid_comp_group_req.FieldName = "id_comp_group"
        Me.GridColumnid_comp_group_req.Name = "GridColumnid_comp_group_req"
        '
        'GridColumncomp_group_name
        '
        Me.GridColumncomp_group_name.Caption = "Store Group"
        Me.GridColumncomp_group_name.FieldName = "comp_group_name"
        Me.GridColumncomp_group_name.Name = "GridColumncomp_group_name"
        Me.GridColumncomp_group_name.Visible = True
        Me.GridColumncomp_group_name.VisibleIndex = 0
        '
        'GridColumnsales_order_ol_shop_number_req
        '
        Me.GridColumnsales_order_ol_shop_number_req.Caption = "Order Number"
        Me.GridColumnsales_order_ol_shop_number_req.FieldName = "sales_order_ol_shop_number"
        Me.GridColumnsales_order_ol_shop_number_req.Name = "GridColumnsales_order_ol_shop_number_req"
        Me.GridColumnsales_order_ol_shop_number_req.Visible = True
        Me.GridColumnsales_order_ol_shop_number_req.VisibleIndex = 1
        '
        'GridColumnnumber
        '
        Me.GridColumnnumber.Caption = "Number"
        Me.GridColumnnumber.FieldName = "number"
        Me.GridColumnnumber.Name = "GridColumnnumber"
        Me.GridColumnnumber.Visible = True
        Me.GridColumnnumber.VisibleIndex = 2
        '
        'GridColumnret_req_number
        '
        Me.GridColumnret_req_number.Caption = "Request Number"
        Me.GridColumnret_req_number.FieldName = "ret_req_number"
        Me.GridColumnret_req_number.Name = "GridColumnret_req_number"
        Me.GridColumnret_req_number.Visible = True
        Me.GridColumnret_req_number.VisibleIndex = 3
        '
        'GridColumnret_req_date
        '
        Me.GridColumnret_req_date.Caption = "Request Date"
        Me.GridColumnret_req_date.FieldName = "ret_req_date"
        Me.GridColumnret_req_date.Name = "GridColumnret_req_date"
        Me.GridColumnret_req_date.Visible = True
        Me.GridColumnret_req_date.VisibleIndex = 4
        '
        'GridColumncreated_date
        '
        Me.GridColumncreated_date.Caption = "Created Date"
        Me.GridColumncreated_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumncreated_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumncreated_date.FieldName = "created_date"
        Me.GridColumncreated_date.Name = "GridColumncreated_date"
        Me.GridColumncreated_date.Visible = True
        Me.GridColumncreated_date.VisibleIndex = 5
        '
        'GridColumncreated_by_name
        '
        Me.GridColumncreated_by_name.Caption = "Created By"
        Me.GridColumncreated_by_name.FieldName = "created_by_name"
        Me.GridColumncreated_by_name.Name = "GridColumncreated_by_name"
        Me.GridColumncreated_by_name.Visible = True
        Me.GridColumncreated_by_name.VisibleIndex = 6
        '
        'GridColumnupdated_date
        '
        Me.GridColumnupdated_date.Caption = "Updated Date"
        Me.GridColumnupdated_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumnupdated_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnupdated_date.FieldName = "updated_date"
        Me.GridColumnupdated_date.Name = "GridColumnupdated_date"
        Me.GridColumnupdated_date.Visible = True
        Me.GridColumnupdated_date.VisibleIndex = 7
        '
        'GridColumnupdated_by_name
        '
        Me.GridColumnupdated_by_name.Caption = "Updated By"
        Me.GridColumnupdated_by_name.FieldName = "updated_by_name"
        Me.GridColumnupdated_by_name.Name = "GridColumnupdated_by_name"
        Me.GridColumnupdated_by_name.Visible = True
        Me.GridColumnupdated_by_name.VisibleIndex = 8
        '
        'GridColumnawb_number
        '
        Me.GridColumnawb_number.Caption = "AWB"
        Me.GridColumnawb_number.FieldName = "awb_number"
        Me.GridColumnawb_number.Name = "GridColumnawb_number"
        '
        'GridColumnnote
        '
        Me.GridColumnnote.Caption = "Note"
        Me.GridColumnnote.FieldName = "note"
        Me.GridColumnnote.Name = "GridColumnnote"
        Me.GridColumnnote.Visible = True
        Me.GridColumnnote.VisibleIndex = 9
        '
        'GridColumnreport_status
        '
        Me.GridColumnreport_status.Caption = "Status"
        Me.GridColumnreport_status.FieldName = "report_status"
        Me.GridColumnreport_status.Name = "GridColumnreport_status"
        Me.GridColumnreport_status.Visible = True
        Me.GridColumnreport_status.VisibleIndex = 10
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.Label1)
        Me.PanelControl2.Controls.Add(Me.SBInputAWB)
        Me.PanelControl2.Controls.Add(Me.TEInputAWB)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1008, 49)
        Me.PanelControl2.TabIndex = 2
        Me.PanelControl2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "AWB"
        '
        'SBInputAWB
        '
        Me.SBInputAWB.Location = New System.Drawing.Point(257, 10)
        Me.SBInputAWB.Name = "SBInputAWB"
        Me.SBInputAWB.Size = New System.Drawing.Size(75, 23)
        Me.SBInputAWB.TabIndex = 1
        Me.SBInputAWB.Text = "Input AWB"
        '
        'TEInputAWB
        '
        Me.TEInputAWB.Location = New System.Drawing.Point(48, 12)
        Me.TEInputAWB.Name = "TEInputAWB"
        Me.TEInputAWB.Size = New System.Drawing.Size(203, 20)
        Me.TEInputAWB.TabIndex = 0
        '
        'FormOlStoreReturnInputAWB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 561)
        Me.Controls.Add(Me.GCRequest)
        Me.Controls.Add(Me.PanelControl2)
        Me.MinimizeBox = False
        Me.Name = "FormOlStoreReturnInputAWB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Return Centre"
        CType(Me.GCRequest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRequest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.TEInputAWB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCRequest As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRequest As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_ol_store_ret_req As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_comp_group_req As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_group_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_order_ol_shop_number_req As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnret_req_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnret_req_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_by_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnupdated_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnupdated_by_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnawb_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnreport_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBInputAWB As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEInputAWB As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label1 As Label
End Class
