Imports System
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraTreeList
Imports DevExpress.Utils.Paint
Imports System.Drawing

Public Class MyTreeListSearchHelper
    Public i As Integer = 1
    Public Sub New(ByVal treeList As TreeList)
        _TreeList = treeList
        AddHandler _TreeList.CustomDrawNodeCell, AddressOf _TreeList_CustomDrawNodeCell
        AddHandler _TreeList.FocusedNodeChanged, AddressOf _TreeList_FocusedNodeChanged
    End Sub

    Private Sub _TreeList_FocusedNodeChanged(ByVal sender As Object, ByVal e As FocusedNodeChangedEventArgs)
        CurrentNode = e.Node
    End Sub

    Private paint As New XPaint()
    Private Sub _TreeList_CustomDrawNodeCell(ByVal sender As Object, ByVal e As CustomDrawNodeCellEventArgs)
        Dim index As Integer = e.CellText.ToUpper.IndexOf(Text.ToUpper, 0)
        If index >= 0 AndAlso e.Column.FieldName = FieldName And Not Text = "" Then
            e.Handled = True
            If e.Node.Focused AndAlso e.Column.FieldName = FieldName Then
                paint.DrawMultiColorString(e.Cache, e.Bounds, e.CellText, Text, e.Appearance, Color.Red, Color.Yellow, False, index)
            Else
                paint.DrawMultiColorString(e.Cache, e.Bounds, e.CellText, Text, e.Appearance, Color.Blue, e.Appearance.GetBackColor(), False, index)
            End If
        End If
    End Sub

    Private _CurrentNode As TreeListNode
    Private ReadOnly _TreeList As TreeList

    Public Property CurrentNode() As TreeListNode
        Get
            If _CurrentNode Is Nothing Then
                Return _TreeList.FocusedNode
            Else
                Return _CurrentNode
            End If
        End Get
        Set(ByVal value As TreeListNode)
            _CurrentNode = value
        End Set
    End Property

    Private _FieldName As String
    Public Property FieldName() As String
        Get
            Return _FieldName
        End Get
        Set(ByVal value As String)
            _FieldName = value
        End Set
    End Property

    Private _Text As String
    Public Property Text() As String
        Get
            Return _Text
        End Get
        Set(ByVal value As String)
            _Text = value
        End Set
    End Property

    Public Sub FindNext()
        PerformSearch(True)
    End Sub

    Public Sub FindPrev()
        PerformSearch(False)
    End Sub

    Public Sub PerformSearch(ByVal forward As Boolean)
        CurrentNode = FindNode(forward)
    End Sub

    Private Function FindNode(ByVal forward As Boolean) As TreeListNode
        If CurrentNode Is Nothing Then
            Return CurrentNode
        End If
        If Text = "" Then
            Return CurrentNode
        End If
        Dim node As TreeListNode = GetNextNode(CurrentNode, forward)
        If node Is Nothing Then
            Return node
        End If
        Do While Not MatchCondition(node)
            node = GetNextNode(node, forward)
        Loop
        Return node
    End Function
    Private Function GetNextNode(ByVal node As TreeListNode, ByVal forward As Boolean) As TreeListNode
        node.ExpandAll()
        If node.Equals(_TreeList.Nodes.LastNode) Then
            Return _TreeList.Nodes.FirstNode
        Else
            If forward Then
                Return node.NextVisibleNode
            Else
                Return node.NextVisibleNode
            End If
        End If
    End Function
    Private Function MatchCondition(ByVal node As TreeListNode) As Boolean
        'Console.WriteLine(node.GetDisplayText("id_acc").ToString)
        If node Is Nothing Then
            Return True
        End If
        If node.Equals(CurrentNode) Then
            Return True
            'If i = 1 Then
            '    i = 2
            'Else
            '    i = 1
            '    Return True
            'End If
        End If
        If node.GetDisplayText(FieldName).ToUpper.Contains(Text.ToUpper) Then
            Return True
        End If
        Return False
    End Function
End Class
