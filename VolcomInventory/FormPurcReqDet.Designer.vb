<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPurcReqDet
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPurcReqDet))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.GCItemList = New DevExpress.XtraGrid.GridControl()
        Me.GVItemList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.PanelControlTopRight = New DevExpress.XtraEditors.PanelControl()
        Me.TxtVirtualPosNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.DEForm = New DevExpress.XtraEditors.TextEdit()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TextEdit2 = New DevExpress.XtraEditors.TextEdit()
        Me.PanelControl5 = New DevExpress.XtraEditors.PanelControl()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BtnDel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GCItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlTopRight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlTopRight.SuspendLayout()
        CType(Me.TxtVirtualPosNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEForm.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 519)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(955, 45)
        Me.PanelControl1.TabIndex = 0
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.PanelControl4)
        Me.PanelControl2.Controls.Add(Me.PanelControlTopRight)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(955, 71)
        Me.PanelControl2.TabIndex = 1
        '
        'GCItemList
        '
        Me.GCItemList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCItemList.Location = New System.Drawing.Point(0, 110)
        Me.GCItemList.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCItemList.MainView = Me.GVItemList
        Me.GCItemList.Name = "GCItemList"
        Me.GCItemList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1})
        Me.GCItemList.Size = New System.Drawing.Size(955, 309)
        Me.GCItemList.TabIndex = 3
        Me.GCItemList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVItemList})
        '
        'GVItemList
        '
        Me.GVItemList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3})
        Me.GVItemList.GridControl = Me.GCItemList
        Me.GVItemList.Name = "GVItemList"
        Me.GVItemList.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVItemList.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVItemList.OptionsBehavior.ReadOnly = True
        Me.GVItemList.OptionsCustomization.AllowGroup = False
        Me.GVItemList.OptionsCustomization.AllowQuickHideColumns = False
        Me.GVItemList.OptionsView.ShowFooter = True
        Me.GVItemList.OptionsView.ShowGroupPanel = False
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "f0"
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'PanelControlTopRight
        '
        Me.PanelControlTopRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlTopRight.Controls.Add(Me.TxtVirtualPosNumber)
        Me.PanelControlTopRight.Controls.Add(Me.LabelControl5)
        Me.PanelControlTopRight.Controls.Add(Me.LabelControl7)
        Me.PanelControlTopRight.Controls.Add(Me.DEForm)
        Me.PanelControlTopRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControlTopRight.Location = New System.Drawing.Point(656, 2)
        Me.PanelControlTopRight.Name = "PanelControlTopRight"
        Me.PanelControlTopRight.Size = New System.Drawing.Size(297, 67)
        Me.PanelControlTopRight.TabIndex = 8936
        '
        'TxtVirtualPosNumber
        '
        Me.TxtVirtualPosNumber.EditValue = ""
        Me.TxtVirtualPosNumber.Location = New System.Drawing.Point(80, 36)
        Me.TxtVirtualPosNumber.Name = "TxtVirtualPosNumber"
        Me.TxtVirtualPosNumber.Properties.EditValueChangedDelay = 1
        Me.TxtVirtualPosNumber.Properties.ReadOnly = True
        Me.TxtVirtualPosNumber.Size = New System.Drawing.Size(207, 20)
        Me.TxtVirtualPosNumber.TabIndex = 8
        Me.TxtVirtualPosNumber.TabStop = False
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(6, 39)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl5.TabIndex = 155
        Me.LabelControl5.Text = "Number"
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(6, 13)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl7.TabIndex = 159
        Me.LabelControl7.Text = "Date Created"
        '
        'DEForm
        '
        Me.DEForm.EditValue = ""
        Me.DEForm.Location = New System.Drawing.Point(80, 10)
        Me.DEForm.Name = "DEForm"
        Me.DEForm.Properties.EditValueChangedDelay = 1
        Me.DEForm.Properties.ReadOnly = True
        Me.DEForm.Size = New System.Drawing.Size(207, 20)
        Me.DEForm.TabIndex = 162
        Me.DEForm.TabStop = False
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.BtnDel)
        Me.PanelControl3.Controls.Add(Me.BtnAdd)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(0, 71)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(955, 39)
        Me.PanelControl3.TabIndex = 4
        '
        'PanelControl4
        '
        Me.PanelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl4.Controls.Add(Me.TextEdit1)
        Me.PanelControl4.Controls.Add(Me.LabelControl1)
        Me.PanelControl4.Controls.Add(Me.LabelControl2)
        Me.PanelControl4.Controls.Add(Me.TextEdit2)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl4.Location = New System.Drawing.Point(2, 2)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(297, 67)
        Me.PanelControl4.TabIndex = 8937
        '
        'TextEdit1
        '
        Me.TextEdit1.EditValue = ""
        Me.TextEdit1.Location = New System.Drawing.Point(80, 36)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Properties.EditValueChangedDelay = 1
        Me.TextEdit1.Properties.ReadOnly = True
        Me.TextEdit1.Size = New System.Drawing.Size(207, 20)
        Me.TextEdit1.TabIndex = 8
        Me.TextEdit1.TabStop = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(6, 39)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl1.TabIndex = 155
        Me.LabelControl1.Text = "Departement"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(6, 13)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(67, 13)
        Me.LabelControl2.TabIndex = 159
        Me.LabelControl2.Text = "Requested By"
        '
        'TextEdit2
        '
        Me.TextEdit2.EditValue = ""
        Me.TextEdit2.Location = New System.Drawing.Point(80, 10)
        Me.TextEdit2.Name = "TextEdit2"
        Me.TextEdit2.Properties.EditValueChangedDelay = 1
        Me.TextEdit2.Properties.ReadOnly = True
        Me.TextEdit2.Size = New System.Drawing.Size(207, 20)
        Me.TextEdit2.TabIndex = 162
        Me.TextEdit2.TabStop = False
        '
        'PanelControl5
        '
        Me.PanelControl5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl5.Location = New System.Drawing.Point(0, 419)
        Me.PanelControl5.Name = "PanelControl5"
        Me.PanelControl5.Size = New System.Drawing.Size(955, 100)
        Me.PanelControl5.TabIndex = 5
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "20_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "8_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "23_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(3, "arrow_refresh.png")
        Me.LargeImageCollection.Images.SetKeyName(4, "check_mark.png")
        Me.LargeImageCollection.Images.SetKeyName(5, "gnome_application_exit (1).png")
        Me.LargeImageCollection.Images.SetKeyName(6, "printer_3.png")
        Me.LargeImageCollection.Images.SetKeyName(7, "save.png")
        Me.LargeImageCollection.Images.SetKeyName(8, "31_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(9, "18_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(10, "10_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(11, "18_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(12, "31_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(13, "folder-documents-icon.png")
        Me.LargeImageCollection.Images.SetKeyName(14, "mail_attachment.png")
        Me.LargeImageCollection.Images.SetKeyName(15, "attachment-icon.png")
        '
        'BtnDel
        '
        Me.BtnDel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDel.ImageIndex = 1
        Me.BtnDel.ImageList = Me.LargeImageCollection
        Me.BtnDel.Location = New System.Drawing.Point(780, 2)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(90, 35)
        Me.BtnDel.TabIndex = 8
        Me.BtnDel.TabStop = False
        Me.BtnDel.Text = "Delete"
        Me.BtnDel.Visible = False
        '
        'BtnAdd
        '
        Me.BtnAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAdd.ImageIndex = 0
        Me.BtnAdd.ImageList = Me.LargeImageCollection
        Me.BtnAdd.Location = New System.Drawing.Point(870, 2)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(83, 35)
        Me.BtnAdd.TabIndex = 6
        Me.BtnAdd.TabStop = False
        Me.BtnAdd.Text = "Add"
        Me.BtnAdd.Visible = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID Det"
        Me.GridColumn1.FieldName = "id_purc_req_det"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "GridColumn2"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Note"
        Me.GridColumn3.FieldName = "note"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'FormPurcReqDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(955, 564)
        Me.Controls.Add(Me.GCItemList)
        Me.Controls.Add(Me.PanelControl5)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "FormPurcReqDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Request Detail"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GCItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlTopRight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlTopRight.ResumeLayout(False)
        Me.PanelControlTopRight.PerformLayout()
        CType(Me.TxtVirtualPosNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEForm.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        Me.PanelControl4.PerformLayout()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCItemList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVItemList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents PanelControlTopRight As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TxtVirtualPosNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEForm As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEdit2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PanelControl5 As DevExpress.XtraEditors.PanelControl
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents BtnDel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
End Class
