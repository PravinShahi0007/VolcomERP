<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormStockTakeStoreVerCrt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormStockTakeStoreVerCrt))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLUEAccount = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SBNew = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.SLUEAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(17, 17)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(71, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Select Account"
        '
        'SLUEAccount
        '
        Me.SLUEAccount.Location = New System.Drawing.Point(17, 41)
        Me.SLUEAccount.Name = "SLUEAccount"
        Me.SLUEAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUEAccount.Properties.View = Me.GridView1
        Me.SLUEAccount.Size = New System.Drawing.Size(255, 20)
        Me.SLUEAccount.TabIndex = 5
        '
        'GridView1
        '
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'SBNew
        '
        Me.SBNew.Image = CType(resources.GetObject("SBNew.Image"), System.Drawing.Image)
        Me.SBNew.Location = New System.Drawing.Point(172, 67)
        Me.SBNew.Name = "SBNew"
        Me.SBNew.Size = New System.Drawing.Size(100, 35)
        Me.SBNew.TabIndex = 6
        Me.SBNew.Text = "New"
        '
        'FormStockTakeStoreVerCrt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 114)
        Me.Controls.Add(Me.SBNew)
        Me.Controls.Add(Me.SLUEAccount)
        Me.Controls.Add(Me.LabelControl1)
        Me.Name = "FormStockTakeStoreVerCrt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Take Store Verification New"
        CType(Me.SLUEAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLUEAccount As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SBNew As DevExpress.XtraEditors.SimpleButton
End Class
