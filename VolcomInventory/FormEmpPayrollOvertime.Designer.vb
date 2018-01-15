<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpPayrollOvertime
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpPayrollOvertime))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.BAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.LEPayrollPeriode = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GCOverTime = New DevExpress.XtraGrid.GridControl()
        Me.GVOverTime = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEPayrollPeriode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCOverTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVOverTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BDelete)
        Me.PanelControl1.Controls.Add(Me.BEdit)
        Me.PanelControl1.Controls.Add(Me.BAdd)
        Me.PanelControl1.Controls.Add(Me.LEPayrollPeriode)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(913, 40)
        Me.PanelControl1.TabIndex = 0
        '
        'BDelete
        '
        Me.BDelete.Dock = System.Windows.Forms.DockStyle.Right
        Me.BDelete.ImageIndex = 1
        Me.BDelete.ImageList = Me.LargeImageCollection
        Me.BDelete.Location = New System.Drawing.Point(628, 2)
        Me.BDelete.Name = "BDelete"
        Me.BDelete.Size = New System.Drawing.Size(98, 36)
        Me.BDelete.TabIndex = 152
        Me.BDelete.Text = "Delete (F3)"
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
        Me.LargeImageCollection.Images.SetKeyName(10, "10_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(11, "18_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(12, "31_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(13, "folder-documents-icon.png")
        Me.LargeImageCollection.Images.SetKeyName(14, "mail_attachment.png")
        Me.LargeImageCollection.Images.SetKeyName(15, "attachment-icon.png")
        '
        'BEdit
        '
        Me.BEdit.Dock = System.Windows.Forms.DockStyle.Right
        Me.BEdit.ImageIndex = 2
        Me.BEdit.ImageList = Me.LargeImageCollection
        Me.BEdit.Location = New System.Drawing.Point(726, 2)
        Me.BEdit.Name = "BEdit"
        Me.BEdit.Size = New System.Drawing.Size(94, 36)
        Me.BEdit.TabIndex = 151
        Me.BEdit.Text = "Edit (F2)"
        '
        'BAdd
        '
        Me.BAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAdd.ImageIndex = 0
        Me.BAdd.ImageList = Me.LargeImageCollection
        Me.BAdd.Location = New System.Drawing.Point(820, 2)
        Me.BAdd.Name = "BAdd"
        Me.BAdd.Size = New System.Drawing.Size(91, 36)
        Me.BAdd.TabIndex = 150
        Me.BAdd.Text = "Add (F1)"
        '
        'LEPayrollPeriode
        '
        Me.LEPayrollPeriode.Location = New System.Drawing.Point(99, 9)
        Me.LEPayrollPeriode.Name = "LEPayrollPeriode"
        Me.LEPayrollPeriode.Properties.Appearance.Options.UseTextOptions = True
        Me.LEPayrollPeriode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEPayrollPeriode.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LEPayrollPeriode.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.LEPayrollPeriode.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.LEPayrollPeriode.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.LEPayrollPeriode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEPayrollPeriode.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_payroll", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("periode", "Periode"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("periode_start", "Periode Start", 20, DevExpress.Utils.FormatType.DateTime, "dd MMM yyyy", True, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("periode_end", "Periode End", 20, DevExpress.Utils.FormatType.DateTime, "dd MMM yyyy", True, DevExpress.Utils.HorzAlignment.[Default])})
        Me.LEPayrollPeriode.Properties.NullText = ""
        Me.LEPayrollPeriode.Properties.ShowFooter = False
        Me.LEPayrollPeriode.Size = New System.Drawing.Size(316, 20)
        Me.LEPayrollPeriode.TabIndex = 149
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(81, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Periode Payroll : "
        '
        'GCOverTime
        '
        Me.GCOverTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCOverTime.Location = New System.Drawing.Point(0, 40)
        Me.GCOverTime.MainView = Me.GVOverTime
        Me.GCOverTime.Name = "GCOverTime"
        Me.GCOverTime.Size = New System.Drawing.Size(913, 405)
        Me.GCOverTime.TabIndex = 1
        Me.GCOverTime.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVOverTime})
        '
        'GVOverTime
        '
        Me.GVOverTime.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10})
        Me.GVOverTime.GridControl = Me.GCOverTime
        Me.GVOverTime.Name = "GVOverTime"
        Me.GVOverTime.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "id_overtime"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Id Employee"
        Me.GridColumn2.FieldName = "id_employee"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Employee"
        Me.GridColumn3.FieldName = "employee_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        Me.GridColumn3.Width = 136
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Level"
        Me.GridColumn4.FieldName = "employee_level"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 1
        Me.GridColumn4.Width = 136
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Overtime Start"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        Me.GridColumn5.Width = 167
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Overtime End"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        Me.GridColumn6.Width = 167
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Is Dayoff"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 2
        Me.GridColumn7.Width = 44
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Type"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 5
        Me.GridColumn8.Width = 129
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Total Time"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 6
        Me.GridColumn9.Width = 69
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Point"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 7
        Me.GridColumn10.Width = 47
        '
        'FormEmpPayrollOvertime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(913, 445)
        Me.Controls.Add(Me.GCOverTime)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "FormEmpPayrollOvertime"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Overtime"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEPayrollPeriode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCOverTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVOverTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEPayrollPeriode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents GCOverTime As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVOverTime As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BAdd As DevExpress.XtraEditors.SimpleButton
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
End Class
