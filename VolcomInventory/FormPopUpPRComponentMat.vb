Public Class FormPopUpPRComponentMat 
    Public id_purc As String = "-1"
    Public id_rec As String = "-1"
    Public id_pr As String = "-1"
    Public id_pr_det As String = "-1"
    'for edit
    Public id_det As String = "-1"
    Public type As String = "-1"

    Private Sub FormPopUpPRComponent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_mat_pr()
        view_ovh()
        view_dc(LETerm)
        TEPriceOvh.EditValue = 0.0
        TEQtyOvh.EditValue = 0.0
        TEPriceTotOvh.EditValue = 0.0
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
            GVSamplePR.FocusedRowHandle = find_row(GVSamplePR, "id_pr_mat_purc", id_det)
        ElseIf type = "2" Then
            If id_rec <> "-1" Then
                pagex = 3
                GVListReceive.FocusedRowHandle = find_row(GVListReceive, "id_mat_purc_det", id_det)
            Else
                pagex = 2
                GVListPurchase.FocusedRowHandle = find_row(GVListPurchase, "id_mat_purc_det", id_det)
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

    Sub view_list_purchase(ByVal id_mat_purc As String)
        Dim query = "CALL view_pr_mat_from_po('" & id_mat_purc & "')"
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

    Sub view_list_rec(ByVal id_mat_purc_rec As String)
        Dim query = "CALL view_pr_mat_from_rec('" & id_mat_purc_rec & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListReceive.DataSource = data

        If data.Rows.Count > 0 Then
            BSaveRec.Enabled = True
        Else
            BSaveRec.Enabled = False
        End If
    End Sub

    Sub view_mat_pr()
        Dim query As String = "SELECT g.season, g.id_season, g0.id_delivery , g0.delivery ,z.pr_mat_purc_dp,z.pr_mat_purc_total,z.id_pr_mat_purc,z.pr_mat_purc_number,DATE_FORMAT(z.pr_mat_purc_date,'%d %M %Y') as pr_mat_purc_date,g.season,b.mat_purc_number,d.comp_name AS comp_to, "
        query += "DATE_FORMAT(DATE_ADD(b.mat_purc_date,INTERVAL (b.mat_purc_top+b.mat_purc_lead_time) DAY),'%d %M %Y') AS mat_purc_top "
        query += "FROM tb_pr_mat_purc z "
        query += "INNER JOIN tb_mat_purc b ON b.id_mat_purc=z.id_mat_purc "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=z.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
        query += "INNER JOIN tb_season_delivery g0 ON g0.id_delivery = b.id_delivery "
        query += "INNER JOIN tb_season g ON g.id_season=g0.id_season WHERE z.id_mat_purc='" & id_purc & "' "
        query += "ORDER BY g.date_season_start ASC "
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
            load_ovh()
        Else
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
            price = Decimal.Parse(TEPriceOvh.EditValue)
            qty = Decimal.Parse(TEQtyOvh.EditValue)

            tot = price * qty

            TEPriceTotOvh.EditValue = tot
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
                    Dim newRow As DataRow = (TryCast(FormMatPRDet.GCListPurchase.DataSource, DataTable)).NewRow()
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
                        newRow("total") = 0
                    Else
                        newRow("debit") = 0
                        newRow("total") = TEPriceTotOvh.EditValue
                    End If
                    '
                    TryCast(FormMatPRDet.GCListPurchase.DataSource, DataTable).Rows.Add(newRow)
                    FormMatPRDet.GCListPurchase.RefreshDataSource()
                    FormMatPRDet.show_but()

                    FormMatPRDet.calculate()
                    Close()
                End If
            Else
                If check_on_gv(GVOVH.GetFocusedRowCellDisplayText("id_ovh").ToString, "3", "2") Then
                    errorDuplicate(" Item on list.")
                Else
                    FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "id_det", GVOVH.GetFocusedRowCellDisplayText("id_ovh").ToString)
                    FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "name", GVOVH.GetFocusedRowCellDisplayText("overhead").ToString)
                    FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "code", GVOVH.GetFocusedRowCellDisplayText("overhead_code").ToString)
                    FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "qty", TEQtyOvh.EditValue)
                    FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "type", "3")
                    FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "price", TEPriceOvh.EditValue)
                    FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "uom", GVOVH.GetFocusedRowCellDisplayText("uom").ToString)
                    If LETerm.EditValue = "1" Then
                        FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "debit", TEPriceTotOvh.EditValue)
                        FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "total", 0)
                    Else
                        FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "debit", 0)
                        FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "total", TEPriceTotOvh.EditValue)
                    End If
                    FormMatPRDet.calculate()
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
                Dim query As String = String.Format("INSERT INTO tb_pr_mat_purc_det(id_pr_mat_purc,id_pr_det_type,id_ovh,pr_mat_purc_det_price,pr_mat_purc_det_qty,id_dc) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", id_pr, "3", GVOVH.GetFocusedRowCellDisplayText("id_ovh").ToString, decimalSQL(TEPriceOvh.EditValue.ToString), decimalSQL(TEQtyOvh.EditValue.ToString), id_dc)
                execute_non_query(query, True, "", "", "", "")
                FormMatPRDet.view_list_pr()
                FormMatPRDet.show_but()
                FormMatPRDet.calculate()
                Close()
            Else
                Dim query As String = String.Format("UPDATE tb_pr_mat_purc_det SET id_pr_det_type='{0}',id_mat_purc_det=NULL,id_ovh='{1}',id_pr_mat_purc_dp=NULL,pr_mat_purc_det_price='{2}',pr_mat_purc_det_qty='{3}',id_dc='{4}' WHERE id_pr_mat_purc_det='{5}'", "3", GVOVH.GetFocusedRowCellDisplayText("id_ovh").ToString, decimalSQL(TEPriceOvh.EditValue.ToString), decimalSQL(TEQtyOvh.EditValue.ToString), id_dc, id_pr_det)
                execute_non_query(query, True, "", "", "", "")
                FormMatPRDet.view_list_pr()
                FormMatPRDet.show_but()
                FormMatPRDet.calculate()
                Close()
            End If
        End If
    End Sub

    Private Sub BSavePurc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSavePurc.Click
        If id_pr = "-1" Then
            If id_det = "-1" Then
                If check_on_gv(GVListPurchase.GetFocusedRowCellDisplayText("id_mat_purc_det").ToString, "2", "1") Then
                    errorDuplicate(" Item on list.")
                Else
                    Dim newRow As DataRow = (TryCast(FormMatPRDet.GCListPurchase.DataSource, DataTable)).NewRow()
                    newRow("id_det") = GVListPurchase.GetFocusedRowCellDisplayText("id_mat_purc_det").ToString
                    newRow("name") = GVListPurchase.GetFocusedRowCellDisplayText("name").ToString
                    newRow("code") = GVListPurchase.GetFocusedRowCellDisplayText("code").ToString
                    newRow("qty") = GVListPurchase.GetFocusedRowCellDisplayText("qty").ToString
                    newRow("type") = "2"
                    newRow("uom") = GVListPurchase.GetFocusedRowCellDisplayText("uom").ToString
                    newRow("price") = GVListPurchase.GetFocusedRowCellDisplayText("price").ToString
                    newRow("total") = GVListPurchase.GetFocusedRowCellValue("total")

                    TryCast(FormMatPRDet.GCListPurchase.DataSource, DataTable).Rows.Add(newRow)
                    FormMatPRDet.GCListPurchase.RefreshDataSource()
                    FormMatPRDet.show_but()
                    FormMatPRDet.calculate()
                    Close()
                End If
            Else
                If check_on_gv(GVListPurchase.GetFocusedRowCellDisplayText("id_mat_purc_det").ToString, "2", "2") Then
                    errorDuplicate(" Item on list.")
                Else
                    FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "id_det", GVListPurchase.GetFocusedRowCellDisplayText("id_mat_purc_det").ToString)
                    FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "name", GVListPurchase.GetFocusedRowCellDisplayText("name").ToString)
                    FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "code", GVListPurchase.GetFocusedRowCellDisplayText("code").ToString)
                    FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "qty", GVListPurchase.GetFocusedRowCellDisplayText("qty"))
                    FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "type", "2")
                    FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "price", GVListPurchase.GetFocusedRowCellDisplayText("price"))
                    FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "total", GVListPurchase.GetFocusedRowCellValue("total"))
                    FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "uom", GVListPurchase.GetFocusedRowCellDisplayText("uom").ToString)
                    FormMatPRDet.calculate()
                    Close()
                End If

            End If
        Else
            If id_det = "-1" Then
                Dim query_jml As String = String.Format("SELECT COUNT(id_pr_mat_purc_det) FROM tb_pr_mat_purc_det WHERE id_pr_mat_purc='{0}' AND id_mat_purc_det='{1}' AND id_pr_det_type='{2}' AND id_pr_mat_purc_det !='{3}'", id_pr, GVListPurchase.GetFocusedRowCellDisplayText("id_mat_purc_det").ToString, "2", id_pr_det)
                Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
                If Not jml < 1 Then
                    errorDuplicate(" item on list.")
                Else
                    Dim query As String = String.Format("INSERT INTO tb_pr_mat_purc_det(id_pr_mat_purc,id_pr_det_type,id_mat_purc_det,pr_mat_purc_det_price,pr_mat_purc_det_qty,id_dc) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", id_pr, "2", GVListPurchase.GetFocusedRowCellDisplayText("id_mat_purc_det").ToString, decimalSQL(GVListPurchase.GetFocusedRowCellValue("price").ToString), decimalSQL(GVListPurchase.GetFocusedRowCellValue("qty").ToString), "2")
                    execute_non_query(query, True, "", "", "", "")
                    FormMatPRDet.view_list_pr()
                    FormMatPRDet.show_but()
                    FormMatPRDet.calculate()
                    Close()
                End If
            Else
                Dim query_jml As String = String.Format("SELECT COUNT(id_pr_mat_purc_det) FROM tb_pr_mat_purc_det WHERE id_pr_mat_purc='{0}' AND id_mat_purc_det='{1}' AND id_pr_det_type='{2}' AND id_pr_mat_purc_det !='{3}'", id_pr, GVListPurchase.GetFocusedRowCellDisplayText("id_mat_purc_det").ToString, "2", id_pr_det)
                Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
                If Not jml < 1 Then
                    errorDuplicate(" item on list.")
                Else
                    Dim query As String = String.Format("UPDATE tb_pr_mat_purc_det SET id_pr_det_type='{0}',id_mat_purc_det='{1}',id_ovh=NULL,id_pr_mat_purc_dp=NULL,pr_mat_purc_det_price='{2}',pr_mat_purc_det_qty='{3}',id_dc='{4}' WHERE id_pr_mat_purc_det='{5}'", "2", GVListPurchase.GetFocusedRowCellDisplayText("id_mat_purc_det").ToString, decimalSQL(GVListPurchase.GetFocusedRowCellValue("price").ToString), decimalSQL(GVListPurchase.GetFocusedRowCellValue("qty").ToString), "2", id_pr_det)
                    execute_non_query(query, True, "", "", "", "")
                    FormMatPRDet.view_list_pr()
                    FormMatPRDet.show_but()
                    FormMatPRDet.calculate()
                    Close()
                End If
            End If
        End If
    End Sub

    Private Sub BSaveRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSaveRec.Click
        If id_pr = "-1" Then
            If id_det = "-1" Then
                If check_on_gv(GVListReceive.GetFocusedRowCellDisplayText("id_mat_purc_det").ToString, "2", "1") Then
                    errorDuplicate(" Item on list.")
                Else
                    Dim newRow As DataRow = (TryCast(FormMatPRDet.GCListPurchase.DataSource, DataTable)).NewRow()
                    newRow("id_det") = GVListReceive.GetFocusedRowCellDisplayText("id_mat_purc_det").ToString
                    newRow("name") = GVListReceive.GetFocusedRowCellDisplayText("name").ToString
                    newRow("code") = GVListReceive.GetFocusedRowCellDisplayText("code").ToString
                    newRow("qty") = GVListReceive.GetFocusedRowCellValue("qty")
                    newRow("type") = "2"
                    newRow("uom") = GVListReceive.GetFocusedRowCellDisplayText("uom").ToString
                    newRow("price") = GVListReceive.GetFocusedRowCellValue("price")
                    newRow("total") = GVListReceive.GetFocusedRowCellValue("total")

                    TryCast(FormMatPRDet.GCListPurchase.DataSource, DataTable).Rows.Add(newRow)
                    FormMatPRDet.GCListPurchase.RefreshDataSource()
                    FormMatPRDet.show_but()
                    FormMatPRDet.calculate()
                    Close()
                End If
            Else
                If check_on_gv(GVListReceive.GetFocusedRowCellDisplayText("id_mat_purc_det").ToString, "2", "2") Then
                    errorDuplicate(" Item on list.")
                Else
                    FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "id_det", GVListReceive.GetFocusedRowCellDisplayText("id_mat_purc_det").ToString)
                    FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "name", GVListReceive.GetFocusedRowCellDisplayText("name").ToString)
                    FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "code", GVListReceive.GetFocusedRowCellDisplayText("code").ToString)
                    FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "qty", GVListReceive.GetFocusedRowCellValue("qty"))
                    FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "type", "2")
                    FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "price", GVListReceive.GetFocusedRowCellValue("price"))
                    FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "total", GVListReceive.GetFocusedRowCellValue("total"))
                    FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "uom", GVListReceive.GetFocusedRowCellDisplayText("uom").ToString)

                    FormMatPRDet.calculate()
                    Close()
                End If
            End If
        Else
            If id_det = "-1" Then
                Dim query_jml As String = String.Format("SELECT COUNT(id_pr_mat_purc_det) FROM tb_pr_mat_purc_det WHERE id_pr_mat_purc='{0}' AND id_mat_purc_det='{1}' AND id_pr_det_type='{2}' AND id_pr_mat_purc_det !='{3}'", id_pr, GVListReceive.GetFocusedRowCellDisplayText("id_mat_purc_det").ToString, "2", id_pr_det)
                Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
                If Not jml < 1 Then
                    errorDuplicate(" item on list.")
                Else
                    Dim query As String = String.Format("INSERT INTO tb_pr_mat_purc_det(id_pr_mat_purc,id_pr_det_type,id_mat_purc_det,pr_mat_purc_det_price,pr_mat_purc_det_qty,id_dc) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", id_pr, "2", GVListReceive.GetFocusedRowCellDisplayText("id_mat_purc_det").ToString, decimalSQL(GVListReceive.GetFocusedRowCellValue("price").ToString), decimalSQL(GVListReceive.GetFocusedRowCellValue("qty").ToString), "2")
                    execute_non_query(query, True, "", "", "", "")
                    FormMatPRDet.view_list_pr()
                    FormMatPRDet.show_but()
                    FormMatPRDet.calculate()
                    Close()
                End If
            Else
                Dim query_jml As String = String.Format("SELECT COUNT(id_pr_mat_purc_det) FROM tb_pr_mat_purc_det WHERE id_pr_mat_purc='{0}' AND id_mat_purc_det='{1}' AND id_pr_det_type='{2}' AND id_pr_mat_purc_det !='{3}'", id_pr, GVListReceive.GetFocusedRowCellDisplayText("id_mat_purc_det").ToString, "2", id_pr_det)
                Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
                If Not jml < 1 Then
                    errorDuplicate(" item on list.")
                Else
                    Dim query As String = String.Format("UPDATE tb_pr_mat_purc_det SET id_pr_det_type='{0}',id_mat_purc_det='{1}',id_ovh=NULL,id_pr_mat_purc_dp=NULL,pr_mat_purc_det_price='{2}',pr_mat_purc_det_qty='{3}',id_dc='{4}' WHERE id_pr_mat_purc_det='{5}'", "2", GVListReceive.GetFocusedRowCellDisplayText("id_mat_purc_det").ToString, decimalSQL(GVListReceive.GetFocusedRowCellValue("price").ToString), decimalSQL(GVListReceive.GetFocusedRowCellValue("qty").ToString), "2", id_pr_det)
                    execute_non_query(query, True, "", "", "", "")
                    FormMatPRDet.view_list_pr()
                    FormMatPRDet.show_but()
                    FormMatPRDet.calculate()
                    Close()
                End If
            End If
        End If
    End Sub

    Private Sub BSavePR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSavePR.Click
        If id_pr = "-1" Then
            If id_det = "-1" Then
                If check_on_gv(GVSamplePR.GetFocusedRowCellDisplayText("id_pr_mat_purc").ToString, "1", "1") Then
                    errorDuplicate(" Item on list.")
                Else
                    Dim newRow As DataRow = (TryCast(FormMatPRDet.GCListPurchase.DataSource, DataTable)).NewRow()
                    newRow("id_det") = GVSamplePR.GetFocusedRowCellDisplayText("id_pr_mat_purc").ToString
                    newRow("name") = "Payment Request"
                    newRow("code") = GVSamplePR.GetFocusedRowCellDisplayText("pr_mat_purc_number").ToString
                    newRow("qty") = 1.0
                    newRow("type") = "1"
                    newRow("price") = GVSamplePR.GetFocusedRowCellValue("pr_mat_purc_dp")
                    newRow("debit") = GVSamplePR.GetFocusedRowCellValue("pr_mat_purc_dp")

                    TryCast(FormMatPRDet.GCListPurchase.DataSource, DataTable).Rows.Add(newRow)
                    FormMatPRDet.GCListPurchase.RefreshDataSource()
                    FormMatPRDet.show_but()
                    FormMatPRDet.calculate()
                    Close()
                End If
            Else
                If check_on_gv(GVSamplePR.GetFocusedRowCellDisplayText("id_pr_mat_purc").ToString, "1", "2") Then
                    errorDuplicate(" Item on list.")
                Else
                    FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "id_det", GVSamplePR.GetFocusedRowCellDisplayText("id_pr_mat_purc").ToString)
                    FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "name", "Payment Request")
                    FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "code", GVSamplePR.GetFocusedRowCellDisplayText("pr_mat_purc_number").ToString)
                    FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "qty", 1.0)
                    FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "type", "1")
                    FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "price", GVSamplePR.GetFocusedRowCellValue("pr_mat_purc_dp"))
                    FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "total", Nothing)
                    FormMatPRDet.GVListPurchase.SetRowCellValue(FormMatPRDet.GVListPurchase.FocusedRowHandle, "debit", GVSamplePR.GetFocusedRowCellValue("pr_mat_purc_dp"))
                    FormMatPRDet.calculate()
                    Close()
                End If
            End If
        Else
            If id_det = "-1" Then
                Dim query_jml As String = String.Format("SELECT COUNT(id_pr_mat_purc_det) FROM tb_pr_mat_purc_det WHERE id_pr_mat_purc='{0}' AND id_pr_mat_purc_dp='{1}' AND id_pr_det_type='{2}' AND id_pr_mat_purc_det !='{3}'", id_pr, GVSamplePR.GetFocusedRowCellDisplayText("id_pr_mat_purc").ToString, "1", id_pr_det)
                Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
                If Not jml < 1 Then
                    errorDuplicate(" item on list.")
                Else
                    Dim query As String = String.Format("INSERT INTO tb_pr_mat_purc_det(id_pr_mat_purc,id_pr_det_type,id_pr_mat_purc_dp,pr_mat_purc_det_price,pr_mat_purc_det_qty,id_dc) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", id_pr, "1", GVSamplePR.GetFocusedRowCellDisplayText("id_pr_mat_purc").ToString, decimalSQL(GVSamplePR.GetFocusedRowCellValue("pr_mat_purc_dp").ToString), "1", "1")
                    execute_non_query(query, True, "", "", "", "")
                    FormMatPRDet.view_list_pr()
                    FormMatPRDet.show_but()
                    FormMatPRDet.calculate()
                    Close()
                End If
            Else
                Dim query_jml As String = String.Format("SELECT COUNT(id_pr_mat_purc_det) FROM tb_pr_mat_purc_det WHERE id_pr_mat_purc='{0}' AND id_pr_mat_purc_dp='{1}' AND id_pr_det_type='{2}' AND id_pr_mat_purc_det !='{3}'", id_pr, GVSamplePR.GetFocusedRowCellDisplayText("id_pr_mat_purc").ToString, "1", id_pr_det)
                Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
                If Not jml < 1 Then
                    errorDuplicate(" item on list.")
                Else
                    Dim query As String = String.Format("UPDATE tb_pr_mat_purc_det SET id_pr_det_type='{0}',id_mat_purc_det=NULL,id_ovh=NULL,id_pr_mat_purc_dp='{1}',pr_mat_purc_det_price='{2}',pr_mat_purc_det_qty='{3}',id_dc='{4}' WHERE id_pr_mat_purc_det='{5}'", "1", GVSamplePR.GetFocusedRowCellDisplayText("id_pr_mat_purc").ToString, decimalSQL(GVSamplePR.GetFocusedRowCellValue("pr_mat_purc_dp").ToString), "1", "1", id_pr_det)
                    execute_non_query(query, True, "", "", "", "")
                    FormMatPRDet.view_list_pr()
                    FormMatPRDet.show_but()
                    FormMatPRDet.calculate()
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
        For i As Integer = 0 To FormMatPRDet.GVListPurchase.RowCount - 1
            If opt = "1" Then
                If type = FormMatPRDet.GVListPurchase.GetRowCellValue(i, "type").ToString() And id_det = FormMatPRDet.GVListPurchase.GetRowCellValue(i, "id_det").ToString() Then
                    temp_check = True
                    Exit For
                End If
            Else
                If type = FormMatPRDet.GVListPurchase.GetRowCellValue(i, "type").ToString() And id_det = FormMatPRDet.GVListPurchase.GetRowCellValue(i, "id_det").ToString() And Not i = FormMatPRDet.GVListPurchase.FocusedRowHandle Then
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

    Private Sub GVSamplePR_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSamplePR.CustomColumnDisplayText
        If e.Column.FieldName = "id_delivery" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVSamplePR.IsGroupRow(rowhandle) Then
                rowhandle = GVSamplePR.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVSamplePR.GetRowCellDisplayText(rowhandle, "delivery")
            End If
        End If
        If e.Column.FieldName = "id_season" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVSamplePR.IsGroupRow(rowhandle) Then
                rowhandle = GVSamplePR.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVSamplePR.GetRowCellDisplayText(rowhandle, "season")
            End If
        End If
    End Sub

    Private Sub GVSamplePR_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSamplePR.FocusedRowChanged
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If
    End Sub
End Class