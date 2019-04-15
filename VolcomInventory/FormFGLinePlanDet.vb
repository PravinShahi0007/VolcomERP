Public Class FormFGLinePlanDet
    Public id As String = "-1"
    Public action As String = "-1"

    Private Sub FormFGLinePlanDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCode(SLESex, "1")
        viewCode(SLECat, "2")
        viewCode(SLESource, "3")
        viewCode(SLEClass, "4")
        viewCode(SLEColor, "5")
        viewDel()
        TxtQty.EditValue = 0.00
        TxtMarkUp.EditValue = 0.00
        TxtTargetPrice.EditValue = 0.00
        TxtTargetCost.EditValue = 0.00
        TxtTotalCost.EditValue = 0.00
        TxtTotalValue.EditValue = 0.00
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FormFGLinePlanDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewCode(ByVal SLE As DevExpress.XtraEditors.SearchLookUpEdit, ByVal id_type As String)
        Dim query As String = "SELECT cd.id_code_detail, cd.display_name FROM tb_m_code_detail cd WHERE cd.id_code_detail>0 "
        If id_type = "1" Then
            query += "AND cd.id_code=32; "
        ElseIf id_type = "2" Then
            query += "AND cd.id_code=4; "
        ElseIf id_type = "3" Then
            query += "AND cd.id_code=5; "
        ElseIf id_type = "4" Then
            query += "AND cd.id_code=30; "
        ElseIf id_type = "5" Then
            query += "AND cd.id_code=14;  "
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        SLE.Properties.DataSource = Nothing
        SLE.Properties.DataSource = data
        SLE.Properties.DisplayMember = "display_name"
        SLE.Properties.ValueMember = "id_code_detail"
        If data.Rows.Count.ToString >= 1 Then
            SLE.EditValue = data.Rows(0)("id_code_detail").ToString
        Else
            SLE.EditValue = Nothing
        End If
    End Sub

    Sub viewDel()
        Dim query As String = "SELECT * FROM tb_season_delivery d WHERE d.id_season=" + FormFGLinePlan.SLESeason.EditValue.ToString + " "
        viewLookupQuery(LEDelivery, query, 0, "id_delivery", "delivery")
    End Sub
End Class