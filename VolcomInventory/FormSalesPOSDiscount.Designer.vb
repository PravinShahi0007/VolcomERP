<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesPOSDiscount
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSalesPOSDiscount))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnChoose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.GCOtherDiscount = New DevExpress.XtraGrid.GridControl()
        Me.GVOtherDiscount = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumncomp_commission = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBandAR = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnacc_name_ar = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnacc_description_ar = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBandSALES = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnacc_name_sales = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnacc_description_sales = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBandSALESRETURN = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnacc_name_sales_ret = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnacc_description_sales_ret = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCOtherDiscount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVOtherDiscount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Controls.Add(Me.BtnChoose)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 296)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 41)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnChoose
        '
        Me.BtnChoose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnChoose.Image = CType(resources.GetObject("BtnChoose.Image"), System.Drawing.Image)
        Me.BtnChoose.Location = New System.Drawing.Point(696, 2)
        Me.BtnChoose.Name = "BtnChoose"
        Me.BtnChoose.Size = New System.Drawing.Size(86, 37)
        Me.BtnChoose.TabIndex = 1
        Me.BtnChoose.Text = "Choose"
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(610, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(86, 37)
        Me.BtnCancel.TabIndex = 2
        Me.BtnCancel.Text = "Cancel"
        '
        'GCOtherDiscount
        '
        Me.GCOtherDiscount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCOtherDiscount.Location = New System.Drawing.Point(0, 0)
        Me.GCOtherDiscount.MainView = Me.GVOtherDiscount
        Me.GCOtherDiscount.Name = "GCOtherDiscount"
        Me.GCOtherDiscount.Size = New System.Drawing.Size(784, 296)
        Me.GCOtherDiscount.TabIndex = 2
        Me.GCOtherDiscount.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVOtherDiscount})
        '
        'GVOtherDiscount
        '
        Me.GVOtherDiscount.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand2, Me.gridBandAR, Me.GridBandSALES, Me.gridBandSALESRETURN})
        Me.GVOtherDiscount.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumncomp_commission, Me.BandedGridColumnacc_name_sales, Me.BandedGridColumnacc_description_sales, Me.BandedGridColumnacc_name_sales_ret, Me.BandedGridColumnacc_description_sales_ret, Me.BandedGridColumnacc_name_ar, Me.BandedGridColumnacc_description_ar})
        Me.GVOtherDiscount.GridControl = Me.GCOtherDiscount
        Me.GVOtherDiscount.Name = "GVOtherDiscount"
        Me.GVOtherDiscount.OptionsBehavior.Editable = False
        Me.GVOtherDiscount.OptionsFind.AlwaysVisible = True
        Me.GVOtherDiscount.OptionsView.ColumnAutoWidth = False
        Me.GVOtherDiscount.OptionsView.ShowGroupPanel = False
        '
        'gridBand2
        '
        Me.gridBand2.Columns.Add(Me.BandedGridColumncomp_commission)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 0
        Me.gridBand2.Width = 75
        '
        'BandedGridColumncomp_commission
        '
        Me.BandedGridColumncomp_commission.Caption = "Discount (%)"
        Me.BandedGridColumncomp_commission.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumncomp_commission.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumncomp_commission.FieldName = "comp_commission"
        Me.BandedGridColumncomp_commission.Name = "BandedGridColumncomp_commission"
        Me.BandedGridColumncomp_commission.Visible = True
        '
        'gridBandAR
        '
        Me.gridBandAR.Caption = "AR"
        Me.gridBandAR.Columns.Add(Me.BandedGridColumnacc_name_ar)
        Me.gridBandAR.Columns.Add(Me.BandedGridColumnacc_description_ar)
        Me.gridBandAR.Name = "gridBandAR"
        Me.gridBandAR.VisibleIndex = 1
        Me.gridBandAR.Width = 150
        '
        'BandedGridColumnacc_name_ar
        '
        Me.BandedGridColumnacc_name_ar.Caption = "Account"
        Me.BandedGridColumnacc_name_ar.FieldName = "acc_name_ar"
        Me.BandedGridColumnacc_name_ar.Name = "BandedGridColumnacc_name_ar"
        Me.BandedGridColumnacc_name_ar.Visible = True
        '
        'BandedGridColumnacc_description_ar
        '
        Me.BandedGridColumnacc_description_ar.Caption = "Description"
        Me.BandedGridColumnacc_description_ar.FieldName = "acc_description_ar"
        Me.BandedGridColumnacc_description_ar.Name = "BandedGridColumnacc_description_ar"
        Me.BandedGridColumnacc_description_ar.Visible = True
        '
        'GridBandSALES
        '
        Me.GridBandSALES.Caption = "SALES"
        Me.GridBandSALES.Columns.Add(Me.BandedGridColumnacc_name_sales)
        Me.GridBandSALES.Columns.Add(Me.BandedGridColumnacc_description_sales)
        Me.GridBandSALES.Name = "GridBandSALES"
        Me.GridBandSALES.VisibleIndex = 2
        Me.GridBandSALES.Width = 150
        '
        'BandedGridColumnacc_name_sales
        '
        Me.BandedGridColumnacc_name_sales.Caption = "Account"
        Me.BandedGridColumnacc_name_sales.FieldName = "acc_name_sales"
        Me.BandedGridColumnacc_name_sales.Name = "BandedGridColumnacc_name_sales"
        Me.BandedGridColumnacc_name_sales.Visible = True
        '
        'BandedGridColumnacc_description_sales
        '
        Me.BandedGridColumnacc_description_sales.Caption = "Description"
        Me.BandedGridColumnacc_description_sales.FieldName = "acc_description_sales"
        Me.BandedGridColumnacc_description_sales.Name = "BandedGridColumnacc_description_sales"
        Me.BandedGridColumnacc_description_sales.Visible = True
        '
        'gridBandSALESRETURN
        '
        Me.gridBandSALESRETURN.Caption = "SALES RETURN"
        Me.gridBandSALESRETURN.Columns.Add(Me.BandedGridColumnacc_name_sales_ret)
        Me.gridBandSALESRETURN.Columns.Add(Me.BandedGridColumnacc_description_sales_ret)
        Me.gridBandSALESRETURN.Name = "gridBandSALESRETURN"
        Me.gridBandSALESRETURN.VisibleIndex = 3
        Me.gridBandSALESRETURN.Width = 150
        '
        'BandedGridColumnacc_name_sales_ret
        '
        Me.BandedGridColumnacc_name_sales_ret.Caption = "Account"
        Me.BandedGridColumnacc_name_sales_ret.FieldName = "acc_name_sales_ret"
        Me.BandedGridColumnacc_name_sales_ret.Name = "BandedGridColumnacc_name_sales_ret"
        Me.BandedGridColumnacc_name_sales_ret.Visible = True
        '
        'BandedGridColumnacc_description_sales_ret
        '
        Me.BandedGridColumnacc_description_sales_ret.Caption = "Description"
        Me.BandedGridColumnacc_description_sales_ret.FieldName = "acc_description_sales_ret"
        Me.BandedGridColumnacc_description_sales_ret.Name = "BandedGridColumnacc_description_sales_ret"
        Me.BandedGridColumnacc_description_sales_ret.Visible = True
        '
        'FormSalesPOSDiscount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 337)
        Me.Controls.Add(Me.GCOtherDiscount)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormSalesPOSDiscount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Discount"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCOtherDiscount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVOtherDiscount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnChoose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCOtherDiscount As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVOtherDiscount As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumncomp_commission As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBandAR As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnacc_name_ar As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnacc_description_ar As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBandSALES As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnacc_name_sales As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnacc_description_sales As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBandSALESRETURN As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnacc_name_sales_ret As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnacc_description_sales_ret As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
End Class
