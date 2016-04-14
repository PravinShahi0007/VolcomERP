<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInfoPLSample
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.LabelSubTitle = New DevExpress.XtraEditors.LabelControl
        Me.LabelTitle = New DevExpress.XtraEditors.LabelControl
        Me.PCClose = New DevExpress.XtraEditors.PanelControl
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        Me.GCPL = New DevExpress.XtraGrid.GridControl
        Me.GVPL = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnIdPLSample = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdContactFrom = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdCompContactTo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdSamplePurcRec = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPLNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnFrom = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnTo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPLCategory = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPLDate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPLNote = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl
        Me.GCListPurchase = New DevExpress.XtraGrid.GridControl
        Me.GVListPurchase = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColIdSamplePurcRecDet = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColCode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColSize = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnRecNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColQtyReceived = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQtyNote = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnQtyIssue = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PCClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCClose.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GCPL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.Blue
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.Controls.Add(Me.LabelSubTitle)
        Me.PanelControl1.Controls.Add(Me.LabelTitle)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(692, 59)
        Me.PanelControl1.TabIndex = 30
        '
        'LabelSubTitle
        '
        Me.LabelSubTitle.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSubTitle.Location = New System.Drawing.Point(12, 32)
        Me.LabelSubTitle.Name = "LabelSubTitle"
        Me.LabelSubTitle.Size = New System.Drawing.Size(128, 15)
        Me.LabelSubTitle.TabIndex = 30
        Me.LabelSubTitle.Text = "Receiving Number : xxx "
        '
        'LabelTitle
        '
        Me.LabelTitle.Appearance.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitle.Location = New System.Drawing.Point(12, 10)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(133, 23)
        Me.LabelTitle.TabIndex = 29
        Me.LabelTitle.Text = "Packing List Data"
        '
        'PCClose
        '
        Me.PCClose.Controls.Add(Me.BtnClose)
        Me.PCClose.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PCClose.Location = New System.Drawing.Point(0, 400)
        Me.PCClose.LookAndFeel.SkinName = "Blue"
        Me.PCClose.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PCClose.Name = "PCClose"
        Me.PCClose.Size = New System.Drawing.Size(692, 50)
        Me.PCClose.TabIndex = 31
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(605, 15)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(75, 23)
        Me.BtnClose.TabIndex = 0
        Me.BtnClose.Text = "Close"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 59)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GroupControl1)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GroupControl2)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(692, 341)
        Me.SplitContainerControl1.SplitterPosition = 170
        Me.SplitContainerControl1.TabIndex = 32
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.GCPL)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(692, 170)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "PL Number"
        '
        'GCPL
        '
        Me.GCPL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPL.Location = New System.Drawing.Point(22, 2)
        Me.GCPL.MainView = Me.GVPL
        Me.GCPL.Name = "GCPL"
        Me.GCPL.Size = New System.Drawing.Size(668, 166)
        Me.GCPL.TabIndex = 1
        Me.GCPL.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPL})
        '
        'GVPL
        '
        Me.GVPL.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdPLSample, Me.GridColumnIdContactFrom, Me.GridColumnIdCompContactTo, Me.GridColumnIdSamplePurcRec, Me.GridColumnPLNumber, Me.GridColumnFrom, Me.GridColumnTo, Me.GridColumnPLCategory, Me.GridColumnPLDate, Me.GridColumnPLNote})
        Me.GVPL.GridControl = Me.GCPL
        Me.GVPL.Name = "GVPL"
        Me.GVPL.OptionsBehavior.Editable = False
        Me.GVPL.OptionsFind.AlwaysVisible = True
        Me.GVPL.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdPLSample
        '
        Me.GridColumnIdPLSample.Caption = "Id PL Sample"
        Me.GridColumnIdPLSample.FieldName = "id_pl_sample_purc"
        Me.GridColumnIdPLSample.Name = "GridColumnIdPLSample"
        '
        'GridColumnIdContactFrom
        '
        Me.GridColumnIdContactFrom.Caption = "GridColumnIdContacctFrom"
        Me.GridColumnIdContactFrom.FieldName = "id_comp_contact_from"
        Me.GridColumnIdContactFrom.Name = "GridColumnIdContactFrom"
        '
        'GridColumnIdCompContactTo
        '
        Me.GridColumnIdCompContactTo.Caption = "GridColumnIdCompContactTo"
        Me.GridColumnIdCompContactTo.FieldName = "id_comp_contact_to"
        Me.GridColumnIdCompContactTo.Name = "GridColumnIdCompContactTo"
        '
        'GridColumnIdSamplePurcRec
        '
        Me.GridColumnIdSamplePurcRec.Caption = "GridColumnIdSamplePurcRec"
        Me.GridColumnIdSamplePurcRec.FieldName = "id_sample_purc_rec"
        Me.GridColumnIdSamplePurcRec.Name = "GridColumnIdSamplePurcRec"
        '
        'GridColumnPLNumber
        '
        Me.GridColumnPLNumber.Caption = "Number"
        Me.GridColumnPLNumber.FieldName = "pl_sample_purc_number"
        Me.GridColumnPLNumber.Name = "GridColumnPLNumber"
        Me.GridColumnPLNumber.Visible = True
        Me.GridColumnPLNumber.VisibleIndex = 0
        '
        'GridColumnFrom
        '
        Me.GridColumnFrom.Caption = "From"
        Me.GridColumnFrom.FieldName = "comp_name_from"
        Me.GridColumnFrom.Name = "GridColumnFrom"
        Me.GridColumnFrom.Visible = True
        Me.GridColumnFrom.VisibleIndex = 1
        '
        'GridColumnTo
        '
        Me.GridColumnTo.Caption = "To"
        Me.GridColumnTo.FieldName = "comp_name_to"
        Me.GridColumnTo.Name = "GridColumnTo"
        Me.GridColumnTo.Visible = True
        Me.GridColumnTo.VisibleIndex = 2
        '
        'GridColumnPLCategory
        '
        Me.GridColumnPLCategory.Caption = "Source"
        Me.GridColumnPLCategory.FieldName = "pl_category"
        Me.GridColumnPLCategory.Name = "GridColumnPLCategory"
        Me.GridColumnPLCategory.Visible = True
        Me.GridColumnPLCategory.VisibleIndex = 3
        '
        'GridColumnPLDate
        '
        Me.GridColumnPLDate.Caption = "Created Date"
        Me.GridColumnPLDate.FieldName = "pl_sample_purc_date"
        Me.GridColumnPLDate.Name = "GridColumnPLDate"
        Me.GridColumnPLDate.Visible = True
        Me.GridColumnPLDate.VisibleIndex = 4
        '
        'GridColumnPLNote
        '
        Me.GridColumnPLNote.Caption = "Note"
        Me.GridColumnPLNote.FieldName = "pl_sample_purc_note"
        Me.GridColumnPLNote.Name = "GridColumnPLNote"
        Me.GridColumnPLNote.Visible = True
        Me.GridColumnPLNote.VisibleIndex = 5
        '
        'GroupControl2
        '
        Me.GroupControl2.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl2.Controls.Add(Me.GCListPurchase)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(692, 166)
        Me.GroupControl2.TabIndex = 1
        Me.GroupControl2.Text = "Detail PL"
        '
        'GCListPurchase
        '
        Me.GCListPurchase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListPurchase.Location = New System.Drawing.Point(22, 2)
        Me.GCListPurchase.MainView = Me.GVListPurchase
        Me.GCListPurchase.Name = "GCListPurchase"
        Me.GCListPurchase.Size = New System.Drawing.Size(668, 162)
        Me.GCListPurchase.TabIndex = 5
        Me.GCListPurchase.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListPurchase})
        '
        'GVListPurchase
        '
        Me.GVListPurchase.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdSamplePurcRecDet, Me.ColNo, Me.ColCode, Me.ColName, Me.ColSize, Me.GridColumnRecNumber, Me.ColQtyReceived, Me.GridColumnQtyNote, Me.GridColumnQtyIssue})
        Me.GVListPurchase.GridControl = Me.GCListPurchase
        Me.GVListPurchase.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.GVListPurchase.Name = "GVListPurchase"
        Me.GVListPurchase.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVListPurchase.OptionsView.ShowGroupPanel = False
        '
        'ColIdSamplePurcRecDet
        '
        Me.ColIdSamplePurcRecDet.Caption = "ID Receive Sample Detail"
        Me.ColIdSamplePurcRecDet.FieldName = "id_sample_purc_rec_det"
        Me.ColIdSamplePurcRecDet.Name = "ColIdSamplePurcRecDet"
        Me.ColIdSamplePurcRecDet.OptionsColumn.AllowEdit = False
        '
        'ColNo
        '
        Me.ColNo.AppearanceCell.Options.UseTextOptions = True
        Me.ColNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColNo.AppearanceHeader.Options.UseTextOptions = True
        Me.ColNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColNo.Caption = "No"
        Me.ColNo.FieldName = "no"
        Me.ColNo.Name = "ColNo"
        Me.ColNo.OptionsColumn.AllowEdit = False
        Me.ColNo.Visible = True
        Me.ColNo.VisibleIndex = 0
        Me.ColNo.Width = 30
        '
        'ColCode
        '
        Me.ColCode.Caption = "Code"
        Me.ColCode.FieldName = "code"
        Me.ColCode.Name = "ColCode"
        Me.ColCode.OptionsColumn.AllowEdit = False
        Me.ColCode.Visible = True
        Me.ColCode.VisibleIndex = 1
        Me.ColCode.Width = 140
        '
        'ColName
        '
        Me.ColName.Caption = "Name"
        Me.ColName.FieldName = "name"
        Me.ColName.Name = "ColName"
        Me.ColName.OptionsColumn.AllowEdit = False
        Me.ColName.Visible = True
        Me.ColName.VisibleIndex = 2
        Me.ColName.Width = 235
        '
        'ColSize
        '
        Me.ColSize.AppearanceCell.Options.UseTextOptions = True
        Me.ColSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ColSize.AppearanceHeader.Options.UseTextOptions = True
        Me.ColSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ColSize.Caption = "Size"
        Me.ColSize.FieldName = "size"
        Me.ColSize.Name = "ColSize"
        Me.ColSize.OptionsColumn.AllowEdit = False
        Me.ColSize.Visible = True
        Me.ColSize.VisibleIndex = 3
        Me.ColSize.Width = 140
        '
        'GridColumnRecNumber
        '
        Me.GridColumnRecNumber.Caption = "Receiving Number"
        Me.GridColumnRecNumber.FieldName = "sample_purc_rec_number"
        Me.GridColumnRecNumber.Name = "GridColumnRecNumber"
        Me.GridColumnRecNumber.Visible = True
        Me.GridColumnRecNumber.VisibleIndex = 4
        '
        'ColQtyReceived
        '
        Me.ColQtyReceived.AppearanceCell.Options.UseTextOptions = True
        Me.ColQtyReceived.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQtyReceived.AppearanceHeader.Options.UseTextOptions = True
        Me.ColQtyReceived.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQtyReceived.Caption = "Qty Received"
        Me.ColQtyReceived.FieldName = "sample_purc_rec_det_qty"
        Me.ColQtyReceived.Name = "ColQtyReceived"
        Me.ColQtyReceived.OptionsColumn.AllowEdit = False
        Me.ColQtyReceived.Width = 68
        '
        'GridColumnQtyNote
        '
        Me.GridColumnQtyNote.Caption = "Note"
        Me.GridColumnQtyNote.FieldName = "pl_sample_purc_det_note"
        Me.GridColumnQtyNote.Name = "GridColumnQtyNote"
        Me.GridColumnQtyNote.Visible = True
        Me.GridColumnQtyNote.VisibleIndex = 5
        '
        'GridColumnQtyIssue
        '
        Me.GridColumnQtyIssue.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQtyIssue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyIssue.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQtyIssue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyIssue.Caption = "Qty PL"
        Me.GridColumnQtyIssue.FieldName = "qty_issue"
        Me.GridColumnQtyIssue.Name = "GridColumnQtyIssue"
        Me.GridColumnQtyIssue.Visible = True
        Me.GridColumnQtyIssue.VisibleIndex = 6
        '
        'FormInfoPLSample
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 450)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Controls.Add(Me.PCClose)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormInfoPLSample"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Packing List "
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.PCClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCClose.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GCPL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GCListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelSubTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PCClose As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCPL As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPL As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdPLSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdContactFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdCompContactTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSamplePurcRec As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCListPurchase As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListPurchase As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdSamplePurcRecDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColQtyReceived As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyIssue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRecNumber As DevExpress.XtraGrid.Columns.GridColumn
End Class
