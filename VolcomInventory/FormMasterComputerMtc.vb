Public Class FormMasterComputerMtc
    Public Action As String
    Public id_purc_rec_asset As String
    Public hw_name As String
    Public id_det_mtc As String

    Private Sub FormMasterComputerMtc_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim query As String = "SELECT id_employee, employee_name FROM tb_m_employee WHERE id_employee_active = '1'"
        viewSearchLookupQuery(LEusernow, query, "id_employee", "employee_name", "id_employee")

        Dim query2 As String = "SELECT * FROM tb_status_mtc_it"
        viewSearchLookupQuery(LEstatus, query2, "id_status_mtc", "status_mtc", "id_status_mtc")

        Dim query3 As String = "SELECT id_employee, employee_name FROM tb_m_employee WHERE id_departement = '7'"
        viewSearchLookupQuery(LEpic, query3, "id_employee", "employee_name", "id_employee")

        If Action = "edit" Then
            Dim queryedit As String = "SELECT * FROM tb_det_mtc_it WHERE id_det_mtc = '" & id_det_mtc & "'"
            Dim data As DataTable = execute_query(queryedit, -1, True, "", "", "", "")
            TEasset.Text = data.Rows(0)("id_purc_rec_asset").ToString
            TEhwname.Text = data.Rows(0)("hw_name").ToString
            DEtglmtc.EditValue = data.Rows(0)("date_mtc").ToString
            LEusernow.EditValue = data.Rows(0)("now_user").ToString
            TEproblem.Text = data.Rows(0)("problem").ToString
            MEdtlmtc.EditValue = data.Rows(0)("dtl_problem").ToString
            LEstatus.EditValue = data.Rows(0)("id_status_mtc").ToString
            LEpic.EditValue = data.Rows(0)("pic").ToString
        Else
            If Action = "ins" Then
                Dim dtn As Date = getTimeDB()
                TEasset.Text = id_purc_rec_asset
                TEhwname.Text = hw_name
                DEtglmtc.EditValue = dtn
            Else
                Dim dtn As Date = getTimeDB()
                DEtglmtc.EditValue = dtn
            End If
        End If
    End Sub


    Private Sub BTsave_Click(sender As Object, e As EventArgs) Handles BTsave.Click
        Dim asset As String = TEasset.Text
        Dim hwname As String = TEhwname.Text
        Dim tglmtc As String = Date.Parse(DEtglmtc.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim usernow As String = LEusernow.EditValue
        Dim prblm As String = TEproblem.Text
        Dim dtlmtc As String = MEdtlmtc.EditValue
        Dim stts As String = LEstatus.EditValue
        Dim picmtc As String = LEpic.EditValue

        If hwname = "" Or prblm = "" Or dtlmtc = "" Or stts = "" Or picmtc = "" Then
            MessageBox.Show("Mohon Lengkapi Data !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If Action = "ins" Then
                If asset = "" Then
                    asset = "NULL"
                Else
                    asset = "'" + asset + "'"
                End If

                Dim query As String = "INSERT INTO tb_det_mtc_it (id_purc_rec_asset,date_mtc,now_user,problem,dtl_problem,id_status_mtc,pic,hw_name) 
VALUES (" & asset & ",'" & tglmtc & "','" & usernow & "','" & prblm & "','" & dtlmtc & "','" & stts & "','" & picmtc & "','" & hwname & "')"
                execute_non_query(query, True, "", "", "", "")
                FormMasterComputer.loadmtc()
                FormMasterComputer.loadlist()
                MessageBox.Show("Data telah disimpan!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Close()
            Else
                Dim query As String = "UPDATE tb_det_mtc_it SET date_mtc = '" & tglmtc & "', now_user = '" & usernow & "', problem = '" & prblm & "', dtl_problem = '" & dtlmtc & "', id_status_mtc = '" & stts & "', pic = '" & picmtc & "', hw_name = '" & hwname & "'
WHERE id_det_mtc = '" & id_det_mtc & "'"
                execute_non_query(query, True, "", "", "", "")
                FormMasterComputer.loadmtc()
                FormMasterComputer.loadlist()
                MessageBox.Show("Data telah diupdate!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Close()
            End If

        End If
    End Sub

    Private Sub FormMasterComputerMtc_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Dispose()

    End Sub

    Private Sub BTcancel_Click(sender As Object, e As EventArgs) Handles BTcancel.Click
        Close()

    End Sub
End Class