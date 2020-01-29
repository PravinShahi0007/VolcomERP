<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesInv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSalesInv))
        Me.XTCSalesInv = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPProduct = New DevExpress.XtraTab.XtraTabPage()
        Me.GCByProduct = New DevExpress.XtraGrid.GridControl()
        Me.GVByProduct = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnExportToXLSRec = New DevExpress.XtraEditors.SimpleButton()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPOutlet = New DevExpress.XtraTab.XtraTabPage()
        Me.BandedGridColumnid_design = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumncode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnname = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnid_design_cat = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumndesign_cat = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnstt = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnid_class = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnclass = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnid_subkat = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnsubkat = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnkat = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnsize_type = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnage = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        CType(Me.XTCSalesInv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCSalesInv.SuspendLayout()
        Me.XTPProduct.SuspendLayout()
        CType(Me.GCByProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVByProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCSalesInv
        '
        Me.XTCSalesInv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCSalesInv.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCSalesInv.Location = New System.Drawing.Point(0, 0)
        Me.XTCSalesInv.Name = "XTCSalesInv"
        Me.XTCSalesInv.SelectedTabPage = Me.XTPProduct
        Me.XTCSalesInv.Size = New System.Drawing.Size(787, 485)
        Me.XTCSalesInv.TabIndex = 0
        Me.XTCSalesInv.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPProduct, Me.XTPOutlet})
        '
        'XTPProduct
        '
        Me.XTPProduct.Controls.Add(Me.GCByProduct)
        Me.XTPProduct.Controls.Add(Me.PanelControl1)
        Me.XTPProduct.Name = "XTPProduct"
        Me.XTPProduct.Size = New System.Drawing.Size(781, 457)
        Me.XTPProduct.Text = "View By Product"
        '
        'GCByProduct
        '
        Me.GCByProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCByProduct.Location = New System.Drawing.Point(0, 142)
        Me.GCByProduct.MainView = Me.GVByProduct
        Me.GCByProduct.Name = "GCByProduct"
        Me.GCByProduct.Size = New System.Drawing.Size(781, 315)
        Me.GCByProduct.TabIndex = 1
        Me.GCByProduct.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVByProduct})
        '
        'GVByProduct
        '
        Me.GVByProduct.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.GVByProduct.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumnid_design, Me.BandedGridColumncode, Me.BandedGridColumnname, Me.BandedGridColumnid_design_cat, Me.BandedGridColumndesign_cat, Me.BandedGridColumnstt, Me.BandedGridColumnid_class, Me.BandedGridColumnclass, Me.BandedGridColumnid_subkat, Me.BandedGridColumnsubkat, Me.BandedGridColumn1, Me.BandedGridColumnkat, Me.BandedGridColumnsize_type, Me.BandedGridColumnage})
        Me.GVByProduct.GridControl = Me.GCByProduct
        Me.GVByProduct.Name = "GVByProduct"
        Me.GVByProduct.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVByProduct.OptionsBehavior.ReadOnly = True
        Me.GVByProduct.OptionsFind.AlwaysVisible = True
        Me.GVByProduct.OptionsPrint.AllowMultilineHeaders = True
        Me.GVByProduct.OptionsView.ColumnAutoWidth = False
        Me.GVByProduct.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVByProduct.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVByProduct.OptionsView.ShowFooter = True
        Me.GVByProduct.OptionsView.ShowGroupPanel = False
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnExportToXLSRec)
        Me.PanelControl1.Controls.Add(Me.DEUntil)
        Me.PanelControl1.Controls.Add(Me.BtnView)
        Me.PanelControl1.Controls.Add(Me.DEFrom)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(781, 142)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnExportToXLSRec
        '
        Me.BtnExportToXLSRec.Image = CType(resources.GetObject("BtnExportToXLSRec.Image"), System.Drawing.Image)
        Me.BtnExportToXLSRec.Location = New System.Drawing.Point(603, 102)
        Me.BtnExportToXLSRec.LookAndFeel.SkinName = "Blue"
        Me.BtnExportToXLSRec.Name = "BtnExportToXLSRec"
        Me.BtnExportToXLSRec.Size = New System.Drawing.Size(106, 20)
        Me.BtnExportToXLSRec.TabIndex = 8907
        Me.BtnExportToXLSRec.Text = "Export to XLS"
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(187, 13)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntil.Size = New System.Drawing.Size(111, 20)
        Me.DEUntil.TabIndex = 8905
        '
        'BtnView
        '
        Me.BtnView.Image = CType(resources.GetObject("BtnView.Image"), System.Drawing.Image)
        Me.BtnView.Location = New System.Drawing.Point(524, 102)
        Me.BtnView.LookAndFeel.SkinName = "Blue"
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(75, 20)
        Me.BtnView.TabIndex = 8906
        Me.BtnView.Text = "View"
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(43, 13)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFrom.Size = New System.Drawing.Size(111, 20)
        Me.DEFrom.TabIndex = 8904
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(160, 16)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl2.TabIndex = 8903
        Me.LabelControl2.Text = "Until"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(13, 16)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl3.TabIndex = 8902
        Me.LabelControl3.Text = "From"
        '
        'XTPOutlet
        '
        Me.XTPOutlet.Name = "XTPOutlet"
        Me.XTPOutlet.Size = New System.Drawing.Size(781, 457)
        Me.XTPOutlet.Text = "View By Product && Account"
        '
        'BandedGridColumnid_design
        '
        Me.BandedGridColumnid_design.Caption = "id_design"
        Me.BandedGridColumnid_design.FieldName = "id_design"
        Me.BandedGridColumnid_design.Name = "BandedGridColumnid_design"
        '
        'BandedGridColumncode
        '
        Me.BandedGridColumncode.Caption = "Code"
        Me.BandedGridColumncode.FieldName = "code"
        Me.BandedGridColumncode.Name = "BandedGridColumncode"
        Me.BandedGridColumncode.Visible = True
        Me.BandedGridColumncode.Width = 67
        '
        'BandedGridColumnname
        '
        Me.BandedGridColumnname.Caption = "Description"
        Me.BandedGridColumnname.FieldName = "name"
        Me.BandedGridColumnname.Name = "BandedGridColumnname"
        Me.BandedGridColumnname.Visible = True
        Me.BandedGridColumnname.Width = 134
        '
        'BandedGridColumnid_design_cat
        '
        Me.BandedGridColumnid_design_cat.Caption = "id_design_cat"
        Me.BandedGridColumnid_design_cat.FieldName = "id_design_cat"
        Me.BandedGridColumnid_design_cat.Name = "BandedGridColumnid_design_cat"
        '
        'BandedGridColumndesign_cat
        '
        Me.BandedGridColumndesign_cat.Caption = "design_cat"
        Me.BandedGridColumndesign_cat.FieldName = "design_cat"
        Me.BandedGridColumndesign_cat.Name = "BandedGridColumndesign_cat"
        '
        'BandedGridColumnstt
        '
        Me.BandedGridColumnstt.Caption = "Status"
        Me.BandedGridColumnstt.FieldName = "stt"
        Me.BandedGridColumnstt.Name = "BandedGridColumnstt"
        Me.BandedGridColumnstt.Visible = True
        Me.BandedGridColumnstt.Width = 44
        '
        'BandedGridColumnid_class
        '
        Me.BandedGridColumnid_class.Caption = "id_class"
        Me.BandedGridColumnid_class.FieldName = "id_class"
        Me.BandedGridColumnid_class.Name = "BandedGridColumnid_class"
        '
        'BandedGridColumnclass
        '
        Me.BandedGridColumnclass.Caption = "Class"
        Me.BandedGridColumnclass.FieldName = "class"
        Me.BandedGridColumnclass.Name = "BandedGridColumnclass"
        Me.BandedGridColumnclass.Visible = True
        Me.BandedGridColumnclass.Width = 42
        '
        'BandedGridColumnid_subkat
        '
        Me.BandedGridColumnid_subkat.Caption = "id_subkat"
        Me.BandedGridColumnid_subkat.FieldName = "id_subkat"
        Me.BandedGridColumnid_subkat.Name = "BandedGridColumnid_subkat"
        '
        'BandedGridColumnsubkat
        '
        Me.BandedGridColumnsubkat.Caption = "Subcategory"
        Me.BandedGridColumnsubkat.FieldName = "subkat"
        Me.BandedGridColumnsubkat.Name = "BandedGridColumnsubkat"
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.Caption = "id_kat"
        Me.BandedGridColumn1.FieldName = "id_kat"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        '
        'BandedGridColumnkat
        '
        Me.BandedGridColumnkat.Caption = "Category"
        Me.BandedGridColumnkat.FieldName = "kat"
        Me.BandedGridColumnkat.Name = "BandedGridColumnkat"
        '
        'BandedGridColumnsize_type
        '
        Me.BandedGridColumnsize_type.Caption = "Sizetype"
        Me.BandedGridColumnsize_type.FieldName = "size_type"
        Me.BandedGridColumnsize_type.Name = "BandedGridColumnsize_type"
        Me.BandedGridColumnsize_type.Visible = True
        Me.BandedGridColumnsize_type.Width = 73
        '
        'BandedGridColumnage
        '
        Me.BandedGridColumnage.Caption = "Age"
        Me.BandedGridColumnage.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnage.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnage.FieldName = "age"
        Me.BandedGridColumnage.Name = "BandedGridColumnage"
        Me.BandedGridColumnage.Visible = True
        Me.BandedGridColumnage.Width = 41
        '
        'GridBand1
        '
        Me.GridBand1.Columns.Add(Me.BandedGridColumnid_design)
        Me.GridBand1.Columns.Add(Me.BandedGridColumncode)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnname)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnid_class)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnclass)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn1)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnkat)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnid_subkat)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnsubkat)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnid_design_cat)
        Me.GridBand1.Columns.Add(Me.BandedGridColumndesign_cat)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnstt)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnage)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnsize_type)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 401
        '
        'FormSalesInv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(787, 485)
        Me.Controls.Add(Me.XTCSalesInv)
        Me.Name = "FormSalesInv"
        Me.Text = "Sales & Inventory"
        CType(Me.XTCSalesInv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCSalesInv.ResumeLayout(False)
        Me.XTPProduct.ResumeLayout(False)
        CType(Me.GCByProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVByProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCSalesInv As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPProduct As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPOutlet As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnExportToXLSRec As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCByProduct As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVByProduct As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnid_design As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumncode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnname As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnid_class As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnclass As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnkat As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnid_subkat As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnsubkat As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnid_design_cat As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumndesign_cat As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnstt As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnage As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnsize_type As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
End Class
