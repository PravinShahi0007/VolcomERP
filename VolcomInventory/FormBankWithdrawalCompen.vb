Public Class FormBankWithdrawalCompen
    Private Sub FormBankWithdrawalCompen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub load_data()
        Dim q As String = "SELECT * FROM tb_sales_pos p WHERE p.report_mark_type='117' AND p.report_mark_type='183' AND p.is_close_rec_payment='2'"
    End Sub
End Class