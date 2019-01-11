<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormEmpPerAppraisal
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
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.GVList = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCId = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCDepartement = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCPosition = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCLevel = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCEmployeeStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCJoinDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCFrom = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCUntil = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCIdPeriod = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GCList
        '
        Me.GCList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCList.Location = New System.Drawing.Point(2, 2)
        Me.GCList.MainView = Me.GVList
        Me.GCList.Name = "GCList"
        Me.GCList.Size = New System.Drawing.Size(933, 539)
        Me.GCList.TabIndex = 0
        Me.GCList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVList})
        '
        'GVList
        '
        Me.GVList.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GVList.Appearance.HeaderPanel.Options.UseFont = True
        Me.GVList.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1, Me.gridBand3, Me.gridBand2})
        Me.GVList.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GCId, Me.GCIdPeriod, Me.GCCode, Me.GCName, Me.GCDepartement, Me.GCPosition, Me.GCLevel, Me.GCEmployeeStatus, Me.GCJoinDate, Me.GCFrom, Me.GCUntil})
        Me.GVList.GridControl = Me.GCList
        Me.GVList.GroupCount = 1
        Me.GVList.Name = "GVList"
        Me.GVList.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVList.OptionsBehavior.Editable = False
        Me.GVList.OptionsView.ShowGroupPanel = False
        Me.GVList.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GCDepartement, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridBand1
        '
        Me.GridBand1.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridBand1.AppearanceHeader.Options.UseFont = True
        Me.GridBand1.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand1.Caption = "GENERAL"
        Me.GridBand1.Columns.Add(Me.GCId)
        Me.GridBand1.Columns.Add(Me.GCCode)
        Me.GridBand1.Columns.Add(Me.GCName)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 295
        '
        'GCId
        '
        Me.GCId.Caption = "Id"
        Me.GCId.FieldName = "id_employee"
        Me.GCId.Name = "GCId"
        Me.GCId.Width = 93
        '
        'GCCode
        '
        Me.GCCode.Caption = "Code"
        Me.GCCode.FieldName = "employee_code"
        Me.GCCode.Name = "GCCode"
        Me.GCCode.Visible = True
        Me.GCCode.Width = 145
        '
        'GCName
        '
        Me.GCName.Caption = "Name"
        Me.GCName.FieldName = "employee_name"
        Me.GCName.Name = "GCName"
        Me.GCName.Visible = True
        Me.GCName.Width = 150
        '
        'gridBand3
        '
        Me.gridBand3.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gridBand3.AppearanceHeader.Options.UseFont = True
        Me.gridBand3.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand3.Caption = "DETAIL"
        Me.gridBand3.Columns.Add(Me.GCDepartement)
        Me.gridBand3.Columns.Add(Me.GCPosition)
        Me.gridBand3.Columns.Add(Me.GCLevel)
        Me.gridBand3.Columns.Add(Me.GCEmployeeStatus)
        Me.gridBand3.Columns.Add(Me.GCJoinDate)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 1
        Me.gridBand3.Width = 421
        '
        'GCDepartement
        '
        Me.GCDepartement.Caption = "Departement"
        Me.GCDepartement.FieldName = "departement"
        Me.GCDepartement.Name = "GCDepartement"
        Me.GCDepartement.Visible = True
        Me.GCDepartement.Width = 86
        '
        'GCPosition
        '
        Me.GCPosition.Caption = "Position"
        Me.GCPosition.FieldName = "employee_position"
        Me.GCPosition.Name = "GCPosition"
        Me.GCPosition.Visible = True
        Me.GCPosition.Width = 86
        '
        'GCLevel
        '
        Me.GCLevel.Caption = "Level"
        Me.GCLevel.FieldName = "employee_level"
        Me.GCLevel.Name = "GCLevel"
        Me.GCLevel.Visible = True
        Me.GCLevel.Width = 86
        '
        'GCEmployeeStatus
        '
        Me.GCEmployeeStatus.Caption = "Employee Status"
        Me.GCEmployeeStatus.FieldName = "employee_status"
        Me.GCEmployeeStatus.Name = "GCEmployeeStatus"
        Me.GCEmployeeStatus.Visible = True
        Me.GCEmployeeStatus.Width = 88
        '
        'GCJoinDate
        '
        Me.GCJoinDate.Caption = "Join Date"
        Me.GCJoinDate.FieldName = "employee_join_date"
        Me.GCJoinDate.Name = "GCJoinDate"
        Me.GCJoinDate.Visible = True
        '
        'gridBand2
        '
        Me.gridBand2.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gridBand2.AppearanceHeader.Options.UseFont = True
        Me.gridBand2.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand2.Caption = "PERIOD"
        Me.gridBand2.Columns.Add(Me.GCFrom)
        Me.gridBand2.Columns.Add(Me.GCUntil)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 2
        Me.gridBand2.Width = 150
        '
        'GCFrom
        '
        Me.GCFrom.Caption = "From"
        Me.GCFrom.FieldName = "start_period"
        Me.GCFrom.Name = "GCFrom"
        Me.GCFrom.Visible = True
        '
        'GCUntil
        '
        Me.GCUntil.Caption = "Until"
        Me.GCUntil.FieldName = "end_period"
        Me.GCUntil.Name = "GCUntil"
        Me.GCUntil.Visible = True
        '
        'GCIdPeriod
        '
        Me.GCIdPeriod.Caption = "Id Period"
        Me.GCIdPeriod.FieldName = "id_question_gen_res_period"
        Me.GCIdPeriod.Name = "GCIdPeriod"
        Me.GCIdPeriod.Visible = True
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.GCList)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(937, 543)
        Me.PanelControl1.TabIndex = 2
        '
        'FormEmpPerAppraisal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(937, 543)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormEmpPerAppraisal"
        Me.Text = "Penilaian Kinerja Karyawan"
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVList As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GCId As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCFrom As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCUntil As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCDepartement As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCPosition As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCLevel As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCEmployeeStatus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCJoinDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GCIdPeriod As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
End Class
