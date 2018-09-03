<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormProdDemandRevNew
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProdDemandRevNew))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.SLESeason = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LESampleDivision = New DevExpress.XtraEditors.LookUpEdit()
        Me.GCProdDemand = New DevExpress.XtraGrid.GridControl()
        Me.GVProdDemand = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnProdDemand = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProdDemandNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIdReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRef = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPDDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDivision = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TxtProdDemandNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LESampleDivision.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCProdDemand, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProdDemand, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtProdDemandNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Controls.Add(Me.BtnOK)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 421)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(670, 43)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnOK
        '
        Me.BtnOK.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnOK.Image = CType(resources.GetObject("BtnOK.Image"), System.Drawing.Image)
        Me.BtnOK.Location = New System.Drawing.Point(593, 2)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(75, 39)
        Me.BtnOK.TabIndex = 1
        Me.BtnOK.Text = "OK"
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(510, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(83, 39)
        Me.BtnCancel.TabIndex = 2
        Me.BtnCancel.Text = "Cancel"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.LabelControl4)
        Me.PanelControl2.Controls.Add(Me.TxtProdDemandNumber)
        Me.PanelControl2.Controls.Add(Me.MENote)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 321)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(670, 100)
        Me.PanelControl2.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(21, 40)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Note"
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(87, 38)
        Me.MENote.Name = "MENote"
        Me.MENote.Size = New System.Drawing.Size(566, 46)
        Me.MENote.TabIndex = 2
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.BSearch)
        Me.PanelControl3.Controls.Add(Me.LESampleDivision)
        Me.PanelControl3.Controls.Add(Me.LabelControl3)
        Me.PanelControl3.Controls.Add(Me.SLESeason)
        Me.PanelControl3.Controls.Add(Me.LabelControl2)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(670, 44)
        Me.PanelControl3.TabIndex = 2
        '
        'SLESeason
        '
        Me.SLESeason.Location = New System.Drawing.Point(63, 11)
        Me.SLESeason.Name = "SLESeason"
        Me.SLESeason.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLESeason.Properties.Appearance.Options.UseFont = True
        Me.SLESeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESeason.Properties.ShowClearButton = False
        Me.SLESeason.Properties.View = Me.SearchLookUpEdit1View
        Me.SLESeason.Size = New System.Drawing.Size(146, 20)
        Me.SLESeason.TabIndex = 8907
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn6, Me.GridColumn8, Me.GridColumn3})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Id Season"
        Me.GridColumn6.FieldName = "id_season"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Season"
        Me.GridColumn8.FieldName = "season"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Range"
        Me.GridColumn3.FieldName = "range"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        '
        'BSearch
        '
        Me.BSearch.Location = New System.Drawing.Point(443, 9)
        Me.BSearch.Name = "BSearch"
        Me.BSearch.Size = New System.Drawing.Size(83, 23)
        Me.BSearch.TabIndex = 8906
        Me.BSearch.Text = "Search"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(21, 14)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl2.TabIndex = 8905
        Me.LabelControl2.Text = "Season"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(216, 14)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl3.TabIndex = 8908
        Me.LabelControl3.Text = "Division"
        '
        'LESampleDivision
        '
        Me.LESampleDivision.Location = New System.Drawing.Point(257, 11)
        Me.LESampleDivision.Name = "LESampleDivision"
        Me.LESampleDivision.Properties.Appearance.Options.UseTextOptions = True
        Me.LESampleDivision.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LESampleDivision.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LESampleDivision.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_code_detail", "ID Division", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("display_name", "Display Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code_detail_name", "Division")})
        Me.LESampleDivision.Properties.NullText = ""
        Me.LESampleDivision.Properties.ShowFooter = False
        Me.LESampleDivision.Size = New System.Drawing.Size(180, 20)
        Me.LESampleDivision.TabIndex = 8907
        '
        'GCProdDemand
        '
        Me.GCProdDemand.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProdDemand.Location = New System.Drawing.Point(0, 44)
        Me.GCProdDemand.MainView = Me.GVProdDemand
        Me.GCProdDemand.Name = "GCProdDemand"
        Me.GCProdDemand.Size = New System.Drawing.Size(670, 277)
        Me.GCProdDemand.TabIndex = 3
        Me.GCProdDemand.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProdDemand})
        '
        'GVProdDemand
        '
        Me.GVProdDemand.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnProdDemand, Me.GridColumnSeason, Me.GridColumnIdSeason, Me.ColIdReportStatus, Me.GridColumnProdDemandNumber, Me.ColReportStatus, Me.GridColumnRef, Me.GridColumnType, Me.GridColumnPDDate, Me.GridColumnDivision, Me.GridColumnPD})
        Me.GVProdDemand.GridControl = Me.GCProdDemand
        Me.GVProdDemand.Name = "GVProdDemand"
        Me.GVProdDemand.OptionsBehavior.Editable = False
        Me.GVProdDemand.OptionsFind.AlwaysVisible = True
        Me.GVProdDemand.OptionsView.ShowGroupPanel = False
        Me.GVProdDemand.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnProdDemand, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'GridColumnProdDemand
        '
        Me.GridColumnProdDemand.Caption = "ID"
        Me.GridColumnProdDemand.FieldName = "id_prod_demand"
        Me.GridColumnProdDemand.Name = "GridColumnProdDemand"
        '
        'GridColumnProdDemandNumber
        '
        Me.GridColumnProdDemandNumber.Caption = "Production Demand Number"
        Me.GridColumnProdDemandNumber.FieldName = "prod_demand_number"
        Me.GridColumnProdDemandNumber.Name = "GridColumnProdDemandNumber"
        Me.GridColumnProdDemandNumber.Visible = True
        Me.GridColumnProdDemandNumber.VisibleIndex = 0
        '
        'GridColumnSeason
        '
        Me.GridColumnSeason.Caption = "Season"
        Me.GridColumnSeason.FieldName = "season"
        Me.GridColumnSeason.FieldNameSortGroup = "id_season"
        Me.GridColumnSeason.Name = "GridColumnSeason"
        '
        'GridColumnIdSeason
        '
        Me.GridColumnIdSeason.Caption = "Id season"
        Me.GridColumnIdSeason.FieldName = "id_season"
        Me.GridColumnIdSeason.Name = "GridColumnIdSeason"
        '
        'ColIdReportStatus
        '
        Me.ColIdReportStatus.Caption = "Id Status"
        Me.ColIdReportStatus.FieldName = "id_report_status"
        Me.ColIdReportStatus.Name = "ColIdReportStatus"
        '
        'ColReportStatus
        '
        Me.ColReportStatus.Caption = "Status"
        Me.ColReportStatus.FieldName = "report_status"
        Me.ColReportStatus.Name = "ColReportStatus"
        Me.ColReportStatus.Visible = True
        Me.ColReportStatus.VisibleIndex = 3
        '
        'GridColumnRef
        '
        Me.GridColumnRef.Caption = "Reference"
        Me.GridColumnRef.FieldName = "prod_demand_number_ref"
        Me.GridColumnRef.Name = "GridColumnRef"
        '
        'GridColumnType
        '
        Me.GridColumnType.Caption = "Type"
        Me.GridColumnType.FieldName = "pd_type"
        Me.GridColumnType.Name = "GridColumnType"
        '
        'GridColumnPDDate
        '
        Me.GridColumnPDDate.Caption = "Created Date"
        Me.GridColumnPDDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnPDDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnPDDate.FieldName = "prod_demand_date"
        Me.GridColumnPDDate.Name = "GridColumnPDDate"
        Me.GridColumnPDDate.Visible = True
        Me.GridColumnPDDate.VisibleIndex = 2
        '
        'GridColumnDivision
        '
        Me.GridColumnDivision.Caption = "Division"
        Me.GridColumnDivision.FieldName = "division"
        Me.GridColumnDivision.Name = "GridColumnDivision"
        Me.GridColumnDivision.Visible = True
        Me.GridColumnDivision.VisibleIndex = 1
        '
        'GridColumnPD
        '
        Me.GridColumnPD.Caption = "Phase"
        Me.GridColumnPD.FieldName = "pd"
        Me.GridColumnPD.Name = "GridColumnPD"
        '
        'TxtProdDemandNumber
        '
        Me.TxtProdDemandNumber.Enabled = False
        Me.TxtProdDemandNumber.Location = New System.Drawing.Point(87, 12)
        Me.TxtProdDemandNumber.Name = "TxtProdDemandNumber"
        Me.TxtProdDemandNumber.Size = New System.Drawing.Size(566, 20)
        Me.TxtProdDemandNumber.TabIndex = 3
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(21, 15)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl4.TabIndex = 4
        Me.LabelControl4.Text = "Number"
        '
        'FormProdDemandRevNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(670, 464)
        Me.Controls.Add(Me.GCProdDemand)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProdDemandRevNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create New - PD Revision"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LESampleDivision.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCProdDemand, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProdDemand, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtProdDemandNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLESeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LESampleDivision As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtProdDemandNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GCProdDemand As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProdDemand As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnProdDemand As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProdDemandNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRef As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPDDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDivision As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPD As DevExpress.XtraGrid.Columns.GridColumn
End Class
