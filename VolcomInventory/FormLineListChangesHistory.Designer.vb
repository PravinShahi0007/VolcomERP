<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLineListChangesHistory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormLineListChangesHistory))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnlog_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnuser_modified = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnuser_created = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnreport_mark_type_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_report = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnreport_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnreport_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_design = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnclass = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncolor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsht = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.RepoLinkDoc = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.RepoLinkDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnClose)
        Me.PanelControl1.Controls.Add(Me.BtnPrint)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 513)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 48)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnClose
        '
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(624, 2)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(79, 44)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(703, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(79, 44)
        Me.BtnPrint.TabIndex = 0
        Me.BtnPrint.Text = "Print"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 47)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepoLinkDoc})
        Me.GCData.Size = New System.Drawing.Size(784, 466)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnlog_date, Me.GridColumnuser_modified, Me.GridColumnuser_created, Me.GridColumnreport_mark_type_name, Me.GridColumnid_report, Me.GridColumnreport_number, Me.GridColumnreport_date, Me.GridColumnid_design, Me.GridColumncode, Me.GridColumnclass, Me.GridColumnname, Me.GridColumncolor, Me.GridColumnsht, Me.GridColumnnote})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnlog_date
        '
        Me.GridColumnlog_date.Caption = "Changed On"
        Me.GridColumnlog_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GridColumnlog_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnlog_date.FieldName = "log_date"
        Me.GridColumnlog_date.Name = "GridColumnlog_date"
        Me.GridColumnlog_date.Visible = True
        Me.GridColumnlog_date.VisibleIndex = 0
        '
        'GridColumnuser_modified
        '
        Me.GridColumnuser_modified.Caption = "Changed By"
        Me.GridColumnuser_modified.FieldName = "user_modified"
        Me.GridColumnuser_modified.Name = "GridColumnuser_modified"
        Me.GridColumnuser_modified.Visible = True
        Me.GridColumnuser_modified.VisibleIndex = 1
        '
        'GridColumnuser_created
        '
        Me.GridColumnuser_created.Caption = "Created By"
        Me.GridColumnuser_created.FieldName = "user_created"
        Me.GridColumnuser_created.Name = "GridColumnuser_created"
        Me.GridColumnuser_created.Visible = True
        Me.GridColumnuser_created.VisibleIndex = 6
        Me.GridColumnuser_created.Width = 105
        '
        'GridColumnreport_mark_type_name
        '
        Me.GridColumnreport_mark_type_name.Caption = "Trans. Type"
        Me.GridColumnreport_mark_type_name.FieldName = "report_mark_type_name"
        Me.GridColumnreport_mark_type_name.Name = "GridColumnreport_mark_type_name"
        Me.GridColumnreport_mark_type_name.Visible = True
        Me.GridColumnreport_mark_type_name.VisibleIndex = 3
        '
        'GridColumnid_report
        '
        Me.GridColumnid_report.Caption = "id_report"
        Me.GridColumnid_report.FieldName = "id_report"
        Me.GridColumnid_report.Name = "GridColumnid_report"
        '
        'GridColumnreport_number
        '
        Me.GridColumnreport_number.Caption = "Document No."
        Me.GridColumnreport_number.ColumnEdit = Me.RepoLinkDoc
        Me.GridColumnreport_number.FieldName = "report_number"
        Me.GridColumnreport_number.Name = "GridColumnreport_number"
        Me.GridColumnreport_number.Visible = True
        Me.GridColumnreport_number.VisibleIndex = 4
        Me.GridColumnreport_number.Width = 94
        '
        'GridColumnreport_date
        '
        Me.GridColumnreport_date.Caption = "Document Date"
        Me.GridColumnreport_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnreport_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnreport_date.FieldName = "report_date"
        Me.GridColumnreport_date.Name = "GridColumnreport_date"
        Me.GridColumnreport_date.Visible = True
        Me.GridColumnreport_date.VisibleIndex = 5
        Me.GridColumnreport_date.Width = 99
        '
        'GridColumnid_design
        '
        Me.GridColumnid_design.Caption = "id_design"
        Me.GridColumnid_design.FieldName = "id_design"
        Me.GridColumnid_design.Name = "GridColumnid_design"
        '
        'GridColumncode
        '
        Me.GridColumncode.Caption = "Code"
        Me.GridColumncode.FieldName = "code"
        Me.GridColumncode.Name = "GridColumncode"
        Me.GridColumncode.Visible = True
        Me.GridColumncode.VisibleIndex = 7
        '
        'GridColumnclass
        '
        Me.GridColumnclass.Caption = "Class"
        Me.GridColumnclass.FieldName = "class"
        Me.GridColumnclass.Name = "GridColumnclass"
        Me.GridColumnclass.Visible = True
        Me.GridColumnclass.VisibleIndex = 8
        '
        'GridColumnname
        '
        Me.GridColumnname.Caption = "Description"
        Me.GridColumnname.FieldName = "name"
        Me.GridColumnname.Name = "GridColumnname"
        Me.GridColumnname.Visible = True
        Me.GridColumnname.VisibleIndex = 9
        '
        'GridColumncolor
        '
        Me.GridColumncolor.Caption = "Color"
        Me.GridColumncolor.FieldName = "color"
        Me.GridColumncolor.Name = "GridColumncolor"
        Me.GridColumncolor.Visible = True
        Me.GridColumncolor.VisibleIndex = 10
        '
        'GridColumnsht
        '
        Me.GridColumnsht.Caption = "Silhouette"
        Me.GridColumnsht.FieldName = "sht"
        Me.GridColumnsht.Name = "GridColumnsht"
        Me.GridColumnsht.Visible = True
        Me.GridColumnsht.VisibleIndex = 11
        '
        'GridColumnnote
        '
        Me.GridColumnnote.Caption = "Changes Note"
        Me.GridColumnnote.FieldName = "note"
        Me.GridColumnnote.Name = "GridColumnnote"
        Me.GridColumnnote.Visible = True
        Me.GridColumnnote.VisibleIndex = 2
        Me.GridColumnnote.Width = 106
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(198, 13)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Size = New System.Drawing.Size(138, 20)
        Me.DEUntil.TabIndex = 8899
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(52, 13)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Size = New System.Drawing.Size(111, 20)
        Me.DEFrom.TabIndex = 8898
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(169, 16)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl2.TabIndex = 8897
        Me.LabelControl2.Text = "Until"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(14, 16)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl3.TabIndex = 8896
        Me.LabelControl3.Text = "From"
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(342, 11)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(75, 23)
        Me.BtnView.TabIndex = 8900
        Me.BtnView.Text = "View"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BtnView)
        Me.PanelControl2.Controls.Add(Me.LabelControl3)
        Me.PanelControl2.Controls.Add(Me.DEUntil)
        Me.PanelControl2.Controls.Add(Me.LabelControl2)
        Me.PanelControl2.Controls.Add(Me.DEFrom)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(784, 47)
        Me.PanelControl2.TabIndex = 8901
        '
        'RepoLinkDoc
        '
        Me.RepoLinkDoc.AutoHeight = False
        Me.RepoLinkDoc.Name = "RepoLinkDoc"
        '
        'FormLineListChangesHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormLineListChangesHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Line List - Changes History"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.RepoLinkDoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GridColumnlog_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnuser_modified As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnuser_created As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnreport_mark_type_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_report As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnreport_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnreport_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_design As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnclass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncolor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsht As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoLinkDoc As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
End Class
