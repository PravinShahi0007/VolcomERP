Public Class FormProductionFinalClearMetode
    Private Sub FormProductionFinalClearMetode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_metode()
    End Sub

    Sub load_metode()
        Dim q As String = "SELECT 1 AS id_metode_qc,'Full QC' AS metode_qc
UNION ALL
SELECT 2 AS id_metode_qc,'AQL' AS metode_qc"
        viewSearchLookupQuery(SLEMetode, q, "id_metode_qc", "metode_qc", "id_metode_qc")
    End Sub

    Private Sub FormProductionFinalClearMetode_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BContinue_Click(sender As Object, e As EventArgs) Handles BContinue.Click
        'FormProductionFinalClearSummary.SLEMetode.EditValue = SLEMetode.EditValue
        Close()
    End Sub
End Class