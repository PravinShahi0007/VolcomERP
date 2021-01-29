Public Class FormPurcAssetDep
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormPurcAssetDep_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormPurcAssetDep_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEReffDate.EditValue = Now
        DECreatedDate.EditValue = Now
        '
        TENumber.Text = "[auto number]"
        TECreatedDate.Text = "[auto]"
    End Sub

    Sub load_det()
        Dim q As String = ""
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCDepreciation.DataSource = dt
        GVDepreciation.BestFitColumns()
    End Sub

    Private Sub DEReffDate_EditValueChanged(sender As Object, e As EventArgs) Handles DEReffDate.EditValueChanged
        Try
            DEReffDate.EditValue = New DateTime(DEReffDate.EditValue.Year, DEReffDate.EditValue.Month, Date.DaysInMonth(DEReffDate.EditValue.Year, DEReffDate.EditValue.Month))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BLoadAsset_Click(sender As Object, e As EventArgs) Handles BLoadAsset.Click
        Dim q As String = "SET @end_date='" & Date.Parse(DEReffDate.EditValue.ToString).ToString("yyyy-MM-dd") & "';
SELECT ass.useful_life,0 AS id_asset_dep_pps_det,ass.id_purc_rec_asset, 
CEIL(TIMESTAMPDIFF(MONTH, ass.`acq_date`, @end_date) +
  DATEDIFF(
    @end_date,
    ass.`acq_date` + INTERVAL
      TIMESTAMPDIFF(MONTH, ass.`acq_date`, @end_date)
    MONTH
  ) /
  DATEDIFF(
    ass.`acq_date` + INTERVAL
      TIMESTAMPDIFF(MONTH, ass.`acq_date`, @end_date) + 1
    MONTH,
    ass.`acq_date` + INTERVAL
      TIMESTAMPDIFF(MONTH, ass.`acq_date`, @end_date)
    MONTH
  )) AS life
,ass.`asset_name`,ass.acq_date,ass.`useful_life`-(SELECT life) AS rem_life
,id_acc_dep
FROM tb_purc_rec_asset ass
WHERE 
CEIL(TIMESTAMPDIFF(MONTH, ass.`acq_date`, @end_date) + DATEDIFF(@end_date,ass.`acq_date` + INTERVAL TIMESTAMPDIFF(MONTH, ass.`acq_date`, @end_date) MONTH) / DATEDIFF(ass.`acq_date` + INTERVAL TIMESTAMPDIFF(MONTH, ass.`acq_date`, @end_date) + 1 MONTH,ass.`acq_date` + INTERVAL TIMESTAMPDIFF(MONTH, ass.`acq_date`, @end_date) MONTH)) 
<=ass.`useful_life`"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCDepreciation.DataSource = dt
        GVDepreciation.BestFitColumns()
    End Sub
End Class