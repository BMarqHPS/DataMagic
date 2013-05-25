<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemMaint
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ItemMaint))
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtItemNo = New System.Windows.Forms.TextBox
        Me.txtLength = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtHeight = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtWidth = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.grpWeight = New System.Windows.Forms.GroupBox
        Me.txtPackagingWeight = New System.Windows.Forms.TextBox
        Me.txtWeight = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.grpSubItems = New System.Windows.Forms.GroupBox
        Me.btnRemoveSubItem = New System.Windows.Forms.Button
        Me.btnAddSubItem = New System.Windows.Forms.Button
        Me.txtAddSubItem = New System.Windows.Forms.TextBox
        Me.lstboxSubItems = New System.Windows.Forms.ListBox
        Me.chkSinglePack = New System.Windows.Forms.CheckBox
        Me.chkSignReq = New System.Windows.Forms.CheckBox
        Me.chkShipViaMail = New System.Windows.Forms.CheckBox
        Me.chkPackException = New System.Windows.Forms.CheckBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbtnPrevious = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtnNext = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtnNew = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtnEdit = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtnCopy = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtnDelete = New System.Windows.Forms.ToolStripButton
        Me.tsbtnCancel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtnFind = New System.Windows.Forms.ToolStripButton
        Me.tsbtnSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtnExit = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator
        Me.grpWeight.SuspendLayout()
        Me.grpSubItems.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(63, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 15)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Item Num"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtItemNo
        '
        Me.txtItemNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemNo.Location = New System.Drawing.Point(139, 51)
        Me.txtItemNo.Name = "txtItemNo"
        Me.txtItemNo.ReadOnly = True
        Me.txtItemNo.Size = New System.Drawing.Size(127, 23)
        Me.txtItemNo.TabIndex = 0
        '
        'txtLength
        '
        Me.txtLength.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLength.Location = New System.Drawing.Point(139, 125)
        Me.txtLength.Name = "txtLength"
        Me.txtLength.ReadOnly = True
        Me.txtLength.Size = New System.Drawing.Size(43, 23)
        Me.txtLength.TabIndex = 2
        Me.txtLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(81, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 15)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Length"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtHeight
        '
        Me.txtHeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeight.Location = New System.Drawing.Point(139, 183)
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.ReadOnly = True
        Me.txtHeight.Size = New System.Drawing.Size(43, 23)
        Me.txtHeight.TabIndex = 4
        Me.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(83, 186)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 15)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Height"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWidth
        '
        Me.txtWidth.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWidth.Location = New System.Drawing.Point(139, 154)
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.ReadOnly = True
        Me.txtWidth.Size = New System.Drawing.Size(43, 23)
        Me.txtWidth.TabIndex = 3
        Me.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(89, 157)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 15)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Width"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDescription
        '
        Me.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(139, 81)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ReadOnly = True
        Me.txtDescription.Size = New System.Drawing.Size(350, 23)
        Me.txtDescription.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(52, 84)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 15)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Description"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpWeight
        '
        Me.grpWeight.Controls.Add(Me.txtPackagingWeight)
        Me.grpWeight.Controls.Add(Me.txtWeight)
        Me.grpWeight.Controls.Add(Me.Label6)
        Me.grpWeight.Controls.Add(Me.Label2)
        Me.grpWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpWeight.Location = New System.Drawing.Point(226, 114)
        Me.grpWeight.Name = "grpWeight"
        Me.grpWeight.Size = New System.Drawing.Size(120, 178)
        Me.grpWeight.TabIndex = 9
        Me.grpWeight.TabStop = False
        Me.grpWeight.Text = "Weight"
        '
        'txtPackagingWeight
        '
        Me.txtPackagingWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPackagingWeight.Location = New System.Drawing.Point(39, 142)
        Me.txtPackagingWeight.Name = "txtPackagingWeight"
        Me.txtPackagingWeight.ReadOnly = True
        Me.txtPackagingWeight.Size = New System.Drawing.Size(43, 23)
        Me.txtPackagingWeight.TabIndex = 18
        Me.txtPackagingWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtWeight
        '
        Me.txtWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWeight.Location = New System.Drawing.Point(32, 66)
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.ReadOnly = True
        Me.txtWeight.Size = New System.Drawing.Size(57, 23)
        Me.txtWeight.TabIndex = 17
        Me.txtWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(23, 106)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 30)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Packaging Weight"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(34, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 32)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Weight (for 1)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpSubItems
        '
        Me.grpSubItems.Controls.Add(Me.btnRemoveSubItem)
        Me.grpSubItems.Controls.Add(Me.btnAddSubItem)
        Me.grpSubItems.Controls.Add(Me.txtAddSubItem)
        Me.grpSubItems.Controls.Add(Me.lstboxSubItems)
        Me.grpSubItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSubItems.Location = New System.Drawing.Point(368, 114)
        Me.grpSubItems.Name = "grpSubItems"
        Me.grpSubItems.Size = New System.Drawing.Size(120, 211)
        Me.grpSubItems.TabIndex = 10
        Me.grpSubItems.TabStop = False
        Me.grpSubItems.Text = "Sub-Item(s)"
        '
        'btnRemoveSubItem
        '
        Me.btnRemoveSubItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveSubItem.Location = New System.Drawing.Point(23, 184)
        Me.btnRemoveSubItem.Name = "btnRemoveSubItem"
        Me.btnRemoveSubItem.Size = New System.Drawing.Size(77, 21)
        Me.btnRemoveSubItem.TabIndex = 3
        Me.btnRemoveSubItem.Tag = "RemoveSubItem"
        Me.btnRemoveSubItem.Text = "Remove"
        Me.btnRemoveSubItem.UseVisualStyleBackColor = True
        Me.btnRemoveSubItem.Visible = False
        '
        'btnAddSubItem
        '
        Me.btnAddSubItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddSubItem.Location = New System.Drawing.Point(23, 157)
        Me.btnAddSubItem.Name = "btnAddSubItem"
        Me.btnAddSubItem.Size = New System.Drawing.Size(77, 21)
        Me.btnAddSubItem.TabIndex = 2
        Me.btnAddSubItem.Tag = "AddSubItem"
        Me.btnAddSubItem.Text = "Add"
        Me.btnAddSubItem.UseVisualStyleBackColor = True
        Me.btnAddSubItem.Visible = False
        '
        'txtAddSubItem
        '
        Me.txtAddSubItem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddSubItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddSubItem.Location = New System.Drawing.Point(12, 128)
        Me.txtAddSubItem.Name = "txtAddSubItem"
        Me.txtAddSubItem.Size = New System.Drawing.Size(97, 23)
        Me.txtAddSubItem.TabIndex = 1
        Me.txtAddSubItem.Tag = "AddSubItem"
        Me.txtAddSubItem.Visible = False
        '
        'lstboxSubItems
        '
        Me.lstboxSubItems.FormattingEnabled = True
        Me.lstboxSubItems.ItemHeight = 15
        Me.lstboxSubItems.Location = New System.Drawing.Point(12, 27)
        Me.lstboxSubItems.MultiColumn = True
        Me.lstboxSubItems.Name = "lstboxSubItems"
        Me.lstboxSubItems.Size = New System.Drawing.Size(97, 94)
        Me.lstboxSubItems.Sorted = True
        Me.lstboxSubItems.TabIndex = 0
        Me.lstboxSubItems.TabStop = False
        Me.lstboxSubItems.Tag = "SubItems"
        '
        'chkSinglePack
        '
        Me.chkSinglePack.AutoSize = True
        Me.chkSinglePack.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkSinglePack.Enabled = False
        Me.chkSinglePack.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSinglePack.Location = New System.Drawing.Point(80, 231)
        Me.chkSinglePack.Name = "chkSinglePack"
        Me.chkSinglePack.Size = New System.Drawing.Size(102, 19)
        Me.chkSinglePack.TabIndex = 5
        Me.chkSinglePack.Text = "Single Pack"
        Me.chkSinglePack.UseVisualStyleBackColor = True
        '
        'chkSignReq
        '
        Me.chkSignReq.AutoSize = True
        Me.chkSignReq.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkSignReq.Enabled = False
        Me.chkSignReq.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSignReq.Location = New System.Drawing.Point(31, 256)
        Me.chkSignReq.Name = "chkSignReq"
        Me.chkSignReq.Size = New System.Drawing.Size(151, 19)
        Me.chkSignReq.TabIndex = 6
        Me.chkSignReq.Text = "Signature Required"
        Me.chkSignReq.UseVisualStyleBackColor = True
        '
        'chkShipViaMail
        '
        Me.chkShipViaMail.AutoSize = True
        Me.chkShipViaMail.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkShipViaMail.Enabled = False
        Me.chkShipViaMail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShipViaMail.Location = New System.Drawing.Point(50, 281)
        Me.chkShipViaMail.Name = "chkShipViaMail"
        Me.chkShipViaMail.Size = New System.Drawing.Size(132, 19)
        Me.chkShipViaMail.TabIndex = 7
        Me.chkShipViaMail.Text = "Ship via US Mail"
        Me.chkShipViaMail.UseVisualStyleBackColor = True
        '
        'chkPackException
        '
        Me.chkPackException.AutoSize = True
        Me.chkPackException.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPackException.Enabled = False
        Me.chkPackException.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPackException.Location = New System.Drawing.Point(38, 306)
        Me.chkPackException.Name = "chkPackException"
        Me.chkPackException.Size = New System.Drawing.Size(144, 19)
        Me.chkPackException.TabIndex = 8
        Me.chkPackException.Text = "Packing Exception"
        Me.chkPackException.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnPrevious, Me.ToolStripSeparator6, Me.tsbtnNext, Me.ToolStripSeparator2, Me.tsbtnNew, Me.ToolStripSeparator5, Me.tsbtnEdit, Me.ToolStripSeparator7, Me.tsbtnCopy, Me.ToolStripSeparator3, Me.tsbtnDelete, Me.tsbtnCancel, Me.ToolStripSeparator1, Me.tsbtnFind, Me.tsbtnSave, Me.ToolStripSeparator4, Me.tsbtnExit, Me.ToolStripSeparator9})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(629, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbtnPrevious
        '
        Me.tsbtnPrevious.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tsbtnPrevious.ForeColor = System.Drawing.Color.Blue
        Me.tsbtnPrevious.Image = CType(resources.GetObject("tsbtnPrevious.Image"), System.Drawing.Image)
        Me.tsbtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnPrevious.Name = "tsbtnPrevious"
        Me.tsbtnPrevious.Size = New System.Drawing.Size(54, 22)
        Me.tsbtnPrevious.Tag = "Previous"
        Me.tsbtnPrevious.Text = "Prev"
        Me.tsbtnPrevious.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnNext
        '
        Me.tsbtnNext.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tsbtnNext.ForeColor = System.Drawing.Color.Blue
        Me.tsbtnNext.Image = CType(resources.GetObject("tsbtnNext.Image"), System.Drawing.Image)
        Me.tsbtnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnNext.Name = "tsbtnNext"
        Me.tsbtnNext.Size = New System.Drawing.Size(55, 22)
        Me.tsbtnNext.Tag = "Next"
        Me.tsbtnNext.Text = "Next"
        Me.tsbtnNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tsbtnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnNew
        '
        Me.tsbtnNew.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tsbtnNew.ForeColor = System.Drawing.Color.Blue
        Me.tsbtnNew.Image = CType(resources.GetObject("tsbtnNew.Image"), System.Drawing.Image)
        Me.tsbtnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnNew.Name = "tsbtnNew"
        Me.tsbtnNew.Size = New System.Drawing.Size(53, 22)
        Me.tsbtnNew.Tag = "New"
        Me.tsbtnNew.Text = "New"
        Me.tsbtnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnEdit
        '
        Me.tsbtnEdit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tsbtnEdit.ForeColor = System.Drawing.Color.Blue
        Me.tsbtnEdit.Image = CType(resources.GetObject("tsbtnEdit.Image"), System.Drawing.Image)
        Me.tsbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnEdit.Name = "tsbtnEdit"
        Me.tsbtnEdit.Size = New System.Drawing.Size(51, 22)
        Me.tsbtnEdit.Tag = "Edit"
        Me.tsbtnEdit.Text = "Edit"
        Me.tsbtnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnCopy
        '
        Me.tsbtnCopy.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtnCopy.ForeColor = System.Drawing.Color.Blue
        Me.tsbtnCopy.Image = CType(resources.GetObject("tsbtnCopy.Image"), System.Drawing.Image)
        Me.tsbtnCopy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnCopy.Name = "tsbtnCopy"
        Me.tsbtnCopy.Size = New System.Drawing.Size(58, 22)
        Me.tsbtnCopy.Tag = "Copy"
        Me.tsbtnCopy.Text = "Copy"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnDelete
        '
        Me.tsbtnDelete.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tsbtnDelete.ForeColor = System.Drawing.Color.Blue
        Me.tsbtnDelete.Image = CType(resources.GetObject("tsbtnDelete.Image"), System.Drawing.Image)
        Me.tsbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnDelete.Name = "tsbtnDelete"
        Me.tsbtnDelete.Size = New System.Drawing.Size(66, 22)
        Me.tsbtnDelete.Tag = "Delete"
        Me.tsbtnDelete.Text = "Delete"
        Me.tsbtnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tsbtnCancel
        '
        Me.tsbtnCancel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tsbtnCancel.ForeColor = System.Drawing.Color.Blue
        Me.tsbtnCancel.Image = CType(resources.GetObject("tsbtnCancel.Image"), System.Drawing.Image)
        Me.tsbtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnCancel.Name = "tsbtnCancel"
        Me.tsbtnCancel.Size = New System.Drawing.Size(66, 22)
        Me.tsbtnCancel.Tag = "Cancel"
        Me.tsbtnCancel.Text = "Cancel"
        Me.tsbtnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnFind
        '
        Me.tsbtnFind.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tsbtnFind.ForeColor = System.Drawing.Color.Blue
        Me.tsbtnFind.Image = CType(resources.GetObject("tsbtnFind.Image"), System.Drawing.Image)
        Me.tsbtnFind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnFind.Name = "tsbtnFind"
        Me.tsbtnFind.Size = New System.Drawing.Size(52, 22)
        Me.tsbtnFind.Tag = "Find"
        Me.tsbtnFind.Text = "Find"
        Me.tsbtnFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tsbtnSave
        '
        Me.tsbtnSave.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tsbtnSave.ForeColor = System.Drawing.Color.Blue
        Me.tsbtnSave.Image = CType(resources.GetObject("tsbtnSave.Image"), System.Drawing.Image)
        Me.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnSave.Name = "tsbtnSave"
        Me.tsbtnSave.Size = New System.Drawing.Size(56, 22)
        Me.tsbtnSave.Tag = "Save"
        Me.tsbtnSave.Text = "Save"
        Me.tsbtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnExit
        '
        Me.tsbtnExit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tsbtnExit.ForeColor = System.Drawing.Color.Blue
        Me.tsbtnExit.Image = CType(resources.GetObject("tsbtnExit.Image"), System.Drawing.Image)
        Me.tsbtnExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnExit.Name = "tsbtnExit"
        Me.tsbtnExit.Size = New System.Drawing.Size(50, 22)
        Me.tsbtnExit.Tag = "Exit"
        Me.tsbtnExit.Text = "Exit"
        Me.tsbtnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'ItemMaint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.ClientSize = New System.Drawing.Size(629, 364)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtItemNo)
        Me.Controls.Add(Me.chkSinglePack)
        Me.Controls.Add(Me.txtHeight)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grpWeight)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtLength)
        Me.Controls.Add(Me.chkSignReq)
        Me.Controls.Add(Me.chkShipViaMail)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.grpSubItems)
        Me.Controls.Add(Me.txtWidth)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.chkPackException)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "ItemMaint"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Item Maintenance"
        Me.grpWeight.ResumeLayout(False)
        Me.grpWeight.PerformLayout()
        Me.grpSubItems.ResumeLayout(False)
        Me.grpSubItems.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtItemNo As System.Windows.Forms.TextBox
    Friend WithEvents txtLength As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtHeight As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtWidth As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents grpWeight As System.Windows.Forms.GroupBox
    Friend WithEvents grpSubItems As System.Windows.Forms.GroupBox
    Friend WithEvents lstboxSubItems As System.Windows.Forms.ListBox
    Friend WithEvents chkSinglePack As System.Windows.Forms.CheckBox
    Friend WithEvents chkSignReq As System.Windows.Forms.CheckBox
    Friend WithEvents chkShipViaMail As System.Windows.Forms.CheckBox
    Friend WithEvents chkPackException As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnFind As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnPrevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRemoveSubItem As System.Windows.Forms.Button
    Friend WithEvents btnAddSubItem As System.Windows.Forms.Button
    Friend WithEvents txtAddSubItem As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtPackagingWeight As System.Windows.Forms.TextBox
    Friend WithEvents txtWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tsbtnCopy As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
End Class
