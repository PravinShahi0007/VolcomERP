<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPolisRegPop
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SLEPenawaran = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn40 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn41 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn42 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TEPremi = New DevExpress.XtraEditors.TextEdit()
        Me.TEStore = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BSubmit = New DevExpress.XtraEditors.SimpleButton()
        Me.TENomorPolis = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEPenawaran.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPremi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEStore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TENomorPolis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.TENomorPolis)
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Controls.Add(Me.SLEPenawaran)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.TEPremi)
        Me.PanelControl1.Controls.Add(Me.TEStore)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(546, 121)
        Me.PanelControl1.TabIndex = 8
        '
        'SLEPenawaran
        '
        Me.SLEPenawaran.EditValue = ""
        Me.SLEPenawaran.Location = New System.Drawing.Point(103, 64)
        Me.SLEPenawaran.Name = "SLEPenawaran"
        Me.SLEPenawaran.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEPenawaran.Properties.NullText = ""
        Me.SLEPenawaran.Properties.View = Me.GridView1
        Me.SLEPenawaran.Size = New System.Drawing.Size(321, 20)
        Me.SLEPenawaran.TabIndex = 5
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn40, Me.GridColumn41, Me.GridColumn42})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn40
        '
        Me.GridColumn40.Caption = "ID"
        Me.GridColumn40.FieldName = "id_comp"
        Me.GridColumn40.Name = "GridColumn40"
        '
        'GridColumn41
        '
        Me.GridColumn41.Caption = "Kode"
        Me.GridColumn41.FieldName = "comp_number"
        Me.GridColumn41.Name = "GridColumn41"
        Me.GridColumn41.Visible = True
        Me.GridColumn41.VisibleIndex = 0
        '
        'GridColumn42
        '
        Me.GridColumn42.Caption = "Vendor"
        Me.GridColumn42.FieldName = "comp_name"
        Me.GridColumn42.Name = "GridColumn42"
        Me.GridColumn42.Visible = True
        Me.GridColumn42.VisibleIndex = 1
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(15, 67)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl3.TabIndex = 4
        Me.LabelControl3.Text = "Vendor"
        '
        'TEPremi
        '
        Me.TEPremi.Location = New System.Drawing.Point(103, 90)
        Me.TEPremi.Name = "TEPremi"
        Me.TEPremi.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.TEPremi.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEPremi.Properties.Mask.EditMask = "N2"
        Me.TEPremi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEPremi.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEPremi.Size = New System.Drawing.Size(231, 20)
        Me.TEPremi.TabIndex = 3
        '
        'TEStore
        '
        Me.TEStore.Location = New System.Drawing.Point(103, 12)
        Me.TEStore.Name = "TEStore"
        Me.TEStore.Properties.ReadOnly = True
        Me.TEStore.Size = New System.Drawing.Size(361, 20)
        Me.TEStore.TabIndex = 2
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(15, 93)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "Premi"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(15, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Store"
        '
        'BSubmit
        '
        Me.BSubmit.Appearance.BackColor = System.Drawing.Color.DarkBlue
        Me.BSubmit.Appearance.ForeColor = System.Drawing.Color.White
        Me.BSubmit.Appearance.Options.UseBackColor = True
        Me.BSubmit.Appearance.Options.UseForeColor = True
        Me.BSubmit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.BSubmit.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BSubmit.Location = New System.Drawing.Point(0, 121)
        Me.BSubmit.Name = "BSubmit"
        Me.BSubmit.Size = New System.Drawing.Size(546, 40)
        Me.BSubmit.TabIndex = 9
        Me.BSubmit.Text = "Submit"
        '
        'TENomorPolis
        '
        Me.TENomorPolis.Location = New System.Drawing.Point(103, 38)
        Me.TENomorPolis.Name = "TENomorPolis"
        Me.TENomorPolis.Properties.ReadOnly = True
        Me.TENomorPolis.Size = New System.Drawing.Size(361, 20)
        Me.TENomorPolis.TabIndex = 7
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(15, 41)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(55, 13)
        Me.LabelControl4.TabIndex = 6
        Me.LabelControl4.Text = "Nomor Polis"
        '
        'FormPolisRegPop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(546, 161)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.BSubmit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPolisRegPop"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Polis Register"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLEPenawaran.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPremi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEStore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TENomorPolis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEPremi As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEStore As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BSubmit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLEPenawaran As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn40 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn41 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn42 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TENomorPolis As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
End Class
