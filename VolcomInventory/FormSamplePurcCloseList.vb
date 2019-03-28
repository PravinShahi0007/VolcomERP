Public Class FormSamplePurcCloseList
    Private Sub FormSamplePurcCloseList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_list()
    End Sub

    Sub load_list()
        Dim query As String = "SELECT spd.`id_sample_purc_det`,sp.`sample_purc_number`,ms.`id_sample`,prc.`id_sample_price`,ms.`sample_name`,spd.`sample_purc_det_price`,spd.`sample_purc_det_qty` 
                                ,clr.code_detail_name AS color,division.code_detail_name AS division
                                FROM tb_sample_purc_det spd
                                INNER JOIN tb_sample_purc sp ON sp.`id_sample_purc`=spd.id_sample_purc AND sp.`id_report_status` = '6'
                                INNER JOIN tb_m_sample_price prc ON prc.`id_sample_price`=spd.`id_sample_price`
                                INNER JOIN tb_m_sample ms ON ms.`id_sample`=prc.`id_sample`
                                LEFT JOIN 
                                (
	                                SELECT sc.`id_sample`,cd.`code_detail_name` FROM tb_m_sample_code sc
	                                INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=sc.`id_code_detail`
	                                INNER JOIN tb_m_code c ON c.`id_code`=cd.`id_code` AND c.`id_code`='14'
                                ) clr ON clr.id_sample=ms.`id_sample`
                                LEFT JOIN 
                                (
	                                SELECT sc.`id_sample`,cd.`code_detail_name` FROM tb_m_sample_code sc
	                                INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=sc.`id_code_detail`
	                                INNER JOIN tb_m_code c ON c.`id_code`=cd.`id_code` AND c.`id_code`='16'
                                ) division ON division.id_sample=ms.`id_sample`
                                LEFT JOIN tb_sample_purc_rec_det recd ON recd.`id_sample_purc_rec_det`=spd.`id_sample_purc_det`
                                LEFT JOIN tb_sample_purc_rec rec ON rec.`id_sample_purc_rec`=recd.`id_sample_purc_rec` AND rec.`id_report_status`!=5
                                LEFT JOIN tb_sample_purc_close_det cld ON cld.`id_sample_purc_det`=spd.`id_sample_purc_det`
                                LEFT JOIN tb_sample_purc_close cl ON cl.`id_sample_purc_close`=cld.`id_sample_purc_close` AND cl.`id_report_status`!=5
                                WHERE IFNULL(recd.`sample_purc_rec_det_qty`,0)=0 AND IFNULL(cld.`qty`,0)=0"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAfter.DataSource = data
        GVAfter.BestFitColumns()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormSamplePurcCloseList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

    End Sub
End Class