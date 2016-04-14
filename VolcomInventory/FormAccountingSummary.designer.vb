<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAccountingSummary
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
        Me.TreeList1 = New DevExpress.XtraTreeList.TreeList
        Me.id_acc = New DevExpress.XtraTreeList.Columns.TreeListColumn
        Me.id_acc_parent = New DevExpress.XtraTreeList.Columns.TreeListColumn
        Me.ColAccName = New DevExpress.XtraTreeList.Columns.TreeListColumn
        Me.ColAccDesc = New DevExpress.XtraTreeList.Columns.TreeListColumn
        Me.ColDebit = New DevExpress.XtraTreeList.Columns.TreeListColumn
        Me.ColCredit = New DevExpress.XtraTreeList.Columns.TreeListColumn
        Me.ColIdAllChild = New DevExpress.XtraTreeList.Columns.TreeListColumn
        Me.BalanceMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SMViewTransaction = New System.Windows.Forms.ToolStripMenuItem
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.DETo = New DevExpress.XtraEditors.DateEdit
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit
        Me.BView = New DevExpress.XtraEditors.SimpleButton
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BalanceMenu.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.DETo.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DETo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TreeList1
        '
        Me.TreeList1.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.id_acc, Me.id_acc_parent, Me.ColAccName, Me.ColAccDesc, Me.ColDebit, Me.ColCredit, Me.ColIdAllChild})
        Me.TreeList1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeList1.KeyFieldName = "id_acc"
        Me.TreeList1.Location = New System.Drawing.Point(0, 0)
        Me.TreeList1.Name = "TreeList1"
        Me.TreeList1.OptionsBehavior.AutoPopulateColumns = False
        Me.TreeList1.OptionsView.EnableAppearanceEvenRow = True
        Me.TreeList1.OptionsView.ShowSummaryFooter = True
        Me.TreeList1.ParentFieldName = "id_acc_parent"
        Me.TreeList1.RootValue = "0"
        Me.TreeList1.Size = New System.Drawing.Size(807, 327)
        Me.TreeList1.TabIndex = 1
        '
        'id_acc
        '
        Me.id_acc.Caption = "id_acc"
        Me.id_acc.FieldName = "id_acc"
        Me.id_acc.Name = "id_acc"
        Me.id_acc.OptionsColumn.ReadOnly = True
        Me.id_acc.Width = 185
        '
        'id_acc_parent
        '
        Me.id_acc_parent.Caption = "id_acc_parent"
        Me.id_acc_parent.FieldName = "id_acc_parent"
        Me.id_acc_parent.Name = "id_acc_parent"
        Me.id_acc_parent.OptionsColumn.ReadOnly = True
        Me.id_acc_parent.Width = 186
        '
        'ColAccName
        '
        Me.ColAccName.Caption = "Account"
        Me.ColAccName.FieldName = "acc_name"
        Me.ColAccName.Name = "ColAccName"
        Me.ColAccName.OptionsColumn.ReadOnly = True
        Me.ColAccName.Visible = True
        Me.ColAccName.VisibleIndex = 0
        Me.ColAccName.Width = 186
        '
        'ColAccDesc
        '
        Me.ColAccDesc.Caption = "Description"
        Me.ColAccDesc.FieldName = "acc_description"
        Me.ColAccDesc.Name = "ColAccDesc"
        Me.ColAccDesc.OptionsColumn.ReadOnly = True
        Me.ColAccDesc.Visible = True
        Me.ColAccDesc.VisibleIndex = 1
        Me.ColAccDesc.Width = 186
        '
        'ColDebit
        '
        Me.ColDebit.AppearanceCell.Options.UseTextOptions = True
        Me.ColDebit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColDebit.AppearanceHeader.Options.UseTextOptions = True
        Me.ColDebit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColDebit.Caption = "Debit"
        Me.ColDebit.FieldName = "debit"
        Me.ColDebit.Format.FormatString = "N2"
        Me.ColDebit.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColDebit.Name = "ColDebit"
        Me.ColDebit.OptionsColumn.ReadOnly = True
        Me.ColDebit.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Sum
        Me.ColDebit.SummaryFooterStrFormat = "{0:N2}"
        Me.ColDebit.Visible = True
        Me.ColDebit.VisibleIndex = 2
        '
        'ColCredit
        '
        Me.ColCredit.AppearanceCell.Options.UseTextOptions = True
        Me.ColCredit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColCredit.AppearanceHeader.Options.UseTextOptions = True
        Me.ColCredit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColCredit.Caption = "Credit"
        Me.ColCredit.FieldName = "credit"
        Me.ColCredit.Format.FormatString = "N2"
        Me.ColCredit.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColCredit.Name = "ColCredit"
        Me.ColCredit.OptionsColumn.ReadOnly = True
        Me.ColCredit.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Sum
        Me.ColCredit.SummaryFooterStrFormat = "{0:N2}"
        Me.ColCredit.Visible = True
        Me.ColCredit.VisibleIndex = 3
        '
        'ColIdAllChild
        '
        Me.ColIdAllChild.Caption = "Child"
        Me.ColIdAllChild.FieldName = "id_all_child"
        Me.ColIdAllChild.Name = "ColIdAllChild"
        '
        'BalanceMenu
        '
        Me.BalanceMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SMViewTransaction})
        Me.BalanceMenu.Name = "ContextMenuStripYM"
        Me.BalanceMenu.Size = New System.Drawing.Size(137, 26)
        '
        'SMViewTransaction
        '
        Me.SMViewTransaction.Name = "SMViewTransaction"
        Me.SMViewTransaction.Size = New System.Drawing.Size(136, 22)
        Me.SMViewTransaction.Text = "Transaction"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.LabelControl2)
        Me.PanelControl3.Controls.Add(Me.LabelControl3)
        Me.PanelControl3.Controls.Add(Me.DETo)
        Me.PanelControl3.Controls.Add(Me.DEFrom)
        Me.PanelControl3.Controls.Add(Me.BView)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 327)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(807, 41)
        Me.PanelControl3.TabIndex = 3
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(245, 13)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(17, 13)
        Me.LabelControl2.TabIndex = 9
        Me.LabelControl2.Text = "to :"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(23, 13)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl3.TabIndex = 8
        Me.LabelControl3.Text = "From :"
        '
        'DETo
        '
        Me.DETo.EditValue = Nothing
        Me.DETo.Location = New System.Drawing.Point(273, 10)
        Me.DETo.Name = "DETo"
        Me.DETo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DETo.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.DETo.Size = New System.Drawing.Size(172, 20)
        Me.DETo.TabIndex = 7
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(60, 10)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.DEFrom.Size = New System.Drawing.Size(172, 20)
        Me.DEFrom.TabIndex = 6
        '
        'BView
        '
        Me.BView.Location = New System.Drawing.Point(463, 9)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(119, 22)
        Me.BView.TabIndex = 5
        Me.BView.Text = "View Transaction"
        '
        'FormAccountingSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(807, 368)
        Me.Controls.Add(Me.TreeList1)
        Me.Controls.Add(Me.PanelControl3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAccountingSummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Summary"
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BalanceMenu.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.DETo.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DETo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TreeList1 As DevExpress.XtraTreeList.TreeList
    Friend WithEvents id_acc As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents id_acc_parent As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents ColAccName As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents ColAccDesc As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents ColDebit As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents ColCredit As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents ColIdAllChild As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents BalanceMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SMViewTransaction As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DETo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
End Class
