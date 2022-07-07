Public Class FormProposePaymentCardPOS
    Private Sub FormProposePaymentCardPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Sub load_form()
        Dim query As String = "
            SELECT c.id_propose_card_pos, c.report_number, c.note, r.report_status, e.employee_name AS created_by, DATE_FORMAT(c.created_date, '%d %M %Y %H:%i:%s') AS created_date
            FROM tb_propose_card_pos AS c
            LEFT JOIN tb_lookup_report_status AS r ON c.id_report_status = r.id_report_status
            LEFT JOIN tb_m_employee AS e ON c.created_by = e.id_employee
            ORDER BY c.id_propose_card_pos DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCData.DataSource = data

        GVData.BestFitColumns()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        FormProposePaymentCardPOSDet.id_propose_card_pos = GVData.GetFocusedRowCellValue("id_propose_card_pos").ToString()
        FormProposePaymentCardPOSDet.ShowDialog()
    End Sub

    Private Sub FormProposePaymentCardPOS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormProposePaymentCardPOS_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("1", "1", "0")
    End Sub

    Private Sub FormProposePaymentCardPOS_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class