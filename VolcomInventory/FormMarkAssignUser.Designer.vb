<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMarkAssignUser
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMarkAssignUser))
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        Me.BAdd = New DevExpress.XtraEditors.SimpleButton
        Me.Bdel = New DevExpress.XtraEditors.SimpleButton
        Me.LStatus = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.LReport = New DevExpress.XtraEditors.LabelControl
        Me.GCUser = New DevExpress.XtraGrid.GridControl
        Me.GVUser = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdUser = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColUser = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColLevel = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColIdMarkAsgUser = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnLeadTime = New DevExpress.XtraGrid.Columns.GridColumn
        Me.SELevel = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GCUser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVUser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SELevel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "20_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "8_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "23_24x24.png")
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.GCUser)
        Me.GroupControl1.Controls.Add(Me.BAdd)
        Me.GroupControl1.Controls.Add(Me.Bdel)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl1.Location = New System.Drawing.Point(0, 78)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(651, 281)
        Me.GroupControl1.TabIndex = 5
        Me.GroupControl1.Text = "User"
        '
        'BAdd
        '
        Me.BAdd.ImageIndex = 0
        Me.BAdd.ImageList = Me.LargeImageCollection
        Me.BAdd.Location = New System.Drawing.Point(548, 8)
        Me.BAdd.Name = "BAdd"
        Me.BAdd.Size = New System.Drawing.Size(91, 29)
        Me.BAdd.TabIndex = 23
        Me.BAdd.Text = "Add"
        '
        'Bdel
        '
        Me.Bdel.ImageIndex = 1
        Me.Bdel.ImageList = Me.LargeImageCollection
        Me.Bdel.Location = New System.Drawing.Point(451, 8)
        Me.Bdel.Name = "Bdel"
        Me.Bdel.Size = New System.Drawing.Size(91, 29)
        Me.Bdel.TabIndex = 22
        Me.Bdel.Text = "Delete"
        '
        'LStatus
        '
        Me.LStatus.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.LStatus.Location = New System.Drawing.Point(141, 41)
        Me.LStatus.Name = "LStatus"
        Me.LStatus.Size = New System.Drawing.Size(5, 16)
        Me.LStatus.TabIndex = 26
        Me.LStatus.Text = "-"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl2.Location = New System.Drawing.Point(12, 41)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(123, 16)
        Me.LabelControl2.TabIndex = 25
        Me.LabelControl2.Text = "Assign on Status : "
        '
        'LReport
        '
        Me.LReport.Appearance.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LReport.Location = New System.Drawing.Point(12, 12)
        Me.LReport.Name = "LReport"
        Me.LReport.Size = New System.Drawing.Size(65, 23)
        Me.LReport.TabIndex = 24
        Me.LReport.Text = "Report"
        '
        'GCUser
        '
        Me.GCUser.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GCUser.Location = New System.Drawing.Point(22, 43)
        Me.GCUser.MainView = Me.GVUser
        Me.GCUser.Name = "GCUser"
        Me.GCUser.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.SELevel})
        Me.GCUser.Size = New System.Drawing.Size(627, 236)
        Me.GCUser.TabIndex = 24
        Me.GCUser.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVUser})
        '
        'GVUser
        '
        Me.GVUser.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdUser, Me.ColUser, Me.ColLevel, Me.ColIdMarkAsgUser, Me.GridColumnLeadTime})
        Me.GVUser.GridControl = Me.GCUser
        Me.GVUser.Name = "GVUser"
        Me.GVUser.OptionsBehavior.Editable = False
        Me.GVUser.OptionsView.ShowGroupPanel = False
        '
        'ColIdUser
        '
        Me.ColIdUser.Caption = "Id User"
        Me.ColIdUser.FieldName = "id_user"
        Me.ColIdUser.Name = "ColIdUser"
        '
        'ColUser
        '
        Me.ColUser.Caption = "User"
        Me.ColUser.FieldName = "employee_name"
        Me.ColUser.Name = "ColUser"
        Me.ColUser.Visible = True
        Me.ColUser.VisibleIndex = 1
        Me.ColUser.Width = 516
        '
        'ColLevel
        '
        Me.ColLevel.AppearanceCell.Options.UseTextOptions = True
        Me.ColLevel.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColLevel.AppearanceHeader.Options.UseTextOptions = True
        Me.ColLevel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColLevel.Caption = "Level"
        Me.ColLevel.FieldName = "level"
        Me.ColLevel.Name = "ColLevel"
        Me.ColLevel.Visible = True
        Me.ColLevel.VisibleIndex = 0
        Me.ColLevel.Width = 100
        '
        'ColIdMarkAsgUser
        '
        Me.ColIdMarkAsgUser.Caption = "Id mark Asg User"
        Me.ColIdMarkAsgUser.FieldName = "id_mark_asg_user"
        Me.ColIdMarkAsgUser.Name = "ColIdMarkAsgUser"
        '
        'GridColumnLeadTime
        '
        Me.GridColumnLeadTime.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnLeadTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnLeadTime.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnLeadTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnLeadTime.Caption = "Lead Time"
        Me.GridColumnLeadTime.FieldName = "lead_time"
        Me.GridColumnLeadTime.Name = "GridColumnLeadTime"
        Me.GridColumnLeadTime.Visible = True
        Me.GridColumnLeadTime.VisibleIndex = 2
        Me.GridColumnLeadTime.Width = 150
        '
        'SELevel
        '
        Me.SELevel.AutoHeight = False
        Me.SELevel.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.SELevel.Name = "SELevel"
        '
        'FormMarkAssignUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(651, 359)
        Me.Controls.Add(Me.LStatus)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMarkAssignUser"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Assign User"
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GCUser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVUser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SELevel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Bdel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LStatus As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LReport As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCUser As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVUser As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdUser As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColUser As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColLevel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdMarkAsgUser As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLeadTime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SELevel As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
End Class
