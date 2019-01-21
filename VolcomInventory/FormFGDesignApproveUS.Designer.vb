<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGDesignApproveUS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFGDesignApproveUS))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControlDesignApprovr = New DevExpress.XtraEditors.PanelControl()
        Me.LEReportStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtNumber = New DevExpress.XtraEditors.TextEdit()
        Me.DateEdit1 = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnConfirm = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCancellApprove = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnMark = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnAttachmentDesign = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControlSampleApprove = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl5 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.CheckEdit1 = New DevExpress.XtraEditors.CheckEdit()
        Me.PanelControl6 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlDesignApprovr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlDesignApprovr.SuspendLayout()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.PanelControlSampleApprove, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlSampleApprove.SuspendLayout()
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl5.SuspendLayout()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl6.SuspendLayout()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LEReportStatus)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.TxtNumber)
        Me.PanelControl1.Controls.Add(Me.DateEdit1)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(745, 46)
        Me.PanelControl1.TabIndex = 0
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BtnMark)
        Me.PanelControl2.Controls.Add(Me.BtnCancellApprove)
        Me.PanelControl2.Controls.Add(Me.BtnConfirm)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 379)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(745, 43)
        Me.PanelControl2.TabIndex = 1
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 46)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(745, 217)
        Me.GCData.TabIndex = 2
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'PanelControlDesignApprovr
        '
        Me.PanelControlDesignApprovr.Controls.Add(Me.BtnAttachmentDesign)
        Me.PanelControlDesignApprovr.Controls.Add(Me.PanelControl4)
        Me.PanelControlDesignApprovr.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControlDesignApprovr.Location = New System.Drawing.Point(0, 263)
        Me.PanelControlDesignApprovr.Name = "PanelControlDesignApprovr"
        Me.PanelControlDesignApprovr.Size = New System.Drawing.Size(745, 38)
        Me.PanelControlDesignApprovr.TabIndex = 3
        '
        'LEReportStatus
        '
        Me.LEReportStatus.Enabled = False
        Me.LEReportStatus.Location = New System.Drawing.Point(492, 13)
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
        Me.LEReportStatus.Size = New System.Drawing.Size(158, 20)
        Me.LEReportStatus.TabIndex = 14
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(455, 16)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl3.TabIndex = 13
        Me.LabelControl3.Text = "Status"
        '
        'TxtNumber
        '
        Me.TxtNumber.Location = New System.Drawing.Point(56, 13)
        Me.TxtNumber.Name = "TxtNumber"
        Me.TxtNumber.Size = New System.Drawing.Size(158, 20)
        Me.TxtNumber.TabIndex = 11
        '
        'DateEdit1
        '
        Me.DateEdit1.EditValue = Nothing
        Me.DateEdit1.Location = New System.Drawing.Point(291, 13)
        Me.DateEdit1.Name = "DateEdit1"
        Me.DateEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Size = New System.Drawing.Size(158, 20)
        Me.DateEdit1.TabIndex = 12
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(13, 16)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl1.TabIndex = 9
        Me.LabelControl1.Text = "Number"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(220, 16)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl2.TabIndex = 10
        Me.LabelControl2.Text = "Created Date"
        '
        'BtnConfirm
        '
        Me.BtnConfirm.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnConfirm.Image = CType(resources.GetObject("BtnConfirm.Image"), System.Drawing.Image)
        Me.BtnConfirm.Location = New System.Drawing.Point(655, 2)
        Me.BtnConfirm.Name = "BtnConfirm"
        Me.BtnConfirm.Size = New System.Drawing.Size(88, 39)
        Me.BtnConfirm.TabIndex = 0
        Me.BtnConfirm.Text = "Confirm"
        '
        'BtnCancellApprove
        '
        Me.BtnCancellApprove.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancellApprove.Image = CType(resources.GetObject("BtnCancellApprove.Image"), System.Drawing.Image)
        Me.BtnCancellApprove.Location = New System.Drawing.Point(529, 2)
        Me.BtnCancellApprove.Name = "BtnCancellApprove"
        Me.BtnCancellApprove.Size = New System.Drawing.Size(126, 39)
        Me.BtnCancellApprove.TabIndex = 1
        Me.BtnCancellApprove.Text = "Cancell Approval"
        '
        'BtnMark
        '
        Me.BtnMark.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnMark.Image = CType(resources.GetObject("BtnMark.Image"), System.Drawing.Image)
        Me.BtnMark.Location = New System.Drawing.Point(2, 2)
        Me.BtnMark.Name = "BtnMark"
        Me.BtnMark.Size = New System.Drawing.Size(89, 39)
        Me.BtnMark.TabIndex = 6
        Me.BtnMark.Text = "Mark"
        Me.BtnMark.Visible = False
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(11, 8)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(147, 19)
        Me.LabelControl4.TabIndex = 15
        Me.LabelControl4.Text = "DESIGN APPROVE"
        '
        'BtnAttachmentDesign
        '
        Me.BtnAttachmentDesign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnAttachmentDesign.Location = New System.Drawing.Point(170, 2)
        Me.BtnAttachmentDesign.LookAndFeel.SkinName = "Office 2007 Green"
        Me.BtnAttachmentDesign.Name = "BtnAttachmentDesign"
        Me.BtnAttachmentDesign.Size = New System.Drawing.Size(573, 34)
        Me.BtnAttachmentDesign.TabIndex = 16
        Me.BtnAttachmentDesign.Text = "Attachment"
        '
        'PanelControl4
        '
        Me.PanelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl4.Controls.Add(Me.LabelControl4)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl4.Location = New System.Drawing.Point(2, 2)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(168, 34)
        Me.PanelControl4.TabIndex = 0
        '
        'PanelControlSampleApprove
        '
        Me.PanelControlSampleApprove.Controls.Add(Me.SimpleButton1)
        Me.PanelControlSampleApprove.Controls.Add(Me.PanelControl6)
        Me.PanelControlSampleApprove.Controls.Add(Me.PanelControl5)
        Me.PanelControlSampleApprove.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControlSampleApprove.Location = New System.Drawing.Point(0, 301)
        Me.PanelControlSampleApprove.Name = "PanelControlSampleApprove"
        Me.PanelControlSampleApprove.Size = New System.Drawing.Size(745, 78)
        Me.PanelControlSampleApprove.TabIndex = 4
        '
        'PanelControl5
        '
        Me.PanelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl5.Controls.Add(Me.LabelControl5)
        Me.PanelControl5.Controls.Add(Me.CheckEdit1)
        Me.PanelControl5.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl5.Location = New System.Drawing.Point(2, 2)
        Me.PanelControl5.Name = "PanelControl5"
        Me.PanelControl5.Size = New System.Drawing.Size(168, 74)
        Me.PanelControl5.TabIndex = 1
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(11, 20)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(150, 19)
        Me.LabelControl5.TabIndex = 15
        Me.LabelControl5.Text = "SAMPLE APPROVE"
        '
        'CheckEdit1
        '
        Me.CheckEdit1.Location = New System.Drawing.Point(12, 38)
        Me.CheckEdit1.Name = "CheckEdit1"
        Me.CheckEdit1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckEdit1.Properties.Appearance.Options.UseFont = True
        Me.CheckEdit1.Properties.Caption = "No need sample approve"
        Me.CheckEdit1.Size = New System.Drawing.Size(153, 19)
        Me.CheckEdit1.TabIndex = 2
        '
        'PanelControl6
        '
        Me.PanelControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl6.Controls.Add(Me.TextEdit1)
        Me.PanelControl6.Controls.Add(Me.LabelControl6)
        Me.PanelControl6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl6.Location = New System.Drawing.Point(170, 36)
        Me.PanelControl6.Name = "PanelControl6"
        Me.PanelControl6.Size = New System.Drawing.Size(573, 40)
        Me.PanelControl6.TabIndex = 2
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(8, 13)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl6.TabIndex = 5
        Me.LabelControl6.Text = "Reason"
        '
        'TextEdit1
        '
        Me.TextEdit1.Location = New System.Drawing.Point(50, 10)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Size = New System.Drawing.Size(513, 20)
        Me.TextEdit1.TabIndex = 6
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SimpleButton1.Location = New System.Drawing.Point(170, 2)
        Me.SimpleButton1.LookAndFeel.SkinName = "Office 2007 Green"
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(573, 34)
        Me.SimpleButton1.TabIndex = 17
        Me.SimpleButton1.Text = "Attachment"
        '
        'FormFGDesignApproveUS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(745, 422)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControlDesignApprovr)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PanelControlSampleApprove)
        Me.Controls.Add(Me.PanelControl2)
        Me.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "FormFGDesignApproveUS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Approve by US"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlDesignApprovr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlDesignApprovr.ResumeLayout(False)
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        Me.PanelControl4.PerformLayout()
        CType(Me.PanelControlSampleApprove, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlSampleApprove.ResumeLayout(False)
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl5.ResumeLayout(False)
        Me.PanelControl5.PerformLayout()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl6.ResumeLayout(False)
        Me.PanelControl6.PerformLayout()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControlDesignApprovr As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LEReportStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DateEdit1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnCancellApprove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnConfirm As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAttachmentDesign As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControlSampleApprove As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl6 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl5 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CheckEdit1 As DevExpress.XtraEditors.CheckEdit
End Class
