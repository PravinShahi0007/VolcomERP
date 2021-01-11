Public Class ReportProposeEmpSalaryCompare
    Public id_employee_sal_pps As String = "-1"
    Public category As String = "1"
    Public data As DataTable = New DataTable
    Public is_pre As String = "-1"

    Private Sub ReportProposeEmpSalaryCompare_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim data_new As DataTable = New DataTable
        data_new.Columns.Add("id_employee_sal_pps_det", GetType(Integer))
        data_new.Columns.Add("no", GetType(String))
        data_new.Columns.Add("employee_code", GetType(String))
        data_new.Columns.Add("employee_name", GetType(String))
        data_new.Columns.Add("departement", GetType(String))
        data_new.Columns.Add("salary_type", GetType(String))
        data_new.Columns.Add("basic_salary", GetType(Decimal))
        data_new.Columns.Add("allow_job", GetType(Decimal))
        data_new.Columns.Add("allow_meal", GetType(Decimal))
        data_new.Columns.Add("allow_trans", GetType(Decimal))
        data_new.Columns.Add("allow_house", GetType(Decimal))
        data_new.Columns.Add("allow_car", GetType(Decimal))

        Dim salary_type As List(Of String) = New List(Of String)
        salary_type.Add("_current")
        salary_type.Add("")

        Dim total_c_basic_salary As Decimal = 0.0
        Dim total_c_allow_job As Decimal = 0.0
        Dim total_c_allow_meal As Decimal = 0.0
        Dim total_c_allow_trans As Decimal = 0.0
        Dim total_c_allow_house As Decimal = 0.0
        Dim total_c_allow_car As Decimal = 0.0
        Dim total_basic_salary As Decimal = 0.0
        Dim total_allow_job As Decimal = 0.0
        Dim total_allow_meal As Decimal = 0.0
        Dim total_allow_trans As Decimal = 0.0
        Dim total_allow_house As Decimal = 0.0
        Dim total_allow_car As Decimal = 0.0

        For i = 0 To data.Rows.Count - 1
            For j = 0 To salary_type.Count - 1
                data_new.Rows.Add(
                    data.Rows(i)("id_employee_sal_pps_det"),
                    (i + 1).ToString,
                    data.Rows(i)("employee_code").ToString,
                    data.Rows(i)("employee_name").ToString,
                    "Departement: " + data.Rows(i)("departement").ToString,
                    If(salary_type(j) = "", "Propose", "Current"),
                    data.Rows(i)("basic_salary" + salary_type(j)),
                    data.Rows(i)("allow_job" + salary_type(j)),
                    data.Rows(i)("allow_meal" + salary_type(j)),
                    data.Rows(i)("allow_trans" + salary_type(j)),
                    data.Rows(i)("allow_house" + salary_type(j)),
                    data.Rows(i)("allow_car" + salary_type(j))
                )

                If salary_type(j) = "" Then
                    total_basic_salary += data.Rows(i)("basic_salary")
                    total_allow_job += data.Rows(i)("allow_job")
                    total_allow_meal += data.Rows(i)("allow_meal")
                    total_allow_trans += data.Rows(i)("allow_trans")
                    total_allow_house += data.Rows(i)("allow_house")
                    total_allow_car += data.Rows(i)("allow_car")
                Else
                    total_c_basic_salary += data.Rows(i)("basic_salary_current")
                    total_c_allow_job += data.Rows(i)("allow_job_current")
                    total_c_allow_meal += data.Rows(i)("allow_meal_current")
                    total_c_allow_trans += data.Rows(i)("allow_trans_current")
                    total_c_allow_house += data.Rows(i)("allow_house_current")
                    total_c_allow_car += data.Rows(i)("allow_car_current")
                End If
            Next
        Next

        'add total
        data_new.Rows.Add(
            0,
            "",
            "",
            "TOTAL:",
            "",
            "Current",
            total_c_basic_salary,
            total_c_allow_job,
            total_c_allow_meal,
            total_c_allow_trans,
            total_c_allow_house,
            total_c_allow_car
        )

        data_new.Rows.Add(
            0,
            "",
            "",
            "TOTAL:",
            "",
            "Propose",
            total_basic_salary,
            total_allow_job,
            total_allow_meal,
            total_allow_trans,
            total_allow_house,
            total_allow_car
        )

        GCEmployee.DataSource = data_new

        GCBasicSalary.Caption = GCBasicSalary.Caption.Replace(" ", Environment.NewLine)
        GCJobAllowance.Caption = GCJobAllowance.Caption.Replace(" ", Environment.NewLine)
        GCMealAllowance.Caption = GCMealAllowance.Caption.Replace(" ", Environment.NewLine)
        GCTransportAllowance.Caption = GCTransportAllowance.Caption.Replace(" ", Environment.NewLine)
        GCHouseAllowance.Caption = GCHouseAllowance.Caption.Replace(" ", Environment.NewLine)
        GCAttendanceAllowance.Caption = GCAttendanceAllowance.Caption.Replace(" ", Environment.NewLine)
        GCTotalSalary.Caption = GCTotalSalary.Caption.Replace(" ", Environment.NewLine)

        Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_employee_sal_pps WHERE id_employee_sal_pps = " + id_employee_sal_pps, 0, True, "", "", "", "")

        If id_report_status = "0" Then
            XrTable1.Visible = False
        Else
            If is_pre = "-1" Then
                load_mark_horz(If(category = "1", "197", "229"), id_employee_sal_pps, "2", "1", XrTable1)
            Else
                pre_load_mark_horz(If(category = "1", "197", "229"), id_employee_sal_pps, "2", "2", XrTable1)
            End If
        End If
    End Sub
End Class