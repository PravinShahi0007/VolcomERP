Public Class FormPricePolicyCodeSingle
    Public id_code_detail As String = "-1"

    Private Sub FormPricePolicyCodeSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub actionLoad()
        viewType()
        TxtAgeMin.EditValue = 0
        TxtAgeMax.EditValue = 0
    End Sub

    Sub viewType()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT dt.id_disc_type, dt.disc_type 
        FROM tb_lookup_disc_type dt 
        WHERE dt.id_disc_type NOT IN(SELECT id_disc_type FROM tb_m_design_price_policy WHERE id_code_detail=" + id_code_detail + ") "
        viewLookupQuery(LEType, query, 0, "disc_type", "id_disc_type")
        Cursor = Cursors.Default
    End Sub

    Private Sub FormPricePolicyCodeSingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        If LEType.EditValue <> Nothing And TxtAgeMax.EditValue <> 0 Then
            Dim query As String = "INSERT INTO tb_m_design_price_policy(id_code_detail, id_disc_type, age_min, age_max) 
            VALUES('" + id_code_detail + "', '" + LEType.EditValue.ToString + "', '" + decimalSQL(TxtAgeMin.EditValue.ToString) + "', '" + decimalSQL(TxtAgeMax.EditValue.ToString) + "'); "
            execute_non_query(query, True, "", "", "", "")
            FormPricePolicyCodeDet.actionLoad()
            FormPricePolicyCodeDet.refreshMain()
            actionLoad()
        Else
            stopCustom("Please input all data")
        End If
    End Sub
End Class