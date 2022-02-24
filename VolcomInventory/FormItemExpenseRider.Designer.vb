<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormItemExpenseRider
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
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.DEDateReff = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEBudget = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        CType(Me.DEDateReff.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDateReff.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEBudget.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEVendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEPPH3PLInv.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPPH3PLInv.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPPN3PLInv.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BImport.Location = New System.Drawing.Point(0, 171)
        Me.BImport.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.BImport.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BImport.Name = "BImport"
        Me.BImport.Size = New System.Drawing.Size(442, 34)
        Me.BImport.TabIndex = 93
        Me.BImport.Text = "Generate Expense"
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(13, 119)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(47, 13)
        Me.LabelControl8.TabIndex = 124
        Me.LabelControl8.Text = "Reff Date"
        '
        'DEDateReff
        '
        Me.DEDateReff.EditValue = Nothing
        Me.DEDateReff.Location = New System.Drawing.Point(94, 116)
        Me.DEDateReff.Name = "DEDateReff"
        Me.DEDateReff.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DEDateReff.Properties.Appearance.Options.UseFont = True
        Me.DEDateReff.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDateReff.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDateReff.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEDateReff.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEDateReff.Size = New System.Drawing.Size(174, 20)
        Me.DEDateReff.TabIndex = 123
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(13, 145)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl7.TabIndex = 122
        Me.LabelControl7.Text = "Budget"
        '
        'SLEBudget
        '
        Me.SLEBudget.Location = New System.Drawing.Point(94, 142)
        Me.SLEBudget.Name = "SLEBudget"
        Me.SLEBudget.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEBudget.Properties.View = Me.GridView1
        Me.SLEBudget.Size = New System.Drawing.Size(338, 20)
        Me.SLEBudget.TabIndex = 121
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "id_b_expense"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Expense"
        Me.GridColumn2.FieldName = "item_cat_main"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(13, 15)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl4.TabIndex = 116
        Me.LabelControl4.Text = "Endorsee"
        '
        'TEVendor
        '
        Me.TEVendor.Location = New System.Drawing.Point(94, 12)
        Me.TEVendor.Name = "TEVendor"
        Me.TEVendor.Properties.ReadOnly = True
        Me.TEVendor.Size = New System.Drawing.Size(338, 20)
        Me.TEVendor.TabIndex = 115
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(13, 93)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl3.TabIndex = 114
        Me.LabelControl3.Text = "PPH Account"
        '
        'SLEPPH3PLInv
        '
        Me.SLEPPH3PLInv.Location = New System.Drawing.Point(94, 90)
        Me.SLEPPH3PLInv.Name = "SLEPPH3PLInv"
        Me.SLEPPH3PLInv.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEPPH3PLInv.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEPPH3PLInv.Size = New System.Drawing.Size(211, 20)
        Me.SLEPPH3PLInv.TabIndex = 113
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
        Me.TEPPH3PLInv.Location = New System.Drawing.Point(94, 64)
        Me.TEPPH3PLInv.Name = "TEPPH3PLInv"
        Me.TEPPH3PLInv.Properties.Mask.EditMask = "N2"
        Me.TEPPH3PLInv.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEPPH3PLInv.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEPPH3PLInv.Size = New System.Drawing.Size(265, 20)
        Me.TEPPH3PLInv.TabIndex = 112
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(13, 67)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl2.TabIndex = 111
        Me.LabelControl2.Text = "PPH (%)"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(13, 41)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl1.TabIndex = 110
        Me.LabelControl1.Text = "PPN (%)"
        '
        'TEPPN3PLInv
        '
        Me.TEPPN3PLInv.Location = New System.Drawing.Point(94, 38)
        Me.TEPPN3PLInv.Name = "TEPPN3PLInv"
        Me.TEPPN3PLInv.Properties.Mask.EditMask = "N2"
        Me.TEPPN3PLInv.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEPPN3PLInv.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEPPN3PLInv.Size = New System.Drawing.Size(336, 20)
        Me.TEPPN3PLInv.TabIndex = 109
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(365, 66)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(65, 17)
        Me.CheckBox1.TabIndex = 125
        Me.CheckBox1.Text = "Grossup"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'FormItemExpenseRider
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(442, 205)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.DEDateReff)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.SLEBudget)
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
        Me.Name = "FormItemExpenseRider"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Item Expense Endorsee"
        CType(Me.DEDateReff.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDateReff.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEBudget.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEVendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEPPH3PLInv.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPPH3PLInv.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPPN3PLInv.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BImport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEDateReff As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEBudget As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
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
    Friend WithEvents CheckBox1 As CheckBox
End Class
