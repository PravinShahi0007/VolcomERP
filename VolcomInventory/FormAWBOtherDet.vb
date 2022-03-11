Public Class FormAWBOtherDet
    Public id As String = "-1"

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub FormAWBOtherDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormAWBOtherDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DECreatedDate.EditValue = getTimeDB()
        DEPickupDate.Properties.MaxValue = getTimeDB()
        DEPickupDate.EditValue = getTimeDB()
        '
        load_head()
    End Sub

    Sub load_head()
        view_3pl()

        If id = "-1" Then
            'new
            load_det()
        Else
            'edit
            Dim q As String = "SELECT CONCAT('AWBOFC',LPAD(awb.id_awb_office,5,'0')) AS number,awb.id_comp,awb.pickup_date,awb.created_date,emp.employee_name,awb.pickup_date
FROM `tb_awb_office` awb
INNER JOIN tb_m_comp c ON c.id_comp=awb.id_comp
INNER JOIN tb_m_user usr ON usr.id_user=awb.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
WHERE awb.id_awb_office='" & id & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                TENumber.Text = dt.Rows(0)("number").ToString
                '
                TECreatedBy.Text = dt.Rows(0)("employee_name").ToString
                DECreatedDate.EditValue = dt.Rows(0)("created_date")
                '
                SLUE3PL.EditValue = dt.Rows(0)("id_comp").ToString
                DEPickupDate.EditValue = dt.Rows(0)("created_date")
            End If

            load_det()
        End If
    End Sub

    Sub load_det()
        Dim q As String = "SELECT awbo.`awbill_no`,dep.id_departement,dep.departement,awbo.`jml_koli`,IFNULL(awbo.id_client,'') AS id_client,IF(ISNULL(awbo.id_client),'Not Registered',c.comp_name) AS comp_name,dis.id_sub_district,dis.sub_district
,awbo.`client_note`,IFNULL(invo.inv_number,'') AS inv_number
FROM `tb_awb_office_det` awbo 
INNER JOIN tb_m_departement dep ON dep.id_departement=awbo.id_departement
LEFT JOIN tb_m_comp c ON c.id_comp=awbo.id_client
LEFT JOIN  
(
    SELECT id_awb_office_det,inv.inv_number
    FROM tb_awb_inv_sum_other invo 
    INNER JOIN tb_awb_inv_sum inv ON inv.id_awb_inv_sum=invo.id_awb_inv_sum AND inv.id_report_status!=5
)invo ON invo.id_awb_office_det=awbo.id_awb_office_det
INNER JOIN tb_m_sub_district dis ON dis.id_sub_district=awbo.id_sub_district
WHERE awbo.id_awb_office='" & id & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCList.DataSource = dt
        GVList.BestFitColumns()
        '
        For i As Integer = 0 To dt.Rows.Count - 1
            If Not dt.Rows(i)("inv_number").ToString = "" Then
                BSave.Visible = False
                GridColumnInv.VisibleIndex = 6
            End If
        Next
    End Sub

    Sub view_3pl()
        Dim query As String = "SELECT id_comp, comp_name AS comp_name FROM tb_m_comp WHERE id_comp_cat = 7"
        viewSearchLookupQuery(SLUE3PL, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub BDel_Click(sender As Object, e As EventArgs) Handles BDel.Click
        If GVList.RowCount > 0 Then
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = DialogResult.Yes Then
                GVList.DeleteSelectedRows()
            End If
        End If
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        FormAWBOtherAdd.ShowDialog()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        'check
        If GVList.RowCount = 0 Then
            warningCustom("No Data")
        Else
            'update data
            If id = "-1" Then
                'new
                Dim q As String = "INSERT INTO `tb_awb_office`(id_comp,pickup_date,created_by,created_date)
VALUES('" & SLUE3PL.EditValue.ToString & "','" & Date.Parse(DEPickupDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & id_user & "',NOW()); SELECT LAST_INSERT_ID();"
                id = execute_query(q, 0, True, "", "", "", "")
                'detail
                Dim qd As String = "INSERT INTO tb_awb_office_det(`id_awb_office`,`id_departement`,`jml_koli`,`id_client`,`id_sub_district`,`client_note`,`awbill_no`) VALUES"

                For i As Integer = 0 To GVList.RowCount - 1
                    If Not i = 0 Then
                        qd += ","
                    End If

                    Dim id_client As String = ""

                    If GVList.GetRowCellValue(i, "id_client").ToString = "" Or GVList.GetRowCellValue(i, "id_client").ToString = "0" Then
                        id_client = "NULL"
                    Else
                        id_client = "'" & GVList.GetRowCellValue(i, "id_client").ToString & "'"
                    End If

                    qd += "('" & id & "','" & GVList.GetRowCellValue(i, "id_departement").ToString & "','" & GVList.GetRowCellValue(i, "jml_koli").ToString & "'," & id_client & ",'" & GVList.GetRowCellValue(i, "id_sub_district").ToString & "','" & addSlashes(GVList.GetRowCellValue(i, "client_note").ToString) & "','" & addSlashes(GVList.GetRowCellValue(i, "awbill_no").ToString) & "')"
                Next

                execute_non_query(qd, True, "", "", "", "")
                infoCustom("Data saved.")
                '
                FormAWBOther.DEStart.EditValue = DEPickupDate.EditValue
                FormAWBOther.DEUntil.EditValue = DEPickupDate.EditValue
                FormAWBOther.load_form()
                Close()
            Else
                'edit
                Dim qu As String = "UPDATE tb_awb_office SET id_comp='" & SLUE3PL.EditValue.ToString & "',pickup_date='" & Date.Parse(DEPickupDate.EditValue.ToString).ToString("yyyy-MM-dd") & "' WHERE id_awb_office='" & id & "'"
                execute_non_query(qu, True, "", "", "", "")
                '
                qu = "DELETE FROM tb_awb_office_det WHERE id_awb_office='" & id & "'"
                execute_non_query(qu, True, "", "", "", "")
                '
                Dim qd As String = "INSERT INTO tb_awb_office_det(`id_awb_office`,`id_departement`,`jml_koli`,`id_client`,`id_sub_district`,`client_note`,`awbill_no`) VALUES"

                For i As Integer = 0 To GVList.RowCount - 1
                    If Not i = 0 Then
                        qd += ","
                    End If

                    Dim id_client As String = ""
                    If GVList.GetRowCellValue(i, "id_client").ToString = "" Or GVList.GetRowCellValue(i, "id_client").ToString = "0" Then
                        id_client = "NULL"
                    Else
                        id_client = "'" & GVList.GetRowCellValue(i, "id_client").ToString & "'"
                    End If

                    qd += "('" & id & "','" & GVList.GetRowCellValue(i, "id_departement").ToString & "','" & GVList.GetRowCellValue(i, "jml_koli").ToString & "'," & id_client & ",'" & GVList.GetRowCellValue(i, "id_sub_district").ToString & "','" & addSlashes(GVList.GetRowCellValue(i, "client_note").ToString) & "','" & addSlashes(GVList.GetRowCellValue(i, "awbill_no").ToString) & "')"
                Next

                execute_non_query(qd, True, "", "", "", "")
                infoCustom("Data updated.")
                Close()
            End If
        End If
    End Sub
End Class