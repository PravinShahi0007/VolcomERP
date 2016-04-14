<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesInvoiceNew
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSalesInvoiceNew))
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.BtnCreate = New DevExpress.XtraEditors.SimpleButton
        Me.PictureSeason = New DevExpress.XtraEditors.PictureEdit
        Me.LETypeSO = New DevExpress.XtraEditors.LookUpEdit
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.SLEStore = New DevExpress.XtraEditors.SearchLookUpEdit
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnCompNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCompName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnAddressPrimary = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCP = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnContactNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl
        Me.DEStart = New DevExpress.XtraEditors.DateEdit
        Me.DEEnd = New DevExpress.XtraEditors.DateEdit
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.PictureSeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LETypeSO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEStore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEnd.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.BtnCancel)
        Me.PanelControl3.Controls.Add(Me.BtnCreate)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 186)
        Me.PanelControl3.LookAndFeel.SkinName = "Blue"
        Me.PanelControl3.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(468, 44)
        Me.PanelControl3.TabIndex = 187
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(300, 9)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnCreate
        '
        Me.BtnCreate.Location = New System.Drawing.Point(381, 9)
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.Size = New System.Drawing.Size(75, 23)
        Me.BtnCreate.TabIndex = 0
        Me.BtnCreate.Text = "Create"
        '
        'PictureSeason
        '
        Me.PictureSeason.EditValue = CType(resources.GetObject("PictureSeason.EditValue"), Object)
        Me.PictureSeason.Location = New System.Drawing.Point(12, 22)
        Me.PictureSeason.Name = "PictureSeason"
        Me.PictureSeason.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureSeason.Properties.Appearance.Options.UseBackColor = True
        Me.PictureSeason.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureSeason.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PictureSeason.Size = New System.Drawing.Size(141, 144)
        Me.PictureSeason.TabIndex = 8909
        '
        'LETypeSO
        '
        Me.LETypeSO.Location = New System.Drawing.Point(173, 132)
        Me.LETypeSO.Name = "LETypeSO"
        Me.LETypeSO.Properties.Appearance.Options.UseTextOptions = True
        Me.LETypeSO.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LETypeSO.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LETypeSO.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_so_type", "ID SO Type", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("so_type", "Type")})
        Me.LETypeSO.Properties.NullText = ""
        Me.LETypeSO.Properties.ShowFooter = False
        Me.LETypeSO.Size = New System.Drawing.Size(283, 20)
        Me.LETypeSO.TabIndex = 8911
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(173, 115)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl1.TabIndex = 8910
        Me.LabelControl1.Text = "Type"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(173, 74)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(57, 13)
        Me.LabelControl2.TabIndex = 8912
        Me.LabelControl2.Text = "Start Period"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(322, 74)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl3.TabIndex = 8913
        Me.LabelControl3.Text = "End Period"
        '
        'SLEStore
        '
        Me.SLEStore.Location = New System.Drawing.Point(173, 46)
        Me.SLEStore.Name = "SLEStore"
        Me.SLEStore.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEStore.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEStore.Size = New System.Drawing.Size(283, 20)
        Me.SLEStore.TabIndex = 8917
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnCompNumber, Me.GridColumnCompName, Me.GridColumnAddressPrimary, Me.GridColumnCP, Me.GridColumnContactNumber})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnCompNumber
        '
        Me.GridColumnCompNumber.Caption = "Code"
        Me.GridColumnCompNumber.FieldName = "comp_number"
        Me.GridColumnCompNumber.Name = "GridColumnCompNumber"
        Me.GridColumnCompNumber.Visible = True
        Me.GridColumnCompNumber.VisibleIndex = 0
        '
        'GridColumnCompName
        '
        Me.GridColumnCompName.Caption = "Store"
        Me.GridColumnCompName.FieldName = "comp_name"
        Me.GridColumnCompName.Name = "GridColumnCompName"
        Me.GridColumnCompName.Visible = True
        Me.GridColumnCompName.VisibleIndex = 1
        '
        'GridColumnAddressPrimary
        '
        Me.GridColumnAddressPrimary.Caption = "Address"
        Me.GridColumnAddressPrimary.FieldName = "address_primary"
        Me.GridColumnAddressPrimary.Name = "GridColumnAddressPrimary"
        Me.GridColumnAddressPrimary.Visible = True
        Me.GridColumnAddressPrimary.VisibleIndex = 2
        '
        'GridColumnCP
        '
        Me.GridColumnCP.Caption = "Contact Person"
        Me.GridColumnCP.FieldName = "contact_person"
        Me.GridColumnCP.Name = "GridColumnCP"
        Me.GridColumnCP.Visible = True
        Me.GridColumnCP.VisibleIndex = 3
        '
        'GridColumnContactNumber
        '
        Me.GridColumnContactNumber.Caption = "Contact Number"
        Me.GridColumnContactNumber.FieldName = "contact_number"
        Me.GridColumnContactNumber.Name = "GridColumnContactNumber"
        Me.GridColumnContactNumber.Visible = True
        Me.GridColumnContactNumber.VisibleIndex = 4
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(173, 27)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl5.TabIndex = 8918
        Me.LabelControl5.Text = "Store"
        '
        'DEStart
        '
        Me.DEStart.EditValue = Nothing
        Me.DEStart.Location = New System.Drawing.Point(173, 89)
        Me.DEStart.Name = "DEStart"
        Me.DEStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStart.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.DEStart.Size = New System.Drawing.Size(132, 20)
        Me.DEStart.TabIndex = 8919
        '
        'DEEnd
        '
        Me.DEEnd.EditValue = Nothing
        Me.DEEnd.Location = New System.Drawing.Point(322, 89)
        Me.DEEnd.Name = "DEEnd"
        Me.DEEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEnd.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEEnd.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.DEEnd.Size = New System.Drawing.Size(134, 20)
        Me.DEEnd.TabIndex = 8920
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(312, 92)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(4, 13)
        Me.LabelControl4.TabIndex = 8916
        Me.LabelControl4.Text = "-"
        '
        'FormSalesInvoiceNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(468, 230)
        Me.Controls.Add(Me.DEEnd)
        Me.Controls.Add(Me.DEStart)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.SLEStore)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LETypeSO)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.PictureSeason)
        Me.Controls.Add(Me.PanelControl3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSalesInvoiceNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create New Sales Invoice"
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.PictureSeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LETypeSO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEStore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEnd.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCreate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PictureSeason As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents LETypeSO As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEStore As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEEnd As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumnCompName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAddressPrimary As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnContactNumber As DevExpress.XtraGrid.Columns.GridColumn
End Class
