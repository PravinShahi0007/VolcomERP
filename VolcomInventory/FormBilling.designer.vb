<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBilling
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBilling))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.BSave = New DevExpress.XtraEditors.SimpleButton
        Me.ImgBut = New DevExpress.Utils.ImageCollection(Me.components)
        Me.LEBilling = New DevExpress.XtraEditors.LookUpEdit
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl
        Me.GCBilling = New DevExpress.XtraGrid.GridControl
        Me.GVBilling = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnID = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnNumber = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIDCostCenter = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnCostCenter = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnAmount = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnKurs = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnIDCurrency = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumnAmountValas = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.ImgBut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEBilling.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GCBilling, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBilling, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BSave)
        Me.PanelControl1.Controls.Add(Me.LEBilling)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(836, 50)
        Me.PanelControl1.TabIndex = 0
        '
        'BSave
        '
        Me.BSave.ImageIndex = 12
        Me.BSave.ImageList = Me.ImgBut
        Me.BSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.BSave.Location = New System.Drawing.Point(270, 9)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(31, 30)
        Me.BSave.TabIndex = 147
        '
        'ImgBut
        '
        Me.ImgBut.ImageSize = New System.Drawing.Size(24, 24)
        Me.ImgBut.ImageStream = CType(resources.GetObject("ImgBut.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImgBut.Images.SetKeyName(0, "20_24x24.png")
        Me.ImgBut.Images.SetKeyName(1, "8_24x24.png")
        Me.ImgBut.Images.SetKeyName(2, "23_24x24.png")
        Me.ImgBut.Images.SetKeyName(3, "arrow_refresh.png")
        Me.ImgBut.Images.SetKeyName(4, "check_mark.png")
        Me.ImgBut.Images.SetKeyName(5, "gnome_application_exit (1).png")
        Me.ImgBut.Images.SetKeyName(6, "printer_3.png")
        Me.ImgBut.Images.SetKeyName(7, "save.png")
        Me.ImgBut.Images.SetKeyName(8, "31_24x24.png")
        Me.ImgBut.Images.SetKeyName(9, "18_24x24.png")
        Me.ImgBut.Images.SetKeyName(10, "attachment-icon.png")
        Me.ImgBut.Images.SetKeyName(11, "document_32.png")
        Me.ImgBut.Images.SetKeyName(12, "search32.png")
        '
        'LEBilling
        '
        Me.LEBilling.Location = New System.Drawing.Point(12, 12)
        Me.LEBilling.Name = "LEBilling"
        Me.LEBilling.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.LEBilling.Properties.Appearance.Options.UseFont = True
        Me.LEBilling.Properties.Appearance.Options.UseTextOptions = True
        Me.LEBilling.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEBilling.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LEBilling.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.LEBilling.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.LEBilling.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.LEBilling.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEBilling.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_bill_type", "Id Billing Type", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("bill_type", "Billing Type")})
        Me.LEBilling.Properties.NullText = ""
        Me.LEBilling.Properties.ShowFooter = False
        Me.LEBilling.Size = New System.Drawing.Size(252, 26)
        Me.LEBilling.TabIndex = 146
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.GCBilling)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl2.Location = New System.Drawing.Point(0, 50)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(836, 308)
        Me.PanelControl2.TabIndex = 1
        '
        'GCBilling
        '
        Me.GCBilling.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCBilling.Location = New System.Drawing.Point(2, 2)
        Me.GCBilling.MainView = Me.GVBilling
        Me.GCBilling.Name = "GCBilling"
        Me.GCBilling.Size = New System.Drawing.Size(832, 304)
        Me.GCBilling.TabIndex = 0
        Me.GCBilling.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBilling})
        '
        'GVBilling
        '
        Me.GVBilling.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNo, Me.GridColumnID, Me.GridColumnNumber, Me.GridColumnIDCostCenter, Me.GridColumnCostCenter, Me.GridColumnAmount, Me.GridColumnKurs, Me.GridColumnIDCurrency, Me.GridColumnAmountValas})
        Me.GVBilling.GridControl = Me.GCBilling
        Me.GVBilling.Name = "GVBilling"
        Me.GVBilling.OptionsBehavior.ReadOnly = True
        Me.GVBilling.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNo
        '
        Me.GridColumnNo.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnNo.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 66
        '
        'GridColumnID
        '
        Me.GridColumnID.Caption = "ID"
        Me.GridColumnID.FieldName = "id_bill"
        Me.GridColumnID.Name = "GridColumnID"
        '
        'GridColumnNumber
        '
        Me.GridColumnNumber.Caption = "Number"
        Me.GridColumnNumber.FieldName = "bill_number"
        Me.GridColumnNumber.Name = "GridColumnNumber"
        Me.GridColumnNumber.Visible = True
        Me.GridColumnNumber.VisibleIndex = 1
        Me.GridColumnNumber.Width = 172
        '
        'GridColumnIDCostCenter
        '
        Me.GridColumnIDCostCenter.Caption = "ID Cost Center"
        Me.GridColumnIDCostCenter.FieldName = "id_comp"
        Me.GridColumnIDCostCenter.Name = "GridColumnIDCostCenter"
        '
        'GridColumnCostCenter
        '
        Me.GridColumnCostCenter.Caption = "Cost Center"
        Me.GridColumnCostCenter.FieldName = "comp_name"
        Me.GridColumnCostCenter.Name = "GridColumnCostCenter"
        Me.GridColumnCostCenter.Visible = True
        Me.GridColumnCostCenter.VisibleIndex = 2
        Me.GridColumnCostCenter.Width = 389
        '
        'GridColumnAmount
        '
        Me.GridColumnAmount.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnAmount.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnAmount.Caption = "Amount"
        Me.GridColumnAmount.DisplayFormat.FormatString = "N4"
        Me.GridColumnAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAmount.FieldName = "bill_amount"
        Me.GridColumnAmount.Name = "GridColumnAmount"
        Me.GridColumnAmount.Visible = True
        Me.GridColumnAmount.VisibleIndex = 3
        Me.GridColumnAmount.Width = 393
        '
        'GridColumnKurs
        '
        Me.GridColumnKurs.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnKurs.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnKurs.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnKurs.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnKurs.Caption = "Kurs"
        Me.GridColumnKurs.DisplayFormat.FormatString = "N4"
        Me.GridColumnKurs.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnKurs.FieldName = "kurs"
        Me.GridColumnKurs.Name = "GridColumnKurs"
        '
        'GridColumnIDCurrency
        '
        Me.GridColumnIDCurrency.Caption = "ID Currency"
        Me.GridColumnIDCurrency.FieldName = "id_currency"
        Me.GridColumnIDCurrency.Name = "GridColumnIDCurrency"
        '
        'GridColumnAmountValas
        '
        Me.GridColumnAmountValas.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnAmountValas.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnAmountValas.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnAmountValas.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnAmountValas.Caption = "Amount Valas"
        Me.GridColumnAmountValas.DisplayFormat.FormatString = "N4"
        Me.GridColumnAmountValas.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAmountValas.FieldName = "bill_amount_valas"
        Me.GridColumnAmountValas.Name = "GridColumnAmountValas"
        '
        'FormBilling
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(836, 358)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormBilling"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Billing"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.ImgBut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEBilling.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GCBilling, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBilling, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCBilling As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVBilling As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LEBilling As DevExpress.XtraEditors.LookUpEdit
    Public WithEvents ImgBut As DevExpress.Utils.ImageCollection
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIDCostCenter As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCostCenter As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnKurs As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIDCurrency As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAmountValas As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
End Class
