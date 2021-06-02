<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3PLInvoiceVerification
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3PLInvoiceVerification))
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.BAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.GCInvoice = New DevExpress.XtraGrid.GridControl()
        Me.GVInvoice = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn39 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn47 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn40 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn41 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn42 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn43 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn44 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn45 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GCInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BRefresh)
        Me.PanelControl2.Controls.Add(Me.BAdd)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1078, 54)
        Me.PanelControl2.TabIndex = 2
        '
        'BRefresh
        '
        Me.BRefresh.Dock = System.Windows.Forms.DockStyle.Left
        Me.BRefresh.Image = CType(resources.GetObject("BRefresh.Image"), System.Drawing.Image)
        Me.BRefresh.Location = New System.Drawing.Point(2, 2)
        Me.BRefresh.Name = "BRefresh"
        Me.BRefresh.Size = New System.Drawing.Size(114, 50)
        Me.BRefresh.TabIndex = 1
        Me.BRefresh.Text = "Refresh"
        '
        'BAdd
        '
        Me.BAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAdd.Image = CType(resources.GetObject("BAdd.Image"), System.Drawing.Image)
        Me.BAdd.Location = New System.Drawing.Point(901, 2)
        Me.BAdd.Name = "BAdd"
        Me.BAdd.Size = New System.Drawing.Size(175, 50)
        Me.BAdd.TabIndex = 0
        Me.BAdd.Text = "Create Verification Report"
        '
        'GCInvoice
        '
        Me.GCInvoice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCInvoice.Location = New System.Drawing.Point(0, 54)
        Me.GCInvoice.MainView = Me.GVInvoice
        Me.GCInvoice.Name = "GCInvoice"
        Me.GCInvoice.Size = New System.Drawing.Size(1078, 476)
        Me.GCInvoice.TabIndex = 3
        Me.GCInvoice.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVInvoice})
        '
        'GVInvoice
        '
        Me.GVInvoice.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn39, Me.GridColumn47, Me.GridColumn40, Me.GridColumn41, Me.GridColumn42, Me.GridColumn43, Me.GridColumn44, Me.GridColumn45, Me.GridColumn1})
        Me.GVInvoice.GridControl = Me.GCInvoice
        Me.GVInvoice.Name = "GVInvoice"
        Me.GVInvoice.OptionsBehavior.Editable = False
        Me.GVInvoice.OptionsBehavior.ReadOnly = True
        Me.GVInvoice.OptionsView.ShowGroupPanel = False
        '
        'GridColumn39
        '
        Me.GridColumn39.Caption = "ID Ivn AWB"
        Me.GridColumn39.FieldName = "id_awb_inv_sum"
        Me.GridColumn39.Name = "GridColumn39"
        '
        'GridColumn47
        '
        Me.GridColumn47.Caption = "3PL"
        Me.GridColumn47.FieldName = "comp_name"
        Me.GridColumn47.Name = "GridColumn47"
        Me.GridColumn47.Visible = True
        Me.GridColumn47.VisibleIndex = 0
        '
        'GridColumn40
        '
        Me.GridColumn40.Caption = "Invoice Number"
        Me.GridColumn40.FieldName = "inv_number"
        Me.GridColumn40.Name = "GridColumn40"
        Me.GridColumn40.Visible = True
        Me.GridColumn40.VisibleIndex = 1
        '
        'GridColumn41
        '
        Me.GridColumn41.Caption = "Created By"
        Me.GridColumn41.FieldName = "employee_name"
        Me.GridColumn41.Name = "GridColumn41"
        Me.GridColumn41.Visible = True
        Me.GridColumn41.VisibleIndex = 2
        '
        'GridColumn42
        '
        Me.GridColumn42.Caption = "Created Date"
        Me.GridColumn42.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn42.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn42.FieldName = "created_date"
        Me.GridColumn42.Name = "GridColumn42"
        Me.GridColumn42.Visible = True
        Me.GridColumn42.VisibleIndex = 3
        '
        'GridColumn43
        '
        Me.GridColumn43.Caption = "Report Status"
        Me.GridColumn43.FieldName = "report_status"
        Me.GridColumn43.Name = "GridColumn43"
        Me.GridColumn43.Visible = True
        Me.GridColumn43.VisibleIndex = 4
        '
        'GridColumn44
        '
        Me.GridColumn44.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn44.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn44.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn44.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn44.Caption = "(Volcom) Total Invoice"
        Me.GridColumn44.DisplayFormat.FormatString = "N2"
        Me.GridColumn44.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn44.FieldName = "c_tot"
        Me.GridColumn44.Name = "GridColumn44"
        Me.GridColumn44.Visible = True
        Me.GridColumn44.VisibleIndex = 5
        '
        'GridColumn45
        '
        Me.GridColumn45.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn45.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn45.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn45.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn45.Caption = "(Cargo) Total Invoice"
        Me.GridColumn45.DisplayFormat.FormatString = "N2"
        Me.GridColumn45.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn45.FieldName = "a_tot"
        Me.GridColumn45.Name = "GridColumn45"
        Me.GridColumn45.Visible = True
        Me.GridColumn45.VisibleIndex = 6
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn1.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn1.Caption = "(Final) Total Invoice"
        Me.GridColumn1.DisplayFormat.FormatString = "N2"
        Me.GridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn1.FieldName = "final_tot"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 7
        '
        'Form3PLInvoiceVerification
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1078, 530)
        Me.Controls.Add(Me.GCInvoice)
        Me.Controls.Add(Me.PanelControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form3PLInvoiceVerification"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Invoice Verification"
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GCInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCInvoice As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVInvoice As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn39 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn47 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn40 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn41 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn42 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn43 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn44 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn45 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
End Class
