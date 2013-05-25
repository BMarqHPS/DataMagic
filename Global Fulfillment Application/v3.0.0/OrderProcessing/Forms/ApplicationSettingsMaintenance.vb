Imports OrderProcessingLibrary
Imports OrderProcessingLibrary.Utilities
Imports Logger = OrderProcessingLibrary.Utilities.LogFileListener
Imports Settings = OrderProcessingLibrary.Utilities.AppSettings

Public Class ApplicationSettingsMaintenance

#Region "Private Fields"

    Private mailManifestFile As String
    Private mailPackageFile As String
    Private upsManifestFile As String
    Private upsPackageFile As String

    Private writeToLogFile As Boolean = True
    Private logFileName As String
    Private loggingLevel As String

    Private packageID As Integer
    Private digits As String = "0123456789"

#End Region


#Region "Private Methods"

    ''' <summary>
    ''' UpdateSetting method
    ''' </summary>
    ''' <remarks>
    ''' Copies the values from the controls of the active panel back to the properties of the
    ''' Settings object.
    ''' </remarks>
    Private Sub UpdateSettings()

        Settings.USMailManifestFile = txtUSMailManifestFile.Text.Trim()
        Settings.USMailPackageFile = txtUSMailPackageFile.Text.Trim()
        Settings.UPSManifestFile = txtUPSManifestFile.Text.Trim()
        Settings.UPSPackageFile = txtUPSPackageFile.Text.Trim()

        Settings.LoggingEnabled = chkLoggingEnabled.Checked
        Settings.LogFileName = txtLogFilename.Text.Trim()
        Settings.LoggingLevel = cmbLoggingLevel.SelectedIndex

        Settings.PackageID = txtPackageID.Text.Trim()

        Settings.Save()

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
    ''' <param name="sender">One of the two button controls on the form.</param>
    ''' <param name="e">Standard EventArgs object.</param>
    ''' <remarks></remarks>
    Private Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs) _
                Handles btnSave.Click, btnCancel.Click

        Dim btn As Button = sender

        Select Case btn.Tag

            Case "Save"
                UpdateSettings()
                Close()

            Case "Cancel"
                Close()

        End Select

    End Sub

    ''' <summary>
    ''' Textbox_KeyPress event handler
    ''' </summary>
    ''' <param name="sender">Textbox control which raised the event.</param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' This handler will make sure that only numeric values are entered in these controls.
    ''' </remarks>
    Private Sub Textbox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                Handles txtPackageID.KeyPress

        If Not digits.Contains(e.KeyChar.ToString()) Then
            e.KeyChar = Nothing
            Beep()
        End If

    End Sub

#End Region

End Class