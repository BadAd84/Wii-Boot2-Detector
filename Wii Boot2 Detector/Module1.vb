Imports System
Imports System.Security.Cryptography
Imports System.IO
Module Module1
    Public Function MD5CalcFile(ByVal pathsource As String) As String
        Dim outputhash As String = "Error"
        Try
            Using fsSource As FileStream = New FileStream(pathsource, _
                FileMode.Open, FileAccess.Read)
                ' Read the source file into a byte array.
                Dim bytes() As Byte = New Byte((1081344) - 1) {}
                Dim numBytesToRead = 1081344
                Dim numBytesRead As Integer = 0

                While (numBytesToRead > 0)
                    ' Read may return anything from 0 to numBytesToRead.
                    Dim n As Integer = fsSource.Read(bytes, numBytesRead, _
                        numBytesToRead)
                    ' Break when the end of the file is reached.
                    If (n = 0) Then
                        Exit While
                    End If
                    numBytesRead = (numBytesRead + n)
                    numBytesToRead = (numBytesToRead - n)

                End While
                numBytesToRead = bytes.Length
                fsSource.Close()
                fsSource.Dispose()

                Using md5 As New System.Security.Cryptography.MD5CryptoServiceProvider
                    Dim hash() As Byte = md5.ComputeHash(bytes)


                    Dim sb As New System.Text.StringBuilder(hash.Length * 2)

                    For i As Integer = 0 To hash.Length - 1
                        sb.Append(hash(i).ToString("X2"))
                    Next

                    outputhash = sb.ToString().ToLower()
                    Return outputhash
                End Using

            End Using
        Catch ioEx As FileNotFoundException
            Console.WriteLine(ioEx.Message)
        End Try

        Return outputhash
    End Function
    Public Function GetFilename() As String

        Dim output As String = ""
        Form1.OpenFileDialog1.FileName = ""
        Form1.OpenFileDialog1.ShowDialog()
        output = Form1.OpenFileDialog1.FileName
        Return output

    End Function

    Public Function dec2baseN(ByVal value, ByVal outBase) As String

        'Converts base 10 to any base
        Dim q 'quotient
        Dim r 'remainder
        Dim m 'denominator
        Dim y As String = "" 'will hold converted value
        m = outBase
        q = value
        Do
            r = q Mod m
            q = Int(q / m)
            If r >= 10 Then
                r = Chr(65 + (r - 10))
            End If
            y = y & CStr(r)
        Loop Until q = 0
        If y.Length = 1 Then
            y = y & "0"
        End If
        dec2baseN = StrReverse(y)
    End Function

    Public Function GetBoot1(ByVal Path As String) As String
        Dim boot1 As String = "Unknown"
        Dim ReadByte As String = ""

        ReadByte = GetByte(Path, "40")

        ' check read byte against currently known boot1 versions
        If ReadByte = "99" Then
            boot1 = "Boot1a"
        ElseIf ReadByte = "C1" Then
            boot1 = "Boot1b"
        ElseIf ReadByte = "FC" Then
            boot1 = "Boot1c"
        ElseIf ReadByte = "48" Then
            boot1 = "Boot1d"
        End If

        Return boot1
    End Function
    Public Function GetBoot2(ByVal Path As String) As String
        Dim boot2 As String = "Unknown"
        Dim ReadByte As String = ""

        ReadByte = GetByte(Path, "21a64")

        ' test for boot2v2
        If ReadByte = "63" Then ' 63 means boot2v2 and either bootmii or stock
            ReadByte = GetByte(Path, "63024")
            If ReadByte = "FF" Then 'FF means stock or bootmii was removed
                boot2 = "Boot2v2 (Stock)"
            ElseIf ReadByte = "B3" Then 'B3 means bootmii is currently still installed
                boot2 = "Boot2v2 (Bootmii)"
            End If
        End If

        If ReadByte = "7A" Then ' 7A means boot2v2 and either bootmii or stock
            ReadByte = GetByte(Path, "63024")
            If ReadByte = "FF" Then 'FF bootmii was removed
                boot2 = "Boot2v2 (Stock)"
            ElseIf ReadByte = "B3" Then 'B3 means bootmii is currently still installed
                boot2 = "Boot2v2 (Bootmii)"
            End If
        End If

        ' tests for boot2v3
        If ReadByte = "1A" Then ' 1A means boot2v3 and either bootmii or stock
            ReadByte = GetByte(Path, "63024")
            If ReadByte = "FF" Then 'FF means stock or bootmii was removed
                boot2 = "Boot2v3 (Stock)"
            ElseIf ReadByte = "B3" Then 'B£ means bootmii is currently still installed
                boot2 = "Boot2v3 (Bootmii)"
            End If
        End If

        ' tests for boot2v4
        If ReadByte = "2F" Then '2F means boot2v4 and either bootmii or stock
            ReadByte = GetByte(Path, "63024")
            If ReadByte = "FF" Then 'FF means stock
                boot2 = "Boot2v4 (Stock)"
            ElseIf ReadByte = "B3" Then 'B3 means bootmii is currently still installed
                boot2 = "Boot2v4 (Bootmii)"
            End If
        End If

        If ReadByte = "33" Then ' 33 means boot2v4 but could be either bootmii or uninstalled
            ReadByte = GetByte(Path, "63024")
            If ReadByte = "FF" Then 'FF means stock or bootmii was removed
                boot2 = "Boot2v4 (Stock)"
            ElseIf ReadByte = "B3" Then 'B3 means bootmii is currently still installed
                boot2 = "Boot2v4 (Bootmii)"
            End If
        End If

        Return boot2
    End Function

    Public Function GetByte(ByVal path, ByVal offset) As String
        Dim boot1 As String = ""

        ' open the file passed through in path variable, read the byte at offset passed through 
        Dim fs As New FileStream(path, FileMode.Open, FileAccess.Read)
        fs.Position = "&H" & offset
        Dim b As Integer = fs.ReadByte()
        fs.Close()
        fs.Dispose()

        ' convert read byte from decimal into hex
        Dim ReadByte As String = ""
        ReadByte = dec2baseN(b, 16) ' convert B into base 16

        Return ReadByte
    End Function

End Module
