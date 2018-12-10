Public Class FormPurcAssetDet
    Public id As String = "-1"
    Public action As String = "-1"
    Dim id_purc_rec As String = "-1"
    Dim id_purc_order As String = "-1"
    Public is_record_form As String = "-1"

    Private Sub FormPurcAssetDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCOA()
        actionLoad()
    End Sub

    Sub viewCOA()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 "
        viewSearchLookupQuery(SLEAccountFixedAsset, query, "id_acc", "acc_description", "id_acc")
        'viewSearchLookupQuery(SLEAP, query, "id_acc", "acc_description", "id_acc")
        'viewSearchLookupQuery(SLEDP, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
        ElseIf action = "upd" Then
            'generate number
            If is_record_form = "1" Then
                execute_non_query("CALL gen_number(1, 160)", True, "", "", "", "")
            End If

            Dim a As New ClassPurcAsset()
            Dim query As String = a.queryMain("AND a.id_purc_rec_asset=" + id + "", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtAssetName.Text = data.Rows(0)("asset_name").ToString
            TxtAssetNumber.Text = data.Rows(0)("asset_number").ToString
            SLEAccountFixedAsset.EditValue = data.Rows(0)("id_acc_fa").ToString
            DECreated.EditValue = data.Rows(0)("acq_date")
            TxtCost.EditValue = data.Rows(0)("acq_cost")
            id_purc_rec = data.Rows(0)("id_purc_rec").ToString
            LinkRec.Text = data.Rows(0)("purc_rec_number").ToString
            id_purc_order = data.Rows(0)("id_purc_rec").ToString
            LinkOrder.Text = data.Rows(0)("purc_order_number").ToString
        End If
    End Sub

    Private Sub FormPurcAssetDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub HyperLinkEdit1_OpenLink(sender As Object, e As DevExpress.XtraEditors.Controls.OpenLinkEventArgs) Handles LinkRec.OpenLink
        Cursor = Cursors.WaitCursor
        Dim c As New ClassShowPopUp()
        c.report_mark_type = "148"
        c.id_report = id_purc_rec
        c.show()
        Cursor = Cursors.Default
    End Sub

    Private Sub LinkOrder_OpenLink(sender As Object, e As DevExpress.XtraEditors.Controls.OpenLinkEventArgs) Handles LinkOrder.OpenLink
        Cursor = Cursors.WaitCursor
        Dim c As New ClassShowPopUp()
        c.report_mark_type = "139"
        c.id_report = id_purc_order
        c.show()
        Cursor = Cursors.Default
    End Sub
End Class