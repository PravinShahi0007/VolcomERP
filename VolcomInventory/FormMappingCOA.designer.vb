<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMappingCOA
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
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        Me.LReportMarkType = New DevExpress.XtraEditors.LabelControl
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl
        Me.GCAcc = New DevExpress.XtraGrid.GridControl
        Me.GVAcc = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.id_coa_mapping = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIsStrict = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Account = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RIColAcc = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
        Me.AccDescription = New DevExpress.XtraGrid.Columns.GridColumn
        Me.is_active = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.ACCDesc = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RILUDebitCredit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Me.is_active_company = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.RICBDebitCredit = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl
        Me.CEAutoPosting = New DevExpress.XtraEditors.CheckEdit
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BSave = New DevExpress.XtraEditors.SimpleButton
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GCAcc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAcc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RIColAcc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RILUDebitCredit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.is_active_company, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICBDebitCredit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.CEAutoPosting.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.LReportMarkType)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(799, 49)
        Me.GroupControl1.TabIndex = 0
        '
        'LReportMarkType
        '
        Me.LReportMarkType.Appearance.Font = New System.Drawing.Font("Kalinga", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LReportMarkType.Location = New System.Drawing.Point(25, 9)
        Me.LReportMarkType.Name = "LReportMarkType"
        Me.LReportMarkType.Size = New System.Drawing.Size(182, 25)
        Me.LReportMarkType.TabIndex = 0
        Me.LReportMarkType.Text = "Report Mark Type Here"
        '
        'GroupControl2
        '
        Me.GroupControl2.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl2.Controls.Add(Me.GCAcc)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 49)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(799, 286)
        Me.GroupControl2.TabIndex = 1
        '
        'GCAcc
        '
        Me.GCAcc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAcc.Location = New System.Drawing.Point(22, 2)
        Me.GCAcc.MainView = Me.GVAcc
        Me.GCAcc.Name = "GCAcc"
        Me.GCAcc.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.is_active_company, Me.RepositoryItemCheckEdit1, Me.RIColAcc, Me.RICBDebitCredit, Me.RILUDebitCredit})
        Me.GCAcc.Size = New System.Drawing.Size(775, 282)
        Me.GCAcc.TabIndex = 5
        Me.GCAcc.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAcc})
        '
        'GVAcc
        '
        Me.GVAcc.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.id_coa_mapping, Me.ColIsStrict, Me.GridColumn2, Me.Account, Me.AccDescription, Me.is_active, Me.ACCDesc, Me.GridColumn1})
        Me.GVAcc.GridControl = Me.GCAcc
        Me.GVAcc.Name = "GVAcc"
        Me.GVAcc.OptionsFind.AllowFindPanel = False
        Me.GVAcc.OptionsView.ShowGroupPanel = False
        '
        'id_coa_mapping
        '
        Me.id_coa_mapping.Caption = "ID"
        Me.id_coa_mapping.FieldName = "id_coa_mapping"
        Me.id_coa_mapping.Name = "id_coa_mapping"
        '
        'ColIsStrict
        '
        Me.ColIsStrict.Caption = "Strict"
        Me.ColIsStrict.FieldName = "is_strict"
        Me.ColIsStrict.Name = "ColIsStrict"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "ID Acc"
        Me.GridColumn2.FieldName = "id_acc"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'Account
        '
        Me.Account.Caption = "COA"
        Me.Account.ColumnEdit = Me.RIColAcc
        Me.Account.FieldName = "acc_name"
        Me.Account.Name = "Account"
        Me.Account.Visible = True
        Me.Account.VisibleIndex = 1
        Me.Account.Width = 95
        '
        'RIColAcc
        '
        Me.RIColAcc.AutoHeight = False
        Me.RIColAcc.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.RIColAcc.Name = "RIColAcc"
        '
        'AccDescription
        '
        Me.AccDescription.Caption = "Mapping Description"
        Me.AccDescription.FieldName = "description"
        Me.AccDescription.Name = "AccDescription"
        Me.AccDescription.Visible = True
        Me.AccDescription.VisibleIndex = 0
        Me.AccDescription.Width = 242
        '
        'is_active
        '
        Me.is_active.AppearanceHeader.Options.UseTextOptions = True
        Me.is_active.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.is_active.Caption = "Followed By Vendor Code"
        Me.is_active.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.is_active.FieldName = "is_acc_sup"
        Me.is_active.Name = "is_active"
        Me.is_active.Visible = True
        Me.is_active.VisibleIndex = 3
        Me.is_active.Width = 150
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RepositoryItemCheckEdit1.ValueGrayed = "0"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'ACCDesc
        '
        Me.ACCDesc.Caption = "COA Description"
        Me.ACCDesc.FieldName = "acc_description"
        Me.ACCDesc.Name = "ACCDesc"
        Me.ACCDesc.Visible = True
        Me.ACCDesc.VisibleIndex = 2
        Me.ACCDesc.Width = 172
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Debit / Credit"
        Me.GridColumn1.ColumnEdit = Me.RILUDebitCredit
        Me.GridColumn1.FieldName = "id_dc"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 4
        '
        'RILUDebitCredit
        '
        Me.RILUDebitCredit.AutoHeight = False
        Me.RILUDebitCredit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RILUDebitCredit.Name = "RILUDebitCredit"
        Me.RILUDebitCredit.NullText = ""
        '
        'is_active_company
        '
        Me.is_active_company.AutoHeight = False
        Me.is_active_company.DisplayValueChecked = "1"
        Me.is_active_company.DisplayValueUnchecked = "0"
        Me.is_active_company.Name = "is_active_company"
        '
        'RICBDebitCredit
        '
        Me.RICBDebitCredit.AutoHeight = False
        Me.RICBDebitCredit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RICBDebitCredit.Name = "RICBDebitCredit"
        '
        'GroupControl3
        '
        Me.GroupControl3.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl3.Controls.Add(Me.CEAutoPosting)
        Me.GroupControl3.Controls.Add(Me.BCancel)
        Me.GroupControl3.Controls.Add(Me.BSave)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl3.Location = New System.Drawing.Point(0, 335)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(799, 36)
        Me.GroupControl3.TabIndex = 2
        '
        'CEAutoPosting
        '
        Me.CEAutoPosting.Location = New System.Drawing.Point(28, 8)
        Me.CEAutoPosting.Name = "CEAutoPosting"
        Me.CEAutoPosting.Properties.Caption = "Auto Posting"
        Me.CEAutoPosting.Size = New System.Drawing.Size(93, 19)
        Me.CEAutoPosting.TabIndex = 2
        '
        'BCancel
        '
        Me.BCancel.Location = New System.Drawing.Point(630, 7)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(75, 23)
        Me.BCancel.TabIndex = 1
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Location = New System.Drawing.Point(711, 7)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(75, 23)
        Me.BSave.TabIndex = 0
        Me.BSave.Text = "Save"
        '
        'FormMappingCOA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(799, 371)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.GroupControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMappingCOA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mapping COA"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GCAcc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAcc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RIColAcc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RILUDebitCredit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.is_active_company, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICBDebitCredit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.CEAutoPosting.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCAcc As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAcc As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents id_coa_mapping As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Account As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents AccDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents is_active As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents is_active_company As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents LReportMarkType As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RIColAcc As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents ACCDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CEAutoPosting As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICBDebitCredit As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RILUDebitCredit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents ColIsStrict As DevExpress.XtraGrid.Columns.GridColumn
End Class
