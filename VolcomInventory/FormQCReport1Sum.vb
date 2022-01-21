Public Class FormQCReport1Sum
    Dim imagedir As String = get_opt_prod_field("pic_path_qc_report1") & "\"
    Public id As String = "-1"
    Private Sub FormQCReport1Sum_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_head()
    End Sub

    Sub load_head()
        view_fgpo()

        If id = "-1" Then
            BGenerate.Visible = True
            XTCImage.Enabled = False
        Else
            BGenerate.Visible = False
            XTCImage.Enabled = True
            '
            load_img()
        End If
    End Sub

    Sub view_fgpo()
        Dim query As String = "SELECT po.`id_prod_order`,po.`prod_order_number`,dsg.`design_display_name`,dsg.`design_code`,CONCAT(po.`prod_order_number`,' - ',dsg.`design_display_name`) AS view_po
FROM tb_prod_order_rec_det recd 
INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec` AND rec.`id_report_status`=6
INNER JOIN tb_prod_order_det pod ON pod.`id_prod_order_det`=recd.`id_prod_order_det`
INNER JOIN tb_prod_order po ON po.`id_prod_order`=pod.`id_prod_order` 
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
INNER JOIN tb_prod_order_wo wo ON wo.id_prod_order=po.id_prod_order AND wo.is_main_vendor=1
INNER JOIN tb_m_ovh_price ovhp ON ovhp.id_ovh_price=wo.id_ovh_price
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = ovhp.id_comp_contact
INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp
INNER JOIN tb_m_city ct ON ct.`id_city`=c.`id_city`
INNER JOIN tb_m_state st ON st.`id_state`=ct.`id_state`
INNER JOIN tb_m_region reg ON reg.`id_region`=st.`id_region`
INNER JOIN tb_m_country co ON co.`id_country`=reg.`id_country`
LEFT JOIN
(
    SELECT * FROM (
		SELECT kod.* FROM tb_prod_order_ko_det kod
        INNER JOIN tb_prod_order_ko ko ON ko.id_prod_order_ko=kod.id_prod_order_ko AND ko.is_locked=1 AND ko.is_void=2 AND NOT ISNULL(kod.id_prod_order)
		ORDER BY kod.id_prod_order_ko_det DESC
	)ko GROUP BY ko.id_prod_order
)ko ON ko.id_prod_order=po.id_prod_order
LEFT JOIN
(
    SELECT id_prod_order
    FROM `tb_prod_order_attach`
    WHERE id_report_status=6
    GROUP BY id_prod_order
)att ON att.id_prod_order=po.id_prod_order
WHERE po.`id_report_status`='6' AND IF(co.id_country=5,NOT ISNULL(ko.id_prod_order_ko),IF(po.prod_order_date>='2021-12-31',NOT ISNULL(att.id_prod_order),TRUE))
GROUP BY po.`id_prod_order`"
        viewSearchLookupQuery(SLEFGPO, query, "id_prod_order", "view_po", "id_prod_order")
    End Sub

    Private Sub BImport_Click(sender As Object, e As EventArgs) Handles BGenerate.Click
        Dim q As String = "INSERT INTO tb_qc_report1_sum(`id_prod_order`,`created_date`,`created_by`,`id_report_status`) VALUES('" & SLEFGPO.EditValue.ToString & "',NOW(),'" & id_user & "','1'); SELECT LAST_INSERT_ID();"
        id = execute_query(q, 0, True, "", "", "", "")
        '
        load_head()
    End Sub

    Sub load_img()
        Dim q As String = "SELECT id_qc_report1_img,note FROM tb_qc_report1_img WHERE id_qc_report1_sum ='" & id & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCImage.DataSource = dt
    End Sub

    Private Sub BUploadImg_Click(sender As Object, e As EventArgs) Handles BUploadImg.Click
        If Not PictureEdit1.EditValue Is Nothing And Not MemoEdit1.Text = "" Then
            Dim q As String = "INSERT INTO tb_qc_report1_img(id_qc_report1_sum,note) VALUES('" & id & "','" & addSlashes(MemoEdit1.Text) & "'); SELECT LAST_INSERT_ID()"
            Dim id_img As String = execute_query(q, 0, True, "", "", "", "")
            save_image_ori(PictureEdit1, imagedir, id_img & ".jpg")
            '
            PictureEdit1.EditValue = Nothing
            MemoEdit1.Text = ""
            '
            load_img()
            XTCImage.SelectedTabPageIndex = 0
        Else
            warningCustom("Please upload image and fill note")
        End If
    End Sub

    Private Sub BRefreshImg_Click(sender As Object, e As EventArgs) Handles BRefreshImg.Click
        load_img()
    End Sub

    Private Sub GVImage_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GVImage.CustomUnboundColumnData
        If e.Column.FieldName = "img" Then
            Dim images As Hashtable = New Hashtable()

            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim id As String = CStr(view.GetListSourceRowCellValue(e.ListSourceRowIndex, "id_qc_report1_img"))

            Dim fileName As String = id & ".jpg".ToLower

            If (Not images.ContainsKey(fileName)) Then
                Dim img As Image = Nothing
                Dim resizeImg As Image = Nothing

                Try
                    Dim filePath As String = DevExpress.Utils.FilesHelper.FindingFileName(imagedir, fileName, False)

                    img = Image.FromFile(filePath)

                    resizeImg = img.GetThumbnailImage(100, 100, Nothing, Nothing)
                Catch
                End Try

                images.Add(fileName, resizeImg)
            End If

            e.Value = images(fileName)
        End If
    End Sub
End Class