<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterDesignFabricationLookup
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
        Me.GCFabrication = New DevExpress.XtraGrid.GridControl()
        Me.GVFabrication = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCFabrication, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVFabrication, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCFabrication
        '
        Me.GCFabrication.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCFabrication.Location = New System.Drawing.Point(0, 0)
        Me.GCFabrication.MainView = Me.GVFabrication
        Me.GCFabrication.Name = "GCFabrication"
        Me.GCFabrication.Size = New System.Drawing.Size(784, 561)
        Me.GCFabrication.TabIndex = 0
        Me.GCFabrication.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVFabrication})
        '
        'GVFabrication
        '
        Me.GVFabrication.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.GVFabrication.GridControl = Me.GCFabrication
        Me.GVFabrication.Name = "GVFabrication"
        Me.GVFabrication.OptionsBehavior.Editable = False
        Me.GVFabrication.OptionsFind.AlwaysVisible = True
        Me.GVFabrication.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "GridColumn1"
        Me.GridColumn1.FieldName = "id_design_fabrication"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Fabrication"
        Me.GridColumn2.FieldName = "design_fabrication"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'FormMasterDesignFabricationLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GCFabrication)
        Me.MinimizeBox = False
        Me.Name = "FormMasterDesignFabricationLookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Design Fabrication Browse"
        CType(Me.GCFabrication, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVFabrication, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCFabrication As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVFabrication As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
End Class
