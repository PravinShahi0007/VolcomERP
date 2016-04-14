<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormNotification
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
        Me.GVNotif = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdNotif = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdNotifDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIsread = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNotifTitle = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNotif = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNotifTime = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNotifDateNew = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnMarkRead = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnEmp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCNotif = New DevExpress.XtraGrid.GridControl()
        Me.RepositoryItemToggleSwitch1 = New DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch()
        Me.RepositoryItemImageEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageEdit()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.HyperlinkLabelAllRead = New DevExpress.XtraEditors.HyperlinkLabelControl()
        Me.ViewMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SMRead = New System.Windows.Forms.ToolStripMenuItem()
        Me.SMUnread = New System.Windows.Forms.ToolStripMenuItem()
        Me.SMDelete = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.GVNotif, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCNotif, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemToggleSwitch1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        Me.ViewMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'GVNotif
        '
        Me.GVNotif.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdNotif, Me.GridColumnIdNotifDet, Me.GridColumnIsread, Me.GridColumnNotifTitle, Me.GridColumnNotif, Me.GridColumnNotifTime, Me.GridColumnNotifDateNew, Me.GridColumnMarkRead, Me.GridColumnEmp, Me.GridColumnType})
        Me.GVNotif.GridControl = Me.GCNotif
        Me.GVNotif.GroupCount = 1
        Me.GVNotif.Name = "GVNotif"
        Me.GVNotif.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVNotif.OptionsCustomization.AllowGroup = False
        Me.GVNotif.OptionsView.RowAutoHeight = True
        Me.GVNotif.OptionsView.ShowGroupPanel = False
        Me.GVNotif.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnNotifDateNew, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnNotifTime, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnIdNotif
        '
        Me.GridColumnIdNotif.Caption = "Id Notif"
        Me.GridColumnIdNotif.FieldName = "id_notif"
        Me.GridColumnIdNotif.Name = "GridColumnIdNotif"
        Me.GridColumnIdNotif.OptionsColumn.AllowEdit = False
        '
        'GridColumnIdNotifDet
        '
        Me.GridColumnIdNotifDet.Caption = "ID Notif Det"
        Me.GridColumnIdNotifDet.FieldName = "id_notif_det"
        Me.GridColumnIdNotifDet.Name = "GridColumnIdNotifDet"
        '
        'GridColumnIsread
        '
        Me.GridColumnIsread.Caption = "Is Read"
        Me.GridColumnIsread.FieldName = "is_read"
        Me.GridColumnIsread.Name = "GridColumnIsread"
        '
        'GridColumnNotifTitle
        '
        Me.GridColumnNotifTitle.Caption = "Subject"
        Me.GridColumnNotifTitle.FieldName = "notif_title"
        Me.GridColumnNotifTitle.Name = "GridColumnNotifTitle"
        Me.GridColumnNotifTitle.OptionsColumn.AllowEdit = False
        Me.GridColumnNotifTitle.Visible = True
        Me.GridColumnNotifTitle.VisibleIndex = 2
        Me.GridColumnNotifTitle.Width = 124
        '
        'GridColumnNotif
        '
        Me.GridColumnNotif.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnNotif.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnNotif.Caption = "Notification"
        Me.GridColumnNotif.FieldName = "notif_content"
        Me.GridColumnNotif.Name = "GridColumnNotif"
        Me.GridColumnNotif.OptionsColumn.AllowEdit = False
        Me.GridColumnNotif.Visible = True
        Me.GridColumnNotif.VisibleIndex = 3
        Me.GridColumnNotif.Width = 150
        '
        'GridColumnNotifTime
        '
        Me.GridColumnNotifTime.Caption = "Time"
        Me.GridColumnNotifTime.DisplayFormat.FormatString = "hh:mm tt"
        Me.GridColumnNotifTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnNotifTime.FieldName = "notif_time"
        Me.GridColumnNotifTime.Name = "GridColumnNotifTime"
        Me.GridColumnNotifTime.OptionsColumn.AllowEdit = False
        Me.GridColumnNotifTime.Visible = True
        Me.GridColumnNotifTime.VisibleIndex = 4
        Me.GridColumnNotifTime.Width = 113
        '
        'GridColumnNotifDateNew
        '
        Me.GridColumnNotifDateNew.Caption = "Date"
        Me.GridColumnNotifDateNew.DisplayFormat.FormatString = "D"
        Me.GridColumnNotifDateNew.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnNotifDateNew.FieldName = "notif_time"
        Me.GridColumnNotifDateNew.GroupFormat.FormatString = "D"
        Me.GridColumnNotifDateNew.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnNotifDateNew.Name = "GridColumnNotifDateNew"
        Me.GridColumnNotifDateNew.OptionsColumn.AllowEdit = False
        Me.GridColumnNotifDateNew.Visible = True
        Me.GridColumnNotifDateNew.VisibleIndex = 2
        '
        'GridColumnMarkRead
        '
        Me.GridColumnMarkRead.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnMarkRead.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnMarkRead.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnMarkRead.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnMarkRead.Caption = "Select"
        Me.GridColumnMarkRead.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnMarkRead.FieldName = "is_read_view"
        Me.GridColumnMarkRead.Name = "GridColumnMarkRead"
        Me.GridColumnMarkRead.Visible = True
        Me.GridColumnMarkRead.VisibleIndex = 0
        Me.GridColumnMarkRead.Width = 67
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'GridColumnEmp
        '
        Me.GridColumnEmp.Caption = "From"
        Me.GridColumnEmp.FieldName = "employee_name"
        Me.GridColumnEmp.FieldNameSortGroup = "id_employee"
        Me.GridColumnEmp.Name = "GridColumnEmp"
        Me.GridColumnEmp.OptionsColumn.AllowEdit = False
        Me.GridColumnEmp.OptionsColumn.ReadOnly = True
        Me.GridColumnEmp.Visible = True
        Me.GridColumnEmp.VisibleIndex = 1
        Me.GridColumnEmp.Width = 124
        '
        'GridColumnType
        '
        Me.GridColumnType.Caption = "Type"
        Me.GridColumnType.FieldName = "type"
        Me.GridColumnType.Name = "GridColumnType"
        Me.GridColumnType.OptionsColumn.AllowEdit = False
        Me.GridColumnType.Width = 111
        '
        'GCNotif
        '
        Me.GCNotif.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCNotif.Location = New System.Drawing.Point(0, 30)
        Me.GCNotif.MainView = Me.GVNotif
        Me.GCNotif.Name = "GCNotif"
        Me.GCNotif.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemToggleSwitch1, Me.RepositoryItemImageEdit1, Me.RepositoryItemCheckEdit1})
        Me.GCNotif.Size = New System.Drawing.Size(707, 180)
        Me.GCNotif.TabIndex = 0
        Me.GCNotif.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVNotif})
        '
        'RepositoryItemToggleSwitch1
        '
        Me.RepositoryItemToggleSwitch1.AutoHeight = False
        Me.RepositoryItemToggleSwitch1.Name = "RepositoryItemToggleSwitch1"
        Me.RepositoryItemToggleSwitch1.OffText = "Off"
        Me.RepositoryItemToggleSwitch1.OnText = "On"
        '
        'RepositoryItemImageEdit1
        '
        Me.RepositoryItemImageEdit1.AutoHeight = False
        Me.RepositoryItemImageEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageEdit1.Name = "RepositoryItemImageEdit1"
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.PanelControl2)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(707, 30)
        Me.PanelControl1.TabIndex = 1
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.HyperlinkLabelAllRead)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl2.Location = New System.Drawing.Point(614, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(93, 30)
        Me.PanelControl2.TabIndex = 1
        '
        'HyperlinkLabelAllRead
        '
        Me.HyperlinkLabelAllRead.Cursor = System.Windows.Forms.Cursors.Hand
        Me.HyperlinkLabelAllRead.Location = New System.Drawing.Point(8, 9)
        Me.HyperlinkLabelAllRead.Name = "HyperlinkLabelAllRead"
        Me.HyperlinkLabelAllRead.Size = New System.Drawing.Size(79, 13)
        Me.HyperlinkLabelAllRead.TabIndex = 2
        Me.HyperlinkLabelAllRead.Text = "Mark All as Read"
        '
        'ViewMenu
        '
        Me.ViewMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SMRead, Me.SMUnread, Me.SMDelete})
        Me.ViewMenu.Name = "ContextMenuStripYM"
        Me.ViewMenu.Size = New System.Drawing.Size(157, 70)
        '
        'SMRead
        '
        Me.SMRead.Name = "SMRead"
        Me.SMRead.Size = New System.Drawing.Size(156, 22)
        Me.SMRead.Text = "Mark as Read"
        '
        'SMUnread
        '
        Me.SMUnread.Name = "SMUnread"
        Me.SMUnread.Size = New System.Drawing.Size(156, 22)
        Me.SMUnread.Text = "Mark as Unread"
        '
        'SMDelete
        '
        Me.SMDelete.Name = "SMDelete"
        Me.SMDelete.Size = New System.Drawing.Size(156, 22)
        Me.SMDelete.Text = "Delete"
        '
        'FormNotification
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(707, 210)
        Me.Controls.Add(Me.GCNotif)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormNotification"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Notification"
        CType(Me.GVNotif, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCNotif, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemToggleSwitch1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        Me.ViewMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GVNotif As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdNotif As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCNotif As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridColumnNotifTitle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNotif As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNotifTime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNotifDateNew As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents RepositoryItemToggleSwitch1 As DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch
    Friend WithEvents RepositoryItemImageEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemImageEdit
    Friend WithEvents GridColumnIsread As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMarkRead As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnIdNotifDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEmp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ViewMenu As ContextMenuStrip
    Friend WithEvents SMRead As ToolStripMenuItem
    Friend WithEvents SMUnread As ToolStripMenuItem
    Friend WithEvents SMDelete As ToolStripMenuItem
    Friend WithEvents HyperlinkLabelAllRead As DevExpress.XtraEditors.HyperlinkLabelControl
    Friend WithEvents GridColumnType As DevExpress.XtraGrid.Columns.GridColumn
End Class
