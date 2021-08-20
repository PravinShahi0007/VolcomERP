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

        Dim query As String = "
            SELECT s.id_store, 'no' AS is_select, s.store_name
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

        WBSuratIjin.DocumentText = html
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

        WBEmail.DocumentText = html
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
            INSERT INTO tb_st_store_propose (id_comp_group, id_comp_contact, number, start_period, end_period, start_time, end_time, created_at, created_by) VALUES (" + id_comp_group + ", " + id_comp_contact + ", '" + number + "', '" + start_period + "', '" + end_period + "', '" + start_time + "', '" + end_time + "', NOW(), " + id_user + "); SELECT LAST_INSERT_ID();
        "

        id_st_store_propose = execute_query(query_head, 0, True, "", "", "", "")

        GVStore.ActiveFilterString = "[is_select] = 'yes'"

        Dim query_detail As String = "INSERT INTO tb_st_store_propose_det (id_st_store_propose, id_store) VALUES "

        For i = 0 To GVStore.RowCount - 1
            query_detail += "(" + id_st_store_propose + ", " + GVStore.GetRowCellValue(i, "id_store").ToString + "), "
        Next

        query_detail = query_detail.Substring(0, query_detail.Length - 2)

        execute_non_query(query_detail, True, "", "", "", "")

        Close()
    End Sub
End Class