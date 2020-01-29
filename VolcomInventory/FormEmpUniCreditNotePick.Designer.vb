<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpUniCreditNotePick
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpUniCreditNotePick))
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPeriodFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPeriodUntil = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnItemCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDept = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCFilter = New DevExpress.XtraEditors.GroupControl()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.GCAction = New DevExpress.XtraEditors.GroupControl()
        Me.SBPick = New DevExpress.XtraEditors.SimpleButton()
        Me.SBClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCFilter.SuspendLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCAction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCAction.SuspendLayout()
        Me.SuspendLayout()
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 39)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(784, 483)
        Me.GCData.TabIndex = 9
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.GridColumn1, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumnPeriodFrom, Me.GridColumnPeriodUntil, Me.GridColumnItemCat, Me.GridColumnDept})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "id"
        Me.GridColumn2.FieldName = "id_emp_uni_ex"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Number"
        Me.GridColumn1.FieldName = "emp_uni_ex_number"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Delivery#"
        Me.GridColumn3.FieldName = "pl_sales_order_del_number"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Account"
        Me.GridColumn4.FieldName = "comp"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Created Date"
        Me.GridColumn5.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn5.FieldName = "emp_uni_ex_date"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 7
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Status"
        Me.GridColumn6.FieldName = "report_status"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 8
        '
        'GridColumnPeriodFrom
        '
        Me.GridColumnPeriodFrom.Caption = "Period From"
        Me.GridColumnPeriodFrom.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnPeriodFrom.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnPeriodFrom.FieldName = "period_from"
        Me.GridColumnPeriodFrom.Name = "GridColumnPeriodFrom"
        Me.GridColumnPeriodFrom.Visible = True
        Me.GridColumnPeriodFrom.VisibleIndex = 5
        '
        'GridColumnPeriodUntil
        '
        Me.GridColumnPeriodUntil.Caption = "Period Until"
        Me.GridColumnPeriodUntil.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnPeriodUntil.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnPeriodUntil.FieldName = "period_until"
        Me.GridColumnPeriodUntil.Name = "GridColumnPeriodUntil"
        Me.GridColumnPeriodUntil.Visible = True
        Me.GridColumnPeriodUntil.VisibleIndex = 6
        '
        'GridColumnItemCat
        '
        Me.GridColumnItemCat.Caption = "Category"
        Me.GridColumnItemCat.FieldName = "item_cat"
        Me.GridColumnItemCat.Name = "GridColumnItemCat"
        Me.GridColumnItemCat.Visible = True
        Me.GridColumnItemCat.VisibleIndex = 3
        '
        'GridColumnDept
        '
        Me.GridColumnDept.Caption = "Departement"
        Me.GridColumnDept.FieldName = "departement"
        Me.GridColumnDept.Name = "GridColumnDept"
        Me.GridColumnDept.Visible = True
        Me.GridColumnDept.VisibleIndex = 4
        '
        'GCFilter
        '
        Me.GCFilter.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GCFilter.Controls.Add(Me.BtnView)
        Me.GCFilter.Controls.Add(Me.DEUntil)
        Me.GCFilter.Controls.Add(Me.DEFrom)
        Me.GCFilter.Controls.Add(Me.LabelControl2)
        Me.GCFilter.Controls.Add(Me.LabelControl3)
        Me.GCFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.GCFilter.Location = New System.Drawing.Point(0, 0)
        Me.GCFilter.Name = "GCFilter"
        Me.GCFilter.Size = New System.Drawing.Size(784, 39)
        Me.GCFilter.TabIndex = 8
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(272, 9)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Size = New System.Drawing.Size(150, 20)
        Me.DEUntil.TabIndex = 8895
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(63, 9)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Size = New System.Drawing.Size(150, 20)
        Me.DEFrom.TabIndex = 8894
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(239, 12)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl2.TabIndex = 8893
        Me.LabelControl2.Text = "Until"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(28, 12)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl3.TabIndex = 8892
        Me.LabelControl3.Text = "From"
        '
        'GCAction
        '
        Me.GCAction.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GCAction.Controls.Add(Me.SBClose)
        Me.GCAction.Controls.Add(Me.SBPick)
        Me.GCAction.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GCAction.Location = New System.Drawing.Point(0, 522)
        Me.GCAction.Name = "GCAction"
        Me.GCAction.Size = New System.Drawing.Size(784, 39)
        Me.GCAction.TabIndex = 10
        '
        'SBPick
        '
        Me.SBPick.Image = CType(resources.GetObject("SBPick.Image"), System.Drawing.Image)
        Me.SBPick.Location = New System.Drawing.Point(706, 8)
        Me.SBPick.Name = "SBPick"
        Me.SBPick.Size = New System.Drawing.Size(66, 23)
        Me.SBPick.TabIndex = 0
        Me.SBPick.Text = "Pick"
        '
        'SBClose
        '
        Me.SBClose.Image = CType(resources.GetObject("SBClose.Image"), System.Drawing.Image)
        Me.SBClose.Location = New System.Drawing.Point(634, 8)
        Me.SBClose.Name = "SBClose"
        Me.SBClose.Size = New System.Drawing.Size(66, 23)
        Me.SBClose.TabIndex = 1
        Me.SBClose.Text = "Close"
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(433, 9)
        Me.BtnView.LookAndFeel.SkinName = "Blue"
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(63, 20)
        Me.BtnView.TabIndex = 8896
        Me.BtnView.Text = "View"
        '
        'FormEmpUniCreditNotePick
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.GCAction)
        Me.Controls.Add(Me.GCFilter)
        Me.Name = "FormEmpUniCreditNotePick"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Credit Note Pick"
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GCFilter.ResumeLayout(False)
        Me.GCFilter.PerformLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCAction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GCAction.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPeriodFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPeriodUntil As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnItemCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDept As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCFilter As DevExpress.XtraEditors.GroupControl
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCAction As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SBClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBPick As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
End Class
