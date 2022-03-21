<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormClassGroup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormClassGroup))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnDel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_class_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnclass_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndivision = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnclass_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnclass_cat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnestimasi_sku = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnPrint)
        Me.PanelControl1.Controls.Add(Me.BtnDel)
        Me.PanelControl1.Controls.Add(Me.BtnAdd)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(638, 49)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(403, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(82, 45)
        Me.BtnPrint.TabIndex = 2
        Me.BtnPrint.Text = "Print"
        '
        'BtnDel
        '
        Me.BtnDel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDel.Image = CType(resources.GetObject("BtnDel.Image"), System.Drawing.Image)
        Me.BtnDel.Location = New System.Drawing.Point(485, 2)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(76, 45)
        Me.BtnDel.TabIndex = 1
        Me.BtnDel.Text = "Delete"
        '
        'BtnAdd
        '
        Me.BtnAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"), System.Drawing.Image)
        Me.BtnAdd.Location = New System.Drawing.Point(561, 2)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(75, 45)
        Me.BtnAdd.TabIndex = 0
        Me.BtnAdd.Text = "Add"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 49)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(638, 345)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_class_group, Me.GridColumnclass_group, Me.GridColumndivision, Me.GridColumnclass_type, Me.GridColumnclass_cat, Me.GridColumnestimasi_sku})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_class_group
        '
        Me.GridColumnid_class_group.Caption = "id_class_group"
        Me.GridColumnid_class_group.FieldName = "id_class_group"
        Me.GridColumnid_class_group.Name = "GridColumnid_class_group"
        '
        'GridColumnclass_group
        '
        Me.GridColumnclass_group.Caption = "Class Group"
        Me.GridColumnclass_group.FieldName = "class_group"
        Me.GridColumnclass_group.Name = "GridColumnclass_group"
        Me.GridColumnclass_group.Visible = True
        Me.GridColumnclass_group.VisibleIndex = 3
        '
        'GridColumndivision
        '
        Me.GridColumndivision.Caption = "Division"
        Me.GridColumndivision.FieldName = "division"
        Me.GridColumndivision.Name = "GridColumndivision"
        Me.GridColumndivision.Visible = True
        Me.GridColumndivision.VisibleIndex = 0
        '
        'GridColumnclass_type
        '
        Me.GridColumnclass_type.Caption = "Class Type"
        Me.GridColumnclass_type.FieldName = "class_type"
        Me.GridColumnclass_type.Name = "GridColumnclass_type"
        Me.GridColumnclass_type.Visible = True
        Me.GridColumnclass_type.VisibleIndex = 1
        '
        'GridColumnclass_cat
        '
        Me.GridColumnclass_cat.Caption = "Class Category"
        Me.GridColumnclass_cat.FieldName = "class_cat"
        Me.GridColumnclass_cat.Name = "GridColumnclass_cat"
        Me.GridColumnclass_cat.Visible = True
        Me.GridColumnclass_cat.VisibleIndex = 2
        '
        'GridColumnestimasi_sku
        '
        Me.GridColumnestimasi_sku.Caption = "ESTIMASI SKU"
        Me.GridColumnestimasi_sku.DisplayFormat.FormatString = "N0"
        Me.GridColumnestimasi_sku.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnestimasi_sku.FieldName = "estimasi_sku"
        Me.GridColumnestimasi_sku.Name = "GridColumnestimasi_sku"
        Me.GridColumnestimasi_sku.Visible = True
        Me.GridColumnestimasi_sku.VisibleIndex = 4
        '
        'FormClassGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(638, 394)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormClassGroup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Class Group"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnDel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_class_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnclass_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndivision As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnclass_type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnclass_cat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnestimasi_sku As DevExpress.XtraGrid.Columns.GridColumn
End Class
