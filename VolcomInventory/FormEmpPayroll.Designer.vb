<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpPayroll
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
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPeriode = New DevExpress.XtraTab.XtraTabPage()
        Me.GCPayrollPeriode = New DevExpress.XtraGrid.GridControl()
        Me.GVPayrollPeriode = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPStart = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPEnd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLastUpd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLastUpdBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPSalaryFormat = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XTPPeriode.SuspendLayout()
        CType(Me.GCPayrollPeriode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPayrollPeriode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPSalaryFormat.SuspendLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XTPPeriode
        Me.XtraTabControl1.Size = New System.Drawing.Size(1121, 469)
        Me.XtraTabControl1.TabIndex = 0
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPeriode, Me.XTPSalaryFormat})
        '
        'XTPPeriode
        '
        Me.XTPPeriode.Controls.Add(Me.GCPayrollPeriode)
        Me.XTPPeriode.Name = "XTPPeriode"
        Me.XTPPeriode.Size = New System.Drawing.Size(1115, 441)
        Me.XTPPeriode.Text = "Periode"
        '
        'GCPayrollPeriode
        '
        Me.GCPayrollPeriode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPayrollPeriode.Location = New System.Drawing.Point(0, 0)
        Me.GCPayrollPeriode.MainView = Me.GVPayrollPeriode
        Me.GCPayrollPeriode.Name = "GCPayrollPeriode"
        Me.GCPayrollPeriode.Size = New System.Drawing.Size(1115, 441)
        Me.GCPayrollPeriode.TabIndex = 0
        Me.GCPayrollPeriode.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPayrollPeriode})
        '
        'GVPayrollPeriode
        '
        Me.GVPayrollPeriode.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnID, Me.GridColumnPStart, Me.GridColumnPEnd, Me.GridColumnLastUpd, Me.GridColumnLastUpdBy, Me.GridColumnNote})
        Me.GVPayrollPeriode.GridControl = Me.GCPayrollPeriode
        Me.GVPayrollPeriode.Name = "GVPayrollPeriode"
        Me.GVPayrollPeriode.OptionsView.ShowGroupPanel = False
        '
        'GridColumnID
        '
        Me.GridColumnID.Caption = "ID"
        Me.GridColumnID.FieldName = "id_payroll"
        Me.GridColumnID.Name = "GridColumnID"
        '
        'GridColumnPStart
        '
        Me.GridColumnPStart.Caption = "Periode Start"
        Me.GridColumnPStart.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumnPStart.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnPStart.FieldName = "periode_start"
        Me.GridColumnPStart.Name = "GridColumnPStart"
        Me.GridColumnPStart.Visible = True
        Me.GridColumnPStart.VisibleIndex = 0
        Me.GridColumnPStart.Width = 160
        '
        'GridColumnPEnd
        '
        Me.GridColumnPEnd.Caption = "Periode End"
        Me.GridColumnPEnd.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumnPEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnPEnd.FieldName = "periode_end"
        Me.GridColumnPEnd.Name = "GridColumnPEnd"
        Me.GridColumnPEnd.Visible = True
        Me.GridColumnPEnd.VisibleIndex = 1
        Me.GridColumnPEnd.Width = 136
        '
        'GridColumnLastUpd
        '
        Me.GridColumnLastUpd.Caption = "Last Update"
        Me.GridColumnLastUpd.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumnLastUpd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnLastUpd.FieldName = "employee_name"
        Me.GridColumnLastUpd.Name = "GridColumnLastUpd"
        Me.GridColumnLastUpd.Visible = True
        Me.GridColumnLastUpd.VisibleIndex = 2
        Me.GridColumnLastUpd.Width = 199
        '
        'GridColumnLastUpdBy
        '
        Me.GridColumnLastUpdBy.Caption = "Last Update By"
        Me.GridColumnLastUpdBy.FieldName = "employee_name"
        Me.GridColumnLastUpdBy.Name = "GridColumnLastUpdBy"
        Me.GridColumnLastUpdBy.Visible = True
        Me.GridColumnLastUpdBy.VisibleIndex = 3
        Me.GridColumnLastUpdBy.Width = 162
        '
        'GridColumnNote
        '
        Me.GridColumnNote.Caption = "Note"
        Me.GridColumnNote.FieldName = "note"
        Me.GridColumnNote.Name = "GridColumnNote"
        Me.GridColumnNote.Visible = True
        Me.GridColumnNote.VisibleIndex = 4
        Me.GridColumnNote.Width = 440
        '
        'XTPSalaryFormat
        '
        Me.XTPSalaryFormat.Controls.Add(Me.GridControl2)
        Me.XTPSalaryFormat.Controls.Add(Me.PanelControl1)
        Me.XTPSalaryFormat.Name = "XTPSalaryFormat"
        Me.XTPSalaryFormat.Size = New System.Drawing.Size(1115, 441)
        Me.XTPSalaryFormat.Text = "Worksheet"
        '
        'GridControl2
        '
        Me.GridControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl2.Location = New System.Drawing.Point(0, 45)
        Me.GridControl2.MainView = Me.GridView2
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(1115, 396)
        Me.GridControl2.TabIndex = 1
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SimpleButton3)
        Me.PanelControl1.Controls.Add(Me.SimpleButton2)
        Me.PanelControl1.Controls.Add(Me.SimpleButton1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1115, 45)
        Me.PanelControl1.TabIndex = 0
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Dock = System.Windows.Forms.DockStyle.Left
        Me.SimpleButton3.Location = New System.Drawing.Point(2, 2)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(97, 41)
        Me.SimpleButton3.TabIndex = 2
        Me.SimpleButton3.Text = "Print"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton2.Location = New System.Drawing.Point(895, 2)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(109, 41)
        Me.SimpleButton2.TabIndex = 1
        Me.SimpleButton2.Text = "Overtime"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton1.Location = New System.Drawing.Point(1004, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(109, 41)
        Me.SimpleButton1.TabIndex = 0
        Me.SimpleButton1.Text = "Setting"
        '
        'FormEmpPayroll
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1121, 469)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpPayroll"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Payroll Worksheet"
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XTPPeriode.ResumeLayout(False)
        CType(Me.GCPayrollPeriode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPayrollPeriode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPSalaryFormat.ResumeLayout(False)
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPeriode As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPSalaryFormat As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCPayrollPeriode As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPayrollPeriode As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPStart As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPEnd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLastUpd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLastUpdBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNote As DevExpress.XtraGrid.Columns.GridColumn
End Class
