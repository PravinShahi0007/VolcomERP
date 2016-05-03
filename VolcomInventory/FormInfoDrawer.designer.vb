<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInfoDrawer
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
        Me.LabelSubTitle = New DevExpress.XtraEditors.LabelControl
        Me.LabelTitle = New DevExpress.XtraEditors.LabelControl
        Me.PanelControlImg = New DevExpress.XtraEditors.PanelControl
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit
        Me.BtnViewImg = New DevExpress.XtraEditors.SimpleButton
        Me.GCSampleDrawer = New DevExpress.XtraGrid.GridControl
        Me.GVSampleDrawer = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnWHInfo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnLocatorInfo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnRackInfo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnDrawerInfo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQtyInfo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdWhDrawerInfo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdPrice = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControlImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlImg.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCSampleDrawer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSampleDrawer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.Blue
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.Controls.Add(Me.LabelSubTitle)
        Me.PanelControl1.Controls.Add(Me.LabelTitle)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(834, 59)
        Me.PanelControl1.TabIndex = 34
        '
        'LabelSubTitle
        '
        Me.LabelSubTitle.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSubTitle.Location = New System.Drawing.Point(12, 32)
        Me.LabelSubTitle.Name = "LabelSubTitle"
        Me.LabelSubTitle.Size = New System.Drawing.Size(64, 15)
        Me.LabelSubTitle.TabIndex = 30
        Me.LabelSubTitle.Text = "SRS No : xxx"
        '
        'LabelTitle
        '
        Me.LabelTitle.Appearance.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitle.Location = New System.Drawing.Point(12, 9)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(94, 23)
        Me.LabelTitle.TabIndex = 29
        Me.LabelTitle.Text = "Info Drawer"
        '
        'PanelControlImg
        '
        Me.PanelControlImg.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlImg.Controls.Add(Me.PictureEdit1)
        Me.PanelControlImg.Controls.Add(Me.BtnViewImg)
        Me.PanelControlImg.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControlImg.Location = New System.Drawing.Point(0, 59)
        Me.PanelControlImg.Name = "PanelControlImg"
        Me.PanelControlImg.Size = New System.Drawing.Size(185, 236)
        Me.PanelControlImg.TabIndex = 35
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureEdit1.Location = New System.Drawing.Point(0, 0)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.PictureEdit1.Properties.ShowMenu = False
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureEdit1.Size = New System.Drawing.Size(185, 213)
        Me.PictureEdit1.TabIndex = 3
        '
        'BtnViewImg
        '
        Me.BtnViewImg.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnViewImg.Location = New System.Drawing.Point(0, 213)
        Me.BtnViewImg.Name = "BtnViewImg"
        Me.BtnViewImg.Size = New System.Drawing.Size(185, 23)
        Me.BtnViewImg.TabIndex = 0
        Me.BtnViewImg.Text = "View Image"
        '
        'GCSampleDrawer
        '
        Me.GCSampleDrawer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSampleDrawer.Location = New System.Drawing.Point(185, 59)
        Me.GCSampleDrawer.MainView = Me.GVSampleDrawer
        Me.GCSampleDrawer.Name = "GCSampleDrawer"
        Me.GCSampleDrawer.Size = New System.Drawing.Size(649, 236)
        Me.GCSampleDrawer.TabIndex = 36
        Me.GCSampleDrawer.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSampleDrawer})
        '
        'GVSampleDrawer
        '
        Me.GVSampleDrawer.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnWHInfo, Me.GridColumnLocatorInfo, Me.GridColumnRackInfo, Me.GridColumnDrawerInfo, Me.GridColumnQtyInfo, Me.GridColumnIdWhDrawerInfo, Me.GridColumnIdPrice, Me.GridColumnPrice})
        Me.GVSampleDrawer.GridControl = Me.GCSampleDrawer
        Me.GVSampleDrawer.Name = "GVSampleDrawer"
        Me.GVSampleDrawer.OptionsBehavior.Editable = False
        Me.GVSampleDrawer.OptionsView.ShowFooter = True
        Me.GVSampleDrawer.OptionsView.ShowGroupPanel = False
        '
        'GridColumnWHInfo
        '
        Me.GridColumnWHInfo.Caption = "WH"
        Me.GridColumnWHInfo.FieldName = "comp_name"
        Me.GridColumnWHInfo.Name = "GridColumnWHInfo"
        Me.GridColumnWHInfo.Visible = True
        Me.GridColumnWHInfo.VisibleIndex = 0
        '
        'GridColumnLocatorInfo
        '
        Me.GridColumnLocatorInfo.Caption = "Locator"
        Me.GridColumnLocatorInfo.FieldName = "wh_locator"
        Me.GridColumnLocatorInfo.Name = "GridColumnLocatorInfo"
        Me.GridColumnLocatorInfo.Visible = True
        Me.GridColumnLocatorInfo.VisibleIndex = 1
        '
        'GridColumnRackInfo
        '
        Me.GridColumnRackInfo.Caption = "Rack"
        Me.GridColumnRackInfo.FieldName = "wh_rack"
        Me.GridColumnRackInfo.Name = "GridColumnRackInfo"
        Me.GridColumnRackInfo.Visible = True
        Me.GridColumnRackInfo.VisibleIndex = 2
        '
        'GridColumnDrawerInfo
        '
        Me.GridColumnDrawerInfo.Caption = "Drawer"
        Me.GridColumnDrawerInfo.FieldName = "wh_drawer"
        Me.GridColumnDrawerInfo.Name = "GridColumnDrawerInfo"
        Me.GridColumnDrawerInfo.Visible = True
        Me.GridColumnDrawerInfo.VisibleIndex = 3
        '
        'GridColumnQtyInfo
        '
        Me.GridColumnQtyInfo.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQtyInfo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyInfo.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQtyInfo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyInfo.Caption = "Qty"
        Me.GridColumnQtyInfo.DisplayFormat.FormatString = "N2"
        Me.GridColumnQtyInfo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyInfo.FieldName = "qty_all_sample"
        Me.GridColumnQtyInfo.Name = "GridColumnQtyInfo"
        Me.GridColumnQtyInfo.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_all_sample", "{0:n2}")})
        Me.GridColumnQtyInfo.Visible = True
        Me.GridColumnQtyInfo.VisibleIndex = 4
        '
        'GridColumnIdWhDrawerInfo
        '
        Me.GridColumnIdWhDrawerInfo.Caption = "Id WH Drawer Info"
        Me.GridColumnIdWhDrawerInfo.FieldName = "id_wh_drawer"
        Me.GridColumnIdWhDrawerInfo.Name = "GridColumnIdWhDrawerInfo"
        '
        'GridColumnIdPrice
        '
        Me.GridColumnIdPrice.Caption = "Id Mat Det Price"
        Me.GridColumnIdPrice.FieldName = "id_mat_det_price"
        Me.GridColumnIdPrice.Name = "GridColumnIdPrice"
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPrice.Caption = "Price"
        Me.GridColumnPrice.DisplayFormat.FormatString = "N2"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 5
        '
        'FormInfoDrawer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 295)
        Me.Controls.Add(Me.GCSampleDrawer)
        Me.Controls.Add(Me.PanelControlImg)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormInfoDrawer"
        Me.ShowInTaskbar = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Info Drawer"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.PanelControlImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlImg.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCSampleDrawer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSampleDrawer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelSubTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControlImg As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents BtnViewImg As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCSampleDrawer As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSampleDrawer As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnWHInfo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLocatorInfo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRackInfo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDrawerInfo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyInfo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdWhDrawerInfo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
End Class
