Imports System
Imports System.Security.Cryptography
Imports System.IO

Public Class Form1

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Dim filename As String = ""
        Dim Boot1Ver As String = ""
        Dim Boot2Ver As String = ""
        Dim md5sum As String = ""


        ' call getfilename, to open file dialog and get the filename
        ' then pass filename through md5sum if not null
        filename = GetFilename()
        If filename <> "" Then

            ' generate MD5 of bootblocks
            md5sum = MD5CalcFile(filename)

            ' put filename on form
            lbl_file.Text = filename
            ' put md5sum on form
            lbl_md5.Text = md5sum
            'enable copy md5sum now that it exists
            CopyToolStripMenuItem.Enabled = True

            ' get boot1 version
            Boot1Ver = GetBoot1(filename)
            lbl_boot1.Text = Boot1Ver

            '' get boot2 version
            Boot2Ver = GetBoot2(filename)
            lbl_boot2.Text = Boot2Ver

        Else
            'filename not read, abort stuff
        End If


    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        Clipboard.SetDataObject(lbl_md5.Text)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbl_boot1.Text = ""
        lbl_boot2.Text = ""
        CopyToolStripMenuItem.Enabled = False
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Frmabout.Show()
        Me.Enabled = False

    End Sub
End Class
