<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frmabout
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
        Me.btn_close = New System.Windows.Forms.Button()
        Me.lbl_text = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btn_close
        '
        Me.btn_close.Location = New System.Drawing.Point(53, 93)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(125, 23)
        Me.btn_close.TabIndex = 0
        Me.btn_close.Text = "Close"
        Me.btn_close.UseVisualStyleBackColor = True
        '
        'lbl_text
        '
        Me.lbl_text.Location = New System.Drawing.Point(1, 9)
        Me.lbl_text.Name = "lbl_text"
        Me.lbl_text.Size = New System.Drawing.Size(247, 81)
        Me.lbl_text.TabIndex = 1
        Me.lbl_text.Text = "This is an internal tool only and not for distribution." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "The only authorised us" & _
            "ers of this application are Bad_Ad84, Erikie and WiiHacks Staff." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Bad_Ad84"
        '
        'Frmabout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(245, 124)
        Me.ControlBox = False
        Me.Controls.Add(Me.lbl_text)
        Me.Controls.Add(Me.btn_close)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Frmabout"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "About..."
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_close As System.Windows.Forms.Button
    Friend WithEvents lbl_text As System.Windows.Forms.Label
End Class
