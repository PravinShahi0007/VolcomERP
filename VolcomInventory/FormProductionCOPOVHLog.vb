Public Class FormProductionCOPOVHLog
    Dim source_path As String = get_setup_field("upload_dir")
    Public id_wo As String = "-1"
    Private Sub FormProductionCOPOVHLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_log()
    End Sub
    Sub load_log()
        Dim query As String = "SELECT logd.`id_wo_log`,logd.`datetime_log`,logd.`old_kurs`,logd.`old_price`,logd.`new_kurs`,logd.`new_price`,comp_old.`comp_name` AS old_vendor,comp_new.`comp_name` AS new_vendor,cur_old.`currency` AS old_curr,cur_new.`currency` AS new_curr,emp.`employee_name`,CONCAT(id_wo_log,ext) AS filename,logd.`doc_desc` FROM `tb_prod_order_wo_log` logd
                                LEFT JOIN tb_m_ovh_price ovhp_old ON logd.`old_id_ovh_price`=`ovhp_old`.`id_ovh_price`
                                LEFT JOIN tb_m_comp_contact cc_old ON cc_old.`id_comp_contact`=ovhp_old.`id_comp_contact`
                                LEFT JOIN tb_m_comp comp_old ON comp_old.`id_comp`=cc_old.`id_comp`
                                LEFT JOIN tb_m_ovh_price ovhp_new ON logd.`new_id_ovh_price`=`ovhp_new`.`id_ovh_price`
                                LEFT JOIN tb_m_comp_contact cc_new ON cc_new.`id_comp_contact`=ovhp_new.`id_comp_contact`
                                LEFT JOIN tb_m_comp comp_new ON comp_new.`id_comp`=cc_new.`id_comp`
                                INNER JOIN tb_lookup_currency cur_old ON cur_old.`id_currency`=logd.`old_curr`
                                INNER JOIN tb_lookup_currency cur_new ON cur_new.`id_currency`=logd.`new_curr`
                                INNER JOIN tb_m_user usr ON usr.`id_user`=logd.`id_user`
                                INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
                                WHERE logd.id_wo='" & id_wo & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCLog.DataSource = data
        GVLog.BestFitColumns()
    End Sub
    Private Sub RICE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RICE.Click
        Try
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            'download
            My.Computer.Network.DownloadFile(source_path & "ProdCOP" & "\" & GVLog.GetFocusedRowCellValue("filename").ToString, path & "SupportDoc" & "_" & GVLog.GetFocusedRowCellValue("doc_desc").ToString & "_" & GVLog.GetFocusedRowCellValue("filename").ToString, "", "", True, 100, True)
            'open folder
            If IO.File.Exists(path & "SupportDoc" & "_" & GVLog.GetFocusedRowCellValue("doc_desc").ToString & "_" & GVLog.GetFocusedRowCellValue("filename").ToString) Then
                Dim open_folder As ProcessStartInfo = New ProcessStartInfo()
                open_folder.WindowStyle = ProcessWindowStyle.Maximized
                open_folder.FileName = "explorer.exe"
                open_folder.Arguments = "/select,""" & path & "SupportDoc" & "_" & GVLog.GetFocusedRowCellValue("doc_desc").ToString & "_" & GVLog.GetFocusedRowCellValue("filename").ToString & """"
                Process.Start(open_folder)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RICE_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RICE.MouseHover
        Cursor = Cursors.Hand
    End Sub

    Private Sub RICE_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RICE.MouseLeave
        Cursor = Cursors.Default
    End Sub
End Class