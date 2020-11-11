Public Class FormInboundAWB
    Public id_awb_inbound As String = "-1"

    Sub load_type()
        Dim q As String = "SELECT rate.id_del_type,del.del_type
FROM tb_3pl_rate rate
INNER JOIN tb_lookup_del_type del ON del.id_del_type=rate.id_del_type AND del.is_able_inbound=1
WHERE id_type='2' AND is_active='1'
GROUP BY del.id_del_type"
        viewSearchLookupQuery(SLEDelType, 1, "del_type", "id_del_type", "del_type")
    End Sub

    Sub load_3pl()
        Dim q As String = "SELECT c.id_comp,c.comp_number,c.comp_name
FROM tb_3pl_rate rate
INNER JOIN tb_lookup_del_type del ON del.id_del_type=rate.id_del_type AND del.is_able_inbound=1
INNER JOIN tb_m_comp c ON c.id_comp=rate.id_comp
WHERE rate.id_type='2' AND rate.is_active='1'
AND rate.id_del_type='" & SLEDelType.EditValue.ToString & "'
GROUP BY rate.id_comp"
        viewSearchLookupQuery(SLEVendor, 1, "comp_name", "id_comp", "comp_name")
    End Sub

    Private Sub FormInboundAWB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_type()
        load_3pl()
    End Sub

    Private Sub BSubmitAwb_Click(sender As Object, e As EventArgs) Handles BSubmitAwb.Click
        'save AWB
        Dim q As String = "INSERT INTO `tb_inbound_awb`(id_comp,awb_number,created_by,created_date)
VALUES('" & SLEVendor.EditValue.ToString & "','" & addSlashes(TEAwb.Text.ToString) & "','" & id_user & "',NOW());SELECT LAST_INSERT_ID()"

        '
        empty_store()
        empty_koli()
        '
        XTCdetail.Enabled = True
        TEAwb.Enabled = False
        BNext.Enabled = True
        BSubmitAwb.Enabled = False
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

        TEAwb.Focus()
    End Sub

    Private Sub BUpdateStore_Click(sender As Object, e As EventArgs) Handles BUpdateStore.Click

    End Sub

    Private Sub BUpdateKoli_Click(sender As Object, e As EventArgs) Handles BUpdateKoli.Click

    End Sub
End Class