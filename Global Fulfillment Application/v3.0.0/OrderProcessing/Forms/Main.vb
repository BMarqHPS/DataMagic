Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.IO
Imports System.Text

Imports OrderProcessingLibrary
Imports OrderProcessingLib.DataAccess
Imports OrderProcessingLibrary.DataObjects
Imports OrderProcessingLibrary.Exceptions
Imports OrderProcessingLibrary.Utilities
Imports Logger = OrderProcessingLibrary.Utilities.LogFileListener
Imports Settings = OrderProcessingLibrary.Utilities.AppSettings

Public Class Main

#Region "Private Members"

    Private WithEvents customers As Customers = Nothing
    Private WithEvents manifests As ManifestRecords = Nothing
    Private WithEvents orderLines As OrderLines = Nothing
    Private WithEvents orders As Orders = Nothing
    Private WithEvents packages As Packages = Nothing
    Private WithEvents updates As UpdateRecords = Nothing

    Private items As Products = Nothing

    Private firstValidationPass As Boolean = True
    Private productIdsValidated As Boolean = False

#End Region


#Region "Event Handlers"

    ''' <summary>
    ''' FileMenu_Click event handler
    ''' </summary>
    ''' <param name="sender">Main.frm</param>
    ''' <param name="e"></param>
    ''' <remarks>This handler will capture all of File menu subitem click events.</remarks>
    Private Sub FileMenu_Click(ByVal sender As Object, ByVal e As EventArgs) _
                Handles mnuFileExit.Click

        Dim mi As ToolStripMenuItem = sender

        Select Case mi.Tag

            Case "Exit"

                ' Save current settings, and exit.
                AppSettings.Save()
                Logger.Log("Application closing")
                Logger.CloseLog()
                Application.Exit()

        End Select

    End Sub

    ''' <summary>
    ''' HelpMenu_Click event handler
    ''' </summary>
    ''' <param name="sender">Menu item that was clicked.</param>
    ''' <param name="e"></param>
    ''' <remarks>This handler will capture all Help menu subitem click events.</remarks>
    Private Sub HelpMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                Handles mnuHelpAbout.Click, mnuHelpAppSettings.Click

        Dim mi As ToolStripMenuItem = sender

        Select Case mi.Tag

            Case "ApplicationSettings"

                ' Display the setting form, with the application group displayed.
                Dim frm As New ApplicationSettingsMaintenance()
                frm.ShowDialog(Me)

            Case "About"
                About.ShowDialog(Me)

        End Select

    End Sub

    ''' <summary>
    ''' ItemMenu_Click event handler
    ''' </summary>
    ''' <param name="sender">Menu item that was clicked.</param>
    ''' <param name="e"></param>
    ''' <remarks>This handler will capture all of Item menu subitem click events.</remarks>
    Private Sub ItemMenu_Click(ByVal sender As Object, ByVal e As EventArgs) _
                Handles mnuItemsMaintenance.Click, _
                        mnuItemListExport.Click

        Dim mi As ToolStripMenuItem = sender

        Select Case mi.Tag

            Case "Maintenance"
                ' Bring up the item maintenance form.
                Dim frm As New ItemMaint()
                frm.StartPosition = FormStartPosition.CenterParent
                frm.SetItemList(items)
                frm.ShowDialog(Me)

            Case "Export"
                ' Export the item list to a formatted text file.
                CreateItemListFile()

        End Select

    End Sub

    ''' <summary>
    ''' Main_FormClosing event handler
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' This is here primarily to catch a user closing the form by clicking the X, and 
    ''' current application settings have not been saved.  The user will be prompted with 
    ''' a Yes/No/Cancel dialog if there are unsaved changes.
    ''' </remarks>
    Private Sub Main_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        ' NOTE: This event handler can also be used to query the user if they click the "X" on the Main form, 
        ' or ALT-F4 on the keyboard to close the app instead of File | Exit.
        '
        ' Below is an example, just update the text in the message box.

        'Dim whyClosing As CloseReason = e.CloseReason

        'If (whyClosing = CloseReason.UserClosing) Or (whyClosing = CloseReason.WindowsShutDown) Then
        '    Dim rslt As DialogResult = _
        '        MessageBox.Show("Do you wish to exit the application?", _
        '                            "Exit", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)

        '    If rslt <> Windows.Forms.DialogResult.Yes Then
        '        e.Cancel = True
        '    End If

        'End If

        ' Save the current settings, then enter a line in the log file to indicate the application 
        ' is shutting down, and then close the log file.
        AppSettings.Save()
        Logger.Log("Application closing")
        Logger.CloseLog()

    End Sub

    ''' <summary>
    ''' Main_Load event handler
    ''' </summary>
    ''' <param name="sender">Main.frm</param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' Used to initialize various aspects of the application.
    ''' </remarks>
    Private Sub Main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim _itemDescLoaded As Boolean = False

        ' Initialize app settings.
        AppSettings.Load()

        Logger.Log("Application started by " & AppSettings.UserID & ", settings loaded.")

        Try

            ' Load the item data
            items = New Products()
            items.LoadItemList(AppSettings.AppPath & "\ItemList.xml")
            _itemDescLoaded = True

        Catch ex As ItemDataLoadException

            Dim sb As New StringBuilder("                             !!! ERROR !!!" & vbCrLf & vbCrLf)
            sb.AppendLine("The application settings indicate that the item data has been")
            sb.AppendLine("loaded, but the file is either missing or corrupted." & vbCrLf)
            sb.AppendLine("The item data will need to be reloaded.")

            MessageBox.Show(sb.ToString(), "File Missing or Corrupt", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show(ex.Message.ToString, "Unexpected Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        ' Display the version in the status bar.
        tsslblVersion.Text = String.Format("v{0}.{1}", AppSettings.Major, AppSettings.Minor)

        ' Display the time and date in the status bar.
        tsslblTime.Text = DateTime.Now.ToString("h:mm tt")
        tsslblDate.Text = DateTime.Now.ToString("MM-dd-yyyy")

    End Sub

    ''' <summary>
    ''' OrdersMenu_Click event handler
    ''' </summary>
    ''' <param name="sender">Menu item that was clicked.</param>
    ''' <param name="e"></param>
    ''' <remarks>This handler will capture all Orders menu subitem click events.</remarks>
    Private Sub OrdersMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                Handles mnuOrdersProcess.Click, mnuOrdersUpdate.Click, mnuOrdersValidate.Click

        Dim mi As ToolStripMenuItem = sender

        Select Case mi.Tag

            Case "Validate"
                ValidateOrdersSQL()

            Case "Process"
                ProcessOrdersSQL()

            Case "Update"
                UpdateOrdersSQL()

        End Select


    End Sub

    ''' <summary>
    ''' Timer1_Click event handler
    ''' </summary>
    ''' <param name="sender">Timer object</param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' Only used to sync the time and date displayed on the status bar.
    ''' </remarks>
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        tsslblTime.Text = DateTime.Now.ToString("hh:mm tt")
        tsslblDate.Text = DateTime.Now.ToString("MM-dd-yyyy")

    End Sub

    ''' <summary>
    ''' ViewMenu_Click event handler
    ''' </summary>
    ''' <param name="sender">Menu item that was clicked.</param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ViewMenu_Click(ByVal sender As Object, ByVal e As EventArgs) _
                Handles _
 _
                        mnuViewUSMailManifest.Click, mnuViewUSMailPackage.Click, mnuViewUPSPackage.Click, mnuViewUPSManifest.Click

        Dim mi As ToolStripMenuItem = sender
        Dim headerSetName As String = ""
        Dim fileName As String = ""
        Dim hasHeaderRow As Boolean = True

        Select Case mi.Tag
            Case "UPS Package"
                headerSetName = "PackageFileView1"
                fileName = AppSettings.UPSPackageFile
            Case "US Mail Package"
                headerSetName = "PackageFileView2"
                fileName = AppSettings.USMailPackageFile
                hasHeaderRow = False
            Case "UPS Manifest"
                headerSetName = "ManifestFileView"
                fileName = AppSettings.UPSManifestFile
            Case "US Mail Manifest"
                headerSetName = "ManifestFileView"
                fileName = AppSettings.USMailManifestFile
        End Select

        Try

            ' Verify file exist.
            If Not File.Exists(fileName) Then
                Throw New FileNotFoundException(fileName)
            End If

            ' Load up and display the file viewer.
            Dim frm As New CSVFileViewer()
            frm.FileName = fileName
            frm.SetColumnHeaders(headerSetName)
            frm.HasHeaderRow = hasHeaderRow
            frm.ShowDialog(Me)
            frm.Dispose()

        Catch ex As FileNotFoundException

            MessageBox.Show(ex.Message, "No File", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        Catch ex As Exception

            MessageBox.Show(ex.Message.ToString(), "Unexpected Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub InitProgressBar(ByVal sender As Object, ByVal e As ProgressBarEventArgs) _
        Handles customers.InitProgressBar, orderLines.InitProgressBar, orders.InitProgressBar, _
                packages.InitProgressBar, updates.InitProgressBar

        tsspbCurrentProgress.Value = e.Value
        tsspbCurrentProgress.Maximum = e.MaxValue

    End Sub

    Private Sub IncrementProgressBar(ByVal sender As Object, ByVal e As ProgressBarEventArgs) _
        Handles customers.IncrementProgressBar, orderLines.IncrementProgressBar, orders.IncrementProgressBar, _
                packages.IncrementProgressBar, updates.IncrementProgressBar

        tsspbCurrentProgress.Increment(1)

    End Sub

    Private Sub UpdateStatusBar(ByVal sender As Object, ByVal e As StatusBarEventArgs) _
        Handles customers.UpdateStatusBar, orderLines.UpdateStatusBar, orders.UpdateStatusBar, _
                packages.UpdateStatusBar, updates.UpdateStatusBar

        tsslblCurrentStatus.Text = e.StatusText

    End Sub

#End Region


#Region "Private Methods"

    ''' <summary>
    ''' CreateItemListFile method
    ''' </summary>
    ''' <remarks>Exports the data in ItemList.xml to a CSV file.</remarks>
    Private Sub CreateItemListFile()

        Dim exportFilePath As String
        Dim dlg As New SaveFileDialog
        Dim rslt As DialogResult

        Try

            ' OpenFile dialog for selecting file destination.
            dlg.FileName = "C:\Temp\ItemListExport.csv"
            rslt = dlg.ShowDialog()
            If rslt <> Windows.Forms.DialogResult.OK Then Exit Sub
            exportFilePath = dlg.FileName
            dlg.Dispose()

            ' Initialize a StreamWriter to write the file.
            Dim sw As New StreamWriter(exportFilePath)

            'Write the line of column headers.
            sw.WriteLine("Item,Description,L,W,H,Weight,PackagingWeight")

            ' Write the values for the first item
            sw.WriteLine(FormatCSV(items.FirstItem))

            ' Begin looping thru the remaining items.
            While Not items.AtLastItem
                ' Write the values for each of the items.
                sw.WriteLine(FormatCSV(items.NextItem))
            End While

            ' Flush, Close and Dispose the StreamWriter.
            sw.Flush()
            sw.Close()
            sw.Dispose()

            ' Display MessageBox showing completion.
            MessageBox.Show("Item list has been successfully exported to:" & vbCrLf & vbCrLf & exportFilePath, "Export Complete")

        Catch ex As Exception

            ' An unexpected exception has occurred.
            Cursor = Cursors.Default
            Logger.LogException(ex)
            MessageBox.Show(ex.Message.ToString(), "Unexpected Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    ''' <summary>
    ''' FormatAsCSV method
    ''' </summary>
    ''' <param name="obj">Reference to the Item object to be formatted.</param>
    ''' <returns>A CSV string of the Item properties.</returns>
    ''' <remarks></remarks>
    Private Function FormatCSV(ByRef obj As Product) As String

        Dim temp As String = ""
        Dim subItems As String = ""

        ' If this Item has sub-items, format them into a "/" separated list.
        If obj.IsKit Then
            For i As Integer = 0 To obj.SubItems.Count - 1
                If subItems.Length > 0 Then
                    subItems &= " / " & obj.SubItems(i)
                Else
                    subItems = obj.SubItems(i)
                End If
            Next
        End If

        ' Format the properties of this Item into a comma-separated list.
        temp = String.Format("{0},{1},{2},{3},{4},{5:##0.00},{6:##0.00}", _
            obj.ItemNumber, obj.Description, obj.L, obj.W, obj.H, obj.Weight, obj.PackagingWeight)

        Return temp

    End Function

    Private Sub ValidateOrdersSQL()

        Dim missingItems As New List(Of String)
        Dim sb As New StringBuilder()

        Dim productList As DataTable = SqlHelper.GetProductIdsForPendingOrders(firstValidationPass)
        Dim row As DataRow
        Dim productId As String

        firstValidationPass = False

        For idx As Integer = 0 To productList.Rows.Count - 1
            row = productList.Rows(idx)
            productId = row.Item(0).ToString()
            If Not items.Exists(productId) Then
                missingItems.Add(productId)
            End If
        Next

        If missingItems.Count > 0 Then
            sb.AppendLine("The following Items from the pending orders were not found")
            sb.AppendLine("")
            For Each id As String In missingItems
                sb.AppendFormat("\t\t\t\t\t{0}\n", id)
            Next
            MessageBox.Show(sb.ToString(), "Missing Item(s)", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            sb.AppendLine("All item numbers from the pending orders")
            sb.AppendLine("have been validated.")
            MessageBox.Show(sb.ToString(), "Validated", MessageBoxButtons.OK, MessageBoxIcon.Information)
            productIdsValidated = True
            mnuOrdersProcess.Enabled = True
        End If

    End Sub

    Private Sub ProcessOrdersSQL()

        Try

            orderLines = New OrderLines()
            orders = New Orders()
            customers = New Customers()

            Cursor = Cursors.WaitCursor

            Logger.Log("Retrieving pending orders...")
            tsslblCurrentStatus.Text = "Retrieving pending orders..."
            Me.Refresh()

            Dim lineCount As Integer = orderLines.LoadOrders(items)

            ' Create the order and customer objects.
            Logger.Log("Creating order and customer lists...", LogLevel.Verbose)
            tsslblCurrentStatus.Text = "Creating order and customer lists..."
            Me.Refresh()

            orders.ProcessOrderLines(orderLines, customers)

            ' Clear the progress bar.
            tsspbCurrentProgress.Value = 0

            ' We can free up some memory at this point.
            orderLines.Clear()

            ' If necessary, move on to customer matching.
            If customers.RawCount > 0 Then
                Logger.Log("Performing customer matchups...", LogLevel.Verbose)
                tsslblCurrentStatus.Text = "Performing customer matchups..."
                Me.Refresh()
                customers.CustomerMatchup()
            Else
                Logger.Log("No customer matchup to perform.", LogLevel.Verbose)
            End If

            ' Create the Packages collection object.
            packages = New Packages(orders, customers, items)

            ' Create the PrePackage objects (item lists per order).
            Logger.Log("Generating item lists per customer/order...", LogLevel.Verbose)
            tsslblCurrentStatus.Text = "Generating item lists..."
            Me.Refresh()
            packages.CreatePrePackages()

            ' Create the Package objects and the cross-reference XML file.
            tsspbCurrentProgress.Value = 0
            Logger.Log("Generating individual packages...", LogLevel.Verbose)
            tsslblCurrentStatus.Text = "Generating individual packages..."
            Me.Refresh()
            packages.CreatePackages()

            ' Write the output files for the carrier shipping programs.
            tsspbCurrentProgress.Value = 0
            Logger.Log("Writing package files...", LogLevel.Verbose)
            tsslblCurrentStatus.Text = "Writing package files..."
            Me.Refresh()
            packages.WritePackageFiles(AppSettings.UPSPackageFile, AppSettings.USMailPackageFile)
            tsspbCurrentProgress.Value = 0

            Cursor = Cursors.Default
            tsslblCurrentStatus.Text = ""
            Me.Refresh()

            Logger.Log("Order files have been processed, and package files have been created.")

            ' Build a message to display the stats.
            Dim msg As New StringBuilder()
            msg.AppendLine("Pending orders pulled from database successfully.")
            msg.AppendLine()
            msg.AppendLine("  Retrieved " & lineCount.ToString() & " order lines from database.")
            msg.AppendLine()
            msg.AppendLine("  Wrote " & packages.UPSPackageCount.ToString() & " lines to " & AppSettings.UPSPackageFileName)
            msg.Append("  Wrote " & packages.USMailPackageCount.ToString() & " lines to " & AppSettings.USMailPackageFileName)
            MessageBox.Show(msg.ToString(), "Processing Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

            mnuOrdersUpdate.Enabled = True

        Catch ex As XRefXmlException
            ' An XML exception occurred while writing the cross-reference file.
            Cursor = Cursors.Default
            tsslblCurrentStatus.Text = ""
            Dim exceptionMessage As String = ex.ExceptionLogMessage
            Logger.LogException(exceptionMessage)
            MessageBox.Show(exceptionMessage, "Unexpected Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As PackageCreateException
            ' An exception occurred while creating the packages.
            Cursor = Cursors.Default
            tsslblCurrentStatus.Text = ""
            Dim exceptionMessage As String = ex.ExceptionLogMessage
            Logger.LogException(exceptionMessage)
            MessageBox.Show(exceptionMessage, "Unexpected Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As SqlException
            ' An exception occurred while retrieving orders from the database
            Cursor = Cursors.Default
            tsslblCurrentStatus.Text = ""
            Logger.LogException(ex)
            MessageBox.Show(ex.Message, "Unexpected Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception
            ' An unexpected exception has occurred, other than those anticipated.
            Cursor = Cursors.Default
            tsslblCurrentStatus.Text = ""
            Logger.LogException(ex)
            MessageBox.Show(ex.Message.ToString(), "Unexpected Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub UpdateOrdersSQL()

        Dim manifests As New ManifestRecords()
        updates = New UpdateRecords(Settings.ConnectionString)

        Try

            Cursor = Cursors.WaitCursor

            ' Load the maninfest files.
            tsslblCurrentStatus.Text = "Reading manifest files..."
            Logger.Log("Loading the manifest files...")
            Me.Refresh()
            manifests.LoadFiles()
            Logger.Log("Loaded a total of " & manifests.Count.ToString() & " manifest records.")

            ' Load up the xreference doc, and instantiate the OutputRecords object.
            Dim xref As New OrdersToPackages(NewStyle.Load)

            ' Sync the carrier shipping data with the packages.
            tsslblCurrentStatus.Text = "Syncing carrier shipping data to orders..."
            Logger.Log("Syncing carrier shipping data to orders...")
            Me.Refresh()
            manifests.SynchronizePackages(xref, updates)
            Logger.Log(String.Format("Sync totals: Matched - {0}, Unmatched - {1}", _
                    manifests.MatchedPackageCount, manifests.UnmatchedPackageCount))
            tsspbCurrentProgress.Value = 0

            updates.ExecuteUpdate()

            tsspbCurrentProgress.Value = 0
            tsslblCurrentStatus.Text = ""
            Cursor = Cursors.Default
            Dim sb As New StringBuilder()
            sb.AppendFormat("Sync totals: Matched - {0}, Unmatched - {1}" & vbCrLf & vbCrLf, _
                    manifests.MatchedPackageCount, manifests.UnmatchedPackageCount)
            sb.AppendFormat("Updated a total of {0} orders.", updates.UpdateCount)
            MessageBox.Show(sb.ToString(), "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As MissingFileException
            ' One of the shipping manifest files could not be found.
            Cursor = Cursors.Default
            tsslblCurrentStatus.Text = ""
            Dim exceptionMessage As String = ex.ExceptionLogMessage
            Logger.LogException(ex.ExceptionLogMessage)
            MessageBox.Show(exceptionMessage, "Unexpected Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As ProcessManifestsException
            ' An exception occurred while reading/processing the manifest files.
            Cursor = Cursors.Default
            tsslblCurrentStatus.Text = ""
            Dim exceptionMessage As String = ex.ExceptionLogMessage
            Logger.LogException(exceptionMessage)
            MessageBox.Show(exceptionMessage, "Unexpected Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As SqlException
            ' An unexpected exception occurred while attempting to update the orders and/or the order line items.
            Cursor = Cursors.Default
            tsslblCurrentStatus.Text = ""
            Logger.LogException(ex)
            MessageBox.Show(ex.Message, "Unexpected SqlException", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception
            ' An unexpected exception has occurred, other than those anticipated.
            Cursor = Cursors.Default
            tsslblCurrentStatus.Text = ""
            Logger.LogException(ex)
            MessageBox.Show(ex.Message, "Unexpected Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

#End Region


End Class
