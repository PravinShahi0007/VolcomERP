<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormItemDel
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
        Me.components = New System.ComponentModel.Container()
        Me.XTCDel = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPRequest = New DevExpress.XtraTab.XtraTabPage()
        Me.GCRequest = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewDetailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVRequest = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdReq = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRecNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDeptReq = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreateddateReq = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedByReq = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPDel = New DevExpress.XtraTab.XtraTabPage()
        Me.GCDelivery = New DevExpress.XtraGrid.GridControl()
        Me.GVDelivery = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.XTCDel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCDel.SuspendLayout()
        Me.XTPRequest.SuspendLayout()
        CType(Me.GCRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GVRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPDel.SuspendLayout()
        CType(Me.GCDelivery, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDelivery, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCDel
        '
        Me.XTCDel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCDel.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCDel.Location = New System.Drawing.Point(0, 0)
        Me.XTCDel.Name = "XTCDel"
        Me.XTCDel.SelectedTabPage = Me.XTPRequest
        Me.XTCDel.Size = New System.Drawing.Size(711, 438)
        Me.XTCDel.TabIndex = 0
        Me.XTCDel.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPRequest, Me.XTPDel})
        '
        'XTPRequest
        '
        Me.XTPRequest.Controls.Add(Me.GCRequest)
        Me.XTPRequest.Name = "XTPRequest"
        Me.XTPRequest.Size = New System.Drawing.Size(705, 410)
        Me.XTPRequest.Text = "Request"
        '
        'GCRequest
        '
        Me.GCRequest.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GCRequest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRequest.Location = New System.Drawing.Point(0, 0)
        Me.GCRequest.MainView = Me.GVRequest
        Me.GCRequest.Name = "GCRequest"
        Me.GCRequest.Size = New System.Drawing.Size(705, 410)
        Me.GCRequest.TabIndex = 0
        Me.GCRequest.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRequest})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewDetailToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(153, 48)
        '
        'ViewDetailToolStripMenuItem
        '
        Me.ViewDetailToolStripMenuItem.Name = "ViewDetailToolStripMenuItem"
        Me.ViewDetailToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ViewDetailToolStripMenuItem.Text = "view detail"
        '
        'GVRequest
        '
        Me.GVRequest.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdReq, Me.GridColumnRecNumber, Me.GridColumnDeptReq, Me.GridColumnCreateddateReq, Me.GridColumnCreatedByReq})
        Me.GVRequest.GridControl = Me.GCRequest
        Me.GVRequest.Name = "GVRequest"
        Me.GVRequest.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVRequest.OptionsBehavior.Editable = False
        Me.GVRequest.OptionsCustomization.AllowSort = False
        Me.GVRequest.OptionsFind.AlwaysVisible = True
        Me.GVRequest.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdReq
        '
        Me.GridColumnIdReq.Caption = "Id"
        Me.GridColumnIdReq.FieldName = "id_item_req"
        Me.GridColumnIdReq.Name = "GridColumnIdReq"
        '
        'GridColumnRecNumber
        '
        Me.GridColumnRecNumber.Caption = "Number"
        Me.GridColumnRecNumber.FieldName = "number"
        Me.GridColumnRecNumber.Name = "GridColumnRecNumber"
        Me.GridColumnRecNumber.Visible = True
        Me.GridColumnRecNumber.VisibleIndex = 0
        '
        'GridColumnDeptReq
        '
        Me.GridColumnDeptReq.Caption = "Department"
        Me.GridColumnDeptReq.FieldName = "departement"
        Me.GridColumnDeptReq.Name = "GridColumnDeptReq"
        Me.GridColumnDeptReq.Visible = True
        Me.GridColumnDeptReq.VisibleIndex = 2
        '
        'GridColumnCreateddateReq
        '
        Me.GridColumnCreateddateReq.Caption = "Created Date"
        Me.GridColumnCreateddateReq.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumnCreateddateReq.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCreateddateReq.FieldName = "created_date"
        Me.GridColumnCreateddateReq.Name = "GridColumnCreateddateReq"
        Me.GridColumnCreateddateReq.Visible = True
        Me.GridColumnCreateddateReq.VisibleIndex = 1
        '
        'GridColumnCreatedByReq
        '
        Me.GridColumnCreatedByReq.Caption = "Request by"
        Me.GridColumnCreatedByReq.FieldName = "created_by_name"
        Me.GridColumnCreatedByReq.Name = "GridColumnCreatedByReq"
        Me.GridColumnCreatedByReq.Visible = True
        Me.GridColumnCreatedByReq.VisibleIndex = 3
        '
        'XTPDel
        '
        Me.XTPDel.Controls.Add(Me.GCDelivery)
        Me.XTPDel.Name = "XTPDel"
        Me.XTPDel.Size = New System.Drawing.Size(705, 410)
        Me.XTPDel.Text = "Delivery List"
        '
        'GCDelivery
        '
        Me.GCDelivery.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDelivery.Location = New System.Drawing.Point(0, 0)
        Me.GCDelivery.MainView = Me.GVDelivery
        Me.GCDelivery.Name = "GCDelivery"
        Me.GCDelivery.Size = New System.Drawing.Size(705, 410)
        Me.GCDelivery.TabIndex = 1
        Me.GCDelivery.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDelivery})
        '
        'GVDelivery
        '
        Me.GVDelivery.GridControl = Me.GCDelivery
        Me.GVDelivery.Name = "GVDelivery"
        Me.GVDelivery.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVDelivery.OptionsBehavior.Editable = False
        Me.GVDelivery.OptionsFind.AlwaysVisible = True
        Me.GVDelivery.OptionsView.ShowGroupPanel = False
        '
        'FormItemDel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(711, 438)
        Me.Controls.Add(Me.XTCDel)
        Me.MinimizeBox = False
        Me.Name = "FormItemDel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delivery"
        CType(Me.XTCDel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCDel.ResumeLayout(False)
        Me.XTPRequest.ResumeLayout(False)
        CType(Me.GCRequest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GVRequest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPDel.ResumeLayout(False)
        CType(Me.GCDelivery, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDelivery, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCDel As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPRequest As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPDel As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCRequest As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRequest As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCDelivery As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDelivery As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ViewDetailToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GridColumnIdReq As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRecNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDeptReq As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreateddateReq As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedByReq As DevExpress.XtraGrid.Columns.GridColumn
End Class
