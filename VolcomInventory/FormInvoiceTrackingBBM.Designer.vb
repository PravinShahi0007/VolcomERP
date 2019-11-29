<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInvoiceTrackingBBM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormInvoiceTrackingBBM))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnDiscard = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumnid_rec_payment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndate_created = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndate_received = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnvalue = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnDiscard)
        Me.PanelControl1.Controls.Add(Me.BtnPrint)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 273)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(490, 47)
        Me.PanelControl1.TabIndex = 0
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(490, 273)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_rec_payment, Me.GridColumndate_created, Me.GridColumndate_received, Me.GridColumnnumber, Me.GridColumnvalue})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(402, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(86, 43)
        Me.BtnPrint.TabIndex = 0
        Me.BtnPrint.Text = "Print"
        '
        'BtnDiscard
        '
        Me.BtnDiscard.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDiscard.Image = CType(resources.GetObject("BtnDiscard.Image"), System.Drawing.Image)
        Me.BtnDiscard.Location = New System.Drawing.Point(303, 2)
        Me.BtnDiscard.Name = "BtnDiscard"
        Me.BtnDiscard.Size = New System.Drawing.Size(99, 43)
        Me.BtnDiscard.TabIndex = 1
        Me.BtnDiscard.Text = "Discard"
        '
        'GridColumnid_rec_payment
        '
        Me.GridColumnid_rec_payment.Caption = "id_rec_payment"
        Me.GridColumnid_rec_payment.FieldName = "id_rec_payment"
        Me.GridColumnid_rec_payment.Name = "GridColumnid_rec_payment"
        '
        'GridColumndate_created
        '
        Me.GridColumndate_created.Caption = "Created Date"
        Me.GridColumndate_created.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GridColumndate_created.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumndate_created.FieldName = "date_created"
        Me.GridColumndate_created.Name = "GridColumndate_created"
        Me.GridColumndate_created.Visible = True
        Me.GridColumndate_created.VisibleIndex = 0
        '
        'GridColumndate_received
        '
        Me.GridColumndate_received.Caption = "Bank Received Date"
        Me.GridColumndate_received.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GridColumndate_received.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumndate_received.FieldName = "date_received"
        Me.GridColumndate_received.Name = "GridColumndate_received"
        Me.GridColumndate_received.Visible = True
        Me.GridColumndate_received.VisibleIndex = 1
        '
        'GridColumnnumber
        '
        Me.GridColumnnumber.Caption = "Number"
        Me.GridColumnnumber.FieldName = "number"
        Me.GridColumnnumber.Name = "GridColumnnumber"
        Me.GridColumnnumber.Visible = True
        Me.GridColumnnumber.VisibleIndex = 2
        '
        'GridColumnvalue
        '
        Me.GridColumnvalue.Caption = "Amount"
        Me.GridColumnvalue.DisplayFormat.FormatString = "N2"
        Me.GridColumnvalue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnvalue.FieldName = "value"
        Me.GridColumnvalue.Name = "GridColumnvalue"
        Me.GridColumnvalue.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "value", "{0:N2}")})
        Me.GridColumnvalue.Visible = True
        Me.GridColumnvalue.VisibleIndex = 3
        '
        'FormInvoiceTrackingBBM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(490, 320)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormInvoiceTrackingBBM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BBM for "
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnDiscard As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnid_rec_payment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndate_created As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndate_received As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnvalue As DevExpress.XtraGrid.Columns.GridColumn
End Class
