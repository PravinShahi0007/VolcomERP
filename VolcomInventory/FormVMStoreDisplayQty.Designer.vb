<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormVMStoreDisplayQty
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
        Me.BtnConfirm = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnDiscard = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEItem = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.SPQty = New DevExpress.XtraEditors.SpinEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEType = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.SLEItem.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SPQty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnConfirm
        '
        Me.BtnConfirm.Appearance.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BtnConfirm.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnConfirm.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnConfirm.Appearance.Options.UseBackColor = True
        Me.BtnConfirm.Appearance.Options.UseFont = True
        Me.BtnConfirm.Appearance.Options.UseForeColor = True
        Me.BtnConfirm.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnConfirm.Location = New System.Drawing.Point(0, 178)
        Me.BtnConfirm.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnConfirm.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BtnConfirm.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnConfirm.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnConfirm.Name = "BtnConfirm"
        Me.BtnConfirm.Size = New System.Drawing.Size(356, 26)
        Me.BtnConfirm.TabIndex = 19
        Me.BtnConfirm.Text = "Confirm"
        '
        'BtnDiscard
        '
        Me.BtnDiscard.Appearance.BackColor = System.Drawing.Color.Crimson
        Me.BtnDiscard.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnDiscard.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnDiscard.Appearance.Options.UseBackColor = True
        Me.BtnDiscard.Appearance.Options.UseFont = True
        Me.BtnDiscard.Appearance.Options.UseForeColor = True
        Me.BtnDiscard.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnDiscard.Location = New System.Drawing.Point(0, 204)
        Me.BtnDiscard.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnDiscard.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BtnDiscard.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnDiscard.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnDiscard.Name = "BtnDiscard"
        Me.BtnDiscard.Size = New System.Drawing.Size(356, 26)
        Me.BtnDiscard.TabIndex = 20
        Me.BtnDiscard.Text = "Discard"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(12, 60)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(28, 13)
        Me.LabelControl1.TabIndex = 21
        Me.LabelControl1.Text = "Item"
        '
        'SLEItem
        '
        Me.SLEItem.Location = New System.Drawing.Point(12, 79)
        Me.SLEItem.Name = "SLEItem"
        Me.SLEItem.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEItem.Properties.ShowClearButton = False
        Me.SLEItem.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEItem.Size = New System.Drawing.Size(328, 20)
        Me.SLEItem.TabIndex = 22
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(12, 111)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(20, 13)
        Me.LabelControl2.TabIndex = 23
        Me.LabelControl2.Text = "Qty"
        '
        'SPQty
        '
        Me.SPQty.EditValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.SPQty.Location = New System.Drawing.Point(12, 130)
        Me.SPQty.Name = "SPQty"
        Me.SPQty.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SPQty.Properties.DisplayFormat.FormatString = "N0"
        Me.SPQty.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.SPQty.Properties.Mask.EditMask = "N0"
        Me.SPQty.Properties.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.SPQty.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.SPQty.Size = New System.Drawing.Size(328, 20)
        Me.SPQty.TabIndex = 24
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(28, 13)
        Me.LabelControl5.TabIndex = 30
        Me.LabelControl5.Text = "Type"
        '
        'SLEType
        '
        Me.SLEType.Location = New System.Drawing.Point(12, 31)
        Me.SLEType.Name = "SLEType"
        Me.SLEType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEType.Properties.ShowClearButton = False
        Me.SLEType.Properties.View = Me.GridView1
        Me.SLEType.Size = New System.Drawing.Size(328, 20)
        Me.SLEType.TabIndex = 31
        '
        'GridView1
        '
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'FormVMStoreDisplayQty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(356, 230)
        Me.Controls.Add(Me.SLEType)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.SPQty)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.SLEItem)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.BtnConfirm)
        Me.Controls.Add(Me.BtnDiscard)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormVMStoreDisplayQty"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Item"
        CType(Me.SLEItem.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SPQty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnConfirm As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnDiscard As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEItem As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SPQty As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEType As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
