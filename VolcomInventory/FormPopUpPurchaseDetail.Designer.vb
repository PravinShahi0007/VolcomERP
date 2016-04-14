<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpPurchaseDetail
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.LabelSubTitle = New DevExpress.XtraEditors.LabelControl
        Me.LabelTitle = New DevExpress.XtraEditors.LabelControl
        Me.PCClose = New DevExpress.XtraEditors.PanelControl
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton
        Me.GCListPurchase = New DevExpress.XtraGrid.GridControl
        Me.GVListPurchase = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColDiscount = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSubtotal = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PCClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCClose.SuspendLayout()
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.Blue
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.Controls.Add(Me.LabelSubTitle)
        Me.PanelControl1.Controls.Add(Me.LabelTitle)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(831, 59)
        Me.PanelControl1.TabIndex = 31
        '
        'LabelSubTitle
        '
        Me.LabelSubTitle.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSubTitle.Location = New System.Drawing.Point(12, 32)
        Me.LabelSubTitle.Name = "LabelSubTitle"
        Me.LabelSubTitle.Size = New System.Drawing.Size(121, 15)
        Me.LabelSubTitle.TabIndex = 30
        Me.LabelSubTitle.Text = "Purchase Sample : xxx"
        '
        'LabelTitle
        '
        Me.LabelTitle.Appearance.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitle.Location = New System.Drawing.Point(12, 10)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(99, 23)
        Me.LabelTitle.TabIndex = 29
        Me.LabelTitle.Text = "Detail Order"
        '
        'PCClose
        '
        Me.PCClose.Controls.Add(Me.BtnSave)
        Me.PCClose.Controls.Add(Me.BtnClose)
        Me.PCClose.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PCClose.Location = New System.Drawing.Point(0, 359)
        Me.PCClose.LookAndFeel.SkinName = "Blue"
        Me.PCClose.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PCClose.Name = "PCClose"
        Me.PCClose.Size = New System.Drawing.Size(831, 52)
        Me.PCClose.TabIndex = 32
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(744, 14)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 1
        Me.BtnSave.Text = "Choose"
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(663, 14)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(75, 23)
        Me.BtnClose.TabIndex = 0
        Me.BtnClose.Text = "Cancel"
        '
        'GCListPurchase
        '
        Me.GCListPurchase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListPurchase.Location = New System.Drawing.Point(0, 59)
        Me.GCListPurchase.MainView = Me.GVListPurchase
        Me.GCListPurchase.Name = "GCListPurchase"
        Me.GCListPurchase.Size = New System.Drawing.Size(831, 300)
        Me.GCListPurchase.TabIndex = 33
        Me.GCListPurchase.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListPurchase})
        '
        'GVListPurchase
        '
        Me.GVListPurchase.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdPrice, Me.ColNo, Me.ColCode, Me.ColName, Me.ColPrice, Me.ColQty, Me.ColDiscount, Me.ColSubtotal})
        Me.GVListPurchase.GridControl = Me.GCListPurchase
        Me.GVListPurchase.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.GVListPurchase.Name = "GVListPurchase"
        Me.GVListPurchase.OptionsBehavior.Editable = False
        Me.GVListPurchase.OptionsView.ShowGroupPanel = False
        '
        'ColIdPrice
        '
        Me.ColIdPrice.Caption = "ID Price"
        Me.ColIdPrice.FieldName = "id_sample_purc_det"
        Me.ColIdPrice.Name = "ColIdPrice"
        '
        'ColNo
        '
        Me.ColNo.AppearanceCell.Options.UseTextOptions = True
        Me.ColNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColNo.Caption = "NO."
        Me.ColNo.FieldName = "no"
        Me.ColNo.Name = "ColNo"
        Me.ColNo.Visible = True
        Me.ColNo.VisibleIndex = 0
        Me.ColNo.Width = 30
        '
        'ColCode
        '
        Me.ColCode.Caption = "Code"
        Me.ColCode.FieldName = "code"
        Me.ColCode.Name = "ColCode"
        Me.ColCode.Visible = True
        Me.ColCode.VisibleIndex = 1
        Me.ColCode.Width = 140
        '
        'ColName
        '
        Me.ColName.Caption = "Name"
        Me.ColName.FieldName = "name"
        Me.ColName.Name = "ColName"
        Me.ColName.Visible = True
        Me.ColName.VisibleIndex = 2
        Me.ColName.Width = 235
        '
        'ColPrice
        '
        Me.ColPrice.AppearanceCell.Options.UseTextOptions = True
        Me.ColPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.ColPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.Caption = "Price"
        Me.ColPrice.DisplayFormat.FormatString = "N2"
        Me.ColPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColPrice.FieldName = "price"
        Me.ColPrice.Name = "ColPrice"
        Me.ColPrice.Visible = True
        Me.ColPrice.VisibleIndex = 3
        Me.ColPrice.Width = 140
        '
        'ColQty
        '
        Me.ColQty.AppearanceCell.Options.UseTextOptions = True
        Me.ColQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.AppearanceHeader.Options.UseTextOptions = True
        Me.ColQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.Caption = "Qty"
        Me.ColQty.DisplayFormat.FormatString = "N2"
        Me.ColQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColQty.FieldName = "qty"
        Me.ColQty.Name = "ColQty"
        Me.ColQty.Visible = True
        Me.ColQty.VisibleIndex = 5
        Me.ColQty.Width = 68
        '
        'ColDiscount
        '
        Me.ColDiscount.AppearanceCell.Options.UseTextOptions = True
        Me.ColDiscount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColDiscount.AppearanceHeader.Options.UseTextOptions = True
        Me.ColDiscount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColDiscount.Caption = "Discount"
        Me.ColDiscount.DisplayFormat.FormatString = "N2"
        Me.ColDiscount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColDiscount.FieldName = "discount"
        Me.ColDiscount.Name = "ColDiscount"
        Me.ColDiscount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.ColDiscount.Visible = True
        Me.ColDiscount.VisibleIndex = 4
        Me.ColDiscount.Width = 96
        '
        'ColSubtotal
        '
        Me.ColSubtotal.AppearanceCell.Options.UseTextOptions = True
        Me.ColSubtotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColSubtotal.AppearanceHeader.Options.UseTextOptions = True
        Me.ColSubtotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColSubtotal.Caption = "Sub Total"
        Me.ColSubtotal.DisplayFormat.FormatString = "N2"
        Me.ColSubtotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColSubtotal.FieldName = "total"
        Me.ColSubtotal.Name = "ColSubtotal"
        Me.ColSubtotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.ColSubtotal.Visible = True
        Me.ColSubtotal.VisibleIndex = 6
        Me.ColSubtotal.Width = 165
        '
        'FormPopUpPurchaseDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(831, 411)
        Me.Controls.Add(Me.GCListPurchase)
        Me.Controls.Add(Me.PCClose)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "FormPopUpPurchaseDetail"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detail Purchase"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.PCClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCClose.ResumeLayout(False)
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelSubTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PCClose As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCListPurchase As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListPurchase As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDiscount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSubtotal As DevExpress.XtraGrid.Columns.GridColumn
End Class
