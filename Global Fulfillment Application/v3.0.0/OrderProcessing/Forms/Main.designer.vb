<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewUPSPackage = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewUSMailPackage = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuViewUPSManifest = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewUSMailManifest = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOrders = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOrdersValidate = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOrdersProcess = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOrdersUpdate = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuItems = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuItemsMaintenance = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuItemListExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpAppSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpAppSettingsApplication = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpAppSettingsLogging = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpAppSettingsProcessing = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpSep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsslblCurrentStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsspbCurrentProgress = New System.Windows.Forms.ToolStripProgressBar()
        Me.tsslblVersion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslblDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslblTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuView, Me.mnuOrders, Me.mnuItems, Me.mnuHelp})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 8, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(975, 26)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFileExit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(46, 22)
        Me.mnuFile.Text = "&File"
        '
        'mnuFileExit
        '
        Me.mnuFileExit.Name = "mnuFileExit"
        Me.mnuFileExit.Size = New System.Drawing.Size(103, 22)
        Me.mnuFileExit.Tag = "Exit"
        Me.mnuFileExit.Text = "E&xit"
        '
        'mnuView
        '
        Me.mnuView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuViewUPSPackage, Me.mnuViewUSMailPackage, Me.ToolStripMenuItem1, Me.mnuViewUPSManifest, Me.mnuViewUSMailManifest})
        Me.mnuView.Name = "mnuView"
        Me.mnuView.Size = New System.Drawing.Size(53, 22)
        Me.mnuView.Text = "&View"
        '
        'mnuViewUPSPackage
        '
        Me.mnuViewUPSPackage.Name = "mnuViewUPSPackage"
        Me.mnuViewUPSPackage.Size = New System.Drawing.Size(225, 22)
        Me.mnuViewUPSPackage.Tag = "UPS Package"
        Me.mnuViewUPSPackage.Text = "UPS Package File"
        '
        'mnuViewUSMailPackage
        '
        Me.mnuViewUSMailPackage.Name = "mnuViewUSMailPackage"
        Me.mnuViewUSMailPackage.Size = New System.Drawing.Size(225, 22)
        Me.mnuViewUSMailPackage.Tag = "US Mail Package"
        Me.mnuViewUSMailPackage.Text = "US Mail Package File"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(222, 6)
        '
        'mnuViewUPSManifest
        '
        Me.mnuViewUPSManifest.Name = "mnuViewUPSManifest"
        Me.mnuViewUPSManifest.Size = New System.Drawing.Size(225, 22)
        Me.mnuViewUPSManifest.Tag = "UPS Manifest"
        Me.mnuViewUPSManifest.Text = "UPS Manifest File"
        '
        'mnuViewUSMailManifest
        '
        Me.mnuViewUSMailManifest.Name = "mnuViewUSMailManifest"
        Me.mnuViewUSMailManifest.Size = New System.Drawing.Size(225, 22)
        Me.mnuViewUSMailManifest.Tag = "US Mail Manifest"
        Me.mnuViewUSMailManifest.Text = "US Mail Manifest File"
        '
        'mnuOrders
        '
        Me.mnuOrders.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOrdersValidate, Me.mnuOrdersProcess, Me.mnuOrdersUpdate})
        Me.mnuOrders.Name = "mnuOrders"
        Me.mnuOrders.Size = New System.Drawing.Size(70, 22)
        Me.mnuOrders.Text = "&Orders"
        '
        'mnuOrdersValidate
        '
        Me.mnuOrdersValidate.Name = "mnuOrdersValidate"
        Me.mnuOrdersValidate.Size = New System.Drawing.Size(152, 22)
        Me.mnuOrdersValidate.Tag = "Validate"
        Me.mnuOrdersValidate.Text = "&Validate"
        '
        'mnuOrdersProcess
        '
        Me.mnuOrdersProcess.Enabled = False
        Me.mnuOrdersProcess.Name = "mnuOrdersProcess"
        Me.mnuOrdersProcess.Size = New System.Drawing.Size(152, 22)
        Me.mnuOrdersProcess.Tag = "Process"
        Me.mnuOrdersProcess.Text = "&Process"
        '
        'mnuOrdersUpdate
        '
        Me.mnuOrdersUpdate.Name = "mnuOrdersUpdate"
        Me.mnuOrdersUpdate.Size = New System.Drawing.Size(152, 22)
        Me.mnuOrdersUpdate.Tag = "Update"
        Me.mnuOrdersUpdate.Text = "&Update"
        '
        'mnuItems
        '
        Me.mnuItems.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuItemsMaintenance, Me.mnuItemListExport})
        Me.mnuItems.Name = "mnuItems"
        Me.mnuItems.Size = New System.Drawing.Size(58, 22)
        Me.mnuItems.Text = "&Items"
        '
        'mnuItemsMaintenance
        '
        Me.mnuItemsMaintenance.Name = "mnuItemsMaintenance"
        Me.mnuItemsMaintenance.Size = New System.Drawing.Size(201, 22)
        Me.mnuItemsMaintenance.Tag = "Maintenance"
        Me.mnuItemsMaintenance.Text = "Item &Maintenance"
        '
        'mnuItemListExport
        '
        Me.mnuItemListExport.Name = "mnuItemListExport"
        Me.mnuItemListExport.Size = New System.Drawing.Size(201, 22)
        Me.mnuItemListExport.Tag = "Export"
        Me.mnuItemListExport.Text = "Item &List Export"
        Me.mnuItemListExport.Visible = False
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHelpAppSettings, Me.mnuHelpSep1, Me.mnuHelpAbout})
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Size = New System.Drawing.Size(53, 22)
        Me.mnuHelp.Text = "&Help"
        '
        'mnuHelpAppSettings
        '
        Me.mnuHelpAppSettings.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHelpAppSettingsApplication, Me.mnuHelpAppSettingsLogging, Me.mnuHelpAppSettingsProcessing})
        Me.mnuHelpAppSettings.Name = "mnuHelpAppSettings"
        Me.mnuHelpAppSettings.Size = New System.Drawing.Size(217, 22)
        Me.mnuHelpAppSettings.Tag = "ApplicationSettings"
        Me.mnuHelpAppSettings.Text = "Application &Settings"
        '
        'mnuHelpAppSettingsApplication
        '
        Me.mnuHelpAppSettingsApplication.Name = "mnuHelpAppSettingsApplication"
        Me.mnuHelpAppSettingsApplication.Size = New System.Drawing.Size(156, 22)
        Me.mnuHelpAppSettingsApplication.Tag = "Application"
        Me.mnuHelpAppSettingsApplication.Text = "&Application"
        '
        'mnuHelpAppSettingsLogging
        '
        Me.mnuHelpAppSettingsLogging.Name = "mnuHelpAppSettingsLogging"
        Me.mnuHelpAppSettingsLogging.Size = New System.Drawing.Size(156, 22)
        Me.mnuHelpAppSettingsLogging.Tag = "Logging"
        Me.mnuHelpAppSettingsLogging.Text = "&Logging"
        '
        'mnuHelpAppSettingsProcessing
        '
        Me.mnuHelpAppSettingsProcessing.Name = "mnuHelpAppSettingsProcessing"
        Me.mnuHelpAppSettingsProcessing.Size = New System.Drawing.Size(156, 22)
        Me.mnuHelpAppSettingsProcessing.Tag = "Processing"
        Me.mnuHelpAppSettingsProcessing.Text = "&Processing"
        '
        'mnuHelpSep1
        '
        Me.mnuHelpSep1.Name = "mnuHelpSep1"
        Me.mnuHelpSep1.Size = New System.Drawing.Size(214, 6)
        Me.mnuHelpSep1.Visible = False
        '
        'mnuHelpAbout
        '
        Me.mnuHelpAbout.Name = "mnuHelpAbout"
        Me.mnuHelpAbout.Size = New System.Drawing.Size(217, 22)
        Me.mnuHelpAbout.Tag = "About"
        Me.mnuHelpAbout.Text = "&About"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslblCurrentStatus, Me.tsspbCurrentProgress, Me.tsslblVersion, Me.tsslblDate, Me.tsslblTime})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 600)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(975, 26)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsslblCurrentStatus
        '
        Me.tsslblCurrentStatus.AutoSize = False
        Me.tsslblCurrentStatus.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslblCurrentStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.tsslblCurrentStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsslblCurrentStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tsslblCurrentStatus.Name = "tsslblCurrentStatus"
        Me.tsslblCurrentStatus.Size = New System.Drawing.Size(339, 21)
        Me.tsslblCurrentStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tsspbCurrentProgress
        '
        Me.tsspbCurrentProgress.Name = "tsspbCurrentProgress"
        Me.tsspbCurrentProgress.Size = New System.Drawing.Size(167, 20)
        Me.tsspbCurrentProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'tsslblVersion
        '
        Me.tsslblVersion.AutoSize = False
        Me.tsslblVersion.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslblVersion.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.tsslblVersion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsslblVersion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tsslblVersion.Name = "tsslblVersion"
        Me.tsslblVersion.Size = New System.Drawing.Size(50, 21)
        Me.tsslblVersion.Text = "v1.15"
        '
        'tsslblDate
        '
        Me.tsslblDate.AutoSize = False
        Me.tsslblDate.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslblDate.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.tsslblDate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsslblDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tsslblDate.Name = "tsslblDate"
        Me.tsslblDate.Size = New System.Drawing.Size(100, 21)
        Me.tsslblDate.Text = "10-24-2010"
        '
        'tsslblTime
        '
        Me.tsslblTime.AutoSize = False
        Me.tsslblTime.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslblTime.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.tsslblTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsslblTime.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tsslblTime.Name = "tsslblTime"
        Me.tsslblTime.Size = New System.Drawing.Size(100, 21)
        Me.tsslblTime.Text = "10:00 PM"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 60000
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(975, 626)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Order File Processor"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuItems As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuItemsMaintenance As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelpAppSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelpSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuHelpAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslblCurrentStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslblTime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslblDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents mnuHelpAppSettingsApplication As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelpAppSettingsLogging As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsspbCurrentProgress As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents mnuHelpAppSettingsProcessing As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsslblVersion As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents mnuItemListExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOrders As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOrdersProcess As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOrdersUpdate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOrdersValidate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewUPSPackage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewUSMailPackage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuViewUPSManifest As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewUSMailManifest As System.Windows.Forms.ToolStripMenuItem

End Class
