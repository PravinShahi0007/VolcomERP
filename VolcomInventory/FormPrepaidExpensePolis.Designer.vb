<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPrepaidExpensePolis
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
        Me.BImport = New DevExpress.XtraEditors.SimpleButton()
        Me.TEDesc = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.TEInvNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TEVendor = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEPPH3PLInv = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TEPPH3PLInv = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TEPPN3PLInv = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.SLECOABiaya = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.TEDesc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEInvNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEVendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEPPH3PLInv.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPPH3PLInv.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPPN3PLInv.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLECOABiaya.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BImport
        '
        Me.BImport.Appearance.BackColor = System.Drawing.Color.Blue
        Me.BImport.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BImport.Appearance.ForeColor = System.Drawing.Color.White
        Me.BImport.Appearance.Options.UseBackColor = True
        Me.BImport.Appearance.Options.UseFont = True
        Me.BImport.Appearance.Options.UseForeColor = True
        Me.BImport.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BImport.Location = New System.Drawing.Point(0, 195)
        Me.BImport.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.BImport.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BImport.Name = "BImport"
        Me.BImport.Size = New System.Drawing.Size(449, 34)
        Me.BImport.TabIndex = 93
        Me.BImport.Text = "Generate Prepaid Expense"
        '
        'TEDesc
        '
        Me.TEDesc.Location = New System.Drawing.Point(93, 165)
        Me.TEDesc.Name = "TEDesc"
        Me.TEDesc.Size = New System.Drawing.Size(259, 20)
        Me.TEDesc.TabIndex = 116
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(12, 168)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl6.TabIndex = 115
        Me.LabelControl6.Text = "Description"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(12, 38)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(75, 13)
        Me.LabelControl5.TabIndex = 114
        Me.LabelControl5.Text = "Invoice Number"
        '
        'TEInvNumber
        '
        Me.TEInvNumber.Location = New System.Drawing.Point(93, 35)
        Me.TEInvNumber.Name = "TEInvNumber"
        Me.TEInvNumber.Properties.ReadOnly = True
        Me.TEInvNumber.Size = New System.Drawing.Size(310, 20)
        Me.TEInvNumber.TabIndex = 113
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl4.TabIndex = 112
        Me.LabelControl4.Text = "Vendor"
        '
        'TEVendor
        '
        Me.TEVendor.Location = New System.Drawing.Point(93, 9)
        Me.TEVendor.Name = "TEVendor"
        Me.TEVendor.Properties.ReadOnly = True
        Me.TEVendor.Size = New System.Drawing.Size(338, 20)
        Me.TEVendor.TabIndex = 111
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 116)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl3.TabIndex = 110
        Me.LabelControl3.Text = "PPH Account"
        '
        'SLEPPH3PLInv
        '
        Me.SLEPPH3PLInv.Location = New System.Drawing.Point(93, 113)
        Me.SLEPPH3PLInv.Name = "SLEPPH3PLInv"
        Me.SLEPPH3PLInv.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEPPH3PLInv.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEPPH3PLInv.Size = New System.Drawing.Size(211, 20)
        Me.SLEPPH3PLInv.TabIndex = 109
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn4, Me.GridColumn5})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "id"
        Me.GridColumn3.FieldName = "id_acc"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "ACC"
        Me.GridColumn4.FieldName = "acc_name"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 0
        Me.GridColumn4.Width = 400
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Description"
        Me.GridColumn5.FieldName = "acc_description"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 1
        Me.GridColumn5.Width = 1216
        '
        'TEPPH3PLInv
        '
        Me.TEPPH3PLInv.Location = New System.Drawing.Point(93, 87)
        Me.TEPPH3PLInv.Name = "TEPPH3PLInv"
        Me.TEPPH3PLInv.Properties.Mask.EditMask = "N2"
        Me.TEPPH3PLInv.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEPPH3PLInv.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEPPH3PLInv.Size = New System.Drawing.Size(174, 20)
        Me.TEPPH3PLInv.TabIndex = 108
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 90)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl2.TabIndex = 107
        Me.LabelControl2.Text = "PPH (%)"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 64)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl1.TabIndex = 106
        Me.LabelControl1.Text = "PPN (%)"
        '
        'TEPPN3PLInv
        '
        Me.TEPPN3PLInv.Location = New System.Drawing.Point(93, 61)
        Me.TEPPN3PLInv.Name = "TEPPN3PLInv"
        Me.TEPPN3PLInv.Properties.Mask.EditMask = "N2"
        Me.TEPPN3PLInv.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEPPN3PLInv.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEPPN3PLInv.Size = New System.Drawing.Size(174, 20)
        Me.TEPPN3PLInv.TabIndex = 105
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(12, 142)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl7.TabIndex = 118
        Me.LabelControl7.Text = "Coa Biaya"
        '
        'SLECOABiaya
        '
        Me.SLECOABiaya.Location = New System.Drawing.Point(93, 139)
        Me.SLECOABiaya.Name = "SLECOABiaya"
        Me.SLECOABiaya.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLECOABiaya.Properties.View = Me.GridView1
        Me.SLECOABiaya.Size = New System.Drawing.Size(211, 20)
        Me.SLECOABiaya.TabIndex = 117
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn6})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "id"
        Me.GridColumn1.FieldName = "id_acc"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "ACC"
        Me.GridColumn2.FieldName = "acc_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 400
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Description"
        Me.GridColumn6.FieldName = "acc_description"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 1
        Me.GridColumn6.Width = 1216
        '
        'FormPrepaidExpensePolis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(449, 229)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.SLECOABiaya)
        Me.Controls.Add(Me.TEDesc)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.TEInvNumber)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.TEVendor)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.SLEPPH3PLInv)
        Me.Controls.Add(Me.TEPPH3PLInv)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.TEPPN3PLInv)
        Me.Controls.Add(Me.BImport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPrepaidExpensePolis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Polis to Prepaid Expense"
        CType(Me.TEDesc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEInvNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEVendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEPPH3PLInv.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPPH3PLInv.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPPN3PLInv.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLECOABiaya.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BImport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEDesc As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEInvNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEVendor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEPPH3PLInv As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TEPPH3PLInv As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEPPN3PLInv As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLECOABiaya As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
End Class
