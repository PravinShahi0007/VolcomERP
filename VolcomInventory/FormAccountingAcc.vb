Public Class FormAccountingAcc 
    Public id_acc As String = "-1"
    Public id_parent As String = "-1"
    '
    Public id_popup As String = "-1"
    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormAccountingAcc_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub view_cons_type()
        Dim q As String = "SELECT '-' AS header,'-' AS sub_header,0 AS id_consolidation,'' AS description_ind,'Please select' AS description_eng 
UNION ALL
SELECT ch.`description_eng` AS header,cs.`description_eng` AS sub_header,c.id_consolidation,c.description_ind,c.description_eng 
FROM `tb_consolidation` c
INNER JOIN `tb_consolidation_sub_header` cs ON cs.`id_consolidation_sub_header`=c.`id_consolidation_sub_header`
INNER JOIN `tb_consolidation_header` ch ON ch.`id_consolidation_header`=cs.`id_consolidation_header`"
        viewSearchLookupQuery(SLEConsolidationCat, q, "id_consolidation", "description_eng", "id_consolidation")
    End Sub

    Sub view_tax_report_type()
        Dim q As String = "SELECT 0 AS id_tax_report,'Not in Tax Report' AS tax_report
UNION ALL
SELECT id_tax_report,tax_report FROM `tb_lookup_tax_report`"
        If LECOAType.EditValue.ToString = "1" Then
            q += " WHERE available_in_office_tag=1"
        Else
            q += " WHERE available_in_store_tag=1"
        End If
        viewSearchLookupQuery(SLETaxReport, q, "id_tax_report", "tax_report", "id_tax_report")
    End Sub

    Private Sub FormAccountingAcc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewCoaType()
        viewParent(SLEParentAccount)
        view_acc_category(LEAccCat)
        view_active(LEActive)
        view_is_det(LEDetail)
        view_dc(LEType)
        '
        view_cons_type()
        view_tax_report_type()
        '
        If id_acc = "-1" Then
            'new
            If Not id_parent = "0" And Not id_parent = "-1" Then
                SLEParentAccount.EditValue = id_parent
                TEAccount.Text = SLEParentAccount.Text
            End If
        Else
            'edit
            Dim query As String = String.Format("SELECT * FROM tb_a_acc WHERE id_acc = '{0}'", id_acc)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            Dim acc_name As String = ""

            id_parent = data.Rows(0)("id_acc_parent").ToString
            acc_name = data.Rows(0)("acc_name").ToString
            TEAccount.Text = acc_name

            If id_parent = "" Then
                SLEParentAccount.EditValue = "-1"
                TEAccountDetail.Text = acc_name
            Else
                SLEParentAccount.EditValue = id_parent
                TEAccountDetail.Text = acc_name.Substring(SLEParentAccount.Text.Length, acc_name.Length - SLEParentAccount.Text.Length)
            End If

            LECOAType.ItemIndex = LECOAType.Properties.GetDataSourceRowIndex("id_coa_type", data.Rows(0)("id_coa_type").ToString)
            LEAccCat.ItemIndex = LEAccCat.Properties.GetDataSourceRowIndex("id_acc_cat", data.Rows(0)("id_acc_cat").ToString)
            LEActive.ItemIndex = LEActive.Properties.GetDataSourceRowIndex("id_status", data.Rows(0)("id_status").ToString)
            LEDetail.ItemIndex = LEDetail.Properties.GetDataSourceRowIndex("id_is_det", data.Rows(0)("id_is_det").ToString)
            LEType.ItemIndex = LEType.Properties.GetDataSourceRowIndex("id_dc", data.Rows(0)("id_dc").ToString)

            SLEConsolidationCat.EditValue = data.Rows(0)("id_consolidation").ToString
            SLETaxReport.EditValue = data.Rows(0)("id_tax_report").ToString
            'cek editnya belom
            MEAccDesc.Text = data.Rows(0)("acc_description").ToString

            LECOAType.Properties.ReadOnly = True
            SLEParentAccount.Properties.ReadOnly = True
            TEAccountDetail.Properties.ReadOnly = True
            LEAccCat.Properties.ReadOnly = True
            MEAccDesc.Properties.ReadOnly = True
            LEDetail.Properties.ReadOnly = True
            LEType.Properties.ReadOnly = True
        End If
    End Sub

    Sub viewCoaType()
        Dim query As String = "SELECT * FROM tb_coa_type t ORDER BY t.id_coa_type ASC "
        viewLookupQuery(LECOAType, query, 0, "coa_type", "id_coa_type")
    End Sub

    Private Sub view_acc_category(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_acc_cat,acc_cat FROM tb_lookup_acc_cat"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "acc_cat"
        lookup.Properties.ValueMember = "id_acc_cat"
        lookup.ItemIndex = 0
    End Sub
    Private Sub view_active(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_status,status FROM tb_lookup_status"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "status"
        lookup.Properties.ValueMember = "id_status"
        lookup.ItemIndex = 0
    End Sub
    Private Sub view_is_det(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_is_det,is_det FROM tb_lookup_is_det"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "is_det"
        lookup.Properties.ValueMember = "id_is_det"
        lookup.ItemIndex = 0
    End Sub
    Private Sub view_dc(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_dc,dc FROM tb_lookup_dc"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "dc"
        lookup.Properties.ValueMember = "id_dc"
        lookup.ItemIndex = 0
    End Sub

    'View Parent
    Private Sub viewParent(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim id_coa_type As String = "-1"
        Try
            id_coa_type = LECOAType.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim query As String = "SELECT '-1' AS id_acc,'No Parent Account' AS acc_name,'' AS acc_description,'-1' AS id_acc_cat,'' AS acc_cat UNION "
        query += "SELECT a.id_acc,acc_name,a.acc_description,a.id_acc_cat,b.acc_cat FROM tb_a_acc a "
        query += "INNER JOIN tb_lookup_acc_cat b ON a.id_acc_cat=b.id_acc_cat "
        query += "WHERE a.id_is_det='1' AND a.id_status='1' AND a.id_coa_type='" + id_coa_type + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        If data.Rows.Count > 0 Then
            lookup.Properties.DisplayMember = "acc_name"
            lookup.Properties.ValueMember = "id_acc"
            lookup.EditValue = data.Rows(0)("id_acc").ToString
        End If
    End Sub
    Private Sub SLEParentAccount_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEParentAccount.EditValueChanged
        If Not SLEParentAccount.EditValue = "-1" Then
            Dim id_acc_cat As String = SLEParentAccount.Properties.View.GetFocusedRowCellValue("id_acc_cat")
            MEAccDesc.Text = SLEParentAccount.Properties.View.GetFocusedRowCellValue("acc_description")
            LEAccCat.EditValue = Nothing
            LEAccCat.ItemIndex = LEAccCat.Properties.GetDataSourceRowIndex("id_acc_cat", id_acc_cat)
        Else
            LEAccCat.ItemIndex = 0
        End If
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim query As String = ""

        ValidateChildren()
        If Not formIsValidInPanel(EPACC, PanelControl3) Then
            errorInput()
        ElseIf LEDetail.EditValue.ToString = "2" And SLEConsolidationCat.EditValue.ToString = "0" Then
            warningCustom("Please select consolidation report category")
        Else
            If id_acc = "-1" Then
                'new
                Dim is_tax_report As String = "2"
                Dim id_tax_report As String = "NULL"
                Dim id_consolidation As String = "NULL"
                '
                If LEDetail.EditValue.ToString = "2" Then
                    'tax
                    If Not SLETaxReport.EditValue.ToString = "0" Then
                        is_tax_report = "1"
                        id_tax_report = "'" & SLETaxReport.EditValue.ToString & "'"
                    End If
                    'consolidation
                    If Not SLEConsolidationCat.EditValue.ToString = "0" Then
                        id_consolidation = "'" & SLEConsolidationCat.EditValue.ToString & "'"
                    End If
                End If
                '
                If SLEParentAccount.EditValue = "-1" Then
                    query = String.Format("INSERT INTO tb_a_acc(acc_name,acc_description,id_acc_cat,id_is_det,id_status,id_dc, id_coa_type) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}');SELECT LAST_INSERT_ID()", TEAccount.Text, addSlashes(MEAccDesc.Text), LEAccCat.EditValue.ToString, LEDetail.EditValue.ToString, LEActive.EditValue.ToString, LEType.EditValue.ToString, LECOAType.EditValue.ToString)
                Else
                    query = String.Format("INSERT INTO tb_a_acc(acc_name,acc_description,id_acc_parent,id_acc_cat,id_is_det,id_status,id_dc, id_coa_type, is_tax_report,id_tax_report,id_consolidation) VALUES('{0}','{1}','{2}','{3}','{4}','{5}',{6}, '{7}','{8}',{9},{10});SELECT LAST_INSERT_ID()", TEAccount.Text, addSlashes(MEAccDesc.Text), SLEParentAccount.Properties.View.GetFocusedRowCellValue("id_acc").ToString, LEAccCat.EditValue.ToString, LEDetail.EditValue.ToString, LEActive.EditValue.ToString, LEType.EditValue.ToString, LECOAType.EditValue.ToString, is_tax_report, id_tax_report, id_consolidation)
                End If

                id_acc = execute_query(query, 0, True, "", "", "", "")

                If id_popup = "1" Then
                    FormPopUpMasterCOA.view_acc()

                    FormPopUpMasterCOA.GVAcc.FocusedRowHandle = find_row(FormPopUpMasterCOA.GVAcc, "id_acc", id_acc)
                Else
                    FormAccounting.LECOAType.ItemIndex = FormAccounting.LECOAType.Properties.GetDataSourceRowIndex("id_coa_type", LECOAType.EditValue.ToString)
                    FormAccounting.LECOATypeLedger.ItemIndex = FormAccounting.LECOATypeLedger.Properties.GetDataSourceRowIndex("id_coa_type", LECOAType.EditValue.ToString)
                    FormAccounting.view_acc()
                    FormAccounting.CreateNodes(FormAccounting.TreeList1)
                    FormAccounting.XTCGeneral.SelectedTabPageIndex = 0

                    FormAccounting.GVAcc.FocusedRowHandle = find_row(FormAccounting.GVAcc, "id_acc", id_acc)
                End If
                Close()
            Else
                'edit
                Dim is_tax_report As String = "2"
                Dim id_tax_report As String = "NULL"
                Dim id_consolidation As String = "NULL"
                '
                If LEDetail.EditValue.ToString = "2" Then
                    'tax
                    If Not SLETaxReport.EditValue.ToString = "0" Then
                        is_tax_report = "1"
                        id_tax_report = "'" & SLETaxReport.EditValue.ToString & "'"
                    End If
                    'consolidation
                    If Not SLEConsolidationCat.EditValue.ToString = "0" Then
                        id_consolidation = "'" & SLEConsolidationCat.EditValue.ToString & "'"
                    End If
                End If

                query = String.Format("UPDATE tb_a_acc SET acc_description='{0}',id_acc_cat='{1}',id_is_det='{2}',id_status='{3}',id_dc='{5}',is_tax_report='{6}',id_tax_report={7},id_consolidation={8} WHERE id_acc='{4}'", addSlashes(MEAccDesc.Text), LEAccCat.EditValue.ToString, LEDetail.EditValue.ToString, LEActive.EditValue.ToString, id_acc, LEType.EditValue.ToString, is_tax_report, id_tax_report, id_consolidation)
                execute_non_query(query, True, "", "", "", "")
                FormAccounting.view_acc()
                FormAccounting.CreateNodes(FormAccounting.TreeList1)

                FormAccounting.TreeList1.FocusedNode = FormAccounting.TreeList1.FindNodeByKeyID(id_acc)

                'FormAccounting.XTCGeneral.SelectedTabPageIndex = 0
                FormAccounting.GVAcc.FocusedRowHandle = find_row(FormAccounting.GVAcc, "id_acc", id_acc)

                Close()
            End If
        End If
    End Sub

    Private Sub TEAccountDetail_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEAccountDetail.EditValueChanged
        combine_acc()
    End Sub
    Sub combine_acc()
        Try
            Dim parent, acc As String

            If Not SLEParentAccount.EditValue = "-1" Then
                parent = SLEParentAccount.Text
            Else
                parent = ""
            End If

            acc = TEAccountDetail.Text

            TEAccount.Text = parent & TEAccountDetail.Text

        Catch ex As Exception
        End Try
    End Sub

    Private Sub TEAccount_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEAccount.Validating
        check()
    End Sub

    Sub check()
        Dim query_jml As String
        query_jml = String.Format("SELECT COUNT(id_acc) FROM tb_a_acc WHERE acc_name='{0}' AND id_acc!='{1}' AND id_coa_type='{2}' ", TEAccount.Text, id_acc, LECOAType.EditValue.ToString)
        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(EPACC, TEAccountDetail, "1")
        Else
            EP_TE_cant_blank(EPACC, TEAccountDetail)
        End If
    End Sub

    Private Sub BPickCompTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormPopUpContact.id_pop_up = "58"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub TEAccountDetail_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TEAccountDetail.Validating
        check()
    End Sub

    Private Sub LECOAType_EditValueChanged(sender As Object, e As EventArgs) Handles LECOAType.EditValueChanged
        viewParent(SLEParentAccount)
        view_tax_report_type()
        TEAccountDetail.Text = ""
    End Sub

    Private Sub LEDetail_EditValueChanged(sender As Object, e As EventArgs) Handles LEDetail.EditValueChanged
        If LEDetail.EditValue.ToString = "2" Then
            LtaxReport.Visible = True
            SLETaxReport.Visible = True
            LConsCat.Visible = True
            SLEConsolidationCat.Visible = True
        Else
            LtaxReport.Visible = False
            SLETaxReport.Visible = False
            LConsCat.Visible = False
            SLEConsolidationCat.Visible = False
        End If
    End Sub
End Class