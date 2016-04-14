Public Class FormSOHPeriodeDet 
    Public id_soh_periode As String = "-1"

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormSOHPeriodeDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormSOHPeriodeDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not id_soh_periode = "-1" Then 'update
            Dim query As String = "SELECT soh_periode,date_start,date_end FROM tb_soh_periode WHERE id_soh_periode='" + id_soh_periode + "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TxtSeasonPrintedName.Text = data.Rows(0)("soh_periode").ToString

            Dim date_start() As String = Data.Rows(0)("date_start").ToString.Split(" ")
            DEStart.Text = date_start(0)

            Dim date_end() As String = Data.Rows(0)("date_end").ToString.Split(" ")
            DEEnd.Text = date_end(0)
        End If
    End Sub
    'Validate Period Name
    Private Sub TxtSeasonPrintedName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtSeasonPrintedName.Validating
        EP_TE_cant_blank(EPPeriodeSOH, TxtSeasonPrintedName)
    End Sub
    'Validating Start Date
    Private Sub DEStart_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DEStart.Validating
        EP_DE_cant_blank(EPPeriodeSOH, DEStart)
    End Sub
    'Validating End Date
    Private Sub DEEnd_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DEEnd.Validating
        EP_DE_cant_blank(EPPeriodeSOH, DEEnd)
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ValidateChildren()
        If Not formIsValid(EPPeriodeSOH) Then
            errorInput()
        Else
            Dim periode_name As String = TxtSeasonPrintedName.Text.ToString
            Dim date_start As String = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim date_end As String = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")

            Dim query As String = ""

            If id_soh_periode = "-1" Then
                query = "INSERT INTO tb_soh_periode(soh_periode,date_start,date_end,id_report_status) VALUES('" & periode_name & "','" & date_start & "','" & date_end & "','1'); SELECT LAST_INSERT_ID(); "
                id_soh_periode = execute_query(query, 0, True, "", "", "", "")
                FormSOHPeriode.view_soh()
                FormSOHPeriode.GVSOHPeriode.FocusedRowHandle = find_row(FormSOHPeriode.GVSOHPeriode, "id_soh_periode", id_soh_periode)
                Close()
            Else
                query = "UPDATE tb_soh_periode SET soh_periode='" & periode_name & "',date_start='" & date_start & "',date_end='" & date_end & "' WHERE id_soh_periode='" & id_soh_periode & "'"
                execute_non_query(query, True, "", "", "", "")

                FormSOHPeriode.view_soh()
                FormSOHPeriode.GVSOHPeriode.FocusedRowHandle = find_row(FormSOHPeriode.GVSOHPeriode, "id_soh_periode", id_soh_periode)
                Close()
            End If
        End If
    End Sub
End Class