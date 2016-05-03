<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpMatRetProd
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
        Me.GroupGeneral = New DevExpress.XtraEditors.GroupControl
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit
        Me.BView = New DevExpress.XtraEditors.SimpleButton
        Me.GCMat = New DevExpress.XtraGrid.GridControl
        Me.GVMat = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnIdPLMRSDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPLMrs = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdPLMRS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdMatDetPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.PanelControlButton = New DevExpress.XtraEditors.PanelControl
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BSave = New DevExpress.XtraEditors.SimpleButton
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneral.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCMat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlButton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlButton.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupGeneral
        '
        Me.GroupGeneral.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupGeneral.Controls.Add(Me.PictureEdit1)
        Me.GroupGeneral.Controls.Add(Me.BView)
        Me.GroupGeneral.Controls.Add(Me.GCMat)
        Me.GroupGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupGeneral.Location = New System.Drawing.Point(0, 0)
        Me.GroupGeneral.Name = "GroupGeneral"
        Me.GroupGeneral.Size = New System.Drawing.Size(896, 273)
        Me.GroupGeneral.TabIndex = 41
        Me.GroupGeneral.Text = "Material"
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureEdit1.Location = New System.Drawing.Point(2, 22)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.Image
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureEdit1.Size = New System.Drawing.Size(210, 226)
        Me.PictureEdit1.TabIndex = 97
        '
        'BView
        '
        Me.BView.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BView.Location = New System.Drawing.Point(2, 248)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(210, 23)
        Me.BView.TabIndex = 96
        Me.BView.Text = "View"
        '
        'GCMat
        '
        Me.GCMat.Dock = System.Windows.Forms.DockStyle.Right
        Me.GCMat.Location = New System.Drawing.Point(212, 22)
        Me.GCMat.MainView = Me.GVMat
        Me.GCMat.Name = "GCMat"
        Me.GCMat.Size = New System.Drawing.Size(682, 249)
        Me.GCMat.TabIndex = 11
        Me.GCMat.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMat, Me.GridView3})
        '
        'GVMat
        '
        Me.GVMat.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdPLMRSDet, Me.GridColumn1, Me.GridColumn5, Me.GridColumn3, Me.GridColumn4, Me.ColSize, Me.GridColumnQty, Me.GridColumnColor, Me.GridColumnPLMrs, Me.GridColumnIdPLMRS, Me.GridColumn2, Me.GridColumnPrice, Me.GridColumnIdMatDetPrice})
        Me.GVMat.GridControl = Me.GCMat
        Me.GVMat.GroupCount = 1
        Me.GVMat.Name = "GVMat"
        Me.GVMat.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVMat.OptionsBehavior.Editable = False
        Me.GVMat.OptionsFind.AlwaysVisible = True
        Me.GVMat.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.GVMat.OptionsView.ShowGroupPanel = False
        Me.GVMat.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnPLMrs, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnIdPLMRSDet
        '
        Me.GridColumnIdPLMRSDet.Caption = "Id Packing List Det"
        Me.GridColumnIdPLMRSDet.FieldName = "id_pl_mrs_det"
        Me.GridColumnIdPLMRSDet.Name = "GridColumnIdPLMRSDet"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id Mat Det"
        Me.GridColumn1.FieldName = "id_mat_det"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Code"
        Me.GridColumn5.FieldName = "mat_det_code"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 0
        Me.GridColumn5.Width = 100
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Material"
        Me.GridColumn3.FieldName = "mat_det_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 210
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn4.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn4.Caption = "UOM"
        Me.GridColumn4.FieldName = "uom"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 5
        Me.GridColumn4.Width = 60
        '
        'ColSize
        '
        Me.ColSize.AppearanceCell.Options.UseTextOptions = True
        Me.ColSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColSize.AppearanceHeader.Options.UseTextOptions = True
        Me.ColSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColSize.Caption = "Size"
        Me.ColSize.FieldName = "size"
        Me.ColSize.Name = "ColSize"
        Me.ColSize.Visible = True
        Me.ColSize.VisibleIndex = 3
        Me.ColSize.Width = 48
        '
        'GridColumnQty
        '
        Me.GridColumnQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.Caption = "Stock Qty"
        Me.GridColumnQty.DisplayFormat.FormatString = "N2"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "qty_all_mat"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.Width = 100
        '
        'GridColumnColor
        '
        Me.GridColumnColor.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnColor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnColor.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnColor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnColor.Caption = "Color"
        Me.GridColumnColor.FieldName = "color"
        Me.GridColumnColor.Name = "GridColumnColor"
        Me.GridColumnColor.Visible = True
        Me.GridColumnColor.VisibleIndex = 2
        Me.GridColumnColor.Width = 60
        '
        'GridColumnPLMrs
        '
        Me.GridColumnPLMrs.Caption = "Packing List"
        Me.GridColumnPLMrs.FieldName = "pl_mrs_number"
        Me.GridColumnPLMrs.FieldNameSortGroup = "id_pl_mrs"
        Me.GridColumnPLMrs.Name = "GridColumnPLMrs"
        '
        'GridColumnIdPLMRS
        '
        Me.GridColumnIdPLMRS.Caption = "Id Packing List"
        Me.GridColumnIdPLMRS.FieldName = "id_pl_mrs"
        Me.GridColumnIdPLMRS.Name = "GridColumnIdPLMRS"
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn2.Caption = "Qty"
        Me.GridColumn2.DisplayFormat.FormatString = "N2"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn2.FieldName = "pl_mrs_det_qty"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 4
        Me.GridColumn2.Width = 74
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPrice.Caption = "Price"
        Me.GridColumnPrice.DisplayFormat.FormatString = "N2"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "pl_mrs_det_price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 6
        Me.GridColumnPrice.Width = 110
        '
        'GridColumnIdMatDetPrice
        '
        Me.GridColumnIdMatDetPrice.Caption = "Id Mat Det Price"
        Me.GridColumnIdMatDetPrice.FieldName = "id_mat_det_price"
        Me.GridColumnIdMatDetPrice.Name = "GridColumnIdMatDetPrice"
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.GCMat
        Me.GridView3.Name = "GridView3"
        '
        'PanelControlButton
        '
        Me.PanelControlButton.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlButton.Controls.Add(Me.BCancel)
        Me.PanelControlButton.Controls.Add(Me.BSave)
        Me.PanelControlButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControlButton.Location = New System.Drawing.Point(0, 273)
        Me.PanelControlButton.Name = "PanelControlButton"
        Me.PanelControlButton.Size = New System.Drawing.Size(896, 38)
        Me.PanelControlButton.TabIndex = 40
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Location = New System.Drawing.Point(738, 6)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(70, 23)
        Me.BCancel.TabIndex = 2
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Location = New System.Drawing.Point(814, 6)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(70, 23)
        Me.BSave.TabIndex = 1
        Me.BSave.Text = "Save"
        '
        'FormPopUpMatRetProd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(896, 311)
        Me.Controls.Add(Me.GroupGeneral)
        Me.Controls.Add(Me.PanelControlButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPopUpMatRetProd"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Material"
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneral.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCMat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlButton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlButton.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupGeneral As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCMat As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMat As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControlButton As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnPLMrs As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdPLMRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdPLMRSDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdMatDetPrice As DevExpress.XtraGrid.Columns.GridColumn
End Class
