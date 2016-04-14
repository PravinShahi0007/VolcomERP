Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports DevExpress.Skins
Imports DevExpress.XtraEditors
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraLayout
Imports System.Drawing.Design
Imports System.ComponentModel
Imports System.Drawing
Imports DevExpress.XtraTreeList.Columns
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.Drawing
Public Class FindPanel
    Inherits PanelControl
    Private provider As OptionFindProvider
    Private tree As TreeList
    Private layoutControl As LayoutControl
    Private searchEdit As MRUEdit
    Private closeButton, findButton, clearButton As SimpleButton
    Private closeItem As LayoutControlItem
    Private searchTimer As Timer
    Private prevSearchText As String = String.Empty

    Public Sub New(ByVal provider As OptionFindProvider, ByVal tree As TreeList)
        Me.provider = provider
        Me.tree = tree

        SetUpFindPanel()
    End Sub

    Friend Property SearchText() As String
        Get
            Return searchEdit.Text
        End Get
        Set(ByVal value As String)
            searchEdit.Text = value
        End Set
    End Property

    Private Sub SetUpFindPanel()
        Dock = tree.Dock
        Location = tree.Location
        Size = tree.Size
        Parent = tree.Parent
        tree.Parent = Me
        tree.Dock = DockStyle.Fill
        BringToFront()
        tree.OptionsBehavior.EnableFiltering = True
        AddHandler tree.FilterNode, AddressOf OnFilterNode
        AddHandler tree.CustomDrawNodeCell, AddressOf OnCustomDrawNodeCell
        CreateLayoutControl()
        CreateTimer()
    End Sub

    Private Sub CreateTimer()
        searchTimer = New Timer()
        searchTimer.Interval = provider.FindDelay
        AddHandler searchTimer.Tick, AddressOf OnSearchTimerTick
    End Sub

    Private Sub CreateLayoutControl()
        layoutControl = New LayoutControl()
        layoutControl.Parent = Me
        layoutControl.Dock = DockStyle.Top
        layoutControl.Height = 60
        TryCast(layoutControl, ILayoutControl).EnableCustomizationForm = False

        CreateLayoutItems()
    End Sub

    Private Sub CreateLayoutItems()
        layoutControl.BeginUpdate()
        Try

            searchEdit = New MRUEdit()
            searchEdit.Name = "searchEdit"
            AddHandler searchEdit.EditValueChanged, AddressOf OnSearchTextChanged
            Dim searchEditItem As LayoutControlItem = layoutControl.AddItem("SearchEditItem", searchEdit)
            searchEditItem.TextVisible = False
            searchEditItem.Name = "searchEditItem"

            closeButton = New SimpleButton()
            closeButton.MaximumSize = New Size(25, closeButton.Height)
            closeButton.Text = "X"
            closeButton.Name = "closeButton"
            AddHandler closeButton.Click, AddressOf OnCloseButtonClick
            closeItem = layoutControl.AddItem("CloseItem", closeButton, searchEditItem, DevExpress.XtraLayout.Utils.InsertType.Left)
            closeItem.TextVisible = False
            closeItem.Name = "closeItem"

            findButton = New SimpleButton()
            findButton.MaximumSize = New Size(50, findButton.Height)
            findButton.Text = "Find"
            findButton.Name = "findButton"
            AddHandler findButton.Click, AddressOf OnFindButtonClick
            Dim findItem As LayoutControlItem = layoutControl.AddItem("FindItem", findButton, searchEditItem, DevExpress.XtraLayout.Utils.InsertType.Right)
            findItem.TextVisible = False
            findItem.Name = "findItem"

            clearButton = New SimpleButton()
            clearButton.MaximumSize = New Size(50, clearButton.Height)
            clearButton.Text = "Clear"
            clearButton.Name = "clearButton"
            AddHandler clearButton.Click, AddressOf OnClearButtonClick
            Dim clearItem As LayoutControlItem = layoutControl.AddItem("ClearItem", clearButton, findItem, DevExpress.XtraLayout.Utils.InsertType.Right)
            clearItem.TextVisible = False
            clearItem.Name = "clearItem"
        Finally
            layoutControl.EndUpdate()
        End Try
    End Sub

    Private Sub OnSearchTextChanged(ByVal sender As Object, ByVal e As EventArgs)
        If provider.FindMode = FindMode.Always Then
            searchTimer.Stop()
            searchTimer.Start()
        End If
    End Sub

    Private Sub OnSearchTimerTick(ByVal sender As Object, ByVal e As EventArgs)
        searchTimer.Stop()
        If CanSearch Then
            If provider.AllowFilter Then
                RefreshFindPanel()
            Else
                InvalidateFindPanel()
            End If
        End If
    End Sub

    Private Sub OnCustomDrawNodeCell(ByVal sender As Object, ByVal e As CustomDrawNodeCellEventArgs)
        If (Not provider.HighlightFindResults) Then
            Return
        End If
        If (Not SearchText.Equals(String.Empty)) AndAlso (ContainsSearchText(e.Column, e.Node) OrElse provider.FindFilterColumns.Equals("*")) Then
            Dim index As Integer = e.CellText.ToLower().IndexOf(SearchText.ToLower())
            If index = -1 Then
                Return
            End If
            Dim viewInfo As TextEditViewInfo = TryCast(e.EditViewInfo, TextEditViewInfo)
            If viewInfo Is Nothing Then
                Return
            End If
            e.Appearance.FillRectangle(e.Cache, e.Bounds)
            e.Cache.Paint.DrawMultiColorString(e.Cache, viewInfo.MaskBoxRect, e.CellText, SearchText, e.Appearance, Color.Black, Color.Orange, True, index)
            DrawButtons(e)
            e.Handled = True
        End If
    End Sub

    Private Sub DrawButtons(ByVal e As CustomDrawNodeCellEventArgs)
        Dim viewInfo As ButtonEditViewInfo = TryCast(e.EditViewInfo, ButtonEditViewInfo)
        If viewInfo IsNot Nothing Then
            For Each args As EditorButtonObjectInfoArgs In viewInfo.LeftButtons
                args.Cache = e.Cache
                viewInfo.EditorButtonPainter.DrawObject(args)
            Next args
            For Each args As EditorButtonObjectInfoArgs In viewInfo.RightButtons
                args.Cache = e.Cache
                viewInfo.EditorButtonPainter.DrawObject(args)
            Next args
        End If
    End Sub

    Private Sub OnFilterNode(ByVal sender As Object, ByVal e As FilterNodeEventArgs)
        If (Not provider.AllowFilter) Then
            Return
        End If
        If (Not Find(e.Node)) Then
            e.Node.Visible = False
            e.Handled = True
        End If
    End Sub

    Private Sub OnClearButtonClick(ByVal sender As Object, ByVal e As EventArgs)
        SearchText = String.Empty
        RefreshFindPanel()
    End Sub

    Private Sub OnCloseButtonClick(ByVal sender As Object, ByVal e As EventArgs)
        PrepareTree()
        provider.HideFindPanel()
    End Sub

    Private Sub OnFindButtonClick(ByVal sender As Object, ByVal e As EventArgs)
        If provider.AllowFilter Then
            RefreshFindPanel()
        Else
            InvalidateFindPanel()
        End If
    End Sub

    Public Function Find(ByVal node As TreeListNode) As Boolean
        If SearchText.Equals(String.Empty) Then
            Return True
        End If
        If provider.FindFilterColumns.Equals("*") Then
            For i As Integer = 0 To tree.VisibleColumns.Count - 1
                If ContainsSearchText(tree.VisibleColumns(i), node) Then
                    Return True
                End If
            Next i
        Else
            Dim fieldNames() As String = provider.FindFilterColumns.Trim().Split(";"c)
            For Each fieldName As String In fieldNames
                If ContainsSearchText(tree.VisibleColumns(fieldName), node) Then
                    Return True
                End If
            Next fieldName
        End If
        Return False
    End Function

    Private Function ContainsSearchText(ByVal column As TreeListColumn, ByVal node As TreeListNode) As Boolean
        If column Is Nothing Then
            Return True
        End If
        Dim txt As String = node.GetDisplayText(column).ToLower()
        Return txt.Contains(SearchText.ToLower())
    End Function

    Private ReadOnly Property CanSearch() As Boolean
        Get
            Return Not prevSearchText.Equals(SearchText)
        End Get
    End Property

    Friend Sub PrepareTree()
        Controls.Remove(tree)
        tree.Dock = Dock
        tree.Parent = Parent
        tree.Location = Location
        tree.Size = Size
    End Sub

    Friend Sub RefreshFindPanel()
        prevSearchText = SearchText
        tree.RefreshDataSource()
    End Sub

    Friend Sub InvalidateFindPanel()
        tree.InvalidateNodes()
    End Sub

    Friend Sub ShowCloseButton()
        closeItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
    End Sub

    Friend Sub HideCloseButton()
        closeItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
    End Sub

    Friend Sub StopSearchTimer()
        searchTimer.Stop()
    End Sub

    Friend Sub RefreshSearchTimerInterval()
        searchTimer.Interval = provider.FindDelay
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If tree IsNot Nothing Then
                RemoveHandler tree.FilterNode, AddressOf OnFilterNode
                RemoveHandler tree.CustomDrawNodeCell, AddressOf OnCustomDrawNodeCell
            End If
            If searchEdit IsNot Nothing Then
                RemoveHandler searchEdit.EditValueChanged, AddressOf OnSearchTextChanged
            End If
            If findButton IsNot Nothing Then
                RemoveHandler findButton.Click, AddressOf OnFindButtonClick
            End If
            If closeButton IsNot Nothing Then
                RemoveHandler closeButton.Click, AddressOf OnCloseButtonClick
            End If
            If clearButton IsNot Nothing Then
                RemoveHandler clearButton.Click, AddressOf OnClearButtonClick
            End If
            If searchTimer IsNot Nothing Then
                RemoveHandler searchTimer.Tick, AddressOf OnSearchTimerTick
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
End Class
