Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.SessionState
Imports System.Threading.Tasks

Public Class CustomModule
	Implements IHttpModule

	Public Sub Dispose() Implements IHttpModule.Dispose		
	End Sub

	Public Sub Init(ByVal application As HttpApplication) Implements IHttpModule.Init
		AddHandler application.AcquireRequestState, AddressOf application_AcquireRequestState
	End Sub

	Private Sub application_AcquireRequestState(ByVal sender As Object, ByVal e As EventArgs)
		Dim context = (TryCast(sender, HttpApplication)).Context
		Dim taskID = context.Request.QueryString("proc")
		Dim isProgressQuery = Not String.IsNullOrEmpty(taskID)
		If isProgressQuery Then
			context.Response.CacheControl = "No-cache"
			Dim task = TaskManager.FindTask(Int32.Parse(taskID))
			Dim progress = task.AsyncState.ToString()
			context.Response.Write(progress)
			context.Response.End()
		End If
	End Sub
End Class