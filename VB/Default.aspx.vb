Imports Microsoft.VisualBasic
Imports System
Imports System.Threading
Imports System.Threading.Tasks

Partial Public Class _Default
	Inherits System.Web.UI.Page

	Protected Sub cbak_Callback(ByVal source As Object, ByVal e As DevExpress.Web.ASPxCallback.CallbackEventArgs)
		e.Result = StartTask().ToString()
	End Sub

	Private Function StartTask() As Int32
		Dim startingTask = Task.Factory.StartNew(AddressOf AnonymousMethod1, New Test())
		Return TaskManager.Register(startingTask, False)
	End Function
	
	Private Sub AnonymousMethod1(ByVal state As Object)
		Dim test = TryCast(state, Test)
		Do While test.Value < 100
			Thread.Sleep(50)
			test.Value += 1
		Loop
	End Sub
End Class