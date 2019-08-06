<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormItemCatProposeAdd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormItemCatProposeAdd))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LEExpenseType = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtCat = New DevExpress.XtraEditors.TextEdit()
        Me.TxtCatEn = New DevExpress.XtraEditors.TextEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BTnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SLEMainCategory = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.LEExpenseType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCatEn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEMainCategory.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Expense Type"
        '
        'LEExpenseType
        '
        Me.LEExpenseType.Enabled = False
        Me.LEExpenseType.Location = New System.Drawing.Point(104, 38)
        Me.LEExpenseType.Name = "LEExpenseType"
        Me.LEExpenseType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEExpenseType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_expense_type", "Id", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("expense_type", "Type")})
        Me.LEExpenseType.Size = New System.Drawing.Size(260, 20)
        Me.LEExpenseType.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Category"
        '
        'TxtCat
        '
        Me.TxtCat.Location = New System.Drawing.Point(104, 64)
        Me.TxtCat.Name = "TxtCat"
        Me.TxtCat.Size = New System.Drawing.Size(260, 20)
        Me.TxtCat.TabIndex = 3
        '
        'TxtCatEn
        '
        Me.TxtCatEn.Location = New System.Drawing.Point(133, 168)
        Me.TxtCatEn.Name = "TxtCatEn"
        Me.TxtCatEn.Size = New System.Drawing.Size(231, 20)
        Me.TxtCatEn.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 171)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Category (english)"
        '
        'BTnOK
        '
        Me.BTnOK.Image = CType(resources.GetObject("BTnOK.Image"), System.Drawing.Image)
        Me.BTnOK.Location = New System.Drawing.Point(289, 90)
        Me.BTnOK.Name = "BTnOK"
        Me.BTnOK.Size = New System.Drawing.Size(75, 36)
        Me.BTnOK.TabIndex = 6
        Me.BTnOK.Text = "OK"
        '
        'BtnCancel
        '
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(195, 90)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(88, 36)
        Me.BtnCancel.TabIndex = 7
        Me.BtnCancel.Text = "Cancel"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Main Category"
        '
        'SLEMainCategory
        '
        Me.SLEMainCategory.Location = New System.Drawing.Point(104, 12)
        Me.SLEMainCategory.Name = "SLEMainCategory"
        Me.SLEMainCategory.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEMainCategory.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEMainCategory.Size = New System.Drawing.Size(260, 20)
        Me.SLEMainCategory.TabIndex = 9
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn4, Me.GridColumn3})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "id_item_cat_main"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Main Category"
        Me.GridColumn2.FieldName = "item_cat_main"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "ID Expense Type"
        Me.GridColumn4.FieldName = "id_expense_type"
        Me.GridColumn4.Name = "GridColumn4"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Expense Type"
        Me.GridColumn3.FieldName = "expense_type"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'FormItemCatProposeAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(383, 141)
        Me.Controls.Add(Me.SLEMainCategory)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BTnOK)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtCatEn)
        Me.Controls.Add(Me.TxtCat)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LEExpenseType)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormItemCatProposeAdd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add"
        CType(Me.LEExpenseType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCatEn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEMainCategory.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents LEExpenseType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtCat As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtCatEn As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents BTnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label4 As Label
    Friend WithEvents SLEMainCategory As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
End Class
