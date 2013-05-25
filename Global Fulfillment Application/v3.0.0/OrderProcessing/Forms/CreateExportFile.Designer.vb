<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateExportFile
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
        Me.btnContinue = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.dlgFileOpen = New System.Windows.Forms.OpenFileDialog()
        Me.btnBrowseUPSFile = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUPSDataFile = New System.Windows.Forms.TextBox()
        Me.btnBrowseUSMailFile = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtUSMailDataFile = New System.Windows.Forms.TextBox()
        Me.dlgFileSave = New System.Windows.Forms.SaveFileDialog()
        Me.grpManifests = New System.Windows.Forms.GroupBox()
        Me.grpManifests.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnContinue
        '
        Me.btnContinue.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnContinue.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnContinue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContinue.Location = New System.Drawing.Point(195, 338)
        Me.btnContinue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnContinue.Name = "btnContinue"
        Me.btnContinue.Size = New System.Drawing.Size(100, 31)
        Me.btnContinue.TabIndex = 6
        Me.btnContinue.Tag = "Continue"
        Me.btnContinue.Text = "&Continue"
        Me.btnContinue.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnContinue.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(391, 338)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(100, 31)
        Me.btnExit.TabIndex = 7
        Me.btnExit.Tag = "Exit"
        Me.btnExit.Text = "E&xit"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnBrowseUPSFile
        '
        Me.btnBrowseUPSFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowseUPSFile.Location = New System.Drawing.Point(529, 48)
        Me.btnBrowseUPSFile.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnBrowseUPSFile.Name = "btnBrowseUPSFile"
        Me.btnBrowseUPSFile.Size = New System.Drawing.Size(100, 28)
        Me.btnBrowseUPSFile.TabIndex = 1
        Me.btnBrowseUPSFile.Tag = "UPSDataFile"
        Me.btnBrowseUPSFile.Text = "Browse..."
        Me.btnBrowseUPSFile.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBrowseUPSFile.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(33, 27)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 18)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "UPS Data File"
        '
        'txtUPSDataFile
        '
        Me.txtUPSDataFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUPSDataFile.Location = New System.Drawing.Point(31, 49)
        Me.txtUPSDataFile.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtUPSDataFile.Name = "txtUPSDataFile"
        Me.txtUPSDataFile.Size = New System.Drawing.Size(472, 24)
        Me.txtUPSDataFile.TabIndex = 0
        '
        'btnBrowseUSMailFile
        '
        Me.btnBrowseUSMailFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowseUSMailFile.Location = New System.Drawing.Point(529, 114)
        Me.btnBrowseUSMailFile.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnBrowseUSMailFile.Name = "btnBrowseUSMailFile"
        Me.btnBrowseUSMailFile.Size = New System.Drawing.Size(100, 28)
        Me.btnBrowseUSMailFile.TabIndex = 3
        Me.btnBrowseUSMailFile.Tag = "USMailDataFile"
        Me.btnBrowseUSMailFile.Text = "Browse..."
        Me.btnBrowseUSMailFile.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBrowseUSMailFile.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(33, 94)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 18)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "USPS Data File"
        '
        'txtUSMailDataFile
        '
        Me.txtUSMailDataFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUSMailDataFile.Location = New System.Drawing.Point(31, 116)
        Me.txtUSMailDataFile.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtUSMailDataFile.Name = "txtUSMailDataFile"
        Me.txtUSMailDataFile.Size = New System.Drawing.Size(472, 24)
        Me.txtUSMailDataFile.TabIndex = 2
        '
        'grpManifests
        '
        Me.grpManifests.Controls.Add(Me.btnBrowseUSMailFile)
        Me.grpManifests.Controls.Add(Me.txtUPSDataFile)
        Me.grpManifests.Controls.Add(Me.Label3)
        Me.grpManifests.Controls.Add(Me.Label1)
        Me.grpManifests.Controls.Add(Me.txtUSMailDataFile)
        Me.grpManifests.Controls.Add(Me.btnBrowseUPSFile)
        Me.grpManifests.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpManifests.Location = New System.Drawing.Point(15, 15)
        Me.grpManifests.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grpManifests.Name = "grpManifests"
        Me.grpManifests.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grpManifests.Size = New System.Drawing.Size(656, 171)
        Me.grpManifests.TabIndex = 11
        Me.grpManifests.TabStop = False
        Me.grpManifests.Text = "Manifest Files"
        '
        'CreateExportFile
        '
        Me.AcceptButton = Me.btnContinue
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(687, 384)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpManifests)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnContinue)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "CreateExportFile"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Export File Setup"
        Me.grpManifests.ResumeLayout(False)
        Me.grpManifests.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnContinue As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents dlgFileOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnBrowseUPSFile As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUPSDataFile As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowseUSMailFile As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUSMailDataFile As System.Windows.Forms.TextBox
    Friend WithEvents dlgFileSave As System.Windows.Forms.SaveFileDialog
    Friend WithEvents grpManifests As System.Windows.Forms.GroupBox
End Class
