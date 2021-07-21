﻿Public Class FormSNISerahTerimaDet
    Public id As String = "-1"
    Dim id_pps As String = "-1"

    Private Sub FormSNISerahTerimaDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_head()
    End Sub

    Sub load_head()
        If Not id = "-1" Then
            'edit
            Dim q As String = "SELECT rec.*,emp.`employee_name`,pps.`number` AS pps_number
FROM tb_sni_rec rec
INNER JOIN tb_m_user usr ON usr.`id_user`=rec.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_sni_pps pps ON pps.`id_sni_pps`=rec.`id_sni_pps`
WHERE rec.id_sni_rec='" & id & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                TEBudgetNumber.Text = dt.Rows(0)("pps_number").ToString
                TEBudgetNumber.Properties.ReadOnly = True
                BLoad.Visible = False
                BDel.Visible = False
                '
                DEProposeDate.EditValue = dt.Rows(0)("created_date").ToString
                TECreatedBy.Text = dt.Rows(0)("employee_name").ToString
                TENumber.Text = dt.Rows(0)("number").ToString
                '
                GridColumnAttachment.Visible = True

                load_det()
            End If
        End If
    End Sub

    Sub load_det()
        Dim q As String = "SELECT 'yes' AS is_attach,recd.id_sni_rec_det,recd.`id_product`,p.`product_full_code`,recd.`qty` AS qty,dsg.`design_display_name`,cd.`display_name` AS size
FROM `tb_sni_rec_det` recd
INNER JOIN tb_m_product p ON p.`id_product`=recd.`id_product`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=p.`id_design`
INNER JOIN tb_m_code_detail cd ON cd.code=p.`product_code` AND cd.`id_code`=33
WHERE recd.id_sni_rec='" & id & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCList.DataSource = dt
        GVList.BestFitColumns()
    End Sub

    Private Sub FormSNISerahTerimaDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BLoad_Click(sender As Object, e As EventArgs) Handles BLoad.Click
        If Not TEBudgetNumber.Text = "" Then
            Dim q As String = "SELECT pps.id_sni_pps,pb.`id_product`,p.`product_full_code`,pb.`budget_qty` AS qty,dsg.`design_display_name`,cd.`display_name` AS size
FROM `tb_sni_pps_budget` pb
INNER JOIN tb_sni_pps pps ON pps.id_sni_pps=pb.id_sni_pps
INNER JOIN tb_m_product p ON p.`id_product`=pb.`id_product`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=p.`id_design`
INNER JOIN tb_m_code_detail cd ON cd.code=p.`product_code` AND cd.`id_code`=33
WHERE NOT ISNULL(pb.id_product) AND pps.number='" & addSlashes(TEBudgetNumber.Text) & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            GCList.DataSource = dt

            If dt.Rows.Count > 0 Then
                TEBudgetNumber.Properties.ReadOnly = True
                '
                id_pps = dt.Rows(0)("id_sni_pps").ToString
            Else
                warningCustom("Budget number not found or already used.")
                id_pps = "-1"
                TEBudgetNumber.Properties.ReadOnly = False
            End If
        End If
    End Sub

    Private Sub BDel_Click(sender As Object, e As EventArgs) Handles BDel.Click
        If GVList.RowCount > 0 Then
            GVList.DeleteSelectedRows()
        End If
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        If GVList.RowCount > 0 And Not id_pps = "-1" Then
            If id = "-1" Then
                Dim q As String = "INSERT INTO tb_sni_rec(id_sni_pps,created_by,created_date,id_report_status)
VALUES('" & id_pps & "','" & id_user & "',NOW(),'1'); SELECT LAST_INSERT_ID();"
                id = execute_query(q, 0, True, "", "", "", "")
                '
                q = "CALL gen_number('" & id & "','325')"
                execute_non_query(q, True, "", "", "", "")
                '
                q = "INSERT INTO tb_sni_rec_det(id_sni_rec,id_product,qty) VALUES"
                For i As Integer = 0 To GVList.RowCount - 1
                    If Not i = 0 Then
                        q += ","
                    End If
                    q += "('" & id & "','" & GVList.GetRowCellValue(i, "id_product").ToString & "','" & GVList.GetRowCellValue(i, "qty").ToString & "')"
                Next
                execute_non_query(q, True, "", "", "", "")
            Else
                'no edit
            End If
        Else
            warningCustom("Please input SNI proposal number")
        End If
    End Sub

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub
End Class