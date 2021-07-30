<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDelayPaymentInv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDelayPaymentInv))
        Me.PanelControlNav = New DevExpress.XtraEditors.PanelControl()
        Me.BView = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEStoreGroup = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_comp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_propose_delay_payment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_by = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_by_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnupdated_by = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndue_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnreport_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnis_submit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumngroup = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNav.SuspendLayout()
        CType(Me.SLEStoreGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControlNav
        '
        Me.PanelControlNav.Controls.Add(Me.BView)
        Me.PanelControlNav.Controls.Add(Me.SLEStoreGroup)
        Me.PanelControlNav.Controls.Add(Me.LabelControl1)
        Me.PanelControlNav.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlNav.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlNav.Name = "PanelControlNav"
        Me.PanelControlNav.Size = New System.Drawing.Size(638, 50)
        Me.PanelControlNav.TabIndex = 1
        '
        'BView
        '
        Me.BView.Image = CType(resources.GetObject("BView.Image"), System.Drawing.Image)
        Me.BView.Location = New System.Drawing.Point(227, 15)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(60, 20)
        Me.BView.TabIndex = 8925
        Me.BView.Text = "View"
        '
        'SLEStoreGroup
        '
        Me.SLEStoreGroup.Location = New System.Drawing.Point(76, 15)
        Me.SLEStoreGroup.Name = "SLEStoreGroup"
        Me.SLEStoreGroup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEStoreGroup.Properties.View = Me.GridView3
        Me.SLEStoreGroup.Size = New System.Drawing.Size(145, 20)
        Me.SLEStoreGroup.TabIndex = 8924
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_comp_group, Me.GridColumncomp_group, Me.GridColumndescription})
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_comp_group
        '
        Me.GridColumnid_comp_group.Caption = "id_comp_group"
        Me.GridColumnid_comp_group.FieldName = "id_comp_group"
        Me.GridColumnid_comp_group.Name = "GridColumnid_comp_group"
        '
        'GridColumncomp_group
        '
        Me.GridColumncomp_group.Caption = "Group"
        Me.GridColumncomp_group.FieldName = "comp_group"
        Me.GridColumncomp_group.Name = "GridColumncomp_group"
        Me.GridColumncomp_group.Visible = True
        Me.GridColumncomp_group.VisibleIndex = 0
        '
        'GridColumndescription
        '
        Me.GridColumndescription.Caption = "Description"
        Me.GridColumndescription.FieldName = "description"
        Me.GridColumndescription.Name = "GridColumndescription"
        Me.GridColumndescription.Visible = True
        Me.GridColumndescription.VisibleIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 18)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Store Group"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 50)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(638, 382)
        Me.GCData.TabIndex = 2
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_propose_delay_payment, Me.GridColumnnumber, Me.GridColumncreated_date, Me.GridColumncreated_by, Me.GridColumncreated_by_name, Me.GridColumnupdated_by, Me.GridColumndue_date, Me.GridColumnnote, Me.GridColumnreport_status, Me.GridColumnis_submit, Me.GridColumn1, Me.GridColumngroup})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_propose_delay_payment
        '
        Me.GridColumnid_propose_delay_payment.Caption = "id_delay_payment"
        Me.GridColumnid_propose_delay_payment.FieldName = "id_propose_delay_payment"
        Me.GridColumnid_propose_delay_payment.Name = "GridColumnid_propose_delay_payment"
        '
        'GridColumnnumber
        '
        Me.GridColumnnumber.Caption = "Number"
        Me.GridColumnnumber.FieldName = "number"
        Me.GridColumnnumber.Name = "GridColumnnumber"
        Me.GridColumnnumber.Visible = True
        Me.GridColumnnumber.VisibleIndex = 0
        '
        'GridColumncreated_date
        '
        Me.GridColumncreated_date.Caption = "Created Date"
        Me.GridColumncreated_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GridColumncreated_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumncreated_date.FieldName = "created_date"
        Me.GridColumncreated_date.Name = "GridColumncreated_date"
        Me.GridColumncreated_date.Visible = True
        Me.GridColumncreated_date.VisibleIndex = 2
        '
        'GridColumncreated_by
        '
        Me.GridColumncreated_by.Caption = "Id Created By"
        Me.GridColumncreated_by.FieldName = "created_by"
        Me.GridColumncreated_by.Name = "GridColumncreated_by"
        '
        'GridColumncreated_by_name
        '
        Me.GridColumncreated_by_name.Caption = "Created By"
        Me.GridColumncreated_by_name.FieldName = "created_by_name"
        Me.GridColumncreated_by_name.Name = "GridColumncreated_by_name"
        Me.GridColumncreated_by_name.Visible = True
        Me.GridColumncreated_by_name.VisibleIndex = 4
        '
        'GridColumnupdated_by
        '
        Me.GridColumnupdated_by.Caption = "updated_by"
        Me.GridColumnupdated_by.FieldName = "updated_by"
        Me.GridColumnupdated_by.Name = "GridColumnupdated_by"
        '
        'GridColumndue_date
        '
        Me.GridColumndue_date.Caption = "Payment Date Est. "
        Me.GridColumndue_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumndue_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumndue_date.FieldName = "due_date"
        Me.GridColumndue_date.Name = "GridColumndue_date"
        Me.GridColumndue_date.Visible = True
        Me.GridColumndue_date.VisibleIndex = 3
        Me.GridColumndue_date.Width = 125
        '
        'GridColumnnote
        '
        Me.GridColumnnote.Caption = "Note"
        Me.GridColumnnote.FieldName = "note"
        Me.GridColumnnote.Name = "GridColumnnote"
        Me.GridColumnnote.Visible = True
        Me.GridColumnnote.VisibleIndex = 5
        '
        'GridColumnreport_status
        '
        Me.GridColumnreport_status.Caption = "Status"
        Me.GridColumnreport_status.FieldName = "report_status"
        Me.GridColumnreport_status.Name = "GridColumnreport_status"
        Me.GridColumnreport_status.Visible = True
        Me.GridColumnreport_status.VisibleIndex = 6
        '
        'GridColumnis_submit
        '
        Me.GridColumnis_submit.Caption = "is_submit"
        Me.GridColumnis_submit.FieldName = "is_submit"
        Me.GridColumnis_submit.Name = "GridColumnis_submit"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "id_comp_group"
        Me.GridColumn1.FieldName = "id_comp_group"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumngroup
        '
        Me.GridColumngroup.Caption = "Store Group"
        Me.GridColumngroup.FieldName = "group"
        Me.GridColumngroup.Name = "GridColumngroup"
        Me.GridColumngroup.Visible = True
        Me.GridColumngroup.VisibleIndex = 1
        '
        'FormDelayPaymentInv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(638, 432)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControlNav)
        Me.Name = "FormDelayPaymentInv"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pengajuan Penundaan Pembayaran"
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNav.ResumeLayout(False)
        Me.PanelControlNav.PerformLayout()
        CType(Me.SLEStoreGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControlNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLEStoreGroup As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_comp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_propose_delay_payment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_by As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_by_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnupdated_by As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndue_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnreport_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnis_submit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumngroup As DevExpress.XtraGrid.Columns.GridColumn
End Class
