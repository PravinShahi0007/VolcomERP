<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAgingProductList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAgingProductList))
        Me.PanelControlSOH = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.LEPriceType = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEAccount = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnViewAcc = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnExportToXLSAcc = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnBrowseProduct = New DevExpress.XtraEditors.SimpleButton()
        Me.CEFindAllProduct = New DevExpress.XtraEditors.CheckEdit()
        Me.TxtProduct = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl29 = New DevExpress.XtraEditors.LabelControl()
        Me.DEUntilAcc = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl35 = New DevExpress.XtraEditors.LabelControl()
        Me.GridColumn31 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn32 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn33 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.GVList = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.PanelControlSOH, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlSOH.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.LEPriceType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.CEFindAllProduct.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtProduct.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilAcc.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilAcc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControlSOH
        '
        Me.PanelControlSOH.Controls.Add(Me.PanelControl3)
        Me.PanelControlSOH.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlSOH.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlSOH.Name = "PanelControlSOH"
        Me.PanelControlSOH.Size = New System.Drawing.Size(836, 140)
        Me.PanelControlSOH.TabIndex = 1
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.LEPriceType)
        Me.PanelControl3.Controls.Add(Me.LabelControl10)
        Me.PanelControl3.Controls.Add(Me.SLEAccount)
        Me.PanelControl3.Controls.Add(Me.PanelControl4)
        Me.PanelControl3.Controls.Add(Me.BtnBrowseProduct)
        Me.PanelControl3.Controls.Add(Me.CEFindAllProduct)
        Me.PanelControl3.Controls.Add(Me.TxtProduct)
        Me.PanelControl3.Controls.Add(Me.LabelControl29)
        Me.PanelControl3.Controls.Add(Me.DEUntilAcc)
        Me.PanelControl3.Controls.Add(Me.LabelControl35)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl3.Location = New System.Drawing.Point(2, 2)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(444, 136)
        Me.PanelControl3.TabIndex = 8927
        '
        'LEPriceType
        '
        Me.LEPriceType.Location = New System.Drawing.Point(183, 172)
        Me.LEPriceType.Name = "LEPriceType"
        Me.LEPriceType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEPriceType.Size = New System.Drawing.Size(185, 20)
        Me.LEPriceType.TabIndex = 8930
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(96, 175)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl10.TabIndex = 8929
        Me.LabelControl10.Text = "Price Type"
        '
        'SLEAccount
        '
        Me.SLEAccount.Location = New System.Drawing.Point(96, 12)
        Me.SLEAccount.Name = "SLEAccount"
        Me.SLEAccount.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLEAccount.Properties.Appearance.Options.UseFont = True
        Me.SLEAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEAccount.Properties.ShowClearButton = False
        Me.SLEAccount.Properties.View = Me.GridView2
        Me.SLEAccount.Size = New System.Drawing.Size(329, 20)
        Me.SLEAccount.TabIndex = 8928
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn31, Me.GridColumn32, Me.GridColumn33})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.BtnViewAcc)
        Me.PanelControl4.Controls.Add(Me.BtnExportToXLSAcc)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl4.Location = New System.Drawing.Point(2, 97)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(440, 37)
        Me.PanelControl4.TabIndex = 8925
        '
        'BtnViewAcc
        '
        Me.BtnViewAcc.Image = CType(resources.GetObject("BtnViewAcc.Image"), System.Drawing.Image)
        Me.BtnViewAcc.Location = New System.Drawing.Point(354, 9)
        Me.BtnViewAcc.LookAndFeel.SkinName = "Blue"
        Me.BtnViewAcc.Name = "BtnViewAcc"
        Me.BtnViewAcc.Size = New System.Drawing.Size(69, 20)
        Me.BtnViewAcc.TabIndex = 8906
        Me.BtnViewAcc.Text = "View"
        '
        'BtnExportToXLSAcc
        '
        Me.BtnExportToXLSAcc.Image = CType(resources.GetObject("BtnExportToXLSAcc.Image"), System.Drawing.Image)
        Me.BtnExportToXLSAcc.Location = New System.Drawing.Point(257, 9)
        Me.BtnExportToXLSAcc.LookAndFeel.SkinName = "Blue"
        Me.BtnExportToXLSAcc.Name = "BtnExportToXLSAcc"
        Me.BtnExportToXLSAcc.Size = New System.Drawing.Size(94, 20)
        Me.BtnExportToXLSAcc.TabIndex = 8907
        Me.BtnExportToXLSAcc.Text = "Export to XLS"
        '
        'BtnBrowseProduct
        '
        Me.BtnBrowseProduct.Enabled = False
        Me.BtnBrowseProduct.Image = CType(resources.GetObject("BtnBrowseProduct.Image"), System.Drawing.Image)
        Me.BtnBrowseProduct.Location = New System.Drawing.Point(399, 38)
        Me.BtnBrowseProduct.LookAndFeel.SkinName = "Blue"
        Me.BtnBrowseProduct.Name = "BtnBrowseProduct"
        Me.BtnBrowseProduct.Size = New System.Drawing.Size(26, 20)
        Me.BtnBrowseProduct.TabIndex = 8904
        Me.BtnBrowseProduct.Text = "..."
        '
        'CEFindAllProduct
        '
        Me.CEFindAllProduct.EditValue = True
        Me.CEFindAllProduct.Location = New System.Drawing.Point(12, 38)
        Me.CEFindAllProduct.Name = "CEFindAllProduct"
        Me.CEFindAllProduct.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CEFindAllProduct.Properties.Appearance.Options.UseFont = True
        Me.CEFindAllProduct.Properties.Caption = "All Product "
        Me.CEFindAllProduct.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CEFindAllProduct.Size = New System.Drawing.Size(72, 19)
        Me.CEFindAllProduct.TabIndex = 8907
        '
        'TxtProduct
        '
        Me.TxtProduct.EditValue = ""
        Me.TxtProduct.Enabled = False
        Me.TxtProduct.Location = New System.Drawing.Point(96, 38)
        Me.TxtProduct.Name = "TxtProduct"
        Me.TxtProduct.Size = New System.Drawing.Size(297, 20)
        Me.TxtProduct.TabIndex = 8906
        '
        'LabelControl29
        '
        Me.LabelControl29.Location = New System.Drawing.Point(13, 67)
        Me.LabelControl29.Name = "LabelControl29"
        Me.LabelControl29.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl29.TabIndex = 8903
        Me.LabelControl29.Text = "Age Until"
        '
        'DEUntilAcc
        '
        Me.DEUntilAcc.EditValue = Nothing
        Me.DEUntilAcc.Location = New System.Drawing.Point(96, 64)
        Me.DEUntilAcc.Name = "DEUntilAcc"
        Me.DEUntilAcc.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEUntilAcc.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntilAcc.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntilAcc.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntilAcc.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntilAcc.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntilAcc.Size = New System.Drawing.Size(329, 20)
        Me.DEUntilAcc.TabIndex = 8905
        '
        'LabelControl35
        '
        Me.LabelControl35.Location = New System.Drawing.Point(13, 15)
        Me.LabelControl35.Name = "LabelControl35"
        Me.LabelControl35.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl35.TabIndex = 8915
        Me.LabelControl35.Text = "Account"
        '
        'GridColumn31
        '
        Me.GridColumn31.Caption = "Id Comp"
        Me.GridColumn31.FieldName = "id_comp"
        Me.GridColumn31.Name = "GridColumn31"
        '
        'GridColumn32
        '
        Me.GridColumn32.Caption = "Account"
        Me.GridColumn32.FieldName = "comp_number"
        Me.GridColumn32.Name = "GridColumn32"
        Me.GridColumn32.Visible = True
        Me.GridColumn32.VisibleIndex = 0
        '
        'GridColumn33
        '
        Me.GridColumn33.Caption = "Description"
        Me.GridColumn33.FieldName = "comp_name_label"
        Me.GridColumn33.Name = "GridColumn33"
        Me.GridColumn33.Visible = True
        Me.GridColumn33.VisibleIndex = 1
        '
        'GCList
        '
        Me.GCList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCList.Location = New System.Drawing.Point(0, 140)
        Me.GCList.MainView = Me.GVList
        Me.GCList.Name = "GCList"
        Me.GCList.Size = New System.Drawing.Size(836, 362)
        Me.GCList.TabIndex = 2
        Me.GCList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVList})
        '
        'GVList
        '
        Me.GVList.GridControl = Me.GCList
        Me.GVList.Name = "GVList"
        Me.GVList.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVList.OptionsFind.AlwaysVisible = True
        Me.GVList.OptionsView.ShowGroupPanel = False
        '
        'FormAgingProductList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(836, 502)
        Me.Controls.Add(Me.GCList)
        Me.Controls.Add(Me.PanelControlSOH)
        Me.Name = "FormAgingProductList"
        Me.Text = "Product Age List"
        CType(Me.PanelControlSOH, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlSOH.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.LEPriceType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        CType(Me.CEFindAllProduct.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtProduct.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilAcc.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilAcc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControlSOH As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LEPriceType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEAccount As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn31 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn32 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn33 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnViewAcc As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnExportToXLSAcc As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnBrowseProduct As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CEFindAllProduct As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents TxtProduct As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl29 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEUntilAcc As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl35 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVList As DevExpress.XtraGrid.Views.Grid.GridView
End Class
