<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpUniPeriodSelect
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpUniPeriodSelect))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.GCUni = New DevExpress.XtraGrid.GridControl()
        Me.GVUni = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnPeriodName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSelectionStart = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSelectionEnd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDistribution = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnActive = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BtnChoose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCUni, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVUni, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnClose)
        Me.PanelControl1.Controls.Add(Me.BtnChoose)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 255)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(654, 38)
        Me.PanelControl1.TabIndex = 0
        '
        'GCUni
        '
        Me.GCUni.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCUni.Location = New System.Drawing.Point(0, 0)
        Me.GCUni.MainView = Me.GVUni
        Me.GCUni.Name = "GCUni"
        Me.GCUni.Size = New System.Drawing.Size(654, 255)
        Me.GCUni.TabIndex = 2
        Me.GCUni.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVUni})
        '
        'GVUni
        '
        Me.GVUni.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnPeriodName, Me.GridColumnSelectionStart, Me.GridColumnSelectionEnd, Me.GridColumnCreatedDate, Me.GridColumnDistribution, Me.GridColumnActive})
        Me.GVUni.GridControl = Me.GCUni
        Me.GVUni.Name = "GVUni"
        Me.GVUni.OptionsBehavior.Editable = False
        Me.GVUni.OptionsView.ShowGroupPanel = False
        '
        'GridColumnPeriodName
        '
        Me.GridColumnPeriodName.Caption = "Period"
        Me.GridColumnPeriodName.FieldName = "period_name"
        Me.GridColumnPeriodName.Name = "GridColumnPeriodName"
        Me.GridColumnPeriodName.Visible = True
        Me.GridColumnPeriodName.VisibleIndex = 0
        '
        'GridColumnSelectionStart
        '
        Me.GridColumnSelectionStart.Caption = "Est. Selection Start"
        Me.GridColumnSelectionStart.DisplayFormat.FormatString = "dd\/MM\/yyyy"
        Me.GridColumnSelectionStart.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnSelectionStart.FieldName = "selection_date_start"
        Me.GridColumnSelectionStart.Name = "GridColumnSelectionStart"
        Me.GridColumnSelectionStart.Visible = True
        Me.GridColumnSelectionStart.VisibleIndex = 1
        '
        'GridColumnSelectionEnd
        '
        Me.GridColumnSelectionEnd.Caption = "Est. Selection End"
        Me.GridColumnSelectionEnd.DisplayFormat.FormatString = "dd\/MM\/yyyy"
        Me.GridColumnSelectionEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnSelectionEnd.FieldName = "selection_date_end"
        Me.GridColumnSelectionEnd.Name = "GridColumnSelectionEnd"
        Me.GridColumnSelectionEnd.Visible = True
        Me.GridColumnSelectionEnd.VisibleIndex = 2
        '
        'GridColumnCreatedDate
        '
        Me.GridColumnCreatedDate.Caption = "Created Date"
        Me.GridColumnCreatedDate.DisplayFormat.FormatString = "dd\/MM\/yyyy"
        Me.GridColumnCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnCreatedDate.FieldName = "created_date"
        Me.GridColumnCreatedDate.Name = "GridColumnCreatedDate"
        Me.GridColumnCreatedDate.Visible = True
        Me.GridColumnCreatedDate.VisibleIndex = 3
        '
        'GridColumnDistribution
        '
        Me.GridColumnDistribution.Caption = "Est. Distribution"
        Me.GridColumnDistribution.DisplayFormat.FormatString = "dd\/MM\/yyyy"
        Me.GridColumnDistribution.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnDistribution.FieldName = "distribution_date"
        Me.GridColumnDistribution.Name = "GridColumnDistribution"
        Me.GridColumnDistribution.Visible = True
        Me.GridColumnDistribution.VisibleIndex = 4
        '
        'GridColumnActive
        '
        Me.GridColumnActive.Caption = "Status"
        Me.GridColumnActive.FieldName = "status"
        Me.GridColumnActive.Name = "GridColumnActive"
        Me.GridColumnActive.Visible = True
        Me.GridColumnActive.VisibleIndex = 5
        '
        'BtnChoose
        '
        Me.BtnChoose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnChoose.Image = CType(resources.GetObject("BtnChoose.Image"), System.Drawing.Image)
        Me.BtnChoose.Location = New System.Drawing.Point(567, 2)
        Me.BtnChoose.Name = "BtnChoose"
        Me.BtnChoose.Size = New System.Drawing.Size(85, 34)
        Me.BtnChoose.TabIndex = 0
        Me.BtnChoose.Text = "Choose"
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(492, 2)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(75, 34)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        '
        'FormEmpUniPeriodSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(654, 293)
        Me.Controls.Add(Me.GCUni)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormEmpUniPeriodSelect"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Uniform Period"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCUni, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVUni, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCUni As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVUni As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnPeriodName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSelectionStart As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSelectionEnd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDistribution As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnActive As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnChoose As DevExpress.XtraEditors.SimpleButton
End Class
