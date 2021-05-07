<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProposePriceMKDHist
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
        Dim GridFormatRule4 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue4 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule5 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue5 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule6 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue6 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProposePriceMKDHist))
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_pp_change_det = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_pp_change = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoLinkNumber = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.GridColumnerp_discount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpropose_discount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpropose_price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpropose_price_final = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoLinkNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepoLinkNumber})
        Me.GCData.Size = New System.Drawing.Size(553, 265)
        Me.GCData.TabIndex = 0
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_pp_change_det, Me.GridColumnid_pp_change, Me.GridColumnnumber, Me.GridColumnerp_discount, Me.GridColumnpropose_discount, Me.GridColumnpropose_price, Me.GridColumnpropose_price_final, Me.GridColumncreated_date})
        GridFormatRule4.Column = Me.GridColumnpropose_discount
        GridFormatRule4.ColumnApplyTo = Me.GridColumnpropose_discount
        GridFormatRule4.Name = "Format0"
        FormatConditionRuleValue4.Appearance.BackColor = System.Drawing.Color.Yellow
        FormatConditionRuleValue4.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        FormatConditionRuleValue4.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue4.Appearance.Options.UseBorderColor = True
        FormatConditionRuleValue4.Condition = DevExpress.XtraEditors.FormatCondition.Expression
        FormatConditionRuleValue4.Expression = "Iif([propose_disc] > 0 And [propose_disc] <= 30, True, False)"
        GridFormatRule4.Rule = FormatConditionRuleValue4
        GridFormatRule5.Column = Me.GridColumnpropose_discount
        GridFormatRule5.ColumnApplyTo = Me.GridColumnpropose_discount
        GridFormatRule5.Name = "Format1"
        FormatConditionRuleValue5.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        FormatConditionRuleValue5.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        FormatConditionRuleValue5.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue5.Appearance.Options.UseBorderColor = True
        FormatConditionRuleValue5.Condition = DevExpress.XtraEditors.FormatCondition.Expression
        FormatConditionRuleValue5.Expression = "Iif([propose_disc] > 31 And [propose_disc] <= 50, True, False)"
        GridFormatRule5.Rule = FormatConditionRuleValue5
        GridFormatRule6.Column = Me.GridColumnpropose_discount
        GridFormatRule6.ColumnApplyTo = Me.GridColumnpropose_discount
        GridFormatRule6.Name = "Format2"
        FormatConditionRuleValue6.Appearance.BackColor = System.Drawing.Color.Lime
        FormatConditionRuleValue6.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        FormatConditionRuleValue6.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue6.Appearance.Options.UseBorderColor = True
        FormatConditionRuleValue6.Condition = DevExpress.XtraEditors.FormatCondition.Expression
        FormatConditionRuleValue6.Expression = "Iif([propose_disc] > 51, True, False)"
        GridFormatRule6.Rule = FormatConditionRuleValue6
        Me.GVData.FormatRules.Add(GridFormatRule4)
        Me.GVData.FormatRules.Add(GridFormatRule5)
        Me.GVData.FormatRules.Add(GridFormatRule6)
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_pp_change_det
        '
        Me.GridColumnid_pp_change_det.Caption = "id_pp_change_det"
        Me.GridColumnid_pp_change_det.FieldName = "id_pp_change_det"
        Me.GridColumnid_pp_change_det.Name = "GridColumnid_pp_change_det"
        '
        'GridColumnid_pp_change
        '
        Me.GridColumnid_pp_change.Caption = "id_pp_change"
        Me.GridColumnid_pp_change.FieldName = "id_pp_change"
        Me.GridColumnid_pp_change.Name = "GridColumnid_pp_change"
        '
        'GridColumnnumber
        '
        Me.GridColumnnumber.Caption = "Number"
        Me.GridColumnnumber.ColumnEdit = Me.RepoLinkNumber
        Me.GridColumnnumber.FieldName = "number"
        Me.GridColumnnumber.Name = "GridColumnnumber"
        Me.GridColumnnumber.Visible = True
        Me.GridColumnnumber.VisibleIndex = 0
        Me.GridColumnnumber.Width = 61
        '
        'RepoLinkNumber
        '
        Me.RepoLinkNumber.AutoHeight = False
        Me.RepoLinkNumber.Name = "RepoLinkNumber"
        '
        'GridColumnerp_discount
        '
        Me.GridColumnerp_discount.Caption = "Rekomendasi Disc."
        Me.GridColumnerp_discount.DisplayFormat.FormatString = "{0:n0}%"
        Me.GridColumnerp_discount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnerp_discount.FieldName = "erp_discount"
        Me.GridColumnerp_discount.Name = "GridColumnerp_discount"
        Me.GridColumnerp_discount.Visible = True
        Me.GridColumnerp_discount.VisibleIndex = 2
        Me.GridColumnerp_discount.Width = 107
        '
        'GridColumnpropose_discount
        '
        Me.GridColumnpropose_discount.Caption = "Propose Disc"
        Me.GridColumnpropose_discount.DisplayFormat.FormatString = "{0:n0}%"
        Me.GridColumnpropose_discount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnpropose_discount.FieldName = "propose_discount"
        Me.GridColumnpropose_discount.Name = "GridColumnpropose_discount"
        Me.GridColumnpropose_discount.Visible = True
        Me.GridColumnpropose_discount.VisibleIndex = 3
        '
        'GridColumnpropose_price
        '
        Me.GridColumnpropose_price.Caption = "Propose Price"
        Me.GridColumnpropose_price.DisplayFormat.FormatString = "N0"
        Me.GridColumnpropose_price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnpropose_price.FieldName = "propose_price"
        Me.GridColumnpropose_price.Name = "GridColumnpropose_price"
        Me.GridColumnpropose_price.Visible = True
        Me.GridColumnpropose_price.VisibleIndex = 4
        '
        'GridColumnpropose_price_final
        '
        Me.GridColumnpropose_price_final.Caption = "Propose Final"
        Me.GridColumnpropose_price_final.DisplayFormat.FormatString = "N0"
        Me.GridColumnpropose_price_final.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnpropose_price_final.FieldName = "propose_price_final"
        Me.GridColumnpropose_price_final.Name = "GridColumnpropose_price_final"
        Me.GridColumnpropose_price_final.Visible = True
        Me.GridColumnpropose_price_final.VisibleIndex = 5
        '
        'GridColumncreated_date
        '
        Me.GridColumncreated_date.Caption = "Created Date"
        Me.GridColumncreated_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumncreated_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumncreated_date.FieldName = "created_date"
        Me.GridColumncreated_date.Name = "GridColumncreated_date"
        Me.GridColumncreated_date.Visible = True
        Me.GridColumncreated_date.VisibleIndex = 1
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnClose)
        Me.PanelControl1.Controls.Add(Me.BtnPrint)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 265)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(553, 47)
        Me.PanelControl1.TabIndex = 1
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(469, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(82, 43)
        Me.BtnPrint.TabIndex = 0
        Me.BtnPrint.Text = "Print"
        '
        'BtnClose
        '
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(387, 2)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(82, 43)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        '
        'FormProposePriceMKDHist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(553, 312)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormProposePriceMKDHist"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "History"
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoLinkNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_pp_change_det As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_pp_change As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoLinkNumber As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents GridColumnerp_discount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpropose_discount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpropose_price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpropose_price_final As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
End Class
