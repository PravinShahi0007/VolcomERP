<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormFGCompareStockCard
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.BandedGridColumnCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTRS = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnReff = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnERPNumber = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnSource = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumndate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnSizeTypBOF = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQty1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQty2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQty3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQty4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQty5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQty6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQty7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQty8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQty9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQty10 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQtyERP1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQtyERP2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQtyERP3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQtyERP4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQtyERP5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQtyERP6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQtyERP7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQtyERP8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQtyERP9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQtyERP10 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SimpleButton1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(656, 44)
        Me.PanelControl1.TabIndex = 0
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Left
        Me.SimpleButton1.Location = New System.Drawing.Point(2, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(100, 40)
        Me.SimpleButton1.TabIndex = 0
        Me.SimpleButton1.Text = "Load BOF XLS"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 44)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(656, 394)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand1, Me.gridBand2, Me.gridBand3})
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumnCode, Me.BandedGridColumnTRS, Me.BandedGridColumnReff, Me.BandedGridColumnERPNumber, Me.BandedGridColumnSource, Me.BandedGridColumndate, Me.BandedGridColumnSizeTypBOF, Me.BandedGridColumnQty1, Me.BandedGridColumnQty2, Me.BandedGridColumnQty3, Me.BandedGridColumnQty4, Me.BandedGridColumnQty5, Me.BandedGridColumnQty6, Me.BandedGridColumnQty7, Me.BandedGridColumnQty8, Me.BandedGridColumnQty9, Me.BandedGridColumnQty10, Me.BandedGridColumnQtyERP1, Me.BandedGridColumnQtyERP2, Me.BandedGridColumnQtyERP3, Me.BandedGridColumnQtyERP4, Me.BandedGridColumnQtyERP5, Me.BandedGridColumnQtyERP6, Me.BandedGridColumnQtyERP7, Me.BandedGridColumnQtyERP8, Me.BandedGridColumnQtyERP9, Me.BandedGridColumnQtyERP10, Me.BandedGridColumn1})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'BandedGridColumnCode
        '
        Me.BandedGridColumnCode.Caption = "Code"
        Me.BandedGridColumnCode.FieldName = "code"
        Me.BandedGridColumnCode.Name = "BandedGridColumnCode"
        Me.BandedGridColumnCode.Visible = True
        Me.BandedGridColumnCode.Width = 66
        '
        'BandedGridColumnTRS
        '
        Me.BandedGridColumnTRS.Caption = "Transaction"
        Me.BandedGridColumnTRS.FieldName = "trstyp"
        Me.BandedGridColumnTRS.Name = "BandedGridColumnTRS"
        Me.BandedGridColumnTRS.Visible = True
        Me.BandedGridColumnTRS.Width = 66
        '
        'BandedGridColumnReff
        '
        Me.BandedGridColumnReff.Caption = "Reff"
        Me.BandedGridColumnReff.FieldName = "reff"
        Me.BandedGridColumnReff.Name = "BandedGridColumnReff"
        Me.BandedGridColumnReff.Visible = True
        Me.BandedGridColumnReff.Width = 66
        '
        'BandedGridColumnERPNumber
        '
        Me.BandedGridColumnERPNumber.Caption = "ERP No."
        Me.BandedGridColumnERPNumber.FieldName = "req"
        Me.BandedGridColumnERPNumber.Name = "BandedGridColumnERPNumber"
        Me.BandedGridColumnERPNumber.Visible = True
        Me.BandedGridColumnERPNumber.Width = 66
        '
        'BandedGridColumnSource
        '
        Me.BandedGridColumnSource.Caption = "Source"
        Me.BandedGridColumnSource.FieldName = "source"
        Me.BandedGridColumnSource.Name = "BandedGridColumnSource"
        Me.BandedGridColumnSource.Visible = True
        Me.BandedGridColumnSource.Width = 66
        '
        'BandedGridColumndate
        '
        Me.BandedGridColumndate.Caption = "Date"
        Me.BandedGridColumndate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.BandedGridColumndate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumndate.FieldName = "date"
        Me.BandedGridColumndate.Name = "BandedGridColumndate"
        Me.BandedGridColumndate.Visible = True
        Me.BandedGridColumndate.Width = 66
        '
        'BandedGridColumnSizeTypBOF
        '
        Me.BandedGridColumnSizeTypBOF.Caption = "Size Type"
        Me.BandedGridColumnSizeTypBOF.FieldName = "sizetyp"
        Me.BandedGridColumnSizeTypBOF.Name = "BandedGridColumnSizeTypBOF"
        Me.BandedGridColumnSizeTypBOF.Visible = True
        Me.BandedGridColumnSizeTypBOF.Width = 66
        '
        'BandedGridColumnQty1
        '
        Me.BandedGridColumnQty1.Caption = "1"
        Me.BandedGridColumnQty1.FieldName = "qty1"
        Me.BandedGridColumnQty1.Name = "BandedGridColumnQty1"
        Me.BandedGridColumnQty1.Visible = True
        Me.BandedGridColumnQty1.Width = 62
        '
        'BandedGridColumnQty2
        '
        Me.BandedGridColumnQty2.Caption = "2"
        Me.BandedGridColumnQty2.FieldName = "qty2"
        Me.BandedGridColumnQty2.Name = "BandedGridColumnQty2"
        Me.BandedGridColumnQty2.Visible = True
        Me.BandedGridColumnQty2.Width = 56
        '
        'BandedGridColumnQty3
        '
        Me.BandedGridColumnQty3.Caption = "3"
        Me.BandedGridColumnQty3.FieldName = "qty3"
        Me.BandedGridColumnQty3.Name = "BandedGridColumnQty3"
        Me.BandedGridColumnQty3.Visible = True
        Me.BandedGridColumnQty3.Width = 51
        '
        'BandedGridColumnQty4
        '
        Me.BandedGridColumnQty4.Caption = "4"
        Me.BandedGridColumnQty4.FieldName = "qty4"
        Me.BandedGridColumnQty4.Name = "BandedGridColumnQty4"
        Me.BandedGridColumnQty4.Visible = True
        Me.BandedGridColumnQty4.Width = 58
        '
        'BandedGridColumnQty5
        '
        Me.BandedGridColumnQty5.Caption = "5"
        Me.BandedGridColumnQty5.FieldName = "qty5"
        Me.BandedGridColumnQty5.Name = "BandedGridColumnQty5"
        Me.BandedGridColumnQty5.Visible = True
        Me.BandedGridColumnQty5.Width = 58
        '
        'BandedGridColumnQty6
        '
        Me.BandedGridColumnQty6.Caption = "6"
        Me.BandedGridColumnQty6.FieldName = "qty6"
        Me.BandedGridColumnQty6.Name = "BandedGridColumnQty6"
        Me.BandedGridColumnQty6.Visible = True
        Me.BandedGridColumnQty6.Width = 53
        '
        'BandedGridColumnQty7
        '
        Me.BandedGridColumnQty7.Caption = "7"
        Me.BandedGridColumnQty7.FieldName = "qty7"
        Me.BandedGridColumnQty7.Name = "BandedGridColumnQty7"
        Me.BandedGridColumnQty7.Visible = True
        Me.BandedGridColumnQty7.Width = 58
        '
        'BandedGridColumnQty8
        '
        Me.BandedGridColumnQty8.Caption = "8"
        Me.BandedGridColumnQty8.FieldName = "qty8"
        Me.BandedGridColumnQty8.Name = "BandedGridColumnQty8"
        Me.BandedGridColumnQty8.Visible = True
        Me.BandedGridColumnQty8.Width = 64
        '
        'BandedGridColumnQty9
        '
        Me.BandedGridColumnQty9.Caption = "9"
        Me.BandedGridColumnQty9.FieldName = "qty9"
        Me.BandedGridColumnQty9.Name = "BandedGridColumnQty9"
        Me.BandedGridColumnQty9.Visible = True
        Me.BandedGridColumnQty9.Width = 62
        '
        'BandedGridColumnQty10
        '
        Me.BandedGridColumnQty10.Caption = "0"
        Me.BandedGridColumnQty10.FieldName = "qty10"
        Me.BandedGridColumnQty10.Name = "BandedGridColumnQty10"
        Me.BandedGridColumnQty10.Visible = True
        Me.BandedGridColumnQty10.Width = 93
        '
        'BandedGridColumnQtyERP1
        '
        Me.BandedGridColumnQtyERP1.Caption = "1"
        Me.BandedGridColumnQtyERP1.FieldName = "qtyerp1"
        Me.BandedGridColumnQtyERP1.Name = "BandedGridColumnQtyERP1"
        Me.BandedGridColumnQtyERP1.Visible = True
        Me.BandedGridColumnQtyERP1.Width = 60
        '
        'BandedGridColumnQtyERP2
        '
        Me.BandedGridColumnQtyERP2.Caption = "2"
        Me.BandedGridColumnQtyERP2.FieldName = "qtyerp2"
        Me.BandedGridColumnQtyERP2.Name = "BandedGridColumnQtyERP2"
        Me.BandedGridColumnQtyERP2.Visible = True
        '
        'BandedGridColumnQtyERP3
        '
        Me.BandedGridColumnQtyERP3.Caption = "3"
        Me.BandedGridColumnQtyERP3.FieldName = "qtyerp3"
        Me.BandedGridColumnQtyERP3.Name = "BandedGridColumnQtyERP3"
        Me.BandedGridColumnQtyERP3.Visible = True
        '
        'BandedGridColumnQtyERP4
        '
        Me.BandedGridColumnQtyERP4.Caption = "4"
        Me.BandedGridColumnQtyERP4.FieldName = "qtyerp4"
        Me.BandedGridColumnQtyERP4.Name = "BandedGridColumnQtyERP4"
        Me.BandedGridColumnQtyERP4.Visible = True
        '
        'BandedGridColumnQtyERP5
        '
        Me.BandedGridColumnQtyERP5.Caption = "5"
        Me.BandedGridColumnQtyERP5.FieldName = "qtyerp5"
        Me.BandedGridColumnQtyERP5.Name = "BandedGridColumnQtyERP5"
        Me.BandedGridColumnQtyERP5.Visible = True
        '
        'BandedGridColumnQtyERP6
        '
        Me.BandedGridColumnQtyERP6.Caption = "6"
        Me.BandedGridColumnQtyERP6.FieldName = "qtyerp6"
        Me.BandedGridColumnQtyERP6.Name = "BandedGridColumnQtyERP6"
        Me.BandedGridColumnQtyERP6.Visible = True
        '
        'BandedGridColumnQtyERP7
        '
        Me.BandedGridColumnQtyERP7.Caption = "7"
        Me.BandedGridColumnQtyERP7.FieldName = "qtyerp7"
        Me.BandedGridColumnQtyERP7.Name = "BandedGridColumnQtyERP7"
        Me.BandedGridColumnQtyERP7.Visible = True
        '
        'BandedGridColumnQtyERP8
        '
        Me.BandedGridColumnQtyERP8.Caption = "8"
        Me.BandedGridColumnQtyERP8.FieldName = "qtyerp8"
        Me.BandedGridColumnQtyERP8.Name = "BandedGridColumnQtyERP8"
        Me.BandedGridColumnQtyERP8.Visible = True
        '
        'BandedGridColumnQtyERP9
        '
        Me.BandedGridColumnQtyERP9.Caption = "9"
        Me.BandedGridColumnQtyERP9.FieldName = "qtyerp9"
        Me.BandedGridColumnQtyERP9.Name = "BandedGridColumnQtyERP9"
        Me.BandedGridColumnQtyERP9.Visible = True
        '
        'BandedGridColumnQtyERP10
        '
        Me.BandedGridColumnQtyERP10.Caption = "0"
        Me.BandedGridColumnQtyERP10.FieldName = "qtyerp10"
        Me.BandedGridColumnQtyERP10.Name = "BandedGridColumnQtyERP10"
        Me.BandedGridColumnQtyERP10.Visible = True
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.Caption = "Note"
        Me.BandedGridColumn1.FieldName = "note"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.UnboundExpression = "Iif([req] = '', 'Not found in ERP', 'OK')"
        Me.BandedGridColumn1.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.BandedGridColumn1.Visible = True
        '
        'gridBand1
        '
        Me.gridBand1.Caption = "BOF"
        Me.gridBand1.Columns.Add(Me.BandedGridColumnCode)
        Me.gridBand1.Columns.Add(Me.BandedGridColumnTRS)
        Me.gridBand1.Columns.Add(Me.BandedGridColumnReff)
        Me.gridBand1.Columns.Add(Me.BandedGridColumnERPNumber)
        Me.gridBand1.Columns.Add(Me.BandedGridColumnSource)
        Me.gridBand1.Columns.Add(Me.BandedGridColumndate)
        Me.gridBand1.Columns.Add(Me.BandedGridColumnSizeTypBOF)
        Me.gridBand1.Columns.Add(Me.BandedGridColumnQty1)
        Me.gridBand1.Columns.Add(Me.BandedGridColumnQty2)
        Me.gridBand1.Columns.Add(Me.BandedGridColumnQty3)
        Me.gridBand1.Columns.Add(Me.BandedGridColumnQty4)
        Me.gridBand1.Columns.Add(Me.BandedGridColumnQty5)
        Me.gridBand1.Columns.Add(Me.BandedGridColumnQty6)
        Me.gridBand1.Columns.Add(Me.BandedGridColumnQty7)
        Me.gridBand1.Columns.Add(Me.BandedGridColumnQty8)
        Me.gridBand1.Columns.Add(Me.BandedGridColumnQty9)
        Me.gridBand1.Columns.Add(Me.BandedGridColumnQty10)
        Me.gridBand1.Name = "gridBand1"
        Me.gridBand1.VisibleIndex = 0
        Me.gridBand1.Width = 1077
        '
        'gridBand2
        '
        Me.gridBand2.Caption = "ERP"
        Me.gridBand2.Columns.Add(Me.BandedGridColumnQtyERP1)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnQtyERP2)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnQtyERP3)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnQtyERP4)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnQtyERP5)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnQtyERP6)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnQtyERP7)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnQtyERP8)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnQtyERP9)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnQtyERP10)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 1
        Me.gridBand2.Width = 735
        '
        'gridBand3
        '
        Me.gridBand3.Caption = "  "
        Me.gridBand3.Columns.Add(Me.BandedGridColumn1)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 2
        Me.gridBand3.Width = 75
        '
        'FormFGCompareStockCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(656, 438)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormFGCompareStockCard"
        Me.Text = "Compare Stock Card"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents BandedGridColumnCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTRS As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnReff As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnERPNumber As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnSource As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumndate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnSizeTypBOF As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQty1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQty2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQty3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQty4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQty5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQty6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQty7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQty8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQty9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQty10 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQtyERP1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQtyERP2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQtyERP3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQtyERP4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQtyERP5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQtyERP6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQtyERP7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQtyERP8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQtyERP9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQtyERP10 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
End Class
