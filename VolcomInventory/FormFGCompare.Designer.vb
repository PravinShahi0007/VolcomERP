<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGCompare
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFGCompare))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.BandedGridColumnCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnType = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnReff = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnReq = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnSource = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnSizeType = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn0 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnErp2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnErp3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnErp4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnErp5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnErp6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnErp7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnErp8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnErp9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnErp0 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnIsMatch = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
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
        Me.PanelControl1.Size = New System.Drawing.Size(961, 47)
        Me.PanelControl1.TabIndex = 0
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Left
        Me.SimpleButton1.Image = CType(resources.GetObject("SimpleButton1.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(2, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(151, 43)
        Me.SimpleButton1.TabIndex = 1
        Me.SimpleButton1.Text = "Load Stock Card BOF"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 47)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(961, 454)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1, Me.gridBand2, Me.gridBand3})
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumnCode, Me.BandedGridColumnType, Me.BandedGridColumnReff, Me.BandedGridColumnReq, Me.BandedGridColumnSource, Me.BandedGridColumnDate, Me.BandedGridColumnSizeType, Me.BandedGridColumn1, Me.BandedGridColumn2, Me.BandedGridColumn3, Me.BandedGridColumn4, Me.BandedGridColumn5, Me.BandedGridColumn6, Me.BandedGridColumn7, Me.BandedGridColumn8, Me.BandedGridColumn9, Me.BandedGridColumn0, Me.BandedGridColumnErp2, Me.BandedGridColumnErp3, Me.BandedGridColumnErp4, Me.BandedGridColumnErp5, Me.BandedGridColumnErp6, Me.BandedGridColumnErp7, Me.BandedGridColumnErp8, Me.BandedGridColumnErp9, Me.BandedGridColumnErp0, Me.BandedGridColumnIsMatch})
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
        Me.BandedGridColumnCode.Width = 62
        '
        'BandedGridColumnType
        '
        Me.BandedGridColumnType.Caption = "Type"
        Me.BandedGridColumnType.FieldName = "trstyp"
        Me.BandedGridColumnType.Name = "BandedGridColumnType"
        Me.BandedGridColumnType.Visible = True
        Me.BandedGridColumnType.Width = 62
        '
        'BandedGridColumnReff
        '
        Me.BandedGridColumnReff.Caption = "Reff"
        Me.BandedGridColumnReff.FieldName = "reff"
        Me.BandedGridColumnReff.Name = "BandedGridColumnReff"
        Me.BandedGridColumnReff.Visible = True
        Me.BandedGridColumnReff.Width = 62
        '
        'BandedGridColumnReq
        '
        Me.BandedGridColumnReq.Caption = "Req"
        Me.BandedGridColumnReq.FieldName = "req"
        Me.BandedGridColumnReq.Name = "BandedGridColumnReq"
        Me.BandedGridColumnReq.Visible = True
        Me.BandedGridColumnReq.Width = 62
        '
        'BandedGridColumnSource
        '
        Me.BandedGridColumnSource.Caption = "Source"
        Me.BandedGridColumnSource.FieldName = "source"
        Me.BandedGridColumnSource.Name = "BandedGridColumnSource"
        Me.BandedGridColumnSource.Visible = True
        Me.BandedGridColumnSource.Width = 62
        '
        'BandedGridColumnDate
        '
        Me.BandedGridColumnDate.Caption = "Date"
        Me.BandedGridColumnDate.FieldName = "date"
        Me.BandedGridColumnDate.Name = "BandedGridColumnDate"
        Me.BandedGridColumnDate.Visible = True
        Me.BandedGridColumnDate.Width = 62
        '
        'BandedGridColumnSizeType
        '
        Me.BandedGridColumnSizeType.Caption = "Size Type"
        Me.BandedGridColumnSizeType.FieldName = "sizetyp"
        Me.BandedGridColumnSizeType.Name = "BandedGridColumnSizeType"
        Me.BandedGridColumnSizeType.Visible = True
        Me.BandedGridColumnSizeType.Width = 94
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.Caption = "1"
        Me.BandedGridColumn1.FieldName = "qty1"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.Visible = True
        Me.BandedGridColumn1.Width = 53
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.Caption = "2"
        Me.BandedGridColumn2.FieldName = "qty2"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.Visible = True
        Me.BandedGridColumn2.Width = 48
        '
        'BandedGridColumn3
        '
        Me.BandedGridColumn3.Caption = "3"
        Me.BandedGridColumn3.FieldName = "qty3"
        Me.BandedGridColumn3.Name = "BandedGridColumn3"
        Me.BandedGridColumn3.Visible = True
        Me.BandedGridColumn3.Width = 51
        '
        'BandedGridColumn4
        '
        Me.BandedGridColumn4.Caption = "4"
        Me.BandedGridColumn4.FieldName = "qty4"
        Me.BandedGridColumn4.Name = "BandedGridColumn4"
        Me.BandedGridColumn4.Visible = True
        Me.BandedGridColumn4.Width = 50
        '
        'BandedGridColumn5
        '
        Me.BandedGridColumn5.Caption = "5"
        Me.BandedGridColumn5.FieldName = "qty5"
        Me.BandedGridColumn5.Name = "BandedGridColumn5"
        Me.BandedGridColumn5.Visible = True
        Me.BandedGridColumn5.Width = 49
        '
        'BandedGridColumn6
        '
        Me.BandedGridColumn6.Caption = "6"
        Me.BandedGridColumn6.FieldName = "qty6"
        Me.BandedGridColumn6.Name = "BandedGridColumn6"
        Me.BandedGridColumn6.Visible = True
        Me.BandedGridColumn6.Width = 51
        '
        'BandedGridColumn7
        '
        Me.BandedGridColumn7.Caption = "7"
        Me.BandedGridColumn7.FieldName = "qty7"
        Me.BandedGridColumn7.Name = "BandedGridColumn7"
        Me.BandedGridColumn7.Visible = True
        Me.BandedGridColumn7.Width = 54
        '
        'BandedGridColumn8
        '
        Me.BandedGridColumn8.Caption = "8"
        Me.BandedGridColumn8.FieldName = "qty8"
        Me.BandedGridColumn8.Name = "BandedGridColumn8"
        Me.BandedGridColumn8.Visible = True
        Me.BandedGridColumn8.Width = 54
        '
        'BandedGridColumn9
        '
        Me.BandedGridColumn9.Caption = "9"
        Me.BandedGridColumn9.FieldName = "qty9"
        Me.BandedGridColumn9.Name = "BandedGridColumn9"
        Me.BandedGridColumn9.Visible = True
        Me.BandedGridColumn9.Width = 57
        '
        'BandedGridColumn0
        '
        Me.BandedGridColumn0.Caption = "0"
        Me.BandedGridColumn0.FieldName = "qty10"
        Me.BandedGridColumn0.Name = "BandedGridColumn0"
        Me.BandedGridColumn0.Visible = True
        Me.BandedGridColumn0.Width = 105
        '
        'BandedGridColumnErp2
        '
        Me.BandedGridColumnErp2.Caption = "1"
        Me.BandedGridColumnErp2.Name = "BandedGridColumnErp2"
        Me.BandedGridColumnErp2.Visible = True
        Me.BandedGridColumnErp2.Width = 56
        '
        'BandedGridColumnErp3
        '
        Me.BandedGridColumnErp3.Caption = "2"
        Me.BandedGridColumnErp3.Name = "BandedGridColumnErp3"
        Me.BandedGridColumnErp3.Visible = True
        Me.BandedGridColumnErp3.Width = 56
        '
        'BandedGridColumnErp4
        '
        Me.BandedGridColumnErp4.Caption = "3"
        Me.BandedGridColumnErp4.Name = "BandedGridColumnErp4"
        Me.BandedGridColumnErp4.Visible = True
        Me.BandedGridColumnErp4.Width = 57
        '
        'BandedGridColumnErp5
        '
        Me.BandedGridColumnErp5.Caption = "4"
        Me.BandedGridColumnErp5.Name = "BandedGridColumnErp5"
        Me.BandedGridColumnErp5.Visible = True
        Me.BandedGridColumnErp5.Width = 58
        '
        'BandedGridColumnErp6
        '
        Me.BandedGridColumnErp6.Caption = "5"
        Me.BandedGridColumnErp6.Name = "BandedGridColumnErp6"
        Me.BandedGridColumnErp6.Visible = True
        Me.BandedGridColumnErp6.Width = 69
        '
        'BandedGridColumnErp7
        '
        Me.BandedGridColumnErp7.Caption = "6"
        Me.BandedGridColumnErp7.Name = "BandedGridColumnErp7"
        Me.BandedGridColumnErp7.Visible = True
        '
        'BandedGridColumnErp8
        '
        Me.BandedGridColumnErp8.Caption = "7"
        Me.BandedGridColumnErp8.Name = "BandedGridColumnErp8"
        Me.BandedGridColumnErp8.Visible = True
        '
        'BandedGridColumnErp9
        '
        Me.BandedGridColumnErp9.Caption = "8"
        Me.BandedGridColumnErp9.Name = "BandedGridColumnErp9"
        Me.BandedGridColumnErp9.Visible = True
        '
        'BandedGridColumnErp0
        '
        Me.BandedGridColumnErp0.Caption = "9"
        Me.BandedGridColumnErp0.Name = "BandedGridColumnErp0"
        Me.BandedGridColumnErp0.Visible = True
        '
        'BandedGridColumnIsMatch
        '
        Me.BandedGridColumnIsMatch.Caption = "Note"
        Me.BandedGridColumnIsMatch.FieldName = "is_match"
        Me.BandedGridColumnIsMatch.Name = "BandedGridColumnIsMatch"
        Me.BandedGridColumnIsMatch.Visible = True
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "BOF"
        Me.GridBand1.Columns.Add(Me.BandedGridColumnCode)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnType)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnDate)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnReff)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnReq)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnSource)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnSizeType)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn1)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn2)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn3)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn4)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn5)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn6)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn7)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn8)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn9)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn0)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 1038
        '
        'gridBand2
        '
        Me.gridBand2.Caption = "ERP"
        Me.gridBand2.Columns.Add(Me.BandedGridColumnErp2)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnErp3)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnErp4)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnErp5)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnErp6)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnErp7)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnErp8)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnErp9)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnErp0)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 1
        Me.gridBand2.Width = 596
        '
        'gridBand3
        '
        Me.gridBand3.Caption = "  "
        Me.gridBand3.Columns.Add(Me.BandedGridColumnIsMatch)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 2
        Me.gridBand3.Width = 75
        '
        'FormFGCompare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(961, 501)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormFGCompare"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
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
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnType As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnReff As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnReq As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnSource As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnSizeType As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn0 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnErp2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnErp3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnErp4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnErp5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnErp6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnErp7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnErp8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnErp9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnErp0 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnIsMatch As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
End Class
