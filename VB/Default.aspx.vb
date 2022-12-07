Option Infer On

Imports System
Imports System.Threading
Imports System.Threading.Tasks

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub cbak_Callback(ByVal source As Object, ByVal e As DevExpress.Web.CallbackEventArgs)
        e.Result = StartTask().ToString()
    End Sub

    Private Function StartTask() As Int32
        Dim startingTask = Task.Factory.StartNew(Sub(state)
            Dim test = TryCast(state, Test)
            Do While test.Value < 100
                Thread.Sleep(50)
                test.Value += 1
            Loop
        End Sub, New Test())
        Return TaskManager.Register(startingTask, False)
    End Function
End Class