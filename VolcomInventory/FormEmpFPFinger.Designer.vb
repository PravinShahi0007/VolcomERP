<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpFPFinger
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
        Me.lvDownload = New System.Windows.Forms.ListView()
        Me.ch1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'lvDownload
        '
        Me.lvDownload.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ch1, Me.ch2, Me.ch3, Me.ch4, Me.ch5, Me.ch6, Me.ch7, Me.ch8})
        Me.lvDownload.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvDownload.GridLines = True
        Me.lvDownload.Location = New System.Drawing.Point(0, 0)
        Me.lvDownload.Name = "lvDownload"
        Me.lvDownload.Size = New System.Drawing.Size(542, 289)
        Me.lvDownload.TabIndex = 1
        Me.lvDownload.UseCompatibleStateImageBehavior = False
        Me.lvDownload.View = System.Windows.Forms.View.Details
        '
        'ch1
        '
        Me.ch1.Text = "UserID"
        Me.ch1.Width = 54
        '
        'ch2
        '
        Me.ch2.Text = "Name"
        Me.ch2.Width = 41
        '
        'ch3
        '
        Me.ch3.Text = "FingerIndex"
        Me.ch3.Width = 52
        '
        'ch4
        '
        Me.ch4.Text = "tmpData"
        Me.ch4.Width = 72
        '
        'ch5
        '
        Me.ch5.Text = "Privilege"
        Me.ch5.Width = 77
        '
        'ch6
        '
        Me.ch6.Text = "Password"
        Me.ch6.Width = 40
        '
        'ch7
        '
        Me.ch7.Text = "Ennabled"
        Me.ch7.Width = 81
        '
        'ch8
        '
        Me.ch8.Text = "Flag"
        '
        'FormEmpFPFinger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 289)
        Me.Controls.Add(Me.lvDownload)
        Me.Name = "FormEmpFPFinger"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormEmpFPFinger"
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents lvDownload As ListView
    Private WithEvents ch1 As ColumnHeader
    Private WithEvents ch2 As ColumnHeader
    Private WithEvents ch3 As ColumnHeader
    Private WithEvents ch4 As ColumnHeader
    Private WithEvents ch5 As ColumnHeader
    Private WithEvents ch6 As ColumnHeader
    Private WithEvents ch7 As ColumnHeader
    Friend WithEvents ch8 As ColumnHeader
End Class
