Public Class FormRiderContractDet
    Public id_pps As String = "-1"

    Private Sub FormRiderContractDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_type()
        load_rider()
        load_det()
    End Sub

    Sub load_det()
        Dim q As String = "SELECT ppsd.*
FROM `tb_kontrak_rider_pps_det` ppsd
WHERE ppsd.id_kontrak_rider_pps='" & id_pps & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCPPS.DataSource = dt
    End Sub

    Sub load_type()
        Dim q As String = "SELECT id_kontrak_type,kontrak_type FROM `tb_kontrak_type`"
        viewSearchLookupRepositoryQuery(RISLECat, q, 0, "kontrak_type", "id_kontrak_type")
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        GVPPS.AddNewRow()
        GVPPS.FocusedRowHandle = GVPPS.RowCount - 1
        '
        GVPPS.SetRowCellValue(GVPPS.RowCount - 1, "id_kontrak_old", "0")
        GVPPS.SetRowCellValue(GVPPS.RowCount - 1, "monthly_pay_old", "0")
        GVPPS.SetRowCellValue(GVPPS.RowCount - 1, "kontrak_until_old", Date.Parse(Now().ToString))
        GVPPS.SetRowCellValue(GVPPS.RowCount - 1, "kontrak_from_old", Date.Parse(Now().ToString))
        GVPPS.SetRowCellValue(GVPPS.RowCount - 1, "qty_month_old", "0")
        GVPPS.SetRowCellValue(GVPPS.RowCount - 1, "monthly_pay_tot_old", "0")
        '
        GVPPS.SetRowCellValue(GVPPS.RowCount - 1, "monthly_pay", "0")
        GVPPS.SetRowCellValue(GVPPS.RowCount - 1, "kontrak_until", Date.Parse(Now().ToString))
        GVPPS.SetRowCellValue(GVPPS.RowCount - 1, "kontrak_from", Date.Parse(Now().ToString))
        GVPPS.RefreshData()
        '
        GVPPS.BestFitColumns()
    End Sub

    Sub load_rider()
        Dim q As String = "SELECT c.id_comp,CONCAT(c.`comp_number`,' - ',c.comp_name) AS comp_name
FROM tb_m_comp c 
WHERE c.`is_active`=1 AND c.`id_comp_cat`=2"
        viewSearchLookupRepositoryQuery(RepositoryItemSearchLookUpEdit1, q, 0, "comp_name", "id_comp")
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim is_ok As Boolean = True
        'check
        For i = 0 To GVPPS.RowCount - 1
            If GVPPS.GetRowCellValue(i, "category") Is Nothing Or GVPPS.GetRowCellValue(i, "id_comp") Is Nothing Or GVPPS.GetRowCellValue(i, "qty_month") <= 0 Or GVPPS.GetRowCellValue(i, "monthly_pay") <= 0 Then
                is_ok = False
                Exit For
            End If
        Next

        If Not is_ok Then
            warningCustom("Please check your input")
        Else
            If GVPPS.RowCount > 0 Then
                If id_pps = "-1" Then 'new
                    Dim q As String = "INSERT INTO `tb_kontrak_rider_pps`(created_by,created_date,note) VALUES('" & id_user & "',NOW(),'" & addSlashes(MENote.Text) & "'); SELECT LAST_INSERT_ID(); "
                    id_pps = execute_query(q, 0, True, "", "", "", "")
                    '
                    execute_non_query("CALL gen_number('" & id_pps & "','398')", True, "", "", "", "")
                    'detail
                    q = "INSERT INTO tb_kontrak_rider_pps_det(`id_kontrak_rider_pps`,`id_comp`,`id_type`,`kontrak_from`,`kontrak_until`,`monthly_pay`,`id_kontrak_old`,`kontrak_from_old`,`kontrak_until_old`,`monthly_pay_old`) VALUES"
                    For i = 0 To GVPPS.RowCount - 1
                        Dim id_kontrak_old As String = "0"
                        Dim kontrak_from_old As String = "NULL"
                        Dim kontrak_until_old As String = "NULL"
                        Dim monthly_pay_old As String = "'0'"

                        If GVPPS.GetRowCellValue(i, "id_kontrak_old").ToString = "0" Or GVPPS.GetRowCellValue(i, "id_kontrak_old").ToString = "" Then
                        Else
                            id_kontrak_old = GVPPS.GetRowCellValue(i, "id_kontrak_old").ToString
                            kontrak_from_old = "'" & Date.Parse(GVPPS.GetRowCellValue(i, "kontrak_from_old").ToString).ToString("yyyy-MM-dd") & "'"
                            kontrak_until_old = "'" & Date.Parse(GVPPS.GetRowCellValue(i, "kontrak_until_old").ToString).ToString("yyyy-MM-dd") & "'"
                            monthly_pay_old = "'" & decimalSQL(Decimal.Parse(GVPPS.GetRowCellValue(i, "monthly_pay_old").ToString).ToString) & "'"
                        End If

                        If Not i = 0 Then
                            q += ","
                        End If
                        q += "('" & id_pps & "','" & GVPPS.GetRowCellValue(i, "id_comp").ToString & "','" & GVPPS.GetRowCellValue(i, "id_type").ToString & "','" & Date.Parse(GVPPS.GetRowCellValue(i, "kontrak_from").ToString).ToString("yyyy-MM-dd") & "','" & Date.Parse(GVPPS.GetRowCellValue(i, "kontrak_until").ToString).ToString("yyyy-MM-dd") & "','" & decimalSQL(Decimal.Parse(GVPPS.GetRowCellValue(i, "monthly_pay").ToString).ToString) & "'," & id_kontrak_old & "," & kontrak_from_old & "," & kontrak_until_old & "," & monthly_pay_old & ")"
                    Next
                    execute_non_query(q, True, "", "", "", "")
                    Close()
                Else 'edit

                End If
            End If
        End If
    End Sub

    Private Sub FormRiderContractDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVPPS_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GVPPS.CustomUnboundColumnData
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Column.FieldName = "qty_month" AndAlso e.IsGetData Then
            Try
                Dim total_month As String = ""
                Dim q As String = "SELECT TIMESTAMPDIFF(MONTH, '" & Date.Parse(GVPPS.GetRowCellValue(e.ListSourceRowIndex, "kontrak_from").ToString).ToString("yyyy-MM-dd") & "', '" & Date.Parse(GVPPS.GetRowCellValue(e.ListSourceRowIndex, "kontrak_until").ToString).ToString("yyyy-MM-dd") & "') as diff"
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                If dt.Rows.Count > 0 Then
                    e.Value = dt.Rows(0)("diff")
                End If
            Catch ex As Exception

            End Try
        ElseIf e.Column.FieldName = "qty_month_old" AndAlso e.IsGetData Then
            Try
                Dim total_month As String = ""
                Dim q As String = "SELECT TIMESTAMPDIFF(MONTH, '" & Date.Parse(GVPPS.GetRowCellValue(e.ListSourceRowIndex, "kontrak_from_old").ToString).ToString("yyyy-MM-dd") & "', '" & Date.Parse(GVPPS.GetRowCellValue(e.ListSourceRowIndex, "kontrak_until_old").ToString).ToString("yyyy-MM-dd") & "') as diff"
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                If dt.Rows.Count > 0 Then
                    e.Value = dt.Rows(0)("diff")
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class