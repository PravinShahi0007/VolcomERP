<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterDesignFabricationDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterDesignFabricationDet))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TEFabrication = New DevExpress.XtraEditors.TextEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DECreatedDate = New DevExpress.XtraEditors.DateEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TECreatedBy = New DevExpress.XtraEditors.TextEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DEUpdatedDate = New DevExpress.XtraEditors.DateEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TEUpdatedBy = New DevExpress.XtraEditors.TextEdit()
        Me.SBSave = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.TEFabrication.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DECreatedDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DECreatedDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECreatedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUpdatedDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUpdatedDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEUpdatedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fabrication"
        '
        'TEFabrication
        '
        Me.TEFabrication.Location = New System.Drawing.Point(123, 25)
        Me.TEFabrication.Name = "TEFabrication"
        Me.TEFabrication.Size = New System.Drawing.Size(263, 20)
        Me.TEFabrication.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Created Date"
        '
        'DECreatedDate
        '
        Me.DECreatedDate.EditValue = Nothing
        Me.DECreatedDate.Location = New System.Drawing.Point(123, 61)
        Me.DECreatedDate.Name = "DECreatedDate"
        Me.DECreatedDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DECreatedDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DECreatedDate.Properties.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.DECreatedDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DECreatedDate.Properties.EditFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.DECreatedDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DECreatedDate.Properties.Mask.EditMask = "dd MMMM yyyy HH:mm:ss"
        Me.DECreatedDate.Properties.ReadOnly = True
        Me.DECreatedDate.Size = New System.Drawing.Size(263, 20)
        Me.DECreatedDate.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Created By"
        '
        'TECreatedBy
        '
        Me.TECreatedBy.Location = New System.Drawing.Point(123, 97)
        Me.TECreatedBy.Name = "TECreatedBy"
        Me.TECreatedBy.Properties.ReadOnly = True
        Me.TECreatedBy.Size = New System.Drawing.Size(263, 20)
        Me.TECreatedBy.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Updated Date"
        '
        'DEUpdatedDate
        '
        Me.DEUpdatedDate.EditValue = Nothing
        Me.DEUpdatedDate.Location = New System.Drawing.Point(123, 133)
        Me.DEUpdatedDate.Name = "DEUpdatedDate"
        Me.DEUpdatedDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUpdatedDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUpdatedDate.Properties.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.DEUpdatedDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUpdatedDate.Properties.EditFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.DEUpdatedDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUpdatedDate.Properties.Mask.EditMask = "dd MMMM yyyy HH:mm:ss"
        Me.DEUpdatedDate.Properties.ReadOnly = True
        Me.DEUpdatedDate.Size = New System.Drawing.Size(263, 20)
        Me.DEUpdatedDate.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 172)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Updated By"
        '
        'TEUpdatedBy
        '
        Me.TEUpdatedBy.Location = New System.Drawing.Point(123, 169)
        Me.TEUpdatedBy.Name = "TEUpdatedBy"
        Me.TEUpdatedBy.Properties.ReadOnly = True
        Me.TEUpdatedBy.Size = New System.Drawing.Size(263, 20)
        Me.TEUpdatedBy.TabIndex = 9
        '
        'SBSave
        '
        Me.SBSave.Image = CType(resources.GetObject("SBSave.Image"), System.Drawing.Image)
        Me.SBSave.Location = New System.Drawing.Point(311, 205)
        Me.SBSave.Name = "SBSave"
        Me.SBSave.Size = New System.Drawing.Size(75, 23)
        Me.SBSave.TabIndex = 10
        Me.SBSave.Text = "Save"
        '
        'FormMasterDesignFabricationDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 251)
        Me.Controls.Add(Me.SBSave)
        Me.Controls.Add(Me.TEUpdatedBy)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DEUpdatedDate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TECreatedBy)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DECreatedDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TEFabrication)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormMasterDesignFabricationDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Design Fabrication Detail"
        CType(Me.TEFabrication.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DECreatedDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DECreatedDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECreatedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUpdatedDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUpdatedDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEUpdatedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TEFabrication As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents DECreatedDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents TECreatedBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents DEUpdatedDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label5 As Label
    Friend WithEvents TEUpdatedBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SBSave As DevExpress.XtraEditors.SimpleButton
End Class
