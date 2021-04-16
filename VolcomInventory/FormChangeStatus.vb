﻿Public Class FormChangeStatus
    Public id_pop_up As String = "-1"
    Public id_current As String = ""
    Public id_volcomstore_normal As String = "-1"
    Public id_volcomstore_sale As String = "-1"

    '1 = Finalize WH- Rec Prod
    '2 = Finalize WH- DO
    '3 = RETURN
    '4 = RETURN QC
    '5 = TRF
    '6 = non stock

    Sub viewReportStatus()
        Dim query As String = "SELECT id_report_status, report_status FROM tb_lookup_report_status WHERE id_report_status=5 OR id_report_status=6 ORDER BY id_report_status DESC "
        viewSearchLookupQuery(SLEStatusRec, query, "id_report_status", "report_status", "id_report_status")
    End Sub

    Sub getOnlineStoreVolcom()
        id_volcomstore_normal = execute_query("SELECT v.id_store FROM tb_m_comp_volcom_ol v WHERE v.id_design_cat=1", 0, True, "", "", "", "")
        id_volcomstore_sale = execute_query("SELECT v.id_store FROM tb_m_comp_volcom_ol v WHERE v.id_design_cat=2", 0, True, "", "", "", "")
    End Sub

    Private Sub FormChangeStatus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        getOnlineStoreVolcom()
    End Sub

    Private Sub BtnUpdateRec_Click(sender As Object, e As EventArgs) Handles BtnUpdateRec.Click
        'var
        Dim report_mark_type As String = ""
        Dim assigned As Boolean = True
        Dim note As String = MEComment.Text
        Dim id_status_reportx As String = SLEStatusRec.EditValue.ToString
        Dim gv As DevExpress.XtraGrid.Views.Grid.GridView
        Dim id As String = ""
        'completed or processed
        If id_pop_up = "1" Then 'rec
            report_mark_type = "37"
            gv = FormSalesOrderSvcLevel.GVPL
            id = "id_pl_prod_order_rec"
        ElseIf id_pop_up = "2" Then 'DO
            report_mark_type = "43"
            gv = FormSalesOrderSvcLevel.GVSalesDelOrder
            id = "id_pl_sales_order_del"
        ElseIf id_pop_up = "3" Then 'RETURN
            report_mark_type = "46"
            gv = FormSalesOrderSvcLevel.GVSalesReturn
            id = "id_sales_return"
        ElseIf id_pop_up = "4" Then 'RETURN QC
            report_mark_type = "49"
            gv = FormSalesOrderSvcLevel.GVSalesReturnQC
            id = "id_sales_return_qc"
        ElseIf id_pop_up = "5" Then 'TRF
            report_mark_type = "57"
            gv = FormSalesOrderSvcLevel.GVFGTrf
            id = "id_fg_trf"
        ElseIf id_pop_up = "6" Then
            report_mark_type = "111"
            gv = FormSalesOrderSvcLevel.GVNonStock
            id = "id_wh_del_empty"
        Else
            gv = Nothing
        End If

        'blocking cancel
        If id_pop_up = "2" And SLEStatusRec.EditValue.ToString = "5" Then
            Dim am As String = ""
            For a As Integer = 0 To ((gv.RowCount - 1) - GetGroupRowCount(gv))
                Dim id_del_manifest As String = gv.GetRowCellValue(a, "id_del_manifest").ToString
                Dim del_number As String = gv.GetRowCellValue(a, "pl_sales_order_del_number").ToString
                If id_del_manifest <> "0" Then
                    am += "- " + del_number + System.Environment.NewLine
                End If
            Next
            If am <> "" Then
                stopCustom("Some delivery number already created on Outbound Delivery Manifest" + System.Environment.NewLine + am)
                Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        'cek tracking code
        If id_pop_up = "2" And SLEStatusRec.EditValue.ToString = "6" Then
            Dim err_track_code As String = ""
            For b As Integer = 0 To ((gv.RowCount - 1) - GetGroupRowCount(gv))
                Dim del_number As String = gv.GetRowCellValue(b, "pl_sales_order_del_number").ToString
                Dim id_store As String = gv.GetRowCellValue(b, "id_store").ToString
                Dim track_code As String = gv.GetRowCellValue(b, "awbill_no").ToString
                If track_code = "" And (id_store = id_volcomstore_normal Or id_store = id_volcomstore_sale) Then
                    err_track_code = "Can't proceed this delivery : " + del_number + ". AWB number not found"
                    Exit For
                End If
            Next
            If err_track_code <> "" Then
                stopCustom(err_track_code)
                Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        For c As Integer = 0 To ((gv.RowCount - 1) - GetGroupRowCount(gv))
            Dim id_report As String = gv.GetRowCellValue(c, id).ToString
            Dim query_jml As String = ""
            If id_pop_up = "3" Then 'return krn byk rmt
                query_jml = String.Format("SELECT count(id_report_mark) FROM tb_report_mark WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status <= '3' AND id_mark != '2' AND is_use='1'", gv.GetRowCellValue(c, "rmt").ToString, id_report)
            ElseIf id_pop_up = "4" Then
                query_jml = "SELECT COUNT(id_sales_return_qc) FROM tb_sales_return_qc WHERE (id_report_status=1 OR id_report_status=5 OR id_report_status=6) AND id_sales_return_qc='" & id_report & "'"
                'query_jml = String.Format("SELECT count(id_report_mark) FROM tb_report_mark WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status <= '3' AND id_mark != '2' AND is_use='1'", gv.GetRowCellValue(c, "rmk").ToString, id_report)
            Else
                query_jml = String.Format("SELECT count(id_report_mark) FROM tb_report_mark WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status <= '3' AND id_mark != '2' AND is_use='1'", report_mark_type, id_report)
            End If
            Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
            If jml >= 1 Then
                assigned = False
            End If
        Next


        If (assigned = True) Or id_status_reportx = "5" Then
            If id_pop_up = "1" Then
                Dim check_stt As Boolean = False
                For c As Integer = 0 To ((FormSalesOrderSvcLevel.GVPL.RowCount - 1) - GetGroupRowCount(FormSalesOrderSvcLevel.GVPL))
                    Dim rs As String = FormSalesOrderSvcLevel.GVPL.GetRowCellValue(c, "id_report_status").ToString
                    If rs = "5" Or rs = "6" Then
                        check_stt = True
                        Exit For
                    End If
                Next

                If check_stt Then
                    stopCustom("Can't update status because data is already locked.")
                    FormSalesOrderSvcLevel.GVPL.ActiveFilterString = ""
                    Close()
                Else
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to set " + SLEStatusRec.Text.ToLower.ToString + " status for these data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        BtnUpdateRec.Enabled = False
                        For i As Integer = 0 To ((FormSalesOrderSvcLevel.GVPL.RowCount - 1) - GetGroupRowCount(FormSalesOrderSvcLevel.GVPL))
                            Dim ch_stt As ClassProductionPLToWHRec = New ClassProductionPLToWHRec()
                            ch_stt.changeStatus(FormSalesOrderSvcLevel.GVPL.GetRowCellValue(i, "id_pl_prod_order_rec").ToString, SLEStatusRec.EditValue.ToString)
                            removeAppList(report_mark_type, FormSalesOrderSvcLevel.GVPL.GetRowCellValue(i, "id_pl_prod_order_rec").ToString, id_status_reportx)
                            insertFinalComment(report_mark_type, FormSalesOrderSvcLevel.GVPL.GetRowCellValue(i, "id_pl_prod_order_rec").ToString, id_status_reportx, note)
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        Cursor = Cursors.Default
                    End If
                End If
                FormSalesOrderSvcLevel.GVPL.ActiveFilterString = ""
                FormSalesOrderSvcLevel.viewRecProduct()
                Close()
            ElseIf id_pop_up = "2" Then
                Dim check_stt As Boolean = False
                For c As Integer = 0 To ((FormSalesOrderSvcLevel.GVSalesDelOrder.RowCount - 1) - GetGroupRowCount(FormSalesOrderSvcLevel.GVSalesDelOrder))
                    Dim rs As String = FormSalesOrderSvcLevel.GVSalesDelOrder.GetRowCellValue(c, "id_report_status").ToString
                    If rs = "5" Or rs = "6" Then
                        check_stt = True
                        Exit For
                    End If
                Next

                If check_stt Then
                    stopCustom("Can't update status because data is already locked.")
                    FormSalesOrderSvcLevel.GVSalesDelOrder.ActiveFilterString = ""
                    Close()
                Else
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to set " + SLEStatusRec.Text.ToLower.ToString + " status for these data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        BtnUpdateRec.Enabled = False
                        For i As Integer = 0 To ((FormSalesOrderSvcLevel.GVSalesDelOrder.RowCount - 1) - GetGroupRowCount(FormSalesOrderSvcLevel.GVSalesDelOrder))
                            Dim id_combine As String = FormSalesOrderSvcLevel.GVSalesDelOrder.GetRowCellValue(i, "id_combine").ToString
                            Dim stt As ClassSalesDelOrder = New ClassSalesDelOrder()
                            '
                            stt.changeStatus(FormSalesOrderSvcLevel.GVSalesDelOrder.GetRowCellValue(i, "id_pl_sales_order_del").ToString, SLEStatusRec.EditValue.ToString)
                            'If id_combine = "0" Then
                            '    'jika delivery single
                            '    'pindah ke class sales del order
                            '    stt.changeStatus(FormSalesOrderSvcLevel.GVSalesDelOrder.GetRowCellValue(i, "id_pl_sales_order_del").ToString, SLEStatusRec.EditValue.ToString)
                            '    'stt.insertUniqueCode(FormSalesOrderSvcLevel.GVSalesDelOrder.GetRowCellValue(i, "id_pl_sales_order_del").ToString, FormSalesOrderSvcLevel.GVSalesDelOrder.GetRowCellValue(i, "id_store").ToString, FormSalesOrderSvcLevel.GVSalesDelOrder.GetRowCellValue(i, "is_use_unique_code").ToString)
                            '    'removeAppList(report_mark_type, FormSalesOrderSvcLevel.GVSalesDelOrder.GetRowCellValue(i, "id_pl_sales_order_del").ToString, id_status_reportx)
                            '    'insertFinalComment(report_mark_type, FormSalesOrderSvcLevel.GVSalesDelOrder.GetRowCellValue(i, "id_pl_sales_order_del").ToString, id_status_reportx, note)
                            '    'sendEmailConfirmation(FormSalesOrderSvcLevel.GVSalesDelOrder.GetRowCellValue(i, "id_commerce_type").ToString, FormSalesOrderSvcLevel.GVSalesDelOrder.GetRowCellValue(i, "id_pl_sales_order_del").ToString)
                            '    'sendEmailConfirmationforConceptStore(FormSalesOrderSvcLevel.GVSalesDelOrder.GetRowCellValue(i, "is_use_unique_code").ToString, FormSalesOrderSvcLevel.GVSalesDelOrder.GetRowCellValue(i, "id_pl_sales_order_del").ToString, "43")
                            '    'updateStatusOnlineStore(FormSalesOrderSvcLevel.GVSalesDelOrder.GetRowCellValue(i, "id_commerce_type").ToString, FormSalesOrderSvcLevel.GVSalesDelOrder.GetRowCellValue(i, "id_store").ToString, FormSalesOrderSvcLevel.GVSalesDelOrder.GetRowCellValue(i, "id_pl_sales_order_del").ToString, FormSalesOrderSvcLevel.GVSalesDelOrder.GetRowCellValue(i, "id_web_order").ToString)
                            'Else
                            '    'jika delivery combine
                            '    Dim id_del As String = FormSalesOrderSvcLevel.GVSalesDelOrder.GetRowCellValue(i, "id_pl_sales_order_del").ToString
                            '    Dim del_stt As String = execute_query("SELECT id_report_status FROM tb_pl_sales_order_del WHERE id_pl_sales_order_del=" + id_del + " ", 0, True, "", "", "", "")
                            '    If del_stt <> SLEStatusRec.EditValue.ToString Then
                            '        stt.changeStatusHead(id_combine, SLEStatusRec.EditValue.ToString)
                            '        stt.insertUniqueCodeHead(id_combine, FormSalesOrderSvcLevel.GVSalesDelOrder.GetRowCellValue(i, "id_store").ToString, FormSalesOrderSvcLevel.GVSalesDelOrder.GetRowCellValue(i, "is_use_unique_code").ToString)
                            '        removeAppListCombine("103", id_combine, id_status_reportx)
                            '        insertFinalCommentCombine("103", id_combine, id_status_reportx, note)
                            '        sendEmailConfirmationforConceptStore(FormSalesOrderSvcLevel.GVSalesDelOrder.GetRowCellValue(i, "is_use_unique_code").ToString, id_combine, "103")
                            '    End If
                            'End If
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        Cursor = Cursors.Default
                    End If
                End If
                FormSalesOrderSvcLevel.GVSalesDelOrder.ActiveFilterString = ""
                FormSalesOrderSvcLevel.GCSalesDelOrder.DataSource = Nothing
                FormSalesOrderSvcLevel.GCSalesOrder.DataSource = Nothing
                'FormSalesOrderSvcLevel.viewDO()
                'FormSalesOrderSvcLevel.viewSalesOrder()
                Close()
            ElseIf id_pop_up = "3" Then
                Dim check_stt As Boolean = False
                For c As Integer = 0 To ((FormSalesOrderSvcLevel.GVSalesReturn.RowCount - 1) - GetGroupRowCount(FormSalesOrderSvcLevel.GVSalesReturn))
                    Dim rs As String = FormSalesOrderSvcLevel.GVSalesReturn.GetRowCellValue(c, "id_report_status").ToString
                    If rs = "5" Or rs = "6" Then
                        check_stt = True
                        Exit For
                    End If
                Next

                If check_stt Then
                    stopCustom("Can't update status because data is already locked.")
                    FormSalesOrderSvcLevel.GVSalesReturn.ActiveFilterString = ""
                    Close()
                Else
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to set " + SLEStatusRec.Text.ToLower.ToString + " status for these data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        BtnUpdateRec.Enabled = False
                        For i As Integer = 0 To ((FormSalesOrderSvcLevel.GVSalesReturn.RowCount - 1) - GetGroupRowCount(FormSalesOrderSvcLevel.GVSalesReturn))
                            Dim id_so As String = FormSalesOrderSvcLevel.GVSalesReturn.GetRowCellValue(i, "id_sales_order").ToString
                            report_mark_type = FormSalesOrderSvcLevel.GVSalesReturn.GetRowCellValue(i, "rmt").ToString
                            Dim stt As ClassSalesReturn = New ClassSalesReturn()
                            If id_so = "0" Then
                                stt.changeStatus(FormSalesOrderSvcLevel.GVSalesReturn.GetRowCellValue(i, "id_sales_return").ToString, SLEStatusRec.EditValue.ToString)
                            Else
                                stt.changeStatusOLStore(FormSalesOrderSvcLevel.GVSalesReturn.GetRowCellValue(i, "id_sales_return").ToString, SLEStatusRec.EditValue.ToString)
                            End If
                            removeAppList(report_mark_type, FormSalesOrderSvcLevel.GVSalesReturn.GetRowCellValue(i, "id_sales_return").ToString, id_status_reportx)
                            insertFinalComment(report_mark_type, FormSalesOrderSvcLevel.GVSalesReturn.GetRowCellValue(i, "id_sales_return").ToString, id_status_reportx, note)
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        Cursor = Cursors.Default
                    End If
                End If
                FormSalesOrderSvcLevel.GVSalesReturn.ActiveFilterString = ""
                FormSalesOrderSvcLevel.viewReturn()
                Close()
            ElseIf id_pop_up = "4" Then
                Dim check_stt As Boolean = False
                For c As Integer = 0 To ((FormSalesOrderSvcLevel.GVSalesReturnQC.RowCount - 1) - GetGroupRowCount(FormSalesOrderSvcLevel.GVSalesReturnQC))
                    Dim rs As String = FormSalesOrderSvcLevel.GVSalesReturnQC.GetRowCellValue(c, "id_report_status").ToString
                    If rs = "5" Or rs = "6" Then
                        check_stt = True
                        Exit For
                    End If
                Next

                If check_stt Then
                    stopCustom("Can't update status because data is already locked.")
                    FormSalesOrderSvcLevel.GVSalesReturnQC.ActiveFilterString = ""
                    Close()
                Else
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to set " + SLEStatusRec.Text.ToLower.ToString + " status for these data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        BtnUpdateRec.Enabled = False
                        For i As Integer = 0 To ((FormSalesOrderSvcLevel.GVSalesReturnQC.RowCount - 1) - GetGroupRowCount(FormSalesOrderSvcLevel.GVSalesReturnQC))
                            Dim stt As ClassSalesReturnQC = New ClassSalesReturnQC()
                            stt.changeStatus(FormSalesOrderSvcLevel.GVSalesReturnQC.GetRowCellValue(i, "id_sales_return_qc").ToString, SLEStatusRec.EditValue.ToString)
                            removeAppList(FormSalesOrderSvcLevel.GVSalesReturnQC.GetRowCellValue(i, "rmk").ToString, FormSalesOrderSvcLevel.GVSalesReturnQC.GetRowCellValue(i, "id_sales_return_qc").ToString, id_status_reportx)
                            insertFinalComment(report_mark_type, FormSalesOrderSvcLevel.GVSalesReturnQC.GetRowCellValue(i, "id_sales_return_qc").ToString, id_status_reportx, note)
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        Cursor = Cursors.Default
                    End If
                End If
                FormSalesOrderSvcLevel.GVSalesReturnQC.ActiveFilterString = ""
                FormSalesOrderSvcLevel.viewReturnQC()
                Close()
            ElseIf id_pop_up = "5" Then
                Dim check_stt As Boolean = False
                For c As Integer = 0 To ((FormSalesOrderSvcLevel.GVFGTrf.RowCount - 1) - GetGroupRowCount(FormSalesOrderSvcLevel.GVFGTrf))
                    Dim rs As String = FormSalesOrderSvcLevel.GVFGTrf.GetRowCellValue(c, "id_report_status").ToString
                    If rs = "5" Or rs = "6" Then
                        check_stt = True
                        Exit For
                    End If
                Next

                If check_stt Then
                    stopCustom("Can't update status because data is already locked.")
                    FormSalesOrderSvcLevel.GVFGTrf.ActiveFilterString = ""
                    Close()
                Else
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to set " + SLEStatusRec.Text.ToLower.ToString + " status for these data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        BtnUpdateRec.Enabled = False
                        Dim type_restock As String = FormSalesOrderSvcLevel.LETypeRestock.EditValue.ToString
                        If type_restock = "1" Then
                            'reguler
                            For i As Integer = 0 To ((FormSalesOrderSvcLevel.GVFGTrf.RowCount - 1) - GetGroupRowCount(FormSalesOrderSvcLevel.GVFGTrf))
                                Dim stt As ClassFGTrf = New ClassFGTrf()
                                stt.changeStatus(FormSalesOrderSvcLevel.GVFGTrf.GetRowCellValue(i, "id_fg_trf").ToString, SLEStatusRec.EditValue.ToString)
                                removeAppList(report_mark_type, FormSalesOrderSvcLevel.GVFGTrf.GetRowCellValue(i, "id_fg_trf").ToString, id_status_reportx)
                                insertFinalComment(report_mark_type, FormSalesOrderSvcLevel.GVFGTrf.GetRowCellValue(i, "id_fg_trf").ToString, id_status_reportx, note)
                                PBC.PerformStep()
                                PBC.Update()
                            Next
                        ElseIf type_restock = "2" Then
                            'oos
                            Dim is_processed_order As String = get_setup_field("is_processed_order")
                            If is_processed_order = "1" Then
                                stopCustom("Sync still running")
                                Cursor = Cursors.Default
                            Else
                                If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                                    FormMain.SplashScreenManager1.ShowWaitForm()
                                End If
                                Dim ord As New ClassSalesOrder()
                                ord.setProceccedWebOrder("1")
                                For i As Integer = 0 To ((FormSalesOrderSvcLevel.GVFGTrf.RowCount - 1) - GetGroupRowCount(FormSalesOrderSvcLevel.GVFGTrf))
                                    FormMain.SplashScreenManager1.SetWaitFormDescription("Processing " + (i + 1).ToString + " of " + FormSalesOrderSvcLevel.GVFGTrf.RowCount.ToString)
                                    Dim stt As ClassFGTrf = New ClassFGTrf()
                                    stt.changeStatus(FormSalesOrderSvcLevel.GVFGTrf.GetRowCellValue(i, "id_fg_trf").ToString, SLEStatusRec.EditValue.ToString)
                                    stt.processRestockOnline(FormSalesOrderSvcLevel.GVFGTrf.GetRowCellValue(i, "id_fg_trf").ToString)
                                    removeAppList(report_mark_type, FormSalesOrderSvcLevel.GVFGTrf.GetRowCellValue(i, "id_fg_trf").ToString, id_status_reportx)
                                    insertFinalComment(report_mark_type, FormSalesOrderSvcLevel.GVFGTrf.GetRowCellValue(i, "id_fg_trf").ToString, id_status_reportx, note)
                                    PBC.PerformStep()
                                    PBC.Update()
                                Next
                                ord.setProceccedWebOrder("2")
                                FormMain.SplashScreenManager1.CloseWaitForm()
                            End If
                        End If
                        Cursor = Cursors.Default
                    End If
                End If
                FormSalesOrderSvcLevel.GVFGTrf.ActiveFilterString = ""
                FormSalesOrderSvcLevel.viewTrf()
                FormSalesOrderSvcLevel.viewSalesOrder()
                Close()
            ElseIf id_pop_up = "6" Then
                Dim check_stt As Boolean = False
                For c As Integer = 0 To ((FormSalesOrderSvcLevel.GVNonStock.RowCount - 1) - GetGroupRowCount(FormSalesOrderSvcLevel.GVNonStock))
                    Dim rs As String = FormSalesOrderSvcLevel.GVNonStock.GetRowCellValue(c, "id_report_status").ToString
                    If rs = "5" Or rs = "6" Then
                        check_stt = True
                        Exit For
                    End If
                Next

                If check_stt Then
                    stopCustom("Can't update status because data is already locked.")
                    FormSalesOrderSvcLevel.GVNonStock.ActiveFilterString = ""
                    Close()
                Else
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to set " + SLEStatusRec.Text.ToLower.ToString + " status for these data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        BtnUpdateRec.Enabled = False
                        For i As Integer = 0 To ((FormSalesOrderSvcLevel.GVNonStock.RowCount - 1) - GetGroupRowCount(FormSalesOrderSvcLevel.GVNonStock))
                            Dim stt As ClassDelEmpty = New ClassDelEmpty()
                            stt.changeStatus(FormSalesOrderSvcLevel.GVNonStock.GetRowCellValue(i, "id_wh_del_empty").ToString, SLEStatusRec.EditValue.ToString)
                            removeAppList(report_mark_type, FormSalesOrderSvcLevel.GVNonStock.GetRowCellValue(i, "id_wh_del_empty").ToString, id_status_reportx)
                            insertFinalComment(report_mark_type, FormSalesOrderSvcLevel.GVNonStock.GetRowCellValue(i, "id_wh_del_empty").ToString, id_status_reportx, note)
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        Cursor = Cursors.Default
                    End If
                End If
                FormSalesOrderSvcLevel.GVNonStock.ActiveFilterString = ""
                FormSalesOrderSvcLevel.viewNonStock()
                Close()
            End If
        Else
            stopCustom("Unable change to this status, report doesn't meet requirement to this status.")
        End If
    End Sub

    Private Sub FormChangeStatus_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub insertFinalComment(ByVal rmt As String, ByVal id_report As String, ByVal id_report_status As String, ByVal comment As String)
        Dim query As String = "INSERT INTO tb_report_mark_final_comment(report_mark_type, id_report, id_report_status, id_user, final_comment, final_comment_date, ip_user) VALUES "
        query += "('" + rmt + "', '" + id_report + "', '" + id_report_status + "', '" + id_user + "', '" + comment + "', NOW(), '" + GetIPv4Address() + "') "
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Private Sub insertFinalCommentCombine(ByVal rmt As String, ByVal id_report As String, ByVal id_report_status As String, ByVal comment As String)
        'head 
        Dim query As String = "INSERT INTO tb_report_mark_final_comment(report_mark_type, id_report, id_report_status, id_user, final_comment, final_comment_date, ip_user) 
        SELECT '" + rmt + "', '" + id_report + "', '" + id_report_status + "', '" + id_user + "', '" + comment + "', NOW(), '" + GetIPv4Address() + "'
        UNION ALL
        SELECT '43',del.id_pl_sales_order_del,  '" + id_report_status + "', '" + id_user + "',  '" + comment + "', NOW() , '" + GetIPv4Address() + "'
        FROM tb_pl_sales_order_del del WHERE del.id_combine=" + id_report + " "
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Private Function GetIPv4Address() As String
        GetIPv4Address = String.Empty
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim iphe As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(strHostName)

        For Each ipheal As System.Net.IPAddress In iphe.AddressList
            If ipheal.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                GetIPv4Address = ipheal.ToString()
            End If
        Next

    End Function

    Private Sub removeAppList(ByVal report_mark_type As String, ByVal id_report As String, ByVal id_status_reportx As String)
        If SLEStatusRec.EditValue.ToString = "5" Then
            Dim query As String = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", report_mark_type, id_report, id_status_reportx)
            execute_non_query(query, True, "", "", "", "")
        End If
    End Sub

    Private Sub removeAppListCombine(ByVal report_mark_type As String, ByVal id_report As String, ByVal id_status_reportx As String)
        If SLEStatusRec.EditValue.ToString = "5" Then
            'head
            Dim query As String = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", report_mark_type, id_report, id_status_reportx)
            execute_non_query(query, True, "", "", "", "")

            'single
            Dim query_single As String = "UPDATE tb_report_mark rm 
                                         INNER JOIN (
                                            SELECT del.id_pl_sales_order_del FROM tb_pl_sales_order_del del WHERE del.id_combine=" + id_report + "
                                         ) src ON src.id_pl_sales_order_del = rm.id_report
                                         SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL 
                                         WHERE rm.report_mark_type='43' AND rm.id_report_status>'1' "
            execute_non_query(query_single, True, "", "", "", "")
        End If
    End Sub

    Sub sendEmailConfirmation(ByVal id_commerce_type As String, ByVal id_report As String)
        If id_pop_up = "2" Then
            If id_commerce_type = "2" And SLEStatusRec.EditValue.ToString = "6" Then
                'only online store
                Dim query As String = "SELECT del.id_pl_sales_order_del, del.pl_sales_order_del_number AS `del_number`, 
                DATE_FORMAT(del.pl_sales_order_del_date, '%d %M %Y') AS `scan_date`, DATE_FORMAT(fcom.final_comment_date,'%d %M %Y %H:%i') AS `del_date`,
                so.sales_order_number AS `order_number`, so.sales_order_ol_shop_number AS `ol_store_order_number`, DATE_FORMAT(so.sales_order_date,'%d %M %Y') AS `order_date`, so.customer_name,
                CONCAT(s.comp_number, ' - ', s.comp_name) AS `store`, sg.comp_group AS `store_group_code`, sg.description AS `store_group`
                FROM tb_pl_sales_order_del del 
                INNER JOIN tb_m_comp_contact sc ON sc.id_comp_contact = del.id_store_contact_to
                INNER JOIN tb_m_comp s ON s.id_comp = sc.id_comp
                INNER JOIN tb_m_comp_group sg ON sg.id_comp_group = s.id_comp_group
                INNER JOIN tb_report_mark_final_comment fcom ON fcom.id_report = del.id_pl_sales_order_del AND fcom.report_mark_type=43
                INNER JOIN tb_sales_order so ON so.id_sales_order = del.id_sales_order
                WHERE del.id_pl_sales_order_del='" + id_report + "' "
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                If data.Rows.Count > 0 Then
                    Try
                        Dim em As New ClassSendEmail
                        em.report_mark_type = "43_confirm"
                        em.id_report = id_report
                        em.dt = data
                        em.send_email()
                    Catch ex As Exception
                        Dim qerr As String = "INSERT INTO tb_error_mail(date,description, note_penyelesaian) VALUES(NOW(), 'Failed send delivery confirmation; id del:" + id_report + "; error:" + addSlashes(ex.ToString) + "', ''); "
                        execute_non_query(qerr, True, "", "", "", "")
                    End Try
                End If
            End If
        End If
    End Sub

    Sub sendEmailConfirmationforConceptStore(ByVal is_use_unique_code As String, ByVal id_report As String, ByVal rmt As String)
        'sementara belum dipake
        'If id_pop_up = "2" Then
        '    If is_use_unique_code = "1" And SLEStatusRec.EditValue.ToString = "6" Then
        '        Dim d As New ClassSalesDelOrder()
        '        d.sendDeliveryConfirmationOfflineStore(id_report, rmt)
        '    End If
        'End If
    End Sub

    Sub updateStatusOnlineStore(ByVal id_commerce_type As String, ByVal id_store As String, ByVal id_report As String, ByVal id_web_order As String)
        If id_pop_up = "2" And id_commerce_type = "2" And (id_store = id_volcomstore_normal Or id_store = id_volcomstore_sale) Then
            Dim so As New ClassSalesOrder
            Dim shopify_comp_group As String = get_setup_field("shopify_comp_group")
            Try
                Dim shopify_tracking_comp As String = get_setup_field("shopify_tracking_comp")
                Dim shopify_tracking_url As String = get_setup_field("shopify_tracking_url")
                Dim track_number As String = execute_query("SELECT m.awbill_no FROM tb_wh_awbill_det d INNER JOIN tb_wh_awbill m ON m.id_awbill = d.id_awbill WHERE d.id_pl_sales_order_del=" + id_report + "", 0, True, "", "", "", "")
                Dim query As String = "SELECT sod.ol_store_id, CAST(SUM(sod.sales_order_det_qty) AS DECIMAL(10,0)) AS `qty`, so.id_sales_order_ol_shop AS `id_web_order`, o.shopify_location_id AS `location_id`
                FROM tb_pl_sales_order_del_det d
                INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = d.id_sales_order_det
                INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
                JOIN tb_opt o 
                WHERE d.id_pl_sales_order_del=" + id_report + " AND sod.is_additional=2
                GROUP BY sod.ol_store_id "
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                Dim val As String = ""
                Dim location_id As String = ""
                For i As Integer = 0 To data.Rows.Count - 1
                    location_id = data.Rows(i)("location_id").ToString
                    If i > 0 Then
                        val += ","
                    End If
                    val += "{
        ""id"": " + data.Rows(i)("ol_store_id").ToString + ",
""quantity"": " + data.Rows(i)("qty").ToString + "
      }"
                Next
                If val <> "" Then
                    Dim shop As New ClassShopifyApi()
                    shop.set_fullfill(id_web_order, location_id, track_number, val, shopify_tracking_comp, shopify_tracking_url)
                End If
            Catch ex As Exception
                so.insertLogWebOrder(id_web_order, "ID DEL:" + id_report + "; Error Set Fullfillment:" + ex.ToString, shopify_comp_group)
            End Try

            Try
                'insert status 
                Dim qstt As String = "INSERT IGNORE INTO tb_sales_order_det_status(id_sales_order_det, `status`, status_date, input_status_date)
                SELECT sod.id_sales_order_det, 'shipped', NOW(), NOW()
                FROM tb_pl_sales_order_del_det d
                INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = d.id_sales_order_det
                INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
                JOIN tb_opt o 
                WHERE d.id_pl_sales_order_del=" + id_report + " AND sod.is_additional=2 "
                execute_non_query(qstt, True, "", "", "", "")
            Catch ex As Exception
                so.insertLogWebOrder(id_web_order, "ID DEL:" + id_report + "; Error Set Status:" + ex.ToString, shopify_comp_group)
            End Try
        End If
    End Sub
End Class