<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMKDEvent
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
        Me.XTCEvent = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPList = New DevExpress.XtraTab.XtraTabPage()
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.GVList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControlList = New DevExpress.XtraEditors.PanelControl()
        Me.BtnViewList = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEOption = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPDetail = New DevExpress.XtraTab.XtraTabPage()
        CType(Me.XTCEvent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCEvent.SuspendLayout()
        Me.XTPList.SuspendLayout()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlList.SuspendLayout()
        CType(Me.SLEOption.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCEvent
        '
        Me.XTCEvent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCEvent.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCEvent.Location = New System.Drawing.Point(0, 0)
        Me.XTCEvent.Name = "XTCEvent"
        Me.XTCEvent.SelectedTabPage = Me.XTPList
        Me.XTCEvent.Size = New System.Drawing.Size(651, 419)
        Me.XTCEvent.TabIndex = 0
        Me.XTCEvent.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPList, Me.XTPDetail})
        '
        'XTPList
        '
        Me.XTPList.Controls.Add(Me.GCList)
        Me.XTPList.Controls.Add(Me.PanelControlList)
        Me.XTPList.Name = "XTPList"
        Me.XTPList.Size = New System.Drawing.Size(645, 391)
        Me.XTPList.Text = "List"
        '
        'GCList
        '
        Me.GCList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCList.Location = New System.Drawing.Point(0, 54)
        Me.GCList.MainView = Me.GVList
        Me.GCList.Name = "GCList"
        Me.GCList.Size = New System.Drawing.Size(645, 337)
        Me.GCList.TabIndex = 1
        Me.GCList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVList})
        '
        'GVList
        '
        Me.GVList.GridControl = Me.GCList
        Me.GVList.Name = "GVList"
        Me.GVList.OptionsBehavior.ReadOnly = True
        Me.GVList.OptionsFind.AlwaysVisible = True
        Me.GVList.OptionsView.ColumnAutoWidth = False
        Me.GVList.OptionsView.ShowGroupPanel = False
        '
        'PanelControlList
        '
        Me.PanelControlList.Controls.Add(Me.BtnViewList)
        Me.PanelControlList.Controls.Add(Me.LabelControl2)
        Me.PanelControlList.Controls.Add(Me.SLEOption)
        Me.PanelControlList.Controls.Add(Me.LabelControl1)
        Me.PanelControlList.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlList.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlList.Name = "PanelControlList"
        Me.PanelControlList.Size = New System.Drawing.Size(645, 54)
        Me.PanelControlList.TabIndex = 0
        '
        'BtnViewList
        '
        Me.BtnViewList.Location = New System.Drawing.Point(223, 16)
        Me.BtnViewList.Name = "BtnViewList"
        Me.BtnViewList.Size = New System.Drawing.Size(75, 23)
        Me.BtnViewList.TabIndex = 1
        Me.BtnViewList.Text = "View Data"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(306, 21)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(0, 13)
        Me.LabelControl2.TabIndex = 2
        '
        'SLEOption
        '
        Me.SLEOption.Location = New System.Drawing.Point(54, 18)
        Me.SLEOption.Name = "SLEOption"
        Me.SLEOption.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEOption.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEOption.Size = New System.Drawing.Size(164, 20)
        Me.SLEOption.TabIndex = 1
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(16, 21)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(32, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Option"
        '
        'XTPDetail
        '
        Me.XTPDetail.Name = "XTPDetail"
        Me.XTPDetail.Size = New System.Drawing.Size(645, 391)
        Me.XTPDetail.Text = "Detail"
        '
        'FormMKDEvent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(651, 419)
        Me.Controls.Add(Me.XTCEvent)
        Me.Name = "FormMKDEvent"
        Me.Text = "End Of Season Sale"
        CType(Me.XTCEvent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCEvent.ResumeLayout(False)
        Me.XTPList.ResumeLayout(False)
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlList.ResumeLayout(False)
        Me.PanelControlList.PerformLayout()
        CType(Me.SLEOption.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCEvent As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPDetail As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControlList As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnViewList As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEOption As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVList As DevExpress.XtraGrid.Views.Grid.GridView
End Class
