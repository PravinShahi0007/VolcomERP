<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterUOM
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
        Me.ErrorProviderUom = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PCUOM = New DevExpress.XtraEditors.PanelControl
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton
        Me.TxtUOM = New DevExpress.XtraEditors.TextEdit
        Me.LabelUOM = New DevExpress.XtraEditors.LabelControl
        Me.GCUOM = New DevExpress.XtraGrid.GridControl
        Me.GVUOM = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ColumnIdUOM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ColumnUOM = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.ErrorProviderUom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCUOM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCUOM.SuspendLayout()
        CType(Me.TxtUOM.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCUOM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVUOM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ErrorProviderUom
        '
        Me.ErrorProviderUom.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProviderUom.ContainerControl = Me
        '
        'PCUOM
        '
        Me.PCUOM.Controls.Add(Me.BtnCancel)
        Me.PCUOM.Controls.Add(Me.BtnSave)
        Me.PCUOM.Controls.Add(Me.TxtUOM)
        Me.PCUOM.Controls.Add(Me.LabelUOM)
        Me.PCUOM.Dock = System.Windows.Forms.DockStyle.Left
        Me.PCUOM.Location = New System.Drawing.Point(0, 0)
        Me.PCUOM.Name = "PCUOM"
        Me.PCUOM.Size = New System.Drawing.Size(219, 419)
        Me.PCUOM.TabIndex = 3
        Me.PCUOM.Visible = False
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(41, 61)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 2
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(122, 61)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 1
        Me.BtnSave.Text = "Save"
        '
        'TxtUOM
        '
        Me.TxtUOM.Location = New System.Drawing.Point(12, 33)
        Me.TxtUOM.Name = "TxtUOM"
        Me.TxtUOM.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUOM.Properties.Appearance.Options.UseFont = True
        Me.TxtUOM.Size = New System.Drawing.Size(185, 22)
        Me.TxtUOM.TabIndex = 0
        Me.TxtUOM.ToolTip = "Example : kg, Yd, Pcs. Max : 10 character."
        Me.TxtUOM.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.TxtUOM.ToolTipTitle = "Information"
        '
        'LabelUOM
        '
        Me.LabelUOM.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelUOM.Location = New System.Drawing.Point(12, 12)
        Me.LabelUOM.Name = "LabelUOM"
        Me.LabelUOM.Size = New System.Drawing.Size(28, 15)
        Me.LabelUOM.TabIndex = 4
        Me.LabelUOM.Text = "UOM"
        '
        'GCUOM
        '
        Me.GCUOM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCUOM.Location = New System.Drawing.Point(219, 0)
        Me.GCUOM.MainView = Me.GVUOM
        Me.GCUOM.Name = "GCUOM"
        Me.GCUOM.Size = New System.Drawing.Size(376, 419)
        Me.GCUOM.TabIndex = 4
        Me.GCUOM.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVUOM})
        '
        'GVUOM
        '
        Me.GVUOM.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColumnIdUOM, Me.ColumnUOM})
        Me.GVUOM.GridControl = Me.GCUOM
        Me.GVUOM.Name = "GVUOM"
        Me.GVUOM.OptionsBehavior.Editable = False
        '
        'ColumnIdUOM
        '
        Me.ColumnIdUOM.Caption = "Id UOM"
        Me.ColumnIdUOM.FieldName = "id_uom"
        Me.ColumnIdUOM.Name = "ColumnIdUOM"
        '
        'ColumnUOM
        '
        Me.ColumnUOM.Caption = "Unit Of measure"
        Me.ColumnUOM.FieldName = "uom"
        Me.ColumnUOM.Name = "ColumnUOM"
        Me.ColumnUOM.Visible = True
        Me.ColumnUOM.VisibleIndex = 0
        '
        'FormMasterUOM
        '
        Me.AcceptButton = Me.BtnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(595, 419)
        Me.Controls.Add(Me.GCUOM)
        Me.Controls.Add(Me.PCUOM)
        Me.Name = "FormMasterUOM"
        Me.ShowInTaskbar = False
        Me.Text = "Master Unit Of Measure"
        CType(Me.ErrorProviderUom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCUOM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCUOM.ResumeLayout(False)
        Me.PCUOM.PerformLayout()
        CType(Me.TxtUOM.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCUOM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVUOM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProviderUom As System.Windows.Forms.ErrorProvider
    Friend WithEvents GCUOM As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVUOM As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PCUOM As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtUOM As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelUOM As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ColumnIdUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnUOM As DevExpress.XtraGrid.Columns.GridColumn
End Class
