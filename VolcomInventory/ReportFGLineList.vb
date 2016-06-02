Public Class ReportFGLineList
    Public Shared dt As New DataTable
    Public Shared img_cond As Boolean = False

    Private Sub ReportFGLineList_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GridControl1.DataSource = dt

        'pic repo
        Dim unb_PE As DevExpress.XtraGrid.Columns.GridColumn = BandedGridView1.Columns.AddVisible("img", "Image")
        unb_PE.UnboundType = DevExpress.Data.UnboundColumnType.Object
        BandedGridView1.Columns.Add(unb_PE)
        Dim PE As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
        PE.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        GridControl1.RepositoryItems.Add(PE)
        BandedGridView1.Columns("img").ColumnEdit = PE
        If img_cond = "True" Then
            BandedGridView1.RowHeight = 100
            BandedGridView1.Columns("img").Visible = True
        Else
            BandedGridView1.RowHeight = 10
            BandedGridView1.Columns("img").Visible = False
        End If
    End Sub

    Private Sub BandedGridView1_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles AdvBandedGridView1.CustomColumnDisplayText
        If e.Column.FieldName = "NO" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Dim tot_cost As Decimal
    Dim tot_prc As Decimal
    Dim tot_cost_grp As Decimal
    Dim tot_prc_grp As Decimal

    Dim tot_cost_act As Decimal
    Dim tot_prc_act As Decimal
    Dim tot_cost_grp_act As Decimal
    Dim tot_prc_grp_act As Decimal
    Private Sub BandedGridView1_CustomSummaryCalculate(ByVal sender As System.Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs) Handles AdvBandedGridView1.CustomSummaryCalculate
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        If FormFGLineList.SLETypeLineList.EditValue.ToString = "3" Then
            '-------------ACTUAL
            ' Initialization 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
                tot_cost = 0.0
                tot_prc = 0.0
                tot_cost_grp = 0.0
                tot_prc_grp = 0.0

                tot_cost_act = 0.0
                tot_prc_act = 0.0
                tot_cost_grp_act = 0.0
                tot_prc_grp_act = 0.0
            End If

            ' Calculation 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
                Dim cost As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL COST_Prc_Plan").ToString, "0.00"))
                Dim prc As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL AMO_Prc_Plan"), "0.00"))
                Dim cost_act As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL COST_Prc").ToString, "0.00"))
                Dim prc_act As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL AMO_Prc"), "0.00"))
                Select Case summaryID
                    Case 46
                        tot_cost += cost
                        tot_prc += prc
                    Case 47
                        tot_cost_grp += cost
                        tot_prc_grp += prc
                    Case 48
                        tot_cost_act += cost_act
                        tot_prc_act += prc_act
                    Case 49
                        tot_cost_grp_act += cost_act
                        tot_prc_grp_act += prc_act
                End Select
            End If

            ' Finalization 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                Select Case summaryID
                    Case 46 'total summary
                        Dim sum_res As Decimal = 0.0
                        Try
                            sum_res = tot_prc / tot_cost
                        Catch ex As Exception
                        End Try
                        e.TotalValue = sum_res
                    Case 47 'group summary
                        Dim sum_res As Decimal = 0.0
                        Try
                            sum_res = tot_prc_grp / tot_cost_grp
                        Catch ex As Exception
                        End Try
                        e.TotalValue = sum_res
                    Case 48 'total summary
                        Dim sum_res As Decimal = 0.0
                        Try
                            sum_res = tot_prc_act / tot_cost_act
                        Catch ex As Exception
                        End Try
                        e.TotalValue = sum_res
                    Case 49 'group summary
                        Dim sum_res As Decimal = 0.0
                        Try
                            sum_res = tot_prc_grp_act / tot_cost_grp_act
                        Catch ex As Exception
                        End Try
                        e.TotalValue = sum_res
                End Select
            End If
        Else
            ' Initialization 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
                tot_cost = 0.0
                tot_prc = 0.0
                tot_cost_grp = 0.0
                tot_prc_grp = 0.0
            End If

            ' Calculation 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
                Dim cost As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL COST_Prc").ToString, "0.00"))
                Dim prc As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL AMO_Prc"), "0.00"))
                Select Case summaryID
                    Case 46
                        tot_cost += cost
                        tot_prc += prc
                    Case 47
                        tot_cost_grp += cost
                        tot_prc_grp += prc
                End Select
            End If

            ' Finalization 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                Select Case summaryID
                    Case 46 'total summary
                        Dim sum_res As Decimal = 0.0
                        Try
                            sum_res = tot_prc / tot_cost
                        Catch ex As Exception
                        End Try
                        e.TotalValue = sum_res
                    Case 47 'group summary
                        Dim sum_res As Decimal = 0.0
                        Try
                            sum_res = tot_prc_grp / tot_cost_grp
                        Catch ex As Exception
                        End Try
                        e.TotalValue = sum_res
                End Select
            End If
        End If
    End Sub

    Private ImageDir As String = product_image_path
    Private Images As Hashtable = New Hashtable()
    Private Sub BandedGridView1_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles BandedGridView1.CustomUnboundColumnData
        If e.Column.FieldName = "img" AndAlso e.IsGetData And img_cond = "True" Then
            Images = Nothing
            Images = New Hashtable()
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim id As String = CStr(view.GetListSourceRowCellValue(e.ListSourceRowIndex, "id_design"))

            Dim fileName As String = id & ".jpg".ToLower

            If (Not Images.ContainsKey(fileName)) Then
                Dim img As Image = Nothing
                Dim resizeImg As Image = Nothing

                Try

                    Dim filePath As String = DevExpress.Utils.FilesHelper.FindingFileName(ImageDir, fileName, False)
                    img = Image.FromFile(filePath)
                    resizeImg = img.GetThumbnailImage(100, 100, Nothing, Nothing)
                Catch

                End Try

                Images.Add(fileName, resizeImg)

            End If

            e.Value = Images(fileName)
        End If
    End Sub
End Class