<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAREvalNote
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAREvalNote))
        Me.GroupControlHead = New DevExpress.XtraEditors.GroupControl()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LEReportStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.DECreated = New DevExpress.XtraEditors.DateEdit()
        Me.PanelControlBottom = New DevExpress.XtraEditors.PanelControl()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAttachment = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnMark = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnResetPropose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSaveChanges = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnConfirm = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddNoteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteNoteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_ar_eval_note_det = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_ar_eval_note_store = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_ar_eval_note = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_comp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnstore_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnoverdue_inv = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControlNav = New DevExpress.XtraEditors.PanelControl()
        Me.BtnAddBulk = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumnsortcol = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TxtEvalNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.GroupControlHead, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlHead.SuspendLayout()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DECreated.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DECreated.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlBottom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlBottom.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNav.SuspendLayout()
        CType(Me.TxtEvalNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControlHead
        '
        Me.GroupControlHead.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlHead.Controls.Add(Me.LabelControl1)
        Me.GroupControlHead.Controls.Add(Me.TxtEvalNumber)
        Me.GroupControlHead.Controls.Add(Me.MENote)
        Me.GroupControlHead.Controls.Add(Me.LabelControl7)
        Me.GroupControlHead.Controls.Add(Me.TxtNumber)
        Me.GroupControlHead.Controls.Add(Me.LabelControl2)
        Me.GroupControlHead.Controls.Add(Me.PanelControl1)
        Me.GroupControlHead.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControlHead.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlHead.Name = "GroupControlHead"
        Me.GroupControlHead.Size = New System.Drawing.Size(826, 134)
        Me.GroupControlHead.TabIndex = 19
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(147, 66)
        Me.MENote.Name = "MENote"
        Me.MENote.Properties.MaxLength = 255
        Me.MENote.Size = New System.Drawing.Size(216, 52)
        Me.MENote.TabIndex = 151
        Me.MENote.TabStop = False
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(34, 68)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl7.TabIndex = 150
        Me.LabelControl7.Text = "Note"
        '
        'TxtNumber
        '
        Me.TxtNumber.EditValue = ""
        Me.TxtNumber.Enabled = False
        Me.TxtNumber.Location = New System.Drawing.Point(147, 40)
        Me.TxtNumber.Name = "TxtNumber"
        Me.TxtNumber.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumber.Properties.Appearance.Options.UseFont = True
        Me.TxtNumber.Size = New System.Drawing.Size(216, 20)
        Me.TxtNumber.TabIndex = 147
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(34, 43)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl2.TabIndex = 147
        Me.LabelControl2.Text = "Note No."
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.LabelControl21)
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Controls.Add(Me.LEReportStatus)
        Me.PanelControl1.Controls.Add(Me.DECreated)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl1.Location = New System.Drawing.Point(599, 2)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(225, 130)
        Me.PanelControl1.TabIndex = 4
        '
        'LabelControl21
        '
        Me.LabelControl21.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl21.Location = New System.Drawing.Point(10, 41)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl21.TabIndex = 144
        Me.LabelControl21.Text = "Status"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(10, 15)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl4.TabIndex = 7
        Me.LabelControl4.Text = "Created Date"
        '
        'LEReportStatus
        '
        Me.LEReportStatus.Enabled = False
        Me.LEReportStatus.Location = New System.Drawing.Point(81, 38)
        Me.LEReportStatus.Name = "LEReportStatus"
        Me.LEReportStatus.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LEReportStatus.Properties.Appearance.Options.UseFont = True
        Me.LEReportStatus.Properties.Appearance.Options.UseTextOptions = True
        Me.LEReportStatus.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEReportStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEReportStatus.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_report_status", "ID Report Status", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("report_status", "Report Status")})
        Me.LEReportStatus.Properties.NullText = ""
        Me.LEReportStatus.Properties.ShowFooter = False
        Me.LEReportStatus.Size = New System.Drawing.Size(136, 20)
        Me.LEReportStatus.TabIndex = 7
        '
        'DECreated
        '
        Me.DECreated.EditValue = Nothing
        Me.DECreated.Enabled = False
        Me.DECreated.Location = New System.Drawing.Point(81, 12)
        Me.DECreated.Name = "DECreated"
        Me.DECreated.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DECreated.Properties.Appearance.Options.UseFont = True
        Me.DECreated.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DECreated.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DECreated.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DECreated.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DECreated.Size = New System.Drawing.Size(136, 20)
        Me.DECreated.TabIndex = 6
        '
        'PanelControlBottom
        '
        Me.PanelControlBottom.Controls.Add(Me.BtnPrint)
        Me.PanelControlBottom.Controls.Add(Me.BtnAttachment)
        Me.PanelControlBottom.Controls.Add(Me.BtnMark)
        Me.PanelControlBottom.Controls.Add(Me.BtnResetPropose)
        Me.PanelControlBottom.Controls.Add(Me.BtnSaveChanges)
        Me.PanelControlBottom.Controls.Add(Me.BtnConfirm)
        Me.PanelControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControlBottom.Location = New System.Drawing.Point(0, 440)
        Me.PanelControlBottom.Name = "PanelControlBottom"
        Me.PanelControlBottom.Size = New System.Drawing.Size(826, 44)
        Me.PanelControlBottom.TabIndex = 21
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(289, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(87, 40)
        Me.BtnPrint.TabIndex = 3
        Me.BtnPrint.Text = "Print"
        '
        'BtnAttachment
        '
        Me.BtnAttachment.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAttachment.Image = CType(resources.GetObject("BtnAttachment.Image"), System.Drawing.Image)
        Me.BtnAttachment.Location = New System.Drawing.Point(376, 2)
        Me.BtnAttachment.Name = "BtnAttachment"
        Me.BtnAttachment.Size = New System.Drawing.Size(109, 40)
        Me.BtnAttachment.TabIndex = 4
        Me.BtnAttachment.Text = "Attachment"
        Me.BtnAttachment.Visible = False
        '
        'BtnMark
        '
        Me.BtnMark.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnMark.Image = CType(resources.GetObject("BtnMark.Image"), System.Drawing.Image)
        Me.BtnMark.Location = New System.Drawing.Point(2, 2)
        Me.BtnMark.Name = "BtnMark"
        Me.BtnMark.Size = New System.Drawing.Size(89, 40)
        Me.BtnMark.TabIndex = 5
        Me.BtnMark.Text = "Mark"
        Me.BtnMark.Visible = False
        '
        'BtnResetPropose
        '
        Me.BtnResetPropose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnResetPropose.Image = CType(resources.GetObject("BtnResetPropose.Image"), System.Drawing.Image)
        Me.BtnResetPropose.Location = New System.Drawing.Point(485, 2)
        Me.BtnResetPropose.Name = "BtnResetPropose"
        Me.BtnResetPropose.Size = New System.Drawing.Size(123, 40)
        Me.BtnResetPropose.TabIndex = 9
        Me.BtnResetPropose.Text = "Reset Propose"
        '
        'BtnSaveChanges
        '
        Me.BtnSaveChanges.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSaveChanges.Image = CType(resources.GetObject("BtnSaveChanges.Image"), System.Drawing.Image)
        Me.BtnSaveChanges.Location = New System.Drawing.Point(608, 2)
        Me.BtnSaveChanges.Name = "BtnSaveChanges"
        Me.BtnSaveChanges.Size = New System.Drawing.Size(120, 40)
        Me.BtnSaveChanges.TabIndex = 8
        Me.BtnSaveChanges.Text = "Save Changes"
        Me.BtnSaveChanges.Visible = False
        '
        'BtnConfirm
        '
        Me.BtnConfirm.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnConfirm.Image = CType(resources.GetObject("BtnConfirm.Image"), System.Drawing.Image)
        Me.BtnConfirm.Location = New System.Drawing.Point(728, 2)
        Me.BtnConfirm.Name = "BtnConfirm"
        Me.BtnConfirm.Size = New System.Drawing.Size(96, 40)
        Me.BtnConfirm.TabIndex = 6
        Me.BtnConfirm.Text = "Confirm"
        Me.BtnConfirm.Visible = False
        '
        'GCData
        '
        Me.GCData.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 177)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(826, 263)
        Me.GCData.TabIndex = 22
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNoteToolStripMenuItem, Me.ToolStripMenuItem1, Me.DeleteNoteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(137, 70)
        '
        'AddNoteToolStripMenuItem
        '
        Me.AddNoteToolStripMenuItem.Name = "AddNoteToolStripMenuItem"
        Me.AddNoteToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.AddNoteToolStripMenuItem.Text = "Add Note"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(136, 22)
        Me.ToolStripMenuItem1.Text = "Edit Note"
        '
        'DeleteNoteToolStripMenuItem
        '
        Me.DeleteNoteToolStripMenuItem.Name = "DeleteNoteToolStripMenuItem"
        Me.DeleteNoteToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.DeleteNoteToolStripMenuItem.Text = "Delete Note"
        '
        'GVData
        '
        Me.GVData.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GVData.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GVData.ColumnPanelRowHeight = 40
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_ar_eval_note_det, Me.GridColumnid_ar_eval_note_store, Me.GridColumnid_ar_eval_note, Me.GridColumnid_comp_group, Me.GridColumnstore_group, Me.GridColumnoverdue_inv, Me.GridColumnnote, Me.GridColumnsortcol})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.LevelIndent = 0
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsView.AllowCellMerge = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupedColumns = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_ar_eval_note_det
        '
        Me.GridColumnid_ar_eval_note_det.Caption = "id_ar_eval_note_det"
        Me.GridColumnid_ar_eval_note_det.FieldName = "id_ar_eval_note_det"
        Me.GridColumnid_ar_eval_note_det.Name = "GridColumnid_ar_eval_note_det"
        '
        'GridColumnid_ar_eval_note_store
        '
        Me.GridColumnid_ar_eval_note_store.Caption = "id_ar_eval_note_store"
        Me.GridColumnid_ar_eval_note_store.FieldName = "id_ar_eval_note_store"
        Me.GridColumnid_ar_eval_note_store.Name = "GridColumnid_ar_eval_note_store"
        '
        'GridColumnid_ar_eval_note
        '
        Me.GridColumnid_ar_eval_note.Caption = "id_ar_eval_note"
        Me.GridColumnid_ar_eval_note.FieldName = "id_ar_eval_note"
        Me.GridColumnid_ar_eval_note.Name = "GridColumnid_ar_eval_note"
        '
        'GridColumnid_comp_group
        '
        Me.GridColumnid_comp_group.Caption = "id_comp_group"
        Me.GridColumnid_comp_group.FieldName = "id_comp_group"
        Me.GridColumnid_comp_group.Name = "GridColumnid_comp_group"
        '
        'GridColumnstore_group
        '
        Me.GridColumnstore_group.Caption = "Store Group"
        Me.GridColumnstore_group.FieldName = "store_group"
        Me.GridColumnstore_group.Name = "GridColumnstore_group"
        Me.GridColumnstore_group.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumnstore_group.Visible = True
        Me.GridColumnstore_group.VisibleIndex = 0
        '
        'GridColumnoverdue_inv
        '
        Me.GridColumnoverdue_inv.Caption = "Total Invoice JT Belum Lunas"
        Me.GridColumnoverdue_inv.DisplayFormat.FormatString = "N2"
        Me.GridColumnoverdue_inv.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnoverdue_inv.FieldName = "overdue_inv"
        Me.GridColumnoverdue_inv.Name = "GridColumnoverdue_inv"
        Me.GridColumnoverdue_inv.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumnoverdue_inv.Visible = True
        Me.GridColumnoverdue_inv.VisibleIndex = 1
        Me.GridColumnoverdue_inv.Width = 90
        '
        'GridColumnnote
        '
        Me.GridColumnnote.Caption = "Note"
        Me.GridColumnnote.FieldName = "note"
        Me.GridColumnnote.Name = "GridColumnnote"
        Me.GridColumnnote.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnnote.Visible = True
        Me.GridColumnnote.VisibleIndex = 2
        '
        'PanelControlNav
        '
        Me.PanelControlNav.Controls.Add(Me.BtnAddBulk)
        Me.PanelControlNav.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlNav.Location = New System.Drawing.Point(0, 134)
        Me.PanelControlNav.Name = "PanelControlNav"
        Me.PanelControlNav.Size = New System.Drawing.Size(826, 43)
        Me.PanelControlNav.TabIndex = 23
        '
        'BtnAddBulk
        '
        Me.BtnAddBulk.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAddBulk.Image = CType(resources.GetObject("BtnAddBulk.Image"), System.Drawing.Image)
        Me.BtnAddBulk.Location = New System.Drawing.Point(697, 2)
        Me.BtnAddBulk.Name = "BtnAddBulk"
        Me.BtnAddBulk.Size = New System.Drawing.Size(127, 39)
        Me.BtnAddBulk.TabIndex = 24
        Me.BtnAddBulk.Text = "Add Note (Bulk)"
        '
        'GridColumnsortcol
        '
        Me.GridColumnsortcol.Caption = "sortcol"
        Me.GridColumnsortcol.FieldName = "sortcol"
        Me.GridColumnsortcol.Name = "GridColumnsortcol"
        '
        'TxtEvalNumber
        '
        Me.TxtEvalNumber.EditValue = ""
        Me.TxtEvalNumber.Enabled = False
        Me.TxtEvalNumber.Location = New System.Drawing.Point(147, 14)
        Me.TxtEvalNumber.Name = "TxtEvalNumber"
        Me.TxtEvalNumber.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEvalNumber.Properties.Appearance.Options.UseFont = True
        Me.TxtEvalNumber.Size = New System.Drawing.Size(216, 20)
        Me.TxtEvalNumber.TabIndex = 152
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(34, 17)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(98, 13)
        Me.LabelControl1.TabIndex = 148
        Me.LabelControl1.Text = "AR Evaluation No."
        '
        'FormAREvalNote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(826, 484)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControlNav)
        Me.Controls.Add(Me.PanelControlBottom)
        Me.Controls.Add(Me.GroupControlHead)
        Me.MinimizeBox = False
        Me.Name = "FormAREvalNote"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catatan Manajemen Terhadap AR"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GroupControlHead, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlHead.ResumeLayout(False)
        Me.GroupControlHead.PerformLayout()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DECreated.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DECreated.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlBottom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlBottom.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNav.ResumeLayout(False)
        CType(Me.TxtEvalNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupControlHead As DevExpress.XtraEditors.GroupControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEReportStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents DECreated As DevExpress.XtraEditors.DateEdit
    Friend WithEvents PanelControlBottom As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAttachment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnResetPropose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSaveChanges As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnConfirm As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents AddNoteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteNoteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents GridColumnid_ar_eval_note_det As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_ar_eval_note_store As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_ar_eval_note As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_comp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnstore_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnoverdue_inv As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControlNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnAddBulk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnsortcol As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtEvalNumber As DevExpress.XtraEditors.TextEdit
End Class
