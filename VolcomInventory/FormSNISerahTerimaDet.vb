Public Class FormSNISerahTerimaDet
    Public id As String = "-1"
    Dim id_pps As String = "-1"
    Dim is_submit As String = "2"

    Public is_view As String = "-1"

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
                is_submit = dt.Rows(0)("is_submit").ToString
                id_pps = dt.Rows(0)("id_sni_pps").ToString
                '
                If is_submit = "1" Then
                    BMark.Visible = True
                    BSave.Visible = False
                Else
                    BMark.Visible = False
                    BSave.Text = "Lock and Submit"
                    BSave.Visible = True
                End If
                '
                load_det()
            End If
        Else
            DEReffDate.Properties.MaxValue = Now
            BSave.Text = "Save"
            GridColumnAttachment.Visible = False
        End If
    End Sub

    Sub load_det()
        Dim q As String = "SELECT 'yes' AS is_attach,po.prod_order_number,recd.id_sni_rec_det,recd.`id_product`,p.`product_full_code`,recd.`qty` AS qty,dsg.`design_display_name`,cd.`display_name` AS size
FROM `tb_sni_rec_det` recd
INNER JOIN tb_m_product p ON p.`id_product`=recd.`id_product`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=p.`id_design`
INNER JOIN tb_m_code_detail cd ON cd.code=p.`product_code` AND cd.`id_code`=33
INNER JOIN tb_prod_order_det pod ON pod.id_prod_order_det=recd.id_prod_order_det
INNER JOIN tb_prod_order po ON po.id_prod_order=pod.id_prod_order
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
            Dim q As String = "SELECT pps.id_sni_pps,pb.`id_product`,p.`product_full_code`,pb.`budget_qty` AS qty,dsg.`design_display_name`,cd.`display_name` AS size,po.id_prod_order_det,po.prod_order_number
FROM `tb_sni_pps_budget` pb
INNER JOIN tb_sni_pps pps ON pps.id_sni_pps=pb.id_sni_pps
INNER JOIN tb_m_product p ON p.`id_product`=pb.`id_product`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=p.`id_design`
INNER JOIN tb_m_code_detail cd ON cd.code=p.`product_code` AND cd.`id_code`=33
LEFT JOIN (
    SELECT pdp.id_product,po.prod_order_number,po.id_prod_order,pod.id_prod_order_det
    FROM tb_prod_demand_product pdp
    INNER JOIN tb_prod_order_det pod ON pod.id_prod_demand_product=pdp.id_prod_demand_product
    INNER JOIN tb_prod_order po ON po.id_prod_order=pod.id_prod_order AND po.is_void=2 AND po.id_report_status=6
)po ON po.id_product=pb.id_product
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
            'check PO
            Dim is_po_not_avail As Boolean = True
            For j As Integer = 0 To GVList.RowCount - 1
                If GVList.GetRowCellValue(j, "prod_order_number").ToString = "" Then
                    is_po_not_avail = False
                End If
            Next

            If Not is_po_not_avail Then
                warningCustom("No FGPO on some design")
            Else
                If id = "-1" Then
                    Dim q As String = "INSERT INTO tb_sni_rec(id_sni_pps,created_by,created_date,reff_date,id_report_status)
VALUES('" & id_pps & "','" & id_user & "',NOW(),'" & Date.Parse(DEReffDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','1'); SELECT LAST_INSERT_ID();"
                    id = execute_query(q, 0, True, "", "", "", "")
                    '
                    q = "CALL gen_number('" & id & "','325')"
                    execute_non_query(q, True, "", "", "", "")
                    '
                    q = "INSERT INTO tb_sni_rec_det(id_sni_rec,id_prod_order_det,id_product,qty) VALUES"
                    For i As Integer = 0 To GVList.RowCount - 1
                        If Not i = 0 Then
                            q += ","
                        End If
                        q += "('" & id & "','" & GVList.GetRowCellValue(i, "id_prod_order_det").ToString & "','" & GVList.GetRowCellValue(i, "id_product").ToString & "','" & GVList.GetRowCellValue(i, "qty").ToString & "')"
                    Next
                    execute_non_query(q, True, "", "", "", "")
                Else
                    'lock and submit
                    'check first
                    Dim is_ok As Boolean = True
                    Dim list_problem As String = ""
                    For i As Integer = 0 To GVList.RowCount - 1
                        Dim q As String = "SELECT * FROM tb_doc WHERE id_report='" & GVList.GetRowCellValue(i, "id_sni_rec_det").ToString & "' AND report_mark_type='325'"
                        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                        If dt.Rows.Count <= 0 Then
                            If Not list_problem = "" Then
                                list_problem += ","
                            End If
                            list_problem += GVList.GetRowCellValue(i, "design_display_name").ToString
                            is_ok = False
                        End If
                    Next

                    If Not is_ok Then
                        warningCustom("Harap isi kelengkapan foto serah terima artikel " & list_problem & " pada attachment.")
                    Else
                        Dim q As String = "UPDATE tb_sni_rec SET is_submit=1 WHERE id_sni_rec='" & id & "'"
                        execute_non_query(q, True, "", "", "", "")
                        '
                        submit_who_prepared("321", id, id_user)
                        '
                        warningCustom("Form serah terima telah disubmit.")
                        '
                        load_head()
                    End If
                End If
            End If
        Else
            warningCustom("Please input SNI proposal number")
        End If
    End Sub

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub RICEAttachment_Click(sender As Object, e As EventArgs) Handles RICEAttachment.Click
        If GVList.RowCount > 0 Then
            FormDocumentUpload.id_report = GVList.GetFocusedRowCellValue("id_sni_rec_det").ToString
            FormDocumentUpload.report_mark_type = "325"
            FormDocumentUpload.ShowDialog()
        End If
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor

        FormReportMark.report_mark_type = "321"
        FormReportMark.id_report = id
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        Cursor = Cursors.WaitCursor

        ReportSNISerahTerima.id = id
        ReportSNISerahTerima.dt = GCList.DataSource

        Dim Report As New ReportSNISerahTerima()
        Report.LabelNumber.Text = TENumber.Text

        GridColumnAttachment.Visible = False

        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVList.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        GridColumnAttachment.Visible = True

        'Grid Detail
        ReportStyleGridview(Report.GVList)
        Report.GVList.OptionsPrint.AllowMultilineHeaders = True

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()

        Cursor = Cursors.Default
    End Sub
End Class