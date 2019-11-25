Public Class FormMailManageDet
    Public rmt As String = "-1"
    Public action As String = "-1"
    Public id As String = "-1"

    Private Sub FormMailManageDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Private Sub FormMailManageDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            If rmt = "225" Then
                '--- load member
                Dim qf As String = "SELECT m.id_mail_manage_mapping_intern AS `index`,0 AS `id_mail_manage_member`,0 AS `id_mail_manage`,m.id_mail_member_type, mmt.mail_member_type,m.id_user,0 AS `id_comp_group`, 
                e.employee_name AS `description`,e.email_external AS `mail_address` 
                FROM tb_mail_manage_mapping_intern m
                INNER JOIN tb_lookup_mail_member_type mmt ON mmt.id_mail_member_type = m.id_mail_member_type
                INNER JOIN tb_m_user u ON u.id_user = m.id_user
                INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
                WHERE e.email_external!=''
                UNION
                SELECT m.id_mail_manage_mapping AS `index`,0 AS `id_mail_manage_member`,0 AS `id_mail_manage`,m.id_mail_member_type, mmt.mail_member_type, 0 AS `id_user`, m.id_comp_group,
                cc.contact_person AS `description`, cc.email AS `mail_address`
                FROM tb_mail_manage_mapping m
                INNER JOIN tb_lookup_mail_member_type mmt ON mmt.id_mail_member_type = m.id_mail_member_type
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = m.id_comp_contact
                WHERE cc.email!=''
                ORDER BY id_mail_member_type ASC, `index` ASC "
                Dim df As DataTable = execute_query(qf, -1, True, "", "", "", "")
                GCMember.DataSource = df
                GVMember.BestFitColumns()

                '--- load data
                Dim id_sales_pos As String = ""
                For i As Integer = 0 To (FormMailManage.GVInvoiceList.RowCount - 1)
                    If i > 0 Then
                        id_sales_pos += ","
                    End If
                    id_sales_pos += FormMailManage.GVInvoiceList.GetRowCellValue(i, "id_sales_pos").ToString
                Next
                Dim qdet As String = "SELECT cg.comp_name AS `group_company`, g.description AS `group_store`,sp.sales_pos_start_period, sp.sales_pos_end_period,prd.period, prd.amount AS `total_amount`,
                sp.id_sales_pos, sp.sales_pos_number, CONCAT(c.comp_number, ' - ', c.comp_name) AS `store`, sp.sales_pos_total_qty AS `qty_invoice`, 
                CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2)) AS `amount`
                FROM tb_sales_pos sp 
                INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
                INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
                INNER JOIN tb_m_comp_group g ON g.id_comp_group = c.id_comp_group
                INNER JOIN tb_m_comp cg ON cg.id_comp = g.id_comp
                INNER JOIN (
	                SELECT c.id_comp_group,
	                GROUP_CONCAT(DISTINCT CONCAT(DATE_FORMAT(sp.sales_pos_start_period,'%d %M %Y'),' s/d ', DATE_FORMAT(sp.sales_pos_end_period,'%d %M %Y')) ORDER BY sp.id_sales_pos ASC SEPARATOR ', ') AS `period`,
	                SUM(CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2))) AS `amount`
	                FROM tb_sales_pos sp
	                INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
	                INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
	                INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
	                WHERE sp.id_sales_pos IN (" + id_sales_pos + ")
	                GROUP BY c.id_comp_group
                ) prd ON prd.id_comp_group = c.id_comp_group
                INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
                WHERE sp.id_sales_pos IN (" + id_sales_pos + ") "
                Dim ddet As DataTable = execute_query(qdet, -1, True, "", "", "", "")
                GCDetail.DataSource = ddet
                GVDetail.BestFitColumns()
                'custom column



                'load html preview
                'Dim dt As DataTable = Nothing
                'Dim m As New ClassSendEmail()
                'Dim html As String = m.email_body_invoice_penjualan(dt)
                'WebBrowser1.DocumentText = html
            End If
        ElseIf action = "upd" Then

        End If
    End Sub

End Class