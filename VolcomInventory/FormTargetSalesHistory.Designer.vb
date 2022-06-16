<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTargetSalesHistory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormTargetSalesHistory))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumnid_b_revenue_propose = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnyear = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnproposal_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_user = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoLinkNo = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoLinkNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnPrint)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(591, 49)
        Me.PanelControl1.TabIndex = 0
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 49)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepoLinkNo})
        Me.GCData.Size = New System.Drawing.Size(591, 347)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_b_revenue_propose, Me.GridColumnnumber, Me.GridColumnyear, Me.GridColumnproposal_type, Me.GridColumntotal, Me.GridColumncreated_date, Me.GridColumncreated_user})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(493, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(96, 45)
        Me.BtnPrint.TabIndex = 0
        Me.BtnPrint.Text = "Print List"
        '
        'GridColumnid_b_revenue_propose
        '
        Me.GridColumnid_b_revenue_propose.Caption = "id_b_revenue_propose"
        Me.GridColumnid_b_revenue_propose.FieldName = "id_b_revenue_propose"
        Me.GridColumnid_b_revenue_propose.Name = "GridColumnid_b_revenue_propose"
        Me.GridColumnid_b_revenue_propose.OptionsColumn.AllowEdit = False
        '
        'GridColumnnumber
        '
        Me.GridColumnnumber.Caption = "Number"
        Me.GridColumnnumber.ColumnEdit = Me.RepoLinkNo
        Me.GridColumnnumber.FieldName = "number"
        Me.GridColumnnumber.Name = "GridColumnnumber"
        Me.GridColumnnumber.Visible = True
        Me.GridColumnnumber.VisibleIndex = 0
        '
        'GridColumnyear
        '
        Me.GridColumnyear.Caption = "Year"
        Me.GridColumnyear.FieldName = "year"
        Me.GridColumnyear.Name = "GridColumnyear"
        Me.GridColumnyear.OptionsColumn.AllowEdit = False
        Me.GridColumnyear.Visible = True
        Me.GridColumnyear.VisibleIndex = 1
        '
        'GridColumnproposal_type
        '
        Me.GridColumnproposal_type.Caption = "Type"
        Me.GridColumnproposal_type.FieldName = "proposal_type"
        Me.GridColumnproposal_type.Name = "GridColumnproposal_type"
        Me.GridColumnproposal_type.OptionsColumn.AllowEdit = False
        Me.GridColumnproposal_type.Visible = True
        Me.GridColumnproposal_type.VisibleIndex = 2
        '
        'GridColumntotal
        '
        Me.GridColumntotal.Caption = "Total Propose"
        Me.GridColumntotal.DisplayFormat.FormatString = "N0"
        Me.GridColumntotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal.FieldName = "total"
        Me.GridColumntotal.Name = "GridColumntotal"
        Me.GridColumntotal.OptionsColumn.AllowEdit = False
        '
        'GridColumncreated_date
        '
        Me.GridColumncreated_date.Caption = "Created Date"
        Me.GridColumncreated_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumncreated_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumncreated_date.FieldName = "created_date"
        Me.GridColumncreated_date.Name = "GridColumncreated_date"
        Me.GridColumncreated_date.OptionsColumn.AllowEdit = False
        Me.GridColumncreated_date.Visible = True
        Me.GridColumncreated_date.VisibleIndex = 3
        '
        'GridColumncreated_user
        '
        Me.GridColumncreated_user.Caption = "Created By"
        Me.GridColumncreated_user.FieldName = "created_user"
        Me.GridColumncreated_user.Name = "GridColumncreated_user"
        Me.GridColumncreated_user.OptionsColumn.AllowEdit = False
        Me.GridColumncreated_user.Visible = True
        Me.GridColumncreated_user.VisibleIndex = 4
        '
        'RepoLinkNo
        '
        Me.RepoLinkNo.AutoHeight = False
        Me.RepoLinkNo.Name = "RepoLinkNo"
        '
        'FormTargetSalesHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(591, 396)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormTargetSalesHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Changes History"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoLinkNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnid_b_revenue_propose As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoLinkNo As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents GridColumnyear As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnproposal_type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_user As DevExpress.XtraGrid.Columns.GridColumn
End Class
