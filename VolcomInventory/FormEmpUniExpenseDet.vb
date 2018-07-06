Public Class FormEmpUniExpenseDet
    Public id_emp_uni_ex As String = "-1"
    Public action As String = ""
    Dim id_pl_sales_order_del As String = "-1"
    Dim id_report_status As String = "-1"

    Private Sub FormEmpUniExpenseDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Private Sub FormEmpUniExpenseDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub


    'View Data
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            BtnPrint.Visible = False
            BtnAttachment.Visible = False
            BtnMark.Visible = False
            viewDetail()
        ElseIf action = "upd" Then
            BtnPrint.Visible = True
            BtnAttachment.Visible = True
            BtnMark.Visible = True
            Dim query_c As New ClassEmpUniExpense()
            Dim query As String = query_c.queryMain("AND e.id_emp_uni_ex=" + id_emp_uni_ex + "", "2")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TxtNumber.Text = data.Rows(0)("emp_uni_ex_number").ToString
            DECreated.EditValue = data.Rows(0)("created_date")
            MENote.Text = data.Rows(0)("memo_note").ToString
            id_pl_sales_order_del = data.Rows(0)("id_pl_sales_order_del").ToString
            TxtDel.Text = data.Rows(0)("pl_sales_order_del_number").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            viewDetail()
            'allow_status()
        End If
    End Sub

    Sub viewDetail()
        'Dim query As String = "SELECT md.id_prod_over_memo_det, md.id_prod_over_memo, md.id_prod_order, po.prod_order_number, d.design_code AS `code`, d.design_display_name AS `name`, md.remark, md.qty
        'FROM tb_prod_over_memo_det md
        'INNER JOIN tb_prod_order po ON po.id_prod_order = md.id_prod_order
        'INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
        'INNER JOIN tb_m_design d ON d.id_design = pdd.id_design
        'WHERE md.id_prod_over_memo=" + id_prod_over_memo + " "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'GCData.DataSource = data
    End Sub

End Class