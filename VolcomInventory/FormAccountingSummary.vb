Imports System.Linq
Imports DevExpress.XtraEditors
Imports DevExpress.XtraTreeList
Imports System.Collections.Generic
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraTreeList.Columns

Public Class FormAccountingSummary
    Dim fromdate As String = "0001-01-01"
    Dim enddate As String = "9999-01-01"

    Private Sub FormAccountingSummary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CreateNodes(TreeList1)
    End Sub

    Private Sub FormAccountingSummary_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormAccountingSummary_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormAccountingSummary_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    Sub CreateNodes(ByVal tl As DevExpress.XtraTreeList.TreeList)
        tl.ClearNodes()
        tl.BeginUnboundLoad()
        ' Create a root node .
        Dim parentForRootNodes As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
        'root
        Dim query As String = "SELECT a.id_acc,acc_name,a.id_acc_parent,a.acc_description,CAST(IFNULL(entry.debit,0) AS DECIMAL(13,2)) AS debit,CAST(IFNULL(entry.credit,0) AS DECIMAL(13,2)) AS credit,a.id_acc_cat,b.acc_cat,a.id_status,c.status,a.id_is_det,d.is_det,a.id_status,'' as id_all_child FROM tb_a_acc a"
        query += " INNER JOIN tb_lookup_acc_cat b ON a.id_acc_cat=b.id_acc_cat "
        query += " INNER JOIN tb_lookup_status c ON a.id_status=c.id_status "
        query += " INNER JOIN tb_lookup_is_det d ON a.id_is_det=d.id_is_det"
        query += " LEFT JOIN ("
        query += " SELECT id_acc,SUM(debit) AS debit,SUM(credit) AS credit FROM"
        query += " ("
        query += " SELECT id_acc,SUM(debit) AS debit,SUM(credit) AS credit FROM tb_a_acc_trans_det a INNER JOIN tb_a_acc_trans b ON a.id_acc_trans=b.id_acc_trans WHERE (DATE(b.date_created) <= '" & enddate & "') AND (DATE(b.date_created) >= '" & fromdate & "') GROUP BY id_acc"
        query += " UNION"
        query += " SELECT id_acc,SUM(debit) AS debit,SUM(credit) AS credit FROM tb_a_acc_trans_adj_det a INNER JOIN tb_a_acc_trans_adj b ON a.id_acc_trans_adj=b.id_acc_trans_adj WHERE (DATE(b.date_created) <= '" & enddate & "') AND (DATE(b.date_created) >= '" & fromdate & "') GROUP BY id_acc"
        query += " ) a GROUP BY id_acc"
        query += " ) entry ON entry.id_acc=a.id_acc"
        'query += " WHERE a.id_acc_parent=a.id_acc"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Dim data_filter As DataRow() = data.Select("[id_acc_parent] is NULL AND [id_status]='1'")

        'MsgBox(data_filter.Length.ToString)

        For i As Integer = 0 To data_filter.Length - 1
            Dim rootNode As DevExpress.XtraTreeList.Nodes.TreeListNode = tl.AppendNode(New Object() {data_filter(i)("id_acc").ToString, data_filter(i)("id_acc_parent").ToString, data_filter(i)("acc_name").ToString, data_filter(i)("acc_description").ToString, data_filter(i)("debit"), data_filter(i)("credit"), data_filter(i)("id_all_child")}, parentForRootNodes)
            recursive_nodes(data_filter(i)("id_acc").ToString, rootNode, tl, data)
        Next

        ' Create a child node for the node1            
        'tl.AppendNode(New Object() {"Suyama, Michael", "Obere Str. 55", "030-0074263"}, rootNode)
        ' Creating more nodes
        ' ...

        tl.EndUnboundLoad()
        tl.ExpandAll()
    End Sub
    Sub recursive_nodes(ByVal id_acc As String, ByVal parent_nodes As DevExpress.XtraTreeList.Nodes.TreeListNode, ByVal tl As DevExpress.XtraTreeList.TreeList, ByVal data_table As DataTable)
        Dim data_filter As DataRow() = data_table.Select("[id_acc_parent]='" & id_acc & "' AND [id_status]='1'")

        If data_filter.Length > 0 Then
            For i As Integer = 0 To data_filter.Length - 1
                Dim newNode As DevExpress.XtraTreeList.Nodes.TreeListNode = tl.AppendNode(New Object() {data_filter(i)("id_acc").ToString, data_filter(i)("id_acc_parent").ToString, data_filter(i)("acc_name").ToString, data_filter(i)("acc_description").ToString, data_filter(i)("debit"), data_filter(i)("credit"), data_filter(i)("id_all_child")}, parent_nodes)
                recursive_nodes(data_filter(i)("id_acc").ToString, newNode, tl, data_table)
                parent_nodes.SetValue("debit", parent_nodes.GetValue("debit") + newNode.GetValue("debit"))
                parent_nodes.SetValue("credit", parent_nodes.GetValue("credit") + newNode.GetValue("credit"))
                If data_filter(i)("id_is_det").ToString = "2" Then
                    If parent_nodes.GetValue("id_all_child") = "" Then
                        parent_nodes.SetValue("id_all_child", data_filter(i)("id_acc").ToString)
                    Else
                        parent_nodes.SetValue("id_all_child", parent_nodes.GetValue("id_all_child").ToString & "," & data_filter(i)("id_acc").ToString)
                    End If
                    newNode.SetValue("id_all_child", data_filter(i)("id_acc").ToString)
                Else
                    If Not newNode.GetValue("id_all_child").ToString = "" Then
                        If parent_nodes.GetValue("id_all_child") = "" Then
                            parent_nodes.SetValue("id_all_child", newNode.GetValue("id_all_child").ToString)
                        Else
                            parent_nodes.SetValue("id_all_child", parent_nodes.GetValue("id_all_child").ToString & "," & newNode.GetValue("id_all_child").ToString)
                        End If
                    End If
                End If
            Next
        End If
    End Sub
    Private SavedFocused As TreeListNode
    Private NeedRestoreFocused As Boolean

    Private Sub treeList1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TreeList1.MouseUp
        Dim tree As TreeList = TryCast(sender, TreeList)
        If e.Button = MouseButtons.Right AndAlso ModifierKeys = Keys.None AndAlso tree.State = TreeListState.Regular Then
            Dim pt As Point = tree.PointToClient(MousePosition)
            Dim info As TreeListHitInfo = tree.CalcHitInfo(pt)
            If info.HitInfoType = HitInfoType.Cell Then
                SavedFocused = tree.FocusedNode
                Dim SavedTopIndex As Integer = tree.TopVisibleNodeIndex
                tree.FocusedNode = info.Node
                NeedRestoreFocused = True
                BalanceMenu.Show(Cursor.Position)
            End If
        End If
    End Sub

    Private Sub SMViewTransaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SMViewTransaction.Click
        FormAccountingTrs.id_pop_up = "2"
        FormAccountingTrs.fromdate = fromdate
        FormAccountingTrs.DEFrom.EditValue = DEFrom.EditValue
        FormAccountingTrs.DETo.EditValue = DETo.EditValue
        FormAccountingTrs.enddate = enddate
        FormAccountingTrs.id_acc = TreeList1.FocusedNode.GetValue("id_acc").ToString
        FormAccountingTrs.id_acc_child = TreeList1.FocusedNode.GetValue("id_all_child").ToString
        FormAccountingTrs.ShowDialog()
    End Sub

    Private Sub BView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BView.Click
        If DEFrom.Text = "" Then
            fromdate = "0001-01-01"
        Else
            fromdate = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyy-MM-dd")
        End If
        If DETo.Text = "" Then
            enddate = "9999-01-01"
        Else
            enddate = DateTime.Parse(DETo.EditValue.ToString).ToString("yyy-MM-dd")
        End If
        CreateNodes(TreeList1)
    End Sub
End Class