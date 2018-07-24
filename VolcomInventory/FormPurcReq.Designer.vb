<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPurcReq
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
        Me.GCPurcReq = New DevExpress.XtraGrid.GridControl()
        Me.GVPurcReq = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RICECheck = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCPurcReq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPurcReq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICECheck, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(905, 44)
        Me.PanelControl1.TabIndex = 0
        '
        'GCPurcReq
        '
        Me.GCPurcReq.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPurcReq.Location = New System.Drawing.Point(0, 44)
        Me.GCPurcReq.MainView = Me.GVPurcReq
        Me.GCPurcReq.Name = "GCPurcReq"
        Me.GCPurcReq.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICECheck})
        Me.GCPurcReq.Size = New System.Drawing.Size(905, 445)
        Me.GCPurcReq.TabIndex = 9
        Me.GCPurcReq.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPurcReq})
        '
        'GVPurcReq
        '
        Me.GVPurcReq.GridControl = Me.GCPurcReq
        Me.GVPurcReq.Name = "GVPurcReq"
        Me.GVPurcReq.OptionsFind.AlwaysVisible = True
        Me.GVPurcReq.OptionsView.ShowGroupPanel = False
        '
        'RICECheck
        '
        Me.RICECheck.AutoHeight = False
        Me.RICECheck.Name = "RICECheck"
        Me.RICECheck.ValueChecked = "yes"
        Me.RICECheck.ValueUnchecked = "no"
        '
        'FormPurcReq
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(905, 489)
        Me.Controls.Add(Me.GCPurcReq)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPurcReq"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Request Purchase"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCPurcReq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPurcReq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICECheck, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCPurcReq As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPurcReq As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RICECheck As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
End Class
