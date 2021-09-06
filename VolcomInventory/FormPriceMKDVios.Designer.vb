<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPriceMKDVios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPriceMKDVios))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnImportToXLS = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.DEEffDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtProposeNo = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BtnUpdatePrice = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnLastPropose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnHistory = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.DEEffDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEffDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtProposeNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnImportToXLS)
        Me.PanelControl1.Controls.Add(Me.BtnHistory)
        Me.PanelControl1.Controls.Add(Me.PanelControl2)
        Me.PanelControl1.Controls.Add(Me.BtnLastPropose)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(860, 42)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnImportToXLS
        '
        Me.BtnImportToXLS.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnImportToXLS.Image = CType(resources.GetObject("BtnImportToXLS.Image"), System.Drawing.Image)
        Me.BtnImportToXLS.Location = New System.Drawing.Point(211, 2)
        Me.BtnImportToXLS.Name = "BtnImportToXLS"
        Me.BtnImportToXLS.Size = New System.Drawing.Size(116, 38)
        Me.BtnImportToXLS.TabIndex = 3
        Me.BtnImportToXLS.Text = "Export as XLS"
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.DEEffDate)
        Me.PanelControl2.Controls.Add(Me.LabelControl2)
        Me.PanelControl2.Controls.Add(Me.TxtProposeNo)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl2.Location = New System.Drawing.Point(422, 2)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(436, 38)
        Me.PanelControl2.TabIndex = 2
        '
        'DEEffDate
        '
        Me.DEEffDate.EditValue = Nothing
        Me.DEEffDate.Location = New System.Drawing.Point(255, 9)
        Me.DEEffDate.Name = "DEEffDate"
        Me.DEEffDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEffDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEffDate.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEEffDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEEffDate.Size = New System.Drawing.Size(173, 20)
        Me.DEEffDate.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(180, 12)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Effective Date"
        '
        'TxtProposeNo
        '
        Me.TxtProposeNo.Enabled = False
        Me.TxtProposeNo.Location = New System.Drawing.Point(31, 9)
        Me.TxtProposeNo.Name = "TxtProposeNo"
        Me.TxtProposeNo.Size = New System.Drawing.Size(143, 20)
        Me.TxtProposeNo.TabIndex = 2
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(8, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(17, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "No."
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 42)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(860, 379)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'BtnUpdatePrice
        '
        Me.BtnUpdatePrice.Appearance.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BtnUpdatePrice.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnUpdatePrice.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnUpdatePrice.Appearance.Options.UseBackColor = True
        Me.BtnUpdatePrice.Appearance.Options.UseFont = True
        Me.BtnUpdatePrice.Appearance.Options.UseForeColor = True
        Me.BtnUpdatePrice.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnUpdatePrice.Location = New System.Drawing.Point(0, 421)
        Me.BtnUpdatePrice.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnUpdatePrice.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BtnUpdatePrice.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnUpdatePrice.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnUpdatePrice.Name = "BtnUpdatePrice"
        Me.BtnUpdatePrice.Size = New System.Drawing.Size(860, 32)
        Me.BtnUpdatePrice.TabIndex = 19
        Me.BtnUpdatePrice.Text = "Update Price"
        Me.BtnUpdatePrice.Visible = False
        '
        'BtnLastPropose
        '
        Me.BtnLastPropose.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnLastPropose.Image = CType(resources.GetObject("BtnLastPropose.Image"), System.Drawing.Image)
        Me.BtnLastPropose.Location = New System.Drawing.Point(2, 2)
        Me.BtnLastPropose.Name = "BtnLastPropose"
        Me.BtnLastPropose.Size = New System.Drawing.Size(125, 38)
        Me.BtnLastPropose.TabIndex = 4
        Me.BtnLastPropose.Text = "Latest Proposal"
        '
        'BtnHistory
        '
        Me.BtnHistory.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnHistory.Image = CType(resources.GetObject("BtnHistory.Image"), System.Drawing.Image)
        Me.BtnHistory.Location = New System.Drawing.Point(127, 2)
        Me.BtnHistory.Name = "BtnHistory"
        Me.BtnHistory.Size = New System.Drawing.Size(84, 38)
        Me.BtnHistory.TabIndex = 5
        Me.BtnHistory.Text = "History"
        '
        'FormPriceMKDVios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(860, 453)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.BtnUpdatePrice)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormPriceMKDVios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VIOS - Sync Price"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.DEEffDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEffDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtProposeNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DEEffDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtProposeNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnUpdatePrice As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnImportToXLS As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnHistory As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnLastPropose As DevExpress.XtraEditors.SimpleButton
End Class
