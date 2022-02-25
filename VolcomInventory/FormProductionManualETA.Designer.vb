<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProductionManualETA
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.Binput = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DEArrive = New DevExpress.XtraEditors.DateEdit()
        Me.BRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.GCLog = New DevExpress.XtraGrid.GridControl()
        Me.GVLog = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DEArrive.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEArrive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.Binput)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Controls.Add(Me.DEArrive)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(846, 45)
        Me.PanelControl1.TabIndex = 0
        '
        'Binput
        '
        Me.Binput.Location = New System.Drawing.Point(427, 10)
        Me.Binput.Name = "Binput"
        Me.Binput.Size = New System.Drawing.Size(75, 23)
        Me.Binput.TabIndex = 169
        Me.Binput.Text = "update"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 13)
        Me.Label1.TabIndex = 168
        Me.Label1.Text = "Update Estimasi Receiving QC"
        '
        'DEArrive
        '
        Me.DEArrive.EditValue = Nothing
        Me.DEArrive.Location = New System.Drawing.Point(168, 13)
        Me.DEArrive.Name = "DEArrive"
        Me.DEArrive.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEArrive.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEArrive.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEArrive.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEArrive.Size = New System.Drawing.Size(253, 20)
        Me.DEArrive.TabIndex = 167
        Me.DEArrive.ToolTip = "Tanggal tiba di QC"
        Me.DEArrive.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        '
        'BRefresh
        '
        Me.BRefresh.Appearance.BackColor = System.Drawing.Color.Blue
        Me.BRefresh.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BRefresh.Appearance.ForeColor = System.Drawing.Color.White
        Me.BRefresh.Appearance.Options.UseBackColor = True
        Me.BRefresh.Appearance.Options.UseFont = True
        Me.BRefresh.Appearance.Options.UseForeColor = True
        Me.BRefresh.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BRefresh.Location = New System.Drawing.Point(0, 487)
        Me.BRefresh.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.BRefresh.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BRefresh.Name = "BRefresh"
        Me.BRefresh.Size = New System.Drawing.Size(846, 34)
        Me.BRefresh.TabIndex = 92
        Me.BRefresh.Text = "Refresh"
        '
        'GCLog
        '
        Me.GCLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCLog.Location = New System.Drawing.Point(0, 45)
        Me.GCLog.MainView = Me.GVLog
        Me.GCLog.Name = "GCLog"
        Me.GCLog.Size = New System.Drawing.Size(846, 442)
        Me.GCLog.TabIndex = 93
        Me.GCLog.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVLog})
        '
        'GVLog
        '
        Me.GVLog.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4})
        Me.GVLog.GridControl = Me.GCLog
        Me.GVLog.Name = "GVLog"
        Me.GVLog.OptionsView.ShowGroupPanel = False
        Me.GVLog.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn3, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "id_prod_order_eta_qc_log"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Input By"
        Me.GridColumn2.FieldName = "employee_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Input Datetime"
        Me.GridColumn3.DisplayFormat.FormatString = "dd MMMM yyyy H:mm"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn3.FieldName = "datetime"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Tanggal Estimasi"
        Me.GridColumn4.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn4.FieldName = "eta_date"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'FormProductionManualETA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(846, 521)
        Me.Controls.Add(Me.GCLog)
        Me.Controls.Add(Me.BRefresh)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProductionManualETA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Update Manual Estimate Receiving QC"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.DEArrive.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEArrive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCLog As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVLog As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents DEArrive As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Binput As DevExpress.XtraEditors.SimpleButton
End Class
