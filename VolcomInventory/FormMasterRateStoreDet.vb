Public Class FormMasterRateStoreDet 
    Public action As String = "-1"
    Public id_store_rate As String = "-1"
    Public quick_edit As String = "-1"

    Private Sub FormMasterRateStoreDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub actionLoad()
        If action = "upd" Then
            Dim query_c As ClassDesign = New ClassDesign()
            Dim query As String = query_c.getRateStore("AND a.id_store_rate = '" + id_store_rate + "' ")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtRetCode.Text = data.Rows(0)("store_rate").ToString
        End If
    End Sub

    Private Sub FormMasterRateStoreDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        If TxtRetCode.Text = "" Then
            stopCustom("Please input rate store!")
        Else
            Dim query_cek As String = "SELECT COUNT(*) FROM tb_lookup_store_rate a WHERE a.store_rate = '" + TxtRetCode.Text + "' "
            If action = "upd" Then
                query_cek += "AND a.id_store_rate <> '" + id_store_rate + "' "
            End If
            Dim jum_cek As String = execute_query(query_cek, 0, True, "", "", "", "")
            If jum_cek > "0" Then
                stopCustom("Rate store is already exist.")
            Else
                Dim store_rate As String = TxtRetCode.Text.ToString
                If action = "ins" Then
                    Dim query As String = "INSERT INTO tb_lookup_store_rate(store_rate) VALUES ("
                    query += "'" + store_rate + "' "
                    query += "); SELECT LAST_INSERT_ID(); "
                    id_store_rate = execute_query(query, 0, True, "", "", "", "")
                    FormMasterRateStore.viewRate()
                    FormMasterRateStore.GVStoreRate.FocusedRowHandle = find_row(FormMasterRateStore.GVStoreRate, "id_store_rate", id_store_rate)
                    If quick_edit = "1" Then
                        FormFGDistSchemeStoreDet.loadStoreRate()
                    End If
                    Close()
                ElseIf action = "upd" Then
                    Dim query As String = "UPDATE tb_lookup_store_rate SET store_rate='" + store_rate + "' "
                    query += "WHERE id_store_rate='" + id_store_rate + "' "
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterRateStore.viewRate()
                    FormMasterRateStore.GVStoreRate.FocusedRowHandle = find_row(FormMasterRateStore.GVStoreRate, "id_store_rate", id_store_rate)
                    If quick_edit = "1" Then
                        FormFGDistSchemeStoreDet.loadStoreRate()
                    End If
                    Close()
                End If
            End If
        End If
        Cursor = Cursors.Default
    End Sub
End Class