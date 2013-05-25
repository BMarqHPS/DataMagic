Imports System.IO

Public Class CSVFileViewer

#Region "Event Handlers"

    ''' <summary>
    ''' CSVFileViewer_Shown event
    ''' </summary>
    ''' <param name="sender">CSVFileViewer form</param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CSVFileViewer_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        CSV_to_DataTable()

    End Sub

    ''' <summary>
    ''' btnClose_Click event
    ''' </summary>
    ''' <param name="sender">btnClose</param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub

#End Region


#Region "Private Members"

    Private _columnNames As String()
    Private _fileName As String
    Private _hasHeader As Boolean = True

    Private _dt As New DataTable("FileData")

#End Region


#Region "Private Methods"

    ''' <summary>
    ''' CSV_to_DataTable method
    ''' </summary>
    ''' <remarks>
    ''' This method will build a data table from the contents of the selected CSV file.
    ''' 
    ''' Each type of file has an associated set of headers, which is used to dynamically name
    ''' the columns.  Then the lines from the file are split into individual values and set
    ''' into the items of a data row, which is then added to the table.
    ''' 
    ''' This is much better than the initial ListView approach for viewing these files.  It is
    ''' slightly quicker, and the lines can be sorted by clicking on the headers.
    ''' 
    ''' NOTE: The sorting DOES NOT carry back to the original file, as this display is totally
    ''' disconnected from the file itself.
    ''' </remarks>
    Private Sub CSV_to_DataTable()

        Try

            ' Display the hourglass.
            Me.Cursor = Cursors.WaitCursor

            ' Load column headers for listview control.
            Dim col As DataColumn

            For Each headerText As String In _columnNames
                col = New DataColumn(headerText)
                col.DataType = System.Type.GetType("System.String")
                _dt.Columns.Add(col)
            Next

            Dim sr As New StreamReader(_fileName)
            Dim lineIn As String
            Dim fields As String()
            Dim headerSkipped As Boolean = Not _hasHeader
            Dim row As DataRow

            While Not sr.EndOfStream

                ' Read lines from the indicated file.
                lineIn = sr.ReadLine().Trim().Replace("""", "")
                If Not headerSkipped Then
                    ' Skip this line
                    headerSkipped = True
                    Continue While
                End If
                If lineIn = "" Then Continue While

                ' Split the line into fields.
                fields = lineIn.Split(New [Char]() {","c})

                ' Load the values into a DataRow.
                row = _dt.NewRow()
                For i As Integer = 0 To fields.Length - 1
                    row.Item(i) = fields(i)
                Next
                _dt.Rows.Add(row)

            End While

            ' Cleanup the stream reader.
            sr.Close()
            sr.Dispose()

            ' Bind the data table to the grid view.
            dgvFileDisplay.DataSource = _dt

            ' Display the number of lines read.
            lblLineCount.Text = String.Format("Line Count - {0}", _dt.Rows.Count)
            lblLineCount.Visible = True

            ' Reset the cursor.
            Me.Cursor = Cursors.Default

        Catch ex As Exception

            ' Reset the cursor.
            Me.Cursor = Cursors.Default

            MessageBox.Show(ex.Message.ToString(), "Unexpected Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub

#End Region


#Region "Public Properties"

    ''' <summary>
    ''' FileName property
    ''' </summary>
    ''' <value>String</value>
    ''' <remarks>Name of the file to be loaded/displayed.</remarks>
    Public WriteOnly Property FileName() As String
        Set(ByVal value As String)
            _fileName = value
            Me.Text = value
        End Set
    End Property

    '''' <summary>
    '''' ColumnNames property
    '''' </summary>
    '''' <value>String</value>
    '''' <remarks>The name of a comma-separated list of column names.</remarks>
    'Public WriteOnly Property ColumnNames() As String
    '    Set(ByVal value As String)
    '        Select Case value
    '            Case "OrderFileView"
    '                _columnNames = Headers.OrderFileView.Split(New [Char]() {","c})
    '            Case "PackageFileView1"
    '                _columnNames = Headers.PackageFileView1.Split(New [Char]() {","c})
    '            Case "PackageFileView2"
    '                _columnNames = Headers.PackageFileView2.Split(New [Char]() {","c})
    '            Case "ManifestFileView"
    '                _columnNames = Headers.ManifestFileView.Split(New [Char]() {","c})
    '            Case "FinalExportFileView"
    '                _columnNames = Headers.FinalExportFileView.Split(New [Char]() {","c})
    '        End Select
    '    End Set
    'End Property

    ''' <summary>
    ''' HasHeaderRow property
    ''' </summary>
    ''' <value>Boolean</value>
    ''' <remarks>Indicates if the file to be loaded has a header row.</remarks>
    Public WriteOnly Property HasHeaderRow() As Boolean
        Set(ByVal value As Boolean)
            _hasHeader = value
        End Set
    End Property

#End Region


#Region "Public Methods"

    Public Sub SetColumnHeaders(ByVal headerSet As String)

        Select Case headerSet
            Case "OrderFileView"
                _columnNames = Headers.OrderFileView.Split(New [Char]() {","c})
            Case "PackageFileView1"
                _columnNames = Headers.PackageFileView1.Split(New [Char]() {","c})
            Case "PackageFileView2"
                _columnNames = Headers.PackageFileView2.Split(New [Char]() {","c})
            Case "ManifestFileView"
                _columnNames = Headers.ManifestFileView.Split(New [Char]() {","c})
            Case "FinalExportFileView"
                _columnNames = Headers.FinalExportFileView.Split(New [Char]() {","c})
        End Select

    End Sub

#End Region


#Region "Headers"

    Private Class Headers

        Friend Const OrderFileView As String = _
            "Win Number,Order Number,SubOrder Number,Cert Number,BackOrder Number,Ship Date,Batch Number," & _
            "Item,Item Description,First Name,MI,Last Name,Address,Address Line 2,City,ST,Zip,Country," & _
            "Phone,Expire Date,Status,Customer Number,Bin Number,VBin Number,Gift"

        Friend Const PackageFileView1 As String = _
           "Win Number,Order Number,BackOrder Number,Ship Date,Batch Number,Item,Item Description," & _
           "First Name,MI,Last Name,Address,Address Line 2,City,ST,Zip,Country,Phone,Expire Date,Status," & _
           "Customer Number,Bin Number,VBin Number,Gift,Package ID,Attention,Weight,Package Type," & _
           "Billing Option,Residential,Service,Shipping,Multi Items,Delivery Confirm,Signature Req," & _
           "Length,Width,Height,SubOrder Number,Cert Number"

        Friend Const PackageFileView2 As String = _
           "Win Number,Order Number,BackOrder Number,Ship Date,Batch Number,Item,Item Description," & _
            "First Name,MI,Last Name,Address,Address Line 2,City,ST,Zip,Country,Phone,Expire Date,Status," & _
            "Customer Number,Bin Number,VBin Number,Gift,Package ID,Attention,Weight,Package Type," & _
            "Billing Option,Residential,Service,Shipping,Multi Items,Delivery Confirm,Signature Req," & _
            "Length,Width,Height,Carrier,SubOrder Number,Cert Number"

        Friend Const ManifestFileView As String = _
            "Order Number,Ship Date,Ship Cost,Weight,Package Type,Service,Package ID,Multi Items," & _
            "Tracking Number,SubOrder Number,Cert Number"

        Friend Const FinalExportFileView As String = _
            "Order Number,Ship Date,Ship Cost,Weight,Carrier,Service," & _
            "Package ID,Multi Items,Tracking Number,SubOrder Number,Cert Number"

    End Class

#End Region

End Class