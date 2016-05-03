<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSOHPriceDet
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
        Me.GroupGeneralHeader = New DevExpress.XtraEditors.GroupControl
        Me.TERangeDesc = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.TERange = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl
        Me.GCSelf = New DevExpress.XtraGrid.GridControl
        Me.GVSelf = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.BEmpty = New DevExpress.XtraEditors.SimpleButton
        Me.BImport = New DevExpress.XtraEditors.SimpleButton
        CType(Me.GroupGeneralHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneralHeader.SuspendLayout()
        CType(Me.TERangeDesc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TERange.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCSelf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSelf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupGeneralHeader
        '
        Me.GroupGeneralHeader.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupGeneralHeader.Controls.Add(Me.TERangeDesc)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl3)
        Me.GroupGeneralHeader.Controls.Add(Me.TERange)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl4)
        Me.GroupGeneralHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupGeneralHeader.Location = New System.Drawing.Point(0, 0)
        Me.GroupGeneralHeader.Name = "GroupGeneralHeader"
        Me.GroupGeneralHeader.Size = New System.Drawing.Size(734, 72)
        Me.GroupGeneralHeader.TabIndex = 27
        '
        'TERangeDesc
        '
        Me.TERangeDesc.EditValue = ""
        Me.TERangeDesc.Location = New System.Drawing.Point(114, 37)
        Me.TERangeDesc.Name = "TERangeDesc"
        Me.TERangeDesc.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TERangeDesc.Properties.Appearance.Options.UseFont = True
        Me.TERangeDesc.Properties.DisplayFormat.FormatString = "dd MMM yyyy HH:mm:ss"
        Me.TERangeDesc.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TERangeDesc.Properties.EditValueChangedDelay = 1
        Me.TERangeDesc.Properties.ReadOnly = True
        Me.TERangeDesc.Size = New System.Drawing.Size(313, 20)
        Me.TERangeDesc.TabIndex = 179
        Me.TERangeDesc.TabStop = False
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(37, 40)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl3.TabIndex = 178
        Me.LabelControl3.Text = "Description"
        '
        'TERange
        '
        Me.TERange.EditValue = ""
        Me.TERange.Location = New System.Drawing.Point(114, 9)
        Me.TERange.Name = "TERange"
        Me.TERange.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TERange.Properties.Appearance.Options.UseFont = True
        Me.TERange.Properties.EditValueChangedDelay = 1
        Me.TERange.Properties.ReadOnly = True
        Me.TERange.Size = New System.Drawing.Size(313, 20)
        Me.TERange.TabIndex = 171
        Me.TERange.TabStop = False
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(37, 12)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl4.TabIndex = 170
        Me.LabelControl4.Text = "Periode"
        '
        'GCSelf
        '
        Me.GCSelf.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSelf.Location = New System.Drawing.Point(0, 108)
        Me.GCSelf.MainView = Me.GVSelf
        Me.GCSelf.Name = "GCSelf"
        Me.GCSelf.Size = New System.Drawing.Size(734, 245)
        Me.GCSelf.TabIndex = 29
        Me.GCSelf.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSelf})
        '
        'GVSelf
        '
        Me.GVSelf.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn13, Me.GridColumn3, Me.GridColumn4, Me.GridColumn9, Me.GridColumn10})
        Me.GVSelf.GridControl = Me.GCSelf
        Me.GVSelf.Name = "GVSelf"
        Me.GVSelf.OptionsBehavior.Editable = False
        Me.GVSelf.OptionsFind.AlwaysVisible = True
        Me.GVSelf.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID SOH on hand"
        Me.GridColumn1.FieldName = "id_soh_price"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.Caption = "No"
        Me.GridColumn2.FieldName = "no"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 49
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Class"
        Me.GridColumn13.FieldName = "prod_class"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 1
        Me.GridColumn13.Width = 73
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Style Code"
        Me.GridColumn3.FieldName = "style_code"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        Me.GridColumn3.Width = 84
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Description"
        Me.GridColumn4.FieldName = "prod_desc"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        Me.GridColumn4.Width = 142
        '
        'GridColumn9
        '
        Me.GridColumn9.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn9.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn9.Caption = "Price"
        Me.GridColumn9.FieldName = "prod_price"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 4
        '
        'GridColumn10
        '
        Me.GridColumn10.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn10.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn10.Caption = "Cost"
        Me.GridColumn10.FieldName = "prod_cost"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 5
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.BEmpty)
        Me.PanelControl1.Controls.Add(Me.BImport)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 72)
        Me.PanelControl1.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(734, 36)
        Me.PanelControl1.TabIndex = 28
        '
        'BEmpty
        '
        Me.BEmpty.Dock = System.Windows.Forms.DockStyle.Right
        Me.BEmpty.ImageIndex = 0
        Me.BEmpty.Location = New System.Drawing.Point(643, 0)
        Me.BEmpty.Name = "BEmpty"
        Me.BEmpty.Size = New System.Drawing.Size(91, 36)
        Me.BEmpty.TabIndex = 7
        Me.BEmpty.Text = "Clear all"
        '
        'BImport
        '
        Me.BImport.Dock = System.Windows.Forms.DockStyle.Left
        Me.BImport.ImageIndex = 0
        Me.BImport.Location = New System.Drawing.Point(0, 0)
        Me.BImport.Name = "BImport"
        Me.BImport.Size = New System.Drawing.Size(105, 36)
        Me.BImport.TabIndex = 6
        Me.BImport.Text = "Import Price List"
        '
        'FormSOHPriceDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 353)
        Me.Controls.Add(Me.GCSelf)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.GroupGeneralHeader)
        Me.MinimizeBox = False
        Me.Name = "FormSOHPriceDet"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Price List"
        CType(Me.GroupGeneralHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneralHeader.ResumeLayout(False)
        Me.GroupGeneralHeader.PerformLayout()
        CType(Me.TERangeDesc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TERange.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCSelf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSelf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupGeneralHeader As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TERangeDesc As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TERange As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCSelf As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSelf As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BEmpty As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BImport As DevExpress.XtraEditors.SimpleButton
End Class
