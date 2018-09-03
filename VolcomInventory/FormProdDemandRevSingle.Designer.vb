<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProdDemandRevSingle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProdDemandRevSingle))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnRevise = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnDrop = New DevExpress.XtraEditors.SimpleButton()
        Me.GCDesign = New DevExpress.XtraGrid.GridControl()
        Me.GVDesign = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnDrop)
        Me.PanelControl1.Controls.Add(Me.BtnRevise)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 326)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(717, 43)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnRevise
        '
        Me.BtnRevise.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRevise.Appearance.Options.UseFont = True
        Me.BtnRevise.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnRevise.Image = CType(resources.GetObject("BtnRevise.Image"), System.Drawing.Image)
        Me.BtnRevise.Location = New System.Drawing.Point(620, 2)
        Me.BtnRevise.LookAndFeel.SkinName = "Office 2007 Green"
        Me.BtnRevise.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnRevise.Name = "BtnRevise"
        Me.BtnRevise.Size = New System.Drawing.Size(95, 39)
        Me.BtnRevise.TabIndex = 0
        Me.BtnRevise.Text = "Revise"
        '
        'BtnDrop
        '
        Me.BtnDrop.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDrop.Appearance.Options.UseFont = True
        Me.BtnDrop.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDrop.Image = CType(resources.GetObject("BtnDrop.Image"), System.Drawing.Image)
        Me.BtnDrop.Location = New System.Drawing.Point(525, 2)
        Me.BtnDrop.LookAndFeel.SkinName = "Office 2007 Pink"
        Me.BtnDrop.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnDrop.Name = "BtnDrop"
        Me.BtnDrop.Size = New System.Drawing.Size(95, 39)
        Me.BtnDrop.TabIndex = 1
        Me.BtnDrop.Text = "Drop"
        '
        'GCDesign
        '
        Me.GCDesign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDesign.Location = New System.Drawing.Point(0, 0)
        Me.GCDesign.MainView = Me.GVDesign
        Me.GCDesign.Name = "GCDesign"
        Me.GCDesign.Size = New System.Drawing.Size(717, 326)
        Me.GCDesign.TabIndex = 1
        Me.GCDesign.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDesign})
        '
        'GVDesign
        '
        Me.GVDesign.GridControl = Me.GCDesign
        Me.GVDesign.Name = "GVDesign"
        Me.GVDesign.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVDesign.OptionsBehavior.Editable = False
        Me.GVDesign.OptionsView.ShowGroupPanel = False
        '
        'FormProdDemandRevSingle
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(717, 369)
        Me.Controls.Add(Me.GCDesign)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProdDemandRevSingle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select article"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDesign, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnDrop As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnRevise As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCDesign As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDesign As DevExpress.XtraGrid.Views.Grid.GridView
End Class
