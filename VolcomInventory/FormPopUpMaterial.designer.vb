<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpMaterial
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPopUpMaterial))
        Me.XTCMaterialType = New DevExpress.XtraTab.XtraTabControl
        Me.XTPRawMaterial = New DevExpress.XtraTab.XtraTabPage
        Me.GCRawMat = New DevExpress.XtraGrid.GridControl
        Me.GVRawMat = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColumnIdRawMat = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnMatCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnRawMaterial = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnMatDisplayName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCategoryMaterial = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnUOM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl
        Me.BDelMatType = New DevExpress.XtraEditors.SimpleButton
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BEditMatType = New DevExpress.XtraEditors.SimpleButton
        Me.BAddMatType = New DevExpress.XtraEditors.SimpleButton
        Me.XTPMaterialDetail = New DevExpress.XtraTab.XtraTabPage
        Me.GCMatDetail = New DevExpress.XtraGrid.GridControl
        Me.GVMatDetail = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColumnIdMatDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnMatDetCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnMatDetName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnMatDetDisplayName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnMethod = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnLifetime = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDateCreated = New DevExpress.XtraGrid.Columns.GridColumn
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl
        Me.BDelMat = New DevExpress.XtraEditors.SimpleButton
        Me.BEditMat = New DevExpress.XtraEditors.SimpleButton
        Me.BAddMat = New DevExpress.XtraEditors.SimpleButton
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.LabelMatContent = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        CType(Me.XTCMaterialType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCMaterialType.SuspendLayout()
        Me.XTPRawMaterial.SuspendLayout()
        CType(Me.GCRawMat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRawMat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPMaterialDetail.SuspendLayout()
        CType(Me.GCMatDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMatDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'XTCMaterialType
        '
        Me.XTCMaterialType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCMaterialType.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left
        Me.XTCMaterialType.Location = New System.Drawing.Point(0, 0)
        Me.XTCMaterialType.LookAndFeel.SkinName = "Seven Classic"
        Me.XTCMaterialType.LookAndFeel.UseDefaultLookAndFeel = False
        Me.XTCMaterialType.Name = "XTCMaterialType"
        Me.XTCMaterialType.SelectedTabPage = Me.XTPRawMaterial
        Me.XTCMaterialType.Size = New System.Drawing.Size(732, 361)
        Me.XTCMaterialType.TabIndex = 1
        Me.XTCMaterialType.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPRawMaterial, Me.XTPMaterialDetail})
        '
        'XTPRawMaterial
        '
        Me.XTPRawMaterial.Controls.Add(Me.GCRawMat)
        Me.XTPRawMaterial.Controls.Add(Me.PanelControl3)
        Me.XTPRawMaterial.Name = "XTPRawMaterial"
        Me.XTPRawMaterial.Size = New System.Drawing.Size(709, 358)
        Me.XTPRawMaterial.Text = "Material Type"
        '
        'GCRawMat
        '
        Me.GCRawMat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRawMat.Location = New System.Drawing.Point(0, 36)
        Me.GCRawMat.MainView = Me.GVRawMat
        Me.GCRawMat.Name = "GCRawMat"
        Me.GCRawMat.Size = New System.Drawing.Size(709, 322)
        Me.GCRawMat.TabIndex = 2
        Me.GCRawMat.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRawMat, Me.GridView2})
        '
        'GVRawMat
        '
        Me.GVRawMat.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColumnIdRawMat, Me.GridColumnMatCode, Me.ColumnRawMaterial, Me.ColumnMatDisplayName, Me.GridColumnCategoryMaterial, Me.ColumnUOM})
        Me.GVRawMat.GridControl = Me.GCRawMat
        Me.GVRawMat.Name = "GVRawMat"
        Me.GVRawMat.OptionsBehavior.Editable = False
        Me.GVRawMat.OptionsFind.AlwaysVisible = True
        Me.GVRawMat.OptionsView.ShowGroupPanel = False
        '
        'ColumnIdRawMat
        '
        Me.ColumnIdRawMat.Caption = "Id Raw Mat"
        Me.ColumnIdRawMat.FieldName = "id_mat"
        Me.ColumnIdRawMat.Name = "ColumnIdRawMat"
        '
        'GridColumnMatCode
        '
        Me.GridColumnMatCode.Caption = "Code"
        Me.GridColumnMatCode.FieldName = "mat_code"
        Me.GridColumnMatCode.Name = "GridColumnMatCode"
        Me.GridColumnMatCode.Visible = True
        Me.GridColumnMatCode.VisibleIndex = 0
        '
        'ColumnRawMaterial
        '
        Me.ColumnRawMaterial.Caption = "Material Name"
        Me.ColumnRawMaterial.FieldName = "mat_name"
        Me.ColumnRawMaterial.Name = "ColumnRawMaterial"
        Me.ColumnRawMaterial.Visible = True
        Me.ColumnRawMaterial.VisibleIndex = 1
        '
        'ColumnMatDisplayName
        '
        Me.ColumnMatDisplayName.Caption = "Material Display Name"
        Me.ColumnMatDisplayName.FieldName = "mat_display_name"
        Me.ColumnMatDisplayName.Name = "ColumnMatDisplayName"
        Me.ColumnMatDisplayName.Visible = True
        Me.ColumnMatDisplayName.VisibleIndex = 2
        '
        'GridColumnCategoryMaterial
        '
        Me.GridColumnCategoryMaterial.Caption = "Category"
        Me.GridColumnCategoryMaterial.FieldName = "mat_cat"
        Me.GridColumnCategoryMaterial.Name = "GridColumnCategoryMaterial"
        Me.GridColumnCategoryMaterial.Visible = True
        Me.GridColumnCategoryMaterial.VisibleIndex = 3
        '
        'ColumnUOM
        '
        Me.ColumnUOM.Caption = "UOM"
        Me.ColumnUOM.FieldName = "uom"
        Me.ColumnUOM.Name = "ColumnUOM"
        Me.ColumnUOM.Visible = True
        Me.ColumnUOM.VisibleIndex = 4
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GCRawMat
        Me.GridView2.Name = "GridView2"
        '
        'PanelControl3
        '
        Me.PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl3.Controls.Add(Me.BDelMatType)
        Me.PanelControl3.Controls.Add(Me.BEditMatType)
        Me.PanelControl3.Controls.Add(Me.BAddMatType)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(709, 36)
        Me.PanelControl3.TabIndex = 31
        '
        'BDelMatType
        '
        Me.BDelMatType.Dock = System.Windows.Forms.DockStyle.Right
        Me.BDelMatType.ImageIndex = 1
        Me.BDelMatType.ImageList = Me.LargeImageCollection
        Me.BDelMatType.Location = New System.Drawing.Point(462, 0)
        Me.BDelMatType.Name = "BDelMatType"
        Me.BDelMatType.Size = New System.Drawing.Size(85, 36)
        Me.BDelMatType.TabIndex = 3
        Me.BDelMatType.Text = "Delete"
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "20_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "8_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "23_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(3, "contact32.png")
        '
        'BEditMatType
        '
        Me.BEditMatType.Dock = System.Windows.Forms.DockStyle.Right
        Me.BEditMatType.ImageIndex = 2
        Me.BEditMatType.ImageList = Me.LargeImageCollection
        Me.BEditMatType.Location = New System.Drawing.Point(547, 0)
        Me.BEditMatType.Name = "BEditMatType"
        Me.BEditMatType.Size = New System.Drawing.Size(82, 36)
        Me.BEditMatType.TabIndex = 2
        Me.BEditMatType.Text = "Edit"
        '
        'BAddMatType
        '
        Me.BAddMatType.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAddMatType.ImageIndex = 0
        Me.BAddMatType.ImageList = Me.LargeImageCollection
        Me.BAddMatType.Location = New System.Drawing.Point(629, 0)
        Me.BAddMatType.Name = "BAddMatType"
        Me.BAddMatType.Size = New System.Drawing.Size(80, 36)
        Me.BAddMatType.TabIndex = 1
        Me.BAddMatType.Text = "Add"
        '
        'XTPMaterialDetail
        '
        Me.XTPMaterialDetail.Controls.Add(Me.GCMatDetail)
        Me.XTPMaterialDetail.Controls.Add(Me.PanelControl2)
        Me.XTPMaterialDetail.Controls.Add(Me.PanelControl1)
        Me.XTPMaterialDetail.Name = "XTPMaterialDetail"
        Me.XTPMaterialDetail.Size = New System.Drawing.Size(709, 358)
        Me.XTPMaterialDetail.Text = "Material Detail"
        '
        'GCMatDetail
        '
        Me.GCMatDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMatDetail.Location = New System.Drawing.Point(0, 80)
        Me.GCMatDetail.MainView = Me.GVMatDetail
        Me.GCMatDetail.Name = "GCMatDetail"
        Me.GCMatDetail.Size = New System.Drawing.Size(709, 278)
        Me.GCMatDetail.TabIndex = 3
        Me.GCMatDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMatDetail})
        '
        'GVMatDetail
        '
        Me.GVMatDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColumnIdMatDet, Me.GridColumnMatDetCode, Me.GridColumnMatDetName, Me.GridColumnMatDetDisplayName, Me.GridColumnMethod, Me.GridColumnLifetime, Me.GridColumnDateCreated})
        Me.GVMatDetail.GridControl = Me.GCMatDetail
        Me.GVMatDetail.Name = "GVMatDetail"
        Me.GVMatDetail.OptionsBehavior.Editable = False
        Me.GVMatDetail.OptionsFind.AlwaysVisible = True
        Me.GVMatDetail.OptionsView.ShowGroupPanel = False
        '
        'ColumnIdMatDet
        '
        Me.ColumnIdMatDet.Caption = "ID"
        Me.ColumnIdMatDet.FieldName = "id_mat_det"
        Me.ColumnIdMatDet.Name = "ColumnIdMatDet"
        '
        'GridColumnMatDetCode
        '
        Me.GridColumnMatDetCode.Caption = "Code"
        Me.GridColumnMatDetCode.FieldName = "mat_det_code"
        Me.GridColumnMatDetCode.Name = "GridColumnMatDetCode"
        Me.GridColumnMatDetCode.Visible = True
        Me.GridColumnMatDetCode.VisibleIndex = 0
        '
        'GridColumnMatDetName
        '
        Me.GridColumnMatDetName.Caption = "Name"
        Me.GridColumnMatDetName.FieldName = "mat_det_name"
        Me.GridColumnMatDetName.Name = "GridColumnMatDetName"
        Me.GridColumnMatDetName.Visible = True
        Me.GridColumnMatDetName.VisibleIndex = 1
        '
        'GridColumnMatDetDisplayName
        '
        Me.GridColumnMatDetDisplayName.Caption = "Display Name"
        Me.GridColumnMatDetDisplayName.FieldName = "mat_det_display_name"
        Me.GridColumnMatDetDisplayName.Name = "GridColumnMatDetDisplayName"
        Me.GridColumnMatDetDisplayName.Visible = True
        Me.GridColumnMatDetDisplayName.VisibleIndex = 2
        '
        'GridColumnMethod
        '
        Me.GridColumnMethod.Caption = "Method"
        Me.GridColumnMethod.FieldName = "method"
        Me.GridColumnMethod.Name = "GridColumnMethod"
        Me.GridColumnMethod.Visible = True
        Me.GridColumnMethod.VisibleIndex = 3
        '
        'GridColumnLifetime
        '
        Me.GridColumnLifetime.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnLifetime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridColumnLifetime.Caption = "Lifetime (day)"
        Me.GridColumnLifetime.FieldName = "lifetime"
        Me.GridColumnLifetime.Name = "GridColumnLifetime"
        Me.GridColumnLifetime.Visible = True
        Me.GridColumnLifetime.VisibleIndex = 4
        '
        'GridColumnDateCreated
        '
        Me.GridColumnDateCreated.Caption = "Date Created"
        Me.GridColumnDateCreated.FieldName = "mat_det_date"
        Me.GridColumnDateCreated.Name = "GridColumnDateCreated"
        Me.GridColumnDateCreated.Visible = True
        Me.GridColumnDateCreated.VisibleIndex = 5
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.BDelMat)
        Me.PanelControl2.Controls.Add(Me.BEditMat)
        Me.PanelControl2.Controls.Add(Me.BAddMat)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 44)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(709, 36)
        Me.PanelControl2.TabIndex = 31
        '
        'BDelMat
        '
        Me.BDelMat.Dock = System.Windows.Forms.DockStyle.Right
        Me.BDelMat.ImageIndex = 1
        Me.BDelMat.ImageList = Me.LargeImageCollection
        Me.BDelMat.Location = New System.Drawing.Point(462, 0)
        Me.BDelMat.Name = "BDelMat"
        Me.BDelMat.Size = New System.Drawing.Size(85, 36)
        Me.BDelMat.TabIndex = 3
        Me.BDelMat.Text = "Delete"
        '
        'BEditMat
        '
        Me.BEditMat.Dock = System.Windows.Forms.DockStyle.Right
        Me.BEditMat.ImageIndex = 2
        Me.BEditMat.ImageList = Me.LargeImageCollection
        Me.BEditMat.Location = New System.Drawing.Point(547, 0)
        Me.BEditMat.Name = "BEditMat"
        Me.BEditMat.Size = New System.Drawing.Size(82, 36)
        Me.BEditMat.TabIndex = 2
        Me.BEditMat.Text = "Edit"
        '
        'BAddMat
        '
        Me.BAddMat.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAddMat.ImageIndex = 0
        Me.BAddMat.ImageList = Me.LargeImageCollection
        Me.BAddMat.Location = New System.Drawing.Point(629, 0)
        Me.BAddMat.Name = "BAddMat"
        Me.BAddMat.Size = New System.Drawing.Size(80, 36)
        Me.BAddMat.TabIndex = 1
        Me.BAddMat.Text = "Add"
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.AliceBlue
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.LabelMatContent)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(709, 44)
        Me.PanelControl1.TabIndex = 2
        '
        'LabelMatContent
        '
        Me.LabelMatContent.Appearance.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMatContent.Location = New System.Drawing.Point(147, 9)
        Me.LabelMatContent.Name = "LabelMatContent"
        Me.LabelMatContent.Size = New System.Drawing.Size(6, 26)
        Me.LabelMatContent.TabIndex = 6
        Me.LabelMatContent.Text = "-"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(11, 9)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(134, 26)
        Me.LabelControl2.TabIndex = 5
        Me.LabelControl2.Text = "Material Type : "
        '
        'FormPopUpMaterial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(732, 361)
        Me.Controls.Add(Me.XTCMaterialType)
        Me.MinimizeBox = False
        Me.Name = "FormPopUpMaterial"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Raw Material"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.XTCMaterialType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCMaterialType.ResumeLayout(False)
        Me.XTPRawMaterial.ResumeLayout(False)
        CType(Me.GCRawMat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRawMat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPMaterialDetail.ResumeLayout(False)
        CType(Me.GCMatDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMatDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XTCMaterialType As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPRawMaterial As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCRawMat As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRawMat As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColumnIdRawMat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMatCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnRawMaterial As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnMatDisplayName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCategoryMaterial As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents XTPMaterialDetail As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCMatDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMatDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColumnIdMatDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMatDetCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMatDetName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMatDetDisplayName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMethod As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLifetime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDateCreated As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelMatContent As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BDelMatType As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BEditMatType As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BAddMatType As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BDelMat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BEditMat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BAddMat As DevExpress.XtraEditors.SimpleButton
End Class
