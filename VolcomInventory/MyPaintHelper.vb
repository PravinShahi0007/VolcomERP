Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.Utils.Paint
Imports DevExpress.XtraGrid.Views.BandedGrid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Drawing
Imports DevExpress.XtraGrid.Views.Grid.Drawing
Imports DevExpress.XtraGrid
Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.Utils

Friend Class MyPaintHelper
    Inherits GridPainter
    Private _View As BandedGridView
    Private _Bands() As GridBand
    Public Sub New(ByVal view As BandedGridView, ByVal bands() As GridBand)
        MyBase.New(view)
        _View = view
        _Bands = bands
        AddHandler _View.GridControl.Paint, AddressOf GridControl_Paint
        AddHandler _View.CustomDrawBandHeader, AddressOf _View_CustomDrawBandHeader
        AddHandler _View.MouseDown, AddressOf _View_MouseDown
    End Sub

    Private Sub _View_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        'Dim hi As BandedGridHitInfo = _View.CalcHitInfo(e.Location)
        'If _Bands.Contains(hi.Band) Then
        '    DXMouseEventArgs.GetMouseArgs(e).Handled = True
        'End If
    End Sub

    Private Sub _View_CustomDrawBandHeader(ByVal sender As Object, ByVal e As BandHeaderCustomDrawEventArgs)
        If _Bands.Contains(e.Band) Then
            e.Handled = True
        End If
    End Sub

    Private Sub GridControl_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)
        For Each band As GridBand In _Bands
            For Each column As BandedGridColumn In band.Columns
                DrawColumnHeader(New GraphicsCache(e.Graphics), column)
            Next column
        Next band
    End Sub

    Public Sub DrawColumnHeader(ByVal cache As GraphicsCache, ByVal column As GridColumn)
        Dim viewInfo As BandedGridViewInfo = TryCast(_View.GetViewInfo(), BandedGridViewInfo)
        Dim colInfo As GridColumnInfoArgs = viewInfo.ColumnsInfo(column)
        Dim bandInfo As GridBandInfoArgs = getBandInfo(viewInfo.BandsInfo, (TryCast(column, BandedGridColumn)).OwnerBand)
        If colInfo Is Nothing OrElse bandInfo Is Nothing Then
            Return
        End If
        colInfo.Cache = cache

        Dim top As Integer = bandInfo.Bounds.Top
        Dim rect As Rectangle = colInfo.Bounds
        Dim delta As Integer = rect.Top - top
        rect.Y = top
        rect.Height += delta
        colInfo.Bounds = rect
        colInfo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Dim args As HeaderObjectInfoArgs = TryCast(colInfo, HeaderObjectInfoArgs)
        Dim btn As GridFilterButtonInfoArgs = TryCast(args.InnerElements(1).ElementInfo, GridFilterButtonInfoArgs)
        ElementsPainter.Column.CalcObjectBounds(colInfo)
        Try
            btn.Bounds = New Rectangle(btn.Bounds.X, btn.Bounds.Y + colInfo.Bounds.Height \ 2, btn.Bounds.Width, btn.Bounds.Height)
        Catch ex As Exception

        End Try
        ElementsPainter.Column.DrawObject(colInfo)
    End Sub

    Private Function getBandInfo(ByVal bands As GridBandInfoCollection, ByVal band As GridBand) As GridBandInfoArgs
        Dim info As GridBandInfoArgs = bands(band)
        If info IsNot Nothing Then
            Return info
        Else
            For Each bandInfo As GridBandInfoArgs In bands
                If bandInfo.Children IsNot Nothing Then
                    info = getBandInfo(bandInfo.Children, band)
                    If info IsNot Nothing Then
                        Return info
                    End If
                End If
            Next bandInfo
        End If
        Return Nothing
    End Function
End Class
