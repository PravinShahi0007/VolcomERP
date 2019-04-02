Public Class FormSamplePurcCloseDet
    Public id_close As String = "-1"

    Private Sub FormSamplePurcCloseDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEDateCreated.EditValue = Now
        TENumber.Text = "[auto generate]"
        TECreatedBy.Text = "[auto generate]"
        '
        load_Det()
    End Sub

    Sub load_Det()
        Dim query As String = "SELECT spcd.*,sp.sample_purc_number,ms.`sample_name`,ms.`sample_us_code` FROM `tb_sample_purc_close_det` spcd
INNER JOIN tb_sample_purc_det spd ON spd.`id_sample_purc_det`=spcd.`id_sample_purc_close_det`
INNER JOIN tb_sample_purc sp ON sp.`id_sample_purc`=spd.`id_sample_purc`
INNER JOIN tb_m_sample_price prc ON prc.`id_sample_price`=spd.`id_sample_price`
INNER JOIN tb_m_sample ms ON ms.`id_sample`=prc.id_sample
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
WHERE spcd.id_sample_purc_close='" & id_close & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAfter.DataSource = data
        GVAfter.BestFitColumns()
    End Sub

    Private Sub BDel_Click(sender As Object, e As EventArgs) Handles BDel.Click

    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        FormSamplePurcCloseList.ShowDialog()
    End Sub
End Class