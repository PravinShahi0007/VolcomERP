<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpPayrollBCAFormat
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpPayrollBCAFormat))
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BExcel = New DevExpress.XtraEditors.SimpleButton()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.GCBCAFormat = New DevExpress.XtraGrid.GridControl()
        Me.GVBCAFormat = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TBFileAddress = New DevExpress.XtraEditors.TextEdit()
        Me.BBrowse = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GCBCAFormat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBCAFormat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TBFileAddress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.LargeImageCollection.Images.SetKeyName(20, "pencil.png")
        Me.LargeImageCollection.Images.SetKeyName(21, "edit-validated-icon.png")
        Me.LargeImageCollection.Images.SetKeyName(22, "Delete.png")
        Me.LargeImageCollection.Images.SetKeyName(23, "browse_3.png")
        Me.LargeImageCollection.Images.SetKeyName(24, "Full_Screen.png")
        Me.LargeImageCollection.Images.SetKeyName(25, "Exit_Full_Screen.png")
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.TBFileAddress)
        Me.PanelControl2.Controls.Add(Me.BBrowse)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Controls.Add(Me.BExcel)
        Me.PanelControl2.Controls.Add(Me.BPrint)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 458)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(986, 39)
        Me.PanelControl2.TabIndex = 3
        '
        'BExcel
        '
        Me.BExcel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BExcel.ImageIndex = 25
        Me.BExcel.ImageList = Me.LargeImageCollection
        Me.BExcel.Location = New System.Drawing.Point(754, 2)
        Me.BExcel.Name = "BExcel"
        Me.BExcel.Size = New System.Drawing.Size(127, 35)
        Me.BExcel.TabIndex = 1
        Me.BExcel.Text = "Excel Download"
        '
        'BPrint
        '
        Me.BPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BPrint.ImageIndex = 6
        Me.BPrint.ImageList = Me.LargeImageCollection
        Me.BPrint.Location = New System.Drawing.Point(881, 2)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(103, 35)
        Me.BPrint.TabIndex = 0
        Me.BPrint.Text = "Print"
        '
        'GCBCAFormat
        '
        Me.GCBCAFormat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCBCAFormat.Location = New System.Drawing.Point(0, 0)
        Me.GCBCAFormat.MainView = Me.GVBCAFormat
        Me.GCBCAFormat.Name = "GCBCAFormat"
        Me.GCBCAFormat.Size = New System.Drawing.Size(986, 458)
        Me.GCBCAFormat.TabIndex = 4
        Me.GCBCAFormat.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBCAFormat})
        '
        'GVBCAFormat
        '
        Me.GVBCAFormat.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6})
        Me.GVBCAFormat.GridControl = Me.GCBCAFormat
        Me.GVBCAFormat.Name = "GVBCAFormat"
        Me.GVBCAFormat.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "NIP"
        Me.GridColumn1.FieldName = "employee_code"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Name"
        Me.GridColumn2.FieldName = "employee_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Departement"
        Me.GridColumn3.FieldName = "departement"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "No Rekening"
        Me.GridColumn4.FieldName = "employee_no_rek"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Grand Total"
        Me.GridColumn5.DisplayFormat.FormatString = "N0"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn5.FieldName = "grand_total"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 4
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Incentive"
        Me.GridColumn6.FieldName = "incentive"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 5
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 14)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Save To :"
        '
        'TBFileAddress
        '
        Me.TBFileAddress.Location = New System.Drawing.Point(64, 10)
        Me.TBFileAddress.Name = "TBFileAddress"
        Me.TBFileAddress.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White
        Me.TBFileAddress.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.TBFileAddress.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.TBFileAddress.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.TBFileAddress.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.TBFileAddress.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black
        Me.TBFileAddress.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TBFileAddress.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.TBFileAddress.Properties.ReadOnly = True
        Me.TBFileAddress.Size = New System.Drawing.Size(383, 20)
        Me.TBFileAddress.TabIndex = 89
        '
        'BBrowse
        '
        Me.BBrowse.Location = New System.Drawing.Point(453, 7)
        Me.BBrowse.Name = "BBrowse"
        Me.BBrowse.Size = New System.Drawing.Size(51, 23)
        Me.BBrowse.TabIndex = 90
        Me.BBrowse.Text = "Browse"
        '
        'FormEmpPayrollBCAFormat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(986, 497)
        Me.Controls.Add(Me.GCBCAFormat)
        Me.Controls.Add(Me.PanelControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpPayrollBCAFormat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Export BCA Format"
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.GCBCAFormat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBCAFormat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TBFileAddress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BExcel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCBCAFormat As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVBCAFormat As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TBFileAddress As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BBrowse As DevExpress.XtraEditors.SimpleButton
End Class
