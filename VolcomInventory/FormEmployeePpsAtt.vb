Public Class FormEmployeePpsAtt
    Public type As String = ""
    Public images As DataTable = New DataTable
    Public read_only As Boolean = False
    Public is_single As Boolean = False

    Private Sub FormEmployeePpsAtt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 0 To images.Rows.Count - 1
            Dim msImage As IO.MemoryStream = New IO.MemoryStream(images.Rows(i)("image"), False)

            addImage(msImage)
        Next

        ' click first image
        For Each i As Control In XSCImageList.Controls
            Dim ic As DevExpress.XtraEditors.PictureEdit = CType(i, DevExpress.XtraEditors.PictureEdit)

            clickImage(ic, New EventArgs)
        Next

        If read_only Then
            SBAdd.Enabled = False
            SBScanUpload.Enabled = False
            SBDelete.Enabled = False
            SBSave.Enabled = False
            'SBRotate.Enabled = False
        End If

        If is_single Then
            SBAdd.Visible = False
            SBDelete.Visible = False
        End If

        ' disable right click
        PictureEdit.Properties.ContextMenuStrip = New ContextMenuStrip
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        If type = "ktp" Then
            Dim ic As DevExpress.XtraEditors.PictureEdit = CType(XSCImageList.Controls(0), DevExpress.XtraEditors.PictureEdit)

            Dim con As ImageConverter = New ImageConverter

            images.Rows(0)("image") = con.ConvertTo(ic.EditValue, GetType(Byte()))

            Dim msImage As IO.MemoryStream = New IO.MemoryStream(images.Rows(0)("image"), False)

            Dim PEEdit As DevExpress.XtraEditors.PictureEdit = New DevExpress.XtraEditors.PictureEdit

            If msImage.Length > 0 Then
                Dim image As Image = Image.FromStream(msImage)

                FormEmployeePpsDet.PEKTP.EditValue = image
            End If
        ElseIf type = "kk" Then
            Dim ic As DevExpress.XtraEditors.PictureEdit = CType(XSCImageList.Controls(0), DevExpress.XtraEditors.PictureEdit)

            Dim con As ImageConverter = New ImageConverter

            images.Rows(0)("image") = con.ConvertTo(ic.EditValue, GetType(Byte()))

            Dim msImage As IO.MemoryStream = New IO.MemoryStream(images.Rows(0)("image"), False)

            Dim PEEdit As DevExpress.XtraEditors.PictureEdit = New DevExpress.XtraEditors.PictureEdit

            If msImage.Length > 0 Then
                Dim image As Image = Image.FromStream(msImage)

                FormEmployeePpsDet.PEKK.EditValue = image
            End If
        ElseIf type = "rek" Then
            Dim ic As DevExpress.XtraEditors.PictureEdit = CType(XSCImageList.Controls(0), DevExpress.XtraEditors.PictureEdit)

            Dim con As ImageConverter = New ImageConverter

            images.Rows(0)("image") = con.ConvertTo(ic.EditValue, GetType(Byte()))

            Dim msImage As IO.MemoryStream = New IO.MemoryStream(images.Rows(0)("image"), False)

            Dim PEEdit As DevExpress.XtraEditors.PictureEdit = New DevExpress.XtraEditors.PictureEdit

            If msImage.Length > 0 Then
                Dim image As Image = Image.FromStream(msImage)

                FormEmployeePpsDet.PEREK.EditValue = image
            End If
        ElseIf type = "position" Then
            images.Rows.Clear()

            For Each i As Control In XSCImageList.Controls
                Dim ic As DevExpress.XtraEditors.PictureEdit = CType(i, DevExpress.XtraEditors.PictureEdit)

                Dim con As ImageConverter = New ImageConverter

                images.Rows.Add(con.ConvertTo(ic.EditValue, GetType(Byte())))
            Next

            FormEmployeePpsDet.PCPosAtt.Controls.Clear()

            For i = 0 To images.Rows.Count - 1
                Dim msImage As IO.MemoryStream = New IO.MemoryStream(images.Rows(i)("image"), False)

                Dim PEEdit As DevExpress.XtraEditors.PictureEdit = New DevExpress.XtraEditors.PictureEdit

                If msImage.Length > 0 Then
                    Dim image As Image = Image.FromStream(msImage)

                    PEEdit.EditValue = image

                    FormEmployeePpsDet.PCPosAtt.Controls.Add(PEEdit)
                    FormEmployeePpsDet.PCPosAtt.Controls.SetChildIndex(PEEdit, 0)
                End If
            Next

            If FormEmployeePpsDet.PCPosAtt.Controls.Count <= 0 Then
                Dim PEEdit As DevExpress.XtraEditors.PictureEdit = New DevExpress.XtraEditors.PictureEdit

                FormEmployeePpsDet.PCPosAtt.Controls.Add(PEEdit)
                FormEmployeePpsDet.PCPosAtt.Controls.SetChildIndex(PEEdit, 0)
            End If
        ElseIf type = "c19" Then
            images.Rows.Clear()

            For Each i As Control In XSCImageList.Controls
                Dim ic As DevExpress.XtraEditors.PictureEdit = CType(i, DevExpress.XtraEditors.PictureEdit)

                Dim con As ImageConverter = New ImageConverter

                images.Rows.Add(con.ConvertTo(ic.EditValue, GetType(Byte())))
            Next

            FormEmployeePpsDet.PCC19Att.Controls.Clear()

            For i = 0 To images.Rows.Count - 1
                Dim msImage As IO.MemoryStream = New IO.MemoryStream(images.Rows(i)("image"), False)

                Dim PEEdit As DevExpress.XtraEditors.PictureEdit = New DevExpress.XtraEditors.PictureEdit

                If msImage.Length > 0 Then
                    Dim image As Image = Image.FromStream(msImage)

                    PEEdit.EditValue = image

                    FormEmployeePpsDet.PCC19Att.Controls.Add(PEEdit)
                    FormEmployeePpsDet.PCC19Att.Controls.SetChildIndex(PEEdit, 0)
                End If
            Next

            If FormEmployeePpsDet.PCC19Att.Controls.Count <= 0 Then
                Dim PEEdit As DevExpress.XtraEditors.PictureEdit = New DevExpress.XtraEditors.PictureEdit

                FormEmployeePpsDet.PCC19Att.Controls.Add(PEEdit)
                FormEmployeePpsDet.PCC19Att.Controls.SetChildIndex(PEEdit, 0)
            End If
        End If

        Close()
    End Sub

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        Dim buffer As Byte() = New Byte() {}

        addImage(New IO.MemoryStream(buffer, False))
    End Sub

    Private Sub FormEmployeePpsAtt_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Sub addImage(ByVal msImage As IO.MemoryStream)
        Dim PEEdit As DevExpress.XtraEditors.PictureEdit = New DevExpress.XtraEditors.PictureEdit

        PEEdit.Size = New Size(50, 50)
        PEEdit.Dock = DockStyle.Left
        PEEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch

        AddHandler PEEdit.Click, AddressOf clickImage
        AddHandler PEEdit.ImageChanged, AddressOf changeImage

        ' load image
        If msImage.Length > 0 Then
            Dim image As Image = Image.FromStream(msImage)

            PEEdit.EditValue = image
        End If

        If read_only Then
            PEEdit.ReadOnly = True
        End If

        XSCImageList.Controls.Add(PEEdit)
        XSCImageList.Controls.SetChildIndex(PEEdit, 0)

        clickImage(PEEdit, New EventArgs)
    End Sub

    Sub clickImage(sender As Object, e As EventArgs)
        ' clear border
        For Each i As Control In XSCImageList.Controls
            Dim ic As DevExpress.XtraEditors.PictureEdit = CType(i, DevExpress.XtraEditors.PictureEdit)

            ic.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default
        Next

        ' set border
        Dim PEEdit As DevExpress.XtraEditors.PictureEdit = CType(sender, DevExpress.XtraEditors.PictureEdit)

        PEEdit.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D

        PictureEdit.EditValue = PEEdit.EditValue
    End Sub

    Sub changeImage(sender As Object, e As EventArgs)
        Dim PEEdit As DevExpress.XtraEditors.PictureEdit = CType(sender, DevExpress.XtraEditors.PictureEdit)

        If Not PEEdit.EditValue Is Nothing Then
            Dim image As Image = imageResize(CType(PEEdit.EditValue, Bitmap))

            If Not image Is Nothing Then
                PEEdit.EditValue = image
            End If
        End If

        PictureEdit.EditValue = PEEdit.EditValue
    End Sub

    Private Sub SBScanUpload_Click(sender As Object, e As EventArgs) Handles SBScanUpload.Click
        For Each i As Control In XSCImageList.Controls
            Dim ic As DevExpress.XtraEditors.PictureEdit = CType(i, DevExpress.XtraEditors.PictureEdit)

            If ic.BorderStyle.ToString = "Style3D" Then
                ic.Image = Scanner.Scan

                Exit For
            End If
        Next
    End Sub

    Private Sub SBDelete_Click(sender As Object, e As EventArgs) Handles SBDelete.Click
        ' check children
        Dim child As Integer = 0

        For Each i As Control In XSCImageList.Controls
            child += 1
        Next

        ' remove selected
        If child > 1 Then
            For Each i As Control In XSCImageList.Controls
                Dim ic As DevExpress.XtraEditors.PictureEdit = CType(i, DevExpress.XtraEditors.PictureEdit)

                If ic.BorderStyle.ToString = "Style3D" Then
                    XSCImageList.Controls.Remove(ic)

                    Exit For
                End If
            Next

            ' set selected
            If XSCImageList.HasChildren Then
                For Each i As Control In XSCImageList.Controls
                    Dim ic As DevExpress.XtraEditors.PictureEdit = CType(i, DevExpress.XtraEditors.PictureEdit)

                    ic.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D

                    PictureEdit.Image = ic.EditValue

                    Exit For
                Next
            Else
                PictureEdit.Image = Nothing
            End If
        End If
    End Sub

    Private Sub PictureEdit_MouseWheel(sender As Object, e As MouseEventArgs) Handles PictureEdit.MouseWheel
        PictureEdit.Properties.ZoomPercent += e.Delta * 0.03F
        DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
    End Sub

    Private Sub SBRotate_Click(sender As Object, e As EventArgs) Handles SBRotate.Click
        For Each i As Control In XSCImageList.Controls
            Dim ic As DevExpress.XtraEditors.PictureEdit = CType(i, DevExpress.XtraEditors.PictureEdit)

            If ic.BorderStyle.ToString = "Style3D" Then
                ic.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)

                clickImage(ic, New EventArgs)

                Exit For
            End If
        Next
    End Sub

    Function imageResize(image As Bitmap) As Image
        Dim width As Integer = 0
        Dim height As Integer = 0
        Dim maxSize As Integer = 1024

        If image.Width > maxSize Or image.Height > maxSize Then
            If image.Width > image.Height Then
                width = maxSize
                height = (maxSize / image.Width) * image.Height
            Else
                width = (maxSize / image.Height) * image.Width
                height = maxSize
            End If
        End If

        If width > 0 And height > 0 Then
            Dim result As Bitmap = New Bitmap(width, height)

            Using gfx As Graphics = Graphics.FromImage(result)
                gfx.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                gfx.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                gfx.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                gfx.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                gfx.CompositingMode = Drawing2D.CompositingMode.SourceOver

                gfx.DrawImage(image, 0, 0, result.Width, result.Height)
            End Using

            Return CType(result, Image)
        Else
            Return Nothing
        End If
    End Function
End Class