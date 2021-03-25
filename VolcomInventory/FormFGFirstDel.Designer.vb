<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGFirstDel
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnfirst_del = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtDesignCode = New DevExpress.XtraEditors.TextEdit()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDesignCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnView)
        Me.PanelControl1.Controls.Add(Me.TxtDesignCode)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(744, 51)
        Me.PanelControl1.TabIndex = 0
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 51)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(744, 439)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumnfirst_del, Me.GridColumnnote})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Code"
        Me.GridColumn1.FieldName = "code"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Description"
        Me.GridColumn2.FieldName = "name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Account"
        Me.GridColumn3.FieldName = "comp_number"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Account Description"
        Me.GridColumn4.FieldName = "comp_name"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Delivery#"
        Me.GridColumn5.FieldName = "pl_sales_order_del_number"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 4
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Price"
        Me.GridColumn6.DisplayFormat.FormatString = "N2"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn6.FieldName = "design_price"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 5
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Saved Date"
        Me.GridColumn7.DisplayFormat.FormatString = "dd MMMM yyyy / hh:mm tt"
        Me.GridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn7.FieldName = "input_date"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 7
        '
        'GridColumnfirst_del
        '
        Me.GridColumnfirst_del.Caption = "First Del."
        Me.GridColumnfirst_del.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnfirst_del.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnfirst_del.FieldName = "first_del"
        Me.GridColumnfirst_del.Name = "GridColumnfirst_del"
        Me.GridColumnfirst_del.Visible = True
        Me.GridColumnfirst_del.VisibleIndex = 6
        '
        'GridColumnnote
        '
        Me.GridColumnnote.Caption = "Note"
        Me.GridColumnnote.FieldName = "note"
        Me.GridColumnnote.Name = "GridColumnnote"
        Me.GridColumnnote.Visible = True
        Me.GridColumnnote.VisibleIndex = 8
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(15, 19)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(60, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Design Code"
        '
        'TxtDesignCode
        '
        Me.TxtDesignCode.Location = New System.Drawing.Point(81, 16)
        Me.TxtDesignCode.Name = "TxtDesignCode"
        Me.TxtDesignCode.Size = New System.Drawing.Size(161, 20)
        Me.TxtDesignCode.TabIndex = 1
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(248, 14)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(60, 23)
        Me.BtnView.TabIndex = 2
        Me.BtnView.Text = "View"
        '
        'FormFGFirstDel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(744, 490)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormFGFirstDel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "First Delivery"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDesignCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtDesignCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumnfirst_del As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnote As DevExpress.XtraGrid.Columns.GridColumn
End Class
