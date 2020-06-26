Public Class FormPromoCollectionDet
    Public action As String = "-1"
    Public id As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim rmt As String = "250"

    Private Sub FormPromoCollectionDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewPromoType()
        actionLoad()
    End Sub

    Private Sub FormPromoCollectionDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewPromoType()
        Dim query As String = "SELECT p.id_promo, p.promo FROM tb_promo p ORDER BY p.promo DESC "
        viewSearchLookupQuery(SLEPromoType, query, "id_promo", "promo", "id_promo")
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        If action = "ins" Then
            DEStart.EditValue = Now
            DEEnd.EditValue = Now
            DECreated.EditValue = Now
        Else
            Dim p As New ClassPromoCollection()
            Dim query As String = p.queryMain("AND p.id_ol_promo_collection=" + id + "", "2")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            SLEPromoType.EditValue = data.Rows(0)("id_promo").ToString
            DEStart.EditValue = data.Rows(0)("start_period")
            DEEnd.EditValue = data.Rows(0)("end_period")
            MENote.Text = data.Rows(0)("note").ToString
            TxtNumber.Text = data.Rows(0)("number").ToString
            DECreated.EditValue = data.Rows(0)("created_date")
            TxtCreatedBy.Text = data.Rows(0)("created_by_name").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            is_confirm = data.Rows(0)("is_confirm").ToString
            viewDetail()
            allow_status()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT pd.id_ol_promo_collection_det, pd.id_ol_promo_collection, 
        pd.id_design, d.design_code AS `code`, d.design_display_name AS `name`, 
        GROUP_CONCAT(DISTINCT cd.code_detail_name ORDER BY cd.id_code_detail ASC) AS `size_chart`
        FROM tb_ol_promo_collection_det pd
        INNER JOIN tb_m_design d ON d.id_design = pd.id_design
        INNER JOIN tb_m_product prod ON prod.id_design = d.id_design
        INNER JOIN tb_m_product_code prod_code ON prod_code.id_product = prod.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prod_code.id_code_detail
        WHERE pd.id_ol_promo_collection=" + id + "
        GROUP BY pd.id_ol_promo_collection_det 
        ORDER BY d.design_code_import ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Sub viewDetailProduct()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT pd.id_ol_promo_collection_det, pd.id_ol_promo_collection, 
        pd.id_design, prod.id_product, prod.product_full_code AS `code`, d.design_display_name AS `name`, cd.code_detail_name AS `size`
        FROM tb_ol_promo_collection_det pd
        INNER JOIN tb_m_design d ON d.id_design = pd.id_design
        INNER JOIN tb_m_product prod ON prod.id_design = d.id_design
        INNER JOIN tb_m_product_code prod_code ON prod_code.id_product = prod.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prod_code.id_code_detail
        WHERE pd.id_ol_promo_collection=" + id + "
        ORDER BY d.design_code_import ASC, cd.id_code_detail ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProduct.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Sub allow_status()
        XTPProduct.PageVisible = True
        PanelControlAdd.Visible = False
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        If is_confirm = "2" And is_view = "-1" Then
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            MENote.Enabled = True
            BtnPrint.Visible = False
            BtnSaveChanges.Visible = True
            MENote.Enabled = True
            GVData.OptionsBehavior.ReadOnly = False
            SLEPromoType.Enabled = True
            DEStart.Enabled = True
            DEEnd.Enabled = True
        Else
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            MENote.Enabled = False
            BtnPrint.Visible = True
            BtnSaveChanges.Visible = False
            MENote.Enabled = False
            GVData.OptionsBehavior.ReadOnly = True
            SLEPromoType.Enabled = False
            DEStart.Enabled = False
            DEEnd.Enabled = False
        End If

        'reset propose
        If is_view = "-1" And is_confirm = "1" Then
            BtnResetPropose.Visible = True
        Else
            BtnResetPropose.Visible = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
            BtnResetPropose.Visible = False
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
            BtnResetPropose.Visible = False
            BtnConfirm.Visible = False
            MENote.Enabled = False
            BtnPrint.Visible = False
            PanelControlAdd.Visible = False
            BtnSaveChanges.Visible = False
            MENote.Enabled = False
            GVData.OptionsBehavior.ReadOnly = True
            SLEPromoType.Enabled = False
            DEStart.Enabled = False
            DEEnd.Enabled = False
        End If
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click

    End Sub

    Private Sub XTCData_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCData.SelectedPageChanged
        If XTCData.SelectedTabPageIndex = 1 Then
            viewDetailProduct()
        End If
    End Sub

    Sub saveHead()
        'head
        Dim id_promo As String = SLEPromoType.EditValue.ToString
        Dim start_period As String = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd HH:mm:ss")
        Dim end_period As String = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd HH:mm:ss")
        If action = "ins" Then

        ElseIf action = "upd" Then

        End If
        Dim query_head As String = "UPDATE tb_ol_promo_collection SET id_promo='' 
        WHERE id_fg_propose_price='" + id + "' "
        execute_non_query(query_head, True, "", "", "", "")
    End Sub


    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        makeSafeGV(GVData)
        If GVData.RowCount <= 0 Then
            stopCustom("No propose were made. If you want to cancel this propose, please click 'Cancel Propose'")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm this Propose Price ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                'update 
                saveHead()

                'update confirm
                Dim query As String = "UPDATE tb_fg_propose_price SET is_confirm=1 WHERE id_fg_propose_price='" + id + "'"
                execute_non_query(query, True, "", "", "", "")

                'submit approval 
                submit_who_prepared(rmt, id, id_user)
                BtnConfirm.Visible = False
                actionLoad()
                infoCustom("Propose Price submitted. Waiting for approval.")
                Cursor = Cursors.Default
            End If
        End If
    End Sub
End Class