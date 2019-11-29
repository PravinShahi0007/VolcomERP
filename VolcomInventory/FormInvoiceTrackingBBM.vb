Public Class FormInvoiceTrackingBBM
    Public rmt As String = "-1"
    Public id_report As String = "-1"

    Private Sub FormInvoiceTrackingBBM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT r.id_rec_payment, r.date_created, r.date_received, r.number, r.value 
        FROM tb_rec_payment r
        INNER JOIN tb_rec_payment_det rd ON rd.id_rec_payment=r.id_rec_payment
        WHERE rd.report_mark_type='" + rmt + "' AND rd.id_report=" + id_report + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormInvoiceTrackingBBM_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print_raw(GCData, "")
        Cursor = Cursors.Default
    End Sub
End Class