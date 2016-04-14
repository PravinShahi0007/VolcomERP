Public Class FormSetupNumberHeader

    Private Sub FormSetupNumberHeader_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '==== sample =====
        'purchase
        view_purc_sample()
        TEExsSamplePurc.Text = combine_header_number(TEHeaderSamplePurc.Text, Integer.Parse(TEIncrementSamplePurc.Text), Integer.Parse(TEDigitSamplePurc.Text))
        'receive
        view_rec_sample()
        TEExsSampleRec.Text = combine_header_number(TEHeaderSampleRec.Text, Integer.Parse(TEIncrementSampleRec.Text), Integer.Parse(TEDigitSampleRec.Text))
        'packing list
        view_pl_sample()
        TEExsSamplePR.Text = combine_header_number(TEHeaderSamplePR.Text, Integer.Parse(TEIncrementSamplePR.Text), Integer.Parse(TEDigitSamplePR.Text))
        'payment request
        view_pr_sample()
        TEExsSamplePR.Text = combine_header_number(TEHeaderSamplePR.Text, Integer.Parse(TEIncrementSamplePR.Text), Integer.Parse(TEDigitSamplePR.Text))
        'planning
        view_plan_sample()
        TEExsSamplePlan.Text = combine_header_number(TEHeaderSamplePlan.Text, Integer.Parse(TEIncrementSamplePlan.Text), Integer.Parse(TEDigitSamplePlan.Text))
        'request
        view_req_sample()
        TEExsSampleReq.Text = combine_header_number(TEHeaderSampleReq.Text, Integer.Parse(TEIncrementSampleReq.Text), Integer.Parse(TEDigitSampleReq.Text))
    End Sub

    Sub view_purc_sample()
        Try
            Dim query As String = String.Format("SELECT purc_sample_code_head,purc_sample_code_inc,purc_sample_code_digit FROM tb_opt")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TEHeaderSamplePurc.Text = data.Rows(0)("purc_sample_code_head").ToString
            TEIncrementSamplePurc.Text = data.Rows(0)("purc_sample_code_inc").ToString
            TEDigitSamplePurc.Text = data.Rows(0)("purc_sample_code_digit").ToString
            data.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TEHeaderSamplePurc_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEHeaderSamplePurc.EditValueChanged
        TEExsSamplePurc.Text = combine_header_number(TEHeaderSamplePurc.Text, Integer.Parse(TEIncrementSamplePurc.Text), Integer.Parse(TEDigitSamplePurc.Text))
    End Sub

    Private Sub TEIncrementSamplePurc_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEIncrementSamplePurc.EditValueChanged
        TEExsSamplePurc.Text = combine_header_number(TEHeaderSamplePurc.Text, Integer.Parse(TEIncrementSamplePurc.Text), Integer.Parse(TEDigitSamplePurc.Text))
    End Sub

    Private Sub TEDigitSamplePurc_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEDigitSamplePurc.EditValueChanged
        TEExsSamplePurc.Text = combine_header_number(TEHeaderSamplePurc.Text, Integer.Parse(TEIncrementSamplePurc.Text), Integer.Parse(TEDigitSamplePurc.Text))
    End Sub

    Private Sub BCancelSamplePurc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelSamplePurc.Click
        Close()
    End Sub

    Private Sub BSaveSamplePurc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSaveSamplePurc.Click
        Try
            Dim header, increment, digit As String

            '
            EP_TE_cant_blank(EPPurcSample, TEHeaderSamplePurc)
            '

            If Not formIsValidInPanel(EPPurcSample, PC2) Then
                errorInput()
            Else

                header = TEHeaderSamplePurc.Text
                increment = TEIncrementSamplePurc.Text
                digit = TEDigitSamplePurc.Text

                Dim query As String = String.Format("UPDATE tb_opt SET purc_sample_code_head='{0}', purc_sample_code_inc='{1}', purc_sample_code_digit='{2}'", header, increment, digit)
                execute_non_query(query, True, "", "", "", "")
                Close()
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub TEHeaderSamplePurc_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEHeaderSamplePurc.Validating
        EP_TE_cant_blank(EPPurcSample, TEHeaderSamplePurc)
    End Sub
    '==== header sample rec ============
    '
    Sub view_rec_sample()
        Try
            Dim query As String = String.Format("SELECT rec_sample_code_head,rec_sample_code_inc,rec_sample_code_digit FROM tb_opt")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TEHeaderSampleRec.Text = data.Rows(0)("rec_sample_code_head").ToString
            TEIncrementSampleRec.Text = data.Rows(0)("rec_sample_code_inc").ToString
            TEDigitSampleRec.Text = data.Rows(0)("rec_sample_code_digit").ToString
            data.Dispose()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BCancelSampleRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelSampleRec.Click
        Close()
    End Sub

    Private Sub TEHeaderSampleRec_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEHeaderSampleRec.EditValueChanged
        TEExsSampleRec.Text = combine_header_number(TEHeaderSampleRec.Text, Integer.Parse(TEIncrementSampleRec.Text), Integer.Parse(TEDigitSampleRec.Text))
    End Sub

    Private Sub TEIncrementSampleRec_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEIncrementSampleRec.EditValueChanged
        TEExsSampleRec.Text = combine_header_number(TEHeaderSampleRec.Text, Integer.Parse(TEIncrementSampleRec.Text), Integer.Parse(TEDigitSampleRec.Text))
    End Sub

    Private Sub TEDigitSampleRec_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEDigitSampleRec.EditValueChanged
        TEExsSampleRec.Text = combine_header_number(TEHeaderSampleRec.Text, Integer.Parse(TEIncrementSampleRec.Text), Integer.Parse(TEDigitSampleRec.Text))
    End Sub

    Private Sub FormSetupNumberHeader_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BSaveSampleRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSaveSampleRec.Click
        Try
            Dim header, increment, digit As String

            '
            EP_TE_cant_blank(EPPurcSample, TEHeaderSampleRec)
            '

            If Not formIsValidInPanel(EPPurcSample, PC2) Then
                errorInput()
            Else

                header = TEHeaderSampleRec.Text
                increment = TEIncrementSampleRec.Text
                digit = TEDigitSampleRec.Text

                Dim query As String = String.Format("UPDATE tb_opt SET purc_sample_code_head='{0}', purc_sample_code_inc='{1}', purc_sample_code_digit='{2}'", header, increment, digit)
                execute_non_query(query, True, "", "", "", "")
                Close()
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub TEHeaderSampleRec_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEHeaderSampleRec.Validating
        EP_TE_cant_blank(EPPurcSample, TEHeaderSampleRec)
    End Sub
    '============= sample PL =============
    Private Sub TEHeaderSamplePL_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEHeaderSamplePL.Validating
        EP_TE_cant_blank(EPPurcSample, TEHeaderSamplePL)
    End Sub
    '
    Sub view_pl_sample()
        Try
            Dim query As String = String.Format("SELECT pl_sample_code_head,pl_sample_code_inc,pl_sample_code_digit FROM tb_opt")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TEHeaderSamplePL.Text = data.Rows(0)("pl_sample_code_head").ToString
            TEIncrementSamplePL.Text = data.Rows(0)("pl_sample_code_inc").ToString
            TEDigitSamplePL.Text = data.Rows(0)("pl_sample_code_digit").ToString
            data.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BCancelSamplePL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelSamplePL.Click
        Close()
    End Sub

    Private Sub TEHeaderSamplePL_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEHeaderSamplePL.EditValueChanged
        TEExsSamplePL.Text = combine_header_number(TEHeaderSamplePL.Text, Integer.Parse(TEIncrementSamplePL.Text), Integer.Parse(TEDigitSamplePL.Text))
    End Sub

    Private Sub TEIncrementSamplePL_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEIncrementSamplePL.EditValueChanged
        TEExsSamplePL.Text = combine_header_number(TEHeaderSamplePL.Text, Integer.Parse(TEIncrementSamplePL.Text), Integer.Parse(TEDigitSamplePL.Text))
    End Sub

    Private Sub TEDigitSamplePL_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEDigitSamplePL.EditValueChanged
        TEExsSamplePL.Text = combine_header_number(TEHeaderSamplePL.Text, Integer.Parse(TEIncrementSamplePL.Text), Integer.Parse(TEDigitSamplePL.Text))
    End Sub

    Private Sub BSaveSamplePL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSaveSamplePL.Click
        Try
            Dim header, increment, digit As String

            '
            EP_TE_cant_blank(EPPurcSample, TEHeaderSamplePL)
            '

            If Not formIsValidInPanel(EPPurcSample, PCSamplePL) Then
                errorInput()
            Else

                header = TEHeaderSamplePL.Text
                increment = TEIncrementSamplePL.Text
                digit = TEDigitSamplePL.Text

                Dim query As String = String.Format("UPDATE tb_opt SET pl_sample_code_head='{0}', pl_sample_code_inc='{1}', pl_sample_code_digit='{2}'", header, increment, digit)
                execute_non_query(query, True, "", "", "", "")
                Close()
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    '=============== Sample PR ================
    Private Sub TEHeaderSamplePR_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEHeaderSamplePR.Validating
        EP_TE_cant_blank(EPPurcSample, TEHeaderSamplePR)
    End Sub
    '
    Sub view_pr_sample()
        Try
            Dim query As String = String.Format("SELECT pr_sample_code_head,pr_sample_code_inc,pr_sample_code_digit FROM tb_opt")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TEHeaderSamplePR.Text = data.Rows(0)("pr_sample_code_head").ToString
            TEIncrementSamplePR.Text = data.Rows(0)("pr_sample_code_inc").ToString
            TEDigitSamplePR.Text = data.Rows(0)("pr_sample_code_digit").ToString
            data.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TEHeaderSamplePR_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEHeaderSamplePR.EditValueChanged
        TEExsSamplePR.Text = combine_header_number(TEHeaderSamplePR.Text, Integer.Parse(TEIncrementSamplePR.Text), Integer.Parse(TEDigitSamplePR.Text))
    End Sub

    Private Sub TEIncrementSamplePR_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEIncrementSamplePR.EditValueChanged
        TEExsSamplePR.Text = combine_header_number(TEHeaderSamplePR.Text, Integer.Parse(TEIncrementSamplePR.Text), Integer.Parse(TEDigitSamplePR.Text))
    End Sub

    Private Sub TEDigitSamplePR_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEDigitSamplePR.EditValueChanged
        TEExsSamplePR.Text = combine_header_number(TEHeaderSamplePR.Text, Integer.Parse(TEIncrementSamplePR.Text), Integer.Parse(TEDigitSamplePR.Text))
    End Sub

    Private Sub BCancelSamplePR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelSamplePR.Click
        Close()
    End Sub

    Private Sub BSaveSamplePR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSaveSamplePR.Click
        Try
            Dim header, increment, digit As String

            '
            EP_TE_cant_blank(EPPurcSample, TEHeaderSamplePR)
            '

            If Not formIsValidInPanel(EPPurcSample, PCSamplePR) Then
                errorInput()
            Else

                header = TEHeaderSamplePR.Text
                increment = TEIncrementSamplePR.Text
                digit = TEDigitSamplePR.Text

                Dim query As String = String.Format("UPDATE tb_opt SET pr_sample_code_head='{0}', pr_sample_code_inc='{1}', pr_sample_code_digit='{2}'", header, increment, digit)
                execute_non_query(query, True, "", "", "", "")
                Close()
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    '==================== header sample plan ==============
    Sub view_plan_sample()
        Try
            Dim query As String = String.Format("SELECT plan_sample_code_head,plan_sample_code_inc,plan_sample_code_digit FROM tb_opt")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TEHeaderSamplePlan.Text = data.Rows(0)("plan_sample_code_head").ToString
            TEIncrementSamplePlan.Text = data.Rows(0)("plan_sample_code_inc").ToString
            TEDigitSamplePlan.Text = data.Rows(0)("plan_sample_code_digit").ToString
            data.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TEHeaderSamplePlan_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEHeaderSamplePlan.Validating
        EP_TE_cant_blank(EPPurcSample, TEHeaderSamplePlan)
    End Sub

    Private Sub TEHeaderSamplePlan_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEHeaderSamplePlan.EditValueChanged
        TEExsSamplePlan.Text = combine_header_number(TEHeaderSamplePlan.Text, Integer.Parse(TEIncrementSamplePlan.Text), Integer.Parse(TEDigitSamplePlan.Text))
    End Sub

    Private Sub TEIncrementSamplePlan_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEIncrementSamplePlan.EditValueChanged
        TEExsSamplePlan.Text = combine_header_number(TEHeaderSamplePlan.Text, Integer.Parse(TEIncrementSamplePlan.Text), Integer.Parse(TEDigitSamplePlan.Text))
    End Sub

    Private Sub TEDigitSamplePlan_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEDigitSamplePlan.EditValueChanged
        TEExsSamplePlan.Text = combine_header_number(TEHeaderSamplePlan.Text, Integer.Parse(TEIncrementSamplePlan.Text), Integer.Parse(TEDigitSamplePlan.Text))
    End Sub

    Private Sub BCancelSamplePlan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelSamplePlan.Click
        Close()
    End Sub

    Private Sub BSaveSamplePlan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSaveSamplePlan.Click
        Try
            Dim header, increment, digit As String

            '
            EP_TE_cant_blank(EPPurcSample, TEHeaderSamplePlan)
            '

            If Not formIsValidInPanel(EPPurcSample, PCSamplePlan) Then
                errorInput()
            Else

                header = TEHeaderSamplePlan.Text
                increment = TEIncrementSamplePlan.Text
                digit = TEDigitSamplePlan.Text

                Dim query As String = String.Format("UPDATE tb_opt SET plan_sample_code_head='{0}', plan_sample_code_inc='{1}', plan_sample_code_digit='{2}'", header, increment, digit)
                execute_non_query(query, True, "", "", "", "")
                Close()
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    '======================= header sample req ======================
    Sub view_req_sample()
        Try
            Dim query As String = String.Format("SELECT req_sample_del_code_head,req_sample_del_code_inc,req_sample_del_code_digit FROM tb_opt")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TEHeaderSampleReq.Text = data.Rows(0)("req_sample_del_code_head").ToString
            TEIncrementSampleReq.Text = data.Rows(0)("req_sample_del_code_inc").ToString
            TEDigitSampleReq.Text = data.Rows(0)("req_sample_del_code_digit").ToString
            data.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TEHeaderSampleReq_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEHeaderSampleReq.Validating
        EP_TE_cant_blank(EPPurcSample, TEHeaderSampleReq)
    End Sub

    Private Sub TEHeaderSampleReq_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEHeaderSampleReq.EditValueChanged
        TEExsSampleReq.Text = combine_header_number(TEHeaderSampleReq.Text, Integer.Parse(TEIncrementSampleReq.Text), Integer.Parse(TEDigitSampleReq.Text))
    End Sub

    Private Sub TEIncrementSampleReq_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEIncrementSampleReq.EditValueChanged
        TEExsSampleReq.Text = combine_header_number(TEHeaderSampleReq.Text, Integer.Parse(TEIncrementSampleReq.Text), Integer.Parse(TEDigitSampleReq.Text))
    End Sub

    Private Sub TEDigitSampleReq_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEDigitSampleReq.EditValueChanged
        TEExsSampleReq.Text = combine_header_number(TEHeaderSampleReq.Text, Integer.Parse(TEIncrementSampleReq.Text), Integer.Parse(TEDigitSampleReq.Text))
    End Sub

    Private Sub BCancelSampleReq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelSampleReq.Click
        Close()
    End Sub

    Private Sub BSaveSampleReq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSaveSampleReq.Click
        Try
            Dim header, increment, digit As String
            '
            EP_TE_cant_blank(EPPurcSample, TEHeaderSampleReq)
            '
            If Not formIsValidInPanel(EPPurcSample, PCSampleReq) Then
                errorInput()
            Else

                header = TEHeaderSampleReq.Text
                increment = TEIncrementSampleReq.Text
                digit = TEDigitSampleReq.Text

                Dim query As String = String.Format("UPDATE tb_opt SET req_sample_del_code_head='{0}', req_sample_del_code_inc='{1}', req_sample_del_code_digit='{2}'", header, increment, digit)
                execute_non_query(query, True, "", "", "", "")
                Close()
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
End Class