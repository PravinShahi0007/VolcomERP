<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPromoReplace
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPromoReplace))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnCreate = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnDiscard = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_ol_promo_collection = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_promo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpromo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_by_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnstart_period = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnend_period = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_report_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnreport_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnote = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnDiscard)
        Me.PanelControl1.Controls.Add(Me.BtnCreate)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 329)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(556, 47)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnCreate
        '
        Me.BtnCreate.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCreate.Image = CType(resources.GetObject("BtnCreate.Image"), System.Drawing.Image)
        Me.BtnCreate.Location = New System.Drawing.Point(433, 2)
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.Size = New System.Drawing.Size(121, 43)
        Me.BtnCreate.TabIndex = 0
        Me.BtnCreate.Text = "Create Order"
        '
        'BtnDiscard
        '
        Me.BtnDiscard.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDiscard.Image = CType(resources.GetObject("BtnDiscard.Image"), System.Drawing.Image)
        Me.BtnDiscard.Location = New System.Drawing.Point(339, 2)
        Me.BtnDiscard.Name = "BtnDiscard"
        Me.BtnDiscard.Size = New System.Drawing.Size(94, 43)
        Me.BtnDiscard.TabIndex = 1
        Me.BtnDiscard.Text = "Discard"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(556, 329)
        Me.GCData.TabIndex = 10
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_ol_promo_collection, Me.GridColumnid_promo, Me.GridColumnpromo, Me.GridColumnnumber, Me.GridColumncreated_date, Me.GridColumncreated_by_name, Me.GridColumnstart_period, Me.GridColumnend_period, Me.GridColumnid_report_status, Me.GridColumnreport_status, Me.GridColumnnote})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_ol_promo_collection
        '
        Me.GridColumnid_ol_promo_collection.Caption = "id_ol_promo_collection"
        Me.GridColumnid_ol_promo_collection.FieldName = "id_ol_promo_collection"
        Me.GridColumnid_ol_promo_collection.Name = "GridColumnid_ol_promo_collection"
        '
        'GridColumnid_promo
        '
        Me.GridColumnid_promo.Caption = "id_promo"
        Me.GridColumnid_promo.FieldName = "id_promo"
        Me.GridColumnid_promo.Name = "GridColumnid_promo"
        '
        'GridColumnpromo
        '
        Me.GridColumnpromo.Caption = "Promo Name"
        Me.GridColumnpromo.FieldName = "promo"
        Me.GridColumnpromo.Name = "GridColumnpromo"
        Me.GridColumnpromo.Visible = True
        Me.GridColumnpromo.VisibleIndex = 1
        '
        'GridColumnnumber
        '
        Me.GridColumnnumber.Caption = "Number"
        Me.GridColumnnumber.FieldName = "number"
        Me.GridColumnnumber.Name = "GridColumnnumber"
        Me.GridColumnnumber.Visible = True
        Me.GridColumnnumber.VisibleIndex = 0
        '
        'GridColumncreated_date
        '
        Me.GridColumncreated_date.Caption = "Created Date"
        Me.GridColumncreated_date.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumncreated_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumncreated_date.FieldName = "created_date"
        Me.GridColumncreated_date.Name = "GridColumncreated_date"
        '
        'GridColumncreated_by_name
        '
        Me.GridColumncreated_by_name.Caption = "Created By"
        Me.GridColumncreated_by_name.FieldName = "created_by_name"
        Me.GridColumncreated_by_name.Name = "GridColumncreated_by_name"
        '
        'GridColumnstart_period
        '
        Me.GridColumnstart_period.Caption = "Start Period"
        Me.GridColumnstart_period.DisplayFormat.FormatString = "dd MMM yyyy HH:mm"
        Me.GridColumnstart_period.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnstart_period.FieldName = "start_period"
        Me.GridColumnstart_period.Name = "GridColumnstart_period"
        Me.GridColumnstart_period.Visible = True
        Me.GridColumnstart_period.VisibleIndex = 2
        '
        'GridColumnend_period
        '
        Me.GridColumnend_period.Caption = "End Period"
        Me.GridColumnend_period.DisplayFormat.FormatString = "dd MMM yyyy HH:mm"
        Me.GridColumnend_period.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnend_period.FieldName = "end_period"
        Me.GridColumnend_period.Name = "GridColumnend_period"
        Me.GridColumnend_period.Visible = True
        Me.GridColumnend_period.VisibleIndex = 3
        '
        'GridColumnid_report_status
        '
        Me.GridColumnid_report_status.Caption = "id_report_status"
        Me.GridColumnid_report_status.FieldName = "id_report_status"
        Me.GridColumnid_report_status.Name = "GridColumnid_report_status"
        '
        'GridColumnreport_status
        '
        Me.GridColumnreport_status.Caption = "Status"
        Me.GridColumnreport_status.FieldName = "report_status"
        Me.GridColumnreport_status.Name = "GridColumnreport_status"
        '
        'GridColumnnote
        '
        Me.GridColumnnote.Caption = "Note"
        Me.GridColumnnote.FieldName = "note"
        Me.GridColumnnote.Name = "GridColumnnote"
        '
        'FormPromoReplace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(556, 376)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPromoReplace"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Promo"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnDiscard As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCreate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_ol_promo_collection As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_promo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpromo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_by_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnstart_period As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnend_period As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_report_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnreport_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnote As DevExpress.XtraGrid.Columns.GridColumn
End Class
