Public Class FormMasterDesignCOPPropose
    Public id_propose As String = "-1"

    Private Sub FormMasterDesignCOPPropose_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormMasterDesignCOPPropose_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewCOPType()

        If id_propose = "-1" Then
            'new
            TENumber.Text = "[auto generate]"
            TEReqBy.Text = "[auto generate]"
            DEDateCreated.EditValue = Now()
            'load det
            load_det()
        Else
            'edit
            Dim query As String = "SELECT cp.*,emp. FROM `tb_design_cop_propose` cp
                                    INNER JOIN tb_m_user usr ON usr.`id_user`=cp.`created_by`
                                    INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
                                    WHERE `id_design_cop_propose`='" & id_propose & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                TENumber.Text = data.Rows(0)("number").ToString
                TEReqBy.Text = data.Rows(0)("employee_name").ToString
                DEDateCreated.EditValue = data.Rows(0)("date_created")
                LECOPType.ItemIndex = LECOPType.Properties.GetDataSourceRowIndex("id_cop_propose_type", data.Rows(0)("id_cop_propose_type").ToString)
                '
                MENote.Text = data.Rows(0)("note").ToString
                LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
                '
                load_det()
            End If
        End If
    End Sub

    Sub viewCOPType()
        Dim query As String = "SELECT id_cop_propose_type,cop_propose_type FROM tb_lookup_cop_propose_type a ORDER BY a.id_cop_propose_type "
        viewLookupQuery(LECOPType, query, 0, "cop_propose_type", "id_cop_propose_type")
    End Sub

    Sub load_det()
        Dim query As String = "SELECT pd.`id_design_cop_propose_det`,pd.`id_design`,pd.`id_currency`,cur.`currency`,pd.`id_comp_contact`,c.`comp_number`,c.`comp_name`,pd.`kurs`,pd.`design_cop`
FROM `tb_design_cop_propose_det` pd
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pd.`id_design`
INNER JOIN tb_lookup_currency cur ON cur.`id_currency`=pd.`id_currency`
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=pd.`id_comp_contact`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
WHERE pd.id_design_cop_propose='" & id_propose & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
        GVItemList.BestFitColumns()
        check_but()
    End Sub

    Sub check_but()
        If id_propose = "-1" Then
            PCAddDel.Visible = True
            BtnAdd.Visible = True
            If GVItemList.RowCount > 0 Then
                BtnDel.Visible = True
            Else
                BtnDel.Visible = False
            End If
        Else
            PCAddDel.Visible = False
        End If
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub
End Class