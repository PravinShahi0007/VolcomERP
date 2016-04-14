<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpSample
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
        Me.GroupGeneral = New DevExpress.XtraEditors.GroupControl
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit
        Me.BView = New DevExpress.XtraEditors.SimpleButton
        Me.GCSample = New DevExpress.XtraGrid.GridControl
        Me.GVSample = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.PanelControlButton = New DevExpress.XtraEditors.PanelControl
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BSave = New DevExpress.XtraEditors.SimpleButton
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneral.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCSample, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSample, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlButton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlButton.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupGeneral
        '
        Me.GroupGeneral.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupGeneral.Controls.Add(Me.PictureEdit1)
        Me.GroupGeneral.Controls.Add(Me.BView)
        Me.GroupGeneral.Controls.Add(Me.GCSample)
        Me.GroupGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupGeneral.Location = New System.Drawing.Point(0, 0)
        Me.GroupGeneral.Name = "GroupGeneral"
        Me.GroupGeneral.Size = New System.Drawing.Size(837, 288)
        Me.GroupGeneral.TabIndex = 35
        Me.GroupGeneral.Text = "Sample"
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureEdit1.Location = New System.Drawing.Point(2, 22)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.Image
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureEdit1.Size = New System.Drawing.Size(245, 241)
        Me.PictureEdit1.TabIndex = 97
        '
        'BView
        '
        Me.BView.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BView.Location = New System.Drawing.Point(2, 263)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(245, 23)
        Me.BView.TabIndex = 96
        Me.BView.Text = "View"
        '
        'GCSample
        '
        Me.GCSample.Dock = System.Windows.Forms.DockStyle.Right
        Me.GCSample.Location = New System.Drawing.Point(247, 22)
        Me.GCSample.MainView = Me.GVSample
        Me.GCSample.Name = "GCSample"
        Me.GCSample.Size = New System.Drawing.Size(588, 264)
        Me.GCSample.TabIndex = 11
        Me.GCSample.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSample, Me.GridView3})
        '
        'GVSample
        '
        Me.GVSample.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn6, Me.GridColumn5, Me.GridColumn3, Me.GridColumnColor, Me.GridColumn4, Me.ColSize, Me.GridColumn2})
        Me.GVSample.GridControl = Me.GCSample
        Me.GVSample.GroupCount = 1
        Me.GVSample.Name = "GVSample"
        Me.GVSample.OptionsBehavior.Editable = False
        Me.GVSample.OptionsFind.AlwaysVisible = True
        Me.GVSample.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.GVSample.OptionsView.ShowGroupPanel = False
        Me.GVSample.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn2, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id Sample"
        Me.GridColumn1.FieldName = "id_sample"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "US Code"
        Me.GridColumn6.FieldName = "sample_us_code"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 0
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Code"
        Me.GridColumn5.FieldName = "sample_code"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Description"
        Me.GridColumn3.FieldName = "sample_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "UOM"
        Me.GridColumn4.FieldName = "uom"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 5
        '
        'ColSize
        '
        Me.ColSize.Caption = "Size"
        Me.ColSize.FieldName = "Size"
        Me.ColSize.Name = "ColSize"
        Me.ColSize.Visible = True
        Me.ColSize.VisibleIndex = 4
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Season"
        Me.GridColumn2.FieldName = "season"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.GCSample
        Me.GridView3.Name = "GridView3"
        '
        'PanelControlButton
        '
        Me.PanelControlButton.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlButton.Controls.Add(Me.BCancel)
        Me.PanelControlButton.Controls.Add(Me.BSave)
        Me.PanelControlButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControlButton.Location = New System.Drawing.Point(0, 288)
        Me.PanelControlButton.Name = "PanelControlButton"
        Me.PanelControlButton.Size = New System.Drawing.Size(837, 38)
        Me.PanelControlButton.TabIndex = 34
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Location = New System.Drawing.Point(679, 8)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(70, 23)
        Me.BCancel.TabIndex = 2
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Location = New System.Drawing.Point(755, 8)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(70, 23)
        Me.BSave.TabIndex = 1
        Me.BSave.Text = "Save"
        '
        'GridColumnColor
        '
        Me.GridColumnColor.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnColor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnColor.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnColor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnColor.Caption = "Color"
        Me.GridColumnColor.FieldName = "Color"
        Me.GridColumnColor.Name = "GridColumnColor"
        Me.GridColumnColor.Visible = True
        Me.GridColumnColor.VisibleIndex = 3
        '
        'FormPopUpSample
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 326)
        Me.Controls.Add(Me.GroupGeneral)
        Me.Controls.Add(Me.PanelControlButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPopUpSample"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Sample"
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneral.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCSample, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSample, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlButton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlButton.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupGeneral As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCSample As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSample As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControlButton As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
End Class
