<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDropChangesMoveHistory
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
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_drop_changes = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnseason_del_from = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnseason_del_to = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoBtnHist = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoBtnHist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepoBtnHist})
        Me.GCData.Size = New System.Drawing.Size(550, 369)
        Me.GCData.TabIndex = 0
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_drop_changes, Me.GridColumnnumber, Me.GridColumnseason_del_from, Me.GridColumnseason_del_to})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_drop_changes
        '
        Me.GridColumnid_drop_changes.Caption = "id_drop_changes"
        Me.GridColumnid_drop_changes.FieldName = "id_drop_changes"
        Me.GridColumnid_drop_changes.Name = "GridColumnid_drop_changes"
        Me.GridColumnid_drop_changes.OptionsColumn.AllowEdit = False
        '
        'GridColumnnumber
        '
        Me.GridColumnnumber.Caption = "Propose No."
        Me.GridColumnnumber.FieldName = "number"
        Me.GridColumnnumber.Name = "GridColumnnumber"
        Me.GridColumnnumber.OptionsColumn.AllowEdit = False
        Me.GridColumnnumber.Visible = True
        Me.GridColumnnumber.VisibleIndex = 0
        '
        'GridColumnseason_del_from
        '
        Me.GridColumnseason_del_from.Caption = "Season From"
        Me.GridColumnseason_del_from.FieldName = "season_del_from"
        Me.GridColumnseason_del_from.Name = "GridColumnseason_del_from"
        Me.GridColumnseason_del_from.OptionsColumn.AllowEdit = False
        Me.GridColumnseason_del_from.Visible = True
        Me.GridColumnseason_del_from.VisibleIndex = 1
        '
        'GridColumnseason_del_to
        '
        Me.GridColumnseason_del_to.Caption = "Season To"
        Me.GridColumnseason_del_to.FieldName = "season_del_to"
        Me.GridColumnseason_del_to.Name = "GridColumnseason_del_to"
        Me.GridColumnseason_del_to.OptionsColumn.AllowEdit = False
        Me.GridColumnseason_del_to.Visible = True
        Me.GridColumnseason_del_to.VisibleIndex = 2
        '
        'RepoBtnHist
        '
        Me.RepoBtnHist.AutoHeight = False
        SerializableAppearanceObject2.BackColor = System.Drawing.Color.OrangeRed
        SerializableAppearanceObject2.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SerializableAppearanceObject2.ForeColor = System.Drawing.Color.White
        SerializableAppearanceObject2.Options.UseBackColor = True
        SerializableAppearanceObject2.Options.UseFont = True
        SerializableAppearanceObject2.Options.UseForeColor = True
        Me.RepoBtnHist.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Move History", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "", Nothing, Nothing, True)})
        Me.RepoBtnHist.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.RepoBtnHist.Name = "RepoBtnHist"
        Me.RepoBtnHist.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'FormDropChangesMoveHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 369)
        Me.Controls.Add(Me.GCData)
        Me.MinimizeBox = False
        Me.Name = "FormDropChangesMoveHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Season Move History"
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoBtnHist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_drop_changes As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnseason_del_from As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnseason_del_to As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoBtnHist As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
End Class
