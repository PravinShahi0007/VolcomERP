<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpMatRetInv
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
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BSave = New DevExpress.XtraEditors.SimpleButton
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl
        Me.GroupGeneral = New DevExpress.XtraEditors.GroupControl
        Me.GCRetInProd = New DevExpress.XtraGrid.GridControl
        Me.GVRetInProd = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDesign = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCRetDetail = New DevExpress.XtraGrid.GridControl
        Me.GVRetDetail = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnIdRet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdSamplePurcDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnUOM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
        Me.GridColumnRemark = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdPLMRSDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnTotPrice = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneral.SuspendLayout()
        CType(Me.GCRetInProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRetInProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCRetDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRetDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.BCancel)
        Me.PanelControl2.Controls.Add(Me.BSave)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl2.Location = New System.Drawing.Point(0, 415)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(814, 42)
        Me.PanelControl2.TabIndex = 34
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Location = New System.Drawing.Point(663, 10)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(70, 23)
        Me.BCancel.TabIndex = 2
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Location = New System.Drawing.Point(739, 10)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(70, 23)
        Me.BSave.TabIndex = 1
        Me.BSave.Text = "Choose"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GroupGeneral)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GCRetDetail)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(814, 415)
        Me.SplitContainerControl1.SplitterPosition = 212
        Me.SplitContainerControl1.TabIndex = 33
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'GroupGeneral
        '
        Me.GroupGeneral.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupGeneral.Controls.Add(Me.GCRetInProd)
        Me.GroupGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupGeneral.Location = New System.Drawing.Point(0, 0)
        Me.GroupGeneral.Name = "GroupGeneral"
        Me.GroupGeneral.Size = New System.Drawing.Size(814, 212)
        Me.GroupGeneral.TabIndex = 15
        Me.GroupGeneral.Text = "Return List"
        '
        'GCRetInProd
        '
        Me.GCRetInProd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRetInProd.Location = New System.Drawing.Point(2, 22)
        Me.GCRetInProd.MainView = Me.GVRetInProd
        Me.GCRetInProd.Name = "GCRetInProd"
        Me.GCRetInProd.Size = New System.Drawing.Size(810, 188)
        Me.GCRetInProd.TabIndex = 5
        Me.GCRetInProd.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRetInProd})
        '
        'GVRetInProd
        '
        Me.GVRetInProd.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn20, Me.GridColumn22, Me.GridColumn23, Me.GridColumn25, Me.GridColumn26, Me.GridColumn27, Me.GridColumn28, Me.GridColumn1, Me.GridColumnDesign})
        Me.GVRetInProd.GridControl = Me.GCRetInProd
        Me.GVRetInProd.Name = "GVRetInProd"
        Me.GVRetInProd.OptionsBehavior.Editable = False
        Me.GVRetInProd.OptionsView.ShowGroupPanel = False
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "ID Sample Ret Out"
        Me.GridColumn20.FieldName = "id_mat_prod_ret_in"
        Me.GridColumn20.Name = "GridColumn20"
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "Number"
        Me.GridColumn22.FieldName = "mat_prod_ret_in_number"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 0
        Me.GridColumn22.Width = 68
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "From"
        Me.GridColumn23.FieldName = "comp_from"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 4
        Me.GridColumn23.Width = 126
        '
        'GridColumn25
        '
        Me.GridColumn25.Caption = "Return In Date"
        Me.GridColumn25.FieldName = "mat_prod_ret_in_date"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.Visible = True
        Me.GridColumn25.VisibleIndex = 5
        Me.GridColumn25.Width = 104
        '
        'GridColumn26
        '
        Me.GridColumn26.Caption = "PO Number"
        Me.GridColumn26.FieldName = "prod_order_number"
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.Visible = True
        Me.GridColumn26.VisibleIndex = 1
        Me.GridColumn26.Width = 77
        '
        'GridColumn27
        '
        Me.GridColumn27.Caption = "Status"
        Me.GridColumn27.FieldName = "report_status"
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.Visible = True
        Me.GridColumn27.VisibleIndex = 6
        Me.GridColumn27.Width = 71
        '
        'GridColumn28
        '
        Me.GridColumn28.Caption = "ID Report Status"
        Me.GridColumn28.FieldName = "id_report_status"
        Me.GridColumn28.Name = "GridColumn28"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "WO Number"
        Me.GridColumn1.FieldName = "prod_order_wo_number"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 2
        Me.GridColumn1.Width = 78
        '
        'GridColumnDesign
        '
        Me.GridColumnDesign.Caption = "Design"
        Me.GridColumnDesign.FieldName = "design_name"
        Me.GridColumnDesign.Name = "GridColumnDesign"
        Me.GridColumnDesign.Visible = True
        Me.GridColumnDesign.VisibleIndex = 3
        Me.GridColumnDesign.Width = 79
        '
        'GCRetDetail
        '
        Me.GCRetDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRetDetail.Location = New System.Drawing.Point(0, 0)
        Me.GCRetDetail.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCRetDetail.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GCRetDetail.MainView = Me.GVRetDetail
        Me.GCRetDetail.Name = "GCRetDetail"
        Me.GCRetDetail.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1})
        Me.GCRetDetail.Size = New System.Drawing.Size(814, 198)
        Me.GCRetDetail.TabIndex = 2
        Me.GCRetDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRetDetail})
        '
        'GVRetDetail
        '
        Me.GVRetDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdRet, Me.GridColumnIdSamplePurcDet, Me.GridColumnNo, Me.GridColumnName, Me.GridColumnCode, Me.GridColumnSize, Me.GridColumnUOM, Me.GridColumnQty, Me.GridColumnRemark, Me.GridColumnIdPLMRSDet, Me.GridColumnPrice, Me.GridColumnTotPrice})
        Me.GVRetDetail.GridControl = Me.GCRetDetail
        Me.GVRetDetail.Name = "GVRetDetail"
        Me.GVRetDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVRetDetail.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVRetDetail.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdRet
        '
        Me.GridColumnIdRet.Caption = "ID Ret"
        Me.GridColumnIdRet.FieldName = "id_mat_prod_ret_in_det"
        Me.GridColumnIdRet.Name = "GridColumnIdRet"
        Me.GridColumnIdRet.OptionsColumn.AllowEdit = False
        '
        'GridColumnIdSamplePurcDet
        '
        Me.GridColumnIdSamplePurcDet.Caption = "Id Sample Purc Det"
        Me.GridColumnIdSamplePurcDet.FieldName = "id_mat_prod_ret_det"
        Me.GridColumnIdSamplePurcDet.Name = "GridColumnIdSamplePurcDet"
        Me.GridColumnIdSamplePurcDet.OptionsColumn.AllowEdit = False
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.OptionsColumn.AllowEdit = False
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Name"
        Me.GridColumnName.FieldName = "mat_det_name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.OptionsColumn.AllowEdit = False
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 1
        Me.GridColumnName.Width = 157
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "mat_det_code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 0
        Me.GridColumnCode.Width = 92
        '
        'GridColumnSize
        '
        Me.GridColumnSize.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSize.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.OptionsColumn.AllowEdit = False
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 2
        Me.GridColumnSize.Width = 47
        '
        'GridColumnUOM
        '
        Me.GridColumnUOM.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnUOM.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnUOM.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnUOM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnUOM.Caption = "UOM"
        Me.GridColumnUOM.FieldName = "uom"
        Me.GridColumnUOM.Name = "GridColumnUOM"
        Me.GridColumnUOM.OptionsColumn.AllowEdit = False
        Me.GridColumnUOM.Visible = True
        Me.GridColumnUOM.VisibleIndex = 4
        Me.GridColumnUOM.Width = 66
        '
        'GridColumnQty
        '
        Me.GridColumnQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.GridColumnQty.FieldName = "mat_prod_ret_in_det_qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 3
        Me.GridColumnQty.Width = 79
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "f0"
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'GridColumnRemark
        '
        Me.GridColumnRemark.Caption = "Remark"
        Me.GridColumnRemark.FieldName = "mat_prod_ret_in_det_note"
        Me.GridColumnRemark.Name = "GridColumnRemark"
        Me.GridColumnRemark.OptionsColumn.ReadOnly = True
        Me.GridColumnRemark.Visible = True
        Me.GridColumnRemark.VisibleIndex = 7
        Me.GridColumnRemark.Width = 82
        '
        'GridColumnIdPLMRSDet
        '
        Me.GridColumnIdPLMRSDet.Caption = "Id PL Mrs Det"
        Me.GridColumnIdPLMRSDet.FieldName = "id_pl_mrs_det"
        Me.GridColumnIdPLMRSDet.Name = "GridColumnIdPLMRSDet"
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
        Me.GridColumnPrice.VisibleIndex = 5
        Me.GridColumnPrice.Width = 123
        '
        'GridColumnTotPrice
        '
        Me.GridColumnTotPrice.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnTotPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnTotPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotPrice.Caption = "Total Price"
        Me.GridColumnTotPrice.DisplayFormat.FormatString = "N2"
        Me.GridColumnTotPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotPrice.FieldName = "total_price"
        Me.GridColumnTotPrice.Name = "GridColumnTotPrice"
        Me.GridColumnTotPrice.Visible = True
        Me.GridColumnTotPrice.VisibleIndex = 6
        Me.GridColumnTotPrice.Width = 150
        '
        'FormPopUpMatRetInv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 457)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPopUpMatRetInv"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Return"
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneral.ResumeLayout(False)
        CType(Me.GCRetInProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRetInProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCRetDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRetDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupGeneral As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCRetInProd As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRetInProd As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCRetDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRetDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdRet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSamplePurcDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumnRemark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdPLMRSDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotPrice As DevExpress.XtraGrid.Columns.GridColumn
End Class
