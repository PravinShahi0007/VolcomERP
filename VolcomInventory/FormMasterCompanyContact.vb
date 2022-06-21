﻿Imports DevExpress.XtraEditors
Public Class FormMasterCompanyContact
    Public id_company As String
    Public id_pop_up As String = "-1"
    Public id_comp_contacts As String
    Private Sub TECP_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TECP.Validating
        EP_TE_cant_blank(EPContact, TECP)
    End Sub
    Private Sub FormCompanyContact_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_annotation()
        view_contact()
    End Sub

    Sub load_annotation()
        Dim query As String = "SELECT id_annotation,annotation FROM tb_lookup_annotation"
        viewSearchLookupQuery(SLEAnnotation, query, "id_annotation", "annotation", "id_annotation")
    End Sub

    Sub view_contact()
        Dim data As DataTable = execute_query(String.Format("SELECT a.id_annotation,a.annotation,cc.id_comp_contact,cc.contact_person,cc.contact_number,cc.email,position,cc.is_default 
FROM tb_m_comp_contact cc
INNER JOIN tb_lookup_annotation a ON cc.id_annotation=a.id_annotation
WHERE cc.id_comp='{0}' 
ORDER BY cc.is_default AND cc.contact_person", id_company), -1, True, "", "", "", "")
        GCCompanyContactList.DataSource = data
        If GVCompanyContactList.RowCount > 0 Then

        End If
    End Sub

    Private Sub view_default(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_default,default_name FROM tb_lookup_default"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "default_name"
        lookup.Properties.ValueMember = "id_default"
        lookup.ItemIndex = 1
    End Sub

    Private Sub BNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BNew.Click
        view_default(LEDefault)
        PDetail.Enabled = True
        BSetDefault.Enabled = False
        BEdit.Enabled = False
        '
        ''
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        clean_field()
        GroupControl1.Enabled = True
        PDetail.Enabled = False
        BNew.Enabled = True
        BSetDefault.Enabled = True
        BEdit.Enabled = True
    End Sub

    Private Sub BEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEdit.Click
        view_default(LEDefault)

        PDetail.Enabled = True
        BSetDefault.Enabled = False
        BNew.Enabled = False

        If GVCompanyContactList.GetFocusedRowCellDisplayText("is_default") = "Checked" Then
            LEDefault.Enabled = False
            LEDefault.ItemIndex = 0
        Else
            LEDefault.Enabled = True
        End If

        GroupControl1.Enabled = False
        TEContactNumber.Text = GVCompanyContactList.GetFocusedRowCellValue("contact_number").ToString
        TECP.Text = GVCompanyContactList.GetFocusedRowCellValue("contact_person").ToString
        TEEmail.Text = GVCompanyContactList.GetFocusedRowCellValue("email").ToString
        TEPosition.Text = GVCompanyContactList.GetFocusedRowCellValue("position").ToString

    End Sub

    Private Sub BSetDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSetDefault.Click
        Dim confirm As DialogResult
        Dim query As String

        Dim id_contact As String = GVCompanyContactList.GetFocusedRowCellValue("id_comp_contact").ToString

        confirm = XtraMessageBox.Show("Are you sure want to set this as default contact?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            query = String.Format("UPDATE tb_m_comp_contact SET is_default='0' WHERE id_comp='{1}';UPDATE tb_m_comp_contact SET is_default='1' WHERE id_comp_contact = '{0}'", id_contact, id_company)
            execute_non_query(query, True, "", "", "", "")
            view_contact()
            GVCompanyContactList.FocusedRowHandle = find_row(GVCompanyContactList, "id_comp_contact", id_contact)
            Try
                FormMasterCompanySingle.SLEAnnotation.EditValue = GVCompanyContactList.GetFocusedRowCellValue("id_annotation").ToString
                FormMasterCompanySingle.TECPName.Text = GVCompanyContactList.GetFocusedRowCellValue("contact_name").ToString
                FormMasterCompanySingle.TECPPosition.EditValue = GVCompanyContactList.GetFocusedRowCellValue("position").ToString
                FormMasterCompanySingle.TECPEmail.EditValue = GVCompanyContactList.GetFocusedRowCellValue("email").ToString
                FormMasterCompanySingle.TECPPhone.EditValue = GVCompanyContactList.GetFocusedRowCellValue("contact_number").ToString
            Catch ex As Exception
            End Try

        End If
    End Sub

    Sub clean_field()
        TECP.Text = ""
        TEContactNumber.Text = ""
        LEDefault.Properties.DataSource = Nothing
        EPContact.SetError(TEContactNumber, "")
        EPContact.SetError(TECP, "")
    End Sub

    Private Sub TEContactNumber_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEContactNumber.Validating
        If Not isPhoneNumber(TEContactNumber.Text) Or TEContactNumber.Text.Length < 1 Then
            EPContact.SetError(TEContactNumber, "Phone number is not valid.")
        Else
            EPContact.SetError(TEContactNumber, String.Empty)
        End If
    End Sub

    Private Sub FormMasterCompanyContact_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BSave_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        ValidateChildren()
        Dim contact_name As String = addSlashes(TECP.Text)
        Dim contact_number As String = addSlashes(TEContactNumber.Text)
        Dim email As String = addSlashes(TEEmail.Text)
        Dim position As String = addSlashes(TEPosition.Text)
        Dim isdefault As String = LEDefault.EditValue.ToString
        Dim annotation As String = SLEAnnotation.EditValue.ToString
        Dim query As String

        If BNew.Enabled = True Then
            'new
            If Not EPContact.GetError(TEContactNumber) = "" Or Not EPContact.GetError(TECP) = "" Then
                errorInput()
            Else
                If isdefault = "1" Then
                    query = String.Format("UPDATE tb_m_comp_contact SET is_default='0' WHERE id_comp='{0}'", id_company)
                    execute_non_query(query, True, "", "", "", "")
                Else
                    isdefault = "0"
                End If
                query = String.Format("INSERT INTO tb_m_comp_contact(id_comp,contact_person,contact_number,email,position,is_default,last_upd,last_upd_by,id_annotation) VALUES('{0}','{1}','{2}','{3}','{4}','{5}',NOW(),'{6}','{7}')", id_company, contact_name, contact_number, email, position, isdefault, id_user, annotation)
                execute_non_query(query, True, "", "", "", "")
                view_contact()
                clean_field()

                If id_pop_up = "1" Then
                    FormPopUpContact.view_contact(id_company)
                End If

                PDetail.Enabled = False
                BNew.Enabled = True
                BSetDefault.Enabled = True
                BEdit.Enabled = True
            End If
        ElseIf BEdit.Enabled = True Then
            'edit
            If Not EPContact.GetError(TEContactNumber) = "" Or Not EPContact.GetError(TECP) = "" Then
                errorInput()
            Else
                If isdefault = "1" Then
                    query = String.Format("UPDATE tb_m_comp_contact SET is_default='0' WHERE id_comp='{0}'", id_company)
                    execute_non_query(query, True, "", "", "", "")
                Else
                    isdefault = "0"
                End If
                query = String.Format("UPDATE tb_m_comp_contact SET contact_person='{0}',contact_number='{1}',is_default='{2}',email='{3}',position='{4}',last_upd=NOW(),last_upd_by='{6}',id_annotation='{7}' WHERE id_comp_contact='{5}'", contact_name, contact_number, isdefault, email, position, GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString, id_user, annotation)
                execute_non_query(query, True, "", "", "", "")
                view_contact()
                clean_field()

                If id_pop_up = "1" Then
                    FormPopUpContact.view_contact(id_company)
                End If

                GroupControl1.Enabled = True
                PDetail.Enabled = False
                BNew.Enabled = True
                BSetDefault.Enabled = True
                BEdit.Enabled = True
            End If
        End If
    End Sub
End Class