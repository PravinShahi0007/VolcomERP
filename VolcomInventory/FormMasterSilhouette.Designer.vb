<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterSilhouette
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterSilhouette))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnExportToXLS = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.GCClass = New DevExpress.XtraGrid.GridControl()
        Me.GVClass = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_class = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnclass = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnclass_desc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_sht = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsht_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BtnSilhouetteList = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCClass, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVClass, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnSilhouetteList)
        Me.PanelControl1.Controls.Add(Me.BtnExportToXLS)
        Me.PanelControl1.Controls.Add(Me.BtnPrint)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(685, 45)
        Me.PanelControl1.TabIndex = 1
        '
        'BtnExportToXLS
        '
        Me.BtnExportToXLS.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnExportToXLS.Image = CType(resources.GetObject("BtnExportToXLS.Image"), System.Drawing.Image)
        Me.BtnExportToXLS.Location = New System.Drawing.Point(481, 2)
        Me.BtnExportToXLS.Name = "BtnExportToXLS"
        Me.BtnExportToXLS.Size = New System.Drawing.Size(120, 41)
        Me.BtnExportToXLS.TabIndex = 2
        Me.BtnExportToXLS.Text = "Export to XLS"
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(601, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(82, 41)
        Me.BtnPrint.TabIndex = 1
        Me.BtnPrint.Text = "Print"
        '
        'GCClass
        '
        Me.GCClass.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCClass.Location = New System.Drawing.Point(0, 45)
        Me.GCClass.MainView = Me.GVClass
        Me.GCClass.Name = "GCClass"
        Me.GCClass.Size = New System.Drawing.Size(685, 446)
        Me.GCClass.TabIndex = 2
        Me.GCClass.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVClass})
        '
        'GVClass
        '
        Me.GVClass.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_class, Me.GridColumnclass, Me.GridColumnclass_desc, Me.GridColumnid_sht, Me.GridColumnsht_name})
        Me.GVClass.GridControl = Me.GCClass
        Me.GVClass.Name = "GVClass"
        Me.GVClass.OptionsBehavior.Editable = False
        Me.GVClass.OptionsFind.AlwaysVisible = True
        Me.GVClass.OptionsView.AllowCellMerge = True
        Me.GVClass.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_class
        '
        Me.GridColumnid_class.Caption = "id_class"
        Me.GridColumnid_class.FieldName = "id_class"
        Me.GridColumnid_class.Name = "GridColumnid_class"
        Me.GridColumnid_class.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GridColumnclass
        '
        Me.GridColumnclass.Caption = "Class"
        Me.GridColumnclass.FieldName = "class"
        Me.GridColumnclass.Name = "GridColumnclass"
        Me.GridColumnclass.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumnclass.Visible = True
        Me.GridColumnclass.VisibleIndex = 0
        '
        'GridColumnclass_desc
        '
        Me.GridColumnclass_desc.Caption = "Class Description"
        Me.GridColumnclass_desc.FieldName = "class_desc"
        Me.GridColumnclass_desc.Name = "GridColumnclass_desc"
        Me.GridColumnclass_desc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumnclass_desc.Visible = True
        Me.GridColumnclass_desc.VisibleIndex = 1
        '
        'GridColumnid_sht
        '
        Me.GridColumnid_sht.Caption = "id_sht"
        Me.GridColumnid_sht.FieldName = "id_sht"
        Me.GridColumnid_sht.Name = "GridColumnid_sht"
        Me.GridColumnid_sht.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GridColumnsht_name
        '
        Me.GridColumnsht_name.Caption = "Silhouette "
        Me.GridColumnsht_name.FieldName = "sht_name"
        Me.GridColumnsht_name.Name = "GridColumnsht_name"
        Me.GridColumnsht_name.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnsht_name.Visible = True
        Me.GridColumnsht_name.VisibleIndex = 2
        '
        'BtnSilhouetteList
        '
        Me.BtnSilhouetteList.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnSilhouetteList.Image = CType(resources.GetObject("BtnSilhouetteList.Image"), System.Drawing.Image)
        Me.BtnSilhouetteList.Location = New System.Drawing.Point(2, 2)
        Me.BtnSilhouetteList.Name = "BtnSilhouetteList"
        Me.BtnSilhouetteList.Size = New System.Drawing.Size(120, 41)
        Me.BtnSilhouetteList.TabIndex = 3
        Me.BtnSilhouetteList.Text = "Silhouette List"
        Me.BtnSilhouetteList.Visible = False
        '
        'FormMasterSilhouette
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(685, 491)
        Me.Controls.Add(Me.GCClass)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormMasterSilhouette"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Master Silhouette"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCClass, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVClass, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnis_select As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnid_code_detail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndisplay_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncode_detail_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnExportToXLS As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCClass As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVClass As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_class As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnclass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnclass_desc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_sht As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsht_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnSilhouetteList As DevExpress.XtraEditors.SimpleButton
End Class
