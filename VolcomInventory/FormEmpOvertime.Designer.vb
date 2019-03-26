<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpOvertime
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
        Me.GCOvertime = New DevExpress.XtraGrid.GridControl()
        Me.GVOvertime = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.GCOvertime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVOvertime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCOvertime
        '
        Me.GCOvertime.Location = New System.Drawing.Point(309, 194)
        Me.GCOvertime.MainView = Me.GVOvertime
        Me.GCOvertime.Name = "GCOvertime"
        Me.GCOvertime.Size = New System.Drawing.Size(400, 200)
        Me.GCOvertime.TabIndex = 0
        Me.GCOvertime.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVOvertime})
        '
        'GVOvertime
        '
        Me.GVOvertime.GridControl = Me.GCOvertime
        Me.GVOvertime.Name = "GVOvertime"
        '
        'FormEmpOvertime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.GCOvertime)
        Me.Name = "FormEmpOvertime"
        Me.Text = "Overtime"
        CType(Me.GCOvertime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVOvertime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCOvertime As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVOvertime As DevExpress.XtraGrid.Views.Grid.GridView
End Class
