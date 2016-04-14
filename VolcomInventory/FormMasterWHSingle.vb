Public Class FormMasterWHSingle 
    Public action As String
    Public id_wh_locator As String
    Public id_comp As String = FormMasterWH.GVWH.GetFocusedRowCellDisplayText("id_comp").ToString
    Public comp_name As String = FormMasterWH.GVWH.GetFocusedRowCellDisplayText("comp_name").ToString
    'Form Load
    Private Sub FormMasterWHSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LabelSubTitle.Text = "Warehouse : " + comp_name.ToString
        If action = "upd" Then
            Try
                Dim query As String = "SELECT * FROM tb_m_wh_locator a WHERE a.id_wh_locator = '" + id_wh_locator + "'"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                TxtLocatorCode.Text = data.Rows(0)("wh_locator_code").ToString
                TxtRackName.Text = data.Rows(0)("wh_locator").ToString
                MEDesription.Text = data.Rows(0)("wh_locator_description").ToString
            Catch ex As Exception
                errorConnection()
                Close()
            End Try
        End If
    End Sub
    'Form Closed
    Private Sub FormMasterWHSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    'Validating
    Private Sub TxtLocatorCode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtLocatorCode.Validating
        Dim query_jml As String
        If action = "ins" Then
            'new
            query_jml = String.Format("SELECT COUNT(id_wh_locator) FROM tb_m_wh_locator WHERE wh_locator_code='{0}'", TxtLocatorCode.Text)
        Else
            query_jml = String.Format("SELECT COUNT(id_wh_locator) FROM tb_m_wh_locator WHERE wh_locator_code='{0}' AND id_wh_locator!='{1}'", TxtLocatorCode.Text, id_wh_locator)
        End If

        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(EPWH, TxtLocatorCode, "1")
        Else
            EP_TE_cant_blank(EPWH, TxtLocatorCode)
        End If
    End Sub
    Private Sub TxtRackName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtRackName.Validating
        EP_TE_cant_blank(EPWH, TxtRackName)
    End Sub
    'Save
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ValidateChildren()
        If Not formIsValid(EPWH) Then
            errorInput()
        Else
            Dim query As String
            Dim wh_locator_code As String = addSlashes(TxtLocatorCode.Text)
            Dim wh_locator As String = addSlashes(TxtRackName.Text)
            Dim wh_locator_description As String = addSlashes(MEDesription.Text)
            If action = "ins" Then
                Try
                    query = "INSERT INTO tb_m_wh_locator(id_comp, wh_locator_code, wh_locator, wh_locator_description) VALUES ('" + id_comp + "', '" + wh_locator_code + "', '" + wh_locator + "', '" + wh_locator_description + "')"
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterWH.viewWHLocator()
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            ElseIf action = "upd" Then
                Try
                    query = "UPDATE tb_m_wh_locator SET id_comp= '" + id_comp + "', wh_locator_code = '" + wh_locator_code + "', wh_locator = '" + wh_locator + "', wh_locator_description = '" + wh_locator_description + "' WHERE id_wh_locator = '" + id_wh_locator + "'"
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterWH.viewWHLocator()
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
        End If
    End Sub
End Class