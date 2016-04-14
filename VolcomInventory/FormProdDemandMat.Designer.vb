<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProdDemandMat
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
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        Me.GCMaterialList = New DevExpress.XtraGrid.GridControl
        Me.GVMaterialList = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdMatDetPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdCompContact = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdComp = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColCompName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColMatCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColMatName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColMatSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColQty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColUOM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColTotal = New DevExpress.XtraGrid.Columns.GridColumn
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl
        Me.LProdDemand = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.MENote = New DevExpress.XtraEditors.MemoEdit
        Me.BSearchCompShipTo = New DevExpress.XtraEditors.SimpleButton
        Me.MECompShipToAddress = New DevExpress.XtraEditors.MemoEdit
        Me.TECompShipToName = New DevExpress.XtraEditors.TextEdit
        Me.TECompShipTo = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.Cancel = New DevExpress.XtraEditors.SimpleButton
        Me.BCreate = New DevExpress.XtraEditors.SimpleButton
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GCMaterialList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMaterialList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MECompShipToAddress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECompShipToName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECompShipTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.GCMaterialList)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 41)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(984, 297)
        Me.GroupControl1.TabIndex = 8
        Me.GroupControl1.Text = "Material List"
        '
        'GCMaterialList
        '
        Me.GCMaterialList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMaterialList.Location = New System.Drawing.Point(2, 22)
        Me.GCMaterialList.MainView = Me.GVMaterialList
        Me.GCMaterialList.Name = "GCMaterialList"
        Me.GCMaterialList.Size = New System.Drawing.Size(980, 273)
        Me.GCMaterialList.TabIndex = 0
        Me.GCMaterialList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMaterialList})
        '
        'GVMaterialList
        '
        Me.GVMaterialList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdMatDetPrice, Me.ColIdCompContact, Me.ColIdComp, Me.ColCompName, Me.ColMatCode, Me.ColMatName, Me.ColMatSize, Me.ColQty, Me.ColUOM, Me.ColPrice, Me.ColTotal})
        Me.GVMaterialList.GridControl = Me.GCMaterialList
        Me.GVMaterialList.GroupCount = 1
        Me.GVMaterialList.Name = "GVMaterialList"
        Me.GVMaterialList.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVMaterialList.OptionsBehavior.Editable = False
        Me.GVMaterialList.OptionsView.ShowGroupPanel = False
        Me.GVMaterialList.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColIdComp, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'ColIdMatDetPrice
        '
        Me.ColIdMatDetPrice.Caption = "Id Mat Det price"
        Me.ColIdMatDetPrice.FieldName = "id_mat_det_price"
        Me.ColIdMatDetPrice.Name = "ColIdMatDetPrice"
        '
        'ColIdCompContact
        '
        Me.ColIdCompContact.Caption = "Id Comp Contact"
        Me.ColIdCompContact.FieldName = "id_comp_contact"
        Me.ColIdCompContact.Name = "ColIdCompContact"
        '
        'ColIdComp
        '
        Me.ColIdComp.Caption = "Vendor"
        Me.ColIdComp.FieldName = "id_comp"
        Me.ColIdComp.Name = "ColIdComp"
        '
        'ColCompName
        '
        Me.ColCompName.Caption = "Vendor"
        Me.ColCompName.FieldName = "comp_name"
        Me.ColCompName.Name = "ColCompName"
        '
        'ColMatCode
        '
        Me.ColMatCode.Caption = "Code"
        Me.ColMatCode.FieldName = "code"
        Me.ColMatCode.Name = "ColMatCode"
        Me.ColMatCode.Visible = True
        Me.ColMatCode.VisibleIndex = 0
        Me.ColMatCode.Width = 150
        '
        'ColMatName
        '
        Me.ColMatName.Caption = "Description"
        Me.ColMatName.FieldName = "name"
        Me.ColMatName.Name = "ColMatName"
        Me.ColMatName.Visible = True
        Me.ColMatName.VisibleIndex = 1
        Me.ColMatName.Width = 300
        '
        'ColMatSize
        '
        Me.ColMatSize.AppearanceCell.Options.UseTextOptions = True
        Me.ColMatSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColMatSize.AppearanceHeader.Options.UseTextOptions = True
        Me.ColMatSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColMatSize.Caption = "Size"
        Me.ColMatSize.FieldName = "size"
        Me.ColMatSize.Name = "ColMatSize"
        Me.ColMatSize.Visible = True
        Me.ColMatSize.VisibleIndex = 2
        Me.ColMatSize.Width = 57
        '
        'ColQty
        '
        Me.ColQty.AppearanceCell.Options.UseTextOptions = True
        Me.ColQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.AppearanceHeader.Options.UseTextOptions = True
        Me.ColQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.Caption = "Qty"
        Me.ColQty.FieldName = "qty"
        Me.ColQty.Name = "ColQty"
        Me.ColQty.Visible = True
        Me.ColQty.VisibleIndex = 3
        Me.ColQty.Width = 78
        '
        'ColUOM
        '
        Me.ColUOM.AppearanceCell.Options.UseTextOptions = True
        Me.ColUOM.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColUOM.AppearanceHeader.Options.UseTextOptions = True
        Me.ColUOM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColUOM.Caption = "UOM"
        Me.ColUOM.FieldName = "uom"
        Me.ColUOM.Name = "ColUOM"
        Me.ColUOM.Visible = True
        Me.ColUOM.VisibleIndex = 4
        Me.ColUOM.Width = 78
        '
        'ColPrice
        '
        Me.ColPrice.AppearanceCell.Options.UseTextOptions = True
        Me.ColPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.ColPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.Caption = "Price"
        Me.ColPrice.FieldName = "price"
        Me.ColPrice.Name = "ColPrice"
        Me.ColPrice.Visible = True
        Me.ColPrice.VisibleIndex = 5
        Me.ColPrice.Width = 120
        '
        'ColTotal
        '
        Me.ColTotal.AppearanceCell.Options.UseTextOptions = True
        Me.ColTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColTotal.AppearanceHeader.Options.UseTextOptions = True
        Me.ColTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColTotal.Caption = "Total"
        Me.ColTotal.FieldName = "total"
        Me.ColTotal.Name = "ColTotal"
        Me.ColTotal.Visible = True
        Me.ColTotal.VisibleIndex = 6
        Me.ColTotal.Width = 182
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.LProdDemand)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(984, 41)
        Me.PanelControl2.TabIndex = 7
        '
        'LProdDemand
        '
        Me.LProdDemand.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LProdDemand.Location = New System.Drawing.Point(153, 12)
        Me.LProdDemand.Name = "LProdDemand"
        Me.LProdDemand.Size = New System.Drawing.Size(6, 16)
        Me.LProdDemand.TabIndex = 1
        Me.LProdDemand.Text = "-"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(135, 16)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Production Demand :"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.MENote)
        Me.PanelControl1.Controls.Add(Me.BSearchCompShipTo)
        Me.PanelControl1.Controls.Add(Me.MECompShipToAddress)
        Me.PanelControl1.Controls.Add(Me.TECompShipToName)
        Me.PanelControl1.Controls.Add(Me.TECompShipTo)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.Cancel)
        Me.PanelControl1.Controls.Add(Me.BCreate)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 338)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(984, 104)
        Me.PanelControl1.TabIndex = 6
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.LabelControl3.Location = New System.Drawing.Point(428, 12)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(26, 16)
        Me.LabelControl3.TabIndex = 140
        Me.LabelControl3.Text = "Note"
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(470, 11)
        Me.MENote.Name = "MENote"
        Me.MENote.Properties.MaxLength = 100
        Me.MENote.Size = New System.Drawing.Size(316, 77)
        Me.MENote.TabIndex = 139
        '
        'BSearchCompShipTo
        '
        Me.BSearchCompShipTo.Location = New System.Drawing.Point(367, 11)
        Me.BSearchCompShipTo.Name = "BSearchCompShipTo"
        Me.BSearchCompShipTo.Size = New System.Drawing.Size(23, 20)
        Me.BSearchCompShipTo.TabIndex = 128
        Me.BSearchCompShipTo.Text = "..."
        '
        'MECompShipToAddress
        '
        Me.MECompShipToAddress.Location = New System.Drawing.Point(74, 37)
        Me.MECompShipToAddress.Name = "MECompShipToAddress"
        Me.MECompShipToAddress.Properties.MaxLength = 100
        Me.MECompShipToAddress.Properties.ReadOnly = True
        Me.MECompShipToAddress.Size = New System.Drawing.Size(316, 51)
        Me.MECompShipToAddress.TabIndex = 127
        '
        'TECompShipToName
        '
        Me.TECompShipToName.EditValue = ""
        Me.TECompShipToName.Location = New System.Drawing.Point(153, 11)
        Me.TECompShipToName.Name = "TECompShipToName"
        Me.TECompShipToName.Properties.EditValueChangedDelay = 1
        Me.TECompShipToName.Properties.ReadOnly = True
        Me.TECompShipToName.Size = New System.Drawing.Size(208, 20)
        Me.TECompShipToName.TabIndex = 126
        '
        'TECompShipTo
        '
        Me.TECompShipTo.EditValue = ""
        Me.TECompShipTo.Location = New System.Drawing.Point(74, 11)
        Me.TECompShipTo.Name = "TECompShipTo"
        Me.TECompShipTo.Properties.EditValueChangedDelay = 1
        Me.TECompShipTo.Properties.ReadOnly = True
        Me.TECompShipTo.Size = New System.Drawing.Size(73, 20)
        Me.TECompShipTo.TabIndex = 125
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.LabelControl2.Location = New System.Drawing.Point(13, 12)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(44, 16)
        Me.LabelControl2.TabIndex = 124
        Me.LabelControl2.Text = "Ship To"
        '
        'Cancel
        '
        Me.Cancel.Location = New System.Drawing.Point(816, 65)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(82, 23)
        Me.Cancel.TabIndex = 1
        Me.Cancel.Text = "Cancel"
        '
        'BCreate
        '
        Me.BCreate.Location = New System.Drawing.Point(904, 65)
        Me.BCreate.Name = "BCreate"
        Me.BCreate.Size = New System.Drawing.Size(76, 23)
        Me.BCreate.TabIndex = 0
        Me.BCreate.Text = "Generate"
        '
        'FormProdDemandMat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 442)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProdDemandMat"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generate Purchase Order Raw Material"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GCMaterialList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMaterialList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MECompShipToAddress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECompShipToName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECompShipTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCMaterialList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMaterialList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdMatDetPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdCompContact As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdComp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCompName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColMatCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColMatName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColMatSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LProdDemand As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents BSearchCompShipTo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents MECompShipToAddress As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents TECompShipToName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TECompShipTo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Cancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BCreate As DevExpress.XtraEditors.SimpleButton
End Class
