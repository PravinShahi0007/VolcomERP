<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSNISerahTerimaDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSNISerahTerimaDet))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.DEProposeDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TextEdit2 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BDel = New DevExpress.XtraEditors.SimpleButton()
        Me.BAdd = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DEProposeDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEProposeDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.DEProposeDate)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.TextEdit2)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.TextEdit1)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(917, 71)
        Me.PanelControl1.TabIndex = 0
        '
        'DEProposeDate
        '
        Me.DEProposeDate.EditValue = Nothing
        Me.DEProposeDate.Location = New System.Drawing.Point(501, 38)
        Me.DEProposeDate.Name = "DEProposeDate"
        Me.DEProposeDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEProposeDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEProposeDate.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEProposeDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEProposeDate.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEProposeDate.Properties.ReadOnly = True
        Me.DEProposeDate.Size = New System.Drawing.Size(266, 20)
        Me.DEProposeDate.TabIndex = 25
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(430, 41)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl3.TabIndex = 5
        Me.LabelControl3.Text = "Created Date"
        '
        'TextEdit2
        '
        Me.TextEdit2.Location = New System.Drawing.Point(91, 12)
        Me.TextEdit2.Name = "TextEdit2"
        Me.TextEdit2.Size = New System.Drawing.Size(333, 20)
        Me.TextEdit2.TabIndex = 4
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(11, 15)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Number"
        '
        'TextEdit1
        '
        Me.TextEdit1.Location = New System.Drawing.Point(91, 38)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Size = New System.Drawing.Size(333, 20)
        Me.TextEdit1.TabIndex = 2
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(11, 41)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Created By"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BDel)
        Me.PanelControl2.Controls.Add(Me.BAdd)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 71)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(917, 42)
        Me.PanelControl2.TabIndex = 1
        '
        'PanelControl3
        '
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 525)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(917, 46)
        Me.PanelControl3.TabIndex = 2
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 113)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(917, 412)
        Me.GridControl1.TabIndex = 3
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'BDel
        '
        Me.BDel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BDel.Image = CType(resources.GetObject("BDel.Image"), System.Drawing.Image)
        Me.BDel.Location = New System.Drawing.Point(694, 2)
        Me.BDel.Name = "BDel"
        Me.BDel.Size = New System.Drawing.Size(108, 38)
        Me.BDel.TabIndex = 4
        Me.BDel.Text = "Delete Item"
        '
        'BAdd
        '
        Me.BAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAdd.Image = CType(resources.GetObject("BAdd.Image"), System.Drawing.Image)
        Me.BAdd.Location = New System.Drawing.Point(802, 2)
        Me.BAdd.Name = "BAdd"
        Me.BAdd.Size = New System.Drawing.Size(113, 38)
        Me.BAdd.TabIndex = 5
        Me.BAdd.Text = "Add Item"
        '
        'FormSNISerahTerimaDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(917, 571)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "FormSNISerahTerimaDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SNI Serah Terima"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.DEProposeDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEProposeDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TextEdit2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEProposeDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BDel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BAdd As DevExpress.XtraEditors.SimpleButton
End Class
