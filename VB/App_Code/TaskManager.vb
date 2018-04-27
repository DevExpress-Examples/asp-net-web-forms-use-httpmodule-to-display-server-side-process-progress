Imports System
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Collections.Generic

Public NotInheritable Class TaskManager

    Private Sub New()
    End Sub

    Private Shared _tasks As Dictionary(Of Int32, Task) = New Dictionary(Of Int32,Task)()
    Private Shared l_lock As New Object()

    Public Shared Function Register(ByVal task As Task) As Int32
        _tasks.Add(task.Id, task)
        Return task.Id
    End Function

    Public Shared Function Register(ByVal task As Task, ByVal dispose As Boolean) As Int32
        SyncLock l_lock
            If dispose Then
                task.ContinueWith(Sub(reference)
                    _tasks.Remove(reference.Id)
                    reference.Dispose()
                End Sub)
            End If
            Return Register(task)
        End SyncLock
    End Function

    Public Shared Function FindTask(ByVal id As Int32) As Task
        SyncLock l_lock
            Return _tasks(id)
        End SyncLock
    End Function
End Class
