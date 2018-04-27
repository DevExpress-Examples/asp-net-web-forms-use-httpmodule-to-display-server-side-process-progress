Imports System
Imports System.Threading
Imports System.Threading.Tasks

Public Class Test
    Public Property Value() As Int32

    Public Overrides Function ToString() As String
        Return Value.ToString()
    End Function
End Class