<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterSampleNR
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
        Me.LEStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.BStatusNR = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.LEStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LEStatus
        '
        Me.LEStatus.Location = New System.Drawing.Point(63, 12)
        Me.LEStatus.Name = "LEStatus"
        Me.LEStatus.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.LEStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEStatus.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_status_nr", "ID STATUS", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Center), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("status_nr", "Status", 20, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Center)})
        Me.LEStatus.Properties.NullText = ""
        Me.LEStatus.Properties.ShowFooter = False
        Me.LEStatus.Size = New System.Drawing.Size(254, 20)
        Me.LEStatus.TabIndex = 103
        '
        'LabelControl13
        '
        Me.LabelControl13.Location = New System.Drawing.Point(12, 15)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl13.TabIndex = 102
        Me.LabelControl13.Text = "Status"
        '
        'BStatusNR
        '
        Me.BStatusNR.ImageIndex = 14
        Me.BStatusNR.Location = New System.Drawing.Point(323, 8)
        Me.BStatusNR.Name = "BStatusNR"
        Me.BStatusNR.Size = New System.Drawing.Size(73, 26)
        Me.BStatusNR.TabIndex = 110
        Me.BStatusNR.Text = "Set"
        '
        'FormMasterSampleNR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(410, 46)
        Me.Controls.Add(Me.BStatusNR)
        Me.Controls.Add(Me.LEStatus)
        Me.Controls.Add(Me.LabelControl13)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterSampleNR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sample Normal / Reject"
        CType(Me.LEStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LEStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BStatusNR As DevExpress.XtraEditors.SimpleButton
End Class
