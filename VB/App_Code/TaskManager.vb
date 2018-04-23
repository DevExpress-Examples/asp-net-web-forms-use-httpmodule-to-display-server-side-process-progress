Imports Microsoft.VisualBasic
Imports System
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Collections.Generic

Public NotInheritable Class TaskManager
	Private Shared _tasks As New Dictionary(Of Int32, Task)()
	Private Shared l_lock As New Object()

	Private Sub New()
	End Sub
	Public Shared Function Register(ByVal task As Task) As Int32
		_tasks.Add(task.Id, task)
		Return task.Id
	End Function

	Public Shared Function Register(ByVal task As Task, ByVal dispose As Boolean) As Int32
		SyncLock l_lock
			If dispose Then
				task.ContinueWith(AddressOf AnonymousMethod1)
			End If
			Return Register(task)
		End SyncLock
	End Function
	
	Private Shared Sub AnonymousMethod1(ByVal reference As Object)
		_tasks.Remove(reference.Id)
		reference.Dispose()
	End Sub

	Public Shared Function FindTask(ByVal id As Int32) As Task
		SyncLock l_lock
			Return _tasks(id)
		End SyncLock
	End Function
End Class
