<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDisplayAllocDet
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
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtClassGroup = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEDisplayType = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtCapacity = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtQty = New DevExpress.XtraEditors.TextEdit()
        Me.BtnConfirm = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.TxtClassGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEDisplayType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCapacity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtQty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(17, 16)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(57, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Class Group"
        '
        'TxtClassGroup
        '
        Me.TxtClassGroup.Enabled = False
        Me.TxtClassGroup.Location = New System.Drawing.Point(17, 35)
        Me.TxtClassGroup.Name = "TxtClassGroup"
        Me.TxtClassGroup.Size = New System.Drawing.Size(374, 20)
        Me.TxtClassGroup.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(17, 67)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Display Type"
        '
        'SLEDisplayType
        '
        Me.SLEDisplayType.Location = New System.Drawing.Point(17, 86)
        Me.SLEDisplayType.Name = "SLEDisplayType"
        Me.SLEDisplayType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEDisplayType.Properties.NullText = "- Select Display Type -"
        Me.SLEDisplayType.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEDisplayType.Size = New System.Drawing.Size(374, 20)
        Me.SLEDisplayType.TabIndex = 3
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(17, 121)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(42, 13)
        Me.LabelControl3.TabIndex = 4
        Me.LabelControl3.Text = "Capacity"
        '
        'TxtCapacity
        '
        Me.TxtCapacity.Location = New System.Drawing.Point(17, 140)
        Me.TxtCapacity.Name = "TxtCapacity"
        Me.TxtCapacity.Properties.DisplayFormat.FormatString = "N2"
        Me.TxtCapacity.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtCapacity.Properties.Mask.EditMask = "N2"
        Me.TxtCapacity.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtCapacity.Size = New System.Drawing.Size(374, 20)
        Me.TxtCapacity.TabIndex = 5
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(17, 175)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(81, 13)
        Me.LabelControl4.TabIndex = 6
        Me.LabelControl4.Text = "Qty Size Per SKU"
        '
        'TxtQty
        '
        Me.TxtQty.Location = New System.Drawing.Point(17, 194)
        Me.TxtQty.Name = "TxtQty"
        Me.TxtQty.Properties.DisplayFormat.FormatString = "N0"
        Me.TxtQty.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtQty.Properties.Mask.EditMask = "N0"
        Me.TxtQty.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtQty.Size = New System.Drawing.Size(374, 20)
        Me.TxtQty.TabIndex = 7
        '
        'BtnConfirm
        '
        Me.BtnConfirm.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConfirm.Appearance.Options.UseFont = True
        Me.BtnConfirm.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnConfirm.Location = New System.Drawing.Point(0, 241)
        Me.BtnConfirm.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnConfirm.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnConfirm.Name = "BtnConfirm"
        Me.BtnConfirm.Size = New System.Drawing.Size(415, 26)
        Me.BtnConfirm.TabIndex = 8
        Me.BtnConfirm.Text = "Confirm"
        '
        'FormDisplayAllocDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 267)
        Me.Controls.Add(Me.BtnConfirm)
        Me.Controls.Add(Me.TxtQty)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.TxtCapacity)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.SLEDisplayType)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.TxtClassGroup)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.LookAndFeel.SkinName = "DevExpress Dark Style"
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormDisplayAllocDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Display Capacity Detail"
        CType(Me.TxtClassGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEDisplayType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCapacity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtQty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtClassGroup As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEDisplayType As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtCapacity As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtQty As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BtnConfirm As DevExpress.XtraEditors.SimpleButton
End Class
