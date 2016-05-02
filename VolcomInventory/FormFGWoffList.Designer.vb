<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGWoffList
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
        Me.GroupControl4 = New DevExpress.XtraEditors.GroupControl
        Me.DEUntilStockFG = New DevExpress.XtraEditors.DateEdit
        Me.LabelControl24 = New DevExpress.XtraEditors.LabelControl
        Me.SLEDesignStockSum = New DevExpress.XtraEditors.SearchLookUpEdit
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl
        Me.BtnViewStockSum = New DevExpress.XtraEditors.SimpleButton
        Me.GroupControlStockSum = New DevExpress.XtraEditors.GroupControl
        Me.GCFGStock = New DevExpress.XtraGrid.GridControl
        Me.BGVFGStock = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl4.SuspendLayout()
        CType(Me.DEUntilStockFG.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilStockFG.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEDesignStockSum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlStockSum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlStockSum.SuspendLayout()
        CType(Me.GCFGStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BGVFGStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl4
        '
        Me.GroupControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.GroupControl4.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl4.Controls.Add(Me.DEUntilStockFG)
        Me.GroupControl4.Controls.Add(Me.LabelControl24)
        Me.GroupControl4.Controls.Add(Me.SLEDesignStockSum)
        Me.GroupControl4.Controls.Add(Me.LabelControl8)
        Me.GroupControl4.Controls.Add(Me.BtnViewStockSum)
        Me.GroupControl4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl4.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl4.Name = "GroupControl4"
        Me.GroupControl4.Size = New System.Drawing.Size(1160, 64)
        Me.GroupControl4.TabIndex = 19
        Me.GroupControl4.Text = "Filter"
        '
        'DEUntilStockFG
        '
        Me.DEUntilStockFG.EditValue = Nothing
        Me.DEUntilStockFG.Location = New System.Drawing.Point(216, 21)
        Me.DEUntilStockFG.Name = "DEUntilStockFG"
        Me.DEUntilStockFG.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntilStockFG.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntilStockFG.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntilStockFG.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.DEUntilStockFG.Size = New System.Drawing.Size(153, 20)
        Me.DEUntilStockFG.TabIndex = 8898
        '
        'LabelControl24
        '
        Me.LabelControl24.Location = New System.Drawing.Point(216, 5)
        Me.LabelControl24.Name = "LabelControl24"
        Me.LabelControl24.Size = New System.Drawing.Size(62, 13)
        Me.LabelControl24.TabIndex = 8899
        Me.LabelControl24.Text = "List Per-Date"
        '
        'SLEDesignStockSum
        '
        Me.SLEDesignStockSum.Location = New System.Drawing.Point(27, 21)
        Me.SLEDesignStockSum.Name = "SLEDesignStockSum"
        Me.SLEDesignStockSum.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEDesignStockSum.Properties.View = Me.GridView2
        Me.SLEDesignStockSum.Size = New System.Drawing.Size(183, 20)
        Me.SLEDesignStockSum.TabIndex = 8894
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Description"
        Me.GridColumn1.FieldName = "label_design"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Color"
        Me.GridColumn3.FieldName = "color"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Division"
        Me.GridColumn4.FieldName = "product_division"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Source"
        Me.GridColumn5.FieldName = "product_source"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Branding"
        Me.GridColumn6.FieldName = "product_branding"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Location = New System.Drawing.Point(27, 5)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(32, 13)
        Me.LabelControl8.TabIndex = 11
        Me.LabelControl8.Text = "Design"
        '
        'BtnViewStockSum
        '
        Me.BtnViewStockSum.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnViewStockSum.Appearance.Options.UseFont = True
        Me.BtnViewStockSum.Location = New System.Drawing.Point(375, 18)
        Me.BtnViewStockSum.Name = "BtnViewStockSum"
        Me.BtnViewStockSum.Size = New System.Drawing.Size(60, 23)
        Me.BtnViewStockSum.TabIndex = 6
        Me.BtnViewStockSum.Text = "View"
        '
        'GroupControlStockSum
        '
        Me.GroupControlStockSum.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlStockSum.Controls.Add(Me.GCFGStock)
        Me.GroupControlStockSum.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlStockSum.Enabled = False
        Me.GroupControlStockSum.Location = New System.Drawing.Point(0, 64)
        Me.GroupControlStockSum.Name = "GroupControlStockSum"
        Me.GroupControlStockSum.Size = New System.Drawing.Size(1160, 424)
        Me.GroupControlStockSum.TabIndex = 20
        Me.GroupControlStockSum.Text = "Write Off List"
        '
        'GCFGStock
        '
        Me.GCFGStock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCFGStock.Location = New System.Drawing.Point(22, 2)
        Me.GCFGStock.MainView = Me.BGVFGStock
        Me.GCFGStock.Name = "GCFGStock"
        Me.GCFGStock.Size = New System.Drawing.Size(1136, 420)
        Me.GCFGStock.TabIndex = 38
        Me.GCFGStock.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BGVFGStock})
        '
        'BGVFGStock
        '
        Me.BGVFGStock.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn2})
        Me.BGVFGStock.GridControl = Me.GCFGStock
        Me.BGVFGStock.Name = "BGVFGStock"
        Me.BGVFGStock.OptionsBehavior.ReadOnly = True
        Me.BGVFGStock.OptionsView.ColumnAutoWidth = False
        Me.BGVFGStock.OptionsView.ShowFooter = True
        Me.BGVFGStock.OptionsView.ShowGroupPanel = False
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.Caption = "BandedGridColumn2"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.Visible = True
        '
        'FormFGWoffList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1160, 488)
        Me.Controls.Add(Me.GroupControlStockSum)
        Me.Controls.Add(Me.GroupControl4)
        Me.MinimizeBox = False
        Me.Name = "FormFGWoffList"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Write Off List"
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl4.ResumeLayout(False)
        Me.GroupControl4.PerformLayout()
        CType(Me.DEUntilStockFG.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilStockFG.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEDesignStockSum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlStockSum, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlStockSum.ResumeLayout(False)
        CType(Me.GCFGStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BGVFGStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl4 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents DEUntilStockFG As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl24 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEDesignStockSum As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnViewStockSum As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControlStockSum As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCFGStock As DevExpress.XtraGrid.GridControl
    Friend WithEvents BGVFGStock As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
End Class
