Imports OrderProcessingLibrary
Imports OrderProcessingLibrary.Utilities
Imports Logger = OrderProcessingLibrary.Utilities.LogFileListener
Imports Settings = OrderProcessingLibrary.Utilities.AppSettings

Public Class CreateExportFile

#Region "Private Members"

    Private Enum FileTypeEnum As Byte
        UPSManifest
        USMailManifest
        FinalExport
    End Enum

#End Region


#Region "Private Methods"

    ''' <summary>
    ''' FileSelect method
    ''' </summary>
    ''' <param name="fileType">Value indicating which file is being selected.</param>
    ''' <param name="defaultFilename">Default file name.</param>
    ''' <remarks></remarks>
    Private Sub FileSelect(ByVal fileType As FileTypeEnum, ByVal defaultFilename As String)

        Dim currentPathFilename As String = ""
        Dim newPathFilename = ""
        Dim dlg As FileDialog = Nothing

        ' Get the contents of the applicable text box, if any are present.
        Select Case fileType
            Case FileTypeEnum.UPSManifest
                currentPathFilename = txtUPSDataFile.Text.Trim()
                dlg = dlgFileOpen
            Case FileTypeEnum.USMailManifest
                currentPathFilename = txtUSMailDataFile.Text.Trim()
                dlg = dlgFileOpen
        End Select

        ' If there is already a path and filename in the textbox, load it into the dialog.  This
        ' will at least position the search in the same folder.
        If currentPathFilename.Length > 0 Then
            dlg.FileName = currentPathFilename
        Else
            dlg.FileName = defaultFilename
        End If

        ' Show the dialog.
        Dim result As DialogResult = dlg.ShowDialog()
        If result = Windows.Forms.DialogResult.OK Then
            ' Keep the results.
            newPathFilename = dlg.FileName
        End If

        ' If a new path/filename has been selected, update the applicable text box and application
        ' settings property.
        If currentPathFilename <> newPathFilename Then
            Select Case fileType
                Case FileTypeEnum.UPSManifest
                    txtUPSDataFile.Text = newPathFilename
                    Settings.UPSManifestFile = newPathFilename
                Case FileTypeEnum.USMailManifest
                    txtUSMailDataFile.Text = newPathFilename
                    Settings.USMailManifestFile = newPathFilename
            End Select
        End If

        dlg.Dispose()

    End Sub

#End Region


#Region "Public Properties"

    ' No public properties defined.

#End Region


#Region "Public Methods"

    ' No public methods defined.

#End Region


#Region "Event Handlers"

    ''' <summary>
    ''' Button_Click event handler
    ''' </summary>
    ''' <param name="sender">Object that raised the event.</param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' This handler will capture all of button click events.
    ''' 
    ''' NOTE: The DialogResult property on the Continue and Exit buttons supplies the
    ''' appropriate value back to the calling routine.
    ''' </remarks>
    Private Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs) _
                Handles btnBrowseUPSFile.Click, btnBrowseUSMailFile.Click, _
                         btnExit.Click, btnContinue.Click

        Dim btn As Button = sender

        Select Case btn.Tag

            Case "UPSDataFile"
                ' Open file dialog.
                FileSelect(FileTypeEnum.UPSManifest, "Manifest.csv")

            Case "USMailDataFile"
                ' Open file dialog.
                FileSelect(FileTypeEnum.USMailManifest, "USPSMANI.csv")

            Case "ExportFile"
                ' Open file dialog.
                FileSelect(FileTypeEnum.FinalExport, "FinalExport.csv")

            Case "Continue"
                Close()

            Case "Exit"
                Close()

        End Select

    End Sub

    ''' <summary>
    ''' ExportFileSelection_Load
    ''' </summary>
    ''' <param name="sender">CreateExportfile form</param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ExportFileSelection_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Load the last used path and filename, if available.
        txtUPSDataFile.Text = Settings.UPSManifestFile
        txtUSMailDataFile.Text = Settings.USMailManifestFile

        ' Set focus to the "Continue" button.
        btnContinue.Focus()

    End Sub

#End Region

End Class