Public Class FormProductionWOProgressDet
    Public id_wo As String = "-1"
    Public id_wo_prog As String = "-1"
    Private Sub FormProductionWOProgressDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query As String = String.Format("SELECT IFNULL(MAX(prod_order_wo_prog_percent),0) as prod_order_wo_prog_percent FROM tb_prod_order_wo_prog WHERE id_prod_order_wo = '{0}'", id_wo)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If Not id_wo_prog = "-1" Then
            'edit
            query = String.Format("SELECT * FROM tb_prod_order_wo_prog WHERE id_prod_order_wo_prog='" & id_wo_prog & "'")
            data = execute_query(query, -1, True, "", "", "", "")

            MENote.Text = data.Rows(0)("prod_order_wo_prog_note").ToString
            SEProgress.EditValue = Decimal.Parse(data.Rows(0)("prod_order_wo_prog_percent").ToString)

            SEProgress.Enabled = False
        Else
            'new
            If data.Rows.Count > 0 Then
                SEProgress.Properties.MinValue = Decimal.Parse(data.Rows(0)("prod_order_wo_prog_percent").ToString)
            Else
                SEProgress.Properties.MinValue = 0
            End If
        End If
    End Sub

    Private Sub FormProductionWOProgressDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim note As String = MENote.Text
        Dim percent As Decimal = SEProgress.EditValue
        If id_wo_prog = "-1" Then
            'new
            Dim query As String = "INSERT INTO tb_prod_order_wo_prog(id_prod_order_wo,prod_order_wo_prog_note,prod_order_wo_prog_date,prod_order_wo_prog_percent) VALUES('{0}','{1}',NOW(),'{2}');SELECT LAST_INSERT_ID(); "
            query = String.Format(query, id_wo, note, decimalSQL(percent.ToString))
            Dim last_id As String = execute_query(query, 0, True, "", "", "", "")
            Close()
            FormProductionDet.view_wo()
            FormProductionWOProgress.view_progress()
            FormProductionWOProgress.GVNote.FocusedRowHandle = find_row(FormProductionWOProgress.GVNote, "id_prod_order_wo_prog", last_id)
        Else
            'edit
            Dim query As String = "UPDATE tb_prod_order_wo_prog SET prod_order_wo_prog_note='{0}',prod_order_wo_prog_date=NOW() WHERE id_prod_order_wo_prog='{1}'"
            query = String.Format(query, note, id_wo_prog)
            execute_non_query(query, True, "", "", "", "")
            Close()
            FormProductionDet.view_wo()
            FormProductionWOProgress.view_progress()
            FormProductionWOProgress.GVNote.FocusedRowHandle = find_row(FormProductionWOProgress.GVNote, "id_prod_order_wo_prog", id_wo_prog)
        End If
    End Sub
End Class