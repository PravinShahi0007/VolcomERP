<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFingerPrint
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
        Me.txtIP = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BtnGet = New System.Windows.Forms.Button()
        Me.BtnSet = New System.Windows.Forms.Button()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtIP
        '
        Me.txtIP.Location = New System.Drawing.Point(40, 13)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(95, 21)
        Me.txtIP.TabIndex = 11
        Me.txtIP.Text = "192.168.1.75"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(141, 16)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(27, 13)
        Me.label2.TabIndex = 14
        Me.label2.Text = "Port"
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(233, 11)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(75, 23)
        Me.btnConnect.TabIndex = 10
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(174, 13)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(53, 21)
        Me.txtPort.TabIndex = 12
        Me.txtPort.Text = "4370"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(9, 17)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(17, 13)
        Me.label1.TabIndex = 13
        Me.label1.Text = "IP"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnSet)
        Me.PanelControl1.Controls.Add(Me.BtnGet)
        Me.PanelControl1.Controls.Add(Me.txtIP)
        Me.PanelControl1.Controls.Add(Me.label1)
        Me.PanelControl1.Controls.Add(Me.txtPort)
        Me.PanelControl1.Controls.Add(Me.label2)
        Me.PanelControl1.Controls.Add(Me.btnConnect)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(522, 46)
        Me.PanelControl1.TabIndex = 16
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 46)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(522, 216)
        Me.GridControl1.TabIndex = 17
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'BtnGet
        '
        Me.BtnGet.Location = New System.Drawing.Point(314, 11)
        Me.BtnGet.Name = "BtnGet"
        Me.BtnGet.Size = New System.Drawing.Size(75, 23)
        Me.BtnGet.TabIndex = 15
        Me.BtnGet.Text = "Get User"
        Me.BtnGet.UseVisualStyleBackColor = True
        '
        'BtnSet
        '
        Me.BtnSet.Location = New System.Drawing.Point(395, 11)
        Me.BtnSet.Name = "BtnSet"
        Me.BtnSet.Size = New System.Drawing.Size(75, 23)
        Me.BtnSet.TabIndex = 16
        Me.BtnSet.Text = "Set User"
        Me.BtnSet.UseVisualStyleBackColor = True
        '
        'FormFingerPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(522, 262)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormFingerPrint"
        Me.Text = "FormFingerPrint"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents txtIP As TextBox
    Private WithEvents label2 As Label
    Private WithEvents btnConnect As Button
    Private WithEvents txtPort As TextBox
    Private WithEvents label1 As Label
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Private WithEvents BtnSet As Button
    Private WithEvents BtnGet As Button
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
