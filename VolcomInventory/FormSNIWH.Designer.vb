<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSNIWH
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
        Me.XTCInOut = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPRecWait = New DevExpress.XtraTab.XtraTabPage()
        Me.GCSNIWaitRec = New DevExpress.XtraGrid.GridControl()
        Me.GVSNIWaitRec = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPRecList = New DevExpress.XtraTab.XtraTabPage()
        Me.GCRecList = New DevExpress.XtraGrid.GridControl()
        Me.GVRecList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPDelWait = New DevExpress.XtraTab.XtraTabPage()
        Me.GCWaitDel = New DevExpress.XtraGrid.GridControl()
        Me.GVWaitDel = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPDelList = New DevExpress.XtraTab.XtraTabPage()
        Me.GCDelList = New DevExpress.XtraGrid.GridControl()
        Me.GVDelList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCInOut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCInOut.SuspendLayout()
        Me.XTPRecWait.SuspendLayout()
        CType(Me.GCSNIWaitRec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSNIWaitRec, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPRecList.SuspendLayout()
        CType(Me.GCRecList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRecList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPDelWait.SuspendLayout()
        CType(Me.GCWaitDel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVWaitDel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPDelList.SuspendLayout()
        CType(Me.GCDelList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDelList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCInOut
        '
        Me.XTCInOut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCInOut.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCInOut.Location = New System.Drawing.Point(0, 0)
        Me.XTCInOut.Name = "XTCInOut"
        Me.XTCInOut.SelectedTabPage = Me.XTPRecWait
        Me.XTCInOut.Size = New System.Drawing.Size(977, 538)
        Me.XTCInOut.TabIndex = 1
        Me.XTCInOut.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPRecWait, Me.XTPRecList, Me.XTPDelWait, Me.XTPDelList})
        '
        'XTPRecWait
        '
        Me.XTPRecWait.Controls.Add(Me.GCSNIWaitRec)
        Me.XTPRecWait.Name = "XTPRecWait"
        Me.XTPRecWait.Size = New System.Drawing.Size(971, 510)
        Me.XTPRecWait.Text = "Waiting to Receive"
        '
        'GCSNIWaitRec
        '
        Me.GCSNIWaitRec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSNIWaitRec.Location = New System.Drawing.Point(0, 0)
        Me.GCSNIWaitRec.MainView = Me.GVSNIWaitRec
        Me.GCSNIWaitRec.Name = "GCSNIWaitRec"
        Me.GCSNIWaitRec.Size = New System.Drawing.Size(971, 510)
        Me.GCSNIWaitRec.TabIndex = 0
        Me.GCSNIWaitRec.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSNIWaitRec})
        '
        'GVSNIWaitRec
        '
        Me.GVSNIWaitRec.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5})
        Me.GVSNIWaitRec.GridControl = Me.GCSNIWaitRec
        Me.GVSNIWaitRec.Name = "GVSNIWaitRec"
        Me.GVSNIWaitRec.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "id_sni_qc_out"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Number"
        Me.GridColumn2.FieldName = "number"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Created By"
        Me.GridColumn3.FieldName = "employee_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Created Date"
        Me.GridColumn4.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn4.FieldName = "created_date"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Report Status"
        Me.GridColumn5.FieldName = "report_status"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        '
        'XTPRecList
        '
        Me.XTPRecList.Controls.Add(Me.GCRecList)
        Me.XTPRecList.Name = "XTPRecList"
        Me.XTPRecList.Size = New System.Drawing.Size(971, 510)
        Me.XTPRecList.Text = "Receive List"
        '
        'GCRecList
        '
        Me.GCRecList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRecList.Location = New System.Drawing.Point(0, 0)
        Me.GCRecList.MainView = Me.GVRecList
        Me.GCRecList.Name = "GCRecList"
        Me.GCRecList.Size = New System.Drawing.Size(971, 510)
        Me.GCRecList.TabIndex = 1
        Me.GCRecList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRecList})
        '
        'GVRecList
        '
        Me.GVRecList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10})
        Me.GVRecList.GridControl = Me.GCRecList
        Me.GVRecList.Name = "GVRecList"
        Me.GVRecList.OptionsView.ShowGroupPanel = False
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "ID"
        Me.GridColumn6.FieldName = "id_sni_qc_out"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Number"
        Me.GridColumn7.FieldName = "number"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 0
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Created By"
        Me.GridColumn8.FieldName = "employee_name"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 1
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Created Date"
        Me.GridColumn9.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn9.FieldName = "created_date"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 2
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Report Status"
        Me.GridColumn10.FieldName = "report_status"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 3
        '
        'XTPDelWait
        '
        Me.XTPDelWait.Controls.Add(Me.GCWaitDel)
        Me.XTPDelWait.Name = "XTPDelWait"
        Me.XTPDelWait.Size = New System.Drawing.Size(971, 510)
        Me.XTPDelWait.Text = "Waiting to Delivery"
        '
        'GCWaitDel
        '
        Me.GCWaitDel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCWaitDel.Location = New System.Drawing.Point(0, 0)
        Me.GCWaitDel.MainView = Me.GVWaitDel
        Me.GCWaitDel.Name = "GCWaitDel"
        Me.GCWaitDel.Size = New System.Drawing.Size(971, 510)
        Me.GCWaitDel.TabIndex = 1
        Me.GCWaitDel.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVWaitDel})
        '
        'GVWaitDel
        '
        Me.GVWaitDel.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15})
        Me.GVWaitDel.GridControl = Me.GCWaitDel
        Me.GVWaitDel.Name = "GVWaitDel"
        Me.GVWaitDel.OptionsView.ShowGroupPanel = False
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "ID"
        Me.GridColumn11.FieldName = "id_sni_qc_out"
        Me.GridColumn11.Name = "GridColumn11"
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Number"
        Me.GridColumn12.FieldName = "number"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 0
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Created By"
        Me.GridColumn13.FieldName = "employee_name"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 1
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Created Date"
        Me.GridColumn14.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn14.FieldName = "created_date"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 2
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Report Status"
        Me.GridColumn15.FieldName = "report_status"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 3
        '
        'XTPDelList
        '
        Me.XTPDelList.Controls.Add(Me.GCDelList)
        Me.XTPDelList.Name = "XTPDelList"
        Me.XTPDelList.Size = New System.Drawing.Size(971, 510)
        Me.XTPDelList.Text = "Delivery List"
        '
        'GCDelList
        '
        Me.GCDelList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDelList.Location = New System.Drawing.Point(0, 0)
        Me.GCDelList.MainView = Me.GVDelList
        Me.GCDelList.Name = "GCDelList"
        Me.GCDelList.Size = New System.Drawing.Size(971, 510)
        Me.GCDelList.TabIndex = 1
        Me.GCDelList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDelList})
        '
        'GVDelList
        '
        Me.GVDelList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20})
        Me.GVDelList.GridControl = Me.GCDelList
        Me.GVDelList.Name = "GVDelList"
        Me.GVDelList.OptionsView.ShowGroupPanel = False
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "ID"
        Me.GridColumn16.FieldName = "id_sni_qc_out"
        Me.GridColumn16.Name = "GridColumn16"
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Number"
        Me.GridColumn17.FieldName = "number"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 0
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Created By"
        Me.GridColumn18.FieldName = "employee_name"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 1
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "Created Date"
        Me.GridColumn19.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn19.FieldName = "created_date"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 2
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Report Status"
        Me.GridColumn20.FieldName = "report_status"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 3
        '
        'FormSNIWH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(977, 538)
        Me.Controls.Add(Me.XTCInOut)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSNIWH"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SNI "
        CType(Me.XTCInOut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCInOut.ResumeLayout(False)
        Me.XTPRecWait.ResumeLayout(False)
        CType(Me.GCSNIWaitRec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSNIWaitRec, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPRecList.ResumeLayout(False)
        CType(Me.GCRecList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRecList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPDelWait.ResumeLayout(False)
        CType(Me.GCWaitDel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVWaitDel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPDelList.ResumeLayout(False)
        CType(Me.GCDelList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDelList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCInOut As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPRecWait As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCSNIWaitRec As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSNIWaitRec As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPRecList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCRecList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRecList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPDelWait As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCWaitDel As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVWaitDel As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPDelList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCDelList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDelList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
End Class
