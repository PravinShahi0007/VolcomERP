Public Class ClassPurcAsset
    Public Function queryMain(ByVal condition As String, ByVal order_type As String) As String
        If order_type = "1" Then
            order_type = "ASC "
        ElseIf order_type = "2" Then
            order_type = "DESC "
        End If

        If condition <> "-1" Then
            condition = condition
        Else
            condition = ""
        End If

        Dim query As String = "SELECT a.id_purc_rec_asset, a.id_item, a.id_purc_rec_det, r.purc_rec_number, 
        a.id_departement, d.departement, a.id_acc_fa, fa.acc_name AS `acc_fa`,fa.acc_description AS `acc_fa_name`, 
        a.asset_number, a.asset_name, a.asset_note, a.acq_date, 
        a.acq_cost, a.is_non_depresiasi, a.useful_life, a.rate, 
        a.id_acc_dep, dep.acc_name AS `dep_acc`, dep.acc_description AS `dep_acc_name`,
        a.id_acc_dep_accum,adep.acc_name AS `accum_dep_acc`, adep.acc_description AS `accum_dep_acc_name`, a.accum_dep, a.as_date, a.current_value, a.is_record, a.is_active
        FROM tb_purc_rec_asset a
        INNER JOIN tb_purc_rec_det rd ON rd.id_purc_rec_det = a.id_purc_rec_det
        INNER JOIN tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
        INNER JOIN tb_m_departement d ON d.id_departement = a.id_departement
        INNER JOIN tb_item i ON i.id_item = a.id_item
        INNER JOIN tb_item_cat cat ON cat.id_item_cat = i.id_item_cat
        INNER JOIN tb_a_acc fa ON fa.id_acc = a.id_acc_fa
        LEFT JOIN tb_a_acc dep ON dep.id_acc = a.id_acc_dep
        LEFT JOIN tb_a_acc adep ON adep.id_acc = a.id_acc_dep_accum
        WHERE a.id_purc_rec_asset>0 "
        query += condition + " "
        query += "ORDER BY a.id_purc_rec_asset " + order_type
        Return query
    End Function
End Class