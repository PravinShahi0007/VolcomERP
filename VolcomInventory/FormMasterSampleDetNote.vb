Public Class FormMasterSampleDetNote 
    Public id_sample As String = "-1"
    Public id_sample_note As String = "-1"

    Private Sub FormMasterSampleDetNote_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query As String = String.Format("SELECT sample_code,sample_name FROM tb_m_sample WHERE id_sample = '{0}'", id_sample)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TESampleCode.Text = data.Rows(0)("sample_code").ToString
        TEName.Text = data.Rows(0)("sample_name").ToString

        pre_viewImages("1", PicSample, id_sample, False)

        BViewImage.Visible = True

        If id_sample_note <> "-1" Then
            'edit
            query = String.Format("SELECT sample_note FROM tb_m_sample_note WHERE id_sample_note = '{0}'", id_sample_note)
            data = execute_query(query, -1, True, "", "", "", "")

            MENote.Text = data.Rows(0)("sample_note").ToString
        End If
    End Sub

    Private Sub BViewImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BViewImage.Click
        pre_viewImages("1", PicSample, id_sample, True)
    End Sub

    Private Sub FormMasterSampleDetNote_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAccept.Click
        Dim sample_notex As String = MENote.Text

        If id_sample_note <> "-1" Then
            'edit
            Dim query As String = String.Format("UPDATE tb_m_sample_note SET sample_note='{0}',sample_note_datetime=NOW() WHERE id_sample_note='{1}'", sample_notex, id_sample_note)
            execute_non_query(query, True, "", "", "", "")
            FormMasterSampleDet.view_sample_note(id_sample)
            Close()
        Else
            'new
            Dim query As String = String.Format("INSERT INTO tb_m_sample_note(id_sample,sample_note,sample_note_datetime) VALUES('{0}','{1}',NOW())", id_sample, sample_notex)
            execute_non_query(query, True, "", "", "", "")
            FormMasterSampleDet.view_sample_note(id_sample)
            Close()
        End If
    End Sub
End Class