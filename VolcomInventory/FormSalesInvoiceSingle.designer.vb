<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesInvoiceSingle
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
        Me.PanelControlNav = New DevExpress.XtraEditors.PanelControl
        Me.BtnChoose = New DevExpress.XtraEditors.SimpleButton
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.GroupControlSample = New DevExpress.XtraEditors.GroupControl
        Me.GCProduct = New DevExpress.XtraGrid.GridControl
        Me.GVProduct = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDesign = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDesignPriceType = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnAmount = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPOSNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdSalesPosDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdProduct = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdDesign = New DevExpress.XtraGrid.Columns.GridColumn
        Me.PanelControlImg = New DevExpress.XtraEditors.PanelControl
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit
        Me.BtnViewImg = New DevExpress.XtraEditors.SimpleButton
        Me.GridColumnRetailPrice = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNav.SuspendLayout()
        CType(Me.GroupControlSample, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlSample.SuspendLayout()
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlImg.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControlNav
        '
        Me.PanelControlNav.Controls.Add(Me.BtnChoose)
        Me.PanelControlNav.Controls.Add(Me.BtnCancel)
        Me.PanelControlNav.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControlNav.Location = New System.Drawing.Point(0, 262)
        Me.PanelControlNav.LookAndFeel.SkinName = "Blue"
        Me.PanelControlNav.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControlNav.Name = "PanelControlNav"
        Me.PanelControlNav.Size = New System.Drawing.Size(868, 47)
        Me.PanelControlNav.TabIndex = 5
        '
        'BtnChoose
        '
        Me.BtnChoose.Location = New System.Drawing.Point(783, 12)
        Me.BtnChoose.Name = "BtnChoose"
        Me.BtnChoose.Size = New System.Drawing.Size(75, 23)
        Me.BtnChoose.TabIndex = 0
        Me.BtnChoose.Text = "Choose"
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(702, 12)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "Cancel"
        '
        'GroupControlSample
        '
        Me.GroupControlSample.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupControlSample.Controls.Add(Me.GCProduct)
        Me.GroupControlSample.Controls.Add(Me.PanelControlImg)
        Me.GroupControlSample.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlSample.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlSample.Name = "GroupControlSample"
        Me.GroupControlSample.Size = New System.Drawing.Size(868, 262)
        Me.GroupControlSample.TabIndex = 7
        Me.GroupControlSample.Text = "Product"
        '
        'GCProduct
        '
        Me.GCProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProduct.Location = New System.Drawing.Point(168, 22)
        Me.GCProduct.MainView = Me.GVProduct
        Me.GCProduct.Name = "GCProduct"
        Me.GCProduct.Size = New System.Drawing.Size(698, 238)
        Me.GCProduct.TabIndex = 1
        Me.GCProduct.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProduct})
        '
        'GVProduct
        '
        Me.GVProduct.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnCode, Me.GridColumnColor, Me.GridColumnSize, Me.GridColumnDesign, Me.GridColumnDesignPriceType, Me.GridColumnPrice, Me.GridColumnRetailPrice, Me.GridColumnQty, Me.GridColumnAmount, Me.GridColumnPOSNumber, Me.GridColumnIdSalesPosDet, Me.GridColumnIdProduct, Me.GridColumnIdDesign})
        Me.GVProduct.GridControl = Me.GCProduct
        Me.GVProduct.Name = "GVProduct"
        Me.GVProduct.OptionsBehavior.ReadOnly = True
        Me.GVProduct.OptionsView.ShowFooter = True
        Me.GVProduct.OptionsView.ShowGroupPanel = False
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 1
        '
        'GridColumnColor
        '
        Me.GridColumnColor.Caption = "Color"
        Me.GridColumnColor.FieldName = "color"
        Me.GridColumnColor.Name = "GridColumnColor"
        Me.GridColumnColor.Visible = True
        Me.GridColumnColor.VisibleIndex = 3
        Me.GridColumnColor.Width = 83
        '
        'GridColumnSize
        '
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 4
        '
        'GridColumnDesign
        '
        Me.GridColumnDesign.Caption = "Name"
        Me.GridColumnDesign.FieldName = "name"
        Me.GridColumnDesign.FieldNameSortGroup = "id_design"
        Me.GridColumnDesign.Name = "GridColumnDesign"
        Me.GridColumnDesign.Visible = True
        Me.GridColumnDesign.VisibleIndex = 2
        '
        'GridColumnDesignPriceType
        '
        Me.GridColumnDesignPriceType.Caption = "Price Type"
        Me.GridColumnDesignPriceType.FieldName = "design_price_type"
        Me.GridColumnDesignPriceType.Name = "GridColumnDesignPriceType"
        Me.GridColumnDesignPriceType.Visible = True
        Me.GridColumnDesignPriceType.VisibleIndex = 5
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.Caption = "Del Price"
        Me.GridColumnPrice.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "design_price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 6
        '
        'GridColumnQty
        '
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.DisplayFormat.FormatString = "{0:f2}"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "sales_invoice_det_qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_invoice_det_qty", "{0:f2}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 8
        '
        'GridColumnAmount
        '
        Me.GridColumnAmount.Caption = "Amount"
        Me.GridColumnAmount.DisplayFormat.FormatString = "{0:f2}"
        Me.GridColumnAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAmount.FieldName = "sales_invoice_det_amount"
        Me.GridColumnAmount.Name = "GridColumnAmount"
        Me.GridColumnAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_invoice_det_amount", "{0:n2}")})
        Me.GridColumnAmount.Visible = True
        Me.GridColumnAmount.VisibleIndex = 9
        '
        'GridColumnPOSNumber
        '
        Me.GridColumnPOSNumber.Caption = "POS Number"
        Me.GridColumnPOSNumber.FieldName = "sales_pos_number"
        Me.GridColumnPOSNumber.Name = "GridColumnPOSNumber"
        Me.GridColumnPOSNumber.Visible = True
        Me.GridColumnPOSNumber.VisibleIndex = 0
        '
        'GridColumnIdSalesPosDet
        '
        Me.GridColumnIdSalesPosDet.Caption = "Id Sales POS Edit"
        Me.GridColumnIdSalesPosDet.FieldName = "id_sales_pos_det"
        Me.GridColumnIdSalesPosDet.Name = "GridColumnIdSalesPosDet"
        '
        'GridColumnIdProduct
        '
        Me.GridColumnIdProduct.Caption = "Id Product"
        Me.GridColumnIdProduct.FieldName = "id_product"
        Me.GridColumnIdProduct.Name = "GridColumnIdProduct"
        '
        'GridColumnIdDesign
        '
        Me.GridColumnIdDesign.Caption = "Id Design"
        Me.GridColumnIdDesign.FieldName = "id_design"
        Me.GridColumnIdDesign.Name = "GridColumnIdDesign"
        '
        'PanelControlImg
        '
        Me.PanelControlImg.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlImg.Controls.Add(Me.PictureEdit1)
        Me.PanelControlImg.Controls.Add(Me.BtnViewImg)
        Me.PanelControlImg.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControlImg.Location = New System.Drawing.Point(2, 22)
        Me.PanelControlImg.Name = "PanelControlImg"
        Me.PanelControlImg.Size = New System.Drawing.Size(166, 238)
        Me.PanelControlImg.TabIndex = 0
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureEdit1.Location = New System.Drawing.Point(0, 0)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.PictureEdit1.Properties.ShowMenu = False
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureEdit1.Size = New System.Drawing.Size(166, 215)
        Me.PictureEdit1.TabIndex = 3
        '
        'BtnViewImg
        '
        Me.BtnViewImg.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnViewImg.Location = New System.Drawing.Point(0, 215)
        Me.BtnViewImg.Name = "BtnViewImg"
        Me.BtnViewImg.Size = New System.Drawing.Size(166, 23)
        Me.BtnViewImg.TabIndex = 0
        Me.BtnViewImg.Text = "View Image"
        '
        'GridColumnRetailPrice
        '
        Me.GridColumnRetailPrice.Caption = "Price"
        Me.GridColumnRetailPrice.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnRetailPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnRetailPrice.FieldName = "design_price_retail"
        Me.GridColumnRetailPrice.Name = "GridColumnRetailPrice"
        Me.GridColumnRetailPrice.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "design_price_retail", "{0:n2}")})
        Me.GridColumnRetailPrice.Visible = True
        Me.GridColumnRetailPrice.VisibleIndex = 7
        '
        'FormSalesInvoiceSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 309)
        Me.Controls.Add(Me.GroupControlSample)
        Me.Controls.Add(Me.PanelControlNav)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSalesInvoiceSingle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Sales Transaction"
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNav.ResumeLayout(False)
        CType(Me.GroupControlSample, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlSample.ResumeLayout(False)
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlImg.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControlNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnChoose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControlSample As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCProduct As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProduct As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdProduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesignPriceType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControlImg As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents BtnViewImg As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSalesPosDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPOSNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRetailPrice As DevExpress.XtraGrid.Columns.GridColumn
End Class
