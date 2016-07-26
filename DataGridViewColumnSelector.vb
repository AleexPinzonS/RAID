Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing

'http://www.codeproject.com/Articles/31987/A-DataGridView-Column-Show-Hide-Popup

Public Class DataGridViewColumnSelector
    ' the DataGridView to which the DataGridViewColumnSelector is attached
    Private WithEvents mDataGridView As DataGridView = Nothing
    ' a CheckedListBox containing the column header text and checkboxes
    Public WithEvents mCheckedListBox As New CheckedListBox
    'Private mCheckedListBox As CheckedListBox 'original code
    ' a ToolStripDropDown object used to show the popup
    Private mPopup As ToolStripDropDown

    ''' <summary>
    ''' The max height of the popup
    ''' </summary>
    Public MaxHeight As Integer = 300
    ''' <summary>
    ''' The width of the popup
    ''' </summary>
    Public Width As Integer = 200
    'Public Event mDataGridView_CellMouseClick()
    ''' <summary>
    ''' Gets or sets the DataGridView to which the DataGridViewColumnSelector is attached
    ''' </summary>
    Public Property DataGridView() As DataGridView
        Get
            Return mDataGridView
        End Get

        Set(ByVal value As DataGridView)
            ' If any, remove handler from current DataGridView 
            If Not (mDataGridView Is Nothing) Then
                'mDataGridView.CellMouseClick -= New DataGridViewCellMouseEventHandler(AddressOf mDataGridView_CellMouseClick)
                RemoveHandler mDataGridView.CellMouseClick, New DataGridViewCellMouseEventHandler(AddressOf mDataGridView_CellMouseClick)
            End If
            ' Set the new DataGridView
            mDataGridView = value
            ' Attach CellMouseClick handler to DataGridView
            If Not (mDataGridView Is Nothing) Then
                'mDataGridView.CellMouseClick += New DataGridViewCellMouseEventHandler(AddressOf mDataGridView_CellMouseClick)
                AddHandler mDataGridView.CellMouseClick, New DataGridViewCellMouseEventHandler(AddressOf mDataGridView_CellMouseClick)
            End If
        End Set
    End Property

    ' When user right-clicks the cell origin, it clears and fill the CheckedListBox with
    ' columns header text. Then it shows the popup. 
    ' In this way the CheckedListBox items are always refreshed to reflect changes occurred in 
    ' DataGridView columns (column additions or name changes and so on).
    'Public Event mDataGridView_CellMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs)

    Private Sub mDataGridView_CellMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles mDataGridView.CellMouseClick   'original code
        If e.Button = MouseButtons.Right AndAlso e.RowIndex = -1 AndAlso e.ColumnIndex = -1 Then
            mCheckedListBox.Items.Clear()
            For Each c As DataGridViewColumn In mDataGridView.Columns
                mCheckedListBox.Items.Add(c.HeaderText, c.Visible)
            Next
            Dim PreferredHeight As Integer = (mCheckedListBox.Items.Count * 16) + 7
            mCheckedListBox.Height = If((PreferredHeight < MaxHeight), PreferredHeight, MaxHeight)
            mCheckedListBox.Width = Me.Width
            mPopup.Show(mDataGridView.PointToScreen(New Point(e.X, e.Y)))
        End If
    End Sub
    'end event

    ' The constructor creates an instance of CheckedListBox and ToolStripDropDown.
    ' the CheckedListBox is hosted by ToolStripControlHost, which in turn is
    ' added to ToolStripDropDown.
    Public Sub New()
        mCheckedListBox = New CheckedListBox()
        mCheckedListBox.CheckOnClick = True
        'mCheckedListBox.ItemCheck += New ItemCheckEventHandler(AddressOf mCheckedListBox_ItemCheck)
        AddHandler mCheckedListBox.ItemCheck, New ItemCheckEventHandler(AddressOf mCheckedListBox_ItemCheck)

        Dim mControlHost As New ToolStripControlHost(mCheckedListBox)
        mControlHost.Padding = Padding.Empty
        mControlHost.Margin = Padding.Empty
        mControlHost.AutoSize = False

        mPopup = New ToolStripDropDown()
        mPopup.Padding = Padding.Empty
        mPopup.Items.Add(mControlHost)
    End Sub

    ' When user checks / unchecks a checkbox, the related column visibility is 
    ' switched.
    Private Sub mCheckedListBox_ItemCheck(ByVal sender As Object, ByVal e As ItemCheckEventArgs) Handles mCheckedListBox.ItemCheck
        mDataGridView.Columns(e.Index).Visible = (e.NewValue = CheckState.Checked)
    End Sub

    Public Sub New(ByVal dgv As DataGridView)
        Me.New()
        Me.DataGridView = dgv
    End Sub
End Class
