Public Class FormListStore
    Dim bnew_active As String = "0"
    Dim bedit_active As String = "0"
    Dim bdel_active As String = "0"

    Private Sub FormListStore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_company()
    End Sub

    Sub view_company()
        Dim q As String = ""

        q = "SELECT c.id_comp as id_comp, c.comp_number as comp_number, c.comp_name, c.comp_display_name, ho.comp_name AS `ho_name`, cg.comp_group, cg.description AS `comp_group_desc`, c.address_primary ,
        cry.country,reg.region,sta.state,cty.city,sd.sub_district, ara.`area`,
        cc.contact_person, cc.contact_number, cc.email AS contact_email,
        sty.store_type, ct.commerce_type, emp.employee_name,c.is_active , cs.comp_status
        FROM tb_m_comp c 
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp = c.id_comp AND cc.is_default = 1
        INNER JOIN tb_m_sub_district sd ON sd.id_sub_district = c.id_sub_district
        INNER JOIN tb_lookup_comp_status cs ON cs.id_comp_status =c.is_active
        INNER JOIN tb_m_city cty ON cty.id_city = c.id_city
        INNER JOIN tb_m_state sta ON sta.id_state = cty.id_state
        INNER JOIN tb_m_region reg ON reg.id_region = sta.id_region
        INNER JOIN tb_m_country cry ON cry.id_country = reg.id_country
        LEFT JOIN tb_m_area ara ON ara.id_area = c.id_area
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        INNER JOIN tb_lookup_store_type sty ON sty.id_store_type = c.id_store_type
        LEFT JOIN tb_m_employee emp ON emp.id_employee = c.id_employee_rep
        INNER JOIN tb_lookup_commerce_type ct ON ct.id_commerce_type = c.id_commerce_type
        LEFT JOIN tb_m_comp ho ON ho.id_comp = c.id_store_company
        WHERE c.id_comp_cat='6'
        ORDER BY comp_name ASC "

        Dim data As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCCompany.DataSource = data
        GVCompany.BestFitColumns()
    End Sub

    Private Sub FormListStore_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormListStore_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class