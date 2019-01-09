Imports System
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Registrator
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Base.Handler

Namespace MyXtraGrid
    Public Class MyGridViewInfo
        Inherits GridViewInfo

        Public Sub New(ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView)
            MyBase.New(gridView)
        End Sub

        Public Overrides Function CalcRowHeight(ByVal graphics As Graphics, ByVal rowHandle As Integer, ByVal min As Integer, ByVal level As Integer, ByVal useCache As Boolean, ByVal columns As GridColumnsInfo) As Integer
            Return MyBase.CalcRowHeight(graphics, rowHandle, MinRowHeight, level, useCache, columns)
        End Function

        Public Overrides ReadOnly Property MinRowHeight() As Integer
            Get
                Return MyBase.MinRowHeight - 2
            End Get
        End Property
    End Class

    Public Class MyGridControl
        Inherits GridControl

        Protected Overrides Function CreateDefaultView() As BaseView
            Return CreateView("MyGridView")
        End Function
    End Class
    Public Class MyGridView
        Inherits DevExpress.XtraGrid.Views.Grid.GridView

        Public Sub New()
            Me.New(Nothing)
        End Sub
        Public Sub New(ByVal grid As DevExpress.XtraGrid.GridControl)
            MyBase.New(grid)
            ' put your initialization code here
        End Sub
        Protected Overrides ReadOnly Property ViewName() As String
            Get
                Return "MyGridView"
            End Get
        End Property
    End Class

    Public Class MyGridHandler
        Inherits DevExpress.XtraGrid.Views.Grid.Handler.GridHandler

        Public Sub New(ByVal gridView As GridView)
            MyBase.New(gridView)
        End Sub

    End Class

    Public Class MyGridViewInfoRegistrator
        Inherits GridInfoRegistrator

        Public Overrides ReadOnly Property ViewName() As String
            Get
                Return "MyGridView"
            End Get
        End Property
        Public Overrides Function CreateView(ByVal grid As GridControl) As BaseView
            Return New MyGridView(TryCast(grid, GridControl))
        End Function
        Public Overrides Function CreateViewInfo(ByVal view As BaseView) As BaseViewInfo
            Return New MyGridViewInfo(TryCast(view, MyGridView))
        End Function
        Public Overrides Function CreateHandler(ByVal view As BaseView) As BaseViewHandler
            Return New MyGridHandler(TryCast(view, MyGridView))
        End Function
    End Class
End Namespace