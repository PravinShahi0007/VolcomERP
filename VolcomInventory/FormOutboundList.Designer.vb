<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormOutboundList
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.XTCOutbound = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPending = New DevExpress.XtraTab.XtraTabPage()
        Me.GCOutbound = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewDocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVOutbound = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.TEOutboundNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPHistory = New DevExpress.XtraTab.XtraTabPage()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCOutbound, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCOutbound.SuspendLayout()
        Me.XTPPending.SuspendLayout()
        CType(Me.GCOutbound, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GVOutbound, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TEOutboundNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPHistory.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCOutbound
        '
        Me.XTCOutbound.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCOutbound.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCOutbound.Location = New System.Drawing.Point(0, 0)
        Me.XTCOutbound.Name = "XTCOutbound"
        Me.XTCOutbound.SelectedTabPage = Me.XTPPending
        Me.XTCOutbound.Size = New System.Drawing.Size(916, 522)
        Me.XTCOutbound.TabIndex = 0
        Me.XTCOutbound.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPending, Me.XTPHistory})
        '
        'XTPPending
        '
        Me.XTPPending.Controls.Add(Me.GCOutbound)
        Me.XTPPending.Controls.Add(Me.BRefresh)
        Me.XTPPending.Controls.Add(Me.PanelControl1)
        Me.XTPPending.Name = "XTPPending"
        Me.XTPPending.Size = New System.Drawing.Size(910, 494)
        Me.XTPPending.Text = "Pending Outbound"
        '
        'GCOutbound
        '
        Me.GCOutbound.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GCOutbound.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCOutbound.Location = New System.Drawing.Point(0, 46)
        Me.GCOutbound.MainView = Me.GVOutbound
        Me.GCOutbound.Name = "GCOutbound"
        Me.GCOutbound.Size = New System.Drawing.Size(910, 415)
        Me.GCOutbound.TabIndex = 1
        Me.GCOutbound.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVOutbound})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewDocumentToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(100, 26)
        '
        'ViewDocumentToolStripMenuItem
        '
        Me.ViewDocumentToolStripMenuItem.Name = "ViewDocumentToolStripMenuItem"
        Me.ViewDocumentToolStripMenuItem.Size = New System.Drawing.Size(99, 22)
        Me.ViewDocumentToolStripMenuItem.Text = "Print"
        '
        'GVOutbound
        '
        Me.GVOutbound.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn4, Me.GridColumn6, Me.GridColumn5, Me.GridColumn3})
        Me.GVOutbound.GridControl = Me.GCOutbound
        Me.GVOutbound.Name = "GVOutbound"
        Me.GVOutbound.OptionsBehavior.Editable = False
        Me.GVOutbound.OptionsBehavior.ReadOnly = True
        Me.GVOutbound.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Outbound Number"
        Me.GridColumn1.FieldName = "ol_number"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 1
        Me.GridColumn1.Width = 98
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Store"
        Me.GridColumn2.FieldName = "comp_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 257
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Sub District"
        Me.GridColumn4.FieldName = "sub_district"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        Me.GridColumn4.Width = 327
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Qty"
        Me.GridColumn3.FieldName = "qty"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 5
        Me.GridColumn3.Width = 132
        '
        'BRefresh
        '
        Me.BRefresh.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BRefresh.Location = New System.Drawing.Point(0, 461)
        Me.BRefresh.Name = "BRefresh"
        Me.BRefresh.Size = New System.Drawing.Size(910, 33)
        Me.BRefresh.TabIndex = 2
        Me.BRefresh.Text = "Refresh"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.TEOutboundNumber)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(910, 46)
        Me.PanelControl1.TabIndex = 0
        '
        'TEOutboundNumber
        '
        Me.TEOutboundNumber.Location = New System.Drawing.Point(150, 9)
        Me.TEOutboundNumber.Name = "TEOutboundNumber"
        Me.TEOutboundNumber.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.TEOutboundNumber.Properties.Appearance.Options.UseFont = True
        Me.TEOutboundNumber.Size = New System.Drawing.Size(334, 28)
        Me.TEOutboundNumber.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.LabelControl1.Location = New System.Drawing.Point(11, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(133, 21)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Outbound Number"
        '
        'XTPHistory
        '
        Me.XTPHistory.Controls.Add(Me.PanelControl2)
        Me.XTPHistory.Name = "XTPHistory"
        Me.XTPHistory.PageVisible = False
        Me.XTPHistory.Size = New System.Drawing.Size(910, 494)
        Me.XTPHistory.Text = "History"
        '
        'PanelControl2
        '
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(910, 46)
        Me.PanelControl2.TabIndex = 1
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Online Order Number"
        Me.GridColumn5.FieldName = "online_order_number"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 4
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Delivery Number"
        Me.GridColumn6.FieldName = "sdo_number"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 3
        '
        'FormOutboundList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(916, 522)
        Me.Controls.Add(Me.XTCOutbound)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormOutboundList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Outbound Number List"
        CType(Me.XTCOutbound, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCOutbound.ResumeLayout(False)
        Me.XTPPending.ResumeLayout(False)
        CType(Me.GCOutbound, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GVOutbound, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.TEOutboundNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPHistory.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCOutbound As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPending As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPHistory As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCOutbound As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVOutbound As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TEOutboundNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ViewDocumentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
End Class
