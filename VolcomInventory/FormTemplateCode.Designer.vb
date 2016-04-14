<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTemplateCode
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
        Me.XTCTemplateCode = New DevExpress.XtraTab.XtraTabControl
        Me.XTPCode = New DevExpress.XtraTab.XtraTabPage
        Me.GCTemplateCode = New DevExpress.XtraGrid.GridControl
        Me.GVTemplateCode = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdTemplateCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColTemplateCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.XTPCodeDet = New DevExpress.XtraTab.XtraTabPage
        Me.GCTemplateCodeDet = New DevExpress.XtraGrid.GridControl
        Me.GVTemplateCodeDet = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColCodeName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.DNTemplateCodeDet = New DevExpress.XtraEditors.DataNavigator
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.BRevert = New DevExpress.XtraEditors.SimpleButton
        Me.BSave = New DevExpress.XtraEditors.SimpleButton
        Me.PCDeliveryTitle = New DevExpress.XtraEditors.PanelControl
        Me.LabelTemplate = New DevExpress.XtraEditors.LabelControl
        Me.LabelCodeTitle = New DevExpress.XtraEditors.LabelControl
        CType(Me.XTCTemplateCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCTemplateCode.SuspendLayout()
        Me.XTPCode.SuspendLayout()
        CType(Me.GCTemplateCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVTemplateCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPCodeDet.SuspendLayout()
        CType(Me.GCTemplateCodeDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVTemplateCodeDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PCDeliveryTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCDeliveryTitle.SuspendLayout()
        Me.SuspendLayout()
        '
        'XTCTemplateCode
        '
        Me.XTCTemplateCode.AppearancePage.Header.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XTCTemplateCode.AppearancePage.Header.Options.UseFont = True
        Me.XTCTemplateCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCTemplateCode.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XTCTemplateCode.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left
        Me.XTCTemplateCode.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Vertical
        Me.XTCTemplateCode.Location = New System.Drawing.Point(0, 0)
        Me.XTCTemplateCode.Name = "XTCTemplateCode"
        Me.XTCTemplateCode.SelectedTabPage = Me.XTPCode
        Me.XTCTemplateCode.Size = New System.Drawing.Size(581, 383)
        Me.XTCTemplateCode.TabIndex = 4
        Me.XTCTemplateCode.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPCode, Me.XTPCodeDet})
        '
        'XTPCode
        '
        Me.XTPCode.Controls.Add(Me.GCTemplateCode)
        Me.XTPCode.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XTPCode.Name = "XTPCode"
        Me.XTPCode.Size = New System.Drawing.Size(555, 377)
        Me.XTPCode.Text = "Code"
        '
        'GCTemplateCode
        '
        Me.GCTemplateCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCTemplateCode.Location = New System.Drawing.Point(0, 0)
        Me.GCTemplateCode.MainView = Me.GVTemplateCode
        Me.GCTemplateCode.Name = "GCTemplateCode"
        Me.GCTemplateCode.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCTemplateCode.Size = New System.Drawing.Size(555, 377)
        Me.GCTemplateCode.TabIndex = 0
        Me.GCTemplateCode.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVTemplateCode})
        '
        'GVTemplateCode
        '
        Me.GVTemplateCode.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdTemplateCode, Me.ColTemplateCode})
        Me.GVTemplateCode.GridControl = Me.GCTemplateCode
        Me.GVTemplateCode.Name = "GVTemplateCode"
        Me.GVTemplateCode.OptionsBehavior.Editable = False
        '
        'ColIdTemplateCode
        '
        Me.ColIdTemplateCode.Caption = "Id Template Code"
        Me.ColIdTemplateCode.FieldName = "id_template_code"
        Me.ColIdTemplateCode.Name = "ColIdTemplateCode"
        '
        'ColTemplateCode
        '
        Me.ColTemplateCode.Caption = "Template"
        Me.ColTemplateCode.FieldName = "template_code"
        Me.ColTemplateCode.Name = "ColTemplateCode"
        Me.ColTemplateCode.Visible = True
        Me.ColTemplateCode.VisibleIndex = 0
        Me.ColTemplateCode.Width = 189
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RepositoryItemCheckEdit1.ValueUnchecked = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'XTPCodeDet
        '
        Me.XTPCodeDet.Controls.Add(Me.GCTemplateCodeDet)
        Me.XTPCodeDet.Controls.Add(Me.DNTemplateCodeDet)
        Me.XTPCodeDet.Controls.Add(Me.PanelControl1)
        Me.XTPCodeDet.Controls.Add(Me.PCDeliveryTitle)
        Me.XTPCodeDet.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XTPCodeDet.Name = "XTPCodeDet"
        Me.XTPCodeDet.Size = New System.Drawing.Size(555, 377)
        Me.XTPCodeDet.Text = "Detail"
        '
        'GCTemplateCodeDet
        '
        Me.GCTemplateCodeDet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCTemplateCodeDet.Location = New System.Drawing.Point(0, 46)
        Me.GCTemplateCodeDet.MainView = Me.GVTemplateCodeDet
        Me.GCTemplateCodeDet.Name = "GCTemplateCodeDet"
        Me.GCTemplateCodeDet.Size = New System.Drawing.Size(555, 274)
        Me.GCTemplateCodeDet.TabIndex = 10
        Me.GCTemplateCodeDet.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVTemplateCodeDet})
        '
        'GVTemplateCodeDet
        '
        Me.GVTemplateCodeDet.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColCodeName})
        Me.GVTemplateCodeDet.GridControl = Me.GCTemplateCodeDet
        Me.GVTemplateCodeDet.Name = "GVTemplateCodeDet"
        Me.GVTemplateCodeDet.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVTemplateCodeDet.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVTemplateCodeDet.OptionsCustomization.AllowColumnMoving = False
        Me.GVTemplateCodeDet.OptionsCustomization.AllowFilter = False
        Me.GVTemplateCodeDet.OptionsCustomization.AllowQuickHideColumns = False
        Me.GVTemplateCodeDet.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GVTemplateCodeDet.OptionsView.EnableAppearanceEvenRow = True
        Me.GVTemplateCodeDet.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.GVTemplateCodeDet.OptionsView.ShowGroupPanel = False
        Me.GVTemplateCodeDet.OptionsView.ShowIndicator = False
        '
        'ColCodeName
        '
        Me.ColCodeName.AppearanceCell.Options.UseTextOptions = True
        Me.ColCodeName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColCodeName.AppearanceHeader.Options.UseTextOptions = True
        Me.ColCodeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColCodeName.Caption = "Code"
        Me.ColCodeName.FieldName = "code_name"
        Me.ColCodeName.Name = "ColCodeName"
        Me.ColCodeName.Visible = True
        Me.ColCodeName.VisibleIndex = 0
        '
        'DNTemplateCodeDet
        '
        Me.DNTemplateCodeDet.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DNTemplateCodeDet.Location = New System.Drawing.Point(0, 320)
        Me.DNTemplateCodeDet.Name = "DNTemplateCodeDet"
        Me.DNTemplateCodeDet.Size = New System.Drawing.Size(555, 24)
        Me.DNTemplateCodeDet.TabIndex = 9
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.White
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.Controls.Add(Me.BRevert)
        Me.PanelControl1.Controls.Add(Me.BSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 344)
        Me.PanelControl1.LookAndFeel.SkinName = "iMaginary"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(555, 33)
        Me.PanelControl1.TabIndex = 6
        '
        'BRevert
        '
        Me.BRevert.Dock = System.Windows.Forms.DockStyle.Right
        Me.BRevert.Location = New System.Drawing.Point(403, 2)
        Me.BRevert.Name = "BRevert"
        Me.BRevert.Size = New System.Drawing.Size(75, 29)
        Me.BRevert.TabIndex = 1
        Me.BRevert.Text = "Revert"
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.Location = New System.Drawing.Point(478, 2)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(75, 29)
        Me.BSave.TabIndex = 0
        Me.BSave.Text = "Save"
        '
        'PCDeliveryTitle
        '
        Me.PCDeliveryTitle.Appearance.BackColor = System.Drawing.Color.White
        Me.PCDeliveryTitle.Appearance.Options.UseBackColor = True
        Me.PCDeliveryTitle.Controls.Add(Me.LabelTemplate)
        Me.PCDeliveryTitle.Controls.Add(Me.LabelCodeTitle)
        Me.PCDeliveryTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCDeliveryTitle.Location = New System.Drawing.Point(0, 0)
        Me.PCDeliveryTitle.LookAndFeel.SkinName = "iMaginary"
        Me.PCDeliveryTitle.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PCDeliveryTitle.Name = "PCDeliveryTitle"
        Me.PCDeliveryTitle.Size = New System.Drawing.Size(555, 46)
        Me.PCDeliveryTitle.TabIndex = 5
        '
        'LabelTemplate
        '
        Me.LabelTemplate.Appearance.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTemplate.Location = New System.Drawing.Point(107, 11)
        Me.LabelTemplate.Name = "LabelTemplate"
        Me.LabelTemplate.Size = New System.Drawing.Size(6, 26)
        Me.LabelTemplate.TabIndex = 4
        Me.LabelTemplate.Text = "-"
        '
        'LabelCodeTitle
        '
        Me.LabelCodeTitle.Appearance.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCodeTitle.Location = New System.Drawing.Point(5, 11)
        Me.LabelCodeTitle.Name = "LabelCodeTitle"
        Me.LabelCodeTitle.Size = New System.Drawing.Size(96, 26)
        Me.LabelCodeTitle.TabIndex = 3
        Me.LabelCodeTitle.Text = "Template : "
        '
        'FormTemplateCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(581, 383)
        Me.Controls.Add(Me.XTCTemplateCode)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormTemplateCode"
        Me.ShowInTaskbar = False
        Me.Text = "Template Code"
        CType(Me.XTCTemplateCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCTemplateCode.ResumeLayout(False)
        Me.XTPCode.ResumeLayout(False)
        CType(Me.GCTemplateCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVTemplateCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPCodeDet.ResumeLayout(False)
        CType(Me.GCTemplateCodeDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVTemplateCodeDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PCDeliveryTitle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCDeliveryTitle.ResumeLayout(False)
        Me.PCDeliveryTitle.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XTCTemplateCode As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPCode As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCTemplateCode As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVTemplateCode As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdTemplateCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColTemplateCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents XTPCodeDet As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCTemplateCodeDet As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVTemplateCodeDet As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColCodeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DNTemplateCodeDet As DevExpress.XtraEditors.DataNavigator
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BRevert As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PCDeliveryTitle As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelTemplate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelCodeTitle As DevExpress.XtraEditors.LabelControl
End Class
