Public Class FormRiderContractDet
    Public id_pps As String = "-1"

    Private Sub FormRiderContractDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_rider()
        load_det()
    End Sub

    Sub load_det()
        Dim q As String = "SELECT ppsd.*,IF(ppsd.id_type=1,'New','Changes') AS type 
FROM `tb_kontrak_rider_pps_det` ppsd"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCPPS.DataSource = dt
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        GVPPS.AddNewRow()
        GVPPS.FocusedRowHandle = GVPPS.RowCount - 1
        '
        GVPPS.SetRowCellValue(GVPPS.RowCount - 1, "id_type", "1")
        GVPPS.SetRowCellValue(GVPPS.RowCount - 1, "type", "New")
        GVPPS.SetRowCellValue(GVPPS.RowCount - 1, "monthly_pay", "0")
        GVPPS.SetRowCellValue(GVPPS.RowCount - 1, "kontrak_until", Date.Parse(Now().ToString))
        GVPPS.SetRowCellValue(GVPPS.RowCount - 1, "kontrak_from", Date.Parse(Now().ToString))
        GVPPS.RefreshData()
        '
        GVPPS.BestFitColumns()
    End Sub

    Sub load_rider()
        Dim q As String = "SELECT c.id_comp,CONCAT(c.`comp_number`,' - ',c.comp_name) AS comp_name
FROM tb_m_comp c 
WHERE c.`is_active`=1 AND c.`id_comp_cat`=2"
        viewSearchLookupRepositoryQuery(RepositoryItemSearchLookUpEdit1, q, 0, "comp_name", "id_comp")
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim is_ok As Boolean = False

        Dim qc As String = ""

        If GVPPS.RowCount > 0 Then
            If id_pps = "-1" Then 'new
                Dim q As String = "INSERT INTO `tb_kontrak_rider_pps`(created_by,created_date,note) VALUES('" & id_user & "',NOW(),'" & addSlashes(MENote.Text) & "'); SELECT LAST_INSERT_ID(); "
                id_pps = execute_query(q, 0, True, "", "", "", "")
                '
                execute_non_query("CALL gen_number('" & id_pps & "','398')", True, "", "", "", "")
                'detail
                q = "INSERT INTO tb_kontrak_rider_pps_det(`id_kontrak_rider_pps`,`id_comp`,`id_type`,`kontrak_from`,`kontrak_until`,`monthly_pay`) VALUES"
                For i = 0 To GVPPS.RowCount - 1
                    If Not i = 0 Then
                        q += ","
                    End If
                    q += "('" & id_pps & "','" & GVPPS.GetRowCellValue(i, "id_comp").ToString & "','" & GVPPS.GetRowCellValue(i, "id_type").ToString & "','" & Date.Parse(GVPPS.GetRowCellValue(i, "kontrak_from").ToString).ToString("yyyy-MM-dd") & "','" & Date.Parse(GVPPS.GetRowCellValue(i, "kontrak_until").ToString).ToString("yyyy-MM-dd") & "','" & decimalSQL(Decimal.Parse(GVPPS.GetRowCellValue(i, "kontrak_until").ToString).ToString) & "')"
                Next
                execute_non_query(q, True, "", "", "", "")
            Else 'edit

            End If
        End If
    End Sub

    Private Sub FormRiderContractDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class