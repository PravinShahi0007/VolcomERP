Public Class FormViewProductionMRS
    Public id_mrs As String = "-1"
    Public id_wo As String = "-1"
    Public id_prod_order As String = "-1"
    Public id_comp_req_from As String = "-1"
    Public id_comp_req_to As String = "-1"
    Public id_report_status_g As String = "-1"
    '
    Private Sub FormViewProductionMRS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_mrs()

        Dim query As String = String.Format("SELECT prod_order_mrs_number,id_prod_order,id_prod_order_wo,prod_order_mrs_note,id_report_status,id_comp_contact_req_from,id_comp_contact_req_to,DATE_FORMAT(prod_order_mrs_date,'%Y-%m-%d') as prod_order_mrs_datex FROM tb_prod_order_mrs WHERE id_prod_order_mrs = '{0}'", id_mrs)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows(0)("id_prod_order_wo").ToString = "" Then
            TEWONumber.Visible = False
            LWONumber.Visible = False
        Else
            TEWONumber.Text = get_prod_wo_x(data.Rows(0)("id_prod_order_wo").ToString, "1")
        End If

        If data.Rows(0)("id_prod_order").ToString = "" Then
            TEPONumber.Visible = False
            TEDesign.Visible = False
            TEDesignCode.Visible = False
            LPONumber.Visible = False
            LDesignName.Visible = False
            LDesignCode.Visible = False
        Else
            TEPONumber.Text = get_prod_order_x(data.Rows(0)("id_prod_order").ToString, "2")
            TEDesign.Text = get_design_x(get_prod_demand_design_x(get_prod_order_x(data.Rows(0)("id_prod_order").ToString, "1"), "3"), "1")
            TEDesignCode.Text = get_design_x(get_prod_demand_design_x(get_prod_order_x(data.Rows(0)("id_prod_order").ToString, "1"), "3"), "2")
        End If

        id_comp_req_from = data.Rows(0)("id_comp_contact_req_from").ToString
        id_comp_req_to = data.Rows(0)("id_comp_contact_req_to").ToString

        TECompName.Text = get_company_x(get_id_company(id_comp_req_from), "1")
        TECompCode.Text = get_company_x(get_id_company(id_comp_req_from), "2")
        TECompToName.Text = get_company_x(get_id_company(id_comp_req_to), "1")
        TECompToCode.Text = get_company_x(get_id_company(id_comp_req_to), "2")

        id_report_status_g = data.Rows(0)("id_report_status").ToString
        TEDate.Text = view_date_from(data.Rows(0)("prod_order_mrs_datex").ToString, 0)
        MENote.Text = data.Rows(0)("prod_order_mrs_note").ToString
        TEMRSNumber.Text = data.Rows(0)("prod_order_mrs_number").ToString

    End Sub
    Sub view_mrs()
        Try
            Dim query As String
            query = "CALL view_prod_order_mrs('" & id_mrs & "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCMat.DataSource = data
            '
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Private Sub GVMat_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMat.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Private Sub GVMat_RowStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GVMat.RowStyle
        If GVMat.GetRowCellValue(e.RowHandle, "qty") > GVMat.GetRowCellValue(e.RowHandle, "qty_left") Then
            'GVMat.FocusedRowHandle()
            e.Appearance.BackColor = Color.Salmon
            e.Appearance.BackColor2 = Color.Salmon
            e.Appearance.Font = New Font(GVMat.Appearance.Row.Font, FontStyle.Bold)
        Else
            e.Appearance.BackColor = Color.White
            e.Appearance.BackColor2 = Color.White
            e.Appearance.Font = New Font(GVMat.Appearance.Row.Font, FontStyle.Regular)
        End If
    End Sub
    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_mrs
        FormReportMark.report_mark_type = "29"
        FormReportMark.is_view = "1"
        FormReportMark.ShowDialog()
    End Sub
End Class