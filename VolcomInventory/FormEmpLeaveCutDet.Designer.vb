<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormEmpLeaveCutDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpLeaveCutDet))
        Me.PCControl = New DevExpress.XtraEditors.PanelControl()
        Me.BSetup = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.Bload = New DevExpress.XtraEditors.SimpleButton()
        Me.BGetEmployee = New DevExpress.XtraEditors.SimpleButton()
        Me.GCLeaveAdj = New DevExpress.XtraGrid.GridControl()
        Me.GVLeaveAdj = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumnIDDet = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnIDEmployee = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnNIP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnDepartement = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnLevel = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnPosition = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnContractEnd = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PCControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCControl.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCLeaveAdj, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVLeaveAdj, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PCControl
        '
        Me.PCControl.Controls.Add(Me.BSetup)
        Me.PCControl.Controls.Add(Me.Bload)
        Me.PCControl.Controls.Add(Me.BGetEmployee)
        Me.PCControl.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCControl.Location = New System.Drawing.Point(0, 0)
        Me.PCControl.Name = "PCControl"
        Me.PCControl.Size = New System.Drawing.Size(1147, 44)
        Me.PCControl.TabIndex = 0
        '
        'BSetup
        '
        Me.BSetup.Dock = System.Windows.Forms.DockStyle.Left
        Me.BSetup.ImageIndex = 17
        Me.BSetup.ImageList = Me.LargeImageCollection
        Me.BSetup.Location = New System.Drawing.Point(2, 2)
        Me.BSetup.Name = "BSetup"
        Me.BSetup.Size = New System.Drawing.Size(90, 40)
        Me.BSetup.TabIndex = 6
        Me.BSetup.Text = "Setup"
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "20_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "8_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "23_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(3, "arrow_refresh.png")
        Me.LargeImageCollection.Images.SetKeyName(4, "check_mark.png")
        Me.LargeImageCollection.Images.SetKeyName(5, "gnome_application_exit (1).png")
        Me.LargeImageCollection.Images.SetKeyName(6, "printer_3.png")
        Me.LargeImageCollection.Images.SetKeyName(7, "save.png")
        Me.LargeImageCollection.Images.SetKeyName(8, "31_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(9, "18_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(10, "1415351112474759854-32.png")
        Me.LargeImageCollection.Images.SetKeyName(11, "icon_merchandise_clothes32.png")
        Me.LargeImageCollection.Images.SetKeyName(12, "t_shirtgreen.png")
        Me.LargeImageCollection.Images.SetKeyName(13, "lock red.png")
        Me.LargeImageCollection.Images.SetKeyName(14, "ordering32.png")
        Me.LargeImageCollection.Images.SetKeyName(15, "kghostview.png")
        Me.LargeImageCollection.Images.SetKeyName(16, "MetroUI-Folder-OS-Configure-icon.png")
        Me.LargeImageCollection.Images.SetKeyName(17, "Setting(32).png")
        Me.LargeImageCollection.Images.SetKeyName(18, "estimate_icon32.png")
        Me.LargeImageCollection.Images.SetKeyName(19, "copy_icon.png")
        '
        'Bload
        '
        Me.Bload.Dock = System.Windows.Forms.DockStyle.Right
        Me.Bload.ImageIndex = 3
        Me.Bload.ImageList = Me.LargeImageCollection
        Me.Bload.Location = New System.Drawing.Point(847, 2)
        Me.Bload.Name = "Bload"
        Me.Bload.Size = New System.Drawing.Size(170, 40)
        Me.Bload.TabIndex = 5
        Me.Bload.Text = "Load Working Time Detail"
        '
        'BGetEmployee
        '
        Me.BGetEmployee.Dock = System.Windows.Forms.DockStyle.Right
        Me.BGetEmployee.ImageIndex = 19
        Me.BGetEmployee.ImageList = Me.LargeImageCollection
        Me.BGetEmployee.Location = New System.Drawing.Point(1017, 2)
        Me.BGetEmployee.Name = "BGetEmployee"
        Me.BGetEmployee.Size = New System.Drawing.Size(128, 40)
        Me.BGetEmployee.TabIndex = 4
        Me.BGetEmployee.Text = "Insert Employee"
        '
        'GCLeaveAdj
        '
        Me.GCLeaveAdj.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCLeaveAdj.Location = New System.Drawing.Point(0, 44)
        Me.GCLeaveAdj.MainView = Me.GVLeaveAdj
        Me.GCLeaveAdj.Name = "GCLeaveAdj"
        Me.GCLeaveAdj.Size = New System.Drawing.Size(1147, 499)
        Me.GCLeaveAdj.TabIndex = 2
        Me.GCLeaveAdj.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVLeaveAdj})
        '
        'GVLeaveAdj
        '
        Me.GVLeaveAdj.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1, Me.gridBand5, Me.gridBand2})
        Me.GVLeaveAdj.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GridColumnIDDet, Me.GridColumnIDEmployee, Me.GridColumnNIP, Me.GridColumnName, Me.GridColumnDepartement, Me.GridColumnLevel, Me.GridColumnPosition, Me.GridColumnStatus, Me.GridColumnContractEnd, Me.BandedGridColumn1, Me.BandedGridColumn2, Me.BandedGridColumn3, Me.BandedGridColumn6, Me.BandedGridColumn4, Me.BandedGridColumn5})
        Me.GVLeaveAdj.GridControl = Me.GCLeaveAdj
        Me.GVLeaveAdj.Name = "GVLeaveAdj"
        Me.GVLeaveAdj.OptionsView.ColumnAutoWidth = False
        Me.GVLeaveAdj.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVLeaveAdj.OptionsView.ShowFooter = True
        Me.GVLeaveAdj.OptionsView.ShowGroupPanel = False
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
        'gridBand5
        '
        Me.gridBand5.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand5.Caption = "Working Time Detail"
        Me.gridBand5.Columns.Add(Me.BandedGridColumn1)
        Me.gridBand5.Columns.Add(Me.BandedGridColumn2)
        Me.gridBand5.Columns.Add(Me.BandedGridColumn3)
        Me.gridBand5.Name = "gridBand5"
        Me.gridBand5.VisibleIndex = 1
        Me.gridBand5.Width = 225
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
        'BandedGridColumn4
        '
        Me.BandedGridColumn4.Caption = "Leave Remaining"
        Me.BandedGridColumn4.Name = "BandedGridColumn4"
        Me.BandedGridColumn4.Visible = True
        '
        'BandedGridColumn6
        '
        Me.BandedGridColumn6.Caption = "Actual Leave Cut"
        Me.BandedGridColumn6.Name = "BandedGridColumn6"
        Me.BandedGridColumn6.Visible = True
        '
        'BandedGridColumn5
        '
        Me.BandedGridColumn5.Caption = "Leave After"
        Me.BandedGridColumn5.Name = "BandedGridColumn5"
        Me.BandedGridColumn5.Visible = True
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.SimpleButton2)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 543)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1147, 44)
        Me.PanelControl2.TabIndex = 3
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SimpleButton2.ImageList = Me.LargeImageCollection
        Me.SimpleButton2.Location = New System.Drawing.Point(2, 2)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(1143, 40)
        Me.SimpleButton2.TabIndex = 4
        Me.SimpleButton2.Text = "Create"
        '
        'FormEmpLeaveCutDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1147, 587)
        Me.Controls.Add(Me.GCLeaveAdj)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PCControl)
        Me.MinimizeBox = False
        Me.Name = "FormEmpLeaveCutDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Leave Adjustment"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PCControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCControl.ResumeLayout(False)
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCLeaveAdj, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVLeaveAdj, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PCControl As DevExpress.XtraEditors.PanelControl
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
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents Bload As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BGetEmployee As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSetup As DevExpress.XtraEditors.SimpleButton
End Class
