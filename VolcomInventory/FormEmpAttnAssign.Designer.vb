<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpAttnAssign
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
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.PCAction = New DevExpress.XtraEditors.PanelControl()
        Me.BViewSum = New DevExpress.XtraEditors.SimpleButton()
        Me.PCSubDepartement = New DevExpress.XtraEditors.PanelControl()
        Me.LESubDeptSum = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.PCDepartement = New DevExpress.XtraEditors.PanelControl()
        Me.LEDeptSum = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GCAttnAssign = New DevExpress.XtraGrid.GridControl()
        Me.GVAttnAssign = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNomor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDepartement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSubDepartement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProposeBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PCAction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCAction.SuspendLayout()
        CType(Me.PCSubDepartement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCSubDepartement.SuspendLayout()
        CType(Me.LESubDeptSum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCDepartement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCDepartement.SuspendLayout()
        CType(Me.LEDeptSum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCAttnAssign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAttnAssign, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.PCAction)
        Me.PanelControl2.Controls.Add(Me.PCSubDepartement)
        Me.PanelControl2.Controls.Add(Me.PCDepartement)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1008, 42)
        Me.PanelControl2.TabIndex = 4
        '
        'PCAction
        '
        Me.PCAction.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCAction.Controls.Add(Me.BViewSum)
        Me.PCAction.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PCAction.Location = New System.Drawing.Point(711, 2)
        Me.PCAction.Name = "PCAction"
        Me.PCAction.Size = New System.Drawing.Size(295, 38)
        Me.PCAction.TabIndex = 19
        '
        'BViewSum
        '
        Me.BViewSum.Location = New System.Drawing.Point(6, 7)
        Me.BViewSum.Name = "BViewSum"
        Me.BViewSum.Size = New System.Drawing.Size(86, 25)
        Me.BViewSum.TabIndex = 1
        Me.BViewSum.Text = "view"
        '
        'PCSubDepartement
        '
        Me.PCSubDepartement.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCSubDepartement.Controls.Add(Me.LESubDeptSum)
        Me.PCSubDepartement.Controls.Add(Me.LabelControl2)
        Me.PCSubDepartement.Dock = System.Windows.Forms.DockStyle.Left
        Me.PCSubDepartement.Location = New System.Drawing.Point(347, 2)
        Me.PCSubDepartement.Name = "PCSubDepartement"
        Me.PCSubDepartement.Size = New System.Drawing.Size(364, 38)
        Me.PCSubDepartement.TabIndex = 18
        '
        'LESubDeptSum
        '
        Me.LESubDeptSum.Location = New System.Drawing.Point(106, 10)
        Me.LESubDeptSum.Name = "LESubDeptSum"
        Me.LESubDeptSum.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LESubDeptSum.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_departement_sub", "Id Departement Sub", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("departement_sub", "Sub Departement")})
        Me.LESubDeptSum.Size = New System.Drawing.Size(250, 20)
        Me.LESubDeptSum.TabIndex = 15
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(11, 13)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(84, 13)
        Me.LabelControl2.TabIndex = 16
        Me.LabelControl2.Text = "Sub Departement"
        '
        'PCDepartement
        '
        Me.PCDepartement.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCDepartement.Controls.Add(Me.LEDeptSum)
        Me.PCDepartement.Controls.Add(Me.LabelControl1)
        Me.PCDepartement.Dock = System.Windows.Forms.DockStyle.Left
        Me.PCDepartement.Location = New System.Drawing.Point(2, 2)
        Me.PCDepartement.Name = "PCDepartement"
        Me.PCDepartement.Size = New System.Drawing.Size(345, 38)
        Me.PCDepartement.TabIndex = 17
        '
        'LEDeptSum
        '
        Me.LEDeptSum.Location = New System.Drawing.Point(86, 10)
        Me.LEDeptSum.Name = "LEDeptSum"
        Me.LEDeptSum.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEDeptSum.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_departement", "Id Departement", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("departement", "Departement")})
        Me.LEDeptSum.Size = New System.Drawing.Size(250, 20)
        Me.LEDeptSum.TabIndex = 14
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 13)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl1.TabIndex = 13
        Me.LabelControl1.Text = "Departement"
        '
        'GCAttnAssign
        '
        Me.GCAttnAssign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAttnAssign.Location = New System.Drawing.Point(0, 42)
        Me.GCAttnAssign.MainView = Me.GVAttnAssign
        Me.GCAttnAssign.Name = "GCAttnAssign"
        Me.GCAttnAssign.Size = New System.Drawing.Size(1008, 687)
        Me.GCAttnAssign.TabIndex = 5
        Me.GCAttnAssign.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAttnAssign})
        '
        'GVAttnAssign
        '
        Me.GVAttnAssign.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnID, Me.GridColumnNomor, Me.GridColumnDate, Me.GridColumnDepartement, Me.GridColumnSubDepartement, Me.GridColumnProposeBy, Me.GridColumnReportStatus})
        Me.GVAttnAssign.GridControl = Me.GCAttnAssign
        Me.GVAttnAssign.Name = "GVAttnAssign"
        Me.GVAttnAssign.OptionsBehavior.Editable = False
        Me.GVAttnAssign.OptionsView.ShowGroupPanel = False
        '
        'GridColumnID
        '
        Me.GridColumnID.Caption = "ID"
        Me.GridColumnID.FieldName = "id_assign_sch"
        Me.GridColumnID.Name = "GridColumnID"
        '
        'GridColumnNomor
        '
        Me.GridColumnNomor.Caption = "Number"
        Me.GridColumnNomor.FieldName = "assign_sch_number"
        Me.GridColumnNomor.Name = "GridColumnNomor"
        Me.GridColumnNomor.Visible = True
        Me.GridColumnNomor.VisibleIndex = 0
        '
        'GridColumnDate
        '
        Me.GridColumnDate.Caption = "Date"
        Me.GridColumnDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumnDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnDate.FieldName = "assign_sch_date"
        Me.GridColumnDate.Name = "GridColumnDate"
        Me.GridColumnDate.Visible = True
        Me.GridColumnDate.VisibleIndex = 1
        '
        'GridColumnDepartement
        '
        Me.GridColumnDepartement.Caption = "Department"
        Me.GridColumnDepartement.FieldName = "departement"
        Me.GridColumnDepartement.Name = "GridColumnDepartement"
        Me.GridColumnDepartement.Visible = True
        Me.GridColumnDepartement.VisibleIndex = 2
        '
        'GridColumnSubDepartement
        '
        Me.GridColumnSubDepartement.Caption = "Sub Departement"
        Me.GridColumnSubDepartement.FieldName = "departement_sub"
        Me.GridColumnSubDepartement.Name = "GridColumnSubDepartement"
        Me.GridColumnSubDepartement.Visible = True
        Me.GridColumnSubDepartement.VisibleIndex = 3
        '
        'GridColumnProposeBy
        '
        Me.GridColumnProposeBy.Caption = "Proposed By"
        Me.GridColumnProposeBy.FieldName = "employee_name"
        Me.GridColumnProposeBy.Name = "GridColumnProposeBy"
        Me.GridColumnProposeBy.Visible = True
        Me.GridColumnProposeBy.VisibleIndex = 4
        '
        'GridColumnReportStatus
        '
        Me.GridColumnReportStatus.Caption = "Status"
        Me.GridColumnReportStatus.FieldName = "report_status"
        Me.GridColumnReportStatus.Name = "GridColumnReportStatus"
        Me.GridColumnReportStatus.Visible = True
        Me.GridColumnReportStatus.VisibleIndex = 5
        '
        'FormEmpAttnAssign
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.GCAttnAssign)
        Me.Controls.Add(Me.PanelControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpAttnAssign"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Assign Schedule"
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PCAction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCAction.ResumeLayout(False)
        CType(Me.PCSubDepartement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCSubDepartement.ResumeLayout(False)
        Me.PCSubDepartement.PerformLayout()
        CType(Me.LESubDeptSum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCDepartement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCDepartement.ResumeLayout(False)
        Me.PCDepartement.PerformLayout()
        CType(Me.LEDeptSum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCAttnAssign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAttnAssign, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LEDeptSum As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BViewSum As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCAttnAssign As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAttnAssign As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNomor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProposeBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LESubDeptSum As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents GridColumnSubDepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PCSubDepartement As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PCDepartement As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PCAction As DevExpress.XtraEditors.PanelControl
End Class
