<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPaymentMissing
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
        Me.GridControlMissing = New DevExpress.XtraGrid.GridControl()
        Me.GridViewMissing = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.GridControlMissing, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewMissing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControlMissing
        '
        Me.GridControlMissing.Location = New System.Drawing.Point(389, 243)
        Me.GridControlMissing.MainView = Me.GridViewMissing
        Me.GridControlMissing.Name = "GridControlMissing"
        Me.GridControlMissing.Size = New System.Drawing.Size(400, 200)
        Me.GridControlMissing.TabIndex = 0
        Me.GridControlMissing.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewMissing})
        '
        'GridViewMissing
        '
        Me.GridViewMissing.GridControl = Me.GridControlMissing
        Me.GridViewMissing.Name = "GridViewMissing"
        '
        'FormPaymentMissing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.GridControlMissing)
        Me.Name = "FormPaymentMissing"
        Me.Text = "Pembayaran Tabungan Missing"
        CType(Me.GridControlMissing, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewMissing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GridControlMissing As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewMissing As DevExpress.XtraGrid.Views.Grid.GridView
End Class
