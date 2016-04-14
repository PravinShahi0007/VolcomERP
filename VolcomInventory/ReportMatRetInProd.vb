Imports System.Drawing
Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Public Class ReportMatRetInProd
    Public Shared id_mat_prod_ret_in As String
    Sub viewDetailReturn()
        Dim query As String = "CALL view_mat_prod_ret('" + id_mat_prod_ret_in + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRetDetail.DataSource = data
    End Sub
    Private Sub ReportMatRetIn_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Try
            Dim query As String = "SELECT a.id_report_status,i.report_status,a.id_mat_prod_ret_in,b.id_prod_order_wo,h.id_prod_order, a.mat_prod_ret_in_date, a.mat_prod_ret_in_note,h.prod_order_number,b.prod_order_wo_number,desg.design_name,e.comp_name,e.comp_number,e.address_primary,a.id_comp_contact_from, "
            query += "a.mat_prod_ret_in_number  "
            query += "FROM tb_mat_prod_ret_in a "
            query += "INNER JOIN tb_prod_order_wo b ON a.id_prod_order_wo = b.id_prod_order_wo "
            query += "INNER JOIN tb_prod_order h ON b.id_prod_order = h.id_prod_order "
            query += "INNER JOIN tb_prod_demand_design pd_desg ON pd_desg.id_prod_demand_design = h.id_prod_demand_design "
            query += "INNER JOIN tb_m_design desg ON desg.id_design = pd_desg.id_design "
            query += "INNER JOIN tb_m_comp_contact d ON d.id_comp_contact = a.id_comp_contact_from "
            query += "INNER JOIN tb_m_comp e ON d.id_comp = e.id_comp "
            query += "INNER JOIN tb_lookup_report_status i ON i.id_report_status = a.id_report_status "
            query += "WHERE a.id_mat_prod_ret_in = '" & id_mat_prod_ret_in & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            LPONumber.Text = data.Rows(0)("prod_order_number").ToString
            LWONumber.Text = data.Rows(0)("prod_order_wo_number").ToString
            LFrom.Text = data.Rows(0)("comp_name").ToString
            LFromAddress.Text = data.Rows(0)("address_primary").ToString
            LDesign.Text = data.Rows(0)("design_name").ToString
            Dim start_date_arr() As String = data.Rows(0)("mat_prod_ret_in_date").ToString.Split(" ")
            LabelDate.Text = start_date_arr(0).ToString
            LabelNo.Text = data.Rows(0)("mat_prod_ret_in_number").ToString
            LabelNote.Text = data.Rows(0)("mat_prod_ret_in_note").ToString
            viewDetailReturn()
            load_mark_horz("47", id_mat_prod_ret_in, "2", "1", XrTable1)
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    'Custom Column
    Private Sub GVRetDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVRetDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class