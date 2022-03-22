Public Class FormAgingProductList
    Public id_design_soh As String = "-1"

    Private Sub FormAgingProductList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewAccount()
        DEUntilAcc.EditValue = getTimeDB()
    End Sub

    Private Sub FormAgingProductList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewAccount()
        Cursor = Cursors.WaitCursor
        Dim query As String = ""
        query += "SELECT ('0') AS id_comp, ('All') AS comp_number, ('All Account') AS comp_name, ('All Account') AS comp_name_label UNION ALL "
        query += "SELECT e.id_comp, e.comp_number, e.comp_name, CONCAT_WS(' - ', e.comp_number, e.comp_name) AS comp_name_label 
        FROM tb_m_comp e "
        viewSearchLookupQuery(SLEAccount, query, "id_comp", "comp_name_label", "id_comp")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnBrowseProduct_Click(sender As Object, e As EventArgs) Handles BtnBrowseProduct.Click
        Cursor = Cursors.WaitCursor
        FormSearchDesign.id_pop_up = "9"
        FormSearchDesign.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub CEFindAllProduct_EditValueChanged(sender As Object, e As EventArgs) Handles CEFindAllProduct.EditValueChanged
        id_design_soh = "-1"
        TxtProduct.Text = ""
        resetViewSOH()
        If CEFindAllProduct.EditValue = True Then
            BtnBrowseProduct.Enabled = False
        Else
            BtnBrowseProduct.Enabled = True
        End If
    End Sub

    Sub resetViewSOH()
        GCList.DataSource = Nothing
    End Sub

    Private Sub SLEAccount_EditValueChanged(sender As Object, e As EventArgs) Handles SLEAccount.EditValueChanged
        resetViewSOH()
    End Sub

    Private Sub TxtProduct_EditValueChanged(sender As Object, e As EventArgs) Handles TxtProduct.EditValueChanged
        resetViewSOH()
    End Sub

    Private Sub DEUntilAcc_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntilAcc.EditValueChanged
        resetViewSOH()
    End Sub

    Sub viewList()
        Cursor = Cursors.WaitCursor
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        Dim id_comp As String = SLEAccount.EditValue.ToString
        Dim id_design_sel As String = ""
        If id_design_soh = "-1" Then
            id_design_sel = 0
        Else
            id_design_sel = id_design_soh
        End If
        Dim until_date As String = DateTime.Parse(DEUntilAcc.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim query As String = "CALL view_aging_product_list('" + id_comp + "', '" + id_design_sel + "','" + until_date + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCList.DataSource = data
        'GVList.BestFitColumns()
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewAcc_Click(sender As Object, e As EventArgs) Handles BtnViewAcc.Click
        If CEFindAllProduct.EditValue = False And id_design_soh = "-1" Then
            warningCustom("Please input product code first")
            Exit Sub
        End If

        viewList()
    End Sub
End Class