<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAccountingFYearDet
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
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl
        Me.XTPDetail = New DevExpress.XtraTab.XtraTabPage
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.BCloseYear = New DevExpress.XtraEditors.SimpleButton
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BSave = New DevExpress.XtraEditors.SimpleButton
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.TEEnd = New DevExpress.XtraEditors.TextEdit
        Me.TEStart = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.MEAccDesc = New DevExpress.XtraEditors.MemoEdit
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl
        Me.XTPSummary = New DevExpress.XtraTab.XtraTabPage
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XTPDetail.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TEEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEAccDesc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPSummary.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XTPDetail
        Me.XtraTabControl1.Size = New System.Drawing.Size(681, 361)
        Me.XtraTabControl1.TabIndex = 0
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPDetail, Me.XTPSummary})
        '
        'XTPDetail
        '
        Me.XTPDetail.Controls.Add(Me.PanelControl1)
        Me.XTPDetail.Controls.Add(Me.LabelControl2)
        Me.XTPDetail.Controls.Add(Me.TEEnd)
        Me.XTPDetail.Controls.Add(Me.TEStart)
        Me.XTPDetail.Controls.Add(Me.LabelControl1)
        Me.XTPDetail.Controls.Add(Me.MEAccDesc)
        Me.XTPDetail.Controls.Add(Me.LabelControl5)
        Me.XTPDetail.Name = "XTPDetail"
        Me.XTPDetail.Size = New System.Drawing.Size(675, 335)
        Me.XTPDetail.Text = "Detail"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BCloseYear)
        Me.PanelControl1.Controls.Add(Me.BCancel)
        Me.PanelControl1.Controls.Add(Me.BSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 299)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(675, 36)
        Me.PanelControl1.TabIndex = 127
        '
        'BCloseYear
        '
        Me.BCloseYear.Dock = System.Windows.Forms.DockStyle.Left
        Me.BCloseYear.Location = New System.Drawing.Point(2, 2)
        Me.BCloseYear.Name = "BCloseYear"
        Me.BCloseYear.Size = New System.Drawing.Size(115, 32)
        Me.BCloseYear.TabIndex = 4
        Me.BCloseYear.Text = "Close Fiscal Year"
        '
        'BCancel
        '
        Me.BCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCancel.Location = New System.Drawing.Point(523, 2)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(75, 32)
        Me.BCancel.TabIndex = 3
        Me.BCancel.Text = "Close"
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.Location = New System.Drawing.Point(598, 2)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(75, 32)
        Me.BSave.TabIndex = 2
        Me.BSave.Text = "Save"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(20, 127)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(48, 15)
        Me.LabelControl2.TabIndex = 126
        Me.LabelControl2.Text = "End Date"
        '
        'TEEnd
        '
        Me.TEEnd.Location = New System.Drawing.Point(108, 124)
        Me.TEEnd.Name = "TEEnd"
        Me.TEEnd.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEEnd.Properties.Appearance.Options.UseFont = True
        Me.TEEnd.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.TEEnd.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black
        Me.TEEnd.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TEEnd.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.TEEnd.Properties.ReadOnly = True
        Me.TEEnd.Size = New System.Drawing.Size(261, 22)
        Me.TEEnd.TabIndex = 125
        '
        'TEStart
        '
        Me.TEStart.Location = New System.Drawing.Point(108, 86)
        Me.TEStart.Name = "TEStart"
        Me.TEStart.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEStart.Properties.Appearance.Options.UseFont = True
        Me.TEStart.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.TEStart.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black
        Me.TEStart.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TEStart.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.TEStart.Properties.ReadOnly = True
        Me.TEStart.Size = New System.Drawing.Size(261, 22)
        Me.TEStart.TabIndex = 124
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(20, 89)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(54, 15)
        Me.LabelControl1.TabIndex = 123
        Me.LabelControl1.Text = "Start Date"
        '
        'MEAccDesc
        '
        Me.MEAccDesc.Location = New System.Drawing.Point(108, 25)
        Me.MEAccDesc.Name = "MEAccDesc"
        Me.MEAccDesc.Size = New System.Drawing.Size(516, 45)
        Me.MEAccDesc.TabIndex = 122
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(20, 27)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(64, 15)
        Me.LabelControl5.TabIndex = 121
        Me.LabelControl5.Text = "Description"
        '
        'XTPSummary
        '
        Me.XTPSummary.Controls.Add(Me.PanelControl2)
        Me.XTPSummary.Name = "XTPSummary"
        Me.XTPSummary.PageVisible = False
        Me.XTPSummary.Size = New System.Drawing.Size(675, 335)
        Me.XTPSummary.Text = "Summary"
        '
        'PanelControl2
        '
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 284)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(675, 51)
        Me.PanelControl2.TabIndex = 128
        '
        'FormAccountingFYearDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(681, 361)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.MinimizeBox = False
        Me.Name = "FormAccountingFYearDet"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fiscal Year Detail"
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XTPDetail.ResumeLayout(False)
        Me.XTPDetail.PerformLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.TEEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEAccDesc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPSummary.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPDetail As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPSummary As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents MEAccDesc As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEEnd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEStart As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCloseYear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
End Class
