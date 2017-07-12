<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpUniPeriodDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpUniPeriodDet))
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.DEDist = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.DEEnd = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.DEStart = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtPeriodName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.XTCUni = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPBudget = New DevExpress.XtraTab.XtraTabPage()
        Me.GCDetail = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVDetail = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdEmployee = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNik = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDept = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPosition = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLevel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBudget = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnActual = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnPrintBudget = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnExportBudget = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnImportBudget = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.DEDist.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDist.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPeriodName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.XTCUni, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCUni.SuspendLayout()
        Me.XTPBudget.SuspendLayout()
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.DEDist)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Controls.Add(Me.DEEnd)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Controls.Add(Me.DEStart)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.TxtPeriodName)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(719, 105)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Period"
        '
        'DEDist
        '
        Me.DEDist.EditValue = Nothing
        Me.DEDist.Location = New System.Drawing.Point(116, 66)
        Me.DEDist.Name = "DEDist"
        Me.DEDist.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDist.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDist.Properties.DisplayFormat.FormatString = "dd\/MM\/yyyy"
        Me.DEDist.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEDist.Size = New System.Drawing.Size(175, 20)
        Me.DEDist.TabIndex = 7
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(33, 69)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(77, 13)
        Me.LabelControl4.TabIndex = 6
        Me.LabelControl4.Text = "Distribution Plan"
        '
        'DEEnd
        '
        Me.DEEnd.EditValue = Nothing
        Me.DEEnd.Location = New System.Drawing.Point(321, 40)
        Me.DEEnd.Name = "DEEnd"
        Me.DEEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEnd.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEnd.Properties.DisplayFormat.FormatString = "dd\/MM\/yyyy"
        Me.DEEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEEnd.Size = New System.Drawing.Size(175, 20)
        Me.DEEnd.TabIndex = 5
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(297, 43)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(18, 13)
        Me.LabelControl3.TabIndex = 4
        Me.LabelControl3.Text = "End"
        '
        'DEStart
        '
        Me.DEStart.EditValue = Nothing
        Me.DEStart.Location = New System.Drawing.Point(116, 40)
        Me.DEStart.Name = "DEStart"
        Me.DEStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.DisplayFormat.FormatString = "dd\/MM\/yyyy"
        Me.DEStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStart.Size = New System.Drawing.Size(175, 20)
        Me.DEStart.TabIndex = 3
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(33, 43)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Start"
        '
        'TxtPeriodName
        '
        Me.TxtPeriodName.Location = New System.Drawing.Point(116, 14)
        Me.TxtPeriodName.Name = "TxtPeriodName"
        Me.TxtPeriodName.Size = New System.Drawing.Size(380, 20)
        Me.TxtPeriodName.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(33, 17)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(60, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Period Name"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnClose)
        Me.PanelControl1.Controls.Add(Me.BtnSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 411)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(719, 40)
        Me.PanelControl1.TabIndex = 1
        '
        'BtnClose
        '
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(524, 2)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(86, 36)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Cancel"
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), System.Drawing.Image)
        Me.BtnSave.Location = New System.Drawing.Point(610, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(107, 36)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "Create New"
        '
        'XTCUni
        '
        Me.XTCUni.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCUni.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left
        Me.XTCUni.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Vertical
        Me.XTCUni.Location = New System.Drawing.Point(0, 105)
        Me.XTCUni.Name = "XTCUni"
        Me.XTCUni.SelectedTabPage = Me.XTPBudget
        Me.XTCUni.Size = New System.Drawing.Size(719, 306)
        Me.XTCUni.TabIndex = 2
        Me.XTCUni.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPBudget})
        '
        'XTPBudget
        '
        Me.XTPBudget.Controls.Add(Me.GCDetail)
        Me.XTPBudget.Controls.Add(Me.PanelControl2)
        Me.XTPBudget.Name = "XTPBudget"
        Me.XTPBudget.Size = New System.Drawing.Size(690, 300)
        Me.XTPBudget.Text = "Detail"
        '
        'GCDetail
        '
        Me.GCDetail.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GCDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDetail.Location = New System.Drawing.Point(0, 37)
        Me.GCDetail.MainView = Me.GVDetail
        Me.GCDetail.Name = "GCDetail"
        Me.GCDetail.Size = New System.Drawing.Size(690, 263)
        Me.GCDetail.TabIndex = 1
        Me.GCDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDetail})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(136, 26)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.EditToolStripMenuItem.Text = "Edit Budget"
        '
        'GVDetail
        '
        Me.GVDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdEmployee, Me.GridColumnNik, Me.GridColumnName, Me.GridColumnDept, Me.GridColumnPosition, Me.GridColumnLevel, Me.GridColumnBudget, Me.GridColumnActual, Me.GridColumn1, Me.GridColumnStatus})
        Me.GVDetail.GridControl = Me.GCDetail
        Me.GVDetail.GroupCount = 1
        Me.GVDetail.Name = "GVDetail"
        Me.GVDetail.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVDetail.OptionsView.ShowGroupedColumns = True
        Me.GVDetail.OptionsView.ShowGroupPanel = False
        Me.GVDetail.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnDept, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnLevel, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnIdEmployee
        '
        Me.GridColumnIdEmployee.Caption = "Id Employee"
        Me.GridColumnIdEmployee.FieldName = "id_employee"
        Me.GridColumnIdEmployee.Name = "GridColumnIdEmployee"
        '
        'GridColumnNik
        '
        Me.GridColumnNik.Caption = "NIK"
        Me.GridColumnNik.FieldName = "employee_code"
        Me.GridColumnNik.Name = "GridColumnNik"
        Me.GridColumnNik.Visible = True
        Me.GridColumnNik.VisibleIndex = 0
        Me.GridColumnNik.Width = 119
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Name"
        Me.GridColumnName.FieldName = "employee_name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 1
        Me.GridColumnName.Width = 227
        '
        'GridColumnDept
        '
        Me.GridColumnDept.Caption = "Departement"
        Me.GridColumnDept.FieldName = "departement"
        Me.GridColumnDept.Name = "GridColumnDept"
        Me.GridColumnDept.Visible = True
        Me.GridColumnDept.VisibleIndex = 2
        Me.GridColumnDept.Width = 122
        '
        'GridColumnPosition
        '
        Me.GridColumnPosition.Caption = "Position"
        Me.GridColumnPosition.FieldName = "employee_position"
        Me.GridColumnPosition.Name = "GridColumnPosition"
        Me.GridColumnPosition.Visible = True
        Me.GridColumnPosition.VisibleIndex = 3
        Me.GridColumnPosition.Width = 99
        '
        'GridColumnLevel
        '
        Me.GridColumnLevel.Caption = "Level"
        Me.GridColumnLevel.FieldName = "employee_level"
        Me.GridColumnLevel.FieldNameSortGroup = "id_employee_level"
        Me.GridColumnLevel.Name = "GridColumnLevel"
        Me.GridColumnLevel.Visible = True
        Me.GridColumnLevel.VisibleIndex = 4
        Me.GridColumnLevel.Width = 99
        '
        'GridColumnBudget
        '
        Me.GridColumnBudget.Caption = "Budget"
        Me.GridColumnBudget.DisplayFormat.FormatString = "N2"
        Me.GridColumnBudget.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnBudget.FieldName = "budget"
        Me.GridColumnBudget.Name = "GridColumnBudget"
        Me.GridColumnBudget.Visible = True
        Me.GridColumnBudget.VisibleIndex = 5
        Me.GridColumnBudget.Width = 99
        '
        'GridColumnActual
        '
        Me.GridColumnActual.Caption = "Actual"
        Me.GridColumnActual.DisplayFormat.FormatString = "N2"
        Me.GridColumnActual.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnActual.FieldName = "amount"
        Me.GridColumnActual.Name = "GridColumnActual"
        Me.GridColumnActual.Visible = True
        Me.GridColumnActual.VisibleIndex = 6
        Me.GridColumnActual.Width = 99
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Qty"
        Me.GridColumn1.DisplayFormat.FormatString = "N0"
        Me.GridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn1.FieldName = "total_qty"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 7
        Me.GridColumn1.Width = 64
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Delivery Status"
        Me.GridColumnStatus.FieldName = "del_report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 8
        Me.GridColumnStatus.Width = 150
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.BtnPrintBudget)
        Me.PanelControl2.Controls.Add(Me.BtnDelete)
        Me.PanelControl2.Controls.Add(Me.BtnExportBudget)
        Me.PanelControl2.Controls.Add(Me.BtnImportBudget)
        Me.PanelControl2.Controls.Add(Me.BtnEdit)
        Me.PanelControl2.Controls.Add(Me.BtnAdd)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(690, 37)
        Me.PanelControl2.TabIndex = 0
        '
        'BtnPrintBudget
        '
        Me.BtnPrintBudget.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrintBudget.Image = CType(resources.GetObject("BtnPrintBudget.Image"), System.Drawing.Image)
        Me.BtnPrintBudget.Location = New System.Drawing.Point(350, 0)
        Me.BtnPrintBudget.Name = "BtnPrintBudget"
        Me.BtnPrintBudget.Size = New System.Drawing.Size(85, 37)
        Me.BtnPrintBudget.TabIndex = 2
        Me.BtnPrintBudget.Text = "Print"
        '
        'BtnDelete
        '
        Me.BtnDelete.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDelete.Image = CType(resources.GetObject("BtnDelete.Image"), System.Drawing.Image)
        Me.BtnDelete.Location = New System.Drawing.Point(435, 0)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(85, 37)
        Me.BtnDelete.TabIndex = 7
        Me.BtnDelete.Text = "Delete"
        '
        'BtnExportBudget
        '
        Me.BtnExportBudget.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnExportBudget.Image = CType(resources.GetObject("BtnExportBudget.Image"), System.Drawing.Image)
        Me.BtnExportBudget.Location = New System.Drawing.Point(121, 0)
        Me.BtnExportBudget.Name = "BtnExportBudget"
        Me.BtnExportBudget.Size = New System.Drawing.Size(170, 37)
        Me.BtnExportBudget.TabIndex = 4
        Me.BtnExportBudget.Text = "Export Master Employee"
        Me.BtnExportBudget.Visible = False
        '
        'BtnImportBudget
        '
        Me.BtnImportBudget.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnImportBudget.Image = CType(resources.GetObject("BtnImportBudget.Image"), System.Drawing.Image)
        Me.BtnImportBudget.Location = New System.Drawing.Point(0, 0)
        Me.BtnImportBudget.Name = "BtnImportBudget"
        Me.BtnImportBudget.Size = New System.Drawing.Size(121, 37)
        Me.BtnImportBudget.TabIndex = 3
        Me.BtnImportBudget.Text = "Import Budget"
        Me.BtnImportBudget.Visible = False
        '
        'BtnEdit
        '
        Me.BtnEdit.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnEdit.Image = CType(resources.GetObject("BtnEdit.Image"), System.Drawing.Image)
        Me.BtnEdit.Location = New System.Drawing.Point(520, 0)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(85, 37)
        Me.BtnEdit.TabIndex = 6
        Me.BtnEdit.Text = "Edit"
        '
        'BtnAdd
        '
        Me.BtnAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"), System.Drawing.Image)
        Me.BtnAdd.Location = New System.Drawing.Point(605, 0)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(85, 37)
        Me.BtnAdd.TabIndex = 5
        Me.BtnAdd.Text = "Add"
        '
        'FormEmpUniPeriodDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(719, 451)
        Me.Controls.Add(Me.XTCUni)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.GroupControl1)
        Me.MinimizeBox = False
        Me.Name = "FormEmpUniPeriodDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Uniform"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.DEDist.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDist.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPeriodName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.XTCUni, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCUni.ResumeLayout(False)
        Me.XTPBudget.ResumeLayout(False)
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XTCUni As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPBudget As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents DEDist As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEEnd As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtPeriodName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnExportBudget As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnImportBudget As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrintBudget As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GVDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdEmployee As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNik As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDept As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPosition As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLevel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBudget As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnActual As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnEdit As DevExpress.XtraEditors.SimpleButton
End Class
