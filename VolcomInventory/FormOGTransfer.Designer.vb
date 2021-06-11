<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOGTransfer
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
        Me.GCOGTransfer = New DevExpress.XtraGrid.GridControl()
        Me.GVOGTransfer = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.GCOGTransfer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVOGTransfer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCOGTransfer
        '
        Me.GCOGTransfer.Location = New System.Drawing.Point(139, 213)
        Me.GCOGTransfer.MainView = Me.GVOGTransfer
        Me.GCOGTransfer.Name = "GCOGTransfer"
        Me.GCOGTransfer.Size = New System.Drawing.Size(400, 200)
        Me.GCOGTransfer.TabIndex = 0
        Me.GCOGTransfer.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVOGTransfer})
        '
        'GVOGTransfer
        '
        Me.GVOGTransfer.GridControl = Me.GCOGTransfer
        Me.GVOGTransfer.Name = "GVOGTransfer"
        '
        'FormOGTransfer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 437)
        Me.Controls.Add(Me.GCOGTransfer)
        Me.Name = "FormOGTransfer"
        Me.Text = "FormOGTransfer"
        CType(Me.GCOGTransfer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVOGTransfer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCOGTransfer As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVOGTransfer As DevExpress.XtraGrid.Views.Grid.GridView
End Class
