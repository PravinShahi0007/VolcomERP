<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGCodeReplaceStoreAdd
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
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtStoreCode = New DevExpress.XtraEditors.TextEdit()
        Me.TxtStoreName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtDesignCode = New DevExpress.XtraEditors.TextEdit()
        Me.TxtDesignName = New DevExpress.XtraEditors.TextEdit()
        Me.TxtQty = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtAvailable = New DevExpress.XtraEditors.TextEdit()
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.PEView = New DevExpress.XtraEditors.PictureEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtSize = New DevExpress.XtraEditors.TextEdit()
        CType(Me.TxtStoreCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtStoreName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDesignCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDesignName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtQty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtAvailable.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PEView.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(164, 24)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Account"
        '
        'TxtStoreCode
        '
        Me.TxtStoreCode.Location = New System.Drawing.Point(232, 21)
        Me.TxtStoreCode.Name = "TxtStoreCode"
        Me.TxtStoreCode.Size = New System.Drawing.Size(56, 20)
        Me.TxtStoreCode.TabIndex = 1
        '
        'TxtStoreName
        '
        Me.TxtStoreName.Enabled = False
        Me.TxtStoreName.Location = New System.Drawing.Point(290, 21)
        Me.TxtStoreName.Name = "TxtStoreName"
        Me.TxtStoreName.Size = New System.Drawing.Size(225, 20)
        Me.TxtStoreName.TabIndex = 2
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(164, 50)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(25, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Code"
        '
        'TxtDesignCode
        '
        Me.TxtDesignCode.EditValue = ""
        Me.TxtDesignCode.Location = New System.Drawing.Point(232, 47)
        Me.TxtDesignCode.Name = "TxtDesignCode"
        Me.TxtDesignCode.Size = New System.Drawing.Size(202, 20)
        Me.TxtDesignCode.TabIndex = 4
        '
        'TxtDesignName
        '
        Me.TxtDesignName.EditValue = ""
        Me.TxtDesignName.Enabled = False
        Me.TxtDesignName.Location = New System.Drawing.Point(232, 73)
        Me.TxtDesignName.Name = "TxtDesignName"
        Me.TxtDesignName.Size = New System.Drawing.Size(283, 20)
        Me.TxtDesignName.TabIndex = 5
        '
        'TxtQty
        '
        Me.TxtQty.Location = New System.Drawing.Point(232, 99)
        Me.TxtQty.Name = "TxtQty"
        Me.TxtQty.Properties.DisplayFormat.FormatString = "N0"
        Me.TxtQty.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtQty.Properties.Mask.EditMask = "n0"
        Me.TxtQty.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtQty.Size = New System.Drawing.Size(108, 20)
        Me.TxtQty.TabIndex = 6
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(164, 102)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(42, 13)
        Me.LabelControl3.TabIndex = 7
        Me.LabelControl3.Text = "Quantity"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(346, 102)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl4.TabIndex = 8
        Me.LabelControl4.Text = "Available"
        '
        'TxtAvailable
        '
        Me.TxtAvailable.Enabled = False
        Me.TxtAvailable.Location = New System.Drawing.Point(395, 99)
        Me.TxtAvailable.Name = "TxtAvailable"
        Me.TxtAvailable.Properties.DisplayFormat.FormatString = "N0"
        Me.TxtAvailable.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtAvailable.Size = New System.Drawing.Size(120, 20)
        Me.TxtAvailable.TabIndex = 9
        '
        'BtnAdd
        '
        Me.BtnAdd.Location = New System.Drawing.Point(440, 125)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(75, 23)
        Me.BtnAdd.TabIndex = 10
        Me.BtnAdd.Text = "Add"
        '
        'BtnClose
        '
        Me.BtnClose.Location = New System.Drawing.Point(359, 125)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(75, 23)
        Me.BtnClose.TabIndex = 11
        Me.BtnClose.Text = "Close"
        '
        'PEView
        '
        Me.PEView.Dock = System.Windows.Forms.DockStyle.Left
        Me.PEView.Location = New System.Drawing.Point(0, 0)
        Me.PEView.Name = "PEView"
        Me.PEView.Properties.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.PEView.Properties.ShowMenu = False
        Me.PEView.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PEView.Size = New System.Drawing.Size(145, 183)
        Me.PEView.TabIndex = 10002
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(164, 76)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl5.TabIndex = 10003
        Me.LabelControl5.Text = "Description"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(440, 50)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl6.TabIndex = 10004
        Me.LabelControl6.Text = "Size"
        '
        'TxtSize
        '
        Me.TxtSize.Enabled = False
        Me.TxtSize.Location = New System.Drawing.Point(467, 47)
        Me.TxtSize.Name = "TxtSize"
        Me.TxtSize.Size = New System.Drawing.Size(48, 20)
        Me.TxtSize.TabIndex = 10005
        '
        'FormFGCodeReplaceStoreAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 183)
        Me.Controls.Add(Me.TxtSize)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.PEView)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.TxtAvailable)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.TxtQty)
        Me.Controls.Add(Me.TxtDesignName)
        Me.Controls.Add(Me.TxtDesignCode)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.TxtStoreName)
        Me.Controls.Add(Me.TxtStoreCode)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormFGCodeReplaceStoreAdd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add"
        CType(Me.TxtStoreCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtStoreName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDesignCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDesignName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtQty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtAvailable.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PEView.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtStoreCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtStoreName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtDesignCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtDesignName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtQty As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtAvailable As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PEView As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtSize As DevExpress.XtraEditors.TextEdit
End Class
