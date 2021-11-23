Public Class FormStockTakeProposeDet
    Public id_st_store_propose As String = "-1"

    Public to_mail As DataTable = New DataTable
    Public cc_mail As DataTable = New DataTable

    Private Sub FormStockTakeProposeDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TENumber.EditValue = "[autogenerate]"
        TECreatedAt.EditValue = DateTime.Parse(Now.ToString).ToString("dd MMMM yyyy HH:mm:ss")
        TECreatedBy.EditValue = get_emp(id_user, "3")
        DEPeriodFrom.EditValue = Now
        DEPeriodTo.EditValue = Now
        TETimeFrom.EditValue = Now
        TETimeTo.EditValue = Now

        load_form()
    End Sub

    Private Sub FormStockTakeProposeDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub load_form()
        load_report_status()
        load_group()
        load_store_company()
        load_contact()

        SBMark.Enabled = False
        SBPrint.Enabled = False
        SBAttachment.Enabled = False

        If Not id_st_store_propose = "-1" Then
            Dim data_head As DataTable = execute_query("
                SELECT p.number, p.start_period, p.end_period, p.start_time, p.end_time, p.id_comp_group, p.id_store_company, p.id_comp_contact, DATE_FORMAT(p.created_at, '%d %M %Y %H:%i:%s') AS created_at, e.employee_name AS created_by, p.id_report_status
                FROM tb_st_store_propose AS p
                LEFT JOIN tb_m_comp_group AS g ON p.id_comp_group = g.id_comp_group
                LEFT JOIN tb_m_user AS u ON p.created_by = u.id_user
                LEFT JOIN tb_m_employee AS e ON u.id_employee = e.id_employee
                WHERE p.id_st_store_propose = " + id_st_store_propose + "
            ", -1, True, "", "", "", "")

            TENumber.EditValue = data_head.Rows(0)("number").ToString
            DEPeriodFrom.EditValue = data_head.Rows(0)("start_period")
            DEPeriodTo.EditValue = data_head.Rows(0)("end_period")
            TETimeFrom.EditValue = data_head.Rows(0)("start_time")
            TETimeTo.EditValue = data_head.Rows(0)("end_time")
            SLUEGroup.EditValue = data_head.Rows(0)("id_comp_group")
            SLUEStoreCompany.EditValue = data_head.Rows(0)("id_store_company")
            SLUEContact.EditValue = data_head.Rows(0)("id_comp_contact")
            SLUEReportStatus.EditValue = data_head.Rows(0)("id_report_status")
            TECreatedAt.EditValue = data_head.Rows(0)("created_by").ToString
            TECreatedBy.EditValue = data_head.Rows(0)("created_at").ToString

            TENumber.ReadOnly = True
            DEPeriodFrom.ReadOnly = True
            DEPeriodTo.ReadOnly = True
            TETimeFrom.ReadOnly = True
            TETimeTo.ReadOnly = True
            SLUEGroup.ReadOnly = True
            SLUEStoreCompany.ReadOnly = True
            SLUEContact.ReadOnly = True
            SLUEReportStatus.ReadOnly = True
            TECreatedAt.ReadOnly = True
            TECreatedBy.ReadOnly = True
            SBMark.Enabled = True
            SBPrint.Enabled = True
            SBAttachment.Enabled = True
            SBSubmit.Enabled = False
            SBAddContact.Enabled = False

            Dim data_store As DataTable = execute_query("
                SELECT id_store, DATE_FORMAT(period_start, '%d %M %Y %H:%i:%s') AS period_start, DATE_FORMAT(period_end, '%d %M %Y %H:%i:%s') AS period_end
                FROM tb_st_store_propose_det
                WHERE id_st_store_propose = " + id_st_store_propose + "
            ", -1, True, "", "", "", "")

            For i = 0 To GVStore.RowCount - 1
                For j = 0 To data_store.Rows.Count - 1
                    If GVStore.GetRowCellValue(i, "id_store").ToString = data_store.Rows(j)("id_store").ToString Then
                        GVStore.SetRowCellValue(i, "is_select", "yes")
                        GVStore.SetRowCellValue(i, "period_start", data_store.Rows(j)("period_start"))
                        GVStore.SetRowCellValue(i, "period_end", data_store.Rows(j)("period_end"))
                    End If
                Next
            Next

            GVStore.OptionsBehavior.ReadOnly = True
        End If

        load_surat_ijin()
        load_email()
    End Sub

    Sub load_group()
        Dim query As String = "
            SELECT id_comp_group, CONCAT(comp_group, ' - ', description) AS comp_group
            FROM tb_m_comp_group
        "

        viewSearchLookupQuery(SLUEGroup, query, "id_comp_group", "comp_group", "id_comp_group")
    End Sub

    Sub load_contact()
        Dim query As String = "
            SELECT id_comp_contact, contact_person, `position`
            FROM tb_m_comp_contact
            WHERE id_comp = '" + SLUEStoreCompany.EditValue.ToString + "'
        "

        viewSearchLookupQuery(SLUEContact, query, "id_comp_contact", "contact_person", "id_comp_contact")
    End Sub

    Sub load_store_company()
        Dim query As String = "
            SELECT g.id_comp, c.comp_name
            FROM tb_m_comp_group AS g
            LEFT JOIN tb_m_comp AS c ON g.id_comp = c.id_comp
            WHERE g.id_comp_group = '" + SLUEGroup.EditValue.ToString + "'
            UNION ALL
            SELECT g.id_comp, c.comp_name
            FROM tb_m_comp_group_other AS g
            LEFT JOIN tb_m_comp AS c ON g.id_comp = c.id_comp
            WHERE g.id_comp_group = '" + SLUEGroup.EditValue.ToString + "'
        "

        viewSearchLookupQuery(SLUEStoreCompany, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub load_store()
        Dim id_comp_group As String = ""

        Try
            id_comp_group = SLUEGroup.EditValue.ToString
        Catch ex As Exception
        End Try

        Dim id_store_company As String = ""

        Try
            id_store_company = SLUEStoreCompany.EditValue.ToString
        Catch ex As Exception
        End Try

        Dim period_start As DateTime = Date.Parse(DEPeriodFrom.EditValue.ToString).ToString("yyyy-MM-dd") + " " + DateTime.Parse(TETimeFrom.EditValue.ToString).ToString("HH:mm:ss")
        Dim period_end As DateTime = Date.Parse(DEPeriodTo.EditValue.ToString).ToString("yyyy-MM-dd") + " " + DateTime.Parse(TETimeTo.EditValue.ToString).ToString("HH:mm:ss")

        Dim query As String = "
            SELECT s.id_store, 'no' AS is_select, s.store_name, '" + period_start.ToString("yyyy-MM-dd HH:mm:ss") + "' AS period_start, '" + period_end.ToString("yyyy-MM-dd HH:mm:ss") + "' AS period_end
            FROM tb_m_comp AS c
            LEFT JOIN tb_m_store AS s ON c.id_store = s.id_store
            WHERE c.id_comp_group = '" + id_comp_group + "' AND c.id_store_company = '" + id_store_company + "' AND c.id_store IS NOT NULL AND c.id_comp_cat = 6
            GROUP BY c.id_store
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCStore.DataSource = data

        GVStore.BestFitColumns()
    End Sub

    Sub load_surat_ijin()
        Dim period_from As String = ""
        Dim period_to As String = ""

        Try
            period_from = Date.Parse(DEPeriodFrom.EditValue.ToString).ToString("dd MMMM yyyy")
            period_to = Date.Parse(DEPeriodTo.EditValue.ToString).ToString("dd MMMM yyyy")
        Catch ex As Exception
        End Try

        Dim surat_number As String = TENumber.EditValue.ToString

        Dim surat_date As String = ""
        Try
            surat_date = Date.Parse(TECreatedAt.EditValue.ToString).ToString("dd MMMM yyyy")
        Catch ex As Exception
        End Try

        Dim surat_contact_person As String = SLUEContact.Text
        Dim surat_comp_name As String = SLUEStoreCompany.Text

        Dim surat_store As String = SLUEGroup.Text
        Dim surat_period As String = period_from + " - " + period_to
        Dim surat_time As String = TETimeFrom.Text + " - " + TETimeTo.Text

        Dim html As String = "
            <p style='margin: 0px; line-height: 1; font-size: 14px;'><u>No. " + surat_number + "</u></p>
            <p style='margin: 0px; line-height: 1; font-size: 14px;'>Kuta, " + surat_date + "</p>
            <p style='line-height: 1; font-size: 14px;'>Kepada Yth,</p>
            <p style='margin: 0px; line-height: 1; font-size: 14px;'><b>Bpk/Ibu " + surat_contact_person + "</b></p>
            <p style='margin: 0px; line-height: 1; font-size: 14px;'><b>" + surat_comp_name + "</b></p>
            <p style='margin: 0px; line-height: 1; font-size: 14px;'>Di Tempat</p>
            <p style='line-height: 1; font-size: 14px;'><b><u>Perihal: Pemberitahuan Kegiatan Stocktake PT. Volcom Indonesia</u></b></p>
            <p style='line-height: 1; font-size: 14px;'><b>Dengan hormat,</b></p>
            <p style='line-height: 1; font-size: 14px;'>Pertama-tama kami ucapkan banyak terimakasih atas kerjasama yang telah terjalin dengan baik selama ini.</p>
            <p style='line-height: 1; font-size: 14px;'>Dalam rangka kegiatan audit terhadap data inventory dan laporan keuangan PT. Volcom Indonesia, maka disampaikan bahwa kami akan melakukan kegiatan remote stocktake brand Volcom di toko " + surat_store + ".</p>
            <table>
              <tr>
                <td style='width: 75px'><p style='margin: 0; line-height: 1; font-size: 14px;'>Periode</p></td>
                <td style='width: 10px'><p style='margin: 0; line-height: 1; font-size: 14px;'>:</p></td>
                <td><p style='margin: 0; line-height: 1; font-size: 14px;'>" + surat_period + "</p></td>
              </tr>
              <tr>
                <td><p style='margin: 0; line-height: 1; font-size: 14px;'>Waktu</p></td>
                <td><p style='margin: 0; line-height: 1; font-size: 14px;'>:</p></td>
                <td><p style='margin: 0; line-height: 1; font-size: 14px;'>" + surat_time + " Wita</p></td>
              </tr>
            </table>
            <p style='line-height: 1; font-size: 14px;'>Petugas IA PT. Volcom Indonesia:</p>
            <table>
              <tr>
                <td style='width: 10px'><p style='margin: 0; line-height: 1; font-size: 14px;'>1.</p></td>
                <td style='width: 250px'><p style='margin: 0; line-height: 1; font-size: 14px;'>Anak Agung Gede Putra Wirawan</p></td>
              </tr>
              <tr>
                <td style='width: 10px'><p style='margin: 0; line-height: 1; font-size: 14px;'>2.</p></td>
                <td style='width: 250px'><p style='margin: 0; line-height: 1; font-size: 14px;'>Ni Ketut Sri Udayani</p></td>
              </tr>
              <tr>
                <td><p style='margin: 0; line-height: 1; font-size: 14px;'>3.</p></td>
                <td><p style='margin: 0; line-height: 1; font-size: 14px;'>I Wayan Swastika</p></td>
              </tr>
              <tr>
                <td><p style='margin: 0; line-height: 1; font-size: 14px;'>4.</p></td>
                <td><p style='margin: 0; line-height: 1; font-size: 14px;'>Kadek Budi Ariawan</p></td>
              </tr>
              <tr>
                <td><p style='margin: 0; line-height: 1; font-size: 14px;'>5.</p></td>
                <td><p style='margin: 0; line-height: 1; font-size: 14px;'>I Putu Adi Suarjana</p></td>
              </tr>
            </table>
            <p style='line-height: 1; font-size: 14px;'>Terlampir</p>
            <ul>
              <li><p style='margin: 0; line-height: 1; font-size: 14px;'>Prosedur Stocktake dari PT. Volcom Indonesia</p></li>
              <li><p style='margin: 0; line-height: 1; font-size: 14px;'>Daftar Toko</p></li>
            </ul>
            <p style='line-height: 1; font-size: 14px;'>Agar kegiatan tersebut dapat berjalan dengan baik dan lancar, kami mohon dukungan dari Bapak/Ibu pimpinan seluruh toko agar menyiapkan akses internet, komputer, scanner barcode dan Team Pelaksana Remote Stocktake Toko, yang nantinya hasil remote stocktake tersebut dapat juga digunakan untuk melakukan penilaian terhadap kinerja toko yang Bapak/Ibu kelola.</p>
            <p style='line-height: 1; font-size: 14px;'>Demikian pemberitahuan ini kami sampaikan, atas perhatian dan kerjasamanya kami ucapkan terimakasih.</p>
            <table>
              <tr>
                <td><p style='margin: 0; line-height: 1; font-size: 14px;'>Hormat Kami,</p></td>
                <td style='width: 150px;'></td>
                <td><p style='margin: 0; line-height: 1; font-size: 14px;'>Mengetahui,</p></td>
              </tr>
              <tr>
                <td style='height: 50px;'></td>
                <td></td>
                <td></td>
              </tr>
              <tr>
                <td><p style='margin: 0; line-height: 1; font-size: 14px;'><b><u>Anak Agung Gede Putra Wirawan</u></b></p></td>
                <td></td>
                <td><p style='margin: 0; line-height: 1; font-size: 14px;'><b><u>Marissa Bridgitt Kasih / Karl James Kasih</u></b></p></td>
              </tr>
              <tr>
                <td><p style='margin: 0; line-height: 1; font-size: 14px;'>Asst. Internal Audit Manager</p></td>
                <td></td>
                <td><p style='margin: 0; line-height: 1; font-size: 14px;'>Director</p></td>
              </tr>
            </table>
            <p style='line-height: 1; font-size: 14px;'><i>Tembusan:</i></p>
            <ul>
              <li><p style='margin: 0; line-height: 1; font-size: 14px;'><i>Sales & Operation PT. Volcom Indonesia</i></p></li>
              <li><p style='margin: 0; line-height: 1; font-size: 14px;'><i>Warehouse & Distribution PT. Volcom Indonesia</i></p></li>
              <li><p style='margin: 0; line-height: 1; font-size: 14px;'><i>Finance & Accounting PT. Volcom Indonesia</i></p></li>
            </ul>
        "

        WBSuratIjin.Navigate("about:blank")
        WBSuratIjin.Document.OpenNew(False)
        WBSuratIjin.Document.Write(html)
        WBSuratIjin.Refresh()
    End Sub

    Sub load_email()
        Dim id_comp_group As String = ""

        Try
            id_comp_group = SLUEGroup.EditValue.ToString
        Catch ex As Exception
        End Try

        to_mail = execute_query("
            SELECT name, email
            FROM tb_mail_to_group
            WHERE id_comp_group = '" + id_comp_group + "' AND report_mark_type = 322 AND is_to = 1
        ", -1, True, "", "", "", "")

        cc_mail = execute_query("
            SELECT name, email
            FROM tb_mail_to_group
            WHERE id_comp_group = '" + id_comp_group + "' AND report_mark_type = 322 AND is_to = 2
        ", -1, True, "", "", "", "")

        Dim to_text As String = ""
        Dim cc_text As String = ""

        Dim email_to_mail As String = ""

        For i = 0 To to_mail.Rows.Count - 1
            to_text += "'" + to_mail.Rows(i)("name").ToString + "' " + to_mail.Rows(i)("email").ToString + ", "

            email_to_mail += to_mail.Rows(i)("name").ToString + ", "
        Next

        For i = 0 To cc_mail.Rows.Count - 1
            cc_text += "'" + cc_mail.Rows(i)("name").ToString + "' " + cc_mail.Rows(i)("email").ToString + ", "
        Next

        If Not to_text = "" Then
            to_text = to_text.Substring(0, to_text.Length - 2)
        End If

        If Not cc_text = "" Then
            cc_text = cc_text.Substring(0, cc_text.Length - 2)
        End If

        MEEMailTo.EditValue = to_text
        MEEmailCC.EditValue = cc_text

        TEMailSubject.EditValue = "Ijin Stock Take - " + SLUEGroup.Text

        Dim period_from As String = ""
        Dim period_to As String = ""

        Try
            period_from = Date.Parse(DEPeriodFrom.EditValue.ToString).ToString("dd MMMM yyyy")
            period_to = Date.Parse(DEPeriodTo.EditValue.ToString).ToString("dd MMMM yyyy")
        Catch ex As Exception
        End Try

        If Not email_to_mail = "" Then
            email_to_mail = email_to_mail.Substring(0, email_to_mail.Length - 2)
        End If

        Dim email_period As String = period_from + " - " + period_to
        Dim email_group As String = SLUEGroup.Text
        Dim email_time As String = TETimeFrom.Text + " - " + TETimeTo.Text

        Dim html As String = "
            <p style='line-height: 1.5;'>Dear Bapak / Ibu " + email_to_mail + "</p>
            <p style='margin: 0px; line-height: 1.5;'>Pertama - tama kami ucapkan terima kasih atas kerjasama yang telah berjalan dengan baik selama ini.</p>
            <p style='margin: 0px; line-height: 1.5;'>Bersama ini kami sampaikan tentang rencana kegiatan / pelaksanaan remote stocktake PT.Volcom Indonesia, periode " + email_period + ".</p>
            <p style='margin: 0px; line-height: 1.5;'>Agar kegiatan ini bisa berjalan dengan baik, mohon support, koordinasi dan bantuan dari management " + email_group + " terkait hal-hal sbb: </p>
            <table>
              <tr>
                <td><p style='margin: 0px; line-height: 1.5;'>1.</p></td>
                <td><p style='margin: 0px; line-height: 1.5;'>Ijin pelaksanaan Stocktake</p></td>
              </tr>
              <tr>
                <td><p style='margin: 0px; line-height: 1.5;'>2.</p></td>
                <td><p style='margin: 0px; line-height: 1.5;'>Periode Remote Stocktake:</p></td>
              </tr>
              <tr>
                <td><p style='margin: 0px; line-height: 1.5;'></p></td>
                <td><p style='margin: 0px; line-height: 1.5;'>" + email_period + "</p></td>
              </tr>
              <tr>
                <td><p style='margin: 0px; line-height: 1.5;'>3.</p></td>
                <td><p style='margin: 0px; line-height: 1.5;'>Estimasi waktu:</p></td>
              </tr>
              <tr>
                <td><p style='margin: 0px; line-height: 1.5;'></p></td>
                <td><p style='margin: 0px; line-height: 1.5;'>" + email_time + "</p></td>
              </tr>
              <tr>
                <td style='vertical-align: top;'><p style='margin: 0px; line-height: 1.5;'>4.</p></td>
                <td>
                  <p style='margin: 0px; line-height: 1.5;'>Koordinasi / persiapan (Internal) dari management " + email_group + " untuk toko-toko yang akan dilaksanakan stocktake:</p>
                  <ul style='margin: 0px;'>
                    <li><p style='margin: 0px; line-height: 1.5;'>- Perangkat computer & scanner barcode</p></li>
                    <li><p style='margin: 0px; line-height: 1.5;'>- Jaringan internet untuk meng-akses program remote stocktake</p></li>
                    <li><p style='margin: 0px; line-height: 1.5;'>- Team Pelaksana Remote Stocktake Toko</p></li>
                    <li><p style='margin: 0px; line-height: 1.5;'>- Persiapan stock produk Volcom yang diminta remote stocktake</p></li>
                    <li><p style='margin: 0px; line-height: 1.5;'>- Penyelesaian administrasi yang masih pending</p></li>
                  </ul>
                </td>
              </tr>
              <tr>
                <td style='vertical-align: top;'><p style='margin: 0px; line-height: 1.5;'>5.</p></td>
                <td>
                  <p style='margin: 0px; line-height: 1.5;'>Petugas IA PT. Volcom Indonesia:</p>
                  <ul style='margin: 0px;'>
                    <li><p style='margin: 0px; line-height: 1.5;'>Anak Agung Gede Putra Wirawan</p></li>
                    <li><p style='margin: 0px; line-height: 1.5;'>Ni Ketut Sri Udayani</p></li>
                    <li><p style='margin: 0px; line-height: 1.5;'>Kadek Budi Ariawan</p></li>
                    <li><p style='margin: 0px; line-height: 1.5;'>I Wayan Swastika</p></li>
                    <li><p style='margin: 0px; line-height: 1.5;'>I Putu Adi Suarjana</p></li>
                  </ul>
                </td>
              </tr>
            </table>
            <ul style='margin-bottom: 0px;'>
              <li><p style='margin: 0px; line-height: 1.5;'>Terlampir:</p></li>
            </ul>
            <p style='margin-top: 0px; margin-bottom: 0px; margin-left: 35px; line-height: 1.5;'>- Prosedur Remote Stocktake</p></li>
            <p style='margin-top: 0px; margin-bottom: 0px; margin-left: 35px; line-height: 1.5;'>- Surat Pemberitahuan Resmi kepada Pimpinan / Direktur</p>
            <br />
            <p style='margin: 0px; line-height: 1.5;'>Mohon konfirmasinya, apabila ada hal yang kurang jelas berkaitan dengan ijin pelaksanaan remote stocktake tersebut agar dapat dikoordinasikan kembali.</p>
            <p style='margin: 0px; line-height: 1.5;'>Terima kasih atas perhatiannya.</p>
        "

        WBEmail.Navigate("about:blank")
        WBEmail.Document.OpenNew(False)
        WBEmail.Document.Write(html)
        WBEmail.Refresh()
    End Sub

    Sub load_report_status()
        Dim query As String = "
            SELECT id_report_status, report_status
            FROM tb_lookup_report_status
        "

        viewSearchLookupQuery(SLUEReportStatus, query, "id_report_status", "report_status", "id_report_status")
    End Sub

    Private Sub SLUEGroup_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEGroup.EditValueChanged
        load_store_company()
        load_contact()
        load_store()
        load_surat_ijin()
        load_email()
    End Sub

    Private Sub SLUEContact_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEContact.EditValueChanged
        load_surat_ijin()
        load_email()
    End Sub

    Private Sub TETimeFrom_EditValueChanged(sender As Object, e As EventArgs) Handles TETimeFrom.EditValueChanged
        load_surat_ijin()
        load_email()
    End Sub

    Private Sub TETimeTo_EditValueChanged(sender As Object, e As EventArgs) Handles TETimeTo.EditValueChanged
        load_surat_ijin()
        load_email()
    End Sub

    Private Sub DEPeriodFrom_EditValueChanged(sender As Object, e As EventArgs) Handles DEPeriodFrom.EditValueChanged
        load_surat_ijin()
        load_email()
    End Sub

    Private Sub DEPeriodTo_EditValueChanged(sender As Object, e As EventArgs) Handles DEPeriodTo.EditValueChanged
        load_surat_ijin()
        load_email()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub SBSubmit_Click(sender As Object, e As EventArgs) Handles SBSubmit.Click
        GVStore.FindFilterText = ""
        GVStore.ActiveFilterString = ""
        GVStore.ClearColumnsFilter()

        Dim id_comp_group As String = SLUEGroup.EditValue.ToString
        Dim id_store_company As String = SLUEStoreCompany.EditValue.ToString
        Dim id_comp_contact As String = SLUEContact.EditValue.ToString
        Dim start_period As String = Date.Parse(DEPeriodFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim end_period As String = Date.Parse(DEPeriodTo.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim start_time As String = DateTime.Parse(TETimeFrom.EditValue.ToString).ToString("HH:mm:ss")
        Dim end_time As String = DateTime.Parse(TETimeTo.EditValue.ToString).ToString("HH:mm:ss")

        Dim number As String = execute_query("
            SELECT CONCAT(LPAD(((
                SELECT COUNT(*)
                FROM tb_st_store_propose AS p
                WHERE YEAR(p.created_at) = YEAR(NOW())
            ) + 1), 3, '0'), '/EXT/IAD-SRT/', (
		        SELECT `code`
		        FROM tb_ot_memo_number_mon
		        WHERE `month` = MONTH(NOW())
            ), '/', (SELECT DATE_FORMAT(NOW(), '%y'))) AS surat_number
        ", 0, True, "", "", "", "")

        Dim query_head As String = "
            INSERT INTO tb_st_store_propose (id_comp_group, id_store_company, id_comp_contact, number, start_period, end_period, id_report_status, start_time, end_time, created_at, created_by) VALUES (" + id_comp_group + ", " + id_store_company + ", " + id_comp_contact + ", '" + number + "', '" + start_period + "', '" + end_period + "', 1, '" + start_time + "', '" + end_time + "', NOW(), " + id_user + "); SELECT LAST_INSERT_ID();
        "

        id_st_store_propose = execute_query(query_head, 0, True, "", "", "", "")

        GVStore.ActiveFilterString = "[is_select] = 'yes'"

        Dim query_detail As String = "INSERT INTO tb_st_store_propose_det (id_st_store_propose, id_store, period_start, period_end) VALUES "

        For i = 0 To GVStore.RowCount - 1
            Dim period_start As String = DateTime.Parse(GVStore.GetRowCellValue(i, "period_start").ToString).ToString("yyyy-MM-dd HH:mm:ss")
            Dim period_end As String = DateTime.Parse(GVStore.GetRowCellValue(i, "period_end").ToString).ToString("yyyy-MM-dd HH:mm:ss")

            query_detail += "(" + id_st_store_propose + ", " + GVStore.GetRowCellValue(i, "id_store").ToString + ", '" + period_start + "', '" + period_end + "'), "
        Next

        query_detail = query_detail.Substring(0, query_detail.Length - 2)

        execute_non_query(query_detail, True, "", "", "", "")

        submit_who_prepared("348", id_st_store_propose, id_user)

        Close()
    End Sub

    Private Sub SBAttachmentSuratIjin_Click(sender As Object, e As EventArgs) Handles SBAttachmentSuratIjin.Click
        'path
        Dim path As String = Application.StartupPath & "\download\"
        Dim filename As String = path + "\Surat Ijin.pdf"

        If Not IO.Directory.Exists(path) Then
            System.IO.Directory.CreateDirectory(path)
        End If

        'report
        Dim report As ReportStockTakeProposeSuratIjin = New ReportStockTakeProposeSuratIjin

        report.XrRichText.Html = WBSuratIjin.DocumentText

        report.ExportToPdf(filename)

        'openfile
        Dim processinfo As ProcessStartInfo = New ProcessStartInfo()

        processinfo.FileName = filename
        processinfo.WorkingDirectory = path

        Process.Start(processinfo)
    End Sub

    Private Sub SBAttachmentStoreList_Click(sender As Object, e As EventArgs) Handles SBAttachmentStoreList.Click
        'generate list
        Dim data As DataTable = New DataTable

        data.Columns.Add("no", GetType(Integer))
        data.Columns.Add("store_name", GetType(String))
        data.Columns.Add("period_start", GetType(DateTime))
        data.Columns.Add("period_end", GetType(DateTime))

        GVStore.ClearColumnsFilter()
        GVStore.FindFilterText = ""
        GVStore.ActiveFilterString = ""

        Dim no As Integer = 1

        For i = 0 To GVStore.RowCount - 1
            If GVStore.IsValidRowHandle(i) Then
                If GVStore.GetRowCellValue(i, "is_select").ToString = "yes" Then
                    data.Rows.Add(
                        no,
                        GVStore.GetRowCellValue(i, "store_name").ToString,
                        GVStore.GetRowCellValue(i, "period_start"),
                        GVStore.GetRowCellValue(i, "period_end")
                    )

                    no = no + 1
                End If
            End If
        Next

        'path
        Dim path As String = Application.StartupPath & "\download\"
        Dim filename As String = path + "\Jadwal Remote Stock Take.pdf"

        If Not IO.Directory.Exists(path) Then
            System.IO.Directory.CreateDirectory(path)
        End If

        'report
        Dim report As ReportStockTakeProposeListToko = New ReportStockTakeProposeListToko

        report.GCStore.DataSource = data

        report.ExportToPdf(filename)

        'openfile
        Dim processinfo As ProcessStartInfo = New ProcessStartInfo()

        processinfo.FileName = filename
        processinfo.WorkingDirectory = path

        Process.Start(processinfo)
    End Sub

    Sub send_mail()
        Dim is_ssl = get_setup_field("system_email_is_ssl").ToString

        Dim client As Net.Mail.SmtpClient = New Net.Mail.SmtpClient()

        If is_ssl = "1" Then
            client.Port = get_setup_field("system_email_ssl_port").ToString
            client.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
            client.UseDefaultCredentials = False
            client.Host = get_setup_field("system_email_ssl_server").ToString
            client.EnableSsl = True
            client.Credentials = New System.Net.NetworkCredential(get_setup_field("system_email_ssl").ToString, get_setup_field("system_email_ssl_pass").ToString)
        Else
            client.Port = get_setup_field("system_email_port").ToString
            client.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
            client.UseDefaultCredentials = False
            client.Host = get_setup_field("system_email_server").ToString
            client.Credentials = New System.Net.NetworkCredential(get_setup_field("system_email").ToString, get_setup_field("system_email_pass").ToString)
        End If

        'mail
        Dim mail As Net.Mail.MailMessage = New Net.Mail.MailMessage()

        'from
        Dim from_mail As Net.Mail.MailAddress = New Net.Mail.MailAddress("system@volcom.co.id", "Stock Take - Volcom ERP")

        mail.From = from_mail

        'to
        For j = 0 To to_mail.Rows.Count - 1
            If Not to_mail.Rows(j)("email").ToString = "" Then
                Dim data_to As Net.Mail.MailAddress = New Net.Mail.MailAddress(to_mail.Rows(j)("email").ToString, to_mail.Rows(j)("name").ToString)

                mail.To.Add(data_to)
            End If
        Next

        'cc
        For j = 0 To cc_mail.Rows.Count - 1
            If Not cc_mail.Rows(j)("email").ToString = "" Then
                Dim data_cc As Net.Mail.MailAddress = New Net.Mail.MailAddress(cc_mail.Rows(j)("email").ToString, cc_mail.Rows(j)("name").ToString)

                mail.CC.Add(data_cc)
            End If
        Next

        'subject & body
        mail.Subject = "Ijin Remote Stock Take"

        mail.IsBodyHtml = True

        mail.Body = WBEmail.DocumentText

        'attachment surat
        Dim query_att As String = "
            SELECT doc.id_doc, doc.doc_desc, doc.datetime, 'yes' as is_download, CONCAT(doc.id_doc, '_348_" + id_st_store_propose + "', doc.ext) AS filename, emp.employee_name, doc.is_encrypted
            FROM tb_doc doc
            LEFT JOIN tb_m_user usr ON usr.id_user=doc.id_user_upload
            LEFT JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
            WHERE report_mark_type = '348' AND id_report = '" + id_st_store_propose + "' 
        "

        Dim data_att As DataTable = execute_query(query_att, -1, True, "", "", "", "")

        Dim path As String = Application.StartupPath & "\download\"

        If Not IO.Directory.Exists(path) Then
            System.IO.Directory.CreateDirectory(path)
        End If

        For i = 0 To data_att.Rows.Count - 1
            If data_att.Rows(i)("is_encrypted").ToString = "1" Then
                CryptFile.DecryptFile(get_setup_field("en_phrase"), get_setup_field("upload_dir") + "348\" & data_att.Rows(i)("filename").ToString, path & data_att.Rows(i)("doc_desc").ToString & "_" & data_att.Rows(i)("filename").ToString)
            Else
                My.Computer.Network.DownloadFile(get_setup_field("upload_dir") & "348\" & data_att.Rows(i)("filename").ToString, path & data_att.Rows(i)("doc_desc").ToString & "_" & data_att.Rows(i)("filename").ToString, "", "", True, 100, True)
            End If

            Dim filename As String = path + data_att.Rows(i)("doc_desc").ToString + "_" & data_att.Rows(i)("filename").ToString

            Dim att_surat = New Net.Mail.Attachment(filename)

            mail.Attachments.Add(att_surat)
        Next

        'attachment list toko
        Dim data_toko As DataTable = New DataTable

        data_toko.Columns.Add("no", GetType(Integer))
        data_toko.Columns.Add("store_name", GetType(String))
        data_toko.Columns.Add("period_start", GetType(DateTime))
        data_toko.Columns.Add("period_end", GetType(DateTime))

        GVStore.ClearColumnsFilter()
        GVStore.FindFilterText = ""
        GVStore.ActiveFilterString = ""

        Dim no_toko As Integer = 1

        For i = 0 To GVStore.RowCount - 1
            If GVStore.IsValidRowHandle(i) Then
                If GVStore.GetRowCellValue(i, "is_select").ToString = "yes" Then
                    data_toko.Rows.Add(
                        no_toko,
                        GVStore.GetRowCellValue(i, "store_name").ToString,
                        GVStore.GetRowCellValue(i, "period_start"),
                        GVStore.GetRowCellValue(i, "period_end")
                    )

                    no_toko = no_toko + 1
                End If
            End If
        Next

        Dim report_toko As ReportStockTakeProposeListToko = New ReportStockTakeProposeListToko

        report_toko.GCStore.DataSource = data_toko

        Dim mem_toko As IO.MemoryStream = New IO.MemoryStream()

        report_toko.ExportToPdf(mem_toko)

        mem_toko.Seek(0, System.IO.SeekOrigin.Begin)

        Dim att_toko = New Net.Mail.Attachment(mem_toko, "Jadwal Remote Stock Take.pdf", "application/pdf")

        mail.Attachments.Add(att_toko)

        'attachment p&p
        My.Computer.Network.DownloadFile(New Uri("\\192.168.1.2\dataapp$\template\PP Remote Stocktake Toko.pdf"), path + "\PP Remote Stocktake Toko.pdf", "", "", True, 100, True)

        Dim att_pp = New Net.Mail.Attachment(path + "\PP Remote Stocktake Toko.pdf", "application/pdf")

        mail.Attachments.Add(att_pp)

        Try
            client.Send(mail)

            mail.Dispose()
        Catch ex As Exception
            execute_non_query("INSERT INTO tb_error_mail (date, description) VALUES(NOW(), 'SURAT IJIN STOCK TAKE;" + id_st_store_propose + ";" + addSlashes(ex.ToString) + "'); ", True, "", "", "", "")
        End Try
    End Sub

    Private Sub SBMark_Click(sender As Object, e As EventArgs) Handles SBMark.Click
        Cursor = Cursors.WaitCursor

        FormReportMark.report_mark_type = "348"
        FormReportMark.id_report = id_st_store_propose

        FormReportMark.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        'report
        Dim report As ReportStockTakeProposeSuratIjin = New ReportStockTakeProposeSuratIjin

        report.XrRichText.Html = WBSuratIjin.DocumentText

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        Tool.ShowPreviewDialog()
    End Sub

    Private Sub SBAttachment_Click(sender As Object, e As EventArgs) Handles SBAttachment.Click
        Cursor = Cursors.WaitCursor

        FormDocumentUpload.is_no_delete = "1"
        FormDocumentUpload.id_report = id_st_store_propose
        FormDocumentUpload.report_mark_type = "348"
        FormDocumentUpload.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub SLUEStoreCompany_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEStoreCompany.EditValueChanged
        load_contact()
        load_store()
        load_surat_ijin()
        load_email()
    End Sub

    Private Sub SBAddContact_Click(sender As Object, e As EventArgs) Handles SBAddContact.Click
        FormMasterCompanyContact.id_company = SLUEStoreCompany.EditValue.ToString
        FormMasterCompanyContact.ShowDialog()

        load_contact()
    End Sub

    Private Sub SBPNP_Click(sender As Object, e As EventArgs) Handles SBPNP.Click
        'path
        Dim path As String = Application.StartupPath & "\download\"
        Dim filename As String = path + "\PP Remote Stocktake Toko.pdf"

        If Not IO.Directory.Exists(path) Then
            System.IO.Directory.CreateDirectory(path)
        End If

        'download
        My.Computer.Network.DownloadFile(New Uri("\\192.168.1.2\dataapp$\template\PP Remote Stocktake Toko.pdf"), filename, "", "", True, 100, True)

        'openfile
        Dim processinfo As ProcessStartInfo = New ProcessStartInfo()

        processinfo.FileName = filename
        processinfo.WorkingDirectory = path

        Process.Start(processinfo)
    End Sub
End Class