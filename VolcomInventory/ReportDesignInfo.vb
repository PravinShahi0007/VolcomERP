Public Class ReportDesignInfo
    Sub setCaptionSize(ByVal gv As DevExpress.XtraGrid.Views.Grid.GridView)
        'avl
        gv.Columns("avl_qty1").Caption = "1" + System.Environment.NewLine + "XXS"
        gv.Columns("avl_qty2").Caption = "2" + System.Environment.NewLine + "XS"
        gv.Columns("avl_qty3").Caption = "3" + System.Environment.NewLine + "S"
        gv.Columns("avl_qty4").Caption = "4" + System.Environment.NewLine + "M"
        gv.Columns("avl_qty5").Caption = "5" + System.Environment.NewLine + "ML"
        gv.Columns("avl_qty6").Caption = "6" + System.Environment.NewLine + "L"
        gv.Columns("avl_qty7").Caption = "7" + System.Environment.NewLine + "XL"
        gv.Columns("avl_qty8").Caption = "8" + System.Environment.NewLine + "XXL"
        gv.Columns("avl_qty9").Caption = "9" + System.Environment.NewLine + "ALL"
        gv.Columns("avl_qty0").Caption = "0" + System.Environment.NewLine + "SM"
        'rsv
        gv.Columns("rsv_qty1").Caption = "1" + System.Environment.NewLine + "XXS"
        gv.Columns("rsv_qty2").Caption = "2" + System.Environment.NewLine + "XS"
        gv.Columns("rsv_qty3").Caption = "3" + System.Environment.NewLine + "S"
        gv.Columns("rsv_qty4").Caption = "4" + System.Environment.NewLine + "M"
        gv.Columns("rsv_qty5").Caption = "5" + System.Environment.NewLine + "ML"
        gv.Columns("rsv_qty6").Caption = "6" + System.Environment.NewLine + "L"
        gv.Columns("rsv_qty7").Caption = "7" + System.Environment.NewLine + "XL"
        gv.Columns("rsv_qty8").Caption = "8" + System.Environment.NewLine + "XXL"
        gv.Columns("rsv_qty9").Caption = "9" + System.Environment.NewLine + "ALL"
        gv.Columns("rsv_qty0").Caption = "0" + System.Environment.NewLine + "SM"
        'ttl
        gv.Columns("ttl_qty1").Caption = "1" + System.Environment.NewLine + "XXS"
        gv.Columns("ttl_qty2").Caption = "2" + System.Environment.NewLine + "XS"
        gv.Columns("ttl_qty3").Caption = "3" + System.Environment.NewLine + "S"
        gv.Columns("ttl_qty4").Caption = "4" + System.Environment.NewLine + "M"
        gv.Columns("ttl_qty5").Caption = "5" + System.Environment.NewLine + "ML"
        gv.Columns("ttl_qty6").Caption = "6" + System.Environment.NewLine + "L"
        gv.Columns("ttl_qty7").Caption = "7" + System.Environment.NewLine + "XL"
        gv.Columns("ttl_qty8").Caption = "8" + System.Environment.NewLine + "XXL"
        gv.Columns("ttl_qty9").Caption = "9" + System.Environment.NewLine + "ALL"
        gv.Columns("ttl_qty0").Caption = "0" + System.Environment.NewLine + "SM"
    End Sub

    Private Sub ReportDesignInfo_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        setCaptionSize(GVSOHCode)
    End Sub
End Class