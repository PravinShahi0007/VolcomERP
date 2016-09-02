<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpFPFaceNew
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
        Me.lvFace = New System.Windows.Forms.ListView()
        Me.columnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'lvFace
        '
        Me.lvFace.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader7, Me.columnHeader8, Me.columnHeader9, Me.columnHeader10, Me.columnHeader11, Me.columnHeader12, Me.columnHeader13, Me.columnHeader14})
        Me.lvFace.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvFace.GridLines = True
        Me.lvFace.Location = New System.Drawing.Point(0, 0)
        Me.lvFace.Name = "lvFace"
        Me.lvFace.Size = New System.Drawing.Size(646, 317)
        Me.lvFace.TabIndex = 69
        Me.lvFace.UseCompatibleStateImageBehavior = False
        Me.lvFace.View = System.Windows.Forms.View.Details
        '
        'columnHeader7
        '
        Me.columnHeader7.Text = "UserID"
        '
        'columnHeader8
        '
        Me.columnHeader8.Text = "Name"
        '
        'columnHeader9
        '
        Me.columnHeader9.Text = "Password"
        '
        'columnHeader10
        '
        Me.columnHeader10.Text = "Privilege"
        '
        'columnHeader11
        '
        Me.columnHeader11.Text = "FaceIndex"
        Me.columnHeader11.Width = 96
        '
        'columnHeader12
        '
        Me.columnHeader12.Text = "TmpData"
        '
        'columnHeader13
        '
        Me.columnHeader13.Text = "Length"
        Me.columnHeader13.Width = 40
        '
        'columnHeader14
        '
        Me.columnHeader14.Text = "Enabled"
        '
        'FormEmpFPFaceNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(646, 317)
        Me.Controls.Add(Me.lvFace)
        Me.Name = "FormEmpFPFaceNew"
        Me.Text = "FormEmpFPFaceNew"
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents lvFace As ListView
    Private WithEvents columnHeader7 As ColumnHeader
    Private WithEvents columnHeader8 As ColumnHeader
    Private WithEvents columnHeader9 As ColumnHeader
    Private WithEvents columnHeader10 As ColumnHeader
    Private WithEvents columnHeader11 As ColumnHeader
    Private WithEvents columnHeader12 As ColumnHeader
    Private WithEvents columnHeader13 As ColumnHeader
    Private WithEvents columnHeader14 As ColumnHeader
End Class
