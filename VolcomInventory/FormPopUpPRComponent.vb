Public Class FormPopUpPRComponent 
    Public id_purc As String = "-1"
    Public id_rec As String = "-1"
    Public id_pr As String = "-1"
    Public id_pr_det As String = "-1"
    'for edit
    Public id_det As String = "-1"
    Public type As String = "-1"

    Private Sub FormPopUpPRComponent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_sample_pr()
        view_ovh()
        view_dc(LETerm)

        If id_rec <> "-1" Then
            'rec selected
            XTPReceive.PageVisible = True
            XTPPurchase.PageVisible = False
            view_list_rec(id_rec)
        Else
            'no rec yet
            XTPReceive.PageVisible = False
            XTPPurchase.PageVisible = True
            view_list_purchase(id_purc)
        End If

        'focus to selected
        Dim pagex As Integer
        pagex = 0

        If type = "1" Then
            pagex = 1
            GVSamplePR.FocusedRowHandle = find_row(GVSamplePR, "id_pr_sample_purc", id_det)
        ElseIf type = "2" Then
            If id_rec <> "-1" Then
                pagex = 3
                GVListReceive.FocusedRowHandle = find_row(GVListReceive, "id_sample_purc_det", id_det)
            Else
                pagex = 2
                GVListPurchase.FocusedRowHandle = find_row(GVListPurchase, "id_sample_purc_det", id_det)
            End If
        ElseIf type = "3" Then
            pagex = 0
            GVOVH.FocusedRowHandle = find_row(GVOVH, "id_ovh", id_det)
        Else
            pagex = 0
        End If
        XtraTabControl1.SelectedTabPageIndex = pagex
        'end focus to selected
    End Sub

    Sub view_list_purchase(ByVal id_sample_purc As String)
        Dim query = "CALL view_purc_sample_det('" & id_sample_purc & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
        If data.Rows.Count > 0 Then
            BSavePurc.Enabled = True
        Else
            BSavePurc.Enabled = False
        End If
    End Sub

    Sub view_dc(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_dc,dc FROM tb_lookup_dc"
        viewLookupQuery(lookup, query, 0, "dc", "id_dc")
    End Sub

    Sub view_list_rec(ByVal id_sample_purc_rec As String)
        Dim query = "CALL view_pr_sample_from_rec('" & id_sample_purc_rec & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListReceive.DataSource = data

        If data.Rows.Count > 0 Then
            BSaveRec.Enabled = True
        Else
            BSaveRec.Enabled = False
        End If
    End Sub

    Sub view_sample_pr()
        Dim query As String = "SELECT z.pr_sample_purc_dp,z.pr_sample_purc_total,z.id_pr_sample_purc,z.pr_sample_purc_number,DATE_FORMAT(z.pr_sample_purc_date,'%d %M %Y') as pr_sample_purc_date,g.season_orign,b.sample_purc_number,d.comp_name AS comp_to, "
        query += "DATE_FORMAT(DATE_ADD(b.sample_purc_date,INTERVAL (b.sample_purc_top+b.sample_purc_lead_time) DAY),'%d %M %Y') AS sample_purc_top "
        query += "FROM tb_pr_sample_purc z "
        query += "INNER JOIN tb_sample_purc b ON b.id_sample_purc=z.id_sample_purc "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=z.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
        query += "INNER JOIN tb_season_orign g ON g.id_season_orign=b.id_season_orign WHERE z.id_sample_purc='" & id_purc & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSamplePR.DataSource = data
        If data.Rows.Count > 0 Then
            BSavePR.Enabled = True
        Else
            BSavePR.Enabled = False
        End If
    End Sub

    Sub view_ovh()
        Dim data As DataTable = execute_query("SELECT * FROM tb_m_ovh a INNER JOIN tb_m_uom b ON b.id_uom = a.id_uom ORDER BY overhead_code ASC", -1, True, "", "", "", "")
        GCOVH.DataSource = data
        If data.Rows.Count > 0 Then
            BSaveOvh.Enabled = True
            '
            BtnEditOVH.Visible = True
            BtnDeleteOVH.Visible = True
            '
            load_ovh()
        Else
            BtnEditOVH.Visible = False
            BtnDeleteOVH.Visible = False
            '
            BSaveOvh.Enabled = False
        End If
    End Sub

    Private Sub GVOVH_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVOVH.RowClick
        load_ovh()
    End Sub

    Sub load_ovh()
        TEUOM.Text = GVOVH.GetFocusedRowCellDisplayText("uom").ToString
    End Sub

    Sub calculate_ovh()
        Dim tot, qty, price As Decimal

        Try
            price = Decimal.Parse(TEPriceOvh.Text)
            qty = Decimal.Parse(TEQtyOvh.Text)

            tot = price * qty

            TEPriceTotOvh.Text = tot.ToString("0.00")
        Catch ex As Exception
        End Try

    End Sub

    Private Sub TEPriceOvh_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEPriceOvh.EditValueChanged
        calculate_ovh()
    End Sub

    Private Sub TEQtyOvh_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEQtyOvh.EditValueChanged
        calculate_ovh()
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVListReceive_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListReceive.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BCancelOvh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelOvh.Click
        Close()
    End Sub

    Private Sub GCancelPR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GCancelPR.Click
        Close()
    End Sub

    Private Sub BCancelPurc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelPurc.Click
        Close()
    End Sub

    Private Sub BCancelRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelRec.Click
        Close()
    End Sub
    Private Sub BSaveOvh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSaveOvh.Click
        If id_pr = "-1" Then
            If id_det = "-1" Then
                If check_on_gv(GVOVH.GetFocusedRowCellDisplayText("id_ovh").ToString, "3", "1") Then
                    errorDuplicate(" Item on list.")
                Else
                    Dim newRow As DataRow = (TryCast(FormSamplePRDet.GCListPurchase.DataSource, DataTable)).NewRow()
                    newRow("name") = GVOVH.GetFocusedRowCellDisplayText("overhead").ToString
                    newRow("id_det") = GVOVH.GetFocusedRowCellDisplayText("id_ovh").ToString
                    newRow("code") = GVOVH.GetFocusedRowCellDisplayText("overhead_code").ToString
                    newRow("qty") = TEQtyOvh.EditValue
                    newRow("type") = "3"
                    newRow("uom") = GVOVH.GetFocusedRowCellDisplayText("uom").ToString
                    newRow("price") = TEPriceOvh.EditValue
                    'tot or debt
                    If LETerm.EditValue = "1" Then
                        newRow("debit") = TEPriceTotOvh.EditValue
                    Else
                        newRow("total") = TEPriceTotOvh.EditValue
                    End If
                    '
                    TryCast(FormSamplePRDet.GCListPurchase.DataSource, DataTable).Rows.Add(newRow)
                    FormSamplePRDet.GCListPurchase.RefreshDataSource()
                    FormSamplePRDet.show_but()
                    FormSamplePRDet.calculate()
                    Close()
                End If
            Else
                If check_on_gv(GVOVH.GetFocusedRowCellDisplayText("id_ovh").ToString, "3", "2") Then
                    errorDuplicate(" Item on list.")
                Else
                    FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "id_det", GVOVH.GetFocusedRowCellDisplayText("id_ovh").ToString)
                    FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "name", GVOVH.GetFocusedRowCellDisplayText("overhead").ToString)
                    FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "code", GVOVH.GetFocusedRowCellDisplayText("overhead_code").ToString)
                    FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "qty", TEQtyOvh.EditValue)
                    FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "type", "3")
                    FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "price", TEPriceOvh.EditValue)
                    FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "uom", GVOVH.GetFocusedRowCellDisplayText("uom").ToString)
                    If LETerm.EditValue = "1" Then
                        FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "debit", TEPriceTotOvh.EditValue)
                        FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "total", "")
                    Else
                        FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "debit", "")
                        FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "total", TEPriceTotOvh.EditValue)
                    End If

                    FormSamplePRDet.calculate()
                    Close()
                End If
            End If
        Else
            'tot or debt
            Dim id_dc As String
            If LETerm.EditValue = "1" Then
                id_dc = 1
            Else
                id_dc = 2
            End If
            If id_det = "-1" Then
                Dim query As String = String.Format("INSERT INTO tb_pr_sample_purc_det(id_pr_sample_purc,id_pr_det_type,id_ovh,pr_sample_purc_det_price,pr_sample_purc_det_qty,id_dc) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", id_pr, "3", GVOVH.GetFocusedRowCellDisplayText("id_ovh").ToString, decimalSQL(TEPriceOvh.EditValue.ToString), decimalSQL(TEQtyOvh.EditValue.ToString), id_dc)
                execute_non_query(query, True, "", "", "", "")
                FormSamplePRDet.view_list_pr()
                FormSamplePRDet.show_but()
                FormSamplePRDet.calculate()
                Close()
            Else
                Dim query As String = String.Format("UPDATE tb_pr_sample_purc_det SET id_pr_det_type='{0}',id_sample_purc_det=NULL,id_ovh='{1}',id_pr_sample_purc_dp=NULL,pr_sample_purc_det_price='{2}',pr_sample_purc_det_qty='{3}',id_dc='{4}' WHERE id_pr_sample_purc_det='{5}'", "3", GVOVH.GetFocusedRowCellDisplayText("id_ovh").ToString, decimalSQL(TEPriceOvh.EditValue.ToString), decimalSQL(TEQtyOvh.EditValue.ToString), id_dc, id_pr_det)
                execute_non_query(query, True, "", "", "", "")
                FormSamplePRDet.view_list_pr()
                FormSamplePRDet.show_but()
                FormSamplePRDet.calculate()
                Close()
            End If
        End If
    End Sub

    Private Sub BSavePurc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSavePurc.Click
        If id_pr = "-1" Then
            If id_det = "-1" Then
                If check_on_gv(GVListPurchase.GetFocusedRowCellDisplayText("id_sample_purc_det").ToString, "2", "1") Then
                    errorDuplicate(" Item on list.")
                Else
                    Dim newRow As DataRow = (TryCast(FormSamplePRDet.GCListPurchase.DataSource, DataTable)).NewRow()
                    newRow("id_det") = GVListPurchase.GetFocusedRowCellDisplayText("id_sample_purc_det").ToString
                    newRow("name") = GVListPurchase.GetFocusedRowCellDisplayText("name").ToString
                    newRow("code") = GVListPurchase.GetFocusedRowCellDisplayText("code").ToString
                    newRow("qty") = GVListPurchase.GetFocusedRowCellValue("qty")
                    newRow("type") = "2"
                    newRow("uom") = GVListPurchase.GetFocusedRowCellDisplayText("uom").ToString
                    newRow("price") = GVListPurchase.GetFocusedRowCellValue("price")
                    newRow("total") = GVListPurchase.GetFocusedRowCellValue("total")

                    TryCast(FormSamplePRDet.GCListPurchase.DataSource, DataTable).Rows.Add(newRow)
                    FormSamplePRDet.GCListPurchase.RefreshDataSource()
                    FormSamplePRDet.show_but()
                    FormSamplePRDet.calculate()
                    Close()
                End If
            Else
                If check_on_gv(GVListPurchase.GetFocusedRowCellDisplayText("id_sample_purc_det").ToString, "2", "2") Then
                    errorDuplicate(" Item on list.")
                Else
                    FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "id_det", GVListPurchase.GetFocusedRowCellDisplayText("id_sample_purc_det").ToString)
                    FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "name", GVListPurchase.GetFocusedRowCellDisplayText("name").ToString)
                    FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "code", GVListPurchase.GetFocusedRowCellDisplayText("code").ToString)
                    FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "qty", GVListPurchase.GetFocusedRowCellValue("qty"))
                    FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "type", "2")
                    FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "price", GVListPurchase.GetFocusedRowCellValue("price"))
                    FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "total", GVListPurchase.GetFocusedRowCellValue("total"))
                    FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "uom", GVListPurchase.GetFocusedRowCellDisplayText("uom").ToString)
                    FormSamplePRDet.calculate()
                    Close()
                End If

            End If
        Else
            If id_det = "-1" Then
                Dim query_jml As String = String.Format("SELECT COUNT(id_pr_sample_purc_det) FROM tb_pr_sample_purc_det WHERE id_pr_sample_purc='{0}' AND id_sample_purc_det='{1}' AND id_pr_det_type='{2}' AND id_pr_sample_purc_det !='{3}'", id_pr, GVListPurchase.GetFocusedRowCellDisplayText("id_sample_purc_det").ToString, "2", id_pr_det)
                Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
                If Not jml < 1 Then
                    errorDuplicate(" item on list.")
                Else
                    Dim query As String = String.Format("INSERT INTO tb_pr_sample_purc_det(id_pr_sample_purc,id_pr_det_type,id_sample_purc_det,pr_sample_purc_det_price,pr_sample_purc_det_qty,id_dc) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", id_pr, "2", GVListPurchase.GetFocusedRowCellDisplayText("id_sample_purc_det").ToString, decimalSQL(GVListPurchase.GetFocusedRowCellValue("price").ToString), decimalSQL(GVListPurchase.GetFocusedRowCellValue("qty").ToString), "2")
                    execute_non_query(query, True, "", "", "", "")
                    FormSamplePRDet.view_list_pr()
                    FormSamplePRDet.show_but()
                    FormSamplePRDet.calculate()
                    Close()
                End If
            Else
                Dim query_jml As String = String.Format("SELECT COUNT(id_pr_sample_purc_det) FROM tb_pr_sample_purc_det WHERE id_pr_sample_purc='{0}' AND id_sample_purc_det='{1}' AND id_pr_det_type='{2}' AND id_pr_sample_purc_det !='{3}'", id_pr, GVListPurchase.GetFocusedRowCellDisplayText("id_sample_purc_det").ToString, "2", id_pr_det)
                Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
                If Not jml < 1 Then
                    errorDuplicate(" item on list.")
                Else
                    Dim query As String = String.Format("UPDATE tb_pr_sample_purc_det SET id_pr_det_type='{0}',id_sample_purc_det='{1}',id_ovh=NULL,id_pr_sample_purc_dp=NULL,pr_sample_purc_det_price='{2}',pr_sample_purc_det_qty='{3}',id_dc='{4}' WHERE id_pr_sample_purc_det='{5}'", "2", GVListPurchase.GetFocusedRowCellDisplayText("id_sample_purc_det").ToString, decimalSQL(GVListPurchase.GetFocusedRowCellValue("price").ToString), decimalSQL(GVListPurchase.GetFocusedRowCellValue("qty").ToString), "2", id_pr_det)
                    execute_non_query(query, True, "", "", "", "")
                    FormSamplePRDet.view_list_pr()
                    FormSamplePRDet.show_but()
                    FormSamplePRDet.calculate()
                    Close()
                End If
            End If
        End If
    End Sub

    Private Sub BSaveRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSaveRec.Click
        If id_pr = "-1" Then
            If id_det = "-1" Then
                If check_on_gv(GVListReceive.GetFocusedRowCellDisplayText("id_sample_purc_det").ToString, "2", "1") Then
                    errorDuplicate(" Item on list.")
                Else
                    Dim newRow As DataRow = (TryCast(FormSamplePRDet.GCListPurchase.DataSource, DataTable)).NewRow()
                    newRow("id_det") = GVListReceive.GetFocusedRowCellDisplayText("id_sample_purc_det").ToString
                    newRow("name") = GVListReceive.GetFocusedRowCellDisplayText("name").ToString
                    newRow("code") = GVListReceive.GetFocusedRowCellDisplayText("code").ToString
                    newRow("qty") = GVListReceive.GetFocusedRowCellValue("qty")
                    newRow("type") = "2"
                    newRow("uom") = GVListReceive.GetFocusedRowCellDisplayText("uom").ToString
                    newRow("price") = GVListReceive.GetFocusedRowCellValue("price")
                    newRow("total") = GVListReceive.GetFocusedRowCellValue("total")

                    TryCast(FormSamplePRDet.GCListPurchase.DataSource, DataTable).Rows.Add(newRow)
                    FormSamplePRDet.GCListPurchase.RefreshDataSource()
                    FormSamplePRDet.show_but()
                    FormSamplePRDet.calculate()
                    Close()
                End If
            Else
                If check_on_gv(GVListReceive.GetFocusedRowCellDisplayText("id_sample_purc_det").ToString, "2", "2") Then
                    errorDuplicate(" Item on list.")
                Else
                    FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "id_det", GVListReceive.GetFocusedRowCellDisplayText("id_sample_purc_det").ToString)
                    FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "name", GVListReceive.GetFocusedRowCellDisplayText("name").ToString)
                    FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "code", GVListReceive.GetFocusedRowCellDisplayText("code").ToString)
                    FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "qty", GVListReceive.GetFocusedRowCellValue("qty"))
                    FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "type", "2")
                    FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "price", GVListReceive.GetFocusedRowCellValue("price"))
                    FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "total", GVListReceive.GetFocusedRowCellValue("total"))
                    FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "uom", GVListReceive.GetFocusedRowCellDisplayText("uom").ToString)

                    FormSamplePRDet.calculate()
                    Close()
                End If
            End If
        Else
            If id_det = "-1" Then
                Dim query_jml As String = String.Format("SELECT COUNT(id_pr_sample_purc_det) FROM tb_pr_sample_purc_det WHERE id_pr_sample_purc='{0}' AND id_sample_purc_det='{1}' AND id_pr_det_type='{2}' AND id_pr_sample_purc_det !='{3}'", id_pr, GVListReceive.GetFocusedRowCellDisplayText("id_sample_purc_det").ToString, "2", id_pr_det)
                Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
                If Not jml < 1 Then
                    errorDuplicate(" item on list.")
                Else
                    Dim query As String = String.Format("INSERT INTO tb_pr_sample_purc_det(id_pr_sample_purc,id_pr_det_type,id_sample_purc_det,pr_sample_purc_det_price,pr_sample_purc_det_qty,id_dc) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", id_pr, "2", GVListReceive.GetFocusedRowCellDisplayText("id_sample_purc_det").ToString, decimalSQL(GVListReceive.GetFocusedRowCellValue("price").ToString), decimalSQL(GVListReceive.GetFocusedRowCellValue("qty").ToString), "2")
                    execute_non_query(query, True, "", "", "", "")
                    FormSamplePRDet.view_list_pr()
                    FormSamplePRDet.show_but()
                    FormSamplePRDet.calculate()
                    Close()
                End If
            Else
                Dim query_jml As String = String.Format("SELECT COUNT(id_pr_sample_purc_det) FROM tb_pr_sample_purc_det WHERE id_pr_sample_purc='{0}' AND id_sample_purc_det='{1}' AND id_pr_det_type='{2}' AND id_pr_sample_purc_det !='{3}'", id_pr, GVListReceive.GetFocusedRowCellDisplayText("id_sample_purc_det").ToString, "2", id_pr_det)
                Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
                If Not jml < 1 Then
                    errorDuplicate(" item on list.")
                Else
                    Dim query As String = String.Format("UPDATE tb_pr_sample_purc_det SET id_pr_det_type='{0}',id_sample_purc_det='{1}',id_ovh=NULL,id_pr_sample_purc_dp=NULL,pr_sample_purc_det_price='{2}',pr_sample_purc_det_qty='{3}',id_dc='{4}' WHERE id_pr_sample_purc_det='{5}'", "2", GVListReceive.GetFocusedRowCellDisplayText("id_sample_purc_det").ToString, decimalSQL(GVListReceive.GetFocusedRowCellValue("price").ToString), decimalSQL(GVListReceive.GetFocusedRowCellValue("qty").ToString), "2", id_pr_det)
                    execute_non_query(query, True, "", "", "", "")
                    FormSamplePRDet.view_list_pr()
                    FormSamplePRDet.show_but()
                    FormSamplePRDet.calculate()
                    Close()
                End If
            End If
        End If
    End Sub

    Private Sub BSavePR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSavePR.Click
        If id_pr = "-1" Then
            If id_det = "-1" Then
                If check_on_gv(GVSamplePR.GetFocusedRowCellDisplayText("id_pr_sample_purc").ToString, "1", "1") Then
                    errorDuplicate(" Item on list.")
                Else
                    Dim newRow As DataRow = (TryCast(FormSamplePRDet.GCListPurchase.DataSource, DataTable)).NewRow()
                    newRow("id_det") = GVSamplePR.GetFocusedRowCellDisplayText("id_pr_sample_purc").ToString
                    newRow("name") = "Payment Request"
                    newRow("code") = GVSamplePR.GetFocusedRowCellDisplayText("pr_sample_purc_number").ToString
                    newRow("qty") = "1"
                    newRow("type") = "1"
                    newRow("price") = GVSamplePR.GetFocusedRowCellValue("pr_sample_purc_dp")
                    newRow("debit") = GVSamplePR.GetFocusedRowCellValue("pr_sample_purc_dp")

                    TryCast(FormSamplePRDet.GCListPurchase.DataSource, DataTable).Rows.Add(newRow)
                    FormSamplePRDet.GCListPurchase.RefreshDataSource()
                    FormSamplePRDet.show_but()
                    FormSamplePRDet.calculate()
                    Close()
                End If
            Else
                If check_on_gv(GVSamplePR.GetFocusedRowCellDisplayText("id_pr_sample_purc").ToString, "1", "2") Then
                    errorDuplicate(" Item on list.")
                Else
                    FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "id_det", GVSamplePR.GetFocusedRowCellDisplayText("id_pr_sample_purc").ToString)
                    FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "name", "Payment Request")
                    FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "code", GVSamplePR.GetFocusedRowCellDisplayText("pr_sample_purc_number").ToString)
                    FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "qty", "1")
                    FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "type", "1")
                    FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "price", GVSamplePR.GetFocusedRowCellValue("pr_sample_purc_dp"))
                    FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "total", Nothing)
                    FormSamplePRDet.GVListPurchase.SetRowCellValue(FormSamplePRDet.GVListPurchase.FocusedRowHandle, "debit", GVSamplePR.GetFocusedRowCellValue("pr_sample_purc_dp"))
                    FormSamplePRDet.calculate()
                    Close()
                End If
            End If
        Else
            If id_det = "-1" Then
                Dim query_jml As String = String.Format("SELECT COUNT(id_pr_sample_purc_det) FROM tb_pr_sample_purc_det WHERE id_pr_sample_purc='{0}' AND id_pr_sample_purc_dp='{1}' AND id_pr_det_type='{2}' AND id_pr_sample_purc_det !='{3}'", id_pr, GVSamplePR.GetFocusedRowCellDisplayText("id_pr_sample_purc").ToString, "1", id_pr_det)
                Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
                If Not jml < 1 Then
                    errorDuplicate(" item on list.")
                Else
                    Dim query As String = String.Format("INSERT INTO tb_pr_sample_purc_det(id_pr_sample_purc,id_pr_det_type,id_pr_sample_purc_dp,pr_sample_purc_det_price,pr_sample_purc_det_qty,id_dc) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", id_pr, "1", GVSamplePR.GetFocusedRowCellDisplayText("id_pr_sample_purc").ToString, decimalSQL(GVSamplePR.GetFocusedRowCellValue("pr_sample_purc_dp").ToString), "1", "1")
                    execute_non_query(query, True, "", "", "", "")
                    FormSamplePRDet.view_list_pr()
                    FormSamplePRDet.show_but()
                    FormSamplePRDet.calculate()
                    Close()
                End If
            Else
                Dim query_jml As String = String.Format("SELECT COUNT(id_pr_sample_purc_det) FROM tb_pr_sample_purc_det WHERE id_pr_sample_purc='{0}' AND id_pr_sample_purc_dp='{1}' AND id_pr_det_type='{2}' AND id_pr_sample_purc_det !='{3}'", id_pr, GVSamplePR.GetFocusedRowCellDisplayText("id_pr_sample_purc").ToString, "1", id_pr_det)
                Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
                If Not jml < 1 Then
                    errorDuplicate(" item on list.")
                Else
                    Dim query As String = String.Format("UPDATE tb_pr_sample_purc_det SET id_pr_det_type='{0}',id_sample_purc_det=NULL,id_ovh=NULL,id_pr_sample_purc_dp='{1}',pr_sample_purc_det_price='{2}',pr_sample_purc_det_qty='{3}',id_dc='{4}' WHERE id_pr_sample_purc_det='{5}'", "1", GVSamplePR.GetFocusedRowCellDisplayText("id_pr_sample_purc").ToString, decimalSQL(GVSamplePR.GetFocusedRowCellValue("pr_sample_purc_dp").ToString), "1", "1", id_pr_det)
                    execute_non_query(query, True, "", "", "", "")
                    FormSamplePRDet.view_list_pr()
                    FormSamplePRDet.show_but()
                    FormSamplePRDet.calculate()
                    Close()
                End If
            End If
        End If
    End Sub

    Function check_on_gv(ByVal id_det As String, ByVal type As String, ByVal opt As String)
        ' opt 
        ' 1 = new
        ' 2 = edit

        Dim temp_check As Boolean = False
        For i As Integer = 0 To FormSamplePRDet.GVListPurchase.RowCount - 1
            If opt = "1" Then
                If type = FormSamplePRDet.GVListPurchase.GetRowCellValue(i, "type").ToString() And id_det = FormSamplePRDet.GVListPurchase.GetRowCellValue(i, "id_det").ToString() Then
                    temp_check = True
                    Exit For
                End If
            Else
                If type = FormSamplePRDet.GVListPurchase.GetRowCellValue(i, "type").ToString() And id_det = FormSamplePRDet.GVListPurchase.GetRowCellValue(i, "id_det").ToString() And Not i = FormSamplePRDet.GVListPurchase.FocusedRowHandle Then
                    temp_check = True
                    Exit For
                End If
            End If
        Next

        Return temp_check
    End Function

    Private Sub FormPopUpPRComponent_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnAddOVH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddOVH.Click
        FormMasterOVHSingle.id_ovh = "-1"
        FormMasterOVHSingle.ShowDialog()
        view_ovh()
    End Sub

    Private Sub BtnEditOVH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditOVH.Click
        FormMasterOVHSingle.id_ovh = GVOVH.GetFocusedRowCellValue("id_ovh").ToString
        FormMasterOVHSingle.ShowDialog()
        view_ovh()
    End Sub

    Private Sub BtnDeleteOVH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDeleteOVH.Click
        Dim confirm As DialogResult
        Dim query As String

        Cursor = Cursors.WaitCursor
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Try
                Dim id_ovh As String = FormMasterOVH.GVOVH.GetFocusedRowCellDisplayText("id_ovh").ToString
                query = String.Format("DELETE FROM tb_m_ovh WHERE id_ovh='{0}'", id_ovh)
                execute_non_query(query, True, "", "", "", "")
                FormMasterOVH.view_ovh()
            Catch ex As Exception
                errorCustom("This overhead already used.")
            End Try
        End If
        Cursor = Cursors.Default

        view_ovh()
    End Sub
End Class