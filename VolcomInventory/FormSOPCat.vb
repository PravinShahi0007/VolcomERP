Public Class FormSOPCat
    Dim id_departement As String = "-1"
    Private Sub FormSOPCat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_departement()
    End Sub

    Sub load_departement()
        Dim q As String = "SELECT id_departement,departement FROM tb_m_departement"
        viewSearchLookupQuery(SLEDepartement, q, "id_departement", "departement", "id_departement")
    End Sub

    Private Sub Bview_Click(sender As Object, e As EventArgs) Handles Bview.Click
        PCAddMasterProsedur.Visible = True
        If GVProsedur.RowCount > 0 Then
            XTPSubProsedur.PageVisible = True
        Else
            XTPSubProsedur.PageVisible = False
        End If

        id_departement = SLEDepartement.EditValue.ToString
    End Sub

    Sub load_prosedur()

    End Sub

    Private Sub BAddProsedur_Click(sender As Object, e As EventArgs) Handles BAddProsedur.Click
        If Not TEKodeProsedur.Text = "" And Not TEProsedur.Text = "" And Not id_departement = "-1" Then
            'check first
            Dim q As String = "SELECT * FROM tb_sop_prosedur WHERE (sop_prosedur_code='" & addSlashes(TEKodeProsedur.Text) & "' OR sop_prosedur='" & addSlashes(TEProsedur.Text) & "') AND id_departement='" & id_departement & "' "
            Dim dtc As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dtc.Rows.Count > 0 Then
                warningCustom("Kode/ nama SOP prosedur sudah pernah digunakan.")
            Else
                q = "INSERT INTO tb_sop_prosedur(sop_prosedur_code,sop_prosedur,id_departement) VALUES('" & addSlashes(TEKodeProsedur.Text) & "','" & addSlashes(TEProsedur.Text) & "','" & id_departement & "')"
                execute_non_query(q, True, "", "", "", "")
                '
                TEKodeProsedur.Text = ""
                TEProsedur.Text = ""

                load_prosedur()
            End If
        End If
    End Sub
End Class