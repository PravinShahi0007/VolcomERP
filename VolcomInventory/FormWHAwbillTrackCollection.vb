Public Class FormWHAwbillTrackCollection
    Public is_pick As Boolean = False
    Public id_vendor As String = ""
    Private Sub FormWHAwbillTrackCollection_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormWHAwbillTrackCollection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_vendor()
        If is_pick Then
            XTPAWBCollection.PageVisible = False
            XTPPickAWB.PageVisible = True
            '
            Dim query As String = "SELECT 3n.`id_track_no`,3n.`track_no`,IF(3n.is_use=1,'Used','-') AS used,c.`comp_name`
FROM tb_3pl_track_no 3n
INNER JOIN tb_m_comp c ON c.id_comp=3n.id_comp
WHERE 3n.id_comp='" & id_vendor & "'
ORDER BY 3n.track_no DESC"
            Dim dt As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCVendorCollection.DataSource = dt
            GVVendorCollection.BestFitColumns()
            '
            TEScanGenerate.Focus()
        Else
            XTPAWBCollection.PageVisible = True
            XTPPickAWB.PageVisible = False
        End If
    End Sub

    Sub load_vendor()
        Dim q As String = "SELECT id_comp,comp_name FROM tb_m_comp WHERE id_comp_cat='7' AND is_active='1'"
        viewSearchLookupQuery(SLECargo, q, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_collection()
    End Sub

    Sub load_collection()
        Dim q As String = "SELECT 3n.`id_track_no`,3n.`track_no`,IF(3n.is_use=1,'Used','-') AS used,c.`comp_name`
FROM tb_3pl_track_no 3n
INNER JOIN tb_m_comp c ON c.id_comp=3n.id_comp
WHERE 3n.id_comp='" & SLECargo.EditValue.ToString & "'
ORDER BY 3n.track_no DESC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCCollection.DataSource = dt
        GVCollection.BestFitColumns()
    End Sub

    Private Sub Bimport_Click(sender As Object, e As EventArgs) Handles Bimport.Click
        FormImportExcel.id_pop_up = "49"
        FormImportExcel.ShowDialog()
    End Sub

    Private Sub TECodeScan_KeyDown(sender As Object, e As KeyEventArgs) Handles TECodeScan.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim query As String = "SELECT 3n.`id_track_no`,3n.`track_no`,IF(3n.is_use=1,'Used','-') AS used,c.`comp_name`
FROM tb_3pl_track_no 3n
INNER JOIN tb_m_comp c ON c.id_comp=3n.id_comp
WHERE 3n.id_comp='" & SLECargo.EditValue.ToString & "' AND 3n.track_no='" & addSlashes(TECodeScan.Text) & "'"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

            If data.Rows.Count > 0 Then
                stopCustom("Code duplicate.")
            Else
                Dim q As String = "INSERT INTO tb_3pl_track_no(id_comp_track_no) VALUES('" & SLECargo.EditValue.ToString & "','" & addSlashes(TECodeScan.Text) & "')"
                execute_non_query(q, True, "", "", "", "")
                load_collection()
            End If
        End If
    End Sub
End Class