<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPricePolicyCodeDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPricePolicyCodeDet))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.TxtDesc = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtCode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnCreate = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_code_detail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_disc_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndisc_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnage_min = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnage_max = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_design_price_policy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumntarget_sal_thru = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TxtDesc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.TxtDesc)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.TxtCode)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(584, 76)
        Me.PanelControl1.TabIndex = 0
        '
        'TxtDesc
        '
        Me.TxtDesc.EditValue = ""
        Me.TxtDesc.Location = New System.Drawing.Point(95, 40)
        Me.TxtDesc.Name = "TxtDesc"
        Me.TxtDesc.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDesc.Properties.Appearance.Options.UseFont = True
        Me.TxtDesc.Properties.MaxLength = 100
        Me.TxtDesc.Size = New System.Drawing.Size(476, 22)
        Me.TxtDesc.TabIndex = 3
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(19, 43)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(63, 16)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Description"
        '
        'TxtCode
        '
        Me.TxtCode.Location = New System.Drawing.Point(95, 12)
        Me.TxtCode.Name = "TxtCode"
        Me.TxtCode.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCode.Properties.Appearance.Options.UseFont = True
        Me.TxtCode.Size = New System.Drawing.Size(476, 22)
        Me.TxtCode.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(19, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(29, 16)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Code"
        '
        'BtnCreate
        '
        Me.BtnCreate.Appearance.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BtnCreate.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnCreate.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnCreate.Appearance.Options.UseBackColor = True
        Me.BtnCreate.Appearance.Options.UseFont = True
        Me.BtnCreate.Appearance.Options.UseForeColor = True
        Me.BtnCreate.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnCreate.Location = New System.Drawing.Point(0, 310)
        Me.BtnCreate.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnCreate.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BtnCreate.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnCreate.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.Size = New System.Drawing.Size(584, 24)
        Me.BtnCreate.TabIndex = 20
        Me.BtnCreate.Text = "Create New"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Top
        Me.GCData.Enabled = False
        Me.GCData.Location = New System.Drawing.Point(0, 119)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(584, 191)
        Me.GCData.TabIndex = 23
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_code_detail, Me.GridColumnid_disc_type, Me.GridColumndisc_type, Me.GridColumnage_min, Me.GridColumnage_max, Me.GridColumnid_design_price_policy, Me.GridColumntarget_sal_thru})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_code_detail
        '
        Me.GridColumnid_code_detail.Caption = "id_code_detail"
        Me.GridColumnid_code_detail.FieldName = "id_code_detail"
        Me.GridColumnid_code_detail.Name = "GridColumnid_code_detail"
        Me.GridColumnid_code_detail.OptionsColumn.ReadOnly = True
        '
        'GridColumnid_disc_type
        '
        Me.GridColumnid_disc_type.Caption = "id_disc_type"
        Me.GridColumnid_disc_type.FieldName = "id_disc_type"
        Me.GridColumnid_disc_type.Name = "GridColumnid_disc_type"
        Me.GridColumnid_disc_type.OptionsColumn.ReadOnly = True
        '
        'GridColumndisc_type
        '
        Me.GridColumndisc_type.Caption = "Discount Type"
        Me.GridColumndisc_type.FieldName = "disc_type"
        Me.GridColumndisc_type.Name = "GridColumndisc_type"
        Me.GridColumndisc_type.OptionsColumn.ReadOnly = True
        Me.GridColumndisc_type.Visible = True
        Me.GridColumndisc_type.VisibleIndex = 0
        '
        'GridColumnage_min
        '
        Me.GridColumnage_min.Caption = "Age Min"
        Me.GridColumnage_min.DisplayFormat.FormatString = "N0"
        Me.GridColumnage_min.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnage_min.FieldName = "age_min"
        Me.GridColumnage_min.Name = "GridColumnage_min"
        Me.GridColumnage_min.OptionsColumn.ReadOnly = True
        Me.GridColumnage_min.Visible = True
        Me.GridColumnage_min.VisibleIndex = 1
        '
        'GridColumnage_max
        '
        Me.GridColumnage_max.Caption = "Age Max"
        Me.GridColumnage_max.DisplayFormat.FormatString = "N0"
        Me.GridColumnage_max.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnage_max.FieldName = "age_max"
        Me.GridColumnage_max.Name = "GridColumnage_max"
        Me.GridColumnage_max.OptionsColumn.ReadOnly = True
        Me.GridColumnage_max.Visible = True
        Me.GridColumnage_max.VisibleIndex = 2
        '
        'GridColumnid_design_price_policy
        '
        Me.GridColumnid_design_price_policy.Caption = "id_design_price_policy"
        Me.GridColumnid_design_price_policy.FieldName = "id_design_price_policy"
        Me.GridColumnid_design_price_policy.Name = "GridColumnid_design_price_policy"
        Me.GridColumnid_design_price_policy.OptionsColumn.ReadOnly = True
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.BtnDelete)
        Me.PanelControl3.Controls.Add(Me.BtnAdd)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Enabled = False
        Me.PanelControl3.Location = New System.Drawing.Point(0, 76)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(584, 43)
        Me.PanelControl3.TabIndex = 24
        '
        'BtnDelete
        '
        Me.BtnDelete.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDelete.Image = CType(resources.GetObject("BtnDelete.Image"), System.Drawing.Image)
        Me.BtnDelete.Location = New System.Drawing.Point(429, 2)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(81, 39)
        Me.BtnDelete.TabIndex = 4
        Me.BtnDelete.Text = "Delete"
        '
        'BtnAdd
        '
        Me.BtnAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"), System.Drawing.Image)
        Me.BtnAdd.Location = New System.Drawing.Point(510, 2)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(72, 39)
        Me.BtnAdd.TabIndex = 3
        Me.BtnAdd.Text = "Add"
        '
        'GridColumntarget_sal_thru
        '
        Me.GridColumntarget_sal_thru.Caption = "Target Sal Thru"
        Me.GridColumntarget_sal_thru.DisplayFormat.FormatString = "{0:n2} %"
        Me.GridColumntarget_sal_thru.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.GridColumntarget_sal_thru.FieldName = "target_sal_thru"
        Me.GridColumntarget_sal_thru.Name = "GridColumntarget_sal_thru"
        Me.GridColumntarget_sal_thru.Visible = True
        Me.GridColumntarget_sal_thru.VisibleIndex = 3
        '
        'FormPricePolicyCodeDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 335)
        Me.Controls.Add(Me.BtnCreate)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPricePolicyCodeDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Setup Code"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.TxtDesc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtDesc As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnCreate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnid_code_detail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_disc_type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndisc_type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnage_min As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnage_max As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_design_price_policy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntarget_sal_thru As DevExpress.XtraGrid.Columns.GridColumn
End Class
