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
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.GCProposal = New DevExpress.XtraGrid.GridControl()
        Me.GVProposal = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_report = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnreport_mark_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumneff_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnbtn_detail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoBtnDetail = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GCProposal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProposal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoBtnDetail, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'GroupControl2
        '
        Me.GroupControl2.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl2.Controls.Add(Me.BtnPrint)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(649, 244)
        Me.GroupControl2.TabIndex = 1
        Me.GroupControl2.Text = "Detail Sync"
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
        Me.GVProposal.OptionsBehavior.Editable = False
        Me.GVProposal.OptionsFind.AlwaysVisible = True
        Me.GVProposal.OptionsView.ColumnAutoWidth = False
        Me.GVProposal.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_report
        '
        Me.GridColumnid_report.Caption = "id_report"
        Me.GridColumnid_report.FieldName = "id_report"
        Me.GridColumnid_report.Name = "GridColumnid_report"
        '
        'GridColumnreport_mark_type
        '
        Me.GridColumnreport_mark_type.Caption = "report_mark_type"
        Me.GridColumnreport_mark_type.FieldName = "report_mark_type"
        Me.GridColumnreport_mark_type.Name = "GridColumnreport_mark_type"
        '
        'GridColumnnumber
        '
        Me.GridColumnnumber.Caption = "Number"
        Me.GridColumnnumber.FieldName = "propose_no"
        Me.GridColumnnumber.Name = "GridColumnnumber"
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
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GCProposal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProposal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoBtnDetail, System.ComponentModel.ISupportInitialize).EndInit()
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
End Class
