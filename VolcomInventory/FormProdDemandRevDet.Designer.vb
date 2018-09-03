<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormProdDemandRevDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProdDemandRevDet))
        Me.GroupControlHead = New DevExpress.XtraEditors.GroupControl()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtRevision = New DevExpress.XtraEditors.TextEdit()
        Me.TxtProdDemandNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.DECreated = New DevExpress.XtraEditors.DateEdit()
        Me.LEReportStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControlBottom = New DevExpress.XtraEditors.PanelControl()
        Me.BtnAttachment = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnMark = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCancell = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnConfirm = New DevExpress.XtraEditors.SimpleButton()
        Me.XTCRevision = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPRevision = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPDetail = New DevExpress.XtraTab.XtraTabPage()
        Me.PanelControlNav = New DevExpress.XtraEditors.PanelControl()
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GroupControlHead, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlHead.SuspendLayout()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtRevision.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtProdDemandNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DECreated.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DECreated.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlBottom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlBottom.SuspendLayout()
        CType(Me.XTCRevision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCRevision.SuspendLayout()
        Me.XTPRevision.SuspendLayout()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNav.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupControlHead
        '
        Me.GroupControlHead.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlHead.Controls.Add(Me.MENote)
        Me.GroupControlHead.Controls.Add(Me.LabelControl7)
        Me.GroupControlHead.Controls.Add(Me.LabelControl6)
        Me.GroupControlHead.Controls.Add(Me.TxtRevision)
        Me.GroupControlHead.Controls.Add(Me.TxtProdDemandNumber)
        Me.GroupControlHead.Controls.Add(Me.LabelControl2)
        Me.GroupControlHead.Controls.Add(Me.PanelControl1)
        Me.GroupControlHead.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControlHead.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlHead.Name = "GroupControlHead"
        Me.GroupControlHead.Size = New System.Drawing.Size(921, 126)
        Me.GroupControlHead.TabIndex = 8
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(105, 67)
        Me.MENote.Name = "MENote"
        Me.MENote.Size = New System.Drawing.Size(289, 41)
        Me.MENote.TabIndex = 151
        Me.MENote.TabStop = False
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(36, 69)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl7.TabIndex = 150
        Me.LabelControl7.Text = "Note"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(36, 43)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(40, 13)
        Me.LabelControl6.TabIndex = 149
        Me.LabelControl6.Text = "Revision"
        '
        'TxtRevision
        '
        Me.TxtRevision.Enabled = False
        Me.TxtRevision.Location = New System.Drawing.Point(105, 40)
        Me.TxtRevision.Name = "TxtRevision"
        Me.TxtRevision.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRevision.Properties.Appearance.Options.UseFont = True
        Me.TxtRevision.Size = New System.Drawing.Size(289, 20)
        Me.TxtRevision.TabIndex = 148
        '
        'TxtProdDemandNumber
        '
        Me.TxtProdDemandNumber.Enabled = False
        Me.TxtProdDemandNumber.Location = New System.Drawing.Point(105, 14)
        Me.TxtProdDemandNumber.Name = "TxtProdDemandNumber"
        Me.TxtProdDemandNumber.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProdDemandNumber.Properties.Appearance.Options.UseFont = True
        Me.TxtProdDemandNumber.Size = New System.Drawing.Size(289, 20)
        Me.TxtProdDemandNumber.TabIndex = 147
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(36, 17)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl2.TabIndex = 147
        Me.LabelControl2.Text = "PD Number"
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.LabelControl21)
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Controls.Add(Me.LEReportStatus)
        Me.PanelControl1.Controls.Add(Me.DECreated)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl1.Location = New System.Drawing.Point(710, 2)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(209, 122)
        Me.PanelControl1.TabIndex = 4
        '
        'DECreated
        '
        Me.DECreated.EditValue = Nothing
        Me.DECreated.Enabled = False
        Me.DECreated.Location = New System.Drawing.Point(56, 12)
        Me.DECreated.Name = "DECreated"
        Me.DECreated.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DECreated.Properties.Appearance.Options.UseFont = True
        Me.DECreated.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DECreated.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DECreated.Size = New System.Drawing.Size(136, 20)
        Me.DECreated.TabIndex = 6
        '
        'LEReportStatus
        '
        Me.LEReportStatus.Enabled = False
        Me.LEReportStatus.Location = New System.Drawing.Point(56, 38)
        Me.LEReportStatus.Name = "LEReportStatus"
        Me.LEReportStatus.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LEReportStatus.Properties.Appearance.Options.UseFont = True
        Me.LEReportStatus.Properties.Appearance.Options.UseTextOptions = True
        Me.LEReportStatus.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEReportStatus.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White
        Me.LEReportStatus.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.LEReportStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEReportStatus.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_report_status", "ID Report Status", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("report_status", "Report Status")})
        Me.LEReportStatus.Properties.NullText = ""
        Me.LEReportStatus.Properties.ShowFooter = False
        Me.LEReportStatus.Size = New System.Drawing.Size(136, 20)
        Me.LEReportStatus.TabIndex = 7
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(10, 15)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl4.TabIndex = 7
        Me.LabelControl4.Text = "Date"
        '
        'LabelControl21
        '
        Me.LabelControl21.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl21.Location = New System.Drawing.Point(10, 41)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl21.TabIndex = 144
        Me.LabelControl21.Text = "Status"
        '
        'PanelControlBottom
        '
        Me.PanelControlBottom.Controls.Add(Me.BtnAttachment)
        Me.PanelControlBottom.Controls.Add(Me.BtnPrint)
        Me.PanelControlBottom.Controls.Add(Me.BtnMark)
        Me.PanelControlBottom.Controls.Add(Me.BtnCancell)
        Me.PanelControlBottom.Controls.Add(Me.BtnConfirm)
        Me.PanelControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControlBottom.Location = New System.Drawing.Point(0, 506)
        Me.PanelControlBottom.Name = "PanelControlBottom"
        Me.PanelControlBottom.Size = New System.Drawing.Size(921, 44)
        Me.PanelControlBottom.TabIndex = 13
        '
        'BtnAttachment
        '
        Me.BtnAttachment.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAttachment.Image = CType(resources.GetObject("BtnAttachment.Image"), System.Drawing.Image)
        Me.BtnAttachment.Location = New System.Drawing.Point(504, 2)
        Me.BtnAttachment.Name = "BtnAttachment"
        Me.BtnAttachment.Size = New System.Drawing.Size(106, 40)
        Me.BtnAttachment.TabIndex = 4
        Me.BtnAttachment.Text = "Attachment"
        Me.BtnAttachment.Visible = False
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(610, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(87, 40)
        Me.BtnPrint.TabIndex = 3
        Me.BtnPrint.Text = "Print"
        '
        'BtnMark
        '
        Me.BtnMark.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnMark.Image = CType(resources.GetObject("BtnMark.Image"), System.Drawing.Image)
        Me.BtnMark.Location = New System.Drawing.Point(2, 2)
        Me.BtnMark.Name = "BtnMark"
        Me.BtnMark.Size = New System.Drawing.Size(89, 40)
        Me.BtnMark.TabIndex = 5
        Me.BtnMark.Text = "Mark"
        Me.BtnMark.Visible = False
        '
        'BtnCancell
        '
        Me.BtnCancell.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancell.Image = CType(resources.GetObject("BtnCancell.Image"), System.Drawing.Image)
        Me.BtnCancell.Location = New System.Drawing.Point(697, 2)
        Me.BtnCancell.Name = "BtnCancell"
        Me.BtnCancell.Size = New System.Drawing.Size(126, 40)
        Me.BtnCancell.TabIndex = 7
        Me.BtnCancell.Text = "Cancell Propose"
        Me.BtnCancell.Visible = False
        '
        'BtnConfirm
        '
        Me.BtnConfirm.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnConfirm.Image = CType(resources.GetObject("BtnConfirm.Image"), System.Drawing.Image)
        Me.BtnConfirm.Location = New System.Drawing.Point(823, 2)
        Me.BtnConfirm.Name = "BtnConfirm"
        Me.BtnConfirm.Size = New System.Drawing.Size(96, 40)
        Me.BtnConfirm.TabIndex = 6
        Me.BtnConfirm.Text = "Confirm"
        Me.BtnConfirm.Visible = False
        '
        'XTCRevision
        '
        Me.XTCRevision.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCRevision.Location = New System.Drawing.Point(0, 126)
        Me.XTCRevision.Name = "XTCRevision"
        Me.XTCRevision.SelectedTabPage = Me.XTPRevision
        Me.XTCRevision.Size = New System.Drawing.Size(921, 380)
        Me.XTCRevision.TabIndex = 14
        Me.XTCRevision.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPRevision, Me.XTPDetail})
        '
        'XTPRevision
        '
        Me.XTPRevision.Controls.Add(Me.PanelControlNav)
        Me.XTPRevision.Name = "XTPRevision"
        Me.XTPRevision.Size = New System.Drawing.Size(915, 352)
        Me.XTPRevision.Text = "Revision"
        '
        'XTPDetail
        '
        Me.XTPDetail.Name = "XTPDetail"
        Me.XTPDetail.Size = New System.Drawing.Size(915, 352)
        Me.XTPDetail.Text = "PD Detail"
        '
        'PanelControlNav
        '
        Me.PanelControlNav.Controls.Add(Me.BtnAdd)
        Me.PanelControlNav.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlNav.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlNav.Name = "PanelControlNav"
        Me.PanelControlNav.Size = New System.Drawing.Size(915, 42)
        Me.PanelControlNav.TabIndex = 0
        '
        'BtnAdd
        '
        Me.BtnAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"), System.Drawing.Image)
        Me.BtnAdd.Location = New System.Drawing.Point(838, 2)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(75, 38)
        Me.BtnAdd.TabIndex = 0
        Me.BtnAdd.Text = "Add"
        '
        'FormProdDemandRevDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(921, 550)
        Me.Controls.Add(Me.XTCRevision)
        Me.Controls.Add(Me.PanelControlBottom)
        Me.Controls.Add(Me.GroupControlHead)
        Me.Name = "FormProdDemandRevDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PD Revision"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GroupControlHead, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlHead.ResumeLayout(False)
        Me.GroupControlHead.PerformLayout()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtRevision.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtProdDemandNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.DECreated.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DECreated.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlBottom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlBottom.ResumeLayout(False)
        CType(Me.XTCRevision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCRevision.ResumeLayout(False)
        Me.XTPRevision.ResumeLayout(False)
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNav.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupControlHead As DevExpress.XtraEditors.GroupControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtRevision As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtProdDemandNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEReportStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents DECreated As DevExpress.XtraEditors.DateEdit
    Friend WithEvents PanelControlBottom As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnAttachment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCancell As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnConfirm As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XTCRevision As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPRevision As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPDetail As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControlNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
End Class
