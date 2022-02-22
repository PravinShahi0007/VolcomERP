Public Class FormRiderContractDet
    Public id_pps As String = "-1"
    Public is_view As String = "-1"
    Public id_type As String = "1"
    Private Sub FormRiderContractDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_head()
    End Sub

    Sub load_head()
        load_type()
        load_rider()

        If id_pps = "-1" Then
            'new
            load_det()
            If FormRiderContract.GVContractList.RowCount > 0 Then
                For i = 0 To FormRiderContract.GVContractList.RowCount - 1
                    GVPPS.AddNewRow()
                    GVPPS.FocusedRowHandle = GVPPS.RowCount - 1
                    '
                    GVPPS.SetRowCellValue(GVPPS.RowCount - 1, "id_kontrak_type", FormRiderContract.GVContractList.GetRowCellValue(i, "id_kontrak_type"))
                    GVPPS.SetRowCellValue(GVPPS.RowCount - 1, "id_comp", FormRiderContract.GVContractList.GetRowCellValue(i, "id_comp"))
                    '
                    GVPPS.SetRowCellValue(GVPPS.RowCount - 1, "id_kontrak_old", FormRiderContract.GVContractList.GetRowCellValue(i, "id_kontrak_rider").ToString)
                    GVPPS.SetRowCellValue(GVPPS.RowCount - 1, "monthly_pay_old", FormRiderContract.GVContractList.GetRowCellValue(i, "monthly_pay"))
                    GVPPS.SetRowCellValue(GVPPS.RowCount - 1, "kontrak_until_old", FormRiderContract.GVContractList.GetRowCellValue(i, "kontrak_until"))
                    GVPPS.SetRowCellValue(GVPPS.RowCount - 1, "kontrak_from_old", FormRiderContract.GVContractList.GetRowCellValue(i, "kontrak_from"))
                    GVPPS.SetRowCellValue(GVPPS.RowCount - 1, "qty_month_old", FormRiderContract.GVContractList.GetRowCellValue(i, "qty_month"))
                    GVPPS.SetRowCellValue(GVPPS.RowCount - 1, "monthly_pay_tot_old", FormRiderContract.GVContractList.GetRowCellValue(i, "total"))
                    '
                    GVPPS.SetRowCellValue(GVPPS.RowCount - 1, "monthly_pay", "0")
                    If id_type = "1" Then
                        GVPPS.SetRowCellValue(GVPPS.RowCount - 1, "kontrak_from", FormRiderContract.GVContractList.GetRowCellValue(i, "kontrak_until"))
                        GVPPS.SetRowCellValue(GVPPS.RowCount - 1, "kontrak_until", FormRiderContract.GVContractList.GetRowCellValue(i, "kontrak_until"))
                    Else
                        GVPPS.SetRowCellValue(GVPPS.RowCount - 1, "kontrak_until", FormRiderContract.GVContractList.GetRowCellValue(i, "kontrak_until"))
                        GVPPS.SetRowCellValue(GVPPS.RowCount - 1, "kontrak_from", FormRiderContract.GVContractList.GetRowCellValue(i, "kontrak_from"))
                        PCAddDel.Visible = False
                    End If

                    GVPPS.RefreshData()
                Next
            End If
            If id_type = "1" Then
                TEType.Text = "New / Extend"
            Else
                TEType.Text = "Changes"
                PCAddDel.Visible = False
            End If
        Else
            'edit
            BtnSave.Visible = False
            PCAddDel.Visible = False
            '
            BtnPrint.Visible = True
            BtnMark.Visible = True
            '
            Dim q As String = "SELECT pps.number,pps.created_date,pps.note,emp.employee_name,pps.id_type,IF(pps.id_type=1,'New / Extend','Changes') AS typ FROM tb_kontrak_rider_pps pps
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
                TEType.Text = dt.Rows(0)("typ").ToString
                id_type = dt.Rows(0)("id_type").ToString
            End If
            If is_view = "1" Then
                BtnPrint.Visible = False
            End If
            load_det()
        End If
    End Sub

    Sub load_det()
        Dim q As String = "SELECT ppsd.*,TIMESTAMPDIFF(MONTH,ppsd.kontrak_from,ppsd.kontrak_until) AS qty_month,TIMESTAMPDIFF(MONTH,ppsd.kontrak_from_old,ppsd.kontrak_until_old) as qty_month_old
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
        Dim q As String = ""
        If id_pps = "-1" Then
            q = "SELECT c.id_comp,CONCAT(c.`comp_number`,' - ',c.comp_name) AS comp_name
FROM tb_m_comp c "
            'q += " WHERE c.`is_active`=1 AND c.`id_comp_cat`=2"
        Else
            q = "SELECT c.id_comp,CONCAT(c.`comp_number`,' - ',c.comp_name) AS comp_name
FROM tb_m_comp c "
        End If

        viewSearchLookupRepositoryQuery(RepositoryItemSearchLookUpEdit1, q, 0, "comp_name", "id_comp")
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim is_ok As Boolean = True
        'check
        For i = 0 To GVPPS.RowCount - 1
            If GVPPS.GetRowCellValue(i, "id_kontrak_type") Is Nothing Or GVPPS.GetRowCellValue(i, "id_comp") Is Nothing Or GVPPS.GetRowCellValue(i, "qty_month") <= 0 Or GVPPS.GetRowCellValue(i, "monthly_pay") <= 0 Or (GVPPS.GetRowCellValue(i, "kontrak_from") <= GVPPS.GetRowCellValue(i, "kontrak_until")) Then
                warningCustom("Please complete your input")
                is_ok = False
                Exit For
            End If
        Next

        If id_type = "1" Then
            'new tidak boleh sebelum until
            For i = 0 To GVPPS.RowCount - 1
                If GVPPS.GetRowCellValue(i, "id_kontrak_old").ToString = "" Or GVPPS.GetRowCellValue(i, "id_kontrak_old").ToString = "0" Then
                    If GVPPS.GetRowCellValue(i, "kontrak_until_old") > GVPPS.GetRowCellValue(i, "kontrak_from") Then
                        warningCustom("Please make sure new period is not below old period")
                        is_ok = False
                        Exit For
                    End If
                End If
            Next
        ElseIf id_type = "2" Then
            'changes tidak boleh sesudah until
            For i = 0 To GVPPS.RowCount - 1
                If GVPPS.GetRowCellValue(i, "kontrak_until") > GVPPS.GetRowCellValue(i, "kontrak_until_old") Or GVPPS.GetRowCellValue(i, "kontrak_from") < GVPPS.GetRowCellValue(i, "kontrak_from_old") Then
                    warningCustom("Please make sure changes is between old period")
                    is_ok = False
                    Exit For
                End If
            Next
        End If

        If Not is_ok Then

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

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Dim qc As String = "SELECT 
h.`number`,emp.employee_name AS created_by,DATE_FORMAT(h.created_date,'%d %M %Y') AS created_date,h.note,IF(h.id_type=1,'New / Extend','Changes') AS report_type
FROM `tb_kontrak_rider_pps` h 
INNER JOIN tb_m_user usr ON usr.id_user=h.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
WHERE h.`id_kontrak_rider_pps`='" & id_pps & "'"
        Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
        If dtc.Rows.Count > 0 Then
            'print
            Cursor = Cursors.WaitCursor

            Dim Report As New ReportRiderContract()
            Report.id_pps = id_pps
            Report.DataSource = dtc

            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreview()

            Cursor = Cursors.Default
        Else
            warningCustom("No data found")
        End If
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "398"
        FormReportMark.id_report = id_pps
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "398"
        FormDocumentUpload.is_view = is_view
        FormDocumentUpload.id_report = id_pps
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class