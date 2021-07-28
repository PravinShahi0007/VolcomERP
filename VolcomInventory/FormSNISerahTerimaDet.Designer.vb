<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSNISerahTerimaDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSNISerahTerimaDet))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.DEReffDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.DEProposeDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TENumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TECreatedBy = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BLoad = New DevExpress.XtraEditors.SimpleButton()
        Me.TEBudgetNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.BDel = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BMark = New DevExpress.XtraEditors.SimpleButton()
        Me.BClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.GVList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAttachment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICEAttachment = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DEReffDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEReffDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEProposeDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEProposeDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECreatedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.TEBudgetNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICEAttachment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.DEReffDate)
        Me.PanelControl1.Controls.Add(Me.LabelControl5)
        Me.PanelControl1.Controls.Add(Me.DEProposeDate)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.TENumber)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.TECreatedBy)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(917, 71)
        Me.PanelControl1.TabIndex = 0
        '
        'DEReffDate
        '
        Me.DEReffDate.EditValue = Nothing
        Me.DEReffDate.Location = New System.Drawing.Point(501, 38)
        Me.DEReffDate.Name = "DEReffDate"
        Me.DEReffDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEReffDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEReffDate.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEReffDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEReffDate.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DEReffDate.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DEReffDate.Size = New System.Drawing.Size(266, 20)
        Me.DEReffDate.TabIndex = 27
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(430, 41)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(47, 13)
        Me.LabelControl5.TabIndex = 26
        Me.LabelControl5.Text = "Reff Date"
        '
        'DEProposeDate
        '
        Me.DEProposeDate.EditValue = Nothing
        Me.DEProposeDate.Location = New System.Drawing.Point(501, 12)
        Me.DEProposeDate.Name = "DEProposeDate"
        Me.DEProposeDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEProposeDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEProposeDate.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEProposeDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEProposeDate.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DEProposeDate.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DEProposeDate.Properties.ReadOnly = True
        Me.DEProposeDate.Size = New System.Drawing.Size(266, 20)
        Me.DEProposeDate.TabIndex = 25
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(430, 15)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl3.TabIndex = 5
        Me.LabelControl3.Text = "Created Date"
        '
        'TENumber
        '
        Me.TENumber.Location = New System.Drawing.Point(91, 12)
        Me.TENumber.Name = "TENumber"
        Me.TENumber.Properties.ReadOnly = True
        Me.TENumber.Size = New System.Drawing.Size(333, 20)
        Me.TENumber.TabIndex = 4
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(11, 15)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Number"
        '
        'TECreatedBy
        '
        Me.TECreatedBy.Location = New System.Drawing.Point(91, 38)
        Me.TECreatedBy.Name = "TECreatedBy"
        Me.TECreatedBy.Properties.ReadOnly = True
        Me.TECreatedBy.Size = New System.Drawing.Size(333, 20)
        Me.TECreatedBy.TabIndex = 2
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(11, 41)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Created By"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BLoad)
        Me.PanelControl2.Controls.Add(Me.TEBudgetNumber)
        Me.PanelControl2.Controls.Add(Me.LabelControl4)
        Me.PanelControl2.Controls.Add(Me.BDel)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 71)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(917, 42)
        Me.PanelControl2.TabIndex = 1
        '
        'BLoad
        '
        Me.BLoad.Location = New System.Drawing.Point(368, 9)
        Me.BLoad.Name = "BLoad"
        Me.BLoad.Size = New System.Drawing.Size(56, 23)
        Me.BLoad.TabIndex = 8
        Me.BLoad.Text = "load"
        '
        'TEBudgetNumber
        '
        Me.TEBudgetNumber.Location = New System.Drawing.Point(91, 11)
        Me.TEBudgetNumber.Name = "TEBudgetNumber"
        Me.TEBudgetNumber.Size = New System.Drawing.Size(271, 20)
        Me.TEBudgetNumber.TabIndex = 7
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(11, 14)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(74, 13)
        Me.LabelControl4.TabIndex = 6
        Me.LabelControl4.Text = "Budget Number"
        '
        'BDel
        '
        Me.BDel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BDel.Image = CType(resources.GetObject("BDel.Image"), System.Drawing.Image)
        Me.BDel.Location = New System.Drawing.Point(807, 2)
        Me.BDel.Name = "BDel"
        Me.BDel.Size = New System.Drawing.Size(108, 38)
        Me.BDel.TabIndex = 4
        Me.BDel.Text = "Delete Item"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.BPrint)
        Me.PanelControl3.Controls.Add(Me.BMark)
        Me.PanelControl3.Controls.Add(Me.BClose)
        Me.PanelControl3.Controls.Add(Me.BSave)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 525)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(917, 46)
        Me.PanelControl3.TabIndex = 2
        '
        'BPrint
        '
        Me.BPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BPrint.Image = CType(resources.GetObject("BPrint.Image"), System.Drawing.Image)
        Me.BPrint.Location = New System.Drawing.Point(594, 2)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(94, 42)
        Me.BPrint.TabIndex = 13
        Me.BPrint.Text = "Print"
        '
        'BMark
        '
        Me.BMark.Dock = System.Windows.Forms.DockStyle.Left
        Me.BMark.Image = CType(resources.GetObject("BMark.Image"), System.Drawing.Image)
        Me.BMark.Location = New System.Drawing.Point(2, 2)
        Me.BMark.Name = "BMark"
        Me.BMark.Size = New System.Drawing.Size(96, 42)
        Me.BMark.TabIndex = 12
        Me.BMark.Text = "Mark"
        '
        'BClose
        '
        Me.BClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BClose.Image = CType(resources.GetObject("BClose.Image"), System.Drawing.Image)
        Me.BClose.Location = New System.Drawing.Point(688, 2)
        Me.BClose.Name = "BClose"
        Me.BClose.Size = New System.Drawing.Size(92, 42)
        Me.BClose.TabIndex = 10
        Me.BClose.Text = "Close"
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.Image = CType(resources.GetObject("BSave.Image"), System.Drawing.Image)
        Me.BSave.Location = New System.Drawing.Point(780, 2)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(135, 42)
        Me.BSave.TabIndex = 9
        Me.BSave.Text = "Lock and Submit"
        '
        'GCList
        '
        Me.GCList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCList.Location = New System.Drawing.Point(0, 113)
        Me.GCList.MainView = Me.GVList
        Me.GCList.Name = "GCList"
        Me.GCList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICEAttachment})
        Me.GCList.Size = New System.Drawing.Size(917, 412)
        Me.GCList.TabIndex = 3
        Me.GCList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVList})
        '
        'GVList
        '
        Me.GVList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn8, Me.GridColumn7, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumnAttachment})
        Me.GVList.GridControl = Me.GCList
        Me.GVList.Name = "GVList"
        Me.GVList.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID Det"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.AllowFocus = False
        Me.GridColumn1.OptionsColumn.ReadOnly = True
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Id Product"
        Me.GridColumn2.FieldName = "id_product"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.OptionsColumn.AllowFocus = False
        Me.GridColumn2.OptionsColumn.ReadOnly = True
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "ID PO Det"
        Me.GridColumn8.FieldName = "id_prod_order_det"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.OptionsColumn.AllowFocus = False
        Me.GridColumn8.OptionsColumn.ReadOnly = True
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "FGPO Number"
        Me.GridColumn7.FieldName = "prod_order_number"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.OptionsColumn.AllowFocus = False
        Me.GridColumn7.OptionsColumn.ReadOnly = True
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 0
        Me.GridColumn7.Width = 307
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Code"
        Me.GridColumn3.FieldName = "product_full_code"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.OptionsColumn.AllowFocus = False
        Me.GridColumn3.OptionsColumn.ReadOnly = True
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 302
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Description"
        Me.GridColumn4.FieldName = "design_display_name"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.OptionsColumn.AllowFocus = False
        Me.GridColumn4.OptionsColumn.ReadOnly = True
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        Me.GridColumn4.Width = 415
        '
        'GridColumn5
        '
        Me.GridColumn5.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn5.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn5.Caption = "Size"
        Me.GridColumn5.FieldName = "size"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.OptionsColumn.AllowFocus = False
        Me.GridColumn5.OptionsColumn.ReadOnly = True
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        Me.GridColumn5.Width = 113
        '
        'GridColumn6
        '
        Me.GridColumn6.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn6.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn6.Caption = "Qty"
        Me.GridColumn6.DisplayFormat.FormatString = "N0"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn6.FieldName = "qty"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        Me.GridColumn6.Width = 290
        '
        'GridColumnAttachment
        '
        Me.GridColumnAttachment.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnAttachment.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnAttachment.Caption = "Attachment"
        Me.GridColumnAttachment.ColumnEdit = Me.RICEAttachment
        Me.GridColumnAttachment.FieldName = "is_attach"
        Me.GridColumnAttachment.Name = "GridColumnAttachment"
        Me.GridColumnAttachment.Visible = True
        Me.GridColumnAttachment.VisibleIndex = 5
        Me.GridColumnAttachment.Width = 205
        '
        'RICEAttachment
        '
        Me.RICEAttachment.AutoHeight = False
        Me.RICEAttachment.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
        Me.RICEAttachment.Name = "RICEAttachment"
        Me.RICEAttachment.PictureChecked = CType(resources.GetObject("RICEAttachment.PictureChecked"), System.Drawing.Image)
        Me.RICEAttachment.PictureGrayed = CType(resources.GetObject("RICEAttachment.PictureGrayed"), System.Drawing.Image)
        Me.RICEAttachment.PictureUnchecked = CType(resources.GetObject("RICEAttachment.PictureUnchecked"), System.Drawing.Image)
        Me.RICEAttachment.ValueChecked = "yes"
        Me.RICEAttachment.ValueUnchecked = "no"
        '
        'FormSNISerahTerimaDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(917, 571)
        Me.Controls.Add(Me.GCList)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "FormSNISerahTerimaDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SNI Serah Terima"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.DEReffDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEReffDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEProposeDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEProposeDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECreatedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.TEBudgetNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICEAttachment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TENumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TECreatedBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEProposeDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BDel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAttachment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BLoad As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEBudgetNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RICEAttachment As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents DEReffDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
End Class
