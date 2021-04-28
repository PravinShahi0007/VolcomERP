<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProposePriceMKDSingle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProposePriceMKDSingle))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnDiscard = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnConfirm = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtCode = New DevExpress.XtraEditors.TextEdit()
        Me.TxtDescription = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtRekomendasiDisc = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtProposePrice = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtProposeFinal = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEProposeDisc = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtCurrDisc = New DevExpress.XtraEditors.TextEdit()
        Me.TxtCurrPrice = New DevExpress.XtraEditors.TextEdit()
        Me.CENoPropose = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TxtCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtRekomendasiDisc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtProposePrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtProposeFinal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEProposeDisc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCurrDisc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCurrPrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CENoPropose.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnDiscard)
        Me.PanelControl1.Controls.Add(Me.BtnConfirm)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 245)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(521, 43)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnDiscard
        '
        Me.BtnDiscard.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDiscard.Image = CType(resources.GetObject("BtnDiscard.Image"), System.Drawing.Image)
        Me.BtnDiscard.Location = New System.Drawing.Point(337, 2)
        Me.BtnDiscard.LookAndFeel.SkinMaskColor = System.Drawing.Color.Red
        Me.BtnDiscard.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnDiscard.Name = "BtnDiscard"
        Me.BtnDiscard.Size = New System.Drawing.Size(91, 39)
        Me.BtnDiscard.TabIndex = 1
        Me.BtnDiscard.Text = "Discard"
        '
        'BtnConfirm
        '
        Me.BtnConfirm.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnConfirm.Image = CType(resources.GetObject("BtnConfirm.Image"), System.Drawing.Image)
        Me.BtnConfirm.Location = New System.Drawing.Point(428, 2)
        Me.BtnConfirm.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnConfirm.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnConfirm.Name = "BtnConfirm"
        Me.BtnConfirm.Size = New System.Drawing.Size(91, 39)
        Me.BtnConfirm.TabIndex = 0
        Me.BtnConfirm.Text = "Confirm"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(18, 19)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(67, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Product Desc."
        '
        'TxtCode
        '
        Me.TxtCode.EditValue = ""
        Me.TxtCode.Enabled = False
        Me.TxtCode.Location = New System.Drawing.Point(121, 16)
        Me.TxtCode.Name = "TxtCode"
        Me.TxtCode.Size = New System.Drawing.Size(79, 20)
        Me.TxtCode.TabIndex = 2
        '
        'TxtDescription
        '
        Me.TxtDescription.EditValue = ""
        Me.TxtDescription.Enabled = False
        Me.TxtDescription.Location = New System.Drawing.Point(203, 16)
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(289, 20)
        Me.TxtDescription.TabIndex = 3
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(18, 71)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(89, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Rekomendasi Disc."
        '
        'TxtRekomendasiDisc
        '
        Me.TxtRekomendasiDisc.Enabled = False
        Me.TxtRekomendasiDisc.Location = New System.Drawing.Point(121, 68)
        Me.TxtRekomendasiDisc.Name = "TxtRekomendasiDisc"
        Me.TxtRekomendasiDisc.Properties.DisplayFormat.FormatString = "{0:n0}%"
        Me.TxtRekomendasiDisc.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtRekomendasiDisc.Size = New System.Drawing.Size(371, 20)
        Me.TxtRekomendasiDisc.TabIndex = 5
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(18, 97)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl3.TabIndex = 7
        Me.LabelControl3.Text = "Propose Disc."
        '
        'TxtProposePrice
        '
        Me.TxtProposePrice.Enabled = False
        Me.TxtProposePrice.Location = New System.Drawing.Point(121, 120)
        Me.TxtProposePrice.Name = "TxtProposePrice"
        Me.TxtProposePrice.Properties.DisplayFormat.FormatString = "N0"
        Me.TxtProposePrice.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtProposePrice.Size = New System.Drawing.Size(371, 20)
        Me.TxtProposePrice.TabIndex = 8
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(18, 123)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl4.TabIndex = 9
        Me.LabelControl4.Text = "Propose Price"
        '
        'TxtProposeFinal
        '
        Me.TxtProposeFinal.Location = New System.Drawing.Point(121, 146)
        Me.TxtProposeFinal.Name = "TxtProposeFinal"
        Me.TxtProposeFinal.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProposeFinal.Properties.Appearance.Options.UseFont = True
        Me.TxtProposeFinal.Properties.DisplayFormat.FormatString = "N0"
        Me.TxtProposeFinal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtProposeFinal.Size = New System.Drawing.Size(371, 20)
        Me.TxtProposeFinal.TabIndex = 10
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(18, 149)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(75, 13)
        Me.LabelControl5.TabIndex = 11
        Me.LabelControl5.Text = "Propose Final"
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(121, 172)
        Me.MENote.Name = "MENote"
        Me.MENote.Properties.MaxLength = 100
        Me.MENote.Size = New System.Drawing.Size(371, 43)
        Me.MENote.TabIndex = 12
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(18, 174)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl6.TabIndex = 13
        Me.LabelControl6.Text = "Note"
        '
        'SLEProposeDisc
        '
        Me.SLEProposeDisc.Location = New System.Drawing.Point(121, 94)
        Me.SLEProposeDisc.Name = "SLEProposeDisc"
        Me.SLEProposeDisc.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEProposeDisc.Properties.NullText = ""
        Me.SLEProposeDisc.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEProposeDisc.Size = New System.Drawing.Size(290, 20)
        Me.SLEProposeDisc.TabIndex = 14
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(18, 45)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl7.TabIndex = 15
        Me.LabelControl7.Text = "Current Price"
        '
        'TxtCurrDisc
        '
        Me.TxtCurrDisc.EditValue = ""
        Me.TxtCurrDisc.Enabled = False
        Me.TxtCurrDisc.Location = New System.Drawing.Point(121, 42)
        Me.TxtCurrDisc.Name = "TxtCurrDisc"
        Me.TxtCurrDisc.Properties.DisplayFormat.FormatString = "{0:n0}%"
        Me.TxtCurrDisc.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtCurrDisc.Size = New System.Drawing.Size(79, 20)
        Me.TxtCurrDisc.TabIndex = 16
        '
        'TxtCurrPrice
        '
        Me.TxtCurrPrice.EditValue = ""
        Me.TxtCurrPrice.Enabled = False
        Me.TxtCurrPrice.Location = New System.Drawing.Point(203, 42)
        Me.TxtCurrPrice.Name = "TxtCurrPrice"
        Me.TxtCurrPrice.Properties.DisplayFormat.FormatString = "{0:n0}"
        Me.TxtCurrPrice.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtCurrPrice.Size = New System.Drawing.Size(289, 20)
        Me.TxtCurrPrice.TabIndex = 17
        '
        'CENoPropose
        '
        Me.CENoPropose.Location = New System.Drawing.Point(417, 94)
        Me.CENoPropose.Name = "CENoPropose"
        Me.CENoPropose.Properties.Caption = "No Propose"
        Me.CENoPropose.Size = New System.Drawing.Size(75, 19)
        Me.CENoPropose.TabIndex = 18
        '
        'FormProposePriceMKDSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(521, 288)
        Me.Controls.Add(Me.CENoPropose)
        Me.Controls.Add(Me.TxtCurrPrice)
        Me.Controls.Add(Me.TxtCurrDisc)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.SLEProposeDisc)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.MENote)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.TxtProposeFinal)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.TxtProposePrice)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.TxtRekomendasiDisc)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.TxtDescription)
        Me.Controls.Add(Me.TxtCode)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProposePriceMKDSingle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Propose Detail"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.TxtCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtRekomendasiDisc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtProposePrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtProposeFinal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEProposeDisc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCurrDisc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCurrPrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CENoPropose.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnDiscard As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnConfirm As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtDescription As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtRekomendasiDisc As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtProposePrice As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtProposeFinal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEProposeDisc As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtCurrDisc As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtCurrPrice As DevExpress.XtraEditors.TextEdit
    Friend WithEvents CENoPropose As DevExpress.XtraEditors.CheckEdit
End Class
