﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPayoutHistory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPayoutHistory))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.GCPayout = New DevExpress.XtraGrid.GridControl()
        Me.GVPayout = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_list_payout_trans = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnamount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntrans_fee = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnett = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnreport_status = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCPayout, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPayout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Controls.Add(Me.PanelControl2)
        Me.PanelControl1.Controls.Add(Me.BtnPrint)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(615, 53)
        Me.PanelControl1.TabIndex = 0
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Segoe UI", 6.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl4.Location = New System.Drawing.Point(40, 21)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(18, 12)
        Me.LabelControl4.TabIndex = 146
        Me.LabelControl4.Text = "BAP"
        '
        'PanelControl2
        '
        Me.PanelControl2.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.PanelControl2.Appearance.BorderColor = System.Drawing.Color.White
        Me.PanelControl2.Appearance.Options.UseBackColor = True
        Me.PanelControl2.Appearance.Options.UseBorderColor = True
        Me.PanelControl2.Location = New System.Drawing.Point(14, 21)
        Me.PanelControl2.LookAndFeel.SkinMaskColor = System.Drawing.Color.Yellow
        Me.PanelControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.PanelControl2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(24, 13)
        Me.PanelControl2.TabIndex = 145
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(513, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(100, 49)
        Me.BtnPrint.TabIndex = 0
        Me.BtnPrint.Text = "Print List"
        '
        'GCPayout
        '
        Me.GCPayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPayout.Location = New System.Drawing.Point(0, 53)
        Me.GCPayout.MainView = Me.GVPayout
        Me.GCPayout.Name = "GCPayout"
        Me.GCPayout.Size = New System.Drawing.Size(615, 325)
        Me.GCPayout.TabIndex = 22
        Me.GCPayout.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPayout})
        '
        'GVPayout
        '
        Me.GVPayout.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_list_payout_trans, Me.GridColumnnumber, Me.GridColumnamount, Me.GridColumntrans_fee, Me.GridColumnnett, Me.GridColumnreport_status})
        Me.GVPayout.GridControl = Me.GCPayout
        Me.GVPayout.Name = "GVPayout"
        Me.GVPayout.OptionsBehavior.ReadOnly = True
        Me.GVPayout.OptionsFind.AlwaysVisible = True
        Me.GVPayout.OptionsView.ColumnAutoWidth = False
        Me.GVPayout.OptionsView.ShowFooter = True
        Me.GVPayout.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_list_payout_trans
        '
        Me.GridColumnid_list_payout_trans.Caption = "id_list_payout_trans"
        Me.GridColumnid_list_payout_trans.FieldName = "id_list_payout_trans"
        Me.GridColumnid_list_payout_trans.Name = "GridColumnid_list_payout_trans"
        '
        'GridColumnnumber
        '
        Me.GridColumnnumber.Caption = "Number"
        Me.GridColumnnumber.FieldName = "number"
        Me.GridColumnnumber.Name = "GridColumnnumber"
        Me.GridColumnnumber.Visible = True
        Me.GridColumnnumber.VisibleIndex = 0
        '
        'GridColumnamount
        '
        Me.GridColumnamount.Caption = "Amount"
        Me.GridColumnamount.DisplayFormat.FormatString = "N2"
        Me.GridColumnamount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnamount.FieldName = "amount"
        Me.GridColumnamount.Name = "GridColumnamount"
        Me.GridColumnamount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N2}")})
        Me.GridColumnamount.Visible = True
        Me.GridColumnamount.VisibleIndex = 1
        '
        'GridColumntrans_fee
        '
        Me.GridColumntrans_fee.Caption = "Transaction Fee"
        Me.GridColumntrans_fee.DisplayFormat.FormatString = "N2"
        Me.GridColumntrans_fee.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntrans_fee.FieldName = "trans_fee"
        Me.GridColumntrans_fee.Name = "GridColumntrans_fee"
        Me.GridColumntrans_fee.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "trans_fee", "{0:N2}")})
        Me.GridColumntrans_fee.Visible = True
        Me.GridColumntrans_fee.VisibleIndex = 2
        '
        'GridColumnnett
        '
        Me.GridColumnnett.Caption = "Nett"
        Me.GridColumnnett.DisplayFormat.FormatString = "N2"
        Me.GridColumnnett.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnnett.FieldName = "nett"
        Me.GridColumnnett.Name = "GridColumnnett"
        Me.GridColumnnett.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "nett", "{0:N2}")})
        Me.GridColumnnett.Visible = True
        Me.GridColumnnett.VisibleIndex = 3
        '
        'GridColumnreport_status
        '
        Me.GridColumnreport_status.Caption = "Status"
        Me.GridColumnreport_status.FieldName = "report_status"
        Me.GridColumnreport_status.Name = "GridColumnreport_status"
        Me.GridColumnreport_status.Visible = True
        Me.GridColumnreport_status.VisibleIndex = 4
        '
        'FormPayoutHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(615, 378)
        Me.Controls.Add(Me.GCPayout)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormPayoutHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Payout History"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCPayout, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPayout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCPayout As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPayout As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_list_payout_trans As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnamount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntrans_fee As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnett As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GridColumnreport_status As DevExpress.XtraGrid.Columns.GridColumn
End Class
