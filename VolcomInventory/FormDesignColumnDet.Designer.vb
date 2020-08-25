<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDesignColumnDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDesignColumnDet))
        Me.TEColumnName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.CEIsLookUp = New DevExpress.XtraEditors.CheckEdit()
        Me.SBSave = New DevExpress.XtraEditors.SimpleButton()
        Me.SBClose = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TECategory = New DevExpress.XtraEditors.TextEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SLUEDependency = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.TEColumnName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CEIsLookUp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECategory.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLUEDependency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TEColumnName
        '
        Me.TEColumnName.Location = New System.Drawing.Point(12, 138)
        Me.TEColumnName.Name = "TEColumnName"
        Me.TEColumnName.Size = New System.Drawing.Size(360, 20)
        Me.TEColumnName.TabIndex = 3
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 119)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Column Name"
        '
        'CEIsLookUp
        '
        Me.CEIsLookUp.EditValue = True
        Me.CEIsLookUp.Location = New System.Drawing.Point(12, 175)
        Me.CEIsLookUp.Name = "CEIsLookUp"
        Me.CEIsLookUp.Properties.Caption = "Is Look Up"
        Me.CEIsLookUp.Size = New System.Drawing.Size(75, 19)
        Me.CEIsLookUp.TabIndex = 4
        '
        'SBSave
        '
        Me.SBSave.Image = CType(resources.GetObject("SBSave.Image"), System.Drawing.Image)
        Me.SBSave.Location = New System.Drawing.Point(297, 215)
        Me.SBSave.Name = "SBSave"
        Me.SBSave.Size = New System.Drawing.Size(75, 23)
        Me.SBSave.TabIndex = 5
        Me.SBSave.Text = "Save"
        '
        'SBClose
        '
        Me.SBClose.Image = CType(resources.GetObject("SBClose.Image"), System.Drawing.Image)
        Me.SBClose.Location = New System.Drawing.Point(216, 215)
        Me.SBClose.Name = "SBClose"
        Me.SBClose.Size = New System.Drawing.Size(75, 23)
        Me.SBClose.TabIndex = 6
        Me.SBClose.Text = "Close"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 18)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl2.TabIndex = 7
        Me.LabelControl2.Text = "Category"
        '
        'TECategory
        '
        Me.TECategory.Location = New System.Drawing.Point(12, 37)
        Me.TECategory.Name = "TECategory"
        Me.TECategory.Properties.ReadOnly = True
        Me.TECategory.Size = New System.Drawing.Size(360, 20)
        Me.TECategory.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Column Dependency"
        '
        'SLUEDependency
        '
        Me.SLUEDependency.Location = New System.Drawing.Point(12, 88)
        Me.SLUEDependency.Name = "SLUEDependency"
        Me.SLUEDependency.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUEDependency.Properties.View = Me.SearchLookUpEdit1View
        Me.SLUEDependency.Size = New System.Drawing.Size(360, 20)
        Me.SLUEDependency.TabIndex = 10
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "GridColumn1"
        Me.GridColumn1.FieldName = "id_design_column"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Column Name"
        Me.GridColumn2.FieldName = "column_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'FormDesignColumnDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 250)
        Me.Controls.Add(Me.SLUEDependency)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.TECategory)
        Me.Controls.Add(Me.SBClose)
        Me.Controls.Add(Me.SBSave)
        Me.Controls.Add(Me.CEIsLookUp)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.TEColumnName)
        Me.Name = "FormDesignColumnDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Design Column Detail"
        CType(Me.TEColumnName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CEIsLookUp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECategory.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLUEDependency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TEColumnName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CEIsLookUp As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents SBSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TECategory As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents SLUEDependency As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
End Class
