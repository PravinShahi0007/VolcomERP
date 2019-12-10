<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpEmail
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
        Me.GCEmail = New DevExpress.XtraGrid.GridControl()
        Me.GVEmail = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnExtEmail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnExtEmailPass = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLocEmail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLocEmailPass = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOther = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOtherPass = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SLEStatus = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCEmail
        '
        Me.GCEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCEmail.Location = New System.Drawing.Point(0, 40)
        Me.GCEmail.MainView = Me.GVEmail
        Me.GCEmail.Name = "GCEmail"
        Me.GCEmail.Size = New System.Drawing.Size(972, 343)
        Me.GCEmail.TabIndex = 1
        Me.GCEmail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVEmail})
        '
        'GVEmail
        '
        Me.GVEmail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumnExtEmail, Me.GridColumnExtEmailPass, Me.GridColumnLocEmail, Me.GridColumnLocEmailPass, Me.GridColumnOther, Me.GridColumnOtherPass})
        Me.GVEmail.GridControl = Me.GCEmail
        Me.GVEmail.GroupCount = 1
        Me.GVEmail.Name = "GVEmail"
        Me.GVEmail.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVEmail.OptionsBehavior.Editable = False
        Me.GVEmail.OptionsView.ShowGroupPanel = False
        Me.GVEmail.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn2, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Name"
        Me.GridColumn1.FieldName = "employee_name"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Departement"
        Me.GridColumn2.FieldName = "departement"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumnExtEmail
        '
        Me.GridColumnExtEmail.Caption = "External Email"
        Me.GridColumnExtEmail.FieldName = "email_external"
        Me.GridColumnExtEmail.Name = "GridColumnExtEmail"
        Me.GridColumnExtEmail.Visible = True
        Me.GridColumnExtEmail.VisibleIndex = 1
        '
        'GridColumnExtEmailPass
        '
        Me.GridColumnExtEmailPass.Caption = "External Password"
        Me.GridColumnExtEmailPass.FieldName = "email_external_pass"
        Me.GridColumnExtEmailPass.Name = "GridColumnExtEmailPass"
        '
        'GridColumnLocEmail
        '
        Me.GridColumnLocEmail.Caption = "Local Email"
        Me.GridColumnLocEmail.FieldName = "email_lokal"
        Me.GridColumnLocEmail.Name = "GridColumnLocEmail"
        '
        'GridColumnLocEmailPass
        '
        Me.GridColumnLocEmailPass.Caption = "Local Password"
        Me.GridColumnLocEmailPass.FieldName = "email_lokal_pass"
        Me.GridColumnLocEmailPass.Name = "GridColumnLocEmailPass"
        '
        'GridColumnOther
        '
        Me.GridColumnOther.Caption = "Other Email"
        Me.GridColumnOther.FieldName = "email_other"
        Me.GridColumnOther.Name = "GridColumnOther"
        Me.GridColumnOther.Visible = True
        Me.GridColumnOther.VisibleIndex = 2
        '
        'GridColumnOtherPass
        '
        Me.GridColumnOtherPass.Caption = "Other Password"
        Me.GridColumnOtherPass.FieldName = "email_other_pass"
        Me.GridColumnOtherPass.Name = "GridColumnOtherPass"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.BSearch)
        Me.PanelControl1.Controls.Add(Me.SLEStatus)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(972, 40)
        Me.PanelControl1.TabIndex = 2
        '
        'SLEStatus
        '
        Me.SLEStatus.Location = New System.Drawing.Point(100, 12)
        Me.SLEStatus.Name = "SLEStatus"
        Me.SLEStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEStatus.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEStatus.Size = New System.Drawing.Size(229, 20)
        Me.SLEStatus.TabIndex = 0
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn4})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'BSearch
        '
        Me.BSearch.Location = New System.Drawing.Point(335, 10)
        Me.BSearch.Name = "BSearch"
        Me.BSearch.Size = New System.Drawing.Size(60, 23)
        Me.BSearch.TabIndex = 1
        Me.BSearch.Text = "Search"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(82, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Status Karyawan"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "ID Status"
        Me.GridColumn3.FieldName = "id_employee_active"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Status Karyawan"
        Me.GridColumn4.FieldName = "employee_active"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 0
        '
        'FormEmpEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(972, 383)
        Me.Controls.Add(Me.GCEmail)
        Me.Controls.Add(Me.PanelControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpEmail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Email List"
        CType(Me.GCEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLEStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCEmail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVEmail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnExtEmail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnExtEmailPass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLocEmail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLocEmailPass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOther As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOtherPass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLEStatus As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
End Class
