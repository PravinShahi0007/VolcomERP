Public Class FormItemPps
    Public id_pps As String = "-1"
    Public is_view As String = "-1"
    Public is_vm_item As String = "-1"

    Private Sub FormItemPps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Sub load_vm_items()
        Dim query As String = "SELECT d.id_display_type, d.display_type FROM tb_display_type d"
        viewSearchLookupQuery(SLEVMItems, query, "id_display_type", "display_type", "id_display_type")
    End Sub

    Private Sub SLEPurchaseCategory_EditValueChanged(sender As Object, e As EventArgs) Handles SLEPurchaseCategory.EditValueChanged
        Try
            SLECat.EditValue = SLEPurchaseCategory.Properties.View.GetFocusedRowCellValue("id_item_cat").ToString
            SLEVendorType.EditValue = SLEPurchaseCategory.Properties.View.GetFocusedRowCellValue("id_vendor_type").ToString
        Catch ex As Exception
        End Try
    End Sub

    Sub load_vendor_type()
        Dim query As String = "SELECT id_vendor_type,vendor_type FROM tb_vendor_type"
        viewSearchLookupQuery(SLEVendorType, query, "id_vendor_type", "vendor_type", "id_vendor_type")
    End Sub

    Sub load_uom()
        Dim query As String = "SELECT id_uom,uom FROM tb_m_uom WHERE is_active='1'"
        viewSearchLookupQuery(SLEUOM, query, "id_uom", "uom", "id_uom")
        viewSearchLookupQuery(SLEUOMStock, query, "id_uom", "uom", "id_uom")
    End Sub

    Sub load_cat()
        Dim query As String = "SELECT cat.id_item_cat,cat.item_cat FROM `tb_item_cat` cat
INNER JOIN `tb_item_coa` coa ON cat.`id_item_cat`=coa.`id_item_cat`
WHERE coa.`is_request`='1' AND cat.is_active='1'
GROUP BY cat.`id_item_cat`"
        viewSearchLookupQuery(SLECat, query, "id_item_cat", "item_cat", "id_item_cat")
    End Sub

    Sub load_purc_cat()
        Dim query As String = "SELECT icd.`id_item_cat_detail`,ic.`item_cat`,vt.`vendor_type`,icd.`item_cat_detail`,icd.id_item_cat,icd.id_vendor_type
FROM `tb_item_cat_detail` icd
INNER JOIN `tb_item_cat` ic ON ic.`id_item_cat`=icd.`id_item_cat`
INNER JOIN tb_vendor_type vt ON vt.`id_vendor_type`=icd.`id_vendor_type`
WHERE id_status='2'"
        viewSearchLookupQuery(SLEPurchaseCategory, query, "id_item_cat_detail", "item_cat_detail", "id_item_cat_detail")
    End Sub

    Sub load_item_type()
        Dim query As String = "SELECT id_item_type,item_type FROM tb_lookup_purc_item_type WHERE is_active='1'"
        viewSearchLookupQuery(SLEItemType, query, "id_item_type", "item_type", "id_item_type")
    End Sub

    Sub load_form()
        TEConvertion.EditValue = 1
        '
        load_vendor_type()
        load_uom()
        load_item_type()
        load_purc_cat()
        load_cat()
        load_vm_items()

        '
        If Not id_pps = "-1" Then 'edit
            Dim query As String = "SELECT it.*,icd.`id_vendor_type`,emp.employee_name FROM tb_item_pps it
INNER JOIN tb_item_cat_detail icd ON icd.id_item_cat_detail=it.id_item_cat_detail 
INNER JOIN tb_m_user usr ON usr.id_user=it.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
WHERE it.id_item_pps='" & id_pps & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TEDesc.Text = data.Rows(0)("item_desc").ToString
            TEConvertion.EditValue = data.Rows(0)("stock_convertion").ToString
            MEDefDesc.Text = data.Rows(0)("def_desc").ToString

            SLEUOM.EditValue = data.Rows(0)("id_uom").ToString
            SLEUOMStock.EditValue = data.Rows(0)("id_uom_stock").ToString
            SLEItemType.EditValue = data.Rows(0)("id_item_type").ToString
            SLEVMItems.EditValue = data.Rows(0)("id_display_type").ToString
            '
            SLEPurchaseCategory.EditValue = data.Rows(0)("id_item_cat_detail").ToString
            SLECat.EditValue = data.Rows(0)("id_item_cat").ToString
            SLEVendorType.EditValue = data.Rows(0)("id_vendor_type").ToString
            '
            TEPPSNumber.Text = data.Rows(0)("number").ToString
            TECreatedBy.Text = data.Rows(0)("employee_name").ToString
            DEDate.EditValue = data.Rows(0)("created_date")
            '
            If data.Rows(0)("is_vm_item").ToString = "1" Then
                is_vm_item = "1"
            End If
            '
            BMark.Visible = True
        Else
            TEPPSNumber.Text = "[auto]"
            SLEPurchaseCategory.EditValue = Nothing
            TECreatedBy.Text = get_user_identify(id_user, "1")
            DEDate.EditValue = Now
            BMark.Visible = False
        End If
        '
        If is_view = "1" Then
            BSave.Visible = False
        End If
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        If Not SLEPurchaseCategory.EditValue = Nothing Then
            Dim vm_item As String = "2"
            If is_vm_item = "1" Then
                vm_item = "1"
            End If

            If id_pps = "-1" Then 'new
                Dim query As String = "INSERT INTO tb_item_pps(created_date,created_by,item_desc,id_item_cat_detail,id_item_cat,id_item_type,id_uom,id_uom_stock,stock_convertion,def_desc, id_display_type,is_vm_item) VALUES(NOW(),'" & id_user & "','" & TEDesc.Text & "','" & SLEPurchaseCategory.EditValue.ToString & "','" & SLECat.EditValue.ToString & "','" & SLEItemType.EditValue.ToString & "','" & SLEUOM.EditValue.ToString & "','" & SLEUOMStock.EditValue.ToString & "','" & decimalSQL(TEConvertion.EditValue.ToString) & "','" & addSlashes(MEDefDesc.Text) & "', '" & SLEVMItems.EditValue.ToString & "','" & vm_item & "'); SELECT LAST_INSERT_ID();"
                id_pps = execute_query(query, 0, True, "", "", "", "")

                If is_vm_item = "1" Then
                    execute_non_query("CALL gen_number('" & id_pps & "','393')", True, "", "", "", "")
                    submit_who_prepared("383", id_pps, id_user)
                    infoCustom("Itme proposed, waiting approval.")
                Else
                    execute_non_query("CALL gen_number('" & id_pps & "','383')", True, "", "", "", "")
                    submit_who_prepared("383", id_pps, id_user)
                    infoCustom("Itme proposed, waiting approval.")
                End If

                FormPurcItem.load_pps()
                FormPurcItem.GVItemPps.FocusedRowHandle = find_row(FormPurcItem.GVItemPps, "id_item_pps", id_pps)
                Close()
            Else 'edit
                Dim query As String = "UPDATE tb_item_pps SET item_desc='" & TEDesc.Text & "',id_item_cat='" & SLECat.EditValue.ToString & "',id_item_type='" & SLEItemType.EditValue.ToString & "',id_uom='" & SLEUOM.EditValue.ToString & "',id_uom_stock='" & SLEUOMStock.EditValue.ToString & "',stock_convertion='" & decimalSQL(TEConvertion.EditValue.ToString) & "',def_desc='" & addSlashes(MEDefDesc.Text) & "' WHERE id_item_pps='" & id_pps & "'"
                execute_non_query(query, True, "", "", "", "")

                infoCustom("Itme updated, waiting approval.")

                FormPurcItem.load_pps()
                FormPurcItem.GVItemPps.FocusedRowHandle = find_row(FormPurcItem.GVItemPps, "id_item_pps", id_pps)
                Close()
            End If
        Else
            warningCustom("Please select category")
        End If
    End Sub

    Private Sub FormItemPps_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        If is_vm_item = "1" Then
            FormReportMark.report_mark_type = "393"
        Else
            FormReportMark.report_mark_type = "383"
        End If
        FormReportMark.id_report = id_pps
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub
End Class