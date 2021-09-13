Public Class FormPriceChecker
    Dim dir As String = get_setup_field("cloud_image_url")
    Dim dir_def As String = get_setup_field("pic_path_design")
    Private Sub FormPriceChecker_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormPriceChecker_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F2 Then
            startScan()
            defaultInput()
        End If
    End Sub

    Sub startScan()
        TxtScannedCode.Text = ""
        TxtScannedCode.Focus()
    End Sub

    Private Sub BtnStartScan_Click(sender As Object, e As EventArgs) Handles BtnStartScan.Click
        startScan()
    End Sub

    Sub defaultInput()
        LabelDesc.Text = "-"
        LabelPrice.Text = "Rp. 0"
        LabelPriceType.Text = "-"
        LabelEffectiveDate.Text = "-"
        LabelCode.Text = ""
        LabelClass.Text = ""
        LabelColor.Text = ""
        LabelSeason.Text = ""
        LabelRecInWH.Text = ""
        PictureEdit1.EditValue = Nothing
    End Sub

    Private Sub TxtScannedCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtScannedCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            viewPrice()
        Else
            defaultInput()
        End If
    End Sub

    Sub viewPrice()
        Cursor = Cursors.WaitCursor
        Dim code As String = ""
        If TxtScannedCode.Text.Length > 9 Then
            code = addSlashes(TxtScannedCode.Text.Substring(0, 9))
        Else
            code = addSlashes(TxtScannedCode.Text)
        End If
        Dim query As String = "SELECT d.id_design, d.design_code, d.design_display_name, cls.class_display, cls.class, 
        col.color_display, col.color, ss.season, IFNULL(prc.design_price,0) AS `design_price`, 
        prc.design_price_type, prc.`price_effective_date`, DATE_FORMAT(d.design_first_rec_wh, '%d %M %Y') AS `rec_in_wh_date`
        FROM tb_m_design d
        LEFT JOIN (
	        SELECT d.id_design, cd.display_name AS `class_display`, cd.code_detail_name AS `class`
	        FROM tb_m_design d 
	        INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail AND cd.id_code=30
	        WHERE d.design_code='" + code + "' AND d.id_lookup_status_order!=2
	        GROUP BY d.id_design
        ) cls ON cls.id_design = d.id_design
        LEFT JOIN (
	        SELECT d.id_design, cd.display_name AS `color_display`, cd.code_detail_name AS `color`
	        FROM tb_m_design d
	        INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail AND cd.id_code=14
	        WHERE d.design_code='" + code + "' AND d.id_lookup_status_order!=2
        ) col ON col.id_design = d.id_design
        LEFT JOIN (
	        SELECT d.id_design, prc.design_price, pt.design_price_type, 
	        DATE_FORMAT(prc.design_price_start_date, '%d %M %Y') AS `price_effective_date`
	        FROM tb_m_design_price prc
	        INNER JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = prc.id_design_price_type
	        INNER JOIN tb_m_design d ON d.id_design = prc.id_design
	        WHERE prc.design_price_start_date<=DATE(NOW()) AND d.design_code='" + code + "' AND d.id_lookup_status_order!=2
	        ORDER BY prc.design_price_start_date DESC, prc.id_design_price DESC
	        LIMIT 1
        ) prc ON prc.id_design = d.id_design
        INNER JOIN tb_season ss ON ss.id_season = d.id_season
        WHERE d.design_code='" + code + "' AND d.id_lookup_status_order!=2 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            TxtScannedCode.Text = ""
            LabelDesc.Text = data.Rows(0)("design_display_name").ToString
            LabelPrice.Text = "Rp. " + Decimal.Parse(data.Rows(0)("design_price").ToString).ToString("N0")
            LabelPriceType.Text = data.Rows(0)("design_price_type").ToString.ToUpper + " PRICE"
            LabelEffectiveDate.Text = data.Rows(0)("price_effective_date").ToString
            LabelCode.Text = data.Rows(0)("design_code").ToString
            LabelClass.Text = data.Rows(0)("class").ToString + " (" + data.Rows(0)("class_display").ToString + ")"
            LabelColor.Text = data.Rows(0)("color").ToString + " (" + data.Rows(0)("color_display").ToString + ")"
            LabelSeason.Text = data.Rows(0)("season").ToString
            LabelRecInWH.Text = data.Rows(0)("rec_in_wh_date").ToString
            TxtScannedCode.Focus()

            'image
            Dim qimg As String = "SELECT * FROM tb_design_images WHERE id_design='" + data.Rows(0)("id_design").ToString + "' AND store='TH' LIMIT 1"
            Dim dimg As DataTable = execute_query(qimg, -1, True, "", "", "", "")
            If dimg.Rows.Count > 0 Then
                Try
                    PictureEdit1.LoadAsync(dir + "/" + dimg.Rows(0)("file_name").ToString)
                Catch ex As Exception
                    warningCustom("Failed load image : " + ex.ToString)
                End Try
            Else
                Try
                    PictureEdit1.LoadAsync(dir_def + "\" + "default.jpg")
                Catch ex As Exception
                    warningCustom("Failed load image : " + ex.ToString)
                End Try
            End If
        Else
            defaultInput()
            FormError.LabelContent.Text = "Product not found"
            FormError.ShowDialog()
            TxtScannedCode.Text = ""
            TxtScannedCode.Focus()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormPriceChecker_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        ActiveControl = TxtScannedCode
    End Sub

    Private Sub FormPriceChecker_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class