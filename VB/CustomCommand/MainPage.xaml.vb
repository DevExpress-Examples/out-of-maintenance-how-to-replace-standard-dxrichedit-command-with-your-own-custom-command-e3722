Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports DevExpress.XtraRichEdit.Services
Imports DevExpress.Xpf.RichEdit

Namespace CustomCommand
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
			richEditControl1.ApplyTemplate()
			AddHandler richEditControl1.Loaded, AddressOf richEditControl1_Loaded
		End Sub

		Private Sub richEditControl1_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			ReplaceRichEditCommandFactoryService(richEditControl1)
		End Sub


		Private Sub ReplaceRichEditCommandFactoryService(ByVal control As RichEditControl)
			Dim service As IRichEditCommandFactoryService = control.GetService(Of IRichEditCommandFactoryService)()
			If service Is Nothing Then
				Return
			End If
			control.ReplaceService(Of IRichEditCommandFactoryService)(New CustomRichEditCommandFactoryService(control, service))
		End Sub

	End Class
End Namespace
