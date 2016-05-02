<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterRateStore
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterRateStore))
        Me.PanelControlRange = New DevExpress.XtraEditors.PanelControl
        Me.BtnDeleteRange = New DevExpress.XtraEditors.SimpleButton
        Me.BtnEditRange = New DevExpress.XtraEditors.SimpleButton
        Me.BtnAddRange = New DevExpress.XtraEditors.SimpleButton
        Me.GCStoreRate = New DevExpress.XtraGrid.GridControl
        Me.GVStoreRate = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        CType(Me.PanelControlRange, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlRange.SuspendLayout()
        CType(Me.GCStoreRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVStoreRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControlRange
        '
        Me.PanelControlRange.Appearance.BackColor = System.Drawing.Color.AliceBlue
        Me.PanelControlRange.Appearance.Options.UseBackColor = True
        Me.PanelControlRange.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlRange.Controls.Add(Me.BtnDeleteRange)
        Me.PanelControlRange.Controls.Add(Me.BtnEditRange)
        Me.PanelControlRange.Controls.Add(Me.BtnAddRange)
        Me.PanelControlRange.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlRange.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlRange.LookAndFeel.SkinName = "Blue"
        Me.PanelControlRange.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControlRange.Name = "PanelControlRange"
        Me.PanelControlRange.Size = New System.Drawing.Size(617, 31)
        Me.PanelControlRange.TabIndex = 4
        Me.PanelControlRange.Visible = False
        '
        'BtnDeleteRange
        '
        Me.BtnDeleteRange.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDeleteRange.ImageIndex = 1
        Me.BtnDeleteRange.ImageList = Me.LargeImageCollection
        Me.BtnDeleteRange.Location = New System.Drawing.Point(392, 0)
        Me.BtnDeleteRange.Name = "BtnDeleteRange"
        Me.BtnDeleteRange.Size = New System.Drawing.Size(75, 31)
        Me.BtnDeleteRange.TabIndex = 2
        Me.BtnDeleteRange.Text = "Delete"
        '
        'BtnEditRange
        '
        Me.BtnEditRange.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnEditRange.ImageIndex = 2
        Me.BtnEditRange.ImageList = Me.LargeImageCollection
        Me.BtnEditRange.Location = New System.Drawing.Point(467, 0)
        Me.BtnEditRange.Name = "BtnEditRange"
        Me.BtnEditRange.Size = New System.Drawing.Size(75, 31)
        Me.BtnEditRange.TabIndex = 1
        Me.BtnEditRange.Text = "Edit"
        '
        'BtnAddRange
        '
        Me.BtnAddRange.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAddRange.ImageIndex = 0
        Me.BtnAddRange.ImageList = Me.LargeImageCollection
        Me.BtnAddRange.Location = New System.Drawing.Point(542, 0)
        Me.BtnAddRange.Name = "BtnAddRange"
        Me.BtnAddRange.Size = New System.Drawing.Size(75, 31)
        Me.BtnAddRange.TabIndex = 0
        Me.BtnAddRange.Text = "Add"
        '
        'GCStoreRate
        '
        Me.GCStoreRate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCStoreRate.Location = New System.Drawing.Point(0, 31)
        Me.GCStoreRate.MainView = Me.GVStoreRate
        Me.GCStoreRate.Name = "GCStoreRate"
        Me.GCStoreRate.Size = New System.Drawing.Size(617, 231)
        Me.GCStoreRate.TabIndex = 5
        Me.GCStoreRate.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVStoreRate})
        '
        'GVStoreRate
        '
        Me.GVStoreRate.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1})
        Me.GVStoreRate.GridControl = Me.GCStoreRate
        Me.GVStoreRate.Name = "GVStoreRate"
        Me.GVStoreRate.OptionsBehavior.Editable = False
        Me.GVStoreRate.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Rate"
        Me.GridColumn1.FieldName = "store_rate"
        Me.GridColumn1.FieldNameSortGroup = "id_store_rate"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.ReadOnly = True
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "20_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "8_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "23_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(3, "arrow_refresh.png")
        Me.LargeImageCollection.Images.SetKeyName(4, "check_mark.png")
        Me.LargeImageCollection.Images.SetKeyName(5, "gnome_application_exit (1).png")
        Me.LargeImageCollection.Images.SetKeyName(6, "printer_3.png")
        Me.LargeImageCollection.Images.SetKeyName(7, "save.png")
        Me.LargeImageCollection.Images.SetKeyName(8, "31_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(9, "18_24x24.png")
        '
        'FormMasterRateStore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 262)
        Me.Controls.Add(Me.GCStoreRate)
        Me.Controls.Add(Me.PanelControlRange)
        Me.Name = "FormMasterRateStore"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Master Rate Store"
        CType(Me.PanelControlRange, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlRange.ResumeLayout(False)
        CType(Me.GCStoreRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVStoreRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControlRange As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnDeleteRange As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnEditRange As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAddRange As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCStoreRate As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVStoreRate As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
End Class
