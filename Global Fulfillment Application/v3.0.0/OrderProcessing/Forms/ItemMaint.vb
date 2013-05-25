Imports System
Imports System.Text
Imports System.Windows.Forms
Imports System.Xml

Imports OrderProcessingLibrary
Imports OrderProcessingLibrary.DataObjects
Imports OrderProcessingLibrary.Exceptions
Imports OrderProcessingLibrary.Utilities
Imports Logger = OrderProcessingLibrary.Utilities.LogFileListener
Imports Settings = OrderProcessingLibrary.Utilities.AppSettings

Public Class ItemMaint

#Region "Event Handlers"

    ''' <summary>
    ''' Button_Click event handler
    ''' </summary>
    ''' <param name="sender">Buttons used for adding/removing subitems from the listbox.</param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs) _
                Handles btnAddSubItem.Click, btnRemoveSubItem.Click

        Dim btn As Button = sender

        Select Case btn.Tag
            Case "AddSubItem"
                AddSubItem()
            Case "RemoveSubItem"
                RemoveSubItem()
        End Select

    End Sub

    ''' <summary>
    ''' HLW_Keypress event handler.
    ''' </summary>
    ''' <param name="sender">Textbox control which raised the event.</param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' This handler will make sure that only numeric values (or a decimal point) are entered in these controls.
    ''' </remarks>
    Private Sub HLW_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) _
                Handles txtLength.KeyPress, txtHeight.KeyPress, txtWidth.KeyPress

        If Not _digits.Contains(e.KeyChar.ToString()) Then
            e.KeyChar = Nothing
            Beep()
        End If

    End Sub

    ''' <summary>
    ''' ItemMaint_Load event handler
    ''' </summary>
    ''' <param name="sender">ItemMaint.frm</param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ItemMaint_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        ' Set sizes.
        Me.Width = 530
        Me.Height = 400
        grpSubItems.Height = 136

        ' Hide these two toolbar buttons.
        tsbtnCancel.Visible = False
        tsbtnSave.Visible = False

        'Set the "mode".
        _mode = ModeEnum.Normal

        ' Set up the various control properties.
        SetControls()

        ' The first item should already be in the "current" variable, so tie the values to the
        ' applicable controls.
        BindControls()

    End Sub

    ''' <summary>
    ''' ToolStripButton_Click event handler
    ''' </summary>
    ''' <param name="sender">Object that raised the event.</param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' This handler will capture all of the ToolStripButton click events, and pass control
    ''' to the appropriate routine.
    ''' </remarks>
    Private Sub ToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) _
                Handles tsbtnPrevious.Click, tsbtnNext.Click, tsbtnNew.Click, _
                        tsbtnEdit.Click, tsbtnCopy.Click, tsbtnDelete.Click, _
                        tsbtnCancel.Click, tsbtnFind.Click, tsbtnSave.Click, tsbtnExit.Click

        Dim btn As ToolStripButton = sender

        Select Case btn.Tag

            Case "Previous"
                ' Move to the previous item in the list.
                NextItem(Direction.Backward)

            Case "Next"
                ' Move to the next item in the list.
                NextItem(Direction.Forward)

            Case "New"
                ' Create a new item, and add it to the list.
                NewItem()

            Case "Edit"
                ' Change one or more values for the selected item.
                EditItem()

            Case "Copy"
                ' Create a copy of the current item, and leaves it in edit mode.
                CopyItem()

            Case "Delete"
                ' Delete an item from the list.
                DeleteItem()

            Case "Save"
                ' Save new or updated item.
                SaveItem()

            Case "Find"
                ' Find an item by item number.
                FindItem()

            Case "Cancel"

                Dim modeMsg As String = ""
                Select Case _mode
                    Case ModeEnum.Create
                        modeMsg = "Cancel creating new item?"
                    Case ModeEnum.Edit
                        modeMsg = "Cancel editing item?"
                    Case ModeEnum.Copy
                        modeMsg = "Cancel copying item?"
                End Select

                ' Prompt user for verification of Cancel.
                Dim rslt As DialogResult = _
                    MessageBox.Show(modeMsg, "Cancel", MessageBoxButtons.YesNo, _
                                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If rslt = Windows.Forms.DialogResult.Yes Then
                    ' Cancel changes.
                    SwitchMode(ModeEnum.Cancel)
                    SetControls()
                End If

            Case "Exit"
                ' Close the form.
                Close()

        End Select

    End Sub

    ''' <summary>
    ''' SubItem_TextChanged event handler
    ''' </summary>
    ''' <param name="sender">txtAddSubItem</param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' Used to enable/disable the "Add" sub item button.
    ''' </remarks>
    Private Sub SubItem_TextChanged(ByVal sender As Object, ByVal e As EventArgs) _
                Handles txtAddSubItem.TextChanged

        'The button will only be enabled if the control contains text.
        btnAddSubItem.Enabled = (txtAddSubItem.Text.Trim() <> "")

    End Sub

    ''' <summary>
    ''' SubItems_SelectedIndexChanged event handler
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' Used to enable/disable the "Remove" sub item button.  The button will only be enabled
    ''' if an item is currently selected.
    ''' </remarks>
    Private Sub SubItems_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
                Handles lstboxSubItems.SelectedIndexChanged

        ' SelectedIndex = -1 means no selected items.
        btnRemoveSubItem.Enabled = (lstboxSubItems.SelectedIndex > -1)

    End Sub

#End Region


#Region "Private Members"

    Private _itemList As Products
    Private _currentItem As Product = Nothing
    Private _mode As ModeEnum = ModeEnum.Normal
    Private _prevMode As ModeEnum = ModeEnum.Normal
    Private _digits As String = "0123456789."

    ' Enumerator used to designate the current mode of the form. 
    Private Enum ModeEnum
        Normal
        Create
        Edit
        Copy
        Cancel
    End Enum

    ' Enumerator used to indicate direction of movement thru the item list.
    Private Enum Direction
        Backward
        Forward
    End Enum

#End Region


#Region "Private Methods"

    ''' <summary>
    ''' AddSubItem method
    ''' </summary>
    ''' <remarks>
    ''' This method is used when building or editing a "kit" item.  It adds an item number to
    ''' the "sub-items" listbox control.</remarks>
    Private Sub AddSubItem()

        Dim newSubItem As String = txtAddSubItem.Text.Trim()

        ' Verify this item is in the master item list.
        If Not _itemList.Exists(newSubItem) Then
            Dim sb As New StringBuilder()
            sb.AppendLine("'" & newSubItem & "' is not a valid item number.")
            sb.AppendLine()
            sb.AppendLine("Item numbers must exist in the Master Item List")
            sb.AppendLine("before they can be added as sub-items of a kit.")
            MessageBox.Show(sb.ToString(), "Invalid Item Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        ' Verify that the subitem isn't already in the list.
        If lstboxSubItems.Items.Count > 0 Then
            For Each subItem As Object In lstboxSubItems.Items
                If subItem.ToString() = newSubItem Then
                    MessageBox.Show("'" & newSubItem & "' is already in the sub-item list.", "Duplicate", _
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            Next
        End If

        ' Add the item to the sub-item list.
        lstboxSubItems.Items.Add(newSubItem)
        txtAddSubItem.Clear()

    End Sub

    ''' <summary>
    ''' BindControls method
    ''' </summary>
    ''' <remarks>
    ''' Loads the various controls with the current item data.
    ''' </remarks>
    Private Sub BindControls()

        ' Load the item number and description.
        txtItemNo.Text = _currentItem.ItemNumber
        txtDescription.Text = _currentItem.Description

        ' Load the dimensions.
        txtHeight.Text = _currentItem.H.ToString()
        txtWidth.Text = _currentItem.W.ToString()
        txtLength.Text = _currentItem.L.ToString()

        ' Set the various "flag" properties.
        chkSinglePack.Checked = _currentItem.SinglePack
        chkShipViaMail.Checked = _currentItem.ShipUSMail
        chkPackException.Checked = _currentItem.PackingException
        chkSignReq.Checked = _currentItem.SignatureRequired

        ' Load the weight and packaging weight.
        txtWeight.Text = _currentItem.Weight
        txtPackagingWeight.Text = _currentItem.PackagingWeight

        ' If this is a "kit" item, load the sub item list.
        lstboxSubItems.Items.Clear()
        If _currentItem.IsKit Then
            For Each subItem As String In _currentItem.SubItems
                lstboxSubItems.Items.Add(subItem)
            Next
        End If

        ' If now positioned at the first item in the list, disable Prev
        tsbtnPrevious.Enabled = Not _itemList.AtFirstItem
        ' If now positioned at the last item in the list, disable Next.
        tsbtnNext.Enabled = Not _itemList.AtLastItem


    End Sub

    ''' <summary>
    ''' CopyItem method
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CopyItem()

        ' Call these two routines to setup the form for copying the current item.
        SwitchMode(ModeEnum.Copy)
        SetControls()

    End Sub

    ''' <summary>
    ''' CreateItem method
    ''' </summary>
    ''' <returns>An Item object</returns>
    ''' <remarks>
    ''' Creates a new Item object using the item number contained in the item number TextBox control,
    ''' then sets the values of the object using the values in the other various controls.
    ''' </remarks>
    Private Function CreateItem() As Product

        Dim i As Integer
        Dim subItemCount As Integer = lstboxSubItems.Items.Count

        ' Create the instance.
        Dim tempItem As New Product(txtItemNo.Text.Trim())

        ' Set the properties
        tempItem.Description = txtDescription.Text.Trim()
        tempItem.H = Integer.Parse(txtHeight.Text)
        tempItem.L = Integer.Parse(txtLength.Text)
        tempItem.W = Integer.Parse(txtWidth.Text)
        tempItem.ShipUSMail = chkShipViaMail.Checked
        tempItem.SinglePack = chkSinglePack.Checked
        tempItem.SignatureRequired = chkSignReq.Checked
        tempItem.PackingException = chkPackException.Checked
        tempItem.Weight = Single.Parse(txtWeight.Text.Trim())
        tempItem.PackagingWeight = Single.Parse(txtPackagingWeight.Text.Trim())

        ' Create the sub-item "list", if applicable.
        If subItemCount > 0 Then
            Dim subItems As String() = {""}
            Array.Resize(subItems, subItemCount)
            For i = 0 To subItemCount - 1
                subItems.SetValue(lstboxSubItems.Items(i).ToString(), i)
            Next
            tempItem.SubItems = subItems
        End If

        Return tempItem

    End Function

    ''' <summary>
    ''' DeleteItem method
    ''' </summary>
    ''' <remarks>
    ''' Method prompts user for a confirmation before deleting the item from the list.  It then
    ''' gets the next item in the list, or the last item if the current last item was the one
    ''' deleted.
    ''' </remarks>
    Private Sub DeleteItem()

        ' Prompt user for confirmation.
        Dim sb As New StringBuilder
        sb.AppendLine("Are you sure you want to delete '" & txtItemNo.Text.Trim() & "' from the list?")
        sb.AppendLine()
        sb.AppendLine("This action cannot be undone.")
        Dim rslt As DialogResult = MessageBox.Show(sb.ToString(), "Confirm", _
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If rslt = Windows.Forms.DialogResult.No Then Return

        Try

            ' Remove the item from the item list.
            _itemList.RemoveItem(_currentItem.ItemNumber)
            MessageBox.Show("Item has been deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Get the new current item from the list.
            _currentItem = _itemList.CurrentItem
            BindControls()

        Catch ex As ItemMaintenanceException

            MessageBox.Show(ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message.ToString(), "Unexpected Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    ''' <summary>
    ''' EditItem method
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EditItem()

        ' Call these two routines to setup the form for editing an item.
        SwitchMode(ModeEnum.Edit)
        SetControls()

    End Sub

    ''' <summary>
    ''' FindItem method.
    ''' </summary>
    ''' <remarks>
    ''' Method first looks for an exact match, and if none found, gets the first item
    ''' number that is greater than the one entered.</remarks>
    Private Sub FindItem()

        ' Prompt user for item number, and verify something was entered.
        Dim itemNum As String = InputBox("Item Number:", "Enter Item to Find").ToUpper
        If String.IsNullOrEmpty(itemNum) Then Return

        Dim tempItem As Product

        If _itemList.Exists(itemNum) Then
            tempItem = _itemList.GetItem(itemNum)
        Else
            tempItem = _itemList.GetNextItem(itemNum)
        End If

        ' Pass the reference to the current item variable, and setup the form.
        _currentItem = tempItem
        BindControls()
        tempItem = Nothing

    End Sub

    ''' <summary>
    ''' NewItem method
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub NewItem()

        ' Call these two routine to setup the form for creating a new item.
        SwitchMode(ModeEnum.Create)
        SetControls()

    End Sub

    ''' <summary>
    ''' NextItem method
    ''' </summary>
    ''' <param name="whichWay">Indicates direction of move.</param>
    ''' <remarks>
    ''' Used by the Prev and Next tool strip buttons.</remarks>
    Private Sub NextItem(ByVal whichWay As Direction)

        Try

            If whichWay = Direction.Forward Then
                _currentItem = _itemList.NextItem
            Else
                _currentItem = _itemList.PreviousItem
            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message.ToString(), "Unexpected Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        ' Bind the controls to the new item.
        BindControls()

    End Sub

    ''' <summary>
    ''' RemoveSubItem method
    ''' </summary>
    ''' <remarks>
    ''' Removes the selected item from the sub-item list box.
    ''' </remarks>
    Private Sub RemoveSubItem()

        ' Remove the selected item from the sub-item list.
        lstboxSubItems.Items.RemoveAt(lstboxSubItems.SelectedIndex)

    End Sub

    ''' <summary>
    ''' SaveItem method
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveItem()

        Try

            ' Create a temp Item object from the current contents of the control.
            Dim tempItem As Product = CreateItem()

            Select Case _mode

                Case ModeEnum.Create, ModeEnum.Copy

                    ' Add the item to the item list.
                    _itemList.AddItem(tempItem)

                    ' Let user know item was successfully added.
                    MessageBox.Show("New item added successfully!", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Display the new item, which now the current item.
                    SwitchMode(ModeEnum.Normal)
                    _currentItem = _itemList.CurrentItem
                    BindControls()
                    SetControls()

                Case ModeEnum.Edit

                    ' Update this item in the item list.
                    _itemList.UpdateItem(tempItem)

                    ' Let user know item was successfully updated.
                    MessageBox.Show("Item updated successfully!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Display the updated item.
                    SwitchMode(ModeEnum.Normal)
                    _currentItem = _itemList.CurrentItem
                    BindControls()
                    SetControls()

            End Select

        Catch ex As DuplicateItemException

            ' This gets thrown when a new item already exists in the item list.
            MessageBox.Show(ex.Message.ToString(), "Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Catch ex As ItemMaintenanceException

            MessageBox.Show(ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message.ToString(), "Unexpected Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    ''' <summary>
    ''' SetControls method
    ''' </summary>
    ''' <remarks>
    ''' Sets up various controls based on the current mode.
    ''' 
    ''' NOTE: Controls were already enabled/disabled in the SwitchMode method.
    ''' </remarks>
    Private Sub SetControls()

        Select Case _mode

            Case ModeEnum.Normal

                ' If canceling a New or Edit, rebind the controls to the previously
                ' current Item object.
                If _prevMode <> ModeEnum.Normal Then
                    BindControls()
                    _prevMode = ModeEnum.Normal
                End If


            Case ModeEnum.Create

                ' Clear the item number and description text boxes.
                txtItemNo.Clear()
                txtDescription.Clear()

                ' Pre-fill the dimension and weight text box controls with zeros.
                txtHeight.Text = "0"
                txtWidth.Text = "0"
                txtLength.Text = "0"
                txtWeight.Text = "0"
                txtPackagingWeight.Text = "0"

                ' Uncheck all checkbox controls. 
                chkSinglePack.Checked = False
                chkShipViaMail.Checked = False
                chkPackException.Checked = False
                chkSignReq.Checked = False

                ' Clear the sub-items listbox control.
                lstboxSubItems.Items.Clear()

                ' Set focus to the Item Number text box control.
                txtItemNo.Focus()

            Case ModeEnum.Edit, ModeEnum.Copy

                ' Set focus to the Item Number text box control.
                txtItemNo.Focus()

        End Select

    End Sub

    ''' <summary>
    ''' SwitchMode method
    ''' </summary>
    ''' <param name="newMode">Enum value indicating the new mode.</param>
    ''' <remarks>
    ''' This method will enable/disable and display/hide various controls, based on the new
    ''' mode being set.
    ''' </remarks>
    Private Sub SwitchMode(ByVal newMode As ModeEnum)

        _prevMode = _mode
        _mode = newMode

        If (_mode = ModeEnum.Normal) Or (_mode = ModeEnum.Cancel) Then

            ' Switch up the toolstrip buttons.
            tsbtnCancel.Visible = False
            tsbtnDelete.Visible = True
            tsbtnSave.Visible = False
            tsbtnFind.Visible = True

            ' Hide all the controls used for New/Edit, and reset the size of the subitems groupbox.
            btnAddSubItem.Visible = False
            txtAddSubItem.Visible = False
            btnRemoveSubItem.Visible = False
            grpSubItems.Height = 136

            ' Set the textbox controls back to "read only".
            txtItemNo.ReadOnly = True
            txtDescription.ReadOnly = True
            txtHeight.ReadOnly = True
            txtWidth.ReadOnly = True
            txtLength.ReadOnly = True
            txtWeight.ReadOnly = True
            txtPackagingWeight.ReadOnly = True

            ' Disable the checkbox controls.
            chkSinglePack.Enabled = False
            chkSignReq.Enabled = False
            chkShipViaMail.Enabled = False
            chkPackException.Enabled = False

            ' Re-enable the toolstrip buttons.
            tsbtnPrevious.Enabled = Not _itemList.AtFirstItem
            tsbtnNext.Enabled = Not _itemList.AtLastItem
            tsbtnPrevious.Enabled = True
            tsbtnNext.Enabled = True
            tsbtnNew.Enabled = True
            tsbtnEdit.Enabled = True
            tsbtnCopy.Enabled = True
            tsbtnExit.Enabled = True

            _mode = ModeEnum.Normal

        Else

            ' Disable these toolstrip buttons.
            tsbtnPrevious.Enabled = False
            tsbtnNext.Enabled = False
            tsbtnNew.Enabled = False
            tsbtnEdit.Enabled = False
            tsbtnCopy.Enabled = False
            tsbtnExit.Enabled = False

            ' Switch up these toolstrip buttons.
            tsbtnDelete.Visible = False
            tsbtnCancel.Visible = True
            tsbtnFind.Visible = False
            tsbtnSave.Visible = True

            ' Adjust the size of the subitems groupbox, and reveal the additional Add/Remove controls.
            grpSubItems.Height = 211
            txtAddSubItem.Visible = True
            txtAddSubItem.Clear()
            btnAddSubItem.Visible = True
            btnAddSubItem.Enabled = False
            btnRemoveSubItem.Visible = True
            btnRemoveSubItem.Enabled = False

            ' Turn off  "read only" on the textbox controls.
            txtItemNo.ReadOnly = False
            txtDescription.ReadOnly = False
            txtHeight.ReadOnly = False
            txtWidth.ReadOnly = False
            txtLength.ReadOnly = False
            txtWeight.ReadOnly = False
            txtPackagingWeight.ReadOnly = False

            ' Enable the checkbox controls.
            chkSinglePack.Enabled = True
            chkSignReq.Enabled = True
            chkShipViaMail.Enabled = True
            chkPackException.Enabled = True

        End If

    End Sub

#End Region


#Region "Public Properties"

    ' No public properties defined.

#End Region


#Region "Public Methods"

    ''' <summary>
    ''' SetItemList method
    ''' </summary>
    ''' <param name="list">A reference to the Items object.</param>
    ''' <remarks>
    ''' Sets a reference to the loaded Items object to give access to the item list.
    ''' </remarks>
    Public Sub SetItemList(ByRef list As Products)
        _itemList = list
        _currentItem = _itemList.FirstItem()
    End Sub

#End Region

End Class