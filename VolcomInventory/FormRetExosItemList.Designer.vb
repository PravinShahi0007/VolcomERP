<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRetExosItemList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormRetExosItemList))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnDiscard = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_product = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnclass = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsht = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncolor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnqty_avl = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnqty_input = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.GridColumndesign_price_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CESelectAll = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CESelectAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.CESelectAll)
        Me.PanelControl1.Controls.Add(Me.BtnDiscard)
        Me.PanelControl1.Controls.Add(Me.BtnAdd)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 289)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(556, 46)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnDiscard
        '
        Me.BtnDiscard.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDiscard.Image = CType(resources.GetObject("BtnDiscard.Image"), System.Drawing.Image)
        Me.BtnDiscard.Location = New System.Drawing.Point(390, 2)
        Me.BtnDiscard.Name = "BtnDiscard"
        Me.BtnDiscard.Size = New System.Drawing.Size(88, 42)
        Me.BtnDiscard.TabIndex = 2
        Me.BtnDiscard.Text = "Discard"
        '
        'BtnAdd
        '
        Me.BtnAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"), System.Drawing.Image)
        Me.BtnAdd.Location = New System.Drawing.Point(478, 2)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(76, 42)
        Me.BtnAdd.TabIndex = 1
        Me.BtnAdd.Text = "Add"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1})
        Me.GCData.Size = New System.Drawing.Size(556, 289)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_product, Me.GridColumncode, Me.GridColumnclass, Me.GridColumnname, Me.GridColumnsht, Me.GridColumncolor, Me.GridColumnqty_avl, Me.GridColumnqty_input, Me.GridColumndesign_price_type, Me.GridColumnsize})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_product
        '
        Me.GridColumnid_product.Caption = "id_product"
        Me.GridColumnid_product.FieldName = "id_product"
        Me.GridColumnid_product.Name = "GridColumnid_product"
        Me.GridColumnid_product.OptionsColumn.AllowEdit = False
        '
        'GridColumncode
        '
        Me.GridColumncode.Caption = "Code"
        Me.GridColumncode.FieldName = "code"
        Me.GridColumncode.Name = "GridColumncode"
        Me.GridColumncode.OptionsColumn.AllowEdit = False
        Me.GridColumncode.Visible = True
        Me.GridColumncode.VisibleIndex = 0
        Me.GridColumncode.Width = 222
        '
        'GridColumnclass
        '
        Me.GridColumnclass.Caption = "Class"
        Me.GridColumnclass.FieldName = "class"
        Me.GridColumnclass.Name = "GridColumnclass"
        Me.GridColumnclass.OptionsColumn.AllowEdit = False
        Me.GridColumnclass.Visible = True
        Me.GridColumnclass.VisibleIndex = 1
        Me.GridColumnclass.Width = 222
        '
        'GridColumnname
        '
        Me.GridColumnname.Caption = "Description"
        Me.GridColumnname.FieldName = "name"
        Me.GridColumnname.Name = "GridColumnname"
        Me.GridColumnname.OptionsColumn.AllowEdit = False
        Me.GridColumnname.Visible = True
        Me.GridColumnname.VisibleIndex = 2
        Me.GridColumnname.Width = 222
        '
        'GridColumnsht
        '
        Me.GridColumnsht.Caption = "Silhouette"
        Me.GridColumnsht.FieldName = "sht"
        Me.GridColumnsht.Name = "GridColumnsht"
        Me.GridColumnsht.OptionsColumn.AllowEdit = False
        Me.GridColumnsht.Visible = True
        Me.GridColumnsht.VisibleIndex = 3
        Me.GridColumnsht.Width = 222
        '
        'GridColumncolor
        '
        Me.GridColumncolor.Caption = "Color"
        Me.GridColumncolor.FieldName = "color"
        Me.GridColumncolor.Name = "GridColumncolor"
        Me.GridColumncolor.OptionsColumn.AllowEdit = False
        Me.GridColumncolor.Visible = True
        Me.GridColumncolor.VisibleIndex = 4
        Me.GridColumncolor.Width = 222
        '
        'GridColumnqty_avl
        '
        Me.GridColumnqty_avl.Caption = "Available"
        Me.GridColumnqty_avl.DisplayFormat.FormatString = "N0"
        Me.GridColumnqty_avl.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnqty_avl.FieldName = "qty_avl"
        Me.GridColumnqty_avl.Name = "GridColumnqty_avl"
        Me.GridColumnqty_avl.OptionsColumn.AllowEdit = False
        Me.GridColumnqty_avl.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_avl", "{0:N0}")})
        Me.GridColumnqty_avl.Visible = True
        Me.GridColumnqty_avl.VisibleIndex = 6
        Me.GridColumnqty_avl.Width = 384
        '
        'GridColumnqty_input
        '
        Me.GridColumnqty_input.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnqty_input.AppearanceCell.Options.UseFont = True
        Me.GridColumnqty_input.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnqty_input.AppearanceHeader.Options.UseFont = True
        Me.GridColumnqty_input.Caption = "Proposed Qty"
        Me.GridColumnqty_input.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.GridColumnqty_input.DisplayFormat.FormatString = "N0"
        Me.GridColumnqty_input.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnqty_input.FieldName = "qty_input"
        Me.GridColumnqty_input.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right
        Me.GridColumnqty_input.Name = "GridColumnqty_input"
        Me.GridColumnqty_input.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_input", "{0:N0}")})
        Me.GridColumnqty_input.Visible = True
        Me.GridColumnqty_input.VisibleIndex = 7
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSpinEdit1.DisplayFormat.FormatString = "N0"
        Me.RepositoryItemSpinEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "n0"
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {1874919423, 2328306, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'GridColumndesign_price_type
        '
        Me.GridColumndesign_price_type.Caption = "design_price_type"
        Me.GridColumndesign_price_type.FieldName = "design_price_type"
        Me.GridColumndesign_price_type.Name = "GridColumndesign_price_type"
        Me.GridColumndesign_price_type.OptionsColumn.AllowEdit = False
        '
        'GridColumnsize
        '
        Me.GridColumnsize.Caption = "Size"
        Me.GridColumnsize.FieldName = "size"
        Me.GridColumnsize.Name = "GridColumnsize"
        Me.GridColumnsize.Visible = True
        Me.GridColumnsize.VisibleIndex = 5
        Me.GridColumnsize.Width = 61
        '
        'CESelectAll
        '
        Me.CESelectAll.Location = New System.Drawing.Point(12, 13)
        Me.CESelectAll.Name = "CESelectAll"
        Me.CESelectAll.Properties.Caption = "Select All"
        Me.CESelectAll.Size = New System.Drawing.Size(75, 19)
        Me.CESelectAll.TabIndex = 3
        '
        'FormRetExosItemList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(556, 335)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormRetExosItemList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Extended EOS Product List"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CESelectAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnDiscard As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_product As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnclass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsht As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncolor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnqty_avl As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnqty_input As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumndesign_price_type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CESelectAll As DevExpress.XtraEditors.CheckEdit
End Class
