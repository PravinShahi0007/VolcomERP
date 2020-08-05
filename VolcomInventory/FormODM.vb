Public Class FormODM
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        Dim q As String = "SELECT *
FROM (
SELECT 0 AS NO, mdet.id_wh_awb_det, md.number, md.id_del_manifest,
c.id_comp_group, a.awbill_no, a.awbill_date, a.id_awbill, IFNULL(pdelc.combine_number, adet.do_no) AS combine_number, adet.do_no, pdel.pl_sales_order_del_number, c.comp_number, c.comp_name, CONCAT((ROUND(IF(pdelc.combine_number IS NULL, adet.qty, z.qty), 0)), ' ') AS qty, ct.city, a.weight, a.width, a.length, a.height, ((a.width * a.length * a.height) / 6000) AS volume, a.c_weight
FROM tb_del_manifest_det AS mdet
INNER JOIN tb_del_manifest md ON md.`id_del_manifest`=mdet.`id_del_manifest` AND ISNULL(md.`id_report_status`)
LEFT JOIN tb_wh_awbill_det AS adet ON mdet.id_wh_awb_det = adet.id_wh_awb_det
LEFT JOIN tb_wh_awbill AS a ON adet.id_awbill = a.id_awbill
LEFT JOIN tb_m_comp AS c ON a.id_store = c.id_comp
LEFT JOIN tb_m_city AS ct ON c.id_city = ct.id_city
LEFT JOIN tb_pl_sales_order_del AS pdel ON adet.id_pl_sales_order_del = pdel.id_pl_sales_order_del
LEFT JOIN tb_pl_sales_order_del_combine AS pdelc ON pdel.id_combine = pdelc.id_combine
LEFT JOIN (
	SELECT z3.combine_number, SUM(pl_sales_order_del_det_qty) AS qty
	FROM tb_pl_sales_order_del_det AS z1
	LEFT JOIN tb_pl_sales_order_del AS z2 ON z1.id_pl_sales_order_del = z2.id_pl_sales_order_del
	LEFT JOIN tb_pl_sales_order_del_combine AS z3 ON z2.id_combine = z3.id_combine
	GROUP BY z2.id_combine
) AS z ON pdelc.combine_number = z.combine_number
WHERE md.id_comp = " + SLUE3PL.EditValue.ToString + " 
) AS tb
ORDER BY tb.comp_number ASC, tb.id_awbill ASC, tb.combine_number ASC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCList.DataSource = dt
        GVList.BestFitColumns()
        '
        If Not GVList.RowCount > 0 Then
            warningCustom("No manifest found for this 3PL, please choose different 3PL")
        Else
            SLUE3PL.Properties.ReadOnly = True
            BView.Visible = False
            TEScan.Focus()
        End If
    End Sub

    Private Sub FormODM_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormODM_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormODM_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormODM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_3pl()
    End Sub

    Sub view_3pl()
        Dim query As String = "(SELECT id_comp, comp_name AS comp_name FROM tb_m_comp WHERE id_comp_cat = 7)"

        viewSearchLookupQuery(SLUE3PL, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub GVList_CellMerge(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs) Handles GVList.CellMerge
        Try
            Console.WriteLine(GVList.GetRowCellValue(e.RowHandle1, "id_awbill").ToString & " : " & GVList.GetRowCellValue(e.RowHandle2, "id_awbill").ToString)
            Console.WriteLine(e.CellValue1.ToString & " : " & e.CellValue2.ToString)
        Catch ex As Exception

        End Try

        Console.WriteLine("===========================")

        If GVList.GetRowCellValue(e.RowHandle1, "id_awbill").ToString = GVList.GetRowCellValue(e.RowHandle2, "id_awbill").ToString Then
            e.Merge = True
            e.Handled = True
        Else
            e.Merge = False
            e.Handled = True
        End If
    End Sub

    Private Sub TEScan_KeyUp(sender As Object, e As KeyEventArgs) Handles TEScan.KeyUp

    End Sub

    Private Sub BReset_Click(sender As Object, e As EventArgs) Handles BReset.Click

    End Sub
End Class