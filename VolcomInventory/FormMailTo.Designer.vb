<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMailTo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMailTo))
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.SLERMT = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GridColumnid_mail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnrecipient_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnemail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntype = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.SLERMT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnAdd
        '
        Me.BtnAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"), System.Drawing.Image)
        Me.BtnAdd.Location = New System.Drawing.Point(492, 2)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(75, 42)
        Me.BtnAdd.TabIndex = 1
        Me.BtnAdd.Text = "Add"
        '
        'BtnDelete
        '
        Me.BtnDelete.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDelete.Image = CType(resources.GetObject("BtnDelete.Image"), System.Drawing.Image)
        Me.BtnDelete.Location = New System.Drawing.Point(404, 2)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(88, 42)
        Me.BtnDelete.TabIndex = 2
        Me.BtnDelete.Text = "Delete"
        '
        'SLERMT
        '
        Me.SLERMT.Location = New System.Drawing.Point(9, 11)
        Me.SLERMT.Name = "SLERMT"
        Me.SLERMT.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLERMT.Properties.View = Me.SearchLookUpEdit1View
        Me.SLERMT.Size = New System.Drawing.Size(213, 20)
        Me.SLERMT.TabIndex = 0
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.PanelControl2)
        Me.PanelControl1.Controls.Add(Me.BtnDelete)
        Me.PanelControl1.Controls.Add(Me.BtnAdd)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(569, 46)
        Me.PanelControl1.TabIndex = 0
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.SLERMT)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl2.Location = New System.Drawing.Point(171, 2)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(233, 42)
        Me.PanelControl2.TabIndex = 3
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_mail, Me.GridColumnrecipient_name, Me.GridColumnemail, Me.GridColumntype})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 46)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(569, 283)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GridColumnid_mail
        '
        Me.GridColumnid_mail.Caption = "id_mail"
        Me.GridColumnid_mail.FieldName = "id_mail"
        Me.GridColumnid_mail.Name = "GridColumnid_mail"
        '
        'GridColumnrecipient_name
        '
        Me.GridColumnrecipient_name.Caption = "Recipient"
        Me.GridColumnrecipient_name.FieldName = "recipient_name"
        Me.GridColumnrecipient_name.Name = "GridColumnrecipient_name"
        Me.GridColumnrecipient_name.Visible = True
        Me.GridColumnrecipient_name.VisibleIndex = 0
        '
        'GridColumnemail
        '
        Me.GridColumnemail.Caption = "Email"
        Me.GridColumnemail.FieldName = "email"
        Me.GridColumnemail.Name = "GridColumnemail"
        Me.GridColumnemail.Visible = True
        Me.GridColumnemail.VisibleIndex = 1
        '
        'GridColumntype
        '
        Me.GridColumntype.Caption = "Type"
        Me.GridColumntype.FieldName = "type"
        Me.GridColumntype.Name = "GridColumntype"
        Me.GridColumntype.Visible = True
        Me.GridColumntype.VisibleIndex = 2
        '
        'FormMailTo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(569, 329)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormMailTo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form Mail To"
        CType(Me.SLERMT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLERMT As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridColumnid_mail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnrecipient_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnemail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntype As DevExpress.XtraGrid.Columns.GridColumn
End Class
