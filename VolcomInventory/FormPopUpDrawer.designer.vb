<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpDrawer
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
        Me.SLELocator = New DevExpress.XtraEditors.SearchLookUpEdit
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.SLEWH = New DevExpress.XtraEditors.SearchLookUpEdit
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl
        Me.SLEDrawer = New DevExpress.XtraEditors.SearchLookUpEdit
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.SLERack = New DevExpress.XtraEditors.SearchLookUpEdit
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl
        Me.BtnChoose = New DevExpress.XtraEditors.SimpleButton
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.GridColumnIdWHLocator = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnWHLOcatorCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnLocatroCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdComp = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCompNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCompName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdWHDrawer = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnWHDrawerCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnWHDrawer = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdWhRack = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnWHRackCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnWHRack = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.SLELocator.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEWH.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEDrawer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLERack.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SLELocator
        '
        Me.SLELocator.Location = New System.Drawing.Point(63, 45)
        Me.SLELocator.Name = "SLELocator"
        Me.SLELocator.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLELocator.Properties.Appearance.Options.UseFont = True
        Me.SLELocator.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLELocator.Properties.View = Me.GridView3
        Me.SLELocator.Size = New System.Drawing.Size(317, 20)
        Me.SLELocator.TabIndex = 8
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdWHLocator, Me.GridColumnWHLOcatorCode, Me.GridColumnLocatroCode})
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'SLEWH
        '
        Me.SLEWH.Location = New System.Drawing.Point(63, 12)
        Me.SLEWH.Name = "SLEWH"
        Me.SLEWH.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLEWH.Properties.Appearance.Options.UseFont = True
        Me.SLEWH.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEWH.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEWH.Size = New System.Drawing.Size(316, 20)
        Me.SLEWH.TabIndex = 7
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdComp, Me.GridColumnCompNumber, Me.GridColumnCompName})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'LabelControl10
        '
        Me.LabelControl10.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl10.Location = New System.Drawing.Point(14, 113)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl10.TabIndex = 5
        Me.LabelControl10.Text = "Drawer"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(14, 48)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl6.TabIndex = 3
        Me.LabelControl6.Text = "Locator"
        '
        'SLEDrawer
        '
        Me.SLEDrawer.Location = New System.Drawing.Point(65, 110)
        Me.SLEDrawer.Name = "SLEDrawer"
        Me.SLEDrawer.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLEDrawer.Properties.Appearance.Options.UseFont = True
        Me.SLEDrawer.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEDrawer.Properties.View = Me.GridView5
        Me.SLEDrawer.Size = New System.Drawing.Size(315, 20)
        Me.SLEDrawer.TabIndex = 10
        '
        'GridView5
        '
        Me.GridView5.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdWHDrawer, Me.GridColumnWHDrawerCode, Me.GridColumnWHDrawer})
        Me.GridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView5.Name = "GridView5"
        Me.GridView5.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView5.OptionsView.ShowGroupPanel = False
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(14, 15)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(17, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "WH"
        '
        'SLERack
        '
        Me.SLERack.Location = New System.Drawing.Point(63, 78)
        Me.SLERack.Name = "SLERack"
        Me.SLERack.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLERack.Properties.Appearance.Options.UseFont = True
        Me.SLERack.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLERack.Properties.View = Me.GridView4
        Me.SLERack.Size = New System.Drawing.Size(317, 20)
        Me.SLERack.TabIndex = 9
        '
        'GridView4
        '
        Me.GridView4.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdWhRack, Me.GridColumnWHRackCode, Me.GridColumnWHRack})
        Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView4.OptionsView.ShowGroupPanel = False
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Location = New System.Drawing.Point(14, 81)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl9.TabIndex = 4
        Me.LabelControl9.Text = "Rack"
        '
        'BtnChoose
        '
        Me.BtnChoose.Location = New System.Drawing.Point(322, 147)
        Me.BtnChoose.Name = "BtnChoose"
        Me.BtnChoose.Size = New System.Drawing.Size(57, 23)
        Me.BtnChoose.TabIndex = 11
        Me.BtnChoose.Text = "Choose"
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(261, 147)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(55, 23)
        Me.BtnCancel.TabIndex = 12
        Me.BtnCancel.Text = "Cancel"
        '
        'GridColumnIdWHLocator
        '
        Me.GridColumnIdWHLocator.Caption = "Id Wh Locator"
        Me.GridColumnIdWHLocator.FieldName = "id_wh_locator"
        Me.GridColumnIdWHLocator.Name = "GridColumnIdWHLocator"
        Me.GridColumnIdWHLocator.Visible = True
        Me.GridColumnIdWHLocator.VisibleIndex = 2
        '
        'GridColumnWHLOcatorCode
        '
        Me.GridColumnWHLOcatorCode.Caption = "Code"
        Me.GridColumnWHLOcatorCode.FieldName = "wh_locator_code"
        Me.GridColumnWHLOcatorCode.Name = "GridColumnWHLOcatorCode"
        Me.GridColumnWHLOcatorCode.Visible = True
        Me.GridColumnWHLOcatorCode.VisibleIndex = 0
        '
        'GridColumnLocatroCode
        '
        Me.GridColumnLocatroCode.Caption = "Locator"
        Me.GridColumnLocatroCode.FieldName = "wh_locator"
        Me.GridColumnLocatroCode.Name = "GridColumnLocatroCode"
        Me.GridColumnLocatroCode.Visible = True
        Me.GridColumnLocatroCode.VisibleIndex = 1
        '
        'GridColumnIdComp
        '
        Me.GridColumnIdComp.Caption = "Id Comp"
        Me.GridColumnIdComp.FieldName = "id_comp"
        Me.GridColumnIdComp.Name = "GridColumnIdComp"
        '
        'GridColumnCompNumber
        '
        Me.GridColumnCompNumber.Caption = "Code"
        Me.GridColumnCompNumber.FieldName = "comp_number"
        Me.GridColumnCompNumber.Name = "GridColumnCompNumber"
        Me.GridColumnCompNumber.Visible = True
        Me.GridColumnCompNumber.VisibleIndex = 0
        '
        'GridColumnCompName
        '
        Me.GridColumnCompName.Caption = "Company Name"
        Me.GridColumnCompName.FieldName = "comp_name"
        Me.GridColumnCompName.Name = "GridColumnCompName"
        Me.GridColumnCompName.Visible = True
        Me.GridColumnCompName.VisibleIndex = 1
        '
        'GridColumnIdWHDrawer
        '
        Me.GridColumnIdWHDrawer.Caption = "Id WH Drawer"
        Me.GridColumnIdWHDrawer.FieldName = "id_wh_drawer"
        Me.GridColumnIdWHDrawer.Name = "GridColumnIdWHDrawer"
        '
        'GridColumnWHDrawerCode
        '
        Me.GridColumnWHDrawerCode.Caption = "Code"
        Me.GridColumnWHDrawerCode.FieldName = "wh_drawer_code"
        Me.GridColumnWHDrawerCode.Name = "GridColumnWHDrawerCode"
        Me.GridColumnWHDrawerCode.Visible = True
        Me.GridColumnWHDrawerCode.VisibleIndex = 0
        '
        'GridColumnWHDrawer
        '
        Me.GridColumnWHDrawer.Caption = "Drawer"
        Me.GridColumnWHDrawer.FieldName = "wh_drawer"
        Me.GridColumnWHDrawer.Name = "GridColumnWHDrawer"
        Me.GridColumnWHDrawer.Visible = True
        Me.GridColumnWHDrawer.VisibleIndex = 1
        '
        'GridColumnIdWhRack
        '
        Me.GridColumnIdWhRack.Caption = "Id WH Rack"
        Me.GridColumnIdWhRack.FieldName = "id_wh_rack"
        Me.GridColumnIdWhRack.Name = "GridColumnIdWhRack"
        '
        'GridColumnWHRackCode
        '
        Me.GridColumnWHRackCode.Caption = "Code"
        Me.GridColumnWHRackCode.FieldName = "wh_rack_code"
        Me.GridColumnWHRackCode.Name = "GridColumnWHRackCode"
        Me.GridColumnWHRackCode.Visible = True
        Me.GridColumnWHRackCode.VisibleIndex = 0
        '
        'GridColumnWHRack
        '
        Me.GridColumnWHRack.Caption = "Rack"
        Me.GridColumnWHRack.FieldName = "wh_rack"
        Me.GridColumnWHRack.Name = "GridColumnWHRack"
        Me.GridColumnWHRack.Visible = True
        Me.GridColumnWHRack.VisibleIndex = 1
        '
        'FormPopUpDrawer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 182)
        Me.Controls.Add(Me.BtnChoose)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.SLELocator)
        Me.Controls.Add(Me.SLEWH)
        Me.Controls.Add(Me.SLEDrawer)
        Me.Controls.Add(Me.LabelControl10)
        Me.Controls.Add(Me.LabelControl9)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.SLERack)
        Me.Controls.Add(Me.LabelControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPopUpDrawer"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Drawer"
        CType(Me.SLELocator.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEWH.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEDrawer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLERack.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SLELocator As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdWHLocator As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnWHLOcatorCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLocatroCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLEWH As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdComp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEDrawer As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdWHDrawer As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnWHDrawerCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnWHDrawer As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLERack As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdWhRack As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnWHRackCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnWHRack As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnChoose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
End Class
