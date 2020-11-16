Public Class FormReturnNoteDet
    Public id_return_note As String = "-1"
    Dim id_inbound_awb As String = "-1"
    Private Sub BAddStore_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BDelStore_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FormReturnNoteDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub load_store()
        Dim q As String = "SELECT id_comp
FROM `tb_return_note_store`
WHERE id_return_note='" & id_return_note & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCStore.DataSource = dt
        GVStore.BestFitColumns()
        check_but()
    End Sub

    Sub load_store_from_awb()
        Dim q As String = "SELECT id_comp
FROM `tb_inbound_store`
WHERE id_inbound_awb='" & id_inbound_awb & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCStore.DataSource = dt
        GVStore.BestFitColumns()
        check_but()
    End Sub

    Sub empty_store()
        For i = GVStore.RowCount - 1 To 0 Step -1
            GVStore.DeleteRow(i)
        Next
        check_but()
    End Sub

    Private Sub BDelStore_Click_1(sender As Object, e As EventArgs) Handles BDelStore.Click
        If GVStore.RowCount > 0 Then
            GVStore.DeleteSelectedRows()
            check_but()
        End If
    End Sub

    Private Sub BAddStore_Click_1(sender As Object, e As EventArgs) Handles BAddStore.Click
        GVStore.AddNewRow()
        check_but()
    End Sub

    Sub load_repo_store()
        Dim q As String = "SELECT id_comp,comp_number,CONCAT(comp_number, ' - ',comp_name) AS comp_name
FROM tb_m_comp 
WHERE id_comp_cat='6' AND is_active='1'"
        viewSearchLookupRepositoryQuery(RISLECompany, q, 0, "comp_name", "id_comp")
    End Sub

    Private Sub FormReturnNoteDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_emp()
        load_type()
        load_store()
        load_repo_store()
    End Sub

    Sub load_type()
        Dim q As String = "SELECT '1' AS id_type,'WH INBOUND DELIVERY' AS type UNION ALL SELECT '2' AS id_type,'3PL OFFLINE' AS type"
        viewSearchLookupQuery(SLEType, q, "id_type", "type", "id_type")
    End Sub

    Sub load_emp()
        Dim q As String = "SELECT id_employee,employee_code,employee_name FROM tb_m_employee WHERE id_employee_status='1' AND id_departement='6'"
        viewSearchLookupQuery(SLEEmp, q, "id_employee", "employee_name", "id_employee")
    End Sub

    Sub check_but()
        If SLEType.EditValue.ToString = "1" Then 'lokal
            PCReturnStaff.Visible = True
            PCButton.Visible = True
            PCAWB.Visible = False
        Else
            PCReturnStaff.Visible = False
            PCButton.Visible = False
            PCAWB.Visible = True
        End If
        '
        If GVStore.RowCount > 0 Then
            BDelStore.Visible = True
        Else
            BDelStore.Visible = False
        End If
        '
        If SLEType.EditValue.ToString = "1" Then
            'wh inbound
            empty_store()
            PCReturnStaff.Visible = True
            PCAWB.Visible = False
            PCButton.Visible = True
            '
            GVStore.OptionsBehavior.ReadOnly = False
            GVStore.OptionsBehavior.Editable = True
        Else
            '3pl offline
            empty_store()
            PCReturnStaff.Visible = False
            PCAWB.Visible = True
            PCButton.Visible = False
            '
            GVStore.OptionsBehavior.ReadOnly = True
            GVStore.OptionsBehavior.Editable = False
        End If
    End Sub

    Private Sub BResetAWB_Click(sender As Object, e As EventArgs) Handles BResetAWB.Click
        TEAWB.Enabled = True
        TEAWB.Text = ""
        id_inbound_awb = "-1"
        check_but()
    End Sub

    Private Sub TEAWB_KeyDown(sender As Object, e As KeyEventArgs) Handles TEAWB.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TEAWB.Text = "" Then
                warningCustom("Please scan AWB")
            Else
                Dim is_ok As Boolean = False
                'check
                Dim qc As String = "SELECT id_inbound_awb FROM tb_inbound_awb WHERE awb_number='" & addSlashes(TEAWB.Text) & "'"
                Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
                If dtc.Rows.Count <= 0 Then
                    warningCustom("AWB not found")
                Else
                    id_inbound_awb = dtc.Rows(0)("id_inbound_awb").ToString
                    TEAWB.Enabled = False
                    load_store_from_awb()
                    check_but()
                End If
            End If
        End If
    End Sub

    Private Sub SLEType_EditValueChanged(sender As Object, e As EventArgs) Handles SLEType.EditValueChanged
        check_but()
    End Sub

    Private Sub BSaveAndPrint_Click(sender As Object, e As EventArgs) Handles BSaveAndPrint.Click
        Dim q As String = ""

        If SLEType.EditValue.ToString = "1" And GVStore.RowCount = 0 Then
            warningCustom("Please input store first")
        End If

        If id_return_note = "-1" Then
            'new
            q = "INSERT INTO tb_return_note(`id_type`,`id_emp_driver`,`id_inbound_awb`,`date_created`,`number_return_note`,`qty`,`date_return_note`
) VALUES('" & SLEType.EditValue.ToString & "','" & If(SLEType.EditValue.ToString = "1", SLEEmp.EditValue.ToString, "0") & "',NOW(),'" & addSlashes(TEReturnNoteNumber.Text) & "','" & TEQtyReturnNote.EditValue.ToString & "','" & Date.Parse(DEReturnNote.EditValue.ToString).ToString("yyyy-MM-dd") & "'); SELECT LAST_INSERT_ID();"
            id_return_note = execute_query(q, 0, True, "", "", "", "")
            '
            q = "CALL gen_label_return_note('" & id_return_note & "')"
            execute_non_query(q, True, "", "", "", "")
            'store
            q = "DELETE FROM tb_return_note_store WHERE id_return_note='" & id_return_note & "'"
            execute_non_query(q, True, "", "", "", "")
            q = "INSERT INTO tb_return_note_store(id_return_note,id_comp) VALUES()"
        Else
            'update

        End If

    End Sub
End Class