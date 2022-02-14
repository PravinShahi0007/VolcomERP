﻿Public Class FormStoreDisplayHanger
    Public id_display_pps As String = "-1"
    Public id_comp As String = "-1"

    Private Sub FormStoreDisplayHanger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub actionLoad()
        viewDivision()
        viewClassCat()
        TxtQty.EditValue = 0
    End Sub

    Private Sub FormStoreDisplayHanger_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewDivision()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT cd.id_code_detail AS `id_division`, cd.code_detail_name AS `division` 
        FROM tb_m_code_detail cd 
        LEFT JOIN (
	        SELECT cg.id_division
	        FROM tb_display_master dm 
	        INNER JOIN tb_class_group cg ON cg.id_class_group = dm.id_class_group
	        WHERE dm.id_comp=" + id_comp + " AND dm.is_active=1
	        GROUP BY cg.id_division
        ) dm ON dm.id_division = cd.id_code_detail
        WHERE cd.id_code IN (SELECT o.id_code_fg_division FROM tb_opt o)
        AND !ISNULL(dm.id_division)
        AND cd.code_detail_name!='-' "
        viewSearchLookupQuery(SLEDivision, query, "id_division", "division", "id_division")
        Cursor = Cursors.Default
    End Sub

    Sub viewClassCat()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT cc.id_class_cat, cc.class_cat 
        FROM tb_class_cat cc 
        LEFT JOIN (
            SELECT cg.id_class_cat
            FROM tb_display_master dm 
            INNER JOIN tb_class_group cg ON cg.id_class_group = dm.id_class_group
            WHERE dm.id_comp=" + id_comp + " AND dm.is_active=1
            GROUP BY cg.id_class_cat
        ) dm ON dm.id_class_cat = cc.id_class_cat
        WHERE !ISNULL(dm.id_class_cat)
        ORDER BY cc.class_cat ASC "
        viewSearchLookupQuery(SLECategory, query, "id_class_cat", "class_cat", "id_class_cat")
        Cursor = Cursors.Default
    End Sub

    Private Sub SLEDivision_EditValueChanged(sender As Object, e As EventArgs) Handles SLEDivision.EditValueChanged
        viewSeason()
    End Sub

    Private Sub SLECategory_EditValueChanged(sender As Object, e As EventArgs) Handles SLECategory.EditValueChanged
        viewSeason()
    End Sub

    Sub viewSeason()
        Cursor = Cursors.WaitCursor
        Dim id_division As String = "-1"
        Try
            id_division = SLEDivision.EditValue.ToString
        Catch ex As Exception

        End Try
        Dim id_class_cat As String = "-1"
        Try
            id_class_cat = SLECategory.EditValue.ToString
        Catch ex As Exception

        End Try
        Dim query As String = "SELECT dps.id_display_pps_season, 
        IFNULL(CONCAT(ss.season, ' ',sd.delivery),'EXTRA SKU') AS `season_del`, 'No' AS `is_select`
        FROM tb_display_pps_season dps
        LEFT JOIN tb_season ss ON ss.id_season = dps.id_season
        LEFT JOIN tb_season_delivery sd ON sd.id_delivery = dps.id_delivery
        LEFT JOIN (
	        SELECT dph.id_display_pps_season 
	        FROM tb_display_pps_hanger dph
	        WHERE dph.id_display_pps=" + id_display_pps + " AND dph.id_class_cat=" + id_class_cat + " AND dph.id_division=" + id_division + "
	        GROUP BY dph.id_display_pps_season
        ) dph ON dph.id_display_pps_season = dps.id_display_pps_season
        WHERE dps.id_display_pps=" + id_display_pps + " AND ISNULL(dph.id_display_pps_season)
        ORDER BY sd.delivery_date ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSeason.DataSource = data
        GVSeason.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewClassGroup()
        Cursor = Cursors.WaitCursor
        Dim id_division As String = "-1"
        Try
            id_division = SLEDivision.EditValue.ToString
        Catch ex As Exception

        End Try
        Dim id_class_cat As String = "-1"
        Try
            id_class_cat = SLECategory.EditValue.ToString
        Catch ex As Exception

        End Try
        Dim query As String = "SELECT cg.id_class_group, cg.class_group, 'Yes' AS `is_select` 
        FROM tb_class_group cg 
        WHERE cg.is_active=1 AND cg.id_division=" + id_division + " AND cg.id_class_cat=" + id_class_cat + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCClassGroup.DataSource = data
        GVClassGroup.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        Dim cond_season As Boolean = False
        GVSeason.ActiveFilterString = "[is_select]='Yes'"
        If GVSeason.RowCount > 0 Then
            cond_season = True
        Else
            cond_season = False
        End If

        'clean fiklter
        GVSeason.ActiveFilterString = ""
        GVClassGroup.ActiveFilterString = ""

        'filter
        GVClassGroup.ActiveFilterString = "[is_select]='Yes'"
        GVSeason.ActiveFilterString = "[is_select]='Yes'"

        If TxtQty.EditValue = 0 Or cond_season = False Or SLEDivision.EditValue = Nothing Or SLECategory.EditValue = Nothing Then
            warningCustom("Please complete all data")
        Else
            Dim indeks As Integer = 0
            Dim id_division As String = SLEDivision.EditValue.ToString
            Dim id_class_cat As String = SLECategory.EditValue.ToString
            Dim qty_hanger As String = decimalSQL(TxtQty.EditValue.ToString)
            Dim query As String = "INSERT INTO tb_display_pps_hanger(id_display_pps, id_display_pps_season, id_class_group, id_division, id_class_cat, qty_hanger) VALUES "
            For i As Integer = 0 To GVClassGroup.RowCount - 1
                Dim id_class_group As String = GVClassGroup.GetRowCellValue(i, "id_class_group").ToString
                For j As Integer = 0 To GVSeason.RowCount - 1
                    If indeks > 0 Then
                        query += ","
                    End If
                    Dim id_display_pps_season As String = GVSeason.GetRowCellValue(j, "id_display_pps_season").ToString
                    query += "('" + id_display_pps + "', '" + id_display_pps_season + "', '" + id_class_group + "','" + id_division + "','" + id_class_cat + "', '" + qty_hanger + "') "
                    indeks += 1
                Next
            Next
            If indeks > 0 Then
                execute_non_query(query, -1, True, "", "", "", "")
            End If
            actionLoad()
        End If

        'clean fiklter
        GVSeason.ActiveFilterString = ""
        GVClassGroup.ActiveFilterString = ""
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub
End Class