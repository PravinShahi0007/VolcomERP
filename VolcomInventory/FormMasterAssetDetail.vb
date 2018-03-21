Public Class FormMasterAssetDetail
    Public id_asset As String = "-1"
    Private Sub FormMasterAssetDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_cat()
        load_dept()
        load_user()
        DEPODate.EditValue = Now
        DERecDate.EditValue = Now
        '
        TEAge.EditValue = 0
        '
        TEPOQty.EditValue = 0
        TEPOValue.EditValue = 0.00
        TEPOTotal.EditValue = 0.00
        '
        TERecQty.EditValue = 0
        TERecValue.EditValue = 0.00
        TERecTotal.EditValue = 0.00
        '
        If id_asset = "-1" Then 'new
            LEAssetCat.Enabled = True
            LEDept.Enabled = True
            DERecDate.Properties.ReadOnly = False
        Else 'edit
            Dim query As String = "SELECT * FROM tb_a_asset WHERE id_asset='" & id_asset & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            '
            TECode.Text = data.Rows(0)("asset_code").ToString
            TEOldCode.Text = data.Rows(0)("asset_code_old").ToString
            TEVendorCode.Text = data.Rows(0)("vendor_code").ToString
            TEDesc.Text = data.Rows(0)("asset_desc").ToString
            LEAssetCat.ItemIndex = LEAssetCat.Properties.GetDataSourceRowIndex("id_asset_cat", data.Rows(0)("id_asset_cat").ToString)
            LEAssetCat.Enabled = False
            '
            LEDept.ItemIndex = LEDept.Properties.GetDataSourceRowIndex("id_departement", data.Rows(0)("id_departement").ToString)
            LEDept.Enabled = False
            '
            If Not data.Rows(0)("id_employee").ToString = "" Then
                LEUser.ItemIndex = LEUser.Properties.GetDataSourceRowIndex("id_employee", data.Rows(0)("id_employee").ToString)
            End If
            '
            TEPONumber.Text = data.Rows(0)("po_no").ToString
            TEPOQty.EditValue = data.Rows(0)("po_qty")
            DEPODate.EditValue = data.Rows(0)("po_date")
            TEPOValue.EditValue = data.Rows(0)("po_value")
            '
            TERecQty.EditValue = data.Rows(0)("rec_qty")
            DERecDate.EditValue = data.Rows(0)("rec_date")
            DERecDate.Properties.ReadOnly = True
            TERecValue.EditValue = data.Rows(0)("rec_value")
            '
            TEAge.EditValue = data.Rows(0)("age")
        End If
        '
        calculate_total_po()
        calculate_total_rec()
        calculate_aging()
        '
        generate_code()
    End Sub

    Sub generate_code()
        Try
            If id_asset = "-1" Then
                Dim year_rec As String = Date.Parse(DERecDate.EditValue.ToString).Year.ToString

                Dim row_kat As DataRowView = CType(LEAssetCat.Properties.GetDataSourceRowByKeyValue(LEAssetCat.EditValue), DataRowView)
                Dim kat_code As String = row_kat("asset_cat_code").ToString

                Dim row_dep As DataRowView = CType(LEDept.Properties.GetDataSourceRowByKeyValue(LEDept.EditValue), DataRowView)
                Dim dep_code As String = row_dep("departement_code").ToString
                '
                Dim query As String = "SELECT LPAD(COUNT(id_asset)+1,3,'0') AS code_counting FROM tb_a_asset WHERE asset_code LIKE '" & year_rec & kat_code & dep_code & "%'"
                TECode.Text = year_rec & kat_code & dep_code & execute_query(query, 0, True, "", "", "", "")
            End If
        Catch ex As Exception
            TECode.Text = ""
        End Try
    End Sub

    Sub calculate_aging()
        Try
            Dim current_age As Integer = 0
            current_age = DateDiff(DateInterval.Month, DERecDate.EditValue, Date.Parse(Now.ToString))
            '
            If current_age > TEAge.EditValue Then
                current_age = TEAge.EditValue
            End If

            DEAging.EditValue = Date.Parse(DERecDate.EditValue.ToString).AddMonths(TEAge.EditValue)
            TEMonthlyDepr.EditValue = TERecValue.EditValue / TEAge.EditValue
            TECurrentValue.EditValue = If(((TEMonthlyDepr.EditValue * current_age) > TERecValue.EditValue) Or (current_age >= TEAge.EditValue), 0, TERecValue.EditValue - (TEMonthlyDepr.EditValue * current_age))
        Catch ex As Exception
        End Try
    End Sub

    Sub calculate_total_po()
        Try
            TEPOTotal.EditValue = TEPOQty.EditValue * TEPOValue.EditValue
        Catch ex As Exception
        End Try
    End Sub

    Sub calculate_total_rec()
        Try
            TERecTotal.EditValue = TERecQty.EditValue * TERecValue.EditValue
        Catch ex As Exception
        End Try
    End Sub

    Sub load_cat()
        Dim query As String = "SELECT id_asset_cat,asset_cat_code,asset_cat FROM tb_a_asset_cat"
        viewLookupQuery(LEAssetCat, query, 0, "asset_cat", "id_asset_cat")
    End Sub

    Sub load_dept()
        Dim query As String = "SELECT id_departement,departement_code,departement FROM tb_m_departement"
        viewLookupQuery(LEDept, query, 0, "departement", "id_departement")
    End Sub

    Sub load_user()
        Dim query As String = "SELECT '' AS id_employee,'-' AS employee_code,'-' AS employee_name FROM tb_m_employee
                                UNION 
                               SELECT id_employee,employee_code,employee_name FROM tb_m_employee"
        viewLookupQuery(LEUser, query, 0, "employee_name", "id_employee")
    End Sub

    Private Sub FormMasterAssetDetail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub TEAge_EditValueChanged(sender As Object, e As EventArgs) Handles TEAge.EditValueChanged
        calculate_aging()
    End Sub

    Private Sub TERecValue_EditValueChanged(sender As Object, e As EventArgs) Handles TERecValue.EditValueChanged
        calculate_aging()
        calculate_total_rec()
    End Sub

    Private Sub DERecDate_EditValueChanged(sender As Object, e As EventArgs) Handles DERecDate.EditValueChanged
        calculate_aging()
        generate_code()
    End Sub

    Private Sub TEPOQty_EditValueChanged(sender As Object, e As EventArgs) Handles TEPOQty.EditValueChanged
        calculate_total_po()
    End Sub

    Private Sub TEPOValue_EditValueChanged(sender As Object, e As EventArgs) Handles TEPOValue.EditValueChanged
        calculate_total_po()
    End Sub

    Private Sub TERecQty_EditValueChanged(sender As Object, e As EventArgs) Handles TERecQty.EditValueChanged
        calculate_total_rec()
    End Sub

    Private Sub LEAssetCat_EditValueChanged(sender As Object, e As EventArgs) Handles LEAssetCat.EditValueChanged
        generate_code()
    End Sub

    Private Sub LEDept_EditValueChanged(sender As Object, e As EventArgs) Handles LEDept.EditValueChanged
        generate_code()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        generate_code()
        Dim code As String = addSlashes(TECode.Text)
        Dim code_old As String = addSlashes(TEOldCode.Text)
        Dim vendor_code As String = addSlashes(TEVendorCode.Text)
        Dim desc As String = addSlashes(TEDesc.Text)
        Dim asset_cat As String = LEAssetCat.EditValue.ToString
        '
        Dim id_emp As String = "NULL"
        If LEUser.Text = "" Then
            id_emp = "NULL"
        Else
            id_emp = "'" & LEUser.EditValue.ToString & "'"
        End If
        '
        Dim id_dep As String = LEDept.EditValue.ToString
        Dim po_no As String = addSlashes(TEPONumber.Text)
        Dim po_date As String = Date.Parse(DEPODate.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim po_qty As String = TEPOQty.EditValue.ToString
        Dim po_value As String = decimalSQL(TEPOValue.EditValue.ToString)
        '
        Dim rec_date As String = Date.Parse(DERecDate.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim rec_qty As String = TEPOQty.EditValue.ToString
        Dim rec_value As String = decimalSQL(TERecValue.EditValue.ToString)
        '
        Dim age As String = TEAge.EditValue.ToString
        '
        If id_asset = "-1" Then 'new
            Dim query As String = "INSERT INTO tb_a_asset(id_asset_cat,asset_code_old,asset_code,vendor_code,asset_desc,id_departement,id_employee,po_no,po_qty,po_value,po_date,rec_date,rec_qty,rec_value,age)
                                    VALUES('" & asset_cat & "','" & code_old & "','" & code & "','" & vendor_code & "','" & desc & "','" & id_dep & "'," & id_emp & ",'" & po_no & "','" & po_qty & "','" & po_value & "','" & po_date & "','" & rec_date & "','" & rec_qty & "','" & rec_value & "','" & age & "')"
            execute_non_query(query, True, "", "", "", "")
            FormMasterAsset.load_asset()
            Close()
        Else
            Dim query As String = "UPDATE tb_a_asset SET asset_code_old='" & code_old & "',vendor_code='" & vendor_code & "',asset_desc='" & desc & "',po_no='" & po_no & "',po_qty='" & po_qty & "',po_value='" & po_value & "',po_date='" & po_date & "',rec_date='" & rec_date & "',rec_qty='" & rec_qty & "',rec_value='" & rec_value & "',age='" & age & "'
                                    WHERE id_asset='" & id_asset & "'"
            execute_non_query(query, True, "", "", "", "")
            FormMasterAsset.load_asset()
            Close()
        End If
    End Sub

    Private Sub BNothingUser_Click(sender As Object, e As EventArgs) Handles BNothingUser.Click
        LEUser.ItemIndex = 0
    End Sub
End Class