﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReportMarkCancel
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
        Me.DEDateProposed = New DevExpress.XtraEditors.DateEdit()
        Me.MEReason = New DevExpress.XtraEditors.MemoEdit()
        Me.TECancelBy = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BApprove = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BAttachment = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.LEPaymentTerm = New DevExpress.XtraEditors.LookUpEdit()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.GCReportList = New DevExpress.XtraGrid.GridControl()
        Me.GVReportList = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.DEDateProposed.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDateProposed.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEReason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECancelBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LEPaymentTerm.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.GCReportList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVReportList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DEDateProposed
        '
        Me.DEDateProposed.EditValue = Nothing
        Me.DEDateProposed.Enabled = False
        Me.DEDateProposed.Location = New System.Drawing.Point(126, 38)
        Me.DEDateProposed.Name = "DEDateProposed"
        Me.DEDateProposed.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDateProposed.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDateProposed.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEDateProposed.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEDateProposed.Size = New System.Drawing.Size(184, 20)
        Me.DEDateProposed.TabIndex = 154
        '
        'MEReason
        '
        Me.MEReason.Location = New System.Drawing.Point(111, 15)
        Me.MEReason.Name = "MEReason"
        Me.MEReason.Properties.ReadOnly = True
        Me.MEReason.Size = New System.Drawing.Size(590, 99)
        Me.MEReason.TabIndex = 153
        '
        'TECancelBy
        '
        Me.TECancelBy.EditValue = "[Auto Generate]"
        Me.TECancelBy.Location = New System.Drawing.Point(126, 12)
        Me.TECancelBy.Name = "TECancelBy"
        Me.TECancelBy.Properties.ReadOnly = True
        Me.TECancelBy.Size = New System.Drawing.Size(312, 20)
        Me.TECancelBy.TabIndex = 152
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(34, 17)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(71, 13)
        Me.LabelControl2.TabIndex = 151
        Me.LabelControl2.Text = "Cancel Reason"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(34, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(47, 13)
        Me.LabelControl1.TabIndex = 150
        Me.LabelControl1.Text = "Cancel By"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(34, 41)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(71, 13)
        Me.LabelControl3.TabIndex = 155
        Me.LabelControl3.Text = "Date Proposed"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BApprove)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 507)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(717, 29)
        Me.PanelControl2.TabIndex = 161
        '
        'BApprove
        '
        Me.BApprove.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BApprove.ImageIndex = 4
        Me.BApprove.Location = New System.Drawing.Point(2, 2)
        Me.BApprove.Name = "BApprove"
        Me.BApprove.Size = New System.Drawing.Size(713, 25)
        Me.BApprove.TabIndex = 15
        Me.BApprove.TabStop = False
        Me.BApprove.Text = "Approve"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BAttachment)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 478)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(717, 29)
        Me.PanelControl1.TabIndex = 162
        '
        'BAttachment
        '
        Me.BAttachment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BAttachment.ImageIndex = 4
        Me.BAttachment.Location = New System.Drawing.Point(2, 2)
        Me.BAttachment.Name = "BAttachment"
        Me.BAttachment.Size = New System.Drawing.Size(713, 25)
        Me.BAttachment.TabIndex = 15
        Me.BAttachment.TabStop = False
        Me.BAttachment.Text = "See Attachment"
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(34, 67)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(86, 13)
        Me.LabelControl10.TabIndex = 166
        Me.LabelControl10.Text = "Report Mark Type"
        '
        'LEPaymentTerm
        '
        Me.LEPaymentTerm.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LEPaymentTerm.Location = New System.Drawing.Point(126, 64)
        Me.LEPaymentTerm.Name = "LEPaymentTerm"
        Me.LEPaymentTerm.Properties.Appearance.Options.UseTextOptions = True
        Me.LEPaymentTerm.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEPaymentTerm.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEPaymentTerm.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_payment_purchasing", "ID Payment Term", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("payment_purchasing", "Payment Term")})
        Me.LEPaymentTerm.Properties.NullText = ""
        Me.LEPaymentTerm.Properties.ShowFooter = False
        Me.LEPaymentTerm.Size = New System.Drawing.Size(423, 20)
        Me.LEPaymentTerm.TabIndex = 165
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.TECancelBy)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.LabelControl10)
        Me.GroupControl1.Controls.Add(Me.DEDateProposed)
        Me.GroupControl1.Controls.Add(Me.LEPaymentTerm)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(717, 100)
        Me.GroupControl1.TabIndex = 167
        Me.GroupControl1.Text = "Header"
        '
        'GroupControl2
        '
        Me.GroupControl2.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl2.Controls.Add(Me.GCReportList)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 100)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(717, 239)
        Me.GroupControl2.TabIndex = 168
        Me.GroupControl2.Text = "List Document"
        '
        'GroupControl3
        '
        Me.GroupControl3.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl3.Controls.Add(Me.MEReason)
        Me.GroupControl3.Controls.Add(Me.LabelControl2)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl3.Location = New System.Drawing.Point(0, 339)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(717, 139)
        Me.GroupControl3.TabIndex = 169
        Me.GroupControl3.Text = "Reason"
        '
        'GCReportList
        '
        Me.GCReportList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCReportList.Location = New System.Drawing.Point(20, 2)
        Me.GCReportList.MainView = Me.GVReportList
        Me.GCReportList.Name = "GCReportList"
        Me.GCReportList.Size = New System.Drawing.Size(695, 235)
        Me.GCReportList.TabIndex = 0
        Me.GCReportList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVReportList})
        '
        'GVReportList
        '
        Me.GVReportList.GridControl = Me.GCReportList
        Me.GVReportList.Name = "GVReportList"
        Me.GVReportList.OptionsView.ShowGroupPanel = False
        '
        'FormReportMarkCancel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(717, 536)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PanelControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormReportMarkCancel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancel Form"
        CType(Me.DEDateProposed.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDateProposed.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEReason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECancelBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.LEPaymentTerm.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        CType(Me.GCReportList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVReportList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DEDateProposed As DevExpress.XtraEditors.DateEdit
    Friend WithEvents MEReason As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents TECancelBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BApprove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BAttachment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEPaymentTerm As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCReportList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVReportList As DevExpress.XtraGrid.Views.Grid.GridView
End Class
