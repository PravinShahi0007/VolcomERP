Public Class FormRiderContractDet
    Public id_pps As String = "-1"
    Public is_view As String = "-1"

    Private Sub FormRiderContractDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_head()
    End Sub

    Sub load_head()
        load_type()
        load_rider()

        If id_pps = "-1" Then
            'new
        Else
            'edit
            BtnSave.Visible = False
            PCAddDel.Visible = False
            '
            BtnPrint.Visible = True
            BtnMark.Visible = True
            '
            Dim q As String = "SELECT * FROM tb_kontrak_rider_pps pps
INNER JOIN tb_lookup_report_status sts ON sts.`id_report_status`=pps.`id_report_status`
INNER JOIN tb_m_user usr ON usr.`id_user`=pps.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
WHERE pps.`id_kontrak_rider_pps`=" & id_pps
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                TxtNumber.Text = dt.Rows(0)("number").ToString
                DECreated.EditValue = dt.Rows(0)("created_date")
                TEProposedBy.Text = dt.Rows(0)("employee_name").ToString
                MENote.Text = dt.Rows(0)("note").ToString
            End If
        End If

        load_det()
    End Sub

    Sub load_det()
        Dim q As String = "SELECT ppsd.*
FROM `tb_kontrak_rider_pps_det` ppsd
WHERE ppsd.id_kontrak_rider_pps='" & id_pps & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCPPS.DataSource = dt
        GVPPS.BestFitColumns()
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
            If GVPPS.GetRowCellValue(i, "id_kontrak_type") Is Nothing Or GVPPS.GetRowCellValue(i, "id_comp") Is Nothing Or GVPPS.GetRowCellValue(i, "qty_month") <= 0 Or GVPPS.GetRowCellValue(i, "monthly_pay") <= 0 Then
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
                    q = "INSERT INTO tb_kontrak_rider_pps_det(`id_kontrak_rider_pps`,`id_comp`,`id_kontrak_type`,`kontrak_from`,`kontrak_until`,`monthly_pay`,`id_kontrak_old`,`kontrak_from_old`,`kontrak_until_old`,`monthly_pay_old`) VALUES"
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
                        q += "('" & id_pps & "','" & GVPPS.GetRowCellValue(i, "id_comp").ToString & "','" & GVPPS.GetRowCellValue(i, "id_kontrak_type").ToString & "','" & Date.Parse(GVPPS.GetRowCellValue(i, "kontrak_from").ToString).ToString("yyyy-MM-dd") & "','" & Date.Parse(GVPPS.GetRowCellValue(i, "kontrak_until").ToString).ToString("yyyy-MM-dd") & "','" & decimalSQL(Decimal.Parse(GVPPS.GetRowCellValue(i, "monthly_pay").ToString).ToString) & "'," & id_kontrak_old & "," & kontrak_from_old & "," & kontrak_until_old & "," & monthly_pay_old & ")"
                    Next
                    execute_non_query(q, True, "", "", "", "")
                    '
                    submit_who_prepared("398", id_pps, id_user)
                    '
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
        'If e.Column.FieldName = "qty_month" Then
        '    Try
        '        Dim total_month As String = ""
        '        Dim q As String = "SELECT TIMESTAMPDIFF(MONTH, '" & Date.Parse(GVPPS.GetRowCellValue(e.ListSourceRowIndex, "kontrak_from").ToString).ToString("yyyy-MM-dd") & "', '" & Date.Parse(GVPPS.GetRowCellValue(e.ListSourceRowIndex, "kontrak_until").ToString).ToString("yyyy-MM-dd") & "') as diff"
        '        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        '        If dt.Rows.Count > 0 Then
        '            e.Value = dt.Rows(0)("diff")
        '        End If
        '    Catch ex As Exception

        '    End Try
        'ElseIf e.Column.FieldName = "qty_month_old" Then
        '    Try
        '        Dim total_month As String = ""
        '        Dim q As String = "SELECT TIMESTAMPDIFF(MONTH, '" & Date.Parse(GVPPS.GetRowCellValue(e.ListSourceRowIndex, "kontrak_from_old").ToString).ToString("yyyy-MM-dd") & "', '" & Date.Parse(GVPPS.GetRowCellValue(e.ListSourceRowIndex, "kontrak_until_old").ToString).ToString("yyyy-MM-dd") & "') as diff"
        '        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        '        If dt.Rows.Count > 0 Then
        '            e.Value = dt.Rows(0)("diff")
        '        End If
        '    Catch ex As Exception

        '    End Try
        'End If
    End Sub

    Private Sub GVPPS_HiddenEditor(sender As Object, e As EventArgs) Handles GVPPS.HiddenEditor

        '
        GVPPS.BestFitColumns()
    End Sub

    Private Sub GVPPS_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVPPS.CellValueChanged
        If e.Column.FieldName = "kontrak_from" Or e.Column.FieldName = "kontrak_until" Then
            Try
                Dim total_month As String = ""
                Dim q As String = "SELECT TIMESTAMPDIFF(MONTH, '" & Date.Parse(GVPPS.GetRowCellValue(e.RowHandle, "kontrak_from").ToString).ToString("yyyy-MM-dd") & "', '" & Date.Parse(GVPPS.GetRowCellValue(e.RowHandle, "kontrak_until").ToString).ToString("yyyy-MM-dd") & "') as diff"
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                If dt.Rows.Count > 0 Then
                    GVPPS.SetFocusedRowCellValue("qty_month", dt.Rows(0)("diff"))
                End If
            Catch ex As Exception

            End Try
        ElseIf e.Column.FieldName = "kontrak_from_old" Or e.Column.FieldName = "kontrak_until_old" Then
            Try
                Dim total_month As String = ""
                Dim q As String = "SELECT TIMESTAMPDIFF(MONTH, '" & Date.Parse(GVPPS.GetRowCellValue(e.RowHandle, "kontrak_from_old").ToString).ToString("yyyy-MM-dd") & "', '" & Date.Parse(GVPPS.GetRowCellValue(e.RowHandle, "kontrak_until_old").ToString).ToString("yyyy-MM-dd") & "') as diff"
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                If dt.Rows.Count > 0 Then
                    GVPPS.SetFocusedRowCellValue("qty_month_old", dt.Rows(0)("diff"))
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class