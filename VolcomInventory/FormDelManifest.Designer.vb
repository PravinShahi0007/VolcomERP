<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDelManifest
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
        Me.XTCDelManifest = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPList = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPDetail = New DevExpress.XtraTab.XtraTabPage()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLUE3PL = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SBView = New DevExpress.XtraEditors.SimpleButton()
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.GVList = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.XTCDelManifest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCDelManifest.SuspendLayout()
        Me.XTPList.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLUE3PL.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCDelManifest
        '
        Me.XTCDelManifest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCDelManifest.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCDelManifest.Location = New System.Drawing.Point(0, 43)
        Me.XTCDelManifest.Name = "XTCDelManifest"
        Me.XTCDelManifest.SelectedTabPage = Me.XTPList
        Me.XTCDelManifest.Size = New System.Drawing.Size(766, 459)
        Me.XTCDelManifest.TabIndex = 0
        Me.XTCDelManifest.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPList, Me.XTPDetail})
        '
        'XTPList
        '
        Me.XTPList.Controls.Add(Me.GCList)
        Me.XTPList.Name = "XTPList"
        Me.XTPList.Size = New System.Drawing.Size(760, 431)
        Me.XTPList.Text = "Created List"
        '
        'XTPDetail
        '
        Me.XTPDetail.Name = "XTPDetail"
        Me.XTPDetail.Size = New System.Drawing.Size(760, 429)
        Me.XTPDetail.Text = "Detail Manifest"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SBView)
        Me.PanelControl1.Controls.Add(Me.SLUE3PL)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(766, 43)
        Me.PanelControl1.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(17, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "3PL"
        '
        'SLUE3PL
        '
        Me.SLUE3PL.Location = New System.Drawing.Point(40, 12)
        Me.SLUE3PL.Name = "SLUE3PL"
        Me.SLUE3PL.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUE3PL.Properties.View = Me.SearchLookUpEdit1View
        Me.SLUE3PL.Size = New System.Drawing.Size(200, 20)
        Me.SLUE3PL.TabIndex = 1
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'SBView
        '
        Me.SBView.Location = New System.Drawing.Point(246, 10)
        Me.SBView.Name = "SBView"
        Me.SBView.Size = New System.Drawing.Size(75, 23)
        Me.SBView.TabIndex = 2
        Me.SBView.Text = "View"
        '
        'GCList
        '
        Me.GCList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCList.Location = New System.Drawing.Point(0, 0)
        Me.GCList.MainView = Me.GVList
        Me.GCList.Name = "GCList"
        Me.GCList.Size = New System.Drawing.Size(760, 431)
        Me.GCList.TabIndex = 0
        Me.GCList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVList})
        '
        'GVList
        '
        Me.GVList.GridControl = Me.GCList
        Me.GVList.Name = "GVList"
        Me.GVList.OptionsView.ShowGroupPanel = False
        '
        'FormDelManifest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(766, 502)
        Me.Controls.Add(Me.XTCDelManifest)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormDelManifest"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Outbound Delivery Manifest"
        CType(Me.XTCDelManifest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCDelManifest.ResumeLayout(False)
        Me.XTPList.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLUE3PL.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCDelManifest As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPDetail As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SBView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLUE3PL As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVList As DevExpress.XtraGrid.Views.Grid.GridView
End Class
