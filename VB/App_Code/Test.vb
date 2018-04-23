Imports Microsoft.VisualBasic
Imports System
Imports System.Threading
Imports System.Threading.Tasks

Public Class Test
	Private privateValue As Int32
	Public Property Value() As Int32
		Get
			Return privateValue
		End Get
		Set(ByVal value As Int32)
			privateValue = value
		End Set
	End Property

	Public Overrides Function ToString() As String
		Return Value.ToString()
	End Function
End Class