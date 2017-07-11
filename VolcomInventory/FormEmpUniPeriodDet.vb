Public Class FormEmpUniPeriodDet
    Public action As String = "-1"
    Public id_emp_uni_period As String = "-1"

    Private Sub FormEmpUniPeriodDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            XTCUni.Enabled = False
            BtnSave.Text = "Create New"
        Else
            XTCUni.Enabled = True
            BtnSave.Text = "Save"
        End If
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If DEStart.Text <> "" And DEEnd.Text <> "" And DEDist.Text <> "" Then
            Dim selection_date_start As String = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim selection_date_end As String = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")

            If action = "ins" Then
                Dim query As String = "INSERT INTO tb_emp_uni_budget (period_name, selection_date_start, selection_date_end, created_date, distribution_date) VALUES "
                query += ""
            End If
        Else
            stopCustom("Period can't blank")
        End If

    End Sub
End Class