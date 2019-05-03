<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProductionHO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProductionHO))
        Me.XTCHO = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPRegisterList = New DevExpress.XtraTab.XtraTabPage()
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.GVList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControlNav = New DevExpress.XtraEditors.PanelControl()
        Me.XTPDetail = New DevExpress.XtraTab.XtraTabPage()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnViewPending = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControlDate = New DevExpress.XtraEditors.PanelControl()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.XTCHO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCHO.SuspendLayout()
        Me.XTPRegisterList.SuspendLayout()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNav.SuspendLayout()
        CType(Me.PanelControlDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlDate.SuspendLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCHO
        '
        Me.XTCHO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCHO.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCHO.Location = New System.Drawing.Point(0, 0)
        Me.XTCHO.Name = "XTCHO"
        Me.XTCHO.SelectedTabPage = Me.XTPRegisterList
        Me.XTCHO.Size = New System.Drawing.Size(810, 500)
        Me.XTCHO.TabIndex = 0
        Me.XTCHO.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPRegisterList, Me.XTPDetail})
        '
        'XTPRegisterList
        '
        Me.XTPRegisterList.Controls.Add(Me.GCList)
        Me.XTPRegisterList.Controls.Add(Me.PanelControlNav)
        Me.XTPRegisterList.Name = "XTPRegisterList"
        Me.XTPRegisterList.Size = New System.Drawing.Size(804, 472)
        Me.XTPRegisterList.Text = "Register List"
        '
        'GCList
        '
        Me.GCList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCList.Location = New System.Drawing.Point(0, 43)
        Me.GCList.MainView = Me.GVList
        Me.GCList.Name = "GCList"
        Me.GCList.Size = New System.Drawing.Size(804, 429)
        Me.GCList.TabIndex = 1
        Me.GCList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVList})
        '
        'GVList
        '
        Me.GVList.GridControl = Me.GCList
        Me.GVList.Name = "GVList"
        Me.GVList.OptionsFind.AlwaysVisible = True
        Me.GVList.OptionsView.ShowGroupPanel = False
        '
        'PanelControlNav
        '
        Me.PanelControlNav.Controls.Add(Me.PanelControlDate)
        Me.PanelControlNav.Controls.Add(Me.BtnView)
        Me.PanelControlNav.Controls.Add(Me.BtnViewPending)
        Me.PanelControlNav.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlNav.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlNav.Name = "PanelControlNav"
        Me.PanelControlNav.Size = New System.Drawing.Size(804, 43)
        Me.PanelControlNav.TabIndex = 0
        '
        'XTPDetail
        '
        Me.XTPDetail.Name = "XTPDetail"
        Me.XTPDetail.Size = New System.Drawing.Size(804, 472)
        Me.XTPDetail.Text = "Detail"
        '
        'BtnView
        '
        Me.BtnView.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnView.Image = CType(resources.GetObject("BtnView.Image"), System.Drawing.Image)
        Me.BtnView.Location = New System.Drawing.Point(544, 2)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(84, 39)
        Me.BtnView.TabIndex = 0
        Me.BtnView.Text = "View"
        '
        'BtnViewPending
        '
        Me.BtnViewPending.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnViewPending.Image = CType(resources.GetObject("BtnViewPending.Image"), System.Drawing.Image)
        Me.BtnViewPending.Location = New System.Drawing.Point(628, 2)
        Me.BtnViewPending.Name = "BtnViewPending"
        Me.BtnViewPending.Size = New System.Drawing.Size(174, 39)
        Me.BtnViewPending.TabIndex = 1
        Me.BtnViewPending.Text = "View Pending Notification"
        '
        'PanelControlDate
        '
        Me.PanelControlDate.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlDate.Controls.Add(Me.DEUntil)
        Me.PanelControlDate.Controls.Add(Me.DEFrom)
        Me.PanelControlDate.Controls.Add(Me.LabelControl2)
        Me.PanelControlDate.Controls.Add(Me.LabelControl3)
        Me.PanelControlDate.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControlDate.Location = New System.Drawing.Point(245, 2)
        Me.PanelControlDate.Name = "PanelControlDate"
        Me.PanelControlDate.Size = New System.Drawing.Size(299, 39)
        Me.PanelControlDate.TabIndex = 2
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(181, 9)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntil.Size = New System.Drawing.Size(111, 20)
        Me.DEUntil.TabIndex = 8899
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(37, 9)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFrom.Size = New System.Drawing.Size(111, 20)
        Me.DEFrom.TabIndex = 8898
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(154, 12)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl2.TabIndex = 8897
        Me.LabelControl2.Text = "Until"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(7, 12)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl3.TabIndex = 8896
        Me.LabelControl3.Text = "From"
        '
        'FormProductionHO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(810, 500)
        Me.Controls.Add(Me.XTCHO)
        Me.MinimizeBox = False
        Me.Name = "FormProductionHO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Handover Report"
        CType(Me.XTCHO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCHO.ResumeLayout(False)
        Me.XTPRegisterList.ResumeLayout(False)
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNav.ResumeLayout(False)
        CType(Me.PanelControlDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlDate.ResumeLayout(False)
        Me.PanelControlDate.PerformLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCHO As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPRegisterList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPDetail As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControlNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControlDate As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnViewPending As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
End Class
