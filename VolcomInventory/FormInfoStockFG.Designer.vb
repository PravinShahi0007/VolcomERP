<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInfoStockFG
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.LabelSubTitle = New DevExpress.XtraEditors.LabelControl
        Me.LabelTitle = New DevExpress.XtraEditors.LabelControl
        Me.PanelControlImg = New DevExpress.XtraEditors.PanelControl
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit
        Me.BtnViewImg = New DevExpress.XtraEditors.SimpleButton
        Me.GCFG = New DevExpress.XtraGrid.GridControl
        Me.GVFG = New DevExpress.XtraGrid.Views.Grid.GridView
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControlImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlImg.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCFG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVFG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.Blue
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.Controls.Add(Me.LabelSubTitle)
        Me.PanelControl1.Controls.Add(Me.LabelTitle)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(721, 55)
        Me.PanelControl1.TabIndex = 35
        '
        'LabelSubTitle
        '
        Me.LabelSubTitle.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSubTitle.Location = New System.Drawing.Point(12, 30)
        Me.LabelSubTitle.Name = "LabelSubTitle"
        Me.LabelSubTitle.Size = New System.Drawing.Size(54, 15)
        Me.LabelSubTitle.TabIndex = 30
        Me.LabelSubTitle.Text = "Item Code"
        '
        'LabelTitle
        '
        Me.LabelTitle.Appearance.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitle.Location = New System.Drawing.Point(12, 8)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(78, 23)
        Me.LabelTitle.TabIndex = 29
        Me.LabelTitle.Text = "Stock Info"
        '
        'PanelControlImg
        '
        Me.PanelControlImg.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlImg.Controls.Add(Me.PictureEdit1)
        Me.PanelControlImg.Controls.Add(Me.BtnViewImg)
        Me.PanelControlImg.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControlImg.Location = New System.Drawing.Point(0, 55)
        Me.PanelControlImg.Name = "PanelControlImg"
        Me.PanelControlImg.Size = New System.Drawing.Size(187, 254)
        Me.PanelControlImg.TabIndex = 36
        Me.PanelControlImg.Visible = False
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureEdit1.Location = New System.Drawing.Point(0, 0)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.PictureEdit1.Properties.ShowMenu = False
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureEdit1.Size = New System.Drawing.Size(187, 231)
        Me.PictureEdit1.TabIndex = 3
        '
        'BtnViewImg
        '
        Me.BtnViewImg.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnViewImg.Location = New System.Drawing.Point(0, 231)
        Me.BtnViewImg.Name = "BtnViewImg"
        Me.BtnViewImg.Size = New System.Drawing.Size(187, 23)
        Me.BtnViewImg.TabIndex = 0
        Me.BtnViewImg.Text = "View Image"
        '
        'GCFG
        '
        Me.GCFG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCFG.Location = New System.Drawing.Point(187, 55)
        Me.GCFG.MainView = Me.GVFG
        Me.GCFG.Name = "GCFG"
        Me.GCFG.Size = New System.Drawing.Size(534, 254)
        Me.GCFG.TabIndex = 37
        Me.GCFG.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVFG})
        '
        'GVFG
        '
        Me.GVFG.GridControl = Me.GCFG
        Me.GVFG.Name = "GVFG"
        Me.GVFG.OptionsView.ShowGroupPanel = False
        '
        'FormInfoStockFG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(721, 309)
        Me.Controls.Add(Me.GCFG)
        Me.Controls.Add(Me.PanelControlImg)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormInfoStockFG"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Finished Goods Stock"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.PanelControlImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlImg.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCFG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVFG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelSubTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControlImg As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents BtnViewImg As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCFG As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVFG As DevExpress.XtraGrid.Views.Grid.GridView
End Class
