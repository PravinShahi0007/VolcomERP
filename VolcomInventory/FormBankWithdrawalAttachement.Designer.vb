<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormBankWithdrawalAttachement
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBankWithdrawalAttachement))
        Me.SimpleButtonAttachment = New DevExpress.XtraEditors.SimpleButton()
        Me.DateEditDueDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButtonSet = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TextEditVendor = New DevExpress.XtraEditors.TextEdit()
        Me.TextEditPONumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.GCPurcReq = New DevExpress.XtraGrid.GridControl()
        Me.GVPurcReq = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn33 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEditPph = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.TEVATValue = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl23 = New DevExpress.XtraEditors.LabelControl()
        Me.TEVATPercent = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl22 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.TEDiscTotal = New DevExpress.XtraEditors.TextEdit()
        Me.TEGrandTotal = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.TEDiscPercent = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.TETotal = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.DateEditDueDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditDueDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEditVendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEditPONumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GCPurcReq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPurcReq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEditPph, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEVATValue.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEVATPercent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDiscTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEGrandTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDiscPercent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TETotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        Me.SuspendLayout()
        '
        'SimpleButtonAttachment
        '
        Me.SimpleButtonAttachment.Location = New System.Drawing.Point(318, 12)
        Me.SimpleButtonAttachment.Name = "SimpleButtonAttachment"
        Me.SimpleButtonAttachment.Size = New System.Drawing.Size(160, 20)
        Me.SimpleButtonAttachment.TabIndex = 0
        Me.SimpleButtonAttachment.Text = "View"
        '
        'DateEditDueDate
        '
        Me.DateEditDueDate.EditValue = Nothing
        Me.DateEditDueDate.Location = New System.Drawing.Point(318, 38)
        Me.DateEditDueDate.Name = "DateEditDueDate"
        Me.DateEditDueDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DateEditDueDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditDueDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditDueDate.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DateEditDueDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEditDueDate.Properties.EditFormat.FormatString = "dd MMMM yyyy"
        Me.DateEditDueDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEditDueDate.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DateEditDueDate.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DateEditDueDate.Size = New System.Drawing.Size(160, 20)
        Me.DateEditDueDate.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(252, 41)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Due Date"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(252, 15)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Attachment"
        '
        'SimpleButtonSet
        '
        Me.SimpleButtonSet.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButtonSet.Image = CType(resources.GetObject("SimpleButtonSet.Image"), System.Drawing.Image)
        Me.SimpleButtonSet.Location = New System.Drawing.Point(422, 2)
        Me.SimpleButtonSet.Name = "SimpleButtonSet"
        Me.SimpleButtonSet.Size = New System.Drawing.Size(68, 34)
        Me.SimpleButtonSet.TabIndex = 4
        Me.SimpleButtonSet.Text = "Set"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(16, 15)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl3.TabIndex = 6
        Me.LabelControl3.Text = "Vendor"
        '
        'TextEditVendor
        '
        Me.TextEditVendor.Location = New System.Drawing.Point(76, 12)
        Me.TextEditVendor.Name = "TextEditVendor"
        Me.TextEditVendor.Properties.ReadOnly = True
        Me.TextEditVendor.Size = New System.Drawing.Size(160, 20)
        Me.TextEditVendor.TabIndex = 7
        '
        'TextEditPONumber
        '
        Me.TextEditPONumber.Location = New System.Drawing.Point(76, 38)
        Me.TextEditPONumber.Name = "TextEditPONumber"
        Me.TextEditPONumber.Properties.ReadOnly = True
        Me.TextEditPONumber.Size = New System.Drawing.Size(160, 20)
        Me.TextEditPONumber.TabIndex = 9
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(16, 41)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl4.TabIndex = 8
        Me.LabelControl4.Text = "PO Number"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.GCPurcReq)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl2.Location = New System.Drawing.Point(0, 192)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(492, 245)
        Me.PanelControl2.TabIndex = 11
        '
        'GCPurcReq
        '
        Me.GCPurcReq.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPurcReq.Location = New System.Drawing.Point(2, 2)
        Me.GCPurcReq.MainView = Me.GVPurcReq
        Me.GCPurcReq.Name = "GCPurcReq"
        Me.GCPurcReq.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEditPph})
        Me.GCPurcReq.Size = New System.Drawing.Size(488, 241)
        Me.GCPurcReq.TabIndex = 12
        Me.GCPurcReq.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPurcReq})
        '
        'GVPurcReq
        '
        Me.GVPurcReq.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn8, Me.GridColumn21, Me.GridColumn33, Me.GridColumn4, Me.GridColumn2, Me.GridColumn1})
        Me.GVPurcReq.GridControl = Me.GCPurcReq
        Me.GVPurcReq.Name = "GVPurcReq"
        Me.GVPurcReq.OptionsFind.AllowFindPanel = False
        Me.GVPurcReq.OptionsView.ColumnAutoWidth = False
        Me.GVPurcReq.OptionsView.ShowGroupPanel = False
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "id_purc_order_det"
        Me.GridColumn8.FieldName = "id_purc_order_det"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.OptionsColumn.ReadOnly = True
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "Item"
        Me.GridColumn21.FieldName = "item_desc"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.OptionsColumn.AllowEdit = False
        Me.GridColumn21.OptionsColumn.ReadOnly = True
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 0
        Me.GridColumn21.Width = 78
        '
        'GridColumn33
        '
        Me.GridColumn33.Caption = "Qty (PO)"
        Me.GridColumn33.DisplayFormat.FormatString = "N2"
        Me.GridColumn33.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn33.FieldName = "qty_po"
        Me.GridColumn33.Name = "GridColumn33"
        Me.GridColumn33.OptionsColumn.AllowEdit = False
        Me.GridColumn33.OptionsColumn.ReadOnly = True
        Me.GridColumn33.Visible = True
        Me.GridColumn33.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Price"
        Me.GridColumn4.DisplayFormat.FormatString = "N2"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn4.FieldName = "val_po"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.OptionsColumn.ReadOnly = True
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Pph (%)"
        Me.GridColumn1.ColumnEdit = Me.RepositoryItemTextEditPph
        Me.GridColumn1.DisplayFormat.FormatString = "N2"
        Me.GridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn1.FieldName = "pph_percent"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 4
        '
        'RepositoryItemTextEditPph
        '
        Me.RepositoryItemTextEditPph.AutoHeight = False
        Me.RepositoryItemTextEditPph.DisplayFormat.FormatString = "N2"
        Me.RepositoryItemTextEditPph.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEditPph.EditFormat.FormatString = "N2"
        Me.RepositoryItemTextEditPph.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEditPph.Mask.EditMask = "N2"
        Me.RepositoryItemTextEditPph.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RepositoryItemTextEditPph.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemTextEditPph.Name = "RepositoryItemTextEditPph"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.PanelControl1)
        Me.PanelControl3.Controls.Add(Me.TEVATValue)
        Me.PanelControl3.Controls.Add(Me.LabelControl23)
        Me.PanelControl3.Controls.Add(Me.TextEditVendor)
        Me.PanelControl3.Controls.Add(Me.TEVATPercent)
        Me.PanelControl3.Controls.Add(Me.SimpleButtonAttachment)
        Me.PanelControl3.Controls.Add(Me.LabelControl22)
        Me.PanelControl3.Controls.Add(Me.DateEditDueDate)
        Me.PanelControl3.Controls.Add(Me.LabelControl15)
        Me.PanelControl3.Controls.Add(Me.TextEditPONumber)
        Me.PanelControl3.Controls.Add(Me.TEDiscTotal)
        Me.PanelControl3.Controls.Add(Me.LabelControl1)
        Me.PanelControl3.Controls.Add(Me.TEGrandTotal)
        Me.PanelControl3.Controls.Add(Me.LabelControl4)
        Me.PanelControl3.Controls.Add(Me.LabelControl9)
        Me.PanelControl3.Controls.Add(Me.LabelControl2)
        Me.PanelControl3.Controls.Add(Me.TEDiscPercent)
        Me.PanelControl3.Controls.Add(Me.LabelControl3)
        Me.PanelControl3.Controls.Add(Me.LabelControl8)
        Me.PanelControl3.Controls.Add(Me.TETotal)
        Me.PanelControl3.Controls.Add(Me.LabelControl6)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(492, 192)
        Me.PanelControl3.TabIndex = 12
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelControl1.Location = New System.Drawing.Point(18, 69)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(462, 2)
        Me.PanelControl1.TabIndex = 8905
        '
        'TEVATValue
        '
        Me.TEVATValue.EditValue = ""
        Me.TEVATValue.Location = New System.Drawing.Point(279, 134)
        Me.TEVATValue.Name = "TEVATValue"
        Me.TEVATValue.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.TEVATValue.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEVATValue.Properties.DisplayFormat.FormatString = "N2"
        Me.TEVATValue.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TEVATValue.Properties.EditValueChangedDelay = 1
        Me.TEVATValue.Properties.ReadOnly = True
        Me.TEVATValue.Size = New System.Drawing.Size(199, 20)
        Me.TEVATValue.TabIndex = 8904
        Me.TEVATValue.TabStop = False
        '
        'LabelControl23
        '
        Me.LabelControl23.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl23.Location = New System.Drawing.Point(262, 137)
        Me.LabelControl23.Name = "LabelControl23"
        Me.LabelControl23.Size = New System.Drawing.Size(11, 13)
        Me.LabelControl23.TabIndex = 8903
        Me.LabelControl23.Text = "%"
        '
        'TEVATPercent
        '
        Me.TEVATPercent.EditValue = ""
        Me.TEVATPercent.Location = New System.Drawing.Point(204, 134)
        Me.TEVATPercent.Name = "TEVATPercent"
        Me.TEVATPercent.Properties.Appearance.Options.UseTextOptions = True
        Me.TEVATPercent.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEVATPercent.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.TEVATPercent.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEVATPercent.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.TEVATPercent.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEVATPercent.Properties.DisplayFormat.FormatString = "N2"
        Me.TEVATPercent.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TEVATPercent.Properties.EditValueChangedDelay = 1
        Me.TEVATPercent.Properties.Mask.EditMask = "N2"
        Me.TEVATPercent.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEVATPercent.Properties.ReadOnly = True
        Me.TEVATPercent.Size = New System.Drawing.Size(50, 20)
        Me.TEVATPercent.TabIndex = 8902
        Me.TEVATPercent.TabStop = False
        '
        'LabelControl22
        '
        Me.LabelControl22.Location = New System.Drawing.Point(179, 137)
        Me.LabelControl22.Name = "LabelControl22"
        Me.LabelControl22.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl22.TabIndex = 8901
        Me.LabelControl22.Text = "VAT"
        '
        'LabelControl15
        '
        Me.LabelControl15.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl15.Location = New System.Drawing.Point(262, 111)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(11, 13)
        Me.LabelControl15.TabIndex = 8900
        Me.LabelControl15.Text = "%"
        '
        'TEDiscTotal
        '
        Me.TEDiscTotal.EditValue = ""
        Me.TEDiscTotal.Location = New System.Drawing.Point(279, 108)
        Me.TEDiscTotal.Name = "TEDiscTotal"
        Me.TEDiscTotal.Properties.Appearance.Options.UseTextOptions = True
        Me.TEDiscTotal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEDiscTotal.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.TEDiscTotal.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEDiscTotal.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.TEDiscTotal.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEDiscTotal.Properties.DisplayFormat.FormatString = "N2"
        Me.TEDiscTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TEDiscTotal.Properties.EditValueChangedDelay = 1
        Me.TEDiscTotal.Properties.Mask.EditMask = "N2"
        Me.TEDiscTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEDiscTotal.Properties.ReadOnly = True
        Me.TEDiscTotal.Size = New System.Drawing.Size(199, 20)
        Me.TEDiscTotal.TabIndex = 150
        Me.TEDiscTotal.TabStop = False
        '
        'TEGrandTotal
        '
        Me.TEGrandTotal.EditValue = ""
        Me.TEGrandTotal.Location = New System.Drawing.Point(204, 160)
        Me.TEGrandTotal.Name = "TEGrandTotal"
        Me.TEGrandTotal.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.TEGrandTotal.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEGrandTotal.Properties.DisplayFormat.FormatString = "N2"
        Me.TEGrandTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TEGrandTotal.Properties.EditValueChangedDelay = 1
        Me.TEGrandTotal.Properties.ReadOnly = True
        Me.TEGrandTotal.Size = New System.Drawing.Size(274, 20)
        Me.TEGrandTotal.TabIndex = 149
        Me.TEGrandTotal.TabStop = False
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(142, 163)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl9.TabIndex = 148
        Me.LabelControl9.Text = "Grand Total"
        '
        'TEDiscPercent
        '
        Me.TEDiscPercent.EditValue = ""
        Me.TEDiscPercent.Location = New System.Drawing.Point(204, 108)
        Me.TEDiscPercent.Name = "TEDiscPercent"
        Me.TEDiscPercent.Properties.Appearance.Options.UseTextOptions = True
        Me.TEDiscPercent.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEDiscPercent.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.TEDiscPercent.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEDiscPercent.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.TEDiscPercent.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEDiscPercent.Properties.DisplayFormat.FormatString = "N2"
        Me.TEDiscPercent.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TEDiscPercent.Properties.EditValueChangedDelay = 1
        Me.TEDiscPercent.Properties.Mask.EditMask = "N2"
        Me.TEDiscPercent.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEDiscPercent.Properties.ReadOnly = True
        Me.TEDiscPercent.Size = New System.Drawing.Size(50, 20)
        Me.TEDiscPercent.TabIndex = 147
        Me.TEDiscPercent.TabStop = False
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(157, 111)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl8.TabIndex = 146
        Me.LabelControl8.Text = "Discount"
        '
        'TETotal
        '
        Me.TETotal.EditValue = ""
        Me.TETotal.Location = New System.Drawing.Point(204, 82)
        Me.TETotal.Name = "TETotal"
        Me.TETotal.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.TETotal.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TETotal.Properties.DisplayFormat.FormatString = "N2"
        Me.TETotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TETotal.Properties.EditValueChangedDelay = 1
        Me.TETotal.Properties.ReadOnly = True
        Me.TETotal.Size = New System.Drawing.Size(274, 20)
        Me.TETotal.TabIndex = 145
        Me.TETotal.TabStop = False
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(174, 85)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl6.TabIndex = 144
        Me.LabelControl6.Text = "Total"
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.SimpleButtonSet)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl4.Location = New System.Drawing.Point(0, 437)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(492, 38)
        Me.PanelControl4.TabIndex = 11
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Amount"
        Me.GridColumn2.DisplayFormat.FormatString = "N2"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn2.FieldName = "amount"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.OptionsColumn.ReadOnly = True
        Me.GridColumn2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N2}")})
        Me.GridColumn2.UnboundExpression = "[qty_po] * [val_po]"
        Me.GridColumn2.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 3
        '
        'FormBankWithdrawalAttachement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 475)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.PanelControl4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormBankWithdrawalAttachement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Attachment, Due Date & Pph"
        CType(Me.DateEditDueDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditDueDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEditVendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEditPONumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GCPurcReq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPurcReq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEditPph, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEVATValue.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEVATPercent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDiscTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEGrandTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDiscPercent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TETotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SimpleButtonAttachment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DateEditDueDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButtonSet As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEditVendor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEditPONumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCPurcReq As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPurcReq As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn33 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEditPph As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TEVATValue As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl23 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEVATPercent As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl22 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEDiscTotal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEGrandTotal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEDiscPercent As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TETotal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
End Class
