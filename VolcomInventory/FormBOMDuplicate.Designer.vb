<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBOMDuplicate
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
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl
        Me.TEMethod = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.TEProduct = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        Me.GCProduct = New DevExpress.XtraGrid.GridControl
        Me.GVProduct = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdProduct = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdDesign = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColNamaDesign = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColProductCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColProductname = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BDuplicate = New DevExpress.XtraEditors.SimpleButton
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.TEMethod.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEProduct.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl3
        '
        Me.PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl3.Controls.Add(Me.TEMethod)
        Me.PanelControl3.Controls.Add(Me.LabelControl1)
        Me.PanelControl3.Controls.Add(Me.TEProduct)
        Me.PanelControl3.Controls.Add(Me.LabelControl3)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl3.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(718, 109)
        Me.PanelControl3.TabIndex = 12
        '
        'TEMethod
        '
        Me.TEMethod.EditValue = ""
        Me.TEMethod.Enabled = False
        Me.TEMethod.Location = New System.Drawing.Point(12, 67)
        Me.TEMethod.Name = "TEMethod"
        Me.TEMethod.Properties.EditValueChangedDelay = 1
        Me.TEMethod.Size = New System.Drawing.Size(371, 20)
        Me.TEMethod.TabIndex = 89
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 50)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl1.TabIndex = 90
        Me.LabelControl1.Text = "BOM Method"
        '
        'TEProduct
        '
        Me.TEProduct.EditValue = ""
        Me.TEProduct.Enabled = False
        Me.TEProduct.Location = New System.Drawing.Point(12, 25)
        Me.TEProduct.Name = "TEProduct"
        Me.TEProduct.Properties.EditValueChangedDelay = 1
        Me.TEProduct.Size = New System.Drawing.Size(316, 20)
        Me.TEProduct.TabIndex = 87
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 8)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(64, 13)
        Me.LabelControl3.TabIndex = 88
        Me.LabelControl3.Text = "From Product"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.GCProduct)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl1.Location = New System.Drawing.Point(0, 109)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(718, 277)
        Me.GroupControl1.TabIndex = 11
        Me.GroupControl1.Text = "Duplicate to"
        '
        'GCProduct
        '
        Me.GCProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProduct.Location = New System.Drawing.Point(2, 22)
        Me.GCProduct.MainView = Me.GVProduct
        Me.GCProduct.Name = "GCProduct"
        Me.GCProduct.Size = New System.Drawing.Size(714, 253)
        Me.GCProduct.TabIndex = 2
        Me.GCProduct.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProduct})
        '
        'GVProduct
        '
        Me.GVProduct.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdProduct, Me.ColIdDesign, Me.ColIdSeason, Me.ColNamaDesign, Me.ColProductCode, Me.ColProductname, Me.ColSeason, Me.ColSize})
        Me.GVProduct.GridControl = Me.GCProduct
        Me.GVProduct.GroupCount = 2
        Me.GVProduct.Name = "GVProduct"
        Me.GVProduct.OptionsBehavior.Editable = False
        Me.GVProduct.OptionsFind.AlwaysVisible = True
        Me.GVProduct.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.GVProduct.OptionsView.ShowGroupPanel = False
        Me.GVProduct.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColSeason, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColNamaDesign, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColIdDesign, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'ColIdProduct
        '
        Me.ColIdProduct.Caption = "ID Product"
        Me.ColIdProduct.FieldName = "id_product"
        Me.ColIdProduct.Name = "ColIdProduct"
        '
        'ColIdDesign
        '
        Me.ColIdDesign.Caption = "ID Design"
        Me.ColIdDesign.FieldName = "id_design"
        Me.ColIdDesign.Name = "ColIdDesign"
        '
        'ColIdSeason
        '
        Me.ColIdSeason.Caption = "ID Season"
        Me.ColIdSeason.FieldName = "id_season"
        Me.ColIdSeason.Name = "ColIdSeason"
        '
        'ColNamaDesign
        '
        Me.ColNamaDesign.Caption = "Design"
        Me.ColNamaDesign.FieldName = "design_name"
        Me.ColNamaDesign.Name = "ColNamaDesign"
        '
        'ColProductCode
        '
        Me.ColProductCode.Caption = "Code"
        Me.ColProductCode.FieldName = "product_full_code"
        Me.ColProductCode.Name = "ColProductCode"
        Me.ColProductCode.Visible = True
        Me.ColProductCode.VisibleIndex = 0
        Me.ColProductCode.Width = 147
        '
        'ColProductname
        '
        Me.ColProductname.Caption = "Product"
        Me.ColProductname.FieldName = "product_name"
        Me.ColProductname.Name = "ColProductname"
        Me.ColProductname.Visible = True
        Me.ColProductname.VisibleIndex = 1
        Me.ColProductname.Width = 147
        '
        'ColSeason
        '
        Me.ColSeason.Caption = "Season"
        Me.ColSeason.FieldName = "season"
        Me.ColSeason.FieldNameSortGroup = "id_season"
        Me.ColSeason.Name = "ColSeason"
        Me.ColSeason.Visible = True
        Me.ColSeason.VisibleIndex = 3
        '
        'ColSize
        '
        Me.ColSize.Caption = "Size"
        Me.ColSize.FieldName = "Size"
        Me.ColSize.Name = "ColSize"
        Me.ColSize.Visible = True
        Me.ColSize.VisibleIndex = 2
        Me.ColSize.Width = 80
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.BCancel)
        Me.PanelControl2.Controls.Add(Me.BDuplicate)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 386)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(718, 45)
        Me.PanelControl2.TabIndex = 10
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Location = New System.Drawing.Point(528, 10)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(86, 23)
        Me.BCancel.TabIndex = 12
        Me.BCancel.Text = "Cancel"
        '
        'BDuplicate
        '
        Me.BDuplicate.Location = New System.Drawing.Point(620, 10)
        Me.BDuplicate.Name = "BDuplicate"
        Me.BDuplicate.Size = New System.Drawing.Size(86, 23)
        Me.BDuplicate.TabIndex = 11
        Me.BDuplicate.Text = "Duplicate"
        '
        'FormBOMDuplicate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(718, 431)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.PanelControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormBOMDuplicate"
        Me.ShowInTaskbar = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Duplicate BOM"
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.TEMethod.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEProduct.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TEMethod As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEProduct As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCProduct As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProduct As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdProduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNamaDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColProductCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColProductname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BDuplicate As DevExpress.XtraEditors.SimpleButton
End Class
