﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form3plRate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3plRate))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BImport = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEDelType = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SLEInboundOutbound = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BView = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLECargo = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SLVCargo = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRange = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.BEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.GCListRate = New DevExpress.XtraGrid.GridControl()
        Me.GVListRate = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEDelType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEInboundOutbound.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLECargo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLVCargo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCListRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BPrint)
        Me.PanelControl1.Controls.Add(Me.BImport)
        Me.PanelControl1.Controls.Add(Me.SLEDelType)
        Me.PanelControl1.Controls.Add(Me.SLEInboundOutbound)
        Me.PanelControl1.Controls.Add(Me.BView)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.SLECargo)
        Me.PanelControl1.Controls.Add(Me.BAdd)
        Me.PanelControl1.Controls.Add(Me.BEdit)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1121, 45)
        Me.PanelControl1.TabIndex = 0
        '
        'BPrint
        '
        Me.BPrint.Location = New System.Drawing.Point(667, 11)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(48, 23)
        Me.BPrint.TabIndex = 17
        Me.BPrint.Text = "print"
        '
        'BImport
        '
        Me.BImport.Dock = System.Windows.Forms.DockStyle.Right
        Me.BImport.Image = CType(resources.GetObject("BImport.Image"), System.Drawing.Image)
        Me.BImport.Location = New System.Drawing.Point(842, 2)
        Me.BImport.Name = "BImport"
        Me.BImport.Size = New System.Drawing.Size(101, 41)
        Me.BImport.TabIndex = 16
        Me.BImport.Text = "Import"
        Me.BImport.Visible = False
        '
        'SLEDelType
        '
        Me.SLEDelType.Location = New System.Drawing.Point(257, 13)
        Me.SLEDelType.Name = "SLEDelType"
        Me.SLEDelType.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLEDelType.Properties.Appearance.Options.UseFont = True
        Me.SLEDelType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEDelType.Properties.NullText = "-"
        Me.SLEDelType.Properties.View = Me.GridView1
        Me.SLEDelType.Size = New System.Drawing.Size(172, 20)
        Me.SLEDelType.TabIndex = 15
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn14, Me.GridColumn15})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn14
        '
        Me.GridColumn14.FieldName = "id_del_type"
        Me.GridColumn14.Name = "GridColumn14"
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Delivery Type"
        Me.GridColumn15.FieldName = "del_type"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 0
        '
        'SLEInboundOutbound
        '
        Me.SLEInboundOutbound.Location = New System.Drawing.Point(435, 13)
        Me.SLEInboundOutbound.Name = "SLEInboundOutbound"
        Me.SLEInboundOutbound.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLEInboundOutbound.Properties.Appearance.Options.UseFont = True
        Me.SLEInboundOutbound.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEInboundOutbound.Properties.NullText = "-"
        Me.SLEInboundOutbound.Properties.View = Me.GridView2
        Me.SLEInboundOutbound.Size = New System.Drawing.Size(172, 20)
        Me.SLEInboundOutbound.TabIndex = 14
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn10, Me.GridColumn11})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.ReadOnly = True
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "ID Out iN"
        Me.GridColumn10.FieldName = "id_type"
        Me.GridColumn10.Name = "GridColumn10"
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Type"
        Me.GridColumn11.FieldName = "type"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 0
        '
        'BView
        '
        Me.BView.Location = New System.Drawing.Point(613, 11)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(48, 23)
        Me.BView.TabIndex = 10
        Me.BView.Text = "view"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 16)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl1.TabIndex = 9
        Me.LabelControl1.Text = "Vendor"
        '
        'SLECargo
        '
        Me.SLECargo.Location = New System.Drawing.Point(52, 13)
        Me.SLECargo.Name = "SLECargo"
        Me.SLECargo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLECargo.Properties.Appearance.Options.UseFont = True
        Me.SLECargo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLECargo.Properties.NullText = "-"
        Me.SLECargo.Properties.View = Me.SLVCargo
        Me.SLECargo.Size = New System.Drawing.Size(199, 20)
        Me.SLECargo.TabIndex = 8
        '
        'SLVCargo
        '
        Me.SLVCargo.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdSeason, Me.GridColumnRange})
        Me.SLVCargo.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SLVCargo.Name = "SLVCargo"
        Me.SLVCargo.OptionsBehavior.ReadOnly = True
        Me.SLVCargo.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SLVCargo.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdSeason
        '
        Me.GridColumnIdSeason.Caption = "ID Cargo"
        Me.GridColumnIdSeason.FieldName = "id_comp"
        Me.GridColumnIdSeason.Name = "GridColumnIdSeason"
        '
        'GridColumnRange
        '
        Me.GridColumnRange.Caption = "Vendor Name"
        Me.GridColumnRange.FieldName = "comp_name"
        Me.GridColumnRange.Name = "GridColumnRange"
        Me.GridColumnRange.Visible = True
        Me.GridColumnRange.VisibleIndex = 0
        '
        'BAdd
        '
        Me.BAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAdd.Image = CType(resources.GetObject("BAdd.Image"), System.Drawing.Image)
        Me.BAdd.Location = New System.Drawing.Point(943, 2)
        Me.BAdd.Name = "BAdd"
        Me.BAdd.Size = New System.Drawing.Size(88, 41)
        Me.BAdd.TabIndex = 1
        Me.BAdd.Text = "Add"
        '
        'BEdit
        '
        Me.BEdit.Dock = System.Windows.Forms.DockStyle.Right
        Me.BEdit.Image = CType(resources.GetObject("BEdit.Image"), System.Drawing.Image)
        Me.BEdit.Location = New System.Drawing.Point(1031, 2)
        Me.BEdit.Name = "BEdit"
        Me.BEdit.Size = New System.Drawing.Size(88, 41)
        Me.BEdit.TabIndex = 2
        Me.BEdit.Text = "Edit"
        '
        'GCListRate
        '
        Me.GCListRate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListRate.Location = New System.Drawing.Point(0, 45)
        Me.GCListRate.MainView = Me.GVListRate
        Me.GCListRate.Name = "GCListRate"
        Me.GCListRate.Size = New System.Drawing.Size(1121, 578)
        Me.GCListRate.TabIndex = 1
        Me.GCListRate.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListRate})
        '
        'GVListRate
        '
        Me.GVListRate.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn13, Me.GridColumn12, Me.GridColumn6, Me.GridColumn4, Me.GridColumn5, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9})
        Me.GVListRate.GridControl = Me.GCListRate
        Me.GVListRate.Name = "GVListRate"
        Me.GVListRate.OptionsBehavior.Editable = False
        Me.GVListRate.OptionsBehavior.ReadOnly = True
        Me.GVListRate.OptionsFind.AlwaysVisible = True
        Me.GVListRate.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id"
        Me.GridColumn1.FieldName = "id_3pl_rate"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "ID City"
        Me.GridColumn2.FieldName = "id_city"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Sub District"
        Me.GridColumn3.FieldName = "sub_district"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "City"
        Me.GridColumn13.FieldName = "city"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 2
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "State"
        Me.GridColumn12.FieldName = "state"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 3
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Cargo Code"
        Me.GridColumn6.FieldName = "cargo_code"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 0
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Rate"
        Me.GridColumn4.DisplayFormat.FormatString = "N2"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn4.FieldName = "cargo_rate"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 4
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Lead Time"
        Me.GridColumn5.DisplayFormat.FormatString = "N0"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn5.FieldName = "cargo_lead_time"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 5
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Minimum Weight (Kg)"
        Me.GridColumn7.DisplayFormat.FormatString = "N0"
        Me.GridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn7.FieldName = "cargo_min_weight"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 6
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Updated Date"
        Me.GridColumn8.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn8.FieldName = "input_datetime"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 7
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Update By"
        Me.GridColumn9.FieldName = "employee_name"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 8
        '
        'Form3plRate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1121, 623)
        Me.Controls.Add(Me.GCListRate)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form3plRate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Rate"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLEDelType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEInboundOutbound.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLECargo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLVCargo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCListRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLECargo As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SLVCargo As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRange As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCListRate As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListRate As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLEInboundOutbound As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLEDelType As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BImport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
End Class
