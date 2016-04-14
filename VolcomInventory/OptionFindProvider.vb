Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports DevExpress.Skins
Imports System.ComponentModel
Imports DevExpress.XtraTreeList
Imports DevExpress.Utils.Serializing
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base

Public Class OptionFindProvider
    Private tree As TreeList
    Private findPanel As FindPanel
    Private allowFilter_Renamed, clearFindOnClose_Renamed, highlightFindResults_Renamed, showCloseButton_Renamed As Boolean
    Private findDelay_Renamed As Integer
    Private findFilterColumns_Renamed, savedSearchString As String
    Private findMode_Renamed As FindMode

    Public Sub New(ByVal tree As TreeList)
        Me.tree = tree
        FindFilterColumns = "*"
        ClearFindOnClose = True
        HighlightFindResults = True
        ShowCloseButton = True
        FindDelay = 1000
        AllowFilter = False
        savedSearchString = String.Empty
    End Sub

    Public Property AllowFilter() As Boolean
        Get
            Return allowFilter_Renamed
        End Get
        Set(ByVal value As Boolean)
            If allowFilter_Renamed <> value Then
                allowFilter_Renamed = value
                If findPanel IsNot Nothing Then
                    findPanel.RefreshFindPanel()
                End If
            End If
        End Set
    End Property

    Public Property ClearFindOnClose() As Boolean
        Get
            Return clearFindOnClose_Renamed
        End Get
        Set(ByVal value As Boolean)
            If clearFindOnClose_Renamed <> value Then
                clearFindOnClose_Renamed = value
            End If
        End Set
    End Property

    Public Property FindDelay() As Integer
        Get
            Return findDelay_Renamed
        End Get
        Set(ByVal value As Integer)
            If findDelay_Renamed <> value Then
                If findDelay_Renamed < 1000 Then
                    findDelay_Renamed = 1000
                Else
                    findDelay_Renamed = value
                End If
                If findPanel IsNot Nothing Then
                    findPanel.RefreshSearchTimerInterval()
                End If
            End If
        End Set
    End Property

    Public Property FindFilterColumns() As String
        Get
            Return findFilterColumns_Renamed
        End Get
        Set(ByVal value As String)
            If findFilterColumns_Renamed <> value Then
                findFilterColumns_Renamed = value
                If findPanel IsNot Nothing Then
                    findPanel.RefreshFindPanel()
                End If
            End If
        End Set
    End Property

    Public Property FindMode() As FindMode
        Get
            Return findMode_Renamed
        End Get
        Set(ByVal value As FindMode)
            If findMode_Renamed <> value Then
                findMode_Renamed = value
                If findPanel IsNot Nothing AndAlso findMode_Renamed = FindMode.FindClick Then
                    findPanel.StopSearchTimer()
                End If
            End If
        End Set
    End Property

    Public Property HighlightFindResults() As Boolean
        Get
            Return highlightFindResults_Renamed
        End Get
        Set(ByVal value As Boolean)
            If highlightFindResults_Renamed <> value Then
                highlightFindResults_Renamed = value
                If findPanel IsNot Nothing Then
                    findPanel.InvalidateFindPanel()
                End If
            End If
        End Set
    End Property

    Public Property ShowCloseButton() As Boolean
        Get
            Return showCloseButton_Renamed
        End Get
        Set(ByVal value As Boolean)
            If showCloseButton_Renamed <> value Then
                showCloseButton_Renamed = value
                If findPanel IsNot Nothing Then
                    If showCloseButton_Renamed Then
                        findPanel.ShowCloseButton()
                    Else
                        findPanel.HideCloseButton()
                    End If
                End If
            End If
        End Set
    End Property

    Private Sub CreateFindPanel()
        findPanel = New FindPanel(Me, tree)
    End Sub

    Public Sub ShowFindPanel()
        If findPanel IsNot Nothing Then
            Return
        End If
        CreateFindPanel()
        If (Not ClearFindOnClose) Then
            findPanel.SearchText = savedSearchString
        End If
    End Sub

    Public Sub HideFindPanel()
        If findPanel Is Nothing Then
            Return
        End If
        If (Not ClearFindOnClose) Then
            savedSearchString = findPanel.SearchText
        End If
        findPanel.PrepareTree()
        DestroyFindPanel()
    End Sub

    Private Sub DestroyFindPanel()
        findPanel.Dispose()
        findPanel = Nothing
    End Sub
End Class

Public Enum FindMode
    FindClick
    Always
End Enum
