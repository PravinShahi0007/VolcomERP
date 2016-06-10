<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormChangeStatus
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
        Me.SLEStatusRec = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnUpdateRec = New DevExpress.XtraEditors.SimpleButton()
        Me.PBC = New DevExpress.XtraEditors.ProgressBarControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.MEComment = New DevExpress.XtraEditors.MemoEdit()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.SLEStatusRec.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBC.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEComment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SLEStatusRec
        '
        Me.SLEStatusRec.Location = New System.Drawing.Point(76, 16)
        Me.SLEStatusRec.Name = "SLEStatusRec"
        Me.SLEStatusRec.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEStatusRec.Properties.ShowClearButton = False
        Me.SLEStatusRec.Properties.View = Me.GridView4
        Me.SLEStatusRec.Size = New System.Drawing.Size(311, 20)
        Me.SLEStatusRec.TabIndex = 1
        '
        'GridView4
        '
        Me.GridView4.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn13, Me.GridColumn14})
        Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView4.OptionsView.ShowGroupPanel = False
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(14, 19)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl7.TabIndex = 8901
        Me.LabelControl7.Text = "Status"
        '
        'BtnUpdateRec
        '
        Me.BtnUpdateRec.Location = New System.Drawing.Point(303, 144)
        Me.BtnUpdateRec.LookAndFeel.SkinName = "Blue"
        Me.BtnUpdateRec.Name = "BtnUpdateRec"
        Me.BtnUpdateRec.Size = New System.Drawing.Size(84, 27)
        Me.BtnUpdateRec.TabIndex = 3
        Me.BtnUpdateRec.Text = "Update Status"
        '
        'PBC
        '
        Me.PBC.Dock = System.Windows.Forms.DockStyle.Top
        Me.PBC.Location = New System.Drawing.Point(0, 0)
        Me.PBC.Name = "PBC"
        Me.PBC.Size = New System.Drawing.Size(408, 6)
        Me.PBC.TabIndex = 8902
        Me.PBC.Visible = False
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(14, 44)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl2.TabIndex = 8904
        Me.LabelControl2.Text = "Comment"
        '
        'MEComment
        '
        Me.MEComment.Location = New System.Drawing.Point(76, 42)
        Me.MEComment.Name = "MEComment"
        Me.MEComment.Size = New System.Drawing.Size(311, 96)
        Me.MEComment.TabIndex = 2
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Id Report Status"
        Me.GridColumn13.FieldName = "id_report_status"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Status"
        Me.GridColumn14.FieldName = "report_status"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 0
        '
        'FormChangeStatus
        '
        Me.AcceptButton = Me.BtnUpdateRec
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 182)
        Me.Controls.Add(Me.MEComment)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.PBC)
        Me.Controls.Add(Me.BtnUpdateRec)
        Me.Controls.Add(Me.SLEStatusRec)
        Me.Controls.Add(Me.LabelControl7)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormChangeStatus"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change Status"
        CType(Me.SLEStatusRec.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBC.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEComment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SLEStatusRec As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnUpdateRec As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PBC As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MEComment As DevExpress.XtraEditors.MemoEdit
End Class
