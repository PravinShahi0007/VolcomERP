Public Class FormFGTransList
    Public page_active As String = ""

    Private Sub FormFGTransList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'date now
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEFromRec.EditValue = data_dt.Rows(0)("dt")
        DEUntilRec.EditValue = data_dt.Rows(0)("dt")
        DEFromDO.EditValue = data_dt.Rows(0)("dt")
        DEUntilDO.EditValue = data_dt.Rows(0)("dt")
        DEFromReturn.EditValue = data_dt.Rows(0)("dt")
        DEUntilReturn.EditValue = data_dt.Rows(0)("dt")
        DEFromReturnQC.EditValue = data_dt.Rows(0)("dt")
        DEUntilReturnQC.EditValue = data_dt.Rows(0)("dt")
        DEFromTrf.EditValue = data_dt.Rows(0)("dt")
        DEUntilTrf.EditValue = data_dt.Rows(0)("dt")
        DEFromNonStock.EditValue = data_dt.Rows(0)("dt")
        DEUntilNonStock.EditValue = data_dt.Rows(0)("dt")
    End Sub

    Sub viewDO()
        Cursor = Cursors.WaitCursor
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromDO.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilDO.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        'prepare query
        Dim query_c As ClassSalesDelOrder = New ClassSalesDelOrder()
        Dim data As DataTable = query_c.transactionList("AND (a.pl_sales_order_del_date>='" + date_from_selected + "' AND a.pl_sales_order_del_date<='" + date_until_selected + "') ", "1")
        GCSalesDelOrder.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewDO_Click(sender As Object, e As EventArgs) Handles BtnViewDO.Click
        viewDO()
    End Sub

    Sub viewReturn()
        Cursor = Cursors.WaitCursor
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromReturn.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilReturn.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        'prepare query
        Dim query_c As ClassSalesReturn = New ClassSalesReturn()
        Dim data As DataTable = query_c.transactionList("AND (a.sales_return_date>='" + date_from_selected + "' AND a.sales_return_date<='" + date_until_selected + "') ", "1")
        GCSalesReturn.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewReturn_Click(sender As Object, e As EventArgs) Handles BtnViewReturn.Click
        viewReturn()
    End Sub
End Class