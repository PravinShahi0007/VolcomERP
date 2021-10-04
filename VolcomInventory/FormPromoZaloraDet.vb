Public Class FormPromoZaloraDet
    Public id As String = "-1"
    Public action As String = ""
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim rmt_propose As String = "351"

    Private Sub FormPromoZaloraDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        TxtDiscountValue.EditValue = 0.00
        TxtVolcomPros.EditValue = 0.00
        XTPReconcile.PageVisible = False

        If action = "ins" Then
            'option
            BtnCreateNew.Visible = True
            Width = 441
            Height = 294
            WindowState = FormWindowState.Normal
            MaximizeBox = False
            FormBorderStyle = FormBorderStyle.FixedDialog
            StartPosition = FormStartPosition.CenterScreen
            PanelControl1.Visible = False
            PanelControlBottom.Visible = False
            'location form
            Dim r As Rectangle
            If Parent IsNot Nothing Then
                r = Parent.RectangleToScreen(Parent.ClientRectangle)
            Else
                r = Screen.FromPoint(Location).WorkingArea
            End If

            Dim x = r.Left + (r.Width - Width) \ 2
            Dim y = r.Top + (r.Height - Height) \ 2
            Location = New Point(x, y)

            'default date
            Dim curr_date As DateTime = getTimeDB()
            DEStart.EditValue = curr_date
            DEEnd.EditValue = curr_date
            TxtNumber.Text = "[auto generated]"
        ElseIf action = "upd" Then
            Dim pz As New ClassPromoZalora()
            Dim query As String = pz.queryMain("AND p.id_promo_zalora='" + id + "' ", "2")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtNumber.Text = data.Rows(0)("number").ToString
            DECreated.EditValue = data.Rows(0)("propose_created_date")
            TxtCreatedBy.Text = data.Rows(0)("propose_created_by_name").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            TxtPromoName.Text = data.Rows(0)("promo_name").ToString
            TxtDiscountCode.Text = data.Rows(0)("discount_code").ToString
            TxtDiscountValue.EditValue = data.Rows(0)("discount_value")
            TxtVolcomPros.EditValue = data.Rows(0)("volcom_pros")
            DEStart.EditValue = data.Rows(0)("start_period")
            DEEnd.EditValue = data.Rows(0)("end_period")
            MENote.Text = data.Rows(0)("propose_note").ToString

            'detail
            viewDetail()
            allow_status()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCreateNew_Click(sender As Object, e As EventArgs) Handles BtnCreateNew.Click
        If Not checkHead() Then
            warningCustom("Please input all data")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to create new propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                saveHead()
            End If
        End If
    End Sub

    Function checkHead()
        If TxtPromoName.Text <> "" And TxtDiscountCode.Text <> "" And TxtDiscountValue.EditValue <> 0 And TxtVolcomPros.EditValue <> 0 Then
            Return True
        Else
            Return False
        End If
    End Function


    Sub saveHead()
        Dim promo_name As String = addSlashes(TxtPromoName.Text)
        Dim discount_code As String = addSlashes(TxtDiscountCode.Text)
        Dim discount_value As String = decimalSQL(TxtDiscountValue.EditValue.ToString)
        Dim volcom_pros As String = decimalSQL(TxtVolcomPros.EditValue.ToString)
        Dim start_period As String = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd HH:mm:ss")
        Dim end_period As String = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd HH:mm:ss")
        Dim propose_note As String = addSlashes(MENote.Text)

        If action = "ins" Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "INSERT INTO tb_promo_zalora(`promo_name`,`discount_code` ,`discount_value`,`volcom_pros`,`start_period`,`end_period` ,`propose_created_date`,`propose_created_by`,`id_report_status`,`rmt_propose`,`propose_note`)
            VALUES ('" + promo_name + "','" + discount_code + "' ,'" + discount_value + "','" + volcom_pros + "','" + start_period + "','" + end_period + "' ,NOW(),'" + id_user + "','" + id_report_status + "','" + rmt_propose + "','" + propose_note + "'); SELECT LAST_INSERT_ID(); "
            id = execute_query(query, 0, True, "", "", "", "")
            refreshMainview()
            FormPromoZalora.is_load_new = True
            Close()
            Cursor = Cursors.Default
        ElseIf action = "upd" Then

        End If
    End Sub

    Sub refreshMainview()
        FormPromoZalora.viewData()
        FormPromoZalora.GVData.FocusedRowHandle = find_row(FormPromoZalora.GVData, "id_promo_zalora", id)
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT pd.id_promo_zalora_det, pd.id_promo_zalora, 
        pd.id_product, p.product_full_code AS `code`, cd.`class`, p.product_display_name AS `name`, cd.sht,cd.color, sz.display_name AS `size`, 
        pd.total_qty, pd.id_design_price, pd.design_price 
        FROM tb_promo_zalora_det pd
        INNER JOIN tb_m_product p ON p.id_product = pd.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail sz ON sz.id_code_detail = pc.id_code_detail
        LEFT JOIN (
	        SELECT dc.id_design, 
	        MAX(CASE WHEN cd.id_code=32 THEN cd.id_code_detail END) AS `id_division`,
	        MAX(CASE WHEN cd.id_code=32 THEN cd.code_detail_name END) AS `division`,
	        MAX(CASE WHEN cd.id_code=30 THEN cd.id_code_detail END) AS `id_class`,
	        MAX(CASE WHEN cd.id_code=30 THEN cd.display_name END) AS `class`,
	        MAX(CASE WHEN cd.id_code=14 THEN cd.id_code_detail END) AS `id_color`,
	        MAX(CASE WHEN cd.id_code=14 THEN cd.display_name END) AS `color`,
	        MAX(CASE WHEN cd.id_code=14 THEN cd.code_detail_name END) AS `color_desc`,
	        MAX(CASE WHEN cd.id_code=43 THEN cd.id_code_detail END) AS `id_sht`,
	        MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`
	        FROM tb_m_design_code dc
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	        AND cd.id_code IN (32,30,14, 43)
	        GROUP BY dc.id_design
        ) cd ON cd.id_design = p.id_design
        WHERE pd.id_promo_zalora=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemPropose.DataSource = data
        GVtemPropose.BestFitColumns()
        Cursor = Cursors.Default
    End Sub
End Class