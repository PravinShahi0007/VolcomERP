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

    Function dtLoadDetail(ByVal id_sales_pos_par As String)
        Dim dt As New DataTable
        If rmt = "225" Then
            Dim qdet As String = "SELECT '' AS `no`, sp.id_sales_pos, sp.sales_pos_number,
            CONCAT(c.comp_number, ' - ', c.comp_name) AS `store`, g.description AS `group_store`,
            cg.comp_name AS `group_company`, prd.period,
            sp.sales_pos_total_qty AS `qty_invoice`, 
            CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2)) AS `amount`,
            prd.amount AS `total_amount`,
            prd.total_qty AS `total_qty`,
            sp.report_mark_type
            FROM tb_sales_pos sp 
            INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
            INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
            INNER JOIN tb_m_comp_group g ON g.id_comp_group = c.id_comp_group
            INNER JOIN tb_m_comp cg ON cg.id_comp = g.id_comp
            INNER JOIN (
	            SELECT c.id_comp_group,
	            GROUP_CONCAT(DISTINCT CONCAT(DATE_FORMAT(sp.sales_pos_start_period,'%d %M %Y'),' s/d ', DATE_FORMAT(sp.sales_pos_end_period,'%d %M %Y')) ORDER BY sp.id_sales_pos ASC SEPARATOR ', ') AS `period`,
	            SUM(CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2))) AS `amount`,
                SUM(sp.sales_pos_total_qty) AS `total_qty`
	            FROM tb_sales_pos sp
	            INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
	            INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
	            INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
	            WHERE sp.id_sales_pos IN (" + id_sales_pos_par + ")
	            GROUP BY c.id_comp_group
            ) prd ON prd.id_comp_group = c.id_comp_group
            INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
            WHERE sp.id_sales_pos IN (" + id_sales_pos_par + ") "
            dt = execute_query(qdet, -1, True, "", "", "", "")
        End If
        Return dt
    End Function

    Sub columnDetail()
        If rmt = "225" Then
            'hide column
            GVDetail.Columns("id_sales_pos").Visible = False
            GVDetail.Columns("period").Visible = False
            GVDetail.Columns("total_amount").Visible = False
            GVDetail.Columns("total_qty").Visible = False
            GVDetail.Columns("report_mark_type").Visible = False
            'caption
            GVDetail.Columns("no").Caption = "No"
            GVDetail.Columns("sales_pos_number").Caption = "Invoice Number"
            GVDetail.Columns("store").Caption = "Store"
            GVDetail.Columns("group_store").Caption = "Store Group"
            GVDetail.Columns("group_company").Caption = "Company"
            GVDetail.Columns("qty_invoice").Caption = "Qty"
            GVDetail.Columns("amount").Caption = "Amount"
            'display format
            GVDetail.Columns("qty_invoice").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVDetail.Columns("qty_invoice").DisplayFormat.FormatString = "{0:N0}"
            GVDetail.Columns("amount").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVDetail.Columns("amount").DisplayFormat.FormatString = "{0:N2}"
            'summary
            GVDetail.Columns("qty_invoice").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVDetail.Columns("qty_invoice").SummaryItem.DisplayFormat = "{0:n0}"
            GVDetail.Columns("amount").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GVDetail.Columns("amount").SummaryItem.DisplayFormat = "{0:n2}"
            'bestfit
            GVDetail.BestFitColumns()
        End If
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        If action = "ins" Then
            TxtEmailNumber.Text = "[auto_generated]"
            TxtMailStatus.Text = "New Email"

            If rmt = "225" Then
                '-- mail type
                TxtMailType.Text = execute_query("SELECT report_mark_type_name FROM tb_lookup_report_mark_type WHERE report_mark_type='225'", 0, True, "", "", "", "")

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
                Dim ddet As DataTable = dtLoadDetail(id_sales_pos)
                GCDetail.DataSource = ddet
                columnDetail()


                '-- load 'from/to/cc & html preview
                GVMember.ActiveFilterString = ""
                For j As Integer = 0 To ((GVMember.RowCount - 1) - GetGroupRowCount(GVMember))
                    Dim id_mail_member_type As String = GVMember.GetRowCellValue(j, "id_mail_member_type").ToString
                    Dim mail_address As String = GVMember.GetRowCellValue(j, "mail_address").ToString

                    If id_mail_member_type = "1" Then
                        MEFrom.Text += mail_address + "; "
                    ElseIf id_mail_member_type = "2" Then
                        METo.Text += mail_address + "; "
                    Else
                        MECC.Text += mail_address + "; "
                    End If
                Next
                MESubject.Text = addSlashes("Invoice Penjualan Per " + ddet.Rows(0)("period").ToString)
                Dim m As New ClassSendEmail()
                Dim html As String = m.email_body_invoice_penjualan(ddet)
                WebBrowser1.DocumentText = html
            End If
        ElseIf action = "upd" Then
            BtnCancel.Visible = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDetail_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnSend_Click(sender As Object, e As EventArgs) Handles BtnSend.Click

    End Sub

    Private Sub BtnDraft_Click(sender As Object, e As EventArgs) Handles BtnDraft.Click

    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click

    End Sub

    Sub save(ByVal id_status_par As String, ByVal note_par As String)
        Cursor = Cursors.WaitCursor
        GVMember.ActiveFilterString = ""
        GVDetail.ActiveFilterString = ""
        Dim mail_subject As String = addSlashes(MESubject.Text)
        If action = "ins" Then
            'head
            Dim query As String = "INSERT INTO tb_mail_manage(number, created_date, created_by, updated_date, updated_by, report_mark_type, id_mail_status, mail_status_note, mail_subject) VALUES
            ('', NOW(), '" + id_user + "', NOW(), '" + id_user + "', '" + rmt + "', '" + id_status_par + "', '" + note_par + "', '" + mail_subject + "'); SELECT LAST_INSERT_ID(); "
            Dim id As String = execute_query(query, 0, True, "", "", "", "")
            execute_non_query("CALL gen_number(" + id + ", " + rmt + ")", True, "", "", "", "")

            'detil
            If GVMember.RowCount > 0 Then
                Dim query_member As String = "INSERT INTO tb_mail_manage_member(id_mail_manage, id_mail_member_type, id_user, id_comp_group, mail_address) VALUES "
                For i As Integer = 0 To ((GVMember.RowCount - 1) - (GetGroupRowCount(GVMember)))

                    If i > 0 Then
                        query_member += ", "
                    End If
                    query_member += "() "
                Next
            End If


        Else

        End If
        Cursor = Cursors.Default
    End Sub
End Class