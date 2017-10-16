Public Class FormPopUpOVH
    Private Sub FormPopUpOVH_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormPopUpOVH_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        load_wo()
    End Sub
    Sub load_wo()
        Dim query As String = "SELECT ovhp.id_ovh_price,cc.id_comp_contact,comp.comp_name,ovh.id_ovh,ovh.overhead_code AS `code`,ovh.overhead AS `name`,cur.id_currency,cur.currency,uom.uom,ovhp.ovh_price AS price_ori,ovhp.ovh_price AS price,ovhp.ovh_price_name,cast_tinyint('1') AS is_ovh_main,'1' AS kurs 
                                FROM tb_m_ovh_price ovhp
                                INNER JOIN tb_m_ovh ovh ON ovh.id_ovh=ovhp.id_ovh
                                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ovhp.id_comp_contact
                                INNER JOIN tb_m_comp comp ON comp.id_comp=cc.id_comp
                                INNER JOIN tb_lookup_currency cur ON cur.id_currency=ovhp.id_currency
                                INNER JOIN tb_m_uom uom ON uom.id_uom=ovh.id_uom
                                WHERE ovhp.`id_ovh` = (SELECT id_ovh FROM tb_m_ovh_price WHERE id_ovh_price='" & FormProductionCOPDet.old_id_ovh_price & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCOVH.DataSource = data
        If data.Rows.Count > 0 Then
            BSaveOvh.Enabled = True
        Else
            BSaveOvh.Enabled = False
        End If
    End Sub

    Private Sub BCancelOvh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelOvh.Click
        Close()
    End Sub

    Private Sub BSaveOvh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSaveOvh.Click
        FormProductionCOPDet.id_ovh_price = GVOVH.GetFocusedRowCellValue("id_ovh_price").ToString
        FormProductionCOPDet.TEDesc.Text = GVOVH.GetFocusedRowCellValue("name").ToString
        FormProductionCOPDet.TEVendor.Text = get_company_x(get_id_company(GVOVH.GetFocusedRowCellValue("id_comp_contact").ToString), "2")
        FormProductionCOPDet.TEVendorName.Text = get_company_x(get_id_company(GVOVH.GetFocusedRowCellValue("id_comp_contact").ToString), "1")

        Close()
    End Sub

End Class