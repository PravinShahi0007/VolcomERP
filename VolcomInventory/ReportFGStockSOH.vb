Public Class ReportFGStockSOH
    Public Shared dt As DataTable

    Private Sub ReportFGStockQC_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCSOH.DataSource = dt
        GCSOHCode.DataSource = dt
    End Sub

    Private Sub GVSOH_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSOH.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVSOHCode_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSOHCode.CustomColumnDisplayText
        If (e.Column.FieldName.Contains("avl_qty") Or e.Column.FieldName.Contains("rsv_qty") Or e.Column.FieldName.Contains("ttl_qty")) Then
            Dim qty As Decimal = Convert.ToDecimal(e.Value)
            If qty = 0 Then
                e.DisplayText = "-"
            End If
        ElseIf e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class