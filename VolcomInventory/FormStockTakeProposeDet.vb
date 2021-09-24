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
        load_contact()

        SBMark.Enabled = False

        If Not id_st_store_propose = "-1" Then
            Dim data_head As DataTable = execute_query("
                SELECT p.number, p.start_period, p.end_period, p.start_time, p.end_time, p.id_comp_group, p.id_comp_contact, DATE_FORMAT(p.created_at, '%d %M %Y %H:%i:%s') AS created_at, e.employee_name AS created_by, p.id_report_status
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
            SLUEContact.ReadOnly = True
            SLUEReportStatus.ReadOnly = True
            TECreatedAt.ReadOnly = True
            TECreatedBy.ReadOnly = True
            SBMark.Enabled = True
            SBSubmit.Enabled = False

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
            WHERE id_comp IN (SELECT id_comp FROM tb_m_comp_group WHERE id_comp_group = " + SLUEGroup.EditValue.ToString + ")
        "

        viewSearchLookupQuery(SLUEContact, query, "id_comp_contact", "contact_person", "id_comp_contact")
    End Sub

    Sub load_store()
        Dim id_comp_group As String = ""

        Try
            id_comp_group = SLUEGroup.EditValue.ToString
        Catch ex As Exception
        End Try

        Dim period_start As DateTime = Date.Parse(DEPeriodFrom.EditValue.ToString).ToString("yyyy-MM-dd") + " " + DateTime.Parse(TETimeFrom.EditValue.ToString).ToString("HH:mm:ss")
        Dim period_end As DateTime = Date.Parse(DEPeriodTo.EditValue.ToString).ToString("yyyy-MM-dd") + " " + DateTime.Parse(TETimeTo.EditValue.ToString).ToString("HH:mm:ss")

        Dim query As String = "
            SELECT s.id_store, 'no' AS is_select, s.store_name, '" + period_start.ToString("yyyy-MM-dd HH:mm:ss") + "' AS period_start, '" + period_end.ToString("yyyy-MM-dd HH:mm:ss") + "' AS period_end
            FROM tb_m_comp AS c
            LEFT JOIN tb_m_store AS s ON c.id_store = s.id_store
            WHERE c.id_comp_group = " + id_comp_group + " AND c.id_store IS NOT NULL
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

        Dim data_comp As DataTable = New DataTable

        Try
            data_comp = execute_query("
                SELECT c.comp_name, c.npwp_address
                FROM tb_m_comp_group AS g
                LEFT JOIN tb_m_comp AS c ON g.id_comp = c.id_comp
                WHERE g.id_comp_group = " + SLUEGroup.EditValue.ToString + "
            ", -1, True, "", "", "", "")
        Catch ex As Exception
        End Try

        Dim surat_number As String = TENumber.EditValue.ToString
        Dim surat_date As String = ""
        Try
            surat_date = Date.Parse(TECreatedAt.EditValue.ToString).ToString("dd MMMM yyyy")
        Catch ex As Exception
        End Try
        Dim surat_contact_person As String = SLUEContact.Text
        Dim surat_comp_name As String = ""
        Try
            surat_comp_name = data_comp.Rows(0)("comp_name").ToString
        Catch ex As Exception
        End Try
        Dim surat_position As String = ""
        Try
            surat_position = execute_query("SELECT position FROM tb_m_comp_contact WHERE id_comp_contact = " + SLUEContact.EditValue.ToString, 0, True, "", "", "", "")
        Catch ex As Exception
        End Try
        Dim surat_npwp_address As String = ""
        Try
            surat_npwp_address = data_comp.Rows(0)("npwp_address").ToString
        Catch ex As Exception
        End Try
        Dim surat_store As String = SLUEGroup.Text
        Dim surat_period As String = period_from + " - " + period_to
        Dim surat_time As String = TETimeFrom.Text + " - " + TETimeTo.Text

        Dim html As String = "
            <p style='margin: 0px; line-height: 1.5;'><u>No. " + surat_number + "</u></p>
            <p style='margin: 0px; line-height: 1.5;'>Kuta, " + surat_date + "</p>
            <p style='line-height: 1.5;'>Kepada Yth,</p>
            <p style='margin: 0px; line-height: 1.5;'><b>" + surat_contact_person + "</b></p>
            <p style='margin: 0px; line-height: 1.5;'><b>" + surat_comp_name + " - " + surat_position + "</b></p>
            <p style='margin: 0px; line-height: 1.5;'>" + surat_npwp_address + "</p>
            <p style='margin: 0px; line-height: 1.5;'>Di Tempat</p>
            <p style='line-height: 1.5;'><b><u>Perihal: Pemberitahuan Kegiatan Stocktake PT. Volcom Indonesia</u></b></p>
            <p style='line-height: 1.5;'><b>Dengan Hormat,</b></p>
            <p style='line-height: 1.5;'>Pertama-tama kami ucapkan banyak terimaksi atas kerjasama yang telah terjalin dengan baik selama ini.</p>
            <p style='line-height: 1.5;'>Dalam rangka kegiatan audit terhadap data inventory dan laporan keuangan PT. Volcom Indonesia, maka disampaikan bahwa kami akan melakukan kegiatan Stocktake (STK) Brand Volcom di toko " + surat_store + ".</p>
            <table>
              <tr>
                <td style='width: 75px'><p style='margin: 0; line-height: 1.5;'>Periode</p></td>
                <td style='width: 10px'><p style='margin: 0; line-height: 1.5;'>:</p></td>
                <td><p style='margin: 0; line-height: 1.5;'>" + surat_period + "</p></td>
              </tr>
              <tr>
                <td><p style='margin: 0; line-height: 1.5;'>Waktu</p></td>
                <td><p style='margin: 0; line-height: 1.5;'>:</p></td>
                <td><p style='margin: 0; line-height: 1.5;'>" + surat_time + "</p></td>
              </tr>
            </table>
            <p style='line-height: 1.5;'>Berikut kami sampaikan team yang bertugas :</p>
            <table>
              <tr>
                <td style='width: 10px'><p style='margin: 0; line-height: 1.5;'>1.</p></td>
                <td style='width: 250px'><p style='margin: 0; line-height: 1.5;'>AA Gede Putra Wirawan</p></td>
              </tr>
              <tr>
                <td><p style='margin: 0; line-height: 1.5;'>2.</p></td>
                <td><p style='margin: 0; line-height: 1.5;'>Kadek Budi Ariawan</p></td>
              </tr>
              <tr>
                <td><p style='margin: 0; line-height: 1.5;'>3.</p></td>
                <td><p style='margin: 0; line-height: 1.5;'>I Wayan Swastika</p></td>
              </tr>
              <tr>
                <td><p style='margin: 0; line-height: 1.5;'>4.</p></td>
                <td><p style='margin: 0; line-height: 1.5;'>I Putu Adi Suarjana</p></td>
              </tr>
            </table>
            <p style='line-height: 1.5;'>Terlampir</p>
            <ul>
              <li><p style='margin: 0; line-height: 1.5;'>Prosedur Stocktake dari PT. Volcom Indonesia</p></li>
              <li><p style='margin: 0; line-height: 1.5;'>Daftar Toko</p></li>
            </ul>
            <p style='margin: 0; line-height: 1.5;'>Agar kegiatan tersebut dapat berjalan dengan baik dan lancar, kami mohon dukungan dari Bapak dan Ibu pimpinan seluruh toko, yang nantinya hasil Stocktake (STK) tersebut dapat juga digunakan untuk melakukan penilaian terhadap kinerja toko yang Bapak maupun Ibu kelola.</p>
            <p style='line-height: 1.5;'>Demikian pemberitahuan ini kami sampaikan, atas perhatian dan kerjasamanya kami ucapkan terimakasih</p>
            <p style='margin-top: 30px; margin-bottom: 30px; line-height: 1.5;'><i>This is a computer generate no signature is required</i></p>
            <p style='margin: 0; line-height: 1.5;'>Tembusan:</p>
            <ul>
              <li><p style='margin: 0; line-height: 1.5;'><i>Sales & Operation PT. Volcom Indonesia</i></p></li>
              <li><p style='margin: 0; line-height: 1.5;'><i>Warehouse & Distribution PT. Volcom Indonesia</i></p></li>
              <li><p style='margin: 0; line-height: 1.5;'><i>Finance & Accounting PT. Volcom Indonesia</i></p></li>
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
            <p style='line-height: 1.5;'>Dear " + email_to_mail + "</p>
            <p style='margin: 0px; line-height: 1.5;'>Pertama - tama kami ucapkan Terima kasih atas kerja samanya yang telah berjalan dengan baik selama ini.</p>
            <p style='margin: 0px; line-height: 1.5;'>Bersama ini kami sampaikan tentang rencana kegiatan / pelaksanaan Stocktake PT.Volcom Indonesia, periode " + email_period + ".</p>
            <p style='margin: 0px; line-height: 1.5;'>Agar kegiatan ini bisa berjalan dengan baik,</p>
            <p style='margin: 0px; line-height: 1.5;'>Mohon support, koordinasi dan bantuan dari management " + email_group + " terkait hal2 sbb: </p>
            <table>
              <tr>
                <td><p style='margin: 0px; line-height: 1.5;'>1.</p></td>
                <td><p style='margin: 0px; line-height: 1.5;'>Ijin pelaksanaan Stocktake</p></td>
              </tr>
              <tr>
                <td style='vertical-align: top;'><p style='margin: 0px; line-height: 1.5;'>2.</p></td>
                <td>
                  <p style='margin: 0px; line-height: 1.5;'>Sehubungan padatnya schedule stocktake, maka operasional dilaksanakan:</p>
                  <ul style='margin: 0px;'>
                    <li><p style='margin: 0px; line-height: 1.5;'>" + email_period + "</p></li>
                    <li><p style='margin: 0px; line-height: 1.5;'>Team Volcom akan ber-koordinasi bersama team / penanggung jawab toko H-1</p></li>
                  </ul>
                </td>
              </tr>
              <tr>
                <td style='vertical-align: top;'><p style='margin: 0px; line-height: 1.5;'>3.</p></td>
                <td>
                  <p style='margin: 0px; line-height: 1.5;'>Estimasi waktu:</p>
                  <ul style='margin: 0px;'>
                    <li><p style='margin: 0px; line-height: 1.5;'>" + email_time + "</p></li>
                  </ul>
                </td>
              </tr>
              <tr>
                <td style='vertical-align: top;'><p style='margin: 0px; line-height: 1.5;'>4.</p></td>
                <td>
                  <p style='margin: 0px; line-height: 1.5;'>Koordinasi / persiapan ( Internal ) dari management " + email_group + " untuk toko2 yang akan dilaksanakan Stocktake:</p>
                  <ul style='margin: 0px;'>
                    <li><p style='margin: 0px; line-height: 1.5;'>Staff pendamping dan penanggung jawab toko</p></li>
                    <li><p style='margin: 0px; line-height: 1.5;'>Persiapan seluruh stock barang Volcom</p></li>
                    <li><p style='margin: 0px; line-height: 1.5;'>Penyelesaian admininstrasi yang masih pending</p></li>
                    <li><p style='margin: 0px; line-height: 1.5;'>Barang masalah ( No.Tag, Reject dll ) dikumpulkan tersendiri</p></li>
                  </ul>
                </td>
              </tr>
              <tr>
                <td style='vertical-align: top;'><p style='margin: 0px; line-height: 1.5;'>5.</p></td>
                <td>
                  <p style='margin: 0px; line-height: 1.5;'>Person in-charge ( Team Volcom yang akan bertugas ):</p>
                  <ul style='margin: 0px;'>
                    <li><p style='margin: 0px; line-height: 1.5;'>AA Gede Putra Wirawan</p></li>
                    <li><p style='margin: 0px; line-height: 1.5;'>Kadek Budi Ariawan</p></li>
                    <li><p style='margin: 0px; line-height: 1.5;'>I Wayan Swastika</p></li>
                    <li><p style='margin: 0px; line-height: 1.5;'>I Putu Adi Suarjana</p></li>
                  </ul>
                </td>
              </tr>
              <tr>
                <td><p style='margin: 0px; line-height: 1.5;'>6.</p></td>
                <td><p style='margin: 0px; line-height: 1.5;'>Mohon dikirimkan Contact Person Coordinator Area untuk memudahkan proses koordinasi dilapangan.</p></td>
              </tr>
            </table>
            <ul>
              <li><p style='margin: 0px; line-height: 1.5;'>Terlampir:</p></li>
            </ul>
            <ul>
              <li><p style='margin: 0px; line-height: 1.5;'>Prosedur stocktake</p></li>
              <li><p style='margin: 0px; line-height: 1.5;'>Surat pemberitahuan Resmi kepada Pimpinan / Direktur</p></li>
              <li><p style='margin: 0px; line-height: 1.5;'>Time Table Stocktake</p></li>
            </ul>
            <ul>
              <li><p style='margin: 0px; line-height: 1.5;'>Mohon konfirmasinya</p></li>
            </ul>
            <p style='margin: 0px; line-height: 1.5;'>Apabila ada hal yang kurang jelas berkaitan dengan planning tersebut mohon agar dapat dikoordinasikan kembali.</p>
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
        Dim id_comp_group As String = SLUEGroup.EditValue.ToString
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
            INSERT INTO tb_st_store_propose (id_comp_group, id_comp_contact, number, start_period, end_period, id_report_status, start_time, end_time, created_at, created_by) VALUES (" + id_comp_group + ", " + id_comp_contact + ", '" + number + "', '" + start_period + "', '" + end_period + "', 1, '" + start_time + "', '" + end_time + "', NOW(), " + id_user + "); SELECT LAST_INSERT_ID();
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
        Dim filename As String = path + "\List Toko.pdf"

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
        Dim report_surat As ReportStockTakeProposeSuratIjin = New ReportStockTakeProposeSuratIjin

        report_surat.XrRichText.Html = WBSuratIjin.DocumentText

        Dim mem_surat As IO.MemoryStream = New IO.MemoryStream()

        report_surat.ExportToPdf(mem_surat)

        mem_surat.Seek(0, System.IO.SeekOrigin.Begin)

        Dim att_surat = New Net.Mail.Attachment(mem_surat, "Surat Ijin.pdf", "application/pdf")

        mail.Attachments.Add(att_surat)

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

        Dim att_toko = New Net.Mail.Attachment(mem_toko, "List Toko.pdf", "application/pdf")

        mail.Attachments.Add(att_toko)

        Try
            client.Send(mail)

            mail.Dispose()
        Catch ex As Exception
        End Try
    End Sub
End Class