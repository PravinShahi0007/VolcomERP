<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSNIQC
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
        Me.XTPOut = New DevExpress.XtraTab.XtraTabPage()
        Me.GCSNIOut = New DevExpress.XtraGrid.GridControl()
        Me.GVSNIOut = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPIn = New DevExpress.XtraTab.XtraTabPage()
        Me.GCSNIIn = New DevExpress.XtraGrid.GridControl()
        Me.GVSNIIn = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCInOut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCInOut.SuspendLayout()
        Me.XTPOut.SuspendLayout()
        CType(Me.GCSNIOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSNIOut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPIn.SuspendLayout()
        CType(Me.GCSNIIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSNIIn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCInOut
        '
        Me.XTCInOut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCInOut.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCInOut.Location = New System.Drawing.Point(0, 0)
        Me.XTCInOut.Name = "XTCInOut"
        Me.XTCInOut.SelectedTabPage = Me.XTPOut
        Me.XTCInOut.Size = New System.Drawing.Size(921, 481)
        Me.XTCInOut.TabIndex = 0
        Me.XTCInOut.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPOut, Me.XTPIn})
        '
        'XTPOut
        '
        Me.XTPOut.Controls.Add(Me.GCSNIOut)
        Me.XTPOut.Name = "XTPOut"
        Me.XTPOut.Size = New System.Drawing.Size(915, 453)
        Me.XTPOut.Text = "SNI Out"
        '
        'GCSNIOut
        '
        Me.GCSNIOut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSNIOut.Location = New System.Drawing.Point(0, 0)
        Me.GCSNIOut.MainView = Me.GVSNIOut
        Me.GCSNIOut.Name = "GCSNIOut"
        Me.GCSNIOut.Size = New System.Drawing.Size(915, 453)
        Me.GCSNIOut.TabIndex = 0
        Me.GCSNIOut.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSNIOut})
        '
        'GVSNIOut
        '
        Me.GVSNIOut.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5})
        Me.GVSNIOut.GridControl = Me.GCSNIOut
        Me.GVSNIOut.Name = "GVSNIOut"
        Me.GVSNIOut.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Number"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Created By"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Created Date"
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
        'XTPIn
        '
        Me.XTPIn.Controls.Add(Me.GCSNIIn)
        Me.XTPIn.Name = "XTPIn"
        Me.XTPIn.Size = New System.Drawing.Size(915, 453)
        Me.XTPIn.Text = "SNI In"
        '
        'GCSNIIn
        '
        Me.GCSNIIn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSNIIn.Location = New System.Drawing.Point(0, 0)
        Me.GCSNIIn.MainView = Me.GVSNIIn
        Me.GCSNIIn.Name = "GCSNIIn"
        Me.GCSNIIn.Size = New System.Drawing.Size(915, 453)
        Me.GCSNIIn.TabIndex = 1
        Me.GCSNIIn.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSNIIn})
        '
        'GVSNIIn
        '
        Me.GVSNIIn.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10})
        Me.GVSNIIn.GridControl = Me.GCSNIIn
        Me.GVSNIIn.Name = "GVSNIIn"
        Me.GVSNIIn.OptionsView.ShowGroupPanel = False
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "ID"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Number"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 0
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Created By"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 1
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Created Date"
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
        'FormSNIQC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(921, 481)
        Me.Controls.Add(Me.XTCInOut)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSNIQC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SNI QC"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.XTCInOut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCInOut.ResumeLayout(False)
        Me.XTPOut.ResumeLayout(False)
        CType(Me.GCSNIOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSNIOut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPIn.ResumeLayout(False)
        CType(Me.GCSNIIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSNIIn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCInOut As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPOut As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPIn As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCSNIOut As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSNIOut As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCSNIIn As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSNIIn As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
End Class
