﻿Public Class FormDebitNoteDet
    Public id_dn As String = "-1"
    Public id_dn_type As String = "-1"
    Public id_comp As String = "-1"

    Public is_view As String = "-1"

    Sub load_form()
        DERefDate.EditValue = getTimeDB()
        DEDueDate.EditValue = getTimeDB()
        DEDueDateInv.EditValue = getTimeDB()

        view_status()
        load_header()
        load_det()

        If id_dn = "-1" Then
            id_comp = FormDebitNote.SLEVendor.EditValue.ToString
            '
            Dim q_dp As String = "SELECT id_acc_dp FROM tb_m_comp WHERE id_comp='" & id_comp & "'"
            Dim dt_dp As DataTable = execute_query(q_dp, -1, True, "", "", "", "")
            If dt_dp.Rows(0)("id_acc_dp").ToString = "" Then
                warningCustom("Please setup DP account first")
                Close()
            End If
            '
            TEVendor.Text = FormDebitNote.SLEVendor.Text.ToString

            DECreated.Text = Date.Parse(Now().ToString).ToString("dd MMMM yyyy")
            TENumber.Text = "[auto generate]"
            TECreatedBy.Text = get_user_identify(id_user, "1")
            MENote.Text = ""

            'pick from type
            If id_dn_type = "1" Or id_dn_type = "4" Then 'reject claim
                If id_dn_type = "1" Then
                    TEDNType.Text = "Claim Reject"

                ElseIf id_dn_type = "4" Then
                    TEDNType.Text = "Claim Reject International"
                End If

                Dim j As Integer = 0
                For i As Integer = 0 To FormDebitNote.GVSumClaimReject.RowCount - 1
                    'add row
                    Dim found As Boolean = False
                    'Try
                    '    For k = 0 To GVItemList.RowCount - 1
                    '        'reject minor
                    '        If GVItemList.GetRowCellValue(k, "unit_price") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") And GVItemList.GetRowCellValue(k, "description").ToString = "REJECT MINOR" And GVItemList.GetRowCellValue(k, "id_report").ToString = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "id_prod_order").ToString And (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_normal_minor") + FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_minor")) > 0 Then
                    '            GVItemList.SetRowCellValue(k, "qty", GVItemList.GetRowCellValue(k, "qty") + (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_normal_minor") + FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_minor")))
                    '            GVItemList.SetRowCellValue(k, "claim_amo", GVItemList.GetRowCellValue(k, "claim_amo") + (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_minor") / 100)) * (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_normal_minor") + FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_minor")))
                    '            found = True
                    '        End If
                    '        'reject major
                    '        If GVItemList.GetRowCellValue(k, "unit_price") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") And GVItemList.GetRowCellValue(k, "description").ToString = "REJECT MAJOR" And GVItemList.GetRowCellValue(k, "id_report").ToString = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "id_prod_order").ToString And (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_minor_major") + FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_major")) > 0 Then
                    '            GVItemList.SetRowCellValue(k, "qty", GVItemList.GetRowCellValue(k, "qty") + (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_minor_major") + FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_major")))
                    '            GVItemList.SetRowCellValue(k, "claim_amo", GVItemList.GetRowCellValue(k, "claim_amo") + (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_major") / 100)) * (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_minor_major") + FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_major")))
                    '            found = True
                    '        End If
                    '        'afkir
                    '        If GVItemList.GetRowCellValue(k, "unit_price") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") And GVItemList.GetRowCellValue(k, "description").ToString = "AFKIR" And GVItemList.GetRowCellValue(k, "id_report").ToString = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "id_prod_order").ToString And FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_afkir") > 0 Then
                    '            GVItemList.SetRowCellValue(k, "qty", GVItemList.GetRowCellValue(k, "qty") + FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_afkir"))
                    '            GVItemList.SetRowCellValue(k, "claim_amo", GVItemList.GetRowCellValue(k, "claim_amo") + (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_afkir") / 100)) * FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_afkir"))
                    '            found = True
                    '        End If
                    '    Next
                    'Catch ex As Exception
                    '    MsgBox(ex.ToString)
                    'End Try

                    If Not found Then
                        j = j + 1
                        If (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_normal_minor") + FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_minor")) > 0 Then 'reject minor
                            Dim newRow As DataRow = (TryCast(GCItemList.DataSource, DataTable)).NewRow()
                            newRow("number") = j
                            newRow("id_reff") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "id_reff").ToString
                            newRow("id_report") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "id_prod_order").ToString
                            newRow("id_currency") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "id_currency").ToString
                            newRow("currency") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "currency").ToString
                            newRow("report_mark_type") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "report_mark_type").ToString
                            newRow("report_number") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_number").ToString
                            newRow("info_design") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "design_display_name").ToString
                            newRow("description") = "REJECT MINOR (PRE RECEIVE " & FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "rec_pl_category") & ")"
                            newRow("claim_percent") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_minor") - FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "rec_discount")
                            newRow("qty") = (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_normal_minor") + FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_minor"))

                            If id_dn_type = "1" Then
                                newRow("kurs") = 1
                                newRow("unit_price_usd") = 0
                                newRow("claim_pcs_usd") = 0
                                newRow("claim_amo_usd") = 0
                                newRow("unit_price") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price")
                                newRow("claim_pcs") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * ((FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_minor") - FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "rec_discount")) / 100)
                                newRow("claim_amo") = (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * ((FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_minor") - FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "rec_discount")) / 100)) * (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_normal_minor") + FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_minor"))
                            Else
                                newRow("kurs") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_kurs")
                                newRow("unit_price_usd") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price")
                                newRow("claim_pcs_usd") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * ((FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_minor") - FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "rec_discount")) / 100)
                                newRow("claim_amo_usd") = (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * ((FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_minor") - FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "rec_discount")) / 100)) * (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_normal_minor") + FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_minor"))
                                newRow("unit_price") = Math.Round(FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_kurs"), 2)
                                newRow("claim_pcs") = Math.Round(FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_kurs"), 2) * ((FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_minor") - FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "rec_discount")) / 100)
                                newRow("claim_amo") = (Math.Round(FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_kurs"), 2) * ((FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_minor") - FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "rec_discount")) / 100)) * (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_normal_minor") + FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_minor"))
                            End If
                            TryCast(GCItemList.DataSource, DataTable).Rows.Add(newRow)
                            GCItemList.RefreshDataSource()
                            GVItemList.RefreshData()
                        End If

                        If (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_minor_major") + FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_major")) > 0 Then 'reject major
                            Dim newRow As DataRow = (TryCast(GCItemList.DataSource, DataTable)).NewRow()
                            newRow("number") = j
                            newRow("id_reff") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "id_reff").ToString
                            newRow("id_report") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "id_prod_order").ToString
                            newRow("id_currency") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "id_currency").ToString
                            newRow("currency") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "currency").ToString
                            newRow("report_mark_type") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "report_mark_type").ToString
                            newRow("report_number") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_number").ToString
                            newRow("info_design") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "design_display_name").ToString
                            newRow("description") = "REJECT MAJOR (PRE RECEIVE " & FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "rec_pl_category") & ")"
                            newRow("claim_percent") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_major") - FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "rec_discount")
                            newRow("qty") = (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_minor_major") + FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_major"))
                            newRow("unit_price") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price")
                            newRow("claim_pcs") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * ((FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_major") - FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "rec_discount")) / 100)
                            newRow("claim_amo") = (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * ((FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_major") - FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "rec_discount")) / 100)) * (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_minor_major") + FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_major"))

                            If id_dn_type = "1" Then
                                newRow("kurs") = 1
                                newRow("unit_price_usd") = 0
                                newRow("claim_pcs_usd") = 0
                                newRow("claim_amo_usd") = 0
                                newRow("unit_price") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price")
                                newRow("claim_pcs") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * ((FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_major") - FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "rec_discount")) / 100)
                                newRow("claim_amo") = (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * ((FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_major") - FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "rec_discount")) / 100)) * (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_minor_major") + FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_major"))
                            Else
                                newRow("kurs") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_kurs")
                                newRow("unit_price_usd") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price")
                                newRow("claim_pcs_usd") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * ((FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_major") - FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "rec_discount")) / 100)
                                newRow("claim_amo_usd") = (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * ((FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_major") - FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "rec_discount")) / 100)) * (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_minor_major") + FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_major"))
                                newRow("unit_price") = Math.Round(FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_kurs"), 2)
                                newRow("claim_pcs") = Math.Round(FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_kurs"), 2) * ((FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_major") - FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "rec_discount")) / 100)
                                newRow("claim_amo") = (Math.Round(FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_kurs"), 2) * ((FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_major") - FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "rec_discount")) / 100)) * (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_minor_major") + FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_major"))
                            End If


                            TryCast(GCItemList.DataSource, DataTable).Rows.Add(newRow)
                            GCItemList.RefreshDataSource()
                            GVItemList.RefreshData()
                        End If

                        If FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_afkir") > 0 Then 'reject afkir
                            Dim newRow As DataRow = (TryCast(GCItemList.DataSource, DataTable)).NewRow()
                            newRow("number") = j
                            newRow("id_reff") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "id_reff").ToString
                            newRow("id_report") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "id_prod_order").ToString
                            newRow("id_currency") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "id_currency").ToString
                            newRow("currency") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "currency").ToString
                            newRow("report_mark_type") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "report_mark_type").ToString
                            newRow("report_number") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_number").ToString
                            newRow("info_design") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "design_display_name").ToString
                            newRow("description") = "AFKIR (PRE RECEIVE " & FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "rec_pl_category") & ")"
                            newRow("claim_percent") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_afkir") - FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "rec_discount")
                            newRow("qty") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_afkir")
                            newRow("unit_price") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price")
                            newRow("claim_pcs") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * ((FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_afkir") - FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "rec_discount")) / 100)
                            newRow("claim_amo") = (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * ((FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_afkir") - FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "rec_discount")) / 100)) * FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_afkir")

                            If id_dn_type = "1" Then
                                newRow("kurs") = 1
                                newRow("unit_price_usd") = 0
                                newRow("claim_pcs_usd") = 0
                                newRow("claim_amo_usd") = 0
                                newRow("unit_price") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price")
                                newRow("claim_pcs") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * ((FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_afkir") - FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "rec_discount")) / 100)
                                newRow("claim_amo") = (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * ((FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_afkir") - FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "rec_discount")) / 100)) * FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_afkir")
                            Else
                                newRow("kurs") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_kurs")
                                newRow("unit_price_usd") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price")
                                newRow("claim_pcs_usd") = FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * ((FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_afkir") - FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "rec_discount")) / 100)
                                newRow("claim_amo_usd") = (FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * ((FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_afkir") - FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "rec_discount")) / 100)) * FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_afkir")
                                newRow("unit_price") = Math.Round(FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_kurs"), 2)
                                newRow("claim_pcs") = Math.Round(FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_kurs"), 2) * ((FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_afkir") - FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "rec_discount")) / 100)
                                newRow("claim_amo") = (Math.Round(FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_det_price") * FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "prod_order_wo_kurs"), 2) * ((FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "p_afkir") - FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "rec_discount")) / 100)) * FormDebitNote.GVSumClaimReject.GetRowCellValue(i, "qc_afkir")
                            End If

                            TryCast(GCItemList.DataSource, DataTable).Rows.Add(newRow)
                            GCItemList.RefreshDataSource()
                            GVItemList.RefreshData()
                        End If
                    End If

                    GVItemList.BestFitColumns()
                Next
            ElseIf id_dn_type = "2" Then 'late claim
                TEDNType.Text = "Claim Late"
                Try
                    For i As Integer = 0 To FormDebitNote.GVClaimLate.RowCount - 1
                        Dim newRow As DataRow = (TryCast(GCItemList.DataSource, DataTable)).NewRow()
                        newRow("number") = i + 1
                        newRow("id_report") = FormDebitNote.GVClaimLate.GetRowCellValue(i, "id_prod_order_rec").ToString
                        newRow("id_currency") = "1"
                        newRow("currency") = "Rp"
                        newRow("report_mark_type") = FormDebitNote.GVClaimLate.GetRowCellValue(i, "report_mark_type").ToString
                        newRow("report_number") = FormDebitNote.GVClaimLate.GetRowCellValue(i, "prod_order_rec_number").ToString
                        newRow("info_design") = FormDebitNote.GVClaimLate.GetRowCellValue(i, "design_display_name").ToString
                        newRow("description") = "HASIL PRODUKSI DATANG TERLAMBAT" & vbNewLine & "Delivery Date PO : " & Date.Parse(FormDebitNote.GVClaimLate.GetRowCellValue(i, "est_rec_date").ToString).ToString("dd MMMM yyyy") & vbNewLine & "Delivery Date KO : " & Date.Parse(FormDebitNote.GVClaimLate.GetRowCellValue(i, "est_rec_date_ko").ToString).ToString("dd MMMM yyyy") & vbNewLine & "Received Date : " & Date.Parse(FormDebitNote.GVClaimLate.GetRowCellValue(i, "arrive_date").ToString).ToString("dd MMMM yyyy") & vbNewLine & "Charge Back : " & FormDebitNote.GVClaimLate.GetRowCellValue(i, "late_day").ToString & " hari kalender"
                        newRow("claim_percent") = FormDebitNote.GVClaimLate.GetRowCellValue(i, "claim_percent")
                        newRow("unit_price") = FormDebitNote.GVClaimLate.GetRowCellValue(i, "prod_order_wo_det_price")
                        newRow("qty") = FormDebitNote.GVClaimLate.GetRowCellValue(i, "rec_qty_trx")
                        newRow("claim_pcs") = FormDebitNote.GVClaimLate.GetRowCellValue(i, "prod_order_wo_det_price") * (FormDebitNote.GVClaimLate.GetRowCellValue(i, "claim_percent") / 100)
                        newRow("claim_amo") = (FormDebitNote.GVClaimLate.GetRowCellValue(i, "prod_order_wo_det_price") * (FormDebitNote.GVClaimLate.GetRowCellValue(i, "claim_percent") / 100)) * FormDebitNote.GVClaimLate.GetRowCellValue(i, "rec_qty_trx")
                        newRow("kurs") = 1
                        newRow("unit_price_usd") = 0
                        newRow("claim_pcs_usd") = 0
                        newRow("claim_amo_usd") = 0
                        TryCast(GCItemList.DataSource, DataTable).Rows.Add(newRow)
                        GCItemList.RefreshDataSource()
                        GVItemList.RefreshData()
                    Next
                    GVItemList.BestFitColumns()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If
            BMark.Visible = False
            BtnPrint.Visible = False
            DEDueDate.Properties.ReadOnly = False
            DERefDate.Properties.ReadOnly = False
            DEDueDateInv.Properties.ReadOnly = False

            DERefDate.Properties.MinValue = execute_query("SELECT DATE_ADD(MAX(date_until),INTERVAL 1 DAY) FROM `tb_closing_log` WHERE id_coa_tag='1'", 0, True, "", "", "", "")
        Else 'edit
            BtnSave.Visible = False
            BMark.Visible = True
            BtnPrint.Visible = True
            '
            DEDueDate.Properties.ReadOnly = True
            DERefDate.Properties.ReadOnly = True
            DEDueDateInv.Properties.ReadOnly = True
            '
            If id_dn_type = "4" Then
                GCKurs.Visible = True
                GCPriceUSD.Visible = True
                GCClaimUSD.Visible = True
                GCAmoUSD.Visible = True
            Else
                GCKurs.Visible = False
                GCPriceUSD.Visible = False
                GCClaimUSD.Visible = False
                GCAmoUSD.Visible = False
            End If
        End If

        If is_view = "1" Then
            BCancelDebitNote.Visible = False
            BtnPrint.Visible = False
        End If

        calculate()
    End Sub

    Private Sub FormDebitNoteDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Sub view_status()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub load_header()
        Dim query As String = "SELECT dn.`id_debit_note`,dn.due_date,dn.due_date_inv,dn.ref_date,dn.`id_comp`,dn.`number`,dn.`id_dn_type`,dnt.dn_type,dn.`created_date`,dn.id_report_status,st.`report_status`,dn.`note`,dn.`id_report_status`,emp.`employee_name`,comp.`comp_name`,comp.address_primary FROM tb_debit_note dn
INNER JOIN tb_m_comp comp ON comp.`id_comp`=dn.`id_comp`
INNER JOIN tb_m_user usr ON usr.`id_user`=dn.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_lookup_report_status st ON st.`id_report_status`=dn.`id_report_status`
INNER JOIN tb_lookup_dn_type dnt ON dnt.id_dn_type=dn.id_dn_type
WHERE dn.id_debit_note='" & id_dn & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            id_comp = data.Rows(0)("id_comp").ToString
            TEDNType.Text = data.Rows(0)("dn_type").ToString
            TEVendor.Text = data.Rows(0)("comp_name").ToString
            MEAddress.Text = data.Rows(0)("address_primary").ToString
            DECreated.Text = Date.Parse(data.Rows(0)("created_date").ToString).ToString("dd MMMM yyyy")
            DEDueDate.EditValue = data.Rows(0)("due_date")
            DERefDate.EditValue = data.Rows(0)("ref_date")
            DEDueDateInv.EditValue = data.Rows(0)("due_date_inv")
            TENumber.Text = data.Rows(0)("number").ToString
            TECreatedBy.Text = data.Rows(0)("employee_name").ToString
            MENote.Text = data.Rows(0)("note").ToString
            '
            id_dn_type = data.Rows(0)("id_dn_type").ToString
            id_comp = data.Rows(0)("id_comp").ToString
            '
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            If Not data.Rows(0)("id_report_status").ToString = "1" Then
                BCancelDebitNote.Visible = False
                If data.Rows(0)("id_report_status").ToString = "6" Then
                    BtnViewJournal.Visible = True
                End If
            Else
                BCancelDebitNote.Visible = True
            End If
        End If
    End Sub

    Sub load_det()
        Dim query As String = "SELECT dnd.id_reff,dnd.`report_number`,dnd.`info_design`,dnd.`description`,dnd.`claim_percent`,dnd.`qty`,dnd.`id_report`,dnd.`report_mark_type`
,dnd.`unit_price_usd`
,ROUND((dnd.`claim_percent`/100)*dnd.`unit_price_usd`,2) as claim_pcs_usd
,ROUND((dnd.`claim_percent`/100)*dnd.`unit_price_usd`,2) * dnd.`qty` as claim_amo_usd
,dnd.kurs
,dnd.id_currency,cur.currency
,dnd.`unit_price`
,ROUND((dnd.`claim_percent`/100)*dnd.`unit_price`,2) AS claim_pcs
,ROUND((dnd.`claim_percent`/100)*dnd.`unit_price`,2) * dnd.`qty` as claim_amo
,@curRow := @curRow + 1 AS `number`
FROM tb_debit_note_det dnd
INNER JOIN tb_lookup_currency cur ON cur.id_currency=dnd.id_currency
JOIN (SELECT @curRow := 0) r
WHERE dnd.id_debit_note='" & id_dn & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
        GVItemList.BestFitColumns()
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_dn
        FormReportMark.is_view = is_view
        FormReportMark.report_mark_type = "221"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormDebitNoteDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub calculate()
        Dim total As Decimal = 0.00

        If Decimal.Parse(GVItemList.Columns("claim_amo_usd").SummaryItem.SummaryValue) > 0 Then
            total = Decimal.Parse(GVItemList.Columns("claim_amo_usd").SummaryItem.SummaryValue)
            METotSay.Text = ConvertCurrencyToEnglish(total, "").ToUpper
        Else
            total = Decimal.Parse(GVItemList.Columns("claim_amo").SummaryItem.SummaryValue)
            METotSay.Text = ConvertCurrencyToIndonesian(total).ToUpper
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim note As String = addSlashes(MENote.Text)
        Dim is_ok As Boolean = True
        '
        For i As Integer = 0 To GVItemList.RowCount - 1
            If GVItemList.GetRowCellValue(i, "claim_amo") < 0 Then
                is_ok = False
            End If
        Next
        '
        If GVItemList.RowCount = 0 Then
            warningCustom("Please input what to debit note")
        ElseIf id_comp = "-1" Then
            warningCustom("Please choose the vendor first.")
        ElseIf is_ok = False Then
            warningCustom("Please complete your detail input")
        Else
            If id_dn = "-1" Then 'new
                Dim query As String = "INSERT INTO tb_debit_note(id_comp,id_dn_type,created_by,created_date,due_date,due_date_inv,ref_date,note,id_report_status) VALUES('" & id_comp & "','" & id_dn_type & "','" & id_user & "',NOW(),'" & Date.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & Date.Parse(DEDueDateInv.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & Date.Parse(DERefDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & addSlashes(MENote.Text) & "','1'); SELECT LAST_INSERT_ID(); "
                id_dn = execute_query(query, 0, True, "", "", "", "")

                query = "CALL gen_number('" & id_dn & "','221')"
                execute_non_query(query, True, "", "", "", "")

                Dim q_det As String = "INSERT INTO tb_debit_note_det(id_debit_note,id_reff,id_report,report_mark_type,report_number,info_design,description,claim_percent,unit_price,qty,id_currency,kurs,unit_price_usd) VALUES"
                For i As Integer = 0 To GVItemList.RowCount - 1
                    If i > 0 Then
                        q_det += ","
                    End If
                    q_det += "('" & id_dn & "','" & GVItemList.GetRowCellValue(i, "id_reff").ToString & "','" & GVItemList.GetRowCellValue(i, "id_report").ToString & "','" & GVItemList.GetRowCellValue(i, "report_mark_type").ToString & "','" & GVItemList.GetRowCellValue(i, "report_number").ToString & "','" & GVItemList.GetRowCellValue(i, "info_design").ToString & "','" & addSlashes(GVItemList.GetRowCellValue(i, "description").ToString) & "','" & decimalSQL(GVItemList.GetRowCellValue(i, "claim_percent").ToString) & "','" & decimalSQL(GVItemList.GetRowCellValue(i, "unit_price").ToString) & "','" & decimalSQL(GVItemList.GetRowCellValue(i, "qty").ToString) & "','" & GVItemList.GetRowCellValue(i, "id_currency").ToString & "','" & decimalSQL(GVItemList.GetRowCellValue(i, "kurs").ToString) & "','" & decimalSQL(GVItemList.GetRowCellValue(i, "unit_price_usd").ToString) & "')"
                Next
                execute_non_query(q_det, True, "", "", "", "")

                submit_who_prepared("221", id_dn, id_user)
                FormDebitNote.load_form()
                Close()
            Else 'edit

            End If
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor

        ReportDebitNote.id_report = id_dn
        ReportDebitNote.vendor = TEVendor.Text
        'add datasource
        Dim q As String = "SELECT dnd.`report_number`,dnd.`info_design`,dnd.`description`,dnd.`claim_percent`,dnd.`qty`,dnd.`id_report`,dnd.`report_mark_type`
,dnd.`unit_price`
,ROUND((dnd.`claim_percent`/100)*dnd.`unit_price`,2) AS claim_pcs
,ROUND((dnd.`claim_percent`/100)*dnd.`unit_price`,2) * dnd.`qty` AS claim_amo
,dnd.`unit_price_usd`,dnd.kurs
,ROUND((dnd.`claim_percent`/100)*dnd.`unit_price_usd`,2) AS claim_pcs_usd
,ROUND((dnd.`claim_percent`/100)*dnd.`unit_price_usd`,2) * dnd.`qty` AS claim_amo_usd
,dnd.currency
,@curRow := @curRow + 1 AS `number`
FROM 
(
	SELECT dnd.`report_number`,cur.currency,dnd.`info_design`,dnd.`description`,dnd.kurs,dnd.`claim_percent`,dnd.`unit_price`,dnd.`unit_price_usd`,SUM(dnd.`qty`) AS qty,dnd.`id_report`,dnd.`report_mark_type`,SUM((dnd.`claim_percent`/100)*dnd.`unit_price`) AS claim_pcs, SUM(((dnd.`claim_percent`/100)*dnd.`unit_price`) * dnd.`qty`) AS claim_amo
	FROM tb_debit_note_det dnd
    INNER JOIN tb_lookup_currency cur ON cur.id_currency=dnd.id_currency
	WHERE dnd.id_debit_note='" & id_dn & "'
	GROUP BY dnd.id_report,dnd.`unit_price`,dnd.description
) dnd
JOIN (SELECT @curRow := 0) r"
        Dim dtq As DataTable = execute_query(q, -1, True, "", "", "", "")
        ReportDebitNote.dt = dtq
        Dim Report As New ReportDebitNote()

        Report.LSay.Text = METotSay.Text
        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        If id_dn_type = "4" Then
            GCClaimPcs.Visible = False
            GCPriceUnit.Visible = False
            GCAmo.Visible = False
            GCKurs.Visible = False
        End If
        '
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVItemList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVItemList.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        '
        If id_dn_type = "4" Then
            GCKurs.VisibleIndex = 8
            GCClaimPcs.VisibleIndex = 9
            GCPriceUnit.VisibleIndex = 10
            GCAmo.VisibleIndex = 13
        End If
        '
        'Grid Detail
        ReportStyleGridview(Report.GVItemList)
        Report.GVItemList.RowHeight = 15
        Report.GVItemList.ColumnPanelRowHeight = 30
        '
        Dim query As String = "SELECT dn.`id_debit_note`,dn.`id_comp`,dn.`number`,dn.`id_dn_type`,dnt.dn_type,DATE_FORMAT(dn.`created_date`,'%d %M %Y') as created_date,dn.id_report_status,st.`report_status`,dn.`note`,dn.`id_report_status`,emp.`employee_name`,comp.`comp_name`,comp.address_primary 
FROM tb_debit_note dn
INNER JOIN tb_m_comp comp ON comp.`id_comp`=dn.`id_comp`
INNER JOIN tb_m_user usr ON usr.`id_user`=dn.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_lookup_report_status st ON st.`id_report_status`=dn.`id_report_status`
INNER JOIN tb_lookup_dn_type dnt ON dnt.id_dn_type=dn.id_dn_type
WHERE dn.id_debit_note='" & id_dn & "'"
        Dim dt As DataTable = execute_query(query, -1, True, "", "", "", "")
        Report.DataSource = dt
        '
        If id_dn_type = "4" Then
            Report.LKepada.Text = "To"
            Report.LTanggal.Text = "Date"
            Report.LDengan.Text = "deduct from invoice"
            Report.LTerbilang.Text = "Say"
        End If
        '' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        FormDocumentUpload.id_report = id_dn
        FormDocumentUpload.report_mark_type = "221"
        FormDocumentUpload.is_no_delete = "1"
        FormDocumentUpload.ShowDialog()
    End Sub

    Private Sub BCancelDebitNote_Click(sender As Object, e As EventArgs) Handles BCancelDebitNote.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to cancel debit note?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            delete_all_mark_related("221", id_dn)
            Dim query As String = "UPDATE tb_debit_note SET id_report_status='5' WHERE id_debit_note='" & id_dn & "'"
            execute_non_query(query, True, "", "", "", "")
            warningCustom("Debit note canceled")
            '
            load_form()
            FormDebitNote.load_debit_note()
            '
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnViewJournal_Click(sender As Object, e As EventArgs) Handles BtnViewJournal.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            WHERE ad.report_mark_type=221 AND ad.id_report=" + id_dn + "
            GROUP BY ad.id_acc_trans ", 0, True, "", "", "", "")
        Catch ex As Exception
            id_acc_trans = ""
        End Try

        If id_acc_trans <> "" Then
            Dim s As New ClassShowPopUp()
            FormViewJournal.is_enable_view_doc = False
            FormViewJournal.BMark.Visible = False
            s.id_report = id_acc_trans
            s.report_mark_type = "36"
            s.show()
        Else
            warningCustom("Auto journal not found.")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ViewQCReportSummaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewQCReportSummaryToolStripMenuItem.Click
        If GVItemList.RowCount > 0 Then
            Dim q As String = "SELECT sd.id_prod_fc_sum
FROM `tb_prod_fc_sum_det` sd
INNER JOIN `tb_prod_fc_sum` s ON s.id_prod_fc_sum=sd.id_prod_fc_sum AND s.id_report_status=6
WHERE sd.id_prod_fc='" & GVItemList.GetFocusedRowCellValue("id_reff").ToString & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                Dim qcp As New ClassShowPopUp
                qcp.id_report = dt.Rows(0)("id_prod_fc_sum").ToString
                qcp.report_mark_type = "222"
                qcp.show()
            Else
                warningCustom("Summary not found")
            End If
        Else
            warningCustom("Summary not found")
        End If
    End Sub

    'Private Sub GVItemList_CustomDrawFooter(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles GVItemList.CustomDrawFooter
    '    Dim stringFormat As StringFormat = New StringFormat()
    '    stringFormat.Alignment = StringAlignment.Near
    '    stringFormat.LineAlignment = StringAlignment.Center
    '    Dim rect = e.Bounds
    '    rect.X += 10
    '    e.DefaultDraw()
    '    e.Cache.DrawString("TOTAL", e.Appearance.GetFont(), e.Appearance.GetForeBrush(e.Cache), rect, stringFormat)
    '    e.Handled = True
    'End Sub
End Class