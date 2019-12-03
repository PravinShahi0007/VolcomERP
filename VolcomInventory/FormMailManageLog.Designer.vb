<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMailManageLog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMailManageLog))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtEmailNo = New DevExpress.XtraEditors.TextEdit()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_mail_manage = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnlog_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_user = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnemployee_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_mail_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnmail_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TxtEmailNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.TxtEmailNo)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.BtnClose)
        Me.PanelControl1.Controls.Add(Me.BtnPrint)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 293)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(507, 45)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(423, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(82, 41)
        Me.BtnPrint.TabIndex = 0
        Me.BtnPrint.Text = "Print"
        '
        'BtnClose
        '
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(341, 2)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(82, 41)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(12, 16)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(47, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Email No"
        '
        'TxtEmailNo
        '
        Me.TxtEmailNo.Enabled = False
        Me.TxtEmailNo.Location = New System.Drawing.Point(65, 13)
        Me.TxtEmailNo.Name = "TxtEmailNo"
        Me.TxtEmailNo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEmailNo.Properties.Appearance.Options.UseFont = True
        Me.TxtEmailNo.Size = New System.Drawing.Size(167, 20)
        Me.TxtEmailNo.TabIndex = 1
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit1})
        Me.GCData.Size = New System.Drawing.Size(507, 293)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_mail_manage, Me.GridColumnnumber, Me.GridColumnlog_date, Me.GridColumnid_user, Me.GridColumnemployee_name, Me.GridColumnid_mail_status, Me.GridColumnmail_status, Me.GridColumnnote})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsPrint.AllowMultilineHeaders = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        Me.GVData.RowHeight = 35
        '
        'GridColumnid_mail_manage
        '
        Me.GridColumnid_mail_manage.Caption = "id_mail_manage"
        Me.GridColumnid_mail_manage.FieldName = "id_mail_manage"
        Me.GridColumnid_mail_manage.Name = "GridColumnid_mail_manage"
        '
        'GridColumnnumber
        '
        Me.GridColumnnumber.Caption = "Number"
        Me.GridColumnnumber.FieldName = "number"
        Me.GridColumnnumber.Name = "GridColumnnumber"
        Me.GridColumnnumber.Visible = True
        Me.GridColumnnumber.VisibleIndex = 0
        '
        'GridColumnlog_date
        '
        Me.GridColumnlog_date.Caption = "Log Date"
        Me.GridColumnlog_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GridColumnlog_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnlog_date.FieldName = "log_date"
        Me.GridColumnlog_date.Name = "GridColumnlog_date"
        Me.GridColumnlog_date.Visible = True
        Me.GridColumnlog_date.VisibleIndex = 1
        '
        'GridColumnid_user
        '
        Me.GridColumnid_user.Caption = "id_user"
        Me.GridColumnid_user.FieldName = "id_user"
        Me.GridColumnid_user.Name = "GridColumnid_user"
        '
        'GridColumnemployee_name
        '
        Me.GridColumnemployee_name.Caption = "Updated By"
        Me.GridColumnemployee_name.FieldName = "employee_name"
        Me.GridColumnemployee_name.Name = "GridColumnemployee_name"
        Me.GridColumnemployee_name.Visible = True
        Me.GridColumnemployee_name.VisibleIndex = 2
        '
        'GridColumnid_mail_status
        '
        Me.GridColumnid_mail_status.Caption = "id_mail_status"
        Me.GridColumnid_mail_status.FieldName = "id_mail_status"
        Me.GridColumnid_mail_status.Name = "GridColumnid_mail_status"
        '
        'GridColumnmail_status
        '
        Me.GridColumnmail_status.Caption = "Status"
        Me.GridColumnmail_status.FieldName = "mail_status"
        Me.GridColumnmail_status.Name = "GridColumnmail_status"
        Me.GridColumnmail_status.Visible = True
        Me.GridColumnmail_status.VisibleIndex = 3
        '
        'GridColumnnote
        '
        Me.GridColumnnote.Caption = "Note"
        Me.GridColumnnote.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.GridColumnnote.FieldName = "note"
        Me.GridColumnnote.Name = "GridColumnnote"
        Me.GridColumnnote.Visible = True
        Me.GridColumnnote.VisibleIndex = 4
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'FormMailManageLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(507, 338)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMailManageLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mail Management Log"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.TxtEmailNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtEmailNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_mail_manage As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnlog_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_user As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnemployee_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_mail_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnmail_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
End Class
