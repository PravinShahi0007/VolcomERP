<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSampleStockOpnameSingle
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
        Me.GroupControlSample = New DevExpress.XtraEditors.GroupControl
        Me.GCSample = New DevExpress.XtraGrid.GridControl
        Me.GVSample = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnSelectProduct = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.GridColumnDesign = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdSample = New DevExpress.XtraGrid.Columns.GridColumn
        Me.PanelControlImg = New DevExpress.XtraEditors.PanelControl
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit
        Me.BtnViewImg = New DevExpress.XtraEditors.SimpleButton
        Me.PanelControlNav = New DevExpress.XtraEditors.PanelControl
        Me.CheckEditProduct = New DevExpress.XtraEditors.CheckEdit
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BtnChoose = New DevExpress.XtraEditors.SimpleButton
        CType(Me.GroupControlSample, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlSample.SuspendLayout()
        CType(Me.GCSample, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSample, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlImg.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNav.SuspendLayout()
        CType(Me.CheckEditProduct.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControlSample
        '
        Me.GroupControlSample.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupControlSample.Controls.Add(Me.GCSample)
        Me.GroupControlSample.Controls.Add(Me.PanelControlImg)
        Me.GroupControlSample.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlSample.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlSample.Name = "GroupControlSample"
        Me.GroupControlSample.Size = New System.Drawing.Size(831, 267)
        Me.GroupControlSample.TabIndex = 11
        Me.GroupControlSample.Text = "Sample"
        '
        'GCSample
        '
        Me.GCSample.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSample.Location = New System.Drawing.Point(168, 22)
        Me.GCSample.MainView = Me.GVSample
        Me.GCSample.Name = "GCSample"
        Me.GCSample.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCSample.Size = New System.Drawing.Size(661, 243)
        Me.GCSample.TabIndex = 1
        Me.GCSample.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSample})
        '
        'GVSample
        '
        Me.GVSample.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnCode, Me.GridColumnColor, Me.GridColumnSize, Me.GridColumnSelectProduct, Me.GridColumnDesign, Me.GridColumnIdSample})
        Me.GVSample.GridControl = Me.GCSample
        Me.GVSample.GroupCount = 1
        Me.GVSample.Name = "GVSample"
        Me.GVSample.OptionsView.ShowFooter = True
        Me.GVSample.OptionsView.ShowGroupPanel = False
        Me.GVSample.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnDesign, DevExpress.Data.ColumnSortOrder.Ascending)})
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
        Me.GridColumnColor.VisibleIndex = 1
        Me.GridColumnColor.Width = 83
        '
        'GridColumnSize
        '
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.OptionsColumn.AllowEdit = False
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 2
        '
        'GridColumnSelectProduct
        '
        Me.GridColumnSelectProduct.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnSelectProduct.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSelectProduct.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSelectProduct.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSelectProduct.Caption = "Select Sample"
        Me.GridColumnSelectProduct.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnSelectProduct.FieldName = "is_select"
        Me.GridColumnSelectProduct.Name = "GridColumnSelectProduct"
        Me.GridColumnSelectProduct.Visible = True
        Me.GridColumnSelectProduct.VisibleIndex = 3
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
        Me.GridColumnDesign.Caption = "Name"
        Me.GridColumnDesign.FieldName = "name"
        Me.GridColumnDesign.FieldNameSortGroup = "id_sample"
        Me.GridColumnDesign.Name = "GridColumnDesign"
        Me.GridColumnDesign.OptionsColumn.AllowEdit = False
        '
        'GridColumnIdSample
        '
        Me.GridColumnIdSample.Caption = "Id Sample "
        Me.GridColumnIdSample.FieldName = "id_sample"
        Me.GridColumnIdSample.Name = "GridColumnIdSample"
        '
        'PanelControlImg
        '
        Me.PanelControlImg.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlImg.Controls.Add(Me.PictureEdit1)
        Me.PanelControlImg.Controls.Add(Me.BtnViewImg)
        Me.PanelControlImg.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControlImg.Location = New System.Drawing.Point(2, 22)
        Me.PanelControlImg.Name = "PanelControlImg"
        Me.PanelControlImg.Size = New System.Drawing.Size(166, 243)
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
        Me.PictureEdit1.Size = New System.Drawing.Size(166, 220)
        Me.PictureEdit1.TabIndex = 3
        '
        'BtnViewImg
        '
        Me.BtnViewImg.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnViewImg.Location = New System.Drawing.Point(0, 220)
        Me.BtnViewImg.Name = "BtnViewImg"
        Me.BtnViewImg.Size = New System.Drawing.Size(166, 23)
        Me.BtnViewImg.TabIndex = 0
        Me.BtnViewImg.Text = "View Image"
        '
        'PanelControlNav
        '
        Me.PanelControlNav.Controls.Add(Me.CheckEditProduct)
        Me.PanelControlNav.Controls.Add(Me.BtnCancel)
        Me.PanelControlNav.Controls.Add(Me.BtnChoose)
        Me.PanelControlNav.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControlNav.Location = New System.Drawing.Point(0, 267)
        Me.PanelControlNav.LookAndFeel.SkinName = "Blue"
        Me.PanelControlNav.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControlNav.Name = "PanelControlNav"
        Me.PanelControlNav.Size = New System.Drawing.Size(831, 36)
        Me.PanelControlNav.TabIndex = 10
        '
        'CheckEditProduct
        '
        Me.CheckEditProduct.Location = New System.Drawing.Point(12, 8)
        Me.CheckEditProduct.Name = "CheckEditProduct"
        Me.CheckEditProduct.Properties.Caption = "Select All Sample"
        Me.CheckEditProduct.Size = New System.Drawing.Size(119, 19)
        Me.CheckEditProduct.TabIndex = 2
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.Location = New System.Drawing.Point(679, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 32)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnChoose
        '
        Me.BtnChoose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnChoose.Location = New System.Drawing.Point(754, 2)
        Me.BtnChoose.Name = "BtnChoose"
        Me.BtnChoose.Size = New System.Drawing.Size(75, 32)
        Me.BtnChoose.TabIndex = 3
        Me.BtnChoose.Text = "Choose"
        '
        'FormSampleStockOpnameSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(831, 303)
        Me.Controls.Add(Me.GroupControlSample)
        Me.Controls.Add(Me.PanelControlNav)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSampleStockOpnameSingle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Opname Single"
        CType(Me.GroupControlSample, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlSample.ResumeLayout(False)
        CType(Me.GCSample, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSample, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlImg.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNav.ResumeLayout(False)
        CType(Me.CheckEditProduct.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControlSample As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCSample As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSample As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSelectProduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControlImg As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents BtnViewImg As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControlNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CheckEditProduct As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnChoose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnIdSample As DevExpress.XtraGrid.Columns.GridColumn
End Class
