Public Class FormProductionCOPDet
    Public id_wo As String = "-1"
    '
    Public old_kurs As Decimal = 1.0
    Public old_price As Decimal = 0.0000
    Public old_curr As String = "1"
    Public old_id_ovh_price As String = "1"
    '
    Public id_ovh_price As String = "-1"
    '
    Public file_address As String = ""
    Public file_name As String = ""
    Public file_ext As String = ""
    '
    Private Sub FormProductionCOPDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEEcop.EditValue = 0.00
        TEKurs.EditValue = 1.0

        view_currency(LECurrency)
        Dim query As String = "SELECT wo.id_ovh_price,wo.prod_order_wo_number,ovh.overhead,comp.comp_number,comp.comp_name,wod.id_prod_order_wo_det,wod.id_prod_order_wo,wod.prod_order_wo_det_price,wo.prod_order_wo_kurs,wo.id_currency
                                FROM tb_prod_order_wo_det wod
                                INNER JOIN tb_prod_order_wo wo ON wo.id_prod_order_wo=wod.id_prod_order_wo
                                INNER JOIN tb_m_ovh_price ovhp ON ovhp.id_ovh_price=wo.id_ovh_price
                                INNER JOIN tb_m_ovh ovh ON ovh.id_ovh=ovhp.id_ovh
                                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ovhp.id_comp_contact
                                INNER JOIN tb_m_comp comp ON comp.id_comp=cc.id_comp
                                WHERE wod.id_prod_order_wo='" & id_wo & "'
                                GROUP BY id_prod_order_wo"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            TEVendor.Text = data.Rows(0)("comp_number").ToString
            TEVendorName.Text = data.Rows(0)("comp_name").ToString
            '
            old_kurs = data.Rows(0)("prod_order_wo_kurs")
            TEKurs.EditValue = data.Rows(0)("prod_order_wo_kurs")
            '
            old_price = data.Rows(0)("prod_order_wo_det_price")
            TEEcop.EditValue = data.Rows(0)("prod_order_wo_det_price")
            '
            TECode.EditValue = data.Rows(0)("prod_order_wo_number")
            TEDesc.EditValue = data.Rows(0)("overhead").ToString
            '
            old_curr = data.Rows(0)("id_currency").ToString
            LECurrency.EditValue = Nothing
            LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)
            '
            old_id_ovh_price = data.Rows(0)("id_ovh_price").ToString
            id_ovh_price = data.Rows(0)("id_ovh_price").ToString
        End If
        '
    End Sub
    '
    Public directory_upload As String = get_setup_field("upload_dir")

    Private Sub BUploadFile_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles BUploadFile.ButtonClick
        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Title = "Upload file"
        fd.InitialDirectory = "C:\"
        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            file_name = System.IO.Path.GetFileNameWithoutExtension(fd.SafeFileName)
            file_address = fd.FileName
            file_ext = System.IO.Path.GetExtension(fd.SafeFileName)
        End If

        BUploadFile.Text = file_address
    End Sub

    '
    Private Sub view_currency(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "currency"
        lookup.Properties.ValueMember = "id_currency"
        lookup.ItemIndex = 0
    End Sub

    Private Sub FormProductionCOPDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormProductionCOPDet_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        LECurrency.Focus()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If Not id_ovh_price = old_id_ovh_price Then
            If Not file_name = "" Then
                Cursor = Cursors.WaitCursor
                Dim id_log As String = ""
                Dim query As String = ""
                Dim total As Decimal = 0.0
                'update detail
                query = "UPDATE tb_prod_order_wo_det SET prod_order_wo_det_price='" & decimalSQL(TEEcop.EditValue.ToString) & "' WHERE id_prod_order_wo='" & id_wo & "'"
                execute_non_query(query, True, "", "", "", "")
                'get total
                query = "SELECT SUM(prod_order_wo_det_qty*prod_order_wo_det_price) AS sub_total FROM tb_prod_order_wo_det
                    WHERE id_prod_order_wo='" & id_wo & "'
                    GROUP BY id_prod_order_wo"
                Dim data_tot As DataTable = execute_query(query, -1, True, "", "", "", "")
                total = data_tot.Rows(0)("sub_total")
                'update kurs dan curr
                query = "UPDATE tb_prod_order_wo SET id_ovh_price='" & id_ovh_price & "',id_currency='" & LECurrency.EditValue.ToString & "',prod_order_wo_kurs='" & decimalSQL(TEKurs.EditValue.ToString) & "',prod_order_wo_amount='" & decimalSQL(total.ToString) & "' WHERE id_prod_order_wo='" & id_wo & "'"
                execute_non_query(query, True, "", "", "", "")
                'insert log
                query = "INSERT INTO tb_prod_order_wo_log(id_wo,old_curr,old_price,old_kurs,new_price,new_curr,new_kurs,id_user,datetime_log,doc_desc,ext,old_id_ovh_price,new_id_ovh_price)
                VALUES('" & id_wo & "','" & old_curr.ToString & "','" & decimalSQL(old_price.ToString) & "','" & decimalSQL(old_kurs.ToString) & "','" & decimalSQL(TEEcop.EditValue.ToString) & "','" & LECurrency.EditValue.ToString & "','" & decimalSQL(TEKurs.EditValue.ToString) & "','" & id_user & "',NOW(),'" & addSlashes(file_name) & "','" & file_ext & "','" & old_id_ovh_price & "','" & id_ovh_price & "'); SELECT LAST_INSERT_ID(); "
                id_log = execute_query(query, 0, True, "", "", "", "")
                '
                'upload
                Dim path As String = directory_upload & "ProdCOP" & "\"
                If Not IO.Directory.Exists(path) Then
                    System.IO.Directory.CreateDirectory(path)
                End If
                My.Computer.Network.UploadFile(file_address, path & id_log & file_ext, "", "", True, 100, True)
                '
                FormProductionCOP.view_list_cost(FormProductionCOP.id_design)
                FormProductionCOP.calculate_cost_management()
                FormProductionCOP.calculate_man()

                infoCustom("Data updated")

                Cursor = Cursors.Default
                Close()
            Else
                stopCustom("Please attach supporting document for changing vendor !")
            End If
        Else
            Cursor = Cursors.WaitCursor
            Dim id_log As String = ""
            Dim query As String = ""
            Dim total As Decimal = 0.0
            'update detail
            query = "UPDATE tb_prod_order_wo_det SET prod_order_wo_det_price='" & decimalSQL(TEEcop.EditValue.ToString) & "' WHERE id_prod_order_wo='" & id_wo & "'"
            execute_non_query(query, True, "", "", "", "")
            'get total
            query = "SELECT SUM(prod_order_wo_det_qty*prod_order_wo_det_price) AS sub_total FROM tb_prod_order_wo_det
                    WHERE id_prod_order_wo='" & id_wo & "'
                    GROUP BY id_prod_order_wo"
            Dim data_tot As DataTable = execute_query(query, -1, True, "", "", "", "")
            total = data_tot.Rows(0)("sub_total")
            'update kurs dan curr
            query = "UPDATE tb_prod_order_wo SET id_ovh_price='" & id_ovh_price & "',id_currency='" & LECurrency.EditValue.ToString & "',prod_order_wo_kurs='" & decimalSQL(TEKurs.EditValue.ToString) & "',prod_order_wo_amount='" & decimalSQL(total.ToString) & "' WHERE id_prod_order_wo='" & id_wo & "'"
            execute_non_query(query, True, "", "", "", "")
            'insert log
            query = "INSERT INTO tb_prod_order_wo_log(id_wo,old_curr,old_price,old_kurs,new_price,new_curr,new_kurs,id_user,datetime_log,old_id_ovh_price,new_id_ovh_price)
                VALUES('" & id_wo & "','" & old_curr.ToString & "','" & decimalSQL(old_price.ToString) & "','" & decimalSQL(old_kurs.ToString) & "','" & decimalSQL(TEEcop.EditValue.ToString) & "','" & LECurrency.EditValue.ToString & "','" & decimalSQL(TEKurs.EditValue.ToString) & "','" & id_user & "',NOW(),'" & old_id_ovh_price & "','" & id_ovh_price & "'); SELECT LAST_INSERT_ID(); "
            id_log = execute_query(query, 0, True, "", "", "", "")
            '
            FormProductionCOP.view_list_cost(FormProductionCOP.id_design)
            FormProductionCOP.calculate_cost_management()
            FormProductionCOP.calculate_man()

            infoCustom("Data updated")

            Cursor = Cursors.Default
            Close()
        End If
    End Sub

    Private Sub BPickOVH_Click(sender As Object, e As EventArgs) Handles BPickOVH.Click
        FormPopUpOVH.ShowDialog()
    End Sub
End Class