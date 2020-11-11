Public Class FormInboundAWB
    Public id_awb_inbound As String = "-1"
    Dim divide_by As Decimal = 0.00

    Sub load_type()
        Dim q As String = "SELECT rate.id_del_type,del.del_type
FROM tb_3pl_rate rate
INNER JOIN tb_lookup_del_type del ON del.id_del_type=rate.id_del_type AND del.is_able_inbound=1
WHERE id_type='2' AND is_active='1'
GROUP BY del.id_del_type"
        viewSearchLookupQuery(SLEDelType, q, "id_del_type", "del_type", "id_del_type")
    End Sub

    Sub load_3pl()
        Dim q As String = "SELECT c.id_comp,c.comp_number,c.comp_name
FROM tb_3pl_rate rate
INNER JOIN tb_lookup_del_type del ON del.id_del_type=rate.id_del_type AND del.is_able_inbound=1
INNER JOIN tb_m_comp c ON c.id_comp=rate.id_comp
WHERE rate.id_type='2' AND rate.is_active='1'
AND rate.id_del_type='" & SLEDelType.EditValue.ToString & "'
GROUP BY rate.id_comp"
        viewSearchLookupQuery(SLEVendor, q, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub load_repo_store()
        Dim q As String = "SELECT id_comp,comp_number,CONCAT(comp_number, " - ",comp_name) AS comp_name
FROM tb_m_comp 
WHERE id_comp_cat='6' AND is_active='1'"
        viewSearchLookupRepositoryQuery(RISLECompany, q, 0, "comp_name", "id_comp")
    End Sub

    Private Sub FormInboundAWB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_type()
        load_3pl()
        '
        load_repo_store()
        load_koli()
        load_store()
    End Sub

    Sub load_koli()
        Dim q As String = ""
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCKoli.DataSource = dt
        GVKoli.BestFitColumns()
        check_but()
    End Sub

    Sub load_store()

    End Sub

    Private Sub BSubmitAwb_Click(sender As Object, e As EventArgs) Handles BSubmitAwb.Click
        'save AWB
        If TEAwb.Text = "" Then
            warningCustom("Please input AWB")
        Else
            'check AWB
            Dim qc As String = "SELECT * FROM tb_inbound_awb
WHERE id_comp='" & SLEVendor.EditValue.ToString & "' AND awb_number='" & addSlashes(TEAwb.Text.ToString) & "'"
            Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
            If dtc.Rows.Count > 0 Then
                warningCustom("AWB already exist.")
            Else
                Dim q As String = "INSERT INTO `tb_inbound_awb`(id_comp,id_del_type,awb_number,created_by,created_date)
VALUES('" & SLEVendor.EditValue.ToString & "','" & SLEDelType.EditValue.ToString & "','" & addSlashes(TEAwb.Text.ToString) & "','" & id_user & "',NOW());SELECT LAST_INSERT_ID()"
                id_awb_inbound = execute_query(q, 0, True, "", "", "", "")
                '
                empty_store()
                empty_koli()
                'divide by
                Dim qdb As String = "SELECT volume_divide_by FROM `tb_lookup_del_type` WHERE id_del_type=''"
                Dim dtb As DataTable = execute_query(qdb, -1, True, "", "", "", "")
                divide_by = dtb.Rows(0)("volume_divide_by")
                '
                XTCdetail.Enabled = True
                TEAwb.Enabled = False
                BNext.Enabled = True
                BSubmitAwb.Enabled = False
            End If
        End If
    End Sub

    Sub empty_store()
        For i = GVStore.RowCount - 1 To 0 Step -1
            GVStore.DeleteRow(i)
        Next
        check_but()
    End Sub

    Sub empty_koli()
        For i = GVKoli.RowCount - 1 To 0 Step -1
            GVKoli.DeleteRow(i)
        Next
        check_but()
    End Sub

    Private Sub FormInboundAWB_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SLEVendor_EditValueChanged(sender As Object, e As EventArgs) Handles SLEVendor.EditValueChanged

    End Sub

    Sub check_but()
        If GVKoli.RowCount > 0 Then
            BDelKoli.Visible = True
        Else
            BDelKoli.Visible = False
        End If
        '
        If GVStore.RowCount > 0 Then
            BDelStore.Visible = True
        Else
            BDelStore.Visible = False
        End If
    End Sub

    Private Sub BDelStore_Click(sender As Object, e As EventArgs) Handles BDelStore.Click
        If GVStore.RowCount > 0 Then
            GVStore.DeleteSelectedRows()
            check_but()
        End If
    End Sub

    Private Sub BDelKoli_Click(sender As Object, e As EventArgs) Handles BDelKoli.Click
        If GVKoli.RowCount > 0 Then
            GVKoli.DeleteSelectedRows()
            check_but()
        End If
    End Sub

    Private Sub BNext_Click(sender As Object, e As EventArgs) Handles BNext.Click
        BSubmitAwb.Enabled = True
        BNext.Enabled = False
        TEAwb.Enabled = True
        XTCdetail.Enabled = False

        empty_store()
        empty_koli()

        TEAwb.Text = ""
        id_awb_inbound = "-1"

        TEAwb.Focus()
    End Sub

    Private Sub BUpdateStore_Click(sender As Object, e As EventArgs) Handles BUpdateStore.Click
        If id_awb_inbound = "-1" Then
            Close()
        Else
            Dim q As String = ""
            q = "DELETE FROM tb_inbound_store WHERE id_inbound_awb='" & id_awb_inbound & "'"
            execute_non_query(q, True, "", "", "", "")
            q = "INSERT INTO `tb_inbound_store`(id_inbound_awb,id_comp)
VALUES"
            For i As Integer = 0 To GVStore.RowCount - 1
                If Not i = 0 Then
                    q += ","
                End If
                q += "('" & id_awb_inbound & "','" & GVStore.GetRowCellValue(i, "id_comp").ToString & "')"
            Next
            execute_non_query(q, True, "", "", "", "")
        End If
    End Sub

    Private Sub BUpdateKoli_Click(sender As Object, e As EventArgs) Handles BUpdateKoli.Click
        If id_awb_inbound = "-1" Then
            Close()
        Else
            Dim q As String = ""
            q = "DELETE FROM tb_inbound_koli WHERE id_inbound_awb='" & id_awb_inbound & "'"
            execute_non_query(q, True, "", "", "", "")
            q = "INSERT INTO `tb_inbound_koli`(id_inbound_awb,koli_notes,divide_by,panjang,lebar,tinggi,berat,berat_dimensi)
VALUES"
            For i As Integer = 0 To GVKoli.RowCount - 1
                If Not i = 0 Then
                    q += ","
                End If
                q += "('" & id_awb_inbound & "','" & GVKoli.GetRowCellValue(i, "koli_notes").ToString & "','" & decimalSQL(Decimal.Parse(GVKoli.GetRowCellValue(i, "divide_by").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVKoli.GetRowCellValue(i, "panjang").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVKoli.GetRowCellValue(i, "lebar").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVKoli.GetRowCellValue(i, "tinggi").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVKoli.GetRowCellValue(i, "berat").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVKoli.GetRowCellValue(i, "berat_dimensi").ToString).ToString) & "')"

            Next
            execute_non_query(q, True, "", "", "", "")
        End If
    End Sub

    Private Sub SLEDelType_EditValueChanged(sender As Object, e As EventArgs) Handles SLEDelType.EditValueChanged
        load_3pl()
    End Sub

    Private Sub BAddStore_Click(sender As Object, e As EventArgs) Handles BAddStore.Click
        GVStore.AddNewRow()
    End Sub

    Private Sub BAddKoli_Click(sender As Object, e As EventArgs) Handles BAddKoli.Click
        GVKoli.AddNewRow()
        GVKoli.SetRowCellValue(GVKoli.RowCount - 1, "", "")
    End Sub
End Class