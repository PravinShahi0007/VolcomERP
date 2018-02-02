<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpPayrollDeduction
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpPayrollDeduction))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.GCDeduction = New DevExpress.XtraGrid.GridControl()
        Me.GVDeduction = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdDeduction = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdEmployee = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEmp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEmpPosition = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEmpLvl = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDeductType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCDeduction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDeduction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SimpleButton4)
        Me.PanelControl1.Controls.Add(Me.SimpleButton3)
        Me.PanelControl1.Controls.Add(Me.SimpleButton2)
        Me.PanelControl1.Controls.Add(Me.SimpleButton1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1253, 38)
        Me.PanelControl1.TabIndex = 0
        '
        'GCDeduction
        '
        Me.GCDeduction.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDeduction.Location = New System.Drawing.Point(0, 38)
        Me.GCDeduction.MainView = Me.GVDeduction
        Me.GCDeduction.Name = "GCDeduction"
        Me.GCDeduction.Size = New System.Drawing.Size(1253, 503)
        Me.GCDeduction.TabIndex = 1
        Me.GCDeduction.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDeduction})
        '
        'GVDeduction
        '
        Me.GVDeduction.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdDeduction, Me.GridColumnIdEmployee, Me.GridColumnEmp, Me.GridColumnEmpPosition, Me.GridColumnEmpLvl, Me.GridColumnDeductType, Me.GridColumnValue, Me.GridColumnNote})
        Me.GVDeduction.GridControl = Me.GCDeduction
        Me.GVDeduction.Name = "GVDeduction"
        Me.GVDeduction.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdDeduction
        '
        Me.GridColumnIdDeduction.Caption = "ID Deduction"
        Me.GridColumnIdDeduction.FieldName = "id_payroll_deduction"
        Me.GridColumnIdDeduction.Name = "GridColumnIdDeduction"
        '
        'GridColumnIdEmployee
        '
        Me.GridColumnIdEmployee.Caption = "ID Employee"
        Me.GridColumnIdEmployee.FieldName = "id_employee"
        Me.GridColumnIdEmployee.Name = "GridColumnIdEmployee"
        '
        'GridColumnEmp
        '
        Me.GridColumnEmp.Caption = "Employee"
        Me.GridColumnEmp.FieldName = "employee_name"
        Me.GridColumnEmp.Name = "GridColumnEmp"
        Me.GridColumnEmp.Visible = True
        Me.GridColumnEmp.VisibleIndex = 0
        '
        'GridColumnEmpPosition
        '
        Me.GridColumnEmpPosition.Caption = "Employee Position"
        Me.GridColumnEmpPosition.FieldName = "employee_position"
        Me.GridColumnEmpPosition.Name = "GridColumnEmpPosition"
        Me.GridColumnEmpPosition.Visible = True
        Me.GridColumnEmpPosition.VisibleIndex = 1
        '
        'GridColumnEmpLvl
        '
        Me.GridColumnEmpLvl.Caption = "Employee level"
        Me.GridColumnEmpLvl.FieldName = "employee_level"
        Me.GridColumnEmpLvl.Name = "GridColumnEmpLvl"
        Me.GridColumnEmpLvl.Visible = True
        Me.GridColumnEmpLvl.VisibleIndex = 2
        '
        'GridColumnDeductType
        '
        Me.GridColumnDeductType.Caption = "Deduction Type"
        Me.GridColumnDeductType.FieldName = "salary_deduction"
        Me.GridColumnDeductType.Name = "GridColumnDeductType"
        Me.GridColumnDeductType.Visible = True
        Me.GridColumnDeductType.VisibleIndex = 3
        '
        'GridColumnValue
        '
        Me.GridColumnValue.Caption = "Value"
        Me.GridColumnValue.DisplayFormat.FormatString = "N0"
        Me.GridColumnValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnValue.FieldName = "deduction"
        Me.GridColumnValue.Name = "GridColumnValue"
        Me.GridColumnValue.Visible = True
        Me.GridColumnValue.VisibleIndex = 4
        '
        'GridColumnNote
        '
        Me.GridColumnNote.Caption = "Note"
        Me.GridColumnNote.FieldName = "note"
        Me.GridColumnNote.Name = "GridColumnNote"
        Me.GridColumnNote.Visible = True
        Me.GridColumnNote.VisibleIndex = 5
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
        'SimpleButton1
        '
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton1.ImageIndex = 0
        Me.SimpleButton1.ImageList = Me.LargeImageCollection
        Me.SimpleButton1.Location = New System.Drawing.Point(1170, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(81, 34)
        Me.SimpleButton1.TabIndex = 0
        Me.SimpleButton1.Text = "Add"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton2.ImageIndex = 2
        Me.SimpleButton2.ImageList = Me.LargeImageCollection
        Me.SimpleButton2.Location = New System.Drawing.Point(1089, 2)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(81, 34)
        Me.SimpleButton2.TabIndex = 1
        Me.SimpleButton2.Text = "Edit"
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton3.ImageIndex = 1
        Me.SimpleButton3.ImageList = Me.LargeImageCollection
        Me.SimpleButton3.Location = New System.Drawing.Point(1008, 2)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(81, 34)
        Me.SimpleButton3.TabIndex = 2
        Me.SimpleButton3.Text = "Delete"
        '
        'SimpleButton4
        '
        Me.SimpleButton4.Dock = System.Windows.Forms.DockStyle.Left
        Me.SimpleButton4.ImageIndex = 17
        Me.SimpleButton4.ImageList = Me.LargeImageCollection
        Me.SimpleButton4.Location = New System.Drawing.Point(2, 2)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(123, 34)
        Me.SimpleButton4.TabIndex = 3
        Me.SimpleButton4.Text = "Quick Generate"
        '
        'FormEmpPayrollDeduction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1253, 541)
        Me.Controls.Add(Me.GCDeduction)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "FormEmpPayrollDeduction"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Deduction "
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCDeduction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDeduction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCDeduction As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDeduction As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdDeduction As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdEmployee As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEmp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEmpPosition As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEmpLvl As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDeductType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnValue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
End Class
