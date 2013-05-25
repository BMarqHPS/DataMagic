<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ApplicationSettingsMaintenance
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
        Me.components = New System.ComponentModel.Container()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtLogFilename = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbLoggingLevel = New System.Windows.Forms.ComboBox()
        Me.chkLoggingEnabled = New System.Windows.Forms.CheckBox()
        Me.txtUSMailManifestFile = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtUPSManifestFile = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtUSMailPackageFile = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtUPSPackageFile = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPackageID = New System.Windows.Forms.TextBox()
        Me.txtNextPackageID = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(272, 179)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(110, 17)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "Logging Level"
        '
        'txtLogFilename
        '
        Me.txtLogFilename.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLogFilename.Location = New System.Drawing.Point(231, 214)
        Me.txtLogFilename.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLogFilename.Name = "txtLogFilename"
        Me.txtLogFilename.Size = New System.Drawing.Size(345, 23)
        Me.txtLogFilename.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.txtLogFilename, "Full path and filename of output log file")
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(106, 217)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(105, 17)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Log Filename"
        '
        'cmbLoggingLevel
        '
        Me.cmbLoggingLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLoggingLevel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLoggingLevel.FormattingEnabled = True
        Me.cmbLoggingLevel.Items.AddRange(New Object() {"Normal", "Verbose", "Debug"})
        Me.cmbLoggingLevel.Location = New System.Drawing.Point(396, 175)
        Me.cmbLoggingLevel.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbLoggingLevel.Name = "cmbLoggingLevel"
        Me.cmbLoggingLevel.Size = New System.Drawing.Size(180, 25)
        Me.cmbLoggingLevel.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.cmbLoggingLevel, "Indicates the level of detail to be logged")
        '
        'chkLoggingEnabled
        '
        Me.chkLoggingEnabled.AutoSize = True
        Me.chkLoggingEnabled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkLoggingEnabled.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLoggingEnabled.Location = New System.Drawing.Point(59, 177)
        Me.chkLoggingEnabled.Margin = New System.Windows.Forms.Padding(4)
        Me.chkLoggingEnabled.Name = "chkLoggingEnabled"
        Me.chkLoggingEnabled.Size = New System.Drawing.Size(152, 21)
        Me.chkLoggingEnabled.TabIndex = 0
        Me.chkLoggingEnabled.Text = "Logging Enabled"
        Me.ToolTip1.SetToolTip(Me.chkLoggingEnabled, "Enable/disable writing to an application log file")
        Me.chkLoggingEnabled.UseVisualStyleBackColor = True
        '
        'txtUSMailManifestFile
        '
        Me.txtUSMailManifestFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUSMailManifestFile.Location = New System.Drawing.Point(231, 138)
        Me.txtUSMailManifestFile.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUSMailManifestFile.Name = "txtUSMailManifestFile"
        Me.txtUSMailManifestFile.Size = New System.Drawing.Size(345, 23)
        Me.txtUSMailManifestFile.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.txtUSMailManifestFile, "Full path and filename of the file returned from the USPS shipping program")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(51, 138)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(160, 17)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "US Mail Manifest File"
        '
        'txtUPSManifestFile
        '
        Me.txtUPSManifestFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUPSManifestFile.Location = New System.Drawing.Point(231, 101)
        Me.txtUPSManifestFile.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUPSManifestFile.Name = "txtUPSManifestFile"
        Me.txtUPSManifestFile.Size = New System.Drawing.Size(345, 23)
        Me.txtUPSManifestFile.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.txtUPSManifestFile, "Full path and filename of the file returned from the UPS shipping program")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(75, 103)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 17)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "UPS Manifest File"
        '
        'txtUSMailPackageFile
        '
        Me.txtUSMailPackageFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUSMailPackageFile.Location = New System.Drawing.Point(231, 64)
        Me.txtUSMailPackageFile.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUSMailPackageFile.Name = "txtUSMailPackageFile"
        Me.txtUSMailPackageFile.Size = New System.Drawing.Size(345, 23)
        Me.txtUSMailPackageFile.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.txtUSMailPackageFile, "Full path and filename of the file for the USPS shipping program")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(50, 67)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(161, 17)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "US Mail Package File"
        '
        'txtUPSPackageFile
        '
        Me.txtUPSPackageFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUPSPackageFile.Location = New System.Drawing.Point(231, 27)
        Me.txtUPSPackageFile.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUPSPackageFile.Name = "txtUPSPackageFile"
        Me.txtUPSPackageFile.Size = New System.Drawing.Size(345, 23)
        Me.txtUPSPackageFile.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txtUPSPackageFile, "Full path and filename of the file for the UPS shipping program")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(74, 31)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(137, 17)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "UPS Package File"
        '
        'txtPackageID
        '
        Me.txtPackageID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPackageID.Location = New System.Drawing.Point(231, 251)
        Me.txtPackageID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPackageID.Name = "txtPackageID"
        Me.txtPackageID.Size = New System.Drawing.Size(189, 23)
        Me.txtPackageID.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.txtPackageID, "Enter numeric portion only of the next ID")
        '
        'txtNextPackageID
        '
        Me.txtNextPackageID.AutoSize = True
        Me.txtNextPackageID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNextPackageID.Location = New System.Drawing.Point(79, 254)
        Me.txtNextPackageID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtNextPackageID.Name = "txtNextPackageID"
        Me.txtNextPackageID.Size = New System.Drawing.Size(132, 17)
        Me.txtNextPackageID.TabIndex = 16
        Me.txtNextPackageID.Text = " Next Package ID"
        '
        'btnSave
        '
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(143, 314)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(152, 31)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Tag = "Save"
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(333, 314)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(152, 31)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Tag = "Cancel"
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'ApplicationSettingsMaintenance
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(627, 359)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtPackageID)
        Me.Controls.Add(Me.txtLogFilename)
        Me.Controls.Add(Me.txtNextPackageID)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtUSMailManifestFile)
        Me.Controls.Add(Me.cmbLoggingLevel)
        Me.Controls.Add(Me.chkLoggingEnabled)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtUPSManifestFile)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtUSMailPackageFile)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtUPSPackageFile)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ApplicationSettingsMaintenance"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Application Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbLoggingLevel As System.Windows.Forms.ComboBox
    Friend WithEvents chkLoggingEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtPackageID As System.Windows.Forms.TextBox
    Friend WithEvents txtNextPackageID As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtLogFilename As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtUSMailManifestFile As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtUPSManifestFile As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtUSMailPackageFile As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtUPSPackageFile As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
