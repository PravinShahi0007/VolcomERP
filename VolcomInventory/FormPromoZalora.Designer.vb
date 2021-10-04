<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPromoZalora
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPromoZalora))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnViewList = New DevExpress.XtraEditors.SimpleButton()
        Me.DEUntilList = New DevExpress.XtraEditors.DateEdit()
        Me.DEFromList = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_promo_zalora = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndiscount_code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndiscount_value = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnvolcom_pros = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpropose_created_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpropose_created_by_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_report_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnreport_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnrmt_propose = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpromo_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpropose_note = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnstart_period = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnend_period = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DEUntilList.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromList.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnViewList)
        Me.PanelControl1.Controls.Add(Me.DEUntilList)
        Me.PanelControl1.Controls.Add(Me.DEFromList)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.LabelControl5)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(728, 48)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnViewList
        '
        Me.BtnViewList.Image = CType(resources.GetObject("BtnViewList.Image"), System.Drawing.Image)
        Me.BtnViewList.Location = New System.Drawing.Point(305, 14)
        Me.BtnViewList.LookAndFeel.SkinName = "Blue"
        Me.BtnViewList.Name = "BtnViewList"
        Me.BtnViewList.Size = New System.Drawing.Size(75, 20)
        Me.BtnViewList.TabIndex = 8901
        Me.BtnViewList.Text = "View"
        '
        'DEUntilList
        '
        Me.DEUntilList.EditValue = Nothing
        Me.DEUntilList.Location = New System.Drawing.Point(190, 14)
        Me.DEUntilList.Name = "DEUntilList"
        Me.DEUntilList.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEUntilList.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntilList.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntilList.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntilList.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntilList.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntilList.Size = New System.Drawing.Size(111, 20)
        Me.DEUntilList.TabIndex = 8900
        '
        'DEFromList
        '
        Me.DEFromList.EditValue = Nothing
        Me.DEFromList.Location = New System.Drawing.Point(46, 14)
        Me.DEFromList.Name = "DEFromList"
        Me.DEFromList.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEFromList.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFromList.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFromList.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFromList.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFromList.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFromList.Size = New System.Drawing.Size(111, 20)
        Me.DEFromList.TabIndex = 8899
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(163, 17)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl3.TabIndex = 8898
        Me.LabelControl3.Text = "Until"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(16, 17)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl5.TabIndex = 8897
        Me.LabelControl5.Text = "From"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 48)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(728, 399)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_promo_zalora, Me.GridColumnnumber, Me.GridColumndiscount_code, Me.GridColumndiscount_value, Me.GridColumnvolcom_pros, Me.GridColumnpropose_created_date, Me.GridColumnpropose_created_by_name, Me.GridColumnid_report_status, Me.GridColumnreport_status, Me.GridColumnrmt_propose, Me.GridColumnpromo_name, Me.GridColumnpropose_note, Me.GridColumnstart_period, Me.GridColumnend_period})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_promo_zalora
        '
        Me.GridColumnid_promo_zalora.Caption = "id_promo_zalora"
        Me.GridColumnid_promo_zalora.FieldName = "id_promo_zalora"
        Me.GridColumnid_promo_zalora.Name = "GridColumnid_promo_zalora"
        '
        'GridColumnnumber
        '
        Me.GridColumnnumber.Caption = "Number"
        Me.GridColumnnumber.FieldName = "number"
        Me.GridColumnnumber.Name = "GridColumnnumber"
        Me.GridColumnnumber.Visible = True
        Me.GridColumnnumber.VisibleIndex = 0
        '
        'GridColumndiscount_code
        '
        Me.GridColumndiscount_code.Caption = "Voucher Code"
        Me.GridColumndiscount_code.DisplayFormat.FormatString = "N2"
        Me.GridColumndiscount_code.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumndiscount_code.FieldName = "discount_code"
        Me.GridColumndiscount_code.Name = "GridColumndiscount_code"
        Me.GridColumndiscount_code.Visible = True
        Me.GridColumndiscount_code.VisibleIndex = 2
        '
        'GridColumndiscount_value
        '
        Me.GridColumndiscount_value.Caption = "Discount Value (%)"
        Me.GridColumndiscount_value.DisplayFormat.FormatString = "N2"
        Me.GridColumndiscount_value.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumndiscount_value.FieldName = "discount_value"
        Me.GridColumndiscount_value.Name = "GridColumndiscount_value"
        Me.GridColumndiscount_value.Visible = True
        Me.GridColumndiscount_value.VisibleIndex = 3
        '
        'GridColumnvolcom_pros
        '
        Me.GridColumnvolcom_pros.Caption = "Charge (%)"
        Me.GridColumnvolcom_pros.DisplayFormat.FormatString = "N2"
        Me.GridColumnvolcom_pros.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnvolcom_pros.FieldName = "volcom_pros"
        Me.GridColumnvolcom_pros.Name = "GridColumnvolcom_pros"
        Me.GridColumnvolcom_pros.Visible = True
        Me.GridColumnvolcom_pros.VisibleIndex = 4
        '
        'GridColumnpropose_created_date
        '
        Me.GridColumnpropose_created_date.Caption = "Proposed Date"
        Me.GridColumnpropose_created_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GridColumnpropose_created_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnpropose_created_date.FieldName = "propose_created_date"
        Me.GridColumnpropose_created_date.Name = "GridColumnpropose_created_date"
        Me.GridColumnpropose_created_date.Visible = True
        Me.GridColumnpropose_created_date.VisibleIndex = 7
        '
        'GridColumnpropose_created_by_name
        '
        Me.GridColumnpropose_created_by_name.Caption = "Proposed By"
        Me.GridColumnpropose_created_by_name.FieldName = "propose_created_by_name"
        Me.GridColumnpropose_created_by_name.Name = "GridColumnpropose_created_by_name"
        Me.GridColumnpropose_created_by_name.Visible = True
        Me.GridColumnpropose_created_by_name.VisibleIndex = 8
        '
        'GridColumnid_report_status
        '
        Me.GridColumnid_report_status.Caption = "id_report_status"
        Me.GridColumnid_report_status.FieldName = "id_report_status"
        Me.GridColumnid_report_status.Name = "GridColumnid_report_status"
        '
        'GridColumnreport_status
        '
        Me.GridColumnreport_status.Caption = "Propose Status"
        Me.GridColumnreport_status.FieldName = "report_status"
        Me.GridColumnreport_status.Name = "GridColumnreport_status"
        Me.GridColumnreport_status.Visible = True
        Me.GridColumnreport_status.VisibleIndex = 9
        '
        'GridColumnrmt_propose
        '
        Me.GridColumnrmt_propose.Caption = "rmt_propose"
        Me.GridColumnrmt_propose.FieldName = "rmt_propose"
        Me.GridColumnrmt_propose.Name = "GridColumnrmt_propose"
        '
        'GridColumnpromo_name
        '
        Me.GridColumnpromo_name.Caption = "Promo Name"
        Me.GridColumnpromo_name.FieldName = "promo_name"
        Me.GridColumnpromo_name.Name = "GridColumnpromo_name"
        Me.GridColumnpromo_name.Visible = True
        Me.GridColumnpromo_name.VisibleIndex = 1
        '
        'GridColumnpropose_note
        '
        Me.GridColumnpropose_note.Caption = "Note"
        Me.GridColumnpropose_note.FieldName = "propose_note"
        Me.GridColumnpropose_note.Name = "GridColumnpropose_note"
        Me.GridColumnpropose_note.Visible = True
        Me.GridColumnpropose_note.VisibleIndex = 10
        '
        'GridColumnstart_period
        '
        Me.GridColumnstart_period.Caption = "Start Period"
        Me.GridColumnstart_period.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GridColumnstart_period.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnstart_period.FieldName = "start_period"
        Me.GridColumnstart_period.Name = "GridColumnstart_period"
        Me.GridColumnstart_period.Visible = True
        Me.GridColumnstart_period.VisibleIndex = 5
        '
        'GridColumnend_period
        '
        Me.GridColumnend_period.Caption = "End Period"
        Me.GridColumnend_period.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GridColumnend_period.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnend_period.FieldName = "end_period"
        Me.GridColumnend_period.Name = "GridColumnend_period"
        Me.GridColumnend_period.Visible = True
        Me.GridColumnend_period.VisibleIndex = 6
        '
        'FormPromoZalora
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(728, 447)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormPromoZalora"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Zalora Promo List"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.DEUntilList.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromList.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnViewList As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntilList As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFromList As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumnid_promo_zalora As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndiscount_code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndiscount_value As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnvolcom_pros As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpropose_created_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpropose_created_by_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_report_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnreport_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnrmt_propose As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpromo_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpropose_note As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnstart_period As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnend_period As DevExpress.XtraGrid.Columns.GridColumn
End Class
