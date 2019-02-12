<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSampleBudgetDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSampleBudgetDet))
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TEReqBy = New DevExpress.XtraEditors.TextEdit()
        Me.PanelControlTopRight = New DevExpress.XtraEditors.PanelControl()
        Me.DEDateCreated = New DevExpress.XtraEditors.DateEdit()
        Me.TEReqNUmber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPBefore = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPAfter = New DevExpress.XtraTab.XtraTabPage()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BMark = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.TEReqBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlTopRight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlTopRight.SuspendLayout()
        CType(Me.DEDateCreated.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDateCreated.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEReqNUmber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
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
        Me.LargeImageCollection.Images.SetKeyName(10, "10_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(11, "18_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(12, "31_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(13, "folder-documents-icon.png")
        Me.LargeImageCollection.Images.SetKeyName(14, "mail_attachment.png")
        Me.LargeImageCollection.Images.SetKeyName(15, "attachment-icon.png")
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.PanelControlTopRight)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(996, 96)
        Me.PanelControl2.TabIndex = 2
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(13, 65)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(67, 13)
        Me.LabelControl2.TabIndex = 159
        Me.LabelControl2.Text = "Requested By"
        '
        'TEReqBy
        '
        Me.TEReqBy.EditValue = ""
        Me.TEReqBy.Location = New System.Drawing.Point(113, 62)
        Me.TEReqBy.Name = "TEReqBy"
        Me.TEReqBy.Properties.EditValueChangedDelay = 1
        Me.TEReqBy.Properties.ReadOnly = True
        Me.TEReqBy.Size = New System.Drawing.Size(207, 20)
        Me.TEReqBy.TabIndex = 162
        Me.TEReqBy.TabStop = False
        '
        'PanelControlTopRight
        '
        Me.PanelControlTopRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlTopRight.Controls.Add(Me.LabelControl2)
        Me.PanelControlTopRight.Controls.Add(Me.DEDateCreated)
        Me.PanelControlTopRight.Controls.Add(Me.TEReqBy)
        Me.PanelControlTopRight.Controls.Add(Me.TEReqNUmber)
        Me.PanelControlTopRight.Controls.Add(Me.LabelControl5)
        Me.PanelControlTopRight.Controls.Add(Me.LabelControl7)
        Me.PanelControlTopRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControlTopRight.Location = New System.Drawing.Point(664, 2)
        Me.PanelControlTopRight.Name = "PanelControlTopRight"
        Me.PanelControlTopRight.Size = New System.Drawing.Size(330, 92)
        Me.PanelControlTopRight.TabIndex = 8936
        '
        'DEDateCreated
        '
        Me.DEDateCreated.EditValue = Nothing
        Me.DEDateCreated.Location = New System.Drawing.Point(113, 10)
        Me.DEDateCreated.Name = "DEDateCreated"
        Me.DEDateCreated.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDateCreated.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDateCreated.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEDateCreated.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEDateCreated.Properties.ReadOnly = True
        Me.DEDateCreated.Size = New System.Drawing.Size(207, 20)
        Me.DEDateCreated.TabIndex = 160
        '
        'TEReqNUmber
        '
        Me.TEReqNUmber.EditValue = ""
        Me.TEReqNUmber.Location = New System.Drawing.Point(113, 36)
        Me.TEReqNUmber.Name = "TEReqNUmber"
        Me.TEReqNUmber.Properties.EditValueChangedDelay = 1
        Me.TEReqNUmber.Properties.ReadOnly = True
        Me.TEReqNUmber.Size = New System.Drawing.Size(207, 20)
        Me.TEReqNUmber.TabIndex = 8
        Me.TEReqNUmber.TabStop = False
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(13, 39)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl5.TabIndex = 155
        Me.LabelControl5.Text = "Number"
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(13, 13)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl7.TabIndex = 159
        Me.LabelControl7.Text = "Date Created"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 96)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XTPBefore
        Me.XtraTabControl1.Size = New System.Drawing.Size(996, 341)
        Me.XtraTabControl1.TabIndex = 3
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPBefore, Me.XTPAfter})
        '
        'XTPBefore
        '
        Me.XTPBefore.Name = "XTPBefore"
        Me.XTPBefore.Size = New System.Drawing.Size(990, 313)
        Me.XTPBefore.Text = "Before"
        '
        'XTPAfter
        '
        Me.XTPAfter.Name = "XTPAfter"
        Me.XTPAfter.Size = New System.Drawing.Size(990, 263)
        Me.XTPAfter.Text = "After"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnPrint)
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Controls.Add(Me.BtnSave)
        Me.PanelControl1.Controls.Add(Me.BMark)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 437)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(996, 39)
        Me.PanelControl1.TabIndex = 4
        '
        'BMark
        '
        Me.BMark.Dock = System.Windows.Forms.DockStyle.Left
        Me.BMark.ImageIndex = 4
        Me.BMark.ImageList = Me.LargeImageCollection
        Me.BMark.Location = New System.Drawing.Point(2, 2)
        Me.BMark.Name = "BMark"
        Me.BMark.Size = New System.Drawing.Size(75, 35)
        Me.BMark.TabIndex = 16
        Me.BMark.TabStop = False
        Me.BMark.Text = "Mark"
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.ImageIndex = 6
        Me.BtnPrint.ImageList = Me.LargeImageCollection
        Me.BtnPrint.Location = New System.Drawing.Point(769, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(75, 35)
        Me.BtnPrint.TabIndex = 18
        Me.BtnPrint.TabStop = False
        Me.BtnPrint.Text = "Print"
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.ImageIndex = 5
        Me.BtnCancel.ImageList = Me.LargeImageCollection
        Me.BtnCancel.Location = New System.Drawing.Point(844, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 35)
        Me.BtnCancel.TabIndex = 19
        Me.BtnCancel.TabStop = False
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.ImageIndex = 7
        Me.BtnSave.ImageList = Me.LargeImageCollection
        Me.BtnSave.Location = New System.Drawing.Point(919, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 35)
        Me.BtnSave.TabIndex = 17
        Me.BtnSave.TabStop = False
        Me.BtnSave.Text = "Save"
        '
        'FormSampleBudgetDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(996, 476)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PanelControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "FormSampleBudgetDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Propose Sample Budget"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.TEReqBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlTopRight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlTopRight.ResumeLayout(False)
        Me.PanelControlTopRight.PerformLayout()
        CType(Me.DEDateCreated.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDateCreated.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEReqNUmber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControlTopRight As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEDateCreated As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TEReqBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEReqNUmber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPBefore As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPAfter As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
End Class
