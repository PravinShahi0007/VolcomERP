<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterDepartementSingle
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
        Me.EPDepartement = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.MEDescription = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TEDepartementCode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.TEDepartement = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEHeadDept = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.GridColumnIdUser = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNIK = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.EPDepartement, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDepartementCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDepartement.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEHeadDept.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EPDepartement
        '
        Me.EPDepartement.ContainerControl = Me
        '
        'MEDescription
        '
        Me.MEDescription.Location = New System.Drawing.Point(14, 131)
        Me.MEDescription.Name = "MEDescription"
        Me.MEDescription.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MEDescription.Properties.Appearance.Options.UseFont = True
        Me.MEDescription.Size = New System.Drawing.Size(337, 74)
        Me.MEDescription.TabIndex = 2
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl3.Location = New System.Drawing.Point(14, 113)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(64, 15)
        Me.LabelControl3.TabIndex = 33
        Me.LabelControl3.Text = "Description"
        '
        'TEDepartementCode
        '
        Me.TEDepartementCode.Location = New System.Drawing.Point(14, 81)
        Me.TEDepartementCode.Name = "TEDepartementCode"
        Me.TEDepartementCode.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TEDepartementCode.Properties.Appearance.Options.UseFont = True
        Me.TEDepartementCode.Size = New System.Drawing.Size(337, 22)
        Me.TEDepartementCode.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl2.Location = New System.Drawing.Point(14, 64)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(100, 15)
        Me.LabelControl2.TabIndex = 32
        Me.LabelControl2.Text = "Departement Code"
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Location = New System.Drawing.Point(197, 271)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(74, 28)
        Me.BCancel.TabIndex = 4
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Location = New System.Drawing.Point(277, 271)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(74, 28)
        Me.BSave.TabIndex = 3
        Me.BSave.Text = "Save"
        '
        'TEDepartement
        '
        Me.TEDepartement.Location = New System.Drawing.Point(14, 33)
        Me.TEDepartement.Name = "TEDepartement"
        Me.TEDepartement.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TEDepartement.Properties.Appearance.Options.UseFont = True
        Me.TEDepartement.Size = New System.Drawing.Size(337, 22)
        Me.TEDepartement.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl1.Location = New System.Drawing.Point(14, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(70, 15)
        Me.LabelControl1.TabIndex = 31
        Me.LabelControl1.Text = "Departement"
        '
        'SLEHeadDept
        '
        Me.SLEHeadDept.Location = New System.Drawing.Point(14, 237)
        Me.SLEHeadDept.Name = "SLEHeadDept"
        Me.SLEHeadDept.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEHeadDept.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEHeadDept.Size = New System.Drawing.Size(337, 20)
        Me.SLEHeadDept.TabIndex = 34
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdUser, Me.GridColumnNIK, Me.GridColumnName})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl4.Location = New System.Drawing.Point(14, 216)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(101, 15)
        Me.LabelControl4.TabIndex = 35
        Me.LabelControl4.Text = "Head Departement"
        '
        'GridColumnIdUser
        '
        Me.GridColumnIdUser.Caption = "Id User"
        Me.GridColumnIdUser.FieldName = "id_user"
        Me.GridColumnIdUser.Name = "GridColumnIdUser"
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Name"
        Me.GridColumnName.FieldName = "employee_name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 1
        '
        'GridColumnNIK
        '
        Me.GridColumnNIK.Caption = "NIK"
        Me.GridColumnNIK.FieldName = "employee_code"
        Me.GridColumnNIK.Name = "GridColumnNIK"
        Me.GridColumnNIK.Visible = True
        Me.GridColumnNIK.VisibleIndex = 0
        '
        'FormMasterDepartementSingle
        '
        Me.AcceptButton = Me.BSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BCancel
        Me.ClientSize = New System.Drawing.Size(363, 311)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.SLEHeadDept)
        Me.Controls.Add(Me.MEDescription)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.TEDepartementCode)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.BCancel)
        Me.Controls.Add(Me.BSave)
        Me.Controls.Add(Me.TEDepartement)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterDepartementSingle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Departement"
        CType(Me.EPDepartement, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDepartementCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDepartement.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEHeadDept.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EPDepartement As System.Windows.Forms.ErrorProvider
    Friend WithEvents MEDescription As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEDepartementCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEDepartement As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEHeadDept As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdUser As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNIK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
End Class
