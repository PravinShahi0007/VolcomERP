<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPriceForSync
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SBSync = New DevExpress.XtraEditors.SimpleButton()
        Me.GCBrowsePrice = New DevExpress.XtraGrid.GridControl()
        Me.GVBrowsePrice = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnFullCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNormalPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCBrowsePrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBrowsePrice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SBSync)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 52)
        Me.PanelControl1.TabIndex = 0
        '
        'SBSync
        '
        Me.SBSync.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SBSync.Location = New System.Drawing.Point(689, 5)
        Me.SBSync.Name = "SBSync"
        Me.SBSync.Size = New System.Drawing.Size(90, 41)
        Me.SBSync.TabIndex = 0
        Me.SBSync.Text = "Sync to Web"
        '
        'GCBrowsePrice
        '
        Me.GCBrowsePrice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCBrowsePrice.Location = New System.Drawing.Point(0, 52)
        Me.GCBrowsePrice.MainView = Me.GVBrowsePrice
        Me.GCBrowsePrice.Name = "GCBrowsePrice"
        Me.GCBrowsePrice.Size = New System.Drawing.Size(784, 509)
        Me.GCBrowsePrice.TabIndex = 91
        Me.GCBrowsePrice.TabStop = False
        Me.GCBrowsePrice.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBrowsePrice})
        '
        'GVBrowsePrice
        '
        Me.GVBrowsePrice.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnFullCode, Me.GridColumnDescription, Me.GridColumnPrice, Me.GridColumnNormalPrice})
        Me.GVBrowsePrice.GridControl = Me.GCBrowsePrice
        Me.GVBrowsePrice.Name = "GVBrowsePrice"
        Me.GVBrowsePrice.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVBrowsePrice.OptionsBehavior.Editable = False
        Me.GVBrowsePrice.OptionsSelection.MultiSelect = True
        Me.GVBrowsePrice.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.GVBrowsePrice.OptionsView.ShowGroupPanel = False
        '
        'GridColumnFullCode
        '
        Me.GridColumnFullCode.Caption = "Full Code"
        Me.GridColumnFullCode.FieldName = "product_full_code"
        Me.GridColumnFullCode.Name = "GridColumnFullCode"
        Me.GridColumnFullCode.Visible = True
        Me.GridColumnFullCode.VisibleIndex = 0
        '
        'GridColumnDescription
        '
        Me.GridColumnDescription.Caption = "Description"
        Me.GridColumnDescription.FieldName = "product_display_name"
        Me.GridColumnDescription.Name = "GridColumnDescription"
        Me.GridColumnDescription.Visible = True
        Me.GridColumnDescription.VisibleIndex = 1
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.Caption = "Price"
        Me.GridColumnPrice.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "design_price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 2
        '
        'GridColumnNormalPrice
        '
        Me.GridColumnNormalPrice.Caption = "Normal Price"
        Me.GridColumnNormalPrice.FieldName = "compare_price"
        Me.GridColumnNormalPrice.Name = "GridColumnNormalPrice"
        Me.GridColumnNormalPrice.Visible = True
        Me.GridColumnNormalPrice.VisibleIndex = 3
        '
        'FormPriceForSync
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GCBrowsePrice)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormPriceForSync"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Price for Sync"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCBrowsePrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBrowsePrice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCBrowsePrice As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVBrowsePrice As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnFullCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SBSync As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNormalPrice As DevExpress.XtraGrid.Columns.GridColumn
End Class
