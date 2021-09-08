<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPriceMKDViosHist
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
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GCProposal = New DevExpress.XtraGrid.GridControl()
        Me.GVProposal = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_report = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnreport_mark_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumneff_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnbtn_detail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoBtnDetail = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.GCDetail = New DevExpress.XtraGrid.GridControl()
        Me.GVDetail = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnnumberdet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumneffective_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnclass = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsht_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsync_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsync_note = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GCProposal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProposal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoBtnDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GroupControl1)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GroupControl2)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(649, 435)
        Me.SplitContainerControl1.SplitterPosition = 186
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.GCProposal)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(649, 186)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Proposal List"
        '
        'GCProposal
        '
        Me.GCProposal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProposal.Location = New System.Drawing.Point(20, 2)
        Me.GCProposal.MainView = Me.GVProposal
        Me.GCProposal.Name = "GCProposal"
        Me.GCProposal.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepoBtnDetail})
        Me.GCProposal.Size = New System.Drawing.Size(627, 182)
        Me.GCProposal.TabIndex = 0
        Me.GCProposal.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProposal})
        '
        'GVProposal
        '
        Me.GVProposal.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_report, Me.GridColumnreport_mark_type, Me.GridColumnnumber, Me.GridColumneff_date, Me.GridColumnbtn_detail})
        Me.GVProposal.GridControl = Me.GCProposal
        Me.GVProposal.Name = "GVProposal"
        Me.GVProposal.OptionsFind.AlwaysVisible = True
        Me.GVProposal.OptionsView.ColumnAutoWidth = False
        Me.GVProposal.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_report
        '
        Me.GridColumnid_report.Caption = "id_report"
        Me.GridColumnid_report.FieldName = "id_report"
        Me.GridColumnid_report.Name = "GridColumnid_report"
        Me.GridColumnid_report.OptionsColumn.AllowEdit = False
        '
        'GridColumnreport_mark_type
        '
        Me.GridColumnreport_mark_type.Caption = "report_mark_type"
        Me.GridColumnreport_mark_type.FieldName = "report_mark_type"
        Me.GridColumnreport_mark_type.Name = "GridColumnreport_mark_type"
        Me.GridColumnreport_mark_type.OptionsColumn.AllowEdit = False
        '
        'GridColumnnumber
        '
        Me.GridColumnnumber.Caption = "Number"
        Me.GridColumnnumber.FieldName = "propose_no"
        Me.GridColumnnumber.Name = "GridColumnnumber"
        Me.GridColumnnumber.OptionsColumn.AllowEdit = False
        Me.GridColumnnumber.Visible = True
        Me.GridColumnnumber.VisibleIndex = 0
        '
        'GridColumneff_date
        '
        Me.GridColumneff_date.Caption = "Effective Date"
        Me.GridColumneff_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumneff_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumneff_date.FieldName = "eff_date"
        Me.GridColumneff_date.Name = "GridColumneff_date"
        Me.GridColumneff_date.OptionsColumn.AllowEdit = False
        Me.GridColumneff_date.Visible = True
        Me.GridColumneff_date.VisibleIndex = 1
        '
        'GridColumnbtn_detail
        '
        Me.GridColumnbtn_detail.Caption = "  "
        Me.GridColumnbtn_detail.ColumnEdit = Me.RepoBtnDetail
        Me.GridColumnbtn_detail.FieldName = "btn_detail"
        Me.GridColumnbtn_detail.Name = "GridColumnbtn_detail"
        Me.GridColumnbtn_detail.Visible = True
        Me.GridColumnbtn_detail.VisibleIndex = 2
        '
        'RepoBtnDetail
        '
        Me.RepoBtnDetail.AutoHeight = False
        Me.RepoBtnDetail.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        SerializableAppearanceObject1.BackColor = System.Drawing.SystemColors.Highlight
        SerializableAppearanceObject1.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SerializableAppearanceObject1.ForeColor = System.Drawing.Color.White
        SerializableAppearanceObject1.Options.UseBackColor = True
        SerializableAppearanceObject1.Options.UseFont = True
        SerializableAppearanceObject1.Options.UseForeColor = True
        Me.RepoBtnDetail.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Detail Sync", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.RepoBtnDetail.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.RepoBtnDetail.Name = "RepoBtnDetail"
        Me.RepoBtnDetail.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'GroupControl2
        '
        Me.GroupControl2.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl2.Controls.Add(Me.GCDetail)
        Me.GroupControl2.Controls.Add(Me.BtnPrint)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(649, 244)
        Me.GroupControl2.TabIndex = 1
        Me.GroupControl2.Text = "Detail Sync"
        '
        'GCDetail
        '
        Me.GCDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDetail.Location = New System.Drawing.Point(20, 25)
        Me.GCDetail.MainView = Me.GVDetail
        Me.GCDetail.Name = "GCDetail"
        Me.GCDetail.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1})
        Me.GCDetail.Size = New System.Drawing.Size(627, 217)
        Me.GCDetail.TabIndex = 1
        Me.GCDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDetail})
        '
        'GVDetail
        '
        Me.GVDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnnumberdet, Me.GridColumneffective_date, Me.GridColumncode, Me.GridColumnclass, Me.GridColumnname, Me.GridColumnsht_name, Me.GridColumnsize, Me.GridColumnsync_date, Me.GridColumnsync_note})
        Me.GVDetail.GridControl = Me.GCDetail
        Me.GVDetail.Name = "GVDetail"
        Me.GVDetail.OptionsBehavior.Editable = False
        Me.GVDetail.OptionsFind.AlwaysVisible = True
        Me.GVDetail.OptionsView.ColumnAutoWidth = False
        Me.GVDetail.OptionsView.ShowGroupPanel = False
        '
        'GridColumnnumberdet
        '
        Me.GridColumnnumberdet.Caption = "Propose No."
        Me.GridColumnnumberdet.FieldName = "number"
        Me.GridColumnnumberdet.Name = "GridColumnnumberdet"
        Me.GridColumnnumberdet.Visible = True
        Me.GridColumnnumberdet.VisibleIndex = 0
        '
        'GridColumneffective_date
        '
        Me.GridColumneffective_date.Caption = "Effective Date"
        Me.GridColumneffective_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumneffective_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumneffective_date.FieldName = "effective_date"
        Me.GridColumneffective_date.Name = "GridColumneffective_date"
        Me.GridColumneffective_date.Visible = True
        Me.GridColumneffective_date.VisibleIndex = 1
        '
        'GridColumncode
        '
        Me.GridColumncode.Caption = "Code"
        Me.GridColumncode.FieldName = "code"
        Me.GridColumncode.Name = "GridColumncode"
        Me.GridColumncode.Visible = True
        Me.GridColumncode.VisibleIndex = 2
        '
        'GridColumnclass
        '
        Me.GridColumnclass.Caption = "Class"
        Me.GridColumnclass.FieldName = "class"
        Me.GridColumnclass.Name = "GridColumnclass"
        Me.GridColumnclass.Visible = True
        Me.GridColumnclass.VisibleIndex = 3
        '
        'GridColumnname
        '
        Me.GridColumnname.Caption = "Description"
        Me.GridColumnname.FieldName = "name"
        Me.GridColumnname.Name = "GridColumnname"
        Me.GridColumnname.Visible = True
        Me.GridColumnname.VisibleIndex = 4
        '
        'GridColumnsht_name
        '
        Me.GridColumnsht_name.Caption = "Silhouette"
        Me.GridColumnsht_name.FieldName = "sht_name"
        Me.GridColumnsht_name.Name = "GridColumnsht_name"
        Me.GridColumnsht_name.Visible = True
        Me.GridColumnsht_name.VisibleIndex = 5
        '
        'GridColumnsize
        '
        Me.GridColumnsize.Caption = "Size"
        Me.GridColumnsize.FieldName = "size"
        Me.GridColumnsize.Name = "GridColumnsize"
        Me.GridColumnsize.Visible = True
        Me.GridColumnsize.VisibleIndex = 6
        '
        'GridColumnsync_date
        '
        Me.GridColumnsync_date.Caption = "Sync Date"
        Me.GridColumnsync_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumnsync_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsync_date.FieldName = "sync_date"
        Me.GridColumnsync_date.Name = "GridColumnsync_date"
        Me.GridColumnsync_date.Visible = True
        Me.GridColumnsync_date.VisibleIndex = 7
        '
        'GridColumnsync_note
        '
        Me.GridColumnsync_note.Caption = "Sync Note"
        Me.GridColumnsync_note.FieldName = "sync_note"
        Me.GridColumnsync_note.Name = "GridColumnsync_note"
        Me.GridColumnsync_note.Visible = True
        Me.GridColumnsync_note.VisibleIndex = 8
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        SerializableAppearanceObject2.BackColor = System.Drawing.SystemColors.Highlight
        SerializableAppearanceObject2.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SerializableAppearanceObject2.ForeColor = System.Drawing.Color.White
        SerializableAppearanceObject2.Options.UseBackColor = True
        SerializableAppearanceObject2.Options.UseFont = True
        SerializableAppearanceObject2.Options.UseForeColor = True
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Detail Sync", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "", Nothing, Nothing, True)})
        Me.RepositoryItemButtonEdit1.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        Me.RepositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnPrint.Location = New System.Drawing.Point(20, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(627, 23)
        Me.BtnPrint.TabIndex = 0
        Me.BtnPrint.Text = "Print"
        '
        'FormPriceMKDViosHist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(649, 435)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.MinimizeBox = False
        Me.Name = "FormPriceMKDViosHist"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "History - VIOS Sync Price"
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GCProposal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProposal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoBtnDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCProposal As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProposal As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_report As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnreport_mark_type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumneff_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnbtn_detail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoBtnDetail As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents GCDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents GridColumnnumberdet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumneffective_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnclass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsht_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsync_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsync_note As DevExpress.XtraGrid.Columns.GridColumn
End Class
