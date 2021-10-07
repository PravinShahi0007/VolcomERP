Public Class FormPolisReg
    Public id_polis_pps As String = "-1"
    Public id_reg As String = "-1"
    Public is_view As String = "-1"
    Private Sub FormPolisReg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_pps_type()
        load_polis_type()

        load_pps_view()
    End Sub

    Sub load_kolektif()
        Dim q As String = ""
        q = "SELECT c.id_comp,c.comp_number,c.comp_name 
FROM tb_polis_pps_kolektif ppsv
INNER JOIN tb_m_comp c ON c.id_comp=ppsv.id_vendor
WHERE ppsv.id_polis_pps='" & id_polis_pps & "'
GROUP BY ppsv.id_vendor"
        viewSearchLookupQuery(SLEPenawaran, q, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub load_pps_view()
        If id_reg = "-1" Then
            FormPolisRegPick.ShowDialog()
            If id_polis_pps = "-1" Then
                Close()
            Else
                '                Dim q As String = "SELECT ppsd.old_end_date,pps.id_polis_pps,ppsd.`id_polis_pps_det`,ppsd.`nilai_stock`,ppsd.`nilai_building`,ppsd.`nilai_fit_out`,ppsd.`nilai_peralatan`,ppsd.`nilai_public_liability`,ppsd.`nilai_total`
                ',ppsd.`id_comp`,c.`comp_name`,c.`comp_number`,c.address_primary,ppsd.`premi`,ppsd.`polis_vendor`,v.`comp_name` AS vendor
                'FROM `tb_polis_pps_det` ppsd
                'LEFT JOIN tb_polis pol ON pol.`id_polis`=ppsd.`old_id_polis`
                'INNER JOIN tb_polis_pps pps ON pps.`id_polis_pps`=ppsd.`id_polis_pps` AND ppsd.`id_polis_pps`='" & id_polis_pps & "' AND pps.id_report_status=6
                'INNER JOIN tb_m_comp c ON c.`id_comp`=ppsd.`id_comp`
                'INNER JOIN tb_m_comp v ON v.`id_comp`=ppsd.`polis_vendor`"
                '                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                '                GCSummary.DataSource = dt
                '                BGVSummary.BestFitColumns()
            End If
        Else
            'head
            Dim qh As String = "SELECT reg.*,emp.`employee_name`,pps.id_pps_type,pps.id_desc_premi FROM `tb_polis_reg` reg
INNER JOIN tb_m_user usr ON usr.`id_user`=reg.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_polis_pps pps ON pps.id_polis_pps=reg.id_polis_pps
WHERE reg.id_polis_reg='" & id_reg & "'"
            Dim dth As DataTable = execute_query(qh, -1, True, "", "", "", "")
            If dth.Rows.Count > 0 Then
                TENumber.Text = dth.Rows(0)("number").ToString
                DECreatedDate.EditValue = dth.Rows(0)("created_date")
                TECreatedBy.Text = dth.Rows(0)("employee_name").ToString
                '
                SLEPolisType.EditValue = dth.Rows(0)("id_desc_premi").ToString
                SLEPPSType.EditValue = dth.Rows(0)("id_pps_type").ToString
                '
                If dth.Rows(0)("is_submit").ToString = "1" Then
                    BtnSave.Visible = False
                    BtnMark.Visible = True
                Else
                    BtnSave.Visible = True
                    BtnMark.Visible = True
                End If
                '
                If dth.Rows(0)("id_report_status").ToString = "5" Or dth.Rows(0)("id_report_status").ToString = "6" Then
                    is_view = "1"
                End If
                '
                If SLEPPSType.EditValue.ToString = "1" Then 'kolektif then
                    PCKolektif.Visible = True
                    load_kolektif()

                    Dim qs As String = "SELECT v.price,v.id_vendor
FROM `tb_polis_reg_det` rd
INNER JOIN tb_polis_reg r ON r.id_polis_reg=rd.id_polis_reg AND r.`id_polis_reg`='" & id_reg & "'
INNER JOIN tb_polis_pps_kolektif v ON rd.vendor_dipilih=v.id_vendor AND r.id_polis_pps=v.id_polis_pps
LIMIT 1"
                    Dim dts As DataTable = execute_query(qs, -1, True, "", "", "", "")
                    If dts.Rows.Count > 0 Then
                        SLEPenawaran.EditValue = dts.Rows(0)("id_vendor").ToString
                        TEPremi.EditValue = dts.Rows(0)("price").ToString
                    End If
                Else
                    PCKolektif.Visible = False
                End If
                '
                If dth.Rows(0)("id_report_status").ToString = "6" Then
                    BtnSave.Visible = False
                End If

                id_polis_pps = dth.Rows(0)("id_polis_pps")
            End If
            '
            '            Dim q As String = "SELECT ppsd.old_end_date,pps.id_polis_pps,ppsd.`id_polis_pps_det`,ppsd.`nilai_stock`,ppsd.`nilai_building`,ppsd.`nilai_fit_out`,ppsd.`nilai_peralatan`,ppsd.`nilai_public_liability`,ppsd.`nilai_total`
            ',ppsd.`id_comp`,c.`comp_name`,c.`comp_number`,c.address_primary,ppsd.`premi`,ppsd.`polis_vendor`,v.`comp_name` AS vendor
            ',regd.premi AS premi_det,regd.polis_number,regd.description
            'FROM `tb_polis_pps_det` ppsd
            'LEFT JOIN tb_polis pol ON pol.`id_polis`=ppsd.`old_id_polis`
            'INNER JOIN tb_polis_pps pps ON pps.`id_polis_pps`=ppsd.`id_polis_pps` AND ppsd.`id_polis_pps`='" & id_polis_pps & "' AND pps.id_report_status=6
            'INNER JOIN tb_m_comp c ON c.`id_comp`=ppsd.`id_comp`
            'INNER JOIN tb_m_comp v ON v.`id_comp`=ppsd.`polis_vendor`
            'LEFT JOIN `tb_polis_reg_det` regd ON ppsd.`id_polis_pps_det`=regd.id_polis_pps_det AND regd.`id_polis_reg`='" & id_reg & "'"
            Dim q As String = "SELECT regd.id_polis_reg_det,ppsd.old_end_date,pps.id_polis_pps,d.description,ppsd.`id_polis_pps_det`,ppsd.`nilai_stock`,ppsd.`nilai_building`,ppsd.`nilai_fit_out`,ppsd.`nilai_peralatan`,ppsd.`nilai_public_liability`,ppsd.`nilai_total`
,c.id_comp,c.`comp_name`,c.`comp_number`,c.address_primary,recv.id_comp AS id_rekomendasi_vendor,recv.comp_name AS rekomendasi_vendor,regd.`rekomendasi_premi`,cv.id_comp AS id_vendor_dipilih,cv.comp_name AS vendor_dipilih,regd.`premi`,regd.`polis_number`
FROM 
`tb_polis_reg_det` regd
INNER JOIN `tb_polis_pps_det` ppsd ON ppsd.`id_polis_pps_det`=regd.id_polis_pps_det AND regd.`id_polis_reg`='" & id_reg & "'
INNER JOIN tb_polis_pps pps ON pps.`id_polis_pps`=ppsd.`id_polis_pps` 
INNER JOIN tb_m_comp c ON c.`id_comp`=ppsd.`id_comp`
INNER JOIN `tb_lookup_desc_premi` d ON d.id_desc_premi=regd.`id_desc_premi`
INNER JOIN tb_m_comp recv ON recv.id_comp=regd.rekomendasi_vendor
LEFT JOIN tb_m_comp cv ON cv.id_comp=regd.vendor_dipilih"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            GCSummary.DataSource = dt
            BGVSummary.BestFitColumns()
            calculate()
        End If
    End Sub

    Sub load_pps_type()
        Dim q As String = "SELECT 1 AS id_pps_type,'Kolektif' AS pps_type
UNION ALL
SELECT 2 AS id_pps_type,'Mandiri' AS pps_type"
        viewSearchLookupQuery(SLEPPSType, q, "id_pps_type", "pps_type", "id_pps_type")
    End Sub

    Sub load_polis_type()
        Dim q As String = "SELECT id_desc_premi,description FROM tb_lookup_desc_premi WHERE is_active=1"
        viewSearchLookupQuery(SLEPolisType, q, "id_desc_premi", "description", "id_desc_premi")
    End Sub

    Private Sub RegisterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegisterToolStripMenuItem.Click
        If BGVSummary.RowCount > 0 Then
            'FormPolisRegSplit.ShowDialog()
            If BtnSave.Visible = True Then
                FormPolisRegPop.ShowDialog()
            End If
        End If
    End Sub

    Private Sub BGVSummary_CellMerge(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs) Handles BGVSummary.CellMerge
        If e.Column.FieldName.ToString = "comp_number" Or e.Column.FieldName.ToString = "comp_name" Or e.Column.FieldName.ToString = "address_primary" Or e.Column.FieldName.ToString = "end_date" Or e.Column.FieldName.ToString = "nilai_stock" Or e.Column.FieldName.ToString = "nilai_building" Or e.Column.FieldName.ToString = "nilai_fit_out" Or e.Column.FieldName.ToString = "nilai_peralatan" Or e.Column.FieldName.ToString = "nilai_public_liability" Or e.Column.FieldName.ToString = "nilai_total" Or e.Column.FieldName.ToString = "vendor" Or e.Column.FieldName.ToString = "premi" Then
            If BGVSummary.GetRowCellValue(e.RowHandle1, "id_polis_pps_det").ToString = BGVSummary.GetRowCellValue(e.RowHandle2, "id_polis_pps_det").ToString Then
                e.Merge = True
                e.Handled = True
            Else
                e.Merge = False
                e.Handled = True
            End If
        End If
    End Sub

    Sub calculate()
        Dim tot As Decimal = 0.00

        Try
            If BGVSummary.RowCount > 0 Then
                tot = BGVSummary.Columns("premi").SummaryItem.SummaryValue
            End If
        Catch ex As Exception

        End Try

        TEPremiTot.EditValue = tot
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim is_ok As Boolean = True

        calculate()

        If SLEPPSType.EditValue.ToString = "1" Then
            'kolektif
            Dim qc As String = "SELECT *
FROM tb_polis_reg_det ppsd
WHERE ppsd.id_polis_reg='" & id_reg & "' AND ppsd.premi<=0"
            Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")

            If dtc.Rows.Count > 0 Then
                warningCustom("Please put all premi per store")
            ElseIf Not TEPremi.EditValue = TEPremiTot.EditValue Then
                warningCustom("Total premi per store is not same with total premi proposed")
            Else
                Dim q As String = "UPDATE tb_polis_reg SET is_submit=1 WHERE id_polis_reg='" & id_reg & "'"
                execute_non_query(q, True, "", "", "", "")
                '
                submit_who_prepared("309", id_reg, id_user)
                '
                load_pps_view()
            End If
        Else
            'mandiri
            Dim qc As String = "SELECT *
FROM tb_polis_reg_det ppsd
WHERE ppsd.id_polis_reg='" & id_reg & "' AND ppsd.premi<=0 AND (ISNULL(ppsd.vendor_dipilih) OR ppsd.vendor_dipilih=0)"
            Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
            If dtc.Rows.Count > 0 Then
                warningCustom("Please register all polis")
            Else
                Dim q As String = "UPDATE tb_polis_reg SET is_submit=1 WHERE id_polis_reg='" & id_reg & "'"
                execute_non_query(q, True, "", "", "", "")
                '
                submit_who_prepared("309", id_reg, id_user)
                '
                load_pps_view()

                'loop
                '                Dim qu As String = ""
                '                Dim ql As String = "SELECT ppsd.`id_polis_pps_det`,IFNULL(ppsd.old_id_polis,0) AS old_id_polis,ppsd.`premi` AS premi_pps,IFNULL(SUM(regd.`premi`),0) AS premi
                'FROM tb_polis_pps_det ppsd
                'LEFT JOIN tb_polis_reg_det regd ON regd.`id_polis_pps_det`=ppsd.`id_polis_pps_det`
                'WHERE ppsd.id_polis_pps='" & id_polis_pps & "'
                'GROUP BY ppsd.`id_polis_pps_det`"
                '                Dim dtl As DataTable = execute_query(ql, -1, True, "", "", "", "")

                '                For i = 0 To dtl.Rows.Count - 1
                '                    'update non active old polis
                '                    qu = "UPDATE `tb_polis` SET is_active=2 WHERE id_polis='" & dtl.Rows(i)("old_id_polis").ToString & "'"
                '                    execute_non_query(qu, True, "", "", "", "")

                '                    'insert baru
                '                    Dim id_pps_baru As String = ""
                '                    qu = "INSERT INTO `tb_polis`(`id_polis_cat`,`id_polis_by`,`id_reff`,`description`,`location`,`start_date`,`end_date`,`nilai_stock`,`nilai_fit_out`,`nilai_building`,`nilai_peralatan`,`nilai_public_liability`,`nilai_total`,`is_active`)
                'SELECT 1 AS id_polis_cat,ppsd.`polis_vendor`,ppsd.`id_comp`,c.comp_name,c.address_primary,ppsd.v_start_date,ppsd.v_end_date,ppsd.`nilai_stock`,ppsd.`nilai_fit_out`,ppsd.`nilai_building`,ppsd.`nilai_peralatan`,ppsd.`nilai_public_liability`,ppsd.`nilai_total`,1 AS is_active
                'FROM `tb_polis_pps_det` ppsd
                'INNER JOIN tb_m_comp c ON c.id_comp=ppsd.id_comp
                'WHERE ppsd.id_polis_pps_det='" & dtl.Rows(i)("id_polis_pps_det").ToString & "';SELECT LAST_INSERT_ID();"
                '                    id_pps_baru = execute_query(qu, 0, True, "", "", "", "")

                '                    'detail
                '                    qu = "INSERT INTO `tb_polis_det`(`id_polis`,`number`,`description`,`premi`) SELECT '" & id_pps_baru & "' AS id_polis,`polis_number`,`description`,`premi` FROM `tb_polis_reg_det` WHERE id_polis_pps_det='" & dtl.Rows(i)("id_polis_pps_det").ToString & "' AND id_polis_reg='" & id_reg & "'"
                '                    execute_non_query(qu, True, "", "", "", "")
                '                Next

                '                'complete
                '                qu = "UPDATE tb_polis_reg 
                'SET id_report_status=6
                'WHERE id_polis_reg = '" & id_reg & "'"
                '                execute_non_query(qu, True, "", "", "", "")
                '
            End If
        End If


    End Sub

    Private Sub FormPolisReg_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BAttachment_Click(sender As Object, e As EventArgs) Handles BAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_reg
        FormDocumentUpload.is_view = is_view
        FormDocumentUpload.report_mark_type = "309"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_reg
        FormReportMark.report_mark_type = "309"
        FormReportMark.is_view = is_view
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class