<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAccountingMappingListDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAccountingMappingListDet))
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl
        Me.LEpayment = New DevExpress.XtraEditors.LookUpEdit
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.TECoaNumber = New DevExpress.XtraEditors.TextEdit
        Me.BPickDesign = New DevExpress.XtraEditors.SimpleButton
        Me.MEDesc = New DevExpress.XtraEditors.MemoEdit
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.BSave = New DevExpress.XtraEditors.SimpleButton
        Me.ImgBut = New DevExpress.Utils.ImageCollection(Me.components)
        Me.GCValueMap = New DevExpress.XtraGrid.GridControl
        Me.GVValueMap = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.LEpayment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECoaNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEDesc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.ImgBut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCValueMap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVValueMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.LEpayment)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Controls.Add(Me.LabelControl3)
        Me.PanelControl2.Controls.Add(Me.TECoaNumber)
        Me.PanelControl2.Controls.Add(Me.BPickDesign)
        Me.PanelControl2.Controls.Add(Me.MEDesc)
        Me.PanelControl2.Controls.Add(Me.LabelControl18)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(783, 128)
        Me.PanelControl2.TabIndex = 1
        '
        'LEpayment
        '
        Me.LEpayment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LEpayment.Location = New System.Drawing.Point(411, 30)
        Me.LEpayment.Name = "LEpayment"
        Me.LEpayment.Properties.Appearance.Options.UseTextOptions = True
        Me.LEpayment.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEpayment.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LEpayment.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.LEpayment.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.LEpayment.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.LEpayment.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEpayment.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_dc", "Id DC", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("dc", "Trans Type")})
        Me.LEpayment.Properties.NullText = ""
        Me.LEpayment.Properties.ShowFooter = False
        Me.LEpayment.Size = New System.Drawing.Size(360, 20)
        Me.LEpayment.TabIndex = 145
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(411, 9)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(64, 13)
        Me.LabelControl1.TabIndex = 143
        Me.LabelControl1.Text = "Debit / Credit"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 9)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl3.TabIndex = 88
        Me.LabelControl3.Text = "Account"
        '
        'TECoaNumber
        '
        Me.TECoaNumber.EditValue = ""
        Me.TECoaNumber.Location = New System.Drawing.Point(12, 28)
        Me.TECoaNumber.Name = "TECoaNumber"
        Me.TECoaNumber.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.TECoaNumber.Properties.Appearance.Options.UseFont = True
        Me.TECoaNumber.Properties.EditValueChangedDelay = 1
        Me.TECoaNumber.Properties.ReadOnly = True
        Me.TECoaNumber.Size = New System.Drawing.Size(325, 23)
        Me.TECoaNumber.TabIndex = 87
        '
        'BPickDesign
        '
        Me.BPickDesign.Location = New System.Drawing.Point(343, 27)
        Me.BPickDesign.Name = "BPickDesign"
        Me.BPickDesign.Size = New System.Drawing.Size(31, 23)
        Me.BPickDesign.TabIndex = 141
        Me.BPickDesign.Text = "..."
        '
        'MEDesc
        '
        Me.MEDesc.Location = New System.Drawing.Point(12, 76)
        Me.MEDesc.Name = "MEDesc"
        Me.MEDesc.Properties.MaxLength = 100
        Me.MEDesc.Size = New System.Drawing.Size(759, 41)
        Me.MEDesc.TabIndex = 139
        '
        'LabelControl18
        '
        Me.LabelControl18.Location = New System.Drawing.Point(12, 57)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl18.TabIndex = 140
        Me.LabelControl18.Text = "Description"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Controls.Add(Me.BSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 334)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(783, 34)
        Me.PanelControl1.TabIndex = 142
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.ImageIndex = 7
        Me.BSave.ImageList = Me.ImgBut
        Me.BSave.Location = New System.Drawing.Point(690, 2)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(91, 30)
        Me.BSave.TabIndex = 5
        Me.BSave.Text = "Save"
        '
        'ImgBut
        '
        Me.ImgBut.ImageSize = New System.Drawing.Size(24, 24)
        Me.ImgBut.ImageStream = CType(resources.GetObject("ImgBut.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImgBut.Images.SetKeyName(0, "20_24x24.png")
        Me.ImgBut.Images.SetKeyName(1, "8_24x24.png")
        Me.ImgBut.Images.SetKeyName(2, "23_24x24.png")
        Me.ImgBut.Images.SetKeyName(3, "arrow_refresh.png")
        Me.ImgBut.Images.SetKeyName(4, "check_mark.png")
        Me.ImgBut.Images.SetKeyName(5, "gnome_application_exit (1).png")
        Me.ImgBut.Images.SetKeyName(6, "printer_3.png")
        Me.ImgBut.Images.SetKeyName(7, "save.png")
        Me.ImgBut.Images.SetKeyName(8, "31_24x24.png")
        Me.ImgBut.Images.SetKeyName(9, "18_24x24.png")
        Me.ImgBut.Images.SetKeyName(10, "attachment-icon.png")
        Me.ImgBut.Images.SetKeyName(11, "document_32.png")
        '
        'GCValueMap
        '
        Me.GCValueMap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCValueMap.Location = New System.Drawing.Point(0, 128)
        Me.GCValueMap.MainView = Me.GVValueMap
        Me.GCValueMap.Name = "GCValueMap"
        Me.GCValueMap.Size = New System.Drawing.Size(783, 206)
        Me.GCValueMap.TabIndex = 143
        Me.GCValueMap.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVValueMap})
        '
        'GVValueMap
        '
        Me.GVValueMap.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn1, Me.GridColumn4, Me.GridColumn2})
        Me.GVValueMap.GridControl = Me.GCValueMap
        Me.GVValueMap.Name = "GVValueMap"
        Me.GVValueMap.OptionsBehavior.ReadOnly = True
        Me.GVValueMap.OptionsView.ShowGroupPanel = False
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Id Coa Mapping Det"
        Me.GridColumn3.FieldName = "id_coa_mapping_det"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Get Value From"
        Me.GridColumn1.FieldName = "field"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 1
        Me.GridColumn1.Width = 494
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Get Valas Value From"
        Me.GridColumn4.FieldName = "field_valas"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        Me.GridColumn4.Width = 512
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.Caption = "Operator"
        Me.GridColumn2.FieldName = "operation"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 174
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.ImageIndex = 5
        Me.BtnCancel.ImageList = Me.ImgBut
        Me.BtnCancel.Location = New System.Drawing.Point(603, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(87, 30)
        Me.BtnCancel.TabIndex = 16
        Me.BtnCancel.Text = "Cancel"
        '
        'FormAccountingMappingListDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(783, 368)
        Me.Controls.Add(Me.GCValueMap)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAccountingMappingListDet"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detail Mapping"
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.LEpayment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECoaNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEDesc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.ImgBut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCValueMap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVValueMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TECoaNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MEDesc As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents BPickDesign As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCValueMap As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVValueMap As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Public WithEvents ImgBut As DevExpress.Utils.ImageCollection
    Friend WithEvents LEpayment As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
End Class
