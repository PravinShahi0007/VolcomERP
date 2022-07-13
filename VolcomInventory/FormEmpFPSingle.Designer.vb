<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpFPSingle
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
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.GCClaim = New DevExpress.XtraGrid.GridControl()
        Me.GVClaim = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BLoad = New DevExpress.XtraEditors.SimpleButton()
        Me.BDelBulk = New DevExpress.XtraEditors.SimpleButton()
        Me.BAddBulk = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.GCClaim, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVClaim, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextEdit1
        '
        Me.TextEdit1.Location = New System.Drawing.Point(17, 21)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Size = New System.Drawing.Size(291, 20)
        Me.TextEdit1.TabIndex = 0
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(233, 47)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton1.TabIndex = 1
        Me.SimpleButton1.Text = "Add"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Location = New System.Drawing.Point(17, 47)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton2.TabIndex = 2
        Me.SimpleButton2.Text = "Delete"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(335, 310)
        Me.XtraTabControl1.TabIndex = 3
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.TextEdit1)
        Me.XtraTabPage1.Controls.Add(Me.SimpleButton2)
        Me.XtraTabPage1.Controls.Add(Me.SimpleButton1)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(329, 282)
        Me.XtraTabPage1.Text = "Single"
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.BDelBulk)
        Me.XtraTabPage2.Controls.Add(Me.BAddBulk)
        Me.XtraTabPage2.Controls.Add(Me.BLoad)
        Me.XtraTabPage2.Controls.Add(Me.GCClaim)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(329, 282)
        Me.XtraTabPage2.Text = "List"
        '
        'GCClaim
        '
        Me.GCClaim.Dock = System.Windows.Forms.DockStyle.Top
        Me.GCClaim.Location = New System.Drawing.Point(0, 0)
        Me.GCClaim.MainView = Me.GVClaim
        Me.GCClaim.Name = "GCClaim"
        Me.GCClaim.Size = New System.Drawing.Size(329, 200)
        Me.GCClaim.TabIndex = 0
        Me.GCClaim.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVClaim})
        '
        'GVClaim
        '
        Me.GVClaim.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3})
        Me.GVClaim.GridControl = Me.GCClaim
        Me.GVClaim.Name = "GVClaim"
        Me.GVClaim.OptionsView.ShowGroupPanel = False
        '
        'BLoad
        '
        Me.BLoad.Location = New System.Drawing.Point(11, 206)
        Me.BLoad.Name = "BLoad"
        Me.BLoad.Size = New System.Drawing.Size(311, 23)
        Me.BLoad.TabIndex = 1
        Me.BLoad.Text = "Load"
        '
        'BDelBulk
        '
        Me.BDelBulk.Location = New System.Drawing.Point(11, 235)
        Me.BDelBulk.Name = "BDelBulk"
        Me.BDelBulk.Size = New System.Drawing.Size(75, 23)
        Me.BDelBulk.TabIndex = 4
        Me.BDelBulk.Text = "Delete"
        '
        'BAddBulk
        '
        Me.BAddBulk.Location = New System.Drawing.Point(247, 235)
        Me.BAddBulk.Name = "BAddBulk"
        Me.BAddBulk.Size = New System.Drawing.Size(75, 23)
        Me.BAddBulk.TabIndex = 3
        Me.BAddBulk.Text = "Add"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Nip"
        Me.GridColumn1.FieldName = "nip"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Employee"
        Me.GridColumn2.FieldName = "employee_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Status"
        Me.GridColumn3.FieldName = "employee_active"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'FormEmpFPSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(335, 310)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Name = "FormEmpFPSingle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Upload Delete"
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.GCClaim, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVClaim, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents BLoad As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCClaim As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVClaim As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BDelBulk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BAddBulk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
End Class
