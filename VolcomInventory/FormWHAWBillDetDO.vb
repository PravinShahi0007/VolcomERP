Public Class FormWHAWBillDetDO
    Public store_number As String = "-1"
    Private Sub FormWHAWBillDetDO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_do()

        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEFrom.EditValue = data_dt.Rows(0)("dt")
        DEUntil.EditValue = data_dt.Rows(0)("dt")
    End Sub
    Sub view_do()
        Cursor = Cursors.WaitCursor
        Dim query As String = ""

        query = "SELECT awbdo.*,awb.awbill_no,awb.awbill_inv_no,'no' AS is_check FROM tb_wh_awb_do awbdo 
        LEFT JOIN tb_wh_awbill_det det ON awbdo.do_no=det.do_no 
        LEFT JOIN tb_wh_awbill awb ON awb.id_awbill=det.id_awbill 
        WHERE store_number='" & store_number.ToString & "' AND ISNULL(awb.id_awbill)"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        Dim data_par As DataTable = FormWHAWBillDet.GCDO.DataSource

        If data_par.Rows.Count = 0 Then
            GCDO.DataSource = data
        Else
            If data.Rows.Count > 0 Then
                Dim t1 = data.AsEnumerable()
                Dim t2 = data_par.AsEnumerable()
                Dim result = From _t1 In t1
                             Group Join _t2 In t2
                                            On _t1("do_no") Equals _t2("do_no") Into Group
                             From _t3 In Group.DefaultIfEmpty()
                             Where _t3 Is Nothing
                             Select _t1
                If result.Count > 0 Then
                    Dim except As DataTable = result.CopyToDataTable
                    GCDO.DataSource = except
                Else
                    GCDO.DataSource = Nothing
                End If
            Else
                GCDO.DataSource = Nothing
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Sub viewDOERP()
        Cursor = Cursors.WaitCursor
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query As String = "SELECT d.id_pl_sales_order_del, d.pl_sales_order_del_number AS `do_no`, d.pl_sales_order_del_date AS `scan_date`, 
        c.comp_number AS `store_number`, c.comp_name AS `store_name`, SUM(dd.pl_sales_order_del_det_qty) AS `qty`, 'no' AS `is_check`
        FROM tb_pl_sales_order_del d
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = d.id_store_contact_to
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        LEFT JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del = d.id_pl_sales_order_del
        LEFT JOIN tb_wh_awbill_det awb ON awb.id_pl_sales_order_del = d.id_pl_sales_order_del
        WHERE d.id_report_status=6 AND c.comp_number='" + addSlashes(store_number.ToString) + "' AND ISNULL(awb.id_awbill) 
        AND (d.pl_sales_order_del_date>='" + date_from_selected + "' AND d.pl_sales_order_del_date<='" + date_until_selected + "')
        GROUP BY d.id_pl_sales_order_del "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        Dim data_par As DataTable = FormWHAWBillDet.GCDO.DataSource
        If data_par.Rows.Count = 0 Then
            GCDOERP.DataSource = data
        Else
            If data.Rows.Count > 0 Then
                Dim t1 = data.AsEnumerable()
                Dim t2 = data_par.AsEnumerable()
                Dim result = From _t1 In t1
                             Group Join _t2 In t2
                                            On _t1("do_no") Equals _t2("do_no") Into Group
                             From _t3 In Group.DefaultIfEmpty()
                             Where _t3 Is Nothing
                             Select _t1
                If result.Count > 0 Then
                    Dim except As DataTable = result.CopyToDataTable
                    GCDOERP.DataSource = except
                Else
                    GCDOERP.DataSource = Nothing
                End If
            Else
                GCDOERP.DataSource = Nothing
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormWHAWBillDetDO_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BBrowse_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        Cursor = Cursors.WaitCursor
        If XTCDel.SelectedTabPageIndex = 0 Then
            If GVDO.RowCount > 0 Then
                GVDO.ActiveFilterString = "[is_check]='yes'"
                If GVDO.RowCount > 0 Then
                    For i As Integer = 0 To GVDO.RowCount - 1
                        Dim newRow As DataRow = (TryCast(FormWHAWBillDet.GCDO.DataSource, DataTable)).NewRow()
                        newRow("do_no") = GVDO.GetRowCellValue(i, "do_no").ToString
                        newRow("qty") = GVDO.GetRowCellValue(i, "qty").ToString

                        TryCast(FormWHAWBillDet.GCDO.DataSource, DataTable).Rows.Add(newRow)
                        FormWHAWBillDet.GCDO.RefreshDataSource()
                    Next
                End If
            End If
        Else
            If GVDOERP.RowCount > 0 Then
                GVDOERP.ActiveFilterString = "[is_check]='yes'"
                If GVDOERP.RowCount > 0 Then
                    For i As Integer = 0 To GVDOERP.RowCount - 1
                        Dim newRow As DataRow = (TryCast(FormWHAWBillDet.GCDO.DataSource, DataTable)).NewRow()
                        newRow("id_pl_sales_order_del") = GVDOERP.GetRowCellValue(i, "id_pl_sales_order_del").ToString
                        newRow("do_no") = GVDOERP.GetRowCellValue(i, "do_no").ToString
                        newRow("qty") = GVDOERP.GetRowCellValue(i, "qty")

                        TryCast(FormWHAWBillDet.GCDO.DataSource, DataTable).Rows.Add(newRow)
                        FormWHAWBillDet.GCDO.RefreshDataSource()
                    Next
                End If
            End If
        End If
        Close()
        Cursor = Cursors.Default
    End Sub

    Private Sub CheckEditSelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditSelAll.CheckedChanged
        If XTCDel.SelectedTabPageIndex = 0 Then
            If GVDO.RowCount > 0 Then
                Dim cek As String = CheckEditSelAll.EditValue.ToString
                For i As Integer = 0 To ((GVDO.RowCount - 1) - GetGroupRowCount(GVDO))
                    If cek Then
                        GVDO.SetRowCellValue(i, "is_check", "yes")
                    Else
                        GVDO.SetRowCellValue(i, "is_check", "no")
                    End If
                Next
            End If
        Else
            If GVDOERP.RowCount > 0 Then
                Dim cek As String = CheckEditSelAll.EditValue.ToString
                For i As Integer = 0 To ((GVDOERP.RowCount - 1) - GetGroupRowCount(GVDOERP))
                    If cek Then
                        GVDOERP.SetRowCellValue(i, "is_check", "yes")
                    Else
                        GVDOERP.SetRowCellValue(i, "is_check", "no")
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub XTCDel_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCDel.SelectedPageChanged
        If XTCDel.SelectedTabPageIndex = 1 Then
            DEFrom.Focus()
        End If
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewDOERP()
    End Sub

    Private Sub DEFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntil.Focus()
        End If
    End Sub

    Private Sub DEUntil_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntil.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnView.Focus()
        End If
    End Sub
End Class