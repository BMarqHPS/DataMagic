<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CSVFileViewer
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgvFileDisplay = New System.Windows.Forms.DataGridView
        Me.lblLineCount = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        CType(Me.dgvFileDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvFileDisplay
        '
        Me.dgvFileDisplay.AllowUserToAddRows = False
        Me.dgvFileDisplay.AllowUserToDeleteRows = False
        Me.dgvFileDisplay.AllowUserToResizeRows = False
        Me.dgvFileDisplay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFileDisplay.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvFileDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFileDisplay.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvFileDisplay.Location = New System.Drawing.Point(0, 0)
        Me.dgvFileDisplay.Name = "dgvFileDisplay"
        Me.dgvFileDisplay.ReadOnly = True
        Me.dgvFileDisplay.RowHeadersVisible = False
        Me.dgvFileDisplay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFileDisplay.Size = New System.Drawing.Size(638, 359)
        Me.dgvFileDisplay.TabIndex = 0
        Me.dgvFileDisplay.TabStop = False
        '
        'lblLineCount
        '
        Me.lblLineCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblLineCount.AutoSize = True
        Me.lblLineCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLineCount.Location = New System.Drawing.Point(22, 379)
        Me.lblLineCount.Name = "lblLineCount"
        Me.lblLineCount.Size = New System.Drawing.Size(89, 15)
        Me.lblLineCount.TabIndex = 4
        Me.lblLineCount.Text = "Line Count - "
        Me.lblLineCount.Visible = False
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(506, 372)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(120, 30)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'CSVFileViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(638, 414)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblLineCount)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.dgvFileDisplay)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "CSVFileViewer"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "CSVFileViewer"
        CType(Me.dgvFileDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvFileDisplay As System.Windows.Forms.DataGridView
    Friend WithEvents lblLineCount As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
