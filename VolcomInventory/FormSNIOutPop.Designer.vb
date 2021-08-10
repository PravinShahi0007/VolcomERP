<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSNIOutPop
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSNIOutPop))
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.SCCQC = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GroupControlItemList = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControlListBarcode = New DevExpress.XtraEditors.GroupControl()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.SCCQC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SCCQC.SuspendLayout()
        CType(Me.GroupControlItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlListBarcode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "20_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "8_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "23_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(3, "arrow_refresh.png")
        Me.LargeImageCollection.Images.SetKeyName(4, "check_mark.png")
        Me.LargeImageCollection.Images.SetKeyName(5, "gnome_application_exit (1).png")
        Me.LargeImageCollection.Images.SetKeyName(6, "printer_3.png")
        Me.LargeImageCollection.Images.SetKeyName(7, "save.png")
        Me.LargeImageCollection.Images.SetKeyName(8, "31_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(9, "18_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(10, "attachment-icon.png")
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.BtnCancel)
        Me.PanelControl3.Controls.Add(Me.BtnSave)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 485)
        Me.PanelControl3.LookAndFeel.SkinName = "Blue"
        Me.PanelControl3.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(906, 40)
        Me.PanelControl3.TabIndex = 205
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.ImageIndex = 5
        Me.BtnCancel.ImageList = Me.LargeImageCollection
        Me.BtnCancel.Location = New System.Drawing.Point(754, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 36)
        Me.BtnCancel.TabIndex = 11
        Me.BtnCancel.Text = "Close"
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.ImageIndex = 4
        Me.BtnSave.ImageList = Me.LargeImageCollection
        Me.BtnSave.Location = New System.Drawing.Point(829, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 36)
        Me.BtnSave.TabIndex = 10
        Me.BtnSave.Text = "Add"
        '
        'SCCQC
        '
        Me.SCCQC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SCCQC.Horizontal = False
        Me.SCCQC.Location = New System.Drawing.Point(0, 0)
        Me.SCCQC.Name = "SCCQC"
        Me.SCCQC.Panel1.Controls.Add(Me.GroupControlItemList)
        Me.SCCQC.Panel1.Text = "Panel1"
        Me.SCCQC.Panel2.Controls.Add(Me.GroupControlListBarcode)
        Me.SCCQC.Panel2.Text = "Panel2"
        Me.SCCQC.Size = New System.Drawing.Size(906, 485)
        Me.SCCQC.SplitterPosition = 224
        Me.SCCQC.TabIndex = 207
        Me.SCCQC.Text = "SplitContainerControl1"
        '
        'GroupControlItemList
        '
        Me.GroupControlItemList.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlItemList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlItemList.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlItemList.Name = "GroupControlItemList"
        Me.GroupControlItemList.Size = New System.Drawing.Size(906, 224)
        Me.GroupControlItemList.TabIndex = 204
        '
        'GroupControlListBarcode
        '
        Me.GroupControlListBarcode.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlListBarcode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlListBarcode.Enabled = False
        Me.GroupControlListBarcode.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlListBarcode.Name = "GroupControlListBarcode"
        Me.GroupControlListBarcode.Size = New System.Drawing.Size(906, 256)
        Me.GroupControlListBarcode.TabIndex = 2
        '
        'FormSNIOutPop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(906, 525)
        Me.Controls.Add(Me.SCCQC)
        Me.Controls.Add(Me.PanelControl3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSNIOutPop"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pop up SNI"
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.SCCQC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SCCQC.ResumeLayout(False)
        CType(Me.GroupControlItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlListBarcode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SCCQC As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControlItemList As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControlListBarcode As DevExpress.XtraEditors.GroupControl
End Class
