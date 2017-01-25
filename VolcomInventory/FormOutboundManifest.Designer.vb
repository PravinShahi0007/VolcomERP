<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormOutboundManifest
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.BAccept = New DevExpress.XtraEditors.SimpleButton()
        Me.GCManifest = New DevExpress.XtraGrid.GridControl()
        Me.GVManifest = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.GCManifest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVManifest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BAccept
        '
        Me.BAccept.Appearance.BackColor = System.Drawing.SystemColors.Highlight
        Me.BAccept.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BAccept.Appearance.ForeColor = System.Drawing.Color.White
        Me.BAccept.Appearance.Options.UseBackColor = True
        Me.BAccept.Appearance.Options.UseFont = True
        Me.BAccept.Appearance.Options.UseForeColor = True
        Me.BAccept.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BAccept.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.BAccept.Location = New System.Drawing.Point(0, 314)
        Me.BAccept.LookAndFeel.SkinName = "Metropolis"
        Me.BAccept.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BAccept.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BAccept.Name = "BAccept"
        Me.BAccept.Size = New System.Drawing.Size(740, 28)
        Me.BAccept.TabIndex = 139
        Me.BAccept.Text = "Print Delivery Manifest"
        '
        'GCManifest
        '
        Me.GCManifest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCManifest.Location = New System.Drawing.Point(0, 0)
        Me.GCManifest.LookAndFeel.SkinName = "Office 2013 Dark Gray"
        Me.GCManifest.MainView = Me.GVManifest
        Me.GCManifest.Name = "GCManifest"
        Me.GCManifest.Size = New System.Drawing.Size(740, 314)
        Me.GCManifest.TabIndex = 140
        Me.GCManifest.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVManifest})
        '
        'GVManifest
        '
        Me.GVManifest.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GVManifest.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GVManifest.Appearance.Row.Options.UseTextOptions = True
        Me.GVManifest.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GVManifest.ColumnPanelRowHeight = 50
        Me.GVManifest.GridControl = Me.GCManifest
        Me.GVManifest.Name = "GVManifest"
        Me.GVManifest.OptionsBehavior.Editable = False
        Me.GVManifest.OptionsView.ColumnAutoWidth = False
        Me.GVManifest.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVManifest.OptionsView.ShowGroupPanel = False
        '
        'FormOutboundManifest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(740, 342)
        Me.Controls.Add(Me.GCManifest)
        Me.Controls.Add(Me.BAccept)
        Me.LookAndFeel.SkinName = "Metropolis Dark"
        Me.MinimizeBox = False
        Me.Name = "FormOutboundManifest"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Outbound Delivery Manifest"
        CType(Me.GCManifest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVManifest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BAccept As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCManifest As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVManifest As DevExpress.XtraGrid.Views.Grid.GridView
End Class
