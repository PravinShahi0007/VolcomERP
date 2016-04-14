<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDataReff
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
        Me.BtnChoose = New DevExpress.XtraEditors.SimpleButton
        Me.GCDataReff = New DevExpress.XtraGrid.GridControl
        Me.GVDataReff = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIdDataReff = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCDataReff, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDataReff, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnChoose)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 376)
        Me.PanelControl1.LookAndFeel.SkinName = "Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(645, 37)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnChoose
        '
        Me.BtnChoose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnChoose.Location = New System.Drawing.Point(568, 2)
        Me.BtnChoose.Name = "BtnChoose"
        Me.BtnChoose.Size = New System.Drawing.Size(75, 33)
        Me.BtnChoose.TabIndex = 0
        Me.BtnChoose.Text = "Choose"
        '
        'GCDataReff
        '
        Me.GCDataReff.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDataReff.Location = New System.Drawing.Point(0, 0)
        Me.GCDataReff.MainView = Me.GVDataReff
        Me.GCDataReff.Name = "GCDataReff"
        Me.GCDataReff.Size = New System.Drawing.Size(645, 376)
        Me.GCDataReff.TabIndex = 1
        Me.GCDataReff.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDataReff})
        '
        'GVDataReff
        '
        Me.GVDataReff.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumnIdDataReff, Me.GridColumn2, Me.GridColumn3})
        Me.GVDataReff.GridControl = Me.GCDataReff
        Me.GVDataReff.Name = "GVDataReff"
        Me.GVDataReff.OptionsBehavior.Editable = False
        Me.GVDataReff.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id Report Mark Type"
        Me.GridColumn1.FieldName = "report_mark_type"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdDataReff
        '
        Me.GridColumnIdDataReff.Caption = "Id Data Reff"
        Me.GridColumnIdDataReff.FieldName = "id_data_reff"
        Me.GridColumnIdDataReff.Name = "GridColumnIdDataReff"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Process"
        Me.GridColumn2.FieldName = "report_mark_type_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Remark"
        Me.GridColumn3.FieldName = "remark_data_reff"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'FormDataReff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(645, 413)
        Me.Controls.Add(Me.GCDataReff)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormDataReff"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Choose Data Reference Type"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCDataReff, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDataReff, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnChoose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCDataReff As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDataReff As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdDataReff As DevExpress.XtraGrid.Columns.GridColumn
End Class
