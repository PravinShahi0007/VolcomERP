<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpPDDesign
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
        Me.GCDesign = New DevExpress.XtraGrid.GridControl
        Me.GVDesign = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnIdProdDemandDesign = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdDelivery = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdProdDemand = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDesignCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDesignName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSeasonOrign = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDelivery = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnProposePrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCategory = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnUSCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl
        Me.LPDNo = New DevExpress.XtraEditors.LabelControl
        Me.LabelPD = New DevExpress.XtraEditors.LabelControl
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BChoose = New DevExpress.XtraEditors.SimpleButton
        CType(Me.GCDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GCDesign
        '
        Me.GCDesign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDesign.Location = New System.Drawing.Point(0, 50)
        Me.GCDesign.MainView = Me.GVDesign
        Me.GCDesign.Name = "GCDesign"
        Me.GCDesign.Size = New System.Drawing.Size(844, 257)
        Me.GCDesign.TabIndex = 11
        Me.GCDesign.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDesign, Me.GridView4})
        '
        'GVDesign
        '
        Me.GVDesign.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdProdDemandDesign, Me.GridColumnIdDelivery, Me.GridColumnIdProdDemand, Me.GridColumn1, Me.GridColumnDesignCode, Me.GridColumnDesignName, Me.GridColumnColor, Me.GridColumnSeasonOrign, Me.GridColumnDelivery, Me.GridColumnProposePrice, Me.GridColumnCategory, Me.GridColumnUSCode})
        Me.GVDesign.GridControl = Me.GCDesign
        Me.GVDesign.Name = "GVDesign"
        Me.GVDesign.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVDesign.OptionsBehavior.Editable = False
        Me.GVDesign.OptionsFind.AlwaysVisible = True
        Me.GVDesign.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdProdDemandDesign
        '
        Me.GridColumnIdProdDemandDesign.Caption = "Id Production Demand Design"
        Me.GridColumnIdProdDemandDesign.FieldName = "id_prod_demand_design"
        Me.GridColumnIdProdDemandDesign.Name = "GridColumnIdProdDemandDesign"
        '
        'GridColumnIdDelivery
        '
        Me.GridColumnIdDelivery.Caption = "Id Delivery"
        Me.GridColumnIdDelivery.FieldName = "id_delivery"
        Me.GridColumnIdDelivery.Name = "GridColumnIdDelivery"
        '
        'GridColumnIdProdDemand
        '
        Me.GridColumnIdProdDemand.Caption = "Id Prod Demand"
        Me.GridColumnIdProdDemand.FieldName = "id_prod_demand"
        Me.GridColumnIdProdDemand.Name = "GridColumnIdProdDemand"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id Design"
        Me.GridColumn1.FieldName = "id_design"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumnDesignCode
        '
        Me.GridColumnDesignCode.Caption = "Code"
        Me.GridColumnDesignCode.FieldName = "design_code"
        Me.GridColumnDesignCode.Name = "GridColumnDesignCode"
        Me.GridColumnDesignCode.Visible = True
        Me.GridColumnDesignCode.VisibleIndex = 0
        '
        'GridColumnDesignName
        '
        Me.GridColumnDesignName.Caption = "Design"
        Me.GridColumnDesignName.FieldName = "design_name"
        Me.GridColumnDesignName.Name = "GridColumnDesignName"
        Me.GridColumnDesignName.Visible = True
        Me.GridColumnDesignName.VisibleIndex = 1
        '
        'GridColumnColor
        '
        Me.GridColumnColor.Caption = "Color"
        Me.GridColumnColor.FieldName = "color"
        Me.GridColumnColor.Name = "GridColumnColor"
        Me.GridColumnColor.Visible = True
        Me.GridColumnColor.VisibleIndex = 3
        '
        'GridColumnSeasonOrign
        '
        Me.GridColumnSeasonOrign.Caption = "Season Origin"
        Me.GridColumnSeasonOrign.FieldName = "season_orign"
        Me.GridColumnSeasonOrign.Name = "GridColumnSeasonOrign"
        Me.GridColumnSeasonOrign.Visible = True
        Me.GridColumnSeasonOrign.VisibleIndex = 4
        '
        'GridColumnDelivery
        '
        Me.GridColumnDelivery.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnDelivery.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridColumnDelivery.Caption = "Delivery"
        Me.GridColumnDelivery.FieldName = "delivery"
        Me.GridColumnDelivery.Name = "GridColumnDelivery"
        Me.GridColumnDelivery.Visible = True
        Me.GridColumnDelivery.VisibleIndex = 5
        '
        'GridColumnProposePrice
        '
        Me.GridColumnProposePrice.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnProposePrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridColumnProposePrice.Caption = "Propose Price"
        Me.GridColumnProposePrice.DisplayFormat.FormatString = "N2"
        Me.GridColumnProposePrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnProposePrice.FieldName = "prod_demand_design_propose_price"
        Me.GridColumnProposePrice.Name = "GridColumnProposePrice"
        Me.GridColumnProposePrice.Visible = True
        Me.GridColumnProposePrice.VisibleIndex = 6
        '
        'GridColumnCategory
        '
        Me.GridColumnCategory.Caption = "Category"
        Me.GridColumnCategory.FieldName = "category_design"
        Me.GridColumnCategory.Name = "GridColumnCategory"
        Me.GridColumnCategory.Visible = True
        Me.GridColumnCategory.VisibleIndex = 7
        '
        'GridColumnUSCode
        '
        Me.GridColumnUSCode.Caption = "US Code"
        Me.GridColumnUSCode.FieldName = "sample_us_code"
        Me.GridColumnUSCode.Name = "GridColumnUSCode"
        Me.GridColumnUSCode.Visible = True
        Me.GridColumnUSCode.VisibleIndex = 2
        '
        'GridView4
        '
        Me.GridView4.GridControl = Me.GCDesign
        Me.GridView4.Name = "GridView4"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.LPDNo)
        Me.PanelControl2.Controls.Add(Me.LabelPD)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(844, 50)
        Me.PanelControl2.TabIndex = 10
        '
        'LPDNo
        '
        Me.LPDNo.Appearance.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LPDNo.Location = New System.Drawing.Point(210, 12)
        Me.LPDNo.Name = "LPDNo"
        Me.LPDNo.Size = New System.Drawing.Size(10, 26)
        Me.LPDNo.TabIndex = 7
        Me.LPDNo.Text = "#"
        '
        'LabelPD
        '
        Me.LabelPD.Appearance.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPD.Location = New System.Drawing.Point(12, 12)
        Me.LabelPD.Name = "LabelPD"
        Me.LabelPD.Size = New System.Drawing.Size(192, 26)
        Me.LabelPD.TabIndex = 6
        Me.LabelPD.Text = "Production Demand  : "
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BCancel)
        Me.PanelControl1.Controls.Add(Me.BChoose)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 307)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(844, 37)
        Me.PanelControl1.TabIndex = 9
        '
        'BCancel
        '
        Me.BCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCancel.Enabled = False
        Me.BCancel.Location = New System.Drawing.Point(692, 2)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(75, 33)
        Me.BCancel.TabIndex = 2
        Me.BCancel.Text = "Cancel"
        '
        'BChoose
        '
        Me.BChoose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BChoose.Enabled = False
        Me.BChoose.Location = New System.Drawing.Point(767, 2)
        Me.BChoose.Name = "BChoose"
        Me.BChoose.Size = New System.Drawing.Size(75, 33)
        Me.BChoose.TabIndex = 1
        Me.BChoose.Text = "Choose"
        '
        'FormPopUpPDDesign
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(844, 344)
        Me.Controls.Add(Me.GCDesign)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPopUpPDDesign"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Design"
        CType(Me.GCDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCDesign As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDesign As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdProdDemandDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdDelivery As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdProdDemand As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesignCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesignName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeasonOrign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDelivery As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProposePrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUSCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LPDNo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelPD As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BChoose As DevExpress.XtraEditors.SimpleButton
End Class
