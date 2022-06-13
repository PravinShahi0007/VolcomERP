<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGRepairReturn
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
        Me.GCFilter = New DevExpress.XtraEditors.GroupControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.BHide = New DevExpress.XtraEditors.SimpleButton()
        Me.BExpand = New DevExpress.XtraEditors.SimpleButton()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.GCRepairReturn = New DevExpress.XtraGrid.GridControl()
        Me.ViewMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SMPrePrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.SMPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVRepairReturn = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFGRepairNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnfg_repair_number_ref = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTCData = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPTransList = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPRepairList = New DevExpress.XtraTab.XtraTabPage()
        Me.GCRepairList = New DevExpress.XtraGrid.GridControl()
        Me.GVRepairList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_fg_repair = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnfg_repair_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnfg_repair_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnvendor = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCFilter.SuspendLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCRepairReturn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ViewMenu.SuspendLayout()
        CType(Me.GVRepairReturn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCData.SuspendLayout()
        Me.XTPTransList.SuspendLayout()
        Me.XTPRepairList.SuspendLayout()
        CType(Me.GCRepairList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRepairList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCFilter
        '
        Me.GCFilter.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GCFilter.Controls.Add(Me.BtnView)
        Me.GCFilter.Controls.Add(Me.BHide)
        Me.GCFilter.Controls.Add(Me.BExpand)
        Me.GCFilter.Controls.Add(Me.DEUntil)
        Me.GCFilter.Controls.Add(Me.DEFrom)
        Me.GCFilter.Controls.Add(Me.LabelControl2)
        Me.GCFilter.Controls.Add(Me.LabelControl3)
        Me.GCFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.GCFilter.Location = New System.Drawing.Point(0, 0)
        Me.GCFilter.Name = "GCFilter"
        Me.GCFilter.Size = New System.Drawing.Size(703, 39)
        Me.GCFilter.TabIndex = 6
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(317, 9)
        Me.BtnView.LookAndFeel.SkinName = "Blue"
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(75, 20)
        Me.BtnView.TabIndex = 8896
        Me.BtnView.Text = "View"
        '
        'BHide
        '
        Me.BHide.ImageIndex = 9
        Me.BHide.Location = New System.Drawing.Point(938, 14)
        Me.BHide.Name = "BHide"
        Me.BHide.Size = New System.Drawing.Size(104, 20)
        Me.BHide.TabIndex = 8898
        Me.BHide.Text = "Hide All Detail"
        Me.BHide.Visible = False
        '
        'BExpand
        '
        Me.BExpand.ImageIndex = 8
        Me.BExpand.Location = New System.Drawing.Point(835, 14)
        Me.BExpand.Name = "BExpand"
        Me.BExpand.Size = New System.Drawing.Size(99, 20)
        Me.BExpand.TabIndex = 8897
        Me.BExpand.Text = "Expand All Detail"
        Me.BExpand.Visible = False
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(202, 9)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntil.Size = New System.Drawing.Size(111, 20)
        Me.DEUntil.TabIndex = 8895
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(58, 9)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFrom.Size = New System.Drawing.Size(111, 20)
        Me.DEFrom.TabIndex = 8894
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(175, 12)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl2.TabIndex = 8893
        Me.LabelControl2.Text = "Until"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(28, 12)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl3.TabIndex = 8892
        Me.LabelControl3.Text = "From"
        '
        'GCRepairReturn
        '
        Me.GCRepairReturn.ContextMenuStrip = Me.ViewMenu
        Me.GCRepairReturn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRepairReturn.Location = New System.Drawing.Point(0, 39)
        Me.GCRepairReturn.MainView = Me.GVRepairReturn
        Me.GCRepairReturn.Name = "GCRepairReturn"
        Me.GCRepairReturn.Size = New System.Drawing.Size(703, 327)
        Me.GCRepairReturn.TabIndex = 7
        Me.GCRepairReturn.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRepairReturn})
        '
        'ViewMenu
        '
        Me.ViewMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SMPrePrint, Me.SMPrint})
        Me.ViewMenu.Name = "ContextMenuStripYM"
        Me.ViewMenu.Size = New System.Drawing.Size(137, 48)
        '
        'SMPrePrint
        '
        Me.SMPrePrint.Name = "SMPrePrint"
        Me.SMPrePrint.Size = New System.Drawing.Size(136, 22)
        Me.SMPrePrint.Text = "Pre Printing"
        '
        'SMPrint
        '
        Me.SMPrint.Name = "SMPrint"
        Me.SMPrint.Size = New System.Drawing.Size(136, 22)
        Me.SMPrint.Text = "Print"
        '
        'GVRepairReturn
        '
        Me.GVRepairReturn.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnID, Me.GridColumnNumber, Me.GridColumnCreatedDate, Me.GridColumnFGRepairNote, Me.GridColumnStatus, Me.GridColumnCompFrom, Me.GridColumnCompTo, Me.GridColumnfg_repair_number_ref})
        Me.GVRepairReturn.GridControl = Me.GCRepairReturn
        Me.GVRepairReturn.Name = "GVRepairReturn"
        Me.GVRepairReturn.OptionsBehavior.Editable = False
        Me.GVRepairReturn.OptionsView.ShowGroupPanel = False
        '
        'GridColumnID
        '
        Me.GridColumnID.Caption = "Id"
        Me.GridColumnID.FieldName = "id_fg_repair_return"
        Me.GridColumnID.Name = "GridColumnID"
        '
        'GridColumnNumber
        '
        Me.GridColumnNumber.Caption = "Number"
        Me.GridColumnNumber.FieldName = "fg_repair_return_number"
        Me.GridColumnNumber.Name = "GridColumnNumber"
        Me.GridColumnNumber.Visible = True
        Me.GridColumnNumber.VisibleIndex = 0
        '
        'GridColumnCreatedDate
        '
        Me.GridColumnCreatedDate.Caption = "Created Date"
        Me.GridColumnCreatedDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnCreatedDate.FieldName = "fg_repair_return_date"
        Me.GridColumnCreatedDate.Name = "GridColumnCreatedDate"
        Me.GridColumnCreatedDate.Visible = True
        Me.GridColumnCreatedDate.VisibleIndex = 4
        '
        'GridColumnFGRepairNote
        '
        Me.GridColumnFGRepairNote.Caption = "Note"
        Me.GridColumnFGRepairNote.FieldName = "fg_repair_return_note"
        Me.GridColumnFGRepairNote.Name = "GridColumnFGRepairNote"
        Me.GridColumnFGRepairNote.Visible = True
        Me.GridColumnFGRepairNote.VisibleIndex = 5
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 6
        '
        'GridColumnCompFrom
        '
        Me.GridColumnCompFrom.Caption = "From"
        Me.GridColumnCompFrom.FieldName = "comp_from"
        Me.GridColumnCompFrom.Name = "GridColumnCompFrom"
        Me.GridColumnCompFrom.Visible = True
        Me.GridColumnCompFrom.VisibleIndex = 2
        '
        'GridColumnCompTo
        '
        Me.GridColumnCompTo.Caption = "To"
        Me.GridColumnCompTo.FieldName = "comp_to"
        Me.GridColumnCompTo.Name = "GridColumnCompTo"
        Me.GridColumnCompTo.Visible = True
        Me.GridColumnCompTo.VisibleIndex = 3
        '
        'GridColumnfg_repair_number_ref
        '
        Me.GridColumnfg_repair_number_ref.Caption = "Ref. No."
        Me.GridColumnfg_repair_number_ref.FieldName = "fg_repair_number"
        Me.GridColumnfg_repair_number_ref.Name = "GridColumnfg_repair_number_ref"
        Me.GridColumnfg_repair_number_ref.Visible = True
        Me.GridColumnfg_repair_number_ref.VisibleIndex = 1
        '
        'XTCData
        '
        Me.XTCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCData.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCData.Location = New System.Drawing.Point(0, 0)
        Me.XTCData.Name = "XTCData"
        Me.XTCData.SelectedTabPage = Me.XTPTransList
        Me.XTCData.Size = New System.Drawing.Size(709, 394)
        Me.XTCData.TabIndex = 8
        Me.XTCData.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPTransList, Me.XTPRepairList})
        '
        'XTPTransList
        '
        Me.XTPTransList.Controls.Add(Me.GCRepairReturn)
        Me.XTPTransList.Controls.Add(Me.GCFilter)
        Me.XTPTransList.Name = "XTPTransList"
        Me.XTPTransList.Size = New System.Drawing.Size(703, 366)
        Me.XTPTransList.Text = "Transaction List"
        '
        'XTPRepairList
        '
        Me.XTPRepairList.Controls.Add(Me.GCRepairList)
        Me.XTPRepairList.Name = "XTPRepairList"
        Me.XTPRepairList.Size = New System.Drawing.Size(703, 366)
        Me.XTPRepairList.Text = "Repair List"
        '
        'GCRepairList
        '
        Me.GCRepairList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRepairList.Location = New System.Drawing.Point(0, 0)
        Me.GCRepairList.MainView = Me.GVRepairList
        Me.GCRepairList.Name = "GCRepairList"
        Me.GCRepairList.Size = New System.Drawing.Size(703, 366)
        Me.GCRepairList.TabIndex = 0
        Me.GCRepairList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRepairList})
        '
        'GVRepairList
        '
        Me.GVRepairList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_fg_repair, Me.GridColumnfg_repair_number, Me.GridColumnfg_repair_date, Me.GridColumnvendor})
        Me.GVRepairList.GridControl = Me.GCRepairList
        Me.GVRepairList.Name = "GVRepairList"
        Me.GVRepairList.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVRepairList.OptionsBehavior.Editable = False
        Me.GVRepairList.OptionsFind.AlwaysVisible = True
        Me.GVRepairList.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_fg_repair
        '
        Me.GridColumnid_fg_repair.Caption = "id"
        Me.GridColumnid_fg_repair.FieldName = "id_fg_repair"
        Me.GridColumnid_fg_repair.Name = "GridColumnid_fg_repair"
        '
        'GridColumnfg_repair_number
        '
        Me.GridColumnfg_repair_number.Caption = "Number"
        Me.GridColumnfg_repair_number.FieldName = "fg_repair_number"
        Me.GridColumnfg_repair_number.Name = "GridColumnfg_repair_number"
        Me.GridColumnfg_repair_number.Visible = True
        Me.GridColumnfg_repair_number.VisibleIndex = 0
        '
        'GridColumnfg_repair_date
        '
        Me.GridColumnfg_repair_date.Caption = "Created Date"
        Me.GridColumnfg_repair_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnfg_repair_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnfg_repair_date.FieldName = "fg_repair_date"
        Me.GridColumnfg_repair_date.Name = "GridColumnfg_repair_date"
        Me.GridColumnfg_repair_date.Visible = True
        Me.GridColumnfg_repair_date.VisibleIndex = 1
        '
        'GridColumnvendor
        '
        Me.GridColumnvendor.Caption = "Vendor"
        Me.GridColumnvendor.FieldName = "vendor"
        Me.GridColumnvendor.Name = "GridColumnvendor"
        Me.GridColumnvendor.Visible = True
        Me.GridColumnvendor.VisibleIndex = 2
        '
        'FormFGRepairReturn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 394)
        Me.Controls.Add(Me.XTCData)
        Me.MinimizeBox = False
        Me.Name = "FormFGRepairReturn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Repaired Product Packing List"
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GCFilter.ResumeLayout(False)
        Me.GCFilter.PerformLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCRepairReturn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ViewMenu.ResumeLayout(False)
        CType(Me.GVRepairReturn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCData.ResumeLayout(False)
        Me.XTPTransList.ResumeLayout(False)
        Me.XTPRepairList.ResumeLayout(False)
        CType(Me.GCRepairList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRepairList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCFilter As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BHide As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BExpand As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCRepairReturn As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRepairReturn As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFGRepairNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ViewMenu As ContextMenuStrip
    Friend WithEvents SMPrePrint As ToolStripMenuItem
    Friend WithEvents SMPrint As ToolStripMenuItem
    Friend WithEvents XTCData As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPTransList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPRepairList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCRepairList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRepairList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_fg_repair As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnfg_repair_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnfg_repair_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnvendor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnfg_repair_number_ref As DevExpress.XtraGrid.Columns.GridColumn
End Class
