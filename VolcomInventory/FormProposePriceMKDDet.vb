Public Class FormProposePriceMKDDet
    Public action As String = ""
    Public id As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim is_load_break_size As Boolean = False
    Dim rmt As String = "306"

    Private Sub FormProposePriceMKDDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewPriceType()
        actionLoad()
    End Sub

    Private Sub FormProposePriceMKDDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewPriceType()
        Dim query As String = "SELECT pt.id_design_price_type, pt.design_price_type 
        FROM tb_lookup_design_price_type pt
        WHERE pt.id_design_price_type>2 "
        viewLookupQuery(LEPriceType, query, 0, "design_price_type", "id_design_price_type")
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            Width = 501
            Height = 296
            WindowState = FormWindowState.Normal
            PanelControl1.Visible = False
            PanelControlBottom.Visible = False
        End If
    End Sub

    Sub saveHead()
        'head
        Dim id_design_price_type As String = addSlashes(MENote.Text)
        Dim effective_date As String = DateTime.Parse(DEEffectDate.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim soh_sal_date As String = DateTime.Parse(DESOHDate.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim note As String = addSlashes(MENote.Text)
        If action = "ins" Then
            Dim query_head As String = "INSERT INTO tb_pp_change(id_design_price_type, created_date, effective_date, soh_sal_date, note, id_report_status)
            VALUES('" + id_design_price_type + "', NOW(), '" + effective_date + "', '" + soh_sal_date + "','" + note + "', 1); SELECT LAST_INSERT_ID(); "
            id = execute_query(query_head, 0, True, "", "", "", "")
            FormProposePriceMKD.viewSummary()
            FormProposePriceMKD.GVSummary.FocusedRowHandle = find_row(FormProposePriceMKD.GVSummary, "id_pp_change", id)
            FormProposePriceMKD.is_load_new = True
            Close()
        End If
    End Sub
End Class