<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterRetCode
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterRetCode))
        Me.GCRetCode = New DevExpress.XtraGrid.GridControl()
        Me.GVRetCode = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControlRange = New DevExpress.XtraEditors.PanelControl()
        Me.BtnDeleteRange = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BtnEditRange = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAddRange = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumnRetDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCRetCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRetCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlRange, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlRange.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCRetCode
        '
        Me.GCRetCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRetCode.Location = New System.Drawing.Point(0, 31)
        Me.GCRetCode.MainView = Me.GVRetCode
        Me.GCRetCode.Name = "GCRetCode"
        Me.GCRetCode.Size = New System.Drawing.Size(624, 318)
        Me.GCRetCode.TabIndex = 2
        Me.GCRetCode.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRetCode})
        '
        'GVRetCode
        '
        Me.GVRetCode.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumnRetDesc, Me.GridColumn2})
        Me.GVRetCode.GridControl = Me.GCRetCode
        Me.GVRetCode.Name = "GVRetCode"
        Me.GVRetCode.OptionsBehavior.Editable = False
        Me.GVRetCode.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Return Code"
        Me.GridColumn1.FieldName = "ret_code"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Return Date"
        Me.GridColumn2.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn2.FieldName = "ret_date"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 2
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
        Me.PanelControlRange.Size = New System.Drawing.Size(624, 31)
        Me.PanelControlRange.TabIndex = 3
        Me.PanelControlRange.Visible = False
        '
        'BtnDeleteRange
        '
        Me.BtnDeleteRange.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDeleteRange.ImageIndex = 1
        Me.BtnDeleteRange.ImageList = Me.LargeImageCollection
        Me.BtnDeleteRange.Location = New System.Drawing.Point(399, 0)
        Me.BtnDeleteRange.Name = "BtnDeleteRange"
        Me.BtnDeleteRange.Size = New System.Drawing.Size(75, 31)
        Me.BtnDeleteRange.TabIndex = 2
        Me.BtnDeleteRange.Text = "Delete"
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
        'BtnEditRange
        '
        Me.BtnEditRange.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnEditRange.ImageIndex = 2
        Me.BtnEditRange.ImageList = Me.LargeImageCollection
        Me.BtnEditRange.Location = New System.Drawing.Point(474, 0)
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
        Me.BtnAddRange.Location = New System.Drawing.Point(549, 0)
        Me.BtnAddRange.Name = "BtnAddRange"
        Me.BtnAddRange.Size = New System.Drawing.Size(75, 31)
        Me.BtnAddRange.TabIndex = 0
        Me.BtnAddRange.Text = "Add"
        '
        'GridColumnRetDesc
        '
        Me.GridColumnRetDesc.Caption = "Description"
        Me.GridColumnRetDesc.FieldName = "ret_description"
        Me.GridColumnRetDesc.Name = "GridColumnRetDesc"
        Me.GridColumnRetDesc.Visible = True
        Me.GridColumnRetDesc.VisibleIndex = 1
        '
        'FormMasterRetCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 349)
        Me.Controls.Add(Me.GCRetCode)
        Me.Controls.Add(Me.PanelControlRange)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterRetCode"
        Me.Text = "Return Code"
        CType(Me.GCRetCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRetCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlRange, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlRange.ResumeLayout(False)
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCRetCode As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRetCode As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControlRange As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnDeleteRange As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnEditRange As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAddRange As DevExpress.XtraEditors.SimpleButton
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents GridColumnRetDesc As DevExpress.XtraGrid.Columns.GridColumn
End Class
