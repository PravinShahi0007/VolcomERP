<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpPL
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
        Me.GroupGeneral = New DevExpress.XtraEditors.GroupControl
        Me.GCPL = New DevExpress.XtraGrid.GridControl
        Me.GVPL = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdSamplePL = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdComp = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdCompFrom = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColTo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPLCategory = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColRecDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnInfo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemHyperLinkEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
        Me.GridColumnCodeCompFrom = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCodeCompTo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Me.ColCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdSamplePurcRecDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GVDetailPL = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColQtyPL = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCDetailPL = New DevExpress.XtraGrid.GridControl
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneral.SuspendLayout()
        CType(Me.GCPL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDetailPL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCDetailPL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupGeneral
        '
        Me.GroupGeneral.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupGeneral.Controls.Add(Me.GCPL)
        Me.GroupGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupGeneral.Location = New System.Drawing.Point(0, 0)
        Me.GroupGeneral.Name = "GroupGeneral"
        Me.GroupGeneral.Size = New System.Drawing.Size(814, 216)
        Me.GroupGeneral.TabIndex = 16
        Me.GroupGeneral.Text = "Packing List Data"
        '
        'GCPL
        '
        Me.GCPL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPL.Location = New System.Drawing.Point(2, 22)
        Me.GCPL.MainView = Me.GVPL
        Me.GCPL.Name = "GCPL"
        Me.GCPL.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit1, Me.RepositoryItemHyperLinkEdit1})
        Me.GCPL.Size = New System.Drawing.Size(810, 192)
        Me.GCPL.TabIndex = 1
        Me.GCPL.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPL})
        '
        'GVPL
        '
        Me.GVPL.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdSamplePL, Me.GridColumnIdComp, Me.GridColumnIdCompFrom, Me.ColNumber, Me.GridColumn1, Me.ColTo, Me.GridColumnPLCategory, Me.ColRecDate, Me.GridColumnStatus, Me.GridColumnInfo, Me.GridColumnCodeCompFrom, Me.GridColumnCodeCompTo})
        Me.GVPL.GridControl = Me.GCPL
        Me.GVPL.Name = "GVPL"
        Me.GVPL.OptionsFind.AlwaysVisible = True
        Me.GVPL.OptionsView.ShowGroupPanel = False
        '
        'ColIdSamplePL
        '
        Me.ColIdSamplePL.Caption = "ID PL Sample"
        Me.ColIdSamplePL.FieldName = "id_pl_sample_purc"
        Me.ColIdSamplePL.Name = "ColIdSamplePL"
        Me.ColIdSamplePL.OptionsColumn.AllowEdit = False
        '
        'GridColumnIdComp
        '
        Me.GridColumnIdComp.Caption = "IdCompContactTo"
        Me.GridColumnIdComp.FieldName = "id_comp_contact_to"
        Me.GridColumnIdComp.Name = "GridColumnIdComp"
        Me.GridColumnIdComp.OptionsColumn.AllowEdit = False
        '
        'GridColumnIdCompFrom
        '
        Me.GridColumnIdCompFrom.Caption = "IdCompContactFrom"
        Me.GridColumnIdCompFrom.FieldName = "id_comp_contact_from"
        Me.GridColumnIdCompFrom.Name = "GridColumnIdCompFrom"
        Me.GridColumnIdCompFrom.OptionsColumn.AllowEdit = False
        '
        'ColNumber
        '
        Me.ColNumber.Caption = "PL Number"
        Me.ColNumber.FieldName = "pl_sample_purc_number"
        Me.ColNumber.Name = "ColNumber"
        Me.ColNumber.OptionsColumn.AllowEdit = False
        Me.ColNumber.Visible = True
        Me.ColNumber.VisibleIndex = 0
        Me.ColNumber.Width = 100
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "From"
        Me.GridColumn1.FieldName = "comp_name_from"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 1
        '
        'ColTo
        '
        Me.ColTo.Caption = "To"
        Me.ColTo.FieldName = "comp_name"
        Me.ColTo.Name = "ColTo"
        Me.ColTo.OptionsColumn.AllowEdit = False
        Me.ColTo.Visible = True
        Me.ColTo.VisibleIndex = 2
        Me.ColTo.Width = 124
        '
        'GridColumnPLCategory
        '
        Me.GridColumnPLCategory.Caption = "PL Category"
        Me.GridColumnPLCategory.FieldName = "pl_category"
        Me.GridColumnPLCategory.Name = "GridColumnPLCategory"
        Me.GridColumnPLCategory.OptionsColumn.AllowEdit = False
        Me.GridColumnPLCategory.Visible = True
        Me.GridColumnPLCategory.VisibleIndex = 3
        '
        'ColRecDate
        '
        Me.ColRecDate.Caption = "Create Date"
        Me.ColRecDate.FieldName = "pl_sample_purc_date"
        Me.ColRecDate.Name = "ColRecDate"
        Me.ColRecDate.OptionsColumn.AllowEdit = False
        Me.ColRecDate.Visible = True
        Me.ColRecDate.VisibleIndex = 4
        Me.ColRecDate.Width = 114
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.OptionsColumn.AllowEdit = False
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 5
        '
        'GridColumnInfo
        '
        Me.GridColumnInfo.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnInfo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridColumnInfo.Caption = "Information"
        Me.GridColumnInfo.ColumnEdit = Me.RepositoryItemHyperLinkEdit1
        Me.GridColumnInfo.FieldName = "label_info"
        Me.GridColumnInfo.Name = "GridColumnInfo"
        '
        'RepositoryItemHyperLinkEdit1
        '
        Me.RepositoryItemHyperLinkEdit1.AutoHeight = False
        Me.RepositoryItemHyperLinkEdit1.Name = "RepositoryItemHyperLinkEdit1"
        Me.RepositoryItemHyperLinkEdit1.SingleClick = True
        Me.RepositoryItemHyperLinkEdit1.StartKey = New DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A))
        '
        'GridColumnCodeCompFrom
        '
        Me.GridColumnCodeCompFrom.Caption = "Code Comp From"
        Me.GridColumnCodeCompFrom.FieldName = "code_comp_from"
        Me.GridColumnCodeCompFrom.Name = "GridColumnCodeCompFrom"
        Me.GridColumnCodeCompFrom.Visible = True
        Me.GridColumnCodeCompFrom.VisibleIndex = 6
        '
        'GridColumnCodeCompTo
        '
        Me.GridColumnCodeCompTo.Caption = "Code Comp To"
        Me.GridColumnCodeCompTo.FieldName = "code_comp_to"
        Me.GridColumnCodeCompTo.Name = "GridColumnCodeCompTo"
        Me.GridColumnCodeCompTo.Visible = True
        Me.GridColumnCodeCompTo.VisibleIndex = 7
        '
        'RepositoryItemLookUpEdit1
        '
        Me.RepositoryItemLookUpEdit1.AutoHeight = False
        Me.RepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1"
        '
        'ColCode
        '
        Me.ColCode.Caption = "Code"
        Me.ColCode.FieldName = "code"
        Me.ColCode.Name = "ColCode"
        Me.ColCode.Visible = True
        Me.ColCode.VisibleIndex = 1
        Me.ColCode.Width = 140
        '
        'ColNo
        '
        Me.ColNo.AppearanceCell.Options.UseTextOptions = True
        Me.ColNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColNo.Caption = "NO."
        Me.ColNo.FieldName = "no"
        Me.ColNo.Name = "ColNo"
        Me.ColNo.Visible = True
        Me.ColNo.VisibleIndex = 0
        Me.ColNo.Width = 30
        '
        'ColIdSamplePurcRecDet
        '
        Me.ColIdSamplePurcRecDet.Caption = "ID Receive Sample Detail"
        Me.ColIdSamplePurcRecDet.FieldName = "id_sample_purc_rec_det"
        Me.ColIdSamplePurcRecDet.Name = "ColIdSamplePurcRecDet"
        '
        'GVDetailPL
        '
        Me.GVDetailPL.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdSamplePurcRecDet, Me.ColNo, Me.ColCode, Me.ColName, Me.ColSize, Me.ColQtyPL})
        Me.GVDetailPL.GridControl = Me.GCDetailPL
        Me.GVDetailPL.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.GVDetailPL.Name = "GVDetailPL"
        Me.GVDetailPL.OptionsBehavior.Editable = False
        Me.GVDetailPL.OptionsView.ShowGroupPanel = False
        '
        'ColName
        '
        Me.ColName.Caption = "Name"
        Me.ColName.FieldName = "name"
        Me.ColName.Name = "ColName"
        Me.ColName.Visible = True
        Me.ColName.VisibleIndex = 2
        Me.ColName.Width = 235
        '
        'ColSize
        '
        Me.ColSize.AppearanceCell.Options.UseTextOptions = True
        Me.ColSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColSize.AppearanceHeader.Options.UseTextOptions = True
        Me.ColSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColSize.Caption = "Size"
        Me.ColSize.FieldName = "size"
        Me.ColSize.Name = "ColSize"
        Me.ColSize.Visible = True
        Me.ColSize.VisibleIndex = 3
        Me.ColSize.Width = 140
        '
        'ColQtyPL
        '
        Me.ColQtyPL.AppearanceCell.Options.UseTextOptions = True
        Me.ColQtyPL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQtyPL.AppearanceHeader.Options.UseTextOptions = True
        Me.ColQtyPL.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQtyPL.Caption = "Qty PL"
        Me.ColQtyPL.FieldName = "qty_issue"
        Me.ColQtyPL.Name = "ColQtyPL"
        Me.ColQtyPL.Visible = True
        Me.ColQtyPL.VisibleIndex = 4
        Me.ColQtyPL.Width = 68
        '
        'GCDetailPL
        '
        Me.GCDetailPL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDetailPL.Location = New System.Drawing.Point(0, 0)
        Me.GCDetailPL.MainView = Me.GVDetailPL
        Me.GCDetailPL.Name = "GCDetailPL"
        Me.GCDetailPL.Size = New System.Drawing.Size(814, 195)
        Me.GCDetailPL.TabIndex = 3
        Me.GCDetailPL.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDetailPL})
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(663, 10)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(70, 23)
        Me.BtnCancel.TabIndex = 2
        Me.BtnCancel.Text = "Cancel"
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.BtnCancel)
        Me.PanelControl2.Controls.Add(Me.BtnSave)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 412)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(814, 45)
        Me.PanelControl2.TabIndex = 31
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(739, 10)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(70, 23)
        Me.BtnSave.TabIndex = 1
        Me.BtnSave.Text = "Choose"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GroupGeneral)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GCDetailPL)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(814, 416)
        Me.SplitContainerControl1.SplitterPosition = 216
        Me.SplitContainerControl1.TabIndex = 28
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'FormPopUpPL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 457)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPopUpPL"
        Me.ShowInTaskbar = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Popup Packing List"
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneral.ResumeLayout(False)
        CType(Me.GCPL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDetailPL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCDetailPL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupGeneral As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCPL As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPL As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdSamplePL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdComp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRecDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnInfo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemHyperLinkEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents RepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents ColCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdSamplePurcRecDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GVDetailPL As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColQtyPL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCDetailPL As DevExpress.XtraGrid.GridControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdCompFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCodeCompFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCodeCompTo As DevExpress.XtraGrid.Columns.GridColumn
End Class
