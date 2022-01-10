﻿Imports DevExpress.XtraEditors
Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraPrinting
Imports System.Xml

Public Class FormMain
    Public connection_problem As Boolean = False
    Dim id_super_user As String = "0"

    Sub badgeVisible()
        If (RibbonControl.SelectedPage.ToString = "General" Or RibbonControl.SelectedPage.ToString = "") And Badge1.Properties.Text > "0" Then
            Badge1.Visible = True
        Else
            Badge1.Visible = False
        End If
    End Sub

    Private Sub RibbonControl_SelectedPageChanged(sender As Object, e As EventArgs) Handles RibbonControl.SelectedPageChanged
        badgeVisible()
    End Sub

    '--------------GENERAL FUNCTION--------------------------------
    Private Sub FormMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'here global setting
        'Dim arguments As String() = Environment.GetCommandLineArgs()
        'MsgBox("GetCommandLineArgs: " + arguments(1).ToString)

        My.Application.ChangeCulture("en-US")
        My.Application.Culture.NumberFormat.NumberDecimalSeparator = ","
        My.Application.Culture.NumberFormat.NumberGroupSeparator = "."
        WindowState = FormWindowState.Maximized
        Cursor = Cursors.WaitCursor

        ShowInTaskbar = False
        Visible = False
        Opacity = 0
        Badge1.Visible = False

        apply_skin()

        Try
            DashboardToolStripMenuItem.Visible = False
            read_database_configuration()
            check_connection(True, "", "", "", "")
            check_pic_location()
            If get_setup_field("auto_update") = "1" Then
                check_and_update_version()
            End If
            'show hide login
            'LoginToolStripMenuItem.Visible = True
        Catch ex As Exception
            connection_problem = True

            FormDatabase.TopMost = True
            FormDatabase.Show()
            FormDatabase.Focus()
            FormDatabase.TopMost = False

            LoginToolStripMenuItem.Visible = False
            DashboardToolStripMenuItem.Visible = False
        End Try

        'change connection shortkey & role superuser
        id_super_user = get_setup_field("id_role_super_admin")
        For Each ex As Control In Me.Controls
            AddHandler ex.KeyDown, AddressOf FormMain_KeyUp
        Next
        '
        NotifyIconVI.ShowBalloonTip(2000, "Information", "Volcom ERP is now running." + Environment.NewLine + "Right click at volcom icon for more option.", ToolTipIcon.Info)
        Cursor = Cursors.Default
    End Sub

    Sub sop_index()
        '    Select Case id_user_head As id_user,2 As is_super_admin FROM tb_m_departement
        'UNION ALL
        Dim q As String = "SELECT id_user,MIN(is_super_admin) AS is_super_admin FROM(
 Select id_user_head As id_user,2 As is_super_admin FROM tb_m_departement
        UNION ALL
		SELECT id_user,is_super_admin FROM tb_sop_user
)tb WHERE tb.id_user='" & id_user & "'
HAVING NOT ISNULL(id_user)"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then
            Try
                FormSOPIndex.MdiParent = Me
                FormSOPIndex.is_super_admin = dt.Rows(0)("is_super_admin").ToString
                FormSOPIndex.Show()
                FormSOPIndex.WindowState = FormWindowState.Maximized
                FormSOPIndex.Focus()
            Catch ex As Exception
                errorProcess()
            End Try
        End If
    End Sub

    '----------- check version
    Sub check_and_update_version()
        Dim update_url As String = get_setup_field("update_address")
        Dim web As New Net.WebClient
        Dim LatestVersion As String = web.DownloadString(update_url & "version.txt") 'To download the Lastest Version from a specified URL.
        If Application.ProductVersion.ToString < LatestVersion Then
            infoCustom("New version of application is available! System will automatically update to new version.")
            My.Computer.Network.DownloadFile(update_url & "setup.exe", Application.StartupPath & "\setup.exe", "", "", True, 100, True)
            My.Computer.Network.DownloadFile(update_url & "SetupVolcomERP.msi", Application.StartupPath & "\SetupVolcomERP.msi", "", "", True, 100, True)
            infoCustom("File downloaded. Begin installing new version.")
            Process.Start(Application.StartupPath & "\setup.exe")
            Application.Exit()
        End If
    End Sub

    Sub checkChangePass()
        If is_change_pass_user = "2" Then
            infoCustom("Welcome to Volcom ERP System. Please setup your account first.")
            FormAccount.Text = "First Login Configuration"
            FormAccount.BtnCancel.Visible = False
            FormAccount.ShowDialog()
        End If
    End Sub
    '=========HIDE WHEN MINIMIZED
    Private Sub FormMain_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If WindowState = FormWindowState.Minimized Then
            Me.Hide()
        End If
    End Sub

    '-----------------------CHANGE CONNECTION (Admin Only)
    Private Sub FormMain_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp

    End Sub

    '-----------------------Notification
    Private Sub TimerNotif_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerNotif.Tick
        ' Try
        Dim query_notif As String = "CALL view_notif_list('" + id_user + "', 'AND notif_det.is_read=2') "
            Dim data_notif As DataTable = execute_query(query_notif, -1, True, "", "", "", "")
            checkTotalNotif(data_notif.Rows.Count)
            For i As Integer = 0 To data_notif.Rows.Count - 1
                If data_notif.Rows(i)("id_type").ToString = "2" Then
                showNotify(data_notif(i)("notif_title").ToString, data_notif(i)("notif_content").ToString, "2#" + data_notif(i)("notif_frm_to").ToString + "#" + data_notif(i)("id_notif_det").ToString + "#" + data_notif(i)("id_report").ToString + "#" + data_notif(i)("report_number").ToString + "#" + data_notif(i)("notif_tag").ToString)
            Else
                showNotify(data_notif(i)("notif_title").ToString, data_notif(i)("notif_content").ToString, data_notif.Rows(i)("id_type").ToString)
            End If
            Next
        '  Catch ex As Exception
        'errorConnection()
        'End Try
    End Sub

    Sub checkNumberNotif()
        Dim query_notif As String = "SELECT get_number_notif('" + id_user + "', '3') AS jum"
        Dim data_notif As DataTable = execute_query(query_notif, -1, True, "", "", "", "")
        checkTotalNotif(data_notif.Rows(0)("jum"))
    End Sub

    Sub checkTotalNotif(ByVal n_par As Integer)
        If n_par <= 0 Then
            Badge1.Properties.Text = "0"
            Badge1.Visible = False
        Else
            If n_par > 99 Then
                Badge1.Properties.TextMargin = New Padding(3, 0, 0, 0)
            ElseIf n_par >= 10 And n_par <= 99 Then
                Badge1.Properties.TextMargin = New Padding(4, 0, 0, 0)
            Else
                Badge1.Properties.TextMargin = New Padding(6, 0, 0, 0)
            End If
            Badge1.Properties.Text = n_par.ToString
            badgeVisible()
        End If
    End Sub

    Private Sub AlertControlNotif_AlertClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.Alerter.AlertClickEventArgs) Handles AlertControlNotif.AlertClick
        Cursor = Cursors.WaitCursor
        If e.Info.Tag.ToString = "1" Then
            Try
                FormWork.MdiParent = Me
                FormWork.Show()
                FormWork.WindowState = FormWindowState.Maximized
                FormWork.Focus()
                FormWork.XTCGeneral.SelectedTabPageIndex = 0
                'FormWork.view_mark_need()
            Catch ex As Exception
                errorProcess()
            End Try
        ElseIf e.Info.Tag.ToString = "2"
            Dim col_foc_str As String() = Split(e.Info.Tag.ToString, "#")
            Dim frm As String = col_foc_str(1)
            Dim id_notif_det As String = col_foc_str(2)
            Dim id_report As String = col_foc_str(3)
            Dim report_number As String = col_foc_str(4)
            Dim notif_tag As String = col_foc_str(5)
            Dim rmt As String = col_foc_str(6)
            frmNotif(frm, id_report, rmt, report_number, notif_tag)
        ElseIf e.Info.Tag.ToString = "3" Then
            Try
                FormFGDesignList.MdiParent = Me
                FormFGDesignList.id_pop_up = "1"
                FormFGDesignList.Show()
                FormFGDesignList.WindowState = FormWindowState.Maximized
                FormFGDesignList.Focus()
                FormFGDesignList.viewData()
            Catch ex As Exception
                errorProcess()
            End Try
        Else
            'no action
        End If
        Cursor = Cursors.Default
    End Sub

    'check pic location
    Sub check_pic_location()
        'picture location
        Dim err_pic As String = "-1"
        Try
            Dim pic_path_mat As String = get_setup_field("pic_path_mat")
            Dim pic_path_sample As String = get_setup_field("pic_path_sample")
            Dim pic_path_design As String = get_setup_field("pic_path_design")
            Dim pic_path_logo As String = get_setup_field("pic_path_logo")

            If pic_path_mat = "" Or pic_path_sample = "" Or pic_path_design = "" Or pic_path_logo = "" Then
                err_pic = "1"
            Else
                If Not System.IO.Directory.Exists(pic_path_sample) Or Not System.IO.Directory.Exists(pic_path_mat) Or Not System.IO.Directory.Exists(pic_path_design) Or Not System.IO.Directory.Exists(pic_path_logo) Then
                    err_pic = "1"
                Else
                    If Not System.IO.File.Exists(pic_path_mat & "\default.jpg") Or Not System.IO.File.Exists(pic_path_sample & "\default.jpg") Or Not System.IO.File.Exists(pic_path_design & "\default.jpg") Or Not System.IO.File.Exists(pic_path_logo & "\default.jpg") Then
                        err_pic = "2"
                    End If
                End If
            End If
        Catch ex As Exception
            'err_pic = "1"
            MsgBox(ex.ToString)
        End Try
        '
        If err_pic <> "-1" Then
            LoginToolStripMenuItem.Visible = False
            stopCustom("Connection error, please contact administrator.")
            'FormSetupPicLocation.TopMost = True
            'FormSetupPicLocation.Show()
            'FormSetupPicLocation.Focus()
            'FormSetupPicLocation.TopMost = False
        Else
            LoginToolStripMenuItem.Visible = True
            DashboardToolStripMenuItem.Visible = False
            loadImgPath()
        End If
    End Sub
    'Show Ribbon
    Sub show_rb(ByVal formnamex As String)
        formName = formnamex
        RPSubMenu.Visible = True
        RibbonControl.SelectedPage = RPSubMenu

        'show contact
        If formName = "FormMasterCompany" Then
            BBContact.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If

        'show mapping
        If formName = "FormAccess" Or formName = "FormMarkAssign" Then
            BBMapping.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If

        'show duplicate
        If formName = "FormAccess" Or formName = "FormMasterSample" Or formName = "FormFGDesignList" Or formName = "FormProposeEmpSalary" Then
            BBDuplicate.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If

        If formName = "FormMasterWH" Then
            If FormMasterWH.XTCWHMain.SelectedTabPageIndex = 0 Then
                BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                BBEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            Else
                BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                BBEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            End If
        End If

        If formName = "FormAccountingFYear" Then
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BBEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

            BBView.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If

        If formName = "formemployeepps" Or formName = "FormEmpPerAppraisal" Or formName = "FormOpt" Or formName = "FormAccountingSummary" Or formName = "FormAccountingSummary" Or formName = "FormMasterDesignCOP" Or formName = "FormSalesOrderList" Or formName = "FormSalesOrderSvcLevel" Or formName = "FormWHImportDO" Or formName = "FormWHSvcLevel" Then
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BBEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If

        If formName = "FormFGStockOpnameStore" Or formName = "FormFGStockOpnameWH" Or formName = "FormMatStockOpname" Then
            BBView.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If

        If formName = "FormFGTrfReceive" Or formName = "FormSOHPrice" Or formName = "FormMasterProduct" Or formName = "FormSNIWH" Then
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If

        If formName = "FormListStore" Or formName = "FormBarcodeProduct" Or formName = "FormReportBudget" Or formName = "FormInvMat" Or formName = "FormWork" Or formName = "FormSOHSum" Or formName = "FormPurcAsset" Or formName = "FormProductionWOList" Or formName = "FormFGDistScheme" Or formName = "FormFGLineList" Or formName = "FormFGTracking" Or formName = "FormFGStock" Or formName = "FormMatStock" Or formName = "FormSalesWeekly" Or formName = "FormFGWoffList" Or formName = "FormFGDistSchemaSetup" Or formName = "FormFGProdList" Or formName = "FormSamplePLExport" Or formName = "FormFGWHAllocLog" Or formName = "FormEmpReview" Or formName = "FormProductionSummary" Or formName = "FormWHDelEmptyStock" Or formName = "FormFGTransList" Or formName = "FormProdClosing" Or formName = "FormOLStoreSummary" Or formName = "FormFGAging" Or formName = "FormFGTransSummary" Or formName = "FormFGFirstDel" Or formName = "FormFGCompareStockCard" Or formName = "FormEmpUniReport" Or formName = "FormBudgetExpenseView" Or formName = "FormPurcItemStock" Or formName = "FormEmpUniSumReport" Or formName = "FormProductionHO" Or formName = "FormSalesOrderReport" Or formName = "FormSalesRecord" Or formName = "FormARAging" Or formName = "FormInvoiceTracking" Or formName = "FormAREvaluation" Or formName = "FormARCollectionAvg" Or formName = "FormDocTracking" Or formName = "FormSalesInv" Or formName = "FormLineList" Or formName = "FormPriceChecker" Or formName = "FormBulanImport" Then
            RGAreaManage.Visible = False
        End If

        If formName = "FormSampleStock" Then
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BBEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BBRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BBSwitch.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If

        If formName = "FormAccountingJournal" Then
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BBRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If

        If formName = "FormGuide" Or formName = "FormNotification" Then
            RGAreaManage.Visible = False
            RGAreaPrint.Visible = False
        End If

        If formName = "FormCompGroupEmail" Or formName = "FormSNIBarcode" Then
            RGAreaManage.Visible = False
            RGAreaPrint.Visible = False
        End If

        If formName = "FormEmpLeave" Or formName = "FormInbound3PL" Or formName = "FormScanReturn" Or formName = "FormSNIQC" Or formName = "FormPreCalFGPO" Then
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If
    End Sub
    'Hide Ribbon
    Sub hide_rb()
        RGAreaManage.Visible = True
        RPSubMenu.Visible = False

        If formName = "FormMasterCompany" Then
            BBContact.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If
        If formName = "FormAccess" Or formName = "FormMarkAssign" Then
            BBMapping.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If
        If formName = "FormAccess" Or formName = "FormMasterSample" Or formName = "FormFGDesignList" Then
            BBDuplicate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If

        If formName = "FormMasterWH" Or formName = "FormMasterDesignCOP" Then
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            'BBSwitch.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If

        If formName = "FormAccountingFYear" Then
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always

            BBView.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If

        If formName = "FormAccountingSummary" Or formName = "FormSalesOrderList" Or formName = "FormSalesOrderSvcLevel" Or formName = "FormWHImportDO" Or formName = "FormWHSvcLevel" Then
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If

        If formName = "FormMatStockOpname" Then
            BBView.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If
        If formName = "FormFGStockOpnameStore" Or formName = "FormFGStockOpnameWH" Then
            BBView.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If

        If formName = "FormFGTrfReceive" Then
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If

        If formName = "FormListStore" Or formName = "FormWork" Or formName = "FormDebitNote" Or formName = "FormProductionWOList" Or formName = "FormFGDistScheme" Or formName = "FormFGLineList" Or formName = "FormFGTracking" Or formName = "FormFGStock" Or formName = "FormMatStock" Or formName = "FormSalesWeekly" Or formName = "FormFGWoffList" Or formName = "FormFGDistSchemaSetup" Or formName = "FormFGProdList" Or formName = "FormSamplePLExport" Or formName = "FormFGWHAllocLog" Or formName = "FormEmpReview" Or formName = "FormProductionSummary" Or formName = "FormWHDelEmptyStock" Or formName = "FormFGTransList" Or formName = "FormProdClosing" Or formName = "FormOLStoreSummary" Or formName = "FormFGAging" Or formName = "FormFGTransSummary" Or formName = "FormFGFirstDel" Or formName = "FormFGCompareStockCard" Or formName = "FormEmpUniReport" Or formName = "FormBudgetExpenseView" Or formName = "FormPurcItemStock" Or formName = "FormEmpUniSumReport" Or formName = "FormProductionHO" Or formName = "FormSalesOrderReport" Or formName = "FormSalesRecord" Or formName = "FormARAging" Or formName = "FormInvoiceTracking" Or formName = "FormAREvaluation" Or formName = "FormARCollectionAvg" Or formName = "FormDocTracking" Or formName = "FormSalesInv" Or formName = "FormLineList" Or formName = "FormPriceChecker" Or formName = "FormBulanImport" Then
            RGAreaManage.Visible = True
        End If

        If formName = "FormSampleStock" Then
            BBSwitch.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If

        If formName = "FormAccountingJournal" Then
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If

        If formName = "FormSOHSum" Then
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always

            BBRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            RGAreaManage.Visible = True
        End If

        If formName = "FormSOHPrice" Then
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If

        If formName = "FormOpt" Then
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If

        If formName = "FormEmpPerAppraisal" Then
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If

        'edit only
        If formName = "FormMasterProduct" Or formName = "FormSNIWH" Then
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If


        If formName = "FormGuide" Then
            RGAreaManage.Visible = True
            RGAreaPrint.Visible = True
        End If

        If formName = "FormNotification" Then
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            RGAreaPrint.Visible = True
        End If

        If formName = "FormEmpLeave" Or formName = "FormInbound3PL" Or formName = "FormScanReturn" Or formName = "FormSNIQC" Or formName = "FormPreCalFGPO" Then
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If
        ''mapping COA
        'If formName = "FormSamplePurchase" _
        'Or formName = "FormSampleReceive" _
        'Or formName = "FormSampleAdjustment" _
        'Or formName = "FormMatPurchase" _
        'Or formName = "FormMatRecPurc" _
        'Or formName = "FormMatWO" _
        'Or formName = "FormMatRecWO" _
        'Or formName = "FormMatRet" _
        'Or formName = "FormMatAdj" _
        'Or formName = "FormMatPL" _
        'Then
        '    BBMappingCOA.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        'End If

        'hide all excep print n close
        If formName = "FormCompGroupEmail" Or formName = "FormSNIBarcode" Then
            RGAreaManage.Visible = DevExpress.XtraBars.BarItemVisibility.Always
            RGAreaPrint.Visible = DevExpress.XtraBars.BarItemVisibility.Always
        End If

        If formName = "FormBarcodeProduct" Then
            RGAreaManage.Visible = True
        End If

        formName = ""

        'set 0 progress bar
        BEProgress.EditValue = 0
    End Sub
    '-------------STRIP MENU -------------------------------
    'Exit Strip
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        NotifyIconVI.Visible = False
        Close()
        'Application.Exit()
    End Sub
    'Dashboard Strip
    Private Sub DashboardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DashboardToolStripMenuItem.Click
        Show()
        WindowState = FormWindowState.Maximized
        BringToFront()
        Activate()
        'For Eac h openForm In Application.OpenForms()
        '    openForm.BringToFront()
        'Next
        Focus()
    End Sub
    'Login Strip
    Private Sub LoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginToolStripMenuItem.Click
        FormLogin.Show()
    End Sub
    'Logout Strip
    Sub logOut()
        Dim confirm As DialogResult = XtraMessageBox.Show("Are you sure to logout this system?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            logOutCmd()
        End If
    End Sub

    Sub logOutCmd()
        Try
            TESearchNavbar.Text = Nothing
            'close all form
            For Each frm In MdiChildren
                If frm.Name <> "FormMain" Then
                    frm.Close()
                End If
            Next

            'log
            Dim u As New ClassUser()
            u.logLogin("2")

            id_user = Nothing
            id_role_login = Nothing
            username_user = Nothing
            name_user = Nothing
            is_change_pass_user = Nothing
            restartMenu()
            DashboardToolStripMenuItem.Visible = False
            LogoutToolStripMenuItem.Visible = False
            LoginToolStripMenuItem.Visible = True
            ShowInTaskbar = False
            Visible = False
            TimerNotif.Enabled = False
            Badge1.Visible = False
            Opacity = 0


            'close all notif
            Dim array = AlertControlNotif.AlertFormList.ToArray()
            If array.Count() > 0 Then
                For i As Integer = 0 To array.Count() - 1
                    array(i).Close()
                Next
            End If
            NotifyIconVI.ShowBalloonTip(2000, "Information", "You're already logout from system." + Environment.NewLine + "Right click here for more option.", ToolTipIcon.Info)
        Catch ex As Exception
            errorProcess()
        End Try
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        Show()
        WindowState = FormWindowState.Maximized
        logOut()
    End Sub
    Private Sub BBLogout_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBLogout.ItemClick
        logOut()
    End Sub
    '---------------SUBMENU (ADD/EDIT/DELETE)---------------------------------
    'New Data
    Private Sub BBNew_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBNew.ItemClick
        Cursor = Cursors.WaitCursor
        If formName = "FormMasterArea" Then
            'AREA
            If FormMasterArea.XTCArea.SelectedTabPageIndex = 0 Then
                'country
                FormMasterCountrySingle.id_country = "-1"
                FormMasterCountrySingle.ShowDialog()
            ElseIf FormMasterArea.XTCArea.SelectedTabPageIndex = 1 Then
                'state
                FormMasterRegionSingle.id_region = "-1"
                FormMasterRegionSingle.id_country = FormMasterArea.GVCountry.GetFocusedRowCellDisplayText("id_country").ToString
                FormMasterRegionSingle.ShowDialog()
            ElseIf FormMasterArea.XTCArea.SelectedTabPageIndex = 2 Then
                'state
                FormMasterStateSingle.id_state = "-1"
                FormMasterStateSingle.id_region = FormMasterArea.GVRegion.GetFocusedRowCellDisplayText("id_region").ToString
                FormMasterStateSingle.ShowDialog()
            ElseIf FormMasterArea.XTCArea.SelectedTabPageIndex = 3 Then
                'city
                FormMasterCitySingle.id_city = "-1"
                FormMasterCitySingle.id_state = FormMasterArea.GVState.GetFocusedRowCellDisplayText("id_state").ToString
                FormMasterCitySingle.ShowDialog()
            Else
                'kecamatan
                FormKecamatanSingle.id_sub_district = "-1"
                FormKecamatanSingle.id_city = FormMasterArea.GVCity.GetFocusedRowCellDisplayText("id_city").ToString
                FormKecamatanSingle.ShowDialog()
            End If
        ElseIf formName = "FormMasterCompany" Then
            'COMPANY
            FormMasterCompanySingle.id_company = "-1"
            FormMasterCompanySingle.ShowDialog()
        ElseIf formName = "FormMasterCompanyCategory" Then
            'COMPANY CATEGORY
            FormMasterCompanyCategorySingle.id_company_category = "-1"
            FormMasterCompanyCategorySingle.ShowDialog()
        ElseIf formName = "FormMasterDepartement" Then
            'DEPARTMENT
            FormMasterDepartementSingle.id_departement = "-1"
            FormMasterDepartementSingle.ShowDialog()
        ElseIf formName = "FormMasterRawMaterialCat" Then
            'OLD MATERIAL CATEGORY
            FormMasterRawMaterialCatSingle.action = "ins"
            FormMasterRawMaterialCatSingle.ShowDialog()
        ElseIf formName = "FormMasterItemColor" Then
            'OLD ITEM COLOR
            FormMasterItemColorSingle.action = "ins"
            FormMasterItemColorSingle.ShowDialog()
        ElseIf formName = "FormMasterItemSize" Then
            'OLD ITEM SIZE
            FormMasterItemSizeSingle.action = "ins"
            FormMasterItemSizeSingle.ShowDialog()
        ElseIf formName = "FormMasterUser" Then
            'USER
            FormMasterUserSingle.id_user = "-1"
            FormMasterUserSingle.ShowDialog()
        ElseIf formName = "FormAccess" Then
            'ACCESS
            If FormAccess.XTCMenuManage.SelectedTabPageIndex = 2 Then 'new role
                FormAccessRoleSingle.action = "ins"
                FormAccessRoleSingle.LabelRole.Text = "Add New Role"
                FormAccessRoleSingle.ShowDialog()
            ElseIf FormAccess.XTCMenuManage.SelectedTabPageIndex = 1 Then 'new menu
                FormAccessMenuSingle.action = "ins"
                FormAccessMenuSingle.ShowDialog()
            ElseIf FormAccess.XTCMenuManage.SelectedTabPageIndex = 0 Then 'new form
                If FormAccess.XTCForm.SelectedTabPageIndex = 0 Then 'new Form
                    FormAccessFrmSingle.action = "ins"
                    FormAccessFrmSingle.ShowDialog()
                ElseIf FormAccess.XTCForm.SelectedTabPageIndex = 1 Then 'new form control
                    FormAccessProcessSingle.action = "ins"
                    FormAccessProcessSingle.id_form = FormAccess.GVForm.GetFocusedRowCellDisplayText("id_form").ToString()
                    FormAccessProcessSingle.is_required = False
                    FormAccessProcessSingle.LabelTitle.Text = FormAccess.GVForm.GetFocusedRowCellDisplayText("form_name").ToString
                    FormAccessProcessSingle.ShowDialog()
                End If
            End If
        ElseIf formName = "FormSeason" Then
            'SEASON
            If FormSeason.XTCMainSeason.SelectedTabPageIndex = 0 Then 'Internal Season
                If FormSeason.XTCSeason.SelectedTabPageIndex = 0 Then
                    'new range
                    FormRangeSingle.action = "ins"
                    FormRangeSingle.ShowDialog()
                ElseIf FormSeason.XTCSeason.SelectedTabPageIndex = 1 Then
                    'new season
                    FormSeasonSingle.action = "ins"
                    FormSeasonSingle.ShowDialog()
                ElseIf FormSeason.XTCSeason.SelectedTabPageIndex = 2 Then
                    'new delivery
                    FormDeliverySingle.action = "ins"
                    FormDeliverySingle.GCtrlDelivery.Text = "Range " + FormSeason.range_season.ToString + " - Season " + FormSeason.season.ToString
                    FormDeliverySingle.ShowDialog()
                End If
            Else 'Origin Season
                FormSeasonorignSingle.action = "ins"
                FormSeasonorignSingle.ShowDialog()
            End If
        ElseIf formName = "FormMasterUOM" Then
            'UOM
            FormMasterUOM.PCUOM.Visible = True
            FormMasterUOM.TxtUOM.Text = ""
            FormMasterUOM.ErrorProviderUom.SetError(FormMasterUOM.TxtUOM, "")
            FormMasterUOM.action = "ins"
        ElseIf formName = "FormMasterRawMat" Then
            'OLD RAW MATERIAL
            If FormMasterRawMat.XTCRawMat.SelectedTabPageIndex = 0 Then 'new raw mat old
                FormMasterRawMatSingle.action = "ins"
                FormMasterRawMatSingle.ShowDialog()
            ElseIf FormMasterRawMat.XTCRawMat.SelectedTabPageIndex = 1 Then 'new raw mat lot old
                FormMasterRawMatLotSingle.action = "ins"
                FormMasterRawMatLotSingle.loadku = 0
                FormMasterRawMatLotSingle.ShowDialog()
            ElseIf FormMasterRawMat.XTCRawMat.SelectedTabPageIndex = 2 Then 'new raw mat supplier old
                FormMasterRawMatSupplierSingle.action = "ins"
                FormMasterRawMatSupplierSingle.id_raw_mat_detail = FormMasterRawMat.GVLot.GetFocusedRowCellDisplayText("id_raw_mat_detail").ToString
                FormMasterRawMatSupplierSingle.ShowDialog()
            End If
        ElseIf formName = "FormSetupRawMatCode" Then
            'OLD CODE
            FormSetupRawMatCodeSingle.action = "ins"
            FormSetupRawMatCodeSingle.ShowDialog()
        ElseIf formName = "FormMasterRawMaterial" Then
            'NEW MASTER RAW MATERIAL
            If FormMasterRawMaterial.XTCMaterialType.SelectedTabPageIndex = 0 Then 'new raw material
                FormMasterRawMaterialSingle.action = "ins"
                FormMasterRawMaterialSingle.ShowDialog()
            ElseIf FormMasterRawMaterial.XTCMaterialType.SelectedTabPageIndex = 1 Then 'new raw material detail
                'FormMasterRawMaterialDetSingle.action = "ins"

                'FormMasterRawMaterialDetSingle.id_mat = FormMasterRawMaterial.GVRawMat.GetFocusedRowCellValue("id_mat").ToString
                'FormMasterRawMaterialDetSingle.LabelPrintedName.Text = FormMasterRawMaterial.GVRawMat.GetFocusedRowCellDisplayText("mat_display_name").ToString
                'FormMasterRawMaterialDetSingle.TxtMaterialTypeCode.Text = FormMasterRawMaterial.GVRawMat.GetFocusedRowCellDisplayText("mat_code").ToString

                'FormMasterRawMaterialDetSingle.ShowDialog()
            End If
        ElseIf formName = "FormMasterOVH" Then
            'OVH
            FormMasterOVHSingle.id_ovh = "-1"
            FormMasterOVHSingle.ShowDialog()
        ElseIf formName = "FormProdDemand" Then
            'PRODUCTION DEMAND
            FormProdDemandSingle.action = "ins"
            FormProdDemandSingle.id_report_status = "-1"
            FormProdDemandSingle.ShowDialog()
        ElseIf formName = "FormMasterCode" Then
            'MASTER CODE
            If FormMasterCode.XTCCode.SelectedTabPageIndex = 0 Then
                'code
                FormMasterCodeSingle.id_code = "-1"
                FormMasterCodeSingle.ShowDialog()
            ElseIf FormMasterCode.XTCCode.SelectedTabPageIndex = 1 Then
                'code detail
                FormMasterCodeDetSingle.id_code_det = "-1"
                FormMasterCodeDetSingle.id_code = FormMasterCode.GVCode.GetFocusedRowCellDisplayText("id_code").ToString
                FormMasterCodeDetSingle.ShowDialog()
            End If
        ElseIf formName = "FormTemplateCode" Then
            'MASTER CODE TEMPLATE
            If FormTemplateCode.XTCTemplateCode.SelectedTabPageIndex = 0 Then
                'code
                FormTemplateCodeSingle.id_template_code = "-1"
                FormTemplateCodeSingle.ShowDialog()
            End If
        ElseIf formName = "FormMasterSample" Then
            'MASTER SAMPLE
            FormMasterSampleDet.id_sample = "-1"
            FormMasterSampleDet.ShowDialog()
        ElseIf formName = "FormMasterProduct" Then
            'MASTER PRODUCT
            If FormMasterProduct.XTCProduct.SelectedTabPageIndex = 0 Then
                'design
                FormMasterDesignSingle.id_design = "-1"
                FormMasterDesignSingle.ShowDialog()
            ElseIf FormMasterProduct.XTCProduct.SelectedTabPageIndex = 1 Then
                'product
                FormMasterProductDet.id_product = "-1"
                FormMasterProductDet.id_design = FormMasterProduct.GVDesign.GetFocusedRowCellDisplayText("id_design").ToString
                FormMasterProductDet.ShowDialog()
            End If
        ElseIf formName = "FormBOM" Then
            'BOM
            If FormBOM.XTCBOMSelection.SelectedTabPageIndex = 0 Then
                'Try
                FormBOMDesignSingle.id_pop_up = "-1"
                FormBOMDesignSingle.id_design = FormBOM.GVDesign.GetFocusedRowCellValue("id_design").ToString
                FormBOMDesignSingle.TEQtyPD.EditValue = FormBOM.GVDesign.GetFocusedRowCellValue("qty")
                'FormBOMDesignSingle.id_prod_demand_design = FormBOM.GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString
                FormBOMDesignSingle.ShowDialog()
                'Catch ex As Exception
                'stopCustom("Please try again later.")
                'End Try
            ElseIf FormBOM.XTCBOMSelection.SelectedTabPageIndex = 1 Then
                FormBOMSingle.id_bom = "-1"
                FormBOMSingle.id_product = FormBOM.GVProduct.GetFocusedRowCellDisplayText("id_product").ToString
                FormBOMSingle.ShowDialog()
            ElseIf FormBOM.XTCBOMSelection.SelectedTabPageIndex = 2 Then
                Try
                    FormBOMSingle.id_pop_up = "1"
                    FormBOMSingle.id_bom_approve = "-1"
                    FormBOMSingle.id_design = FormBOM.GVPerDesign.GetFocusedRowCellDisplayText("id_design").ToString
                    FormBOMSingle.ShowDialog()
                Catch ex As Exception
                    stopCustom("Please try again later.")
                End Try
            End If
        ElseIf formName = "FormSamplePL" Then
            'PACKING LIST SAMPLE
            FormSamplePLSingle.action = "ins"
            FormSamplePLSingle.id_pl_sample_purc = "-1"
            FormSamplePLSingle.id_comp_contact_to = "-1"
            FormSamplePLSingle.id_comp_contact_from = "-1"
            FormSamplePLSingle.id_sample_purc = "-1"
            FormSamplePLSingle.ShowDialog()
        ElseIf formName = "FormSamplePurchase" Then
            'purchase sample
            If FormSamplePurchase.XTCTabReceive.SelectedTabPageIndex = 0 Then
                'normal
                FormSamplePurchaseDet.id_sample_purc = "-1"
                FormSamplePurchaseDet.ShowDialog()
            Else
                'from planning
                FormSamplePurchaseDet.id_sample_plan = FormSamplePurchase.GVSamplePlan.GetFocusedRowCellDisplayText("id_sample_plan").ToString
                FormSamplePurchaseDet.id_sample_purc = "-1"
                FormSamplePurchaseDet.ShowDialog()
            End If
        ElseIf formName = "FormSampleReceive" Then
            'receive sample
            If FormSampleReceive.XTCTabReceive.SelectedTabPageIndex = 0 Then
                FormSampleReceiveDet.id_receive = "-1"
                FormSampleReceiveDet.ShowDialog()
            Else
                FormSampleReceiveDet.id_receive = "-1"
                FormSampleReceiveDet.id_order = FormSampleReceive.GVSamplePurchaseNeed.GetFocusedRowCellDisplayText("id_sample_purc").ToString
                FormSampleReceiveDet.ShowDialog()
            End If
        ElseIf formName = "FormSamplePR" Then
            'Payment Request Sample
            If FormSamplePR.XTCTabPR.SelectedTabPageIndex = 0 Then
                FormSamplePRDet.id_pr = "-1"
                FormSamplePRDet.ShowDialog()
            ElseIf FormSamplePR.XTCTabPR.SelectedTabPageIndex = 1 Then
                FormSamplePRDet.id_pr = "-1"
                FormSamplePRDet.id_purc = FormSamplePR.GVSamplePurchaseNeed.GetFocusedRowCellDisplayText("id_sample_purc").ToString
                FormSamplePRDet.ShowDialog()
            ElseIf FormSamplePR.XTCTabPR.SelectedTabPageIndex = 2 Then
                FormSamplePRDet.id_pr = "-1"
                FormSamplePRDet.id_rec = FormSamplePR.GVMatReceive.GetFocusedRowCellDisplayText("id_sample_purc_rec").ToString
                FormSamplePRDet.ShowDialog()
            End If
        ElseIf formName = "FormMasterWH" Then
            'WH & LOCATOR
            If FormMasterWH.XTCWH.SelectedTabPageIndex = 1 Then 'Locator
                FormMasterWHSingle.id_wh_locator = FormMasterWH.GVLocator.GetFocusedRowCellDisplayText("id_wh_locator").ToString
                FormMasterWHSingle.action = "ins"
                FormMasterWHSingle.ShowDialog()
            ElseIf FormMasterWH.XTCWH.SelectedTabPageIndex = 2 Then 'Rack
                FormMasterWHRackSingle.id_wh_rack = FormMasterWH.GVRack.GetFocusedRowCellDisplayText("id_wh_rack").ToString
                FormMasterWHRackSingle.action = "ins"
                FormMasterWHRackSingle.ShowDialog()
            ElseIf FormMasterWH.XTCWH.SelectedTabPageIndex = 3 Then 'Drawer
                FormMasterWHDrawerSingle.id_wh_drawer = FormMasterWH.GVDrawer.GetFocusedRowCellDisplayText("id_wh_drawer").ToString
                FormMasterWHDrawerSingle.action = "ins"
                FormMasterWHDrawerSingle.ShowDialog()
            End If
        ElseIf formName = "FormSampleReceipt" Then
            'RECEIPT SAMPLE
            FormSampleReceiptSingle.action = "ins"
            FormSampleReceiptSingle.id_receipt_sample = "-1"
            FormSampleReceiptSingle.id_comp_contact_to = "-1"
            FormSampleReceiptSingle.id_comp_contact_from = "-1"
            FormSampleReceiptSingle.id_pl_sample_purc = "-1"
            FormSampleReceiptSingle.ShowDialog()
        ElseIf formName = "FormSampleRet" Then
            'RETURN SAMPLE
            If FormSampleRet.XTCReturn.SelectedTabPageIndex = 0 Then 'returnOut
                FormSampleRetOutSingle.action = "ins"
                FormSampleRetOutSingle.ShowDialog()
            ElseIf FormSampleRet.XTCReturn.SelectedTabPageIndex = 1 Then 'Return In
                FormSampleRetInSingle.action = "ins"
                FormSampleRetInSingle.ShowDialog()
            End If
        ElseIf formName = "FormSamplePLDel" Then
            'PACKING LIST DELIVERY SAMPLE
            If FormSamplePLDel.XTCPL.SelectedTabPageIndex = 0 Then 'based on PL
                FormSamplePLDelSingle.id_comp_from = get_company_from(id_user)
                FormSamplePLDelSingle.action = "ins"
                FormSamplePLDelSingle.id_comp_contact_to = "-1"
                FormSamplePLDelSingle.id_comp_contact_from = "-1"
                FormSamplePLDelSingle.ShowDialog()
            ElseIf FormSamplePLDel.XTCPL.SelectedTabPageIndex = 1 Then 'based on SRS
                FormSamplePLDelSingle.id_comp_from = get_company_from(id_user)
                FormSamplePLDelSingle.id_comp_to = FormSamplePLDel.GVReq.GetFocusedRowCellValue("id_comp_to").ToString
                FormSamplePLDelSingle.SPDuration.Text = FormSamplePLDel.GVReq.GetFocusedRowCellValue("sample_requisition_duration").ToString
                FormSamplePLDelSingle.BtnPopSRS.Enabled = False
                FormSamplePLDelSingle.id_sample_requisition = FormSamplePLDel.GVReq.GetFocusedRowCellDisplayText("id_sample_requisition").ToString
                FormSamplePLDelSingle.TEDivision.Text = FormSamplePLDel.GVReq.GetFocusedRowCellDisplayText("division").ToString
                FormSamplePLDelSingle.TxtSRSNumber.Text = FormSamplePLDel.GVReq.GetFocusedRowCellDisplayText("sample_requisition_number").ToString
                FormSamplePLDelSingle.action = "ins"
                FormSamplePLDelSingle.id_comp_contact_to = "-1"
                FormSamplePLDelSingle.id_comp_contact_from = "-1"
                FormSamplePLDelSingle.ShowDialog()
            End If
        ElseIf formName = "FormSampleReq" Then
            'SAMPLE REQUISITION 
            FormSampleReqSingle.action = "ins"
            FormSampleReqSingle.id_comp_contact_to = "-1"
            FormSampleReqSingle.id_comp_contact_from = "-1"
            FormSampleReqSingle.ShowDialog()
        ElseIf formName = "FormMarkAssign" Then
            'Assign for mark
            FormMarkAssignSingle.id_mark_asg = "-1"
            FormMarkAssignSingle.ShowDialog()
        ElseIf formName = "FormSamplePlan" Then
            'Sample Planning
            FormSamplePlanDet.id_sample_plan = "-1"
            FormSamplePlanDet.ShowDialog()
        ElseIf formName = "FormMatPurchase" Then
            'Material Purchase
            FormMatPurchaseDet.id_purc = "-1"
            FormMatPurchaseDet.ShowDialog()
        ElseIf formName = "FormSampleReturn" Then
            'SAMPLE RETURN
            If FormSampleReturn.XTCReturn.SelectedTabPageIndex = 0 Then
                FormSampleReturnSingle.id_comp_to = get_company_from(id_user)
                FormSampleReturnSingle.action = "ins"
                FormSampleReturnSingle.id_comp_contact_to = "-1"
                FormSampleReturnSingle.id_comp_contact_from = "-1"
                FormSampleReturnSingle.ShowDialog()
            ElseIf FormSampleReturn.XTCReturn.SelectedTabPageIndex = 1 Then
                FormSampleReturnSingle.id_comp_to = get_company_from(id_user)
                FormSampleReturnSingle.id_pl_sample_del = FormSampleReturn.GVPL.GetFocusedRowCellDisplayText("id_pl_sample_del").ToString
                FormSampleReturnSingle.id_comp_contact_from = FormSampleReturn.GVPL.GetFocusedRowCellDisplayText("id_comp_contact_to").ToString
                FormSampleReturnSingle.TxtCodeUserFrom.Text = FormSampleReturn.GVPL.GetFocusedRowCellValue("employee_code").ToString
                FormSampleReturnSingle.TxtNameUserFrom.Text = FormSampleReturn.GVPL.GetFocusedRowCellValue("employee_name").ToString
                FormSampleReturnSingle.TxtCodeDeptFrom.Text = FormSampleReturn.GVPL.GetFocusedRowCellValue("departement_code").ToString
                FormSampleReturnSingle.TxtNameDeptFrom.Text = FormSampleReturn.GVPL.GetFocusedRowCellValue("departement").ToString
                FormSampleReturnSingle.TxtCodeCompFrom.Text = FormSampleReturn.GVPL.GetFocusedRowCellValue("comp_code_to").ToString
                FormSampleReturnSingle.TxtNameCompFrom.Text = FormSampleReturn.GVPL.GetFocusedRowCellValue("comp_name_to").ToString
                FormSampleReturnSingle.TEDivision.Text = FormSampleReturn.GVPL.GetFocusedRowCellValue("division").ToString
                FormSampleReturnSingle.TxtPLSampleDelNumber.Text = FormSampleReturn.GVPL.GetFocusedRowCellValue("pl_sample_del_number").ToString
                FormSampleReturnSingle.BtnInfoPL.Enabled = True
                FormSampleReturnSingle.BtnPopPLDel.Enabled = False

                FormSampleReturnSingle.action = "ins"
                FormSampleReturnSingle.ShowDialog()
            End If
        ElseIf formName = "FormMatWO" Then
            'Material Purchase
            FormMatWODet.id_purc = "-1"
            FormMatWODet.ShowDialog()
        ElseIf formName = "FormMatRecPurc" Then
            'Material Purchase Receive
            If FormMatRecPurc.XTCTabReceive.SelectedTabPageIndex = 0 Then 'based on Rec
                FormMatRecPurcDet.id_order = "-1"
                FormMatRecPurcDet.ShowDialog()
            Else 'based on PO
                FormMatRecPurcDet.id_order = FormMatRecPurc.GVMatPurchase.GetFocusedRowCellValue("id_mat_purc").ToString
                FormMatRecPurcDet.ShowDialog()
            End If
        ElseIf formName = "FormMatRecWO" Then
            'Material WO Receive
            If FormMatRecWO.XTCTabReceive.SelectedTabPageIndex = 0 Then 'based on Rec
                FormMatRecWODet.id_order = "-1"
                FormMatRecWODet.ShowDialog()
            Else 'based on WO
                FormMatRecWODet.id_order = FormMatRecWO.GVMatWO.GetFocusedRowCellValue("id_mat_wo").ToString
                FormMatRecWODet.ShowDialog()
            End If
        ElseIf formName = "FormMatRet" Then
            'Material Return
            If FormMatRet.XTCReturnMat.SelectedTabPageIndex = 0 Then 'purchase
                If FormMatRet.XTCReturnPruchase.SelectedTabPageIndex = 0 Then 'ret out
                    FormMatRetOutDet.action = "ins"
                    FormMatRetOutDet.id_mat_purc_ret_out = "-1"
                    FormMatRetOutDet.ShowDialog()
                Else 'ret in
                    FormMatRetInDet.action = "ins"
                    FormMatRetInDet.id_mat_purc_ret_in = "-1"
                    FormMatRetInDet.ShowDialog()
                End If
            ElseIf FormMatRet.XTCReturnMat.SelectedTabPageIndex = 1 Then 'production
                If FormMatRet.XTCReturnProd.SelectedTabPageIndex = 0 Then 'ret in
                    FormMatRetInProd.action = "ins"
                    FormMatRetInProd.id_mat_prod_ret_in = "-1"
                    FormMatRetInProd.ShowDialog()
                End If
            ElseIf FormMatRet.XTCReturnMat.SelectedTabPageIndex = 2 Then 'other
                FormMatRetInProd.action = "ins"
                FormMatRetInProd.is_other = True
                FormMatRetInProd.id_mat_prod_ret_in = "-1"
                FormMatRetInProd.ShowDialog()
            End If
        ElseIf formName = "FormProduction" Then
            'Production
            If FormProduction.XTCTabProduction.SelectedTabPageIndex = 0 Then 'prod order
                FormProductionDet.id_prod_order = "-1"
                FormProductionDet.ShowDialog()
            Else 'prod demand design
                'check first
                Dim query_cek As String = "SELECT * FROM `tb_prod_demand_design_rev` pddr 
INNER JOIN `tb_prod_demand_rev` pdr ON pdr.id_prod_demand_rev=pddr.id_prod_demand_rev
WHERE pddr.id_prod_demand_design='" & FormProduction.GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString & "' AND pdr.id_report_status!='5'"
                Dim data_cek As DataTable = execute_query(query_cek, -1, True, "", "", "", "")
                If data_cek.Rows.Count > 0 Then
                    warningCustom("PD sedang diproses revisi.")
                Else
                    FormProductionDet.id_prod_demand_design = FormProduction.GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString
                    FormProductionDet.is_pd_base = "1"
                    FormProductionDet.ShowDialog()
                End If
            End If
        ElseIf formName = "FormMatPL" Then
            If FormMatPL.XTCPL.SelectedTabPageIndex = 0 Then 'Production
                If FormMatPL.XTCTabProduction.SelectedTabPageIndex = 0 Then 'list PL
                    FormMatPLSingle.action = "ins"
                    FormMatPLSingle.id_comp_from = get_opt_mat_field("id_wh_mat") 'material WH
                    FormMatPLSingle.id_comp_contact_to = "-1"
                    FormMatPLSingle.id_comp_contact_from = "-1"
                    FormMatPLSingle.ShowDialog()
                Else 'from MRS
                    FormMatPLSingle.action = "ins"
                    FormMatPLSingle.id_comp_from = get_opt_mat_field("id_wh_mat") 'material WH
                    FormMatPLSingle.id_comp_contact_to = FormMatPL.GVMRS.GetFocusedRowCellValue("id_comp_name_req_from").ToString
                    FormMatPLSingle.BtnPopSRS.Enabled = False
                    FormMatPLSingle.id_mrs = FormMatPL.GVMRS.GetFocusedRowCellDisplayText("id_prod_order_mrs").ToString
                    FormMatPLSingle.TxtSRSNumber.Text = FormMatPL.GVMRS.GetFocusedRowCellDisplayText("prod_order_mrs_number").ToString
                    FormMatPLSingle.id_comp_contact_from = "-1"
                    FormMatPLSingle.ShowDialog()
                End If
            ElseIf FormMatPL.XTCPL.SelectedTabPageIndex = 1 Then 'WO
                If FormMatPL.XTCPLWO.SelectedTabPageIndex = 0 Then 'list WO
                    FormMatPLSingle.action = "ins"
                    FormMatPLSingle.id_comp_from = get_opt_mat_field("id_wh_mat") 'material WH
                    FormMatPLSingle.id_comp_contact_to = "-1"
                    FormMatPLSingle.id_comp_contact_from = "-1"
                    FormMatPLSingle.is_other = "1"
                    FormMatPLSingle.ShowDialog()
                Else 'from WO
                    FormMatPLSingle.action = "ins"
                    FormMatPLSingle.id_comp_from = get_company_from(id_user)
                    FormMatPLSingle.id_comp_contact_to = FormMatPL.GVMRSWO.GetFocusedRowCellValue("id_comp_name_req_from").ToString
                    FormMatPLSingle.BtnPopSRS.Enabled = False
                    FormMatPLSingle.id_mrs = FormMatPL.GVMRSWO.GetFocusedRowCellDisplayText("id_prod_order_mrs").ToString
                    FormMatPLSingle.TxtSRSNumber.Text = FormMatPL.GVMRSWO.GetFocusedRowCellDisplayText("prod_order_mrs_number").ToString
                    FormMatPLSingle.id_comp_contact_from = "-1"
                    FormMatPLSingle.is_other = "1"
                    FormMatPLSingle.ShowDialog()
                End If
            ElseIf FormMatPL.XTCPL.SelectedTabPageIndex = 2 Then 'Other
                If FormMatPL.XTCPLOther.SelectedTabPageIndex = 0 Then 'list PL
                    FormMatPLSingle.action = "ins"
                    FormMatPLSingle.id_comp_from = get_company_from(id_user)
                    FormMatPLSingle.id_comp_contact_to = "-1"
                    FormMatPLSingle.id_comp_contact_from = "-1"
                    FormMatPLSingle.is_other = "1"
                    FormMatPLSingle.ShowDialog()
                Else 'from MRS
                    FormMatPLSingle.action = "ins"
                    FormMatPLSingle.id_comp_from = get_company_from(id_user)
                    FormMatPLSingle.id_comp_contact_to = FormMatPL.GVMRSOther.GetFocusedRowCellValue("id_comp_name_req_from").ToString
                    FormMatPLSingle.BtnPopSRS.Enabled = False
                    FormMatPLSingle.id_mrs = FormMatPL.GVMRSOther.GetFocusedRowCellDisplayText("id_prod_order_mrs").ToString
                    FormMatPLSingle.TxtSRSNumber.Text = FormMatPL.GVMRSOther.GetFocusedRowCellDisplayText("prod_order_mrs_number").ToString
                    FormMatPLSingle.id_comp_contact_from = "-1"
                    FormMatPLSingle.is_other = "1"
                    FormMatPLSingle.ShowDialog()
                End If
            End If
        ElseIf formName = "FormMatMRS" Then
            If FormMatMRS.XTCMRS.SelectedTabPageIndex = 0 Then 'mat wo
                FormMatMRSDet.id_mrs = "-1"
                FormMatMRSDet.mrs_type = "2"
                FormMatMRSDet.ShowDialog()
            ElseIf FormMatMRS.XTCMRS.SelectedTabPageIndex = 1 Then 'other
                FormMatMRSDet.id_mrs = "-1"
                FormMatMRSDet.mrs_type = "1"
                FormMatMRSDet.ShowDialog()
            End If
        ElseIf formName = "FormSampleAdjustment" Then
            If FormSampleAdjustment.XTCAdj.SelectedTabPageIndex = 0 Then 'In
                FormSampleAdjustmentInSingle.action = "ins"
                FormSampleAdjustmentInSingle.ShowDialog()
            ElseIf FormSampleAdjustment.XTCAdj.SelectedTabPageIndex = 1 Then 'Out
                FormSampleAdjustmentOutSingle.action = "ins"
                FormSampleAdjustmentOutSingle.ShowDialog()
            End If
        ElseIf formName = "FormMatAdj" Then
            If FormMatAdj.XTCAdj.SelectedTabPageIndex = 0 Then 'In
                FormMatAdjInSingle.action = "ins"
                FormMatAdjInSingle.ShowDialog()
            ElseIf FormMatAdj.XTCAdj.SelectedTabPageIndex = 1 Then 'Out
                FormMatAdjOutSingle.action = "ins"
                FormMatAdjOutSingle.ShowDialog()
            End If
        ElseIf formName = "FormMatPR" Then
            'Payment Request Material
            If FormMatPR.XTCTabPR.SelectedTabPageIndex = 0 Then
                FormMatPRDet.id_pr = "-1"
                FormMatPRDet.ShowDialog()
            ElseIf FormMatPR.XTCTabPR.SelectedTabPageIndex = 1 Then
                FormMatPRDet.id_pr = "-1"
                FormMatPRDet.id_purc = FormMatPR.GVMatPurchaseNeed.GetFocusedRowCellDisplayText("id_mat_purc").ToString
                FormMatPRDet.ShowDialog()
            ElseIf FormMatPR.XTCTabPR.SelectedTabPageIndex = 2 Then
                FormMatPRDet.id_pr = "-1"
                FormMatPRDet.id_rec = FormMatPR.GVMatReceive.GetFocusedRowCellDisplayText("id_mat_purc_rec").ToString
                FormMatPRDet.ShowDialog()
            End If
        ElseIf formName = "FormMatPRWO" Then
            'Payment Request WO Material
            If FormMatPRWO.XTCTabPR.SelectedTabPageIndex = 0 Then
                FormMatPRWODet.id_pr = "-1"
                FormMatPRWODet.ShowDialog()
            ElseIf FormMatPRWO.XTCTabPR.SelectedTabPageIndex = 1 Then
                FormMatPRWODet.id_pr = "-1"
                FormMatPRWODet.id_purc = FormMatPRWO.GVMatPurchaseNeed.GetFocusedRowCellDisplayText("id_mat_wo").ToString
                FormMatPRWODet.ShowDialog()
            ElseIf FormMatPRWO.XTCTabPR.SelectedTabPageIndex = 2 Then
                FormMatPRWODet.id_pr = "-1"
                FormMatPRWODet.id_rec = FormMatPRWO.GVMatReceive.GetFocusedRowCellDisplayText("id_mat_wo_rec").ToString
                FormMatPRWODet.ShowDialog()
            End If
        ElseIf formName = "FormProductionRec" Then
            'Material Purchase Receive
            If FormProductionRec.XTCTabReceive.SelectedTabPageIndex = 0 Then 'based on Rec
                FormProductionRecDet.id_order = "-1"
                FormProductionRecDet.ShowDialog()
            Else 'based on PO
                If FormProductionRec.GVProd.RowCount > 0 And FormProductionRec.GVProd.FocusedRowHandle >= 0 Then
                    'If FormProductionRec.GVProd.GetFocusedRowCellValue("is_need_cps2_verify").ToString = "1" And FormProductionRec.GVProd.GetFocusedRowCellValue("cps2_verify").ToString = "2" Then
                    '    warningCustom("Copy Prototype Sample 2 still not verified. Please contact Sample Departement.")
                    'Else
                    '    FormProductionRecDet.id_order = FormProductionRec.GVProd.GetFocusedRowCellValue("id_prod_order").ToString
                    '    FormProductionRecDet.ShowDialog()
                    'End If
                    FormProductionRecDet.id_order = FormProductionRec.GVProd.GetFocusedRowCellValue("id_prod_order").ToString
                    FormProductionRecDet.ShowDialog()
                End If
            End If
        ElseIf formName = "FormProductionRet" Then
            'FG Return
            If FormProductionRet.XTCReturn.SelectedTabPageIndex = 0 Then 'ret out
                FormProductionRetOutSingle.action = "ins"
                FormProductionRetOutSingle.id_prod_order_ret_out = "0"
                FormProductionRetOutSingle.ShowDialog()
            Else 'ret in
                FormProductionRetInSingle.action = "ins"
                FormProductionRetInSingle.id_prod_order_ret_in = "0"
                FormProductionRetInSingle.ShowDialog()
            End If
        ElseIf formName = "FormProductionPLToWH" Then
            If FormProductionPLToWH.XTCPL.SelectedTabPageIndex = 0 Then
                'FormProductionPLToWHDet.action = "ins"
                'FormProductionPLToWHDet.id_pl_prod_order = "0"
                'FormProductionPLToWHDet.ShowDialog()
            Else
                If FormProductionPLToWH.GVProd.RowCount > 0 And FormProductionPLToWH.GVProd.FocusedRowHandle >= 0 Then
                    Dim id_cop_status As String = FormProductionPLToWH.GVProd.GetFocusedRowCellValue("id_cop_status").ToString
                    Dim cost As Decimal = FormProductionPLToWH.GVProd.GetFocusedRowCellValue("design_cop")
                    If id_cop_status = "2" Then
                        FormProductionPLToWHDet.action = "ins"
                        FormProductionPLToWHDet.id_pl_prod_order = "0"
                        FormProductionPLToWHDet.id_prod_order = FormProductionPLToWH.GVProd.GetFocusedRowCellValue("id_prod_order").ToString
                        FormProductionPLToWHDet.is_use_qc_report = FormProductionPLToWH.GVProd.GetFocusedRowCellValue("is_use_qc_report").ToString
                        FormProductionPLToWHDet.ShowDialog()
                    Else
                        stopCustom("Packing list can't continue process, because there is no final cost for this style.")
                    End If
                End If
            End If
        ElseIf formName = "FormMatInvoice" Then
            If FormMatInvoice.XTCTabGeneral.SelectedTabPageIndex = 0 Then 'invoice
                If FormMatInvoice.XTCTabProduction.SelectedTabPageIndex = 0 Then 'ret out
                    FormMatInvoiceDet.id_invoice = "-1"
                    FormMatInvoiceDet.ShowDialog()
                Else 'PL
                    FormMatInvoiceDet.id_invoice = "-1"
                    FormMatInvoiceDet.id_prod_order_wo = FormMatInvoice.GVProdPL.GetFocusedRowCellValue("id_pl_mrs").ToString
                    FormMatInvoiceDet.ShowDialog()
                End If
            Else ' retur
                If FormMatInvoice.XTCRetur.SelectedTabPageIndex = 0 Then 'ret out
                    FormMatInvoiceReturDet.id_retur = "-1"
                    FormMatInvoiceReturDet.ShowDialog()
                Else 'PL
                    FormMatInvoiceReturDet.id_retur = "-1"
                    FormMatInvoiceReturDet.id_invoice = FormMatInvoice.GVInvoice.GetFocusedRowCellValue("id_inv_pl_mrs").ToString
                    FormMatInvoiceReturDet.ShowDialog()
                End If
            End If
        ElseIf formName = "FormAccounting" Then
            If FormAccounting.XTCGeneral.SelectedTabPageIndex = 0 Then
                FormAccountingAcc.id_acc = "-1"
                FormAccountingAcc.ShowDialog()
            Else
                FormAccountingAcc.id_acc = "-1"
                FormAccountingAcc.id_parent = FormAccounting.TreeList1.FocusedNode("id_acc_parent").ToString()
                FormAccountingAcc.ShowDialog()
            End If
        ElseIf formName = "FormAccountingJournal" Then
            FormAccountingJournalBill.id_trans = "-1"
            FormAccountingJournalBill.ShowDialog()
        ElseIf formName = "FormProductionPLToWHRec" Then
            If FormProductionPLToWHRec.XTCPL.SelectedTabPageIndex = 0 Then
                'FormProductionPLToWHRecDet.action = "ins"
                'FormProductionPLToWHRecDet.id_pl_prod_order_rec = "0"
                'FormProductionPLToWHRecDet.ShowDialog()
            Else
                FormProductionPLToWHRecDet.action = "ins"
                FormProductionPLToWHRecDet.id_pl_prod_order_rec = "0"
                FormProductionPLToWHRecDet.id_pl_prod_order = FormProductionPLToWHRec.GVProd.GetFocusedRowCellValue("id_pl_prod_order").ToString
                FormProductionPLToWHRecDet.id_pd_alloc = FormProductionPLToWHRec.GVProd.GetFocusedRowCellValue("id_pd_alloc").ToString
                FormProductionPLToWHRecDet.ShowDialog()
            End If
        ElseIf formName = "FormSalesTarget" Then
            'SALES TARGET
            If FormSalesTarget.XTCSalesTarget.SelectedTabPageIndex = 0 Then
                FormSalesTargetDet.action = "ins"
                FormSalesTargetDet.id_sales_target = "-1"
                FormSalesTargetDet.ShowDialog()
            End If
        ElseIf formName = "FormSalesOrder" Then
            'SALES OrDEER
            If FormSalesOrder.XTCSOGeneral.SelectedTabPageIndex = 0 Then
                If FormSalesOrder.check_created() Then
                    FormSalesOrderDet.action = "ins"
                    FormSalesOrderDet.id_sales_order = "-1"
                    FormSalesOrderDet.ShowDialog()
                Else
                    stopCustom("Please complete all transaction.")
                End If
            ElseIf FormSalesOrder.XTCSOGeneral.SelectedTabPageIndex = 1 Then
                FormSalesOrderGen.action = "ins"
                FormSalesOrderGen.id_sales_order_gen = "-1"
                FormSalesOrderGen.ShowDialog()
            End If
        ElseIf formName = "FormSalesDelOrder" Then
            'SALES DELIVERY ORDER
            If FormSalesDelOrder.XTCDO.SelectedTabPageIndex = 0 Then
                'FormSalesDelOrderDet.action = "ins"
                'FormSalesDelOrderDet.ShowDialog()
            ElseIf FormSalesDelOrder.XTCDO.SelectedTabPageIndex = 1 Then
                FormSalesDelOrderDet.id_sales_order = FormSalesDelOrder.GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
                FormSalesDelOrderDet.action = "ins"
                FormSalesDelOrderDet.ShowDialog()
            End If
        ElseIf formName = "FormSalesReturnOrder" Then
            'SALES RETURN ORDER
            FormSalesReturnOrderDet.action = "ins"
            FormSalesReturnOrderDet.id_sales_return_order = "-1"
            FormSalesReturnOrderDet.ShowDialog()
        ElseIf formName = "FormSalesReturnOrderOL" Then
            'SALES RETURN ORDER OL
            If FormSalesReturnOrderOL.XTCROR.SelectedTabPageIndex = 0 Then
                FormSalesReturnOrderOLDet.action = "ins"
                FormSalesReturnOrderOLDet.id_sales_return_order = "-1"
                FormSalesReturnOrderOLDet.ShowDialog()
            Else
                FormSalesReturnOrderOLDet.action = "ins"
                FormSalesReturnOrderOLDet.id_sales_return_order = "-1"
                FormSalesReturnOrderOLDet.comp_number = FormSalesReturnOrderOL.GVPending.GetFocusedRowCellValue("comp_number").ToString
                FormSalesReturnOrderOLDet.order_number = FormSalesReturnOrderOL.GVPending.GetFocusedRowCellValue("order_number").ToString
                FormSalesReturnOrderOLDet.is_proceed_from_return_centre = "1"
                FormSalesReturnOrderOLDet.ShowDialog()
            End If
        ElseIf formName = "FormSalesReturn" Then
            'SALES RETURN
            If FormSalesReturn.XTCSalesReturn.SelectedTabPageIndex = 0 Then
                'FormSalesReturnDet.action = "ins"
                'FormSalesReturnDet.ShowDialog()
            ElseIf FormSalesReturn.XTCSalesReturn.SelectedTabPageIndex = 1 Then
                FormSalesReturnDetNew.ShowDialog()
            End If
        ElseIf formName = "FormSalesPOS" Then
            If FormSalesPOS.XTCInvoice.SelectedTabPageIndex = 0 Then
                'SALES POS
                FormSalesPOSDet.action = "ins"
                FormSalesPOSDet.id_menu = FormSalesPOS.id_menu
                FormSalesPOSDet.ShowDialog()
            ElseIf FormSalesPOS.XTCInvoice.SelectedTabPageIndex = 2 Then
                FormSalesPOSDet.action = "ins"
                FormSalesPOSDet.id_menu = FormSalesPOS.id_menu
                FormSalesPOSDet.comp_number = FormSalesPOS.GVPendingCN.GetFocusedRowCellValue("comp_number").ToString
                FormSalesPOSDet.order_number = FormSalesPOS.GVPendingCN.GetFocusedRowCellValue("order_number").ToString
                FormSalesPOSDet.cust_name = FormSalesPOS.GVPendingCN.GetFocusedRowCellValue("customer_name").ToString
                FormSalesPOSDet.ShowDialog()
            End If
        ElseIf formName = "FormSalesReturnQC" Then
            'SALES RETURN QC
            If FormSalesReturnQC.XTCReturnQC.SelectedTabPageIndex = 0 Then
                'FormSalesReturnQCDet.action = "ins"
                'FormSalesReturnQCDet.ShowDialog()
            Else
                FormSalesReturnQCDet.action = "ins"
                FormSalesReturnQCDet.id_sales_return = FormSalesReturnQC.GVSalesReturn.GetFocusedRowCellValue("id_sales_return").ToString
                FormSalesReturnQCDet.ShowDialog()
            End If
        ElseIf formName = "FormSalesInvoice" Then
            'SALES INVOICE
            FormSalesInvoiceNew.ShowDialog()
        ElseIf formName = "FormAccountingJournalAdj" Then
            FormAccountingJournalAdjDet.id_trans = "-1"
            FormAccountingJournalAdjDet.ShowDialog()
        ElseIf formName = "FormProdPRWO" Then
            If FormProdPRWO.XTCTabPR.SelectedTabPageIndex = 0 Then
                FormProdPRWODet.id_pr = "-1"
                FormProdPRWODet.ShowDialog()
            ElseIf FormProdPRWO.XTCTabPR.SelectedTabPageIndex = 1 Then
                FormProdPRWODet.id_pr = "-1"
                FormProdPRWODet.id_prod_order_wo = FormProdPRWO.GVProdWO.GetFocusedRowCellValue("id_prod_order_wo").ToString
                FormProdPRWODet.ShowDialog()
            ElseIf FormProdPRWO.xtctabpr.SelectedTabPageIndex = 2 Then
                FormProdPRWODet.id_pr = "-1"
                FormProdPRWODet.is_po_pr = "1"
                FormProdPRWODet.ShowDialog()
            ElseIf FormProdPRWO.xtctabpr.SelectedTabPageIndex = 3 Then
                FormProdPRWODet.id_pr = "-1"
                FormProdPRWODet.is_no_reff = "1"
                FormProdPRWODet.ShowDialog()
            End If
        ElseIf formName = "FormFGStockOpnameStore" Then
            'STORE STOCK OPNAME
            FormFGStockOpnameStoreDet.action = "ins"
            FormFGStockOpnameStoreDet.ShowDialog()
        ElseIf formName = "FormFGMissing" Then
            'MISSING FG
            If FormFGMissing.XTCFGMissing.SelectedTabPageIndex = 0 Then
                FormFGMissingDet.action = "ins"
                FormFGMissingDet.id_pop_up = "1"
                FormFGMissingDet.ShowDialog()
            ElseIf FormFGMissing.XTCFGMissing.SelectedTabPageIndex = 1 Then
                FormFGMissingWHDet.action = "ins"
                FormFGMissingWHDet.id_pop_up = "1"
                FormFGMissingWHDet.ShowDialog()
            End If
        ElseIf formName = "FormFGMissingInvoice" Then
            'MISSING FG INVOICE
            FormFGMissingInvoiceNew.ShowDialog()
        ElseIf formName = "FormFGStockOpnameWH" Then
            'WH STOCK OPNAME
            FormFGStockOpnameWHDet.action = "ins"
            FormFGStockOpnameWHDet.ShowDialog()
        ElseIf formName = "FormMatStockOpname" Then
            FormMatStockOpnameDet.id_mat_so = "-1"
            FormMatStockOpnameDet.ShowDialog()
        ElseIf formName = "FormFGAdj" Then
            'FG ADJ
            If FormFGAdj.XTCAdj.SelectedTabPageIndex = 0 Then 'In
                FormFGAdjInDet.action = "ins"
                FormFGAdjInDet.ShowDialog()
            ElseIf FormFGAdj.XTCAdj.SelectedTabPageIndex = 1 Then 'Out
                FormFGAdjOutDet.action = "ins"
                FormFGAdjOutDet.ShowDialog()
            End If
        ElseIf formName = "FormFGTrf" Then
            'FG Transfer Future
            FormFGTrfDet.action = "ins"
            FormFGTrfDet.ShowDialog()
        ElseIf formName = "FormFGTrfNew" Then
            'FG Transfer
            If FormFGTrfNew.XTCTrf.SelectedTabPageIndex = 0 Then
                'FormFGTrfNewDet.action = "ins"
                'FormFGTrfNewDet.ShowDialog()
            ElseIf FormFGTrfNew.XTCTrf.SelectedTabPageIndex = 1 Then
                FormFGTrfNewDet.id_sales_order = FormFGTrfNew.GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
                FormFGTrfNewDet.action = "ins"
                FormFGTrfNewDet.ShowDialog()
            End If
        ElseIf formName = "FormMasterEmployee" Then
            'Master Employee
            FormMasterEmployeeNewDet.action = "ins"
            FormMasterEmployeeNewDet.is_salary = FormMasterEmployee.is_salary
            FormMasterEmployeeNewDet.ShowDialog()
            'FormMasterEmployeeDet.action = "ins"
            'FormMasterEmployeeDet.ShowDialog()
        ElseIf formName = "FormSampleDel" Then
            'Delivery Sample Never Returned
            FormSampleDelDet.action = "ins"
            FormSampleDelDet.ShowDialog()
        ElseIf formName = "FormSampleDelRec" Then
            'REC Delivery Sample
            If FormSampleDelRec.XTCSampleDelRec.SelectedTabPageIndex = 0 Then
                FormSampleDelRecDet.action = "ins"
                FormSampleDelRecDet.ShowDialog()
            ElseIf FormSampleDelRec.XTCSampleDelRec.SelectedTabPageIndex = 1 Then
                FormSampleDelRecDet.action = "ins"
                FormSampleDelRecDet.id_sample_del = FormSampleDelRec.GVSampleDel.GetFocusedRowCellValue("id_sample_del").ToString
                FormSampleDelRecDet.ShowDialog()
            End If
        ElseIf formName = "FormSampleOrder" Then
            ' SALES ORDER SAMPLE
            FormSampleOrderDet.action = "ins"
            FormSampleOrderDet.ShowDialog()
        ElseIf formName = "FormSampleDelOrder" Then
            'DELIVERY ORDER FOR SAMPLE SALES
            If FormSampleDelOrder.XTCSampleDelOrder.SelectedTabPageIndex = 0 Then
                FormSampleDelOrderDet.action = "ins"
                FormSampleDelOrderDet.ShowDialog()
            ElseIf FormSampleDelOrder.XTCSampleDelOrder.SelectedTabPageIndex = 1 Then
                FormSampleDelOrderDet.id_sample_order = FormSampleDelOrder.GVSampleOrder.GetFocusedRowCellValue("id_sample_order").ToString
                FormSampleDelOrderDet.action = "ins"
                FormSampleDelOrderDet.id_store_contact_to = FormSampleDelOrder.GVSampleOrder.GetFocusedRowCellValue("id_store_contact_to").ToString
                FormSampleDelOrderDet.id_store_to = FormSampleDelOrder.GVSampleOrder.GetFocusedRowCellValue("id_store_to").ToString
                FormSampleDelOrderDet.TxtCodeCompTo.Text = FormSampleDelOrder.GVSampleOrder.GetFocusedRowCellValue("store_number_to").ToString
                FormSampleDelOrderDet.TxtNameCompTo.Text = FormSampleDelOrder.GVSampleOrder.GetFocusedRowCellValue("store_name_to").ToString
                FormSampleDelOrderDet.MEAdrressCompTo.Text = FormSampleDelOrder.GVSampleOrder.GetFocusedRowCellValue("store_address_to").ToString
                FormSampleDelOrderDet.TxtSampleOrder.Text = FormSampleDelOrder.GVSampleOrder.GetFocusedRowCellValue("sample_order_number").ToString
                FormSampleDelOrderDet.id_so_status = FormSampleDelOrder.GVSampleOrder.GetFocusedRowCellValue("id_so_status").ToString
                FormSampleDelOrderDet.id_so_type = FormSampleDelOrder.GVSampleOrder.GetFocusedRowCellValue("id_so_type").ToString
                FormSampleDelOrderDet.viewSampleOrder()
                FormSampleDelOrderDet.GroupControlListItem.Enabled = True
                FormSampleDelOrderDet.BtnInfoSrs.Enabled = True
                FormSampleDelOrderDet.ShowDialog()
            End If
        ElseIf formName = "FormSampleStockOpname" Then
            FormSampleStockOpnameDet.action = "ins"
            FormSampleStockOpnameDet.ShowDialog()
        ElseIf formName = "FormFGCodeReplace" Then
            'CODE REPLACEMENT
            If FormFGCodeReplace.XTCFGCodeReplace.SelectedTabPageIndex = 0 Then
                FormFGCodeReplaceStoreDet.action = "ins"
                FormFGCodeReplaceStoreDet.ShowDialog()
            ElseIf FormFGCodeReplace.XTCFGCodeReplace.SelectedTabPageIndex = 1 Then
                FormFGCodeReplaceWHDet.action = "ins"
                FormFGCodeReplaceWHDet.ShowDialog()
            End If
        ElseIf formName = "FormSalesCreditNote" Then
            'CREDIT NOTE
            FormSalesCreditNoteDet.action = "ins"
            FormSalesCreditNoteDet.ShowDialog()
        ElseIf formName = "FormFGMissingCreditNote" Then
            'MISSING CREDIT NOTE
            If FormFGMissingCreditNote.XTCFGMissingCN.SelectedTabPageIndex = 0 Then
                FormFGMissingCreditNoteStoreDet.action = "ins"
                FormFGMissingCreditNoteStoreDet.ShowDialog()
            ElseIf FormFGMissingCreditNote.XTCFGMissingCN.SelectedTabPageIndex = 1 Then

            End If
        ElseIf formName = "FormSOHPeriode" Then
            'CREDIT NOTE
            FormSOHPeriodeDet.id_soh_periode = "-1"
            FormSOHPeriodeDet.ShowDialog()
        ElseIf formName = "FormSOH" Then
            'CREDIT NOTE
            FormSOHDet.id_soh = "-1"
            FormSOHDet.ShowDialog()
        ElseIf formName = "FormFGWoff" Then
            'FG Write Off
            FormFGWoffDet.action = "ins"
            FormFGWoffDet.ShowDialog()
        ElseIf formName = "FormFGProposePrice" Then
            'FG PROPOSE PRICE
            If FormFGProposePrice.XTCPropose.SelectedTabPageIndex = 0 Then
                FormFGProposePriceNew.ShowDialog()
            ElseIf FormFGProposePrice.XTCPropose.SelectedTabPageIndex = 1 Then
                FormFGProposePriceRevNew.ShowDialog()
            End If
        ElseIf formName = "FormMasterRetCode" Then
            'RETURN CODE
            FormMasterRetCodeDet.action = "ins"
            FormMasterRetCodeDet.ShowDialog()
        ElseIf formName = "FormSampleOrdered" Then
            ' SAMPLE ORDER
            FormSampleOrderedDet.action = "ins"
            FormSampleOrderedDet.ShowDialog()
        ElseIf formName = "FormMasterRateStore" Then
            'RATE STORE
            FormMasterRateStoreDet.action = "ins"
            FormMasterRateStoreDet.ShowDialog()
        ElseIf formName = "FormProdQCAdj" Then
            'QC ADj
            If FormProdQCAdj.XTCAdj.SelectedTabPageIndex = 0 Then 'adj in
                FormProdQCAdjIn.id_adj_in = "-1"
                FormProdQCAdjIn.ShowDialog()
            ElseIf FormProdQCAdj.XTCAdj.SelectedTabPageIndex = 1 Then 'adj out
                FormProdQCAdjOut.id_adj_out = "-1"
                FormProdQCAdjOut.ShowDialog()
            End If
        ElseIf formName = "FormSalesPromo" Then
            'Sales Promo
            FormSalesPromoDet.action = "ins"
            FormSalesPromoDet.ShowDialog()
        ElseIf formName = "FormFGSalesOrderReff" Then
            FormFGSalesOrderReffDet.action = "ins"
            FormFGSalesOrderReffDet.ShowDialog()
        ElseIf formName = "FormMasterComputer" Then
            FormMasterComnputerDet.action = "ins"
            FormMasterComnputerDet.ShowDialog()
        ElseIf formName = "FormAccountingFakturScan" Then
            FormAccountingFakturScanSingle.action = "ins"
            FormAccountingFakturScanSingle.ShowDialog()
        ElseIf formName = "FormFGBorrowQCReq" Then
            'BORROW REQ FIR QC PRODUCT
            FormFGBorrowQCReqSingle.action = "ins"
            FormFGBorrowQCReqSingle.ShowDialog()
        ElseIf formName = "FormWHAWBill" Then
            If FormWHAWBill.XTCAwb.SelectedTabPageIndex = 0 Then
                again_awb = "1"
                While again_awb = "1"
                    again_awb = "2"
                    FormWHAWBillDet.id_awb = "-1"
                    FormWHAWBillDet.id_awb_type = "1"
                    FormWHAWBillDet.ShowDialog()
                End While
            Else
                again_awb = "1"
                While again_awb = "1"
                    again_awb = "2"
                    FormWHAWBillIn.id_awb = "-1"
                    FormWHAWBillIn.id_awb_type = "2"
                    FormWHAWBillIn.ShowDialog()
                End While
            End If
        ElseIf formName = "FormMasterPrice" Then
            FormMasterPriceSingle.action = "ins"
            FormMasterPriceSingle.ShowDialog()
        ElseIf formName = "FormSamplePLToWH" Then
            'PACKING LIST SAMPLE
            FormSamplePLToWHDet.action = "ins"
            FormSamplePLToWHDet.ShowDialog()
        ElseIf formName = "FormMasterPriceSample" Then
            'MASTER PRICE SAMPLE
            FormMasterPriceSampleSingle.action = "ins"
            FormMasterPriceSampleSingle.ShowDialog()
        ElseIf formName = "FormFGWHAlloc" Then
            'INVENTORY ALLOCATION
            FormFGWHAllocDet.action = "ins"
            FormFGWHAllocDet.ShowDialog()
        ElseIf formName = "FormSampleReturnPL" Then
            'Return Internal sale
            FormSampleReturnPLDet.action = "ins"
            FormSampleReturnPLDet.ShowDialog()
        ElseIf formName = "FormFGDesignList" Then
            'DESIGN LIST
            If FormFGDesignList.XTPDesign.SelectedTabPageIndex = 0 Then
                FormMasterDesignSingle.id_pop_up = "5"
                FormMasterDesignSingle.id_season_par = FormFGDesignList.SLESeason.EditValue.ToString
                FormMasterDesignSingle.form_name = "FormFGDesignList"
                FormMasterDesignSingle.WindowState = FormWindowState.Maximized
                FormMasterDesignSingle.ShowDialog()
            Else
                FormFGDesignListChangesNew.ShowDialog()
            End If
        ElseIf formName = "FormEmpShift" Then
            'DESIGN LIST
            FormEmpShiftDet.id_shift = "-1"
            FormEmpShiftDet.ShowDialog()
        ElseIf formName = "FormEmpInitialize" Then
            FormEmpInitialize.addUser()
        ElseIf formName = "FormEmpHoliday" Then
            'DESIGN LIST
            FormEmpHolidayDet.id_holiday = "-1"
            FormEmpHolidayDet.ShowDialog()
        ElseIf formName = "FormFGRepair" Then
            'Repair
            FormFGRepairDet.action = "ins"
            FormFGRepairDet.ShowDialog()
        ElseIf formName = "FormFGRepairRec" Then
            'Repair receive
            If FormFGRepairRec.XTCRepairRec.SelectedTabPageIndex = 1 Then
                FormFGRepairRecDet.id_fg_repair_select = FormFGRepairRec.GVRepairList.GetFocusedRowCellValue("id_fg_repair").ToString
                FormFGRepairRecDet.action = "ins"
                FormFGRepairRecDet.ShowDialog()
            End If
        ElseIf formName = "FormFGRepairReturn" Then
            'Return Repair
            If FormFGRepairReturn.XTCData.SelectedTabPageIndex = 0 Then
                If FormFGRepairReturn.is_from_vendor = False Then
                    FormFGRepairReturnDet.action = "ins"
                    FormFGRepairReturnDet.ShowDialog()
                End If
            Else
                FormFGRepairReturnDet.id_fg_repair = FormFGRepairReturn.GVRepairList.GetFocusedRowCellValue("id_fg_repair").ToString
                FormFGRepairReturnDet.action = "ins"
                FormFGRepairReturnDet.ShowDialog()
            End If
        ElseIf formName = "FormFGRepairReturnRec" Then
            ''Repair return receive
            If FormFGRepairReturnRec.XTCRepairRec.SelectedTabPageIndex = 1 Then
                FormFGRepairReturnRecDet.id_fg_repair_return_select = FormFGRepairReturnRec.GVRepairList.GetFocusedRowCellValue("id_fg_repair_return").ToString
                FormFGRepairReturnRecDet.action = "ins"
                FormFGRepairReturnRecDet.ShowDialog()
            End If
        ElseIf formName = "FormEmpEmail" Then
            'Email List
            FormEmpEmailDet.type = "2"
            FormEmpEmailDet.ShowDialog()
        ElseIf formName = "FormEmpLeave" Then
            'Leave
            FormEmpLeaveDet.id_emp_leave = "-1"
            FormEmpLeaveDet.ShowDialog()
        ElseIf formName = "FormEmpDP" Then
            'Leave
            FormEmpDPDet.id_emp_dp = "-1"
            FormEmpDPDet.ShowDialog()
        ElseIf formName = "FormEmpChSchedule" Then
            'Leave
            FormEmpChScheduleDet.id_ch_sch = "-1"
            FormEmpChScheduleDet.ShowDialog()
        ElseIf formName = "FormEmpAttnAssign" Then
            'assign schedule with approval
            FormEmpAttnAssignDet.id_emp_assign_sch = "-1"
            FormEmpAttnAssignDet.ShowDialog()
        ElseIf formName = "FormProductionFinalClear" Then
            'qc report
            If FormProductionFinalClear.XTCQCReport.SelectedTabPageIndex = 0 Then
                'list entry
                'FormProductionFinalClearDet.action = "ins"
                'FormProductionFinalClearDet.ShowDialog()
            ElseIf FormProductionFinalClear.XTCQCReport.SelectedTabPageIndex = 1 Then
                'list order
                If FormProductionFinalClear.GVProd.RowCount > 0 And FormProductionFinalClear.GVProd.FocusedRowHandle >= 0 Then
                    FormProductionFinalClearDet.id_prod_order = FormProductionFinalClear.GVProd.GetFocusedRowCellValue("id_prod_order").ToString
                    FormProductionFinalClearDet.id_prod_order_rec = FormProductionFinalClear.GVRecQc.GetFocusedRowCellValue("id_prod_order_rec").ToString
                    FormProductionFinalClearDet.action = "ins"
                    FormProductionFinalClearDet.ShowDialog()
                End If
            ElseIf FormProductionFinalClear.XTCQCReport.SelectedTabPageIndex = 2 Then
                'propose summary
                FormProductionFinalClearSummary.id_prod_fc_sum = "0"
                FormProductionFinalClearSummary.is_vew = "0"
                FormProductionFinalClearSummary.ShowDialog()
            End If
        ElseIf formName = "FormProductionAssembly" Then
            FormProductionAssemblyNew.ShowDialog()
        ElseIf formName = "FormMasterCargoRate" Then
            FormMasterCargoRateAdd.ShowDialog()
        ElseIf formName = "FormWHDelEmpty" Then
            FormPopUpContact.id_cat = "6"
            FormPopUpContact.id_pop_up = "77"
            FormPopUpContact.ShowDialog()
        ElseIf formName = "FormDeliveryCargo" Then
            FormDeliveryCargoDet.id_awbill = "-1"
            FormDeliveryCargoDet.ShowDialog()
        ElseIf formName = "FormEmpUniPeriod" Then
            FormEmpUniPeriodDet.action = "ins"
            FormEmpUniPeriodDet.ShowDialog()
        ElseIf formName = "FormDepartementSub" Then
            FormDepartementSubDet.id_subdept = "-1"
            FormDepartementSubDet.ShowDialog()
        ElseIf formName = "FormProdDebitNote" Then
            FormProdDebitNoteDet.id_dn = "-1"
            FormProdDebitNoteDet.ShowDialog()
        ElseIf formName = "FormEmpPayroll" Then
            FormEmpPayrollPeriode.id_payroll = "-1"
            FormEmpPayrollPeriode.ShowDialog()
        ElseIf formName = "FormEmpLeaveCut" Then
            FormEmpLeaveCutDet.id_leave_cut = "-1"
            FormEmpLeaveCutDet.ShowDialog()
        ElseIf formName = "FormProdOverMemo" Then
            FormProdOverMemoDet.action = "ins"
            FormProdOverMemoDet.ShowDialog()
        ElseIf formName = "FormEmpUniList" Then
            FormEmpUniListNew.ShowDialog()
        ElseIf formName = "FormMasterAssetCategory" Then
            FormMasterAssetCategoryDetail.id_asset_cat = "-1"
            FormMasterAssetCategoryDetail.ShowDialog()
        ElseIf formName = "FormMasterAsset" Then
            If FormMasterAsset.XTCListAsset.SelectedTabPageIndex = 0 Then
                'FormMasterAssetDetail.id_asset = "-1"
                'FormMasterAssetDetail.ShowDialog()
                infoCustom("Please use purchase procedure")
            ElseIf FormMasterAsset.XTCListAsset.SelectedTabPageIndex = 1 Then
                If FormMasterAsset.GVAsset.RowCount > 0 Then
                    FormMasterAssetLog.id_asset = FormMasterAsset.GVAsset.GetFocusedRowCellValue("id_asset").ToString
                    FormMasterAssetLog.ShowDialog()
                End If
            End If
        ElseIf formName = "FormAssetPO" Then
            FormAssetPODet.id_po = "-1"
            FormAssetPODet.ShowDialog()
        ElseIf formName = "FormAssetRec" Then
            FormAssetRecDet.id_rec = "-1"
            FormAssetRecDet.ShowDialog()
        ElseIf formName = "FormEmpUniExpense" Then
            'new
            FormEmpUniExpenseDet.action = "ins"
            FormEmpUniExpenseDet.ShowDialog()
        ElseIf formName = "FormBudgetRevPropose" Then
            If FormBudgetRevPropose.XTCRev.SelectedTabPageIndex = 1 Then
                FormBudgetRevProposeNew.action = "ins"
                FormBudgetRevProposeNew.ShowDialog()
                FormBudgetRevPropose.openNewTrans()
            ElseIf FormBudgetRevPropose.XTCRev.SelectedTabPageIndex = 2 Then
                FormBudgetRevenueRevisionNew.ShowDialog()
            End If
        ElseIf formName = "FormItemCatPropose" Then
            Dim query As String = "INSERT INTO tb_item_cat_propose(number, created_date, note, id_report_status) 
            VALUES('" + header_number_sales("37") + "',NOW(), '',1);SELECT LAST_INSERT_ID(); "
            Dim id As String = execute_query(query, 0, True, "", "", "", "")
            FormItemCatPropose.viewPropose()
            FormItemCatPropose.GVData.FocusedRowHandle = find_row(FormItemCatPropose.GVData, "id_item_cat_propose", id)
            FormItemCatProposeDet.id = id
            FormItemCatProposeDet.ShowDialog()
        ElseIf formName = "FormItemCatMapping" Then
            'check first
            Dim qc As String = "SELECT * FROM tb_item_coa_propose WHERE id_report_status!=5 AND id_report_status!=6"
            Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
            If dtc.Rows.Count > 0 Then
                warningCustom("There is pending document, please complete it first.")
            Else
                Dim query As String = "INSERT INTO tb_item_coa_propose(number, created_date, note, id_report_status) 
                VALUES('" + header_number_sales("38") + "',NOW(), '',1);SELECT LAST_INSERT_ID(); "
                Dim id As String = execute_query(query, 0, True, "", "", "", "")
                FormItemCatMapping.viewPropose()
                FormItemCatMapping.GVPropose.FocusedRowHandle = find_row(FormItemCatMapping.GVPropose, "id_item_coa_propose", id)
                FormItemCatMappingDet.id = id
                FormItemCatMappingDet.ShowDialog()
            End If
        ElseIf formName = "FormPurcItem" Then
            FormPurcItemDet.id_item = "-1"
            FormPurcItemDet.ShowDialog()
        ElseIf formName = "FormBudgetExpensePropose" Then
            FormBudgetExpenseProposeDet.action = "ins"
            FormBudgetExpenseProposeDet.ShowDialog()
        ElseIf formName = "FormPurcReq" Then
            FormPurcReqDet.id_req = "-1"
            FormPurcReqDet.ShowDialog()
        ElseIf formName = "FormBudgetExpenseRevision" Then
            FormBudgetExpenseRevisionNew.ShowDialog()
        ElseIf formName = "FormPurcOrder" Then
            FormPurcOrderDet.id_po = "-1"
            FormPurcOrderDet.ShowDialog()
        ElseIf formName = "FormProdDemandRev" Then
            FormProdDemandRevNew.ShowDialog()
        ElseIf formName = "FormReportMarkCancelList" Then
            FormReportMarkCancel.id_report_mark_cancel = "-1"
            FormReportMarkCancel.ShowDialog()
        ElseIf formName = "FormPurcReceive" Then
            If FormPurcReceive.XTCRec.SelectedTabPageIndex = 0 Then
                If FormPurcReceive.GVPO.RowCount > 0 And FormPurcReceive.GVPO.FocusedRowHandle >= 0 Then
                    Dim id_purc_order As String = FormPurcReceive.GVPO.GetFocusedRowCellValue("id_purc_order").ToString
                    FormPurcReceiveDet.id_purc_order = id_purc_order
                    FormPurcReceiveDet.id_coa_tag = FormPurcReceive.GVPO.GetFocusedRowCellValue("id_coa_tag").ToString
                    FormPurcReceiveDet.id_comp = FormPurcReceive.GVPO.GetFocusedRowCellValue("id_comp").ToString
                    FormPurcReceiveDet.action = "ins"
                    FormPurcReceiveDet.TxtOrderNumber.Text = FormPurcReceive.GVPO.GetFocusedRowCellValue("purc_order_number").ToString
                    FormPurcReceiveDet.TxtVendor.Text = FormPurcReceive.GVPO.GetFocusedRowCellValue("comp_number").ToString + " - " + FormPurcReceive.GVPO.GetFocusedRowCellValue("comp_name").ToString
                    FormPurcReceiveDet.ShowDialog()
                End If
            ElseIf FormPurcReceive.XTCRec.SelectedTabPageIndex = 2 Then
                If FormPurcReceive.XTCFOC.SelectedTabPageIndex = 0 Then
                    If FormPurcReceive.GVFOC.RowCount > 0 And FormPurcReceive.GVFOC.FocusedRowHandle >= 0 Then
                        Dim id_purc_order As String = FormPurcReceive.GVFOC.GetFocusedRowCellValue("id_purc_order").ToString
                        FormPurcReceiveFOCDet.id_purc_order = id_purc_order
                        FormPurcReceiveFOCDet.id_comp = FormPurcReceive.GVFOC.GetFocusedRowCellValue("id_comp").ToString
                        FormPurcReceiveFOCDet.action = "ins"
                        FormPurcReceiveFOCDet.TxtOrderNumber.Text = FormPurcReceive.GVFOC.GetFocusedRowCellValue("purc_order_number").ToString
                        FormPurcReceiveFOCDet.TxtVendor.Text = FormPurcReceive.GVFOC.GetFocusedRowCellValue("comp_number").ToString + " - " + FormPurcReceive.GVFOC.GetFocusedRowCellValue("comp_name").ToString
                        FormPurcReceiveFOCDet.ShowDialog()
                    End If
                End If
            End If
        ElseIf formName = "FormPurcReturn" Then
            If FormPurcReturn.GVPO.RowCount > 0 And FormPurcReturn.GVPO.FocusedRowHandle >= 0 Then
                Dim id_purc_order As String = FormPurcReturn.GVPO.GetFocusedRowCellValue("id_purc_order").ToString
                FormPurchaseReturnDet.id_purc_order = id_purc_order
                FormPurchaseReturnDet.action = "ins"
                FormPurchaseReturnDet.TxtOrderNumber.Text = FormPurcReturn.GVPO.GetFocusedRowCellValue("purc_order_number").ToString
                FormPurchaseReturnDet.TxtVendor.Text = FormPurcReturn.GVPO.GetFocusedRowCellValue("comp_number").ToString + " - " + FormPurcReturn.GVPO.GetFocusedRowCellValue("comp_name").ToString
                FormPurchaseReturnDet.ShowDialog()
            End If
        ElseIf formName = "FormProductionClaimReturn" Then
            FormProductionClaimReturnDet.action = "ins"
            FormProductionClaimReturnDet.ShowDialog()
        ElseIf formName = "FormItemReq" Then
            FormItemReqDet.action = "ins"
            FormItemReqDet.is_for_store = FormItemReq.is_for_store
            FormItemReqDet.ShowDialog()
        ElseIf formName = "FormItemDel" Then
            If FormItemDel.GVRequest.RowCount > 0 And FormItemDel.GVRequest.FocusedRowHandle >= 0 Then
                Dim id_item_req As String = FormItemDel.GVRequest.GetFocusedRowCellValue("id_item_req").ToString
                Dim is_for_store As String = FormItemDel.GVRequest.GetFocusedRowCellValue("is_for_store").ToString
                FormItemDelDetail.is_for_store = is_for_store
                FormItemDelDetail.id_req = id_item_req
                FormItemDelDetail.action = "ins"
                FormItemDelDetail.TxtRequestNo.Text = FormItemDel.GVRequest.GetFocusedRowCellValue("number").ToString
                FormItemDelDetail.TxtRequestedBy.Text = FormItemDel.GVRequest.GetFocusedRowCellValue("created_by_name").ToString
                FormItemDelDetail.TxtDept.Text = FormItemDel.GVRequest.GetFocusedRowCellValue("departement").ToString
                FormItemDelDetail.ShowDialog()
            End If
        ElseIf formName = "FormItemExpense" Then
            FormItemExpenseDet.action = "ins"
            FormItemExpenseDet.ShowDialog()
        ElseIf formName = "FormCashAdvance" Then
            FormCashAdvanceDet.id_ca = "-1"
            FormCashAdvanceDet.ShowDialog()
        ElseIf formName = "FormSalesReturnRec" Then
            FormSalesReturnRecDet.ShowDialog()
        ElseIf formName = "FormDeptHeadSurvey" Then
            FormDeptHeadSurveyDet.ShowDialog()
        ElseIf formName = "FormOLStore" Then
            FormOLStoreDet.ShowDialog()
        ElseIf formName = "FormSampleExpense" Then
            FormSampleExpenseDet.ShowDialog()
        ElseIf formName = "FormEmpOvertime" Then
            FormEmpOvertimeDet.id = "0"
            FormEmpOvertimeDet.is_hrd = FormEmpOvertime.is_hrd
            FormEmpOvertimeDet.ShowDialog()
        ElseIf formName = "FormSamplePurcClose" Then
            FormSamplePurcCloseDet.ShowDialog()
        ElseIf formName = "FormFGLinePlan" Then
            'single add line plan
            FormFGLinePlanDet.action = "ins"
            FormFGLinePlanDet.ShowDialog()
        ElseIf formName = "FormWorkOrder" Then
            FormWorkOrderDet.ShowDialog()
        ElseIf formName = "FormSalesTargetPropose" Then
            If FormSalesTargetPropose.XTCPropose.SelectedTabPageIndex = 0 Then
                FormSalesTargetProposeNew.action = "ins"
                FormSalesTargetProposeNew.ShowDialog()
                FormSalesTargetPropose.openNewTrans()
            ElseIf FormSalesTargetPropose.XTCPropose.SelectedTabPageIndex = 1 Then

            End If
        ElseIf formName = "FormProposeEmpSalary" Then
            'propose employee salary
            FormProposeEmpSalaryDet.id_employee_sal_pps = "-1"
            FormProposeEmpSalaryDet.is_duplicate = "-1"
            FormProposeEmpSalaryDet.ShowDialog()
        ElseIf formName = "FormItemSubCat" Then
            'purchase category
            FormItemSubCatDet.id_sub_cat = "-1"
            FormItemSubCatDet.ShowDialog()
        ElseIf formName = "FormItemCatMain" Then
            'Main Category
            Dim query As String = "INSERT INTO tb_item_cat_main_pps(created_date,created_by, note, id_report_status) 
            VALUES(NOW(),'" & id_user & "', '',1);SELECT LAST_INSERT_ID(); "
            Dim id As String = execute_query(query, 0, True, "", "", "", "")
            execute_non_query("CALL gen_number('" & id & "','207')", True, "", "", "", "")
            FormItemCatMain.view_propose()
            FormItemCatMain.GVData.FocusedRowHandle = find_row(FormItemCatMain.GVData, "id_item_cat_main_pps", id)
            FormItemCatMainDet.id_propose = id
            FormItemCatMainDet.ShowDialog()
        ElseIf formName = "FormVoucherPOS" Then
            'Voucher POS
            FormVoucherPOSDet.action = "ins"
            FormVoucherPOSDet.ShowDialog()
        ElseIf formName = "FormPromoRules" Then
            'Promo Rulese
            FormPromoRulesDet.action = "ins"
            FormPromoRulesDet.ShowDialog()
        ElseIf formName = "FormEmpInputAttendance" Then
            'input attendance
            FormEmpInputAttendanceDet.id = "0"
            FormEmpInputAttendanceDet.ShowDialog()
        ElseIf formName = "FormBankDeposit" Then
            FormBankDepositDet.type_rec = "2"
            FormBankDepositDet.ShowDialog()
        ElseIf formName = "FormBuktiPickup" Then
            FormBuktiPickupDet.id_pickup = "0"
            FormBuktiPickupDet.ShowDialog()
        ElseIf formName = "FormEmpBPJSKesehatan" Then
            FormEmpBPJSKesehatanDet.id = "0"
            FormEmpBPJSKesehatanDet.is_approve = FormEmpBPJSKesehatan.is_approve

            FormEmpBPJSKesehatanDet.ShowDialog()
        ElseIf formName = "FormPopUpCompGroup" Then
            FormMasterCompGroupDet.id_comp_group = "-1"
            FormMasterCompGroupDet.ShowDialog()
        ElseIf formName = "FormCompanyEmailMapping" Then
            'email mapping
            If FormCompanyEmailMapping.XtraTabControl.SelectedTabPageIndex = 0 Then
                FormCompanyEmailMappingDet.tab = "store_group"

                FormCompanyEmailMappingDet.id = "0"

                FormCompanyEmailMappingDet.ShowDialog()
            Else
                FormCompanyEmailMappingDet.tab = "internal"

                FormCompanyEmailMappingDet.id = "0"

                FormCompanyEmailMappingDet.ShowDialog()
            End If
        ElseIf formName = "FormAREvalScheduke" Then
            FormAREvalScheduleDet.action = "ins"
            FormAREvalScheduleDet.ShowDialog()
        ElseIf formName = "FormDelayPayment" Then
            FormDelayPaymentNew.ShowDialog()
        ElseIf formName = "FormDelManifest" Then
            FormDelManifestDet.id_del_manifest = "0"
            FormDelManifestDet.ShowDialog()
        ElseIf formName = "FormFollowUpAR" Then
            FormFollowUpARDetail.action = "ins"
            FormFollowUpARDetail.ShowDialog()
        ElseIf formName = "FormEmpUniCreditNote" Then
            FormEmpUniCreditNoteDet.id_emp_uni_ex = "0"
            FormEmpUniCreditNoteDet.ShowDialog()
        ElseIf formName = "FormPaymentMissing" Then
            FormPaymentMissingDet.id_missing_payment = "-1"
            FormPaymentMissingDet.ShowDialog()
        ElseIf formName = "FormBudgetProdDemand" Then
            FormBudgetProdDemand.XTCBudget.SelectedTabPageIndex = 1
            FormBudgetProdDemandNew.ShowDialog()
        ElseIf formName = "FormLetterOfStatement" Then
            FormLetterOfStatementDet.ShowDialog()
        ElseIf formName = "FormRetOlStore" Then
            If FormRetOlStore.XTCData.SelectedTabPageIndex = 1 Then
                'cek awb
                Dim qcek As String = "SELECT d.id_awbill, m.awbill_no 
                FROM tb_wh_awbill_det_in d 
                INNER JOIN tb_wh_awbill m ON m.id_awbill = d.id_awbill
                WHERE d.id_ol_store_ret_req='" + FormRetOlStore.GVOrderList.GetFocusedRowCellValue("id_ol_store_ret_req").ToString + "' AND m.awbill_no!='' "
                Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
                If dcek.Rows.Count > 0 Then
                    FormRetOLStoreDet.action = "ins"
                    FormRetOLStoreDet.ShowDialog()
                Else
                    stopCustom("Please input AWB number first.")
                End If
            End If
        ElseIf formName = "FormRefundOLStore" Then
            If FormRefundOLStore.XTCData.SelectedTabPageIndex = 1 Then
                FormRefundOLStoreDet.action = "ins"
                FormRefundOLStoreDet.ShowDialog()
            End If
        ElseIf formName = "FormPromoCollection" Then
            FormPromoCollectionNew.ShowDialog()
        ElseIf formName = "FormExternalUser" Then
            FormExternalUserDet.id_user = "-1"
            FormExternalUserDet.ShowDialog()
        ElseIf formName = "FormMasterStore" Then
            FormMasterStoreDet.id_store = "-1"
            FormMasterStoreDet.ShowDialog()
        ElseIf formName = "FormSalesBranch" Then
            If FormSalesBranch.rmt = "254" Then
                FormSalesBranchDet.action = "ins"
                FormSalesBranchDet.ShowDialog()
            End If
        ElseIf formName = "FormMasterDesignFabrication" Then
            FormMasterDesignFabricationDet.id_design_fabrication = "0"
            FormMasterDesignFabricationDet.ShowDialog()
        ElseIf formName = "FormMaterialRequisition" Then
            FormProductionMRS.id_pop_up = "1"

            FormProductionMRS.id_mrs = "-1"
            FormProductionMRS.ShowDialog()
        ElseIf formName = "FormAdditionalCost" Then
            FormAdditionalCostDet.id_pps = "1"
            FormAdditionalCostDet.ShowDialog()
        ElseIf formName = "FormDesignImages" Then
            FormDesignImages.browse_images()
        ElseIf formName = "FormEmployeeContract" Then
            FormEmployeeContractDet.ShowDialog()
        ElseIf formName = "FormSalesReturnOrderMail" Then
            FormSalesReturnOrderMailDet.ShowDialog()
        ElseIf formName = "FormInbound3PL" Then
            FormInboundAWB.ShowDialog()
        ElseIf formName = "FormReturnNote" Then
            FormReturnNoteDet.ShowDialog()
        ElseIf formName = "FormScanReturn" Then
            If FormScanReturn.XTCScanReturn.SelectedTabPageIndex = 0 Then
                FormScanReturnDet.ShowDialog()
            Else
                FormScanReturnBAP.ShowDialog()
            End If
        ElseIf formName = "FormAdjustmentOG" Then
            FormAdjustmentOGDet.ShowDialog()
        ElseIf formName = "FormOLReturnRefuse" Then
            If FormOLReturnRefuse.XTCData.SelectedTabPageIndex = 0 Then
                'no action
            ElseIf FormOLReturnRefuse.XTCData.SelectedTabPageIndex = 1 Then
                If FormOLReturnRefuse.GVOrder.RowCount > 0 And FormOLReturnRefuse.GVOrder.FocusedRowHandle >= 0 Then
                    Cursor = Cursors.WaitCursor
                    FormOLReturnRefuseDet.action = "ins"
                    FormOLReturnRefuseDet.id_sales_order = FormOLReturnRefuse.GVOrder.GetFocusedRowCellValue("id_sales_order").ToString
                    FormOLReturnRefuseDet.id_store_contact = FormOLReturnRefuse.GVOrder.GetFocusedRowCellValue("id_store_contact_to").ToString
                    FormOLReturnRefuseDet.ShowDialog()
                    Cursor = Cursors.Default
                End If
            End If
        ElseIf formName = "FormPricePolicyCode" Then
            FormPricePolicyCodeDet.action = "ins"
            FormPricePolicyCodeDet.ShowDialog()
        ElseIf formName = "FormProposePriceMKD" Then
            FormProposePriceMKDDet.id = "-1"
            FormProposePriceMKDDet.action = "ins"
            FormProposePriceMKDDet.ShowDialog()
            FormProposePriceMKD.loadNewDetail()
        ElseIf formName = "FormStockTakeStorePeriod" Then
            FormStockTakeStorePeriodDet.ShowDialog()
        ElseIf formName = "FormOGTransfer" Then
            FormOGTransferDet.id = "-1"
            FormOGTransferDet.ShowDialog()
        ElseIf formName = "FormAWBOther" Then
            FormAWBOtherDet.id = "-1"
            FormAWBOtherDet.ShowDialog()
        ElseIf formName = "FormSNIppsBudget" Then
            FormSNIppsDet.id_pps = "-1"
            FormSNIppsDet.ShowDialog()
        ElseIf formName = "FormSNISerahTerima" Then
            FormSNISerahTerimaDet.id = "-1"
            FormSNISerahTerimaDet.ShowDialog()
        ElseIf formName = "FormStockTakePartial" Then
            FormStockTakePartialDet.id = "-1"
            FormStockTakePartialDet.ShowDialog()
        ElseIf formName = "FormSNIRealisasi" Then
            FormSNIRealisasiDet.id = "-1"
            FormSNIRealisasiDet.ShowDialog()
        ElseIf formName = "FormSNIQC" Then
            If FormSNIQC.XTCInOut.SelectedTabPageIndex = 0 Then
                'out
                FormSNIOut.id = "-1"
                FormSNIOut.ShowDialog()
            Else
                'in
                FormSNIIn.id = "-1"
                FormSNIIn.ShowDialog()
            End If
        ElseIf formName = "FormPreCalFGPO" Then
            FormPreCalFGPODet.id = "-1"
            FormPreCalFGPODet.ShowDialog()
        ElseIf formName = "FormStockTakePropose" Then
            FormStockTakeProposeDet.id_st_store_propose = "-1"
            FormStockTakeProposeDet.ShowDialog()
        ElseIf formName = "FormPrepaidExpense" Then
            FormPrepaidExpenseDet.id = "-1"
            FormPrepaidExpenseDet.ShowDialog()
        ElseIf formName = "FormPromoZalora" Then
            FormPromoZalora.newPropose()
        ElseIf formName = "FormProposePromo" Then
            FormProposePromoDet.id_propose_promo = "0"
            FormProposePromoDet.ShowDialog()
        ElseIf formName = "FormRetExos" Then
            FormRetExos.createNew()
        ElseIf formName = "FormDisableExos" Then
            FormDisableExos.createNew()
        ElseIf formName = "FormEOSChange" Then
            FormEOSChange.createNew()
        ElseIf formName = "FormEts" Then
            FormEts.createNew()
        ElseIf formName = "FormBSP" Then
            FormBSP.createNew()
        ElseIf formName = "FormDeviden" Then
            FormDevidenDet.id = "-1"
            FormDevidenDet.ShowDialog()
        Else
            RPSubMenu.Visible = False
        End If
        Cursor = Cursors.Default
    End Sub
    'Edit Data
    Private Sub BBEdit_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBEdit.ItemClick
        but_edit()
    End Sub
    Sub but_edit()
        If BBEdit.Enabled = True And BBEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
            Cursor = Cursors.WaitCursor
            If formName = "FormMasterArea" Then
                If FormMasterArea.XTCArea.SelectedTabPageIndex = 0 Then
                    'country
                    FormMasterCountrySingle.id_country = FormMasterArea.GVCountry.GetFocusedRowCellDisplayText("id_country").ToString
                    FormMasterCountrySingle.ShowDialog()
                ElseIf FormMasterArea.XTCArea.SelectedTabPageIndex = 1 Then
                    'state
                    FormMasterRegionSingle.id_country = FormMasterArea.GVCountry.GetFocusedRowCellDisplayText("id_country").ToString
                    FormMasterRegionSingle.id_region = FormMasterArea.GVRegion.GetFocusedRowCellDisplayText("id_region").ToString
                    FormMasterRegionSingle.ShowDialog()
                ElseIf FormMasterArea.XTCArea.SelectedTabPageIndex = 2 Then
                    'state
                    FormMasterStateSingle.id_region = FormMasterArea.GVRegion.GetFocusedRowCellDisplayText("id_region").ToString
                    FormMasterStateSingle.id_state = FormMasterArea.GVState.GetFocusedRowCellDisplayText("id_state").ToString
                    FormMasterStateSingle.ShowDialog()
                ElseIf FormMasterArea.XTCArea.SelectedTabPageIndex = 3 Then
                    'city
                    FormMasterCitySingle.id_state = FormMasterArea.GVState.GetFocusedRowCellDisplayText("id_state").ToString
                    FormMasterCitySingle.id_city = FormMasterArea.GVCity.GetFocusedRowCellDisplayText("id_city").ToString
                    FormMasterCitySingle.ShowDialog()
                Else
                    'kecamatan
                    FormKecamatanSingle.id_sub_district = FormMasterArea.GVKecamatan.GetFocusedRowCellDisplayText("id_sub_district").ToString
                    FormKecamatanSingle.id_city = FormMasterArea.GVCity.GetFocusedRowCellDisplayText("id_city").ToString
                    FormKecamatanSingle.ShowDialog()
                End If
            ElseIf formName = "FormMasterCompany" Then
                '
                FormMasterCompanySingle.id_company = FormMasterCompany.GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
                FormMasterCompanySingle.is_view = If(FormMasterCompany.is_view, "1", "-1")
                FormMasterCompanySingle.ShowDialog()
            ElseIf formName = "FormMasterCompanyCategory" Then
                '
                FormMasterCompanyCategorySingle.id_company_category = FormMasterCompanyCategory.GVCompanyCategory.GetFocusedRowCellDisplayText("id_comp_cat").ToString
                FormMasterCompanyCategorySingle.ShowDialog()
            ElseIf formName = "FormMasterDepartement" Then
                '
                FormMasterDepartementSingle.id_departement = FormMasterDepartement.GVDepartment.GetFocusedRowCellDisplayText("id_departement").ToString
                FormMasterDepartementSingle.ShowDialog()
            ElseIf formName = "FormMasterRawMaterialCat" Then
                '
                FormMasterRawMaterialCatSingle.id_mat_cat = FormMasterRawMaterialCat.GridViewMasterItemCategory.GetFocusedRowCellDisplayText("id_mat_cat").ToString
                FormMasterRawMaterialCatSingle.action = "upd"
                FormMasterRawMaterialCatSingle.ShowDialog()
            ElseIf formName = "FormMasterItemColor" Then
                '
                FormMasterItemColorSingle.action = "upd"
                FormMasterItemColorSingle.id_item_color = FormMasterItemColor.GVItemColor.GetFocusedRowCellDisplayText("id_item_color").ToString
                FormMasterItemColorSingle.ShowDialog()
            ElseIf formName = "FormMasterItemSize" Then
                '
                FormMasterItemSizeSingle.action = "upd"
                FormMasterItemSizeSingle.id_item_size = FormMasterItemSize.GVItemSize.GetFocusedRowCellDisplayText("id_item_size").ToString
                FormMasterItemSizeSingle.ShowDialog()
            ElseIf formName = "FormMasterUser" Then
                FormMasterUserSingle.id_user = FormMasterUser.GVUser.GetFocusedRowCellDisplayText("id_user").ToString
                FormMasterUserSingle.ShowDialog()
            ElseIf formName = "FormAccess" Then
                If FormAccess.XTCMenuManage.SelectedTabPageIndex = 2 Then 'Edit role
                    FormAccessRoleSingle.id_role = FormAccess.GVRole.GetFocusedRowCellDisplayText("id_role").ToString
                    FormAccessRoleSingle.action = "upd"
                    FormAccessRoleSingle.LabelRole.Text = "Edit Role"
                    FormAccessRoleSingle.TxtRoleName.Text = FormAccess.GVRole.GetFocusedRowCellDisplayText("role").ToString
                    FormAccessRoleSingle.ShowDialog()
                ElseIf FormAccess.XTCMenuManage.SelectedTabPageIndex = 1 Then 'Edit menu
                    FormAccessMenuSingle.id_menu = FormAccess.GVMenu.GetFocusedRowCellDisplayText("id_menu").ToString
                    FormAccessMenuSingle.TxtMenuName.Text = FormAccess.GVMenu.GetFocusedRowCellDisplayText("menu_name").ToString
                    FormAccessMenuSingle.MEDescription.Text = FormAccess.GVMenu.GetFocusedRowCellDisplayText("description_menu_name").ToString
                    FormAccessMenuSingle.action = "upd"
                    FormAccessMenuSingle.ShowDialog()
                ElseIf FormAccess.XTCMenuManage.SelectedTabPageIndex = 0 Then 'Edit form
                    If FormAccess.XTCForm.SelectedTabPageIndex = 0 Then 'Edit Form
                        FormAccessProcessSingle.LabelTitle.Text = FormAccess.GVForm.GetFocusedRowCellDisplayText("form_name").ToString
                        FormAccessFrmSingle.id_form = FormAccess.GVForm.GetFocusedRowCellDisplayText("id_form").ToString
                        FormAccessFrmSingle.TxtFormName.Text = FormAccess.GVForm.GetFocusedRowCellDisplayText("form_name").ToString
                        FormAccessFrmSingle.action = "upd"
                        FormAccessFrmSingle.ShowDialog()
                    ElseIf FormAccess.XTCForm.SelectedTabPageIndex = 1 Then 'Edit Form Control
                        Dim is_view As String = FormAccess.GVProcess.GetFocusedRowCellDisplayText("is_view").ToString
                        If is_view = "1" Then
                            FormAccessProcessSingle.is_required = True
                            FormAccessProcessSingle.id_form = FormAccess.GVForm.GetFocusedRowCellDisplayText("id_form").ToString()
                        Else
                            FormAccessProcessSingle.is_required = False
                            FormAccessProcessSingle.id_form = FormAccess.GVForm.GetFocusedRowCellDisplayText("id_form").ToString()
                        End If
                        FormAccessProcessSingle.LabelTitle.Text = FormAccess.GVForm.GetFocusedRowCellDisplayText("form_name").ToString
                        FormAccessProcessSingle.id_form_control = FormAccess.GVProcess.GetFocusedRowCellDisplayText("id_form_control").ToString
                        FormAccessProcessSingle.TxtDescription.Text = FormAccess.GVProcess.GetFocusedRowCellDisplayText("description_form_control").ToString
                        FormAccessProcessSingle.action = "upd"
                        FormAccessProcessSingle.ShowDialog()
                    End If
                End If
            ElseIf formName = "FormSeason" Then
                If FormSeason.XTCMainSeason.SelectedTabPageIndex = 0 Then 'edit internal season
                    If FormSeason.XTCSeason.SelectedTabPageIndex = 0 Then
                        'edit range
                        FormRangeSingle.action = "upd"
                        FormRangeSingle.id_season_par = TryCast(XTMDI.SelectedPage.MdiChild, FormSeason).GVRange.GetFocusedRowCellDisplayText("id_season").ToString
                        FormRangeSingle.id_range = TryCast(XTMDI.SelectedPage.MdiChild, FormSeason).GVRange.GetFocusedRowCellDisplayText("id_range").ToString
                        FormRangeSingle.TxtRange.Text = TryCast(XTMDI.SelectedPage.MdiChild, FormSeason).GVRange.GetFocusedRowCellDisplayText("range").ToString
                        FormRangeSingle.ShowDialog()
                    ElseIf FormSeason.XTCSeason.SelectedTabPageIndex = 1 Then
                        'edit season
                        FormSeasonSingle.action = "upd"
                        FormSeasonSingle.id_season = FormSeason.GVSeason.GetFocusedRowCellDisplayText("id_season").ToString
                        FormSeasonSingle.ShowDialog()
                    ElseIf FormSeason.XTCSeason.SelectedTabPageIndex = 2 Then
                        'edit delivery
                        FormDeliverySingle.action = "upd"
                        FormDeliverySingle.id_delivery = FormSeason.GVDelivery.GetFocusedRowCellDisplayText("id_delivery").ToString
                        FormDeliverySingle.GCtrlDelivery.Text = "Range " + FormSeason.range_season.ToString + " - Season " + FormSeason.season.ToString
                        FormDeliverySingle.ShowDialog()
                    End If
                Else 'edit origin season
                    FormSeasonorignSingle.action = "upd"
                    FormSeasonorignSingle.id_season_orign = FormSeason.GVOrignSeason.GetFocusedRowCellDisplayText("id_season_orign").ToString
                    FormSeasonorignSingle.TxtSeason.Text = FormSeason.GVOrignSeason.GetFocusedRowCellDisplayText("season_orign").ToString
                    FormSeasonorignSingle.TxtSeasonPrintedName.Text = FormSeason.GVOrignSeason.GetFocusedRowCellDisplayText("season_orign_display").ToString
                    'LECountry.ItemIndex = FormSeasonorignSingle.LECountry.Properties.GetDataSourceRowIndex("id_country", FormSeason.GVOrignSeason.GetFocusedRowCellDisplayText("id_country").ToString)
                    FormSeasonorignSingle.id_country = FormSeason.GVOrignSeason.GetFocusedRowCellDisplayText("id_country").ToString
                    FormSeasonorignSingle.season_orign_year = FormSeason.GVOrignSeason.GetFocusedRowCellDisplayText("season_orign_year").ToString
                    FormSeasonorignSingle.ShowDialog()
                End If
            ElseIf formName = "FormMasterUOM" Then
                '
                FormMasterUOM.PCUOM.Visible = True
                FormMasterUOM.ErrorProviderUom.SetError(FormMasterUOM.TxtUOM, "")
                FormMasterUOM.action = "upd"
                FormMasterUOM.getDataUpd()
            ElseIf formName = "FormMasterRawMat" Then
                If FormMasterRawMat.XTCRawMat.SelectedTabPageIndex = 0 Then 'edit raw mat
                    FormMasterRawMatSingle.action = "upd"
                    FormMasterRawMatSingle.id_raw_mat = FormMasterRawMat.GVRawMat.GetFocusedRowCellDisplayText("id_raw_mat").ToString
                    FormMasterRawMatSingle.ShowDialog()
                ElseIf FormMasterRawMat.XTCRawMat.SelectedTabPageIndex = 1 Then 'edit detail raw mat
                    FormMasterRawMatLotSingle.action = "upd"
                    FormMasterRawMatLotSingle.loadku = 0
                    FormMasterRawMatLotSingle.id_raw_mat_detail = FormMasterRawMat.GVLot.GetFocusedRowCellDisplayText("id_raw_mat_detail").ToString
                    FormMasterRawMatLotSingle.ShowDialog()
                ElseIf FormMasterRawMat.XTCRawMat.SelectedTabPageIndex = 2 Then 'edit raw mat supplier
                    FormMasterRawMatSupplierSingle.action = "upd"
                    FormMasterRawMatSupplierSingle.id_raw_mat_detail = FormMasterRawMat.GVLot.GetFocusedRowCellDisplayText("id_raw_mat_detail").ToString
                    FormMasterRawMatSupplierSingle.id_raw_mat_supplier = FormMasterRawMat.GVSupplier.GetFocusedRowCellDisplayText("id_raw_mat_supplier").ToString
                    FormMasterRawMatSupplierSingle.ShowDialog()
                End If
            ElseIf formName = "FormSetupRawMatCode" Then
                Cursor = Cursors.WaitCursor
                FormSetupRawMatCodeSingle.action = "upd"
                FormSetupRawMatCodeSingle.id_raw_mat_code = FormSetupRawMatCode.GVCodeType.GetFocusedRowCellDisplayText("id_raw_mat_code").ToString
                FormSetupRawMatCodeSingle.ShowDialog()
                Cursor = Cursors.Default
            ElseIf formName = "FormMasterRawMaterial" Then 'EDIT MASTER RAW MATERIAL
                If FormMasterRawMaterial.XTCList.SelectedTabPageIndex = 0 Then
                    If FormMasterRawMaterial.XTCMaterialType.SelectedTabPageIndex = 0 Then 'edit raw material
                        FormMasterRawMaterialSingle.action = "upd"
                        FormMasterRawMaterialSingle.id_mat = FormMasterRawMaterial.GVRawMat.GetFocusedRowCellDisplayText("id_mat").ToString
                        FormMasterRawMaterialSingle.ShowDialog()
                    ElseIf FormMasterRawMaterial.XTCMaterialType.SelectedTabPageIndex = 1 Then 'edit raw material detail
                        FormMasterRawMaterialDetSingle.action = "upd"

                        FormMasterRawMaterialDetSingle.id_mat = FormMasterRawMaterial.GVRawMat.GetFocusedRowCellValue("id_mat").ToString
                        FormMasterRawMaterialDetSingle.LabelPrintedName.Text = FormMasterRawMaterial.GVRawMat.GetFocusedRowCellDisplayText("mat_display_name").ToString
                        FormMasterRawMaterialDetSingle.TxtMaterialTypeCode.Text = FormMasterRawMaterial.GVRawMat.GetFocusedRowCellDisplayText("mat_code").ToString

                        FormMasterRawMaterialDetSingle.id_mat_det = FormMasterRawMaterial.GVMatDetail.GetFocusedRowCellDisplayText("id_mat_det").ToString
                        FormMasterRawMaterialDetSingle.ShowDialog()
                    End If
                ElseIf FormMasterRawMaterial.XTCList.SelectedTabPageIndex = 1 Then
                    FormMasterRawMaterialDetSingle.action = "upd"

                    FormMasterRawMaterialDetSingle.id_mat = FormMasterRawMaterial.GVListMat.GetFocusedRowCellValue("id_mat").ToString
                    FormMasterRawMaterialDetSingle.LabelPrintedName.Text = FormMasterRawMaterial.GVListMat.GetFocusedRowCellDisplayText("mat_display_name").ToString
                    FormMasterRawMaterialDetSingle.TxtMaterialTypeCode.Text = FormMasterRawMaterial.GVListMat.GetFocusedRowCellDisplayText("mat_code").ToString

                    FormMasterRawMaterialDetSingle.id_mat_det = FormMasterRawMaterial.GVListMat.GetFocusedRowCellDisplayText("id_mat_det").ToString
                    FormMasterRawMaterialDetSingle.ShowDialog()
                End If
            ElseIf formName = "FormMasterOVH" Then
                FormMasterOVHSingle.id_ovh = FormMasterOVH.GVOVH.GetFocusedRowCellDisplayText("id_ovh").ToString
                FormMasterOVHSingle.ShowDialog()
            ElseIf formName = "FormProdDemand" Then
                FormProdDemandSingle.id_prod_demand = FormProdDemand.GVProdDemand.GetFocusedRowCellValue("id_prod_demand").ToString
                FormProdDemandSingle.id_prod_demand_ref = FormProdDemand.GVProdDemand.GetFocusedRowCellValue("id_prod_demand_ref").ToString
                FormProdDemandSingle.id_season = FormProdDemand.GVProdDemand.GetFocusedRowCellValue("id_season").ToString
                FormProdDemandSingle.TxtProdDemandNumber.Text = FormProdDemand.GVProdDemand.GetFocusedRowCellValue("prod_demand_number").ToString
                FormProdDemandSingle.ButtonEdit1.Text = FormProdDemand.GVProdDemand.GetFocusedRowCellValue("prod_demand_number_ref").ToString
                FormProdDemandSingle.MENote.Text = FormProdDemand.GVProdDemand.GetFocusedRowCellValue("prod_demand_note").ToString
                FormProdDemandSingle.id_report_status = FormProdDemand.GVProdDemand.GetFocusedRowCellValue("id_report_status").ToString
                FormProdDemandSingle.id_pd_kind = FormProdDemand.GVProdDemand.GetFocusedRowCellValue("id_pd_kind").ToString
                FormProdDemandSingle.id_pd_type = FormProdDemand.GVProdDemand.GetFocusedRowCellValue("id_pd_type").ToString
                FormProdDemandSingle.id_pd_budget = FormProdDemand.GVProdDemand.GetFocusedRowCellValue("id_pd_budget").ToString
                FormProdDemandSingle.id_division = FormProdDemand.GVProdDemand.GetFocusedRowCellValue("id_division").ToString
                FormProdDemandSingle.DEForm.EditValue = FormProdDemand.GVProdDemand.GetFocusedRowCellValue("prod_demand_date")
                FormProdDemandSingle.action = "upd"
                FormProdDemandSingle.id_pd = FormProdDemand.GVProdDemand.GetFocusedRowCellValue("is_pd").ToString
                FormProdDemandSingle.is_confirm = FormProdDemand.GVProdDemand.GetFocusedRowCellValue("is_confirm").ToString
                FormProdDemandSingle.rate_current = FormProdDemand.GVProdDemand.GetFocusedRowCellValue("rate_current")
                FormProdDemandSingle.ShowDialog()
            ElseIf formName = "FormMasterCode" Then
                '
                If FormMasterCode.XTCCode.SelectedTabPageIndex = 0 Then
                    'code
                    FormMasterCodeSingle.id_code = FormMasterCode.GVCode.GetFocusedRowCellDisplayText("id_code").ToString
                    FormMasterCodeSingle.ShowDialog()
                ElseIf FormMasterCode.XTCCode.SelectedTabPageIndex = 1 Then
                    'code detail
                    FormMasterCodeDetSingle.id_code_det = FormMasterCode.GVCodeDetail.GetFocusedRowCellDisplayText("id_code_detail").ToString
                    FormMasterCodeDetSingle.id_code = FormMasterCode.GVCode.GetFocusedRowCellDisplayText("id_code").ToString
                    FormMasterCodeDetSingle.ShowDialog()
                End If
            ElseIf formName = "FormTemplateCode" Then
                '
                If FormTemplateCode.XTCTemplateCode.SelectedTabPageIndex = 0 Then
                    'code
                    FormTemplateCodeSingle.id_template_code = FormTemplateCode.GVTemplateCode.GetFocusedRowCellDisplayText("id_template_code").ToString
                    FormTemplateCodeSingle.ShowDialog()
                End If
            ElseIf formName = "FormMasterSample" Then
                '
                FormMasterSampleDet.id_sample = FormMasterSample.GVSample.GetFocusedRowCellDisplayText("id_sample").ToString
                FormMasterSampleDet.ShowDialog()
            ElseIf formName = "FormMasterProduct" Then
                '
                If FormMasterProduct.XTCProduct.SelectedTabPageIndex = 0 Then
                    'design
                    FormMasterDesignSingle.id_design = FormMasterProduct.GVDesign.GetFocusedRowCellDisplayText("id_design").ToString
                    FormMasterDesignSingle.WindowState = FormWindowState.Maximized
                    FormMasterDesignSingle.form_name = "FormMasterProduct"
                    FormMasterDesignSingle.ShowDialog()
                ElseIf FormMasterProduct.XTCProduct.SelectedTabPageIndex = 1 Then
                    'product
                    FormMasterProductDet.id_product = FormMasterProduct.GVProduct.GetFocusedRowCellDisplayText("id_product").ToString
                    FormMasterProductDet.id_design = FormMasterProduct.GVDesign.GetFocusedRowCellDisplayText("id_design").ToString
                    FormMasterProductDet.ShowDialog()
                End If
            ElseIf formName = "FormBOM" Then
                '
                If FormBOM.XTCBOMSelection.SelectedTabPageIndex = 1 Then
                    If FormBOM.GVBOM.RowCount > 0 Then
                        FormBOMSingle.id_bom = FormBOM.GVBOM.GetFocusedRowCellDisplayText("id_bom").ToString
                        FormBOMSingle.id_product = FormBOM.GVProduct.GetFocusedRowCellDisplayText("id_product").ToString
                        FormBOMSingle.ShowDialog()
                    Else
                        stopCustom("No BOM selected")
                    End If
                ElseIf FormBOM.XTCBOMSelection.SelectedTabPageIndex = 2 Then 'per design
                    If FormBOM.GVBOMPerDesign.RowCount > 0 Then
                        FormBOMSingle.id_pop_up = "1"
                        FormBOMSingle.id_bom_approve = FormBOM.GVBOMPerDesign.GetFocusedRowCellValue("id_bom_approve").ToString
                        FormBOMSingle.id_design = FormBOM.GVPerDesign.GetFocusedRowCellDisplayText("id_design").ToString
                        FormBOMSingle.ShowDialog()
                    Else
                        stopCustom("No BOM selected.")
                    End If
                Else ' per PD
                    'Try
                    If FormBOM.GVDesign.FocusedRowHandle < 0 Then
                        stopCustom("Please select proper design first!")
                    Else
                        FormBOMDesignSingle.id_pop_up = "1"
                        FormBOMDesignSingle.id_design = FormBOM.GVDesign.GetFocusedRowCellValue("id_design").ToString
                        FormBOMDesignSingle.TEQtyPD.EditValue = FormBOM.GVDesign.GetFocusedRowCellValue("qty")
                        FormBOMDesignSingle.id_prod_demand_design = FormBOM.GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString
                        FormBOMDesignSingle.ShowDialog()
                    End If
                    'Catch ex As Exception
                    'stopCustom("Please select proper design first!")
                    'End Try
                End If
            ElseIf formName = "FormSamplePL" Then
                'PACKING LIST SAMPLE
                FormSamplePLSingle.action = "upd"
                FormSamplePLSingle.id_pl_sample_purc = FormSamplePL.GVPL.GetFocusedRowCellDisplayText("id_pl_sample_purc").ToString
                FormSamplePLSingle.id_comp_contact_to = FormSamplePL.GVPL.GetFocusedRowCellDisplayText("id_comp_contact_to").ToString
                FormSamplePLSingle.id_comp_contact_from = FormSamplePL.GVPL.GetFocusedRowCellDisplayText("id_comp_contact_from").ToString
                FormSamplePLSingle.id_sample_purc = FormSamplePL.GVPL.GetFocusedRowCellDisplayText("id_sample_purc").ToString
                FormSamplePLSingle.ShowDialog()
            ElseIf formName = "FormSamplePurchase" Then
                '
                FormSamplePurchaseDet.id_sample_purc = FormSamplePurchase.GVSamplePurchase.GetFocusedRowCellDisplayText("id_sample_purc").ToString
                FormSamplePurchaseDet.ShowDialog()
            ElseIf formName = "FormSampleReceive" Then
                '
                FormSampleReceiveDet.id_receive = FormSampleReceive.GVSampleReceive.GetFocusedRowCellDisplayText("id_sample_purc_rec").ToString
                FormSampleReceiveDet.ShowDialog()
            ElseIf formName = "FormSamplePR" Then
                '
                FormSamplePRDet.id_pr = FormSamplePR.GVSamplePR.GetFocusedRowCellDisplayText("id_pr_sample_purc").ToString
                FormSamplePRDet.ShowDialog()
            ElseIf formName = "FormMasterWH" Then
                'WAREHOUSE & LOCATOR
                If FormMasterWH.XTCWH.SelectedTabPageIndex = 1 Then 'Locator
                    FormMasterWHSingle.id_wh_locator = FormMasterWH.GVLocator.GetFocusedRowCellDisplayText("id_wh_locator").ToString
                    FormMasterWHSingle.action = "upd"
                    FormMasterWHSingle.ShowDialog()
                ElseIf FormMasterWH.XTCWH.SelectedTabPageIndex = 2 Then 'Rack
                    FormMasterWHRackSingle.id_wh_rack = FormMasterWH.GVRack.GetFocusedRowCellDisplayText("id_wh_rack").ToString
                    FormMasterWHRackSingle.action = "upd"
                    FormMasterWHRackSingle.ShowDialog()
                ElseIf FormMasterWH.XTCWH.SelectedTabPageIndex = 3 Then 'Drawer
                    FormMasterWHDrawerSingle.id_wh_drawer = FormMasterWH.GVDrawer.GetFocusedRowCellDisplayText("id_wh_drawer").ToString
                    FormMasterWHDrawerSingle.action = "upd"
                    FormMasterWHDrawerSingle.ShowDialog()
                End If
            ElseIf formName = "FormSampleReceipt" Then
                'RECEIPT SAMPLE
                FormSampleReceiptSingle.action = "upd"
                FormSampleReceiptSingle.id_pl_sample_purc = FormSampleReceipt.GVReceipt.GetFocusedRowCellDisplayText("id_pl_sample_purc").ToString
                FormSampleReceiptSingle.ShowDialog()
            ElseIf formName = "FormSampleRet" Then
                'RETURN SAMPLE
                If FormSampleRet.XTCReturn.SelectedTabPageIndex = 0 Then 'returnIn
                    FormSampleRetOutSingle.action = "upd"
                    FormSampleRetOutSingle.id_sample_purc_ret_out = FormSampleRet.GVRetOut.GetFocusedRowCellDisplayText("id_sample_purc_ret_out")
                    FormSampleRetOutSingle.ShowDialog()
                ElseIf FormSampleRet.XTCReturn.SelectedTabPageIndex = 1 Then 'Return Out
                    FormSampleRetInSingle.action = "upd"
                    FormSampleRetInSingle.id_sample_purc_ret_in = FormSampleRet.GVRetIn.GetFocusedRowCellDisplayText("id_sample_purc_ret_in")
                    FormSampleRetInSingle.ShowDialog()
                End If
            ElseIf formName = "FormSamplePLDel" Then
                'PACKING LIST SAMPLE DELIVERY
                FormSamplePLDelSingle.action = "upd"
                FormSamplePLDelSingle.id_pl_sample_del = FormSamplePLDel.GVPL.GetFocusedRowCellDisplayText("id_pl_sample_del").ToString
                FormSamplePLDelSingle.id_comp_contact_to = FormSamplePLDel.GVPL.GetFocusedRowCellDisplayText("id_comp_contact_to").ToString
                FormSamplePLDelSingle.id_comp_contact_from = FormSamplePLDel.GVPL.GetFocusedRowCellDisplayText("id_comp_contact_from").ToString
                FormSamplePLDelSingle.ShowDialog()
            ElseIf formName = "FormSampleReq" Then
                'SAMPLE REQUISITION
                FormSampleReqSingle.action = "upd"
                FormSampleReqSingle.id_sample_requisition = FormSampleReq.GVReq.GetFocusedRowCellDisplayText("id_sample_requisition").ToString
                FormSampleReqSingle.ShowDialog()
            ElseIf formName = "FormMarkAssign" Then
                'Assing Mark
                FormMarkAssignSingle.id_mark_asg = FormMarkAssign.GVMarkAssign.GetFocusedRowCellDisplayText("id_mark_asg")
                FormMarkAssignSingle.ShowDialog()
            ElseIf formName = "FormSamplePlan" Then
                'Sample Plan
                FormSamplePlanDet.id_sample_plan = FormSamplePlan.GVSamplePurchase.GetFocusedRowCellDisplayText("id_sample_plan")
                FormSamplePlanDet.ShowDialog()
            ElseIf formName = "FormMatPurchase" Then
                'Material Purchase
                FormMatPurchaseDet.id_purc = FormMatPurchase.GVMatPurchase.GetFocusedRowCellDisplayText("id_mat_purc")
                FormMatPurchaseDet.ShowDialog()
            ElseIf formName = "FormSampleReturn" Then
                'SAMPLE RETURN
                FormSampleReturnSingle.action = "upd"
                FormSampleReturnSingle.id_sample_return = FormSampleReturn.GVRetSample.GetFocusedRowCellDisplayText("id_sample_return").ToString
                FormSampleReturnSingle.id_comp_contact_to = FormSampleReturn.GVRetSample.GetFocusedRowCellValue("id_comp_contact_to").ToString
                FormSampleReturnSingle.id_comp_contact_from = FormSampleReturn.GVRetSample.GetFocusedRowCellValue("id_comp_contact_from").ToString
                FormSampleReturnSingle.ShowDialog()
            ElseIf formName = "FormMatWO" Then
                'Material WO
                FormMatWODet.id_purc = FormMatWO.GVMatWO.GetFocusedRowCellDisplayText("id_mat_wo")
                FormMatWODet.ShowDialog()
            ElseIf formName = "FormMatRecPurc" Then
                'Receive Material Purchase
                FormMatRecPurcDet.id_receive = FormMatRecPurc.GVMatRecPurc.GetFocusedRowCellDisplayText("id_mat_purc_rec")
                FormMatRecPurcDet.ShowDialog()
            ElseIf formName = "FormMatRecWO" Then
                'Receive Material Purchase
                FormMatRecWODet.id_receive = FormMatRecWO.GVMatRecPurc.GetFocusedRowCellDisplayText("id_mat_wo_rec")
                FormMatRecWODet.ShowDialog()
            ElseIf formName = "FormMatRet" Then
                'RETURN Mat
                If FormMatRet.XTCReturnMat.SelectedTabPageIndex = 0 Then 'ret purchase
                    If FormMatRet.XTCReturnPruchase.SelectedTabPageIndex = 0 Then 'return Out
                        FormMatRetOutDet.action = "upd"
                        FormMatRetOutDet.id_mat_purc_ret_out = FormMatRet.GVRetOut.GetFocusedRowCellDisplayText("id_mat_purc_ret_out")
                        FormMatRetOutDet.ShowDialog()
                    ElseIf FormMatRet.XTCReturnPruchase.SelectedTabPageIndex = 1 Then 'Return In
                        FormMatRetInDet.action = "upd"
                        FormMatRetInDet.id_mat_purc_ret_in = FormMatRet.GVRetIn.GetFocusedRowCellDisplayText("id_mat_purc_ret_in")
                        FormMatRetInDet.ShowDialog()
                    End If
                ElseIf FormMatRet.XTCReturnMat.SelectedTabPageIndex = 1 Then 'ret production
                    If FormMatRet.XTCReturnProd.SelectedTabPageIndex = 0 Then 'return In
                        FormMatRetInProd.action = "upd"
                        FormMatRetInProd.id_mat_prod_ret_in = FormMatRet.GVRetInProd.GetFocusedRowCellDisplayText("id_mat_prod_ret_in")
                        FormMatRetInProd.ShowDialog()
                    End If
                ElseIf FormMatRet.XTCReturnMat.SelectedTabPageIndex = 2 Then 'other
                    FormMatRetInProd.action = "upd"
                    FormMatRetInProd.is_other = True
                    FormMatRetInProd.id_mat_prod_ret_in = FormMatRet.GVRetOther.GetFocusedRowCellDisplayText("id_mat_prod_ret_in")
                    FormMatRetInProd.ShowDialog()
                End If
            ElseIf formName = "FormSampleAdjustment" Then
                'SAMPLE ADJUSTMENT
                If FormSampleAdjustment.XTCAdj.SelectedTabPageIndex = "0" Then
                    FormSampleAdjustmentInSingle.action = "upd"
                    FormSampleAdjustmentInSingle.id_adj_in_sample = FormSampleAdjustment.GVAdjSampleIn.GetFocusedRowCellDisplayText("id_adj_in_sample").ToString
                    FormSampleAdjustmentInSingle.ShowDialog()
                ElseIf FormSampleAdjustment.XTCAdj.SelectedTabPageIndex = "1" Then
                    FormSampleAdjustmentOutSingle.action = "upd"
                    FormSampleAdjustmentOutSingle.id_adj_out_sample = FormSampleAdjustment.GVAdjOutSample.GetFocusedRowCellDisplayText("id_adj_out_sample").ToString
                    FormSampleAdjustmentOutSingle.ShowDialog()
                End If
            ElseIf formName = "FormMatAdj" Then
                'MATERIAL ADJUSTMENT
                If FormMatAdj.XTCAdj.SelectedTabPageIndex = "0" Then
                    FormMatAdjInSingle.action = "upd"
                    FormMatAdjInSingle.id_adj_in_mat = FormMatAdj.GVAdjIn.GetFocusedRowCellDisplayText("id_adj_in_mat").ToString
                    FormMatAdjInSingle.ShowDialog()
                ElseIf FormMatAdj.XTCAdj.SelectedTabPageIndex = "1" Then
                    FormMatAdjOutSingle.action = "upd"
                    FormMatAdjOutSingle.id_adj_out_mat = FormMatAdj.GVAdjOut.GetFocusedRowCellDisplayText("id_adj_out_mat").ToString
                    FormMatAdjOutSingle.ShowDialog()
                End If
            ElseIf formName = "FormProduction" Then
                'Production
                If FormProduction.XTCTabProduction.SelectedTabPageIndex = 0 Then 'prod order
                    FormProductionDet.id_prod_order = FormProduction.GVProd.GetFocusedRowCellDisplayText("id_prod_order").ToString
                    FormProductionDet.ShowDialog()
                End If
            ElseIf formName = "FormMatPL" Then
                If FormMatPL.XTCPL.SelectedTabPageIndex = 0 Then 'Production
                    FormMatPLSingle.action = "upd"
                    FormMatPLSingle.id_pl_mrs = FormMatPL.GVProdPL.GetFocusedRowCellDisplayText("id_pl_mrs").ToString
                    FormMatPLSingle.id_comp_contact_to = FormMatPL.GVProdPL.GetFocusedRowCellDisplayText("id_comp_contact_to").ToString
                    FormMatPLSingle.id_comp_contact_from = FormMatPL.GVProdPL.GetFocusedRowCellDisplayText("id_comp_contact_from").ToString
                    FormMatPLSingle.ShowDialog()
                ElseIf FormMatPL.XTCPL.SelectedTabPageIndex = 1 Then 'wo
                    FormMatPLSingle.action = "upd"
                    FormMatPLSingle.is_other = "1"
                    FormMatPLSingle.id_pl_mrs = FormMatPL.GVPLWO.GetFocusedRowCellDisplayText("id_pl_mrs").ToString
                    FormMatPLSingle.id_comp_contact_to = FormMatPL.GVPLWO.GetFocusedRowCellDisplayText("id_comp_contact_to").ToString
                    FormMatPLSingle.id_comp_contact_from = FormMatPL.GVPLWO.GetFocusedRowCellDisplayText("id_comp_contact_from").ToString
                    FormMatPLSingle.ShowDialog()
                ElseIf FormMatPL.XTCPL.SelectedTabPageIndex = 2 Then 'Other
                    FormMatPLSingle.action = "upd"
                    FormMatPLSingle.is_other = "1"
                    FormMatPLSingle.id_pl_mrs = FormMatPL.GVPLOther.GetFocusedRowCellDisplayText("id_pl_mrs").ToString
                    FormMatPLSingle.id_comp_contact_to = FormMatPL.GVPLOther.GetFocusedRowCellDisplayText("id_comp_contact_to").ToString
                    FormMatPLSingle.id_comp_contact_from = FormMatPL.GVPLOther.GetFocusedRowCellDisplayText("id_comp_contact_from").ToString
                    FormMatPLSingle.ShowDialog()
                End If
            ElseIf formName = "FormMatMRS" Then
                If FormMatMRS.XTCMRS.SelectedTabPageIndex = 0 Then 'mat wo
                    FormMatMRSDet.id_mrs = FormMatMRS.GVMRSWO.GetFocusedRowCellDisplayText("id_prod_order_mrs").ToString
                    FormMatMRSDet.mrs_type = "2"
                    FormMatMRSDet.id_comp_req_from = FormMatMRS.GVMRSWO.GetFocusedRowCellValue("id_comp_name_req_from").ToString
                    FormMatMRSDet.id_comp_req_to = FormMatMRS.GVMRSWO.GetFocusedRowCellValue("id_comp_name_req_to").ToString
                    FormMatMRSDet.TEMRSNumber.Text = FormMatMRS.GVMRSWO.GetFocusedRowCellValue("prod_order_mrs_number").ToString
                    FormMatMRSDet.ShowDialog()
                ElseIf FormMatMRS.XTCMRS.SelectedTabPageIndex = 1 Then 'other
                    FormMatMRSDet.id_mrs = FormMatMRS.GVMRS.GetFocusedRowCellDisplayText("id_prod_order_mrs").ToString
                    FormMatMRSDet.mrs_type = "1"
                    FormMatMRSDet.id_comp_req_from = FormMatMRS.GVMRS.GetFocusedRowCellValue("id_comp_name_req_from").ToString
                    FormMatMRSDet.id_comp_req_to = FormMatMRS.GVMRS.GetFocusedRowCellValue("id_comp_name_req_to").ToString
                    FormMatMRSDet.TEMRSNumber.Text = FormMatMRS.GVMRS.GetFocusedRowCellValue("prod_order_mrs_number").ToString
                    FormMatMRSDet.ShowDialog()
                End If
            ElseIf formName = "FormMatPR" Then
                FormMatPRDet.id_pr = FormMatPR.GVMatPR.GetFocusedRowCellDisplayText("id_pr_mat_purc").ToString
                FormMatPRDet.ShowDialog()
            ElseIf formName = "FormMatPRWO" Then
                FormMatPRWODet.id_pr = FormMatPRWO.GVMatPRWO.GetFocusedRowCellDisplayText("id_pr_mat_wo").ToString
                FormMatPRWODet.ShowDialog()
            ElseIf formName = "FormProductionRec" Then
                'Receive QC FG
                FormProductionRecDet.id_receive = FormProductionRec.GVProdRec.GetFocusedRowCellDisplayText("id_prod_order_rec")
                FormProductionRecDet.ShowDialog()
            ElseIf formName = "FormProductionRet" Then
                'RETURN FG
                If FormProductionRet.XTCReturn.SelectedTabPageIndex = 0 Then 'return Out
                    FormProductionRetOutSingle.action = "upd"
                    FormProductionRetOutSingle.id_prod_order_ret_out = FormProductionRet.GVRetOut.GetFocusedRowCellDisplayText("id_prod_order_ret_out")
                    FormProductionRetOutSingle.ShowDialog()
                ElseIf FormProductionRet.XTCReturn.SelectedTabPageIndex = 1 Then 'Return In
                    FormProductionRetInSingle.action = "upd"
                    FormProductionRetInSingle.id_prod_order_ret_in = FormProductionRet.GVRetIn.GetFocusedRowCellDisplayText("id_prod_order_ret_in")
                    FormProductionRetInSingle.ShowDialog()
                End If
            ElseIf formName = "FormProductionPLToWH" Then
                FormProductionPLToWHDet.action = "upd"
                FormProductionPLToWHDet.id_pl_prod_order = FormProductionPLToWH.GVPL.GetFocusedRowCellDisplayText("id_pl_prod_order")
                FormProductionPLToWHDet.ShowDialog()
            ElseIf formName = "FormMatInvoice" Then
                If FormMatInvoice.XTCTabGeneral.SelectedTabPageIndex = 0 Then 'invoice
                    'Mat Invoice
                    FormMatInvoiceDet.id_invoice = FormMatInvoice.GVProdInvoice.GetFocusedRowCellValue("id_inv_pl_mrs").ToString
                    FormMatInvoiceDet.id_comp_to = FormMatInvoice.GVProdInvoice.GetFocusedRowCellValue("id_comp_contact_to").ToString

                    FormMatInvoiceDet.TEWONumber.Text = FormMatInvoice.GVProdInvoice.GetFocusedRowCellValue("prod_order_wo_number").ToString
                    FormMatInvoiceDet.TEPONumber.Text = FormMatInvoice.GVProdInvoice.GetFocusedRowCellValue("prod_order_number").ToString
                    FormMatInvoiceDet.TEDesign.Text = FormMatInvoice.GVProdInvoice.GetFocusedRowCellValue("design_name").ToString

                    FormMatInvoiceDet.id_prod_order_wo = FormMatInvoice.GVProdInvoice.GetFocusedRowCellValue("id_prod_order_wo").ToString
                    FormMatInvoiceDet.ShowDialog()
                Else 'retur
                    FormMatInvoiceReturDet.id_retur = FormMatInvoice.GVRetur.GetFocusedRowCellValue("id_inv_pl_mrs_ret").ToString
                    FormMatInvoiceReturDet.id_invoice = FormMatInvoice.GVRetur.GetFocusedRowCellValue("id_inv_pl_mrs").ToString
                    FormMatInvoiceReturDet.id_comp_to = FormMatInvoice.GVRetur.GetFocusedRowCellValue("id_comp_contact_from").ToString

                    FormMatInvoiceReturDet.TEReturNumber.Text = FormMatInvoice.GVRetur.GetFocusedRowCellValue("inv_pl_mrs_ret_number").ToString
                    FormMatInvoiceReturDet.TEInvNumber.Text = FormMatInvoice.GVRetur.GetFocusedRowCellValue("inv_pl_mrs_number").ToString
                    FormMatInvoiceReturDet.TEWONumber.Text = FormMatInvoice.GVRetur.GetFocusedRowCellValue("prod_order_wo_number").ToString
                    FormMatInvoiceReturDet.TEPONumber.Text = FormMatInvoice.GVRetur.GetFocusedRowCellValue("prod_order_number").ToString
                    FormMatInvoiceReturDet.TEDesign.Text = FormMatInvoice.GVRetur.GetFocusedRowCellValue("design_name").ToString

                    FormMatInvoiceReturDet.id_prod_wo = FormMatInvoice.GVRetur.GetFocusedRowCellValue("id_prod_order_wo").ToString
                    FormMatInvoiceReturDet.ShowDialog()
                End If
            ElseIf formName = "FormAccounting" Then
                If FormAccounting.XTCGeneral.SelectedTabPageIndex = 0 Then 'view master
                    FormAccountingAcc.id_acc = FormAccounting.GVAcc.GetFocusedRowCellValue("id_acc").ToString
                    FormAccountingAcc.ShowDialog()
                Else
                    FormAccountingAcc.id_acc = FormAccounting.TreeList1.FocusedNode("id_acc").ToString
                    FormAccountingAcc.ShowDialog()
                End If
            ElseIf formName = "FormAccountingJournal" Then
                FormAccountingJournalBill.id_trans = FormAccountingJournal.GVAccTrans.GetFocusedRowCellValue("id_acc_trans").ToString
                FormAccountingJournalBill.TEUserEntry.Text = FormAccountingJournal.GVAccTrans.GetFocusedRowCellValue("employee_name").ToString
                FormAccountingJournalBill.ShowDialog()
            ElseIf formName = "FormProductionPLToWHRec" Then
                FormProductionPLToWHRecDet.action = "upd"
                FormProductionPLToWHRecDet.id_pl_prod_order_rec = FormProductionPLToWHRec.GVPL.GetFocusedRowCellDisplayText("id_pl_prod_order_rec")
                FormProductionPLToWHRecDet.ShowDialog()
            ElseIf formName = "FormSalesTarget" Then
                'SALES TARGET
                If FormSalesTarget.XTCSalesTarget.SelectedTabPageIndex = 0 Then
                    FormSalesTargetDet.action = "upd"
                    FormSalesTargetDet.id_sales_target = FormSalesTarget.GVSalesTarget.GetFocusedRowCellValue("id_sales_target").ToString
                    FormSalesTargetDet.ShowDialog()
                End If
            ElseIf formName = "FormSalesOrder" Then
                'SALES ORDER
                If FormSalesOrder.XTCSOGeneral.SelectedTabPageIndex = 0 Then
                    FormSalesOrderDet.action = "upd"
                    FormSalesOrderDet.id_sales_order = FormSalesOrder.GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
                    FormSalesOrderDet.ShowDialog()
                ElseIf FormSalesOrder.XTCSOGeneral.SelectedTabPageIndex = 1 Then
                    FormSalesOrderGen.action = "upd"
                    FormSalesOrderGen.id_sales_order_gen = FormSalesOrder.GVGen.GetFocusedRowCellValue("id_sales_order_gen").ToString
                    FormSalesOrderGen.ShowDialog()
                End If
            ElseIf formName = "FormSalesDelOrder" Then
                'SALES DELIVERY ORDER
                FormSalesDelOrderDet.action = "upd"
                FormSalesDelOrderDet.id_pl_sales_order_del = FormSalesDelOrder.GVSalesDelOrder.GetFocusedRowCellValue("id_pl_sales_order_del").ToString
                FormSalesDelOrderDet.ShowDialog()
            ElseIf formName = "FormSalesReturnOrder" Then
                'SALES RETURN ORDER
                If FormSalesReturnOrder.XTCROR.SelectedTabPageIndex = 0 Then
                    FormSalesReturnOrderDet.action = "upd"
                    FormSalesReturnOrderDet.id_sales_return_order = FormSalesReturnOrder.GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order").ToString
                    FormSalesReturnOrderDet.ShowDialog()
                ElseIf FormSalesReturnOrder.XTCROR.SelectedTabPageIndex = 1 Then
                    FormSalesReturnOrderDet.action = "upd"
                    FormSalesReturnOrderDet.id_sales_return_order = FormSalesReturnOrder.GVOnHold.GetFocusedRowCellValue("id_sales_return_order").ToString
                    FormSalesReturnOrderDet.ShowDialog()
                End If
            ElseIf formName = "FormSalesReturnOrderOL" Then
                'SALES RETURN ORDER OL
                FormSalesReturnOrderOLDet.action = "upd"
                FormSalesReturnOrderOLDet.id_sales_return_order = FormSalesReturnOrderOL.GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order").ToString
                FormSalesReturnOrderOLDet.ShowDialog()
            ElseIf formName = "FormSalesReturn" Then
                'SALES RETURN
                FormSalesReturnDet.action = "upd"
                FormSalesReturnDet.id_sales_return = FormSalesReturn.GVSalesReturn.GetFocusedRowCellValue("id_sales_return").ToString
                FormSalesReturnDet.ShowDialog()
            ElseIf formName = "FormSalesPOS" Then
                'SALES POS
                FormSalesPOSDet.id_menu = FormSalesPOS.id_menu
                FormSalesPOSDet.action = "upd"
                FormSalesPOSDet.id_sales_pos = FormSalesPOS.GVSalesPOS.GetFocusedRowCellValue("id_sales_pos").ToString
                FormSalesPOSDet.ShowDialog()
            ElseIf formName = "FormSalesReturnQC" Then
                'SALES RETURN QC
                FormSalesReturnQCDet.action = "upd"
                FormSalesReturnQCDet.id_sales_return_qc = FormSalesReturnQC.GVSalesReturnQC.GetFocusedRowCellValue("id_sales_return_qc").ToString
                FormSalesReturnQCDet.ShowDialog()
            ElseIf formName = "FormProdPRWO" Then
                If FormProdPRWO.XTCTabPR.SelectedTabPageIndex = 0 Then
                    FormProdPRWODet.id_pr = FormProdPRWO.GVMatPR.GetFocusedRowCellValue("id_pr_prod_order").ToString
                    'FormProdPRWODet.id_prod_order = FormProdPRWO.GVMatPR.GetFocusedRowCellValue("id_prod_order")
                    'FormProdPRWODet.id_prod_order_wo = FormProdPRWO.GVMatPR.GetFocusedRowCellValue("id_prod_order_wo")
                    FormProdPRWODet.ShowDialog()
                ElseIf FormProdPRWO.XTCTabPR.SelectedTabPageIndex = 2 Then
                    FormProdPRWODet.id_pr = FormProdPRWO.GVPRPO.GetFocusedRowCellValue("id_pr_prod_order").ToString
                    FormProdPRWODet.is_po_pr = "1"
                    FormProdPRWODet.ShowDialog()
                ElseIf FormProdPRWO.XTCTabPR.SelectedTabPageIndex = 3 Then
                    FormProdPRWODet.id_pr = FormProdPRWO.GVPRNoReff.GetFocusedRowCellValue("id_pr_prod_order").ToString
                    FormProdPRWODet.is_no_reff = "1"
                    FormProdPRWODet.ShowDialog()
                End If
            ElseIf formName = "FormSalesInvoice" Then
                'SALES INVOICE
                FormSalesInvoiceDet.action = "upd"
                FormSalesInvoiceDet.id_sales_invoice = FormSalesInvoice.GVSalesInvoice.GetFocusedRowCellValue("id_sales_invoice").ToString
                FormSalesInvoiceDet.ShowDialog()
            ElseIf formName = "FormFGStockOpnameStore" Then
                'STORE STOCK OPNAME
                FormFGStockOpnameStoreDet.action = "upd"
                FormFGStockOpnameStoreDet.id_fg_so_store = FormFGStockOpnameStore.GVSOStore.GetFocusedRowCellValue("id_fg_so_store").ToString
                FormFGStockOpnameStoreDet.ShowDialog()
            ElseIf formName = "FormFGMissing" Then
                'FG MIssing
                If FormFGMissing.XTCFGMissing.SelectedTabPageIndex = 0 Then
                    FormFGMissingDet.action = "upd"
                    FormFGMissingDet.id_fg_missing = FormFGMissing.GVFGMissing.GetFocusedRowCellValue("id_sales_pos").ToString
                    FormFGMissingDet.ShowDialog()
                ElseIf FormFGMissing.XTCFGMissing.SelectedTabPageIndex = 1 Then
                    FormFGMissingWHDet.action = "upd"
                    FormFGMissingWHDet.id_fg_missing = FormFGMissing.GVMissingWH.GetFocusedRowCellValue("id_sales_pos").ToString
                    FormFGMissingWHDet.ShowDialog()
                End If
            ElseIf formName = "FormFGMissingInvoice" Then
                'FG MISSING INVOICE 
                FormFGMissingInvoiceDet.action = "upd"
                FormFGMissingInvoiceDet.id_fg_missing_invoice = FormFGMissingInvoice.GVFGMissingInvoice.GetFocusedRowCellValue("id_fg_missing_invoice").ToString
                FormFGMissingInvoiceDet.ShowDialog()
            ElseIf formName = "FormFGStockOpnameWH" Then
                'WH STOCK OPNAME
                FormFGStockOpnameWHDet.action = "upd"
                FormFGStockOpnameWHDet.id_fg_so_wh = FormFGStockOpnameWH.GVSOWH.GetFocusedRowCellValue("id_fg_so_wh").ToString
                FormFGStockOpnameWHDet.ShowDialog()
            ElseIf formName = "FormMatStockOpname" Then
                If Not FormMatStockOpname.GVMatPR.IsGroupRow(FormMatStockOpname.GVMatPR.FocusedRowHandle) Then
                    FormMatStockOpnameDet.id_mat_so = FormMatStockOpname.GVMatPR.GetFocusedRowCellValue("id_mat_so").ToString
                    FormMatStockOpnameDet.ShowDialog()
                End If
            ElseIf formName = "FormFGAdj" Then
                'FG ADJUSTMENT
                If FormFGAdj.XTCAdj.SelectedTabPageIndex = "0" Then
                    FormFGAdjInDet.action = "upd"
                    FormFGAdjInDet.id_adj_in_fg = FormFGAdj.GVAdjIn.GetFocusedRowCellValue("id_adj_in_fg").ToString
                    FormFGAdjInDet.ShowDialog()
                ElseIf FormFGAdj.XTCAdj.SelectedTabPageIndex = "1" Then
                    FormFGAdjOutDet.action = "upd"
                    FormFGAdjOutDet.id_adj_out_fg = FormFGAdj.GVAdjOut.GetFocusedRowCellDisplayText("id_adj_out_fg").ToString
                    FormFGAdjOutDet.ShowDialog()
                End If
            ElseIf formName = "FormFGTrf" Then
                'FG Transfer Future
                FormFGTrfDet.action = "upd"
                FormFGTrfDet.id_fg_trf = FormFGTrf.GVFGTrf.GetFocusedRowCellValue("id_fg_trf").ToString
                FormFGTrfDet.ShowDialog()
            ElseIf formName = "FormFGTrfNew" Then
                'FG Transfer
                FormFGTrfNewDet.action = "upd"
                FormFGTrfNewDet.id_fg_trf = FormFGTrfNew.GVFGTrf.GetFocusedRowCellValue("id_fg_trf").ToString
                FormFGTrfNewDet.ShowDialog()
            ElseIf formName = "FormFGTrfReceive" Then
                'FG Transfer
                FormFGTrfDet.id_type = "1"
                FormFGTrfDet.action = "upd"
                FormFGTrfDet.id_fg_trf = FormFGTrfReceive.GVFGTrf.GetFocusedRowCellValue("id_fg_trf").ToString
                FormFGTrfDet.ShowDialog()
            ElseIf formName = "FormMasterEmployee" Then
                'Master Employee
                FormMasterEmployeeNewDet.id_employee = FormMasterEmployee.GVEmployee.GetFocusedRowCellValue("id_employee").ToString
                FormMasterEmployeeNewDet.is_salary = FormMasterEmployee.is_salary
                FormMasterEmployeeNewDet.action = "upd"
                FormMasterEmployeeNewDet.ShowDialog()
            ElseIf formName = "FormSampleDel" Then
                'PL Sample Delivery
                FormSampleDelDet.action = "upd"
                FormSampleDelDet.id_sample_del = FormSampleDel.GVSampleDel.GetFocusedRowCellValue("id_sample_del").ToString
                FormSampleDelDet.ShowDialog()
            ElseIf formName = "FormSampleDelRec" Then
                'Rec PL Sample Delivery
                FormSampleDelRecDet.action = "upd"
                FormSampleDelRecDet.id_sample_del_rec = FormSampleDelRec.GVSampleDelRec.GetFocusedRowCellValue("id_sample_del_rec").ToString
                FormSampleDelRecDet.ShowDialog()
            ElseIf formName = "FormSampleOrder" Then
                'Sales Order Sample
                FormSampleOrderDet.action = "upd"
                FormSampleOrderDet.id_sample_order = FormSampleOrder.GVSampleOrder.GetFocusedRowCellValue("id_sample_order").ToString
                FormSampleOrderDet.ShowDialog()
            ElseIf formName = "FormSampleDelOrder" Then
                'DELIVERY ORDER SAMPLE FOR SALES
                If FormSampleDelOrder.XTCSampleDelOrder.SelectedTabPageIndex = 0 Then
                    FormSampleDelOrderDet.id_pl_sample_order_del = FormSampleDelOrder.GVSampleDelOrder.GetFocusedRowCellValue("id_pl_sample_order_del").ToString
                    FormSampleDelOrderDet.action = "upd"
                    FormSampleDelOrderDet.ShowDialog()
                End If
            ElseIf formName = "FormFGCodeReplace" Then
                'CODE REPLACEMENT FG STORE
                If FormFGCodeReplace.XTCFGCodeReplace.SelectedTabPageIndex = 0 Then
                    FormFGCodeReplaceStoreDet.form_type = FormFGCodeReplace.form_type
                    FormFGCodeReplaceStoreDet.action = "upd"
                    FormFGCodeReplaceStoreDet.id_fg_code_replace_store = FormFGCodeReplace.GVFGCodeReplaceStore.GetFocusedRowCellValue("id_fg_code_replace_store").ToString
                    FormFGCodeReplaceStoreDet.ShowDialog()
                ElseIf FormFGCodeReplace.XTCFGCodeReplace.SelectedTabPageIndex = 1 Then
                    FormFGCodeReplaceWHDet.action = "upd"
                    FormFGCodeReplaceWHDet.id_fg_code_replace_wh = FormFGCodeReplace.GVFGCodeReplaceWH.GetFocusedRowCellValue("id_fg_code_replace_wh").ToString
                    FormFGCodeReplaceWHDet.ShowDialog()
                End If
            ElseIf formName = "FormSampleStockOpname" Then
                'Sales Order Sample
                FormSampleStockOpnameDet.action = "upd"
                FormSampleStockOpnameDet.id_sample_so = FormSampleStockOpname.GVSOWH.GetFocusedRowCellValue("id_sample_so").ToString
                FormSampleStockOpnameDet.ShowDialog()
            ElseIf formName = "FormSalesCreditNote" Then
                'CREDIT NOTE SALES
                FormSalesCreditNoteDet.action = "upd"
                FormSalesCreditNoteDet.id_sales_pos = FormSalesCreditNote.GVSalesPOS.GetFocusedRowCellValue("id_sales_pos").ToString
                FormSalesCreditNoteDet.ShowDialog()
            ElseIf formName = "FormFGMissingCreditNote" Then
                'CREDIT NOTE MISSING
                If FormFGMissingCreditNote.XTCFGMissingCN.SelectedTabPageIndex = 0 Then
                    FormFGMissingCreditNoteStoreDet.action = "upd"
                    FormFGMissingCreditNoteStoreDet.id_sales_pos = FormFGMissingCreditNote.GVFGMissingCNStore.GetFocusedRowCellValue("id_sales_pos").ToString
                    FormFGMissingCreditNoteStoreDet.ShowDialog()
                End If
            ElseIf formName = "FormSOHPeriode" Then
                'SOH PERIODE
                FormSOHPeriodeDet.id_soh_periode = FormSOHPeriode.GVSOHPeriode.GetFocusedRowCellValue("id_soh_periode").ToString
                FormSOHPeriodeDet.ShowDialog()
            ElseIf formName = "FormSOH" Then
                'SOH
                FormSOHDet.id_soh = FormSOH.BGVSOH.GetFocusedRowCellValue("id_soh").ToString
                FormSOHDet.ShowDialog()
            ElseIf formName = "FormSOHPrice" Then
                'SOH PRICE
                FormSOHPriceDet.id_soh_periode = FormSOHPrice.GVSOHPeriode.GetFocusedRowCellValue("id_soh_periode").ToString
                FormSOHPriceDet.TERange.Text = FormSOHPrice.GVSOHPeriode.GetFocusedRowCellValue("soh_periode").ToString
                FormSOHPriceDet.TERangeDesc.Text = FormSOHPrice.GVSOHPeriode.GetFocusedRowCellDisplayText("date_start").ToString + " - " + FormSOHPrice.GVSOHPeriode.GetFocusedRowCellDisplayText("date_end").ToString
                FormSOHPriceDet.ShowDialog()
            ElseIf formName = "FormFGWoff" Then
                'FG WRITE OFF
                FormFGWoffDet.id_fg_woff = FormFGWoff.GVFGWoff.GetFocusedRowCellValue("id_fg_woff").ToString
                FormFGWoffDet.action = "upd"
                FormFGWoffDet.ShowDialog()
            ElseIf formName = "FormFGProposePrice" Then
                'FG PROPOSE PRICE
                If FormFGProposePrice.XTCPropose.SelectedTabPageIndex = 0 Then
                    FormFGProposePriceDetail.id = FormFGProposePrice.GVFGPropose.GetFocusedRowCellValue("id_fg_propose_price").ToString
                    FormFGProposePriceDetail.ShowDialog()
                ElseIf FormFGProposePrice.XTCPropose.SelectedTabPageIndex = 1 Then
                    FormFGProposePriceRev.id = FormFGProposePrice.GVRev.GetFocusedRowCellValue("id_fg_propose_price_rev").ToString
                    FormFGProposePriceRev.ShowDialog()
                End If
            ElseIf formName = "FormMasterRetCode" Then
                'MASTER RET CODE
                FormMasterRetCodeDet.id_ret_code = FormMasterRetCode.GVRetCode.GetFocusedRowCellValue("id_ret_code").ToString
                FormMasterRetCodeDet.action = "upd"
                FormMasterRetCodeDet.ShowDialog()
            ElseIf formName = "FormMasterDesignCOP" Then
                'MASTER RET CODE
                FormProductionCOP.id_design = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("id_design").ToString
                FormProductionCOP.ShowDialog()
            ElseIf formName = "FormSampleOrdered" Then
                'SAMPLE ORDERED
                FormSampleOrderedDet.id_sample_ordered = FormSampleOrdered.GVSampleOrder.GetFocusedRowCellValue("id_sample_ordered").ToString
                FormSampleOrderedDet.ShowDialog()
            ElseIf formName = "FormMasterRateStore" Then
                'MASTER RATE STORE
                FormMasterRateStoreDet.id_store_rate = FormMasterRateStore.GVStoreRate.GetFocusedRowCellValue("id_store_rate").ToString
                FormMasterRateStoreDet.action = "upd"
                FormMasterRateStoreDet.ShowDialog()
            ElseIf formName = "FormProdQCAdj" Then
                'QC Adj In
                If FormProdQCAdj.XTCAdj.SelectedTabPageIndex = 0 Then
                    If FormProdQCAdj.GVAdjIn.RowCount > 0 Then
                        FormProdQCAdjIn.id_adj_in = FormProdQCAdj.GVAdjIn.GetFocusedRowCellValue("id_prod_order_qc_adj_in").ToString
                        FormProdQCAdjIn.ShowDialog()
                    Else
                        stopCustom("Nothing to edit.")
                    End If
                Else
                    If FormProdQCAdj.GVAdjOut.RowCount > 0 Then
                        FormProdQCAdjOut.id_adj_out = FormProdQCAdj.GVAdjOut.GetFocusedRowCellValue("id_prod_order_qc_adj_out").ToString
                        FormProdQCAdjOut.ShowDialog()
                    Else
                        stopCustom("Nothing to edit.")
                    End If
                End If
            ElseIf formName = "FormSalesPromo" Then
                'Sales Promo
                FormSalesPromoDet.id_sales_pos = FormSalesPromo.GVSalesPOS.GetFocusedRowCellValue("id_sales_pos").ToString
                FormSalesPromoDet.action = "upd"
                FormSalesPromoDet.ShowDialog()
            ElseIf formName = "FormFGSalesOrderReff" Then
                FormFGSalesOrderReffDet.action = "upd"
                FormFGSalesOrderReffDet.id_fg_so_reff = FormFGSalesOrderReff.GVSOReff.GetFocusedRowCellValue("id_fg_so_reff").ToString
                FormFGSalesOrderReffDet.ShowDialog()
            ElseIf formName = "FormMasterComputer" Then
                'MASTER COMPUTER
                FormMasterComnputerDet.id_computer = FormMasterComputer.GVComputer.GetFocusedRowCellValue("id_computer").ToString
                FormMasterComnputerDet.action = "upd"
                FormMasterComnputerDet.ShowDialog()
            ElseIf formName = "FormAccountingFakturScan" Then
                FormAccountingFakturScanSingle.action = "upd"
                FormAccountingFakturScanSingle.id_acc_fak_scan = FormAccountingFakturScan.GVFak.GetFocusedRowCellValue("id_acc_fak_scan").ToString
                FormAccountingFakturScanSingle.ShowDialog()
            ElseIf formName = "FormFGBorrowQCReq" Then
                FormFGBorrowQCReqSingle.action = "upd"
                FormFGBorrowQCReqSingle.id_borrow_qc_req = FormFGBorrowQCReq.GVBorrowReq.GetFocusedRowCellValue("id_borrow_qc_req").ToString
                FormFGBorrowQCReqSingle.ShowDialog()
            ElseIf formName = "FormWHAWBill" Then

                If FormWHAWBill.XTCAwb.SelectedTabPageIndex = 0 Then
                    FormWHAWBillDet.id_awb = FormWHAWBill.GVAWBill.GetFocusedRowCellValue("id_awbill").ToString
                    FormWHAWBillDet.id_awb_type = "1"
                    FormWHAWBillDet.ShowDialog()
                Else
                    FormWHAWBillIn.id_awb = FormWHAWBill.GVAwbillIn.GetFocusedRowCellValue("id_awbill").ToString
                    FormWHAWBillIn.id_awb_type = "2"
                    FormWHAWBillIn.ShowDialog()
                End If
            ElseIf formName = "FormMasterPrice" Then
                FormMasterPriceSingle.action = "upd"
                FormMasterPriceSingle.id_fg_price = FormMasterPrice.GVPrice.GetFocusedRowCellValue("id_fg_price").ToString
                FormMasterPriceSingle.ShowDialog()
            ElseIf formName = "FormFGDesignList" Then
                If FormFGDesignList.XTPDesign.SelectedTabPageIndex = 0 Then
                    FormMasterDesignSingle.id_pop_up = "5"
                    FormMasterDesignSingle.form_name = "FormFGDesignList"
                    FormMasterDesignSingle.id_design = FormFGDesignList.GVDesign.GetFocusedRowCellValue("id_design").ToString
                    FormMasterDesignSingle.WindowState = FormWindowState.Maximized
                    FormMasterDesignSingle.ShowDialog()
                Else
                    FormFGDesignListChanges.id = FormFGDesignList.GVPropose.GetFocusedRowCellValue("id_changes").ToString
                    FormFGDesignListChanges.ShowDialog()
                End If
            ElseIf formName = "FormSamplePLToWH" Then
                'PACING LIST SAMPLE
                FormSamplePLToWHDet.action = "upd"
                FormSamplePLToWHDet.id_sample_pl = FormSamplePLToWH.GVSamplePL.GetFocusedRowCellValue("id_sample_pl").ToString
                FormSamplePLToWHDet.ShowDialog()
            ElseIf formName = "FormMasterPriceSample" Then
                FormMasterPriceSampleSingle.action = "upd"
                FormMasterPriceSampleSingle.id_sample_price = FormMasterPriceSample.GVPrice.GetFocusedRowCellValue("id_sample_price").ToString
                FormMasterPriceSampleSingle.ShowDialog()
            ElseIf formName = "FormFGWHAlloc" Then
                'INVENTORY ALLOCATION
                FormFGWHAllocDet.action = "upd"
                FormFGWHAllocDet.id_fg_wh_alloc = FormFGWHAlloc.GVFGWHAlloc.GetFocusedRowCellValue("id_fg_wh_alloc").ToString
                FormFGWHAllocDet.ShowDialog()
            ElseIf formName = "FormSampleReturnPL" Then
                'PACKING LIST SAMPLE
                FormSampleReturnPLDet.action = "upd"
                FormSampleReturnPLDet.id_sample_pl = FormSampleReturnPL.GVSamplePL.GetFocusedRowCellValue("id_sample_pl_ret").ToString
                FormSampleReturnPLDet.ShowDialog()
            ElseIf formName = "FormEmpShift" Then
                'Template Shift Employee
                FormEmpShiftDet.id_shift = FormEmpShift.GVShift.GetFocusedRowCellValue("id_shift").ToString
                FormEmpShiftDet.ShowDialog()
            ElseIf formName = "FormEmpHoliday" Then
                'Template Shift Employee
                FormEmpHolidayDet.id_holiday = FormEmpHoliday.GVHoliday.GetFocusedRowCellValue("id_emp_holiday").ToString
                FormEmpHolidayDet.ShowDialog()
            ElseIf formName = "FormFGRepair" Then
                'Repair
                FormFGRepairDet.action = "upd"
                FormFGRepairDet.id_fg_repair = FormFGRepair.GVRepair.GetFocusedRowCellValue("id_fg_repair").ToString
                FormFGRepairDet.ShowDialog()
            ElseIf formName = "FormFGRepairRec" Then
                'Repair rec
                FormFGRepairRecDet.action = "upd"
                FormFGRepairRecDet.id_fg_repair_rec = FormFGRepairRec.GVRepairRec.GetFocusedRowCellValue("id_fg_repair_rec").ToString
                FormFGRepairRecDet.ShowDialog()
            ElseIf formName = "FormFGRepairReturn" Then
                'Return Repair
                FormFGRepairReturnDet.action = "upd"
                FormFGRepairReturnDet.id_fg_repair_return = FormFGRepairReturn.GVRepairReturn.GetFocusedRowCellValue("id_fg_repair_return").ToString
                FormFGRepairReturnDet.ShowDialog()
            ElseIf formName = "FormFGRepairReturnRec" Then
                'Repair return rec
                FormFGRepairReturnRecDet.action = "upd"
                FormFGRepairReturnRecDet.id_fg_repair_return_rec = FormFGRepairReturnRec.GVRepairRec.GetFocusedRowCellValue("id_fg_repair_return_rec").ToString
                FormFGRepairReturnRecDet.ShowDialog()
            ElseIf formName = "FormEmpLeave" Then
                'Leave employee
                If FormEmpLeave.GVLeave.RowCount > 0 Then
                    FormEmpLeaveDet.id_emp_leave = FormEmpLeave.GVLeave.GetFocusedRowCellValue("id_emp_leave").ToString
                    FormEmpLeaveDet.ShowDialog()
                End If
            ElseIf formName = "FormEmpEmail" Then
                Dim type As String = FormEmpEmail.GVEmail.GetFocusedRowCellValue("type").ToString
                If type = "1" Then
                    FormEmpEmailDet.id = FormEmpEmail.GVEmail.GetFocusedRowCellValue("id_employee").ToString
                Else
                    FormEmpEmailDet.id = FormEmpEmail.GVEmail.GetFocusedRowCellValue("id_other_email").ToString
                End If

                FormEmpEmailDet.type = type

                FormEmpEmailDet.ShowDialog()
            ElseIf formName = "FormEmpDP" Then
                'Leave employee
                If FormEmpDP.GVLeave.RowCount > 0 Then
                    FormEmpDPDet.id_emp_dp = FormEmpDP.GVLeave.GetFocusedRowCellValue("id_dp").ToString
                    FormEmpDPDet.ShowDialog()
                End If
            ElseIf formName = "FormEmpChSchedule" Then
                'Leave
                FormEmpChScheduleDet.id_ch_sch = FormEmpChSchedule.BGVChangeSch.GetFocusedRowCellValue("id_emp_ch_schedule").ToString
                FormEmpChScheduleDet.ShowDialog()
            ElseIf formName = "FormEmpAttnAssign" Then
                'Propose schedule with approval
                FormEmpAttnAssignDet.id_emp_assign_sch = FormEmpAttnAssign.GVAttnAssign.GetFocusedRowCellValue("id_assign_sch").ToString
                FormEmpAttnAssignDet.ShowDialog()
            ElseIf formName = "FormProductionFinalClear" Then
                If FormProductionFinalClear.XTCQCReport.SelectedTabPageIndex = 0 Then
                    'list entry
                    FormProductionFinalClearDet.action = "upd"
                    FormProductionFinalClearDet.id_prod_fc = FormProductionFinalClear.GVFinalClear.GetFocusedRowCellValue("id_prod_fc").ToString
                    FormProductionFinalClearDet.ShowDialog()
                ElseIf FormProductionFinalClear.XTCQCReport.SelectedTabPageIndex = 1 Then
                    'list order
                ElseIf FormProductionFinalClear.XTCQCReport.SelectedTabPageIndex = 2 Then
                    'propose summary
                    FormProductionFinalClearSummary.id_prod_fc_sum = FormProductionFinalClear.GVSum.GetFocusedRowCellValue("id_prod_fc_sum").ToString
                    FormProductionFinalClearSummary.is_vew = "0"
                    FormProductionFinalClearSummary.ShowDialog()
                End If
            ElseIf formName = "FormProductionAssembly" Then
                FormProductionAssemblySingle.action = "upd"
                FormProductionAssemblySingle.id_prod_ass = FormProductionAssembly.GVData.GetFocusedRowCellValue("id_prod_ass").ToString
                FormProductionAssemblySingle.ShowDialog()
            ElseIf formName = "FormMasterCargoRate" Then
                FormMasterCargoRateAdd.id_cargo_rate = FormMasterCargoRate.GVCargoRate.GetFocusedRowCellValue("id_cargo_rate").ToString
                FormMasterCargoRateAdd.ShowDialog()
            ElseIf formName = "FormWHDelEmpty" Then
                FormWHDelEmptyDet.id_wh_del_empty = FormWHDelEmpty.GVDel.GetFocusedRowCellValue("id_wh_del_empty").ToString
                FormWHDelEmptyDet.ShowDialog()
            ElseIf formName = "FormDeliveryCargo" Then
                FormDeliveryCargoDet.id_awbill = FormDeliveryCargo.GVDeliverySlip.GetFocusedRowCellValue("id_awbill").ToString
                FormDeliveryCargoDet.ShowDialog()
            ElseIf formName = "FormEmpUniPeriod" Then
                FormEmpUniPeriodDet.action = "upd"
                FormEmpUniPeriodDet.id_emp_uni_period = FormEmpUniPeriod.GVUni.GetFocusedRowCellValue("id_emp_uni_period").ToString
                FormEmpUniPeriodDet.ShowDialog()
            ElseIf formName = "FormDepartementSub" Then
                FormDepartementSubDet.id_subdept = FormDepartementSub.GVDepartment.GetFocusedRowCellValue("id_departement_sub").ToString
                FormDepartementSubDet.ShowDialog()
            ElseIf formName = "FormEmpPayroll" Then
                FormEmpPayrollPeriode.id_payroll = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
                FormEmpPayrollPeriode.ShowDialog()
            ElseIf formName = "FormEmpLeaveCut" Then
                FormEmpLeaveCutDet.id_leave_cut = FormEmpLeaveCut.GVPayrollPeriode.GetFocusedRowCellValue("id_leave_cut").ToString
                FormEmpLeaveCutDet.ShowDialog()
            ElseIf formName = "FormProdOverMemo" Then
                FormProdOverMemoDet.id_prod_over_memo = FormProdOverMemo.GVMemo.GetFocusedRowCellValue("id_prod_over_memo").ToString
                FormProdOverMemoDet.action = "upd"
                FormProdOverMemoDet.ShowDialog()
            ElseIf formName = "FormEmpUniList" Then
                FormEmpUniListDet.id_emp_uni_design = FormEmpUniList.GVData.GetFocusedRowCellValue("id_emp_uni_design").ToString
                FormEmpUniListDet.ShowDialog()
            ElseIf formName = "FormMasterAssetCategory" Then
                FormMasterAssetCategoryDetail.id_asset_cat = FormMasterAssetCategory.GVAssetCat.GetFocusedRowCellValue("id_asset_cat").ToString
                FormMasterAssetCategoryDetail.ShowDialog()
            ElseIf formName = "FormMasterAsset" Then
                FormMasterAssetDetail.id_asset = FormMasterAsset.GVAsset.GetFocusedRowCellValue("id_asset").ToString
                FormMasterAssetDetail.ShowDialog()
            ElseIf formName = "FormAssetPO" Then
                FormAssetPODet.id_po = FormAssetPO.GVPOList.GetFocusedRowCellValue("id_asset_po").ToString
                FormAssetPODet.ShowDialog()
            ElseIf formName = "FormAssetRec" Then
                FormAssetRecDet.id_rec = FormAssetRec.GVRecList.GetFocusedRowCellValue("id_asset_rec").ToString
                FormAssetRecDet.ShowDialog()
            ElseIf formName = "FormEmpUniExpense" Then
                'detail
                FormEmpUniExpenseDet.id_emp_uni_ex = FormEmpUniExpense.GVData.GetFocusedRowCellValue("id_emp_uni_ex").ToString
                FormEmpUniExpenseDet.action = "upd"
                FormEmpUniExpenseDet.ShowDialog()
            ElseIf formName = "FormBudgetRevPropose" Then
                If FormBudgetRevPropose.XTCRev.SelectedTabPageIndex = 1 Then
                    FormBudgetRevProposeDet.id = FormBudgetRevPropose.GVRev.GetFocusedRowCellValue("id_b_revenue_propose").ToString
                    FormBudgetRevProposeDet.ShowDialog()
                ElseIf FormBudgetRevPropose.XTCRev.SelectedTabPageIndex = 2 Then
                    FormBudgetRevenueRevisionDet.id = FormBudgetRevPropose.GVRevision.GetFocusedRowCellValue("id_b_revenue_revision").ToString
                    FormBudgetRevenueRevisionDet.ShowDialog()
                Else

                End If
            ElseIf formName = "FormItemCatPropose" Then
                FormItemCatProposeDet.id = FormItemCatPropose.GVData.GetFocusedRowCellValue("id_item_cat_propose").ToString
                FormItemCatProposeDet.ShowDialog()
            ElseIf formName = "FormItemCatMapping" Then
                FormItemCatMappingDet.id = FormItemCatMapping.GVPropose.GetFocusedRowCellValue("id_item_coa_propose").ToString
                FormItemCatMappingDet.ShowDialog()
            ElseIf formName = "FormPurcItem" Then
                FormPurcItemDet.id_item = FormPurcItem.GVItem.GetFocusedRowCellValue("id_item").ToString
                FormPurcItemDet.ShowDialog()
            ElseIf formName = "FormBudgetExpensePropose" Then
                FormBudgetExpenseProposeDet.id = FormBudgetExpensePropose.GVData.GetFocusedRowCellValue("id_b_expense_propose").ToString
                FormBudgetExpenseProposeDet.action = "upd"
                FormBudgetExpenseProposeDet.ShowDialog()
            ElseIf formName = "FormPurcReq" Then
                FormPurcReqDet.id_req = FormPurcReq.GVPurcReq.GetFocusedRowCellValue("id_purc_req").ToString
                FormPurcReqDet.ShowDialog()
            ElseIf formName = "FormBudgetExpenseRevision" Then
                FormBudgetExpenseRevisionDet.id = FormBudgetExpenseRevision.GVData.GetFocusedRowCellValue("id_b_expense_revision").ToString
                FormBudgetExpenseRevisionDet.ShowDialog()
            ElseIf formName = "FormPurcOrder" Then
                FormPurcOrderDet.id_po = FormPurcOrder.GVPO.GetFocusedRowCellValue("id_purc_order").ToString
                FormPurcOrderDet.ShowDialog()
            ElseIf formName = "FormProdDemandRev" Then
                FormProdDemandRevDet.id = FormProdDemandRev.GVData.GetFocusedRowCellValue("id_prod_demand_rev").ToString
                FormProdDemandRevDet.ShowDialog()
            ElseIf formName = "FormReportMarkCancelList" Then
                FormReportMarkCancel.id_report_mark_cancel = FormReportMarkCancelList.GVListCancel.GetFocusedRowCellValue("id_report_mark_cancel").ToString
                FormReportMarkCancel.ShowDialog()
            ElseIf formName = "FormPurcReceive" Then
                If FormPurcReceive.XTCRec.SelectedTabPageIndex = 1 Then
                    FormPurcReceiveDet.action = "upd"
                    FormPurcReceiveDet.id = FormPurcReceive.GVReceive.GetFocusedRowCellValue("id_purc_rec").ToString
                    FormPurcReceiveDet.ShowDialog()
                ElseIf FormPurcReceive.XTCRec.SelectedTabPageIndex = 2 Then
                    FormPurcReceiveFOCDet.action = "upd"
                    FormPurcReceiveFOCDet.id = FormPurcReceive.GVReceiveFOC.GetFocusedRowCellValue("id_purc_rec_foc").ToString
                    FormPurcReceiveFOCDet.ShowDialog()
                End If
            ElseIf formName = "FormPurcReturn" Then
                FormPurchaseReturnDet.action = "upd"
                FormPurchaseReturnDet.id = FormPurcReturn.GVReturn.GetFocusedRowCellValue("id_purc_return").ToString
                FormPurchaseReturnDet.ShowDialog()
            ElseIf formName = "FormProductionClaimReturn" Then
                FormProductionClaimReturnDet.action = "upd"
                FormProductionClaimReturnDet.id = FormProductionClaimReturn.GVData.GetFocusedRowCellValue("id_prod_claim_return").ToString
                FormProductionClaimReturnDet.ShowDialog()
            ElseIf formName = "FormItemReq" Then
                FormItemReqDet.action = "upd"
                FormItemReqDet.id = FormItemReq.GVData.GetFocusedRowCellValue("id_item_req").ToString
                FormItemReqDet.ShowDialog()
            ElseIf formName = "FormItemDel" Then
                FormItemDelDetail.action = "upd"
                FormItemDelDetail.id = FormItemDel.GVDelivery.GetFocusedRowCellValue("id_item_del").ToString
                FormItemDelDetail.ShowDialog()
            ElseIf formName = "FormItemExpense" Then
                FormItemExpenseDet.action = "upd"
                FormItemExpenseDet.id = FormItemExpense.GVData.GetFocusedRowCellValue("id_item_expense").ToString
                FormItemExpenseDet.ShowDialog()
            ElseIf formName = "FormCashAdvance" Then
                FormCashAdvanceDet.id_ca = FormCashAdvance.GVListOpen.GetFocusedRowCellValue("id_cash_advance").ToString
                FormCashAdvanceDet.ShowDialog()
            ElseIf formName = "FormSalesReturnRec" Then
                FormSalesReturnRecDet.id = FormSalesReturnRec.GVList.GetFocusedRowCellValue("id_sales_return_rec").ToString
                FormSalesReturnRecDet.ShowDialog()
            ElseIf formName = "FormDeptHeadSurvey" Then
                FormDeptHeadSurveyDet.id_period = FormDeptHeadSurvey.GVListPeriod.GetFocusedRowCellValue("id_question_depthead_period").ToString
                FormDeptHeadSurveyDet.ShowDialog()
            ElseIf formName = "FormSampleExpense" Then
                FormSampleExpenseDet.id_purc = FormSampleExpense.GVPurchaseList.GetFocusedRowCellValue("id_sample_po_mat").ToString
                FormSampleExpenseDet.ShowDialog()
            ElseIf formName = "FormEmpOvertime" Then
                If FormEmpOvertime.XTCPropose.SelectedTabPage.Name = "XTPByEmployee" Then
                    FormEmpOvertimeDet.id = FormEmpOvertime.GVProposeEmployee.GetFocusedRowCellValue("id_ot")
                    FormEmpOvertimeDet.is_hrd = FormEmpOvertime.is_hrd

                    FormEmpOvertimeDet.Show()
                Else
                    FormEmpOvertimeDet.id = FormEmpOvertime.GVOvertime.GetFocusedRowCellValue("id_ot")
                    FormEmpOvertimeDet.is_hrd = FormEmpOvertime.is_hrd

                    FormEmpOvertimeDet.Show()
                End If
            ElseIf formName = "FormSamplePurcClose" Then
                FormSamplePurcCloseDet.id_close = FormSamplePurcClose.GVListClose.GetFocusedRowCellValue("id_sample_purc_close")
                FormSamplePurcCloseDet.ShowDialog()
            ElseIf formName = "FormFGLinePlan" Then
                FormFGLinePlanDet.action = "upd"
                FormFGLinePlanDet.id = FormFGLinePlan.GVData.GetFocusedRowCellValue("id_fg_line_plan").ToString
                FormFGLinePlanDet.ShowDialog()
            ElseIf formName = "FormWorkOrder" Then
                FormWorkOrderDet.id_wo = FormWorkOrder.GVWorkOrder.GetFocusedRowCellValue("id_work_order")
                FormWorkOrderDet.ShowDialog()
            ElseIf formName = "FormSalesTargetPropose" Then
                If FormSalesTargetPropose.XTCPropose.SelectedTabPageIndex = 0 Then
                    FormSalesTargetProposeDet.id = FormSalesTargetPropose.GVData.GetFocusedRowCellValue("id_sales_trg_propose").ToString
                    FormSalesTargetProposeDet.ShowDialog()
                ElseIf FormSalesTargetPropose.XTCPropose.SelectedTabPageIndex = 1 Then

                End If
            ElseIf formName = "FormProposeEmpSalary" Then
                'propose employee salary
                If FormProposeEmpSalary.GVList.RowCount > 0 Then
                    FormProposeEmpSalaryDet.id_employee_sal_pps = FormProposeEmpSalary.GVList.GetFocusedRowCellValue("id_employee_sal_pps")
                    FormProposeEmpSalaryDet.is_duplicate = "-1"
                    FormProposeEmpSalaryDet.ShowDialog()
                End If
            ElseIf formName = "FormItemSubCat" Then
                'purchase category
                FormItemSubCatDet.id_sub_cat = FormItemSubCat.GVPurchaseCategory.GetFocusedRowCellValue("id_item_cat_detail").ToString
                FormItemSubCatDet.ShowDialog()
            ElseIf formName = "FormItemCatMain" Then
                'main category
                FormItemCatMainDet.id_propose = FormItemCatMain.GVData.GetFocusedRowCellValue("id_item_cat_main_pps").ToString
                FormItemCatMainDet.ShowDialog()
            ElseIf formName = "FormVoucherPOS" Then
                'Voucher POS
                FormVoucherPOSDet.action = "upd"
                FormVoucherPOSDet.id = FormVoucherPOS.GVData.GetFocusedRowCellValue("id_pos_voucher").ToString
                FormVoucherPOSDet.ShowDialog()
            ElseIf formName = "FormPromoRules" Then
                'Promo Rulese
                FormPromoRulesDet.action = "upd"
                FormPromoRulesDet.id = FormPromoRules.GVRules.GetFocusedRowCellValue("id_rules").ToString
                FormPromoRulesDet.ShowDialog()
            ElseIf formName = "FormEmpInputAttendance" Then
                'input attendance
                FormEmpInputAttendanceDet.id = FormEmpInputAttendance.GVList.GetFocusedRowCellValue("id_emp_attn_input").ToString
                FormEmpInputAttendanceDet.ShowDialog()
            ElseIf formName = "FormBankDeposit" Then
                FormBankDepositDet.id_deposit = FormBankDeposit.GVList.GetFocusedRowCellValue("id_rec_payment").ToString
                FormBankDepositDet.ShowDialog()
            ElseIf formName = "FormBuktiPickup" Then
                Try
                    FormBuktiPickupDet.id_pickup = FormBuktiPickup.GVList.GetFocusedRowCellValue("id_pickup").ToString
                    FormBuktiPickupDet.ShowDialog()
                Catch ex As Exception
                End Try
            ElseIf formName = "FormEmpBPJSKesehatan" Then
                FormEmpBPJSKesehatanDet.id = FormEmpBPJSKesehatan.GVList.GetFocusedRowCellValue("id_pay_bpjs_kesehatan").ToString
                FormEmpBPJSKesehatanDet.is_approve = FormEmpBPJSKesehatan.is_approve

                FormEmpBPJSKesehatanDet.ShowDialog()
            ElseIf formName = "FormPopUpCompGroup" Then
                FormMasterCompGroupDet.id_comp_group = FormPopUpCompGroup.GVGroupComp.GetFocusedRowCellValue("id_comp_group").ToString
                FormMasterCompGroupDet.ShowDialog()
            ElseIf formName = "FormMailManage" Then
                If FormMailManage.XTCMailManage.SelectedTabPageIndex = 0 Then
                    FormMailManageDet.action = "upd"
                    FormMailManageDet.id = FormMailManage.GVData.GetFocusedRowCellValue("id_mail_manage").ToString
                    FormMailManageDet.rmt = FormMailManage.GVData.GetFocusedRowCellValue("report_mark_type").ToString
                    FormMailManageDet.ShowDialog()
                End If
            ElseIf formName = "FormAccountingJournalAdj" Then
                FormAccountingJournalAdjDet.id_trans_adj = FormAccountingJournalAdj.GVAccTrans.GetFocusedRowCellValue("id_acc_trans_adj").ToString
                FormAccountingJournalAdjDet.ShowDialog()
            ElseIf formName = "FormAREvalScheduke" Then
                FormAREvalScheduleDet.id = FormAREvalScheduke.GVData.GetFocusedRowCellValue("id_ar_eval_setup_date").ToString
                FormAREvalScheduleDet.action = "upd"
                FormAREvalScheduleDet.ShowDialog()
            ElseIf formName = "FormDelayPayment" Then
                If FormDelayPayment.GVData.RowCount > 0 And FormDelayPayment.GVData.FocusedRowHandle >= 0 Then
                    FormDelayPaymentDet.id = FormDelayPayment.GVData.GetFocusedRowCellValue("id_propose_delay_payment").ToString
                    FormDelayPaymentDet.ShowDialog()
                End If
            ElseIf formName = "FormDelManifest" Then
                Try
                    FormDelManifestDet.id_del_manifest = FormDelManifest.GVList.GetFocusedRowCellValue("id_del_manifest").ToString
                    FormDelManifestDet.ShowDialog()
                Catch ex As Exception
                End Try
            ElseIf formName = "FormFollowUpAR" Then
                If FormFollowUpAR.XTCAR.SelectedTabPageIndex = 0 And FormFollowUpAR.GVData.RowCount > 0 And FormFollowUpAR.GVData.FocusedRowHandle >= 0 Then
                    FormFollowUpARDetail.action = "upd"
                    FormFollowUpARDetail.id = FormFollowUpAR.GVData.GetFocusedRowCellValue("id_follow_up_ar").ToString
                    FormFollowUpARDetail.ShowDialog()
                ElseIf FormFollowUpAR.XTCAR.SelectedTabPageIndex = 1 And FormFollowUpAR.GVActive.RowCount > 0 And FormFollowUpAR.GVActive.FocusedRowHandle >= 0 Then
                    FormFollowUpARDetail.action = "upd"
                    FormFollowUpARDetail.id = FormFollowUpAR.GVActive.GetFocusedRowCellValue("id_follow_up_ar").ToString
                    FormFollowUpARDetail.ShowDialog()
                End If
            ElseIf formName = "FormEmpUniCreditNote" Then
                Try
                    FormEmpUniCreditNoteDet.id_emp_uni_ex = FormEmpUniCreditNote.GVData.GetFocusedRowCellValue("id_emp_uni_ex").ToString
                    FormEmpUniCreditNoteDet.ShowDialog()
                Catch ex As Exception
                End Try
            ElseIf formName = "FormPaymentMissing" Then
                FormPaymentMissingDet.id_missing_payment = FormPaymentMissing.GridViewMissing.GetFocusedRowCellValue("id_missing_payment").ToString
                FormPaymentMissingDet.ShowDialog()
            ElseIf formName = "FormBudgetProdDemand" Then
                If FormBudgetProdDemand.XTCBudget.SelectedTabPageIndex = 1 Then
                    If FormBudgetProdDemand.GVProposed.RowCount > 0 And FormBudgetProdDemand.GVProposed.FocusedRowHandle >= 0 Then
                        FormBudgetProdDemandDet.id = FormBudgetProdDemand.GVProposed.GetFocusedRowCellValue("id_b_prod_demand_propose").ToString
                        FormBudgetProdDemandDet.ShowDialog()
                    End If
                End If
            ElseIf formName = "FormRetOlStore" Then
                If FormRetOlStore.XTCData.SelectedTabPageIndex = 0 Then
                    FormRetOLStoreDet.id = FormRetOlStore.GVData.GetFocusedRowCellValue("id_ol_store_ret").ToString
                    FormRetOLStoreDet.action = "upd"
                    FormRetOLStoreDet.ShowDialog()
                End If
            ElseIf formName = "FormRefundOLStore" Then
                If FormRefundOLStore.XTCData.SelectedTabPageIndex = 0 Then
                    FormRefundOLStoreDet.id = FormRefundOLStore.GVData.GetFocusedRowCellValue("id_ol_store_refund").ToString
                    FormRefundOLStoreDet.action = "upd"
                    FormRefundOLStoreDet.ShowDialog()
                End If
            ElseIf formName = "FormPromoCollection" Then
                FormPromoCollectionDet.action = "upd"
                FormPromoCollectionDet.id = FormPromoCollection.GVData.GetFocusedRowCellValue("id_ol_promo_collection").ToString
                FormPromoCollectionDet.ShowDialog()
            ElseIf formName = "FormExternalUser" Then
                FormExternalUserDet.id_user = FormExternalUser.GVExternalUser.GetFocusedRowCellValue("id_user").ToString
                FormExternalUserDet.ShowDialog()
            ElseIf formName = "FormMasterStore" Then
                FormMasterStoreDet.id_store = FormMasterStore.GVMasterStore.GetFocusedRowCellValue("id_store").ToString
                FormMasterStoreDet.ShowDialog()
            ElseIf formName = "FormSalesBranch" Then
                FormSalesBranchDet.id = FormSalesBranch.GVData.GetFocusedRowCellValue("id_sales_branch").ToString
                FormSalesBranchDet.action = "upd"
                FormSalesBranchDet.ShowDialog()
            ElseIf formName = "FormMasterDesignFabrication" Then
                Try
                    FormMasterDesignFabricationDet.id_design_fabrication = FormMasterDesignFabrication.GVFabrication.GetFocusedRowCellValue("id_design_fabrication").ToString
                    FormMasterDesignFabricationDet.ShowDialog()
                Catch ex As Exception
                End Try
            ElseIf formName = "FormMaterialRequisition" Then
                FormProductionMRS.id_pop_up = "1"

                FormProductionMRS.id_prod_order = FormMaterialRequisition.GVMRS.GetFocusedRowCellValue("id_prod_order").ToString
                FormProductionMRS.id_mrs = FormMaterialRequisition.GVMRS.GetFocusedRowCellValue("id_prod_order_mrs").ToString
                FormProductionMRS.id_comp_req_from = FormMaterialRequisition.GVMRS.GetFocusedRowCellValue("id_comp_name_req_from").ToString
                FormProductionMRS.id_comp_req_to = FormMaterialRequisition.GVMRS.GetFocusedRowCellValue("id_comp_name_req_to").ToString
                FormProductionMRS.TEMRSNumber.Text = FormMaterialRequisition.GVMRS.GetFocusedRowCellValue("prod_order_mrs_number").ToString
                FormProductionMRS.TEWONumber.Text = FormMaterialRequisition.GVMRS.GetFocusedRowCellValue("prod_order_wo_number").ToString
                FormProductionMRS.TEPONumber.Text = FormMaterialRequisition.GVMRS.GetFocusedRowCellValue("prod_order_number").ToString
                FormProductionMRS.TEDesign.Text = FormMaterialRequisition.GVMRS.GetFocusedRowCellValue("design_display_name").ToString
                FormProductionMRS.TEDesignCode.Text = FormMaterialRequisition.GVMRS.GetFocusedRowCellValue("design_code").ToString
                FormProductionMRS.ShowDialog()
            ElseIf formName = "FormMailManageReturn" Then
                FormMailManageReturnDet.action = "upd"
                FormMailManageReturnDet.id = FormMailManageReturn.GVData.GetFocusedRowCellValue("id_mail_manage").ToString
                FormMailManageReturnDet.rmt = "45"
                FormMailManageReturnDet.ShowDialog()
            ElseIf formName = "FormAdditionalCost" Then
                FormAdditionalCostDet.id_pps = "upd"
                FormAdditionalCostDet.ShowDialog()
            ElseIf formName = "FormSalesReturnOrderMail" Then
                FormSalesReturnOrderMailDet.id_mail_3pl = FormSalesReturnOrderMail.GVDetail.GetFocusedRowCellValue("id_mail_3pl").ToString
                FormSalesReturnOrderMailDet.ShowDialog()
            ElseIf formName = "FormInbound3PL" Then
                FormInboundAWB.id_awb_inbound = FormInbound3PL.GVAwb.GetFocusedRowCellValue("id_inbound_awb").ToString
                FormInboundAWB.ShowDialog()
            ElseIf formName = "FormReturnNote" Then
                FormReturnNoteDet.id_return_note = FormReturnNote.GVAwb.GetFocusedRowCellValue("id_return_note").ToString
                FormReturnNoteDet.ShowDialog()
            ElseIf formName = "FormScanReturn" Then
                If FormScanReturn.XTCScanReturn.SelectedTabPageIndex = 0 Then
                    FormScanReturnDet.id_scan_return = FormScanReturn.GVAwb.GetFocusedRowCellValue("id_scan_return").ToString
                    FormScanReturnDet.ShowDialog()
                Else
                    FormScanReturnBAP.id_bap = FormScanReturn.GVBAP.GetFocusedRowCellValue("id_scan_return_bap").ToString
                    FormScanReturnBAP.ShowDialog()
                End If
            ElseIf formName = "FormCompanyEmailMapping" Then
                FormMasterCompanyContact.id_company = FormCompanyEmailMapping.GV3PL.GetFocusedRowCellValue("id_comp").ToString
                FormMasterCompanyContact.ShowDialog()
            ElseIf formName = "FormAdjustmentOG" Then
                FormAdjustmentOGDet.id_adjustment = FormAdjustmentOG.GVList.GetFocusedRowCellValue("id_adjustment").ToString
                FormAdjustmentOGDet.ShowDialog()
            ElseIf formName = "FormOLReturnRefuse" Then
                If FormOLReturnRefuse.XTCData.SelectedTabPageIndex = 0 Then
                    If FormOLReturnRefuse.GVData.RowCount > 0 And FormOLReturnRefuse.GVData.FocusedRowHandle >= 0 Then
                        Cursor = Cursors.WaitCursor
                        FormOLReturnRefuseDet.action = "upd"
                        FormOLReturnRefuseDet.id = FormOLReturnRefuse.GVData.GetFocusedRowCellValue("id_return_refuse").ToString
                        FormOLReturnRefuseDet.ShowDialog()
                        Cursor = Cursors.Default
                    End If
                ElseIf FormOLReturnRefuse.XTCData.SelectedTabPageIndex = 1 Then
                    'no action
                End If
            ElseIf formName = "FormPricePolicyCode" Then
                FormPricePolicyCodeDet.id = FormPricePolicyCode.GVData.GetFocusedRowCellValue("id_code_detail").ToString
                FormPricePolicyCodeDet.ShowDialog()
            ElseIf formName = "FormProposePriceMKD" Then
                FormProposePriceMKDDet.id = FormProposePriceMKD.GVSummary.GetFocusedRowCellValue("id_pp_change").ToString
                FormProposePriceMKDDet.action = "upd"
                FormProposePriceMKDDet.ShowDialog()
            ElseIf formName = "FormOGTransfer" Then
                FormOGTransferDet.id = FormOGTransfer.GVOGTransfer.GetFocusedRowCellValue("id_og_transfer").ToString
                FormOGTransferDet.ShowDialog()
            ElseIf formName = "FormAWBOther" Then
                FormAWBOtherDet.id = FormAWBOther.GVAWB.GetFocusedRowCellValue("id_awb_office").ToString
                FormAWBOtherDet.ShowDialog()
            ElseIf formName = "FormSNIppsBudget" Then
                FormSNIppsDet.id_pps = FormSNIppsBudget.GVList.GetFocusedRowCellValue("id_sni_pps").ToString
                FormSNIppsDet.ShowDialog()
            ElseIf formName = "FormSNISerahTerima" Then
                FormSNISerahTerimaDet.id = FormSNISerahTerima.GVList.GetFocusedRowCellValue("id_serah_terima").ToString
                FormSNISerahTerimaDet.ShowDialog()
            ElseIf formName = "FormStockTakePartial" Then
                FormStockTakePartialDet.id = FormStockTakePartial.GVData.GetFocusedRowCellValue("id_st_store_partial").ToString
                FormStockTakePartialDet.ShowDialog()
            ElseIf formName = "FormSNIRealisasi" Then
                FormSNIRealisasiDet.id = FormSNIRealisasi.GVRealisasi.GetFocusedRowCellValue("id_sni_realisasi").ToString
                FormSNIRealisasiDet.ShowDialog()
            ElseIf formName = "FormSNIQC" Then
                If FormSNIQC.XTCInOut.SelectedTabPageIndex = 0 Then
                    'out
                    If FormSNIQC.GVSNIOut.RowCount > 0 Then
                        FormSNIOut.id = FormSNIQC.GVSNIOut.GetFocusedRowCellValue("id_qc_sni_out").ToString
                        FormSNIOut.ShowDialog()
                    End If
                Else
                    'in
                    If FormSNIQC.GVSNIIn.RowCount > 0 Then
                        FormSNIIn.id = FormSNIQC.GVSNIIn.GetFocusedRowCellValue("id_qc_sni_in").ToString
                        FormSNIIn.ShowDialog()
                    End If
                End If
            ElseIf formName = "FormSNIWH" Then
                If FormSNIWH.XTCInOut.SelectedTabPageIndex = 0 Then
                    'rec new
                    If FormSNIWH.GVSNIWaitRec.RowCount > 0 Then
                        FormSNIOut.id = FormSNIWH.GVSNIWaitRec.GetFocusedRowCellValue("id_qc_sni_out").ToString
                        FormSNIOut.is_new = True
                        FormSNIOut.is_rec_wh = True
                        FormSNIOut.ShowDialog()
                    End If
                ElseIf FormSNIWH.XTCInOut.SelectedTabPageIndex = 1 Then
                    'rec list
                    If FormSNIWH.GVRecList.RowCount > 0 Then
                        FormSNIOut.id = FormSNIWH.GVRecList.GetFocusedRowCellValue("id_qc_sni_out").ToString
                        FormSNIOut.is_new = False
                        FormSNIOut.is_rec_wh = True
                        FormSNIOut.ShowDialog()
                    End If
                ElseIf FormSNIWH.XTCInOut.SelectedTabPageIndex = 2 Then
                    'del new
                    If FormSNIWH.GVWaitDel.RowCount > 0 Then
                        FormSNIOut.id = FormSNIWH.GVWaitDel.GetFocusedRowCellValue("id_qc_sni_out").ToString
                        FormSNIOut.is_new = True
                        FormSNIOut.is_del_wh = True
                        FormSNIOut.ShowDialog()
                    End If
                ElseIf FormSNIWH.XTCInOut.SelectedTabPageIndex = 3 Then
                    'del list
                    If FormSNIWH.GVDelList.RowCount > 0 Then
                        FormSNIOut.id = FormSNIWH.GVDelList.GetFocusedRowCellValue("id_qc_sni_out").ToString
                        FormSNIOut.is_new = False
                        FormSNIOut.is_del_wh = True
                        FormSNIOut.ShowDialog()
                    End If
                End If
            ElseIf formName = "FormPreCalFGPO" Then
                If FormPreCalFGPO.GVPreCal.RowCount > 0 Then
                    FormPreCalFGPODet.id = FormPreCalFGPO.GVPreCal.GetFocusedRowCellValue("id_pre_cal_fgpo").ToString
                    FormPreCalFGPODet.ShowDialog()
                End If
            ElseIf formName = "FormStockTakePropose" Then
                FormStockTakeProposeDet.id_st_store_propose = FormStockTakePropose.GVData.GetFocusedRowCellValue("id_st_store_propose").ToString
                FormStockTakeProposeDet.ShowDialog()
            ElseIf formName = "FormPrepaidExpense" Then
                FormPrepaidExpenseDet.id = FormPrepaidExpense.GVData.GetFocusedRowCellValue("id_prepaid_expense").ToString
                FormPrepaidExpenseDet.ShowDialog()
            ElseIf formName = "FormPromoZalora" Then
                FormPromoZalora.viewDetail()
            ElseIf formName = "FormProposePromo" Then
                FormProposePromoDet.id_propose_promo = FormProposePromo.GVPromo.GetFocusedRowCellValue("id_propose_promo").ToString
                FormProposePromoDet.ShowDialog()
            ElseIf formName = "FormRetExos" Then
                FormRetExos.viewDetail()
            ElseIf formName = "FormDisableExos" Then
                FormDisableExos.viewDetail()
            ElseIf formName = "FormEOSChange" Then
                FormEOSChange.viewDetail()
            ElseIf formName = "FormEts" Then
                FormEts.viewDetail()
            ElseIf formName = "FormBSP" Then
                FormBSP.viewDetail()
            ElseIf formName = "FormDeviden" Then
                FormDevidenDet.id = FormDeviden.GVData.GetFocusedRowCellValue("id_deviden").ToString
                FormDevidenDet.ShowDialog()
            Else
                RPSubMenu.Visible = False
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    'Delete Data
    Private Sub BBDelete_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBDelete.ItemClick
        Dim confirm As DialogResult
        Dim query As String

        If formName = "FormMasterArea" Then
            If FormMasterArea.XTCArea.SelectedTabPageIndex = 0 Then
                'country
                confirm = XtraMessageBox.Show("Are you sure want to delete this country?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                Dim id_country As String = FormMasterArea.GVCountry.GetFocusedRowCellDisplayText("id_country").ToString
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_m_country WHERE id_country = '{0}'", id_country)
                        execute_non_query(query, True, "", "", "", "")
                        FormMasterArea.view_country()
                    Catch ex As Exception
                        XtraMessageBox.Show("This country already used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    Cursor = Cursors.Default
                End If
            ElseIf FormMasterArea.XTCArea.SelectedTabPageIndex = 1 Then
                'region
                confirm = XtraMessageBox.Show("Are you sure want to delete this region?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                Dim id_region As String = FormMasterArea.GVRegion.GetFocusedRowCellDisplayText("id_region").ToString
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_m_region WHERE id_region = '{0}'", id_region)
                        execute_non_query(query, True, "", "", "", "")
                        FormMasterArea.view_region(FormMasterArea.GVCountry.GetFocusedRowCellDisplayText("id_country").ToString)
                    Catch ex As Exception
                        XtraMessageBox.Show("This region already used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    Cursor = Cursors.Default
                End If
            ElseIf FormMasterArea.XTCArea.SelectedTabPageIndex = 2 Then
                'state
                confirm = XtraMessageBox.Show("Are you sure want to delete this state?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                Dim id_state As String = FormMasterArea.GVState.GetFocusedRowCellDisplayText("id_state").ToString
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_m_state WHERE id_state = '{0}'", id_state)
                        execute_non_query(query, True, "", "", "", "")
                        FormMasterArea.view_state(FormMasterArea.GVRegion.GetFocusedRowCellDisplayText("id_region").ToString)
                    Catch ex As Exception
                        XtraMessageBox.Show("This state already used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    Cursor = Cursors.Default
                End If
            ElseIf FormMasterArea.XTCArea.SelectedTabPageIndex = 3 Then
                'city
                confirm = XtraMessageBox.Show("Are you sure want to delete this city?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                Dim id_city As String = FormMasterArea.GVCity.GetFocusedRowCellDisplayText("id_city").ToString
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_m_city WHERE id_city = '{0}'", id_city)
                        execute_non_query(query, True, "", "", "", "")
                        FormMasterArea.view_city(FormMasterArea.GVState.GetFocusedRowCellDisplayText("id_state").ToString)
                    Catch ex As Exception
                        XtraMessageBox.Show("This city already used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    Cursor = Cursors.Default
                End If
            Else
                'kecamatan
                confirm = XtraMessageBox.Show("Are you sure want to delete this sub district (kecamatan)?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                Dim id_kecamatan As String = FormMasterArea.GVKecamatan.GetFocusedRowCellDisplayText("id_sub_district").ToString
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_m_sub_district WHERE id_sub_district = '{0}'", id_kecamatan)
                        execute_non_query(query, True, "", "", "", "")
                        FormMasterArea.view_kecamatan(FormMasterArea.GVCity.GetFocusedRowCellDisplayText("id_city").ToString)
                    Catch ex As Exception
                        XtraMessageBox.Show("This sub district (kecamatan) already used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        ElseIf formName = "FormMasterCompany" Then
            'confirm = XtraMessageBox.Show("Are you sure want to delete this company ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            'Dim id_company As String = FormMasterCompany.GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString

            'If confirm = Windows.Forms.DialogResult.Yes Then
            '    Cursor = Cursors.WaitCursor
            '    'check first if only created
            '    Dim query_check As String = "SELECT c.is_active,c.`id_drawer_def`,rc.`id_wh_rack`,lc.`id_wh_locator` FROM tb_m_comp c
            '                                INNER JOIN tb_m_wh_drawer dr ON dr.`id_wh_drawer`=c.`id_drawer_def`
            '                                INNER JOIN tb_m_wh_rack rc ON rc.`id_wh_rack`=dr.`id_wh_rack`
            '                                INNER JOIN tb_m_wh_locator lc ON lc.`id_wh_locator`=rc.`id_wh_locator`
            '                                WHERE c.id_comp='" & id_company & "'"
            '    Dim dt_check As DataTable = execute_query(query_check, -1, True, "", "", "", "")
            '    If dt_check.Rows(0)("is_active").ToString = "3" Then
            '        Try
            '            query = String.Format("DELETE FROM tb_m_wh_drawer WHERE id_wh_drawer='{1}';
            '                                    DELETE FROM tb_m_wh_rack WHERE id_wh_rack='{2}';
            '                                    DELETE FROM tb_m_wh_locator WHERE id_wh_locator='{3}';
            '                                    DELETE FROM tb_m_comp WHERE id_comp = '{0}'", id_company, dt_check.Rows(0)("id_drawer_def").ToString, dt_check.Rows(0)("id_wh_rack").ToString, dt_check.Rows(0)("id_wh_locator").ToString)
            '            execute_non_query(query, True, "", "", "", "")
            '            FormMasterCompany.view_company()
            '        Catch ex As Exception
            '            errorDelete()
            '        End Try
            '    Else
            '        warningCustom("This company already submitted")
            '    End If
            '    Cursor = Cursors.Default
            'End If
        ElseIf formName = "FormMasterCompanyCategory" Then
            '
            confirm = XtraMessageBox.Show("Are you sure want to delete this company cateogry?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            Dim id_company_category As String = FormMasterCompanyCategory.GVCompanyCategory.GetFocusedRowCellDisplayText("id_comp_cat").ToString

            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    query = String.Format("DELETE FROM tb_m_comp_cat WHERE id_comp_cat = '{0}'", id_company_category)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterCompanyCategory.view_company_category()
                Catch ex As Exception
                    XtraMessageBox.Show("Server Disconnected on delete category company. Please wait a moment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                Cursor = Cursors.Default
            End If
        ElseIf formName = "FormAccounting" Then
            confirm = XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            Dim id_acc As String = FormAccounting.GVAcc.GetFocusedRowCellDisplayText("id_acc").ToString

            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    query = String.Format("DELETE FROM tb_a_acc WHERE id_acc = '{0}'", id_acc)
                    execute_non_query(query, True, "", "", "", "")
                    FormAccounting.view_acc()
                Catch ex As Exception
                    errorDelete()
                End Try
                Cursor = Cursors.Default
            End If
        ElseIf formName = "FormMasterDepartement" Then
            '
            confirm = XtraMessageBox.Show("Are you sure want to delete this departement ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            Dim id_departement As String = FormMasterDepartement.GVDepartment.GetFocusedRowCellDisplayText("id_departement").ToString

            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    query = String.Format("DELETE FROM tb_m_departement WHERE id_departement = '{0}'", id_departement)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterDepartement.view_department()
                Catch ex As Exception
                    errorDelete()
                End Try
                Cursor = Cursors.Default
            End If
        ElseIf formName = "FormMasterRawMaterialCat" Then
            '
            confirm = XtraMessageBox.Show("Are you sure want to delete this data?" & Environment.NewLine & "This action will delete all operation under this data.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    Dim id_mat_cat As String = FormMasterRawMaterialCat.GridViewMasterItemCategory.GetFocusedRowCellDisplayText("id_mat_cat").ToString
                    query = String.Format("DELETE FROM tb_m_mat_cat WHERE id_mat_cat='{0}'", id_mat_cat)
                    execute_non_query(query, True, "", "", "", "")
                    logData("tb_m_mat_cat", 3)
                    FormMasterRawMaterialCat.view_master_item_category()
                Catch ex As Exception
                    errorDelete()
                End Try
                Cursor = Cursors.Default
            End If
        ElseIf formName = "FormMasterItemColor" Then
            '
            confirm = XtraMessageBox.Show("Are you sure want to delete this data?" & Environment.NewLine & "This action will delete all operation under this data.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    Dim id_item_color As String = FormMasterItemSize.GVItemSize.GetFocusedRowCellDisplayText("id_item_color").ToString
                    query = String.Format("DELETE FROM tb_m_item_color WHERE id_item_color='{0}'", id_item_color)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterItemColor.viewMasterItemColor()
                Catch ex As Exception
                    errorConnection()
                End Try
                Cursor = Cursors.Default
            End If
        ElseIf formName = "FormMasterItemSize" Then
            '
            confirm = XtraMessageBox.Show("Are you sure want to delete this data?" & Environment.NewLine & "This action will delete all operation under this data.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    Dim id_item_size As String = FormMasterItemSize.GVItemSize.GetFocusedRowCellDisplayText("id_item_size").ToString
                    query = String.Format("DELETE FROM tb_m_item_size WHERE id_item_size='{0}'", id_item_size)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterItemSize.viewMasterItemSize()
                Catch ex As Exception
                    errorConnection()
                End Try
                Cursor = Cursors.Default
            End If
        ElseIf formName = "FormMasterUser" Then
            confirm = XtraMessageBox.Show("Are you sure want to delete this user ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            Dim id_user As String = FormMasterUser.GVUser.GetFocusedRowCellDisplayText("id_user").ToString

            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    query = String.Format("DELETE FROM tb_m_user WHERE id_user = '{0}'", id_user)
                    execute_non_query(query, True, "", "", "", "")
                    logData("tb_m_user", 3)
                    FormMasterUser.view_user()
                Catch ex As Exception
                    errorDelete()
                End Try
                Cursor = Cursors.Default
            End If
        ElseIf formName = "FormAccess" Then
            If FormAccess.XTCMenuManage.SelectedTabPageIndex = 2 Then 'Delete Role
                confirm = XtraMessageBox.Show("Are you sure want to delete this role ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                Dim id_role As String = FormAccess.GVRole.GetFocusedRowCellDisplayText("id_role").ToString

                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_m_role WHERE id_role = '{0}'", id_role)
                        execute_non_query(query, True, "", "", "", "")
                        logData("tb_m_role", 3)
                        FormAccess.viewRole()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            ElseIf FormAccess.XTCMenuManage.SelectedTabPageIndex = 1 Then 'Delete Menu
                confirm = XtraMessageBox.Show("Are you sure want to delete this menu ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                Dim id_menu As String = FormAccess.GVMenu.GetFocusedRowCellDisplayText("id_menu").ToString

                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_menu WHERE id_menu = '{0}'", id_menu)
                        execute_non_query(query, True, "", "", "", "")
                        logData("tb_menu", 3)
                        FormAccess.viewMenu()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            ElseIf FormAccess.XTCMenuManage.SelectedTabPageIndex = 0 Then 'Delete Form
                If FormAccess.XTCForm.SelectedTabPageIndex = 0 Then 'Form
                    confirm = XtraMessageBox.Show("Are you sure want to delete this form data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    Dim id_form As String = FormAccess.GVForm.GetFocusedRowCellDisplayText("id_form").ToString

                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        Try
                            query = String.Format("DELETE FROM tb_menu_form WHERE id_form = '{0}'", id_form)
                            execute_non_query(query, True, "", "", "", "")
                            logData("tb_menu_form", 3)
                            FormAccess.viewForm()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                        Cursor = Cursors.Default
                    End If
                ElseIf FormAccess.XTCForm.SelectedTabPageIndex = 1 Then 'Form Process/Control
                    Dim is_view As String = FormAccess.GVProcess.GetFocusedRowCellDisplayText("is_view").ToString
                    If is_view = "1" Then
                        XtraMessageBox.Show("Cannot delete, because this data is required process", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        Dim id_form_control As String = FormAccess.GVProcess.GetFocusedRowCellDisplayText("id_form_control").ToString

                        If confirm = Windows.Forms.DialogResult.Yes Then
                            Cursor = Cursors.WaitCursor
                            Try
                                query = String.Format("DELETE FROM tb_menu_form_control WHERE id_form_control = '{0}'", id_form_control)
                                execute_non_query(query, True, "", "", "", "")
                                logData("tb_menu_form_control", 3)
                                FormAccess.viewFormControl()
                            Catch ex As Exception
                                errorDelete()
                            End Try
                            Cursor = Cursors.Default
                        End If
                    End If
                End If
            End If
        ElseIf formName = "FormSeason" Then
            confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                If FormSeason.XTCMainSeason.SelectedTabPageIndex = 0 Then 'delete season internal
                    If FormSeason.XTCSeason.SelectedTabPageIndex = 0 Then  'delete range
                        Try
                            Dim id_range As String = FormSeason.GVRange.GetFocusedRowCellDisplayText("id_range").ToString
                            query = String.Format("DELETE FROM tb_range WHERE id_range='{0}'", id_range)
                            execute_non_query(query, True, "", "", "", "")
                            logData("tb_range", 3)
                            FormSeason.viewRange()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    ElseIf FormSeason.XTCSeason.SelectedTabPageIndex = 1 Then  'delete season
                        Try
                            Dim id_season As String = FormSeason.GVSeason.GetFocusedRowCellDisplayText("id_season").ToString
                            query = String.Format("DELETE FROM tb_season WHERE id_season='{0}'", id_season)
                            execute_non_query(query, True, "", "", "", "")
                            logData("tb_season", 3)
                            FormSeason.viewSeason()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    ElseIf FormSeason.XTCSeason.SelectedTabPageIndex = 2 Then 'delete delivery
                        Try
                            Dim id_delivery As String = FormSeason.GVDelivery.GetFocusedRowCellDisplayText("id_delivery").ToString
                            query = String.Format("DELETE FROM tb_season_delivery WHERE id_delivery='{0}'", id_delivery)
                            execute_non_query(query, True, "", "", "", "")
                            logData("tb_season_delivery", 3)
                            FormSeason.viewDelivery(FormSeason.id_season)
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else 'delete season origin
                    Try
                        Dim id_season_origin As String = FormSeason.GVOrignSeason.GetFocusedRowCellDisplayText("id_season_orign").ToString
                        query = String.Format("DELETE FROM tb_season_orign WHERE id_season_orign = '{0}'", id_season_origin)
                        execute_non_query(query, True, "", "", "", "")
                        logData("tb_season_orign", 3)
                        FormSeason.viewSeasonOrign()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            End If
        ElseIf formName = "FormMasterUOM" Then
            Cursor = Cursors.WaitCursor
            confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm Then
                Try
                    Dim id_uom As String = FormMasterUOM.GVUOM.GetFocusedRowCellDisplayText("id_uom").ToString
                    query = String.Format("DELETE FROM tb_m_uom WHERE id_uom='{0}'", id_uom)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterUOM.viewUOM()
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
            Cursor = Cursors.Default
        ElseIf formName = "FormMasterRawMat" Then
            Cursor = Cursors.WaitCursor
            If FormMasterRawMat.XTCRawMat.SelectedTabPageIndex = 0 Then ' DELETE RAW MAT
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_raw_mat As String = FormMasterRawMat.GVRawMat.GetFocusedRowCellDisplayText("id_raw_mat").ToString
                        query = String.Format("DELETE FROM tb_m_raw_mat WHERE id_raw_mat='{0}'", id_raw_mat)
                        execute_non_query(query, True, "", "", "", "")
                        FormMasterRawMat.viewRawMat()
                    Catch ex As Exception
                        errorConnection()
                    End Try
                End If
            ElseIf FormMasterRawMat.XTCRawMat.SelectedTabPageIndex = 2 Then ' DELETE RAW MAT SUPPLIER
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_raw_mat_supplier As String = FormMasterRawMat.GVSupplier.GetFocusedRowCellDisplayText("id_raw_mat_supplier").ToString
                        query = "DELETE FROM tb_m_raw_mat_supplier WHERE id_raw_mat_supplier ='" + id_raw_mat_supplier + "'"
                        execute_non_query(query, True, "", "", "", "")
                        FormMasterRawMat.viewRawMatSupplier()
                    Catch ex As Exception
                        errorConnection()
                    End Try
                End If
            End If
            Cursor = Cursors.Default
        ElseIf formName = "FormSetupRawMatCode" Then
            Cursor = Cursors.WaitCursor
            confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim id_raw_mat_code As String = FormSetupRawMatCode.GVCodeType.GetFocusedRowCellDisplayText("id_raw_mat_code").ToString
                    query = "DELETE FROM tb_m_raw_mat_code WHERE id_raw_mat_code ='" + id_raw_mat_code + "'"
                    execute_non_query(query, True, "", "", "", "")
                    FormSetupRawMatCode.viewCodeType(1, FormSetupRawMatCode.GCCodeType)
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
            Cursor = Cursors.Default
        ElseIf formName = "FormMasterRawMaterial" Then 'DELETE MASTER RAW MATERIAL
            Cursor = Cursors.WaitCursor
            If FormMasterRawMaterial.XTCMaterialType.SelectedTabPageIndex = 0 Then 'delete raw material type
                confirm = XtraMessageBox.Show("Are you sure want to delete this material type?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_mat As String = FormMasterRawMaterial.GVRawMat.GetFocusedRowCellDisplayText("id_mat").ToString
                        query = "DELETE FROM tb_m_mat WHERE id_mat ='" + id_mat + "'"
                        execute_non_query(query, True, "", "", "", "")
                        logData("tb_m_mat", 3)
                        FormMasterRawMaterial.viewMat()
                    Catch ex As Exception
                        errorConnection()
                    End Try
                End If
            ElseIf FormMasterRawMaterial.XTCMaterialType.SelectedTabPageIndex = 1 Then 'delete raw material detail
                confirm = XtraMessageBox.Show("Are you sure want to delete this material detail?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_mat_det As String = FormMasterRawMaterial.GVMatDetail.GetFocusedRowCellDisplayText("id_mat_det").ToString
                        query = "DELETE FROM tb_m_mat_det WHERE id_mat_det ='" + id_mat_det + "'"
                        execute_non_query(query, True, "", "", "", "")
                        logData("tb_m_mat_det", 3)
                        FormMasterRawMaterial.viewMatDetail()
                    Catch ex As Exception
                        errorConnection()
                    End Try
                End If
            End If
            Cursor = Cursors.Default
        ElseIf formName = "FormMasterOVH" Then
            Cursor = Cursors.WaitCursor
            confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim id_ovh As String = FormMasterOVH.GVOVH.GetFocusedRowCellDisplayText("id_ovh").ToString
                    query = String.Format("DELETE FROM tb_m_ovh WHERE id_ovh='{0}'", id_ovh)
                    execute_non_query(query, True, "", "", "", "")
                    logData("tb_m_ovh", 3)
                    FormMasterOVH.view_ovh()
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
            Cursor = Cursors.Default
        ElseIf formName = "FormProdDemand" Then
            Dim id_report_status As String = FormProdDemand.GVProdDemand.GetFocusedRowCellValue("id_report_status").ToString
            Dim id_prod_demand As String = FormProdDemand.GVProdDemand.GetFocusedRowCellDisplayText("id_prod_demand").ToString
            '
            Dim rmt As String = "9"
            Dim query_rmt As String = String.Format("SELECT id_pd_kind FROM tb_prod_demand WHERE id_prod_demand ='{0}'", id_prod_demand)
            Dim data_rmt As DataTable = execute_query(query_rmt, -1, True, "", "", "", "")
            If data_rmt.Rows.Count > 0 Then
                If data_rmt.Rows(0)("id_pd_kind").ToString = "1" Then 'pd biasa
                    rmt = "9"
                ElseIf data_rmt.Rows(0)("id_pd_kind").ToString = "2" Then 'Marketing
                    rmt = "80"
                ElseIf data_rmt.Rows(0)("id_pd_kind").ToString = "3" Then 'HRDSCR
                    rmt = "81"
                ElseIf data_rmt.Rows(0)("id_pd_kind").ToString = "4" Then 'SALES
                    rmt = "206"
                End If
            End If
            '
            If Not check_edit_report_status(id_report_status, rmt, id_prod_demand) Or id_report_status = "5" Then
                stopCustom("This data already locked.")
            Else
                Cursor = Cursors.WaitCursor
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        query = String.Format("DELETE FROM tb_prod_demand WHERE id_prod_demand ='{0}'", id_prod_demand)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related(rmt, id_prod_demand)

                        logData("tb_prod_demand", 3)
                        FormProdDemand.viewProdDemand()
                    Catch ex As Exception
                        errorConnection()
                    End Try
                End If
                Cursor = Cursors.Default
            End If
        ElseIf formName = "FormMasterCode" Then
            '
            confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                If FormMasterCode.XTCCode.SelectedTabPageIndex = 0 Then  'delete code
                    Try
                        Dim id_code As String = FormMasterCode.GVCode.GetFocusedRowCellDisplayText("id_code").ToString
                        query = String.Format("DELETE FROM tb_m_code WHERE id_code='{0}'", id_code)
                        execute_non_query(query, True, "", "", "", "")
                        FormMasterCode.view_code()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                ElseIf FormMasterCode.XTCCode.SelectedTabPageIndex = 1 Then 'delete code detail
                    Try
                        Dim id_code_detail As String = FormMasterCode.GVCodeDetail.GetFocusedRowCellDisplayText("id_code_detail").ToString
                        query = String.Format("DELETE FROM tb_m_code_detail WHERE id_code_detail='{0}'", id_code_detail)
                        execute_non_query(query, True, "", "", "", "")
                        FormMasterCode.view_code_detail(FormMasterCode.GVCode.GetFocusedRowCellDisplayText("id_code").ToString)
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            End If
        ElseIf formName = "FormTemplateCode" Then
            '
            confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                If FormTemplateCode.XTCTemplateCode.SelectedTabPageIndex = 0 Then  'delete code
                    Try
                        Dim id_template_code As String = FormTemplateCode.GVTemplateCode.GetFocusedRowCellDisplayText("id_template_code").ToString
                        query = String.Format("DELETE FROM tb_template_code WHERE id_template_code='{0}'", id_template_code)
                        execute_non_query(query, True, "", "", "", "")
                        FormTemplateCode.view_template()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            End If
        ElseIf formName = "FormMasterSample" Then
            '
            confirm = XtraMessageBox.Show("Are you sure want to delete this sample ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            Dim id_sample As String = FormMasterSample.GVSample.GetFocusedRowCellDisplayText("id_sample").ToString

            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    query = String.Format("DELETE FROM tb_m_sample WHERE id_sample = '{0}'", id_sample)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterSample.view_sample()
                Catch ex As Exception
                    errorDelete()
                End Try
                Cursor = Cursors.Default
            End If
        ElseIf formName = "FormMasterProduct" Then
            '
            confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                If FormMasterProduct.XTCProduct.SelectedTabPageIndex = 0 Then  'delete design
                    Try
                        Dim id_design As String = FormMasterProduct.GVDesign.GetFocusedRowCellDisplayText("id_design").ToString
                        query = String.Format("DELETE FROM tb_m_design WHERE id_design='{0}'", id_design)
                        execute_non_query(query, True, "", "", "", "")
                        FormMasterProduct.view_design()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                ElseIf FormMasterProduct.XTCProduct.SelectedTabPageIndex = 1 Then 'delete product
                    Try
                        Dim id_product As String = FormMasterProduct.GVProduct.GetFocusedRowCellDisplayText("id_product").ToString
                        query = String.Format("DELETE FROM tb_m_product WHERE id_product='{0}'", id_product)
                        execute_non_query(query, True, "", "", "", "")
                        FormMasterProduct.view_product(FormMasterProduct.GVDesign.GetFocusedRowCellDisplayText("id_design").ToString)
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            End If
        ElseIf formName = "FormBOM" Then
            '
            If FormBOM.XTCBOMSelection.SelectedTabPageIndex = "2" Then
                If check_edit_report_status(FormBOM.GVBOMPerDesign.GetFocusedRowCellDisplayText("id_report_status"), "79", FormBOM.GVBOMPerDesign.GetFocusedRowCellDisplayText("id_bom_approve")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this BOM ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    Dim id_bom_approve As String = FormBOM.GVBOMPerDesign.GetFocusedRowCellDisplayText("id_bom_approve").ToString

                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        Try
                            query = String.Format("DELETE FROM tb_bom WHERE id_bom_approve = '{0}'", id_bom_approve)
                            execute_non_query(query, True, "", "", "", "")

                            query = String.Format("DELETE FROM tb_bom_approve WHERE id_bom_approve = '{0}'", id_bom_approve)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("79", id_bom_approve)
                            FormBOM.show_bom_per_design(FormBOM.GVPerDesign.GetFocusedRowCellDisplayText("id_design").ToString)
                        Catch ex As Exception
                            errorDelete()
                        End Try
                        Cursor = Cursors.Default
                    End If
                Else
                    stopCustom("BOM already processed.")
                End If
            Else
                If check_edit_report_status(FormBOM.GVBOM.GetFocusedRowCellDisplayText("id_report_status"), "8", FormBOM.GVBOM.GetFocusedRowCellDisplayText("id_bom")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this BOM ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    Dim id_bom As String = FormBOM.GVBOM.GetFocusedRowCellDisplayText("id_bom").ToString

                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        Try
                            query = String.Format("DELETE FROM tb_bom WHERE id_bom = '{0}'", id_bom)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("8", id_bom)

                            FormBOM.view_bom(FormBOM.GVProduct.GetFocusedRowCellDisplayText("id_product").ToString)
                        Catch ex As Exception
                            errorDelete()
                        End Try
                        Cursor = Cursors.Default
                    End If
                Else
                    stopCustom("BOM already processed.")
                End If
            End If
        ElseIf formName = "FormSamplePL" Then
            'PACKING LIST RECEIVING SAMPLE
            If check_edit_report_status(FormSamplePL.GVPL.GetFocusedRowCellDisplayText("id_report_status"), "3", FormSamplePL.GVPL.GetFocusedRowCellDisplayText("id_pl_sample_purc")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this Packing List ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                Dim id_pl_sample_purc As String = FormSamplePL.GVPL.GetFocusedRowCellDisplayText("id_pl_sample_purc").ToString

                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_pl_sample_purc WHERE id_pl_sample_purc = '{0}'", id_pl_sample_purc)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("3", id_pl_sample_purc)

                        FormSamplePL.viewPL()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            Else
                stopCustom("Packing list already processed.")
            End If
        ElseIf formName = "FormSamplePurchase" Then
            '
            If check_edit_report_status(FormSamplePurchase.GVSamplePurchase.GetFocusedRowCellDisplayText("id_report_status"), "1", FormSamplePurchase.GVSamplePurchase.GetFocusedRowCellDisplayText("id_sample_purc")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this purchase sample ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                Dim id_sample_purc As String = FormSamplePurchase.GVSamplePurchase.GetFocusedRowCellDisplayText("id_sample_purc").ToString

                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_sample_purc WHERE id_sample_purc = '{0}'", id_sample_purc)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("1", id_sample_purc)

                        FormSamplePurchase.view_sample_purc()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            Else
                stopCustom("Purchase already processed.")
            End If
        ElseIf formName = "FormSampleReceive" Then
            '
            If check_edit_report_status(FormSampleReceive.GVSampleReceive.GetFocusedRowCellDisplayText("id_report_status"), "2", FormSampleReceive.GVSampleReceive.GetFocusedRowCellDisplayText("id_sample_purc_rec")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this receive sample ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                Dim id_sample_purc_rec As String = FormSampleReceive.GVSampleReceive.GetFocusedRowCellDisplayText("id_sample_purc_rec").ToString

                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_sample_purc_rec WHERE id_sample_purc_rec = '{0}'", id_sample_purc_rec)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("2", id_sample_purc_rec)

                        FormSampleReceive.view_sample_rec()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            Else
                stopCustom("Receive already processed.")
            End If
        ElseIf formName = "FormSamplePR" Then
            '
            If check_edit_report_status(FormSamplePR.GVSamplePR.GetFocusedRowCellDisplayText("id_report_status"), "4", FormSamplePR.GVSamplePR.GetFocusedRowCellDisplayText("id_pr_sample_purc")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this payment requisition ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                Dim id_pr_sample_purc As String = FormSamplePR.GVSamplePR.GetFocusedRowCellDisplayText("id_pr_sample_purc").ToString

                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_pr_sample_purc WHERE id_pr_sample_purc = '{0}'", id_pr_sample_purc)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("4", id_pr_sample_purc)

                        FormSamplePR.view_sample_pr()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            Else
                stopCustom("Payment Request already processed.")
            End If
        ElseIf formName = "FormMasterWH" Then
            'WAREHOUSE & LOCATOR
            If FormMasterWH.XTCWH.SelectedTabPageIndex = 1 Then 'Locator
                confirm = XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                Dim id_wh_locator As String = FormMasterWH.GVLocator.GetFocusedRowCellDisplayText("id_wh_locator").ToString

                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_m_wh_locator WHERE id_wh_locator = '{0}'", id_wh_locator)
                        execute_non_query(query, True, "", "", "", "")
                        FormMasterWH.viewWHLocator()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            ElseIf FormMasterWH.XTCWH.SelectedTabPageIndex = 2 Then 'Rack
                confirm = XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                Dim id_wh_rack As String = FormMasterWH.GVRack.GetFocusedRowCellDisplayText("id_wh_rack").ToString

                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_m_wh_rack WHERE id_wh_rack = '{0}'", id_wh_rack)
                        execute_non_query(query, True, "", "", "", "")
                        FormMasterWH.viewRack()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            ElseIf FormMasterWH.XTCWH.SelectedTabPageIndex = 3 Then 'Drawer
                confirm = XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                Dim id_wh_drawer As String = FormMasterWH.GVDrawer.GetFocusedRowCellDisplayText("id_wh_drawer").ToString

                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_m_wh_drawer WHERE id_wh_drawer = '{0}'", id_wh_drawer)
                        execute_non_query(query, True, "", "", "", "")
                        FormMasterWH.viewDrawer()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        ElseIf formName = "FormSampleRet" Then
            'RETURN SAMPLE
            If FormSampleRet.XTCReturn.SelectedTabPageIndex = 0 Then  'delete return out
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sample_purc_ret_out As String = FormSampleRet.GVRetOut.GetFocusedRowCellDisplayText("id_sample_purc_ret_out").ToString
                        query = String.Format("DELETE FROM tb_sample_purc_ret_out WHERE id_sample_purc_ret_out='{0}'", id_sample_purc_ret_out)
                        execute_non_query(query, True, "", "", "", "")
                        FormSampleRet.viewRetOut()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            ElseIf FormSampleRet.XTCReturn.SelectedTabPageIndex = 1 Then 'delete return in
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sample_purc_ret_in As String = FormSampleRet.GVRetIn.GetFocusedRowCellDisplayText("id_sample_purc_ret_in").ToString
                        query = String.Format("DELETE FROM tb_sample_purc_ret_in WHERE id_sample_purc_ret_in='{0}'", id_sample_purc_ret_in)
                        execute_non_query(query, True, "", "", "", "")
                        FormSampleRet.viewRetIn()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            End If
        ElseIf formName = "FormSamplePLDel" Then
            'PACKING LIST RECEIVING SAMPLE Delivery
            Dim id_pl_sample_del As String = FormSamplePLDel.GVPL.GetFocusedRowCellDisplayText("id_pl_sample_del").ToString
            Dim id_report_status As String = FormSamplePLDel.GVPL.GetFocusedRowCellDisplayText("id_report_status").ToString

            If Not check_edit_report_status(id_report_status, "10", id_pl_sample_del) Or id_report_status = "5" Then
                stopCustom("This data already locked.")
            Else
                confirm = XtraMessageBox.Show("Are you sure want to delete this Packing List ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        Cursor = Cursors.WaitCursor

                        'stock
                        Dim query_cancel As String = "SELECT * FROM tb_pl_sample_del a "
                        query_cancel += "INNER JOIN tb_pl_sample_del_det b ON a.id_pl_sample_del = b.id_pl_sample_del "
                        query_cancel += "INNER JOIN tb_sample_requisition_det c ON b.id_sample_requisition_det = c.id_sample_requisition_det "
                        query_cancel += "WHERE a.id_pl_sample_del = '" + id_pl_sample_del + "' "
                        Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                        For i As Integer = 0 To (data.Rows.Count - 1)
                            Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                            Dim id_sample As String = data.Rows(i)("id_sample").ToString
                            Dim pl_sample_del_det_qty As String = data.Rows(i)("pl_sample_del_det_qty").ToString
                            Dim pl_sample_del_number As String = data.Rows(i)("pl_sample_del_number").ToString
                            Dim id_sample_price As String = data.Rows(i)("id_sample_price").ToString
                            Dim sample_price As Decimal = data.Rows(i)("sample_price")

                            Dim query_upd_storage As String = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes,id_report,report_mark_type,id_stock_status,id_sample_price,sample_price) "
                            query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_sample + "', '" + pl_sample_del_det_qty + "', NOW(), 'Out sample was cancelled, PL : " + pl_sample_del_number + "','" + id_pl_sample_del + "','10','2','" + id_sample_price + "','" + decimalSQL(sample_price.ToString) + "')"
                            execute_non_query(query_upd_storage, True, "", "", "", "")
                        Next

                        'main
                        query = String.Format("DELETE FROM tb_pl_sample_del WHERE id_pl_sample_del = '{0}'", id_pl_sample_del)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("10", id_pl_sample_del)

                        'Refresh data
                        FormSamplePLDel.viewPL()
                        FormSamplePLDel.viewSampleReq()
                        Cursor = Cursors.Default
                    Catch ex As Exception
                        Cursor = Cursors.Default
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        ElseIf formName = "FormSampleReq" Then
            'SAMPLE REQUISITION
            Dim id_sample_requisition As String = FormSampleReq.GVReq.GetFocusedRowCellDisplayText("id_sample_requisition").ToString
            Dim id_report_status As String = FormSampleReq.GVReq.GetFocusedRowCellValue("id_report_status").ToString

            If Not check_edit_report_status(id_report_status, "11", id_sample_requisition) Or id_report_status = "5" Then
                stopCustom("This data already locked.")
            Else
                confirm = XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        Cursor = Cursors.WaitCursor
                        query = String.Format("DELETE FROM tb_sample_requisition WHERE id_sample_requisition = '{0}'", id_sample_requisition)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("11", id_sample_requisition)

                        FormSampleReq.viewSampleReq()
                        Cursor = Cursors.Default
                    Catch ex As Exception
                        Cursor = Cursors.Default
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        ElseIf formName = "FormMarkAssign" Then
            confirm = XtraMessageBox.Show("Are you sure want to delete this assign?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim id_mark_asg As String = FormMarkAssign.GVMarkAssign.GetFocusedRowCellDisplayText("id_mark_asg")
                    query = String.Format("DELETE FROM tb_mark_asg WHERE id_mark_asg='{0}'", id_mark_asg)
                    execute_non_query(query, True, "", "", "", "")
                    FormMarkAssign.view_asg()
                Catch ex As Exception
                    errorDelete()
                End Try
            End If
        ElseIf formName = "FormSamplePlan" Then
            '
            'check first
            If check_edit_report_status(FormSamplePlan.GVSamplePurchase.GetFocusedRowCellDisplayText("id_report_status"), "12", FormSamplePlan.GVSamplePurchase.GetFocusedRowCellDisplayText("id_sample_plan")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this sample plan?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sample_plan As String = FormSamplePlan.GVSamplePurchase.GetFocusedRowCellDisplayText("id_sample_plan")
                        query = String.Format("DELETE FROM tb_sample_plan WHERE id_sample_plan='{0}'", id_sample_plan)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("12", id_sample_plan)

                        FormSamplePlan.view_sample_plan()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This Sample Planning already marked")
            End If
        ElseIf formName = "FormSampleReturn" Then
            'SAMPLE RETURN
            Dim id_sample_return As String = FormSampleReturn.GVRetSample.GetFocusedRowCellDisplayText("id_sample_return").ToString
            Dim id_report_status As String = FormSampleReturn.GVRetSample.GetFocusedRowCellValue("id_report_status").ToString

            If Not check_edit_report_status(id_report_status, "14", id_sample_return) Or id_report_status = "5" Then
                stopCustom("This data already locked.")
            Else
                confirm = XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        Cursor = Cursors.WaitCursor

                        'main
                        query = String.Format("DELETE FROM tb_sample_return WHERE id_sample_return = '{0}'", id_sample_return)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("14", id_sample_return)

                        'Refresh data
                        FormSampleReturn.viewSampleReturn()
                        FormSampleReturn.viewPl()
                        Cursor = Cursors.Default
                    Catch ex As Exception
                        Cursor = Cursors.Default
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        ElseIf formName = "FormMatWO" Then
            '
            'check first
            If check_edit_report_status(FormMatWO.GVMatWO.GetFocusedRowCellDisplayText("id_report_status"), "15", FormMatWO.GVMatWO.GetFocusedRowCellDisplayText("id_mat_wo")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this work order?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_mat_wo As String = FormMatWO.GVMatWO.GetFocusedRowCellDisplayText("id_mat_wo")
                        query = String.Format("DELETE FROM tb_mat_wo WHERE id_mat_wo='{0}'", id_mat_wo)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("15", id_mat_wo)

                        FormMatWO.view_mat_purc()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This Work Order already marked")
            End If
        ElseIf formName = "FormMatPurchase" Then
            'check first
            If check_edit_report_status(FormMatPurchase.GVMatPurchase.GetFocusedRowCellDisplayText("id_report_status"), "15", FormMatPurchase.GVMatPurchase.GetFocusedRowCellDisplayText("id_mat_purc")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this purchase order?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_mat_purc As String = FormMatPurchase.GVMatPurchase.GetFocusedRowCellDisplayText("id_mat_purc")
                        query = String.Format("DELETE FROM tb_mat_purc WHERE id_mat_purc='{0}'", id_mat_purc)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("13", id_mat_purc)

                        FormMatPurchase.view_mat_purc()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This purchase already marked")
            End If
        ElseIf formName = "FormMatRecPurc" Then
            '
            'check first
            If check_edit_report_status(FormMatRecPurc.GVMatRecPurc.GetFocusedRowCellDisplayText("id_report_status"), "16", FormMatRecPurc.GVMatRecPurc.GetFocusedRowCellDisplayText("id_mat_purc_rec")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this receive?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_mat_purc_rec As String = FormMatRecPurc.GVMatRecPurc.GetFocusedRowCellDisplayText("id_mat_purc_rec")
                        query = String.Format("DELETE FROM tb_mat_purc_rec WHERE id_mat_purc_rec='{0}'", id_mat_purc_rec)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("16", id_mat_purc_rec)

                        FormMatRecPurc.view_mat_rec_purc()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This Receive already marked")
            End If
        ElseIf formName = "FormMatRecWO" Then
            '
            'check first
            If check_edit_report_status(FormMatRecWO.GVMatRecPurc.GetFocusedRowCellDisplayText("id_report_status"), "17", FormMatRecWO.GVMatRecPurc.GetFocusedRowCellDisplayText("id_mat_wo_rec")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this receive?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_mat_wo_rec As String = FormMatRecWO.GVMatRecPurc.GetFocusedRowCellDisplayText("id_mat_wo_rec")
                        query = String.Format("DELETE FROM tb_mat_wo_rec WHERE id_mat_wo_rec='{0}'", id_mat_wo_rec)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("17", id_mat_wo_rec)

                        FormMatRecWO.view_mat_rec_purc()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This Receive already marked")
            End If
        ElseIf formName = "FormMatRet" Then
            If FormMatRet.XTCReturnMat.SelectedTabPageIndex = 0 Then 'purchase
                'Return Mat
                If FormMatRet.XTCReturnPruchase.SelectedTabPageIndex = 0 Then 'return Out
                    If check_edit_report_status(FormMatRet.GVRetOut.GetFocusedRowCellDisplayText("id_report_status"), "18", FormMatRet.GVRetOut.GetFocusedRowCellDisplayText("id_mat_purc_ret_out")) Then
                        confirm = XtraMessageBox.Show("Are you sure want to delete this return?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        If confirm = Windows.Forms.DialogResult.Yes Then
                            Try
                                Dim id_mat_purc_ret_out As String = FormMatRet.GVRetOut.GetFocusedRowCellDisplayText("id_mat_purc_ret_out")
                                query = String.Format("DELETE FROM tb_mat_purc_ret_out WHERE id_mat_purc_ret_out='{0}'", id_mat_purc_ret_out)
                                execute_non_query(query, True, "", "", "", "")

                                'del mark
                                delete_all_mark_related("18", id_mat_purc_ret_out)

                                FormMatRet.viewRetOut()
                            Catch ex As Exception
                                errorDelete()
                            End Try
                        End If
                    Else
                        stopCustom("This Return already marked")
                    End If
                ElseIf FormMatRet.XTCReturnPruchase.SelectedTabPageIndex = 1 Then 'Return In
                    If check_edit_report_status(FormMatRet.GVRetIn.GetFocusedRowCellDisplayText("id_report_status"), "19", FormMatRet.GVRetIn.GetFocusedRowCellDisplayText("id_mat_purc_ret_in")) Then
                        confirm = XtraMessageBox.Show("Are you sure want to delete this return?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        If confirm = Windows.Forms.DialogResult.Yes Then
                            Try
                                Dim id_mat_purc_ret_in As String = FormMatRet.GVRetIn.GetFocusedRowCellDisplayText("id_mat_purc_ret_in")
                                query = String.Format("DELETE FROM tb_mat_purc_ret_in WHERE id_mat_purc_ret_in='{0}'", id_mat_purc_ret_in)
                                execute_non_query(query, True, "", "", "", "")

                                'del mark
                                delete_all_mark_related("19", id_mat_purc_ret_in)

                                FormMatRet.viewRetIn()
                            Catch ex As Exception
                                errorDelete()
                            End Try
                        End If
                    Else
                        stopCustom("This Return already marked")
                    End If
                End If
            ElseIf FormMatRet.XTCReturnMat.SelectedTabPageIndex = 1 Then 'production
                If FormMatRet.XTCReturnProd.SelectedTabPageIndex = 0 Then 'return in
                    If check_edit_report_status(FormMatRet.GVRetInProd.GetFocusedRowCellDisplayText("id_report_status"), "47", FormMatRet.GVRetInProd.GetFocusedRowCellDisplayText("id_mat_prod_ret_in")) Then
                        confirm = XtraMessageBox.Show("Are you sure want to delete this return?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        If confirm = Windows.Forms.DialogResult.Yes Then
                            Try
                                Dim id_mat_prod_ret_in As String = FormMatRet.GVRetInProd.GetFocusedRowCellDisplayText("id_mat_prod_ret_in")
                                query = String.Format("DELETE FROM tb_mat_prod_ret_in WHERE id_mat_prod_ret_in='{0}'", id_mat_prod_ret_in)
                                execute_non_query(query, True, "", "", "", "")

                                'del mark
                                delete_all_mark_related("47", id_mat_prod_ret_in)

                                FormMatRet.viewRetInProd()
                            Catch ex As Exception
                                errorDelete()
                            End Try
                        End If
                    Else
                        stopCustom("This Return already marked")
                    End If
                End If
            End If
        ElseIf formName = "FormSampleAdjustment" Then
            'SAMPLE Adjustment
            If FormSampleAdjustment.XTCAdj.SelectedTabPageIndex = 0 Then 'Adj In
                Dim id_adj_in_sample As String = FormSampleAdjustment.GVAdjSampleIn.GetFocusedRowCellDisplayText("id_adj_in_sample").ToString
                Dim id_report_status As String = FormSampleAdjustment.GVAdjSampleIn.GetFocusedRowCellValue("id_report_status").ToString

                If Not check_edit_report_status(id_report_status, "20", id_adj_in_sample) Or id_report_status = "5" Then
                    stopCustom("This data already locked.")
                Else
                    confirm = XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        Try
                            Cursor = Cursors.WaitCursor
                            'main
                            query = String.Format("DELETE FROM tb_adj_in_sample WHERE id_adj_in_sample = '{0}'", id_adj_in_sample)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("20", id_adj_in_sample)

                            'Refresh data
                            FormSampleAdjustment.viewAdjInSample()
                            Cursor = Cursors.Default
                        Catch ex As Exception
                            Cursor = Cursors.Default
                            errorDelete()
                        End Try
                        Cursor = Cursors.Default
                    End If
                End If
            ElseIf FormSampleAdjustment.XTCAdj.SelectedTabPageIndex = 1 Then 'Adj Out
                Dim id_adj_out_sample As String = FormSampleAdjustment.GVAdjOutSample.GetFocusedRowCellDisplayText("id_adj_out_sample").ToString
                Dim id_report_status As String = FormSampleAdjustment.GVAdjOutSample.GetFocusedRowCellValue("id_report_status").ToString

                If Not check_edit_report_status(id_report_status, "21", id_adj_out_sample) Or id_report_status = "5" Then
                    stopCustom("This data already locked.")
                Else
                    confirm = XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        Try
                            'stock
                            Dim query_cancel As String = "SELECT * FROM tb_adj_out_sample a "
                            query_cancel += "INNER JOIN tb_adj_out_sample_det b ON a.id_adj_out_sample = b.id_adj_out_sample "
                            query_cancel += "WHERE a.id_adj_out_sample = '" + id_adj_out_sample + "' "
                            Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")

                            Dim jum_ins_i As Integer = 0
                            Dim query_drawer_stock As String = ""
                            If data.Rows.Count > 0 Then
                                query_drawer_stock = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, id_sample_price, sample_price, qty_sample, datetime_storage_sample, storage_sample_notes, report_mark_type, id_report, id_stock_status) VALUES "
                            End If
                            For i As Integer = 0 To (data.Rows.Count - 1)
                                Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                                Dim id_sample As String = data.Rows(i)("id_sample").ToString
                                Dim adj_out_sample_det_qty As String = decimalSQL(data.Rows(i)("adj_out_sample_det_qty").ToString)
                                Dim adj_out_sample_number As String = data.Rows(i)("adj_out_sample_number").ToString
                                Dim id_sample_price As String = data.Rows(i)("id_sample_price").ToString
                                Dim adj_out_sample_det_price As String = decimalSQL(data.Rows(i)("adj_out_sample_det_price").ToString)

                                'insert stock
                                If jum_ins_i > 0 Then
                                    query_drawer_stock += ", "
                                End If
                                query_drawer_stock += "('" + id_wh_drawer + "', '1', '" + id_sample + "', '" + id_sample_price + "', '" + adj_out_sample_det_price + "','" + adj_out_sample_det_qty + "', NOW(), 'Adjusment Out Cancelled Order No: " + adj_out_sample_number + "', '21', '" + id_adj_out_sample + "', '2') "
                                jum_ins_i = jum_ins_i + 1
                            Next
                            If jum_ins_i > 0 Then
                                execute_non_query(query_drawer_stock, True, "", "", "", "")
                            End If

                            'main
                            query = String.Format("DELETE FROM tb_adj_out_sample WHERE id_adj_out_sample = '{0}'", id_adj_out_sample)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("21", id_adj_out_sample)

                            'Refresh data
                            FormSampleAdjustment.viewAdjOutSample()
                            Cursor = Cursors.Default
                        Catch ex As Exception
                            errorDelete()
                        End Try
                        Cursor = Cursors.Default
                    End If
                End If
            End If
        ElseIf formName = "FormMatAdj" Then
            'Material Adjustment
            If FormMatAdj.XTCAdj.SelectedTabPageIndex = 0 Then 'Adj In
                Dim id_adj_in_mat As String = FormMatAdj.GVAdjIn.GetFocusedRowCellDisplayText("id_adj_in_mat").ToString
                Dim id_report_status As String = FormMatAdj.GVAdjIn.GetFocusedRowCellValue("id_report_status").ToString

                If Not check_edit_report_status(id_report_status, "26", id_adj_in_mat) Or id_report_status = "5" Then
                    stopCustom("This data already locked.")
                Else
                    confirm = XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        Try
                            Cursor = Cursors.WaitCursor

                            'Dim query_cancel As String = "SELECT * FROM tb_adj_in_mat a "
                            'query_cancel += "INNER JOIN tb_adj_in_mat_det b ON a.id_adj_in_mat = b.id_adj_in_mat "
                            'query_cancel += "WHERE a.id_adj_in_mat = '" + id_adj_in_mat + "' "
                            'Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                            'For i As Integer = 0 To (data.Rows.Count - 1)
                            '    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                            '    Dim id_mat_det As String = data.Rows(i)("id_mat_det").ToString
                            '    Dim id_mat_det_price As String = data.Rows(i)("id_mat_det_price").ToString
                            '    Dim adj_in_mat_det_qty As String = decimalSQL(data.Rows(i)("adj_in_mat_det_qty").ToString)
                            '    Dim adj_in_mat_det_price As String = decimalSQL(data.Rows(i)("adj_in_mat_det_price").ToString)
                            '    Dim adj_in_mat_number As String = data.Rows(i)("adj_in_mat_number").ToString

                            '    Dim query_upd_storage As String = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det,id_mat_det_price,price, storage_mat_qty, storage_mat_datetime, storage_mat_notes,report_mark_type,id_report,id_stock_status) "
                            '    query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_mat_det + "','" + id_mat_det_price + "'," + adj_in_mat_det_price + ",'" + adj_in_mat_det_qty + "', NOW(), 'Material Adjustment In cancelled, Adjustment In : " + adj_in_mat_number + "','26','" & id_adj_in_mat & "','2')"
                            '    execute_non_query(query_upd_storage, True, "", "", "", "")
                            'Next
                            'main
                            query = String.Format("DELETE FROM tb_adj_in_mat WHERE id_adj_in_mat = '{0}'", id_adj_in_mat)
                            execute_non_query(query, True, "", "", "", "")
                            'del mark
                            delete_all_mark_related("26", id_adj_in_mat)
                            'Refresh
                            FormMatAdj.viewAdjIn()
                            Cursor = Cursors.Default
                        Catch ex As Exception
                            Cursor = Cursors.Default
                            errorDelete()
                        End Try
                        Cursor = Cursors.Default
                    End If
                End If
            ElseIf FormMatAdj.XTCAdj.SelectedTabPageIndex = 1 Then 'Adj Out
                Dim id_adj_out_mat As String = FormMatAdj.GVAdjOut.GetFocusedRowCellDisplayText("id_adj_out_mat").ToString
                Dim id_report_status As String = FormMatAdj.GVAdjOut.GetFocusedRowCellValue("id_report_status").ToString

                If Not check_edit_report_status(id_report_status, "27", id_adj_out_mat) Or id_report_status = "5" Then
                    stopCustom("This data already locked.")
                Else
                    confirm = XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        Try
                            Cursor = Cursors.WaitCursor
                            'stock
                            Dim query_cancel As String = "SELECT * FROM tb_adj_out_mat a "
                            query_cancel += "INNER JOIN tb_adj_out_mat_det b ON a.id_adj_out_mat = b.id_adj_out_mat "
                            query_cancel += "WHERE a.id_adj_out_mat = '" + id_adj_out_mat + "' "
                            Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                            For i As Integer = 0 To (data.Rows.Count - 1)
                                Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                                Dim id_mat_det As String = data.Rows(i)("id_mat_det").ToString
                                Dim adj_out_mat_det_qty As Decimal = data.Rows(i)("adj_out_mat_det_qty")
                                Dim id_mat_det_price As String = data.Rows(i)("id_mat_det_price").ToString
                                Dim adj_out_mat_det_price As Decimal = data.Rows(i)("adj_out_mat_det_price")
                                Dim adj_out_mat_number As String = data.Rows(i)("adj_out_mat_number").ToString
                                Dim query_upd_storage As String = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_mat_det_price,price,id_stock_status,report_mark_type,id_report) "
                                query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_mat_det + "', '" + decimalSQL(adj_out_mat_det_qty.ToString) + "', NOW(), 'Material Adjustment Out cancelled, Adjustment In : " + adj_out_mat_number + "','" & id_mat_det_price & "','" & decimalSQL(adj_out_mat_det_price.ToString) & "','2','27','" & id_adj_out_mat & "')"
                                execute_non_query(query_upd_storage, True, "", "", "", "")
                            Next

                            'main
                            query = String.Format("DELETE FROM tb_adj_out_mat WHERE id_adj_out_mat = '{0}'", id_adj_out_mat)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("27", id_adj_out_mat)

                            'Refresh data
                            FormMatAdj.viewAdjOut()
                            Cursor = Cursors.Default
                        Catch ex As Exception
                            Cursor = Cursors.Default
                            errorDelete()
                        End Try
                        Cursor = Cursors.Default
                    End If
                End If
            End If
        ElseIf formName = "FormMatPR" Then
            'PR MAT PURCHASE
            Dim id_pr_mat_purc As String = FormMatPR.GVMatPR.GetFocusedRowCellDisplayText("id_pr_mat_purc").ToString
            Dim id_report_status As String = FormMatPR.GVMatPR.GetFocusedRowCellValue("id_report_status").ToString
            If Not check_edit_report_status(id_report_status, "24", id_pr_mat_purc) Or id_report_status = "5" Then
                stopCustom("This data already locked.")
            Else
                confirm = XtraMessageBox.Show("Are you sure want to delete this payment requisition ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_pr_mat_purc WHERE id_pr_mat_purc = '{0}'", id_pr_mat_purc)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("24", id_pr_mat_purc)

                        FormMatPR.view_mat_pr()
                        FormMatPR.view_mat_purc()
                        FormMatPR.view_mat_rec()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        ElseIf formName = "FormMatPRWO" Then
            'PR MAT WO
            Dim id_pr_mat_wo As String = FormMatPRWO.GVMatPRWO.GetFocusedRowCellDisplayText("id_pr_mat_wo").ToString
            Dim id_report_status As String = FormMatPRWO.GVMatPRWO.GetFocusedRowCellValue("id_report_status").ToString
            If Not check_edit_report_status(id_report_status, "25", id_pr_mat_wo) Or id_report_status = "5" Then
                stopCustom("This data already locked.")
            Else
                confirm = XtraMessageBox.Show("Are you sure want to delete this payment requisition ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_pr_mat_wo WHERE id_pr_mat_wo = '{0}'", id_pr_mat_wo)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("25", id_pr_mat_wo)

                        FormMatPRWO.view_mat_pr()
                        FormMatPRWO.view_mat_wo()
                        FormMatPRWO.view_mat_rec()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        ElseIf formName = "FormMatPRWO" Then
            'PR MAT WO
            Dim id_pr_mat_wo As String = FormMatPRWO.GVMatPRWO.GetFocusedRowCellDisplayText("id_pr_mat_wo").ToString
            Dim id_report_status As String = FormMatPRWO.GVMatPRWO.GetFocusedRowCellValue("id_report_status").ToString
            If Not check_edit_report_status(id_report_status, "25", id_pr_mat_wo) Or id_report_status = "5" Then
                stopCustom("This data already locked.")
            Else
                confirm = XtraMessageBox.Show("Are you sure want to delete this payment requisition ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_pr_mat_wo WHERE id_pr_mat_wo = '{0}'", id_pr_mat_wo)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("25", id_pr_mat_wo)

                        FormMatPRWO.view_mat_pr()
                        FormMatPRWO.view_mat_wo()
                        FormMatPRWO.view_mat_rec()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        ElseIf formName = "FormProduction" Then
            'FGPO
            If FormProduction.XTCTabProduction.SelectedTabPageIndex = 0 Then 'prod_order
                If check_edit_report_status(FormProduction.GVProd.GetFocusedRowCellDisplayText("id_report_status"), "22", FormProduction.GVProd.GetFocusedRowCellDisplayText("id_prod_order")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this production order?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_prod_order As String = FormProduction.GVProd.GetFocusedRowCellDisplayText("id_prod_order")
                            query = String.Format("DELETE FROM tb_prod_order WHERE id_prod_order='{0}'", id_prod_order)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("22", id_prod_order)

                            FormProduction.view_production_order()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This Production Order already marked")
                End If
            End If
        ElseIf formName = "FormMatPL" Then
            'Mat PL
            If FormMatPL.XTCPL.SelectedTabPageIndex = 0 Then 'production
                If check_edit_report_status(FormMatPL.GVProdPL.GetFocusedRowCellDisplayText("id_report_status"), "30", FormMatPL.GVProdPL.GetFocusedRowCellDisplayText("id_pl_mrs")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this packing list ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_pl_mrs As String = FormMatPL.GVProdPL.GetFocusedRowCellDisplayText("id_pl_mrs")

                            'stock
                            Dim query_cancel As String = "SELECT b.id_wh_drawer,c.id_mat_det,CAST(IFNULL(b.pl_mrs_det_qty,0) AS DECIMAL(13,2)) as pl_mrs_det_qty,a.pl_mrs_number,b.id_mat_det_price,CAST(IFNULL(b.pl_mrs_det_price,0) AS DECIMAL(13,2)) as pl_mrs_det_price FROM tb_pl_mrs a "
                            query_cancel += "INNER JOIN tb_pl_mrs_det b ON a.id_pl_mrs = b.id_pl_mrs "
                            query_cancel += "INNER JOIN tb_prod_order_mrs_det c ON b.id_prod_order_mrs_det = c.id_prod_order_mrs_det "
                            query_cancel += "WHERE a.id_pl_mrs = '" + id_pl_mrs + "' "
                            Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                            For i As Integer = 0 To (data.Rows.Count - 1)
                                Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                                Dim id_mat_det As String = data.Rows(i)("id_mat_det").ToString
                                Dim pl_mrs_det_qty As Decimal = data.Rows(i)("pl_mrs_det_qty")
                                Dim pl_mrs_number As String = data.Rows(i)("pl_mrs_number").ToString
                                Dim id_mat_det_price As String = data.Rows(i)("id_mat_det_price").ToString
                                Dim pl_mrs_det_price As Decimal = data.Rows(i)("pl_mrs_det_price")
                                Dim query_upd_storage As String = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_mat_det_price,price,id_stock_status,report_mark_type,id_report) "
                                query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_mat_det + "', '" + decimalSQL(pl_mrs_det_qty.ToString) + "', NOW(), 'Out material was cancelled, PL : " + pl_mrs_number + "','" & id_mat_det_price & "','" & decimalSQL(pl_mrs_det_price.ToString) & "','2','30','" & id_pl_mrs & "')"
                                execute_non_query(query_upd_storage, True, "", "", "", "")
                            Next

                            query = String.Format("DELETE FROM tb_pl_mrs WHERE id_pl_mrs='{0}'", id_pl_mrs)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("30", id_pl_mrs)

                            FormMatPL.viewPL()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This Packing List already processed.")
                End If
            ElseIf FormMatPL.XTCPL.SelectedTabPageIndex = 1 Then 'wo
                If check_edit_report_status(FormMatPL.GVPLWO.GetFocusedRowCellDisplayText("id_report_status"), "30", FormMatPL.GVPLWO.GetFocusedRowCellDisplayText("id_pl_mrs")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this packing list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        'Try
                        Dim id_pl_mrs As String = FormMatPL.GVPLWO.GetFocusedRowCellDisplayText("id_pl_mrs")

                        'stock
                        Dim query_cancel As String = "SELECT b.id_wh_drawer,c.id_mat_det,CAST(IFNULL(b.pl_mrs_det_qty,0) AS DECIMAL(13,2)) as pl_mrs_det_qty,a.pl_mrs_number,b.id_mat_det_price,CAST(IFNULL(b.pl_mrs_det_price,0) AS DECIMAL(13,2)) as pl_mrs_det_price FROM tb_pl_mrs a "
                        query_cancel += "INNER JOIN tb_pl_mrs_det b ON a.id_pl_mrs = b.id_pl_mrs "
                        query_cancel += "INNER JOIN tb_prod_order_mrs_det c ON b.id_prod_order_mrs_det = c.id_prod_order_mrs_det "
                        query_cancel += "WHERE a.id_pl_mrs = '" + id_pl_mrs + "' "
                        Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                        For i As Integer = 0 To (data.Rows.Count - 1)
                            Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                            Dim id_mat_det As String = data.Rows(i)("id_mat_det").ToString
                            Dim pl_mrs_det_qty As Decimal = data.Rows(i)("pl_mrs_det_qty")
                            Dim pl_mrs_number As String = data.Rows(i)("pl_mrs_number").ToString
                            Dim id_mat_det_price As String = data.Rows(i)("id_mat_det_price").ToString
                            Dim pl_mrs_det_price As Decimal = data.Rows(i)("pl_mrs_det_price")
                            Dim query_upd_storage As String = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_mat_det_price,price,id_stock_status,report_mark_type,id_report) "

                            query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_mat_det + "', '" + decimalSQL(pl_mrs_det_qty.ToString) + "', NOW(), 'Out material was cancelled, PL : " + pl_mrs_number + "','" & id_mat_det_price & "','" & decimalSQL(pl_mrs_det_price.ToString) & "','2','30','" & id_pl_mrs & "')"
                            execute_non_query(query_upd_storage, True, "", "", "", "")
                        Next

                        query = String.Format("DELETE FROM tb_pl_mrs WHERE id_pl_mrs='{0}'", id_pl_mrs)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("30", id_pl_mrs)

                        FormMatPL.viewPLWO()
                        'Catch ex As Exception
                        'errorDelete()
                        ' End Try
                    End If
                Else
                    stopCustom("This Packing List already processed.")
                End If
            ElseIf FormMatPL.XTCPL.SelectedTabPageIndex = 2 Then 'other
                If check_edit_report_status(FormMatPL.GVPLOther.GetFocusedRowCellDisplayText("id_report_status"), "30", FormMatPL.GVPLOther.GetFocusedRowCellDisplayText("id_pl_mrs")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this packing list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_pl_mrs As String = FormMatPL.GVPLOther.GetFocusedRowCellDisplayText("id_pl_mrs")

                            'stock
                            Dim query_cancel As String = "SELECT b.id_wh_drawer,c.id_mat_det,CAST(IFNULL(b.pl_mrs_det_qty,0) AS DECIMAL(13,2)) as pl_mrs_det_qty,a.pl_mrs_number,b.id_mat_det_price,CAST(IFNULL(b.pl_mrs_det_price,0) AS DECIMAL(13,2)) as pl_mrs_det_price FROM tb_pl_mrs a "
                            query_cancel += "INNER JOIN tb_pl_mrs_det b ON a.id_pl_mrs = b.id_pl_mrs "
                            query_cancel += "INNER JOIN tb_prod_order_mrs_det c ON b.id_prod_order_mrs_det = c.id_prod_order_mrs_det "
                            query_cancel += "WHERE a.id_pl_mrs = '" + id_pl_mrs + "' "
                            Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                            For i As Integer = 0 To (data.Rows.Count - 1)
                                Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                                Dim id_mat_det As String = data.Rows(i)("id_mat_det").ToString
                                Dim pl_mrs_det_qty As Decimal = data.Rows(i)("pl_mrs_det_qty")
                                Dim pl_mrs_number As String = data.Rows(i)("pl_mrs_number").ToString
                                Dim id_mat_det_price As String = data.Rows(i)("id_mat_det_price").ToString
                                Dim pl_mrs_det_price As Decimal = data.Rows(i)("pl_mrs_det_price")
                                Dim query_upd_storage As String = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_mat_det_price,price,id_stock_status,report_mark_type,id_report) "

                                query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_mat_det + "', '" + decimalSQL(pl_mrs_det_qty.ToString) + "', NOW(), 'Out material was cancelled, PL : " + pl_mrs_number + "','" & id_mat_det_price & "','" & decimalSQL(pl_mrs_det_price.ToString) & "','2','30','" & id_pl_mrs & "')"
                                execute_non_query(query_upd_storage, True, "", "", "", "")
                            Next

                            query = String.Format("DELETE FROM tb_pl_mrs WHERE id_pl_mrs='{0}'", id_pl_mrs)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("30", id_pl_mrs)

                            FormMatPL.viewPLOther()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This Packing List already processed.")
                End If
            End If
        ElseIf formName = "FormMatMRS" Then
            'MRS Material
            If FormMatMRS.XTCMRS.SelectedTabPageIndex = 0 Then 'wo
                If check_edit_report_status(FormMatMRS.GVMRSWO.GetFocusedRowCellDisplayText("id_report_status"), "29", FormMatMRS.GVMRSWO.GetFocusedRowCellDisplayText("id_prod_order_mrs")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this Material Requesition?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_mrs As String = FormMatMRS.GVMRSWO.GetFocusedRowCellDisplayText("id_prod_order_mrs")
                            query = String.Format("DELETE FROM tb_prod_order_mrs WHERE id_prod_order_mrs='{0}'", id_mrs)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("29", id_mrs)

                            FormMatMRS.view_mrs_wo()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This Material Requisition already processed.")
                End If
            Else 'other
                If check_edit_report_status(FormMatMRS.GVMRS.GetFocusedRowCellDisplayText("id_report_status"), "44", FormMatMRS.GVMRS.GetFocusedRowCellDisplayText("id_prod_order_mrs")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this Material Requesition?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_mrs As String = FormMatMRS.GVMRS.GetFocusedRowCellDisplayText("id_prod_order_mrs")
                            query = String.Format("DELETE FROM tb_prod_order_mrs WHERE id_prod_order_mrs='{0}'", id_mrs)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("44", id_mrs)

                            FormMatMRS.view_mrs()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This Material Requisition already processed.")
                End If
            End If
        ElseIf formName = "FormProductionRec" Then
            'Receiving QC
            '
            'check first
            If check_edit_report_status(FormProductionRec.GVProdRec.GetFocusedRowCellDisplayText("id_report_status"), "28", FormProductionRec.GVProdRec.GetFocusedRowCellDisplayText("id_prod_order_rec")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this receive?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_prod_order_rec As String = FormProductionRec.GVProdRec.GetFocusedRowCellDisplayText("id_prod_order_rec")
                        query = String.Format("DELETE FROM tb_prod_order_rec WHERE id_prod_order_rec='{0}'", id_prod_order_rec)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("28", id_prod_order_rec)

                        FormProductionRec.view_prod_order_rec()
                        FormProductionRec.view_prod_order()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This Receive already marked")
            End If
        ElseIf formName = "FormProductionRet" Then
            'RETURN FG
            If FormProductionRet.XTCReturn.SelectedTabPageIndex = 0 Then 'return Out
                If check_edit_report_status(FormProductionRet.GVRetOut.GetFocusedRowCellValue("id_report_status"), "31", FormProductionRet.GVRetOut.GetFocusedRowCellDisplayText("id_prod_order_ret_out")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this return?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_prod_order_ret_out As String = FormProductionRet.GVRetOut.GetFocusedRowCellDisplayText("id_prod_order_ret_out")
                            query = String.Format("DELETE FROM tb_prod_order_ret_out WHERE id_prod_order_ret_out='{0}'", id_prod_order_ret_out)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("31", id_prod_order_ret_out)

                            FormProductionRet.viewRetOut()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This Return already marked")
                End If
            ElseIf FormProductionRet.XTCReturn.SelectedTabPageIndex = 1 Then 'return In
                If check_edit_report_status(FormProductionRet.GVRetIn.GetFocusedRowCellValue("id_report_status"), "32", FormProductionRet.GVRetIn.GetFocusedRowCellDisplayText("id_prod_order_ret_in")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this return?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_prod_order_ret_in As String = FormProductionRet.GVRetIn.GetFocusedRowCellDisplayText("id_prod_order_ret_in")
                            query = String.Format("DELETE FROM tb_prod_order_ret_in WHERE id_prod_order_ret_in='{0}'", id_prod_order_ret_in)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("32", id_prod_order_ret_in)

                            FormProductionRet.viewRetIn()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This Return already marked")
                End If
            End If
        ElseIf formName = "FormProductionPLToWH" Then
            If check_edit_report_status(FormProductionPLToWH.GVPL.GetFocusedRowCellValue("id_report_status"), "33", FormProductionPLToWH.GVPL.GetFocusedRowCellDisplayText("id_pl_prod_order")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_pl_prod_order As String = FormProductionPLToWH.GVPL.GetFocusedRowCellDisplayText("id_pl_prod_order")
                        query = String.Format("DELETE FROM tb_pl_prod_order WHERE id_pl_prod_order ='{0}'", id_pl_prod_order)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("33", id_pl_prod_order)

                        FormProductionPLToWH.viewPL()
                        FormProductionPLToWH.view_sample_purc()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormMatInvoice" Then
            'Invoice Material PL MRS
            If FormMatInvoice.XTCTabGeneral.SelectedTabPageIndex = 0 Then 'invoice
                If check_edit_report_status(FormMatInvoice.GVProdInvoice.GetFocusedRowCellDisplayText("id_report_status"), "34", FormMatInvoice.GVProdInvoice.GetFocusedRowCellDisplayText("id_inv_pl_mrs")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this invoice?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_invoice As String = FormMatInvoice.GVProdInvoice.GetFocusedRowCellDisplayText("id_inv_pl_mrs")
                            query = String.Format("DELETE FROM tb_inv_pl_mrs WHERE id_inv_pl_mrs='{0}'", id_invoice)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("34", id_invoice)

                            FormMatInvoice.viewInv()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This invoice already processed.")
                End If
            Else 'retur
                If check_edit_report_status(FormMatInvoice.GVRetur.GetFocusedRowCellDisplayText("id_report_status"), "35", FormMatInvoice.GVRetur.GetFocusedRowCellDisplayText("id_inv_pl_mrs_ret")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this invoice?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_retur As String = FormMatInvoice.GVRetur.GetFocusedRowCellDisplayText("id_inv_pl_mrs_ret")
                            query = String.Format("DELETE FROM tb_inv_pl_mrs_ret WHERE id_inv_pl_mrs_ret='{0}'", id_retur)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("35", id_retur)

                            FormMatInvoice.view_retur()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This invoice already processed.")
                End If
            End If
        ElseIf formName = "FormAccountingJournal" Then
            errorCustom("You can't delete journal entry.")
        ElseIf formName = "FormProductionPLToWHRec" Then
            If check_edit_report_status(FormProductionPLToWHRec.GVPL.GetFocusedRowCellValue("id_report_status"), "37", FormProductionPLToWHRec.GVPL.GetFocusedRowCellDisplayText("id_pl_prod_order_rec")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_pl_prod_order_rec As String = FormProductionPLToWHRec.GVPL.GetFocusedRowCellDisplayText("id_pl_prod_order_rec")
                        query = String.Format("DELETE FROM tb_pl_prod_order_rec WHERE id_pl_prod_order_rec ='{0}'", id_pl_prod_order_rec)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("37", id_pl_prod_order_rec)

                        FormProductionPLToWHRec.viewPL()
                        FormProductionPLToWHRec.view_sample_purc()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormSalesTarget" Then
            'SALES TARGET
            If check_edit_report_status(FormSalesTarget.GVSalesTarget.GetFocusedRowCellValue("id_report_status"), "38", FormSalesTarget.GVSalesTarget.GetFocusedRowCellValue("id_sales_target")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sales_target As String = FormSalesTarget.GVSalesTarget.GetFocusedRowCellValue("id_sales_target")
                        query = String.Format("DELETE FROM tb_sales_target WHERE id_sales_target ='{0}'", id_sales_target)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("38", id_sales_target)

                        FormSalesTarget.viewSalesTarget()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormSalesOrder" Then
            'SALES ORDER
            If FormSalesOrder.XTCSOGeneral.SelectedTabPageIndex = 0 Then
                If check_edit_report_status(FormSalesOrder.GVSalesOrder.GetFocusedRowCellValue("id_report_status"), "39", FormSalesOrder.GVSalesOrder.GetFocusedRowCellValue("id_sales_order")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_sales_order As String = FormSalesOrder.GVSalesOrder.GetFocusedRowCellValue("id_sales_order")

                            'cancel reserve
                            Dim cancel As New ClassSalesOrder()
                            cancel.cancelReservedStock(id_sales_order)

                            'del so
                            query = String.Format("DELETE FROM tb_sales_order WHERE id_sales_order ='{0}'", id_sales_order)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("39", id_sales_order)
                            FormSalesOrder.viewSalesOrder()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This data already marked")
                End If
            ElseIf FormSalesOrder.XTCSOGeneral.SelectedTabPageIndex = 1 Then
                If Not FormSalesOrder.GVGen.GetFocusedRowCellValue("is_submit").ToString = "1" Then
                    If check_edit_report_status(FormSalesOrder.GVGen.GetFocusedRowCellValue("id_report_status"), "88", FormSalesOrder.GVGen.GetFocusedRowCellValue("id_sales_order_gen")) Then
                        confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        If confirm = Windows.Forms.DialogResult.Yes Then
                            Try
                                Dim id_sales_order_gen As String = FormSalesOrder.GVGen.GetFocusedRowCellValue("id_sales_order_gen")

                                query = String.Format("DELETE FROM tb_sales_order_gen WHERE id_sales_order_gen ='{0}'", id_sales_order_gen)
                                execute_non_query(query, True, "", "", "", "")

                                'del mark
                                delete_all_mark_related("88", id_sales_order_gen)
                                FormSalesOrder.viewSalesOrderGen()
                            Catch ex As Exception
                                errorDelete()
                            End Try
                        End If
                    Else
                        stopCustom("This data already marked")
                    End If
                Else
                    stopCustom("This data already submitted")
                End If
            End If
        ElseIf formName = "FormSalesDelOrder" Then
            'SALES DEL ORDER
            If check_edit_report_status(FormSalesDelOrder.GVSalesDelOrder.GetFocusedRowCellValue("id_report_status"), "43", FormSalesDelOrder.GVSalesDelOrder.GetFocusedRowCellValue("id_pl_sales_order_del")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_pl_sales_order_del As String = FormSalesDelOrder.GVSalesDelOrder.GetFocusedRowCellValue("id_pl_sales_order_del")

                        'del mark
                        delete_all_mark_related("43", id_pl_sales_order_del)

                        'del data
                        query = String.Format("DELETE FROM tb_pl_sales_order_del WHERE id_pl_sales_order_del ='{0}'", id_pl_sales_order_del)
                        execute_non_query(query, True, "", "", "", "")

                        FormSalesDelOrder.viewSalesDelOrder()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormSalesReturnOrder" Then
            'SALES RETURN ORDER
            If check_edit_report_status(FormSalesReturnOrder.GVSalesReturnOrder.GetFocusedRowCellValue("id_report_status"), "45", FormSalesReturnOrder.GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sales_return_order As String = FormSalesReturnOrder.GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order")
                        query = String.Format("DELETE FROM tb_sales_return_order WHERE id_sales_return_order ='{0}'", id_sales_return_order)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("45", id_sales_return_order)
                        FormSalesReturnOrder.viewSalesReturnOrder()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormSalesReturn" Then
            'SALES RETURN
            If check_edit_report_status(FormSalesReturn.GVSalesReturn.GetFocusedRowCellValue("id_report_status"), "46", FormSalesReturn.GVSalesReturn.GetFocusedRowCellValue("id_sales_return")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sales_return As String = FormSalesReturn.GVSalesReturn.GetFocusedRowCellValue("id_sales_return")

                        'cancel reserved
                        Dim stc_cancel As ClassSalesReturn = New ClassSalesReturn()
                        stc_cancel.cancelReservedStock(id_sales_return)

                        'delete
                        query = String.Format("DELETE FROM tb_sales_return WHERE id_sales_return ='{0}'", id_sales_return)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("46", id_sales_return)
                        FormSalesReturn.viewSalesReturn()
                        FormSalesReturn.viewSalesReturnOrder()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormSalesPOS" Then
            'SALES POS pakai fitur cancell
            'If check_edit_report_status(FormSalesPOS.GVSalesPOS.GetFocusedRowCellValue("id_report_status"), "48", FormSalesPOS.GVSalesPOS.GetFocusedRowCellValue("id_sales_pos")) Then
            '    confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            '    If confirm = Windows.Forms.DialogResult.Yes Then
            '        Try
            '            Dim id_sales_pos As String = FormSalesPOS.GVSalesPOS.GetFocusedRowCellValue("id_sales_pos")

            '            'rollback stock
            '            Dim rsv_stock As ClassSalesInv = New ClassSalesInv()
            '            rsv_stock.cancelReservedStock(id_sales_pos, "48")

            '            'del data
            '            query = String.Format("DELETE FROM tb_sales_pos WHERE id_sales_pos ='{0}'", id_sales_pos)
            '            execute_non_query(query, True, "", "", "", "")

            '            'del mark
            '            delete_all_mark_related("48", id_sales_pos)
            '            FormSalesPOS.viewSalesPOS()
            '        Catch ex As Exception
            '            errorDelete()
            '        End Try
            '    End If
            'Else
            '    stopCustom("This data already marked")
            'End If
        ElseIf formName = "FormSalesReturnQC" Then
            'SALES RETURN QC
            If check_edit_report_status(FormSalesReturnQC.GVSalesReturnQC.GetFocusedRowCellValue("id_report_status"), "49", FormSalesReturnQC.GVSalesReturnQC.GetFocusedRowCellValue("id_sales_return_qc")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sales_return_qc As String = FormSalesReturnQC.GVSalesReturnQC.GetFocusedRowCellValue("id_sales_return_qc").ToString
                        query = String.Format("DELETE FROM tb_sales_return_qc WHERE id_sales_return_qc ='{0}'", id_sales_return_qc)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("49", id_sales_return_qc)
                        FormSalesReturnQC.viewSalesReturnQC()
                        FormSalesReturnQC.viewSalesReturn()
                        'FormSalesReturnQC.viewSalesReturnOrder()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormAccountingJournalAdj" Then
            If check_edit_report_status(FormAccountingJournalAdj.GVAccTrans.GetFocusedRowCellValue("id_report_status"), "40", FormAccountingJournalAdj.GVAccTrans.GetFocusedRowCellDisplayText("id_acc_trans_adj")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this adjustment?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_acc_trans_adj As String = FormAccountingJournalAdj.GVAccTrans.GetFocusedRowCellDisplayText("id_acc_trans_adj")
                        query = String.Format("DELETE FROM tb_a_acc_trans_adj WHERE id_acc_trans_adj ='{0}'", id_acc_trans_adj)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("40", id_acc_trans_adj)

                        FormAccountingJournalAdj.view_jurnal()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormProdPRWO" Then
            If FormProdPRWO.XTCTabPR.SelectedTabPageIndex = 0 Then
                If check_edit_report_status(FormProdPRWO.GVMatPR.GetFocusedRowCellValue("id_report_status"), "50", FormProdPRWO.GVMatPR.GetFocusedRowCellDisplayText("id_pr_prod_order")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this payment request?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_pr_prod_order As String = FormProdPRWO.GVMatPR.GetFocusedRowCellDisplayText("id_pr_prod_order")
                            query = String.Format("DELETE FROM tb_pr_prod_order WHERE id_pr_prod_order ='{0}'", id_pr_prod_order)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("50", id_pr_prod_order)

                            FormProdPRWO.view_pr()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This data already processed.")
                End If
            ElseIf FormProdPRWO.XTCTabPR.SelectedTabPageIndex = 2 Then
                If check_edit_report_status(FormProdPRWO.GVPRPO.GetFocusedRowCellValue("id_report_status"), "50", FormProdPRWO.GVPRPO.GetFocusedRowCellDisplayText("id_pr_prod_order")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this payment request?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_pr_prod_order As String = FormProdPRWO.GVPRPO.GetFocusedRowCellDisplayText("id_pr_prod_order")
                            query = String.Format("DELETE FROM tb_pr_prod_order WHERE id_pr_prod_order ='{0}'", id_pr_prod_order)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("50", id_pr_prod_order)

                            FormProdPRWO.view_pr_courier()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This data already processed.")
                End If
            ElseIf FormProdPRWO.XTCTabPR.SelectedTabPageIndex = 3 Then
                If check_edit_report_status(FormProdPRWO.GVPRNoReff.GetFocusedRowCellValue("id_report_status"), "50", FormProdPRWO.GVPRNoReff.GetFocusedRowCellDisplayText("id_pr_prod_order")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this payment request?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_pr_prod_order As String = FormProdPRWO.GVPRNoReff.GetFocusedRowCellDisplayText("id_pr_prod_order")
                            query = String.Format("DELETE FROM tb_pr_prod_order WHERE id_pr_prod_order ='{0}'", id_pr_prod_order)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("50", id_pr_prod_order)

                            FormProdPRWO.view_pr_no_reff()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This data already processed.")
                End If
            End If
        ElseIf formName = "FormSalesInvoice" Then
            'SALES INVOICE
            If check_edit_report_status(FormSalesInvoice.GVSalesInvoice.GetFocusedRowCellValue("id_report_status"), "51", FormSalesInvoice.GVSalesInvoice.GetFocusedRowCellValue("id_sales_invoice")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sales_invoice As String = FormSalesInvoice.GVSalesInvoice.GetFocusedRowCellValue("id_sales_invoice").ToString
                        query = String.Format("DELETE FROM tb_sales_invoice WHERE id_sales_invoice ='{0}'", id_sales_invoice)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("51", id_sales_invoice)
                        FormSalesInvoice.viewSalesInvoice()
                        'FormSalesReturnQC.viewSalesReturnOrder()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormFGStockOpnameStore" Then
            If check_edit_report_status(FormFGStockOpnameStore.GVSOStore.GetFocusedRowCellValue("id_report_status"), "53", FormFGStockOpnameStore.GVSOStore.GetFocusedRowCellValue("id_fg_so_store")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_fg_so_store As String = FormFGStockOpnameStore.GVSOStore.GetFocusedRowCellValue("id_fg_so_store").ToString
                        query = String.Format("DELETE FROM tb_fg_so_store WHERE id_fg_so_store ='{0}'", id_fg_so_store)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("53", id_fg_so_store)
                        FormFGStockOpnameStore.viewSoStore()
                        'FormSalesReturnQC.viewSalesReturnOrder()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormFGMissing" Then
            'FG MISSING
            If FormFGMissing.XTCFGMissing.SelectedTabPageIndex = 0 Then
                If check_edit_report_status(FormFGMissing.GVFGMissing.GetFocusedRowCellValue("id_report_status"), "54", FormFGMissing.GVFGMissing.GetFocusedRowCellValue("id_sales_pos")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_fg_missing As String = FormFGMissing.GVFGMissing.GetFocusedRowCellValue("id_sales_pos").ToString

                            'cancelled
                            Dim cancel_rsv_stock As ClassSalesInv = New ClassSalesInv()
                            cancel_rsv_stock.cancelReservedStock(id_fg_missing, "54")


                            query = String.Format("DELETE FROM tb_sales_pos WHERE id_sales_pos ='{0}'", id_fg_missing)
                            execute_non_query(query, True, "", "", "", "")

                            'utk missing terkait stock opname
                            query = String.Format("UPDATE tb_fg_so_store SET id_sales_pos_ref=NULL WHERE id_sales_pos_ref='{0}'", id_fg_missing)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("54", id_fg_missing)
                            FormFGMissing.viewFGMissing()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This data already marked")
                End If
            ElseIf FormFGMissing.XTCFGMissing.SelectedTabPageIndex = 1 Then
                If check_edit_report_status(FormFGMissing.GVMissingWH.GetFocusedRowCellValue("id_report_status"), "77", FormFGMissing.GVMissingWH.GetFocusedRowCellValue("id_sales_pos")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_fg_missing As String = FormFGMissing.GVMissingWH.GetFocusedRowCellValue("id_sales_pos").ToString
                            query = String.Format("DELETE FROM tb_sales_pos WHERE id_sales_pos ='{0}'", id_fg_missing)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("77", id_fg_missing)

                            'update ref in stock opname
                            query = String.Format("UPDATE tb_sales_pos SET id_sales_pos_ref=NULL WHERE id_sales_pos_ref ='{0}'", id_fg_missing)
                            execute_non_query(query, True, "", "", "", "")

                            FormFGMissing.viewFGMissingWH()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This data already marked")
                End If
            End If
        ElseIf formName = "FormFGMissingInvoice" Then
            'FG MISSING INVOICE
            If check_edit_report_status(FormFGMissingInvoice.GVFGMissingInvoice.GetFocusedRowCellValue("id_report_status"), "55", FormFGMissingInvoice.GVFGMissingInvoice.GetFocusedRowCellValue("id_fg_missing_invoice")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_fg_missing_invoice As String = FormFGMissingInvoice.GVFGMissingInvoice.GetFocusedRowCellValue("id_fg_missing_invoice").ToString
                        query = String.Format("DELETE FROM tb_fg_missing_invoice WHERE id_fg_missing_invoice ='{0}'", id_fg_missing_invoice)
                        execute_non_query(query, True, "", "", "", "")

                        query = String.Format("UPDATE tb_fg_so_store SET id_sales_pos_ref=NULL WHERE id_sales_pos_ref='{0}'", id_fg_missing_invoice)
                        execute_non_query(query, True, "", "", "", "")
                        'del mark
                        delete_all_mark_related("55", id_fg_missing_invoice)
                        FormFGMissingInvoice.viewFGMissingInvoice()
                        'FormSalesReturnQC.viewSalesReturnOrder()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormFGStockOpnameWH" Then
            'WH STOCK OPNAME
            If check_edit_report_status(FormFGStockOpnameWH.GVSOWH.GetFocusedRowCellValue("id_report_status"), "56", FormFGStockOpnameWH.GVSOWH.GetFocusedRowCellValue("id_fg_so_wh")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_fg_so_wh As String = FormFGStockOpnameWH.GVSOWH.GetFocusedRowCellValue("id_fg_so_wh").ToString
                        query = String.Format("DELETE FROM tb_fg_so_wh WHERE id_fg_so_wh ='{0}'", id_fg_so_wh)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("56", id_fg_so_wh)
                        FormFGStockOpnameWH.viewSOWH()
                        'FormSalesReturnQC.viewSalesReturnOrder()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormMatStockOpname" Then
            If check_edit_report_status(FormMatStockOpname.GVMatPR.GetFocusedRowCellValue("id_report_status"), "52", FormMatStockOpname.GVMatPR.GetFocusedRowCellDisplayText("id_mat_so")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this stock opname?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_mat_so As String = FormMatStockOpname.GVMatPR.GetFocusedRowCellDisplayText("id_mat_so")
                        query = String.Format("DELETE FROM tb_mat_so WHERE id_mat_so ='{0}'", id_mat_so)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("52", id_mat_so)

                        FormMatStockOpname.view_so()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormFGAdj" Then
            'FG Adjustment
            If FormFGAdj.XTCAdj.SelectedTabPageIndex = 0 Then 'Adj In
                Dim id_adj_in_fg As String = FormFGAdj.GVAdjIn.GetFocusedRowCellValue("id_adj_in_fg").ToString
                Dim id_report_status As String = FormFGAdj.GVAdjIn.GetFocusedRowCellValue("id_report_status").ToString

                If Not check_edit_report_status(id_report_status, "41", id_adj_in_fg) Or id_report_status = "5" Then
                    stopCustom("This data already locked.")
                Else
                    confirm = XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        Try
                            Cursor = Cursors.WaitCursor

                            'main
                            query = String.Format("DELETE FROM tb_adj_in_fg WHERE id_adj_in_fg = '{0}'", id_adj_in_fg)
                            execute_non_query(query, True, "", "", "", "")
                            'del mark
                            delete_all_mark_related("41", id_adj_in_fg)
                            'Refresh
                            FormFGAdj.viewAdjIn()
                            Cursor = Cursors.Default
                        Catch ex As Exception
                            Cursor = Cursors.Default
                            errorDelete()
                        End Try
                        Cursor = Cursors.Default
                    End If
                End If
            ElseIf FormFGAdj.XTCAdj.SelectedTabPageIndex = 1 Then 'Adj Out
                Dim id_adj_out_fg As String = FormFGAdj.GVAdjOut.GetFocusedRowCellDisplayText("id_adj_out_fg").ToString
                Dim id_report_status As String = FormFGAdj.GVAdjOut.GetFocusedRowCellValue("id_report_status").ToString

                If Not check_edit_report_status(id_report_status, "42", id_adj_out_fg) Or id_report_status = "5" Then
                    stopCustom("This data already locked.")
                Else
                    confirm = XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        Try
                            Cursor = Cursors.WaitCursor
                            'stock
                            Dim query_cancel As String = "SELECT * FROM tb_adj_out_fg a "
                            query_cancel += "INNER JOIN tb_adj_out_fg_det b ON a.id_adj_out_fg = b.id_adj_out_fg "
                            query_cancel += "WHERE a.id_adj_out_fg = '" + id_adj_out_fg + "' "
                            Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                            For i As Integer = 0 To (data.Rows.Count - 1)
                                Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                                Dim id_product As String = data.Rows(i)("id_product").ToString
                                Dim adj_out_fg_det_qty As Decimal = data.Rows(i)("adj_out_fg_det_qty")
                                Dim bom_unit_price As Decimal = data.Rows(i)("adj_out_fg_det_price")
                                Dim adj_out_fg_number As String = data.Rows(i)("adj_out_fg_number").ToString

                                Dim query_upd_storage As String = "INSERT tb_storage_fg(id_wh_drawer, id_storage_category, id_product, storage_product_qty, storage_product_datetime, storage_product_notes, bom_unit_price, id_stock_status, report_mark_type, id_report) "
                                query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_product + "', '" + decimalSQL(adj_out_fg_det_qty.ToString) + "', NOW(), 'Finished Goods Adjustment Out cancelled, Adjustment Out : " + adj_out_fg_number + "','" & decimalSQL(bom_unit_price.ToString) & "','2','42','" & id_adj_out_fg & "')"
                                execute_non_query(query_upd_storage, True, "", "", "", "")
                            Next

                            'main
                            query = String.Format("DELETE FROM tb_adj_out_fg WHERE id_adj_out_fg = '{0}'", id_adj_out_fg)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("42", id_adj_out_fg)

                            'Refresh data
                            FormFGAdj.viewAdjOut()
                            Cursor = Cursors.Default
                        Catch ex As Exception
                            Cursor = Cursors.Default
                            errorDelete()
                        End Try
                        Cursor = Cursors.Default
                    End If
                End If
            End If
        ElseIf formName = "FormFGTrf" Then
            'FG TRF
            If check_edit_report_status(FormFGTrf.GVFGTrf.GetFocusedRowCellValue("id_report_status"), "57", FormFGTrf.GVFGTrf.GetFocusedRowCellValue("id_fg_trf")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_fg_trf As String = FormFGTrf.GVFGTrf.GetFocusedRowCellValue("id_fg_trf").ToString
                        Dim query_drawer As String = "SELECT c.fg_trf_number, b.id_product, a.id_wh_drawer, a.fg_trf_det_drawer_qty, a.bom_unit_price FROM tb_fg_trf_det_drawer a "
                        query_drawer += "INNER JOIN tb_fg_trf_det b ON a.id_fg_trf_det = b.id_fg_trf_det "
                        query_drawer += "INNER JOIN tb_fg_trf c ON c.id_fg_trf = b.id_fg_trf "
                        query_drawer += "WHERE b.id_fg_trf = '" + id_fg_trf + "' "
                        Dim data_drawer As DataTable = execute_query(query_drawer, -1, True, "", "", "", "")

                        'prepare rollback stock
                        Dim query_drawer_stock As String = ""
                        Dim jum_ins_c As Integer = 0
                        If data_drawer.Rows.Count > 0 Then
                            query_drawer_stock = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, storage_product_qty, storage_product_datetime, storage_product_notes, bom_unit_price, report_mark_type, id_report, id_stock_status) VALUES "
                        End If
                        For c As Integer = 0 To (data_drawer.Rows.Count - 1)
                            If c > 0 Then
                                query_drawer_stock += ", "
                            End If
                            query_drawer_stock += "('" + data_drawer(c)("id_wh_drawer").ToString + "', '1', '" + data_drawer(c)("id_product").ToString + "', '" + decimalSQL(data_drawer(c)("fg_trf_det_drawer_qty").ToString) + "', NOW(), 'Finished Goods Transfer No: " + data_drawer(c)("fg_trf_number").ToString + ", has been canceled', '" + decimalSQL(data_drawer(c)("bom_unit_price").ToString) + "', '57', '" + id_fg_trf + "', '2') "
                        Next

                        'excequte rollback
                        If data_drawer.Rows.Count > 0 Then
                            execute_non_query(query_drawer_stock, True, "", "", "", "")
                        End If

                        query = String.Format("DELETE FROM tb_fg_trf WHERE id_fg_trf ='{0}'", id_fg_trf)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("57", id_fg_trf)
                        FormFGTrf.viewFGTrf()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormFGTrfNew" Then
            'FG TRF
            If check_edit_report_status(FormFGTrfNew.GVFGTrf.GetFocusedRowCellValue("id_report_status"), "57", FormFGTrfNew.GVFGTrf.GetFocusedRowCellValue("id_fg_trf")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_fg_trf As String = FormFGTrfNew.GVFGTrf.GetFocusedRowCellValue("id_fg_trf").ToString

                        query = String.Format("DELETE FROM tb_fg_trf WHERE id_fg_trf ='{0}'", id_fg_trf)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("57", id_fg_trf)
                        FormFGTrfNew.viewFGTrf()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormMasterEmployee" Then
            'employee
            confirm = XtraMessageBox.Show("Are you sure want to delete this employee?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            Dim id_employee As String = FormMasterEmployee.GVEmployee.GetFocusedRowCellValue("id_employee").ToString
            Dim employee_code As String = FormMasterEmployee.GVEmployee.GetFocusedRowCellValue("employee_code").ToString
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    query = String.Format("DELETE FROM tb_m_employee WHERE id_employee = '{0}'", id_employee)
                    execute_non_query(query, True, "", "", "", "")

                    'delete fp
                    Try
                        Dim fp As New ClassFingerPrint()
                        Dim data_fp As DataTable = fp.get_fp_register()
                        fp.ip = data_fp.Rows(0)("ip").ToString
                        fp.port = data_fp.Rows(0)("port").ToString
                        fp.connect()
                        fp.disable_fp()
                        fp.deleteUserInfo(employee_code)
                        fp.refresh_fp()
                        fp.enable_fp()
                        fp.disconnect()
                    Catch ex As Exception
                        stopCustom(ex.ToString)
                    End Try

                    FormMasterEmployee.viewEmployee("-1")
                Catch ex As Exception
                    XtraMessageBox.Show("This employee already used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                Cursor = Cursors.Default
            End If
        ElseIf formName = "FormSampleDel" Then
            'PL SQAMPE DELIVERY (HANDOVER TO WH)
            If check_edit_report_status(FormSampleDel.GVSampleDel.GetFocusedRowCellValue("id_report_status"), "60", FormSampleDel.GVSampleDel.GetFocusedRowCellValue("id_sample_del")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sample_del As String = FormSampleDel.GVSampleDel.GetFocusedRowCellValue("id_sample_del").ToString
                        Dim query_drawer As String = "SELECT c.sample_del_number, b.id_sample, a.id_wh_drawer, a.sample_del_det_drawer_qty, a.id_sample_price, a.sample_price FROM tb_sample_del_det_drawer a "
                        query_drawer += "INNER JOIN tb_sample_del_det b ON a.id_sample_del_det = b.id_sample_del_det "
                        query_drawer += "INNER JOIN tb_sample_del c ON c.id_sample_del = b.id_sample_del "
                        query_drawer += "WHERE b.id_sample_del = '" + id_sample_del + "' "
                        Dim data_drawer As DataTable = execute_query(query_drawer, -1, True, "", "", "", "")

                        'prepare rollback stock
                        Dim query_drawer_stock As String = ""
                        Dim jum_ins_c As Integer = 0
                        If data_drawer.Rows.Count > 0 Then
                            query_drawer_stock = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes, id_sample_price, sample_price, report_mark_type, id_report, id_stock_status) VALUES "
                        End If
                        For c As Integer = 0 To (data_drawer.Rows.Count - 1)
                            If c > 0 Then
                                query_drawer_stock += ", "
                            End If
                            query_drawer_stock += "('" + data_drawer(c)("id_wh_drawer").ToString + "', '1', '" + data_drawer(c)("id_sample").ToString + "', '" + decimalSQL(data_drawer(c)("sample_del_det_drawer_qty").ToString) + "', NOW(), 'PL Sample Delivery No: " + data_drawer(c)("sample_del_number").ToString + ", has been canceled', '" + data_drawer(c)("id_sample_price").ToString + "','" + decimalSQL(data_drawer(c)("sample_price").ToString) + "', '60', '" + id_sample_del + "', '2') "
                        Next

                        'excequte rollback
                        If data_drawer.Rows.Count > 0 Then
                            execute_non_query(query_drawer_stock, True, "", "", "", "")
                        End If

                        query = String.Format("DELETE FROM tb_sample_del WHERE id_sample_del ='{0}'", id_sample_del)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("60", id_sample_del)
                        FormSampleDel.viewSampleDel()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormSampleDelRec" Then
            'REC PL SQAMPE DELIVERY (HANDOVER TO WH)
            If check_edit_report_status(FormSampleDelRec.GVSampleDelRec.GetFocusedRowCellValue("id_report_status"), "61", FormSampleDelRec.GVSampleDelRec.GetFocusedRowCellValue("id_sample_del_rec")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sample_del_rec As String = FormSampleDelRec.GVSampleDelRec.GetFocusedRowCellValue("id_sample_del_rec").ToString

                        query = String.Format("DELETE FROM tb_sample_del_rec WHERE id_sample_del_rec ='{0}'", id_sample_del_rec)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("61", id_sample_del_rec)
                        FormSampleDelRec.viewSampleDelRec()
                        FormSampleDelRec.viewSampleDel()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormSampleOrder" Then
            'Sales SAMPLE ORDER
            If check_edit_report_status(FormSampleOrder.GVSampleOrder.GetFocusedRowCellValue("id_report_status"), "62", FormSampleOrder.GVSampleOrder.GetFocusedRowCellValue("id_sample_order")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sample_order As String = FormSampleOrder.GVSampleOrder.GetFocusedRowCellValue("id_sample_order").ToString

                        query = String.Format("DELETE FROM tb_sample_order WHERE id_sample_order ='{0}'", id_sample_order)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("62", id_sample_order)
                        FormSampleOrder.viewSampleOrder()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormSampleDelOrder" Then
            'DELIVERY ORDER SAMPLE FOR SALES
            If FormSampleDelOrder.XTCSampleDelOrder.SelectedTabPageIndex = 0 Then
                If check_edit_report_status(FormSampleDelOrder.GVSampleDelOrder.GetFocusedRowCellValue("id_report_status"), "63", FormSampleDelOrder.GVSampleDelOrder.GetFocusedRowCellValue("id_pl_sample_order_del")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_pl_sample_order_del As String = FormSampleDelOrder.GVSampleDelOrder.GetFocusedRowCellValue("id_pl_sample_order_del").ToString

                            'prepare rollback stock
                            Dim query_c As ClassSampleDelOrder = New ClassSampleDelOrder
                            Dim query_drawer As String = query_c.queryDetailDrawer("AND a1.id_pl_sample_order_del = ''" + id_pl_sample_order_del + "''", "1")
                            Dim data_drawer As DataTable = execute_query(query_drawer, -1, True, "", "", "", "")
                            Dim query_drawer_stock As String = ""
                            Dim jum_ins_c As Integer = 0
                            If data_drawer.Rows.Count > 0 Then
                                query_drawer_stock = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes, id_sample_price, sample_price, report_mark_type, id_report, id_stock_status) VALUES "
                            End If
                            For c As Integer = 0 To (data_drawer.Rows.Count - 1)
                                If c > 0 Then
                                    query_drawer_stock += ", "
                                End If
                                query_drawer_stock += "('" + data_drawer(c)("id_wh_drawer").ToString + "', '1', '" + data_drawer(c)("id_sample").ToString + "', '" + decimalSQL(data_drawer(c)("qty_all_sample").ToString) + "', NOW(), 'Delivery Order Sample No: " + data_drawer(c)("pl_sample_order_del_number").ToString + ", has been canceled', '" + data_drawer(c)("id_sample_price").ToString + "','" + decimalSQL(data_drawer(c)("sample_price").ToString) + "', '63', '" + id_pl_sample_order_del + "', '2') "
                            Next
                            'excequte rollback
                            If data_drawer.Rows.Count > 0 Then
                                execute_non_query(query_drawer_stock, True, "", "", "", "")
                            End If

                            'delete DO
                            query = String.Format("DELETE FROM tb_pl_sample_order_del WHERE id_pl_sample_order_del ='{0}'", id_pl_sample_order_del)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("63", id_pl_sample_order_del)
                            FormSampleDelOrder.viewSampleDelOrder()
                            FormSampleDelOrder.viewSampleOrder()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This data already marked")
                End If
            End If

        ElseIf formName = "FormSampleStockOpname" Then
            'Sales SAMPLE ORDER
            If FormSampleStockOpname.GVSOWH.GetFocusedRowCellValue("id_lock").ToString = "2" Then
                stopCustom("This opname already locked")
            Else
                If check_edit_report_status(FormSampleStockOpname.GVSOWH.GetFocusedRowCellValue("id_report_status"), "64", FormSampleStockOpname.GVSOWH.GetFocusedRowCellValue("id_sample_so")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this opname?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_sample_so As String = FormSampleStockOpname.GVSOWH.GetFocusedRowCellValue("id_sample_so").ToString

                            query = String.Format("DELETE FROM tb_sample_so WHERE id_sample_so ='{0}'", id_sample_so)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("64", id_sample_so)
                            FormSampleStockOpname.viewSOWH()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This opname already marked")
                End If
            End If
        ElseIf formName = "FormFGCodeReplace" Then
            If FormFGCodeReplace.XTCFGCodeReplace.SelectedTabPageIndex = 0 Then
                'CODE REPLACEMENT
                If check_edit_report_status(FormFGCodeReplace.GVFGCodeReplaceStore.GetFocusedRowCellValue("id_report_status"), "65", FormFGCodeReplace.GVFGCodeReplaceStore.GetFocusedRowCellValue("id_fg_code_replace_store")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_fg_code_replace_store As String = FormFGCodeReplace.GVFGCodeReplaceStore.GetFocusedRowCellValue("id_fg_code_replace_store").ToString

                            query = String.Format("DELETE FROM tb_fg_code_replace_store WHERE id_fg_code_replace_store ='{0}'", id_fg_code_replace_store)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("65", id_fg_code_replace_store)
                            FormFGCodeReplace.viewCodeReplaceStore()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This data already marked")
                End If
            ElseIf FormFGCodeReplace.XTCFGCodeReplace.SelectedTabPageIndex = 1 Then
                If check_edit_report_status(FormFGCodeReplace.GVFGCodeReplaceWH.GetFocusedRowCellValue("id_report_status"), "68", FormFGCodeReplace.GVFGCodeReplaceWH.GetFocusedRowCellValue("id_fg_code_replace_wh")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_fg_code_replace_wh As String = FormFGCodeReplace.GVFGCodeReplaceWH.GetFocusedRowCellValue("id_fg_code_replace_wh").ToString

                            query = String.Format("DELETE FROM tb_fg_code_replace_wh WHERE id_fg_code_replace_wh ='{0}'", id_fg_code_replace_wh)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("68", id_fg_code_replace_wh)
                            FormFGCodeReplace.viewCodeReplaceWH()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This data already marked")
                End If
            End If
        ElseIf formName = "FormSalesCreditNote" Then
            If check_edit_report_status(FormSalesCreditNote.GVSalesPOS.GetFocusedRowCellValue("id_report_status"), "66", FormSalesCreditNote.GVSalesPOS.GetFocusedRowCellValue("id_sales_pos")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sales_pos As String = FormSalesCreditNote.GVSalesPOS.GetFocusedRowCellValue("id_sales_pos").ToString

                        query = String.Format("DELETE FROM tb_sales_pos WHERE id_sales_pos ='{0}'", id_sales_pos)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("66", id_sales_pos)
                        FormSalesCreditNote.viewSalesPOS()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormFGMissingCreditNote" Then
            'MISSING CREDIT NOTE
            If FormFGMissingCreditNote.XTCFGMissingCN.SelectedTabPageIndex = 0 Then
                If check_edit_report_status(FormFGMissingCreditNote.GVFGMissingCNStore.GetFocusedRowCellValue("id_report_status"), "67", FormFGMissingCreditNote.GVFGMissingCNStore.GetFocusedRowCellValue("id_sales_pos")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_sales_pos As String = FormFGMissingCreditNote.GVFGMissingCNStore.GetFocusedRowCellValue("id_sales_pos").ToString

                            query = String.Format("DELETE FROM tb_sales_pos WHERE id_sales_pos ='{0}'", id_sales_pos)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("67", id_sales_pos)
                            FormFGMissingCreditNote.viewFGMissingStoreCN()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This data already marked")
                End If
            ElseIf FormFGMissingCreditNote.XTCFGMissingCN.SelectedTabPageIndex = 1 Then

            End If
        ElseIf formName = "FormSOHPeriode" Then
            confirm = XtraMessageBox.Show("Are you sure want to delete this periode?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim id_soh_periode As String = FormSOHPeriode.GVSOHPeriode.GetFocusedRowCellValue("id_soh_periode").ToString

                    query = String.Format("DELETE FROM tb_soh_periode WHERE id_soh_periode ='{0}'", id_soh_periode)
                    execute_non_query(query, True, "", "", "", "")

                    'del mark
                    FormSOHPeriode.view_soh()
                Catch ex As Exception
                    errorDelete()
                End Try
            End If
        ElseIf formName = "FormSOH" Then
            confirm = XtraMessageBox.Show("Are you sure want to delete this SOH ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim id_soh As String = FormSOH.BGVSOH.GetFocusedRowCellValue("id_soh").ToString

                    query = String.Format("DELETE FROM tb_soh WHERE id_soh ='{0}'", id_soh)
                    execute_non_query(query, True, "", "", "", "")

                    'del mark
                    FormSOH.view_soh_periode(FormSOH.LESOHPeriode.EditValue)
                Catch ex As Exception
                    errorDelete()
                End Try
            End If
        ElseIf formName = "FormFGWoff" Then
            If check_edit_report_status(FormFGWoff.GVFGWoff.GetFocusedRowCellValue("id_report_status"), "69", FormFGWoff.GVFGWoff.GetFocusedRowCellValue("id_fg_woff")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_fg_woff As String = FormFGWoff.GVFGWoff.GetFocusedRowCellValue("id_fg_woff").ToString

                        'rollback reserved stock
                        Dim query_c As ClassFGWoff = New ClassFGWoff()
                        Dim query_roll As String = query_c.queryRollbackStock(id_fg_woff)
                        execute_non_query(query_roll, True, "", "", "", "")

                        'delete write off
                        query = String.Format("DELETE FROM tb_fg_woff WHERE id_fg_woff ='{0}'", id_fg_woff)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        FormFGWoff.viewFGWoff()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormFGProposePrice" Then
            'If check_edit_report_status(FormFGProposePrice.GVFGPropose.GetFocusedRowCellValue("id_report_status").ToString, "70", FormFGProposePrice.GVFGPropose.GetFocusedRowCellValue("id_fg_propose_price")) Then
            '    confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            '    If confirm = Windows.Forms.DialogResult.Yes Then
            '        Try
            '            Dim id_fg_propose_price As String = FormFGProposePrice.GVFGPropose.GetFocusedRowCellValue("id_fg_propose_price").ToString

            '            'delete write off
            '            query = String.Format("DELETE FROM tb_fg_propose_price WHERE id_fg_propose_price ='{0}'", id_fg_propose_price)
            '            execute_non_query(query, True, "", "", "", "")

            '            'del mark
            '            FormFGProposePrice.viewPropose()
            '        Catch ex As Exception
            '            errorDelete()
            '        End Try
            '    End If
            'Else
            '    stopCustom("This data already marked")
            'End If
        ElseIf formName = "FormMasterRetCode" Then
            confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim id_ret_code As String = FormMasterRetCode.GVRetCode.GetFocusedRowCellValue("id_ret_code").ToString

                    'delete write off
                    query = String.Format("DELETE FROM tb_lookup_ret_code WHERE id_ret_code ='{0}'", id_ret_code)
                    execute_non_query(query, True, "", "", "", "")

                    'del mark
                    FormMasterRetCode.viewRetCode()
                Catch ex As Exception
                    errorDelete()
                End Try
            End If
        ElseIf formName = "FormMasterRateStore" Then
            confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim id_store_rate As String = FormMasterRateStore.GVStoreRate.GetFocusedRowCellValue("id_store_rate").ToString

                    'delete write off
                    query = String.Format("DELETE FROM tb_lookup_store_rate WHERE id_store_rate ='{0}'", id_store_rate)
                    execute_non_query(query, True, "", "", "", "")

                    'del mark
                    FormMasterRateStore.viewRate()
                Catch ex As Exception
                    errorDelete()
                End Try
            End If
        ElseIf formName = "FormSampleOrdered" Then
            If check_edit_report_status(FormSampleOrdered.GVSampleOrder.GetFocusedRowCellValue("id_report_status").ToString, "71", FormSampleOrdered.GVSampleOrder.GetFocusedRowCellValue("id_sample_ordered")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sample_ordered As String = FormSampleOrdered.GVSampleOrder.GetFocusedRowCellValue("id_sample_ordered").ToString

                        'delete sample ordered
                        query = String.Format("DELETE FROM tb_sample_ordered WHERE id_sample_ordered ='{0}'", id_sample_ordered)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        FormSampleOrdered.viewSampleOrder()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormProdQCAdj" Then
            If FormProdQCAdj.XTCAdj.SelectedTabPageIndex = 0 Then 'QC adj IN
                If check_edit_report_status(FormProdQCAdj.GVAdjIn.GetFocusedRowCellValue("id_report_status"), "72", FormProdQCAdj.GVAdjIn.GetFocusedRowCellValue("id_prod_order_qc_adj_in")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_qc_adj_in As String = FormProdQCAdj.GVAdjIn.GetFocusedRowCellValue("id_prod_order_qc_adj_in").ToString

                            'delete write off
                            query = String.Format("DELETE FROM tb_prod_order_qc_adj_in WHERE id_prod_order_qc_adj_in ='{0}'", id_qc_adj_in)
                            execute_non_query(query, True, "", "", "", "")
                            '
                            delete_all_mark_related("72", id_qc_adj_in)
                            'del mark
                            FormProdQCAdj.viewAdjIn()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This data already marked")
                End If
            Else  'QC adj OUT
                If check_edit_report_status(FormProdQCAdj.GVAdjOut.GetFocusedRowCellValue("id_report_status"), "73", FormProdQCAdj.GVAdjOut.GetFocusedRowCellValue("id_prod_order_qc_adj_out")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_qc_adj_out As String = FormProdQCAdj.GVAdjOut.GetFocusedRowCellValue("id_prod_order_qc_adj_out").ToString

                            'delete write off
                            query = String.Format("DELETE FROM tb_prod_order_qc_adj_out WHERE id_prod_order_qc_adj_out ='{0}'", id_qc_adj_out)
                            execute_non_query(query, True, "", "", "", "")
                            '
                            delete_all_mark_related("73", id_qc_adj_out)
                            'del mark
                            FormProdQCAdj.viewAdjOut()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This data already marked")
                End If
            End If
        ElseIf formName = "FormSalesPromo" Then
            If check_edit_report_status(FormSalesPromo.GVSalesPOS.GetFocusedRowCellValue("id_report_status").ToString, "76", FormSalesPromo.GVSalesPOS.GetFocusedRowCellValue("id_sales_pos")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sales_pos As String = FormSalesPromo.GVSalesPOS.GetFocusedRowCellValue("id_sales_pos").ToString

                        'rollback stock
                        Dim rsv_stock As ClassSalesInv = New ClassSalesInv()
                        rsv_stock.cancelReservedStock(id_sales_pos, "76")

                        'delete sample ordered
                        query = String.Format("DELETE FROM tb_sales_pos WHERE id_sales_pos ='{0}'", id_sales_pos)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("76", id_sales_pos)
                        FormSalesPromo.viewSalesPOS()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormFGSalesOrderReff" Then
            If check_edit_report_status(FormFGSalesOrderReff.GVSOReff.GetFocusedRowCellValue("id_report_status"), "75", FormFGSalesOrderReff.GVSOReff.GetFocusedRowCellValue("id_fg_so_reff")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_fg_so_reff As String = FormFGSalesOrderReff.GVSOReff.GetFocusedRowCellValue("id_fg_so_reff").ToString

                        'delete 
                        query = String.Format("DELETE FROM tb_fg_so_reff WHERE id_fg_so_reff ='{0}'", id_fg_so_reff)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("75", id_fg_so_reff)

                        'del mark
                        FormFGSalesOrderReff.viewSOReff()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormMasterComputer" Then
            confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim id_computer As String = FormMasterComputer.GVComputer.GetFocusedRowCellValue("id_computer").ToString

                    'delete
                    query = String.Format("DELETE FROM tb_m_computer WHERE id_computer ='{0}'", id_computer)
                    execute_non_query(query, True, "", "", "", "")

                    'del mark
                    FormMasterComputer.viewComputer()
                Catch ex As Exception
                    errorDelete()
                End Try
            End If
        ElseIf formName = "FormAccountingFakturScan" Then
            confirm = XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            Dim id_acc_fak_scan As String = FormAccountingFakturScan.GVFak.GetFocusedRowCellValue("id_acc_fak_scan").ToString

            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    query = String.Format("DELETE FROM tb_a_acc_fak_scan WHERE id_acc_fak_scan = '{0}'", id_acc_fak_scan)
                    execute_non_query(query, True, "", "", "", "")
                    FormAccountingFakturScan.viewTrans()
                Catch ex As Exception
                    errorDelete()
                End Try
                Cursor = Cursors.Default
            End If
        ElseIf formName = "FormFGBorrowQCReq" Then
            'BORROW REQ FOR QC FRODICT
            confirm = XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            Dim id_borrow_qc_req As String = FormFGBorrowQCReq.GVBorrowReq.GetFocusedRowCellValue("id_borrow_qc_req").ToString

            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    query = String.Format("DELETE FROM tb_fg_borrow_qc_req WHERE id_borrow_qc_req = '{0}'", id_borrow_qc_req)
                    execute_non_query(query, True, "", "", "", "")
                    FormFGBorrowQCReq.viewBorrowReq()
                Catch ex As Exception
                    errorDelete()
                End Try
                Cursor = Cursors.Default
            End If
        ElseIf formName = "FormWHAWBill" Then
            If FormWHAWBill.XTCAwb.SelectedTabPageIndex = 0 Then
                'confirm = XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                'Dim id_awbill As String = FormWHAWBill.GVAWBill.GetFocusedRowCellValue("id_awbill").ToString

                'If confirm = Windows.Forms.DialogResult.Yes Then
                '    Cursor = Cursors.WaitCursor
                '    Try
                '        query = String.Format("DELETE FROM tb_wh_awbill WHERE id_awbill = '{0}'", id_awbill)
                '        execute_non_query(query, True, "", "", "", "")
                '        FormWHAWBill.load_outbound()
                '    Catch ex As Exception
                '        errorDelete()
                '    End Try
                '    Cursor = Cursors.Default
                'End If
            Else
                'confirm = XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                'Dim id_awbill As String = FormWHAWBill.GVAwbillIn.GetFocusedRowCellValue("id_awbill").ToString

                'If confirm = Windows.Forms.DialogResult.Yes Then
                '    Cursor = Cursors.WaitCursor
                '    Try
                '        query = String.Format("DELETE FROM tb_wh_awbill WHERE id_awbill = '{0}'", id_awbill)
                '        execute_non_query(query, True, "", "", "", "")
                '        FormWHAWBill.load_inbound()
                '    Catch ex As Exception
                '        errorDelete()
                '    End Try
                '    Cursor = Cursors.Default
                'End If
            End If
        ElseIf formName = "FormMasterPrice" Then
            If check_edit_report_status(FormMasterPrice.GVPrice.GetFocusedRowCellValue("id_report_status").ToString, "82", FormMasterPrice.GVPrice.GetFocusedRowCellValue("id_fg_price")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_fg_price As String = FormMasterPrice.GVPrice.GetFocusedRowCellValue("id_fg_price").ToString

                        'delete write off
                        query = String.Format("DELETE FROM tb_fg_price WHERE id_fg_price ='{0}'", id_fg_price)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("82", id_fg_price)
                        FormMasterPrice.viewPrice()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormSamplePLToWH" Then
            'PACING LIST SAMPLE
            If check_edit_report_status(FormSamplePLToWH.GVSamplePL.GetFocusedRowCellValue("id_sample_pl").ToString, "85", FormSamplePLToWH.GVSamplePL.GetFocusedRowCellValue("id_sample_pl")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sample_pl As String = FormSamplePLToWH.GVSamplePL.GetFocusedRowCellValue("id_sample_pl").ToString

                        'rollback stock
                        Dim rsv_stock As ClassSamplePLtoWH = New ClassSamplePLtoWH()
                        rsv_stock.cancelReservedStock(id_sample_pl, "85")

                        'delete 
                        query = String.Format("DELETE FROM tb_sample_pl WHERE id_sample_pl ='{0}'", id_sample_pl)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("85", id_sample_pl)
                        FormSamplePLToWH.viewSamplePL()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormMasterPriceSample" Then
            If check_edit_report_status(FormMasterPriceSample.GVPrice.GetFocusedRowCellValue("id_report_status").ToString, "86", FormMasterPriceSample.GVPrice.GetFocusedRowCellValue("id_sample_price")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sample_price As String = FormMasterPriceSample.GVPrice.GetFocusedRowCellValue("id_sample_price").ToString

                        'delete write off
                        query = String.Format("DELETE FROM tb_sample_price WHERE id_sample_price ='{0}'", id_sample_price)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("86", id_sample_price)
                        FormMasterPriceSample.viewPrice()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormFGWHAlloc" Then
            'INVENTORY ALLOCATION
            If check_edit_report_status(FormFGWHAlloc.GVFGWHAlloc.GetFocusedRowCellValue("id_report_status").ToString, "87", FormFGWHAlloc.GVFGWHAlloc.GetFocusedRowCellValue("id_fg_wh_alloc")) Then
                confirm = XtraMessageBox.Show("Are you sure you want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_fg_wh_alloc As String = FormFGWHAlloc.GVFGWHAlloc.GetFocusedRowCellValue("id_fg_wh_alloc").ToString
                        Dim is_submit As String = FormFGWHAlloc.GVFGWHAlloc.GetFocusedRowCellValue("is_submit").ToString

                        'cancel reserved
                        If is_submit = "1" Then
                            'cancelled
                            Dim cancel_rsv_stock As ClassFGWHAlloc = New ClassFGWHAlloc()
                            cancel_rsv_stock.cancelReservedStock(id_fg_wh_alloc)
                        End If

                        'delete 
                        query = String.Format("DELETE FROM tb_fg_wh_alloc WHERE id_fg_wh_alloc ='{0}'", id_fg_wh_alloc)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("87", id_fg_wh_alloc)
                        FormFGWHAlloc.viewFGWHAlloc()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormSampleReturnPL" Then
            'PACING LIST SAMPLE
            If check_edit_report_status(FormSampleReturnPL.GVSamplePL.GetFocusedRowCellValue("id_report_status").ToString, "89", FormSampleReturnPL.GVSamplePL.GetFocusedRowCellValue("id_sample_pl_ret")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sample_pl_ret As String = FormSampleReturnPL.GVSamplePL.GetFocusedRowCellValue("id_sample_pl_ret").ToString
                        'delete 
                        query = String.Format("DELETE FROM tb_sample_pl_ret WHERE id_sample_pl_ret ='{0}'", id_sample_pl_ret)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("89", id_sample_pl_ret)
                        FormSampleReturnPL.viewSamplePL()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormFGDesignList" Then
            If FormFGDesignList.XTPDesign.SelectedTabPageIndex = 0 Then
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_design As String = FormFGDesignList.GVDesign.GetFocusedRowCellValue("id_design").ToString
                        query = String.Format("DELETE FROM tb_m_design WHERE id_design='{0}'", id_design)
                        execute_non_query(query, True, "", "", "", "")
                        FormFGDesignList.viewData()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else

            End If
        ElseIf formName = "FormEmpShift" Then
            confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = DialogResult.Yes Then
                Try
                    Dim id_shift As String = FormEmpShift.GVShift.GetFocusedRowCellValue("id_shift").ToString
                    query = String.Format("DELETE FROM tb_emp_shift WHERE id_shift='{0}'", id_shift)
                    execute_non_query(query, True, "", "", "", "")
                    FormEmpShift.load_schedule()
                Catch ex As Exception
                    errorDelete()
                End Try
            End If
        ElseIf formName = "FormEmpHoliday" Then
            confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = DialogResult.Yes Then
                Try
                    Dim id_holiday As String = FormEmpHoliday.GVHoliday.GetFocusedRowCellValue("id_emp_holiday").ToString
                    query = String.Format("DELETE FROM tb_emp_holiday WHERE id_emp_holiday='{0}'", id_holiday)
                    execute_non_query(query, True, "", "", "", "")
                    FormEmpHoliday.view_holiday()
                Catch ex As Exception
                    errorDelete()
                End Try
            End If
        ElseIf formName = "FormFGRepair" Then
            If check_edit_report_status(FormFGRepair.GVRepair.GetFocusedRowCellValue("id_report_status").ToString, "91", FormFGRepair.GVRepair.GetFocusedRowCellValue("id_fg_repair")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_fg_repair As String = FormFGRepair.GVRepair.GetFocusedRowCellValue("id_fg_repair").ToString

                        'cancel reserve
                        Dim cancel As New ClassFGRepair()
                        cancel.cancelReservedStock(id_fg_repair)

                        query = String.Format("DELETE FROM tb_fg_repair WHERE id_fg_repair='{0}'", id_fg_repair)
                        execute_non_query(query, True, "", "", "", "")
                        FormFGRepair.viewData()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormFGRepairRec" Then
            If check_edit_report_status(FormFGRepairRec.GVRepairRec.GetFocusedRowCellValue("id_report_status").ToString, "92", FormFGRepairRec.GVRepairRec.GetFocusedRowCellValue("id_fg_repair_rec")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_fg_repair_rec As String = FormFGRepairRec.GVRepairRec.GetFocusedRowCellValue("id_fg_repair_rec").ToString

                        query = String.Format("DELETE FROM tb_fg_repair_rec WHERE id_fg_repair_rec='{0}'", id_fg_repair_rec)
                        execute_non_query(query, True, "", "", "", "")
                        FormFGRepairRec.viewData()
                        FormFGRepairRec.viewRepairList()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormFGRepairReturnRec" Then
            If check_edit_report_status(FormFGRepairReturnRec.GVRepairRec.GetFocusedRowCellValue("id_report_status").ToString, "94", FormFGRepairReturnRec.GVRepairRec.GetFocusedRowCellValue("id_fg_repair_return_rec")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_fg_repair_return_rec As String = FormFGRepairReturnRec.GVRepairRec.GetFocusedRowCellValue("id_fg_repair_return_rec").ToString

                        query = String.Format("DELETE FROM tb_fg_repair_return_rec WHERE id_fg_repair_return_rec='{0}'", id_fg_repair_return_rec)
                        execute_non_query(query, True, "", "", "", "")
                        FormFGRepairReturnRec.viewData()
                        FormFGRepairReturnRec.viewRepairList()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormFGRepairReturn" Then
            If check_edit_report_status(FormFGRepairReturn.GVRepairReturn.GetFocusedRowCellValue("id_report_status").ToString, "93", FormFGRepairReturn.GVRepairReturn.GetFocusedRowCellValue("id_fg_repair_return")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_fg_repair_return As String = FormFGRepairReturn.GVRepairReturn.GetFocusedRowCellValue("id_fg_repair_return").ToString

                        'cancel reserve
                        Dim cancel As New ClassFGRepairReturn()
                        cancel.cancelReservedStock(id_fg_repair_return)

                        query = String.Format("DELETE FROM tb_fg_repair_return WHERE id_fg_repair_return='{0}'", id_fg_repair_return)
                        execute_non_query(query, True, "", "", "", "")
                        FormFGRepairReturn.viewData()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormEmpEmail" Then
            Dim type As String = FormEmpEmail.GVEmail.GetFocusedRowCellValue("type").ToString
            If type = "1" Then
                stopCustom("You don't have permission to delete this data")
            Else
                Dim id As String = FormEmpEmail.GVEmail.GetFocusedRowCellValue("id_other_email").ToString
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Dim query_del As String = "DELETE FROM tb_m_other_email WHERE id_other_email='" + id + "'"
                    execute_non_query(query_del, True, "", "", "", "")
                    FormEmpEmail.viewEmployee("-1")
                End If
            End If
        ElseIf formName = "FormEmpLeave" Then
            '
        ElseIf formName = "FormWHDelEmpty" Then

        ElseIf formName = "FormEmpDP" Then
            If check_edit_report_status(FormEmpDP.GVLeave.GetFocusedRowCellValue("id_report_status").ToString, "97", FormEmpDP.GVLeave.GetFocusedRowCellValue("id_dp")) Then
                Dim id As String = FormEmpDP.GVLeave.GetFocusedRowCellValue("id_dp").ToString
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = DialogResult.Yes Then
                    Dim query_del As String = "DELETE FROM tb_emp_dp WHERE id_dp='" + id + "'"
                    execute_non_query(query_del, True, "", "", "", "")
                    FormEmpDP.load_dp()
                End If
            Else
                stopCustom("This report already approved.")
            End If
        ElseIf formName = "FormDeliveryCargo" Then
            If check_edit_report_status(FormDeliveryCargo.GVDeliverySlip.GetFocusedRowCellValue("id_report_status").ToString, "112", FormDeliveryCargo.GVDeliverySlip.GetFocusedRowCellValue("id_awbill")) Then
                Dim id As String = FormDeliveryCargo.GVDeliverySlip.GetFocusedRowCellValue("id_awbill").ToString
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = DialogResult.Yes Then
                    Dim query_del As String = "DELETE FROM tb_awbill WHERE id_awbill='" + id + "'"
                    execute_non_query(query_del, True, "", "", "", "")
                    '
                    FormDeliveryCargo.load_awb()
                End If
            Else
                stopCustom("This report already approved.")
            End If
        ElseIf formName = "FormEmpUniPeriod" Then
            confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim id_emp_uni_period As String = FormEmpUniPeriod.GVUni.GetFocusedRowCellValue("id_emp_uni_period").ToString

                    query = String.Format("DELETE FROM tb_emp_uni_period WHERE id_emp_uni_period='{0}'", id_emp_uni_period)
                    execute_non_query(query, True, "", "", "", "")
                    FormEmpUniPeriod.viewUniformPeriod()
                Catch ex As Exception
                    errorDelete()
                End Try
            End If
        ElseIf formName = "FormEmpLeaveCut" Then
            If check_edit_report_status(FormEmpLeaveCut.GVPayrollPeriode.GetFocusedRowCellValue("id_report_status").ToString, "125", FormEmpLeaveCut.GVPayrollPeriode.GetFocusedRowCellValue("id_leave_cut")) Then
                Dim id As String = FormEmpLeaveCut.GVPayrollPeriode.GetFocusedRowCellValue("id_leave_cut").ToString
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = DialogResult.Yes Then
                    Dim query_del As String = "DELETE FROM tb_emp_leave_cut WHERE id_leave_cut='" + id + "'"
                    execute_non_query(query_del, True, "", "", "", "")
                    FormEmpLeaveCut.load_leave_cut()
                End If
            Else
                stopCustom("This report already approved.")
            End If
        ElseIf formName = "FormMasterAssetCategory" Then
            Dim id As String = FormMasterAssetCategory.GVAssetCat.GetFocusedRowCellValue("id_asset_cat").ToString
            confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = DialogResult.Yes Then
                Dim query_del As String = "DELETE FROM tb_a_asset_cat WHERE id_asset_cat='" + id + "'"
                execute_non_query(query_del, True, "", "", "", "")
                FormMasterAssetCategory.load_cat()
            End If
        ElseIf formName = "FormMasterAsset" Then
            Dim id As String = FormMasterAsset.GVAsset.GetFocusedRowCellValue("id_asset").ToString
            confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = DialogResult.Yes Then
                Dim query_del As String = "DELETE FROM tb_a_asset WHERE id_asset='" + id + "'"
                execute_non_query(query_del, True, "", "", "", "")
                FormMasterAsset.load_asset("2")
            End If
        ElseIf formName = "FormAssetPO" Then
            Dim id As String = FormAssetPO.GVPOList.GetFocusedRowCellValue("id_asset_po").ToString
            confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = DialogResult.Yes Then
                Dim query_del As String = "DELETE FROM tb_a_asset_po WHERE id_asset_po='" + id + "'"
                execute_non_query(query_del, True, "", "", "", "")
                FormAssetPO.load_po()
            End If
        ElseIf formName = "FormAssetRec" Then
            Dim id As String = FormAssetRec.GVRecList.GetFocusedRowCellValue("id_asset_rec").ToString
            confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = DialogResult.Yes Then
                Dim query_del As String = "DELETE FROM tb_a_asset_rec WHERE id_asset_rec='" + id + "'"
                execute_non_query(query_del, True, "", "", "", "")
                FormAssetRec.load_rec()
            End If
        ElseIf formName = "FormPurcReq" Then
            If check_edit_report_status(FormPurcReq.GVPurcReq.GetFocusedRowCellValue("id_report_status").ToString, FormPurcReq.GVPurcReq.GetFocusedRowCellValue("pr_report_mark_type").ToString, FormPurcReq.GVPurcReq.GetFocusedRowCellValue("id_purc_req")) Then
                Dim id As String = FormPurcReq.GVPurcReq.GetFocusedRowCellValue("id_purc_req").ToString
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = DialogResult.Yes Then
                    Dim query_del As String = "DELETE FROM tb_purc_req WHERE id_purc_req='" + id + "'"
                    execute_non_query(query_del, True, "", "", "", "")
                    delete_all_mark_related(FormPurcReq.GVPurcReq.GetFocusedRowCellValue("pr_report_mark_type").ToString, id)
                    FormPurcReq.load_req()
                End If
            Else
                stopCustom("This report already approved.")
            End If
        ElseIf formName = "FormPurcOrder" Then
            If check_edit_report_status(FormPurcOrder.GVPO.GetFocusedRowCellValue("id_report_status").ToString, "139", FormPurcOrder.GVPO.GetFocusedRowCellValue("id_purc_order")) Then
                Dim id As String = FormPurcReq.GVPurcReq.GetFocusedRowCellValue("id_purc_req").ToString
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = DialogResult.Yes Then
                    Dim query_del As String = "DELETE FROM tb_purc_req WHERE id_purc_req='" + id + "'"
                    execute_non_query(query_del, True, "", "", "", "")
                    FormPurcReq.load_req()
                End If
            Else
                stopCustom("This report already approved.")
            End If
        ElseIf formName = "FormEmpUniSumReport" Then
        ElseIf formName = "FormSampleExpense" Then
            If check_edit_report_status(FormSampleExpense.GVPurchaseList.GetFocusedRowCellValue("id_report_status").ToString, "179", FormSampleExpense.GVPurchaseList.GetFocusedRowCellValue("id_sample_purc_mat")) Then
                Dim id As String = FormSampleExpense.GVPurchaseList.GetFocusedRowCellValue("id_sample_purc_mat").ToString
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = DialogResult.Yes Then
                    Dim query_del As String = "DELETE FROM tb_sample_purc_mat WHERE id_sample_purc_mat='" + id + "'"
                    execute_non_query(query_del, True, "", "", "", "")
                    FormSampleExpense.load_purc("2")
                End If
            Else
                stopCustom("This report already approved.")
            End If
        ElseIf formName = "FormFGLinePlan" Then
            'line plan delete
            FormFGLinePlan.GVData.CloseEditor()

            makeSafeGV(FormFGLinePlan.GVData)
            FormFGLinePlan.GVData.ActiveFilterString = "[is_select]='Yes' "
            If FormFGLinePlan.GVData.RowCount > 0 Then
                confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete " + FormFGLinePlan.GVData.RowCount.ToString + " item(s)", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Dim id As String = ""
                    For i As Integer = 0 To FormFGLinePlan.GVData.RowCount - 1
                        If i > 0 Then
                            id += "OR "
                        End If
                        id += "id_fg_line_plan='" + FormFGLinePlan.GVData.GetRowCellValue(i, "id_fg_line_plan").ToString + "' "
                    Next
                    Dim qd As String = "DELETE FROM tb_fg_line_plan WHERE " + id + " "
                    execute_non_query(qd, True, "", "", "", "")
                End If
            Else
                stopCustom("No data selected")
            End If
            FormFGLinePlan.GVData.ActiveFilterString = ""
            FormFGLinePlan.viewData()
        ElseIf formName = "FormWorkOrder" Then
            If check_edit_report_status(FormWorkOrder.GVWorkOrder.GetFocusedRowCellValue("id_work_order").ToString, "179", FormWorkOrder.GVWorkOrder.GetFocusedRowCellValue("id_work_order")) Then
                Dim id As String = FormSampleExpense.GVPurchaseList.GetFocusedRowCellValue("id_sample_purc_mat").ToString
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = DialogResult.Yes Then
                    Dim query_del As String = "DELETE FROM tb_sample_purc_mat WHERE id_sample_purc_mat='" + id + "'"
                    execute_non_query(query_del, True, "", "", "", "")
                    FormSampleExpense.load_purc("2")
                End If
            Else
                stopCustom("This report already approved.")
            End If
        ElseIf formName = "FormVoucherPOS" Then
            'Voucher POS
        ElseIf formName = "FormPromoRules" Then
            If FormPromoRules.GVRules.RowCount > 0 And FormPromoRules.GVRules.FocusedRowHandle >= 0 Then
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = DialogResult.Yes Then
                    'hapus di toko
                    Dim id As String = FormPromoRules.GVRules.GetFocusedRowCellValue("id_rules").ToString
                    Dim qold As String = "SELECT * 
                    FROM tb_promo_rules_det rd
                    INNER JOIN tb_store_conn c ON c.id_outlet = rd.id_outlet
                    WHERE rd.id_rules=" + id + " "
                    Dim dold As DataTable = execute_query(qold, -1, True, "", "", "", "")
                    For i As Integer = 0 To dold.Rows.Count - 1
                        Dim id_outlet As String = dold.Rows(i)("id_outlet").ToString
                        Dim host As String = dold.Rows(i)("host").ToString
                        Dim username As String = dold.Rows(i)("username").ToString
                        Dim pass As String = dold.Rows(i)("pass").ToString
                        Dim db As String = dold.Rows(i)("db").ToString

                        Dim qds As String = "DELETE FROM tb_promo_rules WHERE id_rules='" + id + "' "
                        execute_non_query_long(qds, False, host, username, pass, db)
                    Next
                    Dim query_del As String = "DELETE FROM tb_promo_rules WHERE id_rules='" + id + "' "
                    Try
                        execute_non_query(query_del, True, "", "", "", "")
                        FormPromoRules.viewRules()
                        FormPromoRules.viewStore()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            End If
        ElseIf formName = "FormCompanyEmailMapping" Then
            confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = DialogResult.Yes Then
                If FormCompanyEmailMapping.XtraTabControl.SelectedTabPageIndex = 0 Then
                    If FormCompanyEmailMapping.GVListStoreGroup.RowCount > 0 And FormCompanyEmailMapping.GVListStoreGroup.FocusedRowHandle >= 0 Then
                        Dim query_del As String = "DELETE FROM tb_mail_manage_mapping WHERE id_mail_manage_mapping = " + FormCompanyEmailMapping.GVListStoreGroup.GetFocusedRowCellValue("id_mail_manage_mapping").ToString
                        execute_non_query(query_del, True, "", "", "", "")

                        FormCompanyEmailMapping.form_load()
                    End If
                Else
                    If FormCompanyEmailMapping.GVListInternal.RowCount > 0 And FormCompanyEmailMapping.GVListInternal.FocusedRowHandle >= 0 Then
                        Dim query_del As String = "DELETE FROM tb_mail_manage_mapping_intern WHERE id_mail_manage_mapping_intern = " + FormCompanyEmailMapping.GVListInternal.GetFocusedRowCellValue("id_mail_manage_mapping_intern").ToString
                        execute_non_query(query_del, True, "", "", "", "")

                        FormCompanyEmailMapping.form_load()
                    End If
                End If
            End If
        ElseIf formName = "FormAREvalScheduke" Then
            Dim id As String = FormAREvalScheduke.GVData.GetFocusedRowCellValue("id_ar_eval_setup_date").ToString
            confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = DialogResult.Yes Then
                Dim query_del As String = "DELETE FROM tb_ar_eval_setup_date WHERE id_ar_eval_setup_date='" + id + "'"
                execute_non_query(query_del, True, "", "", "", "")
                FormAREvalScheduke.viewData()
            End If
        ElseIf formName = "FormFollowUpAR" Then
            Dim idx As String = ""
            If FormFollowUpAR.XTCAR.SelectedTabPageIndex = 0 And FormFollowUpAR.GVData.RowCount > 0 And FormFollowUpAR.GVData.FocusedRowHandle >= 0 Then
                idx = FormFollowUpAR.GVData.GetFocusedRowCellValue("id_follow_up_ar").ToString
            ElseIf FormFollowUpAR.XTCAR.SelectedTabPageIndex = 1 And FormFollowUpAR.GVActive.RowCount > 0 And FormFollowUpAR.GVActive.FocusedRowHandle >= 0 Then
                idx = FormFollowUpAR.GVActive.GetFocusedRowCellValue("id_follow_up_ar").ToString
            End If
            confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = DialogResult.Yes Then
                Try
                    Dim query_del As String = "DELETE FROM tb_follow_up_ar WHERE id_follow_up_ar='" + idx + "'"
                    execute_non_query(query_del, True, "", "", "", "")
                    If FormFollowUpAR.XTCAR.SelectedTabPageIndex = 0 Then
                        FormFollowUpAR.viewList()
                    ElseIf FormFollowUpAR.XTCAR.SelectedTabPageIndex = 1 Then
                        FormFollowUpAR.viewActive()
                    End If
                Catch ex As Exception
                    errorDelete()
                End Try
            End If
        ElseIf formName = "FormBudgetProdDemand" Then
        ElseIf formName = "FormLetterOfStatement" Then
            Dim idx As String = ""
            Try
                idx = FormLetterOfStatement.GVLetterOfStatement.GetFocusedRowCellValue("id_letter_of_statement").ToString
            Catch ex As Exception
            End Try

            confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = DialogResult.Yes Then
                Dim query_del As String = "DELETE FROM tb_letter_of_statement WHERE id_letter_of_statement='" + idx + "'"
                execute_non_query(query_del, True, "", "", "", "")

                FormLetterOfStatement.form_load()
            End If
        ElseIf formName = "FormMasterDesignFabrication" Then
            Try
                FormMasterDesignFabricationDet.id_design_fabrication = FormMasterDesignFabrication.GVFabrication.GetFocusedRowCellValue("id_design_fabrication").ToString
                FormMasterDesignFabricationDet.delete()
            Catch ex As Exception
            End Try
        ElseIf formName = "FormMaterialRequisition" Then
            Dim query_delm As String
            If Not check_edit_report_status(FormMaterialRequisition.GVMRS.GetFocusedRowCellDisplayText("id_report_status").ToString, "29", FormMaterialRequisition.GVMRS.GetFocusedRowCellDisplayText("id_prod_order_mrs").ToString) Or FormMaterialRequisition.GVMRS.GetFocusedRowCellDisplayText("id_report_status").ToString = "5" Then
                stopCustom("This data already locked.")
            Else
                Dim confirm_delm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this request ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                Dim id_mrs As String = FormMaterialRequisition.GVMRS.GetFocusedRowCellDisplayText("id_prod_order_mrs").ToString
                If confirm_delm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query_delm = String.Format("DELETE FROM tb_prod_order_mrs WHERE id_prod_order_mrs = '{0}'", id_mrs)
                        execute_non_query(query_delm, True, "", "", "", "")
                        delete_all_mark_related("29", id_mrs)
                        FormMaterialRequisition.view_mrs()
                        FormMaterialRequisition.show_but_mrs()
                    Catch ex As Exception
                        DevExpress.XtraEditors.XtraMessageBox.Show("This request already used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        ElseIf formName = "FormDesignImages" Then
            FormDesignImages.delete_images()
        ElseIf formName = "FormEmployeeContract" Then
            Dim id_emp_contract As String = "0"

            Try
                id_emp_contract = FormEmployeeContract.GVEmployeeContract.GetFocusedRowCellValue("id_emp_contract").ToString
            Catch ex As Exception
            End Try

            If Not id_emp_contract = "0" Then
                Dim confirm_cnt As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this contract ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                If confirm_cnt = DialogResult.Yes Then
                    execute_non_query("DELETE FROM tb_emp_contract WHERE id_emp_contract = " + id_emp_contract, True, "", "", "", "")

                    FormEmployeeContract.form_load()
                End If
            Else
                stopCustom("No contract selected.")
            End If
        ElseIf formName = "FormOLReturnRefuse" Then
            'no action
        ElseIf formName = "FormPricePolicyCode" Then
            If FormPricePolicyCode.GVData.RowCount > 0 And FormPricePolicyCode.GVData.FocusedRowHandle >= 0 Then
                Dim confirm_delm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this code ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                Dim id_code_detail As String = FormPricePolicyCode.GVData.GetFocusedRowCellValue("id_code_detail").ToString
                If confirm_delm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        Dim query_delm As String = String.Format("DELETE FROM tb_m_code_detail WHERE id_code_detail = '{0}'", id_code_detail)
                        execute_non_query(query_delm, True, "", "", "", "")
                        FormPricePolicyCode.viewData()
                    Catch ex As Exception
                        DevExpress.XtraEditors.XtraMessageBox.Show("This code already used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        ElseIf formName = "FormProposePriceMKD" Then
        Else
            RPSubMenu.Visible = False
        End If
    End Sub
    'Print Data
    Private Sub BBPrint_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBPrint.ItemClick
        Cursor = Cursors.WaitCursor
        If formName = "FormMasterArea" Then
            If FormMasterArea.XTCArea.SelectedTabPageIndex = 0 Then
                'country
                print(FormMasterArea.GCCountry, "List Country")
            ElseIf FormMasterArea.XTCArea.SelectedTabPageIndex = 1 Then
                'region
                print(FormMasterArea.GCRegion, "List Region of " & FormMasterArea.GVCountry.GetFocusedRowCellDisplayText("country").ToString)
            ElseIf FormMasterArea.XTCArea.SelectedTabPageIndex = 2 Then
                'state
                print(FormMasterArea.GCState, "List State of " & FormMasterArea.GVRegion.GetFocusedRowCellDisplayText("region").ToString)
            ElseIf FormMasterArea.XTCArea.SelectedTabPageIndex = 3 Then
                'city
                print(FormMasterArea.GCCity, "List City of " & FormMasterArea.GVState.GetFocusedRowCellDisplayText("state").ToString)
            Else
                'kecamatan
                print(FormMasterArea.GCKecamatan, "List Sub District (Kecamatan) of " & FormMasterArea.GVCity.GetFocusedRowCellDisplayText("city").ToString)
            End If
        ElseIf formName = "FormMasterCompany" Then
            '
            print(FormMasterCompany.GCCompany, "List Company")
        ElseIf formName = "FormMasterCompanyCategory" Then
            '
            print(FormMasterCompanyCategory.GCCompanyCategory, "Company Category")
        ElseIf formName = "FormMasterDepartement" Then
            '
            print(FormMasterDepartement.GCDepartement, "List Departement")
        ElseIf formName = "FormMasterRawMaterialCat" Then
            '
            print(FormMasterRawMaterialCat.GridControlMasterItemCategory, "Master Item Category")
        ElseIf formName = "FormMasterItemColor" Then
            '
            print(FormMasterItemColor.GCItemColor, "Master Item Color")
        ElseIf formName = "FormMasterItemSize" Then
            '
            print(FormMasterItemSize.GCItemSize, "Master Item Size")
        ElseIf formName = "FormMasterUser" Then
            print(FormMasterUser.GCUser, "List User")
        ElseIf formName = "FormAccess" Then
            If FormAccess.XTCMenuManage.SelectedTabPageIndex = 2 Then 'Print Role
                print(FormAccess.GCRole, "List Role")
            ElseIf FormAccess.XTCMenuManage.SelectedTabPageIndex = 1 Then 'Print Menu
                print(FormAccess.GCMenu, "List Menu")
            ElseIf FormAccess.XTCMenuManage.SelectedTabPageIndex = 0 Then 'Print Form
                If FormAccess.XTCForm.SelectedTabPageIndex = 0 Then 'Form
                    print(FormAccess.GCForm, "List Form")
                ElseIf FormAccess.XTCForm.SelectedTabPageIndex = 1 Then 'Form Control
                    print(FormAccess.GCProcess, "List Process " + FormAccess.GVForm.GetFocusedRowCellDisplayText("form_name").ToString)
                End If
            End If
        ElseIf formName = "FormSeason" Then
            If FormSeason.XTCMainSeason.SelectedTabPageIndex = 0 Then 'PRINT INTERNAL SEASON
                If FormSeason.XTCSeason.SelectedTabPageIndex = 0 Then  'print range
                    print(FormSeason.GCRange, "List Range")
                    'ElseIf FormSeason.XTCSeason.SelectedTabPageIndex = 1 Then  'print season
                    '    print(FormSeason.GCSeason, "List Season")
                ElseIf FormSeason.XTCSeason.SelectedTabPageIndex = 2 Then 'print delivery
                    print(FormSeason.GCDelivery, FormSeason.delivery_title)
                End If
            Else 'PRINT ORIGIN SEASON
                print(FormSeason.GCOrignSeason, "List Season Origin")
            End If
        ElseIf formName = "FormMasterUOM" Then
            print(FormMasterUOM.GCUOM, "Unit Of Measure")
        ElseIf formName = "FormMasterRawMat" Then
            If FormMasterRawMat.XTCRawMat.SelectedTabPageIndex = 0 Then 'print raw mat
                print(FormMasterRawMat.GCRawMat, "List Raw Material")
            ElseIf FormMasterRawMat.XTCRawMat.SelectedTabPageIndex = 1 Then 'print raw mat lot
                print(FormMasterRawMat.GCLot, "Detail Lot " + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(FormMasterRawMat.GVRawMat.GetFocusedRowCellDisplayText("raw_mat").ToString))
            ElseIf FormMasterRawMat.XTCRawMat.SelectedTabPageIndex = 2 Then 'print raw mat supplier
                print(FormMasterRawMat.GCSupplier, "Detail Supplier " + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(FormMasterRawMat.GVLot.GetFocusedRowCellDisplayText("raw_mat_detail").ToString))
            End If
        ElseIf formName = "FormMasterRawMaterial" Then
            If FormMasterRawMaterial.XTCList.SelectedTabPageIndex = 0 Then
                If FormMasterRawMaterial.XTCMaterialType.SelectedTabPageIndex = 0 Then
                    print(FormMasterRawMaterial.GCRawMat, "List Raw Material")
                ElseIf FormMasterRawMaterial.XTCMaterialType.SelectedTabPageIndex = 1 Then
                    print(FormMasterRawMaterial.GCMatDetail, "List Detail Material : " + FormMasterRawMaterial.GVRawMat.GetFocusedRowCellDisplayText("mat_name").ToString)
                End If
            ElseIf FormMasterRawMaterial.XTCList.SelectedTabPageIndex = 1 Then
                print(FormMasterRawMaterial.GCListMat, "List Raw Material")
            End If

        ElseIf formName = "FormMasterOVH" Then
            print(FormMasterOVH.GCOVH, "Overhead")
        ElseIf formName = "FormMasterCode" Then
            '
            If FormMasterCode.XTCCode.SelectedTabPageIndex = 0 Then
                'code
                print(FormMasterCode.GCCode, "Master Code")
            ElseIf FormMasterCode.XTCCode.SelectedTabPageIndex = 1 Then
                'code detail
                print(FormMasterCode.GCCodeDetail, FormMasterCode.LabelCodeContent.Text)
            End If
        ElseIf formName = "FormTemplateCode" Then
            '
            If FormTemplateCode.XTCTemplateCode.SelectedTabPageIndex = 0 Then
                'code
                print(FormTemplateCode.GCTemplateCode, "Template Code")
            ElseIf FormTemplateCode.XTCTemplateCode.SelectedTabPageIndex = 1 Then
                'code detail
                print(FormTemplateCode.GCTemplateCodeDet, FormTemplateCode.LabelTemplate.Text)
            End If
        ElseIf formName = "FormMasterProduct" Then
            '
            If FormMasterProduct.XTCProduct.SelectedTabPageIndex = 0 Then
                'design
                print(FormMasterProduct.GCDesign, "List Design")
            ElseIf FormMasterProduct.XTCProduct.SelectedTabPageIndex = 1 Then
                'product
                print(FormMasterProduct.GCProduct, FormMasterProduct.LabelPrintedName.Text)
            End If
        ElseIf formName = "FormMasterSample" Then
            '
            print(FormMasterSample.GCSample, "Sample List")
        ElseIf formName = "FormBOM" Then
            '
            If FormBOM.XTCBOMSelection.SelectedTabPageIndex = 1 Then
                ReportBOM.id_bom = FormBOM.GVBOM.GetFocusedRowCellDisplayText("id_bom").ToString
                ReportBOM.product_name = FormBOM.GVProduct.GetFocusedRowCellDisplayText("product_name").ToString & " - " & FormBOM.GVProduct.GetFocusedRowCellDisplayText("Size").ToString
                ReportBOM.bom_name = FormBOM.GVBOM.GetFocusedRowCellDisplayText("bom_name").ToString
                ReportBOM.bom_date = FormBOM.GVBOM.GetFocusedRowCellDisplayText("bom_date_created").ToString
                ReportBOM.bom_term = FormBOM.GVBOM.GetFocusedRowCellDisplayText("term_production").ToString

                Dim Report As New ReportBOM()
                ' Show the report's preview. 
                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreview()
            ElseIf FormBOM.XTCBOMSelection.SelectedTabPageIndex = 0 Then
                print(FormBOM.GCBOMDesign, "Bill Of Material - " & FormBOM.GVDesign.GetFocusedRowCellValue("design_name").ToString & " - " & FormBOM.GVDesign.GetFocusedRowCellValue("design_code").ToString)
            ElseIf FormBOM.XTCBOMSelection.SelectedTabPageIndex = 2 Then
                print(FormBOM.GCCompPerDesign, "Bill Of Material - " & FormBOM.GVPerDesign.GetFocusedRowCellValue("design_name").ToString & " - " & FormBOM.GVPerDesign.GetFocusedRowCellValue("design_code").ToString)
            End If
        ElseIf formName = "FormProdDemand" Then
            'PRODUCTION DEMAND
            print(FormProdDemand.GCProdDemand, "Production Demand List")
            'ReportProdDemand.id_prod_demand = FormProdDemand.GVProdDemand.GetFocusedRowCellDisplayText("id_prod_demand").ToString
            'ReportProdDemand.prod_demand_number = FormProdDemand.GVProdDemand.GetFocusedRowCellDisplayText("prod_demand_number").ToString
            'ReportProdDemand.season = FormProdDemand.GVProdDemand.GetFocusedRowCellDisplayText("season").ToString

            'Dim Report As New ReportProdDemand()
            'Report.Landscape = True
            '' Show the report's preview. 
            'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            'Tool.ShowPreview()
        ElseIf formName = "FormSamplePL" Then
            'PACKING LIST RECEIVING SAMPLE 
            print(FormSamplePL.GCPL, "Packing List To Storage")
        ElseIf formName = "FormSamplePLDel" Then
            'PACKING LIST RECEIVING SAMPLE 
            print(FormSamplePLDel.GCPL, "Packing List Sample Borrow")
        ElseIf formName = "FormSamplePurchase" Then
            '
            print(FormSamplePurchase.GCSamplePurchase, "List Purchase Order Sample")
        ElseIf formName = "FormSampleReceive" Then
            '
            print(FormSampleReceive.GCSampleReceive, "List Receiving Report Sample")
        ElseIf formName = "FormSamplePR" Then
            '
            print(FormSamplePR.GCSamplePR, "List Payment Requistion  Sample")
        ElseIf formName = "FormMasterWH" Then
            'WAREHOUSE & LOCATOR
            If FormMasterWH.XTCWH.SelectedTabPageIndex = 0 Then
                'Warehouse
                print(FormMasterWH.GCWH, "List Warehouse")
            ElseIf FormMasterWH.XTCWH.SelectedTabPageIndex = 1 Then
                'Locator
                print(FormMasterWH.GCWHLocator, "List Locator - " + FormMasterWH.GVWH.GetFocusedRowCellDisplayText("comp_name").ToString)
            ElseIf FormMasterWH.XTCWH.SelectedTabPageIndex = 2 Then
                'Rack
                print(FormMasterWH.GCRack, "List Rack - " + FormMasterWH.GVWH.GetFocusedRowCellDisplayText("comp_name").ToString + "/" + FormMasterWH.GVLocator.GetFocusedRowCellDisplayText("wh_locator").ToString)
            ElseIf FormMasterWH.XTCWH.SelectedTabPageIndex = 3 Then
                'Drawer
                print(FormMasterWH.GCDrawer, "List Drawer - " + FormMasterWH.GVWH.GetFocusedRowCellDisplayText("comp_name").ToString + "/" + FormMasterWH.GVLocator.GetFocusedRowCellDisplayText("wh_locator").ToString + "/" + FormMasterWH.GVRack.GetFocusedRowCellDisplayText("wh_rack").ToString)
            End If
        ElseIf formName = "FormSampleReceipt" Then
            'Receipt Sample
            print(FormSampleReceipt.GCReceipt, "List Sample Receipt")
        ElseIf formName = "FormSampleRet" Then
            'RETURN SAMPLE
            If FormSampleRet.XTCReturn.SelectedTabPageIndex = 0 Then 'returnIn
                print(FormSampleRet.GCRetOut, "List Return Out")
            ElseIf FormSampleRet.XTCReturn.SelectedTabPageIndex = 1 Then 'Return Out
                print(FormSampleRet.GCRetIn, "List Return In")
            End If
        ElseIf formName = "FormSampleReq" Then
            'REQ SAMPLE
            print(FormSampleReq.GCReq, "Sample Borrow Requisition")
        ElseIf formName = "FormMarkAssign" Then
            'Assign mark
            print(FormMarkAssign.GCMarkAssign, "Mapping Approval System")
        ElseIf formName = "FormSamplePlan" Then
            'Planning Sample
            print(FormSamplePlan.GCSamplePurchase, "List Planning Sample")
        ElseIf formName = "FormMatPurchase" Then
            'Purchase Material
            If FormMatPurchase.XTCPurcMat.SelectedTabPageIndex = 0 Then
                print(FormMatPurchase.GCMatPurchase, "List Purchase Material")
            ElseIf FormMatPurchase.XTCPurcMat.SelectedTabPageIndex = 1 Then
                If FormMatPurchase.XTCListPD.SelectedTabPageIndex = 0 Then
                    print(FormMatPurchase.GCListMatPD, "List Material From PD")
                ElseIf FormMatPurchase.XTCListPD.SelectedTabPageIndex = 1 Then
                    print(FormMatPurchase.GCPD, "List PD Design (Season : " & FormMatPurchase.SLEReport.Text & ")")
                End If
            End If
        ElseIf formName = "FormMatWO" Then
            'Purchase Material
            print(FormMatWO.GCMatWO, "List Work Order Material")
        ElseIf formName = "FormMatRecPurc" Then
            'Receive Material Purchase
            If FormMatRecPurc.XTCTabReceive.SelectedTabPageIndex = 0 Then
                print(FormMatRecPurc.GCMatRecPurc, "List Receive Material Purchase")
            Else 'based on PO
                print(FormMatRecPurc.GCMatPurchase, "List Material Purchase Waiting To Receive")
            End If
        ElseIf formName = "FormMatRecWO" Then
            'Receive Material WO
            If FormMatRecWO.XTCTabReceive.SelectedTabPageIndex = 0 Then ' based on receive
                print(FormMatRecWO.GCListPurchase, "List Receive Material Work Order")
            Else 'based on WO
                print(FormMatRecWO.GCMatWO, "List Material Work Order Waiting To Receive")
            End If
        ElseIf formName = "FormMatRet" Then
            If FormMatRet.XTCReturnMat.SelectedTabPageIndex = 0 Then 'purchase
                'Return Mat
                If FormMatRet.XTCReturnPruchase.SelectedTabPageIndex = 0 Then 'return Out
                    print(FormMatRet.GCRetOut, "List Return Out Material Purchasing")
                ElseIf FormMatRet.XTCReturnPruchase.SelectedTabPageIndex = 1 Then 'return In
                    print(FormMatRet.GCRetIn, "List Return In Material Purchasing")
                End If
            ElseIf FormMatRet.XTCReturnMat.SelectedTabPageIndex = 1 Then 'production
                If FormMatRet.XTCReturnProd.SelectedTabPageIndex = 0 Then 'return In
                    print(FormMatRet.GCRetInProd, "List Return In Material Production")
                End If
            ElseIf FormMatRet.XTCReturnMat.SelectedTabPageIndex = 2 Then 'other
                print(FormMatRet.GCRetOther, "List Return In Material Other")
            End If
        ElseIf formName = "FormSampleReturn" Then
            'RETURN SAMPLE
            If FormSampleReturn.XTCReturn.SelectedTabPageIndex = 0 Then 'returnIn
                print(FormSampleReturn.GCRetSample, "Return Sample Borrow")
            ElseIf FormSampleReturn.XTCReturn.SelectedTabPageIndex = 1 Then 'Return Out
                'print(FormSampleRet.GCRetIn, "List Return In")
            End If
        ElseIf formName = "FormSampleAdjustment" Then
            'ADJUSTMENT SAMPLE
            If FormSampleAdjustment.XTCAdj.SelectedTabPageIndex = 0 Then 'In
                print(FormSampleAdjustment.GCAdjSampleIn, "Adjusment In")
            ElseIf FormSampleAdjustment.XTCAdj.SelectedTabPageIndex = 1 Then 'Out
                print(FormSampleAdjustment.GCAdjOutSample, "Adjusment Out")
            End If
        ElseIf formName = "FormMatAdj" Then
            'ADJUSTMENT Material
            If FormMatAdj.XTCAdj.SelectedTabPageIndex = 0 Then 'In
                print(FormMatAdj.GCAdjIn, "List Adjusment In")
            ElseIf FormMatAdj.XTCAdj.SelectedTabPageIndex = 1 Then 'Out
                print(FormMatAdj.GCAdjOut, "List Adjusment Out")
            End If
        ElseIf formName = "FormMatPR" Then
            'PR PO MATERIAL 
            If FormMatPR.XTCTabPR.SelectedTabPageIndex = 0 Then 'List PR
                print(FormMatPR.GCMatPR, "Payment Requisition PO Material")
            ElseIf FormMatPR.XTCTabPR.SelectedTabPageIndex = 1 Then 'List PO
                print(FormMatPR.GCMatPurchaseNeed, "PO Need Payment Requisition")
            ElseIf FormMatPR.XTCTabPR.SelectedTabPageIndex = 2 Then 'List Rec
                print(FormMatPR.GCMatReceive, "Receiving Need Payment Requisition")
            End If
        ElseIf formName = "FormMatPRWO" Then
            'PR WO MATERIAL 
            If FormMatPRWO.XTCTabPR.SelectedTabPageIndex = 0 Then 'List PR
                print(FormMatPRWO.GCMatPRWO, "Payment Requisition WO Material")
            ElseIf FormMatPRWO.XTCTabPR.SelectedTabPageIndex = 1 Then 'List PO
                print(FormMatPRWO.GCMatPurchaseNeed, "WO Need Payment Requisition")
            ElseIf FormMatPRWO.XTCTabPR.SelectedTabPageIndex = 2 Then 'List Rec
                print(FormMatPRWO.GCMatReceive, "Receiving Need Payment Requisition")
            End If
        ElseIf formName = "FormProduction" Then
            If FormProduction.XTCTabProduction.SelectedTabPageIndex = 0 Then
                print(FormProduction.GCProd, "Production Order")
            ElseIf FormProduction.XTCTabProduction.SelectedTabPageIndex = 1 Then
                print(FormProduction.GCDesign, "List Production Demand")
            ElseIf FormProduction.XTCTabProduction.SelectedTabPageIndex = 2 Then
                print(FormProduction.GCProdWO, "Production Order WO")
            ElseIf FormProduction.XTCTabProduction.SelectedTabPageIndex = 3 Then
                print(FormProduction.GCMRS, "Production Order MRS")
            End If
        ElseIf formName = "FormMatPL" Then
            'Packing list material
            If FormMatPL.XTCPL.SelectedTabPageIndex = 0 Then 'Prod MRS
                If FormMatPL.XTCTabProduction.SelectedTabPageIndex = 0 Then 'list PL
                    print(FormMatPL.GCProdPL, "Packing List Material For Production")
                ElseIf FormMatPL.XTCTabProduction.SelectedTabPageIndex = 1 Then 'list MRS
                    print(FormMatPL.GCMRS, "List Material Request For Production")
                End If
            ElseIf FormMatPL.XTCPL.SelectedTabPageIndex = 1 Then 'WO
                If FormMatPL.XTCPLWO.SelectedTabPageIndex = 0 Then
                    print(FormMatPL.GCPLWO, "Packing List Material Work Order")
                ElseIf FormMatPL.XTCPLWO.SelectedTabPageIndex = 1 Then
                    print(FormMatPL.GCMRSWO, "List Material Request Work Order")
                End If
            ElseIf FormMatPL.XTCPL.SelectedTabPageIndex = 2 Then 'Other
                If FormMatPL.XTCPLOther.SelectedTabPageIndex = 0 Then
                    print(FormMatPL.GCPLOther, "Packing List Material Other")
                ElseIf FormMatPL.XTCPLOther.SelectedTabPageIndex = 1 Then
                    print(FormMatPL.GCMRSOther, "List Material Request Other")
                End If
            End If
        ElseIf formName = "FormMatMRS" Then
            'Material Requisition : Other
            print(FormMatPL.GCProdPL, "List Material Requisiton")
        ElseIf formName = "FormProductionRec" Then
            'Receive FG QC
            If FormProductionRec.XTCTabReceive.SelectedTabPageIndex = 0 Then
                print(FormProductionRec.GCProdRec, "List Receiving Finished Goods in QC")
            Else 'based on PO
                print(FormProductionRec.GCProd, "List Production Order Waiting To Receive")
            End If
        ElseIf formName = "FormProductionRet" Then
            'Return Production
            If FormProductionRet.XTCReturn.SelectedTabPageIndex = 0 Then 'return Out
                print(FormProductionRet.GCRetOut, "List Return Out Finished Goods")
            ElseIf FormProductionRet.XTCReturn.SelectedTabPageIndex = 1 Then 'return In
                print(FormProductionRet.GCRetIn, "List Return In Finished Goods")
            End If
        ElseIf formName = "FormProductionPLToWH" Then
            If FormProductionPLToWH.XTCPL.SelectedTabPageIndex = 0 Then
                print(FormProductionPLToWH.GCPL, "Packing List Finished Goods")
            ElseIf FormProductionPLToWH.XTCPL.SelectedTabPageIndex = 1 Then
                '
            End If
        ElseIf formName = "FormMatInvoice" Then
            'Invoice Material PL MRS
            If FormMatInvoice.XTCTabGeneral.SelectedTabPageIndex = 0 Then
                If FormMatInvoice.XTCTabProduction.SelectedTabPageIndex = 0 Then
                    print(FormMatInvoice.GCProdInvoice, "List Invoice Material.")
                Else 'based on PL
                    print(FormMatInvoice.GCProdPL, "List Packing List Material.")
                End If
            ElseIf FormMatInvoice.XTCTabGeneral.SelectedTabPageIndex = 0 Then
                If FormMatInvoice.XTCRetur.SelectedTabPageIndex = 0 Then
                    print(FormMatInvoice.GCRetur, "List Invoice Retur Material.")
                Else 'based on invoice
                    print(FormMatInvoice.GCInvoice, "List Invoice Material.")
                End If
            End If
        ElseIf formName = "FormAccounting" Then
            If FormAccounting.XTCGeneral.SelectedTabPageIndex = 0 Then
                print_raw(FormAccounting.GCAcc, "Chart Of Account")
            ElseIf FormAccounting.XTCGeneral.SelectedTabPageIndex = 1 Then
                'print_raw(FormAccounting.TreeList1, "Chart Of Account")
            ElseIf FormAccounting.XTCGeneral.SelectedTabPageIndex = 2 Then
                print_raw(FormAccounting.GCCompany, "")
            End If
        ElseIf formName = "FormAccountingJournal" Then
            If FormAccountingJournal.XTCJurnal.SelectedTabPageIndex = 0 Then
                print(FormAccountingJournal.GCAccTrans, "Journal Transaction")
            Else
                print(FormAccountingJournal.GCJournalDet, "Journal Transaction")
            End If
        ElseIf formName = "FormAccountingJournalAdj" Then
            print(FormAccountingJournalAdj.GCAccTrans, "Adjustment Journal")
        ElseIf formName = "FormProductionPLToWHRec" Then
            If FormProductionPLToWHRec.XTCPL.SelectedTabPageIndex = 0 Then
                print(FormProductionPLToWHRec.GCPL, "List Receiving Finished Goods in WH")
            ElseIf FormProductionPLToWHRec.XTCPL.SelectedTabPageIndex = 1 Then
                print(FormProductionPLToWHRec.GCProd, "List Waiting Receive Finished Goods")
            End If
        ElseIf formName = "FormSalesTarget" Then
            'SALES TARGET
            If FormSalesTarget.XTCSalesTarget.SelectedTabPageIndex = 0 Then
                print(FormSalesTarget.GCSalesTarget, "List Sales Target")
            End If
        ElseIf formName = "FormSalesOrder" Then
            'SALES ORDER
            If FormSalesOrder.XTCSOGeneral.SelectedTabPageIndex = 0 Then
                print(FormSalesOrder.GCSalesOrder, "List Prepare Order")
            ElseIf FormSalesOrder.XTCSOGeneral.SelectedTabPageIndex = 1 Then
                print(FormSalesOrder.GCGen, "Generate Prepare Order")
            End If
        ElseIf formName = "FormSalesDelOrder" Then
            'SALES DEL ORDER
            If FormSalesDelOrder.XTCDO.SelectedTabPageIndex = 0 Then
                print(FormSalesDelOrder.GCSalesDelOrder, "TRANSACTION LIST - DELIVERY")
            ElseIf FormSalesDelOrder.XTCDO.SelectedTabPageIndex = 1 Then
                print(FormSalesDelOrder.GCSalesOrder, "PREPARE ORDER LIST")
            ElseIf FormSalesDelOrder.XTCDO.SelectedTabPageIndex = 2 Then
                Cursor = Cursors.WaitCursor
                ReportSalesOrderViewRef.dt = FormSalesDelOrder.GCNewPrepare.DataSource
                Dim Report As New ReportSalesOrderViewRef()

                ' '... 
                ' ' creating and saving the view's layout to a new memory stream 
                Dim str As System.IO.Stream
                str = New System.IO.MemoryStream()
                FormSalesDelOrder.GVNewPrepare.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                Report.GVNewPrepare.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)

                'Grid Detail
                ReportStyleBanded(Report.GVNewPrepare)

                'Parse val
                Report.LabelRef.Text = FormSalesDelOrder.TxtNoParam.Text

                'Show the report's preview. 
                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreviewDialog()
                Cursor = Cursors.Default

                'print(FormSalesDelOrder.GCNewPrepare, "PREPARE ORDER REFERENCE - " + FormSalesDelOrder.TxtNoParam.Text.ToUpper + "")
            End If
        ElseIf formName = "FormSalesReturnOrder" Then
            'SALES RETURN ORDER
            If FormSalesReturnOrder.XTCROR.SelectedTabPageIndex = 0 Then
                print(FormSalesReturnOrder.GCSalesReturnOrder, "Return Order List")
            ElseIf FormSalesReturnOrder.XTCROR.SelectedTabPageIndex = 1 Then
                print(FormSalesReturnOrder.GCOnHold, "On Hold List")
            End If
        ElseIf formName = "FormSalesReturnOrderOL" Then
            'SALES RETURN ORDER OL
            print(FormSalesReturnOrderOL.GCSalesReturnOrder, "List Return Order")
        ElseIf formName = "FormSalesReturn" Then
            'SALES REUTNR
            If FormSalesReturn.XTCSalesReturn.SelectedTabPageIndex = 0 Then
                print(FormSalesReturn.GCSalesReturn, "List Return From Store")
            ElseIf FormSalesReturn.XTCSalesReturn.SelectedTabPageIndex = 1 Then
                print(FormSalesReturn.GCSalesReturnOrder, "List Waiting To Return")
                'FormSalesDelOrderPrintOpt.ShowDialog()
            End If
        ElseIf formName = "FormSalesPOS" Then
            'SALES VRTUAL POS
            print(FormSalesPOS.GCSalesPOS, "Sales Invoice")
        ElseIf formName = "FormSalesReturnQC" Then
            'SALES RETURN QC
            print(FormSalesReturnQC.GCSalesReturnQC, "List Quality Control Return Product")
        ElseIf formName = "FormProdPRWO" Then
            'PR Prod WO
            If FormProdPRWO.XTCTabPR.SelectedTabPageIndex = 0 Then 'List PR
                print(FormProdPRWO.GCMatPR, "Payment Requisition WO Production")
            ElseIf FormProdPRWO.XTCTabPR.SelectedTabPageIndex = 1 Then 'List WO
                print(FormProdPRWO.GCProdWO, "WO Production Need Payment Requisition")
            ElseIf FormProdPRWO.XTCTabPR.SelectedTabPageIndex = 2 Then 'List PR FGPO
                print(FormProdPRWO.GCPRPO, "Payment Requisition FGPO Production")
            ElseIf FormProdPRWO.XTCTabPR.SelectedTabPageIndex = 3 Then 'List PR No Reff
                print(FormProdPRWO.GCPRNoReff, "Payment Requisition No Refference")
            End If
        ElseIf formName = "FormSalesInvoice" Then
            'SALES INVOICE
            print(FormSalesInvoice.GCSalesInvoice, "Sales Invoice")
        ElseIf formName = "FormFGStockOpnameStore" Then
            'STORE STOCK OPNAME
            print(FormFGStockOpnameStore.GCSOStore, "Store Stock Opname")
        ElseIf formName = "FormFGMissing" Then
            'FG MISSING
            If FormFGMissing.XTCFGMissing.SelectedTabPageIndex = 0 Then
                print(FormFGMissing.GCFGMissing, "Missing Finished Goods In Store")
            ElseIf FormFGMissing.XTCFGMissing.SelectedTabPageIndex = 1 Then
                print(FormFGMissing.GCMissingWH, "Missing Finished Goods In Warehouse")
            End If
        ElseIf formName = "FormFGMissingInvoice" Then
            'FG Missing INVOICE
            print(FormFGMissingInvoice.GCFGMissingInvoice, "Missing Finished Goods Invoice")
        ElseIf formName = "FormFGStockOpnameWH" Then
            'WH STOCK OPNAME
            print(FormFGStockOpnameWH.GCSOWH, "WH Stock Opname")
        ElseIf formName = "FormMatStockOpname" Then
            'Material Stock Opname
            print(FormMatStockOpname.GCMatPR, "List Material Stock Opname")
        ElseIf formName = "FormMatStockOpname" Then
            'Material Stock Opname
            FormMatStockOpname.Close()
            FormMatStockOpname.Dispose()
        ElseIf formName = "FormFGAdj" Then
            'ADJUSTMENT FG
            If FormFGAdj.XTCAdj.SelectedTabPageIndex = 0 Then 'In
                print(FormFGAdj.GCAdjIn, "List Adjusment In Finished Goods")
            ElseIf FormFGAdj.XTCAdj.SelectedTabPageIndex = 1 Then 'Out
                print(FormFGAdj.GCAdjOut, "List Adjusment Out Finished Goods")
            End If
        ElseIf formName = "FormFGTrf" Then
            'FG Transfer Future
            print(FormFGTrf.GCFGTrf, "Finished Goods Transfer")
        ElseIf formName = "FormFGTrfNew" Then
            'FG Transfer
            If FormFGTrfNew.XTCTrf.SelectedTabPageIndex = 0 Then
                print(FormFGTrfNew.GCFGTrf, "TRANSACTION LIST - TRANSFER")
            ElseIf FormFGTrfNew.XTCTrf.SelectedTabPageIndex = 1 Then
                print(FormFGTrfNew.GCSalesOrder, "PREPARE ORDER LIST")
            End If
        ElseIf formName = "FormFGTrfRec" Then
            'FG Transfer Rec
            print(FormFGTrfReceive.GCFGTrf, "Receive Finished Goods Transfer")
        ElseIf formName = "FormFGTracking" Then
            'FG Tracking
            Cursor = Cursors.WaitCursor
            print(FormFGTracking.GCTracking, "Tracking Product " + FormFGTracking.LabelTitle.Text)
            Cursor = Cursors.Default
        ElseIf formName = "FormFGStock" Then
            'FG STOCK
            Cursor = Cursors.WaitCursor
            If FormFGStock.XTCFGStock.SelectedTabPageIndex = 0 Then
                If FormFGStock.XTCSOH.SelectedTabPageIndex = 0 Then
                    print_raw(FormFGStock.GCFGStock, "")
                    ''... 
                    '' creating and saving the view's layout to a new memory stream 
                    'Dim str As System.IO.Stream
                    'str = New System.IO.MemoryStream()
                    'FormFGStock.BGVFGStock.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                    'str.Seek(0, System.IO.SeekOrigin.Begin)
                    'ReportFGStockSum.str_param = str
                    'ReportFGStockSum.dt = FormFGStock.dt_sum
                    'Dim Report As New ReportFGStockSum()
                    'Report.BandedGridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                    'str.Seek(0, System.IO.SeekOrigin.Begin)

                    'Report.LabelDesign.Text = FormFGStock.label_design_selected_stock_sum
                    'Report.LabelWH.Text = FormFGStock.label_wh_selected_stock_sum
                    'Report.LabelLocator.Text = FormFGStock.label_locator_selected_stock_sum
                    'Report.LabelRack.Text = FormFGStock.label_rack_selected_stock_sum
                    'Report.LabelDrawer.Text = FormFGStock.label_drawer_selected_stock_sum

                    'ReportStyleBanded(Report.BandedGridView1)

                    '' Show the report's preview. 
                    'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                    'Tool.ShowPreview()
                Else
                    print_raw(FormFGStock.GCStockBarcode, "")
                End If
            ElseIf FormFGStock.XTCFGStock.SelectedTabPageIndex = 1 Then
                'modify period
                Dim period_from As String = ""
                Dim period_until As String = ""
                If FormFGStock.date_from_selected = "0000-01-01" Then
                    period_from = "-"
                Else
                    period_from = DateTime.Parse(FormFGStock.date_from_selected).ToString("dd MMM yyyy")
                End If
                If FormFGStock.date_until_selected = "9999-01-01" Then
                    period_until = "-"
                Else
                    period_until = DateTime.Parse(FormFGStock.date_until_selected).ToString("dd MMM yyyy")
                End If


                '... 
                ' creating and saving the view's layout to a new memory stream 
                Dim str As System.IO.Stream
                str = New System.IO.MemoryStream()
                FormFGStock.BandedGridViewFGStockCard.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                ReportFGStockCard.str_param = str
                ReportFGStockCard.dt = FormFGStock.dt
                Dim Report As New ReportFGStockCard()
                Report.BandedGridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)

                Report.LabelWH.Text = FormFGStock.SLEWH.Text.ToUpper
                Report.LabelProduct.Text = FormFGStock.TxtCodeDsgSC.Text + " - " + FormFGStock.LabelControl5.Text
                Report.LabelPeriod.Text = period_from + " - " + period_until
                ReportStyleBanded(Report.BandedGridView1)
                Report.BandedGridView1.ColumnPanelRowHeight = 40

                ' Show the report's preview. 
                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreview()
            ElseIf FormFGStock.XTCFGStock.SelectedTabPageIndex = 2 Then
                'modify period
                Dim period_from As String = ""
                Dim period_until As String = ""
                If FormFGStock.date_from_selected_stock_store = "0000-01-01" Then
                    period_from = ""
                Else
                    period_from = DateTime.Parse(FormFGStock.date_from_selected_stock_store).ToString("dd MMM yyyy")
                End If
                If FormFGStock.date_until_selected_stock_store = "9999-01-01" Then
                    period_until = "-"
                Else
                    period_until = DateTime.Parse(FormFGStock.date_until_selected_stock_store).ToString("dd MMM yyyy")
                End If


                '... 
                ' creating and saving the view's layout to a new memory stream 
                Dim str As System.IO.Stream
                str = New System.IO.MemoryStream()
                FormFGStock.BGVFGStockStore.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                ReportFGStockStore.dt = FormFGStock.dt_store
                Dim Report As New ReportFGStockStore()
                Report.BandedGridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                Report.LabelWH.Text = FormFGStock.label_store_selected_stock_store
                Report.LabelProduct.Text = FormFGStock.label_design_selected_stock_store
                Report.LabelPeriod.Text = "Stock Per " + period_until
                ReportStyleBanded(Report.BandedGridView1)


                ' Show the report's preview. 
                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreview()
            ElseIf FormFGStock.XTCFGStock.SelectedTabPageIndex = 3 Then 'QC STOCK
                'modify period
                Dim period_until As String = ""
                If FormFGStock.date_until_selected_stock_qc = "9999-01-01" Then
                    period_until = "-"
                Else
                    period_until = "Per-" + DateTime.Parse(FormFGStock.date_until_selected_stock_qc).ToString("dd MMM yyyy")
                End If

                '... 
                ' creating and saving the view's layout to a new memory stream 
                Dim str As System.IO.Stream
                str = New System.IO.MemoryStream()
                FormFGStock.BGVFGStockQC.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                ReportFGStockQC.dt = FormFGStock.dt_qc
                Dim Report As New ReportFGStockQC()
                Report.BandedGridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                Report.LabelDesign.Text = FormFGStock.label_design_selected_stock_qc
                Report.LabelPeriod.Text = period_until
                ReportStyleBanded(Report.BandedGridView1)

                ' Show the report's preview. 
                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreview()
            ElseIf FormFGStock.XTCFGStock.SelectedTabPageIndex = 4 Then 'RSV STOCK
                '... 
                ' creating and saving the view's layout to a new memory stream 
                Dim str As System.IO.Stream
                str = New System.IO.MemoryStream()
                FormFGStock.GVRsv.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                ReportFGStockRSV.dt = FormFGStock.GCRsv.DataSource
                Dim Report As New ReportFGStockRSV()
                Report.GVRsv.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                Report.LabelDesign.Text = If(FormFGStock.CheckEditAllDsgRsv.EditValue, "ALL DESIGN", FormFGStock.TxtCodeDsgRsv.Text + " - " + FormFGStock.TxtNameDsgRsv.Text)
                Report.LabelAccount.Text = FormFGStock.TxtCodeAccRsv.Text + " - " + FormFGStock.TxtNameAccRsv.Text
                ReportStyleGridview(Report.GVRsv)

                ' Show the report's preview. 
                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreview()
            ElseIf FormFGStock.XTCFGStock.SelectedTabPageIndex = 5 Then 'SOH
                If FormFGStock.XTCStockOnHandNew.SelectedTabPageIndex = 0 Then
                    '... 
                    ' creating and saving the view's layout to a new memory stream 
                    Dim str As System.IO.Stream
                    str = New System.IO.MemoryStream()
                    FormFGStock.GVSOH.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                    str.Seek(0, System.IO.SeekOrigin.Begin)
                    ReportFGStockSOH.dt = FormFGStock.GCSOH.DataSource
                    Dim Report As New ReportFGStockSOH()
                    Report.XrLabeltitle.Text = "STOCK ON HAND (BY SIZE BARCODE)"
                    Report.DetailReportSize.Visible = True
                    Report.DetailReportCode.Visible = False
                    Report.GVSOH.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                    str.Seek(0, System.IO.SeekOrigin.Begin)
                    Report.LabelDesign.Text = If(FormFGStock.CEFindAllProduct.Checked, "ALL DESIGN", FormFGStock.TxtProduct.Text)
                    Report.LabelAccount.Text = FormFGStock.SLEAccount.Text
                    Report.LabelUnit.Text = FormFGStock.DEUntilAcc.Text
                    ReportStyleGridview(Report.GVSOH)

                    ' Show the report's preview. 
                    Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                    Tool.ShowPreview()
                ElseIf FormFGStock.XTCStockOnHandNew.SelectedTabPageIndex = 1 Then
                    '... 
                    ' creating and saving the view's layout to a new memory stream 
                    Dim str As System.IO.Stream
                    str = New System.IO.MemoryStream()
                    FormFGStock.GVSOHCode.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                    str.Seek(0, System.IO.SeekOrigin.Begin)
                    ReportFGStockSOH.dt = FormFGStock.GCSOHCode.DataSource
                    Dim Report As New ReportFGStockSOH()
                    Report.XrLabeltitle.Text = "STOCK ON HAND (BY CODE)"
                    Report.DetailReportSize.Visible = False
                    Report.DetailReportCode.Visible = True
                    Report.GVSOHCode.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                    str.Seek(0, System.IO.SeekOrigin.Begin)
                    Report.LabelDesign.Text = If(FormFGStock.CEFindAllProduct.Checked, "ALL DESIGN", FormFGStock.TxtProduct.Text)
                    Report.LabelAccount.Text = FormFGStock.SLEAccount.Text
                    Report.LabelUnit.Text = FormFGStock.DEUntilAcc.Text
                    ReportStyleBanded(Report.GVSOHCode)

                    ' Show the report's preview. 
                    Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                    Tool.ShowPreview()
                End If
            ElseIf FormFGStock.XTCFGStock.SelectedTabPageIndex = 6 Then 'SOH VA
                '... 
                ' creating and saving the view's layout to a new memory stream 
                Dim str As System.IO.Stream
                str = New System.IO.MemoryStream()
                FormFGStock.GVSOHVA.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                ReportFGStockSOH.dt = FormFGStock.GCSOHVA.DataSource
                Dim Report As New ReportFGStockSOH()
                Report.XrLabeltitle.Text = "SOH - VIRTUAL ACC. ALLOCATION"
                Report.DetailReportSize.Visible = True
                Report.DetailReportCode.Visible = False
                Report.GVSOH.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                Report.LabelDesign.Text = If(FormFGStock.CEFindAllProductVA.Checked, "ALL DESIGN", FormFGStock.TxtProductVA.Text)
                Report.LabelAccount.Text = FormFGStock.SLEAccountVA.Text
                Report.LabelUnit.Text = FormFGStock.DEUntilAccVA.Text
                ReportStyleGridview(Report.GVSOH)

                ' Show the report's preview. 
                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreview()
            End If
            Cursor = Cursors.Default
        ElseIf formName = "FormMatStock" Then
            'FG STOCK
            Cursor = Cursors.WaitCursor
            If FormMatStock.XTCFGStock.SelectedTabPageIndex = 0 Then
                If FormMatStock.GroupControlStockSum.Enabled = False Then 'not yet
                    stopCustom("Data not found.")
                Else
                    '... 
                    ' creating and saving the view's layout to a new memory stream 
                    Dim str As System.IO.Stream
                    str = New System.IO.MemoryStream()
                    FormMatStock.BGVFGStock.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                    str.Seek(0, System.IO.SeekOrigin.Begin)
                    ReportMatStockSum.str_param = str
                    ReportMatStockSum.dt = FormMatStock.dt_sum
                    Dim Report As New ReportMatStockSum()
                    Report.BandedGridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                    str.Seek(0, System.IO.SeekOrigin.Begin)

                    Report.LabelDesign.Text = FormMatStock.label_design_selected_stock_sum
                    Report.LabelWH.Text = FormMatStock.label_wh_selected_stock_sum
                    Report.LabelLocator.Text = FormMatStock.label_locator_selected_stock_sum
                    Report.LabelRack.Text = FormMatStock.label_rack_selected_stock_sum
                    Report.LabelDrawer.Text = FormMatStock.label_drawer_selected_stock_sum
                    ReportStyleBanded(Report.BandedGridView1)

                    ' Show the report's preview. 
                    Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                    Tool.ShowPreview()
                End If
            ElseIf FormMatStock.XTCFGStock.SelectedTabPageIndex = 1 Then
                If FormMatStock.GroupControlTraccking.Enabled = False Then 'not yet
                    stopCustom("Data not found.")
                Else
                    'modify period
                    Dim period_from As String = ""
                    Dim period_until As String = ""
                    If FormMatStock.date_from_selected = "0000-01-01" Then
                        period_from = "-"
                    Else
                        period_from = DateTime.Parse(FormMatStock.date_from_selected).ToString("dd MMM yyyy")
                    End If
                    If FormMatStock.date_until_selected = "9999-01-01" Then
                        period_until = "-"
                    Else
                        period_until = DateTime.Parse(FormMatStock.date_until_selected).ToString("dd MMM yyyy")
                    End If

                    '... 
                    ' creating and saving the view's layout to a new memory stream 
                    Dim str As System.IO.Stream
                    str = New System.IO.MemoryStream()
                    FormMatStock.BandedGridViewFGStockCard.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                    str.Seek(0, System.IO.SeekOrigin.Begin)
                    ReportMatStockCard.str_param = str
                    ReportMatStockCard.dt = FormMatStock.dt
                    Dim Report As New ReportMatStockCard()
                    Report.BandedGridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                    Report.LabelWH.Text = FormMatStock.comp_name_label_selected
                    Report.LabelProduct.Text = FormMatStock.label_mat_selected
                    Report.LabelPeriod.Text = period_from + " / " + period_until
                    str.Seek(0, System.IO.SeekOrigin.Begin)
                    ReportStyleBanded(Report.BandedGridView1)

                    ' Show the report's preview. 
                    Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                    Tool.ShowPreview()
                End If
            ElseIf FormMatStock.XTCFGStock.SelectedTabPageIndex = 2 Then
                If FormMatStock.GroupControlStockWo.Enabled = False Then 'not yet
                    stopCustom("Data not found.")
                Else
                    'modify period
                    Dim period_from As String = ""
                    Dim period_until As String = ""
                    If FormMatStock.date_from_selected_stock_vendor = "0000-01-01" Then
                        period_from = "-"
                    Else
                        period_from = DateTime.Parse(FormMatStock.date_from_selected_stock_vendor).ToString("dd MMM yyyy")
                    End If
                    If FormMatStock.date_until_selected_stock_vendor = "9999-01-01" Then
                        period_until = "-"
                    Else
                        period_until = DateTime.Parse(FormMatStock.date_until_selected_stock_vendor).ToString("dd MMM yyyy")
                    End If

                    '... 
                    ' creating and saving the view's layout to a new memory stream 
                    Dim str As System.IO.Stream
                    str = New System.IO.MemoryStream()
                    FormMatStock.BGVStockWO.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                    str.Seek(0, System.IO.SeekOrigin.Begin)
                    ReportMatStockWO.str_param = str
                    ReportMatStockWO.dt = FormMatStock.dt_store
                    Dim Report As New ReportMatStockWO()
                    Report.BandedGridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                    Report.LabelWH.Text = FormMatStock.label_vendor_selected_stock_vendor
                    Report.LabelProduct.Text = FormMatStock.label_mat_selected_stock_vendor
                    Report.LabelPeriod.Text = period_from + " / " + period_until
                    str.Seek(0, System.IO.SeekOrigin.Begin)
                    ReportStyleBanded(Report.BandedGridView1)

                    ' Show the report's preview. 
                    Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                    Tool.ShowPreview()
                End If
            ElseIf FormMatStock.XTCFGStock.SelectedTabPageIndex = 3 Then 'BOM
                If FormMatStock.GCStockBOM.Enabled = False Then 'not yet
                    stopCustom("Data not found.")
                Else
                    'modify period
                    Dim period_from As String = ""
                    Dim period_until As String = ""
                    period_from = Date.Parse(FormMatStock.DEFromBOM.EditValue.ToString).ToString("dd MMM yyyy")
                    period_until = Date.Parse(FormMatStock.DEUntilBOM.EditValue.ToString).ToString("dd MMM yyyy")

                    '... 
                    ' creating and saving the view's layout to a new memory stream 
                    Dim str As System.IO.Stream
                    str = New System.IO.MemoryStream()
                    FormMatStock.BGVStockBOM.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                    str.Seek(0, System.IO.SeekOrigin.Begin)
                    ReportMatStockCard.str_param = str
                    ReportMatStockCard.dt = FormMatStock.GCStockBOM.DataSource
                    Dim Report As New ReportMatStockCard()
                    Report.BandedGridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                    Report.LabelWH.Text = "ALL"
                    Report.LabelProduct.Text = FormMatStock.SLEMatBOM.Text
                    Report.LabelPeriod.Text = period_from + " / " + period_until
                    str.Seek(0, System.IO.SeekOrigin.Begin)
                    ReportStyleBanded(Report.BandedGridView1)

                    ' Show the report's preview. 
                    Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                    Tool.ShowPreview()
                End If
            ElseIf FormMatStock.XTCFGStock.SelectedTabPageIndex = 5 Then 'STOCK REPORT
                If FormMatStock.GroupControl6.Enabled = False Then 'not yet
                    stopCustom("Data not found.")
                Else
                    'modify period
                    Dim period_from As String = ""
                    Dim period_until As String = ""
                    period_from = Date.Parse(FormMatStock.DEStockFrom.EditValue.ToString).ToString("dd MMM yyyy")
                    period_until = Date.Parse(FormMatStock.DEStockTo.EditValue.ToString).ToString("dd MMM yyyy")

                    '... 
                    ' creating and saving the view's layout to a new memory stream 
                    Dim str As System.IO.Stream
                    str = New System.IO.MemoryStream()
                    FormMatStock.GVStockReport.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                    str.Seek(0, System.IO.SeekOrigin.Begin)
                    ReportMatStockReport.dt = FormMatStock.GCStockReport.DataSource
                    Dim Report As New ReportMatStockReport()
                    Report.LabelPeriod.Text = period_from + " / " + period_until
                    Report.GVStockReport.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                    str.Seek(0, System.IO.SeekOrigin.Begin)
                    ReportStyleGridview(Report.GVStockReport)

                    ' Show the report's preview. 
                    Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                    Tool.ShowPreview()
                End If
            End If
            Cursor = Cursors.Default
        ElseIf formName = "FormAccountingSummary" Then
            print_tree(FormAccountingSummary.TreeList1, "Summary Account")
        ElseIf formName = "FormSampleStock" Then
            If FormSampleStock.XTCWHMain.SelectedTabPageIndex = 0 Then 'stock
                'prepare
                Dim period As String = ""
                If FormSampleStock.date_until_stock_selected = "9999-12-01" Then
                    period = FormSampleStock.date_default
                Else
                    period = FormSampleStock.date_until_stock_selected
                End If

                '... 
                ' creating and saving the view's layout to a new memory stream 
                Dim str As System.IO.Stream
                str = New System.IO.MemoryStream()
                FormSampleStock.GVSample.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                ReportSampleStock.dt = FormSampleStock.dt_stock
                Dim Report As New ReportSampleStock()
                Report.GridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                Report.LabelWH.Text = FormSampleStock.wh_stock_selected
                Report.LabelLocator.Text = FormSampleStock.locator_stock_selected
                Report.LabelRack.Text = FormSampleStock.rack_stock_selected
                Report.LabelDrawer.Text = FormSampleStock.drawer_stock_selected
                Report.LabelPeriod.Text = period
                str.Seek(0, System.IO.SeekOrigin.Begin)
                ReportStyleGridview(Report.GridView1)

                ' Show the report's preview. 
                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreview()
            Else
            End If
        ElseIf formName = "FormMasterEmployee" Then
            print(FormMasterEmployee.GCEmployee, "Employee List")
        ElseIf formName = "FormSampleDel" Then
            'PL SAMPLE DELIVERY
            print(FormSampleDel.GCSampleDel, "Packing List Delivery Sample")
        ElseIf formName = "FormSampleDelRec" Then
            'REC PL SAMPLE DELIVERY
            If FormSampleDelRec.XTCSampleDelRec.SelectedTabPageIndex = 0 Then
                print(FormSampleDelRec.GCSampleDelRec, "Receive PL Delivery Sample")
            ElseIf FormSampleDelRec.XTCSampleDelRec.SelectedTabPageIndex = 1 Then
                print(FormSampleDelRec.GCSampleDel, "Waiting to Receive PL Delivery Sample")
            End If
        ElseIf formName = "FormSampleOrder" Then
            'SALES ORDER SAMPKE
            print(FormSampleOrder.GCSampleOrder, "Sales Order Sample")
        ElseIf formName = "FormSampleDelOrder" Then
            'DELIVERY ORDER SAMPLE FOR SALES
            If FormSampleDelOrder.XTCSampleDelOrder.SelectedTabPageIndex = 0 Then
                print(FormSampleDelOrder.GCSampleDelOrder, "Delivery Order Sample")
            ElseIf FormSampleDelOrder.XTCSampleDelOrder.SelectedTabPageIndex = 1 Then
                print(FormSampleDelOrder.GCSampleOrder, "Waiting to Delivery")
            End If
        ElseIf formName = "FormFGCodeReplace" Then
            'CODE REPLACEMENT
            If FormFGCodeReplace.XTCFGCodeReplace.SelectedTabPageIndex = 0 Then
                print(FormFGCodeReplace.GCFGCodeReplaceStore, "Code Replacement In Store")
            ElseIf FormFGCodeReplace.XTCFGCodeReplace.SelectedTabPageIndex = 1 Then
                print(FormFGCodeReplace.GCFGCodeReplaceWH, "Code Replacement In WH")
            End If
        ElseIf formName = "FormAccountingListPR" Then
            'Accounting List PR
            print(FormAccountingListPR.GCPaymentList, "List Open Payment Request")
        ElseIf formName = "FormSampleStockOpname" Then
            'Accounting List PR
            print(FormSampleStockOpname.GCSOWH, "List Stock Opname")
        ElseIf formName = "FormSalesWeekly" Then
            'SALES MONTHLY/WEEKLY
            If FormSalesWeekly.XTCPOS.SelectedTabPageIndex = 0 Then
                'modify period
                Dim period_from As String = ""
                Dim period_until As String = ""
                If FormSalesWeekly.date_from_selected = "0000-01-01" Then
                    period_from = "-"
                Else
                    period_from = DateTime.Parse(FormSalesWeekly.date_from_selected).ToString("dd MMM yyyy")
                End If
                If FormSalesWeekly.date_until_selected = "9999-01-01" Then
                    period_until = "-"
                Else
                    period_until = DateTime.Parse(FormSalesWeekly.date_until_selected).ToString("dd MMM yyyy")
                End If


                ReportSalesPosDaily.dt = FormSalesWeekly.dt
                Dim Report As New ReportSalesPosDaily()

                ' '... 
                ' ' creating and saving the view's layout to a new memory stream 
                Dim str As System.IO.Stream
                str = New System.IO.MemoryStream()
                FormSalesWeekly.GVSalesPOS.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                Report.GridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)

                Dim str2 As System.IO.Stream
                str2 = New System.IO.MemoryStream()
                FormSalesWeekly.GVSalesPOSDet.SaveLayoutToStream(str2, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str2.Seek(0, System.IO.SeekOrigin.Begin)
                Report.GridView2.RestoreLayoutFromStream(str2, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str2.Seek(0, System.IO.SeekOrigin.Begin)
                ReportStyleGridview(Report.GridView1)

                If FormSalesWeekly.label_type_selected = "1" Then
                    Report.GridView1.AppearancePrint.Row.Font = New Font("Segoe UI", 7, FontStyle.Italic)
                ElseIf FormSalesWeekly.label_type_selected = "2" Then
                    Report.GridView1.AppearancePrint.Row.Font = New Font("Segoe UI", 7, FontStyle.Regular)
                End If


                'Grid Detail
                ReportStyleGridview(Report.GridView2)

                Report.LabelPeriod.Text = period_from + " / " + period_until
                Report.LabelWH.Text = FormSalesWeekly.label_store_selected



                '' Show the report's preview. 
                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreview()
            ElseIf FormSalesWeekly.XTCPOS.SelectedTabPageIndex = 1 Then
                'modify period
                Dim period_from As String = ""
                Dim period_until As String = ""
                If FormSalesWeekly.date_from_weekdate_selected = "0000-01-01" Then
                    period_from = "-"
                Else
                    period_from = DateTime.Parse(FormSalesWeekly.date_from_weekdate_selected).ToString("dd MMM yyyy")
                End If
                If FormSalesWeekly.date_until_weekdate_selected = "9999-01-01" Then
                    period_until = "-"
                Else
                    period_until = DateTime.Parse(FormSalesWeekly.date_until_weekdate_selected).ToString("dd MMM yyyy")
                End If

                '... 
                ' creating and saving the view's layout to a new memory stream 
                Dim str As System.IO.Stream
                str = New System.IO.MemoryStream()
                FormSalesWeekly.BGVSalesWeeklyByDate.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                ReportSalesPOSWeeklyByDate.dt = FormSalesWeekly.dt_weekly_by_date


                Dim Report As New ReportSalesPOSWeeklyByDate()
                Report.BGVSalesWeeklyByDate.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)

                Report.LabelYear.Text = FormSalesWeekly.year_selected
                Report.LabelPeriod.Text = period_from + " / " + period_until
                Report.LabelWeek.Text = FormSalesWeekly.week_selected

                ReportStyleBanded(Report.BGVSalesWeeklyByDate)

                ' Show the report's preview. 
                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreview()
            ElseIf FormSalesWeekly.XTCPOS.SelectedTabPageIndex = 2 Then
                If FormSalesWeekly.XTCMonthlySales.SelectedTabPageIndex = 0 Then
                    'modify period
                    Dim period_from As String = ""
                    Dim period_until As String = ""
                    If FormSalesWeekly.date_from_weekly_selected = "0000-01-01" Then
                        period_from = "-"
                    Else
                        period_from = DateTime.Parse(FormSalesWeekly.date_from_weekly_selected).ToString("dd MMM yyyy")
                    End If
                    If FormSalesWeekly.date_until_weekly_selected = "9999-01-01" Then
                        period_until = "-"
                    Else
                        period_until = DateTime.Parse(FormSalesWeekly.date_until_weekly_selected).ToString("dd MMM yyyy")
                    End If

                    '... 
                    ' creating and saving the view's layout to a new memory stream 
                    Dim str As System.IO.Stream
                    str = New System.IO.MemoryStream()
                    FormSalesWeekly.BGVSalesPOSWeekly.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                    str.Seek(0, System.IO.SeekOrigin.Begin)
                    ReportSalesPOSWeekly.dt = FormSalesWeekly.dt_weekly
                    Dim Report As New ReportSalesPOSWeekly()
                    Report.BandedGridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                    str.Seek(0, System.IO.SeekOrigin.Begin)

                    Report.LabelPeriod.Text = period_from + " / " + period_until
                    Report.LabelBegin.Text = FormSalesWeekly.day_weekly_selected

                    ReportStyleBanded(Report.BandedGridView1)

                    ' Show the report's preview. 
                    Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                    Tool.ShowPreview()
                Else
                    'modify period


                    '... 
                    ' creating and saving the view's layout to a new memory stream 
                    Dim str As System.IO.Stream
                    str = New System.IO.MemoryStream()
                    FormSalesWeekly.BGVSalesPOSMonthly.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                    str.Seek(0, System.IO.SeekOrigin.Begin)
                    ReportSalesPOSMonthly.dt = FormSalesWeekly.dt_monthly
                    Dim Report As New ReportSalesPOSMonthly()
                    Report.BandedGridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                    str.Seek(0, System.IO.SeekOrigin.Begin)
                    Report.LabelPeriod.Text = FormSalesWeekly.label_from_monthly_selected + "/" + FormSalesWeekly.label_until_monthly_selected

                    ReportStyleBanded(Report.BandedGridView1)

                    ' Show the report's preview. 
                    Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                    Tool.ShowPreview()
                End If
            ElseIf FormSalesWeekly.XTCPOS.SelectedTabPageIndex = 4 Then
                Dim report As ReportSalesPOSUSA = New ReportSalesPOSUSA

                report.data1 = FormSalesWeekly.GCUSASales.DataSource
                report.data2 = FormSalesWeekly.GCDetailSales.DataSource
                report.data3 = FormSalesWeekly.GCDetailRoyalty.DataSource

                Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

                tool.ShowPreview()
            End If
        ElseIf formName = "FormSalesCreditNote" Then
            'CREDIT NOTE
            print(FormSalesCreditNote.GCSalesPOS, "Credit Note")
        ElseIf formName = "FormSOH" Then
            'SOH
            print(FormSOH.GCSOH, "SOH Compare")
        ElseIf formName = "FormSOHPeriode" Then
            'SOH Periode
            print(FormSOHPeriode.GCSOHPeriode, "SOH Periode")
        ElseIf formName = "FormSOHSum" Then
            'SOH Periode
            print(FormSOHSum.GCSumSOH, "SOH Summary")
        ElseIf formName = "FormSOHPrice" Then
            'SOH Price
            print(FormSOHPrice.GCSOHPeriode, "SOH Price Range")
        ElseIf formName = "FormFGWoff" Then
            'Write OFF
            print(FormFGWoff.GCFGWoff, "Write Off Finished Goods")
        ElseIf formName = "FormFGWoffList" Then
            'Write Off LIst
            Cursor = Cursors.WaitCursor
            '... 
            ' creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            FormFGWoffList.BGVFGStock.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            ReportFGWoffList.dt = FormFGWoffList.GCFGStock.DataSource
            Dim Report As New ReportFGWoffList()
            Report.BandedGridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)

            Report.LabelProduct.Text = FormFGWoffList.label_design_selected_stock_sum
            Report.LabelPeriod.Text = FormFGWoffList.label_date_until_selected_stock_sum

            ReportStyleBanded(Report.BandedGridView1)

            ' Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreview()
            Cursor = Cursors.Default
        ElseIf formName = "FormFGProposePrice" Then
            'FormFGProposePrice
            If FormFGProposePrice.XTCPropose.SelectedTabPageIndex = 0 Then
                print_raw(FormFGProposePrice.GCFGPropose, "Propose Price")
            ElseIf FormFGProposePrice.XTCPropose.SelectedTabPageIndex = 1 Then
                print_raw(FormFGProposePrice.GCRev, "Propose Price Revision")
            ElseIf FormFGProposePrice.XTCPropose.SelectedTabPageIndex = 2 Then
                print_raw(FormFGProposePrice.GCCompare, "Propose Price")
            End If
        ElseIf formName = "FormFGLineList" Then
            'LINE LIST
            Cursor = Cursors.WaitCursor
            print(FormFGLineList.GCLineList, FormFGLineList.SLESeason.Text.ToString.ToUpper + " LINE LIST" + System.Environment.NewLine + "TYPE : " + FormFGLineList.SLETypeLineList.Text.ToUpper)
            'If FormFGLineList.BGVLineList.RowCount > 0 Then
            '    '... 
            '    ' creating and saving the view's layout to a new memory stream 
            '    Dim str As System.IO.Stream
            '    str = New System.IO.MemoryStream()
            '    FormFGLineList.BGVLineList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            '    str.Seek(0, System.IO.SeekOrigin.Begin)
            '    ReportFGLineList.dt = FormFGLineList.GCLineList.DataSource
            '    ReportFGLineList.img_cond = FormFGLineList.CheckImg.EditValue
            '    Dim Report As New ReportFGLineList()
            '    Report.AdvBandedGridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            '    str.Seek(0, System.IO.SeekOrigin.Begin)


            '    Report.LabelSeason.Text = FormFGLineList.SLESeason.Text.ToString
            '    Report.LabelType.Text = FormFGLineList.SLETypeLineList.Text.ToString
            '    ReportStyleBanded(Report.AdvBandedGridView1)
            '    Report.AdvBandedGridView1.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap

            '    ' Show the report's preview. 
            '    Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            '    Tool.ShowPreview()
            'End If
            Cursor = Cursors.Default
        ElseIf formName = "FormMasterRetCode" Then
            print(FormMasterRetCode.GCRetCode, "Return Code")
        ElseIf formName = "FormMasterRateStore" Then
            print(FormMasterRateStore.GCStoreRate, "Rate Store")
        ElseIf formName = "FormFGProdList" Then
            'Product List for Production Dept
            print(FormFGProdList.GCProdList, "Product List - " + FormFGProdList.SLESeason.Text.ToString + "")
        ElseIf formName = "FormBarcodeProduct" Then
            If FormBarcodeProduct.GVProdList.RowCount > 0 Then
                If Not FormBarcodeProduct.GVProdList.IsGroupRow(FormBarcodeProduct.GVProdList.FocusedRowHandle) Then
                    FormBarcodeProductPrint.id_product = FormBarcodeProduct.GVProdList.GetFocusedRowCellValue("id_product").ToString
                    FormBarcodeProductPrint.ShowDialog()
                End If
            End If
        ElseIf formName = "FormMasterDesignCOP" Then
            'Product List for Production Dept
            print(FormMasterDesignCOP.GCDesign, "List Design COP")
        ElseIf formName = "FormSampleOrdered" Then
            'SAMPLE ORDERD
            print(FormSampleOrdered.GCSampleOrder, "Sample Order List")
        ElseIf formName = "FormFGDistScheme" Then
            'DISTRIBUTION SCHEME
            print(FormFGDistScheme.GCDS, "DISTRIBUTION SCHEME - SEASON : " + FormFGDistScheme.SLESeason.Text + " - TYPE : " + FormFGDistScheme.SLEType.Text.ToUpper + "")
        ElseIf formName = "FormProdQCAdj" Then
            If FormProdQCAdj.XTCAdj.SelectedTabPageIndex = 0 Then 'QC adj in
                print(FormProdQCAdj.GCAdjIn, "List QC Adjustment In")
            Else
                print(FormProdQCAdj.GCAdjOut, "List QC Adjustment Out")
            End If
        ElseIf formName = "FormSalesPromo" Then
            'Sales Promo
            print(FormSalesPromo.GCSalesPOS, "List Invoice Sales Promo Marketing")
        ElseIf formName = "FormFGSalesOrderReff" Then
            'SAMPLE ORDERD
            print(FormFGSalesOrderReff.GCSOReff, "Analysis of New Product Order List")
        ElseIf formName = "FormSalesOrderList" Then
            'PREPARE ORDER LIST
            If FormSalesOrderList.XTCWHMonitor.SelectedTabPageIndex = 0 Then
                If FormSalesOrderList.XTCPrepareList.SelectedTabPageIndex = 0 Then
                    print(FormSalesOrderList.GCSalesOrder, "Prepare Order List")
                ElseIf FormSalesOrderList.XTCPrepareList.SelectedTabPageIndex = 1 Then
                    print(FormSalesOrderList.GCSalesOrderHist, "Prepare Order History : " + FormSalesOrderList.DateEditFrom.Text + "-" + FormSalesOrderList.DateEditUntil.Text)
                End If
            ElseIf FormSalesOrderList.XTCWHMonitor.SelectedTabPageIndex = 1 Then
                print(FormSalesOrderList.GCNewPrepare, "Prepare Order New Product : " + FormSalesOrderList.TxtNoParam.Text)
            End If
        ElseIf formName = "FormSalesOrderSvcLevel" Then
            'SERVICE LEVEL
            If FormSalesOrderSvcLevel.XTCSvcLevel.SelectedTabPageIndex = 0 Then
                'PREPARE ORDER
                Dim awal As String = FormSalesOrderSvcLevel.DEFrom.Text
                If awal = "" Then
                    awal = "-"
                End If
                Dim akhir As String = FormSalesOrderSvcLevel.DEUntil.Text
                If akhir = "" Then
                    akhir = "-"
                End If
                Dim period As String = "Period : " + awal + " until " + akhir
                print(FormSalesOrderSvcLevel.GCSalesOrder, "Prepare Order" + System.Environment.NewLine + period)
            ElseIf FormSalesOrderSvcLevel.XTCSvcLevel.SelectedTabPageIndex = 1 Then
                'RETURN ORDER
                Dim awal As String = FormSalesOrderSvcLevel.DEFromRet.Text
                If awal = "" Then
                    awal = "-"
                End If
                Dim akhir As String = FormSalesOrderSvcLevel.DEUntilRet.Text
                If akhir = "" Then
                    akhir = "-"
                End If
                Dim period As String = "Period : " + awal + " until " + akhir
                print(FormSalesOrderSvcLevel.GCSalesReturnOrder, "Return Order" + System.Environment.NewLine + period)
            ElseIf FormSalesOrderSvcLevel.XTCSvcLevel.SelectedTabPageIndex = 2 Then
                'RECEIVED
                Dim awal As String = FormSalesOrderSvcLevel.DEFromRec.Text
                If awal = "" Then
                    awal = "-"
                End If
                Dim akhir As String = FormSalesOrderSvcLevel.DEUntilRec.Text
                If akhir = "" Then
                    akhir = "-"
                End If
                Dim period As String = "Period : " + awal + " until " + akhir
                print(FormSalesOrderSvcLevel.GCPL, "Received Product" + System.Environment.NewLine + period)
            ElseIf FormSalesOrderSvcLevel.XTCSvcLevel.SelectedTabPageIndex = 3 Then
                'DO
                Dim awal As String = FormSalesOrderSvcLevel.DEFromDO.Text
                If awal = "" Then
                    awal = "-"
                End If
                Dim akhir As String = FormSalesOrderSvcLevel.DEUntilDO.Text
                If akhir = "" Then
                    akhir = "-"
                End If
                Dim period As String = "Period : " + awal + " until " + akhir
                print(FormSalesOrderSvcLevel.GCSalesDelOrder, "Delivery Order" + System.Environment.NewLine + period)
            ElseIf FormSalesOrderSvcLevel.XTCSvcLevel.SelectedTabPageIndex = 4 Then
                'RETURN
                Dim awal As String = FormSalesOrderSvcLevel.DEFromReturn.Text
                If awal = "" Then
                    awal = "-"
                End If
                Dim akhir As String = FormSalesOrderSvcLevel.DEUntilReturn.Text
                If akhir = "" Then
                    akhir = "-"
                End If
                Dim period As String = "Period : " + awal + " until " + akhir
                print(FormSalesOrderSvcLevel.GCSalesReturn, "Return" + System.Environment.NewLine + period)
            ElseIf FormSalesOrderSvcLevel.XTCSvcLevel.SelectedTabPageIndex = 5 Then
                'RETURN QC
                Dim awal As String = FormSalesOrderSvcLevel.DEFromReturnQC.Text
                If awal = "" Then
                    awal = "-"
                End If
                Dim akhir As String = FormSalesOrderSvcLevel.DEUntilReturnQC.Text
                If akhir = "" Then
                    akhir = "-"
                End If
                Dim period As String = "Period : " + awal + " until " + akhir
                print(FormSalesOrderSvcLevel.GCSalesReturnQC, "Return QC" + System.Environment.NewLine + period)
            ElseIf FormSalesOrderSvcLevel.XTCSvcLevel.SelectedTabPageIndex = 6 Then
                'TRF
                Dim awal As String = FormSalesOrderSvcLevel.DEFromTrf.Text
                If awal = "" Then
                    awal = "-"
                End If
                Dim akhir As String = FormSalesOrderSvcLevel.DEUntilTrf.Text
                If akhir = "" Then
                    akhir = "-"
                End If
                Dim period As String = "Period : " + awal + " until " + akhir
                print(FormSalesOrderSvcLevel.GCFGTrf, "Transfer" + System.Environment.NewLine + period)
            ElseIf FormSalesOrderSvcLevel.XTCSvcLevel.SelectedTabPageIndex = 8 Then
                'Tracking Return
                Dim sg As String = "Store Group : " + FormTrackingReturn.SLEStoreGroup.Text
                Dim st As String = "Store : " + FormTrackingReturn.SLUEStore.Text
                Dim awal As String = FormTrackingReturn.DEFrom.Text
                If awal = "" Then
                    awal = "-"
                End If
                Dim akhir As String = FormTrackingReturn.DETo.Text
                If akhir = "" Then
                    akhir = "-"
                End If
                Dim period As String = "Period : " + awal + " until " + akhir
                print(FormTrackingReturn.GCList, "Tracking Return" + System.Environment.NewLine + period)
            End If
        ElseIf formName = "FormMasterComputer" Then
            'MASTER COMPUTER
            print(FormMasterComputer.GCComputer, "COMPUTER INFO")
        ElseIf formName = "FormAccountingFakturScan" Then
            'FAKTUR SCAN
            print(FormAccountingFakturScan.GCFak, "FAKTUR SCAN")
        ElseIf formName = "FormFGBorrowQCReq" Then
            'BORRWOW REQ FOR QC FG
            print(FormFGBorrowQCReq.GCBorrowReq, "BORROW REQUEST FOR QC PRODUCT")
        ElseIf formName = "FormWHAWBill" Then
            'AWBill
            If FormWHAWBill.XTCAwb.SelectedTabPageIndex = 0 Then
                print(FormWHAWBill.GCAWBill, "Outbound Delivery")
            Else
                print(FormWHAWBill.GCAwbillIn, "Inbound Delivery")
            End If
        ElseIf formName = "FormMasterPrice" Then
            'MASTER PRICE
            If FormMasterPrice.XTCPrice.SelectedTabPageIndex = 0 Then
                If FormMasterPrice.XTCBrowse.SelectedTabPageIndex = 0 Then
                    print_raw(FormMasterPrice.GCBrowsePrice, "")
                ElseIf FormMasterPrice.XTCBrowse.SelectedTabPageIndex = 1 Then
                    print_raw(FormMasterPrice.GCHistDet, "")
                ElseIf FormMasterPrice.XTCBrowse.SelectedTabPageIndex = 2 Then
                    print_raw(FormMasterPrice.GCHistSummary, "")
                End If
                'print(FormMasterPrice.GCBrowsePrice, "MASTER PRODUCT" + System.Environment.NewLine + "SEASON : " + FormMasterPrice.SLESeason.Text.ToUpper + " / " + "DEL : " + FormMasterPrice.SLEDel.Text.ToUpper + " / " + "DATE : " + FormMasterPrice.DEFrom.Text.ToUpper)
            ElseIf FormMasterPrice.XTCPrice.SelectedTabPageIndex = 1 Then
                print(FormMasterPrice.GCPrice, "IMPORT PRICE FROM EXCEL")
            End If
        ElseIf formName = "FormWHImportDO" Then
            'IMPOT DO
            print(FormWHImportDO.GCImportDO, "DELIVERY ORDER LIST")
        ElseIf formName = "FormFGDesignList" Then
            'DESIGN LIST
            If FormFGDesignList.XTPDesign.SelectedTabPageIndex = 0 Then
                print(FormFGDesignList.GCDesign, FormFGDesignList.SLESeason.Text.ToString.ToUpper)
            Else
                print(FormFGDesignList.GCPropose, "PROPOSE CHANGES")
            End If
        ElseIf formName = "FormWHSvcLevel" Then
            If FormWHSvcLevel.XTCSvcLelel.SelectedTabPageIndex = 0 Then
                print(FormWHSvcLevel.GCBySO, "SERVICE LEVEL BY PREPARE ORDER" + System.Environment.NewLine + "PERIOD : " + FormWHSvcLevel.DEFrom.Text + " - " + FormWHSvcLevel.DEUntil.Text)
            ElseIf FormWHSvcLevel.XTCSvcLelel.SelectedTabPageIndex = 1 Then
                print(FormWHSvcLevel.GCByCode, "SERVICE LEVEL BY CODE" + System.Environment.NewLine + "PERIOD : " + FormWHSvcLevel.DEFromCode.Text + " - " + FormWHSvcLevel.DEUntilCode.Text)
            ElseIf FormWHSvcLevel.XTCSvcLelel.SelectedTabPageIndex = 2 Then
                print(FormWHSvcLevel.GCByAcco, "SERVICE LEVEL BY ACCOUNT" + System.Environment.NewLine + "PERIOD : " + FormWHSvcLevel.DEFromAcc.Text + " - " + FormWHSvcLevel.DEUntilAcc.Text)
            ElseIf FormWHSvcLevel.XTCSvcLelel.SelectedTabPageIndex = 3 Then
                print(FormWHSvcLevel.GCReturn, "RETURN" + System.Environment.NewLine + "PERIOD : " + FormWHSvcLevel.DEFromReturn.Text + " - " + FormWHSvcLevel.DEUntilReturn.Text)
            End If
        ElseIf formName = "FormSamplePLToWH" Then
            'PL SAMPLE
            print(FormSamplePLToWH.GCSamplePL, "PACKING LIST SAMPLE")
        ElseIf formName = "FormMasterPriceSample" Then
            'MASTER PRICE SAMPLE
            If FormMasterPriceSample.XTCPrice.SelectedTabPageIndex = 0 Then
                print(FormMasterPriceSample.GCBrowsePrice, "MASTER SAMPLE PRICE" + System.Environment.NewLine + "SEASON : " + FormMasterPriceSample.SLESeason.Text.ToUpper + " / " + "DATE : " + FormMasterPriceSample.DEFrom.Text.ToUpper)
            ElseIf FormMasterPriceSample.XTCPrice.SelectedTabPageIndex = 1 Then
                print(FormMasterPriceSample.GCPrice, "IMPORT SAMPLE PRICE FROM EXCEL")
            End If
        ElseIf formName = "FormSamplePLExport" Then
            print(FormSamplePLExport.GCSample, "PACKING LIST DETAIL")
        ElseIf formName = "FormFGWHAlloc" Then
            print(FormFGWHAlloc.GCFGWHAlloc, "INVENTORY ALLOCATION")
        ElseIf formName = "FormFGWHAllocLog" Then
            FormFGWHAllocLog.ActiveControl = Nothing
            print(FormFGWHAllocLog.GCFGWHAlloc, "INVENTORY ALLOCATION LOG" + System.Environment.NewLine + FormFGWHAllocLog.DEFrom.Text + " - " + FormFGWHAllocLog.DEUntil.Text)
        ElseIf formName = "FormSampleReturnPL" Then
            print(FormSampleReturnPL.GCSamplePL, "RETURN TO WH LIST")
        ElseIf formName = "FormWHCargoRate" Then
            If FormWHCargoRate.XTCRate.SelectedTabPageIndex = 0 Then
                print(FormWHCargoRate.GCCompany, "Cargo Rate Outbound")
            Else
                print(FormWHCargoRate.GCCompanyIn, "Cargo Rate Inbound")
            End If
        ElseIf formName = "FormEmpShift" Then
            print(FormEmpShift.GCShift, "Template Shift")
        ElseIf formName = "FormEmpAttnInd" Then
            print(FormEmpAttnInd.GCEmployee, "Employee List")
        ElseIf formName = "FormEmpInitialize" Then
            print(FormEmpInitialize.GCEmployee, "Employee List")
        ElseIf formName = "FormEmpHoliday" Then
            If FormEmpHoliday.XTCHoliday.SelectedTabPageIndex = 0 Then
                print(FormEmpHoliday.GCHoliday, "Holiday List")
            Else
                print(FormEmpHoliday.GCSum, "Holiday List")
            End If
        ElseIf formName = "FormFGRepair" Then
            print(FormFGRepair.GCRepair, "Repair Product")
        ElseIf formName = "FormFGRepairRec" Then
            print(FormFGRepairRec.GCRepairRec, "Receive Repair Product")
        ElseIf formName = "FormFGRepairReturn" Then
            If FormFGRepairReturn.XTCData.SelectedTabPageIndex = 0 Then
                print(FormFGRepairReturn.GCRepairReturn, "Return Repair Product")
            Else
                print(FormFGRepairReturn.GCRepairList, "Repair List")
            End If
        ElseIf formName = "FormFGRepairReturnRec" Then
            print(FormFGRepairReturnRec.GCRepairRec, "Receive Repair Product (WH)")
        ElseIf formName = "FormEmpEmail" Then
            FormEmpEmail.GVEmail.ActiveFilterString = "Not IsNullOrEmpty([email_lokal]) Or Not IsNullOrEmpty([email_external]) OR Not IsNullOrEmpty([email_other])"
            print(FormEmpEmail.GCEmail, "Email List")
            FormEmpEmail.GVEmail.ActiveFilterString = ""
        ElseIf formName = "FormEmpLeave" Then
            print(FormEmpLeave.GCLeave, "List Cuti")
        ElseIf formName = "FormEmpDP" Then
            print(FormEmpDP.GCLeave, "List DP")
        ElseIf formName = "FormProductionSummary" Then
            If FormProductionSummary.XTCSum.SelectedTabPageIndex = 0 Then
                print(FormProductionSummary.GCDesign, "APPROVED ORDER")
            ElseIf FormProductionSummary.XTCSum.SelectedTabPageIndex = 1 Then
                print(FormProductionSummary.GCDesign, "APPROVED ORDER")
            End If
        ElseIf formName = "FormProductionFinalClear" Then
            If FormProductionFinalClear.XTCQCReport.SelectedTabPageIndex = 0 Then
                'entry list
                FormProductionFinalClear.BtnView.Focus()
                print(FormProductionFinalClear.GCFinalClear, "FINAL CLEARANCE LIST" + System.Environment.NewLine + FormProductionFinalClear.DEFrom.Text + " - " + FormProductionFinalClear.DEUntil.Text)
                FormProductionFinalClear.DEFrom.Focus()
            ElseIf FormProductionFinalClear.XTCQCReport.SelectedTabPageIndex = 1 Then
                print_raw(FormProductionFinalClear.GCProd, "Order List")
            ElseIf FormProductionFinalClear.XTCQCReport.SelectedTabPageIndex = 2 Then
                print_raw(FormProductionFinalClear.GCSum, "Propose Summary")
            End If
        ElseIf formName = "FormProductionAssembly" Then
            print(FormProductionAssembly.GCData, "Assembly")
        ElseIf formName = "FormEmpLeaveStock" Then
            If FormEmpLeaveStock.XTCLeaveRemaining.SelectedTabPageIndex = 0 Then
                print(FormEmpLeaveStock.GCSum, "Remaining Leave Summary " & FormEmpLeaveStock.LEDeptSum.Text)
            ElseIf FormEmpLeaveStock.XTCLeaveRemaining.SelectedTabPageIndex = 1 Then
                print(FormEmpLeaveStock.GCSchedule, "Remaining Leave Detail " & FormEmpLeaveStock.LEDeptSum.Text)
            End If
        ElseIf formName = "FormSampleSummary" Then
            print(FormSampleSummary.GCListPurchase, "Sample Summary")
        ElseIf formName = "FormWHDelEmpty" Then
            print(FormWHDelEmpty.GCDel, "Non Stock Inventory - Out")
        ElseIf formName = "FormWHDelEmptyStock" Then
            'command print here
            print(FormWHDelEmptyStock.GCData, "NON STOCK INVENTORY - " + FormWHDelEmptyStock.store)
        ElseIf formName = "FormEmpUniPeriod" Then
            print(FormEmpUniPeriod.GCUni, "Uniform Period")
        ElseIf formName = "FormFGTransList" Then
            Dim page As String = FormFGTransList.page_active
            If page = "rec" Then
                If FormFGTransList.XTCRec.SelectedTabPageIndex = 0 Then
                    print(FormFGTransList.GCPL, "RECEIVED PRODUCT (" + FormFGTransList.DEFromRec.Text + " - " + FormFGTransList.DEUntilRec.Text + ")")
                Else
                    print(FormFGTransList.GCPLMain, "RECEIVED PRODUCT (" + FormFGTransList.DEFromRec.Text + " - " + FormFGTransList.DEUntilRec.Text + ")")
                End If
            ElseIf page = "del" Then
                If FormFGTransList.XTCDel.SelectedTabPageIndex = 0 Then
                    print(FormFGTransList.GCSalesDelOrder, "DELIVERY (" + FormFGTransList.DEFromDO.Text + " - " + FormFGTransList.DEUntilDO.Text + ")")
                Else
                    print(FormFGTransList.GCSalesDelOrderMain, "DELIVERY (" + FormFGTransList.DEFromDO.Text + " - " + FormFGTransList.DEUntilDO.Text + ")")
                End If
            ElseIf page = "ret" Then
                If FormFGTransList.XTCReturn.SelectedTabPageIndex = 0 Then
                    print(FormFGTransList.GCSalesReturn, "RETURN (" + FormFGTransList.DEFromReturn.Text + " - " + FormFGTransList.DEUntilReturn.Text + ")")
                Else
                    print(FormFGTransList.GCSalesReturnMain, "RETURN (" + FormFGTransList.DEFromReturn.Text + " - " + FormFGTransList.DEUntilReturn.Text + ")")
                End If
            ElseIf page = "nsr" Then
                print(FormFGTransList.GCNonStock, "NON STOCK (" + FormFGTransList.DEFromNonStock.Text + " - " + FormFGTransList.DEUntilNonStock.Text + ")")
            ElseIf page = "ret_trf" Then
                print(FormFGTransList.GCSalesReturnQC, "RETURN TRANSFER (" + FormFGTransList.DEFromReturnQC.Text + " - " + FormFGTransList.DEUntilReturnQC.Text + ")")
            ElseIf page = "trf" Then
                If FormFGTransList.XTCTrf.SelectedTabPageIndex = 0 Then
                    print(FormFGTransList.GCFGTrf, "TRANSFER (" + FormFGTransList.DEFromTrf.Text + " - " + FormFGTransList.DEUntilTrf.Text + ")")
                Else
                    print(FormFGTransList.GCFGTrfMain, "TRANSFER (" + FormFGTransList.DEFromTrf.Text + " - " + FormFGTransList.DEUntilTrf.Text + ")")
                End If
            ElseIf page = "sal" Then
                If FormFGTransList.XTCSales.SelectedTabPageIndex = 0 Then
                    print(FormFGTransList.GCSales, "SALES (" + FormFGTransList.DEFromSal.Text + " - " + FormFGTransList.DEUntilSal.Text + ")")
                Else
                    print(FormFGTransList.GCSalesMain, "SALES (" + FormFGTransList.DEFromSal.Text + " - " + FormFGTransList.DEUntilSal.Text + ")")
                End If
            ElseIf page = "order" Then
                If FormFGTransList.XTCSO.SelectedTabPageIndex = 0 Then
                    print(FormFGTransList.GCSO, "PREPARE ORDER (" + FormFGTransList.DEFromSO.Text + " - " + FormFGTransList.DEUntilSO.Text + ")")
                Else
                    print(FormFGTransList.GCSOMain, "PREPARE ORDER (" + FormFGTransList.DEFromSO.Text + " - " + FormFGTransList.DEUntilSO.Text + ")")
                End If
            ElseIf page = "repair" Then
                print(FormFGTransList.GCRepair, "Repair (" + FormFGTransList.DEFromRepair.Text + " - " + FormFGTransList.DEUntilRepair.Text + ")")
            End If
        ElseIf formName = "FormProdClosing" Then
            print_raw(FormProdClosing.GCProd, "")
        ElseIf formName = "FormOLStoreSummary" Then
            If FormOLStoreSummary.XTCOLStore.SelectedTabPageIndex = 0 Then
                print_raw(FormOLStoreSummary.GCData, "")
            ElseIf FormOLStoreSummary.XTCOLStore.SelectedTabPageIndex = 1 Then
                print_raw(FormOLStoreSummary.GCDetail, "")
            ElseIf FormOLStoreSummary.XTCOLStore.SelectedTabPageIndex = 2 Then
                If FormOLStoreSummary.XTCPromo.SelectedTabPageIndex = 0 Then
                    print_raw(FormOLStoreSummary.GCPromo, "")
                ElseIf FormOLStoreSummary.XTCPromo.SelectedTabPageIndex = 1 Then
                    print_raw(FormOLStoreSummary.GCPromoDetail, "")
                End If
            End If
        ElseIf formName = "FormFGAging" Then
            print_raw(FormFGAging.GCDesign, "")
        ElseIf formName = "FormFGTransSummary" Then
            If FormFGTransSummary.XtraTabControl.SelectedTabPageIndex = 0 Then
                ReportFGTransSummaryReport.dt = FormFGTransSummary.GCData.DataSource
            ElseIf FormFGTransSummary.XtraTabControl.SelectedTabPageIndex = 1 Then
                ReportFGTransSummaryReport.dt = FormFGTransSummary.GCDesign.DataSource
            End If

            Dim Report As New ReportFGTransSummaryReport()

            ' '... 
            ' ' creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()

            If FormFGTransSummary.XtraTabControl.SelectedTabPageIndex = 0 Then
                FormFGTransSummary.GVData.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            ElseIf FormFGTransSummary.XtraTabControl.SelectedTabPageIndex = 1 Then
                FormFGTransSummary.GVDesign.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            End If

            str.Seek(0, System.IO.SeekOrigin.Begin)
            If FormFGTransSummary.XtraTabControl.SelectedTabPageIndex = 0 Then
                Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            ElseIf FormFGTransSummary.XtraTabControl.SelectedTabPageIndex = 1 Then
                Report.GVDesign.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            End If
            str.Seek(0, System.IO.SeekOrigin.Begin)

            'Grid Detail
            ReportStyleGridview(Report.GVData)

            'Label
            Report.LabelPeriod.Text = FormFGTransSummary.DEFrom.Text + " - " + FormFGTransSummary.DEUntil.Text

            If FormFGTransSummary.XtraTabControl.SelectedTabPageIndex = 0 Then
                Report.WCDesign.Visible = False

                Report.XLTitle.Text = "TRANSACTION SUMMARY"
            ElseIf FormFGTransSummary.XtraTabControl.SelectedTabPageIndex = 1 Then
                Report.WCData.Visible = False

                Report.XLTitle.Text = "TRANSACTION SUMMARY PER PRODUCT"
            End If

            'Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreview()
        ElseIf formName = "FormFGFirstDel" Then
            print_raw(FormFGFirstDel.GCData, "")
        ElseIf formName = "FormFGCompareStockCard" Then
            print_raw(FormFGCompareStockCard.GCData, "")
        ElseIf formName = "FormEmpPayroll" Then
            If FormEmpPayroll.XTCPayroll.SelectedTabPageIndex = 0 Then
                print_raw(FormEmpPayroll.GCPayrollPeriode, "")
            Else
                print_raw(FormEmpPayroll.GCPayroll, "")
            End If
        ElseIf formName = "FormEmpLeaveCut" Then
            print_raw(FormEmpLeaveCut.GCPayrollPeriode, "")
        ElseIf formName = "FormProdOverMemo" Then
            print_raw(FormProdOverMemo.GCMemo, "")
        ElseIf formName = "FormMasterAssetCategory" Then
            print_raw(FormMasterAssetCategory.GCAssetCat, "")
        ElseIf formName = "FormMasterAsset" Then
            If FormMasterAsset.XTCListAsset.SelectedTabPageIndex = 0 Then
                print_raw(FormMasterAsset.GCAsset, "")
            ElseIf FormMasterAsset.XTCListAsset.SelectedTabPageIndex = 1 Then
                print_raw(FormMasterAsset.GCAssetMovingLog, "")
            End If
        ElseIf formName = "FormAssetPO" Then
            print_raw(FormAssetPO.GCPOList, "")
        ElseIf formName = "FormAssetRec" Then
            print_raw(FormAssetRec.GCRecList, "")
        ElseIf formName = "FormEmpUniReport" Then
            print_raw(FormEmpUniReport.GCDetail, "")
        ElseIf formName = "FormEmpUniExpense" Then
            print_raw(FormEmpUniExpense.GCData, "")
        ElseIf formName = "FormItemCatPropose" Then
            If FormItemCatPropose.XTCCat.SelectedTabPageIndex = 0 Then
                print_raw(FormItemCatPropose.GCItemCat, "")
            ElseIf FormItemCatPropose.XTCCat.SelectedTabPageIndex = 1 Then
                print_raw(FormItemCatPropose.GCData, "")
            End If
        ElseIf formName = "FormItemCatMapping" Then
            If FormItemCatMapping.XTCMapping.SelectedTabPageIndex = 0 Then
                print_raw(FormItemCatMapping.GCMapping, "")
            ElseIf FormItemCatMapping.XTCMapping.SelectedTabPageIndex = 1 Then
                print_raw(FormItemCatMapping.GCPropose, "")
            End If
        ElseIf formName = "FormBudgetRevPropose" Then
            If FormBudgetRevPropose.XTCRev.SelectedTabPageIndex = 1 Then
                print_raw_no_export(FormBudgetRevPropose.GCRev)
            ElseIf FormBudgetRevPropose.XTCRev.SelectedTabPageIndex = 2 Then
                print_raw_no_export(FormBudgetRevPropose.GCRevision)
            End If
        ElseIf formName = "FormBudgetExpensePropose" Then
            print_raw(FormBudgetExpensePropose.GCData, "")
        ElseIf formName = "FormBudgetExpenseView" Then
            print_raw_no_export(FormBudgetExpenseView.GCData)
        ElseIf formName = "FormBudgetExpenseRevision" Then
            print_raw_no_export(FormBudgetExpenseRevision.GCData)
        ElseIf formName = "FormPurcReq" Then
            print_raw_no_export(FormPurcReq.GCPurcReq)
        ElseIf formName = "FormPurcOrder" Then
            If FormPurcOrder.XTCPO.SelectedTabPageIndex = 0 Then
                print_raw(FormPurcOrder.GCPurcReq, "List Purchase Request")
            ElseIf FormPurcOrder.XTCPO.SelectedTabPageIndex = 1 Then
                print_raw(FormPurcOrder.GCPO, "List Purchase Order")
            End If
        ElseIf formName = "FormProdDemandRev" Then
            print_raw_no_export(FormProdDemandRev.GCData)
        ElseIf formName = "FormReportMarkCancelList" Then
            print_raw_no_export(FormReportMarkCancelList.GCListCancel)
        ElseIf formName = "FormPurcReceive" Then
            If FormPurcReceive.XTCRec.SelectedTabPageIndex = 0 Then
                print_raw_no_export(FormPurcReceive.GCPO)
            ElseIf FormPurcReceive.XTCRec.SelectedTabPageIndex = 1 Then
                print_raw_no_export(FormPurcReceive.GCReceive)
            ElseIf FormPurcReceive.XTCRec.SelectedTabPageIndex = 2 Then
                If FormPurcReceive.XTCFOC.SelectedTabPageIndex = 0 Then
                    print_raw_no_export(FormPurcReceive.GCFOC)
                ElseIf FormPurcReceive.XTCFOC.SelectedTabPageIndex = 1 Then
                    print_raw_no_export(FormPurcReceive.GCReceiveFOC)
                End If
            End If
        ElseIf formName = "FormPurcReturn" Then
            If FormPurcReturn.XTCReturn.SelectedTabPageIndex = 0 Then
                print_raw_no_export(FormPurcReturn.GCPO)
            ElseIf FormPurcReturn.XTCReturn.SelectedTabPageIndex = 1 Then
                print_raw_no_export(FormPurcReturn.GCReturn)
            End If
        ElseIf formName = "FormPurcItemStock" Then
            If FormPurcItemStock.XTCStock.SelectedTabPageIndex = 0 Then
                print_custom(FormPurcItemStock.GCSOH, "Stock On Hand until " & Date.Parse(FormPurcItemStock.DEUntil.EditValue.ToString).ToString("dd MMMM yyyy"))
            ElseIf FormPurcItemStock.XTCStock.SelectedTabPageIndex = 1 Then
                print_custom(FormPurcItemStock.GCSC, FormPurcItemStock.SLEITem.Text & Environment.NewLine & "" & Date.Parse(FormPurcItemStock.DEFromSC.EditValue.ToString).ToString("dd/MM/yyyy") & " until " & Date.Parse(FormPurcItemStock.DEUntilSC.EditValue.ToString).ToString("dd/MM/yyyy"))
            ElseIf FormPurcItemStock.XTCStock.SelectedTabPageIndex = 3 Then
                print(FormPurcItemStock.GCStockKosong, "Zero Stock (" & Date.Parse(Now().ToString).ToString("dd MMMM yyyy") & ")")
            End If
        ElseIf formName = "FormEmpUniSumReport" Then
            If FormEmpUniSumReport.XTCUniReport.SelectedTabPageIndex = 0 Then
                print_raw(FormEmpUniSumReport.GCPeriod, "")
            ElseIf FormEmpUniSumReport.XTCUniReport.SelectedTabPageIndex = 1 Then
                print_raw(FormEmpUniSumReport.GCByDate, "")
            ElseIf FormEmpUniSumReport.XTCUniReport.SelectedTabPageIndex = 2 Then
                print_raw(FormEmpUniSumReport.GCDetail, "")
            End If
        ElseIf formName = "FormProductionClaimReturn" Then
            print_raw_no_export(FormProductionClaimReturn.GCData)
        ElseIf formName = "FormItemReq" Then
            print_raw_no_export(FormItemReq.GCData)
        ElseIf formName = "FormItemDel" Then
            If FormItemDel.XTCDel.SelectedTabPageIndex = 0 Then
                print_raw_no_export(FormItemDel.GCRequest)
            ElseIf FormItemDel.XTCDel.SelectedTabPageIndex = 1 Then
                print_raw_no_export(FormItemDel.GCDelivery)
            End If
        ElseIf formName = "FormPurcPayment" Then
            print_raw_no_export(FormPurcPayment.GCPOList)
        ElseIf formName = "FormBankWithdrawal" Then
            If FormBankWithdrawal.XTCPO.SelectedTabPageIndex = 0 Then
                print_raw_no_export(FormBankWithdrawal.GCList)
            ElseIf FormBankWithdrawal.XTCPO.SelectedTabPageIndex = 1 Then
                print_raw_no_export(FormBankWithdrawal.GCPOList)
            End If
        ElseIf formName = "FormBankDeposit" Then
            If FormBankDeposit.XTCPO.SelectedTabPageIndex = 0 Then
                print_raw_no_export(FormBankDeposit.GCList)
            ElseIf FormBankDeposit.XTCPO.SelectedTabPageIndex = 1 Then
                print_raw_no_export(FormBankDeposit.GCInvoiceList)
            ElseIf FormBankDeposit.XTCPO.SelectedTabPageIndex = 2 Then
                print_raw_no_export(FormBankDeposit.GCPayout)
            End If
        ElseIf formName = "FormPurcAsset" Then
            If FormPurcAsset.XTCAsset.SelectedTabPageIndex = 0 Then
                'print_raw_no_export(FormPurcAsset.GCPending)
                'permintaan pak agung
                print(FormPurcAsset.GCPending, "Fixed Asset (Pending Asset)")
            ElseIf FormPurcAsset.XTCAsset.SelectedTabPageIndex = 1 Then
                'print_raw_no_export(FormPurcAsset.GCActive)
                'permintaan pak agung
                print(FormPurcAsset.GCActive, "Fixed Asset (Active Asset)")
            End If
        ElseIf formName = "FormItemExpense" Then
            print_raw_no_export(FormItemExpense.GCData)
        ElseIf formName = "FormSalesReturnRec" Then
            'Receive Return
            Dim dateFrom As String = Date.Parse(FormSalesReturnRec.DEFrom.EditValue.ToString).ToString("dd MMMM yyyy")
            Dim dateUntil As String = Date.Parse(FormSalesReturnRec.DEUntil.EditValue.ToString).ToString("dd MMMM yyyy")

            Dim period As String = "Period : " + dateFrom + " until " + dateUntil

            print(FormSalesReturnRec.GCList, "List Receive Return" + System.Environment.NewLine + period)
        ElseIf formName = "FormOpt" Then
            If FormOpt.XTCOpt.SelectedTabPageIndex = 0 Then
                print_raw(FormOpt.GCCode, "List Opt")
            ElseIf FormOpt.XTCOpt.SelectedTabPageIndex = 1 Then
                print_raw(FormOpt.GCOther, "List Opt")
            End If
        ElseIf formName = "FormEmpPerAppraisal" Then
            'Performance Appraisal
            If FormEmpPerAppraisal.XTCEmp.SelectedTabPage.Name = "XTPPenilaian" Then
                print(FormEmpPerAppraisal.GCList, "List Penilaian Kinerja Karyawan")
            ElseIf FormEmpPerAppraisal.XTCEmp.SelectedTabPage.Name = "XTPHistory" Then
                print(FormEmpPerAppraisal.GCHistory, "List History Penilaian Kinerja Karyawan")
            End If
        ElseIf formName = "FormDeptHeadSurvey" Then

            If FormDeptHeadSurvey.XTCSurvey.SelectedTabPage.Name = "XTPForm" Then

            ElseIf FormDeptHeadSurvey.XTCSurvey.SelectedTabPage.Name = "XTPPeriod" Then
                print(FormDeptHeadSurvey.GCListPeriod, "List Periode Survey Dept Head")
            End If
        ElseIf formName = "FormSetKurs" Then
            'Kurs Transaksi
            print(FormSetKurs.GCKursTrans, "List Kurs")
        ElseIf formName = "FormCashAdvance" Then
            'FormCashAdvance
            FormCashAdvance.print_list()
        ElseIf formName = "FormVerifyMaster" Then
            'verify master
            If FormVerifyMaster.XTCVerify.SelectedTabPageIndex = 0 Then
                print_raw(FormVerifyMaster.GCData, "")
            ElseIf FormVerifyMaster.XTCVerify.SelectedTabPageIndex = 1 Then
                print_raw(FormVerifyMaster.GCHistory, "")
            End If
        ElseIf formName = "FormSampleExpense" Then
            'Sample Purchase Material
            print(FormSampleExpense.GCPurchaseList, "List Purchase Sample Material")
        ElseIf formName = "FormOLStore" Then
            If FormOLStore.XtraTabControl1.SelectedTabPageIndex = 0 Then
                print_raw(FormOLStore.GCSummary, "")
            ElseIf FormOLStore.XtraTabControl1.SelectedTabPageIndex = 1 Then
                print_raw(FormOLStore.GCDetail, "")
            ElseIf FormOLStore.XtraTabControl1.SelectedTabPageIndex = 2 Then
                print_raw(FormOLStore.GCCancellOrder, "")
            End If
        ElseIf formName = "FormEmloyeePps" Then
            'employee propose
            print(FormEmloyeePps.GCEmployeePps, "List Proposal")
        ElseIf formName = "FormSamplePurcClose" Then
            print(FormSamplePurcClose.GCListClose, "List Close Item Purchase")
        ElseIf formName = "FormEmpOvertime" Then
            If FormEmpOvertime.XTCPropose.SelectedTabPage.Name = "XTPByRequest" Then
                print(FormEmpOvertime.GCOvertime, "List Overtime")
            End If

            If FormEmpOvertime.XTCPropose.SelectedTabPage.Name = "XTPByEmployee" Then
                print(FormEmpOvertime.GCProposeEmployee, "List Overtime")
            End If
        ElseIf formName = "FormInvoiceFGPO" Then
            FormInvoiceFGPO.print_list()
        ElseIf formName = "FormFGLinePlan" Then
            FormFGLinePlan.GridColumnis_select.Visible = False
            FormFGLinePlan.GVData.BestFitColumns()
            print_raw(FormFGLinePlan.GCData, "")
            If FormFGLinePlan.is_view = "-1" Then
                FormFGLinePlan.GridColumnis_select.VisibleIndex = 0
                FormFGLinePlan.GVData.BestFitColumns()
            End If
        ElseIf formName = "FormWorkOrder" Then
            print(FormWorkOrder.GCWorkOrder, "List Work Order")
        ElseIf formName = "FormSalesTargetPropose" Then
            If FormSalesTargetPropose.XTCPropose.SelectedTabPageIndex = 0 Then
                print(FormSalesTargetPropose.GCData, "")
            ElseIf FormSalesTargetPropose.XTCPropose.SelectedTabPageIndex = 1 Then

            End If
        ElseIf formName = "FormReportEstWHInQty" Then
            If FormReportEstWHInQty.XTCTimeline.SelectedTabPageIndex = 0 Then
                print(FormReportEstWHInQty.GCWorkOrder, "Estimate Qty to WH (" & Date.Parse(FormReportEstWHInQty.DEStart.EditValue.ToString).ToString("dd MMMM yyyy") & " - " & Date.Parse(FormReportEstWHInQty.DEEnd.EditValue.ToString).ToString("dd MMMM yyyy") & ")")
            ElseIf FormReportEstWHInQty.XTCTimeline.SelectedTabPageIndex = 1 Then
                print(FormReportEstWHInQty.GCPD, "PD vs PO Material " & FormReportEstWHInQty.SLEReport.Text)
            End If
        ElseIf formName = "FormProductionHO" Then
            If FormProductionHO.XTCHO.SelectedTabPageIndex = 0 Then
                print_raw(FormProductionHO.GCList, "")
            ElseIf FormProductionHO.XTCHO.SelectedTabPageIndex = 1 Then
                print_raw(FormProductionHO.GCDetail, "")
            ElseIf FormProductionHO.XTCHO.SelectedTabPageIndex = 2 Then
                print_raw(FormProductionHO.GCSummary, "")
            End If
        ElseIf formName = "FormSalesOrderReport" Then
            If FormSalesOrderReport.XTCSO.SelectedTabPageIndex = 0 Then
                print_raw(FormSalesOrderReport.GCNew, "")
            ElseIf FormSalesOrderReport.XTCSO.SelectedTabPageIndex = 1 Then
                print_raw(FormSalesOrderReport.GCAll, "")
            End If
        ElseIf formName = "FormProposeEmpSalary" Then
            'employee propose
            print(FormProposeEmpSalary.GCList, "List Propose Employee Salary")
        ElseIf formName = "FormItemSubCat" Then
            'purchase category
            print(FormItemSubCat.GCPurchaseCategory, "List Purchase Category")
        ElseIf formName = "FormItemCatMain" Then
            If FormItemCatMain.XTCCat.SelectedTabPageIndex = 0 Then
                print_raw(FormItemCatMain.GCItemCat, "")
            ElseIf FormItemCatMain.XTCCat.SelectedTabPageIndex = 1 Then
                print_raw(FormItemCatMain.GCData, "")
            End If
        ElseIf formName = "FormSalesRecord" Then
            print_raw(FormSalesRecord.GCData, "")
        ElseIf formName = "FormARAging" Then
            print_raw(FormARAging.GCData, "")
        ElseIf formName = "FormReportBudget" Then
            'report budget
            print(FormReportBudget.GCItemCat, "Summary Budget")
        ElseIf formName = "FormVoucherPOS" Then
            'Voucher POS
            print_raw(FormVoucherPOS.GCData, "")
        ElseIf formName = "FormPromoRules" Then
            print(FormPromoRules.GCStore, FormPromoRules.GVRules.GetFocusedRowCellValue("name").ToString + " (" + FormPromoRules.GVRules.GetFocusedRowCellValue("code").ToString + ")" + " - " + "Limit Value : " + FormPromoRules.GVRules.GetFocusedRowCellValue("limit_value").ToString)
        ElseIf formName = "FormEmpInputAttendance" Then
            'input attendance
            print(FormEmpInputAttendance.GCList, "Input Attendance")
        ElseIf formName = "FormPurcReqList" Then
            'purchase request IC
            FormPurcReqList.print_report()
        ElseIf formName = "FormBuktiPickup" Then
            print(FormBuktiPickup.GCList, "Bukti Pickup")
        ElseIf formName = "FormDebitNote" Then
            print(FormDebitNote.GCDebitNote, "Debit Note")
        ElseIf formName = "FormTrackingReturn" Then
            print_raw(FormTrackingReturn.GCList, "Tracking Return")
        ElseIf formName = "FormEmpBPJSKesehatan" Then
            print(FormEmpBPJSKesehatan.GCList, "BPJS Kesehatan")
        ElseIf formName = "FormPopUpCompGroup" Then
            print(FormPopUpCompGroup.GCGroupComp, "Company Group")
        ElseIf formName = "FormCompanyEmailMapping" Then
            If FormCompanyEmailMapping.XtraTabControl.SelectedTabPageIndex = 0 Then
                print(FormCompanyEmailMapping.GCListStoreGroup, "Store Group Mapping")
            ElseIf FormCompanyEmailMapping.XtraTabControl.SelectedTabPageIndex = 1 Then
                print(FormCompanyEmailMapping.GCListInternal, "Internal Mapping")
            Else
                print(FormCompanyEmailMapping.GC3PL, "3PL Mapping")
            End If
        ElseIf formName = "FormMailManage" Then
            If FormMailManage.XTCMailManage.SelectedTabPageIndex = 0 Then
                print_raw(FormMailManage.GCData, "")
            ElseIf FormMailManage.XTCMailManage.SelectedTabPageIndex = 1 Then
                print_raw(FormMailManage.GCInvoiceList, "")
            ElseIf FormMailManage.XTCMailManage.SelectedTabPageIndex = 2 Then
                print_raw(FormMailManage.GCUnpaid, "")
            End If
        ElseIf formName = "FormInvoiceTracking" Then
            If FormInvoiceTracking.XTCInvTrack.SelectedTabPageIndex = 0 Then
                FormInvoiceTracking.print()
            Else
                FormInvoiceTracking.summary_print()
            End If
        ElseIf formName = "FormInvMat" Then
            FormInvMat.print_list()
        ElseIf formName = "FormAREvalScheduke" Then
            print_raw(FormAREvalScheduke.GCData, "")
        ElseIf formName = "FormDelayPayment" Then
            print_raw(FormDelayPayment.GCData, "")
        ElseIf formName = "FormAccountingLedger" Then
            FormAccountingLedger.print_form()
        ElseIf formName = "FormAREvaluation" Then
            If FormAREvaluation.XTCData.SelectedTabPageIndex = 0 Then
                If FormAREvaluation.XTCCreateNewEval.SelectedTabPageIndex = 0 Then
                    print_raw(FormAREvaluation.GCActiveList, "")
                ElseIf FormAREvaluation.XTCCreateNewEval.SelectedTabPageIndex = 1 Then
                    print_raw(FormAREvaluation.GCGroupStoreList, "")
                End If
            ElseIf FormAREvaluation.XTCData.SelectedTabPageIndex = 1 Then
                FormAREvaluation.printDetail()
            ElseIf FormAREvaluation.XTCData.SelectedTabPageIndex = 2 Then
                print_raw(FormAREvaluation.GCGroup, "")
            End If
        ElseIf formName = "FormDelManifest" Then
            print(FormDelManifest.GCList, FormDelManifest.Text)
        ElseIf formName = "FormARCollectionAvg" Then
            If FormARCollectionAvg.XTCData.SelectedTabPageIndex = 0 Then
                print_raw(FormARCollectionAvg.GCSummary, "")
            ElseIf FormARCollectionAvg.XTCData.SelectedTabPageIndex = 1 Then
                print_raw(FormARCollectionAvg.GCDetail, "")
            End If
        ElseIf formName = "FormFollowUpAR" Then
            If FormFollowUpAR.XTCAR.SelectedTabPageIndex = 0 Then
                print_raw(FormFollowUpAR.GCData, "")
            ElseIf FormFollowUpAR.XTCAR.SelectedTabPageIndex = 1 Then
                print_raw(FormFollowUpAR.GCActive, "")
            End If
        ElseIf formName = "FormAccountingWorksheet" Then
            FormAccountingWorksheet.print_form()
        ElseIf formName = "FormEmpUniCreditNote" Then
            print(FormEmpUniCreditNote.GCData, "Credit Note Uniform")
        ElseIf formName = "FormDocTracking" Then
            print_raw(FormDocTracking.GCData, "")
        ElseIf formName = "FormSalesInv" Then
            If FormSalesInv.XTCSalesInv.SelectedTabPageIndex = 0 Then
                ReportSalesInvReport.dt = FormSalesInv.GCByProduct.DataSource
            ElseIf FormSalesInv.XTCSalesInv.SelectedTabPageIndex = 1 Then
                ReportSalesInvReport.dt = FormSalesInv.GCByAccount.DataSource
            End If

            Dim Report As New ReportSalesInvReport()

            ' '... 
            ' ' creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            If FormSalesInv.XTCSalesInv.SelectedTabPageIndex = 0 Then
                FormSalesInv.GVByProduct.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            ElseIf FormSalesInv.XTCSalesInv.SelectedTabPageIndex = 1 Then
                FormSalesInv.GVByAccount.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            End If
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Report.GVByProduct.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)

            'Grid Detail
            ReportStyleBanded(Report.GVByProduct)

            'Label
            If FormSalesInv.XTCSalesInv.SelectedTabPageIndex = 0 Then
                Report.LabelAccount.Text = FormSalesInv.SLEComp.Text
                Report.LabelPeriod.Text = FormSalesInv.DEFrom.Text + " - " + FormSalesInv.DEUntil.Text
                Report.XLTitle.Text = "SALES / INVENTORY"
            ElseIf FormSalesInv.XTCSalesInv.SelectedTabPageIndex = 1 Then
                Report.LabelAccount.Text = FormSalesInv.SLEAccount.Text
                Report.LabelPeriod.Text = FormSalesInv.DEFromAcc.Text + " - " + FormSalesInv.DEUntilAcc.Text
                Report.XLTitle.Text = "SALES / INVENTORY PER ACCOUNT"
            End If


            'Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreview()
        ElseIf formName = "FormLineList" Then
            print_raw(FormLineList.GCData, "")
        ElseIf formName = "FormPaymentMissing" Then
            FormPaymentMissing.form_print()
        ElseIf formName = "FormBudgetProdDemand" Then
            If FormBudgetProdDemand.XTCBudget.SelectedTabPageIndex = 0 Then
                print_raw(FormBudgetProdDemand.GCApprovedBudget, "")
            ElseIf FormBudgetProdDemand.XTCBudget.SelectedTabPageIndex = 1 Then
                print_raw(FormBudgetProdDemand.GCProposed, "")
            End If
        ElseIf formName = "FormTabunganMissing" Then
            FormTabunganMissing.print()
        ElseIf formName = "FormCompareStockWebsite" Then
            FormCompareStockWebsite.print_compare()
        ElseIf formName = "FormRetOlStore" Then
            print(FormRetOlStore.GCData, "Pre Return List")
        ElseIf formName = "FormRefundOLStore" Then
            print(FormRefundOLStore.GCData, "Accepted Refund List")
        ElseIf formName = "FormPromoCollection" Then
            print(FormPromoCollection.GCData, "Promo Collection List")
        ElseIf formName = "FormPayoutReport" Then
            print(FormPayoutReport.GCData, "Payout Report")
        ElseIf formName = "FormSalesBranch" Then
            print(FormSalesBranch.GCData, "Volcom Store Sales")
        ElseIf formName = "FormABGRoyaltyZone" Then
            print(FormABGRoyaltyZone.GCData, "ABG Royalty Zone")
        ElseIf formName = "FormMailManageReturn" Then
            If FormMailManageReturn.XTCMailManage.SelectedTabPageIndex = 0 Then
                print_raw(FormMailManageReturn.GCData, "")
            ElseIf FormMailManageReturn.XTCMailManage.SelectedTabPageIndex = 1 Then
                print_raw(FormMailManageReturn.GCReturnOrder, "")
            End If
        ElseIf formName = "FormAdditionalCost" Then
            print(FormAdditionalCost.GCAdditionalCost, "Additional Cost Propose List")
        ElseIf formName = "FormDesignImages" Then
            FormDesignImages.print_images()
        ElseIf formName = "FormEmployeeContract" Then
            print(FormEmployeeContract.GCEmployeeContract, "Employee Contract")
        ElseIf formName = "FormSalesReturnOrderMail" Then
            print(FormSalesReturnOrderMail.GCDetail, "Propose Return Mail")
        ElseIf formName = "FormInbound3PL" Then
            print(FormInbound3PL.GCAwb, "AWB Inbound dengan 3PL")
        ElseIf formName = "FormReturnNote" Then
            print(FormReturnNote.GCAwb, "Return Note List")
        ElseIf formName = "FormListStore" Then
            print(FormListStore.GCCompany, "Store List")
        ElseIf formName = "FormScanReturn" Then
            If FormScanReturn.XTCScanReturn.SelectedTabPageIndex = 0 Then
                print(FormScanReturn.GCAwb, "Scan Return List")
            Else
                print(FormScanReturn.GCBAP, "BAP List")
            End If
        ElseIf formName = "FormAdjustmentOG" Then
            print(FormAdjustmentOG.GCList, "Adjustment Operational Goods")
        ElseIf formName = "FormOLReturnRefuse" Then
            If FormOLReturnRefuse.XTCData.SelectedTabPageIndex = 0 Then
                print(FormOLReturnRefuse.GCData, "Created List")
            ElseIf FormOLReturnRefuse.XTCData.SelectedTabPageIndex = 1 Then
                print(FormOLReturnRefuse.GCOrder, "Order List")
            End If
        ElseIf formName = "FormPricePolicyCode" Then
            print(FormPricePolicyCode.GCData, "Price Policy Code")
        ElseIf formName = "FormDeliveryMonitoring" Then
            FormDeliveryMonitoring.print_outbound()
        ElseIf formName = "FormProposePriceMKD" Then
            If FormProposePriceMKD.XTCData.SelectedTabPageIndex = 0 Then
                print_raw(FormProposePriceMKD.GCSummary, "")
            ElseIf FormProposePriceMKD.XTCData.SelectedTabPageIndex = 1 Then

            End If
        ElseIf formName = "FormOutboundPOD" Then
            print_raw(FormOutboundPOD.GCData, "")
        ElseIf formName = "FormCatalogSpec" Then
            print_raw(FormCatalogSpec.GCDesign, "")
        ElseIf formName = "FormStockTakeStorePeriod" Then
            print(FormStockTakeStorePeriod.GCPeriod, "Stock Take Store Period")
        ElseIf formName = "FormOGTransfer" Then
            print(FormOGTransfer.GCOGTransfer, "Transfer List")
        ElseIf formName = "FormAWBOther" Then
            print(FormAWBOther.GCList, "AWB List " & FormAWBOther.SLECargo.Text & " (" & Date.Parse(FormAWBOther.DEStart.EditValue.ToString).ToString("dd MMMM yyyy") & " - " & Date.Parse(FormAWBOther.DEUntil.EditValue.ToString).ToString("dd MMMM yyyy") & ") ")
        ElseIf formName = "FormSNIppsBudget" Then
            print(FormSNIppsBudget.GCList, "SNI Porposal List ")
        ElseIf formName = "FormSNISerahTerima" Then
            print(FormSNISerahTerima.GCList, "List SNI Serah Terima ")
        ElseIf formName = "FormSNIRealisasi" Then
            print(FormSNIRealisasi.GCRealisasi, "List SNI Realisasi ")
        ElseIf formName = "FormSNIQC" Then
            If FormSNIQC.XTCInOut.SelectedTabPageIndex = 0 Then
                'out
                If FormSNIQC.GVSNIOut.RowCount > 0 Then
                    print(FormSNIQC.GCSNIOut, "List SNI Out form QC ")
                End If
            Else
                'in
                If FormSNIQC.GVSNIIn.RowCount > 0 Then
                    print(FormSNIQC.GCSNIIn, "List SNI In from QC")
                End If
            End If
        ElseIf formName = "FormPreCalFGPO" Then
            print(FormPreCalFGPO.GCPreCal, "List Pre Calculation ")
        ElseIf formName = "FormStoreStatus" Then
            print(FormStoreStatus.GCData, "Store Status List")
        ElseIf formName = "FormPriceMKDVios" Then
            print(FormPriceMKDVios.GCData, "Turun Harga - Online Store")
        ElseIf formName = "FormMaterialRequisition" Then
            print(FormMaterialRequisition.GCMRS, "List Material Requisition")
        ElseIf formname = "FormCapsule" Then
            print(FormCapsule.GCData, "Capsule Data")
        ElseIf formname = "FormPrepaidExpense" Then
            print(FormPrepaidExpense.GCData, "List Prepaid Expense")
        ElseIf formname = "FormPromoZalora" Then
            FormPromoZalora.printList()
        ElseIf formname = "FormProposePromo" Then
            print(FormProposePromo.GCPromo, "List Propose Promo")
        ElseIf formname = "FormNominatifPromo" Then
            FormNominatifPromo.form_print()
        ElseIf formName = "FormRetExos" Then
            FormRetExos.printList()
        ElseIf formName = "FormDisableExos" Then
            FormDisableExos.printList()
        ElseIf formName = "FormEOSChange" Then
            FormEOSChange.printList()
        ElseIf formName = "FormEts" Then
            FormEts.printList()
        ElseIf formName = "FormBSP" Then
            FormBSP.printList()
        Else
            RPSubMenu.Visible = False
        End If
        Cursor = Cursors.Default
    End Sub
    'Close Menu
    Private Sub BBClose_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBClose.ItemClick
        If formName = "FormMasterArea" Then
            FormMasterArea.Close()
        ElseIf formName = "FormMasterCompany" Then
            '
            FormMasterCompany.Close()
        ElseIf formName = "FormMasterCompanyCategory" Then
            '
            FormMasterCompanyCategory.Close()
        ElseIf formName = "FormMasterDepartement" Then
            '
            FormMasterDepartement.Close()
        ElseIf formName = "FormMasterRawMaterialCat" Then
            '
            FormMasterRawMaterialCat.Close()
            FormMasterRawMaterialCat.Dispose()
        ElseIf formName = "FormMasterItemColor" Then
            '
            FormMasterItemColor.Close()
            FormMasterItemColor.Dispose()
        ElseIf formName = "FormMasterItemSize" Then
            '
            FormMasterItemSize.Close()
            FormMasterItemSize.Dispose()
        ElseIf formName = "FormMasterUser" Then
            '
            FormMasterUser.Close()
        ElseIf formName = "FormSeason" Then
            '
            FormSeason.Close()
            FormSeason.Dispose()
        ElseIf formName = "FormMasterUOM" Then
            '
            FormMasterUOM.Close()
            FormMasterUOM.Dispose()
        ElseIf formName = "FormMasterRawMaterial" Then
            '
            FormMasterRawMaterial.Close()
            FormMasterRawMaterial.Dispose()
        ElseIf formName = "FormSetupRawMatCode" Then
            FormSetupRawMatCode.Close()
            FormMasterRawMat.Dispose()
        ElseIf formName = "FormMasterOVH" Then
            FormMasterOVH.Close()
            FormMasterOVH.Dispose()
        ElseIf formName = "FormProdDemand" Then
            FormProdDemand.Close()
            FormProdDemand.Dispose()
        ElseIf formName = "FormMasterCode" Then
            '
            FormMasterCode.Close()
            FormMasterCode.Dispose()
        ElseIf formName = "FormTemplateCode" Then
            FormTemplateCode.Close()
            FormTemplateCode.Dispose()
        ElseIf formName = "FormMasterProduct" Then
            '
            FormMasterProduct.Close()
            FormMasterProduct.Dispose()
        ElseIf formName = "FormMasterSample" Then
            '
            FormMasterSample.Close()
            FormMasterSample.Dispose()
        ElseIf formName = "FormBOM" Then
            '
            FormBOM.Close()
            FormBOM.Dispose()
        ElseIf formName = "FormAccess" Then
            '
            FormAccess.Close()
            FormAccess.Dispose()
        ElseIf formName = "FormSamplePL" Then
            'PACKING LIST SAMPLE
            FormSamplePL.Close()
            FormSamplePL.Dispose()
        ElseIf formName = "FormSamplePLDel" Then
            'PACKING LIST SAMPLE Del
            FormSamplePLDel.Close()
            FormSamplePLDel.Dispose()
        ElseIf formName = "FormSamplePurchase" Then
            '
            FormSamplePurchase.Close()
            FormSamplePurchase.Dispose()
        ElseIf formName = "FormSampleReceive" Then
            '
            FormSampleReceive.Close()
            FormSampleReceive.Dispose()
        ElseIf formName = "FormMasterWH" Then
            'WAREHOUSE & LOCATOR
            FormMasterWH.Close()
            FormMasterWH.Dispose()
        ElseIf formName = "FormSampleReceipt" Then
            'Receipt Sample
            FormSampleReceipt.Close()
            FormSampleReceipt.Dispose()
        ElseIf formName = "FormSampleRet" Then
            'RETURN SAMPLE
            FormSampleRet.Close()
            FormSampleRet.Dispose()
        ElseIf formName = "FormSampleReq" Then
            'REQ SAMPLE
            FormSampleReq.Close()
            FormSampleReq.Dispose()
        ElseIf formName = "FormMarkAssign" Then
            'Assign mark
            FormMarkAssign.Close()
            FormMarkAssign.Dispose()
        ElseIf formName = "FormSamplePlan" Then
            'Planning Sample
            FormSamplePlan.Close()
            FormSamplePlan.Dispose()
        ElseIf formName = "FormWork" Then
            'Work
            FormWork.Close()
            FormWork.Dispose()
        ElseIf formName = "FormMatPurchase" Then
            'Material Purchase
            FormMatPurchase.Close()
            FormMatPurchase.Dispose()
        ElseIf formName = "FormMatWO" Then
            'Material Purchase
            FormMatWO.Close()
            FormMatWO.Dispose()
        ElseIf formName = "FormMatRecPurc" Then
            'Receive Purchase Material
            FormMatRecPurc.Close()
            FormMatRecPurc.Dispose()
        ElseIf formName = "FormMatRecWO" Then
            'Receive WO Material
            FormMatRecWO.Close()
            FormMatRecWO.Dispose()
        ElseIf formName = "FormMatRet" Then
            'Return Mat
            FormMatRet.Close()
            FormMatRet.Dispose()
        ElseIf formName = "FormSampleReturn" Then
            'Sample Return
            FormSampleReturn.Close()
            FormSampleReturn.Dispose()
        ElseIf formName = "FormSampleAdjustment" Then
            'Sample Adjustment
            FormSampleAdjustment.Close()
            FormSampleAdjustment.Dispose()
        ElseIf formName = "FormMatAdj" Then
            'Mat Adjustment
            FormMatAdj.Close()
            FormMatAdj.Dispose()
        ElseIf formName = "FormMatPR" Then
            'PR PO Material
            FormMatPR.Close()
            FormMatPR.Dispose()
        ElseIf formName = "FormMatPRWO" Then
            'PR WO Material
            FormMatPRWO.Close()
            FormMatPRWO.Dispose()
        ElseIf formName = "FormProduction" Then
            'Form Production
            FormProduction.Close()
            FormProduction.Dispose()
        ElseIf formName = "FormMatPL" Then
            'Material Packing List
            FormMatPL.Close()
            FormMatPL.Dispose()
        ElseIf formName = "FormMatMRS" Then
            'Material Requisition
            FormMatMRS.Close()
            FormMatMRS.Dispose()
        ElseIf formName = "FormProductionRec" Then
            'Form Production Rec QC
            FormProductionRec.Close()
            FormProductionRec.Dispose()
        ElseIf formName = "FormProductionRet" Then
            'Return FG
            FormProductionRet.Close()
            FormProductionRet.Dispose()
        ElseIf formName = "FormProductionPLToWH" Then
            'PL To WH
            FormProductionPLToWH.Close()
            FormProductionPLToWH.Dispose()
        ElseIf formName = "FormMatInvoice" Then
            'Invoice material PL
            FormMatInvoice.Close()
            FormMatInvoice.Dispose()
        ElseIf formName = "FormAccounting" Then
            FormAccounting.Close()
            FormAccounting.Dispose()
        ElseIf formName = "FormProductionPLToWHRec" Then
            'Rec PL To WH
            FormProductionPLToWHRec.Close()
            FormProductionPLToWHRec.Dispose()
        ElseIf formName = "FormSalesTarget" Then
            'SALEES TARGET
            FormSalesTarget.Close()
            FormSalesTarget.Dispose()
        ElseIf formName = "FormSalesOrder" Then
            'SALEES ORDER
            FormSalesOrder.Close()
            FormSalesOrder.Dispose()
        ElseIf formName = "FormSalesDelOrder" Then
            FormSalesDelOrder.Close()
            FormSalesDelOrder.Dispose()
        ElseIf formName = "FormSalesReturnOrder" Then
            'SALEES RETURN ORDER
            FormSalesReturnOrder.Close()
            FormSalesReturnOrder.Dispose()
        ElseIf formName = "FormSalesReturnOrderOL" Then
            'SALEES RETURN ORDER OL
            FormSalesReturnOrderOL.Close()
            FormSalesReturnOrderOL.Dispose()
        ElseIf formName = "FormSalesReturn" Then
            'SALES RETURN
            FormSalesReturn.Close()
            FormSalesReturn.Dispose()
        ElseIf formName = "FormSalesPOS" Then
            'SALES POS
            FormSalesPOS.Close()
            FormSalesPOS.Dispose()
        ElseIf formName = "FormSalesReturnQC" Then
            'SALES RETURN QC
            FormSalesReturnQC.Close()
            FormSalesReturnQC.Dispose()
        ElseIf formName = "FormAccountingJournal" Then
            'Journal
            FormAccountingJournal.Close()
            FormAccountingJournal.Dispose()
        ElseIf formName = "FormAccountingJournalAdj" Then
            'Adjustment Journal
            FormAccountingJournalAdj.Close()
            FormAccountingJournalAdj.Dispose()
        ElseIf formName = "FormProdPRWO" Then
            'Rec PL To WH
            FormProdPRWO.Close()
            FormProdPRWO.Dispose()
        ElseIf formName = "FormSalesInvoice" Then
            'SALES INVOICE
            FormSalesInvoice.Close()
            FormSalesInvoice.Dispose()
        ElseIf formName = "FormFGStockOpnameStore" Then
            'STORE STOCK OPNAME
            FormFGStockOpnameStore.Close()
            FormFGStockOpnameStore.Dispose()
        ElseIf formName = "FormFGMissing" Then
            'FG MISSING
            FormFGMissing.Close()
            FormFGMissing.Dispose()
        ElseIf formName = "FormFGMissingInvoice" Then
            'FG Missing INVOICE
            FormFGMissingInvoice.Close()
            FormFGMissingInvoice.Dispose()
        ElseIf formName = "FormFGStockOpnameWH" Then
            'WH STOCK OPNAME
            FormFGStockOpnameWH.Close()
            FormFGStockOpnameWH.Dispose()
        ElseIf formName = "FormMatStockOpname" Then
            'Material Stock Opname
            FormMatStockOpname.Close()
            FormMatStockOpname.Dispose()
        ElseIf formName = "FormFGAdj" Then
            'FG Adjustment
            FormFGAdj.Close()
            FormFGAdj.Dispose()
        ElseIf formName = "FormFGTrf" Then
            'FG Transfer Future
            FormFGTrf.Close()
            FormFGTrf.Dispose()
        ElseIf formName = "FormFGTrfNew" Then
            'FG Transfer
            FormFGTrfNew.Close()
            FormFGTrfNew.Dispose()
        ElseIf formName = "FormFGTrfReceive" Then
            'FG Transfer
            FormFGTrfReceive.Close()
            FormFGTrfReceive.Dispose()
        ElseIf formName = "FormFGTracking" Then
            'FG TRACKING
            FormFGTracking.Close()
            FormFGTracking.Dispose()
        ElseIf formName = "FormFGStock" Then
            'FG STOCK
            FormFGStock.Close()
            FormFGStock.Dispose()
        ElseIf formName = "FormMatStock" Then
            'Mat STOCK
            FormMatStock.Close()
            FormMatStock.Dispose()
        ElseIf formName = "FormAccountingSummary" Then
            'Summary Accounting
            FormAccountingSummary.Close()
            FormAccountingSummary.Dispose()
        ElseIf formName = "FormAccountingFYear" Then
            'Financial Year Accounting
            FormAccountingFYear.Close()
            FormAccountingFYear.Dispose()
        ElseIf formName = "FormSampleStock" Then
            'Sample Stock
            FormSampleStock.Close()
            FormSampleStock.Dispose()
        ElseIf formName = "FormMasterEmployee" Then
            'Master Employee
            FormMasterEmployee.Close()
            FormMasterEmployee.Dispose()
        ElseIf formName = "FormSampleDel" Then
            'PL Sample Delivery
            FormSampleDel.Close()
            FormSampleDel.Dispose()
        ElseIf formName = "FormSampleDelRec" Then
            'REC PL Sample Delivery
            FormSampleDelRec.Close()
            FormSampleDelRec.Dispose()
        ElseIf formName = "FormSamplePrintBarcode" Then
            FormSamplePrintBarcode.Close()
            FormSamplePrintBarcode.Dispose()
        ElseIf formName = "FormSampleOrder" Then
            'SALES ORDER SAMPLE
            FormSampleOrder.Close()
            FormSampleOrder.Dispose()
        ElseIf formName = "FormSampleDelOrder" Then
            'DELIVERY ORDER SAMPLE
            FormSampleDelOrder.Close()
            FormSampleDelOrder.Dispose()
        ElseIf formName = "FormSampleStockOpname" Then
            'SAMPLE SO
            FormSampleStockOpname.Close()
            FormSampleStockOpname.Dispose()
        ElseIf formName = "FormAccountingListPR" Then
            'LIST PR ACCOUNTING
            FormAccountingListPR.Close()
            FormAccountingListPR.Dispose()
        ElseIf formName = "FormFGCodeReplace" Then
            'CODE REPLACEMENT
            FormFGCodeReplace.Close()
            FormFGCodeReplace.Dispose()
        ElseIf formName = "FormSalesWeekly" Then
            'CODE REPLACEMENT
            FormSalesWeekly.Close()
            FormSalesWeekly.Dispose()
        ElseIf formName = "FormSalesCreditNote" Then
            'CREDITN NOTE
            FormSalesCreditNote.Close()
            FormSalesCreditNote.Dispose()
        ElseIf formName = "FormFGMissingCreditNote" Then
            'MISSING CREDIT NOTE
            FormFGMissingCreditNote.Close()
            FormFGMissingCreditNote.Dispose()
        ElseIf formName = "FormSOH" Then
            'SOH
            FormSOH.Close()
            FormSOH.Dispose()
        ElseIf formName = "FormSOHPeriode" Then
            'SOH Periode
            FormSOHPeriode.Close()
            FormSOHPeriode.Dispose()
        ElseIf formName = "FormSOHSum" Then
            'SOH Periode
            FormSOHSum.Close()
            FormSOHSum.Dispose()
        ElseIf formName = "FormSOHPrice" Then
            'SOH Price
            FormSOHPrice.Close()
            FormSOHPrice.Dispose()
        ElseIf formName = "FormFGWoff" Then
            ' Write Off Finished Goods
            FormFGWoff.Close()
            FormFGWoff.Dispose()
        ElseIf formName = "FormFGWoffList" Then
            ' WRITE OFF LIST FG
            FormFGWoffList.Close()
            FormFGWoffList.Dispose()
        ElseIf formName = "FormFGProposePrice" Then
            'PROPOSE PRICE
            FormFGProposePrice.Close()
            FormFGProposePrice.Dispose()
        ElseIf formName = "FormFGLineList" Then
            'LINE LIST
            FormFGLineList.Close()
            FormFGLineList.Dispose()
        ElseIf formName = "FormFGDistSchemaSetup" Then
            'DIST SCHEMA SETUP
            FormFGDistSchemaSetup.Close()
            FormFGDistSchemaSetup.Dispose()
        ElseIf formName = "FormMasterRetCode" Then
            'MASTER RETURN CODE
            FormMasterRetCode.Close()
            FormMasterRetCode.Dispose()
        ElseIf formName = "FormMasterRateStore" Then
            'MASTER RATE STORE
            FormMasterRateStore.Close()
            FormMasterRateStore.Dispose()
        ElseIf formName = "FormFGProdList" Then
            FormFGProdList.Close()
            FormFGProdList.Dispose()
        ElseIf formName = "FormBarcodeProduct" Then
            FormBarcodeProduct.Close()
            FormBarcodeProduct.Dispose()
        ElseIf formName = "FormMasterDesignCOP" Then
            FormMasterDesignCOP.Close()
            FormMasterDesignCOP.Dispose()
        ElseIf formName = "" Then
            'SAMPLE ORDER
            FormSampleOrdered.Close()
            FormSampleOrdered.Dispose()
        ElseIf formName = "FormFGDistScheme" Then
            'DISTRIBUTION SCHEME
            FormFGDistScheme.Close()
            FormFGDistScheme.Dispose()
        ElseIf formName = "FormProdQCAdj" Then
            'QC Adj 
            FormProdQCAdj.Close()
            FormProdQCAdj.Dispose()
        ElseIf formName = "FormFGSalesOrderReff" Then
            'Analaisis SO New
            FormFGSalesOrderReff.Close()
            FormFGSalesOrderReff.Dispose()
        ElseIf formName = "FormSalesPromo" Then
            'Sales Promo
            FormSalesPromo.Close()
            FormSalesPromo.Dispose()
        ElseIf formName = "FormSalesOrderList" Then
            'Prepare order
            FormSalesOrderList.Close()
            FormSalesOrderList.Dispose()
        ElseIf formName = "FormGuide" Then
            'USER GUIDE
            FormGuide.Close()
            FormGuide.Dispose()
        ElseIf formName = "FormMasterComputer" Then
            'MASTER COMPUTER
            FormMasterComputer.Close()
            FormMasterComputer.Dispose()
        ElseIf formName = "FormNotification" Then
            'NOTIFICATION
            FormNotification.Close()
            FormNotification.Dispose()
        ElseIf formName = "FormAccountingFakturScan" Then
            'FAKTUR SCAN
            FormAccountingFakturScan.Close()
            FormAccountingFakturScan.Dispose()
        ElseIf formName = "FormFGBorrowQCReq" Then
            'BORROW REQ
            FormFGBorrowQCReq.Close()
            FormFGBorrowQCReq.Dispose()
        ElseIf formName = "FormWHAWBill" Then
            'AIRWAYS BILL
            FormWHAWBill.Close()
            FormWHAWBill.Dispose()
        ElseIf formName = "FormSalesOrderSvcLevel" Then
            'SERVICE LEVEL
            FormSalesOrderSvcLevel.Close()
            FormSalesOrderSvcLevel.Dispose()
        ElseIf formName = "FormMasterPrice" Then
            'MASTER PRICE FROM excel
            FormMasterPrice.Close()
            FormMasterPrice.Dispose()
        ElseIf formName = "FormMasterPriceSample" Then
            'MASTER PRICE SAMPLE FROM excel
            FormMasterPriceSample.Close()
            FormMasterPriceSample.Dispose()
        ElseIf formName = "FormWHImportDO" Then
            'Import DO
            FormWHImportDO.Close()
            FormWHImportDO.Dispose()
        ElseIf formName = "FormFGDesignList" Then
            'DESIGN LIST
            FormFGDesignList.Close()
            FormFGDesignList.Dispose()
        ElseIf formName = "FormWHSvcLevel" Then
            'SERVICE LEVEL
            FormWHSvcLevel.Close()
            FormWHSvcLevel.Dispose()
        ElseIf formName = "FormSamplePLToWH" Then
            'PL SAMPLE
            FormSamplePLToWH.Close()
            FormSamplePLToWH.Dispose()
        ElseIf formName = "FormSamplePLExport" Then
            FormSamplePLExport.Close()
            FormSamplePLExport.Dispose()
        ElseIf formName = "FormFGWHAlloc" Then
            FormFGWHAlloc.Close()
            FormFGWHAlloc.Dispose()
        ElseIf formName = "FormFGWHAllocLog" Then
            FormFGWHAllocLog.Close()
            FormFGWHAllocLog.Dispose()
        ElseIf formName = "FormSampleReturnPL" Then
            'RETURN INTERNAL SALE
            FormSampleReturnPL.Close()
            FormSampleReturnPL.Dispose()
        ElseIf formName = "FormWHCargoRate" Then
            'Cargo Rate
            FormWHCargoRate.Close()
            FormWHCargoRate.Dispose()
        ElseIf formName = "FormEmpFP" Then
            FormEmpFP.Close()
            FormEmpFP.Dispose()
        ElseIf formName = "FormEmpShift" Then
            'Employee Shift
            FormEmpShift.Close()
            FormEmpShift.Dispose()
        ElseIf formName = "FormEmpSchedule" Then
            'Employee Shift
            FormEmpSchedule.Close()
            FormEmpSchedule.Dispose()
        ElseIf formName = "FormEmpAttnInd" Then
            'Employee Attn Report Individual
            FormEmpAttnInd.Close()
            FormEmpAttnInd.Dispose()
        ElseIf formName = "FormEmpAttnSum" Then
            'Employee Attn Report Summary
            FormEmpAttnSum.Close()
            FormEmpAttnSum.Dispose()
        ElseIf formName = "FormEmpReview" Then
            FormEmpReview.Close()
            FormEmpReview.Dispose()
        ElseIf formName = "FormEmpInitialize" Then
            'Initialize Fingerprint
            FormEmpInitialize.Close()
            FormEmpInitialize.Dispose()
        ElseIf formName = "FormEmpHoliday" Then
            'Employee Holiday
            FormEmpHoliday.Close()
            FormEmpHoliday.Dispose()
        ElseIf formName = "FormFGRepair" Then
            FormFGRepair.Close()
            FormFGRepair.Dispose()
        ElseIf formName = "FormFGRepairRec" Then
            FormFGRepairRec.Close()
            FormFGRepairRec.Dispose()
        ElseIf formName = "FormFGRepairReturn" Then
            FormFGRepairReturn.Close()
            FormFGRepairReturn.Dispose()
        ElseIf formName = "FormFGRepairReturnRec" Then
            FormFGRepairReturnRec.Close()
            FormFGRepairReturnRec.Dispose()
        ElseIf formName = "FormEmpEmail" Then
            FormEmpEmail.Close()
            FormEmpEmail.Dispose()
        ElseIf formName = "FormEmpDP" Then
            FormEmpDP.Close()
            FormEmpDP.Dispose()
        ElseIf formName = "FormEmpLeave" Then
            FormEmpLeave.Close()
            FormEmpLeave.Dispose()
        ElseIf formName = "FormProductionSummary" Then
            FormProductionSummary.Close()
            FormProductionSummary.Dispose()
        ElseIf formName = "FormProductionFinalClear" Then
            FormProductionFinalClear.Close()
            FormProductionFinalClear.Dispose()
        ElseIf formName = "FormProductionAssembly" Then
            FormProductionAssembly.Close()
            FormProductionAssembly.Dispose()
        ElseIf formName = "FormSampleSummary" Then
            FormSampleSummary.Close()
            FormSampleSummary.Dispose()
        ElseIf formName = "FormWHDelEmpty" Then
            FormWHDelEmpty.Close()
            FormWHDelEmpty.Dispose()
        ElseIf formName = "FormWHDelEmptyStock" Then
            FormWHDelEmptyStock.Close()
            FormWHDelEmptyStock.Dispose()
        ElseIf formName = "FormEmpUniPeriod" Then
            FormEmpUniPeriod.Close()
        ElseIf formName = "FormFGTransList" Then
            FormFGTransList.Close()
            FormFGTransList.Dispose()
        ElseIf formName = "FormProdClosing" Then
            FormProdClosing.Close()
            FormProdClosing.Dispose()
        ElseIf formName = "FormOLStoreSummary" Then
            FormOLStoreSummary.Close()
            FormOLStoreSummary.Dispose()
        ElseIf formName = "FormFGAging" Then
            FormFGAging.Close()
            FormFGAging.Dispose()
        ElseIf formName = "FormFGTransSummary" Then
            FormFGTransSummary.Close()
            FormFGTransSummary.Dispose()
        ElseIf formName = "FormEmpPayroll" Then
            FormEmpPayroll.Close()
            FormEmpPayroll.Dispose()
        ElseIf formName = "FormFGFirstDel" Then
            FormFGFirstDel.Close()
            FormFGFirstDel.Dispose()
        ElseIf formName = "FormFGCompareStockCard" Then
            FormFGCompareStockCard.Close()
            FormFGCompareStockCard.Dispose()
        ElseIf formName = "FormEmpPayroll" Then
            FormEmpPayroll.Close()
            FormEmpPayroll.Dispose()
        ElseIf formName = "FormEmpLeaveCut" Then
            FormEmpLeaveCut.Close()
            FormEmpLeaveCut.Dispose()
        ElseIf formName = "FormProdOverMemo" Then
            FormProdOverMemo.Close()
            FormProdOverMemo.Dispose()
        ElseIf formName = "FormEmpUniList" Then
            FormEmpUniList.Close()
            FormEmpUniList.Dispose()
        ElseIf formName = "FormMasterAssetCategory" Then
            FormMasterAssetCategory.Close()
            FormMasterAssetCategory.Dispose()
        ElseIf formName = "FormMasterAsset" Then
            FormMasterAsset.Close()
            FormMasterAsset.Dispose()
        ElseIf formName = "FormAssetPO" Then
            FormAssetPO.Close()
            FormAssetPO.Dispose()
        ElseIf formName = "FormAssetRec" Then
            FormAssetRec.Close()
            FormAssetRec.Dispose()
        ElseIf formName = "FormEmpUniReport" Then
            FormEmpUniReport.Close()
            FormEmpUniReport.Dispose()
        ElseIf formName = "FormMasterProductForBOF" Then
            FormMasterProductForBOF.Close()
            FormMasterProductForBOF.Dispose()
        ElseIf formName = "FormEmpUniExpense" Then
            FormEmpUniExpense.Close()
            FormEmpUniExpense.Dispose()
        ElseIf formName = "FormBudgetRevPropose" Then
            FormBudgetRevPropose.Close()
            FormBudgetRevPropose.Dispose()
        ElseIf formName = "FormItemCatPropose" Then
            FormItemCatPropose.Close()
            FormItemCatPropose.Dispose()
        ElseIf formName = "FormItemCatMapping" Then
            FormItemCatMapping.Close()
            FormItemCatMapping.Dispose()
        ElseIf formName = "FormBudgetExpensePropose" Then
            FormBudgetExpensePropose.Close()
            FormBudgetExpensePropose.Dispose()
        ElseIf formName = "FormBudgetExpenseView" Then
            FormBudgetExpenseView.Close()
            FormBudgetExpenseView.Dispose()
        ElseIf formName = "FormBudgetExpenseRevision" Then
            FormBudgetExpenseRevision.Close()
            FormBudgetExpenseRevision.Dispose()
        ElseIf formName = "FormPurcReq" Then
            FormPurcReq.Close()
            FormPurcReq.Dispose()
        ElseIf formName = "FormPurcOrder" Then
            FormPurcOrder.Close()
            FormPurcOrder.Dispose()
        ElseIf formName = "FormProdDemandRev" Then
            FormProdDemandRev.Close()
            FormProdDemandRev.Dispose()
        ElseIf formName = "FormReportMarkCancelList" Then
            FormReportMarkCancelList.Close()
            FormReportMarkCancelList.Dispose()
        ElseIf formName = "FormPurcReceive" Then
            FormPurcReceive.Close()
            FormPurcReceive.Dispose()
        ElseIf formName = "FormPurcItemStock" Then
            FormPurcItemStock.Close()
            FormPurcItemStock.Dispose()
        ElseIf formName = "FormEmpUniSumReport" Then
            FormEmpUniSumReport.Close()
            FormEmpUniSumReport.Dispose()
        ElseIf formName = "FormProductionClaimReturn" Then
            FormProductionClaimReturn.Close()
            FormProductionClaimReturn.Dispose()
        ElseIf formName = "FormPurcReturn" Then
            FormPurcReturn.Close()
            FormPurcReturn.Dispose()
        ElseIf formName = "FormItemReq" Then
            FormItemReq.Close()
            FormItemReq.Dispose()
        ElseIf formName = "FormItemDel" Then
            FormItemDel.Close()
            FormItemDel.Dispose()
        ElseIf formName = "FormPurcPayment" Then
            FormPurcPayment.Close()
            FormPurcPayment.Dispose()
        ElseIf formName = "FormBankWithdrawal" Then
            FormBankWithdrawal.Close()
            FormBankWithdrawal.Dispose()
        ElseIf formName = "FormBankDeposit" Then
            FormBankDeposit.Close()
            FormBankDeposit.Dispose()
        ElseIf formName = "FormPurcAsset" Then
            FormPurcAsset.Close()
            FormPurcAsset.Dispose()
        ElseIf formName = "FormItemExpense" Then
            FormItemExpense.Close()
            FormItemExpense.Dispose()
        ElseIf formName = "FormCashAdvance" Then
            FormCashAdvance.Close()
            FormCashAdvance.Dispose()
        ElseIf formName = "FormSalesReturnRec" Then
            FormSalesReturnRec.Close()
            FormSalesReturnRec.Dispose()
        ElseIf formName = "FormOpt" Then
            FormOpt.Close()
            FormOpt.Dispose()
        ElseIf formName = "FormEmpPerAppraisal" Then
            FormEmpPerAppraisal.Close()
            FormEmpPerAppraisal.Dispose()
        ElseIf formName = "FormDeptHeadSurvey" Then
            FormDeptHeadSurvey.Close()
            FormDeptHeadSurvey.Dispose()
        ElseIf formName = "FormSetKurs" Then
            'Kurs Transaksi
            FormSetKurs.Close()
            FormSetKurs.Dispose()
        ElseIf formName = "FormVerifyMaster" Then
            'verify master
            FormVerifyMaster.Close()
            FormVerifyMaster.Dispose()
        ElseIf formName = "FormSampleExpense" Then
            'Sample Purchase Material
            FormSampleExpense.Close()
            FormSampleExpense.Dispose()
        ElseIf formName = "FormOLStore" Then
            FormOLStore.Close()
            FormOLStore.Dispose()
        ElseIf formName = "FormEmloyeePps" Then
            FormEmloyeePps.Close()
            FormEmloyeePps.Dispose()
        ElseIf formName = "FormSamplePurcClose" Then
            FormSamplePurcClose.Close()
            FormSamplePurcClose.Dispose()
        ElseIf formName = "FormEmpOvertime" Then
            FormEmpOvertime.Close()
            FormEmpOvertime.Dispose()
        ElseIf formName = "FormInvoiceFGPO" Then
            FormInvoiceFGPO.Close()
            FormInvoiceFGPO.Dispose()
        ElseIf formName = "FormFGLinePlan" Then
            FormFGLinePlan.Close()
            FormFGLinePlan.Dispose()
        ElseIf formName = "FormWorkOrder" Then
            FormWorkOrder.Close()
            FormWorkOrder.Dispose()
        ElseIf formName = "FormSalesTargetPropose" Then
            FormSalesTargetPropose.Close()
            FormSalesTargetPropose.Dispose()
        ElseIf formName = "FormReportEstWHInQty" Then
            FormReportEstWHInQty.Close()
            FormReportEstWHInQty.Dispose()
        ElseIf formName = "FormProductionHO" Then
            FormProductionHO.Close()
            FormProductionHO.Dispose()
        ElseIf formName = "FormSalesOrderReport" Then
            FormSalesOrderReport.Close()
            FormSalesOrderReport.Dispose()
        ElseIf formName = "FormProposeEmpSalary" Then
            FormProposeEmpSalary.Close()
            FormProposeEmpSalary.Dispose()
        ElseIf formName = "FormItemSubCat" Then
            FormItemSubCat.Close()
            FormItemSubCat.Dispose()
        ElseIf formName = "FormItemCatMain" Then
            FormItemCatMain.Close()
            FormItemCatMain.Dispose()
        ElseIf formName = "FormSalesRecord" Then
            FormSalesRecord.Close()
            FormSalesRecord.Dispose()
        ElseIf formName = "FormSetupBudgetOPEX" Then
            FormSetupBudgetOPEX.Close()
            FormSetupBudgetOPEX.Dispose()
        ElseIf formName = "FormSetupBudgetCAPEX" Then
            FormSetupBudgetCAPEX.Close()
            FormSetupBudgetCAPEX.Dispose()
        ElseIf formName = "FormARAging" Then
            FormARAging.Close()
            FormARAging.Dispose()
        ElseIf formName = "FormReportBudget" Then
            FormReportBudget.Close()
            FormReportBudget.Dispose()
        ElseIf formName = "FormEmpLeaveStock" Then
            FormEmpLeaveStock.Close()
            FormEmpLeaveStock.Dispose()
        ElseIf formName = "FormVoucherPOS" Then
            'Voucher POS
            FormVoucherPOS.Close()
            FormVoucherPOS.Dispose()
        ElseIf formName = "FormPromoRules" Then
            FormPromoRules.Close()
            FormPromoRules.Dispose()
        ElseIf formName = "FormEmpInputAttendance" Then
            'input attendance
            FormEmpInputAttendance.Close()
            FormEmpInputAttendance.Dispose()
        ElseIf formName = "FormPurcReqList" Then
            'Purchase Request IC
            FormPurcReqList.Close()
            FormPurcReqList.Dispose()
        ElseIf formName = "FormBuktiPickup" Then
            FormBuktiPickup.Close()
        ElseIf formName = "FormDebitNote" Then
            FormDebitNote.Close()
        ElseIf formName = "FormEmpAttnAssign" Then
            FormEmpAttnAssign.Close()
        ElseIf formName = "FormTrackingReturn" Then
            FormTrackingReturn.Close()
        ElseIf formName = "FormEmpBPJSKesehatan" Then
            FormEmpBPJSKesehatan.Close()
        ElseIf formName = "FormPopUpCompGroup" Then
            FormPopUpCompGroup.Close()
        ElseIf formName = "FormCompanyEmailMapping" Then
            FormCompanyEmailMapping.Close()
            FormCompanyEmailMapping.Dispose()
        ElseIf formName = "FormPurcItem" Then
            FormPurcItem.Close()
        ElseIf formName = "FormMailManage" Then
            FormMailManage.Close()
            FormMailManage.Dispose()
        ElseIf formName = "FormInvoiceTracking" Then
            FormInvoiceTracking.Close()
            FormInvoiceTracking.Dispose()
        ElseIf formName = "FormStockQC" Then
            FormStockQC.Close()
            FormStockQC.Dispose()
        ElseIf formName = "FormInvMat" Then
            FormInvMat.Close()
            FormInvMat.Dispose()
        ElseIf formName = "FormAREvalScheduke" Then
            FormAREvalScheduke.Close()
            FormAREvalScheduke.Dispose()
        ElseIf formName = "FormDelayPayment" Then
            FormDelayPayment.Close()
            FormDelayPayment.Dispose()
        ElseIf formName = "FormAccountingLedger" Then
            FormAccountingLedger.Close()
            FormAccountingLedger.Dispose()
        ElseIf formName = "FormAREvaluation" Then
            FormAREvaluation.Close()
            FormAREvaluation.Dispose()
        ElseIf formName = "FormDelManifest" Then
            FormDelManifest.Close()
            FormDelManifest.Dispose()
        ElseIf formName = "FormARCollectionAvg" Then
            FormARCollectionAvg.Close()
            FormARCollectionAvg.Dispose()
        ElseIf formName = "FormFollowUpAR" Then
            FormFollowUpAR.Close()
            FormFollowUpAR.Dispose()
        ElseIf formName = "FormAccountingWorksheet" Then
            FormAccountingWorksheet.Close()
            FormAccountingWorksheet.Dispose()
        ElseIf formName = "FormEmpUniCreditNote" Then
            FormEmpUniCreditNote.Close()
            FormEmpUniCreditNote.Dispose()
        ElseIf formName = "FormDocTracking" Then
            FormDocTracking.Close()
            FormDocTracking.Dispose()
        ElseIf formName = "FormPaymentMissing" Then
            FormPaymentMissing.Close()
            FormPaymentMissing.Dispose()
        ElseIf formName = "FormLineList" Then
            FormLineList.Close()
            FormLineList.Dispose()
        ElseIf formName = "FormBudgetProdDemand" Then
            FormBudgetProdDemand.Close()
            FormBudgetProdDemand.Dispose()
        ElseIf formName = "FormTabunganMissing" Then
            FormTabunganMissing.Close()
        ElseIf formName = "FormLetterOfStatement" Then
            FormLetterOfStatement.Close()
            FormLetterOfStatement.Dispose()
        ElseIf formName = "FormCompareStockWebsite" Then
            FormCompareStockWebsite.Close()
            FormCompareStockWebsite.Dispose()
        ElseIf formName = "FormItemTrf" Then
            FormItemTrf.Close()
            FormItemTrf.Dispose()
        ElseIf formName = "FormRetOlStore" Then
            FormRetOlStore.Close()
            FormRetOlStore.Dispose()
        ElseIf formName = "FormOlStoreReturnList" Then
            FormOlStoreReturnList.Close()
            FormOlStoreReturnList.Dispose()
        ElseIf formName = "FormOlStoreRetCust" Then
            FormOlStoreRetCust.Close()
            FormOlStoreRetCust.Dispose()
        ElseIf formName = "FormRefundOLStore" Then
            FormRefundOLStore.Close()
            FormRefundOLStore.Dispose()
        ElseIf formName = "FormPromoCollection" Then
            FormPromoCollection.Close()
            FormPromoCollection.Dispose()
        ElseIf formName = "FormExternalUser" Then
            FormExternalUser.Close()
            FormExternalUser.Dispose()
        ElseIf formName = "FormMasterStore" Then
            FormMasterStore.Close()
            FormMasterStore.Dispose()
        ElseIf formName = "FormMappingStore" Then
            FormMappingStore.Close()
            FormMappingStore.Dispose()
        ElseIf formName = "FormDesignColumn" Then
            FormDesignColumn.Close()
            FormDesignColumn.Dispose()
        ElseIf formName = "FormOutboundList" Then
            FormOutboundList.Close()
            FormOutboundList.Dispose()
        ElseIf formName = "FormReportFGPO" Then
            FormReportFGPO.Close()
            FormReportFGPO.Dispose()
        ElseIf formName = "FormODM" Then
            FormODM.Close()
            FormODM.Dispose()
        ElseIf formName = "FormPayoutReport" Then
            FormPayoutReport.Close()
            FormPayoutReport.Dispose()
        ElseIf formName = "FormSalesBranch" Then
            FormSalesBranch.Close()
            FormSalesBranch.Dispose()
        ElseIf formName = "FormVerificationMasterOL" Then
            FormVerificationMasterOL.Close()
            FormVerificationMasterOL.Dispose()
        ElseIf formName = "FormVerificationMasterPrice" Then
            FormVerificationMasterPrice.Close()
            FormVerificationMasterPrice.Dispose()
        ElseIf formName = "FormMasterDesignFabrication" Then
            FormMasterDesignFabrication.Close()
            FormMasterDesignFabrication.Dispose()
        ElseIf formName = "FormDesignColumnMapping" Then
            FormDesignColumnMapping.Close()
            FormDesignColumnMapping.Dispose()
        ElseIf formName = "FormMaterialRequisition" Then
            FormMaterialRequisition.Close()
            FormMaterialRequisition.Dispose()
        ElseIf formName = "FormABGRoyaltyZone" Then
            FormABGRoyaltyZone.Close()
            FormABGRoyaltyZone.Dispose()
        ElseIf formName = "FormMailManageReturn" Then
            FormMailManageReturn.Close()
            FormMailManageReturn.Dispose()
        ElseIf formName = "FormAdditionalCost" Then
            FormAdditionalCost.Close()
            FormAdditionalCost.Dispose()
        ElseIf formName = "FormDesignImages" Then
            FormDesignImages.Close()
            FormDesignImages.Dispose()
        ElseIf formName = "FormEmployeeContract" Then
            FormEmployeeContract.Close()
            FormEmployeeContract.Dispose()
        ElseIf formName = "FormSalesReturnOrderMail" Then
            FormSalesReturnOrderMail.Close()
            FormSalesReturnOrderMail.Dispose()
        ElseIf formName = "FormInbound3PL" Then
            FormInbound3PL.Close()
            FormInbound3PL.Dispose()
        ElseIf formName = "FormReturnNote" Then
            FormReturnNote.Close()
            FormReturnNote.Dispose()
        ElseIf formName = "FormListStore" Then
            FormListStore.Close()
            FormListStore.Dispose()
        ElseIf formName = "FormScanReturn" Then
            FormScanReturn.Close()
            FormScanReturn.Dispose()
        ElseIf formName = "FormBatchUploadOnlineStore" Then
            FormBatchUploadOnlineStore.Close()
            FormBatchUploadOnlineStore.Dispose()
        ElseIf formName = "FormAdjustmentOG" Then
            FormAdjustmentOG.Close()
            FormAdjustmentOG.Dispose()
        ElseIf formName = "FormOLReturnRefuse" Then
            FormOLReturnRefuse.Close()
            FormOLReturnRefuse.Dispose()
        ElseIf formName = "FormPricePolicyCode" Then
            FormPricePolicyCode.Close()
            FormPricePolicyCode.Dispose()
        ElseIf formName = "FormDeliveryMonitoring" Then
            FormDeliveryMonitoring.Close()
            FormDeliveryMonitoring.Dispose()
        ElseIf formName = "FormPriceChecker" Then
            FormPriceChecker.Close()
            FormPriceChecker.Dispose()
        ElseIf formName = "FormProposePriceMKD" Then
            FormProposePriceMKD.Close()
            FormProposePriceMKD.Dispose()
        ElseIf formName = "FormOutboundPOD" Then
            FormOutboundPOD.Close()
            FormOutboundPOD.Dispose()
        ElseIf formName = "FormMonthlySalesPerformance" Then
            FormMonthlySalesPerformance.Close()
            FormMonthlySalesPerformance.Dispose()
        ElseIf formName = "FormCatalogSpec" Then
            FormCatalogSpec.Close()
            FormCatalogSpec.Dispose()
        ElseIf formName = "FormStockTakeStorePeriod" Then
            FormStockTakeStorePeriod.Close()
            FormStockTakeStorePeriod.Dispose()
        ElseIf formName = "FormCompGroupEmail" Then
            FormCompGroupEmail.Close()
            FormCompGroupEmail.Dispose()
        ElseIf formName = "FormOGTransfer" Then
            FormOGTransfer.Close()
            FormOGTransfer.Dispose()
        ElseIf formName = "FormAWBOther" Then
            FormAWBOther.Close()
            FormAWBOther.Dispose()
        ElseIf formName = "FormSNIppsBudget" Then
            FormSNIppsBudget.Close()
            FormSNIppsBudget.Dispose()
        ElseIf formName = "FormSNISerahTerima" Then
            FormSNISerahTerima.Close()
            FormSNISerahTerima.Dispose()
        ElseIf formName = "FormStockTakePartial" Then
            FormStockTakePartial.Close()
            FormStockTakePartial.Dispose()
        ElseIf formName = "FormSNIRealisasi" Then
            FormSNIRealisasi.Close()
            FormSNIRealisasi.Dispose()
        ElseIf formName = "FormSNIQC" Then
            FormSNIQC.Close()
            FormSNIQC.Dispose()
        ElseIf formName = "FormSNIWH" Then
            FormSNIWH.Close()
            FormSNIWH.Dispose()
        ElseIf formName = "FormPreCalFGPO" Then
            FormPreCalFGPO.Close()
            FormPreCalFGPO.Dispose()
        ElseIf formName = "FormStoreStatus" Then
            FormStoreStatus.Close()
            FormStoreStatus.Dispose()
        ElseIf formName = "FormPriceMKDVios" Then
            FormPriceMKDVios.Close()
            FormPriceMKDVios.Dispose()
        ElseIf formname = "FormCapsule" Then
            FormCapsule.Close()
            FormCapsule.Dispose()
        ElseIf formName = "FormStockTakePropose" Then
            FormStockTakePropose.Close()
            FormStockTakePropose.Dispose()
        ElseIf formName = "FormPrepaidExpense" Then
            FormPrepaidExpense.Close()
            FormPrepaidExpense.Dispose()
        ElseIf formname = "FormPromoZalora" Then
            FormPromoZalora.Close()
            FormPromoZalora.Dispose()
        ElseIf formname = "FormProposePromo" Then
            FormProposePromo.Close()
            FormProposePromo.Dispose()
        ElseIf formname = "FormNominatifPromo" Then
            FormNominatifPromo.Close()
            FormNominatifPromo.Dispose()
        ElseIf formName = "FormRetExos" Then
            FormRetExos.Close()
            FormRetExos.Dispose()
        ElseIf formName = "FormDisableExos" Then
            FormDisableExos.Close()
            FormDisableExos.Dispose()
        ElseIf formName = "FormEOSChange" Then
            FormEOSChange.Close()
            FormEOSChange.Dispose()
        ElseIf formName = "FormEts" Then
            FormEts.Close()
            FormEts.Dispose()
        ElseIf formName = "FormMKDEvent" Then
            FormMKDEvent.Close()
            FormMKDEvent.Dispose()
        ElseIf formName = "FormBSP" Then
            FormBSP.Close()
            FormBSP.Dispose()
        ElseIf formName = "FormDeviden" Then
            FormDeviden.Close()
            FormDeviden.Dispose()
        Else
            RPSubMenu.Visible = False
        End If
    End Sub
    'Duplicate Data
    Private Sub BBDuplicate_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBDuplicate.ItemClick
        If formName = "FormMasterProduct" Then
            If FormMasterProduct.XTCProduct.SelectedTabPageIndex = 0 Then
                'design
                FormMasterDesignSingle.dupe = "1"
                FormMasterDesignSingle.id_design = FormMasterProduct.GVDesign.GetFocusedRowCellDisplayText("id_design").ToString
                FormMasterDesignSingle.ShowDialog()
            ElseIf FormMasterProduct.XTCProduct.SelectedTabPageIndex = 1 Then
                'product
                FormMasterProductDet.id_product = FormMasterProduct.GVProduct.GetFocusedRowCellDisplayText("id_product").ToString
                FormMasterProductDet.id_design = FormMasterProduct.GVDesign.GetFocusedRowCellDisplayText("id_design").ToString
                FormMasterProductDet.dupe = "1"
                FormMasterProductDet.ShowDialog()
            End If
        ElseIf formName = "FormBOM" Then
            'call form dupe
            FormBOMDuplicate.ShowDialog()
        ElseIf formName = "FormAccess" Then
            'call form dupe
            Dim confirm As DialogResult = XtraMessageBox.Show("Duplicate menu only available for this process (only BarButtonItem type) : " + System.Environment.NewLine + "- BBNew" + System.Environment.NewLine + "- BBEdit" + System.Environment.NewLine + "- BBDelete" + System.Environment.NewLine + "- BBPrint" + System.Environment.NewLine + "- BBRefresh" + System.Environment.NewLine + "Are you sure to continue this process ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Try
                    Cursor = Cursors.WaitCursor

                    Dim id_form As String = FormAccess.GVForm.GetFocusedRowCellDisplayText("id_form").ToString
                    'BBNew
                    Dim query As String = "INSERT INTO tb_menu_form_control(id_form, description_form_control, id_form_control_type, is_view, form_control_name) "
                    query += "VALUES ('" + id_form + "', 'Insert', '1', '2', 'BBNew')"
                    execute_non_query(query, True, "", "", "", "")
                    'BBEdit
                    query = "INSERT INTO tb_menu_form_control(id_form, description_form_control, id_form_control_type, is_view, form_control_name) "
                    query += "VALUES ('" + id_form + "', 'Edit', '1', '2', 'BBEdit')"
                    execute_non_query(query, True, "", "", "", "")
                    'BBDelete
                    query = "INSERT INTO tb_menu_form_control(id_form, description_form_control, id_form_control_type, is_view, form_control_name) "
                    query += "VALUES ('" + id_form + "', 'Delete', '1', '2', 'BBDelete')"
                    execute_non_query(query, True, "", "", "", "")
                    'BBPrint
                    query = "INSERT INTO tb_menu_form_control(id_form, description_form_control, id_form_control_type, is_view, form_control_name) "
                    query += "VALUES ('" + id_form + "', 'Print', '1', '2', 'BBPrint')"
                    execute_non_query(query, True, "", "", "", "")
                    FormAccess.viewFormControl()
                    'BBRefresh
                    'query = "INSERT INTO tb_menu_form_control(id_form, description_form_control, id_form_control_type, is_view, form_control_name) "
                    'query += "VALUES ('" + id_form + "', 'Refresh', '1', '2', 'BBRefresh')"
                    'execute_non_query(query, True, "", "", "", "")
                    'FormAccess.viewFormControl()

                    Cursor = Cursors.Default
                Catch ex As Exception
                    Cursor = Cursors.Default
                    errorConnection()
                End Try
            End If
        ElseIf formName = "FormMasterSample" Then
            '
            FormMasterSampleDet.dupe = "1"
            FormMasterSampleDet.id_sample = FormMasterSample.GVSample.GetFocusedRowCellDisplayText("id_sample").ToString
            FormMasterSampleDet.ShowDialog()
        ElseIf formName = "FormFGDesignList" Then
            'LINE LIST DESIGN
            If FormFGDesignList.XTPDesign.SelectedTabPageIndex = 0 Then
                FormMasterDesignSingle.id_pop_up = "5"
                FormMasterDesignSingle.WindowState = FormWindowState.Maximized
                FormMasterDesignSingle.form_name = "FormFGDesignList"
                FormMasterDesignSingle.dupe = "1"
                Dim id_dsg_param As String = "-1"
                Try
                    id_dsg_param = FormFGDesignList.GVDesign.GetFocusedRowCellValue("id_design").ToString
                Catch ex As Exception
                End Try
                FormMasterDesignSingle.id_design = id_dsg_param
                FormMasterDesignSingle.ShowDialog()
            Else

            End If
        ElseIf formName = "FormProposeEmpSalary" Then
            If FormProposeEmpSalary.GVList.RowCount > 0 Then
                FormProposeEmpSalaryDet.id_employee_sal_pps = FormProposeEmpSalary.GVList.GetFocusedRowCellValue("id_employee_sal_pps")
                FormProposeEmpSalaryDet.is_duplicate = "1"
                FormProposeEmpSalaryDet.ShowDialog()
            End If
        End If
    End Sub
    'Contact 
    Private Sub BBContact_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBContact.ItemClick
        Cursor = Cursors.WaitCursor
        Try
            FormMasterCompanyContact.id_company = FormMasterCompany.GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            FormMasterCompanyContact.ShowDialog()
        Catch ex As Exception

        End Try
        Cursor = Cursors.Default
    End Sub
    'Mapping User
    Private Sub BBMapping_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBMapping.ItemClick
        If formName = "FormAccess" Then
            Cursor = Cursors.WaitCursor
            Try
                'FormAccessMappingSingle.id_menu = FormAccess.GVMenu.GetFocusedRowCellDisplayText("id_menu").ToString
                'FormMasterUserMappingSingle.LabelDescriptionContent.Text = FormAccess.GVMenu.GetFocusedRowCellDisplayText("description_menu_name").ToString
                'FormMasterUserMappingSingle.LabelMenuName.Text = FormAccess.GVMenu.GetFocusedRowCellDisplayText("menu_name").ToString
                FormAccessMappingSingle.ShowDialog()
            Catch ex As Exception
                errorProcess()
                Close()
            End Try
            Cursor = Cursors.Default
        ElseIf formName = "FormMarkAssign" Then
            Cursor = Cursors.WaitCursor
            Try
                FormMarkAssignUser.id_mark_asg = FormMarkAssign.GVMarkAssign.GetFocusedRowCellDisplayText("id_mark_asg").ToString
                FormMarkAssignUser.ShowDialog()
            Catch ex As Exception
                errorProcess()
                Close()
            End Try
            Cursor = Cursors.Default
        End If
    End Sub
    'Refresh
    Private Sub BBRefresh_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBRefresh.ItemClick
        If formName = "FormSamplePlan" Then
            FormSamplePlan.view_sample_plan()
        ElseIf formName = "FormMasterProduct" Then
            FormMasterProduct.view_design()
        ElseIf formName = "FormSamplePurchase" Then
            If FormSamplePurchase.XTCTabReceive.SelectedTabPageIndex = 0 Then
                FormSamplePurchase.view_sample_purc()
            ElseIf FormSamplePurchase.XTCTabReceive.SelectedTabPageIndex = 1 Then
                FormSamplePurchase.view_sample_plan()
            End If
        ElseIf formName = "FormSampleReceive" Then
            If FormSampleReceive.XTCTabReceive.SelectedTabPageIndex = 0 Then
                FormSampleReceive.view_sample_rec()
            ElseIf FormSampleReceive.XTCTabReceive.SelectedTabPageIndex = 1 Then
                FormSampleReceive.view_sample_purc()
            End If
        ElseIf formName = "FormSamplePR" Then
            If FormSamplePR.XTCTabPR.SelectedTabPageIndex = 0 Then
                FormSamplePR.view_sample_pr()
            ElseIf FormSamplePR.XTCTabPR.SelectedTabPageIndex = 1 Then
                FormSamplePR.view_sample_purc()
            ElseIf FormSamplePR.XTCTabPR.SelectedTabPageIndex = 2 Then
                FormSamplePR.view_sample_rec()
            End If
        ElseIf formName = "FormMasterSample" Then
            FormMasterSample.view_sample()
        ElseIf formName = "FormMasterWH" Then
            'WAREHOUSE & LOCATOR
            If FormMasterWH.XTCWH.SelectedTabPageIndex = 0 Then
                FormMasterWH.viewWH()
            ElseIf FormMasterWH.XTCWH.SelectedTabPageIndex = 1 Then
                FormMasterWH.viewWHLocator()
            ElseIf FormMasterWH.XTCWH.SelectedTabPageIndex = 1 Then
                FormMasterWH.viewRack()
            ElseIf FormMasterWH.XTCWH.SelectedTabPageIndex = 3 Then
                FormMasterWH.viewDrawer()
            End If
        ElseIf formName = "FormSampleRet" Then
            'RETURN SAMPLE
            If FormSampleRet.XTCReturn.SelectedTabPageIndex = 0 Then 'returnIn
                FormSampleRet.viewRetOut()
            ElseIf FormSampleRet.XTCReturn.SelectedTabPageIndex = 1 Then 'Return Out
                FormSampleRet.viewRetIn()
            End If
        ElseIf formName = "FormSamplePLDel" Then
            'PL SAMPLE DEL
            If FormSamplePLDel.XTCPL.SelectedTabPageIndex = 0 Then
                FormSamplePLDel.viewPL()
            ElseIf FormSamplePLDel.XTCPL.SelectedTabPageIndex = 1 Then
                FormSamplePLDel.viewSampleReq()
            End If
        ElseIf formName = "FormSamplePL" Then
            'PL SAMPLE
            FormSamplePL.viewPL()
        ElseIf formName = "FormSampleReq" Then
            'SAMPLE REQ
            FormSampleReq.viewSampleReq()
        ElseIf formName = "FormMatPurchase" Then
            'Material Purchase
            If FormMatPurchase.XTCPurcMat.SelectedTabPageIndex = 0 Then
                FormMatPurchase.view_mat_purc()
            ElseIf FormMatPurchase.XTCPurcMat.SelectedTabPageIndex = 1 Then
                If FormMatPurchase.XTCListPD.SelectedTabPageIndex = 0 Then
                    FormMatPurchase.load_list_mat_from_pd()
                ElseIf FormMatPurchase.XTCListPD.SelectedTabPageIndex = 1 Then
                    FormMatPurchase.view_report()
                End If
            End If
        ElseIf formName = "FormMatWO" Then
            'Material WO
            FormMatWO.view_mat_purc()
        ElseIf formName = "FormMatRecPurc" Then
            'Receive Material Purchase
            If FormMatRecPurc.XTCTabReceive.SelectedTabPageIndex = 0 Then 'based on Rec
                FormMatRecPurc.view_mat_rec_purc()
            Else 'based on PO
                FormMatRecPurc.view_mat_purc()
            End If
        ElseIf formName = "FormMatRecWO" Then
            'Receive Material WO
            If FormMatRecPurc.XTCTabReceive.SelectedTabPageIndex = 0 Then 'based on Rec
                FormMatRecWO.view_mat_rec_purc()
            Else 'based on Wo
                FormMatRecWO.view_mat_wo()
            End If
        ElseIf formName = "FormSampleReq" Then
            'SAMPLE REQ
            FormSampleReq.viewSampleReq()
        ElseIf formName = "FormSampleReturn" Then
            'RETURN SAMPLEFromDelivery
            If FormSampleReturn.XTCReturn.SelectedTabPageIndex = 0 Then 'List Return
                'MsgBox("Aw1")
                FormSampleReturn.viewSampleReturn()
            ElseIf FormSampleReturn.XTCReturn.SelectedTabPageIndex = 1 Then 'Not yet returned
                'MsgBox("Aw2")
                FormSampleReturn.viewPl()
            End If
        ElseIf formName = "FormMatRet" Then
            'Return Mat
            If FormMatRet.XTCReturnMat.SelectedTabPageIndex = 0 Then 'return purchasing
                If FormMatRet.XTCReturnPruchase.SelectedTabPageIndex = 0 Then 'return Out
                    FormMatRet.viewRetOut()
                ElseIf FormMatRet.XTCReturnPruchase.SelectedTabPageIndex = 1 Then 'return In
                    FormMatRet.viewRetIn()
                End If
            ElseIf FormMatRet.XTCReturnMat.SelectedTabPageIndex = 1 Then 'return production
                If FormMatRet.XTCReturnProd.SelectedTabPageIndex = 0 Then 'return In
                    FormMatRet.viewRetInProd()
                End If
            ElseIf FormMatRet.XTCReturnMat.SelectedTabPageIndex = 1 Then 'return other
                FormMatRet.viewRetInOther()
            End If
        ElseIf formName = "FormSampleAdjustment" Then
            'Sample Adjustment
            If FormSampleAdjustment.XTCAdj.SelectedTabPageIndex = 0 Then 'List Adj In
                'MsgBox("Aw1")
                FormSampleAdjustment.viewAdjInSample()
            ElseIf FormSampleAdjustment.XTCAdj.SelectedTabPageIndex = 1 Then 'List Adj Out
                'MsgBox("Aw2")
                FormSampleAdjustment.viewAdjOutSample()
            End If
        ElseIf formName = "FormMatAdj" Then
            'Material Adjustment
            If FormMatAdj.XTCAdj.SelectedTabPageIndex = 0 Then 'List Adj In
                FormMatAdj.viewAdjIn()
            ElseIf FormMatAdj.XTCAdj.SelectedTabPageIndex = 1 Then 'List Adj Out
                FormMatAdj.viewAdjOut()
            End If
        ElseIf formName = "FormMatPR" Then
            'PR Mat PO
            If FormMatPR.XTCTabPR.SelectedTabPageIndex = 0 Then 'List PR
                FormMatPR.view_mat_pr()
            ElseIf FormMatPR.XTCTabPR.SelectedTabPageIndex = 1 Then 'List PO
                FormMatPR.view_mat_purc()
            ElseIf FormMatPR.XTCTabPR.SelectedTabPageIndex = 2 Then 'List Rec
                FormMatPR.view_mat_rec()
            End If
        ElseIf formName = "FormMatPRWO" Then
            'PR Mat WO
            If FormMatPRWO.XTCTabPR.SelectedTabPageIndex = 0 Then 'List PR
                FormMatPRWO.view_mat_pr()
            ElseIf FormMatPRWO.XTCTabPR.SelectedTabPageIndex = 1 Then 'List PO
                FormMatPRWO.view_mat_wo()
            ElseIf FormMatPRWO.XTCTabPR.SelectedTabPageIndex = 2 Then 'List Rec
                FormMatPRWO.view_mat_rec()
            End If
        ElseIf formName = "FormProduction" Then
            If FormProduction.XTCTabProduction.SelectedTabPageIndex = 0 Then ' prod order
                FormProduction.view_production_order()
            ElseIf FormProduction.XTCTabProduction.SelectedTabPageIndex = 1 Then ' prod demand
                FormProduction.viewProdDemand()
            ElseIf FormProduction.XTCTabProduction.SelectedTabPageIndex = 2 Then ' prod WO
                FormProduction.view_wo()
            ElseIf FormProduction.XTCTabProduction.SelectedTabPageIndex = 3 Then ' prod MRS
                FormProduction.view_mrs()
            End If
        ElseIf formName = "FormMatPL" Then
            If FormMatPL.XTCPL.SelectedTabPageIndex = 0 Then
                If FormMatPL.XTCTabProduction.SelectedTabPageIndex = 0 Then
                    FormMatPL.viewPL()
                ElseIf FormMatPL.XTCTabProduction.SelectedTabPageIndex = 1 Then
                    FormMatPL.viewMRS()
                End If
            ElseIf FormMatPL.XTCPL.SelectedTabPageIndex = 1 Then
                If FormMatPL.XTCPLOther.SelectedTabPageIndex = 0 Then
                    FormMatPL.viewPLOther()
                ElseIf FormMatPL.XTCPLOther.SelectedTabPageIndex = 1 Then
                    FormMatPL.view_mrs_other()
                End If
            End If
        ElseIf formName = "FormMatMRS" Then
            'Material Requisition : Other
            If FormMatMRS.XTCMRS.SelectedTabPageIndex = 0 Then 'mat wo
                FormMatMRS.view_mrs_wo()
            ElseIf FormMatMRS.XTCMRS.SelectedTabPageIndex = 1 Then 'other
                FormMatMRS.view_mrs()
            End If
        ElseIf formName = "FormProductionRec" Then
            'Receive FG QC
            If FormProductionRec.XTCTabReceive.SelectedTabPageIndex = 0 Then 'based on Rec
                FormProductionRec.view_prod_order_rec()
            Else 'based on Prod Order
                FormProductionRec.view_prod_order()
            End If
        ElseIf formName = "FormProductionRet" Then
            'Return FG
            If FormProductionRet.XTCReturn.SelectedTabPageIndex = 0 Then 'return Out
                FormProductionRet.viewRetOut()
            ElseIf FormProductionRet.XTCReturn.SelectedTabPageIndex = 1 Then 'return In
                FormProductionRet.viewRetIn()
            End If
        ElseIf formName = "FormProductionPLToWH" Then
            'PL FG To WH
            If FormProductionPLToWH.XTCPL.SelectedTabPageIndex = 0 Then
                FormProductionPLToWH.viewPL()
            ElseIf FormProductionPLToWH.XTCPL.SelectedTabPageIndex = 1 Then
                '
            End If
        ElseIf formName = "FormMatInvoice" Then
            'Mat Invoice
            If FormMatInvoice.XTCTabGeneral.SelectedTabPageIndex = 0 Then 'inv
                If FormMatInvoice.XTCTabProduction.SelectedTabPageIndex = 0 Then 'based inv
                    FormMatInvoice.viewInv()
                Else 'PL
                    FormMatInvoice.viewPL()
                End If
            Else 'retur
                If FormMatInvoice.XTCRetur.SelectedTabPageIndex = 0 Then 'based retur
                    FormMatInvoice.view_retur()
                Else 'inv
                    FormMatInvoice.viewInv_retur()
                End If
            End If
        ElseIf formName = "FormAccounting" Then
            If FormAccounting.XTCGeneral.SelectedTabPageIndex = 0 Then 'master
                FormAccounting.view_acc()
            Else
                FormAccounting.CreateNodes(FormAccounting.TreeList1)
            End If
        ElseIf formName = "FormAccountingJournal" Then
            If FormAccountingJournal.XTCJurnal.SelectedTabPageIndex = 0 Then
                FormAccountingJournal.view_entry()
            Else
                FormAccountingJournal.view_det(Now.ToString("yyy-MM-dd"), Now.ToString("yyy-MM-dd"), "2")
            End If
        ElseIf formName = "FormAccountingJournalAdj" Then
            FormAccountingJournalAdj.view_jurnal()
        ElseIf formName = "FormProductionPLToWHRec" Then
            'REC PL FG To WH
            If FormProductionPLToWHRec.XTCPL.SelectedTabPageIndex = 0 Then
                FormProductionPLToWHRec.viewPL()
            ElseIf FormProductionPLToWHRec.XTCPL.SelectedTabPageIndex = 1 Then
                FormProductionPLToWHRec.view_sample_purc()
            End If
        ElseIf formName = "FormSalesTarget" Then
            'SALES TARGET
            If FormSalesTarget.XTCSalesTarget.SelectedTabPageIndex = 0 Then
                FormSalesTarget.viewSalesTarget()
            End If
        ElseIf formName = "FormSalesOrder" Then
            'SALES Order
            If FormSalesOrder.XTCSOGeneral.SelectedTabPageIndex = 0 Then
                FormSalesOrder.viewSalesOrder()
            ElseIf FormSalesOrder.XTCSOGeneral.SelectedTabPageIndex = 1 Then
                FormSalesOrder.viewSalesOrderGen()
            End If
        ElseIf formName = "FormSalesDelOrder" Then
            'Sales Del Order
            If FormSalesDelOrder.XTCDO.SelectedTabPageIndex = 0 Then
                FormSalesDelOrder.viewSalesDelOrder()
            ElseIf FormSalesDelOrder.XTCDO.SelectedTabPageIndex = 1 Then
                FormSalesDelOrder.viewSalesOrder()
            ElseIf FormSalesDelOrder.XTCDO.SelectedTabPageIndex = 2 Then
                FormSalesDelOrder.viewrRef()
            End If
        ElseIf formName = "FormSalesReturnOrder" Then
            'SALES RETURN Order
            FormSalesReturnOrder.viewSalesReturnOrder()
        ElseIf formName = "FormSalesReturnOrderOL" Then
            'SALES RETURN Order OL
            If FormSalesReturnOrderOL.XTCROR.SelectedTabPageIndex = 0 Then
                FormSalesReturnOrderOL.viewSalesReturnOrder()
            ElseIf FormSalesReturnOrderOL.XTCROR.SelectedTabPageIndex = 1 Then
                FormSalesReturnOrderOL.viewPending()
            End If
        ElseIf formName = "FormSalesReturn" Then
            'SALES RETURN
            If FormSalesReturn.XTCSalesReturn.SelectedTabPageIndex = 0 Then
                FormSalesReturn.viewSalesReturn()
            ElseIf FormSalesReturn.XTCSalesReturn.SelectedTabPageIndex = 1 Then
                FormSalesReturn.viewSalesReturnOrder()
            End If
        ElseIf formName = "FormSalesPOS" Then
            'SALES VRTUAL POS
            If FormSalesPOS.XTCInvoice.SelectedTabPageIndex = 0 Then
                FormSalesPOS.viewSalesPOS()
            ElseIf FormSalesPOS.XTCInvoice.SelectedTabPageIndex = 2 Then
                FormSalesPOS.viewPendingCNOLStore()
            End If
        ElseIf formName = "FormSalesReturnQC" Then
            'SALES RETURN QC
            If FormSalesReturnQC.XTCReturnQC.SelectedTabPageIndex = 0 Then
                FormSalesReturnQC.viewSalesReturnQC()
            Else
                FormSalesReturnQC.viewSalesReturn()
            End If
        ElseIf formName = "FormProdPRWO" Then
            'REC PL FG To WH
            If FormProdPRWO.XTCTabPR.SelectedTabPageIndex = 0 Then 'list
                FormProdPRWO.view_pr()
            ElseIf FormProdPRWO.XTCTabPR.SelectedTabPageIndex = 1 Then 'wo
                FormProdPRWO.view_wo()
            ElseIf FormProdPRWO.XTCTabPR.SelectedTabPageIndex = 1 Then 'list FGPO
                FormProdPRWO.view_pr_courier()
            ElseIf FormProdPRWO.XTCTabPR.SelectedTabPageIndex = 1 Then 'list no reff
                FormProdPRWO.view_pr_no_reff()
            End If
        ElseIf formName = "FormSalesInvoice" Then
            'SALES INVOCIE
            FormSalesInvoice.viewSalesInvoice()
        ElseIf formName = "FormFGStockOpnameStore" Then
            'STORE STOCK OPNAME
            FormFGStockOpnameStore.viewSoStore()
        ElseIf formName = "FormFGMissing" Then
            'FG MISSING
            If FormFGMissing.XTCFGMissing.SelectedTabPageIndex = 0 Then
                FormFGMissing.viewFGMissing()
            ElseIf FormFGMissing.XTCFGMissing.SelectedTabPageIndex = 1 Then
                FormFGMissing.viewFGMissingWH()
            End If
        ElseIf formName = "FormFGMissingInvoice" Then
            'FG MISSING INVOCIE
            FormFGMissingInvoice.viewFGMissingInvoice()
        ElseIf formName = "FormFGStockOpnameWH" Then
            'WH STOCK OPNAME
            FormFGStockOpnameWH.viewSOWH()
        ElseIf formName = "FormFGAdj" Then
            'FG Adjustment
            If FormFGAdj.XTCAdj.SelectedTabPageIndex = 0 Then 'List Adj In
                FormFGAdj.viewAdjIn()
            ElseIf FormFGAdj.XTCAdj.SelectedTabPageIndex = 1 Then 'List Adj Out
                FormFGAdj.viewAdjOut()
            End If
        ElseIf formName = "FormFGTrf" Then
            'FG Transfer Future
            FormFGTrf.viewFGTrf()
        ElseIf formName = "FormFGTrfNew" Then
            'FG Transfer Future
            If FormFGTrfNew.XTCTrf.SelectedTabPageIndex = 0 Then
                FormFGTrfNew.viewFGTrf()
            ElseIf FormFGTrfNew.XTCTrf.SelectedTabPageIndex = 1 Then
                FormFGTrfNew.viewSalesOrder()
            End If
        ElseIf formName = "FormFGTrfReceive" Then
            'FG Transfer Rec
            FormFGTrfReceive.viewFGTrf()
        ElseIf formName = "FormAccountingSummary" Then
            'summary accounting
            FormAccountingSummary.CreateNodes(FormAccountingSummary.TreeList1)
        ElseIf formName = "FormMasterEmployee" Then
            'employee
            FormMasterEmployee.viewEmployee("-1")
        ElseIf formName = "FormSampleDel" Then
            'PL SAMPLE DEL
            FormSampleDel.viewSampleDel()
        ElseIf formName = "FormSampleDelRec" Then
            'REC PL SAMPLE DEL
            If FormSampleDelRec.XTCSampleDelRec.SelectedTabPageIndex = 0 Then
                FormSampleDelRec.viewSampleDelRec()
            ElseIf FormSampleDelRec.XTCSampleDelRec.SelectedTabPageIndex = 1 Then
                FormSampleDelRec.viewSampleDel()
            End If
        ElseIf formName = "FormSampleBarcode" Then
            'BARCODE
            FormSamplePrintBarcode.view_sample()
        ElseIf formName = "FormSampleOrder" Then
            'SALES ORDER SAMPLE
            FormSampleOrder.viewSampleOrder()
        ElseIf formName = "FormSampleDelOrder" Then
            'DELIVERY ORDER SAMPLE FOR SALES
            If FormSampleDelOrder.XTCSampleDelOrder.SelectedTabPageIndex = 0 Then
                FormSampleDelOrder.viewSampleDelOrder()
            ElseIf FormSampleDelOrder.XTCSampleDelOrder.SelectedTabPageIndex = 1 Then
                FormSampleDelOrder.viewSampleOrder()
            End If
        ElseIf formName = "FormFGCodeReplace" Then
            'CODE REPLACEMENT
            If FormFGCodeReplace.XTCFGCodeReplace.SelectedTabPageIndex = 0 Then
                FormFGCodeReplace.viewCodeReplaceStore()
            ElseIf FormFGCodeReplace.XTCFGCodeReplace.SelectedTabPageIndex = 1 Then
                FormFGCodeReplace.viewCodeReplaceWH()
            End If
        ElseIf formName = "FormAccountingListPR" Then
            'List PR accounting
            FormAccountingListPR.view_list_pr()
        ElseIf formName = "FormSampleStockOpname" Then
            'List PR accounting
            FormSampleStockOpname.viewSOWH()
        ElseIf formName = "FormSalesCreditNote" Then
            'CREDIT NOTE
            FormSalesCreditNote.viewSalesPOS()
        ElseIf formName = "FormFGMissingCreditNote" Then
            'MISSING CREDIT NOTE
            FormFGMissingCreditNote.viewFGMissingStoreCN()
        ElseIf formName = "FormSOH" Then
            'SOH
            FormSOH.view_soh_periode(FormSOH.LESOHPeriode.EditValue)
        ElseIf formName = "FormSOHPeriode" Then
            'SOH Periode
            FormSOHPeriode.view_soh()
        ElseIf formName = "FormSOHPrice" Then
            'SOH Periode
            FormSOHPrice.view_soh()
        ElseIf formName = "FormFGWoff" Then
            'WRITEOFF
            FormFGWoff.viewFGWoff()
        ElseIf formName = "FormFGProposePrice" Then
            'FG Propose
            If FormFGProposePrice.XTCPropose.SelectedTabPageIndex = 0 Then
                FormFGProposePrice.viewPropose()
            ElseIf FormFGProposePrice.XTCPropose.SelectedTabPageIndex = 1 Then
                FormFGProposePrice.viewRevision()
            ElseIf FormFGProposePrice.XTCPropose.SelectedTabPageIndex = 2 Then
                FormFGProposePrice.viewCompare()
            End If
        ElseIf formName = "FormMasterRetCode" Then
            'MASTER RET CODE
            FormMasterRetCode.viewRetCode()
        ElseIf formName = "FormMasterRateStore" Then
            'MASTER RATE STORE
            FormMasterRateStore.viewRate()
        ElseIf formName = "FormMasterDesignCOP" Then
            'MASTER DESIGN COP
            FormMasterDesignCOP.view_design()
        ElseIf formName = "FormSampleOrdered" Then
            'SAMPLE ORDERED
            FormSampleOrdered.viewSampleOrder()
        ElseIf formName = "FormProdQCAdj" Then
            If FormProdQCAdj.XTCAdj.SelectedTabPageIndex = 0 Then 'QC adj IN
                FormProdQCAdj.viewAdjIn()
            Else 'QC adj OUT
                FormProdQCAdj.viewAdjOut()
            End If
        ElseIf formName = "FormFGSalesOrderReff" Then
            'SALES ORDER REFF
            FormFGSalesOrderReff.viewSOReff()
        ElseIf formName = "FormSalesPromo" Then
            'SALES PROMO
            FormSalesPromo.viewSalesPOS()
        ElseIf formName = "FormSalesOrderList" Then
            'PREPARE ORDER LIST
            Cursor = Cursors.WaitCursor
            If FormSalesOrderList.XTCWHMonitor.SelectedTabPageIndex = 0 Then 'list
                FormSalesOrderList.viewSalesOrder()
            ElseIf FormSalesOrderList.XTCWHMonitor.SelectedTabPageIndex = 1 Then 'ref
                FormSalesOrderList.viewNewPrepare(FormSalesOrderList.TxtNoParam.Text)
            End If
            Cursor = Cursors.Default
        ElseIf formName = "FormSalesOrderSvcLevel" Then
            'SERVICE LEVEL
            If FormSalesOrderSvcLevel.XTCSvcLevel.SelectedTabPageIndex = 0 Then
                'PREPARE ORDER
                FormSalesOrderSvcLevel.viewSalesOrder()
            ElseIf FormSalesOrderSvcLevel.XTCSvcLevel.SelectedTabPageIndex = 1 Then
                'RETURN ORDER
                FormSalesOrderSvcLevel.viewReturnOrder()
            ElseIf FormSalesOrderSvcLevel.XTCSvcLevel.SelectedTabPageIndex = 2 Then
                'RECEIVED
                FormSalesOrderSvcLevel.viewRecProduct()
            ElseIf FormSalesOrderSvcLevel.XTCSvcLevel.SelectedTabPageIndex = 3 Then
                'DO
                FormSalesOrderSvcLevel.viewDO()
            ElseIf FormSalesOrderSvcLevel.XTCSvcLevel.SelectedTabPageIndex = 4 Then
                'RETURN
                FormSalesOrderSvcLevel.viewReturn()
            ElseIf FormSalesOrderSvcLevel.XTCSvcLevel.SelectedTabPageIndex = 5 Then
                'RETURN QC
                FormSalesOrderSvcLevel.viewReturnQC()
            ElseIf FormSalesOrderSvcLevel.XTCSvcLevel.SelectedTabPageIndex = 6 Then
                'TRF
                FormSalesOrderSvcLevel.viewTrf()
            ElseIf FormSalesOrderSvcLevel.XTCSvcLevel.SelectedTabPageIndex = 8 Then
                'Tracking Return
                FormTrackingReturn.load_form()
            End If
        ElseIf formName = "FormMasterComputer" Then
            'MASTER COMPUTER
            Cursor = Cursors.WaitCursor
            FormMasterComputer.viewComputer()
            Cursor = Cursors.Default
        ElseIf formName = "FormNotification" Then
            'NOTIFICATION
            FormNotification.viewNotif()
        ElseIf formName = "FormAccountingFakturScan" Then
            'FAKTURSCAN
            FormAccountingFakturScan.viewTrans()
        ElseIf formName = "FormFGBorrowQCReq" Then
            'BORRWOW REQ FOR QC FG
            FormFGBorrowQCReq.viewBorrowReq()
        ElseIf formName = "FormWHAWBill" Then
            'FormWHAWBill
            If FormWHAWBill.XTCAwb.SelectedTabPageIndex = 0 Then
                FormWHAWBill.load_outbound()
            Else
                FormWHAWBill.load_inbound()
            End If
        ElseIf formName = "FormMasterPrice" Then
            'MASTER PRICE
            FormMasterPrice.viewPrice()
        ElseIf formName = "FormMasterPriceSample" Then
            'MASTER PRICE SAMPLe
            FormMasterPriceSample.viewPrice()
        ElseIf formName = "FormWHImportDO" Then
            'IMPORT DO
            FormWHImportDO.viewDOList()
        ElseIf formName = "FormMasterRawMaterial" Then
            If FormMasterRawMaterial.XTCList.SelectedTabPageIndex = 0 Then
                If FormMasterRawMaterial.XTCMaterialType.SelectedTabPageIndex = 0 Then
                    FormMasterRawMaterial.viewMat()
                Else
                    FormMasterRawMaterial.viewMatDetail()
                End If
            ElseIf FormMasterRawMaterial.XTCList.SelectedTabPageIndex = 1 Then
                FormMasterRawMaterial.viewMatDetailList()
            End If
        ElseIf formName = "FormFGDesignList" Then
            If FormFGDesignList.XTPDesign.SelectedTabPageIndex = 0 Then
                FormFGDesignList.viewData()
            Else
                FormFGDesignList.viewPropose()
            End If
        ElseIf formName = "FormWHSvcLevel" Then
            If FormWHSvcLevel.XTCSvcLelel.SelectedTabPageIndex = 0 Then
                FormWHSvcLevel.viewSvcBySO()
            ElseIf FormWHSvcLevel.XTCSvcLelel.SelectedTabPageIndex = 1 Then
                FormWHSvcLevel.viewSvcByCode()
            ElseIf FormWHSvcLevel.XTCSvcLelel.SelectedTabPageIndex = 2 Then
                FormWHSvcLevel.viewSvcByAcc()
            ElseIf FormWHSvcLevel.XTCSvcLelel.SelectedTabPageIndex = 3 Then
                FormWHSvcLevel.viewSvcReturn()
            End If
        ElseIf formName = "FormFGWHAlloc" Then
            'INVENTORY ALLOCATION
            FormFGWHAlloc.viewFGWHAlloc()
        ElseIf formName = "FormSamplePLToWH" Then
            'PL SAMPLE
            FormSamplePLToWH.viewSamplePL()
        ElseIf formName = "FormSampleReturnPL" Then
            'Return From Internal Sale
            FormSampleReturnPL.viewSamplePL()
        ElseIf formName = "FormWHCargoRate" Then
            'Cargo Rate
            If FormWHCargoRate.XTCRate.SelectedTabPageIndex = 0 Then
                FormWHCargoRate.load_cargo_rate()
            Else
                FormWHCargoRate.load_cargo_rate_in()
            End If
        ElseIf formName = "FormEmpFP" Then
            FormEmpFP.viewFP()
        ElseIf formName = "FormEmpShift" Then
            'Shift employee
            FormEmpShift.load_schedule()
        ElseIf formName = "FormFGRepair" Then
            FormFGRepair.viewData()
        ElseIf formName = "FormFGRepairRec" Then
            If FormFGRepairRec.XTCRepairRec.SelectedTabPageIndex = 0 Then
                FormFGRepairRec.viewData()
            Else
                FormFGRepairRec.viewRepairList()
            End If
        ElseIf formName = "FormFGRepairReturn" Then
            If FormFGRepairReturn.XTCData.SelectedTabPageIndex = 0 Then
                FormFGRepairReturn.viewData()
            Else
                FormFGRepairReturn.viewRepairList()
            End If
        ElseIf formName = "FormEmpEmail" Then
            FormEmpEmail.viewEmployee("-1")
        ElseIf formName = "FormFGRepairReturnRec" Then
            If FormFGRepairReturnRec.XTCRepairRec.SelectedTabPageIndex = 0 Then
                FormFGRepairReturnRec.viewData()
            Else
                FormFGRepairReturnRec.viewRepairList()
            End If
        ElseIf formName = "FormEmpLeave" Then
            FormEmpLeave.load_sum()
        ElseIf formName = "FormEmpInitialize" Then
            FormEmpInitialize.viewEmployee()
        ElseIf formName = "FormEmpDP" Then
            FormEmpDP.load_dp()
        ElseIf formName = "FormProductionFinalClear" Then
            If FormProductionFinalClear.XTCQCReport.SelectedTabPageIndex = 0 Then
                FormProductionFinalClear.viewFinalClear()
            ElseIf FormProductionFinalClear.XTCQCReport.SelectedTabPageIndex = 1 Then
                FormProductionFinalClear.viewOrderList()
            ElseIf FormProductionFinalClear.XTCQCReport.SelectedTabPageIndex = 2 Then
                FormProductionFinalClear.viewSummaryPropose()
            End If
        ElseIf formName = "FormProductionAssembly" Then
            FormProductionAssembly.viewData()
        ElseIf formName = "FormWHDelEmpty" Then
            FormWHDelEmpty.viewDel()
        ElseIf formName = "FormEmpUniPeriod" Then
            FormEmpUniPeriod.viewUniformPeriod()
        ElseIf formName = "FormDepartementSub" Then
            FormDepartementSub.view_departement()
        ElseIf formName = "FormEmpPayroll" Then
            If FormEmpPayroll.XTCPayroll.SelectedTabPageIndex = 0 Then
                FormEmpPayroll.load_payroll()
            Else
                FormEmpPayroll.load_payroll_detail()
            End If
        ElseIf formName = "FormEmpLeaveCut" Then
            FormEmpLeaveCut.load_leave_cut()
        ElseIf formName = "FormProdOverMemo" Then
            FormProdOverMemo.viewData()
        ElseIf formName = "FormEmpUniList" Then
            FormEmpUniList.viewData()
        ElseIf formName = "FormMasterAsset" Then
            If FormMasterAsset.XTCListAsset.SelectedTabPageIndex = 0 Then
                FormMasterAsset.load_asset("2")
            ElseIf FormMasterAsset.XTCListAsset.SelectedTabPageIndex = 1 Then
                FormMasterAsset.load_moving_log()
            End If
        ElseIf formName = "FormAssetPO" Then
            FormAssetPO.load_po()
        ElseIf formName = "FormAssetRec" Then
            FormAssetRec.load_rec()
        ElseIf formName = "FormEmpUniExpense" Then
            FormEmpUniExpense.viewData()
        ElseIf formName = "FormBudgetRevPropose" Then
            If FormBudgetRevPropose.XTCRev.SelectedTabPageIndex = 1 Then
                FormBudgetRevPropose.viewData()
            ElseIf FormBudgetRevPropose.XTCRev.SelectedTabPageIndex = 2 Then
                FormBudgetRevPropose.viewRevision()
            End If
        ElseIf formName = "FormItemCatPropose" Then
            If FormItemCatPropose.XTCCat.SelectedTabPageIndex = 0 Then
                FormItemCatPropose.viewCat()
            ElseIf FormItemCatPropose.XTCCat.SelectedTabPageIndex = 1 Then
                FormItemCatPropose.viewPropose()
            End If
        ElseIf formName = "FormItemCatMapping" Then
            If FormItemCatMapping.XTCMapping.SelectedTabPageIndex = 0 Then
                FormItemCatMapping.viewMapping()
            ElseIf FormItemCatMapping.XTCMapping.SelectedTabPageIndex = 1 Then
                FormItemCatMapping.viewPropose()
            End If
        ElseIf formName = "FormBudgetExpensePropose" Then
            FormBudgetExpensePropose.viewData()
        ElseIf formName = "FormBudgetExpenseRevision" Then
            FormBudgetExpenseRevision.viewData()
        ElseIf formName = "FormProdDemandRev" Then
            FormProdDemandRev.viewData()
        ElseIf formName = "FormPurcReceive" Then
            If FormPurcReceive.XTCRec.SelectedTabPageIndex = 0 Then
                FormPurcReceive.viewOrder()
            ElseIf FormPurcReceive.XTCRec.SelectedTabPageIndex = 1 Then
                FormPurcReceive.viewReceive()
            ElseIf FormPurcReceive.XTCRec.SelectedTabPageIndex = 2 Then
                If FormPurcReceive.XTCFOC.SelectedTabPageIndex = 0 Then
                    FormPurcReceive.viewFOC()
                ElseIf FormPurcReceive.XTCFOC.SelectedTabPageIndex = 1 Then
                    FormPurcReceive.viewListFOC()
                End If
            End If
        ElseIf formName = "FormPurcReturn" Then
            If FormPurcReturn.XTCReturn.SelectedTabPageIndex = 0 Then
                FormPurcReturn.viewOrder()
            ElseIf FormPurcReturn.XTCReturn.SelectedTabPageIndex = 1 Then
                FormPurcReturn.viewReturn()
            End If
        ElseIf formName = "FormProductionClaimReturn" Then
            FormProductionClaimReturn.viewData()
        ElseIf formName = "FormItemReq" Then
            FormItemReq.viewData()
        ElseIf formName = "FormItemDel" Then
            If FormItemDel.XTCDel.SelectedTabPageIndex = 0 Then
                FormItemDel.viewRequest()
            ElseIf FormItemDel.XTCDel.SelectedTabPageIndex = 1 Then
                FormItemDel.viewDelivery()
            End If
        ElseIf formName = "FormBankWithdrawal" Then
            If FormBankWithdrawal.XTCPO.SelectedTabPageIndex = 0 Then
                If FormBankWithdrawal.XTCBBKList.SelectedTabPageIndex = 0 Then
                    FormBankWithdrawal.load_payment()
                Else
                    FormBankWithdrawal.view_sum()
                End If
            ElseIf FormBankWithdrawal.XTCPO.SelectedTabPageIndex = 1 Then
                FormBankWithdrawal.load_po()
            End If
        ElseIf formName = "FormBankDeposit" Then
            If FormBankDeposit.XTCPO.SelectedTabPageIndex = 0 Then
                FormBankDeposit.load_deposit()
            ElseIf FormBankDeposit.XTCPO.SelectedTabPageIndex = 1 Then
                FormBankDeposit.load_invoice()
            ElseIf FormBankDeposit.XTCPO.SelectedTabPageIndex = 2 Then
                FormBankDeposit.load_payout()
            ElseIf FormBankDeposit.XTCPO.SelectedTabPageIndex = 3 Then
                FormBankDeposit.load_vacc()
            End If
        ElseIf formName = "FormPurcAsset" Then
            If FormPurcAsset.XTCAsset.SelectedTabPageIndex = 0 Then
                FormPurcAsset.viewPending()
            ElseIf FormPurcAsset.XTCAsset.SelectedTabPageIndex = 1 Then
                FormPurcAsset.viewActive()
            End If
        ElseIf formName = "FormItemExpense" Then
            FormItemExpense.viewData()
        ElseIf formName = "FormSalesReturnRec" Then
            FormSalesReturnRec.load_list()
        ElseIf formName = "FormOpt" Then
            FormOpt.load_data()
        ElseIf formName = "FormEmpPerAppraisal" Then
            FormEmpPerAppraisal.load_employee()
        ElseIf formName = "FormDeptHeadSurvey" Then
            If FormDeptHeadSurvey.XTCSurvey.SelectedTabPage.Name = "XTPForm" Then
                FormDeptHeadSurvey.load_question()
            ElseIf FormDeptHeadSurvey.XTCSurvey.SelectedTabPage.Name = "XTPPeriod" Then
                FormDeptHeadSurvey.load_period()
            End If
        ElseIf formName = "FormSetKurs" Then
            FormSetKurs.load_kurs()
        ElseIf formName = "FormCashAdvance" Then
            FormCashAdvance.load_cash_advance()
        ElseIf formName = "FormSampleExpense" Then
            FormSampleExpense.load_purc("2")
        ElseIf formName = "FormOLStore" Then
            If FormOLStore.XtraTabControl1.SelectedTabPageIndex = 0 Then
                FormOLStore.viewSummary()
            ElseIf FormOLStore.XtraTabControl1.SelectedTabPageIndex = 1 Then
                FormOLStore.viewDetail()
            ElseIf FormOLStore.XtraTabControl1.SelectedTabPageIndex = 2 Then
                FormOLStore.viewDetailCancell()
            End If
        ElseIf formName = "FormEmloyeePps" Then
            FormEmloyeePps.load_pps()
        ElseIf formName = "FormSamplePurcClose" Then
            FormSamplePurcClose.load_close("1")
        ElseIf formName = "FormEmpOvertime" Then
            FormEmpOvertime.form_load()
            FormEmpOvertime.load_overtime("created_at")
        ElseIf formName = "FormInvoiceFGPO" Then
            FormInvoiceFGPO.load_list("0")
        ElseIf formName = "FormFGLinePlan" Then
            FormFGLinePlan.viewData()
        ElseIf formName = "FormWorkOrder" Then
            FormWorkOrder.load_wo()
        ElseIf formName = "FormSalesTargetPropose" Then
            If FormSalesTargetPropose.XTCPropose.SelectedTabPageIndex = 0 Then
                FormSalesTargetPropose.viewPropose()
            ElseIf FormSalesTargetPropose.XTCPropose.SelectedTabPageIndex = 1 Then

            End If
        ElseIf formName = "FormReportEstWHInQty" Then
            FormReportEstWHInQty.load_data()
        ElseIf formName = "FormSalesOrderReport" Then
            If FormSalesOrderReport.XTCSO.SelectedTabPageIndex = 0 Then
                FormSalesOrderReport.viewNewOrder()
            ElseIf FormSalesOrderReport.XTCSO.SelectedTabPageIndex = 1 Then
                FormSalesOrderReport.viewAllOrder()
            End If
        ElseIf formName = "FormProposeEmpSalary" Then
            FormProposeEmpSalary.load_pps()
        ElseIf formName = "FormItemSubCat" Then
            FormItemSubCat.load_cat()
        ElseIf formName = "FormItemCatMain" Then
            If FormItemCatMain.XTCCat.SelectedTabPageIndex = 0 Then
                FormItemCatMain.view_cat()
            ElseIf FormItemCatMain.XTCCat.SelectedTabPageIndex = 1 Then
                FormItemCatMain.view_propose()
            End If
        ElseIf formName = "FormVoucherPOS" Then
            'Voucher POS
            FormVoucherPOS.viewVoucher()
        ElseIf formName = "FormPromoRules" Then
            FormPromoRules.viewRules()
        ElseIf formName = "FormEmpInputAttendance" Then
            'input attendance
            FormEmpInputAttendance.view_attendance()
        ElseIf formName = "FormPurcReqList" Then
            'Purchase request IC
            FormPurcReqList.load_req()
        ElseIf formName = "FormPurcReq" Then
            FormPurcReq.load_dep()
            FormPurcReq.load_req()
            FormPurcReq.load_status()
            '
            FormPurcReq.check_menu()
        ElseIf formName = "FormBuktiPickup" Then
            FormBuktiPickup.load_form()
        ElseIf formName = "FormTrackingReturn" Then
            FormTrackingReturn.load_form()
        ElseIf formName = "FormEmpBPJSKesehatan" Then
            FormEmpBPJSKesehatan.load_form()
        ElseIf formName = "FormPopUpCompGroup" Then
            FormPopUpCompGroup.view_comp_group()
        ElseIf formName = "FormCompanyEmailMapping" Then
            FormCompanyEmailMapping.form_load()
        ElseIf formName = "FormInvoiceTracking" Then
            FormInvoiceTracking.viewData()
        ElseIf formName = "FormAREvalScheduke" Then
            FormAREvalScheduke.viewData()
        ElseIf formName = "FormEmpAttnAssign" Then
            FormEmpAttnAssign.load_attn()
        ElseIf formName = "FormDelayPayment" Then
            FormDelayPayment.viewData()
        ElseIf formName = "FormDelManifest" Then
            FormDelManifest.form_load()
        ElseIf formName = "FormFollowUpAR" Then
            If FormFollowUpAR.XTCAR.SelectedTabPageIndex = 0 Then
                FormFollowUpAR.viewList()
            ElseIf FormFollowUpAR.XTCAR.SelectedTabPageIndex = 1 Then
                FormFollowUpAR.viewActive()
            End If
        ElseIf formName = "FormAccountingLedger" Then
            FormAccountingLedger.view_form()
        ElseIf formName = "FormAccountingWorksheet" Then
            FormAccountingWorksheet.view_form()
        ElseIf formName = "FormEmpUniCreditNote" Then
            FormEmpUniCreditNote.view_form()
        ElseIf formName = "FormPaymentMissing" Then
            FormPaymentMissingDet.form_load()
        ElseIf formName = "FormBudgetProdDemand" Then
            If FormBudgetProdDemand.XTCBudget.SelectedTabPageIndex = 0 Then
                FormBudgetProdDemand.viewAppBudget()
            ElseIf FormBudgetProdDemand.XTCBudget.SelectedTabPageIndex = 1 Then
                FormBudgetProdDemand.viewPropose(FormBudgetProdDemand.last_cond)
            End If
        ElseIf formName = "FormLetterOfStatement" Then
            FormLetterOfStatement.form_load()
        ElseIf formName = "FormRetOlStore" Then
            FormRetOlStore.viewData()
        ElseIf formName = "FormRefundOLStore" Then
            FormRefundOLStore.viewData()
        ElseIf formName = "FormPromoCollection" Then
            FormPromoCollection.viewPropose()
        ElseIf formName = "FormExternalUser" Then
            FormExternalUser.load_form()
        ElseIf formName = "FormMasterStore" Then
            FormMasterStore.form_load()
        ElseIf formName = "FormMappingStore" Then
            FormMappingStore.form_load()
        ElseIf formName = "FormDesignColumn" Then
            FormDesignColumn.form_load()
        ElseIf formName = "FormPayoutReport" Then
            FormPayoutReport.viewData()
        ElseIf formName = "FormSalesBranch" Then
            FormSalesBranch.viewData()
        ElseIf formName = "FormMasterDesignFabrication" Then
            FormMasterDesignFabrication.load_form()
        ElseIf formName = "FormDesignColumnMapping" Then
            FormDesignColumnMapping.load_form()
        ElseIf formName = "FormPurcOrder" Then
            If FormPurcOrder.XTCPO.SelectedTabPage.Name = "XTPCloseReceiving" Then
                FormPurcOrder.load_close_receiving()
            ElseIf FormPurcOrder.XTCPO.SelectedTabPage.Name = "XTPReceiveDate" Then
                FormPurcOrder.load_receive_date()
            End If
        ElseIf formName = "FormMaterialRequisition" Then
            FormMaterialRequisition.view_mrs()
            FormMaterialRequisition.show_but_mrs()
        ElseIf formName = "FormABGRoyaltyZone" Then
            FormABGRoyaltyZone.viewData()
        ElseIf formName = "FormMasterCompany" Then
            FormMasterCompany.view_company()
        ElseIf formName = "FormAdditionalCost" Then
            FormAdditionalCost.load_view()
        ElseIf formName = "FormDesignImages" Then
            FormDesignImages.view_images()
        ElseIf formName = "FormEmployeeContract" Then
            FormEmployeeContract.form_load()
        ElseIf formName = "FormSalesReturnOrderMail" Then
            FormSalesReturnOrderMail.form_load()
        ElseIf formName = "FormInbound3PL" Then
            FormInbound3PL.load_view()
        ElseIf formName = "FormReturnNote" Then
            FormReturnNote.load_view()
        ElseIf formName = "FormListStore" Then
            FormListStore.view_company()
        ElseIf formName = "FormScanReturn" Then
            If FormScanReturn.XTCScanReturn.SelectedTabPageIndex = 0 Then
                FormScanReturn.load_view()
            Else
                FormScanReturn.load_bap()
            End If
        ElseIf formName = "FormBatchUploadOnlineStore" Then
            FormBatchUploadOnlineStore.GCBatchUpload.DataSource = Nothing
            FormBatchUploadOnlineStore.GVBatchUpload.Columns.Clear()
        ElseIf formName = "FormAdjustmentOG" Then
            FormAdjustmentOG.form_load()
        ElseIf formName = "FormOLReturnRefuse" Then
            If FormOLReturnRefuse.XTCData.SelectedTabPageIndex = 0 Then
                FormOLReturnRefuse.viewData()
            ElseIf FormOLReturnRefuse.XTCData.SelectedTabPageIndex = 1 Then
                FormOLReturnRefuse.viewOrderList()
            End If
        ElseIf formName = "FormPricePolicyCode" Then
            FormPricePolicyCode.viewData()
        ElseIf formName = "FormDeliveryMonitoring" Then
            FormDeliveryMonitoring.view_outbound()
        ElseIf formName = "FormProposePriceMKD" Then
            If FormProposePriceMKD.XTCData.SelectedTabPageIndex = 0 Then
                FormProposePriceMKD.viewSummary()
            ElseIf FormProposePriceMKD.XTCData.SelectedTabPageIndex = 1 Then
                FormProposePriceMKD.viewDetail()
            End If
        ElseIf formName = "FormOutboundPOD" Then
            FormOutboundPOD.viewData()
        ElseIf formName = "FormCatalogSpec" Then
            FormCatalogSpec.viewData()
        ElseIf formName = "FormStockTakeStorePeriod" Then
            FormStockTakeStorePeriod.load_form()
        ElseIf formName = "FormOGTransfer" Then
            FormOGTransfer.load_form()
        ElseIf formName = "FormSNIppsBudget" Then
            FormOGTransfer.load_form()
        ElseIf formName = "FormSNISerahTerima" Then
            FormSNISerahTerima.load_list()
        ElseIf formName = "FormStockTakePartial" Then
            FormStockTakePartial.form_load()
        ElseIf formName = "FormSNIRealisasi" Then
            FormSNIRealisasi.load_list()
        ElseIf formName = "FormSNIQC" Then
            FormSNIQC.load_list()
        ElseIf formName = "FormSNIWH" Then
            FormSNIWH.load_list()
        ElseIf formName = "FormPreCalFGPO" Then
            FormPreCalFGPO.load_list()
        ElseIf formName = "FormStockTakePropose" Then
            FormStockTakePropose.load_form()
        ElseIf formName = "FormPrepaidExpense" Then
            FormPrepaidExpense.viewData()
        ElseIf formName = "FormPromoZalora" Then
            FormPromoZalora.viewData()
        ElseIf formName = "FormProposePromo" Then
            FormProposePromo.form_load()
        ElseIf formName = "FormNominatifPromo" Then
            FormNominatifPromo.form_load()
        ElseIf formName = "FormRetExos" Then
            FormRetExos.viewData()
        ElseIf formName = "FormDisableExos" Then
            FormDisableExos.viewData()
        ElseIf formName = "FormEOSChange" Then
            FormEOSChange.viewData()
        ElseIf formName = "FormEts" Then
            FormEts.viewData()
        ElseIf formName = "FormBSP" Then
            FormBSP.viewData()
        End If
    End Sub
    'Switch
    Private Sub BBSwitch_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBSwitch.ItemClick
        If formName = "FormMasterWH" Then
            'WAREHOUSE & LOCATOR
            If FormMasterWH.XTCWHMain.SelectedTabPageIndex = 1 Then
                'Try
                If FormMasterWH.XTCStock.SelectedTabPageIndex = 0 Then
                    Dim id_wh_drawer As Integer = FormMasterWH.SLEDrawer.EditValue
                    If id_wh_drawer > 0 Or id_wh_drawer <> Nothing Then
                        FormSampleStorageIn.action = "upd"
                        FormSampleStorageIn.id_sample = FormMasterWH.GVSample.GetFocusedRowCellDisplayText("id_sample").ToString
                        FormSampleStorageIn.ShowDialog()
                    Else
                        errorCustom("Cannot switch locator, please Select detail drawer !")
                    End If
                ElseIf FormMasterWH.XTCStock.SelectedTabPageIndex = 1 Then
                    Dim id_wh_drawer As Integer = FormMasterWH.SLEDrawerStockMat.EditValue
                    If id_wh_drawer > 0 Or id_wh_drawer <> Nothing Then
                        FormMatStorageIn.action = "upd"
                        FormMatStorageIn.id_mat_det = FormMasterWH.GVMatStock.GetFocusedRowCellDisplayText("id_mat_det").ToString
                        FormMatStorageIn.ShowDialog()
                    Else
                        errorCustom("Cannot switch locator, please Select detail drawer !")
                    End If
                ElseIf FormMasterWH.XTCStock.SelectedTabPageIndex = 2 Then
                    Dim id_wh_drawer As Integer = FormMasterWH.SLEDrawerStockFG.EditValue
                    If id_wh_drawer > 0 Or id_wh_drawer <> Nothing Then
                        FormProductionStorageIn.action = "upd"
                        FormProductionStorageIn.id_product = FormMasterWH.GVFGStock.GetFocusedRowCellValue("id_product").ToString
                        FormProductionStorageIn.colorku = FormMasterWH.GVFGStock.GetFocusedRowCellValue("color").ToString
                        FormProductionStorageIn.sizeku = FormMasterWH.GVFGStock.GetFocusedRowCellValue("size").ToString
                        FormProductionStorageIn.id_bomx = FormMasterWH.GVFGStock.GetFocusedRowCellValue("id_bom").ToString
                        FormProductionStorageIn.bom_unit_pricex = FormMasterWH.GVFGStock.GetFocusedRowCellValue("bom_unit_price").ToString
                        FormProductionStorageIn.jumx = FormMasterWH.GVFGStock.GetFocusedRowCellValue("qty_all_product").ToString
                        FormProductionStorageIn.id_sample = FormMasterWH.GVFGStock.GetFocusedRowCellValue("id_sample").ToString
                        FormProductionStorageIn.ShowDialog()
                    Else
                        errorCustom("Cannot switch locator, please Select detail drawer !")
                    End If
                End If
                'Catch ex As Exception

                'End Try
            End If
        ElseIf formName = "FormSampleStock" Then
            Dim id_wh_drawer As Integer = FormSampleStock.SLEDrawer.EditValue
            Dim id_sample_par As String = "-1"
            Try
                id_sample_par = FormSampleStock.GVSample.GetFocusedRowCellValue("id_sample").ToString
            Catch ex As Exception
            End Try

            If id_wh_drawer > 0 Or id_wh_drawer <> Nothing Or id_sample_par <> "-1" Then
                FormSampleStorageIn.action = "upd"
                FormSampleStorageIn.id_sample = id_sample_par
                FormSampleStorageIn.ShowDialog()
            Else
                errorCustom("Cannot switch locator, please Select detail drawer !")
            End If
        End If
    End Sub
    ' view
    Private Sub BBView_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBView.ItemClick
        Cursor = Cursors.WaitCursor
        If formName = "FormWork" Then
            If FormWork.XTCGeneral.SelectedTabPageIndex = 0 Then

            End If
        ElseIf formName = "FormFGStockOpnameStore" Then
            FormViewFGStockOpname.id_fg_so_store = FormFGStockOpnameStore.GVSOStore.GetFocusedRowCellValue("id_fg_so_store").ToString
            FormViewFGStockOpname.ShowDialog()
        ElseIf formName = "FormFGStockOpnameWH" Then
            FormViewFGStockOpnameWH.id_fg_so_wh = FormFGStockOpnameWH.GVSOWH.GetFocusedRowCellValue("id_fg_so_wh").ToString
            FormViewFGStockOpnameWH.ShowDialog()
        ElseIf formName = "FormMatStockOpname" Then
            If Not FormMatStockOpname.GVMatPR.IsGroupRow(FormMatStockOpname.GVMatPR.FocusedRowHandle) Then
                If Not FormMatStockOpname.GVMatPR.GetFocusedRowCellValue("id_lock") = "1" Then
                    FormMatStockOpnameResultDet.id_mat_so = FormMatStockOpname.GVMatPR.GetFocusedRowCellValue("id_mat_so").ToString
                    FormMatStockOpnameResultDet.ShowDialog()
                Else
                    warningCustom("This opname Not done yet.")
                End If
            End If
        ElseIf formName = "FormAccountingFYear" Then
            FormAccountingFYearDet.id_acc_fy = FormAccountingFYear.GVAcc.GetFocusedRowCellValue("id_acc_fy").ToString
            FormAccountingFYearDet.ShowDialog()
        ElseIf formName = "FormAccountingListPR" Then
            Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
            showpopup.report_mark_type = FormAccountingListPR.GVPaymentList.GetFocusedRowCellValue("report_mark_type").ToString()
            showpopup.id_report = FormAccountingListPR.GVPaymentList.GetFocusedRowCellValue("id_report").ToString()
            showpopup.is_payment = "1"
            showpopup.show()
        End If
        Cursor = Cursors.Default
    End Sub

    '-------- mapping COA button menu ------------
    Private Sub BBMappingCOA_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBMappingCOA.ItemClick
        If formName = "FormSamplePurchase" Then
            FormMappingCOA.report_mark_type = "1"
            FormMappingCOA.ShowDialog()
        ElseIf formName = "FormSampleReceive" Then
            FormMappingCOA.report_mark_type = "2"
            FormMappingCOA.ShowDialog()
        ElseIf formName = "FormMatPurchase" Then
            FormMappingCOA.report_mark_type = "13"
            FormMappingCOA.ShowDialog()
        ElseIf formName = "FormMatRecPurc" Then
            FormMappingCOA.report_mark_type = "16"
            FormMappingCOA.ShowDialog()
        ElseIf formName = "FormMatWO" Then
            FormMappingCOA.report_mark_type = "15"
            FormMappingCOA.ShowDialog()
        ElseIf formName = "FormMatRecWO" Then
            FormMappingCOA.report_mark_type = "17"
            FormMappingCOA.ShowDialog()
        ElseIf formName = "FormMatRet" Then
            If FormMatRet.XTCReturnPruchase.SelectedTabPageIndex = 0 Then 'ret out
                FormMappingCOA.report_mark_type = "18"
                FormMappingCOA.ShowDialog()
            Else 'ret in
                FormMappingCOA.report_mark_type = "19"
                FormMappingCOA.ShowDialog()
            End If
        ElseIf formName = "FormMatAdj" Then
            If FormMatAdj.XTCAdj.SelectedTabPageIndex = 0 Then 'adj in
                FormMappingCOA.report_mark_type = "26"
                FormMappingCOA.ShowDialog()
            Else 'adj out
                FormMappingCOA.report_mark_type = "27"
                FormMappingCOA.ShowDialog()
            End If
        ElseIf formName = "FormSampleAdjustment" Then
            If FormSampleAdjustment.XTCAdj.SelectedTabPageIndex = 0 Then 'adj in
                FormMappingCOA.report_mark_type = "20"
                FormMappingCOA.ShowDialog()
            Else 'adj out
                FormMappingCOA.report_mark_type = "21"
                FormMappingCOA.ShowDialog()
            End If
        ElseIf formName = "FormMatPL" Then
            If FormMatPL.XTCPL.SelectedTabPageIndex = 0 Then 'prod
                FormMappingCOA.report_mark_type = "30"
                FormMappingCOA.ShowDialog()
            ElseIf FormMatPL.XTCPL.SelectedTabPageIndex = 1 Then 'wo mat
                FormMappingCOA.report_mark_type = "30"
                FormMappingCOA.ShowDialog()
            ElseIf FormMatPL.XTCPL.SelectedTabPageIndex = 2 Then 'other
                FormMappingCOA.report_mark_type = "30"
                FormMappingCOA.ShowDialog()
            End If
        ElseIf formName = "FormMatInvoice" Then
            If FormMatInvoice.XTCTabGeneral.SelectedTabPageIndex = 0 Then 'invoice
                FormMappingCOA.report_mark_type = "34"
                FormMappingCOA.ShowDialog()
            ElseIf FormMatInvoice.XTCTabGeneral.SelectedTabPageIndex = 1 Then 'return invoice
                FormMappingCOA.report_mark_type = "35"
                FormMappingCOA.ShowDialog()
            End If
        End If
    End Sub
    '------------LINK MENU---------------------------------
    'MASTER Area
    Private Sub NBArea_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBArea.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterArea.MdiParent = Me
            FormMasterArea.Show()
            FormMasterArea.WindowState = FormWindowState.Maximized
            FormMasterArea.Focus()
            RPSubMenu.Visible = True
            RibbonControl.SelectedPage = RPSubMenu
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'MASTER ITEM CATEGORY
    Private Sub NavBarItemItemCategory_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItemItemCategory.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterRawMaterialCat.MdiParent = Me
            FormMasterRawMaterialCat.Show()
            FormMasterRawMaterialCat.WindowState = FormWindowState.Maximized
            FormMasterRawMaterialCat.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'MASTER ITEM SIZE
    Private Sub NavBarItemItemSize_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs)
        Cursor = Cursors.WaitCursor
        Try
            FormMasterItemSize.MdiParent = Me
            FormMasterItemSize.Show()
            FormMasterItemSize.WindowState = FormWindowState.Maximized
            FormMasterItemSize.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'MASTER ITEM COLOR-
    Private Sub NBIItemColor_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs)
        Cursor = Cursors.WaitCursor
        Try
            FormMasterItemColor.MdiParent = Me
            FormMasterItemColor.Show()
            FormMasterItemColor.WindowState = FormWindowState.Maximized
            FormMasterItemColor.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'MASTER Company Category
    Private Sub NBCompany_category_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCompany_category.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterCompanyCategory.MdiParent = Me
            FormMasterCompanyCategory.Show()
            FormMasterCompanyCategory.WindowState = FormWindowState.Maximized
            FormMasterCompanyCategory.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Master UOM
    Private Sub NBUom_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBUom.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterUOM.MdiParent = Me
            FormMasterUOM.Show()
            FormMasterUOM.WindowState = FormWindowState.Maximized
            FormMasterUOM.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Season
    Private Sub NBSeason_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSeason.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSeason.MdiParent = Me
            FormSeason.from_menu = "season"
            FormSeason.Show()
            FormSeason.WindowState = FormWindowState.Maximized
            FormSeason.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Master Departement
    Private Sub NBDepartement_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBDepartement.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterDepartement.MdiParent = Me
            FormMasterDepartement.Show()
            FormMasterDepartement.WindowState = FormWindowState.Maximized
            FormMasterDepartement.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Master User
    Private Sub NBUser_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBUser.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterUser.MdiParent = Me
            FormMasterUser.Show()
            FormMasterUser.WindowState = FormWindowState.Maximized
            FormMasterUser.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Master Access
    Private Sub NBAccessUser_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAccessUser.LinkClicked
        Try
            FormAccess.MdiParent = Me
            FormAccess.Show()
            FormAccess.WindowState = FormWindowState.Maximized
            FormAccess.Focus()
            BBMapping.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Catch ex As Exception
            errorProcess()
            Close()
        End Try
    End Sub
    'Master Company
    Private Sub BBCompContact_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBCompContact.ItemClick
        Cursor = Cursors.WaitCursor
        Try
            FormMasterCompanyContact.id_company = FormMasterCompany.GVCompany.GetFocusedRowCellDisplayText("id_company").ToString
            FormMasterCompanyContact.ShowDialog()
        Catch ex As Exception

        End Try
        Cursor = Cursors.Default
    End Sub
    'Company
    Private Sub NBCompany_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCompany.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterCompany.MdiParent = Me
            FormMasterCompany.Show()
            FormMasterCompany.WindowState = FormWindowState.Maximized
            FormMasterCompany.Focus()
            FormMasterCompany.Visible = True
        Catch ex As Exception
        End Try
        Cursor = Cursors.Default
    End Sub
    'Master Raw Material
    Private Sub NBRawMaterial_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBRawMaterial.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterRawMaterial.MdiParent = Me
            FormMasterRawMaterial.Show()
            FormMasterRawMaterial.WindowState = FormWindowState.Maximized
            FormMasterRawMaterial.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Master OVH
    Private Sub NBOVH_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBOVH.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterOVH.MdiParent = Me
            FormMasterOVH.Show()
            FormMasterOVH.WindowState = FormWindowState.Maximized
            FormMasterOVH.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Setup Raw Mat Code
    Private Sub NBRawMatCode_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBRawMatCode.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSetupRawMatCode.MdiParent = Me
            FormSetupRawMatCode.Show()
            FormSetupRawMatCode.WindowState = FormWindowState.Maximized
            FormSetupRawMatCode.Focus()
        Catch ex As Exception
            errorProcess()
            FormSetupRawMatCode.Dispose()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Production Demand
    Private Sub NBProdDemand_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProdDemand.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormProdDemand.MdiParent = Me
            FormProdDemand.Show()
            FormProdDemand.WindowState = FormWindowState.Maximized
            FormProdDemand.Focus()
        Catch ex As Exception
            errorProcess()
            FormProdDemand.Dispose()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Link Code
    Private Sub NBCode_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCode.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterCode.MdiParent = Me
            FormMasterCode.Show()
            FormMasterCode.WindowState = FormWindowState.Maximized
            FormMasterCode.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Link Code Template
    Private Sub NBCodeTemplate_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCodeTemplate.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormTemplateCode.MdiParent = Me
            FormTemplateCode.Show()
            FormTemplateCode.WindowState = FormWindowState.Maximized
            FormTemplateCode.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Link Sample
    Private Sub NBSample_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSample.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterSample.MdiParent = Me
            FormMasterSample.Show()
            FormMasterSample.WindowState = FormWindowState.Maximized
            FormMasterSample.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Link Product
    Private Sub NBProduct_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProduct.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterProduct.MdiParent = Me
            FormMasterProduct.Show()
            FormMasterProduct.WindowState = FormWindowState.Maximized
            FormMasterProduct.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Link BOM
    Private Sub NBBom_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBBom.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormBOM.MdiParent = Me
            FormBOM.Show()
            FormBOM.WindowState = FormWindowState.Maximized
            FormBOM.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Link Picture Location
    Private Sub NBPicLocation_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPicLocation.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSetupPicLocation.ShowDialog()
            FormBOM.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Link Accounnt Edit
    Private Sub BBEditAccount_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBEditAccount.ItemClick
        FormAccount.change = True
        FormAccount.ShowDialog()
    End Sub
    'Master Raw Material Category
    Private Sub NBRawMatCat_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBRawMatCat.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterRawMaterialCat.MdiParent = Me
            FormMasterRawMaterialCat.Show()
            FormMasterRawMaterialCat.WindowState = FormWindowState.Maximized
            FormMasterRawMaterialCat.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Sample Packing List
    Private Sub NBPLSample_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPLSample.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSamplePL.MdiParent = Me
            FormSamplePL.Show()
            FormSamplePL.WindowState = FormWindowState.Maximized
            FormSamplePL.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'header number
    Private Sub NBHeadNumber_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBHeadNumber.LinkClicked
        Cursor = Cursors.WaitCursor
        'Try
        FormSetupNumberHeader.ShowDialog()
        FormSetupNumberHeader.Focus()
        'Catch ex As Exception
        '    errorProcess()
        'End Try
        Cursor = Cursors.Default
    End Sub
    'Sample Purchase
    Private Sub NBSamplePurchase_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSamplePurchase.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSamplePurchase.MdiParent = Me
            FormSamplePurchase.Show()
            FormSamplePurchase.WindowState = FormWindowState.Maximized
            FormSamplePurchase.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Sample Receive
    Private Sub NBSampleReceive_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSampleReceive.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleReceive.MdiParent = Me
            FormSampleReceive.Show()
            FormSampleReceive.WindowState = FormWindowState.Maximized
            FormSampleReceive.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Sample PR
    Private Sub NBSamplePR_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSamplePR.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSamplePR.MdiParent = Me
            FormSamplePR.Show()
            FormSamplePR.WindowState = FormWindowState.Maximized
            FormSamplePR.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Master Warehouse & LOcator
    Private Sub NBWH_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBWH.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterWH.Dispose()
            FormMasterWH.MdiParent = Me
            FormMasterWH.Show()
            FormMasterWH.WindowState = FormWindowState.Maximized
            FormMasterWH.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Receipt Sample
    Private Sub NBReceiptSample_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBReceiptSample.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleReceipt.MdiParent = Me
            FormSampleReceipt.Show()
            FormSampleReceipt.WindowState = FormWindowState.Maximized
            FormSampleReceipt.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Return Sample
    Private Sub NBROSample_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBROSample.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleRet.MdiParent = Me
            FormSampleRet.Show()
            FormSampleRet.WindowState = FormWindowState.Maximized
            FormSampleRet.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBWork_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBWork.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormWork.MdiParent = Me
            FormWork.Show()
            FormWork.WindowState = FormWindowState.Maximized
            FormWork.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Packing List Delivery
    Private Sub NBPLDel_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPLDel.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSamplePLDel.MdiParent = Me
            FormSamplePLDel.Show()
            FormSamplePLDel.WindowState = FormWindowState.Maximized
            FormSamplePLDel.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Sample Requisition
    Private Sub NBReqSample_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBReqSample.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleReq.MdiParent = Me
            FormSampleReq.Show()
            FormSampleReq.WindowState = FormWindowState.Maximized
            FormSampleReq.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    Private Sub NBMarkAssign_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMarkAssign.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMarkAssign.MdiParent = Me
            FormMarkAssign.Show()
            FormMarkAssign.WindowState = FormWindowState.Maximized
            FormMarkAssign.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSamplePlan_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSamplePlan.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSamplePlan.MdiParent = Me
            FormSamplePlan.Show()
            FormSamplePlan.WindowState = FormWindowState.Maximized
            FormSamplePlan.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMatPurchase_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMatPurchase.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMatPurchase.MdiParent = Me
            FormMatPurchase.Show()
            FormMatPurchase.WindowState = FormWindowState.Maximized
            FormMatPurchase.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBReturnSample_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBReturnSample.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleReturn.MdiParent = Me
            FormSampleReturn.Show()
            FormSampleReturn.WindowState = FormWindowState.Maximized
            FormSampleReturn.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMatWO_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMatWO.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMatWO.MdiParent = Me
            FormMatWO.Show()
            FormMatWO.WindowState = FormWindowState.Maximized
            FormMatWO.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMatRecPurc_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMatRecPurc.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMatRecPurc.MdiParent = Me
            FormMatRecPurc.Show()
            FormMatRecPurc.WindowState = FormWindowState.Maximized
            FormMatRecPurc.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMatRecWO_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMatRecWO.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMatRecWO.MdiParent = Me
            FormMatRecWO.Show()
            FormMatRecWO.WindowState = FormWindowState.Maximized
            FormMatRecWO.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMatRet_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMatRet.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMatRet.MdiParent = Me
            FormMatRet.Show()
            FormMatRet.WindowState = FormWindowState.Maximized
            FormMatRet.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAdjSample_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAdjSample.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleAdjustment.MdiParent = Me
            FormSampleAdjustment.Show()
            FormSampleAdjustment.WindowState = FormWindowState.Maximized
            FormSampleAdjustment.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBProdOrder_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProdOrder.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormProduction.MdiParent = Me
            FormProduction.Show()
            FormProduction.WindowState = FormWindowState.Maximized
            FormProduction.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMatPR_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMatPR.LinkClicked
        Cursor = Cursors.WaitCursor
        'Try
        FormMatPR.MdiParent = Me
        FormMatPR.Show()
        FormMatPR.WindowState = FormWindowState.Maximized
        FormMatPR.Focus()
        ' Catch ex As Exception
        'errorProcess()
        'End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMatPRWO_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMatPRWO.LinkClicked
        Cursor = Cursors.WaitCursor
        FormMatPRWO.MdiParent = Me
        FormMatPRWO.Show()
        FormMatPRWO.WindowState = FormWindowState.Maximized
        FormMatPRWO.Focus()
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAdjMat_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAdjMat.LinkClicked
        Cursor = Cursors.WaitCursor
        FormMatAdj.MdiParent = Me
        FormMatAdj.Show()
        FormMatAdj.WindowState = FormWindowState.Maximized
        FormMatAdj.Focus()
        Cursor = Cursors.Default
    End Sub

    Private Sub NBProdRec_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProdRec.LinkClicked
        Cursor = Cursors.WaitCursor
        FormProductionRec.MdiParent = Me
        FormProductionRec.Show()
        FormProductionRec.WindowState = FormWindowState.Maximized
        FormProductionRec.Focus()
        Cursor = Cursors.Default
    End Sub

    Private Sub NBProdReturn_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProdReturn.LinkClicked
        Cursor = Cursors.WaitCursor
        FormProductionRet.MdiParent = Me
        FormProductionRet.Show()
        FormProductionRet.WindowState = FormWindowState.Maximized
        FormProductionRet.Focus()
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMatPL_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMatPL.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMatPL.MdiParent = Me
            FormMatPL.Show()
            FormMatPL.WindowState = FormWindowState.Maximized
            FormMatPL.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMatMRS_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMatMRS.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMatMRS.MdiParent = Me
            FormMatMRS.Show()
            FormMatMRS.WindowState = FormWindowState.Maximized
            FormMatMRS.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBProdPLToWH_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProdPLToWH.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormProductionPLToWH.MdiParent = Me
            FormProductionPLToWH.Show()
            FormProductionPLToWH.WindowState = FormWindowState.Maximized
            FormProductionPLToWH.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMatInvoice_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMatInvoice.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMatInvoice.MdiParent = Me
            FormMatInvoice.Show()
            FormMatInvoice.WindowState = FormWindowState.Maximized
            FormMatInvoice.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAcc_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAcc.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormAccounting.MdiParent = Me
            FormAccounting.Show()
            FormAccounting.WindowState = FormWindowState.Maximized
            FormAccounting.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAccJounal_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAccJournal.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormAccountingJournal.MdiParent = Me
            FormAccountingJournal.Show()
            FormAccountingJournal.WindowState = FormWindowState.Maximized
            FormAccountingJournal.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBProdRecWH_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProdRecWH.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormProductionPLToWHRec.MdiParent = Me
            FormProductionPLToWHRec.Show()
            FormProductionPLToWHRec.WindowState = FormWindowState.Maximized
            FormProductionPLToWHRec.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSalesTarget_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesTarget.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesTarget.MdiParent = Me
            FormSalesTarget.Show()
            FormSalesTarget.WindowState = FormWindowState.Maximized
            FormSalesTarget.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSalesOrder_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesOrder.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesOrder.Close()
            FormSalesOrder.Dispose()
        Catch ex As Exception
        End Try
        Try
            FormSalesOrder.MdiParent = Me
            FormSalesOrder.Show()
            FormSalesOrder.WindowState = FormWindowState.Maximized
            FormSalesOrder.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSalesDelOrder_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesDelOrder.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesDelOrder.MdiParent = Me
            FormSalesDelOrder.Show()
            FormSalesDelOrder.WindowState = FormWindowState.Maximized
            FormSalesDelOrder.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSalesReturnOrder_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesReturnOrder.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesReturnOrder.MdiParent = Me
            FormSalesReturnOrder.Show()
            FormSalesReturnOrder.WindowState = FormWindowState.Maximized
            FormSalesReturnOrder.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBProdWOPR_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProdWOPR.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormProdPRWO.MdiParent = Me
            FormProdPRWO.Show()
            FormProdPRWO.WindowState = FormWindowState.Maximized
            FormProdPRWO.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    Private Sub NBJournalAdj_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBJournalAdj.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormAccountingJournalAdj.MdiParent = Me
            FormAccountingJournalAdj.Show()
            FormAccountingJournalAdj.WindowState = FormWindowState.Maximized
            FormAccountingJournalAdj.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSalesReturn_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesReturn.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesReturn.MdiParent = Me
            FormSalesReturn.Show()
            FormSalesReturn.WindowState = FormWindowState.Maximized
            FormSalesReturn.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSalesPOS_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesPOS.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesPOS.Close()
            FormSalesPOS.Dispose()
        Catch ex As Exception
        End Try
        Try
            FormSalesPOS.MdiParent = Me
            FormSalesPOS.Show()
            FormSalesPOS.WindowState = FormWindowState.Maximized
            FormSalesPOS.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBReturnQC_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesReturnQC.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesReturnQC.MdiParent = Me
            FormSalesReturnQC.Show()
            FormSalesReturnQC.WindowState = FormWindowState.Maximized

            FormSalesReturnQC.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSalesInvoice_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesInvoice.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesInvoice.MdiParent = Me
            FormSalesInvoice.Show()
            FormSalesInvoice.WindowState = FormWindowState.Maximized
            FormSalesInvoice.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGSoStore_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGSoStore.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGStockOpnameStore.MdiParent = Me
            FormFGStockOpnameStore.Show()
            FormFGStockOpnameStore.WindowState = FormWindowState.Maximized
            FormFGStockOpnameStore.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGMissing_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGMissing.LinkClicked
        'missung invoice promo
        Cursor = Cursors.WaitCursor
        Try
            FormSalesPOS.Close()
            FormSalesPOS.Dispose()
        Catch ex As Exception
        End Try
        Try
            FormSalesPOS.MdiParent = Me
            FormSalesPOS.id_menu = "3"
            FormSalesPOS.Show()
            FormSalesPOS.WindowState = FormWindowState.Maximized
            FormSalesPOS.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGMissingInvoice_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGMissingInvoice.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGMissingInvoice.MdiParent = Me
            FormFGMissingInvoice.Show()
            FormFGMissingInvoice.WindowState = FormWindowState.Maximized
            FormFGMissingInvoice.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGSOWH_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGSOWH.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGStockOpnameWH.MdiParent = Me
            FormFGStockOpnameWH.Show()
            FormFGStockOpnameWH.WindowState = FormWindowState.Maximized
            FormFGStockOpnameWH.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMatSO_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMatSO.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMatStockOpname.MdiParent = Me
            FormMatStockOpname.Show()
            FormMatStockOpname.WindowState = FormWindowState.Maximized
            FormMatStockOpname.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGAdj_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGAdj.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGAdj.MdiParent = Me
            FormFGAdj.Show()
            FormFGAdj.WindowState = FormWindowState.Maximized
            FormFGAdj.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGTrf_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGTrf.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGTrf.MdiParent = Me
            FormFGTrf.Show()
            FormFGTrf.WindowState = FormWindowState.Maximized
            FormFGTrf.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGTrfRec_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGTrfRec.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGTrfReceive.MdiParent = Me
            FormFGTrfReceive.Show()
            FormFGTrfReceive.WindowState = FormWindowState.Maximized
            FormFGTrfReceive.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGTracking_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGTracking.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGTracking.MdiParent = Me
            FormFGTracking.Show()
            FormFGTracking.WindowState = FormWindowState.Maximized
            FormFGTracking.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGStock_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGStock.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGStock.MdiParent = Me
            FormFGStock.Show()
            FormFGStock.WindowState = FormWindowState.Maximized
            FormFGStock.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAccSum_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAccSum.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormAccountingSummary.MdiParent = Me
            FormAccountingSummary.Show()
            FormAccountingSummary.WindowState = FormWindowState.Maximized
            FormAccountingSummary.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAccFY_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAccFY.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormAccountingFYear.MdiParent = Me
            FormAccountingFYear.Show()
            FormAccountingFYear.WindowState = FormWindowState.Maximized
            FormAccountingFYear.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMatStock_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMatStock.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMatStock.MdiParent = Me
            FormMatStock.Show()
            FormMatStock.WindowState = FormWindowState.Maximized
            FormMatStock.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSampleStock_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSampleStock.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleStock.MdiParent = Me
            FormSampleStock.Show()
            FormSampleStock.WindowState = FormWindowState.Maximized
            FormSampleStock.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBEmployee_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBEmployee.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterEmployee.MdiParent = Me
            FormMasterEmployee.Show()
            FormMasterEmployee.WindowState = FormWindowState.Maximized
            FormMasterEmployee.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    'Feedback
    Private Sub BBFeedback_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBFeedback.ItemClick
        Cursor = Cursors.WaitCursor
        Try
            FormFeedback.ShowDialog()
            FormFeedback.WindowState = FormWindowState.Maximized
            FormFeedback.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    'Delivery Sample To Warehouse
    Private Sub NBSampleDelivery_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSampleDelivery.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleDel.MdiParent = Me
            FormSampleDel.Show()
            FormSampleDel.WindowState = FormWindowState.Maximized
            FormSampleDel.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub BBAbout_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBAbout.ItemClick
        about()
        If id_role_login = id_super_user Then
            FormSuperUser.ShowDialog()
        End If
    End Sub

    Sub about()
        infoCustom("Version " + Application.ProductVersion.ToString)
    End Sub

    'Rec Delivery Sample To Warehouse
    Private Sub NBSampleDelRec_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSampleDelRec.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleDelRec.MdiParent = Me
            FormSampleDelRec.Show()
            FormSampleDelRec.WindowState = FormWindowState.Maximized
            FormSampleDelRec.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Barcode Sample
    Private Sub NBSampleBarcode_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSampleBarcode.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSamplePrintBarcode.MdiParent = Me
            FormSamplePrintBarcode.Show()
            FormSamplePrintBarcode.WindowState = FormWindowState.Maximized
            FormSamplePrintBarcode.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    'Sample Order
    Private Sub NBSampleOrder_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSampleOrder.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleOrder.MdiParent = Me
            FormSampleOrder.Show()
            FormSampleOrder.WindowState = FormWindowState.Maximized
            FormSampleOrder.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    'Sample Delivery Order
    Private Sub NBSampleDelOrder_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSampleDelOrder.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleDelOrder.MdiParent = Me
            FormSampleDelOrder.Show()
            FormSampleDelOrder.WindowState = FormWindowState.Maximized
            FormSampleDelOrder.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSampleStockOpname_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSampleStockOpname.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleStockOpname.MdiParent = Me
            FormSampleStockOpname.Show()
            FormSampleStockOpname.WindowState = FormWindowState.Maximized
            FormSampleStockOpname.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGCodeReplace_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGCodeReplace.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGCodeReplace.MdiParent = Me
            FormFGCodeReplace.Show()
            FormFGCodeReplace.WindowState = FormWindowState.Maximized
            FormFGCodeReplace.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBPayment_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPayment.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormAccountingListPR.MdiParent = Me
            FormAccountingListPR.Show()
            FormAccountingListPR.WindowState = FormWindowState.Maximized
            FormAccountingListPR.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub BBPay_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBPay.ItemClick
        If formName = "FormAccountingListPR" Then
            FormAccountingListPR.GVPaymentList.ActiveFilterString = String.Empty
            FormAccountingListPR.GVPaymentList.ActiveFilterString = "is_check='yes'"
            FormAccountingListPR.GVPaymentList.UpdateCurrentRow()

            FormAccountingListPRPay.ShowDialog()
        End If
    End Sub

    Private Sub NBSalesWeekly_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesWeekly.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesWeekly.MdiParent = Me
            FormSalesWeekly.Show()
            FormSalesWeekly.WindowState = FormWindowState.Maximized
            FormSalesWeekly.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    'CREDIT NOTE
    Private Sub NBSalesCreditNote_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesCreditNote.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesPOS.Close()
            FormSalesPOS.Dispose()
        Catch ex As Exception
        End Try
        Try
            FormSalesPOS.MdiParent = Me
            FormSalesPOS.id_menu = "2"
            FormSalesPOS.Show()
            FormSalesPOS.WindowState = FormWindowState.Maximized
            FormSalesPOS.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    'MISSING CREDIT NOTE
    Private Sub NBFGMissingCreditNote_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGMissingCreditNote.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGMissingCreditNote.MdiParent = Me
            FormFGMissingCreditNote.Show()
            FormFGMissingCreditNote.WindowState = FormWindowState.Maximized
            FormFGMissingCreditNote.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSOHPeriode_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSOHPeriode.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSOHPeriode.MdiParent = Me
            FormSOHPeriode.Show()
            FormSOHPeriode.WindowState = FormWindowState.Maximized
            FormSOHPeriode.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSOH_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSOH.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSOH.MdiParent = Me
            FormSOH.Show()
            FormSOH.WindowState = FormWindowState.Maximized
            FormSOH.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSOHPrice_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSOHPrice.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSOHPrice.MdiParent = Me
            FormSOHPrice.Show()
            FormSOHPrice.WindowState = FormWindowState.Maximized
            FormSOHPrice.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSOHSum_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSOHSum.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSOHSum.MdiParent = Me
            FormSOHSum.Show()
            FormSOHSum.WindowState = FormWindowState.Maximized
            FormSOHSum.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGWoff_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGWoff.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGWoff.MdiParent = Me
            FormFGWoff.Show()
            FormFGWoff.WindowState = FormWindowState.Maximized
            FormFGWoff.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGWoffList_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGWoffList.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGWoffList.MdiParent = Me
            FormFGWoffList.Show()
            FormFGWoffList.WindowState = FormWindowState.Maximized
            FormFGWoffList.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBProposePrice_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProposePrice.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGProposePrice.MdiParent = Me
            FormFGProposePrice.Show()
            FormFGProposePrice.WindowState = FormWindowState.Maximized
            FormFGProposePrice.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGLineList_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGLineList.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGLineList.MdiParent = Me
            FormFGLineList.Show()
            FormFGLineList.WindowState = FormWindowState.Maximized
            FormFGLineList.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBDistSchemaSetup_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBDistSchemaSetup.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGDistSchemaSetup.MdiParent = Me
            FormFGDistSchemaSetup.Show()
            FormFGDistSchemaSetup.WindowState = FormWindowState.Maximized
            FormFGDistSchemaSetup.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGLineListDsg_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGLineListDsg.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGLineList.MdiParent = Me
            FormFGLineList.id_pop_up = "2"
            FormFGLineList.Show()
            FormFGLineList.WindowState = FormWindowState.Maximized
            FormFGLineList.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBRetCode_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBRetCode.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterRetCode.MdiParent = Me
            FormMasterRetCode.Show()
            FormMasterRetCode.WindowState = FormWindowState.Maximized
            FormMasterRetCode.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGProdList_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGProdList.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGProdList.MdiParent = Me
            FormFGProdList.Show()
            FormFGProdList.WindowState = FormWindowState.Maximized
            FormFGProdList.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBPrintBarcode_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPrintBarcode.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormBarcodeProduct.MdiParent = Me
            FormBarcodeProduct.Show()
            FormBarcodeProduct.WindowState = FormWindowState.Maximized
            FormBarcodeProduct.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBDesignList_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBDesignList.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterDesignCOP.MdiParent = Me
            FormMasterDesignCOP.Show()
            FormMasterDesignCOP.WindowState = FormWindowState.Maximized
            FormMasterDesignCOP.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub


    Private Sub NBSampleOrdered_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSampleOrdered.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleOrdered.MdiParent = Me
            FormSampleOrdered.Show()
            FormSampleOrdered.WindowState = FormWindowState.Maximized
            FormSampleOrdered.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGDS_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGDS.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGDistScheme.MdiParent = Me
            FormFGDistScheme.Show()
            FormFGDistScheme.WindowState = FormWindowState.Maximized
            FormFGDistScheme.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBRateStore_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBRateStore.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterRateStore.MdiParent = Me
            FormMasterRateStore.Show()
            FormMasterRateStore.WindowState = FormWindowState.Maximized
            FormMasterRateStore.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Private Sub NBAccMap_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAccMap.LinkClicked
    '    Cursor = Cursors.WaitCursor
    '    Try
    '        FormAccountingMapping.MdiParent = Me
    '        FormAccountingMapping.Show()
    '        FormAccountingMapping.WindowState = FormWindowState.Maximized
    '        FormAccountingMapping.Focus()
    '    Catch ex As Exception
    '        errorProcess()
    '    End Try
    '    Cursor = Cursors.Default
    'End Sub

    'Private Sub NBBilling_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBBilling.LinkClicked
    '    Cursor = Cursors.WaitCursor
    '    Try
    '        FormBilling.MdiParent = Me
    '        FormBilling.Show()
    '        FormBilling.WindowState = FormWindowState.Maximized
    '        FormBilling.Focus()
    '    Catch ex As Exception
    '        errorProcess()
    '    End Try
    '    Cursor = Cursors.Default
    'End Sub

    Private Sub NBAdjQC_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAdjQC.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormProdQCAdj.MdiParent = Me
            FormProdQCAdj.Show()
            FormProdQCAdj.WindowState = FormWindowState.Maximized
            FormProdQCAdj.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGSOReff_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGSOReff.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGSalesOrderReff.MdiParent = Me
            FormFGSalesOrderReff.Show()
            FormFGSalesOrderReff.WindowState = FormWindowState.Maximized
            FormFGSalesOrderReff.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NavBarItem1_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesOrderList.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesOrderList.MdiParent = Me
            FormSalesOrderList.Show()
            FormSalesOrderList.WindowState = FormWindowState.Maximized
            FormSalesOrderList.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGTrfNew_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGTrfNew.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGTrfNew.MdiParent = Me
            FormFGTrfNew.Show()
            FormFGTrfNew.WindowState = FormWindowState.Maximized
            FormFGTrfNew.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub BBToggleMenu_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBToggleMenu.ItemClick
        If PCMenu.Visible = False Then
            PCMenu.Visible = True
        Else
            PCMenu.Visible = False
        End If
    End Sub

    Private Sub TESearchNavbar_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TESearchNavbar.EditValueChanged
        For Each group As DevExpress.XtraNavBar.NavBarGroup In NBProdRet.Groups
            For Each link As DevExpress.XtraNavBar.NavBarItemLink In group.ItemLinks
                If link.Enabled = True Then
                    link.Visible = link.Caption.ToLower.Contains(TESearchNavbar.Text.ToLower)
                    If group.VisibleItemLinks.Count = 0 Then
                        group.Visible = False
                    Else
                        group.Visible = True
                    End If
                End If
            Next link
        Next group
    End Sub

    Private Sub NBSalesPromo_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesPromo.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesPromo.MdiParent = Me
            FormSalesPromo.Show()
            FormSalesPromo.WindowState = FormWindowState.Maximized
            FormSalesPromo.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub TESearchNavbar_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TESearchNavbar.KeyUp

    End Sub

    Private Sub BBGuide_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBGuide.ItemClick
        Cursor = Cursors.WaitCursor
        Try
            FormGuide.MdiParent = Me
            FormGuide.Show()
            FormGuide.WindowState = FormWindowState.Maximized
            FormGuide.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBComputer_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBComputer.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterComputer.MdiParent = Me
            FormMasterComputer.Show()
            FormMasterComputer.WindowState = FormWindowState.Maximized
            FormMasterComputer.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        about()
    End Sub

    Private Sub BBNotif_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBNotif.ItemClick
        Cursor = Cursors.WaitCursor
        Try
            FormNotification.MdiParent = Me
            FormNotification.Show()
            FormNotification.WindowState = FormWindowState.Maximized
            FormNotification.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBScanEFactur_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBScanEFactur.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormAccountingFakturScan.MdiParent = Me
            FormAccountingFakturScan.Show()
            FormAccountingFakturScan.WindowState = FormWindowState.Maximized
            FormAccountingFakturScan.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBBorrowQCRec_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBBorrowQCRec.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGBorrowQCReq.MdiParent = Me
            FormFGBorrowQCReq.Show()
            FormFGBorrowQCReq.WindowState = FormWindowState.Maximized
            FormFGBorrowQCReq.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    'season non merch
    Private Sub NBSeasonNonMerch_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSeasonNonMerch.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSeason.is_md = "2"
            FormSeason.MdiParent = Me
            FormSeason.Show()
            FormSeason.WindowState = FormWindowState.Maximized
            FormSeason.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBLineListNonMerch_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBLineListNonMerch.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGLineList.MdiParent = Me
            FormFGLineList.id_pop_up = "3"
            FormFGLineList.Show()
            FormFGLineList.WindowState = FormWindowState.Maximized
            FormFGLineList.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSalesOrderCat_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesOrderCat.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesOrderCat.MdiParent = Me
            FormSalesOrderCat.Show()
            FormSalesOrderCat.WindowState = FormWindowState.Maximized
            FormSalesOrderCat.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAWB_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAWB.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormWHAWBill.MdiParent = Me
            FormWHAWBill.Show()
            FormWHAWBill.WindowState = FormWindowState.Maximized
            FormWHAWBill.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBCargoRate_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCargoRate.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormWHCargoRate.MdiParent = Me
            FormWHCargoRate.Show()
            FormWHCargoRate.WindowState = FormWindowState.Maximized
            FormWHCargoRate.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSalesOrderSvcLevel_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesOrderSvcLevel.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesOrderSvcLevel.MdiParent = Me
            FormSalesOrderSvcLevel.Show()
            FormSalesOrderSvcLevel.WindowState = FormWindowState.Maximized
            FormSalesOrderSvcLevel.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMasterPrice_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMasterPrice.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterPrice.MdiParent = Me
            FormMasterPrice.Show()
            FormMasterPrice.WindowState = FormWindowState.Maximized
            FormMasterPrice.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBImportDO_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBImportDO.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormWHImportDO.MdiParent = Me
            FormWHImportDO.Show()
            FormWHImportDO.WindowState = FormWindowState.Maximized
            FormWHImportDO.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBDesignLineList_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBDesignLineList.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGDesignList.MdiParent = Me
            FormFGDesignList.Show()
            FormFGDesignList.WindowState = FormWindowState.Maximized
            FormFGDesignList.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBWHSvcLevel_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBWHSvcLevel.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormWHSvcLevel.MdiParent = Me
            FormWHSvcLevel.Show()
            FormWHSvcLevel.WindowState = FormWindowState.Maximized
            FormWHSvcLevel.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBTestBC_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBTestBC.LinkClicked
        barcodeaa.ShowDialog()
    End Sub

    Private Sub NBSamplePL_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSamplePL.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSamplePLToWH.MdiParent = Me
            FormSamplePLToWH.Show()
            FormSamplePLToWH.WindowState = FormWindowState.Maximized
            FormSamplePLToWH.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMasterSamplePrice_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMasterSamplePrice.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterPriceSample.MdiParent = Me
            FormMasterPriceSample.Show()
            FormMasterPriceSample.WindowState = FormWindowState.Maximized
            FormMasterPriceSample.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSamplePriceRet_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSamplePriceRet.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSamplePLExport.MdiParent = Me
            FormSamplePLExport.Show()
            FormSamplePLExport.WindowState = FormWindowState.Maximized
            FormSamplePLExport.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGWHAlloc_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGWHAlloc.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGWHAlloc.MdiParent = Me
            FormFGWHAlloc.Show()
            FormFGWHAlloc.WindowState = FormWindowState.Maximized
            FormFGWHAlloc.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    Private Sub NBProdWO_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProdWO.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormProductionWOList.MdiParent = Me
            FormProductionWOList.Show()
            FormProductionWOList.WindowState = FormWindowState.Maximized
            FormProductionWOList.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGWHAllocLog_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGWHAllocLog.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGWHAllocLog.MdiParent = Me
            FormFGWHAllocLog.Show()
            FormFGWHAllocLog.WindowState = FormWindowState.Maximized
            FormFGWHAllocLog.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBStockQC_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBStockQC.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormStockQC.MdiParent = Me
            FormStockQC.Show()
            FormStockQC.WindowState = FormWindowState.Maximized
            FormStockQC.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    Private Sub NBSamplePLRet_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSamplePLRet.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleReturnPL.MdiParent = Me
            FormSampleReturnPL.Show()
            FormSampleReturnPL.WindowState = FormWindowState.Maximized
            FormSampleReturnPL.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBDesignListApp_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBDesignListApp.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGDesignList.MdiParent = Me
            FormFGDesignList.id_pop_up = "1"
            FormFGDesignList.Show()
            FormFGDesignList.WindowState = FormWindowState.Maximized
            FormFGDesignList.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBInitializeFP_LinkClicked_1(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBInitializeFP.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpInitialize.MdiParent = Me
            FormEmpInitialize.Show()
            FormEmpInitialize.WindowState = FormWindowState.Maximized
            FormEmpInitialize.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub


    Private Sub NBShift_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBShift.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpShift.MdiParent = Me
            FormEmpShift.Show()
            FormEmpShift.WindowState = FormWindowState.Maximized
            FormEmpShift.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub


    Private Sub NBFPSetup_LinkClicked_1(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFPSetup.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpFP.MdiParent = Me
            FormEmpFP.Show()
            FormEmpFP.WindowState = FormWindowState.Maximized
            FormEmpFP.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBHoliday_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBHoliday.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpHoliday.MdiParent = Me
            FormEmpHoliday.Show()
            FormEmpHoliday.WindowState = FormWindowState.Maximized
            FormEmpHoliday.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSchedule_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSchedule.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpSchedule.MdiParent = Me
            FormEmpSchedule.Show()
            FormEmpSchedule.WindowState = FormWindowState.Maximized
            FormEmpSchedule.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAttnInd_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAttnInd.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpAttnInd.MdiParent = Me
            FormEmpAttnInd.Show()
            FormEmpAttnInd.WindowState = FormWindowState.Maximized
            FormEmpAttnInd.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAttnSum_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAttnSum.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpAttnSum.MdiParent = Me
            FormEmpAttnSum.Show()
            FormEmpAttnSum.WindowState = FormWindowState.Maximized
            FormEmpAttnSum.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBEmpReview_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBEmpReview.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpReview.MdiParent = Me
            FormEmpReview.Show()
            FormEmpReview.WindowState = FormWindowState.Maximized
            FormEmpReview.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAttnLog_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAttnLog.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpAttn.MdiParent = Me
            FormEmpAttn.Show()
            FormEmpAttn.WindowState = FormWindowState.Maximized
            FormEmpAttn.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGRepair_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGRepair.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGRepair.MdiParent = Me
            FormFGRepair.Show()
            FormFGRepair.WindowState = FormWindowState.Maximized
            FormFGRepair.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGRepairRec_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGRepairRec.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGRepairRec.MdiParent = Me
            FormFGRepairRec.Show()
            FormFGRepairRec.WindowState = FormWindowState.Maximized
            FormFGRepairRec.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGRepairReturn_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGRepairReturn.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGRepairReturn.Dispose()
        Catch ex As Exception
        End Try
        Try
            FormFGRepairReturn.MdiParent = Me
            FormFGRepairReturn.Show()
            FormFGRepairReturn.WindowState = FormWindowState.Maximized
            FormFGRepairReturn.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGRepairReturnRec_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGRepairReturnRec.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGRepairReturnRec.MdiParent = Me
            FormFGRepairReturnRec.Show()
            FormFGRepairReturnRec.WindowState = FormWindowState.Maximized
            FormFGRepairReturnRec.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAttnSumDept_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAttnSumDept.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpAttnSum.MdiParent = Me
            FormEmpAttnSum.view_one_dept = True
            FormEmpAttnSum.Show()
            FormEmpAttnSum.WindowState = FormWindowState.Maximized
            FormEmpAttnSum.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBEmpEmail_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBEmpEmail.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpEmail.MdiParent = Me
            FormEmpEmail.Show()
            FormEmpEmail.WindowState = FormWindowState.Maximized
            FormEmpEmail.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBEmpLeave_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBEmpLeave.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpLeave.is_propose = "-1"
            FormEmpLeave.is_hrd = "1"
            FormEmpLeave.MdiParent = Me
            FormEmpLeave.Show()
            FormEmpLeave.WindowState = FormWindowState.Maximized
            FormEmpLeave.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBScheduleSecurity_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBScheduleSecurity.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpSchedule.is_security = "1"
            FormEmpSchedule.MdiParent = Me
            FormEmpSchedule.Show()
            FormEmpSchedule.WindowState = FormWindowState.Maximized
            FormEmpSchedule.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBLeavePropose_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBLeavePropose.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpLeave.is_propose = "1"
            FormEmpLeave.MdiParent = Me
            FormEmpLeave.Show()
            FormEmpLeave.WindowState = FormWindowState.Maximized
            FormEmpLeave.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBEmpLeaveRemaining_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBEmpLeaveRemaining.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpLeaveStock.MdiParent = Me
            FormEmpLeaveStock.Show()
            FormEmpLeaveStock.WindowState = FormWindowState.Maximized
            FormEmpLeaveStock.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBDP_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBDP.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpDP.MdiParent = Me
            FormEmpDP.Show()
            FormEmpDP.WindowState = FormWindowState.Maximized
            FormEmpDP.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub FormMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim confirm As DialogResult = XtraMessageBox.Show("Are you sure want to close application?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = DialogResult.Yes Then
            'log
            Try
                Dim u As New ClassUser()
                u.logLogin("2")
            Catch ex As Exception
            End Try
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub NBChSchedule_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBChSchedule.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpChSchedule.MdiParent = Me
            FormEmpChSchedule.Show()
            FormEmpChSchedule.WindowState = FormWindowState.Maximized
            FormEmpChSchedule.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSchedulePropose_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSchedulePropose.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpAttnAssign.MdiParent = Me
            FormEmpAttnAssign.Show()
            FormEmpAttnAssign.WindowState = FormWindowState.Maximized
            FormEmpAttnAssign.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBProdReport_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProdReport.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormProductionSummary.MdiParent = Me
            FormProductionSummary.Show()
            FormProductionSummary.WindowState = FormWindowState.Maximized
            FormProductionSummary.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAttnStore_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAttnStore.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpAttnSum.MdiParent = Me
            FormEmpAttnSum.view_store = True
            FormEmpAttnSum.Show()
            FormEmpAttnSum.WindowState = FormWindowState.Maximized
            FormEmpAttnSum.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSpecialReceiving_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSpecialReceiving.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormProductionSpecialRec.MdiParent = Me
            FormProductionSpecialRec.Show()
            FormProductionSpecialRec.WindowState = FormWindowState.Maximized
            FormProductionSpecialRec.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFinalClear_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFinalClear.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormProductionFinalClear.MdiParent = Me
            FormProductionFinalClear.Show()
            FormProductionFinalClear.WindowState = FormWindowState.Maximized
            FormProductionFinalClear.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSchCompare_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSchCompare.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpStoreSchCompare.MdiParent = Me
            FormEmpStoreSchCompare.Show()
            FormEmpStoreSchCompare.WindowState = FormWindowState.Maximized
            FormEmpStoreSchCompare.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBDutyReport_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBDutyReport.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormProdDuty.MdiParent = Me
            FormProdDuty.Show()
            FormProdDuty.WindowState = FormWindowState.Maximized
            FormProdDuty.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBCloseFGPO_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCloseFGPO.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormProdClosing.Close()
            FormProdClosing.Dispose()
        Catch ex As Exception
        End Try
        Try
            FormProdClosing.MdiParent = Me
            FormProdClosing.Show()
            FormProdClosing.WindowState = FormWindowState.Maximized
            FormProdClosing.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSampleSum_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSampleSum.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleSummary.MdiParent = Me
            FormSampleSummary.Show()
            FormSampleSummary.WindowState = FormWindowState.Maximized
            FormSampleSummary.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBProdAss_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProdAss.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormProductionAssembly.MdiParent = Me
            FormProductionAssembly.Show()
            FormProductionAssembly.WindowState = FormWindowState.Maximized
            FormProductionAssembly.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBTransList_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBTransList.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGTransList.MdiParent = Me
            FormFGTransList.Show()
            FormFGTransList.WindowState = FormWindowState.Maximized
            FormFGTransList.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBRateCargo_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBRateCargo.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterCargoRate.MdiParent = Me
            FormMasterCargoRate.Show()
            FormMasterCargoRate.WindowState = FormWindowState.Maximized
            FormMasterCargoRate.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBDelEmpty_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBDelEmpty.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormWHDelEmpty.MdiParent = Me
            FormWHDelEmpty.Show()
            FormWHDelEmpty.WindowState = FormWindowState.Maximized
            FormWHDelEmpty.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBNonStockInv_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBNonStockInv.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormWHDelEmptyStock.MdiParent = Me
            FormWHDelEmptyStock.Show()
            FormWHDelEmptyStock.WindowState = FormWindowState.Maximized
            FormWHDelEmptyStock.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAwbill_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAwbill.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormDeliveryCargo.MdiParent = Me
            FormDeliveryCargo.Show()
            FormDeliveryCargo.WindowState = FormWindowState.Maximized
            FormDeliveryCargo.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub


    Private Sub NBEmpUniPeriod_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBEmpUniPeriod.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpUniPeriod.MdiParent = Me
            FormEmpUniPeriod.Show()
            FormEmpUniPeriod.WindowState = FormWindowState.Maximized
            FormEmpUniPeriod.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBRateManagement_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBRateManagement.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterRate.ShowDialog()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBPrepareOrderUni_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPrepareOrderUni.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpUniList.MdiParent = Me
            FormEmpUniList.Show()
            FormEmpUniList.WindowState = FormWindowState.Maximized
            FormEmpUniList.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSubDept_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSubDept.LinkClicked
        Try
            FormDepartementSub.MdiParent = Me
            FormDepartementSub.Show()
            FormDepartementSub.WindowState = FormWindowState.Maximized
            FormDepartementSub.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBCloseRecQC_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCloseRecQC.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormProdClosing.Close()
            FormProdClosing.Dispose()
        Catch ex As Exception
        End Try
        Try
            FormProdClosing.MdiParent = Me
            FormProdClosing.id_pop_up = "1"
            FormProdClosing.Show()
            FormProdClosing.WindowState = FormWindowState.Maximized
            FormProdClosing.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBClaimFGPO_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBClaimFGPO.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormProdClosing.Close()
            FormProdClosing.Dispose()
        Catch ex As Exception
        End Try
        Try
            FormProdClosing.MdiParent = Me
            FormProdClosing.id_pop_up = "2"
            FormProdClosing.Show()
            FormProdClosing.WindowState = FormWindowState.Maximized
            FormProdClosing.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBInvoiceStaff_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBInvoiceStaff.LinkClicked
        'invoice missing staff
        Cursor = Cursors.WaitCursor
        Try
            FormSalesPOS.Close()
            FormSalesPOS.Dispose()
        Catch ex As Exception
        End Try
        Try
            FormSalesPOS.MdiParent = Me
            FormSalesPOS.id_menu = "4"
            FormSalesPOS.Show()
            FormSalesPOS.WindowState = FormWindowState.Maximized
            FormSalesPOS.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBCreditNoteOLStore_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCreditNoteOLStore.LinkClicked
        'cn onlince store
        Cursor = Cursors.WaitCursor
        Try
            FormSalesPOS.Close()
            FormSalesPOS.Dispose()
        Catch ex As Exception
        End Try
        Try
            FormSalesPOS.MdiParent = Me
            FormSalesPOS.id_menu = "5"
            FormSalesPOS.Show()
            FormSalesPOS.WindowState = FormWindowState.Maximized
            FormSalesPOS.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBROOLStore_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesReturnOrderOL.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesReturnOrderOL.MdiParent = Me
            FormSalesReturnOrderOL.Show()
            FormSalesReturnOrderOL.WindowState = FormWindowState.Maximized
            FormSalesReturnOrderOL.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBOLStoreReport_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBOLStoreReport.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormOLStoreSummary.MdiParent = Me
            FormOLStoreSummary.Show()
            FormOLStoreSummary.WindowState = FormWindowState.Maximized
            FormOLStoreSummary.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBPromoTrf_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPromoTrf.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGTrfPromo.MdiParent = Me
            FormFGTrfPromo.Show()
            FormFGTrfPromo.WindowState = FormWindowState.Maximized
            FormFGTrfPromo.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAgingFG_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAgingFG.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGAging.Close()
            FormFGAging.Dispose()
        Catch ex As Exception
        End Try
        Try
            FormFGAging.MdiParent = Me
            FormFGAging.Show()
            FormFGAging.WindowState = FormWindowState.Maximized
            FormFGAging.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAgingFGReport_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAgingFGReport.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGAging.Close()
            FormFGAging.Dispose()
        Catch ex As Exception
        End Try
        Try
            FormFGAging.MdiParent = Me
            FormFGAging.is_view = "1"
            FormFGAging.Show()
            FormFGAging.WindowState = FormWindowState.Maximized
            FormFGAging.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    Private Sub NBProdDebitNote_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProdDebitNote.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormProdDebitNote.MdiParent = Me
            FormProdDebitNote.Show()
            FormProdDebitNote.WindowState = FormWindowState.Maximized
            FormProdDebitNote.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBTransSum_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBTransSum.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGTransSummary.MdiParent = Me
            FormFGTransSummary.Show()
            FormFGTransSummary.WindowState = FormWindowState.Maximized
            FormFGTransSummary.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBCodeReplacementPrint_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCodeReplacementPrint.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGCodeReplace.form_type = "2"
            FormFGCodeReplace.MdiParent = Me
            FormFGCodeReplace.Show()
            FormFGCodeReplace.WindowState = FormWindowState.Maximized
            FormFGCodeReplace.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBCodeReplacementVerify_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCodeReplacementVerify.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGCodeReplace.form_type = "3"
            FormFGCodeReplace.MdiParent = Me
            FormFGCodeReplace.Show()
            FormFGCodeReplace.WindowState = FormWindowState.Maximized
            FormFGCodeReplace.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    Private Sub NBCargoRateView_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCargoRateView.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormWHCargoRate.is_view = "1"
            FormWHCargoRate.MdiParent = Me
            FormWHCargoRate.Show()
            FormWHCargoRate.WindowState = FormWindowState.Maximized
            FormWHCargoRate.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    Private Sub NBPayroll_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPayroll.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpPayroll.is_view = "2"
            FormEmpPayroll.MdiParent = Me
            FormEmpPayroll.Show()
            FormEmpPayroll.WindowState = FormWindowState.Maximized
            FormEmpPayroll.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFirstDel_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFirstDel.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGFirstDel.MdiParent = Me
            FormFGFirstDel.Show()
            FormFGFirstDel.WindowState = FormWindowState.Maximized
            FormFGFirstDel.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBCompareStockCard_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCompareStockCard.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGCompareStockCard.MdiParent = Me
            FormFGCompareStockCard.Show()
            FormFGCompareStockCard.WindowState = FormWindowState.Maximized
            FormFGCompareStockCard.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBLeaveCut_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBLeaveCut.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpLeaveCut.MdiParent = Me
            FormEmpLeaveCut.Show()
            FormEmpLeaveCut.WindowState = FormWindowState.Maximized
            FormEmpLeaveCut.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBProdOver_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProdOver.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormProdOverMemo.MdiParent = Me
            FormProdOverMemo.Show()
            FormProdOverMemo.WindowState = FormWindowState.Maximized
            FormProdOverMemo.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAssetCat_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAssetCat.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterAssetCategory.MdiParent = Me
            FormMasterAssetCategory.Show()
            FormMasterAssetCategory.WindowState = FormWindowState.Maximized
            FormMasterAssetCategory.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAsset_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAsset.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterAsset.MdiParent = Me
            FormMasterAsset.Show()
            FormMasterAsset.WindowState = FormWindowState.Maximized
            FormMasterAsset.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAssetPO_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAssetPO.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormAssetPO.MdiParent = Me
            FormAssetPO.Show()
            FormAssetPO.WindowState = FormWindowState.Maximized
            FormAssetPO.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAssetRec_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAssetRec.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormAssetRec.MdiParent = Me
            FormAssetRec.Show()
            FormAssetRec.WindowState = FormWindowState.Maximized
            FormAssetRec.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Public id_period_uniform_sel As String = ""
    Private Sub NBGUniformPublic_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBGUniformPublic.LinkClicked
        Cursor = Cursors.WaitCursor

        Dim qp As String = "SELECT p.* FROM tb_emp_uni_period p WHERE p.id_status=1  "
        Dim dp As DataTable = execute_query(qp, -1, True, "", "", "", "")

        Dim uni As New ClassEmpUni()
        If dp.Rows.Count = 1 Then
            uni.openUniformPublic(dp.Rows(0)("id_emp_uni_period").ToString)
        ElseIf dp.Rows.Count > 1 Then
            FormEmpUniPeriodSelect.data = dp
            FormEmpUniPeriodSelect.id_pop_up = "1"
            FormEmpUniPeriodSelect.ShowDialog()
            If id_period_uniform_sel <> "" Then
                uni.openUniformPublic(id_period_uniform_sel)
                id_period_uniform_sel = ""
            End If
        Else
            stopCustom("Periode uniform belum dimulai")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub NBGUniformAdmin_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBGUniformAdmin.LinkClicked
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT p.* FROM tb_emp_uni_period p WHERE p.id_status=1  "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Dim id_periode As String = "-1"
        Try
            id_periode = data.Rows(0)("id_emp_uni_period").ToString
        Catch ex As Exception
        End Try
        If id_periode = "" Then
            id_periode = "-1"
        End If

        If data.Rows.Count = 1 Then
            Try
                FormEmpUniPeriodDet.MdiParent = Me
                FormEmpUniPeriodDet.action = "upd"
                FormEmpUniPeriodDet.id_emp_uni_period = id_periode
                FormEmpUniPeriodDet.is_public_form = True
                FormEmpUniPeriodDet.Show()
                FormEmpUniPeriodDet.WindowState = FormWindowState.Maximized
                FormEmpUniPeriodDet.Focus()
            Catch ex As Exception
                errorProcess()
            End Try
        ElseIf data.Rows.Count > 1 Then
            'jika ada lebih dari satu periode
            FormEmpUniPeriodSelect.data = data
            FormEmpUniPeriodSelect.ShowDialog()
        Else
            stopCustom("Periode uniform belum dimulai")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub NBEmpNorm_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBEmpNorm.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterEmployee.is_salary = "1"
            FormMasterEmployee.MdiParent = Me
            FormMasterEmployee.Show()
            FormMasterEmployee.WindowState = FormWindowState.Maximized
            FormMasterEmployee.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBUniformReport_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBUniformReport.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpUniReport.MdiParent = Me
            FormEmpUniReport.Show()
            FormEmpUniReport.WindowState = FormWindowState.Maximized
            FormEmpUniReport.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBProductForBOF_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProductForBOF.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterProductForBOF.MdiParent = Me
            FormMasterProductForBOF.Show()
            FormMasterProductForBOF.WindowState = FormWindowState.Maximized
            FormMasterProductForBOF.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSalesTracking_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesTracking.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesReportTracking.MdiParent = Me
            FormSalesReportTracking.Show()
            FormSalesReportTracking.WindowState = FormWindowState.Maximized
            FormSalesReportTracking.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBUniformExpense_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBUniformExpense.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpUniExpense.MdiParent = Me
            FormEmpUniExpense.Show()
            FormEmpUniExpense.WindowState = FormWindowState.Maximized
            FormEmpUniExpense.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBWHAwbillLock_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBWHAwbillLock.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormWHAWBill.MdiParent = Me
            FormWHAWBill.is_lock = "1"
            FormWHAWBill.Show()
            FormWHAWBill.WindowState = FormWindowState.Maximized
            FormWHAWBill.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBRevenueBudget_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBRevenueBudget.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormBudgetRevPropose.MdiParent = Me
            FormBudgetRevPropose.Show()
            FormBudgetRevPropose.WindowState = FormWindowState.Maximized
            FormBudgetRevPropose.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBRevenue_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBRevenue.LinkClicked

    End Sub

    Private Sub NBItemList_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBItemList.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormPurcItem.MdiParent = Me
            FormPurcItem.Show()
            FormPurcItem.WindowState = FormWindowState.Maximized
            FormPurcItem.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBItemCat_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBItemCat.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormItemCatPropose.MdiParent = Me
            FormItemCatPropose.Show()
            FormItemCatPropose.WindowState = FormWindowState.Maximized
            FormItemCatPropose.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMappingCat_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMappingCat.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormItemCatMapping.MdiParent = Me
            FormItemCatMapping.Show()
            FormItemCatMapping.WindowState = FormWindowState.Maximized
            FormItemCatMapping.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBPurcReq_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPurcReq.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormPurcReq.MdiParent = Me
            FormPurcReq.Show()
            FormPurcReq.WindowState = FormWindowState.Maximized
            FormPurcReq.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBProposeExpenseBudget_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProposeExpenseBudget.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormBudgetExpensePropose.MdiParent = Me
            FormBudgetExpensePropose.Show()
            FormBudgetExpensePropose.WindowState = FormWindowState.Maximized
            FormBudgetExpensePropose.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBExpenseBudget_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBExpenseBudget.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormBudgetExpenseView.MdiParent = Me
            FormBudgetExpenseView.Show()
            FormBudgetExpenseView.WindowState = FormWindowState.Maximized
            FormBudgetExpenseView.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBRevisionExpenseBudget_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBRevisionExpenseBudget.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormBudgetExpenseRevision.MdiParent = Me
            FormBudgetExpenseRevision.Show()
            FormBudgetExpenseRevision.WindowState = FormWindowState.Maximized
            FormBudgetExpenseRevision.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBPurcReqAdmin_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPurcReqAdmin.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormPurcReq.MdiParent = Me
            FormPurcReq.is_purc_dep = "1"
            FormPurcReq.Show()
            FormPurcReq.WindowState = FormWindowState.Maximized
            FormPurcReq.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBPurcOrder_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPurcOrder.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormPurcOrder.MdiParent = Me
            FormPurcOrder.Show()
            FormPurcOrder.WindowState = FormWindowState.Maximized
            FormPurcOrder.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBRepairProductToVendor_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBRepairProductToVendor.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGRepair.MdiParent = Me
            FormFGRepair.is_to_vendor = True
            FormFGRepair.Show()
            FormFGRepair.WindowState = FormWindowState.Maximized
            FormFGRepair.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBRecRepairFromVendor_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBRecRepairFromVendor.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGRepairReturn.Dispose()
        Catch ex As Exception
        End Try
        Try
            FormFGRepairReturn.MdiParent = Me
            FormFGRepairReturn.is_from_vendor = True
            FormFGRepairReturn.Show()
            FormFGRepairReturn.WindowState = FormWindowState.Maximized
            FormFGRepairReturn.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    Private Sub NBAttnIndDep_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAttnIndDep.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpAttnInd.MdiParent = Me
            FormEmpAttnInd.is_dep = True
            FormEmpAttnInd.Show()
            FormEmpAttnInd.WindowState = FormWindowState.Maximized
            FormEmpAttnInd.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBPDRef_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPDRef.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormProdDemandRev.MdiParent = Me
            FormProdDemandRev.Show()
            FormProdDemandRev.WindowState = FormWindowState.Maximized
            FormProdDemandRev.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBCancelForm_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCancelForm.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormReportMarkCancelList.MdiParent = Me
            FormReportMarkCancelList.is_admin = "-1"
            FormReportMarkCancelList.Show()
            FormReportMarkCancelList.WindowState = FormWindowState.Maximized
            FormReportMarkCancelList.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBCancelFormAdmin_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCancelFormAdmin.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormReportMarkCancelList.MdiParent = Me
            FormReportMarkCancelList.is_admin = "1"
            FormReportMarkCancelList.Show()
            FormReportMarkCancelList.WindowState = FormWindowState.Maximized
            FormReportMarkCancelList.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBPurcReceiveNonAsset_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPurcReceiveNonAsset.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormPurcReceive.MdiParent = Me
            FormPurcReceive.Show()
            FormPurcReceive.WindowState = FormWindowState.Maximized
            FormPurcReceive.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBItemStock_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBItemStock.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormPurcItemStock.MdiParent = Me
            FormPurcItemStock.Show()
            FormPurcItemStock.WindowState = FormWindowState.Maximized
            FormPurcItemStock.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBPurcReturn_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPurcReturn.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormPurcReturn.MdiParent = Me
            FormPurcReturn.Show()
            FormPurcReturn.WindowState = FormWindowState.Maximized
            FormPurcReturn.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBEmpUniSummary_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBEmpUniSummary.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpUniSumReport.MdiParent = Me
            FormEmpUniSumReport.Show()
            FormEmpUniSumReport.WindowState = FormWindowState.Maximized
            FormEmpUniSumReport.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBClaimReturn_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBClaimReturn.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormProductionClaimReturn.MdiParent = Me
            FormProductionClaimReturn.Show()
            FormProductionClaimReturn.WindowState = FormWindowState.Maximized
            FormProductionClaimReturn.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBItemRequest_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBItemRequest.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormItemReq.Close()
            FormItemReq.Dispose()
        Catch ex As Exception
        End Try

        Try
            FormItemReq.MdiParent = Me
            FormItemReq.Show()
            FormItemReq.WindowState = FormWindowState.Maximized
            FormItemReq.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBItemDel_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBItemDel.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormItemDel.MdiParent = Me
            FormItemDel.Show()
            FormItemDel.WindowState = FormWindowState.Maximized
            FormItemDel.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBPurcPayment_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPurcPayment.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormPurcPayment.MdiParent = Me
            FormPurcPayment.Show()
            FormPurcPayment.WindowState = FormWindowState.Maximized
            FormPurcPayment.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBItemExpense_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBItemExpense.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormItemExpense.MdiParent = Me
            FormItemExpense.Show()
            FormItemExpense.WindowState = FormWindowState.Maximized
            FormItemExpense.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBBankWithdrawal_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBBankWithdrawal.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormBankWithdrawal.MdiParent = Me
            FormBankWithdrawal.Show()
            FormBankWithdrawal.WindowState = FormWindowState.Maximized
            FormBankWithdrawal.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAssetManagement_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAssetManagement.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormPurcAsset.MdiParent = Me
            FormPurcAsset.Show()
            FormPurcAsset.WindowState = FormWindowState.Maximized
            FormPurcAsset.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBBankDeposit_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBBankDeposit.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormBankDeposit.MdiParent = Me
            FormBankDeposit.Show()
            FormBankDeposit.WindowState = FormWindowState.Maximized
            FormBankDeposit.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBItemRequestForStore_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBItemRequestForStore.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormItemReq.Close()
            FormItemReq.Dispose()
        Catch ex As Exception
        End Try

        Try
            FormItemReq.MdiParent = Me
            FormItemReq.is_for_store = "1"
            FormItemReq.Show()
            FormItemReq.WindowState = FormWindowState.Maximized
            FormItemReq.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSalesReturnRec_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesReturnRec.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesReturnRec.MdiParent = Me
            FormSalesReturnRec.Show()
            FormSalesReturnRec.WindowState = FormWindowState.Maximized
            FormSalesReturnRec.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBCashAdvance_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCashAdvance.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormCashAdvance.MdiParent = Me
            FormCashAdvance.Show()
            FormCashAdvance.WindowState = FormWindowState.Maximized
            FormCashAdvance.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBOpt_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBOpt.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormOpt.MdiParent = Me
            FormOpt.Show()
            FormOpt.WindowState = FormWindowState.Maximized
            FormOpt.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBEmpPerAppraisal_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBEmpPerAppraisal.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpPerAppraisal.MdiParent = Me
            FormEmpPerAppraisal.is_hrd = "1"
            FormEmpPerAppraisal.Show()
            FormEmpPerAppraisal.WindowState = FormWindowState.Maximized
            FormEmpPerAppraisal.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBEmpPerAppraisalDep_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBEmpPerAppraisalDep.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpPerAppraisal.MdiParent = Me
            FormEmpPerAppraisal.is_dephead = "1"
            FormEmpPerAppraisal.Show()
            FormEmpPerAppraisal.WindowState = FormWindowState.Maximized
            FormEmpPerAppraisal.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBDeptHeadSurvey_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBDeptHeadSurvey.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            Dim id_period As Integer = Convert.ToInt32(execute_query("SELECT IFNULL((SELECT id_question_depthead_period FROM tb_question_depthead_period WHERE `status` = 1 AND CURDATE() >= from_period AND CURDATE() <= until_period LIMIT 1), 0) AS id_question_depthead_period", 0, True, "", "", "", ""))

            If id_period = 0 Then
                stopCustom("Tidak sedang dalam periode survey.")
            Else
                FormDeptHeadSurvey.MdiParent = Me
                FormDeptHeadSurvey.Show()
                FormDeptHeadSurvey.WindowState = FormWindowState.Maximized
                FormDeptHeadSurvey.Focus()
            End If
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBDeptHeadSurveyHRD_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBDeptHeadSurveyHRD.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormDeptHeadSurvey.MdiParent = Me
            FormDeptHeadSurvey.is_hrd = "1"
            FormDeptHeadSurvey.Show()
            FormDeptHeadSurvey.WindowState = FormWindowState.Maximized
            FormDeptHeadSurvey.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBKursTrans_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBKursTrans.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSetKurs.MdiParent = Me
            FormSetKurs.Show()
            FormSetKurs.WindowState = FormWindowState.Maximized
            FormSetKurs.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBProposeExpenseBudgetAdmin_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProposeExpenseBudgetAdmin.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormBudgetExpensePropose.Close()
            FormBudgetExpensePropose.Dispose()
        Catch ex As Exception
        End Try
        Try
            FormBudgetExpensePropose.MdiParent = Me
            FormBudgetExpensePropose.is_admin = "1"
            FormBudgetExpensePropose.Show()
            FormBudgetExpensePropose.WindowState = FormWindowState.Maximized
            FormBudgetExpensePropose.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBRevExpenseBudgetAdmin_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBRevExpenseBudgetAdmin.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormBudgetExpenseRevision.Close()
            FormBudgetExpenseRevision.Dispose()
        Catch ex As Exception
        End Try
        Try
            FormBudgetExpenseRevision.MdiParent = Me
            FormBudgetExpenseRevision.is_admin = "1"
            FormBudgetExpenseRevision.Show()
            FormBudgetExpenseRevision.WindowState = FormWindowState.Maximized
            FormBudgetExpenseRevision.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSampleBudget_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSampleBudget.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleBudget.MdiParent = Me
            FormSampleBudget.Show()
            FormSampleBudget.WindowState = FormWindowState.Maximized
            FormSampleBudget.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBOLStoreWork_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBOLStoreWork.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormOLStore.MdiParent = Me
            FormOLStore.Show()
            FormOLStore.WindowState = FormWindowState.Maximized
            FormOLStore.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBVerifyMaster_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBVerifyMaster.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormVerifyMaster.MdiParent = Me
            FormVerifyMaster.Show()
            FormVerifyMaster.WindowState = FormWindowState.Maximized
            FormVerifyMaster.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSamplePOMat_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSamplePOMat.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleExpense.MdiParent = Me
            FormSampleExpense.Show()
            FormSampleExpense.WindowState = FormWindowState.Maximized
            FormSampleExpense.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBProposeEmp_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProposeEmp.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmloyeePps.MdiParent = Me
            FormEmloyeePps.show_payroll = False
            FormEmloyeePps.Show()
            FormEmloyeePps.WindowState = FormWindowState.Maximized
            FormEmloyeePps.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSamplePurcClose_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSamplePurcClose.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSamplePurcClose.MdiParent = Me
            FormSamplePurcClose.Show()
            FormSamplePurcClose.WindowState = FormWindowState.Maximized
            FormSamplePurcClose.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBProposeEmpSal_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProposeEmpSal.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmloyeePps.MdiParent = Me
            FormEmloyeePps.show_payroll = True
            FormEmloyeePps.Show()
            FormEmloyeePps.WindowState = FormWindowState.Maximized
            FormEmloyeePps.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBEmpOvertime_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBEmpOvertime.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpOvertime.MdiParent = Me
            FormEmpOvertime.is_hrd = "1"
            FormEmpOvertime.Show()
            FormEmpOvertime.WindowState = FormWindowState.Maximized
            FormEmpOvertime.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBInvDiffMargin_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBInvDiffMargin.LinkClicked
        'invoice different margin
        Cursor = Cursors.WaitCursor
        Try
            FormSalesPOS.Close()
            FormSalesPOS.Dispose()
        Catch ex As Exception
        End Try
        Try
            FormSalesPOS.MdiParent = Me
            FormSalesPOS.id_menu = "6"
            FormSalesPOS.Show()
            FormSalesPOS.WindowState = FormWindowState.Maximized
            FormSalesPOS.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBInvoiceFGPO_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBInvoiceFGPO.LinkClicked
        'invoice FGPO
        Cursor = Cursors.WaitCursor
        Try
            FormInvoiceFGPO.MdiParent = Me
            FormInvoiceFGPO.Show()
            FormInvoiceFGPO.WindowState = FormWindowState.Maximized
            FormInvoiceFGPO.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBLinePlan_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBLinePlan.LinkClicked
        'line plan
        Cursor = Cursors.WaitCursor
        Try
            FormFGLinePlan.MdiParent = Me
            FormFGLinePlan.Show()
            FormFGLinePlan.WindowState = FormWindowState.Maximized
            FormFGLinePlan.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMTC_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMTC.LinkClicked
        'Work Order
        Cursor = Cursors.WaitCursor
        Try
            FormWorkOrder.MdiParent = Me
            FormWorkOrder.Show()
            FormWorkOrder.WindowState = FormWindowState.Maximized
            FormWorkOrder.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBLinePlanPublic_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBLinePlanPublic.LinkClicked
        'line plan
        Cursor = Cursors.WaitCursor
        Try
            FormFGLinePlan.Close()
            FormFGLinePlan.Dispose()
        Catch ex As Exception
        End Try
        Try
            FormFGLinePlan.MdiParent = Me
            FormFGLinePlan.is_view = "1"
            FormFGLinePlan.Show()
            FormFGLinePlan.WindowState = FormWindowState.Maximized
            FormFGLinePlan.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSalesTargetPropose_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesTargetPropose.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesTargetPropose.MdiParent = Me
            FormSalesTargetPropose.Show()
            FormSalesTargetPropose.WindowState = FormWindowState.Maximized
            FormSalesTargetPropose.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBEmpOvertimeDept_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBEmpOvertimeDept.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpOvertime.MdiParent = Me
            FormEmpOvertime.is_hrd = "-1"
            FormEmpOvertime.Show()
            FormEmpOvertime.WindowState = FormWindowState.Maximized
            FormEmpOvertime.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBWorkOrder_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBWorkOrder.LinkClicked
        'Work Order
        Cursor = Cursors.WaitCursor
        Try
            FormWorkOrder.MdiParent = Me
            FormWorkOrder.is_worker = "1"
            FormWorkOrder.Show()
            FormWorkOrder.WindowState = FormWindowState.Maximized
            FormWorkOrder.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBEstQtyToWH_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBEstQtyToWH.LinkClicked
        'Estimate Qty to WH
        Cursor = Cursors.WaitCursor
        Try
            FormReportEstWHInQty.MdiParent = Me
            FormReportEstWHInQty.Show()
            FormReportEstWHInQty.WindowState = FormWindowState.Maximized
            FormReportEstWHInQty.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBEstQtyToQC_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBEstQtyToQC.LinkClicked
        'Estimate Qty to WH
        Cursor = Cursors.WaitCursor
        Try
            FormReportEstWHInQty.MdiParent = Me
            FormReportEstWHInQty.is_qc = "1"
            FormReportEstWHInQty.Show()
            FormReportEstWHInQty.WindowState = FormWindowState.Maximized
            FormReportEstWHInQty.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBQCHOTarget_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBQCHOTarget.LinkClicked
        Cursor = Cursors.WaitCursor
        FormProductionRec.MdiParent = Me
        FormProductionRec.is_ho_target = "1"
        FormProductionRec.Show()
        FormProductionRec.WindowState = FormWindowState.Maximized
        FormProductionRec.Focus()
        Cursor = Cursors.Default
    End Sub

    Private Sub NBHandoverReport_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBHandoverReport.LinkClicked
        'Handover report
        Cursor = Cursors.WaitCursor
        Try
            FormProductionHO.Close()
            FormProductionHO.Dispose()
        Catch ex As Exception
        End Try

        Try
            FormProductionHO.MdiParent = Me
            FormProductionHO.Show()
            FormProductionHO.WindowState = FormWindowState.Maximized
            FormProductionHO.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBHandoverReportPublic_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBHandoverReportPublic.LinkClicked
        'Handover report
        Cursor = Cursors.WaitCursor
        Try
            FormProductionHO.Close()
            FormProductionHO.Dispose()
        Catch ex As Exception
        End Try

        Try
            FormProductionHO.MdiParent = Me
            FormProductionHO.is_public_form = True
            FormProductionHO.Show()
            FormProductionHO.WindowState = FormWindowState.Maximized
            FormProductionHO.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSalesOrderReport_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesOrderReport.LinkClicked
        ' compare prepare order
        Cursor = Cursors.WaitCursor
        Try
            FormSalesOrderReport.MdiParent = Me
            FormSalesOrderReport.Show()
            FormSalesOrderReport.WindowState = FormWindowState.Maximized
            FormSalesOrderReport.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBLinePlanProduction_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBLinePlanProduction.LinkClicked
        'line plan production   
        Cursor = Cursors.WaitCursor
        Try
            FormFGLinePlan.Close()
            FormFGLinePlan.Dispose()
        Catch ex As Exception
        End Try
        Try
            FormFGLinePlan.MdiParent = Me
            FormFGLinePlan.is_view = "1"
            FormFGLinePlan.id_pop_up = "1"
            FormFGLinePlan.Show()
            FormFGLinePlan.WindowState = FormWindowState.Maximized
            FormFGLinePlan.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBProposeEmpSalary_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProposeEmpSalary.LinkClicked
        'propose employee salary
        Cursor = Cursors.WaitCursor
        Try
            FormProposeEmpSalary.MdiParent = Me
            FormProposeEmpSalary.Show()
            FormProposeEmpSalary.WindowState = FormWindowState.Maximized
            FormProposeEmpSalary.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBItemSubCat_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBItemSubCat.LinkClicked
        'Sub Category/purchase category
        Cursor = Cursors.WaitCursor
        Try
            FormItemSubCat.MdiParent = Me
            FormItemSubCat.Show()
            FormItemSubCat.WindowState = FormWindowState.Maximized
            FormItemSubCat.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBItemSubCatAcc_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBItemSubCatAcc.LinkClicked
        'Sub Category/purchase category
        Cursor = Cursors.WaitCursor
        Try
            FormItemSubCat.MdiParent = Me
            FormItemSubCat.is_accounting = "1"
            FormItemSubCat.Show()
            FormItemSubCat.WindowState = FormWindowState.Maximized
            FormItemSubCat.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBPayrollApprove_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPayrollApprove.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpPayroll.is_view = "1"
            FormEmpPayroll.MdiParent = Me
            FormEmpPayroll.Show()
            FormEmpPayroll.WindowState = FormWindowState.Maximized
            FormEmpPayroll.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSetupBudgetOPEX_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSetupBudgetOPEX.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSetupBudgetOPEX.MdiParent = Me
            FormSetupBudgetOPEX.Show()
            FormSetupBudgetOPEX.WindowState = FormWindowState.Maximized
            FormSetupBudgetOPEX.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSampleDev_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSampleDev.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleDevelopment.MdiParent = Me
            FormSampleDevelopment.Show()
            FormSampleDevelopment.WindowState = FormWindowState.Maximized
            FormSampleDevelopment.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSetupItemMainCat_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSetupItemMainCat.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormItemCatMain.MdiParent = Me
            FormItemCatMain.Show()
            FormItemCatMain.WindowState = FormWindowState.Maximized
            FormItemCatMain.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSalesRecord_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesRecord.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesRecord.MdiParent = Me
            FormSalesRecord.Show()
            FormSalesRecord.WindowState = FormWindowState.Maximized
            FormSalesRecord.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSetupBudgetCAPEX_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSetupBudgetCAPEX.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSetupBudgetCAPEX.MdiParent = Me
            FormSetupBudgetCAPEX.Show()
            FormSetupBudgetCAPEX.WindowState = FormWindowState.Maximized
            FormSetupBudgetCAPEX.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAgingAR_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAgingAR.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormARAging.MdiParent = Me
            FormARAging.Show()
            FormARAging.WindowState = FormWindowState.Maximized
            FormARAging.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBReportBudget_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBReportBudget.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormReportBudget.MdiParent = Me
            FormReportBudget.Show()
            FormReportBudget.WindowState = FormWindowState.Maximized
            FormReportBudget.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBVoucherPOS_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBVoucherPOS.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormVoucherPOS.MdiParent = Me
            FormVoucherPOS.Show()
            FormVoucherPOS.WindowState = FormWindowState.Maximized
            FormVoucherPOS.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBPromoRules_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPromoRules.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormPromoRules.MdiParent = Me
            FormPromoRules.Show()
            FormPromoRules.WindowState = FormWindowState.Maximized
            FormPromoRules.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBInputAttendance_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBInputAttendance.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpInputAttendance.MdiParent = Me
            FormEmpInputAttendance.is_hrd = "-1"
            FormEmpInputAttendance.Show()
            FormEmpInputAttendance.WindowState = FormWindowState.Maximized
            FormEmpInputAttendance.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBPurcReqIC_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPurcReqIC.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormPurcReqList.MdiParent = Me
            FormPurcReqList.step_approve = "1"
            FormPurcReqList.Show()
            FormPurcReqList.WindowState = FormWindowState.Maximized
            FormPurcReqList.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBPurcReqIA_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPurcReqIA.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormPurcReqList.MdiParent = Me
            FormPurcReqList.step_approve = "2"
            FormPurcReqList.Show()
            FormPurcReqList.WindowState = FormWindowState.Maximized
            FormPurcReqList.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBBuktiPickup_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBBuktiPickup.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormBuktiPickup.MdiParent = Me
            FormBuktiPickup.Show()
            FormBuktiPickup.WindowState = FormWindowState.Maximized
            FormBuktiPickup.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBDebitNote_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBDebitNote.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormDebitNote.MdiParent = Me
            FormDebitNote.Show()
            FormDebitNote.WindowState = FormWindowState.Maximized
            FormDebitNote.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBScheduleProposeSales_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBScheduleProposeSales.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpAttnAssign.MdiParent = Me
            FormEmpAttnAssign.is_user_mapping = "1"
            FormEmpAttnAssign.Show()
            FormEmpAttnAssign.WindowState = FormWindowState.Maximized
            FormEmpAttnAssign.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBTrackingReturn_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBTrackingReturn.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormTrackingReturn.MdiParent = Me
            FormTrackingReturn.Show()
            FormTrackingReturn.WindowState = FormWindowState.Maximized
            FormTrackingReturn.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBInputAttendanceHRD_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBInputAttendanceHRD.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpInputAttendance.MdiParent = Me
            FormEmpInputAttendance.is_hrd = "1"
            FormEmpInputAttendance.Show()
            FormEmpInputAttendance.WindowState = FormWindowState.Maximized
            FormEmpInputAttendance.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBBPJSKesehatan_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBBPJSKesehatan.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpBPJSKesehatan.MdiParent = Me
            FormEmpBPJSKesehatan.is_approve = "0"
            FormEmpBPJSKesehatan.Show()
            FormEmpBPJSKesehatan.WindowState = FormWindowState.Maximized
            FormEmpBPJSKesehatan.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBBPJSKesehatanApprove_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBBPJSKesehatanApprove.LinkClicked
        Try
            FormEmpBPJSKesehatan.MdiParent = Me
            FormEmpBPJSKesehatan.is_approve = "1"
            FormEmpBPJSKesehatan.Show()
            FormEmpBPJSKesehatan.WindowState = FormWindowState.Maximized
            FormEmpBPJSKesehatan.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
    End Sub

    Private Sub NBSendEmailAcc_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSendEmailAcc.LinkClicked
        Try
            FormMailManage.MdiParent = Me
            FormMailManage.id_menu = "1"
            FormMailManage.Show()
            FormMailManage.WindowState = FormWindowState.Maximized
            FormMailManage.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
    End Sub

    Private Sub NBCompanyGroup_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCompanyGroup.LinkClicked
        Try
            FormPopUpCompGroup.MdiParent = Me
            FormPopUpCompGroup.is_menu = "1"
            FormPopUpCompGroup.Show()
            FormPopUpCompGroup.WindowState = FormWindowState.Maximized
            FormPopUpCompGroup.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
    End Sub

    Private Sub NBCompanyEmailMapping_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCompanyEmailMapping.LinkClicked
        Try
            FormCompanyEmailMapping.MdiParent = Me
            FormCompanyEmailMapping.mail_dept = "acc"
            FormCompanyEmailMapping.Show()
            FormCompanyEmailMapping.WindowState = FormWindowState.Maximized
            FormCompanyEmailMapping.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
    End Sub

    Private Sub NBInvTracking_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBInvTracking.LinkClicked
        Try
            FormInvoiceTracking.MdiParent = Me
            FormInvoiceTracking.Show()
            FormInvoiceTracking.WindowState = FormWindowState.Maximized
            FormInvoiceTracking.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
    End Sub

    Private Sub NBFolluwUpAR_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFolluwUpAR.LinkClicked
        Try
            FormFollowUpAR.MdiParent = Me
            FormFollowUpAR.Show()
            FormFollowUpAR.WindowState = FormWindowState.Maximized
            FormFollowUpAR.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
    End Sub

    Private Sub NBInvMat_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBInvMat.LinkClicked
        Try
            FormInvMat.MdiParent = Me
            FormInvMat.Show()
            FormInvMat.WindowState = FormWindowState.Maximized
            FormInvMat.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
    End Sub

    Private Sub NBAREvalSchedule_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAREvalSchedule.LinkClicked
        Try
            FormAREvalScheduke.MdiParent = Me
            FormAREvalScheduke.Show()
            FormAREvalScheduke.WindowState = FormWindowState.Maximized
            FormAREvalScheduke.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
    End Sub

    Private Sub NBAREvaluation_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAREvaluation.LinkClicked
        Try
            FormAREvaluation.MdiParent = Me
            FormAREvaluation.Show()
            FormAREvaluation.WindowState = FormWindowState.Maximized
            FormAREvaluation.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
    End Sub

    Private Sub NBDelManifest_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBDelManifest.LinkClicked
        Try
            FormDelManifest.MdiParent = Me
            FormDelManifest.Show()
            FormDelManifest.WindowState = FormWindowState.Maximized
            FormDelManifest.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
    End Sub

    Private Sub NBDelayPayment_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBDelayPayment.LinkClicked
        Try
            FormDelayPayment.MdiParent = Me
            FormDelayPayment.Show()
            FormDelayPayment.WindowState = FormWindowState.Maximized
            FormDelayPayment.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
    End Sub

    Private Sub NBAccountingLedger_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAccountingLedger.LinkClicked
        Try
            FormAccountingLedger.MdiParent = Me
            FormAccountingLedger.Show()
            FormAccountingLedger.WindowState = FormWindowState.Maximized
            FormAccountingLedger.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
    End Sub

    Private Sub NBCollectionAvg_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCollectionAvg.LinkClicked
        Try
            FormARCollectionAvg.MdiParent = Me
            FormARCollectionAvg.Show()
            FormARCollectionAvg.WindowState = FormWindowState.Maximized
            FormARCollectionAvg.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
    End Sub

    Private Sub NBAPReport_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAPReport.LinkClicked
        Try
            FormAPReport.MdiParent = Me
            FormAPReport.Show()
            FormAPReport.WindowState = FormWindowState.Maximized
            FormAPReport.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
    End Sub

    Private Sub NBAccountingWorksheet_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAccountingWorksheet.LinkClicked
        Try
            FormAccountingWorksheet.MdiParent = Me
            FormAccountingWorksheet.Show()
            FormAccountingWorksheet.WindowState = FormWindowState.Maximized
            FormAccountingWorksheet.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
    End Sub

    Private Sub NBReportBalanceSheet_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBReportBalanceSheet.LinkClicked
        Try
            FormReportBalanceSheet.MdiParent = Me
            FormReportBalanceSheet.Show()
            FormReportBalanceSheet.WindowState = FormWindowState.Maximized
            FormReportBalanceSheet.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
    End Sub

    Private Sub NBPriceList_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPriceList.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterPrice.is_price_list = True
            FormMasterPrice.MdiParent = Me
            FormMasterPrice.Show()
            FormMasterPrice.WindowState = FormWindowState.Maximized
            FormMasterPrice.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBDocTracking_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBDocTracking.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormDocTracking.MdiParent = Me
            FormDocTracking.Show()
            FormDocTracking.WindowState = FormWindowState.Maximized
            FormDocTracking.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBListFixedAsset_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBListFixedAsset.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormPurcAsset.is_view = "1"
            FormPurcAsset.MdiParent = Me
            FormPurcAsset.Show()
            FormPurcAsset.WindowState = FormWindowState.Maximized
            FormPurcAsset.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBUniformCreditNote_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBUniformCreditNote.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpUniCreditNote.MdiParent = Me
            FormEmpUniCreditNote.Show()
            FormEmpUniCreditNote.WindowState = FormWindowState.Maximized
            FormEmpUniCreditNote.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSalInv_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesInv.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesInv.MdiParent = Me
            FormSalesInv.Show()
            FormSalesInv.WindowState = FormWindowState.Maximized
            FormSalesInv.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAccClosing_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAccClosing.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormAccClosing.MdiParent = Me
            FormAccClosing.Show()
            FormAccClosing.WindowState = FormWindowState.Maximized
            FormAccClosing.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSeasonDelivery_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSeasonDelivery.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSeason.from_menu = "delivery"
            FormSeason.MdiParent = Me
            FormSeason.Show()
            FormSeason.WindowState = FormWindowState.Maximized
            FormSeason.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBLeavePerUser_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBLeavePerUser.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpLeave.is_propose = "1"
            FormEmpLeave.is_hrd = "-1"
            FormEmpLeave.is_single_user = True
            FormEmpLeave.MdiParent = Me
            FormEmpLeave.Show()
            FormEmpLeave.WindowState = FormWindowState.Maximized
            FormEmpLeave.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBPaymentMissing_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPaymentMissing.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormPaymentMissing.MdiParent = Me
            FormPaymentMissing.Show()
            FormPaymentMissing.WindowState = FormWindowState.Maximized
            FormPaymentMissing.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBLineListMD_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBLineListMD.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormLineList.MdiParent = Me
            FormLineList.Show()
            FormLineList.WindowState = FormWindowState.Maximized
            FormLineList.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBEmpPerAppraisalAtt_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBEmpPerAppraisalAtt.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpPerAppraisal.MdiParent = Me
            FormEmpPerAppraisal.is_hrd = "1"
            FormEmpPerAppraisal.is_only_absensi = True
            FormEmpPerAppraisal.Show()
            FormEmpPerAppraisal.WindowState = FormWindowState.Maximized
            FormEmpPerAppraisal.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBLineListMKT_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBLineListMKT.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormLineList.id_menu = "1"
            FormLineList.show_spesific_col = True
            FormLineList.MdiParent = Me
            FormLineList.Show()
            FormLineList.WindowState = FormWindowState.Maximized
            FormLineList.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBLineListRetail_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBLineListRetail.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormLineList.id_menu = "2"
            FormLineList.show_spesific_col = True
            FormLineList.MdiParent = Me
            FormLineList.Show()
            FormLineList.WindowState = FormWindowState.Maximized
            FormLineList.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBLineListVM_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBLineListVM.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormLineList.id_menu = "3"
            FormLineList.show_spesific_col = True
            FormLineList.MdiParent = Me
            FormLineList.Show()
            FormLineList.WindowState = FormWindowState.Maximized
            FormLineList.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSetupBudgetProdDemand_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSetupBudgetProdDemand.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormBudgetProdDemand.MdiParent = Me
            FormBudgetProdDemand.Show()
            FormBudgetProdDemand.WindowState = FormWindowState.Maximized
            FormBudgetProdDemand.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAttnIndEmp_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAttnIndEmp.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpAttnInd.MdiParent = Me
            FormEmpAttnInd.is_emp = True
            FormEmpAttnInd.Show()
            FormEmpAttnInd.WindowState = FormWindowState.Maximized
            FormEmpAttnInd.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBLeavePerDepartement_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBLeavePerDepartement.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpLeave.is_propose = "1"
            FormEmpLeave.is_hrd = "-1"
            FormEmpLeave.is_departement_sub = True
            FormEmpLeave.MdiParent = Me
            FormEmpLeave.Show()
            FormEmpLeave.WindowState = FormWindowState.Maximized
            FormEmpLeave.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBTabunganMissing_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBTabunganMissing.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormTabunganMissing.MdiParent = Me
            FormTabunganMissing.Show()
            FormTabunganMissing.WindowState = FormWindowState.Maximized
            FormTabunganMissing.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBScheduleProposeDepartement_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBScheduleProposeDepartement.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpAttnAssign.MdiParent = Me
            FormEmpAttnAssign.is_departement = "1"
            FormEmpAttnAssign.Show()
            FormEmpAttnAssign.WindowState = FormWindowState.Maximized
            FormEmpAttnAssign.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBPriceForSync_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPriceForSync.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormPriceForSync.MdiParent = Me
            FormPriceForSync.Show()
            FormPriceForSync.WindowState = FormWindowState.Maximized
            FormPriceForSync.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NB3plRate_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NB3plRate.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            Form3plRate.MdiParent = Me
            Form3plRate.Show()
            Form3plRate.WindowState = FormWindowState.Maximized
            Form3plRate.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFabricType_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFabricType.LinkClicked
        Cursor = Cursors.WaitCursor
        Try

        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBLetterOfStatement_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBLetterOfStatement.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormLetterOfStatement.MdiParent = Me
            FormLetterOfStatement.Show()
            FormLetterOfStatement.WindowState = FormWindowState.Maximized
            FormLetterOfStatement.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBCompareStockWebsite_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCompareStockWebsite.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormCompareStockWebsite.MdiParent = Me
            FormCompareStockWebsite.Show()
            FormCompareStockWebsite.WindowState = FormWindowState.Maximized
            FormCompareStockWebsite.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBItemTrf_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBItemTrf.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormItemTrf.MdiParent = Me
            FormItemTrf.Show()
            FormItemTrf.WindowState = FormWindowState.Maximized
            FormItemTrf.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBRetOlShop_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBRetOlShop.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormRetOlStore.MdiParent = Me
            FormRetOlStore.Show()
            FormRetOlStore.WindowState = FormWindowState.Maximized
            FormRetOlStore.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBRetOlStoreList_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBRetOlStoreList.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormOlStoreReturnList.MdiParent = Me
            FormOlStoreReturnList.Show()
            FormOlStoreReturnList.WindowState = FormWindowState.Maximized
            FormOlStoreReturnList.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBRetOlStoreCust_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBRetOlStoreCust.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormOlStoreRetCust.MdiParent = Me
            FormOlStoreRetCust.Show()
            FormOlStoreRetCust.WindowState = FormWindowState.Maximized
            FormOlStoreRetCust.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAcceptRefundOLStore_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAcceptRefundOLStore.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormRefundOLStore.MdiParent = Me
            FormRefundOLStore.Show()
            FormRefundOLStore.WindowState = FormWindowState.Maximized
            FormRefundOLStore.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBCompCOA_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCompCOA.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterCompany.MdiParent = Me
            FormMasterCompany.is_accounting = True
            FormMasterCompany.Show()
            FormMasterCompany.WindowState = FormWindowState.Maximized
            FormMasterCompany.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSalesBranch_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesBranch.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesBranch.MdiParent = Me
            FormSalesBranch.Show()
            FormSalesBranch.WindowState = FormWindowState.Maximized
            FormSalesBranch.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBPromoCollection_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPromoCollection.LinkClicked
        Cursor = Cursors.WaitCursor
        'close
        Try
            FormPromoCollection.Close()
            FormPromoCollection.Dispose()
        Catch ex As Exception
        End Try
        Try
            FormPromoCollection.MdiParent = Me
            FormPromoCollection.Show()
            FormPromoCollection.WindowState = FormWindowState.Maximized
            FormPromoCollection.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBExternalUser_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBExternalUser.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormExternalUser.MdiParent = Me
            FormExternalUser.Show()
            FormExternalUser.WindowState = FormWindowState.Maximized
            FormExternalUser.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMappingStore_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMappingStore.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMappingStore.MdiParent = Me
            FormMappingStore.Show()
            FormMappingStore.WindowState = FormWindowState.Maximized
            FormMappingStore.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMasterStore_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMasterStore.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterStore.MdiParent = Me
            FormMasterStore.Show()
            FormMasterStore.WindowState = FormWindowState.Maximized
            FormMasterStore.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBDesignColumn_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBDesignColumn.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormDesignColumn.MdiParent = Me
            FormDesignColumn.Show()
            FormDesignColumn.WindowState = FormWindowState.Maximized
            FormDesignColumn.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBCNSalesBranch_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCNSalesBranch.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesBranch.MdiParent = Me
            FormSalesBranch.rmt = "256"
            FormSalesBranch.Show()
            FormSalesBranch.WindowState = FormWindowState.Maximized
            FormSalesBranch.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBOutboundList_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBOutboundList.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormOutboundList.MdiParent = Me
            FormOutboundList.Show()
            FormOutboundList.WindowState = FormWindowState.Maximized
            FormOutboundList.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBODMComplete_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBODMComplete.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormODM.MdiParent = Me
            FormODM.Show()
            FormODM.WindowState = FormWindowState.Maximized
            FormODM.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBPOList_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPOList.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormReportFGPO.MdiParent = Me
            FormReportFGPO.Show()
            FormReportFGPO.WindowState = FormWindowState.Maximized
            FormReportFGPO.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBPayoutReport_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPayoutReport.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormPayoutReport.MdiParent = Me
            FormPayoutReport.Show()
            FormPayoutReport.WindowState = FormWindowState.Maximized
            FormPayoutReport.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBVerificationMasterOL_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBVerificationMasterOL.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormVerificationMasterOL.MdiParent = Me
            FormVerificationMasterOL.Show()
            FormVerificationMasterOL.WindowState = FormWindowState.Maximized
            FormVerificationMasterOL.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFabrication_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFabrication.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterDesignFabrication.MdiParent = Me
            FormMasterDesignFabrication.Show()
            FormMasterDesignFabrication.WindowState = FormWindowState.Maximized
            FormMasterDesignFabrication.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBABGRoyaltyZone_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBABGRoyaltyZone.LinkClicked
        Try
            FormABGRoyaltyZone.MdiParent = Me
            FormABGRoyaltyZone.Show()
            FormABGRoyaltyZone.WindowState = FormWindowState.Maximized
            FormABGRoyaltyZone.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub NBItemRequestPurchasing_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBItemRequestPurchasing.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormItemReq.Close()
            FormItemReq.Dispose()
        Catch ex As Exception
        End Try

        Try
            FormItemReq.is_for_purchasing = "1"
            FormItemReq.MdiParent = Me
            FormItemReq.Show()
            FormItemReq.WindowState = FormWindowState.Maximized
            FormItemReq.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBDesignTemplate_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBDesignTemplate.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormDesignColumnMapping.MdiParent = Me
            FormDesignColumnMapping.Show()
            FormDesignColumnMapping.WindowState = FormWindowState.Maximized
            FormDesignColumnMapping.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMaterialRequisition_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMaterialRequisition.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMaterialRequisition.MdiParent = Me
            FormMaterialRequisition.Show()
            FormMaterialRequisition.WindowState = FormWindowState.Maximized
            FormMaterialRequisition.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSendEmailReturn_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSendEmailReturn.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMailManageReturn.MdiParent = Me
            FormMailManageReturn.Show()
            FormMailManageReturn.WindowState = FormWindowState.Maximized
            FormMailManageReturn.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    Private Sub NBAdditionalCost_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAdditionalCost.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormAdditionalCost.MdiParent = Me
            FormAdditionalCost.Show()
            FormAdditionalCost.WindowState = FormWindowState.Maximized
            FormAdditionalCost.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBDesignImages_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBDesignImages.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormDesignImages.MdiParent = Me
            FormDesignImages.Show()
            FormDesignImages.WindowState = FormWindowState.Maximized
            FormDesignImages.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBEmployeeContract_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBEmployeeContract.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmployeeContract.MdiParent = Me
            FormEmployeeContract.Show()
            FormEmployeeContract.WindowState = FormWindowState.Maximized
            FormEmployeeContract.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NB3PLMailReturn_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NB3PLMailReturn.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesReturnOrderMail.MdiParent = Me
            FormSalesReturnOrderMail.Show()
            FormSalesReturnOrderMail.WindowState = FormWindowState.Maximized
            FormSalesReturnOrderMail.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBInboundAwb_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBInboundAwb.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormInbound3PL.MdiParent = Me
            FormInbound3PL.Show()
            FormInbound3PL.WindowState = FormWindowState.Maximized
            FormInbound3PL.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBReturnNote_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBReturnNote.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormReturnNote.MdiParent = Me
            FormReturnNote.Show()
            FormReturnNote.WindowState = FormWindowState.Maximized
            FormReturnNote.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBListStore_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBListStore.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormListStore.MdiParent = Me
            FormListStore.Show()
            FormListStore.WindowState = FormWindowState.Maximized
            FormListStore.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBScanReturn_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBScanReturn.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormScanReturn.MdiParent = Me
            FormScanReturn.Show()
            FormScanReturn.WindowState = FormWindowState.Maximized
            FormScanReturn.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBCompanyEmailMappingWH_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCompanyEmailMappingWH.LinkClicked
        Try
            FormCompanyEmailMapping.MdiParent = Me
            FormCompanyEmailMapping.mail_dept = "wh"
            FormCompanyEmailMapping.Show()
            FormCompanyEmailMapping.WindowState = FormWindowState.Maximized
            FormCompanyEmailMapping.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
    End Sub

    Private Sub NBBatchUpload_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBBatchUpload.LinkClicked
        Try
            FormBatchUploadOnlineStore.MdiParent = Me
            FormBatchUploadOnlineStore.Show()
            FormBatchUploadOnlineStore.WindowState = FormWindowState.Maximized
            FormBatchUploadOnlineStore.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
    End Sub

    Private Sub NBOOSFinalize_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBOOSFinalize.LinkClicked
        'menu here
        Try
            FormOLStoreOOS.MdiParent = Me
            FormOLStoreOOS.id_type = "3"
            FormOLStoreOOS.Show()
            FormOLStoreOOS.WindowState = FormWindowState.Maximized
            FormOLStoreOOS.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
    End Sub

    Private Sub NBAdjustmentOG_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAdjustmentOG.LinkClicked
        Try
            FormAdjustmentOG.MdiParent = Me
            FormAdjustmentOG.Show()
            FormAdjustmentOG.WindowState = FormWindowState.Maximized
            FormAdjustmentOG.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
    End Sub

    Private Sub NBVerificationMasterPrice_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBVerificationMasterPrice.LinkClicked
        Try
            FormVerificationMasterPrice.MdiParent = Me
            FormVerificationMasterPrice.Show()
            FormVerificationMasterPrice.WindowState = FormWindowState.Maximized
            FormVerificationMasterPrice.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
    End Sub

    Private Sub NBPolis_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPolis.LinkClicked
        Try
            FormPolis.MdiParent = Me
            FormPolis.Show()
            FormPolis.WindowState = FormWindowState.Maximized
            FormPolis.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
    End Sub

    Private Sub NBPromoCollectionMarketplace_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPromoCollectionMarketplace.LinkClicked
        'close
        Try
            FormPromoCollection.Close()
            FormPromoCollection.Dispose()
        Catch ex As Exception
        End Try
        Try
            FormPromoCollection.MdiParent = Me
            FormPromoCollection.rmt = "286"
            FormPromoCollection.Show()
            FormPromoCollection.WindowState = FormWindowState.Maximized
            FormPromoCollection.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
    End Sub

    Private Sub NBReturnForBOF_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBReturnForBOF.LinkClicked
        Try
            FormReturnForBOF.MdiParent = Me
            FormReturnForBOF.Show()
            FormReturnForBOF.WindowState = FormWindowState.Maximized
            FormReturnForBOF.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
    End Sub

    Private Sub NBStockCardAsset_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBStockCardAsset.LinkClicked
        Try
            FormStockCardDept.MdiParent = Me
            FormStockCardDept.Show()
            FormStockCardDept.WindowState = FormWindowState.Maximized
            FormStockCardDept.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
    End Sub

    Private Sub NBOLReturnRefuse_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBOLReturnRefuse.LinkClicked
        Try
            FormOLReturnRefuse.MdiParent = Me
            FormOLReturnRefuse.Show()
            FormOLReturnRefuse.WindowState = FormWindowState.Maximized
            FormOLReturnRefuse.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
    End Sub

    Private Sub NBSetupMasterCode_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSetupMasterCode.LinkClicked
        Try
            FormMasterCode.id_template = "13"
            FormMasterCode.MdiParent = Me
            FormMasterCode.Show()
            FormMasterCode.WindowState = FormWindowState.Maximized
            FormMasterCode.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
    End Sub

    Private Sub NBCancellationCN_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCancellationCN.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesPOS.Close()
            FormSalesPOS.Dispose()
        Catch ex As Exception
        End Try
        Try
            FormSalesPOS.MdiParent = Me
            FormSalesPOS.id_menu = "6"
            FormSalesPOS.Show()
            FormSalesPOS.WindowState = FormWindowState.Maximized
            FormSalesPOS.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBBiayaSewa_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBBiayaSewa.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormBiayaSewa.MdiParent = Me
            FormBiayaSewa.Show()
            FormBiayaSewa.WindowState = FormWindowState.Maximized
            FormBiayaSewa.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBPricePolicyCode_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPricePolicyCode.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormPricePolicyCode.MdiParent = Me
            FormPricePolicyCode.Show()
            FormPricePolicyCode.WindowState = FormWindowState.Maximized
            FormPricePolicyCode.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBDeliveryMonitoring_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBDeliveryMonitoring.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormDeliveryMonitoring.MdiParent = Me
            FormDeliveryMonitoring.Show()
            FormDeliveryMonitoring.WindowState = FormWindowState.Maximized
            FormDeliveryMonitoring.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBPriceChecker_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPriceChecker.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormPriceChecker.MdiParent = Me
            FormPriceChecker.Show()
            FormPriceChecker.WindowState = FormWindowState.Maximized
            FormPriceChecker.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBProposePriceMKD_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProposePriceMKD.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormProposePriceMKD.MdiParent = Me
            FormProposePriceMKD.Show()
            FormProposePriceMKD.WindowState = FormWindowState.Maximized
            FormProposePriceMKD.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBPODReport_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPODReport.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormOutboundPOD.MdiParent = Me
            FormOutboundPOD.Show()
            FormOutboundPOD.WindowState = FormWindowState.Maximized
            FormOutboundPOD.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMonthlySalesPerformance_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMonthlySalesPerformance.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMonthlySalesPerformance.MdiParent = Me
            FormMonthlySalesPerformance.Show()
            FormMonthlySalesPerformance.WindowState = FormWindowState.Maximized
            FormMonthlySalesPerformance.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBCatalogSpec_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCatalogSpec.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormCatalogSpec.MdiParent = Me
            FormCatalogSpec.Show()
            FormCatalogSpec.WindowState = FormWindowState.Maximized
            FormCatalogSpec.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBInvoiceVerification_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBInvoiceVerification.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            Form3PLInvoiceVerification.MdiParent = Me
            Form3PLInvoiceVerification.Show()
            Form3PLInvoiceVerification.WindowState = FormWindowState.Maximized
            Form3PLInvoiceVerification.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBStockTakeStorePeriod_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBStockTakeStorePeriod.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormStockTakeStorePeriod.MdiParent = Me
            FormStockTakeStorePeriod.Show()
            FormStockTakeStorePeriod.WindowState = FormWindowState.Maximized
            FormStockTakeStorePeriod.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBProductPerform_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProductPerform.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormProductPerform.MdiParent = Me
            FormProductPerform.Show()
            FormProductPerform.WindowState = FormWindowState.Maximized
            FormProductPerform.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBCompGroupEmail_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCompGroupEmail.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormCompGroupEmail.MdiParent = Me
            FormCompGroupEmail.Show()
            FormCompGroupEmail.WindowState = FormWindowState.Maximized
            FormCompGroupEmail.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBOGTransfer_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBOGTransfer.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormOGTransfer.MdiParent = Me
            FormOGTransfer.Show()
            FormOGTransfer.WindowState = FormWindowState.Maximized
            FormOGTransfer.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAWBOther_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAWBOther.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormAWBOther.MdiParent = Me
            FormAWBOther.Show()
            FormAWBOther.WindowState = FormWindowState.Maximized
            FormAWBOther.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBCompStore_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCompStore.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterCompany.MdiParent = Me
            FormMasterCompany.is_store = True
            'FormMasterCompany.is_view = True
            FormMasterCompany.Show()
            FormMasterCompany.WindowState = FormWindowState.Maximized
            FormMasterCompany.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSNIpps_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSNIpps.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSNIppsBudget.MdiParent = Me
            FormSNIppsBudget.Show()
            FormSNIppsBudget.WindowState = FormWindowState.Maximized
            FormSNIppsBudget.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSerahTerimaSNI_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSerahTerimaSNI.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSNISerahTerima.MdiParent = Me
            FormSNISerahTerima.Show()
            FormSNISerahTerima.WindowState = FormWindowState.Maximized
            FormSNISerahTerima.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBStockTakePartial_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBStockTakePartial.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormStockTakePartial.MdiParent = Me
            FormStockTakePartial.Show()
            FormStockTakePartial.WindowState = FormWindowState.Maximized
            FormStockTakePartial.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSNIrealisasi_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSNIrealisasi.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSNIRealisasi.MdiParent = Me
            FormSNIRealisasi.Show()
            FormSNIRealisasi.WindowState = FormWindowState.Maximized
            FormSNIRealisasi.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBQCSNI_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBQCSNI.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSNIQC.MdiParent = Me
            FormSNIQC.Show()
            FormSNIQC.WindowState = FormWindowState.Maximized
            FormSNIQC.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSNIBarcode_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSNIBarcode.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSNIBarcode.MdiParent = Me
            FormSNIBarcode.Show()
            FormSNIBarcode.WindowState = FormWindowState.Maximized
            FormSNIBarcode.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSNIWH_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSNIWH.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSNIWH.MdiParent = Me
            FormSNIWH.Show()
            FormSNIWH.WindowState = FormWindowState.Maximized
            FormSNIWH.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBPreCal_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPreCal.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormPreCalFGPO.MdiParent = Me
            FormPreCalFGPO.Show()
            FormPreCalFGPO.WindowState = FormWindowState.Maximized
            FormPreCalFGPO.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBStoreActivation_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBStoreActivation.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormStoreStatus.MdiParent = Me
            FormStoreStatus.id_comp_cat = "6"
            FormStoreStatus.Show()
            FormStoreStatus.WindowState = FormWindowState.Maximized
            FormStoreStatus.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAccountActivation_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAccountActivation.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormStoreStatus.MdiParent = Me
            FormStoreStatus.Show()
            FormStoreStatus.WindowState = FormWindowState.Maximized
            FormStoreStatus.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSilhouette_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSilhouette.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterSilhouette.MdiParent = Me
            FormMasterSilhouette.is_show_master_sht = True
            FormMasterSilhouette.Show()
            FormMasterSilhouette.WindowState = FormWindowState.Maximized
            FormMasterSilhouette.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default

    End Sub

    Private Sub NBPriceMKDVios_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPriceMKDVios.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormPriceMKDVios.MdiParent = Me
            FormPriceMKDVios.Show()
            FormPriceMKDVios.WindowState = FormWindowState.Maximized
            FormPriceMKDVios.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default

    End Sub

    Private Sub NBCapsule_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCapsule.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormCapsule.MdiParent = Me
            FormCapsule.Show()
            FormCapsule.WindowState = FormWindowState.Maximized
            FormCapsule.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default

    End Sub

    Private Sub NBStockTakePropose_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBStockTakePropose.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormStockTakePropose.MdiParent = Me
            FormStockTakePropose.Show()
            FormStockTakePropose.WindowState = FormWindowState.Maximized
            FormStockTakePropose.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBPrepaidExpense_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPrepaidExpense.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormPrepaidExpense.MdiParent = Me
            FormPrepaidExpense.Show()
            FormPrepaidExpense.WindowState = FormWindowState.Maximized
            FormPrepaidExpense.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBPromoZalora_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPromoZalora.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormPromoZalora.MdiParent = Me
            FormPromoZalora.Show()
            FormPromoZalora.WindowState = FormWindowState.Maximized
            FormPromoZalora.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSalesOrderSvcLevelMD_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesOrderSvcLevelMD.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesOrderSvcLevel.MdiParent = Me
            FormSalesOrderSvcLevel.is_md = "1"
            FormSalesOrderSvcLevel.Show()
            FormSalesOrderSvcLevel.WindowState = FormWindowState.Maximized
            FormSalesOrderSvcLevel.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBDisplayCapacity_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBDisplayCapacity.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormDisplayAlloc.MdiParent = Me
            FormDisplayAlloc.Show()
            FormDisplayAlloc.WindowState = FormWindowState.Maximized
            FormDisplayAlloc.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBVMStoreDisplay_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBVMStoreDisplay.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormVMStoreDisplay.MdiParent = Me
            FormVMStoreDisplay.Show()
            FormVMStoreDisplay.WindowState = FormWindowState.Maximized
            FormVMStoreDisplay.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBImportPlanMonth_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBImportPlanMonth.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormBulanImport.MdiParent = Me
            FormBulanImport.Show()
            FormBulanImport.WindowState = FormWindowState.Maximized
            FormBulanImport.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBPIBTrack_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPIBReview.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormPIBReview.MdiParent = Me
            FormPIBReview.Show()
            FormPIBReview.WindowState = FormWindowState.Maximized
            FormPIBReview.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBProposePromo_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProposePromo.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormProposePromo.MdiParent = Me
            FormProposePromo.Show()
            FormProposePromo.WindowState = FormWindowState.Maximized
            FormProposePromo.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBNominatifPromo_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBNominatifPromo.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormNominatifPromo.MdiParent = Me
            FormNominatifPromo.Show()
            FormNominatifPromo.WindowState = FormWindowState.Maximized
            FormNominatifPromo.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBRetExos_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBRetExos.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormRetExos.MdiParent = Me
            FormRetExos.Show()
            FormRetExos.WindowState = FormWindowState.Maximized
            FormRetExos.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBDisableExos_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBDisableExos.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormDisableExos.MdiParent = Me
            FormDisableExos.Show()
            FormDisableExos.WindowState = FormWindowState.Maximized
            FormDisableExos.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBEOSChange_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBEOSChange.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEOSChange.MdiParent = Me
            FormEOSChange.Show()
            FormEOSChange.WindowState = FormWindowState.Maximized
            FormEOSChange.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub BBDarkMode_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBDarkMode.ItemClick
        If DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Visual Studio 2013 Dark" Then
            apply_skin()
        Else
            apply_darkmode_skin()
        End If
    End Sub

    Sub call_click(ByVal btn As String)
        For Each group As DevExpress.XtraNavBar.NavBarGroup In NBProdRet.Groups
            For i As Integer = 0 To (group.ItemLinks.Count - 1)
                If group.ItemLinks(i).ItemName.ToString = btn Then
                    group.ItemLinks(i).Item.Links(0).PerformClick()
                    'NBEOSChange_LinkClicked(group.ItemLinks(i).Item, New DevExpress.XtraNavBar.NavBarLinkEventArgs(group.ItemLinks(i).Item.Links(0)))
                    Exit For
                End If
            Next
        Next group
    End Sub

    Private Sub NBEts_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBEts.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEts.MdiParent = Me
            FormEts.Show()
            FormEts.WindowState = FormWindowState.Maximized
            FormEts.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMKDEvent_ItemChanged(sender As Object, e As EventArgs) Handles NBMKDEvent.ItemChanged

    End Sub

    Private Sub NBMKDEvent_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMKDEvent.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMKDEvent.MdiParent = Me
            FormMKDEvent.Show()
            FormMKDEvent.WindowState = FormWindowState.Maximized
            FormMKDEvent.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBBSP_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBBSP.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormBSP.MdiParent = Me
            FormBSP.Show()
            FormBSP.WindowState = FormWindowState.Maximized
            FormBSP.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
End Class