Public Class FormDesignInfo
    Public id_design As String = "-1"
    Dim dir_def As String = get_setup_field("pic_path_design")
    Dim dir As String = get_setup_field("cloud_image_url")

    Private Sub FormDesignInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT d.id_design, d.design_code, d.design_display_name, cls.class_display, cls.class, 
        col.color_display, col.color, ss.season, IFNULL(prc.design_price,0) AS `design_price`, 
        prc.design_price_type, prc.`price_effective_date`
        FROM tb_m_design d
        LEFT JOIN (
	        SELECT d.id_design, cd.display_name AS `class_display`, cd.code_detail_name AS `class`
	        FROM tb_m_design d 
	        INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail AND cd.id_code=30
	        WHERE d.id_design='" + id_design + "' AND d.id_lookup_status_order!=2
	        GROUP BY d.id_design
        ) cls ON cls.id_design = d.id_design
        LEFT JOIN (
	        SELECT d.id_design, cd.display_name AS `color_display`, cd.code_detail_name AS `color`
	        FROM tb_m_design d
	        INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail AND cd.id_code=14
	        WHERE d.id_design='" + id_design + "' AND d.id_lookup_status_order!=2
        ) col ON col.id_design = d.id_design
        LEFT JOIN (
	        SELECT d.id_design, prc.design_price, pt.design_price_type, 
	        DATE_FORMAT(prc.design_price_start_date, '%d %M %Y') AS `price_effective_date`
	        FROM tb_m_design_price prc
	        INNER JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = prc.id_design_price_type
	        INNER JOIN tb_m_design d ON d.id_design = prc.id_design
	        WHERE prc.design_price_start_date<=DATE(NOW()) AND d.id_design='" + id_design + "' AND d.id_lookup_status_order!=2
	        ORDER BY prc.design_price_start_date DESC, prc.id_design_price DESC
	        LIMIT 1
        ) prc ON prc.id_design = d.id_design
        INNER JOIN tb_season ss ON ss.id_season = d.id_season
        WHERE d.id_design='" + id_design + "' AND d.id_lookup_status_order!=2 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            LabelDesc.Text = data.Rows(0)("design_display_name").ToString
            LabelPrice.Text = "Rp. " + Decimal.Parse(data.Rows(0)("design_price").ToString).ToString("N0")
            LabelPriceType.Text = data.Rows(0)("design_price_type").ToString.ToUpper + " PRICE"
            LabelEffectiveDate.Text = data.Rows(0)("price_effective_date").ToString
            LabelCode.Text = data.Rows(0)("design_code").ToString
            LabelClass.Text = data.Rows(0)("class").ToString + " (" + data.Rows(0)("class_display").ToString + ")"
            LabelColor.Text = data.Rows(0)("color").ToString + " (" + data.Rows(0)("color_display").ToString + ")"
            LabelSeason.Text = data.Rows(0)("season").ToString

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
            stopCustom("Product not found")
            Close()
        End If
    End Sub

    Private Sub FormDesignInfo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class