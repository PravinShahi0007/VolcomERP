Public Class FormMasterWHDrawerSingle 
    Public action As String
    Public id_wh_locator As String = FormMasterWH.GVLocator.GetFocusedRowCellDisplayText("id_wh_locator").ToString
    Public id_wh_rack As String = FormMasterWH.GVRack.GetFocusedRowCellDisplayText("id_wh_rack").ToString
    Public id_wh_drawer As String
    Public comp_name As String = FormMasterWH.GVWH.GetFocusedRowCellDisplayText("comp_name").ToString
    Public locator_name As String = FormMasterWH.GVLocator.GetFocusedRowCellDisplayText("wh_locator").ToString
    Public rack_name As String = FormMasterWH.GVRack.GetFocusedRowCellDisplayText("wh_rack").ToString
    'Form Load
    Private Sub FormMasterWHSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LabelSubTitle.Text = "Warehouse/Locator/Rack : " + comp_name.ToString + "/" + locator_name + "/" + rack_name
        If action = "upd" Then
            Try
                Dim query As String = "SELECT * FROM tb_m_wh_drawer a WHERE a.id_wh_drawer = '" + id_wh_drawer + "'"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                TxtRackCode.Text = data.Rows(0)("wh_drawer_code").ToString
                TxtRackName.Text = data.Rows(0)("wh_drawer").ToString
                MEDesription.Text = data.Rows(0)("wh_drawer_description").ToString
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
    Private Sub TxtLocatorCode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtRackCode.Validating
        Dim query_jml As String
        If action = "ins" Then
            'new
            query_jml = String.Format("SELECT COUNT(id_wh_drawer) FROM tb_m_wh_drawer WHERE wh_drawer_code='{0}'", TxtRackCode.Text)
        Else
            query_jml = String.Format("SELECT COUNT(id_wh_drawer) FROM tb_m_wh_drawer WHERE wh_drawer_code='{0}' AND id_wh_drawer!='{1}'", TxtRackCode.Text, id_wh_drawer)
        End If

        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(EPWH, TxtRackCode, "1")
        Else
            EP_TE_cant_blank(EPWH, TxtRackCode)
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
            Dim wh_drawer_code As String = addSlashes(TxtRackCode.Text)
            Dim wh_drawer As String = addSlashes(TxtRackName.Text)
            Dim wh_drawer_description As String = addSlashes(MEDesription.Text)
            If action = "ins" Then
                Try
                    query = "INSERT INTO tb_m_wh_drawer(id_wh_rack, wh_drawer_code, wh_drawer, wh_drawer_description) VALUES ('" + id_wh_rack + "', '" + wh_drawer_code + "', '" + wh_drawer + "', '" + wh_drawer_description + "')"
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterWH.viewDrawer()
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            ElseIf action = "upd" Then
                Try
                    query = "UPDATE tb_m_wh_drawer SET id_wh_rack= '" + id_wh_rack + "', wh_drawer_code = '" + wh_drawer_code + "', wh_drawer = '" + wh_drawer + "', wh_drawer_description = '" + wh_drawer_description + "' WHERE id_wh_drawer = '" + id_wh_drawer + "'"
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterWH.viewDrawer()
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
        End If
    End Sub
End Class