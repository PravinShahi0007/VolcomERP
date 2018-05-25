<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterProductForBOF
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterProductForBOF))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnGenerate = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.SLESeason = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRange = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnGenerate)
        Me.PanelControl1.Controls.Add(Me.BtnPrint)
        Me.PanelControl1.Controls.Add(Me.BtnView)
        Me.PanelControl1.Controls.Add(Me.PanelControl2)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1077, 38)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnGenerate
        '
        Me.BtnGenerate.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnGenerate.Image = CType(resources.GetObject("BtnGenerate.Image"), System.Drawing.Image)
        Me.BtnGenerate.ImageIndex = 15
        Me.BtnGenerate.Location = New System.Drawing.Point(442, 2)
        Me.BtnGenerate.LookAndFeel.SkinName = "Metropolis"
        Me.BtnGenerate.Name = "BtnGenerate"
        Me.BtnGenerate.Size = New System.Drawing.Size(96, 34)
        Me.BtnGenerate.TabIndex = 99
        Me.BtnGenerate.Text = "Generate"
        Me.BtnGenerate.Visible = False
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.ImageIndex = 15
        Me.BtnPrint.Location = New System.Drawing.Point(363, 2)
        Me.BtnPrint.LookAndFeel.SkinName = "Metropolis"
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(79, 34)
        Me.BtnPrint.TabIndex = 101
        Me.BtnPrint.Text = "Print"
        Me.BtnPrint.Visible = False
        '
        'BtnView
        '
        Me.BtnView.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnView.Image = CType(resources.GetObject("BtnView.Image"), System.Drawing.Image)
        Me.BtnView.ImageIndex = 15
        Me.BtnView.Location = New System.Drawing.Point(283, 2)
        Me.BtnView.LookAndFeel.SkinName = "Metropolis"
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(80, 34)
        Me.BtnView.TabIndex = 98
        Me.BtnView.Text = "View"
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.SLESeason)
        Me.PanelControl2.Controls.Add(Me.LabelControl4)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl2.Location = New System.Drawing.Point(2, 2)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(281, 34)
        Me.PanelControl2.TabIndex = 100
        '
        'SLESeason
        '
        Me.SLESeason.Location = New System.Drawing.Point(49, 7)
        Me.SLESeason.Name = "SLESeason"
        Me.SLESeason.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLESeason.Properties.Appearance.Options.UseFont = True
        Me.SLESeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESeason.Properties.View = Me.SearchLookUpEdit1View
        Me.SLESeason.Size = New System.Drawing.Size(218, 20)
        Me.SLESeason.TabIndex = 97
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdSeason, Me.GridColumnRange, Me.GridColumnSeason})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdSeason
        '
        Me.GridColumnIdSeason.Caption = "Id Season"
        Me.GridColumnIdSeason.FieldName = "id_season"
        Me.GridColumnIdSeason.Name = "GridColumnIdSeason"
        '
        'GridColumnRange
        '
        Me.GridColumnRange.Caption = "Range"
        Me.GridColumnRange.FieldName = "range"
        Me.GridColumnRange.Name = "GridColumnRange"
        Me.GridColumnRange.Visible = True
        Me.GridColumnRange.VisibleIndex = 0
        '
        'GridColumnSeason
        '
        Me.GridColumnSeason.Caption = "Season"
        Me.GridColumnSeason.FieldName = "season"
        Me.GridColumnSeason.Name = "GridColumnSeason"
        Me.GridColumnSeason.Visible = True
        Me.GridColumnSeason.VisibleIndex = 1
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(8, 10)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl4.TabIndex = 96
        Me.LabelControl4.Text = "Season"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 38)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(1077, 474)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'FormMasterProductForBOF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1077, 512)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormMasterProductForBOF"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Product for BOF"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SLESeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRange As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnGenerate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
End Class
