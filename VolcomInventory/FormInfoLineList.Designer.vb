<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInfoLineList
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
        Me.BtnChoose = New DevExpress.XtraEditors.SimpleButton
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.GCDesign = New DevExpress.XtraGrid.GridControl
        Me.GVDesign = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColID = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColDisplayName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColUOM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSampleSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSampleCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Orign = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnOrign = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnClass = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Controls.Add(Me.BtnChoose)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 394)
        Me.PanelControl1.LookAndFeel.SkinName = "Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(666, 32)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnChoose
        '
        Me.BtnChoose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnChoose.Location = New System.Drawing.Point(589, 2)
        Me.BtnChoose.Name = "BtnChoose"
        Me.BtnChoose.Size = New System.Drawing.Size(75, 28)
        Me.BtnChoose.TabIndex = 0
        Me.BtnChoose.Text = "Choose"
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.Location = New System.Drawing.Point(514, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 28)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "Cancel"
        '
        'GCDesign
        '
        Me.GCDesign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDesign.Location = New System.Drawing.Point(0, 0)
        Me.GCDesign.MainView = Me.GVDesign
        Me.GCDesign.Name = "GCDesign"
        Me.GCDesign.Size = New System.Drawing.Size(666, 394)
        Me.GCDesign.TabIndex = 4
        Me.GCDesign.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDesign, Me.GridView2})
        '
        'GVDesign
        '
        Me.GVDesign.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColID, Me.ColDisplayName, Me.ColName, Me.ColUOM, Me.ColSampleSeason, Me.ColSampleCode, Me.Orign, Me.ColIdSeason, Me.GridColumnColor, Me.GridColumnOrign, Me.GridColumnClass})
        Me.GVDesign.GridControl = Me.GCDesign
        Me.GVDesign.GroupCount = 1
        Me.GVDesign.Name = "GVDesign"
        Me.GVDesign.OptionsBehavior.Editable = False
        Me.GVDesign.OptionsCustomization.AllowGroup = False
        Me.GVDesign.OptionsView.ShowGroupPanel = False
        Me.GVDesign.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColIdSeason, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'ColID
        '
        Me.ColID.Caption = "Id Sample"
        Me.ColID.FieldName = "id_design"
        Me.ColID.Name = "ColID"
        '
        'ColDisplayName
        '
        Me.ColDisplayName.Caption = "Short Description"
        Me.ColDisplayName.FieldName = "design_display_name"
        Me.ColDisplayName.Name = "ColDisplayName"
        Me.ColDisplayName.Visible = True
        Me.ColDisplayName.VisibleIndex = 3
        Me.ColDisplayName.Width = 92
        '
        'ColName
        '
        Me.ColName.Caption = "Description"
        Me.ColName.FieldName = "design_name"
        Me.ColName.Name = "ColName"
        Me.ColName.Visible = True
        Me.ColName.VisibleIndex = 4
        Me.ColName.Width = 99
        '
        'ColUOM
        '
        Me.ColUOM.Caption = "UOM"
        Me.ColUOM.FieldName = "id_uom"
        Me.ColUOM.Name = "ColUOM"
        '
        'ColSampleSeason
        '
        Me.ColSampleSeason.Caption = "Season"
        Me.ColSampleSeason.FieldName = "season"
        Me.ColSampleSeason.Name = "ColSampleSeason"
        '
        'ColSampleCode
        '
        Me.ColSampleCode.Caption = "Code"
        Me.ColSampleCode.FieldName = "design_code"
        Me.ColSampleCode.Name = "ColSampleCode"
        Me.ColSampleCode.Visible = True
        Me.ColSampleCode.VisibleIndex = 2
        Me.ColSampleCode.Width = 92
        '
        'Orign
        '
        Me.Orign.Caption = "Design Orign"
        Me.Orign.FieldName = "orign"
        Me.Orign.Name = "Orign"
        Me.Orign.Visible = True
        Me.Orign.VisibleIndex = 6
        Me.Orign.Width = 120
        '
        'ColIdSeason
        '
        Me.ColIdSeason.Caption = "Season"
        Me.ColIdSeason.FieldName = "id_season"
        Me.ColIdSeason.Name = "ColIdSeason"
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
        Me.GridColumnColor.VisibleIndex = 5
        Me.GridColumnColor.Width = 67
        '
        'GridColumnOrign
        '
        Me.GridColumnOrign.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnOrign.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnOrign.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnOrign.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnOrign.Caption = "Source"
        Me.GridColumnOrign.FieldName = "product_source"
        Me.GridColumnOrign.Name = "GridColumnOrign"
        Me.GridColumnOrign.Visible = True
        Me.GridColumnOrign.VisibleIndex = 0
        Me.GridColumnOrign.Width = 69
        '
        'GridColumnClass
        '
        Me.GridColumnClass.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnClass.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnClass.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnClass.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnClass.Caption = "Class"
        Me.GridColumnClass.FieldName = "product_class_display"
        Me.GridColumnClass.Name = "GridColumnClass"
        Me.GridColumnClass.Visible = True
        Me.GridColumnClass.VisibleIndex = 1
        Me.GridColumnClass.Width = 64
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GCDesign
        Me.GridView2.Name = "GridView2"
        '
        'FormInfoLineList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(666, 426)
        Me.Controls.Add(Me.GCDesign)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormInfoLineList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Product Line List"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnChoose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCDesign As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDesign As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDisplayName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSampleSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSampleCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Orign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOrign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnClass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
