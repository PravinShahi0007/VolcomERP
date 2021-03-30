<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDesignImagesDrop
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDesignImagesDrop))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.TECreatedAt = New DevExpress.XtraEditors.TextEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TECreatedBy = New DevExpress.XtraEditors.TextEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SBRemove = New DevExpress.XtraEditors.SimpleButton()
        Me.SBAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.TENumber = New DevExpress.XtraEditors.TextEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GCDesignList = New DevExpress.XtraGrid.GridControl()
        Me.GVDesignList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.TEReason = New DevExpress.XtraEditors.TextEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SBDropImages = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TECreatedAt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECreatedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCDesignList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDesignList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.TEReason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.TECreatedAt)
        Me.PanelControl1.Controls.Add(Me.Label3)
        Me.PanelControl1.Controls.Add(Me.TECreatedBy)
        Me.PanelControl1.Controls.Add(Me.Label2)
        Me.PanelControl1.Controls.Add(Me.SBRemove)
        Me.PanelControl1.Controls.Add(Me.SBAdd)
        Me.PanelControl1.Controls.Add(Me.TENumber)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 100)
        Me.PanelControl1.TabIndex = 0
        '
        'TECreatedAt
        '
        Me.TECreatedAt.Location = New System.Drawing.Point(86, 68)
        Me.TECreatedAt.Name = "TECreatedAt"
        Me.TECreatedAt.Properties.ReadOnly = True
        Me.TECreatedAt.Size = New System.Drawing.Size(180, 20)
        Me.TECreatedAt.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Created At"
        '
        'TECreatedBy
        '
        Me.TECreatedBy.Location = New System.Drawing.Point(86, 43)
        Me.TECreatedBy.Name = "TECreatedBy"
        Me.TECreatedBy.Properties.ReadOnly = True
        Me.TECreatedBy.Size = New System.Drawing.Size(180, 20)
        Me.TECreatedBy.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Created By"
        '
        'SBRemove
        '
        Me.SBRemove.Image = CType(resources.GetObject("SBRemove.Image"), System.Drawing.Image)
        Me.SBRemove.Location = New System.Drawing.Point(586, 54)
        Me.SBRemove.Name = "SBRemove"
        Me.SBRemove.Size = New System.Drawing.Size(90, 34)
        Me.SBRemove.TabIndex = 3
        Me.SBRemove.Text = "Remove"
        '
        'SBAdd
        '
        Me.SBAdd.Image = CType(resources.GetObject("SBAdd.Image"), System.Drawing.Image)
        Me.SBAdd.Location = New System.Drawing.Point(682, 54)
        Me.SBAdd.Name = "SBAdd"
        Me.SBAdd.Size = New System.Drawing.Size(90, 34)
        Me.SBAdd.TabIndex = 2
        Me.SBAdd.Text = "Add"
        '
        'TENumber
        '
        Me.TENumber.Location = New System.Drawing.Point(86, 17)
        Me.TENumber.Name = "TENumber"
        Me.TENumber.Properties.ReadOnly = True
        Me.TENumber.Size = New System.Drawing.Size(180, 20)
        Me.TENumber.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Number"
        '
        'GCDesignList
        '
        Me.GCDesignList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDesignList.Location = New System.Drawing.Point(0, 100)
        Me.GCDesignList.MainView = Me.GVDesignList
        Me.GCDesignList.Name = "GCDesignList"
        Me.GCDesignList.Size = New System.Drawing.Size(784, 416)
        Me.GCDesignList.TabIndex = 1
        Me.GCDesignList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDesignList})
        '
        'GVDesignList
        '
        Me.GVDesignList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3})
        Me.GVDesignList.GridControl = Me.GCDesignList
        Me.GVDesignList.Name = "GVDesignList"
        Me.GVDesignList.OptionsBehavior.Editable = False
        Me.GVDesignList.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "id_design"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Code"
        Me.GridColumn2.FieldName = "design_code"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Name"
        Me.GridColumn3.FieldName = "design_display_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.TEReason)
        Me.PanelControl2.Controls.Add(Me.Label4)
        Me.PanelControl2.Controls.Add(Me.SBDropImages)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 516)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(784, 45)
        Me.PanelControl2.TabIndex = 2
        '
        'TEReason
        '
        Me.TEReason.Location = New System.Drawing.Point(86, 13)
        Me.TEReason.Name = "TEReason"
        Me.TEReason.Size = New System.Drawing.Size(576, 20)
        Me.TEReason.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Reason"
        '
        'SBDropImages
        '
        Me.SBDropImages.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBDropImages.Image = CType(resources.GetObject("SBDropImages.Image"), System.Drawing.Image)
        Me.SBDropImages.Location = New System.Drawing.Point(668, 2)
        Me.SBDropImages.Name = "SBDropImages"
        Me.SBDropImages.Size = New System.Drawing.Size(114, 41)
        Me.SBDropImages.TabIndex = 0
        Me.SBDropImages.Text = "Drop Images"
        '
        'FormDesignImagesDrop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GCDesignList)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormDesignImagesDrop"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Drop Images"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.TECreatedAt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECreatedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCDesignList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDesignList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.TEReason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCDesignList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDesignList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SBDropImages As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TENumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents TECreatedAt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents TECreatedBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents SBRemove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEReason As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label4 As Label
End Class
