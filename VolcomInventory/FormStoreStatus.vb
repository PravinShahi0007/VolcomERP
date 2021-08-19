Public Class FormStoreStatus
    Public id_comp_cat As String = "-1"
    Dim dt_mail As DataTable

    Private Sub FormStoreStatus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_group_store()
        load_status()

        'load
        Dim qmail As String = "SELECT mail_comp_title_active,
        mail_comp_title_non_active,
        mail_store_title_active,
        mail_store_title_non_active,
        mail_comp_title_content_opening,
        mail_comp_title_content_active,
        mail_comp_title_content_non_active
        FROM tb_opt "
        dt_mail = execute_query(qmail, -1, True, "", "", "", "")
    End Sub

    Sub load_group_store()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS id_comp_group, 'All' AS comp_group, 'All Group' AS description 
        UNION
        SELECT cg.id_comp_group, cg.comp_group, cg.description 
        FROM tb_m_comp_group cg "
        viewSearchLookupQuery(SLEStoreGroup, query, "id_comp_group", "comp_group", "id_comp_group")
        Cursor = Cursors.Default
    End Sub

    Sub load_status()
        Dim query As String = "SELECT 0 AS id_status,'All Status' AS status
        UNION
        SELECT 1 AS id_status,'Active' AS status
        UNION
        SELECT 2 AS id_status,'Non Active' AS status "
        viewSearchLookupQuery(SLEStatusInvoice, query, "id_status", "status", "id_status")
        Dim query_no_all As String = "SELECT 1 AS id_status,'Active' AS status
        UNION
        SELECT 2 AS id_status,'Non Active' AS status "
        viewSearchLookupQuery(SLESetStatus, query_no_all, "id_status", "status", "id_status")
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor

        'where
        'category
        Dim cond As String = ""
        If id_comp_cat <> "-1" Then
            cond += "AND c.id_comp_cat IN (" + id_comp_cat + ")"
        End If
        'group
        Dim id_store_group As String = SLEStoreGroup.EditValue.ToString
        If id_store_group <> "0" Then
            cond += "AND c.id_comp_group='" + id_store_group + "' "
        End If
        'status
        Dim is_active As String = SLEStatusInvoice.EditValue.ToString
        If is_active <> "0" Then
            cond += "AND c.is_active='" + is_active + "' "
        End If

        Dim query As String = "SELECT  'No' AS `is_select`,c.id_comp,c.is_active, c.comp_number, c.comp_name, c.id_comp_group, cg.comp_group, cg.description AS `comp_group_desc`, c.address_primary,
        aa.`area`, cty.id_city, cty.city, sta.id_state, sta.state, rep.id_employee, rep.employee_name, ls.log_date, ls.reason
        FROM tb_m_comp c 
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        LEFT JOIN tb_m_area aa ON aa.id_area = c.id_area
        LEFT JOIN tb_m_city cty ON cty.id_city = c.id_city
        LEFT JOIN tb_m_state sta ON sta.id_state = cty.id_state
        LEFT JOIN tb_m_employee rep ON rep.id_employee = c.id_employee_rep
        LEFT JOIN (
	        SELECT ls.id_comp, ls.`log_date`, ls.reason
	        FROM tb_log_store_activation ls
	        INNER JOIN (
		        SELECT ls.id_comp, MAX(ls.log_date) AS `log_date` 
		        FROM tb_log_store_activation ls
		        GROUP BY ls.id_comp
	        ) lm ON lm.id_comp = ls.id_comp AND lm.log_date = ls.log_date
	        GROUP BY ls.id_comp
        ) ls ON ls.id_comp = c.id_comp
        WHERE 1=1 AND c.is_active IN(1,2) " + cond
        query += "ORDER BY cg.description, c.comp_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        If GVData.RowCount > 0 Then
            PanelControlActivate.Visible = True
        Else
            PanelControlActivate.Visible = False
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        viewData()
    End Sub

    Private Sub FormStoreStatus_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub CESelectAll_EditValueChanged(sender As Object, e As EventArgs) Handles CESelectAll.EditValueChanged
        For i As Integer = 0 To GVData.RowCount - 1
            If CESelectAll.EditValue = True Then
                GVData.SetRowCellValue(i, "is_select", "Yes")
            Else
                GVData.SetRowCellValue(i, "is_select", "No")
            End If
        Next
    End Sub

    Private Sub SLEStoreGroup_EditValueChanged(sender As Object, e As EventArgs) Handles SLEStoreGroup.EditValueChanged
        resetView()
    End Sub

    Sub resetView()
        GCData.DataSource = Nothing
        GVData.ActiveFilterString = ""
        PanelControlActivate.Visible = False
    End Sub

    Private Sub SLEStatusInvoice_EditValueChanged(sender As Object, e As EventArgs) Handles SLEStatusInvoice.EditValueChanged

        resetView()
    End Sub

    Private Sub SLESetStatus_EditValueChanged(sender As Object, e As EventArgs) Handles SLESetStatus.EditValueChanged
        TxtReason.Text = ""
        If SLESetStatus.EditValue.ToString = "1" Then
            PanelControlReason.Visible = False
        Else
            PanelControlReason.Visible = True
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        Dim is_active As String = SLESetStatus.EditValue.ToString

        'cek comp
        Dim err_comp As String = ""
        GVData.ActiveFilterString = ""
        GVData.ActiveFilterString = "[is_select]='Yes' AND [is_active]='" + is_active + "'"
        For i As Integer = 0 To (GVData.RowCount - 1) - GetGroupRowCount(GVData)
            If i > 0 Then
                err_comp += ","
            End If
            err_comp += GVData.GetRowCellValue(i, "comp_number").ToString
        Next
        GVData.ActiveFilterString = ""

        If err_comp <> "" Then
            warningCustom("These accounts already '" + SLESetStatus.Text + "' :" + System.Environment.NewLine + err_comp)
        ElseIf is_active = "2" And TxtReason.Text = "" Then
            warningCustom("Please fill reason")
        Else
            'OK
            GVData.ActiveFilterString = "[is_select]='Yes' "
            Dim id_comp_in As String = ""
            Dim comp_info As String = ""
            For s As Integer = 0 To (GVData.RowCount - 1) - GetGroupRowCount(GVData)
                If s > 0 Then
                    id_comp_in += ","
                    comp_info += System.Environment.NewLine
                End If
                id_comp_in += GVData.GetRowCellValue(s, "id_comp").ToString
                comp_info += GVData.GetRowCellValue(s, "comp_number").ToString + " - " + GVData.GetRowCellValue(s, "comp_name").ToString
            Next
            GVData.ActiveFilterString = ""

            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Selected account : " + System.Environment.NewLine + comp_info + System.Environment.NewLine + System.Environment.NewLine + "Are you sure want to set this account as '" + SLESetStatus.Text.ToString + "' ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim reason As String = addSlashes(TxtReason.Text)

                If id_comp_in <> "" Then
                    'update
                    Dim query As String = "UPDATE tb_m_comp SET is_active='" + is_active + "' WHERE id_comp IN (" + id_comp_in + ");
                    INSERT INTO tb_log_store_activation(log_date, log_updated_by, id_comp, is_active, reason) 
                    SELECT NOW(), " + id_user + ", c.id_comp, " + is_active + ", '" + reason + "'
                    FROM tb_m_comp c WHERE c.id_comp IN (" + id_comp_in + ");"
                    execute_non_query(query, True, "", "", "", "")

                    'email
                    Dim email_info As String = ""
                    Try
                        Dim mm As New ClassSendEmail()
                        mm.report_mark_type = "store_activation"
                        mm.par1 = dt_mail.Rows(0)("mail_comp_title_content_opening").ToString
                        If is_active = "1" Then
                            If id_comp_cat = "6" Then
                                mm.titl = dt_mail.Rows(0)("mail_store_title_active").ToString
                            Else
                                mm.titl = dt_mail.Rows(0)("mail_comp_title_active").ToString
                            End If
                            mm.par2 = dt_mail.Rows(0)("mail_comp_title_content_active").ToString
                        Else
                            If id_comp_cat = "6" Then
                                mm.titl = dt_mail.Rows(0)("mail_store_title_non_active").ToString
                            Else
                                mm.titl = dt_mail.Rows(0)("mail_comp_title_non_active").ToString
                            End If
                            mm.par2 = dt_mail.Rows(0)("mail_comp_title_content_non_active").ToString + TxtReason.Text + "."
                        End If
                        mm.dt = execute_query("SELECT comp_number, comp_name FROM tb_m_comp WHERE id_comp IN (" + id_comp_in + ")", -1, True, "", "", "", "")
                        mm.send_email()
                        email_info = "Success"
                    Catch ex As Exception
                        email_info = "Error : " + ex.ToString
                    End Try

                    Dim info As String = ""
                    info += "Updated status : Success " + System.Environment.NewLine
                    info += "Send email to related dept. : " + email_info + System.Environment.NewLine
                    infoCustom(info)
                Else
                    infoCustom("Nothing action")
                End If
                resetView()
            End If
        End If
    End Sub
End Class