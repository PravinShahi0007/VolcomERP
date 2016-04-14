<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSOHPickSource
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
        Me.BEmpty = New DevExpress.XtraEditors.SimpleButton
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton
        Me.GCSource = New DevExpress.XtraGrid.GridControl
        Me.GVSource = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn41 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn42 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn43 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn44 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn45 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn46 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn47 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn48 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn49 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn50 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn51 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn52 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn53 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn54 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn55 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn56 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn57 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn58 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn59 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn60 = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.SimpleButton2)
        Me.PanelControl1.Controls.Add(Me.SimpleButton1)
        Me.PanelControl1.Controls.Add(Me.BEmpty)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(693, 36)
        Me.PanelControl1.TabIndex = 2
        '
        'BEmpty
        '
        Me.BEmpty.Dock = System.Windows.Forms.DockStyle.Right
        Me.BEmpty.ImageIndex = 0
        Me.BEmpty.Location = New System.Drawing.Point(602, 0)
        Me.BEmpty.Name = "BEmpty"
        Me.BEmpty.Size = New System.Drawing.Size(91, 36)
        Me.BEmpty.TabIndex = 7
        Me.BEmpty.Text = "Clear all"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton1.ImageIndex = 0
        Me.SimpleButton1.Location = New System.Drawing.Point(511, 0)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(91, 36)
        Me.SimpleButton1.TabIndex = 8
        Me.SimpleButton1.Text = "Clear all"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton2.ImageIndex = 0
        Me.SimpleButton2.Location = New System.Drawing.Point(420, 0)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(91, 36)
        Me.SimpleButton2.TabIndex = 9
        Me.SimpleButton2.Text = "Clear all"
        '
        'GCSource
        '
        Me.GCSource.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSource.Location = New System.Drawing.Point(0, 36)
        Me.GCSource.MainView = Me.GVSource
        Me.GCSource.Name = "GCSource"
        Me.GCSource.Size = New System.Drawing.Size(693, 296)
        Me.GCSource.TabIndex = 8
        Me.GCSource.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSource})
        '
        'GVSource
        '
        Me.GVSource.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn41, Me.GridColumn42, Me.GridColumn43, Me.GridColumn44, Me.GridColumn45, Me.GridColumn46, Me.GridColumn47, Me.GridColumn48, Me.GridColumn49, Me.GridColumn50, Me.GridColumn51, Me.GridColumn52, Me.GridColumn53, Me.GridColumn54, Me.GridColumn55, Me.GridColumn56, Me.GridColumn57, Me.GridColumn58, Me.GridColumn59, Me.GridColumn60})
        Me.GVSource.GridControl = Me.GCSource
        Me.GVSource.Name = "GVSource"
        Me.GVSource.OptionsBehavior.Editable = False
        Me.GVSource.OptionsFind.AlwaysVisible = True
        Me.GVSource.OptionsView.ShowGroupPanel = False
        '
        'GridColumn41
        '
        Me.GridColumn41.Caption = "ID SOH on hand"
        Me.GridColumn41.FieldName = "id_mat_det"
        Me.GridColumn41.Name = "GridColumn41"
        '
        'GridColumn42
        '
        Me.GridColumn42.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn42.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn42.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn42.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn42.Caption = "No"
        Me.GridColumn42.FieldName = "no"
        Me.GridColumn42.Name = "GridColumn42"
        Me.GridColumn42.Visible = True
        Me.GridColumn42.VisibleIndex = 0
        Me.GridColumn42.Width = 49
        '
        'GridColumn43
        '
        Me.GridColumn43.Caption = "Class"
        Me.GridColumn43.FieldName = "prod_class"
        Me.GridColumn43.Name = "GridColumn43"
        Me.GridColumn43.Visible = True
        Me.GridColumn43.VisibleIndex = 1
        Me.GridColumn43.Width = 73
        '
        'GridColumn44
        '
        Me.GridColumn44.Caption = "Style Code"
        Me.GridColumn44.FieldName = "style_code"
        Me.GridColumn44.Name = "GridColumn44"
        Me.GridColumn44.Visible = True
        Me.GridColumn44.VisibleIndex = 2
        Me.GridColumn44.Width = 84
        '
        'GridColumn45
        '
        Me.GridColumn45.Caption = "Product Code"
        Me.GridColumn45.FieldName = "prod_code"
        Me.GridColumn45.Name = "GridColumn45"
        Me.GridColumn45.Visible = True
        Me.GridColumn45.VisibleIndex = 3
        Me.GridColumn45.Width = 90
        '
        'GridColumn46
        '
        Me.GridColumn46.Caption = "Description"
        Me.GridColumn46.FieldName = "prod_desc"
        Me.GridColumn46.Name = "GridColumn46"
        Me.GridColumn46.Visible = True
        Me.GridColumn46.VisibleIndex = 4
        Me.GridColumn46.Width = 142
        '
        'GridColumn47
        '
        Me.GridColumn47.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn47.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn47.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn47.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn47.Caption = "Size"
        Me.GridColumn47.FieldName = "prod_size"
        Me.GridColumn47.Name = "GridColumn47"
        Me.GridColumn47.Visible = True
        Me.GridColumn47.VisibleIndex = 5
        Me.GridColumn47.Width = 70
        '
        'GridColumn48
        '
        Me.GridColumn48.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn48.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn48.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn48.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn48.Caption = "Qty SOH"
        Me.GridColumn48.DisplayFormat.FormatString = "N2"
        Me.GridColumn48.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn48.FieldName = "qty"
        Me.GridColumn48.Name = "GridColumn48"
        Me.GridColumn48.Visible = True
        Me.GridColumn48.VisibleIndex = 6
        Me.GridColumn48.Width = 95
        '
        'GridColumn49
        '
        Me.GridColumn49.Caption = "Price"
        Me.GridColumn49.FieldName = "prod_price"
        Me.GridColumn49.Name = "GridColumn49"
        Me.GridColumn49.Visible = True
        Me.GridColumn49.VisibleIndex = 7
        '
        'GridColumn50
        '
        Me.GridColumn50.Caption = "Total Amount"
        Me.GridColumn50.FieldName = "tot_amount"
        Me.GridColumn50.Name = "GridColumn50"
        Me.GridColumn50.Visible = True
        Me.GridColumn50.VisibleIndex = 9
        '
        'GridColumn51
        '
        Me.GridColumn51.Caption = "Cost"
        Me.GridColumn51.FieldName = "prod_cost"
        Me.GridColumn51.Name = "GridColumn51"
        Me.GridColumn51.Visible = True
        Me.GridColumn51.VisibleIndex = 8
        '
        'GridColumn52
        '
        Me.GridColumn52.Caption = "Total Cost"
        Me.GridColumn52.FieldName = "tot_cost"
        Me.GridColumn52.Name = "GridColumn52"
        Me.GridColumn52.Visible = True
        Me.GridColumn52.VisibleIndex = 10
        '
        'GridColumn53
        '
        Me.GridColumn53.Caption = "Sale"
        Me.GridColumn53.FieldName = "prod_sale"
        Me.GridColumn53.Name = "GridColumn53"
        '
        'GridColumn54
        '
        Me.GridColumn54.Caption = "Margin"
        Me.GridColumn54.FieldName = "prod_margin"
        Me.GridColumn54.Name = "GridColumn54"
        '
        'GridColumn55
        '
        Me.GridColumn55.Caption = "Aging"
        Me.GridColumn55.FieldName = "prod_aging"
        Me.GridColumn55.Name = "GridColumn55"
        Me.GridColumn55.Width = 70
        '
        'GridColumn56
        '
        Me.GridColumn56.Caption = "Date"
        Me.GridColumn56.FieldName = "prod_date"
        Me.GridColumn56.Name = "GridColumn56"
        '
        'GridColumn57
        '
        Me.GridColumn57.Caption = "Range"
        Me.GridColumn57.FieldName = "prod_range"
        Me.GridColumn57.Name = "GridColumn57"
        '
        'GridColumn58
        '
        Me.GridColumn58.Caption = "Reff"
        Me.GridColumn58.FieldName = "prod_reff"
        Me.GridColumn58.Name = "GridColumn58"
        '
        'GridColumn59
        '
        Me.GridColumn59.Caption = "Status"
        Me.GridColumn59.FieldName = "prod_status"
        Me.GridColumn59.Name = "GridColumn59"
        '
        'GridColumn60
        '
        Me.GridColumn60.Caption = "Source"
        Me.GridColumn60.FieldName = "prod_source"
        Me.GridColumn60.Name = "GridColumn60"
        '
        'FormSOHPickSource
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(693, 332)
        Me.Controls.Add(Me.GCSource)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormSOHPickSource"
        Me.Text = "Pick Source"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BEmpty As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCSource As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSource As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn41 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn42 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn43 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn44 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn45 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn46 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn47 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn48 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn49 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn50 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn51 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn52 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn53 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn54 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn55 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn56 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn57 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn58 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn59 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn60 As DevExpress.XtraGrid.Columns.GridColumn
End Class
