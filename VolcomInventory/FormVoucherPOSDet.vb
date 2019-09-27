Public Class FormVoucherPOSDet
    Public id As String = "-1"
    Public action As String = "-1"
    Dim action_label As String = ""

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormVoucherPOSDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        TxtVoucherNumber.Focus()
        If action = "ins" Then
            action_label = "create"
            TxtValue.EditValue = 0
            Dim tgl As DateTime = getTimeDB()
            DEStart.EditValue = tgl
            DEEnd.EditValue = tgl
        Else
            action_label = "update"

            Dim query As String = "SELECT v.id_pos_voucher, v.voucher_number, v.voucher_value, v.voucher_name, v.voucher_address, 
            v.period_start, v.period_end, IFNULL(v.id_outlet,0) AS `id_outlet`, v.is_active
            FROM tb_pos_voucher v
            WHERE v.id_pos_voucher=" + id + " "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Dim id_outlet As String = data.Rows(0)("id_outlet").ToString
            If id_outlet <> "0" Then
                stopCustom("Can't update this voucher, because this voucher already used")
                Cursor = Cursors.Default
                Close()
                Exit Sub
            End If
            TxtVoucherNumber.Text = data.Rows(0)("voucher_number").ToString
            TxtValue.EditValue = data.Rows(0)("voucher_value")
            DEStart.EditValue = data.Rows(0)("period_start")
            DEEnd.EditValue = data.Rows(0)("period_end")
            TxtOnBehalf.Text = data.Rows(0)("voucher_name").ToString
            MEAddress.Text = data.Rows(0)("voucher_address").ToString
            Dim is_active As String = data.Rows(0)("is_active").ToString
            If is_active = "1" Then
                CEActive.EditValue = True
            Else
                CEActive.EditValue = False
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        'cek exixtig voucher
        Cursor = Cursors.WaitCursor
        Dim qe As String = "SELECT * FROM tb_pos_voucher v WHERE v.voucher_number='" + addSlashes(TxtVoucherNumber.Text) + "' "
        Dim de As DataTable = execute_query(qe, -1, True, "", "", "", "")
        If de.Rows.Count > 0 Then
            stopCustom("Voucher number : " + TxtVoucherNumber.Text + " already exist.")
            Exit Sub
            Cursor = Cursors.Default
        End If

        If TxtVoucherNumber.Text = "" Then
            stopCustom("All required fields")
            Cursor = Cursors.Default
        Else

            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to " + action_label + " this voucher?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim voucher_number As String = addSlashes(TxtVoucherNumber.Text)
                Dim voucher_value As String = decimalSQL(TxtValue.EditValue.ToString)
                Dim voucher_name As String = addSlashes(TxtOnBehalf.Text.ToString)
                Dim voucher_address As String = addSlashes(MEAddress.Text.ToString)
                Dim period_start As String = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
                Dim period_end As String = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
                Dim is_active As String = ""
                If CEActive.EditValue = True Then
                    is_active = "1"
                Else
                    is_active = "2"
                End If

                If action = "ins" Then
                    'new
                    Dim query As String = "INSERT INTO tb_pos_voucher(voucher_number, voucher_value, voucher_name, voucher_address, period_start, period_end, is_active) 
                    VALUES('" + voucher_number + "', '" + voucher_value + "', '" + voucher_name + "', '" + voucher_address + "', '" + period_start + "', '" + period_end + "', '" + is_active + "'); SELECT LAST_INSERT_ID(); "
                    id = execute_query(query, 0, True, "", "", "", "")

                    Dim confirm_create_again As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Create other voucher ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm_create_again = Windows.Forms.DialogResult.Yes Then
                        id = "-1"
                        action = "ins"
                        action_label = ""
                        actionLoad()
                    Else
                        FormVoucherPOS.viewVoucher()
                        FormVoucherPOS.GVData.FocusedRowHandle = find_row(FormVoucherPOS.GVData, "id_pos_voucher", id)
                        Close()
                    End If
                Else
                    'edit
                    Dim query As String = "UPDATE tb_pos_voucher voucher_number='" + voucher_number + "', voucher_value='" + voucher_value + "', 
                    voucher_name='" + voucher_name + "', voucher_address='" + voucher_address + "', period_start='" + period_start + "', period_end='" + period_end + "', 
                    is_active='" + is_active + "' WHERE id_pos_voucher='" + id + "' "
                    execute_non_query(query, True, "", "", "", "")

                    FormVoucherPOS.viewVoucher()
                    FormVoucherPOS.GVData.FocusedRowHandle = find_row(FormVoucherPOS.GVData, "id_pos_voucher", id)
                    Close()
                End If
                Cursor = Cursors.Default
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtValue_EditValueChanged(sender As Object, e As EventArgs) Handles TxtValue.EditValueChanged

    End Sub

    Private Sub FormVoucherPOSDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class