Imports System.Diagnostics.Eventing
Imports System.IO
Imports System.Runtime.InteropServices
Public Class Form1
    Public sr As StreamReader
    Public line As String
    Public found1stHash As New Boolean
    Public found2ndHash As New Boolean
    Public lineNumber As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        sr = New StreamReader("set.txt")
        line = New String("")
        line = sr.ReadLine

        Dim lineNumber As Integer
        lineNumber = 0
        found1stHash = False
        found2ndHash = False

        makeSet(line)

    End Sub

    Function makeSet(line As String) As String
        If line Is Nothing Then
            Return 1
        End If

        If foundFirstHash(line) Then 'if we found first hash, we token the next two lines as title and date respectively
            lineNumber = lineNumber + 1
            makeSet(sr.ReadLine)
        End If

        If foundSecondHash(line) Then 'if we found second hash, that concludes one set
            'Reset counter
            lineNumber = 0
            makeSet(sr.ReadLine)
        End If

        If lineNumber = 1 Then 'token as title
            MessageBox.Show("Title: " + line)
            lineNumber = lineNumber + 1
            makeSet(sr.ReadLine)
        End If

        If lineNumber = 2 Then 'token as date
            MessageBox.Show("Date: " + line)
            lineNumber = lineNumber + 1
            makeSet(sr.ReadLine)
        End If

        If lineNumber = 3 Then
            MessageBox.Show("Item: " + line)
            makeSet(sr.ReadLine)
        End If
    End Function

    Private Function foundSecondHash(ByRef line As String) As Boolean
        If line.Contains("#") And found1stHash = True And found2ndHash = False Then
            'Reset flags
            found1stHash = False
            Return True
        Else
            Return False
        End If
    End Function

    Private Function foundFirstHash(line As String) As Boolean
        If line.Contains("#") And found1stHash = False And found2ndHash = False Then
            'Correcting flags
            found1stHash = True
            Return True
        Else
            Return False
        End If
    End Function

End Class
