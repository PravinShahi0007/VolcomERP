<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPurcReqList
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
        Me.XTCPurcReq = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPurcReq = New DevExpress.XtraTab.XtraTabPage()
        Me.GCPurcReqNeedSubmit = New DevExpress.XtraGrid.GridControl()
        Me.GVPurcReqNeedSubmit = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.GCPurcReqHistorySubmit = New DevExpress.XtraGrid.GridControl()
        Me.GVPurcReqHistorySubmit = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BView = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEDepartement = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCPurcReq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCPurcReq.SuspendLayout()
        Me.XTPPurcReq.SuspendLayout()
        CType(Me.GCPurcReqNeedSubmit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPurcReqNeedSubmit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.GCPurcReqHistorySubmit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPurcReqHistorySubmit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEDepartement.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCPurcReq
        '
        Me.XTCPurcReq.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCPurcReq.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCPurcReq.Location = New System.Drawing.Point(0, 48)
        Me.XTCPurcReq.Name = "XTCPurcReq"
        Me.XTCPurcReq.SelectedTabPage = Me.XTPPurcReq
        Me.XTCPurcReq.Size = New System.Drawing.Size(946, 491)
        Me.XTCPurcReq.TabIndex = 0
        Me.XTCPurcReq.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPurcReq, Me.XtraTabPage2})
        '
        'XTPPurcReq
        '
        Me.XTPPurcReq.Controls.Add(Me.GCPurcReqNeedSubmit)
        Me.XTPPurcReq.Name = "XTPPurcReq"
        Me.XTPPurcReq.Size = New System.Drawing.Size(940, 463)
        Me.XTPPurcReq.Text = "List Need Submit"
        '
        'GCPurcReqNeedSubmit
        '
        Me.GCPurcReqNeedSubmit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPurcReqNeedSubmit.Location = New System.Drawing.Point(0, 0)
        Me.GCPurcReqNeedSubmit.MainView = Me.GVPurcReqNeedSubmit
        Me.GCPurcReqNeedSubmit.Name = "GCPurcReqNeedSubmit"
        Me.GCPurcReqNeedSubmit.Size = New System.Drawing.Size(940, 463)
        Me.GCPurcReqNeedSubmit.TabIndex = 1
        Me.GCPurcReqNeedSubmit.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPurcReqNeedSubmit})
        '
        'GVPurcReqNeedSubmit
        '
        Me.GVPurcReqNeedSubmit.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.GridColumn29, Me.GridColumn1, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn28})
        Me.GVPurcReqNeedSubmit.GridControl = Me.GCPurcReqNeedSubmit
        Me.GVPurcReqNeedSubmit.Name = "GVPurcReqNeedSubmit"
        Me.GVPurcReqNeedSubmit.OptionsBehavior.Editable = False
        Me.GVPurcReqNeedSubmit.OptionsBehavior.ReadOnly = True
        Me.GVPurcReqNeedSubmit.OptionsFind.AlwaysVisible = True
        Me.GVPurcReqNeedSubmit.OptionsView.ShowGroupPanel = False
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "id_purc_req"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "Requirement Date"
        Me.GridColumn29.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn29.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn29.FieldName = "requirement_date"
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.Visible = True
        Me.GridColumn29.VisibleIndex = 2
        Me.GridColumn29.Width = 101
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Request Number"
        Me.GridColumn1.FieldName = "purc_req_number"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 1
        Me.GridColumn1.Width = 206
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Date Created"
        Me.GridColumn3.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn3.FieldName = "date_created"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 3
        Me.GridColumn3.Width = 187
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Departement"
        Me.GridColumn4.FieldName = "departement"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 0
        Me.GridColumn4.Width = 183
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Created By"
        Me.GridColumn5.FieldName = "created_by"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 4
        Me.GridColumn5.Width = 172
        '
        'GridColumn28
        '
        Me.GridColumn28.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn28.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn28.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn28.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn28.Caption = "Status"
        Me.GridColumn28.FieldName = "report_status"
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.Visible = True
        Me.GridColumn28.VisibleIndex = 5
        Me.GridColumn28.Width = 73
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.GCPurcReqHistorySubmit)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(940, 463)
        Me.XtraTabPage2.Text = "History Submit"
        '
        'GCPurcReqHistorySubmit
        '
        Me.GCPurcReqHistorySubmit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPurcReqHistorySubmit.Location = New System.Drawing.Point(0, 0)
        Me.GCPurcReqHistorySubmit.MainView = Me.GVPurcReqHistorySubmit
        Me.GCPurcReqHistorySubmit.Name = "GCPurcReqHistorySubmit"
        Me.GCPurcReqHistorySubmit.Size = New System.Drawing.Size(940, 463)
        Me.GCPurcReqHistorySubmit.TabIndex = 2
        Me.GCPurcReqHistorySubmit.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPurcReqHistorySubmit})
        '
        'GVPurcReqHistorySubmit
        '
        Me.GVPurcReqHistorySubmit.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12})
        Me.GVPurcReqHistorySubmit.GridControl = Me.GCPurcReqHistorySubmit
        Me.GVPurcReqHistorySubmit.Name = "GVPurcReqHistorySubmit"
        Me.GVPurcReqHistorySubmit.OptionsBehavior.Editable = False
        Me.GVPurcReqHistorySubmit.OptionsBehavior.ReadOnly = True
        Me.GVPurcReqHistorySubmit.OptionsFind.AlwaysVisible = True
        Me.GVPurcReqHistorySubmit.OptionsView.ShowGroupPanel = False
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BView)
        Me.PanelControl1.Controls.Add(Me.SLEDepartement)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(946, 48)
        Me.PanelControl1.TabIndex = 0
        '
        'BView
        '
        Me.BView.Location = New System.Drawing.Point(269, 12)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(115, 23)
        Me.BView.TabIndex = 8913
        Me.BView.Text = "view request order"
        '
        'SLEDepartement
        '
        Me.SLEDepartement.Location = New System.Drawing.Point(86, 14)
        Me.SLEDepartement.Name = "SLEDepartement"
        Me.SLEDepartement.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEDepartement.Properties.View = Me.GridView3
        Me.SLEDepartement.Size = New System.Drawing.Size(177, 20)
        Me.SLEDepartement.TabIndex = 8912
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn13, Me.GridColumn14})
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "ID Departement"
        Me.GridColumn13.FieldName = "id_departement"
        Me.GridColumn13.Name = "GridColumn13"
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Departement"
        Me.GridColumn14.FieldName = "departement"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 0
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(17, 17)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl2.TabIndex = 8911
        Me.LabelControl2.Text = "Departement"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "id_purc_req"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Requirement Date"
        Me.GridColumn7.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn7.FieldName = "requirement_date"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 2
        Me.GridColumn7.Width = 101
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Request Number"
        Me.GridColumn8.FieldName = "purc_req_number"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 1
        Me.GridColumn8.Width = 206
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Date Created"
        Me.GridColumn9.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn9.FieldName = "date_created"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 3
        Me.GridColumn9.Width = 187
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Departement"
        Me.GridColumn10.FieldName = "departement"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 0
        Me.GridColumn10.Width = 183
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Created By"
        Me.GridColumn11.FieldName = "created_by"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 4
        Me.GridColumn11.Width = 172
        '
        'GridColumn12
        '
        Me.GridColumn12.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn12.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn12.Caption = "Status"
        Me.GridColumn12.FieldName = "report_status"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 5
        Me.GridColumn12.Width = 73
        '
        'FormPurcReqList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(946, 539)
        Me.Controls.Add(Me.XTCPurcReq)
        Me.Controls.Add(Me.PanelControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPurcReqList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "List Purchase Request"
        CType(Me.XTCPurcReq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCPurcReq.ResumeLayout(False)
        Me.XTPPurcReq.ResumeLayout(False)
        CType(Me.GCPurcReqNeedSubmit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPurcReqNeedSubmit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.GCPurcReqHistorySubmit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPurcReqHistorySubmit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLEDepartement.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCPurcReq As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPurcReq As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCPurcReqNeedSubmit As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPurcReqNeedSubmit As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCPurcReqHistorySubmit As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPurcReqHistorySubmit As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLEDepartement As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
End Class
