<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSOHPrice
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
        Me.GCSOHPeriode = New DevExpress.XtraGrid.GridControl
        Me.GVSOHPeriode = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnIDperiode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnPeriodeSOH = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.GCSOHPeriode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSOHPeriode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCSOHPeriode
        '
        Me.GCSOHPeriode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSOHPeriode.Location = New System.Drawing.Point(0, 0)
        Me.GCSOHPeriode.MainView = Me.GVSOHPeriode
        Me.GCSOHPeriode.Name = "GCSOHPeriode"
        Me.GCSOHPeriode.Size = New System.Drawing.Size(745, 318)
        Me.GCSOHPeriode.TabIndex = 1
        Me.GCSOHPeriode.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSOHPeriode})
        '
        'GVSOHPeriode
        '
        Me.GVSOHPeriode.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIDperiode, Me.GridColumnPeriodeSOH, Me.GridColumn1, Me.GridColumn2, Me.GridColumn3})
        Me.GVSOHPeriode.GridControl = Me.GCSOHPeriode
        Me.GVSOHPeriode.Name = "GVSOHPeriode"
        Me.GVSOHPeriode.OptionsBehavior.ReadOnly = True
        Me.GVSOHPeriode.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIDperiode
        '
        Me.GridColumnIDperiode.Caption = "Id Periode"
        Me.GridColumnIDperiode.FieldName = "id_soh_periode"
        Me.GridColumnIDperiode.Name = "GridColumnIDperiode"
        '
        'GridColumnPeriodeSOH
        '
        Me.GridColumnPeriodeSOH.Caption = "Periode"
        Me.GridColumnPeriodeSOH.FieldName = "soh_periode"
        Me.GridColumnPeriodeSOH.Name = "GridColumnPeriodeSOH"
        Me.GridColumnPeriodeSOH.Visible = True
        Me.GridColumnPeriodeSOH.VisibleIndex = 0
        Me.GridColumnPeriodeSOH.Width = 239
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.Caption = "Date Start"
        Me.GridColumn1.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn1.FieldName = "date_start"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 1
        Me.GridColumn1.Width = 151
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.Caption = "Date End"
        Me.GridColumn2.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn2.FieldName = "date_end"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 2
        Me.GridColumn2.Width = 126
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn3.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn3.Caption = "Status"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Width = 87
        '
        'FormSOHPrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(745, 318)
        Me.Controls.Add(Me.GCSOHPeriode)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSOHPrice"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Price List"
        CType(Me.GCSOHPeriode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSOHPeriode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCSOHPeriode As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSOHPeriode As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIDperiode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPeriodeSOH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
End Class
