<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDesignImagesDropPick
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDesignImagesDropPick))
        Me.GCDesign = New DevExpress.XtraGrid.GridControl()
        Me.GVDesign = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SBAdd = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GCDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GCDesign
        '
        Me.GCDesign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDesign.Location = New System.Drawing.Point(0, 0)
        Me.GCDesign.MainView = Me.GVDesign
        Me.GCDesign.Name = "GCDesign"
        Me.GCDesign.Size = New System.Drawing.Size(584, 516)
        Me.GCDesign.TabIndex = 0
        Me.GCDesign.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDesign})
        '
        'GVDesign
        '
        Me.GVDesign.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3})
        Me.GVDesign.GridControl = Me.GCDesign
        Me.GVDesign.Name = "GVDesign"
        Me.GVDesign.OptionsBehavior.Editable = False
        Me.GVDesign.OptionsFind.AlwaysVisible = True
        Me.GVDesign.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "id_design"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Code"
        Me.GridColumn2.FieldName = "design_code"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Name"
        Me.GridColumn3.FieldName = "design_display_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SBAdd)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 516)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(584, 45)
        Me.PanelControl1.TabIndex = 1
        '
        'SBAdd
        '
        Me.SBAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBAdd.Image = CType(resources.GetObject("SBAdd.Image"), System.Drawing.Image)
        Me.SBAdd.Location = New System.Drawing.Point(515, 2)
        Me.SBAdd.Name = "SBAdd"
        Me.SBAdd.Size = New System.Drawing.Size(67, 41)
        Me.SBAdd.TabIndex = 0
        Me.SBAdd.Text = "Add"
        '
        'FormDesignImagesDropPick
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 561)
        Me.Controls.Add(Me.GCDesign)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormDesignImagesDropPick"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Design"
        CType(Me.GCDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCDesign As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDesign As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
End Class
