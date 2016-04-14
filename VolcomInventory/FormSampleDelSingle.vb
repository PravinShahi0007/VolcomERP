Public Class FormSampleDelSingle 
    Public id_wh As String = "-1"
    Public action_pop As String = "-1"
    Public id_sample_list As New List(Of String)
    Public name_sample_list As New List(Of String)
    Dim dt As New DataTable
    Public id_pop_up As String = "-1"

    Private Sub FormSampleDelSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'initiation datatable jika blm ada
        Try
            dt.Columns.Add("code")
            dt.Columns.Add("name")
            dt.Columns.Add("size")
            dt.Columns.Add("color")
            dt.Columns.Add("id_det")
            dt.Columns.Add("id_sample")
            dt.Columns.Add("id_sample_ret_price")
            dt.Columns.Add("sample_ret_price")
            dt.Columns.Add("season")
            dt.Columns.Add("season_year")
        Catch ex As Exception
        End Try
        viewDetail()
    End Sub

    Sub insertDt(ByVal code_param As String, ByVal name_param As String, ByVal size_param As String, ByVal color_param As String, ByVal id_sample_param As String, ByVal id_sample_ret_price_param As String, ByVal sample_ret_price_param As String, ByVal season_param As String, ByVal season_year_param As String)
        Dim R As DataRow = dt.NewRow
        R("code") = code_param
        R("name") = name_param
        R("size") = size_param
        R("color") = color_param
        R("id_det") = "0"
        R("id_sample") = id_sample_param
        R("id_sample_ret_price") = id_sample_ret_price_param
        R("sample_ret_price") = sample_ret_price_param
        R("season") = season_param
        R("season_year") = season_year_param
        dt.Rows.Add(R)
    End Sub

    Sub viewDetail()
        Dim query As String = ""
        query = "CALL view_stock_sample('" + id_wh + "', '0', '0','0','9999-12-01','3') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProduct.DataSource = data
        If GVProduct.RowCount < 1 Then
            BtnChoose.Visible = False
        Else
            GVProduct.FocusedRowHandle = 0
            BtnChoose.Visible = True

            'isi column
            Dim query_price As String = "SELECT (a.sample_ret_price_name) AS 'Price Name', a.id_currency, a.id_design_price_type, a.id_sample, a.id_sample_ret_price, a.is_print, (a.sample_ret_price) AS 'Price', (a.sample_ret_price_date) AS 'Created Date', (a.sample_ret_price_start_date) AS 'Price Start Date' FROM tb_m_sample_ret_price a ORDER BY a.sample_ret_price_date ASC "
            Dim data_price As DataTable = execute_query(query_price, -1, True, "", "", "", "")
            RepositoryItemSearchLookUpEdit1.DataSource = Nothing
            RepositoryItemSearchLookUpEdit1.DataSource = data_price
            RepositoryItemSearchLookUpEdit1.PopulateViewColumns()
            RepositoryItemSearchLookUpEdit1.NullText = ""
            RepositoryItemSearchLookUpEdit1.View.Columns("id_sample_ret_price").Visible = False
            RepositoryItemSearchLookUpEdit1.View.Columns("id_sample").Visible = False
            RepositoryItemSearchLookUpEdit1.View.Columns("id_design_price_type").Visible = False
            RepositoryItemSearchLookUpEdit1.View.Columns("id_currency").Visible = False
            RepositoryItemSearchLookUpEdit1.View.Columns("is_print").Visible = False
            RepositoryItemSearchLookUpEdit1.View.Columns("Price").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            RepositoryItemSearchLookUpEdit1.View.Columns("Price").DisplayFormat.FormatString = "{0:n2}"
            RepositoryItemSearchLookUpEdit1.DisplayMember = "Price"
            RepositoryItemSearchLookUpEdit1.ValueMember = "id_sample_ret_price"
        End If
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormSampleDelSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVProduct_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVProduct.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVProduct_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProduct.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        Dim id_samplex As String = "0"
        Try
            id_samplex = GVProduct.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception
        End Try
        viewImages(PictureEdit1, get_setup_field("pic_path_sample") & "\", id_samplex, False)
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewImg.Click
        Cursor = Cursors.WaitCursor
        Dim id_samplex As String = "0"
        Try
            id_samplex = GVProduct.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception

        End Try
        viewImages(PictureEdit1, get_setup_field("pic_path_sample") & "\", id_samplex, True)
        Cursor = Cursors.Default
    End Sub

    Private Sub CheckEditProduct_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEditProduct.CheckedChanged
        Cursor = Cursors.WaitCursor
        GVProduct.OptionsBehavior.AutoExpandAllGroups = True
        Dim cek As String = CheckEditProduct.EditValue.ToString
        For i As Integer = 0 To (GVProduct.RowCount - 1)
            Try
                If cek Then
                    GVProduct.SetRowCellValue(i, "is_select", "Yes")
                Else
                    GVProduct.SetRowCellValue(i, "is_select", "No")
                End If
            Catch ex As Exception
            End Try
        Next
        Cursor = Cursors.Default
    End Sub

    Private clone As DataView = Nothing
    Private Sub GVProduct_ShownEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVProduct.ShownEditor
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Try
            If view.FocusedColumn.FieldName = "id_sample_ret_price" AndAlso TypeOf view.ActiveEditor Is DevExpress.XtraEditors.SearchLookUpEdit Then
                Dim edit As DevExpress.XtraEditors.SearchLookUpEdit
                Dim table As DataTable
                Dim row As DataRow

                edit = CType(view.ActiveEditor, DevExpress.XtraEditors.SearchLookUpEdit)
                Try
                    table = CType(edit.Properties.DataSource, DataTable)
                Catch ex As Exception
                    table = CType(edit.Properties.DataSource, DataView).Table
                End Try
                clone = New DataView(table)

                row = view.GetDataRow(view.FocusedRowHandle)
                clone.RowFilter = "[id_sample] = " + row("id_sample").ToString()
                edit.Properties.DataSource = clone
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GVProduct_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVProduct.HiddenEditor
        If clone IsNot Nothing Then
            clone.Dispose()
            clone = Nothing
        End If
    End Sub

    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        Cursor = Cursors.WaitCursor
        GVProduct.OptionsBehavior.AutoExpandAllGroups = True
        Dim cond_check As Boolean = True
        Dim cond_general As Boolean = False
        Dim cond_price As Boolean = True
        Dim alert_check As String = ""
        dt.Clear()

        Dim jum_select As Integer = 0
        For i As Integer = 0 To (GVProduct.RowCount - 1)
            Try
                Dim is_select As String = GVProduct.GetRowCellValue(i, "is_select").ToString
                If is_select = "Yes" Then
                    Dim code As String = GVProduct.GetRowCellValue(i, "code").ToString
                    Dim name As String = GVProduct.GetRowCellValue(i, "name").ToString
                    Dim size As String = GVProduct.GetRowCellValue(i, "size").ToString
                    Dim color As String = GVProduct.GetRowCellValue(i, "color").ToString
                    Dim id_sample As String = GVProduct.GetRowCellValue(i, "id_sample").ToString
                    Dim season As String = GVProduct.GetRowCellValue(i, "season").ToString
                    Dim season_year As String = GVProduct.GetRowCellValue(i, "season_year").ToString
                    'check price
                    Dim id_sample_ret_price As String = "-1"
                    Dim sample_ret_price As Decimal = 0.0
                    Try
                        id_sample_ret_price = GVProduct.GetRowCellValue(i, "id_sample_ret_price").ToString
                    Catch ex As Exception
                    End Try
                    If id_sample_ret_price = "-1" Then
                        cond_price = False
                    Else
                        sample_ret_price = Decimal.Parse(GVProduct.GetRowCellDisplayText(i, "id_sample_ret_price").ToString)
                        insertDt(code, name, size, color, id_sample, id_sample_ret_price, sample_ret_price, season, season_year)
                        jum_select = jum_select + 1
                    End If
                End If
                cond_general = True
            Catch ex As Exception
            End Try
        Next

        If Not cond_price Then
            stopCustom("Price can't blank")
        Else
            If jum_select < 1 Then
                cond_general = False
            End If
            If cond_general Then
                For j As Integer = 0 To (FormSampleDelDet.GVItemList.RowCount - 1)
                    Try
                        Dim id_sample_cek As String = FormSampleDelDet.GVItemList.GetRowCellValue(j, "id_sample").ToString
                        For j_sub As Integer = 0 To (dt.Rows.Count - 1)
                            Try
                                If id_sample_cek = dt.Rows(j_sub)("id_sample").ToString Then
                                    alert_check = dt.Rows(j_sub)("name").ToString + " / Size : " + dt.Rows(j_sub)("size").ToString + ", already selected !"
                                    cond_check = False
                                    Exit For
                                End If
                            Catch ex As Exception
                            End Try
                        Next
                    Catch ex As Exception
                    End Try
                Next

                Dim id_param As String = ""
                If Not cond_check Then
                    errorCustom(alert_check.ToString)
                Else
                    For ls As Integer = 0 To (dt.Rows.Count - 1)
                        Dim newRow As DataRow = (TryCast(FormSampleDelDet.GCItemList.DataSource, DataTable)).NewRow()
                        newRow("code") = dt.Rows(ls)("code").ToString
                        newRow("name") = dt.Rows(ls)("name").ToString
                        newRow("size") = dt.Rows(ls)("size").ToString
                        newRow("color") = dt.Rows(ls)("color").ToString
                        newRow("sample_del_det_qty") = 0.0
                        newRow("sample_del_det_qty_wh") = 0.0
                        newRow("sample_del_det_amount") = 0.0
                        newRow("sample_del_det_amount_ret") = 0.0
                        newRow("sample_del_det_note") = ""
                        newRow("id_sample_del_det") = dt.Rows(ls)("id_det").ToString
                        newRow("id_sample") = dt.Rows(ls)("id_sample").ToString
                        newRow("season") = dt.Rows(ls)("season").ToString
                        newRow("season_year") = dt.Rows(ls)("season_year").ToString
                        newRow("id_sample_ret_price") = dt.Rows(ls)("id_sample_ret_price").ToString
                        newRow("sample_ret_price") = Decimal.Parse(dt.Rows(ls)("sample_ret_price").ToString)
                        TryCast(FormSampleDelDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                        FormSampleDelDet.GCItemList.RefreshDataSource()
                        FormSampleDelDet.GVItemList.RefreshData()
                    Next
                    FormSampleDelDet.check_but()
                    Close()
                End If
            Else
                errorCustom("No item selected")
            End If
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub RepositoryItemSearchLookUpEdit1_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepositoryItemSearchLookUpEdit1.EditValueChanged
        'MsgBox(RepositoryItemSearchLookUpEdit1.View.GetFocusedRowCellValue("id_sample_ret_price"))
    End Sub

End Class