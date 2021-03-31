<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPayoutZaloraComm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPayoutZaloraComm))
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnDiscard = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnConfirm = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtComm = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtCommTax = New DevExpress.XtraEditors.TextEdit()
        Me.TxtTotalCommInput = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtLinkComm = New DevExpress.XtraEditors.HyperLinkEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtCommReff = New DevExpress.XtraEditors.TextEdit()
        Me.TxtOtherExpense = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_zalora_comm_addition = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_payout_zalora = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_zalora_comm_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnzalora_comm_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_acc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnacc_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnacc_description = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnvalue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnote = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TxtComm.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCommTax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTotalCommInput.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtLinkComm.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCommReff.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtOtherExpense.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnDiscard)
        Me.PanelControl1.Controls.Add(Me.BtnConfirm)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 467)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(513, 44)
        Me.PanelControl1.TabIndex = 1
        '
        'BtnDiscard
        '
        Me.BtnDiscard.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDiscard.Image = CType(resources.GetObject("BtnDiscard.Image"), System.Drawing.Image)
        Me.BtnDiscard.Location = New System.Drawing.Point(339, 2)
        Me.BtnDiscard.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnDiscard.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnDiscard.Name = "BtnDiscard"
        Me.BtnDiscard.Size = New System.Drawing.Size(86, 40)
        Me.BtnDiscard.TabIndex = 1
        Me.BtnDiscard.Text = "Discard"
        '
        'BtnConfirm
        '
        Me.BtnConfirm.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnConfirm.Image = CType(resources.GetObject("BtnConfirm.Image"), System.Drawing.Image)
        Me.BtnConfirm.Location = New System.Drawing.Point(425, 2)
        Me.BtnConfirm.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnConfirm.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnConfirm.Name = "BtnConfirm"
        Me.BtnConfirm.Size = New System.Drawing.Size(86, 40)
        Me.BtnConfirm.TabIndex = 0
        Me.BtnConfirm.Text = "Confirm"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(12, 21)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(108, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Verified Commision"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(14, 362)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Commision"
        '
        'TxtComm
        '
        Me.TxtComm.Location = New System.Drawing.Point(126, 359)
        Me.TxtComm.Name = "TxtComm"
        Me.TxtComm.Properties.DisplayFormat.FormatString = "N2"
        Me.TxtComm.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtComm.Properties.Mask.EditMask = "N2"
        Me.TxtComm.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtComm.Size = New System.Drawing.Size(371, 20)
        Me.TxtComm.TabIndex = 5
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(14, 388)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(84, 13)
        Me.LabelControl3.TabIndex = 7
        Me.LabelControl3.Text = "Tax of Commision"
        '
        'TxtCommTax
        '
        Me.TxtCommTax.Location = New System.Drawing.Point(126, 385)
        Me.TxtCommTax.Name = "TxtCommTax"
        Me.TxtCommTax.Properties.DisplayFormat.FormatString = "N2"
        Me.TxtCommTax.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtCommTax.Properties.Mask.EditMask = "N2"
        Me.TxtCommTax.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtCommTax.Size = New System.Drawing.Size(371, 20)
        Me.TxtCommTax.TabIndex = 8
        '
        'TxtTotalCommInput
        '
        Me.TxtTotalCommInput.Enabled = False
        Me.TxtTotalCommInput.Location = New System.Drawing.Point(126, 14)
        Me.TxtTotalCommInput.Name = "TxtTotalCommInput"
        Me.TxtTotalCommInput.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalCommInput.Properties.Appearance.Options.UseFont = True
        Me.TxtTotalCommInput.Properties.DisplayFormat.FormatString = "N2"
        Me.TxtTotalCommInput.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtTotalCommInput.Properties.Mask.EditMask = "N2"
        Me.TxtTotalCommInput.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtTotalCommInput.Size = New System.Drawing.Size(357, 20)
        Me.TxtTotalCommInput.TabIndex = 9
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(12, 17)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(94, 13)
        Me.LabelControl4.TabIndex = 10
        Me.LabelControl4.Text = "Total Commision"
        '
        'TxtLinkComm
        '
        Me.TxtLinkComm.Location = New System.Drawing.Point(126, 18)
        Me.TxtLinkComm.Name = "TxtLinkComm"
        Me.TxtLinkComm.Properties.DisplayFormat.FormatString = "N2"
        Me.TxtLinkComm.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtLinkComm.Properties.ReadOnly = True
        Me.TxtLinkComm.Size = New System.Drawing.Size(371, 20)
        Me.TxtLinkComm.TabIndex = 11
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(12, 70)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(93, 13)
        Me.LabelControl5.TabIndex = 12
        Me.LabelControl5.Text = "Total Pelunasan AR"
        '
        'TxtCommReff
        '
        Me.TxtCommReff.Enabled = False
        Me.TxtCommReff.Location = New System.Drawing.Point(126, 67)
        Me.TxtCommReff.Name = "TxtCommReff"
        Me.TxtCommReff.Properties.DisplayFormat.FormatString = "N2"
        Me.TxtCommReff.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtCommReff.Properties.Mask.EditMask = "N2"
        Me.TxtCommReff.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtCommReff.Size = New System.Drawing.Size(371, 20)
        Me.TxtCommReff.TabIndex = 13
        '
        'TxtOtherExpense
        '
        Me.TxtOtherExpense.Enabled = False
        Me.TxtOtherExpense.Location = New System.Drawing.Point(126, 93)
        Me.TxtOtherExpense.Name = "TxtOtherExpense"
        Me.TxtOtherExpense.Properties.DisplayFormat.FormatString = "N2"
        Me.TxtOtherExpense.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtOtherExpense.Properties.Mask.EditMask = "N2"
        Me.TxtOtherExpense.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtOtherExpense.Size = New System.Drawing.Size(371, 20)
        Me.TxtOtherExpense.TabIndex = 14
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(12, 96)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(99, 13)
        Me.LabelControl6.TabIndex = 15
        Me.LabelControl6.Text = "Other Expense Total"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Controls.Add(Me.TxtLinkComm)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(513, 57)
        Me.PanelControl2.TabIndex = 17
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.LabelControl4)
        Me.PanelControl3.Controls.Add(Me.TxtTotalCommInput)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 420)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(513, 47)
        Me.PanelControl3.TabIndex = 18
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.GCData)
        Me.GroupControl1.Controls.Add(Me.PanelControl4)
        Me.GroupControl1.Location = New System.Drawing.Point(12, 127)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(485, 222)
        Me.GroupControl1.TabIndex = 22
        Me.GroupControl1.Text = "Additional Setup"
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.BtnDelete)
        Me.PanelControl4.Controls.Add(Me.BtnAdd)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl4.Location = New System.Drawing.Point(20, 2)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(463, 38)
        Me.PanelControl4.TabIndex = 0
        '
        'BtnDelete
        '
        Me.BtnDelete.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDelete.Image = CType(resources.GetObject("BtnDelete.Image"), System.Drawing.Image)
        Me.BtnDelete.Location = New System.Drawing.Point(311, 2)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(75, 34)
        Me.BtnDelete.TabIndex = 23
        Me.BtnDelete.Text = "Delete"
        '
        'BtnAdd
        '
        Me.BtnAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"), System.Drawing.Image)
        Me.BtnAdd.Location = New System.Drawing.Point(386, 2)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(75, 34)
        Me.BtnAdd.TabIndex = 22
        Me.BtnAdd.Text = "Add"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(20, 40)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(463, 180)
        Me.GCData.TabIndex = 20
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_zalora_comm_addition, Me.GridColumnid_payout_zalora, Me.GridColumnid_zalora_comm_type, Me.GridColumnzalora_comm_type, Me.GridColumnid_acc, Me.GridColumnacc_name, Me.GridColumnacc_description, Me.GridColumnvalue, Me.GridColumnnote})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.GroupCount = 1
        Me.GVData.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "value", Me.GridColumnvalue, "{0:N2}")})
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        Me.GVData.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnzalora_comm_type, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnid_zalora_comm_addition
        '
        Me.GridColumnid_zalora_comm_addition.Caption = "id_zalora_comm_addition"
        Me.GridColumnid_zalora_comm_addition.FieldName = "id_zalora_comm_addition"
        Me.GridColumnid_zalora_comm_addition.Name = "GridColumnid_zalora_comm_addition"
        '
        'GridColumnid_payout_zalora
        '
        Me.GridColumnid_payout_zalora.Caption = "id_payout_zalora"
        Me.GridColumnid_payout_zalora.FieldName = "id_payout_zalora"
        Me.GridColumnid_payout_zalora.Name = "GridColumnid_payout_zalora"
        '
        'GridColumnid_zalora_comm_type
        '
        Me.GridColumnid_zalora_comm_type.Caption = "id_zalora_comm_type"
        Me.GridColumnid_zalora_comm_type.FieldName = "id_zalora_comm_type"
        Me.GridColumnid_zalora_comm_type.Name = "GridColumnid_zalora_comm_type"
        '
        'GridColumnzalora_comm_type
        '
        Me.GridColumnzalora_comm_type.Caption = "Type"
        Me.GridColumnzalora_comm_type.FieldName = "zalora_comm_type"
        Me.GridColumnzalora_comm_type.Name = "GridColumnzalora_comm_type"
        Me.GridColumnzalora_comm_type.Visible = True
        Me.GridColumnzalora_comm_type.VisibleIndex = 0
        '
        'GridColumnid_acc
        '
        Me.GridColumnid_acc.Caption = "id_acc"
        Me.GridColumnid_acc.FieldName = "id_acc"
        Me.GridColumnid_acc.Name = "GridColumnid_acc"
        '
        'GridColumnacc_name
        '
        Me.GridColumnacc_name.Caption = "Account"
        Me.GridColumnacc_name.FieldName = "acc_name"
        Me.GridColumnacc_name.Name = "GridColumnacc_name"
        Me.GridColumnacc_name.Visible = True
        Me.GridColumnacc_name.VisibleIndex = 0
        '
        'GridColumnacc_description
        '
        Me.GridColumnacc_description.Caption = "Acc. Description"
        Me.GridColumnacc_description.FieldName = "acc_description"
        Me.GridColumnacc_description.Name = "GridColumnacc_description"
        Me.GridColumnacc_description.Visible = True
        Me.GridColumnacc_description.VisibleIndex = 1
        '
        'GridColumnvalue
        '
        Me.GridColumnvalue.Caption = "Amount"
        Me.GridColumnvalue.DisplayFormat.FormatString = "N2"
        Me.GridColumnvalue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnvalue.FieldName = "value"
        Me.GridColumnvalue.Name = "GridColumnvalue"
        Me.GridColumnvalue.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "value", "{0:N2}")})
        Me.GridColumnvalue.Visible = True
        Me.GridColumnvalue.VisibleIndex = 2
        '
        'GridColumnnote
        '
        Me.GridColumnnote.Caption = "Note"
        Me.GridColumnnote.FieldName = "note"
        Me.GridColumnnote.Name = "GridColumnnote"
        Me.GridColumnnote.Visible = True
        Me.GridColumnnote.VisibleIndex = 3
        '
        'FormPayoutZaloraComm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(513, 511)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.TxtOtherExpense)
        Me.Controls.Add(Me.TxtCommReff)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.TxtCommTax)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.TxtComm)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPayoutZaloraComm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Setup Commision"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.TxtComm.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCommTax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTotalCommInput.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtLinkComm.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCommReff.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtOtherExpense.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnDiscard As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnConfirm As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtComm As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtCommTax As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtTotalCommInput As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtLinkComm As DevExpress.XtraEditors.HyperLinkEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtCommReff As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtOtherExpense As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnid_zalora_comm_addition As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_payout_zalora As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_zalora_comm_type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnzalora_comm_type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_acc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnacc_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnacc_description As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnvalue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnote As DevExpress.XtraGrid.Columns.GridColumn
End Class
