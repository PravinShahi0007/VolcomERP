<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAccountingMappingList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAccountingMappingList))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.LReportMarkType = New DevExpress.XtraEditors.LabelControl
        Me.GCAcc = New DevExpress.XtraGrid.GridControl
        Me.GVAcc = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton
        Me.ImgBut = New DevExpress.Utils.ImageCollection(Me.components)
        Me.CEAutoPosting = New DevExpress.XtraEditors.CheckEdit
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton
        Me.BAdd = New DevExpress.XtraEditors.SimpleButton
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCAcc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAcc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.ImgBut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CEAutoPosting.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LReportMarkType)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(754, 48)
        Me.PanelControl1.TabIndex = 0
        '
        'LReportMarkType
        '
        Me.LReportMarkType.Appearance.Font = New System.Drawing.Font("Kalinga", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LReportMarkType.Location = New System.Drawing.Point(5, 12)
        Me.LReportMarkType.Name = "LReportMarkType"
        Me.LReportMarkType.Size = New System.Drawing.Size(182, 25)
        Me.LReportMarkType.TabIndex = 1
        Me.LReportMarkType.Text = "Report Mark Type Here"
        '
        'GCAcc
        '
        Me.GCAcc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAcc.Location = New System.Drawing.Point(0, 83)
        Me.GCAcc.MainView = Me.GVAcc
        Me.GCAcc.Name = "GCAcc"
        Me.GCAcc.Size = New System.Drawing.Size(754, 247)
        Me.GCAcc.TabIndex = 1
        Me.GCAcc.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAcc})
        '
        'GVAcc
        '
        Me.GVAcc.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn4, Me.GridColumn3, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7})
        Me.GVAcc.GridControl = Me.GCAcc
        Me.GVAcc.Name = "GVAcc"
        Me.GVAcc.OptionsBehavior.ReadOnly = True
        Me.GVAcc.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id Mapping"
        Me.GridColumn1.FieldName = "id_coa_mapping"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "ID Acc"
        Me.GridColumn2.FieldName = "id_acc"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Account"
        Me.GridColumn4.FieldName = "acc_name"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 0
        Me.GridColumn4.Width = 202
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Description"
        Me.GridColumn3.FieldName = "description"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 769
        '
        'GridColumn5
        '
        Me.GridColumn5.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn5.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn5.Caption = "Debit/Credit"
        Me.GridColumn5.FieldName = "dc"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 2
        Me.GridColumn5.Width = 209
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Id Dc"
        Me.GridColumn6.FieldName = "id_dc"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Is Acc Sup"
        Me.GridColumn7.FieldName = "is_acc_sup"
        Me.GridColumn7.Name = "GridColumn7"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BCancel)
        Me.PanelControl2.Controls.Add(Me.CEAutoPosting)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 330)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(754, 35)
        Me.PanelControl2.TabIndex = 2
        '
        'BCancel
        '
        Me.BCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCancel.ImageIndex = 5
        Me.BCancel.ImageList = Me.ImgBut
        Me.BCancel.Location = New System.Drawing.Point(664, 2)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(88, 31)
        Me.BCancel.TabIndex = 4
        Me.BCancel.Text = "Close"
        '
        'ImgBut
        '
        Me.ImgBut.ImageSize = New System.Drawing.Size(24, 24)
        Me.ImgBut.ImageStream = CType(resources.GetObject("ImgBut.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImgBut.Images.SetKeyName(0, "20_24x24.png")
        Me.ImgBut.Images.SetKeyName(1, "8_24x24.png")
        Me.ImgBut.Images.SetKeyName(2, "23_24x24.png")
        Me.ImgBut.Images.SetKeyName(3, "arrow_refresh.png")
        Me.ImgBut.Images.SetKeyName(4, "check_mark.png")
        Me.ImgBut.Images.SetKeyName(5, "gnome_application_exit (1).png")
        Me.ImgBut.Images.SetKeyName(6, "printer_3.png")
        Me.ImgBut.Images.SetKeyName(7, "save.png")
        Me.ImgBut.Images.SetKeyName(8, "31_24x24.png")
        Me.ImgBut.Images.SetKeyName(9, "18_24x24.png")
        Me.ImgBut.Images.SetKeyName(10, "attachment-icon.png")
        Me.ImgBut.Images.SetKeyName(11, "document_32.png")
        '
        'CEAutoPosting
        '
        Me.CEAutoPosting.Location = New System.Drawing.Point(12, 8)
        Me.CEAutoPosting.Name = "CEAutoPosting"
        Me.CEAutoPosting.Properties.Caption = "Auto Posting"
        Me.CEAutoPosting.Size = New System.Drawing.Size(93, 19)
        Me.CEAutoPosting.TabIndex = 2
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.SimpleButton3)
        Me.PanelControl3.Controls.Add(Me.SimpleButton2)
        Me.PanelControl3.Controls.Add(Me.BAdd)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(0, 48)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(754, 35)
        Me.PanelControl3.TabIndex = 3
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton3.ImageIndex = 1
        Me.SimpleButton3.ImageList = Me.ImgBut
        Me.SimpleButton3.Location = New System.Drawing.Point(488, 2)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(88, 31)
        Me.SimpleButton3.TabIndex = 6
        Me.SimpleButton3.Text = "Delete"
        Me.SimpleButton3.Visible = False
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton2.ImageIndex = 2
        Me.SimpleButton2.ImageList = Me.ImgBut
        Me.SimpleButton2.Location = New System.Drawing.Point(576, 2)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(88, 31)
        Me.SimpleButton2.TabIndex = 5
        Me.SimpleButton2.Text = "Edit"
        '
        'BAdd
        '
        Me.BAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAdd.ImageIndex = 0
        Me.BAdd.ImageList = Me.ImgBut
        Me.BAdd.Location = New System.Drawing.Point(664, 2)
        Me.BAdd.Name = "BAdd"
        Me.BAdd.Size = New System.Drawing.Size(88, 31)
        Me.BAdd.TabIndex = 4
        Me.BAdd.Text = "Add"
        Me.BAdd.Visible = False
        '
        'FormAccountingMappingList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 365)
        Me.Controls.Add(Me.GCAcc)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormAccountingMappingList"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mapping Account"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.GCAcc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAcc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.ImgBut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CEAutoPosting.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCAcc As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAcc As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CEAutoPosting As DevExpress.XtraEditors.CheckEdit
    Public WithEvents ImgBut As DevExpress.Utils.ImageCollection
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LReportMarkType As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
End Class
