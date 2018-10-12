Public Class FormPurcItemStock
    Private Sub FormPurcItemStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each t As DevExpress.XtraTab.XtraTabPage In XTCStock.TabPages
            XTCStock.SelectedTabPage = t
        Next t
        XTCStock.SelectedTabPage = XTCStock.TabPages(0)

        viewDept()
        viewCat()
        DESOHUntil.EditValue = getTimeDB()
    End Sub

    Sub viewItem()
        Dim query As String = "SELECT i.id_item, i.item_desc, cat.id_item_cat, cat.item_cat 
FROM tb_item i
INNER JOIN tb_item_cat cat ON cat.id_item_cat = i.id_item_cat "
    End Sub

    Sub viewDept()
        Cursor = Cursors.WaitCursor
        Dim query_all As String = queryDept(True)
        Dim query As String = queryDept(False)

        viewLookupQuery(LEDeptSum, query_all, 0, "departement", "id_departement")
        viewLookupQuery(LEDeptSC, query, 0, "departement", "id_departement")
        Cursor = Cursors.Default
    End Sub

    Function queryDept(ByVal include_all As Boolean) As String
        Dim query As String = ""
        If include_all Then
            query += "SELECT 0 as id_departement, 'All departement' as departement UNION  "
        End If
        query += "(SELECT id_departement,departement FROM tb_m_departement a ORDER BY a.departement ASC) "
        Return query
    End Function

    Sub viewCat()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `id_item_cat`, 'All Category' AS `item_cat`
        UNION ALL
        SELECT c.id_item_cat, c.item_cat FROM tb_item_cat c ORDER BY id_item_cat ASC"
        viewLookupQuery(LECat, query, 0, "item_cat", "id_item_cat")
        Cursor = Cursors.Default
    End Sub

    Private Sub FormPurcItemStock_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormPurcItemStock_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        'Prepare paramater
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_until_selected = DateTime.Parse(DESOHUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim dept As String = LEDeptSum.EditValue.ToString
        If dept <> "0" Then
            dept = "AND i.id_departement=" + dept + ""
        Else
            dept = ""
        End If


        Dim query As String = "SELECT a.id_departement, dept.departement,a.id_item, im.item_desc, im.id_item_cat, cat.item_cat, SUM(a.qty) AS `qty`, SUM(a.amount) AS `amount` 
        FROM (
	        SELECT i.id_departement,i.id_item, i.`value`,
	        SUM(IF(i.id_storage_category=2, CONCAT('-', i.storage_item_qty), i.storage_item_qty)) AS `qty`,
	        (SUM(IF(i.id_storage_category=2, CONCAT('-', i.storage_item_qty), i.storage_item_qty)) * i.`value`) AS `amount`
	        FROM tb_storage_item i
	        WHERE DATE(i.storage_item_datetime)<='" + date_until_selected + "' " + dept + "
	        GROUP BY i.id_departement,i.id_item, i.`value`
        ) a 
        INNER JOIN tb_item im ON im.id_item = a.id_item
        INNER JOIN tb_item_cat cat ON cat.id_item_cat = im.id_item_cat
        INNER JOIN tb_m_departement dept ON dept.id_departement = a.id_departement
        GROUP BY a.id_item, a.id_departement "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSOH.DataSource = data
        GVSOH.BestFitColumns()
        Cursor = Cursors.Default
    End Sub
End Class