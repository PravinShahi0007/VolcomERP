<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSampleBudgetSingle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSampleBudgetSingle))
        Me.DEYearBudget = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TEDescription = New DevExpress.XtraEditors.TextEdit()
        Me.GCDivision = New DevExpress.XtraGrid.GridControl()
        Me.GVDivision = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TEBudgetKurs = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TEBudgetUSD = New DevExpress.XtraEditors.TextEdit()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.TEBudgetRp = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TEBudgetinRP = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.DEYearBudget.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEYearBudget.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCDivision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDivision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEBudgetKurs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEBudgetUSD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TEBudgetRp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEBudgetinRP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DEYearBudget
        '
        Me.DEYearBudget.EditValue = Nothing
        Me.DEYearBudget.Location = New System.Drawing.Point(130, 37)
        Me.DEYearBudget.Name = "DEYearBudget"
        Me.DEYearBudget.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEYearBudget.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEYearBudget.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
        Me.DEYearBudget.Properties.DisplayFormat.FormatString = "yyyy"
        Me.DEYearBudget.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEYearBudget.Properties.Mask.EditMask = "yyyy"
        Me.DEYearBudget.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DEYearBudget.Properties.ReadOnly = True
        Me.DEYearBudget.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearsGroupView
        Me.DEYearBudget.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView
        Me.DEYearBudget.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.DEYearBudget.Size = New System.Drawing.Size(205, 20)
        Me.DEYearBudget.TabIndex = 8907
        Me.DEYearBudget.TabStop = False
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(12, 40)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl6.TabIndex = 8906
        Me.LabelControl6.Text = "Year Budget"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl1.TabIndex = 8908
        Me.LabelControl1.Text = "Description"
        '
        'TEDescription
        '
        Me.TEDescription.Location = New System.Drawing.Point(130, 9)
        Me.TEDescription.Name = "TEDescription"
        Me.TEDescription.Size = New System.Drawing.Size(461, 20)
        Me.TEDescription.TabIndex = 1
        '
        'GCDivision
        '
        Me.GCDivision.Location = New System.Drawing.Point(130, 63)
        Me.GCDivision.MainView = Me.GVDivision
        Me.GCDivision.Name = "GCDivision"
        Me.GCDivision.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCDivision.Size = New System.Drawing.Size(461, 200)
        Me.GCDivision.TabIndex = 8910
        Me.GCDivision.TabStop = False
        Me.GCDivision.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDivision})
        '
        'GVDivision
        '
        Me.GVDivision.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3})
        Me.GVDivision.GridControl = Me.GCDivision
        Me.GVDivision.Name = "GVDivision"
        Me.GVDivision.OptionsBehavior.Editable = False
        Me.GVDivision.OptionsBehavior.ReadOnly = True
        Me.GVDivision.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.Caption = "*"
        Me.GridColumn1.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumn1.FieldName = "is_check"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 43
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "no"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Division"
        Me.GridColumn2.FieldName = "code_detail_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 363
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Id"
        Me.GridColumn3.FieldName = "id_code_detail"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'TEBudgetKurs
        '
        Me.TEBudgetKurs.EditValue = ""
        Me.TEBudgetKurs.Location = New System.Drawing.Point(130, 295)
        Me.TEBudgetKurs.Name = "TEBudgetKurs"
        Me.TEBudgetKurs.Properties.Appearance.Options.UseTextOptions = True
        Me.TEBudgetKurs.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEBudgetKurs.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.TEBudgetKurs.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEBudgetKurs.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.TEBudgetKurs.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEBudgetKurs.Properties.DisplayFormat.FormatString = "N2"
        Me.TEBudgetKurs.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TEBudgetKurs.Properties.EditValueChangedDelay = 1
        Me.TEBudgetKurs.Properties.Mask.EditMask = "N2"
        Me.TEBudgetKurs.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEBudgetKurs.Size = New System.Drawing.Size(205, 20)
        Me.TEBudgetKurs.TabIndex = 3
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(15, 298)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl2.TabIndex = 8912
        Me.LabelControl2.Text = "Kurs"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(15, 272)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(57, 13)
        Me.LabelControl3.TabIndex = 8913
        Me.LabelControl3.Text = "Budget USD"
        '
        'TEBudgetUSD
        '
        Me.TEBudgetUSD.EditValue = ""
        Me.TEBudgetUSD.Location = New System.Drawing.Point(130, 269)
        Me.TEBudgetUSD.Name = "TEBudgetUSD"
        Me.TEBudgetUSD.Properties.Appearance.Options.UseTextOptions = True
        Me.TEBudgetUSD.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEBudgetUSD.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.TEBudgetUSD.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEBudgetUSD.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.TEBudgetUSD.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEBudgetUSD.Properties.DisplayFormat.FormatString = "N2"
        Me.TEBudgetUSD.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TEBudgetUSD.Properties.EditValueChangedDelay = 1
        Me.TEBudgetUSD.Properties.Mask.EditMask = "N2"
        Me.TEBudgetUSD.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEBudgetUSD.Size = New System.Drawing.Size(205, 20)
        Me.TEBudgetUSD.TabIndex = 2
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "20_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "8_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "23_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(3, "arrow_refresh.png")
        Me.LargeImageCollection.Images.SetKeyName(4, "check_mark.png")
        Me.LargeImageCollection.Images.SetKeyName(5, "gnome_application_exit (1).png")
        Me.LargeImageCollection.Images.SetKeyName(6, "printer_3.png")
        Me.LargeImageCollection.Images.SetKeyName(7, "save.png")
        Me.LargeImageCollection.Images.SetKeyName(8, "31_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(9, "18_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(10, "10_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(11, "18_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(12, "31_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(13, "folder-documents-icon.png")
        Me.LargeImageCollection.Images.SetKeyName(14, "mail_attachment.png")
        Me.LargeImageCollection.Images.SetKeyName(15, "attachment-icon.png")
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Controls.Add(Me.BtnSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 347)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(612, 39)
        Me.PanelControl1.TabIndex = 8915
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.ImageIndex = 5
        Me.BtnCancel.ImageList = Me.LargeImageCollection
        Me.BtnCancel.Location = New System.Drawing.Point(448, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 35)
        Me.BtnCancel.TabIndex = 6
        Me.BtnCancel.Text = "Close"
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.ImageIndex = 4
        Me.BtnSave.ImageList = Me.LargeImageCollection
        Me.BtnSave.Location = New System.Drawing.Point(523, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(87, 35)
        Me.BtnSave.TabIndex = 5
        Me.BtnSave.Text = "Insert"
        '
        'TEBudgetRp
        '
        Me.TEBudgetRp.EditValue = ""
        Me.TEBudgetRp.Location = New System.Drawing.Point(409, 269)
        Me.TEBudgetRp.Name = "TEBudgetRp"
        Me.TEBudgetRp.Properties.Appearance.Options.UseTextOptions = True
        Me.TEBudgetRp.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEBudgetRp.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.TEBudgetRp.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEBudgetRp.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.TEBudgetRp.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEBudgetRp.Properties.DisplayFormat.FormatString = "N2"
        Me.TEBudgetRp.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TEBudgetRp.Properties.EditValueChangedDelay = 1
        Me.TEBudgetRp.Properties.Mask.EditMask = "N2"
        Me.TEBudgetRp.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEBudgetRp.Size = New System.Drawing.Size(182, 20)
        Me.TEBudgetRp.TabIndex = 4
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(353, 272)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl4.TabIndex = 8916
        Me.LabelControl4.Text = "Budget Rp"
        '
        'TEBudgetinRP
        '
        Me.TEBudgetinRP.EditValue = ""
        Me.TEBudgetinRP.Location = New System.Drawing.Point(130, 321)
        Me.TEBudgetinRP.Name = "TEBudgetinRP"
        Me.TEBudgetinRP.Properties.Appearance.Options.UseTextOptions = True
        Me.TEBudgetinRP.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEBudgetinRP.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.TEBudgetinRP.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEBudgetinRP.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.TEBudgetinRP.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEBudgetinRP.Properties.DisplayFormat.FormatString = "N2"
        Me.TEBudgetinRP.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TEBudgetinRP.Properties.EditValueChangedDelay = 1
        Me.TEBudgetinRP.Properties.Mask.EditMask = "N2"
        Me.TEBudgetinRP.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEBudgetinRP.Properties.ReadOnly = True
        Me.TEBudgetinRP.Size = New System.Drawing.Size(205, 20)
        Me.TEBudgetinRP.TabIndex = 8919
        Me.TEBudgetinRP.TabStop = False
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(15, 324)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(109, 13)
        Me.LabelControl5.TabIndex = 8918
        Me.LabelControl5.Text = "Budget USD After Kurs"
        '
        'FormSampleBudgetSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(612, 386)
        Me.Controls.Add(Me.TEBudgetinRP)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.TEBudgetRp)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.TEBudgetKurs)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.TEBudgetUSD)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.GCDivision)
        Me.Controls.Add(Me.TEDescription)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.DEYearBudget)
        Me.Controls.Add(Me.LabelControl6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSampleBudgetSingle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sample Budget"
        CType(Me.DEYearBudget.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEYearBudget.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCDivision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDivision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEBudgetKurs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEBudgetUSD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.TEBudgetRp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEBudgetinRP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DEYearBudget As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEDescription As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GCDivision As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDivision As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TEBudgetKurs As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEBudgetUSD As DevExpress.XtraEditors.TextEdit
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents TEBudgetRp As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEBudgetinRP As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
End Class
