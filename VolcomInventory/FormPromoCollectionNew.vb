Public Class FormPromoCollectionNew
    Dim rmt As String = FormPromoCollection.rmt

    Sub viewPromoType()
        Dim query As String = "SELECT p.id_promo, p.promo FROM tb_promo p ORDER BY p.id_promo ASC "
        viewSearchLookupQuery(SLEPromoType, query, "id_promo", "promo", "id_promo")
    End Sub

    Private Sub FormPromoCollectionNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewPromoType()
        viewStore()
    End Sub

    Sub viewStore()
        Cursor = Cursors.WaitCursor
        'filter
        Dim cond As String = ""
        Dim id_vios As String = get_setup_field("shopify_comp_group")
        If rmt = "250" Then
            cond = "AND c.id_comp_group='" + id_vios + "' "
        Else
            cond = "AND c.id_comp_group!='" + id_vios + "' "
        End If
        Dim query As String = "SELECT cg.id_comp_group, cg.description
        FROM tb_m_comp c
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        WHERE c.id_commerce_type=2 " + cond + "
        GROUP BY cg.id_comp_group "
        viewSearchLookupQuery(SLEStore, query, "id_comp_group", "description", "id_comp_group")
        If rmt <> "250" Then
            SLEStore.EditValue = Nothing
        Else
            SLEStore.Enabled = False
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormPromoCollectionNew_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Function validateInput() As Boolean
        If SLEStore.EditValue = Nothing Or TxtTag.Text = "" Or DEStart.EditValue = Nothing Or DEEnd.EditValue = Nothing Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub BtnCreateNew_Click(sender As Object, e As EventArgs) Handles BtnCreateNew.Click
        If Not validateInput() Then
            stopCustom("Please complete all data")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to create new propose  ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim id_promo As String = SLEPromoType.EditValue.ToString
                Dim tag As String = addSlashes(TxtTag.Text)
                Dim start_period As String = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd HH:mm:ss")
                Dim end_period As String = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd HH:mm:ss")
                Dim note As String = addSlashes(MENote.Text)
                Dim promo_name As String = addSlashes(TxtPromoName.Text)
                Dim id_comp_group As String = SLEStore.EditValue.ToString

                Dim query As String = "INSERT INTO tb_ol_promo_collection(id_promo, tag, created_date, created_by, start_period, end_period, id_report_status, note, promo_name,id_comp_group)
                VALUES('" + id_promo + "','" + tag + "', NOW(), '" + id_user + "', '" + start_period + "', '" + end_period + "',1, '" + note + "', '" + promo_name + "','" + id_comp_group + "');SELECT LAST_INSERT_ID(); "
                Dim id As String = execute_query(query, 0, True, "", "", "", "")
                Dim rmt As String = "250"
                execute_non_query("CALL gen_number(" + id + ", " + rmt + ")", True, "", "", "", "")

                'refresh
                FormPromoCollection.viewPropose()
                FormPromoCollection.GVData.FocusedRowHandle = find_row(FormPromoCollection.GVData, "id_ol_promo_collection", id)
                Cursor = Cursors.Default

                Opacity = 0
                FormPromoCollectionDet.action = "upd"
                FormPromoCollectionDet.id = id
                FormPromoCollectionDet.ShowDialog()
                Close()
            End If
        End If
    End Sub

    Private Sub SLEStore_EditValueChanged(sender As Object, e As EventArgs) Handles SLEStore.EditValueChanged
        If SLEStore.EditValue <> Nothing Then
            'cek on process
            Dim qcek As String = "SELECT * FROM tb_ol_promo_collection c WHERE c.id_report_status<5 AND c.is_use_discount_code=2 AND c.id_comp_group='" + SLEStore.EditValue.ToString + "' "
            Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
            If dcek.Rows.Count > 0 Then
                stopCustom("Please complete all pending propose first")
                Close()
            End If

            'cek date
            Dim min_date As DateTime
            Dim qmin As String = "SELECT DATE(DATE_ADD(c.end_period,INTERVAL 1 DAY)) AS `min_date` FROM tb_ol_promo_collection c WHERE c.id_report_status=6 AND c.is_use_discount_code=2 AND c.id_comp_group='" + SLEStore.EditValue.ToString + "' ORDER BY c.id_ol_promo_collection DESC LIMIT 1 "
            Dim dmin As DataTable = execute_query(qmin, -1, True, "", "", "", "")
            If dmin.Rows.Count > 0 Then
                min_date = dmin.Rows(0)("min_date")
            Else
                min_date = getTimeDB()
            End If
            DEStart.Properties.MinValue = min_date
            DEEnd.Properties.MinValue = min_date
        End If
    End Sub
End Class