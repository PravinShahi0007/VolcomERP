<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSampleDelSingle
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
        Me.PanelControlNav = New DevExpress.XtraEditors.PanelControl
        Me.CheckEditProduct = New DevExpress.XtraEditors.CheckEdit
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BtnChoose = New DevExpress.XtraEditors.SimpleButton
        Me.GroupControlSample = New DevExpress.XtraEditors.GroupControl
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl
        Me.PanelControlImg = New DevExpress.XtraEditors.PanelControl
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit
        Me.BtnViewImg = New DevExpress.XtraEditors.SimpleButton
        Me.GCProduct = New DevExpress.XtraGrid.GridControl
        Me.GVProduct = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSelectProduct = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.GridColumnDesign = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemSearchLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
        Me.RepositoryItemSearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnYearSeason = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdSample = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNav.SuspendLayout()
        CType(Me.CheckEditProduct.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlSample, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlSample.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.PanelControlImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlImg.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControlNav
        '
        Me.PanelControlNav.Controls.Add(Me.CheckEditProduct)
        Me.PanelControlNav.Controls.Add(Me.BtnCancel)
        Me.PanelControlNav.Controls.Add(Me.BtnChoose)
        Me.PanelControlNav.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControlNav.Location = New System.Drawing.Point(0, 279)
        Me.PanelControlNav.LookAndFeel.SkinName = "Blue"
        Me.PanelControlNav.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControlNav.Name = "PanelControlNav"
        Me.PanelControlNav.Size = New System.Drawing.Size(744, 36)
        Me.PanelControlNav.TabIndex = 8
        '
        'CheckEditProduct
        '
        Me.CheckEditProduct.Location = New System.Drawing.Point(12, 8)
        Me.CheckEditProduct.Name = "CheckEditProduct"
        Me.CheckEditProduct.Properties.Caption = "Select All Product"
        Me.CheckEditProduct.Size = New System.Drawing.Size(119, 19)
        Me.CheckEditProduct.TabIndex = 2
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.Location = New System.Drawing.Point(592, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 32)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnChoose
        '
        Me.BtnChoose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnChoose.Location = New System.Drawing.Point(667, 2)
        Me.BtnChoose.Name = "BtnChoose"
        Me.BtnChoose.Size = New System.Drawing.Size(75, 32)
        Me.BtnChoose.TabIndex = 3
        Me.BtnChoose.Text = "Choose"
        '
        'GroupControlSample
        '
        Me.GroupControlSample.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupControlSample.Controls.Add(Me.SplitContainerControl1)
        Me.GroupControlSample.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlSample.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlSample.Name = "GroupControlSample"
        Me.GroupControlSample.Size = New System.Drawing.Size(744, 279)
        Me.GroupControlSample.TabIndex = 10
        Me.GroupControlSample.Text = "Product"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Location = New System.Drawing.Point(2, 22)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.PanelControlImg)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GCProduct)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(740, 255)
        Me.SplitContainerControl1.SplitterPosition = 191
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'PanelControlImg
        '
        Me.PanelControlImg.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlImg.Controls.Add(Me.PictureEdit1)
        Me.PanelControlImg.Controls.Add(Me.BtnViewImg)
        Me.PanelControlImg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControlImg.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlImg.Name = "PanelControlImg"
        Me.PanelControlImg.Size = New System.Drawing.Size(191, 255)
        Me.PanelControlImg.TabIndex = 0
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureEdit1.Location = New System.Drawing.Point(0, 0)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.PictureEdit1.Properties.ShowMenu = False
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureEdit1.Size = New System.Drawing.Size(191, 232)
        Me.PictureEdit1.TabIndex = 3
        '
        'BtnViewImg
        '
        Me.BtnViewImg.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnViewImg.Location = New System.Drawing.Point(0, 232)
        Me.BtnViewImg.Name = "BtnViewImg"
        Me.BtnViewImg.Size = New System.Drawing.Size(191, 23)
        Me.BtnViewImg.TabIndex = 0
        Me.BtnViewImg.Text = "View Image"
        '
        'GCProduct
        '
        Me.GCProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProduct.Location = New System.Drawing.Point(0, 0)
        Me.GCProduct.MainView = Me.GVProduct
        Me.GCProduct.Name = "GCProduct"
        Me.GCProduct.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1, Me.RepositoryItemSearchLookUpEdit1})
        Me.GCProduct.Size = New System.Drawing.Size(544, 255)
        Me.GCProduct.TabIndex = 1
        Me.GCProduct.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProduct})
        '
        'GVProduct
        '
        Me.GVProduct.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnCode, Me.GridColumnColor, Me.GridColumnSize, Me.GridColumnSelectProduct, Me.GridColumnDesign, Me.GridColumnPrice, Me.GridColumnSeason, Me.GridColumnYearSeason, Me.GridColumnIdSample})
        Me.GVProduct.GridControl = Me.GCProduct
        Me.GVProduct.GroupCount = 2
        Me.GVProduct.Name = "GVProduct"
        Me.GVProduct.OptionsView.ShowFooter = True
        Me.GVProduct.OptionsView.ShowGroupPanel = False
        Me.GVProduct.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnYearSeason, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnSeason, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.OptionsColumn.AllowEdit = False
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 0
        '
        'GridColumnColor
        '
        Me.GridColumnColor.Caption = "Color"
        Me.GridColumnColor.FieldName = "color"
        Me.GridColumnColor.Name = "GridColumnColor"
        Me.GridColumnColor.OptionsColumn.AllowEdit = False
        Me.GridColumnColor.Visible = True
        Me.GridColumnColor.VisibleIndex = 2
        Me.GridColumnColor.Width = 83
        '
        'GridColumnSize
        '
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.OptionsColumn.AllowEdit = False
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 3
        '
        'GridColumnSelectProduct
        '
        Me.GridColumnSelectProduct.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnSelectProduct.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSelectProduct.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSelectProduct.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSelectProduct.Caption = "Select Product"
        Me.GridColumnSelectProduct.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnSelectProduct.FieldName = "is_select"
        Me.GridColumnSelectProduct.Name = "GridColumnSelectProduct"
        Me.GridColumnSelectProduct.Visible = True
        Me.GridColumnSelectProduct.VisibleIndex = 5
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'GridColumnDesign
        '
        Me.GridColumnDesign.Caption = "Description"
        Me.GridColumnDesign.FieldName = "name"
        Me.GridColumnDesign.FieldNameSortGroup = "id_sample"
        Me.GridColumnDesign.Name = "GridColumnDesign"
        Me.GridColumnDesign.OptionsColumn.AllowEdit = False
        Me.GridColumnDesign.Visible = True
        Me.GridColumnDesign.VisibleIndex = 1
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.Caption = "Price"
        Me.GridColumnPrice.ColumnEdit = Me.RepositoryItemSearchLookUpEdit1
        Me.GridColumnPrice.FieldName = "id_sample_ret_price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 4
        '
        'RepositoryItemSearchLookUpEdit1
        '
        Me.RepositoryItemSearchLookUpEdit1.AutoHeight = False
        Me.RepositoryItemSearchLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSearchLookUpEdit1.Name = "RepositoryItemSearchLookUpEdit1"
        Me.RepositoryItemSearchLookUpEdit1.NullText = "-Select Price-"
        Me.RepositoryItemSearchLookUpEdit1.View = Me.RepositoryItemSearchLookUpEdit1View
        '
        'RepositoryItemSearchLookUpEdit1View
        '
        Me.RepositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.RepositoryItemSearchLookUpEdit1View.Name = "RepositoryItemSearchLookUpEdit1View"
        Me.RepositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RepositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnSeason
        '
        Me.GridColumnSeason.Caption = "Season"
        Me.GridColumnSeason.FieldName = "season"
        Me.GridColumnSeason.FieldNameSortGroup = "id_season"
        Me.GridColumnSeason.Name = "GridColumnSeason"
        '
        'GridColumnYearSeason
        '
        Me.GridColumnYearSeason.Caption = "Year Season"
        Me.GridColumnYearSeason.FieldName = "season_year"
        Me.GridColumnYearSeason.Name = "GridColumnYearSeason"
        Me.GridColumnYearSeason.Visible = True
        Me.GridColumnYearSeason.VisibleIndex = 6
        '
        'GridColumnIdSample
        '
        Me.GridColumnIdSample.Caption = "Id Sample"
        Me.GridColumnIdSample.FieldName = "id_sample"
        Me.GridColumnIdSample.Name = "GridColumnIdSample"
        Me.GridColumnIdSample.OptionsColumn.AllowEdit = False
        '
        'FormSampleDelSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(744, 315)
        Me.Controls.Add(Me.GroupControlSample)
        Me.Controls.Add(Me.PanelControlNav)
        Me.MinimizeBox = False
        Me.Name = "FormSampleDelSingle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Sample"
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNav.ResumeLayout(False)
        CType(Me.CheckEditProduct.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlSample, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlSample.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.PanelControlImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlImg.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControlNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CheckEditProduct As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnChoose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControlSample As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCProduct As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProduct As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSelectProduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControlImg As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents BtnViewImg As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSearchLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnYearSeason As DevExpress.XtraGrid.Columns.GridColumn
End Class
