﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormVerificationMasterOLDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormVerificationMasterOLDet))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLUEOnlineStore = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SBImportExcel = New DevExpress.XtraEditors.SimpleButton()
        Me.GCVerification = New DevExpress.XtraGrid.GridControl()
        Me.GVVerification = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCERP = New DevExpress.XtraGrid.GridControl()
        Me.GVERP = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SplitContainerControl = New DevExpress.XtraEditors.SplitContainerControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.SLUEDivision = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TEFileName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLUEOnlineStore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCVerification, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVVerification, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCERP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVERP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.SLUEDivision.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEFileName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LabelControl5)
        Me.PanelControl1.Controls.Add(Me.TEFileName)
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Controls.Add(Me.SLUEDivision)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.SLUEOnlineStore)
        Me.PanelControl1.Controls.Add(Me.SBImportExcel)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 101)
        Me.PanelControl1.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(17, 18)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Online Store"
        '
        'SLUEOnlineStore
        '
        Me.SLUEOnlineStore.Location = New System.Drawing.Point(87, 15)
        Me.SLUEOnlineStore.Name = "SLUEOnlineStore"
        Me.SLUEOnlineStore.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUEOnlineStore.Properties.View = Me.SearchLookUpEdit1View
        Me.SLUEOnlineStore.Size = New System.Drawing.Size(276, 20)
        Me.SLUEOnlineStore.TabIndex = 1
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "GridColumn1"
        Me.GridColumn1.FieldName = "id_comp"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Online Store"
        Me.GridColumn2.FieldName = "comp_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'SBImportExcel
        '
        Me.SBImportExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SBImportExcel.Image = CType(resources.GetObject("SBImportExcel.Image"), System.Drawing.Image)
        Me.SBImportExcel.Location = New System.Drawing.Point(657, 28)
        Me.SBImportExcel.Name = "SBImportExcel"
        Me.SBImportExcel.Size = New System.Drawing.Size(115, 46)
        Me.SBImportExcel.TabIndex = 0
        Me.SBImportExcel.Text = "Import Excel"
        '
        'GCVerification
        '
        Me.GCVerification.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCVerification.Location = New System.Drawing.Point(0, 38)
        Me.GCVerification.MainView = Me.GVVerification
        Me.GCVerification.Name = "GCVerification"
        Me.GCVerification.Size = New System.Drawing.Size(392, 422)
        Me.GCVerification.TabIndex = 1
        Me.GCVerification.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVVerification})
        '
        'GVVerification
        '
        Me.GVVerification.GridControl = Me.GCVerification
        Me.GVVerification.Name = "GVVerification"
        Me.GVVerification.OptionsBehavior.ReadOnly = True
        Me.GVVerification.OptionsView.ShowGroupPanel = False
        '
        'GCERP
        '
        Me.GCERP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCERP.Location = New System.Drawing.Point(0, 38)
        Me.GCERP.MainView = Me.GVERP
        Me.GCERP.Name = "GCERP"
        Me.GCERP.Size = New System.Drawing.Size(387, 422)
        Me.GCERP.TabIndex = 2
        Me.GCERP.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVERP})
        '
        'GVERP
        '
        Me.GVERP.GridControl = Me.GCERP
        Me.GVERP.Name = "GVERP"
        Me.GVERP.OptionsBehavior.ReadOnly = True
        Me.GVERP.OptionsView.ShowGroupPanel = False
        '
        'SplitContainerControl
        '
        Me.SplitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl.Location = New System.Drawing.Point(0, 101)
        Me.SplitContainerControl.Name = "SplitContainerControl"
        Me.SplitContainerControl.Panel1.Controls.Add(Me.GCVerification)
        Me.SplitContainerControl.Panel1.Controls.Add(Me.PanelControl2)
        Me.SplitContainerControl.Panel1.Text = "Panel1"
        Me.SplitContainerControl.Panel2.Controls.Add(Me.GCERP)
        Me.SplitContainerControl.Panel2.Controls.Add(Me.PanelControl3)
        Me.SplitContainerControl.Panel2.Text = "Panel2"
        Me.SplitContainerControl.Size = New System.Drawing.Size(784, 460)
        Me.SplitContainerControl.SplitterPosition = 392
        Me.SplitContainerControl.TabIndex = 3
        Me.SplitContainerControl.Text = "SplitContainerControl1"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.LabelControl2)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(392, 38)
        Me.PanelControl2.TabIndex = 2
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.LabelControl2.Location = New System.Drawing.Point(17, 9)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(69, 18)
        Me.LabelControl2.TabIndex = 0
        Me.LabelControl2.Text = "Data Excel"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.LabelControl3)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(387, 38)
        Me.PanelControl3.TabIndex = 3
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.LabelControl3.Location = New System.Drawing.Point(17, 9)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(61, 18)
        Me.LabelControl3.TabIndex = 1
        Me.LabelControl3.Text = "Data ERP"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(17, 44)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl4.TabIndex = 2
        Me.LabelControl4.Text = "Division"
        '
        'SLUEDivision
        '
        Me.SLUEDivision.Location = New System.Drawing.Point(87, 41)
        Me.SLUEDivision.Name = "SLUEDivision"
        Me.SLUEDivision.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUEDivision.Properties.View = Me.GridView1
        Me.SLUEDivision.Size = New System.Drawing.Size(276, 20)
        Me.SLUEDivision.TabIndex = 3
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn4})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "GridColumn1"
        Me.GridColumn3.FieldName = "id_code_detail"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Division"
        Me.GridColumn4.FieldName = "display_name"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 0
        '
        'TEFileName
        '
        Me.TEFileName.Location = New System.Drawing.Point(87, 67)
        Me.TEFileName.Name = "TEFileName"
        Me.TEFileName.Size = New System.Drawing.Size(276, 20)
        Me.TEFileName.TabIndex = 4
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(17, 70)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl5.TabIndex = 5
        Me.LabelControl5.Text = "File Name"
        '
        'FormVerificationMasterOLDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.SplitContainerControl)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormVerificationMasterOLDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Verification Master OL Detail"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLUEOnlineStore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCVerification, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVVerification, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCERP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVERP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.SLUEDivision.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEFileName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBImportExcel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLUEOnlineStore As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCVerification As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVVerification As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCERP As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVERP As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SplitContainerControl As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEFileName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLUEDivision As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
End Class