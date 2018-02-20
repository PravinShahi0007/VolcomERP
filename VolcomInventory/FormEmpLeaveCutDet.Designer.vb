<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpLeaveCutDet
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
        Me.GCLeaveAdj = New DevExpress.XtraGrid.GridControl()
        Me.GVLeaveAdj = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridColumnIDDet = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnIDEmployee = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnNIP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnDepartement = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnLevel = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnPosition = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnContractEnd = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnWorkingDays = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnActWorkdays = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCLeaveAdj, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVLeaveAdj, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(968, 44)
        Me.PanelControl1.TabIndex = 0
        '
        'GCLeaveAdj
        '
        Me.GCLeaveAdj.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCLeaveAdj.Location = New System.Drawing.Point(0, 44)
        Me.GCLeaveAdj.MainView = Me.GVLeaveAdj
        Me.GCLeaveAdj.Name = "GCLeaveAdj"
        Me.GCLeaveAdj.Size = New System.Drawing.Size(968, 543)
        Me.GCLeaveAdj.TabIndex = 2
        Me.GCLeaveAdj.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVLeaveAdj})
        '
        'GVLeaveAdj
        '
        Me.GVLeaveAdj.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1, Me.gridBand5, Me.gridBand2})
        Me.GVLeaveAdj.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GridColumnIDDet, Me.GridColumnIDEmployee, Me.GridColumnNIP, Me.GridColumnName, Me.GridColumnDepartement, Me.GridColumnLevel, Me.GridColumnPosition, Me.GridColumnStatus, Me.GridColumnContractEnd, Me.GridColumnWorkingDays, Me.BandedGridColumnActWorkdays, Me.BandedGridColumn1, Me.BandedGridColumn2, Me.BandedGridColumn3, Me.BandedGridColumn6, Me.BandedGridColumn4, Me.BandedGridColumn5})
        Me.GVLeaveAdj.GridControl = Me.GCLeaveAdj
        Me.GVLeaveAdj.Name = "GVLeaveAdj"
        Me.GVLeaveAdj.OptionsView.ColumnAutoWidth = False
        Me.GVLeaveAdj.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVLeaveAdj.OptionsView.ShowFooter = True
        Me.GVLeaveAdj.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIDDet
        '
        Me.GridColumnIDDet.Caption = "ID"
        Me.GridColumnIDDet.FieldName = "id_payroll_det"
        Me.GridColumnIDDet.Name = "GridColumnIDDet"
        '
        'GridColumnIDEmployee
        '
        Me.GridColumnIDEmployee.Caption = "ID Employee"
        Me.GridColumnIDEmployee.FieldName = "id_employee"
        Me.GridColumnIDEmployee.Name = "GridColumnIDEmployee"
        '
        'GridColumnNIP
        '
        Me.GridColumnNIP.Caption = "NIP"
        Me.GridColumnNIP.FieldName = "employee_code"
        Me.GridColumnNIP.Name = "GridColumnNIP"
        Me.GridColumnNIP.Visible = True
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Name"
        Me.GridColumnName.FieldName = "employee_name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.Visible = True
        '
        'GridColumnDepartement
        '
        Me.GridColumnDepartement.Caption = "Departement"
        Me.GridColumnDepartement.FieldName = "departement"
        Me.GridColumnDepartement.Name = "GridColumnDepartement"
        Me.GridColumnDepartement.Visible = True
        '
        'GridColumnLevel
        '
        Me.GridColumnLevel.Caption = "Level"
        Me.GridColumnLevel.FieldName = "employee_level"
        Me.GridColumnLevel.Name = "GridColumnLevel"
        Me.GridColumnLevel.Visible = True
        '
        'GridColumnPosition
        '
        Me.GridColumnPosition.Caption = "Position"
        Me.GridColumnPosition.FieldName = "employee_position"
        Me.GridColumnPosition.Name = "GridColumnPosition"
        Me.GridColumnPosition.Visible = True
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "employee_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        '
        'GridColumnContractEnd
        '
        Me.GridColumnContractEnd.Caption = "Contract End"
        Me.GridColumnContractEnd.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnContractEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnContractEnd.FieldName = "end_period"
        Me.GridColumnContractEnd.Name = "GridColumnContractEnd"
        Me.GridColumnContractEnd.Visible = True
        '
        'GridColumnWorkingDays
        '
        Me.GridColumnWorkingDays.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnWorkingDays.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnWorkingDays.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnWorkingDays.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnWorkingDays.Caption = "Working Days"
        Me.GridColumnWorkingDays.DisplayFormat.FormatString = "N1"
        Me.GridColumnWorkingDays.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnWorkingDays.FieldName = "workdays"
        Me.GridColumnWorkingDays.Name = "GridColumnWorkingDays"
        Me.GridColumnWorkingDays.Visible = True
        '
        'BandedGridColumnActWorkdays
        '
        Me.BandedGridColumnActWorkdays.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnActWorkdays.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumnActWorkdays.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnActWorkdays.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumnActWorkdays.Caption = "Actual Working Days"
        Me.BandedGridColumnActWorkdays.DisplayFormat.FormatString = "N1"
        Me.BandedGridColumnActWorkdays.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnActWorkdays.FieldName = "actual_workdays"
        Me.BandedGridColumnActWorkdays.Name = "BandedGridColumnActWorkdays"
        Me.BandedGridColumnActWorkdays.Visible = True
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.Caption = "Total Late"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.Visible = True
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.Caption = "Total Early Home"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.Visible = True
        '
        'BandedGridColumn3
        '
        Me.BandedGridColumn3.Caption = "Total Leave Cut"
        Me.BandedGridColumn3.Name = "BandedGridColumn3"
        Me.BandedGridColumn3.Visible = True
        '
        'BandedGridColumn4
        '
        Me.BandedGridColumn4.Caption = "Leave Remaining"
        Me.BandedGridColumn4.Name = "BandedGridColumn4"
        Me.BandedGridColumn4.Visible = True
        '
        'BandedGridColumn5
        '
        Me.BandedGridColumn5.Caption = "Leave After"
        Me.BandedGridColumn5.Name = "BandedGridColumn5"
        Me.BandedGridColumn5.Visible = True
        '
        'BandedGridColumn6
        '
        Me.BandedGridColumn6.Caption = "Actual Leave Cut"
        Me.BandedGridColumn6.Name = "BandedGridColumn6"
        Me.BandedGridColumn6.Visible = True
        '
        'GridBand1
        '
        Me.GridBand1.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand1.Caption = "Employee Detail"
        Me.GridBand1.Columns.Add(Me.GridColumnIDDet)
        Me.GridBand1.Columns.Add(Me.GridColumnIDEmployee)
        Me.GridBand1.Columns.Add(Me.GridColumnNIP)
        Me.GridBand1.Columns.Add(Me.GridColumnName)
        Me.GridBand1.Columns.Add(Me.GridColumnDepartement)
        Me.GridBand1.Columns.Add(Me.GridColumnLevel)
        Me.GridBand1.Columns.Add(Me.GridColumnPosition)
        Me.GridBand1.Columns.Add(Me.GridColumnStatus)
        Me.GridBand1.Columns.Add(Me.GridColumnContractEnd)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 525
        '
        'gridBand5
        '
        Me.gridBand5.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand5.Caption = "Working Time Detail"
        Me.gridBand5.Columns.Add(Me.GridColumnWorkingDays)
        Me.gridBand5.Columns.Add(Me.BandedGridColumnActWorkdays)
        Me.gridBand5.Columns.Add(Me.BandedGridColumn1)
        Me.gridBand5.Columns.Add(Me.BandedGridColumn2)
        Me.gridBand5.Columns.Add(Me.BandedGridColumn3)
        Me.gridBand5.Name = "gridBand5"
        Me.gridBand5.VisibleIndex = 1
        Me.gridBand5.Width = 375
        '
        'gridBand2
        '
        Me.gridBand2.Caption = "Adjustment Leave"
        Me.gridBand2.Columns.Add(Me.BandedGridColumn4)
        Me.gridBand2.Columns.Add(Me.BandedGridColumn6)
        Me.gridBand2.Columns.Add(Me.BandedGridColumn5)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 2
        Me.gridBand2.Width = 225
        '
        'FormEmpLeaveCutDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(968, 587)
        Me.Controls.Add(Me.GCLeaveAdj)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormEmpLeaveCutDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Leave Adjustment"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCLeaveAdj, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVLeaveAdj, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCLeaveAdj As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVLeaveAdj As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridColumnIDDet As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnIDEmployee As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnNIP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnDepartement As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnLevel As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnPosition As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnContractEnd As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnWorkingDays As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnActWorkdays As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
End Class
